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
namespace GeneXus.Programs {
   public class moneda : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         Form.Meta.addItem("description", context.GetMessage( "Moneda", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMonedaNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public moneda( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public moneda( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Moneda", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Moneda.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Moneda.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Moneda.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Moneda.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Moneda.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00x0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MONEDAID"+"'), id:'"+"MONEDAID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Moneda.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMonedaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMonedaId_Internalname, context.GetMessage( "Moneda", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonedaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtMonedaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A118MonedaId), "ZZZ9") : context.localUtil.Format( (decimal)(A118MonedaId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonedaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMonedaId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Moneda.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMonedaNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMonedaNombre_Internalname, context.GetMessage( "Moneda", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonedaNombre_Internalname, StringUtil.RTrim( A187MonedaNombre), StringUtil.RTrim( context.localUtil.Format( A187MonedaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonedaNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMonedaNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Moneda.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMonedaISOSimbolo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMonedaISOSimbolo_Internalname, context.GetMessage( "ISO", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonedaISOSimbolo_Internalname, StringUtil.RTrim( A119MonedaISOSimbolo), StringUtil.RTrim( context.localUtil.Format( A119MonedaISOSimbolo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonedaISOSimbolo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMonedaISOSimbolo_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "MonISO", "start", true, "", "HLP_Moneda.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Moneda.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Moneda.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Moneda.htm");
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
            Z118MonedaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z118MonedaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z187MonedaNombre = cgiGet( "Z187MonedaNombre");
            Z119MonedaISOSimbolo = cgiGet( "Z119MonedaISOSimbolo");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A118MonedaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMonedaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n118MonedaId = false;
            AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
            A187MonedaNombre = cgiGet( edtMonedaNombre_Internalname);
            AssignAttri("", false, "A187MonedaNombre", A187MonedaNombre);
            A119MonedaISOSimbolo = cgiGet( edtMonedaISOSimbolo_Internalname);
            AssignAttri("", false, "A119MonedaISOSimbolo", A119MonedaISOSimbolo);
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
               A118MonedaId = (short)(Math.Round(NumberUtil.Val( GetPar( "MonedaId"), "."), 18, MidpointRounding.ToEven));
               n118MonedaId = false;
               AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
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
               InitAll0R33( ) ;
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
         DisableAttributes0R33( ) ;
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

      protected void ResetCaption0R0( )
      {
      }

      protected void ZM0R33( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z187MonedaNombre = T000R3_A187MonedaNombre[0];
               Z119MonedaISOSimbolo = T000R3_A119MonedaISOSimbolo[0];
            }
            else
            {
               Z187MonedaNombre = A187MonedaNombre;
               Z119MonedaISOSimbolo = A119MonedaISOSimbolo;
            }
         }
         if ( GX_JID == -2 )
         {
            Z118MonedaId = A118MonedaId;
            Z187MonedaNombre = A187MonedaNombre;
            Z119MonedaISOSimbolo = A119MonedaISOSimbolo;
         }
      }

      protected void standaloneNotModal( )
      {
         edtMonedaId_Enabled = 0;
         AssignProp("", false, edtMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonedaId_Enabled), 5, 0), true);
         edtMonedaId_Enabled = 0;
         AssignProp("", false, edtMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonedaId_Enabled), 5, 0), true);
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

      protected void Load0R33( )
      {
         /* Using cursor T000R4 */
         pr_default.execute(2, new Object[] {n118MonedaId, A118MonedaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound33 = 1;
            A187MonedaNombre = T000R4_A187MonedaNombre[0];
            AssignAttri("", false, "A187MonedaNombre", A187MonedaNombre);
            A119MonedaISOSimbolo = T000R4_A119MonedaISOSimbolo[0];
            AssignAttri("", false, "A119MonedaISOSimbolo", A119MonedaISOSimbolo);
            ZM0R33( -2) ;
         }
         pr_default.close(2);
         OnLoadActions0R33( ) ;
      }

      protected void OnLoadActions0R33( )
      {
      }

      protected void CheckExtendedTable0R33( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0R33( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0R33( )
      {
         /* Using cursor T000R5 */
         pr_default.execute(3, new Object[] {n118MonedaId, A118MonedaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound33 = 1;
         }
         else
         {
            RcdFound33 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000R3 */
         pr_default.execute(1, new Object[] {n118MonedaId, A118MonedaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0R33( 2) ;
            RcdFound33 = 1;
            A118MonedaId = T000R3_A118MonedaId[0];
            n118MonedaId = T000R3_n118MonedaId[0];
            AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
            A187MonedaNombre = T000R3_A187MonedaNombre[0];
            AssignAttri("", false, "A187MonedaNombre", A187MonedaNombre);
            A119MonedaISOSimbolo = T000R3_A119MonedaISOSimbolo[0];
            AssignAttri("", false, "A119MonedaISOSimbolo", A119MonedaISOSimbolo);
            Z118MonedaId = A118MonedaId;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0R33( ) ;
            if ( AnyError == 1 )
            {
               RcdFound33 = 0;
               InitializeNonKey0R33( ) ;
            }
            Gx_mode = sMode33;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound33 = 0;
            InitializeNonKey0R33( ) ;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode33;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0R33( ) ;
         if ( RcdFound33 == 0 )
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
         RcdFound33 = 0;
         /* Using cursor T000R6 */
         pr_default.execute(4, new Object[] {n118MonedaId, A118MonedaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000R6_A118MonedaId[0] < A118MonedaId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000R6_A118MonedaId[0] > A118MonedaId ) ) )
            {
               A118MonedaId = T000R6_A118MonedaId[0];
               n118MonedaId = T000R6_n118MonedaId[0];
               AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
               RcdFound33 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound33 = 0;
         /* Using cursor T000R7 */
         pr_default.execute(5, new Object[] {n118MonedaId, A118MonedaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000R7_A118MonedaId[0] > A118MonedaId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000R7_A118MonedaId[0] < A118MonedaId ) ) )
            {
               A118MonedaId = T000R7_A118MonedaId[0];
               n118MonedaId = T000R7_n118MonedaId[0];
               AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
               RcdFound33 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0R33( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMonedaNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0R33( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound33 == 1 )
            {
               if ( A118MonedaId != Z118MonedaId )
               {
                  A118MonedaId = Z118MonedaId;
                  n118MonedaId = false;
                  AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MONEDAID");
                  AnyError = 1;
                  GX_FocusControl = edtMonedaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMonedaNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0R33( ) ;
                  GX_FocusControl = edtMonedaNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A118MonedaId != Z118MonedaId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtMonedaNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0R33( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MONEDAID");
                     AnyError = 1;
                     GX_FocusControl = edtMonedaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtMonedaNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0R33( ) ;
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
         if ( A118MonedaId != Z118MonedaId )
         {
            A118MonedaId = Z118MonedaId;
            n118MonedaId = false;
            AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MONEDAID");
            AnyError = 1;
            GX_FocusControl = edtMonedaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMonedaNombre_Internalname;
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
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "MONEDAID");
            AnyError = 1;
            GX_FocusControl = edtMonedaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtMonedaNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0R33( ) ;
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMonedaNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0R33( ) ;
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
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMonedaNombre_Internalname;
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
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMonedaNombre_Internalname;
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
         ScanStart0R33( ) ;
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound33 != 0 )
            {
               ScanNext0R33( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMonedaNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0R33( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0R33( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000R2 */
            pr_default.execute(0, new Object[] {n118MonedaId, A118MonedaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Moneda"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z187MonedaNombre, T000R2_A187MonedaNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z119MonedaISOSimbolo, T000R2_A119MonedaISOSimbolo[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z187MonedaNombre, T000R2_A187MonedaNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("moneda:[seudo value changed for attri]"+"MonedaNombre");
                  GXUtil.WriteLogRaw("Old: ",Z187MonedaNombre);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A187MonedaNombre[0]);
               }
               if ( StringUtil.StrCmp(Z119MonedaISOSimbolo, T000R2_A119MonedaISOSimbolo[0]) != 0 )
               {
                  GXUtil.WriteLog("moneda:[seudo value changed for attri]"+"MonedaISOSimbolo");
                  GXUtil.WriteLogRaw("Old: ",Z119MonedaISOSimbolo);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A119MonedaISOSimbolo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Moneda"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0R33( )
      {
         BeforeValidate0R33( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R33( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0R33( 0) ;
            CheckOptimisticConcurrency0R33( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R33( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0R33( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000R8 */
                     pr_default.execute(6, new Object[] {A187MonedaNombre, A119MonedaISOSimbolo});
                     A118MonedaId = T000R8_A118MonedaId[0];
                     n118MonedaId = T000R8_n118MonedaId[0];
                     AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Moneda");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0R0( ) ;
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
               Load0R33( ) ;
            }
            EndLevel0R33( ) ;
         }
         CloseExtendedTableCursors0R33( ) ;
      }

      protected void Update0R33( )
      {
         BeforeValidate0R33( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R33( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R33( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R33( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0R33( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000R9 */
                     pr_default.execute(7, new Object[] {A187MonedaNombre, A119MonedaISOSimbolo, n118MonedaId, A118MonedaId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Moneda");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Moneda"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0R33( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0R0( ) ;
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
            EndLevel0R33( ) ;
         }
         CloseExtendedTableCursors0R33( ) ;
      }

      protected void DeferredUpdate0R33( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0R33( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R33( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0R33( ) ;
            AfterConfirm0R33( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0R33( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000R10 */
                  pr_default.execute(8, new Object[] {n118MonedaId, A118MonedaId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Moneda");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound33 == 0 )
                        {
                           InitAll0R33( ) ;
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
                        ResetCaption0R0( ) ;
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
         sMode33 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0R33( ) ;
         Gx_mode = sMode33;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0R33( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000R11 */
            pr_default.execute(9, new Object[] {n118MonedaId, A118MonedaId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T000R12 */
            pr_default.execute(10, new Object[] {n118MonedaId, A118MonedaId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Publicaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000R13 */
            pr_default.execute(11, new Object[] {n118MonedaId, A118MonedaId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Saldos y Cuentas", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000R14 */
            pr_default.execute(12, new Object[] {n118MonedaId, A118MonedaId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros Medidas y Precios", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000R15 */
            pr_default.execute(13, new Object[] {n118MonedaId, A118MonedaId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Moneda", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0R33( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0R33( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("moneda",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0R0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("moneda",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0R33( )
      {
         /* Using cursor T000R16 */
         pr_default.execute(14);
         RcdFound33 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound33 = 1;
            A118MonedaId = T000R16_A118MonedaId[0];
            n118MonedaId = T000R16_n118MonedaId[0];
            AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0R33( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound33 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound33 = 1;
            A118MonedaId = T000R16_A118MonedaId[0];
            n118MonedaId = T000R16_n118MonedaId[0];
            AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
         }
      }

      protected void ScanEnd0R33( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0R33( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0R33( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0R33( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0R33( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0R33( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0R33( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0R33( )
      {
         edtMonedaId_Enabled = 0;
         AssignProp("", false, edtMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonedaId_Enabled), 5, 0), true);
         edtMonedaNombre_Enabled = 0;
         AssignProp("", false, edtMonedaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonedaNombre_Enabled), 5, 0), true);
         edtMonedaISOSimbolo_Enabled = 0;
         AssignProp("", false, edtMonedaISOSimbolo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonedaISOSimbolo_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0R33( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0R0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("moneda.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z118MonedaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z187MonedaNombre", StringUtil.RTrim( Z187MonedaNombre));
         GxWebStd.gx_hidden_field( context, "Z119MonedaISOSimbolo", StringUtil.RTrim( Z119MonedaISOSimbolo));
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
         return formatLink("moneda.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Moneda" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Moneda", "") ;
      }

      protected void InitializeNonKey0R33( )
      {
         A187MonedaNombre = "";
         AssignAttri("", false, "A187MonedaNombre", A187MonedaNombre);
         A119MonedaISOSimbolo = "";
         AssignAttri("", false, "A119MonedaISOSimbolo", A119MonedaISOSimbolo);
         Z187MonedaNombre = "";
         Z119MonedaISOSimbolo = "";
      }

      protected void InitAll0R33( )
      {
         A118MonedaId = 0;
         n118MonedaId = false;
         AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
         InitializeNonKey0R33( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269282133183", true, true, false);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("moneda.js", "?20269282133184", false, true, false);
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
         edtMonedaId_Internalname = "MONEDAID";
         edtMonedaNombre_Internalname = "MONEDANOMBRE";
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
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
         Form.Caption = context.GetMessage( "Moneda", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtMonedaISOSimbolo_Jsonclick = "";
         edtMonedaISOSimbolo_Enabled = 1;
         edtMonedaNombre_Jsonclick = "";
         edtMonedaNombre_Enabled = 1;
         edtMonedaId_Jsonclick = "";
         edtMonedaId_Enabled = 0;
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
         GX_FocusControl = edtMonedaNombre_Internalname;
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

      public void Valid_Monedaid( )
      {
         n118MonedaId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A187MonedaNombre", StringUtil.RTrim( A187MonedaNombre));
         AssignAttri("", false, "A119MonedaISOSimbolo", StringUtil.RTrim( A119MonedaISOSimbolo));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z118MonedaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118MonedaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z187MonedaNombre", StringUtil.RTrim( Z187MonedaNombre));
         GxWebStd.gx_hidden_field( context, "Z119MonedaISOSimbolo", StringUtil.RTrim( Z119MonedaISOSimbolo));
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
         setEventMetadata("VALID_MONEDAID","{handler:'Valid_Monedaid',iparms:[{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'}]");
         setEventMetadata("VALID_MONEDAID",",oparms:[{av:'A187MonedaNombre',fld:'MONEDANOMBRE',pic:'',type:'char'},{av:'A119MonedaISOSimbolo',fld:'MONEDAISOSIMBOLO',pic:'',type:'char'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z118MonedaId',type:'int'},{av:'Z187MonedaNombre',type:'char'},{av:'Z119MonedaISOSimbolo',type:'char'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z187MonedaNombre = "";
         Z119MonedaISOSimbolo = "";
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
         A187MonedaNombre = "";
         A119MonedaISOSimbolo = "";
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
         T000R4_A118MonedaId = new short[1] ;
         T000R4_n118MonedaId = new bool[] {false} ;
         T000R4_A187MonedaNombre = new string[] {""} ;
         T000R4_A119MonedaISOSimbolo = new string[] {""} ;
         T000R5_A118MonedaId = new short[1] ;
         T000R5_n118MonedaId = new bool[] {false} ;
         T000R3_A118MonedaId = new short[1] ;
         T000R3_n118MonedaId = new bool[] {false} ;
         T000R3_A187MonedaNombre = new string[] {""} ;
         T000R3_A119MonedaISOSimbolo = new string[] {""} ;
         sMode33 = "";
         T000R6_A118MonedaId = new short[1] ;
         T000R6_n118MonedaId = new bool[] {false} ;
         T000R7_A118MonedaId = new short[1] ;
         T000R7_n118MonedaId = new bool[] {false} ;
         T000R2_A118MonedaId = new short[1] ;
         T000R2_n118MonedaId = new bool[] {false} ;
         T000R2_A187MonedaNombre = new string[] {""} ;
         T000R2_A119MonedaISOSimbolo = new string[] {""} ;
         T000R8_A118MonedaId = new short[1] ;
         T000R8_n118MonedaId = new bool[] {false} ;
         T000R11_A127SolicitudesID = new long[1] ;
         T000R12_A381PublicacionesId = new long[1] ;
         T000R13_A637WalletId = new long[1] ;
         T000R14_A121RubrosId = new short[1] ;
         T000R14_A137MedidasID = new long[1] ;
         T000R15_A116PaisID = new string[] {""} ;
         T000R15_A118MonedaId = new short[1] ;
         T000R15_n118MonedaId = new bool[] {false} ;
         T000R16_A118MonedaId = new short[1] ;
         T000R16_n118MonedaId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ187MonedaNombre = "";
         ZZ119MonedaISOSimbolo = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.moneda__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.moneda__default(),
            new Object[][] {
                new Object[] {
               T000R2_A118MonedaId, T000R2_A187MonedaNombre, T000R2_A119MonedaISOSimbolo
               }
               , new Object[] {
               T000R3_A118MonedaId, T000R3_A187MonedaNombre, T000R3_A119MonedaISOSimbolo
               }
               , new Object[] {
               T000R4_A118MonedaId, T000R4_A187MonedaNombre, T000R4_A119MonedaISOSimbolo
               }
               , new Object[] {
               T000R5_A118MonedaId
               }
               , new Object[] {
               T000R6_A118MonedaId
               }
               , new Object[] {
               T000R7_A118MonedaId
               }
               , new Object[] {
               T000R8_A118MonedaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000R11_A127SolicitudesID
               }
               , new Object[] {
               T000R12_A381PublicacionesId
               }
               , new Object[] {
               T000R13_A637WalletId
               }
               , new Object[] {
               T000R14_A121RubrosId, T000R14_A137MedidasID
               }
               , new Object[] {
               T000R15_A116PaisID, T000R15_A118MonedaId
               }
               , new Object[] {
               T000R16_A118MonedaId
               }
            }
         );
      }

      private short Z118MonedaId ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A118MonedaId ;
      private short RcdFound33 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ118MonedaId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtMonedaId_Enabled ;
      private int edtMonedaNombre_Enabled ;
      private int edtMonedaISOSimbolo_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z187MonedaNombre ;
      private string Z119MonedaISOSimbolo ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMonedaNombre_Internalname ;
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
      private string edtMonedaId_Internalname ;
      private string edtMonedaId_Jsonclick ;
      private string A187MonedaNombre ;
      private string edtMonedaNombre_Jsonclick ;
      private string edtMonedaISOSimbolo_Internalname ;
      private string A119MonedaISOSimbolo ;
      private string edtMonedaISOSimbolo_Jsonclick ;
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
      private string sMode33 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ187MonedaNombre ;
      private string ZZ119MonedaISOSimbolo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n118MonedaId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T000R4_A118MonedaId ;
      private bool[] T000R4_n118MonedaId ;
      private string[] T000R4_A187MonedaNombre ;
      private string[] T000R4_A119MonedaISOSimbolo ;
      private short[] T000R5_A118MonedaId ;
      private bool[] T000R5_n118MonedaId ;
      private short[] T000R3_A118MonedaId ;
      private bool[] T000R3_n118MonedaId ;
      private string[] T000R3_A187MonedaNombre ;
      private string[] T000R3_A119MonedaISOSimbolo ;
      private short[] T000R6_A118MonedaId ;
      private bool[] T000R6_n118MonedaId ;
      private short[] T000R7_A118MonedaId ;
      private bool[] T000R7_n118MonedaId ;
      private short[] T000R2_A118MonedaId ;
      private bool[] T000R2_n118MonedaId ;
      private string[] T000R2_A187MonedaNombre ;
      private string[] T000R2_A119MonedaISOSimbolo ;
      private short[] T000R8_A118MonedaId ;
      private bool[] T000R8_n118MonedaId ;
      private long[] T000R11_A127SolicitudesID ;
      private long[] T000R12_A381PublicacionesId ;
      private long[] T000R13_A637WalletId ;
      private short[] T000R14_A121RubrosId ;
      private long[] T000R14_A137MedidasID ;
      private string[] T000R15_A116PaisID ;
      private short[] T000R15_A118MonedaId ;
      private bool[] T000R15_n118MonedaId ;
      private short[] T000R16_A118MonedaId ;
      private bool[] T000R16_n118MonedaId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class moneda__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class moneda__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
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
        Object[] prmT000R2;
        prmT000R2 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000R3;
        prmT000R3 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000R4;
        prmT000R4 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000R5;
        prmT000R5 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000R6;
        prmT000R6 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000R7;
        prmT000R7 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000R8;
        prmT000R8 = new Object[] {
        new ParDef("@MonedaNombre",GXType.NChar,80,0) ,
        new ParDef("@MonedaISOSimbolo",GXType.NChar,3,0)
        };
        Object[] prmT000R9;
        prmT000R9 = new Object[] {
        new ParDef("@MonedaNombre",GXType.NChar,80,0) ,
        new ParDef("@MonedaISOSimbolo",GXType.NChar,3,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000R10;
        prmT000R10 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000R11;
        prmT000R11 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000R12;
        prmT000R12 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000R13;
        prmT000R13 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000R14;
        prmT000R14 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000R15;
        prmT000R15 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000R16;
        prmT000R16 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000R2", "SELECT [MonedaId], [MonedaNombre], [MonedaISOSimbolo] FROM [Moneda] WITH (UPDLOCK) WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000R3", "SELECT [MonedaId], [MonedaNombre], [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000R4", "SELECT TM1.[MonedaId], TM1.[MonedaNombre], TM1.[MonedaISOSimbolo] FROM [Moneda] TM1 WHERE TM1.[MonedaId] = @MonedaId ORDER BY TM1.[MonedaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000R4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000R5", "SELECT [MonedaId] FROM [Moneda] WHERE [MonedaId] = @MonedaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000R5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000R6", "SELECT TOP 1 [MonedaId] FROM [Moneda] WHERE ( [MonedaId] > @MonedaId) ORDER BY [MonedaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000R6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000R7", "SELECT TOP 1 [MonedaId] FROM [Moneda] WHERE ( [MonedaId] < @MonedaId) ORDER BY [MonedaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000R7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000R8", "INSERT INTO [Moneda]([MonedaNombre], [MonedaISOSimbolo]) VALUES(@MonedaNombre, @MonedaISOSimbolo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000R8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000R9", "UPDATE [Moneda] SET [MonedaNombre]=@MonedaNombre, [MonedaISOSimbolo]=@MonedaISOSimbolo  WHERE [MonedaId] = @MonedaId", GxErrorMask.GX_NOMASK,prmT000R9)
           ,new CursorDef("T000R10", "DELETE FROM [Moneda]  WHERE [MonedaId] = @MonedaId", GxErrorMask.GX_NOMASK,prmT000R10)
           ,new CursorDef("T000R11", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [STMonedasId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000R12", "SELECT TOP 1 [PublicacionesId] FROM [Publicaciones] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000R13", "SELECT TOP 1 [WalletId] FROM [Wallet] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000R14", "SELECT TOP 1 [RubrosId], [MedidasID] FROM [RubrosMedidas] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000R15", "SELECT TOP 1 [PaisID], [MonedaId] FROM [PaisMoneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000R16", "SELECT [MonedaId] FROM [Moneda] ORDER BY [MonedaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000R16,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 14 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}
