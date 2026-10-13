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
   public class wwp_notificationdefinition : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel3"+"_"+"WWPNOTIFICATIONDEFINITIONISAUT") == 0 )
         {
            A76WWPNotificationDefinitionSecFu = GetPar( "WWPNotificationDefinitionSecFu");
            AssignAttri("", false, "A76WWPNotificationDefinitionSecFu", A76WWPNotificationDefinitionSecFu);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX3ASAWWPNOTIFICATIONDEFINITIONISAUT0D14( A76WWPNotificationDefinitionSecFu) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Notification Definition", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_notificationdefinition( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notificationdefinition( IGxContext context )
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
         cmbWWPNotificationDefinitionAppli = new GXCombobox();
         chkWWPNotificationDefinitionAllow = new GXCheckbox();
         chkWWPNotificationDefinitionIsAut = new GXCheckbox();
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
         if ( cmbWWPNotificationDefinitionAppli.ItemCount > 0 )
         {
            A39WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( cmbWWPNotificationDefinitionAppli.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A39WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0));
            AssignProp("", false, cmbWWPNotificationDefinitionAppli_Internalname, "Values", cmbWWPNotificationDefinitionAppli.ToJavascriptSource(), true);
         }
         A40WWPNotificationDefinitionAllow = StringUtil.StrToBool( StringUtil.BoolToStr( A40WWPNotificationDefinitionAllow));
         AssignAttri("", false, "A40WWPNotificationDefinitionAllow", A40WWPNotificationDefinitionAllow);
         A77WWPNotificationDefinitionIsAut = StringUtil.StrToBool( StringUtil.BoolToStr( A77WWPNotificationDefinitionIsAut));
         AssignAttri("", false, "A77WWPNotificationDefinitionIsAut", A77WWPNotificationDefinitionIsAut);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Notification Definition", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"wwpbaseobjects.notifications.common.gx00e0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPNOTIFICATIONDEFINITIONID"+"'), id:'"+"WWPNOTIFICATIONDEFINITIONID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A32WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPNotificationDefinitionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A32WWPNotificationDefinitionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A32WWPNotificationDefinitionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionName_Internalname, context.GetMessage( "Internal Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionName_Internalname, A68WWPNotificationDefinitionName, StringUtil.RTrim( context.localUtil.Format( A68WWPNotificationDefinitionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPNotificationDefinitionAppli_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPNotificationDefinitionAppli_Internalname, context.GetMessage( "Applies To", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPNotificationDefinitionAppli, cmbWWPNotificationDefinitionAppli_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0)), 1, cmbWWPNotificationDefinitionAppli_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPNotificationDefinitionAppli.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0));
         AssignProp("", false, cmbWWPNotificationDefinitionAppli_Internalname, "Values", (string)(cmbWWPNotificationDefinitionAppli.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPNotificationDefinitionAllow_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPNotificationDefinitionAllow_Internalname, context.GetMessage( "Allow User Subscription", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPNotificationDefinitionAllow_Internalname, StringUtil.BoolToStr( A40WWPNotificationDefinitionAllow), "", context.GetMessage( "Allow User Subscription", ""), 1, chkWWPNotificationDefinitionAllow.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(49, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,49);\"");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionDescr_Internalname, context.GetMessage( "Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionDescr_Internalname, A38WWPNotificationDefinitionDescr, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtWWPNotificationDefinitionDescr_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionIcon_Internalname, context.GetMessage( "Default Icon", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionIcon_Internalname, A71WWPNotificationDefinitionIcon, StringUtil.RTrim( context.localUtil.Format( A71WWPNotificationDefinitionIcon, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionIcon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionIcon_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionTitle_Internalname, context.GetMessage( "Default Title", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionTitle_Internalname, A72WWPNotificationDefinitionTitle, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtWWPNotificationDefinitionTitle_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionShort_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionShort_Internalname, context.GetMessage( "Default Short Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionShort_Internalname, A73WWPNotificationDefinitionShort, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtWWPNotificationDefinitionShort_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionLongD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionLongD_Internalname, context.GetMessage( "Default Long Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionLongD_Internalname, A74WWPNotificationDefinitionLongD, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, 1, edtWWPNotificationDefinitionLongD_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionLink_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionLink_Internalname, context.GetMessage( "Default Link", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionLink_Internalname, A75WWPNotificationDefinitionLink, StringUtil.RTrim( context.localUtil.Format( A75WWPNotificationDefinitionLink, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", A75WWPNotificationDefinitionLink, "_blank", "", "", edtWWPNotificationDefinitionLink_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionLink_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29WWPEntityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPEntityId_Enabled!=0) ? context.localUtil.Format( (decimal)(A29WWPEntityId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A29WWPEntityId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_29_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_29_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_29_Internalname, sImgUrl, imgprompt_29_Link, "", "", context.GetTheme( ), imgprompt_29_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityName_Internalname, A30WWPEntityName, StringUtil.RTrim( context.localUtil.Format( A30WWPEntityName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionSecFu_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionSecFu_Internalname, context.GetMessage( "Funcionality Key", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionSecFu_Internalname, A76WWPNotificationDefinitionSecFu, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", 0, 1, edtWWPNotificationDefinitionSecFu_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPNotificationDefinitionIsAut_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPNotificationDefinitionIsAut_Internalname, context.GetMessage( "User Authorized", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPNotificationDefinitionIsAut_Internalname, StringUtil.BoolToStr( A77WWPNotificationDefinitionIsAut), "", context.GetMessage( "User Authorized", ""), 1, chkWWPNotificationDefinitionIsAut.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(99, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,99);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
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
            Z32WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z32WWPNotificationDefinitionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z68WWPNotificationDefinitionName = cgiGet( "Z68WWPNotificationDefinitionName");
            Z39WWPNotificationDefinitionAppli = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z39WWPNotificationDefinitionAppli"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z40WWPNotificationDefinitionAllow = StringUtil.StrToBool( cgiGet( "Z40WWPNotificationDefinitionAllow"));
            Z38WWPNotificationDefinitionDescr = cgiGet( "Z38WWPNotificationDefinitionDescr");
            Z71WWPNotificationDefinitionIcon = cgiGet( "Z71WWPNotificationDefinitionIcon");
            Z72WWPNotificationDefinitionTitle = cgiGet( "Z72WWPNotificationDefinitionTitle");
            Z73WWPNotificationDefinitionShort = cgiGet( "Z73WWPNotificationDefinitionShort");
            Z74WWPNotificationDefinitionLongD = cgiGet( "Z74WWPNotificationDefinitionLongD");
            Z75WWPNotificationDefinitionLink = cgiGet( "Z75WWPNotificationDefinitionLink");
            Z76WWPNotificationDefinitionSecFu = cgiGet( "Z76WWPNotificationDefinitionSecFu");
            Z29WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z29WWPEntityId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
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
            cmbWWPNotificationDefinitionAppli.CurrentValue = cgiGet( cmbWWPNotificationDefinitionAppli_Internalname);
            A39WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPNotificationDefinitionAppli_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A39WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0));
            A40WWPNotificationDefinitionAllow = StringUtil.StrToBool( cgiGet( chkWWPNotificationDefinitionAllow_Internalname));
            AssignAttri("", false, "A40WWPNotificationDefinitionAllow", A40WWPNotificationDefinitionAllow);
            A38WWPNotificationDefinitionDescr = cgiGet( edtWWPNotificationDefinitionDescr_Internalname);
            AssignAttri("", false, "A38WWPNotificationDefinitionDescr", A38WWPNotificationDefinitionDescr);
            A71WWPNotificationDefinitionIcon = cgiGet( edtWWPNotificationDefinitionIcon_Internalname);
            AssignAttri("", false, "A71WWPNotificationDefinitionIcon", A71WWPNotificationDefinitionIcon);
            A72WWPNotificationDefinitionTitle = cgiGet( edtWWPNotificationDefinitionTitle_Internalname);
            AssignAttri("", false, "A72WWPNotificationDefinitionTitle", A72WWPNotificationDefinitionTitle);
            A73WWPNotificationDefinitionShort = cgiGet( edtWWPNotificationDefinitionShort_Internalname);
            AssignAttri("", false, "A73WWPNotificationDefinitionShort", A73WWPNotificationDefinitionShort);
            A74WWPNotificationDefinitionLongD = cgiGet( edtWWPNotificationDefinitionLongD_Internalname);
            AssignAttri("", false, "A74WWPNotificationDefinitionLongD", A74WWPNotificationDefinitionLongD);
            A75WWPNotificationDefinitionLink = cgiGet( edtWWPNotificationDefinitionLink_Internalname);
            AssignAttri("", false, "A75WWPNotificationDefinitionLink", A75WWPNotificationDefinitionLink);
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
            A76WWPNotificationDefinitionSecFu = cgiGet( edtWWPNotificationDefinitionSecFu_Internalname);
            AssignAttri("", false, "A76WWPNotificationDefinitionSecFu", A76WWPNotificationDefinitionSecFu);
            A77WWPNotificationDefinitionIsAut = StringUtil.StrToBool( cgiGet( chkWWPNotificationDefinitionIsAut_Internalname));
            AssignAttri("", false, "A77WWPNotificationDefinitionIsAut", A77WWPNotificationDefinitionIsAut);
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
               A32WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
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
               InitAll0D14( ) ;
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
         DisableAttributes0D14( ) ;
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

      protected void ResetCaption0D0( )
      {
      }

      protected void ZM0D14( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z68WWPNotificationDefinitionName = T000D3_A68WWPNotificationDefinitionName[0];
               Z39WWPNotificationDefinitionAppli = T000D3_A39WWPNotificationDefinitionAppli[0];
               Z40WWPNotificationDefinitionAllow = T000D3_A40WWPNotificationDefinitionAllow[0];
               Z38WWPNotificationDefinitionDescr = T000D3_A38WWPNotificationDefinitionDescr[0];
               Z71WWPNotificationDefinitionIcon = T000D3_A71WWPNotificationDefinitionIcon[0];
               Z72WWPNotificationDefinitionTitle = T000D3_A72WWPNotificationDefinitionTitle[0];
               Z73WWPNotificationDefinitionShort = T000D3_A73WWPNotificationDefinitionShort[0];
               Z74WWPNotificationDefinitionLongD = T000D3_A74WWPNotificationDefinitionLongD[0];
               Z75WWPNotificationDefinitionLink = T000D3_A75WWPNotificationDefinitionLink[0];
               Z76WWPNotificationDefinitionSecFu = T000D3_A76WWPNotificationDefinitionSecFu[0];
               Z29WWPEntityId = T000D3_A29WWPEntityId[0];
            }
            else
            {
               Z68WWPNotificationDefinitionName = A68WWPNotificationDefinitionName;
               Z39WWPNotificationDefinitionAppli = A39WWPNotificationDefinitionAppli;
               Z40WWPNotificationDefinitionAllow = A40WWPNotificationDefinitionAllow;
               Z38WWPNotificationDefinitionDescr = A38WWPNotificationDefinitionDescr;
               Z71WWPNotificationDefinitionIcon = A71WWPNotificationDefinitionIcon;
               Z72WWPNotificationDefinitionTitle = A72WWPNotificationDefinitionTitle;
               Z73WWPNotificationDefinitionShort = A73WWPNotificationDefinitionShort;
               Z74WWPNotificationDefinitionLongD = A74WWPNotificationDefinitionLongD;
               Z75WWPNotificationDefinitionLink = A75WWPNotificationDefinitionLink;
               Z76WWPNotificationDefinitionSecFu = A76WWPNotificationDefinitionSecFu;
               Z29WWPEntityId = A29WWPEntityId;
            }
         }
         if ( GX_JID == -4 )
         {
            Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
            Z68WWPNotificationDefinitionName = A68WWPNotificationDefinitionName;
            Z39WWPNotificationDefinitionAppli = A39WWPNotificationDefinitionAppli;
            Z40WWPNotificationDefinitionAllow = A40WWPNotificationDefinitionAllow;
            Z38WWPNotificationDefinitionDescr = A38WWPNotificationDefinitionDescr;
            Z71WWPNotificationDefinitionIcon = A71WWPNotificationDefinitionIcon;
            Z72WWPNotificationDefinitionTitle = A72WWPNotificationDefinitionTitle;
            Z73WWPNotificationDefinitionShort = A73WWPNotificationDefinitionShort;
            Z74WWPNotificationDefinitionLongD = A74WWPNotificationDefinitionLongD;
            Z75WWPNotificationDefinitionLink = A75WWPNotificationDefinitionLink;
            Z76WWPNotificationDefinitionSecFu = A76WWPNotificationDefinitionSecFu;
            Z29WWPEntityId = A29WWPEntityId;
            Z30WWPEntityName = A30WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_29_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.gx0090.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WWPENTITYID"+"'), id:'"+"WWPENTITYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load0D14( )
      {
         /* Using cursor T000D5 */
         pr_default.execute(3, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound14 = 1;
            A68WWPNotificationDefinitionName = T000D5_A68WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
            A39WWPNotificationDefinitionAppli = T000D5_A39WWPNotificationDefinitionAppli[0];
            AssignAttri("", false, "A39WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0));
            A40WWPNotificationDefinitionAllow = T000D5_A40WWPNotificationDefinitionAllow[0];
            AssignAttri("", false, "A40WWPNotificationDefinitionAllow", A40WWPNotificationDefinitionAllow);
            A38WWPNotificationDefinitionDescr = T000D5_A38WWPNotificationDefinitionDescr[0];
            AssignAttri("", false, "A38WWPNotificationDefinitionDescr", A38WWPNotificationDefinitionDescr);
            A71WWPNotificationDefinitionIcon = T000D5_A71WWPNotificationDefinitionIcon[0];
            AssignAttri("", false, "A71WWPNotificationDefinitionIcon", A71WWPNotificationDefinitionIcon);
            A72WWPNotificationDefinitionTitle = T000D5_A72WWPNotificationDefinitionTitle[0];
            AssignAttri("", false, "A72WWPNotificationDefinitionTitle", A72WWPNotificationDefinitionTitle);
            A73WWPNotificationDefinitionShort = T000D5_A73WWPNotificationDefinitionShort[0];
            AssignAttri("", false, "A73WWPNotificationDefinitionShort", A73WWPNotificationDefinitionShort);
            A74WWPNotificationDefinitionLongD = T000D5_A74WWPNotificationDefinitionLongD[0];
            AssignAttri("", false, "A74WWPNotificationDefinitionLongD", A74WWPNotificationDefinitionLongD);
            A75WWPNotificationDefinitionLink = T000D5_A75WWPNotificationDefinitionLink[0];
            AssignAttri("", false, "A75WWPNotificationDefinitionLink", A75WWPNotificationDefinitionLink);
            A30WWPEntityName = T000D5_A30WWPEntityName[0];
            AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
            A76WWPNotificationDefinitionSecFu = T000D5_A76WWPNotificationDefinitionSecFu[0];
            AssignAttri("", false, "A76WWPNotificationDefinitionSecFu", A76WWPNotificationDefinitionSecFu);
            A29WWPEntityId = T000D5_A29WWPEntityId[0];
            AssignAttri("", false, "A29WWPEntityId", StringUtil.LTrimStr( (decimal)(A29WWPEntityId), 10, 0));
            ZM0D14( -4) ;
         }
         pr_default.close(3);
         OnLoadActions0D14( ) ;
      }

      protected void OnLoadActions0D14( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A76WWPNotificationDefinitionSecFu)) )
         {
            A77WWPNotificationDefinitionIsAut = true;
            AssignAttri("", false, "A77WWPNotificationDefinitionIsAut", A77WWPNotificationDefinitionIsAut);
         }
         else
         {
            GXt_boolean1 = A77WWPNotificationDefinitionIsAut;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  A76WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A77WWPNotificationDefinitionIsAut = GXt_boolean1;
            AssignAttri("", false, "A77WWPNotificationDefinitionIsAut", A77WWPNotificationDefinitionIsAut);
         }
      }

      protected void CheckExtendedTable0D14( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( ( A39WWPNotificationDefinitionAppli == 1 ) || ( A39WWPNotificationDefinitionAppli == 2 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Notification Definition Applies To", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPNOTIFICATIONDEFINITIONAPPLI");
            AnyError = 1;
            GX_FocusControl = cmbWWPNotificationDefinitionAppli_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A75WWPNotificationDefinitionLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Notification Definition Default Link", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPNOTIFICATIONDEFINITIONLINK");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionLink_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000D4 */
         pr_default.execute(2, new Object[] {A29WWPEntityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A30WWPEntityName = T000D4_A30WWPEntityName[0];
         AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A76WWPNotificationDefinitionSecFu)) )
         {
            A77WWPNotificationDefinitionIsAut = true;
            AssignAttri("", false, "A77WWPNotificationDefinitionIsAut", A77WWPNotificationDefinitionIsAut);
         }
         else
         {
            GXt_boolean1 = A77WWPNotificationDefinitionIsAut;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  A76WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A77WWPNotificationDefinitionIsAut = GXt_boolean1;
            AssignAttri("", false, "A77WWPNotificationDefinitionIsAut", A77WWPNotificationDefinitionIsAut);
         }
      }

      protected void CloseExtendedTableCursors0D14( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( long A29WWPEntityId )
      {
         /* Using cursor T000D6 */
         pr_default.execute(4, new Object[] {A29WWPEntityId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A30WWPEntityName = T000D6_A30WWPEntityName[0];
         AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A30WWPEntityName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0D14( )
      {
         /* Using cursor T000D7 */
         pr_default.execute(5, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000D3 */
         pr_default.execute(1, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D14( 4) ;
            RcdFound14 = 1;
            A32WWPNotificationDefinitionId = T000D3_A32WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
            A68WWPNotificationDefinitionName = T000D3_A68WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
            A39WWPNotificationDefinitionAppli = T000D3_A39WWPNotificationDefinitionAppli[0];
            AssignAttri("", false, "A39WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0));
            A40WWPNotificationDefinitionAllow = T000D3_A40WWPNotificationDefinitionAllow[0];
            AssignAttri("", false, "A40WWPNotificationDefinitionAllow", A40WWPNotificationDefinitionAllow);
            A38WWPNotificationDefinitionDescr = T000D3_A38WWPNotificationDefinitionDescr[0];
            AssignAttri("", false, "A38WWPNotificationDefinitionDescr", A38WWPNotificationDefinitionDescr);
            A71WWPNotificationDefinitionIcon = T000D3_A71WWPNotificationDefinitionIcon[0];
            AssignAttri("", false, "A71WWPNotificationDefinitionIcon", A71WWPNotificationDefinitionIcon);
            A72WWPNotificationDefinitionTitle = T000D3_A72WWPNotificationDefinitionTitle[0];
            AssignAttri("", false, "A72WWPNotificationDefinitionTitle", A72WWPNotificationDefinitionTitle);
            A73WWPNotificationDefinitionShort = T000D3_A73WWPNotificationDefinitionShort[0];
            AssignAttri("", false, "A73WWPNotificationDefinitionShort", A73WWPNotificationDefinitionShort);
            A74WWPNotificationDefinitionLongD = T000D3_A74WWPNotificationDefinitionLongD[0];
            AssignAttri("", false, "A74WWPNotificationDefinitionLongD", A74WWPNotificationDefinitionLongD);
            A75WWPNotificationDefinitionLink = T000D3_A75WWPNotificationDefinitionLink[0];
            AssignAttri("", false, "A75WWPNotificationDefinitionLink", A75WWPNotificationDefinitionLink);
            A76WWPNotificationDefinitionSecFu = T000D3_A76WWPNotificationDefinitionSecFu[0];
            AssignAttri("", false, "A76WWPNotificationDefinitionSecFu", A76WWPNotificationDefinitionSecFu);
            A29WWPEntityId = T000D3_A29WWPEntityId[0];
            AssignAttri("", false, "A29WWPEntityId", StringUtil.LTrimStr( (decimal)(A29WWPEntityId), 10, 0));
            Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0D14( ) ;
            if ( AnyError == 1 )
            {
               RcdFound14 = 0;
               InitializeNonKey0D14( ) ;
            }
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0D14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D14( ) ;
         if ( RcdFound14 == 0 )
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
         RcdFound14 = 0;
         /* Using cursor T000D8 */
         pr_default.execute(6, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000D8_A32WWPNotificationDefinitionId[0] < A32WWPNotificationDefinitionId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000D8_A32WWPNotificationDefinitionId[0] > A32WWPNotificationDefinitionId ) ) )
            {
               A32WWPNotificationDefinitionId = T000D8_A32WWPNotificationDefinitionId[0];
               AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
               RcdFound14 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound14 = 0;
         /* Using cursor T000D9 */
         pr_default.execute(7, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000D9_A32WWPNotificationDefinitionId[0] > A32WWPNotificationDefinitionId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000D9_A32WWPNotificationDefinitionId[0] < A32WWPNotificationDefinitionId ) ) )
            {
               A32WWPNotificationDefinitionId = T000D9_A32WWPNotificationDefinitionId[0];
               AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
               RcdFound14 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0D14( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0D14( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound14 == 1 )
            {
               if ( A32WWPNotificationDefinitionId != Z32WWPNotificationDefinitionId )
               {
                  A32WWPNotificationDefinitionId = Z32WWPNotificationDefinitionId;
                  AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0D14( ) ;
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A32WWPNotificationDefinitionId != Z32WWPNotificationDefinitionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0D14( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPNOTIFICATIONDEFINITIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0D14( ) ;
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
         if ( A32WWPNotificationDefinitionId != Z32WWPNotificationDefinitionId )
         {
            A32WWPNotificationDefinitionId = Z32WWPNotificationDefinitionId;
            AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0D14( ) ;
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0D14( ) ;
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
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
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
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
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
         ScanStart0D14( ) ;
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound14 != 0 )
            {
               ScanNext0D14( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0D14( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0D14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000D2 */
            pr_default.execute(0, new Object[] {A32WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z68WWPNotificationDefinitionName, T000D2_A68WWPNotificationDefinitionName[0]) != 0 ) || ( Z39WWPNotificationDefinitionAppli != T000D2_A39WWPNotificationDefinitionAppli[0] ) || ( Z40WWPNotificationDefinitionAllow != T000D2_A40WWPNotificationDefinitionAllow[0] ) || ( StringUtil.StrCmp(Z38WWPNotificationDefinitionDescr, T000D2_A38WWPNotificationDefinitionDescr[0]) != 0 ) || ( StringUtil.StrCmp(Z71WWPNotificationDefinitionIcon, T000D2_A71WWPNotificationDefinitionIcon[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z72WWPNotificationDefinitionTitle, T000D2_A72WWPNotificationDefinitionTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z73WWPNotificationDefinitionShort, T000D2_A73WWPNotificationDefinitionShort[0]) != 0 ) || ( StringUtil.StrCmp(Z74WWPNotificationDefinitionLongD, T000D2_A74WWPNotificationDefinitionLongD[0]) != 0 ) || ( StringUtil.StrCmp(Z75WWPNotificationDefinitionLink, T000D2_A75WWPNotificationDefinitionLink[0]) != 0 ) || ( StringUtil.StrCmp(Z76WWPNotificationDefinitionSecFu, T000D2_A76WWPNotificationDefinitionSecFu[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z29WWPEntityId != T000D2_A29WWPEntityId[0] ) )
            {
               if ( StringUtil.StrCmp(Z68WWPNotificationDefinitionName, T000D2_A68WWPNotificationDefinitionName[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionName");
                  GXUtil.WriteLogRaw("Old: ",Z68WWPNotificationDefinitionName);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A68WWPNotificationDefinitionName[0]);
               }
               if ( Z39WWPNotificationDefinitionAppli != T000D2_A39WWPNotificationDefinitionAppli[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionAppli");
                  GXUtil.WriteLogRaw("Old: ",Z39WWPNotificationDefinitionAppli);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A39WWPNotificationDefinitionAppli[0]);
               }
               if ( Z40WWPNotificationDefinitionAllow != T000D2_A40WWPNotificationDefinitionAllow[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionAllow");
                  GXUtil.WriteLogRaw("Old: ",Z40WWPNotificationDefinitionAllow);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A40WWPNotificationDefinitionAllow[0]);
               }
               if ( StringUtil.StrCmp(Z38WWPNotificationDefinitionDescr, T000D2_A38WWPNotificationDefinitionDescr[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionDescr");
                  GXUtil.WriteLogRaw("Old: ",Z38WWPNotificationDefinitionDescr);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A38WWPNotificationDefinitionDescr[0]);
               }
               if ( StringUtil.StrCmp(Z71WWPNotificationDefinitionIcon, T000D2_A71WWPNotificationDefinitionIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionIcon");
                  GXUtil.WriteLogRaw("Old: ",Z71WWPNotificationDefinitionIcon);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A71WWPNotificationDefinitionIcon[0]);
               }
               if ( StringUtil.StrCmp(Z72WWPNotificationDefinitionTitle, T000D2_A72WWPNotificationDefinitionTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionTitle");
                  GXUtil.WriteLogRaw("Old: ",Z72WWPNotificationDefinitionTitle);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A72WWPNotificationDefinitionTitle[0]);
               }
               if ( StringUtil.StrCmp(Z73WWPNotificationDefinitionShort, T000D2_A73WWPNotificationDefinitionShort[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionShort");
                  GXUtil.WriteLogRaw("Old: ",Z73WWPNotificationDefinitionShort);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A73WWPNotificationDefinitionShort[0]);
               }
               if ( StringUtil.StrCmp(Z74WWPNotificationDefinitionLongD, T000D2_A74WWPNotificationDefinitionLongD[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionLongD");
                  GXUtil.WriteLogRaw("Old: ",Z74WWPNotificationDefinitionLongD);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A74WWPNotificationDefinitionLongD[0]);
               }
               if ( StringUtil.StrCmp(Z75WWPNotificationDefinitionLink, T000D2_A75WWPNotificationDefinitionLink[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionLink");
                  GXUtil.WriteLogRaw("Old: ",Z75WWPNotificationDefinitionLink);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A75WWPNotificationDefinitionLink[0]);
               }
               if ( StringUtil.StrCmp(Z76WWPNotificationDefinitionSecFu, T000D2_A76WWPNotificationDefinitionSecFu[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionSecFu");
                  GXUtil.WriteLogRaw("Old: ",Z76WWPNotificationDefinitionSecFu);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A76WWPNotificationDefinitionSecFu[0]);
               }
               if ( Z29WWPEntityId != T000D2_A29WWPEntityId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPEntityId");
                  GXUtil.WriteLogRaw("Old: ",Z29WWPEntityId);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A29WWPEntityId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_NotificationDefinition"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D14( )
      {
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D14( 0) ;
            CheckOptimisticConcurrency0D14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D10 */
                     pr_default.execute(8, new Object[] {A68WWPNotificationDefinitionName, A39WWPNotificationDefinitionAppli, A40WWPNotificationDefinitionAllow, A38WWPNotificationDefinitionDescr, A71WWPNotificationDefinitionIcon, A72WWPNotificationDefinitionTitle, A73WWPNotificationDefinitionShort, A74WWPNotificationDefinitionLongD, A75WWPNotificationDefinitionLink, A76WWPNotificationDefinitionSecFu, A29WWPEntityId});
                     A32WWPNotificationDefinitionId = T000D10_A32WWPNotificationDefinitionId[0];
                     AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0D0( ) ;
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
               Load0D14( ) ;
            }
            EndLevel0D14( ) ;
         }
         CloseExtendedTableCursors0D14( ) ;
      }

      protected void Update0D14( )
      {
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D11 */
                     pr_default.execute(9, new Object[] {A68WWPNotificationDefinitionName, A39WWPNotificationDefinitionAppli, A40WWPNotificationDefinitionAllow, A38WWPNotificationDefinitionDescr, A71WWPNotificationDefinitionIcon, A72WWPNotificationDefinitionTitle, A73WWPNotificationDefinitionShort, A74WWPNotificationDefinitionLongD, A75WWPNotificationDefinitionLink, A76WWPNotificationDefinitionSecFu, A29WWPEntityId, A32WWPNotificationDefinitionId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D14( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0D0( ) ;
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
            EndLevel0D14( ) ;
         }
         CloseExtendedTableCursors0D14( ) ;
      }

      protected void DeferredUpdate0D14( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D14( ) ;
            AfterConfirm0D14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000D12 */
                  pr_default.execute(10, new Object[] {A32WWPNotificationDefinitionId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound14 == 0 )
                        {
                           InitAll0D14( ) ;
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
                        ResetCaption0D0( ) ;
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
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0D14( ) ;
         Gx_mode = sMode14;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0D14( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000D13 */
            pr_default.execute(11, new Object[] {A29WWPEntityId});
            A30WWPEntityName = T000D13_A30WWPEntityName[0];
            AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
            pr_default.close(11);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A76WWPNotificationDefinitionSecFu)) )
            {
               A77WWPNotificationDefinitionIsAut = true;
               AssignAttri("", false, "A77WWPNotificationDefinitionIsAut", A77WWPNotificationDefinitionIsAut);
            }
            else
            {
               GXt_boolean1 = A77WWPNotificationDefinitionIsAut;
               new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  A76WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
               A77WWPNotificationDefinitionIsAut = GXt_boolean1;
               AssignAttri("", false, "A77WWPNotificationDefinitionIsAut", A77WWPNotificationDefinitionIsAut);
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000D14 */
            pr_default.execute(12, new Object[] {A32WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Notification", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000D15 */
            pr_default.execute(13, new Object[] {A32WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Subscription", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0D14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_notificationdefinition",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notificationdefinition",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0D14( )
      {
         /* Using cursor T000D16 */
         pr_default.execute(14);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound14 = 1;
            A32WWPNotificationDefinitionId = T000D16_A32WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0D14( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound14 = 1;
            A32WWPNotificationDefinitionId = T000D16_A32WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
         }
      }

      protected void ScanEnd0D14( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0D14( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D14( )
      {
         edtWWPNotificationDefinitionId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionName_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionName_Enabled), 5, 0), true);
         cmbWWPNotificationDefinitionAppli.Enabled = 0;
         AssignProp("", false, cmbWWPNotificationDefinitionAppli_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPNotificationDefinitionAppli.Enabled), 5, 0), true);
         chkWWPNotificationDefinitionAllow.Enabled = 0;
         AssignProp("", false, chkWWPNotificationDefinitionAllow_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPNotificationDefinitionAllow.Enabled), 5, 0), true);
         edtWWPNotificationDefinitionDescr_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionDescr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionDescr_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionIcon_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionIcon_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionTitle_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionTitle_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionShort_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionShort_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionShort_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionLongD_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionLongD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionLongD_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionLink_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionLink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionLink_Enabled), 5, 0), true);
         edtWWPEntityId_Enabled = 0;
         AssignProp("", false, edtWWPEntityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityId_Enabled), 5, 0), true);
         edtWWPEntityName_Enabled = 0;
         AssignProp("", false, edtWWPEntityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityName_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionSecFu_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionSecFu_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionSecFu_Enabled), 5, 0), true);
         chkWWPNotificationDefinitionIsAut.Enabled = 0;
         AssignProp("", false, chkWWPNotificationDefinitionIsAut_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPNotificationDefinitionIsAut.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0D14( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0D0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.wwp_notificationdefinition.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z32WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z32WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z68WWPNotificationDefinitionName", Z68WWPNotificationDefinitionName);
         GxWebStd.gx_hidden_field( context, "Z39WWPNotificationDefinitionAppli", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z39WWPNotificationDefinitionAppli), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z40WWPNotificationDefinitionAllow", Z40WWPNotificationDefinitionAllow);
         GxWebStd.gx_hidden_field( context, "Z38WWPNotificationDefinitionDescr", Z38WWPNotificationDefinitionDescr);
         GxWebStd.gx_hidden_field( context, "Z71WWPNotificationDefinitionIcon", Z71WWPNotificationDefinitionIcon);
         GxWebStd.gx_hidden_field( context, "Z72WWPNotificationDefinitionTitle", Z72WWPNotificationDefinitionTitle);
         GxWebStd.gx_hidden_field( context, "Z73WWPNotificationDefinitionShort", Z73WWPNotificationDefinitionShort);
         GxWebStd.gx_hidden_field( context, "Z74WWPNotificationDefinitionLongD", Z74WWPNotificationDefinitionLongD);
         GxWebStd.gx_hidden_field( context, "Z75WWPNotificationDefinitionLink", Z75WWPNotificationDefinitionLink);
         GxWebStd.gx_hidden_field( context, "Z76WWPNotificationDefinitionSecFu", Z76WWPNotificationDefinitionSecFu);
         GxWebStd.gx_hidden_field( context, "Z29WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29WWPEntityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("wwpbaseobjects.notifications.common.wwp_notificationdefinition.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Common.WWP_NotificationDefinition" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Notification Definition", "") ;
      }

      protected void InitializeNonKey0D14( )
      {
         A77WWPNotificationDefinitionIsAut = false;
         AssignAttri("", false, "A77WWPNotificationDefinitionIsAut", A77WWPNotificationDefinitionIsAut);
         A68WWPNotificationDefinitionName = "";
         AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
         A39WWPNotificationDefinitionAppli = 0;
         AssignAttri("", false, "A39WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0));
         A40WWPNotificationDefinitionAllow = false;
         AssignAttri("", false, "A40WWPNotificationDefinitionAllow", A40WWPNotificationDefinitionAllow);
         A38WWPNotificationDefinitionDescr = "";
         AssignAttri("", false, "A38WWPNotificationDefinitionDescr", A38WWPNotificationDefinitionDescr);
         A71WWPNotificationDefinitionIcon = "";
         AssignAttri("", false, "A71WWPNotificationDefinitionIcon", A71WWPNotificationDefinitionIcon);
         A72WWPNotificationDefinitionTitle = "";
         AssignAttri("", false, "A72WWPNotificationDefinitionTitle", A72WWPNotificationDefinitionTitle);
         A73WWPNotificationDefinitionShort = "";
         AssignAttri("", false, "A73WWPNotificationDefinitionShort", A73WWPNotificationDefinitionShort);
         A74WWPNotificationDefinitionLongD = "";
         AssignAttri("", false, "A74WWPNotificationDefinitionLongD", A74WWPNotificationDefinitionLongD);
         A75WWPNotificationDefinitionLink = "";
         AssignAttri("", false, "A75WWPNotificationDefinitionLink", A75WWPNotificationDefinitionLink);
         A29WWPEntityId = 0;
         AssignAttri("", false, "A29WWPEntityId", StringUtil.LTrimStr( (decimal)(A29WWPEntityId), 10, 0));
         A30WWPEntityName = "";
         AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
         A76WWPNotificationDefinitionSecFu = "";
         AssignAttri("", false, "A76WWPNotificationDefinitionSecFu", A76WWPNotificationDefinitionSecFu);
         Z68WWPNotificationDefinitionName = "";
         Z39WWPNotificationDefinitionAppli = 0;
         Z40WWPNotificationDefinitionAllow = false;
         Z38WWPNotificationDefinitionDescr = "";
         Z71WWPNotificationDefinitionIcon = "";
         Z72WWPNotificationDefinitionTitle = "";
         Z73WWPNotificationDefinitionShort = "";
         Z74WWPNotificationDefinitionLongD = "";
         Z75WWPNotificationDefinitionLink = "";
         Z76WWPNotificationDefinitionSecFu = "";
         Z29WWPEntityId = 0;
      }

      protected void InitAll0D14( )
      {
         A32WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A32WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A32WWPNotificationDefinitionId), 10, 0));
         InitializeNonKey0D14( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302184935", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/common/wwp_notificationdefinition.js", "?20267302184936", false, true, false);
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
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPNotificationDefinitionName_Internalname = "WWPNOTIFICATIONDEFINITIONNAME";
         cmbWWPNotificationDefinitionAppli_Internalname = "WWPNOTIFICATIONDEFINITIONAPPLI";
         chkWWPNotificationDefinitionAllow_Internalname = "WWPNOTIFICATIONDEFINITIONALLOW";
         edtWWPNotificationDefinitionDescr_Internalname = "WWPNOTIFICATIONDEFINITIONDESCR";
         edtWWPNotificationDefinitionIcon_Internalname = "WWPNOTIFICATIONDEFINITIONICON";
         edtWWPNotificationDefinitionTitle_Internalname = "WWPNOTIFICATIONDEFINITIONTITLE";
         edtWWPNotificationDefinitionShort_Internalname = "WWPNOTIFICATIONDEFINITIONSHORT";
         edtWWPNotificationDefinitionLongD_Internalname = "WWPNOTIFICATIONDEFINITIONLONGD";
         edtWWPNotificationDefinitionLink_Internalname = "WWPNOTIFICATIONDEFINITIONLINK";
         edtWWPEntityId_Internalname = "WWPENTITYID";
         edtWWPEntityName_Internalname = "WWPENTITYNAME";
         edtWWPNotificationDefinitionSecFu_Internalname = "WWPNOTIFICATIONDEFINITIONSECFU";
         chkWWPNotificationDefinitionIsAut_Internalname = "WWPNOTIFICATIONDEFINITIONISAUT";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
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
         Form.Caption = context.GetMessage( "Notification Definition", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkWWPNotificationDefinitionIsAut.Enabled = 0;
         edtWWPNotificationDefinitionSecFu_Enabled = 1;
         edtWWPEntityName_Jsonclick = "";
         edtWWPEntityName_Enabled = 0;
         imgprompt_29_Visible = 1;
         imgprompt_29_Link = "";
         edtWWPEntityId_Jsonclick = "";
         edtWWPEntityId_Enabled = 1;
         edtWWPNotificationDefinitionLink_Jsonclick = "";
         edtWWPNotificationDefinitionLink_Enabled = 1;
         edtWWPNotificationDefinitionLongD_Enabled = 1;
         edtWWPNotificationDefinitionShort_Enabled = 1;
         edtWWPNotificationDefinitionTitle_Enabled = 1;
         edtWWPNotificationDefinitionIcon_Jsonclick = "";
         edtWWPNotificationDefinitionIcon_Enabled = 1;
         edtWWPNotificationDefinitionDescr_Enabled = 1;
         chkWWPNotificationDefinitionAllow.Enabled = 1;
         cmbWWPNotificationDefinitionAppli_Jsonclick = "";
         cmbWWPNotificationDefinitionAppli.Enabled = 1;
         edtWWPNotificationDefinitionName_Jsonclick = "";
         edtWWPNotificationDefinitionName_Enabled = 1;
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPNotificationDefinitionId_Enabled = 1;
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

      protected void GX3ASAWWPNOTIFICATIONDEFINITIONISAUT0D14( string A76WWPNotificationDefinitionSecFu )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A76WWPNotificationDefinitionSecFu)) )
         {
            A77WWPNotificationDefinitionIsAut = true;
            AssignAttri("", false, "A77WWPNotificationDefinitionIsAut", A77WWPNotificationDefinitionIsAut);
         }
         else
         {
            GXt_boolean1 = A77WWPNotificationDefinitionIsAut;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  A76WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A77WWPNotificationDefinitionIsAut = GXt_boolean1;
            AssignAttri("", false, "A77WWPNotificationDefinitionIsAut", A77WWPNotificationDefinitionIsAut);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A77WWPNotificationDefinitionIsAut))+"\"") ;
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
         cmbWWPNotificationDefinitionAppli.Name = "WWPNOTIFICATIONDEFINITIONAPPLI";
         cmbWWPNotificationDefinitionAppli.WebTags = "";
         cmbWWPNotificationDefinitionAppli.addItem("1", context.GetMessage( "Any record", ""), 0);
         cmbWWPNotificationDefinitionAppli.addItem("2", context.GetMessage( "Specific record", ""), 0);
         if ( cmbWWPNotificationDefinitionAppli.ItemCount > 0 )
         {
            A39WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( cmbWWPNotificationDefinitionAppli.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A39WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0));
         }
         chkWWPNotificationDefinitionAllow.Name = "WWPNOTIFICATIONDEFINITIONALLOW";
         chkWWPNotificationDefinitionAllow.WebTags = "";
         chkWWPNotificationDefinitionAllow.Caption = context.GetMessage( "Allow User Subscription", "");
         AssignProp("", false, chkWWPNotificationDefinitionAllow_Internalname, "TitleCaption", chkWWPNotificationDefinitionAllow.Caption, true);
         chkWWPNotificationDefinitionAllow.CheckedValue = "false";
         A40WWPNotificationDefinitionAllow = StringUtil.StrToBool( StringUtil.BoolToStr( A40WWPNotificationDefinitionAllow));
         AssignAttri("", false, "A40WWPNotificationDefinitionAllow", A40WWPNotificationDefinitionAllow);
         chkWWPNotificationDefinitionIsAut.Name = "WWPNOTIFICATIONDEFINITIONISAUT";
         chkWWPNotificationDefinitionIsAut.WebTags = "";
         chkWWPNotificationDefinitionIsAut.Caption = context.GetMessage( "User Authorized", "");
         AssignProp("", false, chkWWPNotificationDefinitionIsAut_Internalname, "TitleCaption", chkWWPNotificationDefinitionIsAut.Caption, true);
         chkWWPNotificationDefinitionIsAut.CheckedValue = "false";
         A77WWPNotificationDefinitionIsAut = StringUtil.StrToBool( StringUtil.BoolToStr( A77WWPNotificationDefinitionIsAut));
         AssignAttri("", false, "A77WWPNotificationDefinitionIsAut", A77WWPNotificationDefinitionIsAut);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
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

      public void Valid_Wwpnotificationdefinitionid( )
      {
         A39WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( cmbWWPNotificationDefinitionAppli.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPNotificationDefinitionAppli.ItemCount > 0 )
         {
            A39WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( cmbWWPNotificationDefinitionAppli.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0));
         }
         A40WWPNotificationDefinitionAllow = StringUtil.StrToBool( StringUtil.BoolToStr( A40WWPNotificationDefinitionAllow));
         A77WWPNotificationDefinitionIsAut = StringUtil.StrToBool( StringUtil.BoolToStr( A77WWPNotificationDefinitionIsAut));
         /*  Sending validation outputs */
         AssignAttri("", false, "A68WWPNotificationDefinitionName", A68WWPNotificationDefinitionName);
         AssignAttri("", false, "A39WWPNotificationDefinitionAppli", StringUtil.LTrim( StringUtil.NToC( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0, ".", "")));
         cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A39WWPNotificationDefinitionAppli), 1, 0));
         AssignProp("", false, cmbWWPNotificationDefinitionAppli_Internalname, "Values", cmbWWPNotificationDefinitionAppli.ToJavascriptSource(), true);
         AssignAttri("", false, "A40WWPNotificationDefinitionAllow", A40WWPNotificationDefinitionAllow);
         AssignAttri("", false, "A38WWPNotificationDefinitionDescr", A38WWPNotificationDefinitionDescr);
         AssignAttri("", false, "A71WWPNotificationDefinitionIcon", A71WWPNotificationDefinitionIcon);
         AssignAttri("", false, "A72WWPNotificationDefinitionTitle", A72WWPNotificationDefinitionTitle);
         AssignAttri("", false, "A73WWPNotificationDefinitionShort", A73WWPNotificationDefinitionShort);
         AssignAttri("", false, "A74WWPNotificationDefinitionLongD", A74WWPNotificationDefinitionLongD);
         AssignAttri("", false, "A75WWPNotificationDefinitionLink", A75WWPNotificationDefinitionLink);
         AssignAttri("", false, "A29WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A76WWPNotificationDefinitionSecFu", A76WWPNotificationDefinitionSecFu);
         AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
         AssignAttri("", false, "A77WWPNotificationDefinitionIsAut", A77WWPNotificationDefinitionIsAut);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z32WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z32WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z68WWPNotificationDefinitionName", Z68WWPNotificationDefinitionName);
         GxWebStd.gx_hidden_field( context, "Z39WWPNotificationDefinitionAppli", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z39WWPNotificationDefinitionAppli), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z40WWPNotificationDefinitionAllow", StringUtil.BoolToStr( Z40WWPNotificationDefinitionAllow));
         GxWebStd.gx_hidden_field( context, "Z38WWPNotificationDefinitionDescr", Z38WWPNotificationDefinitionDescr);
         GxWebStd.gx_hidden_field( context, "Z71WWPNotificationDefinitionIcon", Z71WWPNotificationDefinitionIcon);
         GxWebStd.gx_hidden_field( context, "Z72WWPNotificationDefinitionTitle", Z72WWPNotificationDefinitionTitle);
         GxWebStd.gx_hidden_field( context, "Z73WWPNotificationDefinitionShort", Z73WWPNotificationDefinitionShort);
         GxWebStd.gx_hidden_field( context, "Z74WWPNotificationDefinitionLongD", Z74WWPNotificationDefinitionLongD);
         GxWebStd.gx_hidden_field( context, "Z75WWPNotificationDefinitionLink", Z75WWPNotificationDefinitionLink);
         GxWebStd.gx_hidden_field( context, "Z29WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29WWPEntityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z76WWPNotificationDefinitionSecFu", Z76WWPNotificationDefinitionSecFu);
         GxWebStd.gx_hidden_field( context, "Z30WWPEntityName", Z30WWPEntityName);
         GxWebStd.gx_hidden_field( context, "Z77WWPNotificationDefinitionIsAut", StringUtil.BoolToStr( Z77WWPNotificationDefinitionIsAut));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpentityid( )
      {
         /* Using cursor T000D13 */
         pr_default.execute(11, new Object[] {A29WWPEntityId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
         }
         A30WWPEntityName = T000D13_A30WWPEntityName[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A30WWPEntityName", A30WWPEntityName);
      }

      public void Valid_Wwpnotificationdefinitionsecfu( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A76WWPNotificationDefinitionSecFu)) )
         {
            A77WWPNotificationDefinitionIsAut = true;
         }
         else
         {
            GXt_boolean1 = A77WWPNotificationDefinitionIsAut;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  A76WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A77WWPNotificationDefinitionIsAut = GXt_boolean1;
         }
         dynload_actions( ) ;
         A77WWPNotificationDefinitionIsAut = StringUtil.StrToBool( StringUtil.BoolToStr( A77WWPNotificationDefinitionIsAut));
         /*  Sending validation outputs */
         AssignAttri("", false, "A77WWPNotificationDefinitionIsAut", A77WWPNotificationDefinitionIsAut);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A40WWPNotificationDefinitionAllow',fld:'WWPNOTIFICATIONDEFINITIONALLOW',pic:'',type:'boolean'},{av:'A77WWPNotificationDefinitionIsAut',fld:'WWPNOTIFICATIONDEFINITIONISAUT',pic:'',type:'boolean'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A40WWPNotificationDefinitionAllow',fld:'WWPNOTIFICATIONDEFINITIONALLOW',pic:'',type:'boolean'},{av:'A77WWPNotificationDefinitionIsAut',fld:'WWPNOTIFICATIONDEFINITIONISAUT',pic:'',type:'boolean'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A40WWPNotificationDefinitionAllow',fld:'WWPNOTIFICATIONDEFINITIONALLOW',pic:'',type:'boolean'},{av:'A77WWPNotificationDefinitionIsAut',fld:'WWPNOTIFICATIONDEFINITIONISAUT',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A40WWPNotificationDefinitionAllow',fld:'WWPNOTIFICATIONDEFINITIONALLOW',pic:'',type:'boolean'},{av:'A77WWPNotificationDefinitionIsAut',fld:'WWPNOTIFICATIONDEFINITIONISAUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID","{handler:'Valid_Wwpnotificationdefinitionid',iparms:[{av:'cmbWWPNotificationDefinitionAppli'},{av:'A39WWPNotificationDefinitionAppli',fld:'WWPNOTIFICATIONDEFINITIONAPPLI',pic:'9',type:'int'},{av:'A32WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'A40WWPNotificationDefinitionAllow',fld:'WWPNOTIFICATIONDEFINITIONALLOW',pic:'',type:'boolean'},{av:'A77WWPNotificationDefinitionIsAut',fld:'WWPNOTIFICATIONDEFINITIONISAUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID",",oparms:[{av:'A68WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:'',type:'svchar'},{av:'cmbWWPNotificationDefinitionAppli'},{av:'A39WWPNotificationDefinitionAppli',fld:'WWPNOTIFICATIONDEFINITIONAPPLI',pic:'9',type:'int'},{av:'A38WWPNotificationDefinitionDescr',fld:'WWPNOTIFICATIONDEFINITIONDESCR',pic:'',type:'svchar'},{av:'A71WWPNotificationDefinitionIcon',fld:'WWPNOTIFICATIONDEFINITIONICON',pic:'',type:'svchar'},{av:'A72WWPNotificationDefinitionTitle',fld:'WWPNOTIFICATIONDEFINITIONTITLE',pic:'',type:'svchar'},{av:'A73WWPNotificationDefinitionShort',fld:'WWPNOTIFICATIONDEFINITIONSHORT',pic:'',type:'svchar'},{av:'A74WWPNotificationDefinitionLongD',fld:'WWPNOTIFICATIONDEFINITIONLONGD',pic:'',type:'svchar'},{av:'A75WWPNotificationDefinitionLink',fld:'WWPNOTIFICATIONDEFINITIONLINK',pic:'',type:'svchar'},{av:'A29WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A76WWPNotificationDefinitionSecFu',fld:'WWPNOTIFICATIONDEFINITIONSECFU',pic:'',type:'svchar'},{av:'A30WWPEntityName',fld:'WWPENTITYNAME',pic:'',type:'svchar'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z32WWPNotificationDefinitionId',type:'int'},{av:'Z68WWPNotificationDefinitionName',type:'svchar'},{av:'Z39WWPNotificationDefinitionAppli',type:'int'},{av:'Z40WWPNotificationDefinitionAllow',type:'boolean'},{av:'Z38WWPNotificationDefinitionDescr',type:'svchar'},{av:'Z71WWPNotificationDefinitionIcon',type:'svchar'},{av:'Z72WWPNotificationDefinitionTitle',type:'svchar'},{av:'Z73WWPNotificationDefinitionShort',type:'svchar'},{av:'Z74WWPNotificationDefinitionLongD',type:'svchar'},{av:'Z75WWPNotificationDefinitionLink',type:'svchar'},{av:'Z29WWPEntityId',type:'int'},{av:'Z76WWPNotificationDefinitionSecFu',type:'svchar'},{av:'Z30WWPEntityName',type:'svchar'},{av:'Z77WWPNotificationDefinitionIsAut',type:'boolean'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A40WWPNotificationDefinitionAllow',fld:'WWPNOTIFICATIONDEFINITIONALLOW',pic:'',type:'boolean'},{av:'A77WWPNotificationDefinitionIsAut',fld:'WWPNOTIFICATIONDEFINITIONISAUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONAPPLI","{handler:'Valid_Wwpnotificationdefinitionappli',iparms:[{av:'A40WWPNotificationDefinitionAllow',fld:'WWPNOTIFICATIONDEFINITIONALLOW',pic:'',type:'boolean'},{av:'A77WWPNotificationDefinitionIsAut',fld:'WWPNOTIFICATIONDEFINITIONISAUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONAPPLI",",oparms:[{av:'A40WWPNotificationDefinitionAllow',fld:'WWPNOTIFICATIONDEFINITIONALLOW',pic:'',type:'boolean'},{av:'A77WWPNotificationDefinitionIsAut',fld:'WWPNOTIFICATIONDEFINITIONISAUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONLINK","{handler:'Valid_Wwpnotificationdefinitionlink',iparms:[{av:'A40WWPNotificationDefinitionAllow',fld:'WWPNOTIFICATIONDEFINITIONALLOW',pic:'',type:'boolean'},{av:'A77WWPNotificationDefinitionIsAut',fld:'WWPNOTIFICATIONDEFINITIONISAUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONLINK",",oparms:[{av:'A40WWPNotificationDefinitionAllow',fld:'WWPNOTIFICATIONDEFINITIONALLOW',pic:'',type:'boolean'},{av:'A77WWPNotificationDefinitionIsAut',fld:'WWPNOTIFICATIONDEFINITIONISAUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPENTITYID","{handler:'Valid_Wwpentityid',iparms:[{av:'A29WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A30WWPEntityName',fld:'WWPENTITYNAME',pic:'',type:'svchar'},{av:'A40WWPNotificationDefinitionAllow',fld:'WWPNOTIFICATIONDEFINITIONALLOW',pic:'',type:'boolean'},{av:'A77WWPNotificationDefinitionIsAut',fld:'WWPNOTIFICATIONDEFINITIONISAUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPENTITYID",",oparms:[{av:'A30WWPEntityName',fld:'WWPENTITYNAME',pic:'',type:'svchar'},{av:'A40WWPNotificationDefinitionAllow',fld:'WWPNOTIFICATIONDEFINITIONALLOW',pic:'',type:'boolean'},{av:'A77WWPNotificationDefinitionIsAut',fld:'WWPNOTIFICATIONDEFINITIONISAUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONSECFU","{handler:'Valid_Wwpnotificationdefinitionsecfu',iparms:[{av:'A76WWPNotificationDefinitionSecFu',fld:'WWPNOTIFICATIONDEFINITIONSECFU',pic:'',type:'svchar'},{av:'A40WWPNotificationDefinitionAllow',fld:'WWPNOTIFICATIONDEFINITIONALLOW',pic:'',type:'boolean'},{av:'A77WWPNotificationDefinitionIsAut',fld:'WWPNOTIFICATIONDEFINITIONISAUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONSECFU",",oparms:[{av:'A40WWPNotificationDefinitionAllow',fld:'WWPNOTIFICATIONDEFINITIONALLOW',pic:'',type:'boolean'},{av:'A77WWPNotificationDefinitionIsAut',fld:'WWPNOTIFICATIONDEFINITIONISAUT',pic:'',type:'boolean'}]}");
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
         Z68WWPNotificationDefinitionName = "";
         Z38WWPNotificationDefinitionDescr = "";
         Z71WWPNotificationDefinitionIcon = "";
         Z72WWPNotificationDefinitionTitle = "";
         Z73WWPNotificationDefinitionShort = "";
         Z74WWPNotificationDefinitionLongD = "";
         Z75WWPNotificationDefinitionLink = "";
         Z76WWPNotificationDefinitionSecFu = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A76WWPNotificationDefinitionSecFu = "";
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
         A68WWPNotificationDefinitionName = "";
         A38WWPNotificationDefinitionDescr = "";
         A71WWPNotificationDefinitionIcon = "";
         A72WWPNotificationDefinitionTitle = "";
         A73WWPNotificationDefinitionShort = "";
         A74WWPNotificationDefinitionLongD = "";
         A75WWPNotificationDefinitionLink = "";
         imgprompt_29_gximage = "";
         sImgUrl = "";
         A30WWPEntityName = "";
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
         Z30WWPEntityName = "";
         T000D5_A32WWPNotificationDefinitionId = new long[1] ;
         T000D5_A68WWPNotificationDefinitionName = new string[] {""} ;
         T000D5_A39WWPNotificationDefinitionAppli = new short[1] ;
         T000D5_A40WWPNotificationDefinitionAllow = new bool[] {false} ;
         T000D5_A38WWPNotificationDefinitionDescr = new string[] {""} ;
         T000D5_A71WWPNotificationDefinitionIcon = new string[] {""} ;
         T000D5_A72WWPNotificationDefinitionTitle = new string[] {""} ;
         T000D5_A73WWPNotificationDefinitionShort = new string[] {""} ;
         T000D5_A74WWPNotificationDefinitionLongD = new string[] {""} ;
         T000D5_A75WWPNotificationDefinitionLink = new string[] {""} ;
         T000D5_A30WWPEntityName = new string[] {""} ;
         T000D5_A76WWPNotificationDefinitionSecFu = new string[] {""} ;
         T000D5_A29WWPEntityId = new long[1] ;
         T000D4_A30WWPEntityName = new string[] {""} ;
         T000D6_A30WWPEntityName = new string[] {""} ;
         T000D7_A32WWPNotificationDefinitionId = new long[1] ;
         T000D3_A32WWPNotificationDefinitionId = new long[1] ;
         T000D3_A68WWPNotificationDefinitionName = new string[] {""} ;
         T000D3_A39WWPNotificationDefinitionAppli = new short[1] ;
         T000D3_A40WWPNotificationDefinitionAllow = new bool[] {false} ;
         T000D3_A38WWPNotificationDefinitionDescr = new string[] {""} ;
         T000D3_A71WWPNotificationDefinitionIcon = new string[] {""} ;
         T000D3_A72WWPNotificationDefinitionTitle = new string[] {""} ;
         T000D3_A73WWPNotificationDefinitionShort = new string[] {""} ;
         T000D3_A74WWPNotificationDefinitionLongD = new string[] {""} ;
         T000D3_A75WWPNotificationDefinitionLink = new string[] {""} ;
         T000D3_A76WWPNotificationDefinitionSecFu = new string[] {""} ;
         T000D3_A29WWPEntityId = new long[1] ;
         sMode14 = "";
         T000D8_A32WWPNotificationDefinitionId = new long[1] ;
         T000D9_A32WWPNotificationDefinitionId = new long[1] ;
         T000D2_A32WWPNotificationDefinitionId = new long[1] ;
         T000D2_A68WWPNotificationDefinitionName = new string[] {""} ;
         T000D2_A39WWPNotificationDefinitionAppli = new short[1] ;
         T000D2_A40WWPNotificationDefinitionAllow = new bool[] {false} ;
         T000D2_A38WWPNotificationDefinitionDescr = new string[] {""} ;
         T000D2_A71WWPNotificationDefinitionIcon = new string[] {""} ;
         T000D2_A72WWPNotificationDefinitionTitle = new string[] {""} ;
         T000D2_A73WWPNotificationDefinitionShort = new string[] {""} ;
         T000D2_A74WWPNotificationDefinitionLongD = new string[] {""} ;
         T000D2_A75WWPNotificationDefinitionLink = new string[] {""} ;
         T000D2_A76WWPNotificationDefinitionSecFu = new string[] {""} ;
         T000D2_A29WWPEntityId = new long[1] ;
         T000D10_A32WWPNotificationDefinitionId = new long[1] ;
         T000D13_A30WWPEntityName = new string[] {""} ;
         T000D14_A31WWPNotificationId = new long[1] ;
         T000D15_A34WWPSubscriptionId = new long[1] ;
         T000D16_A32WWPNotificationDefinitionId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ68WWPNotificationDefinitionName = "";
         ZZ38WWPNotificationDefinitionDescr = "";
         ZZ71WWPNotificationDefinitionIcon = "";
         ZZ72WWPNotificationDefinitionTitle = "";
         ZZ73WWPNotificationDefinitionShort = "";
         ZZ74WWPNotificationDefinitionLongD = "";
         ZZ75WWPNotificationDefinitionLink = "";
         ZZ76WWPNotificationDefinitionSecFu = "";
         ZZ30WWPEntityName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition__default(),
            new Object[][] {
                new Object[] {
               T000D2_A32WWPNotificationDefinitionId, T000D2_A68WWPNotificationDefinitionName, T000D2_A39WWPNotificationDefinitionAppli, T000D2_A40WWPNotificationDefinitionAllow, T000D2_A38WWPNotificationDefinitionDescr, T000D2_A71WWPNotificationDefinitionIcon, T000D2_A72WWPNotificationDefinitionTitle, T000D2_A73WWPNotificationDefinitionShort, T000D2_A74WWPNotificationDefinitionLongD, T000D2_A75WWPNotificationDefinitionLink,
               T000D2_A76WWPNotificationDefinitionSecFu, T000D2_A29WWPEntityId
               }
               , new Object[] {
               T000D3_A32WWPNotificationDefinitionId, T000D3_A68WWPNotificationDefinitionName, T000D3_A39WWPNotificationDefinitionAppli, T000D3_A40WWPNotificationDefinitionAllow, T000D3_A38WWPNotificationDefinitionDescr, T000D3_A71WWPNotificationDefinitionIcon, T000D3_A72WWPNotificationDefinitionTitle, T000D3_A73WWPNotificationDefinitionShort, T000D3_A74WWPNotificationDefinitionLongD, T000D3_A75WWPNotificationDefinitionLink,
               T000D3_A76WWPNotificationDefinitionSecFu, T000D3_A29WWPEntityId
               }
               , new Object[] {
               T000D4_A30WWPEntityName
               }
               , new Object[] {
               T000D5_A32WWPNotificationDefinitionId, T000D5_A68WWPNotificationDefinitionName, T000D5_A39WWPNotificationDefinitionAppli, T000D5_A40WWPNotificationDefinitionAllow, T000D5_A38WWPNotificationDefinitionDescr, T000D5_A71WWPNotificationDefinitionIcon, T000D5_A72WWPNotificationDefinitionTitle, T000D5_A73WWPNotificationDefinitionShort, T000D5_A74WWPNotificationDefinitionLongD, T000D5_A75WWPNotificationDefinitionLink,
               T000D5_A30WWPEntityName, T000D5_A76WWPNotificationDefinitionSecFu, T000D5_A29WWPEntityId
               }
               , new Object[] {
               T000D6_A30WWPEntityName
               }
               , new Object[] {
               T000D7_A32WWPNotificationDefinitionId
               }
               , new Object[] {
               T000D8_A32WWPNotificationDefinitionId
               }
               , new Object[] {
               T000D9_A32WWPNotificationDefinitionId
               }
               , new Object[] {
               T000D10_A32WWPNotificationDefinitionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000D13_A30WWPEntityName
               }
               , new Object[] {
               T000D14_A31WWPNotificationId
               }
               , new Object[] {
               T000D15_A34WWPSubscriptionId
               }
               , new Object[] {
               T000D16_A32WWPNotificationDefinitionId
               }
            }
         );
      }

      private short Z39WWPNotificationDefinitionAppli ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A39WWPNotificationDefinitionAppli ;
      private short RcdFound14 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ39WWPNotificationDefinitionAppli ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int edtWWPNotificationDefinitionName_Enabled ;
      private int edtWWPNotificationDefinitionDescr_Enabled ;
      private int edtWWPNotificationDefinitionIcon_Enabled ;
      private int edtWWPNotificationDefinitionTitle_Enabled ;
      private int edtWWPNotificationDefinitionShort_Enabled ;
      private int edtWWPNotificationDefinitionLongD_Enabled ;
      private int edtWWPNotificationDefinitionLink_Enabled ;
      private int edtWWPEntityId_Enabled ;
      private int imgprompt_29_Visible ;
      private int edtWWPEntityName_Enabled ;
      private int edtWWPNotificationDefinitionSecFu_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z32WWPNotificationDefinitionId ;
      private long Z29WWPEntityId ;
      private long A29WWPEntityId ;
      private long A32WWPNotificationDefinitionId ;
      private long ZZ32WWPNotificationDefinitionId ;
      private long ZZ29WWPEntityId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string cmbWWPNotificationDefinitionAppli_Internalname ;
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
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtWWPNotificationDefinitionName_Internalname ;
      private string edtWWPNotificationDefinitionName_Jsonclick ;
      private string cmbWWPNotificationDefinitionAppli_Jsonclick ;
      private string chkWWPNotificationDefinitionAllow_Internalname ;
      private string edtWWPNotificationDefinitionDescr_Internalname ;
      private string edtWWPNotificationDefinitionIcon_Internalname ;
      private string edtWWPNotificationDefinitionIcon_Jsonclick ;
      private string edtWWPNotificationDefinitionTitle_Internalname ;
      private string edtWWPNotificationDefinitionShort_Internalname ;
      private string edtWWPNotificationDefinitionLongD_Internalname ;
      private string edtWWPNotificationDefinitionLink_Internalname ;
      private string edtWWPNotificationDefinitionLink_Jsonclick ;
      private string edtWWPEntityId_Internalname ;
      private string edtWWPEntityId_Jsonclick ;
      private string imgprompt_29_gximage ;
      private string sImgUrl ;
      private string imgprompt_29_Internalname ;
      private string imgprompt_29_Link ;
      private string edtWWPEntityName_Internalname ;
      private string edtWWPEntityName_Jsonclick ;
      private string edtWWPNotificationDefinitionSecFu_Internalname ;
      private string chkWWPNotificationDefinitionIsAut_Internalname ;
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
      private string sMode14 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z40WWPNotificationDefinitionAllow ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A40WWPNotificationDefinitionAllow ;
      private bool A77WWPNotificationDefinitionIsAut ;
      private bool Gx_longc ;
      private bool Z77WWPNotificationDefinitionIsAut ;
      private bool ZZ40WWPNotificationDefinitionAllow ;
      private bool ZZ77WWPNotificationDefinitionIsAut ;
      private bool GXt_boolean1 ;
      private string Z68WWPNotificationDefinitionName ;
      private string Z38WWPNotificationDefinitionDescr ;
      private string Z71WWPNotificationDefinitionIcon ;
      private string Z72WWPNotificationDefinitionTitle ;
      private string Z73WWPNotificationDefinitionShort ;
      private string Z74WWPNotificationDefinitionLongD ;
      private string Z75WWPNotificationDefinitionLink ;
      private string Z76WWPNotificationDefinitionSecFu ;
      private string A76WWPNotificationDefinitionSecFu ;
      private string A68WWPNotificationDefinitionName ;
      private string A38WWPNotificationDefinitionDescr ;
      private string A71WWPNotificationDefinitionIcon ;
      private string A72WWPNotificationDefinitionTitle ;
      private string A73WWPNotificationDefinitionShort ;
      private string A74WWPNotificationDefinitionLongD ;
      private string A75WWPNotificationDefinitionLink ;
      private string A30WWPEntityName ;
      private string Z30WWPEntityName ;
      private string ZZ68WWPNotificationDefinitionName ;
      private string ZZ38WWPNotificationDefinitionDescr ;
      private string ZZ71WWPNotificationDefinitionIcon ;
      private string ZZ72WWPNotificationDefinitionTitle ;
      private string ZZ73WWPNotificationDefinitionShort ;
      private string ZZ74WWPNotificationDefinitionLongD ;
      private string ZZ75WWPNotificationDefinitionLink ;
      private string ZZ76WWPNotificationDefinitionSecFu ;
      private string ZZ30WWPEntityName ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPNotificationDefinitionAppli ;
      private GXCheckbox chkWWPNotificationDefinitionAllow ;
      private GXCheckbox chkWWPNotificationDefinitionIsAut ;
      private IDataStoreProvider pr_default ;
      private long[] T000D5_A32WWPNotificationDefinitionId ;
      private string[] T000D5_A68WWPNotificationDefinitionName ;
      private short[] T000D5_A39WWPNotificationDefinitionAppli ;
      private bool[] T000D5_A40WWPNotificationDefinitionAllow ;
      private string[] T000D5_A38WWPNotificationDefinitionDescr ;
      private string[] T000D5_A71WWPNotificationDefinitionIcon ;
      private string[] T000D5_A72WWPNotificationDefinitionTitle ;
      private string[] T000D5_A73WWPNotificationDefinitionShort ;
      private string[] T000D5_A74WWPNotificationDefinitionLongD ;
      private string[] T000D5_A75WWPNotificationDefinitionLink ;
      private string[] T000D5_A30WWPEntityName ;
      private string[] T000D5_A76WWPNotificationDefinitionSecFu ;
      private long[] T000D5_A29WWPEntityId ;
      private string[] T000D4_A30WWPEntityName ;
      private string[] T000D6_A30WWPEntityName ;
      private long[] T000D7_A32WWPNotificationDefinitionId ;
      private long[] T000D3_A32WWPNotificationDefinitionId ;
      private string[] T000D3_A68WWPNotificationDefinitionName ;
      private short[] T000D3_A39WWPNotificationDefinitionAppli ;
      private bool[] T000D3_A40WWPNotificationDefinitionAllow ;
      private string[] T000D3_A38WWPNotificationDefinitionDescr ;
      private string[] T000D3_A71WWPNotificationDefinitionIcon ;
      private string[] T000D3_A72WWPNotificationDefinitionTitle ;
      private string[] T000D3_A73WWPNotificationDefinitionShort ;
      private string[] T000D3_A74WWPNotificationDefinitionLongD ;
      private string[] T000D3_A75WWPNotificationDefinitionLink ;
      private string[] T000D3_A76WWPNotificationDefinitionSecFu ;
      private long[] T000D3_A29WWPEntityId ;
      private long[] T000D8_A32WWPNotificationDefinitionId ;
      private long[] T000D9_A32WWPNotificationDefinitionId ;
      private long[] T000D2_A32WWPNotificationDefinitionId ;
      private string[] T000D2_A68WWPNotificationDefinitionName ;
      private short[] T000D2_A39WWPNotificationDefinitionAppli ;
      private bool[] T000D2_A40WWPNotificationDefinitionAllow ;
      private string[] T000D2_A38WWPNotificationDefinitionDescr ;
      private string[] T000D2_A71WWPNotificationDefinitionIcon ;
      private string[] T000D2_A72WWPNotificationDefinitionTitle ;
      private string[] T000D2_A73WWPNotificationDefinitionShort ;
      private string[] T000D2_A74WWPNotificationDefinitionLongD ;
      private string[] T000D2_A75WWPNotificationDefinitionLink ;
      private string[] T000D2_A76WWPNotificationDefinitionSecFu ;
      private long[] T000D2_A29WWPEntityId ;
      private long[] T000D10_A32WWPNotificationDefinitionId ;
      private string[] T000D13_A30WWPEntityName ;
      private long[] T000D14_A31WWPNotificationId ;
      private long[] T000D15_A34WWPSubscriptionId ;
      private long[] T000D16_A32WWPNotificationDefinitionId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_notificationdefinition__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notificationdefinition__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000D2;
        prmT000D2 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000D3;
        prmT000D3 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000D4;
        prmT000D4 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmT000D5;
        prmT000D5 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000D6;
        prmT000D6 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmT000D7;
        prmT000D7 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000D8;
        prmT000D8 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000D9;
        prmT000D9 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000D10;
        prmT000D10 = new Object[] {
        new ParDef("@WWPNotificationDefinitionName",GXType.NVarChar,100,0) ,
        new ParDef("@WWPNotificationDefinitionAppli",GXType.Int16,1,0) ,
        new ParDef("@WWPNotificationDefinitionAllow",GXType.Boolean,4,0) ,
        new ParDef("@WWPNotificationDefinitionDescr",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationDefinitionIcon",GXType.NVarChar,40,0) ,
        new ParDef("@WWPNotificationDefinitionTitle",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationDefinitionShort",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationDefinitionLongD",GXType.NVarChar,1000,0) ,
        new ParDef("@WWPNotificationDefinitionLink",GXType.NVarChar,1000,0) ,
        new ParDef("@WWPNotificationDefinitionSecFu",GXType.NVarChar,200,0) ,
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmT000D11;
        prmT000D11 = new Object[] {
        new ParDef("@WWPNotificationDefinitionName",GXType.NVarChar,100,0) ,
        new ParDef("@WWPNotificationDefinitionAppli",GXType.Int16,1,0) ,
        new ParDef("@WWPNotificationDefinitionAllow",GXType.Boolean,4,0) ,
        new ParDef("@WWPNotificationDefinitionDescr",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationDefinitionIcon",GXType.NVarChar,40,0) ,
        new ParDef("@WWPNotificationDefinitionTitle",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationDefinitionShort",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationDefinitionLongD",GXType.NVarChar,1000,0) ,
        new ParDef("@WWPNotificationDefinitionLink",GXType.NVarChar,1000,0) ,
        new ParDef("@WWPNotificationDefinitionSecFu",GXType.NVarChar,200,0) ,
        new ParDef("@WWPEntityId",GXType.Decimal,10,0) ,
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000D12;
        prmT000D12 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000D13;
        prmT000D13 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmT000D14;
        prmT000D14 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000D15;
        prmT000D15 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmT000D16;
        prmT000D16 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000D2", "SELECT [WWPNotificationDefinitionId], [WWPNotificationDefinitionName], [WWPNotificationDefinitionAppli], [WWPNotificationDefinitionAllow], [WWPNotificationDefinitionDescr], [WWPNotificationDefinitionIcon], [WWPNotificationDefinitionTitle], [WWPNotificationDefinitionShort], [WWPNotificationDefinitionLongD], [WWPNotificationDefinitionLink], [WWPNotificationDefinitionSecFu], [WWPEntityId] FROM [WWP_NotificationDefinition] WITH (UPDLOCK) WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D3", "SELECT [WWPNotificationDefinitionId], [WWPNotificationDefinitionName], [WWPNotificationDefinitionAppli], [WWPNotificationDefinitionAllow], [WWPNotificationDefinitionDescr], [WWPNotificationDefinitionIcon], [WWPNotificationDefinitionTitle], [WWPNotificationDefinitionShort], [WWPNotificationDefinitionLongD], [WWPNotificationDefinitionLink], [WWPNotificationDefinitionSecFu], [WWPEntityId] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D4", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D5", "SELECT TM1.[WWPNotificationDefinitionId], TM1.[WWPNotificationDefinitionName], TM1.[WWPNotificationDefinitionAppli], TM1.[WWPNotificationDefinitionAllow], TM1.[WWPNotificationDefinitionDescr], TM1.[WWPNotificationDefinitionIcon], TM1.[WWPNotificationDefinitionTitle], TM1.[WWPNotificationDefinitionShort], TM1.[WWPNotificationDefinitionLongD], TM1.[WWPNotificationDefinitionLink], T2.[WWPEntityName], TM1.[WWPNotificationDefinitionSecFu], TM1.[WWPEntityId] FROM ([WWP_NotificationDefinition] TM1 INNER JOIN [WWP_Entity] T2 ON T2.[WWPEntityId] = TM1.[WWPEntityId]) WHERE TM1.[WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ORDER BY TM1.[WWPNotificationDefinitionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D6", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D7", "SELECT [WWPNotificationDefinitionId] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D8", "SELECT TOP 1 [WWPNotificationDefinitionId] FROM [WWP_NotificationDefinition] WHERE ( [WWPNotificationDefinitionId] > @WWPNotificationDefinitionId) ORDER BY [WWPNotificationDefinitionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D9", "SELECT TOP 1 [WWPNotificationDefinitionId] FROM [WWP_NotificationDefinition] WHERE ( [WWPNotificationDefinitionId] < @WWPNotificationDefinitionId) ORDER BY [WWPNotificationDefinitionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D10", "INSERT INTO [WWP_NotificationDefinition]([WWPNotificationDefinitionName], [WWPNotificationDefinitionAppli], [WWPNotificationDefinitionAllow], [WWPNotificationDefinitionDescr], [WWPNotificationDefinitionIcon], [WWPNotificationDefinitionTitle], [WWPNotificationDefinitionShort], [WWPNotificationDefinitionLongD], [WWPNotificationDefinitionLink], [WWPNotificationDefinitionSecFu], [WWPEntityId]) VALUES(@WWPNotificationDefinitionName, @WWPNotificationDefinitionAppli, @WWPNotificationDefinitionAllow, @WWPNotificationDefinitionDescr, @WWPNotificationDefinitionIcon, @WWPNotificationDefinitionTitle, @WWPNotificationDefinitionShort, @WWPNotificationDefinitionLongD, @WWPNotificationDefinitionLink, @WWPNotificationDefinitionSecFu, @WWPEntityId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000D10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D11", "UPDATE [WWP_NotificationDefinition] SET [WWPNotificationDefinitionName]=@WWPNotificationDefinitionName, [WWPNotificationDefinitionAppli]=@WWPNotificationDefinitionAppli, [WWPNotificationDefinitionAllow]=@WWPNotificationDefinitionAllow, [WWPNotificationDefinitionDescr]=@WWPNotificationDefinitionDescr, [WWPNotificationDefinitionIcon]=@WWPNotificationDefinitionIcon, [WWPNotificationDefinitionTitle]=@WWPNotificationDefinitionTitle, [WWPNotificationDefinitionShort]=@WWPNotificationDefinitionShort, [WWPNotificationDefinitionLongD]=@WWPNotificationDefinitionLongD, [WWPNotificationDefinitionLink]=@WWPNotificationDefinitionLink, [WWPNotificationDefinitionSecFu]=@WWPNotificationDefinitionSecFu, [WWPEntityId]=@WWPEntityId  WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId", GxErrorMask.GX_NOMASK,prmT000D11)
           ,new CursorDef("T000D12", "DELETE FROM [WWP_NotificationDefinition]  WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId", GxErrorMask.GX_NOMASK,prmT000D12)
           ,new CursorDef("T000D13", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D14", "SELECT TOP 1 [WWPNotificationId] FROM [WWP_Notification] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D15", "SELECT TOP 1 [WWPSubscriptionId] FROM [WWP_Subscription] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D16", "SELECT [WWPNotificationDefinitionId] FROM [WWP_NotificationDefinition] ORDER BY [WWPNotificationDefinitionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D16,100, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((long[]) buf[12])[0] = rslt.getLong(13);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
