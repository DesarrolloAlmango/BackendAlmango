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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_webnotification : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A31WWPNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationId"), "."), 18, MidpointRounding.ToEven));
            n31WWPNotificationId = false;
            AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A31WWPNotificationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A32WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A32WWPNotificationDefinitionId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "WWP_Web Notification", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_webnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_webnotification( IGxContext context )
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
         cmbWWPWebNotificationStatus = new GXCombobox();
         chkWWPWebNotificationReceived = new GXCheckbox();
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
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            A63WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPWebNotificationStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A63WWPWebNotificationStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A63WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A63WWPWebNotificationStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A63WWPWebNotificationStatus), 4, 0));
            AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", cmbWWPWebNotificationStatus.ToJavascriptSource(), true);
         }
         A66WWPWebNotificationReceived = StringUtil.StrToBool( StringUtil.BoolToStr( A66WWPWebNotificationReceived));
         n66WWPWebNotificationReceived = false;
         AssignAttri("", false, "A66WWPWebNotificationReceived", A66WWPWebNotificationReceived);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "WWP_Web Notification", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"wwpbaseobjects.notifications.web.gx00c0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPWEBNOTIFICATIONID"+"'), id:'"+"WWPWEBNOTIFICATIONID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationId_Internalname, context.GetMessage( "Notification Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A56WWPWebNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPWebNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A56WWPWebNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A56WWPWebNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationTitle_Internalname, context.GetMessage( "Notification Title", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationTitle_Internalname, A51WWPWebNotificationTitle, StringUtil.RTrim( context.localUtil.Format( A51WWPWebNotificationTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationTitle_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationId_Internalname, context.GetMessage( "Notification Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A31WWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A31WWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_31_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_31_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_31_Internalname, sImgUrl, imgprompt_31_Link, "", "", context.GetTheme( ), imgprompt_31_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationCreated_Internalname, context.GetMessage( "Notification Created Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A33WWPNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationMetadata_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationMetadata_Internalname, context.GetMessage( "WWPNotification Metadata", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationMetadata_Internalname, A69WWPNotificationMetadata, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtWWPNotificationMetadata_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionName_Internalname, A68WWPNotificationDefinitionName, StringUtil.RTrim( context.localUtil.Format( A68WWPNotificationDefinitionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationText_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationText_Internalname, context.GetMessage( "Notification Text", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationText_Internalname, A52WWPWebNotificationText, StringUtil.RTrim( context.localUtil.Format( A52WWPWebNotificationText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationText_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationText_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationIcon_Internalname, context.GetMessage( "Notification Icon", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebNotificationIcon_Internalname, A53WWPWebNotificationIcon, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtWWPWebNotificationIcon_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationClientId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationClientId_Internalname, context.GetMessage( "Client Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebNotificationClientId_Internalname, A62WWPWebNotificationClientId, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, 1, edtWWPWebNotificationClientId_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPWebNotificationStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPWebNotificationStatus_Internalname, context.GetMessage( "Notification Status", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPWebNotificationStatus, cmbWWPWebNotificationStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A63WWPWebNotificationStatus), 4, 0)), 1, cmbWWPWebNotificationStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPWebNotificationStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A63WWPWebNotificationStatus), 4, 0));
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", (string)(cmbWWPWebNotificationStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationCreated_Internalname, context.GetMessage( "Notification Created", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationCreated_Internalname, context.localUtil.TToC( A54WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A54WWPWebNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationScheduled_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationScheduled_Internalname, context.GetMessage( "Notification Scheduled", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationScheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationScheduled_Internalname, context.localUtil.TToC( A67WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A67WWPWebNotificationScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationScheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationScheduled_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationScheduled_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationScheduled_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationProcessed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationProcessed_Internalname, context.GetMessage( "Notification Processed", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationProcessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationProcessed_Internalname, context.localUtil.TToC( A64WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A64WWPWebNotificationProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationProcessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationProcessed_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationProcessed_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationProcessed_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationRead_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationRead_Internalname, context.GetMessage( "Notification Read", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationRead_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationRead_Internalname, context.localUtil.TToC( A55WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A55WWPWebNotificationRead, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationRead_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationRead_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationRead_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationRead_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationDetail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationDetail_Internalname, context.GetMessage( "Notification Detail", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebNotificationDetail_Internalname, A65WWPWebNotificationDetail, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", 0, 1, edtWWPWebNotificationDetail_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPWebNotificationReceived_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPWebNotificationReceived_Internalname, context.GetMessage( "Notification Received", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPWebNotificationReceived_Internalname, StringUtil.BoolToStr( A66WWPWebNotificationReceived), "", context.GetMessage( "Notification Received", ""), 1, chkWWPWebNotificationReceived.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(109, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,109);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
            Z56WWPWebNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z56WWPWebNotificationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z51WWPWebNotificationTitle = cgiGet( "Z51WWPWebNotificationTitle");
            Z52WWPWebNotificationText = cgiGet( "Z52WWPWebNotificationText");
            Z53WWPWebNotificationIcon = cgiGet( "Z53WWPWebNotificationIcon");
            Z63WWPWebNotificationStatus = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z63WWPWebNotificationStatus"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z54WWPWebNotificationCreated = context.localUtil.CToT( cgiGet( "Z54WWPWebNotificationCreated"), 0);
            Z67WWPWebNotificationScheduled = context.localUtil.CToT( cgiGet( "Z67WWPWebNotificationScheduled"), 0);
            Z64WWPWebNotificationProcessed = context.localUtil.CToT( cgiGet( "Z64WWPWebNotificationProcessed"), 0);
            Z55WWPWebNotificationRead = context.localUtil.CToT( cgiGet( "Z55WWPWebNotificationRead"), 0);
            n55WWPWebNotificationRead = ((DateTime.MinValue==A55WWPWebNotificationRead) ? true : false);
            Z66WWPWebNotificationReceived = StringUtil.StrToBool( cgiGet( "Z66WWPWebNotificationReceived"));
            n66WWPWebNotificationReceived = ((false==A66WWPWebNotificationReceived) ? true : false);
            Z31WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z31WWPNotificationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n31WWPNotificationId = ((0==A31WWPNotificationId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A32WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "WWPNOTIFICATIONDEFINITIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPWEBNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A56WWPWebNotificationId = 0;
               AssignAttri("", false, "A56WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A56WWPWebNotificationId), 10, 0));
            }
            else
            {
               A56WWPWebNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A56WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A56WWPWebNotificationId), 10, 0));
            }
            A51WWPWebNotificationTitle = cgiGet( edtWWPWebNotificationTitle_Internalname);
            AssignAttri("", false, "A51WWPWebNotificationTitle", A51WWPWebNotificationTitle);
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
            n31WWPNotificationId = ((0==A31WWPNotificationId) ? true : false);
            A33WWPNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPNotificationCreated_Internalname));
            AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A69WWPNotificationMetadata = cgiGet( edtWWPNotificationMetadata_Internalname);
            n69WWPNotificationMetadata = false;
            AssignAttri("", false, "A69WWPNotificationMetadata", A69WWPNotificationMetadata);
            A68WWPNotificationDefinitionName = cgiGet( edtWWPNotificationDefinitionName_Internalname);
            AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
            A52WWPWebNotificationText = cgiGet( edtWWPWebNotificationText_Internalname);
            AssignAttri("", false, "A52WWPWebNotificationText", A52WWPWebNotificationText);
            A53WWPWebNotificationIcon = cgiGet( edtWWPWebNotificationIcon_Internalname);
            AssignAttri("", false, "A53WWPWebNotificationIcon", A53WWPWebNotificationIcon);
            A62WWPWebNotificationClientId = cgiGet( edtWWPWebNotificationClientId_Internalname);
            AssignAttri("", false, "A62WWPWebNotificationClientId", A62WWPWebNotificationClientId);
            cmbWWPWebNotificationStatus.CurrentValue = cgiGet( cmbWWPWebNotificationStatus_Internalname);
            A63WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPWebNotificationStatus_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A63WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A63WWPWebNotificationStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationCreated_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Web Notification Created", "")}), 1, "WWPWEBNOTIFICATIONCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A54WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A54WWPWebNotificationCreated", context.localUtil.TToC( A54WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A54WWPWebNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPWebNotificationCreated_Internalname));
               AssignAttri("", false, "A54WWPWebNotificationCreated", context.localUtil.TToC( A54WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationScheduled_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Web Notification Scheduled", "")}), 1, "WWPWEBNOTIFICATIONSCHEDULED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationScheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A67WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A67WWPWebNotificationScheduled", context.localUtil.TToC( A67WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A67WWPWebNotificationScheduled = context.localUtil.CToT( cgiGet( edtWWPWebNotificationScheduled_Internalname));
               AssignAttri("", false, "A67WWPWebNotificationScheduled", context.localUtil.TToC( A67WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationProcessed_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Web Notification Processed", "")}), 1, "WWPWEBNOTIFICATIONPROCESSED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationProcessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A64WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A64WWPWebNotificationProcessed", context.localUtil.TToC( A64WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A64WWPWebNotificationProcessed = context.localUtil.CToT( cgiGet( edtWWPWebNotificationProcessed_Internalname));
               AssignAttri("", false, "A64WWPWebNotificationProcessed", context.localUtil.TToC( A64WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationRead_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Web Notification Read", "")}), 1, "WWPWEBNOTIFICATIONREAD");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationRead_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A55WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
               n55WWPWebNotificationRead = false;
               AssignAttri("", false, "A55WWPWebNotificationRead", context.localUtil.TToC( A55WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A55WWPWebNotificationRead = context.localUtil.CToT( cgiGet( edtWWPWebNotificationRead_Internalname));
               n55WWPWebNotificationRead = false;
               AssignAttri("", false, "A55WWPWebNotificationRead", context.localUtil.TToC( A55WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            n55WWPWebNotificationRead = ((DateTime.MinValue==A55WWPWebNotificationRead) ? true : false);
            A65WWPWebNotificationDetail = cgiGet( edtWWPWebNotificationDetail_Internalname);
            n65WWPWebNotificationDetail = false;
            AssignAttri("", false, "A65WWPWebNotificationDetail", A65WWPWebNotificationDetail);
            n65WWPWebNotificationDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A65WWPWebNotificationDetail)) ? true : false);
            A66WWPWebNotificationReceived = StringUtil.StrToBool( cgiGet( chkWWPWebNotificationReceived_Internalname));
            n66WWPWebNotificationReceived = false;
            AssignAttri("", false, "A66WWPWebNotificationReceived", A66WWPWebNotificationReceived);
            n66WWPWebNotificationReceived = ((false==A66WWPWebNotificationReceived) ? true : false);
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
               A56WWPWebNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPWebNotificationId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A56WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A56WWPWebNotificationId), 10, 0));
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
               InitAll0B12( ) ;
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
         DisableAttributes0B12( ) ;
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

      protected void ResetCaption0B0( )
      {
      }

      protected void ZM0B12( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z51WWPWebNotificationTitle = T000B3_A51WWPWebNotificationTitle[0];
               Z52WWPWebNotificationText = T000B3_A52WWPWebNotificationText[0];
               Z53WWPWebNotificationIcon = T000B3_A53WWPWebNotificationIcon[0];
               Z63WWPWebNotificationStatus = T000B3_A63WWPWebNotificationStatus[0];
               Z54WWPWebNotificationCreated = T000B3_A54WWPWebNotificationCreated[0];
               Z67WWPWebNotificationScheduled = T000B3_A67WWPWebNotificationScheduled[0];
               Z64WWPWebNotificationProcessed = T000B3_A64WWPWebNotificationProcessed[0];
               Z55WWPWebNotificationRead = T000B3_A55WWPWebNotificationRead[0];
               Z66WWPWebNotificationReceived = T000B3_A66WWPWebNotificationReceived[0];
               Z31WWPNotificationId = T000B3_A31WWPNotificationId[0];
            }
            else
            {
               Z51WWPWebNotificationTitle = A51WWPWebNotificationTitle;
               Z52WWPWebNotificationText = A52WWPWebNotificationText;
               Z53WWPWebNotificationIcon = A53WWPWebNotificationIcon;
               Z63WWPWebNotificationStatus = A63WWPWebNotificationStatus;
               Z54WWPWebNotificationCreated = A54WWPWebNotificationCreated;
               Z67WWPWebNotificationScheduled = A67WWPWebNotificationScheduled;
               Z64WWPWebNotificationProcessed = A64WWPWebNotificationProcessed;
               Z55WWPWebNotificationRead = A55WWPWebNotificationRead;
               Z66WWPWebNotificationReceived = A66WWPWebNotificationReceived;
               Z31WWPNotificationId = A31WWPNotificationId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z56WWPWebNotificationId = A56WWPWebNotificationId;
            Z51WWPWebNotificationTitle = A51WWPWebNotificationTitle;
            Z52WWPWebNotificationText = A52WWPWebNotificationText;
            Z53WWPWebNotificationIcon = A53WWPWebNotificationIcon;
            Z62WWPWebNotificationClientId = A62WWPWebNotificationClientId;
            Z63WWPWebNotificationStatus = A63WWPWebNotificationStatus;
            Z54WWPWebNotificationCreated = A54WWPWebNotificationCreated;
            Z67WWPWebNotificationScheduled = A67WWPWebNotificationScheduled;
            Z64WWPWebNotificationProcessed = A64WWPWebNotificationProcessed;
            Z55WWPWebNotificationRead = A55WWPWebNotificationRead;
            Z65WWPWebNotificationDetail = A65WWPWebNotificationDetail;
            Z66WWPWebNotificationReceived = A66WWPWebNotificationReceived;
            Z31WWPNotificationId = A31WWPNotificationId;
            Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
            Z33WWPNotificationCreated = A33WWPNotificationCreated;
            Z69WWPNotificationMetadata = A69WWPNotificationMetadata;
            Z68WWPNotificationDefinitionName = A68WWPNotificationDefinitionName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_31_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.notifications.common.gx00f0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPNOTIFICATIONID"+"'), id:'"+"WWPNOTIFICATIONID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A63WWPWebNotificationStatus) && ( Gx_BScreen == 0 ) )
         {
            A63WWPWebNotificationStatus = 1;
            AssignAttri("", false, "A63WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A63WWPWebNotificationStatus), 4, 0));
         }
         if ( IsIns( )  && (DateTime.MinValue==A54WWPWebNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A54WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A54WWPWebNotificationCreated", context.localUtil.TToC( A54WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A67WWPWebNotificationScheduled) && ( Gx_BScreen == 0 ) )
         {
            A67WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A67WWPWebNotificationScheduled", context.localUtil.TToC( A67WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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

      protected void Load0B12( )
      {
         /* Using cursor T000B6 */
         pr_default.execute(4, new Object[] {A56WWPWebNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound12 = 1;
            A32WWPNotificationDefinitionId = T000B6_A32WWPNotificationDefinitionId[0];
            A51WWPWebNotificationTitle = T000B6_A51WWPWebNotificationTitle[0];
            AssignAttri("", false, "A51WWPWebNotificationTitle", A51WWPWebNotificationTitle);
            A33WWPNotificationCreated = T000B6_A33WWPNotificationCreated[0];
            AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A69WWPNotificationMetadata = T000B6_A69WWPNotificationMetadata[0];
            n69WWPNotificationMetadata = T000B6_n69WWPNotificationMetadata[0];
            AssignAttri("", false, "A69WWPNotificationMetadata", A69WWPNotificationMetadata);
            A68WWPNotificationDefinitionName = T000B6_A68WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
            A52WWPWebNotificationText = T000B6_A52WWPWebNotificationText[0];
            AssignAttri("", false, "A52WWPWebNotificationText", A52WWPWebNotificationText);
            A53WWPWebNotificationIcon = T000B6_A53WWPWebNotificationIcon[0];
            AssignAttri("", false, "A53WWPWebNotificationIcon", A53WWPWebNotificationIcon);
            A62WWPWebNotificationClientId = T000B6_A62WWPWebNotificationClientId[0];
            AssignAttri("", false, "A62WWPWebNotificationClientId", A62WWPWebNotificationClientId);
            A63WWPWebNotificationStatus = T000B6_A63WWPWebNotificationStatus[0];
            AssignAttri("", false, "A63WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A63WWPWebNotificationStatus), 4, 0));
            A54WWPWebNotificationCreated = T000B6_A54WWPWebNotificationCreated[0];
            AssignAttri("", false, "A54WWPWebNotificationCreated", context.localUtil.TToC( A54WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A67WWPWebNotificationScheduled = T000B6_A67WWPWebNotificationScheduled[0];
            AssignAttri("", false, "A67WWPWebNotificationScheduled", context.localUtil.TToC( A67WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A64WWPWebNotificationProcessed = T000B6_A64WWPWebNotificationProcessed[0];
            AssignAttri("", false, "A64WWPWebNotificationProcessed", context.localUtil.TToC( A64WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A55WWPWebNotificationRead = T000B6_A55WWPWebNotificationRead[0];
            n55WWPWebNotificationRead = T000B6_n55WWPWebNotificationRead[0];
            AssignAttri("", false, "A55WWPWebNotificationRead", context.localUtil.TToC( A55WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A65WWPWebNotificationDetail = T000B6_A65WWPWebNotificationDetail[0];
            n65WWPWebNotificationDetail = T000B6_n65WWPWebNotificationDetail[0];
            AssignAttri("", false, "A65WWPWebNotificationDetail", A65WWPWebNotificationDetail);
            A66WWPWebNotificationReceived = T000B6_A66WWPWebNotificationReceived[0];
            n66WWPWebNotificationReceived = T000B6_n66WWPWebNotificationReceived[0];
            AssignAttri("", false, "A66WWPWebNotificationReceived", A66WWPWebNotificationReceived);
            A31WWPNotificationId = T000B6_A31WWPNotificationId[0];
            n31WWPNotificationId = T000B6_n31WWPNotificationId[0];
            AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
            ZM0B12( -9) ;
         }
         pr_default.close(4);
         OnLoadActions0B12( ) ;
      }

      protected void OnLoadActions0B12( )
      {
      }

      protected void CheckExtendedTable0B12( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000B4 */
         pr_default.execute(2, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A31WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A32WWPNotificationDefinitionId = T000B4_A32WWPNotificationDefinitionId[0];
         A33WWPNotificationCreated = T000B4_A33WWPNotificationCreated[0];
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A69WWPNotificationMetadata = T000B4_A69WWPNotificationMetadata[0];
         n69WWPNotificationMetadata = T000B4_n69WWPNotificationMetadata[0];
         AssignAttri("", false, "A69WWPNotificationMetadata", A69WWPNotificationMetadata);
         pr_default.close(2);
         /* Using cursor T000B5 */
         pr_default.execute(3, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A32WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A68WWPNotificationDefinitionName = T000B5_A68WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
         pr_default.close(3);
         if ( ! ( ( A63WWPWebNotificationStatus == 1 ) || ( A63WWPWebNotificationStatus == 2 ) || ( A63WWPWebNotificationStatus == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Web Notification Status", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPWEBNOTIFICATIONSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbWWPWebNotificationStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A54WWPWebNotificationCreated) || ( A54WWPWebNotificationCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Web Notification Created", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPWEBNOTIFICATIONCREATED");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationCreated_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A67WWPWebNotificationScheduled) || ( A67WWPWebNotificationScheduled >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Web Notification Scheduled", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPWEBNOTIFICATIONSCHEDULED");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationScheduled_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A64WWPWebNotificationProcessed) || ( A64WWPWebNotificationProcessed >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Web Notification Processed", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPWEBNOTIFICATIONPROCESSED");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationProcessed_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A55WWPWebNotificationRead) || ( A55WWPWebNotificationRead >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Web Notification Read", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPWEBNOTIFICATIONREAD");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationRead_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0B12( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_10( long A31WWPNotificationId )
      {
         /* Using cursor T000B7 */
         pr_default.execute(5, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A31WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A32WWPNotificationDefinitionId = T000B7_A32WWPNotificationDefinitionId[0];
         A33WWPNotificationCreated = T000B7_A33WWPNotificationCreated[0];
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A69WWPNotificationMetadata = T000B7_A69WWPNotificationMetadata[0];
         n69WWPNotificationMetadata = T000B7_n69WWPNotificationMetadata[0];
         AssignAttri("", false, "A69WWPNotificationMetadata", A69WWPNotificationMetadata);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A32WWPNotificationDefinitionId), 10, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))+"\""+","+"\""+GXUtil.EncodeJSConstant( A69WWPNotificationMetadata)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_11( long A32WWPNotificationDefinitionId )
      {
         /* Using cursor T000B8 */
         pr_default.execute(6, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A32WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A68WWPNotificationDefinitionName = T000B8_A68WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A68WWPNotificationDefinitionName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0B12( )
      {
         /* Using cursor T000B9 */
         pr_default.execute(7, new Object[] {A56WWPWebNotificationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000B3 */
         pr_default.execute(1, new Object[] {A56WWPWebNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B12( 9) ;
            RcdFound12 = 1;
            A56WWPWebNotificationId = T000B3_A56WWPWebNotificationId[0];
            AssignAttri("", false, "A56WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A56WWPWebNotificationId), 10, 0));
            A51WWPWebNotificationTitle = T000B3_A51WWPWebNotificationTitle[0];
            AssignAttri("", false, "A51WWPWebNotificationTitle", A51WWPWebNotificationTitle);
            A52WWPWebNotificationText = T000B3_A52WWPWebNotificationText[0];
            AssignAttri("", false, "A52WWPWebNotificationText", A52WWPWebNotificationText);
            A53WWPWebNotificationIcon = T000B3_A53WWPWebNotificationIcon[0];
            AssignAttri("", false, "A53WWPWebNotificationIcon", A53WWPWebNotificationIcon);
            A62WWPWebNotificationClientId = T000B3_A62WWPWebNotificationClientId[0];
            AssignAttri("", false, "A62WWPWebNotificationClientId", A62WWPWebNotificationClientId);
            A63WWPWebNotificationStatus = T000B3_A63WWPWebNotificationStatus[0];
            AssignAttri("", false, "A63WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A63WWPWebNotificationStatus), 4, 0));
            A54WWPWebNotificationCreated = T000B3_A54WWPWebNotificationCreated[0];
            AssignAttri("", false, "A54WWPWebNotificationCreated", context.localUtil.TToC( A54WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A67WWPWebNotificationScheduled = T000B3_A67WWPWebNotificationScheduled[0];
            AssignAttri("", false, "A67WWPWebNotificationScheduled", context.localUtil.TToC( A67WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A64WWPWebNotificationProcessed = T000B3_A64WWPWebNotificationProcessed[0];
            AssignAttri("", false, "A64WWPWebNotificationProcessed", context.localUtil.TToC( A64WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A55WWPWebNotificationRead = T000B3_A55WWPWebNotificationRead[0];
            n55WWPWebNotificationRead = T000B3_n55WWPWebNotificationRead[0];
            AssignAttri("", false, "A55WWPWebNotificationRead", context.localUtil.TToC( A55WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A65WWPWebNotificationDetail = T000B3_A65WWPWebNotificationDetail[0];
            n65WWPWebNotificationDetail = T000B3_n65WWPWebNotificationDetail[0];
            AssignAttri("", false, "A65WWPWebNotificationDetail", A65WWPWebNotificationDetail);
            A66WWPWebNotificationReceived = T000B3_A66WWPWebNotificationReceived[0];
            n66WWPWebNotificationReceived = T000B3_n66WWPWebNotificationReceived[0];
            AssignAttri("", false, "A66WWPWebNotificationReceived", A66WWPWebNotificationReceived);
            A31WWPNotificationId = T000B3_A31WWPNotificationId[0];
            n31WWPNotificationId = T000B3_n31WWPNotificationId[0];
            AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
            Z56WWPWebNotificationId = A56WWPWebNotificationId;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0B12( ) ;
            if ( AnyError == 1 )
            {
               RcdFound12 = 0;
               InitializeNonKey0B12( ) ;
            }
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0B12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B12( ) ;
         if ( RcdFound12 == 0 )
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
         RcdFound12 = 0;
         /* Using cursor T000B10 */
         pr_default.execute(8, new Object[] {A56WWPWebNotificationId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000B10_A56WWPWebNotificationId[0] < A56WWPWebNotificationId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000B10_A56WWPWebNotificationId[0] > A56WWPWebNotificationId ) ) )
            {
               A56WWPWebNotificationId = T000B10_A56WWPWebNotificationId[0];
               AssignAttri("", false, "A56WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A56WWPWebNotificationId), 10, 0));
               RcdFound12 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound12 = 0;
         /* Using cursor T000B11 */
         pr_default.execute(9, new Object[] {A56WWPWebNotificationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000B11_A56WWPWebNotificationId[0] > A56WWPWebNotificationId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000B11_A56WWPWebNotificationId[0] < A56WWPWebNotificationId ) ) )
            {
               A56WWPWebNotificationId = T000B11_A56WWPWebNotificationId[0];
               AssignAttri("", false, "A56WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A56WWPWebNotificationId), 10, 0));
               RcdFound12 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0B12( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0B12( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound12 == 1 )
            {
               if ( A56WWPWebNotificationId != Z56WWPWebNotificationId )
               {
                  A56WWPWebNotificationId = Z56WWPWebNotificationId;
                  AssignAttri("", false, "A56WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A56WWPWebNotificationId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPWEBNOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0B12( ) ;
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A56WWPWebNotificationId != Z56WWPWebNotificationId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0B12( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPWEBNOTIFICATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPWebNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPWebNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0B12( ) ;
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
         if ( A56WWPWebNotificationId != Z56WWPWebNotificationId )
         {
            A56WWPWebNotificationId = Z56WWPWebNotificationId;
            AssignAttri("", false, "A56WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A56WWPWebNotificationId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPWEBNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
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
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPWEBNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0B12( ) ;
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0B12( ) ;
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
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
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
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
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
         ScanStart0B12( ) ;
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound12 != 0 )
            {
               ScanNext0B12( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0B12( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0B12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000B2 */
            pr_default.execute(0, new Object[] {A56WWPWebNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z51WWPWebNotificationTitle, T000B2_A51WWPWebNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z52WWPWebNotificationText, T000B2_A52WWPWebNotificationText[0]) != 0 ) || ( StringUtil.StrCmp(Z53WWPWebNotificationIcon, T000B2_A53WWPWebNotificationIcon[0]) != 0 ) || ( Z63WWPWebNotificationStatus != T000B2_A63WWPWebNotificationStatus[0] ) || ( Z54WWPWebNotificationCreated != T000B2_A54WWPWebNotificationCreated[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z67WWPWebNotificationScheduled != T000B2_A67WWPWebNotificationScheduled[0] ) || ( Z64WWPWebNotificationProcessed != T000B2_A64WWPWebNotificationProcessed[0] ) || ( Z55WWPWebNotificationRead != T000B2_A55WWPWebNotificationRead[0] ) || ( Z66WWPWebNotificationReceived != T000B2_A66WWPWebNotificationReceived[0] ) || ( Z31WWPNotificationId != T000B2_A31WWPNotificationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z51WWPWebNotificationTitle, T000B2_A51WWPWebNotificationTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationTitle");
                  GXUtil.WriteLogRaw("Old: ",Z51WWPWebNotificationTitle);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A51WWPWebNotificationTitle[0]);
               }
               if ( StringUtil.StrCmp(Z52WWPWebNotificationText, T000B2_A52WWPWebNotificationText[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationText");
                  GXUtil.WriteLogRaw("Old: ",Z52WWPWebNotificationText);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A52WWPWebNotificationText[0]);
               }
               if ( StringUtil.StrCmp(Z53WWPWebNotificationIcon, T000B2_A53WWPWebNotificationIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationIcon");
                  GXUtil.WriteLogRaw("Old: ",Z53WWPWebNotificationIcon);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A53WWPWebNotificationIcon[0]);
               }
               if ( Z63WWPWebNotificationStatus != T000B2_A63WWPWebNotificationStatus[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationStatus");
                  GXUtil.WriteLogRaw("Old: ",Z63WWPWebNotificationStatus);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A63WWPWebNotificationStatus[0]);
               }
               if ( Z54WWPWebNotificationCreated != T000B2_A54WWPWebNotificationCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationCreated");
                  GXUtil.WriteLogRaw("Old: ",Z54WWPWebNotificationCreated);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A54WWPWebNotificationCreated[0]);
               }
               if ( Z67WWPWebNotificationScheduled != T000B2_A67WWPWebNotificationScheduled[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationScheduled");
                  GXUtil.WriteLogRaw("Old: ",Z67WWPWebNotificationScheduled);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A67WWPWebNotificationScheduled[0]);
               }
               if ( Z64WWPWebNotificationProcessed != T000B2_A64WWPWebNotificationProcessed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationProcessed");
                  GXUtil.WriteLogRaw("Old: ",Z64WWPWebNotificationProcessed);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A64WWPWebNotificationProcessed[0]);
               }
               if ( Z55WWPWebNotificationRead != T000B2_A55WWPWebNotificationRead[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationRead");
                  GXUtil.WriteLogRaw("Old: ",Z55WWPWebNotificationRead);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A55WWPWebNotificationRead[0]);
               }
               if ( Z66WWPWebNotificationReceived != T000B2_A66WWPWebNotificationReceived[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationReceived");
                  GXUtil.WriteLogRaw("Old: ",Z66WWPWebNotificationReceived);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A66WWPWebNotificationReceived[0]);
               }
               if ( Z31WWPNotificationId != T000B2_A31WWPNotificationId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPNotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z31WWPNotificationId);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A31WWPNotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B12( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B12( 0) ;
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B12 */
                     pr_default.execute(10, new Object[] {A51WWPWebNotificationTitle, A52WWPWebNotificationText, A53WWPWebNotificationIcon, A62WWPWebNotificationClientId, A63WWPWebNotificationStatus, A54WWPWebNotificationCreated, A67WWPWebNotificationScheduled, A64WWPWebNotificationProcessed, n55WWPWebNotificationRead, A55WWPWebNotificationRead, n65WWPWebNotificationDetail, A65WWPWebNotificationDetail, n66WWPWebNotificationReceived, A66WWPWebNotificationReceived, n31WWPNotificationId, A31WWPNotificationId});
                     A56WWPWebNotificationId = T000B12_A56WWPWebNotificationId[0];
                     AssignAttri("", false, "A56WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A56WWPWebNotificationId), 10, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0B0( ) ;
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
               Load0B12( ) ;
            }
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void Update0B12( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B13 */
                     pr_default.execute(11, new Object[] {A51WWPWebNotificationTitle, A52WWPWebNotificationText, A53WWPWebNotificationIcon, A62WWPWebNotificationClientId, A63WWPWebNotificationStatus, A54WWPWebNotificationCreated, A67WWPWebNotificationScheduled, A64WWPWebNotificationProcessed, n55WWPWebNotificationRead, A55WWPWebNotificationRead, n65WWPWebNotificationDetail, A65WWPWebNotificationDetail, n66WWPWebNotificationReceived, A66WWPWebNotificationReceived, n31WWPNotificationId, A31WWPNotificationId, A56WWPWebNotificationId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B12( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0B0( ) ;
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
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void DeferredUpdate0B12( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B12( ) ;
            AfterConfirm0B12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B12( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000B14 */
                  pr_default.execute(12, new Object[] {A56WWPWebNotificationId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound12 == 0 )
                        {
                           InitAll0B12( ) ;
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
                        ResetCaption0B0( ) ;
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
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0B12( ) ;
         Gx_mode = sMode12;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0B12( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000B15 */
            pr_default.execute(13, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
            A32WWPNotificationDefinitionId = T000B15_A32WWPNotificationDefinitionId[0];
            A33WWPNotificationCreated = T000B15_A33WWPNotificationCreated[0];
            AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A69WWPNotificationMetadata = T000B15_A69WWPNotificationMetadata[0];
            n69WWPNotificationMetadata = T000B15_n69WWPNotificationMetadata[0];
            AssignAttri("", false, "A69WWPNotificationMetadata", A69WWPNotificationMetadata);
            pr_default.close(13);
            /* Using cursor T000B16 */
            pr_default.execute(14, new Object[] {A32WWPNotificationDefinitionId});
            A68WWPNotificationDefinitionName = T000B16_A68WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
            pr_default.close(14);
         }
      }

      protected void EndLevel0B12( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("wwpbaseobjects.notifications.web.wwp_webnotification",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0B0( ) ;
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
            context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webnotification",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0B12( )
      {
         /* Using cursor T000B17 */
         pr_default.execute(15);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound12 = 1;
            A56WWPWebNotificationId = T000B17_A56WWPWebNotificationId[0];
            AssignAttri("", false, "A56WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A56WWPWebNotificationId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0B12( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound12 = 1;
            A56WWPWebNotificationId = T000B17_A56WWPWebNotificationId[0];
            AssignAttri("", false, "A56WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A56WWPWebNotificationId), 10, 0));
         }
      }

      protected void ScanEnd0B12( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0B12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B12( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B12( )
      {
         edtWWPWebNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationId_Enabled), 5, 0), true);
         edtWWPWebNotificationTitle_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationTitle_Enabled), 5, 0), true);
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
         edtWWPNotificationMetadata_Enabled = 0;
         AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionName_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionName_Enabled), 5, 0), true);
         edtWWPWebNotificationText_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationText_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationText_Enabled), 5, 0), true);
         edtWWPWebNotificationIcon_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationIcon_Enabled), 5, 0), true);
         edtWWPWebNotificationClientId_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationClientId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationClientId_Enabled), 5, 0), true);
         cmbWWPWebNotificationStatus.Enabled = 0;
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPWebNotificationStatus.Enabled), 5, 0), true);
         edtWWPWebNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationCreated_Enabled), 5, 0), true);
         edtWWPWebNotificationScheduled_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationScheduled_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationScheduled_Enabled), 5, 0), true);
         edtWWPWebNotificationProcessed_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationProcessed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationProcessed_Enabled), 5, 0), true);
         edtWWPWebNotificationRead_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationRead_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationRead_Enabled), 5, 0), true);
         edtWWPWebNotificationDetail_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationDetail_Enabled), 5, 0), true);
         chkWWPWebNotificationReceived.Enabled = 0;
         AssignProp("", false, chkWWPWebNotificationReceived_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPWebNotificationReceived.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0B12( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0B0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.web.wwp_webnotification.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z56WWPWebNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z56WWPWebNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z51WWPWebNotificationTitle", Z51WWPWebNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z52WWPWebNotificationText", Z52WWPWebNotificationText);
         GxWebStd.gx_hidden_field( context, "Z53WWPWebNotificationIcon", Z53WWPWebNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z63WWPWebNotificationStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z63WWPWebNotificationStatus), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z54WWPWebNotificationCreated", context.localUtil.TToC( Z54WWPWebNotificationCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z67WWPWebNotificationScheduled", context.localUtil.TToC( Z67WWPWebNotificationScheduled, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z64WWPWebNotificationProcessed", context.localUtil.TToC( Z64WWPWebNotificationProcessed, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z55WWPWebNotificationRead", context.localUtil.TToC( Z55WWPWebNotificationRead, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z66WWPWebNotificationReceived", Z66WWPWebNotificationReceived);
         GxWebStd.gx_hidden_field( context, "Z31WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A32WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("wwpbaseobjects.notifications.web.wwp_webnotification.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Web.WWP_WebNotification" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Web Notification", "") ;
      }

      protected void InitializeNonKey0B12( )
      {
         A32WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
         A51WWPWebNotificationTitle = "";
         AssignAttri("", false, "A51WWPWebNotificationTitle", A51WWPWebNotificationTitle);
         A31WWPNotificationId = 0;
         n31WWPNotificationId = false;
         AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
         n31WWPNotificationId = ((0==A31WWPNotificationId) ? true : false);
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A69WWPNotificationMetadata = "";
         n69WWPNotificationMetadata = false;
         AssignAttri("", false, "A69WWPNotificationMetadata", A69WWPNotificationMetadata);
         A68WWPNotificationDefinitionName = "";
         AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
         A52WWPWebNotificationText = "";
         AssignAttri("", false, "A52WWPWebNotificationText", A52WWPWebNotificationText);
         A53WWPWebNotificationIcon = "";
         AssignAttri("", false, "A53WWPWebNotificationIcon", A53WWPWebNotificationIcon);
         A62WWPWebNotificationClientId = "";
         AssignAttri("", false, "A62WWPWebNotificationClientId", A62WWPWebNotificationClientId);
         A64WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A64WWPWebNotificationProcessed", context.localUtil.TToC( A64WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A55WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         n55WWPWebNotificationRead = false;
         AssignAttri("", false, "A55WWPWebNotificationRead", context.localUtil.TToC( A55WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n55WWPWebNotificationRead = ((DateTime.MinValue==A55WWPWebNotificationRead) ? true : false);
         A65WWPWebNotificationDetail = "";
         n65WWPWebNotificationDetail = false;
         AssignAttri("", false, "A65WWPWebNotificationDetail", A65WWPWebNotificationDetail);
         n65WWPWebNotificationDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A65WWPWebNotificationDetail)) ? true : false);
         A66WWPWebNotificationReceived = false;
         n66WWPWebNotificationReceived = false;
         AssignAttri("", false, "A66WWPWebNotificationReceived", A66WWPWebNotificationReceived);
         n66WWPWebNotificationReceived = ((false==A66WWPWebNotificationReceived) ? true : false);
         A63WWPWebNotificationStatus = 1;
         AssignAttri("", false, "A63WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A63WWPWebNotificationStatus), 4, 0));
         A54WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A54WWPWebNotificationCreated", context.localUtil.TToC( A54WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A67WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A67WWPWebNotificationScheduled", context.localUtil.TToC( A67WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         Z51WWPWebNotificationTitle = "";
         Z52WWPWebNotificationText = "";
         Z53WWPWebNotificationIcon = "";
         Z63WWPWebNotificationStatus = 0;
         Z54WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z67WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z64WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z55WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         Z66WWPWebNotificationReceived = false;
         Z31WWPNotificationId = 0;
      }

      protected void InitAll0B12( )
      {
         A56WWPWebNotificationId = 0;
         AssignAttri("", false, "A56WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A56WWPWebNotificationId), 10, 0));
         InitializeNonKey0B12( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A63WWPWebNotificationStatus = i63WWPWebNotificationStatus;
         AssignAttri("", false, "A63WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A63WWPWebNotificationStatus), 4, 0));
         A54WWPWebNotificationCreated = i54WWPWebNotificationCreated;
         AssignAttri("", false, "A54WWPWebNotificationCreated", context.localUtil.TToC( A54WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A67WWPWebNotificationScheduled = i67WWPWebNotificationScheduled;
         AssignAttri("", false, "A67WWPWebNotificationScheduled", context.localUtil.TToC( A67WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302184492", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/web/wwp_webnotification.js", "?20267302184492", false, true, false);
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
         edtWWPWebNotificationId_Internalname = "WWPWEBNOTIFICATIONID";
         edtWWPWebNotificationTitle_Internalname = "WWPWEBNOTIFICATIONTITLE";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA";
         edtWWPNotificationDefinitionName_Internalname = "WWPNOTIFICATIONDEFINITIONNAME";
         edtWWPWebNotificationText_Internalname = "WWPWEBNOTIFICATIONTEXT";
         edtWWPWebNotificationIcon_Internalname = "WWPWEBNOTIFICATIONICON";
         edtWWPWebNotificationClientId_Internalname = "WWPWEBNOTIFICATIONCLIENTID";
         cmbWWPWebNotificationStatus_Internalname = "WWPWEBNOTIFICATIONSTATUS";
         edtWWPWebNotificationCreated_Internalname = "WWPWEBNOTIFICATIONCREATED";
         edtWWPWebNotificationScheduled_Internalname = "WWPWEBNOTIFICATIONSCHEDULED";
         edtWWPWebNotificationProcessed_Internalname = "WWPWEBNOTIFICATIONPROCESSED";
         edtWWPWebNotificationRead_Internalname = "WWPWEBNOTIFICATIONREAD";
         edtWWPWebNotificationDetail_Internalname = "WWPWEBNOTIFICATIONDETAIL";
         chkWWPWebNotificationReceived_Internalname = "WWPWEBNOTIFICATIONRECEIVED";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_31_Internalname = "PROMPT_31";
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
         Form.Caption = context.GetMessage( "WWP_Web Notification", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkWWPWebNotificationReceived.Enabled = 1;
         edtWWPWebNotificationDetail_Enabled = 1;
         edtWWPWebNotificationRead_Jsonclick = "";
         edtWWPWebNotificationRead_Enabled = 1;
         edtWWPWebNotificationProcessed_Jsonclick = "";
         edtWWPWebNotificationProcessed_Enabled = 1;
         edtWWPWebNotificationScheduled_Jsonclick = "";
         edtWWPWebNotificationScheduled_Enabled = 1;
         edtWWPWebNotificationCreated_Jsonclick = "";
         edtWWPWebNotificationCreated_Enabled = 1;
         cmbWWPWebNotificationStatus_Jsonclick = "";
         cmbWWPWebNotificationStatus.Enabled = 1;
         edtWWPWebNotificationClientId_Enabled = 1;
         edtWWPWebNotificationIcon_Enabled = 1;
         edtWWPWebNotificationText_Jsonclick = "";
         edtWWPWebNotificationText_Enabled = 1;
         edtWWPNotificationDefinitionName_Jsonclick = "";
         edtWWPNotificationDefinitionName_Enabled = 0;
         edtWWPNotificationMetadata_Enabled = 0;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 0;
         imgprompt_31_Visible = 1;
         imgprompt_31_Link = "";
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
         edtWWPWebNotificationTitle_Jsonclick = "";
         edtWWPWebNotificationTitle_Enabled = 1;
         edtWWPWebNotificationId_Jsonclick = "";
         edtWWPWebNotificationId_Enabled = 1;
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
         cmbWWPWebNotificationStatus.Name = "WWPWEBNOTIFICATIONSTATUS";
         cmbWWPWebNotificationStatus.WebTags = "";
         cmbWWPWebNotificationStatus.addItem("1", context.GetMessage( "Pending", ""), 0);
         cmbWWPWebNotificationStatus.addItem("2", context.GetMessage( "Sent", ""), 0);
         cmbWWPWebNotificationStatus.addItem("3", context.GetMessage( "Error", ""), 0);
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A63WWPWebNotificationStatus) )
            {
               A63WWPWebNotificationStatus = 1;
               AssignAttri("", false, "A63WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A63WWPWebNotificationStatus), 4, 0));
            }
         }
         chkWWPWebNotificationReceived.Name = "WWPWEBNOTIFICATIONRECEIVED";
         chkWWPWebNotificationReceived.WebTags = "";
         chkWWPWebNotificationReceived.Caption = context.GetMessage( "Notification Received", "");
         AssignProp("", false, chkWWPWebNotificationReceived_Internalname, "TitleCaption", chkWWPWebNotificationReceived.Caption, true);
         chkWWPWebNotificationReceived.CheckedValue = "false";
         A66WWPWebNotificationReceived = StringUtil.StrToBool( StringUtil.BoolToStr( A66WWPWebNotificationReceived));
         n66WWPWebNotificationReceived = false;
         AssignAttri("", false, "A66WWPWebNotificationReceived", A66WWPWebNotificationReceived);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
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

      public void Valid_Wwpwebnotificationid( )
      {
         A63WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPWebNotificationStatus.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPWebNotificationStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A63WWPWebNotificationStatus), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            A63WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPWebNotificationStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A63WWPWebNotificationStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A63WWPWebNotificationStatus), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A63WWPWebNotificationStatus), 4, 0));
         }
         A66WWPWebNotificationReceived = StringUtil.StrToBool( StringUtil.BoolToStr( A66WWPWebNotificationReceived));
         n66WWPWebNotificationReceived = false;
         /*  Sending validation outputs */
         AssignAttri("", false, "A51WWPWebNotificationTitle", A51WWPWebNotificationTitle);
         AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A31WWPNotificationId), 10, 0, ".", "")));
         AssignAttri("", false, "A52WWPWebNotificationText", A52WWPWebNotificationText);
         AssignAttri("", false, "A53WWPWebNotificationIcon", A53WWPWebNotificationIcon);
         AssignAttri("", false, "A62WWPWebNotificationClientId", A62WWPWebNotificationClientId);
         AssignAttri("", false, "A63WWPWebNotificationStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(A63WWPWebNotificationStatus), 4, 0, ".", "")));
         cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A63WWPWebNotificationStatus), 4, 0));
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", cmbWWPWebNotificationStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A54WWPWebNotificationCreated", context.localUtil.TToC( A54WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A67WWPWebNotificationScheduled", context.localUtil.TToC( A67WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A64WWPWebNotificationProcessed", context.localUtil.TToC( A64WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A55WWPWebNotificationRead", context.localUtil.TToC( A55WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A65WWPWebNotificationDetail", A65WWPWebNotificationDetail);
         AssignAttri("", false, "A66WWPWebNotificationReceived", A66WWPWebNotificationReceived);
         AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A32WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A69WWPNotificationMetadata", A69WWPNotificationMetadata);
         AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z56WWPWebNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z56WWPWebNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z51WWPWebNotificationTitle", Z51WWPWebNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z31WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z52WWPWebNotificationText", Z52WWPWebNotificationText);
         GxWebStd.gx_hidden_field( context, "Z53WWPWebNotificationIcon", Z53WWPWebNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z62WWPWebNotificationClientId", Z62WWPWebNotificationClientId);
         GxWebStd.gx_hidden_field( context, "Z63WWPWebNotificationStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z63WWPWebNotificationStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z54WWPWebNotificationCreated", context.localUtil.TToC( Z54WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z67WWPWebNotificationScheduled", context.localUtil.TToC( Z67WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z64WWPWebNotificationProcessed", context.localUtil.TToC( Z64WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z55WWPWebNotificationRead", context.localUtil.TToC( Z55WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z65WWPWebNotificationDetail", Z65WWPWebNotificationDetail);
         GxWebStd.gx_hidden_field( context, "Z66WWPWebNotificationReceived", StringUtil.BoolToStr( Z66WWPWebNotificationReceived));
         GxWebStd.gx_hidden_field( context, "Z32WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z32WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z33WWPNotificationCreated", context.localUtil.TToC( Z33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z69WWPNotificationMetadata", Z69WWPNotificationMetadata);
         GxWebStd.gx_hidden_field( context, "Z68WWPNotificationDefinitionName", Z68WWPNotificationDefinitionName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationid( )
      {
         n31WWPNotificationId = false;
         n69WWPNotificationMetadata = false;
         /* Using cursor T000B15 */
         pr_default.execute(13, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A31WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
            }
         }
         A32WWPNotificationDefinitionId = T000B15_A32WWPNotificationDefinitionId[0];
         A33WWPNotificationCreated = T000B15_A33WWPNotificationCreated[0];
         A69WWPNotificationMetadata = T000B15_A69WWPNotificationMetadata[0];
         n69WWPNotificationMetadata = T000B15_n69WWPNotificationMetadata[0];
         pr_default.close(13);
         /* Using cursor T000B16 */
         pr_default.execute(14, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A32WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A68WWPNotificationDefinitionName = T000B16_A68WWPNotificationDefinitionName[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A32WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A69WWPNotificationMetadata", A69WWPNotificationMetadata);
         AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONID","{handler:'Valid_Wwpwebnotificationid',iparms:[{av:'A56WWPWebNotificationId',fld:'WWPWEBNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'cmbWWPWebNotificationStatus'},{av:'A63WWPWebNotificationStatus',fld:'WWPWEBNOTIFICATIONSTATUS',pic:'ZZZ9',type:'int'},{av:'A54WWPWebNotificationCreated',fld:'WWPWEBNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A67WWPWebNotificationScheduled',fld:'WWPWEBNOTIFICATIONSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONID",",oparms:[{av:'A51WWPWebNotificationTitle',fld:'WWPWEBNOTIFICATIONTITLE',pic:'',type:'svchar'},{av:'A31WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A52WWPWebNotificationText',fld:'WWPWEBNOTIFICATIONTEXT',pic:'',type:'svchar'},{av:'A53WWPWebNotificationIcon',fld:'WWPWEBNOTIFICATIONICON',pic:'',type:'svchar'},{av:'A62WWPWebNotificationClientId',fld:'WWPWEBNOTIFICATIONCLIENTID',pic:'',type:'vchar'},{av:'cmbWWPWebNotificationStatus'},{av:'A63WWPWebNotificationStatus',fld:'WWPWEBNOTIFICATIONSTATUS',pic:'ZZZ9',type:'int'},{av:'A54WWPWebNotificationCreated',fld:'WWPWEBNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A67WWPWebNotificationScheduled',fld:'WWPWEBNOTIFICATIONSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A64WWPWebNotificationProcessed',fld:'WWPWEBNOTIFICATIONPROCESSED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A55WWPWebNotificationRead',fld:'WWPWEBNOTIFICATIONREAD',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A65WWPWebNotificationDetail',fld:'WWPWEBNOTIFICATIONDETAIL',pic:'',type:'vchar'},{av:'A32WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A33WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A69WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:'',type:'vchar'},{av:'A68WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:'',type:'svchar'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z56WWPWebNotificationId',type:'int'},{av:'Z51WWPWebNotificationTitle',type:'svchar'},{av:'Z31WWPNotificationId',type:'int'},{av:'Z52WWPWebNotificationText',type:'svchar'},{av:'Z53WWPWebNotificationIcon',type:'svchar'},{av:'Z62WWPWebNotificationClientId',type:'vchar'},{av:'Z63WWPWebNotificationStatus',type:'int'},{av:'Z54WWPWebNotificationCreated',type:'dtime'},{av:'Z67WWPWebNotificationScheduled',type:'dtime'},{av:'Z64WWPWebNotificationProcessed',type:'dtime'},{av:'Z55WWPWebNotificationRead',type:'dtime'},{av:'Z65WWPWebNotificationDetail',type:'vchar'},{av:'Z66WWPWebNotificationReceived',type:'boolean'},{av:'Z32WWPNotificationDefinitionId',type:'int'},{av:'Z33WWPNotificationCreated',type:'dtime'},{av:'Z69WWPNotificationMetadata',type:'vchar'},{av:'Z68WWPNotificationDefinitionName',type:'svchar'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONID","{handler:'Valid_Wwpnotificationid',iparms:[{av:'A31WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A32WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A33WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A69WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:'',type:'vchar'},{av:'A68WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:'',type:'svchar'},{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONID",",oparms:[{av:'A32WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A33WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A69WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:'',type:'vchar'},{av:'A68WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:'',type:'svchar'},{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONSTATUS","{handler:'Valid_Wwpwebnotificationstatus',iparms:[{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONSTATUS",",oparms:[{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONCREATED","{handler:'Valid_Wwpwebnotificationcreated',iparms:[{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONCREATED",",oparms:[{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONSCHEDULED","{handler:'Valid_Wwpwebnotificationscheduled',iparms:[{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONSCHEDULED",",oparms:[{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONPROCESSED","{handler:'Valid_Wwpwebnotificationprocessed',iparms:[{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONPROCESSED",",oparms:[{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONREAD","{handler:'Valid_Wwpwebnotificationread',iparms:[{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONREAD",",oparms:[{av:'A66WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:'',type:'boolean'}]}");
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
         Z51WWPWebNotificationTitle = "";
         Z52WWPWebNotificationText = "";
         Z53WWPWebNotificationIcon = "";
         Z54WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z67WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z64WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z55WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         A51WWPWebNotificationTitle = "";
         imgprompt_31_gximage = "";
         sImgUrl = "";
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A69WWPNotificationMetadata = "";
         A68WWPNotificationDefinitionName = "";
         A52WWPWebNotificationText = "";
         A53WWPWebNotificationIcon = "";
         A62WWPWebNotificationClientId = "";
         A54WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         A67WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         A64WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         A55WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         A65WWPWebNotificationDetail = "";
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
         Z62WWPWebNotificationClientId = "";
         Z65WWPWebNotificationDetail = "";
         Z33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z69WWPNotificationMetadata = "";
         Z68WWPNotificationDefinitionName = "";
         T000B6_A32WWPNotificationDefinitionId = new long[1] ;
         T000B6_A56WWPWebNotificationId = new long[1] ;
         T000B6_A51WWPWebNotificationTitle = new string[] {""} ;
         T000B6_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000B6_A69WWPNotificationMetadata = new string[] {""} ;
         T000B6_n69WWPNotificationMetadata = new bool[] {false} ;
         T000B6_A68WWPNotificationDefinitionName = new string[] {""} ;
         T000B6_A52WWPWebNotificationText = new string[] {""} ;
         T000B6_A53WWPWebNotificationIcon = new string[] {""} ;
         T000B6_A62WWPWebNotificationClientId = new string[] {""} ;
         T000B6_A63WWPWebNotificationStatus = new short[1] ;
         T000B6_A54WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000B6_A67WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         T000B6_A64WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         T000B6_A55WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         T000B6_n55WWPWebNotificationRead = new bool[] {false} ;
         T000B6_A65WWPWebNotificationDetail = new string[] {""} ;
         T000B6_n65WWPWebNotificationDetail = new bool[] {false} ;
         T000B6_A66WWPWebNotificationReceived = new bool[] {false} ;
         T000B6_n66WWPWebNotificationReceived = new bool[] {false} ;
         T000B6_A31WWPNotificationId = new long[1] ;
         T000B6_n31WWPNotificationId = new bool[] {false} ;
         T000B4_A32WWPNotificationDefinitionId = new long[1] ;
         T000B4_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000B4_A69WWPNotificationMetadata = new string[] {""} ;
         T000B4_n69WWPNotificationMetadata = new bool[] {false} ;
         T000B5_A68WWPNotificationDefinitionName = new string[] {""} ;
         T000B7_A32WWPNotificationDefinitionId = new long[1] ;
         T000B7_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000B7_A69WWPNotificationMetadata = new string[] {""} ;
         T000B7_n69WWPNotificationMetadata = new bool[] {false} ;
         T000B8_A68WWPNotificationDefinitionName = new string[] {""} ;
         T000B9_A56WWPWebNotificationId = new long[1] ;
         T000B3_A56WWPWebNotificationId = new long[1] ;
         T000B3_A51WWPWebNotificationTitle = new string[] {""} ;
         T000B3_A52WWPWebNotificationText = new string[] {""} ;
         T000B3_A53WWPWebNotificationIcon = new string[] {""} ;
         T000B3_A62WWPWebNotificationClientId = new string[] {""} ;
         T000B3_A63WWPWebNotificationStatus = new short[1] ;
         T000B3_A54WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000B3_A67WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         T000B3_A64WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         T000B3_A55WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         T000B3_n55WWPWebNotificationRead = new bool[] {false} ;
         T000B3_A65WWPWebNotificationDetail = new string[] {""} ;
         T000B3_n65WWPWebNotificationDetail = new bool[] {false} ;
         T000B3_A66WWPWebNotificationReceived = new bool[] {false} ;
         T000B3_n66WWPWebNotificationReceived = new bool[] {false} ;
         T000B3_A31WWPNotificationId = new long[1] ;
         T000B3_n31WWPNotificationId = new bool[] {false} ;
         sMode12 = "";
         T000B10_A56WWPWebNotificationId = new long[1] ;
         T000B11_A56WWPWebNotificationId = new long[1] ;
         T000B2_A56WWPWebNotificationId = new long[1] ;
         T000B2_A51WWPWebNotificationTitle = new string[] {""} ;
         T000B2_A52WWPWebNotificationText = new string[] {""} ;
         T000B2_A53WWPWebNotificationIcon = new string[] {""} ;
         T000B2_A62WWPWebNotificationClientId = new string[] {""} ;
         T000B2_A63WWPWebNotificationStatus = new short[1] ;
         T000B2_A54WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000B2_A67WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         T000B2_A64WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         T000B2_A55WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         T000B2_n55WWPWebNotificationRead = new bool[] {false} ;
         T000B2_A65WWPWebNotificationDetail = new string[] {""} ;
         T000B2_n65WWPWebNotificationDetail = new bool[] {false} ;
         T000B2_A66WWPWebNotificationReceived = new bool[] {false} ;
         T000B2_n66WWPWebNotificationReceived = new bool[] {false} ;
         T000B2_A31WWPNotificationId = new long[1] ;
         T000B2_n31WWPNotificationId = new bool[] {false} ;
         T000B12_A56WWPWebNotificationId = new long[1] ;
         T000B15_A32WWPNotificationDefinitionId = new long[1] ;
         T000B15_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000B15_A69WWPNotificationMetadata = new string[] {""} ;
         T000B15_n69WWPNotificationMetadata = new bool[] {false} ;
         T000B16_A68WWPNotificationDefinitionName = new string[] {""} ;
         T000B17_A56WWPWebNotificationId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i54WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         i67WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         ZZ51WWPWebNotificationTitle = "";
         ZZ52WWPWebNotificationText = "";
         ZZ53WWPWebNotificationIcon = "";
         ZZ62WWPWebNotificationClientId = "";
         ZZ54WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ67WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         ZZ64WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         ZZ55WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         ZZ65WWPWebNotificationDetail = "";
         ZZ33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ69WWPNotificationMetadata = "";
         ZZ68WWPNotificationDefinitionName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification__default(),
            new Object[][] {
                new Object[] {
               T000B2_A56WWPWebNotificationId, T000B2_A51WWPWebNotificationTitle, T000B2_A52WWPWebNotificationText, T000B2_A53WWPWebNotificationIcon, T000B2_A62WWPWebNotificationClientId, T000B2_A63WWPWebNotificationStatus, T000B2_A54WWPWebNotificationCreated, T000B2_A67WWPWebNotificationScheduled, T000B2_A64WWPWebNotificationProcessed, T000B2_A55WWPWebNotificationRead,
               T000B2_n55WWPWebNotificationRead, T000B2_A65WWPWebNotificationDetail, T000B2_n65WWPWebNotificationDetail, T000B2_A66WWPWebNotificationReceived, T000B2_n66WWPWebNotificationReceived, T000B2_A31WWPNotificationId, T000B2_n31WWPNotificationId
               }
               , new Object[] {
               T000B3_A56WWPWebNotificationId, T000B3_A51WWPWebNotificationTitle, T000B3_A52WWPWebNotificationText, T000B3_A53WWPWebNotificationIcon, T000B3_A62WWPWebNotificationClientId, T000B3_A63WWPWebNotificationStatus, T000B3_A54WWPWebNotificationCreated, T000B3_A67WWPWebNotificationScheduled, T000B3_A64WWPWebNotificationProcessed, T000B3_A55WWPWebNotificationRead,
               T000B3_n55WWPWebNotificationRead, T000B3_A65WWPWebNotificationDetail, T000B3_n65WWPWebNotificationDetail, T000B3_A66WWPWebNotificationReceived, T000B3_n66WWPWebNotificationReceived, T000B3_A31WWPNotificationId, T000B3_n31WWPNotificationId
               }
               , new Object[] {
               T000B4_A32WWPNotificationDefinitionId, T000B4_A33WWPNotificationCreated, T000B4_A69WWPNotificationMetadata, T000B4_n69WWPNotificationMetadata
               }
               , new Object[] {
               T000B5_A68WWPNotificationDefinitionName
               }
               , new Object[] {
               T000B6_A32WWPNotificationDefinitionId, T000B6_A56WWPWebNotificationId, T000B6_A51WWPWebNotificationTitle, T000B6_A33WWPNotificationCreated, T000B6_A69WWPNotificationMetadata, T000B6_n69WWPNotificationMetadata, T000B6_A68WWPNotificationDefinitionName, T000B6_A52WWPWebNotificationText, T000B6_A53WWPWebNotificationIcon, T000B6_A62WWPWebNotificationClientId,
               T000B6_A63WWPWebNotificationStatus, T000B6_A54WWPWebNotificationCreated, T000B6_A67WWPWebNotificationScheduled, T000B6_A64WWPWebNotificationProcessed, T000B6_A55WWPWebNotificationRead, T000B6_n55WWPWebNotificationRead, T000B6_A65WWPWebNotificationDetail, T000B6_n65WWPWebNotificationDetail, T000B6_A66WWPWebNotificationReceived, T000B6_n66WWPWebNotificationReceived,
               T000B6_A31WWPNotificationId, T000B6_n31WWPNotificationId
               }
               , new Object[] {
               T000B7_A32WWPNotificationDefinitionId, T000B7_A33WWPNotificationCreated, T000B7_A69WWPNotificationMetadata, T000B7_n69WWPNotificationMetadata
               }
               , new Object[] {
               T000B8_A68WWPNotificationDefinitionName
               }
               , new Object[] {
               T000B9_A56WWPWebNotificationId
               }
               , new Object[] {
               T000B10_A56WWPWebNotificationId
               }
               , new Object[] {
               T000B11_A56WWPWebNotificationId
               }
               , new Object[] {
               T000B12_A56WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000B15_A32WWPNotificationDefinitionId, T000B15_A33WWPNotificationCreated, T000B15_A69WWPNotificationMetadata, T000B15_n69WWPNotificationMetadata
               }
               , new Object[] {
               T000B16_A68WWPNotificationDefinitionName
               }
               , new Object[] {
               T000B17_A56WWPWebNotificationId
               }
            }
         );
         Z67WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A67WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i67WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z54WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A54WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i54WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z63WWPWebNotificationStatus = 1;
         A63WWPWebNotificationStatus = 1;
         i63WWPWebNotificationStatus = 1;
      }

      private short Z63WWPWebNotificationStatus ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A63WWPWebNotificationStatus ;
      private short Gx_BScreen ;
      private short RcdFound12 ;
      private short gxajaxcallmode ;
      private short i63WWPWebNotificationStatus ;
      private short ZZ63WWPWebNotificationStatus ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPWebNotificationId_Enabled ;
      private int edtWWPWebNotificationTitle_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int imgprompt_31_Visible ;
      private int edtWWPNotificationCreated_Enabled ;
      private int edtWWPNotificationMetadata_Enabled ;
      private int edtWWPNotificationDefinitionName_Enabled ;
      private int edtWWPWebNotificationText_Enabled ;
      private int edtWWPWebNotificationIcon_Enabled ;
      private int edtWWPWebNotificationClientId_Enabled ;
      private int edtWWPWebNotificationCreated_Enabled ;
      private int edtWWPWebNotificationScheduled_Enabled ;
      private int edtWWPWebNotificationProcessed_Enabled ;
      private int edtWWPWebNotificationRead_Enabled ;
      private int edtWWPWebNotificationDetail_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z56WWPWebNotificationId ;
      private long Z31WWPNotificationId ;
      private long A31WWPNotificationId ;
      private long A32WWPNotificationDefinitionId ;
      private long A56WWPWebNotificationId ;
      private long Z32WWPNotificationDefinitionId ;
      private long ZZ56WWPWebNotificationId ;
      private long ZZ31WWPNotificationId ;
      private long ZZ32WWPNotificationDefinitionId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPWebNotificationId_Internalname ;
      private string cmbWWPWebNotificationStatus_Internalname ;
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
      private string edtWWPWebNotificationId_Jsonclick ;
      private string edtWWPWebNotificationTitle_Internalname ;
      private string edtWWPWebNotificationTitle_Jsonclick ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string imgprompt_31_gximage ;
      private string sImgUrl ;
      private string imgprompt_31_Internalname ;
      private string imgprompt_31_Link ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string edtWWPNotificationMetadata_Internalname ;
      private string edtWWPNotificationDefinitionName_Internalname ;
      private string edtWWPNotificationDefinitionName_Jsonclick ;
      private string edtWWPWebNotificationText_Internalname ;
      private string edtWWPWebNotificationText_Jsonclick ;
      private string edtWWPWebNotificationIcon_Internalname ;
      private string edtWWPWebNotificationClientId_Internalname ;
      private string cmbWWPWebNotificationStatus_Jsonclick ;
      private string edtWWPWebNotificationCreated_Internalname ;
      private string edtWWPWebNotificationCreated_Jsonclick ;
      private string edtWWPWebNotificationScheduled_Internalname ;
      private string edtWWPWebNotificationScheduled_Jsonclick ;
      private string edtWWPWebNotificationProcessed_Internalname ;
      private string edtWWPWebNotificationProcessed_Jsonclick ;
      private string edtWWPWebNotificationRead_Internalname ;
      private string edtWWPWebNotificationRead_Jsonclick ;
      private string edtWWPWebNotificationDetail_Internalname ;
      private string chkWWPWebNotificationReceived_Internalname ;
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
      private string sMode12 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z54WWPWebNotificationCreated ;
      private DateTime Z67WWPWebNotificationScheduled ;
      private DateTime Z64WWPWebNotificationProcessed ;
      private DateTime Z55WWPWebNotificationRead ;
      private DateTime A33WWPNotificationCreated ;
      private DateTime A54WWPWebNotificationCreated ;
      private DateTime A67WWPWebNotificationScheduled ;
      private DateTime A64WWPWebNotificationProcessed ;
      private DateTime A55WWPWebNotificationRead ;
      private DateTime Z33WWPNotificationCreated ;
      private DateTime i54WWPWebNotificationCreated ;
      private DateTime i67WWPWebNotificationScheduled ;
      private DateTime ZZ54WWPWebNotificationCreated ;
      private DateTime ZZ67WWPWebNotificationScheduled ;
      private DateTime ZZ64WWPWebNotificationProcessed ;
      private DateTime ZZ55WWPWebNotificationRead ;
      private DateTime ZZ33WWPNotificationCreated ;
      private bool Z66WWPWebNotificationReceived ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n31WWPNotificationId ;
      private bool wbErr ;
      private bool A66WWPWebNotificationReceived ;
      private bool n66WWPWebNotificationReceived ;
      private bool n55WWPWebNotificationRead ;
      private bool n69WWPNotificationMetadata ;
      private bool n65WWPWebNotificationDetail ;
      private bool Gx_longc ;
      private bool ZZ66WWPWebNotificationReceived ;
      private string A69WWPNotificationMetadata ;
      private string A62WWPWebNotificationClientId ;
      private string A65WWPWebNotificationDetail ;
      private string Z62WWPWebNotificationClientId ;
      private string Z65WWPWebNotificationDetail ;
      private string Z69WWPNotificationMetadata ;
      private string ZZ62WWPWebNotificationClientId ;
      private string ZZ65WWPWebNotificationDetail ;
      private string ZZ69WWPNotificationMetadata ;
      private string Z51WWPWebNotificationTitle ;
      private string Z52WWPWebNotificationText ;
      private string Z53WWPWebNotificationIcon ;
      private string A51WWPWebNotificationTitle ;
      private string A68WWPNotificationDefinitionName ;
      private string A52WWPWebNotificationText ;
      private string A53WWPWebNotificationIcon ;
      private string Z68WWPNotificationDefinitionName ;
      private string ZZ51WWPWebNotificationTitle ;
      private string ZZ52WWPWebNotificationText ;
      private string ZZ53WWPWebNotificationIcon ;
      private string ZZ68WWPNotificationDefinitionName ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPWebNotificationStatus ;
      private GXCheckbox chkWWPWebNotificationReceived ;
      private IDataStoreProvider pr_default ;
      private long[] T000B6_A32WWPNotificationDefinitionId ;
      private long[] T000B6_A56WWPWebNotificationId ;
      private string[] T000B6_A51WWPWebNotificationTitle ;
      private DateTime[] T000B6_A33WWPNotificationCreated ;
      private string[] T000B6_A69WWPNotificationMetadata ;
      private bool[] T000B6_n69WWPNotificationMetadata ;
      private string[] T000B6_A68WWPNotificationDefinitionName ;
      private string[] T000B6_A52WWPWebNotificationText ;
      private string[] T000B6_A53WWPWebNotificationIcon ;
      private string[] T000B6_A62WWPWebNotificationClientId ;
      private short[] T000B6_A63WWPWebNotificationStatus ;
      private DateTime[] T000B6_A54WWPWebNotificationCreated ;
      private DateTime[] T000B6_A67WWPWebNotificationScheduled ;
      private DateTime[] T000B6_A64WWPWebNotificationProcessed ;
      private DateTime[] T000B6_A55WWPWebNotificationRead ;
      private bool[] T000B6_n55WWPWebNotificationRead ;
      private string[] T000B6_A65WWPWebNotificationDetail ;
      private bool[] T000B6_n65WWPWebNotificationDetail ;
      private bool[] T000B6_A66WWPWebNotificationReceived ;
      private bool[] T000B6_n66WWPWebNotificationReceived ;
      private long[] T000B6_A31WWPNotificationId ;
      private bool[] T000B6_n31WWPNotificationId ;
      private long[] T000B4_A32WWPNotificationDefinitionId ;
      private DateTime[] T000B4_A33WWPNotificationCreated ;
      private string[] T000B4_A69WWPNotificationMetadata ;
      private bool[] T000B4_n69WWPNotificationMetadata ;
      private string[] T000B5_A68WWPNotificationDefinitionName ;
      private long[] T000B7_A32WWPNotificationDefinitionId ;
      private DateTime[] T000B7_A33WWPNotificationCreated ;
      private string[] T000B7_A69WWPNotificationMetadata ;
      private bool[] T000B7_n69WWPNotificationMetadata ;
      private string[] T000B8_A68WWPNotificationDefinitionName ;
      private long[] T000B9_A56WWPWebNotificationId ;
      private long[] T000B3_A56WWPWebNotificationId ;
      private string[] T000B3_A51WWPWebNotificationTitle ;
      private string[] T000B3_A52WWPWebNotificationText ;
      private string[] T000B3_A53WWPWebNotificationIcon ;
      private string[] T000B3_A62WWPWebNotificationClientId ;
      private short[] T000B3_A63WWPWebNotificationStatus ;
      private DateTime[] T000B3_A54WWPWebNotificationCreated ;
      private DateTime[] T000B3_A67WWPWebNotificationScheduled ;
      private DateTime[] T000B3_A64WWPWebNotificationProcessed ;
      private DateTime[] T000B3_A55WWPWebNotificationRead ;
      private bool[] T000B3_n55WWPWebNotificationRead ;
      private string[] T000B3_A65WWPWebNotificationDetail ;
      private bool[] T000B3_n65WWPWebNotificationDetail ;
      private bool[] T000B3_A66WWPWebNotificationReceived ;
      private bool[] T000B3_n66WWPWebNotificationReceived ;
      private long[] T000B3_A31WWPNotificationId ;
      private bool[] T000B3_n31WWPNotificationId ;
      private long[] T000B10_A56WWPWebNotificationId ;
      private long[] T000B11_A56WWPWebNotificationId ;
      private long[] T000B2_A56WWPWebNotificationId ;
      private string[] T000B2_A51WWPWebNotificationTitle ;
      private string[] T000B2_A52WWPWebNotificationText ;
      private string[] T000B2_A53WWPWebNotificationIcon ;
      private string[] T000B2_A62WWPWebNotificationClientId ;
      private short[] T000B2_A63WWPWebNotificationStatus ;
      private DateTime[] T000B2_A54WWPWebNotificationCreated ;
      private DateTime[] T000B2_A67WWPWebNotificationScheduled ;
      private DateTime[] T000B2_A64WWPWebNotificationProcessed ;
      private DateTime[] T000B2_A55WWPWebNotificationRead ;
      private bool[] T000B2_n55WWPWebNotificationRead ;
      private string[] T000B2_A65WWPWebNotificationDetail ;
      private bool[] T000B2_n65WWPWebNotificationDetail ;
      private bool[] T000B2_A66WWPWebNotificationReceived ;
      private bool[] T000B2_n66WWPWebNotificationReceived ;
      private long[] T000B2_A31WWPNotificationId ;
      private bool[] T000B2_n31WWPNotificationId ;
      private long[] T000B12_A56WWPWebNotificationId ;
      private long[] T000B15_A32WWPNotificationDefinitionId ;
      private DateTime[] T000B15_A33WWPNotificationCreated ;
      private string[] T000B15_A69WWPNotificationMetadata ;
      private bool[] T000B15_n69WWPNotificationMetadata ;
      private string[] T000B16_A68WWPNotificationDefinitionName ;
      private long[] T000B17_A56WWPWebNotificationId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_webnotification__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webnotification__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000B2;
        prmT000B2 = new Object[] {
        new ParDef("@WWPWebNotificationId",GXType.Decimal,10,0)
        };
        Object[] prmT000B3;
        prmT000B3 = new Object[] {
        new ParDef("@WWPWebNotificationId",GXType.Decimal,10,0)
        };
        Object[] prmT000B4;
        prmT000B4 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000B5;
        prmT000B5 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000B6;
        prmT000B6 = new Object[] {
        new ParDef("@WWPWebNotificationId",GXType.Decimal,10,0)
        };
        Object[] prmT000B7;
        prmT000B7 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000B8;
        prmT000B8 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000B9;
        prmT000B9 = new Object[] {
        new ParDef("@WWPWebNotificationId",GXType.Decimal,10,0)
        };
        Object[] prmT000B10;
        prmT000B10 = new Object[] {
        new ParDef("@WWPWebNotificationId",GXType.Decimal,10,0)
        };
        Object[] prmT000B11;
        prmT000B11 = new Object[] {
        new ParDef("@WWPWebNotificationId",GXType.Decimal,10,0)
        };
        Object[] prmT000B12;
        prmT000B12 = new Object[] {
        new ParDef("@WWPWebNotificationTitle",GXType.NVarChar,40,0) ,
        new ParDef("@WWPWebNotificationText",GXType.NVarChar,120,0) ,
        new ParDef("@WWPWebNotificationIcon",GXType.NVarChar,255,0) ,
        new ParDef("@WWPWebNotificationClientId",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPWebNotificationStatus",GXType.Int16,4,0) ,
        new ParDef("@WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
        new ParDef("@WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
        new ParDef("@WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("@WWPWebNotificationDetail",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000B13;
        prmT000B13 = new Object[] {
        new ParDef("@WWPWebNotificationTitle",GXType.NVarChar,40,0) ,
        new ParDef("@WWPWebNotificationText",GXType.NVarChar,120,0) ,
        new ParDef("@WWPWebNotificationIcon",GXType.NVarChar,255,0) ,
        new ParDef("@WWPWebNotificationClientId",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPWebNotificationStatus",GXType.Int16,4,0) ,
        new ParDef("@WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
        new ParDef("@WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
        new ParDef("@WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("@WWPWebNotificationDetail",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@WWPWebNotificationId",GXType.Decimal,10,0)
        };
        Object[] prmT000B14;
        prmT000B14 = new Object[] {
        new ParDef("@WWPWebNotificationId",GXType.Decimal,10,0)
        };
        Object[] prmT000B15;
        prmT000B15 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000B16;
        prmT000B16 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000B17;
        prmT000B17 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000B2", "SELECT [WWPWebNotificationId], [WWPWebNotificationTitle], [WWPWebNotificationText], [WWPWebNotificationIcon], [WWPWebNotificationClientId], [WWPWebNotificationStatus], [WWPWebNotificationCreated], [WWPWebNotificationScheduled], [WWPWebNotificationProcessed], [WWPWebNotificationRead], [WWPWebNotificationDetail], [WWPWebNotificationReceived], [WWPNotificationId] FROM [WWP_WebNotification] WITH (UPDLOCK) WHERE [WWPWebNotificationId] = @WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B3", "SELECT [WWPWebNotificationId], [WWPWebNotificationTitle], [WWPWebNotificationText], [WWPWebNotificationIcon], [WWPWebNotificationClientId], [WWPWebNotificationStatus], [WWPWebNotificationCreated], [WWPWebNotificationScheduled], [WWPWebNotificationProcessed], [WWPWebNotificationRead], [WWPWebNotificationDetail], [WWPWebNotificationReceived], [WWPNotificationId] FROM [WWP_WebNotification] WHERE [WWPWebNotificationId] = @WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B4", "SELECT [WWPNotificationDefinitionId], [WWPNotificationCreated], [WWPNotificationMetadata] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B5", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B6", "SELECT T2.[WWPNotificationDefinitionId], TM1.[WWPWebNotificationId], TM1.[WWPWebNotificationTitle], T2.[WWPNotificationCreated], T2.[WWPNotificationMetadata], T3.[WWPNotificationDefinitionName], TM1.[WWPWebNotificationText], TM1.[WWPWebNotificationIcon], TM1.[WWPWebNotificationClientId], TM1.[WWPWebNotificationStatus], TM1.[WWPWebNotificationCreated], TM1.[WWPWebNotificationScheduled], TM1.[WWPWebNotificationProcessed], TM1.[WWPWebNotificationRead], TM1.[WWPWebNotificationDetail], TM1.[WWPWebNotificationReceived], TM1.[WWPNotificationId] FROM (([WWP_WebNotification] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) LEFT JOIN [WWP_NotificationDefinition] T3 ON T3.[WWPNotificationDefinitionId] = T2.[WWPNotificationDefinitionId]) WHERE TM1.[WWPWebNotificationId] = @WWPWebNotificationId ORDER BY TM1.[WWPWebNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B7", "SELECT [WWPNotificationDefinitionId], [WWPNotificationCreated], [WWPNotificationMetadata] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B8", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B9", "SELECT [WWPWebNotificationId] FROM [WWP_WebNotification] WHERE [WWPWebNotificationId] = @WWPWebNotificationId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B10", "SELECT TOP 1 [WWPWebNotificationId] FROM [WWP_WebNotification] WHERE ( [WWPWebNotificationId] > @WWPWebNotificationId) ORDER BY [WWPWebNotificationId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B11", "SELECT TOP 1 [WWPWebNotificationId] FROM [WWP_WebNotification] WHERE ( [WWPWebNotificationId] < @WWPWebNotificationId) ORDER BY [WWPWebNotificationId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B12", "INSERT INTO [WWP_WebNotification]([WWPWebNotificationTitle], [WWPWebNotificationText], [WWPWebNotificationIcon], [WWPWebNotificationClientId], [WWPWebNotificationStatus], [WWPWebNotificationCreated], [WWPWebNotificationScheduled], [WWPWebNotificationProcessed], [WWPWebNotificationRead], [WWPWebNotificationDetail], [WWPWebNotificationReceived], [WWPNotificationId]) VALUES(@WWPWebNotificationTitle, @WWPWebNotificationText, @WWPWebNotificationIcon, @WWPWebNotificationClientId, @WWPWebNotificationStatus, @WWPWebNotificationCreated, @WWPWebNotificationScheduled, @WWPWebNotificationProcessed, @WWPWebNotificationRead, @WWPWebNotificationDetail, @WWPWebNotificationReceived, @WWPNotificationId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000B12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B13", "UPDATE [WWP_WebNotification] SET [WWPWebNotificationTitle]=@WWPWebNotificationTitle, [WWPWebNotificationText]=@WWPWebNotificationText, [WWPWebNotificationIcon]=@WWPWebNotificationIcon, [WWPWebNotificationClientId]=@WWPWebNotificationClientId, [WWPWebNotificationStatus]=@WWPWebNotificationStatus, [WWPWebNotificationCreated]=@WWPWebNotificationCreated, [WWPWebNotificationScheduled]=@WWPWebNotificationScheduled, [WWPWebNotificationProcessed]=@WWPWebNotificationProcessed, [WWPWebNotificationRead]=@WWPWebNotificationRead, [WWPWebNotificationDetail]=@WWPWebNotificationDetail, [WWPWebNotificationReceived]=@WWPWebNotificationReceived, [WWPNotificationId]=@WWPNotificationId  WHERE [WWPWebNotificationId] = @WWPWebNotificationId", GxErrorMask.GX_NOMASK,prmT000B13)
           ,new CursorDef("T000B14", "DELETE FROM [WWP_WebNotification]  WHERE [WWPWebNotificationId] = @WWPWebNotificationId", GxErrorMask.GX_NOMASK,prmT000B14)
           ,new CursorDef("T000B15", "SELECT [WWPNotificationDefinitionId], [WWPNotificationCreated], [WWPNotificationMetadata] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B16", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B17", "SELECT [WWPWebNotificationId] FROM [WWP_WebNotification] ORDER BY [WWPWebNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B17,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((bool[]) buf[13])[0] = rslt.getBool(12);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((long[]) buf[15])[0] = rslt.getLong(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((bool[]) buf[13])[0] = rslt.getBool(12);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((long[]) buf[15])[0] = rslt.getLong(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(12, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(13, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(14, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(14);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(15);
              ((bool[]) buf[17])[0] = rslt.wasNull(15);
              ((bool[]) buf[18])[0] = rslt.getBool(16);
              ((bool[]) buf[19])[0] = rslt.wasNull(16);
              ((long[]) buf[20])[0] = rslt.getLong(17);
              ((bool[]) buf[21])[0] = rslt.wasNull(17);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
