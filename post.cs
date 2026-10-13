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
   public class post : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridpost_comment") == 0 )
         {
            gxnrGridpost_comment_newrow_invoke( ) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Post", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPostId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridpost_comment_newrow_invoke( )
      {
         nRC_GXsfl_78 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_78"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_78_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_78_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_78_idx = GetPar( "sGXsfl_78_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridpost_comment_newrow( ) ;
         /* End function gxnrGridpost_comment_newrow_invoke */
      }

      public post( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public post( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Post", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Post.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Post.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Post.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Post.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Post.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx01r0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"POSTID"+"'), id:'"+"POSTID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"POSTREFERENCIA"+"'), id:'"+"POSTREFERENCIA"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Post.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A195PostId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPostId_Enabled!=0) ? context.localUtil.Format( (decimal)(A195PostId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A195PostId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPostId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Post.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostReferencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostReferencia_Internalname, context.GetMessage( "Referencia", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostReferencia_Internalname, StringUtil.RTrim( A415PostReferencia), StringUtil.RTrim( context.localUtil.Format( A415PostReferencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostReferencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPostReferencia_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Post.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostUsuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostUsuario_Internalname, context.GetMessage( "Usuario", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostUsuario_Internalname, StringUtil.RTrim( A416PostUsuario), StringUtil.RTrim( context.localUtil.Format( A416PostUsuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostUsuario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPostUsuario_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "Usuario", "start", true, "", "HLP_Post.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostUsuarioNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostUsuarioNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostUsuarioNombre_Internalname, StringUtil.RTrim( A417PostUsuarioNombre), StringUtil.RTrim( context.localUtil.Format( A417PostUsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostUsuarioNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPostUsuarioNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Post.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostTitle_Internalname, context.GetMessage( "Title", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPostTitle_Internalname, A408PostTitle, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtPostTitle_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "256", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Post.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostFecha_Internalname, context.GetMessage( "Fecha", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPostFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPostFecha_Internalname, context.localUtil.TToC( A418PostFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A418PostFecha, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPostFecha_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Post.htm");
         GxWebStd.gx_bitmap( context, edtPostFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPostFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Post.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgPostImage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Image", ""), "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A409PostImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A409PostImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000PostImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A409PostImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A409PostImage)) ? A40000PostImage_GXI : context.PathToRelativeUrl( A409PostImage));
         GxWebStd.gx_bitmap( context, imgPostImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgPostImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", "", "", 0, A409PostImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_Post.htm");
         AssignProp("", false, imgPostImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A409PostImage)) ? A40000PostImage_GXI : context.PathToRelativeUrl( A409PostImage)), true);
         AssignProp("", false, imgPostImage_Internalname, "IsBlob", StringUtil.BoolToStr( A409PostImage_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostDateUpdated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostDateUpdated_Internalname, context.GetMessage( "Date Updated", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPostDateUpdated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPostDateUpdated_Internalname, context.localUtil.TToC( A419PostDateUpdated, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A419PostDateUpdated, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostDateUpdated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPostDateUpdated_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Post.htm");
         GxWebStd.gx_bitmap( context, edtPostDateUpdated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPostDateUpdated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Post.htm");
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
         GxWebStd.gx_div_start( context, divCommenttable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlecomment_Internalname, context.GetMessage( "Comment", ""), "", "", lblTitlecomment_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Post.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridpost_comment( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Post.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Post.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Post.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridpost_comment( )
      {
         /*  Grid Control  */
         StartGridControl78( ) ;
         nGXsfl_78_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount64 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_64 = 1;
               ScanStart1J64( ) ;
               while ( RcdFound64 != 0 )
               {
                  init_level_properties64( ) ;
                  getByPrimaryKey1J64( ) ;
                  AddRow1J64( ) ;
                  ScanNext1J64( ) ;
               }
               ScanEnd1J64( ) ;
               nBlankRcdCount64 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1J64( ) ;
            standaloneModal1J64( ) ;
            sMode64 = Gx_mode;
            while ( nGXsfl_78_idx < nRC_GXsfl_78 )
            {
               bGXsfl_78_Refreshing = true;
               ReadRow1J64( ) ;
               edtPostCommentId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTCOMMENTID_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPostCommentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostCommentId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtPostCommentUsuario_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTCOMMENTUSUARIO_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPostCommentUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostCommentUsuario_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtPostCommentUsuarioNom_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTCOMMENTUSUARIONOM_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPostCommentUsuarioNom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostCommentUsuarioNom_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtPostCommentUsuarioImg_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTCOMMENTUSUARIOIMG_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostCommentUsuarioImg_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtPostCommentContent_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTCOMMENTCONTENT_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPostCommentContent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostCommentContent_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtPostCommentDate_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTCOMMENTDATE_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPostCommentDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostCommentDate_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               if ( ( nRcdExists_64 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1J64( ) ;
               }
               SendRow1J64( ) ;
               bGXsfl_78_Refreshing = false;
            }
            Gx_mode = sMode64;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount64 = 5;
            nRcdExists_64 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1J64( ) ;
               while ( RcdFound64 != 0 )
               {
                  sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_7864( ) ;
                  init_level_properties64( ) ;
                  standaloneNotModal1J64( ) ;
                  getByPrimaryKey1J64( ) ;
                  standaloneModal1J64( ) ;
                  AddRow1J64( ) ;
                  ScanNext1J64( ) ;
               }
               ScanEnd1J64( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode64 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx+1), 4, 0), 4, "0");
         SubsflControlProps_7864( ) ;
         InitAll1J64( ) ;
         init_level_properties64( ) ;
         nRcdExists_64 = 0;
         nIsMod_64 = 0;
         nRcdDeleted_64 = 0;
         nBlankRcdCount64 = (short)(nBlankRcdUsr64+nBlankRcdCount64);
         fRowAdded = 0;
         while ( nBlankRcdCount64 > 0 )
         {
            standaloneNotModal1J64( ) ;
            standaloneModal1J64( ) ;
            AddRow1J64( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtPostCommentId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount64 = (short)(nBlankRcdCount64-1);
         }
         Gx_mode = sMode64;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridpost_commentContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpost_comment", Gridpost_commentContainer, subGridpost_comment_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpost_commentContainerData", Gridpost_commentContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpost_commentContainerData"+"V", Gridpost_commentContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridpost_commentContainerData"+"V"+"\" value='"+Gridpost_commentContainer.GridValuesHidden()+"'/>") ;
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
            Z195PostId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z195PostId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z415PostReferencia = cgiGet( "Z415PostReferencia");
            Z416PostUsuario = cgiGet( "Z416PostUsuario");
            Z417PostUsuarioNombre = cgiGet( "Z417PostUsuarioNombre");
            Z408PostTitle = cgiGet( "Z408PostTitle");
            Z418PostFecha = context.localUtil.CToT( cgiGet( "Z418PostFecha"), 0);
            Z419PostDateUpdated = context.localUtil.CToT( cgiGet( "Z419PostDateUpdated"), 0);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_78 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_78"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A40000PostImage_GXI = cgiGet( "POSTIMAGE_GXI");
            A40001PostCommentUsuarioImg_GXI = cgiGet( "POSTCOMMENTUSUARIOIMG_GXI");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtPostId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPostId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "POSTID");
               AnyError = 1;
               GX_FocusControl = edtPostId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A195PostId = 0;
               AssignAttri("", false, "A195PostId", StringUtil.LTrimStr( (decimal)(A195PostId), 18, 0));
            }
            else
            {
               A195PostId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A195PostId", StringUtil.LTrimStr( (decimal)(A195PostId), 18, 0));
            }
            A415PostReferencia = cgiGet( edtPostReferencia_Internalname);
            AssignAttri("", false, "A415PostReferencia", A415PostReferencia);
            A416PostUsuario = cgiGet( edtPostUsuario_Internalname);
            AssignAttri("", false, "A416PostUsuario", A416PostUsuario);
            A417PostUsuarioNombre = cgiGet( edtPostUsuarioNombre_Internalname);
            AssignAttri("", false, "A417PostUsuarioNombre", A417PostUsuarioNombre);
            A408PostTitle = cgiGet( edtPostTitle_Internalname);
            AssignAttri("", false, "A408PostTitle", A408PostTitle);
            if ( context.localUtil.VCDateTime( cgiGet( edtPostFecha_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha", "")}), 1, "POSTFECHA");
               AnyError = 1;
               GX_FocusControl = edtPostFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A418PostFecha = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A418PostFecha", context.localUtil.TToC( A418PostFecha, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A418PostFecha = context.localUtil.CToT( cgiGet( edtPostFecha_Internalname));
               AssignAttri("", false, "A418PostFecha", context.localUtil.TToC( A418PostFecha, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A409PostImage = cgiGet( imgPostImage_Internalname);
            AssignAttri("", false, "A409PostImage", A409PostImage);
            if ( context.localUtil.VCDateTime( cgiGet( edtPostDateUpdated_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Post Date Updated", "")}), 1, "POSTDATEUPDATED");
               AnyError = 1;
               GX_FocusControl = edtPostDateUpdated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A419PostDateUpdated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A419PostDateUpdated", context.localUtil.TToC( A419PostDateUpdated, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A419PostDateUpdated = context.localUtil.CToT( cgiGet( edtPostDateUpdated_Internalname));
               AssignAttri("", false, "A419PostDateUpdated", context.localUtil.TToC( A419PostDateUpdated, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgPostImage_Internalname, ref  A409PostImage, ref  A40000PostImage_GXI);
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
               A195PostId = (long)(Math.Round(NumberUtil.Val( GetPar( "PostId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A195PostId", StringUtil.LTrimStr( (decimal)(A195PostId), 18, 0));
               A415PostReferencia = GetPar( "PostReferencia");
               AssignAttri("", false, "A415PostReferencia", A415PostReferencia);
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
               InitAll1J63( ) ;
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
         DisableAttributes1J63( ) ;
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

      protected void CONFIRM_1J64( )
      {
         nGXsfl_78_idx = 0;
         while ( nGXsfl_78_idx < nRC_GXsfl_78 )
         {
            ReadRow1J64( ) ;
            if ( ( nRcdExists_64 != 0 ) || ( nIsMod_64 != 0 ) )
            {
               GetKey1J64( ) ;
               if ( ( nRcdExists_64 == 0 ) && ( nRcdDeleted_64 == 0 ) )
               {
                  if ( RcdFound64 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1J64( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1J64( ) ;
                        CloseExtendedTableCursors1J64( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "POSTCOMMENTID_" + sGXsfl_78_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtPostCommentId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound64 != 0 )
                  {
                     if ( nRcdDeleted_64 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1J64( ) ;
                        Load1J64( ) ;
                        BeforeValidate1J64( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1J64( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_64 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1J64( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1J64( ) ;
                              CloseExtendedTableCursors1J64( ) ;
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
                     if ( nRcdDeleted_64 == 0 )
                     {
                        GXCCtl = "POSTCOMMENTID_" + sGXsfl_78_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPostCommentId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPostCommentId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A407PostCommentId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtPostCommentUsuario_Internalname, StringUtil.RTrim( A412PostCommentUsuario)) ;
            ChangePostValue( edtPostCommentUsuarioNom_Internalname, StringUtil.RTrim( A413PostCommentUsuarioNom)) ;
            ChangePostValue( edtPostCommentUsuarioImg_Internalname, A414PostCommentUsuarioImg) ;
            ChangePostValue( edtPostCommentContent_Internalname, A410PostCommentContent) ;
            ChangePostValue( edtPostCommentDate_Internalname, context.localUtil.TToC( A411PostCommentDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z407PostCommentId_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z407PostCommentId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z412PostCommentUsuario_"+sGXsfl_78_idx, StringUtil.RTrim( Z412PostCommentUsuario)) ;
            ChangePostValue( "ZT_"+"Z413PostCommentUsuarioNom_"+sGXsfl_78_idx, StringUtil.RTrim( Z413PostCommentUsuarioNom)) ;
            ChangePostValue( "ZT_"+"Z411PostCommentDate_"+sGXsfl_78_idx, context.localUtil.TToC( Z411PostCommentDate, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "nRcdDeleted_64_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_64), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_64_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_64), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_64_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_64), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_64 != 0 )
            {
               ChangePostValue( "POSTCOMMENTID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTCOMMENTUSUARIO_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentUsuario_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTCOMMENTUSUARIONOM_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentUsuarioNom_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTCOMMENTUSUARIOIMG_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentUsuarioImg_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTCOMMENTCONTENT_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentContent_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTCOMMENTDATE_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentDate_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1J0( )
      {
      }

      protected void ZM1J63( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z416PostUsuario = T001J5_A416PostUsuario[0];
               Z417PostUsuarioNombre = T001J5_A417PostUsuarioNombre[0];
               Z408PostTitle = T001J5_A408PostTitle[0];
               Z418PostFecha = T001J5_A418PostFecha[0];
               Z419PostDateUpdated = T001J5_A419PostDateUpdated[0];
            }
            else
            {
               Z416PostUsuario = A416PostUsuario;
               Z417PostUsuarioNombre = A417PostUsuarioNombre;
               Z408PostTitle = A408PostTitle;
               Z418PostFecha = A418PostFecha;
               Z419PostDateUpdated = A419PostDateUpdated;
            }
         }
         if ( GX_JID == -4 )
         {
            Z195PostId = A195PostId;
            Z415PostReferencia = A415PostReferencia;
            Z416PostUsuario = A416PostUsuario;
            Z417PostUsuarioNombre = A417PostUsuarioNombre;
            Z408PostTitle = A408PostTitle;
            Z418PostFecha = A418PostFecha;
            Z409PostImage = A409PostImage;
            Z40000PostImage_GXI = A40000PostImage_GXI;
            Z419PostDateUpdated = A419PostDateUpdated;
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

      protected void Load1J63( )
      {
         /* Using cursor T001J6 */
         pr_default.execute(4, new Object[] {A195PostId, A415PostReferencia});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound63 = 1;
            A416PostUsuario = T001J6_A416PostUsuario[0];
            AssignAttri("", false, "A416PostUsuario", A416PostUsuario);
            A417PostUsuarioNombre = T001J6_A417PostUsuarioNombre[0];
            AssignAttri("", false, "A417PostUsuarioNombre", A417PostUsuarioNombre);
            A408PostTitle = T001J6_A408PostTitle[0];
            AssignAttri("", false, "A408PostTitle", A408PostTitle);
            A418PostFecha = T001J6_A418PostFecha[0];
            AssignAttri("", false, "A418PostFecha", context.localUtil.TToC( A418PostFecha, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A40000PostImage_GXI = T001J6_A40000PostImage_GXI[0];
            AssignProp("", false, imgPostImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A409PostImage)) ? A40000PostImage_GXI : context.convertURL( context.PathToRelativeUrl( A409PostImage))), true);
            AssignProp("", false, imgPostImage_Internalname, "SrcSet", context.GetImageSrcSet( A409PostImage), true);
            A419PostDateUpdated = T001J6_A419PostDateUpdated[0];
            AssignAttri("", false, "A419PostDateUpdated", context.localUtil.TToC( A419PostDateUpdated, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A409PostImage = T001J6_A409PostImage[0];
            AssignAttri("", false, "A409PostImage", A409PostImage);
            AssignProp("", false, imgPostImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A409PostImage)) ? A40000PostImage_GXI : context.convertURL( context.PathToRelativeUrl( A409PostImage))), true);
            AssignProp("", false, imgPostImage_Internalname, "SrcSet", context.GetImageSrcSet( A409PostImage), true);
            ZM1J63( -4) ;
         }
         pr_default.close(4);
         OnLoadActions1J63( ) ;
      }

      protected void OnLoadActions1J63( )
      {
      }

      protected void CheckExtendedTable1J63( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A418PostFecha) || ( A418PostFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "POSTFECHA");
            AnyError = 1;
            GX_FocusControl = edtPostFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A419PostDateUpdated) || ( A419PostDateUpdated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Post Date Updated", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "POSTDATEUPDATED");
            AnyError = 1;
            GX_FocusControl = edtPostDateUpdated_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1J63( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1J63( )
      {
         /* Using cursor T001J7 */
         pr_default.execute(5, new Object[] {A195PostId, A415PostReferencia});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound63 = 1;
         }
         else
         {
            RcdFound63 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001J5 */
         pr_default.execute(3, new Object[] {A195PostId, A415PostReferencia});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1J63( 4) ;
            RcdFound63 = 1;
            A195PostId = T001J5_A195PostId[0];
            AssignAttri("", false, "A195PostId", StringUtil.LTrimStr( (decimal)(A195PostId), 18, 0));
            A415PostReferencia = T001J5_A415PostReferencia[0];
            AssignAttri("", false, "A415PostReferencia", A415PostReferencia);
            A416PostUsuario = T001J5_A416PostUsuario[0];
            AssignAttri("", false, "A416PostUsuario", A416PostUsuario);
            A417PostUsuarioNombre = T001J5_A417PostUsuarioNombre[0];
            AssignAttri("", false, "A417PostUsuarioNombre", A417PostUsuarioNombre);
            A408PostTitle = T001J5_A408PostTitle[0];
            AssignAttri("", false, "A408PostTitle", A408PostTitle);
            A418PostFecha = T001J5_A418PostFecha[0];
            AssignAttri("", false, "A418PostFecha", context.localUtil.TToC( A418PostFecha, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A40000PostImage_GXI = T001J5_A40000PostImage_GXI[0];
            AssignProp("", false, imgPostImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A409PostImage)) ? A40000PostImage_GXI : context.convertURL( context.PathToRelativeUrl( A409PostImage))), true);
            AssignProp("", false, imgPostImage_Internalname, "SrcSet", context.GetImageSrcSet( A409PostImage), true);
            A419PostDateUpdated = T001J5_A419PostDateUpdated[0];
            AssignAttri("", false, "A419PostDateUpdated", context.localUtil.TToC( A419PostDateUpdated, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A409PostImage = T001J5_A409PostImage[0];
            AssignAttri("", false, "A409PostImage", A409PostImage);
            AssignProp("", false, imgPostImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A409PostImage)) ? A40000PostImage_GXI : context.convertURL( context.PathToRelativeUrl( A409PostImage))), true);
            AssignProp("", false, imgPostImage_Internalname, "SrcSet", context.GetImageSrcSet( A409PostImage), true);
            Z195PostId = A195PostId;
            Z415PostReferencia = A415PostReferencia;
            sMode63 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1J63( ) ;
            if ( AnyError == 1 )
            {
               RcdFound63 = 0;
               InitializeNonKey1J63( ) ;
            }
            Gx_mode = sMode63;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound63 = 0;
            InitializeNonKey1J63( ) ;
            sMode63 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode63;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey1J63( ) ;
         if ( RcdFound63 == 0 )
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
         RcdFound63 = 0;
         /* Using cursor T001J8 */
         pr_default.execute(6, new Object[] {A195PostId, A415PostReferencia});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T001J8_A195PostId[0] < A195PostId ) || ( T001J8_A195PostId[0] == A195PostId ) && ( StringUtil.StrCmp(T001J8_A415PostReferencia[0], A415PostReferencia) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T001J8_A195PostId[0] > A195PostId ) || ( T001J8_A195PostId[0] == A195PostId ) && ( StringUtil.StrCmp(T001J8_A415PostReferencia[0], A415PostReferencia) > 0 ) ) )
            {
               A195PostId = T001J8_A195PostId[0];
               AssignAttri("", false, "A195PostId", StringUtil.LTrimStr( (decimal)(A195PostId), 18, 0));
               A415PostReferencia = T001J8_A415PostReferencia[0];
               AssignAttri("", false, "A415PostReferencia", A415PostReferencia);
               RcdFound63 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound63 = 0;
         /* Using cursor T001J9 */
         pr_default.execute(7, new Object[] {A195PostId, A415PostReferencia});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001J9_A195PostId[0] > A195PostId ) || ( T001J9_A195PostId[0] == A195PostId ) && ( StringUtil.StrCmp(T001J9_A415PostReferencia[0], A415PostReferencia) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001J9_A195PostId[0] < A195PostId ) || ( T001J9_A195PostId[0] == A195PostId ) && ( StringUtil.StrCmp(T001J9_A415PostReferencia[0], A415PostReferencia) < 0 ) ) )
            {
               A195PostId = T001J9_A195PostId[0];
               AssignAttri("", false, "A195PostId", StringUtil.LTrimStr( (decimal)(A195PostId), 18, 0));
               A415PostReferencia = T001J9_A415PostReferencia[0];
               AssignAttri("", false, "A415PostReferencia", A415PostReferencia);
               RcdFound63 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1J63( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPostId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1J63( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound63 == 1 )
            {
               if ( ( A195PostId != Z195PostId ) || ( StringUtil.StrCmp(A415PostReferencia, Z415PostReferencia) != 0 ) )
               {
                  A195PostId = Z195PostId;
                  AssignAttri("", false, "A195PostId", StringUtil.LTrimStr( (decimal)(A195PostId), 18, 0));
                  A415PostReferencia = Z415PostReferencia;
                  AssignAttri("", false, "A415PostReferencia", A415PostReferencia);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "POSTID");
                  AnyError = 1;
                  GX_FocusControl = edtPostId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPostId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1J63( ) ;
                  GX_FocusControl = edtPostId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A195PostId != Z195PostId ) || ( StringUtil.StrCmp(A415PostReferencia, Z415PostReferencia) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPostId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1J63( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "POSTID");
                     AnyError = 1;
                     GX_FocusControl = edtPostId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPostId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1J63( ) ;
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
         if ( ( A195PostId != Z195PostId ) || ( StringUtil.StrCmp(A415PostReferencia, Z415PostReferencia) != 0 ) )
         {
            A195PostId = Z195PostId;
            AssignAttri("", false, "A195PostId", StringUtil.LTrimStr( (decimal)(A195PostId), 18, 0));
            A415PostReferencia = Z415PostReferencia;
            AssignAttri("", false, "A415PostReferencia", A415PostReferencia);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "POSTID");
            AnyError = 1;
            GX_FocusControl = edtPostId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPostId_Internalname;
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
         if ( RcdFound63 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "POSTID");
            AnyError = 1;
            GX_FocusControl = edtPostId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPostUsuario_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1J63( ) ;
         if ( RcdFound63 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPostUsuario_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1J63( ) ;
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
         if ( RcdFound63 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPostUsuario_Internalname;
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
         if ( RcdFound63 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPostUsuario_Internalname;
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
         ScanStart1J63( ) ;
         if ( RcdFound63 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound63 != 0 )
            {
               ScanNext1J63( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPostUsuario_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1J63( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1J63( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001J4 */
            pr_default.execute(2, new Object[] {A195PostId, A415PostReferencia});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Post"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z416PostUsuario, T001J4_A416PostUsuario[0]) != 0 ) || ( StringUtil.StrCmp(Z417PostUsuarioNombre, T001J4_A417PostUsuarioNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z408PostTitle, T001J4_A408PostTitle[0]) != 0 ) || ( Z418PostFecha != T001J4_A418PostFecha[0] ) || ( Z419PostDateUpdated != T001J4_A419PostDateUpdated[0] ) )
            {
               if ( StringUtil.StrCmp(Z416PostUsuario, T001J4_A416PostUsuario[0]) != 0 )
               {
                  GXUtil.WriteLog("post:[seudo value changed for attri]"+"PostUsuario");
                  GXUtil.WriteLogRaw("Old: ",Z416PostUsuario);
                  GXUtil.WriteLogRaw("Current: ",T001J4_A416PostUsuario[0]);
               }
               if ( StringUtil.StrCmp(Z417PostUsuarioNombre, T001J4_A417PostUsuarioNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("post:[seudo value changed for attri]"+"PostUsuarioNombre");
                  GXUtil.WriteLogRaw("Old: ",Z417PostUsuarioNombre);
                  GXUtil.WriteLogRaw("Current: ",T001J4_A417PostUsuarioNombre[0]);
               }
               if ( StringUtil.StrCmp(Z408PostTitle, T001J4_A408PostTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("post:[seudo value changed for attri]"+"PostTitle");
                  GXUtil.WriteLogRaw("Old: ",Z408PostTitle);
                  GXUtil.WriteLogRaw("Current: ",T001J4_A408PostTitle[0]);
               }
               if ( Z418PostFecha != T001J4_A418PostFecha[0] )
               {
                  GXUtil.WriteLog("post:[seudo value changed for attri]"+"PostFecha");
                  GXUtil.WriteLogRaw("Old: ",Z418PostFecha);
                  GXUtil.WriteLogRaw("Current: ",T001J4_A418PostFecha[0]);
               }
               if ( Z419PostDateUpdated != T001J4_A419PostDateUpdated[0] )
               {
                  GXUtil.WriteLog("post:[seudo value changed for attri]"+"PostDateUpdated");
                  GXUtil.WriteLogRaw("Old: ",Z419PostDateUpdated);
                  GXUtil.WriteLogRaw("Current: ",T001J4_A419PostDateUpdated[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Post"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1J63( )
      {
         BeforeValidate1J63( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1J63( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1J63( 0) ;
            CheckOptimisticConcurrency1J63( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1J63( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1J63( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001J10 */
                     pr_default.execute(8, new Object[] {A195PostId, A415PostReferencia, A416PostUsuario, A417PostUsuarioNombre, A408PostTitle, A418PostFecha, A409PostImage, A40000PostImage_GXI, A419PostDateUpdated});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Post");
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
                           ProcessLevel1J63( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1J0( ) ;
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
               Load1J63( ) ;
            }
            EndLevel1J63( ) ;
         }
         CloseExtendedTableCursors1J63( ) ;
      }

      protected void Update1J63( )
      {
         BeforeValidate1J63( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1J63( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1J63( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1J63( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1J63( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001J11 */
                     pr_default.execute(9, new Object[] {A416PostUsuario, A417PostUsuarioNombre, A408PostTitle, A418PostFecha, A419PostDateUpdated, A195PostId, A415PostReferencia});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Post");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Post"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1J63( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1J63( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption1J0( ) ;
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
            EndLevel1J63( ) ;
         }
         CloseExtendedTableCursors1J63( ) ;
      }

      protected void DeferredUpdate1J63( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001J12 */
            pr_default.execute(10, new Object[] {A409PostImage, A40000PostImage_GXI, A195PostId, A415PostReferencia});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Post");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1J63( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1J63( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1J63( ) ;
            AfterConfirm1J63( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1J63( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1J64( ) ;
                  while ( RcdFound64 != 0 )
                  {
                     getByPrimaryKey1J64( ) ;
                     Delete1J64( ) ;
                     ScanNext1J64( ) ;
                  }
                  ScanEnd1J64( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001J13 */
                     pr_default.execute(11, new Object[] {A195PostId, A415PostReferencia});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Post");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound63 == 0 )
                           {
                              InitAll1J63( ) ;
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
                           ResetCaption1J0( ) ;
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
         sMode63 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1J63( ) ;
         Gx_mode = sMode63;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1J63( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel1J64( )
      {
         nGXsfl_78_idx = 0;
         while ( nGXsfl_78_idx < nRC_GXsfl_78 )
         {
            ReadRow1J64( ) ;
            if ( ( nRcdExists_64 != 0 ) || ( nIsMod_64 != 0 ) )
            {
               standaloneNotModal1J64( ) ;
               GetKey1J64( ) ;
               if ( ( nRcdExists_64 == 0 ) && ( nRcdDeleted_64 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1J64( ) ;
               }
               else
               {
                  if ( RcdFound64 != 0 )
                  {
                     if ( ( nRcdDeleted_64 != 0 ) && ( nRcdExists_64 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1J64( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_64 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1J64( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_64 == 0 )
                     {
                        GXCCtl = "POSTCOMMENTID_" + sGXsfl_78_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPostCommentId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPostCommentId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A407PostCommentId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtPostCommentUsuario_Internalname, StringUtil.RTrim( A412PostCommentUsuario)) ;
            ChangePostValue( edtPostCommentUsuarioNom_Internalname, StringUtil.RTrim( A413PostCommentUsuarioNom)) ;
            ChangePostValue( edtPostCommentUsuarioImg_Internalname, A414PostCommentUsuarioImg) ;
            ChangePostValue( edtPostCommentContent_Internalname, A410PostCommentContent) ;
            ChangePostValue( edtPostCommentDate_Internalname, context.localUtil.TToC( A411PostCommentDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z407PostCommentId_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z407PostCommentId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z412PostCommentUsuario_"+sGXsfl_78_idx, StringUtil.RTrim( Z412PostCommentUsuario)) ;
            ChangePostValue( "ZT_"+"Z413PostCommentUsuarioNom_"+sGXsfl_78_idx, StringUtil.RTrim( Z413PostCommentUsuarioNom)) ;
            ChangePostValue( "ZT_"+"Z411PostCommentDate_"+sGXsfl_78_idx, context.localUtil.TToC( Z411PostCommentDate, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "nRcdDeleted_64_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_64), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_64_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_64), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_64_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_64), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_64 != 0 )
            {
               ChangePostValue( "POSTCOMMENTID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTCOMMENTUSUARIO_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentUsuario_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTCOMMENTUSUARIONOM_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentUsuarioNom_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTCOMMENTUSUARIOIMG_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentUsuarioImg_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTCOMMENTCONTENT_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentContent_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTCOMMENTDATE_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentDate_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1J64( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_64 = 0;
         nIsMod_64 = 0;
         nRcdDeleted_64 = 0;
      }

      protected void ProcessLevel1J63( )
      {
         /* Save parent mode. */
         sMode63 = Gx_mode;
         ProcessNestedLevel1J64( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode63;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1J63( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1J63( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.CommitDataStores("post",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1J0( ) ;
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
            context.RollbackDataStores("post",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1J63( )
      {
         /* Using cursor T001J14 */
         pr_default.execute(12);
         RcdFound63 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound63 = 1;
            A195PostId = T001J14_A195PostId[0];
            AssignAttri("", false, "A195PostId", StringUtil.LTrimStr( (decimal)(A195PostId), 18, 0));
            A415PostReferencia = T001J14_A415PostReferencia[0];
            AssignAttri("", false, "A415PostReferencia", A415PostReferencia);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1J63( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound63 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound63 = 1;
            A195PostId = T001J14_A195PostId[0];
            AssignAttri("", false, "A195PostId", StringUtil.LTrimStr( (decimal)(A195PostId), 18, 0));
            A415PostReferencia = T001J14_A415PostReferencia[0];
            AssignAttri("", false, "A415PostReferencia", A415PostReferencia);
         }
      }

      protected void ScanEnd1J63( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1J63( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1J63( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1J63( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1J63( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1J63( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1J63( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1J63( )
      {
         edtPostId_Enabled = 0;
         AssignProp("", false, edtPostId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostId_Enabled), 5, 0), true);
         edtPostReferencia_Enabled = 0;
         AssignProp("", false, edtPostReferencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostReferencia_Enabled), 5, 0), true);
         edtPostUsuario_Enabled = 0;
         AssignProp("", false, edtPostUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostUsuario_Enabled), 5, 0), true);
         edtPostUsuarioNombre_Enabled = 0;
         AssignProp("", false, edtPostUsuarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostUsuarioNombre_Enabled), 5, 0), true);
         edtPostTitle_Enabled = 0;
         AssignProp("", false, edtPostTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostTitle_Enabled), 5, 0), true);
         edtPostFecha_Enabled = 0;
         AssignProp("", false, edtPostFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostFecha_Enabled), 5, 0), true);
         imgPostImage_Enabled = 0;
         AssignProp("", false, imgPostImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgPostImage_Enabled), 5, 0), true);
         edtPostDateUpdated_Enabled = 0;
         AssignProp("", false, edtPostDateUpdated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostDateUpdated_Enabled), 5, 0), true);
      }

      protected void ZM1J64( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z412PostCommentUsuario = T001J3_A412PostCommentUsuario[0];
               Z413PostCommentUsuarioNom = T001J3_A413PostCommentUsuarioNom[0];
               Z411PostCommentDate = T001J3_A411PostCommentDate[0];
            }
            else
            {
               Z412PostCommentUsuario = A412PostCommentUsuario;
               Z413PostCommentUsuarioNom = A413PostCommentUsuarioNom;
               Z411PostCommentDate = A411PostCommentDate;
            }
         }
         if ( GX_JID == -5 )
         {
            Z195PostId = A195PostId;
            Z415PostReferencia = A415PostReferencia;
            Z407PostCommentId = A407PostCommentId;
            Z412PostCommentUsuario = A412PostCommentUsuario;
            Z413PostCommentUsuarioNom = A413PostCommentUsuarioNom;
            Z414PostCommentUsuarioImg = A414PostCommentUsuarioImg;
            Z40001PostCommentUsuarioImg_GXI = A40001PostCommentUsuarioImg_GXI;
            Z410PostCommentContent = A410PostCommentContent;
            Z411PostCommentDate = A411PostCommentDate;
         }
      }

      protected void standaloneNotModal1J64( )
      {
      }

      protected void standaloneModal1J64( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtPostCommentId_Enabled = 0;
            AssignProp("", false, edtPostCommentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostCommentId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         }
         else
         {
            edtPostCommentId_Enabled = 1;
            AssignProp("", false, edtPostCommentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostCommentId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         }
      }

      protected void Load1J64( )
      {
         /* Using cursor T001J15 */
         pr_default.execute(13, new Object[] {A195PostId, A415PostReferencia, A407PostCommentId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound64 = 1;
            A412PostCommentUsuario = T001J15_A412PostCommentUsuario[0];
            A413PostCommentUsuarioNom = T001J15_A413PostCommentUsuarioNom[0];
            A40001PostCommentUsuarioImg_GXI = T001J15_A40001PostCommentUsuarioImg_GXI[0];
            AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A414PostCommentUsuarioImg)) ? A40001PostCommentUsuarioImg_GXI : context.convertURL( context.PathToRelativeUrl( A414PostCommentUsuarioImg))), !bGXsfl_78_Refreshing);
            AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "SrcSet", context.GetImageSrcSet( A414PostCommentUsuarioImg), true);
            A410PostCommentContent = T001J15_A410PostCommentContent[0];
            A411PostCommentDate = T001J15_A411PostCommentDate[0];
            A414PostCommentUsuarioImg = T001J15_A414PostCommentUsuarioImg[0];
            AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A414PostCommentUsuarioImg)) ? A40001PostCommentUsuarioImg_GXI : context.convertURL( context.PathToRelativeUrl( A414PostCommentUsuarioImg))), !bGXsfl_78_Refreshing);
            AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "SrcSet", context.GetImageSrcSet( A414PostCommentUsuarioImg), true);
            ZM1J64( -5) ;
         }
         pr_default.close(13);
         OnLoadActions1J64( ) ;
      }

      protected void OnLoadActions1J64( )
      {
      }

      protected void CheckExtendedTable1J64( )
      {
         nIsDirty_64 = 0;
         Gx_BScreen = 1;
         standaloneModal1J64( ) ;
         if ( ! ( (DateTime.MinValue==A411PostCommentDate) || ( A411PostCommentDate >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GXCCtl = "POSTCOMMENTDATE_" + sGXsfl_78_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Post Comment Date", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPostCommentDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1J64( )
      {
      }

      protected void enableDisable1J64( )
      {
      }

      protected void GetKey1J64( )
      {
         /* Using cursor T001J16 */
         pr_default.execute(14, new Object[] {A195PostId, A415PostReferencia, A407PostCommentId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound64 = 1;
         }
         else
         {
            RcdFound64 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey1J64( )
      {
         /* Using cursor T001J3 */
         pr_default.execute(1, new Object[] {A195PostId, A415PostReferencia, A407PostCommentId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1J64( 5) ;
            RcdFound64 = 1;
            InitializeNonKey1J64( ) ;
            A407PostCommentId = T001J3_A407PostCommentId[0];
            A412PostCommentUsuario = T001J3_A412PostCommentUsuario[0];
            A413PostCommentUsuarioNom = T001J3_A413PostCommentUsuarioNom[0];
            A40001PostCommentUsuarioImg_GXI = T001J3_A40001PostCommentUsuarioImg_GXI[0];
            AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A414PostCommentUsuarioImg)) ? A40001PostCommentUsuarioImg_GXI : context.convertURL( context.PathToRelativeUrl( A414PostCommentUsuarioImg))), !bGXsfl_78_Refreshing);
            AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "SrcSet", context.GetImageSrcSet( A414PostCommentUsuarioImg), true);
            A410PostCommentContent = T001J3_A410PostCommentContent[0];
            A411PostCommentDate = T001J3_A411PostCommentDate[0];
            A414PostCommentUsuarioImg = T001J3_A414PostCommentUsuarioImg[0];
            AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A414PostCommentUsuarioImg)) ? A40001PostCommentUsuarioImg_GXI : context.convertURL( context.PathToRelativeUrl( A414PostCommentUsuarioImg))), !bGXsfl_78_Refreshing);
            AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "SrcSet", context.GetImageSrcSet( A414PostCommentUsuarioImg), true);
            Z195PostId = A195PostId;
            Z415PostReferencia = A415PostReferencia;
            Z407PostCommentId = A407PostCommentId;
            sMode64 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1J64( ) ;
            Load1J64( ) ;
            Gx_mode = sMode64;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound64 = 0;
            InitializeNonKey1J64( ) ;
            sMode64 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1J64( ) ;
            Gx_mode = sMode64;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1J64( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1J64( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001J2 */
            pr_default.execute(0, new Object[] {A195PostId, A415PostReferencia, A407PostCommentId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PostComment"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z412PostCommentUsuario, T001J2_A412PostCommentUsuario[0]) != 0 ) || ( StringUtil.StrCmp(Z413PostCommentUsuarioNom, T001J2_A413PostCommentUsuarioNom[0]) != 0 ) || ( Z411PostCommentDate != T001J2_A411PostCommentDate[0] ) )
            {
               if ( StringUtil.StrCmp(Z412PostCommentUsuario, T001J2_A412PostCommentUsuario[0]) != 0 )
               {
                  GXUtil.WriteLog("post:[seudo value changed for attri]"+"PostCommentUsuario");
                  GXUtil.WriteLogRaw("Old: ",Z412PostCommentUsuario);
                  GXUtil.WriteLogRaw("Current: ",T001J2_A412PostCommentUsuario[0]);
               }
               if ( StringUtil.StrCmp(Z413PostCommentUsuarioNom, T001J2_A413PostCommentUsuarioNom[0]) != 0 )
               {
                  GXUtil.WriteLog("post:[seudo value changed for attri]"+"PostCommentUsuarioNom");
                  GXUtil.WriteLogRaw("Old: ",Z413PostCommentUsuarioNom);
                  GXUtil.WriteLogRaw("Current: ",T001J2_A413PostCommentUsuarioNom[0]);
               }
               if ( Z411PostCommentDate != T001J2_A411PostCommentDate[0] )
               {
                  GXUtil.WriteLog("post:[seudo value changed for attri]"+"PostCommentDate");
                  GXUtil.WriteLogRaw("Old: ",Z411PostCommentDate);
                  GXUtil.WriteLogRaw("Current: ",T001J2_A411PostCommentDate[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PostComment"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1J64( )
      {
         BeforeValidate1J64( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1J64( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1J64( 0) ;
            CheckOptimisticConcurrency1J64( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1J64( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1J64( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001J17 */
                     pr_default.execute(15, new Object[] {A195PostId, A415PostReferencia, A407PostCommentId, A412PostCommentUsuario, A413PostCommentUsuarioNom, A414PostCommentUsuarioImg, A40001PostCommentUsuarioImg_GXI, A410PostCommentContent, A411PostCommentDate});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("PostComment");
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
               Load1J64( ) ;
            }
            EndLevel1J64( ) ;
         }
         CloseExtendedTableCursors1J64( ) ;
      }

      protected void Update1J64( )
      {
         BeforeValidate1J64( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1J64( ) ;
         }
         if ( ( nIsMod_64 != 0 ) || ( nIsDirty_64 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1J64( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1J64( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1J64( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001J18 */
                        pr_default.execute(16, new Object[] {A412PostCommentUsuario, A413PostCommentUsuarioNom, A410PostCommentContent, A411PostCommentDate, A195PostId, A415PostReferencia, A407PostCommentId});
                        pr_default.close(16);
                        pr_default.SmartCacheProvider.SetUpdated("PostComment");
                        if ( (pr_default.getStatus(16) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PostComment"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1J64( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1J64( ) ;
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
               EndLevel1J64( ) ;
            }
         }
         CloseExtendedTableCursors1J64( ) ;
      }

      protected void DeferredUpdate1J64( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001J19 */
            pr_default.execute(17, new Object[] {A414PostCommentUsuarioImg, A40001PostCommentUsuarioImg_GXI, A195PostId, A415PostReferencia, A407PostCommentId});
            pr_default.close(17);
            pr_default.SmartCacheProvider.SetUpdated("PostComment");
         }
      }

      protected void Delete1J64( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1J64( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1J64( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1J64( ) ;
            AfterConfirm1J64( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1J64( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001J20 */
                  pr_default.execute(18, new Object[] {A195PostId, A415PostReferencia, A407PostCommentId});
                  pr_default.close(18);
                  pr_default.SmartCacheProvider.SetUpdated("PostComment");
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
         sMode64 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1J64( ) ;
         Gx_mode = sMode64;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1J64( )
      {
         standaloneModal1J64( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1J64( )
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

      public void ScanStart1J64( )
      {
         /* Scan By routine */
         /* Using cursor T001J21 */
         pr_default.execute(19, new Object[] {A195PostId, A415PostReferencia});
         RcdFound64 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound64 = 1;
            A407PostCommentId = T001J21_A407PostCommentId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1J64( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound64 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound64 = 1;
            A407PostCommentId = T001J21_A407PostCommentId[0];
         }
      }

      protected void ScanEnd1J64( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm1J64( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1J64( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1J64( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1J64( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1J64( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1J64( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1J64( )
      {
         edtPostCommentId_Enabled = 0;
         AssignProp("", false, edtPostCommentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostCommentId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtPostCommentUsuario_Enabled = 0;
         AssignProp("", false, edtPostCommentUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostCommentUsuario_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtPostCommentUsuarioNom_Enabled = 0;
         AssignProp("", false, edtPostCommentUsuarioNom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostCommentUsuarioNom_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtPostCommentUsuarioImg_Enabled = 0;
         AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostCommentUsuarioImg_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtPostCommentContent_Enabled = 0;
         AssignProp("", false, edtPostCommentContent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostCommentContent_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtPostCommentDate_Enabled = 0;
         AssignProp("", false, edtPostCommentDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostCommentDate_Enabled), 5, 0), !bGXsfl_78_Refreshing);
      }

      protected void send_integrity_lvl_hashes1J64( )
      {
      }

      protected void send_integrity_lvl_hashes1J63( )
      {
      }

      protected void SubsflControlProps_7864( )
      {
         edtPostCommentId_Internalname = "POSTCOMMENTID_"+sGXsfl_78_idx;
         edtPostCommentUsuario_Internalname = "POSTCOMMENTUSUARIO_"+sGXsfl_78_idx;
         edtPostCommentUsuarioNom_Internalname = "POSTCOMMENTUSUARIONOM_"+sGXsfl_78_idx;
         edtPostCommentUsuarioImg_Internalname = "POSTCOMMENTUSUARIOIMG_"+sGXsfl_78_idx;
         edtPostCommentContent_Internalname = "POSTCOMMENTCONTENT_"+sGXsfl_78_idx;
         edtPostCommentDate_Internalname = "POSTCOMMENTDATE_"+sGXsfl_78_idx;
      }

      protected void SubsflControlProps_fel_7864( )
      {
         edtPostCommentId_Internalname = "POSTCOMMENTID_"+sGXsfl_78_fel_idx;
         edtPostCommentUsuario_Internalname = "POSTCOMMENTUSUARIO_"+sGXsfl_78_fel_idx;
         edtPostCommentUsuarioNom_Internalname = "POSTCOMMENTUSUARIONOM_"+sGXsfl_78_fel_idx;
         edtPostCommentUsuarioImg_Internalname = "POSTCOMMENTUSUARIOIMG_"+sGXsfl_78_fel_idx;
         edtPostCommentContent_Internalname = "POSTCOMMENTCONTENT_"+sGXsfl_78_fel_idx;
         edtPostCommentDate_Internalname = "POSTCOMMENTDATE_"+sGXsfl_78_fel_idx;
      }

      protected void AddRow1J64( )
      {
         nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
         SubsflControlProps_7864( ) ;
         SendRow1J64( ) ;
      }

      protected void SendRow1J64( )
      {
         Gridpost_commentRow = GXWebRow.GetNew(context);
         if ( subGridpost_comment_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridpost_comment_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridpost_comment_Class, "") != 0 )
            {
               subGridpost_comment_Linesclass = subGridpost_comment_Class+"Odd";
            }
         }
         else if ( subGridpost_comment_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridpost_comment_Backstyle = 0;
            subGridpost_comment_Backcolor = subGridpost_comment_Allbackcolor;
            if ( StringUtil.StrCmp(subGridpost_comment_Class, "") != 0 )
            {
               subGridpost_comment_Linesclass = subGridpost_comment_Class+"Uniform";
            }
         }
         else if ( subGridpost_comment_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridpost_comment_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridpost_comment_Class, "") != 0 )
            {
               subGridpost_comment_Linesclass = subGridpost_comment_Class+"Odd";
            }
            subGridpost_comment_Backcolor = (int)(0x0);
         }
         else if ( subGridpost_comment_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridpost_comment_Backstyle = 1;
            if ( ((int)((nGXsfl_78_idx) % (2))) == 0 )
            {
               subGridpost_comment_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpost_comment_Class, "") != 0 )
               {
                  subGridpost_comment_Linesclass = subGridpost_comment_Class+"Even";
               }
            }
            else
            {
               subGridpost_comment_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpost_comment_Class, "") != 0 )
               {
                  subGridpost_comment_Linesclass = subGridpost_comment_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_64_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridpost_commentRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostCommentId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A407PostCommentId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A407PostCommentId), "ZZZZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,79);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostCommentId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPostCommentId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_64_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridpost_commentRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostCommentUsuario_Internalname,StringUtil.RTrim( A412PostCommentUsuario),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostCommentUsuario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPostCommentUsuario_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)-1,(bool)true,(string)"NickName",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_64_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridpost_commentRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostCommentUsuarioNom_Internalname,StringUtil.RTrim( A413PostCommentUsuarioNom),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostCommentUsuarioNom_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPostCommentUsuarioNom_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Static Bitmap Variable */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_64_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A414PostCommentUsuarioImg_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A414PostCommentUsuarioImg))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001PostCommentUsuarioImg_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A414PostCommentUsuarioImg)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A414PostCommentUsuarioImg)) ? A40001PostCommentUsuarioImg_GXI : context.PathToRelativeUrl( A414PostCommentUsuarioImg));
         Gridpost_commentRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtPostCommentUsuarioImg_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtPostCommentUsuarioImg_Enabled,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"",(string)"",(string)"",(string)"",(short)0,(bool)A414PostCommentUsuarioImg_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
         AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A414PostCommentUsuarioImg)) ? A40001PostCommentUsuarioImg_GXI : context.PathToRelativeUrl( A414PostCommentUsuarioImg)), !bGXsfl_78_Refreshing);
         AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "IsBlob", StringUtil.BoolToStr( A414PostCommentUsuarioImg_IsBlob), !bGXsfl_78_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_64_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridpost_commentRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostCommentContent_Internalname,(string)A410PostCommentContent,(string)A410PostCommentContent,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostCommentContent_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPostCommentContent_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)78,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_64_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridpost_commentRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostCommentDate_Internalname,context.localUtil.TToC( A411PostCommentDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A411PostCommentDate, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,84);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostCommentDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPostCommentDate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridpost_commentRow);
         send_integrity_lvl_hashes1J64( ) ;
         GXCCtl = "Z407PostCommentId_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z407PostCommentId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z412PostCommentUsuario_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z412PostCommentUsuario));
         GXCCtl = "Z413PostCommentUsuarioNom_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z413PostCommentUsuarioNom));
         GXCCtl = "Z411PostCommentDate_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z411PostCommentDate, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "nRcdDeleted_64_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_64), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_64_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_64), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_64_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_64), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "POSTCOMMENTUSUARIOIMG_" + sGXsfl_78_idx;
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A414PostCommentUsuarioImg);
         GxWebStd.gx_hidden_field( context, "POSTCOMMENTID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POSTCOMMENTUSUARIO_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentUsuario_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POSTCOMMENTUSUARIONOM_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentUsuarioNom_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POSTCOMMENTUSUARIOIMG_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentUsuarioImg_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POSTCOMMENTCONTENT_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentContent_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POSTCOMMENTDATE_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentDate_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridpost_commentContainer.AddRow(Gridpost_commentRow);
      }

      protected void ReadRow1J64( )
      {
         nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
         SubsflControlProps_7864( ) ;
         edtPostCommentId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTCOMMENTID_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPostCommentUsuario_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTCOMMENTUSUARIO_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPostCommentUsuarioNom_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTCOMMENTUSUARIONOM_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPostCommentUsuarioImg_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTCOMMENTUSUARIOIMG_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPostCommentContent_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTCOMMENTCONTENT_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPostCommentDate_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTCOMMENTDATE_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtPostCommentId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPostCommentId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "POSTCOMMENTID_" + sGXsfl_78_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPostCommentId_Internalname;
            wbErr = true;
            A407PostCommentId = 0;
         }
         else
         {
            A407PostCommentId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostCommentId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A412PostCommentUsuario = cgiGet( edtPostCommentUsuario_Internalname);
         A413PostCommentUsuarioNom = cgiGet( edtPostCommentUsuarioNom_Internalname);
         A414PostCommentUsuarioImg = cgiGet( edtPostCommentUsuarioImg_Internalname);
         A410PostCommentContent = cgiGet( edtPostCommentContent_Internalname);
         if ( context.localUtil.VCDateTime( cgiGet( edtPostCommentDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
         {
            GXCCtl = "POSTCOMMENTDATE_" + sGXsfl_78_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Post Comment Date", "")}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPostCommentDate_Internalname;
            wbErr = true;
            A411PostCommentDate = (DateTime)(DateTime.MinValue);
         }
         else
         {
            A411PostCommentDate = context.localUtil.CToT( cgiGet( edtPostCommentDate_Internalname));
         }
         GXCCtl = "Z407PostCommentId_" + sGXsfl_78_idx;
         Z407PostCommentId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z412PostCommentUsuario_" + sGXsfl_78_idx;
         Z412PostCommentUsuario = cgiGet( GXCCtl);
         GXCCtl = "Z413PostCommentUsuarioNom_" + sGXsfl_78_idx;
         Z413PostCommentUsuarioNom = cgiGet( GXCCtl);
         GXCCtl = "Z411PostCommentDate_" + sGXsfl_78_idx;
         Z411PostCommentDate = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         GXCCtl = "nRcdDeleted_64_" + sGXsfl_78_idx;
         nRcdDeleted_64 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_64_" + sGXsfl_78_idx;
         nRcdExists_64 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_64_" + sGXsfl_78_idx;
         nIsMod_64 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         getMultimediaValue(edtPostCommentUsuarioImg_Internalname, ref  A414PostCommentUsuarioImg, ref  A40001PostCommentUsuarioImg_GXI);
      }

      protected void assign_properties_default( )
      {
         defedtPostCommentId_Enabled = edtPostCommentId_Enabled;
      }

      protected void ConfirmValues1J0( )
      {
         nGXsfl_78_idx = 0;
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
         SubsflControlProps_7864( ) ;
         while ( nGXsfl_78_idx < nRC_GXsfl_78 )
         {
            nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
            sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
            SubsflControlProps_7864( ) ;
            ChangePostValue( "Z407PostCommentId_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z407PostCommentId_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z407PostCommentId_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z412PostCommentUsuario_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z412PostCommentUsuario_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z412PostCommentUsuario_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z413PostCommentUsuarioNom_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z413PostCommentUsuarioNom_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z413PostCommentUsuarioNom_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z411PostCommentDate_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z411PostCommentDate_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z411PostCommentDate_"+sGXsfl_78_idx) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("post.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z195PostId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z195PostId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z415PostReferencia", StringUtil.RTrim( Z415PostReferencia));
         GxWebStd.gx_hidden_field( context, "Z416PostUsuario", StringUtil.RTrim( Z416PostUsuario));
         GxWebStd.gx_hidden_field( context, "Z417PostUsuarioNombre", StringUtil.RTrim( Z417PostUsuarioNombre));
         GxWebStd.gx_hidden_field( context, "Z408PostTitle", Z408PostTitle);
         GxWebStd.gx_hidden_field( context, "Z418PostFecha", context.localUtil.TToC( Z418PostFecha, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z419PostDateUpdated", context.localUtil.TToC( Z419PostDateUpdated, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_78", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_78_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "POSTIMAGE_GXI", A40000PostImage_GXI);
         GxWebStd.gx_hidden_field( context, "POSTCOMMENTUSUARIOIMG_GXI", A40001PostCommentUsuarioImg_GXI);
         GXCCtlgxBlob = "POSTIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A409PostImage);
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
         return formatLink("post.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Post" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Post", "") ;
      }

      protected void InitializeNonKey1J63( )
      {
         A416PostUsuario = "";
         AssignAttri("", false, "A416PostUsuario", A416PostUsuario);
         A417PostUsuarioNombre = "";
         AssignAttri("", false, "A417PostUsuarioNombre", A417PostUsuarioNombre);
         A408PostTitle = "";
         AssignAttri("", false, "A408PostTitle", A408PostTitle);
         A418PostFecha = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A418PostFecha", context.localUtil.TToC( A418PostFecha, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A409PostImage = "";
         AssignAttri("", false, "A409PostImage", A409PostImage);
         AssignProp("", false, imgPostImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A409PostImage)) ? A40000PostImage_GXI : context.convertURL( context.PathToRelativeUrl( A409PostImage))), true);
         AssignProp("", false, imgPostImage_Internalname, "SrcSet", context.GetImageSrcSet( A409PostImage), true);
         A40000PostImage_GXI = "";
         AssignProp("", false, imgPostImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A409PostImage)) ? A40000PostImage_GXI : context.convertURL( context.PathToRelativeUrl( A409PostImage))), true);
         AssignProp("", false, imgPostImage_Internalname, "SrcSet", context.GetImageSrcSet( A409PostImage), true);
         A419PostDateUpdated = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A419PostDateUpdated", context.localUtil.TToC( A419PostDateUpdated, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         Z416PostUsuario = "";
         Z417PostUsuarioNombre = "";
         Z408PostTitle = "";
         Z418PostFecha = (DateTime)(DateTime.MinValue);
         Z419PostDateUpdated = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll1J63( )
      {
         A195PostId = 0;
         AssignAttri("", false, "A195PostId", StringUtil.LTrimStr( (decimal)(A195PostId), 18, 0));
         A415PostReferencia = "";
         AssignAttri("", false, "A415PostReferencia", A415PostReferencia);
         InitializeNonKey1J63( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1J64( )
      {
         A412PostCommentUsuario = "";
         A413PostCommentUsuarioNom = "";
         A414PostCommentUsuarioImg = "";
         AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A414PostCommentUsuarioImg)) ? A40001PostCommentUsuarioImg_GXI : context.convertURL( context.PathToRelativeUrl( A414PostCommentUsuarioImg))), !bGXsfl_78_Refreshing);
         AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "SrcSet", context.GetImageSrcSet( A414PostCommentUsuarioImg), true);
         A40001PostCommentUsuarioImg_GXI = "";
         AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A414PostCommentUsuarioImg)) ? A40001PostCommentUsuarioImg_GXI : context.convertURL( context.PathToRelativeUrl( A414PostCommentUsuarioImg))), !bGXsfl_78_Refreshing);
         AssignProp("", false, edtPostCommentUsuarioImg_Internalname, "SrcSet", context.GetImageSrcSet( A414PostCommentUsuarioImg), true);
         A410PostCommentContent = "";
         A411PostCommentDate = (DateTime)(DateTime.MinValue);
         Z412PostCommentUsuario = "";
         Z413PostCommentUsuarioNom = "";
         Z411PostCommentDate = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll1J64( )
      {
         A407PostCommentId = 0;
         InitializeNonKey1J64( ) ;
      }

      protected void StandaloneModalInsert1J64( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021115540", true, true, false);
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
         context.AddJavascriptSource("post.js", "?202673021115541", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties64( )
      {
         edtPostCommentId_Enabled = defedtPostCommentId_Enabled;
         AssignProp("", false, edtPostCommentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostCommentId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
      }

      protected void StartGridControl78( )
      {
         Gridpost_commentContainer.AddObjectProperty("GridName", "Gridpost_comment");
         Gridpost_commentContainer.AddObjectProperty("Header", subGridpost_comment_Header);
         Gridpost_commentContainer.AddObjectProperty("Class", "Grid");
         Gridpost_commentContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridpost_commentContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridpost_commentContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpost_comment_Backcolorstyle), 1, 0, ".", "")));
         Gridpost_commentContainer.AddObjectProperty("CmpContext", "");
         Gridpost_commentContainer.AddObjectProperty("InMasterPage", "false");
         Gridpost_commentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpost_commentColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A407PostCommentId), 18, 0, ".", ""))));
         Gridpost_commentColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentId_Enabled), 5, 0, ".", "")));
         Gridpost_commentContainer.AddColumnProperties(Gridpost_commentColumn);
         Gridpost_commentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpost_commentColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A412PostCommentUsuario)));
         Gridpost_commentColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentUsuario_Enabled), 5, 0, ".", "")));
         Gridpost_commentContainer.AddColumnProperties(Gridpost_commentColumn);
         Gridpost_commentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpost_commentColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A413PostCommentUsuarioNom)));
         Gridpost_commentColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentUsuarioNom_Enabled), 5, 0, ".", "")));
         Gridpost_commentContainer.AddColumnProperties(Gridpost_commentColumn);
         Gridpost_commentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpost_commentColumn.AddObjectProperty("Value", context.convertURL( A414PostCommentUsuarioImg));
         Gridpost_commentColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentUsuarioImg_Enabled), 5, 0, ".", "")));
         Gridpost_commentContainer.AddColumnProperties(Gridpost_commentColumn);
         Gridpost_commentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpost_commentColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A410PostCommentContent));
         Gridpost_commentColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentContent_Enabled), 5, 0, ".", "")));
         Gridpost_commentContainer.AddColumnProperties(Gridpost_commentColumn);
         Gridpost_commentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpost_commentColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A411PostCommentDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
         Gridpost_commentColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostCommentDate_Enabled), 5, 0, ".", "")));
         Gridpost_commentContainer.AddColumnProperties(Gridpost_commentColumn);
         Gridpost_commentContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpost_comment_Selectedindex), 4, 0, ".", "")));
         Gridpost_commentContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpost_comment_Allowselection), 1, 0, ".", "")));
         Gridpost_commentContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpost_comment_Selectioncolor), 9, 0, ".", "")));
         Gridpost_commentContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpost_comment_Allowhovering), 1, 0, ".", "")));
         Gridpost_commentContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpost_comment_Hoveringcolor), 9, 0, ".", "")));
         Gridpost_commentContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpost_comment_Allowcollapsing), 1, 0, ".", "")));
         Gridpost_commentContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpost_comment_Collapsed), 1, 0, ".", "")));
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
         edtPostId_Internalname = "POSTID";
         edtPostReferencia_Internalname = "POSTREFERENCIA";
         edtPostUsuario_Internalname = "POSTUSUARIO";
         edtPostUsuarioNombre_Internalname = "POSTUSUARIONOMBRE";
         edtPostTitle_Internalname = "POSTTITLE";
         edtPostFecha_Internalname = "POSTFECHA";
         imgPostImage_Internalname = "POSTIMAGE";
         edtPostDateUpdated_Internalname = "POSTDATEUPDATED";
         lblTitlecomment_Internalname = "TITLECOMMENT";
         edtPostCommentId_Internalname = "POSTCOMMENTID";
         edtPostCommentUsuario_Internalname = "POSTCOMMENTUSUARIO";
         edtPostCommentUsuarioNom_Internalname = "POSTCOMMENTUSUARIONOM";
         edtPostCommentUsuarioImg_Internalname = "POSTCOMMENTUSUARIOIMG";
         edtPostCommentContent_Internalname = "POSTCOMMENTCONTENT";
         edtPostCommentDate_Internalname = "POSTCOMMENTDATE";
         divCommenttable_Internalname = "COMMENTTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridpost_comment_Internalname = "GRIDPOST_COMMENT";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridpost_comment_Allowcollapsing = 0;
         subGridpost_comment_Allowselection = 0;
         subGridpost_comment_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Post", "");
         edtPostCommentDate_Jsonclick = "";
         edtPostCommentContent_Jsonclick = "";
         edtPostCommentUsuarioNom_Jsonclick = "";
         edtPostCommentUsuario_Jsonclick = "";
         edtPostCommentId_Jsonclick = "";
         subGridpost_comment_Class = "Grid";
         subGridpost_comment_Backcolorstyle = 0;
         edtPostCommentDate_Enabled = 1;
         edtPostCommentContent_Enabled = 1;
         edtPostCommentUsuarioImg_Enabled = 1;
         edtPostCommentUsuarioNom_Enabled = 1;
         edtPostCommentUsuario_Enabled = 1;
         edtPostCommentId_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPostDateUpdated_Jsonclick = "";
         edtPostDateUpdated_Enabled = 1;
         imgPostImage_Enabled = 1;
         edtPostFecha_Jsonclick = "";
         edtPostFecha_Enabled = 1;
         edtPostTitle_Enabled = 1;
         edtPostUsuarioNombre_Jsonclick = "";
         edtPostUsuarioNombre_Enabled = 1;
         edtPostUsuario_Jsonclick = "";
         edtPostUsuario_Enabled = 1;
         edtPostReferencia_Jsonclick = "";
         edtPostReferencia_Enabled = 1;
         edtPostId_Jsonclick = "";
         edtPostId_Enabled = 1;
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

      protected void gxnrGridpost_comment_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_7864( ) ;
         while ( nGXsfl_78_idx <= nRC_GXsfl_78 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1J64( ) ;
            standaloneModal1J64( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1J64( ) ;
            nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
            sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
            SubsflControlProps_7864( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridpost_commentContainer)) ;
         /* End function gxnrGridpost_comment_newrow */
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
         GX_FocusControl = edtPostUsuario_Internalname;
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

      public void Valid_Postreferencia( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A416PostUsuario", StringUtil.RTrim( A416PostUsuario));
         AssignAttri("", false, "A417PostUsuarioNombre", StringUtil.RTrim( A417PostUsuarioNombre));
         AssignAttri("", false, "A408PostTitle", A408PostTitle);
         AssignAttri("", false, "A418PostFecha", context.localUtil.TToC( A418PostFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A409PostImage", context.PathToRelativeUrl( A409PostImage));
         GXCCtlgxBlob = "POSTIMAGE" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A409PostImage));
         AssignAttri("", false, "A40000PostImage_GXI", A40000PostImage_GXI);
         AssignAttri("", false, "A419PostDateUpdated", context.localUtil.TToC( A419PostDateUpdated, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z195PostId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z195PostId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z415PostReferencia", StringUtil.RTrim( Z415PostReferencia));
         GxWebStd.gx_hidden_field( context, "Z416PostUsuario", StringUtil.RTrim( Z416PostUsuario));
         GxWebStd.gx_hidden_field( context, "Z417PostUsuarioNombre", StringUtil.RTrim( Z417PostUsuarioNombre));
         GxWebStd.gx_hidden_field( context, "Z408PostTitle", Z408PostTitle);
         GxWebStd.gx_hidden_field( context, "Z418PostFecha", context.localUtil.TToC( Z418PostFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z409PostImage", context.PathToRelativeUrl( Z409PostImage));
         GxWebStd.gx_hidden_field( context, "Z40000PostImage_GXI", Z40000PostImage_GXI);
         GxWebStd.gx_hidden_field( context, "Z419PostDateUpdated", context.localUtil.TToC( Z419PostDateUpdated, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
         setEventMetadata("VALID_POSTID","{handler:'Valid_Postid',iparms:[]");
         setEventMetadata("VALID_POSTID",",oparms:[]}");
         setEventMetadata("VALID_POSTREFERENCIA","{handler:'Valid_Postreferencia',iparms:[{av:'A195PostId',fld:'POSTID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A415PostReferencia',fld:'POSTREFERENCIA',pic:'',type:'char'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'}]");
         setEventMetadata("VALID_POSTREFERENCIA",",oparms:[{av:'A416PostUsuario',fld:'POSTUSUARIO',pic:'',type:'char'},{av:'A417PostUsuarioNombre',fld:'POSTUSUARIONOMBRE',pic:'',type:'char'},{av:'A408PostTitle',fld:'POSTTITLE',pic:'',type:'svchar'},{av:'A418PostFecha',fld:'POSTFECHA',pic:'99/99/99 99:99',type:'dtime'},{av:'A409PostImage',fld:'POSTIMAGE',pic:'',type:'bits'},{av:'A40000PostImage_GXI',fld:'POSTIMAGE_GXI',pic:'',type:'svchar'},{av:'A419PostDateUpdated',fld:'POSTDATEUPDATED',pic:'99/99/99 99:99',type:'dtime'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z195PostId',type:'int'},{av:'Z415PostReferencia',type:'char'},{av:'Z416PostUsuario',type:'char'},{av:'Z417PostUsuarioNombre',type:'char'},{av:'Z408PostTitle',type:'svchar'},{av:'Z418PostFecha',type:'dtime'},{av:'Z409PostImage',type:'bits'},{av:'Z40000PostImage_GXI',type:'svchar'},{av:'Z419PostDateUpdated',type:'dtime'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_POSTFECHA","{handler:'Valid_Postfecha',iparms:[]");
         setEventMetadata("VALID_POSTFECHA",",oparms:[]}");
         setEventMetadata("VALID_POSTDATEUPDATED","{handler:'Valid_Postdateupdated',iparms:[]");
         setEventMetadata("VALID_POSTDATEUPDATED",",oparms:[]}");
         setEventMetadata("VALID_POSTCOMMENTID","{handler:'Valid_Postcommentid',iparms:[]");
         setEventMetadata("VALID_POSTCOMMENTID",",oparms:[]}");
         setEventMetadata("VALID_POSTCOMMENTDATE","{handler:'Valid_Postcommentdate',iparms:[]");
         setEventMetadata("VALID_POSTCOMMENTDATE",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z415PostReferencia = "";
         Z416PostUsuario = "";
         Z417PostUsuarioNombre = "";
         Z408PostTitle = "";
         Z418PostFecha = (DateTime)(DateTime.MinValue);
         Z419PostDateUpdated = (DateTime)(DateTime.MinValue);
         Z412PostCommentUsuario = "";
         Z413PostCommentUsuarioNom = "";
         Z411PostCommentDate = (DateTime)(DateTime.MinValue);
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
         A415PostReferencia = "";
         A416PostUsuario = "";
         A417PostUsuarioNombre = "";
         A408PostTitle = "";
         A418PostFecha = (DateTime)(DateTime.MinValue);
         A409PostImage = "";
         A40000PostImage_GXI = "";
         sImgUrl = "";
         A419PostDateUpdated = (DateTime)(DateTime.MinValue);
         lblTitlecomment_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridpost_commentContainer = new GXWebGrid( context);
         sMode64 = "";
         sStyleString = "";
         A40001PostCommentUsuarioImg_GXI = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A412PostCommentUsuario = "";
         A413PostCommentUsuarioNom = "";
         A414PostCommentUsuarioImg = "";
         A410PostCommentContent = "";
         A411PostCommentDate = (DateTime)(DateTime.MinValue);
         Z409PostImage = "";
         Z40000PostImage_GXI = "";
         T001J6_A195PostId = new long[1] ;
         T001J6_A415PostReferencia = new string[] {""} ;
         T001J6_A416PostUsuario = new string[] {""} ;
         T001J6_A417PostUsuarioNombre = new string[] {""} ;
         T001J6_A408PostTitle = new string[] {""} ;
         T001J6_A418PostFecha = new DateTime[] {DateTime.MinValue} ;
         T001J6_A40000PostImage_GXI = new string[] {""} ;
         T001J6_A419PostDateUpdated = new DateTime[] {DateTime.MinValue} ;
         T001J6_A409PostImage = new string[] {""} ;
         T001J7_A195PostId = new long[1] ;
         T001J7_A415PostReferencia = new string[] {""} ;
         T001J5_A195PostId = new long[1] ;
         T001J5_A415PostReferencia = new string[] {""} ;
         T001J5_A416PostUsuario = new string[] {""} ;
         T001J5_A417PostUsuarioNombre = new string[] {""} ;
         T001J5_A408PostTitle = new string[] {""} ;
         T001J5_A418PostFecha = new DateTime[] {DateTime.MinValue} ;
         T001J5_A40000PostImage_GXI = new string[] {""} ;
         T001J5_A419PostDateUpdated = new DateTime[] {DateTime.MinValue} ;
         T001J5_A409PostImage = new string[] {""} ;
         sMode63 = "";
         T001J8_A195PostId = new long[1] ;
         T001J8_A415PostReferencia = new string[] {""} ;
         T001J9_A195PostId = new long[1] ;
         T001J9_A415PostReferencia = new string[] {""} ;
         T001J4_A195PostId = new long[1] ;
         T001J4_A415PostReferencia = new string[] {""} ;
         T001J4_A416PostUsuario = new string[] {""} ;
         T001J4_A417PostUsuarioNombre = new string[] {""} ;
         T001J4_A408PostTitle = new string[] {""} ;
         T001J4_A418PostFecha = new DateTime[] {DateTime.MinValue} ;
         T001J4_A40000PostImage_GXI = new string[] {""} ;
         T001J4_A419PostDateUpdated = new DateTime[] {DateTime.MinValue} ;
         T001J4_A409PostImage = new string[] {""} ;
         T001J14_A195PostId = new long[1] ;
         T001J14_A415PostReferencia = new string[] {""} ;
         Z414PostCommentUsuarioImg = "";
         Z40001PostCommentUsuarioImg_GXI = "";
         Z410PostCommentContent = "";
         T001J15_A195PostId = new long[1] ;
         T001J15_A415PostReferencia = new string[] {""} ;
         T001J15_A407PostCommentId = new long[1] ;
         T001J15_A412PostCommentUsuario = new string[] {""} ;
         T001J15_A413PostCommentUsuarioNom = new string[] {""} ;
         T001J15_A40001PostCommentUsuarioImg_GXI = new string[] {""} ;
         T001J15_A410PostCommentContent = new string[] {""} ;
         T001J15_A411PostCommentDate = new DateTime[] {DateTime.MinValue} ;
         T001J15_A414PostCommentUsuarioImg = new string[] {""} ;
         T001J16_A195PostId = new long[1] ;
         T001J16_A415PostReferencia = new string[] {""} ;
         T001J16_A407PostCommentId = new long[1] ;
         T001J3_A195PostId = new long[1] ;
         T001J3_A415PostReferencia = new string[] {""} ;
         T001J3_A407PostCommentId = new long[1] ;
         T001J3_A412PostCommentUsuario = new string[] {""} ;
         T001J3_A413PostCommentUsuarioNom = new string[] {""} ;
         T001J3_A40001PostCommentUsuarioImg_GXI = new string[] {""} ;
         T001J3_A410PostCommentContent = new string[] {""} ;
         T001J3_A411PostCommentDate = new DateTime[] {DateTime.MinValue} ;
         T001J3_A414PostCommentUsuarioImg = new string[] {""} ;
         T001J2_A195PostId = new long[1] ;
         T001J2_A415PostReferencia = new string[] {""} ;
         T001J2_A407PostCommentId = new long[1] ;
         T001J2_A412PostCommentUsuario = new string[] {""} ;
         T001J2_A413PostCommentUsuarioNom = new string[] {""} ;
         T001J2_A40001PostCommentUsuarioImg_GXI = new string[] {""} ;
         T001J2_A410PostCommentContent = new string[] {""} ;
         T001J2_A411PostCommentDate = new DateTime[] {DateTime.MinValue} ;
         T001J2_A414PostCommentUsuarioImg = new string[] {""} ;
         T001J21_A195PostId = new long[1] ;
         T001J21_A415PostReferencia = new string[] {""} ;
         T001J21_A407PostCommentId = new long[1] ;
         Gridpost_commentRow = new GXWebRow();
         subGridpost_comment_Linesclass = "";
         ROClassString = "";
         GXCCtlgxBlob = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridpost_commentColumn = new GXWebColumn();
         ZZ415PostReferencia = "";
         ZZ416PostUsuario = "";
         ZZ417PostUsuarioNombre = "";
         ZZ408PostTitle = "";
         ZZ418PostFecha = (DateTime)(DateTime.MinValue);
         ZZ409PostImage = "";
         ZZ40000PostImage_GXI = "";
         ZZ419PostDateUpdated = (DateTime)(DateTime.MinValue);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.post__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.post__default(),
            new Object[][] {
                new Object[] {
               T001J2_A195PostId, T001J2_A415PostReferencia, T001J2_A407PostCommentId, T001J2_A412PostCommentUsuario, T001J2_A413PostCommentUsuarioNom, T001J2_A40001PostCommentUsuarioImg_GXI, T001J2_A410PostCommentContent, T001J2_A411PostCommentDate, T001J2_A414PostCommentUsuarioImg
               }
               , new Object[] {
               T001J3_A195PostId, T001J3_A415PostReferencia, T001J3_A407PostCommentId, T001J3_A412PostCommentUsuario, T001J3_A413PostCommentUsuarioNom, T001J3_A40001PostCommentUsuarioImg_GXI, T001J3_A410PostCommentContent, T001J3_A411PostCommentDate, T001J3_A414PostCommentUsuarioImg
               }
               , new Object[] {
               T001J4_A195PostId, T001J4_A415PostReferencia, T001J4_A416PostUsuario, T001J4_A417PostUsuarioNombre, T001J4_A408PostTitle, T001J4_A418PostFecha, T001J4_A40000PostImage_GXI, T001J4_A419PostDateUpdated, T001J4_A409PostImage
               }
               , new Object[] {
               T001J5_A195PostId, T001J5_A415PostReferencia, T001J5_A416PostUsuario, T001J5_A417PostUsuarioNombre, T001J5_A408PostTitle, T001J5_A418PostFecha, T001J5_A40000PostImage_GXI, T001J5_A419PostDateUpdated, T001J5_A409PostImage
               }
               , new Object[] {
               T001J6_A195PostId, T001J6_A415PostReferencia, T001J6_A416PostUsuario, T001J6_A417PostUsuarioNombre, T001J6_A408PostTitle, T001J6_A418PostFecha, T001J6_A40000PostImage_GXI, T001J6_A419PostDateUpdated, T001J6_A409PostImage
               }
               , new Object[] {
               T001J7_A195PostId, T001J7_A415PostReferencia
               }
               , new Object[] {
               T001J8_A195PostId, T001J8_A415PostReferencia
               }
               , new Object[] {
               T001J9_A195PostId, T001J9_A415PostReferencia
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001J14_A195PostId, T001J14_A415PostReferencia
               }
               , new Object[] {
               T001J15_A195PostId, T001J15_A415PostReferencia, T001J15_A407PostCommentId, T001J15_A412PostCommentUsuario, T001J15_A413PostCommentUsuarioNom, T001J15_A40001PostCommentUsuarioImg_GXI, T001J15_A410PostCommentContent, T001J15_A411PostCommentDate, T001J15_A414PostCommentUsuarioImg
               }
               , new Object[] {
               T001J16_A195PostId, T001J16_A415PostReferencia, T001J16_A407PostCommentId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001J21_A195PostId, T001J21_A415PostReferencia, T001J21_A407PostCommentId
               }
            }
         );
      }

      private short nRcdDeleted_64 ;
      private short nRcdExists_64 ;
      private short nIsMod_64 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount64 ;
      private short RcdFound64 ;
      private short nBlankRcdUsr64 ;
      private short RcdFound63 ;
      private short Gx_BScreen ;
      private short nIsDirty_64 ;
      private short subGridpost_comment_Backcolorstyle ;
      private short subGridpost_comment_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridpost_comment_Allowselection ;
      private short subGridpost_comment_Allowhovering ;
      private short subGridpost_comment_Allowcollapsing ;
      private short subGridpost_comment_Collapsed ;
      private int nRC_GXsfl_78 ;
      private int nGXsfl_78_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPostId_Enabled ;
      private int edtPostReferencia_Enabled ;
      private int edtPostUsuario_Enabled ;
      private int edtPostUsuarioNombre_Enabled ;
      private int edtPostTitle_Enabled ;
      private int edtPostFecha_Enabled ;
      private int imgPostImage_Enabled ;
      private int edtPostDateUpdated_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtPostCommentId_Enabled ;
      private int edtPostCommentUsuario_Enabled ;
      private int edtPostCommentUsuarioNom_Enabled ;
      private int edtPostCommentUsuarioImg_Enabled ;
      private int edtPostCommentContent_Enabled ;
      private int edtPostCommentDate_Enabled ;
      private int fRowAdded ;
      private int subGridpost_comment_Backcolor ;
      private int subGridpost_comment_Allbackcolor ;
      private int defedtPostCommentId_Enabled ;
      private int idxLst ;
      private int subGridpost_comment_Selectedindex ;
      private int subGridpost_comment_Selectioncolor ;
      private int subGridpost_comment_Hoveringcolor ;
      private long Z195PostId ;
      private long Z407PostCommentId ;
      private long A195PostId ;
      private long GRIDPOST_COMMENT_nFirstRecordOnPage ;
      private long A407PostCommentId ;
      private long ZZ195PostId ;
      private string sPrefix ;
      private string Z415PostReferencia ;
      private string Z416PostUsuario ;
      private string Z417PostUsuarioNombre ;
      private string Z412PostCommentUsuario ;
      private string Z413PostCommentUsuarioNom ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPostId_Internalname ;
      private string sGXsfl_78_idx="0001" ;
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
      private string edtPostId_Jsonclick ;
      private string edtPostReferencia_Internalname ;
      private string A415PostReferencia ;
      private string edtPostReferencia_Jsonclick ;
      private string edtPostUsuario_Internalname ;
      private string A416PostUsuario ;
      private string edtPostUsuario_Jsonclick ;
      private string edtPostUsuarioNombre_Internalname ;
      private string A417PostUsuarioNombre ;
      private string edtPostUsuarioNombre_Jsonclick ;
      private string edtPostTitle_Internalname ;
      private string edtPostFecha_Internalname ;
      private string edtPostFecha_Jsonclick ;
      private string imgPostImage_Internalname ;
      private string sImgUrl ;
      private string edtPostDateUpdated_Internalname ;
      private string edtPostDateUpdated_Jsonclick ;
      private string divCommenttable_Internalname ;
      private string lblTitlecomment_Internalname ;
      private string lblTitlecomment_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode64 ;
      private string edtPostCommentId_Internalname ;
      private string edtPostCommentUsuario_Internalname ;
      private string edtPostCommentUsuarioNom_Internalname ;
      private string edtPostCommentUsuarioImg_Internalname ;
      private string edtPostCommentContent_Internalname ;
      private string edtPostCommentDate_Internalname ;
      private string sStyleString ;
      private string subGridpost_comment_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A412PostCommentUsuario ;
      private string A413PostCommentUsuarioNom ;
      private string sMode63 ;
      private string sGXsfl_78_fel_idx="0001" ;
      private string subGridpost_comment_Class ;
      private string subGridpost_comment_Linesclass ;
      private string ROClassString ;
      private string edtPostCommentId_Jsonclick ;
      private string edtPostCommentUsuario_Jsonclick ;
      private string edtPostCommentUsuarioNom_Jsonclick ;
      private string edtPostCommentContent_Jsonclick ;
      private string edtPostCommentDate_Jsonclick ;
      private string GXCCtlgxBlob ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridpost_comment_Header ;
      private string ZZ415PostReferencia ;
      private string ZZ416PostUsuario ;
      private string ZZ417PostUsuarioNombre ;
      private DateTime Z418PostFecha ;
      private DateTime Z419PostDateUpdated ;
      private DateTime Z411PostCommentDate ;
      private DateTime A418PostFecha ;
      private DateTime A419PostDateUpdated ;
      private DateTime A411PostCommentDate ;
      private DateTime ZZ418PostFecha ;
      private DateTime ZZ419PostDateUpdated ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A409PostImage_IsBlob ;
      private bool bGXsfl_78_Refreshing=false ;
      private bool A414PostCommentUsuarioImg_IsBlob ;
      private string A410PostCommentContent ;
      private string Z410PostCommentContent ;
      private string Z408PostTitle ;
      private string A408PostTitle ;
      private string A40000PostImage_GXI ;
      private string A40001PostCommentUsuarioImg_GXI ;
      private string Z40000PostImage_GXI ;
      private string Z40001PostCommentUsuarioImg_GXI ;
      private string ZZ408PostTitle ;
      private string ZZ40000PostImage_GXI ;
      private string A409PostImage ;
      private string A414PostCommentUsuarioImg ;
      private string Z409PostImage ;
      private string Z414PostCommentUsuarioImg ;
      private string ZZ409PostImage ;
      private GXWebGrid Gridpost_commentContainer ;
      private GXWebRow Gridpost_commentRow ;
      private GXWebColumn Gridpost_commentColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T001J6_A195PostId ;
      private string[] T001J6_A415PostReferencia ;
      private string[] T001J6_A416PostUsuario ;
      private string[] T001J6_A417PostUsuarioNombre ;
      private string[] T001J6_A408PostTitle ;
      private DateTime[] T001J6_A418PostFecha ;
      private string[] T001J6_A40000PostImage_GXI ;
      private DateTime[] T001J6_A419PostDateUpdated ;
      private string[] T001J6_A409PostImage ;
      private long[] T001J7_A195PostId ;
      private string[] T001J7_A415PostReferencia ;
      private long[] T001J5_A195PostId ;
      private string[] T001J5_A415PostReferencia ;
      private string[] T001J5_A416PostUsuario ;
      private string[] T001J5_A417PostUsuarioNombre ;
      private string[] T001J5_A408PostTitle ;
      private DateTime[] T001J5_A418PostFecha ;
      private string[] T001J5_A40000PostImage_GXI ;
      private DateTime[] T001J5_A419PostDateUpdated ;
      private string[] T001J5_A409PostImage ;
      private long[] T001J8_A195PostId ;
      private string[] T001J8_A415PostReferencia ;
      private long[] T001J9_A195PostId ;
      private string[] T001J9_A415PostReferencia ;
      private long[] T001J4_A195PostId ;
      private string[] T001J4_A415PostReferencia ;
      private string[] T001J4_A416PostUsuario ;
      private string[] T001J4_A417PostUsuarioNombre ;
      private string[] T001J4_A408PostTitle ;
      private DateTime[] T001J4_A418PostFecha ;
      private string[] T001J4_A40000PostImage_GXI ;
      private DateTime[] T001J4_A419PostDateUpdated ;
      private string[] T001J4_A409PostImage ;
      private long[] T001J14_A195PostId ;
      private string[] T001J14_A415PostReferencia ;
      private long[] T001J15_A195PostId ;
      private string[] T001J15_A415PostReferencia ;
      private long[] T001J15_A407PostCommentId ;
      private string[] T001J15_A412PostCommentUsuario ;
      private string[] T001J15_A413PostCommentUsuarioNom ;
      private string[] T001J15_A40001PostCommentUsuarioImg_GXI ;
      private string[] T001J15_A410PostCommentContent ;
      private DateTime[] T001J15_A411PostCommentDate ;
      private string[] T001J15_A414PostCommentUsuarioImg ;
      private long[] T001J16_A195PostId ;
      private string[] T001J16_A415PostReferencia ;
      private long[] T001J16_A407PostCommentId ;
      private long[] T001J3_A195PostId ;
      private string[] T001J3_A415PostReferencia ;
      private long[] T001J3_A407PostCommentId ;
      private string[] T001J3_A412PostCommentUsuario ;
      private string[] T001J3_A413PostCommentUsuarioNom ;
      private string[] T001J3_A40001PostCommentUsuarioImg_GXI ;
      private string[] T001J3_A410PostCommentContent ;
      private DateTime[] T001J3_A411PostCommentDate ;
      private string[] T001J3_A414PostCommentUsuarioImg ;
      private long[] T001J2_A195PostId ;
      private string[] T001J2_A415PostReferencia ;
      private long[] T001J2_A407PostCommentId ;
      private string[] T001J2_A412PostCommentUsuario ;
      private string[] T001J2_A413PostCommentUsuarioNom ;
      private string[] T001J2_A40001PostCommentUsuarioImg_GXI ;
      private string[] T001J2_A410PostCommentContent ;
      private DateTime[] T001J2_A411PostCommentDate ;
      private string[] T001J2_A414PostCommentUsuarioImg ;
      private long[] T001J21_A195PostId ;
      private string[] T001J21_A415PostReferencia ;
      private long[] T001J21_A407PostCommentId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class post__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class post__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new ForEachCursor(def[19])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001J2;
        prmT001J2 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0)
        };
        Object[] prmT001J3;
        prmT001J3 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0)
        };
        Object[] prmT001J4;
        prmT001J4 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0)
        };
        Object[] prmT001J5;
        prmT001J5 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0)
        };
        Object[] prmT001J6;
        prmT001J6 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0)
        };
        Object[] prmT001J7;
        prmT001J7 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0)
        };
        Object[] prmT001J8;
        prmT001J8 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0)
        };
        Object[] prmT001J9;
        prmT001J9 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0)
        };
        Object[] prmT001J10;
        prmT001J10 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostUsuario",GXType.NChar,30,0) ,
        new ParDef("@PostUsuarioNombre",GXType.NChar,80,0) ,
        new ParDef("@PostTitle",GXType.NVarChar,256,0) ,
        new ParDef("@PostFecha",GXType.DateTime,8,5) ,
        new ParDef("@PostImage",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@PostImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=6, Tbl="Post", Fld="PostImage"} ,
        new ParDef("@PostDateUpdated",GXType.DateTime,8,5)
        };
        Object[] prmT001J11;
        prmT001J11 = new Object[] {
        new ParDef("@PostUsuario",GXType.NChar,30,0) ,
        new ParDef("@PostUsuarioNombre",GXType.NChar,80,0) ,
        new ParDef("@PostTitle",GXType.NVarChar,256,0) ,
        new ParDef("@PostFecha",GXType.DateTime,8,5) ,
        new ParDef("@PostDateUpdated",GXType.DateTime,8,5) ,
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0)
        };
        Object[] prmT001J12;
        prmT001J12 = new Object[] {
        new ParDef("@PostImage",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@PostImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Post", Fld="PostImage"} ,
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0)
        };
        Object[] prmT001J13;
        prmT001J13 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0)
        };
        Object[] prmT001J14;
        prmT001J14 = new Object[] {
        };
        Object[] prmT001J15;
        prmT001J15 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0)
        };
        Object[] prmT001J16;
        prmT001J16 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0)
        };
        Object[] prmT001J17;
        prmT001J17 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0) ,
        new ParDef("@PostCommentUsuario",GXType.NChar,20,0) ,
        new ParDef("@PostCommentUsuarioNom",GXType.NChar,80,0) ,
        new ParDef("@PostCommentUsuarioImg",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@PostCommentUsuarioImg_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=5, Tbl="PostComment", Fld="PostCommentUsuarioImg"} ,
        new ParDef("@PostCommentContent",GXType.NVarChar,2097152,0) ,
        new ParDef("@PostCommentDate",GXType.DateTime,8,5)
        };
        Object[] prmT001J18;
        prmT001J18 = new Object[] {
        new ParDef("@PostCommentUsuario",GXType.NChar,20,0) ,
        new ParDef("@PostCommentUsuarioNom",GXType.NChar,80,0) ,
        new ParDef("@PostCommentContent",GXType.NVarChar,2097152,0) ,
        new ParDef("@PostCommentDate",GXType.DateTime,8,5) ,
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0)
        };
        Object[] prmT001J19;
        prmT001J19 = new Object[] {
        new ParDef("@PostCommentUsuarioImg",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@PostCommentUsuarioImg_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="PostComment", Fld="PostCommentUsuarioImg"} ,
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0)
        };
        Object[] prmT001J20;
        prmT001J20 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0)
        };
        Object[] prmT001J21;
        prmT001J21 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001J2", "SELECT [PostId], [PostReferencia], [PostCommentId], [PostCommentUsuario], [PostCommentUsuarioNom], [PostCommentUsuarioImg_GXI], [PostCommentContent], [PostCommentDate], [PostCommentUsuarioImg] FROM [PostComment] WITH (UPDLOCK) WHERE [PostId] = @PostId AND [PostReferencia] = @PostReferencia AND [PostCommentId] = @PostCommentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001J3", "SELECT [PostId], [PostReferencia], [PostCommentId], [PostCommentUsuario], [PostCommentUsuarioNom], [PostCommentUsuarioImg_GXI], [PostCommentContent], [PostCommentDate], [PostCommentUsuarioImg] FROM [PostComment] WHERE [PostId] = @PostId AND [PostReferencia] = @PostReferencia AND [PostCommentId] = @PostCommentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001J4", "SELECT [PostId], [PostReferencia], [PostUsuario], [PostUsuarioNombre], [PostTitle], [PostFecha], [PostImage_GXI], [PostDateUpdated], [PostImage] FROM [Post] WITH (UPDLOCK) WHERE [PostId] = @PostId AND [PostReferencia] = @PostReferencia ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001J5", "SELECT [PostId], [PostReferencia], [PostUsuario], [PostUsuarioNombre], [PostTitle], [PostFecha], [PostImage_GXI], [PostDateUpdated], [PostImage] FROM [Post] WHERE [PostId] = @PostId AND [PostReferencia] = @PostReferencia ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001J6", "SELECT TM1.[PostId], TM1.[PostReferencia], TM1.[PostUsuario], TM1.[PostUsuarioNombre], TM1.[PostTitle], TM1.[PostFecha], TM1.[PostImage_GXI], TM1.[PostDateUpdated], TM1.[PostImage] FROM [Post] TM1 WHERE TM1.[PostId] = @PostId and TM1.[PostReferencia] = @PostReferencia ORDER BY TM1.[PostId], TM1.[PostReferencia]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001J6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001J7", "SELECT [PostId], [PostReferencia] FROM [Post] WHERE [PostId] = @PostId AND [PostReferencia] = @PostReferencia  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001J7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001J8", "SELECT TOP 1 [PostId], [PostReferencia] FROM [Post] WHERE ( [PostId] > @PostId or [PostId] = @PostId and [PostReferencia] > @PostReferencia) ORDER BY [PostId], [PostReferencia]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001J8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001J9", "SELECT TOP 1 [PostId], [PostReferencia] FROM [Post] WHERE ( [PostId] < @PostId or [PostId] = @PostId and [PostReferencia] < @PostReferencia) ORDER BY [PostId] DESC, [PostReferencia] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001J9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001J10", "INSERT INTO [Post]([PostId], [PostReferencia], [PostUsuario], [PostUsuarioNombre], [PostTitle], [PostFecha], [PostImage], [PostImage_GXI], [PostDateUpdated]) VALUES(@PostId, @PostReferencia, @PostUsuario, @PostUsuarioNombre, @PostTitle, @PostFecha, @PostImage, @PostImage_GXI, @PostDateUpdated)", GxErrorMask.GX_NOMASK,prmT001J10)
           ,new CursorDef("T001J11", "UPDATE [Post] SET [PostUsuario]=@PostUsuario, [PostUsuarioNombre]=@PostUsuarioNombre, [PostTitle]=@PostTitle, [PostFecha]=@PostFecha, [PostDateUpdated]=@PostDateUpdated  WHERE [PostId] = @PostId AND [PostReferencia] = @PostReferencia", GxErrorMask.GX_NOMASK,prmT001J11)
           ,new CursorDef("T001J12", "UPDATE [Post] SET [PostImage]=@PostImage, [PostImage_GXI]=@PostImage_GXI  WHERE [PostId] = @PostId AND [PostReferencia] = @PostReferencia", GxErrorMask.GX_NOMASK,prmT001J12)
           ,new CursorDef("T001J13", "DELETE FROM [Post]  WHERE [PostId] = @PostId AND [PostReferencia] = @PostReferencia", GxErrorMask.GX_NOMASK,prmT001J13)
           ,new CursorDef("T001J14", "SELECT [PostId], [PostReferencia] FROM [Post] ORDER BY [PostId], [PostReferencia]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001J14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001J15", "SELECT [PostId], [PostReferencia], [PostCommentId], [PostCommentUsuario], [PostCommentUsuarioNom], [PostCommentUsuarioImg_GXI], [PostCommentContent], [PostCommentDate], [PostCommentUsuarioImg] FROM [PostComment] WHERE [PostId] = @PostId and [PostReferencia] = @PostReferencia and [PostCommentId] = @PostCommentId ORDER BY [PostId], [PostReferencia], [PostCommentId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J15,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001J16", "SELECT [PostId], [PostReferencia], [PostCommentId] FROM [PostComment] WHERE [PostId] = @PostId AND [PostReferencia] = @PostReferencia AND [PostCommentId] = @PostCommentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001J17", "INSERT INTO [PostComment]([PostId], [PostReferencia], [PostCommentId], [PostCommentUsuario], [PostCommentUsuarioNom], [PostCommentUsuarioImg], [PostCommentUsuarioImg_GXI], [PostCommentContent], [PostCommentDate]) VALUES(@PostId, @PostReferencia, @PostCommentId, @PostCommentUsuario, @PostCommentUsuarioNom, @PostCommentUsuarioImg, @PostCommentUsuarioImg_GXI, @PostCommentContent, @PostCommentDate)", GxErrorMask.GX_NOMASK,prmT001J17)
           ,new CursorDef("T001J18", "UPDATE [PostComment] SET [PostCommentUsuario]=@PostCommentUsuario, [PostCommentUsuarioNom]=@PostCommentUsuarioNom, [PostCommentContent]=@PostCommentContent, [PostCommentDate]=@PostCommentDate  WHERE [PostId] = @PostId AND [PostReferencia] = @PostReferencia AND [PostCommentId] = @PostCommentId", GxErrorMask.GX_NOMASK,prmT001J18)
           ,new CursorDef("T001J19", "UPDATE [PostComment] SET [PostCommentUsuarioImg]=@PostCommentUsuarioImg, [PostCommentUsuarioImg_GXI]=@PostCommentUsuarioImg_GXI  WHERE [PostId] = @PostId AND [PostReferencia] = @PostReferencia AND [PostCommentId] = @PostCommentId", GxErrorMask.GX_NOMASK,prmT001J19)
           ,new CursorDef("T001J20", "DELETE FROM [PostComment]  WHERE [PostId] = @PostId AND [PostReferencia] = @PostReferencia AND [PostCommentId] = @PostCommentId", GxErrorMask.GX_NOMASK,prmT001J20)
           ,new CursorDef("T001J21", "SELECT [PostId], [PostReferencia], [PostCommentId] FROM [PostComment] WHERE [PostId] = @PostId and [PostReferencia] = @PostReferencia ORDER BY [PostId], [PostReferencia], [PostCommentId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J21,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(6));
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(6));
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(7));
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(7));
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(7));
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(6));
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
     }
  }

}

}
