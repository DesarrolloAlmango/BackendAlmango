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
   public class profcomisionesrubroswc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public profcomisionesrubroswc( )
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

      public profcomisionesrubroswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProfComisionesID )
      {
         this.AV8ProfComisionesID = aP0_ProfComisionesID;
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
         cmbProfComisionesRubrosTipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ProfComisionesID");
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
                  AV8ProfComisionesID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProfComisionesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8ProfComisionesID", StringUtil.LTrimStr( (decimal)(AV8ProfComisionesID), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV8ProfComisionesID});
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
                  gxfirstwebparm = GetFirstPar( "ProfComisionesID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ProfComisionesID");
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
         AV8ProfComisionesID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProfComisionesID"), "."), 18, MidpointRounding.ToEven));
         AV46Pgmname = GetPar( "Pgmname");
         AV17TFProfComisionesRubrosId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProfComisionesRubrosId"), "."), 18, MidpointRounding.ToEven));
         AV18TFProfComisionesRubrosId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProfComisionesRubrosId_To"), "."), 18, MidpointRounding.ToEven));
         AV19TFRubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "TFRubrosId"), "."), 18, MidpointRounding.ToEven));
         AV20TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFRubrosId_To"), "."), 18, MidpointRounding.ToEven));
         AV21TFMedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFMedidasID"), "."), 18, MidpointRounding.ToEven));
         AV22TFMedidasID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFMedidasID_To"), "."), 18, MidpointRounding.ToEven));
         AV23TFInventarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFInventarioId"), "."), 18, MidpointRounding.ToEven));
         AV24TFInventarioId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFInventarioId_To"), "."), 18, MidpointRounding.ToEven));
         AV25TFInventarioPrecioFinal = NumberUtil.Val( GetPar( "TFInventarioPrecioFinal"), ".");
         AV26TFInventarioPrecioFinal_To = NumberUtil.Val( GetPar( "TFInventarioPrecioFinal_To"), ".");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV28TFProfComisionesRubrosTipo_Sels);
         AV29TFProfComisionesRubrosValor = NumberUtil.Val( GetPar( "TFProfComisionesRubrosValor"), ".");
         AV30TFProfComisionesRubrosValor_To = NumberUtil.Val( GetPar( "TFProfComisionesRubrosValor_To"), ".");
         AV31TFProfComisionesRubrosGan = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProfComisionesRubrosGan"), "."), 18, MidpointRounding.ToEven));
         AV32TFProfComisionesRubrosGan_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProfComisionesRubrosGan_To"), "."), 18, MidpointRounding.ToEven));
         AV33TFProfComisionesRubrosGanPRF = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProfComisionesRubrosGanPRF"), "."), 18, MidpointRounding.ToEven));
         AV34TFProfComisionesRubrosGanPRF_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProfComisionesRubrosGanPRF_To"), "."), 18, MidpointRounding.ToEven));
         AV35TFProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProveedorID"), "."), 18, MidpointRounding.ToEven));
         AV36TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProveedorID_To"), "."), 18, MidpointRounding.ToEven));
         AV37TFProveedorNombre = GetPar( "TFProveedorNombre");
         AV38TFProveedorNombre_Sel = GetPar( "TFProveedorNombre_Sel");
         AV45IsAuthorized_ProveedorNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_ProveedorNombre"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ProfComisionesID, AV46Pgmname, AV17TFProfComisionesRubrosId, AV18TFProfComisionesRubrosId_To, AV19TFRubrosId, AV20TFRubrosId_To, AV21TFMedidasID, AV22TFMedidasID_To, AV23TFInventarioId, AV24TFInventarioId_To, AV25TFInventarioPrecioFinal, AV26TFInventarioPrecioFinal_To, AV28TFProfComisionesRubrosTipo_Sels, AV29TFProfComisionesRubrosValor, AV30TFProfComisionesRubrosValor_To, AV31TFProfComisionesRubrosGan, AV32TFProfComisionesRubrosGan_To, AV33TFProfComisionesRubrosGanPRF, AV34TFProfComisionesRubrosGanPRF_To, AV35TFProveedorID, AV36TFProveedorID_To, AV37TFProveedorNombre, AV38TFProveedorNombre_Sel, AV45IsAuthorized_ProveedorNombre, sPrefix) ;
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
            PA3Q2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV46Pgmname = "ProfComisionesRubrosWC";
               WS3Q2( ) ;
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
            context.SendWebValue( context.GetMessage( "Prof Comisiones Rubros WC", "")) ;
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
            GXEncryptionTmp = "profcomisionesrubroswc.aspx"+UrlEncode(StringUtil.LTrimStr(AV8ProfComisionesID,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("profcomisionesrubroswc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_PROVEEDORNOMBRE", AV45IsAuthorized_ProveedorNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_PROVEEDORNOMBRE", GetSecureSignedToken( sPrefix, AV45IsAuthorized_ProveedorNombre, context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV44GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV39DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV39DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8ProfComisionesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8ProfComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV46Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFCOMISIONESRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17TFProfComisionesRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFCOMISIONESRUBROSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18TFProfComisionesRubrosId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19TFRubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFRUBROSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20TFRubrosId_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMEDIDASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21TFMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMEDIDASID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22TFMedidasID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFINVENTARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23TFInventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFINVENTARIOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24TFInventarioId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFINVENTARIOPRECIOFINAL", StringUtil.LTrim( StringUtil.NToC( AV25TFInventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFINVENTARIOPRECIOFINAL_TO", StringUtil.LTrim( StringUtil.NToC( AV26TFInventarioPrecioFinal_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFPROFCOMISIONESRUBROSTIPO_SELS", AV28TFProfComisionesRubrosTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFPROFCOMISIONESRUBROSTIPO_SELS", AV28TFProfComisionesRubrosTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFCOMISIONESRUBROSVALOR", StringUtil.LTrim( StringUtil.NToC( AV29TFProfComisionesRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFCOMISIONESRUBROSVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV30TFProfComisionesRubrosValor_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFCOMISIONESRUBROSGAN", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TFProfComisionesRubrosGan), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFCOMISIONESRUBROSGAN_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TFProfComisionesRubrosGan_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFCOMISIONESRUBROSGANPRF", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33TFProfComisionesRubrosGanPRF), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFCOMISIONESRUBROSGANPRF_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34TFProfComisionesRubrosGanPRF_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35TFProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROVEEDORID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36TFProveedorID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROVEEDORNOMBRE", StringUtil.RTrim( AV37TFProveedorNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROVEEDORNOMBRE_SEL", StringUtil.RTrim( AV38TFProveedorNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROFCOMISIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ProfComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_PROVEEDORNOMBRE", AV45IsAuthorized_ProveedorNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_PROVEEDORNOMBRE", GetSecureSignedToken( sPrefix, AV45IsAuthorized_ProveedorNombre, context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
      }

      protected void RenderHtmlCloseForm3Q2( )
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
         return "ProfComisionesRubrosWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Prof Comisiones Rubros WC", "") ;
      }

      protected void WB3Q0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "profcomisionesrubroswc.aspx");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV42GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV43GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV44GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV39DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProfComisionesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A450ProfComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A450ProfComisionesID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfComisionesID_Jsonclick, 0, "Attribute", "", "", "", "", edtProfComisionesID_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ProfComisionesRubrosWC.htm");
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

      protected void START3Q2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Prof Comisiones Rubros WC", ""), 0) ;
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
               STRUP3Q0( ) ;
            }
         }
      }

      protected void WS3Q2( )
      {
         START3Q2( ) ;
         EVT3Q2( ) ;
      }

      protected void EVT3Q2( )
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
                                 STRUP3Q0( ) ;
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
                                 STRUP3Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E113Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E123Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E133Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Q0( ) ;
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
                                 STRUP3Q0( ) ;
                              }
                              nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              A452ProfComisionesRubrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfComisionesRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A137MedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMedidasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A135InventarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtInventarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A190InventarioCosto = context.localUtil.CToN( cgiGet( edtInventarioCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A181InventarioPrecioFinal = context.localUtil.CToN( cgiGet( edtInventarioPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              cmbProfComisionesRubrosTipo.Name = cmbProfComisionesRubrosTipo_Internalname;
                              cmbProfComisionesRubrosTipo.CurrentValue = cgiGet( cmbProfComisionesRubrosTipo_Internalname);
                              A453ProfComisionesRubrosTipo = cgiGet( cmbProfComisionesRubrosTipo_Internalname);
                              A454ProfComisionesRubrosValor = context.localUtil.CToN( cgiGet( edtProfComisionesRubrosValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A456ProfComisionesRubrosGan = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfComisionesRubrosGan_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A457ProfComisionesRubrosGanPRF = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfComisionesRubrosGanPRF_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n133ProveedorID = false;
                              A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
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
                                          E143Q2 ();
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
                                          E153Q2 ();
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
                                          E163Q2 ();
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
                                       STRUP3Q0( ) ;
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

      protected void WE3Q2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3Q2( ) ;
            }
         }
      }

      protected void PA3Q2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "profcomisionesrubroswc.aspx")), "profcomisionesrubroswc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "profcomisionesrubroswc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ProfComisionesID");
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
                                       long AV8ProfComisionesID ,
                                       string AV46Pgmname ,
                                       long AV17TFProfComisionesRubrosId ,
                                       long AV18TFProfComisionesRubrosId_To ,
                                       short AV19TFRubrosId ,
                                       short AV20TFRubrosId_To ,
                                       long AV21TFMedidasID ,
                                       long AV22TFMedidasID_To ,
                                       long AV23TFInventarioId ,
                                       long AV24TFInventarioId_To ,
                                       decimal AV25TFInventarioPrecioFinal ,
                                       decimal AV26TFInventarioPrecioFinal_To ,
                                       GxSimpleCollection<string> AV28TFProfComisionesRubrosTipo_Sels ,
                                       decimal AV29TFProfComisionesRubrosValor ,
                                       decimal AV30TFProfComisionesRubrosValor_To ,
                                       long AV31TFProfComisionesRubrosGan ,
                                       long AV32TFProfComisionesRubrosGan_To ,
                                       long AV33TFProfComisionesRubrosGanPRF ,
                                       long AV34TFProfComisionesRubrosGanPRF_To ,
                                       long AV35TFProveedorID ,
                                       long AV36TFProveedorID_To ,
                                       string AV37TFProveedorNombre ,
                                       string AV38TFProveedorNombre_Sel ,
                                       bool AV45IsAuthorized_ProveedorNombre ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3Q2( ) ;
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
         RF3Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV46Pgmname = "ProfComisionesRubrosWC";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A453ProfComisionesRubrosTipo ,
                                              AV28TFProfComisionesRubrosTipo_Sels ,
                                              AV17TFProfComisionesRubrosId ,
                                              AV18TFProfComisionesRubrosId_To ,
                                              AV19TFRubrosId ,
                                              AV20TFRubrosId_To ,
                                              AV21TFMedidasID ,
                                              AV22TFMedidasID_To ,
                                              AV23TFInventarioId ,
                                              AV24TFInventarioId_To ,
                                              AV25TFInventarioPrecioFinal ,
                                              AV26TFInventarioPrecioFinal_To ,
                                              AV28TFProfComisionesRubrosTipo_Sels.Count ,
                                              AV29TFProfComisionesRubrosValor ,
                                              AV30TFProfComisionesRubrosValor_To ,
                                              AV35TFProveedorID ,
                                              AV36TFProveedorID_To ,
                                              AV38TFProveedorNombre_Sel ,
                                              AV37TFProveedorNombre ,
                                              A452ProfComisionesRubrosId ,
                                              A121RubrosId ,
                                              A137MedidasID ,
                                              A135InventarioId ,
                                              A181InventarioPrecioFinal ,
                                              A454ProfComisionesRubrosValor ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV31TFProfComisionesRubrosGan ,
                                              A456ProfComisionesRubrosGan ,
                                              AV32TFProfComisionesRubrosGan_To ,
                                              AV33TFProfComisionesRubrosGanPRF ,
                                              A457ProfComisionesRubrosGanPRF ,
                                              AV34TFProfComisionesRubrosGanPRF_To ,
                                              AV8ProfComisionesID ,
                                              A450ProfComisionesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV37TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV37TFProveedorNombre), 80, "%");
         /* Using cursor H003Q2 */
         pr_default.execute(0, new Object[] {AV8ProfComisionesID, AV17TFProfComisionesRubrosId, AV18TFProfComisionesRubrosId_To, AV19TFRubrosId, AV20TFRubrosId_To, AV21TFMedidasID, AV22TFMedidasID_To, AV23TFInventarioId, AV24TFInventarioId_To, AV25TFInventarioPrecioFinal, AV26TFInventarioPrecioFinal_To, AV29TFProfComisionesRubrosValor, AV30TFProfComisionesRubrosValor_To, AV35TFProveedorID, AV36TFProveedorID_To, lV37TFProveedorNombre, AV38TFProveedorNombre_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A450ProfComisionesID = H003Q2_A450ProfComisionesID[0];
            AssignAttri(sPrefix, false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
            A282ProveedorNombre = H003Q2_A282ProveedorNombre[0];
            A133ProveedorID = H003Q2_A133ProveedorID[0];
            n133ProveedorID = H003Q2_n133ProveedorID[0];
            A190InventarioCosto = H003Q2_A190InventarioCosto[0];
            A135InventarioId = H003Q2_A135InventarioId[0];
            A137MedidasID = H003Q2_A137MedidasID[0];
            A121RubrosId = H003Q2_A121RubrosId[0];
            A452ProfComisionesRubrosId = H003Q2_A452ProfComisionesRubrosId[0];
            A181InventarioPrecioFinal = H003Q2_A181InventarioPrecioFinal[0];
            A453ProfComisionesRubrosTipo = H003Q2_A453ProfComisionesRubrosTipo[0];
            A454ProfComisionesRubrosValor = H003Q2_A454ProfComisionesRubrosValor[0];
            A282ProveedorNombre = H003Q2_A282ProveedorNombre[0];
            A190InventarioCosto = H003Q2_A190InventarioCosto[0];
            A181InventarioPrecioFinal = H003Q2_A181InventarioPrecioFinal[0];
            if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "F", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
            {
               A457ProfComisionesRubrosGanPRF = (long)(Math.Round(A454ProfComisionesRubrosValor, 18, MidpointRounding.ToEven));
            }
            else
            {
               if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "P", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
               {
                  A457ProfComisionesRubrosGanPRF = (long)(A181InventarioPrecioFinal*(A454ProfComisionesRubrosValor/ (decimal)(100)));
               }
               else
               {
                  A457ProfComisionesRubrosGanPRF = 0;
               }
            }
            if ( (0==AV33TFProfComisionesRubrosGanPRF) || ( ( A457ProfComisionesRubrosGanPRF >= AV33TFProfComisionesRubrosGanPRF ) ) )
            {
               if ( (0==AV34TFProfComisionesRubrosGanPRF_To) || ( ( A457ProfComisionesRubrosGanPRF <= AV34TFProfComisionesRubrosGanPRF_To ) ) )
               {
                  A456ProfComisionesRubrosGan = (long)(A181InventarioPrecioFinal-A457ProfComisionesRubrosGanPRF);
                  if ( (0==AV31TFProfComisionesRubrosGan) || ( ( A456ProfComisionesRubrosGan >= AV31TFProfComisionesRubrosGan ) ) )
                  {
                     if ( (0==AV32TFProfComisionesRubrosGan_To) || ( ( A456ProfComisionesRubrosGan <= AV32TFProfComisionesRubrosGan_To ) ) )
                     {
                        GRID_nRecordCount = (long)(GRID_nRecordCount+1);
                     }
                  }
               }
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF3Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 15;
         /* Execute user event: Refresh */
         E153Q2 ();
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
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A453ProfComisionesRubrosTipo ,
                                                 AV28TFProfComisionesRubrosTipo_Sels ,
                                                 AV17TFProfComisionesRubrosId ,
                                                 AV18TFProfComisionesRubrosId_To ,
                                                 AV19TFRubrosId ,
                                                 AV20TFRubrosId_To ,
                                                 AV21TFMedidasID ,
                                                 AV22TFMedidasID_To ,
                                                 AV23TFInventarioId ,
                                                 AV24TFInventarioId_To ,
                                                 AV25TFInventarioPrecioFinal ,
                                                 AV26TFInventarioPrecioFinal_To ,
                                                 AV28TFProfComisionesRubrosTipo_Sels.Count ,
                                                 AV29TFProfComisionesRubrosValor ,
                                                 AV30TFProfComisionesRubrosValor_To ,
                                                 AV35TFProveedorID ,
                                                 AV36TFProveedorID_To ,
                                                 AV38TFProveedorNombre_Sel ,
                                                 AV37TFProveedorNombre ,
                                                 A452ProfComisionesRubrosId ,
                                                 A121RubrosId ,
                                                 A137MedidasID ,
                                                 A135InventarioId ,
                                                 A181InventarioPrecioFinal ,
                                                 A454ProfComisionesRubrosValor ,
                                                 A133ProveedorID ,
                                                 A282ProveedorNombre ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV31TFProfComisionesRubrosGan ,
                                                 A456ProfComisionesRubrosGan ,
                                                 AV32TFProfComisionesRubrosGan_To ,
                                                 AV33TFProfComisionesRubrosGanPRF ,
                                                 A457ProfComisionesRubrosGanPRF ,
                                                 AV34TFProfComisionesRubrosGanPRF_To ,
                                                 AV8ProfComisionesID ,
                                                 A450ProfComisionesID } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV37TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV37TFProveedorNombre), 80, "%");
            /* Using cursor H003Q3 */
            pr_default.execute(1, new Object[] {AV8ProfComisionesID, AV17TFProfComisionesRubrosId, AV18TFProfComisionesRubrosId_To, AV19TFRubrosId, AV20TFRubrosId_To, AV21TFMedidasID, AV22TFMedidasID_To, AV23TFInventarioId, AV24TFInventarioId_To, AV25TFInventarioPrecioFinal, AV26TFInventarioPrecioFinal_To, AV29TFProfComisionesRubrosValor, AV30TFProfComisionesRubrosValor_To, AV35TFProveedorID, AV36TFProveedorID_To, lV37TFProveedorNombre, AV38TFProveedorNombre_Sel});
            nGXsfl_15_idx = 1;
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A450ProfComisionesID = H003Q3_A450ProfComisionesID[0];
               AssignAttri(sPrefix, false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
               A282ProveedorNombre = H003Q3_A282ProveedorNombre[0];
               A133ProveedorID = H003Q3_A133ProveedorID[0];
               n133ProveedorID = H003Q3_n133ProveedorID[0];
               A190InventarioCosto = H003Q3_A190InventarioCosto[0];
               A135InventarioId = H003Q3_A135InventarioId[0];
               A137MedidasID = H003Q3_A137MedidasID[0];
               A121RubrosId = H003Q3_A121RubrosId[0];
               A452ProfComisionesRubrosId = H003Q3_A452ProfComisionesRubrosId[0];
               A181InventarioPrecioFinal = H003Q3_A181InventarioPrecioFinal[0];
               A453ProfComisionesRubrosTipo = H003Q3_A453ProfComisionesRubrosTipo[0];
               A454ProfComisionesRubrosValor = H003Q3_A454ProfComisionesRubrosValor[0];
               A282ProveedorNombre = H003Q3_A282ProveedorNombre[0];
               A190InventarioCosto = H003Q3_A190InventarioCosto[0];
               A181InventarioPrecioFinal = H003Q3_A181InventarioPrecioFinal[0];
               if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "F", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
               {
                  A457ProfComisionesRubrosGanPRF = (long)(Math.Round(A454ProfComisionesRubrosValor, 18, MidpointRounding.ToEven));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "P", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
                  {
                     A457ProfComisionesRubrosGanPRF = (long)(A181InventarioPrecioFinal*(A454ProfComisionesRubrosValor/ (decimal)(100)));
                  }
                  else
                  {
                     A457ProfComisionesRubrosGanPRF = 0;
                  }
               }
               if ( (0==AV33TFProfComisionesRubrosGanPRF) || ( ( A457ProfComisionesRubrosGanPRF >= AV33TFProfComisionesRubrosGanPRF ) ) )
               {
                  if ( (0==AV34TFProfComisionesRubrosGanPRF_To) || ( ( A457ProfComisionesRubrosGanPRF <= AV34TFProfComisionesRubrosGanPRF_To ) ) )
                  {
                     A456ProfComisionesRubrosGan = (long)(A181InventarioPrecioFinal-A457ProfComisionesRubrosGanPRF);
                     if ( (0==AV31TFProfComisionesRubrosGan) || ( ( A456ProfComisionesRubrosGan >= AV31TFProfComisionesRubrosGan ) ) )
                     {
                        if ( (0==AV32TFProfComisionesRubrosGan_To) || ( ( A456ProfComisionesRubrosGan <= AV32TFProfComisionesRubrosGan_To ) ) )
                        {
                           /* Execute user event: Grid.Load */
                           E163Q2 ();
                        }
                     }
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 15;
            WB3Q0( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3Q2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV46Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_PROVEEDORNOMBRE", AV45IsAuthorized_ProveedorNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_PROVEEDORNOMBRE", GetSecureSignedToken( sPrefix, AV45IsAuthorized_ProveedorNombre, context));
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ProfComisionesID, AV46Pgmname, AV17TFProfComisionesRubrosId, AV18TFProfComisionesRubrosId_To, AV19TFRubrosId, AV20TFRubrosId_To, AV21TFMedidasID, AV22TFMedidasID_To, AV23TFInventarioId, AV24TFInventarioId_To, AV25TFInventarioPrecioFinal, AV26TFInventarioPrecioFinal_To, AV28TFProfComisionesRubrosTipo_Sels, AV29TFProfComisionesRubrosValor, AV30TFProfComisionesRubrosValor_To, AV31TFProfComisionesRubrosGan, AV32TFProfComisionesRubrosGan_To, AV33TFProfComisionesRubrosGanPRF, AV34TFProfComisionesRubrosGanPRF_To, AV35TFProveedorID, AV36TFProveedorID_To, AV37TFProveedorNombre, AV38TFProveedorNombre_Sel, AV45IsAuthorized_ProveedorNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ProfComisionesID, AV46Pgmname, AV17TFProfComisionesRubrosId, AV18TFProfComisionesRubrosId_To, AV19TFRubrosId, AV20TFRubrosId_To, AV21TFMedidasID, AV22TFMedidasID_To, AV23TFInventarioId, AV24TFInventarioId_To, AV25TFInventarioPrecioFinal, AV26TFInventarioPrecioFinal_To, AV28TFProfComisionesRubrosTipo_Sels, AV29TFProfComisionesRubrosValor, AV30TFProfComisionesRubrosValor_To, AV31TFProfComisionesRubrosGan, AV32TFProfComisionesRubrosGan_To, AV33TFProfComisionesRubrosGanPRF, AV34TFProfComisionesRubrosGanPRF_To, AV35TFProveedorID, AV36TFProveedorID_To, AV37TFProveedorNombre, AV38TFProveedorNombre_Sel, AV45IsAuthorized_ProveedorNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ProfComisionesID, AV46Pgmname, AV17TFProfComisionesRubrosId, AV18TFProfComisionesRubrosId_To, AV19TFRubrosId, AV20TFRubrosId_To, AV21TFMedidasID, AV22TFMedidasID_To, AV23TFInventarioId, AV24TFInventarioId_To, AV25TFInventarioPrecioFinal, AV26TFInventarioPrecioFinal_To, AV28TFProfComisionesRubrosTipo_Sels, AV29TFProfComisionesRubrosValor, AV30TFProfComisionesRubrosValor_To, AV31TFProfComisionesRubrosGan, AV32TFProfComisionesRubrosGan_To, AV33TFProfComisionesRubrosGanPRF, AV34TFProfComisionesRubrosGanPRF_To, AV35TFProveedorID, AV36TFProveedorID_To, AV37TFProveedorNombre, AV38TFProveedorNombre_Sel, AV45IsAuthorized_ProveedorNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ProfComisionesID, AV46Pgmname, AV17TFProfComisionesRubrosId, AV18TFProfComisionesRubrosId_To, AV19TFRubrosId, AV20TFRubrosId_To, AV21TFMedidasID, AV22TFMedidasID_To, AV23TFInventarioId, AV24TFInventarioId_To, AV25TFInventarioPrecioFinal, AV26TFInventarioPrecioFinal_To, AV28TFProfComisionesRubrosTipo_Sels, AV29TFProfComisionesRubrosValor, AV30TFProfComisionesRubrosValor_To, AV31TFProfComisionesRubrosGan, AV32TFProfComisionesRubrosGan_To, AV33TFProfComisionesRubrosGanPRF, AV34TFProfComisionesRubrosGanPRF_To, AV35TFProveedorID, AV36TFProveedorID_To, AV37TFProveedorNombre, AV38TFProveedorNombre_Sel, AV45IsAuthorized_ProveedorNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ProfComisionesID, AV46Pgmname, AV17TFProfComisionesRubrosId, AV18TFProfComisionesRubrosId_To, AV19TFRubrosId, AV20TFRubrosId_To, AV21TFMedidasID, AV22TFMedidasID_To, AV23TFInventarioId, AV24TFInventarioId_To, AV25TFInventarioPrecioFinal, AV26TFInventarioPrecioFinal_To, AV28TFProfComisionesRubrosTipo_Sels, AV29TFProfComisionesRubrosValor, AV30TFProfComisionesRubrosValor_To, AV31TFProfComisionesRubrosGan, AV32TFProfComisionesRubrosGan_To, AV33TFProfComisionesRubrosGanPRF, AV34TFProfComisionesRubrosGanPRF_To, AV35TFProveedorID, AV36TFProveedorID_To, AV37TFProveedorNombre, AV38TFProveedorNombre_Sel, AV45IsAuthorized_ProveedorNombre, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV46Pgmname = "ProfComisionesRubrosWC";
         edtProfComisionesRubrosId_Enabled = 0;
         edtRubrosId_Enabled = 0;
         edtMedidasID_Enabled = 0;
         edtInventarioId_Enabled = 0;
         edtInventarioCosto_Enabled = 0;
         edtInventarioPrecioFinal_Enabled = 0;
         cmbProfComisionesRubrosTipo.Enabled = 0;
         edtProfComisionesRubrosValor_Enabled = 0;
         edtProfComisionesRubrosGan_Enabled = 0;
         edtProfComisionesRubrosGanPRF_Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         edtProfComisionesID_Enabled = 0;
         AssignProp(sPrefix, false, edtProfComisionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfComisionesID_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E143Q2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV39DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_15 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_15"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV42GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV43GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV44GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOAV8ProfComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8ProfComisionesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            /* Read variables values. */
            A450ProfComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfComisionesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
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
         E143Q2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E143Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         GXt_boolean1 = AV45IsAuthorized_ProveedorNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor", out  GXt_boolean1) ;
         AV45IsAuthorized_ProveedorNombre = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV45IsAuthorized_ProveedorNombre", AV45IsAuthorized_ProveedorNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_PROVEEDORNOMBRE", GetSecureSignedToken( sPrefix, AV45IsAuthorized_ProveedorNombre, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         edtProfComisionesID_Visible = 0;
         AssignProp(sPrefix, false, edtProfComisionesID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfComisionesID_Visible), 5, 0), true);
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV39DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV39DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E153Q2( )
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
         AV42GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV42GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV42GridCurrentPage), 10, 0));
         AV43GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV43GridPageCount", StringUtil.LTrimStr( (decimal)(AV43GridPageCount), 10, 0));
         GXt_char3 = AV44GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV46Pgmname, out  GXt_char3) ;
         AV44GridAppliedFilters = GXt_char3;
         AssignAttri(sPrefix, false, "AV44GridAppliedFilters", AV44GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E113Q2( )
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
            AV41PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV41PageToGo) ;
         }
         /*  Sending Event outputs  */
      }

      protected void E123Q2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E133Q2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfComisionesRubrosId") == 0 )
            {
               AV17TFProfComisionesRubrosId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV17TFProfComisionesRubrosId", StringUtil.LTrimStr( (decimal)(AV17TFProfComisionesRubrosId), 18, 0));
               AV18TFProfComisionesRubrosId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV18TFProfComisionesRubrosId_To", StringUtil.LTrimStr( (decimal)(AV18TFProfComisionesRubrosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RubrosId") == 0 )
            {
               AV19TFRubrosId = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV19TFRubrosId", StringUtil.LTrimStr( (decimal)(AV19TFRubrosId), 4, 0));
               AV20TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV20TFRubrosId_To", StringUtil.LTrimStr( (decimal)(AV20TFRubrosId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MedidasID") == 0 )
            {
               AV21TFMedidasID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV21TFMedidasID", StringUtil.LTrimStr( (decimal)(AV21TFMedidasID), 18, 0));
               AV22TFMedidasID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV22TFMedidasID_To", StringUtil.LTrimStr( (decimal)(AV22TFMedidasID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "InventarioId") == 0 )
            {
               AV23TFInventarioId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV23TFInventarioId", StringUtil.LTrimStr( (decimal)(AV23TFInventarioId), 18, 0));
               AV24TFInventarioId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV24TFInventarioId_To", StringUtil.LTrimStr( (decimal)(AV24TFInventarioId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "InventarioPrecioFinal") == 0 )
            {
               AV25TFInventarioPrecioFinal = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV25TFInventarioPrecioFinal", StringUtil.LTrimStr( AV25TFInventarioPrecioFinal, 18, 2));
               AV26TFInventarioPrecioFinal_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV26TFInventarioPrecioFinal_To", StringUtil.LTrimStr( AV26TFInventarioPrecioFinal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfComisionesRubrosTipo") == 0 )
            {
               AV27TFProfComisionesRubrosTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV27TFProfComisionesRubrosTipo_SelsJson", AV27TFProfComisionesRubrosTipo_SelsJson);
               AV28TFProfComisionesRubrosTipo_Sels.FromJSonString(AV27TFProfComisionesRubrosTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfComisionesRubrosValor") == 0 )
            {
               AV29TFProfComisionesRubrosValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV29TFProfComisionesRubrosValor", StringUtil.LTrimStr( AV29TFProfComisionesRubrosValor, 18, 2));
               AV30TFProfComisionesRubrosValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV30TFProfComisionesRubrosValor_To", StringUtil.LTrimStr( AV30TFProfComisionesRubrosValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfComisionesRubrosGan") == 0 )
            {
               AV31TFProfComisionesRubrosGan = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV31TFProfComisionesRubrosGan", StringUtil.LTrimStr( (decimal)(AV31TFProfComisionesRubrosGan), 18, 0));
               AV32TFProfComisionesRubrosGan_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV32TFProfComisionesRubrosGan_To", StringUtil.LTrimStr( (decimal)(AV32TFProfComisionesRubrosGan_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfComisionesRubrosGanPRF") == 0 )
            {
               AV33TFProfComisionesRubrosGanPRF = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV33TFProfComisionesRubrosGanPRF", StringUtil.LTrimStr( (decimal)(AV33TFProfComisionesRubrosGanPRF), 18, 0));
               AV34TFProfComisionesRubrosGanPRF_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV34TFProfComisionesRubrosGanPRF_To", StringUtil.LTrimStr( (decimal)(AV34TFProfComisionesRubrosGanPRF_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorID") == 0 )
            {
               AV35TFProveedorID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV35TFProveedorID", StringUtil.LTrimStr( (decimal)(AV35TFProveedorID), 18, 0));
               AV36TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV36TFProveedorID_To", StringUtil.LTrimStr( (decimal)(AV36TFProveedorID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorNombre") == 0 )
            {
               AV37TFProveedorNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV37TFProveedorNombre", AV37TFProveedorNombre);
               AV38TFProveedorNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV38TFProveedorNombre_Sel", AV38TFProveedorNombre_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28TFProfComisionesRubrosTipo_Sels", AV28TFProfComisionesRubrosTipo_Sels);
      }

      private void E163Q2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            if ( AV45IsAuthorized_ProveedorNombre )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "proveedorview.aspx"+UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtProveedorNombre_Link = formatLink("proveedorview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 15;
            }
            sendrow_152( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
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
         if ( StringUtil.StrCmp(AV16Session.Get(AV46Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV46Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV16Session.Get(AV46Pgmname+"GridState"), null, "", "");
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
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFCOMISIONESRUBROSID") == 0 )
            {
               AV17TFProfComisionesRubrosId = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV17TFProfComisionesRubrosId", StringUtil.LTrimStr( (decimal)(AV17TFProfComisionesRubrosId), 18, 0));
               AV18TFProfComisionesRubrosId_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV18TFProfComisionesRubrosId_To", StringUtil.LTrimStr( (decimal)(AV18TFProfComisionesRubrosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV19TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV19TFRubrosId", StringUtil.LTrimStr( (decimal)(AV19TFRubrosId), 4, 0));
               AV20TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV20TFRubrosId_To", StringUtil.LTrimStr( (decimal)(AV20TFRubrosId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFMEDIDASID") == 0 )
            {
               AV21TFMedidasID = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV21TFMedidasID", StringUtil.LTrimStr( (decimal)(AV21TFMedidasID), 18, 0));
               AV22TFMedidasID_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV22TFMedidasID_To", StringUtil.LTrimStr( (decimal)(AV22TFMedidasID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFINVENTARIOID") == 0 )
            {
               AV23TFInventarioId = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV23TFInventarioId", StringUtil.LTrimStr( (decimal)(AV23TFInventarioId), 18, 0));
               AV24TFInventarioId_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV24TFInventarioId_To", StringUtil.LTrimStr( (decimal)(AV24TFInventarioId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFINVENTARIOPRECIOFINAL") == 0 )
            {
               AV25TFInventarioPrecioFinal = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV25TFInventarioPrecioFinal", StringUtil.LTrimStr( AV25TFInventarioPrecioFinal, 18, 2));
               AV26TFInventarioPrecioFinal_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV26TFInventarioPrecioFinal_To", StringUtil.LTrimStr( AV26TFInventarioPrecioFinal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFCOMISIONESRUBROSTIPO_SEL") == 0 )
            {
               AV27TFProfComisionesRubrosTipo_SelsJson = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV27TFProfComisionesRubrosTipo_SelsJson", AV27TFProfComisionesRubrosTipo_SelsJson);
               AV28TFProfComisionesRubrosTipo_Sels.FromJSonString(AV27TFProfComisionesRubrosTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFCOMISIONESRUBROSVALOR") == 0 )
            {
               AV29TFProfComisionesRubrosValor = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV29TFProfComisionesRubrosValor", StringUtil.LTrimStr( AV29TFProfComisionesRubrosValor, 18, 2));
               AV30TFProfComisionesRubrosValor_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV30TFProfComisionesRubrosValor_To", StringUtil.LTrimStr( AV30TFProfComisionesRubrosValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFCOMISIONESRUBROSGAN") == 0 )
            {
               AV31TFProfComisionesRubrosGan = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV31TFProfComisionesRubrosGan", StringUtil.LTrimStr( (decimal)(AV31TFProfComisionesRubrosGan), 18, 0));
               AV32TFProfComisionesRubrosGan_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV32TFProfComisionesRubrosGan_To", StringUtil.LTrimStr( (decimal)(AV32TFProfComisionesRubrosGan_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFCOMISIONESRUBROSGANPRF") == 0 )
            {
               AV33TFProfComisionesRubrosGanPRF = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV33TFProfComisionesRubrosGanPRF", StringUtil.LTrimStr( (decimal)(AV33TFProfComisionesRubrosGanPRF), 18, 0));
               AV34TFProfComisionesRubrosGanPRF_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV34TFProfComisionesRubrosGanPRF_To", StringUtil.LTrimStr( (decimal)(AV34TFProfComisionesRubrosGanPRF_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV35TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV35TFProveedorID", StringUtil.LTrimStr( (decimal)(AV35TFProveedorID), 18, 0));
               AV36TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV36TFProveedorID_To", StringUtil.LTrimStr( (decimal)(AV36TFProveedorID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV37TFProveedorNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV37TFProveedorNombre", AV37TFProveedorNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV38TFProveedorNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV38TFProveedorNombre_Sel", AV38TFProveedorNombre_Sel);
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV28TFProfComisionesRubrosTipo_Sels.Count==0),  AV27TFProfComisionesRubrosTipo_SelsJson, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFProveedorNombre_Sel)),  AV38TFProveedorNombre_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = "|||||"+GXt_char3+"|||||"+GXt_char4;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFProveedorNombre)),  AV37TFProveedorNombre, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = ((0==AV17TFProfComisionesRubrosId) ? "" : StringUtil.Str( (decimal)(AV17TFProfComisionesRubrosId), 18, 0))+"|"+((0==AV19TFRubrosId) ? "" : StringUtil.Str( (decimal)(AV19TFRubrosId), 4, 0))+"|"+((0==AV21TFMedidasID) ? "" : StringUtil.Str( (decimal)(AV21TFMedidasID), 18, 0))+"|"+((0==AV23TFInventarioId) ? "" : StringUtil.Str( (decimal)(AV23TFInventarioId), 18, 0))+"|"+((Convert.ToDecimal(0)==AV25TFInventarioPrecioFinal) ? "" : StringUtil.Str( AV25TFInventarioPrecioFinal, 18, 2))+"||"+((Convert.ToDecimal(0)==AV29TFProfComisionesRubrosValor) ? "" : StringUtil.Str( AV29TFProfComisionesRubrosValor, 18, 2))+"|"+((0==AV31TFProfComisionesRubrosGan) ? "" : StringUtil.Str( (decimal)(AV31TFProfComisionesRubrosGan), 18, 0))+"|"+((0==AV33TFProfComisionesRubrosGanPRF) ? "" : StringUtil.Str( (decimal)(AV33TFProfComisionesRubrosGanPRF), 18, 0))+"|"+((0==AV35TFProveedorID) ? "" : StringUtil.Str( (decimal)(AV35TFProveedorID), 18, 0))+"|"+GXt_char4;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV18TFProfComisionesRubrosId_To) ? "" : StringUtil.Str( (decimal)(AV18TFProfComisionesRubrosId_To), 18, 0))+"|"+((0==AV20TFRubrosId_To) ? "" : StringUtil.Str( (decimal)(AV20TFRubrosId_To), 4, 0))+"|"+((0==AV22TFMedidasID_To) ? "" : StringUtil.Str( (decimal)(AV22TFMedidasID_To), 18, 0))+"|"+((0==AV24TFInventarioId_To) ? "" : StringUtil.Str( (decimal)(AV24TFInventarioId_To), 18, 0))+"|"+((Convert.ToDecimal(0)==AV26TFInventarioPrecioFinal_To) ? "" : StringUtil.Str( AV26TFInventarioPrecioFinal_To, 18, 2))+"||"+((Convert.ToDecimal(0)==AV30TFProfComisionesRubrosValor_To) ? "" : StringUtil.Str( AV30TFProfComisionesRubrosValor_To, 18, 2))+"|"+((0==AV32TFProfComisionesRubrosGan_To) ? "" : StringUtil.Str( (decimal)(AV32TFProfComisionesRubrosGan_To), 18, 0))+"|"+((0==AV34TFProfComisionesRubrosGanPRF_To) ? "" : StringUtil.Str( (decimal)(AV34TFProfComisionesRubrosGanPRF_To), 18, 0))+"|"+((0==AV36TFProveedorID_To) ? "" : StringUtil.Str( (decimal)(AV36TFProveedorID_To), 18, 0))+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
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
         AV12GridState.FromXml(AV16Session.Get(AV46Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFPROFCOMISIONESRUBROSID",  context.GetMessage( "No.", ""),  !((0==AV17TFProfComisionesRubrosId)&&(0==AV18TFProfComisionesRubrosId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV17TFProfComisionesRubrosId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV18TFProfComisionesRubrosId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFRUBROSID",  context.GetMessage( "Rubros Identificador ", ""),  !((0==AV19TFRubrosId)&&(0==AV20TFRubrosId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV19TFRubrosId), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV20TFRubrosId_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFMEDIDASID",  context.GetMessage( "Items/Característica", ""),  !((0==AV21TFMedidasID)&&(0==AV22TFMedidasID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV21TFMedidasID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV22TFMedidasID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFINVENTARIOID",  context.GetMessage( "Detalle", ""),  !((0==AV23TFInventarioId)&&(0==AV24TFInventarioId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV23TFInventarioId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV24TFInventarioId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFINVENTARIOPRECIOFINAL",  context.GetMessage( "Precio", ""),  !((Convert.ToDecimal(0)==AV25TFInventarioPrecioFinal)&&(Convert.ToDecimal(0)==AV26TFInventarioPrecioFinal_To)),  0,  StringUtil.Trim( StringUtil.Str( AV25TFInventarioPrecioFinal, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV26TFInventarioPrecioFinal_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFPROFCOMISIONESRUBROSTIPO_SEL",  context.GetMessage( "Tipo de Comisión", ""),  !(AV28TFProfComisionesRubrosTipo_Sels.Count==0),  0,  AV28TFProfComisionesRubrosTipo_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFPROFCOMISIONESRUBROSVALOR",  context.GetMessage( "Valor/Costo", ""),  !((Convert.ToDecimal(0)==AV29TFProfComisionesRubrosValor)&&(Convert.ToDecimal(0)==AV30TFProfComisionesRubrosValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV29TFProfComisionesRubrosValor, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV30TFProfComisionesRubrosValor_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFPROFCOMISIONESRUBROSGAN",  context.GetMessage( "Ganancia-ALM", ""),  !((0==AV31TFProfComisionesRubrosGan)&&(0==AV32TFProfComisionesRubrosGan_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31TFProfComisionesRubrosGan), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV32TFProfComisionesRubrosGan_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFPROFCOMISIONESRUBROSGANPRF",  context.GetMessage( "Ganancia-PRF", ""),  !((0==AV33TFProfComisionesRubrosGanPRF)&&(0==AV34TFProfComisionesRubrosGanPRF_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV33TFProfComisionesRubrosGanPRF), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV34TFProfComisionesRubrosGanPRF_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFPROVEEDORID",  context.GetMessage( "Código del Proveedor", ""),  !((0==AV35TFProveedorID)&&(0==AV36TFProveedorID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV35TFProveedorID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV36TFProveedorID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFPROVEEDORNOMBRE",  context.GetMessage( "Proveedor Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFProveedorNombre)),  0,  AV37TFProveedorNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFProveedorNombre_Sel)),  AV38TFProveedorNombre_Sel,  "") ;
         if ( ! (0==AV8ProfComisionesID) )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = "PARM_&PROFCOMISIONESID";
            AV13GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV8ProfComisionesID), 18, 0);
            AV12GridState.gxTpr_Filtervalues.Add(AV13GridStateFilterValue, 0);
         }
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV46Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV46Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "ProfComisiones";
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "ProfComisionesID";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8ProfComisionesID), 18, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV16Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8ProfComisionesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV8ProfComisionesID", StringUtil.LTrimStr( (decimal)(AV8ProfComisionesID), 18, 0));
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
         PA3Q2( ) ;
         WS3Q2( ) ;
         WE3Q2( ) ;
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
         sCtrlAV8ProfComisionesID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3Q2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "profcomisionesrubroswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3Q2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8ProfComisionesID = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV8ProfComisionesID", StringUtil.LTrimStr( (decimal)(AV8ProfComisionesID), 18, 0));
         }
         wcpOAV8ProfComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8ProfComisionesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV8ProfComisionesID != wcpOAV8ProfComisionesID ) ) )
         {
            setjustcreated();
         }
         wcpOAV8ProfComisionesID = AV8ProfComisionesID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8ProfComisionesID = cgiGet( sPrefix+"AV8ProfComisionesID_CTRL");
         if ( StringUtil.Len( sCtrlAV8ProfComisionesID) > 0 )
         {
            AV8ProfComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8ProfComisionesID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8ProfComisionesID", StringUtil.LTrimStr( (decimal)(AV8ProfComisionesID), 18, 0));
         }
         else
         {
            AV8ProfComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8ProfComisionesID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA3Q2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3Q2( ) ;
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
         WS3Q2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8ProfComisionesID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ProfComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8ProfComisionesID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8ProfComisionesID_CTRL", StringUtil.RTrim( sCtrlAV8ProfComisionesID));
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
         WE3Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269319521866", true, true, false);
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
         context.AddJavascriptSource("profcomisionesrubroswc.js", "?20269319521867", false, true, false);
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
         edtProfComisionesRubrosId_Internalname = sPrefix+"PROFCOMISIONESRUBROSID_"+sGXsfl_15_idx;
         edtRubrosId_Internalname = sPrefix+"RUBROSID_"+sGXsfl_15_idx;
         edtMedidasID_Internalname = sPrefix+"MEDIDASID_"+sGXsfl_15_idx;
         edtInventarioId_Internalname = sPrefix+"INVENTARIOID_"+sGXsfl_15_idx;
         edtInventarioCosto_Internalname = sPrefix+"INVENTARIOCOSTO_"+sGXsfl_15_idx;
         edtInventarioPrecioFinal_Internalname = sPrefix+"INVENTARIOPRECIOFINAL_"+sGXsfl_15_idx;
         cmbProfComisionesRubrosTipo_Internalname = sPrefix+"PROFCOMISIONESRUBROSTIPO_"+sGXsfl_15_idx;
         edtProfComisionesRubrosValor_Internalname = sPrefix+"PROFCOMISIONESRUBROSVALOR_"+sGXsfl_15_idx;
         edtProfComisionesRubrosGan_Internalname = sPrefix+"PROFCOMISIONESRUBROSGAN_"+sGXsfl_15_idx;
         edtProfComisionesRubrosGanPRF_Internalname = sPrefix+"PROFCOMISIONESRUBROSGANPRF_"+sGXsfl_15_idx;
         edtProveedorID_Internalname = sPrefix+"PROVEEDORID_"+sGXsfl_15_idx;
         edtProveedorNombre_Internalname = sPrefix+"PROVEEDORNOMBRE_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         edtProfComisionesRubrosId_Internalname = sPrefix+"PROFCOMISIONESRUBROSID_"+sGXsfl_15_fel_idx;
         edtRubrosId_Internalname = sPrefix+"RUBROSID_"+sGXsfl_15_fel_idx;
         edtMedidasID_Internalname = sPrefix+"MEDIDASID_"+sGXsfl_15_fel_idx;
         edtInventarioId_Internalname = sPrefix+"INVENTARIOID_"+sGXsfl_15_fel_idx;
         edtInventarioCosto_Internalname = sPrefix+"INVENTARIOCOSTO_"+sGXsfl_15_fel_idx;
         edtInventarioPrecioFinal_Internalname = sPrefix+"INVENTARIOPRECIOFINAL_"+sGXsfl_15_fel_idx;
         cmbProfComisionesRubrosTipo_Internalname = sPrefix+"PROFCOMISIONESRUBROSTIPO_"+sGXsfl_15_fel_idx;
         edtProfComisionesRubrosValor_Internalname = sPrefix+"PROFCOMISIONESRUBROSVALOR_"+sGXsfl_15_fel_idx;
         edtProfComisionesRubrosGan_Internalname = sPrefix+"PROFCOMISIONESRUBROSGAN_"+sGXsfl_15_fel_idx;
         edtProfComisionesRubrosGanPRF_Internalname = sPrefix+"PROFCOMISIONESRUBROSGANPRF_"+sGXsfl_15_fel_idx;
         edtProveedorID_Internalname = sPrefix+"PROVEEDORID_"+sGXsfl_15_fel_idx;
         edtProveedorNombre_Internalname = sPrefix+"PROVEEDORNOMBRE_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         WB3Q0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfComisionesRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A452ProfComisionesRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A452ProfComisionesRubrosId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfComisionesRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidasID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A137MedidasID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidasID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A135InventarioId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioCosto_Internalname,StringUtil.LTrim( StringUtil.NToC( A190InventarioCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A190InventarioCosto, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioCosto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A181InventarioPrecioFinal, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbProfComisionesRubrosTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROFCOMISIONESRUBROSTIPO_" + sGXsfl_15_idx;
               cmbProfComisionesRubrosTipo.Name = GXCCtl;
               cmbProfComisionesRubrosTipo.WebTags = "";
               cmbProfComisionesRubrosTipo.addItem("F", context.GetMessage( "Valor Fijo", ""), 0);
               cmbProfComisionesRubrosTipo.addItem("P", context.GetMessage( "Porcentaje", ""), 0);
               if ( cmbProfComisionesRubrosTipo.ItemCount > 0 )
               {
                  A453ProfComisionesRubrosTipo = cmbProfComisionesRubrosTipo.getValidValue(A453ProfComisionesRubrosTipo);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProfComisionesRubrosTipo,(string)cmbProfComisionesRubrosTipo_Internalname,StringUtil.RTrim( A453ProfComisionesRubrosTipo),(short)1,(string)cmbProfComisionesRubrosTipo_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbProfComisionesRubrosTipo.CurrentValue = StringUtil.RTrim( A453ProfComisionesRubrosTipo);
            AssignProp(sPrefix, false, cmbProfComisionesRubrosTipo_Internalname, "Values", (string)(cmbProfComisionesRubrosTipo.ToJavascriptSource()), !bGXsfl_15_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfComisionesRubrosValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A454ProfComisionesRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A454ProfComisionesRubrosValor, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfComisionesRubrosValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfComisionesRubrosGan_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A456ProfComisionesRubrosGan), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A456ProfComisionesRubrosGan), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfComisionesRubrosGan_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfComisionesRubrosGanPRF_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A457ProfComisionesRubrosGanPRF), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A457ProfComisionesRubrosGanPRF), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfComisionesRubrosGanPRF_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorNombre_Internalname,StringUtil.RTrim( A282ProveedorNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtProveedorNombre_Link,(string)"",(string)"",(string)"",(string)edtProveedorNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes3Q2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_15_idx = ((subGrid_Islastpage==1)&&(nGXsfl_15_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         /* End function sendrow_152 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "PROFCOMISIONESRUBROSTIPO_" + sGXsfl_15_idx;
         cmbProfComisionesRubrosTipo.Name = GXCCtl;
         cmbProfComisionesRubrosTipo.WebTags = "";
         cmbProfComisionesRubrosTipo.addItem("F", context.GetMessage( "Valor Fijo", ""), 0);
         cmbProfComisionesRubrosTipo.addItem("P", context.GetMessage( "Porcentaje", ""), 0);
         if ( cmbProfComisionesRubrosTipo.ItemCount > 0 )
         {
         }
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "No.", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rubros Identificador ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Items/Característica", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Detalle", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Costo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo de Comisión", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Valor/Costo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Ganancia-ALM", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Ganancia-PRF", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Código del Proveedor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Proveedor Nombre", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A452ProfComisionesRubrosId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A190InventarioCosto, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A453ProfComisionesRubrosTipo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A454ProfComisionesRubrosValor, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A456ProfComisionesRubrosGan), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A457ProfComisionesRubrosGanPRF), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A282ProveedorNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtProveedorNombre_Link));
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
         edtProfComisionesRubrosId_Internalname = sPrefix+"PROFCOMISIONESRUBROSID";
         edtRubrosId_Internalname = sPrefix+"RUBROSID";
         edtMedidasID_Internalname = sPrefix+"MEDIDASID";
         edtInventarioId_Internalname = sPrefix+"INVENTARIOID";
         edtInventarioCosto_Internalname = sPrefix+"INVENTARIOCOSTO";
         edtInventarioPrecioFinal_Internalname = sPrefix+"INVENTARIOPRECIOFINAL";
         cmbProfComisionesRubrosTipo_Internalname = sPrefix+"PROFCOMISIONESRUBROSTIPO";
         edtProfComisionesRubrosValor_Internalname = sPrefix+"PROFCOMISIONESRUBROSVALOR";
         edtProfComisionesRubrosGan_Internalname = sPrefix+"PROFCOMISIONESRUBROSGAN";
         edtProfComisionesRubrosGanPRF_Internalname = sPrefix+"PROFCOMISIONESRUBROSGANPRF";
         edtProveedorID_Internalname = sPrefix+"PROVEEDORID";
         edtProveedorNombre_Internalname = sPrefix+"PROVEEDORNOMBRE";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtProfComisionesID_Internalname = sPrefix+"PROFCOMISIONESID";
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
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Link = "";
         edtProveedorID_Jsonclick = "";
         edtProfComisionesRubrosGanPRF_Jsonclick = "";
         edtProfComisionesRubrosGan_Jsonclick = "";
         edtProfComisionesRubrosValor_Jsonclick = "";
         cmbProfComisionesRubrosTipo_Jsonclick = "";
         edtInventarioPrecioFinal_Jsonclick = "";
         edtInventarioCosto_Jsonclick = "";
         edtInventarioId_Jsonclick = "";
         edtMedidasID_Jsonclick = "";
         edtRubrosId_Jsonclick = "";
         edtProfComisionesRubrosId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtProfComisionesID_Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtProfComisionesRubrosGanPRF_Enabled = 0;
         edtProfComisionesRubrosGan_Enabled = 0;
         edtProfComisionesRubrosValor_Enabled = 0;
         cmbProfComisionesRubrosTipo.Enabled = 0;
         edtInventarioPrecioFinal_Enabled = 0;
         edtInventarioCosto_Enabled = 0;
         edtInventarioId_Enabled = 0;
         edtMedidasID_Enabled = 0;
         edtRubrosId_Enabled = 0;
         edtProfComisionesRubrosId_Enabled = 0;
         subGrid_Sortable = 0;
         edtProfComisionesID_Jsonclick = "";
         edtProfComisionesID_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "18.0|4.0|18.0|18.0|18.2||18.2|18.0|18.0|18.0|";
         Ddo_grid_Datalistproc = "ProfComisionesRubrosWCGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||F:Valor Fijo,P:Porcentaje|||||";
         Ddo_grid_Allowmultipleselection = "|||||T|||||";
         Ddo_grid_Datalisttype = "|||||FixedValues|||||Dynamic";
         Ddo_grid_Includedatalist = "|||||T|||||T";
         Ddo_grid_Filterisrange = "T|T|T|T|T||T|T|T|T|";
         Ddo_grid_Filtertype = "Numeric|Numeric|Numeric|Numeric|Numeric||Numeric|Numeric|Numeric|Numeric|Character";
         Ddo_grid_Includefilter = "T|T|T|T|T||T|T|T|T|T";
         Ddo_grid_Includesortasc = "T|T|T|T|T|T|T|||T|T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|||8|9";
         Ddo_grid_Columnids = "0:ProfComisionesRubrosId|1:RubrosId|2:MedidasID|3:InventarioId|5:InventarioPrecioFinal|6:ProfComisionesRubrosTipo|7:ProfComisionesRubrosValor|8:ProfComisionesRubrosGan|9:ProfComisionesRubrosGanPRF|10:ProveedorID|11:ProveedorNombre";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'sPrefix',type:'char'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8ProfComisionesID',fld:'vPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFProfComisionesRubrosId',fld:'vTFPROFCOMISIONESRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV18TFProfComisionesRubrosId_To',fld:'vTFPROFCOMISIONESRUBROSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV19TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV20TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV21TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFInventarioId',fld:'vTFINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFInventarioId_To',fld:'vTFINVENTARIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV25TFInventarioPrecioFinal',fld:'vTFINVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV26TFInventarioPrecioFinal_To',fld:'vTFINVENTARIOPRECIOFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV28TFProfComisionesRubrosTipo_Sels',fld:'vTFPROFCOMISIONESRUBROSTIPO_SELS',pic:''},{av:'AV29TFProfComisionesRubrosValor',fld:'vTFPROFCOMISIONESRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV30TFProfComisionesRubrosValor_To',fld:'vTFPROFCOMISIONESRUBROSVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV31TFProfComisionesRubrosGan',fld:'vTFPROFCOMISIONESRUBROSGAN',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFProfComisionesRubrosGan_To',fld:'vTFPROFCOMISIONESRUBROSGAN_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFProfComisionesRubrosGanPRF',fld:'vTFPROFCOMISIONESRUBROSGANPRF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFProfComisionesRubrosGanPRF_To',fld:'vTFPROFCOMISIONESRUBROSGANPRF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV38TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV45IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E113Q2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8ProfComisionesID',fld:'vPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFProfComisionesRubrosId',fld:'vTFPROFCOMISIONESRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV18TFProfComisionesRubrosId_To',fld:'vTFPROFCOMISIONESRUBROSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV19TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV20TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV21TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFInventarioId',fld:'vTFINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFInventarioId_To',fld:'vTFINVENTARIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV25TFInventarioPrecioFinal',fld:'vTFINVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV26TFInventarioPrecioFinal_To',fld:'vTFINVENTARIOPRECIOFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV28TFProfComisionesRubrosTipo_Sels',fld:'vTFPROFCOMISIONESRUBROSTIPO_SELS',pic:''},{av:'AV29TFProfComisionesRubrosValor',fld:'vTFPROFCOMISIONESRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV30TFProfComisionesRubrosValor_To',fld:'vTFPROFCOMISIONESRUBROSVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV31TFProfComisionesRubrosGan',fld:'vTFPROFCOMISIONESRUBROSGAN',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFProfComisionesRubrosGan_To',fld:'vTFPROFCOMISIONESRUBROSGAN_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFProfComisionesRubrosGanPRF',fld:'vTFPROFCOMISIONESRUBROSGANPRF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFProfComisionesRubrosGanPRF_To',fld:'vTFPROFCOMISIONESRUBROSGANPRF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV38TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV45IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E123Q2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8ProfComisionesID',fld:'vPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFProfComisionesRubrosId',fld:'vTFPROFCOMISIONESRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV18TFProfComisionesRubrosId_To',fld:'vTFPROFCOMISIONESRUBROSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV19TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV20TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV21TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFInventarioId',fld:'vTFINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFInventarioId_To',fld:'vTFINVENTARIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV25TFInventarioPrecioFinal',fld:'vTFINVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV26TFInventarioPrecioFinal_To',fld:'vTFINVENTARIOPRECIOFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV28TFProfComisionesRubrosTipo_Sels',fld:'vTFPROFCOMISIONESRUBROSTIPO_SELS',pic:''},{av:'AV29TFProfComisionesRubrosValor',fld:'vTFPROFCOMISIONESRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV30TFProfComisionesRubrosValor_To',fld:'vTFPROFCOMISIONESRUBROSVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV31TFProfComisionesRubrosGan',fld:'vTFPROFCOMISIONESRUBROSGAN',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFProfComisionesRubrosGan_To',fld:'vTFPROFCOMISIONESRUBROSGAN_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFProfComisionesRubrosGanPRF',fld:'vTFPROFCOMISIONESRUBROSGANPRF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFProfComisionesRubrosGanPRF_To',fld:'vTFPROFCOMISIONESRUBROSGANPRF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV38TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV45IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E133Q2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8ProfComisionesID',fld:'vPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFProfComisionesRubrosId',fld:'vTFPROFCOMISIONESRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV18TFProfComisionesRubrosId_To',fld:'vTFPROFCOMISIONESRUBROSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV19TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV20TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV21TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFInventarioId',fld:'vTFINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFInventarioId_To',fld:'vTFINVENTARIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV25TFInventarioPrecioFinal',fld:'vTFINVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV26TFInventarioPrecioFinal_To',fld:'vTFINVENTARIOPRECIOFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV28TFProfComisionesRubrosTipo_Sels',fld:'vTFPROFCOMISIONESRUBROSTIPO_SELS',pic:''},{av:'AV29TFProfComisionesRubrosValor',fld:'vTFPROFCOMISIONESRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV30TFProfComisionesRubrosValor_To',fld:'vTFPROFCOMISIONESRUBROSVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV31TFProfComisionesRubrosGan',fld:'vTFPROFCOMISIONESRUBROSGAN',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFProfComisionesRubrosGan_To',fld:'vTFPROFCOMISIONESRUBROSGAN_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFProfComisionesRubrosGanPRF',fld:'vTFPROFCOMISIONESRUBROSGANPRF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFProfComisionesRubrosGanPRF_To',fld:'vTFPROFCOMISIONESRUBROSGANPRF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV38TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV45IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV37TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV38TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV35TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFProfComisionesRubrosGanPRF',fld:'vTFPROFCOMISIONESRUBROSGANPRF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFProfComisionesRubrosGanPRF_To',fld:'vTFPROFCOMISIONESRUBROSGANPRF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFProfComisionesRubrosGan',fld:'vTFPROFCOMISIONESRUBROSGAN',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFProfComisionesRubrosGan_To',fld:'vTFPROFCOMISIONESRUBROSGAN_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFProfComisionesRubrosValor',fld:'vTFPROFCOMISIONESRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV30TFProfComisionesRubrosValor_To',fld:'vTFPROFCOMISIONESRUBROSVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV27TFProfComisionesRubrosTipo_SelsJson',fld:'vTFPROFCOMISIONESRUBROSTIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV28TFProfComisionesRubrosTipo_Sels',fld:'vTFPROFCOMISIONESRUBROSTIPO_SELS',pic:''},{av:'AV25TFInventarioPrecioFinal',fld:'vTFINVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV26TFInventarioPrecioFinal_To',fld:'vTFINVENTARIOPRECIOFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV23TFInventarioId',fld:'vTFINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFInventarioId_To',fld:'vTFINVENTARIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV19TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV20TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV17TFProfComisionesRubrosId',fld:'vTFPROFCOMISIONESRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV18TFProfComisionesRubrosId_To',fld:'vTFPROFCOMISIONESRUBROSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E163Q2',iparms:[{av:'AV45IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtProveedorNombre_Link',ctrl:'PROVEEDORNOMBRE',prop:'Link'}]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[]");
         setEventMetadata("VALID_RUBROSID",",oparms:[]}");
         setEventMetadata("VALID_MEDIDASID","{handler:'Valid_Medidasid',iparms:[]");
         setEventMetadata("VALID_MEDIDASID",",oparms:[]}");
         setEventMetadata("VALID_INVENTARIOID","{handler:'Valid_Inventarioid',iparms:[]");
         setEventMetadata("VALID_INVENTARIOID",",oparms:[]}");
         setEventMetadata("VALID_INVENTARIOPRECIOFINAL","{handler:'Valid_Inventariopreciofinal',iparms:[]");
         setEventMetadata("VALID_INVENTARIOPRECIOFINAL",",oparms:[]}");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSTIPO","{handler:'Valid_Profcomisionesrubrostipo',iparms:[]");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSTIPO",",oparms:[]}");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSVALOR","{handler:'Valid_Profcomisionesrubrosvalor',iparms:[]");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSVALOR",",oparms:[]}");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSGAN","{handler:'Valid_Profcomisionesrubrosgan',iparms:[]");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSGAN",",oparms:[]}");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSGANPRF","{handler:'Valid_Profcomisionesrubrosganprf',iparms:[]");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSGANPRF",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Proveedornombre',iparms:[]");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV46Pgmname = "";
         AV28TFProfComisionesRubrosTipo_Sels = new GxSimpleCollection<string>();
         AV37TFProveedorNombre = "";
         AV38TFProveedorNombre_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV44GridAppliedFilters = "";
         AV39DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
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
         A453ProfComisionesRubrosTipo = "";
         A282ProveedorNombre = "";
         GXDecQS = "";
         lV37TFProveedorNombre = "";
         H003Q2_A450ProfComisionesID = new long[1] ;
         H003Q2_A282ProveedorNombre = new string[] {""} ;
         H003Q2_A133ProveedorID = new long[1] ;
         H003Q2_n133ProveedorID = new bool[] {false} ;
         H003Q2_A190InventarioCosto = new decimal[1] ;
         H003Q2_A135InventarioId = new long[1] ;
         H003Q2_A137MedidasID = new long[1] ;
         H003Q2_A121RubrosId = new short[1] ;
         H003Q2_A452ProfComisionesRubrosId = new long[1] ;
         H003Q2_A181InventarioPrecioFinal = new decimal[1] ;
         H003Q2_A453ProfComisionesRubrosTipo = new string[] {""} ;
         H003Q2_A454ProfComisionesRubrosValor = new decimal[1] ;
         H003Q3_A450ProfComisionesID = new long[1] ;
         H003Q3_A282ProveedorNombre = new string[] {""} ;
         H003Q3_A133ProveedorID = new long[1] ;
         H003Q3_n133ProveedorID = new bool[] {false} ;
         H003Q3_A190InventarioCosto = new decimal[1] ;
         H003Q3_A135InventarioId = new long[1] ;
         H003Q3_A137MedidasID = new long[1] ;
         H003Q3_A121RubrosId = new short[1] ;
         H003Q3_A452ProfComisionesRubrosId = new long[1] ;
         H003Q3_A181InventarioPrecioFinal = new decimal[1] ;
         H003Q3_A453ProfComisionesRubrosTipo = new string[] {""} ;
         H003Q3_A454ProfComisionesRubrosValor = new decimal[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27TFProfComisionesRubrosTipo_SelsJson = "";
         GridRow = new GXWebRow();
         AV16Session = context.GetSession();
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char4 = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8ProfComisionesID = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profcomisionesrubroswc__default(),
            new Object[][] {
                new Object[] {
               H003Q2_A450ProfComisionesID, H003Q2_A282ProveedorNombre, H003Q2_A133ProveedorID, H003Q2_n133ProveedorID, H003Q2_A190InventarioCosto, H003Q2_A135InventarioId, H003Q2_A137MedidasID, H003Q2_A121RubrosId, H003Q2_A452ProfComisionesRubrosId, H003Q2_A181InventarioPrecioFinal,
               H003Q2_A453ProfComisionesRubrosTipo, H003Q2_A454ProfComisionesRubrosValor
               }
               , new Object[] {
               H003Q3_A450ProfComisionesID, H003Q3_A282ProveedorNombre, H003Q3_A133ProveedorID, H003Q3_n133ProveedorID, H003Q3_A190InventarioCosto, H003Q3_A135InventarioId, H003Q3_A137MedidasID, H003Q3_A121RubrosId, H003Q3_A452ProfComisionesRubrosId, H003Q3_A181InventarioPrecioFinal,
               H003Q3_A453ProfComisionesRubrosTipo, H003Q3_A454ProfComisionesRubrosValor
               }
            }
         );
         AV46Pgmname = "ProfComisionesRubrosWC";
         /* GeneXus formulas. */
         AV46Pgmname = "ProfComisionesRubrosWC";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14OrderedBy ;
      private short AV19TFRubrosId ;
      private short AV20TFRubrosId_To ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A121RubrosId ;
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
      private int edtProfComisionesID_Visible ;
      private int subGrid_Islastpage ;
      private int AV28TFProfComisionesRubrosTipo_Sels_Count ;
      private int edtProfComisionesRubrosId_Enabled ;
      private int edtRubrosId_Enabled ;
      private int edtMedidasID_Enabled ;
      private int edtInventarioId_Enabled ;
      private int edtInventarioCosto_Enabled ;
      private int edtInventarioPrecioFinal_Enabled ;
      private int edtProfComisionesRubrosValor_Enabled ;
      private int edtProfComisionesRubrosGan_Enabled ;
      private int edtProfComisionesRubrosGanPRF_Enabled ;
      private int edtProveedorID_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtProfComisionesID_Enabled ;
      private int AV41PageToGo ;
      private int AV47GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8ProfComisionesID ;
      private long wcpOAV8ProfComisionesID ;
      private long GRID_nFirstRecordOnPage ;
      private long AV17TFProfComisionesRubrosId ;
      private long AV18TFProfComisionesRubrosId_To ;
      private long AV21TFMedidasID ;
      private long AV22TFMedidasID_To ;
      private long AV23TFInventarioId ;
      private long AV24TFInventarioId_To ;
      private long AV31TFProfComisionesRubrosGan ;
      private long AV32TFProfComisionesRubrosGan_To ;
      private long AV33TFProfComisionesRubrosGanPRF ;
      private long AV34TFProfComisionesRubrosGanPRF_To ;
      private long AV35TFProveedorID ;
      private long AV36TFProveedorID_To ;
      private long AV42GridCurrentPage ;
      private long AV43GridPageCount ;
      private long A450ProfComisionesID ;
      private long A452ProfComisionesRubrosId ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long A456ProfComisionesRubrosGan ;
      private long A457ProfComisionesRubrosGanPRF ;
      private long A133ProveedorID ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV25TFInventarioPrecioFinal ;
      private decimal AV26TFInventarioPrecioFinal_To ;
      private decimal AV29TFProfComisionesRubrosValor ;
      private decimal AV30TFProfComisionesRubrosValor_To ;
      private decimal A190InventarioCosto ;
      private decimal A181InventarioPrecioFinal ;
      private decimal A454ProfComisionesRubrosValor ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_15_idx="0001" ;
      private string AV46Pgmname ;
      private string AV37TFProveedorNombre ;
      private string AV38TFProveedorNombre_Sel ;
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
      private string edtProfComisionesID_Internalname ;
      private string edtProfComisionesID_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtProfComisionesRubrosId_Internalname ;
      private string edtRubrosId_Internalname ;
      private string edtMedidasID_Internalname ;
      private string edtInventarioId_Internalname ;
      private string edtInventarioCosto_Internalname ;
      private string edtInventarioPrecioFinal_Internalname ;
      private string cmbProfComisionesRubrosTipo_Internalname ;
      private string A453ProfComisionesRubrosTipo ;
      private string edtProfComisionesRubrosValor_Internalname ;
      private string edtProfComisionesRubrosGan_Internalname ;
      private string edtProfComisionesRubrosGanPRF_Internalname ;
      private string edtProveedorID_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Internalname ;
      private string GXDecQS ;
      private string lV37TFProveedorNombre ;
      private string edtProveedorNombre_Link ;
      private string GXt_char3 ;
      private string GXt_char4 ;
      private string sCtrlAV8ProfComisionesID ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtProfComisionesRubrosId_Jsonclick ;
      private string edtRubrosId_Jsonclick ;
      private string edtMedidasID_Jsonclick ;
      private string edtInventarioId_Jsonclick ;
      private string edtInventarioCosto_Jsonclick ;
      private string edtInventarioPrecioFinal_Jsonclick ;
      private string GXCCtl ;
      private string cmbProfComisionesRubrosTipo_Jsonclick ;
      private string edtProfComisionesRubrosValor_Jsonclick ;
      private string edtProfComisionesRubrosGan_Jsonclick ;
      private string edtProfComisionesRubrosGanPRF_Jsonclick ;
      private string edtProveedorID_Jsonclick ;
      private string edtProveedorNombre_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV45IsAuthorized_ProveedorNombre ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n133ProveedorID ;
      private bool bGXsfl_15_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private bool gx_refresh_fired ;
      private string AV27TFProfComisionesRubrosTipo_SelsJson ;
      private string AV44GridAppliedFilters ;
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
      private GXCombobox cmbProfComisionesRubrosTipo ;
      private GxSimpleCollection<string> AV28TFProfComisionesRubrosTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV39DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private long[] H003Q2_A450ProfComisionesID ;
      private string[] H003Q2_A282ProveedorNombre ;
      private long[] H003Q2_A133ProveedorID ;
      private bool[] H003Q2_n133ProveedorID ;
      private decimal[] H003Q2_A190InventarioCosto ;
      private long[] H003Q2_A135InventarioId ;
      private long[] H003Q2_A137MedidasID ;
      private short[] H003Q2_A121RubrosId ;
      private long[] H003Q2_A452ProfComisionesRubrosId ;
      private decimal[] H003Q2_A181InventarioPrecioFinal ;
      private string[] H003Q2_A453ProfComisionesRubrosTipo ;
      private decimal[] H003Q2_A454ProfComisionesRubrosValor ;
      private long[] H003Q3_A450ProfComisionesID ;
      private string[] H003Q3_A282ProveedorNombre ;
      private long[] H003Q3_A133ProveedorID ;
      private bool[] H003Q3_n133ProveedorID ;
      private decimal[] H003Q3_A190InventarioCosto ;
      private long[] H003Q3_A135InventarioId ;
      private long[] H003Q3_A137MedidasID ;
      private short[] H003Q3_A121RubrosId ;
      private long[] H003Q3_A452ProfComisionesRubrosId ;
      private decimal[] H003Q3_A181InventarioPrecioFinal ;
      private string[] H003Q3_A453ProfComisionesRubrosTipo ;
      private decimal[] H003Q3_A454ProfComisionesRubrosValor ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class profcomisionesrubroswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003Q2( IGxContext context ,
                                             string A453ProfComisionesRubrosTipo ,
                                             GxSimpleCollection<string> AV28TFProfComisionesRubrosTipo_Sels ,
                                             long AV17TFProfComisionesRubrosId ,
                                             long AV18TFProfComisionesRubrosId_To ,
                                             short AV19TFRubrosId ,
                                             short AV20TFRubrosId_To ,
                                             long AV21TFMedidasID ,
                                             long AV22TFMedidasID_To ,
                                             long AV23TFInventarioId ,
                                             long AV24TFInventarioId_To ,
                                             decimal AV25TFInventarioPrecioFinal ,
                                             decimal AV26TFInventarioPrecioFinal_To ,
                                             int AV28TFProfComisionesRubrosTipo_Sels_Count ,
                                             decimal AV29TFProfComisionesRubrosValor ,
                                             decimal AV30TFProfComisionesRubrosValor_To ,
                                             long AV35TFProveedorID ,
                                             long AV36TFProveedorID_To ,
                                             string AV38TFProveedorNombre_Sel ,
                                             string AV37TFProveedorNombre ,
                                             long A452ProfComisionesRubrosId ,
                                             short A121RubrosId ,
                                             long A137MedidasID ,
                                             long A135InventarioId ,
                                             decimal A181InventarioPrecioFinal ,
                                             decimal A454ProfComisionesRubrosValor ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             long AV31TFProfComisionesRubrosGan ,
                                             long A456ProfComisionesRubrosGan ,
                                             long AV32TFProfComisionesRubrosGan_To ,
                                             long AV33TFProfComisionesRubrosGanPRF ,
                                             long A457ProfComisionesRubrosGanPRF ,
                                             long AV34TFProfComisionesRubrosGanPRF_To ,
                                             long AV8ProfComisionesID ,
                                             long A450ProfComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[17];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[ProfComisionesID], T2.[ProveedorNombre], T1.[ProveedorID], T3.[InventarioCosto], T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T1.[ProfComisionesRubrosId], T3.[InventarioPrecioFinal], T1.[ProfComisionesRubrosTipo], T1.[ProfComisionesRubrosValor] FROM (([ProfComisionesRubros] T1 LEFT JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [Inventario] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID] AND T3.[InventarioId] = T1.[InventarioId])";
         AddWhere(sWhereString, "(T1.[ProfComisionesID] = @AV8ProfComisionesID)");
         if ( ! (0==AV17TFProfComisionesRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosId] >= @AV17TFProfComisionesRubrosId)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (0==AV18TFProfComisionesRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosId] <= @AV18TFProfComisionesRubrosId_To)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV19TFRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV19TFRubrosId)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV20TFRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV20TFRubrosId_To)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (0==AV21TFMedidasID) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] >= @AV21TFMedidasID)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV22TFMedidasID_To) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] <= @AV22TFMedidasID_To)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV23TFInventarioId) )
         {
            AddWhere(sWhereString, "(T1.[InventarioId] >= @AV23TFInventarioId)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (0==AV24TFInventarioId_To) )
         {
            AddWhere(sWhereString, "(T1.[InventarioId] <= @AV24TFInventarioId_To)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV25TFInventarioPrecioFinal) )
         {
            AddWhere(sWhereString, "(T3.[InventarioPrecioFinal] >= @AV25TFInventarioPrecioFinal)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV26TFInventarioPrecioFinal_To) )
         {
            AddWhere(sWhereString, "(T3.[InventarioPrecioFinal] <= @AV26TFInventarioPrecioFinal_To)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV28TFProfComisionesRubrosTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV28TFProfComisionesRubrosTipo_Sels, "T1.[ProfComisionesRubrosTipo] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV29TFProfComisionesRubrosValor) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosValor] >= @AV29TFProfComisionesRubrosValor)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV30TFProfComisionesRubrosValor_To) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosValor] <= @AV30TFProfComisionesRubrosValor_To)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (0==AV35TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV35TFProveedorID)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (0==AV36TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV36TFProveedorID_To)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV37TFProveedorNombre))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV38TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV38TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV38TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] IS NULL or (T2.[ProveedorNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T1.[ProfComisionesRubrosId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T1.[ProfComisionesRubrosId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T1.[RubrosId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T1.[RubrosId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T1.[MedidasID]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T1.[MedidasID] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T1.[InventarioId]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T1.[InventarioId] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T3.[InventarioPrecioFinal]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T3.[InventarioPrecioFinal] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T1.[ProfComisionesRubrosTipo]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T1.[ProfComisionesRubrosTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T1.[ProfComisionesRubrosValor]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T1.[ProfComisionesRubrosValor] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T1.[ProveedorID]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T1.[ProveedorID] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T2.[ProveedorNombre]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T2.[ProveedorNombre] DESC";
         }
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H003Q3( IGxContext context ,
                                             string A453ProfComisionesRubrosTipo ,
                                             GxSimpleCollection<string> AV28TFProfComisionesRubrosTipo_Sels ,
                                             long AV17TFProfComisionesRubrosId ,
                                             long AV18TFProfComisionesRubrosId_To ,
                                             short AV19TFRubrosId ,
                                             short AV20TFRubrosId_To ,
                                             long AV21TFMedidasID ,
                                             long AV22TFMedidasID_To ,
                                             long AV23TFInventarioId ,
                                             long AV24TFInventarioId_To ,
                                             decimal AV25TFInventarioPrecioFinal ,
                                             decimal AV26TFInventarioPrecioFinal_To ,
                                             int AV28TFProfComisionesRubrosTipo_Sels_Count ,
                                             decimal AV29TFProfComisionesRubrosValor ,
                                             decimal AV30TFProfComisionesRubrosValor_To ,
                                             long AV35TFProveedorID ,
                                             long AV36TFProveedorID_To ,
                                             string AV38TFProveedorNombre_Sel ,
                                             string AV37TFProveedorNombre ,
                                             long A452ProfComisionesRubrosId ,
                                             short A121RubrosId ,
                                             long A137MedidasID ,
                                             long A135InventarioId ,
                                             decimal A181InventarioPrecioFinal ,
                                             decimal A454ProfComisionesRubrosValor ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             long AV31TFProfComisionesRubrosGan ,
                                             long A456ProfComisionesRubrosGan ,
                                             long AV32TFProfComisionesRubrosGan_To ,
                                             long AV33TFProfComisionesRubrosGanPRF ,
                                             long A457ProfComisionesRubrosGanPRF ,
                                             long AV34TFProfComisionesRubrosGanPRF_To ,
                                             long AV8ProfComisionesID ,
                                             long A450ProfComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[17];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[ProfComisionesID], T2.[ProveedorNombre], T1.[ProveedorID], T3.[InventarioCosto], T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T1.[ProfComisionesRubrosId], T3.[InventarioPrecioFinal], T1.[ProfComisionesRubrosTipo], T1.[ProfComisionesRubrosValor] FROM (([ProfComisionesRubros] T1 LEFT JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [Inventario] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID] AND T3.[InventarioId] = T1.[InventarioId])";
         AddWhere(sWhereString, "(T1.[ProfComisionesID] = @AV8ProfComisionesID)");
         if ( ! (0==AV17TFProfComisionesRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosId] >= @AV17TFProfComisionesRubrosId)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (0==AV18TFProfComisionesRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosId] <= @AV18TFProfComisionesRubrosId_To)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (0==AV19TFRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV19TFRubrosId)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (0==AV20TFRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV20TFRubrosId_To)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! (0==AV21TFMedidasID) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] >= @AV21TFMedidasID)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (0==AV22TFMedidasID_To) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] <= @AV22TFMedidasID_To)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! (0==AV23TFInventarioId) )
         {
            AddWhere(sWhereString, "(T1.[InventarioId] >= @AV23TFInventarioId)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! (0==AV24TFInventarioId_To) )
         {
            AddWhere(sWhereString, "(T1.[InventarioId] <= @AV24TFInventarioId_To)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV25TFInventarioPrecioFinal) )
         {
            AddWhere(sWhereString, "(T3.[InventarioPrecioFinal] >= @AV25TFInventarioPrecioFinal)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV26TFInventarioPrecioFinal_To) )
         {
            AddWhere(sWhereString, "(T3.[InventarioPrecioFinal] <= @AV26TFInventarioPrecioFinal_To)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV28TFProfComisionesRubrosTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV28TFProfComisionesRubrosTipo_Sels, "T1.[ProfComisionesRubrosTipo] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV29TFProfComisionesRubrosValor) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosValor] >= @AV29TFProfComisionesRubrosValor)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV30TFProfComisionesRubrosValor_To) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosValor] <= @AV30TFProfComisionesRubrosValor_To)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! (0==AV35TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV35TFProveedorID)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! (0==AV36TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV36TFProveedorID_To)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV37TFProveedorNombre))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV38TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV38TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( StringUtil.StrCmp(AV38TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] IS NULL or (T2.[ProveedorNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T1.[ProfComisionesRubrosId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T1.[ProfComisionesRubrosId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T1.[RubrosId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T1.[RubrosId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T1.[MedidasID]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T1.[MedidasID] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T1.[InventarioId]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T1.[InventarioId] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T3.[InventarioPrecioFinal]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T3.[InventarioPrecioFinal] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T1.[ProfComisionesRubrosTipo]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T1.[ProfComisionesRubrosTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T1.[ProfComisionesRubrosValor]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T1.[ProfComisionesRubrosValor] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T1.[ProveedorID]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T1.[ProveedorID] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID], T2.[ProveedorNombre]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC, T2.[ProveedorNombre] DESC";
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
                     return conditional_H003Q2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (int)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (short)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (long)dynConstraints[35] , (long)dynConstraints[36] );
               case 1 :
                     return conditional_H003Q3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (int)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (short)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (long)dynConstraints[35] , (long)dynConstraints[36] );
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
          Object[] prmH003Q2;
          prmH003Q2 = new Object[] {
          new ParDef("@AV8ProfComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@AV17TFProfComisionesRubrosId",GXType.Decimal,18,0) ,
          new ParDef("@AV18TFProfComisionesRubrosId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV19TFRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV20TFRubrosId_To",GXType.Int16,4,0) ,
          new ParDef("@AV21TFMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV23TFInventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV24TFInventarioId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV25TFInventarioPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV26TFInventarioPrecioFinal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV29TFProfComisionesRubrosValor",GXType.Decimal,18,2) ,
          new ParDef("@AV30TFProfComisionesRubrosValor_To",GXType.Decimal,18,2) ,
          new ParDef("@AV35TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV36TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV37TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV38TFProveedorNombre_Sel",GXType.NChar,80,0)
          };
          Object[] prmH003Q3;
          prmH003Q3 = new Object[] {
          new ParDef("@AV8ProfComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@AV17TFProfComisionesRubrosId",GXType.Decimal,18,0) ,
          new ParDef("@AV18TFProfComisionesRubrosId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV19TFRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV20TFRubrosId_To",GXType.Int16,4,0) ,
          new ParDef("@AV21TFMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV23TFInventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV24TFInventarioId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV25TFInventarioPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV26TFInventarioPrecioFinal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV29TFProfComisionesRubrosValor",GXType.Decimal,18,2) ,
          new ParDef("@AV30TFProfComisionesRubrosValor_To",GXType.Decimal,18,2) ,
          new ParDef("@AV35TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV36TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV37TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV38TFProveedorNombre_Sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Q2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003Q3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Q3,11, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 1);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 1);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                return;
       }
    }

 }

}
