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
   public class wwp_discussionmessagemention : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A540WWPDiscussionMessageId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPDiscussionMessageId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A540WWPDiscussionMessageId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A541WWPDiscussionMentionUserId = GetPar( "WWPDiscussionMentionUserId");
            AssignAttri("", false, "A541WWPDiscussionMentionUserId", A541WWPDiscussionMentionUserId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A541WWPDiscussionMentionUserId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Discussion Message Mention", ""), 0) ;
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

      public wwp_discussionmessagemention( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_discussionmessagemention( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Discussion Message Mention", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"wwpbaseobjects.discussions.gx0270.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPDISCUSSIONMESSAGEID"+"'), id:'"+"WWPDISCUSSIONMESSAGEID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"WWPDISCUSSIONMENTIONUSERID"+"'), id:'"+"WWPDISCUSSIONMENTIONUSERID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
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
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageId_Internalname, context.GetMessage( "Message Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A540WWPDiscussionMessageId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPDiscussionMessageId_Enabled!=0) ? context.localUtil.Format( (decimal)(A540WWPDiscussionMessageId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A540WWPDiscussionMessageId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_540_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_540_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_540_Internalname, sImgUrl, imgprompt_540_Link, "", "", context.GetTheme( ), imgprompt_540_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
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
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageDate_Internalname, context.GetMessage( "Message Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPDiscussionMessageDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageDate_Internalname, context.localUtil.TToC( A543WWPDiscussionMessageDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A543WWPDiscussionMessageDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageDate_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_bitmap( context, edtWWPDiscussionMessageDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPDiscussionMessageDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMentionUserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMentionUserId_Internalname, context.GetMessage( "Mention User Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMentionUserId_Internalname, StringUtil.RTrim( A541WWPDiscussionMentionUserId), StringUtil.RTrim( context.localUtil.Format( A541WWPDiscussionMentionUserId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMentionUserId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMentionUserId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_541_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_541_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_541_Internalname, sImgUrl, imgprompt_541_Link, "", "", context.GetTheme( ), imgprompt_541_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMentionUserName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMentionUserName_Internalname, context.GetMessage( "Mention User Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMentionUserName_Internalname, A542WWPDiscussionMentionUserName, StringUtil.RTrim( context.localUtil.Format( A542WWPDiscussionMentionUserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMentionUserName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMentionUserName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessageMention.htm");
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
            Z541WWPDiscussionMentionUserId = cgiGet( "Z541WWPDiscussionMentionUserId");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
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
            A543WWPDiscussionMessageDate = context.localUtil.CToT( cgiGet( edtWWPDiscussionMessageDate_Internalname));
            AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A541WWPDiscussionMentionUserId = cgiGet( edtWWPDiscussionMentionUserId_Internalname);
            AssignAttri("", false, "A541WWPDiscussionMentionUserId", A541WWPDiscussionMentionUserId);
            A542WWPDiscussionMentionUserName = cgiGet( edtWWPDiscussionMentionUserName_Internalname);
            AssignAttri("", false, "A542WWPDiscussionMentionUserName", A542WWPDiscussionMentionUserName);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
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
               A541WWPDiscussionMentionUserId = GetPar( "WWPDiscussionMentionUserId");
               AssignAttri("", false, "A541WWPDiscussionMentionUserId", A541WWPDiscussionMentionUserId);
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
               InitAll1Z79( ) ;
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
         DisableAttributes1Z79( ) ;
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

      protected void ResetCaption1Z0( )
      {
      }

      protected void ZM1Z79( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -1 )
         {
            Z540WWPDiscussionMessageId = A540WWPDiscussionMessageId;
            Z541WWPDiscussionMentionUserId = A541WWPDiscussionMentionUserId;
            Z543WWPDiscussionMessageDate = A543WWPDiscussionMessageDate;
            Z542WWPDiscussionMentionUserName = A542WWPDiscussionMentionUserName;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_540_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.discussions.gx0260.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPDISCUSSIONMESSAGEID"+"'), id:'"+"WWPDISCUSSIONMESSAGEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_541_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPDISCUSSIONMENTIONUSERID"+"'), id:'"+"WWPDISCUSSIONMENTIONUSERID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");");
      }

      protected void standaloneModal( )
      {
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
      }

      protected void Load1Z79( )
      {
         /* Using cursor T001Z6 */
         pr_default.execute(4, new Object[] {A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound79 = 1;
            A543WWPDiscussionMessageDate = T001Z6_A543WWPDiscussionMessageDate[0];
            AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A542WWPDiscussionMentionUserName = T001Z6_A542WWPDiscussionMentionUserName[0];
            AssignAttri("", false, "A542WWPDiscussionMentionUserName", A542WWPDiscussionMentionUserName);
            ZM1Z79( -1) ;
         }
         pr_default.close(4);
         OnLoadActions1Z79( ) ;
      }

      protected void OnLoadActions1Z79( )
      {
      }

      protected void CheckExtendedTable1Z79( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001Z4 */
         pr_default.execute(2, new Object[] {A540WWPDiscussionMessageId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_DiscussionMessage", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A543WWPDiscussionMessageDate = T001Z4_A543WWPDiscussionMessageDate[0];
         AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         pr_default.close(2);
         /* Using cursor T001Z5 */
         pr_default.execute(3, new Object[] {A541WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Mention User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMentionUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A542WWPDiscussionMentionUserName = T001Z5_A542WWPDiscussionMentionUserName[0];
         AssignAttri("", false, "A542WWPDiscussionMentionUserName", A542WWPDiscussionMentionUserName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1Z79( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( long A540WWPDiscussionMessageId )
      {
         /* Using cursor T001Z7 */
         pr_default.execute(5, new Object[] {A540WWPDiscussionMessageId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_DiscussionMessage", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A543WWPDiscussionMessageDate = T001Z7_A543WWPDiscussionMessageDate[0];
         AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A543WWPDiscussionMessageDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( string A541WWPDiscussionMentionUserId )
      {
         /* Using cursor T001Z8 */
         pr_default.execute(6, new Object[] {A541WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Mention User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMentionUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A542WWPDiscussionMentionUserName = T001Z8_A542WWPDiscussionMentionUserName[0];
         AssignAttri("", false, "A542WWPDiscussionMentionUserName", A542WWPDiscussionMentionUserName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A542WWPDiscussionMentionUserName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1Z79( )
      {
         /* Using cursor T001Z9 */
         pr_default.execute(7, new Object[] {A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound79 = 1;
         }
         else
         {
            RcdFound79 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001Z3 */
         pr_default.execute(1, new Object[] {A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Z79( 1) ;
            RcdFound79 = 1;
            A540WWPDiscussionMessageId = T001Z3_A540WWPDiscussionMessageId[0];
            AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
            A541WWPDiscussionMentionUserId = T001Z3_A541WWPDiscussionMentionUserId[0];
            AssignAttri("", false, "A541WWPDiscussionMentionUserId", A541WWPDiscussionMentionUserId);
            Z540WWPDiscussionMessageId = A540WWPDiscussionMessageId;
            Z541WWPDiscussionMentionUserId = A541WWPDiscussionMentionUserId;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1Z79( ) ;
            if ( AnyError == 1 )
            {
               RcdFound79 = 0;
               InitializeNonKey1Z79( ) ;
            }
            Gx_mode = sMode79;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound79 = 0;
            InitializeNonKey1Z79( ) ;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode79;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Z79( ) ;
         if ( RcdFound79 == 0 )
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
         RcdFound79 = 0;
         /* Using cursor T001Z10 */
         pr_default.execute(8, new Object[] {A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001Z10_A540WWPDiscussionMessageId[0] < A540WWPDiscussionMessageId ) || ( T001Z10_A540WWPDiscussionMessageId[0] == A540WWPDiscussionMessageId ) && ( StringUtil.StrCmp(T001Z10_A541WWPDiscussionMentionUserId[0], A541WWPDiscussionMentionUserId) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001Z10_A540WWPDiscussionMessageId[0] > A540WWPDiscussionMessageId ) || ( T001Z10_A540WWPDiscussionMessageId[0] == A540WWPDiscussionMessageId ) && ( StringUtil.StrCmp(T001Z10_A541WWPDiscussionMentionUserId[0], A541WWPDiscussionMentionUserId) > 0 ) ) )
            {
               A540WWPDiscussionMessageId = T001Z10_A540WWPDiscussionMessageId[0];
               AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
               A541WWPDiscussionMentionUserId = T001Z10_A541WWPDiscussionMentionUserId[0];
               AssignAttri("", false, "A541WWPDiscussionMentionUserId", A541WWPDiscussionMentionUserId);
               RcdFound79 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound79 = 0;
         /* Using cursor T001Z11 */
         pr_default.execute(9, new Object[] {A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001Z11_A540WWPDiscussionMessageId[0] > A540WWPDiscussionMessageId ) || ( T001Z11_A540WWPDiscussionMessageId[0] == A540WWPDiscussionMessageId ) && ( StringUtil.StrCmp(T001Z11_A541WWPDiscussionMentionUserId[0], A541WWPDiscussionMentionUserId) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001Z11_A540WWPDiscussionMessageId[0] < A540WWPDiscussionMessageId ) || ( T001Z11_A540WWPDiscussionMessageId[0] == A540WWPDiscussionMessageId ) && ( StringUtil.StrCmp(T001Z11_A541WWPDiscussionMentionUserId[0], A541WWPDiscussionMentionUserId) < 0 ) ) )
            {
               A540WWPDiscussionMessageId = T001Z11_A540WWPDiscussionMessageId[0];
               AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
               A541WWPDiscussionMentionUserId = T001Z11_A541WWPDiscussionMentionUserId[0];
               AssignAttri("", false, "A541WWPDiscussionMentionUserId", A541WWPDiscussionMentionUserId);
               RcdFound79 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1Z79( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1Z79( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound79 == 1 )
            {
               if ( ( A540WWPDiscussionMessageId != Z540WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A541WWPDiscussionMentionUserId, Z541WWPDiscussionMentionUserId) != 0 ) )
               {
                  A540WWPDiscussionMessageId = Z540WWPDiscussionMessageId;
                  AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
                  A541WWPDiscussionMentionUserId = Z541WWPDiscussionMentionUserId;
                  AssignAttri("", false, "A541WWPDiscussionMentionUserId", A541WWPDiscussionMentionUserId);
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
                  Update1Z79( ) ;
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A540WWPDiscussionMessageId != Z540WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A541WWPDiscussionMentionUserId, Z541WWPDiscussionMentionUserId) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1Z79( ) ;
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
                     Insert1Z79( ) ;
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
         if ( ( A540WWPDiscussionMessageId != Z540WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A541WWPDiscussionMentionUserId, Z541WWPDiscussionMentionUserId) != 0 ) )
         {
            A540WWPDiscussionMessageId = Z540WWPDiscussionMessageId;
            AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
            A541WWPDiscussionMentionUserId = Z541WWPDiscussionMentionUserId;
            AssignAttri("", false, "A541WWPDiscussionMentionUserId", A541WWPDiscussionMentionUserId);
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
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1Z79( ) ;
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd1Z79( ) ;
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
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
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
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1Z79( ) ;
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound79 != 0 )
            {
               ScanNext1Z79( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd1Z79( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1Z79( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001Z2 */
            pr_default.execute(0, new Object[] {A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessageMention"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_DiscussionMessageMention"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Z79( )
      {
         BeforeValidate1Z79( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Z79( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Z79( 0) ;
            CheckOptimisticConcurrency1Z79( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Z79( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Z79( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Z12 */
                     pr_default.execute(10, new Object[] {A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessageMention");
                     if ( (pr_default.getStatus(10) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1Z0( ) ;
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
               Load1Z79( ) ;
            }
            EndLevel1Z79( ) ;
         }
         CloseExtendedTableCursors1Z79( ) ;
      }

      protected void Update1Z79( )
      {
         BeforeValidate1Z79( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Z79( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Z79( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Z79( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Z79( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [WWP_DiscussionMessageMention] */
                     DeferredUpdate1Z79( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1Z0( ) ;
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
            EndLevel1Z79( ) ;
         }
         CloseExtendedTableCursors1Z79( ) ;
      }

      protected void DeferredUpdate1Z79( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1Z79( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Z79( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Z79( ) ;
            AfterConfirm1Z79( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Z79( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001Z13 */
                  pr_default.execute(11, new Object[] {A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessageMention");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound79 == 0 )
                        {
                           InitAll1Z79( ) ;
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
                        ResetCaption1Z0( ) ;
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
         sMode79 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1Z79( ) ;
         Gx_mode = sMode79;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1Z79( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001Z14 */
            pr_default.execute(12, new Object[] {A540WWPDiscussionMessageId});
            A543WWPDiscussionMessageDate = T001Z14_A543WWPDiscussionMessageDate[0];
            AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            pr_default.close(12);
            /* Using cursor T001Z15 */
            pr_default.execute(13, new Object[] {A541WWPDiscussionMentionUserId});
            A542WWPDiscussionMentionUserName = T001Z15_A542WWPDiscussionMentionUserName[0];
            AssignAttri("", false, "A542WWPDiscussionMentionUserName", A542WWPDiscussionMentionUserName);
            pr_default.close(13);
         }
      }

      protected void EndLevel1Z79( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Z79( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(12);
            pr_default.close(13);
            context.CommitDataStores("wwpbaseobjects.discussions.wwp_discussionmessagemention",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1Z0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(12);
            pr_default.close(13);
            context.RollbackDataStores("wwpbaseobjects.discussions.wwp_discussionmessagemention",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1Z79( )
      {
         /* Using cursor T001Z16 */
         pr_default.execute(14);
         RcdFound79 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound79 = 1;
            A540WWPDiscussionMessageId = T001Z16_A540WWPDiscussionMessageId[0];
            AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
            A541WWPDiscussionMentionUserId = T001Z16_A541WWPDiscussionMentionUserId[0];
            AssignAttri("", false, "A541WWPDiscussionMentionUserId", A541WWPDiscussionMentionUserId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1Z79( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound79 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound79 = 1;
            A540WWPDiscussionMessageId = T001Z16_A540WWPDiscussionMessageId[0];
            AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
            A541WWPDiscussionMentionUserId = T001Z16_A541WWPDiscussionMentionUserId[0];
            AssignAttri("", false, "A541WWPDiscussionMentionUserId", A541WWPDiscussionMentionUserId);
         }
      }

      protected void ScanEnd1Z79( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm1Z79( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Z79( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Z79( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Z79( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Z79( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Z79( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Z79( )
      {
         edtWWPDiscussionMessageId_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageId_Enabled), 5, 0), true);
         edtWWPDiscussionMessageDate_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageDate_Enabled), 5, 0), true);
         edtWWPDiscussionMentionUserId_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMentionUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMentionUserId_Enabled), 5, 0), true);
         edtWWPDiscussionMentionUserName_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMentionUserName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMentionUserName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1Z79( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1Z0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.discussions.wwp_discussionmessagemention.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z541WWPDiscussionMentionUserId", StringUtil.RTrim( Z541WWPDiscussionMentionUserId));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("wwpbaseobjects.discussions.wwp_discussionmessagemention.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Discussions.WWP_DiscussionMessageMention" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Discussion Message Mention", "") ;
      }

      protected void InitializeNonKey1Z79( )
      {
         A543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A542WWPDiscussionMentionUserName = "";
         AssignAttri("", false, "A542WWPDiscussionMentionUserName", A542WWPDiscussionMentionUserName);
      }

      protected void InitAll1Z79( )
      {
         A540WWPDiscussionMessageId = 0;
         AssignAttri("", false, "A540WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A540WWPDiscussionMessageId), 10, 0));
         A541WWPDiscussionMentionUserId = "";
         AssignAttri("", false, "A541WWPDiscussionMentionUserId", A541WWPDiscussionMentionUserId);
         InitializeNonKey1Z79( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021144836", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/discussions/wwp_discussionmessagemention.js", "?202673021144836", false, true, false);
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
         edtWWPDiscussionMentionUserId_Internalname = "WWPDISCUSSIONMENTIONUSERID";
         edtWWPDiscussionMentionUserName_Internalname = "WWPDISCUSSIONMENTIONUSERNAME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_540_Internalname = "PROMPT_540";
         imgprompt_541_Internalname = "PROMPT_541";
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
         Form.Caption = context.GetMessage( "Discussion Message Mention", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPDiscussionMentionUserName_Jsonclick = "";
         edtWWPDiscussionMentionUserName_Enabled = 0;
         imgprompt_541_Visible = 1;
         imgprompt_541_Link = "";
         edtWWPDiscussionMentionUserId_Jsonclick = "";
         edtWWPDiscussionMentionUserId_Enabled = 1;
         edtWWPDiscussionMessageDate_Jsonclick = "";
         edtWWPDiscussionMessageDate_Enabled = 0;
         imgprompt_540_Visible = 1;
         imgprompt_540_Link = "";
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

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T001Z14 */
         pr_default.execute(12, new Object[] {A540WWPDiscussionMessageId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_DiscussionMessage", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A543WWPDiscussionMessageDate = T001Z14_A543WWPDiscussionMessageDate[0];
         AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         pr_default.close(12);
         /* Using cursor T001Z15 */
         pr_default.execute(13, new Object[] {A541WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Mention User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMentionUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A542WWPDiscussionMentionUserName = T001Z15_A542WWPDiscussionMentionUserName[0];
         AssignAttri("", false, "A542WWPDiscussionMentionUserName", A542WWPDiscussionMentionUserName);
         pr_default.close(13);
         if ( AnyError == 0 )
         {
            GX_FocusControl = "";
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
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
         /* Using cursor T001Z14 */
         pr_default.execute(12, new Object[] {A540WWPDiscussionMessageId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_DiscussionMessage", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
         }
         A543WWPDiscussionMessageDate = T001Z14_A543WWPDiscussionMessageDate[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
      }

      public void Valid_Wwpdiscussionmentionuserid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T001Z15 */
         pr_default.execute(13, new Object[] {A541WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Mention User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMentionUserId_Internalname;
         }
         A542WWPDiscussionMentionUserName = T001Z15_A542WWPDiscussionMentionUserName[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A543WWPDiscussionMessageDate", context.localUtil.TToC( A543WWPDiscussionMessageDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A542WWPDiscussionMentionUserName", A542WWPDiscussionMentionUserName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z540WWPDiscussionMessageId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z540WWPDiscussionMessageId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z541WWPDiscussionMentionUserId", StringUtil.RTrim( Z541WWPDiscussionMentionUserId));
         GxWebStd.gx_hidden_field( context, "Z543WWPDiscussionMessageDate", context.localUtil.TToC( Z543WWPDiscussionMessageDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z542WWPDiscussionMentionUserName", Z542WWPDiscussionMentionUserName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
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
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEID","{handler:'Valid_Wwpdiscussionmessageid',iparms:[{av:'A540WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A543WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEID",",oparms:[{av:'A543WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99',type:'dtime'}]}");
         setEventMetadata("VALID_WWPDISCUSSIONMENTIONUSERID","{handler:'Valid_Wwpdiscussionmentionuserid',iparms:[{av:'A540WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A541WWPDiscussionMentionUserId',fld:'WWPDISCUSSIONMENTIONUSERID',pic:'',type:'char'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'}]");
         setEventMetadata("VALID_WWPDISCUSSIONMENTIONUSERID",",oparms:[{av:'A543WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99',type:'dtime'},{av:'A542WWPDiscussionMentionUserName',fld:'WWPDISCUSSIONMENTIONUSERNAME',pic:'',type:'svchar'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z540WWPDiscussionMessageId',type:'int'},{av:'Z541WWPDiscussionMentionUserId',type:'char'},{av:'Z543WWPDiscussionMessageDate',type:'dtime'},{av:'Z542WWPDiscussionMentionUserName',type:'svchar'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         pr_default.close(12);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z541WWPDiscussionMentionUserId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A541WWPDiscussionMentionUserId = "";
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
         imgprompt_540_gximage = "";
         sImgUrl = "";
         A543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         imgprompt_541_gximage = "";
         A542WWPDiscussionMentionUserName = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z542WWPDiscussionMentionUserName = "";
         T001Z6_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T001Z6_A542WWPDiscussionMentionUserName = new string[] {""} ;
         T001Z6_A540WWPDiscussionMessageId = new long[1] ;
         T001Z6_A541WWPDiscussionMentionUserId = new string[] {""} ;
         T001Z4_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T001Z5_A542WWPDiscussionMentionUserName = new string[] {""} ;
         T001Z7_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T001Z8_A542WWPDiscussionMentionUserName = new string[] {""} ;
         T001Z9_A540WWPDiscussionMessageId = new long[1] ;
         T001Z9_A541WWPDiscussionMentionUserId = new string[] {""} ;
         T001Z3_A540WWPDiscussionMessageId = new long[1] ;
         T001Z3_A541WWPDiscussionMentionUserId = new string[] {""} ;
         sMode79 = "";
         T001Z10_A540WWPDiscussionMessageId = new long[1] ;
         T001Z10_A541WWPDiscussionMentionUserId = new string[] {""} ;
         T001Z11_A540WWPDiscussionMessageId = new long[1] ;
         T001Z11_A541WWPDiscussionMentionUserId = new string[] {""} ;
         T001Z2_A540WWPDiscussionMessageId = new long[1] ;
         T001Z2_A541WWPDiscussionMentionUserId = new string[] {""} ;
         T001Z14_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T001Z15_A542WWPDiscussionMentionUserName = new string[] {""} ;
         T001Z16_A540WWPDiscussionMessageId = new long[1] ;
         T001Z16_A541WWPDiscussionMentionUserId = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ541WWPDiscussionMentionUserId = "";
         ZZ543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         ZZ542WWPDiscussionMentionUserName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessagemention__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessagemention__default(),
            new Object[][] {
                new Object[] {
               T001Z2_A540WWPDiscussionMessageId, T001Z2_A541WWPDiscussionMentionUserId
               }
               , new Object[] {
               T001Z3_A540WWPDiscussionMessageId, T001Z3_A541WWPDiscussionMentionUserId
               }
               , new Object[] {
               T001Z4_A543WWPDiscussionMessageDate
               }
               , new Object[] {
               T001Z5_A542WWPDiscussionMentionUserName
               }
               , new Object[] {
               T001Z6_A543WWPDiscussionMessageDate, T001Z6_A542WWPDiscussionMentionUserName, T001Z6_A540WWPDiscussionMessageId, T001Z6_A541WWPDiscussionMentionUserId
               }
               , new Object[] {
               T001Z7_A543WWPDiscussionMessageDate
               }
               , new Object[] {
               T001Z8_A542WWPDiscussionMentionUserName
               }
               , new Object[] {
               T001Z9_A540WWPDiscussionMessageId, T001Z9_A541WWPDiscussionMentionUserId
               }
               , new Object[] {
               T001Z10_A540WWPDiscussionMessageId, T001Z10_A541WWPDiscussionMentionUserId
               }
               , new Object[] {
               T001Z11_A540WWPDiscussionMessageId, T001Z11_A541WWPDiscussionMentionUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001Z14_A543WWPDiscussionMessageDate
               }
               , new Object[] {
               T001Z15_A542WWPDiscussionMentionUserName
               }
               , new Object[] {
               T001Z16_A540WWPDiscussionMessageId, T001Z16_A541WWPDiscussionMentionUserId
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound79 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPDiscussionMessageId_Enabled ;
      private int imgprompt_540_Visible ;
      private int edtWWPDiscussionMessageDate_Enabled ;
      private int edtWWPDiscussionMentionUserId_Enabled ;
      private int imgprompt_541_Visible ;
      private int edtWWPDiscussionMentionUserName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z540WWPDiscussionMessageId ;
      private long A540WWPDiscussionMessageId ;
      private long ZZ540WWPDiscussionMessageId ;
      private string sPrefix ;
      private string Z541WWPDiscussionMentionUserId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A541WWPDiscussionMentionUserId ;
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
      private string imgprompt_540_gximage ;
      private string sImgUrl ;
      private string imgprompt_540_Internalname ;
      private string imgprompt_540_Link ;
      private string edtWWPDiscussionMessageDate_Internalname ;
      private string edtWWPDiscussionMessageDate_Jsonclick ;
      private string edtWWPDiscussionMentionUserId_Internalname ;
      private string edtWWPDiscussionMentionUserId_Jsonclick ;
      private string imgprompt_541_gximage ;
      private string imgprompt_541_Internalname ;
      private string imgprompt_541_Link ;
      private string edtWWPDiscussionMentionUserName_Internalname ;
      private string edtWWPDiscussionMentionUserName_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode79 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ541WWPDiscussionMentionUserId ;
      private DateTime A543WWPDiscussionMessageDate ;
      private DateTime Z543WWPDiscussionMessageDate ;
      private DateTime ZZ543WWPDiscussionMessageDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string A542WWPDiscussionMentionUserName ;
      private string Z542WWPDiscussionMentionUserName ;
      private string ZZ542WWPDiscussionMentionUserName ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T001Z6_A543WWPDiscussionMessageDate ;
      private string[] T001Z6_A542WWPDiscussionMentionUserName ;
      private long[] T001Z6_A540WWPDiscussionMessageId ;
      private string[] T001Z6_A541WWPDiscussionMentionUserId ;
      private DateTime[] T001Z4_A543WWPDiscussionMessageDate ;
      private string[] T001Z5_A542WWPDiscussionMentionUserName ;
      private DateTime[] T001Z7_A543WWPDiscussionMessageDate ;
      private string[] T001Z8_A542WWPDiscussionMentionUserName ;
      private long[] T001Z9_A540WWPDiscussionMessageId ;
      private string[] T001Z9_A541WWPDiscussionMentionUserId ;
      private long[] T001Z3_A540WWPDiscussionMessageId ;
      private string[] T001Z3_A541WWPDiscussionMentionUserId ;
      private long[] T001Z10_A540WWPDiscussionMessageId ;
      private string[] T001Z10_A541WWPDiscussionMentionUserId ;
      private long[] T001Z11_A540WWPDiscussionMessageId ;
      private string[] T001Z11_A541WWPDiscussionMentionUserId ;
      private long[] T001Z2_A540WWPDiscussionMessageId ;
      private string[] T001Z2_A541WWPDiscussionMentionUserId ;
      private DateTime[] T001Z14_A543WWPDiscussionMessageDate ;
      private string[] T001Z15_A542WWPDiscussionMentionUserName ;
      private long[] T001Z16_A540WWPDiscussionMessageId ;
      private string[] T001Z16_A541WWPDiscussionMentionUserId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_discussionmessagemention__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_discussionmessagemention__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001Z2;
        prmT001Z2 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmT001Z3;
        prmT001Z3 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmT001Z4;
        prmT001Z4 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmT001Z5;
        prmT001Z5 = new Object[] {
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmT001Z6;
        prmT001Z6 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmT001Z7;
        prmT001Z7 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmT001Z8;
        prmT001Z8 = new Object[] {
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmT001Z9;
        prmT001Z9 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmT001Z10;
        prmT001Z10 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmT001Z11;
        prmT001Z11 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmT001Z12;
        prmT001Z12 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmT001Z13;
        prmT001Z13 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmT001Z14;
        prmT001Z14 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmT001Z15;
        prmT001Z15 = new Object[] {
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmT001Z16;
        prmT001Z16 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001Z2", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WITH (UPDLOCK) WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Z3", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Z4", "SELECT [WWPDiscussionMessageDate] FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Z5", "SELECT [WWPUserExtendedFullName] AS WWPDiscussionMentionUserName FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Z6", "SELECT T2.[WWPDiscussionMessageDate], T3.[WWPUserExtendedFullName] AS WWPDiscussionMentionUserName, TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM (([WWP_DiscussionMessageMention] TM1 INNER JOIN [WWP_DiscussionMessage] T2 ON T2.[WWPDiscussionMessageId] = TM1.[WWPDiscussionMessageId]) INNER JOIN [WWP_UserExtended] T3 ON T3.[WWPUserExtendedId] = TM1.[WWPDiscussionMentionUserId]) WHERE TM1.[WWPDiscussionMessageId] = @WWPDiscussionMessageId and TM1.[WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId ORDER BY TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMentionUserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Z7", "SELECT [WWPDiscussionMessageDate] FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Z8", "SELECT [WWPUserExtendedFullName] AS WWPDiscussionMentionUserName FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Z9", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Z10", "SELECT TOP 1 [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WHERE ( [WWPDiscussionMessageId] > @WWPDiscussionMessageId or [WWPDiscussionMessageId] = @WWPDiscussionMessageId and [WWPDiscussionMentionUserId] > @WWPDiscussionMentionUserId) ORDER BY [WWPDiscussionMessageId], [WWPDiscussionMentionUserId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001Z11", "SELECT TOP 1 [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WHERE ( [WWPDiscussionMessageId] < @WWPDiscussionMessageId or [WWPDiscussionMessageId] = @WWPDiscussionMessageId and [WWPDiscussionMentionUserId] < @WWPDiscussionMentionUserId) ORDER BY [WWPDiscussionMessageId] DESC, [WWPDiscussionMentionUserId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001Z12", "INSERT INTO [WWP_DiscussionMessageMention]([WWPDiscussionMessageId], [WWPDiscussionMentionUserId]) VALUES(@WWPDiscussionMessageId, @WWPDiscussionMentionUserId)", GxErrorMask.GX_NOMASK,prmT001Z12)
           ,new CursorDef("T001Z13", "DELETE FROM [WWP_DiscussionMessageMention]  WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId", GxErrorMask.GX_NOMASK,prmT001Z13)
           ,new CursorDef("T001Z14", "SELECT [WWPDiscussionMessageDate] FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Z15", "SELECT [WWPUserExtendedFullName] AS WWPDiscussionMentionUserName FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Z16", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] ORDER BY [WWPDiscussionMessageId], [WWPDiscussionMentionUserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z16,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 2 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              return;
           case 5 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 12 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
     }
  }

}

}
