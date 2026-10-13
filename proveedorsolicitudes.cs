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
   public class proveedorsolicitudes : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedoresTipoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A151ProveedoresTipoId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridproveedorsolicitudes_solicitudes") == 0 )
         {
            gxnrGridproveedorsolicitudes_solicitudes_newrow_invoke( ) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Proveedor Solicitudes", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridproveedorsolicitudes_solicitudes_newrow_invoke( )
      {
         nRC_GXsfl_63 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_63"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_63_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_63_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_63_idx = GetPar( "sGXsfl_63_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridproveedorsolicitudes_solicitudes_newrow( ) ;
         /* End function gxnrGridproveedorsolicitudes_solicitudes_newrow_invoke */
      }

      public proveedorsolicitudes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public proveedorsolicitudes( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Proveedor Solicitudes", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_ProveedorSolicitudes.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00s0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROVEEDORID"+"'), id:'"+"PROVEEDORID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_ProveedorSolicitudes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorID_Internalname, context.GetMessage( "Código del Proveedor", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProveedorID_Enabled!=0) ? context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProveedorID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ProveedorSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedoresTipoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedoresTipoId_Internalname, context.GetMessage( "TipoId", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedoresTipoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A151ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProveedoresTipoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A151ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A151ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedoresTipoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProveedoresTipoId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ProveedorSolicitudes.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_151_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_151_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_151_Internalname, sImgUrl, imgprompt_151_Link, "", "", context.GetTheme( ), imgprompt_151_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_ProveedorSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedoresTipoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedoresTipoNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedoresTipoNombre_Internalname, StringUtil.RTrim( A278ProveedoresTipoNombre), StringUtil.RTrim( context.localUtil.Format( A278ProveedoresTipoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedoresTipoNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProveedoresTipoNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProveedorSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre), StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProveedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_ProveedorSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProveedorImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen", ""), "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A432ProveedorImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.PathToRelativeUrl( A432ProveedorImagen));
         GxWebStd.gx_bitmap( context, imgProveedorImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProveedorImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", "", "", 0, A432ProveedorImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProveedorSolicitudes.htm");
         AssignProp("", false, imgProveedorImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.PathToRelativeUrl( A432ProveedorImagen)), true);
         AssignProp("", false, imgProveedorImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A432ProveedorImagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSolicitudestable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlesolicitudes_Internalname, context.GetMessage( "Solicitudes", ""), "", "", lblTitlesolicitudes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_ProveedorSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridproveedorsolicitudes_solicitudes( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridproveedorsolicitudes_solicitudes( )
      {
         /*  Grid Control  */
         StartGridControl63( ) ;
         nGXsfl_63_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount52 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_52 = 1;
               ScanStart1V52( ) ;
               while ( RcdFound52 != 0 )
               {
                  init_level_properties52( ) ;
                  getByPrimaryKey1V52( ) ;
                  AddRow1V52( ) ;
                  ScanNext1V52( ) ;
               }
               ScanEnd1V52( ) ;
               nBlankRcdCount52 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1V52( ) ;
            standaloneModal1V52( ) ;
            sMode52 = Gx_mode;
            while ( nGXsfl_63_idx < nRC_GXsfl_63 )
            {
               bGXsfl_63_Refreshing = true;
               ReadRow1V52( ) ;
               edtProveedorSolicitudesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORSOLICITUDESID_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorSolicitudesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtProveedorSolicitudesNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORSOLICITUDESNOMBRE_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesNombre_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               if ( ( nRcdExists_52 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1V52( ) ;
               }
               SendRow1V52( ) ;
               bGXsfl_63_Refreshing = false;
            }
            Gx_mode = sMode52;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount52 = 5;
            nRcdExists_52 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1V52( ) ;
               while ( RcdFound52 != 0 )
               {
                  sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_6352( ) ;
                  init_level_properties52( ) ;
                  standaloneNotModal1V52( ) ;
                  getByPrimaryKey1V52( ) ;
                  standaloneModal1V52( ) ;
                  AddRow1V52( ) ;
                  ScanNext1V52( ) ;
               }
               ScanEnd1V52( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode52 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
         SubsflControlProps_6352( ) ;
         InitAll1V52( ) ;
         init_level_properties52( ) ;
         nRcdExists_52 = 0;
         nIsMod_52 = 0;
         nRcdDeleted_52 = 0;
         nBlankRcdCount52 = (short)(nBlankRcdUsr52+nBlankRcdCount52);
         fRowAdded = 0;
         while ( nBlankRcdCount52 > 0 )
         {
            standaloneNotModal1V52( ) ;
            standaloneModal1V52( ) ;
            AddRow1V52( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtProveedorSolicitudesId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount52 = (short)(nBlankRcdCount52-1);
         }
         Gx_mode = sMode52;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridproveedorsolicitudes_solicitudesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridproveedorsolicitudes_solicitudes", Gridproveedorsolicitudes_solicitudesContainer, subGridproveedorsolicitudes_solicitudes_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridproveedorsolicitudes_solicitudesContainerData", Gridproveedorsolicitudes_solicitudesContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridproveedorsolicitudes_solicitudesContainerData"+"V", Gridproveedorsolicitudes_solicitudesContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridproveedorsolicitudes_solicitudesContainerData"+"V"+"\" value='"+Gridproveedorsolicitudes_solicitudesContainer.GridValuesHidden()+"'/>") ;
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
            Z133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z282ProveedorNombre = cgiGet( "Z282ProveedorNombre");
            Z978ProveedorCIU = StringUtil.StrToBool( cgiGet( "Z978ProveedorCIU"));
            Z151ProveedoresTipoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z151ProveedoresTipoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A978ProveedorCIU = StringUtil.StrToBool( cgiGet( "Z978ProveedorCIU"));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_63 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_63"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A978ProveedorCIU = StringUtil.StrToBool( cgiGet( "PROVEEDORCIU"));
            A40000ProveedorImagen_GXI = cgiGet( "PROVEEDORIMAGEN_GXI");
            n40000ProveedorImagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROVEEDORID");
               AnyError = 1;
               GX_FocusControl = edtProveedorID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A133ProveedorID = 0;
               n133ProveedorID = false;
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            }
            else
            {
               A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n133ProveedorID = false;
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProveedoresTipoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProveedoresTipoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROVEEDORESTIPOID");
               AnyError = 1;
               GX_FocusControl = edtProveedoresTipoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A151ProveedoresTipoId = 0;
               AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            }
            else
            {
               A151ProveedoresTipoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedoresTipoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            }
            A278ProveedoresTipoNombre = cgiGet( edtProveedoresTipoNombre_Internalname);
            AssignAttri("", false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
            A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A432ProveedorImagen = cgiGet( imgProveedorImagen_Internalname);
            n432ProveedorImagen = false;
            AssignAttri("", false, "A432ProveedorImagen", A432ProveedorImagen);
            n432ProveedorImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgProveedorImagen_Internalname, ref  A432ProveedorImagen, ref  A40000ProveedorImagen_GXI);
            n40000ProveedorImagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
            n432ProveedorImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"ProveedorSolicitudes");
            forbiddenHiddens.Add("ProveedorCIU", StringUtil.BoolToStr( A978ProveedorCIU));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( A133ProveedorID != Z133ProveedorID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("proveedorsolicitudes:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               AnyError = 1;
               return  ;
            }
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
               A133ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
               n133ProveedorID = false;
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
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
               InitAll1V28( ) ;
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
         DisableAttributes1V28( ) ;
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

      protected void CONFIRM_1V52( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow1V52( ) ;
            if ( ( nRcdExists_52 != 0 ) || ( nIsMod_52 != 0 ) )
            {
               GetKey1V52( ) ;
               if ( ( nRcdExists_52 == 0 ) && ( nRcdDeleted_52 == 0 ) )
               {
                  if ( RcdFound52 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1V52( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1V52( ) ;
                        CloseExtendedTableCursors1V52( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PROVEEDORSOLICITUDESID_" + sGXsfl_63_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProveedorSolicitudesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound52 != 0 )
                  {
                     if ( nRcdDeleted_52 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1V52( ) ;
                        Load1V52( ) ;
                        BeforeValidate1V52( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1V52( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_52 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1V52( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1V52( ) ;
                              CloseExtendedTableCursors1V52( ) ;
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
                     if ( nRcdDeleted_52 == 0 )
                     {
                        GXCCtl = "PROVEEDORSOLICITUDESID_" + sGXsfl_63_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProveedorSolicitudesId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProveedorSolicitudesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A152ProveedorSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProveedorSolicitudesNombre_Internalname, StringUtil.RTrim( A337ProveedorSolicitudesNombre)) ;
            ChangePostValue( "ZT_"+"Z152ProveedorSolicitudesId_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z152ProveedorSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z337ProveedorSolicitudesNombre_"+sGXsfl_63_idx, StringUtil.RTrim( Z337ProveedorSolicitudesNombre)) ;
            ChangePostValue( "nRcdDeleted_52_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_52_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_52_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_52 != 0 )
            {
               ChangePostValue( "PROVEEDORSOLICITUDESID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORSOLICITUDESNOMBRE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesNombre_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1V0( )
      {
      }

      protected void ZM1V28( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z282ProveedorNombre = T001V5_A282ProveedorNombre[0];
               Z978ProveedorCIU = T001V5_A978ProveedorCIU[0];
               Z151ProveedoresTipoId = T001V5_A151ProveedoresTipoId[0];
            }
            else
            {
               Z282ProveedorNombre = A282ProveedorNombre;
               Z978ProveedorCIU = A978ProveedorCIU;
               Z151ProveedoresTipoId = A151ProveedoresTipoId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z133ProveedorID = A133ProveedorID;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z432ProveedorImagen = A432ProveedorImagen;
            Z40000ProveedorImagen_GXI = A40000ProveedorImagen_GXI;
            Z978ProveedorCIU = A978ProveedorCIU;
            Z151ProveedoresTipoId = A151ProveedoresTipoId;
            Z278ProveedoresTipoNombre = A278ProveedoresTipoNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_151_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx01e0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROVEEDORESTIPOID"+"'), id:'"+"PROVEEDORESTIPOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A978ProveedorCIU) && ( Gx_BScreen == 0 ) )
         {
            A978ProveedorCIU = false;
            AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
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
      }

      protected void Load1V28( )
      {
         /* Using cursor T001V7 */
         pr_default.execute(5, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound28 = 1;
            A278ProveedoresTipoNombre = T001V7_A278ProveedoresTipoNombre[0];
            AssignAttri("", false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
            A282ProveedorNombre = T001V7_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A40000ProveedorImagen_GXI = T001V7_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = T001V7_n40000ProveedorImagen_GXI[0];
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            A978ProveedorCIU = T001V7_A978ProveedorCIU[0];
            A151ProveedoresTipoId = T001V7_A151ProveedoresTipoId[0];
            AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            A432ProveedorImagen = T001V7_A432ProveedorImagen[0];
            n432ProveedorImagen = T001V7_n432ProveedorImagen[0];
            AssignAttri("", false, "A432ProveedorImagen", A432ProveedorImagen);
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            ZM1V28( -2) ;
         }
         pr_default.close(5);
         OnLoadActions1V28( ) ;
      }

      protected void OnLoadActions1V28( )
      {
      }

      protected void CheckExtendedTable1V28( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T001V6 */
         pr_default.execute(4, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
            GX_FocusControl = edtProveedoresTipoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A278ProveedoresTipoNombre = T001V6_A278ProveedoresTipoNombre[0];
         AssignAttri("", false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1V28( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( long A151ProveedoresTipoId )
      {
         /* Using cursor T001V8 */
         pr_default.execute(6, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
            GX_FocusControl = edtProveedoresTipoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A278ProveedoresTipoNombre = T001V8_A278ProveedoresTipoNombre[0];
         AssignAttri("", false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A278ProveedoresTipoNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1V28( )
      {
         /* Using cursor T001V9 */
         pr_default.execute(7, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001V5 */
         pr_default.execute(3, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1V28( 2) ;
            RcdFound28 = 1;
            A133ProveedorID = T001V5_A133ProveedorID[0];
            n133ProveedorID = T001V5_n133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            A282ProveedorNombre = T001V5_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A40000ProveedorImagen_GXI = T001V5_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = T001V5_n40000ProveedorImagen_GXI[0];
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            A978ProveedorCIU = T001V5_A978ProveedorCIU[0];
            A151ProveedoresTipoId = T001V5_A151ProveedoresTipoId[0];
            AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            A432ProveedorImagen = T001V5_A432ProveedorImagen[0];
            n432ProveedorImagen = T001V5_n432ProveedorImagen[0];
            AssignAttri("", false, "A432ProveedorImagen", A432ProveedorImagen);
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            Z133ProveedorID = A133ProveedorID;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1V28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey1V28( ) ;
            }
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey1V28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey1V28( ) ;
         if ( RcdFound28 == 0 )
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
         RcdFound28 = 0;
         /* Using cursor T001V10 */
         pr_default.execute(8, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001V10_A133ProveedorID[0] < A133ProveedorID ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001V10_A133ProveedorID[0] > A133ProveedorID ) ) )
            {
               A133ProveedorID = T001V10_A133ProveedorID[0];
               n133ProveedorID = T001V10_n133ProveedorID[0];
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound28 = 0;
         /* Using cursor T001V11 */
         pr_default.execute(9, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001V11_A133ProveedorID[0] > A133ProveedorID ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001V11_A133ProveedorID[0] < A133ProveedorID ) ) )
            {
               A133ProveedorID = T001V11_A133ProveedorID[0];
               n133ProveedorID = T001V11_n133ProveedorID[0];
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1V28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1V28( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( A133ProveedorID != Z133ProveedorID )
               {
                  A133ProveedorID = Z133ProveedorID;
                  n133ProveedorID = false;
                  AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROVEEDORID");
                  AnyError = 1;
                  GX_FocusControl = edtProveedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProveedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1V28( ) ;
                  GX_FocusControl = edtProveedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A133ProveedorID != Z133ProveedorID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProveedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1V28( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROVEEDORID");
                     AnyError = 1;
                     GX_FocusControl = edtProveedorID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProveedorID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1V28( ) ;
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
         if ( A133ProveedorID != Z133ProveedorID )
         {
            A133ProveedorID = Z133ProveedorID;
            n133ProveedorID = false;
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProveedorID_Internalname;
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
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProveedoresTipoId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1V28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProveedoresTipoId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1V28( ) ;
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
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProveedoresTipoId_Internalname;
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
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProveedoresTipoId_Internalname;
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
         ScanStart1V28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound28 != 0 )
            {
               ScanNext1V28( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProveedoresTipoId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1V28( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1V28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001V4 */
            pr_default.execute(2, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proveedor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z282ProveedorNombre, T001V4_A282ProveedorNombre[0]) != 0 ) || ( Z978ProveedorCIU != T001V4_A978ProveedorCIU[0] ) || ( Z151ProveedoresTipoId != T001V4_A151ProveedoresTipoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z282ProveedorNombre, T001V4_A282ProveedorNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedorsolicitudes:[seudo value changed for attri]"+"ProveedorNombre");
                  GXUtil.WriteLogRaw("Old: ",Z282ProveedorNombre);
                  GXUtil.WriteLogRaw("Current: ",T001V4_A282ProveedorNombre[0]);
               }
               if ( Z978ProveedorCIU != T001V4_A978ProveedorCIU[0] )
               {
                  GXUtil.WriteLog("proveedorsolicitudes:[seudo value changed for attri]"+"ProveedorCIU");
                  GXUtil.WriteLogRaw("Old: ",Z978ProveedorCIU);
                  GXUtil.WriteLogRaw("Current: ",T001V4_A978ProveedorCIU[0]);
               }
               if ( Z151ProveedoresTipoId != T001V4_A151ProveedoresTipoId[0] )
               {
                  GXUtil.WriteLog("proveedorsolicitudes:[seudo value changed for attri]"+"ProveedoresTipoId");
                  GXUtil.WriteLogRaw("Old: ",Z151ProveedoresTipoId);
                  GXUtil.WriteLogRaw("Current: ",T001V4_A151ProveedoresTipoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Proveedor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1V28( )
      {
         BeforeValidate1V28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1V28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1V28( 0) ;
            CheckOptimisticConcurrency1V28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1V28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1V28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001V12 */
                     pr_default.execute(10, new Object[] {A282ProveedorNombre, n432ProveedorImagen, A432ProveedorImagen, n40000ProveedorImagen_GXI, A40000ProveedorImagen_GXI, A978ProveedorCIU, A151ProveedoresTipoId});
                     A133ProveedorID = T001V12_A133ProveedorID[0];
                     n133ProveedorID = T001V12_n133ProveedorID[0];
                     AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1V28( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1V0( ) ;
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
               Load1V28( ) ;
            }
            EndLevel1V28( ) ;
         }
         CloseExtendedTableCursors1V28( ) ;
      }

      protected void Update1V28( )
      {
         BeforeValidate1V28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1V28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1V28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1V28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1V28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001V13 */
                     pr_default.execute(11, new Object[] {A282ProveedorNombre, A978ProveedorCIU, A151ProveedoresTipoId, n133ProveedorID, A133ProveedorID});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proveedor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1V28( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1V28( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption1V0( ) ;
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
            EndLevel1V28( ) ;
         }
         CloseExtendedTableCursors1V28( ) ;
      }

      protected void DeferredUpdate1V28( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001V14 */
            pr_default.execute(12, new Object[] {n432ProveedorImagen, A432ProveedorImagen, n40000ProveedorImagen_GXI, A40000ProveedorImagen_GXI, n133ProveedorID, A133ProveedorID});
            pr_default.close(12);
            pr_default.SmartCacheProvider.SetUpdated("Proveedor");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1V28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1V28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1V28( ) ;
            AfterConfirm1V28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1V28( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1V52( ) ;
                  while ( RcdFound52 != 0 )
                  {
                     getByPrimaryKey1V52( ) ;
                     Delete1V52( ) ;
                     ScanNext1V52( ) ;
                  }
                  ScanEnd1V52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001V15 */
                     pr_default.execute(13, new Object[] {n133ProveedorID, A133ProveedorID});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound28 == 0 )
                           {
                              InitAll1V28( ) ;
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
                           ResetCaption1V0( ) ;
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1V28( ) ;
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1V28( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001V16 */
            pr_default.execute(14, new Object[] {A151ProveedoresTipoId});
            A278ProveedoresTipoNombre = T001V16_A278ProveedoresTipoNombre[0];
            AssignAttri("", false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
            pr_default.close(14);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001V17 */
            pr_default.execute(15, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Postulaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T001V18 */
            pr_default.execute(16, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Lista Mapeo", "")+" ("+context.GetMessage( "Comercios SubTipo", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T001V19 */
            pr_default.execute(17, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Lista Mapeo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T001V20 */
            pr_default.execute(18, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Vincular Trn", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T001V21 */
            pr_default.execute(19, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T001V22 */
            pr_default.execute(20, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")+" ("+context.GetMessage( "Comercios SubTipo", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T001V23 */
            pr_default.execute(21, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T001V24 */
            pr_default.execute(22, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T001V25 */
            pr_default.execute(23, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agrupacion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T001V26 */
            pr_default.execute(24, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Proveedor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T001V27 */
            pr_default.execute(25, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Comercio | Proveedor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T001V28 */
            pr_default.execute(26, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Comisiones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
         }
      }

      protected void ProcessNestedLevel1V52( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow1V52( ) ;
            if ( ( nRcdExists_52 != 0 ) || ( nIsMod_52 != 0 ) )
            {
               standaloneNotModal1V52( ) ;
               GetKey1V52( ) ;
               if ( ( nRcdExists_52 == 0 ) && ( nRcdDeleted_52 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1V52( ) ;
               }
               else
               {
                  if ( RcdFound52 != 0 )
                  {
                     if ( ( nRcdDeleted_52 != 0 ) && ( nRcdExists_52 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1V52( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_52 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1V52( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_52 == 0 )
                     {
                        GXCCtl = "PROVEEDORSOLICITUDESID_" + sGXsfl_63_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProveedorSolicitudesId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProveedorSolicitudesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A152ProveedorSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProveedorSolicitudesNombre_Internalname, StringUtil.RTrim( A337ProveedorSolicitudesNombre)) ;
            ChangePostValue( "ZT_"+"Z152ProveedorSolicitudesId_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z152ProveedorSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z337ProveedorSolicitudesNombre_"+sGXsfl_63_idx, StringUtil.RTrim( Z337ProveedorSolicitudesNombre)) ;
            ChangePostValue( "nRcdDeleted_52_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_52_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_52_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_52 != 0 )
            {
               ChangePostValue( "PROVEEDORSOLICITUDESID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORSOLICITUDESNOMBRE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesNombre_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1V52( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_52 = 0;
         nIsMod_52 = 0;
         nRcdDeleted_52 = 0;
      }

      protected void ProcessLevel1V28( )
      {
         /* Save parent mode. */
         sMode28 = Gx_mode;
         ProcessNestedLevel1V52( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1V28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1V28( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(14);
            context.CommitDataStores("proveedorsolicitudes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1V0( ) ;
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
            pr_default.close(14);
            context.RollbackDataStores("proveedorsolicitudes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1V28( )
      {
         /* Scan By routine */
         /* Using cursor T001V29 */
         pr_default.execute(27);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound28 = 1;
            A133ProveedorID = T001V29_A133ProveedorID[0];
            n133ProveedorID = T001V29_n133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1V28( )
      {
         /* Scan next routine */
         pr_default.readNext(27);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound28 = 1;
            A133ProveedorID = T001V29_A133ProveedorID[0];
            n133ProveedorID = T001V29_n133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         }
      }

      protected void ScanEnd1V28( )
      {
         pr_default.close(27);
      }

      protected void AfterConfirm1V28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1V28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1V28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1V28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1V28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1V28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1V28( )
      {
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         edtProveedoresTipoId_Enabled = 0;
         AssignProp("", false, edtProveedoresTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoId_Enabled), 5, 0), true);
         edtProveedoresTipoNombre_Enabled = 0;
         AssignProp("", false, edtProveedoresTipoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoNombre_Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         imgProveedorImagen_Enabled = 0;
         AssignProp("", false, imgProveedorImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProveedorImagen_Enabled), 5, 0), true);
      }

      protected void ZM1V52( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z337ProveedorSolicitudesNombre = T001V3_A337ProveedorSolicitudesNombre[0];
            }
            else
            {
               Z337ProveedorSolicitudesNombre = A337ProveedorSolicitudesNombre;
            }
         }
         if ( GX_JID == -4 )
         {
            Z133ProveedorID = A133ProveedorID;
            Z152ProveedorSolicitudesId = A152ProveedorSolicitudesId;
            Z337ProveedorSolicitudesNombre = A337ProveedorSolicitudesNombre;
         }
      }

      protected void standaloneNotModal1V52( )
      {
      }

      protected void standaloneModal1V52( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProveedorSolicitudesId_Enabled = 0;
            AssignProp("", false, edtProveedorSolicitudesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
         else
         {
            edtProveedorSolicitudesId_Enabled = 1;
            AssignProp("", false, edtProveedorSolicitudesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
      }

      protected void Load1V52( )
      {
         /* Using cursor T001V30 */
         pr_default.execute(28, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound52 = 1;
            A337ProveedorSolicitudesNombre = T001V30_A337ProveedorSolicitudesNombre[0];
            ZM1V52( -4) ;
         }
         pr_default.close(28);
         OnLoadActions1V52( ) ;
      }

      protected void OnLoadActions1V52( )
      {
      }

      protected void CheckExtendedTable1V52( )
      {
         nIsDirty_52 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1V52( ) ;
      }

      protected void CloseExtendedTableCursors1V52( )
      {
      }

      protected void enableDisable1V52( )
      {
      }

      protected void GetKey1V52( )
      {
         /* Using cursor T001V31 */
         pr_default.execute(29, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound52 = 1;
         }
         else
         {
            RcdFound52 = 0;
         }
         pr_default.close(29);
      }

      protected void getByPrimaryKey1V52( )
      {
         /* Using cursor T001V3 */
         pr_default.execute(1, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1V52( 4) ;
            RcdFound52 = 1;
            InitializeNonKey1V52( ) ;
            A152ProveedorSolicitudesId = T001V3_A152ProveedorSolicitudesId[0];
            A337ProveedorSolicitudesNombre = T001V3_A337ProveedorSolicitudesNombre[0];
            Z133ProveedorID = A133ProveedorID;
            Z152ProveedorSolicitudesId = A152ProveedorSolicitudesId;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1V52( ) ;
            Load1V52( ) ;
            Gx_mode = sMode52;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound52 = 0;
            InitializeNonKey1V52( ) ;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1V52( ) ;
            Gx_mode = sMode52;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1V52( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1V52( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001V2 */
            pr_default.execute(0, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProveedorSolicitudes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z337ProveedorSolicitudesNombre, T001V2_A337ProveedorSolicitudesNombre[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z337ProveedorSolicitudesNombre, T001V2_A337ProveedorSolicitudesNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedorsolicitudes:[seudo value changed for attri]"+"ProveedorSolicitudesNombre");
                  GXUtil.WriteLogRaw("Old: ",Z337ProveedorSolicitudesNombre);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A337ProveedorSolicitudesNombre[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProveedorSolicitudes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1V52( )
      {
         BeforeValidate1V52( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1V52( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1V52( 0) ;
            CheckOptimisticConcurrency1V52( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1V52( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1V52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001V32 */
                     pr_default.execute(30, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId, A337ProveedorSolicitudesNombre});
                     pr_default.close(30);
                     pr_default.SmartCacheProvider.SetUpdated("ProveedorSolicitudes");
                     if ( (pr_default.getStatus(30) == 1) )
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
               Load1V52( ) ;
            }
            EndLevel1V52( ) ;
         }
         CloseExtendedTableCursors1V52( ) ;
      }

      protected void Update1V52( )
      {
         BeforeValidate1V52( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1V52( ) ;
         }
         if ( ( nIsMod_52 != 0 ) || ( nIsDirty_52 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1V52( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1V52( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1V52( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001V33 */
                        pr_default.execute(31, new Object[] {A337ProveedorSolicitudesNombre, n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
                        pr_default.close(31);
                        pr_default.SmartCacheProvider.SetUpdated("ProveedorSolicitudes");
                        if ( (pr_default.getStatus(31) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProveedorSolicitudes"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1V52( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1V52( ) ;
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
               EndLevel1V52( ) ;
            }
         }
         CloseExtendedTableCursors1V52( ) ;
      }

      protected void DeferredUpdate1V52( )
      {
      }

      protected void Delete1V52( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1V52( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1V52( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1V52( ) ;
            AfterConfirm1V52( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1V52( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001V34 */
                  pr_default.execute(32, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
                  pr_default.close(32);
                  pr_default.SmartCacheProvider.SetUpdated("ProveedorSolicitudes");
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
         sMode52 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1V52( ) ;
         Gx_mode = sMode52;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1V52( )
      {
         standaloneModal1V52( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1V52( )
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

      public void ScanStart1V52( )
      {
         /* Scan By routine */
         /* Using cursor T001V35 */
         pr_default.execute(33, new Object[] {n133ProveedorID, A133ProveedorID});
         RcdFound52 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound52 = 1;
            A152ProveedorSolicitudesId = T001V35_A152ProveedorSolicitudesId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1V52( )
      {
         /* Scan next routine */
         pr_default.readNext(33);
         RcdFound52 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound52 = 1;
            A152ProveedorSolicitudesId = T001V35_A152ProveedorSolicitudesId[0];
         }
      }

      protected void ScanEnd1V52( )
      {
         pr_default.close(33);
      }

      protected void AfterConfirm1V52( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1V52( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1V52( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1V52( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1V52( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1V52( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1V52( )
      {
         edtProveedorSolicitudesId_Enabled = 0;
         AssignProp("", false, edtProveedorSolicitudesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtProveedorSolicitudesNombre_Enabled = 0;
         AssignProp("", false, edtProveedorSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesNombre_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void send_integrity_lvl_hashes1V52( )
      {
      }

      protected void send_integrity_lvl_hashes1V28( )
      {
      }

      protected void SubsflControlProps_6352( )
      {
         edtProveedorSolicitudesId_Internalname = "PROVEEDORSOLICITUDESID_"+sGXsfl_63_idx;
         edtProveedorSolicitudesNombre_Internalname = "PROVEEDORSOLICITUDESNOMBRE_"+sGXsfl_63_idx;
      }

      protected void SubsflControlProps_fel_6352( )
      {
         edtProveedorSolicitudesId_Internalname = "PROVEEDORSOLICITUDESID_"+sGXsfl_63_fel_idx;
         edtProveedorSolicitudesNombre_Internalname = "PROVEEDORSOLICITUDESNOMBRE_"+sGXsfl_63_fel_idx;
      }

      protected void AddRow1V52( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_6352( ) ;
         SendRow1V52( ) ;
      }

      protected void SendRow1V52( )
      {
         Gridproveedorsolicitudes_solicitudesRow = GXWebRow.GetNew(context);
         if ( subGridproveedorsolicitudes_solicitudes_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridproveedorsolicitudes_solicitudes_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridproveedorsolicitudes_solicitudes_Class, "") != 0 )
            {
               subGridproveedorsolicitudes_solicitudes_Linesclass = subGridproveedorsolicitudes_solicitudes_Class+"Odd";
            }
         }
         else if ( subGridproveedorsolicitudes_solicitudes_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridproveedorsolicitudes_solicitudes_Backstyle = 0;
            subGridproveedorsolicitudes_solicitudes_Backcolor = subGridproveedorsolicitudes_solicitudes_Allbackcolor;
            if ( StringUtil.StrCmp(subGridproveedorsolicitudes_solicitudes_Class, "") != 0 )
            {
               subGridproveedorsolicitudes_solicitudes_Linesclass = subGridproveedorsolicitudes_solicitudes_Class+"Uniform";
            }
         }
         else if ( subGridproveedorsolicitudes_solicitudes_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridproveedorsolicitudes_solicitudes_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridproveedorsolicitudes_solicitudes_Class, "") != 0 )
            {
               subGridproveedorsolicitudes_solicitudes_Linesclass = subGridproveedorsolicitudes_solicitudes_Class+"Odd";
            }
            subGridproveedorsolicitudes_solicitudes_Backcolor = (int)(0x0);
         }
         else if ( subGridproveedorsolicitudes_solicitudes_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridproveedorsolicitudes_solicitudes_Backstyle = 1;
            if ( ((int)((nGXsfl_63_idx) % (2))) == 0 )
            {
               subGridproveedorsolicitudes_solicitudes_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridproveedorsolicitudes_solicitudes_Class, "") != 0 )
               {
                  subGridproveedorsolicitudes_solicitudes_Linesclass = subGridproveedorsolicitudes_solicitudes_Class+"Even";
               }
            }
            else
            {
               subGridproveedorsolicitudes_solicitudes_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridproveedorsolicitudes_solicitudes_Class, "") != 0 )
               {
                  subGridproveedorsolicitudes_solicitudes_Linesclass = subGridproveedorsolicitudes_solicitudes_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_52_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridproveedorsolicitudes_solicitudesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorSolicitudesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A152ProveedorSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A152ProveedorSolicitudesId), "ZZZZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,64);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorSolicitudesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProveedorSolicitudesId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)63,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_52_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridproveedorsolicitudes_solicitudesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorSolicitudesNombre_Internalname,StringUtil.RTrim( A337ProveedorSolicitudesNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorSolicitudesNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProveedorSolicitudesNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)63,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridproveedorsolicitudes_solicitudesRow);
         send_integrity_lvl_hashes1V52( ) ;
         GXCCtl = "Z152ProveedorSolicitudesId_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z152ProveedorSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z337ProveedorSolicitudesNombre_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z337ProveedorSolicitudesNombre));
         GXCCtl = "nRcdDeleted_52_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_52), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_52_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_52), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_52_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_52), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORSOLICITUDESID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORSOLICITUDESNOMBRE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesNombre_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridproveedorsolicitudes_solicitudesContainer.AddRow(Gridproveedorsolicitudes_solicitudesRow);
      }

      protected void ReadRow1V52( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_6352( ) ;
         edtProveedorSolicitudesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORSOLICITUDESID_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedorSolicitudesNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORSOLICITUDESNOMBRE_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtProveedorSolicitudesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProveedorSolicitudesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "PROVEEDORSOLICITUDESID_" + sGXsfl_63_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProveedorSolicitudesId_Internalname;
            wbErr = true;
            A152ProveedorSolicitudesId = 0;
         }
         else
         {
            A152ProveedorSolicitudesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorSolicitudesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A337ProveedorSolicitudesNombre = cgiGet( edtProveedorSolicitudesNombre_Internalname);
         GXCCtl = "Z152ProveedorSolicitudesId_" + sGXsfl_63_idx;
         Z152ProveedorSolicitudesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z337ProveedorSolicitudesNombre_" + sGXsfl_63_idx;
         Z337ProveedorSolicitudesNombre = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_52_" + sGXsfl_63_idx;
         nRcdDeleted_52 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_52_" + sGXsfl_63_idx;
         nRcdExists_52 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_52_" + sGXsfl_63_idx;
         nIsMod_52 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtProveedorSolicitudesId_Enabled = edtProveedorSolicitudesId_Enabled;
      }

      protected void ConfirmValues1V0( )
      {
         nGXsfl_63_idx = 0;
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_6352( ) ;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_6352( ) ;
            ChangePostValue( "Z152ProveedorSolicitudesId_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z152ProveedorSolicitudesId_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z152ProveedorSolicitudesId_"+sGXsfl_63_idx) ;
            ChangePostValue( "Z337ProveedorSolicitudesNombre_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z337ProveedorSolicitudesNombre_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z337ProveedorSolicitudesNombre_"+sGXsfl_63_idx) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("proveedorsolicitudes.aspx") +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ProveedorSolicitudes");
         forbiddenHiddens.Add("ProveedorCIU", StringUtil.BoolToStr( A978ProveedorCIU));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("proveedorsolicitudes:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z282ProveedorNombre", StringUtil.RTrim( Z282ProveedorNombre));
         GxWebStd.gx_boolean_hidden_field( context, "Z978ProveedorCIU", Z978ProveedorCIU);
         GxWebStd.gx_hidden_field( context, "Z151ProveedoresTipoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z151ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_63", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_63_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "PROVEEDORCIU", A978ProveedorCIU);
         GxWebStd.gx_hidden_field( context, "PROVEEDORIMAGEN_GXI", A40000ProveedorImagen_GXI);
         GXCCtlgxBlob = "PROVEEDORIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A432ProveedorImagen);
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
         return formatLink("proveedorsolicitudes.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ProveedorSolicitudes" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Proveedor Solicitudes", "") ;
      }

      protected void InitializeNonKey1V28( )
      {
         A151ProveedoresTipoId = 0;
         AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
         A278ProveedoresTipoNombre = "";
         AssignAttri("", false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
         A282ProveedorNombre = "";
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A432ProveedorImagen = "";
         n432ProveedorImagen = false;
         AssignAttri("", false, "A432ProveedorImagen", A432ProveedorImagen);
         AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
         AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
         n432ProveedorImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
         A40000ProveedorImagen_GXI = "";
         n40000ProveedorImagen_GXI = false;
         AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
         AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
         A978ProveedorCIU = false;
         AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
         Z282ProveedorNombre = "";
         Z978ProveedorCIU = false;
         Z151ProveedoresTipoId = 0;
      }

      protected void InitAll1V28( )
      {
         A133ProveedorID = 0;
         n133ProveedorID = false;
         AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         InitializeNonKey1V28( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A978ProveedorCIU = i978ProveedorCIU;
         AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
      }

      protected void InitializeNonKey1V52( )
      {
         A337ProveedorSolicitudesNombre = "";
         Z337ProveedorSolicitudesNombre = "";
      }

      protected void InitAll1V52( )
      {
         A152ProveedorSolicitudesId = 0;
         InitializeNonKey1V52( ) ;
      }

      protected void StandaloneModalInsert1V52( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202693215172", true, true, false);
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
         context.AddJavascriptSource("proveedorsolicitudes.js", "?202693215172", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties52( )
      {
         edtProveedorSolicitudesId_Enabled = defedtProveedorSolicitudesId_Enabled;
         AssignProp("", false, edtProveedorSolicitudesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void StartGridControl63( )
      {
         Gridproveedorsolicitudes_solicitudesContainer.AddObjectProperty("GridName", "Gridproveedorsolicitudes_solicitudes");
         Gridproveedorsolicitudes_solicitudesContainer.AddObjectProperty("Header", subGridproveedorsolicitudes_solicitudes_Header);
         Gridproveedorsolicitudes_solicitudesContainer.AddObjectProperty("Class", "Grid");
         Gridproveedorsolicitudes_solicitudesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridproveedorsolicitudes_solicitudesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridproveedorsolicitudes_solicitudesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedorsolicitudes_solicitudes_Backcolorstyle), 1, 0, ".", "")));
         Gridproveedorsolicitudes_solicitudesContainer.AddObjectProperty("CmpContext", "");
         Gridproveedorsolicitudes_solicitudesContainer.AddObjectProperty("InMasterPage", "false");
         Gridproveedorsolicitudes_solicitudesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridproveedorsolicitudes_solicitudesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A152ProveedorSolicitudesId), 18, 0, ".", ""))));
         Gridproveedorsolicitudes_solicitudesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0, ".", "")));
         Gridproveedorsolicitudes_solicitudesContainer.AddColumnProperties(Gridproveedorsolicitudes_solicitudesColumn);
         Gridproveedorsolicitudes_solicitudesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridproveedorsolicitudes_solicitudesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A337ProveedorSolicitudesNombre)));
         Gridproveedorsolicitudes_solicitudesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesNombre_Enabled), 5, 0, ".", "")));
         Gridproveedorsolicitudes_solicitudesContainer.AddColumnProperties(Gridproveedorsolicitudes_solicitudesColumn);
         Gridproveedorsolicitudes_solicitudesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedorsolicitudes_solicitudes_Selectedindex), 4, 0, ".", "")));
         Gridproveedorsolicitudes_solicitudesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedorsolicitudes_solicitudes_Allowselection), 1, 0, ".", "")));
         Gridproveedorsolicitudes_solicitudesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedorsolicitudes_solicitudes_Selectioncolor), 9, 0, ".", "")));
         Gridproveedorsolicitudes_solicitudesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedorsolicitudes_solicitudes_Allowhovering), 1, 0, ".", "")));
         Gridproveedorsolicitudes_solicitudesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedorsolicitudes_solicitudes_Hoveringcolor), 9, 0, ".", "")));
         Gridproveedorsolicitudes_solicitudesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedorsolicitudes_solicitudes_Allowcollapsing), 1, 0, ".", "")));
         Gridproveedorsolicitudes_solicitudesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedorsolicitudes_solicitudes_Collapsed), 1, 0, ".", "")));
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
         edtProveedorID_Internalname = "PROVEEDORID";
         edtProveedoresTipoId_Internalname = "PROVEEDORESTIPOID";
         edtProveedoresTipoNombre_Internalname = "PROVEEDORESTIPONOMBRE";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         imgProveedorImagen_Internalname = "PROVEEDORIMAGEN";
         lblTitlesolicitudes_Internalname = "TITLESOLICITUDES";
         edtProveedorSolicitudesId_Internalname = "PROVEEDORSOLICITUDESID";
         edtProveedorSolicitudesNombre_Internalname = "PROVEEDORSOLICITUDESNOMBRE";
         divSolicitudestable_Internalname = "SOLICITUDESTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_151_Internalname = "PROMPT_151";
         subGridproveedorsolicitudes_solicitudes_Internalname = "GRIDPROVEEDORSOLICITUDES_SOLICITUDES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridproveedorsolicitudes_solicitudes_Allowcollapsing = 0;
         subGridproveedorsolicitudes_solicitudes_Allowselection = 0;
         subGridproveedorsolicitudes_solicitudes_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Proveedor Solicitudes", "");
         edtProveedorSolicitudesNombre_Jsonclick = "";
         edtProveedorSolicitudesId_Jsonclick = "";
         subGridproveedorsolicitudes_solicitudes_Class = "Grid";
         subGridproveedorsolicitudes_solicitudes_Backcolorstyle = 0;
         edtProveedorSolicitudesNombre_Enabled = 1;
         edtProveedorSolicitudesId_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         imgProveedorImagen_Enabled = 1;
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Enabled = 1;
         edtProveedoresTipoNombre_Jsonclick = "";
         edtProveedoresTipoNombre_Enabled = 0;
         imgprompt_151_Visible = 1;
         imgprompt_151_Link = "";
         edtProveedoresTipoId_Jsonclick = "";
         edtProveedoresTipoId_Enabled = 1;
         edtProveedorID_Jsonclick = "";
         edtProveedorID_Enabled = 1;
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

      protected void gxnrGridproveedorsolicitudes_solicitudes_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_6352( ) ;
         while ( nGXsfl_63_idx <= nRC_GXsfl_63 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1V52( ) ;
            standaloneModal1V52( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1V52( ) ;
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_6352( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridproveedorsolicitudes_solicitudesContainer)) ;
         /* End function gxnrGridproveedorsolicitudes_solicitudes_newrow */
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
         GX_FocusControl = edtProveedoresTipoId_Internalname;
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

      public void Valid_Proveedorid( )
      {
         n133ProveedorID = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A151ProveedoresTipoId), 18, 0, ".", "")));
         AssignAttri("", false, "A282ProveedorNombre", StringUtil.RTrim( A282ProveedorNombre));
         AssignAttri("", false, "A432ProveedorImagen", context.PathToRelativeUrl( A432ProveedorImagen));
         GXCCtlgxBlob = "PROVEEDORIMAGEN" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A432ProveedorImagen));
         AssignAttri("", false, "A40000ProveedorImagen_GXI", A40000ProveedorImagen_GXI);
         AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
         AssignAttri("", false, "A278ProveedoresTipoNombre", StringUtil.RTrim( A278ProveedoresTipoNombre));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z151ProveedoresTipoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z151ProveedoresTipoId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z282ProveedorNombre", StringUtil.RTrim( Z282ProveedorNombre));
         GxWebStd.gx_hidden_field( context, "Z432ProveedorImagen", context.PathToRelativeUrl( Z432ProveedorImagen));
         GxWebStd.gx_hidden_field( context, "Z40000ProveedorImagen_GXI", Z40000ProveedorImagen_GXI);
         GxWebStd.gx_hidden_field( context, "Z978ProveedorCIU", StringUtil.BoolToStr( Z978ProveedorCIU));
         GxWebStd.gx_hidden_field( context, "Z278ProveedoresTipoNombre", StringUtil.RTrim( Z278ProveedoresTipoNombre));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Proveedorestipoid( )
      {
         /* Using cursor T001V16 */
         pr_default.execute(14, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
            GX_FocusControl = edtProveedoresTipoId_Internalname;
         }
         A278ProveedoresTipoNombre = T001V16_A278ProveedoresTipoNombre[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A278ProveedoresTipoNombre", StringUtil.RTrim( A278ProveedoresTipoNombre));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'A432ProveedorImagen',fld:'PROVEEDORIMAGEN',pic:'',type:'bits'},{av:'A40000ProveedorImagen_GXI',fld:'PROVEEDORIMAGEN_GXI',pic:'',type:'svchar'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'},{av:'A278ProveedoresTipoNombre',fld:'PROVEEDORESTIPONOMBRE',pic:'',type:'char'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z133ProveedorID',type:'int'},{av:'Z151ProveedoresTipoId',type:'int'},{av:'Z282ProveedorNombre',type:'char'},{av:'Z432ProveedorImagen',type:'bits'},{av:'Z40000ProveedorImagen_GXI',type:'svchar'},{av:'Z978ProveedorCIU',type:'boolean'},{av:'Z278ProveedoresTipoNombre',type:'char'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_PROVEEDORESTIPOID","{handler:'Valid_Proveedorestipoid',iparms:[{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A278ProveedoresTipoNombre',fld:'PROVEEDORESTIPONOMBRE',pic:'',type:'char'}]");
         setEventMetadata("VALID_PROVEEDORESTIPOID",",oparms:[{av:'A278ProveedoresTipoNombre',fld:'PROVEEDORESTIPONOMBRE',pic:'',type:'char'}]}");
         setEventMetadata("VALID_PROVEEDORSOLICITUDESID","{handler:'Valid_Proveedorsolicitudesid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORSOLICITUDESID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Proveedorsolicitudesnombre',iparms:[]");
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
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z282ProveedorNombre = "";
         Z337ProveedorSolicitudesNombre = "";
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
         imgprompt_151_gximage = "";
         sImgUrl = "";
         A278ProveedoresTipoNombre = "";
         A282ProveedorNombre = "";
         A432ProveedorImagen = "";
         A40000ProveedorImagen_GXI = "";
         lblTitlesolicitudes_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridproveedorsolicitudes_solicitudesContainer = new GXWebGrid( context);
         sMode52 = "";
         sStyleString = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A337ProveedorSolicitudesNombre = "";
         Z432ProveedorImagen = "";
         Z40000ProveedorImagen_GXI = "";
         Z278ProveedoresTipoNombre = "";
         T001V7_A133ProveedorID = new long[1] ;
         T001V7_n133ProveedorID = new bool[] {false} ;
         T001V7_A278ProveedoresTipoNombre = new string[] {""} ;
         T001V7_A282ProveedorNombre = new string[] {""} ;
         T001V7_A40000ProveedorImagen_GXI = new string[] {""} ;
         T001V7_n40000ProveedorImagen_GXI = new bool[] {false} ;
         T001V7_A978ProveedorCIU = new bool[] {false} ;
         T001V7_A151ProveedoresTipoId = new long[1] ;
         T001V7_A432ProveedorImagen = new string[] {""} ;
         T001V7_n432ProveedorImagen = new bool[] {false} ;
         T001V6_A278ProveedoresTipoNombre = new string[] {""} ;
         T001V8_A278ProveedoresTipoNombre = new string[] {""} ;
         T001V9_A133ProveedorID = new long[1] ;
         T001V9_n133ProveedorID = new bool[] {false} ;
         T001V5_A133ProveedorID = new long[1] ;
         T001V5_n133ProveedorID = new bool[] {false} ;
         T001V5_A282ProveedorNombre = new string[] {""} ;
         T001V5_A40000ProveedorImagen_GXI = new string[] {""} ;
         T001V5_n40000ProveedorImagen_GXI = new bool[] {false} ;
         T001V5_A978ProveedorCIU = new bool[] {false} ;
         T001V5_A151ProveedoresTipoId = new long[1] ;
         T001V5_A432ProveedorImagen = new string[] {""} ;
         T001V5_n432ProveedorImagen = new bool[] {false} ;
         sMode28 = "";
         T001V10_A133ProveedorID = new long[1] ;
         T001V10_n133ProveedorID = new bool[] {false} ;
         T001V11_A133ProveedorID = new long[1] ;
         T001V11_n133ProveedorID = new bool[] {false} ;
         T001V4_A133ProveedorID = new long[1] ;
         T001V4_n133ProveedorID = new bool[] {false} ;
         T001V4_A282ProveedorNombre = new string[] {""} ;
         T001V4_A40000ProveedorImagen_GXI = new string[] {""} ;
         T001V4_n40000ProveedorImagen_GXI = new bool[] {false} ;
         T001V4_A978ProveedorCIU = new bool[] {false} ;
         T001V4_A151ProveedoresTipoId = new long[1] ;
         T001V4_A432ProveedorImagen = new string[] {""} ;
         T001V4_n432ProveedorImagen = new bool[] {false} ;
         T001V12_A133ProveedorID = new long[1] ;
         T001V12_n133ProveedorID = new bool[] {false} ;
         T001V16_A278ProveedoresTipoNombre = new string[] {""} ;
         T001V17_A422PostulacionesId = new long[1] ;
         T001V18_A918MapeoID = new long[1] ;
         T001V19_A918MapeoID = new long[1] ;
         T001V20_A491VincularTrnId = new long[1] ;
         T001V21_A450ProfComisionesID = new long[1] ;
         T001V21_A452ProfComisionesRubrosId = new long[1] ;
         T001V22_A127SolicitudesID = new long[1] ;
         T001V23_A127SolicitudesID = new long[1] ;
         T001V24_A133ProveedorID = new long[1] ;
         T001V24_n133ProveedorID = new bool[] {false} ;
         T001V24_A713ComercioProductosRubrosID = new long[1] ;
         T001V25_A590Listaid = new long[1] ;
         T001V25_A133ProveedorID = new long[1] ;
         T001V25_n133ProveedorID = new bool[] {false} ;
         T001V25_A120ProfesionalesId = new string[] {""} ;
         T001V26_A590Listaid = new long[1] ;
         T001V26_A18SecUserId = new long[1] ;
         T001V26_A133ProveedorID = new long[1] ;
         T001V26_n133ProveedorID = new bool[] {false} ;
         T001V27_A503ComisionesID = new long[1] ;
         T001V27_A133ProveedorID = new long[1] ;
         T001V27_n133ProveedorID = new bool[] {false} ;
         T001V28_A133ProveedorID = new long[1] ;
         T001V28_n133ProveedorID = new bool[] {false} ;
         T001V28_A157ProveedorComisionID = new long[1] ;
         T001V29_A133ProveedorID = new long[1] ;
         T001V29_n133ProveedorID = new bool[] {false} ;
         T001V30_A133ProveedorID = new long[1] ;
         T001V30_n133ProveedorID = new bool[] {false} ;
         T001V30_A152ProveedorSolicitudesId = new long[1] ;
         T001V30_A337ProveedorSolicitudesNombre = new string[] {""} ;
         T001V31_A133ProveedorID = new long[1] ;
         T001V31_n133ProveedorID = new bool[] {false} ;
         T001V31_A152ProveedorSolicitudesId = new long[1] ;
         T001V3_A133ProveedorID = new long[1] ;
         T001V3_n133ProveedorID = new bool[] {false} ;
         T001V3_A152ProveedorSolicitudesId = new long[1] ;
         T001V3_A337ProveedorSolicitudesNombre = new string[] {""} ;
         T001V2_A133ProveedorID = new long[1] ;
         T001V2_n133ProveedorID = new bool[] {false} ;
         T001V2_A152ProveedorSolicitudesId = new long[1] ;
         T001V2_A337ProveedorSolicitudesNombre = new string[] {""} ;
         T001V35_A133ProveedorID = new long[1] ;
         T001V35_n133ProveedorID = new bool[] {false} ;
         T001V35_A152ProveedorSolicitudesId = new long[1] ;
         Gridproveedorsolicitudes_solicitudesRow = new GXWebRow();
         subGridproveedorsolicitudes_solicitudes_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         Gridproveedorsolicitudes_solicitudesColumn = new GXWebColumn();
         ZZ282ProveedorNombre = "";
         ZZ432ProveedorImagen = "";
         ZZ40000ProveedorImagen_GXI = "";
         ZZ278ProveedoresTipoNombre = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.proveedorsolicitudes__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.proveedorsolicitudes__default(),
            new Object[][] {
                new Object[] {
               T001V2_A133ProveedorID, T001V2_A152ProveedorSolicitudesId, T001V2_A337ProveedorSolicitudesNombre
               }
               , new Object[] {
               T001V3_A133ProveedorID, T001V3_A152ProveedorSolicitudesId, T001V3_A337ProveedorSolicitudesNombre
               }
               , new Object[] {
               T001V4_A133ProveedorID, T001V4_A282ProveedorNombre, T001V4_A40000ProveedorImagen_GXI, T001V4_n40000ProveedorImagen_GXI, T001V4_A978ProveedorCIU, T001V4_A151ProveedoresTipoId, T001V4_A432ProveedorImagen, T001V4_n432ProveedorImagen
               }
               , new Object[] {
               T001V5_A133ProveedorID, T001V5_A282ProveedorNombre, T001V5_A40000ProveedorImagen_GXI, T001V5_n40000ProveedorImagen_GXI, T001V5_A978ProveedorCIU, T001V5_A151ProveedoresTipoId, T001V5_A432ProveedorImagen, T001V5_n432ProveedorImagen
               }
               , new Object[] {
               T001V6_A278ProveedoresTipoNombre
               }
               , new Object[] {
               T001V7_A133ProveedorID, T001V7_A278ProveedoresTipoNombre, T001V7_A282ProveedorNombre, T001V7_A40000ProveedorImagen_GXI, T001V7_n40000ProveedorImagen_GXI, T001V7_A978ProveedorCIU, T001V7_A151ProveedoresTipoId, T001V7_A432ProveedorImagen, T001V7_n432ProveedorImagen
               }
               , new Object[] {
               T001V8_A278ProveedoresTipoNombre
               }
               , new Object[] {
               T001V9_A133ProveedorID
               }
               , new Object[] {
               T001V10_A133ProveedorID
               }
               , new Object[] {
               T001V11_A133ProveedorID
               }
               , new Object[] {
               T001V12_A133ProveedorID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001V16_A278ProveedoresTipoNombre
               }
               , new Object[] {
               T001V17_A422PostulacionesId
               }
               , new Object[] {
               T001V18_A918MapeoID
               }
               , new Object[] {
               T001V19_A918MapeoID
               }
               , new Object[] {
               T001V20_A491VincularTrnId
               }
               , new Object[] {
               T001V21_A450ProfComisionesID, T001V21_A452ProfComisionesRubrosId
               }
               , new Object[] {
               T001V22_A127SolicitudesID
               }
               , new Object[] {
               T001V23_A127SolicitudesID
               }
               , new Object[] {
               T001V24_A133ProveedorID, T001V24_A713ComercioProductosRubrosID
               }
               , new Object[] {
               T001V25_A590Listaid, T001V25_A133ProveedorID, T001V25_A120ProfesionalesId
               }
               , new Object[] {
               T001V26_A590Listaid, T001V26_A18SecUserId, T001V26_A133ProveedorID
               }
               , new Object[] {
               T001V27_A503ComisionesID, T001V27_A133ProveedorID
               }
               , new Object[] {
               T001V28_A133ProveedorID, T001V28_A157ProveedorComisionID
               }
               , new Object[] {
               T001V29_A133ProveedorID
               }
               , new Object[] {
               T001V30_A133ProveedorID, T001V30_A152ProveedorSolicitudesId, T001V30_A337ProveedorSolicitudesNombre
               }
               , new Object[] {
               T001V31_A133ProveedorID, T001V31_A152ProveedorSolicitudesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001V35_A133ProveedorID, T001V35_A152ProveedorSolicitudesId
               }
            }
         );
         Z978ProveedorCIU = false;
         A978ProveedorCIU = false;
         i978ProveedorCIU = false;
      }

      private short nRcdDeleted_52 ;
      private short nRcdExists_52 ;
      private short nIsMod_52 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount52 ;
      private short RcdFound52 ;
      private short nBlankRcdUsr52 ;
      private short Gx_BScreen ;
      private short RcdFound28 ;
      private short nIsDirty_52 ;
      private short subGridproveedorsolicitudes_solicitudes_Backcolorstyle ;
      private short subGridproveedorsolicitudes_solicitudes_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridproveedorsolicitudes_solicitudes_Allowselection ;
      private short subGridproveedorsolicitudes_solicitudes_Allowhovering ;
      private short subGridproveedorsolicitudes_solicitudes_Allowcollapsing ;
      private short subGridproveedorsolicitudes_solicitudes_Collapsed ;
      private int nRC_GXsfl_63 ;
      private int nGXsfl_63_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProveedorID_Enabled ;
      private int edtProveedoresTipoId_Enabled ;
      private int imgprompt_151_Visible ;
      private int edtProveedoresTipoNombre_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int imgProveedorImagen_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtProveedorSolicitudesId_Enabled ;
      private int edtProveedorSolicitudesNombre_Enabled ;
      private int fRowAdded ;
      private int subGridproveedorsolicitudes_solicitudes_Backcolor ;
      private int subGridproveedorsolicitudes_solicitudes_Allbackcolor ;
      private int defedtProveedorSolicitudesId_Enabled ;
      private int idxLst ;
      private int subGridproveedorsolicitudes_solicitudes_Selectedindex ;
      private int subGridproveedorsolicitudes_solicitudes_Selectioncolor ;
      private int subGridproveedorsolicitudes_solicitudes_Hoveringcolor ;
      private long Z133ProveedorID ;
      private long Z151ProveedoresTipoId ;
      private long Z152ProveedorSolicitudesId ;
      private long A151ProveedoresTipoId ;
      private long A133ProveedorID ;
      private long GRIDPROVEEDORSOLICITUDES_SOLICITUDES_nFirstRecordOnPage ;
      private long A152ProveedorSolicitudesId ;
      private long ZZ133ProveedorID ;
      private long ZZ151ProveedoresTipoId ;
      private string sPrefix ;
      private string Z282ProveedorNombre ;
      private string Z337ProveedorSolicitudesNombre ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProveedorID_Internalname ;
      private string sGXsfl_63_idx="0001" ;
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
      private string edtProveedorID_Jsonclick ;
      private string edtProveedoresTipoId_Internalname ;
      private string edtProveedoresTipoId_Jsonclick ;
      private string imgprompt_151_gximage ;
      private string sImgUrl ;
      private string imgprompt_151_Internalname ;
      private string imgprompt_151_Link ;
      private string edtProveedoresTipoNombre_Internalname ;
      private string A278ProveedoresTipoNombre ;
      private string edtProveedoresTipoNombre_Jsonclick ;
      private string edtProveedorNombre_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Jsonclick ;
      private string imgProveedorImagen_Internalname ;
      private string divSolicitudestable_Internalname ;
      private string lblTitlesolicitudes_Internalname ;
      private string lblTitlesolicitudes_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode52 ;
      private string edtProveedorSolicitudesId_Internalname ;
      private string edtProveedorSolicitudesNombre_Internalname ;
      private string sStyleString ;
      private string subGridproveedorsolicitudes_solicitudes_Internalname ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A337ProveedorSolicitudesNombre ;
      private string Z278ProveedoresTipoNombre ;
      private string sMode28 ;
      private string sGXsfl_63_fel_idx="0001" ;
      private string subGridproveedorsolicitudes_solicitudes_Class ;
      private string subGridproveedorsolicitudes_solicitudes_Linesclass ;
      private string ROClassString ;
      private string edtProveedorSolicitudesId_Jsonclick ;
      private string edtProveedorSolicitudesNombre_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string subGridproveedorsolicitudes_solicitudes_Header ;
      private string ZZ282ProveedorNombre ;
      private string ZZ278ProveedoresTipoNombre ;
      private bool Z978ProveedorCIU ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A432ProveedorImagen_IsBlob ;
      private bool bGXsfl_63_Refreshing=false ;
      private bool A978ProveedorCIU ;
      private bool n40000ProveedorImagen_GXI ;
      private bool n133ProveedorID ;
      private bool n432ProveedorImagen ;
      private bool i978ProveedorCIU ;
      private bool ZZ978ProveedorCIU ;
      private string A40000ProveedorImagen_GXI ;
      private string Z40000ProveedorImagen_GXI ;
      private string ZZ40000ProveedorImagen_GXI ;
      private string A432ProveedorImagen ;
      private string Z432ProveedorImagen ;
      private string ZZ432ProveedorImagen ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridproveedorsolicitudes_solicitudesContainer ;
      private GXWebRow Gridproveedorsolicitudes_solicitudesRow ;
      private GXWebColumn Gridproveedorsolicitudes_solicitudesColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T001V7_A133ProveedorID ;
      private bool[] T001V7_n133ProveedorID ;
      private string[] T001V7_A278ProveedoresTipoNombre ;
      private string[] T001V7_A282ProveedorNombre ;
      private string[] T001V7_A40000ProveedorImagen_GXI ;
      private bool[] T001V7_n40000ProveedorImagen_GXI ;
      private bool[] T001V7_A978ProveedorCIU ;
      private long[] T001V7_A151ProveedoresTipoId ;
      private string[] T001V7_A432ProveedorImagen ;
      private bool[] T001V7_n432ProveedorImagen ;
      private string[] T001V6_A278ProveedoresTipoNombre ;
      private string[] T001V8_A278ProveedoresTipoNombre ;
      private long[] T001V9_A133ProveedorID ;
      private bool[] T001V9_n133ProveedorID ;
      private long[] T001V5_A133ProveedorID ;
      private bool[] T001V5_n133ProveedorID ;
      private string[] T001V5_A282ProveedorNombre ;
      private string[] T001V5_A40000ProveedorImagen_GXI ;
      private bool[] T001V5_n40000ProveedorImagen_GXI ;
      private bool[] T001V5_A978ProveedorCIU ;
      private long[] T001V5_A151ProveedoresTipoId ;
      private string[] T001V5_A432ProveedorImagen ;
      private bool[] T001V5_n432ProveedorImagen ;
      private long[] T001V10_A133ProveedorID ;
      private bool[] T001V10_n133ProveedorID ;
      private long[] T001V11_A133ProveedorID ;
      private bool[] T001V11_n133ProveedorID ;
      private long[] T001V4_A133ProveedorID ;
      private bool[] T001V4_n133ProveedorID ;
      private string[] T001V4_A282ProveedorNombre ;
      private string[] T001V4_A40000ProveedorImagen_GXI ;
      private bool[] T001V4_n40000ProveedorImagen_GXI ;
      private bool[] T001V4_A978ProveedorCIU ;
      private long[] T001V4_A151ProveedoresTipoId ;
      private string[] T001V4_A432ProveedorImagen ;
      private bool[] T001V4_n432ProveedorImagen ;
      private long[] T001V12_A133ProveedorID ;
      private bool[] T001V12_n133ProveedorID ;
      private string[] T001V16_A278ProveedoresTipoNombre ;
      private long[] T001V17_A422PostulacionesId ;
      private long[] T001V18_A918MapeoID ;
      private long[] T001V19_A918MapeoID ;
      private long[] T001V20_A491VincularTrnId ;
      private long[] T001V21_A450ProfComisionesID ;
      private long[] T001V21_A452ProfComisionesRubrosId ;
      private long[] T001V22_A127SolicitudesID ;
      private long[] T001V23_A127SolicitudesID ;
      private long[] T001V24_A133ProveedorID ;
      private bool[] T001V24_n133ProveedorID ;
      private long[] T001V24_A713ComercioProductosRubrosID ;
      private long[] T001V25_A590Listaid ;
      private long[] T001V25_A133ProveedorID ;
      private bool[] T001V25_n133ProveedorID ;
      private string[] T001V25_A120ProfesionalesId ;
      private long[] T001V26_A590Listaid ;
      private long[] T001V26_A18SecUserId ;
      private long[] T001V26_A133ProveedorID ;
      private bool[] T001V26_n133ProveedorID ;
      private long[] T001V27_A503ComisionesID ;
      private long[] T001V27_A133ProveedorID ;
      private bool[] T001V27_n133ProveedorID ;
      private long[] T001V28_A133ProveedorID ;
      private bool[] T001V28_n133ProveedorID ;
      private long[] T001V28_A157ProveedorComisionID ;
      private long[] T001V29_A133ProveedorID ;
      private bool[] T001V29_n133ProveedorID ;
      private long[] T001V30_A133ProveedorID ;
      private bool[] T001V30_n133ProveedorID ;
      private long[] T001V30_A152ProveedorSolicitudesId ;
      private string[] T001V30_A337ProveedorSolicitudesNombre ;
      private long[] T001V31_A133ProveedorID ;
      private bool[] T001V31_n133ProveedorID ;
      private long[] T001V31_A152ProveedorSolicitudesId ;
      private long[] T001V3_A133ProveedorID ;
      private bool[] T001V3_n133ProveedorID ;
      private long[] T001V3_A152ProveedorSolicitudesId ;
      private string[] T001V3_A337ProveedorSolicitudesNombre ;
      private long[] T001V2_A133ProveedorID ;
      private bool[] T001V2_n133ProveedorID ;
      private long[] T001V2_A152ProveedorSolicitudesId ;
      private string[] T001V2_A337ProveedorSolicitudesNombre ;
      private long[] T001V35_A133ProveedorID ;
      private bool[] T001V35_n133ProveedorID ;
      private long[] T001V35_A152ProveedorSolicitudesId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class proveedorsolicitudes__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class proveedorsolicitudes__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new UpdateCursor(def[30])
       ,new UpdateCursor(def[31])
       ,new UpdateCursor(def[32])
       ,new ForEachCursor(def[33])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001V2;
        prmT001V2 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT001V3;
        prmT001V3 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT001V4;
        prmT001V4 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V5;
        prmT001V5 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V6;
        prmT001V6 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT001V7;
        prmT001V7 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V8;
        prmT001V8 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT001V9;
        prmT001V9 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V10;
        prmT001V10 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V11;
        prmT001V11 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V12;
        prmT001V12 = new Object[] {
        new ParDef("@ProveedorNombre",GXType.NChar,80,0) ,
        new ParDef("@ProveedorImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ProveedorImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=1, Tbl="Proveedor", Fld="ProveedorImagen"} ,
        new ParDef("@ProveedorCIU",GXType.Boolean,4,0) ,
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT001V13;
        prmT001V13 = new Object[] {
        new ParDef("@ProveedorNombre",GXType.NChar,80,0) ,
        new ParDef("@ProveedorCIU",GXType.Boolean,4,0) ,
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V14;
        prmT001V14 = new Object[] {
        new ParDef("@ProveedorImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ProveedorImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Proveedor", Fld="ProveedorImagen"} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V15;
        prmT001V15 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V16;
        prmT001V16 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT001V17;
        prmT001V17 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V18;
        prmT001V18 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V19;
        prmT001V19 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V20;
        prmT001V20 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V21;
        prmT001V21 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V22;
        prmT001V22 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V23;
        prmT001V23 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V24;
        prmT001V24 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V25;
        prmT001V25 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V26;
        prmT001V26 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V27;
        prmT001V27 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V28;
        prmT001V28 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001V29;
        prmT001V29 = new Object[] {
        };
        Object[] prmT001V30;
        prmT001V30 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT001V31;
        prmT001V31 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT001V32;
        prmT001V32 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorSolicitudesNombre",GXType.NChar,120,0)
        };
        Object[] prmT001V33;
        prmT001V33 = new Object[] {
        new ParDef("@ProveedorSolicitudesNombre",GXType.NChar,120,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT001V34;
        prmT001V34 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT001V35;
        prmT001V35 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T001V2", "SELECT [ProveedorID], [ProveedorSolicitudesId], [ProveedorSolicitudesNombre] FROM [ProveedorSolicitudes] WITH (UPDLOCK) WHERE [ProveedorID] = @ProveedorID AND [ProveedorSolicitudesId] = @ProveedorSolicitudesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V3", "SELECT [ProveedorID], [ProveedorSolicitudesId], [ProveedorSolicitudesNombre] FROM [ProveedorSolicitudes] WHERE [ProveedorID] = @ProveedorID AND [ProveedorSolicitudesId] = @ProveedorSolicitudesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V4", "SELECT [ProveedorID], [ProveedorNombre], [ProveedorImagen_GXI], [ProveedorCIU], [ProveedoresTipoId], [ProveedorImagen] FROM [Proveedor] WITH (UPDLOCK) WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V5", "SELECT [ProveedorID], [ProveedorNombre], [ProveedorImagen_GXI], [ProveedorCIU], [ProveedoresTipoId], [ProveedorImagen] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V6", "SELECT [ProveedoresTipoNombre] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V7", "SELECT TM1.[ProveedorID], T2.[ProveedoresTipoNombre], TM1.[ProveedorNombre], TM1.[ProveedorImagen_GXI], TM1.[ProveedorCIU], TM1.[ProveedoresTipoId], TM1.[ProveedorImagen] FROM ([Proveedor] TM1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = TM1.[ProveedoresTipoId]) WHERE TM1.[ProveedorID] = @ProveedorID ORDER BY TM1.[ProveedorID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001V7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V8", "SELECT [ProveedoresTipoNombre] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V9", "SELECT [ProveedorID] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001V9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V10", "SELECT TOP 1 [ProveedorID] FROM [Proveedor] WHERE ( [ProveedorID] > @ProveedorID) ORDER BY [ProveedorID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001V10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V11", "SELECT TOP 1 [ProveedorID] FROM [Proveedor] WHERE ( [ProveedorID] < @ProveedorID) ORDER BY [ProveedorID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001V11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V12", "INSERT INTO [Proveedor]([ProveedorNombre], [ProveedorImagen], [ProveedorImagen_GXI], [ProveedorCIU], [ProveedoresTipoId], [ProveedorDocIdentidad], [ProveedorSerialComi], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorPerAltShop], [ProveedorEstado], [ProveedorPagoDefault], [ProveedorPideDoc], [DocumentacionId], [ProveedorUsrAlta], [ProveedorUsrActualizacion], [ProveedorFechaAlta], [ProveedorFechaActualizacion], [ProveedorUsoInterno], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorSitioWeb], [ProveedorAceptoTerminos], [ProveedorCuentaBancaria], [BancoId], [ComercioProductosREnum], [ProveedorFreezePrice]) VALUES(@ProveedorNombre, @ProveedorImagen, @ProveedorImagen_GXI, @ProveedorCIU, @ProveedoresTipoId, '', convert(int, 0), '', '', '', '', '', '', '', convert(int, 0), convert(int, 0), convert(int, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', convert( DATETIME, '17530101', 112 ), '', convert(int, 0), convert(int, 0), convert(bit, 0)); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001V12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V13", "UPDATE [Proveedor] SET [ProveedorNombre]=@ProveedorNombre, [ProveedorCIU]=@ProveedorCIU, [ProveedoresTipoId]=@ProveedoresTipoId  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT001V13)
           ,new CursorDef("T001V14", "UPDATE [Proveedor] SET [ProveedorImagen]=@ProveedorImagen, [ProveedorImagen_GXI]=@ProveedorImagen_GXI  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT001V14)
           ,new CursorDef("T001V15", "DELETE FROM [Proveedor]  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT001V15)
           ,new CursorDef("T001V16", "SELECT [ProveedoresTipoNombre] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V17", "SELECT TOP 1 [PostulacionesId] FROM [Postulaciones] WHERE [PostulacionesProveedorId] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V18", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE [STComerciosID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V19", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V20", "SELECT TOP 1 [VincularTrnId] FROM [VincularTrn] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V21", "SELECT TOP 1 [ProfComisionesID], [ProfComisionesRubrosId] FROM [ProfComisionesRubros] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V22", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [STComerciosID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V23", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V24", "SELECT TOP 1 [ProveedorID], [ComercioProductosRubrosID] FROM [ComercioProductosRubros] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V25", "SELECT TOP 1 [Listaid], [ProveedorID], [ProfesionalesId] FROM [ListaAgrupacion] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V26", "SELECT TOP 1 [Listaid], [SecUserId], [ProveedorID] FROM [ListaAgrUserProveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V27", "SELECT TOP 1 [ComisionesID], [ProveedorID] FROM [ComisionesProveedores] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V28", "SELECT TOP 1 [ProveedorID], [ProveedorComisionID] FROM [ProveedorComision] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V29", "SELECT [ProveedorID] FROM [Proveedor] ORDER BY [ProveedorID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001V29,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V30", "SELECT [ProveedorID], [ProveedorSolicitudesId], [ProveedorSolicitudesNombre] FROM [ProveedorSolicitudes] WHERE [ProveedorID] = @ProveedorID and [ProveedorSolicitudesId] = @ProveedorSolicitudesId ORDER BY [ProveedorID], [ProveedorSolicitudesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V30,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V31", "SELECT [ProveedorID], [ProveedorSolicitudesId] FROM [ProveedorSolicitudes] WHERE [ProveedorID] = @ProveedorID AND [ProveedorSolicitudesId] = @ProveedorSolicitudesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V31,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V32", "INSERT INTO [ProveedorSolicitudes]([ProveedorID], [ProveedorSolicitudesId], [ProveedorSolicitudesNombre], [ProveedorSolicitudesFecha]) VALUES(@ProveedorID, @ProveedorSolicitudesId, @ProveedorSolicitudesNombre, convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmT001V32)
           ,new CursorDef("T001V33", "UPDATE [ProveedorSolicitudes] SET [ProveedorSolicitudesNombre]=@ProveedorSolicitudesNombre  WHERE [ProveedorID] = @ProveedorID AND [ProveedorSolicitudesId] = @ProveedorSolicitudesId", GxErrorMask.GX_NOMASK,prmT001V33)
           ,new CursorDef("T001V34", "DELETE FROM [ProveedorSolicitudes]  WHERE [ProveedorID] = @ProveedorID AND [ProveedorSolicitudesId] = @ProveedorSolicitudesId", GxErrorMask.GX_NOMASK,prmT001V34)
           ,new CursorDef("T001V35", "SELECT [ProveedorID], [ProveedorSolicitudesId] FROM [ProveedorSolicitudes] WHERE [ProveedorID] = @ProveedorID ORDER BY [ProveedorID], [ProveedorSolicitudesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V35,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((bool[]) buf[4])[0] = rslt.getBool(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((bool[]) buf[4])[0] = rslt.getBool(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(4));
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
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
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 23 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 33 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
  }

}

}
