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
   public class secuserrole : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A18SecUserId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A18SecUserId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A145usuariosId = GetPar( "usuariosId");
            n145usuariosId = false;
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A145usuariosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A16SecRoleId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A16SecRoleId", StringUtil.LTrimStr( (decimal)(A16SecRoleId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A16SecRoleId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Sec User Role", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public secuserrole( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserrole( IGxContext context )
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
         cmbSecUserRoleEstado = new GXCombobox();
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
         if ( cmbSecUserRoleEstado.ItemCount > 0 )
         {
            A551SecUserRoleEstado = cmbSecUserRoleEstado.getValidValue(A551SecUserRoleEstado);
            AssignAttri("", false, "A551SecUserRoleEstado", A551SecUserRoleEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSecUserRoleEstado.CurrentValue = StringUtil.RTrim( A551SecUserRoleEstado);
            AssignProp("", false, cmbSecUserRoleEstado_Internalname, "Values", cmbSecUserRoleEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Sec User Role", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecUserRole.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"wwpbaseobjects.gx0080.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SECUSERID"+"'), id:'"+"SECUSERID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"SECROLEID"+"'), id:'"+"SECROLEID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_WWPBaseObjects/SecUserRole.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserId_Internalname, context.GetMessage( "Usuario Nro.", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A18SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSecUserId_Enabled!=0) ? context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecUserId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SecUserRole.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_18_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_18_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_18_Internalname, sImgUrl, imgprompt_18_Link, "", "", context.GetTheme( ), imgprompt_18_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecRoleId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecRoleId_Internalname, context.GetMessage( "Role Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecRoleId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16SecRoleId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSecRoleId_Enabled!=0) ? context.localUtil.Format( (decimal)(A16SecRoleId), "ZZZ9") : context.localUtil.Format( (decimal)(A16SecRoleId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecRoleId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecRoleId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SecUserRole.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_16_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_16_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_16_Internalname, sImgUrl, imgprompt_16_Link, "", "", context.GetTheme( ), imgprompt_16_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtusuariosNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtusuariosNombre_Internalname, StringUtil.RTrim( A222usuariosNombre), StringUtil.RTrim( context.localUtil.Format( A222usuariosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtusuariosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecRoleName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecRoleName_Internalname, context.GetMessage( "Role Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecRoleName_Internalname, A25SecRoleName, StringUtil.RTrim( context.localUtil.Format( A25SecRoleName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecRoleName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecRoleName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecRoleDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecRoleDescription_Internalname, context.GetMessage( "Role Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecRoleDescription_Internalname, A24SecRoleDescription, StringUtil.RTrim( context.localUtil.Format( A24SecRoleDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecRoleDescription_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecRoleDescription_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSecUserRoleEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSecUserRoleEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSecUserRoleEstado, cmbSecUserRoleEstado_Internalname, StringUtil.RTrim( A551SecUserRoleEstado), 1, cmbSecUserRoleEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSecUserRoleEstado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_WWPBaseObjects/SecUserRole.htm");
         cmbSecUserRoleEstado.CurrentValue = StringUtil.RTrim( A551SecUserRoleEstado);
         AssignProp("", false, cmbSecUserRoleEstado_Internalname, "Values", (string)(cmbSecUserRoleEstado.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserRole.htm");
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
            Z18SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z18SecUserId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z16SecRoleId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z16SecRoleId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z551SecUserRoleEstado = cgiGet( "Z551SecUserRoleEstado");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A145usuariosId = cgiGet( "USUARIOSID");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECUSERID");
               AnyError = 1;
               GX_FocusControl = edtSecUserId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A18SecUserId = 0;
               AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
            }
            else
            {
               A18SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSecRoleId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecRoleId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECROLEID");
               AnyError = 1;
               GX_FocusControl = edtSecRoleId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A16SecRoleId = 0;
               AssignAttri("", false, "A16SecRoleId", StringUtil.LTrimStr( (decimal)(A16SecRoleId), 4, 0));
            }
            else
            {
               A16SecRoleId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecRoleId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A16SecRoleId", StringUtil.LTrimStr( (decimal)(A16SecRoleId), 4, 0));
            }
            A222usuariosNombre = cgiGet( edtusuariosNombre_Internalname);
            AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
            A25SecRoleName = cgiGet( edtSecRoleName_Internalname);
            AssignAttri("", false, "A25SecRoleName", A25SecRoleName);
            A24SecRoleDescription = cgiGet( edtSecRoleDescription_Internalname);
            AssignAttri("", false, "A24SecRoleDescription", A24SecRoleDescription);
            cmbSecUserRoleEstado.CurrentValue = cgiGet( cmbSecUserRoleEstado_Internalname);
            A551SecUserRoleEstado = cgiGet( cmbSecUserRoleEstado_Internalname);
            AssignAttri("", false, "A551SecUserRoleEstado", A551SecUserRoleEstado);
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
               A18SecUserId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
               A16SecRoleId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A16SecRoleId", StringUtil.LTrimStr( (decimal)(A16SecRoleId), 4, 0));
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
               InitAll078( ) ;
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
         DisableAttributes078( ) ;
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

      protected void ResetCaption070( )
      {
      }

      protected void ZM078( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z551SecUserRoleEstado = T00073_A551SecUserRoleEstado[0];
            }
            else
            {
               Z551SecUserRoleEstado = A551SecUserRoleEstado;
            }
         }
         if ( GX_JID == -2 )
         {
            Z551SecUserRoleEstado = A551SecUserRoleEstado;
            Z18SecUserId = A18SecUserId;
            Z16SecRoleId = A16SecRoleId;
            Z145usuariosId = A145usuariosId;
            Z222usuariosNombre = A222usuariosNombre;
            Z25SecRoleName = A25SecRoleName;
            Z24SecRoleDescription = A24SecRoleDescription;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_18_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SECUSERID"+"'), id:'"+"SECUSERID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_16_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SECROLEID"+"'), id:'"+"SECROLEID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");");
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

      protected void Load078( )
      {
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {A18SecUserId, A16SecRoleId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound8 = 1;
            A145usuariosId = T00077_A145usuariosId[0];
            n145usuariosId = T00077_n145usuariosId[0];
            A222usuariosNombre = T00077_A222usuariosNombre[0];
            AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
            A25SecRoleName = T00077_A25SecRoleName[0];
            AssignAttri("", false, "A25SecRoleName", A25SecRoleName);
            A24SecRoleDescription = T00077_A24SecRoleDescription[0];
            AssignAttri("", false, "A24SecRoleDescription", A24SecRoleDescription);
            A551SecUserRoleEstado = T00077_A551SecUserRoleEstado[0];
            AssignAttri("", false, "A551SecUserRoleEstado", A551SecUserRoleEstado);
            ZM078( -2) ;
         }
         pr_default.close(5);
         OnLoadActions078( ) ;
      }

      protected void OnLoadActions078( )
      {
      }

      protected void CheckExtendedTable078( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A145usuariosId = T00074_A145usuariosId[0];
         n145usuariosId = T00074_n145usuariosId[0];
         pr_default.close(2);
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "usuarios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOSID");
               AnyError = 1;
            }
         }
         A222usuariosNombre = T00076_A222usuariosNombre[0];
         AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
         pr_default.close(4);
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {A16SecRoleId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Role", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
            GX_FocusControl = edtSecRoleId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A25SecRoleName = T00075_A25SecRoleName[0];
         AssignAttri("", false, "A25SecRoleName", A25SecRoleName);
         A24SecRoleDescription = T00075_A24SecRoleDescription[0];
         AssignAttri("", false, "A24SecRoleDescription", A24SecRoleDescription);
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A551SecUserRoleEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A551SecUserRoleEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A551SecUserRoleEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A551SecUserRoleEstado, "BLO") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "SECUSERROLEESTADO");
            AnyError = 1;
            GX_FocusControl = cmbSecUserRoleEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors078( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( long A18SecUserId )
      {
         /* Using cursor T00078 */
         pr_default.execute(6, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A145usuariosId = T00078_A145usuariosId[0];
         n145usuariosId = T00078_n145usuariosId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A145usuariosId))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_5( string A145usuariosId )
      {
         /* Using cursor T00079 */
         pr_default.execute(7, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "usuarios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOSID");
               AnyError = 1;
            }
         }
         A222usuariosNombre = T00079_A222usuariosNombre[0];
         AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A222usuariosNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_4( short A16SecRoleId )
      {
         /* Using cursor T000710 */
         pr_default.execute(8, new Object[] {A16SecRoleId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Role", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
            GX_FocusControl = edtSecRoleId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A25SecRoleName = T000710_A25SecRoleName[0];
         AssignAttri("", false, "A25SecRoleName", A25SecRoleName);
         A24SecRoleDescription = T000710_A24SecRoleDescription[0];
         AssignAttri("", false, "A24SecRoleDescription", A24SecRoleDescription);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A25SecRoleName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A24SecRoleDescription)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey078( )
      {
         /* Using cursor T000711 */
         pr_default.execute(9, new Object[] {A18SecUserId, A16SecRoleId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A18SecUserId, A16SecRoleId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM078( 2) ;
            RcdFound8 = 1;
            A551SecUserRoleEstado = T00073_A551SecUserRoleEstado[0];
            AssignAttri("", false, "A551SecUserRoleEstado", A551SecUserRoleEstado);
            A18SecUserId = T00073_A18SecUserId[0];
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
            A16SecRoleId = T00073_A16SecRoleId[0];
            AssignAttri("", false, "A16SecRoleId", StringUtil.LTrimStr( (decimal)(A16SecRoleId), 4, 0));
            Z18SecUserId = A18SecUserId;
            Z16SecRoleId = A16SecRoleId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load078( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey078( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey078( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey078( ) ;
         if ( RcdFound8 == 0 )
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
         RcdFound8 = 0;
         /* Using cursor T000712 */
         pr_default.execute(10, new Object[] {A18SecUserId, A16SecRoleId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000712_A18SecUserId[0] < A18SecUserId ) || ( T000712_A18SecUserId[0] == A18SecUserId ) && ( T000712_A16SecRoleId[0] < A16SecRoleId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000712_A18SecUserId[0] > A18SecUserId ) || ( T000712_A18SecUserId[0] == A18SecUserId ) && ( T000712_A16SecRoleId[0] > A16SecRoleId ) ) )
            {
               A18SecUserId = T000712_A18SecUserId[0];
               AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
               A16SecRoleId = T000712_A16SecRoleId[0];
               AssignAttri("", false, "A16SecRoleId", StringUtil.LTrimStr( (decimal)(A16SecRoleId), 4, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T000713 */
         pr_default.execute(11, new Object[] {A18SecUserId, A16SecRoleId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000713_A18SecUserId[0] > A18SecUserId ) || ( T000713_A18SecUserId[0] == A18SecUserId ) && ( T000713_A16SecRoleId[0] > A16SecRoleId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000713_A18SecUserId[0] < A18SecUserId ) || ( T000713_A18SecUserId[0] == A18SecUserId ) && ( T000713_A16SecRoleId[0] < A16SecRoleId ) ) )
            {
               A18SecUserId = T000713_A18SecUserId[0];
               AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
               A16SecRoleId = T000713_A16SecRoleId[0];
               AssignAttri("", false, "A16SecRoleId", StringUtil.LTrimStr( (decimal)(A16SecRoleId), 4, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey078( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert078( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( ( A18SecUserId != Z18SecUserId ) || ( A16SecRoleId != Z16SecRoleId ) )
               {
                  A18SecUserId = Z18SecUserId;
                  AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
                  A16SecRoleId = Z16SecRoleId;
                  AssignAttri("", false, "A16SecRoleId", StringUtil.LTrimStr( (decimal)(A16SecRoleId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SECUSERID");
                  AnyError = 1;
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update078( ) ;
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A18SecUserId != Z18SecUserId ) || ( A16SecRoleId != Z16SecRoleId ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert078( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SECUSERID");
                     AnyError = 1;
                     GX_FocusControl = edtSecUserId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSecUserId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert078( ) ;
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
         if ( ( A18SecUserId != Z18SecUserId ) || ( A16SecRoleId != Z16SecRoleId ) )
         {
            A18SecUserId = Z18SecUserId;
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
            A16SecRoleId = Z16SecRoleId;
            AssignAttri("", false, "A16SecRoleId", StringUtil.LTrimStr( (decimal)(A16SecRoleId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSecUserId_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = cmbSecUserRoleEstado_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart078( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbSecUserRoleEstado_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd078( ) ;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbSecUserRoleEstado_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbSecUserRoleEstado_Internalname;
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
         ScanStart078( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound8 != 0 )
            {
               ScanNext078( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbSecUserRoleEstado_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd078( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency078( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A18SecUserId, A16SecRoleId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserRole"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z551SecUserRoleEstado, T00072_A551SecUserRoleEstado[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z551SecUserRoleEstado, T00072_A551SecUserRoleEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secuserrole:[seudo value changed for attri]"+"SecUserRoleEstado");
                  GXUtil.WriteLogRaw("Old: ",Z551SecUserRoleEstado);
                  GXUtil.WriteLogRaw("Current: ",T00072_A551SecUserRoleEstado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecUserRole"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert078( )
      {
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable078( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM078( 0) ;
            CheckOptimisticConcurrency078( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm078( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert078( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000714 */
                     pr_default.execute(12, new Object[] {A551SecUserRoleEstado, A18SecUserId, A16SecRoleId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserRole");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ResetCaption070( ) ;
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
               Load078( ) ;
            }
            EndLevel078( ) ;
         }
         CloseExtendedTableCursors078( ) ;
      }

      protected void Update078( )
      {
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable078( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency078( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm078( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate078( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000715 */
                     pr_default.execute(13, new Object[] {A551SecUserRoleEstado, A18SecUserId, A16SecRoleId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserRole");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserRole"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate078( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption070( ) ;
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
            EndLevel078( ) ;
         }
         CloseExtendedTableCursors078( ) ;
      }

      protected void DeferredUpdate078( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency078( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls078( ) ;
            AfterConfirm078( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete078( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000716 */
                  pr_default.execute(14, new Object[] {A18SecUserId, A16SecRoleId});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("SecUserRole");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound8 == 0 )
                        {
                           InitAll078( ) ;
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
                        ResetCaption070( ) ;
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel078( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls078( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000717 */
            pr_default.execute(15, new Object[] {A18SecUserId});
            A145usuariosId = T000717_A145usuariosId[0];
            n145usuariosId = T000717_n145usuariosId[0];
            pr_default.close(15);
            /* Using cursor T000718 */
            pr_default.execute(16, new Object[] {n145usuariosId, A145usuariosId});
            A222usuariosNombre = T000718_A222usuariosNombre[0];
            AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
            pr_default.close(16);
            /* Using cursor T000719 */
            pr_default.execute(17, new Object[] {A16SecRoleId});
            A25SecRoleName = T000719_A25SecRoleName[0];
            AssignAttri("", false, "A25SecRoleName", A25SecRoleName);
            A24SecRoleDescription = T000719_A24SecRoleDescription[0];
            AssignAttri("", false, "A24SecRoleDescription", A24SecRoleDescription);
            pr_default.close(17);
         }
      }

      protected void EndLevel078( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete078( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(17);
            pr_default.close(16);
            context.CommitDataStores("wwpbaseobjects.secuserrole",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(17);
            pr_default.close(16);
            context.RollbackDataStores("wwpbaseobjects.secuserrole",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart078( )
      {
         /* Using cursor T000720 */
         pr_default.execute(18);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound8 = 1;
            A18SecUserId = T000720_A18SecUserId[0];
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
            A16SecRoleId = T000720_A16SecRoleId[0];
            AssignAttri("", false, "A16SecRoleId", StringUtil.LTrimStr( (decimal)(A16SecRoleId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext078( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound8 = 1;
            A18SecUserId = T000720_A18SecUserId[0];
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
            A16SecRoleId = T000720_A16SecRoleId[0];
            AssignAttri("", false, "A16SecRoleId", StringUtil.LTrimStr( (decimal)(A16SecRoleId), 4, 0));
         }
      }

      protected void ScanEnd078( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm078( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert078( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate078( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete078( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete078( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate078( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes078( )
      {
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         edtSecRoleId_Enabled = 0;
         AssignProp("", false, edtSecRoleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecRoleId_Enabled), 5, 0), true);
         edtusuariosNombre_Enabled = 0;
         AssignProp("", false, edtusuariosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNombre_Enabled), 5, 0), true);
         edtSecRoleName_Enabled = 0;
         AssignProp("", false, edtSecRoleName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecRoleName_Enabled), 5, 0), true);
         edtSecRoleDescription_Enabled = 0;
         AssignProp("", false, edtSecRoleDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecRoleDescription_Enabled), 5, 0), true);
         cmbSecUserRoleEstado.Enabled = 0;
         AssignProp("", false, cmbSecUserRoleEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSecUserRoleEstado.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes078( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.secuserrole.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z18SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z16SecRoleId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16SecRoleId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z551SecUserRoleEstado", StringUtil.RTrim( Z551SecUserRoleEstado));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "USUARIOSID", StringUtil.RTrim( A145usuariosId));
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
         return formatLink("wwpbaseobjects.secuserrole.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SecUserRole" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Sec User Role", "") ;
      }

      protected void InitializeNonKey078( )
      {
         A145usuariosId = "";
         n145usuariosId = false;
         AssignAttri("", false, "A145usuariosId", A145usuariosId);
         A222usuariosNombre = "";
         AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
         A25SecRoleName = "";
         AssignAttri("", false, "A25SecRoleName", A25SecRoleName);
         A24SecRoleDescription = "";
         AssignAttri("", false, "A24SecRoleDescription", A24SecRoleDescription);
         A551SecUserRoleEstado = "";
         AssignAttri("", false, "A551SecUserRoleEstado", A551SecUserRoleEstado);
         Z551SecUserRoleEstado = "";
      }

      protected void InitAll078( )
      {
         A18SecUserId = 0;
         AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
         A16SecRoleId = 0;
         AssignAttri("", false, "A16SecRoleId", StringUtil.LTrimStr( (decimal)(A16SecRoleId), 4, 0));
         InitializeNonKey078( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269319593628", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/secuserrole.js", "?20269319593629", false, true, false);
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
         edtSecUserId_Internalname = "SECUSERID";
         edtSecRoleId_Internalname = "SECROLEID";
         edtusuariosNombre_Internalname = "USUARIOSNOMBRE";
         edtSecRoleName_Internalname = "SECROLENAME";
         edtSecRoleDescription_Internalname = "SECROLEDESCRIPTION";
         cmbSecUserRoleEstado_Internalname = "SECUSERROLEESTADO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_18_Internalname = "PROMPT_18";
         imgprompt_16_Internalname = "PROMPT_16";
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
         Form.Caption = context.GetMessage( "Sec User Role", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbSecUserRoleEstado_Jsonclick = "";
         cmbSecUserRoleEstado.Enabled = 1;
         edtSecRoleDescription_Jsonclick = "";
         edtSecRoleDescription_Enabled = 0;
         edtSecRoleName_Jsonclick = "";
         edtSecRoleName_Enabled = 0;
         edtusuariosNombre_Jsonclick = "";
         edtusuariosNombre_Enabled = 0;
         imgprompt_16_Visible = 1;
         imgprompt_16_Link = "";
         edtSecRoleId_Jsonclick = "";
         edtSecRoleId_Enabled = 1;
         imgprompt_18_Visible = 1;
         imgprompt_18_Link = "";
         edtSecUserId_Jsonclick = "";
         edtSecUserId_Enabled = 1;
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
         cmbSecUserRoleEstado.Name = "SECUSERROLEESTADO";
         cmbSecUserRoleEstado.WebTags = "";
         cmbSecUserRoleEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbSecUserRoleEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbSecUserRoleEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbSecUserRoleEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbSecUserRoleEstado.ItemCount > 0 )
         {
            A551SecUserRoleEstado = cmbSecUserRoleEstado.getValidValue(A551SecUserRoleEstado);
            AssignAttri("", false, "A551SecUserRoleEstado", A551SecUserRoleEstado);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T000717 */
         pr_default.execute(15, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A145usuariosId = T000717_A145usuariosId[0];
         n145usuariosId = T000717_n145usuariosId[0];
         pr_default.close(15);
         /* Using cursor T000718 */
         pr_default.execute(16, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "usuarios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOSID");
               AnyError = 1;
            }
         }
         A222usuariosNombre = T000718_A222usuariosNombre[0];
         AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
         pr_default.close(16);
         /* Using cursor T000719 */
         pr_default.execute(17, new Object[] {A16SecRoleId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Role", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
            GX_FocusControl = edtSecRoleId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A25SecRoleName = T000719_A25SecRoleName[0];
         AssignAttri("", false, "A25SecRoleName", A25SecRoleName);
         A24SecRoleDescription = T000719_A24SecRoleDescription[0];
         AssignAttri("", false, "A24SecRoleDescription", A24SecRoleDescription);
         pr_default.close(17);
         GX_FocusControl = cmbSecUserRoleEstado_Internalname;
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

      public void Valid_Secuserid( )
      {
         n145usuariosId = false;
         /* Using cursor T000717 */
         pr_default.execute(15, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
         }
         A145usuariosId = T000717_A145usuariosId[0];
         n145usuariosId = T000717_n145usuariosId[0];
         pr_default.close(15);
         /* Using cursor T000718 */
         pr_default.execute(16, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "usuarios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOSID");
               AnyError = 1;
            }
         }
         A222usuariosNombre = T000718_A222usuariosNombre[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A145usuariosId", StringUtil.RTrim( A145usuariosId));
         AssignAttri("", false, "A222usuariosNombre", StringUtil.RTrim( A222usuariosNombre));
      }

      public void Valid_Secroleid( )
      {
         A551SecUserRoleEstado = cmbSecUserRoleEstado.CurrentValue;
         cmbSecUserRoleEstado.CurrentValue = A551SecUserRoleEstado;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000719 */
         pr_default.execute(17, new Object[] {A16SecRoleId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Role", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
            GX_FocusControl = edtSecRoleId_Internalname;
         }
         A25SecRoleName = T000719_A25SecRoleName[0];
         A24SecRoleDescription = T000719_A24SecRoleDescription[0];
         pr_default.close(17);
         dynload_actions( ) ;
         if ( cmbSecUserRoleEstado.ItemCount > 0 )
         {
            A551SecUserRoleEstado = cmbSecUserRoleEstado.getValidValue(A551SecUserRoleEstado);
            cmbSecUserRoleEstado.CurrentValue = A551SecUserRoleEstado;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSecUserRoleEstado.CurrentValue = StringUtil.RTrim( A551SecUserRoleEstado);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A551SecUserRoleEstado", StringUtil.RTrim( A551SecUserRoleEstado));
         cmbSecUserRoleEstado.CurrentValue = StringUtil.RTrim( A551SecUserRoleEstado);
         AssignProp("", false, cmbSecUserRoleEstado_Internalname, "Values", cmbSecUserRoleEstado.ToJavascriptSource(), true);
         AssignAttri("", false, "A145usuariosId", StringUtil.RTrim( A145usuariosId));
         AssignAttri("", false, "A222usuariosNombre", StringUtil.RTrim( A222usuariosNombre));
         AssignAttri("", false, "A25SecRoleName", A25SecRoleName);
         AssignAttri("", false, "A24SecRoleDescription", A24SecRoleDescription);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z18SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18SecUserId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z16SecRoleId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16SecRoleId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z551SecUserRoleEstado", StringUtil.RTrim( Z551SecUserRoleEstado));
         GxWebStd.gx_hidden_field( context, "Z145usuariosId", StringUtil.RTrim( Z145usuariosId));
         GxWebStd.gx_hidden_field( context, "Z222usuariosNombre", StringUtil.RTrim( Z222usuariosNombre));
         GxWebStd.gx_hidden_field( context, "Z25SecRoleName", Z25SecRoleName);
         GxWebStd.gx_hidden_field( context, "Z24SecRoleDescription", Z24SecRoleDescription);
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
         setEventMetadata("VALID_SECUSERID","{handler:'Valid_Secuserid',iparms:[{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A145usuariosId',fld:'USUARIOSID',pic:'',type:'char'},{av:'A222usuariosNombre',fld:'USUARIOSNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("VALID_SECUSERID",",oparms:[{av:'A145usuariosId',fld:'USUARIOSID',pic:'',type:'char'},{av:'A222usuariosNombre',fld:'USUARIOSNOMBRE',pic:'',type:'char'}]}");
         setEventMetadata("VALID_SECROLEID","{handler:'Valid_Secroleid',iparms:[{av:'cmbSecUserRoleEstado'},{av:'A551SecUserRoleEstado',fld:'SECUSERROLEESTADO',pic:'',type:'char'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A16SecRoleId',fld:'SECROLEID',pic:'ZZZ9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'}]");
         setEventMetadata("VALID_SECROLEID",",oparms:[{av:'cmbSecUserRoleEstado'},{av:'A551SecUserRoleEstado',fld:'SECUSERROLEESTADO',pic:'',type:'char'},{av:'A145usuariosId',fld:'USUARIOSID',pic:'',type:'char'},{av:'A222usuariosNombre',fld:'USUARIOSNOMBRE',pic:'',type:'char'},{av:'A25SecRoleName',fld:'SECROLENAME',pic:'',type:'svchar'},{av:'A24SecRoleDescription',fld:'SECROLEDESCRIPTION',pic:'',type:'svchar'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z18SecUserId',type:'int'},{av:'Z16SecRoleId',type:'int'},{av:'Z551SecUserRoleEstado',type:'char'},{av:'Z145usuariosId',type:'char'},{av:'Z222usuariosNombre',type:'char'},{av:'Z25SecRoleName',type:'svchar'},{av:'Z24SecRoleDescription',type:'svchar'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_SECUSERROLEESTADO","{handler:'Valid_Secuserroleestado',iparms:[]");
         setEventMetadata("VALID_SECUSERROLEESTADO",",oparms:[]}");
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
         pr_default.close(15);
         pr_default.close(17);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z551SecUserRoleEstado = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A145usuariosId = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A551SecUserRoleEstado = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         imgprompt_18_gximage = "";
         sImgUrl = "";
         imgprompt_16_gximage = "";
         A222usuariosNombre = "";
         A25SecRoleName = "";
         A24SecRoleDescription = "";
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
         Z145usuariosId = "";
         Z222usuariosNombre = "";
         Z25SecRoleName = "";
         Z24SecRoleDescription = "";
         T00077_A145usuariosId = new string[] {""} ;
         T00077_n145usuariosId = new bool[] {false} ;
         T00077_A222usuariosNombre = new string[] {""} ;
         T00077_A25SecRoleName = new string[] {""} ;
         T00077_A24SecRoleDescription = new string[] {""} ;
         T00077_A551SecUserRoleEstado = new string[] {""} ;
         T00077_A18SecUserId = new long[1] ;
         T00077_A16SecRoleId = new short[1] ;
         T00074_A145usuariosId = new string[] {""} ;
         T00074_n145usuariosId = new bool[] {false} ;
         T00076_A222usuariosNombre = new string[] {""} ;
         T00075_A25SecRoleName = new string[] {""} ;
         T00075_A24SecRoleDescription = new string[] {""} ;
         T00078_A145usuariosId = new string[] {""} ;
         T00078_n145usuariosId = new bool[] {false} ;
         T00079_A222usuariosNombre = new string[] {""} ;
         T000710_A25SecRoleName = new string[] {""} ;
         T000710_A24SecRoleDescription = new string[] {""} ;
         T000711_A18SecUserId = new long[1] ;
         T000711_A16SecRoleId = new short[1] ;
         T00073_A551SecUserRoleEstado = new string[] {""} ;
         T00073_A18SecUserId = new long[1] ;
         T00073_A16SecRoleId = new short[1] ;
         sMode8 = "";
         T000712_A18SecUserId = new long[1] ;
         T000712_A16SecRoleId = new short[1] ;
         T000713_A18SecUserId = new long[1] ;
         T000713_A16SecRoleId = new short[1] ;
         T00072_A551SecUserRoleEstado = new string[] {""} ;
         T00072_A18SecUserId = new long[1] ;
         T00072_A16SecRoleId = new short[1] ;
         T000717_A145usuariosId = new string[] {""} ;
         T000717_n145usuariosId = new bool[] {false} ;
         T000718_A222usuariosNombre = new string[] {""} ;
         T000719_A25SecRoleName = new string[] {""} ;
         T000719_A24SecRoleDescription = new string[] {""} ;
         T000720_A18SecUserId = new long[1] ;
         T000720_A16SecRoleId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ551SecUserRoleEstado = "";
         ZZ145usuariosId = "";
         ZZ222usuariosNombre = "";
         ZZ25SecRoleName = "";
         ZZ24SecRoleDescription = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secuserrole__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secuserrole__default(),
            new Object[][] {
                new Object[] {
               T00072_A551SecUserRoleEstado, T00072_A18SecUserId, T00072_A16SecRoleId
               }
               , new Object[] {
               T00073_A551SecUserRoleEstado, T00073_A18SecUserId, T00073_A16SecRoleId
               }
               , new Object[] {
               T00074_A145usuariosId, T00074_n145usuariosId
               }
               , new Object[] {
               T00075_A25SecRoleName, T00075_A24SecRoleDescription
               }
               , new Object[] {
               T00076_A222usuariosNombre
               }
               , new Object[] {
               T00077_A145usuariosId, T00077_n145usuariosId, T00077_A222usuariosNombre, T00077_A25SecRoleName, T00077_A24SecRoleDescription, T00077_A551SecUserRoleEstado, T00077_A18SecUserId, T00077_A16SecRoleId
               }
               , new Object[] {
               T00078_A145usuariosId, T00078_n145usuariosId
               }
               , new Object[] {
               T00079_A222usuariosNombre
               }
               , new Object[] {
               T000710_A25SecRoleName, T000710_A24SecRoleDescription
               }
               , new Object[] {
               T000711_A18SecUserId, T000711_A16SecRoleId
               }
               , new Object[] {
               T000712_A18SecUserId, T000712_A16SecRoleId
               }
               , new Object[] {
               T000713_A18SecUserId, T000713_A16SecRoleId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000717_A145usuariosId, T000717_n145usuariosId
               }
               , new Object[] {
               T000718_A222usuariosNombre
               }
               , new Object[] {
               T000719_A25SecRoleName, T000719_A24SecRoleDescription
               }
               , new Object[] {
               T000720_A18SecUserId, T000720_A16SecRoleId
               }
            }
         );
      }

      private short Z16SecRoleId ;
      private short GxWebError ;
      private short A16SecRoleId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound8 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ16SecRoleId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSecUserId_Enabled ;
      private int imgprompt_18_Visible ;
      private int edtSecRoleId_Enabled ;
      private int imgprompt_16_Visible ;
      private int edtusuariosNombre_Enabled ;
      private int edtSecRoleName_Enabled ;
      private int edtSecRoleDescription_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z18SecUserId ;
      private long A18SecUserId ;
      private long ZZ18SecUserId ;
      private string sPrefix ;
      private string Z551SecUserRoleEstado ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A145usuariosId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSecUserId_Internalname ;
      private string A551SecUserRoleEstado ;
      private string cmbSecUserRoleEstado_Internalname ;
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
      private string edtSecUserId_Jsonclick ;
      private string imgprompt_18_gximage ;
      private string sImgUrl ;
      private string imgprompt_18_Internalname ;
      private string imgprompt_18_Link ;
      private string edtSecRoleId_Internalname ;
      private string edtSecRoleId_Jsonclick ;
      private string imgprompt_16_gximage ;
      private string imgprompt_16_Internalname ;
      private string imgprompt_16_Link ;
      private string edtusuariosNombre_Internalname ;
      private string A222usuariosNombre ;
      private string edtusuariosNombre_Jsonclick ;
      private string edtSecRoleName_Internalname ;
      private string edtSecRoleName_Jsonclick ;
      private string edtSecRoleDescription_Internalname ;
      private string edtSecRoleDescription_Jsonclick ;
      private string cmbSecUserRoleEstado_Jsonclick ;
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
      private string Z145usuariosId ;
      private string Z222usuariosNombre ;
      private string sMode8 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ551SecUserRoleEstado ;
      private string ZZ145usuariosId ;
      private string ZZ222usuariosNombre ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n145usuariosId ;
      private bool wbErr ;
      private string A25SecRoleName ;
      private string A24SecRoleDescription ;
      private string Z25SecRoleName ;
      private string Z24SecRoleDescription ;
      private string ZZ25SecRoleName ;
      private string ZZ24SecRoleDescription ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbSecUserRoleEstado ;
      private IDataStoreProvider pr_default ;
      private string[] T00077_A145usuariosId ;
      private bool[] T00077_n145usuariosId ;
      private string[] T00077_A222usuariosNombre ;
      private string[] T00077_A25SecRoleName ;
      private string[] T00077_A24SecRoleDescription ;
      private string[] T00077_A551SecUserRoleEstado ;
      private long[] T00077_A18SecUserId ;
      private short[] T00077_A16SecRoleId ;
      private string[] T00074_A145usuariosId ;
      private bool[] T00074_n145usuariosId ;
      private string[] T00076_A222usuariosNombre ;
      private string[] T00075_A25SecRoleName ;
      private string[] T00075_A24SecRoleDescription ;
      private string[] T00078_A145usuariosId ;
      private bool[] T00078_n145usuariosId ;
      private string[] T00079_A222usuariosNombre ;
      private string[] T000710_A25SecRoleName ;
      private string[] T000710_A24SecRoleDescription ;
      private long[] T000711_A18SecUserId ;
      private short[] T000711_A16SecRoleId ;
      private string[] T00073_A551SecUserRoleEstado ;
      private long[] T00073_A18SecUserId ;
      private short[] T00073_A16SecRoleId ;
      private long[] T000712_A18SecUserId ;
      private short[] T000712_A16SecRoleId ;
      private long[] T000713_A18SecUserId ;
      private short[] T000713_A16SecRoleId ;
      private string[] T00072_A551SecUserRoleEstado ;
      private long[] T00072_A18SecUserId ;
      private short[] T00072_A16SecRoleId ;
      private string[] T000717_A145usuariosId ;
      private bool[] T000717_n145usuariosId ;
      private string[] T000718_A222usuariosNombre ;
      private string[] T000719_A25SecRoleName ;
      private string[] T000719_A24SecRoleDescription ;
      private long[] T000720_A18SecUserId ;
      private short[] T000720_A16SecRoleId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class secuserrole__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class secuserrole__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00072;
        prmT00072 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmT00073;
        prmT00073 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmT00074;
        prmT00074 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT00075;
        prmT00075 = new Object[] {
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmT00076;
        prmT00076 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT00077;
        prmT00077 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmT00078;
        prmT00078 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT00079;
        prmT00079 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000710;
        prmT000710 = new Object[] {
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmT000711;
        prmT000711 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmT000712;
        prmT000712 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmT000713;
        prmT000713 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmT000714;
        prmT000714 = new Object[] {
        new ParDef("@SecUserRoleEstado",GXType.NChar,3,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmT000715;
        prmT000715 = new Object[] {
        new ParDef("@SecUserRoleEstado",GXType.NChar,3,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmT000716;
        prmT000716 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmT000717;
        prmT000717 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT000718;
        prmT000718 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000719;
        prmT000719 = new Object[] {
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmT000720;
        prmT000720 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00072", "SELECT [SecUserRoleEstado], [SecUserId], [SecRoleId] FROM [SecUserRole] WITH (UPDLOCK) WHERE [SecUserId] = @SecUserId AND [SecRoleId] = @SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00073", "SELECT [SecUserRoleEstado], [SecUserId], [SecRoleId] FROM [SecUserRole] WHERE [SecUserId] = @SecUserId AND [SecRoleId] = @SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00074", "SELECT [usuariosId] FROM [SecUser] WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00075", "SELECT [SecRoleName], [SecRoleDescription] FROM [SecRole] WHERE [SecRoleId] = @SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00076", "SELECT [usuariosNombre] FROM [usuarios] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00077", "SELECT T2.[usuariosId], T3.[usuariosNombre], T4.[SecRoleName], T4.[SecRoleDescription], TM1.[SecUserRoleEstado], TM1.[SecUserId], TM1.[SecRoleId] FROM ((([SecUserRole] TM1 INNER JOIN [SecUser] T2 ON T2.[SecUserId] = TM1.[SecUserId]) LEFT JOIN [usuarios] T3 ON T3.[usuariosId] = T2.[usuariosId]) INNER JOIN [SecRole] T4 ON T4.[SecRoleId] = TM1.[SecRoleId]) WHERE TM1.[SecUserId] = @SecUserId and TM1.[SecRoleId] = @SecRoleId ORDER BY TM1.[SecUserId], TM1.[SecRoleId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00078", "SELECT [usuariosId] FROM [SecUser] WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00079", "SELECT [usuariosNombre] FROM [usuarios] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000710", "SELECT [SecRoleName], [SecRoleDescription] FROM [SecRole] WHERE [SecRoleId] = @SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000710,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000711", "SELECT [SecUserId], [SecRoleId] FROM [SecUserRole] WHERE [SecUserId] = @SecUserId AND [SecRoleId] = @SecRoleId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000711,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000712", "SELECT TOP 1 [SecUserId], [SecRoleId] FROM [SecUserRole] WHERE ( [SecUserId] > @SecUserId or [SecUserId] = @SecUserId and [SecRoleId] > @SecRoleId) ORDER BY [SecUserId], [SecRoleId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000712,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000713", "SELECT TOP 1 [SecUserId], [SecRoleId] FROM [SecUserRole] WHERE ( [SecUserId] < @SecUserId or [SecUserId] = @SecUserId and [SecRoleId] < @SecRoleId) ORDER BY [SecUserId] DESC, [SecRoleId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000714", "INSERT INTO [SecUserRole]([SecUserRoleEstado], [SecUserId], [SecRoleId]) VALUES(@SecUserRoleEstado, @SecUserId, @SecRoleId)", GxErrorMask.GX_NOMASK,prmT000714)
           ,new CursorDef("T000715", "UPDATE [SecUserRole] SET [SecUserRoleEstado]=@SecUserRoleEstado  WHERE [SecUserId] = @SecUserId AND [SecRoleId] = @SecRoleId", GxErrorMask.GX_NOMASK,prmT000715)
           ,new CursorDef("T000716", "DELETE FROM [SecUserRole]  WHERE [SecUserId] = @SecUserId AND [SecRoleId] = @SecRoleId", GxErrorMask.GX_NOMASK,prmT000716)
           ,new CursorDef("T000717", "SELECT [usuariosId] FROM [SecUser] WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000717,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000718", "SELECT [usuariosNombre] FROM [usuarios] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000718,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000719", "SELECT [SecRoleName], [SecRoleDescription] FROM [SecRole] WHERE [SecRoleId] = @SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000719,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000720", "SELECT [SecUserId], [SecRoleId] FROM [SecUserRole] ORDER BY [SecUserId], [SecRoleId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000720,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 80);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 3);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
     }
  }

}

}
