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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   public class wwp_sms : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
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
            gxLoad_9( A31WWPNotificationId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "WWP_SMS", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_sms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sms( IGxContext context )
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
         cmbWWPSMSStatus = new GXCombobox();
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
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            A43WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPSMSStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPSMSStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A43WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A43WWPSMSStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPSMSStatus), 4, 0));
            AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", cmbWWPSMSStatus.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "WWP_SMS", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"wwpbaseobjects.sms.gx00b0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPSMSID"+"'), id:'"+"WWPSMSID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPSMSId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A42WWPSMSId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPSMSId_Enabled!=0) ? context.localUtil.Format( (decimal)(A42WWPSMSId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A42WWPSMSId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSMessage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSMessage_Internalname, context.GetMessage( "Message", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSMessage_Internalname, A46WWPSMSMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtWWPSMSMessage_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSSenderNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSSenderNumber_Internalname, context.GetMessage( "Sender Number", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSSenderNumber_Internalname, A47WWPSMSSenderNumber, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtWWPSMSSenderNumber_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSRecipientNumbers_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSRecipientNumbers_Internalname, context.GetMessage( "Recipient Numbers", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSRecipientNumbers_Internalname, A48WWPSMSRecipientNumbers, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtWWPSMSRecipientNumbers_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPSMSStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPSMSStatus_Internalname, context.GetMessage( "Status", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPSMSStatus, cmbWWPSMSStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPSMSStatus), 4, 0)), 1, cmbWWPSMSStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPSMSStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPSMSStatus), 4, 0));
         AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", (string)(cmbWWPSMSStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSCreated_Internalname, context.GetMessage( "Created", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPSMSCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPSMSCreated_Internalname, context.localUtil.TToC( A49WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A49WWPSMSCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPSMSCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPSMSCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSScheduled_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSScheduled_Internalname, context.GetMessage( "Scheduled", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPSMSScheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPSMSScheduled_Internalname, context.localUtil.TToC( A50WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A50WWPSMSScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSScheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSScheduled_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPSMSScheduled_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPSMSScheduled_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSProcessed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSProcessed_Internalname, context.GetMessage( "Processed", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPSMSProcessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPSMSProcessed_Internalname, context.localUtil.TToC( A44WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A44WWPSMSProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSProcessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSProcessed_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPSMSProcessed_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPSMSProcessed_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSDetail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSDetail_Internalname, context.GetMessage( "Detail", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSDetail_Internalname, A45WWPSMSDetail, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, 1, edtWWPSMSDetail_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A31WWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A31WWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_31_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_31_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_31_Internalname, sImgUrl, imgprompt_31_Link, "", "", context.GetTheme( ), imgprompt_31_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A33WWPNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
            Z42WWPSMSId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z42WWPSMSId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z43WWPSMSStatus = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z43WWPSMSStatus"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z49WWPSMSCreated = context.localUtil.CToT( cgiGet( "Z49WWPSMSCreated"), 0);
            Z50WWPSMSScheduled = context.localUtil.CToT( cgiGet( "Z50WWPSMSScheduled"), 0);
            Z44WWPSMSProcessed = context.localUtil.CToT( cgiGet( "Z44WWPSMSProcessed"), 0);
            n44WWPSMSProcessed = ((DateTime.MinValue==A44WWPSMSProcessed) ? true : false);
            Z31WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z31WWPNotificationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n31WWPNotificationId = ((0==A31WWPNotificationId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPSMSID");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A42WWPSMSId = 0;
               AssignAttri("", false, "A42WWPSMSId", StringUtil.LTrimStr( (decimal)(A42WWPSMSId), 10, 0));
            }
            else
            {
               A42WWPSMSId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A42WWPSMSId", StringUtil.LTrimStr( (decimal)(A42WWPSMSId), 10, 0));
            }
            A46WWPSMSMessage = cgiGet( edtWWPSMSMessage_Internalname);
            AssignAttri("", false, "A46WWPSMSMessage", A46WWPSMSMessage);
            A47WWPSMSSenderNumber = cgiGet( edtWWPSMSSenderNumber_Internalname);
            AssignAttri("", false, "A47WWPSMSSenderNumber", A47WWPSMSSenderNumber);
            A48WWPSMSRecipientNumbers = cgiGet( edtWWPSMSRecipientNumbers_Internalname);
            AssignAttri("", false, "A48WWPSMSRecipientNumbers", A48WWPSMSRecipientNumbers);
            cmbWWPSMSStatus.CurrentValue = cgiGet( cmbWWPSMSStatus_Internalname);
            A43WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPSMSStatus_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A43WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A43WWPSMSStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPSMSCreated_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "SMS Created", "")}), 1, "WWPSMSCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A49WWPSMSCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A49WWPSMSCreated", context.localUtil.TToC( A49WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A49WWPSMSCreated = context.localUtil.CToT( cgiGet( edtWWPSMSCreated_Internalname));
               AssignAttri("", false, "A49WWPSMSCreated", context.localUtil.TToC( A49WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPSMSScheduled_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "SMS Scheduled", "")}), 1, "WWPSMSSCHEDULED");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSScheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A50WWPSMSScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A50WWPSMSScheduled", context.localUtil.TToC( A50WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A50WWPSMSScheduled = context.localUtil.CToT( cgiGet( edtWWPSMSScheduled_Internalname));
               AssignAttri("", false, "A50WWPSMSScheduled", context.localUtil.TToC( A50WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPSMSProcessed_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "SMS Processed", "")}), 1, "WWPSMSPROCESSED");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSProcessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A44WWPSMSProcessed = (DateTime)(DateTime.MinValue);
               n44WWPSMSProcessed = false;
               AssignAttri("", false, "A44WWPSMSProcessed", context.localUtil.TToC( A44WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A44WWPSMSProcessed = context.localUtil.CToT( cgiGet( edtWWPSMSProcessed_Internalname));
               n44WWPSMSProcessed = false;
               AssignAttri("", false, "A44WWPSMSProcessed", context.localUtil.TToC( A44WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            n44WWPSMSProcessed = ((DateTime.MinValue==A44WWPSMSProcessed) ? true : false);
            A45WWPSMSDetail = cgiGet( edtWWPSMSDetail_Internalname);
            n45WWPSMSDetail = false;
            AssignAttri("", false, "A45WWPSMSDetail", A45WWPSMSDetail);
            n45WWPSMSDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A45WWPSMSDetail)) ? true : false);
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
               A42WWPSMSId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPSMSId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A42WWPSMSId", StringUtil.LTrimStr( (decimal)(A42WWPSMSId), 10, 0));
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
               InitAll0A11( ) ;
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
         DisableAttributes0A11( ) ;
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

      protected void ResetCaption0A0( )
      {
      }

      protected void ZM0A11( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z43WWPSMSStatus = T000A3_A43WWPSMSStatus[0];
               Z49WWPSMSCreated = T000A3_A49WWPSMSCreated[0];
               Z50WWPSMSScheduled = T000A3_A50WWPSMSScheduled[0];
               Z44WWPSMSProcessed = T000A3_A44WWPSMSProcessed[0];
               Z31WWPNotificationId = T000A3_A31WWPNotificationId[0];
            }
            else
            {
               Z43WWPSMSStatus = A43WWPSMSStatus;
               Z49WWPSMSCreated = A49WWPSMSCreated;
               Z50WWPSMSScheduled = A50WWPSMSScheduled;
               Z44WWPSMSProcessed = A44WWPSMSProcessed;
               Z31WWPNotificationId = A31WWPNotificationId;
            }
         }
         if ( GX_JID == -8 )
         {
            Z42WWPSMSId = A42WWPSMSId;
            Z46WWPSMSMessage = A46WWPSMSMessage;
            Z47WWPSMSSenderNumber = A47WWPSMSSenderNumber;
            Z48WWPSMSRecipientNumbers = A48WWPSMSRecipientNumbers;
            Z43WWPSMSStatus = A43WWPSMSStatus;
            Z49WWPSMSCreated = A49WWPSMSCreated;
            Z50WWPSMSScheduled = A50WWPSMSScheduled;
            Z44WWPSMSProcessed = A44WWPSMSProcessed;
            Z45WWPSMSDetail = A45WWPSMSDetail;
            Z31WWPNotificationId = A31WWPNotificationId;
            Z33WWPNotificationCreated = A33WWPNotificationCreated;
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
         if ( IsIns( )  && (0==A43WWPSMSStatus) && ( Gx_BScreen == 0 ) )
         {
            A43WWPSMSStatus = 1;
            AssignAttri("", false, "A43WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A43WWPSMSStatus), 4, 0));
         }
         if ( IsIns( )  && (DateTime.MinValue==A49WWPSMSCreated) && ( Gx_BScreen == 0 ) )
         {
            A49WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A49WWPSMSCreated", context.localUtil.TToC( A49WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A50WWPSMSScheduled) && ( Gx_BScreen == 0 ) )
         {
            A50WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A50WWPSMSScheduled", context.localUtil.TToC( A50WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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

      protected void Load0A11( )
      {
         /* Using cursor T000A5 */
         pr_default.execute(3, new Object[] {A42WWPSMSId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound11 = 1;
            A46WWPSMSMessage = T000A5_A46WWPSMSMessage[0];
            AssignAttri("", false, "A46WWPSMSMessage", A46WWPSMSMessage);
            A47WWPSMSSenderNumber = T000A5_A47WWPSMSSenderNumber[0];
            AssignAttri("", false, "A47WWPSMSSenderNumber", A47WWPSMSSenderNumber);
            A48WWPSMSRecipientNumbers = T000A5_A48WWPSMSRecipientNumbers[0];
            AssignAttri("", false, "A48WWPSMSRecipientNumbers", A48WWPSMSRecipientNumbers);
            A43WWPSMSStatus = T000A5_A43WWPSMSStatus[0];
            AssignAttri("", false, "A43WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A43WWPSMSStatus), 4, 0));
            A49WWPSMSCreated = T000A5_A49WWPSMSCreated[0];
            AssignAttri("", false, "A49WWPSMSCreated", context.localUtil.TToC( A49WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A50WWPSMSScheduled = T000A5_A50WWPSMSScheduled[0];
            AssignAttri("", false, "A50WWPSMSScheduled", context.localUtil.TToC( A50WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A44WWPSMSProcessed = T000A5_A44WWPSMSProcessed[0];
            n44WWPSMSProcessed = T000A5_n44WWPSMSProcessed[0];
            AssignAttri("", false, "A44WWPSMSProcessed", context.localUtil.TToC( A44WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A45WWPSMSDetail = T000A5_A45WWPSMSDetail[0];
            n45WWPSMSDetail = T000A5_n45WWPSMSDetail[0];
            AssignAttri("", false, "A45WWPSMSDetail", A45WWPSMSDetail);
            A33WWPNotificationCreated = T000A5_A33WWPNotificationCreated[0];
            AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A31WWPNotificationId = T000A5_A31WWPNotificationId[0];
            n31WWPNotificationId = T000A5_n31WWPNotificationId[0];
            AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
            ZM0A11( -8) ;
         }
         pr_default.close(3);
         OnLoadActions0A11( ) ;
      }

      protected void OnLoadActions0A11( )
      {
      }

      protected void CheckExtendedTable0A11( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( A43WWPSMSStatus == 1 ) || ( A43WWPSMSStatus == 2 ) || ( A43WWPSMSStatus == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "SMS Status", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPSMSSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbWWPSMSStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A49WWPSMSCreated) || ( A49WWPSMSCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "SMS Created", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPSMSCREATED");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSCreated_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A50WWPSMSScheduled) || ( A50WWPSMSScheduled >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "SMS Scheduled", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPSMSSCHEDULED");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSScheduled_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A44WWPSMSProcessed) || ( A44WWPSMSProcessed >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "SMS Processed", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPSMSPROCESSED");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSProcessed_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000A4 */
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
         A33WWPNotificationCreated = T000A4_A33WWPNotificationCreated[0];
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0A11( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( long A31WWPNotificationId )
      {
         /* Using cursor T000A6 */
         pr_default.execute(4, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A31WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A33WWPNotificationCreated = T000A6_A33WWPNotificationCreated[0];
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0A11( )
      {
         /* Using cursor T000A7 */
         pr_default.execute(5, new Object[] {A42WWPSMSId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A42WWPSMSId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A11( 8) ;
            RcdFound11 = 1;
            A42WWPSMSId = T000A3_A42WWPSMSId[0];
            AssignAttri("", false, "A42WWPSMSId", StringUtil.LTrimStr( (decimal)(A42WWPSMSId), 10, 0));
            A46WWPSMSMessage = T000A3_A46WWPSMSMessage[0];
            AssignAttri("", false, "A46WWPSMSMessage", A46WWPSMSMessage);
            A47WWPSMSSenderNumber = T000A3_A47WWPSMSSenderNumber[0];
            AssignAttri("", false, "A47WWPSMSSenderNumber", A47WWPSMSSenderNumber);
            A48WWPSMSRecipientNumbers = T000A3_A48WWPSMSRecipientNumbers[0];
            AssignAttri("", false, "A48WWPSMSRecipientNumbers", A48WWPSMSRecipientNumbers);
            A43WWPSMSStatus = T000A3_A43WWPSMSStatus[0];
            AssignAttri("", false, "A43WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A43WWPSMSStatus), 4, 0));
            A49WWPSMSCreated = T000A3_A49WWPSMSCreated[0];
            AssignAttri("", false, "A49WWPSMSCreated", context.localUtil.TToC( A49WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A50WWPSMSScheduled = T000A3_A50WWPSMSScheduled[0];
            AssignAttri("", false, "A50WWPSMSScheduled", context.localUtil.TToC( A50WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A44WWPSMSProcessed = T000A3_A44WWPSMSProcessed[0];
            n44WWPSMSProcessed = T000A3_n44WWPSMSProcessed[0];
            AssignAttri("", false, "A44WWPSMSProcessed", context.localUtil.TToC( A44WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A45WWPSMSDetail = T000A3_A45WWPSMSDetail[0];
            n45WWPSMSDetail = T000A3_n45WWPSMSDetail[0];
            AssignAttri("", false, "A45WWPSMSDetail", A45WWPSMSDetail);
            A31WWPNotificationId = T000A3_A31WWPNotificationId[0];
            n31WWPNotificationId = T000A3_n31WWPNotificationId[0];
            AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
            Z42WWPSMSId = A42WWPSMSId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0A11( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0A11( ) ;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0A11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A11( ) ;
         if ( RcdFound11 == 0 )
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
         RcdFound11 = 0;
         /* Using cursor T000A8 */
         pr_default.execute(6, new Object[] {A42WWPSMSId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000A8_A42WWPSMSId[0] < A42WWPSMSId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000A8_A42WWPSMSId[0] > A42WWPSMSId ) ) )
            {
               A42WWPSMSId = T000A8_A42WWPSMSId[0];
               AssignAttri("", false, "A42WWPSMSId", StringUtil.LTrimStr( (decimal)(A42WWPSMSId), 10, 0));
               RcdFound11 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound11 = 0;
         /* Using cursor T000A9 */
         pr_default.execute(7, new Object[] {A42WWPSMSId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000A9_A42WWPSMSId[0] > A42WWPSMSId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000A9_A42WWPSMSId[0] < A42WWPSMSId ) ) )
            {
               A42WWPSMSId = T000A9_A42WWPSMSId[0];
               AssignAttri("", false, "A42WWPSMSId", StringUtil.LTrimStr( (decimal)(A42WWPSMSId), 10, 0));
               RcdFound11 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0A11( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0A11( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( A42WWPSMSId != Z42WWPSMSId )
               {
                  A42WWPSMSId = Z42WWPSMSId;
                  AssignAttri("", false, "A42WWPSMSId", StringUtil.LTrimStr( (decimal)(A42WWPSMSId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPSMSID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0A11( ) ;
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A42WWPSMSId != Z42WWPSMSId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0A11( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPSMSID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPSMSId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPSMSId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0A11( ) ;
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
         if ( A42WWPSMSId != Z42WWPSMSId )
         {
            A42WWPSMSId = Z42WWPSMSId;
            AssignAttri("", false, "A42WWPSMSId", StringUtil.LTrimStr( (decimal)(A42WWPSMSId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPSMSID");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPSMSId_Internalname;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPSMSID");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0A11( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A11( ) ;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
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
         ScanStart0A11( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound11 != 0 )
            {
               ScanNext0A11( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A11( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0A11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A2 */
            pr_default.execute(0, new Object[] {A42WWPSMSId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z43WWPSMSStatus != T000A2_A43WWPSMSStatus[0] ) || ( Z49WWPSMSCreated != T000A2_A49WWPSMSCreated[0] ) || ( Z50WWPSMSScheduled != T000A2_A50WWPSMSScheduled[0] ) || ( Z44WWPSMSProcessed != T000A2_A44WWPSMSProcessed[0] ) || ( Z31WWPNotificationId != T000A2_A31WWPNotificationId[0] ) )
            {
               if ( Z43WWPSMSStatus != T000A2_A43WWPSMSStatus[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSStatus");
                  GXUtil.WriteLogRaw("Old: ",Z43WWPSMSStatus);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A43WWPSMSStatus[0]);
               }
               if ( Z49WWPSMSCreated != T000A2_A49WWPSMSCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSCreated");
                  GXUtil.WriteLogRaw("Old: ",Z49WWPSMSCreated);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A49WWPSMSCreated[0]);
               }
               if ( Z50WWPSMSScheduled != T000A2_A50WWPSMSScheduled[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSScheduled");
                  GXUtil.WriteLogRaw("Old: ",Z50WWPSMSScheduled);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A50WWPSMSScheduled[0]);
               }
               if ( Z44WWPSMSProcessed != T000A2_A44WWPSMSProcessed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSProcessed");
                  GXUtil.WriteLogRaw("Old: ",Z44WWPSMSProcessed);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A44WWPSMSProcessed[0]);
               }
               if ( Z31WWPNotificationId != T000A2_A31WWPNotificationId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPNotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z31WWPNotificationId);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A31WWPNotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_SMS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A11( )
      {
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A11( 0) ;
            CheckOptimisticConcurrency0A11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A10 */
                     pr_default.execute(8, new Object[] {A46WWPSMSMessage, A47WWPSMSSenderNumber, A48WWPSMSRecipientNumbers, A43WWPSMSStatus, A49WWPSMSCreated, A50WWPSMSScheduled, n44WWPSMSProcessed, A44WWPSMSProcessed, n45WWPSMSDetail, A45WWPSMSDetail, n31WWPNotificationId, A31WWPNotificationId});
                     A42WWPSMSId = T000A10_A42WWPSMSId[0];
                     AssignAttri("", false, "A42WWPSMSId", StringUtil.LTrimStr( (decimal)(A42WWPSMSId), 10, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0A0( ) ;
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
               Load0A11( ) ;
            }
            EndLevel0A11( ) ;
         }
         CloseExtendedTableCursors0A11( ) ;
      }

      protected void Update0A11( )
      {
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A11 */
                     pr_default.execute(9, new Object[] {A46WWPSMSMessage, A47WWPSMSSenderNumber, A48WWPSMSRecipientNumbers, A43WWPSMSStatus, A49WWPSMSCreated, A50WWPSMSScheduled, n44WWPSMSProcessed, A44WWPSMSProcessed, n45WWPSMSDetail, A45WWPSMSDetail, n31WWPNotificationId, A31WWPNotificationId, A42WWPSMSId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A11( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0A0( ) ;
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
            EndLevel0A11( ) ;
         }
         CloseExtendedTableCursors0A11( ) ;
      }

      protected void DeferredUpdate0A11( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A11( ) ;
            AfterConfirm0A11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A11( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000A12 */
                  pr_default.execute(10, new Object[] {A42WWPSMSId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound11 == 0 )
                        {
                           InitAll0A11( ) ;
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
                        ResetCaption0A0( ) ;
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A11( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A11( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000A13 */
            pr_default.execute(11, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
            A33WWPNotificationCreated = T000A13_A33WWPNotificationCreated[0];
            AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            pr_default.close(11);
         }
      }

      protected void EndLevel0A11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("wwpbaseobjects.sms.wwp_sms",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("wwpbaseobjects.sms.wwp_sms",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A11( )
      {
         /* Using cursor T000A14 */
         pr_default.execute(12);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound11 = 1;
            A42WWPSMSId = T000A14_A42WWPSMSId[0];
            AssignAttri("", false, "A42WWPSMSId", StringUtil.LTrimStr( (decimal)(A42WWPSMSId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A11( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound11 = 1;
            A42WWPSMSId = T000A14_A42WWPSMSId[0];
            AssignAttri("", false, "A42WWPSMSId", StringUtil.LTrimStr( (decimal)(A42WWPSMSId), 10, 0));
         }
      }

      protected void ScanEnd0A11( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0A11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A11( )
      {
         edtWWPSMSId_Enabled = 0;
         AssignProp("", false, edtWWPSMSId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSId_Enabled), 5, 0), true);
         edtWWPSMSMessage_Enabled = 0;
         AssignProp("", false, edtWWPSMSMessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSMessage_Enabled), 5, 0), true);
         edtWWPSMSSenderNumber_Enabled = 0;
         AssignProp("", false, edtWWPSMSSenderNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSSenderNumber_Enabled), 5, 0), true);
         edtWWPSMSRecipientNumbers_Enabled = 0;
         AssignProp("", false, edtWWPSMSRecipientNumbers_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSRecipientNumbers_Enabled), 5, 0), true);
         cmbWWPSMSStatus.Enabled = 0;
         AssignProp("", false, cmbWWPSMSStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPSMSStatus.Enabled), 5, 0), true);
         edtWWPSMSCreated_Enabled = 0;
         AssignProp("", false, edtWWPSMSCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSCreated_Enabled), 5, 0), true);
         edtWWPSMSScheduled_Enabled = 0;
         AssignProp("", false, edtWWPSMSScheduled_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSScheduled_Enabled), 5, 0), true);
         edtWWPSMSProcessed_Enabled = 0;
         AssignProp("", false, edtWWPSMSProcessed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSProcessed_Enabled), 5, 0), true);
         edtWWPSMSDetail_Enabled = 0;
         AssignProp("", false, edtWWPSMSDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSDetail_Enabled), 5, 0), true);
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0A11( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0A0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.sms.wwp_sms.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z42WWPSMSId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z42WWPSMSId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z43WWPSMSStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z43WWPSMSStatus), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z49WWPSMSCreated", context.localUtil.TToC( Z49WWPSMSCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z50WWPSMSScheduled", context.localUtil.TToC( Z50WWPSMSScheduled, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z44WWPSMSProcessed", context.localUtil.TToC( Z44WWPSMSProcessed, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z31WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("wwpbaseobjects.sms.wwp_sms.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SMS.WWP_SMS" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_SMS", "") ;
      }

      protected void InitializeNonKey0A11( )
      {
         A46WWPSMSMessage = "";
         AssignAttri("", false, "A46WWPSMSMessage", A46WWPSMSMessage);
         A47WWPSMSSenderNumber = "";
         AssignAttri("", false, "A47WWPSMSSenderNumber", A47WWPSMSSenderNumber);
         A48WWPSMSRecipientNumbers = "";
         AssignAttri("", false, "A48WWPSMSRecipientNumbers", A48WWPSMSRecipientNumbers);
         A44WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         n44WWPSMSProcessed = false;
         AssignAttri("", false, "A44WWPSMSProcessed", context.localUtil.TToC( A44WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n44WWPSMSProcessed = ((DateTime.MinValue==A44WWPSMSProcessed) ? true : false);
         A45WWPSMSDetail = "";
         n45WWPSMSDetail = false;
         AssignAttri("", false, "A45WWPSMSDetail", A45WWPSMSDetail);
         n45WWPSMSDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A45WWPSMSDetail)) ? true : false);
         A31WWPNotificationId = 0;
         n31WWPNotificationId = false;
         AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
         n31WWPNotificationId = ((0==A31WWPNotificationId) ? true : false);
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A43WWPSMSStatus = 1;
         AssignAttri("", false, "A43WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A43WWPSMSStatus), 4, 0));
         A49WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A49WWPSMSCreated", context.localUtil.TToC( A49WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A50WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A50WWPSMSScheduled", context.localUtil.TToC( A50WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         Z43WWPSMSStatus = 0;
         Z49WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z50WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z44WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         Z31WWPNotificationId = 0;
      }

      protected void InitAll0A11( )
      {
         A42WWPSMSId = 0;
         AssignAttri("", false, "A42WWPSMSId", StringUtil.LTrimStr( (decimal)(A42WWPSMSId), 10, 0));
         InitializeNonKey0A11( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A43WWPSMSStatus = i43WWPSMSStatus;
         AssignAttri("", false, "A43WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A43WWPSMSStatus), 4, 0));
         A49WWPSMSCreated = i49WWPSMSCreated;
         AssignAttri("", false, "A49WWPSMSCreated", context.localUtil.TToC( A49WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A50WWPSMSScheduled = i50WWPSMSScheduled;
         AssignAttri("", false, "A50WWPSMSScheduled", context.localUtil.TToC( A50WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026730218438", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/sms/wwp_sms.js", "?2026730218439", false, true, false);
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
         edtWWPSMSId_Internalname = "WWPSMSID";
         edtWWPSMSMessage_Internalname = "WWPSMSMESSAGE";
         edtWWPSMSSenderNumber_Internalname = "WWPSMSSENDERNUMBER";
         edtWWPSMSRecipientNumbers_Internalname = "WWPSMSRECIPIENTNUMBERS";
         cmbWWPSMSStatus_Internalname = "WWPSMSSTATUS";
         edtWWPSMSCreated_Internalname = "WWPSMSCREATED";
         edtWWPSMSScheduled_Internalname = "WWPSMSSCHEDULED";
         edtWWPSMSProcessed_Internalname = "WWPSMSPROCESSED";
         edtWWPSMSDetail_Internalname = "WWPSMSDETAIL";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
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
         Form.Caption = context.GetMessage( "WWP_SMS", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 0;
         imgprompt_31_Visible = 1;
         imgprompt_31_Link = "";
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
         edtWWPSMSDetail_Enabled = 1;
         edtWWPSMSProcessed_Jsonclick = "";
         edtWWPSMSProcessed_Enabled = 1;
         edtWWPSMSScheduled_Jsonclick = "";
         edtWWPSMSScheduled_Enabled = 1;
         edtWWPSMSCreated_Jsonclick = "";
         edtWWPSMSCreated_Enabled = 1;
         cmbWWPSMSStatus_Jsonclick = "";
         cmbWWPSMSStatus.Enabled = 1;
         edtWWPSMSRecipientNumbers_Enabled = 1;
         edtWWPSMSSenderNumber_Enabled = 1;
         edtWWPSMSMessage_Enabled = 1;
         edtWWPSMSId_Jsonclick = "";
         edtWWPSMSId_Enabled = 1;
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
         cmbWWPSMSStatus.Name = "WWPSMSSTATUS";
         cmbWWPSMSStatus.WebTags = "";
         cmbWWPSMSStatus.addItem("1", context.GetMessage( "Pending", ""), 0);
         cmbWWPSMSStatus.addItem("2", context.GetMessage( "Sent", ""), 0);
         cmbWWPSMSStatus.addItem("3", context.GetMessage( "Error", ""), 0);
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A43WWPSMSStatus) )
            {
               A43WWPSMSStatus = 1;
               AssignAttri("", false, "A43WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A43WWPSMSStatus), 4, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPSMSMessage_Internalname;
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

      public void Valid_Wwpsmsid( )
      {
         A43WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPSMSStatus.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPSMSStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A43WWPSMSStatus), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            A43WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPSMSStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPSMSStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPSMSStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A43WWPSMSStatus), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPSMSStatus), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A46WWPSMSMessage", A46WWPSMSMessage);
         AssignAttri("", false, "A47WWPSMSSenderNumber", A47WWPSMSSenderNumber);
         AssignAttri("", false, "A48WWPSMSRecipientNumbers", A48WWPSMSRecipientNumbers);
         AssignAttri("", false, "A43WWPSMSStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(A43WWPSMSStatus), 4, 0, ".", "")));
         cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPSMSStatus), 4, 0));
         AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", cmbWWPSMSStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A49WWPSMSCreated", context.localUtil.TToC( A49WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A50WWPSMSScheduled", context.localUtil.TToC( A50WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A44WWPSMSProcessed", context.localUtil.TToC( A44WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A45WWPSMSDetail", A45WWPSMSDetail);
         AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A31WWPNotificationId), 10, 0, ".", "")));
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z42WWPSMSId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z42WWPSMSId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z46WWPSMSMessage", Z46WWPSMSMessage);
         GxWebStd.gx_hidden_field( context, "Z47WWPSMSSenderNumber", Z47WWPSMSSenderNumber);
         GxWebStd.gx_hidden_field( context, "Z48WWPSMSRecipientNumbers", Z48WWPSMSRecipientNumbers);
         GxWebStd.gx_hidden_field( context, "Z43WWPSMSStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z43WWPSMSStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z49WWPSMSCreated", context.localUtil.TToC( Z49WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z50WWPSMSScheduled", context.localUtil.TToC( Z50WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z44WWPSMSProcessed", context.localUtil.TToC( Z44WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z45WWPSMSDetail", Z45WWPSMSDetail);
         GxWebStd.gx_hidden_field( context, "Z31WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z33WWPNotificationCreated", context.localUtil.TToC( Z33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationid( )
      {
         n31WWPNotificationId = false;
         /* Using cursor T000A13 */
         pr_default.execute(11, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A31WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
            }
         }
         A33WWPNotificationCreated = T000A13_A33WWPNotificationCreated[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
         setEventMetadata("VALID_WWPSMSID","{handler:'Valid_Wwpsmsid',iparms:[{av:'A42WWPSMSId',fld:'WWPSMSID',pic:'ZZZZZZZZZ9',type:'int'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'cmbWWPSMSStatus'},{av:'A43WWPSMSStatus',fld:'WWPSMSSTATUS',pic:'ZZZ9',type:'int'},{av:'A49WWPSMSCreated',fld:'WWPSMSCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A50WWPSMSScheduled',fld:'WWPSMSSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'}]");
         setEventMetadata("VALID_WWPSMSID",",oparms:[{av:'A46WWPSMSMessage',fld:'WWPSMSMESSAGE',pic:'',type:'vchar'},{av:'A47WWPSMSSenderNumber',fld:'WWPSMSSENDERNUMBER',pic:'',type:'vchar'},{av:'A48WWPSMSRecipientNumbers',fld:'WWPSMSRECIPIENTNUMBERS',pic:'',type:'vchar'},{av:'cmbWWPSMSStatus'},{av:'A43WWPSMSStatus',fld:'WWPSMSSTATUS',pic:'ZZZ9',type:'int'},{av:'A49WWPSMSCreated',fld:'WWPSMSCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A50WWPSMSScheduled',fld:'WWPSMSSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A44WWPSMSProcessed',fld:'WWPSMSPROCESSED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A45WWPSMSDetail',fld:'WWPSMSDETAIL',pic:'',type:'vchar'},{av:'A31WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A33WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z42WWPSMSId',type:'int'},{av:'Z46WWPSMSMessage',type:'vchar'},{av:'Z47WWPSMSSenderNumber',type:'vchar'},{av:'Z48WWPSMSRecipientNumbers',type:'vchar'},{av:'Z43WWPSMSStatus',type:'int'},{av:'Z49WWPSMSCreated',type:'dtime'},{av:'Z50WWPSMSScheduled',type:'dtime'},{av:'Z44WWPSMSProcessed',type:'dtime'},{av:'Z45WWPSMSDetail',type:'vchar'},{av:'Z31WWPNotificationId',type:'int'},{av:'Z33WWPNotificationCreated',type:'dtime'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_WWPSMSSTATUS","{handler:'Valid_Wwpsmsstatus',iparms:[]");
         setEventMetadata("VALID_WWPSMSSTATUS",",oparms:[]}");
         setEventMetadata("VALID_WWPSMSCREATED","{handler:'Valid_Wwpsmscreated',iparms:[]");
         setEventMetadata("VALID_WWPSMSCREATED",",oparms:[]}");
         setEventMetadata("VALID_WWPSMSSCHEDULED","{handler:'Valid_Wwpsmsscheduled',iparms:[]");
         setEventMetadata("VALID_WWPSMSSCHEDULED",",oparms:[]}");
         setEventMetadata("VALID_WWPSMSPROCESSED","{handler:'Valid_Wwpsmsprocessed',iparms:[]");
         setEventMetadata("VALID_WWPSMSPROCESSED",",oparms:[]}");
         setEventMetadata("VALID_WWPNOTIFICATIONID","{handler:'Valid_Wwpnotificationid',iparms:[{av:'A31WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A33WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONID",",oparms:[{av:'A33WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'}]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z49WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z50WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z44WWPSMSProcessed = (DateTime)(DateTime.MinValue);
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
         A46WWPSMSMessage = "";
         A47WWPSMSSenderNumber = "";
         A48WWPSMSRecipientNumbers = "";
         A49WWPSMSCreated = (DateTime)(DateTime.MinValue);
         A50WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         A44WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         A45WWPSMSDetail = "";
         imgprompt_31_gximage = "";
         sImgUrl = "";
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
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
         Z46WWPSMSMessage = "";
         Z47WWPSMSSenderNumber = "";
         Z48WWPSMSRecipientNumbers = "";
         Z45WWPSMSDetail = "";
         Z33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         T000A5_A42WWPSMSId = new long[1] ;
         T000A5_A46WWPSMSMessage = new string[] {""} ;
         T000A5_A47WWPSMSSenderNumber = new string[] {""} ;
         T000A5_A48WWPSMSRecipientNumbers = new string[] {""} ;
         T000A5_A43WWPSMSStatus = new short[1] ;
         T000A5_A49WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         T000A5_A50WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         T000A5_A44WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         T000A5_n44WWPSMSProcessed = new bool[] {false} ;
         T000A5_A45WWPSMSDetail = new string[] {""} ;
         T000A5_n45WWPSMSDetail = new bool[] {false} ;
         T000A5_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000A5_A31WWPNotificationId = new long[1] ;
         T000A5_n31WWPNotificationId = new bool[] {false} ;
         T000A4_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000A6_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000A7_A42WWPSMSId = new long[1] ;
         T000A3_A42WWPSMSId = new long[1] ;
         T000A3_A46WWPSMSMessage = new string[] {""} ;
         T000A3_A47WWPSMSSenderNumber = new string[] {""} ;
         T000A3_A48WWPSMSRecipientNumbers = new string[] {""} ;
         T000A3_A43WWPSMSStatus = new short[1] ;
         T000A3_A49WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         T000A3_A50WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         T000A3_A44WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         T000A3_n44WWPSMSProcessed = new bool[] {false} ;
         T000A3_A45WWPSMSDetail = new string[] {""} ;
         T000A3_n45WWPSMSDetail = new bool[] {false} ;
         T000A3_A31WWPNotificationId = new long[1] ;
         T000A3_n31WWPNotificationId = new bool[] {false} ;
         sMode11 = "";
         T000A8_A42WWPSMSId = new long[1] ;
         T000A9_A42WWPSMSId = new long[1] ;
         T000A2_A42WWPSMSId = new long[1] ;
         T000A2_A46WWPSMSMessage = new string[] {""} ;
         T000A2_A47WWPSMSSenderNumber = new string[] {""} ;
         T000A2_A48WWPSMSRecipientNumbers = new string[] {""} ;
         T000A2_A43WWPSMSStatus = new short[1] ;
         T000A2_A49WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         T000A2_A50WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         T000A2_A44WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         T000A2_n44WWPSMSProcessed = new bool[] {false} ;
         T000A2_A45WWPSMSDetail = new string[] {""} ;
         T000A2_n45WWPSMSDetail = new bool[] {false} ;
         T000A2_A31WWPNotificationId = new long[1] ;
         T000A2_n31WWPNotificationId = new bool[] {false} ;
         T000A10_A42WWPSMSId = new long[1] ;
         T000A13_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000A14_A42WWPSMSId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i49WWPSMSCreated = (DateTime)(DateTime.MinValue);
         i50WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         ZZ46WWPSMSMessage = "";
         ZZ47WWPSMSSenderNumber = "";
         ZZ48WWPSMSRecipientNumbers = "";
         ZZ49WWPSMSCreated = (DateTime)(DateTime.MinValue);
         ZZ50WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         ZZ44WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         ZZ45WWPSMSDetail = "";
         ZZ33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms__default(),
            new Object[][] {
                new Object[] {
               T000A2_A42WWPSMSId, T000A2_A46WWPSMSMessage, T000A2_A47WWPSMSSenderNumber, T000A2_A48WWPSMSRecipientNumbers, T000A2_A43WWPSMSStatus, T000A2_A49WWPSMSCreated, T000A2_A50WWPSMSScheduled, T000A2_A44WWPSMSProcessed, T000A2_n44WWPSMSProcessed, T000A2_A45WWPSMSDetail,
               T000A2_n45WWPSMSDetail, T000A2_A31WWPNotificationId, T000A2_n31WWPNotificationId
               }
               , new Object[] {
               T000A3_A42WWPSMSId, T000A3_A46WWPSMSMessage, T000A3_A47WWPSMSSenderNumber, T000A3_A48WWPSMSRecipientNumbers, T000A3_A43WWPSMSStatus, T000A3_A49WWPSMSCreated, T000A3_A50WWPSMSScheduled, T000A3_A44WWPSMSProcessed, T000A3_n44WWPSMSProcessed, T000A3_A45WWPSMSDetail,
               T000A3_n45WWPSMSDetail, T000A3_A31WWPNotificationId, T000A3_n31WWPNotificationId
               }
               , new Object[] {
               T000A4_A33WWPNotificationCreated
               }
               , new Object[] {
               T000A5_A42WWPSMSId, T000A5_A46WWPSMSMessage, T000A5_A47WWPSMSSenderNumber, T000A5_A48WWPSMSRecipientNumbers, T000A5_A43WWPSMSStatus, T000A5_A49WWPSMSCreated, T000A5_A50WWPSMSScheduled, T000A5_A44WWPSMSProcessed, T000A5_n44WWPSMSProcessed, T000A5_A45WWPSMSDetail,
               T000A5_n45WWPSMSDetail, T000A5_A33WWPNotificationCreated, T000A5_A31WWPNotificationId, T000A5_n31WWPNotificationId
               }
               , new Object[] {
               T000A6_A33WWPNotificationCreated
               }
               , new Object[] {
               T000A7_A42WWPSMSId
               }
               , new Object[] {
               T000A8_A42WWPSMSId
               }
               , new Object[] {
               T000A9_A42WWPSMSId
               }
               , new Object[] {
               T000A10_A42WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A13_A33WWPNotificationCreated
               }
               , new Object[] {
               T000A14_A42WWPSMSId
               }
            }
         );
         Z50WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A50WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i50WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z49WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A49WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i49WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z43WWPSMSStatus = 1;
         A43WWPSMSStatus = 1;
         i43WWPSMSStatus = 1;
      }

      private short Z43WWPSMSStatus ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A43WWPSMSStatus ;
      private short Gx_BScreen ;
      private short RcdFound11 ;
      private short gxajaxcallmode ;
      private short i43WWPSMSStatus ;
      private short ZZ43WWPSMSStatus ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPSMSId_Enabled ;
      private int edtWWPSMSMessage_Enabled ;
      private int edtWWPSMSSenderNumber_Enabled ;
      private int edtWWPSMSRecipientNumbers_Enabled ;
      private int edtWWPSMSCreated_Enabled ;
      private int edtWWPSMSScheduled_Enabled ;
      private int edtWWPSMSProcessed_Enabled ;
      private int edtWWPSMSDetail_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int imgprompt_31_Visible ;
      private int edtWWPNotificationCreated_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z42WWPSMSId ;
      private long Z31WWPNotificationId ;
      private long A31WWPNotificationId ;
      private long A42WWPSMSId ;
      private long ZZ42WWPSMSId ;
      private long ZZ31WWPNotificationId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPSMSId_Internalname ;
      private string cmbWWPSMSStatus_Internalname ;
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
      private string edtWWPSMSId_Jsonclick ;
      private string edtWWPSMSMessage_Internalname ;
      private string edtWWPSMSSenderNumber_Internalname ;
      private string edtWWPSMSRecipientNumbers_Internalname ;
      private string cmbWWPSMSStatus_Jsonclick ;
      private string edtWWPSMSCreated_Internalname ;
      private string edtWWPSMSCreated_Jsonclick ;
      private string edtWWPSMSScheduled_Internalname ;
      private string edtWWPSMSScheduled_Jsonclick ;
      private string edtWWPSMSProcessed_Internalname ;
      private string edtWWPSMSProcessed_Jsonclick ;
      private string edtWWPSMSDetail_Internalname ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string imgprompt_31_gximage ;
      private string sImgUrl ;
      private string imgprompt_31_Internalname ;
      private string imgprompt_31_Link ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
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
      private string sMode11 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z49WWPSMSCreated ;
      private DateTime Z50WWPSMSScheduled ;
      private DateTime Z44WWPSMSProcessed ;
      private DateTime A49WWPSMSCreated ;
      private DateTime A50WWPSMSScheduled ;
      private DateTime A44WWPSMSProcessed ;
      private DateTime A33WWPNotificationCreated ;
      private DateTime Z33WWPNotificationCreated ;
      private DateTime i49WWPSMSCreated ;
      private DateTime i50WWPSMSScheduled ;
      private DateTime ZZ49WWPSMSCreated ;
      private DateTime ZZ50WWPSMSScheduled ;
      private DateTime ZZ44WWPSMSProcessed ;
      private DateTime ZZ33WWPNotificationCreated ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n31WWPNotificationId ;
      private bool wbErr ;
      private bool n44WWPSMSProcessed ;
      private bool n45WWPSMSDetail ;
      private string A46WWPSMSMessage ;
      private string A47WWPSMSSenderNumber ;
      private string A48WWPSMSRecipientNumbers ;
      private string A45WWPSMSDetail ;
      private string Z46WWPSMSMessage ;
      private string Z47WWPSMSSenderNumber ;
      private string Z48WWPSMSRecipientNumbers ;
      private string Z45WWPSMSDetail ;
      private string ZZ46WWPSMSMessage ;
      private string ZZ47WWPSMSSenderNumber ;
      private string ZZ48WWPSMSRecipientNumbers ;
      private string ZZ45WWPSMSDetail ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPSMSStatus ;
      private IDataStoreProvider pr_default ;
      private long[] T000A5_A42WWPSMSId ;
      private string[] T000A5_A46WWPSMSMessage ;
      private string[] T000A5_A47WWPSMSSenderNumber ;
      private string[] T000A5_A48WWPSMSRecipientNumbers ;
      private short[] T000A5_A43WWPSMSStatus ;
      private DateTime[] T000A5_A49WWPSMSCreated ;
      private DateTime[] T000A5_A50WWPSMSScheduled ;
      private DateTime[] T000A5_A44WWPSMSProcessed ;
      private bool[] T000A5_n44WWPSMSProcessed ;
      private string[] T000A5_A45WWPSMSDetail ;
      private bool[] T000A5_n45WWPSMSDetail ;
      private DateTime[] T000A5_A33WWPNotificationCreated ;
      private long[] T000A5_A31WWPNotificationId ;
      private bool[] T000A5_n31WWPNotificationId ;
      private DateTime[] T000A4_A33WWPNotificationCreated ;
      private DateTime[] T000A6_A33WWPNotificationCreated ;
      private long[] T000A7_A42WWPSMSId ;
      private long[] T000A3_A42WWPSMSId ;
      private string[] T000A3_A46WWPSMSMessage ;
      private string[] T000A3_A47WWPSMSSenderNumber ;
      private string[] T000A3_A48WWPSMSRecipientNumbers ;
      private short[] T000A3_A43WWPSMSStatus ;
      private DateTime[] T000A3_A49WWPSMSCreated ;
      private DateTime[] T000A3_A50WWPSMSScheduled ;
      private DateTime[] T000A3_A44WWPSMSProcessed ;
      private bool[] T000A3_n44WWPSMSProcessed ;
      private string[] T000A3_A45WWPSMSDetail ;
      private bool[] T000A3_n45WWPSMSDetail ;
      private long[] T000A3_A31WWPNotificationId ;
      private bool[] T000A3_n31WWPNotificationId ;
      private long[] T000A8_A42WWPSMSId ;
      private long[] T000A9_A42WWPSMSId ;
      private long[] T000A2_A42WWPSMSId ;
      private string[] T000A2_A46WWPSMSMessage ;
      private string[] T000A2_A47WWPSMSSenderNumber ;
      private string[] T000A2_A48WWPSMSRecipientNumbers ;
      private short[] T000A2_A43WWPSMSStatus ;
      private DateTime[] T000A2_A49WWPSMSCreated ;
      private DateTime[] T000A2_A50WWPSMSScheduled ;
      private DateTime[] T000A2_A44WWPSMSProcessed ;
      private bool[] T000A2_n44WWPSMSProcessed ;
      private string[] T000A2_A45WWPSMSDetail ;
      private bool[] T000A2_n45WWPSMSDetail ;
      private long[] T000A2_A31WWPNotificationId ;
      private bool[] T000A2_n31WWPNotificationId ;
      private long[] T000A10_A42WWPSMSId ;
      private DateTime[] T000A13_A33WWPNotificationCreated ;
      private long[] T000A14_A42WWPSMSId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_sms__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sms__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000A2;
        prmT000A2 = new Object[] {
        new ParDef("@WWPSMSId",GXType.Decimal,10,0)
        };
        Object[] prmT000A3;
        prmT000A3 = new Object[] {
        new ParDef("@WWPSMSId",GXType.Decimal,10,0)
        };
        Object[] prmT000A4;
        prmT000A4 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000A5;
        prmT000A5 = new Object[] {
        new ParDef("@WWPSMSId",GXType.Decimal,10,0)
        };
        Object[] prmT000A6;
        prmT000A6 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000A7;
        prmT000A7 = new Object[] {
        new ParDef("@WWPSMSId",GXType.Decimal,10,0)
        };
        Object[] prmT000A8;
        prmT000A8 = new Object[] {
        new ParDef("@WWPSMSId",GXType.Decimal,10,0)
        };
        Object[] prmT000A9;
        prmT000A9 = new Object[] {
        new ParDef("@WWPSMSId",GXType.Decimal,10,0)
        };
        Object[] prmT000A10;
        prmT000A10 = new Object[] {
        new ParDef("@WWPSMSMessage",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPSMSSenderNumber",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPSMSRecipientNumbers",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPSMSStatus",GXType.Int16,4,0) ,
        new ParDef("@WWPSMSCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPSMSScheduled",GXType.DateTime2,10,12) ,
        new ParDef("@WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("@WWPSMSDetail",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000A11;
        prmT000A11 = new Object[] {
        new ParDef("@WWPSMSMessage",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPSMSSenderNumber",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPSMSRecipientNumbers",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPSMSStatus",GXType.Int16,4,0) ,
        new ParDef("@WWPSMSCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPSMSScheduled",GXType.DateTime2,10,12) ,
        new ParDef("@WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("@WWPSMSDetail",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@WWPSMSId",GXType.Decimal,10,0)
        };
        Object[] prmT000A12;
        prmT000A12 = new Object[] {
        new ParDef("@WWPSMSId",GXType.Decimal,10,0)
        };
        Object[] prmT000A13;
        prmT000A13 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000A14;
        prmT000A14 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000A2", "SELECT [WWPSMSId], [WWPSMSMessage], [WWPSMSSenderNumber], [WWPSMSRecipientNumbers], [WWPSMSStatus], [WWPSMSCreated], [WWPSMSScheduled], [WWPSMSProcessed], [WWPSMSDetail], [WWPNotificationId] FROM [WWP_SMS] WITH (UPDLOCK) WHERE [WWPSMSId] = @WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A3", "SELECT [WWPSMSId], [WWPSMSMessage], [WWPSMSSenderNumber], [WWPSMSRecipientNumbers], [WWPSMSStatus], [WWPSMSCreated], [WWPSMSScheduled], [WWPSMSProcessed], [WWPSMSDetail], [WWPNotificationId] FROM [WWP_SMS] WHERE [WWPSMSId] = @WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A4", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A5", "SELECT TM1.[WWPSMSId], TM1.[WWPSMSMessage], TM1.[WWPSMSSenderNumber], TM1.[WWPSMSRecipientNumbers], TM1.[WWPSMSStatus], TM1.[WWPSMSCreated], TM1.[WWPSMSScheduled], TM1.[WWPSMSProcessed], TM1.[WWPSMSDetail], T2.[WWPNotificationCreated], TM1.[WWPNotificationId] FROM ([WWP_SMS] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) WHERE TM1.[WWPSMSId] = @WWPSMSId ORDER BY TM1.[WWPSMSId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A6", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A7", "SELECT [WWPSMSId] FROM [WWP_SMS] WHERE [WWPSMSId] = @WWPSMSId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A8", "SELECT TOP 1 [WWPSMSId] FROM [WWP_SMS] WHERE ( [WWPSMSId] > @WWPSMSId) ORDER BY [WWPSMSId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000A9", "SELECT TOP 1 [WWPSMSId] FROM [WWP_SMS] WHERE ( [WWPSMSId] < @WWPSMSId) ORDER BY [WWPSMSId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000A10", "INSERT INTO [WWP_SMS]([WWPSMSMessage], [WWPSMSSenderNumber], [WWPSMSRecipientNumbers], [WWPSMSStatus], [WWPSMSCreated], [WWPSMSScheduled], [WWPSMSProcessed], [WWPSMSDetail], [WWPNotificationId]) VALUES(@WWPSMSMessage, @WWPSMSSenderNumber, @WWPSMSRecipientNumbers, @WWPSMSStatus, @WWPSMSCreated, @WWPSMSScheduled, @WWPSMSProcessed, @WWPSMSDetail, @WWPNotificationId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000A10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000A11", "UPDATE [WWP_SMS] SET [WWPSMSMessage]=@WWPSMSMessage, [WWPSMSSenderNumber]=@WWPSMSSenderNumber, [WWPSMSRecipientNumbers]=@WWPSMSRecipientNumbers, [WWPSMSStatus]=@WWPSMSStatus, [WWPSMSCreated]=@WWPSMSCreated, [WWPSMSScheduled]=@WWPSMSScheduled, [WWPSMSProcessed]=@WWPSMSProcessed, [WWPSMSDetail]=@WWPSMSDetail, [WWPNotificationId]=@WWPNotificationId  WHERE [WWPSMSId] = @WWPSMSId", GxErrorMask.GX_NOMASK,prmT000A11)
           ,new CursorDef("T000A12", "DELETE FROM [WWP_SMS]  WHERE [WWPSMSId] = @WWPSMSId", GxErrorMask.GX_NOMASK,prmT000A12)
           ,new CursorDef("T000A13", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A14", "SELECT [WWPSMSId] FROM [WWP_SMS] ORDER BY [WWPSMSId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A14,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((long[]) buf[12])[0] = rslt.getLong(11);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              return;
           case 4 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
