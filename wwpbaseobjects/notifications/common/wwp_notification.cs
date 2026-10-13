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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_notification : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A32WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A32WWPNotificationDefinitionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
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
            gxLoad_7( A1WWPUserExtendedId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Notification", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_notification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notification( IGxContext context )
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
         chkWWPNotificationIsRead = new GXCheckbox();
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
         A91WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A91WWPNotificationIsRead));
         AssignAttri("", false, "A91WWPNotificationIsRead", A91WWPNotificationIsRead);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Notification", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"wwpbaseobjects.notifications.common.gx00f0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPNOTIFICATIONID"+"'), id:'"+"WWPNOTIFICATIONID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A31WWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A31WWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A32WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPNotificationDefinitionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A32WWPNotificationDefinitionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A32WWPNotificationDefinitionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_32_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_32_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_32_Internalname, sImgUrl, imgprompt_32_Link, "", "", context.GetTheme( ), imgprompt_32_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionName_Internalname, context.GetMessage( "Notification Definition Internal Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionName_Internalname, A68WWPNotificationDefinitionName, StringUtil.RTrim( context.localUtil.Format( A68WWPNotificationDefinitionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationCreated_Internalname, context.GetMessage( "Created Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A33WWPNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationIcon_Internalname, context.GetMessage( "Icon", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationIcon_Internalname, A85WWPNotificationIcon, StringUtil.RTrim( context.localUtil.Format( A85WWPNotificationIcon, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationIcon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationIcon_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationTitle_Internalname, context.GetMessage( "Title", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationTitle_Internalname, A86WWPNotificationTitle, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtWWPNotificationTitle_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationShortDescriptio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationShortDescriptio_Internalname, context.GetMessage( "Short Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationShortDescriptio_Internalname, A87WWPNotificationShortDescriptio, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtWWPNotificationShortDescriptio_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationLink_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationLink_Internalname, context.GetMessage( "Link", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationLink_Internalname, A88WWPNotificationLink, StringUtil.RTrim( context.localUtil.Format( A88WWPNotificationLink, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", A88WWPNotificationLink, "_blank", "", "", edtWWPNotificationLink_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationLink_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPNotificationIsRead_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPNotificationIsRead_Internalname, context.GetMessage( "Is Read", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPNotificationIsRead_Internalname, StringUtil.BoolToStr( A91WWPNotificationIsRead), "", context.GetMessage( "Is Read", ""), 1, chkWWPNotificationIsRead.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(74, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,74);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A1WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A1WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_1_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_1_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A2WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A2WWPUserExtendedFullName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationMetadata_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationMetadata_Internalname, context.GetMessage( "Metadata", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationMetadata_Internalname, A69WWPNotificationMetadata, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", 0, 1, edtWWPNotificationMetadata_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
            Z31WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z31WWPNotificationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z33WWPNotificationCreated = context.localUtil.CToT( cgiGet( "Z33WWPNotificationCreated"), 0);
            Z85WWPNotificationIcon = cgiGet( "Z85WWPNotificationIcon");
            Z86WWPNotificationTitle = cgiGet( "Z86WWPNotificationTitle");
            Z87WWPNotificationShortDescriptio = cgiGet( "Z87WWPNotificationShortDescriptio");
            Z88WWPNotificationLink = cgiGet( "Z88WWPNotificationLink");
            Z91WWPNotificationIsRead = StringUtil.StrToBool( cgiGet( "Z91WWPNotificationIsRead"));
            Z32WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z32WWPNotificationDefinitionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z1WWPUserExtendedId = cgiGet( "Z1WWPUserExtendedId");
            n1WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A31WWPNotificationId = 0;
               n31WWPNotificationId = false;
               AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
            }
            else
            {
               A31WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n31WWPNotificationId = false;
               AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
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
            A68WWPNotificationDefinitionName = cgiGet( edtWWPNotificationDefinitionName_Internalname);
            AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPNotificationCreated_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Notification Created Date", "")}), 1, "WWPNOTIFICATIONCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A33WWPNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPNotificationCreated_Internalname));
               AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A85WWPNotificationIcon = cgiGet( edtWWPNotificationIcon_Internalname);
            AssignAttri("", false, "A85WWPNotificationIcon", A85WWPNotificationIcon);
            A86WWPNotificationTitle = cgiGet( edtWWPNotificationTitle_Internalname);
            AssignAttri("", false, "A86WWPNotificationTitle", A86WWPNotificationTitle);
            A87WWPNotificationShortDescriptio = cgiGet( edtWWPNotificationShortDescriptio_Internalname);
            AssignAttri("", false, "A87WWPNotificationShortDescriptio", A87WWPNotificationShortDescriptio);
            A88WWPNotificationLink = cgiGet( edtWWPNotificationLink_Internalname);
            AssignAttri("", false, "A88WWPNotificationLink", A88WWPNotificationLink);
            A91WWPNotificationIsRead = StringUtil.StrToBool( cgiGet( chkWWPNotificationIsRead_Internalname));
            AssignAttri("", false, "A91WWPNotificationIsRead", A91WWPNotificationIsRead);
            A1WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n1WWPUserExtendedId = false;
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            n1WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ? true : false);
            A2WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
            A69WWPNotificationMetadata = cgiGet( edtWWPNotificationMetadata_Internalname);
            n69WWPNotificationMetadata = false;
            AssignAttri("", false, "A69WWPNotificationMetadata", A69WWPNotificationMetadata);
            n69WWPNotificationMetadata = (String.IsNullOrEmpty(StringUtil.RTrim( A69WWPNotificationMetadata)) ? true : false);
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
               A31WWPNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationId"), "."), 18, MidpointRounding.ToEven));
               n31WWPNotificationId = false;
               AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
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
               InitAll0E15( ) ;
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
         DisableAttributes0E15( ) ;
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

      protected void ResetCaption0E0( )
      {
      }

      protected void ZM0E15( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z33WWPNotificationCreated = T000E3_A33WWPNotificationCreated[0];
               Z85WWPNotificationIcon = T000E3_A85WWPNotificationIcon[0];
               Z86WWPNotificationTitle = T000E3_A86WWPNotificationTitle[0];
               Z87WWPNotificationShortDescriptio = T000E3_A87WWPNotificationShortDescriptio[0];
               Z88WWPNotificationLink = T000E3_A88WWPNotificationLink[0];
               Z91WWPNotificationIsRead = T000E3_A91WWPNotificationIsRead[0];
               Z32WWPNotificationDefinitionId = T000E3_A32WWPNotificationDefinitionId[0];
               Z1WWPUserExtendedId = T000E3_A1WWPUserExtendedId[0];
            }
            else
            {
               Z33WWPNotificationCreated = A33WWPNotificationCreated;
               Z85WWPNotificationIcon = A85WWPNotificationIcon;
               Z86WWPNotificationTitle = A86WWPNotificationTitle;
               Z87WWPNotificationShortDescriptio = A87WWPNotificationShortDescriptio;
               Z88WWPNotificationLink = A88WWPNotificationLink;
               Z91WWPNotificationIsRead = A91WWPNotificationIsRead;
               Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
               Z1WWPUserExtendedId = A1WWPUserExtendedId;
            }
         }
         if ( GX_JID == -5 )
         {
            Z31WWPNotificationId = A31WWPNotificationId;
            Z33WWPNotificationCreated = A33WWPNotificationCreated;
            Z85WWPNotificationIcon = A85WWPNotificationIcon;
            Z86WWPNotificationTitle = A86WWPNotificationTitle;
            Z87WWPNotificationShortDescriptio = A87WWPNotificationShortDescriptio;
            Z88WWPNotificationLink = A88WWPNotificationLink;
            Z91WWPNotificationIsRead = A91WWPNotificationIsRead;
            Z69WWPNotificationMetadata = A69WWPNotificationMetadata;
            Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z68WWPNotificationDefinitionName = A68WWPNotificationDefinitionName;
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_32_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.notifications.common.gx00e0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPNOTIFICATIONDEFINITIONID"+"'), id:'"+"WWPNOTIFICATIONDEFINITIONID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPUSEREXTENDEDID"+"'), id:'"+"WWPUSEREXTENDEDID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A33WWPNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A33WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
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
         }
      }

      protected void Load0E15( )
      {
         /* Using cursor T000E6 */
         pr_default.execute(4, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound15 = 1;
            A68WWPNotificationDefinitionName = T000E6_A68WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
            A33WWPNotificationCreated = T000E6_A33WWPNotificationCreated[0];
            AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A85WWPNotificationIcon = T000E6_A85WWPNotificationIcon[0];
            AssignAttri("", false, "A85WWPNotificationIcon", A85WWPNotificationIcon);
            A86WWPNotificationTitle = T000E6_A86WWPNotificationTitle[0];
            AssignAttri("", false, "A86WWPNotificationTitle", A86WWPNotificationTitle);
            A87WWPNotificationShortDescriptio = T000E6_A87WWPNotificationShortDescriptio[0];
            AssignAttri("", false, "A87WWPNotificationShortDescriptio", A87WWPNotificationShortDescriptio);
            A88WWPNotificationLink = T000E6_A88WWPNotificationLink[0];
            AssignAttri("", false, "A88WWPNotificationLink", A88WWPNotificationLink);
            A91WWPNotificationIsRead = T000E6_A91WWPNotificationIsRead[0];
            AssignAttri("", false, "A91WWPNotificationIsRead", A91WWPNotificationIsRead);
            A2WWPUserExtendedFullName = T000E6_A2WWPUserExtendedFullName[0];
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
            A69WWPNotificationMetadata = T000E6_A69WWPNotificationMetadata[0];
            n69WWPNotificationMetadata = T000E6_n69WWPNotificationMetadata[0];
            AssignAttri("", false, "A69WWPNotificationMetadata", A69WWPNotificationMetadata);
            A32WWPNotificationDefinitionId = T000E6_A32WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
            A1WWPUserExtendedId = T000E6_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = T000E6_n1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            ZM0E15( -5) ;
         }
         pr_default.close(4);
         OnLoadActions0E15( ) ;
      }

      protected void OnLoadActions0E15( )
      {
      }

      protected void CheckExtendedTable0E15( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000E4 */
         pr_default.execute(2, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A68WWPNotificationDefinitionName = T000E4_A68WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A33WWPNotificationCreated) || ( A33WWPNotificationCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Notification Created Date", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPNOTIFICATIONCREATED");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationCreated_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A88WWPNotificationLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Notification Link", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPNOTIFICATIONLINK");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationLink_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000E5 */
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
         A2WWPUserExtendedFullName = T000E5_A2WWPUserExtendedFullName[0];
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0E15( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( long A32WWPNotificationDefinitionId )
      {
         /* Using cursor T000E7 */
         pr_default.execute(5, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A68WWPNotificationDefinitionName = T000E7_A68WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A68WWPNotificationDefinitionName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_7( string A1WWPUserExtendedId )
      {
         /* Using cursor T000E8 */
         pr_default.execute(6, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A2WWPUserExtendedFullName = T000E8_A2WWPUserExtendedFullName[0];
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2WWPUserExtendedFullName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0E15( )
      {
         /* Using cursor T000E9 */
         pr_default.execute(7, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000E3 */
         pr_default.execute(1, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E15( 5) ;
            RcdFound15 = 1;
            A31WWPNotificationId = T000E3_A31WWPNotificationId[0];
            n31WWPNotificationId = T000E3_n31WWPNotificationId[0];
            AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
            A33WWPNotificationCreated = T000E3_A33WWPNotificationCreated[0];
            AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A85WWPNotificationIcon = T000E3_A85WWPNotificationIcon[0];
            AssignAttri("", false, "A85WWPNotificationIcon", A85WWPNotificationIcon);
            A86WWPNotificationTitle = T000E3_A86WWPNotificationTitle[0];
            AssignAttri("", false, "A86WWPNotificationTitle", A86WWPNotificationTitle);
            A87WWPNotificationShortDescriptio = T000E3_A87WWPNotificationShortDescriptio[0];
            AssignAttri("", false, "A87WWPNotificationShortDescriptio", A87WWPNotificationShortDescriptio);
            A88WWPNotificationLink = T000E3_A88WWPNotificationLink[0];
            AssignAttri("", false, "A88WWPNotificationLink", A88WWPNotificationLink);
            A91WWPNotificationIsRead = T000E3_A91WWPNotificationIsRead[0];
            AssignAttri("", false, "A91WWPNotificationIsRead", A91WWPNotificationIsRead);
            A69WWPNotificationMetadata = T000E3_A69WWPNotificationMetadata[0];
            n69WWPNotificationMetadata = T000E3_n69WWPNotificationMetadata[0];
            AssignAttri("", false, "A69WWPNotificationMetadata", A69WWPNotificationMetadata);
            A32WWPNotificationDefinitionId = T000E3_A32WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
            A1WWPUserExtendedId = T000E3_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = T000E3_n1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            Z31WWPNotificationId = A31WWPNotificationId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0E15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0E15( ) ;
            }
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0E15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E15( ) ;
         if ( RcdFound15 == 0 )
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
         RcdFound15 = 0;
         /* Using cursor T000E10 */
         pr_default.execute(8, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000E10_A31WWPNotificationId[0] < A31WWPNotificationId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000E10_A31WWPNotificationId[0] > A31WWPNotificationId ) ) )
            {
               A31WWPNotificationId = T000E10_A31WWPNotificationId[0];
               n31WWPNotificationId = T000E10_n31WWPNotificationId[0];
               AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound15 = 0;
         /* Using cursor T000E11 */
         pr_default.execute(9, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000E11_A31WWPNotificationId[0] > A31WWPNotificationId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000E11_A31WWPNotificationId[0] < A31WWPNotificationId ) ) )
            {
               A31WWPNotificationId = T000E11_A31WWPNotificationId[0];
               n31WWPNotificationId = T000E11_n31WWPNotificationId[0];
               AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0E15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0E15( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A31WWPNotificationId != Z31WWPNotificationId )
               {
                  A31WWPNotificationId = Z31WWPNotificationId;
                  n31WWPNotificationId = false;
                  AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPNOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0E15( ) ;
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A31WWPNotificationId != Z31WWPNotificationId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0E15( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPNOTIFICATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0E15( ) ;
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
         if ( A31WWPNotificationId != Z31WWPNotificationId )
         {
            A31WWPNotificationId = Z31WWPNotificationId;
            n31WWPNotificationId = false;
            AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPNotificationId_Internalname;
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
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationId_Internalname;
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
         ScanStart0E15( ) ;
         if ( RcdFound15 == 0 )
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
         ScanEnd0E15( ) ;
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
         if ( RcdFound15 == 0 )
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
         if ( RcdFound15 == 0 )
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
         ScanStart0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound15 != 0 )
            {
               ScanNext0E15( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0E15( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0E15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000E2 */
            pr_default.execute(0, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z33WWPNotificationCreated != T000E2_A33WWPNotificationCreated[0] ) || ( StringUtil.StrCmp(Z85WWPNotificationIcon, T000E2_A85WWPNotificationIcon[0]) != 0 ) || ( StringUtil.StrCmp(Z86WWPNotificationTitle, T000E2_A86WWPNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z87WWPNotificationShortDescriptio, T000E2_A87WWPNotificationShortDescriptio[0]) != 0 ) || ( StringUtil.StrCmp(Z88WWPNotificationLink, T000E2_A88WWPNotificationLink[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z91WWPNotificationIsRead != T000E2_A91WWPNotificationIsRead[0] ) || ( Z32WWPNotificationDefinitionId != T000E2_A32WWPNotificationDefinitionId[0] ) || ( StringUtil.StrCmp(Z1WWPUserExtendedId, T000E2_A1WWPUserExtendedId[0]) != 0 ) )
            {
               if ( Z33WWPNotificationCreated != T000E2_A33WWPNotificationCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationCreated");
                  GXUtil.WriteLogRaw("Old: ",Z33WWPNotificationCreated);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A33WWPNotificationCreated[0]);
               }
               if ( StringUtil.StrCmp(Z85WWPNotificationIcon, T000E2_A85WWPNotificationIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationIcon");
                  GXUtil.WriteLogRaw("Old: ",Z85WWPNotificationIcon);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A85WWPNotificationIcon[0]);
               }
               if ( StringUtil.StrCmp(Z86WWPNotificationTitle, T000E2_A86WWPNotificationTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationTitle");
                  GXUtil.WriteLogRaw("Old: ",Z86WWPNotificationTitle);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A86WWPNotificationTitle[0]);
               }
               if ( StringUtil.StrCmp(Z87WWPNotificationShortDescriptio, T000E2_A87WWPNotificationShortDescriptio[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationShortDescriptio");
                  GXUtil.WriteLogRaw("Old: ",Z87WWPNotificationShortDescriptio);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A87WWPNotificationShortDescriptio[0]);
               }
               if ( StringUtil.StrCmp(Z88WWPNotificationLink, T000E2_A88WWPNotificationLink[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationLink");
                  GXUtil.WriteLogRaw("Old: ",Z88WWPNotificationLink);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A88WWPNotificationLink[0]);
               }
               if ( Z91WWPNotificationIsRead != T000E2_A91WWPNotificationIsRead[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationIsRead");
                  GXUtil.WriteLogRaw("Old: ",Z91WWPNotificationIsRead);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A91WWPNotificationIsRead[0]);
               }
               if ( Z32WWPNotificationDefinitionId != T000E2_A32WWPNotificationDefinitionId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationDefinitionId");
                  GXUtil.WriteLogRaw("Old: ",Z32WWPNotificationDefinitionId);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A32WWPNotificationDefinitionId[0]);
               }
               if ( StringUtil.StrCmp(Z1WWPUserExtendedId, T000E2_A1WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z1WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A1WWPUserExtendedId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Notification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E15( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E15( 0) ;
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E12 */
                     pr_default.execute(10, new Object[] {A33WWPNotificationCreated, A85WWPNotificationIcon, A86WWPNotificationTitle, A87WWPNotificationShortDescriptio, A88WWPNotificationLink, A91WWPNotificationIsRead, n69WWPNotificationMetadata, A69WWPNotificationMetadata, A32WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId});
                     A31WWPNotificationId = T000E12_A31WWPNotificationId[0];
                     n31WWPNotificationId = T000E12_n31WWPNotificationId[0];
                     AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0E0( ) ;
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
               Load0E15( ) ;
            }
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void Update0E15( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E13 */
                     pr_default.execute(11, new Object[] {A33WWPNotificationCreated, A85WWPNotificationIcon, A86WWPNotificationTitle, A87WWPNotificationShortDescriptio, A88WWPNotificationLink, A91WWPNotificationIsRead, n69WWPNotificationMetadata, A69WWPNotificationMetadata, A32WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId, n31WWPNotificationId, A31WWPNotificationId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E15( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0E0( ) ;
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
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void DeferredUpdate0E15( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E15( ) ;
            AfterConfirm0E15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000E14 */
                  pr_default.execute(12, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound15 == 0 )
                        {
                           InitAll0E15( ) ;
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
                        ResetCaption0E0( ) ;
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0E15( ) ;
         Gx_mode = sMode15;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0E15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000E15 */
            pr_default.execute(13, new Object[] {A32WWPNotificationDefinitionId});
            A68WWPNotificationDefinitionName = T000E15_A68WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
            pr_default.close(13);
            /* Using cursor T000E16 */
            pr_default.execute(14, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            A2WWPUserExtendedFullName = T000E16_A2WWPUserExtendedFullName[0];
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
            pr_default.close(14);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000E17 */
            pr_default.execute(15, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Mail", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000E18 */
            pr_default.execute(16, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_WebNotification", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000E19 */
            pr_default.execute(17, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_SMS", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void EndLevel0E15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_notification",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notification",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0E15( )
      {
         /* Using cursor T000E20 */
         pr_default.execute(18);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound15 = 1;
            A31WWPNotificationId = T000E20_A31WWPNotificationId[0];
            n31WWPNotificationId = T000E20_n31WWPNotificationId[0];
            AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0E15( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound15 = 1;
            A31WWPNotificationId = T000E20_A31WWPNotificationId[0];
            n31WWPNotificationId = T000E20_n31WWPNotificationId[0];
            AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
         }
      }

      protected void ScanEnd0E15( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0E15( )
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

      protected void BeforeInsert0E15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E15( )
      {
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionName_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionName_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
         edtWWPNotificationIcon_Enabled = 0;
         AssignProp("", false, edtWWPNotificationIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationIcon_Enabled), 5, 0), true);
         edtWWPNotificationTitle_Enabled = 0;
         AssignProp("", false, edtWWPNotificationTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationTitle_Enabled), 5, 0), true);
         edtWWPNotificationShortDescriptio_Enabled = 0;
         AssignProp("", false, edtWWPNotificationShortDescriptio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationShortDescriptio_Enabled), 5, 0), true);
         edtWWPNotificationLink_Enabled = 0;
         AssignProp("", false, edtWWPNotificationLink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationLink_Enabled), 5, 0), true);
         chkWWPNotificationIsRead.Enabled = 0;
         AssignProp("", false, chkWWPNotificationIsRead_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPNotificationIsRead.Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPNotificationMetadata_Enabled = 0;
         AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0E15( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0E0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.wwp_notification.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z31WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z33WWPNotificationCreated", context.localUtil.TToC( Z33WWPNotificationCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z85WWPNotificationIcon", Z85WWPNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z86WWPNotificationTitle", Z86WWPNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z87WWPNotificationShortDescriptio", Z87WWPNotificationShortDescriptio);
         GxWebStd.gx_hidden_field( context, "Z88WWPNotificationLink", Z88WWPNotificationLink);
         GxWebStd.gx_boolean_hidden_field( context, "Z91WWPNotificationIsRead", Z91WWPNotificationIsRead);
         GxWebStd.gx_hidden_field( context, "Z32WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z32WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z1WWPUserExtendedId", StringUtil.RTrim( Z1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("wwpbaseobjects.notifications.common.wwp_notification.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Common.WWP_Notification" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Notification", "") ;
      }

      protected void InitializeNonKey0E15( )
      {
         A32WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
         A68WWPNotificationDefinitionName = "";
         AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
         A85WWPNotificationIcon = "";
         AssignAttri("", false, "A85WWPNotificationIcon", A85WWPNotificationIcon);
         A86WWPNotificationTitle = "";
         AssignAttri("", false, "A86WWPNotificationTitle", A86WWPNotificationTitle);
         A87WWPNotificationShortDescriptio = "";
         AssignAttri("", false, "A87WWPNotificationShortDescriptio", A87WWPNotificationShortDescriptio);
         A88WWPNotificationLink = "";
         AssignAttri("", false, "A88WWPNotificationLink", A88WWPNotificationLink);
         A91WWPNotificationIsRead = false;
         AssignAttri("", false, "A91WWPNotificationIsRead", A91WWPNotificationIsRead);
         A1WWPUserExtendedId = "";
         n1WWPUserExtendedId = false;
         AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
         n1WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ? true : false);
         A2WWPUserExtendedFullName = "";
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         A69WWPNotificationMetadata = "";
         n69WWPNotificationMetadata = false;
         AssignAttri("", false, "A69WWPNotificationMetadata", A69WWPNotificationMetadata);
         n69WWPNotificationMetadata = (String.IsNullOrEmpty(StringUtil.RTrim( A69WWPNotificationMetadata)) ? true : false);
         A33WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         Z33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z85WWPNotificationIcon = "";
         Z86WWPNotificationTitle = "";
         Z87WWPNotificationShortDescriptio = "";
         Z88WWPNotificationLink = "";
         Z91WWPNotificationIsRead = false;
         Z32WWPNotificationDefinitionId = 0;
         Z1WWPUserExtendedId = "";
      }

      protected void InitAll0E15( )
      {
         A31WWPNotificationId = 0;
         n31WWPNotificationId = false;
         AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
         InitializeNonKey0E15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A33WWPNotificationCreated = i33WWPNotificationCreated;
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026730218559", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/common/wwp_notification.js", "?20267302185510", false, true, false);
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
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPNotificationDefinitionName_Internalname = "WWPNOTIFICATIONDEFINITIONNAME";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         edtWWPNotificationIcon_Internalname = "WWPNOTIFICATIONICON";
         edtWWPNotificationTitle_Internalname = "WWPNOTIFICATIONTITLE";
         edtWWPNotificationShortDescriptio_Internalname = "WWPNOTIFICATIONSHORTDESCRIPTIO";
         edtWWPNotificationLink_Internalname = "WWPNOTIFICATIONLINK";
         chkWWPNotificationIsRead_Internalname = "WWPNOTIFICATIONISREAD";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA";
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
         Form.Caption = context.GetMessage( "Notification", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPNotificationMetadata_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 0;
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         chkWWPNotificationIsRead.Enabled = 1;
         edtWWPNotificationLink_Jsonclick = "";
         edtWWPNotificationLink_Enabled = 1;
         edtWWPNotificationShortDescriptio_Enabled = 1;
         edtWWPNotificationTitle_Enabled = 1;
         edtWWPNotificationIcon_Jsonclick = "";
         edtWWPNotificationIcon_Enabled = 1;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 1;
         edtWWPNotificationDefinitionName_Jsonclick = "";
         edtWWPNotificationDefinitionName_Enabled = 0;
         imgprompt_32_Visible = 1;
         imgprompt_32_Link = "";
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPNotificationDefinitionId_Enabled = 1;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
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
         chkWWPNotificationIsRead.Name = "WWPNOTIFICATIONISREAD";
         chkWWPNotificationIsRead.WebTags = "";
         chkWWPNotificationIsRead.Caption = context.GetMessage( "Is Read", "");
         AssignProp("", false, chkWWPNotificationIsRead_Internalname, "TitleCaption", chkWWPNotificationIsRead.Caption, true);
         chkWWPNotificationIsRead.CheckedValue = "false";
         A91WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A91WWPNotificationIsRead));
         AssignAttri("", false, "A91WWPNotificationIsRead", A91WWPNotificationIsRead);
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

      public void Valid_Wwpnotificationid( )
      {
         n31WWPNotificationId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A91WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A91WWPNotificationIsRead));
         /*  Sending validation outputs */
         AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A32WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A85WWPNotificationIcon", A85WWPNotificationIcon);
         AssignAttri("", false, "A86WWPNotificationTitle", A86WWPNotificationTitle);
         AssignAttri("", false, "A87WWPNotificationShortDescriptio", A87WWPNotificationShortDescriptio);
         AssignAttri("", false, "A88WWPNotificationLink", A88WWPNotificationLink);
         AssignAttri("", false, "A91WWPNotificationIsRead", A91WWPNotificationIsRead);
         AssignAttri("", false, "A1WWPUserExtendedId", StringUtil.RTrim( A1WWPUserExtendedId));
         AssignAttri("", false, "A69WWPNotificationMetadata", A69WWPNotificationMetadata);
         AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z31WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z32WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z32WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z33WWPNotificationCreated", context.localUtil.TToC( Z33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z85WWPNotificationIcon", Z85WWPNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z86WWPNotificationTitle", Z86WWPNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z87WWPNotificationShortDescriptio", Z87WWPNotificationShortDescriptio);
         GxWebStd.gx_hidden_field( context, "Z88WWPNotificationLink", Z88WWPNotificationLink);
         GxWebStd.gx_hidden_field( context, "Z91WWPNotificationIsRead", StringUtil.BoolToStr( Z91WWPNotificationIsRead));
         GxWebStd.gx_hidden_field( context, "Z1WWPUserExtendedId", StringUtil.RTrim( Z1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z69WWPNotificationMetadata", Z69WWPNotificationMetadata);
         GxWebStd.gx_hidden_field( context, "Z68WWPNotificationDefinitionName", Z68WWPNotificationDefinitionName);
         GxWebStd.gx_hidden_field( context, "Z2WWPUserExtendedFullName", Z2WWPUserExtendedFullName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationdefinitionid( )
      {
         /* Using cursor T000E15 */
         pr_default.execute(13, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         }
         A68WWPNotificationDefinitionName = T000E15_A68WWPNotificationDefinitionName[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
      }

      public void Valid_Wwpuserextendedid( )
      {
         n1WWPUserExtendedId = false;
         /* Using cursor T000E16 */
         pr_default.execute(14, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
            }
         }
         A2WWPUserExtendedFullName = T000E16_A2WWPUserExtendedFullName[0];
         pr_default.close(14);
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:'',type:'boolean'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:'',type:'boolean'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONID","{handler:'Valid_Wwpnotificationid',iparms:[{av:'A31WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'A33WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONID",",oparms:[{av:'A32WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A33WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A85WWPNotificationIcon',fld:'WWPNOTIFICATIONICON',pic:'',type:'svchar'},{av:'A86WWPNotificationTitle',fld:'WWPNOTIFICATIONTITLE',pic:'',type:'svchar'},{av:'A87WWPNotificationShortDescriptio',fld:'WWPNOTIFICATIONSHORTDESCRIPTIO',pic:'',type:'svchar'},{av:'A88WWPNotificationLink',fld:'WWPNOTIFICATIONLINK',pic:'',type:'svchar'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:'',type:'char'},{av:'A69WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:'',type:'vchar'},{av:'A68WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:'',type:'svchar'},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:'',type:'svchar'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z31WWPNotificationId',type:'int'},{av:'Z32WWPNotificationDefinitionId',type:'int'},{av:'Z33WWPNotificationCreated',type:'dtime'},{av:'Z85WWPNotificationIcon',type:'svchar'},{av:'Z86WWPNotificationTitle',type:'svchar'},{av:'Z87WWPNotificationShortDescriptio',type:'svchar'},{av:'Z88WWPNotificationLink',type:'svchar'},{av:'Z91WWPNotificationIsRead',type:'boolean'},{av:'Z1WWPUserExtendedId',type:'char'},{av:'Z69WWPNotificationMetadata',type:'vchar'},{av:'Z68WWPNotificationDefinitionName',type:'svchar'},{av:'Z2WWPUserExtendedFullName',type:'svchar'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID","{handler:'Valid_Wwpnotificationdefinitionid',iparms:[{av:'A32WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A68WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:'',type:'svchar'},{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID",",oparms:[{av:'A68WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:'',type:'svchar'},{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONCREATED","{handler:'Valid_Wwpnotificationcreated',iparms:[{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONCREATED",",oparms:[{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONLINK","{handler:'Valid_Wwpnotificationlink',iparms:[{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONLINK",",oparms:[{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","{handler:'Valid_Wwpuserextendedid',iparms:[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:'',type:'char'},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:'',type:'svchar'},{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",",oparms:[{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:'',type:'svchar'},{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:'',type:'boolean'}]}");
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
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z85WWPNotificationIcon = "";
         Z86WWPNotificationTitle = "";
         Z87WWPNotificationShortDescriptio = "";
         Z88WWPNotificationLink = "";
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
         A68WWPNotificationDefinitionName = "";
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A85WWPNotificationIcon = "";
         A86WWPNotificationTitle = "";
         A87WWPNotificationShortDescriptio = "";
         A88WWPNotificationLink = "";
         imgprompt_1_gximage = "";
         A2WWPUserExtendedFullName = "";
         A69WWPNotificationMetadata = "";
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
         Z69WWPNotificationMetadata = "";
         Z68WWPNotificationDefinitionName = "";
         Z2WWPUserExtendedFullName = "";
         T000E6_A31WWPNotificationId = new long[1] ;
         T000E6_n31WWPNotificationId = new bool[] {false} ;
         T000E6_A68WWPNotificationDefinitionName = new string[] {""} ;
         T000E6_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000E6_A85WWPNotificationIcon = new string[] {""} ;
         T000E6_A86WWPNotificationTitle = new string[] {""} ;
         T000E6_A87WWPNotificationShortDescriptio = new string[] {""} ;
         T000E6_A88WWPNotificationLink = new string[] {""} ;
         T000E6_A91WWPNotificationIsRead = new bool[] {false} ;
         T000E6_A2WWPUserExtendedFullName = new string[] {""} ;
         T000E6_A69WWPNotificationMetadata = new string[] {""} ;
         T000E6_n69WWPNotificationMetadata = new bool[] {false} ;
         T000E6_A32WWPNotificationDefinitionId = new long[1] ;
         T000E6_A1WWPUserExtendedId = new string[] {""} ;
         T000E6_n1WWPUserExtendedId = new bool[] {false} ;
         T000E4_A68WWPNotificationDefinitionName = new string[] {""} ;
         T000E5_A2WWPUserExtendedFullName = new string[] {""} ;
         T000E7_A68WWPNotificationDefinitionName = new string[] {""} ;
         T000E8_A2WWPUserExtendedFullName = new string[] {""} ;
         T000E9_A31WWPNotificationId = new long[1] ;
         T000E9_n31WWPNotificationId = new bool[] {false} ;
         T000E3_A31WWPNotificationId = new long[1] ;
         T000E3_n31WWPNotificationId = new bool[] {false} ;
         T000E3_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000E3_A85WWPNotificationIcon = new string[] {""} ;
         T000E3_A86WWPNotificationTitle = new string[] {""} ;
         T000E3_A87WWPNotificationShortDescriptio = new string[] {""} ;
         T000E3_A88WWPNotificationLink = new string[] {""} ;
         T000E3_A91WWPNotificationIsRead = new bool[] {false} ;
         T000E3_A69WWPNotificationMetadata = new string[] {""} ;
         T000E3_n69WWPNotificationMetadata = new bool[] {false} ;
         T000E3_A32WWPNotificationDefinitionId = new long[1] ;
         T000E3_A1WWPUserExtendedId = new string[] {""} ;
         T000E3_n1WWPUserExtendedId = new bool[] {false} ;
         sMode15 = "";
         T000E10_A31WWPNotificationId = new long[1] ;
         T000E10_n31WWPNotificationId = new bool[] {false} ;
         T000E11_A31WWPNotificationId = new long[1] ;
         T000E11_n31WWPNotificationId = new bool[] {false} ;
         T000E2_A31WWPNotificationId = new long[1] ;
         T000E2_n31WWPNotificationId = new bool[] {false} ;
         T000E2_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000E2_A85WWPNotificationIcon = new string[] {""} ;
         T000E2_A86WWPNotificationTitle = new string[] {""} ;
         T000E2_A87WWPNotificationShortDescriptio = new string[] {""} ;
         T000E2_A88WWPNotificationLink = new string[] {""} ;
         T000E2_A91WWPNotificationIsRead = new bool[] {false} ;
         T000E2_A69WWPNotificationMetadata = new string[] {""} ;
         T000E2_n69WWPNotificationMetadata = new bool[] {false} ;
         T000E2_A32WWPNotificationDefinitionId = new long[1] ;
         T000E2_A1WWPUserExtendedId = new string[] {""} ;
         T000E2_n1WWPUserExtendedId = new bool[] {false} ;
         T000E12_A31WWPNotificationId = new long[1] ;
         T000E12_n31WWPNotificationId = new bool[] {false} ;
         T000E15_A68WWPNotificationDefinitionName = new string[] {""} ;
         T000E16_A2WWPUserExtendedFullName = new string[] {""} ;
         T000E17_A89WWPMailId = new long[1] ;
         T000E18_A56WWPWebNotificationId = new long[1] ;
         T000E19_A42WWPSMSId = new long[1] ;
         T000E20_A31WWPNotificationId = new long[1] ;
         T000E20_n31WWPNotificationId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ85WWPNotificationIcon = "";
         ZZ86WWPNotificationTitle = "";
         ZZ87WWPNotificationShortDescriptio = "";
         ZZ88WWPNotificationLink = "";
         ZZ1WWPUserExtendedId = "";
         ZZ69WWPNotificationMetadata = "";
         ZZ68WWPNotificationDefinitionName = "";
         ZZ2WWPUserExtendedFullName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification__default(),
            new Object[][] {
                new Object[] {
               T000E2_A31WWPNotificationId, T000E2_A33WWPNotificationCreated, T000E2_A85WWPNotificationIcon, T000E2_A86WWPNotificationTitle, T000E2_A87WWPNotificationShortDescriptio, T000E2_A88WWPNotificationLink, T000E2_A91WWPNotificationIsRead, T000E2_A69WWPNotificationMetadata, T000E2_n69WWPNotificationMetadata, T000E2_A32WWPNotificationDefinitionId,
               T000E2_A1WWPUserExtendedId, T000E2_n1WWPUserExtendedId
               }
               , new Object[] {
               T000E3_A31WWPNotificationId, T000E3_A33WWPNotificationCreated, T000E3_A85WWPNotificationIcon, T000E3_A86WWPNotificationTitle, T000E3_A87WWPNotificationShortDescriptio, T000E3_A88WWPNotificationLink, T000E3_A91WWPNotificationIsRead, T000E3_A69WWPNotificationMetadata, T000E3_n69WWPNotificationMetadata, T000E3_A32WWPNotificationDefinitionId,
               T000E3_A1WWPUserExtendedId, T000E3_n1WWPUserExtendedId
               }
               , new Object[] {
               T000E4_A68WWPNotificationDefinitionName
               }
               , new Object[] {
               T000E5_A2WWPUserExtendedFullName
               }
               , new Object[] {
               T000E6_A31WWPNotificationId, T000E6_A68WWPNotificationDefinitionName, T000E6_A33WWPNotificationCreated, T000E6_A85WWPNotificationIcon, T000E6_A86WWPNotificationTitle, T000E6_A87WWPNotificationShortDescriptio, T000E6_A88WWPNotificationLink, T000E6_A91WWPNotificationIsRead, T000E6_A2WWPUserExtendedFullName, T000E6_A69WWPNotificationMetadata,
               T000E6_n69WWPNotificationMetadata, T000E6_A32WWPNotificationDefinitionId, T000E6_A1WWPUserExtendedId, T000E6_n1WWPUserExtendedId
               }
               , new Object[] {
               T000E7_A68WWPNotificationDefinitionName
               }
               , new Object[] {
               T000E8_A2WWPUserExtendedFullName
               }
               , new Object[] {
               T000E9_A31WWPNotificationId
               }
               , new Object[] {
               T000E10_A31WWPNotificationId
               }
               , new Object[] {
               T000E11_A31WWPNotificationId
               }
               , new Object[] {
               T000E12_A31WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000E15_A68WWPNotificationDefinitionName
               }
               , new Object[] {
               T000E16_A2WWPUserExtendedFullName
               }
               , new Object[] {
               T000E17_A89WWPMailId
               }
               , new Object[] {
               T000E18_A56WWPWebNotificationId
               }
               , new Object[] {
               T000E19_A42WWPSMSId
               }
               , new Object[] {
               T000E20_A31WWPNotificationId
               }
            }
         );
         Z33WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A33WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i33WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound15 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int imgprompt_32_Visible ;
      private int edtWWPNotificationDefinitionName_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int edtWWPNotificationIcon_Enabled ;
      private int edtWWPNotificationTitle_Enabled ;
      private int edtWWPNotificationShortDescriptio_Enabled ;
      private int edtWWPNotificationLink_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int imgprompt_1_Visible ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPNotificationMetadata_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z31WWPNotificationId ;
      private long Z32WWPNotificationDefinitionId ;
      private long A32WWPNotificationDefinitionId ;
      private long A31WWPNotificationId ;
      private long ZZ31WWPNotificationId ;
      private long ZZ32WWPNotificationDefinitionId ;
      private string sPrefix ;
      private string Z1WWPUserExtendedId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A1WWPUserExtendedId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPNotificationId_Internalname ;
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
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string imgprompt_32_gximage ;
      private string sImgUrl ;
      private string imgprompt_32_Internalname ;
      private string imgprompt_32_Link ;
      private string edtWWPNotificationDefinitionName_Internalname ;
      private string edtWWPNotificationDefinitionName_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string edtWWPNotificationIcon_Internalname ;
      private string edtWWPNotificationIcon_Jsonclick ;
      private string edtWWPNotificationTitle_Internalname ;
      private string edtWWPNotificationShortDescriptio_Internalname ;
      private string edtWWPNotificationLink_Internalname ;
      private string edtWWPNotificationLink_Jsonclick ;
      private string chkWWPNotificationIsRead_Internalname ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string imgprompt_1_gximage ;
      private string imgprompt_1_Internalname ;
      private string imgprompt_1_Link ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPNotificationMetadata_Internalname ;
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
      private string sMode15 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1WWPUserExtendedId ;
      private DateTime Z33WWPNotificationCreated ;
      private DateTime A33WWPNotificationCreated ;
      private DateTime i33WWPNotificationCreated ;
      private DateTime ZZ33WWPNotificationCreated ;
      private bool Z91WWPNotificationIsRead ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1WWPUserExtendedId ;
      private bool wbErr ;
      private bool A91WWPNotificationIsRead ;
      private bool n31WWPNotificationId ;
      private bool n69WWPNotificationMetadata ;
      private bool Gx_longc ;
      private bool ZZ91WWPNotificationIsRead ;
      private string A69WWPNotificationMetadata ;
      private string Z69WWPNotificationMetadata ;
      private string ZZ69WWPNotificationMetadata ;
      private string Z85WWPNotificationIcon ;
      private string Z86WWPNotificationTitle ;
      private string Z87WWPNotificationShortDescriptio ;
      private string Z88WWPNotificationLink ;
      private string A68WWPNotificationDefinitionName ;
      private string A85WWPNotificationIcon ;
      private string A86WWPNotificationTitle ;
      private string A87WWPNotificationShortDescriptio ;
      private string A88WWPNotificationLink ;
      private string A2WWPUserExtendedFullName ;
      private string Z68WWPNotificationDefinitionName ;
      private string Z2WWPUserExtendedFullName ;
      private string ZZ85WWPNotificationIcon ;
      private string ZZ86WWPNotificationTitle ;
      private string ZZ87WWPNotificationShortDescriptio ;
      private string ZZ88WWPNotificationLink ;
      private string ZZ68WWPNotificationDefinitionName ;
      private string ZZ2WWPUserExtendedFullName ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPNotificationIsRead ;
      private IDataStoreProvider pr_default ;
      private long[] T000E6_A31WWPNotificationId ;
      private bool[] T000E6_n31WWPNotificationId ;
      private string[] T000E6_A68WWPNotificationDefinitionName ;
      private DateTime[] T000E6_A33WWPNotificationCreated ;
      private string[] T000E6_A85WWPNotificationIcon ;
      private string[] T000E6_A86WWPNotificationTitle ;
      private string[] T000E6_A87WWPNotificationShortDescriptio ;
      private string[] T000E6_A88WWPNotificationLink ;
      private bool[] T000E6_A91WWPNotificationIsRead ;
      private string[] T000E6_A2WWPUserExtendedFullName ;
      private string[] T000E6_A69WWPNotificationMetadata ;
      private bool[] T000E6_n69WWPNotificationMetadata ;
      private long[] T000E6_A32WWPNotificationDefinitionId ;
      private string[] T000E6_A1WWPUserExtendedId ;
      private bool[] T000E6_n1WWPUserExtendedId ;
      private string[] T000E4_A68WWPNotificationDefinitionName ;
      private string[] T000E5_A2WWPUserExtendedFullName ;
      private string[] T000E7_A68WWPNotificationDefinitionName ;
      private string[] T000E8_A2WWPUserExtendedFullName ;
      private long[] T000E9_A31WWPNotificationId ;
      private bool[] T000E9_n31WWPNotificationId ;
      private long[] T000E3_A31WWPNotificationId ;
      private bool[] T000E3_n31WWPNotificationId ;
      private DateTime[] T000E3_A33WWPNotificationCreated ;
      private string[] T000E3_A85WWPNotificationIcon ;
      private string[] T000E3_A86WWPNotificationTitle ;
      private string[] T000E3_A87WWPNotificationShortDescriptio ;
      private string[] T000E3_A88WWPNotificationLink ;
      private bool[] T000E3_A91WWPNotificationIsRead ;
      private string[] T000E3_A69WWPNotificationMetadata ;
      private bool[] T000E3_n69WWPNotificationMetadata ;
      private long[] T000E3_A32WWPNotificationDefinitionId ;
      private string[] T000E3_A1WWPUserExtendedId ;
      private bool[] T000E3_n1WWPUserExtendedId ;
      private long[] T000E10_A31WWPNotificationId ;
      private bool[] T000E10_n31WWPNotificationId ;
      private long[] T000E11_A31WWPNotificationId ;
      private bool[] T000E11_n31WWPNotificationId ;
      private long[] T000E2_A31WWPNotificationId ;
      private bool[] T000E2_n31WWPNotificationId ;
      private DateTime[] T000E2_A33WWPNotificationCreated ;
      private string[] T000E2_A85WWPNotificationIcon ;
      private string[] T000E2_A86WWPNotificationTitle ;
      private string[] T000E2_A87WWPNotificationShortDescriptio ;
      private string[] T000E2_A88WWPNotificationLink ;
      private bool[] T000E2_A91WWPNotificationIsRead ;
      private string[] T000E2_A69WWPNotificationMetadata ;
      private bool[] T000E2_n69WWPNotificationMetadata ;
      private long[] T000E2_A32WWPNotificationDefinitionId ;
      private string[] T000E2_A1WWPUserExtendedId ;
      private bool[] T000E2_n1WWPUserExtendedId ;
      private long[] T000E12_A31WWPNotificationId ;
      private bool[] T000E12_n31WWPNotificationId ;
      private string[] T000E15_A68WWPNotificationDefinitionName ;
      private string[] T000E16_A2WWPUserExtendedFullName ;
      private long[] T000E17_A89WWPMailId ;
      private long[] T000E18_A56WWPWebNotificationId ;
      private long[] T000E19_A42WWPSMSId ;
      private long[] T000E20_A31WWPNotificationId ;
      private bool[] T000E20_n31WWPNotificationId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_notification__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notification__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
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
        Object[] prmT000E2;
        prmT000E2 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000E3;
        prmT000E3 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000E4;
        prmT000E4 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000E5;
        prmT000E5 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmT000E6;
        prmT000E6 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000E7;
        prmT000E7 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000E8;
        prmT000E8 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmT000E9;
        prmT000E9 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000E10;
        prmT000E10 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000E11;
        prmT000E11 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000E12;
        prmT000E12 = new Object[] {
        new ParDef("@WWPNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPNotificationIcon",GXType.NVarChar,100,0) ,
        new ParDef("@WWPNotificationTitle",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationShortDescriptio",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationLink",GXType.NVarChar,1000,0) ,
        new ParDef("@WWPNotificationIsRead",GXType.Boolean,4,0) ,
        new ParDef("@WWPNotificationMetadata",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0) ,
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmT000E13;
        prmT000E13 = new Object[] {
        new ParDef("@WWPNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPNotificationIcon",GXType.NVarChar,100,0) ,
        new ParDef("@WWPNotificationTitle",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationShortDescriptio",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationLink",GXType.NVarChar,1000,0) ,
        new ParDef("@WWPNotificationIsRead",GXType.Boolean,4,0) ,
        new ParDef("@WWPNotificationMetadata",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0) ,
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true} ,
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000E14;
        prmT000E14 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000E15;
        prmT000E15 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000E16;
        prmT000E16 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmT000E17;
        prmT000E17 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000E18;
        prmT000E18 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000E19;
        prmT000E19 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000E20;
        prmT000E20 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000E2", "SELECT [WWPNotificationId], [WWPNotificationCreated], [WWPNotificationIcon], [WWPNotificationTitle], [WWPNotificationShortDescriptio], [WWPNotificationLink], [WWPNotificationIsRead], [WWPNotificationMetadata], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Notification] WITH (UPDLOCK) WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E3", "SELECT [WWPNotificationId], [WWPNotificationCreated], [WWPNotificationIcon], [WWPNotificationTitle], [WWPNotificationShortDescriptio], [WWPNotificationLink], [WWPNotificationIsRead], [WWPNotificationMetadata], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E4", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E5", "SELECT [WWPUserExtendedFullName] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E6", "SELECT TM1.[WWPNotificationId], T2.[WWPNotificationDefinitionName], TM1.[WWPNotificationCreated], TM1.[WWPNotificationIcon], TM1.[WWPNotificationTitle], TM1.[WWPNotificationShortDescriptio], TM1.[WWPNotificationLink], TM1.[WWPNotificationIsRead], T3.[WWPUserExtendedFullName], TM1.[WWPNotificationMetadata], TM1.[WWPNotificationDefinitionId], TM1.[WWPUserExtendedId] FROM (([WWP_Notification] TM1 INNER JOIN [WWP_NotificationDefinition] T2 ON T2.[WWPNotificationDefinitionId] = TM1.[WWPNotificationDefinitionId]) LEFT JOIN [WWP_UserExtended] T3 ON T3.[WWPUserExtendedId] = TM1.[WWPUserExtendedId]) WHERE TM1.[WWPNotificationId] = @WWPNotificationId ORDER BY TM1.[WWPNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E7", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E8", "SELECT [WWPUserExtendedFullName] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E9", "SELECT [WWPNotificationId] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E10", "SELECT TOP 1 [WWPNotificationId] FROM [WWP_Notification] WHERE ( [WWPNotificationId] > @WWPNotificationId) ORDER BY [WWPNotificationId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E11", "SELECT TOP 1 [WWPNotificationId] FROM [WWP_Notification] WHERE ( [WWPNotificationId] < @WWPNotificationId) ORDER BY [WWPNotificationId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E12", "INSERT INTO [WWP_Notification]([WWPNotificationCreated], [WWPNotificationIcon], [WWPNotificationTitle], [WWPNotificationShortDescriptio], [WWPNotificationLink], [WWPNotificationIsRead], [WWPNotificationMetadata], [WWPNotificationDefinitionId], [WWPUserExtendedId]) VALUES(@WWPNotificationCreated, @WWPNotificationIcon, @WWPNotificationTitle, @WWPNotificationShortDescriptio, @WWPNotificationLink, @WWPNotificationIsRead, @WWPNotificationMetadata, @WWPNotificationDefinitionId, @WWPUserExtendedId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000E12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E13", "UPDATE [WWP_Notification] SET [WWPNotificationCreated]=@WWPNotificationCreated, [WWPNotificationIcon]=@WWPNotificationIcon, [WWPNotificationTitle]=@WWPNotificationTitle, [WWPNotificationShortDescriptio]=@WWPNotificationShortDescriptio, [WWPNotificationLink]=@WWPNotificationLink, [WWPNotificationIsRead]=@WWPNotificationIsRead, [WWPNotificationMetadata]=@WWPNotificationMetadata, [WWPNotificationDefinitionId]=@WWPNotificationDefinitionId, [WWPUserExtendedId]=@WWPUserExtendedId  WHERE [WWPNotificationId] = @WWPNotificationId", GxErrorMask.GX_NOMASK,prmT000E13)
           ,new CursorDef("T000E14", "DELETE FROM [WWP_Notification]  WHERE [WWPNotificationId] = @WWPNotificationId", GxErrorMask.GX_NOMASK,prmT000E14)
           ,new CursorDef("T000E15", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E16", "SELECT [WWPUserExtendedFullName] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E17", "SELECT TOP 1 [WWPMailId] FROM [WWP_Mail] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E18", "SELECT TOP 1 [WWPWebNotificationId] FROM [WWP_WebNotification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E19", "SELECT TOP 1 [WWPSMSId] FROM [WWP_SMS] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E20", "SELECT [WWPNotificationId] FROM [WWP_Notification] ORDER BY [WWPNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E20,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((long[]) buf[9])[0] = rslt.getLong(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 40);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((long[]) buf[9])[0] = rslt.getLong(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 40);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((long[]) buf[11])[0] = rslt.getLong(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(12);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
