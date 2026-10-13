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
   public class textoslistawc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public textoslistawc( )
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

      public textoslistawc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_InventarioTextosId )
      {
         this.AV8InventarioTextosId = aP0_InventarioTextosId;
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
         cmbMedidasEstado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "InventarioTextosId");
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
                  AV8InventarioTextosId = (long)(Math.Round(NumberUtil.Val( GetPar( "InventarioTextosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8InventarioTextosId", StringUtil.LTrimStr( (decimal)(AV8InventarioTextosId), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV8InventarioTextosId});
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
                  gxfirstwebparm = GetFirstPar( "InventarioTextosId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "InventarioTextosId");
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
         AV8InventarioTextosId = (long)(Math.Round(NumberUtil.Val( GetPar( "InventarioTextosId"), "."), 18, MidpointRounding.ToEven));
         AV20ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV46Pgmname = GetPar( "Pgmname");
         AV21TFRubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "TFRubrosId"), "."), 18, MidpointRounding.ToEven));
         AV22TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFRubrosId_To"), "."), 18, MidpointRounding.ToEven));
         AV23TFRubrosNombre = GetPar( "TFRubrosNombre");
         AV24TFRubrosNombre_Sel = GetPar( "TFRubrosNombre_Sel");
         AV25TFMedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFMedidasID"), "."), 18, MidpointRounding.ToEven));
         AV26TFMedidasID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFMedidasID_To"), "."), 18, MidpointRounding.ToEven));
         AV27TFMedidasNombre = GetPar( "TFMedidasNombre");
         AV28TFMedidasNombre_Sel = GetPar( "TFMedidasNombre_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV30TFMedidasEstado_Sels);
         AV31TFTextosId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFTextosId"), "."), 18, MidpointRounding.ToEven));
         AV32TFTextosId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFTextosId_To"), "."), 18, MidpointRounding.ToEven));
         AV33TFTextosTitulo = GetPar( "TFTextosTitulo");
         AV34TFTextosTitulo_Sel = GetPar( "TFTextosTitulo_Sel");
         AV42IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV43IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV44IsAuthorized_RubrosNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_RubrosNombre"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8InventarioTextosId, AV20ManageFiltersExecutionStep, AV46Pgmname, AV21TFRubrosId, AV22TFRubrosId_To, AV23TFRubrosNombre, AV24TFRubrosNombre_Sel, AV25TFMedidasID, AV26TFMedidasID_To, AV27TFMedidasNombre, AV28TFMedidasNombre_Sel, AV30TFMedidasEstado_Sels, AV31TFTextosId, AV32TFTextosId_To, AV33TFTextosTitulo, AV34TFTextosTitulo_Sel, AV42IsAuthorized_Update, AV43IsAuthorized_Delete, AV44IsAuthorized_RubrosNombre, sPrefix) ;
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
            PA2W2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV46Pgmname = "TextoslistaWC";
               WS2W2( ) ;
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
            context.SendWebValue( context.GetMessage( "Textoslista WC", "")) ;
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
            GXEncryptionTmp = "textoslistawc.aspx"+UrlEncode(StringUtil.LTrimStr(AV8InventarioTextosId,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("textoslistawc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV46Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV42IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV42IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV43IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV43IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_RUBROSNOMBRE", AV44IsAuthorized_RubrosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_RUBROSNOMBRE", GetSecureSignedToken( sPrefix, AV44IsAuthorized_RubrosNombre, context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV40GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV35DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV35DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8InventarioTextosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8InventarioTextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV46Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21TFRubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFRUBROSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22TFRubrosId_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFRUBROSNOMBRE", StringUtil.RTrim( AV23TFRubrosNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFRUBROSNOMBRE_SEL", StringUtil.RTrim( AV24TFRubrosNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMEDIDASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25TFMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMEDIDASID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26TFMedidasID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMEDIDASNOMBRE", StringUtil.RTrim( AV27TFMedidasNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMEDIDASNOMBRE_SEL", StringUtil.RTrim( AV28TFMedidasNombre_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFMEDIDASESTADO_SELS", AV30TFMedidasEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFMEDIDASESTADO_SELS", AV30TFMedidasEstado_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTEXTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TFTextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTEXTOSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TFTextosId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTEXTOSTITULO", StringUtil.RTrim( AV33TFTextosTitulo));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFTEXTOSTITULO_SEL", StringUtil.RTrim( AV34TFTextosTitulo_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINVENTARIOTEXTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8InventarioTextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV42IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV42IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV43IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV43IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_RUBROSNOMBRE", AV44IsAuthorized_RubrosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_RUBROSNOMBRE", GetSecureSignedToken( sPrefix, AV44IsAuthorized_RubrosNombre, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV12GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV12GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMEDIDASESTADO_SELSJSON", AV29TFMedidasEstado_SelsJson);
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

      protected void RenderHtmlCloseForm2W2( )
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
         return "TextoslistaWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Textoslista WC", "") ;
      }

      protected void WB2W0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "textoslistawc.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_TextoslistaWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_22_2W2( true) ;
         }
         else
         {
            wb_table1_22_2W2( false) ;
         }
         return  ;
      }

      protected void wb_table1_22_2W2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV38GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV39GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV40GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV35DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtInventarioTextosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A535InventarioTextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A535InventarioTextosId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInventarioTextosId_Jsonclick, 0, "Attribute", "", "", "", "", edtInventarioTextosId_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_TextoslistaWC.htm");
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

      protected void START2W2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Textoslista WC", ""), 0) ;
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
               STRUP2W0( ) ;
            }
         }
      }

      protected void WS2W2( )
      {
         START2W2( ) ;
         EVT2W2( ) ;
      }

      protected void EVT2W2( )
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
                                 STRUP2W0( ) ;
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
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E112W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E122W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E132W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E142W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E152W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2W0( ) ;
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
                                 STRUP2W0( ) ;
                              }
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV41GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri(sPrefix, false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV41GridActions), 4, 0));
                              A121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A122RubrosNombre = cgiGet( edtRubrosNombre_Internalname);
                              A137MedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMedidasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A138MedidasNombre = cgiGet( edtMedidasNombre_Internalname);
                              A218InventarioSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtInventarioSerial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbMedidasEstado.Name = cmbMedidasEstado_Internalname;
                              cmbMedidasEstado.CurrentValue = cgiGet( cmbMedidasEstado_Internalname);
                              A139MedidasEstado = cgiGet( cmbMedidasEstado_Internalname);
                              n139MedidasEstado = false;
                              A150TextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTextosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n150TextosId = false;
                              A259TextosTitulo = cgiGet( edtTextosTitulo_Internalname);
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
                                          E162W2 ();
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
                                          E172W2 ();
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
                                          E182W2 ();
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
                                          E192W2 ();
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
                                       STRUP2W0( ) ;
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

      protected void WE2W2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2W2( ) ;
            }
         }
      }

      protected void PA2W2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "textoslistawc.aspx")), "textoslistawc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "textoslistawc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "InventarioTextosId");
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
                                       long AV8InventarioTextosId ,
                                       short AV20ManageFiltersExecutionStep ,
                                       string AV46Pgmname ,
                                       short AV21TFRubrosId ,
                                       short AV22TFRubrosId_To ,
                                       string AV23TFRubrosNombre ,
                                       string AV24TFRubrosNombre_Sel ,
                                       long AV25TFMedidasID ,
                                       long AV26TFMedidasID_To ,
                                       string AV27TFMedidasNombre ,
                                       string AV28TFMedidasNombre_Sel ,
                                       GxSimpleCollection<string> AV30TFMedidasEstado_Sels ,
                                       long AV31TFTextosId ,
                                       long AV32TFTextosId_To ,
                                       string AV33TFTextosTitulo ,
                                       string AV34TFTextosTitulo_Sel ,
                                       bool AV42IsAuthorized_Update ,
                                       bool AV43IsAuthorized_Delete ,
                                       bool AV44IsAuthorized_RubrosNombre ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2W2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_RUBROSID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"RUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_MEDIDASID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A137MedidasID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"MEDIDASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", "")));
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
         RF2W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV46Pgmname = "TextoslistaWC";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV30TFMedidasEstado_Sels ,
                                              AV21TFRubrosId ,
                                              AV22TFRubrosId_To ,
                                              AV24TFRubrosNombre_Sel ,
                                              AV23TFRubrosNombre ,
                                              AV25TFMedidasID ,
                                              AV26TFMedidasID_To ,
                                              AV28TFMedidasNombre_Sel ,
                                              AV27TFMedidasNombre ,
                                              AV30TFMedidasEstado_Sels.Count ,
                                              AV31TFTextosId ,
                                              AV32TFTextosId_To ,
                                              AV34TFTextosTitulo_Sel ,
                                              AV33TFTextosTitulo ,
                                              A121RubrosId ,
                                              A122RubrosNombre ,
                                              A137MedidasID ,
                                              A138MedidasNombre ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV16FilterFullText ,
                                              AV8InventarioTextosId ,
                                              A535InventarioTextosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV23TFRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFRubrosNombre), 100, "%");
         lV27TFMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV27TFMedidasNombre), 50, "%");
         lV33TFTextosTitulo = StringUtil.PadR( StringUtil.RTrim( AV33TFTextosTitulo), 80, "%");
         /* Using cursor H002W2 */
         pr_default.execute(0, new Object[] {AV8InventarioTextosId, AV21TFRubrosId, AV22TFRubrosId_To, lV23TFRubrosNombre, AV24TFRubrosNombre_Sel, AV25TFMedidasID, AV26TFMedidasID_To, lV27TFMedidasNombre, AV28TFMedidasNombre_Sel, AV31TFTextosId, AV32TFTextosId_To, lV33TFTextosTitulo, AV34TFTextosTitulo_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A535InventarioTextosId = H002W2_A535InventarioTextosId[0];
            n535InventarioTextosId = H002W2_n535InventarioTextosId[0];
            AssignAttri(sPrefix, false, "A535InventarioTextosId", StringUtil.LTrimStr( (decimal)(A535InventarioTextosId), 18, 0));
            A259TextosTitulo = H002W2_A259TextosTitulo[0];
            A150TextosId = H002W2_A150TextosId[0];
            n150TextosId = H002W2_n150TextosId[0];
            A139MedidasEstado = H002W2_A139MedidasEstado[0];
            n139MedidasEstado = H002W2_n139MedidasEstado[0];
            A218InventarioSerial = H002W2_A218InventarioSerial[0];
            A138MedidasNombre = H002W2_A138MedidasNombre[0];
            A137MedidasID = H002W2_A137MedidasID[0];
            A122RubrosNombre = H002W2_A122RubrosNombre[0];
            A121RubrosId = H002W2_A121RubrosId[0];
            A122RubrosNombre = H002W2_A122RubrosNombre[0];
            A150TextosId = H002W2_A150TextosId[0];
            n150TextosId = H002W2_n150TextosId[0];
            A139MedidasEstado = H002W2_A139MedidasEstado[0];
            n139MedidasEstado = H002W2_n139MedidasEstado[0];
            A218InventarioSerial = H002W2_A218InventarioSerial[0];
            A138MedidasNombre = H002W2_A138MedidasNombre[0];
            A259TextosTitulo = H002W2_A259TextosTitulo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A137MedidasID), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ) )
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

      protected void RF2W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E172W2 ();
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
                                                 A139MedidasEstado ,
                                                 AV30TFMedidasEstado_Sels ,
                                                 AV21TFRubrosId ,
                                                 AV22TFRubrosId_To ,
                                                 AV24TFRubrosNombre_Sel ,
                                                 AV23TFRubrosNombre ,
                                                 AV25TFMedidasID ,
                                                 AV26TFMedidasID_To ,
                                                 AV28TFMedidasNombre_Sel ,
                                                 AV27TFMedidasNombre ,
                                                 AV30TFMedidasEstado_Sels.Count ,
                                                 AV31TFTextosId ,
                                                 AV32TFTextosId_To ,
                                                 AV34TFTextosTitulo_Sel ,
                                                 AV33TFTextosTitulo ,
                                                 A121RubrosId ,
                                                 A122RubrosNombre ,
                                                 A137MedidasID ,
                                                 A138MedidasNombre ,
                                                 A150TextosId ,
                                                 A259TextosTitulo ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV16FilterFullText ,
                                                 AV8InventarioTextosId ,
                                                 A535InventarioTextosId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG,
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                                 }
            });
            lV23TFRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFRubrosNombre), 100, "%");
            lV27TFMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV27TFMedidasNombre), 50, "%");
            lV33TFTextosTitulo = StringUtil.PadR( StringUtil.RTrim( AV33TFTextosTitulo), 80, "%");
            /* Using cursor H002W3 */
            pr_default.execute(1, new Object[] {AV8InventarioTextosId, AV21TFRubrosId, AV22TFRubrosId_To, lV23TFRubrosNombre, AV24TFRubrosNombre_Sel, AV25TFMedidasID, AV26TFMedidasID_To, lV27TFMedidasNombre, AV28TFMedidasNombre_Sel, AV31TFTextosId, AV32TFTextosId_To, lV33TFTextosTitulo, AV34TFTextosTitulo_Sel});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A535InventarioTextosId = H002W3_A535InventarioTextosId[0];
               n535InventarioTextosId = H002W3_n535InventarioTextosId[0];
               AssignAttri(sPrefix, false, "A535InventarioTextosId", StringUtil.LTrimStr( (decimal)(A535InventarioTextosId), 18, 0));
               A259TextosTitulo = H002W3_A259TextosTitulo[0];
               A150TextosId = H002W3_A150TextosId[0];
               n150TextosId = H002W3_n150TextosId[0];
               A139MedidasEstado = H002W3_A139MedidasEstado[0];
               n139MedidasEstado = H002W3_n139MedidasEstado[0];
               A218InventarioSerial = H002W3_A218InventarioSerial[0];
               A138MedidasNombre = H002W3_A138MedidasNombre[0];
               A137MedidasID = H002W3_A137MedidasID[0];
               A122RubrosNombre = H002W3_A122RubrosNombre[0];
               A121RubrosId = H002W3_A121RubrosId[0];
               A122RubrosNombre = H002W3_A122RubrosNombre[0];
               A150TextosId = H002W3_A150TextosId[0];
               n150TextosId = H002W3_n150TextosId[0];
               A139MedidasEstado = H002W3_A139MedidasEstado[0];
               n139MedidasEstado = H002W3_n139MedidasEstado[0];
               A218InventarioSerial = H002W3_A218InventarioSerial[0];
               A138MedidasNombre = H002W3_A138MedidasNombre[0];
               A259TextosTitulo = H002W3_A259TextosTitulo[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A137MedidasID), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ) )
               {
                  /* Execute user event: Grid.Load */
                  E182W2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 37;
            WB2W0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2W2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV46Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV42IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV42IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV43IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV43IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_RUBROSNOMBRE", AV44IsAuthorized_RubrosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_RUBROSNOMBRE", GetSecureSignedToken( sPrefix, AV44IsAuthorized_RubrosNombre, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_RUBROSID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sPrefix+sGXsfl_37_idx, context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_MEDIDASID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sPrefix+sGXsfl_37_idx, context.localUtil.Format( (decimal)(A137MedidasID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8InventarioTextosId, AV20ManageFiltersExecutionStep, AV46Pgmname, AV21TFRubrosId, AV22TFRubrosId_To, AV23TFRubrosNombre, AV24TFRubrosNombre_Sel, AV25TFMedidasID, AV26TFMedidasID_To, AV27TFMedidasNombre, AV28TFMedidasNombre_Sel, AV30TFMedidasEstado_Sels, AV31TFTextosId, AV32TFTextosId_To, AV33TFTextosTitulo, AV34TFTextosTitulo_Sel, AV42IsAuthorized_Update, AV43IsAuthorized_Delete, AV44IsAuthorized_RubrosNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8InventarioTextosId, AV20ManageFiltersExecutionStep, AV46Pgmname, AV21TFRubrosId, AV22TFRubrosId_To, AV23TFRubrosNombre, AV24TFRubrosNombre_Sel, AV25TFMedidasID, AV26TFMedidasID_To, AV27TFMedidasNombre, AV28TFMedidasNombre_Sel, AV30TFMedidasEstado_Sels, AV31TFTextosId, AV32TFTextosId_To, AV33TFTextosTitulo, AV34TFTextosTitulo_Sel, AV42IsAuthorized_Update, AV43IsAuthorized_Delete, AV44IsAuthorized_RubrosNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8InventarioTextosId, AV20ManageFiltersExecutionStep, AV46Pgmname, AV21TFRubrosId, AV22TFRubrosId_To, AV23TFRubrosNombre, AV24TFRubrosNombre_Sel, AV25TFMedidasID, AV26TFMedidasID_To, AV27TFMedidasNombre, AV28TFMedidasNombre_Sel, AV30TFMedidasEstado_Sels, AV31TFTextosId, AV32TFTextosId_To, AV33TFTextosTitulo, AV34TFTextosTitulo_Sel, AV42IsAuthorized_Update, AV43IsAuthorized_Delete, AV44IsAuthorized_RubrosNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8InventarioTextosId, AV20ManageFiltersExecutionStep, AV46Pgmname, AV21TFRubrosId, AV22TFRubrosId_To, AV23TFRubrosNombre, AV24TFRubrosNombre_Sel, AV25TFMedidasID, AV26TFMedidasID_To, AV27TFMedidasNombre, AV28TFMedidasNombre_Sel, AV30TFMedidasEstado_Sels, AV31TFTextosId, AV32TFTextosId_To, AV33TFTextosTitulo, AV34TFTextosTitulo_Sel, AV42IsAuthorized_Update, AV43IsAuthorized_Delete, AV44IsAuthorized_RubrosNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8InventarioTextosId, AV20ManageFiltersExecutionStep, AV46Pgmname, AV21TFRubrosId, AV22TFRubrosId_To, AV23TFRubrosNombre, AV24TFRubrosNombre_Sel, AV25TFMedidasID, AV26TFMedidasID_To, AV27TFMedidasNombre, AV28TFMedidasNombre_Sel, AV30TFMedidasEstado_Sels, AV31TFTextosId, AV32TFTextosId_To, AV33TFTextosTitulo, AV34TFTextosTitulo_Sel, AV42IsAuthorized_Update, AV43IsAuthorized_Delete, AV44IsAuthorized_RubrosNombre, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV46Pgmname = "TextoslistaWC";
         edtRubrosId_Enabled = 0;
         edtRubrosNombre_Enabled = 0;
         edtMedidasID_Enabled = 0;
         edtMedidasNombre_Enabled = 0;
         edtInventarioSerial_Enabled = 0;
         cmbMedidasEstado.Enabled = 0;
         edtTextosId_Enabled = 0;
         edtTextosTitulo_Enabled = 0;
         edtInventarioTextosId_Enabled = 0;
         AssignProp(sPrefix, false, edtInventarioTextosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioTextosId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E162W2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV18ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV35DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV38GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV39GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV40GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOAV8InventarioTextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8InventarioTextosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
            A535InventarioTextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtInventarioTextosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n535InventarioTextosId = false;
            AssignAttri(sPrefix, false, "A535InventarioTextosId", StringUtil.LTrimStr( (decimal)(A535InventarioTextosId), 18, 0));
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
         E162W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E162W2( )
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
         GXt_boolean1 = AV44IsAuthorized_RubrosNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWRubros", out  GXt_boolean1) ;
         AV44IsAuthorized_RubrosNombre = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV44IsAuthorized_RubrosNombre", AV44IsAuthorized_RubrosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_RUBROSNOMBRE", GetSecureSignedToken( sPrefix, AV44IsAuthorized_RubrosNombre, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         edtInventarioTextosId_Visible = 0;
         AssignProp(sPrefix, false, edtInventarioTextosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtInventarioTextosId_Visible), 5, 0), true);
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV35DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV35DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E172W2( )
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
         AV38GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV38GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV38GridCurrentPage), 10, 0));
         AV39GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV39GridPageCount", StringUtil.LTrimStr( (decimal)(AV39GridPageCount), 10, 0));
         GXt_char3 = AV40GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV46Pgmname, out  GXt_char3) ;
         AV40GridAppliedFilters = GXt_char3;
         AssignAttri(sPrefix, false, "AV40GridAppliedFilters", AV40GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E122W2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E132W2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E142W2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RubrosId") == 0 )
            {
               AV21TFRubrosId = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV21TFRubrosId", StringUtil.LTrimStr( (decimal)(AV21TFRubrosId), 4, 0));
               AV22TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV22TFRubrosId_To", StringUtil.LTrimStr( (decimal)(AV22TFRubrosId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RubrosNombre") == 0 )
            {
               AV23TFRubrosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV23TFRubrosNombre", AV23TFRubrosNombre);
               AV24TFRubrosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV24TFRubrosNombre_Sel", AV24TFRubrosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MedidasID") == 0 )
            {
               AV25TFMedidasID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV25TFMedidasID", StringUtil.LTrimStr( (decimal)(AV25TFMedidasID), 18, 0));
               AV26TFMedidasID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV26TFMedidasID_To", StringUtil.LTrimStr( (decimal)(AV26TFMedidasID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MedidasNombre") == 0 )
            {
               AV27TFMedidasNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV27TFMedidasNombre", AV27TFMedidasNombre);
               AV28TFMedidasNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV28TFMedidasNombre_Sel", AV28TFMedidasNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MedidasEstado") == 0 )
            {
               AV29TFMedidasEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV29TFMedidasEstado_SelsJson", AV29TFMedidasEstado_SelsJson);
               AV30TFMedidasEstado_Sels.FromJSonString(AV29TFMedidasEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TextosId") == 0 )
            {
               AV31TFTextosId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV31TFTextosId", StringUtil.LTrimStr( (decimal)(AV31TFTextosId), 18, 0));
               AV32TFTextosId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV32TFTextosId_To", StringUtil.LTrimStr( (decimal)(AV32TFTextosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TextosTitulo") == 0 )
            {
               AV33TFTextosTitulo = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV33TFTextosTitulo", AV33TFTextosTitulo);
               AV34TFTextosTitulo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV34TFTextosTitulo_Sel", AV34TFTextosTitulo_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30TFMedidasEstado_Sels", AV30TFMedidasEstado_Sels);
      }

      private void E182W2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV42IsAuthorized_Update )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV43IsAuthorized_Delete )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            if ( AV44IsAuthorized_RubrosNombre )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "rubrosview.aspx"+UrlEncode(StringUtil.LTrimStr(A121RubrosId,4,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtRubrosNombre_Link = formatLink("rubrosview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV41GridActions), 4, 0));
      }

      protected void E112W2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("TextoslistaWCFilters")) + "," + UrlEncode(StringUtil.RTrim(AV46Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("TextoslistaWCFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char3 = AV19ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "TextoslistaWCFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV46Pgmname+"GridState",  AV19ManageFiltersXml) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30TFMedidasEstado_Sels", AV30TFMedidasEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
      }

      protected void E192W2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV41GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV41GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV41GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV41GridActions = 0;
         AssignAttri(sPrefix, false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV41GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV41GridActions), 4, 0));
         AssignProp(sPrefix, false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E152W2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "inventario.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("inventario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         GXt_boolean1 = AV42IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario_Update", out  GXt_boolean1) ;
         AV42IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV42IsAuthorized_Update", AV42IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV42IsAuthorized_Update, context));
         GXt_boolean1 = AV43IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario_Delete", out  GXt_boolean1) ;
         AV43IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV43IsAuthorized_Delete", AV43IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV43IsAuthorized_Delete, context));
         GXt_boolean1 = AV45TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario_Insert", out  GXt_boolean1) ;
         AV45TempBoolean = GXt_boolean1;
         if ( ! ( AV45TempBoolean ) )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "TextoslistaWCFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV18ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
         AV21TFRubrosId = 0;
         AssignAttri(sPrefix, false, "AV21TFRubrosId", StringUtil.LTrimStr( (decimal)(AV21TFRubrosId), 4, 0));
         AV22TFRubrosId_To = 0;
         AssignAttri(sPrefix, false, "AV22TFRubrosId_To", StringUtil.LTrimStr( (decimal)(AV22TFRubrosId_To), 4, 0));
         AV23TFRubrosNombre = "";
         AssignAttri(sPrefix, false, "AV23TFRubrosNombre", AV23TFRubrosNombre);
         AV24TFRubrosNombre_Sel = "";
         AssignAttri(sPrefix, false, "AV24TFRubrosNombre_Sel", AV24TFRubrosNombre_Sel);
         AV25TFMedidasID = 0;
         AssignAttri(sPrefix, false, "AV25TFMedidasID", StringUtil.LTrimStr( (decimal)(AV25TFMedidasID), 18, 0));
         AV26TFMedidasID_To = 0;
         AssignAttri(sPrefix, false, "AV26TFMedidasID_To", StringUtil.LTrimStr( (decimal)(AV26TFMedidasID_To), 18, 0));
         AV27TFMedidasNombre = "";
         AssignAttri(sPrefix, false, "AV27TFMedidasNombre", AV27TFMedidasNombre);
         AV28TFMedidasNombre_Sel = "";
         AssignAttri(sPrefix, false, "AV28TFMedidasNombre_Sel", AV28TFMedidasNombre_Sel);
         AV30TFMedidasEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31TFTextosId = 0;
         AssignAttri(sPrefix, false, "AV31TFTextosId", StringUtil.LTrimStr( (decimal)(AV31TFTextosId), 18, 0));
         AV32TFTextosId_To = 0;
         AssignAttri(sPrefix, false, "AV32TFTextosId_To", StringUtil.LTrimStr( (decimal)(AV32TFTextosId_To), 18, 0));
         AV33TFTextosTitulo = "";
         AssignAttri(sPrefix, false, "AV33TFTextosTitulo", AV33TFTextosTitulo);
         AV34TFTextosTitulo_Sel = "";
         AssignAttri(sPrefix, false, "AV34TFTextosTitulo_Sel", AV34TFTextosTitulo_Sel);
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "inventario.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A121RubrosId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(A137MedidasID,18,0));
         CallWebObject(formatLink("inventario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S202( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "inventario.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A121RubrosId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(A137MedidasID,18,0));
         CallWebObject(formatLink("inventario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S212( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "inventario.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A121RubrosId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(A137MedidasID,18,0));
         CallWebObject(formatLink("inventario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17Session.Get(AV46Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV46Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV17Session.Get(AV46Pgmname+"GridState"), null, "", "");
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
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV21TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV21TFRubrosId", StringUtil.LTrimStr( (decimal)(AV21TFRubrosId), 4, 0));
               AV22TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV22TFRubrosId_To", StringUtil.LTrimStr( (decimal)(AV22TFRubrosId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE") == 0 )
            {
               AV23TFRubrosNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV23TFRubrosNombre", AV23TFRubrosNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE_SEL") == 0 )
            {
               AV24TFRubrosNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV24TFRubrosNombre_Sel", AV24TFRubrosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFMEDIDASID") == 0 )
            {
               AV25TFMedidasID = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV25TFMedidasID", StringUtil.LTrimStr( (decimal)(AV25TFMedidasID), 18, 0));
               AV26TFMedidasID_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV26TFMedidasID_To", StringUtil.LTrimStr( (decimal)(AV26TFMedidasID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE") == 0 )
            {
               AV27TFMedidasNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV27TFMedidasNombre", AV27TFMedidasNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE_SEL") == 0 )
            {
               AV28TFMedidasNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV28TFMedidasNombre_Sel", AV28TFMedidasNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFMEDIDASESTADO_SEL") == 0 )
            {
               AV29TFMedidasEstado_SelsJson = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV29TFMedidasEstado_SelsJson", AV29TFMedidasEstado_SelsJson);
               AV30TFMedidasEstado_Sels.FromJSonString(AV29TFMedidasEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFTEXTOSID") == 0 )
            {
               AV31TFTextosId = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV31TFTextosId", StringUtil.LTrimStr( (decimal)(AV31TFTextosId), 18, 0));
               AV32TFTextosId_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV32TFTextosId_To", StringUtil.LTrimStr( (decimal)(AV32TFTextosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO") == 0 )
            {
               AV33TFTextosTitulo = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV33TFTextosTitulo", AV33TFTextosTitulo);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO_SEL") == 0 )
            {
               AV34TFTextosTitulo_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV34TFTextosTitulo_Sel", AV34TFTextosTitulo_Sel);
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFRubrosNombre_Sel)),  AV24TFRubrosNombre_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFMedidasNombre_Sel)),  AV28TFMedidasNombre_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV30TFMedidasEstado_Sels.Count==0),  AV29TFMedidasEstado_SelsJson, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTextosTitulo_Sel)),  AV34TFTextosTitulo_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char3+"||"+GXt_char5+"|"+GXt_char6+"||"+GXt_char7;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFRubrosNombre)),  AV23TFRubrosNombre, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFMedidasNombre)),  AV27TFMedidasNombre, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTextosTitulo)),  AV33TFTextosTitulo, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = ((0==AV21TFRubrosId) ? "" : StringUtil.Str( (decimal)(AV21TFRubrosId), 4, 0))+"|"+GXt_char7+"|"+((0==AV25TFMedidasID) ? "" : StringUtil.Str( (decimal)(AV25TFMedidasID), 18, 0))+"|"+GXt_char6+"||"+((0==AV31TFTextosId) ? "" : StringUtil.Str( (decimal)(AV31TFTextosId), 18, 0))+"|"+GXt_char5;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV22TFRubrosId_To) ? "" : StringUtil.Str( (decimal)(AV22TFRubrosId_To), 4, 0))+"||"+((0==AV26TFMedidasID_To) ? "" : StringUtil.Str( (decimal)(AV26TFMedidasID_To), 18, 0))+"|||"+((0==AV32TFTextosId_To) ? "" : StringUtil.Str( (decimal)(AV32TFTextosId_To), 18, 0))+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV17Session.Get(AV46Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFRUBROSID",  context.GetMessage( "Rubros Identificador ", ""),  !((0==AV21TFRubrosId)&&(0==AV22TFRubrosId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV21TFRubrosId), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV22TFRubrosId_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFRUBROSNOMBRE",  context.GetMessage( "Rubro", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFRubrosNombre)),  0,  AV23TFRubrosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFRubrosNombre_Sel)),  AV24TFRubrosNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFMEDIDASID",  context.GetMessage( "Items/Característica", ""),  !((0==AV25TFMedidasID)&&(0==AV26TFMedidasID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV25TFMedidasID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV26TFMedidasID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFMEDIDASNOMBRE",  context.GetMessage( "Nombre de la Característica", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFMedidasNombre)),  0,  AV27TFMedidasNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFMedidasNombre_Sel)),  AV28TFMedidasNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFMEDIDASESTADO_SEL",  context.GetMessage( "Estado de la Lista", ""),  !(AV30TFMedidasEstado_Sels.Count==0),  0,  AV30TFMedidasEstado_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFTEXTOSID",  context.GetMessage( "Textos Id", ""),  !((0==AV31TFTextosId)&&(0==AV32TFTextosId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31TFTextosId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV32TFTextosId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFTEXTOSTITULO",  context.GetMessage( "Titulo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTextosTitulo)),  0,  AV33TFTextosTitulo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTextosTitulo_Sel)),  AV34TFTextosTitulo_Sel,  "") ;
         if ( ! (0==AV8InventarioTextosId) )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = "PARM_&INVENTARIOTEXTOSID";
            AV13GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV8InventarioTextosId), 18, 0);
            AV12GridState.gxTpr_Filtervalues.Add(AV13GridStateFilterValue, 0);
         }
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV46Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV46Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "Inventario";
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "InventarioTextosId";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8InventarioTextosId), 18, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV17Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table1_22_2W2( bool wbgen )
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
            wb_table2_27_2W2( true) ;
         }
         else
         {
            wb_table2_27_2W2( false) ;
         }
         return  ;
      }

      protected void wb_table2_27_2W2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_22_2W2e( true) ;
         }
         else
         {
            wb_table1_22_2W2e( false) ;
         }
      }

      protected void wb_table2_27_2W2( bool wbgen )
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_TextoslistaWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_27_2W2e( true) ;
         }
         else
         {
            wb_table2_27_2W2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8InventarioTextosId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV8InventarioTextosId", StringUtil.LTrimStr( (decimal)(AV8InventarioTextosId), 18, 0));
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
         PA2W2( ) ;
         WS2W2( ) ;
         WE2W2( ) ;
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
         sCtrlAV8InventarioTextosId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2W2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "textoslistawc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2W2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8InventarioTextosId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV8InventarioTextosId", StringUtil.LTrimStr( (decimal)(AV8InventarioTextosId), 18, 0));
         }
         wcpOAV8InventarioTextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8InventarioTextosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV8InventarioTextosId != wcpOAV8InventarioTextosId ) ) )
         {
            setjustcreated();
         }
         wcpOAV8InventarioTextosId = AV8InventarioTextosId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8InventarioTextosId = cgiGet( sPrefix+"AV8InventarioTextosId_CTRL");
         if ( StringUtil.Len( sCtrlAV8InventarioTextosId) > 0 )
         {
            AV8InventarioTextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8InventarioTextosId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8InventarioTextosId", StringUtil.LTrimStr( (decimal)(AV8InventarioTextosId), 18, 0));
         }
         else
         {
            AV8InventarioTextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8InventarioTextosId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA2W2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2W2( ) ;
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
         WS2W2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8InventarioTextosId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8InventarioTextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8InventarioTextosId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8InventarioTextosId_CTRL", StringUtil.RTrim( sCtrlAV8InventarioTextosId));
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
         WE2W2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026931959636", true, true, false);
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
         context.AddJavascriptSource("textoslistawc.js", "?2026931959636", false, true, false);
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
         cmbavGridactions_Internalname = sPrefix+"vGRIDACTIONS_"+sGXsfl_37_idx;
         edtRubrosId_Internalname = sPrefix+"RUBROSID_"+sGXsfl_37_idx;
         edtRubrosNombre_Internalname = sPrefix+"RUBROSNOMBRE_"+sGXsfl_37_idx;
         edtMedidasID_Internalname = sPrefix+"MEDIDASID_"+sGXsfl_37_idx;
         edtMedidasNombre_Internalname = sPrefix+"MEDIDASNOMBRE_"+sGXsfl_37_idx;
         edtInventarioSerial_Internalname = sPrefix+"INVENTARIOSERIAL_"+sGXsfl_37_idx;
         cmbMedidasEstado_Internalname = sPrefix+"MEDIDASESTADO_"+sGXsfl_37_idx;
         edtTextosId_Internalname = sPrefix+"TEXTOSID_"+sGXsfl_37_idx;
         edtTextosTitulo_Internalname = sPrefix+"TEXTOSTITULO_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         cmbavGridactions_Internalname = sPrefix+"vGRIDACTIONS_"+sGXsfl_37_fel_idx;
         edtRubrosId_Internalname = sPrefix+"RUBROSID_"+sGXsfl_37_fel_idx;
         edtRubrosNombre_Internalname = sPrefix+"RUBROSNOMBRE_"+sGXsfl_37_fel_idx;
         edtMedidasID_Internalname = sPrefix+"MEDIDASID_"+sGXsfl_37_fel_idx;
         edtMedidasNombre_Internalname = sPrefix+"MEDIDASNOMBRE_"+sGXsfl_37_fel_idx;
         edtInventarioSerial_Internalname = sPrefix+"INVENTARIOSERIAL_"+sGXsfl_37_fel_idx;
         cmbMedidasEstado_Internalname = sPrefix+"MEDIDASESTADO_"+sGXsfl_37_fel_idx;
         edtTextosId_Internalname = sPrefix+"TEXTOSID_"+sGXsfl_37_fel_idx;
         edtTextosTitulo_Internalname = sPrefix+"TEXTOSTITULO_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB2W0( ) ;
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
                  AV41GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV41GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV41GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV41GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVGRIDACTIONS.CLICK."+sGXsfl_37_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV41GridActions), 4, 0));
            AssignProp(sPrefix, false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosNombre_Internalname,StringUtil.RTrim( A122RubrosNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtRubrosNombre_Link,(string)"",(string)"",(string)"",(string)edtRubrosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidasID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A137MedidasID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidasID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidasNombre_Internalname,StringUtil.RTrim( A138MedidasNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidasNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioSerial_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A218InventarioSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A218InventarioSerial), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioSerial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "MEDIDASESTADO_" + sGXsfl_37_idx;
            cmbMedidasEstado.Name = GXCCtl;
            cmbMedidasEstado.WebTags = "";
            cmbMedidasEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
            cmbMedidasEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
            cmbMedidasEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
            cmbMedidasEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
            if ( cmbMedidasEstado.ItemCount > 0 )
            {
               A139MedidasEstado = cmbMedidasEstado.getValidValue(A139MedidasEstado);
               n139MedidasEstado = false;
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMedidasEstado,(string)cmbMedidasEstado_Internalname,StringUtil.RTrim( A139MedidasEstado),(short)1,(string)cmbMedidasEstado_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbMedidasEstado.CurrentValue = StringUtil.RTrim( A139MedidasEstado);
            AssignProp(sPrefix, false, cmbMedidasEstado_Internalname, "Values", (string)(cmbMedidasEstado.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTextosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A150TextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A150TextosId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTextosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTextosTitulo_Internalname,StringUtil.RTrim( A259TextosTitulo),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTextosTitulo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2W2( ) ;
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
         GXCCtl = "MEDIDASESTADO_" + sGXsfl_37_idx;
         cmbMedidasEstado.Name = GXCCtl;
         cmbMedidasEstado.WebTags = "";
         cmbMedidasEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbMedidasEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbMedidasEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbMedidasEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbMedidasEstado.ItemCount > 0 )
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
            context.SendWebValue( context.GetMessage( "Rubros Identificador ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rubro", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Items/Característica", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre de la Característica", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Serial", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado de la Lista", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Textos Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Titulo", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A122RubrosNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtRubrosNombre_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A138MedidasNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A218InventarioSerial), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A139MedidasEstado)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A150TextosId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A259TextosTitulo)));
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
         edtRubrosId_Internalname = sPrefix+"RUBROSID";
         edtRubrosNombre_Internalname = sPrefix+"RUBROSNOMBRE";
         edtMedidasID_Internalname = sPrefix+"MEDIDASID";
         edtMedidasNombre_Internalname = sPrefix+"MEDIDASNOMBRE";
         edtInventarioSerial_Internalname = sPrefix+"INVENTARIOSERIAL";
         cmbMedidasEstado_Internalname = sPrefix+"MEDIDASESTADO";
         edtTextosId_Internalname = sPrefix+"TEXTOSID";
         edtTextosTitulo_Internalname = sPrefix+"TEXTOSTITULO";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtInventarioTextosId_Internalname = sPrefix+"INVENTARIOTEXTOSID";
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
         edtTextosTitulo_Jsonclick = "";
         edtTextosId_Jsonclick = "";
         cmbMedidasEstado_Jsonclick = "";
         edtInventarioSerial_Jsonclick = "";
         edtMedidasNombre_Jsonclick = "";
         edtMedidasID_Jsonclick = "";
         edtRubrosNombre_Jsonclick = "";
         edtRubrosNombre_Link = "";
         edtRubrosId_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtInventarioTextosId_Enabled = 0;
         edtTextosTitulo_Enabled = 0;
         edtTextosId_Enabled = 0;
         cmbMedidasEstado.Enabled = 0;
         edtInventarioSerial_Enabled = 0;
         edtMedidasNombre_Enabled = 0;
         edtMedidasID_Enabled = 0;
         edtRubrosNombre_Enabled = 0;
         edtRubrosId_Enabled = 0;
         subGrid_Sortable = 0;
         edtInventarioTextosId_Jsonclick = "";
         edtInventarioTextosId_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "4.0||18.0|||18.0|";
         Ddo_grid_Datalistproc = "TextoslistaWCGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||HAB:Habilitado,DES:Deshabilitado,PEN:Pendiente||";
         Ddo_grid_Allowmultipleselection = "||||T||";
         Ddo_grid_Datalisttype = "|Dynamic||Dynamic|FixedValues||Dynamic";
         Ddo_grid_Includedatalist = "|T||T|T||T";
         Ddo_grid_Filterisrange = "T||T|||T|";
         Ddo_grid_Filtertype = "Numeric|Character|Numeric|Character||Numeric|Character";
         Ddo_grid_Includefilter = "T|T|T|T||T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7";
         Ddo_grid_Columnids = "1:RubrosId|2:RubrosNombre|3:MedidasID|4:MedidasNombre|6:MedidasEstado|7:TextosId|8:TextosTitulo";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'sPrefix',type:'char'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8InventarioTextosId',fld:'vINVENTARIOTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV22TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV23TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV24TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV28TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV30TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV31TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV34TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV42IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV39GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV40GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV42IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E122W2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8InventarioTextosId',fld:'vINVENTARIOTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV22TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV23TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV24TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV28TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV30TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV31TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV34TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV42IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV39GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV40GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV42IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E132W2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8InventarioTextosId',fld:'vINVENTARIOTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV22TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV23TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV24TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV28TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV30TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV31TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV34TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV42IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E142W2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8InventarioTextosId',fld:'vINVENTARIOTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV22TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV23TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV24TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV28TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV30TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV31TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV34TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV42IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV33TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV34TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV31TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFMedidasEstado_SelsJson',fld:'vTFMEDIDASESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV30TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV27TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV28TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV24TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV21TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV22TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E182W2',iparms:[{av:'AV42IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV41GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtRubrosNombre_Link',ctrl:'RUBROSNOMBRE',prop:'Link'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E112W2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8InventarioTextosId',fld:'vINVENTARIOTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV22TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV23TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV24TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV28TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV30TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV31TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV34TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV42IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''},{av:'AV29TFMedidasEstado_SelsJson',fld:'vTFMEDIDASESTADO_SELSJSON',pic:'',type:'vchar'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV22TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV23TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV24TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV28TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV30TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV31TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV34TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV29TFMedidasEstado_SelsJson',fld:'vTFMEDIDASESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV38GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV39GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV40GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV42IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E192W2',iparms:[{av:'cmbavGridactions'},{av:'AV41GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV41GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E152W2',iparms:[{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[]");
         setEventMetadata("VALID_RUBROSID",",oparms:[]}");
         setEventMetadata("VALID_RUBROSNOMBRE","{handler:'Valid_Rubrosnombre',iparms:[]");
         setEventMetadata("VALID_RUBROSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_MEDIDASID","{handler:'Valid_Medidasid',iparms:[]");
         setEventMetadata("VALID_MEDIDASID",",oparms:[]}");
         setEventMetadata("VALID_MEDIDASNOMBRE","{handler:'Valid_Medidasnombre',iparms:[]");
         setEventMetadata("VALID_MEDIDASNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_MEDIDASESTADO","{handler:'Valid_Medidasestado',iparms:[]");
         setEventMetadata("VALID_MEDIDASESTADO",",oparms:[]}");
         setEventMetadata("VALID_TEXTOSID","{handler:'Valid_Textosid',iparms:[]");
         setEventMetadata("VALID_TEXTOSID",",oparms:[]}");
         setEventMetadata("VALID_TEXTOSTITULO","{handler:'Valid_Textostitulo',iparms:[]");
         setEventMetadata("VALID_TEXTOSTITULO",",oparms:[]}");
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
         AV46Pgmname = "";
         AV23TFRubrosNombre = "";
         AV24TFRubrosNombre_Sel = "";
         AV27TFMedidasNombre = "";
         AV28TFMedidasNombre_Sel = "";
         AV30TFMedidasEstado_Sels = new GxSimpleCollection<string>();
         AV33TFTextosTitulo = "";
         AV34TFTextosTitulo_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV18ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV40GridAppliedFilters = "";
         AV35DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29TFMedidasEstado_SelsJson = "";
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
         A122RubrosNombre = "";
         A138MedidasNombre = "";
         A139MedidasEstado = "";
         A259TextosTitulo = "";
         GXDecQS = "";
         lV16FilterFullText = "";
         lV23TFRubrosNombre = "";
         lV27TFMedidasNombre = "";
         lV33TFTextosTitulo = "";
         H002W2_A135InventarioId = new long[1] ;
         H002W2_A535InventarioTextosId = new long[1] ;
         H002W2_n535InventarioTextosId = new bool[] {false} ;
         H002W2_A259TextosTitulo = new string[] {""} ;
         H002W2_A150TextosId = new long[1] ;
         H002W2_n150TextosId = new bool[] {false} ;
         H002W2_A139MedidasEstado = new string[] {""} ;
         H002W2_n139MedidasEstado = new bool[] {false} ;
         H002W2_A218InventarioSerial = new short[1] ;
         H002W2_A138MedidasNombre = new string[] {""} ;
         H002W2_A137MedidasID = new long[1] ;
         H002W2_A122RubrosNombre = new string[] {""} ;
         H002W2_A121RubrosId = new short[1] ;
         H002W3_A135InventarioId = new long[1] ;
         H002W3_A535InventarioTextosId = new long[1] ;
         H002W3_n535InventarioTextosId = new bool[] {false} ;
         H002W3_A259TextosTitulo = new string[] {""} ;
         H002W3_A150TextosId = new long[1] ;
         H002W3_n150TextosId = new bool[] {false} ;
         H002W3_A139MedidasEstado = new string[] {""} ;
         H002W3_n139MedidasEstado = new bool[] {false} ;
         H002W3_A218InventarioSerial = new short[1] ;
         H002W3_A138MedidasNombre = new string[] {""} ;
         H002W3_A137MedidasID = new long[1] ;
         H002W3_A122RubrosNombre = new string[] {""} ;
         H002W3_A121RubrosId = new short[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV19ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV17Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8InventarioTextosId = "";
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.textoslistawc__default(),
            new Object[][] {
                new Object[] {
               H002W2_A135InventarioId, H002W2_A535InventarioTextosId, H002W2_n535InventarioTextosId, H002W2_A259TextosTitulo, H002W2_A150TextosId, H002W2_n150TextosId, H002W2_A139MedidasEstado, H002W2_n139MedidasEstado, H002W2_A218InventarioSerial, H002W2_A138MedidasNombre,
               H002W2_A137MedidasID, H002W2_A122RubrosNombre, H002W2_A121RubrosId
               }
               , new Object[] {
               H002W3_A135InventarioId, H002W3_A535InventarioTextosId, H002W3_n535InventarioTextosId, H002W3_A259TextosTitulo, H002W3_A150TextosId, H002W3_n150TextosId, H002W3_A139MedidasEstado, H002W3_n139MedidasEstado, H002W3_A218InventarioSerial, H002W3_A138MedidasNombre,
               H002W3_A137MedidasID, H002W3_A122RubrosNombre, H002W3_A121RubrosId
               }
            }
         );
         AV46Pgmname = "TextoslistaWC";
         /* GeneXus formulas. */
         AV46Pgmname = "TextoslistaWC";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14OrderedBy ;
      private short AV20ManageFiltersExecutionStep ;
      private short AV21TFRubrosId ;
      private short AV22TFRubrosId_To ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV41GridActions ;
      private short A121RubrosId ;
      private short A218InventarioSerial ;
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
      private int edtInventarioTextosId_Visible ;
      private int subGrid_Islastpage ;
      private int AV30TFMedidasEstado_Sels_Count ;
      private int edtRubrosId_Enabled ;
      private int edtRubrosNombre_Enabled ;
      private int edtMedidasID_Enabled ;
      private int edtMedidasNombre_Enabled ;
      private int edtInventarioSerial_Enabled ;
      private int edtTextosId_Enabled ;
      private int edtTextosTitulo_Enabled ;
      private int edtInventarioTextosId_Enabled ;
      private int AV37PageToGo ;
      private int AV47GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8InventarioTextosId ;
      private long wcpOAV8InventarioTextosId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV25TFMedidasID ;
      private long AV26TFMedidasID_To ;
      private long AV31TFTextosId ;
      private long AV32TFTextosId_To ;
      private long AV38GridCurrentPage ;
      private long AV39GridPageCount ;
      private long A535InventarioTextosId ;
      private long A137MedidasID ;
      private long A150TextosId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
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
      private string AV46Pgmname ;
      private string AV23TFRubrosNombre ;
      private string AV24TFRubrosNombre_Sel ;
      private string AV27TFMedidasNombre ;
      private string AV28TFMedidasNombre_Sel ;
      private string AV33TFTextosTitulo ;
      private string AV34TFTextosTitulo_Sel ;
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
      private string edtInventarioTextosId_Internalname ;
      private string edtInventarioTextosId_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtRubrosId_Internalname ;
      private string A122RubrosNombre ;
      private string edtRubrosNombre_Internalname ;
      private string edtMedidasID_Internalname ;
      private string A138MedidasNombre ;
      private string edtMedidasNombre_Internalname ;
      private string edtInventarioSerial_Internalname ;
      private string cmbMedidasEstado_Internalname ;
      private string A139MedidasEstado ;
      private string edtTextosId_Internalname ;
      private string A259TextosTitulo ;
      private string edtTextosTitulo_Internalname ;
      private string GXDecQS ;
      private string edtavFilterfulltext_Internalname ;
      private string lV23TFRubrosNombre ;
      private string lV27TFMedidasNombre ;
      private string lV33TFTextosTitulo ;
      private string edtRubrosNombre_Link ;
      private string GXt_char3 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sCtrlAV8InventarioTextosId ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtRubrosId_Jsonclick ;
      private string edtRubrosNombre_Jsonclick ;
      private string edtMedidasID_Jsonclick ;
      private string edtMedidasNombre_Jsonclick ;
      private string edtInventarioSerial_Jsonclick ;
      private string cmbMedidasEstado_Jsonclick ;
      private string edtTextosId_Jsonclick ;
      private string edtTextosTitulo_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV42IsAuthorized_Update ;
      private bool AV43IsAuthorized_Delete ;
      private bool AV44IsAuthorized_RubrosNombre ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n139MedidasEstado ;
      private bool n150TextosId ;
      private bool n535InventarioTextosId ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV45TempBoolean ;
      private bool GXt_boolean1 ;
      private string AV29TFMedidasEstado_SelsJson ;
      private string AV19ManageFiltersXml ;
      private string AV16FilterFullText ;
      private string AV40GridAppliedFilters ;
      private string lV16FilterFullText ;
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
      private GXCombobox cmbMedidasEstado ;
      private GxSimpleCollection<string> AV30TFMedidasEstado_Sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV18ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV35DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private IDataStoreProvider pr_default ;
      private long[] H002W2_A135InventarioId ;
      private long[] H002W2_A535InventarioTextosId ;
      private bool[] H002W2_n535InventarioTextosId ;
      private string[] H002W2_A259TextosTitulo ;
      private long[] H002W2_A150TextosId ;
      private bool[] H002W2_n150TextosId ;
      private string[] H002W2_A139MedidasEstado ;
      private bool[] H002W2_n139MedidasEstado ;
      private short[] H002W2_A218InventarioSerial ;
      private string[] H002W2_A138MedidasNombre ;
      private long[] H002W2_A137MedidasID ;
      private string[] H002W2_A122RubrosNombre ;
      private short[] H002W2_A121RubrosId ;
      private long[] H002W3_A135InventarioId ;
      private long[] H002W3_A535InventarioTextosId ;
      private bool[] H002W3_n535InventarioTextosId ;
      private string[] H002W3_A259TextosTitulo ;
      private long[] H002W3_A150TextosId ;
      private bool[] H002W3_n150TextosId ;
      private string[] H002W3_A139MedidasEstado ;
      private bool[] H002W3_n139MedidasEstado ;
      private short[] H002W3_A218InventarioSerial ;
      private string[] H002W3_A138MedidasNombre ;
      private long[] H002W3_A137MedidasID ;
      private string[] H002W3_A122RubrosNombre ;
      private short[] H002W3_A121RubrosId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class textoslistawc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002W2( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV30TFMedidasEstado_Sels ,
                                             short AV21TFRubrosId ,
                                             short AV22TFRubrosId_To ,
                                             string AV24TFRubrosNombre_Sel ,
                                             string AV23TFRubrosNombre ,
                                             long AV25TFMedidasID ,
                                             long AV26TFMedidasID_To ,
                                             string AV28TFMedidasNombre_Sel ,
                                             string AV27TFMedidasNombre ,
                                             int AV30TFMedidasEstado_Sels_Count ,
                                             long AV31TFTextosId ,
                                             long AV32TFTextosId_To ,
                                             string AV34TFTextosTitulo_Sel ,
                                             string AV33TFTextosTitulo ,
                                             short A121RubrosId ,
                                             string A122RubrosNombre ,
                                             long A137MedidasID ,
                                             string A138MedidasNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV16FilterFullText ,
                                             long AV8InventarioTextosId ,
                                             long A535InventarioTextosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[13];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[InventarioId], T1.[InventarioTextosId], T4.[TextosTitulo], T3.[TextosId], T3.[MedidasEstado], T3.[InventarioSerial], T3.[MedidasNombre], T1.[MedidasID], T2.[RubrosNombre], T1.[RubrosId] FROM ((([Inventario] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) LEFT JOIN [Textos] T4 ON T4.[TextosId] = T3.[TextosId])";
         AddWhere(sWhereString, "(T1.[InventarioTextosId] = @AV8InventarioTextosId)");
         if ( ! (0==AV21TFRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV21TFRubrosId)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! (0==AV22TFRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV22TFRubrosId_To)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like UPPER(@lV23TFRubrosNombre))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV24TFRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[RubrosNombre] = @AV24TFRubrosNombre_Sel)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[RubrosNombre] = ''))");
         }
         if ( ! (0==AV25TFMedidasID) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] >= @AV25TFMedidasID)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! (0==AV26TFMedidasID_To) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] <= @AV26TFMedidasID_To)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFMedidasNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFMedidasNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[MedidasNombre]) like UPPER(@lV27TFMedidasNombre))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFMedidasNombre_Sel)) && ! ( StringUtil.StrCmp(AV28TFMedidasNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[MedidasNombre] = @AV28TFMedidasNombre_Sel)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFMedidasNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[MedidasNombre] = ''))");
         }
         if ( AV30TFMedidasEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFMedidasEstado_Sels, "T3.[MedidasEstado] IN (", ")")+")");
         }
         if ( ! (0==AV31TFTextosId) )
         {
            AddWhere(sWhereString, "(T3.[TextosId] >= @AV31TFTextosId)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! (0==AV32TFTextosId_To) )
         {
            AddWhere(sWhereString, "(T3.[TextosId] <= @AV32TFTextosId_To)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTextosTitulo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTextosTitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[TextosTitulo]) like UPPER(@lV33TFTextosTitulo))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTextosTitulo_Sel)) && ! ( StringUtil.StrCmp(AV34TFTextosTitulo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[TextosTitulo] = @AV34TFTextosTitulo_Sel)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV34TFTextosTitulo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.[TextosTitulo] IS NULL or (T4.[TextosTitulo] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId], T1.[RubrosId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId] DESC, T1.[RubrosId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId], T2.[RubrosNombre]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId] DESC, T2.[RubrosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId], T1.[MedidasID]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId] DESC, T1.[MedidasID] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId], T3.[MedidasNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId] DESC, T3.[MedidasNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId], T3.[MedidasEstado]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId] DESC, T3.[MedidasEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId], T3.[TextosId]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId] DESC, T3.[TextosId] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId], T4.[TextosTitulo]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId] DESC, T4.[TextosTitulo] DESC";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H002W3( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV30TFMedidasEstado_Sels ,
                                             short AV21TFRubrosId ,
                                             short AV22TFRubrosId_To ,
                                             string AV24TFRubrosNombre_Sel ,
                                             string AV23TFRubrosNombre ,
                                             long AV25TFMedidasID ,
                                             long AV26TFMedidasID_To ,
                                             string AV28TFMedidasNombre_Sel ,
                                             string AV27TFMedidasNombre ,
                                             int AV30TFMedidasEstado_Sels_Count ,
                                             long AV31TFTextosId ,
                                             long AV32TFTextosId_To ,
                                             string AV34TFTextosTitulo_Sel ,
                                             string AV33TFTextosTitulo ,
                                             short A121RubrosId ,
                                             string A122RubrosNombre ,
                                             long A137MedidasID ,
                                             string A138MedidasNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV16FilterFullText ,
                                             long AV8InventarioTextosId ,
                                             long A535InventarioTextosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[13];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.[InventarioId], T1.[InventarioTextosId], T4.[TextosTitulo], T3.[TextosId], T3.[MedidasEstado], T3.[InventarioSerial], T3.[MedidasNombre], T1.[MedidasID], T2.[RubrosNombre], T1.[RubrosId] FROM ((([Inventario] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) LEFT JOIN [Textos] T4 ON T4.[TextosId] = T3.[TextosId])";
         AddWhere(sWhereString, "(T1.[InventarioTextosId] = @AV8InventarioTextosId)");
         if ( ! (0==AV21TFRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV21TFRubrosId)");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( ! (0==AV22TFRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV22TFRubrosId_To)");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like UPPER(@lV23TFRubrosNombre))");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV24TFRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[RubrosNombre] = @AV24TFRubrosNombre_Sel)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[RubrosNombre] = ''))");
         }
         if ( ! (0==AV25TFMedidasID) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] >= @AV25TFMedidasID)");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( ! (0==AV26TFMedidasID_To) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] <= @AV26TFMedidasID_To)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFMedidasNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFMedidasNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[MedidasNombre]) like UPPER(@lV27TFMedidasNombre))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFMedidasNombre_Sel)) && ! ( StringUtil.StrCmp(AV28TFMedidasNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[MedidasNombre] = @AV28TFMedidasNombre_Sel)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFMedidasNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[MedidasNombre] = ''))");
         }
         if ( AV30TFMedidasEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFMedidasEstado_Sels, "T3.[MedidasEstado] IN (", ")")+")");
         }
         if ( ! (0==AV31TFTextosId) )
         {
            AddWhere(sWhereString, "(T3.[TextosId] >= @AV31TFTextosId)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ! (0==AV32TFTextosId_To) )
         {
            AddWhere(sWhereString, "(T3.[TextosId] <= @AV32TFTextosId_To)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTextosTitulo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTextosTitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[TextosTitulo]) like UPPER(@lV33TFTextosTitulo))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTextosTitulo_Sel)) && ! ( StringUtil.StrCmp(AV34TFTextosTitulo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[TextosTitulo] = @AV34TFTextosTitulo_Sel)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( StringUtil.StrCmp(AV34TFTextosTitulo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.[TextosTitulo] IS NULL or (T4.[TextosTitulo] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId], T1.[RubrosId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId] DESC, T1.[RubrosId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId], T2.[RubrosNombre]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId] DESC, T2.[RubrosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId], T1.[MedidasID]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId] DESC, T1.[MedidasID] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId], T3.[MedidasNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId] DESC, T3.[MedidasNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId], T3.[MedidasEstado]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId] DESC, T3.[MedidasEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId], T3.[TextosId]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId] DESC, T3.[TextosId] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId], T4.[TextosTitulo]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InventarioTextosId] DESC, T4.[TextosTitulo] DESC";
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
                     return conditional_H002W2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (string)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] );
               case 1 :
                     return conditional_H002W3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (string)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] );
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
          Object[] prmH002W2;
          prmH002W2 = new Object[] {
          new ParDef("@AV8InventarioTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV21TFRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV22TFRubrosId_To",GXType.Int16,4,0) ,
          new ParDef("@lV23TFRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV24TFRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV25TFMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV26TFMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV27TFMedidasNombre",GXType.Char,50,0) ,
          new ParDef("@AV28TFMedidasNombre_Sel",GXType.NChar,50,0) ,
          new ParDef("@AV31TFTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV32TFTextosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV33TFTextosTitulo",GXType.Char,80,0) ,
          new ParDef("@AV34TFTextosTitulo_Sel",GXType.NChar,80,0)
          };
          Object[] prmH002W3;
          prmH002W3 = new Object[] {
          new ParDef("@AV8InventarioTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV21TFRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV22TFRubrosId_To",GXType.Int16,4,0) ,
          new ParDef("@lV23TFRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV24TFRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV25TFMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV26TFMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV27TFMedidasNombre",GXType.Char,50,0) ,
          new ParDef("@AV28TFMedidasNombre_Sel",GXType.NChar,50,0) ,
          new ParDef("@AV31TFTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV32TFTextosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV33TFTextosTitulo",GXType.Char,80,0) ,
          new ParDef("@AV34TFTextosTitulo_Sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002W2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002W3,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 3);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((short[]) buf[8])[0] = rslt.getShort(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 50);
                ((long[]) buf[10])[0] = rslt.getLong(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 100);
                ((short[]) buf[12])[0] = rslt.getShort(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 3);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((short[]) buf[8])[0] = rslt.getShort(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 50);
                ((long[]) buf[10])[0] = rslt.getLong(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 100);
                ((short[]) buf[12])[0] = rslt.getShort(10);
                return;
       }
    }

 }

}
