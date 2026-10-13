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
   public class clientesdatos : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A112DepartamentoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A112DepartamentoId, A114DepartamentoMunicipioId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Clientes Datos", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtClientesNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clientesdatos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientesdatos( IGxContext context )
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
         cmbClientesEstado = new GXCombobox();
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
         if ( cmbClientesEstado.ItemCount > 0 )
         {
            A435ClientesEstado = cmbClientesEstado.getValidValue(A435ClientesEstado);
            AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbClientesEstado.CurrentValue = StringUtil.RTrim( A435ClientesEstado);
            AssignProp("", false, cmbClientesEstado_Internalname, "Values", cmbClientesEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Clientes Datos", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_ClientesDatos.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClientesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClientesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClientesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClientesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00k0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CLIENTESID"+"'), id:'"+"CLIENTESID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_ClientesDatos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientesId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClientesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106ClientesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtClientesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A106ClientesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A106ClientesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClientesId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClientesId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ClientesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientesNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClientesNombre_Internalname, StringUtil.RTrim( A160ClientesNombre), StringUtil.RTrim( context.localUtil.Format( A160ClientesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClientesNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClientesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClientesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesIdentidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientesIdentidad_Internalname, context.GetMessage( "Identidad", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClientesIdentidad_Internalname, StringUtil.RTrim( A434ClientesIdentidad), StringUtil.RTrim( context.localUtil.Format( A434ClientesIdentidad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClientesIdentidad_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClientesIdentidad_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClientesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgClientesImagen_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A164ClientesImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ClientesImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.PathToRelativeUrl( A164ClientesImagen));
         GxWebStd.gx_bitmap( context, imgClientesImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgClientesImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", "", "", 0, A164ClientesImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_ClientesDatos.htm");
         AssignProp("", false, imgClientesImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.PathToRelativeUrl( A164ClientesImagen)), true);
         AssignProp("", false, imgClientesImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A164ClientesImagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesTelefono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientesTelefono_Internalname, context.GetMessage( "Telefóno", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A161ClientesTelefono);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClientesTelefono_Internalname, StringUtil.RTrim( A161ClientesTelefono), StringUtil.RTrim( context.localUtil.Format( A161ClientesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtClientesTelefono_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClientesTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_ClientesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientesEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClientesEmail_Internalname, A162ClientesEmail, StringUtil.RTrim( context.localUtil.Format( A162ClientesEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A162ClientesEmail, "", "", "", edtClientesEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClientesEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_ClientesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesDireccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientesDireccion_Internalname, context.GetMessage( "Dirección", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtClientesDireccion_Internalname, A163ClientesDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A163ClientesDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtClientesDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ClientesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisID_Internalname, context.GetMessage( "PaisId", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.RTrim( A116PaisID), StringUtil.RTrim( context.localUtil.Format( A116PaisID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisID_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClientesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDepartamentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDepartamentoId_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDepartamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtDepartamentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDepartamentoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDepartamentoId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ClientesDatos.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_112_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_112_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_112_Internalname, sImgUrl, imgprompt_112_Link, "", "", context.GetTheme( ), imgprompt_112_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_ClientesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDepartamentoMunicipioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDepartamentoMunicipioId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDepartamentoMunicipioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtDepartamentoMunicipioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A114DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A114DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDepartamentoMunicipioId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDepartamentoMunicipioId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ClientesDatos.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_114_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_114_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_114_Internalname, sImgUrl, imgprompt_114_Link, "", "", context.GetTheme( ), imgprompt_114_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_ClientesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbClientesEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbClientesEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbClientesEstado, cmbClientesEstado_Internalname, StringUtil.RTrim( A435ClientesEstado), 1, cmbClientesEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbClientesEstado.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "", true, 0, "HLP_ClientesDatos.htm");
         cmbClientesEstado.CurrentValue = StringUtil.RTrim( A435ClientesEstado);
         AssignProp("", false, cmbClientesEstado_Internalname, "Values", (string)(cmbClientesEstado.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClientesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClientesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClientesDatos.htm");
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
            Z106ClientesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z106ClientesId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z435ClientesEstado = cgiGet( "Z435ClientesEstado");
            Z160ClientesNombre = cgiGet( "Z160ClientesNombre");
            Z434ClientesIdentidad = cgiGet( "Z434ClientesIdentidad");
            Z161ClientesTelefono = cgiGet( "Z161ClientesTelefono");
            Z162ClientesEmail = cgiGet( "Z162ClientesEmail");
            Z163ClientesDireccion = cgiGet( "Z163ClientesDireccion");
            Z112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z112DepartamentoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z114DepartamentoMunicipioId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A40000ClientesImagen_GXI = cgiGet( "CLIENTESIMAGEN_GXI");
            /* Read variables values. */
            A106ClientesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtClientesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
            A160ClientesNombre = cgiGet( edtClientesNombre_Internalname);
            AssignAttri("", false, "A160ClientesNombre", A160ClientesNombre);
            A434ClientesIdentidad = cgiGet( edtClientesIdentidad_Internalname);
            AssignAttri("", false, "A434ClientesIdentidad", A434ClientesIdentidad);
            A164ClientesImagen = cgiGet( imgClientesImagen_Internalname);
            AssignAttri("", false, "A164ClientesImagen", A164ClientesImagen);
            A161ClientesTelefono = cgiGet( edtClientesTelefono_Internalname);
            AssignAttri("", false, "A161ClientesTelefono", A161ClientesTelefono);
            A162ClientesEmail = cgiGet( edtClientesEmail_Internalname);
            AssignAttri("", false, "A162ClientesEmail", A162ClientesEmail);
            A163ClientesDireccion = cgiGet( edtClientesDireccion_Internalname);
            AssignAttri("", false, "A163ClientesDireccion", A163ClientesDireccion);
            A116PaisID = cgiGet( edtPaisID_Internalname);
            AssignAttri("", false, "A116PaisID", A116PaisID);
            if ( ( ( context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DEPARTAMENTOID");
               AnyError = 1;
               GX_FocusControl = edtDepartamentoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A112DepartamentoId = 0;
               AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            }
            else
            {
               A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DEPARTAMENTOMUNICIPIOID");
               AnyError = 1;
               GX_FocusControl = edtDepartamentoMunicipioId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A114DepartamentoMunicipioId = 0;
               AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            }
            else
            {
               A114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            }
            cmbClientesEstado.CurrentValue = cgiGet( cmbClientesEstado_Internalname);
            A435ClientesEstado = cgiGet( cmbClientesEstado_Internalname);
            AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgClientesImagen_Internalname, ref  A164ClientesImagen, ref  A40000ClientesImagen_GXI);
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
               A106ClientesId = (long)(Math.Round(NumberUtil.Val( GetPar( "ClientesId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
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
               InitAll1M20( ) ;
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
         DisableAttributes1M20( ) ;
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

      protected void ResetCaption1M0( )
      {
      }

      protected void ZM1M20( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z435ClientesEstado = T001M3_A435ClientesEstado[0];
               Z160ClientesNombre = T001M3_A160ClientesNombre[0];
               Z434ClientesIdentidad = T001M3_A434ClientesIdentidad[0];
               Z161ClientesTelefono = T001M3_A161ClientesTelefono[0];
               Z162ClientesEmail = T001M3_A162ClientesEmail[0];
               Z163ClientesDireccion = T001M3_A163ClientesDireccion[0];
               Z112DepartamentoId = T001M3_A112DepartamentoId[0];
               Z114DepartamentoMunicipioId = T001M3_A114DepartamentoMunicipioId[0];
            }
            else
            {
               Z435ClientesEstado = A435ClientesEstado;
               Z160ClientesNombre = A160ClientesNombre;
               Z434ClientesIdentidad = A434ClientesIdentidad;
               Z161ClientesTelefono = A161ClientesTelefono;
               Z162ClientesEmail = A162ClientesEmail;
               Z163ClientesDireccion = A163ClientesDireccion;
               Z112DepartamentoId = A112DepartamentoId;
               Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            }
         }
         if ( GX_JID == -6 )
         {
            Z106ClientesId = A106ClientesId;
            Z435ClientesEstado = A435ClientesEstado;
            Z160ClientesNombre = A160ClientesNombre;
            Z434ClientesIdentidad = A434ClientesIdentidad;
            Z164ClientesImagen = A164ClientesImagen;
            Z40000ClientesImagen_GXI = A40000ClientesImagen_GXI;
            Z161ClientesTelefono = A161ClientesTelefono;
            Z162ClientesEmail = A162ClientesEmail;
            Z163ClientesDireccion = A163ClientesDireccion;
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            Z116PaisID = A116PaisID;
         }
      }

      protected void standaloneNotModal( )
      {
         edtClientesId_Enabled = 0;
         AssignProp("", false, edtClientesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_112_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00l0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOID"+"'), id:'"+"DEPARTAMENTOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_114_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00m1.aspx"+"',["+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOID"+"'), id:'"+"DEPARTAMENTOID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOMUNICIPIOID"+"'), id:'"+"DEPARTAMENTOMUNICIPIOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtClientesId_Enabled = 0;
         AssignProp("", false, edtClientesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesId_Enabled), 5, 0), true);
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A435ClientesEstado = "HAB";
            AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
         }
         if ( IsIns( )  && (0==A112DepartamentoId) && ( Gx_BScreen == 0 ) )
         {
            A112DepartamentoId = 1;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T001M4 */
            pr_default.execute(2, new Object[] {A112DepartamentoId});
            A116PaisID = T001M4_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
            pr_default.close(2);
         }
      }

      protected void Load1M20( )
      {
         /* Using cursor T001M6 */
         pr_default.execute(4, new Object[] {A106ClientesId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound20 = 1;
            A435ClientesEstado = T001M6_A435ClientesEstado[0];
            AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
            A160ClientesNombre = T001M6_A160ClientesNombre[0];
            AssignAttri("", false, "A160ClientesNombre", A160ClientesNombre);
            A434ClientesIdentidad = T001M6_A434ClientesIdentidad[0];
            AssignAttri("", false, "A434ClientesIdentidad", A434ClientesIdentidad);
            A40000ClientesImagen_GXI = T001M6_A40000ClientesImagen_GXI[0];
            AssignProp("", false, imgClientesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A164ClientesImagen))), true);
            AssignProp("", false, imgClientesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A164ClientesImagen), true);
            A161ClientesTelefono = T001M6_A161ClientesTelefono[0];
            AssignAttri("", false, "A161ClientesTelefono", A161ClientesTelefono);
            A162ClientesEmail = T001M6_A162ClientesEmail[0];
            AssignAttri("", false, "A162ClientesEmail", A162ClientesEmail);
            A163ClientesDireccion = T001M6_A163ClientesDireccion[0];
            AssignAttri("", false, "A163ClientesDireccion", A163ClientesDireccion);
            A112DepartamentoId = T001M6_A112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = T001M6_A114DepartamentoMunicipioId[0];
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            A116PaisID = T001M6_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
            A164ClientesImagen = T001M6_A164ClientesImagen[0];
            AssignAttri("", false, "A164ClientesImagen", A164ClientesImagen);
            AssignProp("", false, imgClientesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A164ClientesImagen))), true);
            AssignProp("", false, imgClientesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A164ClientesImagen), true);
            ZM1M20( -6) ;
         }
         pr_default.close(4);
         OnLoadActions1M20( ) ;
      }

      protected void OnLoadActions1M20( )
      {
      }

      protected void CheckExtendedTable1M20( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A162ClientesEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "CLIENTESEMAIL");
            AnyError = 1;
            GX_FocusControl = edtClientesEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T001M4 */
         pr_default.execute(2, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A116PaisID = T001M4_A116PaisID[0];
         AssignAttri("", false, "A116PaisID", A116PaisID);
         pr_default.close(2);
         /* Using cursor T001M5 */
         pr_default.execute(3, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A435ClientesEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A435ClientesEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A435ClientesEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A435ClientesEstado, "BLO") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Clientes Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "CLIENTESESTADO");
            AnyError = 1;
            GX_FocusControl = cmbClientesEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1M20( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_7( long A112DepartamentoId )
      {
         /* Using cursor T001M7 */
         pr_default.execute(5, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A116PaisID = T001M7_A116PaisID[0];
         AssignAttri("", false, "A116PaisID", A116PaisID);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A116PaisID))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_8( long A112DepartamentoId ,
                               long A114DepartamentoMunicipioId )
      {
         /* Using cursor T001M8 */
         pr_default.execute(6, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1M20( )
      {
         /* Using cursor T001M9 */
         pr_default.execute(7, new Object[] {A106ClientesId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001M3 */
         pr_default.execute(1, new Object[] {A106ClientesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1M20( 6) ;
            RcdFound20 = 1;
            A106ClientesId = T001M3_A106ClientesId[0];
            AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
            A435ClientesEstado = T001M3_A435ClientesEstado[0];
            AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
            A160ClientesNombre = T001M3_A160ClientesNombre[0];
            AssignAttri("", false, "A160ClientesNombre", A160ClientesNombre);
            A434ClientesIdentidad = T001M3_A434ClientesIdentidad[0];
            AssignAttri("", false, "A434ClientesIdentidad", A434ClientesIdentidad);
            A40000ClientesImagen_GXI = T001M3_A40000ClientesImagen_GXI[0];
            AssignProp("", false, imgClientesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A164ClientesImagen))), true);
            AssignProp("", false, imgClientesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A164ClientesImagen), true);
            A161ClientesTelefono = T001M3_A161ClientesTelefono[0];
            AssignAttri("", false, "A161ClientesTelefono", A161ClientesTelefono);
            A162ClientesEmail = T001M3_A162ClientesEmail[0];
            AssignAttri("", false, "A162ClientesEmail", A162ClientesEmail);
            A163ClientesDireccion = T001M3_A163ClientesDireccion[0];
            AssignAttri("", false, "A163ClientesDireccion", A163ClientesDireccion);
            A112DepartamentoId = T001M3_A112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = T001M3_A114DepartamentoMunicipioId[0];
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            A164ClientesImagen = T001M3_A164ClientesImagen[0];
            AssignAttri("", false, "A164ClientesImagen", A164ClientesImagen);
            AssignProp("", false, imgClientesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A164ClientesImagen))), true);
            AssignProp("", false, imgClientesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A164ClientesImagen), true);
            Z106ClientesId = A106ClientesId;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1M20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey1M20( ) ;
            }
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey1M20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1M20( ) ;
         if ( RcdFound20 == 0 )
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
         RcdFound20 = 0;
         /* Using cursor T001M10 */
         pr_default.execute(8, new Object[] {A106ClientesId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001M10_A106ClientesId[0] < A106ClientesId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001M10_A106ClientesId[0] > A106ClientesId ) ) )
            {
               A106ClientesId = T001M10_A106ClientesId[0];
               AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
               RcdFound20 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound20 = 0;
         /* Using cursor T001M11 */
         pr_default.execute(9, new Object[] {A106ClientesId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001M11_A106ClientesId[0] > A106ClientesId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001M11_A106ClientesId[0] < A106ClientesId ) ) )
            {
               A106ClientesId = T001M11_A106ClientesId[0];
               AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
               RcdFound20 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1M20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtClientesNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1M20( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( A106ClientesId != Z106ClientesId )
               {
                  A106ClientesId = Z106ClientesId;
                  AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLIENTESID");
                  AnyError = 1;
                  GX_FocusControl = edtClientesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtClientesNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1M20( ) ;
                  GX_FocusControl = edtClientesNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A106ClientesId != Z106ClientesId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtClientesNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1M20( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLIENTESID");
                     AnyError = 1;
                     GX_FocusControl = edtClientesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtClientesNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1M20( ) ;
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
         if ( A106ClientesId != Z106ClientesId )
         {
            A106ClientesId = Z106ClientesId;
            AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLIENTESID");
            AnyError = 1;
            GX_FocusControl = edtClientesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtClientesNombre_Internalname;
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
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CLIENTESID");
            AnyError = 1;
            GX_FocusControl = edtClientesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtClientesNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1M20( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClientesNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1M20( ) ;
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
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClientesNombre_Internalname;
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
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClientesNombre_Internalname;
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
         ScanStart1M20( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound20 != 0 )
            {
               ScanNext1M20( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClientesNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1M20( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1M20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001M2 */
            pr_default.execute(0, new Object[] {A106ClientesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Clientes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z435ClientesEstado, T001M2_A435ClientesEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z160ClientesNombre, T001M2_A160ClientesNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z434ClientesIdentidad, T001M2_A434ClientesIdentidad[0]) != 0 ) || ( StringUtil.StrCmp(Z161ClientesTelefono, T001M2_A161ClientesTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z162ClientesEmail, T001M2_A162ClientesEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z163ClientesDireccion, T001M2_A163ClientesDireccion[0]) != 0 ) || ( Z112DepartamentoId != T001M2_A112DepartamentoId[0] ) || ( Z114DepartamentoMunicipioId != T001M2_A114DepartamentoMunicipioId[0] ) )
            {
               if ( StringUtil.StrCmp(Z435ClientesEstado, T001M2_A435ClientesEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("clientesdatos:[seudo value changed for attri]"+"ClientesEstado");
                  GXUtil.WriteLogRaw("Old: ",Z435ClientesEstado);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A435ClientesEstado[0]);
               }
               if ( StringUtil.StrCmp(Z160ClientesNombre, T001M2_A160ClientesNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("clientesdatos:[seudo value changed for attri]"+"ClientesNombre");
                  GXUtil.WriteLogRaw("Old: ",Z160ClientesNombre);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A160ClientesNombre[0]);
               }
               if ( StringUtil.StrCmp(Z434ClientesIdentidad, T001M2_A434ClientesIdentidad[0]) != 0 )
               {
                  GXUtil.WriteLog("clientesdatos:[seudo value changed for attri]"+"ClientesIdentidad");
                  GXUtil.WriteLogRaw("Old: ",Z434ClientesIdentidad);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A434ClientesIdentidad[0]);
               }
               if ( StringUtil.StrCmp(Z161ClientesTelefono, T001M2_A161ClientesTelefono[0]) != 0 )
               {
                  GXUtil.WriteLog("clientesdatos:[seudo value changed for attri]"+"ClientesTelefono");
                  GXUtil.WriteLogRaw("Old: ",Z161ClientesTelefono);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A161ClientesTelefono[0]);
               }
               if ( StringUtil.StrCmp(Z162ClientesEmail, T001M2_A162ClientesEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("clientesdatos:[seudo value changed for attri]"+"ClientesEmail");
                  GXUtil.WriteLogRaw("Old: ",Z162ClientesEmail);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A162ClientesEmail[0]);
               }
               if ( StringUtil.StrCmp(Z163ClientesDireccion, T001M2_A163ClientesDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("clientesdatos:[seudo value changed for attri]"+"ClientesDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z163ClientesDireccion);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A163ClientesDireccion[0]);
               }
               if ( Z112DepartamentoId != T001M2_A112DepartamentoId[0] )
               {
                  GXUtil.WriteLog("clientesdatos:[seudo value changed for attri]"+"DepartamentoId");
                  GXUtil.WriteLogRaw("Old: ",Z112DepartamentoId);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A112DepartamentoId[0]);
               }
               if ( Z114DepartamentoMunicipioId != T001M2_A114DepartamentoMunicipioId[0] )
               {
                  GXUtil.WriteLog("clientesdatos:[seudo value changed for attri]"+"DepartamentoMunicipioId");
                  GXUtil.WriteLogRaw("Old: ",Z114DepartamentoMunicipioId);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A114DepartamentoMunicipioId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Clientes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1M20( )
      {
         BeforeValidate1M20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1M20( 0) ;
            CheckOptimisticConcurrency1M20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1M20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1M20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001M12 */
                     pr_default.execute(10, new Object[] {A435ClientesEstado, A160ClientesNombre, A434ClientesIdentidad, A164ClientesImagen, A40000ClientesImagen_GXI, A161ClientesTelefono, A162ClientesEmail, A163ClientesDireccion, A112DepartamentoId, A114DepartamentoMunicipioId});
                     A106ClientesId = T001M12_A106ClientesId[0];
                     AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Clientes");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1M0( ) ;
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
               Load1M20( ) ;
            }
            EndLevel1M20( ) ;
         }
         CloseExtendedTableCursors1M20( ) ;
      }

      protected void Update1M20( )
      {
         BeforeValidate1M20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1M20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1M20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1M20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001M13 */
                     pr_default.execute(11, new Object[] {A435ClientesEstado, A160ClientesNombre, A434ClientesIdentidad, A161ClientesTelefono, A162ClientesEmail, A163ClientesDireccion, A112DepartamentoId, A114DepartamentoMunicipioId, A106ClientesId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Clientes");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Clientes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1M20( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1M0( ) ;
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
            EndLevel1M20( ) ;
         }
         CloseExtendedTableCursors1M20( ) ;
      }

      protected void DeferredUpdate1M20( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001M14 */
            pr_default.execute(12, new Object[] {A164ClientesImagen, A40000ClientesImagen_GXI, A106ClientesId});
            pr_default.close(12);
            pr_default.SmartCacheProvider.SetUpdated("Clientes");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1M20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1M20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1M20( ) ;
            AfterConfirm1M20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1M20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001M15 */
                  pr_default.execute(13, new Object[] {A106ClientesId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("Clientes");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound20 == 0 )
                        {
                           InitAll1M20( ) ;
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
                        ResetCaption1M0( ) ;
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1M20( ) ;
         Gx_mode = sMode20;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1M20( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001M16 */
            pr_default.execute(14, new Object[] {A112DepartamentoId});
            A116PaisID = T001M16_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
            pr_default.close(14);
         }
      }

      protected void EndLevel1M20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1M20( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(14);
            context.CommitDataStores("clientesdatos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1M0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(14);
            context.RollbackDataStores("clientesdatos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1M20( )
      {
         /* Scan By routine */
         /* Using cursor T001M17 */
         pr_default.execute(15);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound20 = 1;
            A106ClientesId = T001M17_A106ClientesId[0];
            AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1M20( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound20 = 1;
            A106ClientesId = T001M17_A106ClientesId[0];
            AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
         }
      }

      protected void ScanEnd1M20( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1M20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1M20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1M20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1M20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1M20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1M20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1M20( )
      {
         edtClientesId_Enabled = 0;
         AssignProp("", false, edtClientesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesId_Enabled), 5, 0), true);
         edtClientesNombre_Enabled = 0;
         AssignProp("", false, edtClientesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesNombre_Enabled), 5, 0), true);
         edtClientesIdentidad_Enabled = 0;
         AssignProp("", false, edtClientesIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesIdentidad_Enabled), 5, 0), true);
         imgClientesImagen_Enabled = 0;
         AssignProp("", false, imgClientesImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgClientesImagen_Enabled), 5, 0), true);
         edtClientesTelefono_Enabled = 0;
         AssignProp("", false, edtClientesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesTelefono_Enabled), 5, 0), true);
         edtClientesEmail_Enabled = 0;
         AssignProp("", false, edtClientesEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesEmail_Enabled), 5, 0), true);
         edtClientesDireccion_Enabled = 0;
         AssignProp("", false, edtClientesDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesDireccion_Enabled), 5, 0), true);
         edtPaisID_Enabled = 0;
         AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         edtDepartamentoId_Enabled = 0;
         AssignProp("", false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
         edtDepartamentoMunicipioId_Enabled = 0;
         AssignProp("", false, edtDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0), true);
         cmbClientesEstado.Enabled = 0;
         AssignProp("", false, cmbClientesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbClientesEstado.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1M20( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1M0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clientesdatos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z106ClientesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106ClientesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z435ClientesEstado", StringUtil.RTrim( Z435ClientesEstado));
         GxWebStd.gx_hidden_field( context, "Z160ClientesNombre", StringUtil.RTrim( Z160ClientesNombre));
         GxWebStd.gx_hidden_field( context, "Z434ClientesIdentidad", StringUtil.RTrim( Z434ClientesIdentidad));
         GxWebStd.gx_hidden_field( context, "Z161ClientesTelefono", StringUtil.RTrim( Z161ClientesTelefono));
         GxWebStd.gx_hidden_field( context, "Z162ClientesEmail", Z162ClientesEmail);
         GxWebStd.gx_hidden_field( context, "Z163ClientesDireccion", Z163ClientesDireccion);
         GxWebStd.gx_hidden_field( context, "Z112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CLIENTESIMAGEN_GXI", A40000ClientesImagen_GXI);
         GXCCtlgxBlob = "CLIENTESIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A164ClientesImagen);
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
         return formatLink("clientesdatos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ClientesDatos" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Clientes Datos", "") ;
      }

      protected void InitializeNonKey1M20( )
      {
         A435ClientesEstado = "";
         AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
         A160ClientesNombre = "";
         AssignAttri("", false, "A160ClientesNombre", A160ClientesNombre);
         A434ClientesIdentidad = "";
         AssignAttri("", false, "A434ClientesIdentidad", A434ClientesIdentidad);
         A164ClientesImagen = "";
         AssignAttri("", false, "A164ClientesImagen", A164ClientesImagen);
         AssignProp("", false, imgClientesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A164ClientesImagen))), true);
         AssignProp("", false, imgClientesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A164ClientesImagen), true);
         A40000ClientesImagen_GXI = "";
         AssignProp("", false, imgClientesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A164ClientesImagen))), true);
         AssignProp("", false, imgClientesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A164ClientesImagen), true);
         A161ClientesTelefono = "";
         AssignAttri("", false, "A161ClientesTelefono", A161ClientesTelefono);
         A162ClientesEmail = "";
         AssignAttri("", false, "A162ClientesEmail", A162ClientesEmail);
         A163ClientesDireccion = "";
         AssignAttri("", false, "A163ClientesDireccion", A163ClientesDireccion);
         A116PaisID = "";
         AssignAttri("", false, "A116PaisID", A116PaisID);
         A114DepartamentoMunicipioId = 0;
         AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         A112DepartamentoId = 1;
         AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         Z435ClientesEstado = "";
         Z160ClientesNombre = "";
         Z434ClientesIdentidad = "";
         Z161ClientesTelefono = "";
         Z162ClientesEmail = "";
         Z163ClientesDireccion = "";
         Z112DepartamentoId = 0;
         Z114DepartamentoMunicipioId = 0;
      }

      protected void InitAll1M20( )
      {
         A106ClientesId = 0;
         AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
         InitializeNonKey1M20( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A435ClientesEstado = i435ClientesEstado;
         AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
         A112DepartamentoId = i112DepartamentoId;
         AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932041952", true, true, false);
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
         context.AddJavascriptSource("clientesdatos.js", "?2026932041952", false, true, false);
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
         edtClientesId_Internalname = "CLIENTESID";
         edtClientesNombre_Internalname = "CLIENTESNOMBRE";
         edtClientesIdentidad_Internalname = "CLIENTESIDENTIDAD";
         imgClientesImagen_Internalname = "CLIENTESIMAGEN";
         edtClientesTelefono_Internalname = "CLIENTESTELEFONO";
         edtClientesEmail_Internalname = "CLIENTESEMAIL";
         edtClientesDireccion_Internalname = "CLIENTESDIRECCION";
         edtPaisID_Internalname = "PAISID";
         edtDepartamentoId_Internalname = "DEPARTAMENTOID";
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID";
         cmbClientesEstado_Internalname = "CLIENTESESTADO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_112_Internalname = "PROMPT_112";
         imgprompt_114_Internalname = "PROMPT_114";
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
         Form.Caption = context.GetMessage( "Clientes Datos", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbClientesEstado_Jsonclick = "";
         cmbClientesEstado.Enabled = 1;
         imgprompt_114_Visible = 1;
         imgprompt_114_Link = "";
         edtDepartamentoMunicipioId_Jsonclick = "";
         edtDepartamentoMunicipioId_Enabled = 1;
         imgprompt_112_Visible = 1;
         imgprompt_112_Link = "";
         edtDepartamentoId_Jsonclick = "";
         edtDepartamentoId_Enabled = 1;
         edtPaisID_Jsonclick = "";
         edtPaisID_Enabled = 0;
         edtClientesDireccion_Enabled = 1;
         edtClientesEmail_Jsonclick = "";
         edtClientesEmail_Enabled = 1;
         edtClientesTelefono_Jsonclick = "";
         edtClientesTelefono_Enabled = 1;
         imgClientesImagen_Enabled = 1;
         edtClientesIdentidad_Jsonclick = "";
         edtClientesIdentidad_Enabled = 1;
         edtClientesNombre_Jsonclick = "";
         edtClientesNombre_Enabled = 1;
         edtClientesId_Jsonclick = "";
         edtClientesId_Enabled = 0;
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
         cmbClientesEstado.Name = "CLIENTESESTADO";
         cmbClientesEstado.WebTags = "";
         cmbClientesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbClientesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbClientesEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbClientesEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbClientesEstado.ItemCount > 0 )
         {
            A435ClientesEstado = cmbClientesEstado.getValidValue(A435ClientesEstado);
            AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtClientesNombre_Internalname;
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

      public void Valid_Clientesid( )
      {
         A435ClientesEstado = cmbClientesEstado.CurrentValue;
         cmbClientesEstado.CurrentValue = A435ClientesEstado;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbClientesEstado.ItemCount > 0 )
         {
            A435ClientesEstado = cmbClientesEstado.getValidValue(A435ClientesEstado);
            cmbClientesEstado.CurrentValue = A435ClientesEstado;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbClientesEstado.CurrentValue = StringUtil.RTrim( A435ClientesEstado);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A435ClientesEstado", StringUtil.RTrim( A435ClientesEstado));
         cmbClientesEstado.CurrentValue = StringUtil.RTrim( A435ClientesEstado);
         AssignProp("", false, cmbClientesEstado_Internalname, "Values", cmbClientesEstado.ToJavascriptSource(), true);
         AssignAttri("", false, "A160ClientesNombre", StringUtil.RTrim( A160ClientesNombre));
         AssignAttri("", false, "A434ClientesIdentidad", StringUtil.RTrim( A434ClientesIdentidad));
         AssignAttri("", false, "A164ClientesImagen", context.PathToRelativeUrl( A164ClientesImagen));
         GXCCtlgxBlob = "CLIENTESIMAGEN" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A164ClientesImagen));
         AssignAttri("", false, "A40000ClientesImagen_GXI", A40000ClientesImagen_GXI);
         AssignAttri("", false, "A161ClientesTelefono", StringUtil.RTrim( A161ClientesTelefono));
         AssignAttri("", false, "A162ClientesEmail", A162ClientesEmail);
         AssignAttri("", false, "A163ClientesDireccion", A163ClientesDireccion);
         AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", "")));
         AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", "")));
         AssignAttri("", false, "A116PaisID", StringUtil.RTrim( A116PaisID));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z106ClientesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106ClientesId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z435ClientesEstado", StringUtil.RTrim( Z435ClientesEstado));
         GxWebStd.gx_hidden_field( context, "Z160ClientesNombre", StringUtil.RTrim( Z160ClientesNombre));
         GxWebStd.gx_hidden_field( context, "Z434ClientesIdentidad", StringUtil.RTrim( Z434ClientesIdentidad));
         GxWebStd.gx_hidden_field( context, "Z164ClientesImagen", context.PathToRelativeUrl( Z164ClientesImagen));
         GxWebStd.gx_hidden_field( context, "Z40000ClientesImagen_GXI", Z40000ClientesImagen_GXI);
         GxWebStd.gx_hidden_field( context, "Z161ClientesTelefono", StringUtil.RTrim( Z161ClientesTelefono));
         GxWebStd.gx_hidden_field( context, "Z162ClientesEmail", Z162ClientesEmail);
         GxWebStd.gx_hidden_field( context, "Z163ClientesDireccion", Z163ClientesDireccion);
         GxWebStd.gx_hidden_field( context, "Z112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z116PaisID", StringUtil.RTrim( Z116PaisID));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Departamentoid( )
      {
         /* Using cursor T001M16 */
         pr_default.execute(14, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
         }
         A116PaisID = T001M16_A116PaisID[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A116PaisID", StringUtil.RTrim( A116PaisID));
      }

      public void Valid_Departamentomunicipioid( )
      {
         /* Using cursor T001M18 */
         pr_default.execute(16, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
         }
         pr_default.close(16);
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
         setEventMetadata("VALID_CLIENTESID","{handler:'Valid_Clientesid',iparms:[{av:'A106ClientesId',fld:'CLIENTESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'cmbClientesEstado'},{av:'A435ClientesEstado',fld:'CLIENTESESTADO',pic:'',type:'char'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_CLIENTESID",",oparms:[{av:'cmbClientesEstado'},{av:'A435ClientesEstado',fld:'CLIENTESESTADO',pic:'',type:'char'},{av:'A160ClientesNombre',fld:'CLIENTESNOMBRE',pic:'',type:'char'},{av:'A434ClientesIdentidad',fld:'CLIENTESIDENTIDAD',pic:'',type:'char'},{av:'A164ClientesImagen',fld:'CLIENTESIMAGEN',pic:'',type:'bits'},{av:'A40000ClientesImagen_GXI',fld:'CLIENTESIMAGEN_GXI',pic:'',type:'svchar'},{av:'A161ClientesTelefono',fld:'CLIENTESTELEFONO',pic:'',type:'char'},{av:'A162ClientesEmail',fld:'CLIENTESEMAIL',pic:'',type:'svchar'},{av:'A163ClientesDireccion',fld:'CLIENTESDIRECCION',pic:'',type:'svchar'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z106ClientesId',type:'int'},{av:'Z435ClientesEstado',type:'char'},{av:'Z160ClientesNombre',type:'char'},{av:'Z434ClientesIdentidad',type:'char'},{av:'Z164ClientesImagen',type:'bits'},{av:'Z40000ClientesImagen_GXI',type:'svchar'},{av:'Z161ClientesTelefono',type:'char'},{av:'Z162ClientesEmail',type:'svchar'},{av:'Z163ClientesDireccion',type:'svchar'},{av:'Z112DepartamentoId',type:'int'},{av:'Z114DepartamentoMunicipioId',type:'int'},{av:'Z116PaisID',type:'char'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_CLIENTESEMAIL","{handler:'Valid_Clientesemail',iparms:[]");
         setEventMetadata("VALID_CLIENTESEMAIL",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'}]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'}]}");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID","{handler:'Valid_Departamentomunicipioid',iparms:[{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID",",oparms:[]}");
         setEventMetadata("VALID_CLIENTESESTADO","{handler:'Valid_Clientesestado',iparms:[]");
         setEventMetadata("VALID_CLIENTESESTADO",",oparms:[]}");
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
         pr_default.close(14);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z435ClientesEstado = "";
         Z160ClientesNombre = "";
         Z434ClientesIdentidad = "";
         Z161ClientesTelefono = "";
         Z162ClientesEmail = "";
         Z163ClientesDireccion = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A435ClientesEstado = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A160ClientesNombre = "";
         A434ClientesIdentidad = "";
         A164ClientesImagen = "";
         A40000ClientesImagen_GXI = "";
         sImgUrl = "";
         gxphoneLink = "";
         A161ClientesTelefono = "";
         A162ClientesEmail = "";
         A163ClientesDireccion = "";
         A116PaisID = "";
         imgprompt_112_gximage = "";
         imgprompt_114_gximage = "";
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
         Z164ClientesImagen = "";
         Z40000ClientesImagen_GXI = "";
         Z116PaisID = "";
         T001M4_A116PaisID = new string[] {""} ;
         T001M6_A106ClientesId = new long[1] ;
         T001M6_A435ClientesEstado = new string[] {""} ;
         T001M6_A160ClientesNombre = new string[] {""} ;
         T001M6_A434ClientesIdentidad = new string[] {""} ;
         T001M6_A40000ClientesImagen_GXI = new string[] {""} ;
         T001M6_A161ClientesTelefono = new string[] {""} ;
         T001M6_A162ClientesEmail = new string[] {""} ;
         T001M6_A163ClientesDireccion = new string[] {""} ;
         T001M6_A112DepartamentoId = new long[1] ;
         T001M6_A114DepartamentoMunicipioId = new long[1] ;
         T001M6_A116PaisID = new string[] {""} ;
         T001M6_A164ClientesImagen = new string[] {""} ;
         T001M5_A112DepartamentoId = new long[1] ;
         T001M7_A116PaisID = new string[] {""} ;
         T001M8_A112DepartamentoId = new long[1] ;
         T001M9_A106ClientesId = new long[1] ;
         T001M3_A106ClientesId = new long[1] ;
         T001M3_A435ClientesEstado = new string[] {""} ;
         T001M3_A160ClientesNombre = new string[] {""} ;
         T001M3_A434ClientesIdentidad = new string[] {""} ;
         T001M3_A40000ClientesImagen_GXI = new string[] {""} ;
         T001M3_A161ClientesTelefono = new string[] {""} ;
         T001M3_A162ClientesEmail = new string[] {""} ;
         T001M3_A163ClientesDireccion = new string[] {""} ;
         T001M3_A112DepartamentoId = new long[1] ;
         T001M3_A114DepartamentoMunicipioId = new long[1] ;
         T001M3_A164ClientesImagen = new string[] {""} ;
         sMode20 = "";
         T001M10_A106ClientesId = new long[1] ;
         T001M11_A106ClientesId = new long[1] ;
         T001M2_A106ClientesId = new long[1] ;
         T001M2_A435ClientesEstado = new string[] {""} ;
         T001M2_A160ClientesNombre = new string[] {""} ;
         T001M2_A434ClientesIdentidad = new string[] {""} ;
         T001M2_A40000ClientesImagen_GXI = new string[] {""} ;
         T001M2_A161ClientesTelefono = new string[] {""} ;
         T001M2_A162ClientesEmail = new string[] {""} ;
         T001M2_A163ClientesDireccion = new string[] {""} ;
         T001M2_A112DepartamentoId = new long[1] ;
         T001M2_A114DepartamentoMunicipioId = new long[1] ;
         T001M2_A164ClientesImagen = new string[] {""} ;
         T001M12_A106ClientesId = new long[1] ;
         T001M16_A116PaisID = new string[] {""} ;
         T001M17_A106ClientesId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         i435ClientesEstado = "";
         ZZ435ClientesEstado = "";
         ZZ160ClientesNombre = "";
         ZZ434ClientesIdentidad = "";
         ZZ164ClientesImagen = "";
         ZZ40000ClientesImagen_GXI = "";
         ZZ161ClientesTelefono = "";
         ZZ162ClientesEmail = "";
         ZZ163ClientesDireccion = "";
         ZZ116PaisID = "";
         T001M18_A112DepartamentoId = new long[1] ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.clientesdatos__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientesdatos__default(),
            new Object[][] {
                new Object[] {
               T001M2_A106ClientesId, T001M2_A435ClientesEstado, T001M2_A160ClientesNombre, T001M2_A434ClientesIdentidad, T001M2_A40000ClientesImagen_GXI, T001M2_A161ClientesTelefono, T001M2_A162ClientesEmail, T001M2_A163ClientesDireccion, T001M2_A112DepartamentoId, T001M2_A114DepartamentoMunicipioId,
               T001M2_A164ClientesImagen
               }
               , new Object[] {
               T001M3_A106ClientesId, T001M3_A435ClientesEstado, T001M3_A160ClientesNombre, T001M3_A434ClientesIdentidad, T001M3_A40000ClientesImagen_GXI, T001M3_A161ClientesTelefono, T001M3_A162ClientesEmail, T001M3_A163ClientesDireccion, T001M3_A112DepartamentoId, T001M3_A114DepartamentoMunicipioId,
               T001M3_A164ClientesImagen
               }
               , new Object[] {
               T001M4_A116PaisID
               }
               , new Object[] {
               T001M5_A112DepartamentoId
               }
               , new Object[] {
               T001M6_A106ClientesId, T001M6_A435ClientesEstado, T001M6_A160ClientesNombre, T001M6_A434ClientesIdentidad, T001M6_A40000ClientesImagen_GXI, T001M6_A161ClientesTelefono, T001M6_A162ClientesEmail, T001M6_A163ClientesDireccion, T001M6_A112DepartamentoId, T001M6_A114DepartamentoMunicipioId,
               T001M6_A116PaisID, T001M6_A164ClientesImagen
               }
               , new Object[] {
               T001M7_A116PaisID
               }
               , new Object[] {
               T001M8_A112DepartamentoId
               }
               , new Object[] {
               T001M9_A106ClientesId
               }
               , new Object[] {
               T001M10_A106ClientesId
               }
               , new Object[] {
               T001M11_A106ClientesId
               }
               , new Object[] {
               T001M12_A106ClientesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001M16_A116PaisID
               }
               , new Object[] {
               T001M17_A106ClientesId
               }
               , new Object[] {
               T001M18_A112DepartamentoId
               }
            }
         );
         Z112DepartamentoId = 1;
         i112DepartamentoId = 1;
         A112DepartamentoId = 1;
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound20 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtClientesId_Enabled ;
      private int edtClientesNombre_Enabled ;
      private int edtClientesIdentidad_Enabled ;
      private int imgClientesImagen_Enabled ;
      private int edtClientesTelefono_Enabled ;
      private int edtClientesEmail_Enabled ;
      private int edtClientesDireccion_Enabled ;
      private int edtPaisID_Enabled ;
      private int edtDepartamentoId_Enabled ;
      private int imgprompt_112_Visible ;
      private int edtDepartamentoMunicipioId_Enabled ;
      private int imgprompt_114_Visible ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z106ClientesId ;
      private long Z112DepartamentoId ;
      private long Z114DepartamentoMunicipioId ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A106ClientesId ;
      private long i112DepartamentoId ;
      private long ZZ106ClientesId ;
      private long ZZ112DepartamentoId ;
      private long ZZ114DepartamentoMunicipioId ;
      private string sPrefix ;
      private string Z435ClientesEstado ;
      private string Z160ClientesNombre ;
      private string Z434ClientesIdentidad ;
      private string Z161ClientesTelefono ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtClientesNombre_Internalname ;
      private string A435ClientesEstado ;
      private string cmbClientesEstado_Internalname ;
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
      private string edtClientesId_Internalname ;
      private string edtClientesId_Jsonclick ;
      private string A160ClientesNombre ;
      private string edtClientesNombre_Jsonclick ;
      private string edtClientesIdentidad_Internalname ;
      private string A434ClientesIdentidad ;
      private string edtClientesIdentidad_Jsonclick ;
      private string imgClientesImagen_Internalname ;
      private string sImgUrl ;
      private string edtClientesTelefono_Internalname ;
      private string gxphoneLink ;
      private string A161ClientesTelefono ;
      private string edtClientesTelefono_Jsonclick ;
      private string edtClientesEmail_Internalname ;
      private string edtClientesEmail_Jsonclick ;
      private string edtClientesDireccion_Internalname ;
      private string edtPaisID_Internalname ;
      private string A116PaisID ;
      private string edtPaisID_Jsonclick ;
      private string edtDepartamentoId_Internalname ;
      private string edtDepartamentoId_Jsonclick ;
      private string imgprompt_112_gximage ;
      private string imgprompt_112_Internalname ;
      private string imgprompt_112_Link ;
      private string edtDepartamentoMunicipioId_Internalname ;
      private string edtDepartamentoMunicipioId_Jsonclick ;
      private string imgprompt_114_gximage ;
      private string imgprompt_114_Internalname ;
      private string imgprompt_114_Link ;
      private string cmbClientesEstado_Jsonclick ;
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
      private string Z116PaisID ;
      private string sMode20 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string i435ClientesEstado ;
      private string ZZ435ClientesEstado ;
      private string ZZ160ClientesNombre ;
      private string ZZ434ClientesIdentidad ;
      private string ZZ161ClientesTelefono ;
      private string ZZ116PaisID ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A164ClientesImagen_IsBlob ;
      private bool Gx_longc ;
      private string Z162ClientesEmail ;
      private string Z163ClientesDireccion ;
      private string A40000ClientesImagen_GXI ;
      private string A162ClientesEmail ;
      private string A163ClientesDireccion ;
      private string Z40000ClientesImagen_GXI ;
      private string ZZ40000ClientesImagen_GXI ;
      private string ZZ162ClientesEmail ;
      private string ZZ163ClientesDireccion ;
      private string A164ClientesImagen ;
      private string Z164ClientesImagen ;
      private string ZZ164ClientesImagen ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbClientesEstado ;
      private IDataStoreProvider pr_default ;
      private string[] T001M4_A116PaisID ;
      private long[] T001M6_A106ClientesId ;
      private string[] T001M6_A435ClientesEstado ;
      private string[] T001M6_A160ClientesNombre ;
      private string[] T001M6_A434ClientesIdentidad ;
      private string[] T001M6_A40000ClientesImagen_GXI ;
      private string[] T001M6_A161ClientesTelefono ;
      private string[] T001M6_A162ClientesEmail ;
      private string[] T001M6_A163ClientesDireccion ;
      private long[] T001M6_A112DepartamentoId ;
      private long[] T001M6_A114DepartamentoMunicipioId ;
      private string[] T001M6_A116PaisID ;
      private string[] T001M6_A164ClientesImagen ;
      private long[] T001M5_A112DepartamentoId ;
      private string[] T001M7_A116PaisID ;
      private long[] T001M8_A112DepartamentoId ;
      private long[] T001M9_A106ClientesId ;
      private long[] T001M3_A106ClientesId ;
      private string[] T001M3_A435ClientesEstado ;
      private string[] T001M3_A160ClientesNombre ;
      private string[] T001M3_A434ClientesIdentidad ;
      private string[] T001M3_A40000ClientesImagen_GXI ;
      private string[] T001M3_A161ClientesTelefono ;
      private string[] T001M3_A162ClientesEmail ;
      private string[] T001M3_A163ClientesDireccion ;
      private long[] T001M3_A112DepartamentoId ;
      private long[] T001M3_A114DepartamentoMunicipioId ;
      private string[] T001M3_A164ClientesImagen ;
      private long[] T001M10_A106ClientesId ;
      private long[] T001M11_A106ClientesId ;
      private long[] T001M2_A106ClientesId ;
      private string[] T001M2_A435ClientesEstado ;
      private string[] T001M2_A160ClientesNombre ;
      private string[] T001M2_A434ClientesIdentidad ;
      private string[] T001M2_A40000ClientesImagen_GXI ;
      private string[] T001M2_A161ClientesTelefono ;
      private string[] T001M2_A162ClientesEmail ;
      private string[] T001M2_A163ClientesDireccion ;
      private long[] T001M2_A112DepartamentoId ;
      private long[] T001M2_A114DepartamentoMunicipioId ;
      private string[] T001M2_A164ClientesImagen ;
      private long[] T001M12_A106ClientesId ;
      private string[] T001M16_A116PaisID ;
      private long[] T001M17_A106ClientesId ;
      private long[] T001M18_A112DepartamentoId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class clientesdatos__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class clientesdatos__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001M2;
        prmT001M2 = new Object[] {
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT001M3;
        prmT001M3 = new Object[] {
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT001M4;
        prmT001M4 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT001M5;
        prmT001M5 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT001M6;
        prmT001M6 = new Object[] {
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT001M7;
        prmT001M7 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT001M8;
        prmT001M8 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT001M9;
        prmT001M9 = new Object[] {
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT001M10;
        prmT001M10 = new Object[] {
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT001M11;
        prmT001M11 = new Object[] {
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT001M12;
        prmT001M12 = new Object[] {
        new ParDef("@ClientesEstado",GXType.NChar,3,0) ,
        new ParDef("@ClientesNombre",GXType.NChar,100,0) ,
        new ParDef("@ClientesIdentidad",GXType.NChar,25,0) ,
        new ParDef("@ClientesImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ClientesImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="Clientes", Fld="ClientesImagen"} ,
        new ParDef("@ClientesTelefono",GXType.NChar,20,0) ,
        new ParDef("@ClientesEmail",GXType.NVarChar,100,0) ,
        new ParDef("@ClientesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT001M13;
        prmT001M13 = new Object[] {
        new ParDef("@ClientesEstado",GXType.NChar,3,0) ,
        new ParDef("@ClientesNombre",GXType.NChar,100,0) ,
        new ParDef("@ClientesIdentidad",GXType.NChar,25,0) ,
        new ParDef("@ClientesTelefono",GXType.NChar,20,0) ,
        new ParDef("@ClientesEmail",GXType.NVarChar,100,0) ,
        new ParDef("@ClientesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0) ,
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT001M14;
        prmT001M14 = new Object[] {
        new ParDef("@ClientesImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ClientesImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Clientes", Fld="ClientesImagen"} ,
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT001M15;
        prmT001M15 = new Object[] {
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT001M16;
        prmT001M16 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT001M17;
        prmT001M17 = new Object[] {
        };
        Object[] prmT001M18;
        prmT001M18 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001M2", "SELECT [ClientesId], [ClientesEstado], [ClientesNombre], [ClientesIdentidad], [ClientesImagen_GXI], [ClientesTelefono], [ClientesEmail], [ClientesDireccion], [DepartamentoId], [DepartamentoMunicipioId], [ClientesImagen] FROM [Clientes] WITH (UPDLOCK) WHERE [ClientesId] = @ClientesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M3", "SELECT [ClientesId], [ClientesEstado], [ClientesNombre], [ClientesIdentidad], [ClientesImagen_GXI], [ClientesTelefono], [ClientesEmail], [ClientesDireccion], [DepartamentoId], [DepartamentoMunicipioId], [ClientesImagen] FROM [Clientes] WHERE [ClientesId] = @ClientesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M4", "SELECT [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M5", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M6", "SELECT TM1.[ClientesId], TM1.[ClientesEstado], TM1.[ClientesNombre], TM1.[ClientesIdentidad], TM1.[ClientesImagen_GXI], TM1.[ClientesTelefono], TM1.[ClientesEmail], TM1.[ClientesDireccion], TM1.[DepartamentoId], TM1.[DepartamentoMunicipioId], T2.[PaisID], TM1.[ClientesImagen] FROM ([Clientes] TM1 INNER JOIN [Departamento] T2 ON T2.[DepartamentoId] = TM1.[DepartamentoId]) WHERE TM1.[ClientesId] = @ClientesId ORDER BY TM1.[ClientesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001M6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M7", "SELECT [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M8", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M9", "SELECT [ClientesId] FROM [Clientes] WHERE [ClientesId] = @ClientesId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001M9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M10", "SELECT TOP 1 [ClientesId] FROM [Clientes] WHERE ( [ClientesId] > @ClientesId) ORDER BY [ClientesId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001M10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001M11", "SELECT TOP 1 [ClientesId] FROM [Clientes] WHERE ( [ClientesId] < @ClientesId) ORDER BY [ClientesId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001M11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001M12", "INSERT INTO [Clientes]([ClientesEstado], [ClientesNombre], [ClientesIdentidad], [ClientesImagen], [ClientesImagen_GXI], [ClientesTelefono], [ClientesEmail], [ClientesDireccion], [DepartamentoId], [DepartamentoMunicipioId]) VALUES(@ClientesEstado, @ClientesNombre, @ClientesIdentidad, @ClientesImagen, @ClientesImagen_GXI, @ClientesTelefono, @ClientesEmail, @ClientesDireccion, @DepartamentoId, @DepartamentoMunicipioId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001M12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001M13", "UPDATE [Clientes] SET [ClientesEstado]=@ClientesEstado, [ClientesNombre]=@ClientesNombre, [ClientesIdentidad]=@ClientesIdentidad, [ClientesTelefono]=@ClientesTelefono, [ClientesEmail]=@ClientesEmail, [ClientesDireccion]=@ClientesDireccion, [DepartamentoId]=@DepartamentoId, [DepartamentoMunicipioId]=@DepartamentoMunicipioId  WHERE [ClientesId] = @ClientesId", GxErrorMask.GX_NOMASK,prmT001M13)
           ,new CursorDef("T001M14", "UPDATE [Clientes] SET [ClientesImagen]=@ClientesImagen, [ClientesImagen_GXI]=@ClientesImagen_GXI  WHERE [ClientesId] = @ClientesId", GxErrorMask.GX_NOMASK,prmT001M14)
           ,new CursorDef("T001M15", "DELETE FROM [Clientes]  WHERE [ClientesId] = @ClientesId", GxErrorMask.GX_NOMASK,prmT001M15)
           ,new CursorDef("T001M16", "SELECT [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M17", "SELECT [ClientesId] FROM [Clientes] ORDER BY [ClientesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001M17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M18", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M18,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 25);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 25);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 25);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 2);
              ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(5));
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
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
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
