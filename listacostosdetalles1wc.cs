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
   public class listacostosdetalles1wc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public listacostosdetalles1wc( )
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

      public listacostosdetalles1wc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ListaCostosId )
      {
         this.AV8ListaCostosId = aP0_ListaCostosId;
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
         cmbCentroCostosTipoRef = new GXCombobox();
         cmbCentroCostosEstado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ListaCostosId");
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
                  AV8ListaCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "ListaCostosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8ListaCostosId", StringUtil.LTrimStr( (decimal)(AV8ListaCostosId), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV8ListaCostosId});
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
                  gxfirstwebparm = GetFirstPar( "ListaCostosId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ListaCostosId");
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
         AV8ListaCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "ListaCostosId"), "."), 18, MidpointRounding.ToEven));
         AV20ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV66Pgmname = GetPar( "Pgmname");
         AV21TFCentroCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCentroCostosId"), "."), 18, MidpointRounding.ToEven));
         AV22TFCentroCostosId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCentroCostosId_To"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV24TFCentroCostosTipoRef_Sels);
         AV25TFCentroCostosRef = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCentroCostosRef"), "."), 18, MidpointRounding.ToEven));
         AV26TFCentroCostosRef_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCentroCostosRef_To"), "."), 18, MidpointRounding.ToEven));
         AV27TFCentroCostosNombre = GetPar( "TFCentroCostosNombre");
         AV28TFCentroCostosNombre_Sel = GetPar( "TFCentroCostosNombre_Sel");
         AV29TFCentroCostosPrecioFinal = NumberUtil.Val( GetPar( "TFCentroCostosPrecioFinal"), ".");
         AV30TFCentroCostosPrecioFinal_To = NumberUtil.Val( GetPar( "TFCentroCostosPrecioFinal_To"), ".");
         AV31TFCentroCostosSubTotal = NumberUtil.Val( GetPar( "TFCentroCostosSubTotal"), ".");
         AV32TFCentroCostosSubTotal_To = NumberUtil.Val( GetPar( "TFCentroCostosSubTotal_To"), ".");
         AV33TFCentroCostosCosto = NumberUtil.Val( GetPar( "TFCentroCostosCosto"), ".");
         AV34TFCentroCostosCosto_To = NumberUtil.Val( GetPar( "TFCentroCostosCosto_To"), ".");
         AV35TFCentroCostosGam = NumberUtil.Val( GetPar( "TFCentroCostosGam"), ".");
         AV36TFCentroCostosGam_To = NumberUtil.Val( GetPar( "TFCentroCostosGam_To"), ".");
         AV37TFCentroCostosUsrAlta = GetPar( "TFCentroCostosUsrAlta");
         AV38TFCentroCostosUsrAlta_Sel = GetPar( "TFCentroCostosUsrAlta_Sel");
         AV39TFCentroCostosUsrMod = GetPar( "TFCentroCostosUsrMod");
         AV40TFCentroCostosUsrMod_Sel = GetPar( "TFCentroCostosUsrMod_Sel");
         AV41TFCentroCostosHoraAlt = context.localUtil.ParseDateParm( GetPar( "TFCentroCostosHoraAlt"));
         AV42TFCentroCostosHoraAlt_To = context.localUtil.ParseDateParm( GetPar( "TFCentroCostosHoraAlt_To"));
         AV46TFCentroCostosHoraMod = context.localUtil.ParseDateParm( GetPar( "TFCentroCostosHoraMod"));
         AV47TFCentroCostosHoraMod_To = context.localUtil.ParseDateParm( GetPar( "TFCentroCostosHoraMod_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV52TFCentroCostosEstado_Sels);
         AV61IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV62IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV63IsAuthorized_CentroCostosNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_CentroCostosNombre"));
         AV65CentroCostosRef = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosRef"), "."), 18, MidpointRounding.ToEven));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8ListaCostosId, AV20ManageFiltersExecutionStep, AV66Pgmname, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV24TFCentroCostosTipoRef_Sels, AV25TFCentroCostosRef, AV26TFCentroCostosRef_To, AV27TFCentroCostosNombre, AV28TFCentroCostosNombre_Sel, AV29TFCentroCostosPrecioFinal, AV30TFCentroCostosPrecioFinal_To, AV31TFCentroCostosSubTotal, AV32TFCentroCostosSubTotal_To, AV33TFCentroCostosCosto, AV34TFCentroCostosCosto_To, AV35TFCentroCostosGam, AV36TFCentroCostosGam_To, AV37TFCentroCostosUsrAlta, AV38TFCentroCostosUsrAlta_Sel, AV39TFCentroCostosUsrMod, AV40TFCentroCostosUsrMod_Sel, AV41TFCentroCostosHoraAlt, AV42TFCentroCostosHoraAlt_To, AV46TFCentroCostosHoraMod, AV47TFCentroCostosHoraMod_To, AV52TFCentroCostosEstado_Sels, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV63IsAuthorized_CentroCostosNombre, AV65CentroCostosRef, sPrefix) ;
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
            PA3Z2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV66Pgmname = "ListaCostosDetalles1WC";
               WS3Z2( ) ;
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
            context.SendWebValue( context.GetMessage( "Lista Costos Detalles1 WC", "")) ;
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
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
            GXEncryptionTmp = "listacostosdetalles1wc.aspx"+UrlEncode(StringUtil.LTrimStr(AV8ListaCostosId,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("listacostosdetalles1wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV66Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV66Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV61IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV61IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV62IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV62IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_CENTROCOSTOSNOMBRE", AV63IsAuthorized_CentroCostosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_CENTROCOSTOSNOMBRE", GetSecureSignedToken( sPrefix, AV63IsAuthorized_CentroCostosNombre, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCENTROCOSTOSREF", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCENTROCOSTOSREF", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV65CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV58GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV53DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV53DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_CENTROCOSTOSHORAALTAUXDATETO", context.localUtil.DToC( AV44DDO_CentroCostosHoraAltAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_CENTROCOSTOSHORAMODAUXDATETO", context.localUtil.DToC( AV49DDO_CentroCostosHoraModAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8ListaCostosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV66Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV66Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21TFCentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22TFCentroCostosId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFCENTROCOSTOSTIPOREF_SELS", AV24TFCentroCostosTipoRef_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFCENTROCOSTOSTIPOREF_SELS", AV24TFCentroCostosTipoRef_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSREF", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25TFCentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSREF_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26TFCentroCostosRef_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSNOMBRE", StringUtil.RTrim( AV27TFCentroCostosNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSNOMBRE_SEL", StringUtil.RTrim( AV28TFCentroCostosNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSPRECIOFINAL", StringUtil.LTrim( StringUtil.NToC( AV29TFCentroCostosPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSPRECIOFINAL_TO", StringUtil.LTrim( StringUtil.NToC( AV30TFCentroCostosPrecioFinal_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSSUBTOTAL", StringUtil.LTrim( StringUtil.NToC( AV31TFCentroCostosSubTotal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSSUBTOTAL_TO", StringUtil.LTrim( StringUtil.NToC( AV32TFCentroCostosSubTotal_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSCOSTO", StringUtil.LTrim( StringUtil.NToC( AV33TFCentroCostosCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSCOSTO_TO", StringUtil.LTrim( StringUtil.NToC( AV34TFCentroCostosCosto_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSGAM", StringUtil.LTrim( StringUtil.NToC( AV35TFCentroCostosGam, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSGAM_TO", StringUtil.LTrim( StringUtil.NToC( AV36TFCentroCostosGam_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSUSRALTA", StringUtil.RTrim( AV37TFCentroCostosUsrAlta));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSUSRALTA_SEL", StringUtil.RTrim( AV38TFCentroCostosUsrAlta_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSUSRMOD", StringUtil.RTrim( AV39TFCentroCostosUsrMod));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSUSRMOD_SEL", StringUtil.RTrim( AV40TFCentroCostosUsrMod_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSHORAALT", context.localUtil.DToC( AV41TFCentroCostosHoraAlt, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSHORAALT_TO", context.localUtil.DToC( AV42TFCentroCostosHoraAlt_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSHORAMOD", context.localUtil.DToC( AV46TFCentroCostosHoraMod, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSHORAMOD_TO", context.localUtil.DToC( AV47TFCentroCostosHoraMod_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFCENTROCOSTOSESTADO_SELS", AV52TFCentroCostosEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFCENTROCOSTOSESTADO_SELS", AV52TFCentroCostosEstado_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vLISTACOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV61IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV61IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV62IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV62IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_CENTROCOSTOSNOMBRE", AV63IsAuthorized_CentroCostosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_CENTROCOSTOSNOMBRE", GetSecureSignedToken( sPrefix, AV63IsAuthorized_CentroCostosNombre, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV12GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV12GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSTIPOREF_SELSJSON", AV23TFCentroCostosTipoRef_SelsJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSESTADO_SELSJSON", AV51TFCentroCostosEstado_SelsJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"vCENTROCOSTOSREF", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCENTROCOSTOSREF", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV65CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_CENTROCOSTOSHORAALTAUXDATE", context.localUtil.DToC( AV43DDO_CentroCostosHoraAltAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_CENTROCOSTOSHORAMODAUXDATE", context.localUtil.DToC( AV48DDO_CentroCostosHoraModAuxDate, 0, "/"));
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

      protected void RenderHtmlCloseForm3Z2( )
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
         return "ListaCostosDetalles1WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Lista Costos Detalles1 WC", "") ;
      }

      protected void WB3Z0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "listacostosdetalles1wc.aspx");
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
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ListaCostosDetalles1WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_22_3Z2( true) ;
         }
         else
         {
            wb_table1_22_3Z2( false) ;
         }
         return  ;
      }

      protected void wb_table1_22_3Z2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV56GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV57GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV58GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV53DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtListaCostosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A459ListaCostosId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaCostosId_Jsonclick, 0, "Attribute", "", "", "", "", edtListaCostosId_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ListaCostosDetalles1WC.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_centrocostoshoraaltauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_centrocostoshoraaltauxdatetext_Internalname, AV45DDO_CentroCostosHoraAltAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV45DDO_CentroCostosHoraAltAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_centrocostoshoraaltauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ListaCostosDetalles1WC.htm");
            /* User Defined Control */
            ucTfcentrocostoshoraalt_rangepicker.SetProperty("Start Date", AV43DDO_CentroCostosHoraAltAuxDate);
            ucTfcentrocostoshoraalt_rangepicker.SetProperty("End Date", AV44DDO_CentroCostosHoraAltAuxDateTo);
            ucTfcentrocostoshoraalt_rangepicker.Render(context, "wwp.daterangepicker", Tfcentrocostoshoraalt_rangepicker_Internalname, sPrefix+"TFCENTROCOSTOSHORAALT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_centrocostoshoramodauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_centrocostoshoramodauxdatetext_Internalname, AV50DDO_CentroCostosHoraModAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV50DDO_CentroCostosHoraModAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_centrocostoshoramodauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ListaCostosDetalles1WC.htm");
            /* User Defined Control */
            ucTfcentrocostoshoramod_rangepicker.SetProperty("Start Date", AV48DDO_CentroCostosHoraModAuxDate);
            ucTfcentrocostoshoramod_rangepicker.SetProperty("End Date", AV49DDO_CentroCostosHoraModAuxDateTo);
            ucTfcentrocostoshoramod_rangepicker.Render(context, "wwp.daterangepicker", Tfcentrocostoshoramod_rangepicker_Internalname, sPrefix+"TFCENTROCOSTOSHORAMOD_RANGEPICKERContainer");
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

      protected void START3Z2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Lista Costos Detalles1 WC", ""), 0) ;
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
               STRUP3Z0( ) ;
            }
         }
      }

      protected void WS3Z2( )
      {
         START3Z2( ) ;
         EVT3Z2( ) ;
      }

      protected void EVT3Z2( )
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
                                 STRUP3Z0( ) ;
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
                                 STRUP3Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E113Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E123Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E133Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E143Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E153Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV59GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri(sPrefix, false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV59GridActions), 4, 0));
                              A461CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbCentroCostosTipoRef.Name = cmbCentroCostosTipoRef_Internalname;
                              cmbCentroCostosTipoRef.CurrentValue = cgiGet( cmbCentroCostosTipoRef_Internalname);
                              A487CentroCostosTipoRef = cgiGet( cmbCentroCostosTipoRef_Internalname);
                              A462CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosRef_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A463CentroCostosNombre = cgiGet( edtCentroCostosNombre_Internalname);
                              A464CentroCostosPrecioFinal = context.localUtil.CToN( cgiGet( edtCentroCostosPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A465CentroCostosSerial = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosSerial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A469CentroCostosSubTotal = context.localUtil.CToN( cgiGet( edtCentroCostosSubTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n469CentroCostosSubTotal = false;
                              A475CentroCostosCosto = context.localUtil.CToN( cgiGet( edtCentroCostosCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A474CentroCostosGam = context.localUtil.CToN( cgiGet( edtCentroCostosGam_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A478CentroCostosUsrAlta = cgiGet( edtCentroCostosUsrAlta_Internalname);
                              A479CentroCostosUsrMod = cgiGet( edtCentroCostosUsrMod_Internalname);
                              A480CentroCostosHoraAlt = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCentroCostosHoraAlt_Internalname), 0));
                              A481CentroCostosHoraMod = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCentroCostosHoraMod_Internalname), 0));
                              cmbCentroCostosEstado.Name = cmbCentroCostosEstado_Internalname;
                              cmbCentroCostosEstado.CurrentValue = cgiGet( cmbCentroCostosEstado_Internalname);
                              A482CentroCostosEstado = cgiGet( cmbCentroCostosEstado_Internalname);
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
                                          E163Z2 ();
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
                                          E173Z2 ();
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
                                          E183Z2 ();
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
                                       STRUP3Z0( ) ;
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

      protected void WE3Z2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3Z2( ) ;
            }
         }
      }

      protected void PA3Z2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "listacostosdetalles1wc.aspx")), "listacostosdetalles1wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "listacostosdetalles1wc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ListaCostosId");
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
                                       long AV8ListaCostosId ,
                                       short AV20ManageFiltersExecutionStep ,
                                       string AV66Pgmname ,
                                       long AV21TFCentroCostosId ,
                                       long AV22TFCentroCostosId_To ,
                                       GxSimpleCollection<string> AV24TFCentroCostosTipoRef_Sels ,
                                       long AV25TFCentroCostosRef ,
                                       long AV26TFCentroCostosRef_To ,
                                       string AV27TFCentroCostosNombre ,
                                       string AV28TFCentroCostosNombre_Sel ,
                                       decimal AV29TFCentroCostosPrecioFinal ,
                                       decimal AV30TFCentroCostosPrecioFinal_To ,
                                       decimal AV31TFCentroCostosSubTotal ,
                                       decimal AV32TFCentroCostosSubTotal_To ,
                                       decimal AV33TFCentroCostosCosto ,
                                       decimal AV34TFCentroCostosCosto_To ,
                                       decimal AV35TFCentroCostosGam ,
                                       decimal AV36TFCentroCostosGam_To ,
                                       string AV37TFCentroCostosUsrAlta ,
                                       string AV38TFCentroCostosUsrAlta_Sel ,
                                       string AV39TFCentroCostosUsrMod ,
                                       string AV40TFCentroCostosUsrMod_Sel ,
                                       DateTime AV41TFCentroCostosHoraAlt ,
                                       DateTime AV42TFCentroCostosHoraAlt_To ,
                                       DateTime AV46TFCentroCostosHoraMod ,
                                       DateTime AV47TFCentroCostosHoraMod_To ,
                                       GxSimpleCollection<string> AV52TFCentroCostosEstado_Sels ,
                                       bool AV61IsAuthorized_Update ,
                                       bool AV62IsAuthorized_Delete ,
                                       bool AV63IsAuthorized_CentroCostosNombre ,
                                       long AV65CentroCostosRef ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3Z2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_CENTROCOSTOSID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"CENTROCOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, ".", "")));
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
         RF3Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV66Pgmname = "ListaCostosDetalles1WC";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A487CentroCostosTipoRef ,
                                              AV24TFCentroCostosTipoRef_Sels ,
                                              A482CentroCostosEstado ,
                                              AV52TFCentroCostosEstado_Sels ,
                                              AV21TFCentroCostosId ,
                                              AV22TFCentroCostosId_To ,
                                              AV24TFCentroCostosTipoRef_Sels.Count ,
                                              AV25TFCentroCostosRef ,
                                              AV26TFCentroCostosRef_To ,
                                              AV28TFCentroCostosNombre_Sel ,
                                              AV27TFCentroCostosNombre ,
                                              AV29TFCentroCostosPrecioFinal ,
                                              AV30TFCentroCostosPrecioFinal_To ,
                                              AV31TFCentroCostosSubTotal ,
                                              AV32TFCentroCostosSubTotal_To ,
                                              AV33TFCentroCostosCosto ,
                                              AV34TFCentroCostosCosto_To ,
                                              AV35TFCentroCostosGam ,
                                              AV36TFCentroCostosGam_To ,
                                              AV38TFCentroCostosUsrAlta_Sel ,
                                              AV37TFCentroCostosUsrAlta ,
                                              AV40TFCentroCostosUsrMod_Sel ,
                                              AV39TFCentroCostosUsrMod ,
                                              AV41TFCentroCostosHoraAlt ,
                                              AV42TFCentroCostosHoraAlt_To ,
                                              AV46TFCentroCostosHoraMod ,
                                              AV47TFCentroCostosHoraMod_To ,
                                              AV52TFCentroCostosEstado_Sels.Count ,
                                              A461CentroCostosId ,
                                              A462CentroCostosRef ,
                                              A463CentroCostosNombre ,
                                              A464CentroCostosPrecioFinal ,
                                              A469CentroCostosSubTotal ,
                                              A475CentroCostosCosto ,
                                              A478CentroCostosUsrAlta ,
                                              A479CentroCostosUsrMod ,
                                              A480CentroCostosHoraAlt ,
                                              A481CentroCostosHoraMod ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV16FilterFullText ,
                                              A474CentroCostosGam ,
                                              AV8ListaCostosId ,
                                              A459ListaCostosId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV27TFCentroCostosNombre = StringUtil.PadR( StringUtil.RTrim( AV27TFCentroCostosNombre), 80, "%");
         lV37TFCentroCostosUsrAlta = StringUtil.PadR( StringUtil.RTrim( AV37TFCentroCostosUsrAlta), 30, "%");
         lV39TFCentroCostosUsrMod = StringUtil.PadR( StringUtil.RTrim( AV39TFCentroCostosUsrMod), 30, "%");
         /* Using cursor H003Z3 */
         pr_default.execute(0, new Object[] {AV8ListaCostosId, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV25TFCentroCostosRef, AV26TFCentroCostosRef_To, lV27TFCentroCostosNombre, AV28TFCentroCostosNombre_Sel, AV29TFCentroCostosPrecioFinal, AV30TFCentroCostosPrecioFinal_To, AV31TFCentroCostosSubTotal, AV32TFCentroCostosSubTotal_To, AV33TFCentroCostosCosto, AV34TFCentroCostosCosto_To, AV35TFCentroCostosGam, AV36TFCentroCostosGam_To, lV37TFCentroCostosUsrAlta, AV38TFCentroCostosUsrAlta_Sel, lV39TFCentroCostosUsrMod, AV40TFCentroCostosUsrMod_Sel, AV41TFCentroCostosHoraAlt, AV42TFCentroCostosHoraAlt_To, AV46TFCentroCostosHoraMod, AV47TFCentroCostosHoraMod_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A459ListaCostosId = H003Z3_A459ListaCostosId[0];
            n459ListaCostosId = H003Z3_n459ListaCostosId[0];
            AssignAttri(sPrefix, false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
            A482CentroCostosEstado = H003Z3_A482CentroCostosEstado[0];
            A481CentroCostosHoraMod = H003Z3_A481CentroCostosHoraMod[0];
            A480CentroCostosHoraAlt = H003Z3_A480CentroCostosHoraAlt[0];
            A479CentroCostosUsrMod = H003Z3_A479CentroCostosUsrMod[0];
            A478CentroCostosUsrAlta = H003Z3_A478CentroCostosUsrAlta[0];
            A474CentroCostosGam = H003Z3_A474CentroCostosGam[0];
            A465CentroCostosSerial = H003Z3_A465CentroCostosSerial[0];
            A463CentroCostosNombre = H003Z3_A463CentroCostosNombre[0];
            A462CentroCostosRef = H003Z3_A462CentroCostosRef[0];
            A487CentroCostosTipoRef = H003Z3_A487CentroCostosTipoRef[0];
            A461CentroCostosId = H003Z3_A461CentroCostosId[0];
            A464CentroCostosPrecioFinal = H003Z3_A464CentroCostosPrecioFinal[0];
            A475CentroCostosCosto = H003Z3_A475CentroCostosCosto[0];
            A469CentroCostosSubTotal = H003Z3_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = H003Z3_n469CentroCostosSubTotal[0];
            A482CentroCostosEstado = H003Z3_A482CentroCostosEstado[0];
            A481CentroCostosHoraMod = H003Z3_A481CentroCostosHoraMod[0];
            A480CentroCostosHoraAlt = H003Z3_A480CentroCostosHoraAlt[0];
            A479CentroCostosUsrMod = H003Z3_A479CentroCostosUsrMod[0];
            A478CentroCostosUsrAlta = H003Z3_A478CentroCostosUsrAlta[0];
            A474CentroCostosGam = H003Z3_A474CentroCostosGam[0];
            A465CentroCostosSerial = H003Z3_A465CentroCostosSerial[0];
            A463CentroCostosNombre = H003Z3_A463CentroCostosNombre[0];
            A462CentroCostosRef = H003Z3_A462CentroCostosRef[0];
            A487CentroCostosTipoRef = H003Z3_A487CentroCostosTipoRef[0];
            A464CentroCostosPrecioFinal = H003Z3_A464CentroCostosPrecioFinal[0];
            A475CentroCostosCosto = H003Z3_A475CentroCostosCosto[0];
            A469CentroCostosSubTotal = H003Z3_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = H003Z3_n469CentroCostosSubTotal[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A461CentroCostosId), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A487CentroCostosTipoRef, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "O") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A462CentroCostosRef), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A463CentroCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A464CentroCostosPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A469CentroCostosSubTotal, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A475CentroCostosCosto, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A474CentroCostosGam, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A478CentroCostosUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A479CentroCostosUsrMod) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "aprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente de aprobación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "PND") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "desaprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) )
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

      protected void RF3Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E173Z2 ();
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
                                                 A487CentroCostosTipoRef ,
                                                 AV24TFCentroCostosTipoRef_Sels ,
                                                 A482CentroCostosEstado ,
                                                 AV52TFCentroCostosEstado_Sels ,
                                                 AV21TFCentroCostosId ,
                                                 AV22TFCentroCostosId_To ,
                                                 AV24TFCentroCostosTipoRef_Sels.Count ,
                                                 AV25TFCentroCostosRef ,
                                                 AV26TFCentroCostosRef_To ,
                                                 AV28TFCentroCostosNombre_Sel ,
                                                 AV27TFCentroCostosNombre ,
                                                 AV29TFCentroCostosPrecioFinal ,
                                                 AV30TFCentroCostosPrecioFinal_To ,
                                                 AV31TFCentroCostosSubTotal ,
                                                 AV32TFCentroCostosSubTotal_To ,
                                                 AV33TFCentroCostosCosto ,
                                                 AV34TFCentroCostosCosto_To ,
                                                 AV35TFCentroCostosGam ,
                                                 AV36TFCentroCostosGam_To ,
                                                 AV38TFCentroCostosUsrAlta_Sel ,
                                                 AV37TFCentroCostosUsrAlta ,
                                                 AV40TFCentroCostosUsrMod_Sel ,
                                                 AV39TFCentroCostosUsrMod ,
                                                 AV41TFCentroCostosHoraAlt ,
                                                 AV42TFCentroCostosHoraAlt_To ,
                                                 AV46TFCentroCostosHoraMod ,
                                                 AV47TFCentroCostosHoraMod_To ,
                                                 AV52TFCentroCostosEstado_Sels.Count ,
                                                 A461CentroCostosId ,
                                                 A462CentroCostosRef ,
                                                 A463CentroCostosNombre ,
                                                 A464CentroCostosPrecioFinal ,
                                                 A469CentroCostosSubTotal ,
                                                 A475CentroCostosCosto ,
                                                 A478CentroCostosUsrAlta ,
                                                 A479CentroCostosUsrMod ,
                                                 A480CentroCostosHoraAlt ,
                                                 A481CentroCostosHoraMod ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV16FilterFullText ,
                                                 A474CentroCostosGam ,
                                                 AV8ListaCostosId ,
                                                 A459ListaCostosId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.LONG,
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN
                                                 }
            });
            lV27TFCentroCostosNombre = StringUtil.PadR( StringUtil.RTrim( AV27TFCentroCostosNombre), 80, "%");
            lV37TFCentroCostosUsrAlta = StringUtil.PadR( StringUtil.RTrim( AV37TFCentroCostosUsrAlta), 30, "%");
            lV39TFCentroCostosUsrMod = StringUtil.PadR( StringUtil.RTrim( AV39TFCentroCostosUsrMod), 30, "%");
            /* Using cursor H003Z5 */
            pr_default.execute(1, new Object[] {AV8ListaCostosId, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV25TFCentroCostosRef, AV26TFCentroCostosRef_To, lV27TFCentroCostosNombre, AV28TFCentroCostosNombre_Sel, AV29TFCentroCostosPrecioFinal, AV30TFCentroCostosPrecioFinal_To, AV31TFCentroCostosSubTotal, AV32TFCentroCostosSubTotal_To, AV33TFCentroCostosCosto, AV34TFCentroCostosCosto_To, AV35TFCentroCostosGam, AV36TFCentroCostosGam_To, lV37TFCentroCostosUsrAlta, AV38TFCentroCostosUsrAlta_Sel, lV39TFCentroCostosUsrMod, AV40TFCentroCostosUsrMod_Sel, AV41TFCentroCostosHoraAlt, AV42TFCentroCostosHoraAlt_To, AV46TFCentroCostosHoraMod, AV47TFCentroCostosHoraMod_To});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A459ListaCostosId = H003Z5_A459ListaCostosId[0];
               n459ListaCostosId = H003Z5_n459ListaCostosId[0];
               AssignAttri(sPrefix, false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
               A482CentroCostosEstado = H003Z5_A482CentroCostosEstado[0];
               A481CentroCostosHoraMod = H003Z5_A481CentroCostosHoraMod[0];
               A480CentroCostosHoraAlt = H003Z5_A480CentroCostosHoraAlt[0];
               A479CentroCostosUsrMod = H003Z5_A479CentroCostosUsrMod[0];
               A478CentroCostosUsrAlta = H003Z5_A478CentroCostosUsrAlta[0];
               A474CentroCostosGam = H003Z5_A474CentroCostosGam[0];
               A465CentroCostosSerial = H003Z5_A465CentroCostosSerial[0];
               A463CentroCostosNombre = H003Z5_A463CentroCostosNombre[0];
               A462CentroCostosRef = H003Z5_A462CentroCostosRef[0];
               A487CentroCostosTipoRef = H003Z5_A487CentroCostosTipoRef[0];
               A461CentroCostosId = H003Z5_A461CentroCostosId[0];
               A464CentroCostosPrecioFinal = H003Z5_A464CentroCostosPrecioFinal[0];
               A475CentroCostosCosto = H003Z5_A475CentroCostosCosto[0];
               A469CentroCostosSubTotal = H003Z5_A469CentroCostosSubTotal[0];
               n469CentroCostosSubTotal = H003Z5_n469CentroCostosSubTotal[0];
               A482CentroCostosEstado = H003Z5_A482CentroCostosEstado[0];
               A481CentroCostosHoraMod = H003Z5_A481CentroCostosHoraMod[0];
               A480CentroCostosHoraAlt = H003Z5_A480CentroCostosHoraAlt[0];
               A479CentroCostosUsrMod = H003Z5_A479CentroCostosUsrMod[0];
               A478CentroCostosUsrAlta = H003Z5_A478CentroCostosUsrAlta[0];
               A474CentroCostosGam = H003Z5_A474CentroCostosGam[0];
               A465CentroCostosSerial = H003Z5_A465CentroCostosSerial[0];
               A463CentroCostosNombre = H003Z5_A463CentroCostosNombre[0];
               A462CentroCostosRef = H003Z5_A462CentroCostosRef[0];
               A487CentroCostosTipoRef = H003Z5_A487CentroCostosTipoRef[0];
               A464CentroCostosPrecioFinal = H003Z5_A464CentroCostosPrecioFinal[0];
               A475CentroCostosCosto = H003Z5_A475CentroCostosCosto[0];
               A469CentroCostosSubTotal = H003Z5_A469CentroCostosSubTotal[0];
               n469CentroCostosSubTotal = H003Z5_n469CentroCostosSubTotal[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A461CentroCostosId), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A487CentroCostosTipoRef, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "O") == 0 ) ) ||
               ( StringUtil.Like( StringUtil.Str( (decimal)(A462CentroCostosRef), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A463CentroCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( A464CentroCostosPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A469CentroCostosSubTotal, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( A475CentroCostosCosto, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A474CentroCostosGam, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A478CentroCostosUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A479CentroCostosUsrMod) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "aprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente de aprobación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "PND") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "desaprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E183Z2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 37;
            WB3Z0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3Z2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV66Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV66Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV61IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV61IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV62IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV62IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_CENTROCOSTOSNOMBRE", AV63IsAuthorized_CentroCostosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_CENTROCOSTOSNOMBRE", GetSecureSignedToken( sPrefix, AV63IsAuthorized_CentroCostosNombre, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_CENTROCOSTOSID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sPrefix+sGXsfl_37_idx, context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCENTROCOSTOSREF", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCENTROCOSTOSREF", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV65CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"), context));
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8ListaCostosId, AV20ManageFiltersExecutionStep, AV66Pgmname, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV24TFCentroCostosTipoRef_Sels, AV25TFCentroCostosRef, AV26TFCentroCostosRef_To, AV27TFCentroCostosNombre, AV28TFCentroCostosNombre_Sel, AV29TFCentroCostosPrecioFinal, AV30TFCentroCostosPrecioFinal_To, AV31TFCentroCostosSubTotal, AV32TFCentroCostosSubTotal_To, AV33TFCentroCostosCosto, AV34TFCentroCostosCosto_To, AV35TFCentroCostosGam, AV36TFCentroCostosGam_To, AV37TFCentroCostosUsrAlta, AV38TFCentroCostosUsrAlta_Sel, AV39TFCentroCostosUsrMod, AV40TFCentroCostosUsrMod_Sel, AV41TFCentroCostosHoraAlt, AV42TFCentroCostosHoraAlt_To, AV46TFCentroCostosHoraMod, AV47TFCentroCostosHoraMod_To, AV52TFCentroCostosEstado_Sels, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV63IsAuthorized_CentroCostosNombre, AV65CentroCostosRef, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8ListaCostosId, AV20ManageFiltersExecutionStep, AV66Pgmname, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV24TFCentroCostosTipoRef_Sels, AV25TFCentroCostosRef, AV26TFCentroCostosRef_To, AV27TFCentroCostosNombre, AV28TFCentroCostosNombre_Sel, AV29TFCentroCostosPrecioFinal, AV30TFCentroCostosPrecioFinal_To, AV31TFCentroCostosSubTotal, AV32TFCentroCostosSubTotal_To, AV33TFCentroCostosCosto, AV34TFCentroCostosCosto_To, AV35TFCentroCostosGam, AV36TFCentroCostosGam_To, AV37TFCentroCostosUsrAlta, AV38TFCentroCostosUsrAlta_Sel, AV39TFCentroCostosUsrMod, AV40TFCentroCostosUsrMod_Sel, AV41TFCentroCostosHoraAlt, AV42TFCentroCostosHoraAlt_To, AV46TFCentroCostosHoraMod, AV47TFCentroCostosHoraMod_To, AV52TFCentroCostosEstado_Sels, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV63IsAuthorized_CentroCostosNombre, AV65CentroCostosRef, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8ListaCostosId, AV20ManageFiltersExecutionStep, AV66Pgmname, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV24TFCentroCostosTipoRef_Sels, AV25TFCentroCostosRef, AV26TFCentroCostosRef_To, AV27TFCentroCostosNombre, AV28TFCentroCostosNombre_Sel, AV29TFCentroCostosPrecioFinal, AV30TFCentroCostosPrecioFinal_To, AV31TFCentroCostosSubTotal, AV32TFCentroCostosSubTotal_To, AV33TFCentroCostosCosto, AV34TFCentroCostosCosto_To, AV35TFCentroCostosGam, AV36TFCentroCostosGam_To, AV37TFCentroCostosUsrAlta, AV38TFCentroCostosUsrAlta_Sel, AV39TFCentroCostosUsrMod, AV40TFCentroCostosUsrMod_Sel, AV41TFCentroCostosHoraAlt, AV42TFCentroCostosHoraAlt_To, AV46TFCentroCostosHoraMod, AV47TFCentroCostosHoraMod_To, AV52TFCentroCostosEstado_Sels, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV63IsAuthorized_CentroCostosNombre, AV65CentroCostosRef, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8ListaCostosId, AV20ManageFiltersExecutionStep, AV66Pgmname, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV24TFCentroCostosTipoRef_Sels, AV25TFCentroCostosRef, AV26TFCentroCostosRef_To, AV27TFCentroCostosNombre, AV28TFCentroCostosNombre_Sel, AV29TFCentroCostosPrecioFinal, AV30TFCentroCostosPrecioFinal_To, AV31TFCentroCostosSubTotal, AV32TFCentroCostosSubTotal_To, AV33TFCentroCostosCosto, AV34TFCentroCostosCosto_To, AV35TFCentroCostosGam, AV36TFCentroCostosGam_To, AV37TFCentroCostosUsrAlta, AV38TFCentroCostosUsrAlta_Sel, AV39TFCentroCostosUsrMod, AV40TFCentroCostosUsrMod_Sel, AV41TFCentroCostosHoraAlt, AV42TFCentroCostosHoraAlt_To, AV46TFCentroCostosHoraMod, AV47TFCentroCostosHoraMod_To, AV52TFCentroCostosEstado_Sels, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV63IsAuthorized_CentroCostosNombre, AV65CentroCostosRef, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8ListaCostosId, AV20ManageFiltersExecutionStep, AV66Pgmname, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV24TFCentroCostosTipoRef_Sels, AV25TFCentroCostosRef, AV26TFCentroCostosRef_To, AV27TFCentroCostosNombre, AV28TFCentroCostosNombre_Sel, AV29TFCentroCostosPrecioFinal, AV30TFCentroCostosPrecioFinal_To, AV31TFCentroCostosSubTotal, AV32TFCentroCostosSubTotal_To, AV33TFCentroCostosCosto, AV34TFCentroCostosCosto_To, AV35TFCentroCostosGam, AV36TFCentroCostosGam_To, AV37TFCentroCostosUsrAlta, AV38TFCentroCostosUsrAlta_Sel, AV39TFCentroCostosUsrMod, AV40TFCentroCostosUsrMod_Sel, AV41TFCentroCostosHoraAlt, AV42TFCentroCostosHoraAlt_To, AV46TFCentroCostosHoraMod, AV47TFCentroCostosHoraMod_To, AV52TFCentroCostosEstado_Sels, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV63IsAuthorized_CentroCostosNombre, AV65CentroCostosRef, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV66Pgmname = "ListaCostosDetalles1WC";
         edtCentroCostosId_Enabled = 0;
         cmbCentroCostosTipoRef.Enabled = 0;
         edtCentroCostosRef_Enabled = 0;
         edtCentroCostosNombre_Enabled = 0;
         edtCentroCostosPrecioFinal_Enabled = 0;
         edtCentroCostosSerial_Enabled = 0;
         edtCentroCostosSubTotal_Enabled = 0;
         edtCentroCostosCosto_Enabled = 0;
         edtCentroCostosGam_Enabled = 0;
         edtCentroCostosUsrAlta_Enabled = 0;
         edtCentroCostosUsrMod_Enabled = 0;
         edtCentroCostosHoraAlt_Enabled = 0;
         edtCentroCostosHoraMod_Enabled = 0;
         cmbCentroCostosEstado.Enabled = 0;
         edtListaCostosId_Enabled = 0;
         AssignProp(sPrefix, false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E163Z2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV18ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV53DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV56GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV57GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV58GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            AV43DDO_CentroCostosHoraAltAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_CENTROCOSTOSHORAALTAUXDATE"), 0);
            AV44DDO_CentroCostosHoraAltAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_CENTROCOSTOSHORAALTAUXDATETO"), 0);
            AV48DDO_CentroCostosHoraModAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_CENTROCOSTOSHORAMODAUXDATE"), 0);
            AV49DDO_CentroCostosHoraModAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_CENTROCOSTOSHORAMODAUXDATETO"), 0);
            wcpOAV8ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8ListaCostosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV65CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vCENTROCOSTOSREF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
            A459ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n459ListaCostosId = false;
            AssignAttri(sPrefix, false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
            AV45DDO_CentroCostosHoraAltAuxDateText = cgiGet( edtavDdo_centrocostoshoraaltauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV45DDO_CentroCostosHoraAltAuxDateText", AV45DDO_CentroCostosHoraAltAuxDateText);
            AV50DDO_CentroCostosHoraModAuxDateText = cgiGet( edtavDdo_centrocostoshoramodauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV50DDO_CentroCostosHoraModAuxDateText", AV50DDO_CentroCostosHoraModAuxDateText);
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
         E163Z2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E163Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFCENTROCOSTOSHORAMOD_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_centrocostoshoramodauxdatetext_Internalname});
         this.executeUsercontrolMethod(sPrefix, false, "TFCENTROCOSTOSHORAALT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_centrocostoshoraaltauxdatetext_Internalname});
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
         GXt_boolean1 = AV63IsAuthorized_CentroCostosNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos", out  GXt_boolean1) ;
         AV63IsAuthorized_CentroCostosNombre = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV63IsAuthorized_CentroCostosNombre", AV63IsAuthorized_CentroCostosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_CENTROCOSTOSNOMBRE", GetSecureSignedToken( sPrefix, AV63IsAuthorized_CentroCostosNombre, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         edtListaCostosId_Visible = 0;
         AssignProp(sPrefix, false, edtListaCostosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Visible), 5, 0), true);
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV53DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV53DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E173Z2( )
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
         AV56GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV56GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV56GridCurrentPage), 10, 0));
         AV57GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV57GridPageCount", StringUtil.LTrimStr( (decimal)(AV57GridPageCount), 10, 0));
         GXt_char3 = AV58GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV66Pgmname, out  GXt_char3) ;
         AV58GridAppliedFilters = GXt_char3;
         AssignAttri(sPrefix, false, "AV58GridAppliedFilters", AV58GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E123Z2( )
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
            AV55PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV55PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E133Z2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E143Z2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosId") == 0 )
            {
               AV21TFCentroCostosId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV21TFCentroCostosId", StringUtil.LTrimStr( (decimal)(AV21TFCentroCostosId), 18, 0));
               AV22TFCentroCostosId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV22TFCentroCostosId_To", StringUtil.LTrimStr( (decimal)(AV22TFCentroCostosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosTipoRef") == 0 )
            {
               AV23TFCentroCostosTipoRef_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV23TFCentroCostosTipoRef_SelsJson", AV23TFCentroCostosTipoRef_SelsJson);
               AV24TFCentroCostosTipoRef_Sels.FromJSonString(AV23TFCentroCostosTipoRef_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosRef") == 0 )
            {
               AV25TFCentroCostosRef = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV25TFCentroCostosRef", StringUtil.LTrimStr( (decimal)(AV25TFCentroCostosRef), 18, 0));
               AV26TFCentroCostosRef_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV26TFCentroCostosRef_To", StringUtil.LTrimStr( (decimal)(AV26TFCentroCostosRef_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosNombre") == 0 )
            {
               AV27TFCentroCostosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV27TFCentroCostosNombre", AV27TFCentroCostosNombre);
               AV28TFCentroCostosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV28TFCentroCostosNombre_Sel", AV28TFCentroCostosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosPrecioFinal") == 0 )
            {
               AV29TFCentroCostosPrecioFinal = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV29TFCentroCostosPrecioFinal", StringUtil.LTrimStr( AV29TFCentroCostosPrecioFinal, 18, 2));
               AV30TFCentroCostosPrecioFinal_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV30TFCentroCostosPrecioFinal_To", StringUtil.LTrimStr( AV30TFCentroCostosPrecioFinal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosSubTotal") == 0 )
            {
               AV31TFCentroCostosSubTotal = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV31TFCentroCostosSubTotal", StringUtil.LTrimStr( AV31TFCentroCostosSubTotal, 18, 2));
               AV32TFCentroCostosSubTotal_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV32TFCentroCostosSubTotal_To", StringUtil.LTrimStr( AV32TFCentroCostosSubTotal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosCosto") == 0 )
            {
               AV33TFCentroCostosCosto = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV33TFCentroCostosCosto", StringUtil.LTrimStr( AV33TFCentroCostosCosto, 18, 2));
               AV34TFCentroCostosCosto_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV34TFCentroCostosCosto_To", StringUtil.LTrimStr( AV34TFCentroCostosCosto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosGam") == 0 )
            {
               AV35TFCentroCostosGam = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV35TFCentroCostosGam", StringUtil.LTrimStr( AV35TFCentroCostosGam, 18, 2));
               AV36TFCentroCostosGam_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV36TFCentroCostosGam_To", StringUtil.LTrimStr( AV36TFCentroCostosGam_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosUsrAlta") == 0 )
            {
               AV37TFCentroCostosUsrAlta = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV37TFCentroCostosUsrAlta", AV37TFCentroCostosUsrAlta);
               AV38TFCentroCostosUsrAlta_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV38TFCentroCostosUsrAlta_Sel", AV38TFCentroCostosUsrAlta_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosUsrMod") == 0 )
            {
               AV39TFCentroCostosUsrMod = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV39TFCentroCostosUsrMod", AV39TFCentroCostosUsrMod);
               AV40TFCentroCostosUsrMod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV40TFCentroCostosUsrMod_Sel", AV40TFCentroCostosUsrMod_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosHoraAlt") == 0 )
            {
               AV41TFCentroCostosHoraAlt = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV41TFCentroCostosHoraAlt", context.localUtil.Format(AV41TFCentroCostosHoraAlt, "99/99/99"));
               AV42TFCentroCostosHoraAlt_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV42TFCentroCostosHoraAlt_To", context.localUtil.Format(AV42TFCentroCostosHoraAlt_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosHoraMod") == 0 )
            {
               AV46TFCentroCostosHoraMod = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV46TFCentroCostosHoraMod", context.localUtil.Format(AV46TFCentroCostosHoraMod, "99/99/99"));
               AV47TFCentroCostosHoraMod_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV47TFCentroCostosHoraMod_To", context.localUtil.Format(AV47TFCentroCostosHoraMod_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosEstado") == 0 )
            {
               AV51TFCentroCostosEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV51TFCentroCostosEstado_SelsJson", AV51TFCentroCostosEstado_SelsJson);
               AV52TFCentroCostosEstado_Sels.FromJSonString(AV51TFCentroCostosEstado_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV52TFCentroCostosEstado_Sels", AV52TFCentroCostosEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24TFCentroCostosTipoRef_Sels", AV24TFCentroCostosTipoRef_Sels);
      }

      private void E183Z2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV61IsAuthorized_Update )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV62IsAuthorized_Delete )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            if ( AV63IsAuthorized_CentroCostosNombre )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "centrocostosview.aspx"+UrlEncode(StringUtil.LTrimStr(A461CentroCostosId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(A462CentroCostosRef,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtCentroCostosNombre_Link = formatLink("centrocostosview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV59GridActions), 4, 0));
      }

      protected void E113Z2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("ListaCostosDetalles1WCFilters")) + "," + UrlEncode(StringUtil.RTrim(AV66Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("ListaCostosDetalles1WCFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char3 = AV19ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ListaCostosDetalles1WCFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV66Pgmname+"GridState",  AV19ManageFiltersXml) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24TFCentroCostosTipoRef_Sels", AV24TFCentroCostosTipoRef_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV52TFCentroCostosEstado_Sels", AV52TFCentroCostosEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
      }

      protected void E153Z2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         CallWebObject(formatLink("costoservicios.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.LTrimStr(AV65CentroCostosRef,18,0))}, new string[] {"Mode","CentroCostosId","CentroCostosRef"}) );
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
         GXt_boolean1 = AV61IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Update", out  GXt_boolean1) ;
         AV61IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV61IsAuthorized_Update", AV61IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV61IsAuthorized_Update, context));
         GXt_boolean1 = AV62IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Delete", out  GXt_boolean1) ;
         AV62IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV62IsAuthorized_Delete", AV62IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV62IsAuthorized_Delete, context));
         GXt_boolean1 = AV64TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Insert", out  GXt_boolean1) ;
         AV64TempBoolean = GXt_boolean1;
         if ( ! ( AV64TempBoolean ) )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ListaCostosDetalles1WCFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV18ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
         AV21TFCentroCostosId = 0;
         AssignAttri(sPrefix, false, "AV21TFCentroCostosId", StringUtil.LTrimStr( (decimal)(AV21TFCentroCostosId), 18, 0));
         AV22TFCentroCostosId_To = 0;
         AssignAttri(sPrefix, false, "AV22TFCentroCostosId_To", StringUtil.LTrimStr( (decimal)(AV22TFCentroCostosId_To), 18, 0));
         AV24TFCentroCostosTipoRef_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25TFCentroCostosRef = 0;
         AssignAttri(sPrefix, false, "AV25TFCentroCostosRef", StringUtil.LTrimStr( (decimal)(AV25TFCentroCostosRef), 18, 0));
         AV26TFCentroCostosRef_To = 0;
         AssignAttri(sPrefix, false, "AV26TFCentroCostosRef_To", StringUtil.LTrimStr( (decimal)(AV26TFCentroCostosRef_To), 18, 0));
         AV27TFCentroCostosNombre = "";
         AssignAttri(sPrefix, false, "AV27TFCentroCostosNombre", AV27TFCentroCostosNombre);
         AV28TFCentroCostosNombre_Sel = "";
         AssignAttri(sPrefix, false, "AV28TFCentroCostosNombre_Sel", AV28TFCentroCostosNombre_Sel);
         AV29TFCentroCostosPrecioFinal = 0;
         AssignAttri(sPrefix, false, "AV29TFCentroCostosPrecioFinal", StringUtil.LTrimStr( AV29TFCentroCostosPrecioFinal, 18, 2));
         AV30TFCentroCostosPrecioFinal_To = 0;
         AssignAttri(sPrefix, false, "AV30TFCentroCostosPrecioFinal_To", StringUtil.LTrimStr( AV30TFCentroCostosPrecioFinal_To, 18, 2));
         AV31TFCentroCostosSubTotal = 0;
         AssignAttri(sPrefix, false, "AV31TFCentroCostosSubTotal", StringUtil.LTrimStr( AV31TFCentroCostosSubTotal, 18, 2));
         AV32TFCentroCostosSubTotal_To = 0;
         AssignAttri(sPrefix, false, "AV32TFCentroCostosSubTotal_To", StringUtil.LTrimStr( AV32TFCentroCostosSubTotal_To, 18, 2));
         AV33TFCentroCostosCosto = 0;
         AssignAttri(sPrefix, false, "AV33TFCentroCostosCosto", StringUtil.LTrimStr( AV33TFCentroCostosCosto, 18, 2));
         AV34TFCentroCostosCosto_To = 0;
         AssignAttri(sPrefix, false, "AV34TFCentroCostosCosto_To", StringUtil.LTrimStr( AV34TFCentroCostosCosto_To, 18, 2));
         AV35TFCentroCostosGam = 0;
         AssignAttri(sPrefix, false, "AV35TFCentroCostosGam", StringUtil.LTrimStr( AV35TFCentroCostosGam, 18, 2));
         AV36TFCentroCostosGam_To = 0;
         AssignAttri(sPrefix, false, "AV36TFCentroCostosGam_To", StringUtil.LTrimStr( AV36TFCentroCostosGam_To, 18, 2));
         AV37TFCentroCostosUsrAlta = "";
         AssignAttri(sPrefix, false, "AV37TFCentroCostosUsrAlta", AV37TFCentroCostosUsrAlta);
         AV38TFCentroCostosUsrAlta_Sel = "";
         AssignAttri(sPrefix, false, "AV38TFCentroCostosUsrAlta_Sel", AV38TFCentroCostosUsrAlta_Sel);
         AV39TFCentroCostosUsrMod = "";
         AssignAttri(sPrefix, false, "AV39TFCentroCostosUsrMod", AV39TFCentroCostosUsrMod);
         AV40TFCentroCostosUsrMod_Sel = "";
         AssignAttri(sPrefix, false, "AV40TFCentroCostosUsrMod_Sel", AV40TFCentroCostosUsrMod_Sel);
         AV41TFCentroCostosHoraAlt = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV41TFCentroCostosHoraAlt", context.localUtil.Format(AV41TFCentroCostosHoraAlt, "99/99/99"));
         AV42TFCentroCostosHoraAlt_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV42TFCentroCostosHoraAlt_To", context.localUtil.Format(AV42TFCentroCostosHoraAlt_To, "99/99/99"));
         AV46TFCentroCostosHoraMod = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV46TFCentroCostosHoraMod", context.localUtil.Format(AV46TFCentroCostosHoraMod, "99/99/99"));
         AV47TFCentroCostosHoraMod_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV47TFCentroCostosHoraMod_To", context.localUtil.Format(AV47TFCentroCostosHoraMod_To, "99/99/99"));
         AV52TFCentroCostosEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
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
         CallWebObject(formatLink("costoservicios.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A461CentroCostosId,18,0)),UrlEncode(StringUtil.LTrimStr(AV65CentroCostosRef,18,0))}, new string[] {"Mode","CentroCostosId","CentroCostosRef"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S202( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         CallWebObject(formatLink("costoservicios.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A461CentroCostosId,18,0)),UrlEncode(StringUtil.LTrimStr(AV65CentroCostosRef,18,0))}, new string[] {"Mode","CentroCostosId","CentroCostosRef"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S212( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         CallWebObject(formatLink("costoservicios.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A461CentroCostosId,18,0)),UrlEncode(StringUtil.LTrimStr(AV65CentroCostosRef,18,0))}, new string[] {"Mode","CentroCostosId","CentroCostosRef"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17Session.Get(AV66Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV66Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV17Session.Get(AV66Pgmname+"GridState"), null, "", "");
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
         AV67GXV1 = 1;
         while ( AV67GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV67GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSID") == 0 )
            {
               AV21TFCentroCostosId = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV21TFCentroCostosId", StringUtil.LTrimStr( (decimal)(AV21TFCentroCostosId), 18, 0));
               AV22TFCentroCostosId_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV22TFCentroCostosId_To", StringUtil.LTrimStr( (decimal)(AV22TFCentroCostosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSTIPOREF_SEL") == 0 )
            {
               AV23TFCentroCostosTipoRef_SelsJson = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV23TFCentroCostosTipoRef_SelsJson", AV23TFCentroCostosTipoRef_SelsJson);
               AV24TFCentroCostosTipoRef_Sels.FromJSonString(AV23TFCentroCostosTipoRef_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSREF") == 0 )
            {
               AV25TFCentroCostosRef = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV25TFCentroCostosRef", StringUtil.LTrimStr( (decimal)(AV25TFCentroCostosRef), 18, 0));
               AV26TFCentroCostosRef_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV26TFCentroCostosRef_To", StringUtil.LTrimStr( (decimal)(AV26TFCentroCostosRef_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE") == 0 )
            {
               AV27TFCentroCostosNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV27TFCentroCostosNombre", AV27TFCentroCostosNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE_SEL") == 0 )
            {
               AV28TFCentroCostosNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV28TFCentroCostosNombre_Sel", AV28TFCentroCostosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSPRECIOFINAL") == 0 )
            {
               AV29TFCentroCostosPrecioFinal = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV29TFCentroCostosPrecioFinal", StringUtil.LTrimStr( AV29TFCentroCostosPrecioFinal, 18, 2));
               AV30TFCentroCostosPrecioFinal_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV30TFCentroCostosPrecioFinal_To", StringUtil.LTrimStr( AV30TFCentroCostosPrecioFinal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSSUBTOTAL") == 0 )
            {
               AV31TFCentroCostosSubTotal = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV31TFCentroCostosSubTotal", StringUtil.LTrimStr( AV31TFCentroCostosSubTotal, 18, 2));
               AV32TFCentroCostosSubTotal_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV32TFCentroCostosSubTotal_To", StringUtil.LTrimStr( AV32TFCentroCostosSubTotal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSCOSTO") == 0 )
            {
               AV33TFCentroCostosCosto = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV33TFCentroCostosCosto", StringUtil.LTrimStr( AV33TFCentroCostosCosto, 18, 2));
               AV34TFCentroCostosCosto_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV34TFCentroCostosCosto_To", StringUtil.LTrimStr( AV34TFCentroCostosCosto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSGAM") == 0 )
            {
               AV35TFCentroCostosGam = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV35TFCentroCostosGam", StringUtil.LTrimStr( AV35TFCentroCostosGam, 18, 2));
               AV36TFCentroCostosGam_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV36TFCentroCostosGam_To", StringUtil.LTrimStr( AV36TFCentroCostosGam_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSUSRALTA") == 0 )
            {
               AV37TFCentroCostosUsrAlta = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV37TFCentroCostosUsrAlta", AV37TFCentroCostosUsrAlta);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSUSRALTA_SEL") == 0 )
            {
               AV38TFCentroCostosUsrAlta_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV38TFCentroCostosUsrAlta_Sel", AV38TFCentroCostosUsrAlta_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSUSRMOD") == 0 )
            {
               AV39TFCentroCostosUsrMod = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV39TFCentroCostosUsrMod", AV39TFCentroCostosUsrMod);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSUSRMOD_SEL") == 0 )
            {
               AV40TFCentroCostosUsrMod_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV40TFCentroCostosUsrMod_Sel", AV40TFCentroCostosUsrMod_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSHORAALT") == 0 )
            {
               AV41TFCentroCostosHoraAlt = context.localUtil.CToD( AV13GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV41TFCentroCostosHoraAlt", context.localUtil.Format(AV41TFCentroCostosHoraAlt, "99/99/99"));
               AV42TFCentroCostosHoraAlt_To = context.localUtil.CToD( AV13GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV42TFCentroCostosHoraAlt_To", context.localUtil.Format(AV42TFCentroCostosHoraAlt_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSHORAMOD") == 0 )
            {
               AV46TFCentroCostosHoraMod = context.localUtil.CToD( AV13GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV46TFCentroCostosHoraMod", context.localUtil.Format(AV46TFCentroCostosHoraMod, "99/99/99"));
               AV47TFCentroCostosHoraMod_To = context.localUtil.CToD( AV13GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV47TFCentroCostosHoraMod_To", context.localUtil.Format(AV47TFCentroCostosHoraMod_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSESTADO_SEL") == 0 )
            {
               AV51TFCentroCostosEstado_SelsJson = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV51TFCentroCostosEstado_SelsJson", AV51TFCentroCostosEstado_SelsJson);
               AV52TFCentroCostosEstado_Sels.FromJSonString(AV51TFCentroCostosEstado_SelsJson, null);
            }
            AV67GXV1 = (int)(AV67GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV24TFCentroCostosTipoRef_Sels.Count==0),  AV23TFCentroCostosTipoRef_SelsJson, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCentroCostosNombre_Sel)),  AV28TFCentroCostosNombre_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCentroCostosUsrAlta_Sel)),  AV38TFCentroCostosUsrAlta_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCentroCostosUsrMod_Sel)),  AV40TFCentroCostosUsrMod_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV52TFCentroCostosEstado_Sels.Count==0),  AV51TFCentroCostosEstado_SelsJson, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char3+"||"+GXt_char5+"|||||"+GXt_char6+"|"+GXt_char7+"|||"+GXt_char8;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFCentroCostosNombre)),  AV27TFCentroCostosNombre, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCentroCostosUsrAlta)),  AV37TFCentroCostosUsrAlta, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCentroCostosUsrMod)),  AV39TFCentroCostosUsrMod, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = ((0==AV21TFCentroCostosId) ? "" : StringUtil.Str( (decimal)(AV21TFCentroCostosId), 18, 0))+"||"+((0==AV25TFCentroCostosRef) ? "" : StringUtil.Str( (decimal)(AV25TFCentroCostosRef), 18, 0))+"|"+GXt_char8+"|"+((Convert.ToDecimal(0)==AV29TFCentroCostosPrecioFinal) ? "" : StringUtil.Str( AV29TFCentroCostosPrecioFinal, 18, 2))+"|"+((Convert.ToDecimal(0)==AV31TFCentroCostosSubTotal) ? "" : StringUtil.Str( AV31TFCentroCostosSubTotal, 18, 2))+"|"+((Convert.ToDecimal(0)==AV33TFCentroCostosCosto) ? "" : StringUtil.Str( AV33TFCentroCostosCosto, 18, 2))+"|"+((Convert.ToDecimal(0)==AV35TFCentroCostosGam) ? "" : StringUtil.Str( AV35TFCentroCostosGam, 18, 2))+"|"+GXt_char7+"|"+GXt_char6+"|"+((DateTime.MinValue==AV41TFCentroCostosHoraAlt) ? "" : context.localUtil.DToC( AV41TFCentroCostosHoraAlt, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV46TFCentroCostosHoraMod) ? "" : context.localUtil.DToC( AV46TFCentroCostosHoraMod, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV22TFCentroCostosId_To) ? "" : StringUtil.Str( (decimal)(AV22TFCentroCostosId_To), 18, 0))+"||"+((0==AV26TFCentroCostosRef_To) ? "" : StringUtil.Str( (decimal)(AV26TFCentroCostosRef_To), 18, 0))+"||"+((Convert.ToDecimal(0)==AV30TFCentroCostosPrecioFinal_To) ? "" : StringUtil.Str( AV30TFCentroCostosPrecioFinal_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV32TFCentroCostosSubTotal_To) ? "" : StringUtil.Str( AV32TFCentroCostosSubTotal_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV34TFCentroCostosCosto_To) ? "" : StringUtil.Str( AV34TFCentroCostosCosto_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV36TFCentroCostosGam_To) ? "" : StringUtil.Str( AV36TFCentroCostosGam_To, 18, 2))+"|||"+((DateTime.MinValue==AV42TFCentroCostosHoraAlt_To) ? "" : context.localUtil.DToC( AV42TFCentroCostosHoraAlt_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV47TFCentroCostosHoraMod_To) ? "" : context.localUtil.DToC( AV47TFCentroCostosHoraMod_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV17Session.Get(AV66Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSID",  context.GetMessage( "Código CC:", ""),  !((0==AV21TFCentroCostosId)&&(0==AV22TFCentroCostosId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV21TFCentroCostosId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV22TFCentroCostosId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSTIPOREF_SEL",  context.GetMessage( "Tipo Referencia:", ""),  !(AV24TFCentroCostosTipoRef_Sels.Count==0),  0,  AV24TFCentroCostosTipoRef_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSREF",  context.GetMessage( "Referencia Nro:", ""),  !((0==AV25TFCentroCostosRef)&&(0==AV26TFCentroCostosRef_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV25TFCentroCostosRef), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV26TFCentroCostosRef_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSNOMBRE",  context.GetMessage( "Nombre:", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFCentroCostosNombre)),  0,  AV27TFCentroCostosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCentroCostosNombre_Sel)),  AV28TFCentroCostosNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSPRECIOFINAL",  context.GetMessage( "Precio Final:", ""),  !((Convert.ToDecimal(0)==AV29TFCentroCostosPrecioFinal)&&(Convert.ToDecimal(0)==AV30TFCentroCostosPrecioFinal_To)),  0,  StringUtil.Trim( StringUtil.Str( AV29TFCentroCostosPrecioFinal, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV30TFCentroCostosPrecioFinal_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSSUBTOTAL",  context.GetMessage( "Sub Total", ""),  !((Convert.ToDecimal(0)==AV31TFCentroCostosSubTotal)&&(Convert.ToDecimal(0)==AV32TFCentroCostosSubTotal_To)),  0,  StringUtil.Trim( StringUtil.Str( AV31TFCentroCostosSubTotal, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV32TFCentroCostosSubTotal_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSCOSTO",  context.GetMessage( "Costo", ""),  !((Convert.ToDecimal(0)==AV33TFCentroCostosCosto)&&(Convert.ToDecimal(0)==AV34TFCentroCostosCosto_To)),  0,  StringUtil.Trim( StringUtil.Str( AV33TFCentroCostosCosto, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV34TFCentroCostosCosto_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSGAM",  context.GetMessage( "Ganancia", ""),  !((Convert.ToDecimal(0)==AV35TFCentroCostosGam)&&(Convert.ToDecimal(0)==AV36TFCentroCostosGam_To)),  0,  StringUtil.Trim( StringUtil.Str( AV35TFCentroCostosGam, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV36TFCentroCostosGam_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSUSRALTA",  context.GetMessage( "Usuario de Alta", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCentroCostosUsrAlta)),  0,  AV37TFCentroCostosUsrAlta,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCentroCostosUsrAlta_Sel)),  AV38TFCentroCostosUsrAlta_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSUSRMOD",  context.GetMessage( "Usuario de Modificiación", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCentroCostosUsrMod)),  0,  AV39TFCentroCostosUsrMod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCentroCostosUsrMod_Sel)),  AV40TFCentroCostosUsrMod_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSHORAALT",  context.GetMessage( "Hora de Alta", ""),  !((DateTime.MinValue==AV41TFCentroCostosHoraAlt)&&(DateTime.MinValue==AV42TFCentroCostosHoraAlt_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV41TFCentroCostosHoraAlt, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV42TFCentroCostosHoraAlt_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSHORAMOD",  context.GetMessage( "Hora de Modificiación", ""),  !((DateTime.MinValue==AV46TFCentroCostosHoraMod)&&(DateTime.MinValue==AV47TFCentroCostosHoraMod_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV46TFCentroCostosHoraMod, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV47TFCentroCostosHoraMod_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSESTADO_SEL",  context.GetMessage( "Estado", ""),  !(AV52TFCentroCostosEstado_Sels.Count==0),  0,  AV52TFCentroCostosEstado_Sels.ToJSonString(false),  "") ;
         if ( ! (0==AV8ListaCostosId) )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = "PARM_&LISTACOSTOSID";
            AV13GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV8ListaCostosId), 18, 0);
            AV12GridState.gxTpr_Filtervalues.Add(AV13GridStateFilterValue, 0);
         }
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV66Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV66Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "CostoServicios";
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "ListaCostosId";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8ListaCostosId), 18, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV17Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table1_22_3Z2( bool wbgen )
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
            wb_table2_27_3Z2( true) ;
         }
         else
         {
            wb_table2_27_3Z2( false) ;
         }
         return  ;
      }

      protected void wb_table2_27_3Z2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_22_3Z2e( true) ;
         }
         else
         {
            wb_table1_22_3Z2e( false) ;
         }
      }

      protected void wb_table2_27_3Z2( bool wbgen )
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ListaCostosDetalles1WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_27_3Z2e( true) ;
         }
         else
         {
            wb_table2_27_3Z2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8ListaCostosId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV8ListaCostosId", StringUtil.LTrimStr( (decimal)(AV8ListaCostosId), 18, 0));
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
         PA3Z2( ) ;
         WS3Z2( ) ;
         WE3Z2( ) ;
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
         sCtrlAV8ListaCostosId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3Z2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "listacostosdetalles1wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3Z2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8ListaCostosId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV8ListaCostosId", StringUtil.LTrimStr( (decimal)(AV8ListaCostosId), 18, 0));
         }
         wcpOAV8ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8ListaCostosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV8ListaCostosId != wcpOAV8ListaCostosId ) ) )
         {
            setjustcreated();
         }
         wcpOAV8ListaCostosId = AV8ListaCostosId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8ListaCostosId = cgiGet( sPrefix+"AV8ListaCostosId_CTRL");
         if ( StringUtil.Len( sCtrlAV8ListaCostosId) > 0 )
         {
            AV8ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8ListaCostosId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8ListaCostosId", StringUtil.LTrimStr( (decimal)(AV8ListaCostosId), 18, 0));
         }
         else
         {
            AV8ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8ListaCostosId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA3Z2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3Z2( ) ;
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
         WS3Z2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8ListaCostosId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8ListaCostosId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8ListaCostosId_CTRL", StringUtil.RTrim( sCtrlAV8ListaCostosId));
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
         WE3Z2( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021123899", true, true, false);
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
         context.AddJavascriptSource("listacostosdetalles1wc.js", "?20267302112390", false, true, false);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_372( )
      {
         cmbavGridactions_Internalname = sPrefix+"vGRIDACTIONS_"+sGXsfl_37_idx;
         edtCentroCostosId_Internalname = sPrefix+"CENTROCOSTOSID_"+sGXsfl_37_idx;
         cmbCentroCostosTipoRef_Internalname = sPrefix+"CENTROCOSTOSTIPOREF_"+sGXsfl_37_idx;
         edtCentroCostosRef_Internalname = sPrefix+"CENTROCOSTOSREF_"+sGXsfl_37_idx;
         edtCentroCostosNombre_Internalname = sPrefix+"CENTROCOSTOSNOMBRE_"+sGXsfl_37_idx;
         edtCentroCostosPrecioFinal_Internalname = sPrefix+"CENTROCOSTOSPRECIOFINAL_"+sGXsfl_37_idx;
         edtCentroCostosSerial_Internalname = sPrefix+"CENTROCOSTOSSERIAL_"+sGXsfl_37_idx;
         edtCentroCostosSubTotal_Internalname = sPrefix+"CENTROCOSTOSSUBTOTAL_"+sGXsfl_37_idx;
         edtCentroCostosCosto_Internalname = sPrefix+"CENTROCOSTOSCOSTO_"+sGXsfl_37_idx;
         edtCentroCostosGam_Internalname = sPrefix+"CENTROCOSTOSGAM_"+sGXsfl_37_idx;
         edtCentroCostosUsrAlta_Internalname = sPrefix+"CENTROCOSTOSUSRALTA_"+sGXsfl_37_idx;
         edtCentroCostosUsrMod_Internalname = sPrefix+"CENTROCOSTOSUSRMOD_"+sGXsfl_37_idx;
         edtCentroCostosHoraAlt_Internalname = sPrefix+"CENTROCOSTOSHORAALT_"+sGXsfl_37_idx;
         edtCentroCostosHoraMod_Internalname = sPrefix+"CENTROCOSTOSHORAMOD_"+sGXsfl_37_idx;
         cmbCentroCostosEstado_Internalname = sPrefix+"CENTROCOSTOSESTADO_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         cmbavGridactions_Internalname = sPrefix+"vGRIDACTIONS_"+sGXsfl_37_fel_idx;
         edtCentroCostosId_Internalname = sPrefix+"CENTROCOSTOSID_"+sGXsfl_37_fel_idx;
         cmbCentroCostosTipoRef_Internalname = sPrefix+"CENTROCOSTOSTIPOREF_"+sGXsfl_37_fel_idx;
         edtCentroCostosRef_Internalname = sPrefix+"CENTROCOSTOSREF_"+sGXsfl_37_fel_idx;
         edtCentroCostosNombre_Internalname = sPrefix+"CENTROCOSTOSNOMBRE_"+sGXsfl_37_fel_idx;
         edtCentroCostosPrecioFinal_Internalname = sPrefix+"CENTROCOSTOSPRECIOFINAL_"+sGXsfl_37_fel_idx;
         edtCentroCostosSerial_Internalname = sPrefix+"CENTROCOSTOSSERIAL_"+sGXsfl_37_fel_idx;
         edtCentroCostosSubTotal_Internalname = sPrefix+"CENTROCOSTOSSUBTOTAL_"+sGXsfl_37_fel_idx;
         edtCentroCostosCosto_Internalname = sPrefix+"CENTROCOSTOSCOSTO_"+sGXsfl_37_fel_idx;
         edtCentroCostosGam_Internalname = sPrefix+"CENTROCOSTOSGAM_"+sGXsfl_37_fel_idx;
         edtCentroCostosUsrAlta_Internalname = sPrefix+"CENTROCOSTOSUSRALTA_"+sGXsfl_37_fel_idx;
         edtCentroCostosUsrMod_Internalname = sPrefix+"CENTROCOSTOSUSRMOD_"+sGXsfl_37_fel_idx;
         edtCentroCostosHoraAlt_Internalname = sPrefix+"CENTROCOSTOSHORAALT_"+sGXsfl_37_fel_idx;
         edtCentroCostosHoraMod_Internalname = sPrefix+"CENTROCOSTOSHORAMOD_"+sGXsfl_37_fel_idx;
         cmbCentroCostosEstado_Internalname = sPrefix+"CENTROCOSTOSESTADO_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB3Z0( ) ;
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
                  AV59GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV59GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV59GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV59GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)7,(string)"'"+sPrefix+"'"+",false,"+"'"+"e193z2_client"+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV59GridActions), 4, 0));
            AssignProp(sPrefix, false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "CENTROCOSTOSTIPOREF_" + sGXsfl_37_idx;
            cmbCentroCostosTipoRef.Name = GXCCtl;
            cmbCentroCostosTipoRef.WebTags = "";
            cmbCentroCostosTipoRef.addItem("S", context.GetMessage( "Servicios", ""), 0);
            cmbCentroCostosTipoRef.addItem("O", context.GetMessage( "Otros", ""), 0);
            if ( cmbCentroCostosTipoRef.ItemCount > 0 )
            {
               A487CentroCostosTipoRef = cmbCentroCostosTipoRef.getValidValue(A487CentroCostosTipoRef);
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCentroCostosTipoRef,(string)cmbCentroCostosTipoRef_Internalname,StringUtil.RTrim( A487CentroCostosTipoRef),(short)1,(string)cmbCentroCostosTipoRef_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbCentroCostosTipoRef.CurrentValue = StringUtil.RTrim( A487CentroCostosTipoRef);
            AssignProp(sPrefix, false, cmbCentroCostosTipoRef_Internalname, "Values", (string)(cmbCentroCostosTipoRef.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosRef_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A462CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A462CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosRef_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosNombre_Internalname,StringUtil.RTrim( A463CentroCostosNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtCentroCostosNombre_Link,(string)"",(string)"",(string)"",(string)edtCentroCostosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A464CentroCostosPrecioFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A464CentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosSerial_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A465CentroCostosSerial), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A465CentroCostosSerial), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosSerial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosSubTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( A469CentroCostosSubTotal, 22, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A469CentroCostosSubTotal, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosSubTotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)22,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Total",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosCosto_Internalname,StringUtil.LTrim( StringUtil.NToC( A475CentroCostosCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A475CentroCostosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosCosto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosGam_Internalname,StringUtil.LTrim( StringUtil.NToC( A474CentroCostosGam, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A474CentroCostosGam, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosGam_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosUsrAlta_Internalname,StringUtil.RTrim( A478CentroCostosUsrAlta),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosUsrAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Usuario",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosUsrMod_Internalname,StringUtil.RTrim( A479CentroCostosUsrMod),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosUsrMod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Usuario",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosHoraAlt_Internalname,context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"),context.localUtil.Format( A480CentroCostosHoraAlt, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosHoraAlt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosHoraMod_Internalname,context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99"),context.localUtil.Format( A481CentroCostosHoraMod, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosHoraMod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "CENTROCOSTOSESTADO_" + sGXsfl_37_idx;
            cmbCentroCostosEstado.Name = GXCCtl;
            cmbCentroCostosEstado.WebTags = "";
            cmbCentroCostosEstado.addItem("HAB", context.GetMessage( "Aprobado", ""), 0);
            cmbCentroCostosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
            cmbCentroCostosEstado.addItem("PND", context.GetMessage( "Pendiente de Aprobación", ""), 0);
            cmbCentroCostosEstado.addItem("DES", context.GetMessage( "Desaprobado", ""), 0);
            if ( cmbCentroCostosEstado.ItemCount > 0 )
            {
               A482CentroCostosEstado = cmbCentroCostosEstado.getValidValue(A482CentroCostosEstado);
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCentroCostosEstado,(string)cmbCentroCostosEstado_Internalname,StringUtil.RTrim( A482CentroCostosEstado),(short)1,(string)cmbCentroCostosEstado_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbCentroCostosEstado.CurrentValue = StringUtil.RTrim( A482CentroCostosEstado);
            AssignProp(sPrefix, false, cmbCentroCostosEstado_Internalname, "Values", (string)(cmbCentroCostosEstado.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            send_integrity_lvl_hashes3Z2( ) ;
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
         GXCCtl = "CENTROCOSTOSTIPOREF_" + sGXsfl_37_idx;
         cmbCentroCostosTipoRef.Name = GXCCtl;
         cmbCentroCostosTipoRef.WebTags = "";
         cmbCentroCostosTipoRef.addItem("S", context.GetMessage( "Servicios", ""), 0);
         cmbCentroCostosTipoRef.addItem("O", context.GetMessage( "Otros", ""), 0);
         if ( cmbCentroCostosTipoRef.ItemCount > 0 )
         {
         }
         GXCCtl = "CENTROCOSTOSESTADO_" + sGXsfl_37_idx;
         cmbCentroCostosEstado.Name = GXCCtl;
         cmbCentroCostosEstado.WebTags = "";
         cmbCentroCostosEstado.addItem("HAB", context.GetMessage( "Aprobado", ""), 0);
         cmbCentroCostosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbCentroCostosEstado.addItem("PND", context.GetMessage( "Pendiente de Aprobación", ""), 0);
         cmbCentroCostosEstado.addItem("DES", context.GetMessage( "Desaprobado", ""), 0);
         if ( cmbCentroCostosEstado.ItemCount > 0 )
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Código CC:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo Referencia:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Referencia Nro:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio Final:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Costos Serial", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Sub Total", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Costo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Ganancia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Usuario de Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Usuario de Modificiación", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Hora de Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Hora de Modificiación", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A487CentroCostosTipoRef)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A462CentroCostosRef), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A463CentroCostosNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCentroCostosNombre_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A464CentroCostosPrecioFinal, 21, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A465CentroCostosSerial), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A469CentroCostosSubTotal, 22, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A475CentroCostosCosto, 21, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A474CentroCostosGam, 21, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A478CentroCostosUsrAlta)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A479CentroCostosUsrMod)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A482CentroCostosEstado)));
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
         edtCentroCostosId_Internalname = sPrefix+"CENTROCOSTOSID";
         cmbCentroCostosTipoRef_Internalname = sPrefix+"CENTROCOSTOSTIPOREF";
         edtCentroCostosRef_Internalname = sPrefix+"CENTROCOSTOSREF";
         edtCentroCostosNombre_Internalname = sPrefix+"CENTROCOSTOSNOMBRE";
         edtCentroCostosPrecioFinal_Internalname = sPrefix+"CENTROCOSTOSPRECIOFINAL";
         edtCentroCostosSerial_Internalname = sPrefix+"CENTROCOSTOSSERIAL";
         edtCentroCostosSubTotal_Internalname = sPrefix+"CENTROCOSTOSSUBTOTAL";
         edtCentroCostosCosto_Internalname = sPrefix+"CENTROCOSTOSCOSTO";
         edtCentroCostosGam_Internalname = sPrefix+"CENTROCOSTOSGAM";
         edtCentroCostosUsrAlta_Internalname = sPrefix+"CENTROCOSTOSUSRALTA";
         edtCentroCostosUsrMod_Internalname = sPrefix+"CENTROCOSTOSUSRMOD";
         edtCentroCostosHoraAlt_Internalname = sPrefix+"CENTROCOSTOSHORAALT";
         edtCentroCostosHoraMod_Internalname = sPrefix+"CENTROCOSTOSHORAMOD";
         cmbCentroCostosEstado_Internalname = sPrefix+"CENTROCOSTOSESTADO";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtListaCostosId_Internalname = sPrefix+"LISTACOSTOSID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_centrocostoshoraaltauxdatetext_Internalname = sPrefix+"vDDO_CENTROCOSTOSHORAALTAUXDATETEXT";
         Tfcentrocostoshoraalt_rangepicker_Internalname = sPrefix+"TFCENTROCOSTOSHORAALT_RANGEPICKER";
         divDdo_centrocostoshoraaltauxdates_Internalname = sPrefix+"DDO_CENTROCOSTOSHORAALTAUXDATES";
         edtavDdo_centrocostoshoramodauxdatetext_Internalname = sPrefix+"vDDO_CENTROCOSTOSHORAMODAUXDATETEXT";
         Tfcentrocostoshoramod_rangepicker_Internalname = sPrefix+"TFCENTROCOSTOSHORAMOD_RANGEPICKER";
         divDdo_centrocostoshoramodauxdates_Internalname = sPrefix+"DDO_CENTROCOSTOSHORAMODAUXDATES";
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
         cmbCentroCostosEstado_Jsonclick = "";
         edtCentroCostosHoraMod_Jsonclick = "";
         edtCentroCostosHoraAlt_Jsonclick = "";
         edtCentroCostosUsrMod_Jsonclick = "";
         edtCentroCostosUsrAlta_Jsonclick = "";
         edtCentroCostosGam_Jsonclick = "";
         edtCentroCostosCosto_Jsonclick = "";
         edtCentroCostosSubTotal_Jsonclick = "";
         edtCentroCostosSerial_Jsonclick = "";
         edtCentroCostosPrecioFinal_Jsonclick = "";
         edtCentroCostosNombre_Jsonclick = "";
         edtCentroCostosNombre_Link = "";
         edtCentroCostosRef_Jsonclick = "";
         cmbCentroCostosTipoRef_Jsonclick = "";
         edtCentroCostosId_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtListaCostosId_Enabled = 0;
         cmbCentroCostosEstado.Enabled = 0;
         edtCentroCostosHoraMod_Enabled = 0;
         edtCentroCostosHoraAlt_Enabled = 0;
         edtCentroCostosUsrMod_Enabled = 0;
         edtCentroCostosUsrAlta_Enabled = 0;
         edtCentroCostosGam_Enabled = 0;
         edtCentroCostosCosto_Enabled = 0;
         edtCentroCostosSubTotal_Enabled = 0;
         edtCentroCostosSerial_Enabled = 0;
         edtCentroCostosPrecioFinal_Enabled = 0;
         edtCentroCostosNombre_Enabled = 0;
         edtCentroCostosRef_Enabled = 0;
         cmbCentroCostosTipoRef.Enabled = 0;
         edtCentroCostosId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_centrocostoshoramodauxdatetext_Jsonclick = "";
         edtavDdo_centrocostoshoraaltauxdatetext_Jsonclick = "";
         edtListaCostosId_Jsonclick = "";
         edtListaCostosId_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "18.0||18.0||-18.2|18.2|-18.2|-18.2|||||";
         Ddo_grid_Datalistproc = "ListaCostosDetalles1WCGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|S:Servicios,O:Otros|||||||||||HAB:Aprobado,DES:Deshabilitado,PND:Pendiente de Aprobación,DES:Desaprobado";
         Ddo_grid_Allowmultipleselection = "|T|||||||||||T";
         Ddo_grid_Datalisttype = "|FixedValues||Dynamic|||||Dynamic|Dynamic|||FixedValues";
         Ddo_grid_Includedatalist = "|T||T|||||T|T|||T";
         Ddo_grid_Filterisrange = "T||T||T|T|T|T|||P|P|";
         Ddo_grid_Filtertype = "Numeric||Numeric|Character|Numeric|Numeric|Numeric|Numeric|Character|Character|Date|Date|";
         Ddo_grid_Includefilter = "T||T|T|T|T|T|T|T|T|T|T|";
         Ddo_grid_Includesortasc = "T|T|T|T|T||T||T|T|T|T|T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5||6||7|8|9|10|11";
         Ddo_grid_Columnids = "1:CentroCostosId|2:CentroCostosTipoRef|3:CentroCostosRef|4:CentroCostosNombre|5:CentroCostosPrecioFinal|7:CentroCostosSubTotal|8:CentroCostosCosto|9:CentroCostosGam|10:CentroCostosUsrAlta|11:CentroCostosUsrMod|12:CentroCostosHoraAlt|13:CentroCostosHoraMod|14:CentroCostosEstado";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'sPrefix',type:'char'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8ListaCostosId',fld:'vLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV66Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV25TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV28TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV30TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31TFCentroCostosSubTotal',fld:'vTFCENTROCOSTOSSUBTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV32TFCentroCostosSubTotal_To',fld:'vTFCENTROCOSTOSSUBTOTAL_TO',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV33TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV34TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV36TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV37TFCentroCostosUsrAlta',fld:'vTFCENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'AV38TFCentroCostosUsrAlta_Sel',fld:'vTFCENTROCOSTOSUSRALTA_SEL',pic:'',type:'char'},{av:'AV39TFCentroCostosUsrMod',fld:'vTFCENTROCOSTOSUSRMOD',pic:'',type:'char'},{av:'AV40TFCentroCostosUsrMod_Sel',fld:'vTFCENTROCOSTOSUSRMOD_SEL',pic:'',type:'char'},{av:'AV41TFCentroCostosHoraAlt',fld:'vTFCENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'AV42TFCentroCostosHoraAlt_To',fld:'vTFCENTROCOSTOSHORAALT_TO',pic:'',type:'date'},{av:'AV46TFCentroCostosHoraMod',fld:'vTFCENTROCOSTOSHORAMOD',pic:'',type:'date'},{av:'AV47TFCentroCostosHoraMod_To',fld:'vTFCENTROCOSTOSHORAMOD_TO',pic:'',type:'date'},{av:'AV52TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV63IsAuthorized_CentroCostosNombre',fld:'vISAUTHORIZED_CENTROCOSTOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV65CentroCostosRef',fld:'vCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV56GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV58GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E123Z2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8ListaCostosId',fld:'vLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV66Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV25TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV28TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV30TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31TFCentroCostosSubTotal',fld:'vTFCENTROCOSTOSSUBTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV32TFCentroCostosSubTotal_To',fld:'vTFCENTROCOSTOSSUBTOTAL_TO',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV33TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV34TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV36TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV37TFCentroCostosUsrAlta',fld:'vTFCENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'AV38TFCentroCostosUsrAlta_Sel',fld:'vTFCENTROCOSTOSUSRALTA_SEL',pic:'',type:'char'},{av:'AV39TFCentroCostosUsrMod',fld:'vTFCENTROCOSTOSUSRMOD',pic:'',type:'char'},{av:'AV40TFCentroCostosUsrMod_Sel',fld:'vTFCENTROCOSTOSUSRMOD_SEL',pic:'',type:'char'},{av:'AV41TFCentroCostosHoraAlt',fld:'vTFCENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'AV42TFCentroCostosHoraAlt_To',fld:'vTFCENTROCOSTOSHORAALT_TO',pic:'',type:'date'},{av:'AV46TFCentroCostosHoraMod',fld:'vTFCENTROCOSTOSHORAMOD',pic:'',type:'date'},{av:'AV47TFCentroCostosHoraMod_To',fld:'vTFCENTROCOSTOSHORAMOD_TO',pic:'',type:'date'},{av:'AV52TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV63IsAuthorized_CentroCostosNombre',fld:'vISAUTHORIZED_CENTROCOSTOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV65CentroCostosRef',fld:'vCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV56GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV58GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E133Z2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8ListaCostosId',fld:'vLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV66Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV25TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV28TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV30TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31TFCentroCostosSubTotal',fld:'vTFCENTROCOSTOSSUBTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV32TFCentroCostosSubTotal_To',fld:'vTFCENTROCOSTOSSUBTOTAL_TO',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV33TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV34TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV36TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV37TFCentroCostosUsrAlta',fld:'vTFCENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'AV38TFCentroCostosUsrAlta_Sel',fld:'vTFCENTROCOSTOSUSRALTA_SEL',pic:'',type:'char'},{av:'AV39TFCentroCostosUsrMod',fld:'vTFCENTROCOSTOSUSRMOD',pic:'',type:'char'},{av:'AV40TFCentroCostosUsrMod_Sel',fld:'vTFCENTROCOSTOSUSRMOD_SEL',pic:'',type:'char'},{av:'AV41TFCentroCostosHoraAlt',fld:'vTFCENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'AV42TFCentroCostosHoraAlt_To',fld:'vTFCENTROCOSTOSHORAALT_TO',pic:'',type:'date'},{av:'AV46TFCentroCostosHoraMod',fld:'vTFCENTROCOSTOSHORAMOD',pic:'',type:'date'},{av:'AV47TFCentroCostosHoraMod_To',fld:'vTFCENTROCOSTOSHORAMOD_TO',pic:'',type:'date'},{av:'AV52TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV63IsAuthorized_CentroCostosNombre',fld:'vISAUTHORIZED_CENTROCOSTOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV65CentroCostosRef',fld:'vCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E143Z2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8ListaCostosId',fld:'vLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV66Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV25TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV28TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV30TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31TFCentroCostosSubTotal',fld:'vTFCENTROCOSTOSSUBTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV32TFCentroCostosSubTotal_To',fld:'vTFCENTROCOSTOSSUBTOTAL_TO',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV33TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV34TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV36TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV37TFCentroCostosUsrAlta',fld:'vTFCENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'AV38TFCentroCostosUsrAlta_Sel',fld:'vTFCENTROCOSTOSUSRALTA_SEL',pic:'',type:'char'},{av:'AV39TFCentroCostosUsrMod',fld:'vTFCENTROCOSTOSUSRMOD',pic:'',type:'char'},{av:'AV40TFCentroCostosUsrMod_Sel',fld:'vTFCENTROCOSTOSUSRMOD_SEL',pic:'',type:'char'},{av:'AV41TFCentroCostosHoraAlt',fld:'vTFCENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'AV42TFCentroCostosHoraAlt_To',fld:'vTFCENTROCOSTOSHORAALT_TO',pic:'',type:'date'},{av:'AV46TFCentroCostosHoraMod',fld:'vTFCENTROCOSTOSHORAMOD',pic:'',type:'date'},{av:'AV47TFCentroCostosHoraMod_To',fld:'vTFCENTROCOSTOSHORAMOD_TO',pic:'',type:'date'},{av:'AV52TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV63IsAuthorized_CentroCostosNombre',fld:'vISAUTHORIZED_CENTROCOSTOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV65CentroCostosRef',fld:'vCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'sPrefix',type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV51TFCentroCostosEstado_SelsJson',fld:'vTFCENTROCOSTOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV52TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV46TFCentroCostosHoraMod',fld:'vTFCENTROCOSTOSHORAMOD',pic:'',type:'date'},{av:'AV47TFCentroCostosHoraMod_To',fld:'vTFCENTROCOSTOSHORAMOD_TO',pic:'',type:'date'},{av:'AV41TFCentroCostosHoraAlt',fld:'vTFCENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'AV42TFCentroCostosHoraAlt_To',fld:'vTFCENTROCOSTOSHORAALT_TO',pic:'',type:'date'},{av:'AV39TFCentroCostosUsrMod',fld:'vTFCENTROCOSTOSUSRMOD',pic:'',type:'char'},{av:'AV40TFCentroCostosUsrMod_Sel',fld:'vTFCENTROCOSTOSUSRMOD_SEL',pic:'',type:'char'},{av:'AV37TFCentroCostosUsrAlta',fld:'vTFCENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'AV38TFCentroCostosUsrAlta_Sel',fld:'vTFCENTROCOSTOSUSRALTA_SEL',pic:'',type:'char'},{av:'AV35TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV36TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV33TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV34TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31TFCentroCostosSubTotal',fld:'vTFCENTROCOSTOSSUBTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV32TFCentroCostosSubTotal_To',fld:'vTFCENTROCOSTOSSUBTOTAL_TO',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV29TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV30TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV27TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV28TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFCentroCostosTipoRef_SelsJson',fld:'vTFCENTROCOSTOSTIPOREF_SELSJSON',pic:'',type:'vchar'},{av:'AV24TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV21TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E183Z2',iparms:[{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV63IsAuthorized_CentroCostosNombre',fld:'vISAUTHORIZED_CENTROCOSTOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A462CentroCostosRef',fld:'CENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV59GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtCentroCostosNombre_Link',ctrl:'CENTROCOSTOSNOMBRE',prop:'Link'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E113Z2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8ListaCostosId',fld:'vLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV66Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV25TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV28TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV30TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31TFCentroCostosSubTotal',fld:'vTFCENTROCOSTOSSUBTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV32TFCentroCostosSubTotal_To',fld:'vTFCENTROCOSTOSSUBTOTAL_TO',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV33TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV34TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV36TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV37TFCentroCostosUsrAlta',fld:'vTFCENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'AV38TFCentroCostosUsrAlta_Sel',fld:'vTFCENTROCOSTOSUSRALTA_SEL',pic:'',type:'char'},{av:'AV39TFCentroCostosUsrMod',fld:'vTFCENTROCOSTOSUSRMOD',pic:'',type:'char'},{av:'AV40TFCentroCostosUsrMod_Sel',fld:'vTFCENTROCOSTOSUSRMOD_SEL',pic:'',type:'char'},{av:'AV41TFCentroCostosHoraAlt',fld:'vTFCENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'AV42TFCentroCostosHoraAlt_To',fld:'vTFCENTROCOSTOSHORAALT_TO',pic:'',type:'date'},{av:'AV46TFCentroCostosHoraMod',fld:'vTFCENTROCOSTOSHORAMOD',pic:'',type:'date'},{av:'AV47TFCentroCostosHoraMod_To',fld:'vTFCENTROCOSTOSHORAMOD_TO',pic:'',type:'date'},{av:'AV52TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV63IsAuthorized_CentroCostosNombre',fld:'vISAUTHORIZED_CENTROCOSTOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV65CentroCostosRef',fld:'vCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'sPrefix',type:'char'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''},{av:'AV23TFCentroCostosTipoRef_SelsJson',fld:'vTFCENTROCOSTOSTIPOREF_SELSJSON',pic:'',type:'vchar'},{av:'AV51TFCentroCostosEstado_SelsJson',fld:'vTFCENTROCOSTOSESTADO_SELSJSON',pic:'',type:'vchar'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV25TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV28TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV30TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31TFCentroCostosSubTotal',fld:'vTFCENTROCOSTOSSUBTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV32TFCentroCostosSubTotal_To',fld:'vTFCENTROCOSTOSSUBTOTAL_TO',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV33TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV34TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV36TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV37TFCentroCostosUsrAlta',fld:'vTFCENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'AV38TFCentroCostosUsrAlta_Sel',fld:'vTFCENTROCOSTOSUSRALTA_SEL',pic:'',type:'char'},{av:'AV39TFCentroCostosUsrMod',fld:'vTFCENTROCOSTOSUSRMOD',pic:'',type:'char'},{av:'AV40TFCentroCostosUsrMod_Sel',fld:'vTFCENTROCOSTOSUSRMOD_SEL',pic:'',type:'char'},{av:'AV41TFCentroCostosHoraAlt',fld:'vTFCENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'AV42TFCentroCostosHoraAlt_To',fld:'vTFCENTROCOSTOSHORAALT_TO',pic:'',type:'date'},{av:'AV46TFCentroCostosHoraMod',fld:'vTFCENTROCOSTOSHORAMOD',pic:'',type:'date'},{av:'AV47TFCentroCostosHoraMod_To',fld:'vTFCENTROCOSTOSHORAMOD_TO',pic:'',type:'date'},{av:'AV52TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV51TFCentroCostosEstado_SelsJson',fld:'vTFCENTROCOSTOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV23TFCentroCostosTipoRef_SelsJson',fld:'vTFCENTROCOSTOSTIPOREF_SELSJSON',pic:'',type:'vchar'},{av:'AV56GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV58GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E193Z2',iparms:[{av:'cmbavGridactions'},{av:'AV59GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV65CentroCostosRef',fld:'vCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV59GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E153Z2',iparms:[{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV65CentroCostosRef',fld:'vCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSID","{handler:'Valid_Centrocostosid',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSID",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSTIPOREF","{handler:'Valid_Centrocostostiporef',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSTIPOREF",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSREF","{handler:'Valid_Centrocostosref',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSREF",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSNOMBRE","{handler:'Valid_Centrocostosnombre',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSPRECIOFINAL","{handler:'Valid_Centrocostospreciofinal',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSPRECIOFINAL",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSSUBTOTAL","{handler:'Valid_Centrocostossubtotal',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSSUBTOTAL",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSCOSTO","{handler:'Valid_Centrocostoscosto',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSCOSTO",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSGAM","{handler:'Valid_Centrocostosgam',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSGAM",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSUSRALTA","{handler:'Valid_Centrocostosusralta',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSUSRALTA",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSUSRMOD","{handler:'Valid_Centrocostosusrmod',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSUSRMOD",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSESTADO","{handler:'Valid_Centrocostosestado',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSESTADO",",oparms:[]}");
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
         AV66Pgmname = "";
         AV24TFCentroCostosTipoRef_Sels = new GxSimpleCollection<string>();
         AV27TFCentroCostosNombre = "";
         AV28TFCentroCostosNombre_Sel = "";
         AV37TFCentroCostosUsrAlta = "";
         AV38TFCentroCostosUsrAlta_Sel = "";
         AV39TFCentroCostosUsrMod = "";
         AV40TFCentroCostosUsrMod_Sel = "";
         AV41TFCentroCostosHoraAlt = DateTime.MinValue;
         AV42TFCentroCostosHoraAlt_To = DateTime.MinValue;
         AV46TFCentroCostosHoraMod = DateTime.MinValue;
         AV47TFCentroCostosHoraMod_To = DateTime.MinValue;
         AV52TFCentroCostosEstado_Sels = new GxSimpleCollection<string>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV18ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV58GridAppliedFilters = "";
         AV53DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV44DDO_CentroCostosHoraAltAuxDateTo = DateTime.MinValue;
         AV49DDO_CentroCostosHoraModAuxDateTo = DateTime.MinValue;
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23TFCentroCostosTipoRef_SelsJson = "";
         AV51TFCentroCostosEstado_SelsJson = "";
         AV43DDO_CentroCostosHoraAltAuxDate = DateTime.MinValue;
         AV48DDO_CentroCostosHoraModAuxDate = DateTime.MinValue;
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
         AV45DDO_CentroCostosHoraAltAuxDateText = "";
         ucTfcentrocostoshoraalt_rangepicker = new GXUserControl();
         AV50DDO_CentroCostosHoraModAuxDateText = "";
         ucTfcentrocostoshoramod_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A487CentroCostosTipoRef = "";
         A463CentroCostosNombre = "";
         A478CentroCostosUsrAlta = "";
         A479CentroCostosUsrMod = "";
         A480CentroCostosHoraAlt = DateTime.MinValue;
         A481CentroCostosHoraMod = DateTime.MinValue;
         A482CentroCostosEstado = "";
         GXDecQS = "";
         lV27TFCentroCostosNombre = "";
         lV37TFCentroCostosUsrAlta = "";
         lV39TFCentroCostosUsrMod = "";
         H003Z3_A466CentroCostosDetallesId = new long[1] ;
         H003Z3_A459ListaCostosId = new long[1] ;
         H003Z3_n459ListaCostosId = new bool[] {false} ;
         H003Z3_A482CentroCostosEstado = new string[] {""} ;
         H003Z3_A481CentroCostosHoraMod = new DateTime[] {DateTime.MinValue} ;
         H003Z3_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         H003Z3_A479CentroCostosUsrMod = new string[] {""} ;
         H003Z3_A478CentroCostosUsrAlta = new string[] {""} ;
         H003Z3_A474CentroCostosGam = new decimal[1] ;
         H003Z3_A465CentroCostosSerial = new long[1] ;
         H003Z3_A463CentroCostosNombre = new string[] {""} ;
         H003Z3_A462CentroCostosRef = new long[1] ;
         H003Z3_A487CentroCostosTipoRef = new string[] {""} ;
         H003Z3_A461CentroCostosId = new long[1] ;
         H003Z3_A464CentroCostosPrecioFinal = new decimal[1] ;
         H003Z3_A475CentroCostosCosto = new decimal[1] ;
         H003Z3_A469CentroCostosSubTotal = new decimal[1] ;
         H003Z3_n469CentroCostosSubTotal = new bool[] {false} ;
         H003Z5_A466CentroCostosDetallesId = new long[1] ;
         H003Z5_A459ListaCostosId = new long[1] ;
         H003Z5_n459ListaCostosId = new bool[] {false} ;
         H003Z5_A482CentroCostosEstado = new string[] {""} ;
         H003Z5_A481CentroCostosHoraMod = new DateTime[] {DateTime.MinValue} ;
         H003Z5_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         H003Z5_A479CentroCostosUsrMod = new string[] {""} ;
         H003Z5_A478CentroCostosUsrAlta = new string[] {""} ;
         H003Z5_A474CentroCostosGam = new decimal[1] ;
         H003Z5_A465CentroCostosSerial = new long[1] ;
         H003Z5_A463CentroCostosNombre = new string[] {""} ;
         H003Z5_A462CentroCostosRef = new long[1] ;
         H003Z5_A487CentroCostosTipoRef = new string[] {""} ;
         H003Z5_A461CentroCostosId = new long[1] ;
         H003Z5_A464CentroCostosPrecioFinal = new decimal[1] ;
         H003Z5_A475CentroCostosCosto = new decimal[1] ;
         H003Z5_A469CentroCostosSubTotal = new decimal[1] ;
         H003Z5_n469CentroCostosSubTotal = new bool[] {false} ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV19ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV17Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char5 = "";
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
         sCtrlAV8ListaCostosId = "";
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listacostosdetalles1wc__default(),
            new Object[][] {
                new Object[] {
               H003Z3_A466CentroCostosDetallesId, H003Z3_A459ListaCostosId, H003Z3_n459ListaCostosId, H003Z3_A482CentroCostosEstado, H003Z3_A481CentroCostosHoraMod, H003Z3_A480CentroCostosHoraAlt, H003Z3_A479CentroCostosUsrMod, H003Z3_A478CentroCostosUsrAlta, H003Z3_A474CentroCostosGam, H003Z3_A465CentroCostosSerial,
               H003Z3_A463CentroCostosNombre, H003Z3_A462CentroCostosRef, H003Z3_A487CentroCostosTipoRef, H003Z3_A461CentroCostosId, H003Z3_A464CentroCostosPrecioFinal, H003Z3_A475CentroCostosCosto, H003Z3_A469CentroCostosSubTotal, H003Z3_n469CentroCostosSubTotal
               }
               , new Object[] {
               H003Z5_A466CentroCostosDetallesId, H003Z5_A459ListaCostosId, H003Z5_n459ListaCostosId, H003Z5_A482CentroCostosEstado, H003Z5_A481CentroCostosHoraMod, H003Z5_A480CentroCostosHoraAlt, H003Z5_A479CentroCostosUsrMod, H003Z5_A478CentroCostosUsrAlta, H003Z5_A474CentroCostosGam, H003Z5_A465CentroCostosSerial,
               H003Z5_A463CentroCostosNombre, H003Z5_A462CentroCostosRef, H003Z5_A487CentroCostosTipoRef, H003Z5_A461CentroCostosId, H003Z5_A464CentroCostosPrecioFinal, H003Z5_A475CentroCostosCosto, H003Z5_A469CentroCostosSubTotal, H003Z5_n469CentroCostosSubTotal
               }
            }
         );
         AV66Pgmname = "ListaCostosDetalles1WC";
         /* GeneXus formulas. */
         AV66Pgmname = "ListaCostosDetalles1WC";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14OrderedBy ;
      private short AV20ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV59GridActions ;
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
      private int edtListaCostosId_Visible ;
      private int subGrid_Islastpage ;
      private int AV24TFCentroCostosTipoRef_Sels_Count ;
      private int AV52TFCentroCostosEstado_Sels_Count ;
      private int edtCentroCostosId_Enabled ;
      private int edtCentroCostosRef_Enabled ;
      private int edtCentroCostosNombre_Enabled ;
      private int edtCentroCostosPrecioFinal_Enabled ;
      private int edtCentroCostosSerial_Enabled ;
      private int edtCentroCostosSubTotal_Enabled ;
      private int edtCentroCostosCosto_Enabled ;
      private int edtCentroCostosGam_Enabled ;
      private int edtCentroCostosUsrAlta_Enabled ;
      private int edtCentroCostosUsrMod_Enabled ;
      private int edtCentroCostosHoraAlt_Enabled ;
      private int edtCentroCostosHoraMod_Enabled ;
      private int edtListaCostosId_Enabled ;
      private int AV55PageToGo ;
      private int AV67GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8ListaCostosId ;
      private long wcpOAV8ListaCostosId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV21TFCentroCostosId ;
      private long AV22TFCentroCostosId_To ;
      private long AV25TFCentroCostosRef ;
      private long AV26TFCentroCostosRef_To ;
      private long AV65CentroCostosRef ;
      private long AV56GridCurrentPage ;
      private long AV57GridPageCount ;
      private long A459ListaCostosId ;
      private long A461CentroCostosId ;
      private long A462CentroCostosRef ;
      private long A465CentroCostosSerial ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV29TFCentroCostosPrecioFinal ;
      private decimal AV30TFCentroCostosPrecioFinal_To ;
      private decimal AV31TFCentroCostosSubTotal ;
      private decimal AV32TFCentroCostosSubTotal_To ;
      private decimal AV33TFCentroCostosCosto ;
      private decimal AV34TFCentroCostosCosto_To ;
      private decimal AV35TFCentroCostosGam ;
      private decimal AV36TFCentroCostosGam_To ;
      private decimal A464CentroCostosPrecioFinal ;
      private decimal A469CentroCostosSubTotal ;
      private decimal A475CentroCostosCosto ;
      private decimal A474CentroCostosGam ;
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
      private string AV66Pgmname ;
      private string AV27TFCentroCostosNombre ;
      private string AV28TFCentroCostosNombre_Sel ;
      private string AV37TFCentroCostosUsrAlta ;
      private string AV38TFCentroCostosUsrAlta_Sel ;
      private string AV39TFCentroCostosUsrMod ;
      private string AV40TFCentroCostosUsrMod_Sel ;
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
      private string edtListaCostosId_Internalname ;
      private string edtListaCostosId_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_centrocostoshoraaltauxdates_Internalname ;
      private string edtavDdo_centrocostoshoraaltauxdatetext_Internalname ;
      private string edtavDdo_centrocostoshoraaltauxdatetext_Jsonclick ;
      private string Tfcentrocostoshoraalt_rangepicker_Internalname ;
      private string divDdo_centrocostoshoramodauxdates_Internalname ;
      private string edtavDdo_centrocostoshoramodauxdatetext_Internalname ;
      private string edtavDdo_centrocostoshoramodauxdatetext_Jsonclick ;
      private string Tfcentrocostoshoramod_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtCentroCostosId_Internalname ;
      private string cmbCentroCostosTipoRef_Internalname ;
      private string A487CentroCostosTipoRef ;
      private string edtCentroCostosRef_Internalname ;
      private string A463CentroCostosNombre ;
      private string edtCentroCostosNombre_Internalname ;
      private string edtCentroCostosPrecioFinal_Internalname ;
      private string edtCentroCostosSerial_Internalname ;
      private string edtCentroCostosSubTotal_Internalname ;
      private string edtCentroCostosCosto_Internalname ;
      private string edtCentroCostosGam_Internalname ;
      private string A478CentroCostosUsrAlta ;
      private string edtCentroCostosUsrAlta_Internalname ;
      private string A479CentroCostosUsrMod ;
      private string edtCentroCostosUsrMod_Internalname ;
      private string edtCentroCostosHoraAlt_Internalname ;
      private string edtCentroCostosHoraMod_Internalname ;
      private string cmbCentroCostosEstado_Internalname ;
      private string A482CentroCostosEstado ;
      private string GXDecQS ;
      private string edtavFilterfulltext_Internalname ;
      private string lV27TFCentroCostosNombre ;
      private string lV37TFCentroCostosUsrAlta ;
      private string lV39TFCentroCostosUsrMod ;
      private string edtCentroCostosNombre_Link ;
      private string GXt_char3 ;
      private string GXt_char5 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sCtrlAV8ListaCostosId ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtCentroCostosId_Jsonclick ;
      private string cmbCentroCostosTipoRef_Jsonclick ;
      private string edtCentroCostosRef_Jsonclick ;
      private string edtCentroCostosNombre_Jsonclick ;
      private string edtCentroCostosPrecioFinal_Jsonclick ;
      private string edtCentroCostosSerial_Jsonclick ;
      private string edtCentroCostosSubTotal_Jsonclick ;
      private string edtCentroCostosCosto_Jsonclick ;
      private string edtCentroCostosGam_Jsonclick ;
      private string edtCentroCostosUsrAlta_Jsonclick ;
      private string edtCentroCostosUsrMod_Jsonclick ;
      private string edtCentroCostosHoraAlt_Jsonclick ;
      private string edtCentroCostosHoraMod_Jsonclick ;
      private string cmbCentroCostosEstado_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV41TFCentroCostosHoraAlt ;
      private DateTime AV42TFCentroCostosHoraAlt_To ;
      private DateTime AV46TFCentroCostosHoraMod ;
      private DateTime AV47TFCentroCostosHoraMod_To ;
      private DateTime AV44DDO_CentroCostosHoraAltAuxDateTo ;
      private DateTime AV49DDO_CentroCostosHoraModAuxDateTo ;
      private DateTime AV43DDO_CentroCostosHoraAltAuxDate ;
      private DateTime AV48DDO_CentroCostosHoraModAuxDate ;
      private DateTime A480CentroCostosHoraAlt ;
      private DateTime A481CentroCostosHoraMod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV61IsAuthorized_Update ;
      private bool AV62IsAuthorized_Delete ;
      private bool AV63IsAuthorized_CentroCostosNombre ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n469CentroCostosSubTotal ;
      private bool n459ListaCostosId ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV64TempBoolean ;
      private bool GXt_boolean1 ;
      private string AV23TFCentroCostosTipoRef_SelsJson ;
      private string AV51TFCentroCostosEstado_SelsJson ;
      private string AV19ManageFiltersXml ;
      private string AV16FilterFullText ;
      private string AV58GridAppliedFilters ;
      private string AV45DDO_CentroCostosHoraAltAuxDateText ;
      private string AV50DDO_CentroCostosHoraModAuxDateText ;
      private IGxSession AV17Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfcentrocostoshoraalt_rangepicker ;
      private GXUserControl ucTfcentrocostoshoramod_rangepicker ;
      private GXUserControl ucDdo_managefilters ;
      private GXWebForm Form ;
      private GxHttpRequest AV9HTTPRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbCentroCostosTipoRef ;
      private GXCombobox cmbCentroCostosEstado ;
      private GxSimpleCollection<string> AV24TFCentroCostosTipoRef_Sels ;
      private GxSimpleCollection<string> AV52TFCentroCostosEstado_Sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV18ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV53DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private IDataStoreProvider pr_default ;
      private long[] H003Z3_A466CentroCostosDetallesId ;
      private long[] H003Z3_A459ListaCostosId ;
      private bool[] H003Z3_n459ListaCostosId ;
      private string[] H003Z3_A482CentroCostosEstado ;
      private DateTime[] H003Z3_A481CentroCostosHoraMod ;
      private DateTime[] H003Z3_A480CentroCostosHoraAlt ;
      private string[] H003Z3_A479CentroCostosUsrMod ;
      private string[] H003Z3_A478CentroCostosUsrAlta ;
      private decimal[] H003Z3_A474CentroCostosGam ;
      private long[] H003Z3_A465CentroCostosSerial ;
      private string[] H003Z3_A463CentroCostosNombre ;
      private long[] H003Z3_A462CentroCostosRef ;
      private string[] H003Z3_A487CentroCostosTipoRef ;
      private long[] H003Z3_A461CentroCostosId ;
      private decimal[] H003Z3_A464CentroCostosPrecioFinal ;
      private decimal[] H003Z3_A475CentroCostosCosto ;
      private decimal[] H003Z3_A469CentroCostosSubTotal ;
      private bool[] H003Z3_n469CentroCostosSubTotal ;
      private long[] H003Z5_A466CentroCostosDetallesId ;
      private long[] H003Z5_A459ListaCostosId ;
      private bool[] H003Z5_n459ListaCostosId ;
      private string[] H003Z5_A482CentroCostosEstado ;
      private DateTime[] H003Z5_A481CentroCostosHoraMod ;
      private DateTime[] H003Z5_A480CentroCostosHoraAlt ;
      private string[] H003Z5_A479CentroCostosUsrMod ;
      private string[] H003Z5_A478CentroCostosUsrAlta ;
      private decimal[] H003Z5_A474CentroCostosGam ;
      private long[] H003Z5_A465CentroCostosSerial ;
      private string[] H003Z5_A463CentroCostosNombre ;
      private long[] H003Z5_A462CentroCostosRef ;
      private string[] H003Z5_A487CentroCostosTipoRef ;
      private long[] H003Z5_A461CentroCostosId ;
      private decimal[] H003Z5_A464CentroCostosPrecioFinal ;
      private decimal[] H003Z5_A475CentroCostosCosto ;
      private decimal[] H003Z5_A469CentroCostosSubTotal ;
      private bool[] H003Z5_n469CentroCostosSubTotal ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class listacostosdetalles1wc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003Z3( IGxContext context ,
                                             string A487CentroCostosTipoRef ,
                                             GxSimpleCollection<string> AV24TFCentroCostosTipoRef_Sels ,
                                             string A482CentroCostosEstado ,
                                             GxSimpleCollection<string> AV52TFCentroCostosEstado_Sels ,
                                             long AV21TFCentroCostosId ,
                                             long AV22TFCentroCostosId_To ,
                                             int AV24TFCentroCostosTipoRef_Sels_Count ,
                                             long AV25TFCentroCostosRef ,
                                             long AV26TFCentroCostosRef_To ,
                                             string AV28TFCentroCostosNombre_Sel ,
                                             string AV27TFCentroCostosNombre ,
                                             decimal AV29TFCentroCostosPrecioFinal ,
                                             decimal AV30TFCentroCostosPrecioFinal_To ,
                                             decimal AV31TFCentroCostosSubTotal ,
                                             decimal AV32TFCentroCostosSubTotal_To ,
                                             decimal AV33TFCentroCostosCosto ,
                                             decimal AV34TFCentroCostosCosto_To ,
                                             decimal AV35TFCentroCostosGam ,
                                             decimal AV36TFCentroCostosGam_To ,
                                             string AV38TFCentroCostosUsrAlta_Sel ,
                                             string AV37TFCentroCostosUsrAlta ,
                                             string AV40TFCentroCostosUsrMod_Sel ,
                                             string AV39TFCentroCostosUsrMod ,
                                             DateTime AV41TFCentroCostosHoraAlt ,
                                             DateTime AV42TFCentroCostosHoraAlt_To ,
                                             DateTime AV46TFCentroCostosHoraMod ,
                                             DateTime AV47TFCentroCostosHoraMod_To ,
                                             int AV52TFCentroCostosEstado_Sels_Count ,
                                             long A461CentroCostosId ,
                                             long A462CentroCostosRef ,
                                             string A463CentroCostosNombre ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             decimal A469CentroCostosSubTotal ,
                                             decimal A475CentroCostosCosto ,
                                             string A478CentroCostosUsrAlta ,
                                             string A479CentroCostosUsrMod ,
                                             DateTime A480CentroCostosHoraAlt ,
                                             DateTime A481CentroCostosHoraMod ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV16FilterFullText ,
                                             decimal A474CentroCostosGam ,
                                             long AV8ListaCostosId ,
                                             long A459ListaCostosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[23];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.[CentroCostosDetallesId], T1.[ListaCostosId], T2.[CentroCostosEstado], T2.[CentroCostosHoraMod], T2.[CentroCostosHoraAlt], T2.[CentroCostosUsrMod], T2.[CentroCostosUsrAlta], T2.[CentroCostosPrecioFinal] - T2.[CentroCostosCosto] AS CentroCostosGam, T2.[CentroCostosSerial], T2.[CentroCostosNombre], T2.[CentroCostosRef], T2.[CentroCostosTipoRef], T1.[CentroCostosId], T2.[CentroCostosPrecioFinal], T2.[CentroCostosCosto], COALESCE( T3.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal FROM (([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId]) LEFT JOIN (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T3 ON T3.[CentroCostosId] = T1.[CentroCostosId])";
         AddWhere(sWhereString, "(T1.[ListaCostosId] = @AV8ListaCostosId)");
         if ( ! (0==AV21TFCentroCostosId) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] >= @AV21TFCentroCostosId)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ! (0==AV22TFCentroCostosId_To) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] <= @AV22TFCentroCostosId_To)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( AV24TFCentroCostosTipoRef_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV24TFCentroCostosTipoRef_Sels, "T2.[CentroCostosTipoRef] IN (", ")")+")");
         }
         if ( ! (0==AV25TFCentroCostosRef) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] >= @AV25TFCentroCostosRef)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! (0==AV26TFCentroCostosRef_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] <= @AV26TFCentroCostosRef_To)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCentroCostosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFCentroCostosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosNombre]) like UPPER(@lV27TFCentroCostosNombre))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCentroCostosNombre_Sel)) && ! ( StringUtil.StrCmp(AV28TFCentroCostosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosNombre] = @AV28TFCentroCostosNombre_Sel)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFCentroCostosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV29TFCentroCostosPrecioFinal) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] >= @AV29TFCentroCostosPrecioFinal)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV30TFCentroCostosPrecioFinal_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] <= @AV30TFCentroCostosPrecioFinal_To)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV31TFCentroCostosSubTotal) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.[CentroCostosSubTotal], 0) >= @AV31TFCentroCostosSubTotal)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV32TFCentroCostosSubTotal_To) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.[CentroCostosSubTotal], 0) <= @AV32TFCentroCostosSubTotal_To)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV33TFCentroCostosCosto) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] >= @AV33TFCentroCostosCosto)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV34TFCentroCostosCosto_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] <= @AV34TFCentroCostosCosto_To)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV35TFCentroCostosGam) )
         {
            AddWhere(sWhereString, "(( T2.[CentroCostosPrecioFinal] - T2.[CentroCostosCosto]) >= @AV35TFCentroCostosGam)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV36TFCentroCostosGam_To) )
         {
            AddWhere(sWhereString, "(( T2.[CentroCostosPrecioFinal] - T2.[CentroCostosCosto]) <= @AV36TFCentroCostosGam_To)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCentroCostosUsrAlta_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCentroCostosUsrAlta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosUsrAlta]) like UPPER(@lV37TFCentroCostosUsrAlta))");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCentroCostosUsrAlta_Sel)) && ! ( StringUtil.StrCmp(AV38TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosUsrAlta] = @AV38TFCentroCostosUsrAlta_Sel)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( StringUtil.StrCmp(AV38TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosUsrAlta] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCentroCostosUsrMod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCentroCostosUsrMod)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosUsrMod]) like UPPER(@lV39TFCentroCostosUsrMod))");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCentroCostosUsrMod_Sel)) && ! ( StringUtil.StrCmp(AV40TFCentroCostosUsrMod_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosUsrMod] = @AV40TFCentroCostosUsrMod_Sel)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( StringUtil.StrCmp(AV40TFCentroCostosUsrMod_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosUsrMod] = ''))");
         }
         if ( ! (DateTime.MinValue==AV41TFCentroCostosHoraAlt) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] >= @AV41TFCentroCostosHoraAlt)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV42TFCentroCostosHoraAlt_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] <= @AV42TFCentroCostosHoraAlt_To)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV46TFCentroCostosHoraMod) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraMod] >= @AV46TFCentroCostosHoraMod)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV47TFCentroCostosHoraMod_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraMod] <= @AV47TFCentroCostosHoraMod_To)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( AV52TFCentroCostosEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV52TFCentroCostosEstado_Sels, "T2.[CentroCostosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T1.[CentroCostosId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T1.[CentroCostosId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosTipoRef]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosTipoRef] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosRef]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosRef] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosPrecioFinal]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosPrecioFinal] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosCosto]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosCosto] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosUsrAlta]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosUsrAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosUsrMod]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosUsrMod] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosHoraAlt]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosHoraAlt] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosHoraMod]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosHoraMod] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosEstado]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosEstado] DESC";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H003Z5( IGxContext context ,
                                             string A487CentroCostosTipoRef ,
                                             GxSimpleCollection<string> AV24TFCentroCostosTipoRef_Sels ,
                                             string A482CentroCostosEstado ,
                                             GxSimpleCollection<string> AV52TFCentroCostosEstado_Sels ,
                                             long AV21TFCentroCostosId ,
                                             long AV22TFCentroCostosId_To ,
                                             int AV24TFCentroCostosTipoRef_Sels_Count ,
                                             long AV25TFCentroCostosRef ,
                                             long AV26TFCentroCostosRef_To ,
                                             string AV28TFCentroCostosNombre_Sel ,
                                             string AV27TFCentroCostosNombre ,
                                             decimal AV29TFCentroCostosPrecioFinal ,
                                             decimal AV30TFCentroCostosPrecioFinal_To ,
                                             decimal AV31TFCentroCostosSubTotal ,
                                             decimal AV32TFCentroCostosSubTotal_To ,
                                             decimal AV33TFCentroCostosCosto ,
                                             decimal AV34TFCentroCostosCosto_To ,
                                             decimal AV35TFCentroCostosGam ,
                                             decimal AV36TFCentroCostosGam_To ,
                                             string AV38TFCentroCostosUsrAlta_Sel ,
                                             string AV37TFCentroCostosUsrAlta ,
                                             string AV40TFCentroCostosUsrMod_Sel ,
                                             string AV39TFCentroCostosUsrMod ,
                                             DateTime AV41TFCentroCostosHoraAlt ,
                                             DateTime AV42TFCentroCostosHoraAlt_To ,
                                             DateTime AV46TFCentroCostosHoraMod ,
                                             DateTime AV47TFCentroCostosHoraMod_To ,
                                             int AV52TFCentroCostosEstado_Sels_Count ,
                                             long A461CentroCostosId ,
                                             long A462CentroCostosRef ,
                                             string A463CentroCostosNombre ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             decimal A469CentroCostosSubTotal ,
                                             decimal A475CentroCostosCosto ,
                                             string A478CentroCostosUsrAlta ,
                                             string A479CentroCostosUsrMod ,
                                             DateTime A480CentroCostosHoraAlt ,
                                             DateTime A481CentroCostosHoraMod ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV16FilterFullText ,
                                             decimal A474CentroCostosGam ,
                                             long AV8ListaCostosId ,
                                             long A459ListaCostosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[23];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.[CentroCostosDetallesId], T1.[ListaCostosId], T2.[CentroCostosEstado], T2.[CentroCostosHoraMod], T2.[CentroCostosHoraAlt], T2.[CentroCostosUsrMod], T2.[CentroCostosUsrAlta], T2.[CentroCostosPrecioFinal] - T2.[CentroCostosCosto] AS CentroCostosGam, T2.[CentroCostosSerial], T2.[CentroCostosNombre], T2.[CentroCostosRef], T2.[CentroCostosTipoRef], T1.[CentroCostosId], T2.[CentroCostosPrecioFinal], T2.[CentroCostosCosto], COALESCE( T3.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal FROM (([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId]) LEFT JOIN (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T3 ON T3.[CentroCostosId] = T1.[CentroCostosId])";
         AddWhere(sWhereString, "(T1.[ListaCostosId] = @AV8ListaCostosId)");
         if ( ! (0==AV21TFCentroCostosId) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] >= @AV21TFCentroCostosId)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( ! (0==AV22TFCentroCostosId_To) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] <= @AV22TFCentroCostosId_To)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( AV24TFCentroCostosTipoRef_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV24TFCentroCostosTipoRef_Sels, "T2.[CentroCostosTipoRef] IN (", ")")+")");
         }
         if ( ! (0==AV25TFCentroCostosRef) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] >= @AV25TFCentroCostosRef)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ! (0==AV26TFCentroCostosRef_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] <= @AV26TFCentroCostosRef_To)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCentroCostosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFCentroCostosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosNombre]) like UPPER(@lV27TFCentroCostosNombre))");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCentroCostosNombre_Sel)) && ! ( StringUtil.StrCmp(AV28TFCentroCostosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosNombre] = @AV28TFCentroCostosNombre_Sel)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFCentroCostosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV29TFCentroCostosPrecioFinal) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] >= @AV29TFCentroCostosPrecioFinal)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV30TFCentroCostosPrecioFinal_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] <= @AV30TFCentroCostosPrecioFinal_To)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV31TFCentroCostosSubTotal) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.[CentroCostosSubTotal], 0) >= @AV31TFCentroCostosSubTotal)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV32TFCentroCostosSubTotal_To) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.[CentroCostosSubTotal], 0) <= @AV32TFCentroCostosSubTotal_To)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV33TFCentroCostosCosto) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] >= @AV33TFCentroCostosCosto)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV34TFCentroCostosCosto_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] <= @AV34TFCentroCostosCosto_To)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV35TFCentroCostosGam) )
         {
            AddWhere(sWhereString, "(( T2.[CentroCostosPrecioFinal] - T2.[CentroCostosCosto]) >= @AV35TFCentroCostosGam)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV36TFCentroCostosGam_To) )
         {
            AddWhere(sWhereString, "(( T2.[CentroCostosPrecioFinal] - T2.[CentroCostosCosto]) <= @AV36TFCentroCostosGam_To)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCentroCostosUsrAlta_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCentroCostosUsrAlta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosUsrAlta]) like UPPER(@lV37TFCentroCostosUsrAlta))");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCentroCostosUsrAlta_Sel)) && ! ( StringUtil.StrCmp(AV38TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosUsrAlta] = @AV38TFCentroCostosUsrAlta_Sel)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( StringUtil.StrCmp(AV38TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosUsrAlta] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCentroCostosUsrMod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCentroCostosUsrMod)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosUsrMod]) like UPPER(@lV39TFCentroCostosUsrMod))");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCentroCostosUsrMod_Sel)) && ! ( StringUtil.StrCmp(AV40TFCentroCostosUsrMod_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosUsrMod] = @AV40TFCentroCostosUsrMod_Sel)");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( StringUtil.StrCmp(AV40TFCentroCostosUsrMod_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosUsrMod] = ''))");
         }
         if ( ! (DateTime.MinValue==AV41TFCentroCostosHoraAlt) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] >= @AV41TFCentroCostosHoraAlt)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV42TFCentroCostosHoraAlt_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] <= @AV42TFCentroCostosHoraAlt_To)");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV46TFCentroCostosHoraMod) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraMod] >= @AV46TFCentroCostosHoraMod)");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV47TFCentroCostosHoraMod_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraMod] <= @AV47TFCentroCostosHoraMod_To)");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( AV52TFCentroCostosEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV52TFCentroCostosEstado_Sels, "T2.[CentroCostosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T1.[CentroCostosId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T1.[CentroCostosId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosTipoRef]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosTipoRef] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosRef]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosRef] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosPrecioFinal]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosPrecioFinal] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosCosto]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosCosto] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosUsrAlta]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosUsrAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosUsrMod]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosUsrMod] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosHoraAlt]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosHoraAlt] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosHoraMod]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosHoraMod] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosEstado]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosEstado] DESC";
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
                     return conditional_H003Z3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (int)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (int)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] , (string)dynConstraints[40] , (decimal)dynConstraints[41] , (long)dynConstraints[42] , (long)dynConstraints[43] );
               case 1 :
                     return conditional_H003Z5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (int)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (int)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] , (string)dynConstraints[40] , (decimal)dynConstraints[41] , (long)dynConstraints[42] , (long)dynConstraints[43] );
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
          Object[] prmH003Z3;
          prmH003Z3 = new Object[] {
          new ParDef("@AV8ListaCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV21TFCentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFCentroCostosId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV25TFCentroCostosRef",GXType.Decimal,18,0) ,
          new ParDef("@AV26TFCentroCostosRef_To",GXType.Decimal,18,0) ,
          new ParDef("@lV27TFCentroCostosNombre",GXType.Char,80,0) ,
          new ParDef("@AV28TFCentroCostosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV29TFCentroCostosPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV30TFCentroCostosPrecioFinal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV31TFCentroCostosSubTotal",GXType.Decimal,18,2) ,
          new ParDef("@AV32TFCentroCostosSubTotal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV33TFCentroCostosCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV34TFCentroCostosCosto_To",GXType.Decimal,18,2) ,
          new ParDef("@AV35TFCentroCostosGam",GXType.Decimal,18,2) ,
          new ParDef("@AV36TFCentroCostosGam_To",GXType.Decimal,18,2) ,
          new ParDef("@lV37TFCentroCostosUsrAlta",GXType.Char,30,0) ,
          new ParDef("@AV38TFCentroCostosUsrAlta_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV39TFCentroCostosUsrMod",GXType.Char,30,0) ,
          new ParDef("@AV40TFCentroCostosUsrMod_Sel",GXType.NChar,30,0) ,
          new ParDef("@AV41TFCentroCostosHoraAlt",GXType.Date,8,0) ,
          new ParDef("@AV42TFCentroCostosHoraAlt_To",GXType.Date,8,0) ,
          new ParDef("@AV46TFCentroCostosHoraMod",GXType.Date,8,0) ,
          new ParDef("@AV47TFCentroCostosHoraMod_To",GXType.Date,8,0)
          };
          Object[] prmH003Z5;
          prmH003Z5 = new Object[] {
          new ParDef("@AV8ListaCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV21TFCentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFCentroCostosId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV25TFCentroCostosRef",GXType.Decimal,18,0) ,
          new ParDef("@AV26TFCentroCostosRef_To",GXType.Decimal,18,0) ,
          new ParDef("@lV27TFCentroCostosNombre",GXType.Char,80,0) ,
          new ParDef("@AV28TFCentroCostosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV29TFCentroCostosPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV30TFCentroCostosPrecioFinal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV31TFCentroCostosSubTotal",GXType.Decimal,18,2) ,
          new ParDef("@AV32TFCentroCostosSubTotal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV33TFCentroCostosCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV34TFCentroCostosCosto_To",GXType.Decimal,18,2) ,
          new ParDef("@AV35TFCentroCostosGam",GXType.Decimal,18,2) ,
          new ParDef("@AV36TFCentroCostosGam_To",GXType.Decimal,18,2) ,
          new ParDef("@lV37TFCentroCostosUsrAlta",GXType.Char,30,0) ,
          new ParDef("@AV38TFCentroCostosUsrAlta_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV39TFCentroCostosUsrMod",GXType.Char,30,0) ,
          new ParDef("@AV40TFCentroCostosUsrMod_Sel",GXType.NChar,30,0) ,
          new ParDef("@AV41TFCentroCostosHoraAlt",GXType.Date,8,0) ,
          new ParDef("@AV42TFCentroCostosHoraAlt_To",GXType.Date,8,0) ,
          new ParDef("@AV46TFCentroCostosHoraMod",GXType.Date,8,0) ,
          new ParDef("@AV47TFCentroCostosHoraMod_To",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003Z3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Z3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003Z5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Z5,11, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((string[]) buf[7])[0] = rslt.getString(7, 30);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 80);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                ((string[]) buf[12])[0] = rslt.getString(12, 1);
                ((long[]) buf[13])[0] = rslt.getLong(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
                ((bool[]) buf[17])[0] = rslt.wasNull(16);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((string[]) buf[7])[0] = rslt.getString(7, 30);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 80);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                ((string[]) buf[12])[0] = rslt.getString(12, 1);
                ((long[]) buf[13])[0] = rslt.getLong(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
                ((bool[]) buf[17])[0] = rslt.wasNull(16);
                return;
       }
    }

 }

}
