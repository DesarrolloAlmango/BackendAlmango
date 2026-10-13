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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secrolefunroleassociationww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public secrolefunroleassociationww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secrolefunroleassociationww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SecRoleId )
      {
         this.AV9SecRoleId = aP0_SecRoleId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavIsassociated = new GXCheckbox();
         chkavIsassociatedold = new GXCheckbox();
         cmbSecFunctionalityType = new GXCombobox();
         chkSecFunctionalityActive = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "SecRoleId");
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
               gxfirstwebparm = GetFirstPar( "SecRoleId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "SecRoleId");
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_23 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_23"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_23_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_23_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_23_idx = GetPar( "sGXsfl_23_idx");
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
         AV38OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV39OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV84FilterFullText = GetPar( "FilterFullText");
         AV87ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV89Pgmname = GetPar( "Pgmname");
         AV60TFSecFunctionalityKey = GetPar( "TFSecFunctionalityKey");
         AV61TFSecFunctionalityKey_Sel = GetPar( "TFSecFunctionalityKey_Sel");
         AV13SecFunctionalityIdRemovedXml = GetPar( "SecFunctionalityIdRemovedXml");
         AV12SecFunctionalityIdAddedXml = GetPar( "SecFunctionalityIdAddedXml");
         AV9SecRoleId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleId"), "."), 18, MidpointRounding.ToEven));
         A16SecRoleId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleId"), "."), 18, MidpointRounding.ToEven));
         AV21i = (long)(Math.Round(NumberUtil.Val( GetPar( "i"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11SecFunctionalityIdRemoved);
         AV15SecFunctionalityIdToFind = (long)(Math.Round(NumberUtil.Val( GetPar( "SecFunctionalityIdToFind"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10SecFunctionalityIdAdded);
         AV34SecRoleIdParm = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleIdParm"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV38OrderedBy, AV39OrderedDsc, AV84FilterFullText, AV87ManageFiltersExecutionStep, AV89Pgmname, AV60TFSecFunctionalityKey, AV61TFSecFunctionalityKey_Sel, AV13SecFunctionalityIdRemovedXml, AV12SecFunctionalityIdAddedXml, AV9SecRoleId, A16SecRoleId, AV21i, AV11SecFunctionalityIdRemoved, AV15SecFunctionalityIdToFind, AV10SecFunctionalityIdAdded, AV34SecRoleIdParm) ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
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
         PA0W2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0W2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.secrolefunroleassociationww.aspx"+UrlEncode(StringUtil.LTrimStr(AV9SecRoleId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.secrolefunroleassociationww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV89Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV89Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vSECROLEIDPARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34SecRoleIdParm), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEIDPARM", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34SecRoleIdParm), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9SecRoleId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9SecRoleId), "ZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV39OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV84FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_23", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_23), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV81GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV82GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV83GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV85ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV85ManageFiltersData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV74DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV74DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV87ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV89Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV89Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV39OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYKEY", AV60TFSecFunctionalityKey);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYKEY_SEL", AV61TFSecFunctionalityKey_Sel);
         GxWebStd.gx_hidden_field( context, "vSECFUNCTIONALITYIDREMOVEDXML", AV13SecFunctionalityIdRemovedXml);
         GxWebStd.gx_hidden_field( context, "vSECFUNCTIONALITYIDADDEDXML", AV12SecFunctionalityIdAddedXml);
         GxWebStd.gx_hidden_field( context, "vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9SecRoleId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9SecRoleId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16SecRoleId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vI", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21i), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSECFUNCTIONALITYIDREMOVED", AV11SecFunctionalityIdRemoved);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSECFUNCTIONALITYIDREMOVED", AV11SecFunctionalityIdRemoved);
         }
         GxWebStd.gx_hidden_field( context, "vSECFUNCTIONALITYIDTOFIND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15SecFunctionalityIdToFind), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSECFUNCTIONALITYIDADDED", AV10SecFunctionalityIdAdded);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSECFUNCTIONALITYIDADDED", AV10SecFunctionalityIdAdded);
         }
         GxWebStd.gx_hidden_field( context, "vSECROLEIDPARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34SecRoleIdParm), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEIDPARM", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34SecRoleIdParm), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSECFUNCTIONALITYROLE", AV16SecFunctionalityRole);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSECFUNCTIONALITYROLE", AV16SecFunctionalityRole);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV35GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV35GridState);
         }
         GxWebStd.gx_hidden_field( context, "vSECFUNCTIONALITYID_SELECTED", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33SecFunctionalityId_Selected), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Title", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Result", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Result));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Result", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Result));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0W2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0W2( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.secrolefunroleassociationww.aspx"+UrlEncode(StringUtil.LTrimStr(AV9SecRoleId,4,0));
         return formatLink("wwpbaseobjects.secrolefunroleassociationww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SecRoleFunRoleAssociationWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Asociados a Role", "") ;
      }

      protected void WB0W0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs", "start", "top", "", "", "div");
            wb_table1_12_0W2( true) ;
         }
         else
         {
            wb_table1_12_0W2( false) ;
         }
         return  ;
      }

      protected void wb_table1_12_0W2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            StartGridControl23( ) ;
         }
         if ( wbEnd == 23 )
         {
            wbEnd = 0;
            nRC_GXsfl_23 = (int)(nGXsfl_23_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV81GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV82GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV83GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnconfirm_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(23), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnEnter", ""), bttBtnconfirm_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecRoleFunRoleAssociationWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(23), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecRoleFunRoleAssociationWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV85ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV74DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            wb_table2_51_0W2( true) ;
         }
         else
         {
            wb_table2_51_0W2( false) ;
         }
         return  ;
      }

      protected void wb_table2_51_0W2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 23 )
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

      protected void START0W2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Asociados a Role", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0W0( ) ;
      }

      protected void WS0W2( )
      {
         START0W2( ) ;
         EVT0W2( ) ;
      }

      protected void EVT0W2( )
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
                              E110W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E120W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E130W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E140W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_uaviewchildren.Close */
                              E150W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 /* Set Refresh If Orderedby Changed */
                                 if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV38OrderedBy )) )
                                 {
                                    Rfr0gs = true;
                                 }
                                 /* Set Refresh If Ordereddsc Changed */
                                 if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV39OrderedDsc )
                                 {
                                    Rfr0gs = true;
                                 }
                                 /* Set Refresh If Filterfulltext Changed */
                                 if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV84FilterFullText) != 0 )
                                 {
                                    Rfr0gs = true;
                                 }
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E160W2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'DOUAVIEWCHILDREN'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VISASSOCIATED.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VISASSOCIATED.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'DOUAVIEWCHILDREN'") == 0 ) )
                           {
                              nGXsfl_23_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
                              SubsflControlProps_232( ) ;
                              AV18IsAssociated = StringUtil.StrToBool( cgiGet( chkavIsassociated_Internalname));
                              AssignAttri("", false, chkavIsassociated_Internalname, AV18IsAssociated);
                              AV19IsAssociatedOld = StringUtil.StrToBool( cgiGet( chkavIsassociatedold_Internalname));
                              AssignAttri("", false, chkavIsassociatedold_Internalname, AV19IsAssociatedOld);
                              GxWebStd.gx_hidden_field( context, "gxhash_vISASSOCIATEDOLD"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, AV19IsAssociatedOld, context));
                              AV29UAViewChildren = cgiGet( edtavUaviewchildren_Internalname);
                              AssignProp("", false, edtavUaviewchildren_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV29UAViewChildren)) ? AV90Uaviewchildren_GXI : context.convertURL( context.PathToRelativeUrl( AV29UAViewChildren))), !bGXsfl_23_Refreshing);
                              AssignProp("", false, edtavUaviewchildren_Internalname, "SrcSet", context.GetImageSrcSet( AV29UAViewChildren), true);
                              A13SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A15SecFunctionalityKey = cgiGet( edtSecFunctionalityKey_Internalname);
                              A20SecFunctionalityDescription = cgiGet( edtSecFunctionalityDescription_Internalname);
                              cmbSecFunctionalityType.Name = cmbSecFunctionalityType_Internalname;
                              cmbSecFunctionalityType.CurrentValue = cgiGet( cmbSecFunctionalityType_Internalname);
                              A21SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbSecFunctionalityType_Internalname), "."), 18, MidpointRounding.ToEven));
                              A14SecParentFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecParentFunctionalityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n14SecParentFunctionalityId = false;
                              A23SecParentFunctionalityDescript = cgiGet( edtSecParentFunctionalityDescript_Internalname);
                              A19SecFunctionalityActive = StringUtil.StrToBool( cgiGet( chkSecFunctionalityActive_Internalname));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E170W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E180W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E190W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOUAVIEWCHILDREN'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUAViewChildren' */
                                    E200W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VISASSOCIATED.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E210W2 ();
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

      protected void WE0W2( )
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

      protected void PA0W2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.secrolefunroleassociationww.aspx")), "wwpbaseobjects.secrolefunroleassociationww.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.secrolefunroleassociationww.aspx")))) ;
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
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "SecRoleId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV9SecRoleId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV9SecRoleId", StringUtil.LTrimStr( (decimal)(AV9SecRoleId), 4, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9SecRoleId), "ZZZ9"), context));
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
         SubsflControlProps_232( ) ;
         while ( nGXsfl_23_idx <= nRC_GXsfl_23 )
         {
            sendrow_232( ) ;
            nGXsfl_23_idx = ((subGrid_Islastpage==1)&&(nGXsfl_23_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_23_idx+1);
            sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
            SubsflControlProps_232( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV38OrderedBy ,
                                       bool AV39OrderedDsc ,
                                       string AV84FilterFullText ,
                                       short AV87ManageFiltersExecutionStep ,
                                       string AV89Pgmname ,
                                       string AV60TFSecFunctionalityKey ,
                                       string AV61TFSecFunctionalityKey_Sel ,
                                       string AV13SecFunctionalityIdRemovedXml ,
                                       string AV12SecFunctionalityIdAddedXml ,
                                       short AV9SecRoleId ,
                                       short A16SecRoleId ,
                                       long AV21i ,
                                       GxSimpleCollection<long> AV11SecFunctionalityIdRemoved ,
                                       long AV15SecFunctionalityIdToFind ,
                                       GxSimpleCollection<long> AV10SecFunctionalityIdAdded ,
                                       short AV34SecRoleIdParm )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0W2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A13SecFunctionalityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SecFunctionalityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vISASSOCIATEDOLD", GetSecureSignedToken( "", AV19IsAssociatedOld, context));
         GxWebStd.gx_hidden_field( context, "vISASSOCIATEDOLD", StringUtil.BoolToStr( AV19IsAssociatedOld));
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
         RF0W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV89Pgmname = "WWPBaseObjects.SecRoleFunRoleAssociationWW";
         chkavIsassociatedold.Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61TFSecFunctionalityKey_Sel ,
                                              AV60TFSecFunctionalityKey ,
                                              A15SecFunctionalityKey ,
                                              AV38OrderedBy ,
                                              AV39OrderedDsc ,
                                              AV84FilterFullText ,
                                              A20SecFunctionalityDescription ,
                                              A21SecFunctionalityType ,
                                              A23SecParentFunctionalityDescript } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV60TFSecFunctionalityKey = StringUtil.Concat( StringUtil.RTrim( AV60TFSecFunctionalityKey), "%", "");
         /* Using cursor H000W2 */
         pr_default.execute(0, new Object[] {lV60TFSecFunctionalityKey, AV61TFSecFunctionalityKey_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A13SecFunctionalityId = H000W2_A13SecFunctionalityId[0];
            A23SecParentFunctionalityDescript = H000W2_A23SecParentFunctionalityDescript[0];
            A21SecFunctionalityType = H000W2_A21SecFunctionalityType[0];
            A20SecFunctionalityDescription = H000W2_A20SecFunctionalityDescription[0];
            A15SecFunctionalityKey = H000W2_A15SecFunctionalityKey[0];
            A19SecFunctionalityActive = H000W2_A19SecFunctionalityActive[0];
            A14SecParentFunctionalityId = H000W2_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = H000W2_n14SecParentFunctionalityId[0];
            A23SecParentFunctionalityDescript = H000W2_A23SecParentFunctionalityDescript[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A15SecFunctionalityKey) , StringUtil.PadR( "%" + StringUtil.Upper( AV84FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A20SecFunctionalityDescription) , StringUtil.PadR( "%" + StringUtil.Upper( AV84FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "mode", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 1 ) ) || ( StringUtil.Like( context.GetMessage( "action", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 2 ) ) || ( StringUtil.Like( context.GetMessage( "tab", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 3 ) ) || ( StringUtil.Like( context.GetMessage( "object", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 4 ) ) || ( StringUtil.Like( context.GetMessage( "attribute", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 5 ) ) || ( StringUtil.Like( StringUtil.Upper( A23SecParentFunctionalityDescript) , StringUtil.PadR( "%" + StringUtil.Upper( AV84FilterFullText) , 255 , "%"),  ' ' ) ) ) )
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

      protected void RF0W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 23;
         /* Execute user event: Refresh */
         E180W2 ();
         nGXsfl_23_idx = 1;
         sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
         SubsflControlProps_232( ) ;
         bGXsfl_23_Refreshing = true;
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
            SubsflControlProps_232( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV61TFSecFunctionalityKey_Sel ,
                                                 AV60TFSecFunctionalityKey ,
                                                 A15SecFunctionalityKey ,
                                                 AV38OrderedBy ,
                                                 AV39OrderedDsc ,
                                                 AV84FilterFullText ,
                                                 A20SecFunctionalityDescription ,
                                                 A21SecFunctionalityType ,
                                                 A23SecParentFunctionalityDescript } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            lV60TFSecFunctionalityKey = StringUtil.Concat( StringUtil.RTrim( AV60TFSecFunctionalityKey), "%", "");
            /* Using cursor H000W3 */
            pr_default.execute(1, new Object[] {lV60TFSecFunctionalityKey, AV61TFSecFunctionalityKey_Sel});
            nGXsfl_23_idx = 1;
            sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
            SubsflControlProps_232( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A13SecFunctionalityId = H000W3_A13SecFunctionalityId[0];
               A23SecParentFunctionalityDescript = H000W3_A23SecParentFunctionalityDescript[0];
               A21SecFunctionalityType = H000W3_A21SecFunctionalityType[0];
               A20SecFunctionalityDescription = H000W3_A20SecFunctionalityDescription[0];
               A15SecFunctionalityKey = H000W3_A15SecFunctionalityKey[0];
               A19SecFunctionalityActive = H000W3_A19SecFunctionalityActive[0];
               A14SecParentFunctionalityId = H000W3_A14SecParentFunctionalityId[0];
               n14SecParentFunctionalityId = H000W3_n14SecParentFunctionalityId[0];
               A23SecParentFunctionalityDescript = H000W3_A23SecParentFunctionalityDescript[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A15SecFunctionalityKey) , StringUtil.PadR( "%" + StringUtil.Upper( AV84FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A20SecFunctionalityDescription) , StringUtil.PadR( "%" + StringUtil.Upper( AV84FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "mode", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 1 ) ) || ( StringUtil.Like( context.GetMessage( "action", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 2 ) ) || ( StringUtil.Like( context.GetMessage( "tab", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 3 ) ) || ( StringUtil.Like( context.GetMessage( "object", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 4 ) ) || ( StringUtil.Like( context.GetMessage( "attribute", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 5 ) ) || ( StringUtil.Like( StringUtil.Upper( A23SecParentFunctionalityDescript) , StringUtil.PadR( "%" + StringUtil.Upper( AV84FilterFullText) , 255 , "%"),  ' ' ) ) ) )
               {
                  /* Execute user event: Grid.Load */
                  E190W2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 23;
            WB0W0( ) ;
         }
         bGXsfl_23_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0W2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV89Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV89Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vSECROLEIDPARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34SecRoleIdParm), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEIDPARM", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34SecRoleIdParm), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYID"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, context.localUtil.Format( (decimal)(A13SecFunctionalityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISASSOCIATEDOLD"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, AV19IsAssociatedOld, context));
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
            gxgrGrid_refresh( subGrid_Rows, AV38OrderedBy, AV39OrderedDsc, AV84FilterFullText, AV87ManageFiltersExecutionStep, AV89Pgmname, AV60TFSecFunctionalityKey, AV61TFSecFunctionalityKey_Sel, AV13SecFunctionalityIdRemovedXml, AV12SecFunctionalityIdAddedXml, AV9SecRoleId, A16SecRoleId, AV21i, AV11SecFunctionalityIdRemoved, AV15SecFunctionalityIdToFind, AV10SecFunctionalityIdAdded, AV34SecRoleIdParm) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV38OrderedBy, AV39OrderedDsc, AV84FilterFullText, AV87ManageFiltersExecutionStep, AV89Pgmname, AV60TFSecFunctionalityKey, AV61TFSecFunctionalityKey_Sel, AV13SecFunctionalityIdRemovedXml, AV12SecFunctionalityIdAddedXml, AV9SecRoleId, A16SecRoleId, AV21i, AV11SecFunctionalityIdRemoved, AV15SecFunctionalityIdToFind, AV10SecFunctionalityIdAdded, AV34SecRoleIdParm) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV38OrderedBy, AV39OrderedDsc, AV84FilterFullText, AV87ManageFiltersExecutionStep, AV89Pgmname, AV60TFSecFunctionalityKey, AV61TFSecFunctionalityKey_Sel, AV13SecFunctionalityIdRemovedXml, AV12SecFunctionalityIdAddedXml, AV9SecRoleId, A16SecRoleId, AV21i, AV11SecFunctionalityIdRemoved, AV15SecFunctionalityIdToFind, AV10SecFunctionalityIdAdded, AV34SecRoleIdParm) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV38OrderedBy, AV39OrderedDsc, AV84FilterFullText, AV87ManageFiltersExecutionStep, AV89Pgmname, AV60TFSecFunctionalityKey, AV61TFSecFunctionalityKey_Sel, AV13SecFunctionalityIdRemovedXml, AV12SecFunctionalityIdAddedXml, AV9SecRoleId, A16SecRoleId, AV21i, AV11SecFunctionalityIdRemoved, AV15SecFunctionalityIdToFind, AV10SecFunctionalityIdAdded, AV34SecRoleIdParm) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV38OrderedBy, AV39OrderedDsc, AV84FilterFullText, AV87ManageFiltersExecutionStep, AV89Pgmname, AV60TFSecFunctionalityKey, AV61TFSecFunctionalityKey_Sel, AV13SecFunctionalityIdRemovedXml, AV12SecFunctionalityIdAddedXml, AV9SecRoleId, A16SecRoleId, AV21i, AV11SecFunctionalityIdRemoved, AV15SecFunctionalityIdToFind, AV10SecFunctionalityIdAdded, AV34SecRoleIdParm) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV89Pgmname = "WWPBaseObjects.SecRoleFunRoleAssociationWW";
         chkavIsassociatedold.Enabled = 0;
         edtSecFunctionalityId_Enabled = 0;
         edtSecFunctionalityKey_Enabled = 0;
         edtSecFunctionalityDescription_Enabled = 0;
         cmbSecFunctionalityType.Enabled = 0;
         edtSecParentFunctionalityId_Enabled = 0;
         edtSecParentFunctionalityDescript_Enabled = 0;
         chkSecFunctionalityActive.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E170W2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV85ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV74DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_23 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_23"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV81GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV82GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV83GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
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
            Dvelop_confirmpanel_uaviewchildren_Title = cgiGet( "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Title");
            Dvelop_confirmpanel_uaviewchildren_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Confirmationtext");
            Dvelop_confirmpanel_uaviewchildren_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Yesbuttoncaption");
            Dvelop_confirmpanel_uaviewchildren_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Nobuttoncaption");
            Dvelop_confirmpanel_uaviewchildren_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Cancelbuttoncaption");
            Dvelop_confirmpanel_uaviewchildren_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Yesbuttonposition");
            Dvelop_confirmpanel_uaviewchildren_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Confirmtype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_uaviewchildren_Result = cgiGet( "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Result");
            /* Read variables values. */
            AV84FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV84FilterFullText", AV84FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV38OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV39OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV84FilterFullText) != 0 )
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
         E170W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E170W2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV22HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( "Asociados a Role", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV38OrderedBy < 1 )
         {
            AV38OrderedBy = 1;
            AssignAttri("", false, "AV38OrderedBy", StringUtil.LTrimStr( (decimal)(AV38OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV74DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV74DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         /* Using cursor H000W4 */
         pr_default.execute(2, new Object[] {AV9SecRoleId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A16SecRoleId = H000W4_A16SecRoleId[0];
            A25SecRoleName = H000W4_A25SecRoleName[0];
            Form.Caption = StringUtil.Format( context.GetMessage( "Associate Functionalities to Role :: %1", ""), A25SecRoleName, "", "", "", "", "", "", "", "");
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      protected void E180W2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV77WWPContext) ;
         if ( AV87ManageFiltersExecutionStep == 1 )
         {
            AV87ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV87ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV87ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV87ManageFiltersExecutionStep == 2 )
         {
            AV87ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV87ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV87ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOAD LISTS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV81GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV81GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV81GridCurrentPage), 10, 0));
         AV82GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV82GridPageCount", StringUtil.LTrimStr( (decimal)(AV82GridPageCount), 10, 0));
         GXt_char2 = AV83GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV89Pgmname, out  GXt_char2) ;
         AV83GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV83GridAppliedFilters", AV83GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV85ManageFiltersData", AV85ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35GridState", AV35GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11SecFunctionalityIdRemoved", AV11SecFunctionalityIdRemoved);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10SecFunctionalityIdAdded", AV10SecFunctionalityIdAdded);
      }

      protected void E110W2( )
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
            AV80PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV80PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV85ManageFiltersData", AV85ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35GridState", AV35GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11SecFunctionalityIdRemoved", AV11SecFunctionalityIdRemoved);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10SecFunctionalityIdAdded", AV10SecFunctionalityIdAdded);
      }

      protected void E120W2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E140W2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV38OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV38OrderedBy", StringUtil.LTrimStr( (decimal)(AV38OrderedBy), 4, 0));
            AV39OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV39OrderedDsc", AV39OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecFunctionalityKey") == 0 )
            {
               AV60TFSecFunctionalityKey = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV60TFSecFunctionalityKey", AV60TFSecFunctionalityKey);
               AV61TFSecFunctionalityKey_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV61TFSecFunctionalityKey_Sel", AV61TFSecFunctionalityKey_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E190W2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            edtavUaviewchildren_gximage = "ActionDisplay";
            AV29UAViewChildren = context.GetImagePath( "f11923b6-6acd-4a79-bfc0-0cfc6f3bced5", "", context.GetTheme( ));
            AssignAttri("", false, edtavUaviewchildren_Internalname, AV29UAViewChildren);
            AV90Uaviewchildren_GXI = GXDbFile.PathToUrl( context.GetImagePath( "f11923b6-6acd-4a79-bfc0-0cfc6f3bced5", "", context.GetTheme( )), context);
            edtavUaviewchildren_Tooltiptext = context.GetMessage( "View Actions, Tabs and Modes", "");
            GXt_boolean3 = AV31TempBoolean;
            new GeneXus.Programs.wwpbaseobjects.secfunctionalityhaschildren(context ).execute(  A13SecFunctionalityId, out  GXt_boolean3) ;
            AV31TempBoolean = GXt_boolean3;
            if ( AV31TempBoolean )
            {
               edtavUaviewchildren_Class = "ActionBaseColorAttribute";
            }
            else
            {
               edtavUaviewchildren_Class = "Invisible";
            }
            AV34SecRoleIdParm = AV9SecRoleId;
            AssignAttri("", false, "AV34SecRoleIdParm", StringUtil.LTrimStr( (decimal)(AV34SecRoleIdParm), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEIDPARM", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34SecRoleIdParm), "ZZZ9"), context));
            AV19IsAssociatedOld = false;
            AssignAttri("", false, chkavIsassociatedold_Internalname, AV19IsAssociatedOld);
            GxWebStd.gx_hidden_field( context, "gxhash_vISASSOCIATEDOLD"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, AV19IsAssociatedOld, context));
            /* Using cursor H000W5 */
            pr_default.execute(3, new Object[] {A13SecFunctionalityId, AV34SecRoleIdParm});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A16SecRoleId = H000W5_A16SecRoleId[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A15SecFunctionalityKey) , StringUtil.PadR( "%" + StringUtil.Upper( AV84FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A20SecFunctionalityDescription) , StringUtil.PadR( "%" + StringUtil.Upper( AV84FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "mode", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 1 ) ) || ( StringUtil.Like( context.GetMessage( "action", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 2 ) ) || ( StringUtil.Like( context.GetMessage( "tab", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 3 ) ) || ( StringUtil.Like( context.GetMessage( "object", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 4 ) ) || ( StringUtil.Like( context.GetMessage( "attribute", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 5 ) ) || ( StringUtil.Like( StringUtil.Upper( A23SecParentFunctionalityDescript) , StringUtil.PadR( "%" + StringUtil.Upper( AV84FilterFullText) , 255 , "%"),  ' ' ) ) ) )
               {
                  AV19IsAssociatedOld = true;
                  AssignAttri("", false, chkavIsassociatedold_Internalname, AV19IsAssociatedOld);
                  GxWebStd.gx_hidden_field( context, "gxhash_vISASSOCIATEDOLD"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, AV19IsAssociatedOld, context));
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            AV15SecFunctionalityIdToFind = A13SecFunctionalityId;
            AssignAttri("", false, "AV15SecFunctionalityIdToFind", StringUtil.LTrimStr( (decimal)(AV15SecFunctionalityIdToFind), 10, 0));
            if ( AV19IsAssociatedOld )
            {
               /* Execute user subroutine: 'FIND IN REMOVED' */
               S162 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            else
            {
               /* Execute user subroutine: 'FIND IN ADDED' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            if ( AV21i > 0 )
            {
               AV18IsAssociated = (bool)(!AV19IsAssociatedOld);
               AssignAttri("", false, chkavIsassociated_Internalname, AV18IsAssociated);
            }
            else
            {
               AV18IsAssociated = AV19IsAssociatedOld;
               AssignAttri("", false, chkavIsassociated_Internalname, AV18IsAssociated);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 23;
            }
            sendrow_232( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_23_Refreshing )
         {
            context.DoAjaxLoad(23, GridRow);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E160W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E160W2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOAD LISTS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV17Success = true;
         AV21i = 1;
         AssignAttri("", false, "AV21i", StringUtil.LTrimStr( (decimal)(AV21i), 10, 0));
         AV92GXV1 = 1;
         while ( AV92GXV1 <= AV11SecFunctionalityIdRemoved.Count )
         {
            AV14SecFunctionalityId = (long)(AV11SecFunctionalityIdRemoved.GetNumeric(AV92GXV1));
            AV16SecFunctionalityRole = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole(context);
            AV16SecFunctionalityRole.Load(AV14SecFunctionalityId, AV9SecRoleId);
            if ( AV16SecFunctionalityRole.Success() )
            {
               AV16SecFunctionalityRole.Delete();
            }
            if ( ! AV16SecFunctionalityRole.Success() )
            {
               AV17Success = false;
               /* Execute user subroutine: 'SHOW ERROR MESSAGES' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            AV21i = (long)(AV21i+1);
            AssignAttri("", false, "AV21i", StringUtil.LTrimStr( (decimal)(AV21i), 10, 0));
            AV92GXV1 = (int)(AV92GXV1+1);
         }
         AV21i = 1;
         AssignAttri("", false, "AV21i", StringUtil.LTrimStr( (decimal)(AV21i), 10, 0));
         AV93GXV2 = 1;
         while ( AV93GXV2 <= AV10SecFunctionalityIdAdded.Count )
         {
            AV14SecFunctionalityId = (long)(AV10SecFunctionalityIdAdded.GetNumeric(AV93GXV2));
            AV16SecFunctionalityRole = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole(context);
            AV16SecFunctionalityRole.gxTpr_Secroleid = AV9SecRoleId;
            AV16SecFunctionalityRole.gxTpr_Secfunctionalityid = AV14SecFunctionalityId;
            AV16SecFunctionalityRole.Save();
            if ( ! AV16SecFunctionalityRole.Success() )
            {
               AV17Success = false;
               /* Execute user subroutine: 'SHOW ERROR MESSAGES' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            AV21i = (long)(AV21i+1);
            AssignAttri("", false, "AV21i", StringUtil.LTrimStr( (decimal)(AV21i), 10, 0));
            AV93GXV2 = (int)(AV93GXV2+1);
         }
         if ( AV17Success )
         {
            if ( AV10SecFunctionalityIdAdded.Count + AV11SecFunctionalityIdRemoved.Count > 0 )
            {
               context.CommitDataStores("wwpbaseobjects.secrolefunroleassociationww",pr_default);
               AV12SecFunctionalityIdAddedXml = "";
               AssignAttri("", false, "AV12SecFunctionalityIdAddedXml", AV12SecFunctionalityIdAddedXml);
               AV13SecFunctionalityIdRemovedXml = "";
               AssignAttri("", false, "AV13SecFunctionalityIdRemovedXml", AV13SecFunctionalityIdRemovedXml);
               GX_msglist.addItem(context.GetMessage( "WWP_DataSuccessfulyUpdated", ""));
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "WWP_NoChangesMade", ""));
            }
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16SecFunctionalityRole", AV16SecFunctionalityRole);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11SecFunctionalityIdRemoved", AV11SecFunctionalityIdRemoved);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10SecFunctionalityIdAdded", AV10SecFunctionalityIdAdded);
      }

      protected void E130W2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WWPBaseObjects.SecRoleFunRoleAssociationWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV89Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV87ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV87ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV87ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WWPBaseObjects.SecRoleFunRoleAssociationWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV87ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV87ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV87ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV86ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WWPBaseObjects.SecRoleFunRoleAssociationWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV86ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV89Pgmname+"GridState",  AV86ManageFiltersXml) ;
               AV35GridState.FromXml(AV86ManageFiltersXml, null, "", "");
               AV38OrderedBy = AV35GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV38OrderedBy", StringUtil.LTrimStr( (decimal)(AV38OrderedBy), 4, 0));
               AV39OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV39OrderedDsc", AV39OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S202 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35GridState", AV35GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV85ManageFiltersData", AV85ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11SecFunctionalityIdRemoved", AV11SecFunctionalityIdRemoved);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10SecFunctionalityIdAdded", AV10SecFunctionalityIdAdded);
      }

      protected void E200W2( )
      {
         /* 'DoUAViewChildren' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOAD LISTS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV10SecFunctionalityIdAdded.Count + AV11SecFunctionalityIdRemoved.Count > 0 )
         {
            AV33SecFunctionalityId_Selected = A13SecFunctionalityId;
            AssignAttri("", false, "AV33SecFunctionalityId_Selected", StringUtil.LTrimStr( (decimal)(AV33SecFunctionalityId_Selected), 10, 0));
            this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_UAVIEWCHILDRENContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            AV32SecRoleId_Selected = AV9SecRoleId;
            AV33SecFunctionalityId_Selected = A13SecFunctionalityId;
            AssignAttri("", false, "AV33SecFunctionalityId_Selected", StringUtil.LTrimStr( (decimal)(AV33SecFunctionalityId_Selected), 10, 0));
            /* Execute user subroutine: 'DO UAVIEWCHILDREN' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11SecFunctionalityIdRemoved", AV11SecFunctionalityIdRemoved);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10SecFunctionalityIdAdded", AV10SecFunctionalityIdAdded);
      }

      protected void E150W2( )
      {
         /* Dvelop_confirmpanel_uaviewchildren_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_uaviewchildren_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO UAVIEWCHILDREN' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void E210W2( )
      {
         /* Isassociated_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOAD LISTS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV15SecFunctionalityIdToFind = A13SecFunctionalityId;
         AssignAttri("", false, "AV15SecFunctionalityIdToFind", StringUtil.LTrimStr( (decimal)(AV15SecFunctionalityIdToFind), 10, 0));
         if ( AV18IsAssociated )
         {
            if ( AV19IsAssociatedOld )
            {
               /* Execute user subroutine: 'FIND IN REMOVED' */
               S162 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               AV11SecFunctionalityIdRemoved.RemoveItem((int)(AV21i));
            }
            else
            {
               AV10SecFunctionalityIdAdded.Add(AV15SecFunctionalityIdToFind, 0);
            }
         }
         else
         {
            if ( AV19IsAssociatedOld )
            {
               AV11SecFunctionalityIdRemoved.Add(AV15SecFunctionalityIdToFind, 0);
            }
            else
            {
               /* Execute user subroutine: 'FIND IN ADDED' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               AV10SecFunctionalityIdAdded.RemoveItem((int)(AV21i));
            }
         }
         /* Execute user subroutine: 'SAVE LISTS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11SecFunctionalityIdRemoved", AV11SecFunctionalityIdRemoved);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10SecFunctionalityIdAdded", AV10SecFunctionalityIdAdded);
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV38OrderedBy), 4, 0))+":"+(AV39OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV85ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WWPBaseObjects.SecRoleFunRoleAssociationWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV85ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S192( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV84FilterFullText = "";
         AssignAttri("", false, "AV84FilterFullText", AV84FilterFullText);
         AV60TFSecFunctionalityKey = "";
         AssignAttri("", false, "AV60TFSecFunctionalityKey", AV60TFSecFunctionalityKey);
         AV61TFSecFunctionalityKey_Sel = "";
         AssignAttri("", false, "AV61TFSecFunctionalityKey_Sel", AV61TFSecFunctionalityKey_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S212( )
      {
         /* 'DO UAVIEWCHILDREN' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.secrolefunroleactionassociationww.aspx"+UrlEncode(StringUtil.LTrimStr(AV9SecRoleId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV33SecFunctionalityId_Selected,10,0));
         CallWebObject(formatLink("wwpbaseobjects.secrolefunroleactionassociationww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get(AV89Pgmname+"GridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV89Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV28Session.Get(AV89Pgmname+"GridState"), null, "", "");
         }
         AV38OrderedBy = AV35GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV38OrderedBy", StringUtil.LTrimStr( (decimal)(AV38OrderedBy), 4, 0));
         AV39OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV39OrderedDsc", AV39OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV35GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV35GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV35GridState.gxTpr_Currentpage) ;
      }

      protected void S202( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV94GXV3 = 1;
         while ( AV94GXV3 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV94GXV3));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV84FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV84FilterFullText", AV84FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY") == 0 )
            {
               AV60TFSecFunctionalityKey = AV36GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV60TFSecFunctionalityKey", AV60TFSecFunctionalityKey);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY_SEL") == 0 )
            {
               AV61TFSecFunctionalityKey_Sel = AV36GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV61TFSecFunctionalityKey_Sel", AV61TFSecFunctionalityKey_Sel);
            }
            AV94GXV3 = (int)(AV94GXV3+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV61TFSecFunctionalityKey_Sel)),  AV61TFSecFunctionalityKey_Sel, out  GXt_char2) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV60TFSecFunctionalityKey)),  AV60TFSecFunctionalityKey, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char2+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV35GridState.FromXml(AV28Session.Get(AV89Pgmname+"GridState"), null, "", "");
         AV35GridState.gxTpr_Orderedby = AV38OrderedBy;
         AV35GridState.gxTpr_Ordereddsc = AV39OrderedDsc;
         AV35GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV35GridState,  "FILTERFULLTEXT",  context.GetMessage( "Filtro", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV84FilterFullText)),  0,  AV84FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV35GridState,  "TFSECFUNCTIONALITYKEY",  context.GetMessage( "Key", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV60TFSecFunctionalityKey)),  0,  AV60TFSecFunctionalityKey,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV61TFSecFunctionalityKey_Sel)),  AV61TFSecFunctionalityKey_Sel,  "") ;
         AV35GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV35GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV89Pgmname+"GridState",  AV35GridState.ToXml(false, true, "", "")) ;
      }

      protected void S172( )
      {
         /* 'FIND IN ADDED' Routine */
         returnInSub = false;
         AV21i = 1;
         AssignAttri("", false, "AV21i", StringUtil.LTrimStr( (decimal)(AV21i), 10, 0));
         AV95GXV4 = 1;
         while ( AV95GXV4 <= AV10SecFunctionalityIdAdded.Count )
         {
            AV14SecFunctionalityId = (long)(AV10SecFunctionalityIdAdded.GetNumeric(AV95GXV4));
            if ( AV14SecFunctionalityId == AV15SecFunctionalityIdToFind )
            {
               if (true) break;
            }
            AV21i = (long)(AV21i+1);
            AssignAttri("", false, "AV21i", StringUtil.LTrimStr( (decimal)(AV21i), 10, 0));
            AV95GXV4 = (int)(AV95GXV4+1);
         }
         if ( AV21i > AV10SecFunctionalityIdAdded.Count )
         {
            AV21i = 0;
            AssignAttri("", false, "AV21i", StringUtil.LTrimStr( (decimal)(AV21i), 10, 0));
         }
      }

      protected void S162( )
      {
         /* 'FIND IN REMOVED' Routine */
         returnInSub = false;
         AV21i = 1;
         AssignAttri("", false, "AV21i", StringUtil.LTrimStr( (decimal)(AV21i), 10, 0));
         AV96GXV5 = 1;
         while ( AV96GXV5 <= AV11SecFunctionalityIdRemoved.Count )
         {
            AV14SecFunctionalityId = (long)(AV11SecFunctionalityIdRemoved.GetNumeric(AV96GXV5));
            if ( AV14SecFunctionalityId == AV15SecFunctionalityIdToFind )
            {
               if (true) break;
            }
            AV21i = (long)(AV21i+1);
            AssignAttri("", false, "AV21i", StringUtil.LTrimStr( (decimal)(AV21i), 10, 0));
            AV96GXV5 = (int)(AV96GXV5+1);
         }
         if ( AV21i > AV11SecFunctionalityIdRemoved.Count )
         {
            AV21i = 0;
            AssignAttri("", false, "AV21i", StringUtil.LTrimStr( (decimal)(AV21i), 10, 0));
         }
      }

      protected void S152( )
      {
         /* 'LOAD LISTS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SecFunctionalityIdRemovedXml)) )
         {
            AV11SecFunctionalityIdRemoved.FromXml(AV13SecFunctionalityIdRemovedXml, null, "Collection", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12SecFunctionalityIdAddedXml)) )
         {
            AV10SecFunctionalityIdAdded.FromXml(AV12SecFunctionalityIdAddedXml, null, "Collection", "");
         }
      }

      protected void S222( )
      {
         /* 'SAVE LISTS' Routine */
         returnInSub = false;
         if ( AV11SecFunctionalityIdRemoved.Count > 0 )
         {
            AV13SecFunctionalityIdRemovedXml = AV11SecFunctionalityIdRemoved.ToXml(false, true, "Collection", "");
            AssignAttri("", false, "AV13SecFunctionalityIdRemovedXml", AV13SecFunctionalityIdRemovedXml);
         }
         else
         {
            AV13SecFunctionalityIdRemovedXml = "";
            AssignAttri("", false, "AV13SecFunctionalityIdRemovedXml", AV13SecFunctionalityIdRemovedXml);
         }
         if ( AV10SecFunctionalityIdAdded.Count > 0 )
         {
            AV12SecFunctionalityIdAddedXml = AV10SecFunctionalityIdAdded.ToXml(false, true, "Collection", "");
            AssignAttri("", false, "AV12SecFunctionalityIdAddedXml", AV12SecFunctionalityIdAddedXml);
         }
         else
         {
            AV12SecFunctionalityIdAddedXml = "";
            AssignAttri("", false, "AV12SecFunctionalityIdAddedXml", AV12SecFunctionalityIdAddedXml);
         }
      }

      protected void S182( )
      {
         /* 'SHOW ERROR MESSAGES' Routine */
         returnInSub = false;
         AV98GXV7 = 1;
         AV97GXV6 = AV16SecFunctionalityRole.GetMessages();
         while ( AV98GXV7 <= AV97GXV6.Count )
         {
            AV20Message = ((GeneXus.Utils.SdtMessages_Message)AV97GXV6.Item(AV98GXV7));
            if ( AV20Message.gxTpr_Type == 1 )
            {
               GX_msglist.addItem(AV20Message.gxTpr_Description);
            }
            AV98GXV7 = (int)(AV98GXV7+1);
         }
      }

      protected void wb_table2_51_0W2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_uaviewchildren_Internalname, tblTabledvelop_confirmpanel_uaviewchildren_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_uaviewchildren.SetProperty("Title", Dvelop_confirmpanel_uaviewchildren_Title);
            ucDvelop_confirmpanel_uaviewchildren.SetProperty("ConfirmationText", Dvelop_confirmpanel_uaviewchildren_Confirmationtext);
            ucDvelop_confirmpanel_uaviewchildren.SetProperty("YesButtonCaption", Dvelop_confirmpanel_uaviewchildren_Yesbuttoncaption);
            ucDvelop_confirmpanel_uaviewchildren.SetProperty("NoButtonCaption", Dvelop_confirmpanel_uaviewchildren_Nobuttoncaption);
            ucDvelop_confirmpanel_uaviewchildren.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_uaviewchildren_Cancelbuttoncaption);
            ucDvelop_confirmpanel_uaviewchildren.SetProperty("YesButtonPosition", Dvelop_confirmpanel_uaviewchildren_Yesbuttonposition);
            ucDvelop_confirmpanel_uaviewchildren.SetProperty("ConfirmType", Dvelop_confirmpanel_uaviewchildren_Confirmtype);
            ucDvelop_confirmpanel_uaviewchildren.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_uaviewchildren_Internalname, "DVELOP_CONFIRMPANEL_UAVIEWCHILDRENContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_UAVIEWCHILDRENContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_51_0W2e( true) ;
         }
         else
         {
            wb_table2_51_0W2e( false) ;
         }
      }

      protected void wb_table1_12_0W2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavFilterfulltext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filtro", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'" + sGXsfl_23_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV84FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV84FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WWPBaseObjects/SecRoleFunRoleAssociationWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_12_0W2e( true) ;
         }
         else
         {
            wb_table1_12_0W2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV9SecRoleId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV9SecRoleId", StringUtil.LTrimStr( (decimal)(AV9SecRoleId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9SecRoleId), "ZZZ9"), context));
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
         PA0W2( ) ;
         WS0W2( ) ;
         WE0W2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20268622531779", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/secrolefunroleassociationww.js", "?20268622531780", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_232( )
      {
         chkavIsassociated_Internalname = "vISASSOCIATED_"+sGXsfl_23_idx;
         chkavIsassociatedold_Internalname = "vISASSOCIATEDOLD_"+sGXsfl_23_idx;
         edtavUaviewchildren_Internalname = "vUAVIEWCHILDREN_"+sGXsfl_23_idx;
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_23_idx;
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY_"+sGXsfl_23_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_23_idx;
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE_"+sGXsfl_23_idx;
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID_"+sGXsfl_23_idx;
         edtSecParentFunctionalityDescript_Internalname = "SECPARENTFUNCTIONALITYDESCRIPT_"+sGXsfl_23_idx;
         chkSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE_"+sGXsfl_23_idx;
      }

      protected void SubsflControlProps_fel_232( )
      {
         chkavIsassociated_Internalname = "vISASSOCIATED_"+sGXsfl_23_fel_idx;
         chkavIsassociatedold_Internalname = "vISASSOCIATEDOLD_"+sGXsfl_23_fel_idx;
         edtavUaviewchildren_Internalname = "vUAVIEWCHILDREN_"+sGXsfl_23_fel_idx;
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_23_fel_idx;
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY_"+sGXsfl_23_fel_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_23_fel_idx;
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE_"+sGXsfl_23_fel_idx;
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID_"+sGXsfl_23_fel_idx;
         edtSecParentFunctionalityDescript_Internalname = "SECPARENTFUNCTIONALITYDESCRIPT_"+sGXsfl_23_fel_idx;
         chkSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE_"+sGXsfl_23_fel_idx;
      }

      protected void sendrow_232( )
      {
         sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
         SubsflControlProps_232( ) ;
         WB0W0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_23_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_23_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_23_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'" + sGXsfl_23_idx + "',23)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "vISASSOCIATED_" + sGXsfl_23_idx;
            chkavIsassociated.Name = GXCCtl;
            chkavIsassociated.WebTags = "";
            chkavIsassociated.Caption = "";
            AssignProp("", false, chkavIsassociated_Internalname, "TitleCaption", chkavIsassociated.Caption, !bGXsfl_23_Refreshing);
            chkavIsassociated.CheckedValue = "false";
            AV18IsAssociated = StringUtil.StrToBool( StringUtil.BoolToStr( AV18IsAssociated));
            AssignAttri("", false, chkavIsassociated_Internalname, AV18IsAssociated);
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavIsassociated_Internalname,StringUtil.BoolToStr( AV18IsAssociated),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onblur=\""+""+";gx.evt.onblur(this,24);\""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "vISASSOCIATEDOLD_" + sGXsfl_23_idx;
            chkavIsassociatedold.Name = GXCCtl;
            chkavIsassociatedold.WebTags = "";
            chkavIsassociatedold.Caption = "";
            AssignProp("", false, chkavIsassociatedold_Internalname, "TitleCaption", chkavIsassociatedold.Caption, !bGXsfl_23_Refreshing);
            chkavIsassociatedold.CheckedValue = "false";
            AV19IsAssociatedOld = StringUtil.StrToBool( StringUtil.BoolToStr( AV19IsAssociatedOld));
            AssignAttri("", false, chkavIsassociatedold_Internalname, AV19IsAssociatedOld);
            GxWebStd.gx_hidden_field( context, "gxhash_vISASSOCIATEDOLD"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, AV19IsAssociatedOld, context));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavIsassociatedold_Internalname,StringUtil.BoolToStr( AV19IsAssociatedOld),(string)"",(string)"",(short)0,chkavIsassociatedold.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',23)\"";
            ClassString = edtavUaviewchildren_Class + " " + ((StringUtil.StrCmp(edtavUaviewchildren_gximage, "")==0) ? "" : "GX_Image_"+edtavUaviewchildren_gximage+"_Class");
            StyleString = "";
            AV29UAViewChildren_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV29UAViewChildren))&&String.IsNullOrEmpty(StringUtil.RTrim( AV90Uaviewchildren_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV29UAViewChildren)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV29UAViewChildren)) ? AV90Uaviewchildren_GXI : context.PathToRelativeUrl( AV29UAViewChildren));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUaviewchildren_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)edtavUaviewchildren_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavUaviewchildren_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'DOUAVIEWCHILDREN\\'."+sGXsfl_23_idx+"'",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV29UAViewChildren_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SecFunctionalityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A13SecFunctionalityId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)23,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityKey_Internalname,(string)A15SecFunctionalityKey,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityKey_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)23,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityDescription_Internalname,(string)A20SecFunctionalityDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)23,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbSecFunctionalityType.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SECFUNCTIONALITYTYPE_" + sGXsfl_23_idx;
               cmbSecFunctionalityType.Name = GXCCtl;
               cmbSecFunctionalityType.WebTags = "";
               cmbSecFunctionalityType.addItem("1", context.GetMessage( "Mode", ""), 0);
               cmbSecFunctionalityType.addItem("2", context.GetMessage( "Action", ""), 0);
               cmbSecFunctionalityType.addItem("3", context.GetMessage( "Tab", ""), 0);
               cmbSecFunctionalityType.addItem("4", context.GetMessage( "Object", ""), 0);
               cmbSecFunctionalityType.addItem("5", context.GetMessage( "Attribute", ""), 0);
               if ( cmbSecFunctionalityType.ItemCount > 0 )
               {
                  A21SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cmbSecFunctionalityType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A21SecFunctionalityType), 2, 0))), "."), 18, MidpointRounding.ToEven));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSecFunctionalityType,(string)cmbSecFunctionalityType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A21SecFunctionalityType), 2, 0)),(short)1,(string)cmbSecFunctionalityType_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbSecFunctionalityType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A21SecFunctionalityType), 2, 0));
            AssignProp("", false, cmbSecFunctionalityType_Internalname, "Values", (string)(cmbSecFunctionalityType.ToJavascriptSource()), !bGXsfl_23_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecParentFunctionalityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14SecParentFunctionalityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A14SecParentFunctionalityId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecParentFunctionalityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)23,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecParentFunctionalityDescript_Internalname,(string)A23SecParentFunctionalityDescript,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecParentFunctionalityDescript_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)23,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "SECFUNCTIONALITYACTIVE_" + sGXsfl_23_idx;
            chkSecFunctionalityActive.Name = GXCCtl;
            chkSecFunctionalityActive.WebTags = "";
            chkSecFunctionalityActive.Caption = "";
            AssignProp("", false, chkSecFunctionalityActive_Internalname, "TitleCaption", chkSecFunctionalityActive.Caption, !bGXsfl_23_Refreshing);
            chkSecFunctionalityActive.CheckedValue = "false";
            A19SecFunctionalityActive = StringUtil.StrToBool( StringUtil.BoolToStr( A19SecFunctionalityActive));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkSecFunctionalityActive_Internalname,StringUtil.BoolToStr( A19SecFunctionalityActive),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            send_integrity_lvl_hashes0W2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_23_idx = ((subGrid_Islastpage==1)&&(nGXsfl_23_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_23_idx+1);
            sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
            SubsflControlProps_232( ) ;
         }
         /* End function sendrow_232 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vISASSOCIATED_" + sGXsfl_23_idx;
         chkavIsassociated.Name = GXCCtl;
         chkavIsassociated.WebTags = "";
         chkavIsassociated.Caption = "";
         AssignProp("", false, chkavIsassociated_Internalname, "TitleCaption", chkavIsassociated.Caption, !bGXsfl_23_Refreshing);
         chkavIsassociated.CheckedValue = "false";
         AV18IsAssociated = StringUtil.StrToBool( StringUtil.BoolToStr( AV18IsAssociated));
         AssignAttri("", false, chkavIsassociated_Internalname, AV18IsAssociated);
         GXCCtl = "vISASSOCIATEDOLD_" + sGXsfl_23_idx;
         chkavIsassociatedold.Name = GXCCtl;
         chkavIsassociatedold.WebTags = "";
         chkavIsassociatedold.Caption = "";
         AssignProp("", false, chkavIsassociatedold_Internalname, "TitleCaption", chkavIsassociatedold.Caption, !bGXsfl_23_Refreshing);
         chkavIsassociatedold.CheckedValue = "false";
         AV19IsAssociatedOld = StringUtil.StrToBool( StringUtil.BoolToStr( AV19IsAssociatedOld));
         AssignAttri("", false, chkavIsassociatedold_Internalname, AV19IsAssociatedOld);
         GxWebStd.gx_hidden_field( context, "gxhash_vISASSOCIATEDOLD"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sGXsfl_23_idx, AV19IsAssociatedOld, context));
         GXCCtl = "SECFUNCTIONALITYTYPE_" + sGXsfl_23_idx;
         cmbSecFunctionalityType.Name = GXCCtl;
         cmbSecFunctionalityType.WebTags = "";
         cmbSecFunctionalityType.addItem("1", context.GetMessage( "Mode", ""), 0);
         cmbSecFunctionalityType.addItem("2", context.GetMessage( "Action", ""), 0);
         cmbSecFunctionalityType.addItem("3", context.GetMessage( "Tab", ""), 0);
         cmbSecFunctionalityType.addItem("4", context.GetMessage( "Object", ""), 0);
         cmbSecFunctionalityType.addItem("5", context.GetMessage( "Attribute", ""), 0);
         if ( cmbSecFunctionalityType.ItemCount > 0 )
         {
            A21SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cmbSecFunctionalityType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A21SecFunctionalityType), 2, 0))), "."), 18, MidpointRounding.ToEven));
         }
         GXCCtl = "SECFUNCTIONALITYACTIVE_" + sGXsfl_23_idx;
         chkSecFunctionalityActive.Name = GXCCtl;
         chkSecFunctionalityActive.WebTags = "";
         chkSecFunctionalityActive.Caption = "";
         AssignProp("", false, chkSecFunctionalityActive_Internalname, "TitleCaption", chkSecFunctionalityActive.Caption, !bGXsfl_23_Refreshing);
         chkSecFunctionalityActive.CheckedValue = "false";
         A19SecFunctionalityActive = StringUtil.StrToBool( StringUtil.BoolToStr( A19SecFunctionalityActive));
         /* End function init_web_controls */
      }

      protected void StartGridControl23( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"23\">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavUaviewchildren_Class+" "+((StringUtil.StrCmp(edtavUaviewchildren_gximage, "")==0) ? "" : "GX_Image_"+edtavUaviewchildren_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Key", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Description", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Type", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Parent Functionality Id  ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Parent Functionality", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Is Active?", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV18IsAssociated)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV19IsAssociatedOld)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavIsassociatedold.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV29UAViewChildren));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavUaviewchildren_Class));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUaviewchildren_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SecFunctionalityId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A15SecFunctionalityKey));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A20SecFunctionalityDescription));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A21SecFunctionalityType), 2, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A14SecParentFunctionalityId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A23SecParentFunctionalityDescript));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A19SecFunctionalityActive)));
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
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         chkavIsassociated_Internalname = "vISASSOCIATED";
         chkavIsassociatedold_Internalname = "vISASSOCIATEDOLD";
         edtavUaviewchildren_Internalname = "vUAVIEWCHILDREN";
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID";
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY";
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION";
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE";
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID";
         edtSecParentFunctionalityDescript_Internalname = "SECPARENTFUNCTIONALITYDESCRIPT";
         chkSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         bttBtnconfirm_Internalname = "BTNCONFIRM";
         bttBtncancel_Internalname = "BTNCANCEL";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Dvelop_confirmpanel_uaviewchildren_Internalname = "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN";
         tblTabledvelop_confirmpanel_uaviewchildren_Internalname = "TABLEDVELOP_CONFIRMPANEL_UAVIEWCHILDREN";
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
         chkSecFunctionalityActive.Caption = "";
         edtSecParentFunctionalityDescript_Jsonclick = "";
         edtSecParentFunctionalityId_Jsonclick = "";
         cmbSecFunctionalityType_Jsonclick = "";
         edtSecFunctionalityDescription_Jsonclick = "";
         edtSecFunctionalityKey_Jsonclick = "";
         edtSecFunctionalityId_Jsonclick = "";
         edtavUaviewchildren_Jsonclick = "";
         edtavUaviewchildren_gximage = "";
         edtavUaviewchildren_Class = "ActionBaseColorAttribute";
         edtavUaviewchildren_Tooltiptext = context.GetMessage( "View Actions, Tabs and Modes", "");
         chkavIsassociatedold.Caption = "";
         chkavIsassociatedold.Enabled = 1;
         chkavIsassociated.Caption = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         chkSecFunctionalityActive.Enabled = 0;
         edtSecParentFunctionalityDescript_Enabled = 0;
         edtSecParentFunctionalityId_Enabled = 0;
         cmbSecFunctionalityType.Enabled = 0;
         edtSecFunctionalityDescription_Enabled = 0;
         edtSecFunctionalityKey_Enabled = 0;
         edtSecFunctionalityId_Enabled = 0;
         subGrid_Sortable = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_uaviewchildren_Confirmtype = "1";
         Dvelop_confirmpanel_uaviewchildren_Yesbuttonposition = "left";
         Dvelop_confirmpanel_uaviewchildren_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_uaviewchildren_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_uaviewchildren_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_uaviewchildren_Confirmationtext = "You will lose the changes made. Are you sure you want to continue?";
         Dvelop_confirmpanel_uaviewchildren_Title = context.GetMessage( "Confirmation of loss changes", "");
         Ddo_grid_Datalistproc = "WWPBaseObjects.SecRoleFunRoleAssociationWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|||";
         Ddo_grid_Includedatalist = "T|||";
         Ddo_grid_Filtertype = "Character|||";
         Ddo_grid_Includefilter = "T|||";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4";
         Ddo_grid_Columnids = "4:SecFunctionalityKey|5:SecFunctionalityDescription|6:SecFunctionalityType|8:SecParentFunctionalityDescription";
         Ddo_grid_Gridinternalname = "";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
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
         Form.Caption = context.GetMessage( "Asociados a Role", "");
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'A16SecRoleId',fld:'SECROLEID',pic:'ZZZ9',type:'int'},{av:'AV21i',fld:'vI',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV11SecFunctionalityIdRemoved',fld:'vSECFUNCTIONALITYIDREMOVED',pic:''},{av:'AV15SecFunctionalityIdToFind',fld:'vSECFUNCTIONALITYIDTOFIND',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV10SecFunctionalityIdAdded',fld:'vSECFUNCTIONALITYIDADDED',pic:''},{av:'AV87ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV39OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV84FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV89Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV60TFSecFunctionalityKey',fld:'vTFSECFUNCTIONALITYKEY',pic:'',type:'svchar'},{av:'AV61TFSecFunctionalityKey_Sel',fld:'vTFSECFUNCTIONALITYKEY_SEL',pic:'',type:'svchar'},{av:'AV13SecFunctionalityIdRemovedXml',fld:'vSECFUNCTIONALITYIDREMOVEDXML',pic:'',type:'vchar'},{av:'AV12SecFunctionalityIdAddedXml',fld:'vSECFUNCTIONALITYIDADDEDXML',pic:'',type:'vchar'},{av:'AV9SecRoleId',fld:'vSECROLEID',pic:'ZZZ9',hsh:true,type:'int'},{av:'AV34SecRoleIdParm',fld:'vSECROLEIDPARM',pic:'ZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV87ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV81GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV82GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV83GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV85ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV35GridState',fld:'vGRIDSTATE',pic:''},{av:'AV11SecFunctionalityIdRemoved',fld:'vSECFUNCTIONALITYIDREMOVED',pic:''},{av:'AV10SecFunctionalityIdAdded',fld:'vSECFUNCTIONALITYIDADDED',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E110W2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV39OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV84FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV87ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV89Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV60TFSecFunctionalityKey',fld:'vTFSECFUNCTIONALITYKEY',pic:'',type:'svchar'},{av:'AV61TFSecFunctionalityKey_Sel',fld:'vTFSECFUNCTIONALITYKEY_SEL',pic:'',type:'svchar'},{av:'AV13SecFunctionalityIdRemovedXml',fld:'vSECFUNCTIONALITYIDREMOVEDXML',pic:'',type:'vchar'},{av:'AV12SecFunctionalityIdAddedXml',fld:'vSECFUNCTIONALITYIDADDEDXML',pic:'',type:'vchar'},{av:'AV9SecRoleId',fld:'vSECROLEID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A16SecRoleId',fld:'SECROLEID',pic:'ZZZ9',type:'int'},{av:'AV21i',fld:'vI',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV11SecFunctionalityIdRemoved',fld:'vSECFUNCTIONALITYIDREMOVED',pic:''},{av:'AV15SecFunctionalityIdToFind',fld:'vSECFUNCTIONALITYIDTOFIND',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV10SecFunctionalityIdAdded',fld:'vSECFUNCTIONALITYIDADDED',pic:''},{av:'AV34SecRoleIdParm',fld:'vSECROLEIDPARM',pic:'ZZZ9',hsh:true,type:'int'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV87ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV81GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV82GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV83GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV85ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV35GridState',fld:'vGRIDSTATE',pic:''},{av:'AV11SecFunctionalityIdRemoved',fld:'vSECFUNCTIONALITYIDREMOVED',pic:''},{av:'AV10SecFunctionalityIdAdded',fld:'vSECFUNCTIONALITYIDADDED',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E120W2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV39OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV84FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV87ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV89Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV60TFSecFunctionalityKey',fld:'vTFSECFUNCTIONALITYKEY',pic:'',type:'svchar'},{av:'AV61TFSecFunctionalityKey_Sel',fld:'vTFSECFUNCTIONALITYKEY_SEL',pic:'',type:'svchar'},{av:'AV13SecFunctionalityIdRemovedXml',fld:'vSECFUNCTIONALITYIDREMOVEDXML',pic:'',type:'vchar'},{av:'AV12SecFunctionalityIdAddedXml',fld:'vSECFUNCTIONALITYIDADDEDXML',pic:'',type:'vchar'},{av:'AV9SecRoleId',fld:'vSECROLEID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A16SecRoleId',fld:'SECROLEID',pic:'ZZZ9',type:'int'},{av:'AV21i',fld:'vI',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV11SecFunctionalityIdRemoved',fld:'vSECFUNCTIONALITYIDREMOVED',pic:''},{av:'AV15SecFunctionalityIdToFind',fld:'vSECFUNCTIONALITYIDTOFIND',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV10SecFunctionalityIdAdded',fld:'vSECFUNCTIONALITYIDADDED',pic:''},{av:'AV34SecRoleIdParm',fld:'vSECROLEIDPARM',pic:'ZZZ9',hsh:true,type:'int'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E140W2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV39OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV84FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV87ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV89Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV60TFSecFunctionalityKey',fld:'vTFSECFUNCTIONALITYKEY',pic:'',type:'svchar'},{av:'AV61TFSecFunctionalityKey_Sel',fld:'vTFSECFUNCTIONALITYKEY_SEL',pic:'',type:'svchar'},{av:'AV13SecFunctionalityIdRemovedXml',fld:'vSECFUNCTIONALITYIDREMOVEDXML',pic:'',type:'vchar'},{av:'AV12SecFunctionalityIdAddedXml',fld:'vSECFUNCTIONALITYIDADDEDXML',pic:'',type:'vchar'},{av:'AV9SecRoleId',fld:'vSECROLEID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A16SecRoleId',fld:'SECROLEID',pic:'ZZZ9',type:'int'},{av:'AV21i',fld:'vI',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV11SecFunctionalityIdRemoved',fld:'vSECFUNCTIONALITYIDREMOVED',pic:''},{av:'AV15SecFunctionalityIdToFind',fld:'vSECFUNCTIONALITYIDTOFIND',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV10SecFunctionalityIdAdded',fld:'vSECFUNCTIONALITYIDADDED',pic:''},{av:'AV34SecRoleIdParm',fld:'vSECROLEIDPARM',pic:'ZZZ9',hsh:true,type:'int'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV38OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV39OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV60TFSecFunctionalityKey',fld:'vTFSECFUNCTIONALITYKEY',pic:'',type:'svchar'},{av:'AV61TFSecFunctionalityKey_Sel',fld:'vTFSECFUNCTIONALITYKEY_SEL',pic:'',type:'svchar'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E190W2',iparms:[{av:'A13SecFunctionalityId',fld:'SECFUNCTIONALITYID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV9SecRoleId',fld:'vSECROLEID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A16SecRoleId',fld:'SECROLEID',pic:'ZZZ9',type:'int'},{av:'AV21i',fld:'vI',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV11SecFunctionalityIdRemoved',fld:'vSECFUNCTIONALITYIDREMOVED',pic:''},{av:'AV15SecFunctionalityIdToFind',fld:'vSECFUNCTIONALITYIDTOFIND',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV10SecFunctionalityIdAdded',fld:'vSECFUNCTIONALITYIDADDED',pic:''},{av:'AV84FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV34SecRoleIdParm',fld:'vSECROLEIDPARM',pic:'ZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV29UAViewChildren',fld:'vUAVIEWCHILDREN',pic:'',type:'bits'},{av:'edtavUaviewchildren_Tooltiptext',ctrl:'vUAVIEWCHILDREN',prop:'Tooltiptext'},{av:'edtavUaviewchildren_Class',ctrl:'vUAVIEWCHILDREN',prop:'Class'},{av:'AV34SecRoleIdParm',fld:'vSECROLEIDPARM',pic:'ZZZ9',hsh:true,type:'int'},{av:'AV19IsAssociatedOld',fld:'vISASSOCIATEDOLD',pic:'',hsh:true,type:'boolean'},{av:'AV15SecFunctionalityIdToFind',fld:'vSECFUNCTIONALITYIDTOFIND',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV18IsAssociated',fld:'vISASSOCIATED',pic:'',type:'boolean'},{av:'AV21i',fld:'vI',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("ENTER","{handler:'E160W2',iparms:[{av:'AV11SecFunctionalityIdRemoved',fld:'vSECFUNCTIONALITYIDREMOVED',pic:''},{av:'AV9SecRoleId',fld:'vSECROLEID',pic:'ZZZ9',hsh:true,type:'int'},{av:'AV10SecFunctionalityIdAdded',fld:'vSECFUNCTIONALITYIDADDED',pic:''},{av:'AV13SecFunctionalityIdRemovedXml',fld:'vSECFUNCTIONALITYIDREMOVEDXML',pic:'',type:'vchar'},{av:'AV12SecFunctionalityIdAddedXml',fld:'vSECFUNCTIONALITYIDADDEDXML',pic:'',type:'vchar'},{av:'AV16SecFunctionalityRole',fld:'vSECFUNCTIONALITYROLE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV21i',fld:'vI',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV16SecFunctionalityRole',fld:'vSECFUNCTIONALITYROLE',pic:''},{av:'AV12SecFunctionalityIdAddedXml',fld:'vSECFUNCTIONALITYIDADDEDXML',pic:'',type:'vchar'},{av:'AV13SecFunctionalityIdRemovedXml',fld:'vSECFUNCTIONALITYIDREMOVEDXML',pic:'',type:'vchar'},{av:'AV11SecFunctionalityIdRemoved',fld:'vSECFUNCTIONALITYIDREMOVED',pic:''},{av:'AV10SecFunctionalityIdAdded',fld:'vSECFUNCTIONALITYIDADDED',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E130W2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV39OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV84FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV87ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV89Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV60TFSecFunctionalityKey',fld:'vTFSECFUNCTIONALITYKEY',pic:'',type:'svchar'},{av:'AV61TFSecFunctionalityKey_Sel',fld:'vTFSECFUNCTIONALITYKEY_SEL',pic:'',type:'svchar'},{av:'AV13SecFunctionalityIdRemovedXml',fld:'vSECFUNCTIONALITYIDREMOVEDXML',pic:'',type:'vchar'},{av:'AV12SecFunctionalityIdAddedXml',fld:'vSECFUNCTIONALITYIDADDEDXML',pic:'',type:'vchar'},{av:'AV9SecRoleId',fld:'vSECROLEID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A16SecRoleId',fld:'SECROLEID',pic:'ZZZ9',type:'int'},{av:'AV21i',fld:'vI',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV11SecFunctionalityIdRemoved',fld:'vSECFUNCTIONALITYIDREMOVED',pic:''},{av:'AV15SecFunctionalityIdToFind',fld:'vSECFUNCTIONALITYIDTOFIND',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV10SecFunctionalityIdAdded',fld:'vSECFUNCTIONALITYIDADDED',pic:''},{av:'AV34SecRoleIdParm',fld:'vSECROLEIDPARM',pic:'ZZZ9',hsh:true,type:'int'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV35GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV87ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35GridState',fld:'vGRIDSTATE',pic:''},{av:'AV38OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV39OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV84FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV60TFSecFunctionalityKey',fld:'vTFSECFUNCTIONALITYKEY',pic:'',type:'svchar'},{av:'AV61TFSecFunctionalityKey_Sel',fld:'vTFSECFUNCTIONALITYKEY_SEL',pic:'',type:'svchar'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV81GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV82GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV83GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV85ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11SecFunctionalityIdRemoved',fld:'vSECFUNCTIONALITYIDREMOVED',pic:''},{av:'AV10SecFunctionalityIdAdded',fld:'vSECFUNCTIONALITYIDADDED',pic:''}]}");
         setEventMetadata("'DOUAVIEWCHILDREN'","{handler:'E200W2',iparms:[{av:'AV10SecFunctionalityIdAdded',fld:'vSECFUNCTIONALITYIDADDED',pic:''},{av:'AV11SecFunctionalityIdRemoved',fld:'vSECFUNCTIONALITYIDREMOVED',pic:''},{av:'A13SecFunctionalityId',fld:'SECFUNCTIONALITYID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV9SecRoleId',fld:'vSECROLEID',pic:'ZZZ9',hsh:true,type:'int'},{av:'AV13SecFunctionalityIdRemovedXml',fld:'vSECFUNCTIONALITYIDREMOVEDXML',pic:'',type:'vchar'},{av:'AV12SecFunctionalityIdAddedXml',fld:'vSECFUNCTIONALITYIDADDEDXML',pic:'',type:'vchar'},{av:'AV33SecFunctionalityId_Selected',fld:'vSECFUNCTIONALITYID_SELECTED',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOUAVIEWCHILDREN'",",oparms:[{av:'AV33SecFunctionalityId_Selected',fld:'vSECFUNCTIONALITYID_SELECTED',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV11SecFunctionalityIdRemoved',fld:'vSECFUNCTIONALITYIDREMOVED',pic:''},{av:'AV10SecFunctionalityIdAdded',fld:'vSECFUNCTIONALITYIDADDED',pic:''}]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_UAVIEWCHILDREN.CLOSE","{handler:'E150W2',iparms:[{av:'Dvelop_confirmpanel_uaviewchildren_Result',ctrl:'DVELOP_CONFIRMPANEL_UAVIEWCHILDREN',prop:'Result'},{av:'AV9SecRoleId',fld:'vSECROLEID',pic:'ZZZ9',hsh:true,type:'int'},{av:'AV33SecFunctionalityId_Selected',fld:'vSECFUNCTIONALITYID_SELECTED',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_UAVIEWCHILDREN.CLOSE",",oparms:[]}");
         setEventMetadata("VISASSOCIATED.CLICK","{handler:'E210W2',iparms:[{av:'A13SecFunctionalityId',fld:'SECFUNCTIONALITYID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV18IsAssociated',fld:'vISASSOCIATED',pic:'',type:'boolean'},{av:'AV19IsAssociatedOld',fld:'vISASSOCIATEDOLD',pic:'',hsh:true,type:'boolean'},{av:'AV21i',fld:'vI',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV11SecFunctionalityIdRemoved',fld:'vSECFUNCTIONALITYIDREMOVED',pic:''},{av:'AV10SecFunctionalityIdAdded',fld:'vSECFUNCTIONALITYIDADDED',pic:''},{av:'AV13SecFunctionalityIdRemovedXml',fld:'vSECFUNCTIONALITYIDREMOVEDXML',pic:'',type:'vchar'},{av:'AV12SecFunctionalityIdAddedXml',fld:'vSECFUNCTIONALITYIDADDEDXML',pic:'',type:'vchar'},{av:'AV15SecFunctionalityIdToFind',fld:'vSECFUNCTIONALITYIDTOFIND',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VISASSOCIATED.CLICK",",oparms:[{av:'AV15SecFunctionalityIdToFind',fld:'vSECFUNCTIONALITYIDTOFIND',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV11SecFunctionalityIdRemoved',fld:'vSECFUNCTIONALITYIDREMOVED',pic:''},{av:'AV10SecFunctionalityIdAdded',fld:'vSECFUNCTIONALITYIDADDED',pic:''},{av:'AV21i',fld:'vI',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV13SecFunctionalityIdRemovedXml',fld:'vSECFUNCTIONALITYIDREMOVEDXML',pic:'',type:'vchar'},{av:'AV12SecFunctionalityIdAddedXml',fld:'vSECFUNCTIONALITYIDADDEDXML',pic:'',type:'vchar'}]}");
         setEventMetadata("VALID_SECFUNCTIONALITYID","{handler:'Valid_Secfunctionalityid',iparms:[]");
         setEventMetadata("VALID_SECFUNCTIONALITYID",",oparms:[]}");
         setEventMetadata("VALID_SECFUNCTIONALITYKEY","{handler:'Valid_Secfunctionalitykey',iparms:[]");
         setEventMetadata("VALID_SECFUNCTIONALITYKEY",",oparms:[]}");
         setEventMetadata("VALID_SECFUNCTIONALITYDESCRIPTION","{handler:'Valid_Secfunctionalitydescription',iparms:[]");
         setEventMetadata("VALID_SECFUNCTIONALITYDESCRIPTION",",oparms:[]}");
         setEventMetadata("VALID_SECFUNCTIONALITYTYPE","{handler:'Valid_Secfunctionalitytype',iparms:[]");
         setEventMetadata("VALID_SECFUNCTIONALITYTYPE",",oparms:[]}");
         setEventMetadata("VALID_SECPARENTFUNCTIONALITYID","{handler:'Valid_Secparentfunctionalityid',iparms:[]");
         setEventMetadata("VALID_SECPARENTFUNCTIONALITYID",",oparms:[]}");
         setEventMetadata("VALID_SECPARENTFUNCTIONALITYDESCRIPT","{handler:'Valid_Secparentfunctionalitydescript',iparms:[]");
         setEventMetadata("VALID_SECPARENTFUNCTIONALITYDESCRIPT",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Secfunctionalityactive',iparms:[]");
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
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_uaviewchildren_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV84FilterFullText = "";
         AV89Pgmname = "";
         AV60TFSecFunctionalityKey = "";
         AV61TFSecFunctionalityKey_Sel = "";
         AV13SecFunctionalityIdRemovedXml = "";
         AV12SecFunctionalityIdAddedXml = "";
         AV11SecFunctionalityIdRemoved = new GxSimpleCollection<long>();
         AV10SecFunctionalityIdAdded = new GxSimpleCollection<long>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV83GridAppliedFilters = "";
         AV85ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV74DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV16SecFunctionalityRole = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole(context);
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         TempTags = "";
         bttBtnconfirm_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV29UAViewChildren = "";
         AV90Uaviewchildren_GXI = "";
         A15SecFunctionalityKey = "";
         A20SecFunctionalityDescription = "";
         A23SecParentFunctionalityDescript = "";
         GXDecQS = "";
         lV84FilterFullText = "";
         lV60TFSecFunctionalityKey = "";
         H000W2_A13SecFunctionalityId = new long[1] ;
         H000W2_A23SecParentFunctionalityDescript = new string[] {""} ;
         H000W2_A21SecFunctionalityType = new short[1] ;
         H000W2_A20SecFunctionalityDescription = new string[] {""} ;
         H000W2_A15SecFunctionalityKey = new string[] {""} ;
         H000W2_A19SecFunctionalityActive = new bool[] {false} ;
         H000W2_A14SecParentFunctionalityId = new long[1] ;
         H000W2_n14SecParentFunctionalityId = new bool[] {false} ;
         H000W3_A13SecFunctionalityId = new long[1] ;
         H000W3_A23SecParentFunctionalityDescript = new string[] {""} ;
         H000W3_A21SecFunctionalityType = new short[1] ;
         H000W3_A20SecFunctionalityDescription = new string[] {""} ;
         H000W3_A15SecFunctionalityKey = new string[] {""} ;
         H000W3_A19SecFunctionalityActive = new bool[] {false} ;
         H000W3_A14SecParentFunctionalityId = new long[1] ;
         H000W3_n14SecParentFunctionalityId = new bool[] {false} ;
         AV22HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         H000W4_A16SecRoleId = new short[1] ;
         H000W4_A25SecRoleName = new string[] {""} ;
         A25SecRoleName = "";
         AV77WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H000W5_A13SecFunctionalityId = new long[1] ;
         H000W5_A16SecRoleId = new short[1] ;
         GridRow = new GXWebRow();
         AV86ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV28Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         AV97GXV6 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV20Message = new GeneXus.Utils.SdtMessages_Message(context);
         ucDvelop_confirmpanel_uaviewchildren = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         sImgUrl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secrolefunroleassociationww__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secrolefunroleassociationww__default(),
            new Object[][] {
                new Object[] {
               H000W2_A13SecFunctionalityId, H000W2_A23SecParentFunctionalityDescript, H000W2_A21SecFunctionalityType, H000W2_A20SecFunctionalityDescription, H000W2_A15SecFunctionalityKey, H000W2_A19SecFunctionalityActive, H000W2_A14SecParentFunctionalityId, H000W2_n14SecParentFunctionalityId
               }
               , new Object[] {
               H000W3_A13SecFunctionalityId, H000W3_A23SecParentFunctionalityDescript, H000W3_A21SecFunctionalityType, H000W3_A20SecFunctionalityDescription, H000W3_A15SecFunctionalityKey, H000W3_A19SecFunctionalityActive, H000W3_A14SecParentFunctionalityId, H000W3_n14SecParentFunctionalityId
               }
               , new Object[] {
               H000W4_A16SecRoleId, H000W4_A25SecRoleName
               }
               , new Object[] {
               H000W5_A13SecFunctionalityId, H000W5_A16SecRoleId
               }
            }
         );
         AV89Pgmname = "WWPBaseObjects.SecRoleFunRoleAssociationWW";
         /* GeneXus formulas. */
         AV89Pgmname = "WWPBaseObjects.SecRoleFunRoleAssociationWW";
         chkavIsassociatedold.Enabled = 0;
      }

      private short AV9SecRoleId ;
      private short wcpOAV9SecRoleId ;
      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV38OrderedBy ;
      private short AV87ManageFiltersExecutionStep ;
      private short A16SecRoleId ;
      private short AV34SecRoleIdParm ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A21SecFunctionalityType ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV32SecRoleId_Selected ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_23 ;
      private int nGXsfl_23_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Islastpage ;
      private int edtSecFunctionalityId_Enabled ;
      private int edtSecFunctionalityKey_Enabled ;
      private int edtSecFunctionalityDescription_Enabled ;
      private int edtSecParentFunctionalityId_Enabled ;
      private int edtSecParentFunctionalityDescript_Enabled ;
      private int AV80PageToGo ;
      private int AV92GXV1 ;
      private int AV93GXV2 ;
      private int AV94GXV3 ;
      private int AV95GXV4 ;
      private int AV96GXV5 ;
      private int AV98GXV7 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV21i ;
      private long AV15SecFunctionalityIdToFind ;
      private long AV81GridCurrentPage ;
      private long AV82GridPageCount ;
      private long AV33SecFunctionalityId_Selected ;
      private long A13SecFunctionalityId ;
      private long A14SecParentFunctionalityId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long AV14SecFunctionalityId ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_uaviewchildren_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_23_idx="0001" ;
      private string AV89Pgmname ;
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
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
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
      private string Dvelop_confirmpanel_uaviewchildren_Title ;
      private string Dvelop_confirmpanel_uaviewchildren_Confirmationtext ;
      private string Dvelop_confirmpanel_uaviewchildren_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_uaviewchildren_Nobuttoncaption ;
      private string Dvelop_confirmpanel_uaviewchildren_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_uaviewchildren_Yesbuttonposition ;
      private string Dvelop_confirmpanel_uaviewchildren_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string TempTags ;
      private string bttBtnconfirm_Internalname ;
      private string bttBtnconfirm_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavIsassociated_Internalname ;
      private string chkavIsassociatedold_Internalname ;
      private string edtavUaviewchildren_Internalname ;
      private string edtSecFunctionalityId_Internalname ;
      private string edtSecFunctionalityKey_Internalname ;
      private string edtSecFunctionalityDescription_Internalname ;
      private string cmbSecFunctionalityType_Internalname ;
      private string edtSecParentFunctionalityId_Internalname ;
      private string edtSecParentFunctionalityDescript_Internalname ;
      private string chkSecFunctionalityActive_Internalname ;
      private string GXDecQS ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavUaviewchildren_gximage ;
      private string edtavUaviewchildren_Tooltiptext ;
      private string edtavUaviewchildren_Class ;
      private string GXt_char2 ;
      private string tblTabledvelop_confirmpanel_uaviewchildren_Internalname ;
      private string Dvelop_confirmpanel_uaviewchildren_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_23_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string sImgUrl ;
      private string edtavUaviewchildren_Jsonclick ;
      private string ROClassString ;
      private string edtSecFunctionalityId_Jsonclick ;
      private string edtSecFunctionalityKey_Jsonclick ;
      private string edtSecFunctionalityDescription_Jsonclick ;
      private string cmbSecFunctionalityType_Jsonclick ;
      private string edtSecParentFunctionalityId_Jsonclick ;
      private string edtSecParentFunctionalityDescript_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV39OrderedDsc ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV18IsAssociated ;
      private bool AV19IsAssociatedOld ;
      private bool bGXsfl_23_Refreshing=false ;
      private bool n14SecParentFunctionalityId ;
      private bool A19SecFunctionalityActive ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV31TempBoolean ;
      private bool GXt_boolean3 ;
      private bool AV17Success ;
      private bool AV29UAViewChildren_IsBlob ;
      private string AV13SecFunctionalityIdRemovedXml ;
      private string AV12SecFunctionalityIdAddedXml ;
      private string AV86ManageFiltersXml ;
      private string AV84FilterFullText ;
      private string AV60TFSecFunctionalityKey ;
      private string AV61TFSecFunctionalityKey_Sel ;
      private string AV83GridAppliedFilters ;
      private string AV90Uaviewchildren_GXI ;
      private string A15SecFunctionalityKey ;
      private string A20SecFunctionalityDescription ;
      private string A23SecParentFunctionalityDescript ;
      private string lV84FilterFullText ;
      private string lV60TFSecFunctionalityKey ;
      private string A25SecRoleName ;
      private string AV29UAViewChildren ;
      private IGxSession AV28Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_uaviewchildren ;
      private GxHttpRequest AV22HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavIsassociated ;
      private GXCheckbox chkavIsassociatedold ;
      private GXCombobox cmbSecFunctionalityType ;
      private GXCheckbox chkSecFunctionalityActive ;
      private GxSimpleCollection<long> AV11SecFunctionalityIdRemoved ;
      private GxSimpleCollection<long> AV10SecFunctionalityIdAdded ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV85ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV74DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole AV16SecFunctionalityRole ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private IDataStoreProvider pr_default ;
      private long[] H000W2_A13SecFunctionalityId ;
      private string[] H000W2_A23SecParentFunctionalityDescript ;
      private short[] H000W2_A21SecFunctionalityType ;
      private string[] H000W2_A20SecFunctionalityDescription ;
      private string[] H000W2_A15SecFunctionalityKey ;
      private bool[] H000W2_A19SecFunctionalityActive ;
      private long[] H000W2_A14SecParentFunctionalityId ;
      private bool[] H000W2_n14SecParentFunctionalityId ;
      private long[] H000W3_A13SecFunctionalityId ;
      private string[] H000W3_A23SecParentFunctionalityDescript ;
      private short[] H000W3_A21SecFunctionalityType ;
      private string[] H000W3_A20SecFunctionalityDescription ;
      private string[] H000W3_A15SecFunctionalityKey ;
      private bool[] H000W3_A19SecFunctionalityActive ;
      private long[] H000W3_A14SecParentFunctionalityId ;
      private bool[] H000W3_n14SecParentFunctionalityId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private short[] H000W4_A16SecRoleId ;
      private string[] H000W4_A25SecRoleName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV77WWPContext ;
      private long[] H000W5_A13SecFunctionalityId ;
      private short[] H000W5_A16SecRoleId ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV97GXV6 ;
      private GeneXus.Utils.SdtMessages_Message AV20Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class secrolefunroleassociationww__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class secrolefunroleassociationww__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H000W2( IGxContext context ,
                                           string AV61TFSecFunctionalityKey_Sel ,
                                           string AV60TFSecFunctionalityKey ,
                                           string A15SecFunctionalityKey ,
                                           short AV38OrderedBy ,
                                           bool AV39OrderedDsc ,
                                           string AV84FilterFullText ,
                                           string A20SecFunctionalityDescription ,
                                           short A21SecFunctionalityType ,
                                           string A23SecParentFunctionalityDescript )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int5 = new short[2];
       Object[] GXv_Object6 = new Object[2];
       scmdbuf = "SELECT T1.[SecFunctionalityId], T2.[SecFunctionalityDescription] AS SecParentFunctionalityDescript, T1.[SecFunctionalityType], T1.[SecFunctionalityDescription], T1.[SecFunctionalityKey], T1.[SecFunctionalityActive], T1.[SecParentFunctionalityId] AS SecParentFunctionalityId FROM ([SecFunctionality] T1 LEFT JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = T1.[SecParentFunctionalityId])";
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFSecFunctionalityKey_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TFSecFunctionalityKey)) ) )
       {
          AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityKey]) like UPPER(@lV60TFSecFunctionalityKey))");
       }
       else
       {
          GXv_int5[0] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFSecFunctionalityKey_Sel)) && ! ( StringUtil.StrCmp(AV61TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T1.[SecFunctionalityKey] = @AV61TFSecFunctionalityKey_Sel)");
       }
       else
       {
          GXv_int5[1] = 1;
       }
       if ( StringUtil.StrCmp(AV61TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "((T1.[SecFunctionalityKey] = ''))");
       }
       scmdbuf += sWhereString;
       if ( ( AV38OrderedBy == 1 ) && ! AV39OrderedDsc )
       {
          scmdbuf += " ORDER BY T1.[SecFunctionalityKey]";
       }
       else if ( ( AV38OrderedBy == 1 ) && ( AV39OrderedDsc ) )
       {
          scmdbuf += " ORDER BY T1.[SecFunctionalityKey] DESC";
       }
       else if ( ( AV38OrderedBy == 2 ) && ! AV39OrderedDsc )
       {
          scmdbuf += " ORDER BY T1.[SecFunctionalityDescription]";
       }
       else if ( ( AV38OrderedBy == 2 ) && ( AV39OrderedDsc ) )
       {
          scmdbuf += " ORDER BY T1.[SecFunctionalityDescription] DESC";
       }
       else if ( ( AV38OrderedBy == 3 ) && ! AV39OrderedDsc )
       {
          scmdbuf += " ORDER BY T1.[SecFunctionalityType]";
       }
       else if ( ( AV38OrderedBy == 3 ) && ( AV39OrderedDsc ) )
       {
          scmdbuf += " ORDER BY T1.[SecFunctionalityType] DESC";
       }
       else if ( ( AV38OrderedBy == 4 ) && ! AV39OrderedDsc )
       {
          scmdbuf += " ORDER BY T2.[SecFunctionalityDescription]";
       }
       else if ( ( AV38OrderedBy == 4 ) && ( AV39OrderedDsc ) )
       {
          scmdbuf += " ORDER BY T2.[SecFunctionalityDescription] DESC";
       }
       GXv_Object6[0] = scmdbuf;
       GXv_Object6[1] = GXv_int5;
       return GXv_Object6 ;
    }

    protected Object[] conditional_H000W3( IGxContext context ,
                                           string AV61TFSecFunctionalityKey_Sel ,
                                           string AV60TFSecFunctionalityKey ,
                                           string A15SecFunctionalityKey ,
                                           short AV38OrderedBy ,
                                           bool AV39OrderedDsc ,
                                           string AV84FilterFullText ,
                                           string A20SecFunctionalityDescription ,
                                           short A21SecFunctionalityType ,
                                           string A23SecParentFunctionalityDescript )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int7 = new short[2];
       Object[] GXv_Object8 = new Object[2];
       scmdbuf = "SELECT T1.[SecFunctionalityId], T2.[SecFunctionalityDescription] AS SecParentFunctionalityDescript, T1.[SecFunctionalityType], T1.[SecFunctionalityDescription], T1.[SecFunctionalityKey], T1.[SecFunctionalityActive], T1.[SecParentFunctionalityId] AS SecParentFunctionalityId FROM ([SecFunctionality] T1 LEFT JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = T1.[SecParentFunctionalityId])";
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFSecFunctionalityKey_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TFSecFunctionalityKey)) ) )
       {
          AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityKey]) like UPPER(@lV60TFSecFunctionalityKey))");
       }
       else
       {
          GXv_int7[0] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFSecFunctionalityKey_Sel)) && ! ( StringUtil.StrCmp(AV61TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T1.[SecFunctionalityKey] = @AV61TFSecFunctionalityKey_Sel)");
       }
       else
       {
          GXv_int7[1] = 1;
       }
       if ( StringUtil.StrCmp(AV61TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "((T1.[SecFunctionalityKey] = ''))");
       }
       scmdbuf += sWhereString;
       if ( ( AV38OrderedBy == 1 ) && ! AV39OrderedDsc )
       {
          scmdbuf += " ORDER BY T1.[SecFunctionalityKey]";
       }
       else if ( ( AV38OrderedBy == 1 ) && ( AV39OrderedDsc ) )
       {
          scmdbuf += " ORDER BY T1.[SecFunctionalityKey] DESC";
       }
       else if ( ( AV38OrderedBy == 2 ) && ! AV39OrderedDsc )
       {
          scmdbuf += " ORDER BY T1.[SecFunctionalityDescription]";
       }
       else if ( ( AV38OrderedBy == 2 ) && ( AV39OrderedDsc ) )
       {
          scmdbuf += " ORDER BY T1.[SecFunctionalityDescription] DESC";
       }
       else if ( ( AV38OrderedBy == 3 ) && ! AV39OrderedDsc )
       {
          scmdbuf += " ORDER BY T1.[SecFunctionalityType]";
       }
       else if ( ( AV38OrderedBy == 3 ) && ( AV39OrderedDsc ) )
       {
          scmdbuf += " ORDER BY T1.[SecFunctionalityType] DESC";
       }
       else if ( ( AV38OrderedBy == 4 ) && ! AV39OrderedDsc )
       {
          scmdbuf += " ORDER BY T2.[SecFunctionalityDescription]";
       }
       else if ( ( AV38OrderedBy == 4 ) && ( AV39OrderedDsc ) )
       {
          scmdbuf += " ORDER BY T2.[SecFunctionalityDescription] DESC";
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
                   return conditional_H000W2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] );
             case 1 :
                   return conditional_H000W3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH000W4;
        prmH000W4 = new Object[] {
        new ParDef("@AV9SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmH000W5;
        prmH000W5 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0) ,
        new ParDef("@AV34SecRoleIdParm",GXType.Int16,4,0)
        };
        Object[] prmH000W2;
        prmH000W2 = new Object[] {
        new ParDef("@lV60TFSecFunctionalityKey",GXType.VarChar,100,0) ,
        new ParDef("@AV61TFSecFunctionalityKey_Sel",GXType.NVarChar,100,0)
        };
        Object[] prmH000W3;
        prmH000W3 = new Object[] {
        new ParDef("@lV60TFSecFunctionalityKey",GXType.VarChar,100,0) ,
        new ParDef("@AV61TFSecFunctionalityKey_Sel",GXType.NVarChar,100,0)
        };
        def= new CursorDef[] {
            new CursorDef("H000W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000W2,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H000W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000W3,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H000W4", "SELECT [SecRoleId], [SecRoleName] FROM [SecRole] WHERE [SecRoleId] = @AV9SecRoleId ORDER BY [SecRoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000W4,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H000W5", "SELECT [SecFunctionalityId], [SecRoleId] FROM [SecFunctionalityRole] WHERE [SecFunctionalityId] = @SecFunctionalityId and [SecRoleId] = @AV34SecRoleIdParm ORDER BY [SecFunctionalityId], [SecRoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000W5,1, GxCacheFrequency.OFF ,false,true )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
     }
  }

}

}
