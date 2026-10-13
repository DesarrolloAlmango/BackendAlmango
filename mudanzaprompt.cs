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
   public class mudanzaprompt : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public mudanzaprompt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mudanzaprompt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_InOutMudanzaId ,
                           ref string aP1_InOutMudanzaAsesor )
      {
         this.AV8InOutMudanzaId = aP0_InOutMudanzaId;
         this.AV9InOutMudanzaAsesor = aP1_InOutMudanzaAsesor;
         ExecutePrivate();
         aP0_InOutMudanzaId=this.AV8InOutMudanzaId;
         aP1_InOutMudanzaAsesor=this.AV9InOutMudanzaAsesor;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbMudanzaHoraServicio = new GXCombobox();
         cmbMudanzaRgoHoraservicio = new GXCombobox();
         cmbMudanzaPisoDptoOrigen = new GXCombobox();
         cmbMudanzaVehiculoSugerido = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "InOutMudanzaId");
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
               gxfirstwebparm = GetFirstPar( "InOutMudanzaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "InOutMudanzaId");
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
               AV8InOutMudanzaId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8InOutMudanzaId", StringUtil.LTrimStr( (decimal)(AV8InOutMudanzaId), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9InOutMudanzaAsesor = GetPar( "InOutMudanzaAsesor");
                  AssignAttri("", false, "AV9InOutMudanzaAsesor", AV9InOutMudanzaAsesor);
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
         AV20Pgmname = GetPar( "Pgmname");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV20Pgmname) ;
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
         PAE62( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTE62( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("mudanzaprompt.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8InOutMudanzaId,18,0)),UrlEncode(StringUtil.RTrim(AV9InOutMudanzaAsesor))}, new string[] {"InOutMudanzaId","InOutMudanzaAsesor"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV20Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV20Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV12OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vINOUTMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8InOutMudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINOUTMUDANZAASESOR", AV9InOutMudanzaAsesor);
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
            WEE62( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTE62( ) ;
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
         return formatLink("mudanzaprompt.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8InOutMudanzaId,18,0)),UrlEncode(StringUtil.RTrim(AV9InOutMudanzaAsesor))}, new string[] {"InOutMudanzaId","InOutMudanzaAsesor"})  ;
      }

      public override string GetPgmname( )
      {
         return "MudanzaPrompt" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selecciona Mudanza", "") ;
      }

      protected void WBE60( )
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
            wb_table1_14_E62( true) ;
         }
         else
         {
            wb_table1_14_E62( false) ;
         }
         return  ;
      }

      protected void wb_table1_14_E62e( bool wbgen )
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

      protected void STARTE62( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selecciona Mudanza", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPE60( ) ;
      }

      protected void WSE62( )
      {
         STARTE62( ) ;
         EVTE62( ) ;
      }

      protected void EVTE62( )
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
                              E11E62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E12E62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E13E62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCLEANFILTERS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCleanFilters' */
                              E14E62 ();
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
                              A735MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMudanzaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A736MudanzaAsesor = cgiGet( edtMudanzaAsesor_Internalname);
                              A737MudanzaFechaAlta = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtMudanzaFechaAlta_Internalname), 0));
                              A738MudanzaFechaServicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtMudanzaFechaServicio_Internalname), 0));
                              cmbMudanzaHoraServicio.Name = cmbMudanzaHoraServicio_Internalname;
                              cmbMudanzaHoraServicio.CurrentValue = cgiGet( cmbMudanzaHoraServicio_Internalname);
                              A739MudanzaHoraServicio = cgiGet( cmbMudanzaHoraServicio_Internalname);
                              n739MudanzaHoraServicio = false;
                              cmbMudanzaRgoHoraservicio.Name = cmbMudanzaRgoHoraservicio_Internalname;
                              cmbMudanzaRgoHoraservicio.CurrentValue = cgiGet( cmbMudanzaRgoHoraservicio_Internalname);
                              A776MudanzaRgoHoraservicio = cgiGet( cmbMudanzaRgoHoraservicio_Internalname);
                              n776MudanzaRgoHoraservicio = false;
                              A740MudanzaDireccionOrigen = cgiGet( edtMudanzaDireccionOrigen_Internalname);
                              cmbMudanzaPisoDptoOrigen.Name = cmbMudanzaPisoDptoOrigen_Internalname;
                              cmbMudanzaPisoDptoOrigen.CurrentValue = cgiGet( cmbMudanzaPisoDptoOrigen_Internalname);
                              A777MudanzaPisoDptoOrigen = cgiGet( cmbMudanzaPisoDptoOrigen_Internalname);
                              A741MudanzaDireccionDestino = cgiGet( edtMudanzaDireccionDestino_Internalname);
                              A778MudanzaPisoDptoDestino = cgiGet( edtMudanzaPisoDptoDestino_Internalname);
                              A762MudanzaDistancia = context.localUtil.CToN( cgiGet( edtMudanzaDistancia_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              cmbMudanzaVehiculoSugerido.Name = cmbMudanzaVehiculoSugerido_Internalname;
                              cmbMudanzaVehiculoSugerido.CurrentValue = cgiGet( cmbMudanzaVehiculoSugerido_Internalname);
                              A742MudanzaVehiculoSugerido = cgiGet( cmbMudanzaVehiculoSugerido_Internalname);
                              A761MudanzaPeajeCantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMudanzaPeajeCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A760MudanzaPeajevalor = context.localUtil.CToN( cgiGet( edtMudanzaPeajevalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A743TipoInmuebleOrigenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoInmuebleOrigenId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A755TipoInmuebleOrigenNombre = cgiGet( edtTipoInmuebleOrigenNombre_Internalname);
                              A756TipoInmuebleOrigenValor = context.localUtil.CToN( cgiGet( edtTipoInmuebleOrigenValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E15E62 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E16E62 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E17E62 ();
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
                                          E18E62 ();
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

      protected void WEE62( )
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

      protected void PAE62( )
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
                                       string AV20Pgmname )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFE62( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MUDANZAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "MUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_MUDANZAASESOR", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A736MudanzaAsesor, "")), context));
         GxWebStd.gx_hidden_field( context, "MUDANZAASESOR", A736MudanzaAsesor);
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
         RFE62( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV20Pgmname = "MudanzaPrompt";
         edtavSelect_Enabled = 0;
      }

      protected void RFE62( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 26;
         /* Execute user event: Refresh */
         E16E62 ();
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
                                                 AV13FilterFullText ,
                                                 A735MudanzaId ,
                                                 A736MudanzaAsesor ,
                                                 A739MudanzaHoraServicio ,
                                                 A776MudanzaRgoHoraservicio ,
                                                 A740MudanzaDireccionOrigen ,
                                                 A777MudanzaPisoDptoOrigen ,
                                                 A741MudanzaDireccionDestino ,
                                                 A778MudanzaPisoDptoDestino ,
                                                 A762MudanzaDistancia ,
                                                 A742MudanzaVehiculoSugerido ,
                                                 A761MudanzaPeajeCantidad ,
                                                 A760MudanzaPeajevalor ,
                                                 A743TipoInmuebleOrigenId ,
                                                 A755TipoInmuebleOrigenNombre ,
                                                 A756TipoInmuebleOrigenValor ,
                                                 AV11OrderedBy ,
                                                 AV12OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
            /* Using cursor H00E62 */
            pr_default.execute(0, new Object[] {lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_26_idx = 1;
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A756TipoInmuebleOrigenValor = H00E62_A756TipoInmuebleOrigenValor[0];
               A755TipoInmuebleOrigenNombre = H00E62_A755TipoInmuebleOrigenNombre[0];
               A743TipoInmuebleOrigenId = H00E62_A743TipoInmuebleOrigenId[0];
               A760MudanzaPeajevalor = H00E62_A760MudanzaPeajevalor[0];
               A761MudanzaPeajeCantidad = H00E62_A761MudanzaPeajeCantidad[0];
               A742MudanzaVehiculoSugerido = H00E62_A742MudanzaVehiculoSugerido[0];
               A762MudanzaDistancia = H00E62_A762MudanzaDistancia[0];
               A778MudanzaPisoDptoDestino = H00E62_A778MudanzaPisoDptoDestino[0];
               A741MudanzaDireccionDestino = H00E62_A741MudanzaDireccionDestino[0];
               A777MudanzaPisoDptoOrigen = H00E62_A777MudanzaPisoDptoOrigen[0];
               A740MudanzaDireccionOrigen = H00E62_A740MudanzaDireccionOrigen[0];
               A776MudanzaRgoHoraservicio = H00E62_A776MudanzaRgoHoraservicio[0];
               n776MudanzaRgoHoraservicio = H00E62_n776MudanzaRgoHoraservicio[0];
               A739MudanzaHoraServicio = H00E62_A739MudanzaHoraServicio[0];
               n739MudanzaHoraServicio = H00E62_n739MudanzaHoraServicio[0];
               A738MudanzaFechaServicio = H00E62_A738MudanzaFechaServicio[0];
               A737MudanzaFechaAlta = H00E62_A737MudanzaFechaAlta[0];
               A736MudanzaAsesor = H00E62_A736MudanzaAsesor[0];
               A735MudanzaId = H00E62_A735MudanzaId[0];
               A756TipoInmuebleOrigenValor = H00E62_A756TipoInmuebleOrigenValor[0];
               A755TipoInmuebleOrigenNombre = H00E62_A755TipoInmuebleOrigenNombre[0];
               /* Execute user event: Grid.Load */
               E17E62 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 26;
            WBE60( ) ;
         }
         bGXsfl_26_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesE62( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV20Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_MUDANZAID"+"_"+sGXsfl_26_idx, GetSecureSignedToken( sGXsfl_26_idx, context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_MUDANZAASESOR"+"_"+sGXsfl_26_idx, GetSecureSignedToken( sGXsfl_26_idx, StringUtil.RTrim( context.localUtil.Format( A736MudanzaAsesor, "")), context));
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
                                              AV13FilterFullText ,
                                              A735MudanzaId ,
                                              A736MudanzaAsesor ,
                                              A739MudanzaHoraServicio ,
                                              A776MudanzaRgoHoraservicio ,
                                              A740MudanzaDireccionOrigen ,
                                              A777MudanzaPisoDptoOrigen ,
                                              A741MudanzaDireccionDestino ,
                                              A778MudanzaPisoDptoDestino ,
                                              A762MudanzaDistancia ,
                                              A742MudanzaVehiculoSugerido ,
                                              A761MudanzaPeajeCantidad ,
                                              A760MudanzaPeajevalor ,
                                              A743TipoInmuebleOrigenId ,
                                              A755TipoInmuebleOrigenNombre ,
                                              A756TipoInmuebleOrigenValor ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         lV13FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV13FilterFullText), "%", "");
         /* Using cursor H00E63 */
         pr_default.execute(1, new Object[] {lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText, lV13FilterFullText});
         GRID_nRecordCount = H00E63_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV20Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV20Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV20Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV20Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV20Pgmname) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV20Pgmname = "MudanzaPrompt";
         edtavSelect_Enabled = 0;
         edtMudanzaId_Enabled = 0;
         edtMudanzaAsesor_Enabled = 0;
         edtMudanzaFechaAlta_Enabled = 0;
         edtMudanzaFechaServicio_Enabled = 0;
         cmbMudanzaHoraServicio.Enabled = 0;
         cmbMudanzaRgoHoraservicio.Enabled = 0;
         edtMudanzaDireccionOrigen_Enabled = 0;
         cmbMudanzaPisoDptoOrigen.Enabled = 0;
         edtMudanzaDireccionDestino_Enabled = 0;
         edtMudanzaPisoDptoDestino_Enabled = 0;
         edtMudanzaDistancia_Enabled = 0;
         cmbMudanzaVehiculoSugerido.Enabled = 0;
         edtMudanzaPeajeCantidad_Enabled = 0;
         edtMudanzaPeajevalor_Enabled = 0;
         edtTipoInmuebleOrigenId_Enabled = 0;
         edtTipoInmuebleOrigenNombre_Enabled = 0;
         edtTipoInmuebleOrigenValor_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPE60( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15E62 ();
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
         E15E62 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E15E62( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( "Selecciona Mudanza", "");
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

      protected void E16E62( )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV20Pgmname, out  GXt_char2) ;
         AV18GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV18GridAppliedFilters", AV18GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E11E62( )
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

      protected void E12E62( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E13E62( )
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

      private void E17E62( )
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
         E18E62 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18E62( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV8InOutMudanzaId = A735MudanzaId;
         AssignAttri("", false, "AV8InOutMudanzaId", StringUtil.LTrimStr( (decimal)(AV8InOutMudanzaId), 18, 0));
         AV9InOutMudanzaAsesor = A736MudanzaAsesor;
         AssignAttri("", false, "AV9InOutMudanzaAsesor", AV9InOutMudanzaAsesor);
         context.setWebReturnParms(new Object[] {(long)AV8InOutMudanzaId,(string)AV9InOutMudanzaAsesor});
         context.setWebReturnParmsMetadata(new Object[] {"AV8InOutMudanzaId","AV9InOutMudanzaAsesor"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void E14E62( )
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

      protected void wb_table1_14_E62( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellAlignTop CellPaddingTop10'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCleanfilters_Internalname, context.GetMessage( "<i class=\"fas fa-filter CleanFiltersIcon\"></i>", ""), "", "", lblCleanfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOCLEANFILTERS\\'."+"'", "", "TextBlock", 5, context.GetMessage( "WWP_CleanFiltersTooltip", ""), 1, 1, 0, 1, "HLP_MudanzaPrompt.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_26_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV13FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_MudanzaPrompt.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_14_E62e( true) ;
         }
         else
         {
            wb_table1_14_E62e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8InOutMudanzaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV8InOutMudanzaId", StringUtil.LTrimStr( (decimal)(AV8InOutMudanzaId), 18, 0));
         AV9InOutMudanzaAsesor = (string)getParm(obj,1);
         AssignAttri("", false, "AV9InOutMudanzaAsesor", AV9InOutMudanzaAsesor);
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
         PAE62( ) ;
         WSE62( ) ;
         WEE62( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026862257638", true, true, false);
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
         context.AddJavascriptSource("mudanzaprompt.js", "?2026862257639", false, true, false);
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
         edtMudanzaId_Internalname = "MUDANZAID_"+sGXsfl_26_idx;
         edtMudanzaAsesor_Internalname = "MUDANZAASESOR_"+sGXsfl_26_idx;
         edtMudanzaFechaAlta_Internalname = "MUDANZAFECHAALTA_"+sGXsfl_26_idx;
         edtMudanzaFechaServicio_Internalname = "MUDANZAFECHASERVICIO_"+sGXsfl_26_idx;
         cmbMudanzaHoraServicio_Internalname = "MUDANZAHORASERVICIO_"+sGXsfl_26_idx;
         cmbMudanzaRgoHoraservicio_Internalname = "MUDANZARGOHORASERVICIO_"+sGXsfl_26_idx;
         edtMudanzaDireccionOrigen_Internalname = "MUDANZADIRECCIONORIGEN_"+sGXsfl_26_idx;
         cmbMudanzaPisoDptoOrigen_Internalname = "MUDANZAPISODPTOORIGEN_"+sGXsfl_26_idx;
         edtMudanzaDireccionDestino_Internalname = "MUDANZADIRECCIONDESTINO_"+sGXsfl_26_idx;
         edtMudanzaPisoDptoDestino_Internalname = "MUDANZAPISODPTODESTINO_"+sGXsfl_26_idx;
         edtMudanzaDistancia_Internalname = "MUDANZADISTANCIA_"+sGXsfl_26_idx;
         cmbMudanzaVehiculoSugerido_Internalname = "MUDANZAVEHICULOSUGERIDO_"+sGXsfl_26_idx;
         edtMudanzaPeajeCantidad_Internalname = "MUDANZAPEAJECANTIDAD_"+sGXsfl_26_idx;
         edtMudanzaPeajevalor_Internalname = "MUDANZAPEAJEVALOR_"+sGXsfl_26_idx;
         edtTipoInmuebleOrigenId_Internalname = "TIPOINMUEBLEORIGENID_"+sGXsfl_26_idx;
         edtTipoInmuebleOrigenNombre_Internalname = "TIPOINMUEBLEORIGENNOMBRE_"+sGXsfl_26_idx;
         edtTipoInmuebleOrigenValor_Internalname = "TIPOINMUEBLEORIGENVALOR_"+sGXsfl_26_idx;
      }

      protected void SubsflControlProps_fel_262( )
      {
         edtavSelect_Internalname = "vSELECT_"+sGXsfl_26_fel_idx;
         edtMudanzaId_Internalname = "MUDANZAID_"+sGXsfl_26_fel_idx;
         edtMudanzaAsesor_Internalname = "MUDANZAASESOR_"+sGXsfl_26_fel_idx;
         edtMudanzaFechaAlta_Internalname = "MUDANZAFECHAALTA_"+sGXsfl_26_fel_idx;
         edtMudanzaFechaServicio_Internalname = "MUDANZAFECHASERVICIO_"+sGXsfl_26_fel_idx;
         cmbMudanzaHoraServicio_Internalname = "MUDANZAHORASERVICIO_"+sGXsfl_26_fel_idx;
         cmbMudanzaRgoHoraservicio_Internalname = "MUDANZARGOHORASERVICIO_"+sGXsfl_26_fel_idx;
         edtMudanzaDireccionOrigen_Internalname = "MUDANZADIRECCIONORIGEN_"+sGXsfl_26_fel_idx;
         cmbMudanzaPisoDptoOrigen_Internalname = "MUDANZAPISODPTOORIGEN_"+sGXsfl_26_fel_idx;
         edtMudanzaDireccionDestino_Internalname = "MUDANZADIRECCIONDESTINO_"+sGXsfl_26_fel_idx;
         edtMudanzaPisoDptoDestino_Internalname = "MUDANZAPISODPTODESTINO_"+sGXsfl_26_fel_idx;
         edtMudanzaDistancia_Internalname = "MUDANZADISTANCIA_"+sGXsfl_26_fel_idx;
         cmbMudanzaVehiculoSugerido_Internalname = "MUDANZAVEHICULOSUGERIDO_"+sGXsfl_26_fel_idx;
         edtMudanzaPeajeCantidad_Internalname = "MUDANZAPEAJECANTIDAD_"+sGXsfl_26_fel_idx;
         edtMudanzaPeajevalor_Internalname = "MUDANZAPEAJEVALOR_"+sGXsfl_26_fel_idx;
         edtTipoInmuebleOrigenId_Internalname = "TIPOINMUEBLEORIGENID_"+sGXsfl_26_fel_idx;
         edtTipoInmuebleOrigenNombre_Internalname = "TIPOINMUEBLEORIGENNOMBRE_"+sGXsfl_26_fel_idx;
         edtTipoInmuebleOrigenValor_Internalname = "TIPOINMUEBLEORIGENVALOR_"+sGXsfl_26_fel_idx;
      }

      protected void sendrow_262( )
      {
         sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
         SubsflControlProps_262( ) ;
         WBE60( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaAsesor_Internalname,(string)A736MudanzaAsesor,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaAsesor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaFechaAlta_Internalname,context.localUtil.Format(A737MudanzaFechaAlta, "99/99/99"),context.localUtil.Format( A737MudanzaFechaAlta, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaFechaServicio_Internalname,context.localUtil.Format(A738MudanzaFechaServicio, "99/99/99"),context.localUtil.Format( A738MudanzaFechaServicio, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaFechaServicio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbMudanzaHoraServicio.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MUDANZAHORASERVICIO_" + sGXsfl_26_idx;
               cmbMudanzaHoraServicio.Name = GXCCtl;
               cmbMudanzaHoraServicio.WebTags = "";
               cmbMudanzaHoraServicio.addItem("08", "08:00", 0);
               cmbMudanzaHoraServicio.addItem("09", "09:00", 0);
               cmbMudanzaHoraServicio.addItem("10", "10:00", 0);
               cmbMudanzaHoraServicio.addItem("11", "11:00", 0);
               cmbMudanzaHoraServicio.addItem("12", "12:00", 0);
               cmbMudanzaHoraServicio.addItem("13", "13:00", 0);
               cmbMudanzaHoraServicio.addItem("14", "14:00", 0);
               cmbMudanzaHoraServicio.addItem("15", "15:00", 0);
               cmbMudanzaHoraServicio.addItem("16", "16:00", 0);
               cmbMudanzaHoraServicio.addItem("17", "17:00", 0);
               cmbMudanzaHoraServicio.addItem("18", "18:00", 0);
               cmbMudanzaHoraServicio.addItem("19", "19:00", 0);
               if ( cmbMudanzaHoraServicio.ItemCount > 0 )
               {
                  A739MudanzaHoraServicio = cmbMudanzaHoraServicio.getValidValue(A739MudanzaHoraServicio);
                  n739MudanzaHoraServicio = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMudanzaHoraServicio,(string)cmbMudanzaHoraServicio_Internalname,StringUtil.RTrim( A739MudanzaHoraServicio),(short)1,(string)cmbMudanzaHoraServicio_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbMudanzaHoraServicio.CurrentValue = StringUtil.RTrim( A739MudanzaHoraServicio);
            AssignProp("", false, cmbMudanzaHoraServicio_Internalname, "Values", (string)(cmbMudanzaHoraServicio.ToJavascriptSource()), !bGXsfl_26_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbMudanzaRgoHoraservicio.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MUDANZARGOHORASERVICIO_" + sGXsfl_26_idx;
               cmbMudanzaRgoHoraservicio.Name = GXCCtl;
               cmbMudanzaRgoHoraservicio.WebTags = "";
               cmbMudanzaRgoHoraservicio.addItem("08-12", "08:00 - 12:00", 0);
               cmbMudanzaRgoHoraservicio.addItem("12-16", "12:00 - 16:00", 0);
               cmbMudanzaRgoHoraservicio.addItem("16-20", "16:00 - 20:00", 0);
               if ( cmbMudanzaRgoHoraservicio.ItemCount > 0 )
               {
                  A776MudanzaRgoHoraservicio = cmbMudanzaRgoHoraservicio.getValidValue(A776MudanzaRgoHoraservicio);
                  n776MudanzaRgoHoraservicio = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMudanzaRgoHoraservicio,(string)cmbMudanzaRgoHoraservicio_Internalname,StringUtil.RTrim( A776MudanzaRgoHoraservicio),(short)1,(string)cmbMudanzaRgoHoraservicio_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbMudanzaRgoHoraservicio.CurrentValue = StringUtil.RTrim( A776MudanzaRgoHoraservicio);
            AssignProp("", false, cmbMudanzaRgoHoraservicio_Internalname, "Values", (string)(cmbMudanzaRgoHoraservicio.ToJavascriptSource()), !bGXsfl_26_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaDireccionOrigen_Internalname,(string)A740MudanzaDireccionOrigen,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaDireccionOrigen_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbMudanzaPisoDptoOrigen.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MUDANZAPISODPTOORIGEN_" + sGXsfl_26_idx;
               cmbMudanzaPisoDptoOrigen.Name = GXCCtl;
               cmbMudanzaPisoDptoOrigen.WebTags = "";
               if ( cmbMudanzaPisoDptoOrigen.ItemCount > 0 )
               {
                  A777MudanzaPisoDptoOrigen = cmbMudanzaPisoDptoOrigen.getValidValue(A777MudanzaPisoDptoOrigen);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMudanzaPisoDptoOrigen,(string)cmbMudanzaPisoDptoOrigen_Internalname,StringUtil.RTrim( A777MudanzaPisoDptoOrigen),(short)1,(string)cmbMudanzaPisoDptoOrigen_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbMudanzaPisoDptoOrigen.CurrentValue = StringUtil.RTrim( A777MudanzaPisoDptoOrigen);
            AssignProp("", false, cmbMudanzaPisoDptoOrigen_Internalname, "Values", (string)(cmbMudanzaPisoDptoOrigen.ToJavascriptSource()), !bGXsfl_26_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaDireccionDestino_Internalname,(string)A741MudanzaDireccionDestino,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaDireccionDestino_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaPisoDptoDestino_Internalname,StringUtil.RTrim( A778MudanzaPisoDptoDestino),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaPisoDptoDestino_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaDistancia_Internalname,StringUtil.LTrim( StringUtil.NToC( A762MudanzaDistancia, 10, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A762MudanzaDistancia, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaDistancia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbMudanzaVehiculoSugerido.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MUDANZAVEHICULOSUGERIDO_" + sGXsfl_26_idx;
               cmbMudanzaVehiculoSugerido.Name = GXCCtl;
               cmbMudanzaVehiculoSugerido.WebTags = "";
               if ( cmbMudanzaVehiculoSugerido.ItemCount > 0 )
               {
                  A742MudanzaVehiculoSugerido = cmbMudanzaVehiculoSugerido.getValidValue(A742MudanzaVehiculoSugerido);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMudanzaVehiculoSugerido,(string)cmbMudanzaVehiculoSugerido_Internalname,StringUtil.RTrim( A742MudanzaVehiculoSugerido),(short)1,(string)cmbMudanzaVehiculoSugerido_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbMudanzaVehiculoSugerido.CurrentValue = StringUtil.RTrim( A742MudanzaVehiculoSugerido);
            AssignProp("", false, cmbMudanzaVehiculoSugerido_Internalname, "Values", (string)(cmbMudanzaVehiculoSugerido.ToJavascriptSource()), !bGXsfl_26_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaPeajeCantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A761MudanzaPeajeCantidad), 1, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A761MudanzaPeajeCantidad), "9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaPeajeCantidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaPeajevalor_Internalname,StringUtil.LTrim( StringUtil.NToC( A760MudanzaPeajevalor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A760MudanzaPeajevalor, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaPeajevalor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"ParametroValor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoInmuebleOrigenId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A743TipoInmuebleOrigenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A743TipoInmuebleOrigenId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoInmuebleOrigenId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoInmuebleOrigenNombre_Internalname,(string)A755TipoInmuebleOrigenNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoInmuebleOrigenNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"ParametroNombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoInmuebleOrigenValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A756TipoInmuebleOrigenValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A756TipoInmuebleOrigenValor, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoInmuebleOrigenValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"ParametroValor",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesE62( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_26_idx = ((subGrid_Islastpage==1)&&(nGXsfl_26_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_26_idx+1);
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
         }
         /* End function sendrow_262 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "MUDANZAHORASERVICIO_" + sGXsfl_26_idx;
         cmbMudanzaHoraServicio.Name = GXCCtl;
         cmbMudanzaHoraServicio.WebTags = "";
         cmbMudanzaHoraServicio.addItem("08", "08:00", 0);
         cmbMudanzaHoraServicio.addItem("09", "09:00", 0);
         cmbMudanzaHoraServicio.addItem("10", "10:00", 0);
         cmbMudanzaHoraServicio.addItem("11", "11:00", 0);
         cmbMudanzaHoraServicio.addItem("12", "12:00", 0);
         cmbMudanzaHoraServicio.addItem("13", "13:00", 0);
         cmbMudanzaHoraServicio.addItem("14", "14:00", 0);
         cmbMudanzaHoraServicio.addItem("15", "15:00", 0);
         cmbMudanzaHoraServicio.addItem("16", "16:00", 0);
         cmbMudanzaHoraServicio.addItem("17", "17:00", 0);
         cmbMudanzaHoraServicio.addItem("18", "18:00", 0);
         cmbMudanzaHoraServicio.addItem("19", "19:00", 0);
         if ( cmbMudanzaHoraServicio.ItemCount > 0 )
         {
            A739MudanzaHoraServicio = cmbMudanzaHoraServicio.getValidValue(A739MudanzaHoraServicio);
            n739MudanzaHoraServicio = false;
         }
         GXCCtl = "MUDANZARGOHORASERVICIO_" + sGXsfl_26_idx;
         cmbMudanzaRgoHoraservicio.Name = GXCCtl;
         cmbMudanzaRgoHoraservicio.WebTags = "";
         cmbMudanzaRgoHoraservicio.addItem("08-12", "08:00 - 12:00", 0);
         cmbMudanzaRgoHoraservicio.addItem("12-16", "12:00 - 16:00", 0);
         cmbMudanzaRgoHoraservicio.addItem("16-20", "16:00 - 20:00", 0);
         if ( cmbMudanzaRgoHoraservicio.ItemCount > 0 )
         {
            A776MudanzaRgoHoraservicio = cmbMudanzaRgoHoraservicio.getValidValue(A776MudanzaRgoHoraservicio);
            n776MudanzaRgoHoraservicio = false;
         }
         GXCCtl = "MUDANZAPISODPTOORIGEN_" + sGXsfl_26_idx;
         cmbMudanzaPisoDptoOrigen.Name = GXCCtl;
         cmbMudanzaPisoDptoOrigen.WebTags = "";
         if ( cmbMudanzaPisoDptoOrigen.ItemCount > 0 )
         {
            A777MudanzaPisoDptoOrigen = cmbMudanzaPisoDptoOrigen.getValidValue(A777MudanzaPisoDptoOrigen);
         }
         GXCCtl = "MUDANZAVEHICULOSUGERIDO_" + sGXsfl_26_idx;
         cmbMudanzaVehiculoSugerido.Name = GXCCtl;
         cmbMudanzaVehiculoSugerido.WebTags = "";
         if ( cmbMudanzaVehiculoSugerido.ItemCount > 0 )
         {
            A742MudanzaVehiculoSugerido = cmbMudanzaVehiculoSugerido.getValidValue(A742MudanzaVehiculoSugerido);
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
            context.SendWebValue( context.GetMessage( "Asesor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Servicio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Hora Servicio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rgo Horaservicio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Direccion Origen", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Dpto Origen", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Direccion Destino", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Dpto Destino", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Distancia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Vehiculo Sugerido", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Peaje Cantidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Peajevalor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Origen Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Origen Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Origen Valor", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A736MudanzaAsesor));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A737MudanzaFechaAlta, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A738MudanzaFechaServicio, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A739MudanzaHoraServicio)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A776MudanzaRgoHoraservicio)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A740MudanzaDireccionOrigen));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A777MudanzaPisoDptoOrigen)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A741MudanzaDireccionDestino));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A778MudanzaPisoDptoDestino)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A762MudanzaDistancia, 10, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A742MudanzaVehiculoSugerido));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A761MudanzaPeajeCantidad), 1, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A760MudanzaPeajevalor, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A743TipoInmuebleOrigenId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A755TipoInmuebleOrigenNombre));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A756TipoInmuebleOrigenValor, 18, 2, ".", ""))));
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
         edtMudanzaId_Internalname = "MUDANZAID";
         edtMudanzaAsesor_Internalname = "MUDANZAASESOR";
         edtMudanzaFechaAlta_Internalname = "MUDANZAFECHAALTA";
         edtMudanzaFechaServicio_Internalname = "MUDANZAFECHASERVICIO";
         cmbMudanzaHoraServicio_Internalname = "MUDANZAHORASERVICIO";
         cmbMudanzaRgoHoraservicio_Internalname = "MUDANZARGOHORASERVICIO";
         edtMudanzaDireccionOrigen_Internalname = "MUDANZADIRECCIONORIGEN";
         cmbMudanzaPisoDptoOrigen_Internalname = "MUDANZAPISODPTOORIGEN";
         edtMudanzaDireccionDestino_Internalname = "MUDANZADIRECCIONDESTINO";
         edtMudanzaPisoDptoDestino_Internalname = "MUDANZAPISODPTODESTINO";
         edtMudanzaDistancia_Internalname = "MUDANZADISTANCIA";
         cmbMudanzaVehiculoSugerido_Internalname = "MUDANZAVEHICULOSUGERIDO";
         edtMudanzaPeajeCantidad_Internalname = "MUDANZAPEAJECANTIDAD";
         edtMudanzaPeajevalor_Internalname = "MUDANZAPEAJEVALOR";
         edtTipoInmuebleOrigenId_Internalname = "TIPOINMUEBLEORIGENID";
         edtTipoInmuebleOrigenNombre_Internalname = "TIPOINMUEBLEORIGENNOMBRE";
         edtTipoInmuebleOrigenValor_Internalname = "TIPOINMUEBLEORIGENVALOR";
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
         edtTipoInmuebleOrigenValor_Jsonclick = "";
         edtTipoInmuebleOrigenNombre_Jsonclick = "";
         edtTipoInmuebleOrigenId_Jsonclick = "";
         edtMudanzaPeajevalor_Jsonclick = "";
         edtMudanzaPeajeCantidad_Jsonclick = "";
         cmbMudanzaVehiculoSugerido_Jsonclick = "";
         edtMudanzaDistancia_Jsonclick = "";
         edtMudanzaPisoDptoDestino_Jsonclick = "";
         edtMudanzaDireccionDestino_Jsonclick = "";
         cmbMudanzaPisoDptoOrigen_Jsonclick = "";
         edtMudanzaDireccionOrigen_Jsonclick = "";
         cmbMudanzaRgoHoraservicio_Jsonclick = "";
         cmbMudanzaHoraServicio_Jsonclick = "";
         edtMudanzaFechaServicio_Jsonclick = "";
         edtMudanzaFechaAlta_Jsonclick = "";
         edtMudanzaAsesor_Jsonclick = "";
         edtMudanzaId_Jsonclick = "";
         edtavSelect_Jsonclick = "";
         edtavSelect_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtTipoInmuebleOrigenValor_Enabled = 0;
         edtTipoInmuebleOrigenNombre_Enabled = 0;
         edtTipoInmuebleOrigenId_Enabled = 0;
         edtMudanzaPeajevalor_Enabled = 0;
         edtMudanzaPeajeCantidad_Enabled = 0;
         cmbMudanzaVehiculoSugerido.Enabled = 0;
         edtMudanzaDistancia_Enabled = 0;
         edtMudanzaPisoDptoDestino_Enabled = 0;
         edtMudanzaDireccionDestino_Enabled = 0;
         cmbMudanzaPisoDptoOrigen.Enabled = 0;
         edtMudanzaDireccionOrigen_Enabled = 0;
         cmbMudanzaRgoHoraservicio.Enabled = 0;
         cmbMudanzaHoraServicio.Enabled = 0;
         edtMudanzaFechaServicio_Enabled = 0;
         edtMudanzaFechaAlta_Enabled = 0;
         edtMudanzaAsesor_Enabled = 0;
         edtMudanzaId_Enabled = 0;
         subGrid_Sortable = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17";
         Ddo_grid_Columnids = "1:MudanzaId|2:MudanzaAsesor|3:MudanzaFechaAlta|4:MudanzaFechaServicio|5:MudanzaHoraServicio|6:MudanzaRgoHoraservicio|7:MudanzaDireccionOrigen|8:MudanzaPisoDptoOrigen|9:MudanzaDireccionDestino|10:MudanzaPisoDptoDestino|11:MudanzaDistancia|12:MudanzaVehiculoSugerido|13:MudanzaPeajeCantidad|14:MudanzaPeajevalor|15:TipoInmuebleOrigenId|16:TipoInmuebleOrigenNombre|17:TipoInmuebleOrigenValor";
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
         Form.Caption = context.GetMessage( "Selecciona Mudanza", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV16GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV17GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV18GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11E62',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV16GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV17GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV18GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12E62',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E13E62',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E17E62',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV19Select',fld:'vSELECT',pic:'',type:'char'}]}");
         setEventMetadata("ENTER","{handler:'E18E62',iparms:[{av:'A735MudanzaId',fld:'MUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A736MudanzaAsesor',fld:'MUDANZAASESOR',pic:'',hsh:true,type:'svchar'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV8InOutMudanzaId',fld:'vINOUTMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9InOutMudanzaAsesor',fld:'vINOUTMUDANZAASESOR',pic:'',type:'svchar'}]}");
         setEventMetadata("'DOCLEANFILTERS'","{handler:'E14E62',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("'DOCLEANFILTERS'",",oparms:[{av:'AV13FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'}]}");
         setEventMetadata("VALID_TIPOINMUEBLEORIGENID","{handler:'Valid_Tipoinmuebleorigenid',iparms:[]");
         setEventMetadata("VALID_TIPOINMUEBLEORIGENID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Tipoinmuebleorigenvalor',iparms:[]");
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
         wcpOAV9InOutMudanzaAsesor = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV13FilterFullText = "";
         AV20Pgmname = "";
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
         A736MudanzaAsesor = "";
         A737MudanzaFechaAlta = DateTime.MinValue;
         A738MudanzaFechaServicio = DateTime.MinValue;
         A739MudanzaHoraServicio = "";
         A776MudanzaRgoHoraservicio = "";
         A740MudanzaDireccionOrigen = "";
         A777MudanzaPisoDptoOrigen = "";
         A741MudanzaDireccionDestino = "";
         A778MudanzaPisoDptoDestino = "";
         A742MudanzaVehiculoSugerido = "";
         A755TipoInmuebleOrigenNombre = "";
         lV13FilterFullText = "";
         H00E62_A756TipoInmuebleOrigenValor = new decimal[1] ;
         H00E62_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         H00E62_A743TipoInmuebleOrigenId = new short[1] ;
         H00E62_A760MudanzaPeajevalor = new decimal[1] ;
         H00E62_A761MudanzaPeajeCantidad = new short[1] ;
         H00E62_A742MudanzaVehiculoSugerido = new string[] {""} ;
         H00E62_A762MudanzaDistancia = new decimal[1] ;
         H00E62_A778MudanzaPisoDptoDestino = new string[] {""} ;
         H00E62_A741MudanzaDireccionDestino = new string[] {""} ;
         H00E62_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         H00E62_A740MudanzaDireccionOrigen = new string[] {""} ;
         H00E62_A776MudanzaRgoHoraservicio = new string[] {""} ;
         H00E62_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         H00E62_A739MudanzaHoraServicio = new string[] {""} ;
         H00E62_n739MudanzaHoraServicio = new bool[] {false} ;
         H00E62_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         H00E62_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00E62_A736MudanzaAsesor = new string[] {""} ;
         H00E62_A735MudanzaId = new long[1] ;
         H00E63_AGRID_nRecordCount = new long[1] ;
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mudanzaprompt__default(),
            new Object[][] {
                new Object[] {
               H00E62_A756TipoInmuebleOrigenValor, H00E62_A755TipoInmuebleOrigenNombre, H00E62_A743TipoInmuebleOrigenId, H00E62_A760MudanzaPeajevalor, H00E62_A761MudanzaPeajeCantidad, H00E62_A742MudanzaVehiculoSugerido, H00E62_A762MudanzaDistancia, H00E62_A778MudanzaPisoDptoDestino, H00E62_A741MudanzaDireccionDestino, H00E62_A777MudanzaPisoDptoOrigen,
               H00E62_A740MudanzaDireccionOrigen, H00E62_A776MudanzaRgoHoraservicio, H00E62_n776MudanzaRgoHoraservicio, H00E62_A739MudanzaHoraServicio, H00E62_n739MudanzaHoraServicio, H00E62_A738MudanzaFechaServicio, H00E62_A737MudanzaFechaAlta, H00E62_A736MudanzaAsesor, H00E62_A735MudanzaId
               }
               , new Object[] {
               H00E63_AGRID_nRecordCount
               }
            }
         );
         AV20Pgmname = "MudanzaPrompt";
         /* GeneXus formulas. */
         AV20Pgmname = "MudanzaPrompt";
         edtavSelect_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV11OrderedBy ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A761MudanzaPeajeCantidad ;
      private short A743TipoInmuebleOrigenId ;
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
      private int edtMudanzaId_Enabled ;
      private int edtMudanzaAsesor_Enabled ;
      private int edtMudanzaFechaAlta_Enabled ;
      private int edtMudanzaFechaServicio_Enabled ;
      private int edtMudanzaDireccionOrigen_Enabled ;
      private int edtMudanzaDireccionDestino_Enabled ;
      private int edtMudanzaPisoDptoDestino_Enabled ;
      private int edtMudanzaDistancia_Enabled ;
      private int edtMudanzaPeajeCantidad_Enabled ;
      private int edtMudanzaPeajevalor_Enabled ;
      private int edtTipoInmuebleOrigenId_Enabled ;
      private int edtTipoInmuebleOrigenNombre_Enabled ;
      private int edtTipoInmuebleOrigenValor_Enabled ;
      private int AV15PageToGo ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8InOutMudanzaId ;
      private long wcpOAV8InOutMudanzaId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV16GridCurrentPage ;
      private long AV17GridPageCount ;
      private long A735MudanzaId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A762MudanzaDistancia ;
      private decimal A760MudanzaPeajevalor ;
      private decimal A756TipoInmuebleOrigenValor ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_26_idx="0001" ;
      private string AV20Pgmname ;
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
      private string edtMudanzaId_Internalname ;
      private string edtMudanzaAsesor_Internalname ;
      private string edtMudanzaFechaAlta_Internalname ;
      private string edtMudanzaFechaServicio_Internalname ;
      private string cmbMudanzaHoraServicio_Internalname ;
      private string A739MudanzaHoraServicio ;
      private string cmbMudanzaRgoHoraservicio_Internalname ;
      private string A776MudanzaRgoHoraservicio ;
      private string edtMudanzaDireccionOrigen_Internalname ;
      private string cmbMudanzaPisoDptoOrigen_Internalname ;
      private string A777MudanzaPisoDptoOrigen ;
      private string edtMudanzaDireccionDestino_Internalname ;
      private string A778MudanzaPisoDptoDestino ;
      private string edtMudanzaPisoDptoDestino_Internalname ;
      private string edtMudanzaDistancia_Internalname ;
      private string cmbMudanzaVehiculoSugerido_Internalname ;
      private string edtMudanzaPeajeCantidad_Internalname ;
      private string edtMudanzaPeajevalor_Internalname ;
      private string edtTipoInmuebleOrigenId_Internalname ;
      private string edtTipoInmuebleOrigenNombre_Internalname ;
      private string edtTipoInmuebleOrigenValor_Internalname ;
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
      private string edtMudanzaId_Jsonclick ;
      private string edtMudanzaAsesor_Jsonclick ;
      private string edtMudanzaFechaAlta_Jsonclick ;
      private string edtMudanzaFechaServicio_Jsonclick ;
      private string GXCCtl ;
      private string cmbMudanzaHoraServicio_Jsonclick ;
      private string cmbMudanzaRgoHoraservicio_Jsonclick ;
      private string edtMudanzaDireccionOrigen_Jsonclick ;
      private string cmbMudanzaPisoDptoOrigen_Jsonclick ;
      private string edtMudanzaDireccionDestino_Jsonclick ;
      private string edtMudanzaPisoDptoDestino_Jsonclick ;
      private string edtMudanzaDistancia_Jsonclick ;
      private string cmbMudanzaVehiculoSugerido_Jsonclick ;
      private string edtMudanzaPeajeCantidad_Jsonclick ;
      private string edtMudanzaPeajevalor_Jsonclick ;
      private string edtTipoInmuebleOrigenId_Jsonclick ;
      private string edtTipoInmuebleOrigenNombre_Jsonclick ;
      private string edtTipoInmuebleOrigenValor_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A737MudanzaFechaAlta ;
      private DateTime A738MudanzaFechaServicio ;
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
      private bool n739MudanzaHoraServicio ;
      private bool n776MudanzaRgoHoraservicio ;
      private bool bGXsfl_26_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV9InOutMudanzaAsesor ;
      private string wcpOAV9InOutMudanzaAsesor ;
      private string AV13FilterFullText ;
      private string AV18GridAppliedFilters ;
      private string A736MudanzaAsesor ;
      private string A740MudanzaDireccionOrigen ;
      private string A741MudanzaDireccionDestino ;
      private string A742MudanzaVehiculoSugerido ;
      private string A755TipoInmuebleOrigenNombre ;
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
      private long aP0_InOutMudanzaId ;
      private string aP1_InOutMudanzaAsesor ;
      private GXCombobox cmbMudanzaHoraServicio ;
      private GXCombobox cmbMudanzaRgoHoraservicio ;
      private GXCombobox cmbMudanzaPisoDptoOrigen ;
      private GXCombobox cmbMudanzaVehiculoSugerido ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private decimal[] H00E62_A756TipoInmuebleOrigenValor ;
      private string[] H00E62_A755TipoInmuebleOrigenNombre ;
      private short[] H00E62_A743TipoInmuebleOrigenId ;
      private decimal[] H00E62_A760MudanzaPeajevalor ;
      private short[] H00E62_A761MudanzaPeajeCantidad ;
      private string[] H00E62_A742MudanzaVehiculoSugerido ;
      private decimal[] H00E62_A762MudanzaDistancia ;
      private string[] H00E62_A778MudanzaPisoDptoDestino ;
      private string[] H00E62_A741MudanzaDireccionDestino ;
      private string[] H00E62_A777MudanzaPisoDptoOrigen ;
      private string[] H00E62_A740MudanzaDireccionOrigen ;
      private string[] H00E62_A776MudanzaRgoHoraservicio ;
      private bool[] H00E62_n776MudanzaRgoHoraservicio ;
      private string[] H00E62_A739MudanzaHoraServicio ;
      private bool[] H00E62_n739MudanzaHoraServicio ;
      private DateTime[] H00E62_A738MudanzaFechaServicio ;
      private DateTime[] H00E62_A737MudanzaFechaAlta ;
      private string[] H00E62_A736MudanzaAsesor ;
      private long[] H00E62_A735MudanzaId ;
      private long[] H00E63_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class mudanzaprompt__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00E62( IGxContext context ,
                                             string AV13FilterFullText ,
                                             long A735MudanzaId ,
                                             string A736MudanzaAsesor ,
                                             string A739MudanzaHoraServicio ,
                                             string A776MudanzaRgoHoraservicio ,
                                             string A740MudanzaDireccionOrigen ,
                                             string A777MudanzaPisoDptoOrigen ,
                                             string A741MudanzaDireccionDestino ,
                                             string A778MudanzaPisoDptoDestino ,
                                             decimal A762MudanzaDistancia ,
                                             string A742MudanzaVehiculoSugerido ,
                                             short A761MudanzaPeajeCantidad ,
                                             decimal A760MudanzaPeajevalor ,
                                             short A743TipoInmuebleOrigenId ,
                                             string A755TipoInmuebleOrigenNombre ,
                                             decimal A756TipoInmuebleOrigenValor ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[31];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.[ParametroMudanzaValor] AS TipoInmuebleOrigenValor, T2.[ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, T1.[TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, T1.[MudanzaPeajevalor], T1.[MudanzaPeajeCantidad], T1.[MudanzaVehiculoSugerido], T1.[MudanzaDistancia], T1.[MudanzaPisoDptoDestino], T1.[MudanzaDireccionDestino], T1.[MudanzaPisoDptoOrigen], T1.[MudanzaDireccionOrigen], T1.[MudanzaRgoHoraservicio], T1.[MudanzaHoraServicio], T1.[MudanzaFechaServicio], T1.[MudanzaFechaAlta], T1.[MudanzaAsesor], T1.[MudanzaId]";
         sFromString = " FROM ([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleOrigenId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[MudanzaId] AS decimal(18,0))) like '%' + @lV13FilterFullText) or ( UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV13FilterFullText)) or ( '08:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '08') or ( '09:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '09') or ( '10:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '10') or ( '11:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '11') or ( '12:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '12') or ( '13:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '13') or ( '14:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '14') or ( '15:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '15') or ( '16:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '16') or ( '17:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '17') or ( '18:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '18') or ( '19:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '19') or ( '08:00 - 12:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaRgoHoraservicio] = '08-12') or ( '12:00 - 16:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaRgoHoraservicio] = '12-16') or ( '16:00 - 20:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaRgoHoraservicio] = '16-20') or ( UPPER(T1.[MudanzaDireccionOrigen]) like '%' + UPPER(@lV13FilterFullText)) or ( UPPER(T1.[MudanzaPisoDptoOrigen]) like '%' + UPPER(@lV13FilterFullText)) or ( UPPER(T1.[MudanzaDireccionDestino]) like '%' + UPPER(@lV13FilterFullText)) or ( UPPER(T1.[MudanzaPisoDptoDestino]) like '%' + UPPER(@lV13FilterFullText)) or ( CONVERT( char(10), CAST(T1.[MudanzaDistancia] AS decimal(10,2))) like '%' + @lV13FilterFullText) or ( UPPER(T1.[MudanzaVehiculoSugerido]) like '%' + UPPER(@lV13FilterFullText)) or ( CONVERT( char(1), CAST(T1.[MudanzaPeajeCantidad] AS decimal(1,0))) like '%' + @lV13FilterFullText) or ( CONVERT( char(18), CAST(T1.[MudanzaPeajevalor] AS decimal(18,2))) like '%' + @lV13FilterFullText) or ( CONVERT( char(4), CAST(T1.[TipoInmuebleOrigenId] AS decimal(4,0))) like '%' + @lV13FilterFullText) or ( UPPER(T2.[ParametroMudanzaNombre]) like '%' + UPPER(@lV13FilterFullText)) or ( CONVERT( char(18), CAST(T2.[ParametroMudanzaValor] AS decimal(18,2))) like '%' + @lV13FilterFullText))");
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
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
            GXv_int3[9] = 1;
            GXv_int3[10] = 1;
            GXv_int3[11] = 1;
            GXv_int3[12] = 1;
            GXv_int3[13] = 1;
            GXv_int3[14] = 1;
            GXv_int3[15] = 1;
            GXv_int3[16] = 1;
            GXv_int3[17] = 1;
            GXv_int3[18] = 1;
            GXv_int3[19] = 1;
            GXv_int3[20] = 1;
            GXv_int3[21] = 1;
            GXv_int3[22] = 1;
            GXv_int3[23] = 1;
            GXv_int3[24] = 1;
            GXv_int3[25] = 1;
            GXv_int3[26] = 1;
            GXv_int3[27] = 1;
         }
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaAsesor]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaAsesor] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaFechaAlta]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaFechaAlta] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaFechaServicio]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaFechaServicio] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaHoraServicio]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaHoraServicio] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaRgoHoraservicio]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaRgoHoraservicio] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaDireccionOrigen]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaDireccionOrigen] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaPisoDptoOrigen]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaPisoDptoOrigen] DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaDireccionDestino]";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaDireccionDestino] DESC";
         }
         else if ( ( AV11OrderedBy == 10 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaPisoDptoDestino]";
         }
         else if ( ( AV11OrderedBy == 10 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaPisoDptoDestino] DESC";
         }
         else if ( ( AV11OrderedBy == 11 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaDistancia]";
         }
         else if ( ( AV11OrderedBy == 11 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaDistancia] DESC";
         }
         else if ( ( AV11OrderedBy == 12 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaVehiculoSugerido]";
         }
         else if ( ( AV11OrderedBy == 12 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaVehiculoSugerido] DESC";
         }
         else if ( ( AV11OrderedBy == 13 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaPeajeCantidad]";
         }
         else if ( ( AV11OrderedBy == 13 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaPeajeCantidad] DESC";
         }
         else if ( ( AV11OrderedBy == 14 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaPeajevalor]";
         }
         else if ( ( AV11OrderedBy == 14 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaPeajevalor] DESC";
         }
         else if ( ( AV11OrderedBy == 15 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[TipoInmuebleOrigenId]";
         }
         else if ( ( AV11OrderedBy == 15 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[TipoInmuebleOrigenId] DESC";
         }
         else if ( ( AV11OrderedBy == 16 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[ParametroMudanzaNombre]";
         }
         else if ( ( AV11OrderedBy == 16 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[ParametroMudanzaNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 17 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[ParametroMudanzaValor]";
         }
         else if ( ( AV11OrderedBy == 17 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[ParametroMudanzaValor] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[MudanzaId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H00E63( IGxContext context ,
                                             string AV13FilterFullText ,
                                             long A735MudanzaId ,
                                             string A736MudanzaAsesor ,
                                             string A739MudanzaHoraServicio ,
                                             string A776MudanzaRgoHoraservicio ,
                                             string A740MudanzaDireccionOrigen ,
                                             string A777MudanzaPisoDptoOrigen ,
                                             string A741MudanzaDireccionDestino ,
                                             string A778MudanzaPisoDptoDestino ,
                                             decimal A762MudanzaDistancia ,
                                             string A742MudanzaVehiculoSugerido ,
                                             short A761MudanzaPeajeCantidad ,
                                             decimal A760MudanzaPeajevalor ,
                                             short A743TipoInmuebleOrigenId ,
                                             string A755TipoInmuebleOrigenNombre ,
                                             decimal A756TipoInmuebleOrigenValor ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[28];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleOrigenId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[MudanzaId] AS decimal(18,0))) like '%' + @lV13FilterFullText) or ( UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV13FilterFullText)) or ( '08:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '08') or ( '09:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '09') or ( '10:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '10') or ( '11:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '11') or ( '12:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '12') or ( '13:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '13') or ( '14:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '14') or ( '15:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '15') or ( '16:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '16') or ( '17:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '17') or ( '18:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '18') or ( '19:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaHoraServicio] = '19') or ( '08:00 - 12:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaRgoHoraservicio] = '08-12') or ( '12:00 - 16:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaRgoHoraservicio] = '12-16') or ( '16:00 - 20:00' like '%' + LOWER(@lV13FilterFullText) and T1.[MudanzaRgoHoraservicio] = '16-20') or ( UPPER(T1.[MudanzaDireccionOrigen]) like '%' + UPPER(@lV13FilterFullText)) or ( UPPER(T1.[MudanzaPisoDptoOrigen]) like '%' + UPPER(@lV13FilterFullText)) or ( UPPER(T1.[MudanzaDireccionDestino]) like '%' + UPPER(@lV13FilterFullText)) or ( UPPER(T1.[MudanzaPisoDptoDestino]) like '%' + UPPER(@lV13FilterFullText)) or ( CONVERT( char(10), CAST(T1.[MudanzaDistancia] AS decimal(10,2))) like '%' + @lV13FilterFullText) or ( UPPER(T1.[MudanzaVehiculoSugerido]) like '%' + UPPER(@lV13FilterFullText)) or ( CONVERT( char(1), CAST(T1.[MudanzaPeajeCantidad] AS decimal(1,0))) like '%' + @lV13FilterFullText) or ( CONVERT( char(18), CAST(T1.[MudanzaPeajevalor] AS decimal(18,2))) like '%' + @lV13FilterFullText) or ( CONVERT( char(4), CAST(T1.[TipoInmuebleOrigenId] AS decimal(4,0))) like '%' + @lV13FilterFullText) or ( UPPER(T2.[ParametroMudanzaNombre]) like '%' + UPPER(@lV13FilterFullText)) or ( CONVERT( char(18), CAST(T2.[ParametroMudanzaValor] AS decimal(18,2))) like '%' + @lV13FilterFullText))");
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
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
            GXv_int5[10] = 1;
            GXv_int5[11] = 1;
            GXv_int5[12] = 1;
            GXv_int5[13] = 1;
            GXv_int5[14] = 1;
            GXv_int5[15] = 1;
            GXv_int5[16] = 1;
            GXv_int5[17] = 1;
            GXv_int5[18] = 1;
            GXv_int5[19] = 1;
            GXv_int5[20] = 1;
            GXv_int5[21] = 1;
            GXv_int5[22] = 1;
            GXv_int5[23] = 1;
            GXv_int5[24] = 1;
            GXv_int5[25] = 1;
            GXv_int5[26] = 1;
            GXv_int5[27] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 10 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 10 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 11 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 11 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 12 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 12 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 13 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 13 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 14 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 14 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 15 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 15 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 16 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 16 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 17 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 17 ) && ( AV12OrderedDsc ) )
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
                     return conditional_H00E62(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (decimal)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
               case 1 :
                     return conditional_H00E63(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (decimal)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
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
          Object[] prmH00E62;
          prmH00E62 = new Object[] {
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00E63;
          prmH00E63 = new Object[] {
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV13FilterFullText",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00E62", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00E62,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00E63", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00E63,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 30);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 30);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 5);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                ((string[]) buf[13])[0] = rslt.getString(13, 2);
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(14);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(15);
                ((string[]) buf[17])[0] = rslt.getVarchar(16);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
