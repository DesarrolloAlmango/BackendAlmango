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
   public class operacionesid2prompt : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public operacionesid2prompt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacionesid2prompt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_InOutOperacionesId ,
                           out string aP1_OutOperacionesNombreRef )
      {
         this.AV22InOutOperacionesId = aP0_InOutOperacionesId;
         this.AV27OutOperacionesNombreRef = "" ;
         ExecutePrivate();
         aP0_InOutOperacionesId=this.AV22InOutOperacionesId;
         aP1_OutOperacionesNombreRef=this.AV27OutOperacionesNombreRef;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbOperacionesTipo = new GXCombobox();
         cmbOperacionesTipoES = new GXCombobox();
         cmbOperacionesEstado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "InOutOperacionesId");
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
               gxfirstwebparm = GetFirstPar( "InOutOperacionesId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "InOutOperacionesId");
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV22InOutOperacionesId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22InOutOperacionesId", StringUtil.LTrimStr( (decimal)(AV22InOutOperacionesId), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV27OutOperacionesNombreRef = GetPar( "OutOperacionesNombreRef");
                  AssignAttri("", false, "AV27OutOperacionesNombreRef", AV27OutOperacionesNombreRef);
               }
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
         nRC_GXsfl_26 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_26"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_26_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_26_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_26_idx = GetPar( "sGXsfl_26_idx");
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
         AV24OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV25OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV15FilterFullText = GetPar( "FilterFullText");
         AV54Pgmname = GetPar( "Pgmname");
         AV39TFOperacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFOperacionesId"), "."), 18, MidpointRounding.ToEven));
         AV40TFOperacionesId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFOperacionesId_To"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV49TFOperacionesTipo_Sels);
         AV47TFOperacionesRef = GetPar( "TFOperacionesRef");
         AV48TFOperacionesRef_Sel = GetPar( "TFOperacionesRef_Sel");
         AV45TFOperacionesNombreRef = GetPar( "TFOperacionesNombreRef");
         AV46TFOperacionesNombreRef_Sel = GetPar( "TFOperacionesNombreRef_Sel");
         AV41TFOperacionesImporte = NumberUtil.Val( GetPar( "TFOperacionesImporte"), ".");
         AV42TFOperacionesImporte_To = NumberUtil.Val( GetPar( "TFOperacionesImporte_To"), ".");
         AV43TFOperacionesMoneda = GetPar( "TFOperacionesMoneda");
         AV44TFOperacionesMoneda_Sel = GetPar( "TFOperacionesMoneda_Sel");
         AV33TFOperacionesFechaAlta = context.localUtil.ParseDateParm( GetPar( "TFOperacionesFechaAlta"));
         AV34TFOperacionesFechaAlta_To = context.localUtil.ParseDateParm( GetPar( "TFOperacionesFechaAlta_To"));
         AV35TFOperacionesFechaDesde = context.localUtil.ParseDateParm( GetPar( "TFOperacionesFechaDesde"));
         AV36TFOperacionesFechaDesde_To = context.localUtil.ParseDateParm( GetPar( "TFOperacionesFechaDesde_To"));
         AV37TFOperacionesFechaHasta = context.localUtil.ParseDateParm( GetPar( "TFOperacionesFechaHasta"));
         AV38TFOperacionesFechaHasta_To = context.localUtil.ParseDateParm( GetPar( "TFOperacionesFechaHasta_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV31TFOperacionesEstado_Sels);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV24OrderedBy, AV25OrderedDsc, AV15FilterFullText, AV54Pgmname, AV39TFOperacionesId, AV40TFOperacionesId_To, AV49TFOperacionesTipo_Sels, AV47TFOperacionesRef, AV48TFOperacionesRef_Sel, AV45TFOperacionesNombreRef, AV46TFOperacionesNombreRef_Sel, AV41TFOperacionesImporte, AV42TFOperacionesImporte_To, AV43TFOperacionesMoneda, AV44TFOperacionesMoneda_Sel, AV33TFOperacionesFechaAlta, AV34TFOperacionesFechaAlta_To, AV35TFOperacionesFechaDesde, AV36TFOperacionesFechaDesde_To, AV37TFOperacionesFechaHasta, AV38TFOperacionesFechaHasta_To, AV31TFOperacionesEstado_Sels) ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageprompt", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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
         PADM2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTDM2( ) ;
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("operacionesid2prompt.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV22InOutOperacionesId,18,0)),UrlEncode(StringUtil.RTrim(AV27OutOperacionesNombreRef))}, new string[] {"InOutOperacionesId","OutOperacionesNombreRef"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV25OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV15FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_26", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_26), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV16GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_OPERACIONESFECHAALTAAUXDATETO", context.localUtil.DToC( AV7DDO_OperacionesFechaAltaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_OPERACIONESFECHADESDEAUXDATETO", context.localUtil.DToC( AV10DDO_OperacionesFechaDesdeAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_OPERACIONESFECHAHASTAAUXDATETO", context.localUtil.DToC( AV13DDO_OperacionesFechaHastaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV25OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39TFOperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40TFOperacionesId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFOPERACIONESTIPO_SELS", AV49TFOperacionesTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFOPERACIONESTIPO_SELS", AV49TFOperacionesTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESREF", StringUtil.RTrim( AV47TFOperacionesRef));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESREF_SEL", StringUtil.RTrim( AV48TFOperacionesRef_Sel));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESNOMBREREF", StringUtil.RTrim( AV45TFOperacionesNombreRef));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESNOMBREREF_SEL", StringUtil.RTrim( AV46TFOperacionesNombreRef_Sel));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESIMPORTE", StringUtil.LTrim( StringUtil.NToC( AV41TFOperacionesImporte, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESIMPORTE_TO", StringUtil.LTrim( StringUtil.NToC( AV42TFOperacionesImporte_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESMONEDA", StringUtil.RTrim( AV43TFOperacionesMoneda));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESMONEDA_SEL", StringUtil.RTrim( AV44TFOperacionesMoneda_Sel));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESFECHAALTA", context.localUtil.DToC( AV33TFOperacionesFechaAlta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESFECHAALTA_TO", context.localUtil.DToC( AV34TFOperacionesFechaAlta_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESFECHADESDE", context.localUtil.DToC( AV35TFOperacionesFechaDesde, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESFECHADESDE_TO", context.localUtil.DToC( AV36TFOperacionesFechaDesde_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESFECHAHASTA", context.localUtil.DToC( AV37TFOperacionesFechaHasta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESFECHAHASTA_TO", context.localUtil.DToC( AV38TFOperacionesFechaHasta_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFOPERACIONESESTADO_SELS", AV31TFOperacionesEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFOPERACIONESESTADO_SELS", AV31TFOperacionesEstado_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vINOUTOPERACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22InOutOperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vOUTOPERACIONESNOMBREREF", StringUtil.RTrim( AV27OutOperacionesNombreRef));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vDDO_OPERACIONESFECHAALTAAUXDATE", context.localUtil.DToC( AV5DDO_OperacionesFechaAltaAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_OPERACIONESFECHADESDEAUXDATE", context.localUtil.DToC( AV8DDO_OperacionesFechaDesdeAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_OPERACIONESFECHAHASTAAUXDATE", context.localUtil.DToC( AV11DDO_OperacionesFechaHastaAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WEDM2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTDM2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("operacionesid2prompt.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV22InOutOperacionesId,18,0)),UrlEncode(StringUtil.RTrim(AV27OutOperacionesNombreRef))}, new string[] {"InOutOperacionesId","OutOperacionesNombreRef"})  ;
      }

      public override string GetPgmname( )
      {
         return "OperacionesId2Prompt" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Operaciones Id2 Prompt", "") ;
      }

      protected void WBDM0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainPrompt", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs", "start", "top", "", "", "div");
            wb_table1_14_DM2( true) ;
         }
         else
         {
            wb_table1_14_DM2( false) ;
         }
         return  ;
      }

      protected void wb_table1_14_DM2e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginLeft15 CellMarginBottom15 GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl26( ) ;
         }
         if ( wbEnd == 26 )
         {
            wbEnd = 0;
            nRC_GXsfl_26 = (int)(nGXsfl_26_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV17GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV18GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV16GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_operacionesfechaaltaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_26_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacionesfechaaltaauxdatetext_Internalname, AV6DDO_OperacionesFechaAltaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV6DDO_OperacionesFechaAltaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacionesfechaaltaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_OperacionesId2Prompt.htm");
            /* User Defined Control */
            ucTfoperacionesfechaalta_rangepicker.SetProperty("Start Date", AV5DDO_OperacionesFechaAltaAuxDate);
            ucTfoperacionesfechaalta_rangepicker.SetProperty("End Date", AV7DDO_OperacionesFechaAltaAuxDateTo);
            ucTfoperacionesfechaalta_rangepicker.Render(context, "wwp.daterangepicker", Tfoperacionesfechaalta_rangepicker_Internalname, "TFOPERACIONESFECHAALTA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_operacionesfechadesdeauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_26_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacionesfechadesdeauxdatetext_Internalname, AV9DDO_OperacionesFechaDesdeAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV9DDO_OperacionesFechaDesdeAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacionesfechadesdeauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_OperacionesId2Prompt.htm");
            /* User Defined Control */
            ucTfoperacionesfechadesde_rangepicker.SetProperty("Start Date", AV8DDO_OperacionesFechaDesdeAuxDate);
            ucTfoperacionesfechadesde_rangepicker.SetProperty("End Date", AV10DDO_OperacionesFechaDesdeAuxDateTo);
            ucTfoperacionesfechadesde_rangepicker.Render(context, "wwp.daterangepicker", Tfoperacionesfechadesde_rangepicker_Internalname, "TFOPERACIONESFECHADESDE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_operacionesfechahastaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_26_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacionesfechahastaauxdatetext_Internalname, AV12DDO_OperacionesFechaHastaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV12DDO_OperacionesFechaHastaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacionesfechahastaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_OperacionesId2Prompt.htm");
            /* User Defined Control */
            ucTfoperacionesfechahasta_rangepicker.SetProperty("Start Date", AV11DDO_OperacionesFechaHastaAuxDate);
            ucTfoperacionesfechahasta_rangepicker.SetProperty("End Date", AV13DDO_OperacionesFechaHastaAuxDateTo);
            ucTfoperacionesfechahasta_rangepicker.Render(context, "wwp.daterangepicker", Tfoperacionesfechahasta_rangepicker_Internalname, "TFOPERACIONESFECHAHASTA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 26 )
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

      protected void STARTDM2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Operaciones Id2 Prompt", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPDM0( ) ;
      }

      protected void WSDM2( )
      {
         STARTDM2( ) ;
         EVTDM2( ) ;
      }

      protected void EVTDM2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E11DM2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E12DM2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E13DM2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCLEANFILTERS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCleanFilters' */
                              E14DM2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_26_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
                              SubsflControlProps_262( ) ;
                              AV30Select = cgiGet( edtavSelect_Internalname);
                              AssignAttri("", false, edtavSelect_Internalname, AV30Select);
                              A554OperacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbOperacionesTipo.Name = cmbOperacionesTipo_Internalname;
                              cmbOperacionesTipo.CurrentValue = cgiGet( cmbOperacionesTipo_Internalname);
                              A649OperacionesTipo = cgiGet( cmbOperacionesTipo_Internalname);
                              n649OperacionesTipo = false;
                              A555OperacionesRef = cgiGet( edtOperacionesRef_Internalname);
                              n555OperacionesRef = false;
                              A657OperacionesNombreRef = cgiGet( edtOperacionesNombreRef_Internalname);
                              n657OperacionesNombreRef = false;
                              A579OperacionesOrdinal = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesOrdinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n579OperacionesOrdinal = false;
                              A586OperacionesIDORD = cgiGet( edtOperacionesIDORD_Internalname);
                              n586OperacionesIDORD = false;
                              cmbOperacionesTipoES.Name = cmbOperacionesTipoES_Internalname;
                              cmbOperacionesTipoES.CurrentValue = cgiGet( cmbOperacionesTipoES_Internalname);
                              A569OperacionesTipoES = cgiGet( cmbOperacionesTipoES_Internalname);
                              n569OperacionesTipoES = false;
                              A570OperacionesImporte = context.localUtil.CToN( cgiGet( edtOperacionesImporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n570OperacionesImporte = false;
                              A662OperacionesMonId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesMonId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n662OperacionesMonId = false;
                              A571OperacionesMoneda = cgiGet( edtOperacionesMoneda_Internalname);
                              n571OperacionesMoneda = false;
                              A572OperacionesFacturaCod = cgiGet( edtOperacionesFacturaCod_Internalname);
                              n572OperacionesFacturaCod = false;
                              A573OperacionesIva = context.localUtil.CToN( cgiGet( edtOperacionesIva_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n573OperacionesIva = false;
                              A574OperacionesComision = context.localUtil.CToN( cgiGet( edtOperacionesComision_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n574OperacionesComision = false;
                              A578OperacionesImporteGrabado = context.localUtil.CToN( cgiGet( edtOperacionesImporteGrabado_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n578OperacionesImporteGrabado = false;
                              A575OperacionesRequest = cgiGet( edtOperacionesRequest_Internalname);
                              n575OperacionesRequest = false;
                              A576OperacionesResponse = cgiGet( edtOperacionesResponse_Internalname);
                              n576OperacionesResponse = false;
                              A580OperacionesComprobantePago = cgiGet( edtOperacionesComprobantePago_Internalname);
                              n580OperacionesComprobantePago = false;
                              A581OperacionesFechaAlta = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtOperacionesFechaAlta_Internalname), 0));
                              n581OperacionesFechaAlta = false;
                              A582OperacionesFechaPago = context.localUtil.CToT( cgiGet( edtOperacionesFechaPago_Internalname), 0);
                              n582OperacionesFechaPago = false;
                              A583OperacionesAux1 = cgiGet( edtOperacionesAux1_Internalname);
                              n583OperacionesAux1 = false;
                              A584OperacionesAux2 = cgiGet( edtOperacionesAux2_Internalname);
                              n584OperacionesAux2 = false;
                              A585OperacionesAux3 = cgiGet( edtOperacionesAux3_Internalname);
                              n585OperacionesAux3 = false;
                              A658OperacionesFechaDesde = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtOperacionesFechaDesde_Internalname), 0));
                              n658OperacionesFechaDesde = false;
                              A659OperacionesFechaHasta = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtOperacionesFechaHasta_Internalname), 0));
                              n659OperacionesFechaHasta = false;
                              cmbOperacionesEstado.Name = cmbOperacionesEstado_Internalname;
                              cmbOperacionesEstado.CurrentValue = cgiGet( cmbOperacionesEstado_Internalname);
                              A577OperacionesEstado = cgiGet( cmbOperacionesEstado_Internalname);
                              n577OperacionesEstado = false;
                              A663OperacionesBlob1 = cgiGet( edtOperacionesBlob1_Internalname);
                              n663OperacionesBlob1 = false;
                              AssignProp("", false, edtOperacionesBlob1_Internalname, "URL", context.PathToRelativeUrl( A663OperacionesBlob1), !bGXsfl_26_Refreshing);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E15DM2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E16DM2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E17DM2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV24OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV25OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E18DM2 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WEDM2( )
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

      protected void PADM2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
         SubsflControlProps_262( ) ;
         while ( nGXsfl_26_idx <= nRC_GXsfl_26 )
         {
            sendrow_262( ) ;
            nGXsfl_26_idx = ((subGrid_Islastpage==1)&&(nGXsfl_26_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_26_idx+1);
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV24OrderedBy ,
                                       bool AV25OrderedDsc ,
                                       string AV15FilterFullText ,
                                       string AV54Pgmname ,
                                       long AV39TFOperacionesId ,
                                       long AV40TFOperacionesId_To ,
                                       GxSimpleCollection<string> AV49TFOperacionesTipo_Sels ,
                                       string AV47TFOperacionesRef ,
                                       string AV48TFOperacionesRef_Sel ,
                                       string AV45TFOperacionesNombreRef ,
                                       string AV46TFOperacionesNombreRef_Sel ,
                                       decimal AV41TFOperacionesImporte ,
                                       decimal AV42TFOperacionesImporte_To ,
                                       string AV43TFOperacionesMoneda ,
                                       string AV44TFOperacionesMoneda_Sel ,
                                       DateTime AV33TFOperacionesFechaAlta ,
                                       DateTime AV34TFOperacionesFechaAlta_To ,
                                       DateTime AV35TFOperacionesFechaDesde ,
                                       DateTime AV36TFOperacionesFechaDesde_To ,
                                       DateTime AV37TFOperacionesFechaHasta ,
                                       DateTime AV38TFOperacionesFechaHasta_To ,
                                       GxSimpleCollection<string> AV31TFOperacionesEstado_Sels )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFDM2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_OPERACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A554OperacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "OPERACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A554OperacionesId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_OPERACIONESNOMBREREF", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A657OperacionesNombreRef, "")), context));
         GxWebStd.gx_hidden_field( context, "OPERACIONESNOMBREREF", StringUtil.RTrim( A657OperacionesNombreRef));
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
         RFDM2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV54Pgmname = "OperacionesId2Prompt";
         edtavSelect_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A649OperacionesTipo ,
                                              AV49TFOperacionesTipo_Sels ,
                                              A577OperacionesEstado ,
                                              AV31TFOperacionesEstado_Sels ,
                                              AV39TFOperacionesId ,
                                              AV40TFOperacionesId_To ,
                                              AV49TFOperacionesTipo_Sels.Count ,
                                              AV48TFOperacionesRef_Sel ,
                                              AV47TFOperacionesRef ,
                                              AV46TFOperacionesNombreRef_Sel ,
                                              AV45TFOperacionesNombreRef ,
                                              AV41TFOperacionesImporte ,
                                              AV42TFOperacionesImporte_To ,
                                              AV44TFOperacionesMoneda_Sel ,
                                              AV43TFOperacionesMoneda ,
                                              AV33TFOperacionesFechaAlta ,
                                              AV34TFOperacionesFechaAlta_To ,
                                              AV35TFOperacionesFechaDesde ,
                                              AV36TFOperacionesFechaDesde_To ,
                                              AV37TFOperacionesFechaHasta ,
                                              AV38TFOperacionesFechaHasta_To ,
                                              AV31TFOperacionesEstado_Sels.Count ,
                                              A554OperacionesId ,
                                              A555OperacionesRef ,
                                              A657OperacionesNombreRef ,
                                              A570OperacionesImporte ,
                                              A571OperacionesMoneda ,
                                              A581OperacionesFechaAlta ,
                                              A658OperacionesFechaDesde ,
                                              A659OperacionesFechaHasta ,
                                              AV24OrderedBy ,
                                              AV25OrderedDsc ,
                                              AV15FilterFullText } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV47TFOperacionesRef = StringUtil.PadR( StringUtil.RTrim( AV47TFOperacionesRef), 25, "%");
         lV45TFOperacionesNombreRef = StringUtil.PadR( StringUtil.RTrim( AV45TFOperacionesNombreRef), 120, "%");
         lV43TFOperacionesMoneda = StringUtil.PadR( StringUtil.RTrim( AV43TFOperacionesMoneda), 3, "%");
         /* Using cursor H00DM2 */
         pr_default.execute(0, new Object[] {AV39TFOperacionesId, AV40TFOperacionesId_To, lV47TFOperacionesRef, AV48TFOperacionesRef_Sel, lV45TFOperacionesNombreRef, AV46TFOperacionesNombreRef_Sel, AV41TFOperacionesImporte, AV42TFOperacionesImporte_To, lV43TFOperacionesMoneda, AV44TFOperacionesMoneda_Sel, AV33TFOperacionesFechaAlta, AV34TFOperacionesFechaAlta_To, AV35TFOperacionesFechaDesde, AV36TFOperacionesFechaDesde_To, AV37TFOperacionesFechaHasta, AV38TFOperacionesFechaHasta_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A577OperacionesEstado = H00DM2_A577OperacionesEstado[0];
            n577OperacionesEstado = H00DM2_n577OperacionesEstado[0];
            A659OperacionesFechaHasta = H00DM2_A659OperacionesFechaHasta[0];
            n659OperacionesFechaHasta = H00DM2_n659OperacionesFechaHasta[0];
            A658OperacionesFechaDesde = H00DM2_A658OperacionesFechaDesde[0];
            n658OperacionesFechaDesde = H00DM2_n658OperacionesFechaDesde[0];
            A585OperacionesAux3 = H00DM2_A585OperacionesAux3[0];
            n585OperacionesAux3 = H00DM2_n585OperacionesAux3[0];
            A584OperacionesAux2 = H00DM2_A584OperacionesAux2[0];
            n584OperacionesAux2 = H00DM2_n584OperacionesAux2[0];
            A583OperacionesAux1 = H00DM2_A583OperacionesAux1[0];
            n583OperacionesAux1 = H00DM2_n583OperacionesAux1[0];
            A582OperacionesFechaPago = H00DM2_A582OperacionesFechaPago[0];
            n582OperacionesFechaPago = H00DM2_n582OperacionesFechaPago[0];
            A581OperacionesFechaAlta = H00DM2_A581OperacionesFechaAlta[0];
            n581OperacionesFechaAlta = H00DM2_n581OperacionesFechaAlta[0];
            A580OperacionesComprobantePago = H00DM2_A580OperacionesComprobantePago[0];
            n580OperacionesComprobantePago = H00DM2_n580OperacionesComprobantePago[0];
            A576OperacionesResponse = H00DM2_A576OperacionesResponse[0];
            n576OperacionesResponse = H00DM2_n576OperacionesResponse[0];
            A575OperacionesRequest = H00DM2_A575OperacionesRequest[0];
            n575OperacionesRequest = H00DM2_n575OperacionesRequest[0];
            A578OperacionesImporteGrabado = H00DM2_A578OperacionesImporteGrabado[0];
            n578OperacionesImporteGrabado = H00DM2_n578OperacionesImporteGrabado[0];
            A574OperacionesComision = H00DM2_A574OperacionesComision[0];
            n574OperacionesComision = H00DM2_n574OperacionesComision[0];
            A573OperacionesIva = H00DM2_A573OperacionesIva[0];
            n573OperacionesIva = H00DM2_n573OperacionesIva[0];
            A572OperacionesFacturaCod = H00DM2_A572OperacionesFacturaCod[0];
            n572OperacionesFacturaCod = H00DM2_n572OperacionesFacturaCod[0];
            A571OperacionesMoneda = H00DM2_A571OperacionesMoneda[0];
            n571OperacionesMoneda = H00DM2_n571OperacionesMoneda[0];
            A662OperacionesMonId = H00DM2_A662OperacionesMonId[0];
            n662OperacionesMonId = H00DM2_n662OperacionesMonId[0];
            A570OperacionesImporte = H00DM2_A570OperacionesImporte[0];
            n570OperacionesImporte = H00DM2_n570OperacionesImporte[0];
            A569OperacionesTipoES = H00DM2_A569OperacionesTipoES[0];
            n569OperacionesTipoES = H00DM2_n569OperacionesTipoES[0];
            A586OperacionesIDORD = H00DM2_A586OperacionesIDORD[0];
            n586OperacionesIDORD = H00DM2_n586OperacionesIDORD[0];
            A579OperacionesOrdinal = H00DM2_A579OperacionesOrdinal[0];
            n579OperacionesOrdinal = H00DM2_n579OperacionesOrdinal[0];
            A657OperacionesNombreRef = H00DM2_A657OperacionesNombreRef[0];
            n657OperacionesNombreRef = H00DM2_n657OperacionesNombreRef[0];
            A555OperacionesRef = H00DM2_A555OperacionesRef[0];
            n555OperacionesRef = H00DM2_n555OperacionesRef[0];
            A649OperacionesTipo = H00DM2_A649OperacionesTipo[0];
            n649OperacionesTipo = H00DM2_n649OperacionesTipo[0];
            A554OperacionesId = H00DM2_A554OperacionesId[0];
            A663OperacionesBlob1 = H00DM2_A663OperacionesBlob1[0];
            n663OperacionesBlob1 = H00DM2_n663OperacionesBlob1[0];
            AssignProp("", false, edtOperacionesBlob1_Internalname, "URL", context.PathToRelativeUrl( A663OperacionesBlob1), !bGXsfl_26_Refreshing);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A554OperacionesId), 18, 0) , StringUtil.PadR( "%" + AV15FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "liquidación de solicitudes del profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "LSF") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "liquidación de  solicitudes comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSC") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro de liquidación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "COL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pago de liquidación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "POL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro de solicitud", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CSO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "nota de credito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "NCR") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "nota de debito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "NDE") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "OTR") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A555OperacionesRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV15FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A657OperacionesNombreRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV15FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A570OperacionesImporte, 18, 2) , StringUtil.PadR( "%" + AV15FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A571OperacionesMoneda) , StringUtil.PadR( "%" + StringUtil.Upper( AV15FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PRO") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PND") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "ANU") == 0 ) ) )
            )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RFDM2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 26;
         /* Execute user event: Refresh */
         E16DM2 ();
         nGXsfl_26_idx = 1;
         sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
         SubsflControlProps_262( ) ;
         bGXsfl_26_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
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
            SubsflControlProps_262( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A649OperacionesTipo ,
                                                 AV49TFOperacionesTipo_Sels ,
                                                 A577OperacionesEstado ,
                                                 AV31TFOperacionesEstado_Sels ,
                                                 AV39TFOperacionesId ,
                                                 AV40TFOperacionesId_To ,
                                                 AV49TFOperacionesTipo_Sels.Count ,
                                                 AV48TFOperacionesRef_Sel ,
                                                 AV47TFOperacionesRef ,
                                                 AV46TFOperacionesNombreRef_Sel ,
                                                 AV45TFOperacionesNombreRef ,
                                                 AV41TFOperacionesImporte ,
                                                 AV42TFOperacionesImporte_To ,
                                                 AV44TFOperacionesMoneda_Sel ,
                                                 AV43TFOperacionesMoneda ,
                                                 AV33TFOperacionesFechaAlta ,
                                                 AV34TFOperacionesFechaAlta_To ,
                                                 AV35TFOperacionesFechaDesde ,
                                                 AV36TFOperacionesFechaDesde_To ,
                                                 AV37TFOperacionesFechaHasta ,
                                                 AV38TFOperacionesFechaHasta_To ,
                                                 AV31TFOperacionesEstado_Sels.Count ,
                                                 A554OperacionesId ,
                                                 A555OperacionesRef ,
                                                 A657OperacionesNombreRef ,
                                                 A570OperacionesImporte ,
                                                 A571OperacionesMoneda ,
                                                 A581OperacionesFechaAlta ,
                                                 A658OperacionesFechaDesde ,
                                                 A659OperacionesFechaHasta ,
                                                 AV24OrderedBy ,
                                                 AV25OrderedDsc ,
                                                 AV15FilterFullText } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV47TFOperacionesRef = StringUtil.PadR( StringUtil.RTrim( AV47TFOperacionesRef), 25, "%");
            lV45TFOperacionesNombreRef = StringUtil.PadR( StringUtil.RTrim( AV45TFOperacionesNombreRef), 120, "%");
            lV43TFOperacionesMoneda = StringUtil.PadR( StringUtil.RTrim( AV43TFOperacionesMoneda), 3, "%");
            /* Using cursor H00DM3 */
            pr_default.execute(1, new Object[] {AV39TFOperacionesId, AV40TFOperacionesId_To, lV47TFOperacionesRef, AV48TFOperacionesRef_Sel, lV45TFOperacionesNombreRef, AV46TFOperacionesNombreRef_Sel, AV41TFOperacionesImporte, AV42TFOperacionesImporte_To, lV43TFOperacionesMoneda, AV44TFOperacionesMoneda_Sel, AV33TFOperacionesFechaAlta, AV34TFOperacionesFechaAlta_To, AV35TFOperacionesFechaDesde, AV36TFOperacionesFechaDesde_To, AV37TFOperacionesFechaHasta, AV38TFOperacionesFechaHasta_To});
            nGXsfl_26_idx = 1;
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A577OperacionesEstado = H00DM3_A577OperacionesEstado[0];
               n577OperacionesEstado = H00DM3_n577OperacionesEstado[0];
               A659OperacionesFechaHasta = H00DM3_A659OperacionesFechaHasta[0];
               n659OperacionesFechaHasta = H00DM3_n659OperacionesFechaHasta[0];
               A658OperacionesFechaDesde = H00DM3_A658OperacionesFechaDesde[0];
               n658OperacionesFechaDesde = H00DM3_n658OperacionesFechaDesde[0];
               A585OperacionesAux3 = H00DM3_A585OperacionesAux3[0];
               n585OperacionesAux3 = H00DM3_n585OperacionesAux3[0];
               A584OperacionesAux2 = H00DM3_A584OperacionesAux2[0];
               n584OperacionesAux2 = H00DM3_n584OperacionesAux2[0];
               A583OperacionesAux1 = H00DM3_A583OperacionesAux1[0];
               n583OperacionesAux1 = H00DM3_n583OperacionesAux1[0];
               A582OperacionesFechaPago = H00DM3_A582OperacionesFechaPago[0];
               n582OperacionesFechaPago = H00DM3_n582OperacionesFechaPago[0];
               A581OperacionesFechaAlta = H00DM3_A581OperacionesFechaAlta[0];
               n581OperacionesFechaAlta = H00DM3_n581OperacionesFechaAlta[0];
               A580OperacionesComprobantePago = H00DM3_A580OperacionesComprobantePago[0];
               n580OperacionesComprobantePago = H00DM3_n580OperacionesComprobantePago[0];
               A576OperacionesResponse = H00DM3_A576OperacionesResponse[0];
               n576OperacionesResponse = H00DM3_n576OperacionesResponse[0];
               A575OperacionesRequest = H00DM3_A575OperacionesRequest[0];
               n575OperacionesRequest = H00DM3_n575OperacionesRequest[0];
               A578OperacionesImporteGrabado = H00DM3_A578OperacionesImporteGrabado[0];
               n578OperacionesImporteGrabado = H00DM3_n578OperacionesImporteGrabado[0];
               A574OperacionesComision = H00DM3_A574OperacionesComision[0];
               n574OperacionesComision = H00DM3_n574OperacionesComision[0];
               A573OperacionesIva = H00DM3_A573OperacionesIva[0];
               n573OperacionesIva = H00DM3_n573OperacionesIva[0];
               A572OperacionesFacturaCod = H00DM3_A572OperacionesFacturaCod[0];
               n572OperacionesFacturaCod = H00DM3_n572OperacionesFacturaCod[0];
               A571OperacionesMoneda = H00DM3_A571OperacionesMoneda[0];
               n571OperacionesMoneda = H00DM3_n571OperacionesMoneda[0];
               A662OperacionesMonId = H00DM3_A662OperacionesMonId[0];
               n662OperacionesMonId = H00DM3_n662OperacionesMonId[0];
               A570OperacionesImporte = H00DM3_A570OperacionesImporte[0];
               n570OperacionesImporte = H00DM3_n570OperacionesImporte[0];
               A569OperacionesTipoES = H00DM3_A569OperacionesTipoES[0];
               n569OperacionesTipoES = H00DM3_n569OperacionesTipoES[0];
               A586OperacionesIDORD = H00DM3_A586OperacionesIDORD[0];
               n586OperacionesIDORD = H00DM3_n586OperacionesIDORD[0];
               A579OperacionesOrdinal = H00DM3_A579OperacionesOrdinal[0];
               n579OperacionesOrdinal = H00DM3_n579OperacionesOrdinal[0];
               A657OperacionesNombreRef = H00DM3_A657OperacionesNombreRef[0];
               n657OperacionesNombreRef = H00DM3_n657OperacionesNombreRef[0];
               A555OperacionesRef = H00DM3_A555OperacionesRef[0];
               n555OperacionesRef = H00DM3_n555OperacionesRef[0];
               A649OperacionesTipo = H00DM3_A649OperacionesTipo[0];
               n649OperacionesTipo = H00DM3_n649OperacionesTipo[0];
               A554OperacionesId = H00DM3_A554OperacionesId[0];
               A663OperacionesBlob1 = H00DM3_A663OperacionesBlob1[0];
               n663OperacionesBlob1 = H00DM3_n663OperacionesBlob1[0];
               AssignProp("", false, edtOperacionesBlob1_Internalname, "URL", context.PathToRelativeUrl( A663OperacionesBlob1), !bGXsfl_26_Refreshing);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A554OperacionesId), 18, 0) , StringUtil.PadR( "%" + AV15FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "liquidación de solicitudes del profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A649OperacionesTipo, "LSF") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "liquidación de  solicitudes comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSC") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "cobro de liquidación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "COL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pago de liquidación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A649OperacionesTipo, "POL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro de solicitud", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CSO") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "nota de credito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "NCR") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "nota de debito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A649OperacionesTipo, "NDE") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "OTR") == 0 ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A555OperacionesRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV15FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A657OperacionesNombreRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV15FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( A570OperacionesImporte, 18, 2) , StringUtil.PadR( "%" + AV15FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A571OperacionesMoneda) , StringUtil.PadR( "%" + StringUtil.Upper( AV15FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PRO") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PND") ==
               0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV15FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "ANU") == 0 ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E17DM2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 26;
            WBDM0( ) ;
         }
         bGXsfl_26_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesDM2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_OPERACIONESID"+"_"+sGXsfl_26_idx, GetSecureSignedToken( sGXsfl_26_idx, context.localUtil.Format( (decimal)(A554OperacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_OPERACIONESNOMBREREF"+"_"+sGXsfl_26_idx, GetSecureSignedToken( sGXsfl_26_idx, StringUtil.RTrim( context.localUtil.Format( A657OperacionesNombreRef, "")), context));
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV24OrderedBy, AV25OrderedDsc, AV15FilterFullText, AV54Pgmname, AV39TFOperacionesId, AV40TFOperacionesId_To, AV49TFOperacionesTipo_Sels, AV47TFOperacionesRef, AV48TFOperacionesRef_Sel, AV45TFOperacionesNombreRef, AV46TFOperacionesNombreRef_Sel, AV41TFOperacionesImporte, AV42TFOperacionesImporte_To, AV43TFOperacionesMoneda, AV44TFOperacionesMoneda_Sel, AV33TFOperacionesFechaAlta, AV34TFOperacionesFechaAlta_To, AV35TFOperacionesFechaDesde, AV36TFOperacionesFechaDesde_To, AV37TFOperacionesFechaHasta, AV38TFOperacionesFechaHasta_To, AV31TFOperacionesEstado_Sels) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV24OrderedBy, AV25OrderedDsc, AV15FilterFullText, AV54Pgmname, AV39TFOperacionesId, AV40TFOperacionesId_To, AV49TFOperacionesTipo_Sels, AV47TFOperacionesRef, AV48TFOperacionesRef_Sel, AV45TFOperacionesNombreRef, AV46TFOperacionesNombreRef_Sel, AV41TFOperacionesImporte, AV42TFOperacionesImporte_To, AV43TFOperacionesMoneda, AV44TFOperacionesMoneda_Sel, AV33TFOperacionesFechaAlta, AV34TFOperacionesFechaAlta_To, AV35TFOperacionesFechaDesde, AV36TFOperacionesFechaDesde_To, AV37TFOperacionesFechaHasta, AV38TFOperacionesFechaHasta_To, AV31TFOperacionesEstado_Sels) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV24OrderedBy, AV25OrderedDsc, AV15FilterFullText, AV54Pgmname, AV39TFOperacionesId, AV40TFOperacionesId_To, AV49TFOperacionesTipo_Sels, AV47TFOperacionesRef, AV48TFOperacionesRef_Sel, AV45TFOperacionesNombreRef, AV46TFOperacionesNombreRef_Sel, AV41TFOperacionesImporte, AV42TFOperacionesImporte_To, AV43TFOperacionesMoneda, AV44TFOperacionesMoneda_Sel, AV33TFOperacionesFechaAlta, AV34TFOperacionesFechaAlta_To, AV35TFOperacionesFechaDesde, AV36TFOperacionesFechaDesde_To, AV37TFOperacionesFechaHasta, AV38TFOperacionesFechaHasta_To, AV31TFOperacionesEstado_Sels) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV24OrderedBy, AV25OrderedDsc, AV15FilterFullText, AV54Pgmname, AV39TFOperacionesId, AV40TFOperacionesId_To, AV49TFOperacionesTipo_Sels, AV47TFOperacionesRef, AV48TFOperacionesRef_Sel, AV45TFOperacionesNombreRef, AV46TFOperacionesNombreRef_Sel, AV41TFOperacionesImporte, AV42TFOperacionesImporte_To, AV43TFOperacionesMoneda, AV44TFOperacionesMoneda_Sel, AV33TFOperacionesFechaAlta, AV34TFOperacionesFechaAlta_To, AV35TFOperacionesFechaDesde, AV36TFOperacionesFechaDesde_To, AV37TFOperacionesFechaHasta, AV38TFOperacionesFechaHasta_To, AV31TFOperacionesEstado_Sels) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV24OrderedBy, AV25OrderedDsc, AV15FilterFullText, AV54Pgmname, AV39TFOperacionesId, AV40TFOperacionesId_To, AV49TFOperacionesTipo_Sels, AV47TFOperacionesRef, AV48TFOperacionesRef_Sel, AV45TFOperacionesNombreRef, AV46TFOperacionesNombreRef_Sel, AV41TFOperacionesImporte, AV42TFOperacionesImporte_To, AV43TFOperacionesMoneda, AV44TFOperacionesMoneda_Sel, AV33TFOperacionesFechaAlta, AV34TFOperacionesFechaAlta_To, AV35TFOperacionesFechaDesde, AV36TFOperacionesFechaDesde_To, AV37TFOperacionesFechaHasta, AV38TFOperacionesFechaHasta_To, AV31TFOperacionesEstado_Sels) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV54Pgmname = "OperacionesId2Prompt";
         edtavSelect_Enabled = 0;
         edtOperacionesId_Enabled = 0;
         cmbOperacionesTipo.Enabled = 0;
         edtOperacionesRef_Enabled = 0;
         edtOperacionesNombreRef_Enabled = 0;
         edtOperacionesOrdinal_Enabled = 0;
         edtOperacionesIDORD_Enabled = 0;
         cmbOperacionesTipoES.Enabled = 0;
         edtOperacionesImporte_Enabled = 0;
         edtOperacionesMonId_Enabled = 0;
         edtOperacionesMoneda_Enabled = 0;
         edtOperacionesFacturaCod_Enabled = 0;
         edtOperacionesIva_Enabled = 0;
         edtOperacionesComision_Enabled = 0;
         edtOperacionesImporteGrabado_Enabled = 0;
         edtOperacionesRequest_Enabled = 0;
         edtOperacionesResponse_Enabled = 0;
         edtOperacionesComprobantePago_Enabled = 0;
         edtOperacionesFechaAlta_Enabled = 0;
         edtOperacionesFechaPago_Enabled = 0;
         edtOperacionesAux1_Enabled = 0;
         edtOperacionesAux2_Enabled = 0;
         edtOperacionesAux3_Enabled = 0;
         edtOperacionesFechaDesde_Enabled = 0;
         edtOperacionesFechaHasta_Enabled = 0;
         cmbOperacionesEstado.Enabled = 0;
         edtOperacionesBlob1_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPDM0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15DM2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_26 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_26"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV17GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV18GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV16GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV5DDO_OperacionesFechaAltaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_OPERACIONESFECHAALTAAUXDATE"), 0);
            AV7DDO_OperacionesFechaAltaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_OPERACIONESFECHAALTAAUXDATETO"), 0);
            AV8DDO_OperacionesFechaDesdeAuxDate = context.localUtil.CToD( cgiGet( "vDDO_OPERACIONESFECHADESDEAUXDATE"), 0);
            AV10DDO_OperacionesFechaDesdeAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_OPERACIONESFECHADESDEAUXDATETO"), 0);
            AV11DDO_OperacionesFechaHastaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_OPERACIONESFECHAHASTAAUXDATE"), 0);
            AV13DDO_OperacionesFechaHastaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_OPERACIONESFECHAHASTAAUXDATETO"), 0);
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            AV6DDO_OperacionesFechaAltaAuxDateText = cgiGet( edtavDdo_operacionesfechaaltaauxdatetext_Internalname);
            AssignAttri("", false, "AV6DDO_OperacionesFechaAltaAuxDateText", AV6DDO_OperacionesFechaAltaAuxDateText);
            AV9DDO_OperacionesFechaDesdeAuxDateText = cgiGet( edtavDdo_operacionesfechadesdeauxdatetext_Internalname);
            AssignAttri("", false, "AV9DDO_OperacionesFechaDesdeAuxDateText", AV9DDO_OperacionesFechaDesdeAuxDateText);
            AV12DDO_OperacionesFechaHastaAuxDateText = cgiGet( edtavDdo_operacionesfechahastaauxdatetext_Internalname);
            AssignAttri("", false, "AV12DDO_OperacionesFechaHastaAuxDateText", AV12DDO_OperacionesFechaHastaAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV24OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV25OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
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
         E15DM2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E15DM2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFOPERACIONESFECHAHASTA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_operacionesfechahastaauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFOPERACIONESFECHADESDE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_operacionesfechadesdeauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFOPERACIONESFECHAALTA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_operacionesfechaaltaauxdatetext_Internalname});
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( "Selecciona Operaciones", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( AV24OrderedBy < 1 )
         {
            AV24OrderedBy = 1;
            AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E16DM2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV52WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV17GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV17GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV17GridCurrentPage), 10, 0));
         AV18GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV18GridPageCount", StringUtil.LTrimStr( (decimal)(AV18GridPageCount), 10, 0));
         GXt_char2 = AV16GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV54Pgmname, out  GXt_char2) ;
         AV16GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV16GridAppliedFilters", AV16GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E11DM2( )
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
            AV28PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV28PageToGo) ;
         }
         /*  Sending Event outputs  */
      }

      protected void E12DM2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E13DM2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV24OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
            AV25OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV25OrderedDsc", AV25OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesId") == 0 )
            {
               AV39TFOperacionesId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV39TFOperacionesId", StringUtil.LTrimStr( (decimal)(AV39TFOperacionesId), 18, 0));
               AV40TFOperacionesId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV40TFOperacionesId_To", StringUtil.LTrimStr( (decimal)(AV40TFOperacionesId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesTipo") == 0 )
            {
               AV50TFOperacionesTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AV49TFOperacionesTipo_Sels.FromJSonString(AV50TFOperacionesTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesRef") == 0 )
            {
               AV47TFOperacionesRef = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV47TFOperacionesRef", AV47TFOperacionesRef);
               AV48TFOperacionesRef_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV48TFOperacionesRef_Sel", AV48TFOperacionesRef_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesNombreRef") == 0 )
            {
               AV45TFOperacionesNombreRef = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV45TFOperacionesNombreRef", AV45TFOperacionesNombreRef);
               AV46TFOperacionesNombreRef_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV46TFOperacionesNombreRef_Sel", AV46TFOperacionesNombreRef_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesImporte") == 0 )
            {
               AV41TFOperacionesImporte = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV41TFOperacionesImporte", StringUtil.LTrimStr( AV41TFOperacionesImporte, 18, 2));
               AV42TFOperacionesImporte_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV42TFOperacionesImporte_To", StringUtil.LTrimStr( AV42TFOperacionesImporte_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesMoneda") == 0 )
            {
               AV43TFOperacionesMoneda = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV43TFOperacionesMoneda", AV43TFOperacionesMoneda);
               AV44TFOperacionesMoneda_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFOperacionesMoneda_Sel", AV44TFOperacionesMoneda_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesFechaAlta") == 0 )
            {
               AV33TFOperacionesFechaAlta = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV33TFOperacionesFechaAlta", context.localUtil.Format(AV33TFOperacionesFechaAlta, "99/99/99"));
               AV34TFOperacionesFechaAlta_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV34TFOperacionesFechaAlta_To", context.localUtil.Format(AV34TFOperacionesFechaAlta_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesFechaDesde") == 0 )
            {
               AV35TFOperacionesFechaDesde = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV35TFOperacionesFechaDesde", context.localUtil.Format(AV35TFOperacionesFechaDesde, "99/99/99"));
               AV36TFOperacionesFechaDesde_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV36TFOperacionesFechaDesde_To", context.localUtil.Format(AV36TFOperacionesFechaDesde_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesFechaHasta") == 0 )
            {
               AV37TFOperacionesFechaHasta = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV37TFOperacionesFechaHasta", context.localUtil.Format(AV37TFOperacionesFechaHasta, "99/99/99"));
               AV38TFOperacionesFechaHasta_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV38TFOperacionesFechaHasta_To", context.localUtil.Format(AV38TFOperacionesFechaHasta_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesEstado") == 0 )
            {
               AV32TFOperacionesEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AV31TFOperacionesEstado_Sels.FromJSonString(AV32TFOperacionesEstado_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31TFOperacionesEstado_Sels", AV31TFOperacionesEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49TFOperacionesTipo_Sels", AV49TFOperacionesTipo_Sels);
      }

      private void E17DM2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV30Select = "<i class=\"fas fa-check\"></i>";
            AssignAttri("", false, edtavSelect_Internalname, AV30Select);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 26;
            }
            sendrow_262( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_26_Refreshing )
         {
            context.DoAjaxLoad(26, GridRow);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E18DM2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18DM2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV22InOutOperacionesId = A554OperacionesId;
         AssignAttri("", false, "AV22InOutOperacionesId", StringUtil.LTrimStr( (decimal)(AV22InOutOperacionesId), 18, 0));
         AV27OutOperacionesNombreRef = A657OperacionesNombreRef;
         AssignAttri("", false, "AV27OutOperacionesNombreRef", AV27OutOperacionesNombreRef);
         context.setWebReturnParms(new Object[] {(long)AV22InOutOperacionesId,(string)AV27OutOperacionesNombreRef});
         context.setWebReturnParmsMetadata(new Object[] {"AV22InOutOperacionesId","AV27OutOperacionesNombreRef"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void E14DM2( )
      {
         /* 'DoCleanFilters' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CLEANFILTERS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49TFOperacionesTipo_Sels", AV49TFOperacionesTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31TFOperacionesEstado_Sels", AV31TFOperacionesEstado_Sels);
      }

      protected void S112( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV24OrderedBy), 4, 0))+":"+(AV25OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S132( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV39TFOperacionesId = 0;
         AssignAttri("", false, "AV39TFOperacionesId", StringUtil.LTrimStr( (decimal)(AV39TFOperacionesId), 18, 0));
         AV40TFOperacionesId_To = 0;
         AssignAttri("", false, "AV40TFOperacionesId_To", StringUtil.LTrimStr( (decimal)(AV40TFOperacionesId_To), 18, 0));
         AV49TFOperacionesTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV47TFOperacionesRef = "";
         AssignAttri("", false, "AV47TFOperacionesRef", AV47TFOperacionesRef);
         AV48TFOperacionesRef_Sel = "";
         AssignAttri("", false, "AV48TFOperacionesRef_Sel", AV48TFOperacionesRef_Sel);
         AV45TFOperacionesNombreRef = "";
         AssignAttri("", false, "AV45TFOperacionesNombreRef", AV45TFOperacionesNombreRef);
         AV46TFOperacionesNombreRef_Sel = "";
         AssignAttri("", false, "AV46TFOperacionesNombreRef_Sel", AV46TFOperacionesNombreRef_Sel);
         AV41TFOperacionesImporte = 0;
         AssignAttri("", false, "AV41TFOperacionesImporte", StringUtil.LTrimStr( AV41TFOperacionesImporte, 18, 2));
         AV42TFOperacionesImporte_To = 0;
         AssignAttri("", false, "AV42TFOperacionesImporte_To", StringUtil.LTrimStr( AV42TFOperacionesImporte_To, 18, 2));
         AV43TFOperacionesMoneda = "";
         AssignAttri("", false, "AV43TFOperacionesMoneda", AV43TFOperacionesMoneda);
         AV44TFOperacionesMoneda_Sel = "";
         AssignAttri("", false, "AV44TFOperacionesMoneda_Sel", AV44TFOperacionesMoneda_Sel);
         AV33TFOperacionesFechaAlta = DateTime.MinValue;
         AssignAttri("", false, "AV33TFOperacionesFechaAlta", context.localUtil.Format(AV33TFOperacionesFechaAlta, "99/99/99"));
         AV34TFOperacionesFechaAlta_To = DateTime.MinValue;
         AssignAttri("", false, "AV34TFOperacionesFechaAlta_To", context.localUtil.Format(AV34TFOperacionesFechaAlta_To, "99/99/99"));
         AV35TFOperacionesFechaDesde = DateTime.MinValue;
         AssignAttri("", false, "AV35TFOperacionesFechaDesde", context.localUtil.Format(AV35TFOperacionesFechaDesde, "99/99/99"));
         AV36TFOperacionesFechaDesde_To = DateTime.MinValue;
         AssignAttri("", false, "AV36TFOperacionesFechaDesde_To", context.localUtil.Format(AV36TFOperacionesFechaDesde_To, "99/99/99"));
         AV37TFOperacionesFechaHasta = DateTime.MinValue;
         AssignAttri("", false, "AV37TFOperacionesFechaHasta", context.localUtil.Format(AV37TFOperacionesFechaHasta, "99/99/99"));
         AV38TFOperacionesFechaHasta_To = DateTime.MinValue;
         AssignAttri("", false, "AV38TFOperacionesFechaHasta_To", context.localUtil.Format(AV38TFOperacionesFechaHasta_To, "99/99/99"));
         AV31TFOperacionesEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV19GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV19GridState.gxTpr_Orderedby = AV24OrderedBy;
         AV19GridState.gxTpr_Ordereddsc = AV25OrderedDsc;
         AV19GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV19GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV19GridState,  "TFOPERACIONESID",  context.GetMessage( "Id", ""),  !((0==AV39TFOperacionesId)&&(0==AV40TFOperacionesId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV39TFOperacionesId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV40TFOperacionesId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV19GridState,  "TFOPERACIONESTIPO_SEL",  context.GetMessage( "Operaciones Tipo", ""),  !(AV49TFOperacionesTipo_Sels.Count==0),  0,  AV49TFOperacionesTipo_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV19GridState,  "TFOPERACIONESREF",  context.GetMessage( "Referencia", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV47TFOperacionesRef)),  0,  AV47TFOperacionesRef,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFOperacionesRef_Sel)),  AV48TFOperacionesRef_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV19GridState,  "TFOPERACIONESNOMBREREF",  context.GetMessage( "Nombre de Referencia", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFOperacionesNombreRef)),  0,  AV45TFOperacionesNombreRef,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV46TFOperacionesNombreRef_Sel)),  AV46TFOperacionesNombreRef_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV19GridState,  "TFOPERACIONESIMPORTE",  context.GetMessage( "Importe", ""),  !((Convert.ToDecimal(0)==AV41TFOperacionesImporte)&&(Convert.ToDecimal(0)==AV42TFOperacionesImporte_To)),  0,  StringUtil.Trim( StringUtil.Str( AV41TFOperacionesImporte, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV42TFOperacionesImporte_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV19GridState,  "TFOPERACIONESMONEDA",  context.GetMessage( "Iso", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFOperacionesMoneda)),  0,  AV43TFOperacionesMoneda,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFOperacionesMoneda_Sel)),  AV44TFOperacionesMoneda_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV19GridState,  "TFOPERACIONESFECHAALTA",  context.GetMessage( "Fecha de Alta", ""),  !((DateTime.MinValue==AV33TFOperacionesFechaAlta)&&(DateTime.MinValue==AV34TFOperacionesFechaAlta_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV33TFOperacionesFechaAlta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV34TFOperacionesFechaAlta_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV19GridState,  "TFOPERACIONESFECHADESDE",  context.GetMessage( "Desde", ""),  !((DateTime.MinValue==AV35TFOperacionesFechaDesde)&&(DateTime.MinValue==AV36TFOperacionesFechaDesde_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV35TFOperacionesFechaDesde, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV36TFOperacionesFechaDesde_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV19GridState,  "TFOPERACIONESFECHAHASTA",  context.GetMessage( "Hasta", ""),  !((DateTime.MinValue==AV37TFOperacionesFechaHasta)&&(DateTime.MinValue==AV38TFOperacionesFechaHasta_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV37TFOperacionesFechaHasta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV38TFOperacionesFechaHasta_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV19GridState,  "TFOPERACIONESESTADO_SEL",  context.GetMessage( "Estado", ""),  !(AV31TFOperacionesEstado_Sels.Count==0),  0,  AV31TFOperacionesEstado_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV54Pgmname+"GridState",  AV19GridState.ToXml(false, true, "", "")) ;
      }

      protected void wb_table1_14_DM2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellAlignTop CellPaddingTop10'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCleanfilters_Internalname, context.GetMessage( "<i class=\"fas fa-filter CleanFiltersIcon\"></i>", ""), "", "", lblCleanfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOCLEANFILTERS\\'."+"'", "", "TextBlock", 5, context.GetMessage( "WWP_CleanFiltersTooltip", ""), 1, 1, 0, 1, "HLP_OperacionesId2Prompt.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_26_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_OperacionesId2Prompt.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_14_DM2e( true) ;
         }
         else
         {
            wb_table1_14_DM2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV22InOutOperacionesId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV22InOutOperacionesId", StringUtil.LTrimStr( (decimal)(AV22InOutOperacionesId), 18, 0));
         AV27OutOperacionesNombreRef = (string)getParm(obj,1);
         AssignAttri("", false, "AV27OutOperacionesNombreRef", AV27OutOperacionesNombreRef);
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
         PADM2( ) ;
         WSDM2( ) ;
         WEDM2( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021225860", true, true, false);
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
         context.AddJavascriptSource("operacionesid2prompt.js", "?202673021225861", false, true, false);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_262( )
      {
         edtavSelect_Internalname = "vSELECT_"+sGXsfl_26_idx;
         edtOperacionesId_Internalname = "OPERACIONESID_"+sGXsfl_26_idx;
         cmbOperacionesTipo_Internalname = "OPERACIONESTIPO_"+sGXsfl_26_idx;
         edtOperacionesRef_Internalname = "OPERACIONESREF_"+sGXsfl_26_idx;
         edtOperacionesNombreRef_Internalname = "OPERACIONESNOMBREREF_"+sGXsfl_26_idx;
         edtOperacionesOrdinal_Internalname = "OPERACIONESORDINAL_"+sGXsfl_26_idx;
         edtOperacionesIDORD_Internalname = "OPERACIONESIDORD_"+sGXsfl_26_idx;
         cmbOperacionesTipoES_Internalname = "OPERACIONESTIPOES_"+sGXsfl_26_idx;
         edtOperacionesImporte_Internalname = "OPERACIONESIMPORTE_"+sGXsfl_26_idx;
         edtOperacionesMonId_Internalname = "OPERACIONESMONID_"+sGXsfl_26_idx;
         edtOperacionesMoneda_Internalname = "OPERACIONESMONEDA_"+sGXsfl_26_idx;
         edtOperacionesFacturaCod_Internalname = "OPERACIONESFACTURACOD_"+sGXsfl_26_idx;
         edtOperacionesIva_Internalname = "OPERACIONESIVA_"+sGXsfl_26_idx;
         edtOperacionesComision_Internalname = "OPERACIONESCOMISION_"+sGXsfl_26_idx;
         edtOperacionesImporteGrabado_Internalname = "OPERACIONESIMPORTEGRABADO_"+sGXsfl_26_idx;
         edtOperacionesRequest_Internalname = "OPERACIONESREQUEST_"+sGXsfl_26_idx;
         edtOperacionesResponse_Internalname = "OPERACIONESRESPONSE_"+sGXsfl_26_idx;
         edtOperacionesComprobantePago_Internalname = "OPERACIONESCOMPROBANTEPAGO_"+sGXsfl_26_idx;
         edtOperacionesFechaAlta_Internalname = "OPERACIONESFECHAALTA_"+sGXsfl_26_idx;
         edtOperacionesFechaPago_Internalname = "OPERACIONESFECHAPAGO_"+sGXsfl_26_idx;
         edtOperacionesAux1_Internalname = "OPERACIONESAUX1_"+sGXsfl_26_idx;
         edtOperacionesAux2_Internalname = "OPERACIONESAUX2_"+sGXsfl_26_idx;
         edtOperacionesAux3_Internalname = "OPERACIONESAUX3_"+sGXsfl_26_idx;
         edtOperacionesFechaDesde_Internalname = "OPERACIONESFECHADESDE_"+sGXsfl_26_idx;
         edtOperacionesFechaHasta_Internalname = "OPERACIONESFECHAHASTA_"+sGXsfl_26_idx;
         cmbOperacionesEstado_Internalname = "OPERACIONESESTADO_"+sGXsfl_26_idx;
         edtOperacionesBlob1_Internalname = "OPERACIONESBLOB1_"+sGXsfl_26_idx;
      }

      protected void SubsflControlProps_fel_262( )
      {
         edtavSelect_Internalname = "vSELECT_"+sGXsfl_26_fel_idx;
         edtOperacionesId_Internalname = "OPERACIONESID_"+sGXsfl_26_fel_idx;
         cmbOperacionesTipo_Internalname = "OPERACIONESTIPO_"+sGXsfl_26_fel_idx;
         edtOperacionesRef_Internalname = "OPERACIONESREF_"+sGXsfl_26_fel_idx;
         edtOperacionesNombreRef_Internalname = "OPERACIONESNOMBREREF_"+sGXsfl_26_fel_idx;
         edtOperacionesOrdinal_Internalname = "OPERACIONESORDINAL_"+sGXsfl_26_fel_idx;
         edtOperacionesIDORD_Internalname = "OPERACIONESIDORD_"+sGXsfl_26_fel_idx;
         cmbOperacionesTipoES_Internalname = "OPERACIONESTIPOES_"+sGXsfl_26_fel_idx;
         edtOperacionesImporte_Internalname = "OPERACIONESIMPORTE_"+sGXsfl_26_fel_idx;
         edtOperacionesMonId_Internalname = "OPERACIONESMONID_"+sGXsfl_26_fel_idx;
         edtOperacionesMoneda_Internalname = "OPERACIONESMONEDA_"+sGXsfl_26_fel_idx;
         edtOperacionesFacturaCod_Internalname = "OPERACIONESFACTURACOD_"+sGXsfl_26_fel_idx;
         edtOperacionesIva_Internalname = "OPERACIONESIVA_"+sGXsfl_26_fel_idx;
         edtOperacionesComision_Internalname = "OPERACIONESCOMISION_"+sGXsfl_26_fel_idx;
         edtOperacionesImporteGrabado_Internalname = "OPERACIONESIMPORTEGRABADO_"+sGXsfl_26_fel_idx;
         edtOperacionesRequest_Internalname = "OPERACIONESREQUEST_"+sGXsfl_26_fel_idx;
         edtOperacionesResponse_Internalname = "OPERACIONESRESPONSE_"+sGXsfl_26_fel_idx;
         edtOperacionesComprobantePago_Internalname = "OPERACIONESCOMPROBANTEPAGO_"+sGXsfl_26_fel_idx;
         edtOperacionesFechaAlta_Internalname = "OPERACIONESFECHAALTA_"+sGXsfl_26_fel_idx;
         edtOperacionesFechaPago_Internalname = "OPERACIONESFECHAPAGO_"+sGXsfl_26_fel_idx;
         edtOperacionesAux1_Internalname = "OPERACIONESAUX1_"+sGXsfl_26_fel_idx;
         edtOperacionesAux2_Internalname = "OPERACIONESAUX2_"+sGXsfl_26_fel_idx;
         edtOperacionesAux3_Internalname = "OPERACIONESAUX3_"+sGXsfl_26_fel_idx;
         edtOperacionesFechaDesde_Internalname = "OPERACIONESFECHADESDE_"+sGXsfl_26_fel_idx;
         edtOperacionesFechaHasta_Internalname = "OPERACIONESFECHAHASTA_"+sGXsfl_26_fel_idx;
         cmbOperacionesEstado_Internalname = "OPERACIONESESTADO_"+sGXsfl_26_fel_idx;
         edtOperacionesBlob1_Internalname = "OPERACIONESBLOB1_"+sGXsfl_26_fel_idx;
      }

      protected void sendrow_262( )
      {
         sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
         SubsflControlProps_262( ) ;
         WBDM0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_26_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_26_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_26_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_26_idx + "',26)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSelect_Internalname,StringUtil.RTrim( AV30Select),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"","'"+""+"'"+",false,"+"'"+"EENTER."+sGXsfl_26_idx+"'",(string)"",(string)"",context.GetMessage( "GX_BtnSelect", ""),(string)"",(string)edtavSelect_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavSelect_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A554OperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A554OperacionesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbOperacionesTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "OPERACIONESTIPO_" + sGXsfl_26_idx;
               cmbOperacionesTipo.Name = GXCCtl;
               cmbOperacionesTipo.WebTags = "";
               cmbOperacionesTipo.addItem("LSF", context.GetMessage( "Liquidación de Solicitudes del Profesional", ""), 0);
               cmbOperacionesTipo.addItem("LSC", context.GetMessage( "Liquidación de  Solicitudes Comercio", ""), 0);
               cmbOperacionesTipo.addItem("COL", context.GetMessage( "Cobro de Saldo Pendiente", ""), 0);
               cmbOperacionesTipo.addItem("POL", context.GetMessage( "Pago de Saldo", ""), 0);
               cmbOperacionesTipo.addItem("CSO", context.GetMessage( "Cobro de Solicitud", ""), 0);
               cmbOperacionesTipo.addItem("NCR", context.GetMessage( "Nota de Credito", ""), 0);
               cmbOperacionesTipo.addItem("NDE", context.GetMessage( "Nota de Debito", ""), 0);
               cmbOperacionesTipo.addItem("OTR", context.GetMessage( "Otros", ""), 0);
               cmbOperacionesTipo.addItem("FEN", context.GetMessage( "Solicitudes ingresadas desde Fenicio", ""), 0);
               cmbOperacionesTipo.addItem("FGO", context.GetMessage( "Respuesta de api fenicio", ""), 0);
               cmbOperacionesTipo.addItem("CEX", context.GetMessage( "COMERCIO_EXTERNO", ""), 0);
               if ( cmbOperacionesTipo.ItemCount > 0 )
               {
                  A649OperacionesTipo = cmbOperacionesTipo.getValidValue(A649OperacionesTipo);
                  n649OperacionesTipo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbOperacionesTipo,(string)cmbOperacionesTipo_Internalname,StringUtil.RTrim( A649OperacionesTipo),(short)1,(string)cmbOperacionesTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbOperacionesTipo.CurrentValue = StringUtil.RTrim( A649OperacionesTipo);
            AssignProp("", false, cmbOperacionesTipo_Internalname, "Values", (string)(cmbOperacionesTipo.ToJavascriptSource()), !bGXsfl_26_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesRef_Internalname,StringUtil.RTrim( A555OperacionesRef),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesRef_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)25,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesNombreRef_Internalname,StringUtil.RTrim( A657OperacionesNombreRef),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesNombreRef_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"NombreLargo",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesOrdinal_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A579OperacionesOrdinal), 12, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A579OperacionesOrdinal), "ZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesOrdinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesIDORD_Internalname,StringUtil.RTrim( A586OperacionesIDORD),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesIDORD_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbOperacionesTipoES.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "OPERACIONESTIPOES_" + sGXsfl_26_idx;
               cmbOperacionesTipoES.Name = GXCCtl;
               cmbOperacionesTipoES.WebTags = "";
               cmbOperacionesTipoES.addItem("E", context.GetMessage( "Entrada", ""), 0);
               cmbOperacionesTipoES.addItem("S", context.GetMessage( "Salida", ""), 0);
               if ( cmbOperacionesTipoES.ItemCount > 0 )
               {
                  A569OperacionesTipoES = cmbOperacionesTipoES.getValidValue(A569OperacionesTipoES);
                  n569OperacionesTipoES = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbOperacionesTipoES,(string)cmbOperacionesTipoES_Internalname,StringUtil.RTrim( A569OperacionesTipoES),(short)1,(string)cmbOperacionesTipoES_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbOperacionesTipoES.CurrentValue = StringUtil.RTrim( A569OperacionesTipoES);
            AssignProp("", false, cmbOperacionesTipoES_Internalname, "Values", (string)(cmbOperacionesTipoES.ToJavascriptSource()), !bGXsfl_26_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesImporte_Internalname,StringUtil.LTrim( StringUtil.NToC( A570OperacionesImporte, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A570OperacionesImporte, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesImporte_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesMonId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A662OperacionesMonId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A662OperacionesMonId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesMonId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesMoneda_Internalname,StringUtil.RTrim( A571OperacionesMoneda),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesMoneda_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"MonISO",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesFacturaCod_Internalname,StringUtil.RTrim( A572OperacionesFacturaCod),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesFacturaCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)25,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesIva_Internalname,StringUtil.LTrim( StringUtil.NToC( A573OperacionesIva, 4, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A573OperacionesIva, "9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesIva_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Iva",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesComision_Internalname,StringUtil.LTrim( StringUtil.NToC( A574OperacionesComision, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A574OperacionesComision, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesComision_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Comision",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesImporteGrabado_Internalname,StringUtil.LTrim( StringUtil.NToC( A578OperacionesImporteGrabado, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A578OperacionesImporteGrabado, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesImporteGrabado_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesRequest_Internalname,(string)A575OperacionesRequest,(string)A575OperacionesRequest,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesRequest_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)26,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesResponse_Internalname,(string)A576OperacionesResponse,(string)A576OperacionesResponse,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesResponse_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)26,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesComprobantePago_Internalname,StringUtil.RTrim( A580OperacionesComprobantePago),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesComprobantePago_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)256,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesFechaAlta_Internalname,context.localUtil.Format(A581OperacionesFechaAlta, "99/99/99"),context.localUtil.Format( A581OperacionesFechaAlta, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesFechaPago_Internalname,context.localUtil.TToC( A582OperacionesFechaPago, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A582OperacionesFechaPago, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesFechaPago_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesAux1_Internalname,(string)A583OperacionesAux1,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesAux1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesAux2_Internalname,(string)A584OperacionesAux2,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesAux2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesAux3_Internalname,(string)A585OperacionesAux3,(string)A585OperacionesAux3,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesAux3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)26,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesFechaDesde_Internalname,context.localUtil.Format(A658OperacionesFechaDesde, "99/99/99"),context.localUtil.Format( A658OperacionesFechaDesde, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesFechaDesde_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesFechaHasta_Internalname,context.localUtil.Format(A659OperacionesFechaHasta, "99/99/99"),context.localUtil.Format( A659OperacionesFechaHasta, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesFechaHasta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbOperacionesEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "OPERACIONESESTADO_" + sGXsfl_26_idx;
               cmbOperacionesEstado.Name = GXCCtl;
               cmbOperacionesEstado.WebTags = "";
               cmbOperacionesEstado.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
               cmbOperacionesEstado.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
               cmbOperacionesEstado.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
               if ( cmbOperacionesEstado.ItemCount > 0 )
               {
                  A577OperacionesEstado = cmbOperacionesEstado.getValidValue(A577OperacionesEstado);
                  n577OperacionesEstado = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbOperacionesEstado,(string)cmbOperacionesEstado_Internalname,StringUtil.RTrim( A577OperacionesEstado),(short)1,(string)cmbOperacionesEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbOperacionesEstado.CurrentValue = StringUtil.RTrim( A577OperacionesEstado);
            AssignProp("", false, cmbOperacionesEstado_Internalname, "Values", (string)(cmbOperacionesEstado.ToJavascriptSource()), !bGXsfl_26_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            ClassString = "Attribute";
            StyleString = "";
            edtOperacionesBlob1_Filetype = "tmp";
            AssignProp("", false, edtOperacionesBlob1_Internalname, "Filetype", edtOperacionesBlob1_Filetype, !bGXsfl_26_Refreshing);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A663OperacionesBlob1)) )
            {
               gxblobfileaux.Source = A663OperacionesBlob1;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtOperacionesBlob1_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtOperacionesBlob1_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  A663OperacionesBlob1 = gxblobfileaux.GetURI();
                  n663OperacionesBlob1 = false;
                  AssignProp("", false, edtOperacionesBlob1_Internalname, "URL", context.PathToRelativeUrl( A663OperacionesBlob1), !bGXsfl_26_Refreshing);
                  edtOperacionesBlob1_Filetype = gxblobfileaux.GetExtension();
                  AssignProp("", false, edtOperacionesBlob1_Internalname, "Filetype", edtOperacionesBlob1_Filetype, !bGXsfl_26_Refreshing);
               }
               AssignProp("", false, edtOperacionesBlob1_Internalname, "URL", context.PathToRelativeUrl( A663OperacionesBlob1), !bGXsfl_26_Refreshing);
            }
            GridRow.AddColumnProperties("blob", 2, isAjaxCallMode( ), new Object[] {(string)edtOperacionesBlob1_Internalname,StringUtil.RTrim( A663OperacionesBlob1),context.PathToRelativeUrl( A663OperacionesBlob1),(String.IsNullOrEmpty(StringUtil.RTrim( edtOperacionesBlob1_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtOperacionesBlob1_Filetype)) ? A663OperacionesBlob1 : edtOperacionesBlob1_Filetype)) : edtOperacionesBlob1_Contenttype),(bool)false,(string)"",(string)edtOperacionesBlob1_Parameters,(short)0,(short)0,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)60,(string)"px",(short)0,(short)0,(short)0,(string)edtOperacionesBlob1_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""+"",(string)"",(string)""});
            send_integrity_lvl_hashesDM2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_26_idx = ((subGrid_Islastpage==1)&&(nGXsfl_26_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_26_idx+1);
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
         }
         /* End function sendrow_262 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "OPERACIONESTIPO_" + sGXsfl_26_idx;
         cmbOperacionesTipo.Name = GXCCtl;
         cmbOperacionesTipo.WebTags = "";
         cmbOperacionesTipo.addItem("LSF", context.GetMessage( "Liquidación de Solicitudes del Profesional", ""), 0);
         cmbOperacionesTipo.addItem("LSC", context.GetMessage( "Liquidación de  Solicitudes Comercio", ""), 0);
         cmbOperacionesTipo.addItem("COL", context.GetMessage( "Cobro de Saldo Pendiente", ""), 0);
         cmbOperacionesTipo.addItem("POL", context.GetMessage( "Pago de Saldo", ""), 0);
         cmbOperacionesTipo.addItem("CSO", context.GetMessage( "Cobro de Solicitud", ""), 0);
         cmbOperacionesTipo.addItem("NCR", context.GetMessage( "Nota de Credito", ""), 0);
         cmbOperacionesTipo.addItem("NDE", context.GetMessage( "Nota de Debito", ""), 0);
         cmbOperacionesTipo.addItem("OTR", context.GetMessage( "Otros", ""), 0);
         cmbOperacionesTipo.addItem("FEN", context.GetMessage( "Solicitudes ingresadas desde Fenicio", ""), 0);
         cmbOperacionesTipo.addItem("FGO", context.GetMessage( "Respuesta de api fenicio", ""), 0);
         cmbOperacionesTipo.addItem("CEX", context.GetMessage( "COMERCIO_EXTERNO", ""), 0);
         if ( cmbOperacionesTipo.ItemCount > 0 )
         {
            A649OperacionesTipo = cmbOperacionesTipo.getValidValue(A649OperacionesTipo);
            n649OperacionesTipo = false;
         }
         GXCCtl = "OPERACIONESTIPOES_" + sGXsfl_26_idx;
         cmbOperacionesTipoES.Name = GXCCtl;
         cmbOperacionesTipoES.WebTags = "";
         cmbOperacionesTipoES.addItem("E", context.GetMessage( "Entrada", ""), 0);
         cmbOperacionesTipoES.addItem("S", context.GetMessage( "Salida", ""), 0);
         if ( cmbOperacionesTipoES.ItemCount > 0 )
         {
            A569OperacionesTipoES = cmbOperacionesTipoES.getValidValue(A569OperacionesTipoES);
            n569OperacionesTipoES = false;
         }
         GXCCtl = "OPERACIONESESTADO_" + sGXsfl_26_idx;
         cmbOperacionesEstado.Name = GXCCtl;
         cmbOperacionesEstado.WebTags = "";
         cmbOperacionesEstado.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
         cmbOperacionesEstado.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
         cmbOperacionesEstado.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
         if ( cmbOperacionesEstado.ItemCount > 0 )
         {
            A577OperacionesEstado = cmbOperacionesEstado.getValidValue(A577OperacionesEstado);
            n577OperacionesEstado = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl26( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"26\">") ;
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
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Operaciones Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Referencia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre de Referencia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Ordinal", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "IDORD", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Importe", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Moneda", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Iso", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Código de Facturación ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "IVA", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comisión", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Importe Grabado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Request", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Response", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nro. Comprobante de Pago", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha de Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha de Pago", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Aux1", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Aux2", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Aux3", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Desde", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Hasta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Archivo", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV30Select)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSelect_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A554OperacionesId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A649OperacionesTipo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A555OperacionesRef)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A657OperacionesNombreRef)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A579OperacionesOrdinal), 12, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A586OperacionesIDORD)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A569OperacionesTipoES)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A570OperacionesImporte, 21, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A662OperacionesMonId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A571OperacionesMoneda)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A572OperacionesFacturaCod)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A573OperacionesIva, 4, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A574OperacionesComision, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A578OperacionesImporteGrabado, 21, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A575OperacionesRequest));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A576OperacionesResponse));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A580OperacionesComprobantePago)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A581OperacionesFechaAlta, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A582OperacionesFechaPago, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A583OperacionesAux1));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A584OperacionesAux2));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A585OperacionesAux3));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A658OperacionesFechaDesde, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A659OperacionesFechaHasta, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A577OperacionesEstado)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A663OperacionesBlob1));
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
         lblCleanfilters_Internalname = "CLEANFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtavSelect_Internalname = "vSELECT";
         edtOperacionesId_Internalname = "OPERACIONESID";
         cmbOperacionesTipo_Internalname = "OPERACIONESTIPO";
         edtOperacionesRef_Internalname = "OPERACIONESREF";
         edtOperacionesNombreRef_Internalname = "OPERACIONESNOMBREREF";
         edtOperacionesOrdinal_Internalname = "OPERACIONESORDINAL";
         edtOperacionesIDORD_Internalname = "OPERACIONESIDORD";
         cmbOperacionesTipoES_Internalname = "OPERACIONESTIPOES";
         edtOperacionesImporte_Internalname = "OPERACIONESIMPORTE";
         edtOperacionesMonId_Internalname = "OPERACIONESMONID";
         edtOperacionesMoneda_Internalname = "OPERACIONESMONEDA";
         edtOperacionesFacturaCod_Internalname = "OPERACIONESFACTURACOD";
         edtOperacionesIva_Internalname = "OPERACIONESIVA";
         edtOperacionesComision_Internalname = "OPERACIONESCOMISION";
         edtOperacionesImporteGrabado_Internalname = "OPERACIONESIMPORTEGRABADO";
         edtOperacionesRequest_Internalname = "OPERACIONESREQUEST";
         edtOperacionesResponse_Internalname = "OPERACIONESRESPONSE";
         edtOperacionesComprobantePago_Internalname = "OPERACIONESCOMPROBANTEPAGO";
         edtOperacionesFechaAlta_Internalname = "OPERACIONESFECHAALTA";
         edtOperacionesFechaPago_Internalname = "OPERACIONESFECHAPAGO";
         edtOperacionesAux1_Internalname = "OPERACIONESAUX1";
         edtOperacionesAux2_Internalname = "OPERACIONESAUX2";
         edtOperacionesAux3_Internalname = "OPERACIONESAUX3";
         edtOperacionesFechaDesde_Internalname = "OPERACIONESFECHADESDE";
         edtOperacionesFechaHasta_Internalname = "OPERACIONESFECHAHASTA";
         cmbOperacionesEstado_Internalname = "OPERACIONESESTADO";
         edtOperacionesBlob1_Internalname = "OPERACIONESBLOB1";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_operacionesfechaaltaauxdatetext_Internalname = "vDDO_OPERACIONESFECHAALTAAUXDATETEXT";
         Tfoperacionesfechaalta_rangepicker_Internalname = "TFOPERACIONESFECHAALTA_RANGEPICKER";
         divDdo_operacionesfechaaltaauxdates_Internalname = "DDO_OPERACIONESFECHAALTAAUXDATES";
         edtavDdo_operacionesfechadesdeauxdatetext_Internalname = "vDDO_OPERACIONESFECHADESDEAUXDATETEXT";
         Tfoperacionesfechadesde_rangepicker_Internalname = "TFOPERACIONESFECHADESDE_RANGEPICKER";
         divDdo_operacionesfechadesdeauxdates_Internalname = "DDO_OPERACIONESFECHADESDEAUXDATES";
         edtavDdo_operacionesfechahastaauxdatetext_Internalname = "vDDO_OPERACIONESFECHAHASTAAUXDATETEXT";
         Tfoperacionesfechahasta_rangepicker_Internalname = "TFOPERACIONESFECHAHASTA_RANGEPICKER";
         divDdo_operacionesfechahastaauxdates_Internalname = "DDO_OPERACIONESFECHAHASTAAUXDATES";
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
         edtOperacionesBlob1_Jsonclick = "";
         edtOperacionesBlob1_Parameters = "";
         edtOperacionesBlob1_Contenttype = "";
         edtOperacionesBlob1_Filetype = "";
         cmbOperacionesEstado_Jsonclick = "";
         edtOperacionesFechaHasta_Jsonclick = "";
         edtOperacionesFechaDesde_Jsonclick = "";
         edtOperacionesAux3_Jsonclick = "";
         edtOperacionesAux2_Jsonclick = "";
         edtOperacionesAux1_Jsonclick = "";
         edtOperacionesFechaPago_Jsonclick = "";
         edtOperacionesFechaAlta_Jsonclick = "";
         edtOperacionesComprobantePago_Jsonclick = "";
         edtOperacionesResponse_Jsonclick = "";
         edtOperacionesRequest_Jsonclick = "";
         edtOperacionesImporteGrabado_Jsonclick = "";
         edtOperacionesComision_Jsonclick = "";
         edtOperacionesIva_Jsonclick = "";
         edtOperacionesFacturaCod_Jsonclick = "";
         edtOperacionesMoneda_Jsonclick = "";
         edtOperacionesMonId_Jsonclick = "";
         edtOperacionesImporte_Jsonclick = "";
         cmbOperacionesTipoES_Jsonclick = "";
         edtOperacionesIDORD_Jsonclick = "";
         edtOperacionesOrdinal_Jsonclick = "";
         edtOperacionesNombreRef_Jsonclick = "";
         edtOperacionesRef_Jsonclick = "";
         cmbOperacionesTipo_Jsonclick = "";
         edtOperacionesId_Jsonclick = "";
         edtavSelect_Jsonclick = "";
         edtavSelect_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtOperacionesBlob1_Enabled = 0;
         cmbOperacionesEstado.Enabled = 0;
         edtOperacionesFechaHasta_Enabled = 0;
         edtOperacionesFechaDesde_Enabled = 0;
         edtOperacionesAux3_Enabled = 0;
         edtOperacionesAux2_Enabled = 0;
         edtOperacionesAux1_Enabled = 0;
         edtOperacionesFechaPago_Enabled = 0;
         edtOperacionesFechaAlta_Enabled = 0;
         edtOperacionesComprobantePago_Enabled = 0;
         edtOperacionesResponse_Enabled = 0;
         edtOperacionesRequest_Enabled = 0;
         edtOperacionesImporteGrabado_Enabled = 0;
         edtOperacionesComision_Enabled = 0;
         edtOperacionesIva_Enabled = 0;
         edtOperacionesFacturaCod_Enabled = 0;
         edtOperacionesMoneda_Enabled = 0;
         edtOperacionesMonId_Enabled = 0;
         edtOperacionesImporte_Enabled = 0;
         cmbOperacionesTipoES.Enabled = 0;
         edtOperacionesIDORD_Enabled = 0;
         edtOperacionesOrdinal_Enabled = 0;
         edtOperacionesNombreRef_Enabled = 0;
         edtOperacionesRef_Enabled = 0;
         cmbOperacionesTipo.Enabled = 0;
         edtOperacionesId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_operacionesfechahastaauxdatetext_Jsonclick = "";
         edtavDdo_operacionesfechadesdeauxdatetext_Jsonclick = "";
         edtavDdo_operacionesfechaaltaauxdatetext_Jsonclick = "";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "18.0||||18.2|||||";
         Ddo_grid_Datalistproc = "OperacionesIdPromptGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|LSF:Liquidación de Solicitudes del Profesional,LSC:Liquidación de  Solicitudes Comercio,COL:Cobro de Liquidación,POL:Pago de Liquidación,CSO:Cobro de Solicitud,NCR:Nota de Credito,NDE:Nota de Debito,OTR:Otros||||||||PRO:Procesado,PND:Pendiente,ANU:Anulado";
         Ddo_grid_Allowmultipleselection = "|T||||||||T";
         Ddo_grid_Datalisttype = "|FixedValues|Dynamic|Dynamic||Dynamic||||FixedValues";
         Ddo_grid_Includedatalist = "|T|T|T||T||||T";
         Ddo_grid_Filterisrange = "T||||T||P|P|P|";
         Ddo_grid_Filtertype = "Numeric||Character|Character|Numeric|Character|Date|Date|Date|";
         Ddo_grid_Includefilter = "T||T|T|T|T|T|T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|7|8|9|10|11";
         Ddo_grid_Columnids = "1:OperacionesId|2:OperacionesTipo|3:OperacionesRef|4:OperacionesNombreRef|8:OperacionesImporte|10:OperacionesMoneda|18:OperacionesFechaAlta|23:OperacionesFechaDesde|24:OperacionesFechaHasta|25:OperacionesEstado";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Operaciones Id2 Prompt", "");
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV25OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV15FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV39TFOperacionesId',fld:'vTFOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV40TFOperacionesId_To',fld:'vTFOPERACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV47TFOperacionesRef',fld:'vTFOPERACIONESREF',pic:'',type:'char'},{av:'AV48TFOperacionesRef_Sel',fld:'vTFOPERACIONESREF_SEL',pic:'',type:'char'},{av:'AV45TFOperacionesNombreRef',fld:'vTFOPERACIONESNOMBREREF',pic:'',type:'char'},{av:'AV46TFOperacionesNombreRef_Sel',fld:'vTFOPERACIONESNOMBREREF_SEL',pic:'',type:'char'},{av:'AV41TFOperacionesImporte',fld:'vTFOPERACIONESIMPORTE',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV42TFOperacionesImporte_To',fld:'vTFOPERACIONESIMPORTE_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43TFOperacionesMoneda',fld:'vTFOPERACIONESMONEDA',pic:'',type:'char'},{av:'AV44TFOperacionesMoneda_Sel',fld:'vTFOPERACIONESMONEDA_SEL',pic:'',type:'char'},{av:'AV33TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV34TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV35TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV36TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV37TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV38TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV31TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV17GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV18GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV16GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11DM2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV25OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV15FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV39TFOperacionesId',fld:'vTFOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV40TFOperacionesId_To',fld:'vTFOPERACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV47TFOperacionesRef',fld:'vTFOPERACIONESREF',pic:'',type:'char'},{av:'AV48TFOperacionesRef_Sel',fld:'vTFOPERACIONESREF_SEL',pic:'',type:'char'},{av:'AV45TFOperacionesNombreRef',fld:'vTFOPERACIONESNOMBREREF',pic:'',type:'char'},{av:'AV46TFOperacionesNombreRef_Sel',fld:'vTFOPERACIONESNOMBREREF_SEL',pic:'',type:'char'},{av:'AV41TFOperacionesImporte',fld:'vTFOPERACIONESIMPORTE',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV42TFOperacionesImporte_To',fld:'vTFOPERACIONESIMPORTE_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43TFOperacionesMoneda',fld:'vTFOPERACIONESMONEDA',pic:'',type:'char'},{av:'AV44TFOperacionesMoneda_Sel',fld:'vTFOPERACIONESMONEDA_SEL',pic:'',type:'char'},{av:'AV33TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV34TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV35TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV36TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV37TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV38TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV31TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV17GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV18GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV16GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12DM2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV25OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV15FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV39TFOperacionesId',fld:'vTFOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV40TFOperacionesId_To',fld:'vTFOPERACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV47TFOperacionesRef',fld:'vTFOPERACIONESREF',pic:'',type:'char'},{av:'AV48TFOperacionesRef_Sel',fld:'vTFOPERACIONESREF_SEL',pic:'',type:'char'},{av:'AV45TFOperacionesNombreRef',fld:'vTFOPERACIONESNOMBREREF',pic:'',type:'char'},{av:'AV46TFOperacionesNombreRef_Sel',fld:'vTFOPERACIONESNOMBREREF_SEL',pic:'',type:'char'},{av:'AV41TFOperacionesImporte',fld:'vTFOPERACIONESIMPORTE',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV42TFOperacionesImporte_To',fld:'vTFOPERACIONESIMPORTE_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43TFOperacionesMoneda',fld:'vTFOPERACIONESMONEDA',pic:'',type:'char'},{av:'AV44TFOperacionesMoneda_Sel',fld:'vTFOPERACIONESMONEDA_SEL',pic:'',type:'char'},{av:'AV33TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV34TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV35TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV36TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV37TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV38TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV31TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E13DM2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV25OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV15FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV39TFOperacionesId',fld:'vTFOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV40TFOperacionesId_To',fld:'vTFOPERACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV47TFOperacionesRef',fld:'vTFOPERACIONESREF',pic:'',type:'char'},{av:'AV48TFOperacionesRef_Sel',fld:'vTFOPERACIONESREF_SEL',pic:'',type:'char'},{av:'AV45TFOperacionesNombreRef',fld:'vTFOPERACIONESNOMBREREF',pic:'',type:'char'},{av:'AV46TFOperacionesNombreRef_Sel',fld:'vTFOPERACIONESNOMBREREF_SEL',pic:'',type:'char'},{av:'AV41TFOperacionesImporte',fld:'vTFOPERACIONESIMPORTE',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV42TFOperacionesImporte_To',fld:'vTFOPERACIONESIMPORTE_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43TFOperacionesMoneda',fld:'vTFOPERACIONESMONEDA',pic:'',type:'char'},{av:'AV44TFOperacionesMoneda_Sel',fld:'vTFOPERACIONESMONEDA_SEL',pic:'',type:'char'},{av:'AV33TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV34TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV35TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV36TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV37TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV38TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV31TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV25OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV31TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'AV37TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV38TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV35TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV36TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV33TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV34TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV43TFOperacionesMoneda',fld:'vTFOPERACIONESMONEDA',pic:'',type:'char'},{av:'AV44TFOperacionesMoneda_Sel',fld:'vTFOPERACIONESMONEDA_SEL',pic:'',type:'char'},{av:'AV41TFOperacionesImporte',fld:'vTFOPERACIONESIMPORTE',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV42TFOperacionesImporte_To',fld:'vTFOPERACIONESIMPORTE_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV45TFOperacionesNombreRef',fld:'vTFOPERACIONESNOMBREREF',pic:'',type:'char'},{av:'AV46TFOperacionesNombreRef_Sel',fld:'vTFOPERACIONESNOMBREREF_SEL',pic:'',type:'char'},{av:'AV47TFOperacionesRef',fld:'vTFOPERACIONESREF',pic:'',type:'char'},{av:'AV48TFOperacionesRef_Sel',fld:'vTFOPERACIONESREF_SEL',pic:'',type:'char'},{av:'AV49TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV39TFOperacionesId',fld:'vTFOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV40TFOperacionesId_To',fld:'vTFOPERACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E17DM2',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV30Select',fld:'vSELECT',pic:'',type:'char'}]}");
         setEventMetadata("ENTER","{handler:'E18DM2',iparms:[{av:'A554OperacionesId',fld:'OPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A657OperacionesNombreRef',fld:'OPERACIONESNOMBREREF',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV22InOutOperacionesId',fld:'vINOUTOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27OutOperacionesNombreRef',fld:'vOUTOPERACIONESNOMBREREF',pic:'',type:'char'}]}");
         setEventMetadata("'DOCLEANFILTERS'","{handler:'E14DM2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV25OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV15FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV39TFOperacionesId',fld:'vTFOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV40TFOperacionesId_To',fld:'vTFOPERACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV47TFOperacionesRef',fld:'vTFOPERACIONESREF',pic:'',type:'char'},{av:'AV48TFOperacionesRef_Sel',fld:'vTFOPERACIONESREF_SEL',pic:'',type:'char'},{av:'AV45TFOperacionesNombreRef',fld:'vTFOPERACIONESNOMBREREF',pic:'',type:'char'},{av:'AV46TFOperacionesNombreRef_Sel',fld:'vTFOPERACIONESNOMBREREF_SEL',pic:'',type:'char'},{av:'AV41TFOperacionesImporte',fld:'vTFOPERACIONESIMPORTE',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV42TFOperacionesImporte_To',fld:'vTFOPERACIONESIMPORTE_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43TFOperacionesMoneda',fld:'vTFOPERACIONESMONEDA',pic:'',type:'char'},{av:'AV44TFOperacionesMoneda_Sel',fld:'vTFOPERACIONESMONEDA_SEL',pic:'',type:'char'},{av:'AV33TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV34TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV35TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV36TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV37TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV38TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV31TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''}]");
         setEventMetadata("'DOCLEANFILTERS'",",oparms:[{av:'AV15FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV39TFOperacionesId',fld:'vTFOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV40TFOperacionesId_To',fld:'vTFOPERACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV47TFOperacionesRef',fld:'vTFOPERACIONESREF',pic:'',type:'char'},{av:'AV48TFOperacionesRef_Sel',fld:'vTFOPERACIONESREF_SEL',pic:'',type:'char'},{av:'AV45TFOperacionesNombreRef',fld:'vTFOPERACIONESNOMBREREF',pic:'',type:'char'},{av:'AV46TFOperacionesNombreRef_Sel',fld:'vTFOPERACIONESNOMBREREF_SEL',pic:'',type:'char'},{av:'AV41TFOperacionesImporte',fld:'vTFOPERACIONESIMPORTE',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV42TFOperacionesImporte_To',fld:'vTFOPERACIONESIMPORTE_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43TFOperacionesMoneda',fld:'vTFOPERACIONESMONEDA',pic:'',type:'char'},{av:'AV44TFOperacionesMoneda_Sel',fld:'vTFOPERACIONESMONEDA_SEL',pic:'',type:'char'},{av:'AV33TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV34TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV35TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV36TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV37TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV38TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV31TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'}]}");
         setEventMetadata("VALID_OPERACIONESID","{handler:'Valid_Operacionesid',iparms:[]");
         setEventMetadata("VALID_OPERACIONESID",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESTIPO","{handler:'Valid_Operacionestipo',iparms:[]");
         setEventMetadata("VALID_OPERACIONESTIPO",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESREF","{handler:'Valid_Operacionesref',iparms:[]");
         setEventMetadata("VALID_OPERACIONESREF",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESNOMBREREF","{handler:'Valid_Operacionesnombreref',iparms:[]");
         setEventMetadata("VALID_OPERACIONESNOMBREREF",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESIMPORTE","{handler:'Valid_Operacionesimporte',iparms:[]");
         setEventMetadata("VALID_OPERACIONESIMPORTE",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESMONEDA","{handler:'Valid_Operacionesmoneda',iparms:[]");
         setEventMetadata("VALID_OPERACIONESMONEDA",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESESTADO","{handler:'Valid_Operacionesestado',iparms:[]");
         setEventMetadata("VALID_OPERACIONESESTADO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Operacionesblob1',iparms:[]");
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
         AV27OutOperacionesNombreRef = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15FilterFullText = "";
         AV54Pgmname = "";
         AV49TFOperacionesTipo_Sels = new GxSimpleCollection<string>();
         AV47TFOperacionesRef = "";
         AV48TFOperacionesRef_Sel = "";
         AV45TFOperacionesNombreRef = "";
         AV46TFOperacionesNombreRef_Sel = "";
         AV43TFOperacionesMoneda = "";
         AV44TFOperacionesMoneda_Sel = "";
         AV33TFOperacionesFechaAlta = DateTime.MinValue;
         AV34TFOperacionesFechaAlta_To = DateTime.MinValue;
         AV35TFOperacionesFechaDesde = DateTime.MinValue;
         AV36TFOperacionesFechaDesde_To = DateTime.MinValue;
         AV37TFOperacionesFechaHasta = DateTime.MinValue;
         AV38TFOperacionesFechaHasta_To = DateTime.MinValue;
         AV31TFOperacionesEstado_Sels = new GxSimpleCollection<string>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV16GridAppliedFilters = "";
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV7DDO_OperacionesFechaAltaAuxDateTo = DateTime.MinValue;
         AV10DDO_OperacionesFechaDesdeAuxDateTo = DateTime.MinValue;
         AV13DDO_OperacionesFechaHastaAuxDateTo = DateTime.MinValue;
         AV5DDO_OperacionesFechaAltaAuxDate = DateTime.MinValue;
         AV8DDO_OperacionesFechaDesdeAuxDate = DateTime.MinValue;
         AV11DDO_OperacionesFechaHastaAuxDate = DateTime.MinValue;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         TempTags = "";
         AV6DDO_OperacionesFechaAltaAuxDateText = "";
         ucTfoperacionesfechaalta_rangepicker = new GXUserControl();
         AV9DDO_OperacionesFechaDesdeAuxDateText = "";
         ucTfoperacionesfechadesde_rangepicker = new GXUserControl();
         AV12DDO_OperacionesFechaHastaAuxDateText = "";
         ucTfoperacionesfechahasta_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV30Select = "";
         A649OperacionesTipo = "";
         A555OperacionesRef = "";
         A657OperacionesNombreRef = "";
         A586OperacionesIDORD = "";
         A569OperacionesTipoES = "";
         A571OperacionesMoneda = "";
         A572OperacionesFacturaCod = "";
         A575OperacionesRequest = "";
         A576OperacionesResponse = "";
         A580OperacionesComprobantePago = "";
         A581OperacionesFechaAlta = DateTime.MinValue;
         A582OperacionesFechaPago = (DateTime)(DateTime.MinValue);
         A583OperacionesAux1 = "";
         A584OperacionesAux2 = "";
         A585OperacionesAux3 = "";
         A658OperacionesFechaDesde = DateTime.MinValue;
         A659OperacionesFechaHasta = DateTime.MinValue;
         A577OperacionesEstado = "";
         A663OperacionesBlob1 = "";
         lV47TFOperacionesRef = "";
         lV45TFOperacionesNombreRef = "";
         lV43TFOperacionesMoneda = "";
         H00DM2_A577OperacionesEstado = new string[] {""} ;
         H00DM2_n577OperacionesEstado = new bool[] {false} ;
         H00DM2_A659OperacionesFechaHasta = new DateTime[] {DateTime.MinValue} ;
         H00DM2_n659OperacionesFechaHasta = new bool[] {false} ;
         H00DM2_A658OperacionesFechaDesde = new DateTime[] {DateTime.MinValue} ;
         H00DM2_n658OperacionesFechaDesde = new bool[] {false} ;
         H00DM2_A585OperacionesAux3 = new string[] {""} ;
         H00DM2_n585OperacionesAux3 = new bool[] {false} ;
         H00DM2_A584OperacionesAux2 = new string[] {""} ;
         H00DM2_n584OperacionesAux2 = new bool[] {false} ;
         H00DM2_A583OperacionesAux1 = new string[] {""} ;
         H00DM2_n583OperacionesAux1 = new bool[] {false} ;
         H00DM2_A582OperacionesFechaPago = new DateTime[] {DateTime.MinValue} ;
         H00DM2_n582OperacionesFechaPago = new bool[] {false} ;
         H00DM2_A581OperacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00DM2_n581OperacionesFechaAlta = new bool[] {false} ;
         H00DM2_A580OperacionesComprobantePago = new string[] {""} ;
         H00DM2_n580OperacionesComprobantePago = new bool[] {false} ;
         H00DM2_A576OperacionesResponse = new string[] {""} ;
         H00DM2_n576OperacionesResponse = new bool[] {false} ;
         H00DM2_A575OperacionesRequest = new string[] {""} ;
         H00DM2_n575OperacionesRequest = new bool[] {false} ;
         H00DM2_A578OperacionesImporteGrabado = new decimal[1] ;
         H00DM2_n578OperacionesImporteGrabado = new bool[] {false} ;
         H00DM2_A574OperacionesComision = new decimal[1] ;
         H00DM2_n574OperacionesComision = new bool[] {false} ;
         H00DM2_A573OperacionesIva = new decimal[1] ;
         H00DM2_n573OperacionesIva = new bool[] {false} ;
         H00DM2_A572OperacionesFacturaCod = new string[] {""} ;
         H00DM2_n572OperacionesFacturaCod = new bool[] {false} ;
         H00DM2_A571OperacionesMoneda = new string[] {""} ;
         H00DM2_n571OperacionesMoneda = new bool[] {false} ;
         H00DM2_A662OperacionesMonId = new long[1] ;
         H00DM2_n662OperacionesMonId = new bool[] {false} ;
         H00DM2_A570OperacionesImporte = new decimal[1] ;
         H00DM2_n570OperacionesImporte = new bool[] {false} ;
         H00DM2_A569OperacionesTipoES = new string[] {""} ;
         H00DM2_n569OperacionesTipoES = new bool[] {false} ;
         H00DM2_A586OperacionesIDORD = new string[] {""} ;
         H00DM2_n586OperacionesIDORD = new bool[] {false} ;
         H00DM2_A579OperacionesOrdinal = new long[1] ;
         H00DM2_n579OperacionesOrdinal = new bool[] {false} ;
         H00DM2_A657OperacionesNombreRef = new string[] {""} ;
         H00DM2_n657OperacionesNombreRef = new bool[] {false} ;
         H00DM2_A555OperacionesRef = new string[] {""} ;
         H00DM2_n555OperacionesRef = new bool[] {false} ;
         H00DM2_A649OperacionesTipo = new string[] {""} ;
         H00DM2_n649OperacionesTipo = new bool[] {false} ;
         H00DM2_A554OperacionesId = new long[1] ;
         H00DM2_A663OperacionesBlob1 = new string[] {""} ;
         H00DM2_n663OperacionesBlob1 = new bool[] {false} ;
         H00DM3_A577OperacionesEstado = new string[] {""} ;
         H00DM3_n577OperacionesEstado = new bool[] {false} ;
         H00DM3_A659OperacionesFechaHasta = new DateTime[] {DateTime.MinValue} ;
         H00DM3_n659OperacionesFechaHasta = new bool[] {false} ;
         H00DM3_A658OperacionesFechaDesde = new DateTime[] {DateTime.MinValue} ;
         H00DM3_n658OperacionesFechaDesde = new bool[] {false} ;
         H00DM3_A585OperacionesAux3 = new string[] {""} ;
         H00DM3_n585OperacionesAux3 = new bool[] {false} ;
         H00DM3_A584OperacionesAux2 = new string[] {""} ;
         H00DM3_n584OperacionesAux2 = new bool[] {false} ;
         H00DM3_A583OperacionesAux1 = new string[] {""} ;
         H00DM3_n583OperacionesAux1 = new bool[] {false} ;
         H00DM3_A582OperacionesFechaPago = new DateTime[] {DateTime.MinValue} ;
         H00DM3_n582OperacionesFechaPago = new bool[] {false} ;
         H00DM3_A581OperacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00DM3_n581OperacionesFechaAlta = new bool[] {false} ;
         H00DM3_A580OperacionesComprobantePago = new string[] {""} ;
         H00DM3_n580OperacionesComprobantePago = new bool[] {false} ;
         H00DM3_A576OperacionesResponse = new string[] {""} ;
         H00DM3_n576OperacionesResponse = new bool[] {false} ;
         H00DM3_A575OperacionesRequest = new string[] {""} ;
         H00DM3_n575OperacionesRequest = new bool[] {false} ;
         H00DM3_A578OperacionesImporteGrabado = new decimal[1] ;
         H00DM3_n578OperacionesImporteGrabado = new bool[] {false} ;
         H00DM3_A574OperacionesComision = new decimal[1] ;
         H00DM3_n574OperacionesComision = new bool[] {false} ;
         H00DM3_A573OperacionesIva = new decimal[1] ;
         H00DM3_n573OperacionesIva = new bool[] {false} ;
         H00DM3_A572OperacionesFacturaCod = new string[] {""} ;
         H00DM3_n572OperacionesFacturaCod = new bool[] {false} ;
         H00DM3_A571OperacionesMoneda = new string[] {""} ;
         H00DM3_n571OperacionesMoneda = new bool[] {false} ;
         H00DM3_A662OperacionesMonId = new long[1] ;
         H00DM3_n662OperacionesMonId = new bool[] {false} ;
         H00DM3_A570OperacionesImporte = new decimal[1] ;
         H00DM3_n570OperacionesImporte = new bool[] {false} ;
         H00DM3_A569OperacionesTipoES = new string[] {""} ;
         H00DM3_n569OperacionesTipoES = new bool[] {false} ;
         H00DM3_A586OperacionesIDORD = new string[] {""} ;
         H00DM3_n586OperacionesIDORD = new bool[] {false} ;
         H00DM3_A579OperacionesOrdinal = new long[1] ;
         H00DM3_n579OperacionesOrdinal = new bool[] {false} ;
         H00DM3_A657OperacionesNombreRef = new string[] {""} ;
         H00DM3_n657OperacionesNombreRef = new bool[] {false} ;
         H00DM3_A555OperacionesRef = new string[] {""} ;
         H00DM3_n555OperacionesRef = new bool[] {false} ;
         H00DM3_A649OperacionesTipo = new string[] {""} ;
         H00DM3_n649OperacionesTipo = new bool[] {false} ;
         H00DM3_A554OperacionesId = new long[1] ;
         H00DM3_A663OperacionesBlob1 = new string[] {""} ;
         H00DM3_n663OperacionesBlob1 = new bool[] {false} ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV52WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_char2 = "";
         AV50TFOperacionesTipo_SelsJson = "";
         AV32TFOperacionesEstado_SelsJson = "";
         GridRow = new GXWebRow();
         AV19GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         lblCleanfilters_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         ClassString = "";
         StyleString = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacionesid2prompt__default(),
            new Object[][] {
                new Object[] {
               H00DM2_A577OperacionesEstado, H00DM2_n577OperacionesEstado, H00DM2_A659OperacionesFechaHasta, H00DM2_n659OperacionesFechaHasta, H00DM2_A658OperacionesFechaDesde, H00DM2_n658OperacionesFechaDesde, H00DM2_A585OperacionesAux3, H00DM2_n585OperacionesAux3, H00DM2_A584OperacionesAux2, H00DM2_n584OperacionesAux2,
               H00DM2_A583OperacionesAux1, H00DM2_n583OperacionesAux1, H00DM2_A582OperacionesFechaPago, H00DM2_n582OperacionesFechaPago, H00DM2_A581OperacionesFechaAlta, H00DM2_n581OperacionesFechaAlta, H00DM2_A580OperacionesComprobantePago, H00DM2_n580OperacionesComprobantePago, H00DM2_A576OperacionesResponse, H00DM2_n576OperacionesResponse,
               H00DM2_A575OperacionesRequest, H00DM2_n575OperacionesRequest, H00DM2_A578OperacionesImporteGrabado, H00DM2_n578OperacionesImporteGrabado, H00DM2_A574OperacionesComision, H00DM2_n574OperacionesComision, H00DM2_A573OperacionesIva, H00DM2_n573OperacionesIva, H00DM2_A572OperacionesFacturaCod, H00DM2_n572OperacionesFacturaCod,
               H00DM2_A571OperacionesMoneda, H00DM2_n571OperacionesMoneda, H00DM2_A662OperacionesMonId, H00DM2_n662OperacionesMonId, H00DM2_A570OperacionesImporte, H00DM2_n570OperacionesImporte, H00DM2_A569OperacionesTipoES, H00DM2_n569OperacionesTipoES, H00DM2_A586OperacionesIDORD, H00DM2_n586OperacionesIDORD,
               H00DM2_A579OperacionesOrdinal, H00DM2_n579OperacionesOrdinal, H00DM2_A657OperacionesNombreRef, H00DM2_n657OperacionesNombreRef, H00DM2_A555OperacionesRef, H00DM2_n555OperacionesRef, H00DM2_A649OperacionesTipo, H00DM2_n649OperacionesTipo, H00DM2_A554OperacionesId, H00DM2_A663OperacionesBlob1,
               H00DM2_n663OperacionesBlob1
               }
               , new Object[] {
               H00DM3_A577OperacionesEstado, H00DM3_n577OperacionesEstado, H00DM3_A659OperacionesFechaHasta, H00DM3_n659OperacionesFechaHasta, H00DM3_A658OperacionesFechaDesde, H00DM3_n658OperacionesFechaDesde, H00DM3_A585OperacionesAux3, H00DM3_n585OperacionesAux3, H00DM3_A584OperacionesAux2, H00DM3_n584OperacionesAux2,
               H00DM3_A583OperacionesAux1, H00DM3_n583OperacionesAux1, H00DM3_A582OperacionesFechaPago, H00DM3_n582OperacionesFechaPago, H00DM3_A581OperacionesFechaAlta, H00DM3_n581OperacionesFechaAlta, H00DM3_A580OperacionesComprobantePago, H00DM3_n580OperacionesComprobantePago, H00DM3_A576OperacionesResponse, H00DM3_n576OperacionesResponse,
               H00DM3_A575OperacionesRequest, H00DM3_n575OperacionesRequest, H00DM3_A578OperacionesImporteGrabado, H00DM3_n578OperacionesImporteGrabado, H00DM3_A574OperacionesComision, H00DM3_n574OperacionesComision, H00DM3_A573OperacionesIva, H00DM3_n573OperacionesIva, H00DM3_A572OperacionesFacturaCod, H00DM3_n572OperacionesFacturaCod,
               H00DM3_A571OperacionesMoneda, H00DM3_n571OperacionesMoneda, H00DM3_A662OperacionesMonId, H00DM3_n662OperacionesMonId, H00DM3_A570OperacionesImporte, H00DM3_n570OperacionesImporte, H00DM3_A569OperacionesTipoES, H00DM3_n569OperacionesTipoES, H00DM3_A586OperacionesIDORD, H00DM3_n586OperacionesIDORD,
               H00DM3_A579OperacionesOrdinal, H00DM3_n579OperacionesOrdinal, H00DM3_A657OperacionesNombreRef, H00DM3_n657OperacionesNombreRef, H00DM3_A555OperacionesRef, H00DM3_n555OperacionesRef, H00DM3_A649OperacionesTipo, H00DM3_n649OperacionesTipo, H00DM3_A554OperacionesId, H00DM3_A663OperacionesBlob1,
               H00DM3_n663OperacionesBlob1
               }
            }
         );
         AV54Pgmname = "OperacionesId2Prompt";
         /* GeneXus formulas. */
         AV54Pgmname = "OperacionesId2Prompt";
         edtavSelect_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV24OrderedBy ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_26 ;
      private int subGrid_Rows ;
      private int nGXsfl_26_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Islastpage ;
      private int edtavSelect_Enabled ;
      private int AV49TFOperacionesTipo_Sels_Count ;
      private int AV31TFOperacionesEstado_Sels_Count ;
      private int edtOperacionesId_Enabled ;
      private int edtOperacionesRef_Enabled ;
      private int edtOperacionesNombreRef_Enabled ;
      private int edtOperacionesOrdinal_Enabled ;
      private int edtOperacionesIDORD_Enabled ;
      private int edtOperacionesImporte_Enabled ;
      private int edtOperacionesMonId_Enabled ;
      private int edtOperacionesMoneda_Enabled ;
      private int edtOperacionesFacturaCod_Enabled ;
      private int edtOperacionesIva_Enabled ;
      private int edtOperacionesComision_Enabled ;
      private int edtOperacionesImporteGrabado_Enabled ;
      private int edtOperacionesRequest_Enabled ;
      private int edtOperacionesResponse_Enabled ;
      private int edtOperacionesComprobantePago_Enabled ;
      private int edtOperacionesFechaAlta_Enabled ;
      private int edtOperacionesFechaPago_Enabled ;
      private int edtOperacionesAux1_Enabled ;
      private int edtOperacionesAux2_Enabled ;
      private int edtOperacionesAux3_Enabled ;
      private int edtOperacionesFechaDesde_Enabled ;
      private int edtOperacionesFechaHasta_Enabled ;
      private int edtOperacionesBlob1_Enabled ;
      private int AV28PageToGo ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV22InOutOperacionesId ;
      private long wcpOAV22InOutOperacionesId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV39TFOperacionesId ;
      private long AV40TFOperacionesId_To ;
      private long AV17GridCurrentPage ;
      private long AV18GridPageCount ;
      private long A554OperacionesId ;
      private long A579OperacionesOrdinal ;
      private long A662OperacionesMonId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV41TFOperacionesImporte ;
      private decimal AV42TFOperacionesImporte_To ;
      private decimal A570OperacionesImporte ;
      private decimal A573OperacionesIva ;
      private decimal A574OperacionesComision ;
      private decimal A578OperacionesImporteGrabado ;
      private string AV27OutOperacionesNombreRef ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_26_idx="0001" ;
      private string AV54Pgmname ;
      private string AV47TFOperacionesRef ;
      private string AV48TFOperacionesRef_Sel ;
      private string AV45TFOperacionesNombreRef ;
      private string AV46TFOperacionesNombreRef_Sel ;
      private string AV43TFOperacionesMoneda ;
      private string AV44TFOperacionesMoneda_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_operacionesfechaaltaauxdates_Internalname ;
      private string TempTags ;
      private string edtavDdo_operacionesfechaaltaauxdatetext_Internalname ;
      private string edtavDdo_operacionesfechaaltaauxdatetext_Jsonclick ;
      private string Tfoperacionesfechaalta_rangepicker_Internalname ;
      private string divDdo_operacionesfechadesdeauxdates_Internalname ;
      private string edtavDdo_operacionesfechadesdeauxdatetext_Internalname ;
      private string edtavDdo_operacionesfechadesdeauxdatetext_Jsonclick ;
      private string Tfoperacionesfechadesde_rangepicker_Internalname ;
      private string divDdo_operacionesfechahastaauxdates_Internalname ;
      private string edtavDdo_operacionesfechahastaauxdatetext_Internalname ;
      private string edtavDdo_operacionesfechahastaauxdatetext_Jsonclick ;
      private string Tfoperacionesfechahasta_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV30Select ;
      private string edtavSelect_Internalname ;
      private string edtOperacionesId_Internalname ;
      private string cmbOperacionesTipo_Internalname ;
      private string A649OperacionesTipo ;
      private string A555OperacionesRef ;
      private string edtOperacionesRef_Internalname ;
      private string A657OperacionesNombreRef ;
      private string edtOperacionesNombreRef_Internalname ;
      private string edtOperacionesOrdinal_Internalname ;
      private string A586OperacionesIDORD ;
      private string edtOperacionesIDORD_Internalname ;
      private string cmbOperacionesTipoES_Internalname ;
      private string A569OperacionesTipoES ;
      private string edtOperacionesImporte_Internalname ;
      private string edtOperacionesMonId_Internalname ;
      private string A571OperacionesMoneda ;
      private string edtOperacionesMoneda_Internalname ;
      private string A572OperacionesFacturaCod ;
      private string edtOperacionesFacturaCod_Internalname ;
      private string edtOperacionesIva_Internalname ;
      private string edtOperacionesComision_Internalname ;
      private string edtOperacionesImporteGrabado_Internalname ;
      private string edtOperacionesRequest_Internalname ;
      private string edtOperacionesResponse_Internalname ;
      private string A580OperacionesComprobantePago ;
      private string edtOperacionesComprobantePago_Internalname ;
      private string edtOperacionesFechaAlta_Internalname ;
      private string edtOperacionesFechaPago_Internalname ;
      private string edtOperacionesAux1_Internalname ;
      private string edtOperacionesAux2_Internalname ;
      private string edtOperacionesAux3_Internalname ;
      private string edtOperacionesFechaDesde_Internalname ;
      private string edtOperacionesFechaHasta_Internalname ;
      private string cmbOperacionesEstado_Internalname ;
      private string A577OperacionesEstado ;
      private string edtOperacionesBlob1_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string lV47TFOperacionesRef ;
      private string lV45TFOperacionesNombreRef ;
      private string lV43TFOperacionesMoneda ;
      private string GXt_char2 ;
      private string tblTablefilters_Internalname ;
      private string lblCleanfilters_Internalname ;
      private string lblCleanfilters_Jsonclick ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_26_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavSelect_Jsonclick ;
      private string edtOperacionesId_Jsonclick ;
      private string GXCCtl ;
      private string cmbOperacionesTipo_Jsonclick ;
      private string edtOperacionesRef_Jsonclick ;
      private string edtOperacionesNombreRef_Jsonclick ;
      private string edtOperacionesOrdinal_Jsonclick ;
      private string edtOperacionesIDORD_Jsonclick ;
      private string cmbOperacionesTipoES_Jsonclick ;
      private string edtOperacionesImporte_Jsonclick ;
      private string edtOperacionesMonId_Jsonclick ;
      private string edtOperacionesMoneda_Jsonclick ;
      private string edtOperacionesFacturaCod_Jsonclick ;
      private string edtOperacionesIva_Jsonclick ;
      private string edtOperacionesComision_Jsonclick ;
      private string edtOperacionesImporteGrabado_Jsonclick ;
      private string edtOperacionesRequest_Jsonclick ;
      private string edtOperacionesResponse_Jsonclick ;
      private string edtOperacionesComprobantePago_Jsonclick ;
      private string edtOperacionesFechaAlta_Jsonclick ;
      private string edtOperacionesFechaPago_Jsonclick ;
      private string edtOperacionesAux1_Jsonclick ;
      private string edtOperacionesAux2_Jsonclick ;
      private string edtOperacionesAux3_Jsonclick ;
      private string edtOperacionesFechaDesde_Jsonclick ;
      private string edtOperacionesFechaHasta_Jsonclick ;
      private string cmbOperacionesEstado_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string edtOperacionesBlob1_Filetype ;
      private string edtOperacionesBlob1_Contenttype ;
      private string edtOperacionesBlob1_Parameters ;
      private string edtOperacionesBlob1_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A582OperacionesFechaPago ;
      private DateTime AV33TFOperacionesFechaAlta ;
      private DateTime AV34TFOperacionesFechaAlta_To ;
      private DateTime AV35TFOperacionesFechaDesde ;
      private DateTime AV36TFOperacionesFechaDesde_To ;
      private DateTime AV37TFOperacionesFechaHasta ;
      private DateTime AV38TFOperacionesFechaHasta_To ;
      private DateTime AV7DDO_OperacionesFechaAltaAuxDateTo ;
      private DateTime AV10DDO_OperacionesFechaDesdeAuxDateTo ;
      private DateTime AV13DDO_OperacionesFechaHastaAuxDateTo ;
      private DateTime AV5DDO_OperacionesFechaAltaAuxDate ;
      private DateTime AV8DDO_OperacionesFechaDesdeAuxDate ;
      private DateTime AV11DDO_OperacionesFechaHastaAuxDate ;
      private DateTime A581OperacionesFechaAlta ;
      private DateTime A658OperacionesFechaDesde ;
      private DateTime A659OperacionesFechaHasta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV25OrderedDsc ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n649OperacionesTipo ;
      private bool n555OperacionesRef ;
      private bool n657OperacionesNombreRef ;
      private bool n579OperacionesOrdinal ;
      private bool n586OperacionesIDORD ;
      private bool n569OperacionesTipoES ;
      private bool n570OperacionesImporte ;
      private bool n662OperacionesMonId ;
      private bool n571OperacionesMoneda ;
      private bool n572OperacionesFacturaCod ;
      private bool n573OperacionesIva ;
      private bool n574OperacionesComision ;
      private bool n578OperacionesImporteGrabado ;
      private bool n575OperacionesRequest ;
      private bool n576OperacionesResponse ;
      private bool n580OperacionesComprobantePago ;
      private bool n581OperacionesFechaAlta ;
      private bool n582OperacionesFechaPago ;
      private bool n583OperacionesAux1 ;
      private bool n584OperacionesAux2 ;
      private bool n585OperacionesAux3 ;
      private bool n658OperacionesFechaDesde ;
      private bool n659OperacionesFechaHasta ;
      private bool n577OperacionesEstado ;
      private bool n663OperacionesBlob1 ;
      private bool bGXsfl_26_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string A575OperacionesRequest ;
      private string A576OperacionesResponse ;
      private string A585OperacionesAux3 ;
      private string AV50TFOperacionesTipo_SelsJson ;
      private string AV32TFOperacionesEstado_SelsJson ;
      private string AV15FilterFullText ;
      private string AV16GridAppliedFilters ;
      private string AV6DDO_OperacionesFechaAltaAuxDateText ;
      private string AV9DDO_OperacionesFechaDesdeAuxDateText ;
      private string AV12DDO_OperacionesFechaHastaAuxDateText ;
      private string A583OperacionesAux1 ;
      private string A584OperacionesAux2 ;
      private string A663OperacionesBlob1 ;
      private GxFile gxblobfileaux ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfoperacionesfechaalta_rangepicker ;
      private GXUserControl ucTfoperacionesfechadesde_rangepicker ;
      private GXUserControl ucTfoperacionesfechahasta_rangepicker ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private long aP0_InOutOperacionesId ;
      private GXCombobox cmbOperacionesTipo ;
      private GXCombobox cmbOperacionesTipoES ;
      private GXCombobox cmbOperacionesEstado ;
      private GxSimpleCollection<string> AV49TFOperacionesTipo_Sels ;
      private GxSimpleCollection<string> AV31TFOperacionesEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H00DM2_A577OperacionesEstado ;
      private bool[] H00DM2_n577OperacionesEstado ;
      private DateTime[] H00DM2_A659OperacionesFechaHasta ;
      private bool[] H00DM2_n659OperacionesFechaHasta ;
      private DateTime[] H00DM2_A658OperacionesFechaDesde ;
      private bool[] H00DM2_n658OperacionesFechaDesde ;
      private string[] H00DM2_A585OperacionesAux3 ;
      private bool[] H00DM2_n585OperacionesAux3 ;
      private string[] H00DM2_A584OperacionesAux2 ;
      private bool[] H00DM2_n584OperacionesAux2 ;
      private string[] H00DM2_A583OperacionesAux1 ;
      private bool[] H00DM2_n583OperacionesAux1 ;
      private DateTime[] H00DM2_A582OperacionesFechaPago ;
      private bool[] H00DM2_n582OperacionesFechaPago ;
      private DateTime[] H00DM2_A581OperacionesFechaAlta ;
      private bool[] H00DM2_n581OperacionesFechaAlta ;
      private string[] H00DM2_A580OperacionesComprobantePago ;
      private bool[] H00DM2_n580OperacionesComprobantePago ;
      private string[] H00DM2_A576OperacionesResponse ;
      private bool[] H00DM2_n576OperacionesResponse ;
      private string[] H00DM2_A575OperacionesRequest ;
      private bool[] H00DM2_n575OperacionesRequest ;
      private decimal[] H00DM2_A578OperacionesImporteGrabado ;
      private bool[] H00DM2_n578OperacionesImporteGrabado ;
      private decimal[] H00DM2_A574OperacionesComision ;
      private bool[] H00DM2_n574OperacionesComision ;
      private decimal[] H00DM2_A573OperacionesIva ;
      private bool[] H00DM2_n573OperacionesIva ;
      private string[] H00DM2_A572OperacionesFacturaCod ;
      private bool[] H00DM2_n572OperacionesFacturaCod ;
      private string[] H00DM2_A571OperacionesMoneda ;
      private bool[] H00DM2_n571OperacionesMoneda ;
      private long[] H00DM2_A662OperacionesMonId ;
      private bool[] H00DM2_n662OperacionesMonId ;
      private decimal[] H00DM2_A570OperacionesImporte ;
      private bool[] H00DM2_n570OperacionesImporte ;
      private string[] H00DM2_A569OperacionesTipoES ;
      private bool[] H00DM2_n569OperacionesTipoES ;
      private string[] H00DM2_A586OperacionesIDORD ;
      private bool[] H00DM2_n586OperacionesIDORD ;
      private long[] H00DM2_A579OperacionesOrdinal ;
      private bool[] H00DM2_n579OperacionesOrdinal ;
      private string[] H00DM2_A657OperacionesNombreRef ;
      private bool[] H00DM2_n657OperacionesNombreRef ;
      private string[] H00DM2_A555OperacionesRef ;
      private bool[] H00DM2_n555OperacionesRef ;
      private string[] H00DM2_A649OperacionesTipo ;
      private bool[] H00DM2_n649OperacionesTipo ;
      private long[] H00DM2_A554OperacionesId ;
      private string[] H00DM2_A663OperacionesBlob1 ;
      private bool[] H00DM2_n663OperacionesBlob1 ;
      private string[] H00DM3_A577OperacionesEstado ;
      private bool[] H00DM3_n577OperacionesEstado ;
      private DateTime[] H00DM3_A659OperacionesFechaHasta ;
      private bool[] H00DM3_n659OperacionesFechaHasta ;
      private DateTime[] H00DM3_A658OperacionesFechaDesde ;
      private bool[] H00DM3_n658OperacionesFechaDesde ;
      private string[] H00DM3_A585OperacionesAux3 ;
      private bool[] H00DM3_n585OperacionesAux3 ;
      private string[] H00DM3_A584OperacionesAux2 ;
      private bool[] H00DM3_n584OperacionesAux2 ;
      private string[] H00DM3_A583OperacionesAux1 ;
      private bool[] H00DM3_n583OperacionesAux1 ;
      private DateTime[] H00DM3_A582OperacionesFechaPago ;
      private bool[] H00DM3_n582OperacionesFechaPago ;
      private DateTime[] H00DM3_A581OperacionesFechaAlta ;
      private bool[] H00DM3_n581OperacionesFechaAlta ;
      private string[] H00DM3_A580OperacionesComprobantePago ;
      private bool[] H00DM3_n580OperacionesComprobantePago ;
      private string[] H00DM3_A576OperacionesResponse ;
      private bool[] H00DM3_n576OperacionesResponse ;
      private string[] H00DM3_A575OperacionesRequest ;
      private bool[] H00DM3_n575OperacionesRequest ;
      private decimal[] H00DM3_A578OperacionesImporteGrabado ;
      private bool[] H00DM3_n578OperacionesImporteGrabado ;
      private decimal[] H00DM3_A574OperacionesComision ;
      private bool[] H00DM3_n574OperacionesComision ;
      private decimal[] H00DM3_A573OperacionesIva ;
      private bool[] H00DM3_n573OperacionesIva ;
      private string[] H00DM3_A572OperacionesFacturaCod ;
      private bool[] H00DM3_n572OperacionesFacturaCod ;
      private string[] H00DM3_A571OperacionesMoneda ;
      private bool[] H00DM3_n571OperacionesMoneda ;
      private long[] H00DM3_A662OperacionesMonId ;
      private bool[] H00DM3_n662OperacionesMonId ;
      private decimal[] H00DM3_A570OperacionesImporte ;
      private bool[] H00DM3_n570OperacionesImporte ;
      private string[] H00DM3_A569OperacionesTipoES ;
      private bool[] H00DM3_n569OperacionesTipoES ;
      private string[] H00DM3_A586OperacionesIDORD ;
      private bool[] H00DM3_n586OperacionesIDORD ;
      private long[] H00DM3_A579OperacionesOrdinal ;
      private bool[] H00DM3_n579OperacionesOrdinal ;
      private string[] H00DM3_A657OperacionesNombreRef ;
      private bool[] H00DM3_n657OperacionesNombreRef ;
      private string[] H00DM3_A555OperacionesRef ;
      private bool[] H00DM3_n555OperacionesRef ;
      private string[] H00DM3_A649OperacionesTipo ;
      private bool[] H00DM3_n649OperacionesTipo ;
      private long[] H00DM3_A554OperacionesId ;
      private string[] H00DM3_A663OperacionesBlob1 ;
      private bool[] H00DM3_n663OperacionesBlob1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV52WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV19GridState ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string aP1_OutOperacionesNombreRef ;
   }

   public class operacionesid2prompt__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00DM2( IGxContext context ,
                                             string A649OperacionesTipo ,
                                             GxSimpleCollection<string> AV49TFOperacionesTipo_Sels ,
                                             string A577OperacionesEstado ,
                                             GxSimpleCollection<string> AV31TFOperacionesEstado_Sels ,
                                             long AV39TFOperacionesId ,
                                             long AV40TFOperacionesId_To ,
                                             int AV49TFOperacionesTipo_Sels_Count ,
                                             string AV48TFOperacionesRef_Sel ,
                                             string AV47TFOperacionesRef ,
                                             string AV46TFOperacionesNombreRef_Sel ,
                                             string AV45TFOperacionesNombreRef ,
                                             decimal AV41TFOperacionesImporte ,
                                             decimal AV42TFOperacionesImporte_To ,
                                             string AV44TFOperacionesMoneda_Sel ,
                                             string AV43TFOperacionesMoneda ,
                                             DateTime AV33TFOperacionesFechaAlta ,
                                             DateTime AV34TFOperacionesFechaAlta_To ,
                                             DateTime AV35TFOperacionesFechaDesde ,
                                             DateTime AV36TFOperacionesFechaDesde_To ,
                                             DateTime AV37TFOperacionesFechaHasta ,
                                             DateTime AV38TFOperacionesFechaHasta_To ,
                                             int AV31TFOperacionesEstado_Sels_Count ,
                                             long A554OperacionesId ,
                                             string A555OperacionesRef ,
                                             string A657OperacionesNombreRef ,
                                             decimal A570OperacionesImporte ,
                                             string A571OperacionesMoneda ,
                                             DateTime A581OperacionesFechaAlta ,
                                             DateTime A658OperacionesFechaDesde ,
                                             DateTime A659OperacionesFechaHasta ,
                                             short AV24OrderedBy ,
                                             bool AV25OrderedDsc ,
                                             string AV15FilterFullText )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [OperacionesEstado], [OperacionesFechaHasta], [OperacionesFechaDesde], [OperacionesAux3], [OperacionesAux2], [OperacionesAux1], [OperacionesFechaPago], [OperacionesFechaAlta], [OperacionesComprobantePago], [OperacionesResponse], [OperacionesRequest], [OperacionesImporteGrabado], [OperacionesComision], [OperacionesIva], [OperacionesFacturaCod], [OperacionesMoneda], [OperacionesMonId], [OperacionesImporte], [OperacionesTipoES], [OperacionesIDORD], [OperacionesOrdinal], [OperacionesNombreRef], [OperacionesRef], [OperacionesTipo], [OperacionesId], [OperacionesBlob1] FROM [Operaciones]";
         AddWhere(sWhereString, "([OperacionesEstado] = 'PND')");
         AddWhere(sWhereString, "([OperacionesImporte] > 0)");
         if ( ! (0==AV39TFOperacionesId) )
         {
            AddWhere(sWhereString, "([OperacionesId] >= @AV39TFOperacionesId)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV40TFOperacionesId_To) )
         {
            AddWhere(sWhereString, "([OperacionesId] <= @AV40TFOperacionesId_To)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV49TFOperacionesTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV49TFOperacionesTipo_Sels, "[OperacionesTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFOperacionesRef_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFOperacionesRef)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesRef]) like UPPER(@lV47TFOperacionesRef))");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFOperacionesRef_Sel)) && ! ( StringUtil.StrCmp(AV48TFOperacionesRef_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesRef] = @AV48TFOperacionesRef_Sel)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV48TFOperacionesRef_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesRef] IS NULL or ([OperacionesRef] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFOperacionesNombreRef_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFOperacionesNombreRef)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesNombreRef]) like UPPER(@lV45TFOperacionesNombreRef))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46TFOperacionesNombreRef_Sel)) && ! ( StringUtil.StrCmp(AV46TFOperacionesNombreRef_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesNombreRef] = @AV46TFOperacionesNombreRef_Sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46TFOperacionesNombreRef_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesNombreRef] IS NULL or ([OperacionesNombreRef] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV41TFOperacionesImporte) )
         {
            AddWhere(sWhereString, "([OperacionesImporte] >= @AV41TFOperacionesImporte)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV42TFOperacionesImporte_To) )
         {
            AddWhere(sWhereString, "([OperacionesImporte] <= @AV42TFOperacionesImporte_To)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFOperacionesMoneda_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFOperacionesMoneda)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesMoneda]) like UPPER(@lV43TFOperacionesMoneda))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFOperacionesMoneda_Sel)) && ! ( StringUtil.StrCmp(AV44TFOperacionesMoneda_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesMoneda] = @AV44TFOperacionesMoneda_Sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV44TFOperacionesMoneda_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesMoneda] IS NULL or ([OperacionesMoneda] = ''))");
         }
         if ( ! (DateTime.MinValue==AV33TFOperacionesFechaAlta) )
         {
            AddWhere(sWhereString, "([OperacionesFechaAlta] >= @AV33TFOperacionesFechaAlta)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV34TFOperacionesFechaAlta_To) )
         {
            AddWhere(sWhereString, "([OperacionesFechaAlta] <= @AV34TFOperacionesFechaAlta_To)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV35TFOperacionesFechaDesde) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] >= @AV35TFOperacionesFechaDesde)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV36TFOperacionesFechaDesde_To) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] <= @AV36TFOperacionesFechaDesde_To)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV37TFOperacionesFechaHasta) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] >= @AV37TFOperacionesFechaHasta)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV38TFOperacionesFechaHasta_To) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] <= @AV38TFOperacionesFechaHasta_To)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV31TFOperacionesEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV31TFOperacionesEstado_Sels, "[OperacionesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV24OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [OperacionesId] DESC, [OperacionesTipo]";
         }
         else if ( ( AV24OrderedBy == 2 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesId]";
         }
         else if ( ( AV24OrderedBy == 2 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesId] DESC";
         }
         else if ( ( AV24OrderedBy == 3 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo]";
         }
         else if ( ( AV24OrderedBy == 3 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC";
         }
         else if ( ( AV24OrderedBy == 4 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesRef]";
         }
         else if ( ( AV24OrderedBy == 4 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesRef] DESC";
         }
         else if ( ( AV24OrderedBy == 5 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesNombreRef]";
         }
         else if ( ( AV24OrderedBy == 5 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesNombreRef] DESC";
         }
         else if ( ( AV24OrderedBy == 6 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesImporte]";
         }
         else if ( ( AV24OrderedBy == 6 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesImporte] DESC";
         }
         else if ( ( AV24OrderedBy == 7 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesMoneda]";
         }
         else if ( ( AV24OrderedBy == 7 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesMoneda] DESC";
         }
         else if ( ( AV24OrderedBy == 8 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesFechaAlta]";
         }
         else if ( ( AV24OrderedBy == 8 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesFechaAlta] DESC";
         }
         else if ( ( AV24OrderedBy == 9 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesFechaDesde]";
         }
         else if ( ( AV24OrderedBy == 9 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesFechaDesde] DESC";
         }
         else if ( ( AV24OrderedBy == 10 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesFechaHasta]";
         }
         else if ( ( AV24OrderedBy == 10 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesFechaHasta] DESC";
         }
         else if ( ( AV24OrderedBy == 11 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesEstado]";
         }
         else if ( ( AV24OrderedBy == 11 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesEstado] DESC";
         }
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H00DM3( IGxContext context ,
                                             string A649OperacionesTipo ,
                                             GxSimpleCollection<string> AV49TFOperacionesTipo_Sels ,
                                             string A577OperacionesEstado ,
                                             GxSimpleCollection<string> AV31TFOperacionesEstado_Sels ,
                                             long AV39TFOperacionesId ,
                                             long AV40TFOperacionesId_To ,
                                             int AV49TFOperacionesTipo_Sels_Count ,
                                             string AV48TFOperacionesRef_Sel ,
                                             string AV47TFOperacionesRef ,
                                             string AV46TFOperacionesNombreRef_Sel ,
                                             string AV45TFOperacionesNombreRef ,
                                             decimal AV41TFOperacionesImporte ,
                                             decimal AV42TFOperacionesImporte_To ,
                                             string AV44TFOperacionesMoneda_Sel ,
                                             string AV43TFOperacionesMoneda ,
                                             DateTime AV33TFOperacionesFechaAlta ,
                                             DateTime AV34TFOperacionesFechaAlta_To ,
                                             DateTime AV35TFOperacionesFechaDesde ,
                                             DateTime AV36TFOperacionesFechaDesde_To ,
                                             DateTime AV37TFOperacionesFechaHasta ,
                                             DateTime AV38TFOperacionesFechaHasta_To ,
                                             int AV31TFOperacionesEstado_Sels_Count ,
                                             long A554OperacionesId ,
                                             string A555OperacionesRef ,
                                             string A657OperacionesNombreRef ,
                                             decimal A570OperacionesImporte ,
                                             string A571OperacionesMoneda ,
                                             DateTime A581OperacionesFechaAlta ,
                                             DateTime A658OperacionesFechaDesde ,
                                             DateTime A659OperacionesFechaHasta ,
                                             short AV24OrderedBy ,
                                             bool AV25OrderedDsc ,
                                             string AV15FilterFullText )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[16];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [OperacionesEstado], [OperacionesFechaHasta], [OperacionesFechaDesde], [OperacionesAux3], [OperacionesAux2], [OperacionesAux1], [OperacionesFechaPago], [OperacionesFechaAlta], [OperacionesComprobantePago], [OperacionesResponse], [OperacionesRequest], [OperacionesImporteGrabado], [OperacionesComision], [OperacionesIva], [OperacionesFacturaCod], [OperacionesMoneda], [OperacionesMonId], [OperacionesImporte], [OperacionesTipoES], [OperacionesIDORD], [OperacionesOrdinal], [OperacionesNombreRef], [OperacionesRef], [OperacionesTipo], [OperacionesId], [OperacionesBlob1] FROM [Operaciones]";
         AddWhere(sWhereString, "([OperacionesEstado] = 'PND')");
         AddWhere(sWhereString, "([OperacionesImporte] > 0)");
         if ( ! (0==AV39TFOperacionesId) )
         {
            AddWhere(sWhereString, "([OperacionesId] >= @AV39TFOperacionesId)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (0==AV40TFOperacionesId_To) )
         {
            AddWhere(sWhereString, "([OperacionesId] <= @AV40TFOperacionesId_To)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( AV49TFOperacionesTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV49TFOperacionesTipo_Sels, "[OperacionesTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFOperacionesRef_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFOperacionesRef)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesRef]) like UPPER(@lV47TFOperacionesRef))");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFOperacionesRef_Sel)) && ! ( StringUtil.StrCmp(AV48TFOperacionesRef_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesRef] = @AV48TFOperacionesRef_Sel)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV48TFOperacionesRef_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesRef] IS NULL or ([OperacionesRef] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFOperacionesNombreRef_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFOperacionesNombreRef)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesNombreRef]) like UPPER(@lV45TFOperacionesNombreRef))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46TFOperacionesNombreRef_Sel)) && ! ( StringUtil.StrCmp(AV46TFOperacionesNombreRef_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesNombreRef] = @AV46TFOperacionesNombreRef_Sel)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46TFOperacionesNombreRef_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesNombreRef] IS NULL or ([OperacionesNombreRef] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV41TFOperacionesImporte) )
         {
            AddWhere(sWhereString, "([OperacionesImporte] >= @AV41TFOperacionesImporte)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV42TFOperacionesImporte_To) )
         {
            AddWhere(sWhereString, "([OperacionesImporte] <= @AV42TFOperacionesImporte_To)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFOperacionesMoneda_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFOperacionesMoneda)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesMoneda]) like UPPER(@lV43TFOperacionesMoneda))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFOperacionesMoneda_Sel)) && ! ( StringUtil.StrCmp(AV44TFOperacionesMoneda_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesMoneda] = @AV44TFOperacionesMoneda_Sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV44TFOperacionesMoneda_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesMoneda] IS NULL or ([OperacionesMoneda] = ''))");
         }
         if ( ! (DateTime.MinValue==AV33TFOperacionesFechaAlta) )
         {
            AddWhere(sWhereString, "([OperacionesFechaAlta] >= @AV33TFOperacionesFechaAlta)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV34TFOperacionesFechaAlta_To) )
         {
            AddWhere(sWhereString, "([OperacionesFechaAlta] <= @AV34TFOperacionesFechaAlta_To)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV35TFOperacionesFechaDesde) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] >= @AV35TFOperacionesFechaDesde)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV36TFOperacionesFechaDesde_To) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] <= @AV36TFOperacionesFechaDesde_To)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV37TFOperacionesFechaHasta) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] >= @AV37TFOperacionesFechaHasta)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV38TFOperacionesFechaHasta_To) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] <= @AV38TFOperacionesFechaHasta_To)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV31TFOperacionesEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV31TFOperacionesEstado_Sels, "[OperacionesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV24OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [OperacionesId] DESC, [OperacionesTipo]";
         }
         else if ( ( AV24OrderedBy == 2 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesId]";
         }
         else if ( ( AV24OrderedBy == 2 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesId] DESC";
         }
         else if ( ( AV24OrderedBy == 3 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo]";
         }
         else if ( ( AV24OrderedBy == 3 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC";
         }
         else if ( ( AV24OrderedBy == 4 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesRef]";
         }
         else if ( ( AV24OrderedBy == 4 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesRef] DESC";
         }
         else if ( ( AV24OrderedBy == 5 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesNombreRef]";
         }
         else if ( ( AV24OrderedBy == 5 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesNombreRef] DESC";
         }
         else if ( ( AV24OrderedBy == 6 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesImporte]";
         }
         else if ( ( AV24OrderedBy == 6 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesImporte] DESC";
         }
         else if ( ( AV24OrderedBy == 7 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesMoneda]";
         }
         else if ( ( AV24OrderedBy == 7 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesMoneda] DESC";
         }
         else if ( ( AV24OrderedBy == 8 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesFechaAlta]";
         }
         else if ( ( AV24OrderedBy == 8 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesFechaAlta] DESC";
         }
         else if ( ( AV24OrderedBy == 9 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesFechaDesde]";
         }
         else if ( ( AV24OrderedBy == 9 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesFechaDesde] DESC";
         }
         else if ( ( AV24OrderedBy == 10 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesFechaHasta]";
         }
         else if ( ( AV24OrderedBy == 10 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesFechaHasta] DESC";
         }
         else if ( ( AV24OrderedBy == 11 ) && ! AV25OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesEstado]";
         }
         else if ( ( AV24OrderedBy == 11 ) && ( AV25OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesEstado] DESC";
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
                     return conditional_H00DM2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (int)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (short)dynConstraints[30] , (bool)dynConstraints[31] , (string)dynConstraints[32] );
               case 1 :
                     return conditional_H00DM3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (int)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (short)dynConstraints[30] , (bool)dynConstraints[31] , (string)dynConstraints[32] );
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
          Object[] prmH00DM2;
          prmH00DM2 = new Object[] {
          new ParDef("@AV39TFOperacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV40TFOperacionesId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV47TFOperacionesRef",GXType.Char,25,0) ,
          new ParDef("@AV48TFOperacionesRef_Sel",GXType.NChar,25,0) ,
          new ParDef("@lV45TFOperacionesNombreRef",GXType.Char,120,0) ,
          new ParDef("@AV46TFOperacionesNombreRef_Sel",GXType.NChar,120,0) ,
          new ParDef("@AV41TFOperacionesImporte",GXType.Decimal,18,2) ,
          new ParDef("@AV42TFOperacionesImporte_To",GXType.Decimal,18,2) ,
          new ParDef("@lV43TFOperacionesMoneda",GXType.Char,3,0) ,
          new ParDef("@AV44TFOperacionesMoneda_Sel",GXType.NChar,3,0) ,
          new ParDef("@AV33TFOperacionesFechaAlta",GXType.Date,8,0) ,
          new ParDef("@AV34TFOperacionesFechaAlta_To",GXType.Date,8,0) ,
          new ParDef("@AV35TFOperacionesFechaDesde",GXType.Date,8,0) ,
          new ParDef("@AV36TFOperacionesFechaDesde_To",GXType.Date,8,0) ,
          new ParDef("@AV37TFOperacionesFechaHasta",GXType.Date,8,0) ,
          new ParDef("@AV38TFOperacionesFechaHasta_To",GXType.Date,8,0)
          };
          Object[] prmH00DM3;
          prmH00DM3 = new Object[] {
          new ParDef("@AV39TFOperacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV40TFOperacionesId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV47TFOperacionesRef",GXType.Char,25,0) ,
          new ParDef("@AV48TFOperacionesRef_Sel",GXType.NChar,25,0) ,
          new ParDef("@lV45TFOperacionesNombreRef",GXType.Char,120,0) ,
          new ParDef("@AV46TFOperacionesNombreRef_Sel",GXType.NChar,120,0) ,
          new ParDef("@AV41TFOperacionesImporte",GXType.Decimal,18,2) ,
          new ParDef("@AV42TFOperacionesImporte_To",GXType.Decimal,18,2) ,
          new ParDef("@lV43TFOperacionesMoneda",GXType.Char,3,0) ,
          new ParDef("@AV44TFOperacionesMoneda_Sel",GXType.NChar,3,0) ,
          new ParDef("@AV33TFOperacionesFechaAlta",GXType.Date,8,0) ,
          new ParDef("@AV34TFOperacionesFechaAlta_To",GXType.Date,8,0) ,
          new ParDef("@AV35TFOperacionesFechaDesde",GXType.Date,8,0) ,
          new ParDef("@AV36TFOperacionesFechaDesde_To",GXType.Date,8,0) ,
          new ParDef("@AV37TFOperacionesFechaHasta",GXType.Date,8,0) ,
          new ParDef("@AV38TFOperacionesFechaHasta_To",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00DM2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DM2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DM3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DM3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getString(9, 256);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getString(15, 25);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getString(16, 3);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((long[]) buf[32])[0] = rslt.getLong(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((decimal[]) buf[34])[0] = rslt.getDecimal(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((string[]) buf[36])[0] = rslt.getString(19, 1);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getString(20, 20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((long[]) buf[40])[0] = rslt.getLong(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getString(22, 120);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((string[]) buf[44])[0] = rslt.getString(23, 25);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getString(24, 3);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((long[]) buf[48])[0] = rslt.getLong(25);
                ((string[]) buf[49])[0] = rslt.getBLOBFile(26, "tmp", "");
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getString(9, 256);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getString(15, 25);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getString(16, 3);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((long[]) buf[32])[0] = rslt.getLong(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((decimal[]) buf[34])[0] = rslt.getDecimal(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((string[]) buf[36])[0] = rslt.getString(19, 1);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getString(20, 20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((long[]) buf[40])[0] = rslt.getLong(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getString(22, 120);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((string[]) buf[44])[0] = rslt.getString(23, 25);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getString(24, 3);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((long[]) buf[48])[0] = rslt.getLong(25);
                ((string[]) buf[49])[0] = rslt.getBLOBFile(26, "tmp", "");
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                return;
       }
    }

 }

}
