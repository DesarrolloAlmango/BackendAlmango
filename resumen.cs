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
   public class resumen : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A349ConfigGenID = (short)(Math.Round(NumberUtil.Val( GetPar( "ConfigGenID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A349ConfigGenID) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Resumen", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtResumenID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public resumen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public resumen( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Resumen", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Resumen.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Resumen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Resumen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Resumen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Resumen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx01k0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"RESUMENID"+"'), id:'"+"RESUMENID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Resumen.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResumenID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResumenID_Internalname, context.GetMessage( "ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResumenID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A371ResumenID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtResumenID_Enabled!=0) ? context.localUtil.Format( (decimal)(A371ResumenID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A371ResumenID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResumenID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResumenID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Resumen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfigGenID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfigGenID_Internalname, context.GetMessage( "Config Gen ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfigGenID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A349ConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtConfigGenID_Enabled!=0) ? context.localUtil.Format( (decimal)(A349ConfigGenID), "ZZZ9") : context.localUtil.Format( (decimal)(A349ConfigGenID), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfigGenID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfigGenID_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Resumen.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_349_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_349_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_349_Internalname, sImgUrl, imgprompt_349_Link, "", "", context.GetTheme( ), imgprompt_349_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Resumen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfigGenEmpNom_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfigGenEmpNom_Internalname, context.GetMessage( "Nombre de la Empresa", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfigGenEmpNom_Internalname, StringUtil.RTrim( A351ConfigGenEmpNom), StringUtil.RTrim( context.localUtil.Format( A351ConfigGenEmpNom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfigGenEmpNom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfigGenEmpNom_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Resumen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResumenTotClientes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResumenTotClientes_Internalname, context.GetMessage( "Total de Clientes", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResumenTotClientes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A372ResumenTotClientes), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtResumenTotClientes_Enabled!=0) ? context.localUtil.Format( (decimal)(A372ResumenTotClientes), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A372ResumenTotClientes), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResumenTotClientes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResumenTotClientes_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Resumen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfeTotProfesionales_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfeTotProfesionales_Internalname, context.GetMessage( "Total Profesionales", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfeTotProfesionales_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A373ProfeTotProfesionales), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProfeTotProfesionales_Enabled!=0) ? context.localUtil.Format( (decimal)(A373ProfeTotProfesionales), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A373ProfeTotProfesionales), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfeTotProfesionales_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProfeTotProfesionales_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Resumen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResumenTotTrabRealizados_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResumenTotTrabRealizados_Internalname, context.GetMessage( "Trabajos Realizados", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResumenTotTrabRealizados_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A375ResumenTotTrabRealizados), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtResumenTotTrabRealizados_Enabled!=0) ? context.localUtil.Format( (decimal)(A375ResumenTotTrabRealizados), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A375ResumenTotTrabRealizados), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResumenTotTrabRealizados_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResumenTotTrabRealizados_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Resumen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResumenTotServicios_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResumenTotServicios_Internalname, context.GetMessage( "Servicios", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResumenTotServicios_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ResumenTotServicios), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtResumenTotServicios_Enabled!=0) ? context.localUtil.Format( (decimal)(A376ResumenTotServicios), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A376ResumenTotServicios), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResumenTotServicios_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResumenTotServicios_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Resumen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResumenFechMod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResumenFechMod_Internalname, context.GetMessage( "Fecha", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtResumenFechMod_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtResumenFechMod_Internalname, context.localUtil.TToC( A377ResumenFechMod, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A377ResumenFechMod, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResumenFechMod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResumenFechMod_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Resumen.htm");
         GxWebStd.gx_bitmap( context, edtResumenFechMod_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtResumenFechMod_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Resumen.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Resumen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Resumen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Resumen.htm");
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
            Z371ResumenID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z371ResumenID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z372ResumenTotClientes = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z372ResumenTotClientes"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z373ProfeTotProfesionales = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z373ProfeTotProfesionales"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z375ResumenTotTrabRealizados = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z375ResumenTotTrabRealizados"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z376ResumenTotServicios = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z376ResumenTotServicios"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z377ResumenFechMod = context.localUtil.CToT( cgiGet( "Z377ResumenFechMod"), 0);
            Z349ConfigGenID = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z349ConfigGenID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtResumenID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtResumenID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RESUMENID");
               AnyError = 1;
               GX_FocusControl = edtResumenID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A371ResumenID = 0;
               AssignAttri("", false, "A371ResumenID", StringUtil.LTrimStr( (decimal)(A371ResumenID), 18, 0));
            }
            else
            {
               A371ResumenID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtResumenID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A371ResumenID", StringUtil.LTrimStr( (decimal)(A371ResumenID), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtConfigGenID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConfigGenID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONFIGGENID");
               AnyError = 1;
               GX_FocusControl = edtConfigGenID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A349ConfigGenID = 0;
               AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
            }
            else
            {
               A349ConfigGenID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtConfigGenID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
            }
            A351ConfigGenEmpNom = cgiGet( edtConfigGenEmpNom_Internalname);
            AssignAttri("", false, "A351ConfigGenEmpNom", A351ConfigGenEmpNom);
            if ( ( ( context.localUtil.CToN( cgiGet( edtResumenTotClientes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtResumenTotClientes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RESUMENTOTCLIENTES");
               AnyError = 1;
               GX_FocusControl = edtResumenTotClientes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A372ResumenTotClientes = 0;
               AssignAttri("", false, "A372ResumenTotClientes", StringUtil.LTrimStr( (decimal)(A372ResumenTotClientes), 18, 0));
            }
            else
            {
               A372ResumenTotClientes = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtResumenTotClientes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A372ResumenTotClientes", StringUtil.LTrimStr( (decimal)(A372ResumenTotClientes), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProfeTotProfesionales_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProfeTotProfesionales_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROFETOTPROFESIONALES");
               AnyError = 1;
               GX_FocusControl = edtProfeTotProfesionales_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A373ProfeTotProfesionales = 0;
               AssignAttri("", false, "A373ProfeTotProfesionales", StringUtil.LTrimStr( (decimal)(A373ProfeTotProfesionales), 18, 0));
            }
            else
            {
               A373ProfeTotProfesionales = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfeTotProfesionales_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A373ProfeTotProfesionales", StringUtil.LTrimStr( (decimal)(A373ProfeTotProfesionales), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtResumenTotTrabRealizados_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtResumenTotTrabRealizados_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RESUMENTOTTRABREALIZADOS");
               AnyError = 1;
               GX_FocusControl = edtResumenTotTrabRealizados_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A375ResumenTotTrabRealizados = 0;
               AssignAttri("", false, "A375ResumenTotTrabRealizados", StringUtil.LTrimStr( (decimal)(A375ResumenTotTrabRealizados), 18, 0));
            }
            else
            {
               A375ResumenTotTrabRealizados = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtResumenTotTrabRealizados_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A375ResumenTotTrabRealizados", StringUtil.LTrimStr( (decimal)(A375ResumenTotTrabRealizados), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtResumenTotServicios_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtResumenTotServicios_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RESUMENTOTSERVICIOS");
               AnyError = 1;
               GX_FocusControl = edtResumenTotServicios_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A376ResumenTotServicios = 0;
               AssignAttri("", false, "A376ResumenTotServicios", StringUtil.LTrimStr( (decimal)(A376ResumenTotServicios), 18, 0));
            }
            else
            {
               A376ResumenTotServicios = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtResumenTotServicios_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A376ResumenTotServicios", StringUtil.LTrimStr( (decimal)(A376ResumenTotServicios), 18, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtResumenFechMod_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha", "")}), 1, "RESUMENFECHMOD");
               AnyError = 1;
               GX_FocusControl = edtResumenFechMod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A377ResumenFechMod = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A377ResumenFechMod", context.localUtil.TToC( A377ResumenFechMod, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A377ResumenFechMod = context.localUtil.CToT( cgiGet( edtResumenFechMod_Internalname));
               AssignAttri("", false, "A377ResumenFechMod", context.localUtil.TToC( A377ResumenFechMod, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
               A371ResumenID = (long)(Math.Round(NumberUtil.Val( GetPar( "ResumenID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A371ResumenID", StringUtil.LTrimStr( (decimal)(A371ResumenID), 18, 0));
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
               InitAll1E56( ) ;
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
         DisableAttributes1E56( ) ;
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

      protected void ResetCaption1E0( )
      {
      }

      protected void ZM1E56( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z372ResumenTotClientes = T001E3_A372ResumenTotClientes[0];
               Z373ProfeTotProfesionales = T001E3_A373ProfeTotProfesionales[0];
               Z375ResumenTotTrabRealizados = T001E3_A375ResumenTotTrabRealizados[0];
               Z376ResumenTotServicios = T001E3_A376ResumenTotServicios[0];
               Z377ResumenFechMod = T001E3_A377ResumenFechMod[0];
               Z349ConfigGenID = T001E3_A349ConfigGenID[0];
            }
            else
            {
               Z372ResumenTotClientes = A372ResumenTotClientes;
               Z373ProfeTotProfesionales = A373ProfeTotProfesionales;
               Z375ResumenTotTrabRealizados = A375ResumenTotTrabRealizados;
               Z376ResumenTotServicios = A376ResumenTotServicios;
               Z377ResumenFechMod = A377ResumenFechMod;
               Z349ConfigGenID = A349ConfigGenID;
            }
         }
         if ( GX_JID == -2 )
         {
            Z371ResumenID = A371ResumenID;
            Z372ResumenTotClientes = A372ResumenTotClientes;
            Z373ProfeTotProfesionales = A373ProfeTotProfesionales;
            Z375ResumenTotTrabRealizados = A375ResumenTotTrabRealizados;
            Z376ResumenTotServicios = A376ResumenTotServicios;
            Z377ResumenFechMod = A377ResumenFechMod;
            Z349ConfigGenID = A349ConfigGenID;
            Z351ConfigGenEmpNom = A351ConfigGenEmpNom;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_349_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx01h0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CONFIGGENID"+"'), id:'"+"CONFIGGENID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load1E56( )
      {
         /* Using cursor T001E5 */
         pr_default.execute(3, new Object[] {A371ResumenID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound56 = 1;
            A351ConfigGenEmpNom = T001E5_A351ConfigGenEmpNom[0];
            AssignAttri("", false, "A351ConfigGenEmpNom", A351ConfigGenEmpNom);
            A372ResumenTotClientes = T001E5_A372ResumenTotClientes[0];
            AssignAttri("", false, "A372ResumenTotClientes", StringUtil.LTrimStr( (decimal)(A372ResumenTotClientes), 18, 0));
            A373ProfeTotProfesionales = T001E5_A373ProfeTotProfesionales[0];
            AssignAttri("", false, "A373ProfeTotProfesionales", StringUtil.LTrimStr( (decimal)(A373ProfeTotProfesionales), 18, 0));
            A375ResumenTotTrabRealizados = T001E5_A375ResumenTotTrabRealizados[0];
            AssignAttri("", false, "A375ResumenTotTrabRealizados", StringUtil.LTrimStr( (decimal)(A375ResumenTotTrabRealizados), 18, 0));
            A376ResumenTotServicios = T001E5_A376ResumenTotServicios[0];
            AssignAttri("", false, "A376ResumenTotServicios", StringUtil.LTrimStr( (decimal)(A376ResumenTotServicios), 18, 0));
            A377ResumenFechMod = T001E5_A377ResumenFechMod[0];
            AssignAttri("", false, "A377ResumenFechMod", context.localUtil.TToC( A377ResumenFechMod, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A349ConfigGenID = T001E5_A349ConfigGenID[0];
            AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
            ZM1E56( -2) ;
         }
         pr_default.close(3);
         OnLoadActions1E56( ) ;
      }

      protected void OnLoadActions1E56( )
      {
      }

      protected void CheckExtendedTable1E56( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001E4 */
         pr_default.execute(2, new Object[] {A349ConfigGenID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Configuración General", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CONFIGGENID");
            AnyError = 1;
            GX_FocusControl = edtConfigGenID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A351ConfigGenEmpNom = T001E4_A351ConfigGenEmpNom[0];
         AssignAttri("", false, "A351ConfigGenEmpNom", A351ConfigGenEmpNom);
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A377ResumenFechMod) || ( A377ResumenFechMod >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "RESUMENFECHMOD");
            AnyError = 1;
            GX_FocusControl = edtResumenFechMod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1E56( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( short A349ConfigGenID )
      {
         /* Using cursor T001E6 */
         pr_default.execute(4, new Object[] {A349ConfigGenID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Configuración General", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CONFIGGENID");
            AnyError = 1;
            GX_FocusControl = edtConfigGenID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A351ConfigGenEmpNom = T001E6_A351ConfigGenEmpNom[0];
         AssignAttri("", false, "A351ConfigGenEmpNom", A351ConfigGenEmpNom);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A351ConfigGenEmpNom))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1E56( )
      {
         /* Using cursor T001E7 */
         pr_default.execute(5, new Object[] {A371ResumenID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound56 = 1;
         }
         else
         {
            RcdFound56 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001E3 */
         pr_default.execute(1, new Object[] {A371ResumenID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1E56( 2) ;
            RcdFound56 = 1;
            A371ResumenID = T001E3_A371ResumenID[0];
            AssignAttri("", false, "A371ResumenID", StringUtil.LTrimStr( (decimal)(A371ResumenID), 18, 0));
            A372ResumenTotClientes = T001E3_A372ResumenTotClientes[0];
            AssignAttri("", false, "A372ResumenTotClientes", StringUtil.LTrimStr( (decimal)(A372ResumenTotClientes), 18, 0));
            A373ProfeTotProfesionales = T001E3_A373ProfeTotProfesionales[0];
            AssignAttri("", false, "A373ProfeTotProfesionales", StringUtil.LTrimStr( (decimal)(A373ProfeTotProfesionales), 18, 0));
            A375ResumenTotTrabRealizados = T001E3_A375ResumenTotTrabRealizados[0];
            AssignAttri("", false, "A375ResumenTotTrabRealizados", StringUtil.LTrimStr( (decimal)(A375ResumenTotTrabRealizados), 18, 0));
            A376ResumenTotServicios = T001E3_A376ResumenTotServicios[0];
            AssignAttri("", false, "A376ResumenTotServicios", StringUtil.LTrimStr( (decimal)(A376ResumenTotServicios), 18, 0));
            A377ResumenFechMod = T001E3_A377ResumenFechMod[0];
            AssignAttri("", false, "A377ResumenFechMod", context.localUtil.TToC( A377ResumenFechMod, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A349ConfigGenID = T001E3_A349ConfigGenID[0];
            AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
            Z371ResumenID = A371ResumenID;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1E56( ) ;
            if ( AnyError == 1 )
            {
               RcdFound56 = 0;
               InitializeNonKey1E56( ) ;
            }
            Gx_mode = sMode56;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound56 = 0;
            InitializeNonKey1E56( ) ;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode56;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1E56( ) ;
         if ( RcdFound56 == 0 )
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
         RcdFound56 = 0;
         /* Using cursor T001E8 */
         pr_default.execute(6, new Object[] {A371ResumenID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T001E8_A371ResumenID[0] < A371ResumenID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T001E8_A371ResumenID[0] > A371ResumenID ) ) )
            {
               A371ResumenID = T001E8_A371ResumenID[0];
               AssignAttri("", false, "A371ResumenID", StringUtil.LTrimStr( (decimal)(A371ResumenID), 18, 0));
               RcdFound56 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound56 = 0;
         /* Using cursor T001E9 */
         pr_default.execute(7, new Object[] {A371ResumenID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001E9_A371ResumenID[0] > A371ResumenID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001E9_A371ResumenID[0] < A371ResumenID ) ) )
            {
               A371ResumenID = T001E9_A371ResumenID[0];
               AssignAttri("", false, "A371ResumenID", StringUtil.LTrimStr( (decimal)(A371ResumenID), 18, 0));
               RcdFound56 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1E56( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtResumenID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1E56( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound56 == 1 )
            {
               if ( A371ResumenID != Z371ResumenID )
               {
                  A371ResumenID = Z371ResumenID;
                  AssignAttri("", false, "A371ResumenID", StringUtil.LTrimStr( (decimal)(A371ResumenID), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RESUMENID");
                  AnyError = 1;
                  GX_FocusControl = edtResumenID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtResumenID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1E56( ) ;
                  GX_FocusControl = edtResumenID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A371ResumenID != Z371ResumenID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtResumenID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1E56( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RESUMENID");
                     AnyError = 1;
                     GX_FocusControl = edtResumenID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtResumenID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1E56( ) ;
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
         if ( A371ResumenID != Z371ResumenID )
         {
            A371ResumenID = Z371ResumenID;
            AssignAttri("", false, "A371ResumenID", StringUtil.LTrimStr( (decimal)(A371ResumenID), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RESUMENID");
            AnyError = 1;
            GX_FocusControl = edtResumenID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtResumenID_Internalname;
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
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "RESUMENID");
            AnyError = 1;
            GX_FocusControl = edtResumenID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtConfigGenID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1E56( ) ;
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConfigGenID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1E56( ) ;
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
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConfigGenID_Internalname;
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
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConfigGenID_Internalname;
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
         ScanStart1E56( ) ;
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound56 != 0 )
            {
               ScanNext1E56( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConfigGenID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1E56( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1E56( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001E2 */
            pr_default.execute(0, new Object[] {A371ResumenID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Resumen"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z372ResumenTotClientes != T001E2_A372ResumenTotClientes[0] ) || ( Z373ProfeTotProfesionales != T001E2_A373ProfeTotProfesionales[0] ) || ( Z375ResumenTotTrabRealizados != T001E2_A375ResumenTotTrabRealizados[0] ) || ( Z376ResumenTotServicios != T001E2_A376ResumenTotServicios[0] ) || ( Z377ResumenFechMod != T001E2_A377ResumenFechMod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z349ConfigGenID != T001E2_A349ConfigGenID[0] ) )
            {
               if ( Z372ResumenTotClientes != T001E2_A372ResumenTotClientes[0] )
               {
                  GXUtil.WriteLog("resumen:[seudo value changed for attri]"+"ResumenTotClientes");
                  GXUtil.WriteLogRaw("Old: ",Z372ResumenTotClientes);
                  GXUtil.WriteLogRaw("Current: ",T001E2_A372ResumenTotClientes[0]);
               }
               if ( Z373ProfeTotProfesionales != T001E2_A373ProfeTotProfesionales[0] )
               {
                  GXUtil.WriteLog("resumen:[seudo value changed for attri]"+"ProfeTotProfesionales");
                  GXUtil.WriteLogRaw("Old: ",Z373ProfeTotProfesionales);
                  GXUtil.WriteLogRaw("Current: ",T001E2_A373ProfeTotProfesionales[0]);
               }
               if ( Z375ResumenTotTrabRealizados != T001E2_A375ResumenTotTrabRealizados[0] )
               {
                  GXUtil.WriteLog("resumen:[seudo value changed for attri]"+"ResumenTotTrabRealizados");
                  GXUtil.WriteLogRaw("Old: ",Z375ResumenTotTrabRealizados);
                  GXUtil.WriteLogRaw("Current: ",T001E2_A375ResumenTotTrabRealizados[0]);
               }
               if ( Z376ResumenTotServicios != T001E2_A376ResumenTotServicios[0] )
               {
                  GXUtil.WriteLog("resumen:[seudo value changed for attri]"+"ResumenTotServicios");
                  GXUtil.WriteLogRaw("Old: ",Z376ResumenTotServicios);
                  GXUtil.WriteLogRaw("Current: ",T001E2_A376ResumenTotServicios[0]);
               }
               if ( Z377ResumenFechMod != T001E2_A377ResumenFechMod[0] )
               {
                  GXUtil.WriteLog("resumen:[seudo value changed for attri]"+"ResumenFechMod");
                  GXUtil.WriteLogRaw("Old: ",Z377ResumenFechMod);
                  GXUtil.WriteLogRaw("Current: ",T001E2_A377ResumenFechMod[0]);
               }
               if ( Z349ConfigGenID != T001E2_A349ConfigGenID[0] )
               {
                  GXUtil.WriteLog("resumen:[seudo value changed for attri]"+"ConfigGenID");
                  GXUtil.WriteLogRaw("Old: ",Z349ConfigGenID);
                  GXUtil.WriteLogRaw("Current: ",T001E2_A349ConfigGenID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Resumen"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1E56( )
      {
         BeforeValidate1E56( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1E56( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1E56( 0) ;
            CheckOptimisticConcurrency1E56( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1E56( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1E56( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001E10 */
                     pr_default.execute(8, new Object[] {A371ResumenID, A372ResumenTotClientes, A373ProfeTotProfesionales, A375ResumenTotTrabRealizados, A376ResumenTotServicios, A377ResumenFechMod, A349ConfigGenID});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Resumen");
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
                           ResetCaption1E0( ) ;
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
               Load1E56( ) ;
            }
            EndLevel1E56( ) ;
         }
         CloseExtendedTableCursors1E56( ) ;
      }

      protected void Update1E56( )
      {
         BeforeValidate1E56( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1E56( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1E56( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1E56( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1E56( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001E11 */
                     pr_default.execute(9, new Object[] {A372ResumenTotClientes, A373ProfeTotProfesionales, A375ResumenTotTrabRealizados, A376ResumenTotServicios, A377ResumenFechMod, A349ConfigGenID, A371ResumenID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Resumen");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Resumen"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1E56( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1E0( ) ;
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
            EndLevel1E56( ) ;
         }
         CloseExtendedTableCursors1E56( ) ;
      }

      protected void DeferredUpdate1E56( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1E56( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1E56( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1E56( ) ;
            AfterConfirm1E56( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1E56( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001E12 */
                  pr_default.execute(10, new Object[] {A371ResumenID});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Resumen");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound56 == 0 )
                        {
                           InitAll1E56( ) ;
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
                        ResetCaption1E0( ) ;
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
         sMode56 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1E56( ) ;
         Gx_mode = sMode56;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1E56( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001E13 */
            pr_default.execute(11, new Object[] {A349ConfigGenID});
            A351ConfigGenEmpNom = T001E13_A351ConfigGenEmpNom[0];
            AssignAttri("", false, "A351ConfigGenEmpNom", A351ConfigGenEmpNom);
            pr_default.close(11);
         }
      }

      protected void EndLevel1E56( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1E56( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("resumen",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("resumen",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1E56( )
      {
         /* Using cursor T001E14 */
         pr_default.execute(12);
         RcdFound56 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound56 = 1;
            A371ResumenID = T001E14_A371ResumenID[0];
            AssignAttri("", false, "A371ResumenID", StringUtil.LTrimStr( (decimal)(A371ResumenID), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1E56( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound56 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound56 = 1;
            A371ResumenID = T001E14_A371ResumenID[0];
            AssignAttri("", false, "A371ResumenID", StringUtil.LTrimStr( (decimal)(A371ResumenID), 18, 0));
         }
      }

      protected void ScanEnd1E56( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1E56( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1E56( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1E56( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1E56( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1E56( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1E56( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1E56( )
      {
         edtResumenID_Enabled = 0;
         AssignProp("", false, edtResumenID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResumenID_Enabled), 5, 0), true);
         edtConfigGenID_Enabled = 0;
         AssignProp("", false, edtConfigGenID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenID_Enabled), 5, 0), true);
         edtConfigGenEmpNom_Enabled = 0;
         AssignProp("", false, edtConfigGenEmpNom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenEmpNom_Enabled), 5, 0), true);
         edtResumenTotClientes_Enabled = 0;
         AssignProp("", false, edtResumenTotClientes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResumenTotClientes_Enabled), 5, 0), true);
         edtProfeTotProfesionales_Enabled = 0;
         AssignProp("", false, edtProfeTotProfesionales_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfeTotProfesionales_Enabled), 5, 0), true);
         edtResumenTotTrabRealizados_Enabled = 0;
         AssignProp("", false, edtResumenTotTrabRealizados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResumenTotTrabRealizados_Enabled), 5, 0), true);
         edtResumenTotServicios_Enabled = 0;
         AssignProp("", false, edtResumenTotServicios_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResumenTotServicios_Enabled), 5, 0), true);
         edtResumenFechMod_Enabled = 0;
         AssignProp("", false, edtResumenFechMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResumenFechMod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1E56( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1E0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("resumen.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z371ResumenID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z371ResumenID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z372ResumenTotClientes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z372ResumenTotClientes), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z373ProfeTotProfesionales", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z373ProfeTotProfesionales), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z375ResumenTotTrabRealizados", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z375ResumenTotTrabRealizados), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z376ResumenTotServicios", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z376ResumenTotServicios), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z377ResumenFechMod", context.localUtil.TToC( Z377ResumenFechMod, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z349ConfigGenID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z349ConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("resumen.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Resumen" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Resumen", "") ;
      }

      protected void InitializeNonKey1E56( )
      {
         A349ConfigGenID = 0;
         AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
         A351ConfigGenEmpNom = "";
         AssignAttri("", false, "A351ConfigGenEmpNom", A351ConfigGenEmpNom);
         A372ResumenTotClientes = 0;
         AssignAttri("", false, "A372ResumenTotClientes", StringUtil.LTrimStr( (decimal)(A372ResumenTotClientes), 18, 0));
         A373ProfeTotProfesionales = 0;
         AssignAttri("", false, "A373ProfeTotProfesionales", StringUtil.LTrimStr( (decimal)(A373ProfeTotProfesionales), 18, 0));
         A375ResumenTotTrabRealizados = 0;
         AssignAttri("", false, "A375ResumenTotTrabRealizados", StringUtil.LTrimStr( (decimal)(A375ResumenTotTrabRealizados), 18, 0));
         A376ResumenTotServicios = 0;
         AssignAttri("", false, "A376ResumenTotServicios", StringUtil.LTrimStr( (decimal)(A376ResumenTotServicios), 18, 0));
         A377ResumenFechMod = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A377ResumenFechMod", context.localUtil.TToC( A377ResumenFechMod, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         Z372ResumenTotClientes = 0;
         Z373ProfeTotProfesionales = 0;
         Z375ResumenTotTrabRealizados = 0;
         Z376ResumenTotServicios = 0;
         Z377ResumenFechMod = (DateTime)(DateTime.MinValue);
         Z349ConfigGenID = 0;
      }

      protected void InitAll1E56( )
      {
         A371ResumenID = 0;
         AssignAttri("", false, "A371ResumenID", StringUtil.LTrimStr( (decimal)(A371ResumenID), 18, 0));
         InitializeNonKey1E56( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021122756", true, true, false);
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
         context.AddJavascriptSource("resumen.js", "?202673021122757", false, true, false);
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
         edtResumenID_Internalname = "RESUMENID";
         edtConfigGenID_Internalname = "CONFIGGENID";
         edtConfigGenEmpNom_Internalname = "CONFIGGENEMPNOM";
         edtResumenTotClientes_Internalname = "RESUMENTOTCLIENTES";
         edtProfeTotProfesionales_Internalname = "PROFETOTPROFESIONALES";
         edtResumenTotTrabRealizados_Internalname = "RESUMENTOTTRABREALIZADOS";
         edtResumenTotServicios_Internalname = "RESUMENTOTSERVICIOS";
         edtResumenFechMod_Internalname = "RESUMENFECHMOD";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_349_Internalname = "PROMPT_349";
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
         Form.Caption = context.GetMessage( "Resumen", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtResumenFechMod_Jsonclick = "";
         edtResumenFechMod_Enabled = 1;
         edtResumenTotServicios_Jsonclick = "";
         edtResumenTotServicios_Enabled = 1;
         edtResumenTotTrabRealizados_Jsonclick = "";
         edtResumenTotTrabRealizados_Enabled = 1;
         edtProfeTotProfesionales_Jsonclick = "";
         edtProfeTotProfesionales_Enabled = 1;
         edtResumenTotClientes_Jsonclick = "";
         edtResumenTotClientes_Enabled = 1;
         edtConfigGenEmpNom_Jsonclick = "";
         edtConfigGenEmpNom_Enabled = 0;
         imgprompt_349_Visible = 1;
         imgprompt_349_Link = "";
         edtConfigGenID_Jsonclick = "";
         edtConfigGenID_Enabled = 1;
         edtResumenID_Jsonclick = "";
         edtResumenID_Enabled = 1;
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
         GX_FocusControl = edtConfigGenID_Internalname;
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

      public void Valid_Resumenid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A349ConfigGenID), 4, 0, ".", "")));
         AssignAttri("", false, "A372ResumenTotClientes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A372ResumenTotClientes), 18, 0, ".", "")));
         AssignAttri("", false, "A373ProfeTotProfesionales", StringUtil.LTrim( StringUtil.NToC( (decimal)(A373ProfeTotProfesionales), 18, 0, ".", "")));
         AssignAttri("", false, "A375ResumenTotTrabRealizados", StringUtil.LTrim( StringUtil.NToC( (decimal)(A375ResumenTotTrabRealizados), 18, 0, ".", "")));
         AssignAttri("", false, "A376ResumenTotServicios", StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ResumenTotServicios), 18, 0, ".", "")));
         AssignAttri("", false, "A377ResumenFechMod", context.localUtil.TToC( A377ResumenFechMod, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A351ConfigGenEmpNom", StringUtil.RTrim( A351ConfigGenEmpNom));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z371ResumenID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z371ResumenID), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z349ConfigGenID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z349ConfigGenID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z372ResumenTotClientes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z372ResumenTotClientes), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z373ProfeTotProfesionales", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z373ProfeTotProfesionales), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z375ResumenTotTrabRealizados", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z375ResumenTotTrabRealizados), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z376ResumenTotServicios", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z376ResumenTotServicios), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z377ResumenFechMod", context.localUtil.TToC( Z377ResumenFechMod, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z351ConfigGenEmpNom", StringUtil.RTrim( Z351ConfigGenEmpNom));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Configgenid( )
      {
         /* Using cursor T001E13 */
         pr_default.execute(11, new Object[] {A349ConfigGenID});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Configuración General", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CONFIGGENID");
            AnyError = 1;
            GX_FocusControl = edtConfigGenID_Internalname;
         }
         A351ConfigGenEmpNom = T001E13_A351ConfigGenEmpNom[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A351ConfigGenEmpNom", StringUtil.RTrim( A351ConfigGenEmpNom));
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
         setEventMetadata("VALID_RESUMENID","{handler:'Valid_Resumenid',iparms:[{av:'A371ResumenID',fld:'RESUMENID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'}]");
         setEventMetadata("VALID_RESUMENID",",oparms:[{av:'A349ConfigGenID',fld:'CONFIGGENID',pic:'ZZZ9',type:'int'},{av:'A372ResumenTotClientes',fld:'RESUMENTOTCLIENTES',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A373ProfeTotProfesionales',fld:'PROFETOTPROFESIONALES',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A375ResumenTotTrabRealizados',fld:'RESUMENTOTTRABREALIZADOS',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A376ResumenTotServicios',fld:'RESUMENTOTSERVICIOS',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A377ResumenFechMod',fld:'RESUMENFECHMOD',pic:'99/99/99 99:99',type:'dtime'},{av:'A351ConfigGenEmpNom',fld:'CONFIGGENEMPNOM',pic:'',type:'char'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z371ResumenID',type:'int'},{av:'Z349ConfigGenID',type:'int'},{av:'Z372ResumenTotClientes',type:'int'},{av:'Z373ProfeTotProfesionales',type:'int'},{av:'Z375ResumenTotTrabRealizados',type:'int'},{av:'Z376ResumenTotServicios',type:'int'},{av:'Z377ResumenFechMod',type:'dtime'},{av:'Z351ConfigGenEmpNom',type:'char'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_CONFIGGENID","{handler:'Valid_Configgenid',iparms:[{av:'A349ConfigGenID',fld:'CONFIGGENID',pic:'ZZZ9',type:'int'},{av:'A351ConfigGenEmpNom',fld:'CONFIGGENEMPNOM',pic:'',type:'char'}]");
         setEventMetadata("VALID_CONFIGGENID",",oparms:[{av:'A351ConfigGenEmpNom',fld:'CONFIGGENEMPNOM',pic:'',type:'char'}]}");
         setEventMetadata("VALID_RESUMENFECHMOD","{handler:'Valid_Resumenfechmod',iparms:[]");
         setEventMetadata("VALID_RESUMENFECHMOD",",oparms:[]}");
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
         Z377ResumenFechMod = (DateTime)(DateTime.MinValue);
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
         imgprompt_349_gximage = "";
         sImgUrl = "";
         A351ConfigGenEmpNom = "";
         A377ResumenFechMod = (DateTime)(DateTime.MinValue);
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
         Z351ConfigGenEmpNom = "";
         T001E5_A371ResumenID = new long[1] ;
         T001E5_A351ConfigGenEmpNom = new string[] {""} ;
         T001E5_A372ResumenTotClientes = new long[1] ;
         T001E5_A373ProfeTotProfesionales = new long[1] ;
         T001E5_A375ResumenTotTrabRealizados = new long[1] ;
         T001E5_A376ResumenTotServicios = new long[1] ;
         T001E5_A377ResumenFechMod = new DateTime[] {DateTime.MinValue} ;
         T001E5_A349ConfigGenID = new short[1] ;
         T001E4_A351ConfigGenEmpNom = new string[] {""} ;
         T001E6_A351ConfigGenEmpNom = new string[] {""} ;
         T001E7_A371ResumenID = new long[1] ;
         T001E3_A371ResumenID = new long[1] ;
         T001E3_A372ResumenTotClientes = new long[1] ;
         T001E3_A373ProfeTotProfesionales = new long[1] ;
         T001E3_A375ResumenTotTrabRealizados = new long[1] ;
         T001E3_A376ResumenTotServicios = new long[1] ;
         T001E3_A377ResumenFechMod = new DateTime[] {DateTime.MinValue} ;
         T001E3_A349ConfigGenID = new short[1] ;
         sMode56 = "";
         T001E8_A371ResumenID = new long[1] ;
         T001E9_A371ResumenID = new long[1] ;
         T001E2_A371ResumenID = new long[1] ;
         T001E2_A372ResumenTotClientes = new long[1] ;
         T001E2_A373ProfeTotProfesionales = new long[1] ;
         T001E2_A375ResumenTotTrabRealizados = new long[1] ;
         T001E2_A376ResumenTotServicios = new long[1] ;
         T001E2_A377ResumenFechMod = new DateTime[] {DateTime.MinValue} ;
         T001E2_A349ConfigGenID = new short[1] ;
         T001E13_A351ConfigGenEmpNom = new string[] {""} ;
         T001E14_A371ResumenID = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ377ResumenFechMod = (DateTime)(DateTime.MinValue);
         ZZ351ConfigGenEmpNom = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.resumen__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.resumen__default(),
            new Object[][] {
                new Object[] {
               T001E2_A371ResumenID, T001E2_A372ResumenTotClientes, T001E2_A373ProfeTotProfesionales, T001E2_A375ResumenTotTrabRealizados, T001E2_A376ResumenTotServicios, T001E2_A377ResumenFechMod, T001E2_A349ConfigGenID
               }
               , new Object[] {
               T001E3_A371ResumenID, T001E3_A372ResumenTotClientes, T001E3_A373ProfeTotProfesionales, T001E3_A375ResumenTotTrabRealizados, T001E3_A376ResumenTotServicios, T001E3_A377ResumenFechMod, T001E3_A349ConfigGenID
               }
               , new Object[] {
               T001E4_A351ConfigGenEmpNom
               }
               , new Object[] {
               T001E5_A371ResumenID, T001E5_A351ConfigGenEmpNom, T001E5_A372ResumenTotClientes, T001E5_A373ProfeTotProfesionales, T001E5_A375ResumenTotTrabRealizados, T001E5_A376ResumenTotServicios, T001E5_A377ResumenFechMod, T001E5_A349ConfigGenID
               }
               , new Object[] {
               T001E6_A351ConfigGenEmpNom
               }
               , new Object[] {
               T001E7_A371ResumenID
               }
               , new Object[] {
               T001E8_A371ResumenID
               }
               , new Object[] {
               T001E9_A371ResumenID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001E13_A351ConfigGenEmpNom
               }
               , new Object[] {
               T001E14_A371ResumenID
               }
            }
         );
      }

      private short Z349ConfigGenID ;
      private short GxWebError ;
      private short A349ConfigGenID ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound56 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ349ConfigGenID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtResumenID_Enabled ;
      private int edtConfigGenID_Enabled ;
      private int imgprompt_349_Visible ;
      private int edtConfigGenEmpNom_Enabled ;
      private int edtResumenTotClientes_Enabled ;
      private int edtProfeTotProfesionales_Enabled ;
      private int edtResumenTotTrabRealizados_Enabled ;
      private int edtResumenTotServicios_Enabled ;
      private int edtResumenFechMod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z371ResumenID ;
      private long Z372ResumenTotClientes ;
      private long Z373ProfeTotProfesionales ;
      private long Z375ResumenTotTrabRealizados ;
      private long Z376ResumenTotServicios ;
      private long A371ResumenID ;
      private long A372ResumenTotClientes ;
      private long A373ProfeTotProfesionales ;
      private long A375ResumenTotTrabRealizados ;
      private long A376ResumenTotServicios ;
      private long ZZ371ResumenID ;
      private long ZZ372ResumenTotClientes ;
      private long ZZ373ProfeTotProfesionales ;
      private long ZZ375ResumenTotTrabRealizados ;
      private long ZZ376ResumenTotServicios ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtResumenID_Internalname ;
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
      private string edtResumenID_Jsonclick ;
      private string edtConfigGenID_Internalname ;
      private string edtConfigGenID_Jsonclick ;
      private string imgprompt_349_gximage ;
      private string sImgUrl ;
      private string imgprompt_349_Internalname ;
      private string imgprompt_349_Link ;
      private string edtConfigGenEmpNom_Internalname ;
      private string A351ConfigGenEmpNom ;
      private string edtConfigGenEmpNom_Jsonclick ;
      private string edtResumenTotClientes_Internalname ;
      private string edtResumenTotClientes_Jsonclick ;
      private string edtProfeTotProfesionales_Internalname ;
      private string edtProfeTotProfesionales_Jsonclick ;
      private string edtResumenTotTrabRealizados_Internalname ;
      private string edtResumenTotTrabRealizados_Jsonclick ;
      private string edtResumenTotServicios_Internalname ;
      private string edtResumenTotServicios_Jsonclick ;
      private string edtResumenFechMod_Internalname ;
      private string edtResumenFechMod_Jsonclick ;
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
      private string Z351ConfigGenEmpNom ;
      private string sMode56 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ351ConfigGenEmpNom ;
      private DateTime Z377ResumenFechMod ;
      private DateTime A377ResumenFechMod ;
      private DateTime ZZ377ResumenFechMod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T001E5_A371ResumenID ;
      private string[] T001E5_A351ConfigGenEmpNom ;
      private long[] T001E5_A372ResumenTotClientes ;
      private long[] T001E5_A373ProfeTotProfesionales ;
      private long[] T001E5_A375ResumenTotTrabRealizados ;
      private long[] T001E5_A376ResumenTotServicios ;
      private DateTime[] T001E5_A377ResumenFechMod ;
      private short[] T001E5_A349ConfigGenID ;
      private string[] T001E4_A351ConfigGenEmpNom ;
      private string[] T001E6_A351ConfigGenEmpNom ;
      private long[] T001E7_A371ResumenID ;
      private long[] T001E3_A371ResumenID ;
      private long[] T001E3_A372ResumenTotClientes ;
      private long[] T001E3_A373ProfeTotProfesionales ;
      private long[] T001E3_A375ResumenTotTrabRealizados ;
      private long[] T001E3_A376ResumenTotServicios ;
      private DateTime[] T001E3_A377ResumenFechMod ;
      private short[] T001E3_A349ConfigGenID ;
      private long[] T001E8_A371ResumenID ;
      private long[] T001E9_A371ResumenID ;
      private long[] T001E2_A371ResumenID ;
      private long[] T001E2_A372ResumenTotClientes ;
      private long[] T001E2_A373ProfeTotProfesionales ;
      private long[] T001E2_A375ResumenTotTrabRealizados ;
      private long[] T001E2_A376ResumenTotServicios ;
      private DateTime[] T001E2_A377ResumenFechMod ;
      private short[] T001E2_A349ConfigGenID ;
      private string[] T001E13_A351ConfigGenEmpNom ;
      private long[] T001E14_A371ResumenID ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class resumen__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class resumen__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT001E2;
        prmT001E2 = new Object[] {
        new ParDef("@ResumenID",GXType.Decimal,18,0)
        };
        Object[] prmT001E3;
        prmT001E3 = new Object[] {
        new ParDef("@ResumenID",GXType.Decimal,18,0)
        };
        Object[] prmT001E4;
        prmT001E4 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        Object[] prmT001E5;
        prmT001E5 = new Object[] {
        new ParDef("@ResumenID",GXType.Decimal,18,0)
        };
        Object[] prmT001E6;
        prmT001E6 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        Object[] prmT001E7;
        prmT001E7 = new Object[] {
        new ParDef("@ResumenID",GXType.Decimal,18,0)
        };
        Object[] prmT001E8;
        prmT001E8 = new Object[] {
        new ParDef("@ResumenID",GXType.Decimal,18,0)
        };
        Object[] prmT001E9;
        prmT001E9 = new Object[] {
        new ParDef("@ResumenID",GXType.Decimal,18,0)
        };
        Object[] prmT001E10;
        prmT001E10 = new Object[] {
        new ParDef("@ResumenID",GXType.Decimal,18,0) ,
        new ParDef("@ResumenTotClientes",GXType.Decimal,18,0) ,
        new ParDef("@ProfeTotProfesionales",GXType.Decimal,18,0) ,
        new ParDef("@ResumenTotTrabRealizados",GXType.Decimal,18,0) ,
        new ParDef("@ResumenTotServicios",GXType.Decimal,18,0) ,
        new ParDef("@ResumenFechMod",GXType.DateTime,8,5) ,
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        Object[] prmT001E11;
        prmT001E11 = new Object[] {
        new ParDef("@ResumenTotClientes",GXType.Decimal,18,0) ,
        new ParDef("@ProfeTotProfesionales",GXType.Decimal,18,0) ,
        new ParDef("@ResumenTotTrabRealizados",GXType.Decimal,18,0) ,
        new ParDef("@ResumenTotServicios",GXType.Decimal,18,0) ,
        new ParDef("@ResumenFechMod",GXType.DateTime,8,5) ,
        new ParDef("@ConfigGenID",GXType.Int16,4,0) ,
        new ParDef("@ResumenID",GXType.Decimal,18,0)
        };
        Object[] prmT001E12;
        prmT001E12 = new Object[] {
        new ParDef("@ResumenID",GXType.Decimal,18,0)
        };
        Object[] prmT001E13;
        prmT001E13 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        Object[] prmT001E14;
        prmT001E14 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001E2", "SELECT [ResumenID], [ResumenTotClientes], [ProfeTotProfesionales], [ResumenTotTrabRealizados], [ResumenTotServicios], [ResumenFechMod], [ConfigGenID] FROM [Resumen] WITH (UPDLOCK) WHERE [ResumenID] = @ResumenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E3", "SELECT [ResumenID], [ResumenTotClientes], [ProfeTotProfesionales], [ResumenTotTrabRealizados], [ResumenTotServicios], [ResumenFechMod], [ConfigGenID] FROM [Resumen] WHERE [ResumenID] = @ResumenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E4", "SELECT [ConfigGenEmpNom] FROM [ConfigGen] WHERE [ConfigGenID] = @ConfigGenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E5", "SELECT TM1.[ResumenID], T2.[ConfigGenEmpNom], TM1.[ResumenTotClientes], TM1.[ProfeTotProfesionales], TM1.[ResumenTotTrabRealizados], TM1.[ResumenTotServicios], TM1.[ResumenFechMod], TM1.[ConfigGenID] FROM ([Resumen] TM1 INNER JOIN [ConfigGen] T2 ON T2.[ConfigGenID] = TM1.[ConfigGenID]) WHERE TM1.[ResumenID] = @ResumenID ORDER BY TM1.[ResumenID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001E5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E6", "SELECT [ConfigGenEmpNom] FROM [ConfigGen] WHERE [ConfigGenID] = @ConfigGenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E7", "SELECT [ResumenID] FROM [Resumen] WHERE [ResumenID] = @ResumenID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001E7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E8", "SELECT TOP 1 [ResumenID] FROM [Resumen] WHERE ( [ResumenID] > @ResumenID) ORDER BY [ResumenID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001E8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001E9", "SELECT TOP 1 [ResumenID] FROM [Resumen] WHERE ( [ResumenID] < @ResumenID) ORDER BY [ResumenID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001E9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001E10", "INSERT INTO [Resumen]([ResumenID], [ResumenTotClientes], [ProfeTotProfesionales], [ResumenTotTrabRealizados], [ResumenTotServicios], [ResumenFechMod], [ConfigGenID]) VALUES(@ResumenID, @ResumenTotClientes, @ProfeTotProfesionales, @ResumenTotTrabRealizados, @ResumenTotServicios, @ResumenFechMod, @ConfigGenID)", GxErrorMask.GX_NOMASK,prmT001E10)
           ,new CursorDef("T001E11", "UPDATE [Resumen] SET [ResumenTotClientes]=@ResumenTotClientes, [ProfeTotProfesionales]=@ProfeTotProfesionales, [ResumenTotTrabRealizados]=@ResumenTotTrabRealizados, [ResumenTotServicios]=@ResumenTotServicios, [ResumenFechMod]=@ResumenFechMod, [ConfigGenID]=@ConfigGenID  WHERE [ResumenID] = @ResumenID", GxErrorMask.GX_NOMASK,prmT001E11)
           ,new CursorDef("T001E12", "DELETE FROM [Resumen]  WHERE [ResumenID] = @ResumenID", GxErrorMask.GX_NOMASK,prmT001E12)
           ,new CursorDef("T001E13", "SELECT [ConfigGenEmpNom] FROM [ConfigGen] WHERE [ConfigGenID] = @ConfigGenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E14", "SELECT [ResumenID] FROM [Resumen] ORDER BY [ResumenID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001E14,100, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
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
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
