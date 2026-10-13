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
   public class comisionesprofesionaleswc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public comisionesprofesionaleswc( )
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

      public comisionesprofesionaleswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ComisionesID )
      {
         this.AV8ComisionesID = aP0_ComisionesID;
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ComisionesID");
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
                  AV8ComisionesID = (long)(Math.Round(NumberUtil.Val( GetPar( "ComisionesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8ComisionesID", StringUtil.LTrimStr( (decimal)(AV8ComisionesID), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV8ComisionesID});
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
                  gxfirstwebparm = GetFirstPar( "ComisionesID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ComisionesID");
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
         nRC_GXsfl_15 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_15"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_15_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_15_idx = GetPar( "sGXsfl_15_idx");
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
         AV8ComisionesID = (long)(Math.Round(NumberUtil.Val( GetPar( "ComisionesID"), "."), 18, MidpointRounding.ToEven));
         AV39Pgmname = GetPar( "Pgmname");
         AV17TFProfesionalesId = GetPar( "TFProfesionalesId");
         AV18TFProfesionalesId_Sel = GetPar( "TFProfesionalesId_Sel");
         AV19TFProfesionalesPrimerNombre = GetPar( "TFProfesionalesPrimerNombre");
         AV20TFProfesionalesPrimerNombre_Sel = GetPar( "TFProfesionalesPrimerNombre_Sel");
         AV21TFProfesionalesSegundoNombre = GetPar( "TFProfesionalesSegundoNombre");
         AV22TFProfesionalesSegundoNombre_Sel = GetPar( "TFProfesionalesSegundoNombre_Sel");
         AV23TFProfesionalesApellidoPrimero = GetPar( "TFProfesionalesApellidoPrimero");
         AV24TFProfesionalesApellidoPrimero_Sel = GetPar( "TFProfesionalesApellidoPrimero_Sel");
         AV25TFProfesionalesApellidoSegundo = GetPar( "TFProfesionalesApellidoSegundo");
         AV26TFProfesionalesApellidoSegundo_Sel = GetPar( "TFProfesionalesApellidoSegundo_Sel");
         AV27TFProfesionalesTelefono = GetPar( "TFProfesionalesTelefono");
         AV28TFProfesionalesTelefono_Sel = GetPar( "TFProfesionalesTelefono_Sel");
         AV29TFEstadosGenericosNombre = GetPar( "TFEstadosGenericosNombre");
         AV30TFEstadosGenericosNombre_Sel = GetPar( "TFEstadosGenericosNombre_Sel");
         AV38IsAuthorized_EstadosGenericosNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_EstadosGenericosNombre"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ComisionesID, AV39Pgmname, AV17TFProfesionalesId, AV18TFProfesionalesId_Sel, AV19TFProfesionalesPrimerNombre, AV20TFProfesionalesPrimerNombre_Sel, AV21TFProfesionalesSegundoNombre, AV22TFProfesionalesSegundoNombre_Sel, AV23TFProfesionalesApellidoPrimero, AV24TFProfesionalesApellidoPrimero_Sel, AV25TFProfesionalesApellidoSegundo, AV26TFProfesionalesApellidoSegundo_Sel, AV27TFProfesionalesTelefono, AV28TFProfesionalesTelefono_Sel, AV29TFEstadosGenericosNombre, AV30TFEstadosGenericosNombre_Sel, AV38IsAuthorized_EstadosGenericosNombre, sPrefix) ;
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
            PA4D2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV39Pgmname = "ComisionesProfesionalesWC";
               WS4D2( ) ;
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
            context.SendWebValue( context.GetMessage( "Comisiones Profesionales WC", "")) ;
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
            GXEncryptionTmp = "comisionesprofesionaleswc.aspx"+UrlEncode(StringUtil.LTrimStr(AV8ComisionesID,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("comisionesprofesionaleswc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV39Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV39Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", AV38IsAuthorized_EstadosGenericosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", GetSecureSignedToken( sPrefix, AV38IsAuthorized_EstadosGenericosNombre, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_15", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_15), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV36GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV31DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV31DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8ComisionesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV39Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV39Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESID", StringUtil.RTrim( AV17TFProfesionalesId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESID_SEL", StringUtil.RTrim( AV18TFProfesionalesId_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESPRIMERNOMBRE", StringUtil.RTrim( AV19TFProfesionalesPrimerNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESPRIMERNOMBRE_SEL", StringUtil.RTrim( AV20TFProfesionalesPrimerNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESSEGUNDONOMBRE", StringUtil.RTrim( AV21TFProfesionalesSegundoNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESSEGUNDONOMBRE_SEL", StringUtil.RTrim( AV22TFProfesionalesSegundoNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESAPELLIDOPRIMERO", StringUtil.RTrim( AV23TFProfesionalesApellidoPrimero));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESAPELLIDOPRIMERO_SEL", StringUtil.RTrim( AV24TFProfesionalesApellidoPrimero_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESAPELLIDOSEGUNDO", StringUtil.RTrim( AV25TFProfesionalesApellidoSegundo));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESAPELLIDOSEGUNDO_SEL", StringUtil.RTrim( AV26TFProfesionalesApellidoSegundo_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESTELEFONO", StringUtil.RTrim( AV27TFProfesionalesTelefono));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESTELEFONO_SEL", StringUtil.RTrim( AV28TFProfesionalesTelefono_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTADOSGENERICOSNOMBRE", StringUtil.RTrim( AV29TFEstadosGenericosNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTADOSGENERICOSNOMBRE_SEL", StringUtil.RTrim( AV30TFEstadosGenericosNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOMISIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", AV38IsAuthorized_EstadosGenericosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", GetSecureSignedToken( sPrefix, AV38IsAuthorized_EstadosGenericosNombre, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
      }

      protected void RenderHtmlCloseForm4D2( )
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
         return "ComisionesProfesionalesWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Comisiones Profesionales WC", "") ;
      }

      protected void WB4D0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "comisionesprofesionaleswc.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl15( ) ;
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            nRC_GXsfl_15 = (int)(nGXsfl_15_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV34GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV35GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV36GridAppliedFilters);
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
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV31DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtComisionesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A503ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A503ComisionesID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesID_Jsonclick, 0, "Attribute", "", "", "", "", edtComisionesID_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ComisionesProfesionalesWC.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 15 )
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

      protected void START4D2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Comisiones Profesionales WC", ""), 0) ;
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
               STRUP4D0( ) ;
            }
         }
      }

      protected void WS4D2( )
      {
         START4D2( ) ;
         EVT4D2( ) ;
      }

      protected void EVT4D2( )
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
                                 STRUP4D0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E114D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E124D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E134D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
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
                                 STRUP4D0( ) ;
                              }
                              nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                              A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
                              A191ProfesionalesSegundoNombre = cgiGet( edtProfesionalesSegundoNombre_Internalname);
                              A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
                              A192ProfesionalesApellidoSegundo = cgiGet( edtProfesionalesApellidoSegundo_Internalname);
                              A170ProfesionalesTelefono = cgiGet( edtProfesionalesTelefono_Internalname);
                              A107EstadosTipo = cgiGet( edtEstadosTipo_Internalname);
                              A108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosGenericosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A109EstadosGenericosNombre = cgiGet( edtEstadosGenericosNombre_Internalname);
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
                                          /* Execute user event: Start */
                                          E144D2 ();
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
                                          /* Execute user event: Refresh */
                                          E154D2 ();
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
                                          /* Execute user event: Grid.Load */
                                          E164D2 ();
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
                                       STRUP4D0( ) ;
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

      protected void WE4D2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4D2( ) ;
            }
         }
      }

      protected void PA4D2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "comisionesprofesionaleswc.aspx")), "comisionesprofesionaleswc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "comisionesprofesionaleswc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ComisionesID");
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
         SubsflControlProps_152( ) ;
         while ( nGXsfl_15_idx <= nRC_GXsfl_15 )
         {
            sendrow_152( ) ;
            nGXsfl_15_idx = ((subGrid_Islastpage==1)&&(nGXsfl_15_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       long AV8ComisionesID ,
                                       string AV39Pgmname ,
                                       string AV17TFProfesionalesId ,
                                       string AV18TFProfesionalesId_Sel ,
                                       string AV19TFProfesionalesPrimerNombre ,
                                       string AV20TFProfesionalesPrimerNombre_Sel ,
                                       string AV21TFProfesionalesSegundoNombre ,
                                       string AV22TFProfesionalesSegundoNombre_Sel ,
                                       string AV23TFProfesionalesApellidoPrimero ,
                                       string AV24TFProfesionalesApellidoPrimero_Sel ,
                                       string AV25TFProfesionalesApellidoSegundo ,
                                       string AV26TFProfesionalesApellidoSegundo_Sel ,
                                       string AV27TFProfesionalesTelefono ,
                                       string AV28TFProfesionalesTelefono_Sel ,
                                       string AV29TFEstadosGenericosNombre ,
                                       string AV30TFEstadosGenericosNombre_Sel ,
                                       bool AV38IsAuthorized_EstadosGenericosNombre ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4D2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
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
         RF4D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV39Pgmname = "ComisionesProfesionalesWC";
      }

      protected void RF4D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 15;
         /* Execute user event: Refresh */
         E154D2 ();
         nGXsfl_15_idx = 1;
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         bGXsfl_15_Refreshing = true;
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
            SubsflControlProps_152( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV18TFProfesionalesId_Sel ,
                                                 AV17TFProfesionalesId ,
                                                 AV20TFProfesionalesPrimerNombre_Sel ,
                                                 AV19TFProfesionalesPrimerNombre ,
                                                 AV22TFProfesionalesSegundoNombre_Sel ,
                                                 AV21TFProfesionalesSegundoNombre ,
                                                 AV24TFProfesionalesApellidoPrimero_Sel ,
                                                 AV23TFProfesionalesApellidoPrimero ,
                                                 AV26TFProfesionalesApellidoSegundo_Sel ,
                                                 AV25TFProfesionalesApellidoSegundo ,
                                                 AV28TFProfesionalesTelefono_Sel ,
                                                 AV27TFProfesionalesTelefono ,
                                                 AV30TFEstadosGenericosNombre_Sel ,
                                                 AV29TFEstadosGenericosNombre ,
                                                 A120ProfesionalesId ,
                                                 A166ProfesionalesPrimerNombre ,
                                                 A191ProfesionalesSegundoNombre ,
                                                 A167ProfesionalesApellidoPrimero ,
                                                 A192ProfesionalesApellidoSegundo ,
                                                 A170ProfesionalesTelefono ,
                                                 A109EstadosGenericosNombre ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV8ComisionesID ,
                                                 A503ComisionesID } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV17TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesId), 20, "%");
            lV19TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesPrimerNombre), 30, "%");
            lV21TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesSegundoNombre), 30, "%");
            lV23TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV23TFProfesionalesApellidoPrimero), 30, "%");
            lV25TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV25TFProfesionalesApellidoSegundo), 30, "%");
            lV27TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV27TFProfesionalesTelefono), 20, "%");
            lV29TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV29TFEstadosGenericosNombre), 80, "%");
            /* Using cursor H004D2 */
            pr_default.execute(0, new Object[] {AV8ComisionesID, lV17TFProfesionalesId, AV18TFProfesionalesId_Sel, lV19TFProfesionalesPrimerNombre, AV20TFProfesionalesPrimerNombre_Sel, lV21TFProfesionalesSegundoNombre, AV22TFProfesionalesSegundoNombre_Sel, lV23TFProfesionalesApellidoPrimero, AV24TFProfesionalesApellidoPrimero_Sel, lV25TFProfesionalesApellidoSegundo, AV26TFProfesionalesApellidoSegundo_Sel, lV27TFProfesionalesTelefono, AV28TFProfesionalesTelefono_Sel, lV29TFEstadosGenericosNombre, AV30TFEstadosGenericosNombre_Sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_15_idx = 1;
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A503ComisionesID = H004D2_A503ComisionesID[0];
               AssignAttri(sPrefix, false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
               A109EstadosGenericosNombre = H004D2_A109EstadosGenericosNombre[0];
               A108EstadosGenericosId = H004D2_A108EstadosGenericosId[0];
               A107EstadosTipo = H004D2_A107EstadosTipo[0];
               A170ProfesionalesTelefono = H004D2_A170ProfesionalesTelefono[0];
               A192ProfesionalesApellidoSegundo = H004D2_A192ProfesionalesApellidoSegundo[0];
               A167ProfesionalesApellidoPrimero = H004D2_A167ProfesionalesApellidoPrimero[0];
               A191ProfesionalesSegundoNombre = H004D2_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = H004D2_A166ProfesionalesPrimerNombre[0];
               A120ProfesionalesId = H004D2_A120ProfesionalesId[0];
               A108EstadosGenericosId = H004D2_A108EstadosGenericosId[0];
               A107EstadosTipo = H004D2_A107EstadosTipo[0];
               A170ProfesionalesTelefono = H004D2_A170ProfesionalesTelefono[0];
               A192ProfesionalesApellidoSegundo = H004D2_A192ProfesionalesApellidoSegundo[0];
               A167ProfesionalesApellidoPrimero = H004D2_A167ProfesionalesApellidoPrimero[0];
               A191ProfesionalesSegundoNombre = H004D2_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = H004D2_A166ProfesionalesPrimerNombre[0];
               A109EstadosGenericosNombre = H004D2_A109EstadosGenericosNombre[0];
               /* Execute user event: Grid.Load */
               E164D2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 15;
            WB4D0( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4D2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV39Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV39Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", AV38IsAuthorized_EstadosGenericosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", GetSecureSignedToken( sPrefix, AV38IsAuthorized_EstadosGenericosNombre, context));
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV18TFProfesionalesId_Sel ,
                                              AV17TFProfesionalesId ,
                                              AV20TFProfesionalesPrimerNombre_Sel ,
                                              AV19TFProfesionalesPrimerNombre ,
                                              AV22TFProfesionalesSegundoNombre_Sel ,
                                              AV21TFProfesionalesSegundoNombre ,
                                              AV24TFProfesionalesApellidoPrimero_Sel ,
                                              AV23TFProfesionalesApellidoPrimero ,
                                              AV26TFProfesionalesApellidoSegundo_Sel ,
                                              AV25TFProfesionalesApellidoSegundo ,
                                              AV28TFProfesionalesTelefono_Sel ,
                                              AV27TFProfesionalesTelefono ,
                                              AV30TFEstadosGenericosNombre_Sel ,
                                              AV29TFEstadosGenericosNombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV8ComisionesID ,
                                              A503ComisionesID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV17TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesId), 20, "%");
         lV19TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesPrimerNombre), 30, "%");
         lV21TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesSegundoNombre), 30, "%");
         lV23TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV23TFProfesionalesApellidoPrimero), 30, "%");
         lV25TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV25TFProfesionalesApellidoSegundo), 30, "%");
         lV27TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV27TFProfesionalesTelefono), 20, "%");
         lV29TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV29TFEstadosGenericosNombre), 80, "%");
         /* Using cursor H004D3 */
         pr_default.execute(1, new Object[] {AV8ComisionesID, lV17TFProfesionalesId, AV18TFProfesionalesId_Sel, lV19TFProfesionalesPrimerNombre, AV20TFProfesionalesPrimerNombre_Sel, lV21TFProfesionalesSegundoNombre, AV22TFProfesionalesSegundoNombre_Sel, lV23TFProfesionalesApellidoPrimero, AV24TFProfesionalesApellidoPrimero_Sel, lV25TFProfesionalesApellidoSegundo, AV26TFProfesionalesApellidoSegundo_Sel, lV27TFProfesionalesTelefono, AV28TFProfesionalesTelefono_Sel, lV29TFEstadosGenericosNombre, AV30TFEstadosGenericosNombre_Sel});
         GRID_nRecordCount = H004D3_AGRID_nRecordCount[0];
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ComisionesID, AV39Pgmname, AV17TFProfesionalesId, AV18TFProfesionalesId_Sel, AV19TFProfesionalesPrimerNombre, AV20TFProfesionalesPrimerNombre_Sel, AV21TFProfesionalesSegundoNombre, AV22TFProfesionalesSegundoNombre_Sel, AV23TFProfesionalesApellidoPrimero, AV24TFProfesionalesApellidoPrimero_Sel, AV25TFProfesionalesApellidoSegundo, AV26TFProfesionalesApellidoSegundo_Sel, AV27TFProfesionalesTelefono, AV28TFProfesionalesTelefono_Sel, AV29TFEstadosGenericosNombre, AV30TFEstadosGenericosNombre_Sel, AV38IsAuthorized_EstadosGenericosNombre, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ComisionesID, AV39Pgmname, AV17TFProfesionalesId, AV18TFProfesionalesId_Sel, AV19TFProfesionalesPrimerNombre, AV20TFProfesionalesPrimerNombre_Sel, AV21TFProfesionalesSegundoNombre, AV22TFProfesionalesSegundoNombre_Sel, AV23TFProfesionalesApellidoPrimero, AV24TFProfesionalesApellidoPrimero_Sel, AV25TFProfesionalesApellidoSegundo, AV26TFProfesionalesApellidoSegundo_Sel, AV27TFProfesionalesTelefono, AV28TFProfesionalesTelefono_Sel, AV29TFEstadosGenericosNombre, AV30TFEstadosGenericosNombre_Sel, AV38IsAuthorized_EstadosGenericosNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ComisionesID, AV39Pgmname, AV17TFProfesionalesId, AV18TFProfesionalesId_Sel, AV19TFProfesionalesPrimerNombre, AV20TFProfesionalesPrimerNombre_Sel, AV21TFProfesionalesSegundoNombre, AV22TFProfesionalesSegundoNombre_Sel, AV23TFProfesionalesApellidoPrimero, AV24TFProfesionalesApellidoPrimero_Sel, AV25TFProfesionalesApellidoSegundo, AV26TFProfesionalesApellidoSegundo_Sel, AV27TFProfesionalesTelefono, AV28TFProfesionalesTelefono_Sel, AV29TFEstadosGenericosNombre, AV30TFEstadosGenericosNombre_Sel, AV38IsAuthorized_EstadosGenericosNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ComisionesID, AV39Pgmname, AV17TFProfesionalesId, AV18TFProfesionalesId_Sel, AV19TFProfesionalesPrimerNombre, AV20TFProfesionalesPrimerNombre_Sel, AV21TFProfesionalesSegundoNombre, AV22TFProfesionalesSegundoNombre_Sel, AV23TFProfesionalesApellidoPrimero, AV24TFProfesionalesApellidoPrimero_Sel, AV25TFProfesionalesApellidoSegundo, AV26TFProfesionalesApellidoSegundo_Sel, AV27TFProfesionalesTelefono, AV28TFProfesionalesTelefono_Sel, AV29TFEstadosGenericosNombre, AV30TFEstadosGenericosNombre_Sel, AV38IsAuthorized_EstadosGenericosNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ComisionesID, AV39Pgmname, AV17TFProfesionalesId, AV18TFProfesionalesId_Sel, AV19TFProfesionalesPrimerNombre, AV20TFProfesionalesPrimerNombre_Sel, AV21TFProfesionalesSegundoNombre, AV22TFProfesionalesSegundoNombre_Sel, AV23TFProfesionalesApellidoPrimero, AV24TFProfesionalesApellidoPrimero_Sel, AV25TFProfesionalesApellidoSegundo, AV26TFProfesionalesApellidoSegundo_Sel, AV27TFProfesionalesTelefono, AV28TFProfesionalesTelefono_Sel, AV29TFEstadosGenericosNombre, AV30TFEstadosGenericosNombre_Sel, AV38IsAuthorized_EstadosGenericosNombre, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV39Pgmname = "ComisionesProfesionalesWC";
         edtProfesionalesId_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesTelefono_Enabled = 0;
         edtEstadosTipo_Enabled = 0;
         edtEstadosGenericosId_Enabled = 0;
         edtEstadosGenericosNombre_Enabled = 0;
         edtComisionesID_Enabled = 0;
         AssignProp(sPrefix, false, edtComisionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesID_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E144D2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV31DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_15 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_15"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV34GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV35GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV36GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOAV8ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8ComisionesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            /* Read variables values. */
            A503ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtComisionesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
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
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E144D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E144D2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         GXt_boolean1 = AV38IsAuthorized_EstadosGenericosNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion", out  GXt_boolean1) ;
         AV38IsAuthorized_EstadosGenericosNombre = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV38IsAuthorized_EstadosGenericosNombre", AV38IsAuthorized_EstadosGenericosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", GetSecureSignedToken( sPrefix, AV38IsAuthorized_EstadosGenericosNombre, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         edtComisionesID_Visible = 0;
         AssignProp(sPrefix, false, edtComisionesID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtComisionesID_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
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
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV31DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV31DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E154D2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV34GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV34GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV34GridCurrentPage), 10, 0));
         AV35GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV35GridPageCount", StringUtil.LTrimStr( (decimal)(AV35GridPageCount), 10, 0));
         GXt_char3 = AV36GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV39Pgmname, out  GXt_char3) ;
         AV36GridAppliedFilters = GXt_char3;
         AssignAttri(sPrefix, false, "AV36GridAppliedFilters", AV36GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E114D2( )
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
            AV33PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV33PageToGo) ;
         }
         /*  Sending Event outputs  */
      }

      protected void E124D2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E134D2( )
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
            S132 ();
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
               AV17TFProfesionalesId = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV17TFProfesionalesId", AV17TFProfesionalesId);
               AV18TFProfesionalesId_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV18TFProfesionalesId_Sel", AV18TFProfesionalesId_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesPrimerNombre") == 0 )
            {
               AV19TFProfesionalesPrimerNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV19TFProfesionalesPrimerNombre", AV19TFProfesionalesPrimerNombre);
               AV20TFProfesionalesPrimerNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV20TFProfesionalesPrimerNombre_Sel", AV20TFProfesionalesPrimerNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesSegundoNombre") == 0 )
            {
               AV21TFProfesionalesSegundoNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV21TFProfesionalesSegundoNombre", AV21TFProfesionalesSegundoNombre);
               AV22TFProfesionalesSegundoNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV22TFProfesionalesSegundoNombre_Sel", AV22TFProfesionalesSegundoNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesApellidoPrimero") == 0 )
            {
               AV23TFProfesionalesApellidoPrimero = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV23TFProfesionalesApellidoPrimero", AV23TFProfesionalesApellidoPrimero);
               AV24TFProfesionalesApellidoPrimero_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV24TFProfesionalesApellidoPrimero_Sel", AV24TFProfesionalesApellidoPrimero_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesApellidoSegundo") == 0 )
            {
               AV25TFProfesionalesApellidoSegundo = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV25TFProfesionalesApellidoSegundo", AV25TFProfesionalesApellidoSegundo);
               AV26TFProfesionalesApellidoSegundo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV26TFProfesionalesApellidoSegundo_Sel", AV26TFProfesionalesApellidoSegundo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesTelefono") == 0 )
            {
               AV27TFProfesionalesTelefono = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV27TFProfesionalesTelefono", AV27TFProfesionalesTelefono);
               AV28TFProfesionalesTelefono_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV28TFProfesionalesTelefono_Sel", AV28TFProfesionalesTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstadosGenericosNombre") == 0 )
            {
               AV29TFEstadosGenericosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV29TFEstadosGenericosNombre", AV29TFEstadosGenericosNombre);
               AV30TFEstadosGenericosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV30TFEstadosGenericosNombre_Sel", AV30TFEstadosGenericosNombre_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E164D2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( AV38IsAuthorized_EstadosGenericosNombre )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "estadosnotificacionview.aspx"+UrlEncode(StringUtil.RTrim(A107EstadosTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A108EstadosGenericosId,5,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtEstadosGenericosNombre_Link = formatLink("estadosnotificacionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            context.DoAjaxLoad(15, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV39Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV39Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV16Session.Get(AV39Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV12GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV40GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV17TFProfesionalesId = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV17TFProfesionalesId", AV17TFProfesionalesId);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV18TFProfesionalesId_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV18TFProfesionalesId_Sel", AV18TFProfesionalesId_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV19TFProfesionalesPrimerNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV19TFProfesionalesPrimerNombre", AV19TFProfesionalesPrimerNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV20TFProfesionalesPrimerNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV20TFProfesionalesPrimerNombre_Sel", AV20TFProfesionalesPrimerNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               AV21TFProfesionalesSegundoNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV21TFProfesionalesSegundoNombre", AV21TFProfesionalesSegundoNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE_SEL") == 0 )
            {
               AV22TFProfesionalesSegundoNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV22TFProfesionalesSegundoNombre_Sel", AV22TFProfesionalesSegundoNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV23TFProfesionalesApellidoPrimero = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV23TFProfesionalesApellidoPrimero", AV23TFProfesionalesApellidoPrimero);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV24TFProfesionalesApellidoPrimero_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV24TFProfesionalesApellidoPrimero_Sel", AV24TFProfesionalesApellidoPrimero_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               AV25TFProfesionalesApellidoSegundo = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV25TFProfesionalesApellidoSegundo", AV25TFProfesionalesApellidoSegundo);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO_SEL") == 0 )
            {
               AV26TFProfesionalesApellidoSegundo_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV26TFProfesionalesApellidoSegundo_Sel", AV26TFProfesionalesApellidoSegundo_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO") == 0 )
            {
               AV27TFProfesionalesTelefono = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV27TFProfesionalesTelefono", AV27TFProfesionalesTelefono);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO_SEL") == 0 )
            {
               AV28TFProfesionalesTelefono_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV28TFProfesionalesTelefono_Sel", AV28TFProfesionalesTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE") == 0 )
            {
               AV29TFEstadosGenericosNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV29TFEstadosGenericosNombre", AV29TFEstadosGenericosNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE_SEL") == 0 )
            {
               AV30TFEstadosGenericosNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV30TFEstadosGenericosNombre_Sel", AV30TFEstadosGenericosNombre_Sel);
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesId_Sel)),  AV18TFProfesionalesId_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesPrimerNombre_Sel)),  AV20TFProfesionalesPrimerNombre_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesSegundoNombre_Sel)),  AV22TFProfesionalesSegundoNombre_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesApellidoPrimero_Sel)),  AV24TFProfesionalesApellidoPrimero_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesApellidoSegundo_Sel)),  AV26TFProfesionalesApellidoSegundo_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProfesionalesTelefono_Sel)),  AV28TFProfesionalesTelefono_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFEstadosGenericosNombre_Sel)),  AV30TFEstadosGenericosNombre_Sel, out  GXt_char9) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesId)),  AV17TFProfesionalesId, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesPrimerNombre)),  AV19TFProfesionalesPrimerNombre, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesSegundoNombre)),  AV21TFProfesionalesSegundoNombre, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesApellidoPrimero)),  AV23TFProfesionalesApellidoPrimero, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesApellidoSegundo)),  AV25TFProfesionalesApellidoSegundo, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFProfesionalesTelefono)),  AV27TFProfesionalesTelefono, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFEstadosGenericosNombre)),  AV29TFEstadosGenericosNombre, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV12GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV16Session.Get(AV39Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFPROFESIONALESID",  context.GetMessage( "Identidad", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesId)),  0,  AV17TFProfesionalesId,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesId_Sel)),  AV18TFProfesionalesId_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFPROFESIONALESPRIMERNOMBRE",  context.GetMessage( "Primer Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesPrimerNombre)),  0,  AV19TFProfesionalesPrimerNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesPrimerNombre_Sel)),  AV20TFProfesionalesPrimerNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFPROFESIONALESSEGUNDONOMBRE",  context.GetMessage( "Segundo Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesSegundoNombre)),  0,  AV21TFProfesionalesSegundoNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesSegundoNombre_Sel)),  AV22TFProfesionalesSegundoNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFPROFESIONALESAPELLIDOPRIMERO",  context.GetMessage( "Primero Apellido ", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesApellidoPrimero)),  0,  AV23TFProfesionalesApellidoPrimero,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesApellidoPrimero_Sel)),  AV24TFProfesionalesApellidoPrimero_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFPROFESIONALESAPELLIDOSEGUNDO",  context.GetMessage( "Segundo Apellido ", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesApellidoSegundo)),  0,  AV25TFProfesionalesApellidoSegundo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesApellidoSegundo_Sel)),  AV26TFProfesionalesApellidoSegundo_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFPROFESIONALESTELEFONO",  context.GetMessage( "Teléfono", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFProfesionalesTelefono)),  0,  AV27TFProfesionalesTelefono,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProfesionalesTelefono_Sel)),  AV28TFProfesionalesTelefono_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFESTADOSGENERICOSNOMBRE",  context.GetMessage( "Estado", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFEstadosGenericosNombre)),  0,  AV29TFEstadosGenericosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFEstadosGenericosNombre_Sel)),  AV30TFEstadosGenericosNombre_Sel,  "") ;
         if ( ! (0==AV8ComisionesID) )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = "PARM_&COMISIONESID";
            AV13GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV8ComisionesID), 18, 0);
            AV12GridState.gxTpr_Filtervalues.Add(AV13GridStateFilterValue, 0);
         }
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV39Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV39Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "Comisiones";
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "ComisionesID";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8ComisionesID), 18, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV16Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8ComisionesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV8ComisionesID", StringUtil.LTrimStr( (decimal)(AV8ComisionesID), 18, 0));
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
         PA4D2( ) ;
         WS4D2( ) ;
         WE4D2( ) ;
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
         sCtrlAV8ComisionesID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4D2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "comisionesprofesionaleswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4D2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8ComisionesID = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV8ComisionesID", StringUtil.LTrimStr( (decimal)(AV8ComisionesID), 18, 0));
         }
         wcpOAV8ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8ComisionesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV8ComisionesID != wcpOAV8ComisionesID ) ) )
         {
            setjustcreated();
         }
         wcpOAV8ComisionesID = AV8ComisionesID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8ComisionesID = cgiGet( sPrefix+"AV8ComisionesID_CTRL");
         if ( StringUtil.Len( sCtrlAV8ComisionesID) > 0 )
         {
            AV8ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8ComisionesID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8ComisionesID", StringUtil.LTrimStr( (decimal)(AV8ComisionesID), 18, 0));
         }
         else
         {
            AV8ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8ComisionesID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA4D2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4D2( ) ;
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
         WS4D2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8ComisionesID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8ComisionesID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8ComisionesID_CTRL", StringUtil.RTrim( sCtrlAV8ComisionesID));
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
         WE4D2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302121092", true, true, false);
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
         context.AddJavascriptSource("comisionesprofesionaleswc.js", "?20267302121093", false, true, false);
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

      protected void SubsflControlProps_152( )
      {
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID_"+sGXsfl_15_idx;
         edtProfesionalesPrimerNombre_Internalname = sPrefix+"PROFESIONALESPRIMERNOMBRE_"+sGXsfl_15_idx;
         edtProfesionalesSegundoNombre_Internalname = sPrefix+"PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_15_idx;
         edtProfesionalesApellidoPrimero_Internalname = sPrefix+"PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_15_idx;
         edtProfesionalesApellidoSegundo_Internalname = sPrefix+"PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_15_idx;
         edtProfesionalesTelefono_Internalname = sPrefix+"PROFESIONALESTELEFONO_"+sGXsfl_15_idx;
         edtEstadosTipo_Internalname = sPrefix+"ESTADOSTIPO_"+sGXsfl_15_idx;
         edtEstadosGenericosId_Internalname = sPrefix+"ESTADOSGENERICOSID_"+sGXsfl_15_idx;
         edtEstadosGenericosNombre_Internalname = sPrefix+"ESTADOSGENERICOSNOMBRE_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID_"+sGXsfl_15_fel_idx;
         edtProfesionalesPrimerNombre_Internalname = sPrefix+"PROFESIONALESPRIMERNOMBRE_"+sGXsfl_15_fel_idx;
         edtProfesionalesSegundoNombre_Internalname = sPrefix+"PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_15_fel_idx;
         edtProfesionalesApellidoPrimero_Internalname = sPrefix+"PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_15_fel_idx;
         edtProfesionalesApellidoSegundo_Internalname = sPrefix+"PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_15_fel_idx;
         edtProfesionalesTelefono_Internalname = sPrefix+"PROFESIONALESTELEFONO_"+sGXsfl_15_fel_idx;
         edtEstadosTipo_Internalname = sPrefix+"ESTADOSTIPO_"+sGXsfl_15_fel_idx;
         edtEstadosGenericosId_Internalname = sPrefix+"ESTADOSGENERICOSID_"+sGXsfl_15_fel_idx;
         edtEstadosGenericosNombre_Internalname = sPrefix+"ESTADOSGENERICOSNOMBRE_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         WB4D0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_15_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_15_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_15_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPrimerNombre_Internalname,StringUtil.RTrim( A166ProfesionalesPrimerNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesPrimerNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesSegundoNombre_Internalname,StringUtil.RTrim( A191ProfesionalesSegundoNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesSegundoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoPrimero_Internalname,StringUtil.RTrim( A167ProfesionalesApellidoPrimero),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoPrimero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoSegundo_Internalname,StringUtil.RTrim( A192ProfesionalesApellidoSegundo),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoSegundo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A170ProfesionalesTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesTelefono_Internalname,StringUtil.RTrim( A170ProfesionalesTelefono),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtProfesionalesTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosTipo_Internalname,StringUtil.RTrim( A107EstadosTipo),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosGenericosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosNombre_Internalname,StringUtil.RTrim( A109EstadosGenericosNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtEstadosGenericosNombre_Link,(string)"",(string)"",(string)"",(string)edtEstadosGenericosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes4D2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_15_idx = ((subGrid_Islastpage==1)&&(nGXsfl_15_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         /* End function sendrow_152 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl15( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"15\">") ;
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
            context.SendWebValue( context.GetMessage( "Identidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Primer Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Segundo Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Primero Apellido ", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A166ProfesionalesPrimerNombre)));
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
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID";
         edtProfesionalesPrimerNombre_Internalname = sPrefix+"PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = sPrefix+"PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = sPrefix+"PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesApellidoSegundo_Internalname = sPrefix+"PROFESIONALESAPELLIDOSEGUNDO";
         edtProfesionalesTelefono_Internalname = sPrefix+"PROFESIONALESTELEFONO";
         edtEstadosTipo_Internalname = sPrefix+"ESTADOSTIPO";
         edtEstadosGenericosId_Internalname = sPrefix+"ESTADOSGENERICOSID";
         edtEstadosGenericosNombre_Internalname = sPrefix+"ESTADOSGENERICOSNOMBRE";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtComisionesID_Internalname = sPrefix+"COMISIONESID";
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
         edtEstadosGenericosNombre_Jsonclick = "";
         edtEstadosGenericosNombre_Link = "";
         edtEstadosGenericosId_Jsonclick = "";
         edtEstadosTipo_Jsonclick = "";
         edtProfesionalesTelefono_Jsonclick = "";
         edtProfesionalesApellidoSegundo_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtComisionesID_Enabled = 0;
         edtEstadosGenericosNombre_Enabled = 0;
         edtEstadosGenericosId_Enabled = 0;
         edtEstadosTipo_Enabled = 0;
         edtProfesionalesTelefono_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         subGrid_Sortable = 0;
         edtComisionesID_Jsonclick = "";
         edtComisionesID_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "ComisionesProfesionalesWCGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7";
         Ddo_grid_Columnids = "0:ProfesionalesId|1:ProfesionalesPrimerNombre|2:ProfesionalesSegundoNombre|3:ProfesionalesApellidoPrimero|4:ProfesionalesApellidoSegundo|5:ProfesionalesTelefono|8:EstadosGenericosNombre";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'sPrefix',type:'char'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8ComisionesID',fld:'vCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV18TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV19TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV20TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV21TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV22TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV24TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV25TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV26TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV27TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV28TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV29TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV30TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV38IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV34GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV35GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV36GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E114D2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8ComisionesID',fld:'vCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV18TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV19TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV20TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV21TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV22TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV24TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV25TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV26TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV27TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV28TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV29TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV30TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV38IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV34GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV35GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV36GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E124D2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8ComisionesID',fld:'vCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV18TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV19TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV20TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV21TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV22TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV24TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV25TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV26TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV27TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV28TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV29TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV30TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV38IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E134D2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8ComisionesID',fld:'vCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV18TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV19TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV20TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV21TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV22TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV24TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV25TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV26TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV27TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV28TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV29TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV30TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV38IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV29TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV30TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV27TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV28TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV25TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV26TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV23TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV24TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV21TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV22TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV19TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV20TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV17TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV18TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E164D2',iparms:[{av:'AV38IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtEstadosGenericosNombre_Link',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Link'}]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSTIPO","{handler:'Valid_Estadostipo',iparms:[]");
         setEventMetadata("VALID_ESTADOSTIPO",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSGENERICOSID","{handler:'Valid_Estadosgenericosid',iparms:[]");
         setEventMetadata("VALID_ESTADOSGENERICOSID",",oparms:[]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV39Pgmname = "";
         AV17TFProfesionalesId = "";
         AV18TFProfesionalesId_Sel = "";
         AV19TFProfesionalesPrimerNombre = "";
         AV20TFProfesionalesPrimerNombre_Sel = "";
         AV21TFProfesionalesSegundoNombre = "";
         AV22TFProfesionalesSegundoNombre_Sel = "";
         AV23TFProfesionalesApellidoPrimero = "";
         AV24TFProfesionalesApellidoPrimero_Sel = "";
         AV25TFProfesionalesApellidoSegundo = "";
         AV26TFProfesionalesApellidoSegundo_Sel = "";
         AV27TFProfesionalesTelefono = "";
         AV28TFProfesionalesTelefono_Sel = "";
         AV29TFEstadosGenericosNombre = "";
         AV30TFEstadosGenericosNombre_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV36GridAppliedFilters = "";
         AV31DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
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
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         A107EstadosTipo = "";
         A109EstadosGenericosNombre = "";
         GXDecQS = "";
         lV17TFProfesionalesId = "";
         lV19TFProfesionalesPrimerNombre = "";
         lV21TFProfesionalesSegundoNombre = "";
         lV23TFProfesionalesApellidoPrimero = "";
         lV25TFProfesionalesApellidoSegundo = "";
         lV27TFProfesionalesTelefono = "";
         lV29TFEstadosGenericosNombre = "";
         H004D2_A503ComisionesID = new long[1] ;
         H004D2_A109EstadosGenericosNombre = new string[] {""} ;
         H004D2_A108EstadosGenericosId = new int[1] ;
         H004D2_A107EstadosTipo = new string[] {""} ;
         H004D2_A170ProfesionalesTelefono = new string[] {""} ;
         H004D2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         H004D2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H004D2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         H004D2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H004D2_A120ProfesionalesId = new string[] {""} ;
         H004D3_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV16Session = context.GetSession();
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char3 = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8ComisionesID = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisionesprofesionaleswc__default(),
            new Object[][] {
                new Object[] {
               H004D2_A503ComisionesID, H004D2_A109EstadosGenericosNombre, H004D2_A108EstadosGenericosId, H004D2_A107EstadosTipo, H004D2_A170ProfesionalesTelefono, H004D2_A192ProfesionalesApellidoSegundo, H004D2_A167ProfesionalesApellidoPrimero, H004D2_A191ProfesionalesSegundoNombre, H004D2_A166ProfesionalesPrimerNombre, H004D2_A120ProfesionalesId
               }
               , new Object[] {
               H004D3_AGRID_nRecordCount
               }
            }
         );
         AV39Pgmname = "ComisionesProfesionalesWC";
         /* GeneXus formulas. */
         AV39Pgmname = "ComisionesProfesionalesWC";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14OrderedBy ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
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
      private int nRC_GXsfl_15 ;
      private int nGXsfl_15_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtComisionesID_Visible ;
      private int A108EstadosGenericosId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesApellidoSegundo_Enabled ;
      private int edtProfesionalesTelefono_Enabled ;
      private int edtEstadosTipo_Enabled ;
      private int edtEstadosGenericosId_Enabled ;
      private int edtEstadosGenericosNombre_Enabled ;
      private int edtComisionesID_Enabled ;
      private int AV33PageToGo ;
      private int AV40GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8ComisionesID ;
      private long wcpOAV8ComisionesID ;
      private long GRID_nFirstRecordOnPage ;
      private long AV34GridCurrentPage ;
      private long AV35GridPageCount ;
      private long A503ComisionesID ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_15_idx="0001" ;
      private string AV39Pgmname ;
      private string AV17TFProfesionalesId ;
      private string AV18TFProfesionalesId_Sel ;
      private string AV19TFProfesionalesPrimerNombre ;
      private string AV20TFProfesionalesPrimerNombre_Sel ;
      private string AV21TFProfesionalesSegundoNombre ;
      private string AV22TFProfesionalesSegundoNombre_Sel ;
      private string AV23TFProfesionalesApellidoPrimero ;
      private string AV24TFProfesionalesApellidoPrimero_Sel ;
      private string AV25TFProfesionalesApellidoSegundo ;
      private string AV26TFProfesionalesApellidoSegundo_Sel ;
      private string AV27TFProfesionalesTelefono ;
      private string AV28TFProfesionalesTelefono_Sel ;
      private string AV29TFEstadosGenericosNombre ;
      private string AV30TFEstadosGenericosNombre_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Ddo_grid_Datalistproc ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablegridheader_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string edtComisionesID_Internalname ;
      private string edtComisionesID_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
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
      private string A107EstadosTipo ;
      private string edtEstadosTipo_Internalname ;
      private string edtEstadosGenericosId_Internalname ;
      private string A109EstadosGenericosNombre ;
      private string edtEstadosGenericosNombre_Internalname ;
      private string GXDecQS ;
      private string lV17TFProfesionalesId ;
      private string lV19TFProfesionalesPrimerNombre ;
      private string lV21TFProfesionalesSegundoNombre ;
      private string lV23TFProfesionalesApellidoPrimero ;
      private string lV25TFProfesionalesApellidoSegundo ;
      private string lV27TFProfesionalesTelefono ;
      private string lV29TFEstadosGenericosNombre ;
      private string edtEstadosGenericosNombre_Link ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string sCtrlAV8ComisionesID ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtProfesionalesId_Jsonclick ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesSegundoNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtProfesionalesApellidoSegundo_Jsonclick ;
      private string gxphoneLink ;
      private string edtProfesionalesTelefono_Jsonclick ;
      private string edtEstadosTipo_Jsonclick ;
      private string edtEstadosGenericosId_Jsonclick ;
      private string edtEstadosGenericosNombre_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV38IsAuthorized_EstadosGenericosNombre ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_15_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private bool gx_refresh_fired ;
      private string AV36GridAppliedFilters ;
      private IGxSession AV16Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private GxHttpRequest AV9HTTPRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV31DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private long[] H004D2_A503ComisionesID ;
      private string[] H004D2_A109EstadosGenericosNombre ;
      private int[] H004D2_A108EstadosGenericosId ;
      private string[] H004D2_A107EstadosTipo ;
      private string[] H004D2_A170ProfesionalesTelefono ;
      private string[] H004D2_A192ProfesionalesApellidoSegundo ;
      private string[] H004D2_A167ProfesionalesApellidoPrimero ;
      private string[] H004D2_A191ProfesionalesSegundoNombre ;
      private string[] H004D2_A166ProfesionalesPrimerNombre ;
      private string[] H004D2_A120ProfesionalesId ;
      private long[] H004D3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class comisionesprofesionaleswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004D2( IGxContext context ,
                                             string AV18TFProfesionalesId_Sel ,
                                             string AV17TFProfesionalesId ,
                                             string AV20TFProfesionalesPrimerNombre_Sel ,
                                             string AV19TFProfesionalesPrimerNombre ,
                                             string AV22TFProfesionalesSegundoNombre_Sel ,
                                             string AV21TFProfesionalesSegundoNombre ,
                                             string AV24TFProfesionalesApellidoPrimero_Sel ,
                                             string AV23TFProfesionalesApellidoPrimero ,
                                             string AV26TFProfesionalesApellidoSegundo_Sel ,
                                             string AV25TFProfesionalesApellidoSegundo ,
                                             string AV28TFProfesionalesTelefono_Sel ,
                                             string AV27TFProfesionalesTelefono ,
                                             string AV30TFEstadosGenericosNombre_Sel ,
                                             string AV29TFEstadosGenericosNombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             long AV8ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[18];
         Object[] GXv_Object11 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[ComisionesID], T3.[EstadosGenericosNombre], T2.[EstadosGenericosId], T2.[EstadosTipo], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId]";
         sFromString = " FROM (([ComisionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[ComisionesID] = @AV8ComisionesID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV17TFProfesionalesId))");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV18TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV19TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV20TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV21TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV22TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV23TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV24TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV25TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV26TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV26TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV27TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV28TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV28TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30TFEstadosGenericosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFEstadosGenericosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV29TFEstadosGenericosNombre))");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TFEstadosGenericosNombre_Sel)) && ! ( StringUtil.StrCmp(AV30TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV30TFEstadosGenericosNombre_Sel)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( StringUtil.StrCmp(AV30TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ComisionesID], T1.[ProfesionalesId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ComisionesID] DESC, T1.[ProfesionalesId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ComisionesID], T2.[ProfesionalesPrimerNombre]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ComisionesID] DESC, T2.[ProfesionalesPrimerNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ComisionesID], T2.[ProfesionalesSegundoNombre]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ComisionesID] DESC, T2.[ProfesionalesSegundoNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ComisionesID], T2.[ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ComisionesID] DESC, T2.[ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ComisionesID], T2.[ProfesionalesApellidoSegundo]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ComisionesID] DESC, T2.[ProfesionalesApellidoSegundo] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ComisionesID], T2.[ProfesionalesTelefono]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ComisionesID] DESC, T2.[ProfesionalesTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ComisionesID], T3.[EstadosGenericosNombre]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ComisionesID] DESC, T3.[EstadosGenericosNombre] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[ComisionesID], T1.[ProfesionalesId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_H004D3( IGxContext context ,
                                             string AV18TFProfesionalesId_Sel ,
                                             string AV17TFProfesionalesId ,
                                             string AV20TFProfesionalesPrimerNombre_Sel ,
                                             string AV19TFProfesionalesPrimerNombre ,
                                             string AV22TFProfesionalesSegundoNombre_Sel ,
                                             string AV21TFProfesionalesSegundoNombre ,
                                             string AV24TFProfesionalesApellidoPrimero_Sel ,
                                             string AV23TFProfesionalesApellidoPrimero ,
                                             string AV26TFProfesionalesApellidoSegundo_Sel ,
                                             string AV25TFProfesionalesApellidoSegundo ,
                                             string AV28TFProfesionalesTelefono_Sel ,
                                             string AV27TFProfesionalesTelefono ,
                                             string AV30TFEstadosGenericosNombre_Sel ,
                                             string AV29TFEstadosGenericosNombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             long AV8ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[15];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (([ComisionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[ComisionesID] = @AV8ComisionesID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV17TFProfesionalesId))");
         }
         else
         {
            GXv_int12[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV18TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int12[2] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV19TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int12[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV20TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int12[4] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV21TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int12[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV22TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int12[6] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV23TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV24TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV25TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV26TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV26TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV27TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV28TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV28TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30TFEstadosGenericosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFEstadosGenericosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV29TFEstadosGenericosNombre))");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TFEstadosGenericosNombre_Sel)) && ! ( StringUtil.StrCmp(AV30TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV30TFEstadosGenericosNombre_Sel)");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( StringUtil.StrCmp(AV30TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
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
                     return conditional_H004D2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] );
               case 1 :
                     return conditional_H004D3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] );
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
          Object[] prmH004D2;
          prmH004D2 = new Object[] {
          new ParDef("@AV8ComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@lV17TFProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV18TFProfesionalesId_Sel",GXType.Char,20,0) ,
          new ParDef("@lV19TFProfesionalesPrimerNombre",GXType.Char,30,0) ,
          new ParDef("@AV20TFProfesionalesPrimerNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV21TFProfesionalesSegundoNombre",GXType.Char,30,0) ,
          new ParDef("@AV22TFProfesionalesSegundoNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV23TFProfesionalesApellidoPrimero",GXType.Char,30,0) ,
          new ParDef("@AV24TFProfesionalesApellidoPrimero_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV25TFProfesionalesApellidoSegundo",GXType.Char,30,0) ,
          new ParDef("@AV26TFProfesionalesApellidoSegundo_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV27TFProfesionalesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV28TFProfesionalesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV29TFEstadosGenericosNombre",GXType.Char,80,0) ,
          new ParDef("@AV30TFEstadosGenericosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004D3;
          prmH004D3 = new Object[] {
          new ParDef("@AV8ComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@lV17TFProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV18TFProfesionalesId_Sel",GXType.Char,20,0) ,
          new ParDef("@lV19TFProfesionalesPrimerNombre",GXType.Char,30,0) ,
          new ParDef("@AV20TFProfesionalesPrimerNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV21TFProfesionalesSegundoNombre",GXType.Char,30,0) ,
          new ParDef("@AV22TFProfesionalesSegundoNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV23TFProfesionalesApellidoPrimero",GXType.Char,30,0) ,
          new ParDef("@AV24TFProfesionalesApellidoPrimero_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV25TFProfesionalesApellidoSegundo",GXType.Char,30,0) ,
          new ParDef("@AV26TFProfesionalesApellidoSegundo_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV27TFProfesionalesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV28TFProfesionalesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV29TFEstadosGenericosNombre",GXType.Char,80,0) ,
          new ParDef("@AV30TFEstadosGenericosNombre_Sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004D2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004D3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 30);
                ((string[]) buf[6])[0] = rslt.getString(7, 30);
                ((string[]) buf[7])[0] = rslt.getString(8, 30);
                ((string[]) buf[8])[0] = rslt.getString(9, 30);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
