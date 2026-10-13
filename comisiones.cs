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
   public class comisiones : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A133ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A133ProveedorID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A120ProfesionalesId = GetPar( "ProfesionalesId");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A120ProfesionalesId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A107EstadosTipo = GetPar( "EstadosTipo");
            A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosGenericosId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A107EstadosTipo, A108EstadosGenericosId) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_proveedores") == 0 )
         {
            gxnrGridlevel_proveedores_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_profesionales") == 0 )
         {
            gxnrGridlevel_profesionales_newrow_invoke( ) ;
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
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "comisiones.aspx")), "comisiones.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "comisiones.aspx")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7ComisionesID = (long)(Math.Round(NumberUtil.Val( GetPar( "ComisionesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ComisionesID", StringUtil.LTrimStr( (decimal)(AV7ComisionesID), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCOMISIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ComisionesID), "ZZZZZZZZZZZZZZZZZ9"), context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
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
         Form.Meta.addItem("description", context.GetMessage( "Comisiones", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbComisionesEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_proveedores_newrow_invoke( )
      {
         nRC_GXsfl_72 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_72"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_72_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_72_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_72_idx = GetPar( "sGXsfl_72_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_proveedores_newrow( ) ;
         /* End function gxnrGridlevel_proveedores_newrow_invoke */
      }

      protected void gxnrGridlevel_profesionales_newrow_invoke( )
      {
         nRC_GXsfl_88 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_88"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_88_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_88_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_88_idx = GetPar( "sGXsfl_88_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_profesionales_newrow( ) ;
         /* End function gxnrGridlevel_profesionales_newrow_invoke */
      }

      public comisiones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comisiones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_ComisionesID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ComisionesID = aP1_ComisionesID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbComisionesEstado = new GXCombobox();
         cmbComisionesTipo = new GXCombobox();
         chkComisionesGlobal = new GXCheckbox();
         dynProveedorID = new GXCombobox();
         cmbProveedorEstado = new GXCombobox();
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
         if ( cmbComisionesEstado.ItemCount > 0 )
         {
            A511ComisionesEstado = cmbComisionesEstado.getValidValue(A511ComisionesEstado);
            n511ComisionesEstado = false;
            AssignAttri("", false, "A511ComisionesEstado", A511ComisionesEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbComisionesEstado.CurrentValue = StringUtil.RTrim( A511ComisionesEstado);
            AssignProp("", false, cmbComisionesEstado_Internalname, "Values", cmbComisionesEstado.ToJavascriptSource(), true);
         }
         if ( cmbComisionesTipo.ItemCount > 0 )
         {
            A505ComisionesTipo = cmbComisionesTipo.getValidValue(A505ComisionesTipo);
            AssignAttri("", false, "A505ComisionesTipo", A505ComisionesTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbComisionesTipo.CurrentValue = StringUtil.RTrim( A505ComisionesTipo);
            AssignProp("", false, cmbComisionesTipo_Internalname, "Values", cmbComisionesTipo.ToJavascriptSource(), true);
         }
         A520ComisionesGlobal = StringUtil.StrToBool( StringUtil.BoolToStr( A520ComisionesGlobal));
         n520ComisionesGlobal = false;
         AssignAttri("", false, "A520ComisionesGlobal", A520ComisionesGlobal);
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
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucGxuitabspanel_tabs.SetProperty("PageCount", Gxuitabspanel_tabs_Pagecount);
         ucGxuitabspanel_tabs.SetProperty("Class", Gxuitabspanel_tabs_Class);
         ucGxuitabspanel_tabs.SetProperty("HistoryManagement", Gxuitabspanel_tabs_Historymanagement);
         ucGxuitabspanel_tabs.Render(context, "tab", Gxuitabspanel_tabs_Internalname, "GXUITABSPANEL_TABSContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTabgeneral_title_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), "", "", lblTabgeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Comisiones.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "tabGeneral") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtComisionesID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComisionesID_Internalname, context.GetMessage( "Código", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComisionesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A503ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtComisionesID_Enabled!=0) ? context.localUtil.Format( (decimal)(A503ComisionesID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A503ComisionesID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtComisionesID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Comisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbComisionesEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbComisionesEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbComisionesEstado, cmbComisionesEstado_Internalname, StringUtil.RTrim( A511ComisionesEstado), 1, cmbComisionesEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbComisionesEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Comisiones.htm");
         cmbComisionesEstado.CurrentValue = StringUtil.RTrim( A511ComisionesEstado);
         AssignProp("", false, cmbComisionesEstado_Internalname, "Values", (string)(cmbComisionesEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTb1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbComisionesTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbComisionesTipo_Internalname, context.GetMessage( "Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbComisionesTipo, cmbComisionesTipo_Internalname, StringUtil.RTrim( A505ComisionesTipo), 1, cmbComisionesTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbComisionesTipo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_Comisiones.htm");
         cmbComisionesTipo.CurrentValue = StringUtil.RTrim( A505ComisionesTipo);
         AssignProp("", false, cmbComisionesTipo_Internalname, "Values", (string)(cmbComisionesTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtComisionesNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComisionesNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComisionesNombre_Internalname, StringUtil.RTrim( A504ComisionesNombre), StringUtil.RTrim( context.localUtil.Format( A504ComisionesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtComisionesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Comisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtComisionesDefault_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComisionesDefault_Internalname, context.GetMessage( "Comisión por Defecto %", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComisionesDefault_Internalname, StringUtil.LTrim( StringUtil.NToC( A506ComisionesDefault, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtComisionesDefault_Enabled!=0) ? context.localUtil.Format( A506ComisionesDefault, "ZZ9.99") : context.localUtil.Format( A506ComisionesDefault, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesDefault_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtComisionesDefault_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divComisionesglobal_cell_Internalname, 1, 0, "px", 0, "px", divComisionesglobal_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", chkComisionesGlobal.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkComisionesGlobal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkComisionesGlobal_Internalname, context.GetMessage( "Comisión Global", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkComisionesGlobal_Internalname, StringUtil.BoolToStr( A520ComisionesGlobal), "", context.GetMessage( "Comisión Global", ""), chkComisionesGlobal.Visible, chkComisionesGlobal.Enabled, "true", context.GetMessage( "¿Es una comisión global?", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(49, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,49);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTb2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgComisionesImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen Promisional", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A519ComisionesImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ComisionesImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? A40000ComisionesImagen_GXI : context.PathToRelativeUrl( A519ComisionesImagen));
         GxWebStd.gx_bitmap( context, imgComisionesImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgComisionesImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", "", "", 0, A519ComisionesImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_Comisiones.htm");
         AssignProp("", false, imgComisionesImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? A40000ComisionesImagen_GXI : context.PathToRelativeUrl( A519ComisionesImagen)), true);
         AssignProp("", false, imgComisionesImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A519ComisionesImagen_IsBlob), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtComisionesComentario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComisionesComentario_Internalname, context.GetMessage( "Comentario", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtComisionesComentario_Internalname, A518ComisionesComentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", 0, 1, edtComisionesComentario_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Comisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTablevel_proveedores_title_Internalname, context.GetMessage( "Comercio | Proveedor", ""), "", "", lblTablevel_proveedores_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Comisiones.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "TabLevel_Proveedores") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabtablelevel_proveedores_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_proveedores_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_proveedores( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTablevel_profesionales_title_Internalname, context.GetMessage( "Profesionales", ""), "", "", lblTablevel_profesionales_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Comisiones.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "TabLevel_Profesionales") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabtablelevel_profesionales_Internalname, divTabtablelevel_profesionales_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_profesionales_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_profesionales( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Comisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Comisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Comisiones.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtComisionesFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtComisionesFechaAlta_Internalname, context.localUtil.TToC( A507ComisionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A507ComisionesFechaAlta, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesFechaAlta_Jsonclick, 0, "Attribute", "", "", "", "", edtComisionesFechaAlta_Visible, edtComisionesFechaAlta_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comisiones.htm");
         GxWebStd.gx_bitmap( context, edtComisionesFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtComisionesFechaAlta_Visible==0)||(edtComisionesFechaAlta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Comisiones.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComisionesEspermanente_Internalname, StringUtil.BoolToStr( A508ComisionesEspermanente), StringUtil.BoolToStr( A508ComisionesEspermanente), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesEspermanente_Jsonclick, 0, "Attribute", "", "", "", "", edtComisionesEspermanente_Visible, edtComisionesEspermanente_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "", "end", false, "", "HLP_Comisiones.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtComisionesFechaVigencia_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtComisionesFechaVigencia_Internalname, context.localUtil.TToC( A509ComisionesFechaVigencia, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A509ComisionesFechaVigencia, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesFechaVigencia_Jsonclick, 0, "Attribute", "", "", "", "", edtComisionesFechaVigencia_Visible, edtComisionesFechaVigencia_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comisiones.htm");
         GxWebStd.gx_bitmap( context, edtComisionesFechaVigencia_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtComisionesFechaVigencia_Visible==0)||(edtComisionesFechaVigencia_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Comisiones.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtComisionesFechaVencimiento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtComisionesFechaVencimiento_Internalname, context.localUtil.TToC( A510ComisionesFechaVencimiento, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A510ComisionesFechaVencimiento, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesFechaVencimiento_Jsonclick, 0, "Attribute", "", "", "", "", edtComisionesFechaVencimiento_Visible, edtComisionesFechaVencimiento_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comisiones.htm");
         GxWebStd.gx_bitmap( context, edtComisionesFechaVencimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtComisionesFechaVencimiento_Visible==0)||(edtComisionesFechaVencimiento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Comisiones.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComisionesInventarioEnum_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A512ComisionesInventarioEnum), 6, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtComisionesInventarioEnum_Enabled!=0) ? context.localUtil.Format( (decimal)(A512ComisionesInventarioEnum), "ZZZZZ9") : context.localUtil.Format( (decimal)(A512ComisionesInventarioEnum), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesInventarioEnum_Jsonclick, 0, "Attribute", "", "", "", "", edtComisionesInventarioEnum_Visible, edtComisionesInventarioEnum_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_proveedores( )
      {
         /*  Grid Control  */
         StartGridControl72( ) ;
         nGXsfl_72_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount75 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_75 = 1;
               ScanStart1W75( ) ;
               while ( RcdFound75 != 0 )
               {
                  init_level_properties75( ) ;
                  getByPrimaryKey1W75( ) ;
                  AddRow1W75( ) ;
                  ScanNext1W75( ) ;
               }
               ScanEnd1W75( ) ;
               nBlankRcdCount75 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1W75( ) ;
            standaloneModal1W75( ) ;
            sMode75 = Gx_mode;
            while ( nGXsfl_72_idx < nRC_GXsfl_72 )
            {
               bGXsfl_72_Refreshing = true;
               ReadRow1W75( ) ;
               dynProveedorID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORID_"+sGXsfl_72_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedorID.Enabled), 5, 0), !bGXsfl_72_Refreshing);
               edtProveedorEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDOREMAIL_"+sGXsfl_72_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorEmail_Enabled), 5, 0), !bGXsfl_72_Refreshing);
               edtProveedorTelefono_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORTELEFONO_"+sGXsfl_72_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorTelefono_Enabled), 5, 0), !bGXsfl_72_Refreshing);
               edtProveedorImagen_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORIMAGEN_"+sGXsfl_72_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorImagen_Enabled), 5, 0), !bGXsfl_72_Refreshing);
               cmbProveedorEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORESTADO_"+sGXsfl_72_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbProveedorEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorEstado.Enabled), 5, 0), !bGXsfl_72_Refreshing);
               if ( ( nRcdExists_75 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1W75( ) ;
               }
               SendRow1W75( ) ;
               bGXsfl_72_Refreshing = false;
            }
            Gx_mode = sMode75;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount75 = 5;
            nRcdExists_75 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1W75( ) ;
               while ( RcdFound75 != 0 )
               {
                  sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_7275( ) ;
                  init_level_properties75( ) ;
                  standaloneNotModal1W75( ) ;
                  getByPrimaryKey1W75( ) ;
                  standaloneModal1W75( ) ;
                  AddRow1W75( ) ;
                  ScanNext1W75( ) ;
               }
               ScanEnd1W75( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode75 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx+1), 4, 0), 4, "0");
            SubsflControlProps_7275( ) ;
            InitAll1W75( ) ;
            init_level_properties75( ) ;
            nRcdExists_75 = 0;
            nIsMod_75 = 0;
            nRcdDeleted_75 = 0;
            nBlankRcdCount75 = (short)(nBlankRcdUsr75+nBlankRcdCount75);
            fRowAdded = 0;
            while ( nBlankRcdCount75 > 0 )
            {
               standaloneNotModal1W75( ) ;
               standaloneModal1W75( ) ;
               AddRow1W75( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = dynProveedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount75 = (short)(nBlankRcdCount75-1);
            }
            Gx_mode = sMode75;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_proveedoresContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_proveedores", Gridlevel_proveedoresContainer, subGridlevel_proveedores_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_proveedoresContainerData", Gridlevel_proveedoresContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_proveedoresContainerData"+"V", Gridlevel_proveedoresContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_proveedoresContainerData"+"V"+"\" value='"+Gridlevel_proveedoresContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridlevel_profesionales( )
      {
         /*  Grid Control  */
         StartGridControl88( ) ;
         nGXsfl_88_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount76 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_76 = 1;
               ScanStart1W76( ) ;
               while ( RcdFound76 != 0 )
               {
                  init_level_properties76( ) ;
                  getByPrimaryKey1W76( ) ;
                  AddRow1W76( ) ;
                  ScanNext1W76( ) ;
               }
               ScanEnd1W76( ) ;
               nBlankRcdCount76 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1W76( ) ;
            standaloneModal1W76( ) ;
            sMode76 = Gx_mode;
            while ( nGXsfl_88_idx < nRC_GXsfl_88 )
            {
               bGXsfl_88_Refreshing = true;
               ReadRow1W76( ) ;
               edtProfesionalesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESID_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtProfesionalesPrimerNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesPrimerNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtProfesionalesSegundoNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesSegundoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesSegundoNombre_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtProfesionalesApellidoPrimero_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesApellidoPrimero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtProfesionalesApellidoSegundo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesApellidoSegundo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoSegundo_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtProfesionalesTelefono_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESTELEFONO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesTelefono_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtEstadosTipo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSTIPO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtEstadosGenericosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGENERICOSID_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtEstadosGenericosNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGENERICOSNOMBRE_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtEstadosGenericosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               imgprompt_120_Link = cgiGet( "PROMPT_120_"+sGXsfl_88_idx+"Link");
               if ( ( nRcdExists_76 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1W76( ) ;
               }
               SendRow1W76( ) ;
               bGXsfl_88_Refreshing = false;
            }
            Gx_mode = sMode76;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount76 = 5;
            nRcdExists_76 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1W76( ) ;
               while ( RcdFound76 != 0 )
               {
                  sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_8876( ) ;
                  init_level_properties76( ) ;
                  standaloneNotModal1W76( ) ;
                  getByPrimaryKey1W76( ) ;
                  standaloneModal1W76( ) ;
                  AddRow1W76( ) ;
                  ScanNext1W76( ) ;
               }
               ScanEnd1W76( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode76 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
            SubsflControlProps_8876( ) ;
            InitAll1W76( ) ;
            init_level_properties76( ) ;
            nRcdExists_76 = 0;
            nIsMod_76 = 0;
            nRcdDeleted_76 = 0;
            nBlankRcdCount76 = (short)(nBlankRcdUsr76+nBlankRcdCount76);
            fRowAdded = 0;
            while ( nBlankRcdCount76 > 0 )
            {
               standaloneNotModal1W76( ) ;
               standaloneModal1W76( ) ;
               AddRow1W76( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProfesionalesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount76 = (short)(nBlankRcdCount76-1);
            }
            Gx_mode = sMode76;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_profesionalesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_profesionales", Gridlevel_profesionalesContainer, subGridlevel_profesionales_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_profesionalesContainerData", Gridlevel_profesionalesContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_profesionalesContainerData"+"V", Gridlevel_profesionalesContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_profesionalesContainerData"+"V"+"\" value='"+Gridlevel_profesionalesContainer.GridValuesHidden()+"'/>") ;
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111W2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z503ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z503ComisionesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z504ComisionesNombre = cgiGet( "Z504ComisionesNombre");
               Z505ComisionesTipo = cgiGet( "Z505ComisionesTipo");
               Z506ComisionesDefault = context.localUtil.CToN( cgiGet( "Z506ComisionesDefault"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n506ComisionesDefault = ((Convert.ToDecimal(0)==A506ComisionesDefault) ? true : false);
               Z520ComisionesGlobal = StringUtil.StrToBool( cgiGet( "Z520ComisionesGlobal"));
               n520ComisionesGlobal = ((false==A520ComisionesGlobal) ? true : false);
               Z507ComisionesFechaAlta = context.localUtil.CToT( cgiGet( "Z507ComisionesFechaAlta"), 0);
               n507ComisionesFechaAlta = ((DateTime.MinValue==A507ComisionesFechaAlta) ? true : false);
               Z508ComisionesEspermanente = StringUtil.StrToBool( cgiGet( "Z508ComisionesEspermanente"));
               n508ComisionesEspermanente = ((false==A508ComisionesEspermanente) ? true : false);
               Z509ComisionesFechaVigencia = context.localUtil.CToT( cgiGet( "Z509ComisionesFechaVigencia"), 0);
               n509ComisionesFechaVigencia = ((DateTime.MinValue==A509ComisionesFechaVigencia) ? true : false);
               Z510ComisionesFechaVencimiento = context.localUtil.CToT( cgiGet( "Z510ComisionesFechaVencimiento"), 0);
               n510ComisionesFechaVencimiento = ((DateTime.MinValue==A510ComisionesFechaVencimiento) ? true : false);
               Z511ComisionesEstado = cgiGet( "Z511ComisionesEstado");
               n511ComisionesEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A511ComisionesEstado)) ? true : false);
               Z512ComisionesInventarioEnum = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z512ComisionesInventarioEnum"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n512ComisionesInventarioEnum = ((0==A512ComisionesInventarioEnum) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_72 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_72"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               nRC_GXsfl_88 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_88"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCOMISIONESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A40000ComisionesImagen_GXI = cgiGet( "COMISIONESIMAGEN_GXI");
               n40000ComisionesImagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000ComisionesImagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? true : false);
               AV20Pgmname = cgiGet( "vPGMNAME");
               A282ProveedorNombre = cgiGet( "PROVEEDORNOMBRE");
               A40001ProveedorImagen_GXI = cgiGet( "PROVEEDORIMAGEN_GXI");
               n40001ProveedorImagen_GXI = false;
               Gxuitabspanel_tabs_Objectcall = cgiGet( "GXUITABSPANEL_TABS_Objectcall");
               Gxuitabspanel_tabs_Enabled = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Enabled"));
               Gxuitabspanel_tabs_Activepage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Activepage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs_Activepagecontrolname = cgiGet( "GXUITABSPANEL_TABS_Activepagecontrolname");
               Gxuitabspanel_tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs_Class = cgiGet( "GXUITABSPANEL_TABS_Class");
               Gxuitabspanel_tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Historymanagement"));
               Gxuitabspanel_tabs_Visible = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Visible"));
               /* Read variables values. */
               A503ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtComisionesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
               cmbComisionesEstado.Name = cmbComisionesEstado_Internalname;
               cmbComisionesEstado.CurrentValue = cgiGet( cmbComisionesEstado_Internalname);
               A511ComisionesEstado = cgiGet( cmbComisionesEstado_Internalname);
               n511ComisionesEstado = false;
               AssignAttri("", false, "A511ComisionesEstado", A511ComisionesEstado);
               n511ComisionesEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A511ComisionesEstado)) ? true : false);
               cmbComisionesTipo.Name = cmbComisionesTipo_Internalname;
               cmbComisionesTipo.CurrentValue = cgiGet( cmbComisionesTipo_Internalname);
               A505ComisionesTipo = cgiGet( cmbComisionesTipo_Internalname);
               AssignAttri("", false, "A505ComisionesTipo", A505ComisionesTipo);
               A504ComisionesNombre = cgiGet( edtComisionesNombre_Internalname);
               AssignAttri("", false, "A504ComisionesNombre", A504ComisionesNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtComisionesDefault_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComisionesDefault_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMISIONESDEFAULT");
                  AnyError = 1;
                  GX_FocusControl = edtComisionesDefault_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A506ComisionesDefault = 0;
                  n506ComisionesDefault = false;
                  AssignAttri("", false, "A506ComisionesDefault", StringUtil.LTrimStr( A506ComisionesDefault, 6, 2));
               }
               else
               {
                  A506ComisionesDefault = context.localUtil.CToN( cgiGet( edtComisionesDefault_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  n506ComisionesDefault = false;
                  AssignAttri("", false, "A506ComisionesDefault", StringUtil.LTrimStr( A506ComisionesDefault, 6, 2));
               }
               n506ComisionesDefault = ((Convert.ToDecimal(0)==A506ComisionesDefault) ? true : false);
               A520ComisionesGlobal = StringUtil.StrToBool( cgiGet( chkComisionesGlobal_Internalname));
               n520ComisionesGlobal = false;
               AssignAttri("", false, "A520ComisionesGlobal", A520ComisionesGlobal);
               n520ComisionesGlobal = ((false==A520ComisionesGlobal) ? true : false);
               A519ComisionesImagen = cgiGet( imgComisionesImagen_Internalname);
               n519ComisionesImagen = false;
               AssignAttri("", false, "A519ComisionesImagen", A519ComisionesImagen);
               n519ComisionesImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? true : false);
               A518ComisionesComentario = cgiGet( edtComisionesComentario_Internalname);
               n518ComisionesComentario = false;
               AssignAttri("", false, "A518ComisionesComentario", A518ComisionesComentario);
               n518ComisionesComentario = (String.IsNullOrEmpty(StringUtil.RTrim( A518ComisionesComentario)) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtComisionesFechaAlta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Alta", "")}), 1, "COMISIONESFECHAALTA");
                  AnyError = 1;
                  GX_FocusControl = edtComisionesFechaAlta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A507ComisionesFechaAlta = (DateTime)(DateTime.MinValue);
                  n507ComisionesFechaAlta = false;
                  AssignAttri("", false, "A507ComisionesFechaAlta", context.localUtil.TToC( A507ComisionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A507ComisionesFechaAlta = context.localUtil.CToT( cgiGet( edtComisionesFechaAlta_Internalname));
                  n507ComisionesFechaAlta = false;
                  AssignAttri("", false, "A507ComisionesFechaAlta", context.localUtil.TToC( A507ComisionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               n507ComisionesFechaAlta = ((DateTime.MinValue==A507ComisionesFechaAlta) ? true : false);
               A508ComisionesEspermanente = StringUtil.StrToBool( cgiGet( edtComisionesEspermanente_Internalname));
               n508ComisionesEspermanente = false;
               AssignAttri("", false, "A508ComisionesEspermanente", A508ComisionesEspermanente);
               n508ComisionesEspermanente = ((false==A508ComisionesEspermanente) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtComisionesFechaVigencia_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha de vigencia", "")}), 1, "COMISIONESFECHAVIGENCIA");
                  AnyError = 1;
                  GX_FocusControl = edtComisionesFechaVigencia_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A509ComisionesFechaVigencia = (DateTime)(DateTime.MinValue);
                  n509ComisionesFechaVigencia = false;
                  AssignAttri("", false, "A509ComisionesFechaVigencia", context.localUtil.TToC( A509ComisionesFechaVigencia, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A509ComisionesFechaVigencia = context.localUtil.CToT( cgiGet( edtComisionesFechaVigencia_Internalname));
                  n509ComisionesFechaVigencia = false;
                  AssignAttri("", false, "A509ComisionesFechaVigencia", context.localUtil.TToC( A509ComisionesFechaVigencia, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               n509ComisionesFechaVigencia = ((DateTime.MinValue==A509ComisionesFechaVigencia) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtComisionesFechaVencimiento_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Vencimiento", "")}), 1, "COMISIONESFECHAVENCIMIENTO");
                  AnyError = 1;
                  GX_FocusControl = edtComisionesFechaVencimiento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A510ComisionesFechaVencimiento = (DateTime)(DateTime.MinValue);
                  n510ComisionesFechaVencimiento = false;
                  AssignAttri("", false, "A510ComisionesFechaVencimiento", context.localUtil.TToC( A510ComisionesFechaVencimiento, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A510ComisionesFechaVencimiento = context.localUtil.CToT( cgiGet( edtComisionesFechaVencimiento_Internalname));
                  n510ComisionesFechaVencimiento = false;
                  AssignAttri("", false, "A510ComisionesFechaVencimiento", context.localUtil.TToC( A510ComisionesFechaVencimiento, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               n510ComisionesFechaVencimiento = ((DateTime.MinValue==A510ComisionesFechaVencimiento) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtComisionesInventarioEnum_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComisionesInventarioEnum_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMISIONESINVENTARIOENUM");
                  AnyError = 1;
                  GX_FocusControl = edtComisionesInventarioEnum_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A512ComisionesInventarioEnum = 0;
                  n512ComisionesInventarioEnum = false;
                  AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
               }
               else
               {
                  A512ComisionesInventarioEnum = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtComisionesInventarioEnum_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n512ComisionesInventarioEnum = false;
                  AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
               }
               n512ComisionesInventarioEnum = ((0==A512ComisionesInventarioEnum) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgComisionesImagen_Internalname, ref  A519ComisionesImagen, ref  A40000ComisionesImagen_GXI);
               n40000ComisionesImagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000ComisionesImagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? true : false);
               n519ComisionesImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? true : false);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Comisiones");
               A503ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtComisionesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
               forbiddenHiddens.Add("ComisionesID", context.localUtil.Format( (decimal)(A503ComisionesID), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A503ComisionesID != Z503ComisionesID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("comisiones:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A503ComisionesID = (long)(Math.Round(NumberUtil.Val( GetPar( "ComisionesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode74 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode74;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound74 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1W0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "COMISIONESID");
                        AnyError = 1;
                        GX_FocusControl = edtComisionesID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E111W2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121W2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
            /* Execute user event: After Trn */
            E121W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1W74( ) ;
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
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes1W74( ) ;
         }
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

      protected void CONFIRM_1W0( )
      {
         BeforeValidate1W74( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1W74( ) ;
            }
            else
            {
               CheckExtendedTable1W74( ) ;
               CloseExtendedTableCursors1W74( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode74 = Gx_mode;
            CONFIRM_1W75( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_1W76( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode74;
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  IsConfirmed = 1;
                  AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode74;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_1W76( )
      {
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow1W76( ) ;
            if ( ( nRcdExists_76 != 0 ) || ( nIsMod_76 != 0 ) )
            {
               GetKey1W76( ) ;
               if ( ( nRcdExists_76 == 0 ) && ( nRcdDeleted_76 == 0 ) )
               {
                  if ( RcdFound76 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1W76( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1W76( ) ;
                        CloseExtendedTableCursors1W76( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PROFESIONALESID_" + sGXsfl_88_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProfesionalesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound76 != 0 )
                  {
                     if ( nRcdDeleted_76 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1W76( ) ;
                        Load1W76( ) ;
                        BeforeValidate1W76( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1W76( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_76 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1W76( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1W76( ) ;
                              CloseExtendedTableCursors1W76( ) ;
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
                     if ( nRcdDeleted_76 == 0 )
                     {
                        GXCCtl = "PROFESIONALESID_" + sGXsfl_88_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProfesionalesId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProfesionalesId_Internalname, StringUtil.RTrim( A120ProfesionalesId)) ;
            ChangePostValue( edtProfesionalesPrimerNombre_Internalname, StringUtil.RTrim( A166ProfesionalesPrimerNombre)) ;
            ChangePostValue( edtProfesionalesSegundoNombre_Internalname, StringUtil.RTrim( A191ProfesionalesSegundoNombre)) ;
            ChangePostValue( edtProfesionalesApellidoPrimero_Internalname, StringUtil.RTrim( A167ProfesionalesApellidoPrimero)) ;
            ChangePostValue( edtProfesionalesApellidoSegundo_Internalname, StringUtil.RTrim( A192ProfesionalesApellidoSegundo)) ;
            ChangePostValue( edtProfesionalesTelefono_Internalname, StringUtil.RTrim( A170ProfesionalesTelefono)) ;
            ChangePostValue( edtEstadosTipo_Internalname, StringUtil.RTrim( A107EstadosTipo)) ;
            ChangePostValue( edtEstadosGenericosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtEstadosGenericosNombre_Internalname, StringUtil.RTrim( A109EstadosGenericosNombre)) ;
            ChangePostValue( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_88_idx, StringUtil.RTrim( Z120ProfesionalesId)) ;
            ChangePostValue( "nRcdDeleted_76_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_76), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_76_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_76), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_76_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_76), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_76 != 0 )
            {
               ChangePostValue( "PROFESIONALESID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesSegundoNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoSegundo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESTELEFONO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesTelefono_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSTIPO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosTipo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGENERICOSID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGENERICOSNOMBRE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_1W75( )
      {
         nGXsfl_72_idx = 0;
         while ( nGXsfl_72_idx < nRC_GXsfl_72 )
         {
            ReadRow1W75( ) ;
            if ( ( nRcdExists_75 != 0 ) || ( nIsMod_75 != 0 ) )
            {
               GetKey1W75( ) ;
               if ( ( nRcdExists_75 == 0 ) && ( nRcdDeleted_75 == 0 ) )
               {
                  if ( RcdFound75 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1W75( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1W75( ) ;
                        CloseExtendedTableCursors1W75( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PROVEEDORID_" + sGXsfl_72_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = dynProveedorID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound75 != 0 )
                  {
                     if ( nRcdDeleted_75 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1W75( ) ;
                        Load1W75( ) ;
                        BeforeValidate1W75( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1W75( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_75 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1W75( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1W75( ) ;
                              CloseExtendedTableCursors1W75( ) ;
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
                     if ( nRcdDeleted_75 == 0 )
                     {
                        GXCCtl = "PROVEEDORID_" + sGXsfl_72_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = dynProveedorID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( dynProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))) ;
            ChangePostValue( edtProveedorEmail_Internalname, A433ProveedorEmail) ;
            ChangePostValue( edtProveedorTelefono_Internalname, StringUtil.RTrim( A430ProveedorTelefono)) ;
            ChangePostValue( edtProveedorImagen_Internalname, A432ProveedorImagen) ;
            ChangePostValue( cmbProveedorEstado_Internalname, StringUtil.RTrim( A344ProveedorEstado)) ;
            ChangePostValue( "ZT_"+"Z133ProveedorID_"+sGXsfl_72_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_75_"+sGXsfl_72_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_75), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_75_"+sGXsfl_72_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_75), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_75_"+sGXsfl_72_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_75), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_75 != 0 )
            {
               ChangePostValue( "PROVEEDORID_"+sGXsfl_72_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynProveedorID.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDOREMAIL_"+sGXsfl_72_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORTELEFONO_"+sGXsfl_72_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorTelefono_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORIMAGEN_"+sGXsfl_72_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorImagen_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORESTADO_"+sGXsfl_72_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProveedorEstado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1W0( )
      {
      }

      protected void E111W2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV11WWPContext) ;
         AV8IsAuthorized = true;
         AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisiones_Insert", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisiones_Update", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisiones_Delete", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV20Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtComisionesFechaAlta_Visible = 0;
         AssignProp("", false, edtComisionesFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtComisionesFechaAlta_Visible), 5, 0), true);
         edtComisionesEspermanente_Visible = 0;
         AssignProp("", false, edtComisionesEspermanente_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtComisionesEspermanente_Visible), 5, 0), true);
         edtComisionesFechaVigencia_Visible = 0;
         AssignProp("", false, edtComisionesFechaVigencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtComisionesFechaVigencia_Visible), 5, 0), true);
         edtComisionesFechaVencimiento_Visible = 0;
         AssignProp("", false, edtComisionesFechaVencimiento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtComisionesFechaVencimiento_Visible), 5, 0), true);
         edtComisionesInventarioEnum_Visible = 0;
         AssignProp("", false, edtComisionesInventarioEnum_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtComisionesInventarioEnum_Visible), 5, 0), true);
      }

      protected void E121W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("comisionesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         chkComisionesGlobal.Visible = 0;
         AssignProp("", false, chkComisionesGlobal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkComisionesGlobal.Visible), 5, 0), true);
         divComisionesglobal_cell_Class = "Invisible";
         AssignProp("", false, divComisionesglobal_cell_Internalname, "Class", divComisionesglobal_cell_Class, true);
      }

      protected void ZM1W74( short GX_JID )
      {
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z504ComisionesNombre = T001W10_A504ComisionesNombre[0];
               Z505ComisionesTipo = T001W10_A505ComisionesTipo[0];
               Z506ComisionesDefault = T001W10_A506ComisionesDefault[0];
               Z520ComisionesGlobal = T001W10_A520ComisionesGlobal[0];
               Z507ComisionesFechaAlta = T001W10_A507ComisionesFechaAlta[0];
               Z508ComisionesEspermanente = T001W10_A508ComisionesEspermanente[0];
               Z509ComisionesFechaVigencia = T001W10_A509ComisionesFechaVigencia[0];
               Z510ComisionesFechaVencimiento = T001W10_A510ComisionesFechaVencimiento[0];
               Z511ComisionesEstado = T001W10_A511ComisionesEstado[0];
               Z512ComisionesInventarioEnum = T001W10_A512ComisionesInventarioEnum[0];
            }
            else
            {
               Z504ComisionesNombre = A504ComisionesNombre;
               Z505ComisionesTipo = A505ComisionesTipo;
               Z506ComisionesDefault = A506ComisionesDefault;
               Z520ComisionesGlobal = A520ComisionesGlobal;
               Z507ComisionesFechaAlta = A507ComisionesFechaAlta;
               Z508ComisionesEspermanente = A508ComisionesEspermanente;
               Z509ComisionesFechaVigencia = A509ComisionesFechaVigencia;
               Z510ComisionesFechaVencimiento = A510ComisionesFechaVencimiento;
               Z511ComisionesEstado = A511ComisionesEstado;
               Z512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
            }
         }
         if ( GX_JID == -19 )
         {
            Z503ComisionesID = A503ComisionesID;
            Z504ComisionesNombre = A504ComisionesNombre;
            Z505ComisionesTipo = A505ComisionesTipo;
            Z519ComisionesImagen = A519ComisionesImagen;
            Z40000ComisionesImagen_GXI = A40000ComisionesImagen_GXI;
            Z506ComisionesDefault = A506ComisionesDefault;
            Z520ComisionesGlobal = A520ComisionesGlobal;
            Z507ComisionesFechaAlta = A507ComisionesFechaAlta;
            Z508ComisionesEspermanente = A508ComisionesEspermanente;
            Z509ComisionesFechaVigencia = A509ComisionesFechaVigencia;
            Z510ComisionesFechaVencimiento = A510ComisionesFechaVencimiento;
            Z511ComisionesEstado = A511ComisionesEstado;
            Z518ComisionesComentario = A518ComisionesComentario;
            Z512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
         }
      }

      protected void standaloneNotModal( )
      {
         edtComisionesID_Enabled = 0;
         AssignProp("", false, edtComisionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesID_Enabled), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            cmbComisionesTipo.Enabled = 0;
            AssignProp("", false, cmbComisionesTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbComisionesTipo.Enabled), 5, 0), true);
         }
         else
         {
            cmbComisionesTipo.Enabled = 1;
            AssignProp("", false, cmbComisionesTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbComisionesTipo.Enabled), 5, 0), true);
         }
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtComisionesID_Enabled = 0;
         AssignProp("", false, edtComisionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesID_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ComisionesID) )
         {
            A503ComisionesID = AV7ComisionesID;
            AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            cmbComisionesTipo.Enabled = 0;
            AssignProp("", false, cmbComisionesTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbComisionesTipo.Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A505ComisionesTipo)) && ( Gx_BScreen == 0 ) )
         {
            A505ComisionesTipo = "C";
            AssignAttri("", false, "A505ComisionesTipo", A505ComisionesTipo);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A511ComisionesEstado)) && ( Gx_BScreen == 0 ) )
         {
            A511ComisionesEstado = "HAB";
            n511ComisionesEstado = false;
            AssignAttri("", false, "A511ComisionesEstado", A511ComisionesEstado);
         }
         if ( IsIns( )  && (DateTime.MinValue==A507ComisionesFechaAlta) && ( Gx_BScreen == 0 ) )
         {
            A507ComisionesFechaAlta = DateTimeUtil.Now( context);
            n507ComisionesFechaAlta = false;
            AssignAttri("", false, "A507ComisionesFechaAlta", context.localUtil.TToC( A507ComisionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         if ( IsIns( )  && (false==A520ComisionesGlobal) && ( Gx_BScreen == 0 ) )
         {
            A520ComisionesGlobal = false;
            n520ComisionesGlobal = false;
            AssignAttri("", false, "A520ComisionesGlobal", A520ComisionesGlobal);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV20Pgmname = "Comisiones";
            AssignAttri("", false, "AV20Pgmname", AV20Pgmname);
            chkComisionesGlobal.Visible = ((StringUtil.StrCmp(A505ComisionesTipo, "P")==0) ? 1 : 0);
            AssignProp("", false, chkComisionesGlobal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkComisionesGlobal.Visible), 5, 0), true);
            if ( ! ( ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) ) )
            {
               divComisionesglobal_cell_Class = context.GetMessage( "Invisible", "");
               AssignProp("", false, divComisionesglobal_cell_Internalname, "Class", divComisionesglobal_cell_Class, true);
            }
            else
            {
               if ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 )
               {
                  divComisionesglobal_cell_Class = context.GetMessage( "col-xs-12 DataContentCellFL", "");
                  AssignProp("", false, divComisionesglobal_cell_Internalname, "Class", divComisionesglobal_cell_Class, true);
               }
            }
            divTabtablelevel_profesionales_Visible = (((StringUtil.StrCmp(A505ComisionesTipo, "P")==0)) ? 1 : 0);
            AssignProp("", false, divTabtablelevel_profesionales_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTabtablelevel_profesionales_Visible), 5, 0), true);
         }
      }

      protected void Load1W74( )
      {
         /* Using cursor T001W11 */
         pr_default.execute(9, new Object[] {A503ComisionesID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound74 = 1;
            A504ComisionesNombre = T001W11_A504ComisionesNombre[0];
            AssignAttri("", false, "A504ComisionesNombre", A504ComisionesNombre);
            A505ComisionesTipo = T001W11_A505ComisionesTipo[0];
            AssignAttri("", false, "A505ComisionesTipo", A505ComisionesTipo);
            A40000ComisionesImagen_GXI = T001W11_A40000ComisionesImagen_GXI[0];
            n40000ComisionesImagen_GXI = T001W11_n40000ComisionesImagen_GXI[0];
            AssignProp("", false, imgComisionesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? A40000ComisionesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A519ComisionesImagen))), true);
            AssignProp("", false, imgComisionesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A519ComisionesImagen), true);
            A506ComisionesDefault = T001W11_A506ComisionesDefault[0];
            n506ComisionesDefault = T001W11_n506ComisionesDefault[0];
            AssignAttri("", false, "A506ComisionesDefault", StringUtil.LTrimStr( A506ComisionesDefault, 6, 2));
            A520ComisionesGlobal = T001W11_A520ComisionesGlobal[0];
            n520ComisionesGlobal = T001W11_n520ComisionesGlobal[0];
            AssignAttri("", false, "A520ComisionesGlobal", A520ComisionesGlobal);
            A507ComisionesFechaAlta = T001W11_A507ComisionesFechaAlta[0];
            n507ComisionesFechaAlta = T001W11_n507ComisionesFechaAlta[0];
            AssignAttri("", false, "A507ComisionesFechaAlta", context.localUtil.TToC( A507ComisionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A508ComisionesEspermanente = T001W11_A508ComisionesEspermanente[0];
            n508ComisionesEspermanente = T001W11_n508ComisionesEspermanente[0];
            AssignAttri("", false, "A508ComisionesEspermanente", A508ComisionesEspermanente);
            A509ComisionesFechaVigencia = T001W11_A509ComisionesFechaVigencia[0];
            n509ComisionesFechaVigencia = T001W11_n509ComisionesFechaVigencia[0];
            AssignAttri("", false, "A509ComisionesFechaVigencia", context.localUtil.TToC( A509ComisionesFechaVigencia, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A510ComisionesFechaVencimiento = T001W11_A510ComisionesFechaVencimiento[0];
            n510ComisionesFechaVencimiento = T001W11_n510ComisionesFechaVencimiento[0];
            AssignAttri("", false, "A510ComisionesFechaVencimiento", context.localUtil.TToC( A510ComisionesFechaVencimiento, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A511ComisionesEstado = T001W11_A511ComisionesEstado[0];
            n511ComisionesEstado = T001W11_n511ComisionesEstado[0];
            AssignAttri("", false, "A511ComisionesEstado", A511ComisionesEstado);
            A518ComisionesComentario = T001W11_A518ComisionesComentario[0];
            n518ComisionesComentario = T001W11_n518ComisionesComentario[0];
            AssignAttri("", false, "A518ComisionesComentario", A518ComisionesComentario);
            A512ComisionesInventarioEnum = T001W11_A512ComisionesInventarioEnum[0];
            n512ComisionesInventarioEnum = T001W11_n512ComisionesInventarioEnum[0];
            AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
            A519ComisionesImagen = T001W11_A519ComisionesImagen[0];
            n519ComisionesImagen = T001W11_n519ComisionesImagen[0];
            AssignAttri("", false, "A519ComisionesImagen", A519ComisionesImagen);
            AssignProp("", false, imgComisionesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? A40000ComisionesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A519ComisionesImagen))), true);
            AssignProp("", false, imgComisionesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A519ComisionesImagen), true);
            ZM1W74( -19) ;
         }
         pr_default.close(9);
         OnLoadActions1W74( ) ;
      }

      protected void OnLoadActions1W74( )
      {
         AV20Pgmname = "Comisiones";
         AssignAttri("", false, "AV20Pgmname", AV20Pgmname);
         chkComisionesGlobal.Visible = ((StringUtil.StrCmp(A505ComisionesTipo, "P")==0) ? 1 : 0);
         AssignProp("", false, chkComisionesGlobal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkComisionesGlobal.Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) ) )
         {
            divComisionesglobal_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divComisionesglobal_cell_Internalname, "Class", divComisionesglobal_cell_Class, true);
         }
         else
         {
            if ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 )
            {
               divComisionesglobal_cell_Class = context.GetMessage( "col-xs-12 DataContentCellFL", "");
               AssignProp("", false, divComisionesglobal_cell_Internalname, "Class", divComisionesglobal_cell_Class, true);
            }
         }
         divTabtablelevel_profesionales_Visible = (((StringUtil.StrCmp(A505ComisionesTipo, "P")==0)) ? 1 : 0);
         AssignProp("", false, divTabtablelevel_profesionales_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTabtablelevel_profesionales_Visible), 5, 0), true);
      }

      protected void CheckExtendedTable1W74( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV20Pgmname = "Comisiones";
         AssignAttri("", false, "AV20Pgmname", AV20Pgmname);
         if ( ! ( ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) || ( StringUtil.StrCmp(A505ComisionesTipo, "C") == 0 ) || ( StringUtil.StrCmp(A505ComisionesTipo, "Z") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Tipo", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "COMISIONESTIPO");
            AnyError = 1;
            GX_FocusControl = cmbComisionesTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         chkComisionesGlobal.Visible = ((StringUtil.StrCmp(A505ComisionesTipo, "P")==0) ? 1 : 0);
         AssignProp("", false, chkComisionesGlobal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkComisionesGlobal.Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) ) )
         {
            divComisionesglobal_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divComisionesglobal_cell_Internalname, "Class", divComisionesglobal_cell_Class, true);
         }
         else
         {
            if ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 )
            {
               divComisionesglobal_cell_Class = context.GetMessage( "col-xs-12 DataContentCellFL", "");
               AssignProp("", false, divComisionesglobal_cell_Internalname, "Class", divComisionesglobal_cell_Class, true);
            }
         }
         divTabtablelevel_profesionales_Visible = (((StringUtil.StrCmp(A505ComisionesTipo, "P")==0)) ? 1 : 0);
         AssignProp("", false, divTabtablelevel_profesionales_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTabtablelevel_profesionales_Visible), 5, 0), true);
         if ( ! ( (DateTime.MinValue==A507ComisionesFechaAlta) || ( A507ComisionesFechaAlta >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Alta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "COMISIONESFECHAALTA");
            AnyError = 1;
            GX_FocusControl = edtComisionesFechaAlta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A509ComisionesFechaVigencia) || ( A509ComisionesFechaVigencia >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha de vigencia", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "COMISIONESFECHAVIGENCIA");
            AnyError = 1;
            GX_FocusControl = edtComisionesFechaVigencia_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A510ComisionesFechaVencimiento) || ( A510ComisionesFechaVencimiento >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Vencimiento", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "COMISIONESFECHAVENCIMIENTO");
            AnyError = 1;
            GX_FocusControl = edtComisionesFechaVencimiento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A511ComisionesEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A511ComisionesEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A511ComisionesEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A511ComisionesEstado, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A511ComisionesEstado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "COMISIONESESTADO");
            AnyError = 1;
            GX_FocusControl = cmbComisionesEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1W74( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1W74( )
      {
         /* Using cursor T001W12 */
         pr_default.execute(10, new Object[] {A503ComisionesID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound74 = 1;
         }
         else
         {
            RcdFound74 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001W10 */
         pr_default.execute(8, new Object[] {A503ComisionesID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            ZM1W74( 19) ;
            RcdFound74 = 1;
            A503ComisionesID = T001W10_A503ComisionesID[0];
            AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
            A504ComisionesNombre = T001W10_A504ComisionesNombre[0];
            AssignAttri("", false, "A504ComisionesNombre", A504ComisionesNombre);
            A505ComisionesTipo = T001W10_A505ComisionesTipo[0];
            AssignAttri("", false, "A505ComisionesTipo", A505ComisionesTipo);
            A40000ComisionesImagen_GXI = T001W10_A40000ComisionesImagen_GXI[0];
            n40000ComisionesImagen_GXI = T001W10_n40000ComisionesImagen_GXI[0];
            AssignProp("", false, imgComisionesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? A40000ComisionesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A519ComisionesImagen))), true);
            AssignProp("", false, imgComisionesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A519ComisionesImagen), true);
            A506ComisionesDefault = T001W10_A506ComisionesDefault[0];
            n506ComisionesDefault = T001W10_n506ComisionesDefault[0];
            AssignAttri("", false, "A506ComisionesDefault", StringUtil.LTrimStr( A506ComisionesDefault, 6, 2));
            A520ComisionesGlobal = T001W10_A520ComisionesGlobal[0];
            n520ComisionesGlobal = T001W10_n520ComisionesGlobal[0];
            AssignAttri("", false, "A520ComisionesGlobal", A520ComisionesGlobal);
            A507ComisionesFechaAlta = T001W10_A507ComisionesFechaAlta[0];
            n507ComisionesFechaAlta = T001W10_n507ComisionesFechaAlta[0];
            AssignAttri("", false, "A507ComisionesFechaAlta", context.localUtil.TToC( A507ComisionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A508ComisionesEspermanente = T001W10_A508ComisionesEspermanente[0];
            n508ComisionesEspermanente = T001W10_n508ComisionesEspermanente[0];
            AssignAttri("", false, "A508ComisionesEspermanente", A508ComisionesEspermanente);
            A509ComisionesFechaVigencia = T001W10_A509ComisionesFechaVigencia[0];
            n509ComisionesFechaVigencia = T001W10_n509ComisionesFechaVigencia[0];
            AssignAttri("", false, "A509ComisionesFechaVigencia", context.localUtil.TToC( A509ComisionesFechaVigencia, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A510ComisionesFechaVencimiento = T001W10_A510ComisionesFechaVencimiento[0];
            n510ComisionesFechaVencimiento = T001W10_n510ComisionesFechaVencimiento[0];
            AssignAttri("", false, "A510ComisionesFechaVencimiento", context.localUtil.TToC( A510ComisionesFechaVencimiento, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A511ComisionesEstado = T001W10_A511ComisionesEstado[0];
            n511ComisionesEstado = T001W10_n511ComisionesEstado[0];
            AssignAttri("", false, "A511ComisionesEstado", A511ComisionesEstado);
            A518ComisionesComentario = T001W10_A518ComisionesComentario[0];
            n518ComisionesComentario = T001W10_n518ComisionesComentario[0];
            AssignAttri("", false, "A518ComisionesComentario", A518ComisionesComentario);
            A512ComisionesInventarioEnum = T001W10_A512ComisionesInventarioEnum[0];
            n512ComisionesInventarioEnum = T001W10_n512ComisionesInventarioEnum[0];
            AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
            A519ComisionesImagen = T001W10_A519ComisionesImagen[0];
            n519ComisionesImagen = T001W10_n519ComisionesImagen[0];
            AssignAttri("", false, "A519ComisionesImagen", A519ComisionesImagen);
            AssignProp("", false, imgComisionesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? A40000ComisionesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A519ComisionesImagen))), true);
            AssignProp("", false, imgComisionesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A519ComisionesImagen), true);
            Z503ComisionesID = A503ComisionesID;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1W74( ) ;
            if ( AnyError == 1 )
            {
               RcdFound74 = 0;
               InitializeNonKey1W74( ) ;
            }
            Gx_mode = sMode74;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound74 = 0;
            InitializeNonKey1W74( ) ;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode74;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(8);
      }

      protected void getEqualNoModal( )
      {
         GetKey1W74( ) ;
         if ( RcdFound74 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound74 = 0;
         /* Using cursor T001W13 */
         pr_default.execute(11, new Object[] {A503ComisionesID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T001W13_A503ComisionesID[0] < A503ComisionesID ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T001W13_A503ComisionesID[0] > A503ComisionesID ) ) )
            {
               A503ComisionesID = T001W13_A503ComisionesID[0];
               AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
               RcdFound74 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void move_previous( )
      {
         RcdFound74 = 0;
         /* Using cursor T001W14 */
         pr_default.execute(12, new Object[] {A503ComisionesID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T001W14_A503ComisionesID[0] > A503ComisionesID ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T001W14_A503ComisionesID[0] < A503ComisionesID ) ) )
            {
               A503ComisionesID = T001W14_A503ComisionesID[0];
               AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
               RcdFound74 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1W74( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbComisionesEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1W74( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound74 == 1 )
            {
               if ( A503ComisionesID != Z503ComisionesID )
               {
                  A503ComisionesID = Z503ComisionesID;
                  AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COMISIONESID");
                  AnyError = 1;
                  GX_FocusControl = edtComisionesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbComisionesEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1W74( ) ;
                  GX_FocusControl = cmbComisionesEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A503ComisionesID != Z503ComisionesID )
               {
                  /* Insert record */
                  GX_FocusControl = cmbComisionesEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1W74( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COMISIONESID");
                     AnyError = 1;
                     GX_FocusControl = edtComisionesID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbComisionesEstado_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1W74( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A503ComisionesID != Z503ComisionesID )
         {
            A503ComisionesID = Z503ComisionesID;
            AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COMISIONESID");
            AnyError = 1;
            GX_FocusControl = edtComisionesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbComisionesEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1W74( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001W9 */
            pr_default.execute(7, new Object[] {A503ComisionesID});
            if ( (pr_default.getStatus(7) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Comisiones"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(7) == 101) || ( StringUtil.StrCmp(Z504ComisionesNombre, T001W9_A504ComisionesNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z505ComisionesTipo, T001W9_A505ComisionesTipo[0]) != 0 ) || ( Z506ComisionesDefault != T001W9_A506ComisionesDefault[0] ) || ( Z520ComisionesGlobal != T001W9_A520ComisionesGlobal[0] ) || ( Z507ComisionesFechaAlta != T001W9_A507ComisionesFechaAlta[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z508ComisionesEspermanente != T001W9_A508ComisionesEspermanente[0] ) || ( Z509ComisionesFechaVigencia != T001W9_A509ComisionesFechaVigencia[0] ) || ( Z510ComisionesFechaVencimiento != T001W9_A510ComisionesFechaVencimiento[0] ) || ( StringUtil.StrCmp(Z511ComisionesEstado, T001W9_A511ComisionesEstado[0]) != 0 ) || ( Z512ComisionesInventarioEnum != T001W9_A512ComisionesInventarioEnum[0] ) )
            {
               if ( StringUtil.StrCmp(Z504ComisionesNombre, T001W9_A504ComisionesNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("comisiones:[seudo value changed for attri]"+"ComisionesNombre");
                  GXUtil.WriteLogRaw("Old: ",Z504ComisionesNombre);
                  GXUtil.WriteLogRaw("Current: ",T001W9_A504ComisionesNombre[0]);
               }
               if ( StringUtil.StrCmp(Z505ComisionesTipo, T001W9_A505ComisionesTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("comisiones:[seudo value changed for attri]"+"ComisionesTipo");
                  GXUtil.WriteLogRaw("Old: ",Z505ComisionesTipo);
                  GXUtil.WriteLogRaw("Current: ",T001W9_A505ComisionesTipo[0]);
               }
               if ( Z506ComisionesDefault != T001W9_A506ComisionesDefault[0] )
               {
                  GXUtil.WriteLog("comisiones:[seudo value changed for attri]"+"ComisionesDefault");
                  GXUtil.WriteLogRaw("Old: ",Z506ComisionesDefault);
                  GXUtil.WriteLogRaw("Current: ",T001W9_A506ComisionesDefault[0]);
               }
               if ( Z520ComisionesGlobal != T001W9_A520ComisionesGlobal[0] )
               {
                  GXUtil.WriteLog("comisiones:[seudo value changed for attri]"+"ComisionesGlobal");
                  GXUtil.WriteLogRaw("Old: ",Z520ComisionesGlobal);
                  GXUtil.WriteLogRaw("Current: ",T001W9_A520ComisionesGlobal[0]);
               }
               if ( Z507ComisionesFechaAlta != T001W9_A507ComisionesFechaAlta[0] )
               {
                  GXUtil.WriteLog("comisiones:[seudo value changed for attri]"+"ComisionesFechaAlta");
                  GXUtil.WriteLogRaw("Old: ",Z507ComisionesFechaAlta);
                  GXUtil.WriteLogRaw("Current: ",T001W9_A507ComisionesFechaAlta[0]);
               }
               if ( Z508ComisionesEspermanente != T001W9_A508ComisionesEspermanente[0] )
               {
                  GXUtil.WriteLog("comisiones:[seudo value changed for attri]"+"ComisionesEspermanente");
                  GXUtil.WriteLogRaw("Old: ",Z508ComisionesEspermanente);
                  GXUtil.WriteLogRaw("Current: ",T001W9_A508ComisionesEspermanente[0]);
               }
               if ( Z509ComisionesFechaVigencia != T001W9_A509ComisionesFechaVigencia[0] )
               {
                  GXUtil.WriteLog("comisiones:[seudo value changed for attri]"+"ComisionesFechaVigencia");
                  GXUtil.WriteLogRaw("Old: ",Z509ComisionesFechaVigencia);
                  GXUtil.WriteLogRaw("Current: ",T001W9_A509ComisionesFechaVigencia[0]);
               }
               if ( Z510ComisionesFechaVencimiento != T001W9_A510ComisionesFechaVencimiento[0] )
               {
                  GXUtil.WriteLog("comisiones:[seudo value changed for attri]"+"ComisionesFechaVencimiento");
                  GXUtil.WriteLogRaw("Old: ",Z510ComisionesFechaVencimiento);
                  GXUtil.WriteLogRaw("Current: ",T001W9_A510ComisionesFechaVencimiento[0]);
               }
               if ( StringUtil.StrCmp(Z511ComisionesEstado, T001W9_A511ComisionesEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("comisiones:[seudo value changed for attri]"+"ComisionesEstado");
                  GXUtil.WriteLogRaw("Old: ",Z511ComisionesEstado);
                  GXUtil.WriteLogRaw("Current: ",T001W9_A511ComisionesEstado[0]);
               }
               if ( Z512ComisionesInventarioEnum != T001W9_A512ComisionesInventarioEnum[0] )
               {
                  GXUtil.WriteLog("comisiones:[seudo value changed for attri]"+"ComisionesInventarioEnum");
                  GXUtil.WriteLogRaw("Old: ",Z512ComisionesInventarioEnum);
                  GXUtil.WriteLogRaw("Current: ",T001W9_A512ComisionesInventarioEnum[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Comisiones"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1W74( )
      {
         BeforeValidate1W74( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W74( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1W74( 0) ;
            CheckOptimisticConcurrency1W74( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1W74( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1W74( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001W15 */
                     pr_default.execute(13, new Object[] {A504ComisionesNombre, A505ComisionesTipo, n519ComisionesImagen, A519ComisionesImagen, n40000ComisionesImagen_GXI, A40000ComisionesImagen_GXI, n506ComisionesDefault, A506ComisionesDefault, n520ComisionesGlobal, A520ComisionesGlobal, n507ComisionesFechaAlta, A507ComisionesFechaAlta, n508ComisionesEspermanente, A508ComisionesEspermanente, n509ComisionesFechaVigencia, A509ComisionesFechaVigencia, n510ComisionesFechaVencimiento, A510ComisionesFechaVencimiento, n511ComisionesEstado, A511ComisionesEstado, n518ComisionesComentario, A518ComisionesComentario, n512ComisionesInventarioEnum, A512ComisionesInventarioEnum});
                     A503ComisionesID = T001W15_A503ComisionesID[0];
                     AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Comisiones");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1W74( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1W0( ) ;
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
               Load1W74( ) ;
            }
            EndLevel1W74( ) ;
         }
         CloseExtendedTableCursors1W74( ) ;
      }

      protected void Update1W74( )
      {
         BeforeValidate1W74( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W74( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1W74( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1W74( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1W74( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001W16 */
                     pr_default.execute(14, new Object[] {A504ComisionesNombre, A505ComisionesTipo, n506ComisionesDefault, A506ComisionesDefault, n520ComisionesGlobal, A520ComisionesGlobal, n507ComisionesFechaAlta, A507ComisionesFechaAlta, n508ComisionesEspermanente, A508ComisionesEspermanente, n509ComisionesFechaVigencia, A509ComisionesFechaVigencia, n510ComisionesFechaVencimiento, A510ComisionesFechaVencimiento, n511ComisionesEstado, A511ComisionesEstado, n518ComisionesComentario, A518ComisionesComentario, n512ComisionesInventarioEnum, A512ComisionesInventarioEnum, A503ComisionesID});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Comisiones");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Comisiones"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1W74( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1W74( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
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
            }
            EndLevel1W74( ) ;
         }
         CloseExtendedTableCursors1W74( ) ;
      }

      protected void DeferredUpdate1W74( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001W17 */
            pr_default.execute(15, new Object[] {n519ComisionesImagen, A519ComisionesImagen, n40000ComisionesImagen_GXI, A40000ComisionesImagen_GXI, A503ComisionesID});
            pr_default.close(15);
            pr_default.SmartCacheProvider.SetUpdated("Comisiones");
         }
      }

      protected void delete( )
      {
         BeforeValidate1W74( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1W74( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1W74( ) ;
            AfterConfirm1W74( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1W74( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1W76( ) ;
                  while ( RcdFound76 != 0 )
                  {
                     getByPrimaryKey1W76( ) ;
                     Delete1W76( ) ;
                     ScanNext1W76( ) ;
                  }
                  ScanEnd1W76( ) ;
                  ScanStart1W75( ) ;
                  while ( RcdFound75 != 0 )
                  {
                     getByPrimaryKey1W75( ) ;
                     Delete1W75( ) ;
                     ScanNext1W75( ) ;
                  }
                  ScanEnd1W75( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001W18 */
                     pr_default.execute(16, new Object[] {A503ComisionesID});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Comisiones");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
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
            }
         }
         sMode74 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1W74( ) ;
         Gx_mode = sMode74;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1W74( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV20Pgmname = "Comisiones";
            AssignAttri("", false, "AV20Pgmname", AV20Pgmname);
            chkComisionesGlobal.Visible = ((StringUtil.StrCmp(A505ComisionesTipo, "P")==0) ? 1 : 0);
            AssignProp("", false, chkComisionesGlobal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkComisionesGlobal.Visible), 5, 0), true);
            if ( ! ( ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) ) )
            {
               divComisionesglobal_cell_Class = context.GetMessage( "Invisible", "");
               AssignProp("", false, divComisionesglobal_cell_Internalname, "Class", divComisionesglobal_cell_Class, true);
            }
            else
            {
               if ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 )
               {
                  divComisionesglobal_cell_Class = context.GetMessage( "col-xs-12 DataContentCellFL", "");
                  AssignProp("", false, divComisionesglobal_cell_Internalname, "Class", divComisionesglobal_cell_Class, true);
               }
            }
            divTabtablelevel_profesionales_Visible = (((StringUtil.StrCmp(A505ComisionesTipo, "P")==0)) ? 1 : 0);
            AssignProp("", false, divTabtablelevel_profesionales_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTabtablelevel_profesionales_Visible), 5, 0), true);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001W19 */
            pr_default.execute(17, new Object[] {A503ComisionesID});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void ProcessNestedLevel1W75( )
      {
         nGXsfl_72_idx = 0;
         while ( nGXsfl_72_idx < nRC_GXsfl_72 )
         {
            ReadRow1W75( ) ;
            if ( ( nRcdExists_75 != 0 ) || ( nIsMod_75 != 0 ) )
            {
               standaloneNotModal1W75( ) ;
               GetKey1W75( ) ;
               if ( ( nRcdExists_75 == 0 ) && ( nRcdDeleted_75 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1W75( ) ;
               }
               else
               {
                  if ( RcdFound75 != 0 )
                  {
                     if ( ( nRcdDeleted_75 != 0 ) && ( nRcdExists_75 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1W75( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_75 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1W75( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_75 == 0 )
                     {
                        GXCCtl = "PROVEEDORID_" + sGXsfl_72_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = dynProveedorID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( dynProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))) ;
            ChangePostValue( edtProveedorEmail_Internalname, A433ProveedorEmail) ;
            ChangePostValue( edtProveedorTelefono_Internalname, StringUtil.RTrim( A430ProveedorTelefono)) ;
            ChangePostValue( edtProveedorImagen_Internalname, A432ProveedorImagen) ;
            ChangePostValue( cmbProveedorEstado_Internalname, StringUtil.RTrim( A344ProveedorEstado)) ;
            ChangePostValue( "ZT_"+"Z133ProveedorID_"+sGXsfl_72_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_75_"+sGXsfl_72_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_75), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_75_"+sGXsfl_72_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_75), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_75_"+sGXsfl_72_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_75), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_75 != 0 )
            {
               ChangePostValue( "PROVEEDORID_"+sGXsfl_72_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynProveedorID.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDOREMAIL_"+sGXsfl_72_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORTELEFONO_"+sGXsfl_72_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorTelefono_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORIMAGEN_"+sGXsfl_72_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorImagen_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORESTADO_"+sGXsfl_72_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProveedorEstado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1W75( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_75 = 0;
         nIsMod_75 = 0;
         nRcdDeleted_75 = 0;
      }

      protected void ProcessNestedLevel1W76( )
      {
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow1W76( ) ;
            if ( ( nRcdExists_76 != 0 ) || ( nIsMod_76 != 0 ) )
            {
               standaloneNotModal1W76( ) ;
               GetKey1W76( ) ;
               if ( ( nRcdExists_76 == 0 ) && ( nRcdDeleted_76 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1W76( ) ;
               }
               else
               {
                  if ( RcdFound76 != 0 )
                  {
                     if ( ( nRcdDeleted_76 != 0 ) && ( nRcdExists_76 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1W76( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_76 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1W76( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_76 == 0 )
                     {
                        GXCCtl = "PROFESIONALESID_" + sGXsfl_88_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProfesionalesId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProfesionalesId_Internalname, StringUtil.RTrim( A120ProfesionalesId)) ;
            ChangePostValue( edtProfesionalesPrimerNombre_Internalname, StringUtil.RTrim( A166ProfesionalesPrimerNombre)) ;
            ChangePostValue( edtProfesionalesSegundoNombre_Internalname, StringUtil.RTrim( A191ProfesionalesSegundoNombre)) ;
            ChangePostValue( edtProfesionalesApellidoPrimero_Internalname, StringUtil.RTrim( A167ProfesionalesApellidoPrimero)) ;
            ChangePostValue( edtProfesionalesApellidoSegundo_Internalname, StringUtil.RTrim( A192ProfesionalesApellidoSegundo)) ;
            ChangePostValue( edtProfesionalesTelefono_Internalname, StringUtil.RTrim( A170ProfesionalesTelefono)) ;
            ChangePostValue( edtEstadosTipo_Internalname, StringUtil.RTrim( A107EstadosTipo)) ;
            ChangePostValue( edtEstadosGenericosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtEstadosGenericosNombre_Internalname, StringUtil.RTrim( A109EstadosGenericosNombre)) ;
            ChangePostValue( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_88_idx, StringUtil.RTrim( Z120ProfesionalesId)) ;
            ChangePostValue( "nRcdDeleted_76_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_76), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_76_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_76), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_76_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_76), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_76 != 0 )
            {
               ChangePostValue( "PROFESIONALESID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesSegundoNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoSegundo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESTELEFONO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesTelefono_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSTIPO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosTipo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGENERICOSID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGENERICOSNOMBRE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1W76( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_76 = 0;
         nIsMod_76 = 0;
         nRcdDeleted_76 = 0;
      }

      protected void ProcessLevel1W74( )
      {
         /* Save parent mode. */
         sMode74 = Gx_mode;
         ProcessNestedLevel1W75( ) ;
         ProcessNestedLevel1W76( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode74;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1W74( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(7);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1W74( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(8);
            pr_default.close(5);
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(6);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("comisiones",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(8);
            pr_default.close(5);
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(6);
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("comisiones",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1W74( )
      {
         /* Scan By routine */
         /* Using cursor T001W20 */
         pr_default.execute(18);
         RcdFound74 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound74 = 1;
            A503ComisionesID = T001W20_A503ComisionesID[0];
            AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1W74( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound74 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound74 = 1;
            A503ComisionesID = T001W20_A503ComisionesID[0];
            AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
         }
      }

      protected void ScanEnd1W74( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm1W74( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1W74( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1W74( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1W74( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1W74( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1W74( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1W74( )
      {
         edtComisionesID_Enabled = 0;
         AssignProp("", false, edtComisionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesID_Enabled), 5, 0), true);
         cmbComisionesEstado.Enabled = 0;
         AssignProp("", false, cmbComisionesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbComisionesEstado.Enabled), 5, 0), true);
         cmbComisionesTipo.Enabled = 0;
         AssignProp("", false, cmbComisionesTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbComisionesTipo.Enabled), 5, 0), true);
         edtComisionesNombre_Enabled = 0;
         AssignProp("", false, edtComisionesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesNombre_Enabled), 5, 0), true);
         edtComisionesDefault_Enabled = 0;
         AssignProp("", false, edtComisionesDefault_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesDefault_Enabled), 5, 0), true);
         chkComisionesGlobal.Enabled = 0;
         AssignProp("", false, chkComisionesGlobal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkComisionesGlobal.Enabled), 5, 0), true);
         imgComisionesImagen_Enabled = 0;
         AssignProp("", false, imgComisionesImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgComisionesImagen_Enabled), 5, 0), true);
         edtComisionesComentario_Enabled = 0;
         AssignProp("", false, edtComisionesComentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesComentario_Enabled), 5, 0), true);
         edtComisionesFechaAlta_Enabled = 0;
         AssignProp("", false, edtComisionesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesFechaAlta_Enabled), 5, 0), true);
         edtComisionesEspermanente_Enabled = 0;
         AssignProp("", false, edtComisionesEspermanente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesEspermanente_Enabled), 5, 0), true);
         edtComisionesFechaVigencia_Enabled = 0;
         AssignProp("", false, edtComisionesFechaVigencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesFechaVigencia_Enabled), 5, 0), true);
         edtComisionesFechaVencimiento_Enabled = 0;
         AssignProp("", false, edtComisionesFechaVencimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesFechaVencimiento_Enabled), 5, 0), true);
         edtComisionesInventarioEnum_Enabled = 0;
         AssignProp("", false, edtComisionesInventarioEnum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesInventarioEnum_Enabled), 5, 0), true);
      }

      protected void ZM1W75( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -20 )
         {
            Z503ComisionesID = A503ComisionesID;
            Z133ProveedorID = A133ProveedorID;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z433ProveedorEmail = A433ProveedorEmail;
            Z430ProveedorTelefono = A430ProveedorTelefono;
            Z432ProveedorImagen = A432ProveedorImagen;
            Z40001ProveedorImagen_GXI = A40001ProveedorImagen_GXI;
            Z344ProveedorEstado = A344ProveedorEstado;
         }
      }

      protected void standaloneNotModal1W75( )
      {
      }

      protected void standaloneModal1W75( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            dynProveedorID.Enabled = 0;
            AssignProp("", false, dynProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedorID.Enabled), 5, 0), !bGXsfl_72_Refreshing);
         }
         else
         {
            dynProveedorID.Enabled = 1;
            AssignProp("", false, dynProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedorID.Enabled), 5, 0), !bGXsfl_72_Refreshing);
         }
      }

      protected void Load1W75( )
      {
         /* Using cursor T001W21 */
         pr_default.execute(19, new Object[] {A503ComisionesID, A133ProveedorID});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound75 = 1;
            A282ProveedorNombre = T001W21_A282ProveedorNombre[0];
            A433ProveedorEmail = T001W21_A433ProveedorEmail[0];
            n433ProveedorEmail = T001W21_n433ProveedorEmail[0];
            A430ProveedorTelefono = T001W21_A430ProveedorTelefono[0];
            n430ProveedorTelefono = T001W21_n430ProveedorTelefono[0];
            A40001ProveedorImagen_GXI = T001W21_A40001ProveedorImagen_GXI[0];
            n40001ProveedorImagen_GXI = T001W21_n40001ProveedorImagen_GXI[0];
            AssignProp("", false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40001ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_72_Refreshing);
            AssignProp("", false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            A344ProveedorEstado = T001W21_A344ProveedorEstado[0];
            A432ProveedorImagen = T001W21_A432ProveedorImagen[0];
            n432ProveedorImagen = T001W21_n432ProveedorImagen[0];
            AssignProp("", false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40001ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_72_Refreshing);
            AssignProp("", false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            ZM1W75( -20) ;
         }
         pr_default.close(19);
         OnLoadActions1W75( ) ;
      }

      protected void OnLoadActions1W75( )
      {
      }

      protected void CheckExtendedTable1W75( )
      {
         nIsDirty_75 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1W75( ) ;
         /* Using cursor T001W8 */
         pr_default.execute(6, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GXCCtl = "PROVEEDORID_" + sGXsfl_72_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A282ProveedorNombre = T001W8_A282ProveedorNombre[0];
         A433ProveedorEmail = T001W8_A433ProveedorEmail[0];
         n433ProveedorEmail = T001W8_n433ProveedorEmail[0];
         A430ProveedorTelefono = T001W8_A430ProveedorTelefono[0];
         n430ProveedorTelefono = T001W8_n430ProveedorTelefono[0];
         A40001ProveedorImagen_GXI = T001W8_A40001ProveedorImagen_GXI[0];
         n40001ProveedorImagen_GXI = T001W8_n40001ProveedorImagen_GXI[0];
         AssignProp("", false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40001ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_72_Refreshing);
         AssignProp("", false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
         A344ProveedorEstado = T001W8_A344ProveedorEstado[0];
         A432ProveedorImagen = T001W8_A432ProveedorImagen[0];
         n432ProveedorImagen = T001W8_n432ProveedorImagen[0];
         AssignProp("", false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40001ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_72_Refreshing);
         AssignProp("", false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors1W75( )
      {
         pr_default.close(6);
      }

      protected void enableDisable1W75( )
      {
      }

      protected void gxLoad_21( long A133ProveedorID )
      {
         /* Using cursor T001W22 */
         pr_default.execute(20, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GXCCtl = "PROVEEDORID_" + sGXsfl_72_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A282ProveedorNombre = T001W22_A282ProveedorNombre[0];
         A433ProveedorEmail = T001W22_A433ProveedorEmail[0];
         n433ProveedorEmail = T001W22_n433ProveedorEmail[0];
         A430ProveedorTelefono = T001W22_A430ProveedorTelefono[0];
         n430ProveedorTelefono = T001W22_n430ProveedorTelefono[0];
         A40001ProveedorImagen_GXI = T001W22_A40001ProveedorImagen_GXI[0];
         n40001ProveedorImagen_GXI = T001W22_n40001ProveedorImagen_GXI[0];
         AssignProp("", false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40001ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_72_Refreshing);
         AssignProp("", false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
         A344ProveedorEstado = T001W22_A344ProveedorEstado[0];
         A432ProveedorImagen = T001W22_A432ProveedorImagen[0];
         n432ProveedorImagen = T001W22_n432ProveedorImagen[0];
         AssignProp("", false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40001ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_72_Refreshing);
         AssignProp("", false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A282ProveedorNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( A433ProveedorEmail)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A430ProveedorTelefono))+"\""+","+"\""+GXUtil.EncodeJSConstant( A432ProveedorImagen)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40001ProveedorImagen_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A344ProveedorEstado))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void GetKey1W75( )
      {
         /* Using cursor T001W23 */
         pr_default.execute(21, new Object[] {A503ComisionesID, A133ProveedorID});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound75 = 1;
         }
         else
         {
            RcdFound75 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey1W75( )
      {
         /* Using cursor T001W7 */
         pr_default.execute(5, new Object[] {A503ComisionesID, A133ProveedorID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM1W75( 20) ;
            RcdFound75 = 1;
            InitializeNonKey1W75( ) ;
            A133ProveedorID = T001W7_A133ProveedorID[0];
            Z503ComisionesID = A503ComisionesID;
            Z133ProveedorID = A133ProveedorID;
            sMode75 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1W75( ) ;
            Gx_mode = sMode75;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound75 = 0;
            InitializeNonKey1W75( ) ;
            sMode75 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1W75( ) ;
            Gx_mode = sMode75;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1W75( ) ;
         }
         pr_default.close(5);
      }

      protected void CheckOptimisticConcurrency1W75( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001W6 */
            pr_default.execute(4, new Object[] {A503ComisionesID, A133ProveedorID});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComisionesProveedores"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ComisionesProveedores"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1W75( )
      {
         BeforeValidate1W75( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W75( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1W75( 0) ;
            CheckOptimisticConcurrency1W75( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1W75( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1W75( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001W24 */
                     pr_default.execute(22, new Object[] {A503ComisionesID, A133ProveedorID});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("ComisionesProveedores");
                     if ( (pr_default.getStatus(22) == 1) )
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
               Load1W75( ) ;
            }
            EndLevel1W75( ) ;
         }
         CloseExtendedTableCursors1W75( ) ;
      }

      protected void Update1W75( )
      {
         BeforeValidate1W75( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W75( ) ;
         }
         if ( ( nIsMod_75 != 0 ) || ( nIsDirty_75 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1W75( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1W75( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1W75( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [ComisionesProveedores] */
                        DeferredUpdate1W75( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1W75( ) ;
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
               EndLevel1W75( ) ;
            }
         }
         CloseExtendedTableCursors1W75( ) ;
      }

      protected void DeferredUpdate1W75( )
      {
      }

      protected void Delete1W75( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1W75( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1W75( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1W75( ) ;
            AfterConfirm1W75( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1W75( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001W25 */
                  pr_default.execute(23, new Object[] {A503ComisionesID, A133ProveedorID});
                  pr_default.close(23);
                  pr_default.SmartCacheProvider.SetUpdated("ComisionesProveedores");
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
         sMode75 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1W75( ) ;
         Gx_mode = sMode75;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1W75( )
      {
         standaloneModal1W75( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001W26 */
            pr_default.execute(24, new Object[] {A133ProveedorID});
            A282ProveedorNombre = T001W26_A282ProveedorNombre[0];
            A433ProveedorEmail = T001W26_A433ProveedorEmail[0];
            n433ProveedorEmail = T001W26_n433ProveedorEmail[0];
            A430ProveedorTelefono = T001W26_A430ProveedorTelefono[0];
            n430ProveedorTelefono = T001W26_n430ProveedorTelefono[0];
            A40001ProveedorImagen_GXI = T001W26_A40001ProveedorImagen_GXI[0];
            n40001ProveedorImagen_GXI = T001W26_n40001ProveedorImagen_GXI[0];
            AssignProp("", false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40001ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_72_Refreshing);
            AssignProp("", false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            A344ProveedorEstado = T001W26_A344ProveedorEstado[0];
            A432ProveedorImagen = T001W26_A432ProveedorImagen[0];
            n432ProveedorImagen = T001W26_n432ProveedorImagen[0];
            AssignProp("", false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40001ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_72_Refreshing);
            AssignProp("", false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            pr_default.close(24);
         }
      }

      protected void EndLevel1W75( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1W75( )
      {
         /* Scan By routine */
         /* Using cursor T001W27 */
         pr_default.execute(25, new Object[] {A503ComisionesID});
         RcdFound75 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound75 = 1;
            A133ProveedorID = T001W27_A133ProveedorID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1W75( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound75 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound75 = 1;
            A133ProveedorID = T001W27_A133ProveedorID[0];
         }
      }

      protected void ScanEnd1W75( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm1W75( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1W75( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1W75( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1W75( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1W75( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1W75( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1W75( )
      {
         dynProveedorID.Enabled = 0;
         AssignProp("", false, dynProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedorID.Enabled), 5, 0), !bGXsfl_72_Refreshing);
         edtProveedorEmail_Enabled = 0;
         AssignProp("", false, edtProveedorEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorEmail_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         edtProveedorTelefono_Enabled = 0;
         AssignProp("", false, edtProveedorTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorTelefono_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         edtProveedorImagen_Enabled = 0;
         AssignProp("", false, edtProveedorImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorImagen_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         cmbProveedorEstado.Enabled = 0;
         AssignProp("", false, cmbProveedorEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorEstado.Enabled), 5, 0), !bGXsfl_72_Refreshing);
      }

      protected void send_integrity_lvl_hashes1W75( )
      {
      }

      protected void ZM1W76( short GX_JID )
      {
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -22 )
         {
            Z503ComisionesID = A503ComisionesID;
            Z120ProfesionalesId = A120ProfesionalesId;
            Z166ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
            Z191ProfesionalesSegundoNombre = A191ProfesionalesSegundoNombre;
            Z167ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
            Z192ProfesionalesApellidoSegundo = A192ProfesionalesApellidoSegundo;
            Z170ProfesionalesTelefono = A170ProfesionalesTelefono;
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
            Z109EstadosGenericosNombre = A109EstadosGenericosNombre;
         }
      }

      protected void standaloneNotModal1W76( )
      {
         edtEstadosTipo_Enabled = 0;
         AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtEstadosGenericosId_Enabled = 0;
         AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void standaloneModal1W76( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProfesionalesId_Enabled = 0;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
         else
         {
            edtProfesionalesId_Enabled = 1;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
      }

      protected void Load1W76( )
      {
         /* Using cursor T001W28 */
         pr_default.execute(26, new Object[] {A503ComisionesID, A120ProfesionalesId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound76 = 1;
            A166ProfesionalesPrimerNombre = T001W28_A166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = T001W28_A191ProfesionalesSegundoNombre[0];
            A167ProfesionalesApellidoPrimero = T001W28_A167ProfesionalesApellidoPrimero[0];
            A192ProfesionalesApellidoSegundo = T001W28_A192ProfesionalesApellidoSegundo[0];
            A170ProfesionalesTelefono = T001W28_A170ProfesionalesTelefono[0];
            A109EstadosGenericosNombre = T001W28_A109EstadosGenericosNombre[0];
            A107EstadosTipo = T001W28_A107EstadosTipo[0];
            A108EstadosGenericosId = T001W28_A108EstadosGenericosId[0];
            ZM1W76( -22) ;
         }
         pr_default.close(26);
         OnLoadActions1W76( ) ;
      }

      protected void OnLoadActions1W76( )
      {
      }

      protected void CheckExtendedTable1W76( )
      {
         nIsDirty_76 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1W76( ) ;
         /* Using cursor T001W4 */
         pr_default.execute(2, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PROFESIONALESID_" + sGXsfl_88_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A166ProfesionalesPrimerNombre = T001W4_A166ProfesionalesPrimerNombre[0];
         A191ProfesionalesSegundoNombre = T001W4_A191ProfesionalesSegundoNombre[0];
         A167ProfesionalesApellidoPrimero = T001W4_A167ProfesionalesApellidoPrimero[0];
         A192ProfesionalesApellidoSegundo = T001W4_A192ProfesionalesApellidoSegundo[0];
         A170ProfesionalesTelefono = T001W4_A170ProfesionalesTelefono[0];
         A107EstadosTipo = T001W4_A107EstadosTipo[0];
         A108EstadosGenericosId = T001W4_A108EstadosGenericosId[0];
         pr_default.close(2);
         /* Using cursor T001W5 */
         pr_default.execute(3, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "ESTADOSGENERICOSID_" + sGXsfl_88_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         A109EstadosGenericosNombre = T001W5_A109EstadosGenericosNombre[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1W76( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable1W76( )
      {
      }

      protected void gxLoad_23( string A120ProfesionalesId )
      {
         /* Using cursor T001W29 */
         pr_default.execute(27, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GXCCtl = "PROFESIONALESID_" + sGXsfl_88_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A166ProfesionalesPrimerNombre = T001W29_A166ProfesionalesPrimerNombre[0];
         A191ProfesionalesSegundoNombre = T001W29_A191ProfesionalesSegundoNombre[0];
         A167ProfesionalesApellidoPrimero = T001W29_A167ProfesionalesApellidoPrimero[0];
         A192ProfesionalesApellidoSegundo = T001W29_A192ProfesionalesApellidoSegundo[0];
         A170ProfesionalesTelefono = T001W29_A170ProfesionalesTelefono[0];
         A107EstadosTipo = T001W29_A107EstadosTipo[0];
         A108EstadosGenericosId = T001W29_A108EstadosGenericosId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A166ProfesionalesPrimerNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A191ProfesionalesSegundoNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A167ProfesionalesApellidoPrimero))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A192ProfesionalesApellidoSegundo))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A170ProfesionalesTelefono))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A107EstadosTipo))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(27) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(27);
      }

      protected void gxLoad_24( string A107EstadosTipo ,
                                int A108EstadosGenericosId )
      {
         /* Using cursor T001W30 */
         pr_default.execute(28, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GXCCtl = "ESTADOSGENERICOSID_" + sGXsfl_88_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         A109EstadosGenericosNombre = T001W30_A109EstadosGenericosNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A109EstadosGenericosNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(28) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(28);
      }

      protected void GetKey1W76( )
      {
         /* Using cursor T001W31 */
         pr_default.execute(29, new Object[] {A503ComisionesID, A120ProfesionalesId});
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound76 = 1;
         }
         else
         {
            RcdFound76 = 0;
         }
         pr_default.close(29);
      }

      protected void getByPrimaryKey1W76( )
      {
         /* Using cursor T001W3 */
         pr_default.execute(1, new Object[] {A503ComisionesID, A120ProfesionalesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1W76( 22) ;
            RcdFound76 = 1;
            InitializeNonKey1W76( ) ;
            A120ProfesionalesId = T001W3_A120ProfesionalesId[0];
            Z503ComisionesID = A503ComisionesID;
            Z120ProfesionalesId = A120ProfesionalesId;
            sMode76 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1W76( ) ;
            Gx_mode = sMode76;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound76 = 0;
            InitializeNonKey1W76( ) ;
            sMode76 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1W76( ) ;
            Gx_mode = sMode76;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1W76( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1W76( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001W2 */
            pr_default.execute(0, new Object[] {A503ComisionesID, A120ProfesionalesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComisionesProfesionales"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ComisionesProfesionales"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1W76( )
      {
         BeforeValidate1W76( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W76( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1W76( 0) ;
            CheckOptimisticConcurrency1W76( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1W76( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1W76( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001W32 */
                     pr_default.execute(30, new Object[] {A503ComisionesID, A120ProfesionalesId});
                     pr_default.close(30);
                     pr_default.SmartCacheProvider.SetUpdated("ComisionesProfesionales");
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
               Load1W76( ) ;
            }
            EndLevel1W76( ) ;
         }
         CloseExtendedTableCursors1W76( ) ;
      }

      protected void Update1W76( )
      {
         BeforeValidate1W76( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W76( ) ;
         }
         if ( ( nIsMod_76 != 0 ) || ( nIsDirty_76 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1W76( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1W76( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1W76( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [ComisionesProfesionales] */
                        DeferredUpdate1W76( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1W76( ) ;
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
               EndLevel1W76( ) ;
            }
         }
         CloseExtendedTableCursors1W76( ) ;
      }

      protected void DeferredUpdate1W76( )
      {
      }

      protected void Delete1W76( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1W76( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1W76( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1W76( ) ;
            AfterConfirm1W76( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1W76( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001W33 */
                  pr_default.execute(31, new Object[] {A503ComisionesID, A120ProfesionalesId});
                  pr_default.close(31);
                  pr_default.SmartCacheProvider.SetUpdated("ComisionesProfesionales");
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
         sMode76 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1W76( ) ;
         Gx_mode = sMode76;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1W76( )
      {
         standaloneModal1W76( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001W34 */
            pr_default.execute(32, new Object[] {A120ProfesionalesId});
            A166ProfesionalesPrimerNombre = T001W34_A166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = T001W34_A191ProfesionalesSegundoNombre[0];
            A167ProfesionalesApellidoPrimero = T001W34_A167ProfesionalesApellidoPrimero[0];
            A192ProfesionalesApellidoSegundo = T001W34_A192ProfesionalesApellidoSegundo[0];
            A170ProfesionalesTelefono = T001W34_A170ProfesionalesTelefono[0];
            A107EstadosTipo = T001W34_A107EstadosTipo[0];
            A108EstadosGenericosId = T001W34_A108EstadosGenericosId[0];
            pr_default.close(32);
            /* Using cursor T001W35 */
            pr_default.execute(33, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            A109EstadosGenericosNombre = T001W35_A109EstadosGenericosNombre[0];
            pr_default.close(33);
         }
      }

      protected void EndLevel1W76( )
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

      public void ScanStart1W76( )
      {
         /* Scan By routine */
         /* Using cursor T001W36 */
         pr_default.execute(34, new Object[] {A503ComisionesID});
         RcdFound76 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound76 = 1;
            A120ProfesionalesId = T001W36_A120ProfesionalesId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1W76( )
      {
         /* Scan next routine */
         pr_default.readNext(34);
         RcdFound76 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound76 = 1;
            A120ProfesionalesId = T001W36_A120ProfesionalesId[0];
         }
      }

      protected void ScanEnd1W76( )
      {
         pr_default.close(34);
      }

      protected void AfterConfirm1W76( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1W76( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1W76( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1W76( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1W76( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1W76( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1W76( )
      {
         edtProfesionalesId_Enabled = 0;
         AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtProfesionalesPrimerNombre_Enabled = 0;
         AssignProp("", false, edtProfesionalesPrimerNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtProfesionalesSegundoNombre_Enabled = 0;
         AssignProp("", false, edtProfesionalesSegundoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesSegundoNombre_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtProfesionalesApellidoPrimero_Enabled = 0;
         AssignProp("", false, edtProfesionalesApellidoPrimero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtProfesionalesApellidoSegundo_Enabled = 0;
         AssignProp("", false, edtProfesionalesApellidoSegundo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoSegundo_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtProfesionalesTelefono_Enabled = 0;
         AssignProp("", false, edtProfesionalesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesTelefono_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtEstadosTipo_Enabled = 0;
         AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtEstadosGenericosId_Enabled = 0;
         AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtEstadosGenericosNombre_Enabled = 0;
         AssignProp("", false, edtEstadosGenericosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void send_integrity_lvl_hashes1W76( )
      {
      }

      protected void send_integrity_lvl_hashes1W74( )
      {
      }

      protected void SubsflControlProps_7275( )
      {
         dynProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_72_idx;
         edtProveedorEmail_Internalname = "PROVEEDOREMAIL_"+sGXsfl_72_idx;
         edtProveedorTelefono_Internalname = "PROVEEDORTELEFONO_"+sGXsfl_72_idx;
         edtProveedorImagen_Internalname = "PROVEEDORIMAGEN_"+sGXsfl_72_idx;
         cmbProveedorEstado_Internalname = "PROVEEDORESTADO_"+sGXsfl_72_idx;
      }

      protected void SubsflControlProps_fel_7275( )
      {
         dynProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_72_fel_idx;
         edtProveedorEmail_Internalname = "PROVEEDOREMAIL_"+sGXsfl_72_fel_idx;
         edtProveedorTelefono_Internalname = "PROVEEDORTELEFONO_"+sGXsfl_72_fel_idx;
         edtProveedorImagen_Internalname = "PROVEEDORIMAGEN_"+sGXsfl_72_fel_idx;
         cmbProveedorEstado_Internalname = "PROVEEDORESTADO_"+sGXsfl_72_fel_idx;
      }

      protected void AddRow1W75( )
      {
         nGXsfl_72_idx = (int)(nGXsfl_72_idx+1);
         sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx), 4, 0), 4, "0");
         SubsflControlProps_7275( ) ;
         SendRow1W75( ) ;
      }

      protected void SendRow1W75( )
      {
         Gridlevel_proveedoresRow = GXWebRow.GetNew(context);
         if ( subGridlevel_proveedores_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_proveedores_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_proveedores_Class, "") != 0 )
            {
               subGridlevel_proveedores_Linesclass = subGridlevel_proveedores_Class+"Odd";
            }
         }
         else if ( subGridlevel_proveedores_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_proveedores_Backstyle = 0;
            subGridlevel_proveedores_Backcolor = subGridlevel_proveedores_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_proveedores_Class, "") != 0 )
            {
               subGridlevel_proveedores_Linesclass = subGridlevel_proveedores_Class+"Uniform";
            }
         }
         else if ( subGridlevel_proveedores_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_proveedores_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_proveedores_Class, "") != 0 )
            {
               subGridlevel_proveedores_Linesclass = subGridlevel_proveedores_Class+"Odd";
            }
            subGridlevel_proveedores_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_proveedores_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_proveedores_Backstyle = 1;
            if ( ((int)((nGXsfl_72_idx) % (2))) == 0 )
            {
               subGridlevel_proveedores_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_proveedores_Class, "") != 0 )
               {
                  subGridlevel_proveedores_Linesclass = subGridlevel_proveedores_Class+"Even";
               }
            }
            else
            {
               subGridlevel_proveedores_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_proveedores_Class, "") != 0 )
               {
                  subGridlevel_proveedores_Linesclass = subGridlevel_proveedores_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_75_" + sGXsfl_72_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_72_idx + "',72)\"";
         GXCCtl = "PROVEEDORID_" + sGXsfl_72_idx;
         dynProveedorID.Name = GXCCtl;
         dynProveedorID.WebTags = "";
         dynProveedorID.removeAllItems();
         /* Using cursor T001W37 */
         pr_default.execute(35);
         while ( (pr_default.getStatus(35) != 101) )
         {
            dynProveedorID.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T001W37_A133ProveedorID[0]), 18, 0)), T001W37_A282ProveedorNombre[0], 0);
            pr_default.readNext(35);
         }
         pr_default.close(35);
         if ( dynProveedorID.ItemCount > 0 )
         {
            A133ProveedorID = (long)(Math.Round(NumberUtil.Val( dynProveedorID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         /* ComboBox */
         Gridlevel_proveedoresRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynProveedorID,(string)dynProveedorID_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0)),(short)1,(string)dynProveedorID_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynProveedorID.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"",(string)"",(bool)true,(short)0});
         dynProveedorID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0));
         AssignProp("", false, dynProveedorID_Internalname, "Values", (string)(dynProveedorID.ToJavascriptSource()), !bGXsfl_72_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_75_" + sGXsfl_72_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_72_idx + "',72)\"";
         ROClassString = "Attribute";
         Gridlevel_proveedoresRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorEmail_Internalname,(string)A433ProveedorEmail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A433ProveedorEmail,(string)"",(string)"",(string)"",(string)edtProveedorEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorEmail_Enabled,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A430ProveedorTelefono);
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_75_" + sGXsfl_72_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_72_idx + "',72)\"";
         ROClassString = "Attribute";
         Gridlevel_proveedoresRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorTelefono_Internalname,StringUtil.RTrim( A430ProveedorTelefono),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtProveedorTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorTelefono_Enabled,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Static Bitmap Variable */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_75_" + sGXsfl_72_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_72_idx + "',72)\"";
         ClassString = "Attribute";
         StyleString = "";
         A432ProveedorImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001ProveedorImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40001ProveedorImagen_GXI : context.PathToRelativeUrl( A432ProveedorImagen));
         Gridlevel_proveedoresRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtProveedorImagen_Enabled,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"",(string)"",(string)"",(string)"",(short)0,(bool)A432ProveedorImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
         AssignProp("", false, edtProveedorImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40001ProveedorImagen_GXI : context.PathToRelativeUrl( A432ProveedorImagen)), !bGXsfl_72_Refreshing);
         AssignProp("", false, edtProveedorImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A432ProveedorImagen_IsBlob), !bGXsfl_72_Refreshing);
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_75_" + sGXsfl_72_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_72_idx + "',72)\"";
         GXCCtl = "PROVEEDORESTADO_" + sGXsfl_72_idx;
         cmbProveedorEstado.Name = GXCCtl;
         cmbProveedorEstado.WebTags = "";
         cmbProveedorEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbProveedorEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbProveedorEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbProveedorEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbProveedorEstado.ItemCount > 0 )
         {
            A344ProveedorEstado = cmbProveedorEstado.getValidValue(A344ProveedorEstado);
         }
         /* ComboBox */
         Gridlevel_proveedoresRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProveedorEstado,(string)cmbProveedorEstado_Internalname,StringUtil.RTrim( A344ProveedorEstado),(short)1,(string)cmbProveedorEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbProveedorEstado.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"",(string)"",(bool)true,(short)0});
         cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
         AssignProp("", false, cmbProveedorEstado_Internalname, "Values", (string)(cmbProveedorEstado.ToJavascriptSource()), !bGXsfl_72_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_proveedoresRow);
         send_integrity_lvl_hashes1W75( ) ;
         GXCCtl = "Z133ProveedorID_" + sGXsfl_72_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_75_" + sGXsfl_72_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_75), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_75_" + sGXsfl_72_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_75), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_75_" + sGXsfl_72_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_75), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_72_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_72_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vCOMISIONESID_" + sGXsfl_72_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "PROVEEDORIMAGEN_" + sGXsfl_72_idx;
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A432ProveedorImagen);
         GxWebStd.gx_hidden_field( context, "PROVEEDORID_"+sGXsfl_72_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynProveedorID.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDOREMAIL_"+sGXsfl_72_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorEmail_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORTELEFONO_"+sGXsfl_72_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorTelefono_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORIMAGEN_"+sGXsfl_72_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorImagen_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORESTADO_"+sGXsfl_72_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProveedorEstado.Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_proveedoresContainer.AddRow(Gridlevel_proveedoresRow);
      }

      protected void ReadRow1W75( )
      {
         nGXsfl_72_idx = (int)(nGXsfl_72_idx+1);
         sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx), 4, 0), 4, "0");
         SubsflControlProps_7275( ) ;
         dynProveedorID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORID_"+sGXsfl_72_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedorEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDOREMAIL_"+sGXsfl_72_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedorTelefono_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORTELEFONO_"+sGXsfl_72_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedorImagen_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORIMAGEN_"+sGXsfl_72_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbProveedorEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORESTADO_"+sGXsfl_72_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynProveedorID.Name = dynProveedorID_Internalname;
         dynProveedorID.CurrentValue = cgiGet( dynProveedorID_Internalname);
         A133ProveedorID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynProveedorID_Internalname), "."), 18, MidpointRounding.ToEven));
         A433ProveedorEmail = cgiGet( edtProveedorEmail_Internalname);
         n433ProveedorEmail = false;
         A430ProveedorTelefono = cgiGet( edtProveedorTelefono_Internalname);
         n430ProveedorTelefono = false;
         A432ProveedorImagen = cgiGet( edtProveedorImagen_Internalname);
         n432ProveedorImagen = false;
         cmbProveedorEstado.Name = cmbProveedorEstado_Internalname;
         cmbProveedorEstado.CurrentValue = cgiGet( cmbProveedorEstado_Internalname);
         A344ProveedorEstado = cgiGet( cmbProveedorEstado_Internalname);
         GXCCtl = "Z133ProveedorID_" + sGXsfl_72_idx;
         Z133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_75_" + sGXsfl_72_idx;
         nRcdDeleted_75 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_75_" + sGXsfl_72_idx;
         nRcdExists_75 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_75_" + sGXsfl_72_idx;
         nIsMod_75 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         getMultimediaValue(edtProveedorImagen_Internalname, ref  A432ProveedorImagen, ref  A40001ProveedorImagen_GXI);
      }

      protected void SubsflControlProps_8876( )
      {
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_88_idx;
         imgprompt_120_Internalname = "PROMPT_120_"+sGXsfl_88_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_88_idx;
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_88_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_88_idx;
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_88_idx;
         edtProfesionalesTelefono_Internalname = "PROFESIONALESTELEFONO_"+sGXsfl_88_idx;
         edtEstadosTipo_Internalname = "ESTADOSTIPO_"+sGXsfl_88_idx;
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_88_idx;
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE_"+sGXsfl_88_idx;
      }

      protected void SubsflControlProps_fel_8876( )
      {
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_88_fel_idx;
         imgprompt_120_Internalname = "PROMPT_120_"+sGXsfl_88_fel_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_88_fel_idx;
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_88_fel_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_88_fel_idx;
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_88_fel_idx;
         edtProfesionalesTelefono_Internalname = "PROFESIONALESTELEFONO_"+sGXsfl_88_fel_idx;
         edtEstadosTipo_Internalname = "ESTADOSTIPO_"+sGXsfl_88_fel_idx;
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_88_fel_idx;
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE_"+sGXsfl_88_fel_idx;
      }

      protected void AddRow1W76( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8876( ) ;
         SendRow1W76( ) ;
      }

      protected void SendRow1W76( )
      {
         Gridlevel_profesionalesRow = GXWebRow.GetNew(context);
         if ( subGridlevel_profesionales_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_profesionales_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_profesionales_Class, "") != 0 )
            {
               subGridlevel_profesionales_Linesclass = subGridlevel_profesionales_Class+"Odd";
            }
         }
         else if ( subGridlevel_profesionales_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_profesionales_Backstyle = 0;
            subGridlevel_profesionales_Backcolor = subGridlevel_profesionales_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_profesionales_Class, "") != 0 )
            {
               subGridlevel_profesionales_Linesclass = subGridlevel_profesionales_Class+"Uniform";
            }
         }
         else if ( subGridlevel_profesionales_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_profesionales_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_profesionales_Class, "") != 0 )
            {
               subGridlevel_profesionales_Linesclass = subGridlevel_profesionales_Class+"Odd";
            }
            subGridlevel_profesionales_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_profesionales_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_profesionales_Backstyle = 1;
            if ( ((int)((nGXsfl_88_idx) % (2))) == 0 )
            {
               subGridlevel_profesionales_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_profesionales_Class, "") != 0 )
               {
                  subGridlevel_profesionales_Linesclass = subGridlevel_profesionales_Class+"Even";
               }
            }
            else
            {
               subGridlevel_profesionales_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_profesionales_Class, "") != 0 )
               {
                  subGridlevel_profesionales_Linesclass = subGridlevel_profesionales_Class+"Odd";
               }
            }
         }
         imgprompt_120_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"profesionalesprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROFESIONALESID_"+sGXsfl_88_idx+"'), id:'"+"PROFESIONALESID_"+sGXsfl_88_idx+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"PROFESIONALESPRIMERNOMBRE_"+sGXsfl_88_idx+"'), id:'"+"PROFESIONALESPRIMERNOMBRE_"+sGXsfl_88_idx+"'"+",IOType:'inout'}"+"],"+"gx.dom.form()."+"nIsMod_76_"+sGXsfl_88_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_76_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_120_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_120_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_profesionalesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_120_Internalname,(string)sImgUrl,(string)imgprompt_120_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_120_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_76_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPrimerNombre_Internalname,StringUtil.RTrim( A166ProfesionalesPrimerNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesPrimerNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesPrimerNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_76_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesSegundoNombre_Internalname,StringUtil.RTrim( A191ProfesionalesSegundoNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesSegundoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesSegundoNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_76_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 92,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoPrimero_Internalname,StringUtil.RTrim( A167ProfesionalesApellidoPrimero),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoPrimero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesApellidoPrimero_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_76_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoSegundo_Internalname,StringUtil.RTrim( A192ProfesionalesApellidoSegundo),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoSegundo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesApellidoSegundo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A170ProfesionalesTelefono);
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_76_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesTelefono_Internalname,StringUtil.RTrim( A170ProfesionalesTelefono),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtProfesionalesTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesTelefono_Enabled,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosTipo_Internalname,StringUtil.RTrim( A107EstadosTipo),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtEstadosTipo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtEstadosGenericosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9") : context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosGenericosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtEstadosGenericosId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_76_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 97,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosNombre_Internalname,StringUtil.RTrim( A109EstadosGenericosNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosGenericosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtEstadosGenericosNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_profesionalesRow);
         send_integrity_lvl_hashes1W76( ) ;
         GXCCtl = "Z120ProfesionalesId_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z120ProfesionalesId));
         GXCCtl = "nRcdDeleted_76_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_76), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_76_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_76), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_76_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_76), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_88_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vCOMISIONESID_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesSegundoNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoSegundo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESTELEFONO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesTelefono_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSTIPO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosTipo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSNOMBRE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_120_"+sGXsfl_88_idx+"Link", StringUtil.RTrim( imgprompt_120_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_profesionalesContainer.AddRow(Gridlevel_profesionalesRow);
      }

      protected void ReadRow1W76( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8876( ) ;
         edtProfesionalesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESID_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfesionalesPrimerNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfesionalesSegundoNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfesionalesApellidoPrimero_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfesionalesApellidoSegundo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfesionalesTelefono_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESTELEFONO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtEstadosTipo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSTIPO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtEstadosGenericosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGENERICOSID_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtEstadosGenericosNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGENERICOSNOMBRE_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_120_Link = cgiGet( "PROMPT_120_"+sGXsfl_88_idx+"Link");
         A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
         A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
         A191ProfesionalesSegundoNombre = cgiGet( edtProfesionalesSegundoNombre_Internalname);
         A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
         A192ProfesionalesApellidoSegundo = cgiGet( edtProfesionalesApellidoSegundo_Internalname);
         A170ProfesionalesTelefono = cgiGet( edtProfesionalesTelefono_Internalname);
         A107EstadosTipo = cgiGet( edtEstadosTipo_Internalname);
         A108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosGenericosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A109EstadosGenericosNombre = cgiGet( edtEstadosGenericosNombre_Internalname);
         GXCCtl = "Z120ProfesionalesId_" + sGXsfl_88_idx;
         Z120ProfesionalesId = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_76_" + sGXsfl_88_idx;
         nRcdDeleted_76 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_76_" + sGXsfl_88_idx;
         nRcdExists_76 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_76_" + sGXsfl_88_idx;
         nIsMod_76 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtEstadosGenericosId_Enabled = edtEstadosGenericosId_Enabled;
         defedtEstadosTipo_Enabled = edtEstadosTipo_Enabled;
         defedtProfesionalesId_Enabled = edtProfesionalesId_Enabled;
         defdynProveedorID_Enabled = dynProveedorID.Enabled;
      }

      protected void ConfirmValues1W0( )
      {
         nGXsfl_72_idx = 0;
         sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx), 4, 0), 4, "0");
         SubsflControlProps_7275( ) ;
         while ( nGXsfl_72_idx < nRC_GXsfl_72 )
         {
            nGXsfl_72_idx = (int)(nGXsfl_72_idx+1);
            sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx), 4, 0), 4, "0");
            SubsflControlProps_7275( ) ;
            ChangePostValue( "Z133ProveedorID_"+sGXsfl_72_idx, cgiGet( "ZT_"+"Z133ProveedorID_"+sGXsfl_72_idx)) ;
            DeletePostValue( "ZT_"+"Z133ProveedorID_"+sGXsfl_72_idx) ;
         }
         nGXsfl_88_idx = 0;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8876( ) ;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8876( ) ;
            ChangePostValue( "Z120ProfesionalesId_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_88_idx) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "comisiones.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ComisionesID,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("comisiones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Comisiones");
         forbiddenHiddens.Add("ComisionesID", context.localUtil.Format( (decimal)(A503ComisionesID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("comisiones:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z503ComisionesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z503ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z504ComisionesNombre", StringUtil.RTrim( Z504ComisionesNombre));
         GxWebStd.gx_hidden_field( context, "Z505ComisionesTipo", StringUtil.RTrim( Z505ComisionesTipo));
         GxWebStd.gx_hidden_field( context, "Z506ComisionesDefault", StringUtil.LTrim( StringUtil.NToC( Z506ComisionesDefault, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z520ComisionesGlobal", Z520ComisionesGlobal);
         GxWebStd.gx_hidden_field( context, "Z507ComisionesFechaAlta", context.localUtil.TToC( Z507ComisionesFechaAlta, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z508ComisionesEspermanente", Z508ComisionesEspermanente);
         GxWebStd.gx_hidden_field( context, "Z509ComisionesFechaVigencia", context.localUtil.TToC( Z509ComisionesFechaVigencia, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z510ComisionesFechaVencimiento", context.localUtil.TToC( Z510ComisionesFechaVencimiento, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z511ComisionesEstado", StringUtil.RTrim( Z511ComisionesEstado));
         GxWebStd.gx_hidden_field( context, "Z512ComisionesInventarioEnum", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z512ComisionesInventarioEnum), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_72", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_72_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_88", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_88_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vCOMISIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCOMISIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ComisionesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "COMISIONESIMAGEN_GXI", A40000ComisionesImagen_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV20Pgmname));
         GxWebStd.gx_hidden_field( context, "PROVEEDORNOMBRE", StringUtil.RTrim( A282ProveedorNombre));
         GxWebStd.gx_hidden_field( context, "PROVEEDORIMAGEN_GXI", A40001ProveedorImagen_GXI);
         GXCCtlgxBlob = "COMISIONESIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A519ComisionesImagen);
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Objectcall", StringUtil.RTrim( Gxuitabspanel_tabs_Objectcall));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Enabled", StringUtil.BoolToStr( Gxuitabspanel_tabs_Enabled));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Class", StringUtil.RTrim( Gxuitabspanel_tabs_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs_Historymanagement));
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "comisiones.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ComisionesID,18,0));
         return formatLink("comisiones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Comisiones" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Comisiones", "") ;
      }

      protected void InitializeNonKey1W74( )
      {
         A504ComisionesNombre = "";
         AssignAttri("", false, "A504ComisionesNombre", A504ComisionesNombre);
         A519ComisionesImagen = "";
         n519ComisionesImagen = false;
         AssignAttri("", false, "A519ComisionesImagen", A519ComisionesImagen);
         AssignProp("", false, imgComisionesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? A40000ComisionesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A519ComisionesImagen))), true);
         AssignProp("", false, imgComisionesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A519ComisionesImagen), true);
         n519ComisionesImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? true : false);
         A40000ComisionesImagen_GXI = "";
         n40000ComisionesImagen_GXI = false;
         AssignProp("", false, imgComisionesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? A40000ComisionesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A519ComisionesImagen))), true);
         AssignProp("", false, imgComisionesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A519ComisionesImagen), true);
         A506ComisionesDefault = 0;
         n506ComisionesDefault = false;
         AssignAttri("", false, "A506ComisionesDefault", StringUtil.LTrimStr( A506ComisionesDefault, 6, 2));
         n506ComisionesDefault = ((Convert.ToDecimal(0)==A506ComisionesDefault) ? true : false);
         A508ComisionesEspermanente = false;
         n508ComisionesEspermanente = false;
         AssignAttri("", false, "A508ComisionesEspermanente", A508ComisionesEspermanente);
         n508ComisionesEspermanente = ((false==A508ComisionesEspermanente) ? true : false);
         A509ComisionesFechaVigencia = (DateTime)(DateTime.MinValue);
         n509ComisionesFechaVigencia = false;
         AssignAttri("", false, "A509ComisionesFechaVigencia", context.localUtil.TToC( A509ComisionesFechaVigencia, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n509ComisionesFechaVigencia = ((DateTime.MinValue==A509ComisionesFechaVigencia) ? true : false);
         A510ComisionesFechaVencimiento = (DateTime)(DateTime.MinValue);
         n510ComisionesFechaVencimiento = false;
         AssignAttri("", false, "A510ComisionesFechaVencimiento", context.localUtil.TToC( A510ComisionesFechaVencimiento, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n510ComisionesFechaVencimiento = ((DateTime.MinValue==A510ComisionesFechaVencimiento) ? true : false);
         A518ComisionesComentario = "";
         n518ComisionesComentario = false;
         AssignAttri("", false, "A518ComisionesComentario", A518ComisionesComentario);
         n518ComisionesComentario = (String.IsNullOrEmpty(StringUtil.RTrim( A518ComisionesComentario)) ? true : false);
         A512ComisionesInventarioEnum = 0;
         n512ComisionesInventarioEnum = false;
         AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
         n512ComisionesInventarioEnum = ((0==A512ComisionesInventarioEnum) ? true : false);
         A505ComisionesTipo = "C";
         AssignAttri("", false, "A505ComisionesTipo", A505ComisionesTipo);
         A520ComisionesGlobal = false;
         n520ComisionesGlobal = false;
         AssignAttri("", false, "A520ComisionesGlobal", A520ComisionesGlobal);
         A507ComisionesFechaAlta = DateTimeUtil.Now( context);
         n507ComisionesFechaAlta = false;
         AssignAttri("", false, "A507ComisionesFechaAlta", context.localUtil.TToC( A507ComisionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A511ComisionesEstado = "HAB";
         n511ComisionesEstado = false;
         AssignAttri("", false, "A511ComisionesEstado", A511ComisionesEstado);
         Z504ComisionesNombre = "";
         Z505ComisionesTipo = "";
         Z506ComisionesDefault = 0;
         Z520ComisionesGlobal = false;
         Z507ComisionesFechaAlta = (DateTime)(DateTime.MinValue);
         Z508ComisionesEspermanente = false;
         Z509ComisionesFechaVigencia = (DateTime)(DateTime.MinValue);
         Z510ComisionesFechaVencimiento = (DateTime)(DateTime.MinValue);
         Z511ComisionesEstado = "";
         Z512ComisionesInventarioEnum = 0;
      }

      protected void InitAll1W74( )
      {
         A503ComisionesID = 0;
         AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
         InitializeNonKey1W74( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A505ComisionesTipo = i505ComisionesTipo;
         AssignAttri("", false, "A505ComisionesTipo", A505ComisionesTipo);
         A511ComisionesEstado = i511ComisionesEstado;
         n511ComisionesEstado = false;
         AssignAttri("", false, "A511ComisionesEstado", A511ComisionesEstado);
         A507ComisionesFechaAlta = i507ComisionesFechaAlta;
         n507ComisionesFechaAlta = false;
         AssignAttri("", false, "A507ComisionesFechaAlta", context.localUtil.TToC( A507ComisionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A520ComisionesGlobal = i520ComisionesGlobal;
         n520ComisionesGlobal = false;
         AssignAttri("", false, "A520ComisionesGlobal", A520ComisionesGlobal);
      }

      protected void InitializeNonKey1W75( )
      {
         A282ProveedorNombre = "";
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A433ProveedorEmail = "";
         n433ProveedorEmail = false;
         A430ProveedorTelefono = "";
         n430ProveedorTelefono = false;
         A432ProveedorImagen = "";
         n432ProveedorImagen = false;
         AssignProp("", false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40001ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_72_Refreshing);
         AssignProp("", false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
         A40001ProveedorImagen_GXI = "";
         n40001ProveedorImagen_GXI = false;
         AssignProp("", false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40001ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_72_Refreshing);
         AssignProp("", false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
         A344ProveedorEstado = "";
      }

      protected void InitAll1W75( )
      {
         A133ProveedorID = 0;
         InitializeNonKey1W75( ) ;
      }

      protected void StandaloneModalInsert1W75( )
      {
      }

      protected void InitializeNonKey1W76( )
      {
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         A107EstadosTipo = "";
         A108EstadosGenericosId = 0;
         A109EstadosGenericosNombre = "";
      }

      protected void InitAll1W76( )
      {
         A120ProfesionalesId = "";
         InitializeNonKey1W76( ) ;
      }

      protected void StandaloneModalInsert1W76( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932074735", true, true, false);
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
         context.AddJavascriptSource("comisiones.js", "?2026932074735", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties75( )
      {
         dynProveedorID.Enabled = defdynProveedorID_Enabled;
         AssignProp("", false, dynProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedorID.Enabled), 5, 0), !bGXsfl_72_Refreshing);
      }

      protected void init_level_properties76( )
      {
         edtEstadosGenericosId_Enabled = defedtEstadosGenericosId_Enabled;
         AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtEstadosTipo_Enabled = defedtEstadosTipo_Enabled;
         AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtProfesionalesId_Enabled = defedtProfesionalesId_Enabled;
         AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void StartGridControl72( )
      {
         Gridlevel_proveedoresContainer.AddObjectProperty("GridName", "Gridlevel_proveedores");
         Gridlevel_proveedoresContainer.AddObjectProperty("Header", subGridlevel_proveedores_Header);
         Gridlevel_proveedoresContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_proveedoresContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_proveedoresContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_proveedoresContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedores_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_proveedoresContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_proveedoresContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_proveedoresColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_proveedoresColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))));
         Gridlevel_proveedoresColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynProveedorID.Enabled), 5, 0, ".", "")));
         Gridlevel_proveedoresContainer.AddColumnProperties(Gridlevel_proveedoresColumn);
         Gridlevel_proveedoresColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_proveedoresColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A433ProveedorEmail));
         Gridlevel_proveedoresColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorEmail_Enabled), 5, 0, ".", "")));
         Gridlevel_proveedoresContainer.AddColumnProperties(Gridlevel_proveedoresColumn);
         Gridlevel_proveedoresColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_proveedoresColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A430ProveedorTelefono)));
         Gridlevel_proveedoresColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorTelefono_Enabled), 5, 0, ".", "")));
         Gridlevel_proveedoresContainer.AddColumnProperties(Gridlevel_proveedoresColumn);
         Gridlevel_proveedoresColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_proveedoresColumn.AddObjectProperty("Value", context.convertURL( A432ProveedorImagen));
         Gridlevel_proveedoresColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorImagen_Enabled), 5, 0, ".", "")));
         Gridlevel_proveedoresContainer.AddColumnProperties(Gridlevel_proveedoresColumn);
         Gridlevel_proveedoresColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_proveedoresColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A344ProveedorEstado)));
         Gridlevel_proveedoresColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProveedorEstado.Enabled), 5, 0, ".", "")));
         Gridlevel_proveedoresContainer.AddColumnProperties(Gridlevel_proveedoresColumn);
         Gridlevel_proveedoresContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedores_Selectedindex), 4, 0, ".", "")));
         Gridlevel_proveedoresContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedores_Allowselection), 1, 0, ".", "")));
         Gridlevel_proveedoresContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedores_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_proveedoresContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedores_Allowhovering), 1, 0, ".", "")));
         Gridlevel_proveedoresContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedores_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_proveedoresContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedores_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_proveedoresContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedores_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl88( )
      {
         Gridlevel_profesionalesContainer.AddObjectProperty("GridName", "Gridlevel_profesionales");
         Gridlevel_profesionalesContainer.AddObjectProperty("Header", subGridlevel_profesionales_Header);
         Gridlevel_profesionalesContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_profesionalesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_profesionalesContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A166ProfesionalesPrimerNombre)));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A191ProfesionalesSegundoNombre)));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesSegundoNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A167ProfesionalesApellidoPrimero)));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A192ProfesionalesApellidoSegundo)));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoSegundo_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A170ProfesionalesTelefono)));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesTelefono_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A107EstadosTipo)));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosTipo_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", ""))));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosId_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A109EstadosGenericosNombre)));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Selectedindex), 4, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Allowselection), 1, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Allowhovering), 1, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTabgeneral_title_Internalname = "TABGENERAL_TITLE";
         edtComisionesID_Internalname = "COMISIONESID";
         cmbComisionesEstado_Internalname = "COMISIONESESTADO";
         cmbComisionesTipo_Internalname = "COMISIONESTIPO";
         edtComisionesNombre_Internalname = "COMISIONESNOMBRE";
         edtComisionesDefault_Internalname = "COMISIONESDEFAULT";
         chkComisionesGlobal_Internalname = "COMISIONESGLOBAL";
         divComisionesglobal_cell_Internalname = "COMISIONESGLOBAL_CELL";
         divTb1_Internalname = "TB1";
         imgComisionesImagen_Internalname = "COMISIONESIMAGEN";
         divTb2_Internalname = "TB2";
         edtComisionesComentario_Internalname = "COMISIONESCOMENTARIO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         lblTablevel_proveedores_title_Internalname = "TABLEVEL_PROVEEDORES_TITLE";
         dynProveedorID_Internalname = "PROVEEDORID";
         edtProveedorEmail_Internalname = "PROVEEDOREMAIL";
         edtProveedorTelefono_Internalname = "PROVEEDORTELEFONO";
         edtProveedorImagen_Internalname = "PROVEEDORIMAGEN";
         cmbProveedorEstado_Internalname = "PROVEEDORESTADO";
         divTableleaflevel_proveedores_Internalname = "TABLELEAFLEVEL_PROVEEDORES";
         divTabtablelevel_proveedores_Internalname = "TABTABLELEVEL_PROVEEDORES";
         lblTablevel_profesionales_title_Internalname = "TABLEVEL_PROFESIONALES_TITLE";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO";
         edtProfesionalesTelefono_Internalname = "PROFESIONALESTELEFONO";
         edtEstadosTipo_Internalname = "ESTADOSTIPO";
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID";
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE";
         divTableleaflevel_profesionales_Internalname = "TABLELEAFLEVEL_PROFESIONALES";
         divTabtablelevel_profesionales_Internalname = "TABTABLELEVEL_PROFESIONALES";
         Gxuitabspanel_tabs_Internalname = "GXUITABSPANEL_TABS";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtComisionesFechaAlta_Internalname = "COMISIONESFECHAALTA";
         edtComisionesEspermanente_Internalname = "COMISIONESESPERMANENTE";
         edtComisionesFechaVigencia_Internalname = "COMISIONESFECHAVIGENCIA";
         edtComisionesFechaVencimiento_Internalname = "COMISIONESFECHAVENCIMIENTO";
         edtComisionesInventarioEnum_Internalname = "COMISIONESINVENTARIOENUM";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_120_Internalname = "PROMPT_120";
         subGridlevel_proveedores_Internalname = "GRIDLEVEL_PROVEEDORES";
         subGridlevel_profesionales_Internalname = "GRIDLEVEL_PROFESIONALES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_profesionales_Allowcollapsing = 0;
         subGridlevel_profesionales_Allowselection = 0;
         subGridlevel_profesionales_Header = "";
         subGridlevel_proveedores_Allowcollapsing = 0;
         subGridlevel_proveedores_Allowselection = 0;
         subGridlevel_proveedores_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Comisiones", "");
         edtEstadosGenericosNombre_Jsonclick = "";
         edtEstadosGenericosId_Jsonclick = "";
         edtEstadosTipo_Jsonclick = "";
         edtProfesionalesTelefono_Jsonclick = "";
         edtProfesionalesApellidoSegundo_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Jsonclick = "";
         imgprompt_120_Visible = 1;
         imgprompt_120_Link = "";
         imgprompt_120_Visible = 1;
         edtProfesionalesId_Jsonclick = "";
         subGridlevel_profesionales_Class = "WorkWith";
         subGridlevel_profesionales_Backcolorstyle = 0;
         cmbProveedorEstado_Jsonclick = "";
         edtProveedorTelefono_Jsonclick = "";
         edtProveedorEmail_Jsonclick = "";
         dynProveedorID_Jsonclick = "";
         subGridlevel_proveedores_Class = "WorkWith";
         subGridlevel_proveedores_Backcolorstyle = 0;
         edtEstadosGenericosNombre_Enabled = 0;
         edtEstadosGenericosId_Enabled = 0;
         edtEstadosTipo_Enabled = 0;
         edtProfesionalesTelefono_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesId_Enabled = 1;
         cmbProveedorEstado.Enabled = 0;
         edtProveedorImagen_Enabled = 0;
         edtProveedorTelefono_Enabled = 0;
         edtProveedorEmail_Enabled = 0;
         dynProveedorID.Enabled = 1;
         edtComisionesInventarioEnum_Jsonclick = "";
         edtComisionesInventarioEnum_Enabled = 1;
         edtComisionesInventarioEnum_Visible = 1;
         edtComisionesFechaVencimiento_Jsonclick = "";
         edtComisionesFechaVencimiento_Enabled = 1;
         edtComisionesFechaVencimiento_Visible = 1;
         edtComisionesFechaVigencia_Jsonclick = "";
         edtComisionesFechaVigencia_Enabled = 1;
         edtComisionesFechaVigencia_Visible = 1;
         edtComisionesEspermanente_Jsonclick = "";
         edtComisionesEspermanente_Enabled = 1;
         edtComisionesEspermanente_Visible = 1;
         edtComisionesFechaAlta_Jsonclick = "";
         edtComisionesFechaAlta_Enabled = 1;
         edtComisionesFechaAlta_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         divTabtablelevel_profesionales_Visible = 1;
         edtComisionesComentario_Enabled = 1;
         imgComisionesImagen_Enabled = 1;
         chkComisionesGlobal.Enabled = 1;
         chkComisionesGlobal.Visible = 1;
         divComisionesglobal_cell_Class = "col-xs-12";
         edtComisionesDefault_Jsonclick = "";
         edtComisionesDefault_Enabled = 1;
         edtComisionesNombre_Jsonclick = "";
         edtComisionesNombre_Enabled = 1;
         cmbComisionesTipo_Jsonclick = "";
         cmbComisionesTipo.Enabled = 1;
         cmbComisionesEstado_Jsonclick = "";
         cmbComisionesEstado.Enabled = 1;
         edtComisionesID_Jsonclick = "";
         edtComisionesID_Enabled = 0;
         Gxuitabspanel_tabs_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs_Class = "Tab";
         Gxuitabspanel_tabs_Pagecount = 3;
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

      protected void gxnrGridlevel_proveedores_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_7275( ) ;
         while ( nGXsfl_72_idx <= nRC_GXsfl_72 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1W75( ) ;
            standaloneModal1W75( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1W75( ) ;
            nGXsfl_72_idx = (int)(nGXsfl_72_idx+1);
            sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx), 4, 0), 4, "0");
            SubsflControlProps_7275( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_proveedoresContainer)) ;
         /* End function gxnrGridlevel_proveedores_newrow */
      }

      protected void gxnrGridlevel_profesionales_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_8876( ) ;
         while ( nGXsfl_88_idx <= nRC_GXsfl_88 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1W76( ) ;
            standaloneModal1W76( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1W76( ) ;
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8876( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_profesionalesContainer)) ;
         /* End function gxnrGridlevel_profesionales_newrow */
      }

      protected void init_web_controls( )
      {
         cmbComisionesEstado.Name = "COMISIONESESTADO";
         cmbComisionesEstado.WebTags = "";
         cmbComisionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbComisionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbComisionesEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbComisionesEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbComisionesEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A511ComisionesEstado)) )
            {
               A511ComisionesEstado = "HAB";
               n511ComisionesEstado = false;
               AssignAttri("", false, "A511ComisionesEstado", A511ComisionesEstado);
            }
         }
         cmbComisionesTipo.Name = "COMISIONESTIPO";
         cmbComisionesTipo.WebTags = "";
         cmbComisionesTipo.addItem("P", context.GetMessage( "Profesional", ""), 0);
         cmbComisionesTipo.addItem("C", context.GetMessage( "Comercio", ""), 0);
         cmbComisionesTipo.addItem("Z", context.GetMessage( "Zona", ""), 0);
         if ( cmbComisionesTipo.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A505ComisionesTipo)) )
            {
               A505ComisionesTipo = "C";
               AssignAttri("", false, "A505ComisionesTipo", A505ComisionesTipo);
            }
         }
         chkComisionesGlobal.Name = "COMISIONESGLOBAL";
         chkComisionesGlobal.WebTags = "";
         chkComisionesGlobal.Caption = context.GetMessage( "Comisión Global", "");
         AssignProp("", false, chkComisionesGlobal_Internalname, "TitleCaption", chkComisionesGlobal.Caption, true);
         chkComisionesGlobal.CheckedValue = "false";
         if ( IsIns( ) && (false==A520ComisionesGlobal) )
         {
            A520ComisionesGlobal = false;
            n520ComisionesGlobal = false;
            AssignAttri("", false, "A520ComisionesGlobal", A520ComisionesGlobal);
         }
         GXCCtl = "PROVEEDORID_" + sGXsfl_72_idx;
         dynProveedorID.Name = GXCCtl;
         dynProveedorID.WebTags = "";
         dynProveedorID.removeAllItems();
         /* Using cursor T001W38 */
         pr_default.execute(36);
         while ( (pr_default.getStatus(36) != 101) )
         {
            dynProveedorID.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T001W38_A133ProveedorID[0]), 18, 0)), T001W38_A282ProveedorNombre[0], 0);
            pr_default.readNext(36);
         }
         pr_default.close(36);
         if ( dynProveedorID.ItemCount > 0 )
         {
            A133ProveedorID = (long)(Math.Round(NumberUtil.Val( dynProveedorID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         GXCCtl = "PROVEEDORESTADO_" + sGXsfl_72_idx;
         cmbProveedorEstado.Name = GXCCtl;
         cmbProveedorEstado.WebTags = "";
         cmbProveedorEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbProveedorEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbProveedorEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbProveedorEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbProveedorEstado.ItemCount > 0 )
         {
            A344ProveedorEstado = cmbProveedorEstado.getValidValue(A344ProveedorEstado);
         }
         /* End function init_web_controls */
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
         A133ProveedorID = (long)(Math.Round(NumberUtil.Val( dynProveedorID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n433ProveedorEmail = false;
         n430ProveedorTelefono = false;
         n432ProveedorImagen = false;
         n40001ProveedorImagen_GXI = false;
         A344ProveedorEstado = cmbProveedorEstado.CurrentValue;
         cmbProveedorEstado.CurrentValue = A344ProveedorEstado;
         /* Using cursor T001W26 */
         pr_default.execute(24, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = dynProveedorID_Internalname;
         }
         A282ProveedorNombre = T001W26_A282ProveedorNombre[0];
         A433ProveedorEmail = T001W26_A433ProveedorEmail[0];
         n433ProveedorEmail = T001W26_n433ProveedorEmail[0];
         A430ProveedorTelefono = T001W26_A430ProveedorTelefono[0];
         n430ProveedorTelefono = T001W26_n430ProveedorTelefono[0];
         A40001ProveedorImagen_GXI = T001W26_A40001ProveedorImagen_GXI[0];
         n40001ProveedorImagen_GXI = T001W26_n40001ProveedorImagen_GXI[0];
         A344ProveedorEstado = T001W26_A344ProveedorEstado[0];
         cmbProveedorEstado.CurrentValue = A344ProveedorEstado;
         A432ProveedorImagen = T001W26_A432ProveedorImagen[0];
         n432ProveedorImagen = T001W26_n432ProveedorImagen[0];
         pr_default.close(24);
         dynload_actions( ) ;
         if ( dynProveedorID.ItemCount > 0 )
         {
            A133ProveedorID = (long)(Math.Round(NumberUtil.Val( dynProveedorID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynProveedorID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0));
         }
         if ( cmbProveedorEstado.ItemCount > 0 )
         {
            A344ProveedorEstado = cmbProveedorEstado.getValidValue(A344ProveedorEstado);
            cmbProveedorEstado.CurrentValue = A344ProveedorEstado;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A282ProveedorNombre", StringUtil.RTrim( A282ProveedorNombre));
         AssignAttri("", false, "A433ProveedorEmail", A433ProveedorEmail);
         AssignAttri("", false, "A430ProveedorTelefono", StringUtil.RTrim( A430ProveedorTelefono));
         AssignAttri("", false, "A432ProveedorImagen", context.PathToRelativeUrl( A432ProveedorImagen));
         GXCCtl = "PROVEEDORIMAGEN_" + sGXsfl_72_idx;
         AssignAttri("", false, "GXCCtl", GXCCtl);
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A432ProveedorImagen));
         AssignAttri("", false, "A40001ProveedorImagen_GXI", A40001ProveedorImagen_GXI);
         AssignAttri("", false, "A344ProveedorEstado", StringUtil.RTrim( A344ProveedorEstado));
         cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
         AssignProp("", false, cmbProveedorEstado_Internalname, "Values", cmbProveedorEstado.ToJavascriptSource(), true);
      }

      public void Valid_Profesionalesid( )
      {
         /* Using cursor T001W34 */
         pr_default.execute(32, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROFESIONALESID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
         }
         A166ProfesionalesPrimerNombre = T001W34_A166ProfesionalesPrimerNombre[0];
         A191ProfesionalesSegundoNombre = T001W34_A191ProfesionalesSegundoNombre[0];
         A167ProfesionalesApellidoPrimero = T001W34_A167ProfesionalesApellidoPrimero[0];
         A192ProfesionalesApellidoSegundo = T001W34_A192ProfesionalesApellidoSegundo[0];
         A170ProfesionalesTelefono = T001W34_A170ProfesionalesTelefono[0];
         A107EstadosTipo = T001W34_A107EstadosTipo[0];
         A108EstadosGenericosId = T001W34_A108EstadosGenericosId[0];
         pr_default.close(32);
         /* Using cursor T001W35 */
         pr_default.execute(33, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(33) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSGENERICOSID");
            AnyError = 1;
         }
         A109EstadosGenericosNombre = T001W35_A109EstadosGenericosNombre[0];
         pr_default.close(33);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A166ProfesionalesPrimerNombre", StringUtil.RTrim( A166ProfesionalesPrimerNombre));
         AssignAttri("", false, "A191ProfesionalesSegundoNombre", StringUtil.RTrim( A191ProfesionalesSegundoNombre));
         AssignAttri("", false, "A167ProfesionalesApellidoPrimero", StringUtil.RTrim( A167ProfesionalesApellidoPrimero));
         AssignAttri("", false, "A192ProfesionalesApellidoSegundo", StringUtil.RTrim( A192ProfesionalesApellidoSegundo));
         AssignAttri("", false, "A170ProfesionalesTelefono", StringUtil.RTrim( A170ProfesionalesTelefono));
         AssignAttri("", false, "A107EstadosTipo", StringUtil.RTrim( A107EstadosTipo));
         AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", "")));
         AssignAttri("", false, "A109EstadosGenericosNombre", StringUtil.RTrim( A109EstadosGenericosNombre));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7ComisionesID',fld:'vCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ComisionesID',fld:'vCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A503ComisionesID',fld:'COMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]}");
         setEventMetadata("AFTER TRN","{handler:'E121W2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_COMISIONESID","{handler:'Valid_Comisionesid',iparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_COMISIONESID",",oparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_COMISIONESESTADO","{handler:'Valid_Comisionesestado',iparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_COMISIONESESTADO",",oparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_COMISIONESTIPO","{handler:'Valid_Comisionestipo',iparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_COMISIONESTIPO",",oparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_COMISIONESFECHAALTA","{handler:'Valid_Comisionesfechaalta',iparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_COMISIONESFECHAALTA",",oparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_COMISIONESFECHAVIGENCIA","{handler:'Valid_Comisionesfechavigencia',iparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_COMISIONESFECHAVIGENCIA",",oparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_COMISIONESFECHAVENCIMIENTO","{handler:'Valid_Comisionesfechavencimiento',iparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_COMISIONESFECHAVENCIMIENTO",",oparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[{av:'dynProveedorID'},{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'A433ProveedorEmail',fld:'PROVEEDOREMAIL',pic:'',type:'svchar'},{av:'A430ProveedorTelefono',fld:'PROVEEDORTELEFONO',pic:'',type:'char'},{av:'A432ProveedorImagen',fld:'PROVEEDORIMAGEN',pic:'',type:'bits'},{av:'A40001ProveedorImagen_GXI',fld:'PROVEEDORIMAGEN_GXI',pic:'',type:'svchar'},{av:'cmbProveedorEstado'},{av:'A344ProveedorEstado',fld:'PROVEEDORESTADO',pic:'',type:'char'},{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'A433ProveedorEmail',fld:'PROVEEDOREMAIL',pic:'',type:'svchar'},{av:'A430ProveedorTelefono',fld:'PROVEEDORTELEFONO',pic:'',type:'char'},{av:'A432ProveedorImagen',fld:'PROVEEDORIMAGEN',pic:'',type:'bits'},{av:'A40001ProveedorImagen_GXI',fld:'PROVEEDORIMAGEN_GXI',pic:'',type:'svchar'},{av:'cmbProveedorEstado'},{av:'A344ProveedorEstado',fld:'PROVEEDORESTADO',pic:'',type:'char'},{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]}");
         setEventMetadata("NULL","{handler:'Valid_Proveedorestado',iparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]");
         setEventMetadata("NULL",",oparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'A166ProfesionalesPrimerNombre',fld:'PROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'A191ProfesionalesSegundoNombre',fld:'PROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'A167ProfesionalesApellidoPrimero',fld:'PROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'A192ProfesionalesApellidoSegundo',fld:'PROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'A170ProfesionalesTelefono',fld:'PROFESIONALESTELEFONO',pic:'',type:'char'},{av:'A109EstadosGenericosNombre',fld:'ESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[{av:'A166ProfesionalesPrimerNombre',fld:'PROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'A191ProfesionalesSegundoNombre',fld:'PROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'A167ProfesionalesApellidoPrimero',fld:'PROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'A192ProfesionalesApellidoSegundo',fld:'PROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'A170ProfesionalesTelefono',fld:'PROFESIONALESTELEFONO',pic:'',type:'char'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'A109EstadosGenericosNombre',fld:'ESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_ESTADOSTIPO","{handler:'Valid_Estadostipo',iparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_ESTADOSTIPO",",oparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_ESTADOSGENERICOSID","{handler:'Valid_Estadosgenericosid',iparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_ESTADOSGENERICOSID",",oparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]}");
         setEventMetadata("NULL","{handler:'Valid_Estadosgenericosnombre',iparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]");
         setEventMetadata("NULL",",oparms:[{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'}]}");
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
         pr_default.close(32);
         pr_default.close(33);
         pr_default.close(5);
         pr_default.close(24);
         pr_default.close(8);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z504ComisionesNombre = "";
         Z505ComisionesTipo = "";
         Z507ComisionesFechaAlta = (DateTime)(DateTime.MinValue);
         Z509ComisionesFechaVigencia = (DateTime)(DateTime.MinValue);
         Z510ComisionesFechaVencimiento = (DateTime)(DateTime.MinValue);
         Z511ComisionesEstado = "";
         Z120ProfesionalesId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A120ProfesionalesId = "";
         A107EstadosTipo = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A511ComisionesEstado = "";
         A505ComisionesTipo = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblTabgeneral_title_Jsonclick = "";
         TempTags = "";
         A504ComisionesNombre = "";
         A519ComisionesImagen = "";
         A40000ComisionesImagen_GXI = "";
         sImgUrl = "";
         A518ComisionesComentario = "";
         lblTablevel_proveedores_title_Jsonclick = "";
         lblTablevel_profesionales_title_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A507ComisionesFechaAlta = (DateTime)(DateTime.MinValue);
         A509ComisionesFechaVigencia = (DateTime)(DateTime.MinValue);
         A510ComisionesFechaVencimiento = (DateTime)(DateTime.MinValue);
         Gridlevel_proveedoresContainer = new GXWebGrid( context);
         sMode75 = "";
         sStyleString = "";
         Gridlevel_profesionalesContainer = new GXWebGrid( context);
         sMode76 = "";
         AV20Pgmname = "";
         A282ProveedorNombre = "";
         A40001ProveedorImagen_GXI = "";
         Gxuitabspanel_tabs_Objectcall = "";
         Gxuitabspanel_tabs_Activepagecontrolname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode74 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         A109EstadosGenericosNombre = "";
         A433ProveedorEmail = "";
         A430ProveedorTelefono = "";
         A432ProveedorImagen = "";
         A344ProveedorEstado = "";
         AV11WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z519ComisionesImagen = "";
         Z40000ComisionesImagen_GXI = "";
         Z518ComisionesComentario = "";
         T001W11_A503ComisionesID = new long[1] ;
         T001W11_A504ComisionesNombre = new string[] {""} ;
         T001W11_A505ComisionesTipo = new string[] {""} ;
         T001W11_A40000ComisionesImagen_GXI = new string[] {""} ;
         T001W11_n40000ComisionesImagen_GXI = new bool[] {false} ;
         T001W11_A506ComisionesDefault = new decimal[1] ;
         T001W11_n506ComisionesDefault = new bool[] {false} ;
         T001W11_A520ComisionesGlobal = new bool[] {false} ;
         T001W11_n520ComisionesGlobal = new bool[] {false} ;
         T001W11_A507ComisionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T001W11_n507ComisionesFechaAlta = new bool[] {false} ;
         T001W11_A508ComisionesEspermanente = new bool[] {false} ;
         T001W11_n508ComisionesEspermanente = new bool[] {false} ;
         T001W11_A509ComisionesFechaVigencia = new DateTime[] {DateTime.MinValue} ;
         T001W11_n509ComisionesFechaVigencia = new bool[] {false} ;
         T001W11_A510ComisionesFechaVencimiento = new DateTime[] {DateTime.MinValue} ;
         T001W11_n510ComisionesFechaVencimiento = new bool[] {false} ;
         T001W11_A511ComisionesEstado = new string[] {""} ;
         T001W11_n511ComisionesEstado = new bool[] {false} ;
         T001W11_A518ComisionesComentario = new string[] {""} ;
         T001W11_n518ComisionesComentario = new bool[] {false} ;
         T001W11_A512ComisionesInventarioEnum = new int[1] ;
         T001W11_n512ComisionesInventarioEnum = new bool[] {false} ;
         T001W11_A519ComisionesImagen = new string[] {""} ;
         T001W11_n519ComisionesImagen = new bool[] {false} ;
         T001W12_A503ComisionesID = new long[1] ;
         T001W10_A503ComisionesID = new long[1] ;
         T001W10_A504ComisionesNombre = new string[] {""} ;
         T001W10_A505ComisionesTipo = new string[] {""} ;
         T001W10_A40000ComisionesImagen_GXI = new string[] {""} ;
         T001W10_n40000ComisionesImagen_GXI = new bool[] {false} ;
         T001W10_A506ComisionesDefault = new decimal[1] ;
         T001W10_n506ComisionesDefault = new bool[] {false} ;
         T001W10_A520ComisionesGlobal = new bool[] {false} ;
         T001W10_n520ComisionesGlobal = new bool[] {false} ;
         T001W10_A507ComisionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T001W10_n507ComisionesFechaAlta = new bool[] {false} ;
         T001W10_A508ComisionesEspermanente = new bool[] {false} ;
         T001W10_n508ComisionesEspermanente = new bool[] {false} ;
         T001W10_A509ComisionesFechaVigencia = new DateTime[] {DateTime.MinValue} ;
         T001W10_n509ComisionesFechaVigencia = new bool[] {false} ;
         T001W10_A510ComisionesFechaVencimiento = new DateTime[] {DateTime.MinValue} ;
         T001W10_n510ComisionesFechaVencimiento = new bool[] {false} ;
         T001W10_A511ComisionesEstado = new string[] {""} ;
         T001W10_n511ComisionesEstado = new bool[] {false} ;
         T001W10_A518ComisionesComentario = new string[] {""} ;
         T001W10_n518ComisionesComentario = new bool[] {false} ;
         T001W10_A512ComisionesInventarioEnum = new int[1] ;
         T001W10_n512ComisionesInventarioEnum = new bool[] {false} ;
         T001W10_A519ComisionesImagen = new string[] {""} ;
         T001W10_n519ComisionesImagen = new bool[] {false} ;
         T001W13_A503ComisionesID = new long[1] ;
         T001W14_A503ComisionesID = new long[1] ;
         T001W9_A503ComisionesID = new long[1] ;
         T001W9_A504ComisionesNombre = new string[] {""} ;
         T001W9_A505ComisionesTipo = new string[] {""} ;
         T001W9_A40000ComisionesImagen_GXI = new string[] {""} ;
         T001W9_n40000ComisionesImagen_GXI = new bool[] {false} ;
         T001W9_A506ComisionesDefault = new decimal[1] ;
         T001W9_n506ComisionesDefault = new bool[] {false} ;
         T001W9_A520ComisionesGlobal = new bool[] {false} ;
         T001W9_n520ComisionesGlobal = new bool[] {false} ;
         T001W9_A507ComisionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T001W9_n507ComisionesFechaAlta = new bool[] {false} ;
         T001W9_A508ComisionesEspermanente = new bool[] {false} ;
         T001W9_n508ComisionesEspermanente = new bool[] {false} ;
         T001W9_A509ComisionesFechaVigencia = new DateTime[] {DateTime.MinValue} ;
         T001W9_n509ComisionesFechaVigencia = new bool[] {false} ;
         T001W9_A510ComisionesFechaVencimiento = new DateTime[] {DateTime.MinValue} ;
         T001W9_n510ComisionesFechaVencimiento = new bool[] {false} ;
         T001W9_A511ComisionesEstado = new string[] {""} ;
         T001W9_n511ComisionesEstado = new bool[] {false} ;
         T001W9_A518ComisionesComentario = new string[] {""} ;
         T001W9_n518ComisionesComentario = new bool[] {false} ;
         T001W9_A512ComisionesInventarioEnum = new int[1] ;
         T001W9_n512ComisionesInventarioEnum = new bool[] {false} ;
         T001W9_A519ComisionesImagen = new string[] {""} ;
         T001W9_n519ComisionesImagen = new bool[] {false} ;
         T001W15_A503ComisionesID = new long[1] ;
         T001W19_A503ComisionesID = new long[1] ;
         T001W19_A513ComisionesAgruparRubrosId = new long[1] ;
         T001W20_A503ComisionesID = new long[1] ;
         Z282ProveedorNombre = "";
         Z433ProveedorEmail = "";
         Z430ProveedorTelefono = "";
         Z432ProveedorImagen = "";
         Z40001ProveedorImagen_GXI = "";
         Z344ProveedorEstado = "";
         T001W21_A503ComisionesID = new long[1] ;
         T001W21_A282ProveedorNombre = new string[] {""} ;
         T001W21_A433ProveedorEmail = new string[] {""} ;
         T001W21_n433ProveedorEmail = new bool[] {false} ;
         T001W21_A430ProveedorTelefono = new string[] {""} ;
         T001W21_n430ProveedorTelefono = new bool[] {false} ;
         T001W21_A40001ProveedorImagen_GXI = new string[] {""} ;
         T001W21_n40001ProveedorImagen_GXI = new bool[] {false} ;
         T001W21_A344ProveedorEstado = new string[] {""} ;
         T001W21_A133ProveedorID = new long[1] ;
         T001W21_A432ProveedorImagen = new string[] {""} ;
         T001W21_n432ProveedorImagen = new bool[] {false} ;
         T001W8_A282ProveedorNombre = new string[] {""} ;
         T001W8_A433ProveedorEmail = new string[] {""} ;
         T001W8_n433ProveedorEmail = new bool[] {false} ;
         T001W8_A430ProveedorTelefono = new string[] {""} ;
         T001W8_n430ProveedorTelefono = new bool[] {false} ;
         T001W8_A40001ProveedorImagen_GXI = new string[] {""} ;
         T001W8_n40001ProveedorImagen_GXI = new bool[] {false} ;
         T001W8_A344ProveedorEstado = new string[] {""} ;
         T001W8_A432ProveedorImagen = new string[] {""} ;
         T001W8_n432ProveedorImagen = new bool[] {false} ;
         T001W22_A282ProveedorNombre = new string[] {""} ;
         T001W22_A433ProveedorEmail = new string[] {""} ;
         T001W22_n433ProveedorEmail = new bool[] {false} ;
         T001W22_A430ProveedorTelefono = new string[] {""} ;
         T001W22_n430ProveedorTelefono = new bool[] {false} ;
         T001W22_A40001ProveedorImagen_GXI = new string[] {""} ;
         T001W22_n40001ProveedorImagen_GXI = new bool[] {false} ;
         T001W22_A344ProveedorEstado = new string[] {""} ;
         T001W22_A432ProveedorImagen = new string[] {""} ;
         T001W22_n432ProveedorImagen = new bool[] {false} ;
         T001W23_A503ComisionesID = new long[1] ;
         T001W23_A133ProveedorID = new long[1] ;
         T001W7_A503ComisionesID = new long[1] ;
         T001W7_A133ProveedorID = new long[1] ;
         T001W6_A503ComisionesID = new long[1] ;
         T001W6_A133ProveedorID = new long[1] ;
         T001W26_A282ProveedorNombre = new string[] {""} ;
         T001W26_A433ProveedorEmail = new string[] {""} ;
         T001W26_n433ProveedorEmail = new bool[] {false} ;
         T001W26_A430ProveedorTelefono = new string[] {""} ;
         T001W26_n430ProveedorTelefono = new bool[] {false} ;
         T001W26_A40001ProveedorImagen_GXI = new string[] {""} ;
         T001W26_n40001ProveedorImagen_GXI = new bool[] {false} ;
         T001W26_A344ProveedorEstado = new string[] {""} ;
         T001W26_A432ProveedorImagen = new string[] {""} ;
         T001W26_n432ProveedorImagen = new bool[] {false} ;
         T001W27_A503ComisionesID = new long[1] ;
         T001W27_A133ProveedorID = new long[1] ;
         Z166ProfesionalesPrimerNombre = "";
         Z191ProfesionalesSegundoNombre = "";
         Z167ProfesionalesApellidoPrimero = "";
         Z192ProfesionalesApellidoSegundo = "";
         Z170ProfesionalesTelefono = "";
         Z107EstadosTipo = "";
         Z109EstadosGenericosNombre = "";
         T001W28_A503ComisionesID = new long[1] ;
         T001W28_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T001W28_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T001W28_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T001W28_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T001W28_A170ProfesionalesTelefono = new string[] {""} ;
         T001W28_A109EstadosGenericosNombre = new string[] {""} ;
         T001W28_A120ProfesionalesId = new string[] {""} ;
         T001W28_A107EstadosTipo = new string[] {""} ;
         T001W28_A108EstadosGenericosId = new int[1] ;
         T001W4_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T001W4_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T001W4_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T001W4_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T001W4_A170ProfesionalesTelefono = new string[] {""} ;
         T001W4_A107EstadosTipo = new string[] {""} ;
         T001W4_A108EstadosGenericosId = new int[1] ;
         T001W5_A109EstadosGenericosNombre = new string[] {""} ;
         T001W29_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T001W29_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T001W29_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T001W29_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T001W29_A170ProfesionalesTelefono = new string[] {""} ;
         T001W29_A107EstadosTipo = new string[] {""} ;
         T001W29_A108EstadosGenericosId = new int[1] ;
         T001W30_A109EstadosGenericosNombre = new string[] {""} ;
         T001W31_A503ComisionesID = new long[1] ;
         T001W31_A120ProfesionalesId = new string[] {""} ;
         T001W3_A503ComisionesID = new long[1] ;
         T001W3_A120ProfesionalesId = new string[] {""} ;
         T001W2_A503ComisionesID = new long[1] ;
         T001W2_A120ProfesionalesId = new string[] {""} ;
         T001W34_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T001W34_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T001W34_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T001W34_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T001W34_A170ProfesionalesTelefono = new string[] {""} ;
         T001W34_A107EstadosTipo = new string[] {""} ;
         T001W34_A108EstadosGenericosId = new int[1] ;
         T001W35_A109EstadosGenericosNombre = new string[] {""} ;
         T001W36_A503ComisionesID = new long[1] ;
         T001W36_A120ProfesionalesId = new string[] {""} ;
         Gridlevel_proveedoresRow = new GXWebRow();
         subGridlevel_proveedores_Linesclass = "";
         T001W37_A133ProveedorID = new long[1] ;
         T001W37_A282ProveedorNombre = new string[] {""} ;
         ROClassString = "";
         gxphoneLink = "";
         GXCCtlgxBlob = "";
         Gridlevel_profesionalesRow = new GXWebRow();
         subGridlevel_profesionales_Linesclass = "";
         imgprompt_120_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i505ComisionesTipo = "";
         i511ComisionesEstado = "";
         i507ComisionesFechaAlta = (DateTime)(DateTime.MinValue);
         Gridlevel_proveedoresColumn = new GXWebColumn();
         Gridlevel_profesionalesColumn = new GXWebColumn();
         T001W38_A133ProveedorID = new long[1] ;
         T001W38_A282ProveedorNombre = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.comisiones__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisiones__default(),
            new Object[][] {
                new Object[] {
               T001W2_A503ComisionesID, T001W2_A120ProfesionalesId
               }
               , new Object[] {
               T001W3_A503ComisionesID, T001W3_A120ProfesionalesId
               }
               , new Object[] {
               T001W4_A166ProfesionalesPrimerNombre, T001W4_A191ProfesionalesSegundoNombre, T001W4_A167ProfesionalesApellidoPrimero, T001W4_A192ProfesionalesApellidoSegundo, T001W4_A170ProfesionalesTelefono, T001W4_A107EstadosTipo, T001W4_A108EstadosGenericosId
               }
               , new Object[] {
               T001W5_A109EstadosGenericosNombre
               }
               , new Object[] {
               T001W6_A503ComisionesID, T001W6_A133ProveedorID
               }
               , new Object[] {
               T001W7_A503ComisionesID, T001W7_A133ProveedorID
               }
               , new Object[] {
               T001W8_A282ProveedorNombre, T001W8_A433ProveedorEmail, T001W8_n433ProveedorEmail, T001W8_A430ProveedorTelefono, T001W8_n430ProveedorTelefono, T001W8_A40001ProveedorImagen_GXI, T001W8_n40001ProveedorImagen_GXI, T001W8_A344ProveedorEstado, T001W8_A432ProveedorImagen, T001W8_n432ProveedorImagen
               }
               , new Object[] {
               T001W9_A503ComisionesID, T001W9_A504ComisionesNombre, T001W9_A505ComisionesTipo, T001W9_A40000ComisionesImagen_GXI, T001W9_n40000ComisionesImagen_GXI, T001W9_A506ComisionesDefault, T001W9_n506ComisionesDefault, T001W9_A520ComisionesGlobal, T001W9_n520ComisionesGlobal, T001W9_A507ComisionesFechaAlta,
               T001W9_n507ComisionesFechaAlta, T001W9_A508ComisionesEspermanente, T001W9_n508ComisionesEspermanente, T001W9_A509ComisionesFechaVigencia, T001W9_n509ComisionesFechaVigencia, T001W9_A510ComisionesFechaVencimiento, T001W9_n510ComisionesFechaVencimiento, T001W9_A511ComisionesEstado, T001W9_n511ComisionesEstado, T001W9_A518ComisionesComentario,
               T001W9_n518ComisionesComentario, T001W9_A512ComisionesInventarioEnum, T001W9_n512ComisionesInventarioEnum, T001W9_A519ComisionesImagen, T001W9_n519ComisionesImagen
               }
               , new Object[] {
               T001W10_A503ComisionesID, T001W10_A504ComisionesNombre, T001W10_A505ComisionesTipo, T001W10_A40000ComisionesImagen_GXI, T001W10_n40000ComisionesImagen_GXI, T001W10_A506ComisionesDefault, T001W10_n506ComisionesDefault, T001W10_A520ComisionesGlobal, T001W10_n520ComisionesGlobal, T001W10_A507ComisionesFechaAlta,
               T001W10_n507ComisionesFechaAlta, T001W10_A508ComisionesEspermanente, T001W10_n508ComisionesEspermanente, T001W10_A509ComisionesFechaVigencia, T001W10_n509ComisionesFechaVigencia, T001W10_A510ComisionesFechaVencimiento, T001W10_n510ComisionesFechaVencimiento, T001W10_A511ComisionesEstado, T001W10_n511ComisionesEstado, T001W10_A518ComisionesComentario,
               T001W10_n518ComisionesComentario, T001W10_A512ComisionesInventarioEnum, T001W10_n512ComisionesInventarioEnum, T001W10_A519ComisionesImagen, T001W10_n519ComisionesImagen
               }
               , new Object[] {
               T001W11_A503ComisionesID, T001W11_A504ComisionesNombre, T001W11_A505ComisionesTipo, T001W11_A40000ComisionesImagen_GXI, T001W11_n40000ComisionesImagen_GXI, T001W11_A506ComisionesDefault, T001W11_n506ComisionesDefault, T001W11_A520ComisionesGlobal, T001W11_n520ComisionesGlobal, T001W11_A507ComisionesFechaAlta,
               T001W11_n507ComisionesFechaAlta, T001W11_A508ComisionesEspermanente, T001W11_n508ComisionesEspermanente, T001W11_A509ComisionesFechaVigencia, T001W11_n509ComisionesFechaVigencia, T001W11_A510ComisionesFechaVencimiento, T001W11_n510ComisionesFechaVencimiento, T001W11_A511ComisionesEstado, T001W11_n511ComisionesEstado, T001W11_A518ComisionesComentario,
               T001W11_n518ComisionesComentario, T001W11_A512ComisionesInventarioEnum, T001W11_n512ComisionesInventarioEnum, T001W11_A519ComisionesImagen, T001W11_n519ComisionesImagen
               }
               , new Object[] {
               T001W12_A503ComisionesID
               }
               , new Object[] {
               T001W13_A503ComisionesID
               }
               , new Object[] {
               T001W14_A503ComisionesID
               }
               , new Object[] {
               T001W15_A503ComisionesID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001W19_A503ComisionesID, T001W19_A513ComisionesAgruparRubrosId
               }
               , new Object[] {
               T001W20_A503ComisionesID
               }
               , new Object[] {
               T001W21_A503ComisionesID, T001W21_A282ProveedorNombre, T001W21_A433ProveedorEmail, T001W21_n433ProveedorEmail, T001W21_A430ProveedorTelefono, T001W21_n430ProveedorTelefono, T001W21_A40001ProveedorImagen_GXI, T001W21_n40001ProveedorImagen_GXI, T001W21_A344ProveedorEstado, T001W21_A133ProveedorID,
               T001W21_A432ProveedorImagen, T001W21_n432ProveedorImagen
               }
               , new Object[] {
               T001W22_A282ProveedorNombre, T001W22_A433ProveedorEmail, T001W22_n433ProveedorEmail, T001W22_A430ProveedorTelefono, T001W22_n430ProveedorTelefono, T001W22_A40001ProveedorImagen_GXI, T001W22_n40001ProveedorImagen_GXI, T001W22_A344ProveedorEstado, T001W22_A432ProveedorImagen, T001W22_n432ProveedorImagen
               }
               , new Object[] {
               T001W23_A503ComisionesID, T001W23_A133ProveedorID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001W26_A282ProveedorNombre, T001W26_A433ProveedorEmail, T001W26_n433ProveedorEmail, T001W26_A430ProveedorTelefono, T001W26_n430ProveedorTelefono, T001W26_A40001ProveedorImagen_GXI, T001W26_n40001ProveedorImagen_GXI, T001W26_A344ProveedorEstado, T001W26_A432ProveedorImagen, T001W26_n432ProveedorImagen
               }
               , new Object[] {
               T001W27_A503ComisionesID, T001W27_A133ProveedorID
               }
               , new Object[] {
               T001W28_A503ComisionesID, T001W28_A166ProfesionalesPrimerNombre, T001W28_A191ProfesionalesSegundoNombre, T001W28_A167ProfesionalesApellidoPrimero, T001W28_A192ProfesionalesApellidoSegundo, T001W28_A170ProfesionalesTelefono, T001W28_A109EstadosGenericosNombre, T001W28_A120ProfesionalesId, T001W28_A107EstadosTipo, T001W28_A108EstadosGenericosId
               }
               , new Object[] {
               T001W29_A166ProfesionalesPrimerNombre, T001W29_A191ProfesionalesSegundoNombre, T001W29_A167ProfesionalesApellidoPrimero, T001W29_A192ProfesionalesApellidoSegundo, T001W29_A170ProfesionalesTelefono, T001W29_A107EstadosTipo, T001W29_A108EstadosGenericosId
               }
               , new Object[] {
               T001W30_A109EstadosGenericosNombre
               }
               , new Object[] {
               T001W31_A503ComisionesID, T001W31_A120ProfesionalesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001W34_A166ProfesionalesPrimerNombre, T001W34_A191ProfesionalesSegundoNombre, T001W34_A167ProfesionalesApellidoPrimero, T001W34_A192ProfesionalesApellidoSegundo, T001W34_A170ProfesionalesTelefono, T001W34_A107EstadosTipo, T001W34_A108EstadosGenericosId
               }
               , new Object[] {
               T001W35_A109EstadosGenericosNombre
               }
               , new Object[] {
               T001W36_A503ComisionesID, T001W36_A120ProfesionalesId
               }
               , new Object[] {
               T001W37_A133ProveedorID, T001W37_A282ProveedorNombre
               }
               , new Object[] {
               T001W38_A133ProveedorID, T001W38_A282ProveedorNombre
               }
            }
         );
         AV20Pgmname = "Comisiones";
         Z520ComisionesGlobal = false;
         n520ComisionesGlobal = false;
         A520ComisionesGlobal = false;
         n520ComisionesGlobal = false;
         i520ComisionesGlobal = false;
         n520ComisionesGlobal = false;
         Z507ComisionesFechaAlta = DateTimeUtil.Now( context);
         n507ComisionesFechaAlta = false;
         A507ComisionesFechaAlta = DateTimeUtil.Now( context);
         n507ComisionesFechaAlta = false;
         i507ComisionesFechaAlta = DateTimeUtil.Now( context);
         n507ComisionesFechaAlta = false;
         Z511ComisionesEstado = "HAB";
         n511ComisionesEstado = false;
         A511ComisionesEstado = "HAB";
         n511ComisionesEstado = false;
         i511ComisionesEstado = "HAB";
         n511ComisionesEstado = false;
         Z505ComisionesTipo = "C";
         A505ComisionesTipo = "C";
         i505ComisionesTipo = "C";
      }

      private short nIsMod_76 ;
      private short nRcdDeleted_75 ;
      private short nRcdExists_75 ;
      private short nIsMod_75 ;
      private short nRcdDeleted_76 ;
      private short nRcdExists_76 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount75 ;
      private short RcdFound75 ;
      private short nBlankRcdUsr75 ;
      private short nBlankRcdCount76 ;
      private short RcdFound76 ;
      private short nBlankRcdUsr76 ;
      private short Gx_BScreen ;
      private short RcdFound74 ;
      private short nIsDirty_75 ;
      private short nIsDirty_76 ;
      private short subGridlevel_proveedores_Backcolorstyle ;
      private short subGridlevel_proveedores_Backstyle ;
      private short subGridlevel_profesionales_Backcolorstyle ;
      private short subGridlevel_profesionales_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_proveedores_Allowselection ;
      private short subGridlevel_proveedores_Allowhovering ;
      private short subGridlevel_proveedores_Allowcollapsing ;
      private short subGridlevel_proveedores_Collapsed ;
      private short subGridlevel_profesionales_Allowselection ;
      private short subGridlevel_profesionales_Allowhovering ;
      private short subGridlevel_profesionales_Allowcollapsing ;
      private short subGridlevel_profesionales_Collapsed ;
      private int Z512ComisionesInventarioEnum ;
      private int nRC_GXsfl_72 ;
      private int nGXsfl_72_idx=1 ;
      private int nRC_GXsfl_88 ;
      private int nGXsfl_88_idx=1 ;
      private int A108EstadosGenericosId ;
      private int trnEnded ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int edtComisionesID_Enabled ;
      private int edtComisionesNombre_Enabled ;
      private int edtComisionesDefault_Enabled ;
      private int imgComisionesImagen_Enabled ;
      private int edtComisionesComentario_Enabled ;
      private int divTabtablelevel_profesionales_Visible ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtComisionesFechaAlta_Visible ;
      private int edtComisionesFechaAlta_Enabled ;
      private int edtComisionesEspermanente_Visible ;
      private int edtComisionesEspermanente_Enabled ;
      private int edtComisionesFechaVigencia_Visible ;
      private int edtComisionesFechaVigencia_Enabled ;
      private int edtComisionesFechaVencimiento_Visible ;
      private int edtComisionesFechaVencimiento_Enabled ;
      private int A512ComisionesInventarioEnum ;
      private int edtComisionesInventarioEnum_Enabled ;
      private int edtComisionesInventarioEnum_Visible ;
      private int edtProveedorEmail_Enabled ;
      private int edtProveedorTelefono_Enabled ;
      private int edtProveedorImagen_Enabled ;
      private int fRowAdded ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesApellidoSegundo_Enabled ;
      private int edtProfesionalesTelefono_Enabled ;
      private int edtEstadosTipo_Enabled ;
      private int edtEstadosGenericosId_Enabled ;
      private int edtEstadosGenericosNombre_Enabled ;
      private int Gxuitabspanel_tabs_Activepage ;
      private int Z108EstadosGenericosId ;
      private int subGridlevel_proveedores_Backcolor ;
      private int subGridlevel_proveedores_Allbackcolor ;
      private int subGridlevel_profesionales_Backcolor ;
      private int subGridlevel_profesionales_Allbackcolor ;
      private int imgprompt_120_Visible ;
      private int defedtEstadosGenericosId_Enabled ;
      private int defedtEstadosTipo_Enabled ;
      private int defedtProfesionalesId_Enabled ;
      private int defdynProveedorID_Enabled ;
      private int idxLst ;
      private int subGridlevel_proveedores_Selectedindex ;
      private int subGridlevel_proveedores_Selectioncolor ;
      private int subGridlevel_proveedores_Hoveringcolor ;
      private int subGridlevel_profesionales_Selectedindex ;
      private int subGridlevel_profesionales_Selectioncolor ;
      private int subGridlevel_profesionales_Hoveringcolor ;
      private long wcpOAV7ComisionesID ;
      private long Z503ComisionesID ;
      private long Z133ProveedorID ;
      private long A133ProveedorID ;
      private long AV7ComisionesID ;
      private long A503ComisionesID ;
      private long GRIDLEVEL_PROVEEDORES_nFirstRecordOnPage ;
      private long GRIDLEVEL_PROFESIONALES_nFirstRecordOnPage ;
      private decimal Z506ComisionesDefault ;
      private decimal A506ComisionesDefault ;
      private string sPrefix ;
      private string sGXsfl_88_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z504ComisionesNombre ;
      private string Z505ComisionesTipo ;
      private string Z511ComisionesEstado ;
      private string Z120ProfesionalesId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A120ProfesionalesId ;
      private string A107EstadosTipo ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbComisionesEstado_Internalname ;
      private string sGXsfl_72_idx="0001" ;
      private string A511ComisionesEstado ;
      private string A505ComisionesTipo ;
      private string cmbComisionesTipo_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Gxuitabspanel_tabs_Class ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblTabgeneral_title_Internalname ;
      private string lblTabgeneral_title_Jsonclick ;
      private string divTableattributes_Internalname ;
      private string edtComisionesID_Internalname ;
      private string TempTags ;
      private string edtComisionesID_Jsonclick ;
      private string cmbComisionesEstado_Jsonclick ;
      private string divTb1_Internalname ;
      private string cmbComisionesTipo_Jsonclick ;
      private string edtComisionesNombre_Internalname ;
      private string A504ComisionesNombre ;
      private string edtComisionesNombre_Jsonclick ;
      private string edtComisionesDefault_Internalname ;
      private string edtComisionesDefault_Jsonclick ;
      private string divComisionesglobal_cell_Internalname ;
      private string divComisionesglobal_cell_Class ;
      private string chkComisionesGlobal_Internalname ;
      private string divTb2_Internalname ;
      private string imgComisionesImagen_Internalname ;
      private string sImgUrl ;
      private string edtComisionesComentario_Internalname ;
      private string lblTablevel_proveedores_title_Internalname ;
      private string lblTablevel_proveedores_title_Jsonclick ;
      private string divTabtablelevel_proveedores_Internalname ;
      private string divTableleaflevel_proveedores_Internalname ;
      private string lblTablevel_profesionales_title_Internalname ;
      private string lblTablevel_profesionales_title_Jsonclick ;
      private string divTabtablelevel_profesionales_Internalname ;
      private string divTableleaflevel_profesionales_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtComisionesFechaAlta_Internalname ;
      private string edtComisionesFechaAlta_Jsonclick ;
      private string edtComisionesEspermanente_Internalname ;
      private string edtComisionesEspermanente_Jsonclick ;
      private string edtComisionesFechaVigencia_Internalname ;
      private string edtComisionesFechaVigencia_Jsonclick ;
      private string edtComisionesFechaVencimiento_Internalname ;
      private string edtComisionesFechaVencimiento_Jsonclick ;
      private string edtComisionesInventarioEnum_Internalname ;
      private string edtComisionesInventarioEnum_Jsonclick ;
      private string sMode75 ;
      private string dynProveedorID_Internalname ;
      private string edtProveedorEmail_Internalname ;
      private string edtProveedorTelefono_Internalname ;
      private string edtProveedorImagen_Internalname ;
      private string cmbProveedorEstado_Internalname ;
      private string sStyleString ;
      private string subGridlevel_proveedores_Internalname ;
      private string sMode76 ;
      private string edtProfesionalesId_Internalname ;
      private string edtProfesionalesPrimerNombre_Internalname ;
      private string edtProfesionalesSegundoNombre_Internalname ;
      private string edtProfesionalesApellidoPrimero_Internalname ;
      private string edtProfesionalesApellidoSegundo_Internalname ;
      private string edtProfesionalesTelefono_Internalname ;
      private string edtEstadosTipo_Internalname ;
      private string edtEstadosGenericosId_Internalname ;
      private string edtEstadosGenericosNombre_Internalname ;
      private string imgprompt_120_Link ;
      private string subGridlevel_profesionales_Internalname ;
      private string AV20Pgmname ;
      private string A282ProveedorNombre ;
      private string Gxuitabspanel_tabs_Objectcall ;
      private string Gxuitabspanel_tabs_Activepagecontrolname ;
      private string hsh ;
      private string sMode74 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A192ProfesionalesApellidoSegundo ;
      private string A170ProfesionalesTelefono ;
      private string A109EstadosGenericosNombre ;
      private string A430ProveedorTelefono ;
      private string A344ProveedorEstado ;
      private string GXEncryptionTmp ;
      private string Z282ProveedorNombre ;
      private string Z430ProveedorTelefono ;
      private string Z344ProveedorEstado ;
      private string Z166ProfesionalesPrimerNombre ;
      private string Z191ProfesionalesSegundoNombre ;
      private string Z167ProfesionalesApellidoPrimero ;
      private string Z192ProfesionalesApellidoSegundo ;
      private string Z170ProfesionalesTelefono ;
      private string Z107EstadosTipo ;
      private string Z109EstadosGenericosNombre ;
      private string sGXsfl_72_fel_idx="0001" ;
      private string subGridlevel_proveedores_Class ;
      private string subGridlevel_proveedores_Linesclass ;
      private string dynProveedorID_Jsonclick ;
      private string ROClassString ;
      private string edtProveedorEmail_Jsonclick ;
      private string gxphoneLink ;
      private string edtProveedorTelefono_Jsonclick ;
      private string cmbProveedorEstado_Jsonclick ;
      private string GXCCtlgxBlob ;
      private string imgprompt_120_Internalname ;
      private string sGXsfl_88_fel_idx="0001" ;
      private string subGridlevel_profesionales_Class ;
      private string subGridlevel_profesionales_Linesclass ;
      private string edtProfesionalesId_Jsonclick ;
      private string imgprompt_120_gximage ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesSegundoNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtProfesionalesApellidoSegundo_Jsonclick ;
      private string edtProfesionalesTelefono_Jsonclick ;
      private string edtEstadosTipo_Jsonclick ;
      private string edtEstadosGenericosId_Jsonclick ;
      private string edtEstadosGenericosNombre_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i505ComisionesTipo ;
      private string i511ComisionesEstado ;
      private string subGridlevel_proveedores_Header ;
      private string subGridlevel_profesionales_Header ;
      private DateTime Z507ComisionesFechaAlta ;
      private DateTime Z509ComisionesFechaVigencia ;
      private DateTime Z510ComisionesFechaVencimiento ;
      private DateTime A507ComisionesFechaAlta ;
      private DateTime A509ComisionesFechaVigencia ;
      private DateTime A510ComisionesFechaVencimiento ;
      private DateTime i507ComisionesFechaAlta ;
      private bool Z520ComisionesGlobal ;
      private bool Z508ComisionesEspermanente ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n511ComisionesEstado ;
      private bool A520ComisionesGlobal ;
      private bool n520ComisionesGlobal ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool A519ComisionesImagen_IsBlob ;
      private bool A508ComisionesEspermanente ;
      private bool bGXsfl_72_Refreshing=false ;
      private bool bGXsfl_88_Refreshing=false ;
      private bool n506ComisionesDefault ;
      private bool n507ComisionesFechaAlta ;
      private bool n508ComisionesEspermanente ;
      private bool n509ComisionesFechaVigencia ;
      private bool n510ComisionesFechaVencimiento ;
      private bool n512ComisionesInventarioEnum ;
      private bool n40000ComisionesImagen_GXI ;
      private bool n40001ProveedorImagen_GXI ;
      private bool Gxuitabspanel_tabs_Enabled ;
      private bool Gxuitabspanel_tabs_Visible ;
      private bool n519ComisionesImagen ;
      private bool n518ComisionesComentario ;
      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private bool n433ProveedorEmail ;
      private bool n430ProveedorTelefono ;
      private bool n432ProveedorImagen ;
      private bool A432ProveedorImagen_IsBlob ;
      private bool i520ComisionesGlobal ;
      private string A518ComisionesComentario ;
      private string Z518ComisionesComentario ;
      private string A40000ComisionesImagen_GXI ;
      private string A40001ProveedorImagen_GXI ;
      private string A433ProveedorEmail ;
      private string Z40000ComisionesImagen_GXI ;
      private string Z433ProveedorEmail ;
      private string Z40001ProveedorImagen_GXI ;
      private string A519ComisionesImagen ;
      private string A432ProveedorImagen ;
      private string Z519ComisionesImagen ;
      private string Z432ProveedorImagen ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_proveedoresContainer ;
      private GXWebGrid Gridlevel_profesionalesContainer ;
      private GXWebRow Gridlevel_proveedoresRow ;
      private GXWebRow Gridlevel_profesionalesRow ;
      private GXWebColumn Gridlevel_proveedoresColumn ;
      private GXWebColumn Gridlevel_profesionalesColumn ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbComisionesEstado ;
      private GXCombobox cmbComisionesTipo ;
      private GXCheckbox chkComisionesGlobal ;
      private GXCombobox dynProveedorID ;
      private GXCombobox cmbProveedorEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV11WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] T001W11_A503ComisionesID ;
      private string[] T001W11_A504ComisionesNombre ;
      private string[] T001W11_A505ComisionesTipo ;
      private string[] T001W11_A40000ComisionesImagen_GXI ;
      private bool[] T001W11_n40000ComisionesImagen_GXI ;
      private decimal[] T001W11_A506ComisionesDefault ;
      private bool[] T001W11_n506ComisionesDefault ;
      private bool[] T001W11_A520ComisionesGlobal ;
      private bool[] T001W11_n520ComisionesGlobal ;
      private DateTime[] T001W11_A507ComisionesFechaAlta ;
      private bool[] T001W11_n507ComisionesFechaAlta ;
      private bool[] T001W11_A508ComisionesEspermanente ;
      private bool[] T001W11_n508ComisionesEspermanente ;
      private DateTime[] T001W11_A509ComisionesFechaVigencia ;
      private bool[] T001W11_n509ComisionesFechaVigencia ;
      private DateTime[] T001W11_A510ComisionesFechaVencimiento ;
      private bool[] T001W11_n510ComisionesFechaVencimiento ;
      private string[] T001W11_A511ComisionesEstado ;
      private bool[] T001W11_n511ComisionesEstado ;
      private string[] T001W11_A518ComisionesComentario ;
      private bool[] T001W11_n518ComisionesComentario ;
      private int[] T001W11_A512ComisionesInventarioEnum ;
      private bool[] T001W11_n512ComisionesInventarioEnum ;
      private string[] T001W11_A519ComisionesImagen ;
      private bool[] T001W11_n519ComisionesImagen ;
      private long[] T001W12_A503ComisionesID ;
      private long[] T001W10_A503ComisionesID ;
      private string[] T001W10_A504ComisionesNombre ;
      private string[] T001W10_A505ComisionesTipo ;
      private string[] T001W10_A40000ComisionesImagen_GXI ;
      private bool[] T001W10_n40000ComisionesImagen_GXI ;
      private decimal[] T001W10_A506ComisionesDefault ;
      private bool[] T001W10_n506ComisionesDefault ;
      private bool[] T001W10_A520ComisionesGlobal ;
      private bool[] T001W10_n520ComisionesGlobal ;
      private DateTime[] T001W10_A507ComisionesFechaAlta ;
      private bool[] T001W10_n507ComisionesFechaAlta ;
      private bool[] T001W10_A508ComisionesEspermanente ;
      private bool[] T001W10_n508ComisionesEspermanente ;
      private DateTime[] T001W10_A509ComisionesFechaVigencia ;
      private bool[] T001W10_n509ComisionesFechaVigencia ;
      private DateTime[] T001W10_A510ComisionesFechaVencimiento ;
      private bool[] T001W10_n510ComisionesFechaVencimiento ;
      private string[] T001W10_A511ComisionesEstado ;
      private bool[] T001W10_n511ComisionesEstado ;
      private string[] T001W10_A518ComisionesComentario ;
      private bool[] T001W10_n518ComisionesComentario ;
      private int[] T001W10_A512ComisionesInventarioEnum ;
      private bool[] T001W10_n512ComisionesInventarioEnum ;
      private string[] T001W10_A519ComisionesImagen ;
      private bool[] T001W10_n519ComisionesImagen ;
      private long[] T001W13_A503ComisionesID ;
      private long[] T001W14_A503ComisionesID ;
      private long[] T001W9_A503ComisionesID ;
      private string[] T001W9_A504ComisionesNombre ;
      private string[] T001W9_A505ComisionesTipo ;
      private string[] T001W9_A40000ComisionesImagen_GXI ;
      private bool[] T001W9_n40000ComisionesImagen_GXI ;
      private decimal[] T001W9_A506ComisionesDefault ;
      private bool[] T001W9_n506ComisionesDefault ;
      private bool[] T001W9_A520ComisionesGlobal ;
      private bool[] T001W9_n520ComisionesGlobal ;
      private DateTime[] T001W9_A507ComisionesFechaAlta ;
      private bool[] T001W9_n507ComisionesFechaAlta ;
      private bool[] T001W9_A508ComisionesEspermanente ;
      private bool[] T001W9_n508ComisionesEspermanente ;
      private DateTime[] T001W9_A509ComisionesFechaVigencia ;
      private bool[] T001W9_n509ComisionesFechaVigencia ;
      private DateTime[] T001W9_A510ComisionesFechaVencimiento ;
      private bool[] T001W9_n510ComisionesFechaVencimiento ;
      private string[] T001W9_A511ComisionesEstado ;
      private bool[] T001W9_n511ComisionesEstado ;
      private string[] T001W9_A518ComisionesComentario ;
      private bool[] T001W9_n518ComisionesComentario ;
      private int[] T001W9_A512ComisionesInventarioEnum ;
      private bool[] T001W9_n512ComisionesInventarioEnum ;
      private string[] T001W9_A519ComisionesImagen ;
      private bool[] T001W9_n519ComisionesImagen ;
      private long[] T001W15_A503ComisionesID ;
      private long[] T001W19_A503ComisionesID ;
      private long[] T001W19_A513ComisionesAgruparRubrosId ;
      private long[] T001W20_A503ComisionesID ;
      private long[] T001W21_A503ComisionesID ;
      private string[] T001W21_A282ProveedorNombre ;
      private string[] T001W21_A433ProveedorEmail ;
      private bool[] T001W21_n433ProveedorEmail ;
      private string[] T001W21_A430ProveedorTelefono ;
      private bool[] T001W21_n430ProveedorTelefono ;
      private string[] T001W21_A40001ProveedorImagen_GXI ;
      private bool[] T001W21_n40001ProveedorImagen_GXI ;
      private string[] T001W21_A344ProveedorEstado ;
      private long[] T001W21_A133ProveedorID ;
      private string[] T001W21_A432ProveedorImagen ;
      private bool[] T001W21_n432ProveedorImagen ;
      private string[] T001W8_A282ProveedorNombre ;
      private string[] T001W8_A433ProveedorEmail ;
      private bool[] T001W8_n433ProveedorEmail ;
      private string[] T001W8_A430ProveedorTelefono ;
      private bool[] T001W8_n430ProveedorTelefono ;
      private string[] T001W8_A40001ProveedorImagen_GXI ;
      private bool[] T001W8_n40001ProveedorImagen_GXI ;
      private string[] T001W8_A344ProveedorEstado ;
      private string[] T001W8_A432ProveedorImagen ;
      private bool[] T001W8_n432ProveedorImagen ;
      private string[] T001W22_A282ProveedorNombre ;
      private string[] T001W22_A433ProveedorEmail ;
      private bool[] T001W22_n433ProveedorEmail ;
      private string[] T001W22_A430ProveedorTelefono ;
      private bool[] T001W22_n430ProveedorTelefono ;
      private string[] T001W22_A40001ProveedorImagen_GXI ;
      private bool[] T001W22_n40001ProveedorImagen_GXI ;
      private string[] T001W22_A344ProveedorEstado ;
      private string[] T001W22_A432ProveedorImagen ;
      private bool[] T001W22_n432ProveedorImagen ;
      private long[] T001W23_A503ComisionesID ;
      private long[] T001W23_A133ProveedorID ;
      private long[] T001W7_A503ComisionesID ;
      private long[] T001W7_A133ProveedorID ;
      private long[] T001W6_A503ComisionesID ;
      private long[] T001W6_A133ProveedorID ;
      private string[] T001W26_A282ProveedorNombre ;
      private string[] T001W26_A433ProveedorEmail ;
      private bool[] T001W26_n433ProveedorEmail ;
      private string[] T001W26_A430ProveedorTelefono ;
      private bool[] T001W26_n430ProveedorTelefono ;
      private string[] T001W26_A40001ProveedorImagen_GXI ;
      private bool[] T001W26_n40001ProveedorImagen_GXI ;
      private string[] T001W26_A344ProveedorEstado ;
      private string[] T001W26_A432ProveedorImagen ;
      private bool[] T001W26_n432ProveedorImagen ;
      private long[] T001W27_A503ComisionesID ;
      private long[] T001W27_A133ProveedorID ;
      private long[] T001W28_A503ComisionesID ;
      private string[] T001W28_A166ProfesionalesPrimerNombre ;
      private string[] T001W28_A191ProfesionalesSegundoNombre ;
      private string[] T001W28_A167ProfesionalesApellidoPrimero ;
      private string[] T001W28_A192ProfesionalesApellidoSegundo ;
      private string[] T001W28_A170ProfesionalesTelefono ;
      private string[] T001W28_A109EstadosGenericosNombre ;
      private string[] T001W28_A120ProfesionalesId ;
      private string[] T001W28_A107EstadosTipo ;
      private int[] T001W28_A108EstadosGenericosId ;
      private string[] T001W4_A166ProfesionalesPrimerNombre ;
      private string[] T001W4_A191ProfesionalesSegundoNombre ;
      private string[] T001W4_A167ProfesionalesApellidoPrimero ;
      private string[] T001W4_A192ProfesionalesApellidoSegundo ;
      private string[] T001W4_A170ProfesionalesTelefono ;
      private string[] T001W4_A107EstadosTipo ;
      private int[] T001W4_A108EstadosGenericosId ;
      private string[] T001W5_A109EstadosGenericosNombre ;
      private string[] T001W29_A166ProfesionalesPrimerNombre ;
      private string[] T001W29_A191ProfesionalesSegundoNombre ;
      private string[] T001W29_A167ProfesionalesApellidoPrimero ;
      private string[] T001W29_A192ProfesionalesApellidoSegundo ;
      private string[] T001W29_A170ProfesionalesTelefono ;
      private string[] T001W29_A107EstadosTipo ;
      private int[] T001W29_A108EstadosGenericosId ;
      private string[] T001W30_A109EstadosGenericosNombre ;
      private long[] T001W31_A503ComisionesID ;
      private string[] T001W31_A120ProfesionalesId ;
      private long[] T001W3_A503ComisionesID ;
      private string[] T001W3_A120ProfesionalesId ;
      private long[] T001W2_A503ComisionesID ;
      private string[] T001W2_A120ProfesionalesId ;
      private string[] T001W34_A166ProfesionalesPrimerNombre ;
      private string[] T001W34_A191ProfesionalesSegundoNombre ;
      private string[] T001W34_A167ProfesionalesApellidoPrimero ;
      private string[] T001W34_A192ProfesionalesApellidoSegundo ;
      private string[] T001W34_A170ProfesionalesTelefono ;
      private string[] T001W34_A107EstadosTipo ;
      private int[] T001W34_A108EstadosGenericosId ;
      private string[] T001W35_A109EstadosGenericosNombre ;
      private long[] T001W36_A503ComisionesID ;
      private string[] T001W36_A120ProfesionalesId ;
      private long[] T001W37_A133ProveedorID ;
      private string[] T001W37_A282ProveedorNombre ;
      private long[] T001W38_A133ProveedorID ;
      private string[] T001W38_A282ProveedorNombre ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class comisiones__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class comisiones__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new UpdateCursor(def[30])
       ,new UpdateCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001W2;
        prmT001W2 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001W3;
        prmT001W3 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001W4;
        prmT001W4 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001W5;
        prmT001W5 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001W6;
        prmT001W6 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT001W7;
        prmT001W7 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT001W8;
        prmT001W8 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT001W9;
        prmT001W9 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001W10;
        prmT001W10 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001W11;
        prmT001W11 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001W12;
        prmT001W12 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001W13;
        prmT001W13 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001W14;
        prmT001W14 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001W15;
        prmT001W15 = new Object[] {
        new ParDef("@ComisionesNombre",GXType.NChar,80,0) ,
        new ParDef("@ComisionesTipo",GXType.NChar,1,0) ,
        new ParDef("@ComisionesImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ComisionesImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=2, Tbl="Comisiones", Fld="ComisionesImagen"} ,
        new ParDef("@ComisionesDefault",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@ComisionesGlobal",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ComisionesFechaAlta",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ComisionesEspermanente",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ComisionesFechaVigencia",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ComisionesFechaVencimiento",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ComisionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@ComisionesComentario",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@ComisionesInventarioEnum",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001W16;
        prmT001W16 = new Object[] {
        new ParDef("@ComisionesNombre",GXType.NChar,80,0) ,
        new ParDef("@ComisionesTipo",GXType.NChar,1,0) ,
        new ParDef("@ComisionesDefault",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@ComisionesGlobal",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ComisionesFechaAlta",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ComisionesEspermanente",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ComisionesFechaVigencia",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ComisionesFechaVencimiento",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ComisionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@ComisionesComentario",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@ComisionesInventarioEnum",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001W17;
        prmT001W17 = new Object[] {
        new ParDef("@ComisionesImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ComisionesImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Comisiones", Fld="ComisionesImagen"} ,
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001W18;
        prmT001W18 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001W19;
        prmT001W19 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001W20;
        prmT001W20 = new Object[] {
        };
        Object[] prmT001W21;
        prmT001W21 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT001W22;
        prmT001W22 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT001W23;
        prmT001W23 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT001W24;
        prmT001W24 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT001W25;
        prmT001W25 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT001W26;
        prmT001W26 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT001W27;
        prmT001W27 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001W28;
        prmT001W28 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001W29;
        prmT001W29 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001W30;
        prmT001W30 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001W31;
        prmT001W31 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001W32;
        prmT001W32 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001W33;
        prmT001W33 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001W34;
        prmT001W34 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001W35;
        prmT001W35 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001W36;
        prmT001W36 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001W37;
        prmT001W37 = new Object[] {
        };
        Object[] prmT001W38;
        prmT001W38 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001W2", "SELECT [ComisionesID], [ProfesionalesId] FROM [ComisionesProfesionales] WITH (UPDLOCK) WHERE [ComisionesID] = @ComisionesID AND [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W3", "SELECT [ComisionesID], [ProfesionalesId] FROM [ComisionesProfesionales] WHERE [ComisionesID] = @ComisionesID AND [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W4", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesTelefono], [EstadosTipo], [EstadosGenericosId] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W5", "SELECT [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W6", "SELECT [ComisionesID], [ProveedorID] FROM [ComisionesProveedores] WITH (UPDLOCK) WHERE [ComisionesID] = @ComisionesID AND [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W7", "SELECT [ComisionesID], [ProveedorID] FROM [ComisionesProveedores] WHERE [ComisionesID] = @ComisionesID AND [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W8", "SELECT [ProveedorNombre], [ProveedorEmail], [ProveedorTelefono], [ProveedorImagen_GXI], [ProveedorEstado], [ProveedorImagen] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W9", "SELECT [ComisionesID], [ComisionesNombre], [ComisionesTipo], [ComisionesImagen_GXI], [ComisionesDefault], [ComisionesGlobal], [ComisionesFechaAlta], [ComisionesEspermanente], [ComisionesFechaVigencia], [ComisionesFechaVencimiento], [ComisionesEstado], [ComisionesComentario], [ComisionesInventarioEnum], [ComisionesImagen] FROM [Comisiones] WITH (UPDLOCK) WHERE [ComisionesID] = @ComisionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W10", "SELECT [ComisionesID], [ComisionesNombre], [ComisionesTipo], [ComisionesImagen_GXI], [ComisionesDefault], [ComisionesGlobal], [ComisionesFechaAlta], [ComisionesEspermanente], [ComisionesFechaVigencia], [ComisionesFechaVencimiento], [ComisionesEstado], [ComisionesComentario], [ComisionesInventarioEnum], [ComisionesImagen] FROM [Comisiones] WHERE [ComisionesID] = @ComisionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W11", "SELECT TM1.[ComisionesID], TM1.[ComisionesNombre], TM1.[ComisionesTipo], TM1.[ComisionesImagen_GXI], TM1.[ComisionesDefault], TM1.[ComisionesGlobal], TM1.[ComisionesFechaAlta], TM1.[ComisionesEspermanente], TM1.[ComisionesFechaVigencia], TM1.[ComisionesFechaVencimiento], TM1.[ComisionesEstado], TM1.[ComisionesComentario], TM1.[ComisionesInventarioEnum], TM1.[ComisionesImagen] FROM [Comisiones] TM1 WHERE TM1.[ComisionesID] = @ComisionesID ORDER BY TM1.[ComisionesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001W11,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W12", "SELECT [ComisionesID] FROM [Comisiones] WHERE [ComisionesID] = @ComisionesID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001W12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W13", "SELECT TOP 1 [ComisionesID] FROM [Comisiones] WHERE ( [ComisionesID] > @ComisionesID) ORDER BY [ComisionesID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001W13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001W14", "SELECT TOP 1 [ComisionesID] FROM [Comisiones] WHERE ( [ComisionesID] < @ComisionesID) ORDER BY [ComisionesID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001W14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001W15", "INSERT INTO [Comisiones]([ComisionesNombre], [ComisionesTipo], [ComisionesImagen], [ComisionesImagen_GXI], [ComisionesDefault], [ComisionesGlobal], [ComisionesFechaAlta], [ComisionesEspermanente], [ComisionesFechaVigencia], [ComisionesFechaVencimiento], [ComisionesEstado], [ComisionesComentario], [ComisionesInventarioEnum]) VALUES(@ComisionesNombre, @ComisionesTipo, @ComisionesImagen, @ComisionesImagen_GXI, @ComisionesDefault, @ComisionesGlobal, @ComisionesFechaAlta, @ComisionesEspermanente, @ComisionesFechaVigencia, @ComisionesFechaVencimiento, @ComisionesEstado, @ComisionesComentario, @ComisionesInventarioEnum); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001W15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001W16", "UPDATE [Comisiones] SET [ComisionesNombre]=@ComisionesNombre, [ComisionesTipo]=@ComisionesTipo, [ComisionesDefault]=@ComisionesDefault, [ComisionesGlobal]=@ComisionesGlobal, [ComisionesFechaAlta]=@ComisionesFechaAlta, [ComisionesEspermanente]=@ComisionesEspermanente, [ComisionesFechaVigencia]=@ComisionesFechaVigencia, [ComisionesFechaVencimiento]=@ComisionesFechaVencimiento, [ComisionesEstado]=@ComisionesEstado, [ComisionesComentario]=@ComisionesComentario, [ComisionesInventarioEnum]=@ComisionesInventarioEnum  WHERE [ComisionesID] = @ComisionesID", GxErrorMask.GX_NOMASK,prmT001W16)
           ,new CursorDef("T001W17", "UPDATE [Comisiones] SET [ComisionesImagen]=@ComisionesImagen, [ComisionesImagen_GXI]=@ComisionesImagen_GXI  WHERE [ComisionesID] = @ComisionesID", GxErrorMask.GX_NOMASK,prmT001W17)
           ,new CursorDef("T001W18", "DELETE FROM [Comisiones]  WHERE [ComisionesID] = @ComisionesID", GxErrorMask.GX_NOMASK,prmT001W18)
           ,new CursorDef("T001W19", "SELECT TOP 1 [ComisionesID], [ComisionesAgruparRubrosId] FROM [ComisionesAgruparRubros] WHERE [ComisionesID] = @ComisionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001W20", "SELECT [ComisionesID] FROM [Comisiones] ORDER BY [ComisionesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001W20,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W21", "SELECT T1.[ComisionesID], T2.[ProveedorNombre], T2.[ProveedorEmail], T2.[ProveedorTelefono], T2.[ProveedorImagen_GXI], T2.[ProveedorEstado], T1.[ProveedorID], T2.[ProveedorImagen] FROM ([ComisionesProveedores] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) WHERE T1.[ComisionesID] = @ComisionesID and T1.[ProveedorID] = @ProveedorID ORDER BY T1.[ComisionesID], T1.[ProveedorID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W21,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W22", "SELECT [ProveedorNombre], [ProveedorEmail], [ProveedorTelefono], [ProveedorImagen_GXI], [ProveedorEstado], [ProveedorImagen] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W23", "SELECT [ComisionesID], [ProveedorID] FROM [ComisionesProveedores] WHERE [ComisionesID] = @ComisionesID AND [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W24", "INSERT INTO [ComisionesProveedores]([ComisionesID], [ProveedorID]) VALUES(@ComisionesID, @ProveedorID)", GxErrorMask.GX_NOMASK,prmT001W24)
           ,new CursorDef("T001W25", "DELETE FROM [ComisionesProveedores]  WHERE [ComisionesID] = @ComisionesID AND [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT001W25)
           ,new CursorDef("T001W26", "SELECT [ProveedorNombre], [ProveedorEmail], [ProveedorTelefono], [ProveedorImagen_GXI], [ProveedorEstado], [ProveedorImagen] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W27", "SELECT [ComisionesID], [ProveedorID] FROM [ComisionesProveedores] WHERE [ComisionesID] = @ComisionesID ORDER BY [ComisionesID], [ProveedorID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W27,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W28", "SELECT T1.[ComisionesID], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesTelefono], T3.[EstadosGenericosNombre], T1.[ProfesionalesId], T2.[EstadosTipo], T2.[EstadosGenericosId] FROM (([ComisionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId]) WHERE T1.[ComisionesID] = @ComisionesID and T1.[ProfesionalesId] = @ProfesionalesId ORDER BY T1.[ComisionesID], T1.[ProfesionalesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W28,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W29", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesTelefono], [EstadosTipo], [EstadosGenericosId] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W30", "SELECT [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W31", "SELECT [ComisionesID], [ProfesionalesId] FROM [ComisionesProfesionales] WHERE [ComisionesID] = @ComisionesID AND [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W31,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W32", "INSERT INTO [ComisionesProfesionales]([ComisionesID], [ProfesionalesId]) VALUES(@ComisionesID, @ProfesionalesId)", GxErrorMask.GX_NOMASK,prmT001W32)
           ,new CursorDef("T001W33", "DELETE FROM [ComisionesProfesionales]  WHERE [ComisionesID] = @ComisionesID AND [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT001W33)
           ,new CursorDef("T001W34", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesTelefono], [EstadosTipo], [EstadosGenericosId] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W34,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W35", "SELECT [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W35,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W36", "SELECT [ComisionesID], [ProfesionalesId] FROM [ComisionesProfesionales] WHERE [ComisionesID] = @ComisionesID ORDER BY [ComisionesID], [ProfesionalesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W36,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W37", "SELECT [ProveedorID], [ProveedorNombre] FROM [Proveedor] ORDER BY [ProveedorNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W37,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W38", "SELECT [ProveedorID], [ProveedorNombre] FROM [Proveedor] ORDER BY [ProveedorNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W38,0, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 20);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 3);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              ((bool[]) buf[9])[0] = rslt.wasNull(6);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((bool[]) buf[7])[0] = rslt.getBool(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((bool[]) buf[11])[0] = rslt.getBool(8);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[14])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[16])[0] = rslt.wasNull(10);
              ((string[]) buf[17])[0] = rslt.getString(11, 3);
              ((bool[]) buf[18])[0] = rslt.wasNull(11);
              ((string[]) buf[19])[0] = rslt.getLongVarchar(12);
              ((bool[]) buf[20])[0] = rslt.wasNull(12);
              ((int[]) buf[21])[0] = rslt.getInt(13);
              ((bool[]) buf[22])[0] = rslt.wasNull(13);
              ((string[]) buf[23])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(4));
              ((bool[]) buf[24])[0] = rslt.wasNull(14);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((bool[]) buf[7])[0] = rslt.getBool(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((bool[]) buf[11])[0] = rslt.getBool(8);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[14])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[16])[0] = rslt.wasNull(10);
              ((string[]) buf[17])[0] = rslt.getString(11, 3);
              ((bool[]) buf[18])[0] = rslt.wasNull(11);
              ((string[]) buf[19])[0] = rslt.getLongVarchar(12);
              ((bool[]) buf[20])[0] = rslt.wasNull(12);
              ((int[]) buf[21])[0] = rslt.getInt(13);
              ((bool[]) buf[22])[0] = rslt.wasNull(13);
              ((string[]) buf[23])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(4));
              ((bool[]) buf[24])[0] = rslt.wasNull(14);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((bool[]) buf[7])[0] = rslt.getBool(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((bool[]) buf[11])[0] = rslt.getBool(8);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[14])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[16])[0] = rslt.wasNull(10);
              ((string[]) buf[17])[0] = rslt.getString(11, 3);
              ((bool[]) buf[18])[0] = rslt.wasNull(11);
              ((string[]) buf[19])[0] = rslt.getLongVarchar(12);
              ((bool[]) buf[20])[0] = rslt.wasNull(12);
              ((int[]) buf[21])[0] = rslt.getInt(13);
              ((bool[]) buf[22])[0] = rslt.wasNull(13);
              ((string[]) buf[23])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(4));
              ((bool[]) buf[24])[0] = rslt.wasNull(14);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getMultimediaUri(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((string[]) buf[8])[0] = rslt.getString(6, 3);
              ((long[]) buf[9])[0] = rslt.getLong(7);
              ((string[]) buf[10])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(5));
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 20);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 3);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              ((bool[]) buf[9])[0] = rslt.wasNull(6);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 20);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 3);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              ((bool[]) buf[9])[0] = rslt.wasNull(6);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              ((string[]) buf[4])[0] = rslt.getString(5, 30);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 80);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getString(9, 3);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 28 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 34 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 35 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              return;
           case 36 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              return;
     }
  }

}

}
