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
   public class profesionalesfullnameprompt : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public profesionalesfullnameprompt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionalesfullnameprompt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_InOutProfesionalesId ,
                           ref string aP1_FullName )
      {
         this.AV8InOutProfesionalesId = aP0_InOutProfesionalesId;
         this.AV36FullName = aP1_FullName;
         ExecutePrivate();
         aP0_InOutProfesionalesId=this.AV8InOutProfesionalesId;
         aP1_FullName=this.AV36FullName;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "InOutProfesionalesId");
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
               gxfirstwebparm = GetFirstPar( "InOutProfesionalesId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "InOutProfesionalesId");
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
               AV8InOutProfesionalesId = gxfirstwebparm;
               AssignAttri("", false, "AV8InOutProfesionalesId", AV8InOutProfesionalesId);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV36FullName = GetPar( "FullName");
                  AssignAttri("", false, "AV36FullName", AV36FullName);
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
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV15FilterFullText = GetPar( "FilterFullText");
         AV37Pgmname = GetPar( "Pgmname");
         AV16TFProfesionalesId = GetPar( "TFProfesionalesId");
         AV17TFProfesionalesId_Sel = GetPar( "TFProfesionalesId_Sel");
         AV18TFProfesionalesPrimerNombre = GetPar( "TFProfesionalesPrimerNombre");
         AV19TFProfesionalesPrimerNombre_Sel = GetPar( "TFProfesionalesPrimerNombre_Sel");
         AV20TFProfesionalesSegundoNombre = GetPar( "TFProfesionalesSegundoNombre");
         AV21TFProfesionalesSegundoNombre_Sel = GetPar( "TFProfesionalesSegundoNombre_Sel");
         AV22TFProfesionalesApellidoPrimero = GetPar( "TFProfesionalesApellidoPrimero");
         AV23TFProfesionalesApellidoPrimero_Sel = GetPar( "TFProfesionalesApellidoPrimero_Sel");
         AV24TFProfesionalesApellidoSegundo = GetPar( "TFProfesionalesApellidoSegundo");
         AV25TFProfesionalesApellidoSegundo_Sel = GetPar( "TFProfesionalesApellidoSegundo_Sel");
         AV26TFProfesionalesTelefono = GetPar( "TFProfesionalesTelefono");
         AV27TFProfesionalesTelefono_Sel = GetPar( "TFProfesionalesTelefono_Sel");
         AV28TFProfesionalesEmail = GetPar( "TFProfesionalesEmail");
         AV29TFProfesionalesEmail_Sel = GetPar( "TFProfesionalesEmail_Sel");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV37Pgmname, AV16TFProfesionalesId, AV17TFProfesionalesId_Sel, AV18TFProfesionalesPrimerNombre, AV19TFProfesionalesPrimerNombre_Sel, AV20TFProfesionalesSegundoNombre, AV21TFProfesionalesSegundoNombre_Sel, AV22TFProfesionalesApellidoPrimero, AV23TFProfesionalesApellidoPrimero_Sel, AV24TFProfesionalesApellidoSegundo, AV25TFProfesionalesApellidoSegundo_Sel, AV26TFProfesionalesTelefono, AV27TFProfesionalesTelefono_Sel, AV28TFProfesionalesEmail, AV29TFProfesionalesEmail_Sel) ;
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
         PAB12( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTB12( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("profesionalesfullnameprompt.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV8InOutProfesionalesId)),UrlEncode(StringUtil.RTrim(AV36FullName))}, new string[] {"InOutProfesionalesId","FullName"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV37Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV37Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV15FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_26", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_26), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV34GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV30DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV30DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV37Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV37Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESID", StringUtil.RTrim( AV16TFProfesionalesId));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESID_SEL", StringUtil.RTrim( AV17TFProfesionalesId_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESPRIMERNOMBRE", StringUtil.RTrim( AV18TFProfesionalesPrimerNombre));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESPRIMERNOMBRE_SEL", StringUtil.RTrim( AV19TFProfesionalesPrimerNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESSEGUNDONOMBRE", StringUtil.RTrim( AV20TFProfesionalesSegundoNombre));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESSEGUNDONOMBRE_SEL", StringUtil.RTrim( AV21TFProfesionalesSegundoNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESAPELLIDOPRIMERO", StringUtil.RTrim( AV22TFProfesionalesApellidoPrimero));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESAPELLIDOPRIMERO_SEL", StringUtil.RTrim( AV23TFProfesionalesApellidoPrimero_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESAPELLIDOSEGUNDO", StringUtil.RTrim( AV24TFProfesionalesApellidoSegundo));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESAPELLIDOSEGUNDO_SEL", StringUtil.RTrim( AV25TFProfesionalesApellidoSegundo_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESTELEFONO", StringUtil.RTrim( AV26TFProfesionalesTelefono));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESTELEFONO_SEL", StringUtil.RTrim( AV27TFProfesionalesTelefono_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESEMAIL", AV28TFProfesionalesEmail);
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESEMAIL_SEL", AV29TFProfesionalesEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vINOUTPROFESIONALESID", StringUtil.RTrim( AV8InOutProfesionalesId));
         GxWebStd.gx_hidden_field( context, "vFULLNAME", StringUtil.RTrim( AV36FullName));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
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
            WEB12( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTB12( ) ;
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
         return formatLink("profesionalesfullnameprompt.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV8InOutProfesionalesId)),UrlEncode(StringUtil.RTrim(AV36FullName))}, new string[] {"InOutProfesionalesId","FullName"})  ;
      }

      public override string GetPgmname( )
      {
         return "ProfesionalesFullNamePrompt" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selecciona Profesionales", "") ;
      }

      protected void WBB10( )
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
            wb_table1_14_B12( true) ;
         }
         else
         {
            wb_table1_14_B12( false) ;
         }
         return  ;
      }

      protected void wb_table1_14_B12e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV32GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV33GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV34GridAppliedFilters);
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
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV30DDO_TitleSettingsIcons);
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

      protected void STARTB12( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selecciona Profesionales", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPB10( ) ;
      }

      protected void WSB12( )
      {
         STARTB12( ) ;
         EVTB12( ) ;
      }

      protected void EVTB12( )
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
                              E11B12 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E12B12 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E13B12 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCLEANFILTERS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCleanFilters' */
                              E14B12 ();
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
                              AV35Select = cgiGet( edtavSelect_Internalname);
                              AssignAttri("", false, edtavSelect_Internalname, AV35Select);
                              A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                              A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
                              A191ProfesionalesSegundoNombre = cgiGet( edtProfesionalesSegundoNombre_Internalname);
                              A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
                              A192ProfesionalesApellidoSegundo = cgiGet( edtProfesionalesApellidoSegundo_Internalname);
                              A170ProfesionalesTelefono = cgiGet( edtProfesionalesTelefono_Internalname);
                              A193ProfesionalesEmail = cgiGet( edtProfesionalesEmail_Internalname);
                              n193ProfesionalesEmail = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E15B12 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E16B12 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E17B12 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
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
                                          E18B12 ();
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

      protected void WEB12( )
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

      protected void PAB12( )
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
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV15FilterFullText ,
                                       string AV37Pgmname ,
                                       string AV16TFProfesionalesId ,
                                       string AV17TFProfesionalesId_Sel ,
                                       string AV18TFProfesionalesPrimerNombre ,
                                       string AV19TFProfesionalesPrimerNombre_Sel ,
                                       string AV20TFProfesionalesSegundoNombre ,
                                       string AV21TFProfesionalesSegundoNombre_Sel ,
                                       string AV22TFProfesionalesApellidoPrimero ,
                                       string AV23TFProfesionalesApellidoPrimero_Sel ,
                                       string AV24TFProfesionalesApellidoSegundo ,
                                       string AV25TFProfesionalesApellidoSegundo_Sel ,
                                       string AV26TFProfesionalesTelefono ,
                                       string AV27TFProfesionalesTelefono_Sel ,
                                       string AV28TFProfesionalesEmail ,
                                       string AV29TFProfesionalesEmail_Sel )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFB12( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESSEGUNDONOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A191ProfesionalesSegundoNombre, "")), context));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESSEGUNDONOMBRE", StringUtil.RTrim( A191ProfesionalesSegundoNombre));
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESPRIMERNOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A166ProfesionalesPrimerNombre, "")), context));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESPRIMERNOMBRE", StringUtil.RTrim( A166ProfesionalesPrimerNombre));
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESAPELLIDOPRIMERO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A167ProfesionalesApellidoPrimero, "")), context));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAPELLIDOPRIMERO", StringUtil.RTrim( A167ProfesionalesApellidoPrimero));
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESAPELLIDOSEGUNDO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A192ProfesionalesApellidoSegundo, "")), context));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAPELLIDOSEGUNDO", StringUtil.RTrim( A192ProfesionalesApellidoSegundo));
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), context));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESID", StringUtil.RTrim( A120ProfesionalesId));
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
         RFB12( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV37Pgmname = "ProfesionalesFullNamePrompt";
         edtavSelect_Enabled = 0;
      }

      protected void RFB12( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 26;
         /* Execute user event: Refresh */
         E16B12 ();
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
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV15FilterFullText ,
                                                 AV17TFProfesionalesId_Sel ,
                                                 AV16TFProfesionalesId ,
                                                 AV19TFProfesionalesPrimerNombre_Sel ,
                                                 AV18TFProfesionalesPrimerNombre ,
                                                 AV21TFProfesionalesSegundoNombre_Sel ,
                                                 AV20TFProfesionalesSegundoNombre ,
                                                 AV23TFProfesionalesApellidoPrimero_Sel ,
                                                 AV22TFProfesionalesApellidoPrimero ,
                                                 AV25TFProfesionalesApellidoSegundo_Sel ,
                                                 AV24TFProfesionalesApellidoSegundo ,
                                                 AV27TFProfesionalesTelefono_Sel ,
                                                 AV26TFProfesionalesTelefono ,
                                                 AV29TFProfesionalesEmail_Sel ,
                                                 AV28TFProfesionalesEmail ,
                                                 A120ProfesionalesId ,
                                                 A166ProfesionalesPrimerNombre ,
                                                 A191ProfesionalesSegundoNombre ,
                                                 A167ProfesionalesApellidoPrimero ,
                                                 A192ProfesionalesApellidoSegundo ,
                                                 A170ProfesionalesTelefono ,
                                                 A193ProfesionalesEmail ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A108EstadosGenericosId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
            lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
            lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
            lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
            lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
            lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
            lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
            lV16TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV16TFProfesionalesId), 20, "%");
            lV18TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV18TFProfesionalesPrimerNombre), 30, "%");
            lV20TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV20TFProfesionalesSegundoNombre), 30, "%");
            lV22TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV22TFProfesionalesApellidoPrimero), 30, "%");
            lV24TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV24TFProfesionalesApellidoSegundo), 30, "%");
            lV26TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV26TFProfesionalesTelefono), 20, "%");
            lV28TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV28TFProfesionalesEmail), "%", "");
            /* Using cursor H00B12 */
            pr_default.execute(0, new Object[] {lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, lV16TFProfesionalesId, AV17TFProfesionalesId_Sel, lV18TFProfesionalesPrimerNombre, AV19TFProfesionalesPrimerNombre_Sel, lV20TFProfesionalesSegundoNombre, AV21TFProfesionalesSegundoNombre_Sel, lV22TFProfesionalesApellidoPrimero, AV23TFProfesionalesApellidoPrimero_Sel, lV24TFProfesionalesApellidoSegundo, AV25TFProfesionalesApellidoSegundo_Sel, lV26TFProfesionalesTelefono, AV27TFProfesionalesTelefono_Sel, lV28TFProfesionalesEmail, AV29TFProfesionalesEmail_Sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_26_idx = 1;
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A108EstadosGenericosId = H00B12_A108EstadosGenericosId[0];
               A193ProfesionalesEmail = H00B12_A193ProfesionalesEmail[0];
               n193ProfesionalesEmail = H00B12_n193ProfesionalesEmail[0];
               A170ProfesionalesTelefono = H00B12_A170ProfesionalesTelefono[0];
               A192ProfesionalesApellidoSegundo = H00B12_A192ProfesionalesApellidoSegundo[0];
               A167ProfesionalesApellidoPrimero = H00B12_A167ProfesionalesApellidoPrimero[0];
               A191ProfesionalesSegundoNombre = H00B12_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = H00B12_A166ProfesionalesPrimerNombre[0];
               A120ProfesionalesId = H00B12_A120ProfesionalesId[0];
               /* Execute user event: Grid.Load */
               E17B12 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 26;
            WBB10( ) ;
         }
         bGXsfl_26_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesB12( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV37Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV37Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESSEGUNDONOMBRE"+"_"+sGXsfl_26_idx, GetSecureSignedToken( sGXsfl_26_idx, StringUtil.RTrim( context.localUtil.Format( A191ProfesionalesSegundoNombre, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESPRIMERNOMBRE"+"_"+sGXsfl_26_idx, GetSecureSignedToken( sGXsfl_26_idx, StringUtil.RTrim( context.localUtil.Format( A166ProfesionalesPrimerNombre, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESAPELLIDOPRIMERO"+"_"+sGXsfl_26_idx, GetSecureSignedToken( sGXsfl_26_idx, StringUtil.RTrim( context.localUtil.Format( A167ProfesionalesApellidoPrimero, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESAPELLIDOSEGUNDO"+"_"+sGXsfl_26_idx, GetSecureSignedToken( sGXsfl_26_idx, StringUtil.RTrim( context.localUtil.Format( A192ProfesionalesApellidoSegundo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESID"+"_"+sGXsfl_26_idx, GetSecureSignedToken( sGXsfl_26_idx, StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), context));
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
                                              AV15FilterFullText ,
                                              AV17TFProfesionalesId_Sel ,
                                              AV16TFProfesionalesId ,
                                              AV19TFProfesionalesPrimerNombre_Sel ,
                                              AV18TFProfesionalesPrimerNombre ,
                                              AV21TFProfesionalesSegundoNombre_Sel ,
                                              AV20TFProfesionalesSegundoNombre ,
                                              AV23TFProfesionalesApellidoPrimero_Sel ,
                                              AV22TFProfesionalesApellidoPrimero ,
                                              AV25TFProfesionalesApellidoSegundo_Sel ,
                                              AV24TFProfesionalesApellidoSegundo ,
                                              AV27TFProfesionalesTelefono_Sel ,
                                              AV26TFProfesionalesTelefono ,
                                              AV29TFProfesionalesEmail_Sel ,
                                              AV28TFProfesionalesEmail ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A108EstadosGenericosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
         lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
         lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
         lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
         lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
         lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
         lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
         lV16TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV16TFProfesionalesId), 20, "%");
         lV18TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV18TFProfesionalesPrimerNombre), 30, "%");
         lV20TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV20TFProfesionalesSegundoNombre), 30, "%");
         lV22TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV22TFProfesionalesApellidoPrimero), 30, "%");
         lV24TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV24TFProfesionalesApellidoSegundo), 30, "%");
         lV26TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV26TFProfesionalesTelefono), 20, "%");
         lV28TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV28TFProfesionalesEmail), "%", "");
         /* Using cursor H00B13 */
         pr_default.execute(1, new Object[] {lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, lV16TFProfesionalesId, AV17TFProfesionalesId_Sel, lV18TFProfesionalesPrimerNombre, AV19TFProfesionalesPrimerNombre_Sel, lV20TFProfesionalesSegundoNombre, AV21TFProfesionalesSegundoNombre_Sel, lV22TFProfesionalesApellidoPrimero, AV23TFProfesionalesApellidoPrimero_Sel, lV24TFProfesionalesApellidoSegundo, AV25TFProfesionalesApellidoSegundo_Sel, lV26TFProfesionalesTelefono, AV27TFProfesionalesTelefono_Sel, lV28TFProfesionalesEmail, AV29TFProfesionalesEmail_Sel});
         GRID_nRecordCount = H00B13_AGRID_nRecordCount[0];
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV37Pgmname, AV16TFProfesionalesId, AV17TFProfesionalesId_Sel, AV18TFProfesionalesPrimerNombre, AV19TFProfesionalesPrimerNombre_Sel, AV20TFProfesionalesSegundoNombre, AV21TFProfesionalesSegundoNombre_Sel, AV22TFProfesionalesApellidoPrimero, AV23TFProfesionalesApellidoPrimero_Sel, AV24TFProfesionalesApellidoSegundo, AV25TFProfesionalesApellidoSegundo_Sel, AV26TFProfesionalesTelefono, AV27TFProfesionalesTelefono_Sel, AV28TFProfesionalesEmail, AV29TFProfesionalesEmail_Sel) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV37Pgmname, AV16TFProfesionalesId, AV17TFProfesionalesId_Sel, AV18TFProfesionalesPrimerNombre, AV19TFProfesionalesPrimerNombre_Sel, AV20TFProfesionalesSegundoNombre, AV21TFProfesionalesSegundoNombre_Sel, AV22TFProfesionalesApellidoPrimero, AV23TFProfesionalesApellidoPrimero_Sel, AV24TFProfesionalesApellidoSegundo, AV25TFProfesionalesApellidoSegundo_Sel, AV26TFProfesionalesTelefono, AV27TFProfesionalesTelefono_Sel, AV28TFProfesionalesEmail, AV29TFProfesionalesEmail_Sel) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV37Pgmname, AV16TFProfesionalesId, AV17TFProfesionalesId_Sel, AV18TFProfesionalesPrimerNombre, AV19TFProfesionalesPrimerNombre_Sel, AV20TFProfesionalesSegundoNombre, AV21TFProfesionalesSegundoNombre_Sel, AV22TFProfesionalesApellidoPrimero, AV23TFProfesionalesApellidoPrimero_Sel, AV24TFProfesionalesApellidoSegundo, AV25TFProfesionalesApellidoSegundo_Sel, AV26TFProfesionalesTelefono, AV27TFProfesionalesTelefono_Sel, AV28TFProfesionalesEmail, AV29TFProfesionalesEmail_Sel) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV37Pgmname, AV16TFProfesionalesId, AV17TFProfesionalesId_Sel, AV18TFProfesionalesPrimerNombre, AV19TFProfesionalesPrimerNombre_Sel, AV20TFProfesionalesSegundoNombre, AV21TFProfesionalesSegundoNombre_Sel, AV22TFProfesionalesApellidoPrimero, AV23TFProfesionalesApellidoPrimero_Sel, AV24TFProfesionalesApellidoSegundo, AV25TFProfesionalesApellidoSegundo_Sel, AV26TFProfesionalesTelefono, AV27TFProfesionalesTelefono_Sel, AV28TFProfesionalesEmail, AV29TFProfesionalesEmail_Sel) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV37Pgmname, AV16TFProfesionalesId, AV17TFProfesionalesId_Sel, AV18TFProfesionalesPrimerNombre, AV19TFProfesionalesPrimerNombre_Sel, AV20TFProfesionalesSegundoNombre, AV21TFProfesionalesSegundoNombre_Sel, AV22TFProfesionalesApellidoPrimero, AV23TFProfesionalesApellidoPrimero_Sel, AV24TFProfesionalesApellidoSegundo, AV25TFProfesionalesApellidoSegundo_Sel, AV26TFProfesionalesTelefono, AV27TFProfesionalesTelefono_Sel, AV28TFProfesionalesEmail, AV29TFProfesionalesEmail_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV37Pgmname = "ProfesionalesFullNamePrompt";
         edtavSelect_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesTelefono_Enabled = 0;
         edtProfesionalesEmail_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPB10( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15B12 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV30DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_26 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_26"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV32GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV33GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV34GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
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
         E15B12 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E15B12( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( "Selecciona Profesionales", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV30DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV30DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E16B12( )
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
         AV32GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV32GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV32GridCurrentPage), 10, 0));
         AV33GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV33GridPageCount", StringUtil.LTrimStr( (decimal)(AV33GridPageCount), 10, 0));
         GXt_char2 = AV34GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV37Pgmname, out  GXt_char2) ;
         AV34GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV34GridAppliedFilters", AV34GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E11B12( )
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

      protected void E12B12( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E13B12( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesId") == 0 )
            {
               AV16TFProfesionalesId = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV16TFProfesionalesId", AV16TFProfesionalesId);
               AV17TFProfesionalesId_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV17TFProfesionalesId_Sel", AV17TFProfesionalesId_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesPrimerNombre") == 0 )
            {
               AV18TFProfesionalesPrimerNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV18TFProfesionalesPrimerNombre", AV18TFProfesionalesPrimerNombre);
               AV19TFProfesionalesPrimerNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV19TFProfesionalesPrimerNombre_Sel", AV19TFProfesionalesPrimerNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesSegundoNombre") == 0 )
            {
               AV20TFProfesionalesSegundoNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV20TFProfesionalesSegundoNombre", AV20TFProfesionalesSegundoNombre);
               AV21TFProfesionalesSegundoNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV21TFProfesionalesSegundoNombre_Sel", AV21TFProfesionalesSegundoNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesApellidoPrimero") == 0 )
            {
               AV22TFProfesionalesApellidoPrimero = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV22TFProfesionalesApellidoPrimero", AV22TFProfesionalesApellidoPrimero);
               AV23TFProfesionalesApellidoPrimero_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV23TFProfesionalesApellidoPrimero_Sel", AV23TFProfesionalesApellidoPrimero_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesApellidoSegundo") == 0 )
            {
               AV24TFProfesionalesApellidoSegundo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV24TFProfesionalesApellidoSegundo", AV24TFProfesionalesApellidoSegundo);
               AV25TFProfesionalesApellidoSegundo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV25TFProfesionalesApellidoSegundo_Sel", AV25TFProfesionalesApellidoSegundo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesTelefono") == 0 )
            {
               AV26TFProfesionalesTelefono = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV26TFProfesionalesTelefono", AV26TFProfesionalesTelefono);
               AV27TFProfesionalesTelefono_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV27TFProfesionalesTelefono_Sel", AV27TFProfesionalesTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesEmail") == 0 )
            {
               AV28TFProfesionalesEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV28TFProfesionalesEmail", AV28TFProfesionalesEmail);
               AV29TFProfesionalesEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFProfesionalesEmail_Sel", AV29TFProfesionalesEmail_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E17B12( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV35Select = "<i class=\"fas fa-check\"></i>";
         AssignAttri("", false, edtavSelect_Internalname, AV35Select);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 26;
         }
         sendrow_262( ) ;
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
         E18B12 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18B12( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A191ProfesionalesSegundoNombre)) )
         {
            AV36FullName = StringUtil.Format( "%1, %2 %4", StringUtil.Trim( A166ProfesionalesPrimerNombre), StringUtil.Trim( A167ProfesionalesApellidoPrimero), StringUtil.Trim( A192ProfesionalesApellidoSegundo), "", "", "", "", "", "");
            AssignAttri("", false, "AV36FullName", AV36FullName);
         }
         else
         {
            AV36FullName = StringUtil.Format( "%1 %2, %3 %4", StringUtil.Trim( A166ProfesionalesPrimerNombre), StringUtil.Trim( A191ProfesionalesSegundoNombre), StringUtil.Trim( A167ProfesionalesApellidoPrimero), StringUtil.Trim( A192ProfesionalesApellidoSegundo), "", "", "", "", "");
            AssignAttri("", false, "AV36FullName", AV36FullName);
         }
         AV8InOutProfesionalesId = A120ProfesionalesId;
         AssignAttri("", false, "AV8InOutProfesionalesId", AV8InOutProfesionalesId);
         context.setWebReturnParms(new Object[] {(string)AV8InOutProfesionalesId,(string)AV36FullName});
         context.setWebReturnParmsMetadata(new Object[] {"AV8InOutProfesionalesId","AV36FullName"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void E14B12( )
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
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S132( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV16TFProfesionalesId = "";
         AssignAttri("", false, "AV16TFProfesionalesId", AV16TFProfesionalesId);
         AV17TFProfesionalesId_Sel = "";
         AssignAttri("", false, "AV17TFProfesionalesId_Sel", AV17TFProfesionalesId_Sel);
         AV18TFProfesionalesPrimerNombre = "";
         AssignAttri("", false, "AV18TFProfesionalesPrimerNombre", AV18TFProfesionalesPrimerNombre);
         AV19TFProfesionalesPrimerNombre_Sel = "";
         AssignAttri("", false, "AV19TFProfesionalesPrimerNombre_Sel", AV19TFProfesionalesPrimerNombre_Sel);
         AV20TFProfesionalesSegundoNombre = "";
         AssignAttri("", false, "AV20TFProfesionalesSegundoNombre", AV20TFProfesionalesSegundoNombre);
         AV21TFProfesionalesSegundoNombre_Sel = "";
         AssignAttri("", false, "AV21TFProfesionalesSegundoNombre_Sel", AV21TFProfesionalesSegundoNombre_Sel);
         AV22TFProfesionalesApellidoPrimero = "";
         AssignAttri("", false, "AV22TFProfesionalesApellidoPrimero", AV22TFProfesionalesApellidoPrimero);
         AV23TFProfesionalesApellidoPrimero_Sel = "";
         AssignAttri("", false, "AV23TFProfesionalesApellidoPrimero_Sel", AV23TFProfesionalesApellidoPrimero_Sel);
         AV24TFProfesionalesApellidoSegundo = "";
         AssignAttri("", false, "AV24TFProfesionalesApellidoSegundo", AV24TFProfesionalesApellidoSegundo);
         AV25TFProfesionalesApellidoSegundo_Sel = "";
         AssignAttri("", false, "AV25TFProfesionalesApellidoSegundo_Sel", AV25TFProfesionalesApellidoSegundo_Sel);
         AV26TFProfesionalesTelefono = "";
         AssignAttri("", false, "AV26TFProfesionalesTelefono", AV26TFProfesionalesTelefono);
         AV27TFProfesionalesTelefono_Sel = "";
         AssignAttri("", false, "AV27TFProfesionalesTelefono_Sel", AV27TFProfesionalesTelefono_Sel);
         AV28TFProfesionalesEmail = "";
         AssignAttri("", false, "AV28TFProfesionalesEmail", AV28TFProfesionalesEmail);
         AV29TFProfesionalesEmail_Sel = "";
         AssignAttri("", false, "AV29TFProfesionalesEmail_Sel", AV29TFProfesionalesEmail_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESID",  context.GetMessage( "Identidad", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesId)),  0,  AV16TFProfesionalesId,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesId_Sel)),  AV17TFProfesionalesId_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESPRIMERNOMBRE",  context.GetMessage( "Primer Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesPrimerNombre)),  0,  AV18TFProfesionalesPrimerNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesPrimerNombre_Sel)),  AV19TFProfesionalesPrimerNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESSEGUNDONOMBRE",  context.GetMessage( "Segundo Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesSegundoNombre)),  0,  AV20TFProfesionalesSegundoNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesSegundoNombre_Sel)),  AV21TFProfesionalesSegundoNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESAPELLIDOPRIMERO",  context.GetMessage( "Primer Apellido ", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesApellidoPrimero)),  0,  AV22TFProfesionalesApellidoPrimero,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesApellidoPrimero_Sel)),  AV23TFProfesionalesApellidoPrimero_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESAPELLIDOSEGUNDO",  context.GetMessage( "Segundo Apellido ", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesApellidoSegundo)),  0,  AV24TFProfesionalesApellidoSegundo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesApellidoSegundo_Sel)),  AV25TFProfesionalesApellidoSegundo_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESTELEFONO",  context.GetMessage( "Teléfono", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesTelefono)),  0,  AV26TFProfesionalesTelefono,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFProfesionalesTelefono_Sel)),  AV27TFProfesionalesTelefono_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESEMAIL",  context.GetMessage( "Email", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProfesionalesEmail)),  0,  AV28TFProfesionalesEmail,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFProfesionalesEmail_Sel)),  AV29TFProfesionalesEmail_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV37Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void wb_table1_14_B12( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellAlignTop CellPaddingTop10'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCleanfilters_Internalname, context.GetMessage( "<i class=\"fas fa-filter CleanFiltersIcon\"></i>", ""), "", "", lblCleanfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOCLEANFILTERS\\'."+"'", "", "TextBlock", 5, context.GetMessage( "WWP_CleanFiltersTooltip", ""), 1, 1, 0, 1, "HLP_ProfesionalesFullNamePrompt.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_26_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ProfesionalesFullNamePrompt.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_14_B12e( true) ;
         }
         else
         {
            wb_table1_14_B12e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8InOutProfesionalesId = (string)getParm(obj,0);
         AssignAttri("", false, "AV8InOutProfesionalesId", AV8InOutProfesionalesId);
         AV36FullName = (string)getParm(obj,1);
         AssignAttri("", false, "AV36FullName", AV36FullName);
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
         PAB12( ) ;
         WSB12( ) ;
         WEB12( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021221392", true, true, false);
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
         context.AddJavascriptSource("profesionalesfullnameprompt.js", "?202673021221392", false, true, false);
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
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_26_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_26_idx;
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_26_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_26_idx;
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_26_idx;
         edtProfesionalesTelefono_Internalname = "PROFESIONALESTELEFONO_"+sGXsfl_26_idx;
         edtProfesionalesEmail_Internalname = "PROFESIONALESEMAIL_"+sGXsfl_26_idx;
      }

      protected void SubsflControlProps_fel_262( )
      {
         edtavSelect_Internalname = "vSELECT_"+sGXsfl_26_fel_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_26_fel_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_26_fel_idx;
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_26_fel_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_26_fel_idx;
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_26_fel_idx;
         edtProfesionalesTelefono_Internalname = "PROFESIONALESTELEFONO_"+sGXsfl_26_fel_idx;
         edtProfesionalesEmail_Internalname = "PROFESIONALESEMAIL_"+sGXsfl_26_fel_idx;
      }

      protected void sendrow_262( )
      {
         sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
         SubsflControlProps_262( ) ;
         WBB10( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSelect_Internalname,StringUtil.RTrim( AV35Select),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"","'"+""+"'"+",false,"+"'"+"EENTER."+sGXsfl_26_idx+"'",(string)"",(string)"",context.GetMessage( "GX_BtnSelect", ""),(string)"",(string)edtavSelect_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavSelect_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPrimerNombre_Internalname,StringUtil.RTrim( A166ProfesionalesPrimerNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesPrimerNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesSegundoNombre_Internalname,StringUtil.RTrim( A191ProfesionalesSegundoNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesSegundoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoPrimero_Internalname,StringUtil.RTrim( A167ProfesionalesApellidoPrimero),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoPrimero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoSegundo_Internalname,StringUtil.RTrim( A192ProfesionalesApellidoSegundo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoSegundo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A170ProfesionalesTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesTelefono_Internalname,StringUtil.RTrim( A170ProfesionalesTelefono),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtProfesionalesTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesEmail_Internalname,(string)A193ProfesionalesEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A193ProfesionalesEmail,(string)"",(string)"",context.GetMessage( "email@correo.com", ""),(string)edtProfesionalesEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashesB12( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_26_idx = ((subGrid_Islastpage==1)&&(nGXsfl_26_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_26_idx+1);
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
         }
         /* End function sendrow_262 */
      }

      protected void init_web_controls( )
      {
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
            context.SendWebValue( context.GetMessage( "Primer Apellido ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Segundo Apellido ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Teléfono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV35Select)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSelect_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A193ProfesionalesEmail));
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
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO";
         edtProfesionalesTelefono_Internalname = "PROFESIONALESTELEFONO";
         edtProfesionalesEmail_Internalname = "PROFESIONALESEMAIL";
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
         edtProfesionalesEmail_Jsonclick = "";
         edtProfesionalesTelefono_Jsonclick = "";
         edtProfesionalesApellidoSegundo_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesId_Jsonclick = "";
         edtavSelect_Jsonclick = "";
         edtavSelect_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtProfesionalesEmail_Enabled = 0;
         edtProfesionalesTelefono_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         subGrid_Sortable = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "ProfesionalesFullNamePromptGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7";
         Ddo_grid_Columnids = "1:ProfesionalesId|2:ProfesionalesPrimerNombre|3:ProfesionalesSegundoNombre|4:ProfesionalesApellidoPrimero|5:ProfesionalesApellidoSegundo|6:ProfesionalesTelefono|7:ProfesionalesEmail";
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
         Form.Caption = context.GetMessage( "Selecciona Profesionales", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV15FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV37Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV17TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV18TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV19TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV20TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV21TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV22TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV23TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV24TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV25TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV26TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV27TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV28TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV29TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV32GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV33GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV34GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11B12',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV15FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV37Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV17TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV18TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV19TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV20TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV21TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV22TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV23TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV24TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV25TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV26TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV27TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV28TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV29TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV32GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV33GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV34GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12B12',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV15FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV37Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV17TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV18TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV19TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV20TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV21TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV22TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV23TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV24TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV25TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV26TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV27TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV28TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV29TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E13B12',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV15FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV37Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV17TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV18TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV19TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV20TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV21TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV22TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV23TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV24TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV25TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV26TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV27TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV28TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV29TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV28TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV29TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'AV26TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV27TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV24TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV25TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV22TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV23TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV20TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV21TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV18TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV19TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV16TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV17TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E17B12',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV35Select',fld:'vSELECT',pic:'',type:'char'}]}");
         setEventMetadata("ENTER","{handler:'E18B12',iparms:[{av:'A191ProfesionalesSegundoNombre',fld:'PROFESIONALESSEGUNDONOMBRE',pic:'',hsh:true,type:'char'},{av:'A166ProfesionalesPrimerNombre',fld:'PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'char'},{av:'A167ProfesionalesApellidoPrimero',fld:'PROFESIONALESAPELLIDOPRIMERO',pic:'',hsh:true,type:'char'},{av:'A192ProfesionalesApellidoSegundo',fld:'PROFESIONALESAPELLIDOSEGUNDO',pic:'',hsh:true,type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV36FullName',fld:'vFULLNAME',pic:'',type:'char'},{av:'AV8InOutProfesionalesId',fld:'vINOUTPROFESIONALESID',pic:'',type:'char'}]}");
         setEventMetadata("'DOCLEANFILTERS'","{handler:'E14B12',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV15FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV37Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV17TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV18TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV19TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV20TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV21TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV22TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV23TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV24TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV25TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV26TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV27TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV28TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV29TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'}]");
         setEventMetadata("'DOCLEANFILTERS'",",oparms:[{av:'AV15FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV16TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV17TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV18TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV19TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV20TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV21TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV22TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV23TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV24TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV25TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV26TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV27TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV28TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV29TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'}]}");
         setEventMetadata("NULL","{handler:'Valid_Profesionalesemail',iparms:[]");
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
         wcpOAV8InOutProfesionalesId = "";
         wcpOAV36FullName = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15FilterFullText = "";
         AV37Pgmname = "";
         AV16TFProfesionalesId = "";
         AV17TFProfesionalesId_Sel = "";
         AV18TFProfesionalesPrimerNombre = "";
         AV19TFProfesionalesPrimerNombre_Sel = "";
         AV20TFProfesionalesSegundoNombre = "";
         AV21TFProfesionalesSegundoNombre_Sel = "";
         AV22TFProfesionalesApellidoPrimero = "";
         AV23TFProfesionalesApellidoPrimero_Sel = "";
         AV24TFProfesionalesApellidoSegundo = "";
         AV25TFProfesionalesApellidoSegundo_Sel = "";
         AV26TFProfesionalesTelefono = "";
         AV27TFProfesionalesTelefono_Sel = "";
         AV28TFProfesionalesEmail = "";
         AV29TFProfesionalesEmail_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV34GridAppliedFilters = "";
         AV30DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
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
         AV35Select = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         A193ProfesionalesEmail = "";
         lV15FilterFullText = "";
         lV16TFProfesionalesId = "";
         lV18TFProfesionalesPrimerNombre = "";
         lV20TFProfesionalesSegundoNombre = "";
         lV22TFProfesionalesApellidoPrimero = "";
         lV24TFProfesionalesApellidoSegundo = "";
         lV26TFProfesionalesTelefono = "";
         lV28TFProfesionalesEmail = "";
         H00B12_A108EstadosGenericosId = new int[1] ;
         H00B12_A193ProfesionalesEmail = new string[] {""} ;
         H00B12_n193ProfesionalesEmail = new bool[] {false} ;
         H00B12_A170ProfesionalesTelefono = new string[] {""} ;
         H00B12_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         H00B12_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H00B12_A191ProfesionalesSegundoNombre = new string[] {""} ;
         H00B12_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H00B12_A120ProfesionalesId = new string[] {""} ;
         H00B13_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         lblCleanfilters_Jsonclick = "";
         TempTags = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionalesfullnameprompt__default(),
            new Object[][] {
                new Object[] {
               H00B12_A108EstadosGenericosId, H00B12_A193ProfesionalesEmail, H00B12_n193ProfesionalesEmail, H00B12_A170ProfesionalesTelefono, H00B12_A192ProfesionalesApellidoSegundo, H00B12_A167ProfesionalesApellidoPrimero, H00B12_A191ProfesionalesSegundoNombre, H00B12_A166ProfesionalesPrimerNombre, H00B12_A120ProfesionalesId
               }
               , new Object[] {
               H00B13_AGRID_nRecordCount
               }
            }
         );
         AV37Pgmname = "ProfesionalesFullNamePrompt";
         /* GeneXus formulas. */
         AV37Pgmname = "ProfesionalesFullNamePrompt";
         edtavSelect_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
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
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A108EstadosGenericosId ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesApellidoSegundo_Enabled ;
      private int edtProfesionalesTelefono_Enabled ;
      private int edtProfesionalesEmail_Enabled ;
      private int AV31PageToGo ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV32GridCurrentPage ;
      private long AV33GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string AV8InOutProfesionalesId ;
      private string AV36FullName ;
      private string wcpOAV8InOutProfesionalesId ;
      private string wcpOAV36FullName ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_26_idx="0001" ;
      private string AV37Pgmname ;
      private string AV16TFProfesionalesId ;
      private string AV17TFProfesionalesId_Sel ;
      private string AV18TFProfesionalesPrimerNombre ;
      private string AV19TFProfesionalesPrimerNombre_Sel ;
      private string AV20TFProfesionalesSegundoNombre ;
      private string AV21TFProfesionalesSegundoNombre_Sel ;
      private string AV22TFProfesionalesApellidoPrimero ;
      private string AV23TFProfesionalesApellidoPrimero_Sel ;
      private string AV24TFProfesionalesApellidoSegundo ;
      private string AV25TFProfesionalesApellidoSegundo_Sel ;
      private string AV26TFProfesionalesTelefono ;
      private string AV27TFProfesionalesTelefono_Sel ;
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
      private string AV35Select ;
      private string edtavSelect_Internalname ;
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
      private string edtProfesionalesEmail_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string lV16TFProfesionalesId ;
      private string lV18TFProfesionalesPrimerNombre ;
      private string lV20TFProfesionalesSegundoNombre ;
      private string lV22TFProfesionalesApellidoPrimero ;
      private string lV24TFProfesionalesApellidoSegundo ;
      private string lV26TFProfesionalesTelefono ;
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
      private string edtProfesionalesId_Jsonclick ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesSegundoNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtProfesionalesApellidoSegundo_Jsonclick ;
      private string gxphoneLink ;
      private string edtProfesionalesTelefono_Jsonclick ;
      private string edtProfesionalesEmail_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n193ProfesionalesEmail ;
      private bool bGXsfl_26_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV15FilterFullText ;
      private string AV28TFProfesionalesEmail ;
      private string AV29TFProfesionalesEmail_Sel ;
      private string AV34GridAppliedFilters ;
      private string A193ProfesionalesEmail ;
      private string lV15FilterFullText ;
      private string lV28TFProfesionalesEmail ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP0_InOutProfesionalesId ;
      private string aP1_FullName ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV30DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private int[] H00B12_A108EstadosGenericosId ;
      private string[] H00B12_A193ProfesionalesEmail ;
      private bool[] H00B12_n193ProfesionalesEmail ;
      private string[] H00B12_A170ProfesionalesTelefono ;
      private string[] H00B12_A192ProfesionalesApellidoSegundo ;
      private string[] H00B12_A167ProfesionalesApellidoPrimero ;
      private string[] H00B12_A191ProfesionalesSegundoNombre ;
      private string[] H00B12_A166ProfesionalesPrimerNombre ;
      private string[] H00B12_A120ProfesionalesId ;
      private long[] H00B13_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class profesionalesfullnameprompt__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00B12( IGxContext context ,
                                             string AV15FilterFullText ,
                                             string AV17TFProfesionalesId_Sel ,
                                             string AV16TFProfesionalesId ,
                                             string AV19TFProfesionalesPrimerNombre_Sel ,
                                             string AV18TFProfesionalesPrimerNombre ,
                                             string AV21TFProfesionalesSegundoNombre_Sel ,
                                             string AV20TFProfesionalesSegundoNombre ,
                                             string AV23TFProfesionalesApellidoPrimero_Sel ,
                                             string AV22TFProfesionalesApellidoPrimero ,
                                             string AV25TFProfesionalesApellidoSegundo_Sel ,
                                             string AV24TFProfesionalesApellidoSegundo ,
                                             string AV27TFProfesionalesTelefono_Sel ,
                                             string AV26TFProfesionalesTelefono ,
                                             string AV29TFProfesionalesEmail_Sel ,
                                             string AV28TFProfesionalesEmail ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A108EstadosGenericosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[24];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [EstadosGenericosId], [ProfesionalesEmail], [ProfesionalesTelefono], [ProfesionalesApellidoSegundo], [ProfesionalesApellidoPrimero], [ProfesionalesSegundoNombre], [ProfesionalesPrimerNombre], [ProfesionalesId]";
         sFromString = " FROM [Profesionales]";
         sOrderString = "";
         AddWhere(sWhereString, "([EstadosGenericosId] <> 2)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)) )
         {
            AddWhere(sWhereString, "(( UPPER([ProfesionalesId]) like '%' + UPPER(@lV15FilterFullText)) or ( UPPER([ProfesionalesPrimerNombre]) like '%' + UPPER(@lV15FilterFullText)) or ( UPPER([ProfesionalesSegundoNombre]) like '%' + UPPER(@lV15FilterFullText)) or ( UPPER([ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV15FilterFullText)) or ( UPPER([ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV15FilterFullText)) or ( UPPER([ProfesionalesTelefono]) like '%' + UPPER(@lV15FilterFullText)) or ( UPPER([ProfesionalesEmail]) like '%' + UPPER(@lV15FilterFullText)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesId]) like UPPER(@lV16TFProfesionalesId))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV17TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesId] = @AV17TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV17TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesPrimerNombre]) like UPPER(@lV18TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV19TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesPrimerNombre] = @AV19TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV19TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesSegundoNombre]) like UPPER(@lV20TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV21TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesSegundoNombre] = @AV21TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV21TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoPrimero]) like UPPER(@lV22TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV23TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoPrimero] = @AV23TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV23TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoSegundo]) like UPPER(@lV24TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV25TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoSegundo] = @AV25TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV25TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesTelefono]) like UPPER(@lV26TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV27TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesTelefono] = @AV27TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV27TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesEmail]) like UPPER(@lV28TFProfesionalesEmail))");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV29TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] = @AV29TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( StringUtil.StrCmp(AV29TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] IS NULL or ([ProfesionalesEmail] = ''))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [ProfesionalesPrimerNombre]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [ProfesionalesPrimerNombre] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [ProfesionalesId]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [ProfesionalesId] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [ProfesionalesSegundoNombre]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [ProfesionalesSegundoNombre] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [ProfesionalesApellidoSegundo]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [ProfesionalesApellidoSegundo] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [ProfesionalesTelefono]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [ProfesionalesTelefono] DESC";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [ProfesionalesEmail]";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [ProfesionalesEmail] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [ProfesionalesId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H00B13( IGxContext context ,
                                             string AV15FilterFullText ,
                                             string AV17TFProfesionalesId_Sel ,
                                             string AV16TFProfesionalesId ,
                                             string AV19TFProfesionalesPrimerNombre_Sel ,
                                             string AV18TFProfesionalesPrimerNombre ,
                                             string AV21TFProfesionalesSegundoNombre_Sel ,
                                             string AV20TFProfesionalesSegundoNombre ,
                                             string AV23TFProfesionalesApellidoPrimero_Sel ,
                                             string AV22TFProfesionalesApellidoPrimero ,
                                             string AV25TFProfesionalesApellidoSegundo_Sel ,
                                             string AV24TFProfesionalesApellidoSegundo ,
                                             string AV27TFProfesionalesTelefono_Sel ,
                                             string AV26TFProfesionalesTelefono ,
                                             string AV29TFProfesionalesEmail_Sel ,
                                             string AV28TFProfesionalesEmail ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A108EstadosGenericosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[21];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Profesionales]";
         AddWhere(sWhereString, "([EstadosGenericosId] <> 2)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)) )
         {
            AddWhere(sWhereString, "(( UPPER([ProfesionalesId]) like '%' + UPPER(@lV15FilterFullText)) or ( UPPER([ProfesionalesPrimerNombre]) like '%' + UPPER(@lV15FilterFullText)) or ( UPPER([ProfesionalesSegundoNombre]) like '%' + UPPER(@lV15FilterFullText)) or ( UPPER([ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV15FilterFullText)) or ( UPPER([ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV15FilterFullText)) or ( UPPER([ProfesionalesTelefono]) like '%' + UPPER(@lV15FilterFullText)) or ( UPPER([ProfesionalesEmail]) like '%' + UPPER(@lV15FilterFullText)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesId]) like UPPER(@lV16TFProfesionalesId))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV17TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesId] = @AV17TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV17TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesPrimerNombre]) like UPPER(@lV18TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV19TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesPrimerNombre] = @AV19TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV19TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesSegundoNombre]) like UPPER(@lV20TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV21TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesSegundoNombre] = @AV21TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV21TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoPrimero]) like UPPER(@lV22TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV23TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoPrimero] = @AV23TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV23TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoSegundo]) like UPPER(@lV24TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV25TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoSegundo] = @AV25TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV25TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesTelefono]) like UPPER(@lV26TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV27TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesTelefono] = @AV27TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( StringUtil.StrCmp(AV27TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesEmail]) like UPPER(@lV28TFProfesionalesEmail))");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV29TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] = @AV29TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( StringUtil.StrCmp(AV29TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] IS NULL or ([ProfesionalesEmail] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
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
                     return conditional_H00B12(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] , (int)dynConstraints[24] );
               case 1 :
                     return conditional_H00B13(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] , (int)dynConstraints[24] );
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
          Object[] prmH00B12;
          prmH00B12 = new Object[] {
          new ParDef("@lV15FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV16TFProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV17TFProfesionalesId_Sel",GXType.Char,20,0) ,
          new ParDef("@lV18TFProfesionalesPrimerNombre",GXType.Char,30,0) ,
          new ParDef("@AV19TFProfesionalesPrimerNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV20TFProfesionalesSegundoNombre",GXType.Char,30,0) ,
          new ParDef("@AV21TFProfesionalesSegundoNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV22TFProfesionalesApellidoPrimero",GXType.Char,30,0) ,
          new ParDef("@AV23TFProfesionalesApellidoPrimero_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV24TFProfesionalesApellidoSegundo",GXType.Char,30,0) ,
          new ParDef("@AV25TFProfesionalesApellidoSegundo_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV26TFProfesionalesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV27TFProfesionalesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV28TFProfesionalesEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV29TFProfesionalesEmail_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00B13;
          prmH00B13 = new Object[] {
          new ParDef("@lV15FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV16TFProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV17TFProfesionalesId_Sel",GXType.Char,20,0) ,
          new ParDef("@lV18TFProfesionalesPrimerNombre",GXType.Char,30,0) ,
          new ParDef("@AV19TFProfesionalesPrimerNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV20TFProfesionalesSegundoNombre",GXType.Char,30,0) ,
          new ParDef("@AV21TFProfesionalesSegundoNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV22TFProfesionalesApellidoPrimero",GXType.Char,30,0) ,
          new ParDef("@AV23TFProfesionalesApellidoPrimero_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV24TFProfesionalesApellidoSegundo",GXType.Char,30,0) ,
          new ParDef("@AV25TFProfesionalesApellidoSegundo_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV26TFProfesionalesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV27TFProfesionalesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV28TFProfesionalesEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV29TFProfesionalesEmail_Sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00B12", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B12,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00B13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B13,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((string[]) buf[4])[0] = rslt.getString(4, 30);
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((string[]) buf[7])[0] = rslt.getString(7, 30);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
