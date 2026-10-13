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
   public class mensajes : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         Form.Meta.addItem("description", context.GetMessage( "Mensajes", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMensajesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public mensajes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mensajes( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Mensajes", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Mensajes.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Mensajes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Mensajes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Mensajes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Mensajes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx01q0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MENSAJESID"+"'), id:'"+"MENSAJESID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"MENSAJESDEUSER"+"'), id:'"+"MENSAJESDEUSER"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"MENSAJESPARAUSER"+"'), id:'"+"MENSAJESPARAUSER"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"MENSAJESCODREF"+"'), id:'"+"MENSAJESCODREF"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Mensajes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMensajesID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMensajesID_Internalname, context.GetMessage( "ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMensajesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A396MensajesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtMensajesID_Enabled!=0) ? context.localUtil.Format( (decimal)(A396MensajesID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A396MensajesID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMensajesID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMensajesID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Mensajes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMensajesDeUser_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMensajesDeUser_Internalname, context.GetMessage( "De", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMensajesDeUser_Internalname, StringUtil.RTrim( A397MensajesDeUser), StringUtil.RTrim( context.localUtil.Format( A397MensajesDeUser, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMensajesDeUser_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMensajesDeUser_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "Usuario", "start", true, "", "HLP_Mensajes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMensajesParaUser_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMensajesParaUser_Internalname, context.GetMessage( "Para", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMensajesParaUser_Internalname, StringUtil.RTrim( A398MensajesParaUser), StringUtil.RTrim( context.localUtil.Format( A398MensajesParaUser, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMensajesParaUser_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMensajesParaUser_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "Usuario", "start", true, "", "HLP_Mensajes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMensajesMSG_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMensajesMSG_Internalname, context.GetMessage( "Mensaje", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtMensajesMSG_Internalname, A399MensajesMSG, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtMensajesMSG_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Mensajes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMensajesCodRef_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMensajesCodRef_Internalname, context.GetMessage( "Codígo de Referencia", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMensajesCodRef_Internalname, StringUtil.RTrim( A400MensajesCodRef), StringUtil.RTrim( context.localUtil.Format( A400MensajesCodRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMensajesCodRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMensajesCodRef_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Mensajes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMensajesFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMensajesFecha_Internalname, context.GetMessage( "Fecha", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMensajesFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMensajesFecha_Internalname, context.localUtil.TToC( A401MensajesFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A401MensajesFecha, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMensajesFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMensajesFecha_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Mensajes.htm");
         GxWebStd.gx_bitmap( context, edtMensajesFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMensajesFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Mensajes.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Mensajes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Mensajes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Mensajes.htm");
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
            Z396MensajesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z396MensajesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z397MensajesDeUser = cgiGet( "Z397MensajesDeUser");
            Z398MensajesParaUser = cgiGet( "Z398MensajesParaUser");
            Z400MensajesCodRef = cgiGet( "Z400MensajesCodRef");
            Z401MensajesFecha = context.localUtil.CToT( cgiGet( "Z401MensajesFecha"), 0);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtMensajesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMensajesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MENSAJESID");
               AnyError = 1;
               GX_FocusControl = edtMensajesID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A396MensajesID = 0;
               AssignAttri("", false, "A396MensajesID", StringUtil.LTrimStr( (decimal)(A396MensajesID), 18, 0));
            }
            else
            {
               A396MensajesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMensajesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A396MensajesID", StringUtil.LTrimStr( (decimal)(A396MensajesID), 18, 0));
            }
            A397MensajesDeUser = cgiGet( edtMensajesDeUser_Internalname);
            AssignAttri("", false, "A397MensajesDeUser", A397MensajesDeUser);
            A398MensajesParaUser = cgiGet( edtMensajesParaUser_Internalname);
            AssignAttri("", false, "A398MensajesParaUser", A398MensajesParaUser);
            A399MensajesMSG = cgiGet( edtMensajesMSG_Internalname);
            AssignAttri("", false, "A399MensajesMSG", A399MensajesMSG);
            A400MensajesCodRef = cgiGet( edtMensajesCodRef_Internalname);
            AssignAttri("", false, "A400MensajesCodRef", A400MensajesCodRef);
            if ( context.localUtil.VCDateTime( cgiGet( edtMensajesFecha_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha", "")}), 1, "MENSAJESFECHA");
               AnyError = 1;
               GX_FocusControl = edtMensajesFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A401MensajesFecha = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A401MensajesFecha", context.localUtil.TToC( A401MensajesFecha, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A401MensajesFecha = context.localUtil.CToT( cgiGet( edtMensajesFecha_Internalname));
               AssignAttri("", false, "A401MensajesFecha", context.localUtil.TToC( A401MensajesFecha, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
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
               A396MensajesID = (long)(Math.Round(NumberUtil.Val( GetPar( "MensajesID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A396MensajesID", StringUtil.LTrimStr( (decimal)(A396MensajesID), 18, 0));
               A397MensajesDeUser = GetPar( "MensajesDeUser");
               AssignAttri("", false, "A397MensajesDeUser", A397MensajesDeUser);
               A398MensajesParaUser = GetPar( "MensajesParaUser");
               AssignAttri("", false, "A398MensajesParaUser", A398MensajesParaUser);
               A400MensajesCodRef = GetPar( "MensajesCodRef");
               AssignAttri("", false, "A400MensajesCodRef", A400MensajesCodRef);
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
               InitAll1I62( ) ;
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
         DisableAttributes1I62( ) ;
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

      protected void ResetCaption1I0( )
      {
      }

      protected void ZM1I62( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z401MensajesFecha = T001I3_A401MensajesFecha[0];
            }
            else
            {
               Z401MensajesFecha = A401MensajesFecha;
            }
         }
         if ( GX_JID == -2 )
         {
            Z396MensajesID = A396MensajesID;
            Z397MensajesDeUser = A397MensajesDeUser;
            Z398MensajesParaUser = A398MensajesParaUser;
            Z400MensajesCodRef = A400MensajesCodRef;
            Z399MensajesMSG = A399MensajesMSG;
            Z401MensajesFecha = A401MensajesFecha;
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

      protected void Load1I62( )
      {
         /* Using cursor T001I4 */
         pr_default.execute(2, new Object[] {A396MensajesID, A397MensajesDeUser, A398MensajesParaUser, A400MensajesCodRef});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound62 = 1;
            A399MensajesMSG = T001I4_A399MensajesMSG[0];
            AssignAttri("", false, "A399MensajesMSG", A399MensajesMSG);
            A401MensajesFecha = T001I4_A401MensajesFecha[0];
            AssignAttri("", false, "A401MensajesFecha", context.localUtil.TToC( A401MensajesFecha, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            ZM1I62( -2) ;
         }
         pr_default.close(2);
         OnLoadActions1I62( ) ;
      }

      protected void OnLoadActions1I62( )
      {
      }

      protected void CheckExtendedTable1I62( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A401MensajesFecha) || ( A401MensajesFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "MENSAJESFECHA");
            AnyError = 1;
            GX_FocusControl = edtMensajesFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1I62( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1I62( )
      {
         /* Using cursor T001I5 */
         pr_default.execute(3, new Object[] {A396MensajesID, A397MensajesDeUser, A398MensajesParaUser, A400MensajesCodRef});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound62 = 1;
         }
         else
         {
            RcdFound62 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001I3 */
         pr_default.execute(1, new Object[] {A396MensajesID, A397MensajesDeUser, A398MensajesParaUser, A400MensajesCodRef});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1I62( 2) ;
            RcdFound62 = 1;
            A396MensajesID = T001I3_A396MensajesID[0];
            AssignAttri("", false, "A396MensajesID", StringUtil.LTrimStr( (decimal)(A396MensajesID), 18, 0));
            A397MensajesDeUser = T001I3_A397MensajesDeUser[0];
            AssignAttri("", false, "A397MensajesDeUser", A397MensajesDeUser);
            A398MensajesParaUser = T001I3_A398MensajesParaUser[0];
            AssignAttri("", false, "A398MensajesParaUser", A398MensajesParaUser);
            A400MensajesCodRef = T001I3_A400MensajesCodRef[0];
            AssignAttri("", false, "A400MensajesCodRef", A400MensajesCodRef);
            A399MensajesMSG = T001I3_A399MensajesMSG[0];
            AssignAttri("", false, "A399MensajesMSG", A399MensajesMSG);
            A401MensajesFecha = T001I3_A401MensajesFecha[0];
            AssignAttri("", false, "A401MensajesFecha", context.localUtil.TToC( A401MensajesFecha, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            Z396MensajesID = A396MensajesID;
            Z397MensajesDeUser = A397MensajesDeUser;
            Z398MensajesParaUser = A398MensajesParaUser;
            Z400MensajesCodRef = A400MensajesCodRef;
            sMode62 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1I62( ) ;
            if ( AnyError == 1 )
            {
               RcdFound62 = 0;
               InitializeNonKey1I62( ) ;
            }
            Gx_mode = sMode62;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound62 = 0;
            InitializeNonKey1I62( ) ;
            sMode62 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode62;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1I62( ) ;
         if ( RcdFound62 == 0 )
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
         RcdFound62 = 0;
         /* Using cursor T001I6 */
         pr_default.execute(4, new Object[] {A396MensajesID, A397MensajesDeUser, A398MensajesParaUser, A400MensajesCodRef});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T001I6_A396MensajesID[0] < A396MensajesID ) || ( T001I6_A396MensajesID[0] == A396MensajesID ) && ( StringUtil.StrCmp(T001I6_A397MensajesDeUser[0], A397MensajesDeUser) < 0 ) || ( StringUtil.StrCmp(T001I6_A397MensajesDeUser[0], A397MensajesDeUser) == 0 ) && ( T001I6_A396MensajesID[0] == A396MensajesID ) && ( StringUtil.StrCmp(T001I6_A398MensajesParaUser[0], A398MensajesParaUser) < 0 ) || ( StringUtil.StrCmp(T001I6_A398MensajesParaUser[0], A398MensajesParaUser) == 0 ) && ( StringUtil.StrCmp(T001I6_A397MensajesDeUser[0], A397MensajesDeUser) == 0 ) && ( T001I6_A396MensajesID[0] == A396MensajesID ) && ( StringUtil.StrCmp(T001I6_A400MensajesCodRef[0], A400MensajesCodRef) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T001I6_A396MensajesID[0] > A396MensajesID ) || ( T001I6_A396MensajesID[0] == A396MensajesID ) && ( StringUtil.StrCmp(T001I6_A397MensajesDeUser[0], A397MensajesDeUser) > 0 ) || ( StringUtil.StrCmp(T001I6_A397MensajesDeUser[0], A397MensajesDeUser) == 0 ) && ( T001I6_A396MensajesID[0] == A396MensajesID ) && ( StringUtil.StrCmp(T001I6_A398MensajesParaUser[0], A398MensajesParaUser) > 0 ) || ( StringUtil.StrCmp(T001I6_A398MensajesParaUser[0], A398MensajesParaUser) == 0 ) && ( StringUtil.StrCmp(T001I6_A397MensajesDeUser[0], A397MensajesDeUser) == 0 ) && ( T001I6_A396MensajesID[0] == A396MensajesID ) && ( StringUtil.StrCmp(T001I6_A400MensajesCodRef[0], A400MensajesCodRef) > 0 ) ) )
            {
               A396MensajesID = T001I6_A396MensajesID[0];
               AssignAttri("", false, "A396MensajesID", StringUtil.LTrimStr( (decimal)(A396MensajesID), 18, 0));
               A397MensajesDeUser = T001I6_A397MensajesDeUser[0];
               AssignAttri("", false, "A397MensajesDeUser", A397MensajesDeUser);
               A398MensajesParaUser = T001I6_A398MensajesParaUser[0];
               AssignAttri("", false, "A398MensajesParaUser", A398MensajesParaUser);
               A400MensajesCodRef = T001I6_A400MensajesCodRef[0];
               AssignAttri("", false, "A400MensajesCodRef", A400MensajesCodRef);
               RcdFound62 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound62 = 0;
         /* Using cursor T001I7 */
         pr_default.execute(5, new Object[] {A396MensajesID, A397MensajesDeUser, A398MensajesParaUser, A400MensajesCodRef});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T001I7_A396MensajesID[0] > A396MensajesID ) || ( T001I7_A396MensajesID[0] == A396MensajesID ) && ( StringUtil.StrCmp(T001I7_A397MensajesDeUser[0], A397MensajesDeUser) > 0 ) || ( StringUtil.StrCmp(T001I7_A397MensajesDeUser[0], A397MensajesDeUser) == 0 ) && ( T001I7_A396MensajesID[0] == A396MensajesID ) && ( StringUtil.StrCmp(T001I7_A398MensajesParaUser[0], A398MensajesParaUser) > 0 ) || ( StringUtil.StrCmp(T001I7_A398MensajesParaUser[0], A398MensajesParaUser) == 0 ) && ( StringUtil.StrCmp(T001I7_A397MensajesDeUser[0], A397MensajesDeUser) == 0 ) && ( T001I7_A396MensajesID[0] == A396MensajesID ) && ( StringUtil.StrCmp(T001I7_A400MensajesCodRef[0], A400MensajesCodRef) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T001I7_A396MensajesID[0] < A396MensajesID ) || ( T001I7_A396MensajesID[0] == A396MensajesID ) && ( StringUtil.StrCmp(T001I7_A397MensajesDeUser[0], A397MensajesDeUser) < 0 ) || ( StringUtil.StrCmp(T001I7_A397MensajesDeUser[0], A397MensajesDeUser) == 0 ) && ( T001I7_A396MensajesID[0] == A396MensajesID ) && ( StringUtil.StrCmp(T001I7_A398MensajesParaUser[0], A398MensajesParaUser) < 0 ) || ( StringUtil.StrCmp(T001I7_A398MensajesParaUser[0], A398MensajesParaUser) == 0 ) && ( StringUtil.StrCmp(T001I7_A397MensajesDeUser[0], A397MensajesDeUser) == 0 ) && ( T001I7_A396MensajesID[0] == A396MensajesID ) && ( StringUtil.StrCmp(T001I7_A400MensajesCodRef[0], A400MensajesCodRef) < 0 ) ) )
            {
               A396MensajesID = T001I7_A396MensajesID[0];
               AssignAttri("", false, "A396MensajesID", StringUtil.LTrimStr( (decimal)(A396MensajesID), 18, 0));
               A397MensajesDeUser = T001I7_A397MensajesDeUser[0];
               AssignAttri("", false, "A397MensajesDeUser", A397MensajesDeUser);
               A398MensajesParaUser = T001I7_A398MensajesParaUser[0];
               AssignAttri("", false, "A398MensajesParaUser", A398MensajesParaUser);
               A400MensajesCodRef = T001I7_A400MensajesCodRef[0];
               AssignAttri("", false, "A400MensajesCodRef", A400MensajesCodRef);
               RcdFound62 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1I62( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMensajesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1I62( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound62 == 1 )
            {
               if ( ( A396MensajesID != Z396MensajesID ) || ( StringUtil.StrCmp(A397MensajesDeUser, Z397MensajesDeUser) != 0 ) || ( StringUtil.StrCmp(A398MensajesParaUser, Z398MensajesParaUser) != 0 ) || ( StringUtil.StrCmp(A400MensajesCodRef, Z400MensajesCodRef) != 0 ) )
               {
                  A396MensajesID = Z396MensajesID;
                  AssignAttri("", false, "A396MensajesID", StringUtil.LTrimStr( (decimal)(A396MensajesID), 18, 0));
                  A397MensajesDeUser = Z397MensajesDeUser;
                  AssignAttri("", false, "A397MensajesDeUser", A397MensajesDeUser);
                  A398MensajesParaUser = Z398MensajesParaUser;
                  AssignAttri("", false, "A398MensajesParaUser", A398MensajesParaUser);
                  A400MensajesCodRef = Z400MensajesCodRef;
                  AssignAttri("", false, "A400MensajesCodRef", A400MensajesCodRef);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MENSAJESID");
                  AnyError = 1;
                  GX_FocusControl = edtMensajesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMensajesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1I62( ) ;
                  GX_FocusControl = edtMensajesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A396MensajesID != Z396MensajesID ) || ( StringUtil.StrCmp(A397MensajesDeUser, Z397MensajesDeUser) != 0 ) || ( StringUtil.StrCmp(A398MensajesParaUser, Z398MensajesParaUser) != 0 ) || ( StringUtil.StrCmp(A400MensajesCodRef, Z400MensajesCodRef) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtMensajesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1I62( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MENSAJESID");
                     AnyError = 1;
                     GX_FocusControl = edtMensajesID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtMensajesID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1I62( ) ;
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
         if ( ( A396MensajesID != Z396MensajesID ) || ( StringUtil.StrCmp(A397MensajesDeUser, Z397MensajesDeUser) != 0 ) || ( StringUtil.StrCmp(A398MensajesParaUser, Z398MensajesParaUser) != 0 ) || ( StringUtil.StrCmp(A400MensajesCodRef, Z400MensajesCodRef) != 0 ) )
         {
            A396MensajesID = Z396MensajesID;
            AssignAttri("", false, "A396MensajesID", StringUtil.LTrimStr( (decimal)(A396MensajesID), 18, 0));
            A397MensajesDeUser = Z397MensajesDeUser;
            AssignAttri("", false, "A397MensajesDeUser", A397MensajesDeUser);
            A398MensajesParaUser = Z398MensajesParaUser;
            AssignAttri("", false, "A398MensajesParaUser", A398MensajesParaUser);
            A400MensajesCodRef = Z400MensajesCodRef;
            AssignAttri("", false, "A400MensajesCodRef", A400MensajesCodRef);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MENSAJESID");
            AnyError = 1;
            GX_FocusControl = edtMensajesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMensajesID_Internalname;
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
         if ( RcdFound62 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "MENSAJESID");
            AnyError = 1;
            GX_FocusControl = edtMensajesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtMensajesMSG_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1I62( ) ;
         if ( RcdFound62 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMensajesMSG_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1I62( ) ;
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
         if ( RcdFound62 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMensajesMSG_Internalname;
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
         if ( RcdFound62 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMensajesMSG_Internalname;
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
         ScanStart1I62( ) ;
         if ( RcdFound62 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound62 != 0 )
            {
               ScanNext1I62( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMensajesMSG_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1I62( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1I62( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001I2 */
            pr_default.execute(0, new Object[] {A396MensajesID, A397MensajesDeUser, A398MensajesParaUser, A400MensajesCodRef});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Mensajes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z401MensajesFecha != T001I2_A401MensajesFecha[0] ) )
            {
               if ( Z401MensajesFecha != T001I2_A401MensajesFecha[0] )
               {
                  GXUtil.WriteLog("mensajes:[seudo value changed for attri]"+"MensajesFecha");
                  GXUtil.WriteLogRaw("Old: ",Z401MensajesFecha);
                  GXUtil.WriteLogRaw("Current: ",T001I2_A401MensajesFecha[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Mensajes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1I62( )
      {
         BeforeValidate1I62( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1I62( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1I62( 0) ;
            CheckOptimisticConcurrency1I62( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1I62( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1I62( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001I8 */
                     pr_default.execute(6, new Object[] {A396MensajesID, A397MensajesDeUser, A398MensajesParaUser, A400MensajesCodRef, A399MensajesMSG, A401MensajesFecha});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Mensajes");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption1I0( ) ;
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
               Load1I62( ) ;
            }
            EndLevel1I62( ) ;
         }
         CloseExtendedTableCursors1I62( ) ;
      }

      protected void Update1I62( )
      {
         BeforeValidate1I62( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1I62( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1I62( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1I62( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1I62( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001I9 */
                     pr_default.execute(7, new Object[] {A399MensajesMSG, A401MensajesFecha, A396MensajesID, A397MensajesDeUser, A398MensajesParaUser, A400MensajesCodRef});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Mensajes");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Mensajes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1I62( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1I0( ) ;
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
            EndLevel1I62( ) ;
         }
         CloseExtendedTableCursors1I62( ) ;
      }

      protected void DeferredUpdate1I62( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1I62( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1I62( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1I62( ) ;
            AfterConfirm1I62( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1I62( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001I10 */
                  pr_default.execute(8, new Object[] {A396MensajesID, A397MensajesDeUser, A398MensajesParaUser, A400MensajesCodRef});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Mensajes");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound62 == 0 )
                        {
                           InitAll1I62( ) ;
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
                        ResetCaption1I0( ) ;
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
         sMode62 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1I62( ) ;
         Gx_mode = sMode62;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1I62( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1I62( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1I62( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("mensajes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1I0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("mensajes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1I62( )
      {
         /* Using cursor T001I11 */
         pr_default.execute(9);
         RcdFound62 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound62 = 1;
            A396MensajesID = T001I11_A396MensajesID[0];
            AssignAttri("", false, "A396MensajesID", StringUtil.LTrimStr( (decimal)(A396MensajesID), 18, 0));
            A397MensajesDeUser = T001I11_A397MensajesDeUser[0];
            AssignAttri("", false, "A397MensajesDeUser", A397MensajesDeUser);
            A398MensajesParaUser = T001I11_A398MensajesParaUser[0];
            AssignAttri("", false, "A398MensajesParaUser", A398MensajesParaUser);
            A400MensajesCodRef = T001I11_A400MensajesCodRef[0];
            AssignAttri("", false, "A400MensajesCodRef", A400MensajesCodRef);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1I62( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound62 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound62 = 1;
            A396MensajesID = T001I11_A396MensajesID[0];
            AssignAttri("", false, "A396MensajesID", StringUtil.LTrimStr( (decimal)(A396MensajesID), 18, 0));
            A397MensajesDeUser = T001I11_A397MensajesDeUser[0];
            AssignAttri("", false, "A397MensajesDeUser", A397MensajesDeUser);
            A398MensajesParaUser = T001I11_A398MensajesParaUser[0];
            AssignAttri("", false, "A398MensajesParaUser", A398MensajesParaUser);
            A400MensajesCodRef = T001I11_A400MensajesCodRef[0];
            AssignAttri("", false, "A400MensajesCodRef", A400MensajesCodRef);
         }
      }

      protected void ScanEnd1I62( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1I62( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1I62( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1I62( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1I62( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1I62( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1I62( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1I62( )
      {
         edtMensajesID_Enabled = 0;
         AssignProp("", false, edtMensajesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMensajesID_Enabled), 5, 0), true);
         edtMensajesDeUser_Enabled = 0;
         AssignProp("", false, edtMensajesDeUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMensajesDeUser_Enabled), 5, 0), true);
         edtMensajesParaUser_Enabled = 0;
         AssignProp("", false, edtMensajesParaUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMensajesParaUser_Enabled), 5, 0), true);
         edtMensajesMSG_Enabled = 0;
         AssignProp("", false, edtMensajesMSG_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMensajesMSG_Enabled), 5, 0), true);
         edtMensajesCodRef_Enabled = 0;
         AssignProp("", false, edtMensajesCodRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMensajesCodRef_Enabled), 5, 0), true);
         edtMensajesFecha_Enabled = 0;
         AssignProp("", false, edtMensajesFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMensajesFecha_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1I62( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1I0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("mensajes.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z396MensajesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z396MensajesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z397MensajesDeUser", StringUtil.RTrim( Z397MensajesDeUser));
         GxWebStd.gx_hidden_field( context, "Z398MensajesParaUser", StringUtil.RTrim( Z398MensajesParaUser));
         GxWebStd.gx_hidden_field( context, "Z400MensajesCodRef", StringUtil.RTrim( Z400MensajesCodRef));
         GxWebStd.gx_hidden_field( context, "Z401MensajesFecha", context.localUtil.TToC( Z401MensajesFecha, 10, 8, 0, 0, "/", ":", " "));
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
         return formatLink("mensajes.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Mensajes" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Mensajes", "") ;
      }

      protected void InitializeNonKey1I62( )
      {
         A399MensajesMSG = "";
         AssignAttri("", false, "A399MensajesMSG", A399MensajesMSG);
         A401MensajesFecha = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A401MensajesFecha", context.localUtil.TToC( A401MensajesFecha, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         Z401MensajesFecha = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll1I62( )
      {
         A396MensajesID = 0;
         AssignAttri("", false, "A396MensajesID", StringUtil.LTrimStr( (decimal)(A396MensajesID), 18, 0));
         A397MensajesDeUser = "";
         AssignAttri("", false, "A397MensajesDeUser", A397MensajesDeUser);
         A398MensajesParaUser = "";
         AssignAttri("", false, "A398MensajesParaUser", A398MensajesParaUser);
         A400MensajesCodRef = "";
         AssignAttri("", false, "A400MensajesCodRef", A400MensajesCodRef);
         InitializeNonKey1I62( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021115333", true, true, false);
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
         context.AddJavascriptSource("mensajes.js", "?202673021115333", false, true, false);
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
         edtMensajesID_Internalname = "MENSAJESID";
         edtMensajesDeUser_Internalname = "MENSAJESDEUSER";
         edtMensajesParaUser_Internalname = "MENSAJESPARAUSER";
         edtMensajesMSG_Internalname = "MENSAJESMSG";
         edtMensajesCodRef_Internalname = "MENSAJESCODREF";
         edtMensajesFecha_Internalname = "MENSAJESFECHA";
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
         Form.Caption = context.GetMessage( "Mensajes", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtMensajesFecha_Jsonclick = "";
         edtMensajesFecha_Enabled = 1;
         edtMensajesCodRef_Jsonclick = "";
         edtMensajesCodRef_Enabled = 1;
         edtMensajesMSG_Enabled = 1;
         edtMensajesParaUser_Jsonclick = "";
         edtMensajesParaUser_Enabled = 1;
         edtMensajesDeUser_Jsonclick = "";
         edtMensajesDeUser_Enabled = 1;
         edtMensajesID_Jsonclick = "";
         edtMensajesID_Enabled = 1;
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
         GX_FocusControl = edtMensajesMSG_Internalname;
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

      public void Valid_Mensajescodref( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A399MensajesMSG", A399MensajesMSG);
         AssignAttri("", false, "A401MensajesFecha", context.localUtil.TToC( A401MensajesFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z396MensajesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z396MensajesID), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z397MensajesDeUser", StringUtil.RTrim( Z397MensajesDeUser));
         GxWebStd.gx_hidden_field( context, "Z398MensajesParaUser", StringUtil.RTrim( Z398MensajesParaUser));
         GxWebStd.gx_hidden_field( context, "Z400MensajesCodRef", StringUtil.RTrim( Z400MensajesCodRef));
         GxWebStd.gx_hidden_field( context, "Z399MensajesMSG", Z399MensajesMSG);
         GxWebStd.gx_hidden_field( context, "Z401MensajesFecha", context.localUtil.TToC( Z401MensajesFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
         setEventMetadata("VALID_MENSAJESID","{handler:'Valid_Mensajesid',iparms:[]");
         setEventMetadata("VALID_MENSAJESID",",oparms:[]}");
         setEventMetadata("VALID_MENSAJESDEUSER","{handler:'Valid_Mensajesdeuser',iparms:[]");
         setEventMetadata("VALID_MENSAJESDEUSER",",oparms:[]}");
         setEventMetadata("VALID_MENSAJESPARAUSER","{handler:'Valid_Mensajesparauser',iparms:[]");
         setEventMetadata("VALID_MENSAJESPARAUSER",",oparms:[]}");
         setEventMetadata("VALID_MENSAJESCODREF","{handler:'Valid_Mensajescodref',iparms:[{av:'A396MensajesID',fld:'MENSAJESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A397MensajesDeUser',fld:'MENSAJESDEUSER',pic:'',type:'char'},{av:'A398MensajesParaUser',fld:'MENSAJESPARAUSER',pic:'',type:'char'},{av:'A400MensajesCodRef',fld:'MENSAJESCODREF',pic:'',type:'char'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'}]");
         setEventMetadata("VALID_MENSAJESCODREF",",oparms:[{av:'A399MensajesMSG',fld:'MENSAJESMSG',pic:'',type:'vchar'},{av:'A401MensajesFecha',fld:'MENSAJESFECHA',pic:'99/99/99 99:99',type:'dtime'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z396MensajesID',type:'int'},{av:'Z397MensajesDeUser',type:'char'},{av:'Z398MensajesParaUser',type:'char'},{av:'Z400MensajesCodRef',type:'char'},{av:'Z399MensajesMSG',type:'vchar'},{av:'Z401MensajesFecha',type:'dtime'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_MENSAJESFECHA","{handler:'Valid_Mensajesfecha',iparms:[]");
         setEventMetadata("VALID_MENSAJESFECHA",",oparms:[]}");
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
         Z397MensajesDeUser = "";
         Z398MensajesParaUser = "";
         Z400MensajesCodRef = "";
         Z401MensajesFecha = (DateTime)(DateTime.MinValue);
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
         A397MensajesDeUser = "";
         A398MensajesParaUser = "";
         A399MensajesMSG = "";
         A400MensajesCodRef = "";
         A401MensajesFecha = (DateTime)(DateTime.MinValue);
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
         Z399MensajesMSG = "";
         T001I4_A396MensajesID = new long[1] ;
         T001I4_A397MensajesDeUser = new string[] {""} ;
         T001I4_A398MensajesParaUser = new string[] {""} ;
         T001I4_A400MensajesCodRef = new string[] {""} ;
         T001I4_A399MensajesMSG = new string[] {""} ;
         T001I4_A401MensajesFecha = new DateTime[] {DateTime.MinValue} ;
         T001I5_A396MensajesID = new long[1] ;
         T001I5_A397MensajesDeUser = new string[] {""} ;
         T001I5_A398MensajesParaUser = new string[] {""} ;
         T001I5_A400MensajesCodRef = new string[] {""} ;
         T001I3_A396MensajesID = new long[1] ;
         T001I3_A397MensajesDeUser = new string[] {""} ;
         T001I3_A398MensajesParaUser = new string[] {""} ;
         T001I3_A400MensajesCodRef = new string[] {""} ;
         T001I3_A399MensajesMSG = new string[] {""} ;
         T001I3_A401MensajesFecha = new DateTime[] {DateTime.MinValue} ;
         sMode62 = "";
         T001I6_A396MensajesID = new long[1] ;
         T001I6_A397MensajesDeUser = new string[] {""} ;
         T001I6_A398MensajesParaUser = new string[] {""} ;
         T001I6_A400MensajesCodRef = new string[] {""} ;
         T001I7_A396MensajesID = new long[1] ;
         T001I7_A397MensajesDeUser = new string[] {""} ;
         T001I7_A398MensajesParaUser = new string[] {""} ;
         T001I7_A400MensajesCodRef = new string[] {""} ;
         T001I2_A396MensajesID = new long[1] ;
         T001I2_A397MensajesDeUser = new string[] {""} ;
         T001I2_A398MensajesParaUser = new string[] {""} ;
         T001I2_A400MensajesCodRef = new string[] {""} ;
         T001I2_A399MensajesMSG = new string[] {""} ;
         T001I2_A401MensajesFecha = new DateTime[] {DateTime.MinValue} ;
         T001I11_A396MensajesID = new long[1] ;
         T001I11_A397MensajesDeUser = new string[] {""} ;
         T001I11_A398MensajesParaUser = new string[] {""} ;
         T001I11_A400MensajesCodRef = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ397MensajesDeUser = "";
         ZZ398MensajesParaUser = "";
         ZZ400MensajesCodRef = "";
         ZZ399MensajesMSG = "";
         ZZ401MensajesFecha = (DateTime)(DateTime.MinValue);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.mensajes__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mensajes__default(),
            new Object[][] {
                new Object[] {
               T001I2_A396MensajesID, T001I2_A397MensajesDeUser, T001I2_A398MensajesParaUser, T001I2_A400MensajesCodRef, T001I2_A399MensajesMSG, T001I2_A401MensajesFecha
               }
               , new Object[] {
               T001I3_A396MensajesID, T001I3_A397MensajesDeUser, T001I3_A398MensajesParaUser, T001I3_A400MensajesCodRef, T001I3_A399MensajesMSG, T001I3_A401MensajesFecha
               }
               , new Object[] {
               T001I4_A396MensajesID, T001I4_A397MensajesDeUser, T001I4_A398MensajesParaUser, T001I4_A400MensajesCodRef, T001I4_A399MensajesMSG, T001I4_A401MensajesFecha
               }
               , new Object[] {
               T001I5_A396MensajesID, T001I5_A397MensajesDeUser, T001I5_A398MensajesParaUser, T001I5_A400MensajesCodRef
               }
               , new Object[] {
               T001I6_A396MensajesID, T001I6_A397MensajesDeUser, T001I6_A398MensajesParaUser, T001I6_A400MensajesCodRef
               }
               , new Object[] {
               T001I7_A396MensajesID, T001I7_A397MensajesDeUser, T001I7_A398MensajesParaUser, T001I7_A400MensajesCodRef
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001I11_A396MensajesID, T001I11_A397MensajesDeUser, T001I11_A398MensajesParaUser, T001I11_A400MensajesCodRef
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound62 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtMensajesID_Enabled ;
      private int edtMensajesDeUser_Enabled ;
      private int edtMensajesParaUser_Enabled ;
      private int edtMensajesMSG_Enabled ;
      private int edtMensajesCodRef_Enabled ;
      private int edtMensajesFecha_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z396MensajesID ;
      private long A396MensajesID ;
      private long ZZ396MensajesID ;
      private string sPrefix ;
      private string Z397MensajesDeUser ;
      private string Z398MensajesParaUser ;
      private string Z400MensajesCodRef ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMensajesID_Internalname ;
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
      private string edtMensajesID_Jsonclick ;
      private string edtMensajesDeUser_Internalname ;
      private string A397MensajesDeUser ;
      private string edtMensajesDeUser_Jsonclick ;
      private string edtMensajesParaUser_Internalname ;
      private string A398MensajesParaUser ;
      private string edtMensajesParaUser_Jsonclick ;
      private string edtMensajesMSG_Internalname ;
      private string edtMensajesCodRef_Internalname ;
      private string A400MensajesCodRef ;
      private string edtMensajesCodRef_Jsonclick ;
      private string edtMensajesFecha_Internalname ;
      private string edtMensajesFecha_Jsonclick ;
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
      private string sMode62 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ397MensajesDeUser ;
      private string ZZ398MensajesParaUser ;
      private string ZZ400MensajesCodRef ;
      private DateTime Z401MensajesFecha ;
      private DateTime A401MensajesFecha ;
      private DateTime ZZ401MensajesFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string A399MensajesMSG ;
      private string Z399MensajesMSG ;
      private string ZZ399MensajesMSG ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T001I4_A396MensajesID ;
      private string[] T001I4_A397MensajesDeUser ;
      private string[] T001I4_A398MensajesParaUser ;
      private string[] T001I4_A400MensajesCodRef ;
      private string[] T001I4_A399MensajesMSG ;
      private DateTime[] T001I4_A401MensajesFecha ;
      private long[] T001I5_A396MensajesID ;
      private string[] T001I5_A397MensajesDeUser ;
      private string[] T001I5_A398MensajesParaUser ;
      private string[] T001I5_A400MensajesCodRef ;
      private long[] T001I3_A396MensajesID ;
      private string[] T001I3_A397MensajesDeUser ;
      private string[] T001I3_A398MensajesParaUser ;
      private string[] T001I3_A400MensajesCodRef ;
      private string[] T001I3_A399MensajesMSG ;
      private DateTime[] T001I3_A401MensajesFecha ;
      private long[] T001I6_A396MensajesID ;
      private string[] T001I6_A397MensajesDeUser ;
      private string[] T001I6_A398MensajesParaUser ;
      private string[] T001I6_A400MensajesCodRef ;
      private long[] T001I7_A396MensajesID ;
      private string[] T001I7_A397MensajesDeUser ;
      private string[] T001I7_A398MensajesParaUser ;
      private string[] T001I7_A400MensajesCodRef ;
      private long[] T001I2_A396MensajesID ;
      private string[] T001I2_A397MensajesDeUser ;
      private string[] T001I2_A398MensajesParaUser ;
      private string[] T001I2_A400MensajesCodRef ;
      private string[] T001I2_A399MensajesMSG ;
      private DateTime[] T001I2_A401MensajesFecha ;
      private long[] T001I11_A396MensajesID ;
      private string[] T001I11_A397MensajesDeUser ;
      private string[] T001I11_A398MensajesParaUser ;
      private string[] T001I11_A400MensajesCodRef ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class mensajes__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class mensajes__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001I2;
        prmT001I2 = new Object[] {
        new ParDef("@MensajesID",GXType.Decimal,18,0) ,
        new ParDef("@MensajesDeUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesParaUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesCodRef",GXType.NChar,20,0)
        };
        Object[] prmT001I3;
        prmT001I3 = new Object[] {
        new ParDef("@MensajesID",GXType.Decimal,18,0) ,
        new ParDef("@MensajesDeUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesParaUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesCodRef",GXType.NChar,20,0)
        };
        Object[] prmT001I4;
        prmT001I4 = new Object[] {
        new ParDef("@MensajesID",GXType.Decimal,18,0) ,
        new ParDef("@MensajesDeUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesParaUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesCodRef",GXType.NChar,20,0)
        };
        Object[] prmT001I5;
        prmT001I5 = new Object[] {
        new ParDef("@MensajesID",GXType.Decimal,18,0) ,
        new ParDef("@MensajesDeUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesParaUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesCodRef",GXType.NChar,20,0)
        };
        Object[] prmT001I6;
        prmT001I6 = new Object[] {
        new ParDef("@MensajesID",GXType.Decimal,18,0) ,
        new ParDef("@MensajesDeUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesParaUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesCodRef",GXType.NChar,20,0)
        };
        Object[] prmT001I7;
        prmT001I7 = new Object[] {
        new ParDef("@MensajesID",GXType.Decimal,18,0) ,
        new ParDef("@MensajesDeUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesParaUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesCodRef",GXType.NChar,20,0)
        };
        Object[] prmT001I8;
        prmT001I8 = new Object[] {
        new ParDef("@MensajesID",GXType.Decimal,18,0) ,
        new ParDef("@MensajesDeUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesParaUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesCodRef",GXType.NChar,20,0) ,
        new ParDef("@MensajesMSG",GXType.NVarChar,2097152,0) ,
        new ParDef("@MensajesFecha",GXType.DateTime,8,5)
        };
        Object[] prmT001I9;
        prmT001I9 = new Object[] {
        new ParDef("@MensajesMSG",GXType.NVarChar,2097152,0) ,
        new ParDef("@MensajesFecha",GXType.DateTime,8,5) ,
        new ParDef("@MensajesID",GXType.Decimal,18,0) ,
        new ParDef("@MensajesDeUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesParaUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesCodRef",GXType.NChar,20,0)
        };
        Object[] prmT001I10;
        prmT001I10 = new Object[] {
        new ParDef("@MensajesID",GXType.Decimal,18,0) ,
        new ParDef("@MensajesDeUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesParaUser",GXType.NChar,30,0) ,
        new ParDef("@MensajesCodRef",GXType.NChar,20,0)
        };
        Object[] prmT001I11;
        prmT001I11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001I2", "SELECT [MensajesID], [MensajesDeUser], [MensajesParaUser], [MensajesCodRef], [MensajesMSG], [MensajesFecha] FROM [Mensajes] WITH (UPDLOCK) WHERE [MensajesID] = @MensajesID AND [MensajesDeUser] = @MensajesDeUser AND [MensajesParaUser] = @MensajesParaUser AND [MensajesCodRef] = @MensajesCodRef ",true, GxErrorMask.GX_NOMASK, false, this,prmT001I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001I3", "SELECT [MensajesID], [MensajesDeUser], [MensajesParaUser], [MensajesCodRef], [MensajesMSG], [MensajesFecha] FROM [Mensajes] WHERE [MensajesID] = @MensajesID AND [MensajesDeUser] = @MensajesDeUser AND [MensajesParaUser] = @MensajesParaUser AND [MensajesCodRef] = @MensajesCodRef ",true, GxErrorMask.GX_NOMASK, false, this,prmT001I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001I4", "SELECT TM1.[MensajesID], TM1.[MensajesDeUser], TM1.[MensajesParaUser], TM1.[MensajesCodRef], TM1.[MensajesMSG], TM1.[MensajesFecha] FROM [Mensajes] TM1 WHERE TM1.[MensajesID] = @MensajesID and TM1.[MensajesDeUser] = @MensajesDeUser and TM1.[MensajesParaUser] = @MensajesParaUser and TM1.[MensajesCodRef] = @MensajesCodRef ORDER BY TM1.[MensajesID], TM1.[MensajesDeUser], TM1.[MensajesParaUser], TM1.[MensajesCodRef]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001I4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001I5", "SELECT [MensajesID], [MensajesDeUser], [MensajesParaUser], [MensajesCodRef] FROM [Mensajes] WHERE [MensajesID] = @MensajesID AND [MensajesDeUser] = @MensajesDeUser AND [MensajesParaUser] = @MensajesParaUser AND [MensajesCodRef] = @MensajesCodRef  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001I5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001I6", "SELECT TOP 1 [MensajesID], [MensajesDeUser], [MensajesParaUser], [MensajesCodRef] FROM [Mensajes] WHERE ( [MensajesID] > @MensajesID or [MensajesID] = @MensajesID and [MensajesDeUser] > @MensajesDeUser or [MensajesDeUser] = @MensajesDeUser and [MensajesID] = @MensajesID and [MensajesParaUser] > @MensajesParaUser or [MensajesParaUser] = @MensajesParaUser and [MensajesDeUser] = @MensajesDeUser and [MensajesID] = @MensajesID and [MensajesCodRef] > @MensajesCodRef) ORDER BY [MensajesID], [MensajesDeUser], [MensajesParaUser], [MensajesCodRef]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001I6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001I7", "SELECT TOP 1 [MensajesID], [MensajesDeUser], [MensajesParaUser], [MensajesCodRef] FROM [Mensajes] WHERE ( [MensajesID] < @MensajesID or [MensajesID] = @MensajesID and [MensajesDeUser] < @MensajesDeUser or [MensajesDeUser] = @MensajesDeUser and [MensajesID] = @MensajesID and [MensajesParaUser] < @MensajesParaUser or [MensajesParaUser] = @MensajesParaUser and [MensajesDeUser] = @MensajesDeUser and [MensajesID] = @MensajesID and [MensajesCodRef] < @MensajesCodRef) ORDER BY [MensajesID] DESC, [MensajesDeUser] DESC, [MensajesParaUser] DESC, [MensajesCodRef] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001I7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001I8", "INSERT INTO [Mensajes]([MensajesID], [MensajesDeUser], [MensajesParaUser], [MensajesCodRef], [MensajesMSG], [MensajesFecha]) VALUES(@MensajesID, @MensajesDeUser, @MensajesParaUser, @MensajesCodRef, @MensajesMSG, @MensajesFecha)", GxErrorMask.GX_NOMASK,prmT001I8)
           ,new CursorDef("T001I9", "UPDATE [Mensajes] SET [MensajesMSG]=@MensajesMSG, [MensajesFecha]=@MensajesFecha  WHERE [MensajesID] = @MensajesID AND [MensajesDeUser] = @MensajesDeUser AND [MensajesParaUser] = @MensajesParaUser AND [MensajesCodRef] = @MensajesCodRef", GxErrorMask.GX_NOMASK,prmT001I9)
           ,new CursorDef("T001I10", "DELETE FROM [Mensajes]  WHERE [MensajesID] = @MensajesID AND [MensajesDeUser] = @MensajesDeUser AND [MensajesParaUser] = @MensajesParaUser AND [MensajesCodRef] = @MensajesCodRef", GxErrorMask.GX_NOMASK,prmT001I10)
           ,new CursorDef("T001I11", "SELECT [MensajesID], [MensajesDeUser], [MensajesParaUser], [MensajesCodRef] FROM [Mensajes] ORDER BY [MensajesID], [MensajesDeUser], [MensajesParaUser], [MensajesCodRef]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001I11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              return;
     }
  }

}

}
