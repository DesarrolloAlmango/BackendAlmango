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
namespace GeneXus.Programs.apis {
   public class token : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A145usuariosId = GetPar( "usuariosId");
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A145usuariosId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Token", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTokenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public token( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public token( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Token", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_APIs/Token.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_APIs/Token.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_APIs/Token.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_APIs/Token.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_APIs/Token.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"apis.gx03o0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TOKENID"+"'), id:'"+"TOKENID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_APIs/Token.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTokenId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTokenId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTokenId_Internalname, StringUtil.RTrim( A899TokenId), StringUtil.RTrim( context.localUtil.Format( A899TokenId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTokenId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTokenId_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_APIs/Token.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTokenFechaAlta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTokenFechaAlta_Internalname, context.GetMessage( "Fecha Alta", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTokenFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTokenFechaAlta_Internalname, context.localUtil.TToC( A905TokenFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A905TokenFechaAlta, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTokenFechaAlta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTokenFechaAlta_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_APIs/Token.htm");
         GxWebStd.gx_bitmap( context, edtTokenFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTokenFechaAlta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_APIs/Token.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTokenFechaExpiracion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTokenFechaExpiracion_Internalname, context.GetMessage( "Fecha Expiracion", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTokenFechaExpiracion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTokenFechaExpiracion_Internalname, context.localUtil.TToC( A904TokenFechaExpiracion, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A904TokenFechaExpiracion, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTokenFechaExpiracion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTokenFechaExpiracion_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_APIs/Token.htm");
         GxWebStd.gx_bitmap( context, edtTokenFechaExpiracion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTokenFechaExpiracion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_APIs/Token.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtusuariosId_Internalname, context.GetMessage( "NickName", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtusuariosId_Internalname, StringUtil.RTrim( A145usuariosId), StringUtil.RTrim( context.localUtil.Format( A145usuariosId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtusuariosId_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "NickName", "start", true, "", "HLP_APIs/Token.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_145_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_145_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_145_Internalname, sImgUrl, imgprompt_145_Link, "", "", context.GetTheme( ), imgprompt_145_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_APIs/Token.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTokenRequests_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTokenRequests_Internalname, context.GetMessage( "Requests", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTokenRequests_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A903TokenRequests), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtTokenRequests_Enabled!=0) ? context.localUtil.Format( (decimal)(A903TokenRequests), "ZZZ9") : context.localUtil.Format( (decimal)(A903TokenRequests), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTokenRequests_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTokenRequests_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_APIs/Token.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_APIs/Token.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_APIs/Token.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_APIs/Token.htm");
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
            Z899TokenId = cgiGet( "Z899TokenId");
            Z905TokenFechaAlta = context.localUtil.CToT( cgiGet( "Z905TokenFechaAlta"), 0);
            Z904TokenFechaExpiracion = context.localUtil.CToT( cgiGet( "Z904TokenFechaExpiracion"), 0);
            Z903TokenRequests = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z903TokenRequests"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z145usuariosId = cgiGet( "Z145usuariosId");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A899TokenId = cgiGet( edtTokenId_Internalname);
            AssignAttri("", false, "A899TokenId", A899TokenId);
            if ( context.localUtil.VCDateTime( cgiGet( edtTokenFechaAlta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Token Fecha Alta", "")}), 1, "TOKENFECHAALTA");
               AnyError = 1;
               GX_FocusControl = edtTokenFechaAlta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A905TokenFechaAlta = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A905TokenFechaAlta", context.localUtil.TToC( A905TokenFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A905TokenFechaAlta = context.localUtil.CToT( cgiGet( edtTokenFechaAlta_Internalname));
               AssignAttri("", false, "A905TokenFechaAlta", context.localUtil.TToC( A905TokenFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtTokenFechaExpiracion_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Token Fecha Expiracion", "")}), 1, "TOKENFECHAEXPIRACION");
               AnyError = 1;
               GX_FocusControl = edtTokenFechaExpiracion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A904TokenFechaExpiracion = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A904TokenFechaExpiracion", context.localUtil.TToC( A904TokenFechaExpiracion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A904TokenFechaExpiracion = context.localUtil.CToT( cgiGet( edtTokenFechaExpiracion_Internalname));
               AssignAttri("", false, "A904TokenFechaExpiracion", context.localUtil.TToC( A904TokenFechaExpiracion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A145usuariosId = cgiGet( edtusuariosId_Internalname);
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTokenRequests_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTokenRequests_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TOKENREQUESTS");
               AnyError = 1;
               GX_FocusControl = edtTokenRequests_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A903TokenRequests = 0;
               AssignAttri("", false, "A903TokenRequests", StringUtil.LTrimStr( (decimal)(A903TokenRequests), 4, 0));
            }
            else
            {
               A903TokenRequests = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTokenRequests_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A903TokenRequests", StringUtil.LTrimStr( (decimal)(A903TokenRequests), 4, 0));
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
               A899TokenId = GetPar( "TokenId");
               AssignAttri("", false, "A899TokenId", A899TokenId);
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
               InitAll2S132( ) ;
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
         DisableAttributes2S132( ) ;
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

      protected void ResetCaption2S0( )
      {
      }

      protected void ZM2S132( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z905TokenFechaAlta = T002S3_A905TokenFechaAlta[0];
               Z904TokenFechaExpiracion = T002S3_A904TokenFechaExpiracion[0];
               Z903TokenRequests = T002S3_A903TokenRequests[0];
               Z145usuariosId = T002S3_A145usuariosId[0];
            }
            else
            {
               Z905TokenFechaAlta = A905TokenFechaAlta;
               Z904TokenFechaExpiracion = A904TokenFechaExpiracion;
               Z903TokenRequests = A903TokenRequests;
               Z145usuariosId = A145usuariosId;
            }
         }
         if ( GX_JID == -3 )
         {
            Z899TokenId = A899TokenId;
            Z905TokenFechaAlta = A905TokenFechaAlta;
            Z904TokenFechaExpiracion = A904TokenFechaExpiracion;
            Z903TokenRequests = A903TokenRequests;
            Z145usuariosId = A145usuariosId;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_145_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0190.aspx"+"',["+"{Ctrl:gx.dom.el('"+"USUARIOSID"+"'), id:'"+"USUARIOSID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load2S132( )
      {
         /* Using cursor T002S5 */
         pr_default.execute(3, new Object[] {A899TokenId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound132 = 1;
            A905TokenFechaAlta = T002S5_A905TokenFechaAlta[0];
            AssignAttri("", false, "A905TokenFechaAlta", context.localUtil.TToC( A905TokenFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A904TokenFechaExpiracion = T002S5_A904TokenFechaExpiracion[0];
            AssignAttri("", false, "A904TokenFechaExpiracion", context.localUtil.TToC( A904TokenFechaExpiracion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A903TokenRequests = T002S5_A903TokenRequests[0];
            AssignAttri("", false, "A903TokenRequests", StringUtil.LTrimStr( (decimal)(A903TokenRequests), 4, 0));
            A145usuariosId = T002S5_A145usuariosId[0];
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
            ZM2S132( -3) ;
         }
         pr_default.close(3);
         OnLoadActions2S132( ) ;
      }

      protected void OnLoadActions2S132( )
      {
      }

      protected void CheckExtendedTable2S132( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A905TokenFechaAlta) || ( A905TokenFechaAlta >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Token Fecha Alta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "TOKENFECHAALTA");
            AnyError = 1;
            GX_FocusControl = edtTokenFechaAlta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A904TokenFechaExpiracion) || ( A904TokenFechaExpiracion >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Token Fecha Expiracion", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "TOKENFECHAEXPIRACION");
            AnyError = 1;
            GX_FocusControl = edtTokenFechaExpiracion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002S4 */
         pr_default.execute(2, new Object[] {A145usuariosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "usuarios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOSID");
            AnyError = 1;
            GX_FocusControl = edtusuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors2S132( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A145usuariosId )
      {
         /* Using cursor T002S6 */
         pr_default.execute(4, new Object[] {A145usuariosId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "usuarios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOSID");
            AnyError = 1;
            GX_FocusControl = edtusuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey2S132( )
      {
         /* Using cursor T002S7 */
         pr_default.execute(5, new Object[] {A899TokenId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound132 = 1;
         }
         else
         {
            RcdFound132 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002S3 */
         pr_default.execute(1, new Object[] {A899TokenId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2S132( 3) ;
            RcdFound132 = 1;
            A899TokenId = T002S3_A899TokenId[0];
            AssignAttri("", false, "A899TokenId", A899TokenId);
            A905TokenFechaAlta = T002S3_A905TokenFechaAlta[0];
            AssignAttri("", false, "A905TokenFechaAlta", context.localUtil.TToC( A905TokenFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A904TokenFechaExpiracion = T002S3_A904TokenFechaExpiracion[0];
            AssignAttri("", false, "A904TokenFechaExpiracion", context.localUtil.TToC( A904TokenFechaExpiracion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A903TokenRequests = T002S3_A903TokenRequests[0];
            AssignAttri("", false, "A903TokenRequests", StringUtil.LTrimStr( (decimal)(A903TokenRequests), 4, 0));
            A145usuariosId = T002S3_A145usuariosId[0];
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
            Z899TokenId = A899TokenId;
            sMode132 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2S132( ) ;
            if ( AnyError == 1 )
            {
               RcdFound132 = 0;
               InitializeNonKey2S132( ) ;
            }
            Gx_mode = sMode132;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound132 = 0;
            InitializeNonKey2S132( ) ;
            sMode132 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode132;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2S132( ) ;
         if ( RcdFound132 == 0 )
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
         RcdFound132 = 0;
         /* Using cursor T002S8 */
         pr_default.execute(6, new Object[] {A899TokenId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T002S8_A899TokenId[0], A899TokenId) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T002S8_A899TokenId[0], A899TokenId) > 0 ) ) )
            {
               A899TokenId = T002S8_A899TokenId[0];
               AssignAttri("", false, "A899TokenId", A899TokenId);
               RcdFound132 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound132 = 0;
         /* Using cursor T002S9 */
         pr_default.execute(7, new Object[] {A899TokenId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T002S9_A899TokenId[0], A899TokenId) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T002S9_A899TokenId[0], A899TokenId) < 0 ) ) )
            {
               A899TokenId = T002S9_A899TokenId[0];
               AssignAttri("", false, "A899TokenId", A899TokenId);
               RcdFound132 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2S132( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTokenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2S132( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound132 == 1 )
            {
               if ( StringUtil.StrCmp(A899TokenId, Z899TokenId) != 0 )
               {
                  A899TokenId = Z899TokenId;
                  AssignAttri("", false, "A899TokenId", A899TokenId);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TOKENID");
                  AnyError = 1;
                  GX_FocusControl = edtTokenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTokenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2S132( ) ;
                  GX_FocusControl = edtTokenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A899TokenId, Z899TokenId) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTokenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2S132( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TOKENID");
                     AnyError = 1;
                     GX_FocusControl = edtTokenId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTokenId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2S132( ) ;
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
         if ( StringUtil.StrCmp(A899TokenId, Z899TokenId) != 0 )
         {
            A899TokenId = Z899TokenId;
            AssignAttri("", false, "A899TokenId", A899TokenId);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TOKENID");
            AnyError = 1;
            GX_FocusControl = edtTokenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTokenId_Internalname;
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
         if ( RcdFound132 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TOKENID");
            AnyError = 1;
            GX_FocusControl = edtTokenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTokenFechaAlta_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2S132( ) ;
         if ( RcdFound132 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTokenFechaAlta_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2S132( ) ;
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
         if ( RcdFound132 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTokenFechaAlta_Internalname;
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
         if ( RcdFound132 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTokenFechaAlta_Internalname;
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
         ScanStart2S132( ) ;
         if ( RcdFound132 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound132 != 0 )
            {
               ScanNext2S132( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTokenFechaAlta_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2S132( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2S132( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002S2 */
            pr_default.execute(0, new Object[] {A899TokenId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Token"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z905TokenFechaAlta != T002S2_A905TokenFechaAlta[0] ) || ( Z904TokenFechaExpiracion != T002S2_A904TokenFechaExpiracion[0] ) || ( Z903TokenRequests != T002S2_A903TokenRequests[0] ) || ( StringUtil.StrCmp(Z145usuariosId, T002S2_A145usuariosId[0]) != 0 ) )
            {
               if ( Z905TokenFechaAlta != T002S2_A905TokenFechaAlta[0] )
               {
                  GXUtil.WriteLog("apis.token:[seudo value changed for attri]"+"TokenFechaAlta");
                  GXUtil.WriteLogRaw("Old: ",Z905TokenFechaAlta);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A905TokenFechaAlta[0]);
               }
               if ( Z904TokenFechaExpiracion != T002S2_A904TokenFechaExpiracion[0] )
               {
                  GXUtil.WriteLog("apis.token:[seudo value changed for attri]"+"TokenFechaExpiracion");
                  GXUtil.WriteLogRaw("Old: ",Z904TokenFechaExpiracion);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A904TokenFechaExpiracion[0]);
               }
               if ( Z903TokenRequests != T002S2_A903TokenRequests[0] )
               {
                  GXUtil.WriteLog("apis.token:[seudo value changed for attri]"+"TokenRequests");
                  GXUtil.WriteLogRaw("Old: ",Z903TokenRequests);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A903TokenRequests[0]);
               }
               if ( StringUtil.StrCmp(Z145usuariosId, T002S2_A145usuariosId[0]) != 0 )
               {
                  GXUtil.WriteLog("apis.token:[seudo value changed for attri]"+"usuariosId");
                  GXUtil.WriteLogRaw("Old: ",Z145usuariosId);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A145usuariosId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Token"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2S132( )
      {
         BeforeValidate2S132( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2S132( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2S132( 0) ;
            CheckOptimisticConcurrency2S132( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2S132( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2S132( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002S10 */
                     pr_default.execute(8, new Object[] {A899TokenId, A905TokenFechaAlta, A904TokenFechaExpiracion, A903TokenRequests, A145usuariosId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Token");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ResetCaption2S0( ) ;
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
               Load2S132( ) ;
            }
            EndLevel2S132( ) ;
         }
         CloseExtendedTableCursors2S132( ) ;
      }

      protected void Update2S132( )
      {
         BeforeValidate2S132( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2S132( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2S132( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2S132( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2S132( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002S11 */
                     pr_default.execute(9, new Object[] {A905TokenFechaAlta, A904TokenFechaExpiracion, A903TokenRequests, A145usuariosId, A899TokenId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Token");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Token"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2S132( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2S0( ) ;
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
            EndLevel2S132( ) ;
         }
         CloseExtendedTableCursors2S132( ) ;
      }

      protected void DeferredUpdate2S132( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2S132( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2S132( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2S132( ) ;
            AfterConfirm2S132( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2S132( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002S12 */
                  pr_default.execute(10, new Object[] {A899TokenId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Token");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound132 == 0 )
                        {
                           InitAll2S132( ) ;
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
                        ResetCaption2S0( ) ;
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
         sMode132 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2S132( ) ;
         Gx_mode = sMode132;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2S132( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2S132( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2S132( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("apis.token",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2S0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("apis.token",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2S132( )
      {
         /* Using cursor T002S13 */
         pr_default.execute(11);
         RcdFound132 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound132 = 1;
            A899TokenId = T002S13_A899TokenId[0];
            AssignAttri("", false, "A899TokenId", A899TokenId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2S132( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound132 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound132 = 1;
            A899TokenId = T002S13_A899TokenId[0];
            AssignAttri("", false, "A899TokenId", A899TokenId);
         }
      }

      protected void ScanEnd2S132( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm2S132( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2S132( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2S132( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2S132( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2S132( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2S132( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2S132( )
      {
         edtTokenId_Enabled = 0;
         AssignProp("", false, edtTokenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTokenId_Enabled), 5, 0), true);
         edtTokenFechaAlta_Enabled = 0;
         AssignProp("", false, edtTokenFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTokenFechaAlta_Enabled), 5, 0), true);
         edtTokenFechaExpiracion_Enabled = 0;
         AssignProp("", false, edtTokenFechaExpiracion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTokenFechaExpiracion_Enabled), 5, 0), true);
         edtusuariosId_Enabled = 0;
         AssignProp("", false, edtusuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosId_Enabled), 5, 0), true);
         edtTokenRequests_Enabled = 0;
         AssignProp("", false, edtTokenRequests_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTokenRequests_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2S132( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2S0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("apis.token.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z899TokenId", StringUtil.RTrim( Z899TokenId));
         GxWebStd.gx_hidden_field( context, "Z905TokenFechaAlta", context.localUtil.TToC( Z905TokenFechaAlta, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z904TokenFechaExpiracion", context.localUtil.TToC( Z904TokenFechaExpiracion, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z903TokenRequests", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z903TokenRequests), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z145usuariosId", StringUtil.RTrim( Z145usuariosId));
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
         return formatLink("apis.token.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "APIs.Token" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Token", "") ;
      }

      protected void InitializeNonKey2S132( )
      {
         A905TokenFechaAlta = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A905TokenFechaAlta", context.localUtil.TToC( A905TokenFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A904TokenFechaExpiracion = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A904TokenFechaExpiracion", context.localUtil.TToC( A904TokenFechaExpiracion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A145usuariosId = "";
         AssignAttri("", false, "A145usuariosId", A145usuariosId);
         A903TokenRequests = 0;
         AssignAttri("", false, "A903TokenRequests", StringUtil.LTrimStr( (decimal)(A903TokenRequests), 4, 0));
         Z905TokenFechaAlta = (DateTime)(DateTime.MinValue);
         Z904TokenFechaExpiracion = (DateTime)(DateTime.MinValue);
         Z903TokenRequests = 0;
         Z145usuariosId = "";
      }

      protected void InitAll2S132( )
      {
         A899TokenId = "";
         AssignAttri("", false, "A899TokenId", A899TokenId);
         InitializeNonKey2S132( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021171342", true, true, false);
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
         context.AddJavascriptSource("apis/token.js", "?202673021171342", false, true, false);
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
         edtTokenId_Internalname = "TOKENID";
         edtTokenFechaAlta_Internalname = "TOKENFECHAALTA";
         edtTokenFechaExpiracion_Internalname = "TOKENFECHAEXPIRACION";
         edtusuariosId_Internalname = "USUARIOSID";
         edtTokenRequests_Internalname = "TOKENREQUESTS";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_145_Internalname = "PROMPT_145";
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
         Form.Caption = context.GetMessage( "Token", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTokenRequests_Jsonclick = "";
         edtTokenRequests_Enabled = 1;
         imgprompt_145_Visible = 1;
         imgprompt_145_Link = "";
         edtusuariosId_Jsonclick = "";
         edtusuariosId_Enabled = 1;
         edtTokenFechaExpiracion_Jsonclick = "";
         edtTokenFechaExpiracion_Enabled = 1;
         edtTokenFechaAlta_Jsonclick = "";
         edtTokenFechaAlta_Enabled = 1;
         edtTokenId_Jsonclick = "";
         edtTokenId_Enabled = 1;
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
         GX_FocusControl = edtTokenFechaAlta_Internalname;
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

      public void Valid_Tokenid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A905TokenFechaAlta", context.localUtil.TToC( A905TokenFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A904TokenFechaExpiracion", context.localUtil.TToC( A904TokenFechaExpiracion, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A145usuariosId", StringUtil.RTrim( A145usuariosId));
         AssignAttri("", false, "A903TokenRequests", StringUtil.LTrim( StringUtil.NToC( (decimal)(A903TokenRequests), 4, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z899TokenId", StringUtil.RTrim( Z899TokenId));
         GxWebStd.gx_hidden_field( context, "Z905TokenFechaAlta", context.localUtil.TToC( Z905TokenFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z904TokenFechaExpiracion", context.localUtil.TToC( Z904TokenFechaExpiracion, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z145usuariosId", StringUtil.RTrim( Z145usuariosId));
         GxWebStd.gx_hidden_field( context, "Z903TokenRequests", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z903TokenRequests), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Usuariosid( )
      {
         /* Using cursor T002S14 */
         pr_default.execute(12, new Object[] {A145usuariosId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "usuarios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOSID");
            AnyError = 1;
            GX_FocusControl = edtusuariosId_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
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
         setEventMetadata("VALID_TOKENID","{handler:'Valid_Tokenid',iparms:[{av:'A899TokenId',fld:'TOKENID',pic:'',type:'char'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'}]");
         setEventMetadata("VALID_TOKENID",",oparms:[{av:'A905TokenFechaAlta',fld:'TOKENFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'A904TokenFechaExpiracion',fld:'TOKENFECHAEXPIRACION',pic:'99/99/99 99:99',type:'dtime'},{av:'A145usuariosId',fld:'USUARIOSID',pic:'',type:'char'},{av:'A903TokenRequests',fld:'TOKENREQUESTS',pic:'ZZZ9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z899TokenId',type:'char'},{av:'Z905TokenFechaAlta',type:'dtime'},{av:'Z904TokenFechaExpiracion',type:'dtime'},{av:'Z145usuariosId',type:'char'},{av:'Z903TokenRequests',type:'int'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_TOKENFECHAALTA","{handler:'Valid_Tokenfechaalta',iparms:[]");
         setEventMetadata("VALID_TOKENFECHAALTA",",oparms:[]}");
         setEventMetadata("VALID_TOKENFECHAEXPIRACION","{handler:'Valid_Tokenfechaexpiracion',iparms:[]");
         setEventMetadata("VALID_TOKENFECHAEXPIRACION",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSID","{handler:'Valid_Usuariosid',iparms:[{av:'A145usuariosId',fld:'USUARIOSID',pic:'',type:'char'}]");
         setEventMetadata("VALID_USUARIOSID",",oparms:[]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z899TokenId = "";
         Z905TokenFechaAlta = (DateTime)(DateTime.MinValue);
         Z904TokenFechaExpiracion = (DateTime)(DateTime.MinValue);
         Z145usuariosId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A145usuariosId = "";
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
         A899TokenId = "";
         A905TokenFechaAlta = (DateTime)(DateTime.MinValue);
         A904TokenFechaExpiracion = (DateTime)(DateTime.MinValue);
         imgprompt_145_gximage = "";
         sImgUrl = "";
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
         T002S5_A899TokenId = new string[] {""} ;
         T002S5_A905TokenFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T002S5_A904TokenFechaExpiracion = new DateTime[] {DateTime.MinValue} ;
         T002S5_A903TokenRequests = new short[1] ;
         T002S5_A145usuariosId = new string[] {""} ;
         T002S4_A145usuariosId = new string[] {""} ;
         T002S6_A145usuariosId = new string[] {""} ;
         T002S7_A899TokenId = new string[] {""} ;
         T002S3_A899TokenId = new string[] {""} ;
         T002S3_A905TokenFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T002S3_A904TokenFechaExpiracion = new DateTime[] {DateTime.MinValue} ;
         T002S3_A903TokenRequests = new short[1] ;
         T002S3_A145usuariosId = new string[] {""} ;
         sMode132 = "";
         T002S8_A899TokenId = new string[] {""} ;
         T002S9_A899TokenId = new string[] {""} ;
         T002S2_A899TokenId = new string[] {""} ;
         T002S2_A905TokenFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T002S2_A904TokenFechaExpiracion = new DateTime[] {DateTime.MinValue} ;
         T002S2_A903TokenRequests = new short[1] ;
         T002S2_A145usuariosId = new string[] {""} ;
         T002S13_A899TokenId = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ899TokenId = "";
         ZZ905TokenFechaAlta = (DateTime)(DateTime.MinValue);
         ZZ904TokenFechaExpiracion = (DateTime)(DateTime.MinValue);
         ZZ145usuariosId = "";
         T002S14_A145usuariosId = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.apis.token__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.token__default(),
            new Object[][] {
                new Object[] {
               T002S2_A899TokenId, T002S2_A905TokenFechaAlta, T002S2_A904TokenFechaExpiracion, T002S2_A903TokenRequests, T002S2_A145usuariosId
               }
               , new Object[] {
               T002S3_A899TokenId, T002S3_A905TokenFechaAlta, T002S3_A904TokenFechaExpiracion, T002S3_A903TokenRequests, T002S3_A145usuariosId
               }
               , new Object[] {
               T002S4_A145usuariosId
               }
               , new Object[] {
               T002S5_A899TokenId, T002S5_A905TokenFechaAlta, T002S5_A904TokenFechaExpiracion, T002S5_A903TokenRequests, T002S5_A145usuariosId
               }
               , new Object[] {
               T002S6_A145usuariosId
               }
               , new Object[] {
               T002S7_A899TokenId
               }
               , new Object[] {
               T002S8_A899TokenId
               }
               , new Object[] {
               T002S9_A899TokenId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002S13_A899TokenId
               }
               , new Object[] {
               T002S14_A145usuariosId
               }
            }
         );
      }

      private short Z903TokenRequests ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A903TokenRequests ;
      private short RcdFound132 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ903TokenRequests ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTokenId_Enabled ;
      private int edtTokenFechaAlta_Enabled ;
      private int edtTokenFechaExpiracion_Enabled ;
      private int edtusuariosId_Enabled ;
      private int imgprompt_145_Visible ;
      private int edtTokenRequests_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z899TokenId ;
      private string Z145usuariosId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A145usuariosId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTokenId_Internalname ;
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
      private string A899TokenId ;
      private string edtTokenId_Jsonclick ;
      private string edtTokenFechaAlta_Internalname ;
      private string edtTokenFechaAlta_Jsonclick ;
      private string edtTokenFechaExpiracion_Internalname ;
      private string edtTokenFechaExpiracion_Jsonclick ;
      private string edtusuariosId_Internalname ;
      private string edtusuariosId_Jsonclick ;
      private string imgprompt_145_gximage ;
      private string sImgUrl ;
      private string imgprompt_145_Internalname ;
      private string imgprompt_145_Link ;
      private string edtTokenRequests_Internalname ;
      private string edtTokenRequests_Jsonclick ;
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
      private string sMode132 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ899TokenId ;
      private string ZZ145usuariosId ;
      private DateTime Z905TokenFechaAlta ;
      private DateTime Z904TokenFechaExpiracion ;
      private DateTime A905TokenFechaAlta ;
      private DateTime A904TokenFechaExpiracion ;
      private DateTime ZZ905TokenFechaAlta ;
      private DateTime ZZ904TokenFechaExpiracion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T002S5_A899TokenId ;
      private DateTime[] T002S5_A905TokenFechaAlta ;
      private DateTime[] T002S5_A904TokenFechaExpiracion ;
      private short[] T002S5_A903TokenRequests ;
      private string[] T002S5_A145usuariosId ;
      private string[] T002S4_A145usuariosId ;
      private string[] T002S6_A145usuariosId ;
      private string[] T002S7_A899TokenId ;
      private string[] T002S3_A899TokenId ;
      private DateTime[] T002S3_A905TokenFechaAlta ;
      private DateTime[] T002S3_A904TokenFechaExpiracion ;
      private short[] T002S3_A903TokenRequests ;
      private string[] T002S3_A145usuariosId ;
      private string[] T002S8_A899TokenId ;
      private string[] T002S9_A899TokenId ;
      private string[] T002S2_A899TokenId ;
      private DateTime[] T002S2_A905TokenFechaAlta ;
      private DateTime[] T002S2_A904TokenFechaExpiracion ;
      private short[] T002S2_A903TokenRequests ;
      private string[] T002S2_A145usuariosId ;
      private string[] T002S13_A899TokenId ;
      private string[] T002S14_A145usuariosId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class token__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class token__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
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
        Object[] prmT002S2;
        prmT002S2 = new Object[] {
        new ParDef("@TokenId",GXType.NChar,80,0)
        };
        Object[] prmT002S3;
        prmT002S3 = new Object[] {
        new ParDef("@TokenId",GXType.NChar,80,0)
        };
        Object[] prmT002S4;
        prmT002S4 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0)
        };
        Object[] prmT002S5;
        prmT002S5 = new Object[] {
        new ParDef("@TokenId",GXType.NChar,80,0)
        };
        Object[] prmT002S6;
        prmT002S6 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0)
        };
        Object[] prmT002S7;
        prmT002S7 = new Object[] {
        new ParDef("@TokenId",GXType.NChar,80,0)
        };
        Object[] prmT002S8;
        prmT002S8 = new Object[] {
        new ParDef("@TokenId",GXType.NChar,80,0)
        };
        Object[] prmT002S9;
        prmT002S9 = new Object[] {
        new ParDef("@TokenId",GXType.NChar,80,0)
        };
        Object[] prmT002S10;
        prmT002S10 = new Object[] {
        new ParDef("@TokenId",GXType.NChar,80,0) ,
        new ParDef("@TokenFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@TokenFechaExpiracion",GXType.DateTime,8,5) ,
        new ParDef("@TokenRequests",GXType.Int16,4,0) ,
        new ParDef("@usuariosId",GXType.NChar,20,0)
        };
        Object[] prmT002S11;
        prmT002S11 = new Object[] {
        new ParDef("@TokenFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@TokenFechaExpiracion",GXType.DateTime,8,5) ,
        new ParDef("@TokenRequests",GXType.Int16,4,0) ,
        new ParDef("@usuariosId",GXType.NChar,20,0) ,
        new ParDef("@TokenId",GXType.NChar,80,0)
        };
        Object[] prmT002S12;
        prmT002S12 = new Object[] {
        new ParDef("@TokenId",GXType.NChar,80,0)
        };
        Object[] prmT002S13;
        prmT002S13 = new Object[] {
        };
        Object[] prmT002S14;
        prmT002S14 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002S2", "SELECT [TokenId], [TokenFechaAlta], [TokenFechaExpiracion], [TokenRequests], [usuariosId] FROM [Token] WITH (UPDLOCK) WHERE [TokenId] = @TokenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S3", "SELECT [TokenId], [TokenFechaAlta], [TokenFechaExpiracion], [TokenRequests], [usuariosId] FROM [Token] WHERE [TokenId] = @TokenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S4", "SELECT [usuariosId] FROM [usuarios] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S5", "SELECT TM1.[TokenId], TM1.[TokenFechaAlta], TM1.[TokenFechaExpiracion], TM1.[TokenRequests], TM1.[usuariosId] FROM [Token] TM1 WHERE TM1.[TokenId] = @TokenId ORDER BY TM1.[TokenId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002S5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S6", "SELECT [usuariosId] FROM [usuarios] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S7", "SELECT [TokenId] FROM [Token] WHERE [TokenId] = @TokenId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002S7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S8", "SELECT TOP 1 [TokenId] FROM [Token] WHERE ( [TokenId] > @TokenId) ORDER BY [TokenId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002S8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002S9", "SELECT TOP 1 [TokenId] FROM [Token] WHERE ( [TokenId] < @TokenId) ORDER BY [TokenId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002S9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002S10", "INSERT INTO [Token]([TokenId], [TokenFechaAlta], [TokenFechaExpiracion], [TokenRequests], [usuariosId]) VALUES(@TokenId, @TokenFechaAlta, @TokenFechaExpiracion, @TokenRequests, @usuariosId)", GxErrorMask.GX_NOMASK,prmT002S10)
           ,new CursorDef("T002S11", "UPDATE [Token] SET [TokenFechaAlta]=@TokenFechaAlta, [TokenFechaExpiracion]=@TokenFechaExpiracion, [TokenRequests]=@TokenRequests, [usuariosId]=@usuariosId  WHERE [TokenId] = @TokenId", GxErrorMask.GX_NOMASK,prmT002S11)
           ,new CursorDef("T002S12", "DELETE FROM [Token]  WHERE [TokenId] = @TokenId", GxErrorMask.GX_NOMASK,prmT002S12)
           ,new CursorDef("T002S13", "SELECT [TokenId] FROM [Token] ORDER BY [TokenId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002S13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S14", "SELECT [usuariosId] FROM [usuarios] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S14,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
     }
  }

}

}
