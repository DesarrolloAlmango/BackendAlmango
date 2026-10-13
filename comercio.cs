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
   public class comercio : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A673BancoId = (long)(Math.Round(NumberUtil.Val( GetPar( "BancoId"), "."), 18, MidpointRounding.ToEven));
            n673BancoId = false;
            AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A673BancoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedoresTipoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A151ProveedoresTipoId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_solicitudes") == 0 )
         {
            gxnrGridlevel_solicitudes_newrow_invoke( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            GxWebError = 1;
            context.HttpContext.Response.StatusDescription = 403.ToString();
            context.HttpContext.Response.StatusCode = 403;
            context.WriteHtmlText( "<title>403 Forbidden</title>") ;
            context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
            context.WriteHtmlText( "<p /><hr />") ;
            GXUtil.WriteLog("send_http_error_code " + 403.ToString());
         }
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "comercio.aspx")), "comercio.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "comercio.aspx")))) ;
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
                  AV15ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15ProveedorID", StringUtil.LTrimStr( (decimal)(AV15ProveedorID), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Datos Generales del Comercio", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProveedorRazonSocial_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_solicitudes_newrow_invoke( )
      {
         nRC_GXsfl_99 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_99"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_99_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_99_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_99_idx = GetPar( "sGXsfl_99_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_solicitudes_newrow( ) ;
         /* End function gxnrGridlevel_solicitudes_newrow_invoke */
      }

      public comercio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comercio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_ProveedorID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV15ProveedorID = aP1_ProveedorID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
         if ( cmbProveedorEstado.ItemCount > 0 )
         {
            A344ProveedorEstado = cmbProveedorEstado.getValidValue(A344ProveedorEstado);
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
            AssignProp("", false, cmbProveedorEstado_Internalname, "Values", cmbProveedorEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTabgeneral_title_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), "", "", lblTabgeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Comercio.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divB1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorID_Internalname, context.GetMessage( "Código del Proveedor", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProveedorID_Enabled!=0) ? context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Comercio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre), StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Comercio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorRazonSocial_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorRazonSocial_Internalname, context.GetMessage( "Razón Social", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorRazonSocial_Internalname, StringUtil.RTrim( A682ProveedorRazonSocial), StringUtil.RTrim( context.localUtil.Format( A682ProveedorRazonSocial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorRazonSocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorRazonSocial_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Comercio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorTelefono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorTelefono_Internalname, context.GetMessage( "Teléfono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A430ProveedorTelefono);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorTelefono_Internalname, StringUtil.RTrim( A430ProveedorTelefono), StringUtil.RTrim( context.localUtil.Format( A430ProveedorTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtProveedorTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Comercio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorDireccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorDireccion_Internalname, context.GetMessage( "Dirección", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProveedorDireccion_Internalname, A431ProveedorDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A431ProveedorDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", 0, 1, edtProveedorDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Comercio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorEmail_Internalname, A433ProveedorEmail, StringUtil.RTrim( context.localUtil.Format( A433ProveedorEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A433ProveedorEmail, "", "", "", edtProveedorEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Comercio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorContacto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorContacto_Internalname, context.GetMessage( "Nombre del Contacto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorContacto_Internalname, StringUtil.RTrim( A683ProveedorContacto), StringUtil.RTrim( context.localUtil.Format( A683ProveedorContacto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorContacto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorContacto_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Comercio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorContactoCell_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorContactoCell_Internalname, context.GetMessage( "Número del Contacto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A684ProveedorContactoCell);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorContactoCell_Internalname, StringUtil.RTrim( A684ProveedorContactoCell), StringUtil.RTrim( context.localUtil.Format( A684ProveedorContactoCell, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtProveedorContactoCell_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorContactoCell_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Comercio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divB2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProveedorEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbProveedorEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbProveedorEstado, cmbProveedorEstado_Internalname, StringUtil.RTrim( A344ProveedorEstado), 1, cmbProveedorEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbProveedorEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "", true, 0, "HLP_Comercio.htm");
         cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
         AssignProp("", false, cmbProveedorEstado_Internalname, "Values", (string)(cmbProveedorEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProveedorImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A432ProveedorImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.PathToRelativeUrl( A432ProveedorImagen));
         GxWebStd.gx_bitmap( context, imgProveedorImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProveedorImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "", "", "", 0, A432ProveedorImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_Comercio.htm");
         AssignProp("", false, imgProveedorImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.PathToRelativeUrl( A432ProveedorImagen)), true);
         AssignProp("", false, imgProveedorImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A432ProveedorImagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorCuentaBancaria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorCuentaBancaria_Internalname, context.GetMessage( "Cuenta Bancaria", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorCuentaBancaria_Internalname, StringUtil.RTrim( A687ProveedorCuentaBancaria), StringUtil.RTrim( context.localUtil.Format( A687ProveedorCuentaBancaria, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorCuentaBancaria_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorCuentaBancaria_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "CuentaBancari", "start", true, "", "HLP_Comercio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedbancoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockbancoid_Internalname, context.GetMessage( "Entidad Financiera", ""), "", "", lblTextblockbancoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Comercio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_bancoid.SetProperty("Caption", Combo_bancoid_Caption);
         ucCombo_bancoid.SetProperty("Cls", Combo_bancoid_Cls);
         ucCombo_bancoid.SetProperty("EmptyItem", Combo_bancoid_Emptyitem);
         ucCombo_bancoid.SetProperty("DropDownOptionsData", AV19BancoId_Data);
         ucCombo_bancoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_bancoid_Internalname, "COMBO_BANCOIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBancoId_Internalname, context.GetMessage( "Nro", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBancoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A673BancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A673BancoId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBancoId_Jsonclick, 0, "Attribute", "", "", "", "", edtBancoId_Visible, edtBancoId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Comercio.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_673_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_673_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_673_Internalname, sImgUrl, imgprompt_673_Link, "", "", context.GetTheme( ), imgprompt_673_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Comercio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTablevel_solicitudes_title_Internalname, "-", "", "", lblTablevel_solicitudes_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Comercio.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "TabLevel_Solicitudes") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabtablelevel_solicitudes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_solicitudes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_solicitudes( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Comercio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Comercio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Comercio.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_bancoid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombobancoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21ComboBancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCombobancoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV21ComboBancoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV21ComboBancoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombobancoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombobancoid_Visible, edtavCombobancoid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comercio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedoresTipoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A151ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProveedoresTipoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A151ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A151ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedoresTipoId_Jsonclick, 0, "Attribute", "", "", "", "", edtProveedoresTipoId_Visible, edtProveedoresTipoId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Comercio.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedoresTipoNombre_Internalname, StringUtil.RTrim( A278ProveedoresTipoNombre), StringUtil.RTrim( context.localUtil.Format( A278ProveedoresTipoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedoresTipoNombre_Jsonclick, 0, "Attribute", "", "", "", "", edtProveedoresTipoNombre_Visible, edtProveedoresTipoNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Comercio.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorDocIdentidad_Internalname, StringUtil.RTrim( A338ProveedorDocIdentidad), StringUtil.RTrim( context.localUtil.Format( A338ProveedorDocIdentidad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorDocIdentidad_Jsonclick, 0, "Attribute", "", "", "", "", edtProveedorDocIdentidad_Visible, edtProveedorDocIdentidad_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Comercio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_solicitudes( )
      {
         /*  Grid Control  */
         StartGridControl99( ) ;
         nGXsfl_99_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount52 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_52 = 1;
               ScanStart1B52( ) ;
               while ( RcdFound52 != 0 )
               {
                  init_level_properties52( ) ;
                  getByPrimaryKey1B52( ) ;
                  AddRow1B52( ) ;
                  ScanNext1B52( ) ;
               }
               ScanEnd1B52( ) ;
               nBlankRcdCount52 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1B52( ) ;
            standaloneModal1B52( ) ;
            sMode52 = Gx_mode;
            while ( nGXsfl_99_idx < nRC_GXsfl_99 )
            {
               bGXsfl_99_Refreshing = true;
               ReadRow1B52( ) ;
               edtProveedorSolicitudesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORSOLICITUDESID_"+sGXsfl_99_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorSolicitudesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0), !bGXsfl_99_Refreshing);
               edtProveedorSolicitudesNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORSOLICITUDESNOMBRE_"+sGXsfl_99_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesNombre_Enabled), 5, 0), !bGXsfl_99_Refreshing);
               edtProveedorSolicitudesFecha_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORSOLICITUDESFECHA_"+sGXsfl_99_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorSolicitudesFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesFecha_Enabled), 5, 0), !bGXsfl_99_Refreshing);
               if ( ( nRcdExists_52 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1B52( ) ;
               }
               SendRow1B52( ) ;
               bGXsfl_99_Refreshing = false;
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
               ScanStart1B52( ) ;
               while ( RcdFound52 != 0 )
               {
                  sGXsfl_99_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_99_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_9952( ) ;
                  init_level_properties52( ) ;
                  standaloneNotModal1B52( ) ;
                  getByPrimaryKey1B52( ) ;
                  standaloneModal1B52( ) ;
                  AddRow1B52( ) ;
                  ScanNext1B52( ) ;
               }
               ScanEnd1B52( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode52 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_99_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_99_idx+1), 4, 0), 4, "0");
            SubsflControlProps_9952( ) ;
            InitAll1B52( ) ;
            init_level_properties52( ) ;
            nRcdExists_52 = 0;
            nIsMod_52 = 0;
            nRcdDeleted_52 = 0;
            nBlankRcdCount52 = (short)(nBlankRcdUsr52+nBlankRcdCount52);
            fRowAdded = 0;
            while ( nBlankRcdCount52 > 0 )
            {
               standaloneNotModal1B52( ) ;
               standaloneModal1B52( ) ;
               AddRow1B52( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
               }
               nBlankRcdCount52 = (short)(nBlankRcdCount52-1);
            }
            Gx_mode = sMode52;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_solicitudesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_solicitudes", Gridlevel_solicitudesContainer, subGridlevel_solicitudes_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_solicitudesContainerData", Gridlevel_solicitudesContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_solicitudesContainerData"+"V", Gridlevel_solicitudesContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_solicitudesContainerData"+"V"+"\" value='"+Gridlevel_solicitudesContainer.GridValuesHidden()+"'/>") ;
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
         E111B2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vBANCOID_DATA"), AV19BancoId_Data);
               /* Read saved values. */
               Z133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z282ProveedorNombre = cgiGet( "Z282ProveedorNombre");
               Z338ProveedorDocIdentidad = cgiGet( "Z338ProveedorDocIdentidad");
               Z430ProveedorTelefono = cgiGet( "Z430ProveedorTelefono");
               n430ProveedorTelefono = (String.IsNullOrEmpty(StringUtil.RTrim( A430ProveedorTelefono)) ? true : false);
               Z431ProveedorDireccion = cgiGet( "Z431ProveedorDireccion");
               n431ProveedorDireccion = (String.IsNullOrEmpty(StringUtil.RTrim( A431ProveedorDireccion)) ? true : false);
               Z433ProveedorEmail = cgiGet( "Z433ProveedorEmail");
               n433ProveedorEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A433ProveedorEmail)) ? true : false);
               Z344ProveedorEstado = cgiGet( "Z344ProveedorEstado");
               Z682ProveedorRazonSocial = cgiGet( "Z682ProveedorRazonSocial");
               n682ProveedorRazonSocial = (String.IsNullOrEmpty(StringUtil.RTrim( A682ProveedorRazonSocial)) ? true : false);
               Z683ProveedorContacto = cgiGet( "Z683ProveedorContacto");
               n683ProveedorContacto = (String.IsNullOrEmpty(StringUtil.RTrim( A683ProveedorContacto)) ? true : false);
               Z684ProveedorContactoCell = cgiGet( "Z684ProveedorContactoCell");
               n684ProveedorContactoCell = (String.IsNullOrEmpty(StringUtil.RTrim( A684ProveedorContactoCell)) ? true : false);
               Z687ProveedorCuentaBancaria = cgiGet( "Z687ProveedorCuentaBancaria");
               n687ProveedorCuentaBancaria = (String.IsNullOrEmpty(StringUtil.RTrim( A687ProveedorCuentaBancaria)) ? true : false);
               Z978ProveedorCIU = StringUtil.StrToBool( cgiGet( "Z978ProveedorCIU"));
               Z151ProveedoresTipoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z151ProveedoresTipoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z673BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z673BancoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n673BancoId = ((0==A673BancoId) ? true : false);
               A978ProveedorCIU = StringUtil.StrToBool( cgiGet( "Z978ProveedorCIU"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_99 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_99"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N673BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N673BancoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n673BancoId = ((0==A673BancoId) ? true : false);
               AV15ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vPROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV10Insert_ProveedoresTipoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROVEEDORESTIPOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10Insert_ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(AV10Insert_ProveedoresTipoId), 18, 0));
               AV18Insert_BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_BANCOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18Insert_BancoId", StringUtil.LTrimStr( (decimal)(AV18Insert_BancoId), 18, 0));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A978ProveedorCIU = StringUtil.StrToBool( cgiGet( "PROVEEDORCIU"));
               A40000ProveedorImagen_GXI = cgiGet( "PROVEEDORIMAGEN_GXI");
               n40000ProveedorImagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
               A674BancoNombre = cgiGet( "BANCONOMBRE");
               AV22Pgmname = cgiGet( "vPGMNAME");
               Combo_bancoid_Objectcall = cgiGet( "COMBO_BANCOID_Objectcall");
               Combo_bancoid_Class = cgiGet( "COMBO_BANCOID_Class");
               Combo_bancoid_Icontype = cgiGet( "COMBO_BANCOID_Icontype");
               Combo_bancoid_Icon = cgiGet( "COMBO_BANCOID_Icon");
               Combo_bancoid_Caption = cgiGet( "COMBO_BANCOID_Caption");
               Combo_bancoid_Tooltip = cgiGet( "COMBO_BANCOID_Tooltip");
               Combo_bancoid_Cls = cgiGet( "COMBO_BANCOID_Cls");
               Combo_bancoid_Selectedvalue_set = cgiGet( "COMBO_BANCOID_Selectedvalue_set");
               Combo_bancoid_Selectedvalue_get = cgiGet( "COMBO_BANCOID_Selectedvalue_get");
               Combo_bancoid_Selectedtext_set = cgiGet( "COMBO_BANCOID_Selectedtext_set");
               Combo_bancoid_Selectedtext_get = cgiGet( "COMBO_BANCOID_Selectedtext_get");
               Combo_bancoid_Gamoauthtoken = cgiGet( "COMBO_BANCOID_Gamoauthtoken");
               Combo_bancoid_Ddointernalname = cgiGet( "COMBO_BANCOID_Ddointernalname");
               Combo_bancoid_Titlecontrolalign = cgiGet( "COMBO_BANCOID_Titlecontrolalign");
               Combo_bancoid_Dropdownoptionstype = cgiGet( "COMBO_BANCOID_Dropdownoptionstype");
               Combo_bancoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_BANCOID_Enabled"));
               Combo_bancoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_BANCOID_Visible"));
               Combo_bancoid_Titlecontrolidtoreplace = cgiGet( "COMBO_BANCOID_Titlecontrolidtoreplace");
               Combo_bancoid_Datalisttype = cgiGet( "COMBO_BANCOID_Datalisttype");
               Combo_bancoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_BANCOID_Allowmultipleselection"));
               Combo_bancoid_Datalistfixedvalues = cgiGet( "COMBO_BANCOID_Datalistfixedvalues");
               Combo_bancoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_BANCOID_Isgriditem"));
               Combo_bancoid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_BANCOID_Hasdescription"));
               Combo_bancoid_Datalistproc = cgiGet( "COMBO_BANCOID_Datalistproc");
               Combo_bancoid_Datalistprocparametersprefix = cgiGet( "COMBO_BANCOID_Datalistprocparametersprefix");
               Combo_bancoid_Remoteservicesparameters = cgiGet( "COMBO_BANCOID_Remoteservicesparameters");
               Combo_bancoid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_BANCOID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_bancoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_BANCOID_Includeonlyselectedoption"));
               Combo_bancoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_BANCOID_Includeselectalloption"));
               Combo_bancoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_BANCOID_Emptyitem"));
               Combo_bancoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_BANCOID_Includeaddnewoption"));
               Combo_bancoid_Htmltemplate = cgiGet( "COMBO_BANCOID_Htmltemplate");
               Combo_bancoid_Multiplevaluestype = cgiGet( "COMBO_BANCOID_Multiplevaluestype");
               Combo_bancoid_Loadingdata = cgiGet( "COMBO_BANCOID_Loadingdata");
               Combo_bancoid_Noresultsfound = cgiGet( "COMBO_BANCOID_Noresultsfound");
               Combo_bancoid_Emptyitemtext = cgiGet( "COMBO_BANCOID_Emptyitemtext");
               Combo_bancoid_Onlyselectedvalues = cgiGet( "COMBO_BANCOID_Onlyselectedvalues");
               Combo_bancoid_Selectalltext = cgiGet( "COMBO_BANCOID_Selectalltext");
               Combo_bancoid_Multiplevaluesseparator = cgiGet( "COMBO_BANCOID_Multiplevaluesseparator");
               Combo_bancoid_Addnewoptiontext = cgiGet( "COMBO_BANCOID_Addnewoptiontext");
               Combo_bancoid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_BANCOID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs_Objectcall = cgiGet( "GXUITABSPANEL_TABS_Objectcall");
               Gxuitabspanel_tabs_Enabled = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Enabled"));
               Gxuitabspanel_tabs_Activepage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Activepage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs_Activepagecontrolname = cgiGet( "GXUITABSPANEL_TABS_Activepagecontrolname");
               Gxuitabspanel_tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs_Class = cgiGet( "GXUITABSPANEL_TABS_Class");
               Gxuitabspanel_tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Historymanagement"));
               Gxuitabspanel_tabs_Visible = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Visible"));
               /* Read variables values. */
               A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n133ProveedorID = false;
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
               AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
               A682ProveedorRazonSocial = cgiGet( edtProveedorRazonSocial_Internalname);
               n682ProveedorRazonSocial = false;
               AssignAttri("", false, "A682ProveedorRazonSocial", A682ProveedorRazonSocial);
               n682ProveedorRazonSocial = (String.IsNullOrEmpty(StringUtil.RTrim( A682ProveedorRazonSocial)) ? true : false);
               A430ProveedorTelefono = cgiGet( edtProveedorTelefono_Internalname);
               n430ProveedorTelefono = false;
               AssignAttri("", false, "A430ProveedorTelefono", A430ProveedorTelefono);
               n430ProveedorTelefono = (String.IsNullOrEmpty(StringUtil.RTrim( A430ProveedorTelefono)) ? true : false);
               A431ProveedorDireccion = cgiGet( edtProveedorDireccion_Internalname);
               n431ProveedorDireccion = false;
               AssignAttri("", false, "A431ProveedorDireccion", A431ProveedorDireccion);
               n431ProveedorDireccion = (String.IsNullOrEmpty(StringUtil.RTrim( A431ProveedorDireccion)) ? true : false);
               A433ProveedorEmail = cgiGet( edtProveedorEmail_Internalname);
               n433ProveedorEmail = false;
               AssignAttri("", false, "A433ProveedorEmail", A433ProveedorEmail);
               n433ProveedorEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A433ProveedorEmail)) ? true : false);
               A683ProveedorContacto = cgiGet( edtProveedorContacto_Internalname);
               n683ProveedorContacto = false;
               AssignAttri("", false, "A683ProveedorContacto", A683ProveedorContacto);
               n683ProveedorContacto = (String.IsNullOrEmpty(StringUtil.RTrim( A683ProveedorContacto)) ? true : false);
               A684ProveedorContactoCell = cgiGet( edtProveedorContactoCell_Internalname);
               n684ProveedorContactoCell = false;
               AssignAttri("", false, "A684ProveedorContactoCell", A684ProveedorContactoCell);
               n684ProveedorContactoCell = (String.IsNullOrEmpty(StringUtil.RTrim( A684ProveedorContactoCell)) ? true : false);
               cmbProveedorEstado.Name = cmbProveedorEstado_Internalname;
               cmbProveedorEstado.CurrentValue = cgiGet( cmbProveedorEstado_Internalname);
               A344ProveedorEstado = cgiGet( cmbProveedorEstado_Internalname);
               AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
               A432ProveedorImagen = cgiGet( imgProveedorImagen_Internalname);
               n432ProveedorImagen = false;
               AssignAttri("", false, "A432ProveedorImagen", A432ProveedorImagen);
               n432ProveedorImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
               A687ProveedorCuentaBancaria = cgiGet( edtProveedorCuentaBancaria_Internalname);
               n687ProveedorCuentaBancaria = false;
               AssignAttri("", false, "A687ProveedorCuentaBancaria", A687ProveedorCuentaBancaria);
               n687ProveedorCuentaBancaria = (String.IsNullOrEmpty(StringUtil.RTrim( A687ProveedorCuentaBancaria)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtBancoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBancoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BANCOID");
                  AnyError = 1;
                  GX_FocusControl = edtBancoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A673BancoId = 0;
                  n673BancoId = false;
                  AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
               }
               else
               {
                  A673BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtBancoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n673BancoId = false;
                  AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
               }
               n673BancoId = ((0==A673BancoId) ? true : false);
               AV21ComboBancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombobancoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV21ComboBancoId", StringUtil.LTrimStr( (decimal)(AV21ComboBancoId), 18, 0));
               A151ProveedoresTipoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedoresTipoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
               A278ProveedoresTipoNombre = cgiGet( edtProveedoresTipoNombre_Internalname);
               AssignAttri("", false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
               A338ProveedorDocIdentidad = cgiGet( edtProveedorDocIdentidad_Internalname);
               AssignAttri("", false, "A338ProveedorDocIdentidad", A338ProveedorDocIdentidad);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProveedorImagen_Internalname, ref  A432ProveedorImagen, ref  A40000ProveedorImagen_GXI);
               n40000ProveedorImagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
               n432ProveedorImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Comercio");
               A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n133ProveedorID = false;
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               forbiddenHiddens.Add("ProveedorID", context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
               A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
               AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
               forbiddenHiddens.Add("ProveedorNombre", StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")));
               A344ProveedorEstado = cgiGet( cmbProveedorEstado_Internalname);
               AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
               forbiddenHiddens.Add("ProveedorEstado", StringUtil.RTrim( context.localUtil.Format( A344ProveedorEstado, "")));
               A151ProveedoresTipoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedoresTipoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
               forbiddenHiddens.Add("ProveedoresTipoId", context.localUtil.Format( (decimal)(A151ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9"));
               A338ProveedorDocIdentidad = cgiGet( edtProveedorDocIdentidad_Internalname);
               AssignAttri("", false, "A338ProveedorDocIdentidad", A338ProveedorDocIdentidad);
               forbiddenHiddens.Add("ProveedorDocIdentidad", StringUtil.RTrim( context.localUtil.Format( A338ProveedorDocIdentidad, "")));
               forbiddenHiddens.Add("Insert_ProveedoresTipoId", context.localUtil.Format( (decimal)(AV10Insert_ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_BancoId", context.localUtil.Format( (decimal)(AV18Insert_BancoId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ProveedorCIU", StringUtil.BoolToStr( A978ProveedorCIU));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A133ProveedorID != Z133ProveedorID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("comercio:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode28 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode28;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound28 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1B0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PROVEEDORID");
                        AnyError = 1;
                        GX_FocusControl = edtProveedorID_Internalname;
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
                           E111B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121B2 ();
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
            E121B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1B28( ) ;
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
            DisableAttributes1B28( ) ;
         }
         AssignProp("", false, edtavCombobancoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombobancoid_Enabled), 5, 0), true);
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

      protected void CONFIRM_1B0( )
      {
         BeforeValidate1B28( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1B28( ) ;
            }
            else
            {
               CheckExtendedTable1B28( ) ;
               CloseExtendedTableCursors1B28( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode28 = Gx_mode;
            CONFIRM_1B52( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode28;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_1B52( )
      {
         nGXsfl_99_idx = 0;
         while ( nGXsfl_99_idx < nRC_GXsfl_99 )
         {
            ReadRow1B52( ) ;
            if ( ( nRcdExists_52 != 0 ) || ( nIsMod_52 != 0 ) )
            {
               GetKey1B52( ) ;
               if ( ( nRcdExists_52 == 0 ) && ( nRcdDeleted_52 == 0 ) )
               {
                  if ( RcdFound52 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1B52( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1B52( ) ;
                        CloseExtendedTableCursors1B52( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
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
                        getByPrimaryKey1B52( ) ;
                        Load1B52( ) ;
                        BeforeValidate1B52( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1B52( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_52 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1B52( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1B52( ) ;
                              CloseExtendedTableCursors1B52( ) ;
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
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtProveedorSolicitudesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A152ProveedorSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProveedorSolicitudesNombre_Internalname, StringUtil.RTrim( A337ProveedorSolicitudesNombre)) ;
            ChangePostValue( edtProveedorSolicitudesFecha_Internalname, context.localUtil.Format(A280ProveedorSolicitudesFecha, "99/99/99")) ;
            ChangePostValue( "ZT_"+"Z152ProveedorSolicitudesId_"+sGXsfl_99_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z152ProveedorSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z337ProveedorSolicitudesNombre_"+sGXsfl_99_idx, StringUtil.RTrim( Z337ProveedorSolicitudesNombre)) ;
            ChangePostValue( "ZT_"+"Z280ProveedorSolicitudesFecha_"+sGXsfl_99_idx, context.localUtil.DToC( Z280ProveedorSolicitudesFecha, 0, "/")) ;
            ChangePostValue( "nRcdDeleted_52_"+sGXsfl_99_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_52_"+sGXsfl_99_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_52_"+sGXsfl_99_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_52 != 0 )
            {
               ChangePostValue( "PROVEEDORSOLICITUDESID_"+sGXsfl_99_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORSOLICITUDESNOMBRE_"+sGXsfl_99_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORSOLICITUDESFECHA_"+sGXsfl_99_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesFecha_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1B0( )
      {
      }

      protected void E111B2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV16WWPContext) ;
         edtBancoId_Visible = 0;
         AssignProp("", false, edtBancoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtBancoId_Visible), 5, 0), true);
         AV21ComboBancoId = 0;
         AssignAttri("", false, "AV21ComboBancoId", StringUtil.LTrimStr( (decimal)(AV21ComboBancoId), 18, 0));
         edtavCombobancoid_Visible = 0;
         AssignProp("", false, edtavCombobancoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombobancoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOBANCOID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV7IsAuthorized = true;
         AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComercio_Insert", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComercio_Update", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComercio_Delete", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         }
         if ( ! AV7IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV22Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV8TrnContext.FromXml(AV9WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Transactionname, AV22Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV23GXV1 = 1;
            AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            while ( AV23GXV1 <= AV8TrnContext.gxTpr_Attributes.Count )
            {
               AV11TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV8TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV11TrnContextAtt.gxTpr_Attributename, "ProveedoresTipoId") == 0 )
               {
                  AV10Insert_ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( AV11TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV10Insert_ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(AV10Insert_ProveedoresTipoId), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV11TrnContextAtt.gxTpr_Attributename, "BancoId") == 0 )
               {
                  AV18Insert_BancoId = (long)(Math.Round(NumberUtil.Val( AV11TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV18Insert_BancoId", StringUtil.LTrimStr( (decimal)(AV18Insert_BancoId), 18, 0));
                  if ( ! (0==AV18Insert_BancoId) )
                  {
                     AV21ComboBancoId = AV18Insert_BancoId;
                     AssignAttri("", false, "AV21ComboBancoId", StringUtil.LTrimStr( (decimal)(AV21ComboBancoId), 18, 0));
                     Combo_bancoid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV21ComboBancoId), 18, 0));
                     ucCombo_bancoid.SendProperty(context, "", false, Combo_bancoid_Internalname, "SelectedValue_set", Combo_bancoid_Selectedvalue_set);
                     Combo_bancoid_Enabled = false;
                     ucCombo_bancoid.SendProperty(context, "", false, Combo_bancoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_bancoid_Enabled));
                  }
               }
               AV23GXV1 = (int)(AV23GXV1+1);
               AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            }
         }
         edtProveedoresTipoId_Visible = 0;
         AssignProp("", false, edtProveedoresTipoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoId_Visible), 5, 0), true);
         edtProveedoresTipoNombre_Visible = 0;
         AssignProp("", false, edtProveedoresTipoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoNombre_Visible), 5, 0), true);
         edtProveedorDocIdentidad_Visible = 0;
         AssignProp("", false, edtProveedorDocIdentidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorDocIdentidad_Visible), 5, 0), true);
      }

      protected void E121B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV8TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("comercioww.aspx") );
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
         /* 'LOADCOMBOBANCOID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item2 = AV19BancoId_Data;
         new comercioloaddvcombo(context ).execute(  "BancoId",  Gx_mode,  AV15ProveedorID, out  AV20ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item2) ;
         AV19BancoId_Data = GXt_objcol_SdtDVB_SDTComboData_Item2;
         Combo_bancoid_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_bancoid.SendProperty(context, "", false, Combo_bancoid_Internalname, "SelectedValue_set", Combo_bancoid_Selectedvalue_set);
         AV21ComboBancoId = (long)(Math.Round(NumberUtil.Val( AV20ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV21ComboBancoId", StringUtil.LTrimStr( (decimal)(AV21ComboBancoId), 18, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_bancoid_Enabled = false;
            ucCombo_bancoid.SendProperty(context, "", false, Combo_bancoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_bancoid_Enabled));
         }
      }

      protected void ZM1B28( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z282ProveedorNombre = T001B5_A282ProveedorNombre[0];
               Z338ProveedorDocIdentidad = T001B5_A338ProveedorDocIdentidad[0];
               Z430ProveedorTelefono = T001B5_A430ProveedorTelefono[0];
               Z431ProveedorDireccion = T001B5_A431ProveedorDireccion[0];
               Z433ProveedorEmail = T001B5_A433ProveedorEmail[0];
               Z344ProveedorEstado = T001B5_A344ProveedorEstado[0];
               Z682ProveedorRazonSocial = T001B5_A682ProveedorRazonSocial[0];
               Z683ProveedorContacto = T001B5_A683ProveedorContacto[0];
               Z684ProveedorContactoCell = T001B5_A684ProveedorContactoCell[0];
               Z687ProveedorCuentaBancaria = T001B5_A687ProveedorCuentaBancaria[0];
               Z978ProveedorCIU = T001B5_A978ProveedorCIU[0];
               Z151ProveedoresTipoId = T001B5_A151ProveedoresTipoId[0];
               Z673BancoId = T001B5_A673BancoId[0];
            }
            else
            {
               Z282ProveedorNombre = A282ProveedorNombre;
               Z338ProveedorDocIdentidad = A338ProveedorDocIdentidad;
               Z430ProveedorTelefono = A430ProveedorTelefono;
               Z431ProveedorDireccion = A431ProveedorDireccion;
               Z433ProveedorEmail = A433ProveedorEmail;
               Z344ProveedorEstado = A344ProveedorEstado;
               Z682ProveedorRazonSocial = A682ProveedorRazonSocial;
               Z683ProveedorContacto = A683ProveedorContacto;
               Z684ProveedorContactoCell = A684ProveedorContactoCell;
               Z687ProveedorCuentaBancaria = A687ProveedorCuentaBancaria;
               Z978ProveedorCIU = A978ProveedorCIU;
               Z151ProveedoresTipoId = A151ProveedoresTipoId;
               Z673BancoId = A673BancoId;
            }
         }
         if ( GX_JID == -18 )
         {
            Z133ProveedorID = A133ProveedorID;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z338ProveedorDocIdentidad = A338ProveedorDocIdentidad;
            Z430ProveedorTelefono = A430ProveedorTelefono;
            Z431ProveedorDireccion = A431ProveedorDireccion;
            Z433ProveedorEmail = A433ProveedorEmail;
            Z344ProveedorEstado = A344ProveedorEstado;
            Z682ProveedorRazonSocial = A682ProveedorRazonSocial;
            Z683ProveedorContacto = A683ProveedorContacto;
            Z684ProveedorContactoCell = A684ProveedorContactoCell;
            Z432ProveedorImagen = A432ProveedorImagen;
            Z40000ProveedorImagen_GXI = A40000ProveedorImagen_GXI;
            Z687ProveedorCuentaBancaria = A687ProveedorCuentaBancaria;
            Z978ProveedorCIU = A978ProveedorCIU;
            Z151ProveedoresTipoId = A151ProveedoresTipoId;
            Z673BancoId = A673BancoId;
            Z278ProveedoresTipoNombre = A278ProveedoresTipoNombre;
            Z674BancoNombre = A674BancoNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         cmbProveedorEstado.Enabled = 0;
         AssignProp("", false, cmbProveedorEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorEstado.Enabled), 5, 0), true);
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         edtProveedoresTipoId_Enabled = 0;
         AssignProp("", false, edtProveedoresTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoId_Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         edtProveedorDocIdentidad_Enabled = 0;
         AssignProp("", false, edtProveedorDocIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorDocIdentidad_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_673_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx02n0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"BANCOID"+"'), id:'"+"BANCOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         cmbProveedorEstado.Enabled = 0;
         AssignProp("", false, cmbProveedorEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorEstado.Enabled), 5, 0), true);
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         edtProveedoresTipoId_Enabled = 0;
         AssignProp("", false, edtProveedoresTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoId_Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         edtProveedorDocIdentidad_Enabled = 0;
         AssignProp("", false, edtProveedorDocIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorDocIdentidad_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV15ProveedorID) )
         {
            A133ProveedorID = AV15ProveedorID;
            n133ProveedorID = false;
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV18Insert_BancoId) )
         {
            edtBancoId_Enabled = 0;
            AssignProp("", false, edtBancoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBancoId_Enabled), 5, 0), true);
         }
         else
         {
            edtBancoId_Enabled = 1;
            AssignProp("", false, edtBancoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBancoId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV10Insert_ProveedoresTipoId) )
         {
            A151ProveedoresTipoId = AV10Insert_ProveedoresTipoId;
            AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV18Insert_BancoId) )
         {
            A673BancoId = AV18Insert_BancoId;
            n673BancoId = false;
            AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
         }
         else
         {
            if ( (0==AV21ComboBancoId) )
            {
               A673BancoId = 0;
               n673BancoId = false;
               AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
               n673BancoId = true;
               AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
            }
            else
            {
               if ( ! (0==AV21ComboBancoId) )
               {
                  A673BancoId = AV21ComboBancoId;
                  n673BancoId = false;
                  AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
               }
            }
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
         if ( IsIns( )  && (false==A978ProveedorCIU) && ( Gx_BScreen == 0 ) )
         {
            A978ProveedorCIU = false;
            AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV22Pgmname = "Comercio";
            AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
            /* Using cursor T001B6 */
            pr_default.execute(4, new Object[] {A151ProveedoresTipoId});
            A278ProveedoresTipoNombre = T001B6_A278ProveedoresTipoNombre[0];
            AssignAttri("", false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
            pr_default.close(4);
            /* Using cursor T001B7 */
            pr_default.execute(5, new Object[] {n673BancoId, A673BancoId});
            A674BancoNombre = T001B7_A674BancoNombre[0];
            pr_default.close(5);
         }
      }

      protected void Load1B28( )
      {
         /* Using cursor T001B8 */
         pr_default.execute(6, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound28 = 1;
            A278ProveedoresTipoNombre = T001B8_A278ProveedoresTipoNombre[0];
            AssignAttri("", false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
            A282ProveedorNombre = T001B8_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A338ProveedorDocIdentidad = T001B8_A338ProveedorDocIdentidad[0];
            AssignAttri("", false, "A338ProveedorDocIdentidad", A338ProveedorDocIdentidad);
            A430ProveedorTelefono = T001B8_A430ProveedorTelefono[0];
            n430ProveedorTelefono = T001B8_n430ProveedorTelefono[0];
            AssignAttri("", false, "A430ProveedorTelefono", A430ProveedorTelefono);
            A431ProveedorDireccion = T001B8_A431ProveedorDireccion[0];
            n431ProveedorDireccion = T001B8_n431ProveedorDireccion[0];
            AssignAttri("", false, "A431ProveedorDireccion", A431ProveedorDireccion);
            A433ProveedorEmail = T001B8_A433ProveedorEmail[0];
            n433ProveedorEmail = T001B8_n433ProveedorEmail[0];
            AssignAttri("", false, "A433ProveedorEmail", A433ProveedorEmail);
            A344ProveedorEstado = T001B8_A344ProveedorEstado[0];
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
            A682ProveedorRazonSocial = T001B8_A682ProveedorRazonSocial[0];
            n682ProveedorRazonSocial = T001B8_n682ProveedorRazonSocial[0];
            AssignAttri("", false, "A682ProveedorRazonSocial", A682ProveedorRazonSocial);
            A683ProveedorContacto = T001B8_A683ProveedorContacto[0];
            n683ProveedorContacto = T001B8_n683ProveedorContacto[0];
            AssignAttri("", false, "A683ProveedorContacto", A683ProveedorContacto);
            A684ProveedorContactoCell = T001B8_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = T001B8_n684ProveedorContactoCell[0];
            AssignAttri("", false, "A684ProveedorContactoCell", A684ProveedorContactoCell);
            A40000ProveedorImagen_GXI = T001B8_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = T001B8_n40000ProveedorImagen_GXI[0];
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            A687ProveedorCuentaBancaria = T001B8_A687ProveedorCuentaBancaria[0];
            n687ProveedorCuentaBancaria = T001B8_n687ProveedorCuentaBancaria[0];
            AssignAttri("", false, "A687ProveedorCuentaBancaria", A687ProveedorCuentaBancaria);
            A674BancoNombre = T001B8_A674BancoNombre[0];
            A978ProveedorCIU = T001B8_A978ProveedorCIU[0];
            A151ProveedoresTipoId = T001B8_A151ProveedoresTipoId[0];
            AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            A673BancoId = T001B8_A673BancoId[0];
            n673BancoId = T001B8_n673BancoId[0];
            AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
            A432ProveedorImagen = T001B8_A432ProveedorImagen[0];
            n432ProveedorImagen = T001B8_n432ProveedorImagen[0];
            AssignAttri("", false, "A432ProveedorImagen", A432ProveedorImagen);
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            ZM1B28( -18) ;
         }
         pr_default.close(6);
         OnLoadActions1B28( ) ;
      }

      protected void OnLoadActions1B28( )
      {
         AV22Pgmname = "Comercio";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
      }

      protected void CheckExtendedTable1B28( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV22Pgmname = "Comercio";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         if ( ! ( GxRegex.IsMatch(A433ProveedorEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A433ProveedorEmail)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PROVEEDOREMAIL");
            AnyError = 1;
            GX_FocusControl = edtProveedorEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T001B7 */
         pr_default.execute(5, new Object[] {n673BancoId, A673BancoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A673BancoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Banco", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "BANCOID");
               AnyError = 1;
               GX_FocusControl = edtBancoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A674BancoNombre = T001B7_A674BancoNombre[0];
         pr_default.close(5);
         /* Using cursor T001B6 */
         pr_default.execute(4, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
         }
         A278ProveedoresTipoNombre = T001B6_A278ProveedoresTipoNombre[0];
         AssignAttri("", false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1B28( )
      {
         pr_default.close(5);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_20( long A673BancoId )
      {
         /* Using cursor T001B9 */
         pr_default.execute(7, new Object[] {n673BancoId, A673BancoId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A673BancoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Banco", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "BANCOID");
               AnyError = 1;
               GX_FocusControl = edtBancoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A674BancoNombre = T001B9_A674BancoNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A674BancoNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_19( long A151ProveedoresTipoId )
      {
         /* Using cursor T001B10 */
         pr_default.execute(8, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
         }
         A278ProveedoresTipoNombre = T001B10_A278ProveedoresTipoNombre[0];
         AssignAttri("", false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A278ProveedoresTipoNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey1B28( )
      {
         /* Using cursor T001B11 */
         pr_default.execute(9, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001B5 */
         pr_default.execute(3, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1B28( 18) ;
            RcdFound28 = 1;
            A133ProveedorID = T001B5_A133ProveedorID[0];
            n133ProveedorID = T001B5_n133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            A282ProveedorNombre = T001B5_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A338ProveedorDocIdentidad = T001B5_A338ProveedorDocIdentidad[0];
            AssignAttri("", false, "A338ProveedorDocIdentidad", A338ProveedorDocIdentidad);
            A430ProveedorTelefono = T001B5_A430ProveedorTelefono[0];
            n430ProveedorTelefono = T001B5_n430ProveedorTelefono[0];
            AssignAttri("", false, "A430ProveedorTelefono", A430ProveedorTelefono);
            A431ProveedorDireccion = T001B5_A431ProveedorDireccion[0];
            n431ProveedorDireccion = T001B5_n431ProveedorDireccion[0];
            AssignAttri("", false, "A431ProveedorDireccion", A431ProveedorDireccion);
            A433ProveedorEmail = T001B5_A433ProveedorEmail[0];
            n433ProveedorEmail = T001B5_n433ProveedorEmail[0];
            AssignAttri("", false, "A433ProveedorEmail", A433ProveedorEmail);
            A344ProveedorEstado = T001B5_A344ProveedorEstado[0];
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
            A682ProveedorRazonSocial = T001B5_A682ProveedorRazonSocial[0];
            n682ProveedorRazonSocial = T001B5_n682ProveedorRazonSocial[0];
            AssignAttri("", false, "A682ProveedorRazonSocial", A682ProveedorRazonSocial);
            A683ProveedorContacto = T001B5_A683ProveedorContacto[0];
            n683ProveedorContacto = T001B5_n683ProveedorContacto[0];
            AssignAttri("", false, "A683ProveedorContacto", A683ProveedorContacto);
            A684ProveedorContactoCell = T001B5_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = T001B5_n684ProveedorContactoCell[0];
            AssignAttri("", false, "A684ProveedorContactoCell", A684ProveedorContactoCell);
            A40000ProveedorImagen_GXI = T001B5_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = T001B5_n40000ProveedorImagen_GXI[0];
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            A687ProveedorCuentaBancaria = T001B5_A687ProveedorCuentaBancaria[0];
            n687ProveedorCuentaBancaria = T001B5_n687ProveedorCuentaBancaria[0];
            AssignAttri("", false, "A687ProveedorCuentaBancaria", A687ProveedorCuentaBancaria);
            A978ProveedorCIU = T001B5_A978ProveedorCIU[0];
            A151ProveedoresTipoId = T001B5_A151ProveedoresTipoId[0];
            AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            A673BancoId = T001B5_A673BancoId[0];
            n673BancoId = T001B5_n673BancoId[0];
            AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
            A432ProveedorImagen = T001B5_A432ProveedorImagen[0];
            n432ProveedorImagen = T001B5_n432ProveedorImagen[0];
            AssignAttri("", false, "A432ProveedorImagen", A432ProveedorImagen);
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            Z133ProveedorID = A133ProveedorID;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1B28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey1B28( ) ;
            }
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey1B28( ) ;
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
         GetKey1B28( ) ;
         if ( RcdFound28 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound28 = 0;
         /* Using cursor T001B12 */
         pr_default.execute(10, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T001B12_A133ProveedorID[0] < A133ProveedorID ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T001B12_A133ProveedorID[0] > A133ProveedorID ) ) )
            {
               A133ProveedorID = T001B12_A133ProveedorID[0];
               n133ProveedorID = T001B12_n133ProveedorID[0];
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound28 = 0;
         /* Using cursor T001B13 */
         pr_default.execute(11, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T001B13_A133ProveedorID[0] > A133ProveedorID ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T001B13_A133ProveedorID[0] < A133ProveedorID ) ) )
            {
               A133ProveedorID = T001B13_A133ProveedorID[0];
               n133ProveedorID = T001B13_n133ProveedorID[0];
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1B28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProveedorRazonSocial_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1B28( ) ;
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
                  GX_FocusControl = edtProveedorRazonSocial_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1B28( ) ;
                  GX_FocusControl = edtProveedorRazonSocial_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A133ProveedorID != Z133ProveedorID )
               {
                  /* Insert record */
                  GX_FocusControl = edtProveedorRazonSocial_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1B28( ) ;
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
                     /* Insert record */
                     GX_FocusControl = edtProveedorRazonSocial_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1B28( ) ;
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
            GX_FocusControl = edtProveedorRazonSocial_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1B28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001B4 */
            pr_default.execute(2, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proveedor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z282ProveedorNombre, T001B4_A282ProveedorNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z338ProveedorDocIdentidad, T001B4_A338ProveedorDocIdentidad[0]) != 0 ) || ( StringUtil.StrCmp(Z430ProveedorTelefono, T001B4_A430ProveedorTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z431ProveedorDireccion, T001B4_A431ProveedorDireccion[0]) != 0 ) || ( StringUtil.StrCmp(Z433ProveedorEmail, T001B4_A433ProveedorEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z344ProveedorEstado, T001B4_A344ProveedorEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z682ProveedorRazonSocial, T001B4_A682ProveedorRazonSocial[0]) != 0 ) || ( StringUtil.StrCmp(Z683ProveedorContacto, T001B4_A683ProveedorContacto[0]) != 0 ) || ( StringUtil.StrCmp(Z684ProveedorContactoCell, T001B4_A684ProveedorContactoCell[0]) != 0 ) || ( StringUtil.StrCmp(Z687ProveedorCuentaBancaria, T001B4_A687ProveedorCuentaBancaria[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z978ProveedorCIU != T001B4_A978ProveedorCIU[0] ) || ( Z151ProveedoresTipoId != T001B4_A151ProveedoresTipoId[0] ) || ( Z673BancoId != T001B4_A673BancoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z282ProveedorNombre, T001B4_A282ProveedorNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("comercio:[seudo value changed for attri]"+"ProveedorNombre");
                  GXUtil.WriteLogRaw("Old: ",Z282ProveedorNombre);
                  GXUtil.WriteLogRaw("Current: ",T001B4_A282ProveedorNombre[0]);
               }
               if ( StringUtil.StrCmp(Z338ProveedorDocIdentidad, T001B4_A338ProveedorDocIdentidad[0]) != 0 )
               {
                  GXUtil.WriteLog("comercio:[seudo value changed for attri]"+"ProveedorDocIdentidad");
                  GXUtil.WriteLogRaw("Old: ",Z338ProveedorDocIdentidad);
                  GXUtil.WriteLogRaw("Current: ",T001B4_A338ProveedorDocIdentidad[0]);
               }
               if ( StringUtil.StrCmp(Z430ProveedorTelefono, T001B4_A430ProveedorTelefono[0]) != 0 )
               {
                  GXUtil.WriteLog("comercio:[seudo value changed for attri]"+"ProveedorTelefono");
                  GXUtil.WriteLogRaw("Old: ",Z430ProveedorTelefono);
                  GXUtil.WriteLogRaw("Current: ",T001B4_A430ProveedorTelefono[0]);
               }
               if ( StringUtil.StrCmp(Z431ProveedorDireccion, T001B4_A431ProveedorDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("comercio:[seudo value changed for attri]"+"ProveedorDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z431ProveedorDireccion);
                  GXUtil.WriteLogRaw("Current: ",T001B4_A431ProveedorDireccion[0]);
               }
               if ( StringUtil.StrCmp(Z433ProveedorEmail, T001B4_A433ProveedorEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("comercio:[seudo value changed for attri]"+"ProveedorEmail");
                  GXUtil.WriteLogRaw("Old: ",Z433ProveedorEmail);
                  GXUtil.WriteLogRaw("Current: ",T001B4_A433ProveedorEmail[0]);
               }
               if ( StringUtil.StrCmp(Z344ProveedorEstado, T001B4_A344ProveedorEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("comercio:[seudo value changed for attri]"+"ProveedorEstado");
                  GXUtil.WriteLogRaw("Old: ",Z344ProveedorEstado);
                  GXUtil.WriteLogRaw("Current: ",T001B4_A344ProveedorEstado[0]);
               }
               if ( StringUtil.StrCmp(Z682ProveedorRazonSocial, T001B4_A682ProveedorRazonSocial[0]) != 0 )
               {
                  GXUtil.WriteLog("comercio:[seudo value changed for attri]"+"ProveedorRazonSocial");
                  GXUtil.WriteLogRaw("Old: ",Z682ProveedorRazonSocial);
                  GXUtil.WriteLogRaw("Current: ",T001B4_A682ProveedorRazonSocial[0]);
               }
               if ( StringUtil.StrCmp(Z683ProveedorContacto, T001B4_A683ProveedorContacto[0]) != 0 )
               {
                  GXUtil.WriteLog("comercio:[seudo value changed for attri]"+"ProveedorContacto");
                  GXUtil.WriteLogRaw("Old: ",Z683ProveedorContacto);
                  GXUtil.WriteLogRaw("Current: ",T001B4_A683ProveedorContacto[0]);
               }
               if ( StringUtil.StrCmp(Z684ProveedorContactoCell, T001B4_A684ProveedorContactoCell[0]) != 0 )
               {
                  GXUtil.WriteLog("comercio:[seudo value changed for attri]"+"ProveedorContactoCell");
                  GXUtil.WriteLogRaw("Old: ",Z684ProveedorContactoCell);
                  GXUtil.WriteLogRaw("Current: ",T001B4_A684ProveedorContactoCell[0]);
               }
               if ( StringUtil.StrCmp(Z687ProveedorCuentaBancaria, T001B4_A687ProveedorCuentaBancaria[0]) != 0 )
               {
                  GXUtil.WriteLog("comercio:[seudo value changed for attri]"+"ProveedorCuentaBancaria");
                  GXUtil.WriteLogRaw("Old: ",Z687ProveedorCuentaBancaria);
                  GXUtil.WriteLogRaw("Current: ",T001B4_A687ProveedorCuentaBancaria[0]);
               }
               if ( Z978ProveedorCIU != T001B4_A978ProveedorCIU[0] )
               {
                  GXUtil.WriteLog("comercio:[seudo value changed for attri]"+"ProveedorCIU");
                  GXUtil.WriteLogRaw("Old: ",Z978ProveedorCIU);
                  GXUtil.WriteLogRaw("Current: ",T001B4_A978ProveedorCIU[0]);
               }
               if ( Z151ProveedoresTipoId != T001B4_A151ProveedoresTipoId[0] )
               {
                  GXUtil.WriteLog("comercio:[seudo value changed for attri]"+"ProveedoresTipoId");
                  GXUtil.WriteLogRaw("Old: ",Z151ProveedoresTipoId);
                  GXUtil.WriteLogRaw("Current: ",T001B4_A151ProveedoresTipoId[0]);
               }
               if ( Z673BancoId != T001B4_A673BancoId[0] )
               {
                  GXUtil.WriteLog("comercio:[seudo value changed for attri]"+"BancoId");
                  GXUtil.WriteLogRaw("Old: ",Z673BancoId);
                  GXUtil.WriteLogRaw("Current: ",T001B4_A673BancoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Proveedor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1B28( )
      {
         BeforeValidate1B28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1B28( 0) ;
            CheckOptimisticConcurrency1B28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1B28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001B14 */
                     pr_default.execute(12, new Object[] {A282ProveedorNombre, A338ProveedorDocIdentidad, n430ProveedorTelefono, A430ProveedorTelefono, n431ProveedorDireccion, A431ProveedorDireccion, n433ProveedorEmail, A433ProveedorEmail, A344ProveedorEstado, n682ProveedorRazonSocial, A682ProveedorRazonSocial, n683ProveedorContacto, A683ProveedorContacto, n684ProveedorContactoCell, A684ProveedorContactoCell, n432ProveedorImagen, A432ProveedorImagen, n40000ProveedorImagen_GXI, A40000ProveedorImagen_GXI, n687ProveedorCuentaBancaria, A687ProveedorCuentaBancaria, A978ProveedorCIU, A151ProveedoresTipoId, n673BancoId, A673BancoId});
                     A133ProveedorID = T001B14_A133ProveedorID[0];
                     n133ProveedorID = T001B14_n133ProveedorID[0];
                     AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1B28( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1B0( ) ;
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
               Load1B28( ) ;
            }
            EndLevel1B28( ) ;
         }
         CloseExtendedTableCursors1B28( ) ;
      }

      protected void Update1B28( )
      {
         BeforeValidate1B28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1B28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001B15 */
                     pr_default.execute(13, new Object[] {A282ProveedorNombre, A338ProveedorDocIdentidad, n430ProveedorTelefono, A430ProveedorTelefono, n431ProveedorDireccion, A431ProveedorDireccion, n433ProveedorEmail, A433ProveedorEmail, A344ProveedorEstado, n682ProveedorRazonSocial, A682ProveedorRazonSocial, n683ProveedorContacto, A683ProveedorContacto, n684ProveedorContactoCell, A684ProveedorContactoCell, n687ProveedorCuentaBancaria, A687ProveedorCuentaBancaria, A978ProveedorCIU, A151ProveedoresTipoId, n673BancoId, A673BancoId, n133ProveedorID, A133ProveedorID});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proveedor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1B28( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1B28( ) ;
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
            EndLevel1B28( ) ;
         }
         CloseExtendedTableCursors1B28( ) ;
      }

      protected void DeferredUpdate1B28( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001B16 */
            pr_default.execute(14, new Object[] {n432ProveedorImagen, A432ProveedorImagen, n40000ProveedorImagen_GXI, A40000ProveedorImagen_GXI, n133ProveedorID, A133ProveedorID});
            pr_default.close(14);
            pr_default.SmartCacheProvider.SetUpdated("Proveedor");
         }
      }

      protected void delete( )
      {
         BeforeValidate1B28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1B28( ) ;
            AfterConfirm1B28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1B28( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1B52( ) ;
                  while ( RcdFound52 != 0 )
                  {
                     getByPrimaryKey1B52( ) ;
                     Delete1B52( ) ;
                     ScanNext1B52( ) ;
                  }
                  ScanEnd1B52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001B17 */
                     pr_default.execute(15, new Object[] {n133ProveedorID, A133ProveedorID});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1B28( ) ;
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1B28( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV22Pgmname = "Comercio";
            AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
            /* Using cursor T001B18 */
            pr_default.execute(16, new Object[] {n673BancoId, A673BancoId});
            A674BancoNombre = T001B18_A674BancoNombre[0];
            pr_default.close(16);
            /* Using cursor T001B19 */
            pr_default.execute(17, new Object[] {A151ProveedoresTipoId});
            A278ProveedoresTipoNombre = T001B19_A278ProveedoresTipoNombre[0];
            AssignAttri("", false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
            pr_default.close(17);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001B20 */
            pr_default.execute(18, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Postulaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T001B21 */
            pr_default.execute(19, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Lista Mapeo", "")+" ("+context.GetMessage( "Comercios SubTipo", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T001B22 */
            pr_default.execute(20, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Lista Mapeo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T001B23 */
            pr_default.execute(21, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Vincular Trn", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T001B24 */
            pr_default.execute(22, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T001B25 */
            pr_default.execute(23, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")+" ("+context.GetMessage( "Comercios SubTipo", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T001B26 */
            pr_default.execute(24, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T001B27 */
            pr_default.execute(25, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T001B28 */
            pr_default.execute(26, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agrupacion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T001B29 */
            pr_default.execute(27, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Proveedor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T001B30 */
            pr_default.execute(28, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Comercio | Proveedor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T001B31 */
            pr_default.execute(29, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Comisiones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
         }
      }

      protected void ProcessNestedLevel1B52( )
      {
         nGXsfl_99_idx = 0;
         while ( nGXsfl_99_idx < nRC_GXsfl_99 )
         {
            ReadRow1B52( ) ;
            if ( ( nRcdExists_52 != 0 ) || ( nIsMod_52 != 0 ) )
            {
               standaloneNotModal1B52( ) ;
               GetKey1B52( ) ;
               if ( ( nRcdExists_52 == 0 ) && ( nRcdDeleted_52 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1B52( ) ;
               }
               else
               {
                  if ( RcdFound52 != 0 )
                  {
                     if ( ( nRcdDeleted_52 != 0 ) && ( nRcdExists_52 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1B52( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_52 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1B52( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_52 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtProveedorSolicitudesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A152ProveedorSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProveedorSolicitudesNombre_Internalname, StringUtil.RTrim( A337ProveedorSolicitudesNombre)) ;
            ChangePostValue( edtProveedorSolicitudesFecha_Internalname, context.localUtil.Format(A280ProveedorSolicitudesFecha, "99/99/99")) ;
            ChangePostValue( "ZT_"+"Z152ProveedorSolicitudesId_"+sGXsfl_99_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z152ProveedorSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z337ProveedorSolicitudesNombre_"+sGXsfl_99_idx, StringUtil.RTrim( Z337ProveedorSolicitudesNombre)) ;
            ChangePostValue( "ZT_"+"Z280ProveedorSolicitudesFecha_"+sGXsfl_99_idx, context.localUtil.DToC( Z280ProveedorSolicitudesFecha, 0, "/")) ;
            ChangePostValue( "nRcdDeleted_52_"+sGXsfl_99_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_52_"+sGXsfl_99_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_52_"+sGXsfl_99_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_52 != 0 )
            {
               ChangePostValue( "PROVEEDORSOLICITUDESID_"+sGXsfl_99_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORSOLICITUDESNOMBRE_"+sGXsfl_99_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORSOLICITUDESFECHA_"+sGXsfl_99_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesFecha_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1B52( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_52 = 0;
         nIsMod_52 = 0;
         nRcdDeleted_52 = 0;
      }

      protected void ProcessLevel1B28( )
      {
         /* Save parent mode. */
         sMode28 = Gx_mode;
         ProcessNestedLevel1B52( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1B28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1B28( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(17);
            pr_default.close(16);
            context.CommitDataStores("comercio",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1B0( ) ;
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
            pr_default.close(17);
            pr_default.close(16);
            context.RollbackDataStores("comercio",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1B28( )
      {
         /* Scan By routine */
         /* Using cursor T001B32 */
         pr_default.execute(30);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound28 = 1;
            A133ProveedorID = T001B32_A133ProveedorID[0];
            n133ProveedorID = T001B32_n133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1B28( )
      {
         /* Scan next routine */
         pr_default.readNext(30);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound28 = 1;
            A133ProveedorID = T001B32_A133ProveedorID[0];
            n133ProveedorID = T001B32_n133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         }
      }

      protected void ScanEnd1B28( )
      {
         pr_default.close(30);
      }

      protected void AfterConfirm1B28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1B28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1B28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1B28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1B28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1B28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1B28( )
      {
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         edtProveedorRazonSocial_Enabled = 0;
         AssignProp("", false, edtProveedorRazonSocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorRazonSocial_Enabled), 5, 0), true);
         edtProveedorTelefono_Enabled = 0;
         AssignProp("", false, edtProveedorTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorTelefono_Enabled), 5, 0), true);
         edtProveedorDireccion_Enabled = 0;
         AssignProp("", false, edtProveedorDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorDireccion_Enabled), 5, 0), true);
         edtProveedorEmail_Enabled = 0;
         AssignProp("", false, edtProveedorEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorEmail_Enabled), 5, 0), true);
         edtProveedorContacto_Enabled = 0;
         AssignProp("", false, edtProveedorContacto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorContacto_Enabled), 5, 0), true);
         edtProveedorContactoCell_Enabled = 0;
         AssignProp("", false, edtProveedorContactoCell_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorContactoCell_Enabled), 5, 0), true);
         cmbProveedorEstado.Enabled = 0;
         AssignProp("", false, cmbProveedorEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorEstado.Enabled), 5, 0), true);
         imgProveedorImagen_Enabled = 0;
         AssignProp("", false, imgProveedorImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProveedorImagen_Enabled), 5, 0), true);
         edtProveedorCuentaBancaria_Enabled = 0;
         AssignProp("", false, edtProveedorCuentaBancaria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorCuentaBancaria_Enabled), 5, 0), true);
         edtBancoId_Enabled = 0;
         AssignProp("", false, edtBancoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBancoId_Enabled), 5, 0), true);
         edtavCombobancoid_Enabled = 0;
         AssignProp("", false, edtavCombobancoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombobancoid_Enabled), 5, 0), true);
         edtProveedoresTipoId_Enabled = 0;
         AssignProp("", false, edtProveedoresTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoId_Enabled), 5, 0), true);
         edtProveedoresTipoNombre_Enabled = 0;
         AssignProp("", false, edtProveedoresTipoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoNombre_Enabled), 5, 0), true);
         edtProveedorDocIdentidad_Enabled = 0;
         AssignProp("", false, edtProveedorDocIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorDocIdentidad_Enabled), 5, 0), true);
      }

      protected void ZM1B52( short GX_JID )
      {
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z337ProveedorSolicitudesNombre = T001B3_A337ProveedorSolicitudesNombre[0];
               Z280ProveedorSolicitudesFecha = T001B3_A280ProveedorSolicitudesFecha[0];
            }
            else
            {
               Z337ProveedorSolicitudesNombre = A337ProveedorSolicitudesNombre;
               Z280ProveedorSolicitudesFecha = A280ProveedorSolicitudesFecha;
            }
         }
         if ( GX_JID == -21 )
         {
            Z133ProveedorID = A133ProveedorID;
            Z152ProveedorSolicitudesId = A152ProveedorSolicitudesId;
            Z337ProveedorSolicitudesNombre = A337ProveedorSolicitudesNombre;
            Z280ProveedorSolicitudesFecha = A280ProveedorSolicitudesFecha;
         }
      }

      protected void standaloneNotModal1B52( )
      {
         edtProveedorSolicitudesId_Enabled = 0;
         AssignProp("", false, edtProveedorSolicitudesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0), !bGXsfl_99_Refreshing);
         edtProveedorSolicitudesNombre_Enabled = 0;
         AssignProp("", false, edtProveedorSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesNombre_Enabled), 5, 0), !bGXsfl_99_Refreshing);
         edtProveedorSolicitudesFecha_Enabled = 0;
         AssignProp("", false, edtProveedorSolicitudesFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesFecha_Enabled), 5, 0), !bGXsfl_99_Refreshing);
      }

      protected void standaloneModal1B52( )
      {
      }

      protected void Load1B52( )
      {
         /* Using cursor T001B33 */
         pr_default.execute(31, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound52 = 1;
            A337ProveedorSolicitudesNombre = T001B33_A337ProveedorSolicitudesNombre[0];
            A280ProveedorSolicitudesFecha = T001B33_A280ProveedorSolicitudesFecha[0];
            n280ProveedorSolicitudesFecha = T001B33_n280ProveedorSolicitudesFecha[0];
            ZM1B52( -21) ;
         }
         pr_default.close(31);
         OnLoadActions1B52( ) ;
      }

      protected void OnLoadActions1B52( )
      {
      }

      protected void CheckExtendedTable1B52( )
      {
         nIsDirty_52 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1B52( ) ;
      }

      protected void CloseExtendedTableCursors1B52( )
      {
      }

      protected void enableDisable1B52( )
      {
      }

      protected void GetKey1B52( )
      {
         /* Using cursor T001B34 */
         pr_default.execute(32, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound52 = 1;
         }
         else
         {
            RcdFound52 = 0;
         }
         pr_default.close(32);
      }

      protected void getByPrimaryKey1B52( )
      {
         /* Using cursor T001B3 */
         pr_default.execute(1, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1B52( 21) ;
            RcdFound52 = 1;
            InitializeNonKey1B52( ) ;
            A152ProveedorSolicitudesId = T001B3_A152ProveedorSolicitudesId[0];
            A337ProveedorSolicitudesNombre = T001B3_A337ProveedorSolicitudesNombre[0];
            A280ProveedorSolicitudesFecha = T001B3_A280ProveedorSolicitudesFecha[0];
            n280ProveedorSolicitudesFecha = T001B3_n280ProveedorSolicitudesFecha[0];
            Z133ProveedorID = A133ProveedorID;
            Z152ProveedorSolicitudesId = A152ProveedorSolicitudesId;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1B52( ) ;
            Gx_mode = sMode52;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound52 = 0;
            InitializeNonKey1B52( ) ;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1B52( ) ;
            Gx_mode = sMode52;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1B52( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1B52( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001B2 */
            pr_default.execute(0, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProveedorSolicitudes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z337ProveedorSolicitudesNombre, T001B2_A337ProveedorSolicitudesNombre[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z280ProveedorSolicitudesFecha ) != DateTimeUtil.ResetTime ( T001B2_A280ProveedorSolicitudesFecha[0] ) ) )
            {
               if ( StringUtil.StrCmp(Z337ProveedorSolicitudesNombre, T001B2_A337ProveedorSolicitudesNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("comercio:[seudo value changed for attri]"+"ProveedorSolicitudesNombre");
                  GXUtil.WriteLogRaw("Old: ",Z337ProveedorSolicitudesNombre);
                  GXUtil.WriteLogRaw("Current: ",T001B2_A337ProveedorSolicitudesNombre[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z280ProveedorSolicitudesFecha ) != DateTimeUtil.ResetTime ( T001B2_A280ProveedorSolicitudesFecha[0] ) )
               {
                  GXUtil.WriteLog("comercio:[seudo value changed for attri]"+"ProveedorSolicitudesFecha");
                  GXUtil.WriteLogRaw("Old: ",Z280ProveedorSolicitudesFecha);
                  GXUtil.WriteLogRaw("Current: ",T001B2_A280ProveedorSolicitudesFecha[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProveedorSolicitudes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1B52( )
      {
         BeforeValidate1B52( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B52( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1B52( 0) ;
            CheckOptimisticConcurrency1B52( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B52( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1B52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001B35 */
                     pr_default.execute(33, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId, A337ProveedorSolicitudesNombre, n280ProveedorSolicitudesFecha, A280ProveedorSolicitudesFecha});
                     pr_default.close(33);
                     pr_default.SmartCacheProvider.SetUpdated("ProveedorSolicitudes");
                     if ( (pr_default.getStatus(33) == 1) )
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
               Load1B52( ) ;
            }
            EndLevel1B52( ) ;
         }
         CloseExtendedTableCursors1B52( ) ;
      }

      protected void Update1B52( )
      {
         BeforeValidate1B52( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B52( ) ;
         }
         if ( ( nIsMod_52 != 0 ) || ( nIsDirty_52 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1B52( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1B52( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1B52( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001B36 */
                        pr_default.execute(34, new Object[] {A337ProveedorSolicitudesNombre, n280ProveedorSolicitudesFecha, A280ProveedorSolicitudesFecha, n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
                        pr_default.close(34);
                        pr_default.SmartCacheProvider.SetUpdated("ProveedorSolicitudes");
                        if ( (pr_default.getStatus(34) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProveedorSolicitudes"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1B52( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1B52( ) ;
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
               EndLevel1B52( ) ;
            }
         }
         CloseExtendedTableCursors1B52( ) ;
      }

      protected void DeferredUpdate1B52( )
      {
      }

      protected void Delete1B52( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1B52( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B52( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1B52( ) ;
            AfterConfirm1B52( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1B52( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001B37 */
                  pr_default.execute(35, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
                  pr_default.close(35);
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
         EndLevel1B52( ) ;
         Gx_mode = sMode52;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1B52( )
      {
         standaloneModal1B52( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1B52( )
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

      public void ScanStart1B52( )
      {
         /* Scan By routine */
         /* Using cursor T001B38 */
         pr_default.execute(36, new Object[] {n133ProveedorID, A133ProveedorID});
         RcdFound52 = 0;
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound52 = 1;
            A152ProveedorSolicitudesId = T001B38_A152ProveedorSolicitudesId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1B52( )
      {
         /* Scan next routine */
         pr_default.readNext(36);
         RcdFound52 = 0;
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound52 = 1;
            A152ProveedorSolicitudesId = T001B38_A152ProveedorSolicitudesId[0];
         }
      }

      protected void ScanEnd1B52( )
      {
         pr_default.close(36);
      }

      protected void AfterConfirm1B52( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1B52( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1B52( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1B52( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1B52( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1B52( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1B52( )
      {
         edtProveedorSolicitudesId_Enabled = 0;
         AssignProp("", false, edtProveedorSolicitudesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0), !bGXsfl_99_Refreshing);
         edtProveedorSolicitudesNombre_Enabled = 0;
         AssignProp("", false, edtProveedorSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesNombre_Enabled), 5, 0), !bGXsfl_99_Refreshing);
         edtProveedorSolicitudesFecha_Enabled = 0;
         AssignProp("", false, edtProveedorSolicitudesFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesFecha_Enabled), 5, 0), !bGXsfl_99_Refreshing);
      }

      protected void send_integrity_lvl_hashes1B52( )
      {
      }

      protected void send_integrity_lvl_hashes1B28( )
      {
      }

      protected void SubsflControlProps_9952( )
      {
         edtProveedorSolicitudesId_Internalname = "PROVEEDORSOLICITUDESID_"+sGXsfl_99_idx;
         edtProveedorSolicitudesNombre_Internalname = "PROVEEDORSOLICITUDESNOMBRE_"+sGXsfl_99_idx;
         edtProveedorSolicitudesFecha_Internalname = "PROVEEDORSOLICITUDESFECHA_"+sGXsfl_99_idx;
      }

      protected void SubsflControlProps_fel_9952( )
      {
         edtProveedorSolicitudesId_Internalname = "PROVEEDORSOLICITUDESID_"+sGXsfl_99_fel_idx;
         edtProveedorSolicitudesNombre_Internalname = "PROVEEDORSOLICITUDESNOMBRE_"+sGXsfl_99_fel_idx;
         edtProveedorSolicitudesFecha_Internalname = "PROVEEDORSOLICITUDESFECHA_"+sGXsfl_99_fel_idx;
      }

      protected void AddRow1B52( )
      {
         nGXsfl_99_idx = (int)(nGXsfl_99_idx+1);
         sGXsfl_99_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_99_idx), 4, 0), 4, "0");
         SubsflControlProps_9952( ) ;
         SendRow1B52( ) ;
      }

      protected void SendRow1B52( )
      {
         Gridlevel_solicitudesRow = GXWebRow.GetNew(context);
         if ( subGridlevel_solicitudes_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_solicitudes_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_solicitudes_Class, "") != 0 )
            {
               subGridlevel_solicitudes_Linesclass = subGridlevel_solicitudes_Class+"Odd";
            }
         }
         else if ( subGridlevel_solicitudes_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_solicitudes_Backstyle = 0;
            subGridlevel_solicitudes_Backcolor = subGridlevel_solicitudes_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_solicitudes_Class, "") != 0 )
            {
               subGridlevel_solicitudes_Linesclass = subGridlevel_solicitudes_Class+"Uniform";
            }
         }
         else if ( subGridlevel_solicitudes_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_solicitudes_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_solicitudes_Class, "") != 0 )
            {
               subGridlevel_solicitudes_Linesclass = subGridlevel_solicitudes_Class+"Odd";
            }
            subGridlevel_solicitudes_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_solicitudes_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_solicitudes_Backstyle = 1;
            if ( ((int)((nGXsfl_99_idx) % (2))) == 0 )
            {
               subGridlevel_solicitudes_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_solicitudes_Class, "") != 0 )
               {
                  subGridlevel_solicitudes_Linesclass = subGridlevel_solicitudes_Class+"Even";
               }
            }
            else
            {
               subGridlevel_solicitudes_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_solicitudes_Class, "") != 0 )
               {
                  subGridlevel_solicitudes_Linesclass = subGridlevel_solicitudes_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_52_" + sGXsfl_99_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_99_idx + "',99)\"";
         ROClassString = "Attribute";
         Gridlevel_solicitudesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorSolicitudesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A152ProveedorSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtProveedorSolicitudesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A152ProveedorSolicitudesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A152ProveedorSolicitudesId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,100);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorSolicitudesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorSolicitudesId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)99,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_52_" + sGXsfl_99_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_99_idx + "',99)\"";
         ROClassString = "Attribute";
         Gridlevel_solicitudesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorSolicitudesNombre_Internalname,StringUtil.RTrim( A337ProveedorSolicitudesNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorSolicitudesNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorSolicitudesNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)99,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_52_" + sGXsfl_99_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_99_idx + "',99)\"";
         ROClassString = "Attribute";
         Gridlevel_solicitudesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorSolicitudesFecha_Internalname,context.localUtil.Format(A280ProveedorSolicitudesFecha, "99/99/99"),context.localUtil.Format( A280ProveedorSolicitudesFecha, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,102);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorSolicitudesFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorSolicitudesFecha_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)99,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_solicitudesRow);
         send_integrity_lvl_hashes1B52( ) ;
         GXCCtl = "Z152ProveedorSolicitudesId_" + sGXsfl_99_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z152ProveedorSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z337ProveedorSolicitudesNombre_" + sGXsfl_99_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z337ProveedorSolicitudesNombre));
         GXCCtl = "Z280ProveedorSolicitudesFecha_" + sGXsfl_99_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.DToC( Z280ProveedorSolicitudesFecha, 0, "/"));
         GXCCtl = "nRcdDeleted_52_" + sGXsfl_99_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_52), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_52_" + sGXsfl_99_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_52), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_52_" + sGXsfl_99_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_52), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_99_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_99_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV8TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV8TrnContext);
         }
         GXCCtl = "vPROVEEDORID_" + sGXsfl_99_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORSOLICITUDESID_"+sGXsfl_99_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORSOLICITUDESNOMBRE_"+sGXsfl_99_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORSOLICITUDESFECHA_"+sGXsfl_99_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesFecha_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_solicitudesContainer.AddRow(Gridlevel_solicitudesRow);
      }

      protected void ReadRow1B52( )
      {
         nGXsfl_99_idx = (int)(nGXsfl_99_idx+1);
         sGXsfl_99_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_99_idx), 4, 0), 4, "0");
         SubsflControlProps_9952( ) ;
         edtProveedorSolicitudesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORSOLICITUDESID_"+sGXsfl_99_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedorSolicitudesNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORSOLICITUDESNOMBRE_"+sGXsfl_99_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedorSolicitudesFecha_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORSOLICITUDESFECHA_"+sGXsfl_99_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A152ProveedorSolicitudesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorSolicitudesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A337ProveedorSolicitudesNombre = cgiGet( edtProveedorSolicitudesNombre_Internalname);
         A280ProveedorSolicitudesFecha = context.localUtil.CToD( cgiGet( edtProveedorSolicitudesFecha_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
         n280ProveedorSolicitudesFecha = false;
         GXCCtl = "Z152ProveedorSolicitudesId_" + sGXsfl_99_idx;
         Z152ProveedorSolicitudesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z337ProveedorSolicitudesNombre_" + sGXsfl_99_idx;
         Z337ProveedorSolicitudesNombre = cgiGet( GXCCtl);
         GXCCtl = "Z280ProveedorSolicitudesFecha_" + sGXsfl_99_idx;
         Z280ProveedorSolicitudesFecha = context.localUtil.CToD( cgiGet( GXCCtl), 0);
         n280ProveedorSolicitudesFecha = ((DateTime.MinValue==A280ProveedorSolicitudesFecha) ? true : false);
         GXCCtl = "nRcdDeleted_52_" + sGXsfl_99_idx;
         nRcdDeleted_52 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_52_" + sGXsfl_99_idx;
         nRcdExists_52 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_52_" + sGXsfl_99_idx;
         nIsMod_52 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtProveedorSolicitudesFecha_Enabled = edtProveedorSolicitudesFecha_Enabled;
         defedtProveedorSolicitudesNombre_Enabled = edtProveedorSolicitudesNombre_Enabled;
         defedtProveedorSolicitudesId_Enabled = edtProveedorSolicitudesId_Enabled;
      }

      protected void ConfirmValues1B0( )
      {
         nGXsfl_99_idx = 0;
         sGXsfl_99_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_99_idx), 4, 0), 4, "0");
         SubsflControlProps_9952( ) ;
         while ( nGXsfl_99_idx < nRC_GXsfl_99 )
         {
            nGXsfl_99_idx = (int)(nGXsfl_99_idx+1);
            sGXsfl_99_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_99_idx), 4, 0), 4, "0");
            SubsflControlProps_9952( ) ;
            ChangePostValue( "Z152ProveedorSolicitudesId_"+sGXsfl_99_idx, cgiGet( "ZT_"+"Z152ProveedorSolicitudesId_"+sGXsfl_99_idx)) ;
            DeletePostValue( "ZT_"+"Z152ProveedorSolicitudesId_"+sGXsfl_99_idx) ;
            ChangePostValue( "Z337ProveedorSolicitudesNombre_"+sGXsfl_99_idx, cgiGet( "ZT_"+"Z337ProveedorSolicitudesNombre_"+sGXsfl_99_idx)) ;
            DeletePostValue( "ZT_"+"Z337ProveedorSolicitudesNombre_"+sGXsfl_99_idx) ;
            ChangePostValue( "Z280ProveedorSolicitudesFecha_"+sGXsfl_99_idx, cgiGet( "ZT_"+"Z280ProveedorSolicitudesFecha_"+sGXsfl_99_idx)) ;
            DeletePostValue( "ZT_"+"Z280ProveedorSolicitudesFecha_"+sGXsfl_99_idx) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "comercio.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV15ProveedorID,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("comercio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Comercio");
         forbiddenHiddens.Add("ProveedorID", context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("ProveedorNombre", StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")));
         forbiddenHiddens.Add("ProveedorEstado", StringUtil.RTrim( context.localUtil.Format( A344ProveedorEstado, "")));
         forbiddenHiddens.Add("ProveedoresTipoId", context.localUtil.Format( (decimal)(A151ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("ProveedorDocIdentidad", StringUtil.RTrim( context.localUtil.Format( A338ProveedorDocIdentidad, "")));
         forbiddenHiddens.Add("Insert_ProveedoresTipoId", context.localUtil.Format( (decimal)(AV10Insert_ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_BancoId", context.localUtil.Format( (decimal)(AV18Insert_BancoId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ProveedorCIU", StringUtil.BoolToStr( A978ProveedorCIU));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("comercio:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z282ProveedorNombre", StringUtil.RTrim( Z282ProveedorNombre));
         GxWebStd.gx_hidden_field( context, "Z338ProveedorDocIdentidad", StringUtil.RTrim( Z338ProveedorDocIdentidad));
         GxWebStd.gx_hidden_field( context, "Z430ProveedorTelefono", StringUtil.RTrim( Z430ProveedorTelefono));
         GxWebStd.gx_hidden_field( context, "Z431ProveedorDireccion", Z431ProveedorDireccion);
         GxWebStd.gx_hidden_field( context, "Z433ProveedorEmail", Z433ProveedorEmail);
         GxWebStd.gx_hidden_field( context, "Z344ProveedorEstado", StringUtil.RTrim( Z344ProveedorEstado));
         GxWebStd.gx_hidden_field( context, "Z682ProveedorRazonSocial", StringUtil.RTrim( Z682ProveedorRazonSocial));
         GxWebStd.gx_hidden_field( context, "Z683ProveedorContacto", StringUtil.RTrim( Z683ProveedorContacto));
         GxWebStd.gx_hidden_field( context, "Z684ProveedorContactoCell", StringUtil.RTrim( Z684ProveedorContactoCell));
         GxWebStd.gx_hidden_field( context, "Z687ProveedorCuentaBancaria", StringUtil.RTrim( Z687ProveedorCuentaBancaria));
         GxWebStd.gx_boolean_hidden_field( context, "Z978ProveedorCIU", Z978ProveedorCIU);
         GxWebStd.gx_hidden_field( context, "Z151ProveedoresTipoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z151ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z673BancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z673BancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_99", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_99_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N673BancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A673BancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBANCOID_DATA", AV19BancoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBANCOID_DATA", AV19BancoId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV8TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV8TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV8TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROVEEDORESTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10Insert_ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_BANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18Insert_BancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "PROVEEDORCIU", A978ProveedorCIU);
         GxWebStd.gx_hidden_field( context, "PROVEEDORIMAGEN_GXI", A40000ProveedorImagen_GXI);
         GxWebStd.gx_hidden_field( context, "BANCONOMBRE", StringUtil.RTrim( A674BancoNombre));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GXCCtlgxBlob = "PROVEEDORIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A432ProveedorImagen);
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOID_Objectcall", StringUtil.RTrim( Combo_bancoid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOID_Cls", StringUtil.RTrim( Combo_bancoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOID_Selectedvalue_set", StringUtil.RTrim( Combo_bancoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOID_Enabled", StringUtil.BoolToStr( Combo_bancoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOID_Emptyitem", StringUtil.BoolToStr( Combo_bancoid_Emptyitem));
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "comercio.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV15ProveedorID,18,0));
         return formatLink("comercio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Comercio" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Datos Generales del Comercio", "") ;
      }

      protected void InitializeNonKey1B28( )
      {
         A151ProveedoresTipoId = 0;
         AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
         A673BancoId = 0;
         n673BancoId = false;
         AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
         n673BancoId = ((0==A673BancoId) ? true : false);
         A278ProveedoresTipoNombre = "";
         AssignAttri("", false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
         A282ProveedorNombre = "";
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A338ProveedorDocIdentidad = "";
         AssignAttri("", false, "A338ProveedorDocIdentidad", A338ProveedorDocIdentidad);
         A430ProveedorTelefono = "";
         n430ProveedorTelefono = false;
         AssignAttri("", false, "A430ProveedorTelefono", A430ProveedorTelefono);
         n430ProveedorTelefono = (String.IsNullOrEmpty(StringUtil.RTrim( A430ProveedorTelefono)) ? true : false);
         A431ProveedorDireccion = "";
         n431ProveedorDireccion = false;
         AssignAttri("", false, "A431ProveedorDireccion", A431ProveedorDireccion);
         n431ProveedorDireccion = (String.IsNullOrEmpty(StringUtil.RTrim( A431ProveedorDireccion)) ? true : false);
         A433ProveedorEmail = "";
         n433ProveedorEmail = false;
         AssignAttri("", false, "A433ProveedorEmail", A433ProveedorEmail);
         n433ProveedorEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A433ProveedorEmail)) ? true : false);
         A344ProveedorEstado = "";
         AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
         A682ProveedorRazonSocial = "";
         n682ProveedorRazonSocial = false;
         AssignAttri("", false, "A682ProveedorRazonSocial", A682ProveedorRazonSocial);
         n682ProveedorRazonSocial = (String.IsNullOrEmpty(StringUtil.RTrim( A682ProveedorRazonSocial)) ? true : false);
         A683ProveedorContacto = "";
         n683ProveedorContacto = false;
         AssignAttri("", false, "A683ProveedorContacto", A683ProveedorContacto);
         n683ProveedorContacto = (String.IsNullOrEmpty(StringUtil.RTrim( A683ProveedorContacto)) ? true : false);
         A684ProveedorContactoCell = "";
         n684ProveedorContactoCell = false;
         AssignAttri("", false, "A684ProveedorContactoCell", A684ProveedorContactoCell);
         n684ProveedorContactoCell = (String.IsNullOrEmpty(StringUtil.RTrim( A684ProveedorContactoCell)) ? true : false);
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
         A687ProveedorCuentaBancaria = "";
         n687ProveedorCuentaBancaria = false;
         AssignAttri("", false, "A687ProveedorCuentaBancaria", A687ProveedorCuentaBancaria);
         n687ProveedorCuentaBancaria = (String.IsNullOrEmpty(StringUtil.RTrim( A687ProveedorCuentaBancaria)) ? true : false);
         A674BancoNombre = "";
         AssignAttri("", false, "A674BancoNombre", A674BancoNombre);
         A978ProveedorCIU = false;
         AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
         Z282ProveedorNombre = "";
         Z338ProveedorDocIdentidad = "";
         Z430ProveedorTelefono = "";
         Z431ProveedorDireccion = "";
         Z433ProveedorEmail = "";
         Z344ProveedorEstado = "";
         Z682ProveedorRazonSocial = "";
         Z683ProveedorContacto = "";
         Z684ProveedorContactoCell = "";
         Z687ProveedorCuentaBancaria = "";
         Z978ProveedorCIU = false;
         Z151ProveedoresTipoId = 0;
         Z673BancoId = 0;
      }

      protected void InitAll1B28( )
      {
         A133ProveedorID = 0;
         n133ProveedorID = false;
         AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         InitializeNonKey1B28( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A978ProveedorCIU = i978ProveedorCIU;
         AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
      }

      protected void InitializeNonKey1B52( )
      {
         A337ProveedorSolicitudesNombre = "";
         A280ProveedorSolicitudesFecha = DateTime.MinValue;
         n280ProveedorSolicitudesFecha = false;
         Z337ProveedorSolicitudesNombre = "";
         Z280ProveedorSolicitudesFecha = DateTime.MinValue;
      }

      protected void InitAll1B52( )
      {
         A152ProveedorSolicitudesId = 0;
         InitializeNonKey1B52( ) ;
      }

      protected void StandaloneModalInsert1B52( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932041729", true, true, false);
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
         context.AddJavascriptSource("comercio.js", "?2026932041730", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties52( )
      {
         edtProveedorSolicitudesFecha_Enabled = defedtProveedorSolicitudesFecha_Enabled;
         AssignProp("", false, edtProveedorSolicitudesFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesFecha_Enabled), 5, 0), !bGXsfl_99_Refreshing);
         edtProveedorSolicitudesNombre_Enabled = defedtProveedorSolicitudesNombre_Enabled;
         AssignProp("", false, edtProveedorSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesNombre_Enabled), 5, 0), !bGXsfl_99_Refreshing);
         edtProveedorSolicitudesId_Enabled = defedtProveedorSolicitudesId_Enabled;
         AssignProp("", false, edtProveedorSolicitudesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0), !bGXsfl_99_Refreshing);
      }

      protected void StartGridControl99( )
      {
         Gridlevel_solicitudesContainer.AddObjectProperty("GridName", "Gridlevel_solicitudes");
         Gridlevel_solicitudesContainer.AddObjectProperty("Header", subGridlevel_solicitudes_Header);
         Gridlevel_solicitudesContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_solicitudesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_solicitudes_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_solicitudesContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_solicitudesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_solicitudesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A152ProveedorSolicitudesId), 18, 0, ".", ""))));
         Gridlevel_solicitudesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesId_Enabled), 5, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddColumnProperties(Gridlevel_solicitudesColumn);
         Gridlevel_solicitudesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_solicitudesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A337ProveedorSolicitudesNombre)));
         Gridlevel_solicitudesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddColumnProperties(Gridlevel_solicitudesColumn);
         Gridlevel_solicitudesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_solicitudesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A280ProveedorSolicitudesFecha, "99/99/99")));
         Gridlevel_solicitudesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorSolicitudesFecha_Enabled), 5, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddColumnProperties(Gridlevel_solicitudesColumn);
         Gridlevel_solicitudesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_solicitudes_Selectedindex), 4, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_solicitudes_Allowselection), 1, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_solicitudes_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_solicitudes_Allowhovering), 1, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_solicitudes_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_solicitudes_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_solicitudes_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTabgeneral_title_Internalname = "TABGENERAL_TITLE";
         edtProveedorID_Internalname = "PROVEEDORID";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         edtProveedorRazonSocial_Internalname = "PROVEEDORRAZONSOCIAL";
         edtProveedorTelefono_Internalname = "PROVEEDORTELEFONO";
         edtProveedorDireccion_Internalname = "PROVEEDORDIRECCION";
         edtProveedorEmail_Internalname = "PROVEEDOREMAIL";
         edtProveedorContacto_Internalname = "PROVEEDORCONTACTO";
         edtProveedorContactoCell_Internalname = "PROVEEDORCONTACTOCELL";
         divB1_Internalname = "B1";
         cmbProveedorEstado_Internalname = "PROVEEDORESTADO";
         imgProveedorImagen_Internalname = "PROVEEDORIMAGEN";
         edtProveedorCuentaBancaria_Internalname = "PROVEEDORCUENTABANCARIA";
         lblTextblockbancoid_Internalname = "TEXTBLOCKBANCOID";
         Combo_bancoid_Internalname = "COMBO_BANCOID";
         edtBancoId_Internalname = "BANCOID";
         divTablesplittedbancoid_Internalname = "TABLESPLITTEDBANCOID";
         divB2_Internalname = "B2";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         lblTablevel_solicitudes_title_Internalname = "TABLEVEL_SOLICITUDES_TITLE";
         edtProveedorSolicitudesId_Internalname = "PROVEEDORSOLICITUDESID";
         edtProveedorSolicitudesNombre_Internalname = "PROVEEDORSOLICITUDESNOMBRE";
         edtProveedorSolicitudesFecha_Internalname = "PROVEEDORSOLICITUDESFECHA";
         divTableleaflevel_solicitudes_Internalname = "TABLELEAFLEVEL_SOLICITUDES";
         divTabtablelevel_solicitudes_Internalname = "TABTABLELEVEL_SOLICITUDES";
         Gxuitabspanel_tabs_Internalname = "GXUITABSPANEL_TABS";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombobancoid_Internalname = "vCOMBOBANCOID";
         divSectionattribute_bancoid_Internalname = "SECTIONATTRIBUTE_BANCOID";
         edtProveedoresTipoId_Internalname = "PROVEEDORESTIPOID";
         edtProveedoresTipoNombre_Internalname = "PROVEEDORESTIPONOMBRE";
         edtProveedorDocIdentidad_Internalname = "PROVEEDORDOCIDENTIDAD";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_673_Internalname = "PROMPT_673";
         subGridlevel_solicitudes_Internalname = "GRIDLEVEL_SOLICITUDES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_solicitudes_Allowcollapsing = 0;
         subGridlevel_solicitudes_Allowselection = 0;
         subGridlevel_solicitudes_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Datos Generales del Comercio", "");
         edtProveedorSolicitudesFecha_Jsonclick = "";
         edtProveedorSolicitudesNombre_Jsonclick = "";
         edtProveedorSolicitudesId_Jsonclick = "";
         subGridlevel_solicitudes_Class = "WorkWith";
         subGridlevel_solicitudes_Backcolorstyle = 0;
         edtProveedorSolicitudesFecha_Enabled = 0;
         edtProveedorSolicitudesNombre_Enabled = 0;
         edtProveedorSolicitudesId_Enabled = 0;
         edtProveedorDocIdentidad_Jsonclick = "";
         edtProveedorDocIdentidad_Enabled = 0;
         edtProveedorDocIdentidad_Visible = 1;
         edtProveedoresTipoNombre_Jsonclick = "";
         edtProveedoresTipoNombre_Enabled = 0;
         edtProveedoresTipoNombre_Visible = 1;
         edtProveedoresTipoId_Jsonclick = "";
         edtProveedoresTipoId_Enabled = 0;
         edtProveedoresTipoId_Visible = 1;
         edtavCombobancoid_Jsonclick = "";
         edtavCombobancoid_Enabled = 0;
         edtavCombobancoid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         imgprompt_673_Visible = 1;
         imgprompt_673_Link = "";
         edtBancoId_Jsonclick = "";
         edtBancoId_Enabled = 1;
         edtBancoId_Visible = 1;
         Combo_bancoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_bancoid_Cls = "ExtendedCombo AttributeFL";
         Combo_bancoid_Enabled = Convert.ToBoolean( -1);
         edtProveedorCuentaBancaria_Jsonclick = "";
         edtProveedorCuentaBancaria_Enabled = 1;
         imgProveedorImagen_Enabled = 1;
         cmbProveedorEstado_Jsonclick = "";
         cmbProveedorEstado.Enabled = 0;
         edtProveedorContactoCell_Jsonclick = "";
         edtProveedorContactoCell_Enabled = 1;
         edtProveedorContacto_Jsonclick = "";
         edtProveedorContacto_Enabled = 1;
         edtProveedorEmail_Jsonclick = "";
         edtProveedorEmail_Enabled = 1;
         edtProveedorDireccion_Enabled = 1;
         edtProveedorTelefono_Jsonclick = "";
         edtProveedorTelefono_Enabled = 1;
         edtProveedorRazonSocial_Jsonclick = "";
         edtProveedorRazonSocial_Enabled = 1;
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Enabled = 0;
         edtProveedorID_Jsonclick = "";
         edtProveedorID_Enabled = 0;
         Gxuitabspanel_tabs_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs_Class = "Tab";
         Gxuitabspanel_tabs_Pagecount = 2;
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

      protected void gxnrGridlevel_solicitudes_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_9952( ) ;
         while ( nGXsfl_99_idx <= nRC_GXsfl_99 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1B52( ) ;
            standaloneModal1B52( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1B52( ) ;
            nGXsfl_99_idx = (int)(nGXsfl_99_idx+1);
            sGXsfl_99_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_99_idx), 4, 0), 4, "0");
            SubsflControlProps_9952( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_solicitudesContainer)) ;
         /* End function gxnrGridlevel_solicitudes_newrow */
      }

      protected void init_web_controls( )
      {
         cmbProveedorEstado.Name = "PROVEEDORESTADO";
         cmbProveedorEstado.WebTags = "";
         cmbProveedorEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbProveedorEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbProveedorEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbProveedorEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbProveedorEstado.ItemCount > 0 )
         {
            A344ProveedorEstado = cmbProveedorEstado.getValidValue(A344ProveedorEstado);
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
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

      public void Valid_Bancoid( )
      {
         n673BancoId = false;
         /* Using cursor T001B18 */
         pr_default.execute(16, new Object[] {n673BancoId, A673BancoId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A673BancoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Banco", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "BANCOID");
               AnyError = 1;
               GX_FocusControl = edtBancoId_Internalname;
            }
         }
         A674BancoNombre = T001B18_A674BancoNombre[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A674BancoNombre", StringUtil.RTrim( A674BancoNombre));
      }

      public void Valid_Proveedorestipoid( )
      {
         /* Using cursor T001B19 */
         pr_default.execute(17, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
         }
         A278ProveedoresTipoNombre = T001B19_A278ProveedoresTipoNombre[0];
         pr_default.close(17);
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV15ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV15ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'cmbProveedorEstado'},{av:'A344ProveedorEstado',fld:'PROVEEDORESTADO',pic:'',type:'char'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A338ProveedorDocIdentidad',fld:'PROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'AV10Insert_ProveedoresTipoId',fld:'vINSERT_PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV18Insert_BancoId',fld:'vINSERT_BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E121B2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDOREMAIL","{handler:'Valid_Proveedoremail',iparms:[]");
         setEventMetadata("VALID_PROVEEDOREMAIL",",oparms:[]}");
         setEventMetadata("VALID_BANCOID","{handler:'Valid_Bancoid',iparms:[{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A674BancoNombre',fld:'BANCONOMBRE',pic:'',type:'char'}]");
         setEventMetadata("VALID_BANCOID",",oparms:[{av:'A674BancoNombre',fld:'BANCONOMBRE',pic:'',type:'char'}]}");
         setEventMetadata("VALIDV_COMBOBANCOID","{handler:'Validv_Combobancoid',iparms:[]");
         setEventMetadata("VALIDV_COMBOBANCOID",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORESTIPOID","{handler:'Valid_Proveedorestipoid',iparms:[{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A278ProveedoresTipoNombre',fld:'PROVEEDORESTIPONOMBRE',pic:'',type:'char'}]");
         setEventMetadata("VALID_PROVEEDORESTIPOID",",oparms:[{av:'A278ProveedoresTipoNombre',fld:'PROVEEDORESTIPONOMBRE',pic:'',type:'char'}]}");
         setEventMetadata("VALID_PROVEEDORSOLICITUDESID","{handler:'Valid_Proveedorsolicitudesid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORSOLICITUDESID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Proveedorsolicitudesfecha',iparms:[]");
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
         pr_default.close(17);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z282ProveedorNombre = "";
         Z338ProveedorDocIdentidad = "";
         Z430ProveedorTelefono = "";
         Z431ProveedorDireccion = "";
         Z433ProveedorEmail = "";
         Z344ProveedorEstado = "";
         Z682ProveedorRazonSocial = "";
         Z683ProveedorContacto = "";
         Z684ProveedorContactoCell = "";
         Z687ProveedorCuentaBancaria = "";
         Combo_bancoid_Selectedvalue_get = "";
         Z337ProveedorSolicitudesNombre = "";
         Z280ProveedorSolicitudesFecha = DateTime.MinValue;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A344ProveedorEstado = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblTabgeneral_title_Jsonclick = "";
         TempTags = "";
         A282ProveedorNombre = "";
         A682ProveedorRazonSocial = "";
         gxphoneLink = "";
         A430ProveedorTelefono = "";
         A431ProveedorDireccion = "";
         A433ProveedorEmail = "";
         A683ProveedorContacto = "";
         A684ProveedorContactoCell = "";
         A432ProveedorImagen = "";
         A40000ProveedorImagen_GXI = "";
         sImgUrl = "";
         A687ProveedorCuentaBancaria = "";
         lblTextblockbancoid_Jsonclick = "";
         ucCombo_bancoid = new GXUserControl();
         Combo_bancoid_Caption = "";
         AV19BancoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         imgprompt_673_gximage = "";
         lblTablevel_solicitudes_title_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A278ProveedoresTipoNombre = "";
         A338ProveedorDocIdentidad = "";
         Gridlevel_solicitudesContainer = new GXWebGrid( context);
         sMode52 = "";
         sStyleString = "";
         A674BancoNombre = "";
         AV22Pgmname = "";
         Combo_bancoid_Objectcall = "";
         Combo_bancoid_Class = "";
         Combo_bancoid_Icontype = "";
         Combo_bancoid_Icon = "";
         Combo_bancoid_Tooltip = "";
         Combo_bancoid_Selectedvalue_set = "";
         Combo_bancoid_Selectedtext_set = "";
         Combo_bancoid_Selectedtext_get = "";
         Combo_bancoid_Gamoauthtoken = "";
         Combo_bancoid_Ddointernalname = "";
         Combo_bancoid_Titlecontrolalign = "";
         Combo_bancoid_Dropdownoptionstype = "";
         Combo_bancoid_Titlecontrolidtoreplace = "";
         Combo_bancoid_Datalisttype = "";
         Combo_bancoid_Datalistfixedvalues = "";
         Combo_bancoid_Datalistproc = "";
         Combo_bancoid_Datalistprocparametersprefix = "";
         Combo_bancoid_Remoteservicesparameters = "";
         Combo_bancoid_Htmltemplate = "";
         Combo_bancoid_Multiplevaluestype = "";
         Combo_bancoid_Loadingdata = "";
         Combo_bancoid_Noresultsfound = "";
         Combo_bancoid_Emptyitemtext = "";
         Combo_bancoid_Onlyselectedvalues = "";
         Combo_bancoid_Selectalltext = "";
         Combo_bancoid_Multiplevaluesseparator = "";
         Combo_bancoid_Addnewoptiontext = "";
         Gxuitabspanel_tabs_Objectcall = "";
         Gxuitabspanel_tabs_Activepagecontrolname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode28 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A337ProveedorSolicitudesNombre = "";
         A280ProveedorSolicitudesFecha = DateTime.MinValue;
         AV16WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9WebSession = context.GetSession();
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         GXt_objcol_SdtDVB_SDTComboData_Item2 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV20ComboSelectedValue = "";
         Z432ProveedorImagen = "";
         Z40000ProveedorImagen_GXI = "";
         Z278ProveedoresTipoNombre = "";
         Z674BancoNombre = "";
         T001B6_A278ProveedoresTipoNombre = new string[] {""} ;
         T001B7_A674BancoNombre = new string[] {""} ;
         T001B8_A133ProveedorID = new long[1] ;
         T001B8_n133ProveedorID = new bool[] {false} ;
         T001B8_A278ProveedoresTipoNombre = new string[] {""} ;
         T001B8_A282ProveedorNombre = new string[] {""} ;
         T001B8_A338ProveedorDocIdentidad = new string[] {""} ;
         T001B8_A430ProveedorTelefono = new string[] {""} ;
         T001B8_n430ProveedorTelefono = new bool[] {false} ;
         T001B8_A431ProveedorDireccion = new string[] {""} ;
         T001B8_n431ProveedorDireccion = new bool[] {false} ;
         T001B8_A433ProveedorEmail = new string[] {""} ;
         T001B8_n433ProveedorEmail = new bool[] {false} ;
         T001B8_A344ProveedorEstado = new string[] {""} ;
         T001B8_A682ProveedorRazonSocial = new string[] {""} ;
         T001B8_n682ProveedorRazonSocial = new bool[] {false} ;
         T001B8_A683ProveedorContacto = new string[] {""} ;
         T001B8_n683ProveedorContacto = new bool[] {false} ;
         T001B8_A684ProveedorContactoCell = new string[] {""} ;
         T001B8_n684ProveedorContactoCell = new bool[] {false} ;
         T001B8_A40000ProveedorImagen_GXI = new string[] {""} ;
         T001B8_n40000ProveedorImagen_GXI = new bool[] {false} ;
         T001B8_A687ProveedorCuentaBancaria = new string[] {""} ;
         T001B8_n687ProveedorCuentaBancaria = new bool[] {false} ;
         T001B8_A674BancoNombre = new string[] {""} ;
         T001B8_A978ProveedorCIU = new bool[] {false} ;
         T001B8_A151ProveedoresTipoId = new long[1] ;
         T001B8_A673BancoId = new long[1] ;
         T001B8_n673BancoId = new bool[] {false} ;
         T001B8_A432ProveedorImagen = new string[] {""} ;
         T001B8_n432ProveedorImagen = new bool[] {false} ;
         T001B9_A674BancoNombre = new string[] {""} ;
         T001B10_A278ProveedoresTipoNombre = new string[] {""} ;
         T001B11_A133ProveedorID = new long[1] ;
         T001B11_n133ProveedorID = new bool[] {false} ;
         T001B5_A133ProveedorID = new long[1] ;
         T001B5_n133ProveedorID = new bool[] {false} ;
         T001B5_A282ProveedorNombre = new string[] {""} ;
         T001B5_A338ProveedorDocIdentidad = new string[] {""} ;
         T001B5_A430ProveedorTelefono = new string[] {""} ;
         T001B5_n430ProveedorTelefono = new bool[] {false} ;
         T001B5_A431ProveedorDireccion = new string[] {""} ;
         T001B5_n431ProveedorDireccion = new bool[] {false} ;
         T001B5_A433ProveedorEmail = new string[] {""} ;
         T001B5_n433ProveedorEmail = new bool[] {false} ;
         T001B5_A344ProveedorEstado = new string[] {""} ;
         T001B5_A682ProveedorRazonSocial = new string[] {""} ;
         T001B5_n682ProveedorRazonSocial = new bool[] {false} ;
         T001B5_A683ProveedorContacto = new string[] {""} ;
         T001B5_n683ProveedorContacto = new bool[] {false} ;
         T001B5_A684ProveedorContactoCell = new string[] {""} ;
         T001B5_n684ProveedorContactoCell = new bool[] {false} ;
         T001B5_A40000ProveedorImagen_GXI = new string[] {""} ;
         T001B5_n40000ProveedorImagen_GXI = new bool[] {false} ;
         T001B5_A687ProveedorCuentaBancaria = new string[] {""} ;
         T001B5_n687ProveedorCuentaBancaria = new bool[] {false} ;
         T001B5_A978ProveedorCIU = new bool[] {false} ;
         T001B5_A151ProveedoresTipoId = new long[1] ;
         T001B5_A673BancoId = new long[1] ;
         T001B5_n673BancoId = new bool[] {false} ;
         T001B5_A432ProveedorImagen = new string[] {""} ;
         T001B5_n432ProveedorImagen = new bool[] {false} ;
         T001B12_A133ProveedorID = new long[1] ;
         T001B12_n133ProveedorID = new bool[] {false} ;
         T001B13_A133ProveedorID = new long[1] ;
         T001B13_n133ProveedorID = new bool[] {false} ;
         T001B4_A133ProveedorID = new long[1] ;
         T001B4_n133ProveedorID = new bool[] {false} ;
         T001B4_A282ProveedorNombre = new string[] {""} ;
         T001B4_A338ProveedorDocIdentidad = new string[] {""} ;
         T001B4_A430ProveedorTelefono = new string[] {""} ;
         T001B4_n430ProveedorTelefono = new bool[] {false} ;
         T001B4_A431ProveedorDireccion = new string[] {""} ;
         T001B4_n431ProveedorDireccion = new bool[] {false} ;
         T001B4_A433ProveedorEmail = new string[] {""} ;
         T001B4_n433ProveedorEmail = new bool[] {false} ;
         T001B4_A344ProveedorEstado = new string[] {""} ;
         T001B4_A682ProveedorRazonSocial = new string[] {""} ;
         T001B4_n682ProveedorRazonSocial = new bool[] {false} ;
         T001B4_A683ProveedorContacto = new string[] {""} ;
         T001B4_n683ProveedorContacto = new bool[] {false} ;
         T001B4_A684ProveedorContactoCell = new string[] {""} ;
         T001B4_n684ProveedorContactoCell = new bool[] {false} ;
         T001B4_A40000ProveedorImagen_GXI = new string[] {""} ;
         T001B4_n40000ProveedorImagen_GXI = new bool[] {false} ;
         T001B4_A687ProveedorCuentaBancaria = new string[] {""} ;
         T001B4_n687ProveedorCuentaBancaria = new bool[] {false} ;
         T001B4_A978ProveedorCIU = new bool[] {false} ;
         T001B4_A151ProveedoresTipoId = new long[1] ;
         T001B4_A673BancoId = new long[1] ;
         T001B4_n673BancoId = new bool[] {false} ;
         T001B4_A432ProveedorImagen = new string[] {""} ;
         T001B4_n432ProveedorImagen = new bool[] {false} ;
         T001B14_A133ProveedorID = new long[1] ;
         T001B14_n133ProveedorID = new bool[] {false} ;
         T001B18_A674BancoNombre = new string[] {""} ;
         T001B19_A278ProveedoresTipoNombre = new string[] {""} ;
         T001B20_A422PostulacionesId = new long[1] ;
         T001B21_A918MapeoID = new long[1] ;
         T001B22_A918MapeoID = new long[1] ;
         T001B23_A491VincularTrnId = new long[1] ;
         T001B24_A450ProfComisionesID = new long[1] ;
         T001B24_A452ProfComisionesRubrosId = new long[1] ;
         T001B25_A127SolicitudesID = new long[1] ;
         T001B26_A127SolicitudesID = new long[1] ;
         T001B27_A133ProveedorID = new long[1] ;
         T001B27_n133ProveedorID = new bool[] {false} ;
         T001B27_A713ComercioProductosRubrosID = new long[1] ;
         T001B28_A590Listaid = new long[1] ;
         T001B28_A133ProveedorID = new long[1] ;
         T001B28_n133ProveedorID = new bool[] {false} ;
         T001B28_A120ProfesionalesId = new string[] {""} ;
         T001B29_A590Listaid = new long[1] ;
         T001B29_A18SecUserId = new long[1] ;
         T001B29_A133ProveedorID = new long[1] ;
         T001B29_n133ProveedorID = new bool[] {false} ;
         T001B30_A503ComisionesID = new long[1] ;
         T001B30_A133ProveedorID = new long[1] ;
         T001B30_n133ProveedorID = new bool[] {false} ;
         T001B31_A133ProveedorID = new long[1] ;
         T001B31_n133ProveedorID = new bool[] {false} ;
         T001B31_A157ProveedorComisionID = new long[1] ;
         T001B32_A133ProveedorID = new long[1] ;
         T001B32_n133ProveedorID = new bool[] {false} ;
         T001B33_A133ProveedorID = new long[1] ;
         T001B33_n133ProveedorID = new bool[] {false} ;
         T001B33_A152ProveedorSolicitudesId = new long[1] ;
         T001B33_A337ProveedorSolicitudesNombre = new string[] {""} ;
         T001B33_A280ProveedorSolicitudesFecha = new DateTime[] {DateTime.MinValue} ;
         T001B33_n280ProveedorSolicitudesFecha = new bool[] {false} ;
         T001B34_A133ProveedorID = new long[1] ;
         T001B34_n133ProveedorID = new bool[] {false} ;
         T001B34_A152ProveedorSolicitudesId = new long[1] ;
         T001B3_A133ProveedorID = new long[1] ;
         T001B3_n133ProveedorID = new bool[] {false} ;
         T001B3_A152ProveedorSolicitudesId = new long[1] ;
         T001B3_A337ProveedorSolicitudesNombre = new string[] {""} ;
         T001B3_A280ProveedorSolicitudesFecha = new DateTime[] {DateTime.MinValue} ;
         T001B3_n280ProveedorSolicitudesFecha = new bool[] {false} ;
         T001B2_A133ProveedorID = new long[1] ;
         T001B2_n133ProveedorID = new bool[] {false} ;
         T001B2_A152ProveedorSolicitudesId = new long[1] ;
         T001B2_A337ProveedorSolicitudesNombre = new string[] {""} ;
         T001B2_A280ProveedorSolicitudesFecha = new DateTime[] {DateTime.MinValue} ;
         T001B2_n280ProveedorSolicitudesFecha = new bool[] {false} ;
         T001B38_A133ProveedorID = new long[1] ;
         T001B38_n133ProveedorID = new bool[] {false} ;
         T001B38_A152ProveedorSolicitudesId = new long[1] ;
         Gridlevel_solicitudesRow = new GXWebRow();
         subGridlevel_solicitudes_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         Gridlevel_solicitudesColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.comercio__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comercio__default(),
            new Object[][] {
                new Object[] {
               T001B2_A133ProveedorID, T001B2_A152ProveedorSolicitudesId, T001B2_A337ProveedorSolicitudesNombre, T001B2_A280ProveedorSolicitudesFecha, T001B2_n280ProveedorSolicitudesFecha
               }
               , new Object[] {
               T001B3_A133ProveedorID, T001B3_A152ProveedorSolicitudesId, T001B3_A337ProveedorSolicitudesNombre, T001B3_A280ProveedorSolicitudesFecha, T001B3_n280ProveedorSolicitudesFecha
               }
               , new Object[] {
               T001B4_A133ProveedorID, T001B4_A282ProveedorNombre, T001B4_A338ProveedorDocIdentidad, T001B4_A430ProveedorTelefono, T001B4_n430ProveedorTelefono, T001B4_A431ProveedorDireccion, T001B4_n431ProveedorDireccion, T001B4_A433ProveedorEmail, T001B4_n433ProveedorEmail, T001B4_A344ProveedorEstado,
               T001B4_A682ProveedorRazonSocial, T001B4_n682ProveedorRazonSocial, T001B4_A683ProveedorContacto, T001B4_n683ProveedorContacto, T001B4_A684ProveedorContactoCell, T001B4_n684ProveedorContactoCell, T001B4_A40000ProveedorImagen_GXI, T001B4_n40000ProveedorImagen_GXI, T001B4_A687ProveedorCuentaBancaria, T001B4_n687ProveedorCuentaBancaria,
               T001B4_A978ProveedorCIU, T001B4_A151ProveedoresTipoId, T001B4_A673BancoId, T001B4_n673BancoId, T001B4_A432ProveedorImagen, T001B4_n432ProveedorImagen
               }
               , new Object[] {
               T001B5_A133ProveedorID, T001B5_A282ProveedorNombre, T001B5_A338ProveedorDocIdentidad, T001B5_A430ProveedorTelefono, T001B5_n430ProveedorTelefono, T001B5_A431ProveedorDireccion, T001B5_n431ProveedorDireccion, T001B5_A433ProveedorEmail, T001B5_n433ProveedorEmail, T001B5_A344ProveedorEstado,
               T001B5_A682ProveedorRazonSocial, T001B5_n682ProveedorRazonSocial, T001B5_A683ProveedorContacto, T001B5_n683ProveedorContacto, T001B5_A684ProveedorContactoCell, T001B5_n684ProveedorContactoCell, T001B5_A40000ProveedorImagen_GXI, T001B5_n40000ProveedorImagen_GXI, T001B5_A687ProveedorCuentaBancaria, T001B5_n687ProveedorCuentaBancaria,
               T001B5_A978ProveedorCIU, T001B5_A151ProveedoresTipoId, T001B5_A673BancoId, T001B5_n673BancoId, T001B5_A432ProveedorImagen, T001B5_n432ProveedorImagen
               }
               , new Object[] {
               T001B6_A278ProveedoresTipoNombre
               }
               , new Object[] {
               T001B7_A674BancoNombre
               }
               , new Object[] {
               T001B8_A133ProveedorID, T001B8_A278ProveedoresTipoNombre, T001B8_A282ProveedorNombre, T001B8_A338ProveedorDocIdentidad, T001B8_A430ProveedorTelefono, T001B8_n430ProveedorTelefono, T001B8_A431ProveedorDireccion, T001B8_n431ProveedorDireccion, T001B8_A433ProveedorEmail, T001B8_n433ProveedorEmail,
               T001B8_A344ProveedorEstado, T001B8_A682ProveedorRazonSocial, T001B8_n682ProveedorRazonSocial, T001B8_A683ProveedorContacto, T001B8_n683ProveedorContacto, T001B8_A684ProveedorContactoCell, T001B8_n684ProveedorContactoCell, T001B8_A40000ProveedorImagen_GXI, T001B8_n40000ProveedorImagen_GXI, T001B8_A687ProveedorCuentaBancaria,
               T001B8_n687ProveedorCuentaBancaria, T001B8_A674BancoNombre, T001B8_A978ProveedorCIU, T001B8_A151ProveedoresTipoId, T001B8_A673BancoId, T001B8_n673BancoId, T001B8_A432ProveedorImagen, T001B8_n432ProveedorImagen
               }
               , new Object[] {
               T001B9_A674BancoNombre
               }
               , new Object[] {
               T001B10_A278ProveedoresTipoNombre
               }
               , new Object[] {
               T001B11_A133ProveedorID
               }
               , new Object[] {
               T001B12_A133ProveedorID
               }
               , new Object[] {
               T001B13_A133ProveedorID
               }
               , new Object[] {
               T001B14_A133ProveedorID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001B18_A674BancoNombre
               }
               , new Object[] {
               T001B19_A278ProveedoresTipoNombre
               }
               , new Object[] {
               T001B20_A422PostulacionesId
               }
               , new Object[] {
               T001B21_A918MapeoID
               }
               , new Object[] {
               T001B22_A918MapeoID
               }
               , new Object[] {
               T001B23_A491VincularTrnId
               }
               , new Object[] {
               T001B24_A450ProfComisionesID, T001B24_A452ProfComisionesRubrosId
               }
               , new Object[] {
               T001B25_A127SolicitudesID
               }
               , new Object[] {
               T001B26_A127SolicitudesID
               }
               , new Object[] {
               T001B27_A133ProveedorID, T001B27_A713ComercioProductosRubrosID
               }
               , new Object[] {
               T001B28_A590Listaid, T001B28_A133ProveedorID, T001B28_A120ProfesionalesId
               }
               , new Object[] {
               T001B29_A590Listaid, T001B29_A18SecUserId, T001B29_A133ProveedorID
               }
               , new Object[] {
               T001B30_A503ComisionesID, T001B30_A133ProveedorID
               }
               , new Object[] {
               T001B31_A133ProveedorID, T001B31_A157ProveedorComisionID
               }
               , new Object[] {
               T001B32_A133ProveedorID
               }
               , new Object[] {
               T001B33_A133ProveedorID, T001B33_A152ProveedorSolicitudesId, T001B33_A337ProveedorSolicitudesNombre, T001B33_A280ProveedorSolicitudesFecha, T001B33_n280ProveedorSolicitudesFecha
               }
               , new Object[] {
               T001B34_A133ProveedorID, T001B34_A152ProveedorSolicitudesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001B38_A133ProveedorID, T001B38_A152ProveedorSolicitudesId
               }
            }
         );
         Z978ProveedorCIU = false;
         A978ProveedorCIU = false;
         i978ProveedorCIU = false;
         AV22Pgmname = "Comercio";
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
      private short subGridlevel_solicitudes_Backcolorstyle ;
      private short subGridlevel_solicitudes_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_solicitudes_Allowselection ;
      private short subGridlevel_solicitudes_Allowhovering ;
      private short subGridlevel_solicitudes_Allowcollapsing ;
      private short subGridlevel_solicitudes_Collapsed ;
      private int nRC_GXsfl_99 ;
      private int nGXsfl_99_idx=1 ;
      private int trnEnded ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int edtProveedorID_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtProveedorRazonSocial_Enabled ;
      private int edtProveedorTelefono_Enabled ;
      private int edtProveedorDireccion_Enabled ;
      private int edtProveedorEmail_Enabled ;
      private int edtProveedorContacto_Enabled ;
      private int edtProveedorContactoCell_Enabled ;
      private int imgProveedorImagen_Enabled ;
      private int edtProveedorCuentaBancaria_Enabled ;
      private int edtBancoId_Visible ;
      private int edtBancoId_Enabled ;
      private int imgprompt_673_Visible ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombobancoid_Enabled ;
      private int edtavCombobancoid_Visible ;
      private int edtProveedoresTipoId_Enabled ;
      private int edtProveedoresTipoId_Visible ;
      private int edtProveedoresTipoNombre_Visible ;
      private int edtProveedoresTipoNombre_Enabled ;
      private int edtProveedorDocIdentidad_Visible ;
      private int edtProveedorDocIdentidad_Enabled ;
      private int edtProveedorSolicitudesId_Enabled ;
      private int edtProveedorSolicitudesNombre_Enabled ;
      private int edtProveedorSolicitudesFecha_Enabled ;
      private int fRowAdded ;
      private int Combo_bancoid_Datalistupdateminimumcharacters ;
      private int Combo_bancoid_Gxcontroltype ;
      private int Gxuitabspanel_tabs_Activepage ;
      private int AV23GXV1 ;
      private int subGridlevel_solicitudes_Backcolor ;
      private int subGridlevel_solicitudes_Allbackcolor ;
      private int defedtProveedorSolicitudesFecha_Enabled ;
      private int defedtProveedorSolicitudesNombre_Enabled ;
      private int defedtProveedorSolicitudesId_Enabled ;
      private int idxLst ;
      private int subGridlevel_solicitudes_Selectedindex ;
      private int subGridlevel_solicitudes_Selectioncolor ;
      private int subGridlevel_solicitudes_Hoveringcolor ;
      private long wcpOAV15ProveedorID ;
      private long Z133ProveedorID ;
      private long Z151ProveedoresTipoId ;
      private long Z673BancoId ;
      private long N673BancoId ;
      private long Z152ProveedorSolicitudesId ;
      private long A673BancoId ;
      private long A151ProveedoresTipoId ;
      private long AV15ProveedorID ;
      private long A133ProveedorID ;
      private long AV21ComboBancoId ;
      private long AV10Insert_ProveedoresTipoId ;
      private long AV18Insert_BancoId ;
      private long GRIDLEVEL_SOLICITUDES_nFirstRecordOnPage ;
      private long A152ProveedorSolicitudesId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z282ProveedorNombre ;
      private string Z338ProveedorDocIdentidad ;
      private string Z430ProveedorTelefono ;
      private string Z344ProveedorEstado ;
      private string Z682ProveedorRazonSocial ;
      private string Z683ProveedorContacto ;
      private string Z684ProveedorContactoCell ;
      private string Z687ProveedorCuentaBancaria ;
      private string Combo_bancoid_Selectedvalue_get ;
      private string Z337ProveedorSolicitudesNombre ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProveedorRazonSocial_Internalname ;
      private string sGXsfl_99_idx="0001" ;
      private string A344ProveedorEstado ;
      private string cmbProveedorEstado_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Gxuitabspanel_tabs_Class ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblTabgeneral_title_Internalname ;
      private string lblTabgeneral_title_Jsonclick ;
      private string divTableattributes_Internalname ;
      private string divB1_Internalname ;
      private string edtProveedorID_Internalname ;
      private string TempTags ;
      private string edtProveedorID_Jsonclick ;
      private string edtProveedorNombre_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Jsonclick ;
      private string A682ProveedorRazonSocial ;
      private string edtProveedorRazonSocial_Jsonclick ;
      private string edtProveedorTelefono_Internalname ;
      private string gxphoneLink ;
      private string A430ProveedorTelefono ;
      private string edtProveedorTelefono_Jsonclick ;
      private string edtProveedorDireccion_Internalname ;
      private string edtProveedorEmail_Internalname ;
      private string edtProveedorEmail_Jsonclick ;
      private string edtProveedorContacto_Internalname ;
      private string A683ProveedorContacto ;
      private string edtProveedorContacto_Jsonclick ;
      private string edtProveedorContactoCell_Internalname ;
      private string A684ProveedorContactoCell ;
      private string edtProveedorContactoCell_Jsonclick ;
      private string divB2_Internalname ;
      private string cmbProveedorEstado_Jsonclick ;
      private string imgProveedorImagen_Internalname ;
      private string sImgUrl ;
      private string edtProveedorCuentaBancaria_Internalname ;
      private string A687ProveedorCuentaBancaria ;
      private string edtProveedorCuentaBancaria_Jsonclick ;
      private string divTablesplittedbancoid_Internalname ;
      private string lblTextblockbancoid_Internalname ;
      private string lblTextblockbancoid_Jsonclick ;
      private string Combo_bancoid_Caption ;
      private string Combo_bancoid_Cls ;
      private string Combo_bancoid_Internalname ;
      private string edtBancoId_Internalname ;
      private string edtBancoId_Jsonclick ;
      private string imgprompt_673_gximage ;
      private string imgprompt_673_Internalname ;
      private string imgprompt_673_Link ;
      private string lblTablevel_solicitudes_title_Internalname ;
      private string lblTablevel_solicitudes_title_Jsonclick ;
      private string divTabtablelevel_solicitudes_Internalname ;
      private string divTableleaflevel_solicitudes_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_bancoid_Internalname ;
      private string edtavCombobancoid_Internalname ;
      private string edtavCombobancoid_Jsonclick ;
      private string edtProveedoresTipoId_Internalname ;
      private string edtProveedoresTipoId_Jsonclick ;
      private string edtProveedoresTipoNombre_Internalname ;
      private string A278ProveedoresTipoNombre ;
      private string edtProveedoresTipoNombre_Jsonclick ;
      private string edtProveedorDocIdentidad_Internalname ;
      private string A338ProveedorDocIdentidad ;
      private string edtProveedorDocIdentidad_Jsonclick ;
      private string sMode52 ;
      private string edtProveedorSolicitudesId_Internalname ;
      private string edtProveedorSolicitudesNombre_Internalname ;
      private string edtProveedorSolicitudesFecha_Internalname ;
      private string sStyleString ;
      private string subGridlevel_solicitudes_Internalname ;
      private string A674BancoNombre ;
      private string AV22Pgmname ;
      private string Combo_bancoid_Objectcall ;
      private string Combo_bancoid_Class ;
      private string Combo_bancoid_Icontype ;
      private string Combo_bancoid_Icon ;
      private string Combo_bancoid_Tooltip ;
      private string Combo_bancoid_Selectedvalue_set ;
      private string Combo_bancoid_Selectedtext_set ;
      private string Combo_bancoid_Selectedtext_get ;
      private string Combo_bancoid_Gamoauthtoken ;
      private string Combo_bancoid_Ddointernalname ;
      private string Combo_bancoid_Titlecontrolalign ;
      private string Combo_bancoid_Dropdownoptionstype ;
      private string Combo_bancoid_Titlecontrolidtoreplace ;
      private string Combo_bancoid_Datalisttype ;
      private string Combo_bancoid_Datalistfixedvalues ;
      private string Combo_bancoid_Datalistproc ;
      private string Combo_bancoid_Datalistprocparametersprefix ;
      private string Combo_bancoid_Remoteservicesparameters ;
      private string Combo_bancoid_Htmltemplate ;
      private string Combo_bancoid_Multiplevaluestype ;
      private string Combo_bancoid_Loadingdata ;
      private string Combo_bancoid_Noresultsfound ;
      private string Combo_bancoid_Emptyitemtext ;
      private string Combo_bancoid_Onlyselectedvalues ;
      private string Combo_bancoid_Selectalltext ;
      private string Combo_bancoid_Multiplevaluesseparator ;
      private string Combo_bancoid_Addnewoptiontext ;
      private string Gxuitabspanel_tabs_Objectcall ;
      private string Gxuitabspanel_tabs_Activepagecontrolname ;
      private string hsh ;
      private string sMode28 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A337ProveedorSolicitudesNombre ;
      private string GXEncryptionTmp ;
      private string Z278ProveedoresTipoNombre ;
      private string Z674BancoNombre ;
      private string sGXsfl_99_fel_idx="0001" ;
      private string subGridlevel_solicitudes_Class ;
      private string subGridlevel_solicitudes_Linesclass ;
      private string ROClassString ;
      private string edtProveedorSolicitudesId_Jsonclick ;
      private string edtProveedorSolicitudesNombre_Jsonclick ;
      private string edtProveedorSolicitudesFecha_Jsonclick ;
      private string GXCCtl ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string subGridlevel_solicitudes_Header ;
      private DateTime Z280ProveedorSolicitudesFecha ;
      private DateTime A280ProveedorSolicitudesFecha ;
      private bool Z978ProveedorCIU ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n673BancoId ;
      private bool wbErr ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool A432ProveedorImagen_IsBlob ;
      private bool Combo_bancoid_Emptyitem ;
      private bool bGXsfl_99_Refreshing=false ;
      private bool n430ProveedorTelefono ;
      private bool n431ProveedorDireccion ;
      private bool n433ProveedorEmail ;
      private bool n682ProveedorRazonSocial ;
      private bool n683ProveedorContacto ;
      private bool n684ProveedorContactoCell ;
      private bool n687ProveedorCuentaBancaria ;
      private bool A978ProveedorCIU ;
      private bool n40000ProveedorImagen_GXI ;
      private bool Combo_bancoid_Enabled ;
      private bool Combo_bancoid_Visible ;
      private bool Combo_bancoid_Allowmultipleselection ;
      private bool Combo_bancoid_Isgriditem ;
      private bool Combo_bancoid_Hasdescription ;
      private bool Combo_bancoid_Includeonlyselectedoption ;
      private bool Combo_bancoid_Includeselectalloption ;
      private bool Combo_bancoid_Includeaddnewoption ;
      private bool Gxuitabspanel_tabs_Enabled ;
      private bool Gxuitabspanel_tabs_Visible ;
      private bool n133ProveedorID ;
      private bool n432ProveedorImagen ;
      private bool returnInSub ;
      private bool AV7IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private bool n280ProveedorSolicitudesFecha ;
      private bool i978ProveedorCIU ;
      private string Z431ProveedorDireccion ;
      private string Z433ProveedorEmail ;
      private string A431ProveedorDireccion ;
      private string A433ProveedorEmail ;
      private string A40000ProveedorImagen_GXI ;
      private string AV20ComboSelectedValue ;
      private string Z40000ProveedorImagen_GXI ;
      private string A432ProveedorImagen ;
      private string Z432ProveedorImagen ;
      private IGxSession AV9WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_solicitudesContainer ;
      private GXWebRow Gridlevel_solicitudesRow ;
      private GXWebColumn Gridlevel_solicitudesColumn ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private GXUserControl ucCombo_bancoid ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbProveedorEstado ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV19BancoId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV16WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item2 ;
      private IDataStoreProvider pr_default ;
      private string[] T001B6_A278ProveedoresTipoNombre ;
      private string[] T001B7_A674BancoNombre ;
      private long[] T001B8_A133ProveedorID ;
      private bool[] T001B8_n133ProveedorID ;
      private string[] T001B8_A278ProveedoresTipoNombre ;
      private string[] T001B8_A282ProveedorNombre ;
      private string[] T001B8_A338ProveedorDocIdentidad ;
      private string[] T001B8_A430ProveedorTelefono ;
      private bool[] T001B8_n430ProveedorTelefono ;
      private string[] T001B8_A431ProveedorDireccion ;
      private bool[] T001B8_n431ProveedorDireccion ;
      private string[] T001B8_A433ProveedorEmail ;
      private bool[] T001B8_n433ProveedorEmail ;
      private string[] T001B8_A344ProveedorEstado ;
      private string[] T001B8_A682ProveedorRazonSocial ;
      private bool[] T001B8_n682ProveedorRazonSocial ;
      private string[] T001B8_A683ProveedorContacto ;
      private bool[] T001B8_n683ProveedorContacto ;
      private string[] T001B8_A684ProveedorContactoCell ;
      private bool[] T001B8_n684ProveedorContactoCell ;
      private string[] T001B8_A40000ProveedorImagen_GXI ;
      private bool[] T001B8_n40000ProveedorImagen_GXI ;
      private string[] T001B8_A687ProveedorCuentaBancaria ;
      private bool[] T001B8_n687ProveedorCuentaBancaria ;
      private string[] T001B8_A674BancoNombre ;
      private bool[] T001B8_A978ProveedorCIU ;
      private long[] T001B8_A151ProveedoresTipoId ;
      private long[] T001B8_A673BancoId ;
      private bool[] T001B8_n673BancoId ;
      private string[] T001B8_A432ProveedorImagen ;
      private bool[] T001B8_n432ProveedorImagen ;
      private string[] T001B9_A674BancoNombre ;
      private string[] T001B10_A278ProveedoresTipoNombre ;
      private long[] T001B11_A133ProveedorID ;
      private bool[] T001B11_n133ProveedorID ;
      private long[] T001B5_A133ProveedorID ;
      private bool[] T001B5_n133ProveedorID ;
      private string[] T001B5_A282ProveedorNombre ;
      private string[] T001B5_A338ProveedorDocIdentidad ;
      private string[] T001B5_A430ProveedorTelefono ;
      private bool[] T001B5_n430ProveedorTelefono ;
      private string[] T001B5_A431ProveedorDireccion ;
      private bool[] T001B5_n431ProveedorDireccion ;
      private string[] T001B5_A433ProveedorEmail ;
      private bool[] T001B5_n433ProveedorEmail ;
      private string[] T001B5_A344ProveedorEstado ;
      private string[] T001B5_A682ProveedorRazonSocial ;
      private bool[] T001B5_n682ProveedorRazonSocial ;
      private string[] T001B5_A683ProveedorContacto ;
      private bool[] T001B5_n683ProveedorContacto ;
      private string[] T001B5_A684ProveedorContactoCell ;
      private bool[] T001B5_n684ProveedorContactoCell ;
      private string[] T001B5_A40000ProveedorImagen_GXI ;
      private bool[] T001B5_n40000ProveedorImagen_GXI ;
      private string[] T001B5_A687ProveedorCuentaBancaria ;
      private bool[] T001B5_n687ProveedorCuentaBancaria ;
      private bool[] T001B5_A978ProveedorCIU ;
      private long[] T001B5_A151ProveedoresTipoId ;
      private long[] T001B5_A673BancoId ;
      private bool[] T001B5_n673BancoId ;
      private string[] T001B5_A432ProveedorImagen ;
      private bool[] T001B5_n432ProveedorImagen ;
      private long[] T001B12_A133ProveedorID ;
      private bool[] T001B12_n133ProveedorID ;
      private long[] T001B13_A133ProveedorID ;
      private bool[] T001B13_n133ProveedorID ;
      private long[] T001B4_A133ProveedorID ;
      private bool[] T001B4_n133ProveedorID ;
      private string[] T001B4_A282ProveedorNombre ;
      private string[] T001B4_A338ProveedorDocIdentidad ;
      private string[] T001B4_A430ProveedorTelefono ;
      private bool[] T001B4_n430ProveedorTelefono ;
      private string[] T001B4_A431ProveedorDireccion ;
      private bool[] T001B4_n431ProveedorDireccion ;
      private string[] T001B4_A433ProveedorEmail ;
      private bool[] T001B4_n433ProveedorEmail ;
      private string[] T001B4_A344ProveedorEstado ;
      private string[] T001B4_A682ProveedorRazonSocial ;
      private bool[] T001B4_n682ProveedorRazonSocial ;
      private string[] T001B4_A683ProveedorContacto ;
      private bool[] T001B4_n683ProveedorContacto ;
      private string[] T001B4_A684ProveedorContactoCell ;
      private bool[] T001B4_n684ProveedorContactoCell ;
      private string[] T001B4_A40000ProveedorImagen_GXI ;
      private bool[] T001B4_n40000ProveedorImagen_GXI ;
      private string[] T001B4_A687ProveedorCuentaBancaria ;
      private bool[] T001B4_n687ProveedorCuentaBancaria ;
      private bool[] T001B4_A978ProveedorCIU ;
      private long[] T001B4_A151ProveedoresTipoId ;
      private long[] T001B4_A673BancoId ;
      private bool[] T001B4_n673BancoId ;
      private string[] T001B4_A432ProveedorImagen ;
      private bool[] T001B4_n432ProveedorImagen ;
      private long[] T001B14_A133ProveedorID ;
      private bool[] T001B14_n133ProveedorID ;
      private string[] T001B18_A674BancoNombre ;
      private string[] T001B19_A278ProveedoresTipoNombre ;
      private long[] T001B20_A422PostulacionesId ;
      private long[] T001B21_A918MapeoID ;
      private long[] T001B22_A918MapeoID ;
      private long[] T001B23_A491VincularTrnId ;
      private long[] T001B24_A450ProfComisionesID ;
      private long[] T001B24_A452ProfComisionesRubrosId ;
      private long[] T001B25_A127SolicitudesID ;
      private long[] T001B26_A127SolicitudesID ;
      private long[] T001B27_A133ProveedorID ;
      private bool[] T001B27_n133ProveedorID ;
      private long[] T001B27_A713ComercioProductosRubrosID ;
      private long[] T001B28_A590Listaid ;
      private long[] T001B28_A133ProveedorID ;
      private bool[] T001B28_n133ProveedorID ;
      private string[] T001B28_A120ProfesionalesId ;
      private long[] T001B29_A590Listaid ;
      private long[] T001B29_A18SecUserId ;
      private long[] T001B29_A133ProveedorID ;
      private bool[] T001B29_n133ProveedorID ;
      private long[] T001B30_A503ComisionesID ;
      private long[] T001B30_A133ProveedorID ;
      private bool[] T001B30_n133ProveedorID ;
      private long[] T001B31_A133ProveedorID ;
      private bool[] T001B31_n133ProveedorID ;
      private long[] T001B31_A157ProveedorComisionID ;
      private long[] T001B32_A133ProveedorID ;
      private bool[] T001B32_n133ProveedorID ;
      private long[] T001B33_A133ProveedorID ;
      private bool[] T001B33_n133ProveedorID ;
      private long[] T001B33_A152ProveedorSolicitudesId ;
      private string[] T001B33_A337ProveedorSolicitudesNombre ;
      private DateTime[] T001B33_A280ProveedorSolicitudesFecha ;
      private bool[] T001B33_n280ProveedorSolicitudesFecha ;
      private long[] T001B34_A133ProveedorID ;
      private bool[] T001B34_n133ProveedorID ;
      private long[] T001B34_A152ProveedorSolicitudesId ;
      private long[] T001B3_A133ProveedorID ;
      private bool[] T001B3_n133ProveedorID ;
      private long[] T001B3_A152ProveedorSolicitudesId ;
      private string[] T001B3_A337ProveedorSolicitudesNombre ;
      private DateTime[] T001B3_A280ProveedorSolicitudesFecha ;
      private bool[] T001B3_n280ProveedorSolicitudesFecha ;
      private long[] T001B2_A133ProveedorID ;
      private bool[] T001B2_n133ProveedorID ;
      private long[] T001B2_A152ProveedorSolicitudesId ;
      private string[] T001B2_A337ProveedorSolicitudesNombre ;
      private DateTime[] T001B2_A280ProveedorSolicitudesFecha ;
      private bool[] T001B2_n280ProveedorSolicitudesFecha ;
      private long[] T001B38_A133ProveedorID ;
      private bool[] T001B38_n133ProveedorID ;
      private long[] T001B38_A152ProveedorSolicitudesId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class comercio__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class comercio__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
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
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new UpdateCursor(def[33])
       ,new UpdateCursor(def[34])
       ,new UpdateCursor(def[35])
       ,new ForEachCursor(def[36])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001B2;
        prmT001B2 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT001B3;
        prmT001B3 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT001B4;
        prmT001B4 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B5;
        prmT001B5 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B6;
        prmT001B6 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT001B7;
        prmT001B7 = new Object[] {
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B8;
        prmT001B8 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B9;
        prmT001B9 = new Object[] {
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B10;
        prmT001B10 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT001B11;
        prmT001B11 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B12;
        prmT001B12 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B13;
        prmT001B13 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B14;
        prmT001B14 = new Object[] {
        new ParDef("@ProveedorNombre",GXType.NChar,80,0) ,
        new ParDef("@ProveedorDocIdentidad",GXType.NChar,25,0) ,
        new ParDef("@ProveedorTelefono",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorDireccion",GXType.NVarChar,1024,0){Nullable=true} ,
        new ParDef("@ProveedorEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProveedorEstado",GXType.NChar,3,0) ,
        new ParDef("@ProveedorRazonSocial",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@ProveedorContacto",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ProveedorContactoCell",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ProveedorImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=9, Tbl="Proveedor", Fld="ProveedorImagen"} ,
        new ParDef("@ProveedorCuentaBancaria",GXType.NChar,50,0){Nullable=true} ,
        new ParDef("@ProveedorCIU",GXType.Boolean,4,0) ,
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0) ,
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B15;
        prmT001B15 = new Object[] {
        new ParDef("@ProveedorNombre",GXType.NChar,80,0) ,
        new ParDef("@ProveedorDocIdentidad",GXType.NChar,25,0) ,
        new ParDef("@ProveedorTelefono",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorDireccion",GXType.NVarChar,1024,0){Nullable=true} ,
        new ParDef("@ProveedorEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProveedorEstado",GXType.NChar,3,0) ,
        new ParDef("@ProveedorRazonSocial",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@ProveedorContacto",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ProveedorContactoCell",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorCuentaBancaria",GXType.NChar,50,0){Nullable=true} ,
        new ParDef("@ProveedorCIU",GXType.Boolean,4,0) ,
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0) ,
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B16;
        prmT001B16 = new Object[] {
        new ParDef("@ProveedorImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ProveedorImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Proveedor", Fld="ProveedorImagen"} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B17;
        prmT001B17 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B18;
        prmT001B18 = new Object[] {
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B19;
        prmT001B19 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT001B20;
        prmT001B20 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B21;
        prmT001B21 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B22;
        prmT001B22 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B23;
        prmT001B23 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B24;
        prmT001B24 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B25;
        prmT001B25 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B26;
        prmT001B26 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B27;
        prmT001B27 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B28;
        prmT001B28 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B29;
        prmT001B29 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B30;
        prmT001B30 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B31;
        prmT001B31 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001B32;
        prmT001B32 = new Object[] {
        };
        Object[] prmT001B33;
        prmT001B33 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT001B34;
        prmT001B34 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT001B35;
        prmT001B35 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorSolicitudesNombre",GXType.NChar,120,0) ,
        new ParDef("@ProveedorSolicitudesFecha",GXType.Date,8,0){Nullable=true}
        };
        Object[] prmT001B36;
        prmT001B36 = new Object[] {
        new ParDef("@ProveedorSolicitudesNombre",GXType.NChar,120,0) ,
        new ParDef("@ProveedorSolicitudesFecha",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT001B37;
        prmT001B37 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT001B38;
        prmT001B38 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T001B2", "SELECT [ProveedorID], [ProveedorSolicitudesId], [ProveedorSolicitudesNombre], [ProveedorSolicitudesFecha] FROM [ProveedorSolicitudes] WITH (UPDLOCK) WHERE [ProveedorID] = @ProveedorID AND [ProveedorSolicitudesId] = @ProveedorSolicitudesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B3", "SELECT [ProveedorID], [ProveedorSolicitudesId], [ProveedorSolicitudesNombre], [ProveedorSolicitudesFecha] FROM [ProveedorSolicitudes] WHERE [ProveedorID] = @ProveedorID AND [ProveedorSolicitudesId] = @ProveedorSolicitudesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B4", "SELECT [ProveedorID], [ProveedorNombre], [ProveedorDocIdentidad], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorEstado], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorImagen_GXI], [ProveedorCuentaBancaria], [ProveedorCIU], [ProveedoresTipoId], [BancoId], [ProveedorImagen] FROM [Proveedor] WITH (UPDLOCK) WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B5", "SELECT [ProveedorID], [ProveedorNombre], [ProveedorDocIdentidad], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorEstado], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorImagen_GXI], [ProveedorCuentaBancaria], [ProveedorCIU], [ProveedoresTipoId], [BancoId], [ProveedorImagen] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B6", "SELECT [ProveedoresTipoNombre] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B7", "SELECT [BancoNombre] FROM [Banco] WHERE [BancoId] = @BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B8", "SELECT TM1.[ProveedorID], T2.[ProveedoresTipoNombre], TM1.[ProveedorNombre], TM1.[ProveedorDocIdentidad], TM1.[ProveedorTelefono], TM1.[ProveedorDireccion], TM1.[ProveedorEmail], TM1.[ProveedorEstado], TM1.[ProveedorRazonSocial], TM1.[ProveedorContacto], TM1.[ProveedorContactoCell], TM1.[ProveedorImagen_GXI], TM1.[ProveedorCuentaBancaria], T3.[BancoNombre], TM1.[ProveedorCIU], TM1.[ProveedoresTipoId], TM1.[BancoId], TM1.[ProveedorImagen] FROM (([Proveedor] TM1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = TM1.[ProveedoresTipoId]) LEFT JOIN [Banco] T3 ON T3.[BancoId] = TM1.[BancoId]) WHERE TM1.[ProveedorID] = @ProveedorID ORDER BY TM1.[ProveedorID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001B8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B9", "SELECT [BancoNombre] FROM [Banco] WHERE [BancoId] = @BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B10", "SELECT [ProveedoresTipoNombre] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B11", "SELECT [ProveedorID] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001B11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B12", "SELECT TOP 1 [ProveedorID] FROM [Proveedor] WHERE ( [ProveedorID] > @ProveedorID) ORDER BY [ProveedorID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001B12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B13", "SELECT TOP 1 [ProveedorID] FROM [Proveedor] WHERE ( [ProveedorID] < @ProveedorID) ORDER BY [ProveedorID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001B13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B14", "INSERT INTO [Proveedor]([ProveedorNombre], [ProveedorDocIdentidad], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorEstado], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorImagen], [ProveedorImagen_GXI], [ProveedorCuentaBancaria], [ProveedorCIU], [ProveedoresTipoId], [BancoId], [ProveedorSerialComi], [ProveedorPerAltShop], [ProveedorPagoDefault], [ProveedorPideDoc], [DocumentacionId], [ProveedorUsrAlta], [ProveedorUsrActualizacion], [ProveedorFechaAlta], [ProveedorFechaActualizacion], [ProveedorUsoInterno], [ProveedorSitioWeb], [ProveedorAceptoTerminos], [ComercioProductosREnum], [ProveedorFreezePrice]) VALUES(@ProveedorNombre, @ProveedorDocIdentidad, @ProveedorTelefono, @ProveedorDireccion, @ProveedorEmail, @ProveedorEstado, @ProveedorRazonSocial, @ProveedorContacto, @ProveedorContactoCell, @ProveedorImagen, @ProveedorImagen_GXI, @ProveedorCuentaBancaria, @ProveedorCIU, @ProveedoresTipoId, @BancoId, convert(int, 0), '', '', '', convert(int, 0), convert(int, 0), convert(int, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', convert( DATETIME, '17530101', 112 ), convert(int, 0), convert(bit, 0)); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001B14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B15", "UPDATE [Proveedor] SET [ProveedorNombre]=@ProveedorNombre, [ProveedorDocIdentidad]=@ProveedorDocIdentidad, [ProveedorTelefono]=@ProveedorTelefono, [ProveedorDireccion]=@ProveedorDireccion, [ProveedorEmail]=@ProveedorEmail, [ProveedorEstado]=@ProveedorEstado, [ProveedorRazonSocial]=@ProveedorRazonSocial, [ProveedorContacto]=@ProveedorContacto, [ProveedorContactoCell]=@ProveedorContactoCell, [ProveedorCuentaBancaria]=@ProveedorCuentaBancaria, [ProveedorCIU]=@ProveedorCIU, [ProveedoresTipoId]=@ProveedoresTipoId, [BancoId]=@BancoId  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT001B15)
           ,new CursorDef("T001B16", "UPDATE [Proveedor] SET [ProveedorImagen]=@ProveedorImagen, [ProveedorImagen_GXI]=@ProveedorImagen_GXI  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT001B16)
           ,new CursorDef("T001B17", "DELETE FROM [Proveedor]  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT001B17)
           ,new CursorDef("T001B18", "SELECT [BancoNombre] FROM [Banco] WHERE [BancoId] = @BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B19", "SELECT [ProveedoresTipoNombre] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B20", "SELECT TOP 1 [PostulacionesId] FROM [Postulaciones] WHERE [PostulacionesProveedorId] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B21", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE [STComerciosID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B22", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B23", "SELECT TOP 1 [VincularTrnId] FROM [VincularTrn] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B24", "SELECT TOP 1 [ProfComisionesID], [ProfComisionesRubrosId] FROM [ProfComisionesRubros] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B25", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [STComerciosID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B26", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B27", "SELECT TOP 1 [ProveedorID], [ComercioProductosRubrosID] FROM [ComercioProductosRubros] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B28", "SELECT TOP 1 [Listaid], [ProveedorID], [ProfesionalesId] FROM [ListaAgrupacion] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B29", "SELECT TOP 1 [Listaid], [SecUserId], [ProveedorID] FROM [ListaAgrUserProveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B30", "SELECT TOP 1 [ComisionesID], [ProveedorID] FROM [ComisionesProveedores] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B31", "SELECT TOP 1 [ProveedorID], [ProveedorComisionID] FROM [ProveedorComision] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B31,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B32", "SELECT [ProveedorID] FROM [Proveedor] ORDER BY [ProveedorID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001B32,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B33", "SELECT [ProveedorID], [ProveedorSolicitudesId], [ProveedorSolicitudesNombre], [ProveedorSolicitudesFecha] FROM [ProveedorSolicitudes] WHERE [ProveedorID] = @ProveedorID and [ProveedorSolicitudesId] = @ProveedorSolicitudesId ORDER BY [ProveedorID], [ProveedorSolicitudesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B33,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B34", "SELECT [ProveedorID], [ProveedorSolicitudesId] FROM [ProveedorSolicitudes] WHERE [ProveedorID] = @ProveedorID AND [ProveedorSolicitudesId] = @ProveedorSolicitudesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B34,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B35", "INSERT INTO [ProveedorSolicitudes]([ProveedorID], [ProveedorSolicitudesId], [ProveedorSolicitudesNombre], [ProveedorSolicitudesFecha]) VALUES(@ProveedorID, @ProveedorSolicitudesId, @ProveedorSolicitudesNombre, @ProveedorSolicitudesFecha)", GxErrorMask.GX_NOMASK,prmT001B35)
           ,new CursorDef("T001B36", "UPDATE [ProveedorSolicitudes] SET [ProveedorSolicitudesNombre]=@ProveedorSolicitudesNombre, [ProveedorSolicitudesFecha]=@ProveedorSolicitudesFecha  WHERE [ProveedorID] = @ProveedorID AND [ProveedorSolicitudesId] = @ProveedorSolicitudesId", GxErrorMask.GX_NOMASK,prmT001B36)
           ,new CursorDef("T001B37", "DELETE FROM [ProveedorSolicitudes]  WHERE [ProveedorID] = @ProveedorID AND [ProveedorSolicitudesId] = @ProveedorSolicitudesId", GxErrorMask.GX_NOMASK,prmT001B37)
           ,new CursorDef("T001B38", "SELECT [ProveedorID], [ProveedorSolicitudesId] FROM [ProveedorSolicitudes] WHERE [ProveedorID] = @ProveedorID ORDER BY [ProveedorID], [ProveedorSolicitudesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B38,11, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 25);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getString(7, 3);
              ((string[]) buf[10])[0] = rslt.getString(8, 25);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getString(9, 128);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getString(10, 20);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getMultimediaUri(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((string[]) buf[18])[0] = rslt.getString(12, 50);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((bool[]) buf[20])[0] = rslt.getBool(13);
              ((long[]) buf[21])[0] = rslt.getLong(14);
              ((long[]) buf[22])[0] = rslt.getLong(15);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(11));
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 25);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getString(7, 3);
              ((string[]) buf[10])[0] = rslt.getString(8, 25);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getString(9, 128);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getString(10, 20);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getMultimediaUri(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((string[]) buf[18])[0] = rslt.getString(12, 50);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((bool[]) buf[20])[0] = rslt.getBool(13);
              ((long[]) buf[21])[0] = rslt.getLong(14);
              ((long[]) buf[22])[0] = rslt.getLong(15);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(11));
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getString(4, 25);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 3);
              ((string[]) buf[11])[0] = rslt.getString(9, 25);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getString(10, 128);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getString(11, 20);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getMultimediaUri(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              ((string[]) buf[19])[0] = rslt.getString(13, 50);
              ((bool[]) buf[20])[0] = rslt.wasNull(13);
              ((string[]) buf[21])[0] = rslt.getString(14, 80);
              ((bool[]) buf[22])[0] = rslt.getBool(15);
              ((long[]) buf[23])[0] = rslt.getLong(16);
              ((long[]) buf[24])[0] = rslt.getLong(17);
              ((bool[]) buf[25])[0] = rslt.wasNull(17);
              ((string[]) buf[26])[0] = rslt.getMultimediaFile(18, rslt.getVarchar(12));
              ((bool[]) buf[27])[0] = rslt.wasNull(18);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
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
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
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
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 31 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 32 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 36 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
  }

}

}
