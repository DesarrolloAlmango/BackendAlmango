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
   public class secobject : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A13SecFunctionalityId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecFunctionalityId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A13SecFunctionalityId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsecobject_functionalities") == 0 )
         {
            gxnrGridsecobject_functionalities_newrow_invoke( ) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Sec Object", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSecObjectName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridsecobject_functionalities_newrow_invoke( )
      {
         nRC_GXsfl_43 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_43"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_43_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_43_idx = GetPar( "sGXsfl_43_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsecobject_functionalities_newrow( ) ;
         /* End function gxnrGridsecobject_functionalities_newrow_invoke */
      }

      public secobject( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secobject( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Sec Object", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecObject.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"wwpbaseobjects.gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SECOBJECTNAME"+"'), id:'"+"SECOBJECTNAME"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_WWPBaseObjects/SecObject.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecObjectName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecObjectName_Internalname, context.GetMessage( "Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecObjectName_Internalname, A17SecObjectName, StringUtil.RTrim( context.localUtil.Format( A17SecObjectName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecObjectName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecObjectName_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFunctionalitiestable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlefunctionalities_Internalname, context.GetMessage( "Functionalities", ""), "", "", lblTitlefunctionalities_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridsecobject_functionalities( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridsecobject_functionalities( )
      {
         /*  Grid Control  */
         StartGridControl43( ) ;
         nGXsfl_43_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount5 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_5 = 1;
               ScanStart045( ) ;
               while ( RcdFound5 != 0 )
               {
                  init_level_properties5( ) ;
                  getByPrimaryKey045( ) ;
                  AddRow045( ) ;
                  ScanNext045( ) ;
               }
               ScanEnd045( ) ;
               nBlankRcdCount5 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal045( ) ;
            standaloneModal045( ) ;
            sMode5 = Gx_mode;
            while ( nGXsfl_43_idx < nRC_GXsfl_43 )
            {
               bGXsfl_43_Refreshing = true;
               ReadRow045( ) ;
               edtSecFunctionalityId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECFUNCTIONALITYID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtSecFunctionalityDescription_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSecFunctionalityDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityDescription_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               imgprompt_13_Link = cgiGet( "PROMPT_13_"+sGXsfl_43_idx+"Link");
               if ( ( nRcdExists_5 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal045( ) ;
               }
               SendRow045( ) ;
               bGXsfl_43_Refreshing = false;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount5 = 5;
            nRcdExists_5 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart045( ) ;
               while ( RcdFound5 != 0 )
               {
                  sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_435( ) ;
                  init_level_properties5( ) ;
                  standaloneNotModal045( ) ;
                  getByPrimaryKey045( ) ;
                  standaloneModal045( ) ;
                  AddRow045( ) ;
                  ScanNext045( ) ;
               }
               ScanEnd045( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode5 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx+1), 4, 0), 4, "0");
         SubsflControlProps_435( ) ;
         InitAll045( ) ;
         init_level_properties5( ) ;
         nRcdExists_5 = 0;
         nIsMod_5 = 0;
         nRcdDeleted_5 = 0;
         nBlankRcdCount5 = (short)(nBlankRcdUsr5+nBlankRcdCount5);
         fRowAdded = 0;
         while ( nBlankRcdCount5 > 0 )
         {
            standaloneNotModal045( ) ;
            standaloneModal045( ) ;
            AddRow045( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtSecFunctionalityId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount5 = (short)(nBlankRcdCount5-1);
         }
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridsecobject_functionalitiesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsecobject_functionalities", Gridsecobject_functionalitiesContainer, subGridsecobject_functionalities_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridsecobject_functionalitiesContainerData", Gridsecobject_functionalitiesContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridsecobject_functionalitiesContainerData"+"V", Gridsecobject_functionalitiesContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridsecobject_functionalitiesContainerData"+"V"+"\" value='"+Gridsecobject_functionalitiesContainer.GridValuesHidden()+"'/>") ;
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
            Z17SecObjectName = cgiGet( "Z17SecObjectName");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A17SecObjectName = cgiGet( edtSecObjectName_Internalname);
            AssignAttri("", false, "A17SecObjectName", A17SecObjectName);
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
               A17SecObjectName = GetPar( "SecObjectName");
               AssignAttri("", false, "A17SecObjectName", A17SecObjectName);
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
               InitAll044( ) ;
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
         DisableAttributes044( ) ;
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

      protected void CONFIRM_045( )
      {
         nGXsfl_43_idx = 0;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            ReadRow045( ) ;
            if ( ( nRcdExists_5 != 0 ) || ( nIsMod_5 != 0 ) )
            {
               GetKey045( ) ;
               if ( ( nRcdExists_5 == 0 ) && ( nRcdDeleted_5 == 0 ) )
               {
                  if ( RcdFound5 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate045( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable045( ) ;
                        CloseExtendedTableCursors045( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "SECFUNCTIONALITYID_" + sGXsfl_43_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtSecFunctionalityId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound5 != 0 )
                  {
                     if ( nRcdDeleted_5 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey045( ) ;
                        Load045( ) ;
                        BeforeValidate045( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls045( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_5 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate045( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable045( ) ;
                              CloseExtendedTableCursors045( ) ;
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
                     if ( nRcdDeleted_5 == 0 )
                     {
                        GXCCtl = "SECFUNCTIONALITYID_" + sGXsfl_43_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtSecFunctionalityId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtSecFunctionalityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SecFunctionalityId), 10, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtSecFunctionalityDescription_Internalname, A20SecFunctionalityDescription) ;
            ChangePostValue( "ZT_"+"Z13SecFunctionalityId_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13SecFunctionalityId), 10, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_5_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_5_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_5_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_5 != 0 )
            {
               ChangePostValue( "SECFUNCTIONALITYID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityDescription_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption040( )
      {
      }

      protected void ZM044( short GX_JID )
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
            Z17SecObjectName = A17SecObjectName;
         }
      }

      protected void standaloneNotModal( )
      {
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

      protected void Load044( )
      {
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A17SecObjectName});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound4 = 1;
            ZM044( -1) ;
         }
         pr_default.close(5);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
      }

      protected void CheckExtendedTable044( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors044( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey044( )
      {
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {A17SecObjectName});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {A17SecObjectName});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM044( 1) ;
            RcdFound4 = 1;
            A17SecObjectName = T00046_A17SecObjectName[0];
            AssignAttri("", false, "A17SecObjectName", A17SecObjectName);
            Z17SecObjectName = A17SecObjectName;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
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
         RcdFound4 = 0;
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A17SecObjectName});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00049_A17SecObjectName[0], A17SecObjectName) < 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00049_A17SecObjectName[0], A17SecObjectName) > 0 ) ) )
            {
               A17SecObjectName = T00049_A17SecObjectName[0];
               AssignAttri("", false, "A17SecObjectName", A17SecObjectName);
               RcdFound4 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T000410 */
         pr_default.execute(8, new Object[] {A17SecObjectName});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000410_A17SecObjectName[0], A17SecObjectName) > 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000410_A17SecObjectName[0], A17SecObjectName) < 0 ) ) )
            {
               A17SecObjectName = T000410_A17SecObjectName[0];
               AssignAttri("", false, "A17SecObjectName", A17SecObjectName);
               RcdFound4 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSecObjectName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert044( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( StringUtil.StrCmp(A17SecObjectName, Z17SecObjectName) != 0 )
               {
                  A17SecObjectName = Z17SecObjectName;
                  AssignAttri("", false, "A17SecObjectName", A17SecObjectName);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SECOBJECTNAME");
                  AnyError = 1;
                  GX_FocusControl = edtSecObjectName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSecObjectName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update044( ) ;
                  GX_FocusControl = edtSecObjectName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A17SecObjectName, Z17SecObjectName) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSecObjectName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert044( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SECOBJECTNAME");
                     AnyError = 1;
                     GX_FocusControl = edtSecObjectName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSecObjectName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert044( ) ;
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
         if ( StringUtil.StrCmp(A17SecObjectName, Z17SecObjectName) != 0 )
         {
            A17SecObjectName = Z17SecObjectName;
            AssignAttri("", false, "A17SecObjectName", A17SecObjectName);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SECOBJECTNAME");
            AnyError = 1;
            GX_FocusControl = edtSecObjectName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSecObjectName_Internalname;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SECOBJECTNAME");
            AnyError = 1;
            GX_FocusControl = edtSecObjectName_Internalname;
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
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd044( ) ;
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
         if ( RcdFound4 == 0 )
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
         if ( RcdFound4 == 0 )
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
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound4 != 0 )
            {
               ScanNext044( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd044( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00045 */
            pr_default.execute(3, new Object[] {A17SecObjectName});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecObject"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecObject"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000411 */
                     pr_default.execute(9, new Object[] {A17SecObjectName});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("SecObject");
                     if ( (pr_default.getStatus(9) == 1) )
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
                           ProcessLevel044( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption040( ) ;
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [SecObject] */
                     DeferredUpdate044( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel044( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption040( ) ;
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart045( ) ;
                  while ( RcdFound5 != 0 )
                  {
                     getByPrimaryKey045( ) ;
                     Delete045( ) ;
                     ScanNext045( ) ;
                  }
                  ScanEnd045( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000412 */
                     pr_default.execute(10, new Object[] {A17SecObjectName});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SecObject");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound4 == 0 )
                           {
                              InitAll044( ) ;
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
                           ResetCaption040( ) ;
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel044( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel045( )
      {
         nGXsfl_43_idx = 0;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            ReadRow045( ) ;
            if ( ( nRcdExists_5 != 0 ) || ( nIsMod_5 != 0 ) )
            {
               standaloneNotModal045( ) ;
               GetKey045( ) ;
               if ( ( nRcdExists_5 == 0 ) && ( nRcdDeleted_5 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert045( ) ;
               }
               else
               {
                  if ( RcdFound5 != 0 )
                  {
                     if ( ( nRcdDeleted_5 != 0 ) && ( nRcdExists_5 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete045( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_5 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update045( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_5 == 0 )
                     {
                        GXCCtl = "SECFUNCTIONALITYID_" + sGXsfl_43_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtSecFunctionalityId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtSecFunctionalityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SecFunctionalityId), 10, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtSecFunctionalityDescription_Internalname, A20SecFunctionalityDescription) ;
            ChangePostValue( "ZT_"+"Z13SecFunctionalityId_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13SecFunctionalityId), 10, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_5_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_5_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_5_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_5 != 0 )
            {
               ChangePostValue( "SECFUNCTIONALITYID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityDescription_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll045( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_5 = 0;
         nIsMod_5 = 0;
         nRcdDeleted_5 = 0;
      }

      protected void ProcessLevel044( )
      {
         /* Save parent mode. */
         sMode4 = Gx_mode;
         ProcessNestedLevel045( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("wwpbaseobjects.secobject",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("wwpbaseobjects.secobject",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart044( )
      {
         /* Using cursor T000413 */
         pr_default.execute(11);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound4 = 1;
            A17SecObjectName = T000413_A17SecObjectName[0];
            AssignAttri("", false, "A17SecObjectName", A17SecObjectName);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound4 = 1;
            A17SecObjectName = T000413_A17SecObjectName[0];
            AssignAttri("", false, "A17SecObjectName", A17SecObjectName);
         }
      }

      protected void ScanEnd044( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
         edtSecObjectName_Enabled = 0;
         AssignProp("", false, edtSecObjectName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecObjectName_Enabled), 5, 0), true);
      }

      protected void ZM045( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -2 )
         {
            Z17SecObjectName = A17SecObjectName;
            Z13SecFunctionalityId = A13SecFunctionalityId;
            Z20SecFunctionalityDescription = A20SecFunctionalityDescription;
         }
      }

      protected void standaloneNotModal045( )
      {
      }

      protected void standaloneModal045( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtSecFunctionalityId_Enabled = 0;
            AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         }
         else
         {
            edtSecFunctionalityId_Enabled = 1;
            AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         }
      }

      protected void Load045( )
      {
         /* Using cursor T000414 */
         pr_default.execute(12, new Object[] {A17SecObjectName, A13SecFunctionalityId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound5 = 1;
            A20SecFunctionalityDescription = T000414_A20SecFunctionalityDescription[0];
            ZM045( -2) ;
         }
         pr_default.close(12);
         OnLoadActions045( ) ;
      }

      protected void OnLoadActions045( )
      {
      }

      protected void CheckExtendedTable045( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         standaloneModal045( ) ;
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A13SecFunctionalityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "SECFUNCTIONALITYID_" + sGXsfl_43_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Functionality", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A20SecFunctionalityDescription = T00044_A20SecFunctionalityDescription[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors045( )
      {
         pr_default.close(2);
      }

      protected void enableDisable045( )
      {
      }

      protected void gxLoad_3( long A13SecFunctionalityId )
      {
         /* Using cursor T000415 */
         pr_default.execute(13, new Object[] {A13SecFunctionalityId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GXCCtl = "SECFUNCTIONALITYID_" + sGXsfl_43_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Functionality", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A20SecFunctionalityDescription = T000415_A20SecFunctionalityDescription[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A20SecFunctionalityDescription)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void GetKey045( )
      {
         /* Using cursor T000416 */
         pr_default.execute(14, new Object[] {A17SecObjectName, A13SecFunctionalityId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey045( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A17SecObjectName, A13SecFunctionalityId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM045( 2) ;
            RcdFound5 = 1;
            InitializeNonKey045( ) ;
            A13SecFunctionalityId = T00043_A13SecFunctionalityId[0];
            Z17SecObjectName = A17SecObjectName;
            Z13SecFunctionalityId = A13SecFunctionalityId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal045( ) ;
            Load045( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey045( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal045( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes045( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency045( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A17SecObjectName, A13SecFunctionalityId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecObjectFunctionalities"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecObjectFunctionalities"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert045( )
      {
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable045( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM045( 0) ;
            CheckOptimisticConcurrency045( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm045( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert045( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000417 */
                     pr_default.execute(15, new Object[] {A17SecObjectName, A13SecFunctionalityId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("SecObjectFunctionalities");
                     if ( (pr_default.getStatus(15) == 1) )
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
               Load045( ) ;
            }
            EndLevel045( ) ;
         }
         CloseExtendedTableCursors045( ) ;
      }

      protected void Update045( )
      {
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable045( ) ;
         }
         if ( ( nIsMod_5 != 0 ) || ( nIsDirty_5 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency045( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm045( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate045( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [SecObjectFunctionalities] */
                        DeferredUpdate045( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey045( ) ;
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
               EndLevel045( ) ;
            }
         }
         CloseExtendedTableCursors045( ) ;
      }

      protected void DeferredUpdate045( )
      {
      }

      protected void Delete045( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency045( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls045( ) ;
            AfterConfirm045( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete045( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000418 */
                  pr_default.execute(16, new Object[] {A17SecObjectName, A13SecFunctionalityId});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("SecObjectFunctionalities");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel045( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls045( )
      {
         standaloneModal045( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000419 */
            pr_default.execute(17, new Object[] {A13SecFunctionalityId});
            A20SecFunctionalityDescription = T000419_A20SecFunctionalityDescription[0];
            pr_default.close(17);
         }
      }

      protected void EndLevel045( )
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

      public void ScanStart045( )
      {
         /* Scan By routine */
         /* Using cursor T000420 */
         pr_default.execute(18, new Object[] {A17SecObjectName});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound5 = 1;
            A13SecFunctionalityId = T000420_A13SecFunctionalityId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext045( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound5 = 1;
            A13SecFunctionalityId = T000420_A13SecFunctionalityId[0];
         }
      }

      protected void ScanEnd045( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm045( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert045( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate045( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete045( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete045( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate045( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes045( )
      {
         edtSecFunctionalityId_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtSecFunctionalityDescription_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityDescription_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void send_integrity_lvl_hashes045( )
      {
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void SubsflControlProps_435( )
      {
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_43_idx;
         imgprompt_13_Internalname = "PROMPT_13_"+sGXsfl_43_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_435( )
      {
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_43_fel_idx;
         imgprompt_13_Internalname = "PROMPT_13_"+sGXsfl_43_fel_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_43_fel_idx;
      }

      protected void AddRow045( )
      {
         nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_435( ) ;
         SendRow045( ) ;
      }

      protected void SendRow045( )
      {
         Gridsecobject_functionalitiesRow = GXWebRow.GetNew(context);
         if ( subGridsecobject_functionalities_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridsecobject_functionalities_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridsecobject_functionalities_Class, "") != 0 )
            {
               subGridsecobject_functionalities_Linesclass = subGridsecobject_functionalities_Class+"Odd";
            }
         }
         else if ( subGridsecobject_functionalities_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridsecobject_functionalities_Backstyle = 0;
            subGridsecobject_functionalities_Backcolor = subGridsecobject_functionalities_Allbackcolor;
            if ( StringUtil.StrCmp(subGridsecobject_functionalities_Class, "") != 0 )
            {
               subGridsecobject_functionalities_Linesclass = subGridsecobject_functionalities_Class+"Uniform";
            }
         }
         else if ( subGridsecobject_functionalities_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridsecobject_functionalities_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridsecobject_functionalities_Class, "") != 0 )
            {
               subGridsecobject_functionalities_Linesclass = subGridsecobject_functionalities_Class+"Odd";
            }
            subGridsecobject_functionalities_Backcolor = (int)(0x0);
         }
         else if ( subGridsecobject_functionalities_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridsecobject_functionalities_Backstyle = 1;
            if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
            {
               subGridsecobject_functionalities_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridsecobject_functionalities_Class, "") != 0 )
               {
                  subGridsecobject_functionalities_Linesclass = subGridsecobject_functionalities_Class+"Even";
               }
            }
            else
            {
               subGridsecobject_functionalities_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridsecobject_functionalities_Class, "") != 0 )
               {
                  subGridsecobject_functionalities_Linesclass = subGridsecobject_functionalities_Class+"Odd";
               }
            }
         }
         imgprompt_13_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SECFUNCTIONALITYID_"+sGXsfl_43_idx+"'), id:'"+"SECFUNCTIONALITYID_"+sGXsfl_43_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_5_"+sGXsfl_43_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_5_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Gridsecobject_functionalitiesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SecFunctionalityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A13SecFunctionalityId), "ZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSecFunctionalityId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_13_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_13_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridsecobject_functionalitiesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_13_Internalname,(string)sImgUrl,(string)imgprompt_13_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_13_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_5_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Gridsecobject_functionalitiesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityDescription_Internalname,(string)A20SecFunctionalityDescription,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSecFunctionalityDescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridsecobject_functionalitiesRow);
         send_integrity_lvl_hashes045( ) ;
         GXCCtl = "Z13SecFunctionalityId_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13SecFunctionalityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_5_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_5_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_5_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityDescription_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_13_"+sGXsfl_43_idx+"Link", StringUtil.RTrim( imgprompt_13_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridsecobject_functionalitiesContainer.AddRow(Gridsecobject_functionalitiesRow);
      }

      protected void ReadRow045( )
      {
         nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_435( ) ;
         edtSecFunctionalityId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECFUNCTIONALITYID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSecFunctionalityDescription_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_13_Link = cgiGet( "PROMPT_13_"+sGXsfl_43_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
         {
            GXCCtl = "SECFUNCTIONALITYID_" + sGXsfl_43_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
            wbErr = true;
            A13SecFunctionalityId = 0;
         }
         else
         {
            A13SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A20SecFunctionalityDescription = cgiGet( edtSecFunctionalityDescription_Internalname);
         GXCCtl = "Z13SecFunctionalityId_" + sGXsfl_43_idx;
         Z13SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_5_" + sGXsfl_43_idx;
         nRcdDeleted_5 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_5_" + sGXsfl_43_idx;
         nRcdExists_5 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_5_" + sGXsfl_43_idx;
         nIsMod_5 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtSecFunctionalityId_Enabled = edtSecFunctionalityId_Enabled;
      }

      protected void ConfirmValues040( )
      {
         nGXsfl_43_idx = 0;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_435( ) ;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_435( ) ;
            ChangePostValue( "Z13SecFunctionalityId_"+sGXsfl_43_idx, cgiGet( "ZT_"+"Z13SecFunctionalityId_"+sGXsfl_43_idx)) ;
            DeletePostValue( "ZT_"+"Z13SecFunctionalityId_"+sGXsfl_43_idx) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.secobject.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z17SecObjectName", Z17SecObjectName);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_43_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("wwpbaseobjects.secobject.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SecObject" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Sec Object", "") ;
      }

      protected void InitializeNonKey044( )
      {
      }

      protected void InitAll044( )
      {
         A17SecObjectName = "";
         AssignAttri("", false, "A17SecObjectName", A17SecObjectName);
         InitializeNonKey044( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey045( )
      {
         A20SecFunctionalityDescription = "";
      }

      protected void InitAll045( )
      {
         A13SecFunctionalityId = 0;
         InitializeNonKey045( ) ;
      }

      protected void StandaloneModalInsert045( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302182319", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/secobject.js", "?20267302182319", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties5( )
      {
         edtSecFunctionalityId_Enabled = defedtSecFunctionalityId_Enabled;
         AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void StartGridControl43( )
      {
         Gridsecobject_functionalitiesContainer.AddObjectProperty("GridName", "Gridsecobject_functionalities");
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Header", subGridsecobject_functionalities_Header);
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Class", "Grid");
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Backcolorstyle), 1, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("CmpContext", "");
         Gridsecobject_functionalitiesContainer.AddObjectProperty("InMasterPage", "false");
         Gridsecobject_functionalitiesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsecobject_functionalitiesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SecFunctionalityId), 10, 0, ".", ""))));
         Gridsecobject_functionalitiesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityId_Enabled), 5, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddColumnProperties(Gridsecobject_functionalitiesColumn);
         Gridsecobject_functionalitiesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsecobject_functionalitiesContainer.AddColumnProperties(Gridsecobject_functionalitiesColumn);
         Gridsecobject_functionalitiesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsecobject_functionalitiesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A20SecFunctionalityDescription));
         Gridsecobject_functionalitiesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityDescription_Enabled), 5, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddColumnProperties(Gridsecobject_functionalitiesColumn);
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Selectedindex), 4, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Allowselection), 1, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Selectioncolor), 9, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Allowhovering), 1, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Hoveringcolor), 9, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Allowcollapsing), 1, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Collapsed), 1, 0, ".", "")));
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
         edtSecObjectName_Internalname = "SECOBJECTNAME";
         lblTitlefunctionalities_Internalname = "TITLEFUNCTIONALITIES";
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID";
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION";
         divFunctionalitiestable_Internalname = "FUNCTIONALITIESTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_13_Internalname = "PROMPT_13";
         subGridsecobject_functionalities_Internalname = "GRIDSECOBJECT_FUNCTIONALITIES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridsecobject_functionalities_Allowcollapsing = 0;
         subGridsecobject_functionalities_Allowselection = 0;
         subGridsecobject_functionalities_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Sec Object", "");
         edtSecFunctionalityDescription_Jsonclick = "";
         imgprompt_13_Visible = 1;
         imgprompt_13_Link = "";
         imgprompt_13_Visible = 1;
         edtSecFunctionalityId_Jsonclick = "";
         subGridsecobject_functionalities_Class = "Grid";
         subGridsecobject_functionalities_Backcolorstyle = 0;
         edtSecFunctionalityDescription_Enabled = 0;
         edtSecFunctionalityId_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSecObjectName_Jsonclick = "";
         edtSecObjectName_Enabled = 1;
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

      protected void gxnrGridsecobject_functionalities_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_435( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal045( ) ;
            standaloneModal045( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow045( ) ;
            nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_435( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridsecobject_functionalitiesContainer)) ;
         /* End function gxnrGridsecobject_functionalities_newrow */
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

      public void Valid_Secobjectname( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z17SecObjectName", Z17SecObjectName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Secfunctionalityid( )
      {
         /* Using cursor T000419 */
         pr_default.execute(17, new Object[] {A13SecFunctionalityId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Functionality", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECFUNCTIONALITYID");
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
         }
         A20SecFunctionalityDescription = T000419_A20SecFunctionalityDescription[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A20SecFunctionalityDescription", A20SecFunctionalityDescription);
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
         setEventMetadata("VALID_SECOBJECTNAME","{handler:'Valid_Secobjectname',iparms:[{av:'A17SecObjectName',fld:'SECOBJECTNAME',pic:'',type:'svchar'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'}]");
         setEventMetadata("VALID_SECOBJECTNAME",",oparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z17SecObjectName',type:'svchar'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_SECFUNCTIONALITYID","{handler:'Valid_Secfunctionalityid',iparms:[{av:'A13SecFunctionalityId',fld:'SECFUNCTIONALITYID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A20SecFunctionalityDescription',fld:'SECFUNCTIONALITYDESCRIPTION',pic:'',type:'svchar'}]");
         setEventMetadata("VALID_SECFUNCTIONALITYID",",oparms:[{av:'A20SecFunctionalityDescription',fld:'SECFUNCTIONALITYDESCRIPTION',pic:'',type:'svchar'}]}");
         setEventMetadata("NULL","{handler:'Valid_Secfunctionalitydescription',iparms:[]");
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
         pr_default.close(17);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z17SecObjectName = "";
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
         A17SecObjectName = "";
         lblTitlefunctionalities_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridsecobject_functionalitiesContainer = new GXWebGrid( context);
         sMode5 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A20SecFunctionalityDescription = "";
         T00047_A17SecObjectName = new string[] {""} ;
         T00048_A17SecObjectName = new string[] {""} ;
         T00046_A17SecObjectName = new string[] {""} ;
         sMode4 = "";
         T00049_A17SecObjectName = new string[] {""} ;
         T000410_A17SecObjectName = new string[] {""} ;
         T00045_A17SecObjectName = new string[] {""} ;
         T000413_A17SecObjectName = new string[] {""} ;
         Z20SecFunctionalityDescription = "";
         T000414_A17SecObjectName = new string[] {""} ;
         T000414_A20SecFunctionalityDescription = new string[] {""} ;
         T000414_A13SecFunctionalityId = new long[1] ;
         T00044_A20SecFunctionalityDescription = new string[] {""} ;
         T000415_A20SecFunctionalityDescription = new string[] {""} ;
         T000416_A17SecObjectName = new string[] {""} ;
         T000416_A13SecFunctionalityId = new long[1] ;
         T00043_A17SecObjectName = new string[] {""} ;
         T00043_A13SecFunctionalityId = new long[1] ;
         T00042_A17SecObjectName = new string[] {""} ;
         T00042_A13SecFunctionalityId = new long[1] ;
         T000419_A20SecFunctionalityDescription = new string[] {""} ;
         T000420_A17SecObjectName = new string[] {""} ;
         T000420_A13SecFunctionalityId = new long[1] ;
         Gridsecobject_functionalitiesRow = new GXWebRow();
         subGridsecobject_functionalities_Linesclass = "";
         ROClassString = "";
         imgprompt_13_gximage = "";
         sImgUrl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridsecobject_functionalitiesColumn = new GXWebColumn();
         ZZ17SecObjectName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secobject__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secobject__default(),
            new Object[][] {
                new Object[] {
               T00042_A17SecObjectName, T00042_A13SecFunctionalityId
               }
               , new Object[] {
               T00043_A17SecObjectName, T00043_A13SecFunctionalityId
               }
               , new Object[] {
               T00044_A20SecFunctionalityDescription
               }
               , new Object[] {
               T00045_A17SecObjectName
               }
               , new Object[] {
               T00046_A17SecObjectName
               }
               , new Object[] {
               T00047_A17SecObjectName
               }
               , new Object[] {
               T00048_A17SecObjectName
               }
               , new Object[] {
               T00049_A17SecObjectName
               }
               , new Object[] {
               T000410_A17SecObjectName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000413_A17SecObjectName
               }
               , new Object[] {
               T000414_A17SecObjectName, T000414_A20SecFunctionalityDescription, T000414_A13SecFunctionalityId
               }
               , new Object[] {
               T000415_A20SecFunctionalityDescription
               }
               , new Object[] {
               T000416_A17SecObjectName, T000416_A13SecFunctionalityId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000419_A20SecFunctionalityDescription
               }
               , new Object[] {
               T000420_A17SecObjectName, T000420_A13SecFunctionalityId
               }
            }
         );
      }

      private short nIsMod_5 ;
      private short nRcdDeleted_5 ;
      private short nRcdExists_5 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount5 ;
      private short RcdFound5 ;
      private short nBlankRcdUsr5 ;
      private short RcdFound4 ;
      private short Gx_BScreen ;
      private short nIsDirty_5 ;
      private short subGridsecobject_functionalities_Backcolorstyle ;
      private short subGridsecobject_functionalities_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridsecobject_functionalities_Allowselection ;
      private short subGridsecobject_functionalities_Allowhovering ;
      private short subGridsecobject_functionalities_Allowcollapsing ;
      private short subGridsecobject_functionalities_Collapsed ;
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSecObjectName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtSecFunctionalityId_Enabled ;
      private int edtSecFunctionalityDescription_Enabled ;
      private int fRowAdded ;
      private int subGridsecobject_functionalities_Backcolor ;
      private int subGridsecobject_functionalities_Allbackcolor ;
      private int imgprompt_13_Visible ;
      private int defedtSecFunctionalityId_Enabled ;
      private int idxLst ;
      private int subGridsecobject_functionalities_Selectedindex ;
      private int subGridsecobject_functionalities_Selectioncolor ;
      private int subGridsecobject_functionalities_Hoveringcolor ;
      private long Z13SecFunctionalityId ;
      private long A13SecFunctionalityId ;
      private long GRIDSECOBJECT_FUNCTIONALITIES_nFirstRecordOnPage ;
      private string sPrefix ;
      private string sGXsfl_43_idx="0001" ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSecObjectName_Internalname ;
      private string Gx_mode ;
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
      private string edtSecObjectName_Jsonclick ;
      private string divFunctionalitiestable_Internalname ;
      private string lblTitlefunctionalities_Internalname ;
      private string lblTitlefunctionalities_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode5 ;
      private string edtSecFunctionalityId_Internalname ;
      private string edtSecFunctionalityDescription_Internalname ;
      private string imgprompt_13_Link ;
      private string sStyleString ;
      private string subGridsecobject_functionalities_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode4 ;
      private string imgprompt_13_Internalname ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string subGridsecobject_functionalities_Class ;
      private string subGridsecobject_functionalities_Linesclass ;
      private string ROClassString ;
      private string edtSecFunctionalityId_Jsonclick ;
      private string imgprompt_13_gximage ;
      private string sImgUrl ;
      private string edtSecFunctionalityDescription_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridsecobject_functionalities_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_43_Refreshing=false ;
      private string Z17SecObjectName ;
      private string A17SecObjectName ;
      private string A20SecFunctionalityDescription ;
      private string Z20SecFunctionalityDescription ;
      private string ZZ17SecObjectName ;
      private GXWebGrid Gridsecobject_functionalitiesContainer ;
      private GXWebRow Gridsecobject_functionalitiesRow ;
      private GXWebColumn Gridsecobject_functionalitiesColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00047_A17SecObjectName ;
      private string[] T00048_A17SecObjectName ;
      private string[] T00046_A17SecObjectName ;
      private string[] T00049_A17SecObjectName ;
      private string[] T000410_A17SecObjectName ;
      private string[] T00045_A17SecObjectName ;
      private string[] T000413_A17SecObjectName ;
      private string[] T000414_A17SecObjectName ;
      private string[] T000414_A20SecFunctionalityDescription ;
      private long[] T000414_A13SecFunctionalityId ;
      private string[] T00044_A20SecFunctionalityDescription ;
      private string[] T000415_A20SecFunctionalityDescription ;
      private string[] T000416_A17SecObjectName ;
      private long[] T000416_A13SecFunctionalityId ;
      private string[] T00043_A17SecObjectName ;
      private long[] T00043_A13SecFunctionalityId ;
      private string[] T00042_A17SecObjectName ;
      private long[] T00042_A13SecFunctionalityId ;
      private string[] T000419_A20SecFunctionalityDescription ;
      private string[] T000420_A17SecObjectName ;
      private long[] T000420_A13SecFunctionalityId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class secobject__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class secobject__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00042;
        prmT00042 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0) ,
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT00043;
        prmT00043 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0) ,
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT00044;
        prmT00044 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT00045;
        prmT00045 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0)
        };
        Object[] prmT00046;
        prmT00046 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0)
        };
        Object[] prmT00047;
        prmT00047 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0)
        };
        Object[] prmT00048;
        prmT00048 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0)
        };
        Object[] prmT00049;
        prmT00049 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0)
        };
        Object[] prmT000410;
        prmT000410 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0)
        };
        Object[] prmT000411;
        prmT000411 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0)
        };
        Object[] prmT000412;
        prmT000412 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0)
        };
        Object[] prmT000413;
        prmT000413 = new Object[] {
        };
        Object[] prmT000414;
        prmT000414 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0) ,
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT000415;
        prmT000415 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT000416;
        prmT000416 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0) ,
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT000417;
        prmT000417 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0) ,
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT000418;
        prmT000418 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0) ,
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT000419;
        prmT000419 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT000420;
        prmT000420 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00042", "SELECT [SecObjectName], [SecFunctionalityId] FROM [SecObjectFunctionalities] WITH (UPDLOCK) WHERE [SecObjectName] = @SecObjectName AND [SecFunctionalityId] = @SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00043", "SELECT [SecObjectName], [SecFunctionalityId] FROM [SecObjectFunctionalities] WHERE [SecObjectName] = @SecObjectName AND [SecFunctionalityId] = @SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00044", "SELECT [SecFunctionalityDescription] FROM [SecFunctionality] WHERE [SecFunctionalityId] = @SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00045", "SELECT [SecObjectName] FROM [SecObject] WITH (UPDLOCK) WHERE [SecObjectName] = @SecObjectName ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00046", "SELECT [SecObjectName] FROM [SecObject] WHERE [SecObjectName] = @SecObjectName ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00047", "SELECT TM1.[SecObjectName] FROM [SecObject] TM1 WHERE TM1.[SecObjectName] = @SecObjectName ORDER BY TM1.[SecObjectName]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00048", "SELECT [SecObjectName] FROM [SecObject] WHERE [SecObjectName] = @SecObjectName  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00049", "SELECT TOP 1 [SecObjectName] FROM [SecObject] WHERE ( [SecObjectName] > @SecObjectName) ORDER BY [SecObjectName]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000410", "SELECT TOP 1 [SecObjectName] FROM [SecObject] WHERE ( [SecObjectName] < @SecObjectName) ORDER BY [SecObjectName] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000411", "INSERT INTO [SecObject]([SecObjectName]) VALUES(@SecObjectName)", GxErrorMask.GX_NOMASK,prmT000411)
           ,new CursorDef("T000412", "DELETE FROM [SecObject]  WHERE [SecObjectName] = @SecObjectName", GxErrorMask.GX_NOMASK,prmT000412)
           ,new CursorDef("T000413", "SELECT [SecObjectName] FROM [SecObject] ORDER BY [SecObjectName]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000413,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000414", "SELECT T1.[SecObjectName], T2.[SecFunctionalityDescription], T1.[SecFunctionalityId] FROM ([SecObjectFunctionalities] T1 INNER JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = T1.[SecFunctionalityId]) WHERE T1.[SecObjectName] = @SecObjectName and T1.[SecFunctionalityId] = @SecFunctionalityId ORDER BY T1.[SecObjectName], T1.[SecFunctionalityId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000414,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000415", "SELECT [SecFunctionalityDescription] FROM [SecFunctionality] WHERE [SecFunctionalityId] = @SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000415,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000416", "SELECT [SecObjectName], [SecFunctionalityId] FROM [SecObjectFunctionalities] WHERE [SecObjectName] = @SecObjectName AND [SecFunctionalityId] = @SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000416,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000417", "INSERT INTO [SecObjectFunctionalities]([SecObjectName], [SecFunctionalityId]) VALUES(@SecObjectName, @SecFunctionalityId)", GxErrorMask.GX_NOMASK,prmT000417)
           ,new CursorDef("T000418", "DELETE FROM [SecObjectFunctionalities]  WHERE [SecObjectName] = @SecObjectName AND [SecFunctionalityId] = @SecFunctionalityId", GxErrorMask.GX_NOMASK,prmT000418)
           ,new CursorDef("T000419", "SELECT [SecFunctionalityDescription] FROM [SecFunctionality] WHERE [SecFunctionalityId] = @SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000419,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000420", "SELECT [SecObjectName], [SecFunctionalityId] FROM [SecObjectFunctionalities] WHERE [SecObjectName] = @SecObjectName ORDER BY [SecObjectName], [SecFunctionalityId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000420,11, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
  }

}

}
