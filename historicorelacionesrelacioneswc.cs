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
   public class historicorelacionesrelacioneswc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public historicorelacionesrelacioneswc( )
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

      public historicorelacionesrelacioneswc( IGxContext context )
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
         AV46Pgmname = GetPar( "Pgmname");
         AV17TFHistoricoRelacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHistoricoRelacionesId"), "."), 18, MidpointRounding.ToEven));
         AV18TFHistoricoRelacionesId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHistoricoRelacionesId_To"), "."), 18, MidpointRounding.ToEven));
         AV19TFHistoricoRelacionesProfesionalesId = GetPar( "TFHistoricoRelacionesProfesionalesId");
         AV20TFHistoricoRelacionesProfesionalesId_Sel = GetPar( "TFHistoricoRelacionesProfesionalesId_Sel");
         AV21TFHistoricoRelacionesNombre = GetPar( "TFHistoricoRelacionesNombre");
         AV22TFHistoricoRelacionesNombre_Sel = GetPar( "TFHistoricoRelacionesNombre_Sel");
         AV23TFHistoricoRelacionesApellido = GetPar( "TFHistoricoRelacionesApellido");
         AV24TFHistoricoRelacionesApellido_Sel = GetPar( "TFHistoricoRelacionesApellido_Sel");
         AV25TFEstadoSGTipo = GetPar( "TFEstadoSGTipo");
         AV26TFEstadoSGTipo_Sel = GetPar( "TFEstadoSGTipo_Sel");
         AV27TFEstadoSGNombre = GetPar( "TFEstadoSGNombre");
         AV28TFEstadoSGNombre_Sel = GetPar( "TFEstadoSGNombre_Sel");
         AV29TFHistoricoRelacionesFechaAlta = context.localUtil.ParseDTimeParm( GetPar( "TFHistoricoRelacionesFechaAlta"));
         AV30TFHistoricoRelacionesFechaAlta_To = context.localUtil.ParseDTimeParm( GetPar( "TFHistoricoRelacionesFechaAlta_To"));
         AV34TFHistoricoRelacionesFechaModif = context.localUtil.ParseDTimeParm( GetPar( "TFHistoricoRelacionesFechaModif"));
         AV35TFHistoricoRelacionesFechaModif_To = context.localUtil.ParseDTimeParm( GetPar( "TFHistoricoRelacionesFechaModif_To"));
         AV45IsAuthorized_EstadoSGNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_EstadoSGNombre"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8HistoricoSolicitudesID, AV46Pgmname, AV17TFHistoricoRelacionesId, AV18TFHistoricoRelacionesId_To, AV19TFHistoricoRelacionesProfesionalesId, AV20TFHistoricoRelacionesProfesionalesId_Sel, AV21TFHistoricoRelacionesNombre, AV22TFHistoricoRelacionesNombre_Sel, AV23TFHistoricoRelacionesApellido, AV24TFHistoricoRelacionesApellido_Sel, AV25TFEstadoSGTipo, AV26TFEstadoSGTipo_Sel, AV27TFEstadoSGNombre, AV28TFEstadoSGNombre_Sel, AV29TFHistoricoRelacionesFechaAlta, AV30TFHistoricoRelacionesFechaAlta_To, AV34TFHistoricoRelacionesFechaModif, AV35TFHistoricoRelacionesFechaModif_To, AV45IsAuthorized_EstadoSGNombre, sPrefix) ;
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
            PA2P2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV46Pgmname = "HistoricoRelacionesRelacionesWC";
               WS2P2( ) ;
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
            context.SendWebValue( context.GetMessage( "Historico Relaciones Relaciones WC", "")) ;
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
            GXEncryptionTmp = "historicorelacionesrelacioneswc.aspx"+UrlEncode(StringUtil.LTrimStr(AV8HistoricoSolicitudesID,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("historicorelacionesrelacioneswc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_ESTADOSGNOMBRE", AV45IsAuthorized_EstadoSGNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSGNOMBRE", GetSecureSignedToken( sPrefix, AV45IsAuthorized_EstadoSGNombre, context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_HISTORICORELACIONESFECHAALTAAUXDATETO", context.localUtil.DToC( AV32DDO_HistoricoRelacionesFechaAltaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_HISTORICORELACIONESFECHAMODIFAUXDATETO", context.localUtil.DToC( AV37DDO_HistoricoRelacionesFechaModifAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8HistoricoSolicitudesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV46Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICORELACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17TFHistoricoRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICORELACIONESID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18TFHistoricoRelacionesId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICORELACIONESPROFESIONALESID", StringUtil.RTrim( AV19TFHistoricoRelacionesProfesionalesId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICORELACIONESPROFESIONALESID_SEL", StringUtil.RTrim( AV20TFHistoricoRelacionesProfesionalesId_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICORELACIONESNOMBRE", StringUtil.RTrim( AV21TFHistoricoRelacionesNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICORELACIONESNOMBRE_SEL", StringUtil.RTrim( AV22TFHistoricoRelacionesNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICORELACIONESAPELLIDO", StringUtil.RTrim( AV23TFHistoricoRelacionesApellido));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICORELACIONESAPELLIDO_SEL", StringUtil.RTrim( AV24TFHistoricoRelacionesApellido_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTADOSGTIPO", StringUtil.RTrim( AV25TFEstadoSGTipo));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTADOSGTIPO_SEL", StringUtil.RTrim( AV26TFEstadoSGTipo_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTADOSGNOMBRE", StringUtil.RTrim( AV27TFEstadoSGNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTADOSGNOMBRE_SEL", StringUtil.RTrim( AV28TFEstadoSGNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICORELACIONESFECHAALTA", context.localUtil.TToC( AV29TFHistoricoRelacionesFechaAlta, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICORELACIONESFECHAALTA_TO", context.localUtil.TToC( AV30TFHistoricoRelacionesFechaAlta_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICORELACIONESFECHAMODIF", context.localUtil.TToC( AV34TFHistoricoRelacionesFechaModif, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICORELACIONESFECHAMODIF_TO", context.localUtil.TToC( AV35TFHistoricoRelacionesFechaModif_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vHISTORICOSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_ESTADOSGNOMBRE", AV45IsAuthorized_EstadoSGNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSGNOMBRE", GetSecureSignedToken( sPrefix, AV45IsAuthorized_EstadoSGNombre, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_HISTORICORELACIONESFECHAALTAAUXDATE", context.localUtil.DToC( AV31DDO_HistoricoRelacionesFechaAltaAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_HISTORICORELACIONESFECHAMODIFAUXDATE", context.localUtil.DToC( AV36DDO_HistoricoRelacionesFechaModifAuxDate, 0, "/"));
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

      protected void RenderHtmlCloseForm2P2( )
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
         return "HistoricoRelacionesRelacionesWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Historico Relaciones Relaciones WC", "") ;
      }

      protected void WB2P0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "historicorelacionesrelacioneswc.aspx");
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
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV39DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A153HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A153HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesID_Jsonclick, 0, "Attribute", "", "", "", "", edtHistoricoSolicitudesID_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_HistoricoRelacionesRelacionesWC.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_historicorelacionesfechaaltaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'" + sGXsfl_15_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_historicorelacionesfechaaltaauxdatetext_Internalname, AV33DDO_HistoricoRelacionesFechaAltaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV33DDO_HistoricoRelacionesFechaAltaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_historicorelacionesfechaaltaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoRelacionesRelacionesWC.htm");
            /* User Defined Control */
            ucTfhistoricorelacionesfechaalta_rangepicker.SetProperty("Start Date", AV31DDO_HistoricoRelacionesFechaAltaAuxDate);
            ucTfhistoricorelacionesfechaalta_rangepicker.SetProperty("End Date", AV32DDO_HistoricoRelacionesFechaAltaAuxDateTo);
            ucTfhistoricorelacionesfechaalta_rangepicker.Render(context, "wwp.daterangepicker", Tfhistoricorelacionesfechaalta_rangepicker_Internalname, sPrefix+"TFHISTORICORELACIONESFECHAALTA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_historicorelacionesfechamodifauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'" + sGXsfl_15_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_historicorelacionesfechamodifauxdatetext_Internalname, AV38DDO_HistoricoRelacionesFechaModifAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV38DDO_HistoricoRelacionesFechaModifAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_historicorelacionesfechamodifauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoRelacionesRelacionesWC.htm");
            /* User Defined Control */
            ucTfhistoricorelacionesfechamodif_rangepicker.SetProperty("Start Date", AV36DDO_HistoricoRelacionesFechaModifAuxDate);
            ucTfhistoricorelacionesfechamodif_rangepicker.SetProperty("End Date", AV37DDO_HistoricoRelacionesFechaModifAuxDateTo);
            ucTfhistoricorelacionesfechamodif_rangepicker.Render(context, "wwp.daterangepicker", Tfhistoricorelacionesfechamodif_rangepicker_Internalname, sPrefix+"TFHISTORICORELACIONESFECHAMODIF_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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

      protected void START2P2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Historico Relaciones Relaciones WC", ""), 0) ;
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
               STRUP2P0( ) ;
            }
         }
      }

      protected void WS2P2( )
      {
         START2P2( ) ;
         EVT2P2( ) ;
      }

      protected void EVT2P2( )
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
                                 STRUP2P0( ) ;
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
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E112P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E122P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E132P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavDdo_historicorelacionesfechaaltaauxdatetext_Internalname;
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
                                 STRUP2P0( ) ;
                              }
                              nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              A156HistoricoRelacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoRelacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A320HistoricoRelacionesProfesional = cgiGet( edtHistoricoRelacionesProfesional_Internalname);
                              A323HistoricoRelacionesNombre = cgiGet( edtHistoricoRelacionesNombre_Internalname);
                              A324HistoricoRelacionesApellido = cgiGet( edtHistoricoRelacionesApellido_Internalname);
                              A141EstadoSGTipo = cgiGet( edtEstadoSGTipo_Internalname);
                              A142EstadoSGId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadoSGId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A143EstadoSGNombre = cgiGet( edtEstadoSGNombre_Internalname);
                              A321HistoricoRelacionesFechaAlta = context.localUtil.CToT( cgiGet( edtHistoricoRelacionesFechaAlta_Internalname), 0);
                              A322HistoricoRelacionesFechaModif = context.localUtil.CToT( cgiGet( edtHistoricoRelacionesFechaModif_Internalname), 0);
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
                                          GX_FocusControl = edtavDdo_historicorelacionesfechaaltaauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E142P2 ();
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
                                          GX_FocusControl = edtavDdo_historicorelacionesfechaaltaauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E152P2 ();
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
                                          GX_FocusControl = edtavDdo_historicorelacionesfechaaltaauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E162P2 ();
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
                                       STRUP2P0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDdo_historicorelacionesfechaaltaauxdatetext_Internalname;
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

      protected void WE2P2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2P2( ) ;
            }
         }
      }

      protected void PA2P2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "historicorelacionesrelacioneswc.aspx")), "historicorelacionesrelacioneswc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "historicorelacionesrelacioneswc.aspx")))) ;
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
               GX_FocusControl = edtavDdo_historicorelacionesfechaaltaauxdatetext_Internalname;
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
                                       string AV46Pgmname ,
                                       long AV17TFHistoricoRelacionesId ,
                                       long AV18TFHistoricoRelacionesId_To ,
                                       string AV19TFHistoricoRelacionesProfesionalesId ,
                                       string AV20TFHistoricoRelacionesProfesionalesId_Sel ,
                                       string AV21TFHistoricoRelacionesNombre ,
                                       string AV22TFHistoricoRelacionesNombre_Sel ,
                                       string AV23TFHistoricoRelacionesApellido ,
                                       string AV24TFHistoricoRelacionesApellido_Sel ,
                                       string AV25TFEstadoSGTipo ,
                                       string AV26TFEstadoSGTipo_Sel ,
                                       string AV27TFEstadoSGNombre ,
                                       string AV28TFEstadoSGNombre_Sel ,
                                       DateTime AV29TFHistoricoRelacionesFechaAlta ,
                                       DateTime AV30TFHistoricoRelacionesFechaAlta_To ,
                                       DateTime AV34TFHistoricoRelacionesFechaModif ,
                                       DateTime AV35TFHistoricoRelacionesFechaModif_To ,
                                       bool AV45IsAuthorized_EstadoSGNombre ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2P2( ) ;
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
         RF2P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV46Pgmname = "HistoricoRelacionesRelacionesWC";
      }

      protected void RF2P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 15;
         /* Execute user event: Refresh */
         E152P2 ();
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
                                                 AV17TFHistoricoRelacionesId ,
                                                 AV18TFHistoricoRelacionesId_To ,
                                                 AV20TFHistoricoRelacionesProfesionalesId_Sel ,
                                                 AV19TFHistoricoRelacionesProfesionalesId ,
                                                 AV22TFHistoricoRelacionesNombre_Sel ,
                                                 AV21TFHistoricoRelacionesNombre ,
                                                 AV24TFHistoricoRelacionesApellido_Sel ,
                                                 AV23TFHistoricoRelacionesApellido ,
                                                 AV26TFEstadoSGTipo_Sel ,
                                                 AV25TFEstadoSGTipo ,
                                                 AV28TFEstadoSGNombre_Sel ,
                                                 AV27TFEstadoSGNombre ,
                                                 AV29TFHistoricoRelacionesFechaAlta ,
                                                 AV30TFHistoricoRelacionesFechaAlta_To ,
                                                 AV34TFHistoricoRelacionesFechaModif ,
                                                 AV35TFHistoricoRelacionesFechaModif_To ,
                                                 A156HistoricoRelacionesId ,
                                                 A320HistoricoRelacionesProfesional ,
                                                 A323HistoricoRelacionesNombre ,
                                                 A324HistoricoRelacionesApellido ,
                                                 A141EstadoSGTipo ,
                                                 A143EstadoSGNombre ,
                                                 A321HistoricoRelacionesFechaAlta ,
                                                 A322HistoricoRelacionesFechaModif ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV8HistoricoSolicitudesID ,
                                                 A153HistoricoSolicitudesID } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV19TFHistoricoRelacionesProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV19TFHistoricoRelacionesProfesionalesId), 20, "%");
            lV21TFHistoricoRelacionesNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFHistoricoRelacionesNombre), 80, "%");
            lV23TFHistoricoRelacionesApellido = StringUtil.PadR( StringUtil.RTrim( AV23TFHistoricoRelacionesApellido), 80, "%");
            lV25TFEstadoSGTipo = StringUtil.PadR( StringUtil.RTrim( AV25TFEstadoSGTipo), 3, "%");
            lV27TFEstadoSGNombre = StringUtil.PadR( StringUtil.RTrim( AV27TFEstadoSGNombre), 80, "%");
            /* Using cursor H002P2 */
            pr_default.execute(0, new Object[] {AV8HistoricoSolicitudesID, AV17TFHistoricoRelacionesId, AV18TFHistoricoRelacionesId_To, lV19TFHistoricoRelacionesProfesionalesId, AV20TFHistoricoRelacionesProfesionalesId_Sel, lV21TFHistoricoRelacionesNombre, AV22TFHistoricoRelacionesNombre_Sel, lV23TFHistoricoRelacionesApellido, AV24TFHistoricoRelacionesApellido_Sel, lV25TFEstadoSGTipo, AV26TFEstadoSGTipo_Sel, lV27TFEstadoSGNombre, AV28TFEstadoSGNombre_Sel, AV29TFHistoricoRelacionesFechaAlta, AV30TFHistoricoRelacionesFechaAlta_To, AV34TFHistoricoRelacionesFechaModif, AV35TFHistoricoRelacionesFechaModif_To, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_15_idx = 1;
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A153HistoricoSolicitudesID = H002P2_A153HistoricoSolicitudesID[0];
               AssignAttri(sPrefix, false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
               A322HistoricoRelacionesFechaModif = H002P2_A322HistoricoRelacionesFechaModif[0];
               A321HistoricoRelacionesFechaAlta = H002P2_A321HistoricoRelacionesFechaAlta[0];
               A143EstadoSGNombre = H002P2_A143EstadoSGNombre[0];
               A142EstadoSGId = H002P2_A142EstadoSGId[0];
               A141EstadoSGTipo = H002P2_A141EstadoSGTipo[0];
               A324HistoricoRelacionesApellido = H002P2_A324HistoricoRelacionesApellido[0];
               A323HistoricoRelacionesNombre = H002P2_A323HistoricoRelacionesNombre[0];
               A320HistoricoRelacionesProfesional = H002P2_A320HistoricoRelacionesProfesional[0];
               A156HistoricoRelacionesId = H002P2_A156HistoricoRelacionesId[0];
               A143EstadoSGNombre = H002P2_A143EstadoSGNombre[0];
               /* Execute user event: Grid.Load */
               E162P2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 15;
            WB2P0( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2P2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV46Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_ESTADOSGNOMBRE", AV45IsAuthorized_EstadoSGNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSGNOMBRE", GetSecureSignedToken( sPrefix, AV45IsAuthorized_EstadoSGNombre, context));
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
                                              AV17TFHistoricoRelacionesId ,
                                              AV18TFHistoricoRelacionesId_To ,
                                              AV20TFHistoricoRelacionesProfesionalesId_Sel ,
                                              AV19TFHistoricoRelacionesProfesionalesId ,
                                              AV22TFHistoricoRelacionesNombre_Sel ,
                                              AV21TFHistoricoRelacionesNombre ,
                                              AV24TFHistoricoRelacionesApellido_Sel ,
                                              AV23TFHistoricoRelacionesApellido ,
                                              AV26TFEstadoSGTipo_Sel ,
                                              AV25TFEstadoSGTipo ,
                                              AV28TFEstadoSGNombre_Sel ,
                                              AV27TFEstadoSGNombre ,
                                              AV29TFHistoricoRelacionesFechaAlta ,
                                              AV30TFHistoricoRelacionesFechaAlta_To ,
                                              AV34TFHistoricoRelacionesFechaModif ,
                                              AV35TFHistoricoRelacionesFechaModif_To ,
                                              A156HistoricoRelacionesId ,
                                              A320HistoricoRelacionesProfesional ,
                                              A323HistoricoRelacionesNombre ,
                                              A324HistoricoRelacionesApellido ,
                                              A141EstadoSGTipo ,
                                              A143EstadoSGNombre ,
                                              A321HistoricoRelacionesFechaAlta ,
                                              A322HistoricoRelacionesFechaModif ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV8HistoricoSolicitudesID ,
                                              A153HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV19TFHistoricoRelacionesProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV19TFHistoricoRelacionesProfesionalesId), 20, "%");
         lV21TFHistoricoRelacionesNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFHistoricoRelacionesNombre), 80, "%");
         lV23TFHistoricoRelacionesApellido = StringUtil.PadR( StringUtil.RTrim( AV23TFHistoricoRelacionesApellido), 80, "%");
         lV25TFEstadoSGTipo = StringUtil.PadR( StringUtil.RTrim( AV25TFEstadoSGTipo), 3, "%");
         lV27TFEstadoSGNombre = StringUtil.PadR( StringUtil.RTrim( AV27TFEstadoSGNombre), 80, "%");
         /* Using cursor H002P3 */
         pr_default.execute(1, new Object[] {AV8HistoricoSolicitudesID, AV17TFHistoricoRelacionesId, AV18TFHistoricoRelacionesId_To, lV19TFHistoricoRelacionesProfesionalesId, AV20TFHistoricoRelacionesProfesionalesId_Sel, lV21TFHistoricoRelacionesNombre, AV22TFHistoricoRelacionesNombre_Sel, lV23TFHistoricoRelacionesApellido, AV24TFHistoricoRelacionesApellido_Sel, lV25TFEstadoSGTipo, AV26TFEstadoSGTipo_Sel, lV27TFEstadoSGNombre, AV28TFEstadoSGNombre_Sel, AV29TFHistoricoRelacionesFechaAlta, AV30TFHistoricoRelacionesFechaAlta_To, AV34TFHistoricoRelacionesFechaModif, AV35TFHistoricoRelacionesFechaModif_To});
         GRID_nRecordCount = H002P3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8HistoricoSolicitudesID, AV46Pgmname, AV17TFHistoricoRelacionesId, AV18TFHistoricoRelacionesId_To, AV19TFHistoricoRelacionesProfesionalesId, AV20TFHistoricoRelacionesProfesionalesId_Sel, AV21TFHistoricoRelacionesNombre, AV22TFHistoricoRelacionesNombre_Sel, AV23TFHistoricoRelacionesApellido, AV24TFHistoricoRelacionesApellido_Sel, AV25TFEstadoSGTipo, AV26TFEstadoSGTipo_Sel, AV27TFEstadoSGNombre, AV28TFEstadoSGNombre_Sel, AV29TFHistoricoRelacionesFechaAlta, AV30TFHistoricoRelacionesFechaAlta_To, AV34TFHistoricoRelacionesFechaModif, AV35TFHistoricoRelacionesFechaModif_To, AV45IsAuthorized_EstadoSGNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8HistoricoSolicitudesID, AV46Pgmname, AV17TFHistoricoRelacionesId, AV18TFHistoricoRelacionesId_To, AV19TFHistoricoRelacionesProfesionalesId, AV20TFHistoricoRelacionesProfesionalesId_Sel, AV21TFHistoricoRelacionesNombre, AV22TFHistoricoRelacionesNombre_Sel, AV23TFHistoricoRelacionesApellido, AV24TFHistoricoRelacionesApellido_Sel, AV25TFEstadoSGTipo, AV26TFEstadoSGTipo_Sel, AV27TFEstadoSGNombre, AV28TFEstadoSGNombre_Sel, AV29TFHistoricoRelacionesFechaAlta, AV30TFHistoricoRelacionesFechaAlta_To, AV34TFHistoricoRelacionesFechaModif, AV35TFHistoricoRelacionesFechaModif_To, AV45IsAuthorized_EstadoSGNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8HistoricoSolicitudesID, AV46Pgmname, AV17TFHistoricoRelacionesId, AV18TFHistoricoRelacionesId_To, AV19TFHistoricoRelacionesProfesionalesId, AV20TFHistoricoRelacionesProfesionalesId_Sel, AV21TFHistoricoRelacionesNombre, AV22TFHistoricoRelacionesNombre_Sel, AV23TFHistoricoRelacionesApellido, AV24TFHistoricoRelacionesApellido_Sel, AV25TFEstadoSGTipo, AV26TFEstadoSGTipo_Sel, AV27TFEstadoSGNombre, AV28TFEstadoSGNombre_Sel, AV29TFHistoricoRelacionesFechaAlta, AV30TFHistoricoRelacionesFechaAlta_To, AV34TFHistoricoRelacionesFechaModif, AV35TFHistoricoRelacionesFechaModif_To, AV45IsAuthorized_EstadoSGNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8HistoricoSolicitudesID, AV46Pgmname, AV17TFHistoricoRelacionesId, AV18TFHistoricoRelacionesId_To, AV19TFHistoricoRelacionesProfesionalesId, AV20TFHistoricoRelacionesProfesionalesId_Sel, AV21TFHistoricoRelacionesNombre, AV22TFHistoricoRelacionesNombre_Sel, AV23TFHistoricoRelacionesApellido, AV24TFHistoricoRelacionesApellido_Sel, AV25TFEstadoSGTipo, AV26TFEstadoSGTipo_Sel, AV27TFEstadoSGNombre, AV28TFEstadoSGNombre_Sel, AV29TFHistoricoRelacionesFechaAlta, AV30TFHistoricoRelacionesFechaAlta_To, AV34TFHistoricoRelacionesFechaModif, AV35TFHistoricoRelacionesFechaModif_To, AV45IsAuthorized_EstadoSGNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8HistoricoSolicitudesID, AV46Pgmname, AV17TFHistoricoRelacionesId, AV18TFHistoricoRelacionesId_To, AV19TFHistoricoRelacionesProfesionalesId, AV20TFHistoricoRelacionesProfesionalesId_Sel, AV21TFHistoricoRelacionesNombre, AV22TFHistoricoRelacionesNombre_Sel, AV23TFHistoricoRelacionesApellido, AV24TFHistoricoRelacionesApellido_Sel, AV25TFEstadoSGTipo, AV26TFEstadoSGTipo_Sel, AV27TFEstadoSGNombre, AV28TFEstadoSGNombre_Sel, AV29TFHistoricoRelacionesFechaAlta, AV30TFHistoricoRelacionesFechaAlta_To, AV34TFHistoricoRelacionesFechaModif, AV35TFHistoricoRelacionesFechaModif_To, AV45IsAuthorized_EstadoSGNombre, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV46Pgmname = "HistoricoRelacionesRelacionesWC";
         edtHistoricoRelacionesId_Enabled = 0;
         edtHistoricoRelacionesProfesional_Enabled = 0;
         edtHistoricoRelacionesNombre_Enabled = 0;
         edtHistoricoRelacionesApellido_Enabled = 0;
         edtEstadoSGTipo_Enabled = 0;
         edtEstadoSGId_Enabled = 0;
         edtEstadoSGNombre_Enabled = 0;
         edtHistoricoRelacionesFechaAlta_Enabled = 0;
         edtHistoricoRelacionesFechaModif_Enabled = 0;
         edtHistoricoSolicitudesID_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesID_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E142P2 ();
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
            AV31DDO_HistoricoRelacionesFechaAltaAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_HISTORICORELACIONESFECHAALTAAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV31DDO_HistoricoRelacionesFechaAltaAuxDate", context.localUtil.Format(AV31DDO_HistoricoRelacionesFechaAltaAuxDate, "99/99/99"));
            AV32DDO_HistoricoRelacionesFechaAltaAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_HISTORICORELACIONESFECHAALTAAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV32DDO_HistoricoRelacionesFechaAltaAuxDateTo", context.localUtil.Format(AV32DDO_HistoricoRelacionesFechaAltaAuxDateTo, "99/99/99"));
            AV36DDO_HistoricoRelacionesFechaModifAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_HISTORICORELACIONESFECHAMODIFAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV36DDO_HistoricoRelacionesFechaModifAuxDate", context.localUtil.Format(AV36DDO_HistoricoRelacionesFechaModifAuxDate, "99/99/99"));
            AV37DDO_HistoricoRelacionesFechaModifAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_HISTORICORELACIONESFECHAMODIFAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV37DDO_HistoricoRelacionesFechaModifAuxDateTo", context.localUtil.Format(AV37DDO_HistoricoRelacionesFechaModifAuxDateTo, "99/99/99"));
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
            AV33DDO_HistoricoRelacionesFechaAltaAuxDateText = cgiGet( edtavDdo_historicorelacionesfechaaltaauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV33DDO_HistoricoRelacionesFechaAltaAuxDateText", AV33DDO_HistoricoRelacionesFechaAltaAuxDateText);
            AV38DDO_HistoricoRelacionesFechaModifAuxDateText = cgiGet( edtavDdo_historicorelacionesfechamodifauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV38DDO_HistoricoRelacionesFechaModifAuxDateText", AV38DDO_HistoricoRelacionesFechaModifAuxDateText);
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
         E142P2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E142P2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFHISTORICORELACIONESFECHAMODIF_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_historicorelacionesfechamodifauxdatetext_Internalname});
         this.executeUsercontrolMethod(sPrefix, false, "TFHISTORICORELACIONESFECHAALTA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_historicorelacionesfechaaltaauxdatetext_Internalname});
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         GXt_boolean1 = AV45IsAuthorized_EstadoSGNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion", out  GXt_boolean1) ;
         AV45IsAuthorized_EstadoSGNombre = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV45IsAuthorized_EstadoSGNombre", AV45IsAuthorized_EstadoSGNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSGNOMBRE", GetSecureSignedToken( sPrefix, AV45IsAuthorized_EstadoSGNombre, context));
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV39DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV39DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E152P2( )
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

      protected void E112P2( )
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

      protected void E122P2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E132P2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoRelacionesId") == 0 )
            {
               AV17TFHistoricoRelacionesId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV17TFHistoricoRelacionesId", StringUtil.LTrimStr( (decimal)(AV17TFHistoricoRelacionesId), 18, 0));
               AV18TFHistoricoRelacionesId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV18TFHistoricoRelacionesId_To", StringUtil.LTrimStr( (decimal)(AV18TFHistoricoRelacionesId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoRelacionesProfesionalesId") == 0 )
            {
               AV19TFHistoricoRelacionesProfesionalesId = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV19TFHistoricoRelacionesProfesionalesId", AV19TFHistoricoRelacionesProfesionalesId);
               AV20TFHistoricoRelacionesProfesionalesId_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV20TFHistoricoRelacionesProfesionalesId_Sel", AV20TFHistoricoRelacionesProfesionalesId_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoRelacionesNombre") == 0 )
            {
               AV21TFHistoricoRelacionesNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV21TFHistoricoRelacionesNombre", AV21TFHistoricoRelacionesNombre);
               AV22TFHistoricoRelacionesNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV22TFHistoricoRelacionesNombre_Sel", AV22TFHistoricoRelacionesNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoRelacionesApellido") == 0 )
            {
               AV23TFHistoricoRelacionesApellido = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV23TFHistoricoRelacionesApellido", AV23TFHistoricoRelacionesApellido);
               AV24TFHistoricoRelacionesApellido_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV24TFHistoricoRelacionesApellido_Sel", AV24TFHistoricoRelacionesApellido_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstadoSGTipo") == 0 )
            {
               AV25TFEstadoSGTipo = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV25TFEstadoSGTipo", AV25TFEstadoSGTipo);
               AV26TFEstadoSGTipo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV26TFEstadoSGTipo_Sel", AV26TFEstadoSGTipo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstadoSGNombre") == 0 )
            {
               AV27TFEstadoSGNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV27TFEstadoSGNombre", AV27TFEstadoSGNombre);
               AV28TFEstadoSGNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV28TFEstadoSGNombre_Sel", AV28TFEstadoSGNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoRelacionesFechaAlta") == 0 )
            {
               AV29TFHistoricoRelacionesFechaAlta = context.localUtil.CToT( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV29TFHistoricoRelacionesFechaAlta", context.localUtil.TToC( AV29TFHistoricoRelacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV30TFHistoricoRelacionesFechaAlta_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV30TFHistoricoRelacionesFechaAlta_To", context.localUtil.TToC( AV30TFHistoricoRelacionesFechaAlta_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               if ( ! (DateTime.MinValue==AV30TFHistoricoRelacionesFechaAlta_To) )
               {
                  AV30TFHistoricoRelacionesFechaAlta_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV30TFHistoricoRelacionesFechaAlta_To)), (short)(DateTimeUtil.Month( AV30TFHistoricoRelacionesFechaAlta_To)), (short)(DateTimeUtil.Day( AV30TFHistoricoRelacionesFechaAlta_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV30TFHistoricoRelacionesFechaAlta_To", context.localUtil.TToC( AV30TFHistoricoRelacionesFechaAlta_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoRelacionesFechaModif") == 0 )
            {
               AV34TFHistoricoRelacionesFechaModif = context.localUtil.CToT( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV34TFHistoricoRelacionesFechaModif", context.localUtil.TToC( AV34TFHistoricoRelacionesFechaModif, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV35TFHistoricoRelacionesFechaModif_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV35TFHistoricoRelacionesFechaModif_To", context.localUtil.TToC( AV35TFHistoricoRelacionesFechaModif_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               if ( ! (DateTime.MinValue==AV35TFHistoricoRelacionesFechaModif_To) )
               {
                  AV35TFHistoricoRelacionesFechaModif_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV35TFHistoricoRelacionesFechaModif_To)), (short)(DateTimeUtil.Month( AV35TFHistoricoRelacionesFechaModif_To)), (short)(DateTimeUtil.Day( AV35TFHistoricoRelacionesFechaModif_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV35TFHistoricoRelacionesFechaModif_To", context.localUtil.TToC( AV35TFHistoricoRelacionesFechaModif_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E162P2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( AV45IsAuthorized_EstadoSGNombre )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "estadosnotificacionview.aspx"+UrlEncode(StringUtil.RTrim(A141EstadoSGTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A142EstadoSGId,5,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtEstadoSGNombre_Link = formatLink("estadosnotificacionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESID") == 0 )
            {
               AV17TFHistoricoRelacionesId = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV17TFHistoricoRelacionesId", StringUtil.LTrimStr( (decimal)(AV17TFHistoricoRelacionesId), 18, 0));
               AV18TFHistoricoRelacionesId_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV18TFHistoricoRelacionesId_To", StringUtil.LTrimStr( (decimal)(AV18TFHistoricoRelacionesId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESPROFESIONALESID") == 0 )
            {
               AV19TFHistoricoRelacionesProfesionalesId = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV19TFHistoricoRelacionesProfesionalesId", AV19TFHistoricoRelacionesProfesionalesId);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESPROFESIONALESID_SEL") == 0 )
            {
               AV20TFHistoricoRelacionesProfesionalesId_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV20TFHistoricoRelacionesProfesionalesId_Sel", AV20TFHistoricoRelacionesProfesionalesId_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESNOMBRE") == 0 )
            {
               AV21TFHistoricoRelacionesNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV21TFHistoricoRelacionesNombre", AV21TFHistoricoRelacionesNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESNOMBRE_SEL") == 0 )
            {
               AV22TFHistoricoRelacionesNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV22TFHistoricoRelacionesNombre_Sel", AV22TFHistoricoRelacionesNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESAPELLIDO") == 0 )
            {
               AV23TFHistoricoRelacionesApellido = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV23TFHistoricoRelacionesApellido", AV23TFHistoricoRelacionesApellido);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESAPELLIDO_SEL") == 0 )
            {
               AV24TFHistoricoRelacionesApellido_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV24TFHistoricoRelacionesApellido_Sel", AV24TFHistoricoRelacionesApellido_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFESTADOSGTIPO") == 0 )
            {
               AV25TFEstadoSGTipo = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV25TFEstadoSGTipo", AV25TFEstadoSGTipo);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFESTADOSGTIPO_SEL") == 0 )
            {
               AV26TFEstadoSGTipo_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV26TFEstadoSGTipo_Sel", AV26TFEstadoSGTipo_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFESTADOSGNOMBRE") == 0 )
            {
               AV27TFEstadoSGNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV27TFEstadoSGNombre", AV27TFEstadoSGNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFESTADOSGNOMBRE_SEL") == 0 )
            {
               AV28TFEstadoSGNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV28TFEstadoSGNombre_Sel", AV28TFEstadoSGNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESFECHAALTA") == 0 )
            {
               AV29TFHistoricoRelacionesFechaAlta = context.localUtil.CToT( AV13GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV29TFHistoricoRelacionesFechaAlta", context.localUtil.TToC( AV29TFHistoricoRelacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV30TFHistoricoRelacionesFechaAlta_To = context.localUtil.CToT( AV13GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV30TFHistoricoRelacionesFechaAlta_To", context.localUtil.TToC( AV30TFHistoricoRelacionesFechaAlta_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV31DDO_HistoricoRelacionesFechaAltaAuxDate = DateTimeUtil.ResetTime(AV29TFHistoricoRelacionesFechaAlta);
               AssignAttri(sPrefix, false, "AV31DDO_HistoricoRelacionesFechaAltaAuxDate", context.localUtil.Format(AV31DDO_HistoricoRelacionesFechaAltaAuxDate, "99/99/99"));
               AV32DDO_HistoricoRelacionesFechaAltaAuxDateTo = DateTimeUtil.ResetTime(AV30TFHistoricoRelacionesFechaAlta_To);
               AssignAttri(sPrefix, false, "AV32DDO_HistoricoRelacionesFechaAltaAuxDateTo", context.localUtil.Format(AV32DDO_HistoricoRelacionesFechaAltaAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESFECHAMODIF") == 0 )
            {
               AV34TFHistoricoRelacionesFechaModif = context.localUtil.CToT( AV13GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV34TFHistoricoRelacionesFechaModif", context.localUtil.TToC( AV34TFHistoricoRelacionesFechaModif, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV35TFHistoricoRelacionesFechaModif_To = context.localUtil.CToT( AV13GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV35TFHistoricoRelacionesFechaModif_To", context.localUtil.TToC( AV35TFHistoricoRelacionesFechaModif_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV36DDO_HistoricoRelacionesFechaModifAuxDate = DateTimeUtil.ResetTime(AV34TFHistoricoRelacionesFechaModif);
               AssignAttri(sPrefix, false, "AV36DDO_HistoricoRelacionesFechaModifAuxDate", context.localUtil.Format(AV36DDO_HistoricoRelacionesFechaModifAuxDate, "99/99/99"));
               AV37DDO_HistoricoRelacionesFechaModifAuxDateTo = DateTimeUtil.ResetTime(AV35TFHistoricoRelacionesFechaModif_To);
               AssignAttri(sPrefix, false, "AV37DDO_HistoricoRelacionesFechaModifAuxDateTo", context.localUtil.Format(AV37DDO_HistoricoRelacionesFechaModifAuxDateTo, "99/99/99"));
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV20TFHistoricoRelacionesProfesionalesId_Sel)),  AV20TFHistoricoRelacionesProfesionalesId_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHistoricoRelacionesNombre_Sel)),  AV22TFHistoricoRelacionesNombre_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFHistoricoRelacionesApellido_Sel)),  AV24TFHistoricoRelacionesApellido_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFEstadoSGTipo_Sel)),  AV26TFEstadoSGTipo_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFEstadoSGNombre_Sel)),  AV28TFEstadoSGNombre_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char3+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV19TFHistoricoRelacionesProfesionalesId)),  AV19TFHistoricoRelacionesProfesionalesId, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHistoricoRelacionesNombre)),  AV21TFHistoricoRelacionesNombre, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFHistoricoRelacionesApellido)),  AV23TFHistoricoRelacionesApellido, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFEstadoSGTipo)),  AV25TFEstadoSGTipo, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFEstadoSGNombre)),  AV27TFEstadoSGNombre, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((0==AV17TFHistoricoRelacionesId) ? "" : StringUtil.Str( (decimal)(AV17TFHistoricoRelacionesId), 18, 0))+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"|"+GXt_char3+"|"+((DateTime.MinValue==AV29TFHistoricoRelacionesFechaAlta) ? "" : context.localUtil.DToC( AV31DDO_HistoricoRelacionesFechaAltaAuxDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV34TFHistoricoRelacionesFechaModif) ? "" : context.localUtil.DToC( AV36DDO_HistoricoRelacionesFechaModifAuxDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV18TFHistoricoRelacionesId_To) ? "" : StringUtil.Str( (decimal)(AV18TFHistoricoRelacionesId_To), 18, 0))+"||||||"+((DateTime.MinValue==AV30TFHistoricoRelacionesFechaAlta_To) ? "" : context.localUtil.DToC( AV32DDO_HistoricoRelacionesFechaAltaAuxDateTo, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV35TFHistoricoRelacionesFechaModif_To) ? "" : context.localUtil.DToC( AV37DDO_HistoricoRelacionesFechaModifAuxDateTo, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
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
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICORELACIONESID",  context.GetMessage( "Correlativo", ""),  !((0==AV17TFHistoricoRelacionesId)&&(0==AV18TFHistoricoRelacionesId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV17TFHistoricoRelacionesId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV18TFHistoricoRelacionesId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICORELACIONESPROFESIONALESID",  context.GetMessage( "ID", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV19TFHistoricoRelacionesProfesionalesId)),  0,  AV19TFHistoricoRelacionesProfesionalesId,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFHistoricoRelacionesProfesionalesId_Sel)),  AV20TFHistoricoRelacionesProfesionalesId_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICORELACIONESNOMBRE",  context.GetMessage( "Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHistoricoRelacionesNombre)),  0,  AV21TFHistoricoRelacionesNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHistoricoRelacionesNombre_Sel)),  AV22TFHistoricoRelacionesNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICORELACIONESAPELLIDO",  context.GetMessage( "Apellido", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFHistoricoRelacionesApellido)),  0,  AV23TFHistoricoRelacionesApellido,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFHistoricoRelacionesApellido_Sel)),  AV24TFHistoricoRelacionesApellido_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFESTADOSGTIPO",  context.GetMessage( "SGTipo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFEstadoSGTipo)),  0,  AV25TFEstadoSGTipo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFEstadoSGTipo_Sel)),  AV26TFEstadoSGTipo_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFESTADOSGNOMBRE",  context.GetMessage( "SGNombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFEstadoSGNombre)),  0,  AV27TFEstadoSGNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFEstadoSGNombre_Sel)),  AV28TFEstadoSGNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICORELACIONESFECHAALTA",  context.GetMessage( "Alta", ""),  !((DateTime.MinValue==AV29TFHistoricoRelacionesFechaAlta)&&(DateTime.MinValue==AV30TFHistoricoRelacionesFechaAlta_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV29TFHistoricoRelacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV30TFHistoricoRelacionesFechaAlta_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICORELACIONESFECHAMODIF",  context.GetMessage( "Modifado", ""),  !((DateTime.MinValue==AV34TFHistoricoRelacionesFechaModif)&&(DateTime.MinValue==AV35TFHistoricoRelacionesFechaModif_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV34TFHistoricoRelacionesFechaModif, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV35TFHistoricoRelacionesFechaModif_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))) ;
         if ( ! (0==AV8HistoricoSolicitudesID) )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = "PARM_&HISTORICOSOLICITUDESID";
            AV13GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV8HistoricoSolicitudesID), 18, 0);
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
         AV10TrnContext.gxTpr_Transactionname = "HistoricoRelaciones";
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
         PA2P2( ) ;
         WS2P2( ) ;
         WE2P2( ) ;
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
         PA2P2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "historicorelacionesrelacioneswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2P2( ) ;
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
         PA2P2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2P2( ) ;
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
         WS2P2( ) ;
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
         WE2P2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026862221247", true, true, false);
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
         context.AddJavascriptSource("historicorelacionesrelacioneswc.js", "?2026862221247", false, true, false);
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

      protected void SubsflControlProps_152( )
      {
         edtHistoricoRelacionesId_Internalname = sPrefix+"HISTORICORELACIONESID_"+sGXsfl_15_idx;
         edtHistoricoRelacionesProfesional_Internalname = sPrefix+"HISTORICORELACIONESPROFESIONAL_"+sGXsfl_15_idx;
         edtHistoricoRelacionesNombre_Internalname = sPrefix+"HISTORICORELACIONESNOMBRE_"+sGXsfl_15_idx;
         edtHistoricoRelacionesApellido_Internalname = sPrefix+"HISTORICORELACIONESAPELLIDO_"+sGXsfl_15_idx;
         edtEstadoSGTipo_Internalname = sPrefix+"ESTADOSGTIPO_"+sGXsfl_15_idx;
         edtEstadoSGId_Internalname = sPrefix+"ESTADOSGID_"+sGXsfl_15_idx;
         edtEstadoSGNombre_Internalname = sPrefix+"ESTADOSGNOMBRE_"+sGXsfl_15_idx;
         edtHistoricoRelacionesFechaAlta_Internalname = sPrefix+"HISTORICORELACIONESFECHAALTA_"+sGXsfl_15_idx;
         edtHistoricoRelacionesFechaModif_Internalname = sPrefix+"HISTORICORELACIONESFECHAMODIF_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         edtHistoricoRelacionesId_Internalname = sPrefix+"HISTORICORELACIONESID_"+sGXsfl_15_fel_idx;
         edtHistoricoRelacionesProfesional_Internalname = sPrefix+"HISTORICORELACIONESPROFESIONAL_"+sGXsfl_15_fel_idx;
         edtHistoricoRelacionesNombre_Internalname = sPrefix+"HISTORICORELACIONESNOMBRE_"+sGXsfl_15_fel_idx;
         edtHistoricoRelacionesApellido_Internalname = sPrefix+"HISTORICORELACIONESAPELLIDO_"+sGXsfl_15_fel_idx;
         edtEstadoSGTipo_Internalname = sPrefix+"ESTADOSGTIPO_"+sGXsfl_15_fel_idx;
         edtEstadoSGId_Internalname = sPrefix+"ESTADOSGID_"+sGXsfl_15_fel_idx;
         edtEstadoSGNombre_Internalname = sPrefix+"ESTADOSGNOMBRE_"+sGXsfl_15_fel_idx;
         edtHistoricoRelacionesFechaAlta_Internalname = sPrefix+"HISTORICORELACIONESFECHAALTA_"+sGXsfl_15_fel_idx;
         edtHistoricoRelacionesFechaModif_Internalname = sPrefix+"HISTORICORELACIONESFECHAMODIF_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         WB2P0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoRelacionesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A156HistoricoRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A156HistoricoRelacionesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoRelacionesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoRelacionesProfesional_Internalname,StringUtil.RTrim( A320HistoricoRelacionesProfesional),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoRelacionesProfesional_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoRelacionesNombre_Internalname,StringUtil.RTrim( A323HistoricoRelacionesNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoRelacionesNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoRelacionesApellido_Internalname,StringUtil.RTrim( A324HistoricoRelacionesApellido),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoRelacionesApellido_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoSGTipo_Internalname,StringUtil.RTrim( A141EstadoSGTipo),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoSGTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoSGId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A142EstadoSGId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A142EstadoSGId), "ZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoSGId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoSGNombre_Internalname,StringUtil.RTrim( A143EstadoSGNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtEstadoSGNombre_Link,(string)"",(string)"",(string)"",(string)edtEstadoSGNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoRelacionesFechaAlta_Internalname,context.localUtil.TToC( A321HistoricoRelacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A321HistoricoRelacionesFechaAlta, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoRelacionesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoRelacionesFechaModif_Internalname,context.localUtil.TToC( A322HistoricoRelacionesFechaModif, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A322HistoricoRelacionesFechaModif, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoRelacionesFechaModif_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes2P2( ) ;
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
            context.SendWebValue( context.GetMessage( "Correlativo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Apellido", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "SGTipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "SGId", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "SGNombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Modifado", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A156HistoricoRelacionesId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A320HistoricoRelacionesProfesional)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A323HistoricoRelacionesNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A324HistoricoRelacionesApellido)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A141EstadoSGTipo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A142EstadoSGId), 5, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A143EstadoSGNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtEstadoSGNombre_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A321HistoricoRelacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A322HistoricoRelacionesFechaModif, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
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
         edtHistoricoRelacionesId_Internalname = sPrefix+"HISTORICORELACIONESID";
         edtHistoricoRelacionesProfesional_Internalname = sPrefix+"HISTORICORELACIONESPROFESIONAL";
         edtHistoricoRelacionesNombre_Internalname = sPrefix+"HISTORICORELACIONESNOMBRE";
         edtHistoricoRelacionesApellido_Internalname = sPrefix+"HISTORICORELACIONESAPELLIDO";
         edtEstadoSGTipo_Internalname = sPrefix+"ESTADOSGTIPO";
         edtEstadoSGId_Internalname = sPrefix+"ESTADOSGID";
         edtEstadoSGNombre_Internalname = sPrefix+"ESTADOSGNOMBRE";
         edtHistoricoRelacionesFechaAlta_Internalname = sPrefix+"HISTORICORELACIONESFECHAALTA";
         edtHistoricoRelacionesFechaModif_Internalname = sPrefix+"HISTORICORELACIONESFECHAMODIF";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtHistoricoSolicitudesID_Internalname = sPrefix+"HISTORICOSOLICITUDESID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_historicorelacionesfechaaltaauxdatetext_Internalname = sPrefix+"vDDO_HISTORICORELACIONESFECHAALTAAUXDATETEXT";
         Tfhistoricorelacionesfechaalta_rangepicker_Internalname = sPrefix+"TFHISTORICORELACIONESFECHAALTA_RANGEPICKER";
         divDdo_historicorelacionesfechaaltaauxdates_Internalname = sPrefix+"DDO_HISTORICORELACIONESFECHAALTAAUXDATES";
         edtavDdo_historicorelacionesfechamodifauxdatetext_Internalname = sPrefix+"vDDO_HISTORICORELACIONESFECHAMODIFAUXDATETEXT";
         Tfhistoricorelacionesfechamodif_rangepicker_Internalname = sPrefix+"TFHISTORICORELACIONESFECHAMODIF_RANGEPICKER";
         divDdo_historicorelacionesfechamodifauxdates_Internalname = sPrefix+"DDO_HISTORICORELACIONESFECHAMODIFAUXDATES";
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
         edtHistoricoRelacionesFechaModif_Jsonclick = "";
         edtHistoricoRelacionesFechaAlta_Jsonclick = "";
         edtEstadoSGNombre_Jsonclick = "";
         edtEstadoSGNombre_Link = "";
         edtEstadoSGId_Jsonclick = "";
         edtEstadoSGTipo_Jsonclick = "";
         edtHistoricoRelacionesApellido_Jsonclick = "";
         edtHistoricoRelacionesNombre_Jsonclick = "";
         edtHistoricoRelacionesProfesional_Jsonclick = "";
         edtHistoricoRelacionesId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtHistoricoSolicitudesID_Enabled = 0;
         edtHistoricoRelacionesFechaModif_Enabled = 0;
         edtHistoricoRelacionesFechaAlta_Enabled = 0;
         edtEstadoSGNombre_Enabled = 0;
         edtEstadoSGId_Enabled = 0;
         edtEstadoSGTipo_Enabled = 0;
         edtHistoricoRelacionesApellido_Enabled = 0;
         edtHistoricoRelacionesNombre_Enabled = 0;
         edtHistoricoRelacionesProfesional_Enabled = 0;
         edtHistoricoRelacionesId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_historicorelacionesfechamodifauxdatetext_Jsonclick = "";
         edtavDdo_historicorelacionesfechaaltaauxdatetext_Jsonclick = "";
         edtHistoricoSolicitudesID_Jsonclick = "";
         edtHistoricoSolicitudesID_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "18.0|||||||";
         Ddo_grid_Datalistproc = "HistoricoRelacionesRelacionesWCGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic||";
         Ddo_grid_Includedatalist = "|T|T|T|T|T||";
         Ddo_grid_Filterisrange = "T||||||P|P";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Character|Character|Character|Date|Date";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8";
         Ddo_grid_Columnids = "0:HistoricoRelacionesId|1:HistoricoRelacionesProfesionalesId|2:HistoricoRelacionesNombre|3:HistoricoRelacionesApellido|4:EstadoSGTipo|6:EstadoSGNombre|7:HistoricoRelacionesFechaAlta|8:HistoricoRelacionesFechaModif";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'sPrefix',type:'char'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFHistoricoRelacionesId',fld:'vTFHISTORICORELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV18TFHistoricoRelacionesId_To',fld:'vTFHISTORICORELACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV19TFHistoricoRelacionesProfesionalesId',fld:'vTFHISTORICORELACIONESPROFESIONALESID',pic:'',type:'char'},{av:'AV20TFHistoricoRelacionesProfesionalesId_Sel',fld:'vTFHISTORICORELACIONESPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV21TFHistoricoRelacionesNombre',fld:'vTFHISTORICORELACIONESNOMBRE',pic:'',type:'char'},{av:'AV22TFHistoricoRelacionesNombre_Sel',fld:'vTFHISTORICORELACIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFHistoricoRelacionesApellido',fld:'vTFHISTORICORELACIONESAPELLIDO',pic:'',type:'char'},{av:'AV24TFHistoricoRelacionesApellido_Sel',fld:'vTFHISTORICORELACIONESAPELLIDO_SEL',pic:'',type:'char'},{av:'AV25TFEstadoSGTipo',fld:'vTFESTADOSGTIPO',pic:'',type:'char'},{av:'AV26TFEstadoSGTipo_Sel',fld:'vTFESTADOSGTIPO_SEL',pic:'',type:'char'},{av:'AV27TFEstadoSGNombre',fld:'vTFESTADOSGNOMBRE',pic:'',type:'char'},{av:'AV28TFEstadoSGNombre_Sel',fld:'vTFESTADOSGNOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFHistoricoRelacionesFechaAlta',fld:'vTFHISTORICORELACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV30TFHistoricoRelacionesFechaAlta_To',fld:'vTFHISTORICORELACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV34TFHistoricoRelacionesFechaModif',fld:'vTFHISTORICORELACIONESFECHAMODIF',pic:'99/99/99 99:99',type:'dtime'},{av:'AV35TFHistoricoRelacionesFechaModif_To',fld:'vTFHISTORICORELACIONESFECHAMODIF_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV45IsAuthorized_EstadoSGNombre',fld:'vISAUTHORIZED_ESTADOSGNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E112P2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFHistoricoRelacionesId',fld:'vTFHISTORICORELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV18TFHistoricoRelacionesId_To',fld:'vTFHISTORICORELACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV19TFHistoricoRelacionesProfesionalesId',fld:'vTFHISTORICORELACIONESPROFESIONALESID',pic:'',type:'char'},{av:'AV20TFHistoricoRelacionesProfesionalesId_Sel',fld:'vTFHISTORICORELACIONESPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV21TFHistoricoRelacionesNombre',fld:'vTFHISTORICORELACIONESNOMBRE',pic:'',type:'char'},{av:'AV22TFHistoricoRelacionesNombre_Sel',fld:'vTFHISTORICORELACIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFHistoricoRelacionesApellido',fld:'vTFHISTORICORELACIONESAPELLIDO',pic:'',type:'char'},{av:'AV24TFHistoricoRelacionesApellido_Sel',fld:'vTFHISTORICORELACIONESAPELLIDO_SEL',pic:'',type:'char'},{av:'AV25TFEstadoSGTipo',fld:'vTFESTADOSGTIPO',pic:'',type:'char'},{av:'AV26TFEstadoSGTipo_Sel',fld:'vTFESTADOSGTIPO_SEL',pic:'',type:'char'},{av:'AV27TFEstadoSGNombre',fld:'vTFESTADOSGNOMBRE',pic:'',type:'char'},{av:'AV28TFEstadoSGNombre_Sel',fld:'vTFESTADOSGNOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFHistoricoRelacionesFechaAlta',fld:'vTFHISTORICORELACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV30TFHistoricoRelacionesFechaAlta_To',fld:'vTFHISTORICORELACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV34TFHistoricoRelacionesFechaModif',fld:'vTFHISTORICORELACIONESFECHAMODIF',pic:'99/99/99 99:99',type:'dtime'},{av:'AV35TFHistoricoRelacionesFechaModif_To',fld:'vTFHISTORICORELACIONESFECHAMODIF_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV45IsAuthorized_EstadoSGNombre',fld:'vISAUTHORIZED_ESTADOSGNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E122P2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFHistoricoRelacionesId',fld:'vTFHISTORICORELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV18TFHistoricoRelacionesId_To',fld:'vTFHISTORICORELACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV19TFHistoricoRelacionesProfesionalesId',fld:'vTFHISTORICORELACIONESPROFESIONALESID',pic:'',type:'char'},{av:'AV20TFHistoricoRelacionesProfesionalesId_Sel',fld:'vTFHISTORICORELACIONESPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV21TFHistoricoRelacionesNombre',fld:'vTFHISTORICORELACIONESNOMBRE',pic:'',type:'char'},{av:'AV22TFHistoricoRelacionesNombre_Sel',fld:'vTFHISTORICORELACIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFHistoricoRelacionesApellido',fld:'vTFHISTORICORELACIONESAPELLIDO',pic:'',type:'char'},{av:'AV24TFHistoricoRelacionesApellido_Sel',fld:'vTFHISTORICORELACIONESAPELLIDO_SEL',pic:'',type:'char'},{av:'AV25TFEstadoSGTipo',fld:'vTFESTADOSGTIPO',pic:'',type:'char'},{av:'AV26TFEstadoSGTipo_Sel',fld:'vTFESTADOSGTIPO_SEL',pic:'',type:'char'},{av:'AV27TFEstadoSGNombre',fld:'vTFESTADOSGNOMBRE',pic:'',type:'char'},{av:'AV28TFEstadoSGNombre_Sel',fld:'vTFESTADOSGNOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFHistoricoRelacionesFechaAlta',fld:'vTFHISTORICORELACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV30TFHistoricoRelacionesFechaAlta_To',fld:'vTFHISTORICORELACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV34TFHistoricoRelacionesFechaModif',fld:'vTFHISTORICORELACIONESFECHAMODIF',pic:'99/99/99 99:99',type:'dtime'},{av:'AV35TFHistoricoRelacionesFechaModif_To',fld:'vTFHISTORICORELACIONESFECHAMODIF_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV45IsAuthorized_EstadoSGNombre',fld:'vISAUTHORIZED_ESTADOSGNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E132P2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17TFHistoricoRelacionesId',fld:'vTFHISTORICORELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV18TFHistoricoRelacionesId_To',fld:'vTFHISTORICORELACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV19TFHistoricoRelacionesProfesionalesId',fld:'vTFHISTORICORELACIONESPROFESIONALESID',pic:'',type:'char'},{av:'AV20TFHistoricoRelacionesProfesionalesId_Sel',fld:'vTFHISTORICORELACIONESPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV21TFHistoricoRelacionesNombre',fld:'vTFHISTORICORELACIONESNOMBRE',pic:'',type:'char'},{av:'AV22TFHistoricoRelacionesNombre_Sel',fld:'vTFHISTORICORELACIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFHistoricoRelacionesApellido',fld:'vTFHISTORICORELACIONESAPELLIDO',pic:'',type:'char'},{av:'AV24TFHistoricoRelacionesApellido_Sel',fld:'vTFHISTORICORELACIONESAPELLIDO_SEL',pic:'',type:'char'},{av:'AV25TFEstadoSGTipo',fld:'vTFESTADOSGTIPO',pic:'',type:'char'},{av:'AV26TFEstadoSGTipo_Sel',fld:'vTFESTADOSGTIPO_SEL',pic:'',type:'char'},{av:'AV27TFEstadoSGNombre',fld:'vTFESTADOSGNOMBRE',pic:'',type:'char'},{av:'AV28TFEstadoSGNombre_Sel',fld:'vTFESTADOSGNOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFHistoricoRelacionesFechaAlta',fld:'vTFHISTORICORELACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV30TFHistoricoRelacionesFechaAlta_To',fld:'vTFHISTORICORELACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV34TFHistoricoRelacionesFechaModif',fld:'vTFHISTORICORELACIONESFECHAMODIF',pic:'99/99/99 99:99',type:'dtime'},{av:'AV35TFHistoricoRelacionesFechaModif_To',fld:'vTFHISTORICORELACIONESFECHAMODIF_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV45IsAuthorized_EstadoSGNombre',fld:'vISAUTHORIZED_ESTADOSGNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV34TFHistoricoRelacionesFechaModif',fld:'vTFHISTORICORELACIONESFECHAMODIF',pic:'99/99/99 99:99',type:'dtime'},{av:'AV35TFHistoricoRelacionesFechaModif_To',fld:'vTFHISTORICORELACIONESFECHAMODIF_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV29TFHistoricoRelacionesFechaAlta',fld:'vTFHISTORICORELACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV30TFHistoricoRelacionesFechaAlta_To',fld:'vTFHISTORICORELACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27TFEstadoSGNombre',fld:'vTFESTADOSGNOMBRE',pic:'',type:'char'},{av:'AV28TFEstadoSGNombre_Sel',fld:'vTFESTADOSGNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFEstadoSGTipo',fld:'vTFESTADOSGTIPO',pic:'',type:'char'},{av:'AV26TFEstadoSGTipo_Sel',fld:'vTFESTADOSGTIPO_SEL',pic:'',type:'char'},{av:'AV23TFHistoricoRelacionesApellido',fld:'vTFHISTORICORELACIONESAPELLIDO',pic:'',type:'char'},{av:'AV24TFHistoricoRelacionesApellido_Sel',fld:'vTFHISTORICORELACIONESAPELLIDO_SEL',pic:'',type:'char'},{av:'AV21TFHistoricoRelacionesNombre',fld:'vTFHISTORICORELACIONESNOMBRE',pic:'',type:'char'},{av:'AV22TFHistoricoRelacionesNombre_Sel',fld:'vTFHISTORICORELACIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV19TFHistoricoRelacionesProfesionalesId',fld:'vTFHISTORICORELACIONESPROFESIONALESID',pic:'',type:'char'},{av:'AV20TFHistoricoRelacionesProfesionalesId_Sel',fld:'vTFHISTORICORELACIONESPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV17TFHistoricoRelacionesId',fld:'vTFHISTORICORELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV18TFHistoricoRelacionesId_To',fld:'vTFHISTORICORELACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E162P2',iparms:[{av:'AV45IsAuthorized_EstadoSGNombre',fld:'vISAUTHORIZED_ESTADOSGNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtEstadoSGNombre_Link',ctrl:'ESTADOSGNOMBRE',prop:'Link'}]}");
         setEventMetadata("VALID_ESTADOSGTIPO","{handler:'Valid_Estadosgtipo',iparms:[]");
         setEventMetadata("VALID_ESTADOSGTIPO",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSGID","{handler:'Valid_Estadosgid',iparms:[]");
         setEventMetadata("VALID_ESTADOSGID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Historicorelacionesfechamodif',iparms:[]");
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
         AV19TFHistoricoRelacionesProfesionalesId = "";
         AV20TFHistoricoRelacionesProfesionalesId_Sel = "";
         AV21TFHistoricoRelacionesNombre = "";
         AV22TFHistoricoRelacionesNombre_Sel = "";
         AV23TFHistoricoRelacionesApellido = "";
         AV24TFHistoricoRelacionesApellido_Sel = "";
         AV25TFEstadoSGTipo = "";
         AV26TFEstadoSGTipo_Sel = "";
         AV27TFEstadoSGNombre = "";
         AV28TFEstadoSGNombre_Sel = "";
         AV29TFHistoricoRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         AV30TFHistoricoRelacionesFechaAlta_To = (DateTime)(DateTime.MinValue);
         AV34TFHistoricoRelacionesFechaModif = (DateTime)(DateTime.MinValue);
         AV35TFHistoricoRelacionesFechaModif_To = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV44GridAppliedFilters = "";
         AV39DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV32DDO_HistoricoRelacionesFechaAltaAuxDateTo = DateTime.MinValue;
         AV37DDO_HistoricoRelacionesFechaModifAuxDateTo = DateTime.MinValue;
         AV31DDO_HistoricoRelacionesFechaAltaAuxDate = DateTime.MinValue;
         AV36DDO_HistoricoRelacionesFechaModifAuxDate = DateTime.MinValue;
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
         TempTags = "";
         AV33DDO_HistoricoRelacionesFechaAltaAuxDateText = "";
         ucTfhistoricorelacionesfechaalta_rangepicker = new GXUserControl();
         AV38DDO_HistoricoRelacionesFechaModifAuxDateText = "";
         ucTfhistoricorelacionesfechamodif_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A320HistoricoRelacionesProfesional = "";
         A323HistoricoRelacionesNombre = "";
         A324HistoricoRelacionesApellido = "";
         A141EstadoSGTipo = "";
         A143EstadoSGNombre = "";
         A321HistoricoRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         A322HistoricoRelacionesFechaModif = (DateTime)(DateTime.MinValue);
         GXDecQS = "";
         lV19TFHistoricoRelacionesProfesionalesId = "";
         lV21TFHistoricoRelacionesNombre = "";
         lV23TFHistoricoRelacionesApellido = "";
         lV25TFEstadoSGTipo = "";
         lV27TFEstadoSGNombre = "";
         H002P2_A153HistoricoSolicitudesID = new long[1] ;
         H002P2_A322HistoricoRelacionesFechaModif = new DateTime[] {DateTime.MinValue} ;
         H002P2_A321HistoricoRelacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H002P2_A143EstadoSGNombre = new string[] {""} ;
         H002P2_A142EstadoSGId = new int[1] ;
         H002P2_A141EstadoSGTipo = new string[] {""} ;
         H002P2_A324HistoricoRelacionesApellido = new string[] {""} ;
         H002P2_A323HistoricoRelacionesNombre = new string[] {""} ;
         H002P2_A320HistoricoRelacionesProfesional = new string[] {""} ;
         H002P2_A156HistoricoRelacionesId = new long[1] ;
         H002P3_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV16Session = context.GetSession();
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         sCtrlAV8HistoricoSolicitudesID = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historicorelacionesrelacioneswc__default(),
            new Object[][] {
                new Object[] {
               H002P2_A153HistoricoSolicitudesID, H002P2_A322HistoricoRelacionesFechaModif, H002P2_A321HistoricoRelacionesFechaAlta, H002P2_A143EstadoSGNombre, H002P2_A142EstadoSGId, H002P2_A141EstadoSGTipo, H002P2_A324HistoricoRelacionesApellido, H002P2_A323HistoricoRelacionesNombre, H002P2_A320HistoricoRelacionesProfesional, H002P2_A156HistoricoRelacionesId
               }
               , new Object[] {
               H002P3_AGRID_nRecordCount
               }
            }
         );
         AV46Pgmname = "HistoricoRelacionesRelacionesWC";
         /* GeneXus formulas. */
         AV46Pgmname = "HistoricoRelacionesRelacionesWC";
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
      private int edtHistoricoSolicitudesID_Visible ;
      private int A142EstadoSGId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtHistoricoRelacionesId_Enabled ;
      private int edtHistoricoRelacionesProfesional_Enabled ;
      private int edtHistoricoRelacionesNombre_Enabled ;
      private int edtHistoricoRelacionesApellido_Enabled ;
      private int edtEstadoSGTipo_Enabled ;
      private int edtEstadoSGId_Enabled ;
      private int edtEstadoSGNombre_Enabled ;
      private int edtHistoricoRelacionesFechaAlta_Enabled ;
      private int edtHistoricoRelacionesFechaModif_Enabled ;
      private int edtHistoricoSolicitudesID_Enabled ;
      private int AV41PageToGo ;
      private int AV47GXV1 ;
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
      private long AV17TFHistoricoRelacionesId ;
      private long AV18TFHistoricoRelacionesId_To ;
      private long AV42GridCurrentPage ;
      private long AV43GridPageCount ;
      private long A153HistoricoSolicitudesID ;
      private long A156HistoricoRelacionesId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
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
      private string AV19TFHistoricoRelacionesProfesionalesId ;
      private string AV20TFHistoricoRelacionesProfesionalesId_Sel ;
      private string AV21TFHistoricoRelacionesNombre ;
      private string AV22TFHistoricoRelacionesNombre_Sel ;
      private string AV23TFHistoricoRelacionesApellido ;
      private string AV24TFHistoricoRelacionesApellido_Sel ;
      private string AV25TFEstadoSGTipo ;
      private string AV26TFEstadoSGTipo_Sel ;
      private string AV27TFEstadoSGNombre ;
      private string AV28TFEstadoSGNombre_Sel ;
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
      private string divDdo_historicorelacionesfechaaltaauxdates_Internalname ;
      private string TempTags ;
      private string edtavDdo_historicorelacionesfechaaltaauxdatetext_Internalname ;
      private string edtavDdo_historicorelacionesfechaaltaauxdatetext_Jsonclick ;
      private string Tfhistoricorelacionesfechaalta_rangepicker_Internalname ;
      private string divDdo_historicorelacionesfechamodifauxdates_Internalname ;
      private string edtavDdo_historicorelacionesfechamodifauxdatetext_Internalname ;
      private string edtavDdo_historicorelacionesfechamodifauxdatetext_Jsonclick ;
      private string Tfhistoricorelacionesfechamodif_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtHistoricoRelacionesId_Internalname ;
      private string A320HistoricoRelacionesProfesional ;
      private string edtHistoricoRelacionesProfesional_Internalname ;
      private string A323HistoricoRelacionesNombre ;
      private string edtHistoricoRelacionesNombre_Internalname ;
      private string A324HistoricoRelacionesApellido ;
      private string edtHistoricoRelacionesApellido_Internalname ;
      private string A141EstadoSGTipo ;
      private string edtEstadoSGTipo_Internalname ;
      private string edtEstadoSGId_Internalname ;
      private string A143EstadoSGNombre ;
      private string edtEstadoSGNombre_Internalname ;
      private string edtHistoricoRelacionesFechaAlta_Internalname ;
      private string edtHistoricoRelacionesFechaModif_Internalname ;
      private string GXDecQS ;
      private string lV19TFHistoricoRelacionesProfesionalesId ;
      private string lV21TFHistoricoRelacionesNombre ;
      private string lV23TFHistoricoRelacionesApellido ;
      private string lV25TFEstadoSGTipo ;
      private string lV27TFEstadoSGNombre ;
      private string edtEstadoSGNombre_Link ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string sCtrlAV8HistoricoSolicitudesID ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtHistoricoRelacionesId_Jsonclick ;
      private string edtHistoricoRelacionesProfesional_Jsonclick ;
      private string edtHistoricoRelacionesNombre_Jsonclick ;
      private string edtHistoricoRelacionesApellido_Jsonclick ;
      private string edtEstadoSGTipo_Jsonclick ;
      private string edtEstadoSGId_Jsonclick ;
      private string edtEstadoSGNombre_Jsonclick ;
      private string edtHistoricoRelacionesFechaAlta_Jsonclick ;
      private string edtHistoricoRelacionesFechaModif_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV29TFHistoricoRelacionesFechaAlta ;
      private DateTime AV30TFHistoricoRelacionesFechaAlta_To ;
      private DateTime AV34TFHistoricoRelacionesFechaModif ;
      private DateTime AV35TFHistoricoRelacionesFechaModif_To ;
      private DateTime A321HistoricoRelacionesFechaAlta ;
      private DateTime A322HistoricoRelacionesFechaModif ;
      private DateTime AV32DDO_HistoricoRelacionesFechaAltaAuxDateTo ;
      private DateTime AV37DDO_HistoricoRelacionesFechaModifAuxDateTo ;
      private DateTime AV31DDO_HistoricoRelacionesFechaAltaAuxDate ;
      private DateTime AV36DDO_HistoricoRelacionesFechaModifAuxDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV45IsAuthorized_EstadoSGNombre ;
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
      private string AV44GridAppliedFilters ;
      private string AV33DDO_HistoricoRelacionesFechaAltaAuxDateText ;
      private string AV38DDO_HistoricoRelacionesFechaModifAuxDateText ;
      private IGxSession AV16Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfhistoricorelacionesfechaalta_rangepicker ;
      private GXUserControl ucTfhistoricorelacionesfechamodif_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV9HTTPRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV39DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private long[] H002P2_A153HistoricoSolicitudesID ;
      private DateTime[] H002P2_A322HistoricoRelacionesFechaModif ;
      private DateTime[] H002P2_A321HistoricoRelacionesFechaAlta ;
      private string[] H002P2_A143EstadoSGNombre ;
      private int[] H002P2_A142EstadoSGId ;
      private string[] H002P2_A141EstadoSGTipo ;
      private string[] H002P2_A324HistoricoRelacionesApellido ;
      private string[] H002P2_A323HistoricoRelacionesNombre ;
      private string[] H002P2_A320HistoricoRelacionesProfesional ;
      private long[] H002P2_A156HistoricoRelacionesId ;
      private long[] H002P3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class historicorelacionesrelacioneswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002P2( IGxContext context ,
                                             long AV17TFHistoricoRelacionesId ,
                                             long AV18TFHistoricoRelacionesId_To ,
                                             string AV20TFHistoricoRelacionesProfesionalesId_Sel ,
                                             string AV19TFHistoricoRelacionesProfesionalesId ,
                                             string AV22TFHistoricoRelacionesNombre_Sel ,
                                             string AV21TFHistoricoRelacionesNombre ,
                                             string AV24TFHistoricoRelacionesApellido_Sel ,
                                             string AV23TFHistoricoRelacionesApellido ,
                                             string AV26TFEstadoSGTipo_Sel ,
                                             string AV25TFEstadoSGTipo ,
                                             string AV28TFEstadoSGNombre_Sel ,
                                             string AV27TFEstadoSGNombre ,
                                             DateTime AV29TFHistoricoRelacionesFechaAlta ,
                                             DateTime AV30TFHistoricoRelacionesFechaAlta_To ,
                                             DateTime AV34TFHistoricoRelacionesFechaModif ,
                                             DateTime AV35TFHistoricoRelacionesFechaModif_To ,
                                             long A156HistoricoRelacionesId ,
                                             string A320HistoricoRelacionesProfesional ,
                                             string A323HistoricoRelacionesNombre ,
                                             string A324HistoricoRelacionesApellido ,
                                             string A141EstadoSGTipo ,
                                             string A143EstadoSGNombre ,
                                             DateTime A321HistoricoRelacionesFechaAlta ,
                                             DateTime A322HistoricoRelacionesFechaModif ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             long AV8HistoricoSolicitudesID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[20];
         Object[] GXv_Object9 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesFechaModif], T1.[HistoricoRelacionesFechaAlta], T2.[EstadosGenericosNombre] AS EstadoSGNombre, T1.[EstadoSGId] AS EstadoSGId, T1.[EstadoSGTipo] AS EstadoSGTipo, T1.[HistoricoRelacionesApellido], T1.[HistoricoRelacionesNombre], T1.[HistoricoRelacionesProfesional], T1.[HistoricoRelacionesId]";
         sFromString = " FROM ([HistoricoRelacionesRelaciones] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadoSGTipo] AND T2.[EstadosGenericosId] = T1.[EstadoSGId])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] = @AV8HistoricoSolicitudesID)");
         if ( ! (0==AV17TFHistoricoRelacionesId) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesId] >= @AV17TFHistoricoRelacionesId)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! (0==AV18TFHistoricoRelacionesId_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesId] <= @AV18TFHistoricoRelacionesId_To)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFHistoricoRelacionesProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFHistoricoRelacionesProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesProfesional]) like UPPER(@lV19TFHistoricoRelacionesProfesionalesId))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFHistoricoRelacionesProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV20TFHistoricoRelacionesProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesProfesional] = @AV20TFHistoricoRelacionesProfesionalesId_Sel)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFHistoricoRelacionesProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesProfesional] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHistoricoRelacionesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHistoricoRelacionesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesNombre]) like UPPER(@lV21TFHistoricoRelacionesNombre))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHistoricoRelacionesNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesNombre] = @AV22TFHistoricoRelacionesNombre_Sel)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFHistoricoRelacionesApellido_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFHistoricoRelacionesApellido)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesApellido]) like UPPER(@lV23TFHistoricoRelacionesApellido))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFHistoricoRelacionesApellido_Sel)) && ! ( StringUtil.StrCmp(AV24TFHistoricoRelacionesApellido_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesApellido] = @AV24TFHistoricoRelacionesApellido_Sel)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFHistoricoRelacionesApellido_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesApellido] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFEstadoSGTipo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFEstadoSGTipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[EstadoSGTipo]) like UPPER(@lV25TFEstadoSGTipo))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFEstadoSGTipo_Sel)) && ! ( StringUtil.StrCmp(AV26TFEstadoSGTipo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[EstadoSGTipo] = @AV26TFEstadoSGTipo_Sel)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFEstadoSGTipo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[EstadoSGTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFEstadoSGNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFEstadoSGNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV27TFEstadoSGNombre))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFEstadoSGNombre_Sel)) && ! ( StringUtil.StrCmp(AV28TFEstadoSGNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV28TFEstadoSGNombre_Sel)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFEstadoSGNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         if ( ! (DateTime.MinValue==AV29TFHistoricoRelacionesFechaAlta) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaAlta] >= @AV29TFHistoricoRelacionesFechaAlta)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV30TFHistoricoRelacionesFechaAlta_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaAlta] <= @AV30TFHistoricoRelacionesFechaAlta_To)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV34TFHistoricoRelacionesFechaModif) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaModif] >= @AV34TFHistoricoRelacionesFechaModif)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV35TFHistoricoRelacionesFechaModif_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaModif] <= @AV35TFHistoricoRelacionesFechaModif_To)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoRelacionesId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesProfesional]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoRelacionesProfesional] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesNombre]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoRelacionesNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesApellido]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoRelacionesApellido] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID], T1.[EstadoSGTipo]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[EstadoSGTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID], T2.[EstadosGenericosNombre]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T2.[EstadosGenericosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoRelacionesFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesFechaModif]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoRelacionesFechaModif] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H002P3( IGxContext context ,
                                             long AV17TFHistoricoRelacionesId ,
                                             long AV18TFHistoricoRelacionesId_To ,
                                             string AV20TFHistoricoRelacionesProfesionalesId_Sel ,
                                             string AV19TFHistoricoRelacionesProfesionalesId ,
                                             string AV22TFHistoricoRelacionesNombre_Sel ,
                                             string AV21TFHistoricoRelacionesNombre ,
                                             string AV24TFHistoricoRelacionesApellido_Sel ,
                                             string AV23TFHistoricoRelacionesApellido ,
                                             string AV26TFEstadoSGTipo_Sel ,
                                             string AV25TFEstadoSGTipo ,
                                             string AV28TFEstadoSGNombre_Sel ,
                                             string AV27TFEstadoSGNombre ,
                                             DateTime AV29TFHistoricoRelacionesFechaAlta ,
                                             DateTime AV30TFHistoricoRelacionesFechaAlta_To ,
                                             DateTime AV34TFHistoricoRelacionesFechaModif ,
                                             DateTime AV35TFHistoricoRelacionesFechaModif_To ,
                                             long A156HistoricoRelacionesId ,
                                             string A320HistoricoRelacionesProfesional ,
                                             string A323HistoricoRelacionesNombre ,
                                             string A324HistoricoRelacionesApellido ,
                                             string A141EstadoSGTipo ,
                                             string A143EstadoSGNombre ,
                                             DateTime A321HistoricoRelacionesFechaAlta ,
                                             DateTime A322HistoricoRelacionesFechaModif ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             long AV8HistoricoSolicitudesID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[17];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([HistoricoRelacionesRelaciones] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadoSGTipo] AND T2.[EstadosGenericosId] = T1.[EstadoSGId])";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] = @AV8HistoricoSolicitudesID)");
         if ( ! (0==AV17TFHistoricoRelacionesId) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesId] >= @AV17TFHistoricoRelacionesId)");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( ! (0==AV18TFHistoricoRelacionesId_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesId] <= @AV18TFHistoricoRelacionesId_To)");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFHistoricoRelacionesProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFHistoricoRelacionesProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesProfesional]) like UPPER(@lV19TFHistoricoRelacionesProfesionalesId))");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFHistoricoRelacionesProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV20TFHistoricoRelacionesProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesProfesional] = @AV20TFHistoricoRelacionesProfesionalesId_Sel)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFHistoricoRelacionesProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesProfesional] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHistoricoRelacionesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHistoricoRelacionesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesNombre]) like UPPER(@lV21TFHistoricoRelacionesNombre))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHistoricoRelacionesNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesNombre] = @AV22TFHistoricoRelacionesNombre_Sel)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFHistoricoRelacionesApellido_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFHistoricoRelacionesApellido)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesApellido]) like UPPER(@lV23TFHistoricoRelacionesApellido))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFHistoricoRelacionesApellido_Sel)) && ! ( StringUtil.StrCmp(AV24TFHistoricoRelacionesApellido_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesApellido] = @AV24TFHistoricoRelacionesApellido_Sel)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFHistoricoRelacionesApellido_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesApellido] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFEstadoSGTipo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFEstadoSGTipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[EstadoSGTipo]) like UPPER(@lV25TFEstadoSGTipo))");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFEstadoSGTipo_Sel)) && ! ( StringUtil.StrCmp(AV26TFEstadoSGTipo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[EstadoSGTipo] = @AV26TFEstadoSGTipo_Sel)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFEstadoSGTipo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[EstadoSGTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFEstadoSGNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFEstadoSGNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV27TFEstadoSGNombre))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFEstadoSGNombre_Sel)) && ! ( StringUtil.StrCmp(AV28TFEstadoSGNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV28TFEstadoSGNombre_Sel)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFEstadoSGNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         if ( ! (DateTime.MinValue==AV29TFHistoricoRelacionesFechaAlta) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaAlta] >= @AV29TFHistoricoRelacionesFechaAlta)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV30TFHistoricoRelacionesFechaAlta_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaAlta] <= @AV30TFHistoricoRelacionesFechaAlta_To)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV34TFHistoricoRelacionesFechaModif) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaModif] >= @AV34TFHistoricoRelacionesFechaModif)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV35TFHistoricoRelacionesFechaModif_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaModif] <= @AV35TFHistoricoRelacionesFechaModif_To)");
         }
         else
         {
            GXv_int10[16] = 1;
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
                     return conditional_H002P2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (long)dynConstraints[26] , (long)dynConstraints[27] );
               case 1 :
                     return conditional_H002P3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (long)dynConstraints[26] , (long)dynConstraints[27] );
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
          Object[] prmH002P2;
          prmH002P2 = new Object[] {
          new ParDef("@AV8HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV17TFHistoricoRelacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV18TFHistoricoRelacionesId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV19TFHistoricoRelacionesProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV20TFHistoricoRelacionesProfesionalesId_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV21TFHistoricoRelacionesNombre",GXType.Char,80,0) ,
          new ParDef("@AV22TFHistoricoRelacionesNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV23TFHistoricoRelacionesApellido",GXType.Char,80,0) ,
          new ParDef("@AV24TFHistoricoRelacionesApellido_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV25TFEstadoSGTipo",GXType.Char,3,0) ,
          new ParDef("@AV26TFEstadoSGTipo_Sel",GXType.NChar,3,0) ,
          new ParDef("@lV27TFEstadoSGNombre",GXType.Char,80,0) ,
          new ParDef("@AV28TFEstadoSGNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV29TFHistoricoRelacionesFechaAlta",GXType.DateTime,8,5) ,
          new ParDef("@AV30TFHistoricoRelacionesFechaAlta_To",GXType.DateTime,8,5) ,
          new ParDef("@AV34TFHistoricoRelacionesFechaModif",GXType.DateTime,8,5) ,
          new ParDef("@AV35TFHistoricoRelacionesFechaModif_To",GXType.DateTime,8,5) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002P3;
          prmH002P3 = new Object[] {
          new ParDef("@AV8HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV17TFHistoricoRelacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV18TFHistoricoRelacionesId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV19TFHistoricoRelacionesProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV20TFHistoricoRelacionesProfesionalesId_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV21TFHistoricoRelacionesNombre",GXType.Char,80,0) ,
          new ParDef("@AV22TFHistoricoRelacionesNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV23TFHistoricoRelacionesApellido",GXType.Char,80,0) ,
          new ParDef("@AV24TFHistoricoRelacionesApellido_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV25TFEstadoSGTipo",GXType.Char,3,0) ,
          new ParDef("@AV26TFEstadoSGTipo_Sel",GXType.NChar,3,0) ,
          new ParDef("@lV27TFEstadoSGNombre",GXType.Char,80,0) ,
          new ParDef("@AV28TFEstadoSGNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV29TFHistoricoRelacionesFechaAlta",GXType.DateTime,8,5) ,
          new ParDef("@AV30TFHistoricoRelacionesFechaAlta_To",GXType.DateTime,8,5) ,
          new ParDef("@AV34TFHistoricoRelacionesFechaModif",GXType.DateTime,8,5) ,
          new ParDef("@AV35TFHistoricoRelacionesFechaModif_To",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("H002P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002P2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002P3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002P3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((string[]) buf[6])[0] = rslt.getString(7, 80);
                ((string[]) buf[7])[0] = rslt.getString(8, 80);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
