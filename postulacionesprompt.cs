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
   public class postulacionesprompt : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public postulacionesprompt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public postulacionesprompt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_InOutPostulacionesId ,
                           ref string aP1_InOutPostulacionesProveedorNombre ,
                           ref long aP2_InOutPostulacionesProveedorId )
      {
         this.AV8InOutPostulacionesId = aP0_InOutPostulacionesId;
         this.AV20InOutPostulacionesProveedorNombre = aP1_InOutPostulacionesProveedorNombre;
         this.AV9InOutPostulacionesProveedorId = aP2_InOutPostulacionesProveedorId;
         ExecutePrivate();
         aP0_InOutPostulacionesId=this.AV8InOutPostulacionesId;
         aP1_InOutPostulacionesProveedorNombre=this.AV20InOutPostulacionesProveedorNombre;
         aP2_InOutPostulacionesProveedorId=this.AV9InOutPostulacionesProveedorId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkPostulacionesReqSuministros = new GXCheckbox();
         cmbPostulacionesEstado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "InOutPostulacionesId");
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
               gxfirstwebparm = GetFirstPar( "InOutPostulacionesId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "InOutPostulacionesId");
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
               AV8InOutPostulacionesId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8InOutPostulacionesId", StringUtil.LTrimStr( (decimal)(AV8InOutPostulacionesId), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV20InOutPostulacionesProveedorNombre = GetPar( "InOutPostulacionesProveedorNombre");
                  AssignAttri("", false, "AV20InOutPostulacionesProveedorNombre", AV20InOutPostulacionesProveedorNombre);
                  AV9InOutPostulacionesProveedorId = (long)(Math.Round(NumberUtil.Val( GetPar( "InOutPostulacionesProveedorId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV9InOutPostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(AV9InOutPostulacionesProveedorId), 18, 0));
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
         AV21Pgmname = GetPar( "Pgmname");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV21Pgmname) ;
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
         PAKJ2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTKJ2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("postulacionesprompt.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8InOutPostulacionesId,18,0)),UrlEncode(StringUtil.RTrim(AV20InOutPostulacionesProveedorNombre)),UrlEncode(StringUtil.LTrimStr(AV9InOutPostulacionesProveedorId,18,0))}, new string[] {"InOutPostulacionesId","InOutPostulacionesProveedorNombre","InOutPostulacionesProveedorId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV12OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vINOUTPOSTULACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8InOutPostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINOUTPOSTULACIONESPROVEEDORNOMBRE", StringUtil.RTrim( AV20InOutPostulacionesProveedorNombre));
         GxWebStd.gx_hidden_field( context, "vINOUTPOSTULACIONESPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9InOutPostulacionesProveedorId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
            WEKJ2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTKJ2( ) ;
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
         return formatLink("postulacionesprompt.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8InOutPostulacionesId,18,0)),UrlEncode(StringUtil.RTrim(AV20InOutPostulacionesProveedorNombre)),UrlEncode(StringUtil.LTrimStr(AV9InOutPostulacionesProveedorId,18,0))}, new string[] {"InOutPostulacionesId","InOutPostulacionesProveedorNombre","InOutPostulacionesProveedorId"})  ;
      }

      public override string GetPgmname( )
      {
         return "PostulacionesPrompt" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selecciona Postulaciones", "") ;
      }

      protected void WBKJ0( )
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
            wb_table1_14_KJ2( true) ;
         }
         else
         {
            wb_table1_14_KJ2( false) ;
         }
         return  ;
      }

      protected void wb_table1_14_KJ2e( bool wbgen )
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

      protected void STARTKJ2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selecciona Postulaciones", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPKJ0( ) ;
      }

      protected void WSKJ2( )
      {
         STARTKJ2( ) ;
         EVTKJ2( ) ;
      }

      protected void EVTKJ2( )
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
                              E11KJ2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E12KJ2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E13KJ2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCLEANFILTERS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCleanFilters' */
                              E14KJ2 ();
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
                              A422PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A942ServiciosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtServiciosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n942ServiciosId = false;
                              A943ServiciosNombre = cgiGet( edtServiciosNombre_Internalname);
                              A945PostulacionesProveedorId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesProveedorId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A969PostulacionesProveedorNombre = cgiGet( edtPostulacionesProveedorNombre_Internalname);
                              A946PostulacionesPrecio = context.localUtil.CToN( cgiGet( edtPostulacionesPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A961PostulacionesMultimediaSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesMultimediaSerial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A936PostulacionesDescripcion = cgiGet( edtPostulacionesDescripcion_Internalname);
                              A937PostulacionesReqSuministros = StringUtil.StrToBool( cgiGet( chkPostulacionesReqSuministros_Internalname));
                              A938PostulacionesSuministrosDescri = cgiGet( edtPostulacionesSuministrosDescri_Internalname);
                              A947PostulacionesFechaTrabajo = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPostulacionesFechaTrabajo_Internalname), 0));
                              A939PostulacionesFechaCierre = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPostulacionesFechaCierre_Internalname), 0));
                              A940PostulacionesHoraCierre = cgiGet( edtPostulacionesHoraCierre_Internalname);
                              A941PostulacionesTipoFecha = cgiGet( edtPostulacionesTipoFecha_Internalname);
                              A949PostulacionesRgoHoraservicio = cgiGet( edtPostulacionesRgoHoraservicio_Internalname);
                              A950PostulacionesApellidoNombre = cgiGet( edtPostulacionesApellidoNombre_Internalname);
                              A951PostulacionesMail = cgiGet( edtPostulacionesMail_Internalname);
                              A952PostulacionesTelefono = cgiGet( edtPostulacionesTelefono_Internalname);
                              A425PostulacionesFechaAlta = context.localUtil.CToT( cgiGet( edtPostulacionesFechaAlta_Internalname), 0);
                              cmbPostulacionesEstado.Name = cmbPostulacionesEstado_Internalname;
                              cmbPostulacionesEstado.CurrentValue = cgiGet( cmbPostulacionesEstado_Internalname);
                              A424PostulacionesEstado = cgiGet( cmbPostulacionesEstado_Internalname);
                              A948PostulacionesSecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E15KJ2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E16KJ2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E17KJ2 ();
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
                                          E18KJ2 ();
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

      protected void WEKJ2( )
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

      protected void PAKJ2( )
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
                                       string AV21Pgmname )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFKJ2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_POSTULACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "POSTULACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_POSTULACIONESPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A945PostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "POSTULACIONESPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A945PostulacionesProveedorId), 18, 0, ".", "")));
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
         RFKJ2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV21Pgmname = "PostulacionesPrompt";
         edtavSelect_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV13FilterFullText ,
                                              A422PostulacionesId ,
                                              A942ServiciosId ,
                                              A943ServiciosNombre ,
                                              A945PostulacionesProveedorId ,
                                              A969PostulacionesProveedorNombre ,
                                              A946PostulacionesPrecio ,
                                              A961PostulacionesMultimediaSerial ,
                                              A936PostulacionesDescripcion ,
                                              A938PostulacionesSuministrosDescri ,
                                              A940PostulacionesHoraCierre ,
                                              A941PostulacionesTipoFecha ,
                                              A949PostulacionesRgoHoraservicio ,
                                              A950PostulacionesApellidoNombre ,
                                              A951PostulacionesMail ,
                                              A952PostulacionesTelefono ,
                                              A424PostulacionesEstado ,
                                              A948PostulacionesSecUserId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG
                                              }
         });
         /* Using cursor H00KJ2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A948PostulacionesSecUserId = H00KJ2_A948PostulacionesSecUserId[0];
            A424PostulacionesEstado = H00KJ2_A424PostulacionesEstado[0];
            A425PostulacionesFechaAlta = H00KJ2_A425PostulacionesFechaAlta[0];
            A952PostulacionesTelefono = H00KJ2_A952PostulacionesTelefono[0];
            A951PostulacionesMail = H00KJ2_A951PostulacionesMail[0];
            A950PostulacionesApellidoNombre = H00KJ2_A950PostulacionesApellidoNombre[0];
            A949PostulacionesRgoHoraservicio = H00KJ2_A949PostulacionesRgoHoraservicio[0];
            A941PostulacionesTipoFecha = H00KJ2_A941PostulacionesTipoFecha[0];
            A940PostulacionesHoraCierre = H00KJ2_A940PostulacionesHoraCierre[0];
            A939PostulacionesFechaCierre = H00KJ2_A939PostulacionesFechaCierre[0];
            A947PostulacionesFechaTrabajo = H00KJ2_A947PostulacionesFechaTrabajo[0];
            A938PostulacionesSuministrosDescri = H00KJ2_A938PostulacionesSuministrosDescri[0];
            A937PostulacionesReqSuministros = H00KJ2_A937PostulacionesReqSuministros[0];
            A936PostulacionesDescripcion = H00KJ2_A936PostulacionesDescripcion[0];
            A961PostulacionesMultimediaSerial = H00KJ2_A961PostulacionesMultimediaSerial[0];
            A946PostulacionesPrecio = H00KJ2_A946PostulacionesPrecio[0];
            A969PostulacionesProveedorNombre = H00KJ2_A969PostulacionesProveedorNombre[0];
            A945PostulacionesProveedorId = H00KJ2_A945PostulacionesProveedorId[0];
            A943ServiciosNombre = H00KJ2_A943ServiciosNombre[0];
            A942ServiciosId = H00KJ2_A942ServiciosId[0];
            n942ServiciosId = H00KJ2_n942ServiciosId[0];
            A422PostulacionesId = H00KJ2_A422PostulacionesId[0];
            A969PostulacionesProveedorNombre = H00KJ2_A969PostulacionesProveedorNombre[0];
            A943ServiciosNombre = H00KJ2_A943ServiciosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV13FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV13FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV13FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) )
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

      protected void RFKJ2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 26;
         /* Execute user event: Refresh */
         E16KJ2 ();
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
                                                 AV11OrderedBy ,
                                                 AV12OrderedDsc ,
                                                 AV13FilterFullText ,
                                                 A422PostulacionesId ,
                                                 A942ServiciosId ,
                                                 A943ServiciosNombre ,
                                                 A945PostulacionesProveedorId ,
                                                 A969PostulacionesProveedorNombre ,
                                                 A946PostulacionesPrecio ,
                                                 A961PostulacionesMultimediaSerial ,
                                                 A936PostulacionesDescripcion ,
                                                 A938PostulacionesSuministrosDescri ,
                                                 A940PostulacionesHoraCierre ,
                                                 A941PostulacionesTipoFecha ,
                                                 A949PostulacionesRgoHoraservicio ,
                                                 A950PostulacionesApellidoNombre ,
                                                 A951PostulacionesMail ,
                                                 A952PostulacionesTelefono ,
                                                 A424PostulacionesEstado ,
                                                 A948PostulacionesSecUserId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H00KJ3 */
            pr_default.execute(1);
            nGXsfl_26_idx = 1;
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A948PostulacionesSecUserId = H00KJ3_A948PostulacionesSecUserId[0];
               A424PostulacionesEstado = H00KJ3_A424PostulacionesEstado[0];
               A425PostulacionesFechaAlta = H00KJ3_A425PostulacionesFechaAlta[0];
               A952PostulacionesTelefono = H00KJ3_A952PostulacionesTelefono[0];
               A951PostulacionesMail = H00KJ3_A951PostulacionesMail[0];
               A950PostulacionesApellidoNombre = H00KJ3_A950PostulacionesApellidoNombre[0];
               A949PostulacionesRgoHoraservicio = H00KJ3_A949PostulacionesRgoHoraservicio[0];
               A941PostulacionesTipoFecha = H00KJ3_A941PostulacionesTipoFecha[0];
               A940PostulacionesHoraCierre = H00KJ3_A940PostulacionesHoraCierre[0];
               A939PostulacionesFechaCierre = H00KJ3_A939PostulacionesFechaCierre[0];
               A947PostulacionesFechaTrabajo = H00KJ3_A947PostulacionesFechaTrabajo[0];
               A938PostulacionesSuministrosDescri = H00KJ3_A938PostulacionesSuministrosDescri[0];
               A937PostulacionesReqSuministros = H00KJ3_A937PostulacionesReqSuministros[0];
               A936PostulacionesDescripcion = H00KJ3_A936PostulacionesDescripcion[0];
               A961PostulacionesMultimediaSerial = H00KJ3_A961PostulacionesMultimediaSerial[0];
               A946PostulacionesPrecio = H00KJ3_A946PostulacionesPrecio[0];
               A969PostulacionesProveedorNombre = H00KJ3_A969PostulacionesProveedorNombre[0];
               A945PostulacionesProveedorId = H00KJ3_A945PostulacionesProveedorId[0];
               A943ServiciosNombre = H00KJ3_A943ServiciosNombre[0];
               A942ServiciosId = H00KJ3_A942ServiciosId[0];
               n942ServiciosId = H00KJ3_n942ServiciosId[0];
               A422PostulacionesId = H00KJ3_A422PostulacionesId[0];
               A969PostulacionesProveedorNombre = H00KJ3_A969PostulacionesProveedorNombre[0];
               A943ServiciosNombre = H00KJ3_A943ServiciosNombre[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV13FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV13FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV13FilterFullText) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E17KJ2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 26;
            WBKJ0( ) ;
         }
         bGXsfl_26_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesKJ2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_POSTULACIONESID"+"_"+sGXsfl_26_idx, GetSecureSignedToken( sGXsfl_26_idx, context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_POSTULACIONESPROVEEDORID"+"_"+sGXsfl_26_idx, GetSecureSignedToken( sGXsfl_26_idx, context.localUtil.Format( (decimal)(A945PostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV21Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV21Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV21Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV21Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV21Pgmname) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV21Pgmname = "PostulacionesPrompt";
         edtavSelect_Enabled = 0;
         edtPostulacionesId_Enabled = 0;
         edtServiciosId_Enabled = 0;
         edtServiciosNombre_Enabled = 0;
         edtPostulacionesProveedorId_Enabled = 0;
         edtPostulacionesProveedorNombre_Enabled = 0;
         edtPostulacionesPrecio_Enabled = 0;
         edtPostulacionesMultimediaSerial_Enabled = 0;
         edtPostulacionesDescripcion_Enabled = 0;
         chkPostulacionesReqSuministros.Enabled = 0;
         edtPostulacionesSuministrosDescri_Enabled = 0;
         edtPostulacionesFechaTrabajo_Enabled = 0;
         edtPostulacionesFechaCierre_Enabled = 0;
         edtPostulacionesHoraCierre_Enabled = 0;
         edtPostulacionesTipoFecha_Enabled = 0;
         edtPostulacionesRgoHoraservicio_Enabled = 0;
         edtPostulacionesApellidoNombre_Enabled = 0;
         edtPostulacionesMail_Enabled = 0;
         edtPostulacionesTelefono_Enabled = 0;
         edtPostulacionesFechaAlta_Enabled = 0;
         cmbPostulacionesEstado.Enabled = 0;
         edtPostulacionesSecUserId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPKJ0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15KJ2 ();
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
         E15KJ2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E15KJ2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( "Selecciona Postulaciones", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E16KJ2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         AV16GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV16GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV16GridCurrentPage), 10, 0));
         AV17GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV17GridPageCount", StringUtil.LTrimStr( (decimal)(AV17GridPageCount), 10, 0));
         GXt_char2 = AV18GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV21Pgmname, out  GXt_char2) ;
         AV18GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV18GridAppliedFilters", AV18GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E11KJ2( )
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

      protected void E12KJ2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E13KJ2( )
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
         /*  Sending Event outputs  */
      }

      private void E17KJ2( )
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
         E18KJ2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18KJ2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV8InOutPostulacionesId = A422PostulacionesId;
         AssignAttri("", false, "AV8InOutPostulacionesId", StringUtil.LTrimStr( (decimal)(AV8InOutPostulacionesId), 18, 0));
         AV20InOutPostulacionesProveedorNombre = A969PostulacionesProveedorNombre;
         AssignAttri("", false, "AV20InOutPostulacionesProveedorNombre", AV20InOutPostulacionesProveedorNombre);
         AV9InOutPostulacionesProveedorId = A945PostulacionesProveedorId;
         AssignAttri("", false, "AV9InOutPostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(AV9InOutPostulacionesProveedorId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV8InOutPostulacionesId,(string)AV20InOutPostulacionesProveedorNombre,(long)AV9InOutPostulacionesProveedorId});
         context.setWebReturnParmsMetadata(new Object[] {"AV8InOutPostulacionesId","AV20InOutPostulacionesProveedorNombre","AV9InOutPostulacionesProveedorId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void E14KJ2( )
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
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV11OrderedBy), 4, 0))+":"+(AV12OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV13FilterFullText = "";
         AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
      }

      protected void wb_table1_14_KJ2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellAlignTop CellPaddingTop10'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCleanfilters_Internalname, context.GetMessage( "<i class=\"fas fa-filter CleanFiltersIcon\"></i>", ""), "", "", lblCleanfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOCLEANFILTERS\\'."+"'", "", "TextBlock", 5, context.GetMessage( "WWP_CleanFiltersTooltip", ""), 1, 1, 0, 1, "HLP_PostulacionesPrompt.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_26_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV13FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_PostulacionesPrompt.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_14_KJ2e( true) ;
         }
         else
         {
            wb_table1_14_KJ2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8InOutPostulacionesId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV8InOutPostulacionesId", StringUtil.LTrimStr( (decimal)(AV8InOutPostulacionesId), 18, 0));
         AV20InOutPostulacionesProveedorNombre = (string)getParm(obj,1);
         AssignAttri("", false, "AV20InOutPostulacionesProveedorNombre", AV20InOutPostulacionesProveedorNombre);
         AV9InOutPostulacionesProveedorId = Convert.ToInt64(getParm(obj,2));
         AssignAttri("", false, "AV9InOutPostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(AV9InOutPostulacionesProveedorId), 18, 0));
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
         PAKJ2( ) ;
         WSKJ2( ) ;
         WEKJ2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932018251", true, true, false);
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
         context.AddJavascriptSource("postulacionesprompt.js", "?2026932018251", false, true, false);
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
         edtPostulacionesId_Internalname = "POSTULACIONESID_"+sGXsfl_26_idx;
         edtServiciosId_Internalname = "SERVICIOSID_"+sGXsfl_26_idx;
         edtServiciosNombre_Internalname = "SERVICIOSNOMBRE_"+sGXsfl_26_idx;
         edtPostulacionesProveedorId_Internalname = "POSTULACIONESPROVEEDORID_"+sGXsfl_26_idx;
         edtPostulacionesProveedorNombre_Internalname = "POSTULACIONESPROVEEDORNOMBRE_"+sGXsfl_26_idx;
         edtPostulacionesPrecio_Internalname = "POSTULACIONESPRECIO_"+sGXsfl_26_idx;
         edtPostulacionesMultimediaSerial_Internalname = "POSTULACIONESMULTIMEDIASERIAL_"+sGXsfl_26_idx;
         edtPostulacionesDescripcion_Internalname = "POSTULACIONESDESCRIPCION_"+sGXsfl_26_idx;
         chkPostulacionesReqSuministros_Internalname = "POSTULACIONESREQSUMINISTROS_"+sGXsfl_26_idx;
         edtPostulacionesSuministrosDescri_Internalname = "POSTULACIONESSUMINISTROSDESCRI_"+sGXsfl_26_idx;
         edtPostulacionesFechaTrabajo_Internalname = "POSTULACIONESFECHATRABAJO_"+sGXsfl_26_idx;
         edtPostulacionesFechaCierre_Internalname = "POSTULACIONESFECHACIERRE_"+sGXsfl_26_idx;
         edtPostulacionesHoraCierre_Internalname = "POSTULACIONESHORACIERRE_"+sGXsfl_26_idx;
         edtPostulacionesTipoFecha_Internalname = "POSTULACIONESTIPOFECHA_"+sGXsfl_26_idx;
         edtPostulacionesRgoHoraservicio_Internalname = "POSTULACIONESRGOHORASERVICIO_"+sGXsfl_26_idx;
         edtPostulacionesApellidoNombre_Internalname = "POSTULACIONESAPELLIDONOMBRE_"+sGXsfl_26_idx;
         edtPostulacionesMail_Internalname = "POSTULACIONESMAIL_"+sGXsfl_26_idx;
         edtPostulacionesTelefono_Internalname = "POSTULACIONESTELEFONO_"+sGXsfl_26_idx;
         edtPostulacionesFechaAlta_Internalname = "POSTULACIONESFECHAALTA_"+sGXsfl_26_idx;
         cmbPostulacionesEstado_Internalname = "POSTULACIONESESTADO_"+sGXsfl_26_idx;
         edtPostulacionesSecUserId_Internalname = "POSTULACIONESSECUSERID_"+sGXsfl_26_idx;
      }

      protected void SubsflControlProps_fel_262( )
      {
         edtavSelect_Internalname = "vSELECT_"+sGXsfl_26_fel_idx;
         edtPostulacionesId_Internalname = "POSTULACIONESID_"+sGXsfl_26_fel_idx;
         edtServiciosId_Internalname = "SERVICIOSID_"+sGXsfl_26_fel_idx;
         edtServiciosNombre_Internalname = "SERVICIOSNOMBRE_"+sGXsfl_26_fel_idx;
         edtPostulacionesProveedorId_Internalname = "POSTULACIONESPROVEEDORID_"+sGXsfl_26_fel_idx;
         edtPostulacionesProveedorNombre_Internalname = "POSTULACIONESPROVEEDORNOMBRE_"+sGXsfl_26_fel_idx;
         edtPostulacionesPrecio_Internalname = "POSTULACIONESPRECIO_"+sGXsfl_26_fel_idx;
         edtPostulacionesMultimediaSerial_Internalname = "POSTULACIONESMULTIMEDIASERIAL_"+sGXsfl_26_fel_idx;
         edtPostulacionesDescripcion_Internalname = "POSTULACIONESDESCRIPCION_"+sGXsfl_26_fel_idx;
         chkPostulacionesReqSuministros_Internalname = "POSTULACIONESREQSUMINISTROS_"+sGXsfl_26_fel_idx;
         edtPostulacionesSuministrosDescri_Internalname = "POSTULACIONESSUMINISTROSDESCRI_"+sGXsfl_26_fel_idx;
         edtPostulacionesFechaTrabajo_Internalname = "POSTULACIONESFECHATRABAJO_"+sGXsfl_26_fel_idx;
         edtPostulacionesFechaCierre_Internalname = "POSTULACIONESFECHACIERRE_"+sGXsfl_26_fel_idx;
         edtPostulacionesHoraCierre_Internalname = "POSTULACIONESHORACIERRE_"+sGXsfl_26_fel_idx;
         edtPostulacionesTipoFecha_Internalname = "POSTULACIONESTIPOFECHA_"+sGXsfl_26_fel_idx;
         edtPostulacionesRgoHoraservicio_Internalname = "POSTULACIONESRGOHORASERVICIO_"+sGXsfl_26_fel_idx;
         edtPostulacionesApellidoNombre_Internalname = "POSTULACIONESAPELLIDONOMBRE_"+sGXsfl_26_fel_idx;
         edtPostulacionesMail_Internalname = "POSTULACIONESMAIL_"+sGXsfl_26_fel_idx;
         edtPostulacionesTelefono_Internalname = "POSTULACIONESTELEFONO_"+sGXsfl_26_fel_idx;
         edtPostulacionesFechaAlta_Internalname = "POSTULACIONESFECHAALTA_"+sGXsfl_26_fel_idx;
         cmbPostulacionesEstado_Internalname = "POSTULACIONESESTADO_"+sGXsfl_26_fel_idx;
         edtPostulacionesSecUserId_Internalname = "POSTULACIONESSECUSERID_"+sGXsfl_26_fel_idx;
      }

      protected void sendrow_262( )
      {
         sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
         SubsflControlProps_262( ) ;
         WBKJ0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtServiciosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A942ServiciosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A942ServiciosId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtServiciosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtServiciosNombre_Internalname,StringUtil.RTrim( A943ServiciosNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtServiciosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesProveedorId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A945PostulacionesProveedorId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A945PostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesProveedorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesProveedorNombre_Internalname,StringUtil.RTrim( A969PostulacionesProveedorNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesProveedorNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( A946PostulacionesPrecio, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A946PostulacionesPrecio, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesMultimediaSerial_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A961PostulacionesMultimediaSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A961PostulacionesMultimediaSerial), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesMultimediaSerial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesDescripcion_Internalname,StringUtil.RTrim( A936PostulacionesDescripcion),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2000,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "POSTULACIONESREQSUMINISTROS_" + sGXsfl_26_idx;
            chkPostulacionesReqSuministros.Name = GXCCtl;
            chkPostulacionesReqSuministros.WebTags = "";
            chkPostulacionesReqSuministros.Caption = "";
            AssignProp("", false, chkPostulacionesReqSuministros_Internalname, "TitleCaption", chkPostulacionesReqSuministros.Caption, !bGXsfl_26_Refreshing);
            chkPostulacionesReqSuministros.CheckedValue = "false";
            A937PostulacionesReqSuministros = StringUtil.StrToBool( StringUtil.BoolToStr( A937PostulacionesReqSuministros));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkPostulacionesReqSuministros_Internalname,StringUtil.BoolToStr( A937PostulacionesReqSuministros),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesSuministrosDescri_Internalname,StringUtil.RTrim( A938PostulacionesSuministrosDescri),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesSuministrosDescri_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)250,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesFechaTrabajo_Internalname,context.localUtil.Format(A947PostulacionesFechaTrabajo, "99/99/99"),context.localUtil.Format( A947PostulacionesFechaTrabajo, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesFechaTrabajo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesFechaCierre_Internalname,context.localUtil.Format(A939PostulacionesFechaCierre, "99/99/99"),context.localUtil.Format( A939PostulacionesFechaCierre, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesFechaCierre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesHoraCierre_Internalname,(string)A940PostulacionesHoraCierre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesHoraCierre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesTipoFecha_Internalname,(string)A941PostulacionesTipoFecha,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesTipoFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesRgoHoraservicio_Internalname,StringUtil.RTrim( A949PostulacionesRgoHoraservicio),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesRgoHoraservicio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesApellidoNombre_Internalname,StringUtil.RTrim( A950PostulacionesApellidoNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesApellidoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesMail_Internalname,(string)A951PostulacionesMail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A951PostulacionesMail,(string)"",(string)"",(string)"",(string)edtPostulacionesMail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A952PostulacionesTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesTelefono_Internalname,StringUtil.RTrim( A952PostulacionesTelefono),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtPostulacionesTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesFechaAlta_Internalname,context.localUtil.TToC( A425PostulacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A425PostulacionesFechaAlta, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbPostulacionesEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "POSTULACIONESESTADO_" + sGXsfl_26_idx;
               cmbPostulacionesEstado.Name = GXCCtl;
               cmbPostulacionesEstado.WebTags = "";
               cmbPostulacionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbPostulacionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbPostulacionesEstado.addItem("GAN", context.GetMessage( "Ganador", ""), 0);
               if ( cmbPostulacionesEstado.ItemCount > 0 )
               {
                  A424PostulacionesEstado = cmbPostulacionesEstado.getValidValue(A424PostulacionesEstado);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPostulacionesEstado,(string)cmbPostulacionesEstado_Internalname,StringUtil.RTrim( A424PostulacionesEstado),(short)1,(string)cmbPostulacionesEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbPostulacionesEstado.CurrentValue = StringUtil.RTrim( A424PostulacionesEstado);
            AssignProp("", false, cmbPostulacionesEstado_Internalname, "Values", (string)(cmbPostulacionesEstado.ToJavascriptSource()), !bGXsfl_26_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesSecUserId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A948PostulacionesSecUserId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A948PostulacionesSecUserId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesSecUserId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesKJ2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_26_idx = ((subGrid_Islastpage==1)&&(nGXsfl_26_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_26_idx+1);
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
         }
         /* End function sendrow_262 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "POSTULACIONESREQSUMINISTROS_" + sGXsfl_26_idx;
         chkPostulacionesReqSuministros.Name = GXCCtl;
         chkPostulacionesReqSuministros.WebTags = "";
         chkPostulacionesReqSuministros.Caption = "";
         AssignProp("", false, chkPostulacionesReqSuministros_Internalname, "TitleCaption", chkPostulacionesReqSuministros.Caption, !bGXsfl_26_Refreshing);
         chkPostulacionesReqSuministros.CheckedValue = "false";
         A937PostulacionesReqSuministros = StringUtil.StrToBool( StringUtil.BoolToStr( A937PostulacionesReqSuministros));
         GXCCtl = "POSTULACIONESESTADO_" + sGXsfl_26_idx;
         cmbPostulacionesEstado.Name = GXCCtl;
         cmbPostulacionesEstado.WebTags = "";
         cmbPostulacionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbPostulacionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbPostulacionesEstado.addItem("GAN", context.GetMessage( "Ganador", ""), 0);
         if ( cmbPostulacionesEstado.ItemCount > 0 )
         {
            A424PostulacionesEstado = cmbPostulacionesEstado.getValidValue(A424PostulacionesEstado);
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Servicios Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Servicios Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Proveedor Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Proveedor Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Multimedia Serial", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Descripcion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Req Suministros", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Suministros Descripcion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Trabajo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Cierre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Hora Cierre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo Fecha", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rgo Horaservicio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Apellido Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Mail", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Telefono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "User Id", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A942ServiciosId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A943ServiciosNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A945PostulacionesProveedorId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A969PostulacionesProveedorNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A946PostulacionesPrecio, 21, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A961PostulacionesMultimediaSerial), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A936PostulacionesDescripcion)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A937PostulacionesReqSuministros)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A938PostulacionesSuministrosDescri)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A947PostulacionesFechaTrabajo, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A939PostulacionesFechaCierre, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A940PostulacionesHoraCierre));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A941PostulacionesTipoFecha));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A949PostulacionesRgoHoraservicio)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A950PostulacionesApellidoNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A951PostulacionesMail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A952PostulacionesTelefono)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A425PostulacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A424PostulacionesEstado)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A948PostulacionesSecUserId), 18, 0, ".", ""))));
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
         edtPostulacionesId_Internalname = "POSTULACIONESID";
         edtServiciosId_Internalname = "SERVICIOSID";
         edtServiciosNombre_Internalname = "SERVICIOSNOMBRE";
         edtPostulacionesProveedorId_Internalname = "POSTULACIONESPROVEEDORID";
         edtPostulacionesProveedorNombre_Internalname = "POSTULACIONESPROVEEDORNOMBRE";
         edtPostulacionesPrecio_Internalname = "POSTULACIONESPRECIO";
         edtPostulacionesMultimediaSerial_Internalname = "POSTULACIONESMULTIMEDIASERIAL";
         edtPostulacionesDescripcion_Internalname = "POSTULACIONESDESCRIPCION";
         chkPostulacionesReqSuministros_Internalname = "POSTULACIONESREQSUMINISTROS";
         edtPostulacionesSuministrosDescri_Internalname = "POSTULACIONESSUMINISTROSDESCRI";
         edtPostulacionesFechaTrabajo_Internalname = "POSTULACIONESFECHATRABAJO";
         edtPostulacionesFechaCierre_Internalname = "POSTULACIONESFECHACIERRE";
         edtPostulacionesHoraCierre_Internalname = "POSTULACIONESHORACIERRE";
         edtPostulacionesTipoFecha_Internalname = "POSTULACIONESTIPOFECHA";
         edtPostulacionesRgoHoraservicio_Internalname = "POSTULACIONESRGOHORASERVICIO";
         edtPostulacionesApellidoNombre_Internalname = "POSTULACIONESAPELLIDONOMBRE";
         edtPostulacionesMail_Internalname = "POSTULACIONESMAIL";
         edtPostulacionesTelefono_Internalname = "POSTULACIONESTELEFONO";
         edtPostulacionesFechaAlta_Internalname = "POSTULACIONESFECHAALTA";
         cmbPostulacionesEstado_Internalname = "POSTULACIONESESTADO";
         edtPostulacionesSecUserId_Internalname = "POSTULACIONESSECUSERID";
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
         edtPostulacionesSecUserId_Jsonclick = "";
         cmbPostulacionesEstado_Jsonclick = "";
         edtPostulacionesFechaAlta_Jsonclick = "";
         edtPostulacionesTelefono_Jsonclick = "";
         edtPostulacionesMail_Jsonclick = "";
         edtPostulacionesApellidoNombre_Jsonclick = "";
         edtPostulacionesRgoHoraservicio_Jsonclick = "";
         edtPostulacionesTipoFecha_Jsonclick = "";
         edtPostulacionesHoraCierre_Jsonclick = "";
         edtPostulacionesFechaCierre_Jsonclick = "";
         edtPostulacionesFechaTrabajo_Jsonclick = "";
         edtPostulacionesSuministrosDescri_Jsonclick = "";
         chkPostulacionesReqSuministros.Caption = "";
         edtPostulacionesDescripcion_Jsonclick = "";
         edtPostulacionesMultimediaSerial_Jsonclick = "";
         edtPostulacionesPrecio_Jsonclick = "";
         edtPostulacionesProveedorNombre_Jsonclick = "";
         edtPostulacionesProveedorId_Jsonclick = "";
         edtServiciosNombre_Jsonclick = "";
         edtServiciosId_Jsonclick = "";
         edtPostulacionesId_Jsonclick = "";
         edtavSelect_Jsonclick = "";
         edtavSelect_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtPostulacionesSecUserId_Enabled = 0;
         cmbPostulacionesEstado.Enabled = 0;
         edtPostulacionesFechaAlta_Enabled = 0;
         edtPostulacionesTelefono_Enabled = 0;
         edtPostulacionesMail_Enabled = 0;
         edtPostulacionesApellidoNombre_Enabled = 0;
         edtPostulacionesRgoHoraservicio_Enabled = 0;
         edtPostulacionesTipoFecha_Enabled = 0;
         edtPostulacionesHoraCierre_Enabled = 0;
         edtPostulacionesFechaCierre_Enabled = 0;
         edtPostulacionesFechaTrabajo_Enabled = 0;
         edtPostulacionesSuministrosDescri_Enabled = 0;
         chkPostulacionesReqSuministros.Enabled = 0;
         edtPostulacionesDescripcion_Enabled = 0;
         edtPostulacionesMultimediaSerial_Enabled = 0;
         edtPostulacionesPrecio_Enabled = 0;
         edtPostulacionesProveedorNombre_Enabled = 0;
         edtPostulacionesProveedorId_Enabled = 0;
         edtServiciosNombre_Enabled = 0;
         edtServiciosId_Enabled = 0;
         edtPostulacionesId_Enabled = 0;
         subGrid_Sortable = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "3|4|5|2|1|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21";
         Ddo_grid_Columnids = "1:PostulacionesId|2:ServiciosId|3:ServiciosNombre|4:PostulacionesProveedorId|5:PostulacionesProveedorNombre|6:PostulacionesPrecio|7:PostulacionesMultimediaSerial|8:PostulacionesDescripcion|9:PostulacionesReqSuministros|10:PostulacionesSuministrosDescripcion|11:PostulacionesFechaTrabajo|12:PostulacionesFechaCierre|13:PostulacionesHoraCierre|14:PostulacionesTipoFecha|15:PostulacionesRgoHoraservicio|16:PostulacionesApellidoNombre|17:PostulacionesMail|18:PostulacionesTelefono|19:PostulacionesFechaAlta|20:PostulacionesEstado|21:PostulacionesSecUserId";
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
         Form.Caption = context.GetMessage( "Selecciona Postulaciones", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV16GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV17GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV18GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11KJ2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV16GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV17GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV18GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12KJ2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E13KJ2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E17KJ2',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV19Select',fld:'vSELECT',pic:'',type:'char'}]}");
         setEventMetadata("ENTER","{handler:'E18KJ2',iparms:[{av:'A422PostulacionesId',fld:'POSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A969PostulacionesProveedorNombre',fld:'POSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'A945PostulacionesProveedorId',fld:'POSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV8InOutPostulacionesId',fld:'vINOUTPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20InOutPostulacionesProveedorNombre',fld:'vINOUTPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV9InOutPostulacionesProveedorId',fld:'vINOUTPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("'DOCLEANFILTERS'","{handler:'E14KJ2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("'DOCLEANFILTERS'",",oparms:[{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'}]}");
         setEventMetadata("VALID_POSTULACIONESID","{handler:'Valid_Postulacionesid',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESID",",oparms:[]}");
         setEventMetadata("VALID_SERVICIOSID","{handler:'Valid_Serviciosid',iparms:[]");
         setEventMetadata("VALID_SERVICIOSID",",oparms:[]}");
         setEventMetadata("VALID_SERVICIOSNOMBRE","{handler:'Valid_Serviciosnombre',iparms:[]");
         setEventMetadata("VALID_SERVICIOSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESPROVEEDORID","{handler:'Valid_Postulacionesproveedorid',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESPROVEEDORID",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESPROVEEDORNOMBRE","{handler:'Valid_Postulacionesproveedornombre',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESPROVEEDORNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESPRECIO","{handler:'Valid_Postulacionesprecio',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESPRECIO",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESMULTIMEDIASERIAL","{handler:'Valid_Postulacionesmultimediaserial',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESMULTIMEDIASERIAL",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESDESCRIPCION","{handler:'Valid_Postulacionesdescripcion',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESDESCRIPCION",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESSUMINISTROSDESCRI","{handler:'Valid_Postulacionessuministrosdescri',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESSUMINISTROSDESCRI",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESHORACIERRE","{handler:'Valid_Postulacioneshoracierre',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESHORACIERRE",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESTIPOFECHA","{handler:'Valid_Postulacionestipofecha',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESTIPOFECHA",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESRGOHORASERVICIO","{handler:'Valid_Postulacionesrgohoraservicio',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESRGOHORASERVICIO",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESAPELLIDONOMBRE","{handler:'Valid_Postulacionesapellidonombre',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESAPELLIDONOMBRE",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESMAIL","{handler:'Valid_Postulacionesmail',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESMAIL",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESTELEFONO","{handler:'Valid_Postulacionestelefono',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESTELEFONO",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESESTADO","{handler:'Valid_Postulacionesestado',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESESTADO",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESSECUSERID","{handler:'Valid_Postulacionessecuserid',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESSECUSERID",",oparms:[]}");
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
         wcpOAV20InOutPostulacionesProveedorNombre = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV13FilterFullText = "";
         AV21Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV18GridAppliedFilters = "";
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         AV19Select = "";
         A943ServiciosNombre = "";
         A969PostulacionesProveedorNombre = "";
         A936PostulacionesDescripcion = "";
         A938PostulacionesSuministrosDescri = "";
         A947PostulacionesFechaTrabajo = DateTime.MinValue;
         A939PostulacionesFechaCierre = DateTime.MinValue;
         A940PostulacionesHoraCierre = "";
         A941PostulacionesTipoFecha = "";
         A949PostulacionesRgoHoraservicio = "";
         A950PostulacionesApellidoNombre = "";
         A951PostulacionesMail = "";
         A952PostulacionesTelefono = "";
         A425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         A424PostulacionesEstado = "";
         lV13FilterFullText = "";
         H00KJ2_A948PostulacionesSecUserId = new long[1] ;
         H00KJ2_A424PostulacionesEstado = new string[] {""} ;
         H00KJ2_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00KJ2_A952PostulacionesTelefono = new string[] {""} ;
         H00KJ2_A951PostulacionesMail = new string[] {""} ;
         H00KJ2_A950PostulacionesApellidoNombre = new string[] {""} ;
         H00KJ2_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         H00KJ2_A941PostulacionesTipoFecha = new string[] {""} ;
         H00KJ2_A940PostulacionesHoraCierre = new string[] {""} ;
         H00KJ2_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         H00KJ2_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         H00KJ2_A938PostulacionesSuministrosDescri = new string[] {""} ;
         H00KJ2_A937PostulacionesReqSuministros = new bool[] {false} ;
         H00KJ2_A936PostulacionesDescripcion = new string[] {""} ;
         H00KJ2_A961PostulacionesMultimediaSerial = new short[1] ;
         H00KJ2_A946PostulacionesPrecio = new decimal[1] ;
         H00KJ2_A969PostulacionesProveedorNombre = new string[] {""} ;
         H00KJ2_A945PostulacionesProveedorId = new long[1] ;
         H00KJ2_A943ServiciosNombre = new string[] {""} ;
         H00KJ2_A942ServiciosId = new long[1] ;
         H00KJ2_n942ServiciosId = new bool[] {false} ;
         H00KJ2_A422PostulacionesId = new long[1] ;
         H00KJ3_A948PostulacionesSecUserId = new long[1] ;
         H00KJ3_A424PostulacionesEstado = new string[] {""} ;
         H00KJ3_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00KJ3_A952PostulacionesTelefono = new string[] {""} ;
         H00KJ3_A951PostulacionesMail = new string[] {""} ;
         H00KJ3_A950PostulacionesApellidoNombre = new string[] {""} ;
         H00KJ3_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         H00KJ3_A941PostulacionesTipoFecha = new string[] {""} ;
         H00KJ3_A940PostulacionesHoraCierre = new string[] {""} ;
         H00KJ3_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         H00KJ3_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         H00KJ3_A938PostulacionesSuministrosDescri = new string[] {""} ;
         H00KJ3_A937PostulacionesReqSuministros = new bool[] {false} ;
         H00KJ3_A936PostulacionesDescripcion = new string[] {""} ;
         H00KJ3_A961PostulacionesMultimediaSerial = new short[1] ;
         H00KJ3_A946PostulacionesPrecio = new decimal[1] ;
         H00KJ3_A969PostulacionesProveedorNombre = new string[] {""} ;
         H00KJ3_A945PostulacionesProveedorId = new long[1] ;
         H00KJ3_A943ServiciosNombre = new string[] {""} ;
         H00KJ3_A942ServiciosId = new long[1] ;
         H00KJ3_n942ServiciosId = new bool[] {false} ;
         H00KJ3_A422PostulacionesId = new long[1] ;
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
         ClassString = "";
         StyleString = "";
         GXCCtl = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.postulacionesprompt__default(),
            new Object[][] {
                new Object[] {
               H00KJ2_A948PostulacionesSecUserId, H00KJ2_A424PostulacionesEstado, H00KJ2_A425PostulacionesFechaAlta, H00KJ2_A952PostulacionesTelefono, H00KJ2_A951PostulacionesMail, H00KJ2_A950PostulacionesApellidoNombre, H00KJ2_A949PostulacionesRgoHoraservicio, H00KJ2_A941PostulacionesTipoFecha, H00KJ2_A940PostulacionesHoraCierre, H00KJ2_A939PostulacionesFechaCierre,
               H00KJ2_A947PostulacionesFechaTrabajo, H00KJ2_A938PostulacionesSuministrosDescri, H00KJ2_A937PostulacionesReqSuministros, H00KJ2_A936PostulacionesDescripcion, H00KJ2_A961PostulacionesMultimediaSerial, H00KJ2_A946PostulacionesPrecio, H00KJ2_A969PostulacionesProveedorNombre, H00KJ2_A945PostulacionesProveedorId, H00KJ2_A943ServiciosNombre, H00KJ2_A942ServiciosId,
               H00KJ2_n942ServiciosId, H00KJ2_A422PostulacionesId
               }
               , new Object[] {
               H00KJ3_A948PostulacionesSecUserId, H00KJ3_A424PostulacionesEstado, H00KJ3_A425PostulacionesFechaAlta, H00KJ3_A952PostulacionesTelefono, H00KJ3_A951PostulacionesMail, H00KJ3_A950PostulacionesApellidoNombre, H00KJ3_A949PostulacionesRgoHoraservicio, H00KJ3_A941PostulacionesTipoFecha, H00KJ3_A940PostulacionesHoraCierre, H00KJ3_A939PostulacionesFechaCierre,
               H00KJ3_A947PostulacionesFechaTrabajo, H00KJ3_A938PostulacionesSuministrosDescri, H00KJ3_A937PostulacionesReqSuministros, H00KJ3_A936PostulacionesDescripcion, H00KJ3_A961PostulacionesMultimediaSerial, H00KJ3_A946PostulacionesPrecio, H00KJ3_A969PostulacionesProveedorNombre, H00KJ3_A945PostulacionesProveedorId, H00KJ3_A943ServiciosNombre, H00KJ3_A942ServiciosId,
               H00KJ3_n942ServiciosId, H00KJ3_A422PostulacionesId
               }
            }
         );
         AV21Pgmname = "PostulacionesPrompt";
         /* GeneXus formulas. */
         AV21Pgmname = "PostulacionesPrompt";
         edtavSelect_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV11OrderedBy ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A961PostulacionesMultimediaSerial ;
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
      private int edtPostulacionesId_Enabled ;
      private int edtServiciosId_Enabled ;
      private int edtServiciosNombre_Enabled ;
      private int edtPostulacionesProveedorId_Enabled ;
      private int edtPostulacionesProveedorNombre_Enabled ;
      private int edtPostulacionesPrecio_Enabled ;
      private int edtPostulacionesMultimediaSerial_Enabled ;
      private int edtPostulacionesDescripcion_Enabled ;
      private int edtPostulacionesSuministrosDescri_Enabled ;
      private int edtPostulacionesFechaTrabajo_Enabled ;
      private int edtPostulacionesFechaCierre_Enabled ;
      private int edtPostulacionesHoraCierre_Enabled ;
      private int edtPostulacionesTipoFecha_Enabled ;
      private int edtPostulacionesRgoHoraservicio_Enabled ;
      private int edtPostulacionesApellidoNombre_Enabled ;
      private int edtPostulacionesMail_Enabled ;
      private int edtPostulacionesTelefono_Enabled ;
      private int edtPostulacionesFechaAlta_Enabled ;
      private int edtPostulacionesSecUserId_Enabled ;
      private int AV15PageToGo ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8InOutPostulacionesId ;
      private long AV9InOutPostulacionesProveedorId ;
      private long wcpOAV8InOutPostulacionesId ;
      private long wcpOAV9InOutPostulacionesProveedorId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV16GridCurrentPage ;
      private long AV17GridPageCount ;
      private long A422PostulacionesId ;
      private long A942ServiciosId ;
      private long A945PostulacionesProveedorId ;
      private long A948PostulacionesSecUserId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A946PostulacionesPrecio ;
      private string AV20InOutPostulacionesProveedorNombre ;
      private string wcpOAV20InOutPostulacionesProveedorNombre ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_26_idx="0001" ;
      private string AV21Pgmname ;
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
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV19Select ;
      private string edtavSelect_Internalname ;
      private string edtPostulacionesId_Internalname ;
      private string edtServiciosId_Internalname ;
      private string A943ServiciosNombre ;
      private string edtServiciosNombre_Internalname ;
      private string edtPostulacionesProveedorId_Internalname ;
      private string A969PostulacionesProveedorNombre ;
      private string edtPostulacionesProveedorNombre_Internalname ;
      private string edtPostulacionesPrecio_Internalname ;
      private string edtPostulacionesMultimediaSerial_Internalname ;
      private string A936PostulacionesDescripcion ;
      private string edtPostulacionesDescripcion_Internalname ;
      private string chkPostulacionesReqSuministros_Internalname ;
      private string A938PostulacionesSuministrosDescri ;
      private string edtPostulacionesSuministrosDescri_Internalname ;
      private string edtPostulacionesFechaTrabajo_Internalname ;
      private string edtPostulacionesFechaCierre_Internalname ;
      private string edtPostulacionesHoraCierre_Internalname ;
      private string edtPostulacionesTipoFecha_Internalname ;
      private string A949PostulacionesRgoHoraservicio ;
      private string edtPostulacionesRgoHoraservicio_Internalname ;
      private string A950PostulacionesApellidoNombre ;
      private string edtPostulacionesApellidoNombre_Internalname ;
      private string edtPostulacionesMail_Internalname ;
      private string A952PostulacionesTelefono ;
      private string edtPostulacionesTelefono_Internalname ;
      private string edtPostulacionesFechaAlta_Internalname ;
      private string cmbPostulacionesEstado_Internalname ;
      private string A424PostulacionesEstado ;
      private string edtPostulacionesSecUserId_Internalname ;
      private string edtavFilterfulltext_Internalname ;
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
      private string edtPostulacionesId_Jsonclick ;
      private string edtServiciosId_Jsonclick ;
      private string edtServiciosNombre_Jsonclick ;
      private string edtPostulacionesProveedorId_Jsonclick ;
      private string edtPostulacionesProveedorNombre_Jsonclick ;
      private string edtPostulacionesPrecio_Jsonclick ;
      private string edtPostulacionesMultimediaSerial_Jsonclick ;
      private string edtPostulacionesDescripcion_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string GXCCtl ;
      private string edtPostulacionesSuministrosDescri_Jsonclick ;
      private string edtPostulacionesFechaTrabajo_Jsonclick ;
      private string edtPostulacionesFechaCierre_Jsonclick ;
      private string edtPostulacionesHoraCierre_Jsonclick ;
      private string edtPostulacionesTipoFecha_Jsonclick ;
      private string edtPostulacionesRgoHoraservicio_Jsonclick ;
      private string edtPostulacionesApellidoNombre_Jsonclick ;
      private string edtPostulacionesMail_Jsonclick ;
      private string gxphoneLink ;
      private string edtPostulacionesTelefono_Jsonclick ;
      private string edtPostulacionesFechaAlta_Jsonclick ;
      private string cmbPostulacionesEstado_Jsonclick ;
      private string edtPostulacionesSecUserId_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A425PostulacionesFechaAlta ;
      private DateTime A947PostulacionesFechaTrabajo ;
      private DateTime A939PostulacionesFechaCierre ;
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
      private bool n942ServiciosId ;
      private bool A937PostulacionesReqSuministros ;
      private bool bGXsfl_26_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV13FilterFullText ;
      private string AV18GridAppliedFilters ;
      private string A940PostulacionesHoraCierre ;
      private string A941PostulacionesTipoFecha ;
      private string A951PostulacionesMail ;
      private string lV13FilterFullText ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private long aP0_InOutPostulacionesId ;
      private string aP1_InOutPostulacionesProveedorNombre ;
      private long aP2_InOutPostulacionesProveedorId ;
      private GXCheckbox chkPostulacionesReqSuministros ;
      private GXCombobox cmbPostulacionesEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private long[] H00KJ2_A948PostulacionesSecUserId ;
      private string[] H00KJ2_A424PostulacionesEstado ;
      private DateTime[] H00KJ2_A425PostulacionesFechaAlta ;
      private string[] H00KJ2_A952PostulacionesTelefono ;
      private string[] H00KJ2_A951PostulacionesMail ;
      private string[] H00KJ2_A950PostulacionesApellidoNombre ;
      private string[] H00KJ2_A949PostulacionesRgoHoraservicio ;
      private string[] H00KJ2_A941PostulacionesTipoFecha ;
      private string[] H00KJ2_A940PostulacionesHoraCierre ;
      private DateTime[] H00KJ2_A939PostulacionesFechaCierre ;
      private DateTime[] H00KJ2_A947PostulacionesFechaTrabajo ;
      private string[] H00KJ2_A938PostulacionesSuministrosDescri ;
      private bool[] H00KJ2_A937PostulacionesReqSuministros ;
      private string[] H00KJ2_A936PostulacionesDescripcion ;
      private short[] H00KJ2_A961PostulacionesMultimediaSerial ;
      private decimal[] H00KJ2_A946PostulacionesPrecio ;
      private string[] H00KJ2_A969PostulacionesProveedorNombre ;
      private long[] H00KJ2_A945PostulacionesProveedorId ;
      private string[] H00KJ2_A943ServiciosNombre ;
      private long[] H00KJ2_A942ServiciosId ;
      private bool[] H00KJ2_n942ServiciosId ;
      private long[] H00KJ2_A422PostulacionesId ;
      private long[] H00KJ3_A948PostulacionesSecUserId ;
      private string[] H00KJ3_A424PostulacionesEstado ;
      private DateTime[] H00KJ3_A425PostulacionesFechaAlta ;
      private string[] H00KJ3_A952PostulacionesTelefono ;
      private string[] H00KJ3_A951PostulacionesMail ;
      private string[] H00KJ3_A950PostulacionesApellidoNombre ;
      private string[] H00KJ3_A949PostulacionesRgoHoraservicio ;
      private string[] H00KJ3_A941PostulacionesTipoFecha ;
      private string[] H00KJ3_A940PostulacionesHoraCierre ;
      private DateTime[] H00KJ3_A939PostulacionesFechaCierre ;
      private DateTime[] H00KJ3_A947PostulacionesFechaTrabajo ;
      private string[] H00KJ3_A938PostulacionesSuministrosDescri ;
      private bool[] H00KJ3_A937PostulacionesReqSuministros ;
      private string[] H00KJ3_A936PostulacionesDescripcion ;
      private short[] H00KJ3_A961PostulacionesMultimediaSerial ;
      private decimal[] H00KJ3_A946PostulacionesPrecio ;
      private string[] H00KJ3_A969PostulacionesProveedorNombre ;
      private long[] H00KJ3_A945PostulacionesProveedorId ;
      private string[] H00KJ3_A943ServiciosNombre ;
      private long[] H00KJ3_A942ServiciosId ;
      private bool[] H00KJ3_n942ServiciosId ;
      private long[] H00KJ3_A422PostulacionesId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class postulacionesprompt__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00KJ2( IGxContext context ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV13FilterFullText ,
                                             long A422PostulacionesId ,
                                             long A942ServiciosId ,
                                             string A943ServiciosNombre ,
                                             long A945PostulacionesProveedorId ,
                                             string A969PostulacionesProveedorNombre ,
                                             decimal A946PostulacionesPrecio ,
                                             short A961PostulacionesMultimediaSerial ,
                                             string A936PostulacionesDescripcion ,
                                             string A938PostulacionesSuministrosDescri ,
                                             string A940PostulacionesHoraCierre ,
                                             string A941PostulacionesTipoFecha ,
                                             string A949PostulacionesRgoHoraservicio ,
                                             string A950PostulacionesApellidoNombre ,
                                             string A951PostulacionesMail ,
                                             string A952PostulacionesTelefono ,
                                             string A424PostulacionesEstado ,
                                             long A948PostulacionesSecUserId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesSecUserId], T1.[PostulacionesEstado], T1.[PostulacionesFechaAlta], T1.[PostulacionesTelefono], T1.[PostulacionesMail], T1.[PostulacionesApellidoNombre], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesTipoFecha], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T2.[ProveedorNombre] AS PostulacionesProveedorNombre, T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T3.[ServiciosNombre], T1.[ServiciosId], T1.[PostulacionesId] FROM (([Postulaciones] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[PostulacionesProveedorId]) LEFT JOIN [Servicios] T3 ON T3.[ServiciosId] = T1.[ServiciosId])";
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProveedorNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProveedorNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesProveedorId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesProveedorId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ServiciosId]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ServiciosId] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ServiciosNombre]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ServiciosNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesPrecio]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesPrecio] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMultimediaSerial]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMultimediaSerial] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesDescripcion]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesDescripcion] DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesReqSuministros]";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesReqSuministros] DESC";
         }
         else if ( ( AV11OrderedBy == 10 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSuministrosDescri]";
         }
         else if ( ( AV11OrderedBy == 10 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSuministrosDescri] DESC";
         }
         else if ( ( AV11OrderedBy == 11 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaTrabajo]";
         }
         else if ( ( AV11OrderedBy == 11 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaTrabajo] DESC";
         }
         else if ( ( AV11OrderedBy == 12 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaCierre]";
         }
         else if ( ( AV11OrderedBy == 12 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaCierre] DESC";
         }
         else if ( ( AV11OrderedBy == 13 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesHoraCierre]";
         }
         else if ( ( AV11OrderedBy == 13 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesHoraCierre] DESC";
         }
         else if ( ( AV11OrderedBy == 14 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTipoFecha]";
         }
         else if ( ( AV11OrderedBy == 14 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTipoFecha] DESC";
         }
         else if ( ( AV11OrderedBy == 15 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesRgoHoraservicio]";
         }
         else if ( ( AV11OrderedBy == 15 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesRgoHoraservicio] DESC";
         }
         else if ( ( AV11OrderedBy == 16 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesApellidoNombre]";
         }
         else if ( ( AV11OrderedBy == 16 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesApellidoNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 17 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMail]";
         }
         else if ( ( AV11OrderedBy == 17 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMail] DESC";
         }
         else if ( ( AV11OrderedBy == 18 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTelefono]";
         }
         else if ( ( AV11OrderedBy == 18 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTelefono] DESC";
         }
         else if ( ( AV11OrderedBy == 19 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaAlta]";
         }
         else if ( ( AV11OrderedBy == 19 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaAlta] DESC";
         }
         else if ( ( AV11OrderedBy == 20 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesEstado]";
         }
         else if ( ( AV11OrderedBy == 20 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesEstado] DESC";
         }
         else if ( ( AV11OrderedBy == 21 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSecUserId]";
         }
         else if ( ( AV11OrderedBy == 21 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSecUserId] DESC";
         }
         GXv_Object3[0] = scmdbuf;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H00KJ3( IGxContext context ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV13FilterFullText ,
                                             long A422PostulacionesId ,
                                             long A942ServiciosId ,
                                             string A943ServiciosNombre ,
                                             long A945PostulacionesProveedorId ,
                                             string A969PostulacionesProveedorNombre ,
                                             decimal A946PostulacionesPrecio ,
                                             short A961PostulacionesMultimediaSerial ,
                                             string A936PostulacionesDescripcion ,
                                             string A938PostulacionesSuministrosDescri ,
                                             string A940PostulacionesHoraCierre ,
                                             string A941PostulacionesTipoFecha ,
                                             string A949PostulacionesRgoHoraservicio ,
                                             string A950PostulacionesApellidoNombre ,
                                             string A951PostulacionesMail ,
                                             string A952PostulacionesTelefono ,
                                             string A424PostulacionesEstado ,
                                             long A948PostulacionesSecUserId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesSecUserId], T1.[PostulacionesEstado], T1.[PostulacionesFechaAlta], T1.[PostulacionesTelefono], T1.[PostulacionesMail], T1.[PostulacionesApellidoNombre], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesTipoFecha], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T2.[ProveedorNombre] AS PostulacionesProveedorNombre, T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T3.[ServiciosNombre], T1.[ServiciosId], T1.[PostulacionesId] FROM (([Postulaciones] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[PostulacionesProveedorId]) LEFT JOIN [Servicios] T3 ON T3.[ServiciosId] = T1.[ServiciosId])";
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProveedorNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProveedorNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesProveedorId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesProveedorId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ServiciosId]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ServiciosId] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ServiciosNombre]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ServiciosNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesPrecio]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesPrecio] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMultimediaSerial]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMultimediaSerial] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesDescripcion]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesDescripcion] DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesReqSuministros]";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesReqSuministros] DESC";
         }
         else if ( ( AV11OrderedBy == 10 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSuministrosDescri]";
         }
         else if ( ( AV11OrderedBy == 10 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSuministrosDescri] DESC";
         }
         else if ( ( AV11OrderedBy == 11 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaTrabajo]";
         }
         else if ( ( AV11OrderedBy == 11 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaTrabajo] DESC";
         }
         else if ( ( AV11OrderedBy == 12 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaCierre]";
         }
         else if ( ( AV11OrderedBy == 12 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaCierre] DESC";
         }
         else if ( ( AV11OrderedBy == 13 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesHoraCierre]";
         }
         else if ( ( AV11OrderedBy == 13 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesHoraCierre] DESC";
         }
         else if ( ( AV11OrderedBy == 14 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTipoFecha]";
         }
         else if ( ( AV11OrderedBy == 14 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTipoFecha] DESC";
         }
         else if ( ( AV11OrderedBy == 15 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesRgoHoraservicio]";
         }
         else if ( ( AV11OrderedBy == 15 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesRgoHoraservicio] DESC";
         }
         else if ( ( AV11OrderedBy == 16 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesApellidoNombre]";
         }
         else if ( ( AV11OrderedBy == 16 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesApellidoNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 17 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMail]";
         }
         else if ( ( AV11OrderedBy == 17 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMail] DESC";
         }
         else if ( ( AV11OrderedBy == 18 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTelefono]";
         }
         else if ( ( AV11OrderedBy == 18 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTelefono] DESC";
         }
         else if ( ( AV11OrderedBy == 19 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaAlta]";
         }
         else if ( ( AV11OrderedBy == 19 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaAlta] DESC";
         }
         else if ( ( AV11OrderedBy == 20 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesEstado]";
         }
         else if ( ( AV11OrderedBy == 20 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesEstado] DESC";
         }
         else if ( ( AV11OrderedBy == 21 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSecUserId]";
         }
         else if ( ( AV11OrderedBy == 21 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSecUserId] DESC";
         }
         GXv_Object4[0] = scmdbuf;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00KJ2(context, (short)dynConstraints[0] , (bool)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] );
               case 1 :
                     return conditional_H00KJ3(context, (short)dynConstraints[0] , (bool)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] );
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
          Object[] prmH00KJ2;
          prmH00KJ2 = new Object[] {
          };
          Object[] prmH00KJ3;
          prmH00KJ3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00KJ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00KJ2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00KJ3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00KJ3,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 250);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                ((string[]) buf[13])[0] = rslt.getString(14, 2000);
                ((short[]) buf[14])[0] = rslt.getShort(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                ((string[]) buf[16])[0] = rslt.getString(17, 80);
                ((long[]) buf[17])[0] = rslt.getLong(18);
                ((string[]) buf[18])[0] = rslt.getString(19, 80);
                ((long[]) buf[19])[0] = rslt.getLong(20);
                ((bool[]) buf[20])[0] = rslt.wasNull(20);
                ((long[]) buf[21])[0] = rslt.getLong(21);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 250);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                ((string[]) buf[13])[0] = rslt.getString(14, 2000);
                ((short[]) buf[14])[0] = rslt.getShort(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                ((string[]) buf[16])[0] = rslt.getString(17, 80);
                ((long[]) buf[17])[0] = rslt.getLong(18);
                ((string[]) buf[18])[0] = rslt.getString(19, 80);
                ((long[]) buf[19])[0] = rslt.getLong(20);
                ((bool[]) buf[20])[0] = rslt.wasNull(20);
                ((long[]) buf[21])[0] = rslt.getLong(21);
                return;
       }
    }

 }

}
