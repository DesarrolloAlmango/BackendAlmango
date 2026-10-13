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
   public class walletprompt : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public walletprompt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public walletprompt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_InOutWalletId ,
                           ref string aP1_InOutWalletTipoEntidad )
      {
         this.AV8InOutWalletId = aP0_InOutWalletId;
         this.AV9InOutWalletTipoEntidad = aP1_InOutWalletTipoEntidad;
         ExecutePrivate();
         aP0_InOutWalletId=this.AV8InOutWalletId;
         aP1_InOutWalletTipoEntidad=this.AV9InOutWalletTipoEntidad;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTipoCuentaConcepto = new GXCombobox();
         cmbWalletTipoEntidad = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "InOutWalletId");
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
               gxfirstwebparm = GetFirstPar( "InOutWalletId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "InOutWalletId");
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
               AV8InOutWalletId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8InOutWalletId", StringUtil.LTrimStr( (decimal)(AV8InOutWalletId), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9InOutWalletTipoEntidad = GetPar( "InOutWalletTipoEntidad");
                  AssignAttri("", false, "AV9InOutWalletTipoEntidad", AV9InOutWalletTipoEntidad);
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
         AV11OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV12OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV13FilterFullText = GetPar( "FilterFullText");
         AV22TFWalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFWalletId"), "."), 18, MidpointRounding.ToEven));
         AV23TFWalletId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFWalletId_To"), "."), 18, MidpointRounding.ToEven));
         AV32Pgmname = GetPar( "Pgmname");
         AV24TFWalletCodRefencia = GetPar( "TFWalletCodRefencia");
         AV25TFWalletCodRefencia_Sel = GetPar( "TFWalletCodRefencia_Sel");
         AV26TFWalletNombre = GetPar( "TFWalletNombre");
         AV27TFWalletNombre_Sel = GetPar( "TFWalletNombre_Sel");
         AV28TFMonedaISOSimbolo = GetPar( "TFMonedaISOSimbolo");
         AV29TFMonedaISOSimbolo_Sel = GetPar( "TFMonedaISOSimbolo_Sel");
         AV30TFWalletSaldo = NumberUtil.Val( GetPar( "TFWalletSaldo"), ".");
         AV31TFWalletSaldo_To = NumberUtil.Val( GetPar( "TFWalletSaldo_To"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV22TFWalletId, AV23TFWalletId_To, AV32Pgmname, AV24TFWalletCodRefencia, AV25TFWalletCodRefencia_Sel, AV26TFWalletNombre, AV27TFWalletNombre_Sel, AV28TFMonedaISOSimbolo, AV29TFMonedaISOSimbolo_Sel, AV30TFWalletSaldo, AV31TFWalletSaldo_To) ;
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
         PAAQ2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTAQ2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("walletprompt.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8InOutWalletId,18,0)),UrlEncode(StringUtil.RTrim(AV9InOutWalletTipoEntidad))}, new string[] {"InOutWalletId","InOutWalletTipoEntidad"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV12OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV13FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_26", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_26), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV18GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV12OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFWALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22TFWalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWALLETID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23TFWalletId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWALLETCODREFENCIA", StringUtil.RTrim( AV24TFWalletCodRefencia));
         GxWebStd.gx_hidden_field( context, "vTFWALLETCODREFENCIA_SEL", StringUtil.RTrim( AV25TFWalletCodRefencia_Sel));
         GxWebStd.gx_hidden_field( context, "vTFWALLETNOMBRE", StringUtil.RTrim( AV26TFWalletNombre));
         GxWebStd.gx_hidden_field( context, "vTFWALLETNOMBRE_SEL", StringUtil.RTrim( AV27TFWalletNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFMONEDAISOSIMBOLO", StringUtil.RTrim( AV28TFMonedaISOSimbolo));
         GxWebStd.gx_hidden_field( context, "vTFMONEDAISOSIMBOLO_SEL", StringUtil.RTrim( AV29TFMonedaISOSimbolo_Sel));
         GxWebStd.gx_hidden_field( context, "vTFWALLETSALDO", StringUtil.LTrim( StringUtil.NToC( AV30TFWalletSaldo, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWALLETSALDO_TO", StringUtil.LTrim( StringUtil.NToC( AV31TFWalletSaldo_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINOUTWALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8InOutWalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINOUTWALLETTIPOENTIDAD", StringUtil.RTrim( AV9InOutWalletTipoEntidad));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WALLETTOTALDEBITO", StringUtil.LTrim( StringUtil.NToC( A646WalletTotalDebito, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WALLETTOTALCREDITO", StringUtil.LTrim( StringUtil.NToC( A647WalletTotalCredito, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WEAQ2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTAQ2( ) ;
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
         return formatLink("walletprompt.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8InOutWalletId,18,0)),UrlEncode(StringUtil.RTrim(AV9InOutWalletTipoEntidad))}, new string[] {"InOutWalletId","InOutWalletTipoEntidad"})  ;
      }

      public override string GetPgmname( )
      {
         return "WalletPrompt" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selecciona Saldos y Cuentas", "") ;
      }

      protected void WBAQ0( )
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
            wb_table1_14_AQ2( true) ;
         }
         else
         {
            wb_table1_14_AQ2( false) ;
         }
         return  ;
      }

      protected void wb_table1_14_AQ2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV16GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV17GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV18GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
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

      protected void STARTAQ2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selecciona Saldos y Cuentas", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPAQ0( ) ;
      }

      protected void WSAQ2( )
      {
         STARTAQ2( ) ;
         EVTAQ2( ) ;
      }

      protected void EVTAQ2( )
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
                              E11AQ2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E12AQ2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E13AQ2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCLEANFILTERS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCleanFilters' */
                              E14AQ2 ();
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
                              AV19Select = cgiGet( edtavSelect_Internalname);
                              AssignAttri("", false, edtavSelect_Internalname, AV19Select);
                              A637WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWalletId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A483TipoCuentaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoCuentaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbTipoCuentaConcepto.Name = cmbTipoCuentaConcepto_Internalname;
                              cmbTipoCuentaConcepto.CurrentValue = cgiGet( cmbTipoCuentaConcepto_Internalname);
                              A636TipoCuentaConcepto = cgiGet( cmbTipoCuentaConcepto_Internalname);
                              A484TipoCuentaNombre = cgiGet( edtTipoCuentaNombre_Internalname);
                              cmbWalletTipoEntidad.Name = cmbWalletTipoEntidad_Internalname;
                              cmbWalletTipoEntidad.CurrentValue = cgiGet( cmbWalletTipoEntidad_Internalname);
                              A638WalletTipoEntidad = cgiGet( cmbWalletTipoEntidad_Internalname);
                              A639WalletCodRefencia = cgiGet( edtWalletCodRefencia_Internalname);
                              A715WalletNombre = cgiGet( edtWalletNombre_Internalname);
                              A118MonedaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMonedaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n118MonedaId = false;
                              A119MonedaISOSimbolo = cgiGet( edtMonedaISOSimbolo_Internalname);
                              A648WalletSaldo = context.localUtil.CToN( cgiGet( edtWalletSaldo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E15AQ2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E16AQ2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E17AQ2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV12OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV13FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E18AQ2 ();
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

      protected void WEAQ2( )
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

      protected void PAAQ2( )
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
                                       short AV11OrderedBy ,
                                       bool AV12OrderedDsc ,
                                       string AV13FilterFullText ,
                                       long AV22TFWalletId ,
                                       long AV23TFWalletId_To ,
                                       string AV32Pgmname ,
                                       string AV24TFWalletCodRefencia ,
                                       string AV25TFWalletCodRefencia_Sel ,
                                       string AV26TFWalletNombre ,
                                       string AV27TFWalletNombre_Sel ,
                                       string AV28TFMonedaISOSimbolo ,
                                       string AV29TFMonedaISOSimbolo_Sel ,
                                       decimal AV30TFWalletSaldo ,
                                       decimal AV31TFWalletSaldo_To )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFAQ2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A637WalletId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETTIPOENTIDAD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A638WalletTipoEntidad, "")), context));
         GxWebStd.gx_hidden_field( context, "WALLETTIPOENTIDAD", StringUtil.RTrim( A638WalletTipoEntidad));
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
         RFAQ2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV32Pgmname = "WalletPrompt";
         edtavSelect_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV22TFWalletId ,
                                              AV23TFWalletId_To ,
                                              AV25TFWalletCodRefencia_Sel ,
                                              AV24TFWalletCodRefencia ,
                                              AV29TFMonedaISOSimbolo_Sel ,
                                              AV28TFMonedaISOSimbolo ,
                                              A637WalletId ,
                                              A639WalletCodRefencia ,
                                              A119MonedaISOSimbolo ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV13FilterFullText ,
                                              A715WalletNombre ,
                                              A648WalletSaldo ,
                                              AV27TFWalletNombre_Sel ,
                                              AV26TFWalletNombre ,
                                              AV30TFWalletSaldo ,
                                              AV31TFWalletSaldo_To } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV24TFWalletCodRefencia = StringUtil.PadR( StringUtil.RTrim( AV24TFWalletCodRefencia), 25, "%");
         lV28TFMonedaISOSimbolo = StringUtil.PadR( StringUtil.RTrim( AV28TFMonedaISOSimbolo), 3, "%");
         /* Using cursor H00AQ2 */
         pr_default.execute(0, new Object[] {AV22TFWalletId, AV23TFWalletId_To, lV24TFWalletCodRefencia, AV25TFWalletCodRefencia_Sel, lV28TFMonedaISOSimbolo, AV29TFMonedaISOSimbolo_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A119MonedaISOSimbolo = H00AQ2_A119MonedaISOSimbolo[0];
            A118MonedaId = H00AQ2_A118MonedaId[0];
            n118MonedaId = H00AQ2_n118MonedaId[0];
            A484TipoCuentaNombre = H00AQ2_A484TipoCuentaNombre[0];
            A636TipoCuentaConcepto = H00AQ2_A636TipoCuentaConcepto[0];
            A483TipoCuentaId = H00AQ2_A483TipoCuentaId[0];
            A639WalletCodRefencia = H00AQ2_A639WalletCodRefencia[0];
            A638WalletTipoEntidad = H00AQ2_A638WalletTipoEntidad[0];
            A637WalletId = H00AQ2_A637WalletId[0];
            A119MonedaISOSimbolo = H00AQ2_A119MonedaISOSimbolo[0];
            A484TipoCuentaNombre = H00AQ2_A484TipoCuentaNombre[0];
            A636TipoCuentaConcepto = H00AQ2_A636TipoCuentaConcepto[0];
            GXt_decimal1 = A646WalletTotalDebito;
            new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal1) ;
            A646WalletTotalDebito = GXt_decimal1;
            AssignAttri("", false, "A646WalletTotalDebito", StringUtil.LTrimStr( A646WalletTotalDebito, 18, 2));
            GXt_decimal1 = A647WalletTotalCredito;
            new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal1) ;
            A647WalletTotalCredito = GXt_decimal1;
            AssignAttri("", false, "A647WalletTotalCredito", StringUtil.LTrimStr( A647WalletTotalCredito, 18, 2));
            A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
            if ( (Convert.ToDecimal(0)==AV30TFWalletSaldo) || ( ( A648WalletSaldo >= AV30TFWalletSaldo ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV31TFWalletSaldo_To) || ( ( A648WalletSaldo <= AV31TFWalletSaldo_To ) ) )
               {
                  GXt_char2 = A715WalletNombre;
                  new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char2) ;
                  A715WalletNombre = GXt_char2;
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A637WalletId), 18, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A639WalletCodRefencia) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A119MonedaISOSimbolo) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A648WalletSaldo, 18, 2) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) ) )
                  {
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV27TFWalletNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFWalletNombre)) ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( StringUtil.Upper( AV26TFWalletNombre) , 254 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFWalletNombre_Sel)) && ! ( StringUtil.StrCmp(AV27TFWalletNombre_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A715WalletNombre, AV27TFWalletNombre_Sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV27TFWalletNombre_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) || String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) ) )
                           {
                              GRID_nRecordCount = (long)(GRID_nRecordCount+1);
                           }
                        }
                     }
                  }
               }
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RFAQ2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 26;
         /* Execute user event: Refresh */
         E16AQ2 ();
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
                                                 AV22TFWalletId ,
                                                 AV23TFWalletId_To ,
                                                 AV25TFWalletCodRefencia_Sel ,
                                                 AV24TFWalletCodRefencia ,
                                                 AV29TFMonedaISOSimbolo_Sel ,
                                                 AV28TFMonedaISOSimbolo ,
                                                 A637WalletId ,
                                                 A639WalletCodRefencia ,
                                                 A119MonedaISOSimbolo ,
                                                 AV11OrderedBy ,
                                                 AV12OrderedDsc ,
                                                 AV13FilterFullText ,
                                                 A715WalletNombre ,
                                                 A648WalletSaldo ,
                                                 AV27TFWalletNombre_Sel ,
                                                 AV26TFWalletNombre ,
                                                 AV30TFWalletSaldo ,
                                                 AV31TFWalletSaldo_To } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                                 }
            });
            lV24TFWalletCodRefencia = StringUtil.PadR( StringUtil.RTrim( AV24TFWalletCodRefencia), 25, "%");
            lV28TFMonedaISOSimbolo = StringUtil.PadR( StringUtil.RTrim( AV28TFMonedaISOSimbolo), 3, "%");
            /* Using cursor H00AQ3 */
            pr_default.execute(1, new Object[] {AV22TFWalletId, AV23TFWalletId_To, lV24TFWalletCodRefencia, AV25TFWalletCodRefencia_Sel, lV28TFMonedaISOSimbolo, AV29TFMonedaISOSimbolo_Sel});
            nGXsfl_26_idx = 1;
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A119MonedaISOSimbolo = H00AQ3_A119MonedaISOSimbolo[0];
               A118MonedaId = H00AQ3_A118MonedaId[0];
               n118MonedaId = H00AQ3_n118MonedaId[0];
               A484TipoCuentaNombre = H00AQ3_A484TipoCuentaNombre[0];
               A636TipoCuentaConcepto = H00AQ3_A636TipoCuentaConcepto[0];
               A483TipoCuentaId = H00AQ3_A483TipoCuentaId[0];
               A639WalletCodRefencia = H00AQ3_A639WalletCodRefencia[0];
               A638WalletTipoEntidad = H00AQ3_A638WalletTipoEntidad[0];
               A637WalletId = H00AQ3_A637WalletId[0];
               A119MonedaISOSimbolo = H00AQ3_A119MonedaISOSimbolo[0];
               A484TipoCuentaNombre = H00AQ3_A484TipoCuentaNombre[0];
               A636TipoCuentaConcepto = H00AQ3_A636TipoCuentaConcepto[0];
               GXt_decimal1 = A646WalletTotalDebito;
               new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal1) ;
               A646WalletTotalDebito = GXt_decimal1;
               AssignAttri("", false, "A646WalletTotalDebito", StringUtil.LTrimStr( A646WalletTotalDebito, 18, 2));
               GXt_decimal1 = A647WalletTotalCredito;
               new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal1) ;
               A647WalletTotalCredito = GXt_decimal1;
               AssignAttri("", false, "A647WalletTotalCredito", StringUtil.LTrimStr( A647WalletTotalCredito, 18, 2));
               A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
               if ( (Convert.ToDecimal(0)==AV30TFWalletSaldo) || ( ( A648WalletSaldo >= AV30TFWalletSaldo ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV31TFWalletSaldo_To) || ( ( A648WalletSaldo <= AV31TFWalletSaldo_To ) ) )
                  {
                     GXt_char2 = A715WalletNombre;
                     new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char2) ;
                     A715WalletNombre = GXt_char2;
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A637WalletId), 18, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A639WalletCodRefencia) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A119MonedaISOSimbolo) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A648WalletSaldo, 18, 2) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) ) )
                     {
                        if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV27TFWalletNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFWalletNombre)) ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( StringUtil.Upper( AV26TFWalletNombre) , 254 , "%"),  ' ' ) ) )
                        {
                           if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFWalletNombre_Sel)) && ! ( StringUtil.StrCmp(AV27TFWalletNombre_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A715WalletNombre, AV27TFWalletNombre_Sel) == 0 ) ) )
                           {
                              if ( ( StringUtil.StrCmp(AV27TFWalletNombre_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) || String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) ) )
                              {
                                 /* Execute user event: Grid.Load */
                                 E17AQ2 ();
                              }
                           }
                        }
                     }
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 26;
            WBAQ0( ) ;
         }
         bGXsfl_26_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesAQ2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETID"+"_"+sGXsfl_26_idx, GetSecureSignedToken( sGXsfl_26_idx, context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETTIPOENTIDAD"+"_"+sGXsfl_26_idx, GetSecureSignedToken( sGXsfl_26_idx, StringUtil.RTrim( context.localUtil.Format( A638WalletTipoEntidad, "")), context));
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV22TFWalletId, AV23TFWalletId_To, AV32Pgmname, AV24TFWalletCodRefencia, AV25TFWalletCodRefencia_Sel, AV26TFWalletNombre, AV27TFWalletNombre_Sel, AV28TFMonedaISOSimbolo, AV29TFMonedaISOSimbolo_Sel, AV30TFWalletSaldo, AV31TFWalletSaldo_To) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV22TFWalletId, AV23TFWalletId_To, AV32Pgmname, AV24TFWalletCodRefencia, AV25TFWalletCodRefencia_Sel, AV26TFWalletNombre, AV27TFWalletNombre_Sel, AV28TFMonedaISOSimbolo, AV29TFMonedaISOSimbolo_Sel, AV30TFWalletSaldo, AV31TFWalletSaldo_To) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV22TFWalletId, AV23TFWalletId_To, AV32Pgmname, AV24TFWalletCodRefencia, AV25TFWalletCodRefencia_Sel, AV26TFWalletNombre, AV27TFWalletNombre_Sel, AV28TFMonedaISOSimbolo, AV29TFMonedaISOSimbolo_Sel, AV30TFWalletSaldo, AV31TFWalletSaldo_To) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV22TFWalletId, AV23TFWalletId_To, AV32Pgmname, AV24TFWalletCodRefencia, AV25TFWalletCodRefencia_Sel, AV26TFWalletNombre, AV27TFWalletNombre_Sel, AV28TFMonedaISOSimbolo, AV29TFMonedaISOSimbolo_Sel, AV30TFWalletSaldo, AV31TFWalletSaldo_To) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV22TFWalletId, AV23TFWalletId_To, AV32Pgmname, AV24TFWalletCodRefencia, AV25TFWalletCodRefencia_Sel, AV26TFWalletNombre, AV27TFWalletNombre_Sel, AV28TFMonedaISOSimbolo, AV29TFMonedaISOSimbolo_Sel, AV30TFWalletSaldo, AV31TFWalletSaldo_To) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV32Pgmname = "WalletPrompt";
         edtavSelect_Enabled = 0;
         edtWalletId_Enabled = 0;
         edtTipoCuentaId_Enabled = 0;
         cmbTipoCuentaConcepto.Enabled = 0;
         edtTipoCuentaNombre_Enabled = 0;
         cmbWalletTipoEntidad.Enabled = 0;
         edtWalletCodRefencia_Enabled = 0;
         edtWalletNombre_Enabled = 0;
         edtMonedaId_Enabled = 0;
         edtMonedaISOSimbolo_Enabled = 0;
         edtWalletSaldo_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPAQ0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15AQ2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_26 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_26"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV16GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV17GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV18GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            /* Read variables values. */
            AV13FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV12OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV13FilterFullText) != 0 )
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
         E15AQ2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E15AQ2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( "Selecciona Saldos y Cuentas", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( AV11OrderedBy < 1 )
         {
            AV11OrderedBy = 1;
            AssignAttri("", false, "AV11OrderedBy", StringUtil.LTrimStr( (decimal)(AV11OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E16AQ2( )
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
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV16GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV16GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV16GridCurrentPage), 10, 0));
         AV17GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV17GridPageCount", StringUtil.LTrimStr( (decimal)(AV17GridPageCount), 10, 0));
         GXt_char2 = AV18GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV32Pgmname, out  GXt_char2) ;
         AV18GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV18GridAppliedFilters", AV18GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E11AQ2( )
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
            AV15PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV15PageToGo) ;
         }
         /*  Sending Event outputs  */
      }

      protected void E12AQ2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E13AQ2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV11OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV11OrderedBy", StringUtil.LTrimStr( (decimal)(AV11OrderedBy), 4, 0));
            AV12OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV12OrderedDsc", AV12OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WalletId") == 0 )
            {
               AV22TFWalletId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22TFWalletId", StringUtil.LTrimStr( (decimal)(AV22TFWalletId), 18, 0));
               AV23TFWalletId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV23TFWalletId_To", StringUtil.LTrimStr( (decimal)(AV23TFWalletId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WalletCodRefencia") == 0 )
            {
               AV24TFWalletCodRefencia = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV24TFWalletCodRefencia", AV24TFWalletCodRefencia);
               AV25TFWalletCodRefencia_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV25TFWalletCodRefencia_Sel", AV25TFWalletCodRefencia_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WalletNombre") == 0 )
            {
               AV26TFWalletNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV26TFWalletNombre", AV26TFWalletNombre);
               AV27TFWalletNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV27TFWalletNombre_Sel", AV27TFWalletNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MonedaISOSimbolo") == 0 )
            {
               AV28TFMonedaISOSimbolo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV28TFMonedaISOSimbolo", AV28TFMonedaISOSimbolo);
               AV29TFMonedaISOSimbolo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFMonedaISOSimbolo_Sel", AV29TFMonedaISOSimbolo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WalletSaldo") == 0 )
            {
               AV30TFWalletSaldo = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV30TFWalletSaldo", StringUtil.LTrimStr( AV30TFWalletSaldo, 18, 2));
               AV31TFWalletSaldo_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV31TFWalletSaldo_To", StringUtil.LTrimStr( AV31TFWalletSaldo_To, 18, 2));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E17AQ2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV19Select = "<i class=\"fas fa-check\"></i>";
            AssignAttri("", false, edtavSelect_Internalname, AV19Select);
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
         E18AQ2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18AQ2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV8InOutWalletId = A637WalletId;
         AssignAttri("", false, "AV8InOutWalletId", StringUtil.LTrimStr( (decimal)(AV8InOutWalletId), 18, 0));
         AV9InOutWalletTipoEntidad = A638WalletTipoEntidad;
         AssignAttri("", false, "AV9InOutWalletTipoEntidad", AV9InOutWalletTipoEntidad);
         context.setWebReturnParms(new Object[] {(long)AV8InOutWalletId,(string)AV9InOutWalletTipoEntidad});
         context.setWebReturnParmsMetadata(new Object[] {"AV8InOutWalletId","AV9InOutWalletTipoEntidad"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void E14AQ2( )
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
      }

      protected void S112( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV11OrderedBy), 4, 0))+":"+(AV12OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S132( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV13FilterFullText = "";
         AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
         AV22TFWalletId = 0;
         AssignAttri("", false, "AV22TFWalletId", StringUtil.LTrimStr( (decimal)(AV22TFWalletId), 18, 0));
         AV23TFWalletId_To = 0;
         AssignAttri("", false, "AV23TFWalletId_To", StringUtil.LTrimStr( (decimal)(AV23TFWalletId_To), 18, 0));
         AV24TFWalletCodRefencia = "";
         AssignAttri("", false, "AV24TFWalletCodRefencia", AV24TFWalletCodRefencia);
         AV25TFWalletCodRefencia_Sel = "";
         AssignAttri("", false, "AV25TFWalletCodRefencia_Sel", AV25TFWalletCodRefencia_Sel);
         AV26TFWalletNombre = "";
         AssignAttri("", false, "AV26TFWalletNombre", AV26TFWalletNombre);
         AV27TFWalletNombre_Sel = "";
         AssignAttri("", false, "AV27TFWalletNombre_Sel", AV27TFWalletNombre_Sel);
         AV28TFMonedaISOSimbolo = "";
         AssignAttri("", false, "AV28TFMonedaISOSimbolo", AV28TFMonedaISOSimbolo);
         AV29TFMonedaISOSimbolo_Sel = "";
         AssignAttri("", false, "AV29TFMonedaISOSimbolo_Sel", AV29TFMonedaISOSimbolo_Sel);
         AV30TFWalletSaldo = 0;
         AssignAttri("", false, "AV30TFWalletSaldo", StringUtil.LTrimStr( AV30TFWalletSaldo, 18, 2));
         AV31TFWalletSaldo_To = 0;
         AssignAttri("", false, "AV31TFWalletSaldo_To", StringUtil.LTrimStr( AV31TFWalletSaldo_To, 18, 2));
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
         AV20GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV20GridState.gxTpr_Orderedby = AV11OrderedBy;
         AV20GridState.gxTpr_Ordereddsc = AV12OrderedDsc;
         AV20GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV20GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)),  0,  AV13FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV20GridState,  "TFWALLETID",  context.GetMessage( "Id", ""),  !((0==AV22TFWalletId)&&(0==AV23TFWalletId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV22TFWalletId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV23TFWalletId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV20GridState,  "TFWALLETCODREFENCIA",  context.GetMessage( "Código de Refencia", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFWalletCodRefencia)),  0,  AV24TFWalletCodRefencia,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFWalletCodRefencia_Sel)),  AV25TFWalletCodRefencia_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV20GridState,  "TFWALLETNOMBRE",  context.GetMessage( "Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFWalletNombre)),  0,  AV26TFWalletNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFWalletNombre_Sel)),  AV27TFWalletNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV20GridState,  "TFMONEDAISOSIMBOLO",  context.GetMessage( "Moneda", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFMonedaISOSimbolo)),  0,  AV28TFMonedaISOSimbolo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFMonedaISOSimbolo_Sel)),  AV29TFMonedaISOSimbolo_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV20GridState,  "TFWALLETSALDO",  context.GetMessage( "Saldo", ""),  !((Convert.ToDecimal(0)==AV30TFWalletSaldo)&&(Convert.ToDecimal(0)==AV31TFWalletSaldo_To)),  0,  StringUtil.Trim( StringUtil.Str( AV30TFWalletSaldo, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV31TFWalletSaldo_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV32Pgmname+"GridState",  AV20GridState.ToXml(false, true, "", "")) ;
      }

      protected void wb_table1_14_AQ2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellAlignTop CellPaddingTop10'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCleanfilters_Internalname, context.GetMessage( "<i class=\"fas fa-filter CleanFiltersIcon\"></i>", ""), "", "", lblCleanfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOCLEANFILTERS\\'."+"'", "", "TextBlock", 5, context.GetMessage( "WWP_CleanFiltersTooltip", ""), 1, 1, 0, 1, "HLP_WalletPrompt.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_26_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV13FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WalletPrompt.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_14_AQ2e( true) ;
         }
         else
         {
            wb_table1_14_AQ2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8InOutWalletId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV8InOutWalletId", StringUtil.LTrimStr( (decimal)(AV8InOutWalletId), 18, 0));
         AV9InOutWalletTipoEntidad = (string)getParm(obj,1);
         AssignAttri("", false, "AV9InOutWalletTipoEntidad", AV9InOutWalletTipoEntidad);
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
         PAAQ2( ) ;
         WSAQ2( ) ;
         WEAQ2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202692821442593", true, true, false);
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
         context.AddJavascriptSource("walletprompt.js", "?202692821442593", false, true, false);
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

      protected void SubsflControlProps_262( )
      {
         edtavSelect_Internalname = "vSELECT_"+sGXsfl_26_idx;
         edtWalletId_Internalname = "WALLETID_"+sGXsfl_26_idx;
         edtTipoCuentaId_Internalname = "TIPOCUENTAID_"+sGXsfl_26_idx;
         cmbTipoCuentaConcepto_Internalname = "TIPOCUENTACONCEPTO_"+sGXsfl_26_idx;
         edtTipoCuentaNombre_Internalname = "TIPOCUENTANOMBRE_"+sGXsfl_26_idx;
         cmbWalletTipoEntidad_Internalname = "WALLETTIPOENTIDAD_"+sGXsfl_26_idx;
         edtWalletCodRefencia_Internalname = "WALLETCODREFENCIA_"+sGXsfl_26_idx;
         edtWalletNombre_Internalname = "WALLETNOMBRE_"+sGXsfl_26_idx;
         edtMonedaId_Internalname = "MONEDAID_"+sGXsfl_26_idx;
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO_"+sGXsfl_26_idx;
         edtWalletSaldo_Internalname = "WALLETSALDO_"+sGXsfl_26_idx;
      }

      protected void SubsflControlProps_fel_262( )
      {
         edtavSelect_Internalname = "vSELECT_"+sGXsfl_26_fel_idx;
         edtWalletId_Internalname = "WALLETID_"+sGXsfl_26_fel_idx;
         edtTipoCuentaId_Internalname = "TIPOCUENTAID_"+sGXsfl_26_fel_idx;
         cmbTipoCuentaConcepto_Internalname = "TIPOCUENTACONCEPTO_"+sGXsfl_26_fel_idx;
         edtTipoCuentaNombre_Internalname = "TIPOCUENTANOMBRE_"+sGXsfl_26_fel_idx;
         cmbWalletTipoEntidad_Internalname = "WALLETTIPOENTIDAD_"+sGXsfl_26_fel_idx;
         edtWalletCodRefencia_Internalname = "WALLETCODREFENCIA_"+sGXsfl_26_fel_idx;
         edtWalletNombre_Internalname = "WALLETNOMBRE_"+sGXsfl_26_fel_idx;
         edtMonedaId_Internalname = "MONEDAID_"+sGXsfl_26_fel_idx;
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO_"+sGXsfl_26_fel_idx;
         edtWalletSaldo_Internalname = "WALLETSALDO_"+sGXsfl_26_fel_idx;
      }

      protected void sendrow_262( )
      {
         sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
         SubsflControlProps_262( ) ;
         WBAQ0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSelect_Internalname,StringUtil.RTrim( AV19Select),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"","'"+""+"'"+",false,"+"'"+"EENTER."+sGXsfl_26_idx+"'",(string)"",(string)"",context.GetMessage( "GX_BtnSelect", ""),(string)"",(string)edtavSelect_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavSelect_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A637WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoCuentaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A483TipoCuentaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A483TipoCuentaId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoCuentaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            GXCCtl = "TIPOCUENTACONCEPTO_" + sGXsfl_26_idx;
            cmbTipoCuentaConcepto.Name = GXCCtl;
            cmbTipoCuentaConcepto.WebTags = "";
            cmbTipoCuentaConcepto.addItem("SAL", context.GetMessage( "Saldo por Cuentas", ""), 0);
            cmbTipoCuentaConcepto.addItem("COS", context.GetMessage( "Usada En Centro Costo", ""), 0);
            cmbTipoCuentaConcepto.addItem("OTR", context.GetMessage( "Otros", ""), 0);
            if ( cmbTipoCuentaConcepto.ItemCount > 0 )
            {
               A636TipoCuentaConcepto = cmbTipoCuentaConcepto.getValidValue(A636TipoCuentaConcepto);
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTipoCuentaConcepto,(string)cmbTipoCuentaConcepto_Internalname,StringUtil.RTrim( A636TipoCuentaConcepto),(short)1,(string)cmbTipoCuentaConcepto_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbTipoCuentaConcepto.CurrentValue = StringUtil.RTrim( A636TipoCuentaConcepto);
            AssignProp("", false, cmbTipoCuentaConcepto_Internalname, "Values", (string)(cmbTipoCuentaConcepto.ToJavascriptSource()), !bGXsfl_26_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoCuentaNombre_Internalname,StringUtil.RTrim( A484TipoCuentaNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoCuentaNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"NombreLargo",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbWalletTipoEntidad.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "WALLETTIPOENTIDAD_" + sGXsfl_26_idx;
               cmbWalletTipoEntidad.Name = GXCCtl;
               cmbWalletTipoEntidad.WebTags = "";
               cmbWalletTipoEntidad.addItem("CLI", context.GetMessage( "Clientes", ""), 0);
               cmbWalletTipoEntidad.addItem("COM", context.GetMessage( "Comercios", ""), 0);
               cmbWalletTipoEntidad.addItem("PRO", context.GetMessage( "Profesionales", ""), 0);
               cmbWalletTipoEntidad.addItem("EMP", context.GetMessage( "Empleados", ""), 0);
               cmbWalletTipoEntidad.addItem("OTR", context.GetMessage( "Otros", ""), 0);
               if ( cmbWalletTipoEntidad.ItemCount > 0 )
               {
                  A638WalletTipoEntidad = cmbWalletTipoEntidad.getValidValue(A638WalletTipoEntidad);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWalletTipoEntidad,(string)cmbWalletTipoEntidad_Internalname,StringUtil.RTrim( A638WalletTipoEntidad),(short)1,(string)cmbWalletTipoEntidad_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbWalletTipoEntidad.CurrentValue = StringUtil.RTrim( A638WalletTipoEntidad);
            AssignProp("", false, cmbWalletTipoEntidad_Internalname, "Values", (string)(cmbWalletTipoEntidad.ToJavascriptSource()), !bGXsfl_26_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletCodRefencia_Internalname,StringUtil.RTrim( A639WalletCodRefencia),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletCodRefencia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)25,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletNombre_Internalname,StringUtil.RTrim( A715WalletNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMonedaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A118MonedaId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMonedaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMonedaISOSimbolo_Internalname,StringUtil.RTrim( A119MonedaISOSimbolo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMonedaISOSimbolo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"MonISO",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletSaldo_Internalname,StringUtil.LTrim( StringUtil.NToC( A648WalletSaldo, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A648WalletSaldo, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletSaldo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesAQ2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_26_idx = ((subGrid_Islastpage==1)&&(nGXsfl_26_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_26_idx+1);
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
         }
         /* End function sendrow_262 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "TIPOCUENTACONCEPTO_" + sGXsfl_26_idx;
         cmbTipoCuentaConcepto.Name = GXCCtl;
         cmbTipoCuentaConcepto.WebTags = "";
         cmbTipoCuentaConcepto.addItem("SAL", context.GetMessage( "Saldo por Cuentas", ""), 0);
         cmbTipoCuentaConcepto.addItem("COS", context.GetMessage( "Usada En Centro Costo", ""), 0);
         cmbTipoCuentaConcepto.addItem("OTR", context.GetMessage( "Otros", ""), 0);
         if ( cmbTipoCuentaConcepto.ItemCount > 0 )
         {
            A636TipoCuentaConcepto = cmbTipoCuentaConcepto.getValidValue(A636TipoCuentaConcepto);
         }
         GXCCtl = "WALLETTIPOENTIDAD_" + sGXsfl_26_idx;
         cmbWalletTipoEntidad.Name = GXCCtl;
         cmbWalletTipoEntidad.WebTags = "";
         cmbWalletTipoEntidad.addItem("CLI", context.GetMessage( "Clientes", ""), 0);
         cmbWalletTipoEntidad.addItem("COM", context.GetMessage( "Comercios", ""), 0);
         cmbWalletTipoEntidad.addItem("PRO", context.GetMessage( "Profesionales", ""), 0);
         cmbWalletTipoEntidad.addItem("EMP", context.GetMessage( "Empleados", ""), 0);
         cmbWalletTipoEntidad.addItem("OTR", context.GetMessage( "Otros", ""), 0);
         if ( cmbWalletTipoEntidad.ItemCount > 0 )
         {
            A638WalletTipoEntidad = cmbWalletTipoEntidad.getValidValue(A638WalletTipoEntidad);
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo de Cuenta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo de Concepto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo de Cuenta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo Entidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Código de Refencia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Moneda", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Moneda", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Saldo", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV19Select)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSelect_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A637WalletId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A483TipoCuentaId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A636TipoCuentaConcepto)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A484TipoCuentaNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A638WalletTipoEntidad)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A639WalletCodRefencia)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A715WalletNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A119MonedaISOSimbolo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A648WalletSaldo, 18, 2, ".", ""))));
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
         edtWalletId_Internalname = "WALLETID";
         edtTipoCuentaId_Internalname = "TIPOCUENTAID";
         cmbTipoCuentaConcepto_Internalname = "TIPOCUENTACONCEPTO";
         edtTipoCuentaNombre_Internalname = "TIPOCUENTANOMBRE";
         cmbWalletTipoEntidad_Internalname = "WALLETTIPOENTIDAD";
         edtWalletCodRefencia_Internalname = "WALLETCODREFENCIA";
         edtWalletNombre_Internalname = "WALLETNOMBRE";
         edtMonedaId_Internalname = "MONEDAID";
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO";
         edtWalletSaldo_Internalname = "WALLETSALDO";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
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
         edtWalletSaldo_Jsonclick = "";
         edtMonedaISOSimbolo_Jsonclick = "";
         edtMonedaId_Jsonclick = "";
         edtWalletNombre_Jsonclick = "";
         edtWalletCodRefencia_Jsonclick = "";
         cmbWalletTipoEntidad_Jsonclick = "";
         edtTipoCuentaNombre_Jsonclick = "";
         cmbTipoCuentaConcepto_Jsonclick = "";
         edtTipoCuentaId_Jsonclick = "";
         edtWalletId_Jsonclick = "";
         edtavSelect_Jsonclick = "";
         edtavSelect_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtWalletSaldo_Enabled = 0;
         edtMonedaISOSimbolo_Enabled = 0;
         edtMonedaId_Enabled = 0;
         edtWalletNombre_Enabled = 0;
         edtWalletCodRefencia_Enabled = 0;
         cmbWalletTipoEntidad.Enabled = 0;
         edtTipoCuentaNombre_Enabled = 0;
         cmbTipoCuentaConcepto.Enabled = 0;
         edtTipoCuentaId_Enabled = 0;
         edtWalletId_Enabled = 0;
         subGrid_Sortable = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "18.0||||-18.2";
         Ddo_grid_Datalistproc = "WalletPromptGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic|";
         Ddo_grid_Includedatalist = "|T|T|T|";
         Ddo_grid_Filterisrange = "T||||T";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Character|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T|T||T|";
         Ddo_grid_Columnssortvalues = "2|3||4|";
         Ddo_grid_Columnids = "1:WalletId|6:WalletCodRefencia|7:WalletNombre|9:MonedaISOSimbolo|10:WalletSaldo";
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
         Form.Caption = context.GetMessage( "Selecciona Saldos y Cuentas", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV24TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV25TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV26TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV27TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV28TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV29TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV30TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV31TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV16GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV17GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV18GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11AQ2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV24TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV25TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV26TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV27TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV28TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV29TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV30TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV31TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV16GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV17GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV18GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12AQ2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV24TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV25TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV26TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV27TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV28TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV29TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV30TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV31TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E13AQ2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV24TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV25TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV26TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV27TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV28TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV29TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV30TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV31TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV22TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV25TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV26TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV27TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV28TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV29TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV30TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV31TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E17AQ2',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV19Select',fld:'vSELECT',pic:'',type:'char'}]}");
         setEventMetadata("ENTER","{handler:'E18AQ2',iparms:[{av:'A637WalletId',fld:'WALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'cmbWalletTipoEntidad'},{av:'A638WalletTipoEntidad',fld:'WALLETTIPOENTIDAD',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV8InOutWalletId',fld:'vINOUTWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9InOutWalletTipoEntidad',fld:'vINOUTWALLETTIPOENTIDAD',pic:'',type:'char'}]}");
         setEventMetadata("'DOCLEANFILTERS'","{handler:'E14AQ2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV24TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV25TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV26TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV27TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV28TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV29TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV30TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV31TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'}]");
         setEventMetadata("'DOCLEANFILTERS'",",oparms:[{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV25TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV26TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV27TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV28TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV29TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV30TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV31TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'}]}");
         setEventMetadata("VALID_WALLETID","{handler:'Valid_Walletid',iparms:[]");
         setEventMetadata("VALID_WALLETID",",oparms:[]}");
         setEventMetadata("VALID_TIPOCUENTAID","{handler:'Valid_Tipocuentaid',iparms:[]");
         setEventMetadata("VALID_TIPOCUENTAID",",oparms:[]}");
         setEventMetadata("VALID_WALLETTIPOENTIDAD","{handler:'Valid_Wallettipoentidad',iparms:[]");
         setEventMetadata("VALID_WALLETTIPOENTIDAD",",oparms:[]}");
         setEventMetadata("VALID_WALLETCODREFENCIA","{handler:'Valid_Walletcodrefencia',iparms:[]");
         setEventMetadata("VALID_WALLETCODREFENCIA",",oparms:[]}");
         setEventMetadata("VALID_WALLETNOMBRE","{handler:'Valid_Walletnombre',iparms:[]");
         setEventMetadata("VALID_WALLETNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_MONEDAID","{handler:'Valid_Monedaid',iparms:[]");
         setEventMetadata("VALID_MONEDAID",",oparms:[]}");
         setEventMetadata("VALID_MONEDAISOSIMBOLO","{handler:'Valid_Monedaisosimbolo',iparms:[]");
         setEventMetadata("VALID_MONEDAISOSIMBOLO",",oparms:[]}");
         setEventMetadata("VALID_WALLETSALDO","{handler:'Valid_Walletsaldo',iparms:[]");
         setEventMetadata("VALID_WALLETSALDO",",oparms:[]}");
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
         wcpOAV9InOutWalletTipoEntidad = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV13FilterFullText = "";
         AV22TFWalletId = 0;
         AV23TFWalletId_To = 0;
         AV32Pgmname = "";
         AV24TFWalletCodRefencia = "";
         AV25TFWalletCodRefencia_Sel = "";
         AV26TFWalletNombre = "";
         AV27TFWalletNombre_Sel = "";
         AV28TFMonedaISOSimbolo = "";
         AV29TFMonedaISOSimbolo_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV18GridAppliedFilters = "";
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV19Select = "";
         A636TipoCuentaConcepto = "";
         A484TipoCuentaNombre = "";
         A638WalletTipoEntidad = "";
         A639WalletCodRefencia = "";
         A715WalletNombre = "";
         A119MonedaISOSimbolo = "";
         lV24TFWalletCodRefencia = "";
         lV28TFMonedaISOSimbolo = "";
         H00AQ2_A119MonedaISOSimbolo = new string[] {""} ;
         H00AQ2_A118MonedaId = new short[1] ;
         H00AQ2_n118MonedaId = new bool[] {false} ;
         H00AQ2_A484TipoCuentaNombre = new string[] {""} ;
         H00AQ2_A636TipoCuentaConcepto = new string[] {""} ;
         H00AQ2_A483TipoCuentaId = new long[1] ;
         H00AQ2_A639WalletCodRefencia = new string[] {""} ;
         H00AQ2_A638WalletTipoEntidad = new string[] {""} ;
         H00AQ2_A637WalletId = new long[1] ;
         H00AQ3_A119MonedaISOSimbolo = new string[] {""} ;
         H00AQ3_A118MonedaId = new short[1] ;
         H00AQ3_n118MonedaId = new bool[] {false} ;
         H00AQ3_A484TipoCuentaNombre = new string[] {""} ;
         H00AQ3_A636TipoCuentaConcepto = new string[] {""} ;
         H00AQ3_A483TipoCuentaId = new long[1] ;
         H00AQ3_A639WalletCodRefencia = new string[] {""} ;
         H00AQ3_A638WalletTipoEntidad = new string[] {""} ;
         H00AQ3_A637WalletId = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV20GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         lblCleanfilters_Jsonclick = "";
         TempTags = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.walletprompt__default(),
            new Object[][] {
                new Object[] {
               H00AQ2_A119MonedaISOSimbolo, H00AQ2_A118MonedaId, H00AQ2_n118MonedaId, H00AQ2_A484TipoCuentaNombre, H00AQ2_A636TipoCuentaConcepto, H00AQ2_A483TipoCuentaId, H00AQ2_A639WalletCodRefencia, H00AQ2_A638WalletTipoEntidad, H00AQ2_A637WalletId
               }
               , new Object[] {
               H00AQ3_A119MonedaISOSimbolo, H00AQ3_A118MonedaId, H00AQ3_n118MonedaId, H00AQ3_A484TipoCuentaNombre, H00AQ3_A636TipoCuentaConcepto, H00AQ3_A483TipoCuentaId, H00AQ3_A639WalletCodRefencia, H00AQ3_A638WalletTipoEntidad, H00AQ3_A637WalletId
               }
            }
         );
         AV32Pgmname = "WalletPrompt";
         /* GeneXus formulas. */
         AV32Pgmname = "WalletPrompt";
         edtavSelect_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV11OrderedBy ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A118MonedaId ;
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
      private int edtWalletId_Enabled ;
      private int edtTipoCuentaId_Enabled ;
      private int edtTipoCuentaNombre_Enabled ;
      private int edtWalletCodRefencia_Enabled ;
      private int edtWalletNombre_Enabled ;
      private int edtMonedaId_Enabled ;
      private int edtMonedaISOSimbolo_Enabled ;
      private int edtWalletSaldo_Enabled ;
      private int AV15PageToGo ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8InOutWalletId ;
      private long wcpOAV8InOutWalletId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV22TFWalletId ;
      private long AV23TFWalletId_To ;
      private long AV16GridCurrentPage ;
      private long AV17GridPageCount ;
      private long A637WalletId ;
      private long A483TipoCuentaId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV30TFWalletSaldo ;
      private decimal AV31TFWalletSaldo_To ;
      private decimal A646WalletTotalDebito ;
      private decimal A647WalletTotalCredito ;
      private decimal A648WalletSaldo ;
      private decimal GXt_decimal1 ;
      private string AV9InOutWalletTipoEntidad ;
      private string wcpOAV9InOutWalletTipoEntidad ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_26_idx="0001" ;
      private string AV32Pgmname ;
      private string AV24TFWalletCodRefencia ;
      private string AV25TFWalletCodRefencia_Sel ;
      private string AV26TFWalletNombre ;
      private string AV27TFWalletNombre_Sel ;
      private string AV28TFMonedaISOSimbolo ;
      private string AV29TFMonedaISOSimbolo_Sel ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV19Select ;
      private string edtavSelect_Internalname ;
      private string edtWalletId_Internalname ;
      private string edtTipoCuentaId_Internalname ;
      private string cmbTipoCuentaConcepto_Internalname ;
      private string A636TipoCuentaConcepto ;
      private string A484TipoCuentaNombre ;
      private string edtTipoCuentaNombre_Internalname ;
      private string cmbWalletTipoEntidad_Internalname ;
      private string A638WalletTipoEntidad ;
      private string A639WalletCodRefencia ;
      private string edtWalletCodRefencia_Internalname ;
      private string A715WalletNombre ;
      private string edtWalletNombre_Internalname ;
      private string edtMonedaId_Internalname ;
      private string A119MonedaISOSimbolo ;
      private string edtMonedaISOSimbolo_Internalname ;
      private string edtWalletSaldo_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string lV24TFWalletCodRefencia ;
      private string lV28TFMonedaISOSimbolo ;
      private string GXt_char2 ;
      private string tblTablefilters_Internalname ;
      private string lblCleanfilters_Internalname ;
      private string lblCleanfilters_Jsonclick ;
      private string TempTags ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_26_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavSelect_Jsonclick ;
      private string edtWalletId_Jsonclick ;
      private string edtTipoCuentaId_Jsonclick ;
      private string GXCCtl ;
      private string cmbTipoCuentaConcepto_Jsonclick ;
      private string edtTipoCuentaNombre_Jsonclick ;
      private string cmbWalletTipoEntidad_Jsonclick ;
      private string edtWalletCodRefencia_Jsonclick ;
      private string edtWalletNombre_Jsonclick ;
      private string edtMonedaId_Jsonclick ;
      private string edtMonedaISOSimbolo_Jsonclick ;
      private string edtWalletSaldo_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12OrderedDsc ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n118MonedaId ;
      private bool bGXsfl_26_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV13FilterFullText ;
      private string AV18GridAppliedFilters ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private long aP0_InOutWalletId ;
      private string aP1_InOutWalletTipoEntidad ;
      private GXCombobox cmbTipoCuentaConcepto ;
      private GXCombobox cmbWalletTipoEntidad ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H00AQ2_A119MonedaISOSimbolo ;
      private short[] H00AQ2_A118MonedaId ;
      private bool[] H00AQ2_n118MonedaId ;
      private string[] H00AQ2_A484TipoCuentaNombre ;
      private string[] H00AQ2_A636TipoCuentaConcepto ;
      private long[] H00AQ2_A483TipoCuentaId ;
      private string[] H00AQ2_A639WalletCodRefencia ;
      private string[] H00AQ2_A638WalletTipoEntidad ;
      private long[] H00AQ2_A637WalletId ;
      private string[] H00AQ3_A119MonedaISOSimbolo ;
      private short[] H00AQ3_A118MonedaId ;
      private bool[] H00AQ3_n118MonedaId ;
      private string[] H00AQ3_A484TipoCuentaNombre ;
      private string[] H00AQ3_A636TipoCuentaConcepto ;
      private long[] H00AQ3_A483TipoCuentaId ;
      private string[] H00AQ3_A639WalletCodRefencia ;
      private string[] H00AQ3_A638WalletTipoEntidad ;
      private long[] H00AQ3_A637WalletId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV20GridState ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class walletprompt__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00AQ2( IGxContext context ,
                                             long AV22TFWalletId ,
                                             long AV23TFWalletId_To ,
                                             string AV25TFWalletCodRefencia_Sel ,
                                             string AV24TFWalletCodRefencia ,
                                             string AV29TFMonedaISOSimbolo_Sel ,
                                             string AV28TFMonedaISOSimbolo ,
                                             long A637WalletId ,
                                             string A639WalletCodRefencia ,
                                             string A119MonedaISOSimbolo ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV13FilterFullText ,
                                             string A715WalletNombre ,
                                             decimal A648WalletSaldo ,
                                             string AV27TFWalletNombre_Sel ,
                                             string AV26TFWalletNombre ,
                                             decimal AV30TFWalletSaldo ,
                                             decimal AV31TFWalletSaldo_To )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.[MonedaISOSimbolo], T1.[MonedaId], T3.[TipoCuentaNombre], T3.[TipoCuentaConcepto], T1.[TipoCuentaId], T1.[WalletCodRefencia], T1.[WalletTipoEntidad], T1.[WalletId] FROM (([Wallet] T1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId]) INNER JOIN [TipoCuenta] T3 ON T3.[TipoCuentaId] = T1.[TipoCuentaId])";
         if ( ! (0==AV22TFWalletId) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] >= @AV22TFWalletId)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV23TFWalletId_To) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] <= @AV23TFWalletId_To)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25TFWalletCodRefencia_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFWalletCodRefencia)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[WalletCodRefencia]) like UPPER(@lV24TFWalletCodRefencia))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFWalletCodRefencia_Sel)) && ! ( StringUtil.StrCmp(AV25TFWalletCodRefencia_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[WalletCodRefencia] = @AV25TFWalletCodRefencia_Sel)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV25TFWalletCodRefencia_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[WalletCodRefencia] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29TFMonedaISOSimbolo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFMonedaISOSimbolo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MonedaISOSimbolo]) like UPPER(@lV28TFMonedaISOSimbolo))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFMonedaISOSimbolo_Sel)) && ! ( StringUtil.StrCmp(AV29TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] = @AV29TFMonedaISOSimbolo_Sel)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV29TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] IS NULL or (T2.[MonedaISOSimbolo] = ''))");
         }
         scmdbuf += sWhereString;
         if ( AV11OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[WalletTipoEntidad]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[WalletId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[WalletId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[WalletCodRefencia]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[WalletCodRefencia] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MonedaISOSimbolo]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MonedaISOSimbolo] DESC";
         }
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H00AQ3( IGxContext context ,
                                             long AV22TFWalletId ,
                                             long AV23TFWalletId_To ,
                                             string AV25TFWalletCodRefencia_Sel ,
                                             string AV24TFWalletCodRefencia ,
                                             string AV29TFMonedaISOSimbolo_Sel ,
                                             string AV28TFMonedaISOSimbolo ,
                                             long A637WalletId ,
                                             string A639WalletCodRefencia ,
                                             string A119MonedaISOSimbolo ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV13FilterFullText ,
                                             string A715WalletNombre ,
                                             decimal A648WalletSaldo ,
                                             string AV27TFWalletNombre_Sel ,
                                             string AV26TFWalletNombre ,
                                             decimal AV30TFWalletSaldo ,
                                             decimal AV31TFWalletSaldo_To )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[6];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T2.[MonedaISOSimbolo], T1.[MonedaId], T3.[TipoCuentaNombre], T3.[TipoCuentaConcepto], T1.[TipoCuentaId], T1.[WalletCodRefencia], T1.[WalletTipoEntidad], T1.[WalletId] FROM (([Wallet] T1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId]) INNER JOIN [TipoCuenta] T3 ON T3.[TipoCuentaId] = T1.[TipoCuentaId])";
         if ( ! (0==AV22TFWalletId) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] >= @AV22TFWalletId)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! (0==AV23TFWalletId_To) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] <= @AV23TFWalletId_To)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25TFWalletCodRefencia_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFWalletCodRefencia)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[WalletCodRefencia]) like UPPER(@lV24TFWalletCodRefencia))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFWalletCodRefencia_Sel)) && ! ( StringUtil.StrCmp(AV25TFWalletCodRefencia_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[WalletCodRefencia] = @AV25TFWalletCodRefencia_Sel)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( StringUtil.StrCmp(AV25TFWalletCodRefencia_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[WalletCodRefencia] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29TFMonedaISOSimbolo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFMonedaISOSimbolo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MonedaISOSimbolo]) like UPPER(@lV28TFMonedaISOSimbolo))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFMonedaISOSimbolo_Sel)) && ! ( StringUtil.StrCmp(AV29TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] = @AV29TFMonedaISOSimbolo_Sel)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( StringUtil.StrCmp(AV29TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] IS NULL or (T2.[MonedaISOSimbolo] = ''))");
         }
         scmdbuf += sWhereString;
         if ( AV11OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[WalletTipoEntidad]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[WalletId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[WalletId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[WalletCodRefencia]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[WalletCodRefencia] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MonedaISOSimbolo]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MonedaISOSimbolo] DESC";
         }
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00AQ2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (decimal)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] );
               case 1 :
                     return conditional_H00AQ3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (decimal)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] );
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
          Object[] prmH00AQ2;
          prmH00AQ2 = new Object[] {
          new ParDef("@AV22TFWalletId",GXType.Decimal,18,0) ,
          new ParDef("@AV23TFWalletId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV24TFWalletCodRefencia",GXType.Char,25,0) ,
          new ParDef("@AV25TFWalletCodRefencia_Sel",GXType.NChar,25,0) ,
          new ParDef("@lV28TFMonedaISOSimbolo",GXType.Char,3,0) ,
          new ParDef("@AV29TFMonedaISOSimbolo_Sel",GXType.NChar,3,0)
          };
          Object[] prmH00AQ3;
          prmH00AQ3 = new Object[] {
          new ParDef("@AV22TFWalletId",GXType.Decimal,18,0) ,
          new ParDef("@AV23TFWalletId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV24TFWalletCodRefencia",GXType.Char,25,0) ,
          new ParDef("@AV25TFWalletCodRefencia_Sel",GXType.NChar,25,0) ,
          new ParDef("@lV28TFMonedaISOSimbolo",GXType.Char,3,0) ,
          new ParDef("@AV29TFMonedaISOSimbolo_Sel",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00AQ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AQ2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00AQ3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AQ3,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 120);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 25);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 120);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 25);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
