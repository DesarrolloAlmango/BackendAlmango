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
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class gx0010 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0010( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0010( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_pWWPUserExtendedId )
      {
         this.AV13pWWPUserExtendedId = "" ;
         ExecutePrivate();
         aP0_pWWPUserExtendedId=this.AV13pWWPUserExtendedId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCwwpuserextendedsmsnotif = new GXCheckbox();
         chkavCwwpuserextendedmobilenotif = new GXCheckbox();
         chkWWPUserExtendedSMSNotif = new GXCheckbox();
         chkWWPUserExtendedMobileNotif = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pWWPUserExtendedId");
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
               gxfirstwebparm = GetFirstPar( "pWWPUserExtendedId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pWWPUserExtendedId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
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
               AV13pWWPUserExtendedId = gxfirstwebparm;
               AssignAttri("", false, "AV13pWWPUserExtendedId", AV13pWWPUserExtendedId);
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_84 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cWWPUserExtendedId = GetPar( "cWWPUserExtendedId");
         AV7cWWPUserExtendedName = GetPar( "cWWPUserExtendedName");
         AV8cWWPUserExtendedFullName = GetPar( "cWWPUserExtendedFullName");
         AV9cWWPUserExtendedPhone = GetPar( "cWWPUserExtendedPhone");
         AV10cWWPUserExtendedEmail = GetPar( "cWWPUserExtendedEmail");
         AV11cWWPUserExtendedSMSNotif = StringUtil.StrToBool( GetPar( "cWWPUserExtendedSMSNotif"));
         AV12cWWPUserExtendedMobileNotif = StringUtil.StrToBool( GetPar( "cWWPUserExtendedMobileNotif"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPUserExtendedId, AV7cWWPUserExtendedName, AV8cWWPUserExtendedFullName, AV9cWWPUserExtendedPhone, AV10cWWPUserExtendedEmail, AV11cWWPUserExtendedSMSNotif, AV12cWWPUserExtendedMobileNotif) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
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
         PA8G2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START8G2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.gx0010.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13pWWPUserExtendedId))}, new string[] {"pWWPUserExtendedId"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPUSEREXTENDEDID", StringUtil.RTrim( AV6cWWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPUSEREXTENDEDNAME", AV7cWWPUserExtendedName);
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPUSEREXTENDEDFULLNAME", AV8cWWPUserExtendedFullName);
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPUSEREXTENDEDPHONE", StringUtil.RTrim( AV9cWWPUserExtendedPhone));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPUSEREXTENDEDEMAIL", AV10cWWPUserExtendedEmail);
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPUSEREXTENDEDSMSNOTIF", StringUtil.BoolToStr( AV11cWWPUserExtendedSMSNotif));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPUSEREXTENDEDMOBILENOTIF", StringUtil.BoolToStr( AV12cWWPUserExtendedMobileNotif));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPWWPUSEREXTENDEDID", StringUtil.RTrim( AV13pWWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDIDFILTERCONTAINER_Class", StringUtil.RTrim( divWwpuserextendedidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divWwpuserextendednamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDFULLNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divWwpuserextendedfullnamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDPHONEFILTERCONTAINER_Class", StringUtil.RTrim( divWwpuserextendedphonefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDEMAILFILTERCONTAINER_Class", StringUtil.RTrim( divWwpuserextendedemailfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDSMSNOTIFFILTERCONTAINER_Class", StringUtil.RTrim( divWwpuserextendedsmsnotiffiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDMOBILENOTIFFILTERCONTAINER_Class", StringUtil.RTrim( divWwpuserextendedmobilenotiffiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
            WE8G2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT8G2( ) ;
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
         return formatLink("wwpbaseobjects.gx0010.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13pWWPUserExtendedId))}, new string[] {"pWWPUserExtendedId"})  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Gx0010" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List WWP_UserExtended", "") ;
      }

      protected void WB8G0( )
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
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwpuserextendedidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpuserextendedidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpuserextendedidfilter_Internalname, context.GetMessage( "User Id", ""), "", "", lblLblwwpuserextendedidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e118g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpuserextendedid_Internalname, context.GetMessage( "User Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpuserextendedid_Internalname, StringUtil.RTrim( AV6cWWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( AV6cWWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpuserextendedid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpuserextendedid_Visible, edtavCwwpuserextendedid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divWwpuserextendednamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpuserextendednamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpuserextendednamefilter_Internalname, context.GetMessage( "WWPUser Extended Name", ""), "", "", lblLblwwpuserextendednamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e128g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpuserextendedname_Internalname, context.GetMessage( "WWPUser Extended Name", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpuserextendedname_Internalname, AV7cWWPUserExtendedName, StringUtil.RTrim( context.localUtil.Format( AV7cWWPUserExtendedName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpuserextendedname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpuserextendedname_Visible, edtavCwwpuserextendedname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divWwpuserextendedfullnamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpuserextendedfullnamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpuserextendedfullnamefilter_Internalname, context.GetMessage( "User Full Name", ""), "", "", lblLblwwpuserextendedfullnamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e138g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpuserextendedfullname_Internalname, context.GetMessage( "User Full Name", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpuserextendedfullname_Internalname, AV8cWWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( AV8cWWPUserExtendedFullName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpuserextendedfullname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpuserextendedfullname_Visible, edtavCwwpuserextendedfullname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divWwpuserextendedphonefiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpuserextendedphonefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpuserextendedphonefilter_Internalname, context.GetMessage( "User Phone", ""), "", "", lblLblwwpuserextendedphonefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e148g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpuserextendedphone_Internalname, context.GetMessage( "User Phone", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpuserextendedphone_Internalname, StringUtil.RTrim( AV9cWWPUserExtendedPhone), StringUtil.RTrim( context.localUtil.Format( AV9cWWPUserExtendedPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpuserextendedphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpuserextendedphone_Visible, edtavCwwpuserextendedphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WWPBaseObjects/Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divWwpuserextendedemailfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpuserextendedemailfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpuserextendedemailfilter_Internalname, context.GetMessage( "User Email", ""), "", "", lblLblwwpuserextendedemailfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e158g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpuserextendedemail_Internalname, context.GetMessage( "User Email", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpuserextendedemail_Internalname, AV10cWWPUserExtendedEmail, StringUtil.RTrim( context.localUtil.Format( AV10cWWPUserExtendedEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpuserextendedemail_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpuserextendedemail_Visible, edtavCwwpuserextendedemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WWPBaseObjects/Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divWwpuserextendedsmsnotiffiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpuserextendedsmsnotiffiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpuserextendedsmsnotiffilter_Internalname, context.GetMessage( "Receive SMS Notifications", ""), "", "", lblLblwwpuserextendedsmsnotiffilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e168g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCwwpuserextendedsmsnotif_Internalname, context.GetMessage( "Receive SMS Notifications", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCwwpuserextendedsmsnotif_Internalname, StringUtil.BoolToStr( AV11cWWPUserExtendedSMSNotif), "", context.GetMessage( "Receive SMS Notifications", ""), chkavCwwpuserextendedsmsnotif.Visible, chkavCwwpuserextendedsmsnotif.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(66, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,66);\"");
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
            GxWebStd.gx_div_start( context, divWwpuserextendedmobilenotiffiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpuserextendedmobilenotiffiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpuserextendedmobilenotiffilter_Internalname, context.GetMessage( "Receive Mobile Notifications", ""), "", "", lblLblwwpuserextendedmobilenotiffilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e178g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCwwpuserextendedmobilenotif_Internalname, context.GetMessage( "Receive Mobile Notifications", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCwwpuserextendedmobilenotif_Internalname, StringUtil.BoolToStr( AV12cWWPUserExtendedMobileNotif), "", context.GetMessage( "Receive Mobile Notifications", ""), chkavCwwpuserextendedmobilenotif.Visible, chkavCwwpuserextendedmobilenotif.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(76, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,76);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e188g1_client"+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START8G2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List WWP_UserExtended", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP8G0( ) ;
      }

      protected void WS8G2( )
      {
         START8G2( ) ;
         EVT8G2( ) ;
      }

      protected void EVT8G2( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A1WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
                              A4WWPUserExtendedPhoto = cgiGet( edtWWPUserExtendedPhoto_Internalname);
                              AssignProp("", false, edtWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
                              A9WWPUserExtendedPhone = cgiGet( edtWWPUserExtendedPhone_Internalname);
                              A6WWPUserExtendedSMSNotif = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedSMSNotif_Internalname));
                              A7WWPUserExtendedMobileNotif = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedMobileNotif_Internalname));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E198G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E208G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cwwpuserextendedid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPUSEREXTENDEDID"), AV6cWWPUserExtendedId) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpuserextendedname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPUSEREXTENDEDNAME"), AV7cWWPUserExtendedName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpuserextendedfullname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPUSEREXTENDEDFULLNAME"), AV8cWWPUserExtendedFullName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpuserextendedphone Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPUSEREXTENDEDPHONE"), AV9cWWPUserExtendedPhone) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpuserextendedemail Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPUSEREXTENDEDEMAIL"), AV10cWWPUserExtendedEmail) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpuserextendedsmsnotif Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCWWPUSEREXTENDEDSMSNOTIF")) != AV11cWWPUserExtendedSMSNotif )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpuserextendedmobilenotif Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCWWPUSEREXTENDEDMOBILENOTIF")) != AV12cWWPUserExtendedMobileNotif )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E218G2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE8G2( )
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

      protected void PA8G2( )
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        string AV6cWWPUserExtendedId ,
                                        string AV7cWWPUserExtendedName ,
                                        string AV8cWWPUserExtendedFullName ,
                                        string AV9cWWPUserExtendedPhone ,
                                        string AV10cWWPUserExtendedEmail ,
                                        bool AV11cWWPUserExtendedSMSNotif ,
                                        bool AV12cWWPUserExtendedMobileNotif )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF8G2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPUSEREXTENDEDID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A1WWPUserExtendedId, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDID", StringUtil.RTrim( A1WWPUserExtendedId));
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
         AV11cWWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( AV11cWWPUserExtendedSMSNotif));
         AssignAttri("", false, "AV11cWWPUserExtendedSMSNotif", AV11cWWPUserExtendedSMSNotif);
         AV12cWWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( AV12cWWPUserExtendedMobileNotif));
         AssignAttri("", false, "AV12cWWPUserExtendedMobileNotif", AV12cWWPUserExtendedMobileNotif);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF8G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF8G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cWWPUserExtendedName ,
                                                 AV8cWWPUserExtendedFullName ,
                                                 AV9cWWPUserExtendedPhone ,
                                                 AV10cWWPUserExtendedEmail ,
                                                 AV11cWWPUserExtendedSMSNotif ,
                                                 AV12cWWPUserExtendedMobileNotif ,
                                                 A10WWPUserExtendedName ,
                                                 A2WWPUserExtendedFullName ,
                                                 A9WWPUserExtendedPhone ,
                                                 A3WWPUserExtendedEmail ,
                                                 A6WWPUserExtendedSMSNotif ,
                                                 A7WWPUserExtendedMobileNotif ,
                                                 A1WWPUserExtendedId ,
                                                 AV6cWWPUserExtendedId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV6cWWPUserExtendedId = StringUtil.PadR( StringUtil.RTrim( AV6cWWPUserExtendedId), 40, "%");
            lV7cWWPUserExtendedName = StringUtil.Concat( StringUtil.RTrim( AV7cWWPUserExtendedName), "%", "");
            lV8cWWPUserExtendedFullName = StringUtil.Concat( StringUtil.RTrim( AV8cWWPUserExtendedFullName), "%", "");
            lV9cWWPUserExtendedPhone = StringUtil.PadR( StringUtil.RTrim( AV9cWWPUserExtendedPhone), 20, "%");
            lV10cWWPUserExtendedEmail = StringUtil.Concat( StringUtil.RTrim( AV10cWWPUserExtendedEmail), "%", "");
            /* Using cursor H008G2 */
            pr_default.execute(0, new Object[] {lV6cWWPUserExtendedId, lV7cWWPUserExtendedName, lV8cWWPUserExtendedFullName, lV9cWWPUserExtendedPhone, lV10cWWPUserExtendedEmail, AV11cWWPUserExtendedSMSNotif, AV12cWWPUserExtendedMobileNotif, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A3WWPUserExtendedEmail = H008G2_A3WWPUserExtendedEmail[0];
               A2WWPUserExtendedFullName = H008G2_A2WWPUserExtendedFullName[0];
               A10WWPUserExtendedName = H008G2_A10WWPUserExtendedName[0];
               A7WWPUserExtendedMobileNotif = H008G2_A7WWPUserExtendedMobileNotif[0];
               A6WWPUserExtendedSMSNotif = H008G2_A6WWPUserExtendedSMSNotif[0];
               A9WWPUserExtendedPhone = H008G2_A9WWPUserExtendedPhone[0];
               A40000WWPUserExtendedPhoto_GXI = H008G2_A40000WWPUserExtendedPhoto_GXI[0];
               AssignProp("", false, edtWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
               A1WWPUserExtendedId = H008G2_A1WWPUserExtendedId[0];
               A4WWPUserExtendedPhoto = H008G2_A4WWPUserExtendedPhoto[0];
               AssignProp("", false, edtWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
               /* Execute user event: Load */
               E208G2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB8G0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes8G2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPUSEREXTENDEDID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A1WWPUserExtendedId, "")), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((long)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cWWPUserExtendedName ,
                                              AV8cWWPUserExtendedFullName ,
                                              AV9cWWPUserExtendedPhone ,
                                              AV10cWWPUserExtendedEmail ,
                                              AV11cWWPUserExtendedSMSNotif ,
                                              AV12cWWPUserExtendedMobileNotif ,
                                              A10WWPUserExtendedName ,
                                              A2WWPUserExtendedFullName ,
                                              A9WWPUserExtendedPhone ,
                                              A3WWPUserExtendedEmail ,
                                              A6WWPUserExtendedSMSNotif ,
                                              A7WWPUserExtendedMobileNotif ,
                                              A1WWPUserExtendedId ,
                                              AV6cWWPUserExtendedId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV6cWWPUserExtendedId = StringUtil.PadR( StringUtil.RTrim( AV6cWWPUserExtendedId), 40, "%");
         lV7cWWPUserExtendedName = StringUtil.Concat( StringUtil.RTrim( AV7cWWPUserExtendedName), "%", "");
         lV8cWWPUserExtendedFullName = StringUtil.Concat( StringUtil.RTrim( AV8cWWPUserExtendedFullName), "%", "");
         lV9cWWPUserExtendedPhone = StringUtil.PadR( StringUtil.RTrim( AV9cWWPUserExtendedPhone), 20, "%");
         lV10cWWPUserExtendedEmail = StringUtil.Concat( StringUtil.RTrim( AV10cWWPUserExtendedEmail), "%", "");
         /* Using cursor H008G3 */
         pr_default.execute(1, new Object[] {lV6cWWPUserExtendedId, lV7cWWPUserExtendedName, lV8cWWPUserExtendedFullName, lV9cWWPUserExtendedPhone, lV10cWWPUserExtendedEmail, AV11cWWPUserExtendedSMSNotif, AV12cWWPUserExtendedMobileNotif});
         GRID1_nRecordCount = H008G3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPUserExtendedId, AV7cWWPUserExtendedName, AV8cWWPUserExtendedFullName, AV9cWWPUserExtendedPhone, AV10cWWPUserExtendedEmail, AV11cWWPUserExtendedSMSNotif, AV12cWWPUserExtendedMobileNotif) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPUserExtendedId, AV7cWWPUserExtendedName, AV8cWWPUserExtendedFullName, AV9cWWPUserExtendedPhone, AV10cWWPUserExtendedEmail, AV11cWWPUserExtendedSMSNotif, AV12cWWPUserExtendedMobileNotif) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPUserExtendedId, AV7cWWPUserExtendedName, AV8cWWPUserExtendedFullName, AV9cWWPUserExtendedPhone, AV10cWWPUserExtendedEmail, AV11cWWPUserExtendedSMSNotif, AV12cWWPUserExtendedMobileNotif) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((long)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPUserExtendedId, AV7cWWPUserExtendedName, AV8cWWPUserExtendedFullName, AV9cWWPUserExtendedPhone, AV10cWWPUserExtendedEmail, AV11cWWPUserExtendedSMSNotif, AV12cWWPUserExtendedMobileNotif) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPUserExtendedId, AV7cWWPUserExtendedName, AV8cWWPUserExtendedFullName, AV9cWWPUserExtendedPhone, AV10cWWPUserExtendedEmail, AV11cWWPUserExtendedSMSNotif, AV12cWWPUserExtendedMobileNotif) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtWWPUserExtendedId_Enabled = 0;
         edtWWPUserExtendedPhoto_Enabled = 0;
         edtWWPUserExtendedPhone_Enabled = 0;
         chkWWPUserExtendedSMSNotif.Enabled = 0;
         chkWWPUserExtendedMobileNotif.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E198G2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV6cWWPUserExtendedId = cgiGet( edtavCwwpuserextendedid_Internalname);
            AssignAttri("", false, "AV6cWWPUserExtendedId", AV6cWWPUserExtendedId);
            AV7cWWPUserExtendedName = cgiGet( edtavCwwpuserextendedname_Internalname);
            AssignAttri("", false, "AV7cWWPUserExtendedName", AV7cWWPUserExtendedName);
            AV8cWWPUserExtendedFullName = cgiGet( edtavCwwpuserextendedfullname_Internalname);
            AssignAttri("", false, "AV8cWWPUserExtendedFullName", AV8cWWPUserExtendedFullName);
            AV9cWWPUserExtendedPhone = cgiGet( edtavCwwpuserextendedphone_Internalname);
            AssignAttri("", false, "AV9cWWPUserExtendedPhone", AV9cWWPUserExtendedPhone);
            AV10cWWPUserExtendedEmail = cgiGet( edtavCwwpuserextendedemail_Internalname);
            AssignAttri("", false, "AV10cWWPUserExtendedEmail", AV10cWWPUserExtendedEmail);
            AV11cWWPUserExtendedSMSNotif = StringUtil.StrToBool( cgiGet( chkavCwwpuserextendedsmsnotif_Internalname));
            AssignAttri("", false, "AV11cWWPUserExtendedSMSNotif", AV11cWWPUserExtendedSMSNotif);
            AV12cWWPUserExtendedMobileNotif = StringUtil.StrToBool( cgiGet( chkavCwwpuserextendedmobilenotif_Internalname));
            AssignAttri("", false, "AV12cWWPUserExtendedMobileNotif", AV12cWWPUserExtendedMobileNotif);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPUSEREXTENDEDID"), AV6cWWPUserExtendedId) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPUSEREXTENDEDNAME"), AV7cWWPUserExtendedName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPUSEREXTENDEDFULLNAME"), AV8cWWPUserExtendedFullName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPUSEREXTENDEDPHONE"), AV9cWWPUserExtendedPhone) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPUSEREXTENDEDEMAIL"), AV10cWWPUserExtendedEmail) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCWWPUSEREXTENDEDSMSNOTIF")) != AV11cWWPUserExtendedSMSNotif )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCWWPUSEREXTENDEDMOBILENOTIF")) != AV12cWWPUserExtendedMobileNotif )
            {
               GRID1_nFirstRecordOnPage = 0;
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
         E198G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E198G2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E208G2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            context.DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E218G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E218G2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pWWPUserExtendedId = A1WWPUserExtendedId;
         AssignAttri("", false, "AV13pWWPUserExtendedId", AV13pWWPUserExtendedId);
         context.setWebReturnParms(new Object[] {(string)AV13pWWPUserExtendedId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pWWPUserExtendedId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pWWPUserExtendedId = (string)getParm(obj,0);
         AssignAttri("", false, "AV13pWWPUserExtendedId", AV13pWWPUserExtendedId);
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
         PA8G2( ) ;
         WS8G2( ) ;
         WE8G2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021253760", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/gx0010.js", "?202673021253760", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID_"+sGXsfl_84_idx;
         edtWWPUserExtendedPhoto_Internalname = "WWPUSEREXTENDEDPHOTO_"+sGXsfl_84_idx;
         edtWWPUserExtendedPhone_Internalname = "WWPUSEREXTENDEDPHONE_"+sGXsfl_84_idx;
         chkWWPUserExtendedSMSNotif_Internalname = "WWPUSEREXTENDEDSMSNOTIF_"+sGXsfl_84_idx;
         chkWWPUserExtendedMobileNotif_Internalname = "WWPUSEREXTENDEDMOBILENOTIF_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID_"+sGXsfl_84_fel_idx;
         edtWWPUserExtendedPhoto_Internalname = "WWPUSEREXTENDEDPHOTO_"+sGXsfl_84_fel_idx;
         edtWWPUserExtendedPhone_Internalname = "WWPUSEREXTENDEDPHONE_"+sGXsfl_84_fel_idx;
         chkWWPUserExtendedSMSNotif_Internalname = "WWPUSEREXTENDEDSMSNOTIF_"+sGXsfl_84_fel_idx;
         chkWWPUserExtendedMobileNotif_Internalname = "WWPUSEREXTENDEDMOBILENOTIF_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WB8G0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1WWPUserExtendedId))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            edtWWPUserExtendedId_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1WWPUserExtendedId))+"'"+"]);";
            AssignProp("", false, edtWWPUserExtendedId_Internalname, "Link", edtWWPUserExtendedId_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPUserExtendedId_Internalname,StringUtil.RTrim( A1WWPUserExtendedId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtWWPUserExtendedId_Link,(string)"",(string)"",(string)"",(string)edtWWPUserExtendedId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"WWPBaseObjects\\WWP_GAMGUID",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A4WWPUserExtendedPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000WWPUserExtendedPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.PathToRelativeUrl( A4WWPUserExtendedPhoto));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPUserExtendedPhoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A4WWPUserExtendedPhoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A9WWPUserExtendedPhone);
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPUserExtendedPhone_Internalname,StringUtil.RTrim( A9WWPUserExtendedPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtWWPUserExtendedPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "WWPUSEREXTENDEDSMSNOTIF_" + sGXsfl_84_idx;
            chkWWPUserExtendedSMSNotif.Name = GXCCtl;
            chkWWPUserExtendedSMSNotif.WebTags = "";
            chkWWPUserExtendedSMSNotif.Caption = "";
            AssignProp("", false, chkWWPUserExtendedSMSNotif_Internalname, "TitleCaption", chkWWPUserExtendedSMSNotif.Caption, !bGXsfl_84_Refreshing);
            chkWWPUserExtendedSMSNotif.CheckedValue = "false";
            A6WWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A6WWPUserExtendedSMSNotif));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkWWPUserExtendedSMSNotif_Internalname,StringUtil.BoolToStr( A6WWPUserExtendedSMSNotif),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "WWPUSEREXTENDEDMOBILENOTIF_" + sGXsfl_84_idx;
            chkWWPUserExtendedMobileNotif.Name = GXCCtl;
            chkWWPUserExtendedMobileNotif.WebTags = "";
            chkWWPUserExtendedMobileNotif.Caption = "";
            AssignProp("", false, chkWWPUserExtendedMobileNotif_Internalname, "TitleCaption", chkWWPUserExtendedMobileNotif.Caption, !bGXsfl_84_Refreshing);
            chkWWPUserExtendedMobileNotif.CheckedValue = "false";
            A7WWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A7WWPUserExtendedMobileNotif));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkWWPUserExtendedMobileNotif_Internalname,StringUtil.BoolToStr( A7WWPUserExtendedMobileNotif),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            send_integrity_lvl_hashes8G2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         chkavCwwpuserextendedsmsnotif.Name = "vCWWPUSEREXTENDEDSMSNOTIF";
         chkavCwwpuserextendedsmsnotif.WebTags = "";
         chkavCwwpuserextendedsmsnotif.Caption = context.GetMessage( "Receive SMS Notifications", "");
         AssignProp("", false, chkavCwwpuserextendedsmsnotif_Internalname, "TitleCaption", chkavCwwpuserextendedsmsnotif.Caption, true);
         chkavCwwpuserextendedsmsnotif.CheckedValue = "false";
         AV11cWWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( AV11cWWPUserExtendedSMSNotif));
         AssignAttri("", false, "AV11cWWPUserExtendedSMSNotif", AV11cWWPUserExtendedSMSNotif);
         chkavCwwpuserextendedmobilenotif.Name = "vCWWPUSEREXTENDEDMOBILENOTIF";
         chkavCwwpuserextendedmobilenotif.WebTags = "";
         chkavCwwpuserextendedmobilenotif.Caption = context.GetMessage( "Receive Mobile Notifications", "");
         AssignProp("", false, chkavCwwpuserextendedmobilenotif_Internalname, "TitleCaption", chkavCwwpuserextendedmobilenotif.Caption, true);
         chkavCwwpuserextendedmobilenotif.CheckedValue = "false";
         AV12cWWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( AV12cWWPUserExtendedMobileNotif));
         AssignAttri("", false, "AV12cWWPUserExtendedMobileNotif", AV12cWWPUserExtendedMobileNotif);
         GXCCtl = "WWPUSEREXTENDEDSMSNOTIF_" + sGXsfl_84_idx;
         chkWWPUserExtendedSMSNotif.Name = GXCCtl;
         chkWWPUserExtendedSMSNotif.WebTags = "";
         chkWWPUserExtendedSMSNotif.Caption = "";
         AssignProp("", false, chkWWPUserExtendedSMSNotif_Internalname, "TitleCaption", chkWWPUserExtendedSMSNotif.Caption, !bGXsfl_84_Refreshing);
         chkWWPUserExtendedSMSNotif.CheckedValue = "false";
         A6WWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A6WWPUserExtendedSMSNotif));
         GXCCtl = "WWPUSEREXTENDEDMOBILENOTIF_" + sGXsfl_84_idx;
         chkWWPUserExtendedMobileNotif.Name = GXCCtl;
         chkWWPUserExtendedMobileNotif.WebTags = "";
         chkWWPUserExtendedMobileNotif.Caption = "";
         AssignProp("", false, chkWWPUserExtendedMobileNotif_Internalname, "TitleCaption", chkWWPUserExtendedMobileNotif.Caption, !bGXsfl_84_Refreshing);
         chkWWPUserExtendedMobileNotif.CheckedValue = "false";
         A7WWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A7WWPUserExtendedMobileNotif));
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Photo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "SMS Notifications", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Mobile Notifications", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A1WWPUserExtendedId)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtWWPUserExtendedId_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( A4WWPUserExtendedPhoto));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A9WWPUserExtendedPhone)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A6WWPUserExtendedSMSNotif)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A7WWPUserExtendedMobileNotif)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLblwwpuserextendedidfilter_Internalname = "LBLWWPUSEREXTENDEDIDFILTER";
         edtavCwwpuserextendedid_Internalname = "vCWWPUSEREXTENDEDID";
         divWwpuserextendedidfiltercontainer_Internalname = "WWPUSEREXTENDEDIDFILTERCONTAINER";
         lblLblwwpuserextendednamefilter_Internalname = "LBLWWPUSEREXTENDEDNAMEFILTER";
         edtavCwwpuserextendedname_Internalname = "vCWWPUSEREXTENDEDNAME";
         divWwpuserextendednamefiltercontainer_Internalname = "WWPUSEREXTENDEDNAMEFILTERCONTAINER";
         lblLblwwpuserextendedfullnamefilter_Internalname = "LBLWWPUSEREXTENDEDFULLNAMEFILTER";
         edtavCwwpuserextendedfullname_Internalname = "vCWWPUSEREXTENDEDFULLNAME";
         divWwpuserextendedfullnamefiltercontainer_Internalname = "WWPUSEREXTENDEDFULLNAMEFILTERCONTAINER";
         lblLblwwpuserextendedphonefilter_Internalname = "LBLWWPUSEREXTENDEDPHONEFILTER";
         edtavCwwpuserextendedphone_Internalname = "vCWWPUSEREXTENDEDPHONE";
         divWwpuserextendedphonefiltercontainer_Internalname = "WWPUSEREXTENDEDPHONEFILTERCONTAINER";
         lblLblwwpuserextendedemailfilter_Internalname = "LBLWWPUSEREXTENDEDEMAILFILTER";
         edtavCwwpuserextendedemail_Internalname = "vCWWPUSEREXTENDEDEMAIL";
         divWwpuserextendedemailfiltercontainer_Internalname = "WWPUSEREXTENDEDEMAILFILTERCONTAINER";
         lblLblwwpuserextendedsmsnotiffilter_Internalname = "LBLWWPUSEREXTENDEDSMSNOTIFFILTER";
         chkavCwwpuserextendedsmsnotif_Internalname = "vCWWPUSEREXTENDEDSMSNOTIF";
         divWwpuserextendedsmsnotiffiltercontainer_Internalname = "WWPUSEREXTENDEDSMSNOTIFFILTERCONTAINER";
         lblLblwwpuserextendedmobilenotiffilter_Internalname = "LBLWWPUSEREXTENDEDMOBILENOTIFFILTER";
         chkavCwwpuserextendedmobilenotif_Internalname = "vCWWPUSEREXTENDEDMOBILENOTIF";
         divWwpuserextendedmobilenotiffiltercontainer_Internalname = "WWPUSEREXTENDEDMOBILENOTIFFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         edtWWPUserExtendedPhoto_Internalname = "WWPUSEREXTENDEDPHOTO";
         edtWWPUserExtendedPhone_Internalname = "WWPUSEREXTENDEDPHONE";
         chkWWPUserExtendedSMSNotif_Internalname = "WWPUSEREXTENDEDSMSNOTIF";
         chkWWPUserExtendedMobileNotif_Internalname = "WWPUSEREXTENDEDMOBILENOTIF";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         chkavCwwpuserextendedmobilenotif.Caption = context.GetMessage( "Receive Mobile Notifications", "");
         chkavCwwpuserextendedsmsnotif.Caption = context.GetMessage( "Receive SMS Notifications", "");
         chkWWPUserExtendedMobileNotif.Caption = "";
         chkWWPUserExtendedSMSNotif.Caption = "";
         edtWWPUserExtendedPhone_Jsonclick = "";
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Link = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         chkWWPUserExtendedMobileNotif.Enabled = 0;
         chkWWPUserExtendedSMSNotif.Enabled = 0;
         edtWWPUserExtendedPhone_Enabled = 0;
         edtWWPUserExtendedPhoto_Enabled = 0;
         edtWWPUserExtendedId_Enabled = 0;
         chkavCwwpuserextendedmobilenotif.Enabled = 1;
         chkavCwwpuserextendedmobilenotif.Visible = 1;
         chkavCwwpuserextendedsmsnotif.Enabled = 1;
         chkavCwwpuserextendedsmsnotif.Visible = 1;
         edtavCwwpuserextendedemail_Jsonclick = "";
         edtavCwwpuserextendedemail_Enabled = 1;
         edtavCwwpuserextendedemail_Visible = 1;
         edtavCwwpuserextendedphone_Jsonclick = "";
         edtavCwwpuserextendedphone_Enabled = 1;
         edtavCwwpuserextendedphone_Visible = 1;
         edtavCwwpuserextendedfullname_Jsonclick = "";
         edtavCwwpuserextendedfullname_Enabled = 1;
         edtavCwwpuserextendedfullname_Visible = 1;
         edtavCwwpuserextendedname_Jsonclick = "";
         edtavCwwpuserextendedname_Enabled = 1;
         edtavCwwpuserextendedname_Visible = 1;
         edtavCwwpuserextendedid_Jsonclick = "";
         edtavCwwpuserextendedid_Enabled = 1;
         edtavCwwpuserextendedid_Visible = 1;
         divWwpuserextendedmobilenotiffiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpuserextendedsmsnotiffiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpuserextendedemailfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpuserextendedphonefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpuserextendedfullnamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpuserextendednamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpuserextendedidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List WWP_UserExtended", "");
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPUserExtendedId',fld:'vCWWPUSEREXTENDEDID',pic:'',type:'char'},{av:'AV7cWWPUserExtendedName',fld:'vCWWPUSEREXTENDEDNAME',pic:'',type:'svchar'},{av:'AV8cWWPUserExtendedFullName',fld:'vCWWPUSEREXTENDEDFULLNAME',pic:'',type:'svchar'},{av:'AV9cWWPUserExtendedPhone',fld:'vCWWPUSEREXTENDEDPHONE',pic:'',type:'char'},{av:'AV10cWWPUserExtendedEmail',fld:'vCWWPUSEREXTENDEDEMAIL',pic:'',type:'svchar'},{av:'AV11cWWPUserExtendedSMSNotif',fld:'vCWWPUSEREXTENDEDSMSNOTIF',pic:'',type:'boolean'},{av:'AV12cWWPUserExtendedMobileNotif',fld:'vCWWPUSEREXTENDEDMOBILENOTIF',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E188G1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLWWPUSEREXTENDEDIDFILTER.CLICK","{handler:'E118G1',iparms:[{av:'divWwpuserextendedidfiltercontainer_Class',ctrl:'WWPUSEREXTENDEDIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPUSEREXTENDEDIDFILTER.CLICK",",oparms:[{av:'divWwpuserextendedidfiltercontainer_Class',ctrl:'WWPUSEREXTENDEDIDFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpuserextendedid_Visible',ctrl:'vCWWPUSEREXTENDEDID',prop:'Visible'}]}");
         setEventMetadata("LBLWWPUSEREXTENDEDNAMEFILTER.CLICK","{handler:'E128G1',iparms:[{av:'divWwpuserextendednamefiltercontainer_Class',ctrl:'WWPUSEREXTENDEDNAMEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPUSEREXTENDEDNAMEFILTER.CLICK",",oparms:[{av:'divWwpuserextendednamefiltercontainer_Class',ctrl:'WWPUSEREXTENDEDNAMEFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpuserextendedname_Visible',ctrl:'vCWWPUSEREXTENDEDNAME',prop:'Visible'}]}");
         setEventMetadata("LBLWWPUSEREXTENDEDFULLNAMEFILTER.CLICK","{handler:'E138G1',iparms:[{av:'divWwpuserextendedfullnamefiltercontainer_Class',ctrl:'WWPUSEREXTENDEDFULLNAMEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPUSEREXTENDEDFULLNAMEFILTER.CLICK",",oparms:[{av:'divWwpuserextendedfullnamefiltercontainer_Class',ctrl:'WWPUSEREXTENDEDFULLNAMEFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpuserextendedfullname_Visible',ctrl:'vCWWPUSEREXTENDEDFULLNAME',prop:'Visible'}]}");
         setEventMetadata("LBLWWPUSEREXTENDEDPHONEFILTER.CLICK","{handler:'E148G1',iparms:[{av:'divWwpuserextendedphonefiltercontainer_Class',ctrl:'WWPUSEREXTENDEDPHONEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPUSEREXTENDEDPHONEFILTER.CLICK",",oparms:[{av:'divWwpuserextendedphonefiltercontainer_Class',ctrl:'WWPUSEREXTENDEDPHONEFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpuserextendedphone_Visible',ctrl:'vCWWPUSEREXTENDEDPHONE',prop:'Visible'}]}");
         setEventMetadata("LBLWWPUSEREXTENDEDEMAILFILTER.CLICK","{handler:'E158G1',iparms:[{av:'divWwpuserextendedemailfiltercontainer_Class',ctrl:'WWPUSEREXTENDEDEMAILFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPUSEREXTENDEDEMAILFILTER.CLICK",",oparms:[{av:'divWwpuserextendedemailfiltercontainer_Class',ctrl:'WWPUSEREXTENDEDEMAILFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpuserextendedemail_Visible',ctrl:'vCWWPUSEREXTENDEDEMAIL',prop:'Visible'}]}");
         setEventMetadata("LBLWWPUSEREXTENDEDSMSNOTIFFILTER.CLICK","{handler:'E168G1',iparms:[{av:'divWwpuserextendedsmsnotiffiltercontainer_Class',ctrl:'WWPUSEREXTENDEDSMSNOTIFFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPUSEREXTENDEDSMSNOTIFFILTER.CLICK",",oparms:[{av:'divWwpuserextendedsmsnotiffiltercontainer_Class',ctrl:'WWPUSEREXTENDEDSMSNOTIFFILTERCONTAINER',prop:'Class'},{av:'chkavCwwpuserextendedsmsnotif.Visible',ctrl:'vCWWPUSEREXTENDEDSMSNOTIF',prop:'Visible'}]}");
         setEventMetadata("LBLWWPUSEREXTENDEDMOBILENOTIFFILTER.CLICK","{handler:'E178G1',iparms:[{av:'divWwpuserextendedmobilenotiffiltercontainer_Class',ctrl:'WWPUSEREXTENDEDMOBILENOTIFFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPUSEREXTENDEDMOBILENOTIFFILTER.CLICK",",oparms:[{av:'divWwpuserextendedmobilenotiffiltercontainer_Class',ctrl:'WWPUSEREXTENDEDMOBILENOTIFFILTERCONTAINER',prop:'Class'},{av:'chkavCwwpuserextendedmobilenotif.Visible',ctrl:'vCWWPUSEREXTENDEDMOBILENOTIF',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E218G2',iparms:[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pWWPUserExtendedId',fld:'vPWWPUSEREXTENDEDID',pic:'',type:'char'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPUserExtendedId',fld:'vCWWPUSEREXTENDEDID',pic:'',type:'char'},{av:'AV7cWWPUserExtendedName',fld:'vCWWPUSEREXTENDEDNAME',pic:'',type:'svchar'},{av:'AV8cWWPUserExtendedFullName',fld:'vCWWPUSEREXTENDEDFULLNAME',pic:'',type:'svchar'},{av:'AV9cWWPUserExtendedPhone',fld:'vCWWPUSEREXTENDEDPHONE',pic:'',type:'char'},{av:'AV10cWWPUserExtendedEmail',fld:'vCWWPUSEREXTENDEDEMAIL',pic:'',type:'svchar'},{av:'AV11cWWPUserExtendedSMSNotif',fld:'vCWWPUSEREXTENDEDSMSNOTIF',pic:'',type:'boolean'},{av:'AV12cWWPUserExtendedMobileNotif',fld:'vCWWPUSEREXTENDEDMOBILENOTIF',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPUserExtendedId',fld:'vCWWPUSEREXTENDEDID',pic:'',type:'char'},{av:'AV7cWWPUserExtendedName',fld:'vCWWPUSEREXTENDEDNAME',pic:'',type:'svchar'},{av:'AV8cWWPUserExtendedFullName',fld:'vCWWPUSEREXTENDEDFULLNAME',pic:'',type:'svchar'},{av:'AV9cWWPUserExtendedPhone',fld:'vCWWPUSEREXTENDEDPHONE',pic:'',type:'char'},{av:'AV10cWWPUserExtendedEmail',fld:'vCWWPUSEREXTENDEDEMAIL',pic:'',type:'svchar'},{av:'AV11cWWPUserExtendedSMSNotif',fld:'vCWWPUSEREXTENDEDSMSNOTIF',pic:'',type:'boolean'},{av:'AV12cWWPUserExtendedMobileNotif',fld:'vCWWPUSEREXTENDEDMOBILENOTIF',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPUserExtendedId',fld:'vCWWPUSEREXTENDEDID',pic:'',type:'char'},{av:'AV7cWWPUserExtendedName',fld:'vCWWPUSEREXTENDEDNAME',pic:'',type:'svchar'},{av:'AV8cWWPUserExtendedFullName',fld:'vCWWPUSEREXTENDEDFULLNAME',pic:'',type:'svchar'},{av:'AV9cWWPUserExtendedPhone',fld:'vCWWPUSEREXTENDEDPHONE',pic:'',type:'char'},{av:'AV10cWWPUserExtendedEmail',fld:'vCWWPUSEREXTENDEDEMAIL',pic:'',type:'svchar'},{av:'AV11cWWPUserExtendedSMSNotif',fld:'vCWWPUSEREXTENDEDSMSNOTIF',pic:'',type:'boolean'},{av:'AV12cWWPUserExtendedMobileNotif',fld:'vCWWPUSEREXTENDEDMOBILENOTIF',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPUserExtendedId',fld:'vCWWPUSEREXTENDEDID',pic:'',type:'char'},{av:'AV7cWWPUserExtendedName',fld:'vCWWPUSEREXTENDEDNAME',pic:'',type:'svchar'},{av:'AV8cWWPUserExtendedFullName',fld:'vCWWPUSEREXTENDEDFULLNAME',pic:'',type:'svchar'},{av:'AV9cWWPUserExtendedPhone',fld:'vCWWPUSEREXTENDEDPHONE',pic:'',type:'char'},{av:'AV10cWWPUserExtendedEmail',fld:'vCWWPUSEREXTENDEDEMAIL',pic:'',type:'svchar'},{av:'AV11cWWPUserExtendedSMSNotif',fld:'vCWWPUSEREXTENDEDSMSNOTIF',pic:'',type:'boolean'},{av:'AV12cWWPUserExtendedMobileNotif',fld:'vCWWPUSEREXTENDEDMOBILENOTIF',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CWWPUSEREXTENDEDEMAIL","{handler:'Validv_Cwwpuserextendedemail',iparms:[]");
         setEventMetadata("VALIDV_CWWPUSEREXTENDEDEMAIL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Wwpuserextendedmobilenotif',iparms:[]");
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
         AV13pWWPUserExtendedId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cWWPUserExtendedId = "";
         AV7cWWPUserExtendedName = "";
         AV8cWWPUserExtendedFullName = "";
         AV9cWWPUserExtendedPhone = "";
         AV10cWWPUserExtendedEmail = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblwwpuserextendedidfilter_Jsonclick = "";
         TempTags = "";
         lblLblwwpuserextendednamefilter_Jsonclick = "";
         lblLblwwpuserextendedfullnamefilter_Jsonclick = "";
         lblLblwwpuserextendedphonefilter_Jsonclick = "";
         lblLblwwpuserextendedemailfilter_Jsonclick = "";
         lblLblwwpuserextendedsmsnotiffilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLblwwpuserextendedmobilenotiffilter_Jsonclick = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV15Linkselection_GXI = "";
         A1WWPUserExtendedId = "";
         A4WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         A9WWPUserExtendedPhone = "";
         lV6cWWPUserExtendedId = "";
         lV7cWWPUserExtendedName = "";
         lV8cWWPUserExtendedFullName = "";
         lV9cWWPUserExtendedPhone = "";
         lV10cWWPUserExtendedEmail = "";
         A10WWPUserExtendedName = "";
         A2WWPUserExtendedFullName = "";
         A3WWPUserExtendedEmail = "";
         H008G2_A3WWPUserExtendedEmail = new string[] {""} ;
         H008G2_A2WWPUserExtendedFullName = new string[] {""} ;
         H008G2_A10WWPUserExtendedName = new string[] {""} ;
         H008G2_A7WWPUserExtendedMobileNotif = new bool[] {false} ;
         H008G2_A6WWPUserExtendedSMSNotif = new bool[] {false} ;
         H008G2_A9WWPUserExtendedPhone = new string[] {""} ;
         H008G2_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         H008G2_A1WWPUserExtendedId = new string[] {""} ;
         H008G2_A4WWPUserExtendedPhoto = new string[] {""} ;
         H008G3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         gxphoneLink = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.gx0010__default(),
            new Object[][] {
                new Object[] {
               H008G2_A3WWPUserExtendedEmail, H008G2_A2WWPUserExtendedFullName, H008G2_A10WWPUserExtendedName, H008G2_A7WWPUserExtendedMobileNotif, H008G2_A6WWPUserExtendedSMSNotif, H008G2_A9WWPUserExtendedPhone, H008G2_A40000WWPUserExtendedPhoto_GXI, H008G2_A1WWPUserExtendedId, H008G2_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               H008G3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int edtavCwwpuserextendedid_Visible ;
      private int edtavCwwpuserextendedid_Enabled ;
      private int edtavCwwpuserextendedname_Visible ;
      private int edtavCwwpuserextendedname_Enabled ;
      private int edtavCwwpuserextendedfullname_Visible ;
      private int edtavCwwpuserextendedfullname_Enabled ;
      private int edtavCwwpuserextendedphone_Visible ;
      private int edtavCwwpuserextendedphone_Enabled ;
      private int edtavCwwpuserextendedemail_Visible ;
      private int edtavCwwpuserextendedemail_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtWWPUserExtendedId_Enabled ;
      private int edtWWPUserExtendedPhoto_Enabled ;
      private int edtWWPUserExtendedPhone_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string AV13pWWPUserExtendedId ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divWwpuserextendedidfiltercontainer_Class ;
      private string divWwpuserextendednamefiltercontainer_Class ;
      private string divWwpuserextendedfullnamefiltercontainer_Class ;
      private string divWwpuserextendedphonefiltercontainer_Class ;
      private string divWwpuserextendedemailfiltercontainer_Class ;
      private string divWwpuserextendedsmsnotiffiltercontainer_Class ;
      private string divWwpuserextendedmobilenotiffiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV6cWWPUserExtendedId ;
      private string AV9cWWPUserExtendedPhone ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divWwpuserextendedidfiltercontainer_Internalname ;
      private string lblLblwwpuserextendedidfilter_Internalname ;
      private string lblLblwwpuserextendedidfilter_Jsonclick ;
      private string edtavCwwpuserextendedid_Internalname ;
      private string TempTags ;
      private string edtavCwwpuserextendedid_Jsonclick ;
      private string divWwpuserextendednamefiltercontainer_Internalname ;
      private string lblLblwwpuserextendednamefilter_Internalname ;
      private string lblLblwwpuserextendednamefilter_Jsonclick ;
      private string edtavCwwpuserextendedname_Internalname ;
      private string edtavCwwpuserextendedname_Jsonclick ;
      private string divWwpuserextendedfullnamefiltercontainer_Internalname ;
      private string lblLblwwpuserextendedfullnamefilter_Internalname ;
      private string lblLblwwpuserextendedfullnamefilter_Jsonclick ;
      private string edtavCwwpuserextendedfullname_Internalname ;
      private string edtavCwwpuserextendedfullname_Jsonclick ;
      private string divWwpuserextendedphonefiltercontainer_Internalname ;
      private string lblLblwwpuserextendedphonefilter_Internalname ;
      private string lblLblwwpuserextendedphonefilter_Jsonclick ;
      private string edtavCwwpuserextendedphone_Internalname ;
      private string edtavCwwpuserextendedphone_Jsonclick ;
      private string divWwpuserextendedemailfiltercontainer_Internalname ;
      private string lblLblwwpuserextendedemailfilter_Internalname ;
      private string lblLblwwpuserextendedemailfilter_Jsonclick ;
      private string edtavCwwpuserextendedemail_Internalname ;
      private string edtavCwwpuserextendedemail_Jsonclick ;
      private string divWwpuserextendedsmsnotiffiltercontainer_Internalname ;
      private string lblLblwwpuserextendedsmsnotiffilter_Internalname ;
      private string lblLblwwpuserextendedsmsnotiffilter_Jsonclick ;
      private string chkavCwwpuserextendedsmsnotif_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divWwpuserextendedmobilenotiffiltercontainer_Internalname ;
      private string lblLblwwpuserextendedmobilenotiffilter_Internalname ;
      private string lblLblwwpuserextendedmobilenotiffilter_Jsonclick ;
      private string chkavCwwpuserextendedmobilenotif_Internalname ;
      private string divGridtable_Internalname ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string A1WWPUserExtendedId ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedPhoto_Internalname ;
      private string A9WWPUserExtendedPhone ;
      private string edtWWPUserExtendedPhone_Internalname ;
      private string chkWWPUserExtendedSMSNotif_Internalname ;
      private string chkWWPUserExtendedMobileNotif_Internalname ;
      private string lV6cWWPUserExtendedId ;
      private string lV9cWWPUserExtendedPhone ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtWWPUserExtendedId_Link ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string gxphoneLink ;
      private string edtWWPUserExtendedPhone_Jsonclick ;
      private string GXCCtl ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV11cWWPUserExtendedSMSNotif ;
      private bool AV12cWWPUserExtendedMobileNotif ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool A6WWPUserExtendedSMSNotif ;
      private bool A7WWPUserExtendedMobileNotif ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private bool A4WWPUserExtendedPhoto_IsBlob ;
      private string AV7cWWPUserExtendedName ;
      private string AV8cWWPUserExtendedFullName ;
      private string AV10cWWPUserExtendedEmail ;
      private string AV15Linkselection_GXI ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string lV7cWWPUserExtendedName ;
      private string lV8cWWPUserExtendedFullName ;
      private string lV10cWWPUserExtendedEmail ;
      private string A10WWPUserExtendedName ;
      private string A2WWPUserExtendedFullName ;
      private string A3WWPUserExtendedEmail ;
      private string AV5LinkSelection ;
      private string A4WWPUserExtendedPhoto ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCwwpuserextendedsmsnotif ;
      private GXCheckbox chkavCwwpuserextendedmobilenotif ;
      private GXCheckbox chkWWPUserExtendedSMSNotif ;
      private GXCheckbox chkWWPUserExtendedMobileNotif ;
      private IDataStoreProvider pr_default ;
      private string[] H008G2_A3WWPUserExtendedEmail ;
      private string[] H008G2_A2WWPUserExtendedFullName ;
      private string[] H008G2_A10WWPUserExtendedName ;
      private bool[] H008G2_A7WWPUserExtendedMobileNotif ;
      private bool[] H008G2_A6WWPUserExtendedSMSNotif ;
      private string[] H008G2_A9WWPUserExtendedPhone ;
      private string[] H008G2_A40000WWPUserExtendedPhoto_GXI ;
      private string[] H008G2_A1WWPUserExtendedId ;
      private string[] H008G2_A4WWPUserExtendedPhoto ;
      private long[] H008G3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string aP0_pWWPUserExtendedId ;
   }

   public class gx0010__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H008G2( IGxContext context ,
                                             string AV7cWWPUserExtendedName ,
                                             string AV8cWWPUserExtendedFullName ,
                                             string AV9cWWPUserExtendedPhone ,
                                             string AV10cWWPUserExtendedEmail ,
                                             bool AV11cWWPUserExtendedSMSNotif ,
                                             bool AV12cWWPUserExtendedMobileNotif ,
                                             string A10WWPUserExtendedName ,
                                             string A2WWPUserExtendedFullName ,
                                             string A9WWPUserExtendedPhone ,
                                             string A3WWPUserExtendedEmail ,
                                             bool A6WWPUserExtendedSMSNotif ,
                                             bool A7WWPUserExtendedMobileNotif ,
                                             string A1WWPUserExtendedId ,
                                             string AV6cWWPUserExtendedId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [WWPUserExtendedEmail], [WWPUserExtendedFullName], [WWPUserExtendedName], [WWPUserExtendedMobileNotif], [WWPUserExtendedSMSNotif], [WWPUserExtendedPhone], [WWPUserExtendedPhoto_GXI], [WWPUserExtendedId], [WWPUserExtendedPhoto]";
         sFromString = " FROM [WWP_UserExtended]";
         sOrderString = "";
         AddWhere(sWhereString, "([WWPUserExtendedId] like @lV6cWWPUserExtendedId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cWWPUserExtendedName)) )
         {
            AddWhere(sWhereString, "([WWPUserExtendedName] like @lV7cWWPUserExtendedName)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cWWPUserExtendedFullName)) )
         {
            AddWhere(sWhereString, "([WWPUserExtendedFullName] like @lV8cWWPUserExtendedFullName)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cWWPUserExtendedPhone)) )
         {
            AddWhere(sWhereString, "([WWPUserExtendedPhone] like @lV9cWWPUserExtendedPhone)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cWWPUserExtendedEmail)) )
         {
            AddWhere(sWhereString, "([WWPUserExtendedEmail] like @lV10cWWPUserExtendedEmail)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (false==AV11cWWPUserExtendedSMSNotif) )
         {
            AddWhere(sWhereString, "([WWPUserExtendedSMSNotif] >= @AV11cWWPUserExtendedSMSNotif)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (false==AV12cWWPUserExtendedMobileNotif) )
         {
            AddWhere(sWhereString, "([WWPUserExtendedMobileNotif] >= @AV12cWWPUserExtendedMobileNotif)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [WWPUserExtendedId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H008G3( IGxContext context ,
                                             string AV7cWWPUserExtendedName ,
                                             string AV8cWWPUserExtendedFullName ,
                                             string AV9cWWPUserExtendedPhone ,
                                             string AV10cWWPUserExtendedEmail ,
                                             bool AV11cWWPUserExtendedSMSNotif ,
                                             bool AV12cWWPUserExtendedMobileNotif ,
                                             string A10WWPUserExtendedName ,
                                             string A2WWPUserExtendedFullName ,
                                             string A9WWPUserExtendedPhone ,
                                             string A3WWPUserExtendedEmail ,
                                             bool A6WWPUserExtendedSMSNotif ,
                                             bool A7WWPUserExtendedMobileNotif ,
                                             string A1WWPUserExtendedId ,
                                             string AV6cWWPUserExtendedId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [WWP_UserExtended]";
         AddWhere(sWhereString, "([WWPUserExtendedId] like @lV6cWWPUserExtendedId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cWWPUserExtendedName)) )
         {
            AddWhere(sWhereString, "([WWPUserExtendedName] like @lV7cWWPUserExtendedName)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cWWPUserExtendedFullName)) )
         {
            AddWhere(sWhereString, "([WWPUserExtendedFullName] like @lV8cWWPUserExtendedFullName)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cWWPUserExtendedPhone)) )
         {
            AddWhere(sWhereString, "([WWPUserExtendedPhone] like @lV9cWWPUserExtendedPhone)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cWWPUserExtendedEmail)) )
         {
            AddWhere(sWhereString, "([WWPUserExtendedEmail] like @lV10cWWPUserExtendedEmail)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (false==AV11cWWPUserExtendedSMSNotif) )
         {
            AddWhere(sWhereString, "([WWPUserExtendedSMSNotif] >= @AV11cWWPUserExtendedSMSNotif)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (false==AV12cWWPUserExtendedMobileNotif) )
         {
            AddWhere(sWhereString, "([WWPUserExtendedMobileNotif] >= @AV12cWWPUserExtendedMobileNotif)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H008G2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
               case 1 :
                     return conditional_H008G3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
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
          Object[] prmH008G2;
          prmH008G2 = new Object[] {
          new ParDef("@lV6cWWPUserExtendedId",GXType.NChar,40,0) ,
          new ParDef("@lV7cWWPUserExtendedName",GXType.NVarChar,100,0) ,
          new ParDef("@lV8cWWPUserExtendedFullName",GXType.NVarChar,100,0) ,
          new ParDef("@lV9cWWPUserExtendedPhone",GXType.NChar,20,0) ,
          new ParDef("@lV10cWWPUserExtendedEmail",GXType.NVarChar,100,0) ,
          new ParDef("@AV11cWWPUserExtendedSMSNotif",GXType.Boolean,4,0) ,
          new ParDef("@AV12cWWPUserExtendedMobileNotif",GXType.Boolean,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH008G3;
          prmH008G3 = new Object[] {
          new ParDef("@lV6cWWPUserExtendedId",GXType.NChar,40,0) ,
          new ParDef("@lV7cWWPUserExtendedName",GXType.NVarChar,100,0) ,
          new ParDef("@lV8cWWPUserExtendedFullName",GXType.NVarChar,100,0) ,
          new ParDef("@lV9cWWPUserExtendedPhone",GXType.NChar,20,0) ,
          new ParDef("@lV10cWWPUserExtendedEmail",GXType.NVarChar,100,0) ,
          new ParDef("@AV11cWWPUserExtendedSMSNotif",GXType.Boolean,4,0) ,
          new ParDef("@AV12cWWPUserExtendedMobileNotif",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H008G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008G2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H008G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008G3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 40);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(7));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
