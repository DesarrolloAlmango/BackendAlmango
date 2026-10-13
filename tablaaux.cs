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
   public class tablaaux : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         Form.Meta.addItem("description", context.GetMessage( "Tabla Aux", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTablaAuxId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tablaaux( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tablaaux( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Tabla Aux", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_TablaAux.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TablaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TablaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TablaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TablaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx03g0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TABLAAUXID"+"'), id:'"+"TABLAAUXID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TablaAux.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTablaAuxId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTablaAuxId_Internalname, context.GetMessage( "Aux Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTablaAuxId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A830TablaAuxId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtTablaAuxId_Enabled!=0) ? context.localUtil.Format( (decimal)(A830TablaAuxId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A830TablaAuxId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTablaAuxId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTablaAuxId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_TablaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTablaAuxDepartamentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTablaAuxDepartamentoId_Internalname, context.GetMessage( "Departamento Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTablaAuxDepartamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A831TablaAuxDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtTablaAuxDepartamentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A831TablaAuxDepartamentoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A831TablaAuxDepartamentoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTablaAuxDepartamentoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTablaAuxDepartamentoId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_TablaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTablaAuxDepartamentoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTablaAuxDepartamentoNombre_Internalname, context.GetMessage( "Departamento Nombre", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTablaAuxDepartamentoNombre_Internalname, StringUtil.RTrim( A832TablaAuxDepartamentoNombre), StringUtil.RTrim( context.localUtil.Format( A832TablaAuxDepartamentoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTablaAuxDepartamentoNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTablaAuxDepartamentoNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_TablaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTablaAuxCapacidadProd_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTablaAuxCapacidadProd_Internalname, context.GetMessage( "Capacidad Prod", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTablaAuxCapacidadProd_Internalname, StringUtil.LTrim( StringUtil.NToC( A833TablaAuxCapacidadProd, 22, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtTablaAuxCapacidadProd_Enabled!=0) ? context.localUtil.Format( A833TablaAuxCapacidadProd, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A833TablaAuxCapacidadProd, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTablaAuxCapacidadProd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTablaAuxCapacidadProd_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "Total", "end", false, "", "HLP_TablaAux.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TablaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TablaAux.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TablaAux.htm");
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
            Z830TablaAuxId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z830TablaAuxId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z831TablaAuxDepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z831TablaAuxDepartamentoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z832TablaAuxDepartamentoNombre = cgiGet( "Z832TablaAuxDepartamentoNombre");
            Z833TablaAuxCapacidadProd = context.localUtil.CToN( cgiGet( "Z833TablaAuxCapacidadProd"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTablaAuxId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTablaAuxId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TABLAAUXID");
               AnyError = 1;
               GX_FocusControl = edtTablaAuxId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A830TablaAuxId = 0;
               AssignAttri("", false, "A830TablaAuxId", StringUtil.LTrimStr( (decimal)(A830TablaAuxId), 18, 0));
            }
            else
            {
               A830TablaAuxId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTablaAuxId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A830TablaAuxId", StringUtil.LTrimStr( (decimal)(A830TablaAuxId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTablaAuxDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTablaAuxDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TABLAAUXDEPARTAMENTOID");
               AnyError = 1;
               GX_FocusControl = edtTablaAuxDepartamentoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A831TablaAuxDepartamentoId = 0;
               AssignAttri("", false, "A831TablaAuxDepartamentoId", StringUtil.LTrimStr( (decimal)(A831TablaAuxDepartamentoId), 18, 0));
            }
            else
            {
               A831TablaAuxDepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTablaAuxDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A831TablaAuxDepartamentoId", StringUtil.LTrimStr( (decimal)(A831TablaAuxDepartamentoId), 18, 0));
            }
            A832TablaAuxDepartamentoNombre = cgiGet( edtTablaAuxDepartamentoNombre_Internalname);
            AssignAttri("", false, "A832TablaAuxDepartamentoNombre", A832TablaAuxDepartamentoNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTablaAuxCapacidadProd_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTablaAuxCapacidadProd_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TABLAAUXCAPACIDADPROD");
               AnyError = 1;
               GX_FocusControl = edtTablaAuxCapacidadProd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A833TablaAuxCapacidadProd = 0;
               AssignAttri("", false, "A833TablaAuxCapacidadProd", StringUtil.LTrimStr( A833TablaAuxCapacidadProd, 18, 2));
            }
            else
            {
               A833TablaAuxCapacidadProd = context.localUtil.CToN( cgiGet( edtTablaAuxCapacidadProd_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A833TablaAuxCapacidadProd", StringUtil.LTrimStr( A833TablaAuxCapacidadProd, 18, 2));
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
               A830TablaAuxId = (long)(Math.Round(NumberUtil.Val( GetPar( "TablaAuxId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A830TablaAuxId", StringUtil.LTrimStr( (decimal)(A830TablaAuxId), 18, 0));
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
               InitAll2Q124( ) ;
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
         DisableAttributes2Q124( ) ;
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

      protected void ResetCaption2Q0( )
      {
      }

      protected void ZM2Q124( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z831TablaAuxDepartamentoId = T002Q3_A831TablaAuxDepartamentoId[0];
               Z832TablaAuxDepartamentoNombre = T002Q3_A832TablaAuxDepartamentoNombre[0];
               Z833TablaAuxCapacidadProd = T002Q3_A833TablaAuxCapacidadProd[0];
            }
            else
            {
               Z831TablaAuxDepartamentoId = A831TablaAuxDepartamentoId;
               Z832TablaAuxDepartamentoNombre = A832TablaAuxDepartamentoNombre;
               Z833TablaAuxCapacidadProd = A833TablaAuxCapacidadProd;
            }
         }
         if ( GX_JID == -1 )
         {
            Z830TablaAuxId = A830TablaAuxId;
            Z831TablaAuxDepartamentoId = A831TablaAuxDepartamentoId;
            Z832TablaAuxDepartamentoNombre = A832TablaAuxDepartamentoNombre;
            Z833TablaAuxCapacidadProd = A833TablaAuxCapacidadProd;
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

      protected void Load2Q124( )
      {
         /* Using cursor T002Q4 */
         pr_default.execute(2, new Object[] {A830TablaAuxId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound124 = 1;
            A831TablaAuxDepartamentoId = T002Q4_A831TablaAuxDepartamentoId[0];
            AssignAttri("", false, "A831TablaAuxDepartamentoId", StringUtil.LTrimStr( (decimal)(A831TablaAuxDepartamentoId), 18, 0));
            A832TablaAuxDepartamentoNombre = T002Q4_A832TablaAuxDepartamentoNombre[0];
            AssignAttri("", false, "A832TablaAuxDepartamentoNombre", A832TablaAuxDepartamentoNombre);
            A833TablaAuxCapacidadProd = T002Q4_A833TablaAuxCapacidadProd[0];
            AssignAttri("", false, "A833TablaAuxCapacidadProd", StringUtil.LTrimStr( A833TablaAuxCapacidadProd, 18, 2));
            ZM2Q124( -1) ;
         }
         pr_default.close(2);
         OnLoadActions2Q124( ) ;
      }

      protected void OnLoadActions2Q124( )
      {
      }

      protected void CheckExtendedTable2Q124( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors2Q124( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2Q124( )
      {
         /* Using cursor T002Q5 */
         pr_default.execute(3, new Object[] {A830TablaAuxId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound124 = 1;
         }
         else
         {
            RcdFound124 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002Q3 */
         pr_default.execute(1, new Object[] {A830TablaAuxId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2Q124( 1) ;
            RcdFound124 = 1;
            A830TablaAuxId = T002Q3_A830TablaAuxId[0];
            AssignAttri("", false, "A830TablaAuxId", StringUtil.LTrimStr( (decimal)(A830TablaAuxId), 18, 0));
            A831TablaAuxDepartamentoId = T002Q3_A831TablaAuxDepartamentoId[0];
            AssignAttri("", false, "A831TablaAuxDepartamentoId", StringUtil.LTrimStr( (decimal)(A831TablaAuxDepartamentoId), 18, 0));
            A832TablaAuxDepartamentoNombre = T002Q3_A832TablaAuxDepartamentoNombre[0];
            AssignAttri("", false, "A832TablaAuxDepartamentoNombre", A832TablaAuxDepartamentoNombre);
            A833TablaAuxCapacidadProd = T002Q3_A833TablaAuxCapacidadProd[0];
            AssignAttri("", false, "A833TablaAuxCapacidadProd", StringUtil.LTrimStr( A833TablaAuxCapacidadProd, 18, 2));
            Z830TablaAuxId = A830TablaAuxId;
            sMode124 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2Q124( ) ;
            if ( AnyError == 1 )
            {
               RcdFound124 = 0;
               InitializeNonKey2Q124( ) ;
            }
            Gx_mode = sMode124;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound124 = 0;
            InitializeNonKey2Q124( ) ;
            sMode124 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode124;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2Q124( ) ;
         if ( RcdFound124 == 0 )
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
         RcdFound124 = 0;
         /* Using cursor T002Q6 */
         pr_default.execute(4, new Object[] {A830TablaAuxId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T002Q6_A830TablaAuxId[0] < A830TablaAuxId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T002Q6_A830TablaAuxId[0] > A830TablaAuxId ) ) )
            {
               A830TablaAuxId = T002Q6_A830TablaAuxId[0];
               AssignAttri("", false, "A830TablaAuxId", StringUtil.LTrimStr( (decimal)(A830TablaAuxId), 18, 0));
               RcdFound124 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound124 = 0;
         /* Using cursor T002Q7 */
         pr_default.execute(5, new Object[] {A830TablaAuxId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T002Q7_A830TablaAuxId[0] > A830TablaAuxId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T002Q7_A830TablaAuxId[0] < A830TablaAuxId ) ) )
            {
               A830TablaAuxId = T002Q7_A830TablaAuxId[0];
               AssignAttri("", false, "A830TablaAuxId", StringUtil.LTrimStr( (decimal)(A830TablaAuxId), 18, 0));
               RcdFound124 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2Q124( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTablaAuxId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2Q124( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound124 == 1 )
            {
               if ( A830TablaAuxId != Z830TablaAuxId )
               {
                  A830TablaAuxId = Z830TablaAuxId;
                  AssignAttri("", false, "A830TablaAuxId", StringUtil.LTrimStr( (decimal)(A830TablaAuxId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TABLAAUXID");
                  AnyError = 1;
                  GX_FocusControl = edtTablaAuxId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTablaAuxId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2Q124( ) ;
                  GX_FocusControl = edtTablaAuxId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A830TablaAuxId != Z830TablaAuxId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTablaAuxId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2Q124( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TABLAAUXID");
                     AnyError = 1;
                     GX_FocusControl = edtTablaAuxId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTablaAuxId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2Q124( ) ;
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
         if ( A830TablaAuxId != Z830TablaAuxId )
         {
            A830TablaAuxId = Z830TablaAuxId;
            AssignAttri("", false, "A830TablaAuxId", StringUtil.LTrimStr( (decimal)(A830TablaAuxId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TABLAAUXID");
            AnyError = 1;
            GX_FocusControl = edtTablaAuxId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTablaAuxId_Internalname;
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
         if ( RcdFound124 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TABLAAUXID");
            AnyError = 1;
            GX_FocusControl = edtTablaAuxId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTablaAuxDepartamentoId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2Q124( ) ;
         if ( RcdFound124 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTablaAuxDepartamentoId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2Q124( ) ;
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
         if ( RcdFound124 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTablaAuxDepartamentoId_Internalname;
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
         if ( RcdFound124 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTablaAuxDepartamentoId_Internalname;
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
         ScanStart2Q124( ) ;
         if ( RcdFound124 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound124 != 0 )
            {
               ScanNext2Q124( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTablaAuxDepartamentoId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2Q124( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2Q124( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002Q2 */
            pr_default.execute(0, new Object[] {A830TablaAuxId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TablaAux"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z831TablaAuxDepartamentoId != T002Q2_A831TablaAuxDepartamentoId[0] ) || ( StringUtil.StrCmp(Z832TablaAuxDepartamentoNombre, T002Q2_A832TablaAuxDepartamentoNombre[0]) != 0 ) || ( Z833TablaAuxCapacidadProd != T002Q2_A833TablaAuxCapacidadProd[0] ) )
            {
               if ( Z831TablaAuxDepartamentoId != T002Q2_A831TablaAuxDepartamentoId[0] )
               {
                  GXUtil.WriteLog("tablaaux:[seudo value changed for attri]"+"TablaAuxDepartamentoId");
                  GXUtil.WriteLogRaw("Old: ",Z831TablaAuxDepartamentoId);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A831TablaAuxDepartamentoId[0]);
               }
               if ( StringUtil.StrCmp(Z832TablaAuxDepartamentoNombre, T002Q2_A832TablaAuxDepartamentoNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("tablaaux:[seudo value changed for attri]"+"TablaAuxDepartamentoNombre");
                  GXUtil.WriteLogRaw("Old: ",Z832TablaAuxDepartamentoNombre);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A832TablaAuxDepartamentoNombre[0]);
               }
               if ( Z833TablaAuxCapacidadProd != T002Q2_A833TablaAuxCapacidadProd[0] )
               {
                  GXUtil.WriteLog("tablaaux:[seudo value changed for attri]"+"TablaAuxCapacidadProd");
                  GXUtil.WriteLogRaw("Old: ",Z833TablaAuxCapacidadProd);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A833TablaAuxCapacidadProd[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TablaAux"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2Q124( )
      {
         BeforeValidate2Q124( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Q124( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2Q124( 0) ;
            CheckOptimisticConcurrency2Q124( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Q124( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2Q124( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Q8 */
                     pr_default.execute(6, new Object[] {A831TablaAuxDepartamentoId, A832TablaAuxDepartamentoNombre, A833TablaAuxCapacidadProd});
                     A830TablaAuxId = T002Q8_A830TablaAuxId[0];
                     AssignAttri("", false, "A830TablaAuxId", StringUtil.LTrimStr( (decimal)(A830TablaAuxId), 18, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("TablaAux");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2Q0( ) ;
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
               Load2Q124( ) ;
            }
            EndLevel2Q124( ) ;
         }
         CloseExtendedTableCursors2Q124( ) ;
      }

      protected void Update2Q124( )
      {
         BeforeValidate2Q124( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Q124( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Q124( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Q124( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2Q124( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Q9 */
                     pr_default.execute(7, new Object[] {A831TablaAuxDepartamentoId, A832TablaAuxDepartamentoNombre, A833TablaAuxCapacidadProd, A830TablaAuxId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("TablaAux");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TablaAux"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2Q124( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2Q0( ) ;
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
            EndLevel2Q124( ) ;
         }
         CloseExtendedTableCursors2Q124( ) ;
      }

      protected void DeferredUpdate2Q124( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2Q124( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Q124( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2Q124( ) ;
            AfterConfirm2Q124( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2Q124( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002Q10 */
                  pr_default.execute(8, new Object[] {A830TablaAuxId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("TablaAux");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound124 == 0 )
                        {
                           InitAll2Q124( ) ;
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
                        ResetCaption2Q0( ) ;
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
         sMode124 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2Q124( ) ;
         Gx_mode = sMode124;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2Q124( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2Q124( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2Q124( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tablaaux",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2Q0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tablaaux",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2Q124( )
      {
         /* Using cursor T002Q11 */
         pr_default.execute(9);
         RcdFound124 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound124 = 1;
            A830TablaAuxId = T002Q11_A830TablaAuxId[0];
            AssignAttri("", false, "A830TablaAuxId", StringUtil.LTrimStr( (decimal)(A830TablaAuxId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2Q124( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound124 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound124 = 1;
            A830TablaAuxId = T002Q11_A830TablaAuxId[0];
            AssignAttri("", false, "A830TablaAuxId", StringUtil.LTrimStr( (decimal)(A830TablaAuxId), 18, 0));
         }
      }

      protected void ScanEnd2Q124( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm2Q124( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2Q124( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2Q124( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2Q124( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2Q124( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2Q124( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2Q124( )
      {
         edtTablaAuxId_Enabled = 0;
         AssignProp("", false, edtTablaAuxId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTablaAuxId_Enabled), 5, 0), true);
         edtTablaAuxDepartamentoId_Enabled = 0;
         AssignProp("", false, edtTablaAuxDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTablaAuxDepartamentoId_Enabled), 5, 0), true);
         edtTablaAuxDepartamentoNombre_Enabled = 0;
         AssignProp("", false, edtTablaAuxDepartamentoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTablaAuxDepartamentoNombre_Enabled), 5, 0), true);
         edtTablaAuxCapacidadProd_Enabled = 0;
         AssignProp("", false, edtTablaAuxCapacidadProd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTablaAuxCapacidadProd_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2Q124( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2Q0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tablaaux.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z830TablaAuxId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z830TablaAuxId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z831TablaAuxDepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z831TablaAuxDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z832TablaAuxDepartamentoNombre", StringUtil.RTrim( Z832TablaAuxDepartamentoNombre));
         GxWebStd.gx_hidden_field( context, "Z833TablaAuxCapacidadProd", StringUtil.LTrim( StringUtil.NToC( Z833TablaAuxCapacidadProd, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("tablaaux.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TablaAux" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Tabla Aux", "") ;
      }

      protected void InitializeNonKey2Q124( )
      {
         A831TablaAuxDepartamentoId = 0;
         AssignAttri("", false, "A831TablaAuxDepartamentoId", StringUtil.LTrimStr( (decimal)(A831TablaAuxDepartamentoId), 18, 0));
         A832TablaAuxDepartamentoNombre = "";
         AssignAttri("", false, "A832TablaAuxDepartamentoNombre", A832TablaAuxDepartamentoNombre);
         A833TablaAuxCapacidadProd = 0;
         AssignAttri("", false, "A833TablaAuxCapacidadProd", StringUtil.LTrimStr( A833TablaAuxCapacidadProd, 18, 2));
         Z831TablaAuxDepartamentoId = 0;
         Z832TablaAuxDepartamentoNombre = "";
         Z833TablaAuxCapacidadProd = 0;
      }

      protected void InitAll2Q124( )
      {
         A830TablaAuxId = 0;
         AssignAttri("", false, "A830TablaAuxId", StringUtil.LTrimStr( (decimal)(A830TablaAuxId), 18, 0));
         InitializeNonKey2Q124( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302116404", true, true, false);
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
         context.AddJavascriptSource("tablaaux.js", "?20267302116404", false, true, false);
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
         edtTablaAuxId_Internalname = "TABLAAUXID";
         edtTablaAuxDepartamentoId_Internalname = "TABLAAUXDEPARTAMENTOID";
         edtTablaAuxDepartamentoNombre_Internalname = "TABLAAUXDEPARTAMENTONOMBRE";
         edtTablaAuxCapacidadProd_Internalname = "TABLAAUXCAPACIDADPROD";
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
         Form.Caption = context.GetMessage( "Tabla Aux", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTablaAuxCapacidadProd_Jsonclick = "";
         edtTablaAuxCapacidadProd_Enabled = 1;
         edtTablaAuxDepartamentoNombre_Jsonclick = "";
         edtTablaAuxDepartamentoNombre_Enabled = 1;
         edtTablaAuxDepartamentoId_Jsonclick = "";
         edtTablaAuxDepartamentoId_Enabled = 1;
         edtTablaAuxId_Jsonclick = "";
         edtTablaAuxId_Enabled = 1;
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
         GX_FocusControl = edtTablaAuxDepartamentoId_Internalname;
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

      public void Valid_Tablaauxid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A831TablaAuxDepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A831TablaAuxDepartamentoId), 18, 0, ".", "")));
         AssignAttri("", false, "A832TablaAuxDepartamentoNombre", StringUtil.RTrim( A832TablaAuxDepartamentoNombre));
         AssignAttri("", false, "A833TablaAuxCapacidadProd", StringUtil.LTrim( StringUtil.NToC( A833TablaAuxCapacidadProd, 18, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z830TablaAuxId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z830TablaAuxId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z831TablaAuxDepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z831TablaAuxDepartamentoId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z832TablaAuxDepartamentoNombre", StringUtil.RTrim( Z832TablaAuxDepartamentoNombre));
         GxWebStd.gx_hidden_field( context, "Z833TablaAuxCapacidadProd", StringUtil.LTrim( StringUtil.NToC( Z833TablaAuxCapacidadProd, 18, 2, ".", "")));
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
         setEventMetadata("VALID_TABLAAUXID","{handler:'Valid_Tablaauxid',iparms:[{av:'A830TablaAuxId',fld:'TABLAAUXID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'}]");
         setEventMetadata("VALID_TABLAAUXID",",oparms:[{av:'A831TablaAuxDepartamentoId',fld:'TABLAAUXDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A832TablaAuxDepartamentoNombre',fld:'TABLAAUXDEPARTAMENTONOMBRE',pic:'',type:'char'},{av:'A833TablaAuxCapacidadProd',fld:'TABLAAUXCAPACIDADPROD',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z830TablaAuxId',type:'int'},{av:'Z831TablaAuxDepartamentoId',type:'int'},{av:'Z832TablaAuxDepartamentoNombre',type:'char'},{av:'Z833TablaAuxCapacidadProd',type:'decimal'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z832TablaAuxDepartamentoNombre = "";
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
         A832TablaAuxDepartamentoNombre = "";
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
         T002Q4_A830TablaAuxId = new long[1] ;
         T002Q4_A831TablaAuxDepartamentoId = new long[1] ;
         T002Q4_A832TablaAuxDepartamentoNombre = new string[] {""} ;
         T002Q4_A833TablaAuxCapacidadProd = new decimal[1] ;
         T002Q5_A830TablaAuxId = new long[1] ;
         T002Q3_A830TablaAuxId = new long[1] ;
         T002Q3_A831TablaAuxDepartamentoId = new long[1] ;
         T002Q3_A832TablaAuxDepartamentoNombre = new string[] {""} ;
         T002Q3_A833TablaAuxCapacidadProd = new decimal[1] ;
         sMode124 = "";
         T002Q6_A830TablaAuxId = new long[1] ;
         T002Q7_A830TablaAuxId = new long[1] ;
         T002Q2_A830TablaAuxId = new long[1] ;
         T002Q2_A831TablaAuxDepartamentoId = new long[1] ;
         T002Q2_A832TablaAuxDepartamentoNombre = new string[] {""} ;
         T002Q2_A833TablaAuxCapacidadProd = new decimal[1] ;
         T002Q8_A830TablaAuxId = new long[1] ;
         T002Q11_A830TablaAuxId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ832TablaAuxDepartamentoNombre = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.tablaaux__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tablaaux__default(),
            new Object[][] {
                new Object[] {
               T002Q2_A830TablaAuxId, T002Q2_A831TablaAuxDepartamentoId, T002Q2_A832TablaAuxDepartamentoNombre, T002Q2_A833TablaAuxCapacidadProd
               }
               , new Object[] {
               T002Q3_A830TablaAuxId, T002Q3_A831TablaAuxDepartamentoId, T002Q3_A832TablaAuxDepartamentoNombre, T002Q3_A833TablaAuxCapacidadProd
               }
               , new Object[] {
               T002Q4_A830TablaAuxId, T002Q4_A831TablaAuxDepartamentoId, T002Q4_A832TablaAuxDepartamentoNombre, T002Q4_A833TablaAuxCapacidadProd
               }
               , new Object[] {
               T002Q5_A830TablaAuxId
               }
               , new Object[] {
               T002Q6_A830TablaAuxId
               }
               , new Object[] {
               T002Q7_A830TablaAuxId
               }
               , new Object[] {
               T002Q8_A830TablaAuxId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002Q11_A830TablaAuxId
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound124 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTablaAuxId_Enabled ;
      private int edtTablaAuxDepartamentoId_Enabled ;
      private int edtTablaAuxDepartamentoNombre_Enabled ;
      private int edtTablaAuxCapacidadProd_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z830TablaAuxId ;
      private long Z831TablaAuxDepartamentoId ;
      private long A830TablaAuxId ;
      private long A831TablaAuxDepartamentoId ;
      private long ZZ830TablaAuxId ;
      private long ZZ831TablaAuxDepartamentoId ;
      private decimal Z833TablaAuxCapacidadProd ;
      private decimal A833TablaAuxCapacidadProd ;
      private decimal ZZ833TablaAuxCapacidadProd ;
      private string sPrefix ;
      private string Z832TablaAuxDepartamentoNombre ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTablaAuxId_Internalname ;
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
      private string edtTablaAuxId_Jsonclick ;
      private string edtTablaAuxDepartamentoId_Internalname ;
      private string edtTablaAuxDepartamentoId_Jsonclick ;
      private string edtTablaAuxDepartamentoNombre_Internalname ;
      private string A832TablaAuxDepartamentoNombre ;
      private string edtTablaAuxDepartamentoNombre_Jsonclick ;
      private string edtTablaAuxCapacidadProd_Internalname ;
      private string edtTablaAuxCapacidadProd_Jsonclick ;
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
      private string sMode124 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ832TablaAuxDepartamentoNombre ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T002Q4_A830TablaAuxId ;
      private long[] T002Q4_A831TablaAuxDepartamentoId ;
      private string[] T002Q4_A832TablaAuxDepartamentoNombre ;
      private decimal[] T002Q4_A833TablaAuxCapacidadProd ;
      private long[] T002Q5_A830TablaAuxId ;
      private long[] T002Q3_A830TablaAuxId ;
      private long[] T002Q3_A831TablaAuxDepartamentoId ;
      private string[] T002Q3_A832TablaAuxDepartamentoNombre ;
      private decimal[] T002Q3_A833TablaAuxCapacidadProd ;
      private long[] T002Q6_A830TablaAuxId ;
      private long[] T002Q7_A830TablaAuxId ;
      private long[] T002Q2_A830TablaAuxId ;
      private long[] T002Q2_A831TablaAuxDepartamentoId ;
      private string[] T002Q2_A832TablaAuxDepartamentoNombre ;
      private decimal[] T002Q2_A833TablaAuxCapacidadProd ;
      private long[] T002Q8_A830TablaAuxId ;
      private long[] T002Q11_A830TablaAuxId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class tablaaux__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class tablaaux__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT002Q2;
        prmT002Q2 = new Object[] {
        new ParDef("@TablaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002Q3;
        prmT002Q3 = new Object[] {
        new ParDef("@TablaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002Q4;
        prmT002Q4 = new Object[] {
        new ParDef("@TablaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002Q5;
        prmT002Q5 = new Object[] {
        new ParDef("@TablaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002Q6;
        prmT002Q6 = new Object[] {
        new ParDef("@TablaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002Q7;
        prmT002Q7 = new Object[] {
        new ParDef("@TablaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002Q8;
        prmT002Q8 = new Object[] {
        new ParDef("@TablaAuxDepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@TablaAuxDepartamentoNombre",GXType.NChar,80,0) ,
        new ParDef("@TablaAuxCapacidadProd",GXType.Decimal,18,2)
        };
        Object[] prmT002Q9;
        prmT002Q9 = new Object[] {
        new ParDef("@TablaAuxDepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@TablaAuxDepartamentoNombre",GXType.NChar,80,0) ,
        new ParDef("@TablaAuxCapacidadProd",GXType.Decimal,18,2) ,
        new ParDef("@TablaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002Q10;
        prmT002Q10 = new Object[] {
        new ParDef("@TablaAuxId",GXType.Decimal,18,0)
        };
        Object[] prmT002Q11;
        prmT002Q11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T002Q2", "SELECT [TablaAuxId], [TablaAuxDepartamentoId], [TablaAuxDepartamentoNombre], [TablaAuxCapacidadProd] FROM [TablaAux] WITH (UPDLOCK) WHERE [TablaAuxId] = @TablaAuxId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Q3", "SELECT [TablaAuxId], [TablaAuxDepartamentoId], [TablaAuxDepartamentoNombre], [TablaAuxCapacidadProd] FROM [TablaAux] WHERE [TablaAuxId] = @TablaAuxId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Q4", "SELECT TM1.[TablaAuxId], TM1.[TablaAuxDepartamentoId], TM1.[TablaAuxDepartamentoNombre], TM1.[TablaAuxCapacidadProd] FROM [TablaAux] TM1 WHERE TM1.[TablaAuxId] = @TablaAuxId ORDER BY TM1.[TablaAuxId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Q5", "SELECT [TablaAuxId] FROM [TablaAux] WHERE [TablaAuxId] = @TablaAuxId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Q6", "SELECT TOP 1 [TablaAuxId] FROM [TablaAux] WHERE ( [TablaAuxId] > @TablaAuxId) ORDER BY [TablaAuxId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Q7", "SELECT TOP 1 [TablaAuxId] FROM [TablaAux] WHERE ( [TablaAuxId] < @TablaAuxId) ORDER BY [TablaAuxId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Q8", "INSERT INTO [TablaAux]([TablaAuxDepartamentoId], [TablaAuxDepartamentoNombre], [TablaAuxCapacidadProd]) VALUES(@TablaAuxDepartamentoId, @TablaAuxDepartamentoNombre, @TablaAuxCapacidadProd); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Q9", "UPDATE [TablaAux] SET [TablaAuxDepartamentoId]=@TablaAuxDepartamentoId, [TablaAuxDepartamentoNombre]=@TablaAuxDepartamentoNombre, [TablaAuxCapacidadProd]=@TablaAuxCapacidadProd  WHERE [TablaAuxId] = @TablaAuxId", GxErrorMask.GX_NOMASK,prmT002Q9)
           ,new CursorDef("T002Q10", "DELETE FROM [TablaAux]  WHERE [TablaAuxId] = @TablaAuxId", GxErrorMask.GX_NOMASK,prmT002Q10)
           ,new CursorDef("T002Q11", "SELECT [TablaAuxId] FROM [TablaAux] ORDER BY [TablaAuxId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
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
