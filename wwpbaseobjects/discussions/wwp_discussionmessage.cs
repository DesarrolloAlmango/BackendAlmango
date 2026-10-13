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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_discussionmessage : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel3"+"_"+"WWPUSEREXTENDEDID") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX3ASAWWPUSEREXTENDEDID1Y78( Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A539WWPDiscussionMessageThreadId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPDiscussionMessageThreadId"), "."), 18, MidpointRounding.ToEven));
            n539WWPDiscussionMessageThreadId = false;
            AssignAttri("", false, "A539WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A539WWPDiscussionMessageThreadId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A539WWPDiscussionMessageThreadId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A1WWPUserExtendedId = GetPar( "WWPUserExtendedId");
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A1WWPUserExtendedId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A29WWPEntityId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPEntityId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A29WWPEntityId", StringUtil.LTrimStr( (decimal)(A29WWPEntityId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A29WWPEntityId) ;
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
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
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
         GXKey = Crypto.GetSiteKey( );
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Discussion Message", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_discussionmessage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_discussionmessage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Discussion Message", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"wwpbaseobjects.discussions.gx0260.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPDISCUSSIONMESSAGEID"+"'), id:'"+"WWPDISCUSSIONMESSAGEID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A540WWPDiscussionMessageId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPDiscussionMessageId_Enabled!=0) ? context.localUtil.Format( (decimal)(A540WWPDiscussionMessageId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A540WWPDiscussionMessageId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageDate_Internalname, context.GetMessage( "Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPDiscussionMessageDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageDate_Internalname, context.localUtil.TToC( A543WWPDiscussionMessageDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A543WWPDiscussionMessageDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageDate_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_bitmap( context, edtWWPDiscussionMessageDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPDiscussionMessageDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageThreadId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageThreadId_Internalname, context.GetMessage( "Thread Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageThreadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A539WWPDiscussionMessageThreadId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPDiscussionMessageThreadId_Enabled!=0) ? context.localUtil.Format( (decimal)(A539WWPDiscussionMessageThreadId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A539WWPDiscussionMessageThreadId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageThreadId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageThreadId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_539_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_539_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_539_Internalname, sImgUrl, imgprompt_539_Link, "", "", context.GetTheme( ), imgprompt_539_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageMessage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageMessage_Internalname, context.GetMessage( "Message", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPDiscussionMessageMessage_Internalname, A544WWPDiscussionMessageMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtWWPDiscussionMessageMessage_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedId_Internalname, context.GetMessage( "User Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A1WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A1WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_1_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_1_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgWWPUserExtendedPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "User Photo", ""), "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A4WWPUserExtendedPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000WWPUserExtendedPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.PathToRelativeUrl( A4WWPUserExtendedPhoto));
         GxWebStd.gx_bitmap( context, imgWWPUserExtendedPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgWWPUserExtendedPhoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", "", "", 0, A4WWPUserExtendedPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.PathToRelativeUrl( A4WWPUserExtendedPhoto)), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A4WWPUserExtendedPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedFullName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedFullName_Internalname, context.GetMessage( "User Full Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A2WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A2WWPUserExtendedFullName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPEntityId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPEntityId_Internalname, context.GetMessage( "Entity Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29WWPEntityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPEntityId_Enabled!=0) ? context.localUtil.Format( (decimal)(A29WWPEntityId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A29WWPEntityId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_29_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_29_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_29_Internalname, sImgUrl, imgprompt_29_Link, "", "", context.GetTheme( ), imgprompt_29_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPEntityName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPEntityName_Internalname, context.GetMessage( "Entity Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityName_Internalname, A30WWPEntityName, StringUtil.RTrim( context.localUtil.Format( A30WWPEntityName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageEntityReco_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageEntityReco_Internalname, context.GetMessage( "Record Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageEntityReco_Internalname, A545WWPDiscussionMessageEntityReco, StringUtil.RTrim( context.localUtil.Format( A545WWPDiscussionMessageEntityReco, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageEntityReco_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageEntityReco_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z540WWPDiscussionMessageId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z540WWPDiscussionMessageId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z543WWPDiscussionMessageDate = context.localUtil.CToT( cgiGet( "Z543WWPDiscussionMessageDate"), 0);
            Z544WWPDiscussionMessageMessage = cgiGet( "Z544WWPDiscussionMessageMessage");
            Z545WWPDiscussionMessageEntityReco = cgiGet( "Z545WWPDiscussionMessageEntityReco");
            Z1WWPUserExtendedId = cgiGet( "Z1WWPUserExtendedId");
            Z29WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z29WWPEntityId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z539WWPDiscussionMessageThreadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z539WWPDiscussionMessageThreadId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n539WWPDiscussionMessageThreadId = ((0==A539WWPDiscussionMessageThreadId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A40000WWPUserExtendedPhoto_GXI = cgiGet( "WWPUSEREXTENDEDPHOTO_GXI");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPDISCUSSIONMESSAGEID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A540WWPDiscussionMessageId = 0;
               AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
            }
            else
            {
               A540WWPDiscussionMessageId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPDiscussionMessageDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Message Date", "")}), 1, "WWPDISCUSSIONMESSAGEDATE");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A543WWPDiscussionMessageDate = context.localUtil.CToT( cgiGet( edtWWPDiscussionMessageDate_Internalname));
               AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageThreadId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageThreadId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A539WWPDiscussionMessageThreadId = 0;
               n539WWPDiscussionMessageThreadId = false;
               AssignAttri("", false, "A539WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A539WWPDiscussionMessageThreadId), 10, 0));
            }
            else
            {
               A539WWPDiscussionMessageThreadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageThreadId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n539WWPDiscussionMessageThreadId = false;
               AssignAttri("", false, "A539WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A539WWPDiscussionMessageThreadId), 10, 0));
            }
            n539WWPDiscussionMessageThreadId = ((0==A539WWPDiscussionMessageThreadId) ? true : false);
            A544WWPDiscussionMessageMessage = cgiGet( edtWWPDiscussionMessageMessage_Internalname);
            AssignAttri("", false, "A544WWPDiscussionMessageMessage", A544WWPDiscussionMessageMessage);
            A1WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            A4WWPUserExtendedPhoto = cgiGet( imgWWPUserExtendedPhoto_Internalname);
            AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
            A2WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPEntityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPEntityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPENTITYID");
               AnyError = 1;
               GX_FocusControl = edtWWPEntityId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A29WWPEntityId = 0;
               AssignAttri("", false, "A29WWPEntityId", StringUtil.LTrimStr( (decimal)(A29WWPEntityId), 10, 0));
            }
            else
            {
               A29WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPEntityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A29WWPEntityId", StringUtil.LTrimStr( (decimal)(A29WWPEntityId), 10, 0));
            }
            A30WWPEntityName = cgiGet( edtWWPEntityName_Internalname);
            AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
            A545WWPDiscussionMessageEntityReco = cgiGet( edtWWPDiscussionMessageEntityReco_Internalname);
            AssignAttri("", false, "A545WWPDiscussionMessageEntityReco", A545WWPDiscussionMessageEntityReco);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgWWPUserExtendedPhoto_Internalname, ref  A4WWPUserExtendedPhoto, ref  A40000WWPUserExtendedPhoto_GXI);
            GXKey = Crypto.GetSiteKey( );
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A540WWPDiscussionMessageId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPDiscussionMessageId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1Y78( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes1Y78( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption1Y0( )
      {
      }

      protected void ZM1Y78( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z543WWPDiscussionMessageDate = T001Y3_A543WWPDiscussionMessageDate[0];
               Z544WWPDiscussionMessageMessage = T001Y3_A544WWPDiscussionMessageMessage[0];
               Z545WWPDiscussionMessageEntityReco = T001Y3_A545WWPDiscussionMessageEntityReco[0];
               Z1WWPUserExtendedId = T001Y3_A1WWPUserExtendedId[0];
               Z29WWPEntityId = T001Y3_A29WWPEntityId[0];
               Z539WWPDiscussionMessageThreadId = T001Y3_A539WWPDiscussionMessageThreadId[0];
            }
            else
            {
               Z543WWPDiscussionMessageDate = A543WWPDiscussionMessageDate;
               Z544WWPDiscussionMessageMessage = A544WWPDiscussionMessageMessage;
               Z545WWPDiscussionMessageEntityReco = A545WWPDiscussionMessageEntityReco;
               Z1WWPUserExtendedId = A1WWPUserExtendedId;
               Z29WWPEntityId = A29WWPEntityId;
               Z539WWPDiscussionMessageThreadId = A539WWPDiscussionMessageThreadId;
            }
         }
         if ( GX_JID == -5 )
         {
            Z540WWPDiscussionMessageId = A540WWPDiscussionMessageId;
            Z543WWPDiscussionMessageDate = A543WWPDiscussionMessageDate;
            Z544WWPDiscussionMessageMessage = A544WWPDiscussionMessageMessage;
            Z545WWPDiscussionMessageEntityReco = A545WWPDiscussionMessageEntityReco;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z29WWPEntityId = A29WWPEntityId;
            Z539WWPDiscussionMessageThreadId = A539WWPDiscussionMessageThreadId;
            Z4WWPUserExtendedPhoto = A4WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
            Z30WWPEntityName = A30WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_539_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.discussions.gx0260.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPDISCUSSIONMESSAGETHREADID"+"'), id:'"+"WWPDISCUSSIONMESSAGETHREADID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPUSEREXTENDEDID"+"'), id:'"+"WWPUSEREXTENDEDID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_29_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.gx0090.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPENTITYID"+"'), id:'"+"WWPENTITYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         A543WWPDiscussionMessageDate = DateTimeUtil.Now( context);
         AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GXt_char1 = A1WWPUserExtendedId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         A1WWPUserExtendedId = GXt_char1;
         AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T001Y4 */
            pr_default.execute(2, new Object[] {A1WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = T001Y4_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            A2WWPUserExtendedFullName = T001Y4_A2WWPUserExtendedFullName[0];
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
            A4WWPUserExtendedPhoto = T001Y4_A4WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            pr_default.close(2);
         }
      }

      protected void Load1Y78( )
      {
         /* Using cursor T001Y7 */
         pr_default.execute(5, new Object[] {A540WWPDiscussionMessageId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound78 = 1;
            A543WWPDiscussionMessageDate = T001Y7_A543WWPDiscussionMessageDate[0];
            AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A544WWPDiscussionMessageMessage = T001Y7_A544WWPDiscussionMessageMessage[0];
            AssignAttri("", false, "A544WWPDiscussionMessageMessage", A544WWPDiscussionMessageMessage);
            A40000WWPUserExtendedPhoto_GXI = T001Y7_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            A2WWPUserExtendedFullName = T001Y7_A2WWPUserExtendedFullName[0];
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
            A30WWPEntityName = T001Y7_A30WWPEntityName[0];
            AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
            A545WWPDiscussionMessageEntityReco = T001Y7_A545WWPDiscussionMessageEntityReco[0];
            AssignAttri("", false, "A545WWPDiscussionMessageEntityReco", A545WWPDiscussionMessageEntityReco);
            A1WWPUserExtendedId = T001Y7_A1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            A29WWPEntityId = T001Y7_A29WWPEntityId[0];
            AssignAttri("", false, "A29WWPEntityId", StringUtil.LTrimStr( (decimal)(A29WWPEntityId), 10, 0));
            A539WWPDiscussionMessageThreadId = T001Y7_A539WWPDiscussionMessageThreadId[0];
            n539WWPDiscussionMessageThreadId = T001Y7_n539WWPDiscussionMessageThreadId[0];
            AssignAttri("", false, "A539WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A539WWPDiscussionMessageThreadId), 10, 0));
            A4WWPUserExtendedPhoto = T001Y7_A4WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            ZM1Y78( -5) ;
         }
         pr_default.close(5);
         OnLoadActions1Y78( ) ;
      }

      protected void OnLoadActions1Y78( )
      {
      }

      protected void CheckExtendedTable1Y78( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A543WWPDiscussionMessageDate) || ( A543WWPDiscussionMessageDate >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Message Date", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPDISCUSSIONMESSAGEDATE");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T001Y6 */
         pr_default.execute(4, new Object[] {n539WWPDiscussionMessageThreadId, A539WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A539WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Thread", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         /* Using cursor T001Y4 */
         pr_default.execute(2, new Object[] {A1WWPUserExtendedId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40000WWPUserExtendedPhoto_GXI = T001Y4_A40000WWPUserExtendedPhoto_GXI[0];
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
         A2WWPUserExtendedFullName = T001Y4_A2WWPUserExtendedFullName[0];
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         A4WWPUserExtendedPhoto = T001Y4_A4WWPUserExtendedPhoto[0];
         AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
         pr_default.close(2);
         /* Using cursor T001Y5 */
         pr_default.execute(3, new Object[] {A29WWPEntityId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A30WWPEntityName = T001Y5_A30WWPEntityName[0];
         AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1Y78( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_8( long A539WWPDiscussionMessageThreadId )
      {
         /* Using cursor T001Y8 */
         pr_default.execute(6, new Object[] {n539WWPDiscussionMessageThreadId, A539WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A539WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Thread", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_6( string A1WWPUserExtendedId )
      {
         /* Using cursor T001Y9 */
         pr_default.execute(7, new Object[] {A1WWPUserExtendedId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40000WWPUserExtendedPhoto_GXI = T001Y9_A40000WWPUserExtendedPhoto_GXI[0];
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
         A2WWPUserExtendedFullName = T001Y9_A2WWPUserExtendedFullName[0];
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         A4WWPUserExtendedPhoto = T001Y9_A4WWPUserExtendedPhoto[0];
         AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A4WWPUserExtendedPhoto)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000WWPUserExtendedPhoto_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( A2WWPUserExtendedFullName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_7( long A29WWPEntityId )
      {
         /* Using cursor T001Y10 */
         pr_default.execute(8, new Object[] {A29WWPEntityId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A30WWPEntityName = T001Y10_A30WWPEntityName[0];
         AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A30WWPEntityName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey1Y78( )
      {
         /* Using cursor T001Y11 */
         pr_default.execute(9, new Object[] {A540WWPDiscussionMessageId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound78 = 1;
         }
         else
         {
            RcdFound78 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001Y3 */
         pr_default.execute(1, new Object[] {A540WWPDiscussionMessageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Y78( 5) ;
            RcdFound78 = 1;
            A540WWPDiscussionMessageId = T001Y3_A540WWPDiscussionMessageId[0];
            AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
            A543WWPDiscussionMessageDate = T001Y3_A543WWPDiscussionMessageDate[0];
            AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A544WWPDiscussionMessageMessage = T001Y3_A544WWPDiscussionMessageMessage[0];
            AssignAttri("", false, "A544WWPDiscussionMessageMessage", A544WWPDiscussionMessageMessage);
            A545WWPDiscussionMessageEntityReco = T001Y3_A545WWPDiscussionMessageEntityReco[0];
            AssignAttri("", false, "A545WWPDiscussionMessageEntityReco", A545WWPDiscussionMessageEntityReco);
            A1WWPUserExtendedId = T001Y3_A1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            A29WWPEntityId = T001Y3_A29WWPEntityId[0];
            AssignAttri("", false, "A29WWPEntityId", StringUtil.LTrimStr( (decimal)(A29WWPEntityId), 10, 0));
            A539WWPDiscussionMessageThreadId = T001Y3_A539WWPDiscussionMessageThreadId[0];
            n539WWPDiscussionMessageThreadId = T001Y3_n539WWPDiscussionMessageThreadId[0];
            AssignAttri("", false, "A539WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A539WWPDiscussionMessageThreadId), 10, 0));
            Z540WWPDiscussionMessageId = A540WWPDiscussionMessageId;
            sMode78 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1Y78( ) ;
            if ( AnyError == 1 )
            {
               RcdFound78 = 0;
               InitializeNonKey1Y78( ) ;
            }
            Gx_mode = sMode78;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound78 = 0;
            InitializeNonKey1Y78( ) ;
            sMode78 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode78;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Y78( ) ;
         if ( RcdFound78 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound78 = 0;
         /* Using cursor T001Y12 */
         pr_default.execute(10, new Object[] {A540WWPDiscussionMessageId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T001Y12_A540WWPDiscussionMessageId[0] < A540WWPDiscussionMessageId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T001Y12_A540WWPDiscussionMessageId[0] > A540WWPDiscussionMessageId ) ) )
            {
               A540WWPDiscussionMessageId = T001Y12_A540WWPDiscussionMessageId[0];
               AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
               RcdFound78 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound78 = 0;
         /* Using cursor T001Y13 */
         pr_default.execute(11, new Object[] {A540WWPDiscussionMessageId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T001Y13_A540WWPDiscussionMessageId[0] > A540WWPDiscussionMessageId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T001Y13_A540WWPDiscussionMessageId[0] < A540WWPDiscussionMessageId ) ) )
            {
               A540WWPDiscussionMessageId = T001Y13_A540WWPDiscussionMessageId[0];
               AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
               RcdFound78 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1Y78( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1Y78( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound78 == 1 )
            {
               if ( A540WWPDiscussionMessageId != Z540WWPDiscussionMessageId )
               {
                  A540WWPDiscussionMessageId = Z540WWPDiscussionMessageId;
                  AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1Y78( ) ;
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A540WWPDiscussionMessageId != Z540WWPDiscussionMessageId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1Y78( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPDISCUSSIONMESSAGEID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1Y78( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A540WWPDiscussionMessageId != Z540WWPDiscussionMessageId )
         {
            A540WWPDiscussionMessageId = Z540WWPDiscussionMessageId;
            AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1Y78( ) ;
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1Y78( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1Y78( ) ;
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound78 != 0 )
            {
               ScanNext1Y78( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1Y78( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1Y78( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001Y2 */
            pr_default.execute(0, new Object[] {A540WWPDiscussionMessageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z543WWPDiscussionMessageDate != T001Y2_A543WWPDiscussionMessageDate[0] ) || ( StringUtil.StrCmp(Z544WWPDiscussionMessageMessage, T001Y2_A544WWPDiscussionMessageMessage[0]) != 0 ) || ( StringUtil.StrCmp(Z545WWPDiscussionMessageEntityReco, T001Y2_A545WWPDiscussionMessageEntityReco[0]) != 0 ) || ( StringUtil.StrCmp(Z1WWPUserExtendedId, T001Y2_A1WWPUserExtendedId[0]) != 0 ) || ( Z29WWPEntityId != T001Y2_A29WWPEntityId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z539WWPDiscussionMessageThreadId != T001Y2_A539WWPDiscussionMessageThreadId[0] ) )
            {
               if ( Z543WWPDiscussionMessageDate != T001Y2_A543WWPDiscussionMessageDate[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageDate");
                  GXUtil.WriteLogRaw("Old: ",Z543WWPDiscussionMessageDate);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A543WWPDiscussionMessageDate[0]);
               }
               if ( StringUtil.StrCmp(Z544WWPDiscussionMessageMessage, T001Y2_A544WWPDiscussionMessageMessage[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageMessage");
                  GXUtil.WriteLogRaw("Old: ",Z544WWPDiscussionMessageMessage);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A544WWPDiscussionMessageMessage[0]);
               }
               if ( StringUtil.StrCmp(Z545WWPDiscussionMessageEntityReco, T001Y2_A545WWPDiscussionMessageEntityReco[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageEntityReco");
                  GXUtil.WriteLogRaw("Old: ",Z545WWPDiscussionMessageEntityReco);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A545WWPDiscussionMessageEntityReco[0]);
               }
               if ( StringUtil.StrCmp(Z1WWPUserExtendedId, T001Y2_A1WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z1WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A1WWPUserExtendedId[0]);
               }
               if ( Z29WWPEntityId != T001Y2_A29WWPEntityId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPEntityId");
                  GXUtil.WriteLogRaw("Old: ",Z29WWPEntityId);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A29WWPEntityId[0]);
               }
               if ( Z539WWPDiscussionMessageThreadId != T001Y2_A539WWPDiscussionMessageThreadId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageThreadId");
                  GXUtil.WriteLogRaw("Old: ",Z539WWPDiscussionMessageThreadId);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A539WWPDiscussionMessageThreadId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_DiscussionMessage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Y78( )
      {
         BeforeValidate1Y78( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Y78( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Y78( 0) ;
            CheckOptimisticConcurrency1Y78( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Y78( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Y78( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Y14 */
                     pr_default.execute(12, new Object[] {A543WWPDiscussionMessageDate, A544WWPDiscussionMessageMessage, A545WWPDiscussionMessageEntityReco, A1WWPUserExtendedId, A29WWPEntityId, n539WWPDiscussionMessageThreadId, A539WWPDiscussionMessageThreadId});
                     A540WWPDiscussionMessageId = T001Y14_A540WWPDiscussionMessageId[0];
                     AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1Y0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1Y78( ) ;
            }
            EndLevel1Y78( ) ;
         }
         CloseExtendedTableCursors1Y78( ) ;
      }

      protected void Update1Y78( )
      {
         BeforeValidate1Y78( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Y78( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Y78( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Y78( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Y78( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Y15 */
                     pr_default.execute(13, new Object[] {A543WWPDiscussionMessageDate, A544WWPDiscussionMessageMessage, A545WWPDiscussionMessageEntityReco, A1WWPUserExtendedId, A29WWPEntityId, n539WWPDiscussionMessageThreadId, A539WWPDiscussionMessageThreadId, A540WWPDiscussionMessageId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Y78( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1Y0( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1Y78( ) ;
         }
         CloseExtendedTableCursors1Y78( ) ;
      }

      protected void DeferredUpdate1Y78( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1Y78( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Y78( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Y78( ) ;
            AfterConfirm1Y78( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Y78( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001Y16 */
                  pr_default.execute(14, new Object[] {A540WWPDiscussionMessageId});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound78 == 0 )
                        {
                           InitAll1Y78( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption1Y0( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode78 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1Y78( ) ;
         Gx_mode = sMode78;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1Y78( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001Y17 */
            pr_default.execute(15, new Object[] {A1WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = T001Y17_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            A2WWPUserExtendedFullName = T001Y17_A2WWPUserExtendedFullName[0];
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
            A4WWPUserExtendedPhoto = T001Y17_A4WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            pr_default.close(15);
            /* Using cursor T001Y18 */
            pr_default.execute(16, new Object[] {A29WWPEntityId});
            A30WWPEntityName = T001Y18_A30WWPEntityName[0];
            AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001Y19 */
            pr_default.execute(17, new Object[] {A540WWPDiscussionMessageId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_DiscussionMessage", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T001Y20 */
            pr_default.execute(18, new Object[] {A540WWPDiscussionMessageId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_DiscussionMessageMention", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel1Y78( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Y78( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.CommitDataStores("wwpbaseobjects.discussions.wwp_discussionmessage",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1Y0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.RollbackDataStores("wwpbaseobjects.discussions.wwp_discussionmessage",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1Y78( )
      {
         /* Using cursor T001Y21 */
         pr_default.execute(19);
         RcdFound78 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound78 = 1;
            A540WWPDiscussionMessageId = T001Y21_A540WWPDiscussionMessageId[0];
            AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1Y78( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound78 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound78 = 1;
            A540WWPDiscussionMessageId = T001Y21_A540WWPDiscussionMessageId[0];
            AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
         }
      }

      protected void ScanEnd1Y78( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm1Y78( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Y78( )
      {
         /* Before Insert Rules */
         if ( (0==A539WWPDiscussionMessageThreadId) )
         {
            A539WWPDiscussionMessageThreadId = 0;
            n539WWPDiscussionMessageThreadId = false;
            AssignAttri("", false, "A539WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A539WWPDiscussionMessageThreadId), 10, 0));
            n539WWPDiscussionMessageThreadId = true;
            AssignAttri("", false, "A539WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A539WWPDiscussionMessageThreadId), 10, 0));
         }
      }

      protected void BeforeUpdate1Y78( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Y78( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Y78( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Y78( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Y78( )
      {
         edtWWPDiscussionMessageId_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageId_Enabled), 5, 0), true);
         edtWWPDiscussionMessageDate_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageDate_Enabled), 5, 0), true);
         edtWWPDiscussionMessageThreadId_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageThreadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageThreadId_Enabled), 5, 0), true);
         edtWWPDiscussionMessageMessage_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageMessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageMessage_Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         imgWWPUserExtendedPhoto_Enabled = 0;
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgWWPUserExtendedPhoto_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPEntityId_Enabled = 0;
         AssignProp("", false, edtWWPEntityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityId_Enabled), 5, 0), true);
         edtWWPEntityName_Enabled = 0;
         AssignProp("", false, edtWWPEntityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityName_Enabled), 5, 0), true);
         edtWWPDiscussionMessageEntityReco_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageEntityReco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageEntityReco_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1Y78( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1Y0( )
      {
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
         MasterPageObj.master_styles();
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.discussions.wwp_discussionmessage.aspx") +"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z540WWPDiscussionMessageId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z540WWPDiscussionMessageId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z543WWPDiscussionMessageDate", context.localUtil.TToC( Z543WWPDiscussionMessageDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z544WWPDiscussionMessageMessage", Z544WWPDiscussionMessageMessage);
         GxWebStd.gx_hidden_field( context, "Z545WWPDiscussionMessageEntityReco", Z545WWPDiscussionMessageEntityReco);
         GxWebStd.gx_hidden_field( context, "Z1WWPUserExtendedId", StringUtil.RTrim( Z1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z29WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29WWPEntityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z539WWPDiscussionMessageThreadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z539WWPDiscussionMessageThreadId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDPHOTO_GXI", A40000WWPUserExtendedPhoto_GXI);
         GXCCtlgxBlob = "WWPUSEREXTENDEDPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A4WWPUserExtendedPhoto);
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("wwpbaseobjects.discussions.wwp_discussionmessage.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Discussions.WWP_DiscussionMessage" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Discussion Message", "") ;
      }

      protected void InitializeNonKey1Y78( )
      {
         A543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A1WWPUserExtendedId = "";
         AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
         A539WWPDiscussionMessageThreadId = 0;
         n539WWPDiscussionMessageThreadId = false;
         AssignAttri("", false, "A539WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A539WWPDiscussionMessageThreadId), 10, 0));
         n539WWPDiscussionMessageThreadId = ((0==A539WWPDiscussionMessageThreadId) ? true : false);
         A544WWPDiscussionMessageMessage = "";
         AssignAttri("", false, "A544WWPDiscussionMessageMessage", A544WWPDiscussionMessageMessage);
         A4WWPUserExtendedPhoto = "";
         AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
         A40000WWPUserExtendedPhoto_GXI = "";
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
         A2WWPUserExtendedFullName = "";
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         A29WWPEntityId = 0;
         AssignAttri("", false, "A29WWPEntityId", StringUtil.LTrimStr( (decimal)(A29WWPEntityId), 10, 0));
         A30WWPEntityName = "";
         AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
         A545WWPDiscussionMessageEntityReco = "";
         AssignAttri("", false, "A545WWPDiscussionMessageEntityReco", A545WWPDiscussionMessageEntityReco);
         Z543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z544WWPDiscussionMessageMessage = "";
         Z545WWPDiscussionMessageEntityReco = "";
         Z1WWPUserExtendedId = "";
         Z29WWPEntityId = 0;
         Z539WWPDiscussionMessageThreadId = 0;
      }

      protected void InitAll1Y78( )
      {
         A540WWPDiscussionMessageId = 0;
         AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
         InitializeNonKey1Y78( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A543WWPDiscussionMessageDate = i543WWPDiscussionMessageDate;
         AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A1WWPUserExtendedId = i1WWPUserExtendedId;
         AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
      }

      protected void define_styles( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021145365", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/discussions/wwp_discussionmessage.js", "?202673021145366", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtWWPDiscussionMessageId_Internalname = "WWPDISCUSSIONMESSAGEID";
         edtWWPDiscussionMessageDate_Internalname = "WWPDISCUSSIONMESSAGEDATE";
         edtWWPDiscussionMessageThreadId_Internalname = "WWPDISCUSSIONMESSAGETHREADID";
         edtWWPDiscussionMessageMessage_Internalname = "WWPDISCUSSIONMESSAGEMESSAGE";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         imgWWPUserExtendedPhoto_Internalname = "WWPUSEREXTENDEDPHOTO";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPEntityId_Internalname = "WWPENTITYID";
         edtWWPEntityName_Internalname = "WWPENTITYNAME";
         edtWWPDiscussionMessageEntityReco_Internalname = "WWPDISCUSSIONMESSAGEENTITYRECO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_539_Internalname = "PROMPT_539";
         imgprompt_1_Internalname = "PROMPT_1";
         imgprompt_29_Internalname = "PROMPT_29";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Discussion Message", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPDiscussionMessageEntityReco_Jsonclick = "";
         edtWWPDiscussionMessageEntityReco_Enabled = 1;
         edtWWPEntityName_Jsonclick = "";
         edtWWPEntityName_Enabled = 0;
         imgprompt_29_Visible = 1;
         imgprompt_29_Link = "";
         edtWWPEntityId_Jsonclick = "";
         edtWWPEntityId_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 0;
         imgWWPUserExtendedPhoto_Enabled = 0;
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         edtWWPDiscussionMessageMessage_Enabled = 1;
         imgprompt_539_Visible = 1;
         imgprompt_539_Link = "";
         edtWWPDiscussionMessageThreadId_Jsonclick = "";
         edtWWPDiscussionMessageThreadId_Enabled = 1;
         edtWWPDiscussionMessageDate_Jsonclick = "";
         edtWWPDiscussionMessageDate_Enabled = 1;
         edtWWPDiscussionMessageId_Jsonclick = "";
         edtWWPDiscussionMessageId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GX3ASAWWPUSEREXTENDEDID1Y78( string Gx_mode )
      {
         GXt_char1 = A1WWPUserExtendedId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         A1WWPUserExtendedId = GXt_char1;
         AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1WWPUserExtendedId))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Wwpdiscussionmessageid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A1WWPUserExtendedId", StringUtil.RTrim( A1WWPUserExtendedId));
         AssignAttri("", false, "A539WWPDiscussionMessageThreadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A539WWPDiscussionMessageThreadId), 10, 0, ".", "")));
         AssignAttri("", false, "A544WWPDiscussionMessageMessage", A544WWPDiscussionMessageMessage);
         AssignAttri("", false, "A29WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A545WWPDiscussionMessageEntityReco", A545WWPDiscussionMessageEntityReco);
         AssignAttri("", false, "A4WWPUserExtendedPhoto", context.PathToRelativeUrl( A4WWPUserExtendedPhoto));
         GXCCtlgxBlob = "WWPUSEREXTENDEDPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A4WWPUserExtendedPhoto));
         AssignAttri("", false, "A40000WWPUserExtendedPhoto_GXI", A40000WWPUserExtendedPhoto_GXI);
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z540WWPDiscussionMessageId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z540WWPDiscussionMessageId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z543WWPDiscussionMessageDate", context.localUtil.TToC( Z543WWPDiscussionMessageDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1WWPUserExtendedId", StringUtil.RTrim( Z1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z539WWPDiscussionMessageThreadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z539WWPDiscussionMessageThreadId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z544WWPDiscussionMessageMessage", Z544WWPDiscussionMessageMessage);
         GxWebStd.gx_hidden_field( context, "Z29WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29WWPEntityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z545WWPDiscussionMessageEntityReco", Z545WWPDiscussionMessageEntityReco);
         GxWebStd.gx_hidden_field( context, "Z4WWPUserExtendedPhoto", context.PathToRelativeUrl( Z4WWPUserExtendedPhoto));
         GxWebStd.gx_hidden_field( context, "Z40000WWPUserExtendedPhoto_GXI", Z40000WWPUserExtendedPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z2WWPUserExtendedFullName", Z2WWPUserExtendedFullName);
         GxWebStd.gx_hidden_field( context, "Z30WWPEntityName", Z30WWPEntityName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpdiscussionmessagethreadid( )
      {
         n539WWPDiscussionMessageThreadId = false;
         /* Using cursor T001Y22 */
         pr_default.execute(20, new Object[] {n539WWPDiscussionMessageThreadId, A539WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A539WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Thread", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
            }
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Wwpuserextendedid( )
      {
         /* Using cursor T001Y17 */
         pr_default.execute(15, new Object[] {A1WWPUserExtendedId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
         }
         A40000WWPUserExtendedPhoto_GXI = T001Y17_A40000WWPUserExtendedPhoto_GXI[0];
         A2WWPUserExtendedFullName = T001Y17_A2WWPUserExtendedFullName[0];
         A4WWPUserExtendedPhoto = T001Y17_A4WWPUserExtendedPhoto[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A4WWPUserExtendedPhoto", context.PathToRelativeUrl( A4WWPUserExtendedPhoto));
         GXCCtlgxBlob = "WWPUSEREXTENDEDPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A4WWPUserExtendedPhoto));
         AssignAttri("", false, "A40000WWPUserExtendedPhoto_GXI", A40000WWPUserExtendedPhoto_GXI);
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
      }

      public void Valid_Wwpentityid( )
      {
         /* Using cursor T001Y18 */
         pr_default.execute(16, new Object[] {A29WWPEntityId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
         }
         A30WWPEntityName = T001Y18_A30WWPEntityName[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEID","{handler:'Valid_Wwpdiscussionmessageid',iparms:[{av:'A540WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'A543WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99',type:'dtime'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:'',type:'char'}]");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEID",",oparms:[{av:'A543WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99',type:'dtime'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:'',type:'char'},{av:'A539WWPDiscussionMessageThreadId',fld:'WWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A544WWPDiscussionMessageMessage',fld:'WWPDISCUSSIONMESSAGEMESSAGE',pic:'',type:'svchar'},{av:'A29WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A545WWPDiscussionMessageEntityReco',fld:'WWPDISCUSSIONMESSAGEENTITYRECO',pic:'',type:'svchar'},{av:'A4WWPUserExtendedPhoto',fld:'WWPUSEREXTENDEDPHOTO',pic:'',type:'bits'},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:'',type:'svchar'},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:'',type:'svchar'},{av:'A30WWPEntityName',fld:'WWPENTITYNAME',pic:'',type:'svchar'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z540WWPDiscussionMessageId',type:'int'},{av:'Z543WWPDiscussionMessageDate',type:'dtime'},{av:'Z1WWPUserExtendedId',type:'char'},{av:'Z539WWPDiscussionMessageThreadId',type:'int'},{av:'Z544WWPDiscussionMessageMessage',type:'svchar'},{av:'Z29WWPEntityId',type:'int'},{av:'Z545WWPDiscussionMessageEntityReco',type:'svchar'},{av:'Z4WWPUserExtendedPhoto',type:'bits'},{av:'Z40000WWPUserExtendedPhoto_GXI',type:'svchar'},{av:'Z2WWPUserExtendedFullName',type:'svchar'},{av:'Z30WWPEntityName',type:'svchar'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEDATE","{handler:'Valid_Wwpdiscussionmessagedate',iparms:[]");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEDATE",",oparms:[]}");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGETHREADID","{handler:'Valid_Wwpdiscussionmessagethreadid',iparms:[{av:'A539WWPDiscussionMessageThreadId',fld:'WWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGETHREADID",",oparms:[]}");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","{handler:'Valid_Wwpuserextendedid',iparms:[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:'',type:'char'},{av:'A4WWPUserExtendedPhoto',fld:'WWPUSEREXTENDEDPHOTO',pic:'',type:'bits'},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:'',type:'svchar'},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:'',type:'svchar'}]");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",",oparms:[{av:'A4WWPUserExtendedPhoto',fld:'WWPUSEREXTENDEDPHOTO',pic:'',type:'bits'},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:'',type:'svchar'},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:'',type:'svchar'}]}");
         setEventMetadata("VALID_WWPENTITYID","{handler:'Valid_Wwpentityid',iparms:[{av:'A29WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A30WWPEntityName',fld:'WWPENTITYNAME',pic:'',type:'svchar'}]");
         setEventMetadata("VALID_WWPENTITYID",",oparms:[{av:'A30WWPEntityName',fld:'WWPENTITYNAME',pic:'',type:'svchar'}]}");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z544WWPDiscussionMessageMessage = "";
         Z545WWPDiscussionMessageEntityReco = "";
         Z1WWPUserExtendedId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         Gx_mode = "";
         A1WWPUserExtendedId = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         imgprompt_539_gximage = "";
         sImgUrl = "";
         A544WWPDiscussionMessageMessage = "";
         imgprompt_1_gximage = "";
         A4WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         A2WWPUserExtendedFullName = "";
         imgprompt_29_gximage = "";
         A30WWPEntityName = "";
         A545WWPDiscussionMessageEntityReco = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z4WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         Z2WWPUserExtendedFullName = "";
         Z30WWPEntityName = "";
         T001Y4_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T001Y4_A2WWPUserExtendedFullName = new string[] {""} ;
         T001Y4_A4WWPUserExtendedPhoto = new string[] {""} ;
         T001Y7_A540WWPDiscussionMessageId = new long[1] ;
         T001Y7_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T001Y7_A544WWPDiscussionMessageMessage = new string[] {""} ;
         T001Y7_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T001Y7_A2WWPUserExtendedFullName = new string[] {""} ;
         T001Y7_A30WWPEntityName = new string[] {""} ;
         T001Y7_A545WWPDiscussionMessageEntityReco = new string[] {""} ;
         T001Y7_A1WWPUserExtendedId = new string[] {""} ;
         T001Y7_A29WWPEntityId = new long[1] ;
         T001Y7_A539WWPDiscussionMessageThreadId = new long[1] ;
         T001Y7_n539WWPDiscussionMessageThreadId = new bool[] {false} ;
         T001Y7_A4WWPUserExtendedPhoto = new string[] {""} ;
         T001Y6_A539WWPDiscussionMessageThreadId = new long[1] ;
         T001Y6_n539WWPDiscussionMessageThreadId = new bool[] {false} ;
         T001Y5_A30WWPEntityName = new string[] {""} ;
         T001Y8_A539WWPDiscussionMessageThreadId = new long[1] ;
         T001Y8_n539WWPDiscussionMessageThreadId = new bool[] {false} ;
         T001Y9_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T001Y9_A2WWPUserExtendedFullName = new string[] {""} ;
         T001Y9_A4WWPUserExtendedPhoto = new string[] {""} ;
         T001Y10_A30WWPEntityName = new string[] {""} ;
         T001Y11_A540WWPDiscussionMessageId = new long[1] ;
         T001Y3_A540WWPDiscussionMessageId = new long[1] ;
         T001Y3_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T001Y3_A544WWPDiscussionMessageMessage = new string[] {""} ;
         T001Y3_A545WWPDiscussionMessageEntityReco = new string[] {""} ;
         T001Y3_A1WWPUserExtendedId = new string[] {""} ;
         T001Y3_A29WWPEntityId = new long[1] ;
         T001Y3_A539WWPDiscussionMessageThreadId = new long[1] ;
         T001Y3_n539WWPDiscussionMessageThreadId = new bool[] {false} ;
         sMode78 = "";
         T001Y12_A540WWPDiscussionMessageId = new long[1] ;
         T001Y13_A540WWPDiscussionMessageId = new long[1] ;
         T001Y2_A540WWPDiscussionMessageId = new long[1] ;
         T001Y2_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T001Y2_A544WWPDiscussionMessageMessage = new string[] {""} ;
         T001Y2_A545WWPDiscussionMessageEntityReco = new string[] {""} ;
         T001Y2_A1WWPUserExtendedId = new string[] {""} ;
         T001Y2_A29WWPEntityId = new long[1] ;
         T001Y2_A539WWPDiscussionMessageThreadId = new long[1] ;
         T001Y2_n539WWPDiscussionMessageThreadId = new bool[] {false} ;
         T001Y14_A540WWPDiscussionMessageId = new long[1] ;
         T001Y17_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T001Y17_A2WWPUserExtendedFullName = new string[] {""} ;
         T001Y17_A4WWPUserExtendedPhoto = new string[] {""} ;
         T001Y18_A30WWPEntityName = new string[] {""} ;
         T001Y19_A539WWPDiscussionMessageThreadId = new long[1] ;
         T001Y19_n539WWPDiscussionMessageThreadId = new bool[] {false} ;
         T001Y20_A540WWPDiscussionMessageId = new long[1] ;
         T001Y20_A541WWPDiscussionMentionUserId = new string[] {""} ;
         T001Y21_A540WWPDiscussionMessageId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         i543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         i1WWPUserExtendedId = "";
         GXt_char1 = "";
         ZZ543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         ZZ1WWPUserExtendedId = "";
         ZZ544WWPDiscussionMessageMessage = "";
         ZZ545WWPDiscussionMessageEntityReco = "";
         ZZ4WWPUserExtendedPhoto = "";
         ZZ40000WWPUserExtendedPhoto_GXI = "";
         ZZ2WWPUserExtendedFullName = "";
         ZZ30WWPEntityName = "";
         T001Y22_A539WWPDiscussionMessageThreadId = new long[1] ;
         T001Y22_n539WWPDiscussionMessageThreadId = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage__default(),
            new Object[][] {
                new Object[] {
               T001Y2_A540WWPDiscussionMessageId, T001Y2_A543WWPDiscussionMessageDate, T001Y2_A544WWPDiscussionMessageMessage, T001Y2_A545WWPDiscussionMessageEntityReco, T001Y2_A1WWPUserExtendedId, T001Y2_A29WWPEntityId, T001Y2_A539WWPDiscussionMessageThreadId, T001Y2_n539WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T001Y3_A540WWPDiscussionMessageId, T001Y3_A543WWPDiscussionMessageDate, T001Y3_A544WWPDiscussionMessageMessage, T001Y3_A545WWPDiscussionMessageEntityReco, T001Y3_A1WWPUserExtendedId, T001Y3_A29WWPEntityId, T001Y3_A539WWPDiscussionMessageThreadId, T001Y3_n539WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T001Y4_A40000WWPUserExtendedPhoto_GXI, T001Y4_A2WWPUserExtendedFullName, T001Y4_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               T001Y5_A30WWPEntityName
               }
               , new Object[] {
               T001Y6_A539WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T001Y7_A540WWPDiscussionMessageId, T001Y7_A543WWPDiscussionMessageDate, T001Y7_A544WWPDiscussionMessageMessage, T001Y7_A40000WWPUserExtendedPhoto_GXI, T001Y7_A2WWPUserExtendedFullName, T001Y7_A30WWPEntityName, T001Y7_A545WWPDiscussionMessageEntityReco, T001Y7_A1WWPUserExtendedId, T001Y7_A29WWPEntityId, T001Y7_A539WWPDiscussionMessageThreadId,
               T001Y7_n539WWPDiscussionMessageThreadId, T001Y7_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               T001Y8_A539WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T001Y9_A40000WWPUserExtendedPhoto_GXI, T001Y9_A2WWPUserExtendedFullName, T001Y9_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               T001Y10_A30WWPEntityName
               }
               , new Object[] {
               T001Y11_A540WWPDiscussionMessageId
               }
               , new Object[] {
               T001Y12_A540WWPDiscussionMessageId
               }
               , new Object[] {
               T001Y13_A540WWPDiscussionMessageId
               }
               , new Object[] {
               T001Y14_A540WWPDiscussionMessageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001Y17_A40000WWPUserExtendedPhoto_GXI, T001Y17_A2WWPUserExtendedFullName, T001Y17_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               T001Y18_A30WWPEntityName
               }
               , new Object[] {
               T001Y19_A539WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T001Y20_A540WWPDiscussionMessageId, T001Y20_A541WWPDiscussionMentionUserId
               }
               , new Object[] {
               T001Y21_A540WWPDiscussionMessageId
               }
               , new Object[] {
               T001Y22_A539WWPDiscussionMessageThreadId
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound78 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPDiscussionMessageId_Enabled ;
      private int edtWWPDiscussionMessageDate_Enabled ;
      private int edtWWPDiscussionMessageThreadId_Enabled ;
      private int imgprompt_539_Visible ;
      private int edtWWPDiscussionMessageMessage_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int imgprompt_1_Visible ;
      private int imgWWPUserExtendedPhoto_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPEntityId_Enabled ;
      private int imgprompt_29_Visible ;
      private int edtWWPEntityName_Enabled ;
      private int edtWWPDiscussionMessageEntityReco_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z540WWPDiscussionMessageId ;
      private long Z29WWPEntityId ;
      private long Z539WWPDiscussionMessageThreadId ;
      private long A539WWPDiscussionMessageThreadId ;
      private long A29WWPEntityId ;
      private long A540WWPDiscussionMessageId ;
      private long ZZ540WWPDiscussionMessageId ;
      private long ZZ539WWPDiscussionMessageThreadId ;
      private long ZZ29WWPEntityId ;
      private string sPrefix ;
      private string Z1WWPUserExtendedId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string A1WWPUserExtendedId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPDiscussionMessageId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtWWPDiscussionMessageId_Jsonclick ;
      private string edtWWPDiscussionMessageDate_Internalname ;
      private string edtWWPDiscussionMessageDate_Jsonclick ;
      private string edtWWPDiscussionMessageThreadId_Internalname ;
      private string edtWWPDiscussionMessageThreadId_Jsonclick ;
      private string imgprompt_539_gximage ;
      private string sImgUrl ;
      private string imgprompt_539_Internalname ;
      private string imgprompt_539_Link ;
      private string edtWWPDiscussionMessageMessage_Internalname ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string imgprompt_1_gximage ;
      private string imgprompt_1_Internalname ;
      private string imgprompt_1_Link ;
      private string imgWWPUserExtendedPhoto_Internalname ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPEntityId_Internalname ;
      private string edtWWPEntityId_Jsonclick ;
      private string imgprompt_29_gximage ;
      private string imgprompt_29_Internalname ;
      private string imgprompt_29_Link ;
      private string edtWWPEntityName_Internalname ;
      private string edtWWPEntityName_Jsonclick ;
      private string edtWWPDiscussionMessageEntityReco_Internalname ;
      private string edtWWPDiscussionMessageEntityReco_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode78 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string i1WWPUserExtendedId ;
      private string GXt_char1 ;
      private string ZZ1WWPUserExtendedId ;
      private DateTime Z543WWPDiscussionMessageDate ;
      private DateTime A543WWPDiscussionMessageDate ;
      private DateTime i543WWPDiscussionMessageDate ;
      private DateTime ZZ543WWPDiscussionMessageDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n539WWPDiscussionMessageThreadId ;
      private bool wbErr ;
      private bool A4WWPUserExtendedPhoto_IsBlob ;
      private bool Gx_longc ;
      private string Z544WWPDiscussionMessageMessage ;
      private string Z545WWPDiscussionMessageEntityReco ;
      private string A544WWPDiscussionMessageMessage ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string A2WWPUserExtendedFullName ;
      private string A30WWPEntityName ;
      private string A545WWPDiscussionMessageEntityReco ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string Z2WWPUserExtendedFullName ;
      private string Z30WWPEntityName ;
      private string ZZ544WWPDiscussionMessageMessage ;
      private string ZZ545WWPDiscussionMessageEntityReco ;
      private string ZZ40000WWPUserExtendedPhoto_GXI ;
      private string ZZ2WWPUserExtendedFullName ;
      private string ZZ30WWPEntityName ;
      private string A4WWPUserExtendedPhoto ;
      private string Z4WWPUserExtendedPhoto ;
      private string ZZ4WWPUserExtendedPhoto ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T001Y4_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T001Y4_A2WWPUserExtendedFullName ;
      private string[] T001Y4_A4WWPUserExtendedPhoto ;
      private long[] T001Y7_A540WWPDiscussionMessageId ;
      private DateTime[] T001Y7_A543WWPDiscussionMessageDate ;
      private string[] T001Y7_A544WWPDiscussionMessageMessage ;
      private string[] T001Y7_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T001Y7_A2WWPUserExtendedFullName ;
      private string[] T001Y7_A30WWPEntityName ;
      private string[] T001Y7_A545WWPDiscussionMessageEntityReco ;
      private string[] T001Y7_A1WWPUserExtendedId ;
      private long[] T001Y7_A29WWPEntityId ;
      private long[] T001Y7_A539WWPDiscussionMessageThreadId ;
      private bool[] T001Y7_n539WWPDiscussionMessageThreadId ;
      private string[] T001Y7_A4WWPUserExtendedPhoto ;
      private long[] T001Y6_A539WWPDiscussionMessageThreadId ;
      private bool[] T001Y6_n539WWPDiscussionMessageThreadId ;
      private string[] T001Y5_A30WWPEntityName ;
      private long[] T001Y8_A539WWPDiscussionMessageThreadId ;
      private bool[] T001Y8_n539WWPDiscussionMessageThreadId ;
      private string[] T001Y9_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T001Y9_A2WWPUserExtendedFullName ;
      private string[] T001Y9_A4WWPUserExtendedPhoto ;
      private string[] T001Y10_A30WWPEntityName ;
      private long[] T001Y11_A540WWPDiscussionMessageId ;
      private long[] T001Y3_A540WWPDiscussionMessageId ;
      private DateTime[] T001Y3_A543WWPDiscussionMessageDate ;
      private string[] T001Y3_A544WWPDiscussionMessageMessage ;
      private string[] T001Y3_A545WWPDiscussionMessageEntityReco ;
      private string[] T001Y3_A1WWPUserExtendedId ;
      private long[] T001Y3_A29WWPEntityId ;
      private long[] T001Y3_A539WWPDiscussionMessageThreadId ;
      private bool[] T001Y3_n539WWPDiscussionMessageThreadId ;
      private long[] T001Y12_A540WWPDiscussionMessageId ;
      private long[] T001Y13_A540WWPDiscussionMessageId ;
      private long[] T001Y2_A540WWPDiscussionMessageId ;
      private DateTime[] T001Y2_A543WWPDiscussionMessageDate ;
      private string[] T001Y2_A544WWPDiscussionMessageMessage ;
      private string[] T001Y2_A545WWPDiscussionMessageEntityReco ;
      private string[] T001Y2_A1WWPUserExtendedId ;
      private long[] T001Y2_A29WWPEntityId ;
      private long[] T001Y2_A539WWPDiscussionMessageThreadId ;
      private bool[] T001Y2_n539WWPDiscussionMessageThreadId ;
      private long[] T001Y14_A540WWPDiscussionMessageId ;
      private string[] T001Y17_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T001Y17_A2WWPUserExtendedFullName ;
      private string[] T001Y17_A4WWPUserExtendedPhoto ;
      private string[] T001Y18_A30WWPEntityName ;
      private long[] T001Y19_A539WWPDiscussionMessageThreadId ;
      private bool[] T001Y19_n539WWPDiscussionMessageThreadId ;
      private long[] T001Y20_A540WWPDiscussionMessageId ;
      private string[] T001Y20_A541WWPDiscussionMentionUserId ;
      private long[] T001Y21_A540WWPDiscussionMessageId ;
      private long[] T001Y22_A539WWPDiscussionMessageThreadId ;
      private bool[] T001Y22_n539WWPDiscussionMessageThreadId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_discussionmessage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_discussionmessage__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001Y2;
        prmT001Y2 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmT001Y3;
        prmT001Y3 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmT001Y4;
        prmT001Y4 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0)
        };
        Object[] prmT001Y5;
        prmT001Y5 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmT001Y6;
        prmT001Y6 = new Object[] {
        new ParDef("@WWPDiscussionMessageThreadId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT001Y7;
        prmT001Y7 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmT001Y8;
        prmT001Y8 = new Object[] {
        new ParDef("@WWPDiscussionMessageThreadId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT001Y9;
        prmT001Y9 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0)
        };
        Object[] prmT001Y10;
        prmT001Y10 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmT001Y11;
        prmT001Y11 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmT001Y12;
        prmT001Y12 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmT001Y13;
        prmT001Y13 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmT001Y14;
        prmT001Y14 = new Object[] {
        new ParDef("@WWPDiscussionMessageDate",GXType.DateTime,8,5) ,
        new ParDef("@WWPDiscussionMessageMessage",GXType.NVarChar,400,0) ,
        new ParDef("@WWPDiscussionMessageEntityReco",GXType.NVarChar,100,0) ,
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0) ,
        new ParDef("@WWPEntityId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMessageThreadId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT001Y15;
        prmT001Y15 = new Object[] {
        new ParDef("@WWPDiscussionMessageDate",GXType.DateTime,8,5) ,
        new ParDef("@WWPDiscussionMessageMessage",GXType.NVarChar,400,0) ,
        new ParDef("@WWPDiscussionMessageEntityReco",GXType.NVarChar,100,0) ,
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0) ,
        new ParDef("@WWPEntityId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMessageThreadId",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmT001Y16;
        prmT001Y16 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmT001Y17;
        prmT001Y17 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0)
        };
        Object[] prmT001Y18;
        prmT001Y18 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmT001Y19;
        prmT001Y19 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmT001Y20;
        prmT001Y20 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmT001Y21;
        prmT001Y21 = new Object[] {
        };
        Object[] prmT001Y22;
        prmT001Y22 = new Object[] {
        new ParDef("@WWPDiscussionMessageThreadId",GXType.Decimal,10,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T001Y2", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMessageDate], [WWPDiscussionMessageMessage], [WWPDiscussionMessageEntityReco], [WWPUserExtendedId], [WWPEntityId], [WWPDiscussionMessageThreadId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WITH (UPDLOCK) WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y3", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMessageDate], [WWPDiscussionMessageMessage], [WWPDiscussionMessageEntityReco], [WWPUserExtendedId], [WWPEntityId], [WWPDiscussionMessageThreadId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y4", "SELECT [WWPUserExtendedPhoto_GXI], [WWPUserExtendedFullName], [WWPUserExtendedPhoto] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y5", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y6", "SELECT [WWPDiscussionMessageId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y7", "SELECT TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMessageDate], TM1.[WWPDiscussionMessageMessage], T2.[WWPUserExtendedPhoto_GXI], T2.[WWPUserExtendedFullName], T3.[WWPEntityName], TM1.[WWPDiscussionMessageEntityReco], TM1.[WWPUserExtendedId], TM1.[WWPEntityId], TM1.[WWPDiscussionMessageThreadId] AS WWPDiscussionMessageThreadId, T2.[WWPUserExtendedPhoto] FROM (([WWP_DiscussionMessage] TM1 INNER JOIN [WWP_UserExtended] T2 ON T2.[WWPUserExtendedId] = TM1.[WWPUserExtendedId]) INNER JOIN [WWP_Entity] T3 ON T3.[WWPEntityId] = TM1.[WWPEntityId]) WHERE TM1.[WWPDiscussionMessageId] = @WWPDiscussionMessageId ORDER BY TM1.[WWPDiscussionMessageId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y8", "SELECT [WWPDiscussionMessageId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y9", "SELECT [WWPUserExtendedPhoto_GXI], [WWPUserExtendedFullName], [WWPUserExtendedPhoto] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y10", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y11", "SELECT [WWPDiscussionMessageId] FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y12", "SELECT TOP 1 [WWPDiscussionMessageId] FROM [WWP_DiscussionMessage] WHERE ( [WWPDiscussionMessageId] > @WWPDiscussionMessageId) ORDER BY [WWPDiscussionMessageId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001Y13", "SELECT TOP 1 [WWPDiscussionMessageId] FROM [WWP_DiscussionMessage] WHERE ( [WWPDiscussionMessageId] < @WWPDiscussionMessageId) ORDER BY [WWPDiscussionMessageId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001Y14", "INSERT INTO [WWP_DiscussionMessage]([WWPDiscussionMessageDate], [WWPDiscussionMessageMessage], [WWPDiscussionMessageEntityReco], [WWPUserExtendedId], [WWPEntityId], [WWPDiscussionMessageThreadId]) VALUES(@WWPDiscussionMessageDate, @WWPDiscussionMessageMessage, @WWPDiscussionMessageEntityReco, @WWPUserExtendedId, @WWPEntityId, @WWPDiscussionMessageThreadId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001Y15", "UPDATE [WWP_DiscussionMessage] SET [WWPDiscussionMessageDate]=@WWPDiscussionMessageDate, [WWPDiscussionMessageMessage]=@WWPDiscussionMessageMessage, [WWPDiscussionMessageEntityReco]=@WWPDiscussionMessageEntityReco, [WWPUserExtendedId]=@WWPUserExtendedId, [WWPEntityId]=@WWPEntityId, [WWPDiscussionMessageThreadId]=@WWPDiscussionMessageThreadId  WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId", GxErrorMask.GX_NOMASK,prmT001Y15)
           ,new CursorDef("T001Y16", "DELETE FROM [WWP_DiscussionMessage]  WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId", GxErrorMask.GX_NOMASK,prmT001Y16)
           ,new CursorDef("T001Y17", "SELECT [WWPUserExtendedPhoto_GXI], [WWPUserExtendedFullName], [WWPUserExtendedPhoto] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y18", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y19", "SELECT TOP 1 [WWPDiscussionMessageId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageThreadId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001Y20", "SELECT TOP 1 [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] FROM [WWP_DiscussionMessageMention] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001Y21", "SELECT [WWPDiscussionMessageId] FROM [WWP_DiscussionMessage] ORDER BY [WWPDiscussionMessageId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y21,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y22", "SELECT [WWPDiscussionMessageId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y22,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
