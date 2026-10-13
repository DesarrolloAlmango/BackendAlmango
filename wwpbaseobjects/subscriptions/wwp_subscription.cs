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
   public class wwp_subscription : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A32WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A32WWPNotificationDefinitionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A29WWPEntityId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPEntityId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A29WWPEntityId", StringUtil.LTrimStr( (decimal)(A29WWPEntityId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A29WWPEntityId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A1WWPUserExtendedId = GetPar( "WWPUserExtendedId");
            n1WWPUserExtendedId = false;
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A1WWPUserExtendedId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "WWP_Subscription", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_subscription( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_subscription( IGxContext context )
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
         chkWWPSubscriptionSubscribed = new GXCheckbox();
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
         A36WWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( A36WWPSubscriptionSubscribed));
         AssignAttri("", false, "A36WWPSubscriptionSubscribed", A36WWPSubscriptionSubscribed);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "WWP_Subscription", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"wwpbaseobjects.subscriptions.gx00a0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPSUBSCRIPTIONID"+"'), id:'"+"WWPSUBSCRIPTIONID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPSubscriptionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A34WWPSubscriptionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPSubscriptionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A34WWPSubscriptionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A34WWPSubscriptionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSubscriptionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSubscriptionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionId_Internalname, context.GetMessage( "Notification Definition Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A32WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPNotificationDefinitionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A32WWPNotificationDefinitionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A32WWPNotificationDefinitionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_32_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_32_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_32_Internalname, sImgUrl, imgprompt_32_Link, "", "", context.GetTheme( ), imgprompt_32_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionDescr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionDescr_Internalname, context.GetMessage( "Notification Definition Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionDescr_Internalname, A38WWPNotificationDefinitionDescr, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtWWPNotificationDefinitionDescr_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityName_Internalname, A30WWPEntityName, StringUtil.RTrim( context.localUtil.Format( A30WWPEntityName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A1WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A1WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_1_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_1_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A2WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A2WWPUserExtendedFullName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionEntityRecordId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionEntityRecordId_Internalname, context.GetMessage( "Record Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSubscriptionEntityRecordId_Internalname, A35WWPSubscriptionEntityRecordId, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtWWPSubscriptionEntityRecordId_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionEntityRecordDes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionEntityRecordDes_Internalname, context.GetMessage( "Record Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSubscriptionEntityRecordDes_Internalname, A37WWPSubscriptionEntityRecordDes, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtWWPSubscriptionEntityRecordDes_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionRoleId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionRoleId_Internalname, context.GetMessage( "Role Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPSubscriptionRoleId_Internalname, StringUtil.RTrim( A28WWPSubscriptionRoleId), StringUtil.RTrim( context.localUtil.Format( A28WWPSubscriptionRoleId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSubscriptionRoleId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSubscriptionRoleId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPSubscriptionSubscribed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPSubscriptionSubscribed_Internalname, context.GetMessage( "Subscribed", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPSubscriptionSubscribed_Internalname, StringUtil.BoolToStr( A36WWPSubscriptionSubscribed), "", context.GetMessage( "Subscribed", ""), 1, chkWWPSubscriptionSubscribed.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(79, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,79);\"");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
            Z34WWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z34WWPSubscriptionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z35WWPSubscriptionEntityRecordId = cgiGet( "Z35WWPSubscriptionEntityRecordId");
            Z37WWPSubscriptionEntityRecordDes = cgiGet( "Z37WWPSubscriptionEntityRecordDes");
            Z28WWPSubscriptionRoleId = cgiGet( "Z28WWPSubscriptionRoleId");
            n28WWPSubscriptionRoleId = (String.IsNullOrEmpty(StringUtil.RTrim( A28WWPSubscriptionRoleId)) ? true : false);
            Z36WWPSubscriptionSubscribed = StringUtil.StrToBool( cgiGet( "Z36WWPSubscriptionSubscribed"));
            Z32WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z32WWPNotificationDefinitionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z1WWPUserExtendedId = cgiGet( "Z1WWPUserExtendedId");
            n1WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A29WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "WWPENTITYID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPSUBSCRIPTIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPSubscriptionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A34WWPSubscriptionId = 0;
               AssignAttri("", false, "A34WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A34WWPSubscriptionId), 10, 0));
            }
            else
            {
               A34WWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A34WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A34WWPSubscriptionId), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A32WWPNotificationDefinitionId = 0;
               AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
            }
            else
            {
               A32WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
            }
            A38WWPNotificationDefinitionDescr = cgiGet( edtWWPNotificationDefinitionDescr_Internalname);
            AssignAttri("", false, "A38WWPNotificationDefinitionDescr", A38WWPNotificationDefinitionDescr);
            A30WWPEntityName = cgiGet( edtWWPEntityName_Internalname);
            AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
            A1WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n1WWPUserExtendedId = false;
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            n1WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ? true : false);
            A2WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
            A35WWPSubscriptionEntityRecordId = cgiGet( edtWWPSubscriptionEntityRecordId_Internalname);
            AssignAttri("", false, "A35WWPSubscriptionEntityRecordId", A35WWPSubscriptionEntityRecordId);
            A37WWPSubscriptionEntityRecordDes = cgiGet( edtWWPSubscriptionEntityRecordDes_Internalname);
            AssignAttri("", false, "A37WWPSubscriptionEntityRecordDes", A37WWPSubscriptionEntityRecordDes);
            A28WWPSubscriptionRoleId = cgiGet( edtWWPSubscriptionRoleId_Internalname);
            n28WWPSubscriptionRoleId = false;
            AssignAttri("", false, "A28WWPSubscriptionRoleId", A28WWPSubscriptionRoleId);
            n28WWPSubscriptionRoleId = (String.IsNullOrEmpty(StringUtil.RTrim( A28WWPSubscriptionRoleId)) ? true : false);
            A36WWPSubscriptionSubscribed = StringUtil.StrToBool( cgiGet( chkWWPSubscriptionSubscribed_Internalname));
            AssignAttri("", false, "A36WWPSubscriptionSubscribed", A36WWPSubscriptionSubscribed);
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
               A34WWPSubscriptionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPSubscriptionId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A34WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A34WWPSubscriptionId), 10, 0));
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
               InitAll0910( ) ;
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
         DisableAttributes0910( ) ;
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

      protected void ResetCaption090( )
      {
      }

      protected void ZM0910( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z35WWPSubscriptionEntityRecordId = T00093_A35WWPSubscriptionEntityRecordId[0];
               Z37WWPSubscriptionEntityRecordDes = T00093_A37WWPSubscriptionEntityRecordDes[0];
               Z28WWPSubscriptionRoleId = T00093_A28WWPSubscriptionRoleId[0];
               Z36WWPSubscriptionSubscribed = T00093_A36WWPSubscriptionSubscribed[0];
               Z32WWPNotificationDefinitionId = T00093_A32WWPNotificationDefinitionId[0];
               Z1WWPUserExtendedId = T00093_A1WWPUserExtendedId[0];
            }
            else
            {
               Z35WWPSubscriptionEntityRecordId = A35WWPSubscriptionEntityRecordId;
               Z37WWPSubscriptionEntityRecordDes = A37WWPSubscriptionEntityRecordDes;
               Z28WWPSubscriptionRoleId = A28WWPSubscriptionRoleId;
               Z36WWPSubscriptionSubscribed = A36WWPSubscriptionSubscribed;
               Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
               Z1WWPUserExtendedId = A1WWPUserExtendedId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z34WWPSubscriptionId = A34WWPSubscriptionId;
            Z35WWPSubscriptionEntityRecordId = A35WWPSubscriptionEntityRecordId;
            Z37WWPSubscriptionEntityRecordDes = A37WWPSubscriptionEntityRecordDes;
            Z28WWPSubscriptionRoleId = A28WWPSubscriptionRoleId;
            Z36WWPSubscriptionSubscribed = A36WWPSubscriptionSubscribed;
            Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z29WWPEntityId = A29WWPEntityId;
            Z38WWPNotificationDefinitionDescr = A38WWPNotificationDefinitionDescr;
            Z30WWPEntityName = A30WWPEntityName;
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_32_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.notifications.common.gx00e0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPNOTIFICATIONDEFINITIONID"+"'), id:'"+"WWPNOTIFICATIONDEFINITIONID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPUSEREXTENDEDID"+"'), id:'"+"WWPUSEREXTENDEDID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load0910( )
      {
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A34WWPSubscriptionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound10 = 1;
            A29WWPEntityId = T00097_A29WWPEntityId[0];
            A38WWPNotificationDefinitionDescr = T00097_A38WWPNotificationDefinitionDescr[0];
            AssignAttri("", false, "A38WWPNotificationDefinitionDescr", A38WWPNotificationDefinitionDescr);
            A30WWPEntityName = T00097_A30WWPEntityName[0];
            AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
            A2WWPUserExtendedFullName = T00097_A2WWPUserExtendedFullName[0];
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
            A35WWPSubscriptionEntityRecordId = T00097_A35WWPSubscriptionEntityRecordId[0];
            AssignAttri("", false, "A35WWPSubscriptionEntityRecordId", A35WWPSubscriptionEntityRecordId);
            A37WWPSubscriptionEntityRecordDes = T00097_A37WWPSubscriptionEntityRecordDes[0];
            AssignAttri("", false, "A37WWPSubscriptionEntityRecordDes", A37WWPSubscriptionEntityRecordDes);
            A28WWPSubscriptionRoleId = T00097_A28WWPSubscriptionRoleId[0];
            n28WWPSubscriptionRoleId = T00097_n28WWPSubscriptionRoleId[0];
            AssignAttri("", false, "A28WWPSubscriptionRoleId", A28WWPSubscriptionRoleId);
            A36WWPSubscriptionSubscribed = T00097_A36WWPSubscriptionSubscribed[0];
            AssignAttri("", false, "A36WWPSubscriptionSubscribed", A36WWPSubscriptionSubscribed);
            A32WWPNotificationDefinitionId = T00097_A32WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
            A1WWPUserExtendedId = T00097_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = T00097_n1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            ZM0910( -2) ;
         }
         pr_default.close(5);
         OnLoadActions0910( ) ;
      }

      protected void OnLoadActions0910( )
      {
      }

      protected void CheckExtendedTable0910( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A29WWPEntityId = T00094_A29WWPEntityId[0];
         A38WWPNotificationDefinitionDescr = T00094_A38WWPNotificationDefinitionDescr[0];
         AssignAttri("", false, "A38WWPNotificationDefinitionDescr", A38WWPNotificationDefinitionDescr);
         pr_default.close(2);
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {A29WWPEntityId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A30WWPEntityName = T00096_A30WWPEntityName[0];
         AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
         pr_default.close(4);
         /* Using cursor T00095 */
         pr_default.execute(3, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A2WWPUserExtendedFullName = T00095_A2WWPUserExtendedFullName[0];
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0910( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( long A32WWPNotificationDefinitionId )
      {
         /* Using cursor T00098 */
         pr_default.execute(6, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A29WWPEntityId = T00098_A29WWPEntityId[0];
         A38WWPNotificationDefinitionDescr = T00098_A38WWPNotificationDefinitionDescr[0];
         AssignAttri("", false, "A38WWPNotificationDefinitionDescr", A38WWPNotificationDefinitionDescr);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A29WWPEntityId), 10, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A38WWPNotificationDefinitionDescr)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_5( long A29WWPEntityId )
      {
         /* Using cursor T00099 */
         pr_default.execute(7, new Object[] {A29WWPEntityId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A30WWPEntityName = T00099_A30WWPEntityName[0];
         AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A30WWPEntityName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_4( string A1WWPUserExtendedId )
      {
         /* Using cursor T000910 */
         pr_default.execute(8, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A2WWPUserExtendedFullName = T000910_A2WWPUserExtendedFullName[0];
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2WWPUserExtendedFullName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0910( )
      {
         /* Using cursor T000911 */
         pr_default.execute(9, new Object[] {A34WWPSubscriptionId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A34WWPSubscriptionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0910( 2) ;
            RcdFound10 = 1;
            A34WWPSubscriptionId = T00093_A34WWPSubscriptionId[0];
            AssignAttri("", false, "A34WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A34WWPSubscriptionId), 10, 0));
            A35WWPSubscriptionEntityRecordId = T00093_A35WWPSubscriptionEntityRecordId[0];
            AssignAttri("", false, "A35WWPSubscriptionEntityRecordId", A35WWPSubscriptionEntityRecordId);
            A37WWPSubscriptionEntityRecordDes = T00093_A37WWPSubscriptionEntityRecordDes[0];
            AssignAttri("", false, "A37WWPSubscriptionEntityRecordDes", A37WWPSubscriptionEntityRecordDes);
            A28WWPSubscriptionRoleId = T00093_A28WWPSubscriptionRoleId[0];
            n28WWPSubscriptionRoleId = T00093_n28WWPSubscriptionRoleId[0];
            AssignAttri("", false, "A28WWPSubscriptionRoleId", A28WWPSubscriptionRoleId);
            A36WWPSubscriptionSubscribed = T00093_A36WWPSubscriptionSubscribed[0];
            AssignAttri("", false, "A36WWPSubscriptionSubscribed", A36WWPSubscriptionSubscribed);
            A32WWPNotificationDefinitionId = T00093_A32WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
            A1WWPUserExtendedId = T00093_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = T00093_n1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            Z34WWPSubscriptionId = A34WWPSubscriptionId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0910( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0910( ) ;
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0910( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0910( ) ;
         if ( RcdFound10 == 0 )
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
         RcdFound10 = 0;
         /* Using cursor T000912 */
         pr_default.execute(10, new Object[] {A34WWPSubscriptionId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000912_A34WWPSubscriptionId[0] < A34WWPSubscriptionId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000912_A34WWPSubscriptionId[0] > A34WWPSubscriptionId ) ) )
            {
               A34WWPSubscriptionId = T000912_A34WWPSubscriptionId[0];
               AssignAttri("", false, "A34WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A34WWPSubscriptionId), 10, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound10 = 0;
         /* Using cursor T000913 */
         pr_default.execute(11, new Object[] {A34WWPSubscriptionId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000913_A34WWPSubscriptionId[0] > A34WWPSubscriptionId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000913_A34WWPSubscriptionId[0] < A34WWPSubscriptionId ) ) )
            {
               A34WWPSubscriptionId = T000913_A34WWPSubscriptionId[0];
               AssignAttri("", false, "A34WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A34WWPSubscriptionId), 10, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0910( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0910( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A34WWPSubscriptionId != Z34WWPSubscriptionId )
               {
                  A34WWPSubscriptionId = Z34WWPSubscriptionId;
                  AssignAttri("", false, "A34WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A34WWPSubscriptionId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPSUBSCRIPTIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0910( ) ;
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A34WWPSubscriptionId != Z34WWPSubscriptionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0910( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPSUBSCRIPTIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPSubscriptionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPSubscriptionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0910( ) ;
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
         if ( A34WWPSubscriptionId != Z34WWPSubscriptionId )
         {
            A34WWPSubscriptionId = Z34WWPSubscriptionId;
            AssignAttri("", false, "A34WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A34WWPSubscriptionId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPSUBSCRIPTIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPSUBSCRIPTIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0910( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0910( ) ;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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
         ScanStart0910( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound10 != 0 )
            {
               ScanNext0910( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0910( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0910( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A34WWPSubscriptionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z35WWPSubscriptionEntityRecordId, T00092_A35WWPSubscriptionEntityRecordId[0]) != 0 ) || ( StringUtil.StrCmp(Z37WWPSubscriptionEntityRecordDes, T00092_A37WWPSubscriptionEntityRecordDes[0]) != 0 ) || ( StringUtil.StrCmp(Z28WWPSubscriptionRoleId, T00092_A28WWPSubscriptionRoleId[0]) != 0 ) || ( Z36WWPSubscriptionSubscribed != T00092_A36WWPSubscriptionSubscribed[0] ) || ( Z32WWPNotificationDefinitionId != T00092_A32WWPNotificationDefinitionId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1WWPUserExtendedId, T00092_A1WWPUserExtendedId[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z35WWPSubscriptionEntityRecordId, T00092_A35WWPSubscriptionEntityRecordId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionEntityRecordId");
                  GXUtil.WriteLogRaw("Old: ",Z35WWPSubscriptionEntityRecordId);
                  GXUtil.WriteLogRaw("Current: ",T00092_A35WWPSubscriptionEntityRecordId[0]);
               }
               if ( StringUtil.StrCmp(Z37WWPSubscriptionEntityRecordDes, T00092_A37WWPSubscriptionEntityRecordDes[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionEntityRecordDes");
                  GXUtil.WriteLogRaw("Old: ",Z37WWPSubscriptionEntityRecordDes);
                  GXUtil.WriteLogRaw("Current: ",T00092_A37WWPSubscriptionEntityRecordDes[0]);
               }
               if ( StringUtil.StrCmp(Z28WWPSubscriptionRoleId, T00092_A28WWPSubscriptionRoleId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionRoleId");
                  GXUtil.WriteLogRaw("Old: ",Z28WWPSubscriptionRoleId);
                  GXUtil.WriteLogRaw("Current: ",T00092_A28WWPSubscriptionRoleId[0]);
               }
               if ( Z36WWPSubscriptionSubscribed != T00092_A36WWPSubscriptionSubscribed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionSubscribed");
                  GXUtil.WriteLogRaw("Old: ",Z36WWPSubscriptionSubscribed);
                  GXUtil.WriteLogRaw("Current: ",T00092_A36WWPSubscriptionSubscribed[0]);
               }
               if ( Z32WWPNotificationDefinitionId != T00092_A32WWPNotificationDefinitionId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPNotificationDefinitionId");
                  GXUtil.WriteLogRaw("Old: ",Z32WWPNotificationDefinitionId);
                  GXUtil.WriteLogRaw("Current: ",T00092_A32WWPNotificationDefinitionId[0]);
               }
               if ( StringUtil.StrCmp(Z1WWPUserExtendedId, T00092_A1WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z1WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T00092_A1WWPUserExtendedId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Subscription"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0910( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0910( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0910( 0) ;
            CheckOptimisticConcurrency0910( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0910( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000914 */
                     pr_default.execute(12, new Object[] {A35WWPSubscriptionEntityRecordId, A37WWPSubscriptionEntityRecordDes, n28WWPSubscriptionRoleId, A28WWPSubscriptionRoleId, A36WWPSubscriptionSubscribed, A32WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId});
                     A34WWPSubscriptionId = T000914_A34WWPSubscriptionId[0];
                     AssignAttri("", false, "A34WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A34WWPSubscriptionId), 10, 0));
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption090( ) ;
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
               Load0910( ) ;
            }
            EndLevel0910( ) ;
         }
         CloseExtendedTableCursors0910( ) ;
      }

      protected void Update0910( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0910( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0910( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0910( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000915 */
                     pr_default.execute(13, new Object[] {A35WWPSubscriptionEntityRecordId, A37WWPSubscriptionEntityRecordDes, n28WWPSubscriptionRoleId, A28WWPSubscriptionRoleId, A36WWPSubscriptionSubscribed, A32WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId, A34WWPSubscriptionId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0910( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption090( ) ;
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
            EndLevel0910( ) ;
         }
         CloseExtendedTableCursors0910( ) ;
      }

      protected void DeferredUpdate0910( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0910( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0910( ) ;
            AfterConfirm0910( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0910( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000916 */
                  pr_default.execute(14, new Object[] {A34WWPSubscriptionId});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound10 == 0 )
                        {
                           InitAll0910( ) ;
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
                        ResetCaption090( ) ;
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0910( ) ;
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0910( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000917 */
            pr_default.execute(15, new Object[] {A32WWPNotificationDefinitionId});
            A29WWPEntityId = T000917_A29WWPEntityId[0];
            A38WWPNotificationDefinitionDescr = T000917_A38WWPNotificationDefinitionDescr[0];
            AssignAttri("", false, "A38WWPNotificationDefinitionDescr", A38WWPNotificationDefinitionDescr);
            pr_default.close(15);
            /* Using cursor T000918 */
            pr_default.execute(16, new Object[] {A29WWPEntityId});
            A30WWPEntityName = T000918_A30WWPEntityName[0];
            AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
            pr_default.close(16);
            /* Using cursor T000919 */
            pr_default.execute(17, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            A2WWPUserExtendedFullName = T000919_A2WWPUserExtendedFullName[0];
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
            pr_default.close(17);
         }
      }

      protected void EndLevel0910( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0910( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(17);
            pr_default.close(16);
            context.CommitDataStores("wwpbaseobjects.subscriptions.wwp_subscription",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(17);
            pr_default.close(16);
            context.RollbackDataStores("wwpbaseobjects.subscriptions.wwp_subscription",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0910( )
      {
         /* Using cursor T000920 */
         pr_default.execute(18);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound10 = 1;
            A34WWPSubscriptionId = T000920_A34WWPSubscriptionId[0];
            AssignAttri("", false, "A34WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A34WWPSubscriptionId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0910( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound10 = 1;
            A34WWPSubscriptionId = T000920_A34WWPSubscriptionId[0];
            AssignAttri("", false, "A34WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A34WWPSubscriptionId), 10, 0));
         }
      }

      protected void ScanEnd0910( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0910( )
      {
         /* After Confirm Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) )
         {
            A1WWPUserExtendedId = "";
            n1WWPUserExtendedId = false;
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            n1WWPUserExtendedId = true;
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
         }
      }

      protected void BeforeInsert0910( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0910( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0910( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0910( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0910( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0910( )
      {
         edtWWPSubscriptionId_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionDescr_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionDescr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionDescr_Enabled), 5, 0), true);
         edtWWPEntityName_Enabled = 0;
         AssignProp("", false, edtWWPEntityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityName_Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPSubscriptionEntityRecordId_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionEntityRecordId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionEntityRecordId_Enabled), 5, 0), true);
         edtWWPSubscriptionEntityRecordDes_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionEntityRecordDes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionEntityRecordDes_Enabled), 5, 0), true);
         edtWWPSubscriptionRoleId_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionRoleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionRoleId_Enabled), 5, 0), true);
         chkWWPSubscriptionSubscribed.Enabled = 0;
         AssignProp("", false, chkWWPSubscriptionSubscribed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPSubscriptionSubscribed.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0910( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues090( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.subscriptions.wwp_subscription.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z34WWPSubscriptionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34WWPSubscriptionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z35WWPSubscriptionEntityRecordId", Z35WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, "Z37WWPSubscriptionEntityRecordDes", Z37WWPSubscriptionEntityRecordDes);
         GxWebStd.gx_hidden_field( context, "Z28WWPSubscriptionRoleId", StringUtil.RTrim( Z28WWPSubscriptionRoleId));
         GxWebStd.gx_boolean_hidden_field( context, "Z36WWPSubscriptionSubscribed", Z36WWPSubscriptionSubscribed);
         GxWebStd.gx_hidden_field( context, "Z32WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z32WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z1WWPUserExtendedId", StringUtil.RTrim( Z1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "WWPENTITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29WWPEntityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("wwpbaseobjects.subscriptions.wwp_subscription.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Subscriptions.WWP_Subscription" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Subscription", "") ;
      }

      protected void InitializeNonKey0910( )
      {
         A29WWPEntityId = 0;
         AssignAttri("", false, "A29WWPEntityId", StringUtil.LTrimStr( (decimal)(A29WWPEntityId), 10, 0));
         A32WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
         A38WWPNotificationDefinitionDescr = "";
         AssignAttri("", false, "A38WWPNotificationDefinitionDescr", A38WWPNotificationDefinitionDescr);
         A30WWPEntityName = "";
         AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
         A1WWPUserExtendedId = "";
         n1WWPUserExtendedId = false;
         AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
         n1WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ? true : false);
         A2WWPUserExtendedFullName = "";
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         A35WWPSubscriptionEntityRecordId = "";
         AssignAttri("", false, "A35WWPSubscriptionEntityRecordId", A35WWPSubscriptionEntityRecordId);
         A37WWPSubscriptionEntityRecordDes = "";
         AssignAttri("", false, "A37WWPSubscriptionEntityRecordDes", A37WWPSubscriptionEntityRecordDes);
         A28WWPSubscriptionRoleId = "";
         n28WWPSubscriptionRoleId = false;
         AssignAttri("", false, "A28WWPSubscriptionRoleId", A28WWPSubscriptionRoleId);
         n28WWPSubscriptionRoleId = (String.IsNullOrEmpty(StringUtil.RTrim( A28WWPSubscriptionRoleId)) ? true : false);
         A36WWPSubscriptionSubscribed = false;
         AssignAttri("", false, "A36WWPSubscriptionSubscribed", A36WWPSubscriptionSubscribed);
         Z35WWPSubscriptionEntityRecordId = "";
         Z37WWPSubscriptionEntityRecordDes = "";
         Z28WWPSubscriptionRoleId = "";
         Z36WWPSubscriptionSubscribed = false;
         Z32WWPNotificationDefinitionId = 0;
         Z1WWPUserExtendedId = "";
      }

      protected void InitAll0910( )
      {
         A34WWPSubscriptionId = 0;
         AssignAttri("", false, "A34WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A34WWPSubscriptionId), 10, 0));
         InitializeNonKey0910( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026730218411", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/subscriptions/wwp_subscription.js", "?2026730218411", false, true, false);
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
         edtWWPSubscriptionId_Internalname = "WWPSUBSCRIPTIONID";
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPNotificationDefinitionDescr_Internalname = "WWPNOTIFICATIONDEFINITIONDESCR";
         edtWWPEntityName_Internalname = "WWPENTITYNAME";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPSubscriptionEntityRecordId_Internalname = "WWPSUBSCRIPTIONENTITYRECORDID";
         edtWWPSubscriptionEntityRecordDes_Internalname = "WWPSUBSCRIPTIONENTITYRECORDDES";
         edtWWPSubscriptionRoleId_Internalname = "WWPSUBSCRIPTIONROLEID";
         chkWWPSubscriptionSubscribed_Internalname = "WWPSUBSCRIPTIONSUBSCRIBED";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_32_Internalname = "PROMPT_32";
         imgprompt_1_Internalname = "PROMPT_1";
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
         Form.Caption = context.GetMessage( "WWP_Subscription", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkWWPSubscriptionSubscribed.Enabled = 1;
         edtWWPSubscriptionRoleId_Jsonclick = "";
         edtWWPSubscriptionRoleId_Enabled = 1;
         edtWWPSubscriptionEntityRecordDes_Enabled = 1;
         edtWWPSubscriptionEntityRecordId_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 0;
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         edtWWPEntityName_Jsonclick = "";
         edtWWPEntityName_Enabled = 0;
         edtWWPNotificationDefinitionDescr_Enabled = 0;
         imgprompt_32_Visible = 1;
         imgprompt_32_Link = "";
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPNotificationDefinitionId_Enabled = 1;
         edtWWPSubscriptionId_Jsonclick = "";
         edtWWPSubscriptionId_Enabled = 1;
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
         chkWWPSubscriptionSubscribed.Name = "WWPSUBSCRIPTIONSUBSCRIBED";
         chkWWPSubscriptionSubscribed.WebTags = "";
         chkWWPSubscriptionSubscribed.Caption = context.GetMessage( "Subscribed", "");
         AssignProp("", false, chkWWPSubscriptionSubscribed_Internalname, "TitleCaption", chkWWPSubscriptionSubscribed.Caption, true);
         chkWWPSubscriptionSubscribed.CheckedValue = "false";
         A36WWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( A36WWPSubscriptionSubscribed));
         AssignAttri("", false, "A36WWPSubscriptionSubscribed", A36WWPSubscriptionSubscribed);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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

      public void Valid_Wwpsubscriptionid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A36WWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( A36WWPSubscriptionSubscribed));
         /*  Sending validation outputs */
         AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A32WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A1WWPUserExtendedId", StringUtil.RTrim( A1WWPUserExtendedId));
         AssignAttri("", false, "A35WWPSubscriptionEntityRecordId", A35WWPSubscriptionEntityRecordId);
         AssignAttri("", false, "A37WWPSubscriptionEntityRecordDes", A37WWPSubscriptionEntityRecordDes);
         AssignAttri("", false, "A28WWPSubscriptionRoleId", StringUtil.RTrim( A28WWPSubscriptionRoleId));
         AssignAttri("", false, "A36WWPSubscriptionSubscribed", A36WWPSubscriptionSubscribed);
         AssignAttri("", false, "A29WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A38WWPNotificationDefinitionDescr", A38WWPNotificationDefinitionDescr);
         AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z34WWPSubscriptionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34WWPSubscriptionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z32WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z32WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1WWPUserExtendedId", StringUtil.RTrim( Z1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z35WWPSubscriptionEntityRecordId", Z35WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, "Z37WWPSubscriptionEntityRecordDes", Z37WWPSubscriptionEntityRecordDes);
         GxWebStd.gx_hidden_field( context, "Z28WWPSubscriptionRoleId", StringUtil.RTrim( Z28WWPSubscriptionRoleId));
         GxWebStd.gx_hidden_field( context, "Z36WWPSubscriptionSubscribed", StringUtil.BoolToStr( Z36WWPSubscriptionSubscribed));
         GxWebStd.gx_hidden_field( context, "Z29WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29WWPEntityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z38WWPNotificationDefinitionDescr", Z38WWPNotificationDefinitionDescr);
         GxWebStd.gx_hidden_field( context, "Z30WWPEntityName", Z30WWPEntityName);
         GxWebStd.gx_hidden_field( context, "Z2WWPUserExtendedFullName", Z2WWPUserExtendedFullName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationdefinitionid( )
      {
         /* Using cursor T000917 */
         pr_default.execute(15, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         }
         A29WWPEntityId = T000917_A29WWPEntityId[0];
         A38WWPNotificationDefinitionDescr = T000917_A38WWPNotificationDefinitionDescr[0];
         pr_default.close(15);
         /* Using cursor T000918 */
         pr_default.execute(16, new Object[] {A29WWPEntityId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A30WWPEntityName = T000918_A30WWPEntityName[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A29WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A38WWPNotificationDefinitionDescr", A38WWPNotificationDefinitionDescr);
         AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
      }

      public void Valid_Wwpuserextendedid( )
      {
         n1WWPUserExtendedId = false;
         /* Using cursor T000919 */
         pr_default.execute(17, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
            }
         }
         A2WWPUserExtendedFullName = T000919_A2WWPUserExtendedFullName[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A36WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:'',type:'boolean'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A36WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:'',type:'boolean'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A36WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A36WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPSUBSCRIPTIONID","{handler:'Valid_Wwpsubscriptionid',iparms:[{av:'A34WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'A36WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPSUBSCRIPTIONID",",oparms:[{av:'A32WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:'',type:'char'},{av:'A35WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:'',type:'svchar'},{av:'A37WWPSubscriptionEntityRecordDes',fld:'WWPSUBSCRIPTIONENTITYRECORDDES',pic:'',type:'svchar'},{av:'A28WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:'',type:'char'},{av:'A29WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A38WWPNotificationDefinitionDescr',fld:'WWPNOTIFICATIONDEFINITIONDESCR',pic:'',type:'svchar'},{av:'A30WWPEntityName',fld:'WWPENTITYNAME',pic:'',type:'svchar'},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:'',type:'svchar'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z34WWPSubscriptionId',type:'int'},{av:'Z32WWPNotificationDefinitionId',type:'int'},{av:'Z1WWPUserExtendedId',type:'char'},{av:'Z35WWPSubscriptionEntityRecordId',type:'svchar'},{av:'Z37WWPSubscriptionEntityRecordDes',type:'svchar'},{av:'Z28WWPSubscriptionRoleId',type:'char'},{av:'Z36WWPSubscriptionSubscribed',type:'boolean'},{av:'Z29WWPEntityId',type:'int'},{av:'Z38WWPNotificationDefinitionDescr',type:'svchar'},{av:'Z30WWPEntityName',type:'svchar'},{av:'Z2WWPUserExtendedFullName',type:'svchar'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A36WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID","{handler:'Valid_Wwpnotificationdefinitionid',iparms:[{av:'A32WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A29WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A38WWPNotificationDefinitionDescr',fld:'WWPNOTIFICATIONDEFINITIONDESCR',pic:'',type:'svchar'},{av:'A30WWPEntityName',fld:'WWPENTITYNAME',pic:'',type:'svchar'},{av:'A36WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID",",oparms:[{av:'A29WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A38WWPNotificationDefinitionDescr',fld:'WWPNOTIFICATIONDEFINITIONDESCR',pic:'',type:'svchar'},{av:'A30WWPEntityName',fld:'WWPENTITYNAME',pic:'',type:'svchar'},{av:'A36WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","{handler:'Valid_Wwpuserextendedid',iparms:[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:'',type:'char'},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:'',type:'svchar'},{av:'A36WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",",oparms:[{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:'',type:'svchar'},{av:'A36WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:'',type:'boolean'}]}");
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
         pr_default.close(17);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z35WWPSubscriptionEntityRecordId = "";
         Z37WWPSubscriptionEntityRecordDes = "";
         Z28WWPSubscriptionRoleId = "";
         Z1WWPUserExtendedId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         imgprompt_32_gximage = "";
         sImgUrl = "";
         A38WWPNotificationDefinitionDescr = "";
         A30WWPEntityName = "";
         imgprompt_1_gximage = "";
         A2WWPUserExtendedFullName = "";
         A35WWPSubscriptionEntityRecordId = "";
         A37WWPSubscriptionEntityRecordDes = "";
         A28WWPSubscriptionRoleId = "";
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
         Z38WWPNotificationDefinitionDescr = "";
         Z30WWPEntityName = "";
         Z2WWPUserExtendedFullName = "";
         T00097_A29WWPEntityId = new long[1] ;
         T00097_A34WWPSubscriptionId = new long[1] ;
         T00097_A38WWPNotificationDefinitionDescr = new string[] {""} ;
         T00097_A30WWPEntityName = new string[] {""} ;
         T00097_A2WWPUserExtendedFullName = new string[] {""} ;
         T00097_A35WWPSubscriptionEntityRecordId = new string[] {""} ;
         T00097_A37WWPSubscriptionEntityRecordDes = new string[] {""} ;
         T00097_A28WWPSubscriptionRoleId = new string[] {""} ;
         T00097_n28WWPSubscriptionRoleId = new bool[] {false} ;
         T00097_A36WWPSubscriptionSubscribed = new bool[] {false} ;
         T00097_A32WWPNotificationDefinitionId = new long[1] ;
         T00097_A1WWPUserExtendedId = new string[] {""} ;
         T00097_n1WWPUserExtendedId = new bool[] {false} ;
         T00094_A29WWPEntityId = new long[1] ;
         T00094_A38WWPNotificationDefinitionDescr = new string[] {""} ;
         T00096_A30WWPEntityName = new string[] {""} ;
         T00095_A2WWPUserExtendedFullName = new string[] {""} ;
         T00098_A29WWPEntityId = new long[1] ;
         T00098_A38WWPNotificationDefinitionDescr = new string[] {""} ;
         T00099_A30WWPEntityName = new string[] {""} ;
         T000910_A2WWPUserExtendedFullName = new string[] {""} ;
         T000911_A34WWPSubscriptionId = new long[1] ;
         T00093_A34WWPSubscriptionId = new long[1] ;
         T00093_A35WWPSubscriptionEntityRecordId = new string[] {""} ;
         T00093_A37WWPSubscriptionEntityRecordDes = new string[] {""} ;
         T00093_A28WWPSubscriptionRoleId = new string[] {""} ;
         T00093_n28WWPSubscriptionRoleId = new bool[] {false} ;
         T00093_A36WWPSubscriptionSubscribed = new bool[] {false} ;
         T00093_A32WWPNotificationDefinitionId = new long[1] ;
         T00093_A1WWPUserExtendedId = new string[] {""} ;
         T00093_n1WWPUserExtendedId = new bool[] {false} ;
         sMode10 = "";
         T000912_A34WWPSubscriptionId = new long[1] ;
         T000913_A34WWPSubscriptionId = new long[1] ;
         T00092_A34WWPSubscriptionId = new long[1] ;
         T00092_A35WWPSubscriptionEntityRecordId = new string[] {""} ;
         T00092_A37WWPSubscriptionEntityRecordDes = new string[] {""} ;
         T00092_A28WWPSubscriptionRoleId = new string[] {""} ;
         T00092_n28WWPSubscriptionRoleId = new bool[] {false} ;
         T00092_A36WWPSubscriptionSubscribed = new bool[] {false} ;
         T00092_A32WWPNotificationDefinitionId = new long[1] ;
         T00092_A1WWPUserExtendedId = new string[] {""} ;
         T00092_n1WWPUserExtendedId = new bool[] {false} ;
         T000914_A34WWPSubscriptionId = new long[1] ;
         T000917_A29WWPEntityId = new long[1] ;
         T000917_A38WWPNotificationDefinitionDescr = new string[] {""} ;
         T000918_A30WWPEntityName = new string[] {""} ;
         T000919_A2WWPUserExtendedFullName = new string[] {""} ;
         T000920_A34WWPSubscriptionId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1WWPUserExtendedId = "";
         ZZ35WWPSubscriptionEntityRecordId = "";
         ZZ37WWPSubscriptionEntityRecordDes = "";
         ZZ28WWPSubscriptionRoleId = "";
         ZZ38WWPNotificationDefinitionDescr = "";
         ZZ30WWPEntityName = "";
         ZZ2WWPUserExtendedFullName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription__default(),
            new Object[][] {
                new Object[] {
               T00092_A34WWPSubscriptionId, T00092_A35WWPSubscriptionEntityRecordId, T00092_A37WWPSubscriptionEntityRecordDes, T00092_A28WWPSubscriptionRoleId, T00092_n28WWPSubscriptionRoleId, T00092_A36WWPSubscriptionSubscribed, T00092_A32WWPNotificationDefinitionId, T00092_A1WWPUserExtendedId, T00092_n1WWPUserExtendedId
               }
               , new Object[] {
               T00093_A34WWPSubscriptionId, T00093_A35WWPSubscriptionEntityRecordId, T00093_A37WWPSubscriptionEntityRecordDes, T00093_A28WWPSubscriptionRoleId, T00093_n28WWPSubscriptionRoleId, T00093_A36WWPSubscriptionSubscribed, T00093_A32WWPNotificationDefinitionId, T00093_A1WWPUserExtendedId, T00093_n1WWPUserExtendedId
               }
               , new Object[] {
               T00094_A29WWPEntityId, T00094_A38WWPNotificationDefinitionDescr
               }
               , new Object[] {
               T00095_A2WWPUserExtendedFullName
               }
               , new Object[] {
               T00096_A30WWPEntityName
               }
               , new Object[] {
               T00097_A29WWPEntityId, T00097_A34WWPSubscriptionId, T00097_A38WWPNotificationDefinitionDescr, T00097_A30WWPEntityName, T00097_A2WWPUserExtendedFullName, T00097_A35WWPSubscriptionEntityRecordId, T00097_A37WWPSubscriptionEntityRecordDes, T00097_A28WWPSubscriptionRoleId, T00097_n28WWPSubscriptionRoleId, T00097_A36WWPSubscriptionSubscribed,
               T00097_A32WWPNotificationDefinitionId, T00097_A1WWPUserExtendedId, T00097_n1WWPUserExtendedId
               }
               , new Object[] {
               T00098_A29WWPEntityId, T00098_A38WWPNotificationDefinitionDescr
               }
               , new Object[] {
               T00099_A30WWPEntityName
               }
               , new Object[] {
               T000910_A2WWPUserExtendedFullName
               }
               , new Object[] {
               T000911_A34WWPSubscriptionId
               }
               , new Object[] {
               T000912_A34WWPSubscriptionId
               }
               , new Object[] {
               T000913_A34WWPSubscriptionId
               }
               , new Object[] {
               T000914_A34WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000917_A29WWPEntityId, T000917_A38WWPNotificationDefinitionDescr
               }
               , new Object[] {
               T000918_A30WWPEntityName
               }
               , new Object[] {
               T000919_A2WWPUserExtendedFullName
               }
               , new Object[] {
               T000920_A34WWPSubscriptionId
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound10 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPSubscriptionId_Enabled ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int imgprompt_32_Visible ;
      private int edtWWPNotificationDefinitionDescr_Enabled ;
      private int edtWWPEntityName_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int imgprompt_1_Visible ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPSubscriptionEntityRecordId_Enabled ;
      private int edtWWPSubscriptionEntityRecordDes_Enabled ;
      private int edtWWPSubscriptionRoleId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z34WWPSubscriptionId ;
      private long Z32WWPNotificationDefinitionId ;
      private long A32WWPNotificationDefinitionId ;
      private long A29WWPEntityId ;
      private long A34WWPSubscriptionId ;
      private long Z29WWPEntityId ;
      private long ZZ34WWPSubscriptionId ;
      private long ZZ32WWPNotificationDefinitionId ;
      private long ZZ29WWPEntityId ;
      private string sPrefix ;
      private string Z28WWPSubscriptionRoleId ;
      private string Z1WWPUserExtendedId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A1WWPUserExtendedId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPSubscriptionId_Internalname ;
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
      private string edtWWPSubscriptionId_Jsonclick ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string imgprompt_32_gximage ;
      private string sImgUrl ;
      private string imgprompt_32_Internalname ;
      private string imgprompt_32_Link ;
      private string edtWWPNotificationDefinitionDescr_Internalname ;
      private string edtWWPEntityName_Internalname ;
      private string edtWWPEntityName_Jsonclick ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string imgprompt_1_gximage ;
      private string imgprompt_1_Internalname ;
      private string imgprompt_1_Link ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPSubscriptionEntityRecordId_Internalname ;
      private string edtWWPSubscriptionEntityRecordDes_Internalname ;
      private string edtWWPSubscriptionRoleId_Internalname ;
      private string A28WWPSubscriptionRoleId ;
      private string edtWWPSubscriptionRoleId_Jsonclick ;
      private string chkWWPSubscriptionSubscribed_Internalname ;
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
      private string sMode10 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1WWPUserExtendedId ;
      private string ZZ28WWPSubscriptionRoleId ;
      private bool Z36WWPSubscriptionSubscribed ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1WWPUserExtendedId ;
      private bool wbErr ;
      private bool A36WWPSubscriptionSubscribed ;
      private bool n28WWPSubscriptionRoleId ;
      private bool Gx_longc ;
      private bool ZZ36WWPSubscriptionSubscribed ;
      private string Z35WWPSubscriptionEntityRecordId ;
      private string Z37WWPSubscriptionEntityRecordDes ;
      private string A38WWPNotificationDefinitionDescr ;
      private string A30WWPEntityName ;
      private string A2WWPUserExtendedFullName ;
      private string A35WWPSubscriptionEntityRecordId ;
      private string A37WWPSubscriptionEntityRecordDes ;
      private string Z38WWPNotificationDefinitionDescr ;
      private string Z30WWPEntityName ;
      private string Z2WWPUserExtendedFullName ;
      private string ZZ35WWPSubscriptionEntityRecordId ;
      private string ZZ37WWPSubscriptionEntityRecordDes ;
      private string ZZ38WWPNotificationDefinitionDescr ;
      private string ZZ30WWPEntityName ;
      private string ZZ2WWPUserExtendedFullName ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPSubscriptionSubscribed ;
      private IDataStoreProvider pr_default ;
      private long[] T00097_A29WWPEntityId ;
      private long[] T00097_A34WWPSubscriptionId ;
      private string[] T00097_A38WWPNotificationDefinitionDescr ;
      private string[] T00097_A30WWPEntityName ;
      private string[] T00097_A2WWPUserExtendedFullName ;
      private string[] T00097_A35WWPSubscriptionEntityRecordId ;
      private string[] T00097_A37WWPSubscriptionEntityRecordDes ;
      private string[] T00097_A28WWPSubscriptionRoleId ;
      private bool[] T00097_n28WWPSubscriptionRoleId ;
      private bool[] T00097_A36WWPSubscriptionSubscribed ;
      private long[] T00097_A32WWPNotificationDefinitionId ;
      private string[] T00097_A1WWPUserExtendedId ;
      private bool[] T00097_n1WWPUserExtendedId ;
      private long[] T00094_A29WWPEntityId ;
      private string[] T00094_A38WWPNotificationDefinitionDescr ;
      private string[] T00096_A30WWPEntityName ;
      private string[] T00095_A2WWPUserExtendedFullName ;
      private long[] T00098_A29WWPEntityId ;
      private string[] T00098_A38WWPNotificationDefinitionDescr ;
      private string[] T00099_A30WWPEntityName ;
      private string[] T000910_A2WWPUserExtendedFullName ;
      private long[] T000911_A34WWPSubscriptionId ;
      private long[] T00093_A34WWPSubscriptionId ;
      private string[] T00093_A35WWPSubscriptionEntityRecordId ;
      private string[] T00093_A37WWPSubscriptionEntityRecordDes ;
      private string[] T00093_A28WWPSubscriptionRoleId ;
      private bool[] T00093_n28WWPSubscriptionRoleId ;
      private bool[] T00093_A36WWPSubscriptionSubscribed ;
      private long[] T00093_A32WWPNotificationDefinitionId ;
      private string[] T00093_A1WWPUserExtendedId ;
      private bool[] T00093_n1WWPUserExtendedId ;
      private long[] T000912_A34WWPSubscriptionId ;
      private long[] T000913_A34WWPSubscriptionId ;
      private long[] T00092_A34WWPSubscriptionId ;
      private string[] T00092_A35WWPSubscriptionEntityRecordId ;
      private string[] T00092_A37WWPSubscriptionEntityRecordDes ;
      private string[] T00092_A28WWPSubscriptionRoleId ;
      private bool[] T00092_n28WWPSubscriptionRoleId ;
      private bool[] T00092_A36WWPSubscriptionSubscribed ;
      private long[] T00092_A32WWPNotificationDefinitionId ;
      private string[] T00092_A1WWPUserExtendedId ;
      private bool[] T00092_n1WWPUserExtendedId ;
      private long[] T000914_A34WWPSubscriptionId ;
      private long[] T000917_A29WWPEntityId ;
      private string[] T000917_A38WWPNotificationDefinitionDescr ;
      private string[] T000918_A30WWPEntityName ;
      private string[] T000919_A2WWPUserExtendedFullName ;
      private long[] T000920_A34WWPSubscriptionId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_subscription__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscription__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00092;
        prmT00092 = new Object[] {
        new ParDef("@WWPSubscriptionId",GXType.Decimal,10,0)
        };
        Object[] prmT00093;
        prmT00093 = new Object[] {
        new ParDef("@WWPSubscriptionId",GXType.Decimal,10,0)
        };
        Object[] prmT00094;
        prmT00094 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT00095;
        prmT00095 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmT00096;
        prmT00096 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmT00097;
        prmT00097 = new Object[] {
        new ParDef("@WWPSubscriptionId",GXType.Decimal,10,0)
        };
        Object[] prmT00098;
        prmT00098 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT00099;
        prmT00099 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmT000910;
        prmT000910 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmT000911;
        prmT000911 = new Object[] {
        new ParDef("@WWPSubscriptionId",GXType.Decimal,10,0)
        };
        Object[] prmT000912;
        prmT000912 = new Object[] {
        new ParDef("@WWPSubscriptionId",GXType.Decimal,10,0)
        };
        Object[] prmT000913;
        prmT000913 = new Object[] {
        new ParDef("@WWPSubscriptionId",GXType.Decimal,10,0)
        };
        Object[] prmT000914;
        prmT000914 = new Object[] {
        new ParDef("@WWPSubscriptionEntityRecordId",GXType.NVarChar,2000,0) ,
        new ParDef("@WWPSubscriptionEntityRecordDes",GXType.NVarChar,200,0) ,
        new ParDef("@WWPSubscriptionRoleId",GXType.NChar,40,0){Nullable=true} ,
        new ParDef("@WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0) ,
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmT000915;
        prmT000915 = new Object[] {
        new ParDef("@WWPSubscriptionEntityRecordId",GXType.NVarChar,2000,0) ,
        new ParDef("@WWPSubscriptionEntityRecordDes",GXType.NVarChar,200,0) ,
        new ParDef("@WWPSubscriptionRoleId",GXType.NChar,40,0){Nullable=true} ,
        new ParDef("@WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0) ,
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true} ,
        new ParDef("@WWPSubscriptionId",GXType.Decimal,10,0)
        };
        Object[] prmT000916;
        prmT000916 = new Object[] {
        new ParDef("@WWPSubscriptionId",GXType.Decimal,10,0)
        };
        Object[] prmT000917;
        prmT000917 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000918;
        prmT000918 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmT000919;
        prmT000919 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmT000920;
        prmT000920 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00092", "SELECT [WWPSubscriptionId], [WWPSubscriptionEntityRecordId], [WWPSubscriptionEntityRecordDes], [WWPSubscriptionRoleId], [WWPSubscriptionSubscribed], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Subscription] WITH (UPDLOCK) WHERE [WWPSubscriptionId] = @WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00093", "SELECT [WWPSubscriptionId], [WWPSubscriptionEntityRecordId], [WWPSubscriptionEntityRecordDes], [WWPSubscriptionRoleId], [WWPSubscriptionSubscribed], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Subscription] WHERE [WWPSubscriptionId] = @WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00094", "SELECT [WWPEntityId], [WWPNotificationDefinitionDescr] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00095", "SELECT [WWPUserExtendedFullName] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00096", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00097", "SELECT T2.[WWPEntityId], TM1.[WWPSubscriptionId], T2.[WWPNotificationDefinitionDescr], T3.[WWPEntityName], T4.[WWPUserExtendedFullName], TM1.[WWPSubscriptionEntityRecordId], TM1.[WWPSubscriptionEntityRecordDes], TM1.[WWPSubscriptionRoleId], TM1.[WWPSubscriptionSubscribed], TM1.[WWPNotificationDefinitionId], TM1.[WWPUserExtendedId] FROM ((([WWP_Subscription] TM1 INNER JOIN [WWP_NotificationDefinition] T2 ON T2.[WWPNotificationDefinitionId] = TM1.[WWPNotificationDefinitionId]) INNER JOIN [WWP_Entity] T3 ON T3.[WWPEntityId] = T2.[WWPEntityId]) LEFT JOIN [WWP_UserExtended] T4 ON T4.[WWPUserExtendedId] = TM1.[WWPUserExtendedId]) WHERE TM1.[WWPSubscriptionId] = @WWPSubscriptionId ORDER BY TM1.[WWPSubscriptionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00098", "SELECT [WWPEntityId], [WWPNotificationDefinitionDescr] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00098,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00099", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000910", "SELECT [WWPUserExtendedFullName] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000910,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000911", "SELECT [WWPSubscriptionId] FROM [WWP_Subscription] WHERE [WWPSubscriptionId] = @WWPSubscriptionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000911,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000912", "SELECT TOP 1 [WWPSubscriptionId] FROM [WWP_Subscription] WHERE ( [WWPSubscriptionId] > @WWPSubscriptionId) ORDER BY [WWPSubscriptionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000912,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000913", "SELECT TOP 1 [WWPSubscriptionId] FROM [WWP_Subscription] WHERE ( [WWPSubscriptionId] < @WWPSubscriptionId) ORDER BY [WWPSubscriptionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000913,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000914", "INSERT INTO [WWP_Subscription]([WWPSubscriptionEntityRecordId], [WWPSubscriptionEntityRecordDes], [WWPSubscriptionRoleId], [WWPSubscriptionSubscribed], [WWPNotificationDefinitionId], [WWPUserExtendedId]) VALUES(@WWPSubscriptionEntityRecordId, @WWPSubscriptionEntityRecordDes, @WWPSubscriptionRoleId, @WWPSubscriptionSubscribed, @WWPNotificationDefinitionId, @WWPUserExtendedId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000914,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000915", "UPDATE [WWP_Subscription] SET [WWPSubscriptionEntityRecordId]=@WWPSubscriptionEntityRecordId, [WWPSubscriptionEntityRecordDes]=@WWPSubscriptionEntityRecordDes, [WWPSubscriptionRoleId]=@WWPSubscriptionRoleId, [WWPSubscriptionSubscribed]=@WWPSubscriptionSubscribed, [WWPNotificationDefinitionId]=@WWPNotificationDefinitionId, [WWPUserExtendedId]=@WWPUserExtendedId  WHERE [WWPSubscriptionId] = @WWPSubscriptionId", GxErrorMask.GX_NOMASK,prmT000915)
           ,new CursorDef("T000916", "DELETE FROM [WWP_Subscription]  WHERE [WWPSubscriptionId] = @WWPSubscriptionId", GxErrorMask.GX_NOMASK,prmT000916)
           ,new CursorDef("T000917", "SELECT [WWPEntityId], [WWPNotificationDefinitionDescr] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000917,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000918", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000918,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000919", "SELECT [WWPUserExtendedFullName] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000919,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000920", "SELECT [WWPSubscriptionId] FROM [WWP_Subscription] ORDER BY [WWPSubscriptionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000920,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((bool[]) buf[9])[0] = rslt.getBool(9);
              ((long[]) buf[10])[0] = rslt.getLong(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 40);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
