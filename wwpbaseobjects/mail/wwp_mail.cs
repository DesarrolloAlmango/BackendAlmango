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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_mail : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridwwp_mail_attachments") == 0 )
         {
            gxnrGridwwp_mail_attachments_newrow_invoke( ) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Mail", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridwwp_mail_attachments_newrow_invoke( )
      {
         nRC_GXsfl_113 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_113"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_113_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_113_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_113_idx = GetPar( "sGXsfl_113_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridwwp_mail_attachments_newrow( ) ;
         /* End function gxnrGridwwp_mail_attachments_newrow_invoke */
      }

      public wwp_mail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_mail( IGxContext context )
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
         cmbWWPMailStatus = new GXCombobox();
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
         if ( cmbWWPMailStatus.ItemCount > 0 )
         {
            A90WWPMailStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPMailStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A90WWPMailStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A90WWPMailStatus", StringUtil.LTrimStr( (decimal)(A90WWPMailStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A90WWPMailStatus), 4, 0));
            AssignProp("", false, cmbWWPMailStatus_Internalname, "Values", cmbWWPMailStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Mail", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"wwpbaseobjects.mail.gx00h0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPMAILID"+"'), id:'"+"WWPMAILID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A89WWPMailId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPMailId_Enabled!=0) ? context.localUtil.Format( (decimal)(A89WWPMailId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A89WWPMailId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailSubject_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailSubject_Internalname, context.GetMessage( "Subject", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailSubject_Internalname, A78WWPMailSubject, StringUtil.RTrim( context.localUtil.Format( A78WWPMailSubject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailSubject_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailSubject_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailBody_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailBody_Internalname, context.GetMessage( "Body", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailBody_Internalname, A70WWPMailBody, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 1, 1, edtWWPMailBody_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "GeneXus\\Html", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailTo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTo_Internalname, context.GetMessage( "To", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailTo_Internalname, A79WWPMailTo, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtWWPMailTo_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailCC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailCC_Internalname, context.GetMessage( "CC", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailCC_Internalname, A92WWPMailCC, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtWWPMailCC_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailBCC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailBCC_Internalname, context.GetMessage( "BCC", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailBCC_Internalname, A93WWPMailBCC, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtWWPMailBCC_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailSenderAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailSenderAddress_Internalname, context.GetMessage( "Sender Address", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailSenderAddress_Internalname, A80WWPMailSenderAddress, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtWWPMailSenderAddress_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailSenderName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailSenderName_Internalname, context.GetMessage( "Sender Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailSenderName_Internalname, A81WWPMailSenderName, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtWWPMailSenderName_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPMailStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPMailStatus_Internalname, context.GetMessage( "Status", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPMailStatus, cmbWWPMailStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A90WWPMailStatus), 4, 0)), 1, cmbWWPMailStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPMailStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 0, "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A90WWPMailStatus), 4, 0));
         AssignProp("", false, cmbWWPMailStatus_Internalname, "Values", (string)(cmbWWPMailStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailCreated_Internalname, context.GetMessage( "Created", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPMailCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPMailCreated_Internalname, context.localUtil.TToC( A100WWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A100WWPMailCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPMailCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPMailCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailScheduled_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailScheduled_Internalname, context.GetMessage( "Scheduled", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPMailScheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPMailScheduled_Internalname, context.localUtil.TToC( A101WWPMailScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A101WWPMailScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailScheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailScheduled_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPMailScheduled_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPMailScheduled_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailProcessed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailProcessed_Internalname, context.GetMessage( "Processed", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPMailProcessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPMailProcessed_Internalname, context.localUtil.TToC( A95WWPMailProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A95WWPMailProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailProcessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailProcessed_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPMailProcessed_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPMailProcessed_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailDetail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailDetail_Internalname, context.GetMessage( "Detail", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailDetail_Internalname, A96WWPMailDetail, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", 0, 1, edtWWPMailDetail_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A31WWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A31WWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_31_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_31_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_31_Internalname, sImgUrl, imgprompt_31_Link, "", "", context.GetTheme( ), imgprompt_31_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A33WWPNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divAttachmentstable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleattachments_Internalname, context.GetMessage( "Attachments", ""), "", "", lblTitleattachments_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridwwp_mail_attachments( ) ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridwwp_mail_attachments( )
      {
         /*  Grid Control  */
         StartGridControl113( ) ;
         nGXsfl_113_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount18 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_18 = 1;
               ScanStart0G18( ) ;
               while ( RcdFound18 != 0 )
               {
                  init_level_properties18( ) ;
                  getByPrimaryKey0G18( ) ;
                  AddRow0G18( ) ;
                  ScanNext0G18( ) ;
               }
               ScanEnd0G18( ) ;
               nBlankRcdCount18 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0G18( ) ;
            standaloneModal0G18( ) ;
            sMode18 = Gx_mode;
            while ( nGXsfl_113_idx < nRC_GXsfl_113 )
            {
               bGXsfl_113_Refreshing = true;
               ReadRow0G18( ) ;
               edtWWPMailAttachmentName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_113_Refreshing);
               edtWWPMailAttachmentFile_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWWPMailAttachmentFile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0), !bGXsfl_113_Refreshing);
               if ( ( nRcdExists_18 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0G18( ) ;
               }
               SendRow0G18( ) ;
               bGXsfl_113_Refreshing = false;
            }
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount18 = 5;
            nRcdExists_18 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0G18( ) ;
               while ( RcdFound18 != 0 )
               {
                  sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_11318( ) ;
                  init_level_properties18( ) ;
                  standaloneNotModal0G18( ) ;
                  getByPrimaryKey0G18( ) ;
                  standaloneModal0G18( ) ;
                  AddRow0G18( ) ;
                  ScanNext0G18( ) ;
               }
               ScanEnd0G18( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode18 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx+1), 4, 0), 4, "0");
         SubsflControlProps_11318( ) ;
         InitAll0G18( ) ;
         init_level_properties18( ) ;
         nRcdExists_18 = 0;
         nIsMod_18 = 0;
         nRcdDeleted_18 = 0;
         nBlankRcdCount18 = (short)(nBlankRcdUsr18+nBlankRcdCount18);
         fRowAdded = 0;
         while ( nBlankRcdCount18 > 0 )
         {
            standaloneNotModal0G18( ) ;
            standaloneModal0G18( ) ;
            AddRow0G18( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtWWPMailAttachmentName_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount18 = (short)(nBlankRcdCount18-1);
         }
         Gx_mode = sMode18;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridwwp_mail_attachmentsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridwwp_mail_attachments", Gridwwp_mail_attachmentsContainer, subGridwwp_mail_attachments_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridwwp_mail_attachmentsContainerData", Gridwwp_mail_attachmentsContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridwwp_mail_attachmentsContainerData"+"V", Gridwwp_mail_attachmentsContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridwwp_mail_attachmentsContainerData"+"V"+"\" value='"+Gridwwp_mail_attachmentsContainer.GridValuesHidden()+"'/>") ;
         }
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
            Z89WWPMailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z89WWPMailId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z78WWPMailSubject = cgiGet( "Z78WWPMailSubject");
            Z90WWPMailStatus = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z90WWPMailStatus"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z100WWPMailCreated = context.localUtil.CToT( cgiGet( "Z100WWPMailCreated"), 0);
            Z101WWPMailScheduled = context.localUtil.CToT( cgiGet( "Z101WWPMailScheduled"), 0);
            Z95WWPMailProcessed = context.localUtil.CToT( cgiGet( "Z95WWPMailProcessed"), 0);
            n95WWPMailProcessed = ((DateTime.MinValue==A95WWPMailProcessed) ? true : false);
            Z31WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z31WWPNotificationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n31WWPNotificationId = ((0==A31WWPNotificationId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_113 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_113"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPMailId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPMailId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPMAILID");
               AnyError = 1;
               GX_FocusControl = edtWWPMailId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A89WWPMailId = 0;
               AssignAttri("", false, "A89WWPMailId", StringUtil.LTrimStr( (decimal)(A89WWPMailId), 10, 0));
            }
            else
            {
               A89WWPMailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPMailId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A89WWPMailId", StringUtil.LTrimStr( (decimal)(A89WWPMailId), 10, 0));
            }
            A78WWPMailSubject = cgiGet( edtWWPMailSubject_Internalname);
            AssignAttri("", false, "A78WWPMailSubject", A78WWPMailSubject);
            A70WWPMailBody = cgiGet( edtWWPMailBody_Internalname);
            AssignAttri("", false, "A70WWPMailBody", A70WWPMailBody);
            A79WWPMailTo = cgiGet( edtWWPMailTo_Internalname);
            n79WWPMailTo = false;
            AssignAttri("", false, "A79WWPMailTo", A79WWPMailTo);
            n79WWPMailTo = (String.IsNullOrEmpty(StringUtil.RTrim( A79WWPMailTo)) ? true : false);
            A92WWPMailCC = cgiGet( edtWWPMailCC_Internalname);
            n92WWPMailCC = false;
            AssignAttri("", false, "A92WWPMailCC", A92WWPMailCC);
            n92WWPMailCC = (String.IsNullOrEmpty(StringUtil.RTrim( A92WWPMailCC)) ? true : false);
            A93WWPMailBCC = cgiGet( edtWWPMailBCC_Internalname);
            n93WWPMailBCC = false;
            AssignAttri("", false, "A93WWPMailBCC", A93WWPMailBCC);
            n93WWPMailBCC = (String.IsNullOrEmpty(StringUtil.RTrim( A93WWPMailBCC)) ? true : false);
            A80WWPMailSenderAddress = cgiGet( edtWWPMailSenderAddress_Internalname);
            AssignAttri("", false, "A80WWPMailSenderAddress", A80WWPMailSenderAddress);
            A81WWPMailSenderName = cgiGet( edtWWPMailSenderName_Internalname);
            AssignAttri("", false, "A81WWPMailSenderName", A81WWPMailSenderName);
            cmbWWPMailStatus.Name = cmbWWPMailStatus_Internalname;
            cmbWWPMailStatus.CurrentValue = cgiGet( cmbWWPMailStatus_Internalname);
            A90WWPMailStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPMailStatus_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A90WWPMailStatus", StringUtil.LTrimStr( (decimal)(A90WWPMailStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPMailCreated_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Mail Created", "")}), 1, "WWPMAILCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPMailCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A100WWPMailCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A100WWPMailCreated", context.localUtil.TToC( A100WWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A100WWPMailCreated = context.localUtil.CToT( cgiGet( edtWWPMailCreated_Internalname));
               AssignAttri("", false, "A100WWPMailCreated", context.localUtil.TToC( A100WWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPMailScheduled_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Mail Scheduled", "")}), 1, "WWPMAILSCHEDULED");
               AnyError = 1;
               GX_FocusControl = edtWWPMailScheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A101WWPMailScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A101WWPMailScheduled", context.localUtil.TToC( A101WWPMailScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A101WWPMailScheduled = context.localUtil.CToT( cgiGet( edtWWPMailScheduled_Internalname));
               AssignAttri("", false, "A101WWPMailScheduled", context.localUtil.TToC( A101WWPMailScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPMailProcessed_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Mail Processed", "")}), 1, "WWPMAILPROCESSED");
               AnyError = 1;
               GX_FocusControl = edtWWPMailProcessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A95WWPMailProcessed = (DateTime)(DateTime.MinValue);
               n95WWPMailProcessed = false;
               AssignAttri("", false, "A95WWPMailProcessed", context.localUtil.TToC( A95WWPMailProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A95WWPMailProcessed = context.localUtil.CToT( cgiGet( edtWWPMailProcessed_Internalname));
               n95WWPMailProcessed = false;
               AssignAttri("", false, "A95WWPMailProcessed", context.localUtil.TToC( A95WWPMailProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            n95WWPMailProcessed = ((DateTime.MinValue==A95WWPMailProcessed) ? true : false);
            A96WWPMailDetail = cgiGet( edtWWPMailDetail_Internalname);
            n96WWPMailDetail = false;
            AssignAttri("", false, "A96WWPMailDetail", A96WWPMailDetail);
            n96WWPMailDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A96WWPMailDetail)) ? true : false);
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
            /* Check if conditions changed and reset current page numbers */
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A89WWPMailId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPMailId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A89WWPMailId", StringUtil.LTrimStr( (decimal)(A89WWPMailId), 10, 0));
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
               InitAll0G17( ) ;
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
         DisableAttributes0G17( ) ;
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

      protected void CONFIRM_0G18( )
      {
         nGXsfl_113_idx = 0;
         while ( nGXsfl_113_idx < nRC_GXsfl_113 )
         {
            ReadRow0G18( ) ;
            if ( ( nRcdExists_18 != 0 ) || ( nIsMod_18 != 0 ) )
            {
               GetKey0G18( ) ;
               if ( ( nRcdExists_18 == 0 ) && ( nRcdDeleted_18 == 0 ) )
               {
                  if ( RcdFound18 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0G18( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0G18( ) ;
                        CloseExtendedTableCursors0G18( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "WWPMAILATTACHMENTNAME_" + sGXsfl_113_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtWWPMailAttachmentName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound18 != 0 )
                  {
                     if ( nRcdDeleted_18 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0G18( ) ;
                        Load0G18( ) ;
                        BeforeValidate0G18( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0G18( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_18 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0G18( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0G18( ) ;
                              CloseExtendedTableCursors0G18( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_18 == 0 )
                     {
                        GXCCtl = "WWPMAILATTACHMENTNAME_" + sGXsfl_113_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPMailAttachmentName_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtWWPMailAttachmentName_Internalname, A102WWPMailAttachmentName) ;
            ChangePostValue( edtWWPMailAttachmentFile_Internalname, A94WWPMailAttachmentFile) ;
            ChangePostValue( "ZT_"+"Z102WWPMailAttachmentName_"+sGXsfl_113_idx, Z102WWPMailAttachmentName) ;
            ChangePostValue( "nRcdDeleted_18_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_18), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_18_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_18), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_18_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_18), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_18 != 0 )
            {
               ChangePostValue( "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0G0( )
      {
      }

      protected void ZM0G17( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z78WWPMailSubject = T000G5_A78WWPMailSubject[0];
               Z90WWPMailStatus = T000G5_A90WWPMailStatus[0];
               Z100WWPMailCreated = T000G5_A100WWPMailCreated[0];
               Z101WWPMailScheduled = T000G5_A101WWPMailScheduled[0];
               Z95WWPMailProcessed = T000G5_A95WWPMailProcessed[0];
               Z31WWPNotificationId = T000G5_A31WWPNotificationId[0];
            }
            else
            {
               Z78WWPMailSubject = A78WWPMailSubject;
               Z90WWPMailStatus = A90WWPMailStatus;
               Z100WWPMailCreated = A100WWPMailCreated;
               Z101WWPMailScheduled = A101WWPMailScheduled;
               Z95WWPMailProcessed = A95WWPMailProcessed;
               Z31WWPNotificationId = A31WWPNotificationId;
            }
         }
         if ( GX_JID == -8 )
         {
            Z89WWPMailId = A89WWPMailId;
            Z78WWPMailSubject = A78WWPMailSubject;
            Z70WWPMailBody = A70WWPMailBody;
            Z79WWPMailTo = A79WWPMailTo;
            Z92WWPMailCC = A92WWPMailCC;
            Z93WWPMailBCC = A93WWPMailBCC;
            Z80WWPMailSenderAddress = A80WWPMailSenderAddress;
            Z81WWPMailSenderName = A81WWPMailSenderName;
            Z90WWPMailStatus = A90WWPMailStatus;
            Z100WWPMailCreated = A100WWPMailCreated;
            Z101WWPMailScheduled = A101WWPMailScheduled;
            Z95WWPMailProcessed = A95WWPMailProcessed;
            Z96WWPMailDetail = A96WWPMailDetail;
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
         if ( IsIns( )  && (0==A90WWPMailStatus) && ( Gx_BScreen == 0 ) )
         {
            A90WWPMailStatus = 1;
            AssignAttri("", false, "A90WWPMailStatus", StringUtil.LTrimStr( (decimal)(A90WWPMailStatus), 4, 0));
         }
         if ( IsIns( )  && (DateTime.MinValue==A100WWPMailCreated) && ( Gx_BScreen == 0 ) )
         {
            A100WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A100WWPMailCreated", context.localUtil.TToC( A100WWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A101WWPMailScheduled) && ( Gx_BScreen == 0 ) )
         {
            A101WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A101WWPMailScheduled", context.localUtil.TToC( A101WWPMailScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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

      protected void Load0G17( )
      {
         /* Using cursor T000G7 */
         pr_default.execute(5, new Object[] {A89WWPMailId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound17 = 1;
            A78WWPMailSubject = T000G7_A78WWPMailSubject[0];
            AssignAttri("", false, "A78WWPMailSubject", A78WWPMailSubject);
            A70WWPMailBody = T000G7_A70WWPMailBody[0];
            AssignAttri("", false, "A70WWPMailBody", A70WWPMailBody);
            A79WWPMailTo = T000G7_A79WWPMailTo[0];
            n79WWPMailTo = T000G7_n79WWPMailTo[0];
            AssignAttri("", false, "A79WWPMailTo", A79WWPMailTo);
            A92WWPMailCC = T000G7_A92WWPMailCC[0];
            n92WWPMailCC = T000G7_n92WWPMailCC[0];
            AssignAttri("", false, "A92WWPMailCC", A92WWPMailCC);
            A93WWPMailBCC = T000G7_A93WWPMailBCC[0];
            n93WWPMailBCC = T000G7_n93WWPMailBCC[0];
            AssignAttri("", false, "A93WWPMailBCC", A93WWPMailBCC);
            A80WWPMailSenderAddress = T000G7_A80WWPMailSenderAddress[0];
            AssignAttri("", false, "A80WWPMailSenderAddress", A80WWPMailSenderAddress);
            A81WWPMailSenderName = T000G7_A81WWPMailSenderName[0];
            AssignAttri("", false, "A81WWPMailSenderName", A81WWPMailSenderName);
            A90WWPMailStatus = T000G7_A90WWPMailStatus[0];
            AssignAttri("", false, "A90WWPMailStatus", StringUtil.LTrimStr( (decimal)(A90WWPMailStatus), 4, 0));
            A100WWPMailCreated = T000G7_A100WWPMailCreated[0];
            AssignAttri("", false, "A100WWPMailCreated", context.localUtil.TToC( A100WWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A101WWPMailScheduled = T000G7_A101WWPMailScheduled[0];
            AssignAttri("", false, "A101WWPMailScheduled", context.localUtil.TToC( A101WWPMailScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A95WWPMailProcessed = T000G7_A95WWPMailProcessed[0];
            n95WWPMailProcessed = T000G7_n95WWPMailProcessed[0];
            AssignAttri("", false, "A95WWPMailProcessed", context.localUtil.TToC( A95WWPMailProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A96WWPMailDetail = T000G7_A96WWPMailDetail[0];
            n96WWPMailDetail = T000G7_n96WWPMailDetail[0];
            AssignAttri("", false, "A96WWPMailDetail", A96WWPMailDetail);
            A33WWPNotificationCreated = T000G7_A33WWPNotificationCreated[0];
            AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A31WWPNotificationId = T000G7_A31WWPNotificationId[0];
            n31WWPNotificationId = T000G7_n31WWPNotificationId[0];
            AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
            ZM0G17( -8) ;
         }
         pr_default.close(5);
         OnLoadActions0G17( ) ;
      }

      protected void OnLoadActions0G17( )
      {
      }

      protected void CheckExtendedTable0G17( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( A90WWPMailStatus == 1 ) || ( A90WWPMailStatus == 2 ) || ( A90WWPMailStatus == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Mail Status", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPMAILSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbWWPMailStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A100WWPMailCreated) || ( A100WWPMailCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Mail Created", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPMAILCREATED");
            AnyError = 1;
            GX_FocusControl = edtWWPMailCreated_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A101WWPMailScheduled) || ( A101WWPMailScheduled >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Mail Scheduled", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPMAILSCHEDULED");
            AnyError = 1;
            GX_FocusControl = edtWWPMailScheduled_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A95WWPMailProcessed) || ( A95WWPMailProcessed >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Mail Processed", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPMAILPROCESSED");
            AnyError = 1;
            GX_FocusControl = edtWWPMailProcessed_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000G6 */
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
         A33WWPNotificationCreated = T000G6_A33WWPNotificationCreated[0];
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0G17( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( long A31WWPNotificationId )
      {
         /* Using cursor T000G8 */
         pr_default.execute(6, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A31WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A33WWPNotificationCreated = T000G8_A33WWPNotificationCreated[0];
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0G17( )
      {
         /* Using cursor T000G9 */
         pr_default.execute(7, new Object[] {A89WWPMailId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000G5 */
         pr_default.execute(3, new Object[] {A89WWPMailId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0G17( 8) ;
            RcdFound17 = 1;
            A89WWPMailId = T000G5_A89WWPMailId[0];
            AssignAttri("", false, "A89WWPMailId", StringUtil.LTrimStr( (decimal)(A89WWPMailId), 10, 0));
            A78WWPMailSubject = T000G5_A78WWPMailSubject[0];
            AssignAttri("", false, "A78WWPMailSubject", A78WWPMailSubject);
            A70WWPMailBody = T000G5_A70WWPMailBody[0];
            AssignAttri("", false, "A70WWPMailBody", A70WWPMailBody);
            A79WWPMailTo = T000G5_A79WWPMailTo[0];
            n79WWPMailTo = T000G5_n79WWPMailTo[0];
            AssignAttri("", false, "A79WWPMailTo", A79WWPMailTo);
            A92WWPMailCC = T000G5_A92WWPMailCC[0];
            n92WWPMailCC = T000G5_n92WWPMailCC[0];
            AssignAttri("", false, "A92WWPMailCC", A92WWPMailCC);
            A93WWPMailBCC = T000G5_A93WWPMailBCC[0];
            n93WWPMailBCC = T000G5_n93WWPMailBCC[0];
            AssignAttri("", false, "A93WWPMailBCC", A93WWPMailBCC);
            A80WWPMailSenderAddress = T000G5_A80WWPMailSenderAddress[0];
            AssignAttri("", false, "A80WWPMailSenderAddress", A80WWPMailSenderAddress);
            A81WWPMailSenderName = T000G5_A81WWPMailSenderName[0];
            AssignAttri("", false, "A81WWPMailSenderName", A81WWPMailSenderName);
            A90WWPMailStatus = T000G5_A90WWPMailStatus[0];
            AssignAttri("", false, "A90WWPMailStatus", StringUtil.LTrimStr( (decimal)(A90WWPMailStatus), 4, 0));
            A100WWPMailCreated = T000G5_A100WWPMailCreated[0];
            AssignAttri("", false, "A100WWPMailCreated", context.localUtil.TToC( A100WWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A101WWPMailScheduled = T000G5_A101WWPMailScheduled[0];
            AssignAttri("", false, "A101WWPMailScheduled", context.localUtil.TToC( A101WWPMailScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A95WWPMailProcessed = T000G5_A95WWPMailProcessed[0];
            n95WWPMailProcessed = T000G5_n95WWPMailProcessed[0];
            AssignAttri("", false, "A95WWPMailProcessed", context.localUtil.TToC( A95WWPMailProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A96WWPMailDetail = T000G5_A96WWPMailDetail[0];
            n96WWPMailDetail = T000G5_n96WWPMailDetail[0];
            AssignAttri("", false, "A96WWPMailDetail", A96WWPMailDetail);
            A31WWPNotificationId = T000G5_A31WWPNotificationId[0];
            n31WWPNotificationId = T000G5_n31WWPNotificationId[0];
            AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
            Z89WWPMailId = A89WWPMailId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0G17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0G17( ) ;
            }
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0G17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G17( ) ;
         if ( RcdFound17 == 0 )
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
         RcdFound17 = 0;
         /* Using cursor T000G10 */
         pr_default.execute(8, new Object[] {A89WWPMailId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000G10_A89WWPMailId[0] < A89WWPMailId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000G10_A89WWPMailId[0] > A89WWPMailId ) ) )
            {
               A89WWPMailId = T000G10_A89WWPMailId[0];
               AssignAttri("", false, "A89WWPMailId", StringUtil.LTrimStr( (decimal)(A89WWPMailId), 10, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound17 = 0;
         /* Using cursor T000G11 */
         pr_default.execute(9, new Object[] {A89WWPMailId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000G11_A89WWPMailId[0] > A89WWPMailId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000G11_A89WWPMailId[0] < A89WWPMailId ) ) )
            {
               A89WWPMailId = T000G11_A89WWPMailId[0];
               AssignAttri("", false, "A89WWPMailId", StringUtil.LTrimStr( (decimal)(A89WWPMailId), 10, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0G17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0G17( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A89WWPMailId != Z89WWPMailId )
               {
                  A89WWPMailId = Z89WWPMailId;
                  AssignAttri("", false, "A89WWPMailId", StringUtil.LTrimStr( (decimal)(A89WWPMailId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPMAILID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0G17( ) ;
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A89WWPMailId != Z89WWPMailId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0G17( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPMAILID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPMailId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPMailId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0G17( ) ;
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
         if ( A89WWPMailId != Z89WWPMailId )
         {
            A89WWPMailId = Z89WWPMailId;
            AssignAttri("", false, "A89WWPMailId", StringUtil.LTrimStr( (decimal)(A89WWPMailId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPMAILID");
            AnyError = 1;
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPMailId_Internalname;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPMAILID");
            AnyError = 1;
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G17( ) ;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
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
         ScanStart0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound17 != 0 )
            {
               ScanNext0G17( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G17( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0G17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000G4 */
            pr_default.execute(2, new Object[] {A89WWPMailId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z78WWPMailSubject, T000G4_A78WWPMailSubject[0]) != 0 ) || ( Z90WWPMailStatus != T000G4_A90WWPMailStatus[0] ) || ( Z100WWPMailCreated != T000G4_A100WWPMailCreated[0] ) || ( Z101WWPMailScheduled != T000G4_A101WWPMailScheduled[0] ) || ( Z95WWPMailProcessed != T000G4_A95WWPMailProcessed[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z31WWPNotificationId != T000G4_A31WWPNotificationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z78WWPMailSubject, T000G4_A78WWPMailSubject[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailSubject");
                  GXUtil.WriteLogRaw("Old: ",Z78WWPMailSubject);
                  GXUtil.WriteLogRaw("Current: ",T000G4_A78WWPMailSubject[0]);
               }
               if ( Z90WWPMailStatus != T000G4_A90WWPMailStatus[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailStatus");
                  GXUtil.WriteLogRaw("Old: ",Z90WWPMailStatus);
                  GXUtil.WriteLogRaw("Current: ",T000G4_A90WWPMailStatus[0]);
               }
               if ( Z100WWPMailCreated != T000G4_A100WWPMailCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailCreated");
                  GXUtil.WriteLogRaw("Old: ",Z100WWPMailCreated);
                  GXUtil.WriteLogRaw("Current: ",T000G4_A100WWPMailCreated[0]);
               }
               if ( Z101WWPMailScheduled != T000G4_A101WWPMailScheduled[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailScheduled");
                  GXUtil.WriteLogRaw("Old: ",Z101WWPMailScheduled);
                  GXUtil.WriteLogRaw("Current: ",T000G4_A101WWPMailScheduled[0]);
               }
               if ( Z95WWPMailProcessed != T000G4_A95WWPMailProcessed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailProcessed");
                  GXUtil.WriteLogRaw("Old: ",Z95WWPMailProcessed);
                  GXUtil.WriteLogRaw("Current: ",T000G4_A95WWPMailProcessed[0]);
               }
               if ( Z31WWPNotificationId != T000G4_A31WWPNotificationId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPNotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z31WWPNotificationId);
                  GXUtil.WriteLogRaw("Current: ",T000G4_A31WWPNotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Mail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G17( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G17( 0) ;
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G12 */
                     pr_default.execute(10, new Object[] {A78WWPMailSubject, A70WWPMailBody, n79WWPMailTo, A79WWPMailTo, n92WWPMailCC, A92WWPMailCC, n93WWPMailBCC, A93WWPMailBCC, A80WWPMailSenderAddress, A81WWPMailSenderName, A90WWPMailStatus, A100WWPMailCreated, A101WWPMailScheduled, n95WWPMailProcessed, A95WWPMailProcessed, n96WWPMailDetail, A96WWPMailDetail, n31WWPNotificationId, A31WWPNotificationId});
                     A89WWPMailId = T000G12_A89WWPMailId[0];
                     AssignAttri("", false, "A89WWPMailId", StringUtil.LTrimStr( (decimal)(A89WWPMailId), 10, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0G17( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0G0( ) ;
                           }
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
               Load0G17( ) ;
            }
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void Update0G17( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G13 */
                     pr_default.execute(11, new Object[] {A78WWPMailSubject, A70WWPMailBody, n79WWPMailTo, A79WWPMailTo, n92WWPMailCC, A92WWPMailCC, n93WWPMailBCC, A93WWPMailBCC, A80WWPMailSenderAddress, A81WWPMailSenderName, A90WWPMailStatus, A100WWPMailCreated, A101WWPMailScheduled, n95WWPMailProcessed, A95WWPMailProcessed, n96WWPMailDetail, A96WWPMailDetail, n31WWPNotificationId, A31WWPNotificationId, A89WWPMailId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G17( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0G17( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption0G0( ) ;
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
            }
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void DeferredUpdate0G17( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G17( ) ;
            AfterConfirm0G17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G17( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0G18( ) ;
                  while ( RcdFound18 != 0 )
                  {
                     getByPrimaryKey0G18( ) ;
                     Delete0G18( ) ;
                     ScanNext0G18( ) ;
                  }
                  ScanEnd0G18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G14 */
                     pr_default.execute(12, new Object[] {A89WWPMailId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound17 == 0 )
                           {
                              InitAll0G17( ) ;
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
                           ResetCaption0G0( ) ;
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
         }
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0G17( ) ;
         Gx_mode = sMode17;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0G17( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000G15 */
            pr_default.execute(13, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
            A33WWPNotificationCreated = T000G15_A33WWPNotificationCreated[0];
            AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            pr_default.close(13);
         }
      }

      protected void ProcessNestedLevel0G18( )
      {
         nGXsfl_113_idx = 0;
         while ( nGXsfl_113_idx < nRC_GXsfl_113 )
         {
            ReadRow0G18( ) ;
            if ( ( nRcdExists_18 != 0 ) || ( nIsMod_18 != 0 ) )
            {
               standaloneNotModal0G18( ) ;
               GetKey0G18( ) ;
               if ( ( nRcdExists_18 == 0 ) && ( nRcdDeleted_18 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0G18( ) ;
               }
               else
               {
                  if ( RcdFound18 != 0 )
                  {
                     if ( ( nRcdDeleted_18 != 0 ) && ( nRcdExists_18 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0G18( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_18 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0G18( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_18 == 0 )
                     {
                        GXCCtl = "WWPMAILATTACHMENTNAME_" + sGXsfl_113_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPMailAttachmentName_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtWWPMailAttachmentName_Internalname, A102WWPMailAttachmentName) ;
            ChangePostValue( edtWWPMailAttachmentFile_Internalname, A94WWPMailAttachmentFile) ;
            ChangePostValue( "ZT_"+"Z102WWPMailAttachmentName_"+sGXsfl_113_idx, Z102WWPMailAttachmentName) ;
            ChangePostValue( "nRcdDeleted_18_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_18), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_18_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_18), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_18_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_18), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_18 != 0 )
            {
               ChangePostValue( "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0G18( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_18 = 0;
         nIsMod_18 = 0;
         nRcdDeleted_18 = 0;
      }

      protected void ProcessLevel0G17( )
      {
         /* Save parent mode. */
         sMode17 = Gx_mode;
         ProcessNestedLevel0G18( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode17;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0G17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(13);
            context.CommitDataStores("wwpbaseobjects.mail.wwp_mail",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(13);
            context.RollbackDataStores("wwpbaseobjects.mail.wwp_mail",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0G17( )
      {
         /* Using cursor T000G16 */
         pr_default.execute(14);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound17 = 1;
            A89WWPMailId = T000G16_A89WWPMailId[0];
            AssignAttri("", false, "A89WWPMailId", StringUtil.LTrimStr( (decimal)(A89WWPMailId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0G17( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound17 = 1;
            A89WWPMailId = T000G16_A89WWPMailId[0];
            AssignAttri("", false, "A89WWPMailId", StringUtil.LTrimStr( (decimal)(A89WWPMailId), 10, 0));
         }
      }

      protected void ScanEnd0G17( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0G17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G17( )
      {
         edtWWPMailId_Enabled = 0;
         AssignProp("", false, edtWWPMailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailId_Enabled), 5, 0), true);
         edtWWPMailSubject_Enabled = 0;
         AssignProp("", false, edtWWPMailSubject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailSubject_Enabled), 5, 0), true);
         edtWWPMailBody_Enabled = 0;
         AssignProp("", false, edtWWPMailBody_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailBody_Enabled), 5, 0), true);
         edtWWPMailTo_Enabled = 0;
         AssignProp("", false, edtWWPMailTo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTo_Enabled), 5, 0), true);
         edtWWPMailCC_Enabled = 0;
         AssignProp("", false, edtWWPMailCC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailCC_Enabled), 5, 0), true);
         edtWWPMailBCC_Enabled = 0;
         AssignProp("", false, edtWWPMailBCC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailBCC_Enabled), 5, 0), true);
         edtWWPMailSenderAddress_Enabled = 0;
         AssignProp("", false, edtWWPMailSenderAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailSenderAddress_Enabled), 5, 0), true);
         edtWWPMailSenderName_Enabled = 0;
         AssignProp("", false, edtWWPMailSenderName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailSenderName_Enabled), 5, 0), true);
         cmbWWPMailStatus.Enabled = 0;
         AssignProp("", false, cmbWWPMailStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPMailStatus.Enabled), 5, 0), true);
         edtWWPMailCreated_Enabled = 0;
         AssignProp("", false, edtWWPMailCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailCreated_Enabled), 5, 0), true);
         edtWWPMailScheduled_Enabled = 0;
         AssignProp("", false, edtWWPMailScheduled_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailScheduled_Enabled), 5, 0), true);
         edtWWPMailProcessed_Enabled = 0;
         AssignProp("", false, edtWWPMailProcessed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailProcessed_Enabled), 5, 0), true);
         edtWWPMailDetail_Enabled = 0;
         AssignProp("", false, edtWWPMailDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailDetail_Enabled), 5, 0), true);
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
      }

      protected void ZM0G18( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -10 )
         {
            Z89WWPMailId = A89WWPMailId;
            Z102WWPMailAttachmentName = A102WWPMailAttachmentName;
            Z94WWPMailAttachmentFile = A94WWPMailAttachmentFile;
         }
      }

      protected void standaloneNotModal0G18( )
      {
      }

      protected void standaloneModal0G18( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtWWPMailAttachmentName_Enabled = 0;
            AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         }
         else
         {
            edtWWPMailAttachmentName_Enabled = 1;
            AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         }
      }

      protected void Load0G18( )
      {
         /* Using cursor T000G17 */
         pr_default.execute(15, new Object[] {A89WWPMailId, A102WWPMailAttachmentName});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound18 = 1;
            A94WWPMailAttachmentFile = T000G17_A94WWPMailAttachmentFile[0];
            ZM0G18( -10) ;
         }
         pr_default.close(15);
         OnLoadActions0G18( ) ;
      }

      protected void OnLoadActions0G18( )
      {
      }

      protected void CheckExtendedTable0G18( )
      {
         nIsDirty_18 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0G18( ) ;
      }

      protected void CloseExtendedTableCursors0G18( )
      {
      }

      protected void enableDisable0G18( )
      {
      }

      protected void GetKey0G18( )
      {
         /* Using cursor T000G18 */
         pr_default.execute(16, new Object[] {A89WWPMailId, A102WWPMailAttachmentName});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey0G18( )
      {
         /* Using cursor T000G3 */
         pr_default.execute(1, new Object[] {A89WWPMailId, A102WWPMailAttachmentName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G18( 10) ;
            RcdFound18 = 1;
            InitializeNonKey0G18( ) ;
            A102WWPMailAttachmentName = T000G3_A102WWPMailAttachmentName[0];
            A94WWPMailAttachmentFile = T000G3_A94WWPMailAttachmentFile[0];
            Z89WWPMailId = A89WWPMailId;
            Z102WWPMailAttachmentName = A102WWPMailAttachmentName;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0G18( ) ;
            Load0G18( ) ;
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0G18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0G18( ) ;
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0G18( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0G18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000G2 */
            pr_default.execute(0, new Object[] {A89WWPMailId, A102WWPMailAttachmentName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailAttachments"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G18( )
      {
         BeforeValidate0G18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G18( 0) ;
            CheckOptimisticConcurrency0G18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G19 */
                     pr_default.execute(17, new Object[] {A89WWPMailId, A102WWPMailAttachmentName, A94WWPMailAttachmentFile});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                     if ( (pr_default.getStatus(17) == 1) )
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
               Load0G18( ) ;
            }
            EndLevel0G18( ) ;
         }
         CloseExtendedTableCursors0G18( ) ;
      }

      protected void Update0G18( )
      {
         BeforeValidate0G18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G18( ) ;
         }
         if ( ( nIsMod_18 != 0 ) || ( nIsDirty_18 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0G18( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0G18( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0G18( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000G20 */
                        pr_default.execute(18, new Object[] {A94WWPMailAttachmentFile, A89WWPMailId, A102WWPMailAttachmentName});
                        pr_default.close(18);
                        pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                        if ( (pr_default.getStatus(18) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0G18( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0G18( ) ;
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
               EndLevel0G18( ) ;
            }
         }
         CloseExtendedTableCursors0G18( ) ;
      }

      protected void DeferredUpdate0G18( )
      {
      }

      protected void Delete0G18( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0G18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G18( ) ;
            AfterConfirm0G18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000G21 */
                  pr_default.execute(19, new Object[] {A89WWPMailId, A102WWPMailAttachmentName});
                  pr_default.close(19);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0G18( ) ;
         Gx_mode = sMode18;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0G18( )
      {
         standaloneModal0G18( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0G18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0G18( )
      {
         /* Scan By routine */
         /* Using cursor T000G22 */
         pr_default.execute(20, new Object[] {A89WWPMailId});
         RcdFound18 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound18 = 1;
            A102WWPMailAttachmentName = T000G22_A102WWPMailAttachmentName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0G18( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound18 = 1;
            A102WWPMailAttachmentName = T000G22_A102WWPMailAttachmentName[0];
         }
      }

      protected void ScanEnd0G18( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0G18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G18( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G18( )
      {
         edtWWPMailAttachmentName_Enabled = 0;
         AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtWWPMailAttachmentFile_Enabled = 0;
         AssignProp("", false, edtWWPMailAttachmentFile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0), !bGXsfl_113_Refreshing);
      }

      protected void send_integrity_lvl_hashes0G18( )
      {
      }

      protected void send_integrity_lvl_hashes0G17( )
      {
      }

      protected void SubsflControlProps_11318( )
      {
         edtWWPMailAttachmentName_Internalname = "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx;
         edtWWPMailAttachmentFile_Internalname = "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx;
      }

      protected void SubsflControlProps_fel_11318( )
      {
         edtWWPMailAttachmentName_Internalname = "WWPMAILATTACHMENTNAME_"+sGXsfl_113_fel_idx;
         edtWWPMailAttachmentFile_Internalname = "WWPMAILATTACHMENTFILE_"+sGXsfl_113_fel_idx;
      }

      protected void AddRow0G18( )
      {
         nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_11318( ) ;
         SendRow0G18( ) ;
      }

      protected void SendRow0G18( )
      {
         Gridwwp_mail_attachmentsRow = GXWebRow.GetNew(context);
         if ( subGridwwp_mail_attachments_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
            {
               subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Odd";
            }
         }
         else if ( subGridwwp_mail_attachments_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 0;
            subGridwwp_mail_attachments_Backcolor = subGridwwp_mail_attachments_Allbackcolor;
            if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
            {
               subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Uniform";
            }
         }
         else if ( subGridwwp_mail_attachments_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
            {
               subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Odd";
            }
            subGridwwp_mail_attachments_Backcolor = (int)(0x0);
         }
         else if ( subGridwwp_mail_attachments_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 1;
            if ( ((int)((nGXsfl_113_idx) % (2))) == 0 )
            {
               subGridwwp_mail_attachments_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
               {
                  subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Even";
               }
            }
            else
            {
               subGridwwp_mail_attachments_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
               {
                  subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_18_" + sGXsfl_113_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 114,'',false,'" + sGXsfl_113_idx + "',113)\"";
         ROClassString = "Attribute";
         Gridwwp_mail_attachmentsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPMailAttachmentName_Internalname,(string)A102WWPMailAttachmentName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPMailAttachmentName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtWWPMailAttachmentName_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_18_" + sGXsfl_113_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_113_idx + "',113)\"";
         ROClassString = "Attribute";
         Gridwwp_mail_attachmentsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPMailAttachmentFile_Internalname,(string)A94WWPMailAttachmentFile,(string)A94WWPMailAttachmentFile,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPMailAttachmentFile_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtWWPMailAttachmentFile_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)113,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridwwp_mail_attachmentsRow);
         send_integrity_lvl_hashes0G18( ) ;
         GXCCtl = "Z102WWPMailAttachmentName_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z102WWPMailAttachmentName);
         GXCCtl = "nRcdDeleted_18_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_18), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_18_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_18), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_18_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_18), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridwwp_mail_attachmentsContainer.AddRow(Gridwwp_mail_attachmentsRow);
      }

      protected void ReadRow0G18( )
      {
         nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_11318( ) ;
         edtWWPMailAttachmentName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPMailAttachmentFile_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A102WWPMailAttachmentName = cgiGet( edtWWPMailAttachmentName_Internalname);
         A94WWPMailAttachmentFile = cgiGet( edtWWPMailAttachmentFile_Internalname);
         GXCCtl = "Z102WWPMailAttachmentName_" + sGXsfl_113_idx;
         Z102WWPMailAttachmentName = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_18_" + sGXsfl_113_idx;
         nRcdDeleted_18 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_18_" + sGXsfl_113_idx;
         nRcdExists_18 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_18_" + sGXsfl_113_idx;
         nIsMod_18 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtWWPMailAttachmentName_Enabled = edtWWPMailAttachmentName_Enabled;
      }

      protected void ConfirmValues0G0( )
      {
         nGXsfl_113_idx = 0;
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_11318( ) ;
         while ( nGXsfl_113_idx < nRC_GXsfl_113 )
         {
            nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_11318( ) ;
            ChangePostValue( "Z102WWPMailAttachmentName_"+sGXsfl_113_idx, cgiGet( "ZT_"+"Z102WWPMailAttachmentName_"+sGXsfl_113_idx)) ;
            DeletePostValue( "ZT_"+"Z102WWPMailAttachmentName_"+sGXsfl_113_idx) ;
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.mail.wwp_mail.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z89WWPMailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z89WWPMailId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z78WWPMailSubject", Z78WWPMailSubject);
         GxWebStd.gx_hidden_field( context, "Z90WWPMailStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z90WWPMailStatus), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z100WWPMailCreated", context.localUtil.TToC( Z100WWPMailCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z101WWPMailScheduled", context.localUtil.TToC( Z101WWPMailScheduled, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z95WWPMailProcessed", context.localUtil.TToC( Z95WWPMailProcessed, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z31WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_113", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_113_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("wwpbaseobjects.mail.wwp_mail.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Mail.WWP_Mail" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Mail", "") ;
      }

      protected void InitializeNonKey0G17( )
      {
         A78WWPMailSubject = "";
         AssignAttri("", false, "A78WWPMailSubject", A78WWPMailSubject);
         A70WWPMailBody = "";
         AssignAttri("", false, "A70WWPMailBody", A70WWPMailBody);
         A79WWPMailTo = "";
         n79WWPMailTo = false;
         AssignAttri("", false, "A79WWPMailTo", A79WWPMailTo);
         n79WWPMailTo = (String.IsNullOrEmpty(StringUtil.RTrim( A79WWPMailTo)) ? true : false);
         A92WWPMailCC = "";
         n92WWPMailCC = false;
         AssignAttri("", false, "A92WWPMailCC", A92WWPMailCC);
         n92WWPMailCC = (String.IsNullOrEmpty(StringUtil.RTrim( A92WWPMailCC)) ? true : false);
         A93WWPMailBCC = "";
         n93WWPMailBCC = false;
         AssignAttri("", false, "A93WWPMailBCC", A93WWPMailBCC);
         n93WWPMailBCC = (String.IsNullOrEmpty(StringUtil.RTrim( A93WWPMailBCC)) ? true : false);
         A80WWPMailSenderAddress = "";
         AssignAttri("", false, "A80WWPMailSenderAddress", A80WWPMailSenderAddress);
         A81WWPMailSenderName = "";
         AssignAttri("", false, "A81WWPMailSenderName", A81WWPMailSenderName);
         A95WWPMailProcessed = (DateTime)(DateTime.MinValue);
         n95WWPMailProcessed = false;
         AssignAttri("", false, "A95WWPMailProcessed", context.localUtil.TToC( A95WWPMailProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n95WWPMailProcessed = ((DateTime.MinValue==A95WWPMailProcessed) ? true : false);
         A96WWPMailDetail = "";
         n96WWPMailDetail = false;
         AssignAttri("", false, "A96WWPMailDetail", A96WWPMailDetail);
         n96WWPMailDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A96WWPMailDetail)) ? true : false);
         A31WWPNotificationId = 0;
         n31WWPNotificationId = false;
         AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrimStr( (decimal)(A31WWPNotificationId), 10, 0));
         n31WWPNotificationId = ((0==A31WWPNotificationId) ? true : false);
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A90WWPMailStatus = 1;
         AssignAttri("", false, "A90WWPMailStatus", StringUtil.LTrimStr( (decimal)(A90WWPMailStatus), 4, 0));
         A100WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A100WWPMailCreated", context.localUtil.TToC( A100WWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A101WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A101WWPMailScheduled", context.localUtil.TToC( A101WWPMailScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         Z78WWPMailSubject = "";
         Z90WWPMailStatus = 0;
         Z100WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z101WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z95WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z31WWPNotificationId = 0;
      }

      protected void InitAll0G17( )
      {
         A89WWPMailId = 0;
         AssignAttri("", false, "A89WWPMailId", StringUtil.LTrimStr( (decimal)(A89WWPMailId), 10, 0));
         InitializeNonKey0G17( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A90WWPMailStatus = i90WWPMailStatus;
         AssignAttri("", false, "A90WWPMailStatus", StringUtil.LTrimStr( (decimal)(A90WWPMailStatus), 4, 0));
         A100WWPMailCreated = i100WWPMailCreated;
         AssignAttri("", false, "A100WWPMailCreated", context.localUtil.TToC( A100WWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A101WWPMailScheduled = i101WWPMailScheduled;
         AssignAttri("", false, "A101WWPMailScheduled", context.localUtil.TToC( A101WWPMailScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
      }

      protected void InitializeNonKey0G18( )
      {
         A94WWPMailAttachmentFile = "";
      }

      protected void InitAll0G18( )
      {
         A102WWPMailAttachmentName = "";
         InitializeNonKey0G18( ) ;
      }

      protected void StandaloneModalInsert0G18( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302185890", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/mail/wwp_mail.js", "?20267302185891", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties18( )
      {
         edtWWPMailAttachmentName_Enabled = defedtWWPMailAttachmentName_Enabled;
         AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_113_Refreshing);
      }

      protected void StartGridControl113( )
      {
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("GridName", "Gridwwp_mail_attachments");
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Header", subGridwwp_mail_attachments_Header);
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Class", "Grid");
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Backcolorstyle), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("CmpContext", "");
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("InMasterPage", "false");
         Gridwwp_mail_attachmentsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A102WWPMailAttachmentName));
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddColumnProperties(Gridwwp_mail_attachmentsColumn);
         Gridwwp_mail_attachmentsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A94WWPMailAttachmentFile));
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddColumnProperties(Gridwwp_mail_attachmentsColumn);
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Selectedindex), 4, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Allowselection), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Selectioncolor), 9, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Allowhovering), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Hoveringcolor), 9, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Allowcollapsing), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Collapsed), 1, 0, ".", "")));
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
         edtWWPMailId_Internalname = "WWPMAILID";
         edtWWPMailSubject_Internalname = "WWPMAILSUBJECT";
         edtWWPMailBody_Internalname = "WWPMAILBODY";
         edtWWPMailTo_Internalname = "WWPMAILTO";
         edtWWPMailCC_Internalname = "WWPMAILCC";
         edtWWPMailBCC_Internalname = "WWPMAILBCC";
         edtWWPMailSenderAddress_Internalname = "WWPMAILSENDERADDRESS";
         edtWWPMailSenderName_Internalname = "WWPMAILSENDERNAME";
         cmbWWPMailStatus_Internalname = "WWPMAILSTATUS";
         edtWWPMailCreated_Internalname = "WWPMAILCREATED";
         edtWWPMailScheduled_Internalname = "WWPMAILSCHEDULED";
         edtWWPMailProcessed_Internalname = "WWPMAILPROCESSED";
         edtWWPMailDetail_Internalname = "WWPMAILDETAIL";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         lblTitleattachments_Internalname = "TITLEATTACHMENTS";
         edtWWPMailAttachmentName_Internalname = "WWPMAILATTACHMENTNAME";
         edtWWPMailAttachmentFile_Internalname = "WWPMAILATTACHMENTFILE";
         divAttachmentstable_Internalname = "ATTACHMENTSTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_31_Internalname = "PROMPT_31";
         subGridwwp_mail_attachments_Internalname = "GRIDWWP_MAIL_ATTACHMENTS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridwwp_mail_attachments_Allowcollapsing = 0;
         subGridwwp_mail_attachments_Allowselection = 0;
         subGridwwp_mail_attachments_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Mail", "");
         edtWWPMailAttachmentFile_Jsonclick = "";
         edtWWPMailAttachmentName_Jsonclick = "";
         subGridwwp_mail_attachments_Class = "Grid";
         subGridwwp_mail_attachments_Backcolorstyle = 0;
         edtWWPMailAttachmentFile_Enabled = 1;
         edtWWPMailAttachmentName_Enabled = 1;
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
         edtWWPMailDetail_Enabled = 1;
         edtWWPMailProcessed_Jsonclick = "";
         edtWWPMailProcessed_Enabled = 1;
         edtWWPMailScheduled_Jsonclick = "";
         edtWWPMailScheduled_Enabled = 1;
         edtWWPMailCreated_Jsonclick = "";
         edtWWPMailCreated_Enabled = 1;
         cmbWWPMailStatus_Jsonclick = "";
         cmbWWPMailStatus.Enabled = 1;
         edtWWPMailSenderName_Enabled = 1;
         edtWWPMailSenderAddress_Enabled = 1;
         edtWWPMailBCC_Enabled = 1;
         edtWWPMailCC_Enabled = 1;
         edtWWPMailTo_Enabled = 1;
         edtWWPMailBody_Enabled = 1;
         edtWWPMailSubject_Jsonclick = "";
         edtWWPMailSubject_Enabled = 1;
         edtWWPMailId_Jsonclick = "";
         edtWWPMailId_Enabled = 1;
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

      protected void gxnrGridwwp_mail_attachments_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_11318( ) ;
         while ( nGXsfl_113_idx <= nRC_GXsfl_113 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0G18( ) ;
            standaloneModal0G18( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0G18( ) ;
            nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_11318( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridwwp_mail_attachmentsContainer)) ;
         /* End function gxnrGridwwp_mail_attachments_newrow */
      }

      protected void init_web_controls( )
      {
         cmbWWPMailStatus.Name = "WWPMAILSTATUS";
         cmbWWPMailStatus.WebTags = "";
         cmbWWPMailStatus.addItem("1", context.GetMessage( "Pending", ""), 0);
         cmbWWPMailStatus.addItem("2", context.GetMessage( "Sent", ""), 0);
         cmbWWPMailStatus.addItem("3", context.GetMessage( "Error", ""), 0);
         if ( cmbWWPMailStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A90WWPMailStatus) )
            {
               A90WWPMailStatus = 1;
               AssignAttri("", false, "A90WWPMailStatus", StringUtil.LTrimStr( (decimal)(A90WWPMailStatus), 4, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPMailSubject_Internalname;
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

      public void Valid_Wwpmailid( )
      {
         A90WWPMailStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPMailStatus.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPMailStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A90WWPMailStatus), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPMailStatus.ItemCount > 0 )
         {
            A90WWPMailStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPMailStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A90WWPMailStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPMailStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A90WWPMailStatus), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A90WWPMailStatus), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A78WWPMailSubject", A78WWPMailSubject);
         AssignAttri("", false, "A70WWPMailBody", A70WWPMailBody);
         AssignAttri("", false, "A79WWPMailTo", A79WWPMailTo);
         AssignAttri("", false, "A92WWPMailCC", A92WWPMailCC);
         AssignAttri("", false, "A93WWPMailBCC", A93WWPMailBCC);
         AssignAttri("", false, "A80WWPMailSenderAddress", A80WWPMailSenderAddress);
         AssignAttri("", false, "A81WWPMailSenderName", A81WWPMailSenderName);
         AssignAttri("", false, "A90WWPMailStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(A90WWPMailStatus), 4, 0, ".", "")));
         cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A90WWPMailStatus), 4, 0));
         AssignProp("", false, cmbWWPMailStatus_Internalname, "Values", cmbWWPMailStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A100WWPMailCreated", context.localUtil.TToC( A100WWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A101WWPMailScheduled", context.localUtil.TToC( A101WWPMailScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A95WWPMailProcessed", context.localUtil.TToC( A95WWPMailProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A96WWPMailDetail", A96WWPMailDetail);
         AssignAttri("", false, "A31WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A31WWPNotificationId), 10, 0, ".", "")));
         AssignAttri("", false, "A33WWPNotificationCreated", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z89WWPMailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z89WWPMailId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z78WWPMailSubject", Z78WWPMailSubject);
         GxWebStd.gx_hidden_field( context, "Z70WWPMailBody", Z70WWPMailBody);
         GxWebStd.gx_hidden_field( context, "Z79WWPMailTo", Z79WWPMailTo);
         GxWebStd.gx_hidden_field( context, "Z92WWPMailCC", Z92WWPMailCC);
         GxWebStd.gx_hidden_field( context, "Z93WWPMailBCC", Z93WWPMailBCC);
         GxWebStd.gx_hidden_field( context, "Z80WWPMailSenderAddress", Z80WWPMailSenderAddress);
         GxWebStd.gx_hidden_field( context, "Z81WWPMailSenderName", Z81WWPMailSenderName);
         GxWebStd.gx_hidden_field( context, "Z90WWPMailStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z90WWPMailStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z100WWPMailCreated", context.localUtil.TToC( Z100WWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z101WWPMailScheduled", context.localUtil.TToC( Z101WWPMailScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z95WWPMailProcessed", context.localUtil.TToC( Z95WWPMailProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z96WWPMailDetail", Z96WWPMailDetail);
         GxWebStd.gx_hidden_field( context, "Z31WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z33WWPNotificationCreated", context.localUtil.TToC( Z33WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationid( )
      {
         n31WWPNotificationId = false;
         /* Using cursor T000G15 */
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
         A33WWPNotificationCreated = T000G15_A33WWPNotificationCreated[0];
         pr_default.close(13);
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
         setEventMetadata("VALID_WWPMAILID","{handler:'Valid_Wwpmailid',iparms:[{av:'A89WWPMailId',fld:'WWPMAILID',pic:'ZZZZZZZZZ9',type:'int'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'cmbWWPMailStatus'},{av:'A90WWPMailStatus',fld:'WWPMAILSTATUS',pic:'ZZZ9',type:'int'},{av:'A100WWPMailCreated',fld:'WWPMAILCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A101WWPMailScheduled',fld:'WWPMAILSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'}]");
         setEventMetadata("VALID_WWPMAILID",",oparms:[{av:'A78WWPMailSubject',fld:'WWPMAILSUBJECT',pic:'',type:'svchar'},{av:'A70WWPMailBody',fld:'WWPMAILBODY',pic:'',type:'vchar'},{av:'A79WWPMailTo',fld:'WWPMAILTO',pic:'',type:'vchar'},{av:'A92WWPMailCC',fld:'WWPMAILCC',pic:'',type:'vchar'},{av:'A93WWPMailBCC',fld:'WWPMAILBCC',pic:'',type:'vchar'},{av:'A80WWPMailSenderAddress',fld:'WWPMAILSENDERADDRESS',pic:'',type:'vchar'},{av:'A81WWPMailSenderName',fld:'WWPMAILSENDERNAME',pic:'',type:'vchar'},{av:'cmbWWPMailStatus'},{av:'A90WWPMailStatus',fld:'WWPMAILSTATUS',pic:'ZZZ9',type:'int'},{av:'A100WWPMailCreated',fld:'WWPMAILCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A101WWPMailScheduled',fld:'WWPMAILSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A95WWPMailProcessed',fld:'WWPMAILPROCESSED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A96WWPMailDetail',fld:'WWPMAILDETAIL',pic:'',type:'vchar'},{av:'A31WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A33WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z89WWPMailId',type:'int'},{av:'Z78WWPMailSubject',type:'svchar'},{av:'Z70WWPMailBody',type:'vchar'},{av:'Z79WWPMailTo',type:'vchar'},{av:'Z92WWPMailCC',type:'vchar'},{av:'Z93WWPMailBCC',type:'vchar'},{av:'Z80WWPMailSenderAddress',type:'vchar'},{av:'Z81WWPMailSenderName',type:'vchar'},{av:'Z90WWPMailStatus',type:'int'},{av:'Z100WWPMailCreated',type:'dtime'},{av:'Z101WWPMailScheduled',type:'dtime'},{av:'Z95WWPMailProcessed',type:'dtime'},{av:'Z96WWPMailDetail',type:'vchar'},{av:'Z31WWPNotificationId',type:'int'},{av:'Z33WWPNotificationCreated',type:'dtime'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_WWPMAILSTATUS","{handler:'Valid_Wwpmailstatus',iparms:[]");
         setEventMetadata("VALID_WWPMAILSTATUS",",oparms:[]}");
         setEventMetadata("VALID_WWPMAILCREATED","{handler:'Valid_Wwpmailcreated',iparms:[]");
         setEventMetadata("VALID_WWPMAILCREATED",",oparms:[]}");
         setEventMetadata("VALID_WWPMAILSCHEDULED","{handler:'Valid_Wwpmailscheduled',iparms:[]");
         setEventMetadata("VALID_WWPMAILSCHEDULED",",oparms:[]}");
         setEventMetadata("VALID_WWPMAILPROCESSED","{handler:'Valid_Wwpmailprocessed',iparms:[]");
         setEventMetadata("VALID_WWPMAILPROCESSED",",oparms:[]}");
         setEventMetadata("VALID_WWPNOTIFICATIONID","{handler:'Valid_Wwpnotificationid',iparms:[{av:'A31WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A33WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONID",",oparms:[{av:'A33WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'}]}");
         setEventMetadata("VALID_WWPMAILATTACHMENTNAME","{handler:'Valid_Wwpmailattachmentname',iparms:[]");
         setEventMetadata("VALID_WWPMAILATTACHMENTNAME",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Wwpmailattachmentfile',iparms:[]");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(3);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z78WWPMailSubject = "";
         Z100WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z101WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z95WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z102WWPMailAttachmentName = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         Gx_mode = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A78WWPMailSubject = "";
         A70WWPMailBody = "";
         A79WWPMailTo = "";
         A92WWPMailCC = "";
         A93WWPMailBCC = "";
         A80WWPMailSenderAddress = "";
         A81WWPMailSenderName = "";
         A100WWPMailCreated = (DateTime)(DateTime.MinValue);
         A101WWPMailScheduled = (DateTime)(DateTime.MinValue);
         A95WWPMailProcessed = (DateTime)(DateTime.MinValue);
         A96WWPMailDetail = "";
         imgprompt_31_gximage = "";
         sImgUrl = "";
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         lblTitleattachments_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridwwp_mail_attachmentsContainer = new GXWebGrid( context);
         sMode18 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A102WWPMailAttachmentName = "";
         A94WWPMailAttachmentFile = "";
         Z70WWPMailBody = "";
         Z79WWPMailTo = "";
         Z92WWPMailCC = "";
         Z93WWPMailBCC = "";
         Z80WWPMailSenderAddress = "";
         Z81WWPMailSenderName = "";
         Z96WWPMailDetail = "";
         Z33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         T000G7_A89WWPMailId = new long[1] ;
         T000G7_A78WWPMailSubject = new string[] {""} ;
         T000G7_A70WWPMailBody = new string[] {""} ;
         T000G7_A79WWPMailTo = new string[] {""} ;
         T000G7_n79WWPMailTo = new bool[] {false} ;
         T000G7_A92WWPMailCC = new string[] {""} ;
         T000G7_n92WWPMailCC = new bool[] {false} ;
         T000G7_A93WWPMailBCC = new string[] {""} ;
         T000G7_n93WWPMailBCC = new bool[] {false} ;
         T000G7_A80WWPMailSenderAddress = new string[] {""} ;
         T000G7_A81WWPMailSenderName = new string[] {""} ;
         T000G7_A90WWPMailStatus = new short[1] ;
         T000G7_A100WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         T000G7_A101WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         T000G7_A95WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         T000G7_n95WWPMailProcessed = new bool[] {false} ;
         T000G7_A96WWPMailDetail = new string[] {""} ;
         T000G7_n96WWPMailDetail = new bool[] {false} ;
         T000G7_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000G7_A31WWPNotificationId = new long[1] ;
         T000G7_n31WWPNotificationId = new bool[] {false} ;
         T000G6_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000G8_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000G9_A89WWPMailId = new long[1] ;
         T000G5_A89WWPMailId = new long[1] ;
         T000G5_A78WWPMailSubject = new string[] {""} ;
         T000G5_A70WWPMailBody = new string[] {""} ;
         T000G5_A79WWPMailTo = new string[] {""} ;
         T000G5_n79WWPMailTo = new bool[] {false} ;
         T000G5_A92WWPMailCC = new string[] {""} ;
         T000G5_n92WWPMailCC = new bool[] {false} ;
         T000G5_A93WWPMailBCC = new string[] {""} ;
         T000G5_n93WWPMailBCC = new bool[] {false} ;
         T000G5_A80WWPMailSenderAddress = new string[] {""} ;
         T000G5_A81WWPMailSenderName = new string[] {""} ;
         T000G5_A90WWPMailStatus = new short[1] ;
         T000G5_A100WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         T000G5_A101WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         T000G5_A95WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         T000G5_n95WWPMailProcessed = new bool[] {false} ;
         T000G5_A96WWPMailDetail = new string[] {""} ;
         T000G5_n96WWPMailDetail = new bool[] {false} ;
         T000G5_A31WWPNotificationId = new long[1] ;
         T000G5_n31WWPNotificationId = new bool[] {false} ;
         sMode17 = "";
         T000G10_A89WWPMailId = new long[1] ;
         T000G11_A89WWPMailId = new long[1] ;
         T000G4_A89WWPMailId = new long[1] ;
         T000G4_A78WWPMailSubject = new string[] {""} ;
         T000G4_A70WWPMailBody = new string[] {""} ;
         T000G4_A79WWPMailTo = new string[] {""} ;
         T000G4_n79WWPMailTo = new bool[] {false} ;
         T000G4_A92WWPMailCC = new string[] {""} ;
         T000G4_n92WWPMailCC = new bool[] {false} ;
         T000G4_A93WWPMailBCC = new string[] {""} ;
         T000G4_n93WWPMailBCC = new bool[] {false} ;
         T000G4_A80WWPMailSenderAddress = new string[] {""} ;
         T000G4_A81WWPMailSenderName = new string[] {""} ;
         T000G4_A90WWPMailStatus = new short[1] ;
         T000G4_A100WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         T000G4_A101WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         T000G4_A95WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         T000G4_n95WWPMailProcessed = new bool[] {false} ;
         T000G4_A96WWPMailDetail = new string[] {""} ;
         T000G4_n96WWPMailDetail = new bool[] {false} ;
         T000G4_A31WWPNotificationId = new long[1] ;
         T000G4_n31WWPNotificationId = new bool[] {false} ;
         T000G12_A89WWPMailId = new long[1] ;
         T000G15_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000G16_A89WWPMailId = new long[1] ;
         Z94WWPMailAttachmentFile = "";
         T000G17_A89WWPMailId = new long[1] ;
         T000G17_A102WWPMailAttachmentName = new string[] {""} ;
         T000G17_A94WWPMailAttachmentFile = new string[] {""} ;
         T000G18_A89WWPMailId = new long[1] ;
         T000G18_A102WWPMailAttachmentName = new string[] {""} ;
         T000G3_A89WWPMailId = new long[1] ;
         T000G3_A102WWPMailAttachmentName = new string[] {""} ;
         T000G3_A94WWPMailAttachmentFile = new string[] {""} ;
         T000G2_A89WWPMailId = new long[1] ;
         T000G2_A102WWPMailAttachmentName = new string[] {""} ;
         T000G2_A94WWPMailAttachmentFile = new string[] {""} ;
         T000G22_A89WWPMailId = new long[1] ;
         T000G22_A102WWPMailAttachmentName = new string[] {""} ;
         Gridwwp_mail_attachmentsRow = new GXWebRow();
         subGridwwp_mail_attachments_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i100WWPMailCreated = (DateTime)(DateTime.MinValue);
         i101WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Gridwwp_mail_attachmentsColumn = new GXWebColumn();
         ZZ78WWPMailSubject = "";
         ZZ70WWPMailBody = "";
         ZZ79WWPMailTo = "";
         ZZ92WWPMailCC = "";
         ZZ93WWPMailBCC = "";
         ZZ80WWPMailSenderAddress = "";
         ZZ81WWPMailSenderName = "";
         ZZ100WWPMailCreated = (DateTime)(DateTime.MinValue);
         ZZ101WWPMailScheduled = (DateTime)(DateTime.MinValue);
         ZZ95WWPMailProcessed = (DateTime)(DateTime.MinValue);
         ZZ96WWPMailDetail = "";
         ZZ33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail__default(),
            new Object[][] {
                new Object[] {
               T000G2_A89WWPMailId, T000G2_A102WWPMailAttachmentName, T000G2_A94WWPMailAttachmentFile
               }
               , new Object[] {
               T000G3_A89WWPMailId, T000G3_A102WWPMailAttachmentName, T000G3_A94WWPMailAttachmentFile
               }
               , new Object[] {
               T000G4_A89WWPMailId, T000G4_A78WWPMailSubject, T000G4_A70WWPMailBody, T000G4_A79WWPMailTo, T000G4_n79WWPMailTo, T000G4_A92WWPMailCC, T000G4_n92WWPMailCC, T000G4_A93WWPMailBCC, T000G4_n93WWPMailBCC, T000G4_A80WWPMailSenderAddress,
               T000G4_A81WWPMailSenderName, T000G4_A90WWPMailStatus, T000G4_A100WWPMailCreated, T000G4_A101WWPMailScheduled, T000G4_A95WWPMailProcessed, T000G4_n95WWPMailProcessed, T000G4_A96WWPMailDetail, T000G4_n96WWPMailDetail, T000G4_A31WWPNotificationId, T000G4_n31WWPNotificationId
               }
               , new Object[] {
               T000G5_A89WWPMailId, T000G5_A78WWPMailSubject, T000G5_A70WWPMailBody, T000G5_A79WWPMailTo, T000G5_n79WWPMailTo, T000G5_A92WWPMailCC, T000G5_n92WWPMailCC, T000G5_A93WWPMailBCC, T000G5_n93WWPMailBCC, T000G5_A80WWPMailSenderAddress,
               T000G5_A81WWPMailSenderName, T000G5_A90WWPMailStatus, T000G5_A100WWPMailCreated, T000G5_A101WWPMailScheduled, T000G5_A95WWPMailProcessed, T000G5_n95WWPMailProcessed, T000G5_A96WWPMailDetail, T000G5_n96WWPMailDetail, T000G5_A31WWPNotificationId, T000G5_n31WWPNotificationId
               }
               , new Object[] {
               T000G6_A33WWPNotificationCreated
               }
               , new Object[] {
               T000G7_A89WWPMailId, T000G7_A78WWPMailSubject, T000G7_A70WWPMailBody, T000G7_A79WWPMailTo, T000G7_n79WWPMailTo, T000G7_A92WWPMailCC, T000G7_n92WWPMailCC, T000G7_A93WWPMailBCC, T000G7_n93WWPMailBCC, T000G7_A80WWPMailSenderAddress,
               T000G7_A81WWPMailSenderName, T000G7_A90WWPMailStatus, T000G7_A100WWPMailCreated, T000G7_A101WWPMailScheduled, T000G7_A95WWPMailProcessed, T000G7_n95WWPMailProcessed, T000G7_A96WWPMailDetail, T000G7_n96WWPMailDetail, T000G7_A33WWPNotificationCreated, T000G7_A31WWPNotificationId,
               T000G7_n31WWPNotificationId
               }
               , new Object[] {
               T000G8_A33WWPNotificationCreated
               }
               , new Object[] {
               T000G9_A89WWPMailId
               }
               , new Object[] {
               T000G10_A89WWPMailId
               }
               , new Object[] {
               T000G11_A89WWPMailId
               }
               , new Object[] {
               T000G12_A89WWPMailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000G15_A33WWPNotificationCreated
               }
               , new Object[] {
               T000G16_A89WWPMailId
               }
               , new Object[] {
               T000G17_A89WWPMailId, T000G17_A102WWPMailAttachmentName, T000G17_A94WWPMailAttachmentFile
               }
               , new Object[] {
               T000G18_A89WWPMailId, T000G18_A102WWPMailAttachmentName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000G22_A89WWPMailId, T000G22_A102WWPMailAttachmentName
               }
            }
         );
         Z101WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A101WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i101WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z100WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A100WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i100WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z90WWPMailStatus = 1;
         A90WWPMailStatus = 1;
         i90WWPMailStatus = 1;
      }

      private short Z90WWPMailStatus ;
      private short nRcdDeleted_18 ;
      private short nRcdExists_18 ;
      private short nIsMod_18 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A90WWPMailStatus ;
      private short nBlankRcdCount18 ;
      private short RcdFound18 ;
      private short nBlankRcdUsr18 ;
      private short Gx_BScreen ;
      private short RcdFound17 ;
      private short nIsDirty_18 ;
      private short subGridwwp_mail_attachments_Backcolorstyle ;
      private short subGridwwp_mail_attachments_Backstyle ;
      private short gxajaxcallmode ;
      private short i90WWPMailStatus ;
      private short subGridwwp_mail_attachments_Allowselection ;
      private short subGridwwp_mail_attachments_Allowhovering ;
      private short subGridwwp_mail_attachments_Allowcollapsing ;
      private short subGridwwp_mail_attachments_Collapsed ;
      private short ZZ90WWPMailStatus ;
      private int nRC_GXsfl_113 ;
      private int nGXsfl_113_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPMailId_Enabled ;
      private int edtWWPMailSubject_Enabled ;
      private int edtWWPMailBody_Enabled ;
      private int edtWWPMailTo_Enabled ;
      private int edtWWPMailCC_Enabled ;
      private int edtWWPMailBCC_Enabled ;
      private int edtWWPMailSenderAddress_Enabled ;
      private int edtWWPMailSenderName_Enabled ;
      private int edtWWPMailCreated_Enabled ;
      private int edtWWPMailScheduled_Enabled ;
      private int edtWWPMailProcessed_Enabled ;
      private int edtWWPMailDetail_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int imgprompt_31_Visible ;
      private int edtWWPNotificationCreated_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtWWPMailAttachmentName_Enabled ;
      private int edtWWPMailAttachmentFile_Enabled ;
      private int fRowAdded ;
      private int subGridwwp_mail_attachments_Backcolor ;
      private int subGridwwp_mail_attachments_Allbackcolor ;
      private int defedtWWPMailAttachmentName_Enabled ;
      private int idxLst ;
      private int subGridwwp_mail_attachments_Selectedindex ;
      private int subGridwwp_mail_attachments_Selectioncolor ;
      private int subGridwwp_mail_attachments_Hoveringcolor ;
      private long Z89WWPMailId ;
      private long Z31WWPNotificationId ;
      private long A31WWPNotificationId ;
      private long A89WWPMailId ;
      private long GRIDWWP_MAIL_ATTACHMENTS_nFirstRecordOnPage ;
      private long ZZ89WWPMailId ;
      private long ZZ31WWPNotificationId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPMailId_Internalname ;
      private string sGXsfl_113_idx="0001" ;
      private string Gx_mode ;
      private string cmbWWPMailStatus_Internalname ;
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
      private string edtWWPMailId_Jsonclick ;
      private string edtWWPMailSubject_Internalname ;
      private string edtWWPMailSubject_Jsonclick ;
      private string edtWWPMailBody_Internalname ;
      private string edtWWPMailTo_Internalname ;
      private string edtWWPMailCC_Internalname ;
      private string edtWWPMailBCC_Internalname ;
      private string edtWWPMailSenderAddress_Internalname ;
      private string edtWWPMailSenderName_Internalname ;
      private string cmbWWPMailStatus_Jsonclick ;
      private string edtWWPMailCreated_Internalname ;
      private string edtWWPMailCreated_Jsonclick ;
      private string edtWWPMailScheduled_Internalname ;
      private string edtWWPMailScheduled_Jsonclick ;
      private string edtWWPMailProcessed_Internalname ;
      private string edtWWPMailProcessed_Jsonclick ;
      private string edtWWPMailDetail_Internalname ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string imgprompt_31_gximage ;
      private string sImgUrl ;
      private string imgprompt_31_Internalname ;
      private string imgprompt_31_Link ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string divAttachmentstable_Internalname ;
      private string lblTitleattachments_Internalname ;
      private string lblTitleattachments_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode18 ;
      private string edtWWPMailAttachmentName_Internalname ;
      private string edtWWPMailAttachmentFile_Internalname ;
      private string sStyleString ;
      private string subGridwwp_mail_attachments_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode17 ;
      private string sGXsfl_113_fel_idx="0001" ;
      private string subGridwwp_mail_attachments_Class ;
      private string subGridwwp_mail_attachments_Linesclass ;
      private string ROClassString ;
      private string edtWWPMailAttachmentName_Jsonclick ;
      private string edtWWPMailAttachmentFile_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridwwp_mail_attachments_Header ;
      private DateTime Z100WWPMailCreated ;
      private DateTime Z101WWPMailScheduled ;
      private DateTime Z95WWPMailProcessed ;
      private DateTime A100WWPMailCreated ;
      private DateTime A101WWPMailScheduled ;
      private DateTime A95WWPMailProcessed ;
      private DateTime A33WWPNotificationCreated ;
      private DateTime Z33WWPNotificationCreated ;
      private DateTime i100WWPMailCreated ;
      private DateTime i101WWPMailScheduled ;
      private DateTime ZZ100WWPMailCreated ;
      private DateTime ZZ101WWPMailScheduled ;
      private DateTime ZZ95WWPMailProcessed ;
      private DateTime ZZ33WWPNotificationCreated ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n31WWPNotificationId ;
      private bool wbErr ;
      private bool bGXsfl_113_Refreshing=false ;
      private bool n95WWPMailProcessed ;
      private bool n79WWPMailTo ;
      private bool n92WWPMailCC ;
      private bool n93WWPMailBCC ;
      private bool n96WWPMailDetail ;
      private bool Gx_longc ;
      private string A70WWPMailBody ;
      private string A79WWPMailTo ;
      private string A92WWPMailCC ;
      private string A93WWPMailBCC ;
      private string A80WWPMailSenderAddress ;
      private string A81WWPMailSenderName ;
      private string A96WWPMailDetail ;
      private string A94WWPMailAttachmentFile ;
      private string Z70WWPMailBody ;
      private string Z79WWPMailTo ;
      private string Z92WWPMailCC ;
      private string Z93WWPMailBCC ;
      private string Z80WWPMailSenderAddress ;
      private string Z81WWPMailSenderName ;
      private string Z96WWPMailDetail ;
      private string Z94WWPMailAttachmentFile ;
      private string ZZ70WWPMailBody ;
      private string ZZ79WWPMailTo ;
      private string ZZ92WWPMailCC ;
      private string ZZ93WWPMailBCC ;
      private string ZZ80WWPMailSenderAddress ;
      private string ZZ81WWPMailSenderName ;
      private string ZZ96WWPMailDetail ;
      private string Z78WWPMailSubject ;
      private string Z102WWPMailAttachmentName ;
      private string A78WWPMailSubject ;
      private string A102WWPMailAttachmentName ;
      private string ZZ78WWPMailSubject ;
      private GXWebGrid Gridwwp_mail_attachmentsContainer ;
      private GXWebRow Gridwwp_mail_attachmentsRow ;
      private GXWebColumn Gridwwp_mail_attachmentsColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPMailStatus ;
      private IDataStoreProvider pr_default ;
      private long[] T000G7_A89WWPMailId ;
      private string[] T000G7_A78WWPMailSubject ;
      private string[] T000G7_A70WWPMailBody ;
      private string[] T000G7_A79WWPMailTo ;
      private bool[] T000G7_n79WWPMailTo ;
      private string[] T000G7_A92WWPMailCC ;
      private bool[] T000G7_n92WWPMailCC ;
      private string[] T000G7_A93WWPMailBCC ;
      private bool[] T000G7_n93WWPMailBCC ;
      private string[] T000G7_A80WWPMailSenderAddress ;
      private string[] T000G7_A81WWPMailSenderName ;
      private short[] T000G7_A90WWPMailStatus ;
      private DateTime[] T000G7_A100WWPMailCreated ;
      private DateTime[] T000G7_A101WWPMailScheduled ;
      private DateTime[] T000G7_A95WWPMailProcessed ;
      private bool[] T000G7_n95WWPMailProcessed ;
      private string[] T000G7_A96WWPMailDetail ;
      private bool[] T000G7_n96WWPMailDetail ;
      private DateTime[] T000G7_A33WWPNotificationCreated ;
      private long[] T000G7_A31WWPNotificationId ;
      private bool[] T000G7_n31WWPNotificationId ;
      private DateTime[] T000G6_A33WWPNotificationCreated ;
      private DateTime[] T000G8_A33WWPNotificationCreated ;
      private long[] T000G9_A89WWPMailId ;
      private long[] T000G5_A89WWPMailId ;
      private string[] T000G5_A78WWPMailSubject ;
      private string[] T000G5_A70WWPMailBody ;
      private string[] T000G5_A79WWPMailTo ;
      private bool[] T000G5_n79WWPMailTo ;
      private string[] T000G5_A92WWPMailCC ;
      private bool[] T000G5_n92WWPMailCC ;
      private string[] T000G5_A93WWPMailBCC ;
      private bool[] T000G5_n93WWPMailBCC ;
      private string[] T000G5_A80WWPMailSenderAddress ;
      private string[] T000G5_A81WWPMailSenderName ;
      private short[] T000G5_A90WWPMailStatus ;
      private DateTime[] T000G5_A100WWPMailCreated ;
      private DateTime[] T000G5_A101WWPMailScheduled ;
      private DateTime[] T000G5_A95WWPMailProcessed ;
      private bool[] T000G5_n95WWPMailProcessed ;
      private string[] T000G5_A96WWPMailDetail ;
      private bool[] T000G5_n96WWPMailDetail ;
      private long[] T000G5_A31WWPNotificationId ;
      private bool[] T000G5_n31WWPNotificationId ;
      private long[] T000G10_A89WWPMailId ;
      private long[] T000G11_A89WWPMailId ;
      private long[] T000G4_A89WWPMailId ;
      private string[] T000G4_A78WWPMailSubject ;
      private string[] T000G4_A70WWPMailBody ;
      private string[] T000G4_A79WWPMailTo ;
      private bool[] T000G4_n79WWPMailTo ;
      private string[] T000G4_A92WWPMailCC ;
      private bool[] T000G4_n92WWPMailCC ;
      private string[] T000G4_A93WWPMailBCC ;
      private bool[] T000G4_n93WWPMailBCC ;
      private string[] T000G4_A80WWPMailSenderAddress ;
      private string[] T000G4_A81WWPMailSenderName ;
      private short[] T000G4_A90WWPMailStatus ;
      private DateTime[] T000G4_A100WWPMailCreated ;
      private DateTime[] T000G4_A101WWPMailScheduled ;
      private DateTime[] T000G4_A95WWPMailProcessed ;
      private bool[] T000G4_n95WWPMailProcessed ;
      private string[] T000G4_A96WWPMailDetail ;
      private bool[] T000G4_n96WWPMailDetail ;
      private long[] T000G4_A31WWPNotificationId ;
      private bool[] T000G4_n31WWPNotificationId ;
      private long[] T000G12_A89WWPMailId ;
      private DateTime[] T000G15_A33WWPNotificationCreated ;
      private long[] T000G16_A89WWPMailId ;
      private long[] T000G17_A89WWPMailId ;
      private string[] T000G17_A102WWPMailAttachmentName ;
      private string[] T000G17_A94WWPMailAttachmentFile ;
      private long[] T000G18_A89WWPMailId ;
      private string[] T000G18_A102WWPMailAttachmentName ;
      private long[] T000G3_A89WWPMailId ;
      private string[] T000G3_A102WWPMailAttachmentName ;
      private string[] T000G3_A94WWPMailAttachmentFile ;
      private long[] T000G2_A89WWPMailId ;
      private string[] T000G2_A102WWPMailAttachmentName ;
      private string[] T000G2_A94WWPMailAttachmentFile ;
      private long[] T000G22_A89WWPMailId ;
      private string[] T000G22_A102WWPMailAttachmentName ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_mail__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mail__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new ForEachCursor(def[20])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000G2;
        prmT000G2 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0) ,
        new ParDef("@WWPMailAttachmentName",GXType.NVarChar,40,0)
        };
        Object[] prmT000G3;
        prmT000G3 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0) ,
        new ParDef("@WWPMailAttachmentName",GXType.NVarChar,40,0)
        };
        Object[] prmT000G4;
        prmT000G4 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        Object[] prmT000G5;
        prmT000G5 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        Object[] prmT000G6;
        prmT000G6 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000G7;
        prmT000G7 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        Object[] prmT000G8;
        prmT000G8 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000G9;
        prmT000G9 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        Object[] prmT000G10;
        prmT000G10 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        Object[] prmT000G11;
        prmT000G11 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        Object[] prmT000G12;
        prmT000G12 = new Object[] {
        new ParDef("@WWPMailSubject",GXType.NVarChar,80,0) ,
        new ParDef("@WWPMailBody",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailTo",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPMailCC",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPMailBCC",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPMailSenderAddress",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailSenderName",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailStatus",GXType.Int16,4,0) ,
        new ParDef("@WWPMailCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPMailScheduled",GXType.DateTime2,10,12) ,
        new ParDef("@WWPMailProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("@WWPMailDetail",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000G13;
        prmT000G13 = new Object[] {
        new ParDef("@WWPMailSubject",GXType.NVarChar,80,0) ,
        new ParDef("@WWPMailBody",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailTo",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPMailCC",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPMailBCC",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPMailSenderAddress",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailSenderName",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailStatus",GXType.Int16,4,0) ,
        new ParDef("@WWPMailCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPMailScheduled",GXType.DateTime2,10,12) ,
        new ParDef("@WWPMailProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("@WWPMailDetail",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        Object[] prmT000G14;
        prmT000G14 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        Object[] prmT000G15;
        prmT000G15 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000G16;
        prmT000G16 = new Object[] {
        };
        Object[] prmT000G17;
        prmT000G17 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0) ,
        new ParDef("@WWPMailAttachmentName",GXType.NVarChar,40,0)
        };
        Object[] prmT000G18;
        prmT000G18 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0) ,
        new ParDef("@WWPMailAttachmentName",GXType.NVarChar,40,0)
        };
        Object[] prmT000G19;
        prmT000G19 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0) ,
        new ParDef("@WWPMailAttachmentName",GXType.NVarChar,40,0) ,
        new ParDef("@WWPMailAttachmentFile",GXType.NVarChar,2097152,0)
        };
        Object[] prmT000G20;
        prmT000G20 = new Object[] {
        new ParDef("@WWPMailAttachmentFile",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailId",GXType.Decimal,10,0) ,
        new ParDef("@WWPMailAttachmentName",GXType.NVarChar,40,0)
        };
        Object[] prmT000G21;
        prmT000G21 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0) ,
        new ParDef("@WWPMailAttachmentName",GXType.NVarChar,40,0)
        };
        Object[] prmT000G22;
        prmT000G22 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000G2", "SELECT [WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile] FROM [WWP_MailAttachments] WITH (UPDLOCK) WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G3", "SELECT [WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G4", "SELECT [WWPMailId], [WWPMailSubject], [WWPMailBody], [WWPMailTo], [WWPMailCC], [WWPMailBCC], [WWPMailSenderAddress], [WWPMailSenderName], [WWPMailStatus], [WWPMailCreated], [WWPMailScheduled], [WWPMailProcessed], [WWPMailDetail], [WWPNotificationId] FROM [WWP_Mail] WITH (UPDLOCK) WHERE [WWPMailId] = @WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G5", "SELECT [WWPMailId], [WWPMailSubject], [WWPMailBody], [WWPMailTo], [WWPMailCC], [WWPMailBCC], [WWPMailSenderAddress], [WWPMailSenderName], [WWPMailStatus], [WWPMailCreated], [WWPMailScheduled], [WWPMailProcessed], [WWPMailDetail], [WWPNotificationId] FROM [WWP_Mail] WHERE [WWPMailId] = @WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G6", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G7", "SELECT TM1.[WWPMailId], TM1.[WWPMailSubject], TM1.[WWPMailBody], TM1.[WWPMailTo], TM1.[WWPMailCC], TM1.[WWPMailBCC], TM1.[WWPMailSenderAddress], TM1.[WWPMailSenderName], TM1.[WWPMailStatus], TM1.[WWPMailCreated], TM1.[WWPMailScheduled], TM1.[WWPMailProcessed], TM1.[WWPMailDetail], T2.[WWPNotificationCreated], TM1.[WWPNotificationId] FROM ([WWP_Mail] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) WHERE TM1.[WWPMailId] = @WWPMailId ORDER BY TM1.[WWPMailId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G8", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G9", "SELECT [WWPMailId] FROM [WWP_Mail] WHERE [WWPMailId] = @WWPMailId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G10", "SELECT TOP 1 [WWPMailId] FROM [WWP_Mail] WHERE ( [WWPMailId] > @WWPMailId) ORDER BY [WWPMailId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G11", "SELECT TOP 1 [WWPMailId] FROM [WWP_Mail] WHERE ( [WWPMailId] < @WWPMailId) ORDER BY [WWPMailId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G12", "INSERT INTO [WWP_Mail]([WWPMailSubject], [WWPMailBody], [WWPMailTo], [WWPMailCC], [WWPMailBCC], [WWPMailSenderAddress], [WWPMailSenderName], [WWPMailStatus], [WWPMailCreated], [WWPMailScheduled], [WWPMailProcessed], [WWPMailDetail], [WWPNotificationId]) VALUES(@WWPMailSubject, @WWPMailBody, @WWPMailTo, @WWPMailCC, @WWPMailBCC, @WWPMailSenderAddress, @WWPMailSenderName, @WWPMailStatus, @WWPMailCreated, @WWPMailScheduled, @WWPMailProcessed, @WWPMailDetail, @WWPNotificationId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000G12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G13", "UPDATE [WWP_Mail] SET [WWPMailSubject]=@WWPMailSubject, [WWPMailBody]=@WWPMailBody, [WWPMailTo]=@WWPMailTo, [WWPMailCC]=@WWPMailCC, [WWPMailBCC]=@WWPMailBCC, [WWPMailSenderAddress]=@WWPMailSenderAddress, [WWPMailSenderName]=@WWPMailSenderName, [WWPMailStatus]=@WWPMailStatus, [WWPMailCreated]=@WWPMailCreated, [WWPMailScheduled]=@WWPMailScheduled, [WWPMailProcessed]=@WWPMailProcessed, [WWPMailDetail]=@WWPMailDetail, [WWPNotificationId]=@WWPNotificationId  WHERE [WWPMailId] = @WWPMailId", GxErrorMask.GX_NOMASK,prmT000G13)
           ,new CursorDef("T000G14", "DELETE FROM [WWP_Mail]  WHERE [WWPMailId] = @WWPMailId", GxErrorMask.GX_NOMASK,prmT000G14)
           ,new CursorDef("T000G15", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G16", "SELECT [WWPMailId] FROM [WWP_Mail] ORDER BY [WWPMailId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G17", "SELECT [WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId and [WWPMailAttachmentName] = @WWPMailAttachmentName ORDER BY [WWPMailId], [WWPMailAttachmentName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G17,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G18", "SELECT [WWPMailId], [WWPMailAttachmentName] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G19", "INSERT INTO [WWP_MailAttachments]([WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile]) VALUES(@WWPMailId, @WWPMailAttachmentName, @WWPMailAttachmentFile)", GxErrorMask.GX_NOMASK,prmT000G19)
           ,new CursorDef("T000G20", "UPDATE [WWP_MailAttachments] SET [WWPMailAttachmentFile]=@WWPMailAttachmentFile  WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName", GxErrorMask.GX_NOMASK,prmT000G20)
           ,new CursorDef("T000G21", "DELETE FROM [WWP_MailAttachments]  WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName", GxErrorMask.GX_NOMASK,prmT000G21)
           ,new CursorDef("T000G22", "SELECT [WWPMailId], [WWPMailAttachmentName] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId ORDER BY [WWPMailId], [WWPMailAttachmentName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G22,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((long[]) buf[18])[0] = rslt.getLong(14);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((long[]) buf[18])[0] = rslt.getLong(14);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              return;
           case 4 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14, true);
              ((long[]) buf[19])[0] = rslt.getLong(15);
              ((bool[]) buf[20])[0] = rslt.wasNull(15);
              return;
           case 6 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
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
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
     }
  }

}

}
