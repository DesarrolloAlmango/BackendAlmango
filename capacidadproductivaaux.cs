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
   public class capacidadproductivaaux : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         Form.Meta.addItem("description", context.GetMessage( "Capacidad Productiva Aux", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCapacidadProductivaAuxId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public capacidadproductivaaux( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public capacidadproductivaaux( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Capacidad Productiva Aux", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_CapacidadProductivaAux.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CapacidadProductivaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CapacidadProductivaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CapacidadProductivaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CapacidadProductivaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx03f0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CAPACIDADPRODUCTIVAAUXID"+"'), id:'"+"CAPACIDADPRODUCTIVAAUXID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_CapacidadProductivaAux.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProductivaAuxId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProductivaAuxId_Internalname, context.GetMessage( "Aux Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProductivaAuxId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A820CapacidadProductivaAuxId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCapacidadProductivaAuxId_Enabled!=0) ? context.localUtil.Format( (decimal)(A820CapacidadProductivaAuxId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A820CapacidadProductivaAuxId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProductivaAuxId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProductivaAuxId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CapacidadProductivaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProductivaAuxProfId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProductivaAuxProfId_Internalname, context.GetMessage( "Prof Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProductivaAuxProfId_Internalname, StringUtil.RTrim( A824CapacidadProductivaAuxProfId), StringUtil.RTrim( context.localUtil.Format( A824CapacidadProductivaAuxProfId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProductivaAuxProfId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProductivaAuxProfId_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CapacidadProductivaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProductivaAuxDepId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProductivaAuxDepId_Internalname, context.GetMessage( "Dep Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProductivaAuxDepId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A825CapacidadProductivaAuxDepId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCapacidadProductivaAuxDepId_Enabled!=0) ? context.localUtil.Format( (decimal)(A825CapacidadProductivaAuxDepId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A825CapacidadProductivaAuxDepId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProductivaAuxDepId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProductivaAuxDepId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CapacidadProductivaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProductivaAuxRubroId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProductivaAuxRubroId_Internalname, context.GetMessage( "Rubro Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProductivaAuxRubroId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A835CapacidadProductivaAuxRubroId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCapacidadProductivaAuxRubroId_Enabled!=0) ? context.localUtil.Format( (decimal)(A835CapacidadProductivaAuxRubroId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A835CapacidadProductivaAuxRubroId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProductivaAuxRubroId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProductivaAuxRubroId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CapacidadProductivaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProductivaAuxDepNombr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProductivaAuxDepNombr_Internalname, context.GetMessage( "Dep Nombre", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProductivaAuxDepNombr_Internalname, StringUtil.RTrim( A834CapacidadProductivaAuxDepNombr), StringUtil.RTrim( context.localUtil.Format( A834CapacidadProductivaAuxDepNombr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProductivaAuxDepNombr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProductivaAuxDepNombr_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_CapacidadProductivaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProductivaAuxCant_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProductivaAuxCant_Internalname, context.GetMessage( "Aux Cant", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProductivaAuxCant_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A821CapacidadProductivaAuxCant), 12, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCapacidadProductivaAuxCant_Enabled!=0) ? context.localUtil.Format( (decimal)(A821CapacidadProductivaAuxCant), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A821CapacidadProductivaAuxCant), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProductivaAuxCant_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProductivaAuxCant_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CapacidadProductivaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProductivaAuxPorcent_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProductivaAuxPorcent_Internalname, context.GetMessage( "Aux Porcent", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProductivaAuxPorcent_Internalname, StringUtil.LTrim( StringUtil.NToC( A826CapacidadProductivaAuxPorcent, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCapacidadProductivaAuxPorcent_Enabled!=0) ? context.localUtil.Format( A826CapacidadProductivaAuxPorcent, "ZZ9.99") : context.localUtil.Format( A826CapacidadProductivaAuxPorcent, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProductivaAuxPorcent_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProductivaAuxPorcent_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CapacidadProductivaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProductivaAuxHoras_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProductivaAuxHoras_Internalname, context.GetMessage( "Aux Horas", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProductivaAuxHoras_Internalname, StringUtil.LTrim( StringUtil.NToC( A808CapacidadProductivaAuxHoras, 22, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCapacidadProductivaAuxHoras_Enabled!=0) ? context.localUtil.Format( A808CapacidadProductivaAuxHoras, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A808CapacidadProductivaAuxHoras, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProductivaAuxHoras_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProductivaAuxHoras_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "Total", "end", false, "", "HLP_CapacidadProductivaAux.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CapacidadProductivaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CapacidadProductivaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CapacidadProductivaAux.htm");
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
            Z820CapacidadProductivaAuxId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z820CapacidadProductivaAuxId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z824CapacidadProductivaAuxProfId = cgiGet( "Z824CapacidadProductivaAuxProfId");
            Z825CapacidadProductivaAuxDepId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z825CapacidadProductivaAuxDepId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z835CapacidadProductivaAuxRubroId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z835CapacidadProductivaAuxRubroId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z834CapacidadProductivaAuxDepNombr = cgiGet( "Z834CapacidadProductivaAuxDepNombr");
            Z821CapacidadProductivaAuxCant = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z821CapacidadProductivaAuxCant"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z826CapacidadProductivaAuxPorcent = context.localUtil.CToN( cgiGet( "Z826CapacidadProductivaAuxPorcent"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            Z808CapacidadProductivaAuxHoras = context.localUtil.CToN( cgiGet( "Z808CapacidadProductivaAuxHoras"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAPACIDADPRODUCTIVAAUXID");
               AnyError = 1;
               GX_FocusControl = edtCapacidadProductivaAuxId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A820CapacidadProductivaAuxId = 0;
               AssignAttri("", false, "A820CapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(A820CapacidadProductivaAuxId), 18, 0));
            }
            else
            {
               A820CapacidadProductivaAuxId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A820CapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(A820CapacidadProductivaAuxId), 18, 0));
            }
            A824CapacidadProductivaAuxProfId = cgiGet( edtCapacidadProductivaAuxProfId_Internalname);
            AssignAttri("", false, "A824CapacidadProductivaAuxProfId", A824CapacidadProductivaAuxProfId);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxDepId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxDepId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAPACIDADPRODUCTIVAAUXDEPID");
               AnyError = 1;
               GX_FocusControl = edtCapacidadProductivaAuxDepId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A825CapacidadProductivaAuxDepId = 0;
               AssignAttri("", false, "A825CapacidadProductivaAuxDepId", StringUtil.LTrimStr( (decimal)(A825CapacidadProductivaAuxDepId), 18, 0));
            }
            else
            {
               A825CapacidadProductivaAuxDepId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxDepId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A825CapacidadProductivaAuxDepId", StringUtil.LTrimStr( (decimal)(A825CapacidadProductivaAuxDepId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxRubroId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxRubroId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAPACIDADPRODUCTIVAAUXRUBROID");
               AnyError = 1;
               GX_FocusControl = edtCapacidadProductivaAuxRubroId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A835CapacidadProductivaAuxRubroId = 0;
               AssignAttri("", false, "A835CapacidadProductivaAuxRubroId", StringUtil.LTrimStr( (decimal)(A835CapacidadProductivaAuxRubroId), 18, 0));
            }
            else
            {
               A835CapacidadProductivaAuxRubroId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxRubroId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A835CapacidadProductivaAuxRubroId", StringUtil.LTrimStr( (decimal)(A835CapacidadProductivaAuxRubroId), 18, 0));
            }
            A834CapacidadProductivaAuxDepNombr = cgiGet( edtCapacidadProductivaAuxDepNombr_Internalname);
            AssignAttri("", false, "A834CapacidadProductivaAuxDepNombr", A834CapacidadProductivaAuxDepNombr);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxCant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxCant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAPACIDADPRODUCTIVAAUXCANT");
               AnyError = 1;
               GX_FocusControl = edtCapacidadProductivaAuxCant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A821CapacidadProductivaAuxCant = 0;
               AssignAttri("", false, "A821CapacidadProductivaAuxCant", StringUtil.LTrimStr( (decimal)(A821CapacidadProductivaAuxCant), 12, 0));
            }
            else
            {
               A821CapacidadProductivaAuxCant = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxCant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A821CapacidadProductivaAuxCant", StringUtil.LTrimStr( (decimal)(A821CapacidadProductivaAuxCant), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxPorcent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxPorcent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAPACIDADPRODUCTIVAAUXPORCENT");
               AnyError = 1;
               GX_FocusControl = edtCapacidadProductivaAuxPorcent_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A826CapacidadProductivaAuxPorcent = 0;
               AssignAttri("", false, "A826CapacidadProductivaAuxPorcent", StringUtil.LTrimStr( A826CapacidadProductivaAuxPorcent, 6, 2));
            }
            else
            {
               A826CapacidadProductivaAuxPorcent = context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxPorcent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A826CapacidadProductivaAuxPorcent", StringUtil.LTrimStr( A826CapacidadProductivaAuxPorcent, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxHoras_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxHoras_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAPACIDADPRODUCTIVAAUXHORAS");
               AnyError = 1;
               GX_FocusControl = edtCapacidadProductivaAuxHoras_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A808CapacidadProductivaAuxHoras = 0;
               AssignAttri("", false, "A808CapacidadProductivaAuxHoras", StringUtil.LTrimStr( A808CapacidadProductivaAuxHoras, 18, 2));
            }
            else
            {
               A808CapacidadProductivaAuxHoras = context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxHoras_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A808CapacidadProductivaAuxHoras", StringUtil.LTrimStr( A808CapacidadProductivaAuxHoras, 18, 2));
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
               A820CapacidadProductivaAuxId = (long)(Math.Round(NumberUtil.Val( GetPar( "CapacidadProductivaAuxId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A820CapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(A820CapacidadProductivaAuxId), 18, 0));
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
               InitAll2P123( ) ;
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
         DisableAttributes2P123( ) ;
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

      protected void ResetCaption2P0( )
      {
      }

      protected void ZM2P123( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z824CapacidadProductivaAuxProfId = T002P3_A824CapacidadProductivaAuxProfId[0];
               Z825CapacidadProductivaAuxDepId = T002P3_A825CapacidadProductivaAuxDepId[0];
               Z835CapacidadProductivaAuxRubroId = T002P3_A835CapacidadProductivaAuxRubroId[0];
               Z834CapacidadProductivaAuxDepNombr = T002P3_A834CapacidadProductivaAuxDepNombr[0];
               Z821CapacidadProductivaAuxCant = T002P3_A821CapacidadProductivaAuxCant[0];
               Z826CapacidadProductivaAuxPorcent = T002P3_A826CapacidadProductivaAuxPorcent[0];
               Z808CapacidadProductivaAuxHoras = T002P3_A808CapacidadProductivaAuxHoras[0];
            }
            else
            {
               Z824CapacidadProductivaAuxProfId = A824CapacidadProductivaAuxProfId;
               Z825CapacidadProductivaAuxDepId = A825CapacidadProductivaAuxDepId;
               Z835CapacidadProductivaAuxRubroId = A835CapacidadProductivaAuxRubroId;
               Z834CapacidadProductivaAuxDepNombr = A834CapacidadProductivaAuxDepNombr;
               Z821CapacidadProductivaAuxCant = A821CapacidadProductivaAuxCant;
               Z826CapacidadProductivaAuxPorcent = A826CapacidadProductivaAuxPorcent;
               Z808CapacidadProductivaAuxHoras = A808CapacidadProductivaAuxHoras;
            }
         }
         if ( GX_JID == -1 )
         {
            Z820CapacidadProductivaAuxId = A820CapacidadProductivaAuxId;
            Z824CapacidadProductivaAuxProfId = A824CapacidadProductivaAuxProfId;
            Z825CapacidadProductivaAuxDepId = A825CapacidadProductivaAuxDepId;
            Z835CapacidadProductivaAuxRubroId = A835CapacidadProductivaAuxRubroId;
            Z834CapacidadProductivaAuxDepNombr = A834CapacidadProductivaAuxDepNombr;
            Z821CapacidadProductivaAuxCant = A821CapacidadProductivaAuxCant;
            Z826CapacidadProductivaAuxPorcent = A826CapacidadProductivaAuxPorcent;
            Z808CapacidadProductivaAuxHoras = A808CapacidadProductivaAuxHoras;
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

      protected void Load2P123( )
      {
         /* Using cursor T002P4 */
         pr_default.execute(2, new Object[] {A820CapacidadProductivaAuxId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound123 = 1;
            A824CapacidadProductivaAuxProfId = T002P4_A824CapacidadProductivaAuxProfId[0];
            AssignAttri("", false, "A824CapacidadProductivaAuxProfId", A824CapacidadProductivaAuxProfId);
            A825CapacidadProductivaAuxDepId = T002P4_A825CapacidadProductivaAuxDepId[0];
            AssignAttri("", false, "A825CapacidadProductivaAuxDepId", StringUtil.LTrimStr( (decimal)(A825CapacidadProductivaAuxDepId), 18, 0));
            A835CapacidadProductivaAuxRubroId = T002P4_A835CapacidadProductivaAuxRubroId[0];
            AssignAttri("", false, "A835CapacidadProductivaAuxRubroId", StringUtil.LTrimStr( (decimal)(A835CapacidadProductivaAuxRubroId), 18, 0));
            A834CapacidadProductivaAuxDepNombr = T002P4_A834CapacidadProductivaAuxDepNombr[0];
            AssignAttri("", false, "A834CapacidadProductivaAuxDepNombr", A834CapacidadProductivaAuxDepNombr);
            A821CapacidadProductivaAuxCant = T002P4_A821CapacidadProductivaAuxCant[0];
            AssignAttri("", false, "A821CapacidadProductivaAuxCant", StringUtil.LTrimStr( (decimal)(A821CapacidadProductivaAuxCant), 12, 0));
            A826CapacidadProductivaAuxPorcent = T002P4_A826CapacidadProductivaAuxPorcent[0];
            AssignAttri("", false, "A826CapacidadProductivaAuxPorcent", StringUtil.LTrimStr( A826CapacidadProductivaAuxPorcent, 6, 2));
            A808CapacidadProductivaAuxHoras = T002P4_A808CapacidadProductivaAuxHoras[0];
            AssignAttri("", false, "A808CapacidadProductivaAuxHoras", StringUtil.LTrimStr( A808CapacidadProductivaAuxHoras, 18, 2));
            ZM2P123( -1) ;
         }
         pr_default.close(2);
         OnLoadActions2P123( ) ;
      }

      protected void OnLoadActions2P123( )
      {
      }

      protected void CheckExtendedTable2P123( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors2P123( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2P123( )
      {
         /* Using cursor T002P5 */
         pr_default.execute(3, new Object[] {A820CapacidadProductivaAuxId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound123 = 1;
         }
         else
         {
            RcdFound123 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002P3 */
         pr_default.execute(1, new Object[] {A820CapacidadProductivaAuxId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2P123( 1) ;
            RcdFound123 = 1;
            A820CapacidadProductivaAuxId = T002P3_A820CapacidadProductivaAuxId[0];
            AssignAttri("", false, "A820CapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(A820CapacidadProductivaAuxId), 18, 0));
            A824CapacidadProductivaAuxProfId = T002P3_A824CapacidadProductivaAuxProfId[0];
            AssignAttri("", false, "A824CapacidadProductivaAuxProfId", A824CapacidadProductivaAuxProfId);
            A825CapacidadProductivaAuxDepId = T002P3_A825CapacidadProductivaAuxDepId[0];
            AssignAttri("", false, "A825CapacidadProductivaAuxDepId", StringUtil.LTrimStr( (decimal)(A825CapacidadProductivaAuxDepId), 18, 0));
            A835CapacidadProductivaAuxRubroId = T002P3_A835CapacidadProductivaAuxRubroId[0];
            AssignAttri("", false, "A835CapacidadProductivaAuxRubroId", StringUtil.LTrimStr( (decimal)(A835CapacidadProductivaAuxRubroId), 18, 0));
            A834CapacidadProductivaAuxDepNombr = T002P3_A834CapacidadProductivaAuxDepNombr[0];
            AssignAttri("", false, "A834CapacidadProductivaAuxDepNombr", A834CapacidadProductivaAuxDepNombr);
            A821CapacidadProductivaAuxCant = T002P3_A821CapacidadProductivaAuxCant[0];
            AssignAttri("", false, "A821CapacidadProductivaAuxCant", StringUtil.LTrimStr( (decimal)(A821CapacidadProductivaAuxCant), 12, 0));
            A826CapacidadProductivaAuxPorcent = T002P3_A826CapacidadProductivaAuxPorcent[0];
            AssignAttri("", false, "A826CapacidadProductivaAuxPorcent", StringUtil.LTrimStr( A826CapacidadProductivaAuxPorcent, 6, 2));
            A808CapacidadProductivaAuxHoras = T002P3_A808CapacidadProductivaAuxHoras[0];
            AssignAttri("", false, "A808CapacidadProductivaAuxHoras", StringUtil.LTrimStr( A808CapacidadProductivaAuxHoras, 18, 2));
            Z820CapacidadProductivaAuxId = A820CapacidadProductivaAuxId;
            sMode123 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2P123( ) ;
            if ( AnyError == 1 )
            {
               RcdFound123 = 0;
               InitializeNonKey2P123( ) ;
            }
            Gx_mode = sMode123;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound123 = 0;
            InitializeNonKey2P123( ) ;
            sMode123 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode123;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2P123( ) ;
         if ( RcdFound123 == 0 )
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
         RcdFound123 = 0;
         /* Using cursor T002P6 */
         pr_default.execute(4, new Object[] {A820CapacidadProductivaAuxId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T002P6_A820CapacidadProductivaAuxId[0] < A820CapacidadProductivaAuxId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T002P6_A820CapacidadProductivaAuxId[0] > A820CapacidadProductivaAuxId ) ) )
            {
               A820CapacidadProductivaAuxId = T002P6_A820CapacidadProductivaAuxId[0];
               AssignAttri("", false, "A820CapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(A820CapacidadProductivaAuxId), 18, 0));
               RcdFound123 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound123 = 0;
         /* Using cursor T002P7 */
         pr_default.execute(5, new Object[] {A820CapacidadProductivaAuxId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T002P7_A820CapacidadProductivaAuxId[0] > A820CapacidadProductivaAuxId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T002P7_A820CapacidadProductivaAuxId[0] < A820CapacidadProductivaAuxId ) ) )
            {
               A820CapacidadProductivaAuxId = T002P7_A820CapacidadProductivaAuxId[0];
               AssignAttri("", false, "A820CapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(A820CapacidadProductivaAuxId), 18, 0));
               RcdFound123 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2P123( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCapacidadProductivaAuxId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2P123( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound123 == 1 )
            {
               if ( A820CapacidadProductivaAuxId != Z820CapacidadProductivaAuxId )
               {
                  A820CapacidadProductivaAuxId = Z820CapacidadProductivaAuxId;
                  AssignAttri("", false, "A820CapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(A820CapacidadProductivaAuxId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CAPACIDADPRODUCTIVAAUXID");
                  AnyError = 1;
                  GX_FocusControl = edtCapacidadProductivaAuxId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCapacidadProductivaAuxId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2P123( ) ;
                  GX_FocusControl = edtCapacidadProductivaAuxId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A820CapacidadProductivaAuxId != Z820CapacidadProductivaAuxId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCapacidadProductivaAuxId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2P123( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CAPACIDADPRODUCTIVAAUXID");
                     AnyError = 1;
                     GX_FocusControl = edtCapacidadProductivaAuxId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCapacidadProductivaAuxId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2P123( ) ;
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
         if ( A820CapacidadProductivaAuxId != Z820CapacidadProductivaAuxId )
         {
            A820CapacidadProductivaAuxId = Z820CapacidadProductivaAuxId;
            AssignAttri("", false, "A820CapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(A820CapacidadProductivaAuxId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CAPACIDADPRODUCTIVAAUXID");
            AnyError = 1;
            GX_FocusControl = edtCapacidadProductivaAuxId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCapacidadProductivaAuxId_Internalname;
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
         if ( RcdFound123 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CAPACIDADPRODUCTIVAAUXID");
            AnyError = 1;
            GX_FocusControl = edtCapacidadProductivaAuxId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCapacidadProductivaAuxProfId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2P123( ) ;
         if ( RcdFound123 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCapacidadProductivaAuxProfId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2P123( ) ;
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
         if ( RcdFound123 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCapacidadProductivaAuxProfId_Internalname;
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
         if ( RcdFound123 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCapacidadProductivaAuxProfId_Internalname;
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
         ScanStart2P123( ) ;
         if ( RcdFound123 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound123 != 0 )
            {
               ScanNext2P123( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCapacidadProductivaAuxProfId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2P123( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2P123( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002P2 */
            pr_default.execute(0, new Object[] {A820CapacidadProductivaAuxId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CapacidadProductivaAux"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z824CapacidadProductivaAuxProfId, T002P2_A824CapacidadProductivaAuxProfId[0]) != 0 ) || ( Z825CapacidadProductivaAuxDepId != T002P2_A825CapacidadProductivaAuxDepId[0] ) || ( Z835CapacidadProductivaAuxRubroId != T002P2_A835CapacidadProductivaAuxRubroId[0] ) || ( StringUtil.StrCmp(Z834CapacidadProductivaAuxDepNombr, T002P2_A834CapacidadProductivaAuxDepNombr[0]) != 0 ) || ( Z821CapacidadProductivaAuxCant != T002P2_A821CapacidadProductivaAuxCant[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z826CapacidadProductivaAuxPorcent != T002P2_A826CapacidadProductivaAuxPorcent[0] ) || ( Z808CapacidadProductivaAuxHoras != T002P2_A808CapacidadProductivaAuxHoras[0] ) )
            {
               if ( StringUtil.StrCmp(Z824CapacidadProductivaAuxProfId, T002P2_A824CapacidadProductivaAuxProfId[0]) != 0 )
               {
                  GXUtil.WriteLog("capacidadproductivaaux:[seudo value changed for attri]"+"CapacidadProductivaAuxProfId");
                  GXUtil.WriteLogRaw("Old: ",Z824CapacidadProductivaAuxProfId);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A824CapacidadProductivaAuxProfId[0]);
               }
               if ( Z825CapacidadProductivaAuxDepId != T002P2_A825CapacidadProductivaAuxDepId[0] )
               {
                  GXUtil.WriteLog("capacidadproductivaaux:[seudo value changed for attri]"+"CapacidadProductivaAuxDepId");
                  GXUtil.WriteLogRaw("Old: ",Z825CapacidadProductivaAuxDepId);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A825CapacidadProductivaAuxDepId[0]);
               }
               if ( Z835CapacidadProductivaAuxRubroId != T002P2_A835CapacidadProductivaAuxRubroId[0] )
               {
                  GXUtil.WriteLog("capacidadproductivaaux:[seudo value changed for attri]"+"CapacidadProductivaAuxRubroId");
                  GXUtil.WriteLogRaw("Old: ",Z835CapacidadProductivaAuxRubroId);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A835CapacidadProductivaAuxRubroId[0]);
               }
               if ( StringUtil.StrCmp(Z834CapacidadProductivaAuxDepNombr, T002P2_A834CapacidadProductivaAuxDepNombr[0]) != 0 )
               {
                  GXUtil.WriteLog("capacidadproductivaaux:[seudo value changed for attri]"+"CapacidadProductivaAuxDepNombr");
                  GXUtil.WriteLogRaw("Old: ",Z834CapacidadProductivaAuxDepNombr);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A834CapacidadProductivaAuxDepNombr[0]);
               }
               if ( Z821CapacidadProductivaAuxCant != T002P2_A821CapacidadProductivaAuxCant[0] )
               {
                  GXUtil.WriteLog("capacidadproductivaaux:[seudo value changed for attri]"+"CapacidadProductivaAuxCant");
                  GXUtil.WriteLogRaw("Old: ",Z821CapacidadProductivaAuxCant);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A821CapacidadProductivaAuxCant[0]);
               }
               if ( Z826CapacidadProductivaAuxPorcent != T002P2_A826CapacidadProductivaAuxPorcent[0] )
               {
                  GXUtil.WriteLog("capacidadproductivaaux:[seudo value changed for attri]"+"CapacidadProductivaAuxPorcent");
                  GXUtil.WriteLogRaw("Old: ",Z826CapacidadProductivaAuxPorcent);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A826CapacidadProductivaAuxPorcent[0]);
               }
               if ( Z808CapacidadProductivaAuxHoras != T002P2_A808CapacidadProductivaAuxHoras[0] )
               {
                  GXUtil.WriteLog("capacidadproductivaaux:[seudo value changed for attri]"+"CapacidadProductivaAuxHoras");
                  GXUtil.WriteLogRaw("Old: ",Z808CapacidadProductivaAuxHoras);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A808CapacidadProductivaAuxHoras[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CapacidadProductivaAux"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2P123( )
      {
         BeforeValidate2P123( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2P123( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2P123( 0) ;
            CheckOptimisticConcurrency2P123( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2P123( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2P123( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002P8 */
                     pr_default.execute(6, new Object[] {A824CapacidadProductivaAuxProfId, A825CapacidadProductivaAuxDepId, A835CapacidadProductivaAuxRubroId, A834CapacidadProductivaAuxDepNombr, A821CapacidadProductivaAuxCant, A826CapacidadProductivaAuxPorcent, A808CapacidadProductivaAuxHoras});
                     A820CapacidadProductivaAuxId = T002P8_A820CapacidadProductivaAuxId[0];
                     AssignAttri("", false, "A820CapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(A820CapacidadProductivaAuxId), 18, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("CapacidadProductivaAux");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2P0( ) ;
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
               Load2P123( ) ;
            }
            EndLevel2P123( ) ;
         }
         CloseExtendedTableCursors2P123( ) ;
      }

      protected void Update2P123( )
      {
         BeforeValidate2P123( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2P123( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2P123( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2P123( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2P123( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002P9 */
                     pr_default.execute(7, new Object[] {A824CapacidadProductivaAuxProfId, A825CapacidadProductivaAuxDepId, A835CapacidadProductivaAuxRubroId, A834CapacidadProductivaAuxDepNombr, A821CapacidadProductivaAuxCant, A826CapacidadProductivaAuxPorcent, A808CapacidadProductivaAuxHoras, A820CapacidadProductivaAuxId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("CapacidadProductivaAux");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CapacidadProductivaAux"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2P123( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2P0( ) ;
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
            EndLevel2P123( ) ;
         }
         CloseExtendedTableCursors2P123( ) ;
      }

      protected void DeferredUpdate2P123( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2P123( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2P123( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2P123( ) ;
            AfterConfirm2P123( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2P123( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002P10 */
                  pr_default.execute(8, new Object[] {A820CapacidadProductivaAuxId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("CapacidadProductivaAux");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound123 == 0 )
                        {
                           InitAll2P123( ) ;
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
                        ResetCaption2P0( ) ;
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
         sMode123 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2P123( ) ;
         Gx_mode = sMode123;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2P123( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2P123( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2P123( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("capacidadproductivaaux",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2P0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("capacidadproductivaaux",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2P123( )
      {
         /* Using cursor T002P11 */
         pr_default.execute(9);
         RcdFound123 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound123 = 1;
            A820CapacidadProductivaAuxId = T002P11_A820CapacidadProductivaAuxId[0];
            AssignAttri("", false, "A820CapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(A820CapacidadProductivaAuxId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2P123( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound123 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound123 = 1;
            A820CapacidadProductivaAuxId = T002P11_A820CapacidadProductivaAuxId[0];
            AssignAttri("", false, "A820CapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(A820CapacidadProductivaAuxId), 18, 0));
         }
      }

      protected void ScanEnd2P123( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm2P123( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2P123( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2P123( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2P123( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2P123( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2P123( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2P123( )
      {
         edtCapacidadProductivaAuxId_Enabled = 0;
         AssignProp("", false, edtCapacidadProductivaAuxId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProductivaAuxId_Enabled), 5, 0), true);
         edtCapacidadProductivaAuxProfId_Enabled = 0;
         AssignProp("", false, edtCapacidadProductivaAuxProfId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProductivaAuxProfId_Enabled), 5, 0), true);
         edtCapacidadProductivaAuxDepId_Enabled = 0;
         AssignProp("", false, edtCapacidadProductivaAuxDepId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProductivaAuxDepId_Enabled), 5, 0), true);
         edtCapacidadProductivaAuxRubroId_Enabled = 0;
         AssignProp("", false, edtCapacidadProductivaAuxRubroId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProductivaAuxRubroId_Enabled), 5, 0), true);
         edtCapacidadProductivaAuxDepNombr_Enabled = 0;
         AssignProp("", false, edtCapacidadProductivaAuxDepNombr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProductivaAuxDepNombr_Enabled), 5, 0), true);
         edtCapacidadProductivaAuxCant_Enabled = 0;
         AssignProp("", false, edtCapacidadProductivaAuxCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProductivaAuxCant_Enabled), 5, 0), true);
         edtCapacidadProductivaAuxPorcent_Enabled = 0;
         AssignProp("", false, edtCapacidadProductivaAuxPorcent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProductivaAuxPorcent_Enabled), 5, 0), true);
         edtCapacidadProductivaAuxHoras_Enabled = 0;
         AssignProp("", false, edtCapacidadProductivaAuxHoras_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProductivaAuxHoras_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2P123( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2P0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("capacidadproductivaaux.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z820CapacidadProductivaAuxId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z820CapacidadProductivaAuxId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z824CapacidadProductivaAuxProfId", StringUtil.RTrim( Z824CapacidadProductivaAuxProfId));
         GxWebStd.gx_hidden_field( context, "Z825CapacidadProductivaAuxDepId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z825CapacidadProductivaAuxDepId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z835CapacidadProductivaAuxRubroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z835CapacidadProductivaAuxRubroId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z834CapacidadProductivaAuxDepNombr", StringUtil.RTrim( Z834CapacidadProductivaAuxDepNombr));
         GxWebStd.gx_hidden_field( context, "Z821CapacidadProductivaAuxCant", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z821CapacidadProductivaAuxCant), 12, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z826CapacidadProductivaAuxPorcent", StringUtil.LTrim( StringUtil.NToC( Z826CapacidadProductivaAuxPorcent, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z808CapacidadProductivaAuxHoras", StringUtil.LTrim( StringUtil.NToC( Z808CapacidadProductivaAuxHoras, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("capacidadproductivaaux.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CapacidadProductivaAux" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Capacidad Productiva Aux", "") ;
      }

      protected void InitializeNonKey2P123( )
      {
         A824CapacidadProductivaAuxProfId = "";
         AssignAttri("", false, "A824CapacidadProductivaAuxProfId", A824CapacidadProductivaAuxProfId);
         A825CapacidadProductivaAuxDepId = 0;
         AssignAttri("", false, "A825CapacidadProductivaAuxDepId", StringUtil.LTrimStr( (decimal)(A825CapacidadProductivaAuxDepId), 18, 0));
         A835CapacidadProductivaAuxRubroId = 0;
         AssignAttri("", false, "A835CapacidadProductivaAuxRubroId", StringUtil.LTrimStr( (decimal)(A835CapacidadProductivaAuxRubroId), 18, 0));
         A834CapacidadProductivaAuxDepNombr = "";
         AssignAttri("", false, "A834CapacidadProductivaAuxDepNombr", A834CapacidadProductivaAuxDepNombr);
         A821CapacidadProductivaAuxCant = 0;
         AssignAttri("", false, "A821CapacidadProductivaAuxCant", StringUtil.LTrimStr( (decimal)(A821CapacidadProductivaAuxCant), 12, 0));
         A826CapacidadProductivaAuxPorcent = 0;
         AssignAttri("", false, "A826CapacidadProductivaAuxPorcent", StringUtil.LTrimStr( A826CapacidadProductivaAuxPorcent, 6, 2));
         A808CapacidadProductivaAuxHoras = 0;
         AssignAttri("", false, "A808CapacidadProductivaAuxHoras", StringUtil.LTrimStr( A808CapacidadProductivaAuxHoras, 18, 2));
         Z824CapacidadProductivaAuxProfId = "";
         Z825CapacidadProductivaAuxDepId = 0;
         Z835CapacidadProductivaAuxRubroId = 0;
         Z834CapacidadProductivaAuxDepNombr = "";
         Z821CapacidadProductivaAuxCant = 0;
         Z826CapacidadProductivaAuxPorcent = 0;
         Z808CapacidadProductivaAuxHoras = 0;
      }

      protected void InitAll2P123( )
      {
         A820CapacidadProductivaAuxId = 0;
         AssignAttri("", false, "A820CapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(A820CapacidadProductivaAuxId), 18, 0));
         InitializeNonKey2P123( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021163889", true, true, false);
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
         context.AddJavascriptSource("capacidadproductivaaux.js", "?202673021163890", false, true, false);
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
         edtCapacidadProductivaAuxId_Internalname = "CAPACIDADPRODUCTIVAAUXID";
         edtCapacidadProductivaAuxProfId_Internalname = "CAPACIDADPRODUCTIVAAUXPROFID";
         edtCapacidadProductivaAuxDepId_Internalname = "CAPACIDADPRODUCTIVAAUXDEPID";
         edtCapacidadProductivaAuxRubroId_Internalname = "CAPACIDADPRODUCTIVAAUXRUBROID";
         edtCapacidadProductivaAuxDepNombr_Internalname = "CAPACIDADPRODUCTIVAAUXDEPNOMBR";
         edtCapacidadProductivaAuxCant_Internalname = "CAPACIDADPRODUCTIVAAUXCANT";
         edtCapacidadProductivaAuxPorcent_Internalname = "CAPACIDADPRODUCTIVAAUXPORCENT";
         edtCapacidadProductivaAuxHoras_Internalname = "CAPACIDADPRODUCTIVAAUXHORAS";
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
         Form.Caption = context.GetMessage( "Capacidad Productiva Aux", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCapacidadProductivaAuxHoras_Jsonclick = "";
         edtCapacidadProductivaAuxHoras_Enabled = 1;
         edtCapacidadProductivaAuxPorcent_Jsonclick = "";
         edtCapacidadProductivaAuxPorcent_Enabled = 1;
         edtCapacidadProductivaAuxCant_Jsonclick = "";
         edtCapacidadProductivaAuxCant_Enabled = 1;
         edtCapacidadProductivaAuxDepNombr_Jsonclick = "";
         edtCapacidadProductivaAuxDepNombr_Enabled = 1;
         edtCapacidadProductivaAuxRubroId_Jsonclick = "";
         edtCapacidadProductivaAuxRubroId_Enabled = 1;
         edtCapacidadProductivaAuxDepId_Jsonclick = "";
         edtCapacidadProductivaAuxDepId_Enabled = 1;
         edtCapacidadProductivaAuxProfId_Jsonclick = "";
         edtCapacidadProductivaAuxProfId_Enabled = 1;
         edtCapacidadProductivaAuxId_Jsonclick = "";
         edtCapacidadProductivaAuxId_Enabled = 1;
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
         GX_FocusControl = edtCapacidadProductivaAuxProfId_Internalname;
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

      public void Valid_Capacidadproductivaauxid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A824CapacidadProductivaAuxProfId", StringUtil.RTrim( A824CapacidadProductivaAuxProfId));
         AssignAttri("", false, "A825CapacidadProductivaAuxDepId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A825CapacidadProductivaAuxDepId), 18, 0, ".", "")));
         AssignAttri("", false, "A835CapacidadProductivaAuxRubroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A835CapacidadProductivaAuxRubroId), 18, 0, ".", "")));
         AssignAttri("", false, "A834CapacidadProductivaAuxDepNombr", StringUtil.RTrim( A834CapacidadProductivaAuxDepNombr));
         AssignAttri("", false, "A821CapacidadProductivaAuxCant", StringUtil.LTrim( StringUtil.NToC( (decimal)(A821CapacidadProductivaAuxCant), 12, 0, ".", "")));
         AssignAttri("", false, "A826CapacidadProductivaAuxPorcent", StringUtil.LTrim( StringUtil.NToC( A826CapacidadProductivaAuxPorcent, 6, 2, ".", "")));
         AssignAttri("", false, "A808CapacidadProductivaAuxHoras", StringUtil.LTrim( StringUtil.NToC( A808CapacidadProductivaAuxHoras, 18, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z820CapacidadProductivaAuxId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z820CapacidadProductivaAuxId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z824CapacidadProductivaAuxProfId", StringUtil.RTrim( Z824CapacidadProductivaAuxProfId));
         GxWebStd.gx_hidden_field( context, "Z825CapacidadProductivaAuxDepId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z825CapacidadProductivaAuxDepId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z835CapacidadProductivaAuxRubroId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z835CapacidadProductivaAuxRubroId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z834CapacidadProductivaAuxDepNombr", StringUtil.RTrim( Z834CapacidadProductivaAuxDepNombr));
         GxWebStd.gx_hidden_field( context, "Z821CapacidadProductivaAuxCant", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z821CapacidadProductivaAuxCant), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z826CapacidadProductivaAuxPorcent", StringUtil.LTrim( StringUtil.NToC( Z826CapacidadProductivaAuxPorcent, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z808CapacidadProductivaAuxHoras", StringUtil.LTrim( StringUtil.NToC( Z808CapacidadProductivaAuxHoras, 18, 2, ".", "")));
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
         setEventMetadata("VALID_CAPACIDADPRODUCTIVAAUXID","{handler:'Valid_Capacidadproductivaauxid',iparms:[{av:'A820CapacidadProductivaAuxId',fld:'CAPACIDADPRODUCTIVAAUXID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'}]");
         setEventMetadata("VALID_CAPACIDADPRODUCTIVAAUXID",",oparms:[{av:'A824CapacidadProductivaAuxProfId',fld:'CAPACIDADPRODUCTIVAAUXPROFID',pic:'',type:'char'},{av:'A825CapacidadProductivaAuxDepId',fld:'CAPACIDADPRODUCTIVAAUXDEPID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A835CapacidadProductivaAuxRubroId',fld:'CAPACIDADPRODUCTIVAAUXRUBROID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A834CapacidadProductivaAuxDepNombr',fld:'CAPACIDADPRODUCTIVAAUXDEPNOMBR',pic:'',type:'char'},{av:'A821CapacidadProductivaAuxCant',fld:'CAPACIDADPRODUCTIVAAUXCANT',pic:'ZZZZZZZZZZZ9',type:'int'},{av:'A826CapacidadProductivaAuxPorcent',fld:'CAPACIDADPRODUCTIVAAUXPORCENT',pic:'ZZ9.99',type:'decimal'},{av:'A808CapacidadProductivaAuxHoras',fld:'CAPACIDADPRODUCTIVAAUXHORAS',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z820CapacidadProductivaAuxId',type:'int'},{av:'Z824CapacidadProductivaAuxProfId',type:'char'},{av:'Z825CapacidadProductivaAuxDepId',type:'int'},{av:'Z835CapacidadProductivaAuxRubroId',type:'int'},{av:'Z834CapacidadProductivaAuxDepNombr',type:'char'},{av:'Z821CapacidadProductivaAuxCant',type:'int'},{av:'Z826CapacidadProductivaAuxPorcent',type:'decimal'},{av:'Z808CapacidadProductivaAuxHoras',type:'decimal'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z824CapacidadProductivaAuxProfId = "";
         Z834CapacidadProductivaAuxDepNombr = "";
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
         A824CapacidadProductivaAuxProfId = "";
         A834CapacidadProductivaAuxDepNombr = "";
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
         T002P4_A820CapacidadProductivaAuxId = new long[1] ;
         T002P4_A824CapacidadProductivaAuxProfId = new string[] {""} ;
         T002P4_A825CapacidadProductivaAuxDepId = new long[1] ;
         T002P4_A835CapacidadProductivaAuxRubroId = new long[1] ;
         T002P4_A834CapacidadProductivaAuxDepNombr = new string[] {""} ;
         T002P4_A821CapacidadProductivaAuxCant = new long[1] ;
         T002P4_A826CapacidadProductivaAuxPorcent = new decimal[1] ;
         T002P4_A808CapacidadProductivaAuxHoras = new decimal[1] ;
         T002P5_A820CapacidadProductivaAuxId = new long[1] ;
         T002P3_A820CapacidadProductivaAuxId = new long[1] ;
         T002P3_A824CapacidadProductivaAuxProfId = new string[] {""} ;
         T002P3_A825CapacidadProductivaAuxDepId = new long[1] ;
         T002P3_A835CapacidadProductivaAuxRubroId = new long[1] ;
         T002P3_A834CapacidadProductivaAuxDepNombr = new string[] {""} ;
         T002P3_A821CapacidadProductivaAuxCant = new long[1] ;
         T002P3_A826CapacidadProductivaAuxPorcent = new decimal[1] ;
         T002P3_A808CapacidadProductivaAuxHoras = new decimal[1] ;
         sMode123 = "";
         T002P6_A820CapacidadProductivaAuxId = new long[1] ;
         T002P7_A820CapacidadProductivaAuxId = new long[1] ;
         T002P2_A820CapacidadProductivaAuxId = new long[1] ;
         T002P2_A824CapacidadProductivaAuxProfId = new string[] {""} ;
         T002P2_A825CapacidadProductivaAuxDepId = new long[1] ;
         T002P2_A835CapacidadProductivaAuxRubroId = new long[1] ;
         T002P2_A834CapacidadProductivaAuxDepNombr = new string[] {""} ;
         T002P2_A821CapacidadProductivaAuxCant = new long[1] ;
         T002P2_A826CapacidadProductivaAuxPorcent = new decimal[1] ;
         T002P2_A808CapacidadProductivaAuxHoras = new decimal[1] ;
         T002P8_A820CapacidadProductivaAuxId = new long[1] ;
         T002P11_A820CapacidadProductivaAuxId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ824CapacidadProductivaAuxProfId = "";
         ZZ834CapacidadProductivaAuxDepNombr = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.capacidadproductivaaux__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.capacidadproductivaaux__default(),
            new Object[][] {
                new Object[] {
               T002P2_A820CapacidadProductivaAuxId, T002P2_A824CapacidadProductivaAuxProfId, T002P2_A825CapacidadProductivaAuxDepId, T002P2_A835CapacidadProductivaAuxRubroId, T002P2_A834CapacidadProductivaAuxDepNombr, T002P2_A821CapacidadProductivaAuxCant, T002P2_A826CapacidadProductivaAuxPorcent, T002P2_A808CapacidadProductivaAuxHoras
               }
               , new Object[] {
               T002P3_A820CapacidadProductivaAuxId, T002P3_A824CapacidadProductivaAuxProfId, T002P3_A825CapacidadProductivaAuxDepId, T002P3_A835CapacidadProductivaAuxRubroId, T002P3_A834CapacidadProductivaAuxDepNombr, T002P3_A821CapacidadProductivaAuxCant, T002P3_A826CapacidadProductivaAuxPorcent, T002P3_A808CapacidadProductivaAuxHoras
               }
               , new Object[] {
               T002P4_A820CapacidadProductivaAuxId, T002P4_A824CapacidadProductivaAuxProfId, T002P4_A825CapacidadProductivaAuxDepId, T002P4_A835CapacidadProductivaAuxRubroId, T002P4_A834CapacidadProductivaAuxDepNombr, T002P4_A821CapacidadProductivaAuxCant, T002P4_A826CapacidadProductivaAuxPorcent, T002P4_A808CapacidadProductivaAuxHoras
               }
               , new Object[] {
               T002P5_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               T002P6_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               T002P7_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               T002P8_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002P11_A820CapacidadProductivaAuxId
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound123 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCapacidadProductivaAuxId_Enabled ;
      private int edtCapacidadProductivaAuxProfId_Enabled ;
      private int edtCapacidadProductivaAuxDepId_Enabled ;
      private int edtCapacidadProductivaAuxRubroId_Enabled ;
      private int edtCapacidadProductivaAuxDepNombr_Enabled ;
      private int edtCapacidadProductivaAuxCant_Enabled ;
      private int edtCapacidadProductivaAuxPorcent_Enabled ;
      private int edtCapacidadProductivaAuxHoras_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z820CapacidadProductivaAuxId ;
      private long Z825CapacidadProductivaAuxDepId ;
      private long Z835CapacidadProductivaAuxRubroId ;
      private long Z821CapacidadProductivaAuxCant ;
      private long A820CapacidadProductivaAuxId ;
      private long A825CapacidadProductivaAuxDepId ;
      private long A835CapacidadProductivaAuxRubroId ;
      private long A821CapacidadProductivaAuxCant ;
      private long ZZ820CapacidadProductivaAuxId ;
      private long ZZ825CapacidadProductivaAuxDepId ;
      private long ZZ835CapacidadProductivaAuxRubroId ;
      private long ZZ821CapacidadProductivaAuxCant ;
      private decimal Z826CapacidadProductivaAuxPorcent ;
      private decimal Z808CapacidadProductivaAuxHoras ;
      private decimal A826CapacidadProductivaAuxPorcent ;
      private decimal A808CapacidadProductivaAuxHoras ;
      private decimal ZZ826CapacidadProductivaAuxPorcent ;
      private decimal ZZ808CapacidadProductivaAuxHoras ;
      private string sPrefix ;
      private string Z824CapacidadProductivaAuxProfId ;
      private string Z834CapacidadProductivaAuxDepNombr ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCapacidadProductivaAuxId_Internalname ;
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
      private string edtCapacidadProductivaAuxId_Jsonclick ;
      private string edtCapacidadProductivaAuxProfId_Internalname ;
      private string A824CapacidadProductivaAuxProfId ;
      private string edtCapacidadProductivaAuxProfId_Jsonclick ;
      private string edtCapacidadProductivaAuxDepId_Internalname ;
      private string edtCapacidadProductivaAuxDepId_Jsonclick ;
      private string edtCapacidadProductivaAuxRubroId_Internalname ;
      private string edtCapacidadProductivaAuxRubroId_Jsonclick ;
      private string edtCapacidadProductivaAuxDepNombr_Internalname ;
      private string A834CapacidadProductivaAuxDepNombr ;
      private string edtCapacidadProductivaAuxDepNombr_Jsonclick ;
      private string edtCapacidadProductivaAuxCant_Internalname ;
      private string edtCapacidadProductivaAuxCant_Jsonclick ;
      private string edtCapacidadProductivaAuxPorcent_Internalname ;
      private string edtCapacidadProductivaAuxPorcent_Jsonclick ;
      private string edtCapacidadProductivaAuxHoras_Internalname ;
      private string edtCapacidadProductivaAuxHoras_Jsonclick ;
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
      private string sMode123 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ824CapacidadProductivaAuxProfId ;
      private string ZZ834CapacidadProductivaAuxDepNombr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T002P4_A820CapacidadProductivaAuxId ;
      private string[] T002P4_A824CapacidadProductivaAuxProfId ;
      private long[] T002P4_A825CapacidadProductivaAuxDepId ;
      private long[] T002P4_A835CapacidadProductivaAuxRubroId ;
      private string[] T002P4_A834CapacidadProductivaAuxDepNombr ;
      private long[] T002P4_A821CapacidadProductivaAuxCant ;
      private decimal[] T002P4_A826CapacidadProductivaAuxPorcent ;
      private decimal[] T002P4_A808CapacidadProductivaAuxHoras ;
      private long[] T002P5_A820CapacidadProductivaAuxId ;
      private long[] T002P3_A820CapacidadProductivaAuxId ;
      private string[] T002P3_A824CapacidadProductivaAuxProfId ;
      private long[] T002P3_A825CapacidadProductivaAuxDepId ;
      private long[] T002P3_A835CapacidadProductivaAuxRubroId ;
      private string[] T002P3_A834CapacidadProductivaAuxDepNombr ;
      private long[] T002P3_A821CapacidadProductivaAuxCant ;
      private decimal[] T002P3_A826CapacidadProductivaAuxPorcent ;
      private decimal[] T002P3_A808CapacidadProductivaAuxHoras ;
      private long[] T002P6_A820CapacidadProductivaAuxId ;
      private long[] T002P7_A820CapacidadProductivaAuxId ;
      private long[] T002P2_A820CapacidadProductivaAuxId ;
      private string[] T002P2_A824CapacidadProductivaAuxProfId ;
      private long[] T002P2_A825CapacidadProductivaAuxDepId ;
      private long[] T002P2_A835CapacidadProductivaAuxRubroId ;
      private string[] T002P2_A834CapacidadProductivaAuxDepNombr ;
      private long[] T002P2_A821CapacidadProductivaAuxCant ;
      private decimal[] T002P2_A826CapacidadProductivaAuxPorcent ;
      private decimal[] T002P2_A808CapacidadProductivaAuxHoras ;
      private long[] T002P8_A820CapacidadProductivaAuxId ;
      private long[] T002P11_A820CapacidadProductivaAuxId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class capacidadproductivaaux__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class capacidadproductivaaux__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002P2;
        prmT002P2 = new Object[] {
        new ParDef("@CapacidadProductivaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002P3;
        prmT002P3 = new Object[] {
        new ParDef("@CapacidadProductivaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002P4;
        prmT002P4 = new Object[] {
        new ParDef("@CapacidadProductivaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002P5;
        prmT002P5 = new Object[] {
        new ParDef("@CapacidadProductivaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002P6;
        prmT002P6 = new Object[] {
        new ParDef("@CapacidadProductivaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002P7;
        prmT002P7 = new Object[] {
        new ParDef("@CapacidadProductivaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002P8;
        prmT002P8 = new Object[] {
        new ParDef("@CapacidadProductivaAuxProfId",GXType.NChar,20,0) ,
        new ParDef("@CapacidadProductivaAuxDepId",GXType.Decimal,18,0) ,
        new ParDef("@CapacidadProductivaAuxRubroId",GXType.Decimal,18,0) ,
        new ParDef("@CapacidadProductivaAuxDepNombr",GXType.NChar,80,0) ,
        new ParDef("@CapacidadProductivaAuxCant",GXType.Decimal,12,0) ,
        new ParDef("@CapacidadProductivaAuxPorcent",GXType.Decimal,6,2) ,
        new ParDef("@CapacidadProductivaAuxHoras",GXType.Decimal,18,2)
        };
        Object[] prmT002P9;
        prmT002P9 = new Object[] {
        new ParDef("@CapacidadProductivaAuxProfId",GXType.NChar,20,0) ,
        new ParDef("@CapacidadProductivaAuxDepId",GXType.Decimal,18,0) ,
        new ParDef("@CapacidadProductivaAuxRubroId",GXType.Decimal,18,0) ,
        new ParDef("@CapacidadProductivaAuxDepNombr",GXType.NChar,80,0) ,
        new ParDef("@CapacidadProductivaAuxCant",GXType.Decimal,12,0) ,
        new ParDef("@CapacidadProductivaAuxPorcent",GXType.Decimal,6,2) ,
        new ParDef("@CapacidadProductivaAuxHoras",GXType.Decimal,18,2) ,
        new ParDef("@CapacidadProductivaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002P10;
        prmT002P10 = new Object[] {
        new ParDef("@CapacidadProductivaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002P11;
        prmT002P11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T002P2", "SELECT [CapacidadProductivaAuxId], [CapacidadProductivaAuxProfId], [CapacidadProductivaAuxDepId], [CapacidadProductivaAuxRubroId], [CapacidadProductivaAuxDepNombr], [CapacidadProductivaAuxCant], [CapacidadProductivaAuxPorcent], [CapacidadProductivaAuxHoras] FROM [CapacidadProductivaAux] WITH (UPDLOCK) WHERE [CapacidadProductivaAuxId] = @CapacidadProductivaAuxId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P3", "SELECT [CapacidadProductivaAuxId], [CapacidadProductivaAuxProfId], [CapacidadProductivaAuxDepId], [CapacidadProductivaAuxRubroId], [CapacidadProductivaAuxDepNombr], [CapacidadProductivaAuxCant], [CapacidadProductivaAuxPorcent], [CapacidadProductivaAuxHoras] FROM [CapacidadProductivaAux] WHERE [CapacidadProductivaAuxId] = @CapacidadProductivaAuxId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P4", "SELECT TM1.[CapacidadProductivaAuxId], TM1.[CapacidadProductivaAuxProfId], TM1.[CapacidadProductivaAuxDepId], TM1.[CapacidadProductivaAuxRubroId], TM1.[CapacidadProductivaAuxDepNombr], TM1.[CapacidadProductivaAuxCant], TM1.[CapacidadProductivaAuxPorcent], TM1.[CapacidadProductivaAuxHoras] FROM [CapacidadProductivaAux] TM1 WHERE TM1.[CapacidadProductivaAuxId] = @CapacidadProductivaAuxId ORDER BY TM1.[CapacidadProductivaAuxId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002P4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P5", "SELECT [CapacidadProductivaAuxId] FROM [CapacidadProductivaAux] WHERE [CapacidadProductivaAuxId] = @CapacidadProductivaAuxId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002P5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P6", "SELECT TOP 1 [CapacidadProductivaAuxId] FROM [CapacidadProductivaAux] WHERE ( [CapacidadProductivaAuxId] > @CapacidadProductivaAuxId) ORDER BY [CapacidadProductivaAuxId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002P6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002P7", "SELECT TOP 1 [CapacidadProductivaAuxId] FROM [CapacidadProductivaAux] WHERE ( [CapacidadProductivaAuxId] < @CapacidadProductivaAuxId) ORDER BY [CapacidadProductivaAuxId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002P7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002P8", "INSERT INTO [CapacidadProductivaAux]([CapacidadProductivaAuxProfId], [CapacidadProductivaAuxDepId], [CapacidadProductivaAuxRubroId], [CapacidadProductivaAuxDepNombr], [CapacidadProductivaAuxCant], [CapacidadProductivaAuxPorcent], [CapacidadProductivaAuxHoras]) VALUES(@CapacidadProductivaAuxProfId, @CapacidadProductivaAuxDepId, @CapacidadProductivaAuxRubroId, @CapacidadProductivaAuxDepNombr, @CapacidadProductivaAuxCant, @CapacidadProductivaAuxPorcent, @CapacidadProductivaAuxHoras); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT002P8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002P9", "UPDATE [CapacidadProductivaAux] SET [CapacidadProductivaAuxProfId]=@CapacidadProductivaAuxProfId, [CapacidadProductivaAuxDepId]=@CapacidadProductivaAuxDepId, [CapacidadProductivaAuxRubroId]=@CapacidadProductivaAuxRubroId, [CapacidadProductivaAuxDepNombr]=@CapacidadProductivaAuxDepNombr, [CapacidadProductivaAuxCant]=@CapacidadProductivaAuxCant, [CapacidadProductivaAuxPorcent]=@CapacidadProductivaAuxPorcent, [CapacidadProductivaAuxHoras]=@CapacidadProductivaAuxHoras  WHERE [CapacidadProductivaAuxId] = @CapacidadProductivaAuxId", GxErrorMask.GX_NOMASK,prmT002P9)
           ,new CursorDef("T002P10", "DELETE FROM [CapacidadProductivaAux]  WHERE [CapacidadProductivaAuxId] = @CapacidadProductivaAuxId", GxErrorMask.GX_NOMASK,prmT002P10)
           ,new CursorDef("T002P11", "SELECT [CapacidadProductivaAuxId] FROM [CapacidadProductivaAux] ORDER BY [CapacidadProductivaAuxId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002P11,100, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
