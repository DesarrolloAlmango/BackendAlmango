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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class gx00a0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00a0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx00a0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pWWPSubscriptionId )
      {
         this.AV11pWWPSubscriptionId = 0 ;
         ExecutePrivate();
         aP0_pWWPSubscriptionId=this.AV11pWWPSubscriptionId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCwwpsubscriptionsubscribed = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pWWPSubscriptionId");
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
               gxfirstwebparm = GetFirstPar( "pWWPSubscriptionId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pWWPSubscriptionId");
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
               AV11pWWPSubscriptionId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11pWWPSubscriptionId", StringUtil.LTrimStr( (decimal)(AV11pWWPSubscriptionId), 10, 0));
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
         nRC_GXsfl_64 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
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
         AV6cWWPSubscriptionId = (long)(Math.Round(NumberUtil.Val( GetPar( "cWWPSubscriptionId"), "."), 18, MidpointRounding.ToEven));
         AV7cWWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "cWWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
         AV8cWWPUserExtendedId = GetPar( "cWWPUserExtendedId");
         AV9cWWPSubscriptionRoleId = GetPar( "cWWPSubscriptionRoleId");
         AV10cWWPSubscriptionSubscribed = StringUtil.StrToBool( GetPar( "cWWPSubscriptionSubscribed"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPSubscriptionId, AV7cWWPNotificationDefinitionId, AV8cWWPUserExtendedId, AV9cWWPSubscriptionRoleId, AV10cWWPSubscriptionSubscribed) ;
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
         PA8P2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START8P2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.subscriptions.gx00a0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pWWPSubscriptionId,10,0))}, new string[] {"pWWPSubscriptionId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPSUBSCRIPTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cWWPSubscriptionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cWWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPUSEREXTENDEDID", StringUtil.RTrim( AV8cWWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPSUBSCRIPTIONROLEID", StringUtil.RTrim( AV9cWWPSubscriptionRoleId));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPSUBSCRIPTIONSUBSCRIBED", StringUtil.BoolToStr( AV10cWWPSubscriptionSubscribed));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPWWPSUBSCRIPTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pWWPSubscriptionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "WWPSUBSCRIPTIONIDFILTERCONTAINER_Class", StringUtil.RTrim( divWwpsubscriptionidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER_Class", StringUtil.RTrim( divWwpnotificationdefinitionidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDIDFILTERCONTAINER_Class", StringUtil.RTrim( divWwpuserextendedidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPSUBSCRIPTIONROLEIDFILTERCONTAINER_Class", StringUtil.RTrim( divWwpsubscriptionroleidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPSUBSCRIPTIONSUBSCRIBEDFILTERCONTAINER_Class", StringUtil.RTrim( divWwpsubscriptionsubscribedfiltercontainer_Class));
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
            WE8P2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT8P2( ) ;
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
         return formatLink("wwpbaseobjects.subscriptions.gx00a0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pWWPSubscriptionId,10,0))}, new string[] {"pWWPSubscriptionId"})  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Subscriptions.Gx00A0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List WWP_Subscription", "") ;
      }

      protected void WB8P0( )
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
            GxWebStd.gx_div_start( context, divWwpsubscriptionidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpsubscriptionidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpsubscriptionidfilter_Internalname, context.GetMessage( "Subscription Id", ""), "", "", lblLblwwpsubscriptionidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e118p1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Subscriptions/Gx00A0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpsubscriptionid_Internalname, context.GetMessage( "Subscription Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpsubscriptionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cWWPSubscriptionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCwwpsubscriptionid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cWWPSubscriptionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cWWPSubscriptionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpsubscriptionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpsubscriptionid_Visible, edtavCwwpsubscriptionid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Subscriptions/Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divWwpnotificationdefinitionidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpnotificationdefinitionidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpnotificationdefinitionidfilter_Internalname, context.GetMessage( "Notification Definition Id", ""), "", "", lblLblwwpnotificationdefinitionidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e128p1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Subscriptions/Gx00A0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpnotificationdefinitionid_Internalname, context.GetMessage( "Notification Definition Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpnotificationdefinitionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cWWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCwwpnotificationdefinitionid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cWWPNotificationDefinitionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV7cWWPNotificationDefinitionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpnotificationdefinitionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpnotificationdefinitionid_Visible, edtavCwwpnotificationdefinitionid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Subscriptions/Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divWwpuserextendedidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpuserextendedidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpuserextendedidfilter_Internalname, context.GetMessage( "User Id", ""), "", "", lblLblwwpuserextendedidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e138p1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Subscriptions/Gx00A0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpuserextendedid_Internalname, StringUtil.RTrim( AV8cWWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( AV8cWWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpuserextendedid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpuserextendedid_Visible, edtavCwwpuserextendedid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Subscriptions/Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divWwpsubscriptionroleidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpsubscriptionroleidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpsubscriptionroleidfilter_Internalname, context.GetMessage( "Subscription Role Id", ""), "", "", lblLblwwpsubscriptionroleidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e148p1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Subscriptions/Gx00A0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpsubscriptionroleid_Internalname, context.GetMessage( "Subscription Role Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpsubscriptionroleid_Internalname, StringUtil.RTrim( AV9cWWPSubscriptionRoleId), StringUtil.RTrim( context.localUtil.Format( AV9cWWPSubscriptionRoleId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpsubscriptionroleid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpsubscriptionroleid_Visible, edtavCwwpsubscriptionroleid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Subscriptions/Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divWwpsubscriptionsubscribedfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpsubscriptionsubscribedfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpsubscriptionsubscribedfilter_Internalname, context.GetMessage( "Is Subscribed", ""), "", "", lblLblwwpsubscriptionsubscribedfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e158p1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Subscriptions/Gx00A0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCwwpsubscriptionsubscribed_Internalname, context.GetMessage( "Is Subscribed", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCwwpsubscriptionsubscribed_Internalname, StringUtil.BoolToStr( AV10cWWPSubscriptionSubscribed), "", context.GetMessage( "Is Subscribed", ""), chkavCwwpsubscriptionsubscribed.Visible, chkavCwwpsubscriptionsubscribed.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,56);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e168p1_client"+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Subscriptions/Gx00A0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl64( ) ;
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/Gx00A0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 64 )
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

      protected void START8P2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List WWP_Subscription", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP8P0( ) ;
      }

      protected void WS8P2( )
      {
         START8P2( ) ;
         EVT8P2( ) ;
      }

      protected void EVT8P2( )
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
                              nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_642( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV13Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A34WWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A32WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A1WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
                              n1WWPUserExtendedId = false;
                              A28WWPSubscriptionRoleId = cgiGet( edtWWPSubscriptionRoleId_Internalname);
                              n28WWPSubscriptionRoleId = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E178P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E188P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cwwpsubscriptionid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPSUBSCRIPTIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cWWPSubscriptionId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpnotificationdefinitionid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPNOTIFICATIONDEFINITIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cWWPNotificationDefinitionId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpuserextendedid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPUSEREXTENDEDID"), AV8cWWPUserExtendedId) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpsubscriptionroleid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPSUBSCRIPTIONROLEID"), AV9cWWPSubscriptionRoleId) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpsubscriptionsubscribed Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCWWPSUBSCRIPTIONSUBSCRIBED")) != AV10cWWPSubscriptionSubscribed )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E198P2 ();
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

      protected void WE8P2( )
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

      protected void PA8P2( )
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
         SubsflControlProps_642( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_642( ) ;
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cWWPSubscriptionId ,
                                        long AV7cWWPNotificationDefinitionId ,
                                        string AV8cWWPUserExtendedId ,
                                        string AV9cWWPSubscriptionRoleId ,
                                        bool AV10cWWPSubscriptionSubscribed )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF8P2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPSUBSCRIPTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A34WWPSubscriptionId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPSUBSCRIPTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A34WWPSubscriptionId), 10, 0, ".", "")));
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
         AV10cWWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( AV10cWWPSubscriptionSubscribed));
         AssignAttri("", false, "AV10cWWPSubscriptionSubscribed", AV10cWWPSubscriptionSubscribed);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF8P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF8P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 64;
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         bGXsfl_64_Refreshing = true;
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
            SubsflControlProps_642( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cWWPNotificationDefinitionId ,
                                                 AV8cWWPUserExtendedId ,
                                                 AV9cWWPSubscriptionRoleId ,
                                                 AV10cWWPSubscriptionSubscribed ,
                                                 A32WWPNotificationDefinitionId ,
                                                 A1WWPUserExtendedId ,
                                                 A28WWPSubscriptionRoleId ,
                                                 A36WWPSubscriptionSubscribed ,
                                                 AV6cWWPSubscriptionId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG
                                                 }
            });
            lV8cWWPUserExtendedId = StringUtil.PadR( StringUtil.RTrim( AV8cWWPUserExtendedId), 40, "%");
            lV9cWWPSubscriptionRoleId = StringUtil.PadR( StringUtil.RTrim( AV9cWWPSubscriptionRoleId), 40, "%");
            /* Using cursor H008P2 */
            pr_default.execute(0, new Object[] {AV6cWWPSubscriptionId, AV7cWWPNotificationDefinitionId, lV8cWWPUserExtendedId, lV9cWWPSubscriptionRoleId, AV10cWWPSubscriptionSubscribed, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A36WWPSubscriptionSubscribed = H008P2_A36WWPSubscriptionSubscribed[0];
               A28WWPSubscriptionRoleId = H008P2_A28WWPSubscriptionRoleId[0];
               n28WWPSubscriptionRoleId = H008P2_n28WWPSubscriptionRoleId[0];
               A1WWPUserExtendedId = H008P2_A1WWPUserExtendedId[0];
               n1WWPUserExtendedId = H008P2_n1WWPUserExtendedId[0];
               A32WWPNotificationDefinitionId = H008P2_A32WWPNotificationDefinitionId[0];
               A34WWPSubscriptionId = H008P2_A34WWPSubscriptionId[0];
               /* Execute user event: Load */
               E188P2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB8P0( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes8P2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPSUBSCRIPTIONID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A34WWPSubscriptionId), "ZZZZZZZZZ9"), context));
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
                                              AV7cWWPNotificationDefinitionId ,
                                              AV8cWWPUserExtendedId ,
                                              AV9cWWPSubscriptionRoleId ,
                                              AV10cWWPSubscriptionSubscribed ,
                                              A32WWPNotificationDefinitionId ,
                                              A1WWPUserExtendedId ,
                                              A28WWPSubscriptionRoleId ,
                                              A36WWPSubscriptionSubscribed ,
                                              AV6cWWPSubscriptionId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         lV8cWWPUserExtendedId = StringUtil.PadR( StringUtil.RTrim( AV8cWWPUserExtendedId), 40, "%");
         lV9cWWPSubscriptionRoleId = StringUtil.PadR( StringUtil.RTrim( AV9cWWPSubscriptionRoleId), 40, "%");
         /* Using cursor H008P3 */
         pr_default.execute(1, new Object[] {AV6cWWPSubscriptionId, AV7cWWPNotificationDefinitionId, lV8cWWPUserExtendedId, lV9cWWPSubscriptionRoleId, AV10cWWPSubscriptionSubscribed});
         GRID1_nRecordCount = H008P3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPSubscriptionId, AV7cWWPNotificationDefinitionId, AV8cWWPUserExtendedId, AV9cWWPSubscriptionRoleId, AV10cWWPSubscriptionSubscribed) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPSubscriptionId, AV7cWWPNotificationDefinitionId, AV8cWWPUserExtendedId, AV9cWWPSubscriptionRoleId, AV10cWWPSubscriptionSubscribed) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPSubscriptionId, AV7cWWPNotificationDefinitionId, AV8cWWPUserExtendedId, AV9cWWPSubscriptionRoleId, AV10cWWPSubscriptionSubscribed) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPSubscriptionId, AV7cWWPNotificationDefinitionId, AV8cWWPUserExtendedId, AV9cWWPSubscriptionRoleId, AV10cWWPSubscriptionSubscribed) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPSubscriptionId, AV7cWWPNotificationDefinitionId, AV8cWWPUserExtendedId, AV9cWWPSubscriptionRoleId, AV10cWWPSubscriptionSubscribed) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtWWPSubscriptionId_Enabled = 0;
         edtWWPNotificationDefinitionId_Enabled = 0;
         edtWWPUserExtendedId_Enabled = 0;
         edtWWPSubscriptionRoleId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E178P2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCwwpsubscriptionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCwwpsubscriptionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCWWPSUBSCRIPTIONID");
               GX_FocusControl = edtavCwwpsubscriptionid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cWWPSubscriptionId = 0;
               AssignAttri("", false, "AV6cWWPSubscriptionId", StringUtil.LTrimStr( (decimal)(AV6cWWPSubscriptionId), 10, 0));
            }
            else
            {
               AV6cWWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCwwpsubscriptionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cWWPSubscriptionId", StringUtil.LTrimStr( (decimal)(AV6cWWPSubscriptionId), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCwwpnotificationdefinitionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCwwpnotificationdefinitionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCWWPNOTIFICATIONDEFINITIONID");
               GX_FocusControl = edtavCwwpnotificationdefinitionid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cWWPNotificationDefinitionId = 0;
               AssignAttri("", false, "AV7cWWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(AV7cWWPNotificationDefinitionId), 10, 0));
            }
            else
            {
               AV7cWWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCwwpnotificationdefinitionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cWWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(AV7cWWPNotificationDefinitionId), 10, 0));
            }
            AV8cWWPUserExtendedId = cgiGet( edtavCwwpuserextendedid_Internalname);
            AssignAttri("", false, "AV8cWWPUserExtendedId", AV8cWWPUserExtendedId);
            AV9cWWPSubscriptionRoleId = cgiGet( edtavCwwpsubscriptionroleid_Internalname);
            AssignAttri("", false, "AV9cWWPSubscriptionRoleId", AV9cWWPSubscriptionRoleId);
            AV10cWWPSubscriptionSubscribed = StringUtil.StrToBool( cgiGet( chkavCwwpsubscriptionsubscribed_Internalname));
            AssignAttri("", false, "AV10cWWPSubscriptionSubscribed", AV10cWWPSubscriptionSubscribed);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPSUBSCRIPTIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cWWPSubscriptionId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPNOTIFICATIONDEFINITIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cWWPNotificationDefinitionId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPUSEREXTENDEDID"), AV8cWWPUserExtendedId) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPSUBSCRIPTIONROLEID"), AV9cWWPSubscriptionRoleId) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCWWPSUBSCRIPTIONSUBSCRIBED")) != AV10cWWPSubscriptionSubscribed )
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
         E178P2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E178P2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "WWP_Subscription", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV12ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E188P2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV13Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_642( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
         {
            context.DoAjaxLoad(64, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E198P2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E198P2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV11pWWPSubscriptionId = A34WWPSubscriptionId;
         AssignAttri("", false, "AV11pWWPSubscriptionId", StringUtil.LTrimStr( (decimal)(AV11pWWPSubscriptionId), 10, 0));
         context.setWebReturnParms(new Object[] {(long)AV11pWWPSubscriptionId});
         context.setWebReturnParmsMetadata(new Object[] {"AV11pWWPSubscriptionId"});
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
         AV11pWWPSubscriptionId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV11pWWPSubscriptionId", StringUtil.LTrimStr( (decimal)(AV11pWWPSubscriptionId), 10, 0));
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
         PA8P2( ) ;
         WS8P2( ) ;
         WE8P2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021254291", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/subscriptions/gx00a0.js", "?202673021254291", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtWWPSubscriptionId_Internalname = "WWPSUBSCRIPTIONID_"+sGXsfl_64_idx;
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID_"+sGXsfl_64_idx;
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID_"+sGXsfl_64_idx;
         edtWWPSubscriptionRoleId_Internalname = "WWPSUBSCRIPTIONROLEID_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtWWPSubscriptionId_Internalname = "WWPSUBSCRIPTIONID_"+sGXsfl_64_fel_idx;
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID_"+sGXsfl_64_fel_idx;
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID_"+sGXsfl_64_fel_idx;
         edtWWPSubscriptionRoleId_Internalname = "WWPSUBSCRIPTIONROLEID_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         WB8P0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_64_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_64_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A34WWPSubscriptionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV13Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV13Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPSubscriptionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A34WWPSubscriptionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A34WWPSubscriptionId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPSubscriptionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationDefinitionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A32WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A32WWPNotificationDefinitionId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPNotificationDefinitionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPUserExtendedId_Internalname,StringUtil.RTrim( A1WWPUserExtendedId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPUserExtendedId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"WWPBaseObjects\\WWP_GAMGUID",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPSubscriptionRoleId_Internalname,StringUtil.RTrim( A28WWPSubscriptionRoleId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPSubscriptionRoleId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"WWPBaseObjects\\WWP_GAMGUID",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes8P2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         chkavCwwpsubscriptionsubscribed.Name = "vCWWPSUBSCRIPTIONSUBSCRIBED";
         chkavCwwpsubscriptionsubscribed.WebTags = "";
         chkavCwwpsubscriptionsubscribed.Caption = context.GetMessage( "Is Subscribed", "");
         AssignProp("", false, chkavCwwpsubscriptionsubscribed_Internalname, "TitleCaption", chkavCwwpsubscriptionsubscribed.Caption, true);
         chkavCwwpsubscriptionsubscribed.CheckedValue = "false";
         AV10cWWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( AV10cWWPSubscriptionSubscribed));
         AssignAttri("", false, "AV10cWWPSubscriptionSubscribed", AV10cWWPSubscriptionSubscribed);
         /* End function init_web_controls */
      }

      protected void StartGridControl64( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"64\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Definition Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "User Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Role Id", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A34WWPSubscriptionId), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A32WWPNotificationDefinitionId), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A1WWPUserExtendedId)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A28WWPSubscriptionRoleId)));
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
         lblLblwwpsubscriptionidfilter_Internalname = "LBLWWPSUBSCRIPTIONIDFILTER";
         edtavCwwpsubscriptionid_Internalname = "vCWWPSUBSCRIPTIONID";
         divWwpsubscriptionidfiltercontainer_Internalname = "WWPSUBSCRIPTIONIDFILTERCONTAINER";
         lblLblwwpnotificationdefinitionidfilter_Internalname = "LBLWWPNOTIFICATIONDEFINITIONIDFILTER";
         edtavCwwpnotificationdefinitionid_Internalname = "vCWWPNOTIFICATIONDEFINITIONID";
         divWwpnotificationdefinitionidfiltercontainer_Internalname = "WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER";
         lblLblwwpuserextendedidfilter_Internalname = "LBLWWPUSEREXTENDEDIDFILTER";
         edtavCwwpuserextendedid_Internalname = "vCWWPUSEREXTENDEDID";
         divWwpuserextendedidfiltercontainer_Internalname = "WWPUSEREXTENDEDIDFILTERCONTAINER";
         lblLblwwpsubscriptionroleidfilter_Internalname = "LBLWWPSUBSCRIPTIONROLEIDFILTER";
         edtavCwwpsubscriptionroleid_Internalname = "vCWWPSUBSCRIPTIONROLEID";
         divWwpsubscriptionroleidfiltercontainer_Internalname = "WWPSUBSCRIPTIONROLEIDFILTERCONTAINER";
         lblLblwwpsubscriptionsubscribedfilter_Internalname = "LBLWWPSUBSCRIPTIONSUBSCRIBEDFILTER";
         chkavCwwpsubscriptionsubscribed_Internalname = "vCWWPSUBSCRIPTIONSUBSCRIBED";
         divWwpsubscriptionsubscribedfiltercontainer_Internalname = "WWPSUBSCRIPTIONSUBSCRIBEDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtWWPSubscriptionId_Internalname = "WWPSUBSCRIPTIONID";
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         edtWWPSubscriptionRoleId_Internalname = "WWPSUBSCRIPTIONROLEID";
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
         chkavCwwpsubscriptionsubscribed.Caption = context.GetMessage( "Is Subscribed", "");
         edtWWPSubscriptionRoleId_Jsonclick = "";
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPSubscriptionId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtWWPSubscriptionRoleId_Enabled = 0;
         edtWWPUserExtendedId_Enabled = 0;
         edtWWPNotificationDefinitionId_Enabled = 0;
         edtWWPSubscriptionId_Enabled = 0;
         chkavCwwpsubscriptionsubscribed.Enabled = 1;
         chkavCwwpsubscriptionsubscribed.Visible = 1;
         edtavCwwpsubscriptionroleid_Jsonclick = "";
         edtavCwwpsubscriptionroleid_Enabled = 1;
         edtavCwwpsubscriptionroleid_Visible = 1;
         edtavCwwpuserextendedid_Jsonclick = "";
         edtavCwwpuserextendedid_Enabled = 1;
         edtavCwwpuserextendedid_Visible = 1;
         edtavCwwpnotificationdefinitionid_Jsonclick = "";
         edtavCwwpnotificationdefinitionid_Enabled = 1;
         edtavCwwpnotificationdefinitionid_Visible = 1;
         edtavCwwpsubscriptionid_Jsonclick = "";
         edtavCwwpsubscriptionid_Enabled = 1;
         edtavCwwpsubscriptionid_Visible = 1;
         divWwpsubscriptionsubscribedfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpsubscriptionroleidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpuserextendedidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpnotificationdefinitionidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpsubscriptionidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List WWP_Subscription", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPSubscriptionId',fld:'vCWWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV7cWWPNotificationDefinitionId',fld:'vCWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV8cWWPUserExtendedId',fld:'vCWWPUSEREXTENDEDID',pic:'',type:'char'},{av:'AV9cWWPSubscriptionRoleId',fld:'vCWWPSUBSCRIPTIONROLEID',pic:'',type:'char'},{av:'AV10cWWPSubscriptionSubscribed',fld:'vCWWPSUBSCRIPTIONSUBSCRIBED',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E168P1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLWWPSUBSCRIPTIONIDFILTER.CLICK","{handler:'E118P1',iparms:[{av:'divWwpsubscriptionidfiltercontainer_Class',ctrl:'WWPSUBSCRIPTIONIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPSUBSCRIPTIONIDFILTER.CLICK",",oparms:[{av:'divWwpsubscriptionidfiltercontainer_Class',ctrl:'WWPSUBSCRIPTIONIDFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpsubscriptionid_Visible',ctrl:'vCWWPSUBSCRIPTIONID',prop:'Visible'}]}");
         setEventMetadata("LBLWWPNOTIFICATIONDEFINITIONIDFILTER.CLICK","{handler:'E128P1',iparms:[{av:'divWwpnotificationdefinitionidfiltercontainer_Class',ctrl:'WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPNOTIFICATIONDEFINITIONIDFILTER.CLICK",",oparms:[{av:'divWwpnotificationdefinitionidfiltercontainer_Class',ctrl:'WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpnotificationdefinitionid_Visible',ctrl:'vCWWPNOTIFICATIONDEFINITIONID',prop:'Visible'}]}");
         setEventMetadata("LBLWWPUSEREXTENDEDIDFILTER.CLICK","{handler:'E138P1',iparms:[{av:'divWwpuserextendedidfiltercontainer_Class',ctrl:'WWPUSEREXTENDEDIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPUSEREXTENDEDIDFILTER.CLICK",",oparms:[{av:'divWwpuserextendedidfiltercontainer_Class',ctrl:'WWPUSEREXTENDEDIDFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpuserextendedid_Visible',ctrl:'vCWWPUSEREXTENDEDID',prop:'Visible'}]}");
         setEventMetadata("LBLWWPSUBSCRIPTIONROLEIDFILTER.CLICK","{handler:'E148P1',iparms:[{av:'divWwpsubscriptionroleidfiltercontainer_Class',ctrl:'WWPSUBSCRIPTIONROLEIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPSUBSCRIPTIONROLEIDFILTER.CLICK",",oparms:[{av:'divWwpsubscriptionroleidfiltercontainer_Class',ctrl:'WWPSUBSCRIPTIONROLEIDFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpsubscriptionroleid_Visible',ctrl:'vCWWPSUBSCRIPTIONROLEID',prop:'Visible'}]}");
         setEventMetadata("LBLWWPSUBSCRIPTIONSUBSCRIBEDFILTER.CLICK","{handler:'E158P1',iparms:[{av:'divWwpsubscriptionsubscribedfiltercontainer_Class',ctrl:'WWPSUBSCRIPTIONSUBSCRIBEDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPSUBSCRIPTIONSUBSCRIBEDFILTER.CLICK",",oparms:[{av:'divWwpsubscriptionsubscribedfiltercontainer_Class',ctrl:'WWPSUBSCRIPTIONSUBSCRIBEDFILTERCONTAINER',prop:'Class'},{av:'chkavCwwpsubscriptionsubscribed.Visible',ctrl:'vCWWPSUBSCRIPTIONSUBSCRIBED',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E198P2',iparms:[{av:'A34WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV11pWWPSubscriptionId',fld:'vPWWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPSubscriptionId',fld:'vCWWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV7cWWPNotificationDefinitionId',fld:'vCWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV8cWWPUserExtendedId',fld:'vCWWPUSEREXTENDEDID',pic:'',type:'char'},{av:'AV9cWWPSubscriptionRoleId',fld:'vCWWPSUBSCRIPTIONROLEID',pic:'',type:'char'},{av:'AV10cWWPSubscriptionSubscribed',fld:'vCWWPSUBSCRIPTIONSUBSCRIBED',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPSubscriptionId',fld:'vCWWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV7cWWPNotificationDefinitionId',fld:'vCWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV8cWWPUserExtendedId',fld:'vCWWPUSEREXTENDEDID',pic:'',type:'char'},{av:'AV9cWWPSubscriptionRoleId',fld:'vCWWPSUBSCRIPTIONROLEID',pic:'',type:'char'},{av:'AV10cWWPSubscriptionSubscribed',fld:'vCWWPSUBSCRIPTIONSUBSCRIBED',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPSubscriptionId',fld:'vCWWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV7cWWPNotificationDefinitionId',fld:'vCWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV8cWWPUserExtendedId',fld:'vCWWPUSEREXTENDEDID',pic:'',type:'char'},{av:'AV9cWWPSubscriptionRoleId',fld:'vCWWPSUBSCRIPTIONROLEID',pic:'',type:'char'},{av:'AV10cWWPSubscriptionSubscribed',fld:'vCWWPSUBSCRIPTIONSUBSCRIBED',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPSubscriptionId',fld:'vCWWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV7cWWPNotificationDefinitionId',fld:'vCWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV8cWWPUserExtendedId',fld:'vCWWPUSEREXTENDEDID',pic:'',type:'char'},{av:'AV9cWWPSubscriptionRoleId',fld:'vCWWPSUBSCRIPTIONROLEID',pic:'',type:'char'},{av:'AV10cWWPSubscriptionSubscribed',fld:'vCWWPSUBSCRIPTIONSUBSCRIBED',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Wwpsubscriptionroleid',iparms:[]");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV8cWWPUserExtendedId = "";
         AV9cWWPSubscriptionRoleId = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblwwpsubscriptionidfilter_Jsonclick = "";
         TempTags = "";
         lblLblwwpnotificationdefinitionidfilter_Jsonclick = "";
         lblLblwwpuserextendedidfilter_Jsonclick = "";
         lblLblwwpsubscriptionroleidfilter_Jsonclick = "";
         lblLblwwpsubscriptionsubscribedfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV13Linkselection_GXI = "";
         A1WWPUserExtendedId = "";
         A28WWPSubscriptionRoleId = "";
         lV8cWWPUserExtendedId = "";
         lV9cWWPSubscriptionRoleId = "";
         H008P2_A36WWPSubscriptionSubscribed = new bool[] {false} ;
         H008P2_A28WWPSubscriptionRoleId = new string[] {""} ;
         H008P2_n28WWPSubscriptionRoleId = new bool[] {false} ;
         H008P2_A1WWPUserExtendedId = new string[] {""} ;
         H008P2_n1WWPUserExtendedId = new bool[] {false} ;
         H008P2_A32WWPNotificationDefinitionId = new long[1] ;
         H008P2_A34WWPSubscriptionId = new long[1] ;
         H008P3_AGRID1_nRecordCount = new long[1] ;
         AV12ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.gx00a0__default(),
            new Object[][] {
                new Object[] {
               H008P2_A36WWPSubscriptionSubscribed, H008P2_A28WWPSubscriptionRoleId, H008P2_n28WWPSubscriptionRoleId, H008P2_A1WWPUserExtendedId, H008P2_n1WWPUserExtendedId, H008P2_A32WWPNotificationDefinitionId, H008P2_A34WWPSubscriptionId
               }
               , new Object[] {
               H008P3_AGRID1_nRecordCount
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
      private int nRC_GXsfl_64 ;
      private int subGrid1_Rows ;
      private int nGXsfl_64_idx=1 ;
      private int edtavCwwpsubscriptionid_Enabled ;
      private int edtavCwwpsubscriptionid_Visible ;
      private int edtavCwwpnotificationdefinitionid_Enabled ;
      private int edtavCwwpnotificationdefinitionid_Visible ;
      private int edtavCwwpuserextendedid_Visible ;
      private int edtavCwwpuserextendedid_Enabled ;
      private int edtavCwwpsubscriptionroleid_Visible ;
      private int edtavCwwpsubscriptionroleid_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtWWPSubscriptionId_Enabled ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int edtWWPSubscriptionRoleId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV11pWWPSubscriptionId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cWWPSubscriptionId ;
      private long AV7cWWPNotificationDefinitionId ;
      private long A34WWPSubscriptionId ;
      private long A32WWPNotificationDefinitionId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divWwpsubscriptionidfiltercontainer_Class ;
      private string divWwpnotificationdefinitionidfiltercontainer_Class ;
      private string divWwpuserextendedidfiltercontainer_Class ;
      private string divWwpsubscriptionroleidfiltercontainer_Class ;
      private string divWwpsubscriptionsubscribedfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string AV8cWWPUserExtendedId ;
      private string AV9cWWPSubscriptionRoleId ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divWwpsubscriptionidfiltercontainer_Internalname ;
      private string lblLblwwpsubscriptionidfilter_Internalname ;
      private string lblLblwwpsubscriptionidfilter_Jsonclick ;
      private string edtavCwwpsubscriptionid_Internalname ;
      private string TempTags ;
      private string edtavCwwpsubscriptionid_Jsonclick ;
      private string divWwpnotificationdefinitionidfiltercontainer_Internalname ;
      private string lblLblwwpnotificationdefinitionidfilter_Internalname ;
      private string lblLblwwpnotificationdefinitionidfilter_Jsonclick ;
      private string edtavCwwpnotificationdefinitionid_Internalname ;
      private string edtavCwwpnotificationdefinitionid_Jsonclick ;
      private string divWwpuserextendedidfiltercontainer_Internalname ;
      private string lblLblwwpuserextendedidfilter_Internalname ;
      private string lblLblwwpuserextendedidfilter_Jsonclick ;
      private string edtavCwwpuserextendedid_Internalname ;
      private string edtavCwwpuserextendedid_Jsonclick ;
      private string divWwpsubscriptionroleidfiltercontainer_Internalname ;
      private string lblLblwwpsubscriptionroleidfilter_Internalname ;
      private string lblLblwwpsubscriptionroleidfilter_Jsonclick ;
      private string edtavCwwpsubscriptionroleid_Internalname ;
      private string edtavCwwpsubscriptionroleid_Jsonclick ;
      private string divWwpsubscriptionsubscribedfiltercontainer_Internalname ;
      private string lblLblwwpsubscriptionsubscribedfilter_Internalname ;
      private string lblLblwwpsubscriptionsubscribedfilter_Jsonclick ;
      private string chkavCwwpsubscriptionsubscribed_Internalname ;
      private string ClassString ;
      private string StyleString ;
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
      private string edtWWPSubscriptionId_Internalname ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string A1WWPUserExtendedId ;
      private string edtWWPUserExtendedId_Internalname ;
      private string A28WWPSubscriptionRoleId ;
      private string edtWWPSubscriptionRoleId_Internalname ;
      private string lV8cWWPUserExtendedId ;
      private string lV9cWWPSubscriptionRoleId ;
      private string AV12ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtWWPSubscriptionId_Jsonclick ;
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string edtWWPSubscriptionRoleId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10cWWPSubscriptionSubscribed ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool n1WWPUserExtendedId ;
      private bool n28WWPSubscriptionRoleId ;
      private bool gxdyncontrolsrefreshing ;
      private bool A36WWPSubscriptionSubscribed ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV13Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCwwpsubscriptionsubscribed ;
      private IDataStoreProvider pr_default ;
      private bool[] H008P2_A36WWPSubscriptionSubscribed ;
      private string[] H008P2_A28WWPSubscriptionRoleId ;
      private bool[] H008P2_n28WWPSubscriptionRoleId ;
      private string[] H008P2_A1WWPUserExtendedId ;
      private bool[] H008P2_n1WWPUserExtendedId ;
      private long[] H008P2_A32WWPNotificationDefinitionId ;
      private long[] H008P2_A34WWPSubscriptionId ;
      private long[] H008P3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pWWPSubscriptionId ;
   }

   public class gx00a0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H008P2( IGxContext context ,
                                             long AV7cWWPNotificationDefinitionId ,
                                             string AV8cWWPUserExtendedId ,
                                             string AV9cWWPSubscriptionRoleId ,
                                             bool AV10cWWPSubscriptionSubscribed ,
                                             long A32WWPNotificationDefinitionId ,
                                             string A1WWPUserExtendedId ,
                                             string A28WWPSubscriptionRoleId ,
                                             bool A36WWPSubscriptionSubscribed ,
                                             long AV6cWWPSubscriptionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [WWPSubscriptionSubscribed], [WWPSubscriptionRoleId], [WWPUserExtendedId], [WWPNotificationDefinitionId], [WWPSubscriptionId]";
         sFromString = " FROM [WWP_Subscription]";
         sOrderString = "";
         AddWhere(sWhereString, "([WWPSubscriptionId] >= @AV6cWWPSubscriptionId)");
         if ( ! (0==AV7cWWPNotificationDefinitionId) )
         {
            AddWhere(sWhereString, "([WWPNotificationDefinitionId] >= @AV7cWWPNotificationDefinitionId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cWWPUserExtendedId)) )
         {
            AddWhere(sWhereString, "([WWPUserExtendedId] like @lV8cWWPUserExtendedId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cWWPSubscriptionRoleId)) )
         {
            AddWhere(sWhereString, "([WWPSubscriptionRoleId] like @lV9cWWPSubscriptionRoleId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (false==AV10cWWPSubscriptionSubscribed) )
         {
            AddWhere(sWhereString, "([WWPSubscriptionSubscribed] >= @AV10cWWPSubscriptionSubscribed)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         sOrderString += " ORDER BY [WWPSubscriptionId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H008P3( IGxContext context ,
                                             long AV7cWWPNotificationDefinitionId ,
                                             string AV8cWWPUserExtendedId ,
                                             string AV9cWWPSubscriptionRoleId ,
                                             bool AV10cWWPSubscriptionSubscribed ,
                                             long A32WWPNotificationDefinitionId ,
                                             string A1WWPUserExtendedId ,
                                             string A28WWPSubscriptionRoleId ,
                                             bool A36WWPSubscriptionSubscribed ,
                                             long AV6cWWPSubscriptionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [WWP_Subscription]";
         AddWhere(sWhereString, "([WWPSubscriptionId] >= @AV6cWWPSubscriptionId)");
         if ( ! (0==AV7cWWPNotificationDefinitionId) )
         {
            AddWhere(sWhereString, "([WWPNotificationDefinitionId] >= @AV7cWWPNotificationDefinitionId)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cWWPUserExtendedId)) )
         {
            AddWhere(sWhereString, "([WWPUserExtendedId] like @lV8cWWPUserExtendedId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cWWPSubscriptionRoleId)) )
         {
            AddWhere(sWhereString, "([WWPSubscriptionRoleId] like @lV9cWWPSubscriptionRoleId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (false==AV10cWWPSubscriptionSubscribed) )
         {
            AddWhere(sWhereString, "([WWPSubscriptionSubscribed] >= @AV10cWWPSubscriptionSubscribed)");
         }
         else
         {
            GXv_int3[4] = 1;
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
                     return conditional_H008P2(context, (long)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (long)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (long)dynConstraints[8] );
               case 1 :
                     return conditional_H008P3(context, (long)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (long)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (long)dynConstraints[8] );
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
          Object[] prmH008P2;
          prmH008P2 = new Object[] {
          new ParDef("@AV6cWWPSubscriptionId",GXType.Decimal,10,0) ,
          new ParDef("@AV7cWWPNotificationDefinitionId",GXType.Decimal,10,0) ,
          new ParDef("@lV8cWWPUserExtendedId",GXType.NChar,40,0) ,
          new ParDef("@lV9cWWPSubscriptionRoleId",GXType.NChar,40,0) ,
          new ParDef("@AV10cWWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH008P3;
          prmH008P3 = new Object[] {
          new ParDef("@AV6cWWPSubscriptionId",GXType.Decimal,10,0) ,
          new ParDef("@AV7cWWPNotificationDefinitionId",GXType.Decimal,10,0) ,
          new ParDef("@lV8cWWPUserExtendedId",GXType.NChar,40,0) ,
          new ParDef("@lV9cWWPSubscriptionRoleId",GXType.NChar,40,0) ,
          new ParDef("@AV10cWWPSubscriptionSubscribed",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H008P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008P2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H008P3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008P3,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 40);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
