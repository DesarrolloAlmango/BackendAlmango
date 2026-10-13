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
   public class historicosolicitudesitemswc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public historicosolicitudesitemswc( )
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

      public historicosolicitudesitemswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_HistoricoSolicitudesID )
      {
         this.AV8HistoricoSolicitudesID = aP0_HistoricoSolicitudesID;
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
               gxfirstwebparm = GetFirstPar( "HistoricoSolicitudesID");
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
                  AV8HistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "HistoricoSolicitudesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(AV8HistoricoSolicitudesID), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV8HistoricoSolicitudesID});
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
                  gxfirstwebparm = GetFirstPar( "HistoricoSolicitudesID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "HistoricoSolicitudesID");
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
         AV8HistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "HistoricoSolicitudesID"), "."), 18, MidpointRounding.ToEven));
         AV49Pgmname = GetPar( "Pgmname");
         AV17TFHistoricoSolicitudesItemsID = (short)(Math.Round(NumberUtil.Val( GetPar( "TFHistoricoSolicitudesItemsID"), "."), 18, MidpointRounding.ToEven));
         AV18TFHistoricoSolicitudesItemsID_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFHistoricoSolicitudesItemsID_To"), "."), 18, MidpointRounding.ToEven));
         AV19TFHItemsRubrosId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHItemsRubrosId"), "."), 18, MidpointRounding.ToEven));
         AV20TFHItemsRubrosId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHItemsRubrosId_To"), "."), 18, MidpointRounding.ToEven));
         AV21TFHItemsRubrosNombre = GetPar( "TFHItemsRubrosNombre");
         AV22TFHItemsRubrosNombre_Sel = GetPar( "TFHItemsRubrosNombre_Sel");
         AV23TFHItemsMedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHItemsMedidasID"), "."), 18, MidpointRounding.ToEven));
         AV24TFHItemsMedidasID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHItemsMedidasID_To"), "."), 18, MidpointRounding.ToEven));
         AV25TFHItemsInventarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHItemsInventarioId"), "."), 18, MidpointRounding.ToEven));
         AV26TFHItemsInventarioId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHItemsInventarioId_To"), "."), 18, MidpointRounding.ToEven));
         AV27TFHItemsInventarioNombre = GetPar( "TFHItemsInventarioNombre");
         AV28TFHItemsInventarioNombre_Sel = GetPar( "TFHItemsInventarioNombre_Sel");
         AV29TFHItemsInventarioPrecioFinal = (short)(Math.Round(NumberUtil.Val( GetPar( "TFHItemsInventarioPrecioFinal"), "."), 18, MidpointRounding.ToEven));
         AV30TFHItemsInventarioPrecioFinal_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFHItemsInventarioPrecioFinal_To"), "."), 18, MidpointRounding.ToEven));
         AV31TFHItemsSolicitudesItemsCantidad = (short)(Math.Round(NumberUtil.Val( GetPar( "TFHItemsSolicitudesItemsCantidad"), "."), 18, MidpointRounding.ToEven));
         AV32TFHItemsSolicitudesItemsCantidad_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFHItemsSolicitudesItemsCantidad_To"), "."), 18, MidpointRounding.ToEven));
         AV33TFHItemsSolicitudesItemsPrecioInstalacion = NumberUtil.Val( GetPar( "TFHItemsSolicitudesItemsPrecioInstalacion"), ".");
         AV34TFHItemsSolicitudesItemsPrecioInstalacion_To = NumberUtil.Val( GetPar( "TFHItemsSolicitudesItemsPrecioInstalacion_To"), ".");
         AV35TFHItemsSolicitudesMonedaId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHItemsSolicitudesMonedaId"), "."), 18, MidpointRounding.ToEven));
         AV36TFHItemsSolicitudesMonedaId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHItemsSolicitudesMonedaId_To"), "."), 18, MidpointRounding.ToEven));
         AV37TFHistoricoSolicitudesItemsSR = GetPar( "TFHistoricoSolicitudesItemsSR");
         AV38TFHistoricoSolicitudesItemsSR_Sel = GetPar( "TFHistoricoSolicitudesItemsSR_Sel");
         AV39TFHistoricoSolicitudesItemsCT = GetPar( "TFHistoricoSolicitudesItemsCT");
         AV40TFHistoricoSolicitudesItemsCT_Sel = GetPar( "TFHistoricoSolicitudesItemsCT_Sel");
         AV41TFHistoricoSolicitudesItemsComision = NumberUtil.Val( GetPar( "TFHistoricoSolicitudesItemsComision"), ".");
         AV42TFHistoricoSolicitudesItemsComision_To = NumberUtil.Val( GetPar( "TFHistoricoSolicitudesItemsComision_To"), ".");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8HistoricoSolicitudesID, AV49Pgmname, AV17TFHistoricoSolicitudesItemsID, AV18TFHistoricoSolicitudesItemsID_To, AV19TFHItemsRubrosId, AV20TFHItemsRubrosId_To, AV21TFHItemsRubrosNombre, AV22TFHItemsRubrosNombre_Sel, AV23TFHItemsMedidasID, AV24TFHItemsMedidasID_To, AV25TFHItemsInventarioId, AV26TFHItemsInventarioId_To, AV27TFHItemsInventarioNombre, AV28TFHItemsInventarioNombre_Sel, AV29TFHItemsInventarioPrecioFinal, AV30TFHItemsInventarioPrecioFinal_To, AV31TFHItemsSolicitudesItemsCantidad, AV32TFHItemsSolicitudesItemsCantidad_To, AV33TFHItemsSolicitudesItemsPrecioInstalacion, AV34TFHItemsSolicitudesItemsPrecioInstalacion_To, AV35TFHItemsSolicitudesMonedaId, AV36TFHItemsSolicitudesMonedaId_To, AV37TFHistoricoSolicitudesItemsSR, AV38TFHistoricoSolicitudesItemsSR_Sel, AV39TFHistoricoSolicitudesItemsCT, AV40TFHistoricoSolicitudesItemsCT_Sel, AV41TFHistoricoSolicitudesItemsComision, AV42TFHistoricoSolicitudesItemsComision_To, sPrefix) ;
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
            PA2K2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV49Pgmname = "HistoricoSolicitudesItemsWC";
               WS2K2( ) ;
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
            context.SendWebValue( context.GetMessage( "Historico Solicitudes Items WC", "")) ;
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
            GXEncryptionTmp = "historicosolicitudesitemswc.aspx"+UrlEncode(StringUtil.LTrimStr(AV8HistoricoSolicitudesID,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("historicosolicitudesitemswc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8HistoricoSolicitudesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESITEMSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17TFHistoricoSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESITEMSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18TFHistoricoSolicitudesItemsID_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19TFHItemsRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSRUBROSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20TFHItemsRubrosId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSRUBROSNOMBRE", StringUtil.RTrim( AV21TFHItemsRubrosNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSRUBROSNOMBRE_SEL", StringUtil.RTrim( AV22TFHItemsRubrosNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSMEDIDASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23TFHItemsMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSMEDIDASID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24TFHItemsMedidasID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSINVENTARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25TFHItemsInventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSINVENTARIOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26TFHItemsInventarioId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSINVENTARIONOMBRE", StringUtil.RTrim( AV27TFHItemsInventarioNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSINVENTARIONOMBRE_SEL", StringUtil.RTrim( AV28TFHItemsInventarioNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSINVENTARIOPRECIOFINAL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29TFHItemsInventarioPrecioFinal), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSINVENTARIOPRECIOFINAL_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30TFHItemsInventarioPrecioFinal_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSSOLICITUDESITEMSCANTIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TFHItemsSolicitudesItemsCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSSOLICITUDESITEMSCANTIDAD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TFHItemsSolicitudesItemsCantidad_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSSOLICITUDESITEMSPRECIOINSTALACION", StringUtil.LTrim( StringUtil.NToC( AV33TFHItemsSolicitudesItemsPrecioInstalacion, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSSOLICITUDESITEMSPRECIOINSTALACION_TO", StringUtil.LTrim( StringUtil.NToC( AV34TFHItemsSolicitudesItemsPrecioInstalacion_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSSOLICITUDESMONEDAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35TFHItemsSolicitudesMonedaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHITEMSSOLICITUDESMONEDAID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36TFHItemsSolicitudesMonedaId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESITEMSSR", StringUtil.RTrim( AV37TFHistoricoSolicitudesItemsSR));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESITEMSSR_SEL", StringUtil.RTrim( AV38TFHistoricoSolicitudesItemsSR_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESITEMSCT", StringUtil.RTrim( AV39TFHistoricoSolicitudesItemsCT));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESITEMSCT_SEL", StringUtil.RTrim( AV40TFHistoricoSolicitudesItemsCT_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESITEMSCOMISION", StringUtil.LTrim( StringUtil.NToC( AV41TFHistoricoSolicitudesItemsComision, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESITEMSCOMISION_TO", StringUtil.LTrim( StringUtil.NToC( AV42TFHistoricoSolicitudesItemsComision_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vHISTORICOSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
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

      protected void RenderHtmlCloseForm2K2( )
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
         return "HistoricoSolicitudesItemsWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Historico Solicitudes Items WC", "") ;
      }

      protected void WB2K0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "historicosolicitudesitemswc.aspx");
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
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV43DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A153HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A153HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesID_Jsonclick, 0, "Attribute", "", "", "", "", edtHistoricoSolicitudesID_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_HistoricoSolicitudesItemsWC.htm");
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

      protected void START2K2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Historico Solicitudes Items WC", ""), 0) ;
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
               STRUP2K0( ) ;
            }
         }
      }

      protected void WS2K2( )
      {
         START2K2( ) ;
         EVT2K2( ) ;
      }

      protected void EVT2K2( )
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
                                 STRUP2K0( ) ;
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
                                 STRUP2K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E112K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E122K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E132K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2K0( ) ;
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
                                 STRUP2K0( ) ;
                              }
                              nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              A154HistoricoSolicitudesItemsID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesItemsID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A330HItemsRubrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A331HItemsRubrosNombre = cgiGet( edtHItemsRubrosNombre_Internalname);
                              A327HItemsMedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsMedidasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A328HItemsInventarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsInventarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A329HItemsInventarioNombre = cgiGet( edtHItemsInventarioNombre_Internalname);
                              A295HItemsInventarioPrecioFinal = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsInventarioPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A293HItemsSolicitudesItemsCantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsSolicitudesItemsCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A294HItemsSolicitudesItemsPrecioIn = context.localUtil.CToN( cgiGet( edtHItemsSolicitudesItemsPrecioIn_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A319HItemsSolicitudesMonedaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsSolicitudesMonedaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A296HistoricoSolicitudesItemsSR = cgiGet( edtHistoricoSolicitudesItemsSR_Internalname);
                              A297HistoricoSolicitudesItemsCT = cgiGet( edtHistoricoSolicitudesItemsCT_Internalname);
                              A298HistoricoSolicitudesItemsComis = context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesItemsComis_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
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
                                          E142K2 ();
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
                                          E152K2 ();
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
                                          E162K2 ();
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
                                       STRUP2K0( ) ;
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

      protected void WE2K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2K2( ) ;
            }
         }
      }

      protected void PA2K2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "historicosolicitudesitemswc.aspx")), "historicosolicitudesitemswc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "historicosolicitudesitemswc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "HistoricoSolicitudesID");
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
                                       long AV8HistoricoSolicitudesID ,
                                       string AV49Pgmname ,
                                       short AV17TFHistoricoSolicitudesItemsID ,
                                       short AV18TFHistoricoSolicitudesItemsID_To ,
                                       long AV19TFHItemsRubrosId ,
                                       long AV20TFHItemsRubrosId_To ,
                                       string AV21TFHItemsRubrosNombre ,
                                       string AV22TFHItemsRubrosNombre_Sel ,
                                       long AV23TFHItemsMedidasID ,
                                       long AV24TFHItemsMedidasID_To ,
                                       long AV25TFHItemsInventarioId ,
                                       long AV26TFHItemsInventarioId_To ,
                                       string AV27TFHItemsInventarioNombre ,
                                       string AV28TFHItemsInventarioNombre_Sel ,
                                       short AV29TFHItemsInventarioPrecioFinal ,
                                       short AV30TFHItemsInventarioPrecioFinal_To ,
                                       short AV31TFHItemsSolicitudesItemsCantidad ,
                                       short AV32TFHItemsSolicitudesItemsCantidad_To ,
                                       decimal AV33TFHItemsSolicitudesItemsPrecioInstalacion ,
                                       decimal AV34TFHItemsSolicitudesItemsPrecioInstalacion_To ,
                                       long AV35TFHItemsSolicitudesMonedaId ,
                                       long AV36TFHItemsSolicitudesMonedaId_To ,
                                       string AV37TFHistoricoSolicitudesItemsSR ,
                                       string AV38TFHistoricoSolicitudesItemsSR_Sel ,
                                       string AV39TFHistoricoSolicitudesItemsCT ,
                                       string AV40TFHistoricoSolicitudesItemsCT_Sel ,
                                       decimal AV41TFHistoricoSolicitudesItemsComision ,
                                       decimal AV42TFHistoricoSolicitudesItemsComision_To ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2K2( ) ;
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
         RF2K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV49Pgmname = "HistoricoSolicitudesItemsWC";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV17TFHistoricoSolicitudesItemsID ,
                                              AV18TFHistoricoSolicitudesItemsID_To ,
                                              AV19TFHItemsRubrosId ,
                                              AV20TFHItemsRubrosId_To ,
                                              AV22TFHItemsRubrosNombre_Sel ,
                                              AV21TFHItemsRubrosNombre ,
                                              AV23TFHItemsMedidasID ,
                                              AV24TFHItemsMedidasID_To ,
                                              AV25TFHItemsInventarioId ,
                                              AV26TFHItemsInventarioId_To ,
                                              AV28TFHItemsInventarioNombre_Sel ,
                                              AV27TFHItemsInventarioNombre ,
                                              AV29TFHItemsInventarioPrecioFinal ,
                                              AV30TFHItemsInventarioPrecioFinal_To ,
                                              AV31TFHItemsSolicitudesItemsCantidad ,
                                              AV32TFHItemsSolicitudesItemsCantidad_To ,
                                              AV35TFHItemsSolicitudesMonedaId ,
                                              AV36TFHItemsSolicitudesMonedaId_To ,
                                              AV38TFHistoricoSolicitudesItemsSR_Sel ,
                                              AV37TFHistoricoSolicitudesItemsSR ,
                                              AV40TFHistoricoSolicitudesItemsCT_Sel ,
                                              AV39TFHistoricoSolicitudesItemsCT ,
                                              AV41TFHistoricoSolicitudesItemsComision ,
                                              AV42TFHistoricoSolicitudesItemsComision_To ,
                                              A154HistoricoSolicitudesItemsID ,
                                              A330HItemsRubrosId ,
                                              A331HItemsRubrosNombre ,
                                              A327HItemsMedidasID ,
                                              A328HItemsInventarioId ,
                                              A329HItemsInventarioNombre ,
                                              A295HItemsInventarioPrecioFinal ,
                                              A293HItemsSolicitudesItemsCantidad ,
                                              A319HItemsSolicitudesMonedaId ,
                                              A296HistoricoSolicitudesItemsSR ,
                                              A297HistoricoSolicitudesItemsCT ,
                                              A298HistoricoSolicitudesItemsComis ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV33TFHItemsSolicitudesItemsPrecioInstalacion ,
                                              A294HItemsSolicitudesItemsPrecioIn ,
                                              AV34TFHItemsSolicitudesItemsPrecioInstalacion_To ,
                                              AV8HistoricoSolicitudesID ,
                                              A153HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG,
                                              TypeConstants.LONG
                                              }
         });
         lV21TFHItemsRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFHItemsRubrosNombre), 100, "%");
         lV27TFHItemsInventarioNombre = StringUtil.PadR( StringUtil.RTrim( AV27TFHItemsInventarioNombre), 100, "%");
         lV37TFHistoricoSolicitudesItemsSR = StringUtil.PadR( StringUtil.RTrim( AV37TFHistoricoSolicitudesItemsSR), 1, "%");
         lV39TFHistoricoSolicitudesItemsCT = StringUtil.PadR( StringUtil.RTrim( AV39TFHistoricoSolicitudesItemsCT), 1, "%");
         /* Using cursor H002K2 */
         pr_default.execute(0, new Object[] {AV8HistoricoSolicitudesID, AV17TFHistoricoSolicitudesItemsID, AV18TFHistoricoSolicitudesItemsID_To, AV19TFHItemsRubrosId, AV20TFHItemsRubrosId_To, lV21TFHItemsRubrosNombre, AV22TFHItemsRubrosNombre_Sel, AV23TFHItemsMedidasID, AV24TFHItemsMedidasID_To, AV25TFHItemsInventarioId, AV26TFHItemsInventarioId_To, lV27TFHItemsInventarioNombre, AV28TFHItemsInventarioNombre_Sel, AV29TFHItemsInventarioPrecioFinal, AV30TFHItemsInventarioPrecioFinal_To, AV31TFHItemsSolicitudesItemsCantidad, AV32TFHItemsSolicitudesItemsCantidad_To, AV35TFHItemsSolicitudesMonedaId, AV36TFHItemsSolicitudesMonedaId_To, lV37TFHistoricoSolicitudesItemsSR, AV38TFHistoricoSolicitudesItemsSR_Sel, lV39TFHistoricoSolicitudesItemsCT, AV40TFHistoricoSolicitudesItemsCT_Sel, AV41TFHistoricoSolicitudesItemsComision, AV42TFHistoricoSolicitudesItemsComision_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A153HistoricoSolicitudesID = H002K2_A153HistoricoSolicitudesID[0];
            AssignAttri(sPrefix, false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
            A319HItemsSolicitudesMonedaId = H002K2_A319HItemsSolicitudesMonedaId[0];
            A329HItemsInventarioNombre = H002K2_A329HItemsInventarioNombre[0];
            A328HItemsInventarioId = H002K2_A328HItemsInventarioId[0];
            A327HItemsMedidasID = H002K2_A327HItemsMedidasID[0];
            A331HItemsRubrosNombre = H002K2_A331HItemsRubrosNombre[0];
            A330HItemsRubrosId = H002K2_A330HItemsRubrosId[0];
            A154HistoricoSolicitudesItemsID = H002K2_A154HistoricoSolicitudesItemsID[0];
            A298HistoricoSolicitudesItemsComis = H002K2_A298HistoricoSolicitudesItemsComis[0];
            A297HistoricoSolicitudesItemsCT = H002K2_A297HistoricoSolicitudesItemsCT[0];
            A296HistoricoSolicitudesItemsSR = H002K2_A296HistoricoSolicitudesItemsSR[0];
            A293HItemsSolicitudesItemsCantidad = H002K2_A293HItemsSolicitudesItemsCantidad[0];
            A295HItemsInventarioPrecioFinal = H002K2_A295HItemsInventarioPrecioFinal[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A296HistoricoSolicitudesItemsSR)) || ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "N", "")) == 0 ) )
            {
               A294HItemsSolicitudesItemsPrecioIn = (decimal)(A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad);
            }
            else
            {
               if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
               {
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                  {
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
                     {
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                        {
                           A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                        }
                        else
                        {
                           A294HItemsSolicitudesItemsPrecioIn = 0;
                        }
                     }
                  }
               }
            }
            if ( (Convert.ToDecimal(0)==AV33TFHItemsSolicitudesItemsPrecioInstalacion) || ( ( A294HItemsSolicitudesItemsPrecioIn >= AV33TFHItemsSolicitudesItemsPrecioInstalacion ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV34TFHItemsSolicitudesItemsPrecioInstalacion_To) || ( ( A294HItemsSolicitudesItemsPrecioIn <= AV34TFHItemsSolicitudesItemsPrecioInstalacion_To ) ) )
               {
                  GRID_nRecordCount = (long)(GRID_nRecordCount+1);
               }
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF2K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 15;
         /* Execute user event: Refresh */
         E152K2 ();
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
                                                 AV17TFHistoricoSolicitudesItemsID ,
                                                 AV18TFHistoricoSolicitudesItemsID_To ,
                                                 AV19TFHItemsRubrosId ,
                                                 AV20TFHItemsRubrosId_To ,
                                                 AV22TFHItemsRubrosNombre_Sel ,
                                                 AV21TFHItemsRubrosNombre ,
                                                 AV23TFHItemsMedidasID ,
                                                 AV24TFHItemsMedidasID_To ,
                                                 AV25TFHItemsInventarioId ,
                                                 AV26TFHItemsInventarioId_To ,
                                                 AV28TFHItemsInventarioNombre_Sel ,
                                                 AV27TFHItemsInventarioNombre ,
                                                 AV29TFHItemsInventarioPrecioFinal ,
                                                 AV30TFHItemsInventarioPrecioFinal_To ,
                                                 AV31TFHItemsSolicitudesItemsCantidad ,
                                                 AV32TFHItemsSolicitudesItemsCantidad_To ,
                                                 AV35TFHItemsSolicitudesMonedaId ,
                                                 AV36TFHItemsSolicitudesMonedaId_To ,
                                                 AV38TFHistoricoSolicitudesItemsSR_Sel ,
                                                 AV37TFHistoricoSolicitudesItemsSR ,
                                                 AV40TFHistoricoSolicitudesItemsCT_Sel ,
                                                 AV39TFHistoricoSolicitudesItemsCT ,
                                                 AV41TFHistoricoSolicitudesItemsComision ,
                                                 AV42TFHistoricoSolicitudesItemsComision_To ,
                                                 A154HistoricoSolicitudesItemsID ,
                                                 A330HItemsRubrosId ,
                                                 A331HItemsRubrosNombre ,
                                                 A327HItemsMedidasID ,
                                                 A328HItemsInventarioId ,
                                                 A329HItemsInventarioNombre ,
                                                 A295HItemsInventarioPrecioFinal ,
                                                 A293HItemsSolicitudesItemsCantidad ,
                                                 A319HItemsSolicitudesMonedaId ,
                                                 A296HistoricoSolicitudesItemsSR ,
                                                 A297HistoricoSolicitudesItemsCT ,
                                                 A298HistoricoSolicitudesItemsComis ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV33TFHItemsSolicitudesItemsPrecioInstalacion ,
                                                 A294HItemsSolicitudesItemsPrecioIn ,
                                                 AV34TFHItemsSolicitudesItemsPrecioInstalacion_To ,
                                                 AV8HistoricoSolicitudesID ,
                                                 A153HistoricoSolicitudesID } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG,
                                                 TypeConstants.LONG
                                                 }
            });
            lV21TFHItemsRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFHItemsRubrosNombre), 100, "%");
            lV27TFHItemsInventarioNombre = StringUtil.PadR( StringUtil.RTrim( AV27TFHItemsInventarioNombre), 100, "%");
            lV37TFHistoricoSolicitudesItemsSR = StringUtil.PadR( StringUtil.RTrim( AV37TFHistoricoSolicitudesItemsSR), 1, "%");
            lV39TFHistoricoSolicitudesItemsCT = StringUtil.PadR( StringUtil.RTrim( AV39TFHistoricoSolicitudesItemsCT), 1, "%");
            /* Using cursor H002K3 */
            pr_default.execute(1, new Object[] {AV8HistoricoSolicitudesID, AV17TFHistoricoSolicitudesItemsID, AV18TFHistoricoSolicitudesItemsID_To, AV19TFHItemsRubrosId, AV20TFHItemsRubrosId_To, lV21TFHItemsRubrosNombre, AV22TFHItemsRubrosNombre_Sel, AV23TFHItemsMedidasID, AV24TFHItemsMedidasID_To, AV25TFHItemsInventarioId, AV26TFHItemsInventarioId_To, lV27TFHItemsInventarioNombre, AV28TFHItemsInventarioNombre_Sel, AV29TFHItemsInventarioPrecioFinal, AV30TFHItemsInventarioPrecioFinal_To, AV31TFHItemsSolicitudesItemsCantidad, AV32TFHItemsSolicitudesItemsCantidad_To, AV35TFHItemsSolicitudesMonedaId, AV36TFHItemsSolicitudesMonedaId_To, lV37TFHistoricoSolicitudesItemsSR, AV38TFHistoricoSolicitudesItemsSR_Sel, lV39TFHistoricoSolicitudesItemsCT, AV40TFHistoricoSolicitudesItemsCT_Sel, AV41TFHistoricoSolicitudesItemsComision, AV42TFHistoricoSolicitudesItemsComision_To});
            nGXsfl_15_idx = 1;
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A153HistoricoSolicitudesID = H002K3_A153HistoricoSolicitudesID[0];
               AssignAttri(sPrefix, false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
               A319HItemsSolicitudesMonedaId = H002K3_A319HItemsSolicitudesMonedaId[0];
               A329HItemsInventarioNombre = H002K3_A329HItemsInventarioNombre[0];
               A328HItemsInventarioId = H002K3_A328HItemsInventarioId[0];
               A327HItemsMedidasID = H002K3_A327HItemsMedidasID[0];
               A331HItemsRubrosNombre = H002K3_A331HItemsRubrosNombre[0];
               A330HItemsRubrosId = H002K3_A330HItemsRubrosId[0];
               A154HistoricoSolicitudesItemsID = H002K3_A154HistoricoSolicitudesItemsID[0];
               A298HistoricoSolicitudesItemsComis = H002K3_A298HistoricoSolicitudesItemsComis[0];
               A297HistoricoSolicitudesItemsCT = H002K3_A297HistoricoSolicitudesItemsCT[0];
               A296HistoricoSolicitudesItemsSR = H002K3_A296HistoricoSolicitudesItemsSR[0];
               A293HItemsSolicitudesItemsCantidad = H002K3_A293HItemsSolicitudesItemsCantidad[0];
               A295HItemsInventarioPrecioFinal = H002K3_A295HItemsInventarioPrecioFinal[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( A296HistoricoSolicitudesItemsSR)) || ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "N", "")) == 0 ) )
               {
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)(A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad);
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
                  {
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                     {
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
                        {
                           A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                        }
                        else
                        {
                           if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                           {
                              A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                           }
                           else
                           {
                              A294HItemsSolicitudesItemsPrecioIn = 0;
                           }
                        }
                     }
                  }
               }
               if ( (Convert.ToDecimal(0)==AV33TFHItemsSolicitudesItemsPrecioInstalacion) || ( ( A294HItemsSolicitudesItemsPrecioIn >= AV33TFHItemsSolicitudesItemsPrecioInstalacion ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV34TFHItemsSolicitudesItemsPrecioInstalacion_To) || ( ( A294HItemsSolicitudesItemsPrecioIn <= AV34TFHItemsSolicitudesItemsPrecioInstalacion_To ) ) )
                  {
                     /* Execute user event: Grid.Load */
                     E162K2 ();
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 15;
            WB2K0( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2K2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8HistoricoSolicitudesID, AV49Pgmname, AV17TFHistoricoSolicitudesItemsID, AV18TFHistoricoSolicitudesItemsID_To, AV19TFHItemsRubrosId, AV20TFHItemsRubrosId_To, AV21TFHItemsRubrosNombre, AV22TFHItemsRubrosNombre_Sel, AV23TFHItemsMedidasID, AV24TFHItemsMedidasID_To, AV25TFHItemsInventarioId, AV26TFHItemsInventarioId_To, AV27TFHItemsInventarioNombre, AV28TFHItemsInventarioNombre_Sel, AV29TFHItemsInventarioPrecioFinal, AV30TFHItemsInventarioPrecioFinal_To, AV31TFHItemsSolicitudesItemsCantidad, AV32TFHItemsSolicitudesItemsCantidad_To, AV33TFHItemsSolicitudesItemsPrecioInstalacion, AV34TFHItemsSolicitudesItemsPrecioInstalacion_To, AV35TFHItemsSolicitudesMonedaId, AV36TFHItemsSolicitudesMonedaId_To, AV37TFHistoricoSolicitudesItemsSR, AV38TFHistoricoSolicitudesItemsSR_Sel, AV39TFHistoricoSolicitudesItemsCT, AV40TFHistoricoSolicitudesItemsCT_Sel, AV41TFHistoricoSolicitudesItemsComision, AV42TFHistoricoSolicitudesItemsComision_To, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8HistoricoSolicitudesID, AV49Pgmname, AV17TFHistoricoSolicitudesItemsID, AV18TFHistoricoSolicitudesItemsID_To, AV19TFHItemsRubrosId, AV20TFHItemsRubrosId_To, AV21TFHItemsRubrosNombre, AV22TFHItemsRubrosNombre_Sel, AV23TFHItemsMedidasID, AV24TFHItemsMedidasID_To, AV25TFHItemsInventarioId, AV26TFHItemsInventarioId_To, AV27TFHItemsInventarioNombre, AV28TFHItemsInventarioNombre_Sel, AV29TFHItemsInventarioPrecioFinal, AV30TFHItemsInventarioPrecioFinal_To, AV31TFHItemsSolicitudesItemsCantidad, AV32TFHItemsSolicitudesItemsCantidad_To, AV33TFHItemsSolicitudesItemsPrecioInstalacion, AV34TFHItemsSolicitudesItemsPrecioInstalacion_To, AV35TFHItemsSolicitudesMonedaId, AV36TFHItemsSolicitudesMonedaId_To, AV37TFHistoricoSolicitudesItemsSR, AV38TFHistoricoSolicitudesItemsSR_Sel, AV39TFHistoricoSolicitudesItemsCT, AV40TFHistoricoSolicitudesItemsCT_Sel, AV41TFHistoricoSolicitudesItemsComision, AV42TFHistoricoSolicitudesItemsComision_To, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8HistoricoSolicitudesID, AV49Pgmname, AV17TFHistoricoSolicitudesItemsID, AV18TFHistoricoSolicitudesItemsID_To, AV19TFHItemsRubrosId, AV20TFHItemsRubrosId_To, AV21TFHItemsRubrosNombre, AV22TFHItemsRubrosNombre_Sel, AV23TFHItemsMedidasID, AV24TFHItemsMedidasID_To, AV25TFHItemsInventarioId, AV26TFHItemsInventarioId_To, AV27TFHItemsInventarioNombre, AV28TFHItemsInventarioNombre_Sel, AV29TFHItemsInventarioPrecioFinal, AV30TFHItemsInventarioPrecioFinal_To, AV31TFHItemsSolicitudesItemsCantidad, AV32TFHItemsSolicitudesItemsCantidad_To, AV33TFHItemsSolicitudesItemsPrecioInstalacion, AV34TFHItemsSolicitudesItemsPrecioInstalacion_To, AV35TFHItemsSolicitudesMonedaId, AV36TFHItemsSolicitudesMonedaId_To, AV37TFHistoricoSolicitudesItemsSR, AV38TFHistoricoSolicitudesItemsSR_Sel, AV39TFHistoricoSolicitudesItemsCT, AV40TFHistoricoSolicitudesItemsCT_Sel, AV41TFHistoricoSolicitudesItemsComision, AV42TFHistoricoSolicitudesItemsComision_To, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8HistoricoSolicitudesID, AV49Pgmname, AV17TFHistoricoSolicitudesItemsID, AV18TFHistoricoSolicitudesItemsID_To, AV19TFHItemsRubrosId, AV20TFHItemsRubrosId_To, AV21TFHItemsRubrosNombre, AV22TFHItemsRubrosNombre_Sel, AV23TFHItemsMedidasID, AV24TFHItemsMedidasID_To, AV25TFHItemsInventarioId, AV26TFHItemsInventarioId_To, AV27TFHItemsInventarioNombre, AV28TFHItemsInventarioNombre_Sel, AV29TFHItemsInventarioPrecioFinal, AV30TFHItemsInventarioPrecioFinal_To, AV31TFHItemsSolicitudesItemsCantidad, AV32TFHItemsSolicitudesItemsCantidad_To, AV33TFHItemsSolicitudesItemsPrecioInstalacion, AV34TFHItemsSolicitudesItemsPrecioInstalacion_To, AV35TFHItemsSolicitudesMonedaId, AV36TFHItemsSolicitudesMonedaId_To, AV37TFHistoricoSolicitudesItemsSR, AV38TFHistoricoSolicitudesItemsSR_Sel, AV39TFHistoricoSolicitudesItemsCT, AV40TFHistoricoSolicitudesItemsCT_Sel, AV41TFHistoricoSolicitudesItemsComision, AV42TFHistoricoSolicitudesItemsComision_To, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8HistoricoSolicitudesID, AV49Pgmname, AV17TFHistoricoSolicitudesItemsID, AV18TFHistoricoSolicitudesItemsID_To, AV19TFHItemsRubrosId, AV20TFHItemsRubrosId_To, AV21TFHItemsRubrosNombre, AV22TFHItemsRubrosNombre_Sel, AV23TFHItemsMedidasID, AV24TFHItemsMedidasID_To, AV25TFHItemsInventarioId, AV26TFHItemsInventarioId_To, AV27TFHItemsInventarioNombre, AV28TFHItemsInventarioNombre_Sel, AV29TFHItemsInventarioPrecioFinal, AV30TFHItemsInventarioPrecioFinal_To, AV31TFHItemsSolicitudesItemsCantidad, AV32TFHItemsSolicitudesItemsCantidad_To, AV33TFHItemsSolicitudesItemsPrecioInstalacion, AV34TFHItemsSolicitudesItemsPrecioInstalacion_To, AV35TFHItemsSolicitudesMonedaId, AV36TFHItemsSolicitudesMonedaId_To, AV37TFHistoricoSolicitudesItemsSR, AV38TFHistoricoSolicitudesItemsSR_Sel, AV39TFHistoricoSolicitudesItemsCT, AV40TFHistoricoSolicitudesItemsCT_Sel, AV41TFHistoricoSolicitudesItemsComision, AV42TFHistoricoSolicitudesItemsComision_To, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV49Pgmname = "HistoricoSolicitudesItemsWC";
         edtHistoricoSolicitudesItemsID_Enabled = 0;
         edtHItemsRubrosId_Enabled = 0;
         edtHItemsRubrosNombre_Enabled = 0;
         edtHItemsMedidasID_Enabled = 0;
         edtHItemsInventarioId_Enabled = 0;
         edtHItemsInventarioNombre_Enabled = 0;
         edtHItemsInventarioPrecioFinal_Enabled = 0;
         edtHItemsSolicitudesItemsCantidad_Enabled = 0;
         edtHItemsSolicitudesItemsPrecioIn_Enabled = 0;
         edtHItemsSolicitudesMonedaId_Enabled = 0;
         edtHistoricoSolicitudesItemsSR_Enabled = 0;
         edtHistoricoSolicitudesItemsCT_Enabled = 0;
         edtHistoricoSolicitudesItemsComis_Enabled = 0;
         edtHistoricoSolicitudesID_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesID_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E142K2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV43DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_15 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_15"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV46GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV47GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV48GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOAV8HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8HistoricoSolicitudesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
            A153HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
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
         E142K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E142K2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         edtHistoricoSolicitudesID_Visible = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesID_Visible), 5, 0), true);
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV43DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV43DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E152K2( )
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
         AV46GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV46GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV46GridCurrentPage), 10, 0));
         AV47GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV47GridPageCount", StringUtil.LTrimStr( (decimal)(AV47GridPageCount), 10, 0));
         GXt_char2 = AV48GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV49Pgmname, out  GXt_char2) ;
         AV48GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV48GridAppliedFilters", AV48GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E112K2( )
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
      }

      protected void E122K2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E132K2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesItemsID") == 0 )
            {
               AV17TFHistoricoSolicitudesItemsID = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV17TFHistoricoSolicitudesItemsID", StringUtil.LTrimStr( (decimal)(AV17TFHistoricoSolicitudesItemsID), 4, 0));
               AV18TFHistoricoSolicitudesItemsID_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV18TFHistoricoSolicitudesItemsID_To", StringUtil.LTrimStr( (decimal)(AV18TFHistoricoSolicitudesItemsID_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HItemsRubrosId") == 0 )
            {
               AV19TFHItemsRubrosId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV19TFHItemsRubrosId", StringUtil.LTrimStr( (decimal)(AV19TFHItemsRubrosId), 18, 0));
               AV20TFHItemsRubrosId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV20TFHItemsRubrosId_To", StringUtil.LTrimStr( (decimal)(AV20TFHItemsRubrosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HItemsRubrosNombre") == 0 )
            {
               AV21TFHItemsRubrosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV21TFHItemsRubrosNombre", AV21TFHItemsRubrosNombre);
               AV22TFHItemsRubrosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV22TFHItemsRubrosNombre_Sel", AV22TFHItemsRubrosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HItemsMedidasID") == 0 )
            {
               AV23TFHItemsMedidasID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV23TFHItemsMedidasID", StringUtil.LTrimStr( (decimal)(AV23TFHItemsMedidasID), 18, 0));
               AV24TFHItemsMedidasID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV24TFHItemsMedidasID_To", StringUtil.LTrimStr( (decimal)(AV24TFHItemsMedidasID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HItemsInventarioId") == 0 )
            {
               AV25TFHItemsInventarioId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV25TFHItemsInventarioId", StringUtil.LTrimStr( (decimal)(AV25TFHItemsInventarioId), 18, 0));
               AV26TFHItemsInventarioId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV26TFHItemsInventarioId_To", StringUtil.LTrimStr( (decimal)(AV26TFHItemsInventarioId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HItemsInventarioNombre") == 0 )
            {
               AV27TFHItemsInventarioNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV27TFHItemsInventarioNombre", AV27TFHItemsInventarioNombre);
               AV28TFHItemsInventarioNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV28TFHItemsInventarioNombre_Sel", AV28TFHItemsInventarioNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HItemsInventarioPrecioFinal") == 0 )
            {
               AV29TFHItemsInventarioPrecioFinal = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV29TFHItemsInventarioPrecioFinal", StringUtil.LTrimStr( (decimal)(AV29TFHItemsInventarioPrecioFinal), 4, 0));
               AV30TFHItemsInventarioPrecioFinal_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV30TFHItemsInventarioPrecioFinal_To", StringUtil.LTrimStr( (decimal)(AV30TFHItemsInventarioPrecioFinal_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HItemsSolicitudesItemsCantidad") == 0 )
            {
               AV31TFHItemsSolicitudesItemsCantidad = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV31TFHItemsSolicitudesItemsCantidad", StringUtil.LTrimStr( (decimal)(AV31TFHItemsSolicitudesItemsCantidad), 4, 0));
               AV32TFHItemsSolicitudesItemsCantidad_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV32TFHItemsSolicitudesItemsCantidad_To", StringUtil.LTrimStr( (decimal)(AV32TFHItemsSolicitudesItemsCantidad_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HItemsSolicitudesItemsPrecioInstalacion") == 0 )
            {
               AV33TFHItemsSolicitudesItemsPrecioInstalacion = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV33TFHItemsSolicitudesItemsPrecioInstalacion", StringUtil.LTrimStr( AV33TFHItemsSolicitudesItemsPrecioInstalacion, 18, 2));
               AV34TFHItemsSolicitudesItemsPrecioInstalacion_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV34TFHItemsSolicitudesItemsPrecioInstalacion_To", StringUtil.LTrimStr( AV34TFHItemsSolicitudesItemsPrecioInstalacion_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HItemsSolicitudesMonedaId") == 0 )
            {
               AV35TFHItemsSolicitudesMonedaId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV35TFHItemsSolicitudesMonedaId", StringUtil.LTrimStr( (decimal)(AV35TFHItemsSolicitudesMonedaId), 18, 0));
               AV36TFHItemsSolicitudesMonedaId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV36TFHItemsSolicitudesMonedaId_To", StringUtil.LTrimStr( (decimal)(AV36TFHItemsSolicitudesMonedaId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesItemsSR") == 0 )
            {
               AV37TFHistoricoSolicitudesItemsSR = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV37TFHistoricoSolicitudesItemsSR", AV37TFHistoricoSolicitudesItemsSR);
               AV38TFHistoricoSolicitudesItemsSR_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV38TFHistoricoSolicitudesItemsSR_Sel", AV38TFHistoricoSolicitudesItemsSR_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesItemsCT") == 0 )
            {
               AV39TFHistoricoSolicitudesItemsCT = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV39TFHistoricoSolicitudesItemsCT", AV39TFHistoricoSolicitudesItemsCT);
               AV40TFHistoricoSolicitudesItemsCT_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV40TFHistoricoSolicitudesItemsCT_Sel", AV40TFHistoricoSolicitudesItemsCT_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesItemsComision") == 0 )
            {
               AV41TFHistoricoSolicitudesItemsComision = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV41TFHistoricoSolicitudesItemsComision", StringUtil.LTrimStr( AV41TFHistoricoSolicitudesItemsComision, 18, 2));
               AV42TFHistoricoSolicitudesItemsComision_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV42TFHistoricoSolicitudesItemsComision_To", StringUtil.LTrimStr( AV42TFHistoricoSolicitudesItemsComision_To, 18, 2));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E162K2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
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
         if ( StringUtil.StrCmp(AV16Session.Get(AV49Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV49Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV16Session.Get(AV49Pgmname+"GridState"), null, "", "");
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
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESITEMSID") == 0 )
            {
               AV17TFHistoricoSolicitudesItemsID = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV17TFHistoricoSolicitudesItemsID", StringUtil.LTrimStr( (decimal)(AV17TFHistoricoSolicitudesItemsID), 4, 0));
               AV18TFHistoricoSolicitudesItemsID_To = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV18TFHistoricoSolicitudesItemsID_To", StringUtil.LTrimStr( (decimal)(AV18TFHistoricoSolicitudesItemsID_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHITEMSRUBROSID") == 0 )
            {
               AV19TFHItemsRubrosId = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV19TFHItemsRubrosId", StringUtil.LTrimStr( (decimal)(AV19TFHItemsRubrosId), 18, 0));
               AV20TFHItemsRubrosId_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV20TFHItemsRubrosId_To", StringUtil.LTrimStr( (decimal)(AV20TFHItemsRubrosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHITEMSRUBROSNOMBRE") == 0 )
            {
               AV21TFHItemsRubrosNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV21TFHItemsRubrosNombre", AV21TFHItemsRubrosNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHITEMSRUBROSNOMBRE_SEL") == 0 )
            {
               AV22TFHItemsRubrosNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV22TFHItemsRubrosNombre_Sel", AV22TFHItemsRubrosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHITEMSMEDIDASID") == 0 )
            {
               AV23TFHItemsMedidasID = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV23TFHItemsMedidasID", StringUtil.LTrimStr( (decimal)(AV23TFHItemsMedidasID), 18, 0));
               AV24TFHItemsMedidasID_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV24TFHItemsMedidasID_To", StringUtil.LTrimStr( (decimal)(AV24TFHItemsMedidasID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHITEMSINVENTARIOID") == 0 )
            {
               AV25TFHItemsInventarioId = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV25TFHItemsInventarioId", StringUtil.LTrimStr( (decimal)(AV25TFHItemsInventarioId), 18, 0));
               AV26TFHItemsInventarioId_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV26TFHItemsInventarioId_To", StringUtil.LTrimStr( (decimal)(AV26TFHItemsInventarioId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHITEMSINVENTARIONOMBRE") == 0 )
            {
               AV27TFHItemsInventarioNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV27TFHItemsInventarioNombre", AV27TFHItemsInventarioNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHITEMSINVENTARIONOMBRE_SEL") == 0 )
            {
               AV28TFHItemsInventarioNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV28TFHItemsInventarioNombre_Sel", AV28TFHItemsInventarioNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHITEMSINVENTARIOPRECIOFINAL") == 0 )
            {
               AV29TFHItemsInventarioPrecioFinal = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV29TFHItemsInventarioPrecioFinal", StringUtil.LTrimStr( (decimal)(AV29TFHItemsInventarioPrecioFinal), 4, 0));
               AV30TFHItemsInventarioPrecioFinal_To = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV30TFHItemsInventarioPrecioFinal_To", StringUtil.LTrimStr( (decimal)(AV30TFHItemsInventarioPrecioFinal_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHITEMSSOLICITUDESITEMSCANTIDAD") == 0 )
            {
               AV31TFHItemsSolicitudesItemsCantidad = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV31TFHItemsSolicitudesItemsCantidad", StringUtil.LTrimStr( (decimal)(AV31TFHItemsSolicitudesItemsCantidad), 4, 0));
               AV32TFHItemsSolicitudesItemsCantidad_To = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV32TFHItemsSolicitudesItemsCantidad_To", StringUtil.LTrimStr( (decimal)(AV32TFHItemsSolicitudesItemsCantidad_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHITEMSSOLICITUDESITEMSPRECIOINSTALACION") == 0 )
            {
               AV33TFHItemsSolicitudesItemsPrecioInstalacion = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV33TFHItemsSolicitudesItemsPrecioInstalacion", StringUtil.LTrimStr( AV33TFHItemsSolicitudesItemsPrecioInstalacion, 18, 2));
               AV34TFHItemsSolicitudesItemsPrecioInstalacion_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV34TFHItemsSolicitudesItemsPrecioInstalacion_To", StringUtil.LTrimStr( AV34TFHItemsSolicitudesItemsPrecioInstalacion_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHITEMSSOLICITUDESMONEDAID") == 0 )
            {
               AV35TFHItemsSolicitudesMonedaId = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV35TFHItemsSolicitudesMonedaId", StringUtil.LTrimStr( (decimal)(AV35TFHItemsSolicitudesMonedaId), 18, 0));
               AV36TFHItemsSolicitudesMonedaId_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV36TFHItemsSolicitudesMonedaId_To", StringUtil.LTrimStr( (decimal)(AV36TFHItemsSolicitudesMonedaId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESITEMSSR") == 0 )
            {
               AV37TFHistoricoSolicitudesItemsSR = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV37TFHistoricoSolicitudesItemsSR", AV37TFHistoricoSolicitudesItemsSR);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESITEMSSR_SEL") == 0 )
            {
               AV38TFHistoricoSolicitudesItemsSR_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV38TFHistoricoSolicitudesItemsSR_Sel", AV38TFHistoricoSolicitudesItemsSR_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESITEMSCT") == 0 )
            {
               AV39TFHistoricoSolicitudesItemsCT = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV39TFHistoricoSolicitudesItemsCT", AV39TFHistoricoSolicitudesItemsCT);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESITEMSCT_SEL") == 0 )
            {
               AV40TFHistoricoSolicitudesItemsCT_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV40TFHistoricoSolicitudesItemsCT_Sel", AV40TFHistoricoSolicitudesItemsCT_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESITEMSCOMISION") == 0 )
            {
               AV41TFHistoricoSolicitudesItemsComision = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV41TFHistoricoSolicitudesItemsComision", StringUtil.LTrimStr( AV41TFHistoricoSolicitudesItemsComision, 18, 2));
               AV42TFHistoricoSolicitudesItemsComision_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV42TFHistoricoSolicitudesItemsComision_To", StringUtil.LTrimStr( AV42TFHistoricoSolicitudesItemsComision_To, 18, 2));
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHItemsRubrosNombre_Sel)),  AV22TFHItemsRubrosNombre_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFHItemsInventarioNombre_Sel)),  AV28TFHItemsInventarioNombre_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFHistoricoSolicitudesItemsSR_Sel)),  AV38TFHistoricoSolicitudesItemsSR_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFHistoricoSolicitudesItemsCT_Sel)),  AV40TFHistoricoSolicitudesItemsCT_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = "||"+GXt_char2+"|||"+GXt_char3+"|||||"+GXt_char4+"|"+GXt_char5+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHItemsRubrosNombre)),  AV21TFHItemsRubrosNombre, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFHItemsInventarioNombre)),  AV27TFHItemsInventarioNombre, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFHistoricoSolicitudesItemsSR)),  AV37TFHistoricoSolicitudesItemsSR, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFHistoricoSolicitudesItemsCT)),  AV39TFHistoricoSolicitudesItemsCT, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((0==AV17TFHistoricoSolicitudesItemsID) ? "" : StringUtil.Str( (decimal)(AV17TFHistoricoSolicitudesItemsID), 4, 0))+"|"+((0==AV19TFHItemsRubrosId) ? "" : StringUtil.Str( (decimal)(AV19TFHItemsRubrosId), 18, 0))+"|"+GXt_char5+"|"+((0==AV23TFHItemsMedidasID) ? "" : StringUtil.Str( (decimal)(AV23TFHItemsMedidasID), 18, 0))+"|"+((0==AV25TFHItemsInventarioId) ? "" : StringUtil.Str( (decimal)(AV25TFHItemsInventarioId), 18, 0))+"|"+GXt_char4+"|"+((0==AV29TFHItemsInventarioPrecioFinal) ? "" : StringUtil.Str( (decimal)(AV29TFHItemsInventarioPrecioFinal), 4, 0))+"|"+((0==AV31TFHItemsSolicitudesItemsCantidad) ? "" : StringUtil.Str( (decimal)(AV31TFHItemsSolicitudesItemsCantidad), 4, 0))+"|"+((Convert.ToDecimal(0)==AV33TFHItemsSolicitudesItemsPrecioInstalacion) ? "" : StringUtil.Str( AV33TFHItemsSolicitudesItemsPrecioInstalacion, 18, 2))+"|"+((0==AV35TFHItemsSolicitudesMonedaId) ? "" : StringUtil.Str( (decimal)(AV35TFHItemsSolicitudesMonedaId), 18, 0))+"|"+GXt_char3+"|"+GXt_char2+"|"+((Convert.ToDecimal(0)==AV41TFHistoricoSolicitudesItemsComision) ? "" : StringUtil.Str( AV41TFHistoricoSolicitudesItemsComision, 18, 2));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV18TFHistoricoSolicitudesItemsID_To) ? "" : StringUtil.Str( (decimal)(AV18TFHistoricoSolicitudesItemsID_To), 4, 0))+"|"+((0==AV20TFHItemsRubrosId_To) ? "" : StringUtil.Str( (decimal)(AV20TFHItemsRubrosId_To), 18, 0))+"||"+((0==AV24TFHItemsMedidasID_To) ? "" : StringUtil.Str( (decimal)(AV24TFHItemsMedidasID_To), 18, 0))+"|"+((0==AV26TFHItemsInventarioId_To) ? "" : StringUtil.Str( (decimal)(AV26TFHItemsInventarioId_To), 18, 0))+"||"+((0==AV30TFHItemsInventarioPrecioFinal_To) ? "" : StringUtil.Str( (decimal)(AV30TFHItemsInventarioPrecioFinal_To), 4, 0))+"|"+((0==AV32TFHItemsSolicitudesItemsCantidad_To) ? "" : StringUtil.Str( (decimal)(AV32TFHItemsSolicitudesItemsCantidad_To), 4, 0))+"|"+((Convert.ToDecimal(0)==AV34TFHItemsSolicitudesItemsPrecioInstalacion_To) ? "" : StringUtil.Str( AV34TFHItemsSolicitudesItemsPrecioInstalacion_To, 18, 2))+"|"+((0==AV36TFHItemsSolicitudesMonedaId_To) ? "" : StringUtil.Str( (decimal)(AV36TFHItemsSolicitudesMonedaId_To), 18, 0))+"|||"+((Convert.ToDecimal(0)==AV42TFHistoricoSolicitudesItemsComision_To) ? "" : StringUtil.Str( AV42TFHistoricoSolicitudesItemsComision_To, 18, 2));
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
         AV12GridState.FromXml(AV16Session.Get(AV49Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESITEMSID",  context.GetMessage( "Items ID", ""),  !((0==AV17TFHistoricoSolicitudesItemsID)&&(0==AV18TFHistoricoSolicitudesItemsID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV17TFHistoricoSolicitudesItemsID), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV18TFHistoricoSolicitudesItemsID_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHITEMSRUBROSID",  context.GetMessage( "Rubros Id", ""),  !((0==AV19TFHItemsRubrosId)&&(0==AV20TFHItemsRubrosId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV19TFHItemsRubrosId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV20TFHItemsRubrosId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHITEMSRUBROSNOMBRE",  context.GetMessage( "Rubros Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHItemsRubrosNombre)),  0,  AV21TFHItemsRubrosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHItemsRubrosNombre_Sel)),  AV22TFHItemsRubrosNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHITEMSMEDIDASID",  context.GetMessage( "Medidas ID", ""),  !((0==AV23TFHItemsMedidasID)&&(0==AV24TFHItemsMedidasID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV23TFHItemsMedidasID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV24TFHItemsMedidasID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHITEMSINVENTARIOID",  context.GetMessage( "Inventario Id", ""),  !((0==AV25TFHItemsInventarioId)&&(0==AV26TFHItemsInventarioId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV25TFHItemsInventarioId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV26TFHItemsInventarioId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHITEMSINVENTARIONOMBRE",  context.GetMessage( "Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFHItemsInventarioNombre)),  0,  AV27TFHItemsInventarioNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFHItemsInventarioNombre_Sel)),  AV28TFHItemsInventarioNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHITEMSINVENTARIOPRECIOFINAL",  context.GetMessage( "Precio Final", ""),  !((0==AV29TFHItemsInventarioPrecioFinal)&&(0==AV30TFHItemsInventarioPrecioFinal_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV29TFHItemsInventarioPrecioFinal), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV30TFHItemsInventarioPrecioFinal_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHITEMSSOLICITUDESITEMSCANTIDAD",  context.GetMessage( "Items Cantidad", ""),  !((0==AV31TFHItemsSolicitudesItemsCantidad)&&(0==AV32TFHItemsSolicitudesItemsCantidad_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31TFHItemsSolicitudesItemsCantidad), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV32TFHItemsSolicitudesItemsCantidad_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHITEMSSOLICITUDESITEMSPRECIOINSTALACION",  context.GetMessage( "Precio Instalacion", ""),  !((Convert.ToDecimal(0)==AV33TFHItemsSolicitudesItemsPrecioInstalacion)&&(Convert.ToDecimal(0)==AV34TFHItemsSolicitudesItemsPrecioInstalacion_To)),  0,  StringUtil.Trim( StringUtil.Str( AV33TFHItemsSolicitudesItemsPrecioInstalacion, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV34TFHItemsSolicitudesItemsPrecioInstalacion_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHITEMSSOLICITUDESMONEDAID",  context.GetMessage( "Moneda Id", ""),  !((0==AV35TFHItemsSolicitudesMonedaId)&&(0==AV36TFHItemsSolicitudesMonedaId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV35TFHItemsSolicitudesMonedaId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV36TFHItemsSolicitudesMonedaId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESITEMSSR",  context.GetMessage( "Resta", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFHistoricoSolicitudesItemsSR)),  0,  AV37TFHistoricoSolicitudesItemsSR,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFHistoricoSolicitudesItemsSR_Sel)),  AV38TFHistoricoSolicitudesItemsSR_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESITEMSCT",  context.GetMessage( "Comisión", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFHistoricoSolicitudesItemsCT)),  0,  AV39TFHistoricoSolicitudesItemsCT,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFHistoricoSolicitudesItemsCT_Sel)),  AV40TFHistoricoSolicitudesItemsCT_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESITEMSCOMISION",  context.GetMessage( "Comisión", ""),  !((Convert.ToDecimal(0)==AV41TFHistoricoSolicitudesItemsComision)&&(Convert.ToDecimal(0)==AV42TFHistoricoSolicitudesItemsComision_To)),  0,  StringUtil.Trim( StringUtil.Str( AV41TFHistoricoSolicitudesItemsComision, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV42TFHistoricoSolicitudesItemsComision_To, 18, 2))) ;
         if ( ! (0==AV8HistoricoSolicitudesID) )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = "PARM_&HISTORICOSOLICITUDESID";
            AV13GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV8HistoricoSolicitudesID), 18, 0);
            AV12GridState.gxTpr_Filtervalues.Add(AV13GridStateFilterValue, 0);
         }
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV49Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV49Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "HistoricoSolicitudes";
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "HistoricoSolicitudesID";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8HistoricoSolicitudesID), 18, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV16Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8HistoricoSolicitudesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV8HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(AV8HistoricoSolicitudesID), 18, 0));
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
         PA2K2( ) ;
         WS2K2( ) ;
         WE2K2( ) ;
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
         sCtrlAV8HistoricoSolicitudesID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2K2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "historicosolicitudesitemswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2K2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8HistoricoSolicitudesID = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV8HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(AV8HistoricoSolicitudesID), 18, 0));
         }
         wcpOAV8HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8HistoricoSolicitudesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV8HistoricoSolicitudesID != wcpOAV8HistoricoSolicitudesID ) ) )
         {
            setjustcreated();
         }
         wcpOAV8HistoricoSolicitudesID = AV8HistoricoSolicitudesID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8HistoricoSolicitudesID = cgiGet( sPrefix+"AV8HistoricoSolicitudesID_CTRL");
         if ( StringUtil.Len( sCtrlAV8HistoricoSolicitudesID) > 0 )
         {
            AV8HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8HistoricoSolicitudesID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(AV8HistoricoSolicitudesID), 18, 0));
         }
         else
         {
            AV8HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8HistoricoSolicitudesID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA2K2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2K2( ) ;
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
         WS2K2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8HistoricoSolicitudesID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8HistoricoSolicitudesID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8HistoricoSolicitudesID_CTRL", StringUtil.RTrim( sCtrlAV8HistoricoSolicitudesID));
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
         WE2K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302122150", true, true, false);
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
         context.AddJavascriptSource("historicosolicitudesitemswc.js", "?20267302122150", false, true, false);
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
         edtHistoricoSolicitudesItemsID_Internalname = sPrefix+"HISTORICOSOLICITUDESITEMSID_"+sGXsfl_15_idx;
         edtHItemsRubrosId_Internalname = sPrefix+"HITEMSRUBROSID_"+sGXsfl_15_idx;
         edtHItemsRubrosNombre_Internalname = sPrefix+"HITEMSRUBROSNOMBRE_"+sGXsfl_15_idx;
         edtHItemsMedidasID_Internalname = sPrefix+"HITEMSMEDIDASID_"+sGXsfl_15_idx;
         edtHItemsInventarioId_Internalname = sPrefix+"HITEMSINVENTARIOID_"+sGXsfl_15_idx;
         edtHItemsInventarioNombre_Internalname = sPrefix+"HITEMSINVENTARIONOMBRE_"+sGXsfl_15_idx;
         edtHItemsInventarioPrecioFinal_Internalname = sPrefix+"HITEMSINVENTARIOPRECIOFINAL_"+sGXsfl_15_idx;
         edtHItemsSolicitudesItemsCantidad_Internalname = sPrefix+"HITEMSSOLICITUDESITEMSCANTIDAD_"+sGXsfl_15_idx;
         edtHItemsSolicitudesItemsPrecioIn_Internalname = sPrefix+"HITEMSSOLICITUDESITEMSPRECIOIN_"+sGXsfl_15_idx;
         edtHItemsSolicitudesMonedaId_Internalname = sPrefix+"HITEMSSOLICITUDESMONEDAID_"+sGXsfl_15_idx;
         edtHistoricoSolicitudesItemsSR_Internalname = sPrefix+"HISTORICOSOLICITUDESITEMSSR_"+sGXsfl_15_idx;
         edtHistoricoSolicitudesItemsCT_Internalname = sPrefix+"HISTORICOSOLICITUDESITEMSCT_"+sGXsfl_15_idx;
         edtHistoricoSolicitudesItemsComis_Internalname = sPrefix+"HISTORICOSOLICITUDESITEMSCOMIS_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         edtHistoricoSolicitudesItemsID_Internalname = sPrefix+"HISTORICOSOLICITUDESITEMSID_"+sGXsfl_15_fel_idx;
         edtHItemsRubrosId_Internalname = sPrefix+"HITEMSRUBROSID_"+sGXsfl_15_fel_idx;
         edtHItemsRubrosNombre_Internalname = sPrefix+"HITEMSRUBROSNOMBRE_"+sGXsfl_15_fel_idx;
         edtHItemsMedidasID_Internalname = sPrefix+"HITEMSMEDIDASID_"+sGXsfl_15_fel_idx;
         edtHItemsInventarioId_Internalname = sPrefix+"HITEMSINVENTARIOID_"+sGXsfl_15_fel_idx;
         edtHItemsInventarioNombre_Internalname = sPrefix+"HITEMSINVENTARIONOMBRE_"+sGXsfl_15_fel_idx;
         edtHItemsInventarioPrecioFinal_Internalname = sPrefix+"HITEMSINVENTARIOPRECIOFINAL_"+sGXsfl_15_fel_idx;
         edtHItemsSolicitudesItemsCantidad_Internalname = sPrefix+"HITEMSSOLICITUDESITEMSCANTIDAD_"+sGXsfl_15_fel_idx;
         edtHItemsSolicitudesItemsPrecioIn_Internalname = sPrefix+"HITEMSSOLICITUDESITEMSPRECIOIN_"+sGXsfl_15_fel_idx;
         edtHItemsSolicitudesMonedaId_Internalname = sPrefix+"HITEMSSOLICITUDESMONEDAID_"+sGXsfl_15_fel_idx;
         edtHistoricoSolicitudesItemsSR_Internalname = sPrefix+"HISTORICOSOLICITUDESITEMSSR_"+sGXsfl_15_fel_idx;
         edtHistoricoSolicitudesItemsCT_Internalname = sPrefix+"HISTORICOSOLICITUDESITEMSCT_"+sGXsfl_15_fel_idx;
         edtHistoricoSolicitudesItemsComis_Internalname = sPrefix+"HISTORICOSOLICITUDESITEMSCOMIS_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         WB2K0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesItemsID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A154HistoricoSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A154HistoricoSolicitudesItemsID), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesItemsID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A330HItemsRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A330HItemsRubrosId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsRubrosNombre_Internalname,StringUtil.RTrim( A331HItemsRubrosNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsRubrosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsMedidasID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A327HItemsMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A327HItemsMedidasID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsMedidasID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsInventarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A328HItemsInventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A328HItemsInventarioId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsInventarioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsInventarioNombre_Internalname,StringUtil.RTrim( A329HItemsInventarioNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsInventarioNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsInventarioPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A295HItemsInventarioPrecioFinal), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A295HItemsInventarioPrecioFinal), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsInventarioPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsSolicitudesItemsCantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A293HItemsSolicitudesItemsCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A293HItemsSolicitudesItemsCantidad), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsSolicitudesItemsCantidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsSolicitudesItemsPrecioIn_Internalname,StringUtil.LTrim( StringUtil.NToC( A294HItemsSolicitudesItemsPrecioIn, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A294HItemsSolicitudesItemsPrecioIn, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsSolicitudesItemsPrecioIn_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsSolicitudesMonedaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A319HItemsSolicitudesMonedaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A319HItemsSolicitudesMonedaId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsSolicitudesMonedaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesItemsSR_Internalname,StringUtil.RTrim( A296HistoricoSolicitudesItemsSR),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesItemsSR_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesItemsCT_Internalname,StringUtil.RTrim( A297HistoricoSolicitudesItemsCT),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesItemsCT_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesItemsComis_Internalname,StringUtil.LTrim( StringUtil.NToC( A298HistoricoSolicitudesItemsComis, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A298HistoricoSolicitudesItemsComis, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesItemsComis_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes2K2( ) ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Items ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rubros Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rubros Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Medidas ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Inventario Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio Final", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Items Cantidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio Instalacion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Moneda Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comisión", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comisión", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A154HistoricoSolicitudesItemsID), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A330HItemsRubrosId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A331HItemsRubrosNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A327HItemsMedidasID), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A328HItemsInventarioId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A329HItemsInventarioNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A295HItemsInventarioPrecioFinal), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A293HItemsSolicitudesItemsCantidad), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A294HItemsSolicitudesItemsPrecioIn, 21, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A319HItemsSolicitudesMonedaId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A296HistoricoSolicitudesItemsSR)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A297HistoricoSolicitudesItemsCT)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A298HistoricoSolicitudesItemsComis, 18, 2, ".", ""))));
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
         edtHistoricoSolicitudesItemsID_Internalname = sPrefix+"HISTORICOSOLICITUDESITEMSID";
         edtHItemsRubrosId_Internalname = sPrefix+"HITEMSRUBROSID";
         edtHItemsRubrosNombre_Internalname = sPrefix+"HITEMSRUBROSNOMBRE";
         edtHItemsMedidasID_Internalname = sPrefix+"HITEMSMEDIDASID";
         edtHItemsInventarioId_Internalname = sPrefix+"HITEMSINVENTARIOID";
         edtHItemsInventarioNombre_Internalname = sPrefix+"HITEMSINVENTARIONOMBRE";
         edtHItemsInventarioPrecioFinal_Internalname = sPrefix+"HITEMSINVENTARIOPRECIOFINAL";
         edtHItemsSolicitudesItemsCantidad_Internalname = sPrefix+"HITEMSSOLICITUDESITEMSCANTIDAD";
         edtHItemsSolicitudesItemsPrecioIn_Internalname = sPrefix+"HITEMSSOLICITUDESITEMSPRECIOIN";
         edtHItemsSolicitudesMonedaId_Internalname = sPrefix+"HITEMSSOLICITUDESMONEDAID";
         edtHistoricoSolicitudesItemsSR_Internalname = sPrefix+"HISTORICOSOLICITUDESITEMSSR";
         edtHistoricoSolicitudesItemsCT_Internalname = sPrefix+"HISTORICOSOLICITUDESITEMSCT";
         edtHistoricoSolicitudesItemsComis_Internalname = sPrefix+"HISTORICOSOLICITUDESITEMSCOMIS";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtHistoricoSolicitudesID_Internalname = sPrefix+"HISTORICOSOLICITUDESID";
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
         edtHistoricoSolicitudesItemsComis_Jsonclick = "";
         edtHistoricoSolicitudesItemsCT_Jsonclick = "";
         edtHistoricoSolicitudesItemsSR_Jsonclick = "";
         edtHItemsSolicitudesMonedaId_Jsonclick = "";
         edtHItemsSolicitudesItemsPrecioIn_Jsonclick = "";
         edtHItemsSolicitudesItemsCantidad_Jsonclick = "";
         edtHItemsInventarioPrecioFinal_Jsonclick = "";
         edtHItemsInventarioNombre_Jsonclick = "";
         edtHItemsInventarioId_Jsonclick = "";
         edtHItemsMedidasID_Jsonclick = "";
         edtHItemsRubrosNombre_Jsonclick = "";
         edtHItemsRubrosId_Jsonclick = "";
         edtHistoricoSolicitudesItemsID_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtHistoricoSolicitudesID_Enabled = 0;
         edtHistoricoSolicitudesItemsComis_Enabled = 0;
         edtHistoricoSolicitudesItemsCT_Enabled = 0;
         edtHistoricoSolicitudesItemsSR_Enabled = 0;
         edtHItemsSolicitudesMonedaId_Enabled = 0;
         edtHItemsSolicitudesItemsPrecioIn_Enabled = 0;
         edtHItemsSolicitudesItemsCantidad_Enabled = 0;
         edtHItemsInventarioPrecioFinal_Enabled = 0;
         edtHItemsInventarioNombre_Enabled = 0;
         edtHItemsInventarioId_Enabled = 0;
         edtHItemsMedidasID_Enabled = 0;
         edtHItemsRubrosNombre_Enabled = 0;
         edtHItemsRubrosId_Enabled = 0;
         edtHistoricoSolicitudesItemsID_Enabled = 0;
         subGrid_Sortable = 0;
         edtHistoricoSolicitudesID_Jsonclick = "";
         edtHistoricoSolicitudesID_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "4.0|18.0||18.0|18.0||4.0|4.0|18.2|18.0|||18.2";
         Ddo_grid_Datalistproc = "HistoricoSolicitudesItemsWCGetFilterData";
         Ddo_grid_Datalisttype = "||Dynamic|||Dynamic|||||Dynamic|Dynamic|";
         Ddo_grid_Includedatalist = "||T|||T|||||T|T|";
         Ddo_grid_Filterisrange = "T|T||T|T||T|T|T|T|||T";
         Ddo_grid_Filtertype = "Numeric|Numeric|Character|Numeric|Numeric|Character|Numeric|Numeric|Numeric|Numeric|Character|Character|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|T|T|T|T||T|T|T|T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8||9|10|11|12";
         Ddo_grid_Columnids = "0:HistoricoSolicitudesItemsID|1:HItemsRubrosId|2:HItemsRubrosNombre|3:HItemsMedidasID|4:HItemsInventarioId|5:HItemsInventarioNombre|6:HItemsInventarioPrecioFinal|7:HItemsSolicitudesItemsCantidad|8:HItemsSolicitudesItemsPrecioInstalacion|9:HItemsSolicitudesMonedaId|10:HistoricoSolicitudesItemsSR|11:HistoricoSolicitudesItemsCT|12:HistoricoSolicitudesItemsComision";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'sPrefix',type:'char'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFHistoricoSolicitudesItemsID',fld:'vTFHISTORICOSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'},{av:'AV18TFHistoricoSolicitudesItemsID_To',fld:'vTFHISTORICOSOLICITUDESITEMSID_TO',pic:'ZZZ9',type:'int'},{av:'AV19TFHItemsRubrosId',fld:'vTFHITEMSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20TFHItemsRubrosId_To',fld:'vTFHITEMSRUBROSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21TFHItemsRubrosNombre',fld:'vTFHITEMSRUBROSNOMBRE',pic:'',type:'char'},{av:'AV22TFHItemsRubrosNombre_Sel',fld:'vTFHITEMSRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFHItemsMedidasID',fld:'vTFHITEMSMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFHItemsMedidasID_To',fld:'vTFHITEMSMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV25TFHItemsInventarioId',fld:'vTFHITEMSINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFHItemsInventarioId_To',fld:'vTFHITEMSINVENTARIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFHItemsInventarioNombre',fld:'vTFHITEMSINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV28TFHItemsInventarioNombre_Sel',fld:'vTFHITEMSINVENTARIONOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFHItemsInventarioPrecioFinal',fld:'vTFHITEMSINVENTARIOPRECIOFINAL',pic:'ZZZ9',type:'int'},{av:'AV30TFHItemsInventarioPrecioFinal_To',fld:'vTFHITEMSINVENTARIOPRECIOFINAL_TO',pic:'ZZZ9',type:'int'},{av:'AV31TFHItemsSolicitudesItemsCantidad',fld:'vTFHITEMSSOLICITUDESITEMSCANTIDAD',pic:'ZZZ9',type:'int'},{av:'AV32TFHItemsSolicitudesItemsCantidad_To',fld:'vTFHITEMSSOLICITUDESITEMSCANTIDAD_TO',pic:'ZZZ9',type:'int'},{av:'AV33TFHItemsSolicitudesItemsPrecioInstalacion',fld:'vTFHITEMSSOLICITUDESITEMSPRECIOINSTALACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV34TFHItemsSolicitudesItemsPrecioInstalacion_To',fld:'vTFHITEMSSOLICITUDESITEMSPRECIOINSTALACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35TFHItemsSolicitudesMonedaId',fld:'vTFHITEMSSOLICITUDESMONEDAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFHItemsSolicitudesMonedaId_To',fld:'vTFHITEMSSOLICITUDESMONEDAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFHistoricoSolicitudesItemsSR',fld:'vTFHISTORICOSOLICITUDESITEMSSR',pic:'',type:'char'},{av:'AV38TFHistoricoSolicitudesItemsSR_Sel',fld:'vTFHISTORICOSOLICITUDESITEMSSR_SEL',pic:'',type:'char'},{av:'AV39TFHistoricoSolicitudesItemsCT',fld:'vTFHISTORICOSOLICITUDESITEMSCT',pic:'',type:'char'},{av:'AV40TFHistoricoSolicitudesItemsCT_Sel',fld:'vTFHISTORICOSOLICITUDESITEMSCT_SEL',pic:'',type:'char'},{av:'AV41TFHistoricoSolicitudesItemsComision',fld:'vTFHISTORICOSOLICITUDESITEMSCOMISION',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV42TFHistoricoSolicitudesItemsComision_To',fld:'vTFHISTORICOSOLICITUDESITEMSCOMISION_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV46GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV47GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E112K2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFHistoricoSolicitudesItemsID',fld:'vTFHISTORICOSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'},{av:'AV18TFHistoricoSolicitudesItemsID_To',fld:'vTFHISTORICOSOLICITUDESITEMSID_TO',pic:'ZZZ9',type:'int'},{av:'AV19TFHItemsRubrosId',fld:'vTFHITEMSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20TFHItemsRubrosId_To',fld:'vTFHITEMSRUBROSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21TFHItemsRubrosNombre',fld:'vTFHITEMSRUBROSNOMBRE',pic:'',type:'char'},{av:'AV22TFHItemsRubrosNombre_Sel',fld:'vTFHITEMSRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFHItemsMedidasID',fld:'vTFHITEMSMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFHItemsMedidasID_To',fld:'vTFHITEMSMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV25TFHItemsInventarioId',fld:'vTFHITEMSINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFHItemsInventarioId_To',fld:'vTFHITEMSINVENTARIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFHItemsInventarioNombre',fld:'vTFHITEMSINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV28TFHItemsInventarioNombre_Sel',fld:'vTFHITEMSINVENTARIONOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFHItemsInventarioPrecioFinal',fld:'vTFHITEMSINVENTARIOPRECIOFINAL',pic:'ZZZ9',type:'int'},{av:'AV30TFHItemsInventarioPrecioFinal_To',fld:'vTFHITEMSINVENTARIOPRECIOFINAL_TO',pic:'ZZZ9',type:'int'},{av:'AV31TFHItemsSolicitudesItemsCantidad',fld:'vTFHITEMSSOLICITUDESITEMSCANTIDAD',pic:'ZZZ9',type:'int'},{av:'AV32TFHItemsSolicitudesItemsCantidad_To',fld:'vTFHITEMSSOLICITUDESITEMSCANTIDAD_TO',pic:'ZZZ9',type:'int'},{av:'AV33TFHItemsSolicitudesItemsPrecioInstalacion',fld:'vTFHITEMSSOLICITUDESITEMSPRECIOINSTALACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV34TFHItemsSolicitudesItemsPrecioInstalacion_To',fld:'vTFHITEMSSOLICITUDESITEMSPRECIOINSTALACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35TFHItemsSolicitudesMonedaId',fld:'vTFHITEMSSOLICITUDESMONEDAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFHItemsSolicitudesMonedaId_To',fld:'vTFHITEMSSOLICITUDESMONEDAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFHistoricoSolicitudesItemsSR',fld:'vTFHISTORICOSOLICITUDESITEMSSR',pic:'',type:'char'},{av:'AV38TFHistoricoSolicitudesItemsSR_Sel',fld:'vTFHISTORICOSOLICITUDESITEMSSR_SEL',pic:'',type:'char'},{av:'AV39TFHistoricoSolicitudesItemsCT',fld:'vTFHISTORICOSOLICITUDESITEMSCT',pic:'',type:'char'},{av:'AV40TFHistoricoSolicitudesItemsCT_Sel',fld:'vTFHISTORICOSOLICITUDESITEMSCT_SEL',pic:'',type:'char'},{av:'AV41TFHistoricoSolicitudesItemsComision',fld:'vTFHISTORICOSOLICITUDESITEMSCOMISION',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV42TFHistoricoSolicitudesItemsComision_To',fld:'vTFHISTORICOSOLICITUDESITEMSCOMISION_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV46GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV47GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E122K2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFHistoricoSolicitudesItemsID',fld:'vTFHISTORICOSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'},{av:'AV18TFHistoricoSolicitudesItemsID_To',fld:'vTFHISTORICOSOLICITUDESITEMSID_TO',pic:'ZZZ9',type:'int'},{av:'AV19TFHItemsRubrosId',fld:'vTFHITEMSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20TFHItemsRubrosId_To',fld:'vTFHITEMSRUBROSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21TFHItemsRubrosNombre',fld:'vTFHITEMSRUBROSNOMBRE',pic:'',type:'char'},{av:'AV22TFHItemsRubrosNombre_Sel',fld:'vTFHITEMSRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFHItemsMedidasID',fld:'vTFHITEMSMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFHItemsMedidasID_To',fld:'vTFHITEMSMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV25TFHItemsInventarioId',fld:'vTFHITEMSINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFHItemsInventarioId_To',fld:'vTFHITEMSINVENTARIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFHItemsInventarioNombre',fld:'vTFHITEMSINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV28TFHItemsInventarioNombre_Sel',fld:'vTFHITEMSINVENTARIONOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFHItemsInventarioPrecioFinal',fld:'vTFHITEMSINVENTARIOPRECIOFINAL',pic:'ZZZ9',type:'int'},{av:'AV30TFHItemsInventarioPrecioFinal_To',fld:'vTFHITEMSINVENTARIOPRECIOFINAL_TO',pic:'ZZZ9',type:'int'},{av:'AV31TFHItemsSolicitudesItemsCantidad',fld:'vTFHITEMSSOLICITUDESITEMSCANTIDAD',pic:'ZZZ9',type:'int'},{av:'AV32TFHItemsSolicitudesItemsCantidad_To',fld:'vTFHITEMSSOLICITUDESITEMSCANTIDAD_TO',pic:'ZZZ9',type:'int'},{av:'AV33TFHItemsSolicitudesItemsPrecioInstalacion',fld:'vTFHITEMSSOLICITUDESITEMSPRECIOINSTALACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV34TFHItemsSolicitudesItemsPrecioInstalacion_To',fld:'vTFHITEMSSOLICITUDESITEMSPRECIOINSTALACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35TFHItemsSolicitudesMonedaId',fld:'vTFHITEMSSOLICITUDESMONEDAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFHItemsSolicitudesMonedaId_To',fld:'vTFHITEMSSOLICITUDESMONEDAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFHistoricoSolicitudesItemsSR',fld:'vTFHISTORICOSOLICITUDESITEMSSR',pic:'',type:'char'},{av:'AV38TFHistoricoSolicitudesItemsSR_Sel',fld:'vTFHISTORICOSOLICITUDESITEMSSR_SEL',pic:'',type:'char'},{av:'AV39TFHistoricoSolicitudesItemsCT',fld:'vTFHISTORICOSOLICITUDESITEMSCT',pic:'',type:'char'},{av:'AV40TFHistoricoSolicitudesItemsCT_Sel',fld:'vTFHISTORICOSOLICITUDESITEMSCT_SEL',pic:'',type:'char'},{av:'AV41TFHistoricoSolicitudesItemsComision',fld:'vTFHISTORICOSOLICITUDESITEMSCOMISION',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV42TFHistoricoSolicitudesItemsComision_To',fld:'vTFHISTORICOSOLICITUDESITEMSCOMISION_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E132K2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFHistoricoSolicitudesItemsID',fld:'vTFHISTORICOSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'},{av:'AV18TFHistoricoSolicitudesItemsID_To',fld:'vTFHISTORICOSOLICITUDESITEMSID_TO',pic:'ZZZ9',type:'int'},{av:'AV19TFHItemsRubrosId',fld:'vTFHITEMSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20TFHItemsRubrosId_To',fld:'vTFHITEMSRUBROSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21TFHItemsRubrosNombre',fld:'vTFHITEMSRUBROSNOMBRE',pic:'',type:'char'},{av:'AV22TFHItemsRubrosNombre_Sel',fld:'vTFHITEMSRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFHItemsMedidasID',fld:'vTFHITEMSMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFHItemsMedidasID_To',fld:'vTFHITEMSMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV25TFHItemsInventarioId',fld:'vTFHITEMSINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFHItemsInventarioId_To',fld:'vTFHITEMSINVENTARIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFHItemsInventarioNombre',fld:'vTFHITEMSINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV28TFHItemsInventarioNombre_Sel',fld:'vTFHITEMSINVENTARIONOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFHItemsInventarioPrecioFinal',fld:'vTFHITEMSINVENTARIOPRECIOFINAL',pic:'ZZZ9',type:'int'},{av:'AV30TFHItemsInventarioPrecioFinal_To',fld:'vTFHITEMSINVENTARIOPRECIOFINAL_TO',pic:'ZZZ9',type:'int'},{av:'AV31TFHItemsSolicitudesItemsCantidad',fld:'vTFHITEMSSOLICITUDESITEMSCANTIDAD',pic:'ZZZ9',type:'int'},{av:'AV32TFHItemsSolicitudesItemsCantidad_To',fld:'vTFHITEMSSOLICITUDESITEMSCANTIDAD_TO',pic:'ZZZ9',type:'int'},{av:'AV33TFHItemsSolicitudesItemsPrecioInstalacion',fld:'vTFHITEMSSOLICITUDESITEMSPRECIOINSTALACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV34TFHItemsSolicitudesItemsPrecioInstalacion_To',fld:'vTFHITEMSSOLICITUDESITEMSPRECIOINSTALACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35TFHItemsSolicitudesMonedaId',fld:'vTFHITEMSSOLICITUDESMONEDAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFHItemsSolicitudesMonedaId_To',fld:'vTFHITEMSSOLICITUDESMONEDAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFHistoricoSolicitudesItemsSR',fld:'vTFHISTORICOSOLICITUDESITEMSSR',pic:'',type:'char'},{av:'AV38TFHistoricoSolicitudesItemsSR_Sel',fld:'vTFHISTORICOSOLICITUDESITEMSSR_SEL',pic:'',type:'char'},{av:'AV39TFHistoricoSolicitudesItemsCT',fld:'vTFHISTORICOSOLICITUDESITEMSCT',pic:'',type:'char'},{av:'AV40TFHistoricoSolicitudesItemsCT_Sel',fld:'vTFHISTORICOSOLICITUDESITEMSCT_SEL',pic:'',type:'char'},{av:'AV41TFHistoricoSolicitudesItemsComision',fld:'vTFHISTORICOSOLICITUDESITEMSCOMISION',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV42TFHistoricoSolicitudesItemsComision_To',fld:'vTFHISTORICOSOLICITUDESITEMSCOMISION_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'sPrefix',type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV41TFHistoricoSolicitudesItemsComision',fld:'vTFHISTORICOSOLICITUDESITEMSCOMISION',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV42TFHistoricoSolicitudesItemsComision_To',fld:'vTFHISTORICOSOLICITUDESITEMSCOMISION_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV39TFHistoricoSolicitudesItemsCT',fld:'vTFHISTORICOSOLICITUDESITEMSCT',pic:'',type:'char'},{av:'AV40TFHistoricoSolicitudesItemsCT_Sel',fld:'vTFHISTORICOSOLICITUDESITEMSCT_SEL',pic:'',type:'char'},{av:'AV37TFHistoricoSolicitudesItemsSR',fld:'vTFHISTORICOSOLICITUDESITEMSSR',pic:'',type:'char'},{av:'AV38TFHistoricoSolicitudesItemsSR_Sel',fld:'vTFHISTORICOSOLICITUDESITEMSSR_SEL',pic:'',type:'char'},{av:'AV35TFHItemsSolicitudesMonedaId',fld:'vTFHITEMSSOLICITUDESMONEDAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFHItemsSolicitudesMonedaId_To',fld:'vTFHITEMSSOLICITUDESMONEDAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFHItemsSolicitudesItemsPrecioInstalacion',fld:'vTFHITEMSSOLICITUDESITEMSPRECIOINSTALACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV34TFHItemsSolicitudesItemsPrecioInstalacion_To',fld:'vTFHITEMSSOLICITUDESITEMSPRECIOINSTALACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31TFHItemsSolicitudesItemsCantidad',fld:'vTFHITEMSSOLICITUDESITEMSCANTIDAD',pic:'ZZZ9',type:'int'},{av:'AV32TFHItemsSolicitudesItemsCantidad_To',fld:'vTFHITEMSSOLICITUDESITEMSCANTIDAD_TO',pic:'ZZZ9',type:'int'},{av:'AV29TFHItemsInventarioPrecioFinal',fld:'vTFHITEMSINVENTARIOPRECIOFINAL',pic:'ZZZ9',type:'int'},{av:'AV30TFHItemsInventarioPrecioFinal_To',fld:'vTFHITEMSINVENTARIOPRECIOFINAL_TO',pic:'ZZZ9',type:'int'},{av:'AV27TFHItemsInventarioNombre',fld:'vTFHITEMSINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV28TFHItemsInventarioNombre_Sel',fld:'vTFHITEMSINVENTARIONOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFHItemsInventarioId',fld:'vTFHITEMSINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26TFHItemsInventarioId_To',fld:'vTFHITEMSINVENTARIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFHItemsMedidasID',fld:'vTFHITEMSMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFHItemsMedidasID_To',fld:'vTFHITEMSMEDIDASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21TFHItemsRubrosNombre',fld:'vTFHITEMSRUBROSNOMBRE',pic:'',type:'char'},{av:'AV22TFHItemsRubrosNombre_Sel',fld:'vTFHITEMSRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV19TFHItemsRubrosId',fld:'vTFHITEMSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20TFHItemsRubrosId_To',fld:'vTFHITEMSRUBROSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV17TFHistoricoSolicitudesItemsID',fld:'vTFHISTORICOSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'},{av:'AV18TFHistoricoSolicitudesItemsID_To',fld:'vTFHISTORICOSOLICITUDESITEMSID_TO',pic:'ZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E162K2',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[]}");
         setEventMetadata("VALID_HITEMSINVENTARIOPRECIOFINAL","{handler:'Valid_Hitemsinventariopreciofinal',iparms:[]");
         setEventMetadata("VALID_HITEMSINVENTARIOPRECIOFINAL",",oparms:[]}");
         setEventMetadata("VALID_HITEMSSOLICITUDESITEMSCANTIDAD","{handler:'Valid_Hitemssolicitudesitemscantidad',iparms:[]");
         setEventMetadata("VALID_HITEMSSOLICITUDESITEMSCANTIDAD",",oparms:[]}");
         setEventMetadata("VALID_HITEMSSOLICITUDESITEMSPRECIOIN","{handler:'Valid_Hitemssolicitudesitemsprecioin',iparms:[]");
         setEventMetadata("VALID_HITEMSSOLICITUDESITEMSPRECIOIN",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESITEMSSR","{handler:'Valid_Historicosolicitudesitemssr',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESITEMSSR",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESITEMSCT","{handler:'Valid_Historicosolicitudesitemsct',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESITEMSCT",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESITEMSCOMIS","{handler:'Valid_Historicosolicitudesitemscomis',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESITEMSCOMIS",",oparms:[]}");
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
         AV49Pgmname = "";
         AV21TFHItemsRubrosNombre = "";
         AV22TFHItemsRubrosNombre_Sel = "";
         AV27TFHItemsInventarioNombre = "";
         AV28TFHItemsInventarioNombre_Sel = "";
         AV37TFHistoricoSolicitudesItemsSR = "";
         AV38TFHistoricoSolicitudesItemsSR_Sel = "";
         AV39TFHistoricoSolicitudesItemsCT = "";
         AV40TFHistoricoSolicitudesItemsCT_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV48GridAppliedFilters = "";
         AV43DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         A331HItemsRubrosNombre = "";
         A329HItemsInventarioNombre = "";
         A296HistoricoSolicitudesItemsSR = "";
         A297HistoricoSolicitudesItemsCT = "";
         GXDecQS = "";
         lV21TFHItemsRubrosNombre = "";
         lV27TFHItemsInventarioNombre = "";
         lV37TFHistoricoSolicitudesItemsSR = "";
         lV39TFHistoricoSolicitudesItemsCT = "";
         H002K2_A153HistoricoSolicitudesID = new long[1] ;
         H002K2_A319HItemsSolicitudesMonedaId = new long[1] ;
         H002K2_A329HItemsInventarioNombre = new string[] {""} ;
         H002K2_A328HItemsInventarioId = new long[1] ;
         H002K2_A327HItemsMedidasID = new long[1] ;
         H002K2_A331HItemsRubrosNombre = new string[] {""} ;
         H002K2_A330HItemsRubrosId = new long[1] ;
         H002K2_A154HistoricoSolicitudesItemsID = new short[1] ;
         H002K2_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         H002K2_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         H002K2_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         H002K2_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         H002K2_A295HItemsInventarioPrecioFinal = new short[1] ;
         H002K3_A153HistoricoSolicitudesID = new long[1] ;
         H002K3_A319HItemsSolicitudesMonedaId = new long[1] ;
         H002K3_A329HItemsInventarioNombre = new string[] {""} ;
         H002K3_A328HItemsInventarioId = new long[1] ;
         H002K3_A327HItemsMedidasID = new long[1] ;
         H002K3_A331HItemsRubrosNombre = new string[] {""} ;
         H002K3_A330HItemsRubrosId = new long[1] ;
         H002K3_A154HistoricoSolicitudesItemsID = new short[1] ;
         H002K3_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         H002K3_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         H002K3_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         H002K3_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         H002K3_A295HItemsInventarioPrecioFinal = new short[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV16Session = context.GetSession();
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char3 = "";
         GXt_char2 = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8HistoricoSolicitudesID = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historicosolicitudesitemswc__default(),
            new Object[][] {
                new Object[] {
               H002K2_A153HistoricoSolicitudesID, H002K2_A319HItemsSolicitudesMonedaId, H002K2_A329HItemsInventarioNombre, H002K2_A328HItemsInventarioId, H002K2_A327HItemsMedidasID, H002K2_A331HItemsRubrosNombre, H002K2_A330HItemsRubrosId, H002K2_A154HistoricoSolicitudesItemsID, H002K2_A298HistoricoSolicitudesItemsComis, H002K2_A297HistoricoSolicitudesItemsCT,
               H002K2_A296HistoricoSolicitudesItemsSR, H002K2_A293HItemsSolicitudesItemsCantidad, H002K2_A295HItemsInventarioPrecioFinal
               }
               , new Object[] {
               H002K3_A153HistoricoSolicitudesID, H002K3_A319HItemsSolicitudesMonedaId, H002K3_A329HItemsInventarioNombre, H002K3_A328HItemsInventarioId, H002K3_A327HItemsMedidasID, H002K3_A331HItemsRubrosNombre, H002K3_A330HItemsRubrosId, H002K3_A154HistoricoSolicitudesItemsID, H002K3_A298HistoricoSolicitudesItemsComis, H002K3_A297HistoricoSolicitudesItemsCT,
               H002K3_A296HistoricoSolicitudesItemsSR, H002K3_A293HItemsSolicitudesItemsCantidad, H002K3_A295HItemsInventarioPrecioFinal
               }
            }
         );
         AV49Pgmname = "HistoricoSolicitudesItemsWC";
         /* GeneXus formulas. */
         AV49Pgmname = "HistoricoSolicitudesItemsWC";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14OrderedBy ;
      private short AV17TFHistoricoSolicitudesItemsID ;
      private short AV18TFHistoricoSolicitudesItemsID_To ;
      private short AV29TFHItemsInventarioPrecioFinal ;
      private short AV30TFHItemsInventarioPrecioFinal_To ;
      private short AV31TFHItemsSolicitudesItemsCantidad ;
      private short AV32TFHItemsSolicitudesItemsCantidad_To ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A154HistoricoSolicitudesItemsID ;
      private short A295HItemsInventarioPrecioFinal ;
      private short A293HItemsSolicitudesItemsCantidad ;
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
      private int edtHistoricoSolicitudesID_Visible ;
      private int subGrid_Islastpage ;
      private int edtHistoricoSolicitudesItemsID_Enabled ;
      private int edtHItemsRubrosId_Enabled ;
      private int edtHItemsRubrosNombre_Enabled ;
      private int edtHItemsMedidasID_Enabled ;
      private int edtHItemsInventarioId_Enabled ;
      private int edtHItemsInventarioNombre_Enabled ;
      private int edtHItemsInventarioPrecioFinal_Enabled ;
      private int edtHItemsSolicitudesItemsCantidad_Enabled ;
      private int edtHItemsSolicitudesItemsPrecioIn_Enabled ;
      private int edtHItemsSolicitudesMonedaId_Enabled ;
      private int edtHistoricoSolicitudesItemsSR_Enabled ;
      private int edtHistoricoSolicitudesItemsCT_Enabled ;
      private int edtHistoricoSolicitudesItemsComis_Enabled ;
      private int edtHistoricoSolicitudesID_Enabled ;
      private int AV45PageToGo ;
      private int AV50GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8HistoricoSolicitudesID ;
      private long wcpOAV8HistoricoSolicitudesID ;
      private long GRID_nFirstRecordOnPage ;
      private long AV19TFHItemsRubrosId ;
      private long AV20TFHItemsRubrosId_To ;
      private long AV23TFHItemsMedidasID ;
      private long AV24TFHItemsMedidasID_To ;
      private long AV25TFHItemsInventarioId ;
      private long AV26TFHItemsInventarioId_To ;
      private long AV35TFHItemsSolicitudesMonedaId ;
      private long AV36TFHItemsSolicitudesMonedaId_To ;
      private long AV46GridCurrentPage ;
      private long AV47GridPageCount ;
      private long A153HistoricoSolicitudesID ;
      private long A330HItemsRubrosId ;
      private long A327HItemsMedidasID ;
      private long A328HItemsInventarioId ;
      private long A319HItemsSolicitudesMonedaId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV33TFHItemsSolicitudesItemsPrecioInstalacion ;
      private decimal AV34TFHItemsSolicitudesItemsPrecioInstalacion_To ;
      private decimal AV41TFHistoricoSolicitudesItemsComision ;
      private decimal AV42TFHistoricoSolicitudesItemsComision_To ;
      private decimal A294HItemsSolicitudesItemsPrecioIn ;
      private decimal A298HistoricoSolicitudesItemsComis ;
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
      private string AV49Pgmname ;
      private string AV21TFHItemsRubrosNombre ;
      private string AV22TFHItemsRubrosNombre_Sel ;
      private string AV27TFHItemsInventarioNombre ;
      private string AV28TFHItemsInventarioNombre_Sel ;
      private string AV37TFHistoricoSolicitudesItemsSR ;
      private string AV38TFHistoricoSolicitudesItemsSR_Sel ;
      private string AV39TFHistoricoSolicitudesItemsCT ;
      private string AV40TFHistoricoSolicitudesItemsCT_Sel ;
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
      private string edtHistoricoSolicitudesID_Internalname ;
      private string edtHistoricoSolicitudesID_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtHistoricoSolicitudesItemsID_Internalname ;
      private string edtHItemsRubrosId_Internalname ;
      private string A331HItemsRubrosNombre ;
      private string edtHItemsRubrosNombre_Internalname ;
      private string edtHItemsMedidasID_Internalname ;
      private string edtHItemsInventarioId_Internalname ;
      private string A329HItemsInventarioNombre ;
      private string edtHItemsInventarioNombre_Internalname ;
      private string edtHItemsInventarioPrecioFinal_Internalname ;
      private string edtHItemsSolicitudesItemsCantidad_Internalname ;
      private string edtHItemsSolicitudesItemsPrecioIn_Internalname ;
      private string edtHItemsSolicitudesMonedaId_Internalname ;
      private string A296HistoricoSolicitudesItemsSR ;
      private string edtHistoricoSolicitudesItemsSR_Internalname ;
      private string A297HistoricoSolicitudesItemsCT ;
      private string edtHistoricoSolicitudesItemsCT_Internalname ;
      private string edtHistoricoSolicitudesItemsComis_Internalname ;
      private string GXDecQS ;
      private string lV21TFHItemsRubrosNombre ;
      private string lV27TFHItemsInventarioNombre ;
      private string lV37TFHistoricoSolicitudesItemsSR ;
      private string lV39TFHistoricoSolicitudesItemsCT ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string sCtrlAV8HistoricoSolicitudesID ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtHistoricoSolicitudesItemsID_Jsonclick ;
      private string edtHItemsRubrosId_Jsonclick ;
      private string edtHItemsRubrosNombre_Jsonclick ;
      private string edtHItemsMedidasID_Jsonclick ;
      private string edtHItemsInventarioId_Jsonclick ;
      private string edtHItemsInventarioNombre_Jsonclick ;
      private string edtHItemsInventarioPrecioFinal_Jsonclick ;
      private string edtHItemsSolicitudesItemsCantidad_Jsonclick ;
      private string edtHItemsSolicitudesItemsPrecioIn_Jsonclick ;
      private string edtHItemsSolicitudesMonedaId_Jsonclick ;
      private string edtHistoricoSolicitudesItemsSR_Jsonclick ;
      private string edtHistoricoSolicitudesItemsCT_Jsonclick ;
      private string edtHistoricoSolicitudesItemsComis_Jsonclick ;
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
      private bool bGXsfl_15_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV48GridAppliedFilters ;
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
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV43DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private long[] H002K2_A153HistoricoSolicitudesID ;
      private long[] H002K2_A319HItemsSolicitudesMonedaId ;
      private string[] H002K2_A329HItemsInventarioNombre ;
      private long[] H002K2_A328HItemsInventarioId ;
      private long[] H002K2_A327HItemsMedidasID ;
      private string[] H002K2_A331HItemsRubrosNombre ;
      private long[] H002K2_A330HItemsRubrosId ;
      private short[] H002K2_A154HistoricoSolicitudesItemsID ;
      private decimal[] H002K2_A298HistoricoSolicitudesItemsComis ;
      private string[] H002K2_A297HistoricoSolicitudesItemsCT ;
      private string[] H002K2_A296HistoricoSolicitudesItemsSR ;
      private short[] H002K2_A293HItemsSolicitudesItemsCantidad ;
      private short[] H002K2_A295HItemsInventarioPrecioFinal ;
      private long[] H002K3_A153HistoricoSolicitudesID ;
      private long[] H002K3_A319HItemsSolicitudesMonedaId ;
      private string[] H002K3_A329HItemsInventarioNombre ;
      private long[] H002K3_A328HItemsInventarioId ;
      private long[] H002K3_A327HItemsMedidasID ;
      private string[] H002K3_A331HItemsRubrosNombre ;
      private long[] H002K3_A330HItemsRubrosId ;
      private short[] H002K3_A154HistoricoSolicitudesItemsID ;
      private decimal[] H002K3_A298HistoricoSolicitudesItemsComis ;
      private string[] H002K3_A297HistoricoSolicitudesItemsCT ;
      private string[] H002K3_A296HistoricoSolicitudesItemsSR ;
      private short[] H002K3_A293HItemsSolicitudesItemsCantidad ;
      private short[] H002K3_A295HItemsInventarioPrecioFinal ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class historicosolicitudesitemswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002K2( IGxContext context ,
                                             short AV17TFHistoricoSolicitudesItemsID ,
                                             short AV18TFHistoricoSolicitudesItemsID_To ,
                                             long AV19TFHItemsRubrosId ,
                                             long AV20TFHItemsRubrosId_To ,
                                             string AV22TFHItemsRubrosNombre_Sel ,
                                             string AV21TFHItemsRubrosNombre ,
                                             long AV23TFHItemsMedidasID ,
                                             long AV24TFHItemsMedidasID_To ,
                                             long AV25TFHItemsInventarioId ,
                                             long AV26TFHItemsInventarioId_To ,
                                             string AV28TFHItemsInventarioNombre_Sel ,
                                             string AV27TFHItemsInventarioNombre ,
                                             short AV29TFHItemsInventarioPrecioFinal ,
                                             short AV30TFHItemsInventarioPrecioFinal_To ,
                                             short AV31TFHItemsSolicitudesItemsCantidad ,
                                             short AV32TFHItemsSolicitudesItemsCantidad_To ,
                                             long AV35TFHItemsSolicitudesMonedaId ,
                                             long AV36TFHItemsSolicitudesMonedaId_To ,
                                             string AV38TFHistoricoSolicitudesItemsSR_Sel ,
                                             string AV37TFHistoricoSolicitudesItemsSR ,
                                             string AV40TFHistoricoSolicitudesItemsCT_Sel ,
                                             string AV39TFHistoricoSolicitudesItemsCT ,
                                             decimal AV41TFHistoricoSolicitudesItemsComision ,
                                             decimal AV42TFHistoricoSolicitudesItemsComision_To ,
                                             short A154HistoricoSolicitudesItemsID ,
                                             long A330HItemsRubrosId ,
                                             string A331HItemsRubrosNombre ,
                                             long A327HItemsMedidasID ,
                                             long A328HItemsInventarioId ,
                                             string A329HItemsInventarioNombre ,
                                             short A295HItemsInventarioPrecioFinal ,
                                             short A293HItemsSolicitudesItemsCantidad ,
                                             long A319HItemsSolicitudesMonedaId ,
                                             string A296HistoricoSolicitudesItemsSR ,
                                             string A297HistoricoSolicitudesItemsCT ,
                                             decimal A298HistoricoSolicitudesItemsComis ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             decimal AV33TFHItemsSolicitudesItemsPrecioInstalacion ,
                                             decimal A294HItemsSolicitudesItemsPrecioIn ,
                                             decimal AV34TFHItemsSolicitudesItemsPrecioInstalacion_To ,
                                             long AV8HistoricoSolicitudesID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[25];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [HistoricoSolicitudesID], [HItemsSolicitudesMonedaId], [HItemsInventarioNombre], [HItemsInventarioId], [HItemsMedidasID], [HItemsRubrosNombre], [HItemsRubrosId], [HistoricoSolicitudesItemsID], [HistoricoSolicitudesItemsComis], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsSR], [HItemsSolicitudesItemsCantidad], [HItemsInventarioPrecioFinal] FROM [HistoricoSolicitudesItems]";
         AddWhere(sWhereString, "([HistoricoSolicitudesID] = @AV8HistoricoSolicitudesID)");
         if ( ! (0==AV17TFHistoricoSolicitudesItemsID) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsID] >= @AV17TFHistoricoSolicitudesItemsID)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (0==AV18TFHistoricoSolicitudesItemsID_To) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsID] <= @AV18TFHistoricoSolicitudesItemsID_To)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! (0==AV19TFHItemsRubrosId) )
         {
            AddWhere(sWhereString, "([HItemsRubrosId] >= @AV19TFHItemsRubrosId)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV20TFHItemsRubrosId_To) )
         {
            AddWhere(sWhereString, "([HItemsRubrosId] <= @AV20TFHItemsRubrosId_To)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHItemsRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHItemsRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HItemsRubrosNombre]) like UPPER(@lV21TFHItemsRubrosNombre))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHItemsRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFHItemsRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HItemsRubrosNombre] = @AV22TFHItemsRubrosNombre_Sel)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFHItemsRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HItemsRubrosNombre] = ''))");
         }
         if ( ! (0==AV23TFHItemsMedidasID) )
         {
            AddWhere(sWhereString, "([HItemsMedidasID] >= @AV23TFHItemsMedidasID)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! (0==AV24TFHItemsMedidasID_To) )
         {
            AddWhere(sWhereString, "([HItemsMedidasID] <= @AV24TFHItemsMedidasID_To)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! (0==AV25TFHItemsInventarioId) )
         {
            AddWhere(sWhereString, "([HItemsInventarioId] >= @AV25TFHItemsInventarioId)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! (0==AV26TFHItemsInventarioId_To) )
         {
            AddWhere(sWhereString, "([HItemsInventarioId] <= @AV26TFHItemsInventarioId_To)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFHItemsInventarioNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFHItemsInventarioNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HItemsInventarioNombre]) like UPPER(@lV27TFHItemsInventarioNombre))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFHItemsInventarioNombre_Sel)) && ! ( StringUtil.StrCmp(AV28TFHItemsInventarioNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HItemsInventarioNombre] = @AV28TFHItemsInventarioNombre_Sel)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFHItemsInventarioNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HItemsInventarioNombre] = ''))");
         }
         if ( ! (0==AV29TFHItemsInventarioPrecioFinal) )
         {
            AddWhere(sWhereString, "([HItemsInventarioPrecioFinal] >= @AV29TFHItemsInventarioPrecioFinal)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! (0==AV30TFHItemsInventarioPrecioFinal_To) )
         {
            AddWhere(sWhereString, "([HItemsInventarioPrecioFinal] <= @AV30TFHItemsInventarioPrecioFinal_To)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! (0==AV31TFHItemsSolicitudesItemsCantidad) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesItemsCantidad] >= @AV31TFHItemsSolicitudesItemsCantidad)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! (0==AV32TFHItemsSolicitudesItemsCantidad_To) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesItemsCantidad] <= @AV32TFHItemsSolicitudesItemsCantidad_To)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! (0==AV35TFHItemsSolicitudesMonedaId) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesMonedaId] >= @AV35TFHItemsSolicitudesMonedaId)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! (0==AV36TFHItemsSolicitudesMonedaId_To) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesMonedaId] <= @AV36TFHItemsSolicitudesMonedaId_To)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFHistoricoSolicitudesItemsSR_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFHistoricoSolicitudesItemsSR)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HistoricoSolicitudesItemsSR]) like UPPER(@lV37TFHistoricoSolicitudesItemsSR))");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFHistoricoSolicitudesItemsSR_Sel)) && ! ( StringUtil.StrCmp(AV38TFHistoricoSolicitudesItemsSR_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsSR] = @AV38TFHistoricoSolicitudesItemsSR_Sel)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( StringUtil.StrCmp(AV38TFHistoricoSolicitudesItemsSR_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HistoricoSolicitudesItemsSR] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFHistoricoSolicitudesItemsCT_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFHistoricoSolicitudesItemsCT)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HistoricoSolicitudesItemsCT]) like UPPER(@lV39TFHistoricoSolicitudesItemsCT))");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFHistoricoSolicitudesItemsCT_Sel)) && ! ( StringUtil.StrCmp(AV40TFHistoricoSolicitudesItemsCT_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsCT] = @AV40TFHistoricoSolicitudesItemsCT_Sel)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( StringUtil.StrCmp(AV40TFHistoricoSolicitudesItemsCT_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HistoricoSolicitudesItemsCT] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV41TFHistoricoSolicitudesItemsComision) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsComis] >= @AV41TFHistoricoSolicitudesItemsComision)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV42TFHistoricoSolicitudesItemsComision_To) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsComis] <= @AV42TFHistoricoSolicitudesItemsComision_To)");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HistoricoSolicitudesItemsID] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsRubrosId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsRubrosId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsRubrosNombre]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsRubrosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsMedidasID]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsMedidasID] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsInventarioId]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsInventarioId] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsInventarioNombre]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsInventarioNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsInventarioPrecioFinal]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsInventarioPrecioFinal] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsSolicitudesItemsCantidad]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsSolicitudesItemsCantidad] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsSolicitudesMonedaId]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsSolicitudesMonedaId] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HistoricoSolicitudesItemsSR]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HistoricoSolicitudesItemsSR] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HistoricoSolicitudesItemsCT]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HistoricoSolicitudesItemsCT] DESC";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HistoricoSolicitudesItemsComis]";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HistoricoSolicitudesItemsComis] DESC";
         }
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H002K3( IGxContext context ,
                                             short AV17TFHistoricoSolicitudesItemsID ,
                                             short AV18TFHistoricoSolicitudesItemsID_To ,
                                             long AV19TFHItemsRubrosId ,
                                             long AV20TFHItemsRubrosId_To ,
                                             string AV22TFHItemsRubrosNombre_Sel ,
                                             string AV21TFHItemsRubrosNombre ,
                                             long AV23TFHItemsMedidasID ,
                                             long AV24TFHItemsMedidasID_To ,
                                             long AV25TFHItemsInventarioId ,
                                             long AV26TFHItemsInventarioId_To ,
                                             string AV28TFHItemsInventarioNombre_Sel ,
                                             string AV27TFHItemsInventarioNombre ,
                                             short AV29TFHItemsInventarioPrecioFinal ,
                                             short AV30TFHItemsInventarioPrecioFinal_To ,
                                             short AV31TFHItemsSolicitudesItemsCantidad ,
                                             short AV32TFHItemsSolicitudesItemsCantidad_To ,
                                             long AV35TFHItemsSolicitudesMonedaId ,
                                             long AV36TFHItemsSolicitudesMonedaId_To ,
                                             string AV38TFHistoricoSolicitudesItemsSR_Sel ,
                                             string AV37TFHistoricoSolicitudesItemsSR ,
                                             string AV40TFHistoricoSolicitudesItemsCT_Sel ,
                                             string AV39TFHistoricoSolicitudesItemsCT ,
                                             decimal AV41TFHistoricoSolicitudesItemsComision ,
                                             decimal AV42TFHistoricoSolicitudesItemsComision_To ,
                                             short A154HistoricoSolicitudesItemsID ,
                                             long A330HItemsRubrosId ,
                                             string A331HItemsRubrosNombre ,
                                             long A327HItemsMedidasID ,
                                             long A328HItemsInventarioId ,
                                             string A329HItemsInventarioNombre ,
                                             short A295HItemsInventarioPrecioFinal ,
                                             short A293HItemsSolicitudesItemsCantidad ,
                                             long A319HItemsSolicitudesMonedaId ,
                                             string A296HistoricoSolicitudesItemsSR ,
                                             string A297HistoricoSolicitudesItemsCT ,
                                             decimal A298HistoricoSolicitudesItemsComis ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             decimal AV33TFHItemsSolicitudesItemsPrecioInstalacion ,
                                             decimal A294HItemsSolicitudesItemsPrecioIn ,
                                             decimal AV34TFHItemsSolicitudesItemsPrecioInstalacion_To ,
                                             long AV8HistoricoSolicitudesID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[25];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT [HistoricoSolicitudesID], [HItemsSolicitudesMonedaId], [HItemsInventarioNombre], [HItemsInventarioId], [HItemsMedidasID], [HItemsRubrosNombre], [HItemsRubrosId], [HistoricoSolicitudesItemsID], [HistoricoSolicitudesItemsComis], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsSR], [HItemsSolicitudesItemsCantidad], [HItemsInventarioPrecioFinal] FROM [HistoricoSolicitudesItems]";
         AddWhere(sWhereString, "([HistoricoSolicitudesID] = @AV8HistoricoSolicitudesID)");
         if ( ! (0==AV17TFHistoricoSolicitudesItemsID) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsID] >= @AV17TFHistoricoSolicitudesItemsID)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! (0==AV18TFHistoricoSolicitudesItemsID_To) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsID] <= @AV18TFHistoricoSolicitudesItemsID_To)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ! (0==AV19TFHItemsRubrosId) )
         {
            AddWhere(sWhereString, "([HItemsRubrosId] >= @AV19TFHItemsRubrosId)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! (0==AV20TFHItemsRubrosId_To) )
         {
            AddWhere(sWhereString, "([HItemsRubrosId] <= @AV20TFHItemsRubrosId_To)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHItemsRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHItemsRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HItemsRubrosNombre]) like UPPER(@lV21TFHItemsRubrosNombre))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHItemsRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFHItemsRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HItemsRubrosNombre] = @AV22TFHItemsRubrosNombre_Sel)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFHItemsRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HItemsRubrosNombre] = ''))");
         }
         if ( ! (0==AV23TFHItemsMedidasID) )
         {
            AddWhere(sWhereString, "([HItemsMedidasID] >= @AV23TFHItemsMedidasID)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! (0==AV24TFHItemsMedidasID_To) )
         {
            AddWhere(sWhereString, "([HItemsMedidasID] <= @AV24TFHItemsMedidasID_To)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! (0==AV25TFHItemsInventarioId) )
         {
            AddWhere(sWhereString, "([HItemsInventarioId] >= @AV25TFHItemsInventarioId)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! (0==AV26TFHItemsInventarioId_To) )
         {
            AddWhere(sWhereString, "([HItemsInventarioId] <= @AV26TFHItemsInventarioId_To)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFHItemsInventarioNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFHItemsInventarioNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HItemsInventarioNombre]) like UPPER(@lV27TFHItemsInventarioNombre))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFHItemsInventarioNombre_Sel)) && ! ( StringUtil.StrCmp(AV28TFHItemsInventarioNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HItemsInventarioNombre] = @AV28TFHItemsInventarioNombre_Sel)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFHItemsInventarioNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HItemsInventarioNombre] = ''))");
         }
         if ( ! (0==AV29TFHItemsInventarioPrecioFinal) )
         {
            AddWhere(sWhereString, "([HItemsInventarioPrecioFinal] >= @AV29TFHItemsInventarioPrecioFinal)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! (0==AV30TFHItemsInventarioPrecioFinal_To) )
         {
            AddWhere(sWhereString, "([HItemsInventarioPrecioFinal] <= @AV30TFHItemsInventarioPrecioFinal_To)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ! (0==AV31TFHItemsSolicitudesItemsCantidad) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesItemsCantidad] >= @AV31TFHItemsSolicitudesItemsCantidad)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! (0==AV32TFHItemsSolicitudesItemsCantidad_To) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesItemsCantidad] <= @AV32TFHItemsSolicitudesItemsCantidad_To)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ! (0==AV35TFHItemsSolicitudesMonedaId) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesMonedaId] >= @AV35TFHItemsSolicitudesMonedaId)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ! (0==AV36TFHItemsSolicitudesMonedaId_To) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesMonedaId] <= @AV36TFHItemsSolicitudesMonedaId_To)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFHistoricoSolicitudesItemsSR_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFHistoricoSolicitudesItemsSR)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HistoricoSolicitudesItemsSR]) like UPPER(@lV37TFHistoricoSolicitudesItemsSR))");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFHistoricoSolicitudesItemsSR_Sel)) && ! ( StringUtil.StrCmp(AV38TFHistoricoSolicitudesItemsSR_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsSR] = @AV38TFHistoricoSolicitudesItemsSR_Sel)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( StringUtil.StrCmp(AV38TFHistoricoSolicitudesItemsSR_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HistoricoSolicitudesItemsSR] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFHistoricoSolicitudesItemsCT_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFHistoricoSolicitudesItemsCT)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HistoricoSolicitudesItemsCT]) like UPPER(@lV39TFHistoricoSolicitudesItemsCT))");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFHistoricoSolicitudesItemsCT_Sel)) && ! ( StringUtil.StrCmp(AV40TFHistoricoSolicitudesItemsCT_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsCT] = @AV40TFHistoricoSolicitudesItemsCT_Sel)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( StringUtil.StrCmp(AV40TFHistoricoSolicitudesItemsCT_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HistoricoSolicitudesItemsCT] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV41TFHistoricoSolicitudesItemsComision) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsComis] >= @AV41TFHistoricoSolicitudesItemsComision)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV42TFHistoricoSolicitudesItemsComision_To) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsComis] <= @AV42TFHistoricoSolicitudesItemsComision_To)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HistoricoSolicitudesItemsID] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsRubrosId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsRubrosId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsRubrosNombre]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsRubrosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsMedidasID]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsMedidasID] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsInventarioId]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsInventarioId] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsInventarioNombre]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsInventarioNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsInventarioPrecioFinal]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsInventarioPrecioFinal] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsSolicitudesItemsCantidad]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsSolicitudesItemsCantidad] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsSolicitudesMonedaId]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HItemsSolicitudesMonedaId] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HistoricoSolicitudesItemsSR]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HistoricoSolicitudesItemsSR] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HistoricoSolicitudesItemsCT]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HistoricoSolicitudesItemsCT] DESC";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HistoricoSolicitudesItemsComis]";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HistoricoSolicitudesID] DESC, [HistoricoSolicitudesItemsComis] DESC";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H002K2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (short)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (short)dynConstraints[36] , (bool)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (long)dynConstraints[41] , (long)dynConstraints[42] );
               case 1 :
                     return conditional_H002K3(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (short)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (short)dynConstraints[36] , (bool)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (long)dynConstraints[41] , (long)dynConstraints[42] );
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
          Object[] prmH002K2;
          prmH002K2 = new Object[] {
          new ParDef("@AV8HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV17TFHistoricoSolicitudesItemsID",GXType.Int16,4,0) ,
          new ParDef("@AV18TFHistoricoSolicitudesItemsID_To",GXType.Int16,4,0) ,
          new ParDef("@AV19TFHItemsRubrosId",GXType.Decimal,18,0) ,
          new ParDef("@AV20TFHItemsRubrosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV21TFHItemsRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV22TFHItemsRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV23TFHItemsMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV24TFHItemsMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV25TFHItemsInventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV26TFHItemsInventarioId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV27TFHItemsInventarioNombre",GXType.Char,100,0) ,
          new ParDef("@AV28TFHItemsInventarioNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV29TFHItemsInventarioPrecioFinal",GXType.Int16,4,0) ,
          new ParDef("@AV30TFHItemsInventarioPrecioFinal_To",GXType.Int16,4,0) ,
          new ParDef("@AV31TFHItemsSolicitudesItemsCantidad",GXType.Int16,4,0) ,
          new ParDef("@AV32TFHItemsSolicitudesItemsCantidad_To",GXType.Int16,4,0) ,
          new ParDef("@AV35TFHItemsSolicitudesMonedaId",GXType.Decimal,18,0) ,
          new ParDef("@AV36TFHItemsSolicitudesMonedaId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV37TFHistoricoSolicitudesItemsSR",GXType.Char,1,0) ,
          new ParDef("@AV38TFHistoricoSolicitudesItemsSR_Sel",GXType.NChar,1,0) ,
          new ParDef("@lV39TFHistoricoSolicitudesItemsCT",GXType.Char,1,0) ,
          new ParDef("@AV40TFHistoricoSolicitudesItemsCT_Sel",GXType.NChar,1,0) ,
          new ParDef("@AV41TFHistoricoSolicitudesItemsComision",GXType.Decimal,18,2) ,
          new ParDef("@AV42TFHistoricoSolicitudesItemsComision_To",GXType.Decimal,18,2)
          };
          Object[] prmH002K3;
          prmH002K3 = new Object[] {
          new ParDef("@AV8HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV17TFHistoricoSolicitudesItemsID",GXType.Int16,4,0) ,
          new ParDef("@AV18TFHistoricoSolicitudesItemsID_To",GXType.Int16,4,0) ,
          new ParDef("@AV19TFHItemsRubrosId",GXType.Decimal,18,0) ,
          new ParDef("@AV20TFHItemsRubrosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV21TFHItemsRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV22TFHItemsRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV23TFHItemsMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV24TFHItemsMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV25TFHItemsInventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV26TFHItemsInventarioId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV27TFHItemsInventarioNombre",GXType.Char,100,0) ,
          new ParDef("@AV28TFHItemsInventarioNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV29TFHItemsInventarioPrecioFinal",GXType.Int16,4,0) ,
          new ParDef("@AV30TFHItemsInventarioPrecioFinal_To",GXType.Int16,4,0) ,
          new ParDef("@AV31TFHItemsSolicitudesItemsCantidad",GXType.Int16,4,0) ,
          new ParDef("@AV32TFHItemsSolicitudesItemsCantidad_To",GXType.Int16,4,0) ,
          new ParDef("@AV35TFHItemsSolicitudesMonedaId",GXType.Decimal,18,0) ,
          new ParDef("@AV36TFHItemsSolicitudesMonedaId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV37TFHistoricoSolicitudesItemsSR",GXType.Char,1,0) ,
          new ParDef("@AV38TFHistoricoSolicitudesItemsSR_Sel",GXType.NChar,1,0) ,
          new ParDef("@lV39TFHistoricoSolicitudesItemsCT",GXType.Char,1,0) ,
          new ParDef("@AV40TFHistoricoSolicitudesItemsCT_Sel",GXType.NChar,1,0) ,
          new ParDef("@AV41TFHistoricoSolicitudesItemsComision",GXType.Decimal,18,2) ,
          new ParDef("@AV42TFHistoricoSolicitudesItemsComision_To",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("H002K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002K2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002K3,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 1);
                ((string[]) buf[10])[0] = rslt.getString(11, 1);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 1);
                ((string[]) buf[10])[0] = rslt.getString(11, 1);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                return;
       }
    }

 }

}
