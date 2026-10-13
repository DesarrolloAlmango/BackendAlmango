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
   public class proveedorcomisionprompt : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public proveedorcomisionprompt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public proveedorcomisionprompt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_InProveedorID ,
                           ref long aP1_InOutProveedorComisionID ,
                           ref bool aP2_InOutProveedorComisionFP ,
                           ref string aP3_InOutProveedorComisionTipo )
      {
         this.AV8InProveedorID = aP0_InProveedorID;
         this.AV9InOutProveedorComisionID = aP1_InOutProveedorComisionID;
         this.AV21InOutProveedorComisionFP = aP2_InOutProveedorComisionFP;
         this.AV10InOutProveedorComisionTipo = aP3_InOutProveedorComisionTipo;
         ExecutePrivate();
         aP1_InOutProveedorComisionID=this.AV9InOutProveedorComisionID;
         aP2_InOutProveedorComisionFP=this.AV21InOutProveedorComisionFP;
         aP3_InOutProveedorComisionTipo=this.AV10InOutProveedorComisionTipo;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbProveedorComisionTipo = new GXCombobox();
         cmbProveedorComisionAccion = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "InProveedorID");
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
               gxfirstwebparm = GetFirstPar( "InProveedorID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "InProveedorID");
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
               AV8InProveedorID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8InProveedorID", StringUtil.LTrimStr( (decimal)(AV8InProveedorID), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9InOutProveedorComisionID = (long)(Math.Round(NumberUtil.Val( GetPar( "InOutProveedorComisionID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV9InOutProveedorComisionID", StringUtil.LTrimStr( (decimal)(AV9InOutProveedorComisionID), 18, 0));
                  AV21InOutProveedorComisionFP = StringUtil.StrToBool( GetPar( "InOutProveedorComisionFP"));
                  AssignAttri("", false, "AV21InOutProveedorComisionFP", AV21InOutProveedorComisionFP);
                  AV10InOutProveedorComisionTipo = GetPar( "InOutProveedorComisionTipo");
                  AssignAttri("", false, "AV10InOutProveedorComisionTipo", AV10InOutProveedorComisionTipo);
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
         AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV14FilterFullText = GetPar( "FilterFullText");
         AV8InProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "InProveedorID"), "."), 18, MidpointRounding.ToEven));
         AV22Pgmname = GetPar( "Pgmname");
         A1001ProveedorComisionFP = StringUtil.StrToBool( GetPar( "ProveedorComisionFP"));
         n1001ProveedorComisionFP = false;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV8InProveedorID, AV22Pgmname, A1001ProveedorComisionFP) ;
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
         PA4T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4T2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("proveedorcomisionprompt.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8InProveedorID,18,0)),UrlEncode(StringUtil.LTrimStr(AV9InOutProveedorComisionID,18,0)),UrlEncode(StringUtil.BoolToStr(AV21InOutProveedorComisionFP)),UrlEncode(StringUtil.RTrim(AV10InOutProveedorComisionTipo))}, new string[] {"InProveedorID","InOutProveedorComisionID","InOutProveedorComisionFP","InOutProveedorComisionTipo"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROVEEDORCOMISIONFP", GetSecureSignedToken( "", A1001ProveedorComisionFP, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ProveedorComisionPrompt");
         forbiddenHiddens.Add("ProveedorComisionFP", StringUtil.BoolToStr( A1001ProveedorComisionFP));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("proveedorcomisionprompt:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV14FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_26", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_26), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV19GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vINPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8InProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINOUTPROVEEDORCOMISIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9InOutProveedorComisionID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vINOUTPROVEEDORCOMISIONFP", AV21InOutProveedorComisionFP);
         GxWebStd.gx_hidden_field( context, "vINOUTPROVEEDORCOMISIONTIPO", StringUtil.RTrim( AV10InOutProveedorComisionTipo));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
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
            WE4T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4T2( ) ;
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
         return formatLink("proveedorcomisionprompt.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8InProveedorID,18,0)),UrlEncode(StringUtil.LTrimStr(AV9InOutProveedorComisionID,18,0)),UrlEncode(StringUtil.BoolToStr(AV21InOutProveedorComisionFP)),UrlEncode(StringUtil.RTrim(AV10InOutProveedorComisionTipo))}, new string[] {"InProveedorID","InOutProveedorComisionID","InOutProveedorComisionFP","InOutProveedorComisionTipo"})  ;
      }

      public override string GetPgmname( )
      {
         return "ProveedorComisionPrompt" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selecciona Comisiones", "") ;
      }

      protected void WB4T0( )
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
            wb_table1_14_4T2( true) ;
         }
         else
         {
            wb_table1_14_4T2( false) ;
         }
         return  ;
      }

      protected void wb_table1_14_4T2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("AppliedFilters", AV19GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProveedorComisionFP_Internalname, StringUtil.BoolToStr( A1001ProveedorComisionFP), StringUtil.BoolToStr( A1001ProveedorComisionFP), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", context.GetMessage( "Desactivado omitirá el precio freezado", ""), "", edtProveedorComisionFP_Jsonclick, 0, "Attribute", "", "", "", "", edtProveedorComisionFP_Visible, 0, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "", "end", false, "", "HLP_ProveedorComisionPrompt.htm");
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

      protected void START4T2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selecciona Comisiones", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4T0( ) ;
      }

      protected void WS4T2( )
      {
         START4T2( ) ;
         EVT4T2( ) ;
      }

      protected void EVT4T2( )
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
                              E114T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E124T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E134T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCLEANFILTERS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCleanFilters' */
                              E144T2 ();
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
                              AV20Select = cgiGet( edtavSelect_Internalname);
                              AssignAttri("", false, edtavSelect_Internalname, AV20Select);
                              A157ProveedorComisionID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorComisionID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A137MedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMedidasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A135InventarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtInventarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n135InventarioId = false;
                              A136InventarioNombre = cgiGet( edtInventarioNombre_Internalname);
                              A118MonedaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMonedaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A107EstadosTipo = cgiGet( edtEstadosTipo_Internalname);
                              A108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosGenericosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A109EstadosGenericosNombre = cgiGet( edtEstadosGenericosNombre_Internalname);
                              A181InventarioPrecioFinal = context.localUtil.CToN( cgiGet( edtInventarioPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              cmbProveedorComisionTipo.Name = cmbProveedorComisionTipo_Internalname;
                              cmbProveedorComisionTipo.CurrentValue = cgiGet( cmbProveedorComisionTipo_Internalname);
                              A346ProveedorComisionTipo = cgiGet( cmbProveedorComisionTipo_Internalname);
                              A347ProveedorComision = context.localUtil.CToN( cgiGet( edtProveedorComision_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              cmbProveedorComisionAccion.Name = cmbProveedorComisionAccion_Internalname;
                              cmbProveedorComisionAccion.CurrentValue = cgiGet( cmbProveedorComisionAccion_Internalname);
                              A348ProveedorComisionAccion = cgiGet( cmbProveedorComisionAccion_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E154T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E164T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E174T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV14FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E184T2 ();
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

      protected void WE4T2( )
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

      protected void PA4T2( )
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
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       string AV14FilterFullText ,
                                       long AV8InProveedorID ,
                                       string AV22Pgmname ,
                                       bool A1001ProveedorComisionFP )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4T2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ProveedorComisionPrompt");
         forbiddenHiddens.Add("ProveedorComisionFP", StringUtil.BoolToStr( A1001ProveedorComisionFP));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("proveedorcomisionprompt:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROVEEDORCOMISIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A157ProveedorComisionID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROVEEDORCOMISIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A157ProveedorComisionID), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_PROVEEDORCOMISIONTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A346ProveedorComisionTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "PROVEEDORCOMISIONTIPO", StringUtil.RTrim( A346ProveedorComisionTipo));
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
         RF4T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV22Pgmname = "ProveedorComisionPrompt";
         edtavSelect_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              AV14FilterFullText ,
                                              A157ProveedorComisionID ,
                                              A121RubrosId ,
                                              A137MedidasID ,
                                              A136InventarioNombre ,
                                              A107EstadosTipo ,
                                              A109EstadosGenericosNombre ,
                                              A181InventarioPrecioFinal ,
                                              A346ProveedorComisionTipo ,
                                              A347ProveedorComision ,
                                              A348ProveedorComisionAccion ,
                                              AV8InProveedorID ,
                                              A133ProveedorID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor H004T2 */
         pr_default.execute(0, new Object[] {AV8InProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133ProveedorID = H004T2_A133ProveedorID[0];
            A282ProveedorNombre = H004T2_A282ProveedorNombre[0];
            A1001ProveedorComisionFP = H004T2_A1001ProveedorComisionFP[0];
            n1001ProveedorComisionFP = H004T2_n1001ProveedorComisionFP[0];
            AssignAttri("", false, "A1001ProveedorComisionFP", A1001ProveedorComisionFP);
            GxWebStd.gx_hidden_field( context, "gxhash_PROVEEDORCOMISIONFP", GetSecureSignedToken( "", A1001ProveedorComisionFP, context));
            A348ProveedorComisionAccion = H004T2_A348ProveedorComisionAccion[0];
            A347ProveedorComision = H004T2_A347ProveedorComision[0];
            A346ProveedorComisionTipo = H004T2_A346ProveedorComisionTipo[0];
            A181InventarioPrecioFinal = H004T2_A181InventarioPrecioFinal[0];
            A109EstadosGenericosNombre = H004T2_A109EstadosGenericosNombre[0];
            A108EstadosGenericosId = H004T2_A108EstadosGenericosId[0];
            A107EstadosTipo = H004T2_A107EstadosTipo[0];
            A118MonedaId = H004T2_A118MonedaId[0];
            A136InventarioNombre = H004T2_A136InventarioNombre[0];
            A135InventarioId = H004T2_A135InventarioId[0];
            n135InventarioId = H004T2_n135InventarioId[0];
            A137MedidasID = H004T2_A137MedidasID[0];
            A121RubrosId = H004T2_A121RubrosId[0];
            A157ProveedorComisionID = H004T2_A157ProveedorComisionID[0];
            A282ProveedorNombre = H004T2_A282ProveedorNombre[0];
            A118MonedaId = H004T2_A118MonedaId[0];
            A181InventarioPrecioFinal = H004T2_A181InventarioPrecioFinal[0];
            A108EstadosGenericosId = H004T2_A108EstadosGenericosId[0];
            A107EstadosTipo = H004T2_A107EstadosTipo[0];
            A136InventarioNombre = H004T2_A136InventarioNombre[0];
            A109EstadosGenericosNombre = H004T2_A109EstadosGenericosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A157ProveedorComisionID), 18, 0) , StringUtil.PadR( "%" + AV14FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV14FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A137MedidasID), 18, 0) , StringUtil.PadR( "%" + AV14FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A136InventarioNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV14FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A107EstadosTipo) , StringUtil.PadR( "%" + StringUtil.Upper( AV14FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A109EstadosGenericosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV14FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A181InventarioPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV14FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "porcentaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV14FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A346ProveedorComisionTipo, "P") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "valor fijo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV14FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A346ProveedorComisionTipo, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "no aplica", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV14FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A346ProveedorComisionTipo, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A347ProveedorComision, 18, 2) , StringUtil.PadR( "%" + AV14FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "sin accion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV14FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A348ProveedorComisionAccion, "") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "suma", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV14FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A348ProveedorComisionAccion, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "resta", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV14FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A348ProveedorComisionAccion, "R") == 0 ) ) )
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

      protected void RF4T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 26;
         /* Execute user event: Refresh */
         E164T2 ();
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
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 AV14FilterFullText ,
                                                 A157ProveedorComisionID ,
                                                 A121RubrosId ,
                                                 A137MedidasID ,
                                                 A136InventarioNombre ,
                                                 A107EstadosTipo ,
                                                 A109EstadosGenericosNombre ,
                                                 A181InventarioPrecioFinal ,
                                                 A346ProveedorComisionTipo ,
                                                 A347ProveedorComision ,
                                                 A348ProveedorComisionAccion ,
                                                 AV8InProveedorID ,
                                                 A133ProveedorID } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H004T3 */
            pr_default.execute(1, new Object[] {AV8InProveedorID});
            nGXsfl_26_idx = 1;
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A133ProveedorID = H004T3_A133ProveedorID[0];
               A282ProveedorNombre = H004T3_A282ProveedorNombre[0];
               A1001ProveedorComisionFP = H004T3_A1001ProveedorComisionFP[0];
               n1001ProveedorComisionFP = H004T3_n1001ProveedorComisionFP[0];
               AssignAttri("", false, "A1001ProveedorComisionFP", A1001ProveedorComisionFP);
               GxWebStd.gx_hidden_field( context, "gxhash_PROVEEDORCOMISIONFP", GetSecureSignedToken( "", A1001ProveedorComisionFP, context));
               A348ProveedorComisionAccion = H004T3_A348ProveedorComisionAccion[0];
               A347ProveedorComision = H004T3_A347ProveedorComision[0];
               A346ProveedorComisionTipo = H004T3_A346ProveedorComisionTipo[0];
               A181InventarioPrecioFinal = H004T3_A181InventarioPrecioFinal[0];
               A109EstadosGenericosNombre = H004T3_A109EstadosGenericosNombre[0];
               A108EstadosGenericosId = H004T3_A108EstadosGenericosId[0];
               A107EstadosTipo = H004T3_A107EstadosTipo[0];
               A118MonedaId = H004T3_A118MonedaId[0];
               A136InventarioNombre = H004T3_A136InventarioNombre[0];
               A135InventarioId = H004T3_A135InventarioId[0];
               n135InventarioId = H004T3_n135InventarioId[0];
               A137MedidasID = H004T3_A137MedidasID[0];
               A121RubrosId = H004T3_A121RubrosId[0];
               A157ProveedorComisionID = H004T3_A157ProveedorComisionID[0];
               A282ProveedorNombre = H004T3_A282ProveedorNombre[0];
               A118MonedaId = H004T3_A118MonedaId[0];
               A181InventarioPrecioFinal = H004T3_A181InventarioPrecioFinal[0];
               A108EstadosGenericosId = H004T3_A108EstadosGenericosId[0];
               A107EstadosTipo = H004T3_A107EstadosTipo[0];
               A136InventarioNombre = H004T3_A136InventarioNombre[0];
               A109EstadosGenericosNombre = H004T3_A109EstadosGenericosNombre[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A157ProveedorComisionID), 18, 0) , StringUtil.PadR( "%" + AV14FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV14FilterFullText , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( (decimal)(A137MedidasID), 18, 0) , StringUtil.PadR( "%" + AV14FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A136InventarioNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV14FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A107EstadosTipo) , StringUtil.PadR( "%" + StringUtil.Upper( AV14FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A109EstadosGenericosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV14FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( A181InventarioPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV14FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "porcentaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV14FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A346ProveedorComisionTipo, "P") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "valor fijo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV14FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A346ProveedorComisionTipo, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "no aplica", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV14FilterFullText) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A346ProveedorComisionTipo, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A347ProveedorComision, 18, 2) , StringUtil.PadR( "%" + AV14FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "sin accion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV14FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A348ProveedorComisionAccion, "") ==
               0 ) ) || ( StringUtil.Like( context.GetMessage( "suma", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV14FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A348ProveedorComisionAccion, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "resta", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV14FilterFullText) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A348ProveedorComisionAccion, "R") == 0 ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E174T2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 26;
            WB4T0( ) ;
         }
         bGXsfl_26_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4T2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROVEEDORCOMISIONID"+"_"+sGXsfl_26_idx, GetSecureSignedToken( sGXsfl_26_idx, context.localUtil.Format( (decimal)(A157ProveedorComisionID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROVEEDORCOMISIONTIPO"+"_"+sGXsfl_26_idx, GetSecureSignedToken( sGXsfl_26_idx, StringUtil.RTrim( context.localUtil.Format( A346ProveedorComisionTipo, "")), context));
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV8InProveedorID, AV22Pgmname, A1001ProveedorComisionFP) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV8InProveedorID, AV22Pgmname, A1001ProveedorComisionFP) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV8InProveedorID, AV22Pgmname, A1001ProveedorComisionFP) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV8InProveedorID, AV22Pgmname, A1001ProveedorComisionFP) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV8InProveedorID, AV22Pgmname, A1001ProveedorComisionFP) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV22Pgmname = "ProveedorComisionPrompt";
         edtavSelect_Enabled = 0;
         edtProveedorComisionID_Enabled = 0;
         edtRubrosId_Enabled = 0;
         edtMedidasID_Enabled = 0;
         edtInventarioId_Enabled = 0;
         edtInventarioNombre_Enabled = 0;
         edtMonedaId_Enabled = 0;
         edtEstadosTipo_Enabled = 0;
         edtEstadosGenericosId_Enabled = 0;
         edtEstadosGenericosNombre_Enabled = 0;
         edtInventarioPrecioFinal_Enabled = 0;
         cmbProveedorComisionTipo.Enabled = 0;
         edtProveedorComision_Enabled = 0;
         cmbProveedorComisionAccion.Enabled = 0;
         edtProveedorComisionFP_Enabled = 0;
         AssignProp("", false, edtProveedorComisionFP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorComisionFP_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E154T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_26 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_26"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV17GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV18GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV19GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            /* Read variables values. */
            AV14FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            A1001ProveedorComisionFP = StringUtil.StrToBool( cgiGet( edtProveedorComisionFP_Internalname));
            n1001ProveedorComisionFP = false;
            AssignAttri("", false, "A1001ProveedorComisionFP", A1001ProveedorComisionFP);
            GxWebStd.gx_hidden_field( context, "gxhash_PROVEEDORCOMISIONFP", GetSecureSignedToken( "", A1001ProveedorComisionFP, context));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"ProveedorComisionPrompt");
            A1001ProveedorComisionFP = StringUtil.StrToBool( cgiGet( edtProveedorComisionFP_Internalname));
            n1001ProveedorComisionFP = false;
            AssignAttri("", false, "A1001ProveedorComisionFP", A1001ProveedorComisionFP);
            GxWebStd.gx_hidden_field( context, "gxhash_PROVEEDORCOMISIONFP", GetSecureSignedToken( "", A1001ProveedorComisionFP, context));
            forbiddenHiddens.Add("ProveedorComisionFP", StringUtil.BoolToStr( A1001ProveedorComisionFP));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("proveedorcomisionprompt:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV14FilterFullText) != 0 )
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
         E154T2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E154T2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( "Selecciona Comisiones", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         edtProveedorComisionFP_Visible = 0;
         AssignProp("", false, edtProveedorComisionFP_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorComisionFP_Visible), 5, 0), true);
         if ( AV12OrderedBy < 1 )
         {
            AV12OrderedBy = 1;
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E164T2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         AV17GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV17GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV17GridCurrentPage), 10, 0));
         AV18GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV18GridPageCount", StringUtil.LTrimStr( (decimal)(AV18GridPageCount), 10, 0));
         GXt_char2 = AV19GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV22Pgmname, out  GXt_char2) ;
         AV19GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV19GridAppliedFilters", AV19GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E114T2( )
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
            AV16PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV16PageToGo) ;
         }
         /*  Sending Event outputs  */
      }

      protected void E124T2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E134T2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E174T2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV20Select = "<i class=\"fas fa-check\"></i>";
            AssignAttri("", false, edtavSelect_Internalname, AV20Select);
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
         E184T2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E184T2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV9InOutProveedorComisionID = A157ProveedorComisionID;
         AssignAttri("", false, "AV9InOutProveedorComisionID", StringUtil.LTrimStr( (decimal)(AV9InOutProveedorComisionID), 18, 0));
         AV21InOutProveedorComisionFP = A1001ProveedorComisionFP;
         AssignAttri("", false, "AV21InOutProveedorComisionFP", AV21InOutProveedorComisionFP);
         AV10InOutProveedorComisionTipo = A346ProveedorComisionTipo;
         AssignAttri("", false, "AV10InOutProveedorComisionTipo", AV10InOutProveedorComisionTipo);
         context.setWebReturnParms(new Object[] {(long)AV9InOutProveedorComisionID,(bool)AV21InOutProveedorComisionFP,(string)AV10InOutProveedorComisionTipo});
         context.setWebReturnParmsMetadata(new Object[] {"AV9InOutProveedorComisionID","AV21InOutProveedorComisionFP","AV10InOutProveedorComisionTipo"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void E144T2( )
      {
         /* 'DoCleanFilters' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CLEANFILTERS' */
         S122 ();
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
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV14FilterFullText = "";
         AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
      }

      protected void wb_table1_14_4T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellAlignTop CellPaddingTop10'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCleanfilters_Internalname, context.GetMessage( "<i class=\"fas fa-filter CleanFiltersIcon\"></i>", ""), "", "", lblCleanfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOCLEANFILTERS\\'."+"'", "", "TextBlock", 5, context.GetMessage( "WWP_CleanFiltersTooltip", ""), 1, 1, 0, 1, "HLP_ProveedorComisionPrompt.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_26_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV14FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV14FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ProveedorComisionPrompt.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_14_4T2e( true) ;
         }
         else
         {
            wb_table1_14_4T2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8InProveedorID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV8InProveedorID", StringUtil.LTrimStr( (decimal)(AV8InProveedorID), 18, 0));
         AV9InOutProveedorComisionID = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV9InOutProveedorComisionID", StringUtil.LTrimStr( (decimal)(AV9InOutProveedorComisionID), 18, 0));
         AV21InOutProveedorComisionFP = (bool)getParm(obj,2);
         AssignAttri("", false, "AV21InOutProveedorComisionFP", AV21InOutProveedorComisionFP);
         AV10InOutProveedorComisionTipo = (string)getParm(obj,3);
         AssignAttri("", false, "AV10InOutProveedorComisionTipo", AV10InOutProveedorComisionTipo);
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
         PA4T2( ) ;
         WS4T2( ) ;
         WE4T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320141029", true, true, false);
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
         context.AddJavascriptSource("proveedorcomisionprompt.js", "?20269320141029", false, true, false);
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
         edtProveedorComisionID_Internalname = "PROVEEDORCOMISIONID_"+sGXsfl_26_idx;
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_26_idx;
         edtMedidasID_Internalname = "MEDIDASID_"+sGXsfl_26_idx;
         edtInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_26_idx;
         edtInventarioNombre_Internalname = "INVENTARIONOMBRE_"+sGXsfl_26_idx;
         edtMonedaId_Internalname = "MONEDAID_"+sGXsfl_26_idx;
         edtEstadosTipo_Internalname = "ESTADOSTIPO_"+sGXsfl_26_idx;
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_26_idx;
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE_"+sGXsfl_26_idx;
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL_"+sGXsfl_26_idx;
         cmbProveedorComisionTipo_Internalname = "PROVEEDORCOMISIONTIPO_"+sGXsfl_26_idx;
         edtProveedorComision_Internalname = "PROVEEDORCOMISION_"+sGXsfl_26_idx;
         cmbProveedorComisionAccion_Internalname = "PROVEEDORCOMISIONACCION_"+sGXsfl_26_idx;
      }

      protected void SubsflControlProps_fel_262( )
      {
         edtavSelect_Internalname = "vSELECT_"+sGXsfl_26_fel_idx;
         edtProveedorComisionID_Internalname = "PROVEEDORCOMISIONID_"+sGXsfl_26_fel_idx;
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_26_fel_idx;
         edtMedidasID_Internalname = "MEDIDASID_"+sGXsfl_26_fel_idx;
         edtInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_26_fel_idx;
         edtInventarioNombre_Internalname = "INVENTARIONOMBRE_"+sGXsfl_26_fel_idx;
         edtMonedaId_Internalname = "MONEDAID_"+sGXsfl_26_fel_idx;
         edtEstadosTipo_Internalname = "ESTADOSTIPO_"+sGXsfl_26_fel_idx;
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_26_fel_idx;
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE_"+sGXsfl_26_fel_idx;
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL_"+sGXsfl_26_fel_idx;
         cmbProveedorComisionTipo_Internalname = "PROVEEDORCOMISIONTIPO_"+sGXsfl_26_fel_idx;
         edtProveedorComision_Internalname = "PROVEEDORCOMISION_"+sGXsfl_26_fel_idx;
         cmbProveedorComisionAccion_Internalname = "PROVEEDORCOMISIONACCION_"+sGXsfl_26_fel_idx;
      }

      protected void sendrow_262( )
      {
         sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
         SubsflControlProps_262( ) ;
         WB4T0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSelect_Internalname,StringUtil.RTrim( AV20Select),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"","'"+""+"'"+",false,"+"'"+"EENTER."+sGXsfl_26_idx+"'",(string)"",(string)"",context.GetMessage( "GX_BtnSelect", ""),(string)"",(string)edtavSelect_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavSelect_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorComisionID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A157ProveedorComisionID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A157ProveedorComisionID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorComisionID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidasID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A137MedidasID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidasID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A135InventarioId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioNombre_Internalname,StringUtil.RTrim( A136InventarioNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMonedaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A118MonedaId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMonedaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosTipo_Internalname,StringUtil.RTrim( A107EstadosTipo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosGenericosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosNombre_Internalname,StringUtil.RTrim( A109EstadosGenericosNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosGenericosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A181InventarioPrecioFinal, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbProveedorComisionTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROVEEDORCOMISIONTIPO_" + sGXsfl_26_idx;
               cmbProveedorComisionTipo.Name = GXCCtl;
               cmbProveedorComisionTipo.WebTags = "";
               cmbProveedorComisionTipo.addItem("P", context.GetMessage( "Porcentaje", ""), 0);
               cmbProveedorComisionTipo.addItem("F", context.GetMessage( "Valor Fijo", ""), 0);
               cmbProveedorComisionTipo.addItem("N", context.GetMessage( "No Aplica", ""), 0);
               if ( cmbProveedorComisionTipo.ItemCount > 0 )
               {
                  A346ProveedorComisionTipo = cmbProveedorComisionTipo.getValidValue(A346ProveedorComisionTipo);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProveedorComisionTipo,(string)cmbProveedorComisionTipo_Internalname,StringUtil.RTrim( A346ProveedorComisionTipo),(short)1,(string)cmbProveedorComisionTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbProveedorComisionTipo.CurrentValue = StringUtil.RTrim( A346ProveedorComisionTipo);
            AssignProp("", false, cmbProveedorComisionTipo_Internalname, "Values", (string)(cmbProveedorComisionTipo.ToJavascriptSource()), !bGXsfl_26_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorComision_Internalname,StringUtil.LTrim( StringUtil.NToC( A347ProveedorComision, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A347ProveedorComision, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorComision_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbProveedorComisionAccion.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROVEEDORCOMISIONACCION_" + sGXsfl_26_idx;
               cmbProveedorComisionAccion.Name = GXCCtl;
               cmbProveedorComisionAccion.WebTags = "";
               cmbProveedorComisionAccion.addItem("", context.GetMessage( "Sin Accion", ""), 0);
               cmbProveedorComisionAccion.addItem("S", context.GetMessage( "Suma", ""), 0);
               cmbProveedorComisionAccion.addItem("R", context.GetMessage( "Resta", ""), 0);
               if ( cmbProveedorComisionAccion.ItemCount > 0 )
               {
                  A348ProveedorComisionAccion = cmbProveedorComisionAccion.getValidValue(A348ProveedorComisionAccion);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProveedorComisionAccion,(string)cmbProveedorComisionAccion_Internalname,StringUtil.RTrim( A348ProveedorComisionAccion),(short)1,(string)cmbProveedorComisionAccion_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbProveedorComisionAccion.CurrentValue = StringUtil.RTrim( A348ProveedorComisionAccion);
            AssignProp("", false, cmbProveedorComisionAccion_Internalname, "Values", (string)(cmbProveedorComisionAccion.ToJavascriptSource()), !bGXsfl_26_Refreshing);
            send_integrity_lvl_hashes4T2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_26_idx = ((subGrid_Islastpage==1)&&(nGXsfl_26_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_26_idx+1);
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
         }
         /* End function sendrow_262 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "PROVEEDORCOMISIONTIPO_" + sGXsfl_26_idx;
         cmbProveedorComisionTipo.Name = GXCCtl;
         cmbProveedorComisionTipo.WebTags = "";
         cmbProveedorComisionTipo.addItem("P", context.GetMessage( "Porcentaje", ""), 0);
         cmbProveedorComisionTipo.addItem("F", context.GetMessage( "Valor Fijo", ""), 0);
         cmbProveedorComisionTipo.addItem("N", context.GetMessage( "No Aplica", ""), 0);
         if ( cmbProveedorComisionTipo.ItemCount > 0 )
         {
            A346ProveedorComisionTipo = cmbProveedorComisionTipo.getValidValue(A346ProveedorComisionTipo);
         }
         GXCCtl = "PROVEEDORCOMISIONACCION_" + sGXsfl_26_idx;
         cmbProveedorComisionAccion.Name = GXCCtl;
         cmbProveedorComisionAccion.WebTags = "";
         cmbProveedorComisionAccion.addItem("", context.GetMessage( "Sin Accion", ""), 0);
         cmbProveedorComisionAccion.addItem("S", context.GetMessage( "Suma", ""), 0);
         cmbProveedorComisionAccion.addItem("R", context.GetMessage( "Resta", ""), 0);
         if ( cmbProveedorComisionAccion.ItemCount > 0 )
         {
            A348ProveedorComisionAccion = cmbProveedorComisionAccion.getValidValue(A348ProveedorComisionAccion);
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
            context.SendWebValue( context.GetMessage( "Identificador", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rubros Identificador ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Items/Característica", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Detalle", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Producto/Característica", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Moneda", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo de Estados", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identificador", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comisión", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Acción", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV20Select)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSelect_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A157ProveedorComisionID), 18, 0, ".", ""))));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A136InventarioNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A107EstadosTipo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A109EstadosGenericosNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A346ProveedorComisionTipo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A347ProveedorComision, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A348ProveedorComisionAccion)));
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
         edtProveedorComisionID_Internalname = "PROVEEDORCOMISIONID";
         edtRubrosId_Internalname = "RUBROSID";
         edtMedidasID_Internalname = "MEDIDASID";
         edtInventarioId_Internalname = "INVENTARIOID";
         edtInventarioNombre_Internalname = "INVENTARIONOMBRE";
         edtMonedaId_Internalname = "MONEDAID";
         edtEstadosTipo_Internalname = "ESTADOSTIPO";
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID";
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE";
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL";
         cmbProveedorComisionTipo_Internalname = "PROVEEDORCOMISIONTIPO";
         edtProveedorComision_Internalname = "PROVEEDORCOMISION";
         cmbProveedorComisionAccion_Internalname = "PROVEEDORCOMISIONACCION";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         edtProveedorComisionFP_Internalname = "PROVEEDORCOMISIONFP";
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
         cmbProveedorComisionAccion_Jsonclick = "";
         edtProveedorComision_Jsonclick = "";
         cmbProveedorComisionTipo_Jsonclick = "";
         edtInventarioPrecioFinal_Jsonclick = "";
         edtEstadosGenericosNombre_Jsonclick = "";
         edtEstadosGenericosId_Jsonclick = "";
         edtEstadosTipo_Jsonclick = "";
         edtMonedaId_Jsonclick = "";
         edtInventarioNombre_Jsonclick = "";
         edtInventarioId_Jsonclick = "";
         edtMedidasID_Jsonclick = "";
         edtRubrosId_Jsonclick = "";
         edtProveedorComisionID_Jsonclick = "";
         edtavSelect_Jsonclick = "";
         edtavSelect_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtProveedorComisionFP_Enabled = 0;
         cmbProveedorComisionAccion.Enabled = 0;
         edtProveedorComision_Enabled = 0;
         cmbProveedorComisionTipo.Enabled = 0;
         edtInventarioPrecioFinal_Enabled = 0;
         edtEstadosGenericosNombre_Enabled = 0;
         edtEstadosGenericosId_Enabled = 0;
         edtEstadosTipo_Enabled = 0;
         edtMonedaId_Enabled = 0;
         edtInventarioNombre_Enabled = 0;
         edtInventarioId_Enabled = 0;
         edtMedidasID_Enabled = 0;
         edtRubrosId_Enabled = 0;
         edtProveedorComisionID_Enabled = 0;
         subGrid_Sortable = 0;
         edtProveedorComisionFP_Jsonclick = "";
         edtProveedorComisionFP_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|7|8|9|10|11";
         Ddo_grid_Columnids = "1:ProveedorComisionID|2:RubrosId|3:MedidasID|5:InventarioNombre|7:EstadosTipo|9:EstadosGenericosNombre|10:InventarioPrecioFinal|11:ProveedorComisionTipo|12:ProveedorComision|13:ProveedorComisionAccion";
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
         Form.Caption = context.GetMessage( "Selecciona Comisiones", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV12OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV13OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV14FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8InProveedorID',fld:'vINPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'A1001ProveedorComisionFP',fld:'PROVEEDORCOMISIONFP',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV17GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV18GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV19GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E114T2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV12OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV13OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV14FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8InProveedorID',fld:'vINPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'A1001ProveedorComisionFP',fld:'PROVEEDORCOMISIONFP',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV17GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV18GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV19GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E124T2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV12OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV13OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV14FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8InProveedorID',fld:'vINPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'A1001ProveedorComisionFP',fld:'PROVEEDORCOMISIONFP',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E134T2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV12OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV13OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV14FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8InProveedorID',fld:'vINPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'A1001ProveedorComisionFP',fld:'PROVEEDORCOMISIONFP',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV12OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV13OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E174T2',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV20Select',fld:'vSELECT',pic:'',type:'char'}]}");
         setEventMetadata("ENTER","{handler:'E184T2',iparms:[{av:'A157ProveedorComisionID',fld:'PROVEEDORCOMISIONID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A1001ProveedorComisionFP',fld:'PROVEEDORCOMISIONFP',pic:'',hsh:true,type:'boolean'},{av:'cmbProveedorComisionTipo'},{av:'A346ProveedorComisionTipo',fld:'PROVEEDORCOMISIONTIPO',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV9InOutProveedorComisionID',fld:'vINOUTPROVEEDORCOMISIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21InOutProveedorComisionFP',fld:'vINOUTPROVEEDORCOMISIONFP',pic:'',type:'boolean'},{av:'AV10InOutProveedorComisionTipo',fld:'vINOUTPROVEEDORCOMISIONTIPO',pic:'',type:'char'}]}");
         setEventMetadata("'DOCLEANFILTERS'","{handler:'E144T2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV12OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV13OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV14FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8InProveedorID',fld:'vINPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'A1001ProveedorComisionFP',fld:'PROVEEDORCOMISIONFP',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'DOCLEANFILTERS'",",oparms:[{av:'AV14FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'}]}");
         setEventMetadata("VALID_PROVEEDORCOMISIONID","{handler:'Valid_Proveedorcomisionid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORCOMISIONID",",oparms:[]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[]");
         setEventMetadata("VALID_RUBROSID",",oparms:[]}");
         setEventMetadata("VALID_MEDIDASID","{handler:'Valid_Medidasid',iparms:[]");
         setEventMetadata("VALID_MEDIDASID",",oparms:[]}");
         setEventMetadata("VALID_INVENTARIOID","{handler:'Valid_Inventarioid',iparms:[]");
         setEventMetadata("VALID_INVENTARIOID",",oparms:[]}");
         setEventMetadata("VALID_INVENTARIONOMBRE","{handler:'Valid_Inventarionombre',iparms:[]");
         setEventMetadata("VALID_INVENTARIONOMBRE",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSTIPO","{handler:'Valid_Estadostipo',iparms:[]");
         setEventMetadata("VALID_ESTADOSTIPO",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSGENERICOSID","{handler:'Valid_Estadosgenericosid',iparms:[]");
         setEventMetadata("VALID_ESTADOSGENERICOSID",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSGENERICOSNOMBRE","{handler:'Valid_Estadosgenericosnombre',iparms:[]");
         setEventMetadata("VALID_ESTADOSGENERICOSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_INVENTARIOPRECIOFINAL","{handler:'Valid_Inventariopreciofinal',iparms:[]");
         setEventMetadata("VALID_INVENTARIOPRECIOFINAL",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORCOMISIONTIPO","{handler:'Valid_Proveedorcomisiontipo',iparms:[]");
         setEventMetadata("VALID_PROVEEDORCOMISIONTIPO",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORCOMISION","{handler:'Valid_Proveedorcomision',iparms:[]");
         setEventMetadata("VALID_PROVEEDORCOMISION",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORCOMISIONACCION","{handler:'Valid_Proveedorcomisionaccion',iparms:[]");
         setEventMetadata("VALID_PROVEEDORCOMISIONACCION",",oparms:[]}");
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
         wcpOAV10InOutProveedorComisionTipo = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV14FilterFullText = "";
         AV22Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         AV19GridAppliedFilters = "";
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
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
         AV20Select = "";
         A136InventarioNombre = "";
         A107EstadosTipo = "";
         A109EstadosGenericosNombre = "";
         A346ProveedorComisionTipo = "";
         A348ProveedorComisionAccion = "";
         H004T2_A133ProveedorID = new long[1] ;
         H004T2_A282ProveedorNombre = new string[] {""} ;
         H004T2_A1001ProveedorComisionFP = new bool[] {false} ;
         H004T2_n1001ProveedorComisionFP = new bool[] {false} ;
         H004T2_A348ProveedorComisionAccion = new string[] {""} ;
         H004T2_A347ProveedorComision = new decimal[1] ;
         H004T2_A346ProveedorComisionTipo = new string[] {""} ;
         H004T2_A181InventarioPrecioFinal = new decimal[1] ;
         H004T2_A109EstadosGenericosNombre = new string[] {""} ;
         H004T2_A108EstadosGenericosId = new int[1] ;
         H004T2_A107EstadosTipo = new string[] {""} ;
         H004T2_A118MonedaId = new short[1] ;
         H004T2_A136InventarioNombre = new string[] {""} ;
         H004T2_A135InventarioId = new long[1] ;
         H004T2_n135InventarioId = new bool[] {false} ;
         H004T2_A137MedidasID = new long[1] ;
         H004T2_A121RubrosId = new short[1] ;
         H004T2_A157ProveedorComisionID = new long[1] ;
         A282ProveedorNombre = "";
         H004T3_A133ProveedorID = new long[1] ;
         H004T3_A282ProveedorNombre = new string[] {""} ;
         H004T3_A1001ProveedorComisionFP = new bool[] {false} ;
         H004T3_n1001ProveedorComisionFP = new bool[] {false} ;
         H004T3_A348ProveedorComisionAccion = new string[] {""} ;
         H004T3_A347ProveedorComision = new decimal[1] ;
         H004T3_A346ProveedorComisionTipo = new string[] {""} ;
         H004T3_A181InventarioPrecioFinal = new decimal[1] ;
         H004T3_A109EstadosGenericosNombre = new string[] {""} ;
         H004T3_A108EstadosGenericosId = new int[1] ;
         H004T3_A107EstadosTipo = new string[] {""} ;
         H004T3_A118MonedaId = new short[1] ;
         H004T3_A136InventarioNombre = new string[] {""} ;
         H004T3_A135InventarioId = new long[1] ;
         H004T3_n135InventarioId = new bool[] {false} ;
         H004T3_A137MedidasID = new long[1] ;
         H004T3_A121RubrosId = new short[1] ;
         H004T3_A157ProveedorComisionID = new long[1] ;
         hsh = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_char2 = "";
         GridRow = new GXWebRow();
         lblCleanfilters_Jsonclick = "";
         TempTags = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.proveedorcomisionprompt__default(),
            new Object[][] {
                new Object[] {
               H004T2_A133ProveedorID, H004T2_A282ProveedorNombre, H004T2_A1001ProveedorComisionFP, H004T2_n1001ProveedorComisionFP, H004T2_A348ProveedorComisionAccion, H004T2_A347ProveedorComision, H004T2_A346ProveedorComisionTipo, H004T2_A181InventarioPrecioFinal, H004T2_A109EstadosGenericosNombre, H004T2_A108EstadosGenericosId,
               H004T2_A107EstadosTipo, H004T2_A118MonedaId, H004T2_A136InventarioNombre, H004T2_A135InventarioId, H004T2_n135InventarioId, H004T2_A137MedidasID, H004T2_A121RubrosId, H004T2_A157ProveedorComisionID
               }
               , new Object[] {
               H004T3_A133ProveedorID, H004T3_A282ProveedorNombre, H004T3_A1001ProveedorComisionFP, H004T3_n1001ProveedorComisionFP, H004T3_A348ProveedorComisionAccion, H004T3_A347ProveedorComision, H004T3_A346ProveedorComisionTipo, H004T3_A181InventarioPrecioFinal, H004T3_A109EstadosGenericosNombre, H004T3_A108EstadosGenericosId,
               H004T3_A107EstadosTipo, H004T3_A118MonedaId, H004T3_A136InventarioNombre, H004T3_A135InventarioId, H004T3_n135InventarioId, H004T3_A137MedidasID, H004T3_A121RubrosId, H004T3_A157ProveedorComisionID
               }
            }
         );
         AV22Pgmname = "ProveedorComisionPrompt";
         /* GeneXus formulas. */
         AV22Pgmname = "ProveedorComisionPrompt";
         edtavSelect_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV12OrderedBy ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A121RubrosId ;
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
      private int edtProveedorComisionFP_Visible ;
      private int A108EstadosGenericosId ;
      private int subGrid_Islastpage ;
      private int edtavSelect_Enabled ;
      private int edtProveedorComisionID_Enabled ;
      private int edtRubrosId_Enabled ;
      private int edtMedidasID_Enabled ;
      private int edtInventarioId_Enabled ;
      private int edtInventarioNombre_Enabled ;
      private int edtMonedaId_Enabled ;
      private int edtEstadosTipo_Enabled ;
      private int edtEstadosGenericosId_Enabled ;
      private int edtEstadosGenericosNombre_Enabled ;
      private int edtInventarioPrecioFinal_Enabled ;
      private int edtProveedorComision_Enabled ;
      private int edtProveedorComisionFP_Enabled ;
      private int AV16PageToGo ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8InProveedorID ;
      private long AV9InOutProveedorComisionID ;
      private long wcpOAV8InProveedorID ;
      private long wcpOAV9InOutProveedorComisionID ;
      private long GRID_nFirstRecordOnPage ;
      private long AV17GridCurrentPage ;
      private long AV18GridPageCount ;
      private long A157ProveedorComisionID ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long A133ProveedorID ;
      private decimal A181InventarioPrecioFinal ;
      private decimal A347ProveedorComision ;
      private string AV10InOutProveedorComisionTipo ;
      private string wcpOAV10InOutProveedorComisionTipo ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_26_idx="0001" ;
      private string AV22Pgmname ;
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
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
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
      private string edtProveedorComisionFP_Internalname ;
      private string edtProveedorComisionFP_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV20Select ;
      private string edtavSelect_Internalname ;
      private string edtProveedorComisionID_Internalname ;
      private string edtRubrosId_Internalname ;
      private string edtMedidasID_Internalname ;
      private string edtInventarioId_Internalname ;
      private string A136InventarioNombre ;
      private string edtInventarioNombre_Internalname ;
      private string edtMonedaId_Internalname ;
      private string A107EstadosTipo ;
      private string edtEstadosTipo_Internalname ;
      private string edtEstadosGenericosId_Internalname ;
      private string A109EstadosGenericosNombre ;
      private string edtEstadosGenericosNombre_Internalname ;
      private string edtInventarioPrecioFinal_Internalname ;
      private string cmbProveedorComisionTipo_Internalname ;
      private string A346ProveedorComisionTipo ;
      private string edtProveedorComision_Internalname ;
      private string cmbProveedorComisionAccion_Internalname ;
      private string A348ProveedorComisionAccion ;
      private string edtavFilterfulltext_Internalname ;
      private string A282ProveedorNombre ;
      private string hsh ;
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
      private string edtProveedorComisionID_Jsonclick ;
      private string edtRubrosId_Jsonclick ;
      private string edtMedidasID_Jsonclick ;
      private string edtInventarioId_Jsonclick ;
      private string edtInventarioNombre_Jsonclick ;
      private string edtMonedaId_Jsonclick ;
      private string edtEstadosTipo_Jsonclick ;
      private string edtEstadosGenericosId_Jsonclick ;
      private string edtEstadosGenericosNombre_Jsonclick ;
      private string edtInventarioPrecioFinal_Jsonclick ;
      private string GXCCtl ;
      private string cmbProveedorComisionTipo_Jsonclick ;
      private string edtProveedorComision_Jsonclick ;
      private string cmbProveedorComisionAccion_Jsonclick ;
      private string subGrid_Header ;
      private bool AV21InOutProveedorComisionFP ;
      private bool wcpOAV21InOutProveedorComisionFP ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool A1001ProveedorComisionFP ;
      private bool n1001ProveedorComisionFP ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n135InventarioId ;
      private bool bGXsfl_26_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV14FilterFullText ;
      private string AV19GridAppliedFilters ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private long aP1_InOutProveedorComisionID ;
      private bool aP2_InOutProveedorComisionFP ;
      private string aP3_InOutProveedorComisionTipo ;
      private GXCombobox cmbProveedorComisionTipo ;
      private GXCombobox cmbProveedorComisionAccion ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private long[] H004T2_A133ProveedorID ;
      private string[] H004T2_A282ProveedorNombre ;
      private bool[] H004T2_A1001ProveedorComisionFP ;
      private bool[] H004T2_n1001ProveedorComisionFP ;
      private string[] H004T2_A348ProveedorComisionAccion ;
      private decimal[] H004T2_A347ProveedorComision ;
      private string[] H004T2_A346ProveedorComisionTipo ;
      private decimal[] H004T2_A181InventarioPrecioFinal ;
      private string[] H004T2_A109EstadosGenericosNombre ;
      private int[] H004T2_A108EstadosGenericosId ;
      private string[] H004T2_A107EstadosTipo ;
      private short[] H004T2_A118MonedaId ;
      private string[] H004T2_A136InventarioNombre ;
      private long[] H004T2_A135InventarioId ;
      private bool[] H004T2_n135InventarioId ;
      private long[] H004T2_A137MedidasID ;
      private short[] H004T2_A121RubrosId ;
      private long[] H004T2_A157ProveedorComisionID ;
      private long[] H004T3_A133ProveedorID ;
      private string[] H004T3_A282ProveedorNombre ;
      private bool[] H004T3_A1001ProveedorComisionFP ;
      private bool[] H004T3_n1001ProveedorComisionFP ;
      private string[] H004T3_A348ProveedorComisionAccion ;
      private decimal[] H004T3_A347ProveedorComision ;
      private string[] H004T3_A346ProveedorComisionTipo ;
      private decimal[] H004T3_A181InventarioPrecioFinal ;
      private string[] H004T3_A109EstadosGenericosNombre ;
      private int[] H004T3_A108EstadosGenericosId ;
      private string[] H004T3_A107EstadosTipo ;
      private short[] H004T3_A118MonedaId ;
      private string[] H004T3_A136InventarioNombre ;
      private long[] H004T3_A135InventarioId ;
      private bool[] H004T3_n135InventarioId ;
      private long[] H004T3_A137MedidasID ;
      private short[] H004T3_A121RubrosId ;
      private long[] H004T3_A157ProveedorComisionID ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class proveedorcomisionprompt__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004T2( IGxContext context ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             string AV14FilterFullText ,
                                             long A157ProveedorComisionID ,
                                             short A121RubrosId ,
                                             long A137MedidasID ,
                                             string A136InventarioNombre ,
                                             string A107EstadosTipo ,
                                             string A109EstadosGenericosNombre ,
                                             decimal A181InventarioPrecioFinal ,
                                             string A346ProveedorComisionTipo ,
                                             decimal A347ProveedorComision ,
                                             string A348ProveedorComisionAccion ,
                                             long AV8InProveedorID ,
                                             long A133ProveedorID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[ProveedorID], T2.[ProveedorNombre], T1.[ProveedorComisionFP], T1.[ProveedorComisionAccion], T1.[ProveedorComision], T1.[ProveedorComisionTipo], T4.[InventarioPrecioFinal], T5.[EstadosGenericosNombre], T4.[EstadosGenericosId], T4.[EstadosTipo], T3.[MonedaId], T4.[InventarioNombre], T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T1.[ProveedorComisionID] FROM (((([ProveedorComision] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) LEFT JOIN [Inventario] T4 ON T4.[RubrosId] = T1.[RubrosId] AND T4.[MedidasID] = T1.[MedidasID] AND T4.[InventarioId] = T1.[InventarioId]) LEFT JOIN [EstadosGenericos] T5 ON T5.[EstadosTipo] = T4.[EstadosTipo] AND T5.[EstadosGenericosId] = T4.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[ProveedorID] = @AV8InProveedorID)");
         scmdbuf += sWhereString;
         if ( AV12OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T2.[ProveedorNombre]";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComisionID]";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComisionID] DESC";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId]";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MedidasID]";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MedidasID] DESC";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[InventarioNombre]";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[InventarioNombre] DESC";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[EstadosTipo]";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[EstadosTipo] DESC";
         }
         else if ( ( AV12OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.[EstadosGenericosNombre]";
         }
         else if ( ( AV12OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.[EstadosGenericosNombre] DESC";
         }
         else if ( ( AV12OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[InventarioPrecioFinal]";
         }
         else if ( ( AV12OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[InventarioPrecioFinal] DESC";
         }
         else if ( ( AV12OrderedBy == 9 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComisionTipo]";
         }
         else if ( ( AV12OrderedBy == 9 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComisionTipo] DESC";
         }
         else if ( ( AV12OrderedBy == 10 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComision]";
         }
         else if ( ( AV12OrderedBy == 10 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComision] DESC";
         }
         else if ( ( AV12OrderedBy == 11 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComisionAccion]";
         }
         else if ( ( AV12OrderedBy == 11 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComisionAccion] DESC";
         }
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H004T3( IGxContext context ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             string AV14FilterFullText ,
                                             long A157ProveedorComisionID ,
                                             short A121RubrosId ,
                                             long A137MedidasID ,
                                             string A136InventarioNombre ,
                                             string A107EstadosTipo ,
                                             string A109EstadosGenericosNombre ,
                                             decimal A181InventarioPrecioFinal ,
                                             string A346ProveedorComisionTipo ,
                                             decimal A347ProveedorComision ,
                                             string A348ProveedorComisionAccion ,
                                             long AV8InProveedorID ,
                                             long A133ProveedorID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[1];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[ProveedorID], T2.[ProveedorNombre], T1.[ProveedorComisionFP], T1.[ProveedorComisionAccion], T1.[ProveedorComision], T1.[ProveedorComisionTipo], T4.[InventarioPrecioFinal], T5.[EstadosGenericosNombre], T4.[EstadosGenericosId], T4.[EstadosTipo], T3.[MonedaId], T4.[InventarioNombre], T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T1.[ProveedorComisionID] FROM (((([ProveedorComision] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) LEFT JOIN [Inventario] T4 ON T4.[RubrosId] = T1.[RubrosId] AND T4.[MedidasID] = T1.[MedidasID] AND T4.[InventarioId] = T1.[InventarioId]) LEFT JOIN [EstadosGenericos] T5 ON T5.[EstadosTipo] = T4.[EstadosTipo] AND T5.[EstadosGenericosId] = T4.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[ProveedorID] = @AV8InProveedorID)");
         scmdbuf += sWhereString;
         if ( AV12OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T2.[ProveedorNombre]";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComisionID]";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComisionID] DESC";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId]";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MedidasID]";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MedidasID] DESC";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[InventarioNombre]";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[InventarioNombre] DESC";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[EstadosTipo]";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[EstadosTipo] DESC";
         }
         else if ( ( AV12OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.[EstadosGenericosNombre]";
         }
         else if ( ( AV12OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.[EstadosGenericosNombre] DESC";
         }
         else if ( ( AV12OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[InventarioPrecioFinal]";
         }
         else if ( ( AV12OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[InventarioPrecioFinal] DESC";
         }
         else if ( ( AV12OrderedBy == 9 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComisionTipo]";
         }
         else if ( ( AV12OrderedBy == 9 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComisionTipo] DESC";
         }
         else if ( ( AV12OrderedBy == 10 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComision]";
         }
         else if ( ( AV12OrderedBy == 10 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComision] DESC";
         }
         else if ( ( AV12OrderedBy == 11 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComisionAccion]";
         }
         else if ( ( AV12OrderedBy == 11 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorComisionAccion] DESC";
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
                     return conditional_H004T2(context, (short)dynConstraints[0] , (bool)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (short)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] );
               case 1 :
                     return conditional_H004T3(context, (short)dynConstraints[0] , (bool)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (short)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] );
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
          Object[] prmH004T2;
          prmH004T2 = new Object[] {
          new ParDef("@AV8InProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmH004T3;
          prmH004T3 = new Object[] {
          new ParDef("@AV8InProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004T2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004T3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004T3,11, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 1);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 1);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 80);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 3);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                ((string[]) buf[12])[0] = rslt.getString(12, 100);
                ((long[]) buf[13])[0] = rslt.getLong(13);
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
                ((long[]) buf[15])[0] = rslt.getLong(14);
                ((short[]) buf[16])[0] = rslt.getShort(15);
                ((long[]) buf[17])[0] = rslt.getLong(16);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 1);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 1);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 80);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 3);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                ((string[]) buf[12])[0] = rslt.getString(12, 100);
                ((long[]) buf[13])[0] = rslt.getLong(13);
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
                ((long[]) buf[15])[0] = rslt.getLong(14);
                ((short[]) buf[16])[0] = rslt.getShort(15);
                ((long[]) buf[17])[0] = rslt.getLong(16);
                return;
       }
    }

 }

}
