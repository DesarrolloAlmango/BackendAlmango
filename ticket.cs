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
   public class ticket : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A1021TicketMotivoId = (long)(Math.Round(NumberUtil.Val( GetPar( "TicketMotivoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1021TicketMotivoId", StringUtil.LTrimStr( (decimal)(A1021TicketMotivoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A1021TicketMotivoId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Ticket", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTicketId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public ticket( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ticket( IGxContext context )
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
         cmbTicketEstado = new GXCombobox();
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
         if ( cmbTicketEstado.ItemCount > 0 )
         {
            A1030TicketEstado = StringUtil.StrToBool( cmbTicketEstado.getValidValue(StringUtil.BoolToStr( A1030TicketEstado)));
            AssignAttri("", false, "A1030TicketEstado", A1030TicketEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTicketEstado.CurrentValue = StringUtil.BoolToStr( A1030TicketEstado);
            AssignProp("", false, cmbTicketEstado_Internalname, "Values", cmbTicketEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Ticket", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Ticket.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ticket.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ticket.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ticket.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ticket.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0440.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TICKETID"+"'), id:'"+"TICKETID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Ticket.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTicketId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTicketId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1020TicketId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtTicketId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1020TicketId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1020TicketId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTicketId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Ticket.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTicketSolicitudId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketSolicitudId_Internalname, context.GetMessage( "Solicitud Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTicketSolicitudId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1023TicketSolicitudId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtTicketSolicitudId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1023TicketSolicitudId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1023TicketSolicitudId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketSolicitudId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTicketSolicitudId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Ticket.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTicketMotivoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketMotivoId_Internalname, context.GetMessage( "Ticket Motivo Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTicketMotivoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1021TicketMotivoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtTicketMotivoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1021TicketMotivoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1021TicketMotivoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketMotivoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTicketMotivoId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Ticket.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_1021_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_1021_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1021_Internalname, sImgUrl, imgprompt_1021_Link, "", "", context.GetTheme( ), imgprompt_1021_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Ticket.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTicketMotivoDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketMotivoDescripcion_Internalname, context.GetMessage( "Ticket Motivo Descripcion", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTicketMotivoDescripcion_Internalname, StringUtil.RTrim( A1022TicketMotivoDescripcion), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtTicketMotivoDescripcion_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "Descripcion", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Ticket.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTicketEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTicketEstado_Internalname, context.GetMessage( "False Cerrado", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTicketEstado, cmbTicketEstado_Internalname, StringUtil.BoolToStr( A1030TicketEstado), 1, cmbTicketEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbTicketEstado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_Ticket.htm");
         cmbTicketEstado.CurrentValue = StringUtil.BoolToStr( A1030TicketEstado);
         AssignProp("", false, cmbTicketEstado_Internalname, "Values", (string)(cmbTicketEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTicketComentario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketComentario_Internalname, context.GetMessage( "Comentario", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTicketComentario_Internalname, StringUtil.RTrim( A1024TicketComentario), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtTicketComentario_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "Descripcion", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Ticket.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTicketAdjunto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketAdjunto_Internalname, context.GetMessage( "Adjunto", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTicketAdjunto_Internalname, StringUtil.RTrim( A1026TicketAdjunto), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtTicketAdjunto_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "Descripcion", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Ticket.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ticket.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ticket.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ticket.htm");
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
            Z1020TicketId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1020TicketId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z1023TicketSolicitudId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1023TicketSolicitudId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z1030TicketEstado = StringUtil.StrToBool( cgiGet( "Z1030TicketEstado"));
            Z1024TicketComentario = cgiGet( "Z1024TicketComentario");
            Z1026TicketAdjunto = cgiGet( "Z1026TicketAdjunto");
            Z1021TicketMotivoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1021TicketMotivoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTicketId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTicketId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TICKETID");
               AnyError = 1;
               GX_FocusControl = edtTicketId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1020TicketId = 0;
               n1020TicketId = false;
               AssignAttri("", false, "A1020TicketId", StringUtil.LTrimStr( (decimal)(A1020TicketId), 18, 0));
            }
            else
            {
               A1020TicketId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n1020TicketId = false;
               AssignAttri("", false, "A1020TicketId", StringUtil.LTrimStr( (decimal)(A1020TicketId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTicketSolicitudId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTicketSolicitudId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TICKETSOLICITUDID");
               AnyError = 1;
               GX_FocusControl = edtTicketSolicitudId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1023TicketSolicitudId = 0;
               AssignAttri("", false, "A1023TicketSolicitudId", StringUtil.LTrimStr( (decimal)(A1023TicketSolicitudId), 18, 0));
            }
            else
            {
               A1023TicketSolicitudId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTicketSolicitudId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1023TicketSolicitudId", StringUtil.LTrimStr( (decimal)(A1023TicketSolicitudId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTicketMotivoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTicketMotivoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TICKETMOTIVOID");
               AnyError = 1;
               GX_FocusControl = edtTicketMotivoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1021TicketMotivoId = 0;
               AssignAttri("", false, "A1021TicketMotivoId", StringUtil.LTrimStr( (decimal)(A1021TicketMotivoId), 18, 0));
            }
            else
            {
               A1021TicketMotivoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTicketMotivoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1021TicketMotivoId", StringUtil.LTrimStr( (decimal)(A1021TicketMotivoId), 18, 0));
            }
            A1022TicketMotivoDescripcion = cgiGet( edtTicketMotivoDescripcion_Internalname);
            AssignAttri("", false, "A1022TicketMotivoDescripcion", A1022TicketMotivoDescripcion);
            cmbTicketEstado.CurrentValue = cgiGet( cmbTicketEstado_Internalname);
            A1030TicketEstado = StringUtil.StrToBool( cgiGet( cmbTicketEstado_Internalname));
            AssignAttri("", false, "A1030TicketEstado", A1030TicketEstado);
            A1024TicketComentario = cgiGet( edtTicketComentario_Internalname);
            AssignAttri("", false, "A1024TicketComentario", A1024TicketComentario);
            A1026TicketAdjunto = cgiGet( edtTicketAdjunto_Internalname);
            AssignAttri("", false, "A1026TicketAdjunto", A1026TicketAdjunto);
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
               A1020TicketId = (long)(Math.Round(NumberUtil.Val( GetPar( "TicketId"), "."), 18, MidpointRounding.ToEven));
               n1020TicketId = false;
               AssignAttri("", false, "A1020TicketId", StringUtil.LTrimStr( (decimal)(A1020TicketId), 18, 0));
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
               InitAll31148( ) ;
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
         DisableAttributes31148( ) ;
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

      protected void ResetCaption310( )
      {
      }

      protected void ZM31148( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1023TicketSolicitudId = T00313_A1023TicketSolicitudId[0];
               Z1030TicketEstado = T00313_A1030TicketEstado[0];
               Z1024TicketComentario = T00313_A1024TicketComentario[0];
               Z1026TicketAdjunto = T00313_A1026TicketAdjunto[0];
               Z1021TicketMotivoId = T00313_A1021TicketMotivoId[0];
            }
            else
            {
               Z1023TicketSolicitudId = A1023TicketSolicitudId;
               Z1030TicketEstado = A1030TicketEstado;
               Z1024TicketComentario = A1024TicketComentario;
               Z1026TicketAdjunto = A1026TicketAdjunto;
               Z1021TicketMotivoId = A1021TicketMotivoId;
            }
         }
         if ( GX_JID == -1 )
         {
            Z1020TicketId = A1020TicketId;
            Z1023TicketSolicitudId = A1023TicketSolicitudId;
            Z1030TicketEstado = A1030TicketEstado;
            Z1024TicketComentario = A1024TicketComentario;
            Z1026TicketAdjunto = A1026TicketAdjunto;
            Z1021TicketMotivoId = A1021TicketMotivoId;
            Z1022TicketMotivoDescripcion = A1022TicketMotivoDescripcion;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_1021_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0450.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TICKETMOTIVOID"+"'), id:'"+"TICKETMOTIVOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load31148( )
      {
         /* Using cursor T00315 */
         pr_default.execute(3, new Object[] {n1020TicketId, A1020TicketId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound148 = 1;
            A1023TicketSolicitudId = T00315_A1023TicketSolicitudId[0];
            AssignAttri("", false, "A1023TicketSolicitudId", StringUtil.LTrimStr( (decimal)(A1023TicketSolicitudId), 18, 0));
            A1022TicketMotivoDescripcion = T00315_A1022TicketMotivoDescripcion[0];
            AssignAttri("", false, "A1022TicketMotivoDescripcion", A1022TicketMotivoDescripcion);
            A1030TicketEstado = T00315_A1030TicketEstado[0];
            AssignAttri("", false, "A1030TicketEstado", A1030TicketEstado);
            A1024TicketComentario = T00315_A1024TicketComentario[0];
            AssignAttri("", false, "A1024TicketComentario", A1024TicketComentario);
            A1026TicketAdjunto = T00315_A1026TicketAdjunto[0];
            AssignAttri("", false, "A1026TicketAdjunto", A1026TicketAdjunto);
            A1021TicketMotivoId = T00315_A1021TicketMotivoId[0];
            AssignAttri("", false, "A1021TicketMotivoId", StringUtil.LTrimStr( (decimal)(A1021TicketMotivoId), 18, 0));
            ZM31148( -1) ;
         }
         pr_default.close(3);
         OnLoadActions31148( ) ;
      }

      protected void OnLoadActions31148( )
      {
      }

      protected void CheckExtendedTable31148( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00314 */
         pr_default.execute(2, new Object[] {A1021TicketMotivoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ticket Motivo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TICKETMOTIVOID");
            AnyError = 1;
            GX_FocusControl = edtTicketMotivoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1022TicketMotivoDescripcion = T00314_A1022TicketMotivoDescripcion[0];
         AssignAttri("", false, "A1022TicketMotivoDescripcion", A1022TicketMotivoDescripcion);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors31148( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( long A1021TicketMotivoId )
      {
         /* Using cursor T00316 */
         pr_default.execute(4, new Object[] {A1021TicketMotivoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ticket Motivo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TICKETMOTIVOID");
            AnyError = 1;
            GX_FocusControl = edtTicketMotivoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1022TicketMotivoDescripcion = T00316_A1022TicketMotivoDescripcion[0];
         AssignAttri("", false, "A1022TicketMotivoDescripcion", A1022TicketMotivoDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1022TicketMotivoDescripcion))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey31148( )
      {
         /* Using cursor T00317 */
         pr_default.execute(5, new Object[] {n1020TicketId, A1020TicketId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound148 = 1;
         }
         else
         {
            RcdFound148 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00313 */
         pr_default.execute(1, new Object[] {n1020TicketId, A1020TicketId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM31148( 1) ;
            RcdFound148 = 1;
            A1020TicketId = T00313_A1020TicketId[0];
            n1020TicketId = T00313_n1020TicketId[0];
            AssignAttri("", false, "A1020TicketId", StringUtil.LTrimStr( (decimal)(A1020TicketId), 18, 0));
            A1023TicketSolicitudId = T00313_A1023TicketSolicitudId[0];
            AssignAttri("", false, "A1023TicketSolicitudId", StringUtil.LTrimStr( (decimal)(A1023TicketSolicitudId), 18, 0));
            A1030TicketEstado = T00313_A1030TicketEstado[0];
            AssignAttri("", false, "A1030TicketEstado", A1030TicketEstado);
            A1024TicketComentario = T00313_A1024TicketComentario[0];
            AssignAttri("", false, "A1024TicketComentario", A1024TicketComentario);
            A1026TicketAdjunto = T00313_A1026TicketAdjunto[0];
            AssignAttri("", false, "A1026TicketAdjunto", A1026TicketAdjunto);
            A1021TicketMotivoId = T00313_A1021TicketMotivoId[0];
            AssignAttri("", false, "A1021TicketMotivoId", StringUtil.LTrimStr( (decimal)(A1021TicketMotivoId), 18, 0));
            Z1020TicketId = A1020TicketId;
            sMode148 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load31148( ) ;
            if ( AnyError == 1 )
            {
               RcdFound148 = 0;
               InitializeNonKey31148( ) ;
            }
            Gx_mode = sMode148;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound148 = 0;
            InitializeNonKey31148( ) ;
            sMode148 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode148;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey31148( ) ;
         if ( RcdFound148 == 0 )
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
         RcdFound148 = 0;
         /* Using cursor T00318 */
         pr_default.execute(6, new Object[] {n1020TicketId, A1020TicketId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00318_A1020TicketId[0] < A1020TicketId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00318_A1020TicketId[0] > A1020TicketId ) ) )
            {
               A1020TicketId = T00318_A1020TicketId[0];
               n1020TicketId = T00318_n1020TicketId[0];
               AssignAttri("", false, "A1020TicketId", StringUtil.LTrimStr( (decimal)(A1020TicketId), 18, 0));
               RcdFound148 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound148 = 0;
         /* Using cursor T00319 */
         pr_default.execute(7, new Object[] {n1020TicketId, A1020TicketId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00319_A1020TicketId[0] > A1020TicketId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00319_A1020TicketId[0] < A1020TicketId ) ) )
            {
               A1020TicketId = T00319_A1020TicketId[0];
               n1020TicketId = T00319_n1020TicketId[0];
               AssignAttri("", false, "A1020TicketId", StringUtil.LTrimStr( (decimal)(A1020TicketId), 18, 0));
               RcdFound148 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey31148( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTicketId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert31148( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound148 == 1 )
            {
               if ( A1020TicketId != Z1020TicketId )
               {
                  A1020TicketId = Z1020TicketId;
                  n1020TicketId = false;
                  AssignAttri("", false, "A1020TicketId", StringUtil.LTrimStr( (decimal)(A1020TicketId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TICKETID");
                  AnyError = 1;
                  GX_FocusControl = edtTicketId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTicketId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update31148( ) ;
                  GX_FocusControl = edtTicketId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1020TicketId != Z1020TicketId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTicketId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert31148( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TICKETID");
                     AnyError = 1;
                     GX_FocusControl = edtTicketId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTicketId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert31148( ) ;
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
         if ( A1020TicketId != Z1020TicketId )
         {
            A1020TicketId = Z1020TicketId;
            n1020TicketId = false;
            AssignAttri("", false, "A1020TicketId", StringUtil.LTrimStr( (decimal)(A1020TicketId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TICKETID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTicketId_Internalname;
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
         if ( RcdFound148 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TICKETID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTicketSolicitudId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart31148( ) ;
         if ( RcdFound148 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTicketSolicitudId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd31148( ) ;
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
         if ( RcdFound148 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTicketSolicitudId_Internalname;
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
         if ( RcdFound148 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTicketSolicitudId_Internalname;
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
         ScanStart31148( ) ;
         if ( RcdFound148 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound148 != 0 )
            {
               ScanNext31148( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTicketSolicitudId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd31148( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency31148( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00312 */
            pr_default.execute(0, new Object[] {n1020TicketId, A1020TicketId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ticket"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1023TicketSolicitudId != T00312_A1023TicketSolicitudId[0] ) || ( Z1030TicketEstado != T00312_A1030TicketEstado[0] ) || ( StringUtil.StrCmp(Z1024TicketComentario, T00312_A1024TicketComentario[0]) != 0 ) || ( StringUtil.StrCmp(Z1026TicketAdjunto, T00312_A1026TicketAdjunto[0]) != 0 ) || ( Z1021TicketMotivoId != T00312_A1021TicketMotivoId[0] ) )
            {
               if ( Z1023TicketSolicitudId != T00312_A1023TicketSolicitudId[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketSolicitudId");
                  GXUtil.WriteLogRaw("Old: ",Z1023TicketSolicitudId);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1023TicketSolicitudId[0]);
               }
               if ( Z1030TicketEstado != T00312_A1030TicketEstado[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketEstado");
                  GXUtil.WriteLogRaw("Old: ",Z1030TicketEstado);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1030TicketEstado[0]);
               }
               if ( StringUtil.StrCmp(Z1024TicketComentario, T00312_A1024TicketComentario[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketComentario");
                  GXUtil.WriteLogRaw("Old: ",Z1024TicketComentario);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1024TicketComentario[0]);
               }
               if ( StringUtil.StrCmp(Z1026TicketAdjunto, T00312_A1026TicketAdjunto[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketAdjunto");
                  GXUtil.WriteLogRaw("Old: ",Z1026TicketAdjunto);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1026TicketAdjunto[0]);
               }
               if ( Z1021TicketMotivoId != T00312_A1021TicketMotivoId[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketMotivoId");
                  GXUtil.WriteLogRaw("Old: ",Z1021TicketMotivoId);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1021TicketMotivoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Ticket"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert31148( )
      {
         BeforeValidate31148( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable31148( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM31148( 0) ;
            CheckOptimisticConcurrency31148( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm31148( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert31148( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003110 */
                     pr_default.execute(8, new Object[] {A1023TicketSolicitudId, A1030TicketEstado, A1024TicketComentario, A1026TicketAdjunto, A1021TicketMotivoId});
                     A1020TicketId = T003110_A1020TicketId[0];
                     n1020TicketId = T003110_n1020TicketId[0];
                     AssignAttri("", false, "A1020TicketId", StringUtil.LTrimStr( (decimal)(A1020TicketId), 18, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Ticket");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption310( ) ;
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
               Load31148( ) ;
            }
            EndLevel31148( ) ;
         }
         CloseExtendedTableCursors31148( ) ;
      }

      protected void Update31148( )
      {
         BeforeValidate31148( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable31148( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency31148( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm31148( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate31148( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003111 */
                     pr_default.execute(9, new Object[] {A1023TicketSolicitudId, A1030TicketEstado, A1024TicketComentario, A1026TicketAdjunto, A1021TicketMotivoId, n1020TicketId, A1020TicketId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Ticket");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ticket"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate31148( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption310( ) ;
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
            EndLevel31148( ) ;
         }
         CloseExtendedTableCursors31148( ) ;
      }

      protected void DeferredUpdate31148( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate31148( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency31148( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls31148( ) ;
            AfterConfirm31148( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete31148( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003112 */
                  pr_default.execute(10, new Object[] {n1020TicketId, A1020TicketId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Ticket");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound148 == 0 )
                        {
                           InitAll31148( ) ;
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
                        ResetCaption310( ) ;
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
         sMode148 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel31148( ) ;
         Gx_mode = sMode148;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls31148( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003113 */
            pr_default.execute(11, new Object[] {A1021TicketMotivoId});
            A1022TicketMotivoDescripcion = T003113_A1022TicketMotivoDescripcion[0];
            AssignAttri("", false, "A1022TicketMotivoDescripcion", A1022TicketMotivoDescripcion);
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T003114 */
            pr_default.execute(12, new Object[] {n1020TicketId, A1020TicketId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel31148( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete31148( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("ticket",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues310( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("ticket",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart31148( )
      {
         /* Using cursor T003115 */
         pr_default.execute(13);
         RcdFound148 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound148 = 1;
            A1020TicketId = T003115_A1020TicketId[0];
            n1020TicketId = T003115_n1020TicketId[0];
            AssignAttri("", false, "A1020TicketId", StringUtil.LTrimStr( (decimal)(A1020TicketId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext31148( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound148 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound148 = 1;
            A1020TicketId = T003115_A1020TicketId[0];
            n1020TicketId = T003115_n1020TicketId[0];
            AssignAttri("", false, "A1020TicketId", StringUtil.LTrimStr( (decimal)(A1020TicketId), 18, 0));
         }
      }

      protected void ScanEnd31148( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm31148( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert31148( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate31148( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete31148( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete31148( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate31148( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes31148( )
      {
         edtTicketId_Enabled = 0;
         AssignProp("", false, edtTicketId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketId_Enabled), 5, 0), true);
         edtTicketSolicitudId_Enabled = 0;
         AssignProp("", false, edtTicketSolicitudId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketSolicitudId_Enabled), 5, 0), true);
         edtTicketMotivoId_Enabled = 0;
         AssignProp("", false, edtTicketMotivoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketMotivoId_Enabled), 5, 0), true);
         edtTicketMotivoDescripcion_Enabled = 0;
         AssignProp("", false, edtTicketMotivoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketMotivoDescripcion_Enabled), 5, 0), true);
         cmbTicketEstado.Enabled = 0;
         AssignProp("", false, cmbTicketEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTicketEstado.Enabled), 5, 0), true);
         edtTicketComentario_Enabled = 0;
         AssignProp("", false, edtTicketComentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketComentario_Enabled), 5, 0), true);
         edtTicketAdjunto_Enabled = 0;
         AssignProp("", false, edtTicketAdjunto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketAdjunto_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes31148( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues310( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ticket.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z1020TicketId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1020TicketId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z1023TicketSolicitudId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1023TicketSolicitudId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z1030TicketEstado", Z1030TicketEstado);
         GxWebStd.gx_hidden_field( context, "Z1024TicketComentario", StringUtil.RTrim( Z1024TicketComentario));
         GxWebStd.gx_hidden_field( context, "Z1026TicketAdjunto", StringUtil.RTrim( Z1026TicketAdjunto));
         GxWebStd.gx_hidden_field( context, "Z1021TicketMotivoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1021TicketMotivoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("ticket.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Ticket" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Ticket", "") ;
      }

      protected void InitializeNonKey31148( )
      {
         A1023TicketSolicitudId = 0;
         AssignAttri("", false, "A1023TicketSolicitudId", StringUtil.LTrimStr( (decimal)(A1023TicketSolicitudId), 18, 0));
         A1021TicketMotivoId = 0;
         AssignAttri("", false, "A1021TicketMotivoId", StringUtil.LTrimStr( (decimal)(A1021TicketMotivoId), 18, 0));
         A1022TicketMotivoDescripcion = "";
         AssignAttri("", false, "A1022TicketMotivoDescripcion", A1022TicketMotivoDescripcion);
         A1030TicketEstado = false;
         AssignAttri("", false, "A1030TicketEstado", A1030TicketEstado);
         A1024TicketComentario = "";
         AssignAttri("", false, "A1024TicketComentario", A1024TicketComentario);
         A1026TicketAdjunto = "";
         AssignAttri("", false, "A1026TicketAdjunto", A1026TicketAdjunto);
         Z1023TicketSolicitudId = 0;
         Z1030TicketEstado = false;
         Z1024TicketComentario = "";
         Z1026TicketAdjunto = "";
         Z1021TicketMotivoId = 0;
      }

      protected void InitAll31148( )
      {
         A1020TicketId = 0;
         n1020TicketId = false;
         AssignAttri("", false, "A1020TicketId", StringUtil.LTrimStr( (decimal)(A1020TicketId), 18, 0));
         InitializeNonKey31148( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202693020462844", true, true, false);
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
         context.AddJavascriptSource("ticket.js", "?202693020462845", false, true, false);
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
         edtTicketId_Internalname = "TICKETID";
         edtTicketSolicitudId_Internalname = "TICKETSOLICITUDID";
         edtTicketMotivoId_Internalname = "TICKETMOTIVOID";
         edtTicketMotivoDescripcion_Internalname = "TICKETMOTIVODESCRIPCION";
         cmbTicketEstado_Internalname = "TICKETESTADO";
         edtTicketComentario_Internalname = "TICKETCOMENTARIO";
         edtTicketAdjunto_Internalname = "TICKETADJUNTO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_1021_Internalname = "PROMPT_1021";
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
         Form.Caption = context.GetMessage( "Ticket", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTicketAdjunto_Enabled = 1;
         edtTicketComentario_Enabled = 1;
         cmbTicketEstado_Jsonclick = "";
         cmbTicketEstado.Enabled = 1;
         edtTicketMotivoDescripcion_Enabled = 0;
         imgprompt_1021_Visible = 1;
         imgprompt_1021_Link = "";
         edtTicketMotivoId_Jsonclick = "";
         edtTicketMotivoId_Enabled = 1;
         edtTicketSolicitudId_Jsonclick = "";
         edtTicketSolicitudId_Enabled = 1;
         edtTicketId_Jsonclick = "";
         edtTicketId_Enabled = 1;
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
         cmbTicketEstado.Name = "TICKETESTADO";
         cmbTicketEstado.WebTags = "";
         cmbTicketEstado.addItem(StringUtil.BoolToStr( true), context.GetMessage( "true", ""), 0);
         cmbTicketEstado.addItem(StringUtil.BoolToStr( false), context.GetMessage( "false", ""), 0);
         if ( cmbTicketEstado.ItemCount > 0 )
         {
            A1030TicketEstado = StringUtil.StrToBool( cmbTicketEstado.getValidValue(StringUtil.BoolToStr( A1030TicketEstado)));
            AssignAttri("", false, "A1030TicketEstado", A1030TicketEstado);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTicketSolicitudId_Internalname;
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

      public void Valid_Ticketid( )
      {
         A1030TicketEstado = StringUtil.StrToBool( cmbTicketEstado.CurrentValue);
         cmbTicketEstado.CurrentValue = StringUtil.BoolToStr( A1030TicketEstado);
         n1020TicketId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbTicketEstado.ItemCount > 0 )
         {
            A1030TicketEstado = StringUtil.StrToBool( cmbTicketEstado.getValidValue(StringUtil.BoolToStr( A1030TicketEstado)));
            cmbTicketEstado.CurrentValue = StringUtil.BoolToStr( A1030TicketEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTicketEstado.CurrentValue = StringUtil.BoolToStr( A1030TicketEstado);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1023TicketSolicitudId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1023TicketSolicitudId), 18, 0, ".", "")));
         AssignAttri("", false, "A1021TicketMotivoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1021TicketMotivoId), 18, 0, ".", "")));
         AssignAttri("", false, "A1030TicketEstado", A1030TicketEstado);
         cmbTicketEstado.CurrentValue = StringUtil.BoolToStr( A1030TicketEstado);
         AssignProp("", false, cmbTicketEstado_Internalname, "Values", cmbTicketEstado.ToJavascriptSource(), true);
         AssignAttri("", false, "A1024TicketComentario", StringUtil.RTrim( A1024TicketComentario));
         AssignAttri("", false, "A1026TicketAdjunto", StringUtil.RTrim( A1026TicketAdjunto));
         AssignAttri("", false, "A1022TicketMotivoDescripcion", StringUtil.RTrim( A1022TicketMotivoDescripcion));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z1020TicketId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1020TicketId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1023TicketSolicitudId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1023TicketSolicitudId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1021TicketMotivoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1021TicketMotivoId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1030TicketEstado", StringUtil.BoolToStr( Z1030TicketEstado));
         GxWebStd.gx_hidden_field( context, "Z1024TicketComentario", StringUtil.RTrim( Z1024TicketComentario));
         GxWebStd.gx_hidden_field( context, "Z1026TicketAdjunto", StringUtil.RTrim( Z1026TicketAdjunto));
         GxWebStd.gx_hidden_field( context, "Z1022TicketMotivoDescripcion", StringUtil.RTrim( Z1022TicketMotivoDescripcion));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Ticketmotivoid( )
      {
         /* Using cursor T003113 */
         pr_default.execute(11, new Object[] {A1021TicketMotivoId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ticket Motivo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TICKETMOTIVOID");
            AnyError = 1;
            GX_FocusControl = edtTicketMotivoId_Internalname;
         }
         A1022TicketMotivoDescripcion = T003113_A1022TicketMotivoDescripcion[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1022TicketMotivoDescripcion", StringUtil.RTrim( A1022TicketMotivoDescripcion));
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
         setEventMetadata("VALID_TICKETID","{handler:'Valid_Ticketid',iparms:[{av:'cmbTicketEstado'},{av:'A1030TicketEstado',fld:'TICKETESTADO',pic:'',type:'boolean'},{av:'A1020TicketId',fld:'TICKETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'}]");
         setEventMetadata("VALID_TICKETID",",oparms:[{av:'A1023TicketSolicitudId',fld:'TICKETSOLICITUDID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A1021TicketMotivoId',fld:'TICKETMOTIVOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbTicketEstado'},{av:'A1030TicketEstado',fld:'TICKETESTADO',pic:'',type:'boolean'},{av:'A1024TicketComentario',fld:'TICKETCOMENTARIO',pic:'',type:'char'},{av:'A1026TicketAdjunto',fld:'TICKETADJUNTO',pic:'',type:'char'},{av:'A1022TicketMotivoDescripcion',fld:'TICKETMOTIVODESCRIPCION',pic:'',type:'char'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z1020TicketId',type:'int'},{av:'Z1023TicketSolicitudId',type:'int'},{av:'Z1021TicketMotivoId',type:'int'},{av:'Z1030TicketEstado',type:'boolean'},{av:'Z1024TicketComentario',type:'char'},{av:'Z1026TicketAdjunto',type:'char'},{av:'Z1022TicketMotivoDescripcion',type:'char'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_TICKETMOTIVOID","{handler:'Valid_Ticketmotivoid',iparms:[{av:'A1021TicketMotivoId',fld:'TICKETMOTIVOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A1022TicketMotivoDescripcion',fld:'TICKETMOTIVODESCRIPCION',pic:'',type:'char'}]");
         setEventMetadata("VALID_TICKETMOTIVOID",",oparms:[{av:'A1022TicketMotivoDescripcion',fld:'TICKETMOTIVODESCRIPCION',pic:'',type:'char'}]}");
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
         Z1024TicketComentario = "";
         Z1026TicketAdjunto = "";
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
         imgprompt_1021_gximage = "";
         sImgUrl = "";
         A1022TicketMotivoDescripcion = "";
         A1024TicketComentario = "";
         A1026TicketAdjunto = "";
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
         Z1022TicketMotivoDescripcion = "";
         T00315_A1020TicketId = new long[1] ;
         T00315_n1020TicketId = new bool[] {false} ;
         T00315_A1023TicketSolicitudId = new long[1] ;
         T00315_A1022TicketMotivoDescripcion = new string[] {""} ;
         T00315_A1030TicketEstado = new bool[] {false} ;
         T00315_A1024TicketComentario = new string[] {""} ;
         T00315_A1026TicketAdjunto = new string[] {""} ;
         T00315_A1021TicketMotivoId = new long[1] ;
         T00314_A1022TicketMotivoDescripcion = new string[] {""} ;
         T00316_A1022TicketMotivoDescripcion = new string[] {""} ;
         T00317_A1020TicketId = new long[1] ;
         T00317_n1020TicketId = new bool[] {false} ;
         T00313_A1020TicketId = new long[1] ;
         T00313_n1020TicketId = new bool[] {false} ;
         T00313_A1023TicketSolicitudId = new long[1] ;
         T00313_A1030TicketEstado = new bool[] {false} ;
         T00313_A1024TicketComentario = new string[] {""} ;
         T00313_A1026TicketAdjunto = new string[] {""} ;
         T00313_A1021TicketMotivoId = new long[1] ;
         sMode148 = "";
         T00318_A1020TicketId = new long[1] ;
         T00318_n1020TicketId = new bool[] {false} ;
         T00319_A1020TicketId = new long[1] ;
         T00319_n1020TicketId = new bool[] {false} ;
         T00312_A1020TicketId = new long[1] ;
         T00312_n1020TicketId = new bool[] {false} ;
         T00312_A1023TicketSolicitudId = new long[1] ;
         T00312_A1030TicketEstado = new bool[] {false} ;
         T00312_A1024TicketComentario = new string[] {""} ;
         T00312_A1026TicketAdjunto = new string[] {""} ;
         T00312_A1021TicketMotivoId = new long[1] ;
         T003110_A1020TicketId = new long[1] ;
         T003110_n1020TicketId = new bool[] {false} ;
         T003113_A1022TicketMotivoDescripcion = new string[] {""} ;
         T003114_A127SolicitudesID = new long[1] ;
         T003115_A1020TicketId = new long[1] ;
         T003115_n1020TicketId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1024TicketComentario = "";
         ZZ1026TicketAdjunto = "";
         ZZ1022TicketMotivoDescripcion = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.ticket__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ticket__default(),
            new Object[][] {
                new Object[] {
               T00312_A1020TicketId, T00312_A1023TicketSolicitudId, T00312_A1030TicketEstado, T00312_A1024TicketComentario, T00312_A1026TicketAdjunto, T00312_A1021TicketMotivoId
               }
               , new Object[] {
               T00313_A1020TicketId, T00313_A1023TicketSolicitudId, T00313_A1030TicketEstado, T00313_A1024TicketComentario, T00313_A1026TicketAdjunto, T00313_A1021TicketMotivoId
               }
               , new Object[] {
               T00314_A1022TicketMotivoDescripcion
               }
               , new Object[] {
               T00315_A1020TicketId, T00315_A1023TicketSolicitudId, T00315_A1022TicketMotivoDescripcion, T00315_A1030TicketEstado, T00315_A1024TicketComentario, T00315_A1026TicketAdjunto, T00315_A1021TicketMotivoId
               }
               , new Object[] {
               T00316_A1022TicketMotivoDescripcion
               }
               , new Object[] {
               T00317_A1020TicketId
               }
               , new Object[] {
               T00318_A1020TicketId
               }
               , new Object[] {
               T00319_A1020TicketId
               }
               , new Object[] {
               T003110_A1020TicketId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003113_A1022TicketMotivoDescripcion
               }
               , new Object[] {
               T003114_A127SolicitudesID
               }
               , new Object[] {
               T003115_A1020TicketId
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound148 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTicketId_Enabled ;
      private int edtTicketSolicitudId_Enabled ;
      private int edtTicketMotivoId_Enabled ;
      private int imgprompt_1021_Visible ;
      private int edtTicketMotivoDescripcion_Enabled ;
      private int edtTicketComentario_Enabled ;
      private int edtTicketAdjunto_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z1020TicketId ;
      private long Z1023TicketSolicitudId ;
      private long Z1021TicketMotivoId ;
      private long A1021TicketMotivoId ;
      private long A1020TicketId ;
      private long A1023TicketSolicitudId ;
      private long ZZ1020TicketId ;
      private long ZZ1023TicketSolicitudId ;
      private long ZZ1021TicketMotivoId ;
      private string sPrefix ;
      private string Z1024TicketComentario ;
      private string Z1026TicketAdjunto ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTicketId_Internalname ;
      private string cmbTicketEstado_Internalname ;
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
      private string edtTicketId_Jsonclick ;
      private string edtTicketSolicitudId_Internalname ;
      private string edtTicketSolicitudId_Jsonclick ;
      private string edtTicketMotivoId_Internalname ;
      private string edtTicketMotivoId_Jsonclick ;
      private string imgprompt_1021_gximage ;
      private string sImgUrl ;
      private string imgprompt_1021_Internalname ;
      private string imgprompt_1021_Link ;
      private string edtTicketMotivoDescripcion_Internalname ;
      private string A1022TicketMotivoDescripcion ;
      private string cmbTicketEstado_Jsonclick ;
      private string edtTicketComentario_Internalname ;
      private string A1024TicketComentario ;
      private string edtTicketAdjunto_Internalname ;
      private string A1026TicketAdjunto ;
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
      private string Z1022TicketMotivoDescripcion ;
      private string sMode148 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1024TicketComentario ;
      private string ZZ1026TicketAdjunto ;
      private string ZZ1022TicketMotivoDescripcion ;
      private bool Z1030TicketEstado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A1030TicketEstado ;
      private bool n1020TicketId ;
      private bool ZZ1030TicketEstado ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTicketEstado ;
      private IDataStoreProvider pr_default ;
      private long[] T00315_A1020TicketId ;
      private bool[] T00315_n1020TicketId ;
      private long[] T00315_A1023TicketSolicitudId ;
      private string[] T00315_A1022TicketMotivoDescripcion ;
      private bool[] T00315_A1030TicketEstado ;
      private string[] T00315_A1024TicketComentario ;
      private string[] T00315_A1026TicketAdjunto ;
      private long[] T00315_A1021TicketMotivoId ;
      private string[] T00314_A1022TicketMotivoDescripcion ;
      private string[] T00316_A1022TicketMotivoDescripcion ;
      private long[] T00317_A1020TicketId ;
      private bool[] T00317_n1020TicketId ;
      private long[] T00313_A1020TicketId ;
      private bool[] T00313_n1020TicketId ;
      private long[] T00313_A1023TicketSolicitudId ;
      private bool[] T00313_A1030TicketEstado ;
      private string[] T00313_A1024TicketComentario ;
      private string[] T00313_A1026TicketAdjunto ;
      private long[] T00313_A1021TicketMotivoId ;
      private long[] T00318_A1020TicketId ;
      private bool[] T00318_n1020TicketId ;
      private long[] T00319_A1020TicketId ;
      private bool[] T00319_n1020TicketId ;
      private long[] T00312_A1020TicketId ;
      private bool[] T00312_n1020TicketId ;
      private long[] T00312_A1023TicketSolicitudId ;
      private bool[] T00312_A1030TicketEstado ;
      private string[] T00312_A1024TicketComentario ;
      private string[] T00312_A1026TicketAdjunto ;
      private long[] T00312_A1021TicketMotivoId ;
      private long[] T003110_A1020TicketId ;
      private bool[] T003110_n1020TicketId ;
      private string[] T003113_A1022TicketMotivoDescripcion ;
      private long[] T003114_A127SolicitudesID ;
      private long[] T003115_A1020TicketId ;
      private bool[] T003115_n1020TicketId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class ticket__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class ticket__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00312;
        prmT00312 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00313;
        prmT00313 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00314;
        prmT00314 = new Object[] {
        new ParDef("@TicketMotivoId",GXType.Decimal,18,0)
        };
        Object[] prmT00315;
        prmT00315 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00316;
        prmT00316 = new Object[] {
        new ParDef("@TicketMotivoId",GXType.Decimal,18,0)
        };
        Object[] prmT00317;
        prmT00317 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00318;
        prmT00318 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00319;
        prmT00319 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT003110;
        prmT003110 = new Object[] {
        new ParDef("@TicketSolicitudId",GXType.Decimal,18,0) ,
        new ParDef("@TicketEstado",GXType.Boolean,40,0) ,
        new ParDef("@TicketComentario",GXType.NChar,250,0) ,
        new ParDef("@TicketAdjunto",GXType.NChar,250,0) ,
        new ParDef("@TicketMotivoId",GXType.Decimal,18,0)
        };
        Object[] prmT003111;
        prmT003111 = new Object[] {
        new ParDef("@TicketSolicitudId",GXType.Decimal,18,0) ,
        new ParDef("@TicketEstado",GXType.Boolean,40,0) ,
        new ParDef("@TicketComentario",GXType.NChar,250,0) ,
        new ParDef("@TicketAdjunto",GXType.NChar,250,0) ,
        new ParDef("@TicketMotivoId",GXType.Decimal,18,0) ,
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT003112;
        prmT003112 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT003113;
        prmT003113 = new Object[] {
        new ParDef("@TicketMotivoId",GXType.Decimal,18,0)
        };
        Object[] prmT003114;
        prmT003114 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT003115;
        prmT003115 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00312", "SELECT [TicketId], [TicketSolicitudId], [TicketEstado], [TicketComentario], [TicketAdjunto], [TicketMotivoId] FROM [Ticket] WITH (UPDLOCK) WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00312,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00313", "SELECT [TicketId], [TicketSolicitudId], [TicketEstado], [TicketComentario], [TicketAdjunto], [TicketMotivoId] FROM [Ticket] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00313,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00314", "SELECT [TicketMotivoDescripcion] FROM [TicketMotivo] WHERE [TicketMotivoId] = @TicketMotivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00314,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00315", "SELECT TM1.[TicketId], TM1.[TicketSolicitudId], T2.[TicketMotivoDescripcion], TM1.[TicketEstado], TM1.[TicketComentario], TM1.[TicketAdjunto], TM1.[TicketMotivoId] FROM ([Ticket] TM1 INNER JOIN [TicketMotivo] T2 ON T2.[TicketMotivoId] = TM1.[TicketMotivoId]) WHERE TM1.[TicketId] = @TicketId ORDER BY TM1.[TicketId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00315,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00316", "SELECT [TicketMotivoDescripcion] FROM [TicketMotivo] WHERE [TicketMotivoId] = @TicketMotivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00316,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00317", "SELECT [TicketId] FROM [Ticket] WHERE [TicketId] = @TicketId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00317,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00318", "SELECT TOP 1 [TicketId] FROM [Ticket] WHERE ( [TicketId] > @TicketId) ORDER BY [TicketId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00318,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00319", "SELECT TOP 1 [TicketId] FROM [Ticket] WHERE ( [TicketId] < @TicketId) ORDER BY [TicketId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00319,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003110", "INSERT INTO [Ticket]([TicketSolicitudId], [TicketEstado], [TicketComentario], [TicketAdjunto], [TicketMotivoId]) VALUES(@TicketSolicitudId, @TicketEstado, @TicketComentario, @TicketAdjunto, @TicketMotivoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT003110,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003111", "UPDATE [Ticket] SET [TicketSolicitudId]=@TicketSolicitudId, [TicketEstado]=@TicketEstado, [TicketComentario]=@TicketComentario, [TicketAdjunto]=@TicketAdjunto, [TicketMotivoId]=@TicketMotivoId  WHERE [TicketId] = @TicketId", GxErrorMask.GX_NOMASK,prmT003111)
           ,new CursorDef("T003112", "DELETE FROM [Ticket]  WHERE [TicketId] = @TicketId", GxErrorMask.GX_NOMASK,prmT003112)
           ,new CursorDef("T003113", "SELECT [TicketMotivoDescripcion] FROM [TicketMotivo] WHERE [TicketMotivoId] = @TicketMotivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003113,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003114", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003114,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003115", "SELECT [TicketId] FROM [Ticket] ORDER BY [TicketId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003115,100, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 250);
              ((string[]) buf[4])[0] = rslt.getString(5, 250);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 250);
              ((string[]) buf[4])[0] = rslt.getString(5, 250);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 250);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 250);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 250);
              ((string[]) buf[5])[0] = rslt.getString(6, 250);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 250);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 250);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
