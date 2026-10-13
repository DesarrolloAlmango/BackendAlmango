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
   public class comisionesagruparrubroswc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public comisionesagruparrubroswc( )
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

      public comisionesagruparrubroswc( IGxContext context )
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
         AV35Pgmname = GetPar( "Pgmname");
         AV17TFRubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "TFRubrosId"), "."), 18, MidpointRounding.ToEven));
         AV18TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFRubrosId_To"), "."), 18, MidpointRounding.ToEven));
         AV19TFMedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFMedidasID"), "."), 18, MidpointRounding.ToEven));
         AV20TFMedidasID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFMedidasID_To"), "."), 18, MidpointRounding.ToEven));
         AV21TFInventarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFInventarioId"), "."), 18, MidpointRounding.ToEven));
         AV22TFInventarioId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFInventarioId_To"), "."), 18, MidpointRounding.ToEven));
         AV23TFInventarioPrecioFinal = NumberUtil.Val( GetPar( "TFInventarioPrecioFinal"), ".");
         AV24TFInventarioPrecioFinal_To = NumberUtil.Val( GetPar( "TFInventarioPrecioFinal_To"), ".");
         AV25TFComisionesAgruparRubrosValor = NumberUtil.Val( GetPar( "TFComisionesAgruparRubrosValor"), ".");
         AV26TFComisionesAgruparRubrosValor_To = NumberUtil.Val( GetPar( "TFComisionesAgruparRubrosValor_To"), ".");
         AV27TFComisionesAgruparRubrosGan = NumberUtil.Val( GetPar( "TFComisionesAgruparRubrosGan"), ".");
         AV28TFComisionesAgruparRubrosGan_To = NumberUtil.Val( GetPar( "TFComisionesAgruparRubrosGan_To"), ".");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ComisionesID, AV35Pgmname, AV17TFRubrosId, AV18TFRubrosId_To, AV19TFMedidasID, AV20TFMedidasID_To, AV21TFInventarioId, AV22TFInventarioId_To, AV23TFInventarioPrecioFinal, AV24TFInventarioPrecioFinal_To, AV25TFComisionesAgruparRubrosValor, AV26TFComisionesAgruparRubrosValor_To, AV27TFComisionesAgruparRubrosGan, AV28TFComisionesAgruparRubrosGan_To, sPrefix) ;
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
            PA4I2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV35Pgmname = "ComisionesAgruparRubrosWC";
               WS4I2( ) ;
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
            context.SendWebValue( context.GetMessage( "Comisiones Agrupar Rubros WC", "")) ;
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
            GXEncryptionTmp = "comisionesagruparrubroswc.aspx"+UrlEncode(StringUtil.LTrimStr(AV8ComisionesID,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("comisionesagruparrubroswc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV35Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV35Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV34GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV29DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV29DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8ComisionesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV35Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV35Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17TFRubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFRUBROSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18TFRubrosId_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMEDIDASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19TFMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMEDIDASID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20TFMedidasID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFINVENTARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21TFInventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFINVENTARIOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22TFInventarioId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFINVENTARIOPRECIOFINAL", StringUtil.LTrim( StringUtil.NToC( AV23TFInventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFINVENTARIOPRECIOFINAL_TO", StringUtil.LTrim( StringUtil.NToC( AV24TFInventarioPrecioFinal_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCOMISIONESAGRUPARRUBROSVALOR", StringUtil.LTrim( StringUtil.NToC( AV25TFComisionesAgruparRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCOMISIONESAGRUPARRUBROSVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV26TFComisionesAgruparRubrosValor_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCOMISIONESAGRUPARRUBROSGAN", StringUtil.LTrim( StringUtil.NToC( AV27TFComisionesAgruparRubrosGan, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCOMISIONESAGRUPARRUBROSGAN_TO", StringUtil.LTrim( StringUtil.NToC( AV28TFComisionesAgruparRubrosGan_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOMISIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
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

      protected void RenderHtmlCloseForm4I2( )
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
         return "ComisionesAgruparRubrosWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Comisiones Agrupar Rubros WC", "") ;
      }

      protected void WB4I0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "comisionesagruparrubroswc.aspx");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV32GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV33GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV34GridAppliedFilters);
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
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV29DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtComisionesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A503ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A503ComisionesID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesID_Jsonclick, 0, "Attribute", "", "", "", "", edtComisionesID_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ComisionesAgruparRubrosWC.htm");
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

      protected void START4I2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Comisiones Agrupar Rubros WC", ""), 0) ;
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
               STRUP4I0( ) ;
            }
         }
      }

      protected void WS4I2( )
      {
         START4I2( ) ;
         EVT4I2( ) ;
      }

      protected void EVT4I2( )
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
                                 STRUP4I0( ) ;
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
                                 STRUP4I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E114I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E124I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E134I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4I0( ) ;
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
                                 STRUP4I0( ) ;
                              }
                              nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              A513ComisionesAgruparRubrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtComisionesAgruparRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A137MedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMedidasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n137MedidasID = false;
                              A135InventarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtInventarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n135InventarioId = false;
                              A181InventarioPrecioFinal = context.localUtil.CToN( cgiGet( edtInventarioPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A515ComisionesAgruparRubrosValor = context.localUtil.CToN( cgiGet( edtComisionesAgruparRubrosValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A517ComisionesAgruparRubrosGan = context.localUtil.CToN( cgiGet( edtComisionesAgruparRubrosGan_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
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
                                          E144I2 ();
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
                                          E154I2 ();
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
                                          E164I2 ();
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
                                       STRUP4I0( ) ;
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

      protected void WE4I2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4I2( ) ;
            }
         }
      }

      protected void PA4I2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "comisionesagruparrubroswc.aspx")), "comisionesagruparrubroswc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "comisionesagruparrubroswc.aspx")))) ;
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
                                       string AV35Pgmname ,
                                       short AV17TFRubrosId ,
                                       short AV18TFRubrosId_To ,
                                       long AV19TFMedidasID ,
                                       long AV20TFMedidasID_To ,
                                       long AV21TFInventarioId ,
                                       long AV22TFInventarioId_To ,
                                       decimal AV23TFInventarioPrecioFinal ,
                                       decimal AV24TFInventarioPrecioFinal_To ,
                                       decimal AV25TFComisionesAgruparRubrosValor ,
                                       decimal AV26TFComisionesAgruparRubrosValor_To ,
                                       decimal AV27TFComisionesAgruparRubrosGan ,
                                       decimal AV28TFComisionesAgruparRubrosGan_To ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4I2( ) ;
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
         RF4I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV35Pgmname = "ComisionesAgruparRubrosWC";
      }

      protected void RF4I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 15;
         /* Execute user event: Refresh */
         E154I2 ();
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
                                                 AV17TFRubrosId ,
                                                 AV18TFRubrosId_To ,
                                                 AV19TFMedidasID ,
                                                 AV20TFMedidasID_To ,
                                                 AV21TFInventarioId ,
                                                 AV22TFInventarioId_To ,
                                                 AV23TFInventarioPrecioFinal ,
                                                 AV24TFInventarioPrecioFinal_To ,
                                                 AV25TFComisionesAgruparRubrosValor ,
                                                 AV26TFComisionesAgruparRubrosValor_To ,
                                                 AV27TFComisionesAgruparRubrosGan ,
                                                 AV28TFComisionesAgruparRubrosGan_To ,
                                                 A121RubrosId ,
                                                 A137MedidasID ,
                                                 A135InventarioId ,
                                                 A181InventarioPrecioFinal ,
                                                 A515ComisionesAgruparRubrosValor ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV8ComisionesID ,
                                                 A503ComisionesID } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H004I2 */
            pr_default.execute(0, new Object[] {AV8ComisionesID, AV17TFRubrosId, AV18TFRubrosId_To, AV19TFMedidasID, AV20TFMedidasID_To, AV21TFInventarioId, AV22TFInventarioId_To, AV23TFInventarioPrecioFinal, AV24TFInventarioPrecioFinal_To, AV25TFComisionesAgruparRubrosValor, AV26TFComisionesAgruparRubrosValor_To, AV27TFComisionesAgruparRubrosGan, AV28TFComisionesAgruparRubrosGan_To, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_15_idx = 1;
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A503ComisionesID = H004I2_A503ComisionesID[0];
               AssignAttri(sPrefix, false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
               A135InventarioId = H004I2_A135InventarioId[0];
               n135InventarioId = H004I2_n135InventarioId[0];
               A137MedidasID = H004I2_A137MedidasID[0];
               n137MedidasID = H004I2_n137MedidasID[0];
               A121RubrosId = H004I2_A121RubrosId[0];
               A513ComisionesAgruparRubrosId = H004I2_A513ComisionesAgruparRubrosId[0];
               A181InventarioPrecioFinal = H004I2_A181InventarioPrecioFinal[0];
               A515ComisionesAgruparRubrosValor = H004I2_A515ComisionesAgruparRubrosValor[0];
               A181InventarioPrecioFinal = H004I2_A181InventarioPrecioFinal[0];
               if ( ( A515ComisionesAgruparRubrosValor > Convert.ToDecimal( 0 )) )
               {
                  A517ComisionesAgruparRubrosGan = (decimal)((A181InventarioPrecioFinal*(A515ComisionesAgruparRubrosValor/ (decimal)(100))));
               }
               else
               {
                  A517ComisionesAgruparRubrosGan = 0;
               }
               /* Execute user event: Grid.Load */
               E164I2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 15;
            WB4I0( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4I2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV35Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV35Pgmname, "")), context));
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
                                              AV17TFRubrosId ,
                                              AV18TFRubrosId_To ,
                                              AV19TFMedidasID ,
                                              AV20TFMedidasID_To ,
                                              AV21TFInventarioId ,
                                              AV22TFInventarioId_To ,
                                              AV23TFInventarioPrecioFinal ,
                                              AV24TFInventarioPrecioFinal_To ,
                                              AV25TFComisionesAgruparRubrosValor ,
                                              AV26TFComisionesAgruparRubrosValor_To ,
                                              AV27TFComisionesAgruparRubrosGan ,
                                              AV28TFComisionesAgruparRubrosGan_To ,
                                              A121RubrosId ,
                                              A137MedidasID ,
                                              A135InventarioId ,
                                              A181InventarioPrecioFinal ,
                                              A515ComisionesAgruparRubrosValor ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV8ComisionesID ,
                                              A503ComisionesID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor H004I3 */
         pr_default.execute(1, new Object[] {AV8ComisionesID, AV17TFRubrosId, AV18TFRubrosId_To, AV19TFMedidasID, AV20TFMedidasID_To, AV21TFInventarioId, AV22TFInventarioId_To, AV23TFInventarioPrecioFinal, AV24TFInventarioPrecioFinal_To, AV25TFComisionesAgruparRubrosValor, AV26TFComisionesAgruparRubrosValor_To, AV27TFComisionesAgruparRubrosGan, AV28TFComisionesAgruparRubrosGan_To});
         GRID_nRecordCount = H004I3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ComisionesID, AV35Pgmname, AV17TFRubrosId, AV18TFRubrosId_To, AV19TFMedidasID, AV20TFMedidasID_To, AV21TFInventarioId, AV22TFInventarioId_To, AV23TFInventarioPrecioFinal, AV24TFInventarioPrecioFinal_To, AV25TFComisionesAgruparRubrosValor, AV26TFComisionesAgruparRubrosValor_To, AV27TFComisionesAgruparRubrosGan, AV28TFComisionesAgruparRubrosGan_To, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ComisionesID, AV35Pgmname, AV17TFRubrosId, AV18TFRubrosId_To, AV19TFMedidasID, AV20TFMedidasID_To, AV21TFInventarioId, AV22TFInventarioId_To, AV23TFInventarioPrecioFinal, AV24TFInventarioPrecioFinal_To, AV25TFComisionesAgruparRubrosValor, AV26TFComisionesAgruparRubrosValor_To, AV27TFComisionesAgruparRubrosGan, AV28TFComisionesAgruparRubrosGan_To, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ComisionesID, AV35Pgmname, AV17TFRubrosId, AV18TFRubrosId_To, AV19TFMedidasID, AV20TFMedidasID_To, AV21TFInventarioId, AV22TFInventarioId_To, AV23TFInventarioPrecioFinal, AV24TFInventarioPrecioFinal_To, AV25TFComisionesAgruparRubrosValor, AV26TFComisionesAgruparRubrosValor_To, AV27TFComisionesAgruparRubrosGan, AV28TFComisionesAgruparRubrosGan_To, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ComisionesID, AV35Pgmname, AV17TFRubrosId, AV18TFRubrosId_To, AV19TFMedidasID, AV20TFMedidasID_To, AV21TFInventarioId, AV22TFInventarioId_To, AV23TFInventarioPrecioFinal, AV24TFInventarioPrecioFinal_To, AV25TFComisionesAgruparRubrosValor, AV26TFComisionesAgruparRubrosValor_To, AV27TFComisionesAgruparRubrosGan, AV28TFComisionesAgruparRubrosGan_To, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8ComisionesID, AV35Pgmname, AV17TFRubrosId, AV18TFRubrosId_To, AV19TFMedidasID, AV20TFMedidasID_To, AV21TFInventarioId, AV22TFInventarioId_To, AV23TFInventarioPrecioFinal, AV24TFInventarioPrecioFinal_To, AV25TFComisionesAgruparRubrosValor, AV26TFComisionesAgruparRubrosValor_To, AV27TFComisionesAgruparRubrosGan, AV28TFComisionesAgruparRubrosGan_To, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV35Pgmname = "ComisionesAgruparRubrosWC";
         edtComisionesAgruparRubrosId_Enabled = 0;
         edtRubrosId_Enabled = 0;
         edtMedidasID_Enabled = 0;
         edtInventarioId_Enabled = 0;
         edtInventarioPrecioFinal_Enabled = 0;
         edtComisionesAgruparRubrosValor_Enabled = 0;
         edtComisionesAgruparRubrosGan_Enabled = 0;
         edtComisionesID_Enabled = 0;
         AssignProp(sPrefix, false, edtComisionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesID_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E144I2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV29DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_15 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_15"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV32GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV33GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV34GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Filteredtextto_set = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
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
         E144I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E144I2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV29DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV29DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E154I2( )
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
         AV32GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV32GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV32GridCurrentPage), 10, 0));
         AV33GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV33GridPageCount", StringUtil.LTrimStr( (decimal)(AV33GridPageCount), 10, 0));
         GXt_char2 = AV34GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV35Pgmname, out  GXt_char2) ;
         AV34GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV34GridAppliedFilters", AV34GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E114I2( )
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
            AV31PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV31PageToGo) ;
         }
         /*  Sending Event outputs  */
      }

      protected void E124I2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E134I2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RubrosId") == 0 )
            {
               AV17TFRubrosId = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV17TFRubrosId", StringUtil.LTrimStr( (decimal)(AV17TFRubrosId), 4, 0));
               AV18TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV18TFRubrosId_To", StringUtil.LTrimStr( (decimal)(AV18TFRubrosId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MedidasID") == 0 )
            {
               AV19TFMedidasID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV19TFMedidasID", StringUtil.LTrimStr( (decimal)(AV19TFMedidasID), 18, 0));
               AV20TFMedidasID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV20TFMedidasID_To", StringUtil.LTrimStr( (decimal)(AV20TFMedidasID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "InventarioId") == 0 )
            {
               AV21TFInventarioId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV21TFInventarioId", StringUtil.LTrimStr( (decimal)(AV21TFInventarioId), 18, 0));
               AV22TFInventarioId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV22TFInventarioId_To", StringUtil.LTrimStr( (decimal)(AV22TFInventarioId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "InventarioPrecioFinal") == 0 )
            {
               AV23TFInventarioPrecioFinal = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV23TFInventarioPrecioFinal", StringUtil.LTrimStr( AV23TFInventarioPrecioFinal, 18, 2));
               AV24TFInventarioPrecioFinal_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV24TFInventarioPrecioFinal_To", StringUtil.LTrimStr( AV24TFInventarioPrecioFinal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ComisionesAgruparRubrosValor") == 0 )
            {
               AV25TFComisionesAgruparRubrosValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV25TFComisionesAgruparRubrosValor", StringUtil.LTrimStr( AV25TFComisionesAgruparRubrosValor, 18, 2));
               AV26TFComisionesAgruparRubrosValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV26TFComisionesAgruparRubrosValor_To", StringUtil.LTrimStr( AV26TFComisionesAgruparRubrosValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ComisionesAgruparRubrosGan") == 0 )
            {
               AV27TFComisionesAgruparRubrosGan = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV27TFComisionesAgruparRubrosGan", StringUtil.LTrimStr( AV27TFComisionesAgruparRubrosGan, 18, 2));
               AV28TFComisionesAgruparRubrosGan_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV28TFComisionesAgruparRubrosGan_To", StringUtil.LTrimStr( AV28TFComisionesAgruparRubrosGan_To, 18, 2));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E164I2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
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
         if ( StringUtil.StrCmp(AV16Session.Get(AV35Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV35Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV16Session.Get(AV35Pgmname+"GridState"), null, "", "");
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
         AV36GXV1 = 1;
         while ( AV36GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV36GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV17TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV17TFRubrosId", StringUtil.LTrimStr( (decimal)(AV17TFRubrosId), 4, 0));
               AV18TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV18TFRubrosId_To", StringUtil.LTrimStr( (decimal)(AV18TFRubrosId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFMEDIDASID") == 0 )
            {
               AV19TFMedidasID = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV19TFMedidasID", StringUtil.LTrimStr( (decimal)(AV19TFMedidasID), 18, 0));
               AV20TFMedidasID_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV20TFMedidasID_To", StringUtil.LTrimStr( (decimal)(AV20TFMedidasID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFINVENTARIOID") == 0 )
            {
               AV21TFInventarioId = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV21TFInventarioId", StringUtil.LTrimStr( (decimal)(AV21TFInventarioId), 18, 0));
               AV22TFInventarioId_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV22TFInventarioId_To", StringUtil.LTrimStr( (decimal)(AV22TFInventarioId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFINVENTARIOPRECIOFINAL") == 0 )
            {
               AV23TFInventarioPrecioFinal = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV23TFInventarioPrecioFinal", StringUtil.LTrimStr( AV23TFInventarioPrecioFinal, 18, 2));
               AV24TFInventarioPrecioFinal_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV24TFInventarioPrecioFinal_To", StringUtil.LTrimStr( AV24TFInventarioPrecioFinal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCOMISIONESAGRUPARRUBROSVALOR") == 0 )
            {
               AV25TFComisionesAgruparRubrosValor = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV25TFComisionesAgruparRubrosValor", StringUtil.LTrimStr( AV25TFComisionesAgruparRubrosValor, 18, 2));
               AV26TFComisionesAgruparRubrosValor_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV26TFComisionesAgruparRubrosValor_To", StringUtil.LTrimStr( AV26TFComisionesAgruparRubrosValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCOMISIONESAGRUPARRUBROSGAN") == 0 )
            {
               AV27TFComisionesAgruparRubrosGan = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV27TFComisionesAgruparRubrosGan", StringUtil.LTrimStr( AV27TFComisionesAgruparRubrosGan, 18, 2));
               AV28TFComisionesAgruparRubrosGan_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV28TFComisionesAgruparRubrosGan_To", StringUtil.LTrimStr( AV28TFComisionesAgruparRubrosGan_To, 18, 2));
            }
            AV36GXV1 = (int)(AV36GXV1+1);
         }
         Ddo_grid_Filteredtext_set = ((0==AV17TFRubrosId) ? "" : StringUtil.Str( (decimal)(AV17TFRubrosId), 4, 0))+"|"+((0==AV19TFMedidasID) ? "" : StringUtil.Str( (decimal)(AV19TFMedidasID), 18, 0))+"|"+((0==AV21TFInventarioId) ? "" : StringUtil.Str( (decimal)(AV21TFInventarioId), 18, 0))+"|"+((Convert.ToDecimal(0)==AV23TFInventarioPrecioFinal) ? "" : StringUtil.Str( AV23TFInventarioPrecioFinal, 18, 2))+"|"+((Convert.ToDecimal(0)==AV25TFComisionesAgruparRubrosValor) ? "" : StringUtil.Str( AV25TFComisionesAgruparRubrosValor, 18, 2))+"|"+((Convert.ToDecimal(0)==AV27TFComisionesAgruparRubrosGan) ? "" : StringUtil.Str( AV27TFComisionesAgruparRubrosGan, 18, 2));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV18TFRubrosId_To) ? "" : StringUtil.Str( (decimal)(AV18TFRubrosId_To), 4, 0))+"|"+((0==AV20TFMedidasID_To) ? "" : StringUtil.Str( (decimal)(AV20TFMedidasID_To), 18, 0))+"|"+((0==AV22TFInventarioId_To) ? "" : StringUtil.Str( (decimal)(AV22TFInventarioId_To), 18, 0))+"|"+((Convert.ToDecimal(0)==AV24TFInventarioPrecioFinal_To) ? "" : StringUtil.Str( AV24TFInventarioPrecioFinal_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV26TFComisionesAgruparRubrosValor_To) ? "" : StringUtil.Str( AV26TFComisionesAgruparRubrosValor_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV28TFComisionesAgruparRubrosGan_To) ? "" : StringUtil.Str( AV28TFComisionesAgruparRubrosGan_To, 18, 2));
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
         AV12GridState.FromXml(AV16Session.Get(AV35Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFRUBROSID",  context.GetMessage( "Rubros Identificador ", ""),  !((0==AV17TFRubrosId)&&(0==AV18TFRubrosId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV17TFRubrosId), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV18TFRubrosId_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFMEDIDASID",  context.GetMessage( "Items/Característica", ""),  !((0==AV19TFMedidasID)&&(0==AV20TFMedidasID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV19TFMedidasID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV20TFMedidasID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFINVENTARIOID",  context.GetMessage( "Detalle", ""),  !((0==AV21TFInventarioId)&&(0==AV22TFInventarioId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV21TFInventarioId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV22TFInventarioId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFINVENTARIOPRECIOFINAL",  context.GetMessage( "Precio", ""),  !((Convert.ToDecimal(0)==AV23TFInventarioPrecioFinal)&&(Convert.ToDecimal(0)==AV24TFInventarioPrecioFinal_To)),  0,  StringUtil.Trim( StringUtil.Str( AV23TFInventarioPrecioFinal, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV24TFInventarioPrecioFinal_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCOMISIONESAGRUPARRUBROSVALOR",  context.GetMessage( "Valor/Costo", ""),  !((Convert.ToDecimal(0)==AV25TFComisionesAgruparRubrosValor)&&(Convert.ToDecimal(0)==AV26TFComisionesAgruparRubrosValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV25TFComisionesAgruparRubrosValor, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV26TFComisionesAgruparRubrosValor_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCOMISIONESAGRUPARRUBROSGAN",  context.GetMessage( "Ganancia", ""),  !((Convert.ToDecimal(0)==AV27TFComisionesAgruparRubrosGan)&&(Convert.ToDecimal(0)==AV28TFComisionesAgruparRubrosGan_To)),  0,  StringUtil.Trim( StringUtil.Str( AV27TFComisionesAgruparRubrosGan, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV28TFComisionesAgruparRubrosGan_To, 18, 2))) ;
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV35Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV35Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "ComisionesAgrupar";
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
         PA4I2( ) ;
         WS4I2( ) ;
         WE4I2( ) ;
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
         PA4I2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "comisionesagruparrubroswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4I2( ) ;
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
         PA4I2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4I2( ) ;
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
         WS4I2( ) ;
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
         WE4I2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026730212656", true, true, false);
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
         context.AddJavascriptSource("comisionesagruparrubroswc.js", "?2026730212656", false, true, false);
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
         edtComisionesAgruparRubrosId_Internalname = sPrefix+"COMISIONESAGRUPARRUBROSID_"+sGXsfl_15_idx;
         edtRubrosId_Internalname = sPrefix+"RUBROSID_"+sGXsfl_15_idx;
         edtMedidasID_Internalname = sPrefix+"MEDIDASID_"+sGXsfl_15_idx;
         edtInventarioId_Internalname = sPrefix+"INVENTARIOID_"+sGXsfl_15_idx;
         edtInventarioPrecioFinal_Internalname = sPrefix+"INVENTARIOPRECIOFINAL_"+sGXsfl_15_idx;
         edtComisionesAgruparRubrosValor_Internalname = sPrefix+"COMISIONESAGRUPARRUBROSVALOR_"+sGXsfl_15_idx;
         edtComisionesAgruparRubrosGan_Internalname = sPrefix+"COMISIONESAGRUPARRUBROSGAN_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         edtComisionesAgruparRubrosId_Internalname = sPrefix+"COMISIONESAGRUPARRUBROSID_"+sGXsfl_15_fel_idx;
         edtRubrosId_Internalname = sPrefix+"RUBROSID_"+sGXsfl_15_fel_idx;
         edtMedidasID_Internalname = sPrefix+"MEDIDASID_"+sGXsfl_15_fel_idx;
         edtInventarioId_Internalname = sPrefix+"INVENTARIOID_"+sGXsfl_15_fel_idx;
         edtInventarioPrecioFinal_Internalname = sPrefix+"INVENTARIOPRECIOFINAL_"+sGXsfl_15_fel_idx;
         edtComisionesAgruparRubrosValor_Internalname = sPrefix+"COMISIONESAGRUPARRUBROSVALOR_"+sGXsfl_15_fel_idx;
         edtComisionesAgruparRubrosGan_Internalname = sPrefix+"COMISIONESAGRUPARRUBROSGAN_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         WB4I0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtComisionesAgruparRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A513ComisionesAgruparRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A513ComisionesAgruparRubrosId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtComisionesAgruparRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A181InventarioPrecioFinal, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtComisionesAgruparRubrosValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A515ComisionesAgruparRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A515ComisionesAgruparRubrosValor, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtComisionesAgruparRubrosValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtComisionesAgruparRubrosGan_Internalname,StringUtil.LTrim( StringUtil.NToC( A517ComisionesAgruparRubrosGan, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A517ComisionesAgruparRubrosGan, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtComisionesAgruparRubrosGan_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes4I2( ) ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nro.", "")) ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Valor/Costo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Ganancia", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A513ComisionesAgruparRubrosId), 18, 0, ".", ""))));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A515ComisionesAgruparRubrosValor, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A517ComisionesAgruparRubrosGan, 18, 2, ".", ""))));
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
         edtComisionesAgruparRubrosId_Internalname = sPrefix+"COMISIONESAGRUPARRUBROSID";
         edtRubrosId_Internalname = sPrefix+"RUBROSID";
         edtMedidasID_Internalname = sPrefix+"MEDIDASID";
         edtInventarioId_Internalname = sPrefix+"INVENTARIOID";
         edtInventarioPrecioFinal_Internalname = sPrefix+"INVENTARIOPRECIOFINAL";
         edtComisionesAgruparRubrosValor_Internalname = sPrefix+"COMISIONESAGRUPARRUBROSVALOR";
         edtComisionesAgruparRubrosGan_Internalname = sPrefix+"COMISIONESAGRUPARRUBROSGAN";
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
         edtComisionesAgruparRubrosGan_Jsonclick = "";
         edtComisionesAgruparRubrosValor_Jsonclick = "";
         edtInventarioPrecioFinal_Jsonclick = "";
         edtInventarioId_Jsonclick = "";
         edtMedidasID_Jsonclick = "";
         edtRubrosId_Jsonclick = "";
         edtComisionesAgruparRubrosId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtComisionesID_Enabled = 0;
         edtComisionesAgruparRubrosGan_Enabled = 0;
         edtComisionesAgruparRubrosValor_Enabled = 0;
         edtInventarioPrecioFinal_Enabled = 0;
         edtInventarioId_Enabled = 0;
         edtMedidasID_Enabled = 0;
         edtRubrosId_Enabled = 0;
         edtComisionesAgruparRubrosId_Enabled = 0;
         subGrid_Sortable = 0;
         edtComisionesID_Jsonclick = "";
         edtComisionesID_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "4.0|18.0|18.0|18.2|18.2|18.2";
         Ddo_grid_Filterisrange = "T";
         Ddo_grid_Filtertype = "Numeric|Numeric|Numeric|Numeric|Numeric|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|T|";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|";
         Ddo_grid_Columnids = "1:RubrosId|2:MedidasID|3:InventarioId|4:InventarioPrecioFinal|5:ComisionesAgruparRubrosValor|6:ComisionesAgruparRubrosGan";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV8ComisionesID',fld:'vCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'sPrefix',type:'char'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV18TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV19TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21TFInventarioId',fld:'vTFINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFInventarioId_To',fld:'vTFINVENTARIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFInventarioPrecioFinal',fld:'vTFINVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV24TFInventarioPrecioFinal_To',fld:'vTFINVENTARIOPRECIOFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV25TFComisionesAgruparRubrosValor',fld:'vTFCOMISIONESAGRUPARRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV26TFComisionesAgruparRubrosValor_To',fld:'vTFCOMISIONESAGRUPARRUBROSVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV27TFComisionesAgruparRubrosGan',fld:'vTFCOMISIONESAGRUPARRUBROSGAN',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV28TFComisionesAgruparRubrosGan_To',fld:'vTFCOMISIONESAGRUPARRUBROSGAN_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV32GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV33GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV34GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E114I2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8ComisionesID',fld:'vCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV18TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV19TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21TFInventarioId',fld:'vTFINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFInventarioId_To',fld:'vTFINVENTARIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFInventarioPrecioFinal',fld:'vTFINVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV24TFInventarioPrecioFinal_To',fld:'vTFINVENTARIOPRECIOFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV25TFComisionesAgruparRubrosValor',fld:'vTFCOMISIONESAGRUPARRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV26TFComisionesAgruparRubrosValor_To',fld:'vTFCOMISIONESAGRUPARRUBROSVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV27TFComisionesAgruparRubrosGan',fld:'vTFCOMISIONESAGRUPARRUBROSGAN',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV28TFComisionesAgruparRubrosGan_To',fld:'vTFCOMISIONESAGRUPARRUBROSGAN_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV32GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV33GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV34GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E124I2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8ComisionesID',fld:'vCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV18TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV19TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21TFInventarioId',fld:'vTFINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFInventarioId_To',fld:'vTFINVENTARIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFInventarioPrecioFinal',fld:'vTFINVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV24TFInventarioPrecioFinal_To',fld:'vTFINVENTARIOPRECIOFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV25TFComisionesAgruparRubrosValor',fld:'vTFCOMISIONESAGRUPARRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV26TFComisionesAgruparRubrosValor_To',fld:'vTFCOMISIONESAGRUPARRUBROSVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV27TFComisionesAgruparRubrosGan',fld:'vTFCOMISIONESAGRUPARRUBROSGAN',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV28TFComisionesAgruparRubrosGan_To',fld:'vTFCOMISIONESAGRUPARRUBROSGAN_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E134I2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8ComisionesID',fld:'vCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV18TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV19TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21TFInventarioId',fld:'vTFINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFInventarioId_To',fld:'vTFINVENTARIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFInventarioPrecioFinal',fld:'vTFINVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV24TFInventarioPrecioFinal_To',fld:'vTFINVENTARIOPRECIOFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV25TFComisionesAgruparRubrosValor',fld:'vTFCOMISIONESAGRUPARRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV26TFComisionesAgruparRubrosValor_To',fld:'vTFCOMISIONESAGRUPARRUBROSVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV27TFComisionesAgruparRubrosGan',fld:'vTFCOMISIONESAGRUPARRUBROSGAN',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV28TFComisionesAgruparRubrosGan_To',fld:'vTFCOMISIONESAGRUPARRUBROSGAN_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'sPrefix',type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV27TFComisionesAgruparRubrosGan',fld:'vTFCOMISIONESAGRUPARRUBROSGAN',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV28TFComisionesAgruparRubrosGan_To',fld:'vTFCOMISIONESAGRUPARRUBROSGAN_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV25TFComisionesAgruparRubrosValor',fld:'vTFCOMISIONESAGRUPARRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV26TFComisionesAgruparRubrosValor_To',fld:'vTFCOMISIONESAGRUPARRUBROSVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV23TFInventarioPrecioFinal',fld:'vTFINVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV24TFInventarioPrecioFinal_To',fld:'vTFINVENTARIOPRECIOFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV21TFInventarioId',fld:'vTFINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFInventarioId_To',fld:'vTFINVENTARIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV19TFMedidasID',fld:'vTFMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20TFMedidasID_To',fld:'vTFMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV17TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV18TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E164I2',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[]");
         setEventMetadata("VALID_RUBROSID",",oparms:[]}");
         setEventMetadata("VALID_MEDIDASID","{handler:'Valid_Medidasid',iparms:[]");
         setEventMetadata("VALID_MEDIDASID",",oparms:[]}");
         setEventMetadata("VALID_INVENTARIOID","{handler:'Valid_Inventarioid',iparms:[]");
         setEventMetadata("VALID_INVENTARIOID",",oparms:[]}");
         setEventMetadata("VALID_INVENTARIOPRECIOFINAL","{handler:'Valid_Inventariopreciofinal',iparms:[]");
         setEventMetadata("VALID_INVENTARIOPRECIOFINAL",",oparms:[]}");
         setEventMetadata("VALID_COMISIONESAGRUPARRUBROSVALOR","{handler:'Valid_Comisionesagruparrubrosvalor',iparms:[]");
         setEventMetadata("VALID_COMISIONESAGRUPARRUBROSVALOR",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Comisionesagruparrubrosgan',iparms:[]");
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
         AV35Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV34GridAppliedFilters = "";
         AV29DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
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
         GXDecQS = "";
         H004I2_A503ComisionesID = new long[1] ;
         H004I2_A135InventarioId = new long[1] ;
         H004I2_n135InventarioId = new bool[] {false} ;
         H004I2_A137MedidasID = new long[1] ;
         H004I2_n137MedidasID = new bool[] {false} ;
         H004I2_A121RubrosId = new short[1] ;
         H004I2_A513ComisionesAgruparRubrosId = new long[1] ;
         H004I2_A181InventarioPrecioFinal = new decimal[1] ;
         H004I2_A515ComisionesAgruparRubrosValor = new decimal[1] ;
         H004I3_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV16Session = context.GetSession();
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8ComisionesID = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisionesagruparrubroswc__default(),
            new Object[][] {
                new Object[] {
               H004I2_A503ComisionesID, H004I2_A135InventarioId, H004I2_n135InventarioId, H004I2_A137MedidasID, H004I2_n137MedidasID, H004I2_A121RubrosId, H004I2_A513ComisionesAgruparRubrosId, H004I2_A181InventarioPrecioFinal, H004I2_A515ComisionesAgruparRubrosValor
               }
               , new Object[] {
               H004I3_AGRID_nRecordCount
               }
            }
         );
         AV35Pgmname = "ComisionesAgruparRubrosWC";
         /* GeneXus formulas. */
         AV35Pgmname = "ComisionesAgruparRubrosWC";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14OrderedBy ;
      private short AV17TFRubrosId ;
      private short AV18TFRubrosId_To ;
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
      private int edtComisionesID_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtComisionesAgruparRubrosId_Enabled ;
      private int edtRubrosId_Enabled ;
      private int edtMedidasID_Enabled ;
      private int edtInventarioId_Enabled ;
      private int edtInventarioPrecioFinal_Enabled ;
      private int edtComisionesAgruparRubrosValor_Enabled ;
      private int edtComisionesAgruparRubrosGan_Enabled ;
      private int edtComisionesID_Enabled ;
      private int AV31PageToGo ;
      private int AV36GXV1 ;
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
      private long AV19TFMedidasID ;
      private long AV20TFMedidasID_To ;
      private long AV21TFInventarioId ;
      private long AV22TFInventarioId_To ;
      private long AV32GridCurrentPage ;
      private long AV33GridPageCount ;
      private long A503ComisionesID ;
      private long A513ComisionesAgruparRubrosId ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV23TFInventarioPrecioFinal ;
      private decimal AV24TFInventarioPrecioFinal_To ;
      private decimal AV25TFComisionesAgruparRubrosValor ;
      private decimal AV26TFComisionesAgruparRubrosValor_To ;
      private decimal AV27TFComisionesAgruparRubrosGan ;
      private decimal AV28TFComisionesAgruparRubrosGan_To ;
      private decimal A181InventarioPrecioFinal ;
      private decimal A515ComisionesAgruparRubrosValor ;
      private decimal A517ComisionesAgruparRubrosGan ;
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
      private string AV35Pgmname ;
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
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
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
      private string edtComisionesID_Internalname ;
      private string edtComisionesID_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtComisionesAgruparRubrosId_Internalname ;
      private string edtRubrosId_Internalname ;
      private string edtMedidasID_Internalname ;
      private string edtInventarioId_Internalname ;
      private string edtInventarioPrecioFinal_Internalname ;
      private string edtComisionesAgruparRubrosValor_Internalname ;
      private string edtComisionesAgruparRubrosGan_Internalname ;
      private string GXDecQS ;
      private string GXt_char2 ;
      private string sCtrlAV8ComisionesID ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtComisionesAgruparRubrosId_Jsonclick ;
      private string edtRubrosId_Jsonclick ;
      private string edtMedidasID_Jsonclick ;
      private string edtInventarioId_Jsonclick ;
      private string edtInventarioPrecioFinal_Jsonclick ;
      private string edtComisionesAgruparRubrosValor_Jsonclick ;
      private string edtComisionesAgruparRubrosGan_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n137MedidasID ;
      private bool n135InventarioId ;
      private bool bGXsfl_15_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV34GridAppliedFilters ;
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
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV29DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private long[] H004I2_A503ComisionesID ;
      private long[] H004I2_A135InventarioId ;
      private bool[] H004I2_n135InventarioId ;
      private long[] H004I2_A137MedidasID ;
      private bool[] H004I2_n137MedidasID ;
      private short[] H004I2_A121RubrosId ;
      private long[] H004I2_A513ComisionesAgruparRubrosId ;
      private decimal[] H004I2_A181InventarioPrecioFinal ;
      private decimal[] H004I2_A515ComisionesAgruparRubrosValor ;
      private long[] H004I3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class comisionesagruparrubroswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004I2( IGxContext context ,
                                             short AV17TFRubrosId ,
                                             short AV18TFRubrosId_To ,
                                             long AV19TFMedidasID ,
                                             long AV20TFMedidasID_To ,
                                             long AV21TFInventarioId ,
                                             long AV22TFInventarioId_To ,
                                             decimal AV23TFInventarioPrecioFinal ,
                                             decimal AV24TFInventarioPrecioFinal_To ,
                                             decimal AV25TFComisionesAgruparRubrosValor ,
                                             decimal AV26TFComisionesAgruparRubrosValor_To ,
                                             decimal AV27TFComisionesAgruparRubrosGan ,
                                             decimal AV28TFComisionesAgruparRubrosGan_To ,
                                             short A121RubrosId ,
                                             long A137MedidasID ,
                                             long A135InventarioId ,
                                             decimal A181InventarioPrecioFinal ,
                                             decimal A515ComisionesAgruparRubrosValor ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             long AV8ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[ComisionesID], T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T1.[ComisionesAgruparRubrosId], T2.[InventarioPrecioFinal], T1.[ComisionesAgruparRubrosValor]";
         sFromString = " FROM ([ComisionesAgruparRubros] T1 LEFT JOIN [Inventario] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID] AND T2.[InventarioId] = T1.[InventarioId])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[ComisionesID] = @AV8ComisionesID)");
         if ( ! (0==AV17TFRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV17TFRubrosId)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV18TFRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV18TFRubrosId_To)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV19TFMedidasID) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] >= @AV19TFMedidasID)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV20TFMedidasID_To) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] <= @AV20TFMedidasID_To)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV21TFInventarioId) )
         {
            AddWhere(sWhereString, "(T1.[InventarioId] >= @AV21TFInventarioId)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV22TFInventarioId_To) )
         {
            AddWhere(sWhereString, "(T1.[InventarioId] <= @AV22TFInventarioId_To)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV23TFInventarioPrecioFinal) )
         {
            AddWhere(sWhereString, "(T2.[InventarioPrecioFinal] >= @AV23TFInventarioPrecioFinal)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV24TFInventarioPrecioFinal_To) )
         {
            AddWhere(sWhereString, "(T2.[InventarioPrecioFinal] <= @AV24TFInventarioPrecioFinal_To)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV25TFComisionesAgruparRubrosValor) )
         {
            AddWhere(sWhereString, "(T1.[ComisionesAgruparRubrosValor] >= @AV25TFComisionesAgruparRubrosValor)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV26TFComisionesAgruparRubrosValor_To) )
         {
            AddWhere(sWhereString, "(T1.[ComisionesAgruparRubrosValor] <= @AV26TFComisionesAgruparRubrosValor_To)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV27TFComisionesAgruparRubrosGan) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[ComisionesAgruparRubrosValor] > 0 THEN ( T2.[InventarioPrecioFinal] * CAST(( CAST(T1.[ComisionesAgruparRubrosValor] AS decimal( 28, 10)) / 100) AS decimal( 28, 10))) END) >= @AV27TFComisionesAgruparRubrosGan)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV28TFComisionesAgruparRubrosGan_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[ComisionesAgruparRubrosValor] > 0 THEN ( T2.[InventarioPrecioFinal] * CAST(( CAST(T1.[ComisionesAgruparRubrosValor] AS decimal( 28, 10)) / 100) AS decimal( 28, 10))) END) <= @AV28TFComisionesAgruparRubrosGan_To)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ComisionesID], T1.[RubrosId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ComisionesID] DESC, T1.[RubrosId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ComisionesID], T1.[MedidasID]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ComisionesID] DESC, T1.[MedidasID] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ComisionesID], T1.[InventarioId]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ComisionesID] DESC, T1.[InventarioId] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ComisionesID], T2.[InventarioPrecioFinal]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ComisionesID] DESC, T2.[InventarioPrecioFinal] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ComisionesID], T1.[ComisionesAgruparRubrosValor]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ComisionesID] DESC, T1.[ComisionesAgruparRubrosValor] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[ComisionesID], T1.[ComisionesAgruparRubrosId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H004I3( IGxContext context ,
                                             short AV17TFRubrosId ,
                                             short AV18TFRubrosId_To ,
                                             long AV19TFMedidasID ,
                                             long AV20TFMedidasID_To ,
                                             long AV21TFInventarioId ,
                                             long AV22TFInventarioId_To ,
                                             decimal AV23TFInventarioPrecioFinal ,
                                             decimal AV24TFInventarioPrecioFinal_To ,
                                             decimal AV25TFComisionesAgruparRubrosValor ,
                                             decimal AV26TFComisionesAgruparRubrosValor_To ,
                                             decimal AV27TFComisionesAgruparRubrosGan ,
                                             decimal AV28TFComisionesAgruparRubrosGan_To ,
                                             short A121RubrosId ,
                                             long A137MedidasID ,
                                             long A135InventarioId ,
                                             decimal A181InventarioPrecioFinal ,
                                             decimal A515ComisionesAgruparRubrosValor ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             long AV8ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[13];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([ComisionesAgruparRubros] T1 LEFT JOIN [Inventario] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID] AND T2.[InventarioId] = T1.[InventarioId])";
         AddWhere(sWhereString, "(T1.[ComisionesID] = @AV8ComisionesID)");
         if ( ! (0==AV17TFRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV17TFRubrosId)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (0==AV18TFRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV18TFRubrosId_To)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV19TFMedidasID) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] >= @AV19TFMedidasID)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV20TFMedidasID_To) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] <= @AV20TFMedidasID_To)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (0==AV21TFInventarioId) )
         {
            AddWhere(sWhereString, "(T1.[InventarioId] >= @AV21TFInventarioId)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV22TFInventarioId_To) )
         {
            AddWhere(sWhereString, "(T1.[InventarioId] <= @AV22TFInventarioId_To)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV23TFInventarioPrecioFinal) )
         {
            AddWhere(sWhereString, "(T2.[InventarioPrecioFinal] >= @AV23TFInventarioPrecioFinal)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV24TFInventarioPrecioFinal_To) )
         {
            AddWhere(sWhereString, "(T2.[InventarioPrecioFinal] <= @AV24TFInventarioPrecioFinal_To)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV25TFComisionesAgruparRubrosValor) )
         {
            AddWhere(sWhereString, "(T1.[ComisionesAgruparRubrosValor] >= @AV25TFComisionesAgruparRubrosValor)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV26TFComisionesAgruparRubrosValor_To) )
         {
            AddWhere(sWhereString, "(T1.[ComisionesAgruparRubrosValor] <= @AV26TFComisionesAgruparRubrosValor_To)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV27TFComisionesAgruparRubrosGan) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[ComisionesAgruparRubrosValor] > 0 THEN ( T2.[InventarioPrecioFinal] * CAST(( CAST(T1.[ComisionesAgruparRubrosValor] AS decimal( 28, 10)) / 100) AS decimal( 28, 10))) END) >= @AV27TFComisionesAgruparRubrosGan)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV28TFComisionesAgruparRubrosGan_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[ComisionesAgruparRubrosValor] > 0 THEN ( T2.[InventarioPrecioFinal] * CAST(( CAST(T1.[ComisionesAgruparRubrosValor] AS decimal( 28, 10)) / 100) AS decimal( 28, 10))) END) <= @AV28TFComisionesAgruparRubrosGan_To)");
         }
         else
         {
            GXv_int5[12] = 1;
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H004I2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (short)dynConstraints[17] , (bool)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] );
               case 1 :
                     return conditional_H004I3(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (short)dynConstraints[17] , (bool)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] );
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
          Object[] prmH004I2;
          prmH004I2 = new Object[] {
          new ParDef("@AV8ComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@AV17TFRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV18TFRubrosId_To",GXType.Int16,4,0) ,
          new ParDef("@AV19TFMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV20TFMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV21TFInventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFInventarioId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV23TFInventarioPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV24TFInventarioPrecioFinal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV25TFComisionesAgruparRubrosValor",GXType.Decimal,18,2) ,
          new ParDef("@AV26TFComisionesAgruparRubrosValor_To",GXType.Decimal,18,2) ,
          new ParDef("@AV27TFComisionesAgruparRubrosGan",GXType.Decimal,18,2) ,
          new ParDef("@AV28TFComisionesAgruparRubrosGan_To",GXType.Decimal,18,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004I3;
          prmH004I3 = new Object[] {
          new ParDef("@AV8ComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@AV17TFRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV18TFRubrosId_To",GXType.Int16,4,0) ,
          new ParDef("@AV19TFMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV20TFMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV21TFInventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFInventarioId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV23TFInventarioPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV24TFInventarioPrecioFinal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV25TFComisionesAgruparRubrosValor",GXType.Decimal,18,2) ,
          new ParDef("@AV26TFComisionesAgruparRubrosValor_To",GXType.Decimal,18,2) ,
          new ParDef("@AV27TFComisionesAgruparRubrosGan",GXType.Decimal,18,2) ,
          new ParDef("@AV28TFComisionesAgruparRubrosGan_To",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("H004I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004I2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004I3,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
