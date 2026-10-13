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
   public class operaciones : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "operaciones.aspx")), "operaciones.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "operaciones.aspx")))) ;
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
                  AV7OperacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "OperacionesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7OperacionesId", StringUtil.LTrimStr( (decimal)(AV7OperacionesId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vOPERACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7OperacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Operaciones", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtOperacionesId_Internalname;
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
         nRC_GXsfl_128 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_128"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_128_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_128_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_128_idx = GetPar( "sGXsfl_128_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_solicitudes_newrow( ) ;
         /* End function gxnrGridlevel_solicitudes_newrow_invoke */
      }

      public operaciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operaciones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_OperacionesId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7OperacionesId = aP1_OperacionesId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbOperacionesEstado = new GXCombobox();
         cmbOperacionesTipo = new GXCombobox();
         cmbOperacionesTipoES = new GXCombobox();
         cmbOperacionesSolicitudesOrigenPa = new GXCombobox();
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
         if ( cmbOperacionesEstado.ItemCount > 0 )
         {
            A577OperacionesEstado = cmbOperacionesEstado.getValidValue(A577OperacionesEstado);
            n577OperacionesEstado = false;
            AssignAttri("", false, "A577OperacionesEstado", A577OperacionesEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbOperacionesEstado.CurrentValue = StringUtil.RTrim( A577OperacionesEstado);
            AssignProp("", false, cmbOperacionesEstado_Internalname, "Values", cmbOperacionesEstado.ToJavascriptSource(), true);
         }
         if ( cmbOperacionesTipo.ItemCount > 0 )
         {
            A649OperacionesTipo = cmbOperacionesTipo.getValidValue(A649OperacionesTipo);
            n649OperacionesTipo = false;
            AssignAttri("", false, "A649OperacionesTipo", A649OperacionesTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbOperacionesTipo.CurrentValue = StringUtil.RTrim( A649OperacionesTipo);
            AssignProp("", false, cmbOperacionesTipo_Internalname, "Values", cmbOperacionesTipo.ToJavascriptSource(), true);
         }
         if ( cmbOperacionesTipoES.ItemCount > 0 )
         {
            A569OperacionesTipoES = cmbOperacionesTipoES.getValidValue(A569OperacionesTipoES);
            n569OperacionesTipoES = false;
            AssignAttri("", false, "A569OperacionesTipoES", A569OperacionesTipoES);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbOperacionesTipoES.CurrentValue = StringUtil.RTrim( A569OperacionesTipoES);
            AssignProp("", false, cmbOperacionesTipoES_Internalname, "Values", cmbOperacionesTipoES.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTabgeneral_title_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), "", "", lblTabgeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Operaciones.htm");
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
         GxWebStd.gx_div_start( context, divTb1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A554OperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A554OperacionesId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesRef_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesRef_Internalname, context.GetMessage( "Referencia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesRef_Internalname, StringUtil.RTrim( A555OperacionesRef), StringUtil.RTrim( context.localUtil.Format( A555OperacionesRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesRef_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesRef_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesNombreRef_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesNombreRef_Internalname, context.GetMessage( "Nombre de Referencia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesNombreRef_Internalname, StringUtil.RTrim( A657OperacionesNombreRef), StringUtil.RTrim( context.localUtil.Format( A657OperacionesNombreRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesNombreRef_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesNombreRef_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "NombreLargo", "start", true, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesFacturaCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesFacturaCod_Internalname, context.GetMessage( "Código de Facturación ", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesFacturaCod_Internalname, StringUtil.RTrim( A572OperacionesFacturaCod), StringUtil.RTrim( context.localUtil.Format( A572OperacionesFacturaCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesFacturaCod_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesFacturaCod_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesIva_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesIva_Internalname, context.GetMessage( "IVA", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesIva_Internalname, StringUtil.LTrim( StringUtil.NToC( A573OperacionesIva, 4, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtOperacionesIva_Enabled!=0) ? context.localUtil.Format( A573OperacionesIva, "9.99") : context.localUtil.Format( A573OperacionesIva, "9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesIva_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesIva_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Iva", "end", false, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesComision_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesComision_Internalname, context.GetMessage( "Comisión", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesComision_Internalname, StringUtil.LTrim( StringUtil.NToC( A574OperacionesComision, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtOperacionesComision_Enabled!=0) ? context.localUtil.Format( A574OperacionesComision, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A574OperacionesComision, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesComision_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesComision_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Comision", "end", false, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesImporteGrabado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesImporteGrabado_Internalname, context.GetMessage( "Importe Grabado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesImporteGrabado_Internalname, StringUtil.LTrim( StringUtil.NToC( A578OperacionesImporteGrabado, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtOperacionesImporteGrabado_Enabled!=0) ? context.localUtil.Format( A578OperacionesImporteGrabado, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A578OperacionesImporteGrabado, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesImporteGrabado_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesImporteGrabado_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesComprobantePago_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesComprobantePago_Internalname, context.GetMessage( "Nro. Comprobante de Pago", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtOperacionesComprobantePago_Internalname, StringUtil.RTrim( A580OperacionesComprobantePago), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", 0, 1, edtOperacionesComprobantePago_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "256", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Operaciones.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbOperacionesEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbOperacionesEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbOperacionesEstado, cmbOperacionesEstado_Internalname, StringUtil.RTrim( A577OperacionesEstado), 1, cmbOperacionesEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbOperacionesEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "", true, 0, "HLP_Operaciones.htm");
         cmbOperacionesEstado.CurrentValue = StringUtil.RTrim( A577OperacionesEstado);
         AssignProp("", false, cmbOperacionesEstado_Internalname, "Values", (string)(cmbOperacionesEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbOperacionesTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbOperacionesTipo_Internalname, context.GetMessage( "Operaciones Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbOperacionesTipo, cmbOperacionesTipo_Internalname, StringUtil.RTrim( A649OperacionesTipo), 1, cmbOperacionesTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbOperacionesTipo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "", true, 0, "HLP_Operaciones.htm");
         cmbOperacionesTipo.CurrentValue = StringUtil.RTrim( A649OperacionesTipo);
         AssignProp("", false, cmbOperacionesTipo_Internalname, "Values", (string)(cmbOperacionesTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbOperacionesTipoES_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbOperacionesTipoES_Internalname, context.GetMessage( "Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbOperacionesTipoES, cmbOperacionesTipoES_Internalname, StringUtil.RTrim( A569OperacionesTipoES), 1, cmbOperacionesTipoES_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbOperacionesTipoES.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "", true, 0, "HLP_Operaciones.htm");
         cmbOperacionesTipoES.CurrentValue = StringUtil.RTrim( A569OperacionesTipoES);
         AssignProp("", false, cmbOperacionesTipoES_Internalname, "Values", (string)(cmbOperacionesTipoES.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesMoneda_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesMoneda_Internalname, context.GetMessage( "Moneda", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesMoneda_Internalname, StringUtil.RTrim( A571OperacionesMoneda), StringUtil.RTrim( context.localUtil.Format( A571OperacionesMoneda, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesMoneda_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesMoneda_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "MonISO", "start", true, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesImporte_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesImporte_Internalname, context.GetMessage( "Importe", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A570OperacionesImporte, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtOperacionesImporte_Enabled!=0) ? context.localUtil.Format( A570OperacionesImporte, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A570OperacionesImporte, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesImporte_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesImporte_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_Operaciones.htm");
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
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Otros Datos", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Operaciones.htm");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblOtros_Internalname, tblOtros_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesUsrAlta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesUsrAlta_Internalname, context.GetMessage( "Usuario de Alta", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesUsrAlta_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A666OperacionesUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtOperacionesUsrAlta_Enabled!=0) ? context.localUtil.Format( (decimal)(A666OperacionesUsrAlta), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A666OperacionesUsrAlta), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesUsrAlta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesUsrAlta_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "UserID", "end", false, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesFechaAlta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesFechaAlta_Internalname, context.GetMessage( "Fecha de Alta", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOperacionesFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOperacionesFechaAlta_Internalname, context.localUtil.Format(A581OperacionesFechaAlta, "99/99/99"), context.localUtil.Format( A581OperacionesFechaAlta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesFechaAlta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesFechaAlta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operaciones.htm");
         GxWebStd.gx_bitmap( context, edtOperacionesFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOperacionesFechaAlta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Operaciones.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesFechaPago_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesFechaPago_Internalname, context.GetMessage( "Fecha de Pago", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOperacionesFechaPago_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOperacionesFechaPago_Internalname, context.localUtil.TToC( A582OperacionesFechaPago, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A582OperacionesFechaPago, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesFechaPago_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesFechaPago_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operaciones.htm");
         GxWebStd.gx_bitmap( context, edtOperacionesFechaPago_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOperacionesFechaPago_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Operaciones.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesFechaDesde_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesFechaDesde_Internalname, context.GetMessage( "Desde", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOperacionesFechaDesde_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOperacionesFechaDesde_Internalname, context.localUtil.Format(A658OperacionesFechaDesde, "99/99/99"), context.localUtil.Format( A658OperacionesFechaDesde, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesFechaDesde_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesFechaDesde_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operaciones.htm");
         GxWebStd.gx_bitmap( context, edtOperacionesFechaDesde_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOperacionesFechaDesde_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Operaciones.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesFechaHasta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesFechaHasta_Internalname, context.GetMessage( "Hasta", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOperacionesFechaHasta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOperacionesFechaHasta_Internalname, context.localUtil.Format(A659OperacionesFechaHasta, "99/99/99"), context.localUtil.Format( A659OperacionesFechaHasta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesFechaHasta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesFechaHasta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operaciones.htm");
         GxWebStd.gx_bitmap( context, edtOperacionesFechaHasta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOperacionesFechaHasta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Operaciones.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesUsrActualizacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesUsrActualizacion_Internalname, context.GetMessage( "Usuario de Actualización", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesUsrActualizacion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A667OperacionesUsrActualizacion), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtOperacionesUsrActualizacion_Enabled!=0) ? context.localUtil.Format( (decimal)(A667OperacionesUsrActualizacion), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A667OperacionesUsrActualizacion), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesUsrActualizacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesUsrActualizacion_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "UserID", "end", false, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</fieldset>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTablevel_solicitudes_title_Internalname, context.GetMessage( "Solicitudes", ""), "", "", lblTablevel_solicitudes_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Operaciones.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_solicitudes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_solicitudes( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTab1_title_Internalname, context.GetMessage( "DATA", ""), "", "", lblTab1_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Operaciones.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "Tab1") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesRequest_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesRequest_Internalname, context.GetMessage( "Request", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtOperacionesRequest_Internalname, A575OperacionesRequest, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"", 0, 1, edtOperacionesRequest_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesResponse_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesResponse_Internalname, context.GetMessage( "Response", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtOperacionesResponse_Internalname, A576OperacionesResponse, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,152);\"", 0, 1, edtOperacionesResponse_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesAux1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesAux1_Internalname, context.GetMessage( "Aux1", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesAux1_Internalname, A583OperacionesAux1, StringUtil.RTrim( context.localUtil.Format( A583OperacionesAux1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesAux1_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesAux1_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesAux2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesAux2_Internalname, context.GetMessage( "Aux2", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesAux2_Internalname, A584OperacionesAux2, StringUtil.RTrim( context.localUtil.Format( A584OperacionesAux2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,162);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesAux2_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacionesAux2_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesAux3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesAux3_Internalname, context.GetMessage( "Aux3", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtOperacionesAux3_Internalname, A585OperacionesAux3, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,167);\"", 0, 1, edtOperacionesAux3_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesBlob1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesBlob1_Internalname, context.GetMessage( "Archivo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         ClassString = "AttributeFL";
         StyleString = "";
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'',0)\"";
         edtOperacionesBlob1_Filetype = "tmp";
         AssignProp("", false, edtOperacionesBlob1_Internalname, "Filetype", edtOperacionesBlob1_Filetype, true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A663OperacionesBlob1)) )
         {
            gxblobfileaux.Source = A663OperacionesBlob1;
            if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtOperacionesBlob1_Filetype, "tmp") != 0 ) )
            {
               gxblobfileaux.SetExtension(StringUtil.Trim( edtOperacionesBlob1_Filetype));
            }
            if ( gxblobfileaux.ErrCode == 0 )
            {
               A663OperacionesBlob1 = gxblobfileaux.GetURI();
               n663OperacionesBlob1 = false;
               AssignAttri("", false, "A663OperacionesBlob1", A663OperacionesBlob1);
               AssignProp("", false, edtOperacionesBlob1_Internalname, "URL", context.PathToRelativeUrl( A663OperacionesBlob1), true);
               edtOperacionesBlob1_Filetype = gxblobfileaux.GetExtension();
               AssignProp("", false, edtOperacionesBlob1_Internalname, "Filetype", edtOperacionesBlob1_Filetype, true);
            }
            AssignProp("", false, edtOperacionesBlob1_Internalname, "URL", context.PathToRelativeUrl( A663OperacionesBlob1), true);
         }
         GxWebStd.gx_blob_field( context, edtOperacionesBlob1_Internalname, StringUtil.RTrim( A663OperacionesBlob1), context.PathToRelativeUrl( A663OperacionesBlob1), (String.IsNullOrEmpty(StringUtil.RTrim( edtOperacionesBlob1_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtOperacionesBlob1_Filetype)) ? A663OperacionesBlob1 : edtOperacionesBlob1_Filetype)) : edtOperacionesBlob1_Contenttype), false, "", edtOperacionesBlob1_Parameters, 0, edtOperacionesBlob1_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtOperacionesBlob1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,172);\"", "", "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacionesBlob2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacionesBlob2_Internalname, context.GetMessage( "Archivo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         ClassString = "AttributeFL";
         StyleString = "";
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'',0)\"";
         edtOperacionesBlob2_Filetype = "tmp";
         AssignProp("", false, edtOperacionesBlob2_Internalname, "Filetype", edtOperacionesBlob2_Filetype, true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A664OperacionesBlob2)) )
         {
            gxblobfileaux.Source = A664OperacionesBlob2;
            if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtOperacionesBlob2_Filetype, "tmp") != 0 ) )
            {
               gxblobfileaux.SetExtension(StringUtil.Trim( edtOperacionesBlob2_Filetype));
            }
            if ( gxblobfileaux.ErrCode == 0 )
            {
               A664OperacionesBlob2 = gxblobfileaux.GetURI();
               n664OperacionesBlob2 = false;
               AssignAttri("", false, "A664OperacionesBlob2", A664OperacionesBlob2);
               AssignProp("", false, edtOperacionesBlob2_Internalname, "URL", context.PathToRelativeUrl( A664OperacionesBlob2), true);
               edtOperacionesBlob2_Filetype = gxblobfileaux.GetExtension();
               AssignProp("", false, edtOperacionesBlob2_Internalname, "Filetype", edtOperacionesBlob2_Filetype, true);
            }
            AssignProp("", false, edtOperacionesBlob2_Internalname, "URL", context.PathToRelativeUrl( A664OperacionesBlob2), true);
         }
         GxWebStd.gx_blob_field( context, edtOperacionesBlob2_Internalname, StringUtil.RTrim( A664OperacionesBlob2), context.PathToRelativeUrl( A664OperacionesBlob2), (String.IsNullOrEmpty(StringUtil.RTrim( edtOperacionesBlob2_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtOperacionesBlob2_Filetype)) ? A664OperacionesBlob2 : edtOperacionesBlob2_Filetype)) : edtOperacionesBlob2_Contenttype), false, "", edtOperacionesBlob2_Parameters, 0, edtOperacionesBlob2_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtOperacionesBlob2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,177);\"", "", "", "HLP_Operaciones.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 182,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Operaciones.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesMonId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A662OperacionesMonId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtOperacionesMonId_Enabled!=0) ? context.localUtil.Format( (decimal)(A662OperacionesMonId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A662OperacionesMonId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,190);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesMonId_Jsonclick, 0, "Attribute", "", "", "", "", edtOperacionesMonId_Visible, edtOperacionesMonId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Operaciones.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesOrdinal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A579OperacionesOrdinal), 12, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtOperacionesOrdinal_Enabled!=0) ? context.localUtil.Format( (decimal)(A579OperacionesOrdinal), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A579OperacionesOrdinal), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,191);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesOrdinal_Jsonclick, 0, "Attribute", "", "", "", "", edtOperacionesOrdinal_Visible, edtOperacionesOrdinal_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operaciones.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 192,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacionesIDORD_Internalname, StringUtil.RTrim( A586OperacionesIDORD), StringUtil.RTrim( context.localUtil.Format( A586OperacionesIDORD, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,192);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacionesIDORD_Jsonclick, 0, "Attribute", "", "", "", "", edtOperacionesIDORD_Visible, edtOperacionesIDORD_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Operaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_solicitudes( )
      {
         /*  Grid Control  */
         StartGridControl128( ) ;
         nGXsfl_128_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount94 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_94 = 1;
               ScanStart2194( ) ;
               while ( RcdFound94 != 0 )
               {
                  init_level_properties94( ) ;
                  getByPrimaryKey2194( ) ;
                  AddRow2194( ) ;
                  ScanNext2194( ) ;
               }
               ScanEnd2194( ) ;
               nBlankRcdCount94 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal2194( ) ;
            standaloneModal2194( ) ;
            sMode94 = Gx_mode;
            while ( nGXsfl_128_idx < nRC_GXsfl_128 )
            {
               bGXsfl_128_Refreshing = true;
               ReadRow2194( ) ;
               edtOperacionesSolicitudesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESID_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtOperacionesSolicitudesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesId_Enabled), 5, 0), !bGXsfl_128_Refreshing);
               edtOperacionesSolicitudesNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESNOMBRE_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtOperacionesSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesNombre_Enabled), 5, 0), !bGXsfl_128_Refreshing);
               edtOperacionesSolicitudesPFinal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESPFINAL_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtOperacionesSolicitudesPFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesPFinal_Enabled), 5, 0), !bGXsfl_128_Refreshing);
               edtOperacionesSolicitudesComPro_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESCOMPRO_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtOperacionesSolicitudesComPro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesComPro_Enabled), 5, 0), !bGXsfl_128_Refreshing);
               edtOperacionesSolicitudesProvID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESPROVID_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtOperacionesSolicitudesProvID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesProvID_Enabled), 5, 0), !bGXsfl_128_Refreshing);
               edtOperacionesSolicitudesProvNomb_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESPROVNOMB_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtOperacionesSolicitudesProvNomb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesProvNomb_Enabled), 5, 0), !bGXsfl_128_Refreshing);
               edtOperacionesSolicitudesComProv_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESCOMPROV_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtOperacionesSolicitudesComProv_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesComProv_Enabled), 5, 0), !bGXsfl_128_Refreshing);
               edtOperacionesSolicitudesComALM_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESCOMALM_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtOperacionesSolicitudesComALM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesComALM_Enabled), 5, 0), !bGXsfl_128_Refreshing);
               cmbOperacionesSolicitudesOrigenPa.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESORIGENPA_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbOperacionesSolicitudesOrigenPa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbOperacionesSolicitudesOrigenPa.Enabled), 5, 0), !bGXsfl_128_Refreshing);
               if ( ( nRcdExists_94 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal2194( ) ;
               }
               SendRow2194( ) ;
               bGXsfl_128_Refreshing = false;
            }
            Gx_mode = sMode94;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount94 = 5;
            nRcdExists_94 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart2194( ) ;
               while ( RcdFound94 != 0 )
               {
                  sGXsfl_128_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_128_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_12894( ) ;
                  init_level_properties94( ) ;
                  standaloneNotModal2194( ) ;
                  getByPrimaryKey2194( ) ;
                  standaloneModal2194( ) ;
                  AddRow2194( ) ;
                  ScanNext2194( ) ;
               }
               ScanEnd2194( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode94 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_128_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_128_idx+1), 4, 0), 4, "0");
            SubsflControlProps_12894( ) ;
            InitAll2194( ) ;
            init_level_properties94( ) ;
            nRcdExists_94 = 0;
            nIsMod_94 = 0;
            nRcdDeleted_94 = 0;
            nBlankRcdCount94 = (short)(nBlankRcdUsr94+nBlankRcdCount94);
            fRowAdded = 0;
            while ( nBlankRcdCount94 > 0 )
            {
               standaloneNotModal2194( ) ;
               standaloneModal2194( ) ;
               AddRow2194( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
               }
               nBlankRcdCount94 = (short)(nBlankRcdCount94-1);
            }
            Gx_mode = sMode94;
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
         E11212 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z554OperacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z554OperacionesId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z649OperacionesTipo = cgiGet( "Z649OperacionesTipo");
               n649OperacionesTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A649OperacionesTipo)) ? true : false);
               Z962OperacionesComercioId1 = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z962OperacionesComercioId1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n962OperacionesComercioId1 = ((0==A962OperacionesComercioId1) ? true : false);
               Z963OperacionesComercioId2 = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z963OperacionesComercioId2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n963OperacionesComercioId2 = ((0==A963OperacionesComercioId2) ? true : false);
               Z555OperacionesRef = cgiGet( "Z555OperacionesRef");
               n555OperacionesRef = (String.IsNullOrEmpty(StringUtil.RTrim( A555OperacionesRef)) ? true : false);
               Z657OperacionesNombreRef = cgiGet( "Z657OperacionesNombreRef");
               n657OperacionesNombreRef = (String.IsNullOrEmpty(StringUtil.RTrim( A657OperacionesNombreRef)) ? true : false);
               Z579OperacionesOrdinal = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z579OperacionesOrdinal"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n579OperacionesOrdinal = ((0==A579OperacionesOrdinal) ? true : false);
               Z586OperacionesIDORD = cgiGet( "Z586OperacionesIDORD");
               n586OperacionesIDORD = (String.IsNullOrEmpty(StringUtil.RTrim( A586OperacionesIDORD)) ? true : false);
               Z569OperacionesTipoES = cgiGet( "Z569OperacionesTipoES");
               n569OperacionesTipoES = (String.IsNullOrEmpty(StringUtil.RTrim( A569OperacionesTipoES)) ? true : false);
               Z570OperacionesImporte = context.localUtil.CToN( cgiGet( "Z570OperacionesImporte"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n570OperacionesImporte = ((Convert.ToDecimal(0)==A570OperacionesImporte) ? true : false);
               Z662OperacionesMonId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z662OperacionesMonId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n662OperacionesMonId = ((0==A662OperacionesMonId) ? true : false);
               Z571OperacionesMoneda = cgiGet( "Z571OperacionesMoneda");
               n571OperacionesMoneda = (String.IsNullOrEmpty(StringUtil.RTrim( A571OperacionesMoneda)) ? true : false);
               Z572OperacionesFacturaCod = cgiGet( "Z572OperacionesFacturaCod");
               n572OperacionesFacturaCod = (String.IsNullOrEmpty(StringUtil.RTrim( A572OperacionesFacturaCod)) ? true : false);
               Z573OperacionesIva = context.localUtil.CToN( cgiGet( "Z573OperacionesIva"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n573OperacionesIva = ((Convert.ToDecimal(0)==A573OperacionesIva) ? true : false);
               Z574OperacionesComision = context.localUtil.CToN( cgiGet( "Z574OperacionesComision"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n574OperacionesComision = ((Convert.ToDecimal(0)==A574OperacionesComision) ? true : false);
               Z578OperacionesImporteGrabado = context.localUtil.CToN( cgiGet( "Z578OperacionesImporteGrabado"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n578OperacionesImporteGrabado = ((Convert.ToDecimal(0)==A578OperacionesImporteGrabado) ? true : false);
               Z580OperacionesComprobantePago = cgiGet( "Z580OperacionesComprobantePago");
               n580OperacionesComprobantePago = (String.IsNullOrEmpty(StringUtil.RTrim( A580OperacionesComprobantePago)) ? true : false);
               Z581OperacionesFechaAlta = context.localUtil.CToD( cgiGet( "Z581OperacionesFechaAlta"), 0);
               n581OperacionesFechaAlta = ((DateTime.MinValue==A581OperacionesFechaAlta) ? true : false);
               Z582OperacionesFechaPago = context.localUtil.CToT( cgiGet( "Z582OperacionesFechaPago"), 0);
               n582OperacionesFechaPago = ((DateTime.MinValue==A582OperacionesFechaPago) ? true : false);
               Z583OperacionesAux1 = cgiGet( "Z583OperacionesAux1");
               n583OperacionesAux1 = (String.IsNullOrEmpty(StringUtil.RTrim( A583OperacionesAux1)) ? true : false);
               Z584OperacionesAux2 = cgiGet( "Z584OperacionesAux2");
               n584OperacionesAux2 = (String.IsNullOrEmpty(StringUtil.RTrim( A584OperacionesAux2)) ? true : false);
               Z658OperacionesFechaDesde = context.localUtil.CToD( cgiGet( "Z658OperacionesFechaDesde"), 0);
               n658OperacionesFechaDesde = ((DateTime.MinValue==A658OperacionesFechaDesde) ? true : false);
               Z659OperacionesFechaHasta = context.localUtil.CToD( cgiGet( "Z659OperacionesFechaHasta"), 0);
               n659OperacionesFechaHasta = ((DateTime.MinValue==A659OperacionesFechaHasta) ? true : false);
               Z1028OperacionesPeriodoCod = cgiGet( "Z1028OperacionesPeriodoCod");
               n1028OperacionesPeriodoCod = (String.IsNullOrEmpty(StringUtil.RTrim( A1028OperacionesPeriodoCod)) ? true : false);
               Z577OperacionesEstado = cgiGet( "Z577OperacionesEstado");
               n577OperacionesEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A577OperacionesEstado)) ? true : false);
               Z666OperacionesUsrAlta = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z666OperacionesUsrAlta"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n666OperacionesUsrAlta = ((0==A666OperacionesUsrAlta) ? true : false);
               Z667OperacionesUsrActualizacion = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z667OperacionesUsrActualizacion"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n667OperacionesUsrActualizacion = ((0==A667OperacionesUsrActualizacion) ? true : false);
               A962OperacionesComercioId1 = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z962OperacionesComercioId1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n962OperacionesComercioId1 = false;
               n962OperacionesComercioId1 = ((0==A962OperacionesComercioId1) ? true : false);
               A963OperacionesComercioId2 = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z963OperacionesComercioId2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n963OperacionesComercioId2 = false;
               n963OperacionesComercioId2 = ((0==A963OperacionesComercioId2) ? true : false);
               A1028OperacionesPeriodoCod = cgiGet( "Z1028OperacionesPeriodoCod");
               n1028OperacionesPeriodoCod = false;
               n1028OperacionesPeriodoCod = (String.IsNullOrEmpty(StringUtil.RTrim( A1028OperacionesPeriodoCod)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_128 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_128"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7OperacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vOPERACIONESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A962OperacionesComercioId1 = (long)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESCOMERCIOID1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n962OperacionesComercioId1 = ((0==A962OperacionesComercioId1) ? true : false);
               A963OperacionesComercioId2 = (long)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESCOMERCIOID2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n963OperacionesComercioId2 = ((0==A963OperacionesComercioId2) ? true : false);
               A1028OperacionesPeriodoCod = cgiGet( "OPERACIONESPERIODOCOD");
               n1028OperacionesPeriodoCod = (String.IsNullOrEmpty(StringUtil.RTrim( A1028OperacionesPeriodoCod)) ? true : false);
               AV17Pgmname = cgiGet( "vPGMNAME");
               A1029OperacionesSolicitudesXZComPro = context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESXZCOMPRO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n1029OperacionesSolicitudesXZComPro = false;
               n1029OperacionesSolicitudesXZComPro = ((Convert.ToDecimal(0)==A1029OperacionesSolicitudesXZComPro) ? true : false);
               A1027OperacionesSolicitudesXZComAlm = context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESXZCOMALM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n1027OperacionesSolicitudesXZComAlm = false;
               n1027OperacionesSolicitudesXZComAlm = ((Convert.ToDecimal(0)==A1027OperacionesSolicitudesXZComAlm) ? true : false);
               Gxuitabspanel_tabs_Objectcall = cgiGet( "GXUITABSPANEL_TABS_Objectcall");
               Gxuitabspanel_tabs_Enabled = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Enabled"));
               Gxuitabspanel_tabs_Activepage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Activepage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs_Activepagecontrolname = cgiGet( "GXUITABSPANEL_TABS_Activepagecontrolname");
               Gxuitabspanel_tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs_Class = cgiGet( "GXUITABSPANEL_TABS_Class");
               Gxuitabspanel_tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Historymanagement"));
               Gxuitabspanel_tabs_Visible = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Visible"));
               edtOperacionesBlob1_Filename = cgiGet( "OPERACIONESBLOB1_Filename");
               edtOperacionesBlob2_Filename = cgiGet( "OPERACIONESBLOB2_Filename");
               edtOperacionesBlob1_Filetype = cgiGet( "OPERACIONESBLOB1_Filetype");
               edtOperacionesBlob2_Filetype = cgiGet( "OPERACIONESBLOB2_Filetype");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtOperacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACIONESID");
                  AnyError = 1;
                  GX_FocusControl = edtOperacionesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A554OperacionesId = 0;
                  AssignAttri("", false, "A554OperacionesId", StringUtil.LTrimStr( (decimal)(A554OperacionesId), 18, 0));
               }
               else
               {
                  A554OperacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A554OperacionesId", StringUtil.LTrimStr( (decimal)(A554OperacionesId), 18, 0));
               }
               A555OperacionesRef = cgiGet( edtOperacionesRef_Internalname);
               n555OperacionesRef = false;
               AssignAttri("", false, "A555OperacionesRef", A555OperacionesRef);
               n555OperacionesRef = (String.IsNullOrEmpty(StringUtil.RTrim( A555OperacionesRef)) ? true : false);
               A657OperacionesNombreRef = cgiGet( edtOperacionesNombreRef_Internalname);
               n657OperacionesNombreRef = false;
               AssignAttri("", false, "A657OperacionesNombreRef", A657OperacionesNombreRef);
               n657OperacionesNombreRef = (String.IsNullOrEmpty(StringUtil.RTrim( A657OperacionesNombreRef)) ? true : false);
               A572OperacionesFacturaCod = cgiGet( edtOperacionesFacturaCod_Internalname);
               n572OperacionesFacturaCod = false;
               AssignAttri("", false, "A572OperacionesFacturaCod", A572OperacionesFacturaCod);
               n572OperacionesFacturaCod = (String.IsNullOrEmpty(StringUtil.RTrim( A572OperacionesFacturaCod)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtOperacionesIva_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacionesIva_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 9.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACIONESIVA");
                  AnyError = 1;
                  GX_FocusControl = edtOperacionesIva_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A573OperacionesIva = 0;
                  n573OperacionesIva = false;
                  AssignAttri("", false, "A573OperacionesIva", StringUtil.LTrimStr( A573OperacionesIva, 4, 2));
               }
               else
               {
                  A573OperacionesIva = context.localUtil.CToN( cgiGet( edtOperacionesIva_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  n573OperacionesIva = false;
                  AssignAttri("", false, "A573OperacionesIva", StringUtil.LTrimStr( A573OperacionesIva, 4, 2));
               }
               n573OperacionesIva = ((Convert.ToDecimal(0)==A573OperacionesIva) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtOperacionesComision_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacionesComision_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACIONESCOMISION");
                  AnyError = 1;
                  GX_FocusControl = edtOperacionesComision_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A574OperacionesComision = 0;
                  n574OperacionesComision = false;
                  AssignAttri("", false, "A574OperacionesComision", StringUtil.LTrimStr( A574OperacionesComision, 18, 2));
               }
               else
               {
                  A574OperacionesComision = context.localUtil.CToN( cgiGet( edtOperacionesComision_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  n574OperacionesComision = false;
                  AssignAttri("", false, "A574OperacionesComision", StringUtil.LTrimStr( A574OperacionesComision, 18, 2));
               }
               n574OperacionesComision = ((Convert.ToDecimal(0)==A574OperacionesComision) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtOperacionesImporteGrabado_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacionesImporteGrabado_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACIONESIMPORTEGRABADO");
                  AnyError = 1;
                  GX_FocusControl = edtOperacionesImporteGrabado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A578OperacionesImporteGrabado = 0;
                  n578OperacionesImporteGrabado = false;
                  AssignAttri("", false, "A578OperacionesImporteGrabado", StringUtil.LTrimStr( A578OperacionesImporteGrabado, 18, 2));
               }
               else
               {
                  A578OperacionesImporteGrabado = context.localUtil.CToN( cgiGet( edtOperacionesImporteGrabado_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  n578OperacionesImporteGrabado = false;
                  AssignAttri("", false, "A578OperacionesImporteGrabado", StringUtil.LTrimStr( A578OperacionesImporteGrabado, 18, 2));
               }
               n578OperacionesImporteGrabado = ((Convert.ToDecimal(0)==A578OperacionesImporteGrabado) ? true : false);
               A580OperacionesComprobantePago = cgiGet( edtOperacionesComprobantePago_Internalname);
               n580OperacionesComprobantePago = false;
               AssignAttri("", false, "A580OperacionesComprobantePago", A580OperacionesComprobantePago);
               n580OperacionesComprobantePago = (String.IsNullOrEmpty(StringUtil.RTrim( A580OperacionesComprobantePago)) ? true : false);
               cmbOperacionesEstado.Name = cmbOperacionesEstado_Internalname;
               cmbOperacionesEstado.CurrentValue = cgiGet( cmbOperacionesEstado_Internalname);
               A577OperacionesEstado = cgiGet( cmbOperacionesEstado_Internalname);
               n577OperacionesEstado = false;
               AssignAttri("", false, "A577OperacionesEstado", A577OperacionesEstado);
               n577OperacionesEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A577OperacionesEstado)) ? true : false);
               cmbOperacionesTipo.Name = cmbOperacionesTipo_Internalname;
               cmbOperacionesTipo.CurrentValue = cgiGet( cmbOperacionesTipo_Internalname);
               A649OperacionesTipo = cgiGet( cmbOperacionesTipo_Internalname);
               n649OperacionesTipo = false;
               AssignAttri("", false, "A649OperacionesTipo", A649OperacionesTipo);
               n649OperacionesTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A649OperacionesTipo)) ? true : false);
               cmbOperacionesTipoES.Name = cmbOperacionesTipoES_Internalname;
               cmbOperacionesTipoES.CurrentValue = cgiGet( cmbOperacionesTipoES_Internalname);
               A569OperacionesTipoES = cgiGet( cmbOperacionesTipoES_Internalname);
               n569OperacionesTipoES = false;
               AssignAttri("", false, "A569OperacionesTipoES", A569OperacionesTipoES);
               n569OperacionesTipoES = (String.IsNullOrEmpty(StringUtil.RTrim( A569OperacionesTipoES)) ? true : false);
               A571OperacionesMoneda = cgiGet( edtOperacionesMoneda_Internalname);
               n571OperacionesMoneda = false;
               AssignAttri("", false, "A571OperacionesMoneda", A571OperacionesMoneda);
               n571OperacionesMoneda = (String.IsNullOrEmpty(StringUtil.RTrim( A571OperacionesMoneda)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtOperacionesImporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacionesImporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACIONESIMPORTE");
                  AnyError = 1;
                  GX_FocusControl = edtOperacionesImporte_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A570OperacionesImporte = 0;
                  n570OperacionesImporte = false;
                  AssignAttri("", false, "A570OperacionesImporte", StringUtil.LTrimStr( A570OperacionesImporte, 18, 2));
               }
               else
               {
                  A570OperacionesImporte = context.localUtil.CToN( cgiGet( edtOperacionesImporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  n570OperacionesImporte = false;
                  AssignAttri("", false, "A570OperacionesImporte", StringUtil.LTrimStr( A570OperacionesImporte, 18, 2));
               }
               n570OperacionesImporte = ((Convert.ToDecimal(0)==A570OperacionesImporte) ? true : false);
               A666OperacionesUsrAlta = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesUsrAlta_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n666OperacionesUsrAlta = false;
               AssignAttri("", false, "A666OperacionesUsrAlta", StringUtil.LTrimStr( (decimal)(A666OperacionesUsrAlta), 10, 0));
               if ( context.localUtil.VCDate( cgiGet( edtOperacionesFechaAlta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha de Alta", "")}), 1, "OPERACIONESFECHAALTA");
                  AnyError = 1;
                  GX_FocusControl = edtOperacionesFechaAlta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A581OperacionesFechaAlta = DateTime.MinValue;
                  n581OperacionesFechaAlta = false;
                  AssignAttri("", false, "A581OperacionesFechaAlta", context.localUtil.Format(A581OperacionesFechaAlta, "99/99/99"));
               }
               else
               {
                  A581OperacionesFechaAlta = context.localUtil.CToD( cgiGet( edtOperacionesFechaAlta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  n581OperacionesFechaAlta = false;
                  AssignAttri("", false, "A581OperacionesFechaAlta", context.localUtil.Format(A581OperacionesFechaAlta, "99/99/99"));
               }
               n581OperacionesFechaAlta = ((DateTime.MinValue==A581OperacionesFechaAlta) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtOperacionesFechaPago_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha de Pago", "")}), 1, "OPERACIONESFECHAPAGO");
                  AnyError = 1;
                  GX_FocusControl = edtOperacionesFechaPago_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A582OperacionesFechaPago = (DateTime)(DateTime.MinValue);
                  n582OperacionesFechaPago = false;
                  AssignAttri("", false, "A582OperacionesFechaPago", context.localUtil.TToC( A582OperacionesFechaPago, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A582OperacionesFechaPago = context.localUtil.CToT( cgiGet( edtOperacionesFechaPago_Internalname));
                  n582OperacionesFechaPago = false;
                  AssignAttri("", false, "A582OperacionesFechaPago", context.localUtil.TToC( A582OperacionesFechaPago, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               n582OperacionesFechaPago = ((DateTime.MinValue==A582OperacionesFechaPago) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtOperacionesFechaDesde_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Desde", "")}), 1, "OPERACIONESFECHADESDE");
                  AnyError = 1;
                  GX_FocusControl = edtOperacionesFechaDesde_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A658OperacionesFechaDesde = DateTime.MinValue;
                  n658OperacionesFechaDesde = false;
                  AssignAttri("", false, "A658OperacionesFechaDesde", context.localUtil.Format(A658OperacionesFechaDesde, "99/99/99"));
               }
               else
               {
                  A658OperacionesFechaDesde = context.localUtil.CToD( cgiGet( edtOperacionesFechaDesde_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  n658OperacionesFechaDesde = false;
                  AssignAttri("", false, "A658OperacionesFechaDesde", context.localUtil.Format(A658OperacionesFechaDesde, "99/99/99"));
               }
               n658OperacionesFechaDesde = ((DateTime.MinValue==A658OperacionesFechaDesde) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtOperacionesFechaHasta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Hasta", "")}), 1, "OPERACIONESFECHAHASTA");
                  AnyError = 1;
                  GX_FocusControl = edtOperacionesFechaHasta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A659OperacionesFechaHasta = DateTime.MinValue;
                  n659OperacionesFechaHasta = false;
                  AssignAttri("", false, "A659OperacionesFechaHasta", context.localUtil.Format(A659OperacionesFechaHasta, "99/99/99"));
               }
               else
               {
                  A659OperacionesFechaHasta = context.localUtil.CToD( cgiGet( edtOperacionesFechaHasta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  n659OperacionesFechaHasta = false;
                  AssignAttri("", false, "A659OperacionesFechaHasta", context.localUtil.Format(A659OperacionesFechaHasta, "99/99/99"));
               }
               n659OperacionesFechaHasta = ((DateTime.MinValue==A659OperacionesFechaHasta) ? true : false);
               A667OperacionesUsrActualizacion = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesUsrActualizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n667OperacionesUsrActualizacion = false;
               AssignAttri("", false, "A667OperacionesUsrActualizacion", StringUtil.LTrimStr( (decimal)(A667OperacionesUsrActualizacion), 10, 0));
               A575OperacionesRequest = cgiGet( edtOperacionesRequest_Internalname);
               n575OperacionesRequest = false;
               AssignAttri("", false, "A575OperacionesRequest", A575OperacionesRequest);
               n575OperacionesRequest = (String.IsNullOrEmpty(StringUtil.RTrim( A575OperacionesRequest)) ? true : false);
               A576OperacionesResponse = cgiGet( edtOperacionesResponse_Internalname);
               n576OperacionesResponse = false;
               AssignAttri("", false, "A576OperacionesResponse", A576OperacionesResponse);
               n576OperacionesResponse = (String.IsNullOrEmpty(StringUtil.RTrim( A576OperacionesResponse)) ? true : false);
               A583OperacionesAux1 = cgiGet( edtOperacionesAux1_Internalname);
               n583OperacionesAux1 = false;
               AssignAttri("", false, "A583OperacionesAux1", A583OperacionesAux1);
               n583OperacionesAux1 = (String.IsNullOrEmpty(StringUtil.RTrim( A583OperacionesAux1)) ? true : false);
               A584OperacionesAux2 = cgiGet( edtOperacionesAux2_Internalname);
               n584OperacionesAux2 = false;
               AssignAttri("", false, "A584OperacionesAux2", A584OperacionesAux2);
               n584OperacionesAux2 = (String.IsNullOrEmpty(StringUtil.RTrim( A584OperacionesAux2)) ? true : false);
               A585OperacionesAux3 = cgiGet( edtOperacionesAux3_Internalname);
               n585OperacionesAux3 = false;
               AssignAttri("", false, "A585OperacionesAux3", A585OperacionesAux3);
               n585OperacionesAux3 = (String.IsNullOrEmpty(StringUtil.RTrim( A585OperacionesAux3)) ? true : false);
               A663OperacionesBlob1 = cgiGet( edtOperacionesBlob1_Internalname);
               n663OperacionesBlob1 = false;
               AssignAttri("", false, "A663OperacionesBlob1", A663OperacionesBlob1);
               n663OperacionesBlob1 = (String.IsNullOrEmpty(StringUtil.RTrim( A663OperacionesBlob1)) ? true : false);
               A664OperacionesBlob2 = cgiGet( edtOperacionesBlob2_Internalname);
               n664OperacionesBlob2 = false;
               AssignAttri("", false, "A664OperacionesBlob2", A664OperacionesBlob2);
               n664OperacionesBlob2 = (String.IsNullOrEmpty(StringUtil.RTrim( A664OperacionesBlob2)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtOperacionesMonId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacionesMonId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACIONESMONID");
                  AnyError = 1;
                  GX_FocusControl = edtOperacionesMonId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A662OperacionesMonId = 0;
                  n662OperacionesMonId = false;
                  AssignAttri("", false, "A662OperacionesMonId", StringUtil.LTrimStr( (decimal)(A662OperacionesMonId), 18, 0));
               }
               else
               {
                  A662OperacionesMonId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesMonId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n662OperacionesMonId = false;
                  AssignAttri("", false, "A662OperacionesMonId", StringUtil.LTrimStr( (decimal)(A662OperacionesMonId), 18, 0));
               }
               n662OperacionesMonId = ((0==A662OperacionesMonId) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtOperacionesOrdinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacionesOrdinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACIONESORDINAL");
                  AnyError = 1;
                  GX_FocusControl = edtOperacionesOrdinal_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A579OperacionesOrdinal = 0;
                  n579OperacionesOrdinal = false;
                  AssignAttri("", false, "A579OperacionesOrdinal", StringUtil.LTrimStr( (decimal)(A579OperacionesOrdinal), 12, 0));
               }
               else
               {
                  A579OperacionesOrdinal = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesOrdinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n579OperacionesOrdinal = false;
                  AssignAttri("", false, "A579OperacionesOrdinal", StringUtil.LTrimStr( (decimal)(A579OperacionesOrdinal), 12, 0));
               }
               n579OperacionesOrdinal = ((0==A579OperacionesOrdinal) ? true : false);
               A586OperacionesIDORD = cgiGet( edtOperacionesIDORD_Internalname);
               n586OperacionesIDORD = false;
               AssignAttri("", false, "A586OperacionesIDORD", A586OperacionesIDORD);
               n586OperacionesIDORD = (String.IsNullOrEmpty(StringUtil.RTrim( A586OperacionesIDORD)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A663OperacionesBlob1)) )
               {
                  edtOperacionesBlob1_Filename = (string)(CGIGetFileName(edtOperacionesBlob1_Internalname));
                  edtOperacionesBlob1_Filetype = (string)(CGIGetFileType(edtOperacionesBlob1_Internalname));
               }
               if ( String.IsNullOrEmpty(StringUtil.RTrim( A663OperacionesBlob1)) )
               {
                  GXCCtlgxBlob = "OPERACIONESBLOB1" + "_gxBlob";
                  A663OperacionesBlob1 = cgiGet( GXCCtlgxBlob);
                  n663OperacionesBlob1 = false;
                  n663OperacionesBlob1 = (String.IsNullOrEmpty(StringUtil.RTrim( A663OperacionesBlob1)) ? true : false);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A664OperacionesBlob2)) )
               {
                  edtOperacionesBlob2_Filename = (string)(CGIGetFileName(edtOperacionesBlob2_Internalname));
                  edtOperacionesBlob2_Filetype = (string)(CGIGetFileType(edtOperacionesBlob2_Internalname));
               }
               if ( String.IsNullOrEmpty(StringUtil.RTrim( A664OperacionesBlob2)) )
               {
                  GXCCtlgxBlob = "OPERACIONESBLOB2" + "_gxBlob";
                  A664OperacionesBlob2 = cgiGet( GXCCtlgxBlob);
                  n664OperacionesBlob2 = false;
                  n664OperacionesBlob2 = (String.IsNullOrEmpty(StringUtil.RTrim( A664OperacionesBlob2)) ? true : false);
               }
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Operaciones");
               A666OperacionesUsrAlta = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesUsrAlta_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n666OperacionesUsrAlta = false;
               AssignAttri("", false, "A666OperacionesUsrAlta", StringUtil.LTrimStr( (decimal)(A666OperacionesUsrAlta), 10, 0));
               forbiddenHiddens.Add("OperacionesUsrAlta", context.localUtil.Format( (decimal)(A666OperacionesUsrAlta), "ZZZZZZZZZ9"));
               A667OperacionesUsrActualizacion = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesUsrActualizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n667OperacionesUsrActualizacion = false;
               AssignAttri("", false, "A667OperacionesUsrActualizacion", StringUtil.LTrimStr( (decimal)(A667OperacionesUsrActualizacion), 10, 0));
               forbiddenHiddens.Add("OperacionesUsrActualizacion", context.localUtil.Format( (decimal)(A667OperacionesUsrActualizacion), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("OperacionesComercioId1", context.localUtil.Format( (decimal)(A962OperacionesComercioId1), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("OperacionesComercioId2", context.localUtil.Format( (decimal)(A963OperacionesComercioId2), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("OperacionesPeriodoCod", StringUtil.RTrim( context.localUtil.Format( A1028OperacionesPeriodoCod, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A554OperacionesId != Z554OperacionesId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("operaciones:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A554OperacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "OperacionesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A554OperacionesId", StringUtil.LTrimStr( (decimal)(A554OperacionesId), 18, 0));
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
                     sMode82 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode82;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound82 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_210( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "OPERACIONESID");
                        AnyError = 1;
                        GX_FocusControl = edtOperacionesId_Internalname;
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
                           E11212 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12212 ();
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
            E12212 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2182( ) ;
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
            DisableAttributes2182( ) ;
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

      protected void CONFIRM_210( )
      {
         BeforeValidate2182( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2182( ) ;
            }
            else
            {
               CheckExtendedTable2182( ) ;
               CloseExtendedTableCursors2182( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode82 = Gx_mode;
            CONFIRM_2194( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode82;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode82;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_2194( )
      {
         nGXsfl_128_idx = 0;
         while ( nGXsfl_128_idx < nRC_GXsfl_128 )
         {
            ReadRow2194( ) ;
            if ( ( nRcdExists_94 != 0 ) || ( nIsMod_94 != 0 ) )
            {
               GetKey2194( ) ;
               if ( ( nRcdExists_94 == 0 ) && ( nRcdDeleted_94 == 0 ) )
               {
                  if ( RcdFound94 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate2194( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2194( ) ;
                        CloseExtendedTableCursors2194( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "OPERACIONESID");
                     AnyError = 1;
                     GX_FocusControl = edtOperacionesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound94 != 0 )
                  {
                     if ( nRcdDeleted_94 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey2194( ) ;
                        Load2194( ) ;
                        BeforeValidate2194( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2194( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_94 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate2194( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2194( ) ;
                              CloseExtendedTableCursors2194( ) ;
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
                     if ( nRcdDeleted_94 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "OPERACIONESID");
                        AnyError = 1;
                        GX_FocusControl = edtOperacionesId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtOperacionesSolicitudesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A650OperacionesSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtOperacionesSolicitudesNombre_Internalname, StringUtil.RTrim( A651OperacionesSolicitudesNombre)) ;
            ChangePostValue( edtOperacionesSolicitudesPFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A654OperacionesSolicitudesPFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtOperacionesSolicitudesComPro_Internalname, StringUtil.LTrim( StringUtil.NToC( A653OperacionesSolicitudesComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtOperacionesSolicitudesProvID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A660OperacionesSolicitudesProvID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtOperacionesSolicitudesProvNomb_Internalname, StringUtil.RTrim( A661OperacionesSolicitudesProvNomb)) ;
            ChangePostValue( edtOperacionesSolicitudesComProv_Internalname, StringUtil.LTrim( StringUtil.NToC( A655OperacionesSolicitudesComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtOperacionesSolicitudesComALM_Internalname, StringUtil.LTrim( StringUtil.NToC( A656OperacionesSolicitudesComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbOperacionesSolicitudesOrigenPa_Internalname, StringUtil.RTrim( A668OperacionesSolicitudesOrigenPa)) ;
            ChangePostValue( "ZT_"+"Z650OperacionesSolicitudesId_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z650OperacionesSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z651OperacionesSolicitudesNombre_"+sGXsfl_128_idx, StringUtil.RTrim( Z651OperacionesSolicitudesNombre)) ;
            ChangePostValue( "ZT_"+"Z654OperacionesSolicitudesPFinal_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( Z654OperacionesSolicitudesPFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z653OperacionesSolicitudesComPro_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( Z653OperacionesSolicitudesComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z660OperacionesSolicitudesProvID_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z660OperacionesSolicitudesProvID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z661OperacionesSolicitudesProvNomb_"+sGXsfl_128_idx, StringUtil.RTrim( Z661OperacionesSolicitudesProvNomb)) ;
            ChangePostValue( "ZT_"+"Z655OperacionesSolicitudesComProv_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( Z655OperacionesSolicitudesComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z656OperacionesSolicitudesComALM_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( Z656OperacionesSolicitudesComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z1029OperacionesSolicitudesXZComPro_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( Z1029OperacionesSolicitudesXZComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z1027OperacionesSolicitudesXZComAlm_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( Z1027OperacionesSolicitudesXZComAlm, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z668OperacionesSolicitudesOrigenPa_"+sGXsfl_128_idx, StringUtil.RTrim( Z668OperacionesSolicitudesOrigenPa)) ;
            ChangePostValue( "nRcdDeleted_94_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_94), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_94_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_94), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_94_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_94), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_94 != 0 )
            {
               ChangePostValue( "OPERACIONESSOLICITUDESID_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESNOMBRE_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESPFINAL_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesPFinal_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESCOMPRO_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesComPro_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESPROVID_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesProvID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESPROVNOMB_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesProvNomb_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESCOMPROV_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesComProv_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESCOMALM_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesComALM_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESORIGENPA_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbOperacionesSolicitudesOrigenPa.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption210( )
      {
      }

      protected void E11212( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWOperaciones_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWOperaciones_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWOperaciones_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV17Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtOperacionesMonId_Visible = 0;
         AssignProp("", false, edtOperacionesMonId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacionesMonId_Visible), 5, 0), true);
         edtOperacionesOrdinal_Visible = 0;
         AssignProp("", false, edtOperacionesOrdinal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacionesOrdinal_Visible), 5, 0), true);
         edtOperacionesIDORD_Visible = 0;
         AssignProp("", false, edtOperacionesIDORD_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacionesIDORD_Visible), 5, 0), true);
      }

      protected void E12212( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("operacionesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM2182( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z649OperacionesTipo = T00215_A649OperacionesTipo[0];
               Z962OperacionesComercioId1 = T00215_A962OperacionesComercioId1[0];
               Z963OperacionesComercioId2 = T00215_A963OperacionesComercioId2[0];
               Z555OperacionesRef = T00215_A555OperacionesRef[0];
               Z657OperacionesNombreRef = T00215_A657OperacionesNombreRef[0];
               Z579OperacionesOrdinal = T00215_A579OperacionesOrdinal[0];
               Z586OperacionesIDORD = T00215_A586OperacionesIDORD[0];
               Z569OperacionesTipoES = T00215_A569OperacionesTipoES[0];
               Z570OperacionesImporte = T00215_A570OperacionesImporte[0];
               Z662OperacionesMonId = T00215_A662OperacionesMonId[0];
               Z571OperacionesMoneda = T00215_A571OperacionesMoneda[0];
               Z572OperacionesFacturaCod = T00215_A572OperacionesFacturaCod[0];
               Z573OperacionesIva = T00215_A573OperacionesIva[0];
               Z574OperacionesComision = T00215_A574OperacionesComision[0];
               Z578OperacionesImporteGrabado = T00215_A578OperacionesImporteGrabado[0];
               Z580OperacionesComprobantePago = T00215_A580OperacionesComprobantePago[0];
               Z581OperacionesFechaAlta = T00215_A581OperacionesFechaAlta[0];
               Z582OperacionesFechaPago = T00215_A582OperacionesFechaPago[0];
               Z583OperacionesAux1 = T00215_A583OperacionesAux1[0];
               Z584OperacionesAux2 = T00215_A584OperacionesAux2[0];
               Z658OperacionesFechaDesde = T00215_A658OperacionesFechaDesde[0];
               Z659OperacionesFechaHasta = T00215_A659OperacionesFechaHasta[0];
               Z1028OperacionesPeriodoCod = T00215_A1028OperacionesPeriodoCod[0];
               Z577OperacionesEstado = T00215_A577OperacionesEstado[0];
               Z666OperacionesUsrAlta = T00215_A666OperacionesUsrAlta[0];
               Z667OperacionesUsrActualizacion = T00215_A667OperacionesUsrActualizacion[0];
            }
            else
            {
               Z649OperacionesTipo = A649OperacionesTipo;
               Z962OperacionesComercioId1 = A962OperacionesComercioId1;
               Z963OperacionesComercioId2 = A963OperacionesComercioId2;
               Z555OperacionesRef = A555OperacionesRef;
               Z657OperacionesNombreRef = A657OperacionesNombreRef;
               Z579OperacionesOrdinal = A579OperacionesOrdinal;
               Z586OperacionesIDORD = A586OperacionesIDORD;
               Z569OperacionesTipoES = A569OperacionesTipoES;
               Z570OperacionesImporte = A570OperacionesImporte;
               Z662OperacionesMonId = A662OperacionesMonId;
               Z571OperacionesMoneda = A571OperacionesMoneda;
               Z572OperacionesFacturaCod = A572OperacionesFacturaCod;
               Z573OperacionesIva = A573OperacionesIva;
               Z574OperacionesComision = A574OperacionesComision;
               Z578OperacionesImporteGrabado = A578OperacionesImporteGrabado;
               Z580OperacionesComprobantePago = A580OperacionesComprobantePago;
               Z581OperacionesFechaAlta = A581OperacionesFechaAlta;
               Z582OperacionesFechaPago = A582OperacionesFechaPago;
               Z583OperacionesAux1 = A583OperacionesAux1;
               Z584OperacionesAux2 = A584OperacionesAux2;
               Z658OperacionesFechaDesde = A658OperacionesFechaDesde;
               Z659OperacionesFechaHasta = A659OperacionesFechaHasta;
               Z1028OperacionesPeriodoCod = A1028OperacionesPeriodoCod;
               Z577OperacionesEstado = A577OperacionesEstado;
               Z666OperacionesUsrAlta = A666OperacionesUsrAlta;
               Z667OperacionesUsrActualizacion = A667OperacionesUsrActualizacion;
            }
         }
         if ( GX_JID == -23 )
         {
            Z554OperacionesId = A554OperacionesId;
            Z649OperacionesTipo = A649OperacionesTipo;
            Z962OperacionesComercioId1 = A962OperacionesComercioId1;
            Z963OperacionesComercioId2 = A963OperacionesComercioId2;
            Z555OperacionesRef = A555OperacionesRef;
            Z657OperacionesNombreRef = A657OperacionesNombreRef;
            Z579OperacionesOrdinal = A579OperacionesOrdinal;
            Z586OperacionesIDORD = A586OperacionesIDORD;
            Z569OperacionesTipoES = A569OperacionesTipoES;
            Z570OperacionesImporte = A570OperacionesImporte;
            Z662OperacionesMonId = A662OperacionesMonId;
            Z571OperacionesMoneda = A571OperacionesMoneda;
            Z572OperacionesFacturaCod = A572OperacionesFacturaCod;
            Z573OperacionesIva = A573OperacionesIva;
            Z574OperacionesComision = A574OperacionesComision;
            Z578OperacionesImporteGrabado = A578OperacionesImporteGrabado;
            Z575OperacionesRequest = A575OperacionesRequest;
            Z576OperacionesResponse = A576OperacionesResponse;
            Z580OperacionesComprobantePago = A580OperacionesComprobantePago;
            Z581OperacionesFechaAlta = A581OperacionesFechaAlta;
            Z582OperacionesFechaPago = A582OperacionesFechaPago;
            Z583OperacionesAux1 = A583OperacionesAux1;
            Z584OperacionesAux2 = A584OperacionesAux2;
            Z585OperacionesAux3 = A585OperacionesAux3;
            Z658OperacionesFechaDesde = A658OperacionesFechaDesde;
            Z659OperacionesFechaHasta = A659OperacionesFechaHasta;
            Z1028OperacionesPeriodoCod = A1028OperacionesPeriodoCod;
            Z663OperacionesBlob1 = A663OperacionesBlob1;
            Z664OperacionesBlob2 = A664OperacionesBlob2;
            Z577OperacionesEstado = A577OperacionesEstado;
            Z666OperacionesUsrAlta = A666OperacionesUsrAlta;
            Z667OperacionesUsrActualizacion = A667OperacionesUsrActualizacion;
         }
      }

      protected void standaloneNotModal( )
      {
         edtOperacionesUsrAlta_Enabled = 0;
         AssignProp("", false, edtOperacionesUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesUsrAlta_Enabled), 5, 0), true);
         edtOperacionesUsrActualizacion_Enabled = 0;
         AssignProp("", false, edtOperacionesUsrActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesUsrActualizacion_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtOperacionesUsrAlta_Enabled = 0;
         AssignProp("", false, edtOperacionesUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesUsrAlta_Enabled), 5, 0), true);
         edtOperacionesUsrActualizacion_Enabled = 0;
         AssignProp("", false, edtOperacionesUsrActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesUsrActualizacion_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7OperacionesId) )
         {
            A554OperacionesId = AV7OperacionesId;
            AssignAttri("", false, "A554OperacionesId", StringUtil.LTrimStr( (decimal)(A554OperacionesId), 18, 0));
         }
         if ( ! (0==AV7OperacionesId) )
         {
            edtOperacionesId_Enabled = 0;
            AssignProp("", false, edtOperacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesId_Enabled), 5, 0), true);
         }
         else
         {
            edtOperacionesId_Enabled = 1;
            AssignProp("", false, edtOperacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7OperacionesId) )
         {
            edtOperacionesId_Enabled = 0;
            AssignProp("", false, edtOperacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A649OperacionesTipo)) && ( Gx_BScreen == 0 ) )
         {
            A649OperacionesTipo = "CSO";
            n649OperacionesTipo = false;
            AssignAttri("", false, "A649OperacionesTipo", A649OperacionesTipo);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV17Pgmname = "Operaciones";
            AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         }
      }

      protected void Load2182( )
      {
         /* Using cursor T00216 */
         pr_default.execute(4, new Object[] {A554OperacionesId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound82 = 1;
            A649OperacionesTipo = T00216_A649OperacionesTipo[0];
            n649OperacionesTipo = T00216_n649OperacionesTipo[0];
            AssignAttri("", false, "A649OperacionesTipo", A649OperacionesTipo);
            A962OperacionesComercioId1 = T00216_A962OperacionesComercioId1[0];
            n962OperacionesComercioId1 = T00216_n962OperacionesComercioId1[0];
            A963OperacionesComercioId2 = T00216_A963OperacionesComercioId2[0];
            n963OperacionesComercioId2 = T00216_n963OperacionesComercioId2[0];
            A555OperacionesRef = T00216_A555OperacionesRef[0];
            n555OperacionesRef = T00216_n555OperacionesRef[0];
            AssignAttri("", false, "A555OperacionesRef", A555OperacionesRef);
            A657OperacionesNombreRef = T00216_A657OperacionesNombreRef[0];
            n657OperacionesNombreRef = T00216_n657OperacionesNombreRef[0];
            AssignAttri("", false, "A657OperacionesNombreRef", A657OperacionesNombreRef);
            A579OperacionesOrdinal = T00216_A579OperacionesOrdinal[0];
            n579OperacionesOrdinal = T00216_n579OperacionesOrdinal[0];
            AssignAttri("", false, "A579OperacionesOrdinal", StringUtil.LTrimStr( (decimal)(A579OperacionesOrdinal), 12, 0));
            A586OperacionesIDORD = T00216_A586OperacionesIDORD[0];
            n586OperacionesIDORD = T00216_n586OperacionesIDORD[0];
            AssignAttri("", false, "A586OperacionesIDORD", A586OperacionesIDORD);
            A569OperacionesTipoES = T00216_A569OperacionesTipoES[0];
            n569OperacionesTipoES = T00216_n569OperacionesTipoES[0];
            AssignAttri("", false, "A569OperacionesTipoES", A569OperacionesTipoES);
            A570OperacionesImporte = T00216_A570OperacionesImporte[0];
            n570OperacionesImporte = T00216_n570OperacionesImporte[0];
            AssignAttri("", false, "A570OperacionesImporte", StringUtil.LTrimStr( A570OperacionesImporte, 18, 2));
            A662OperacionesMonId = T00216_A662OperacionesMonId[0];
            n662OperacionesMonId = T00216_n662OperacionesMonId[0];
            AssignAttri("", false, "A662OperacionesMonId", StringUtil.LTrimStr( (decimal)(A662OperacionesMonId), 18, 0));
            A571OperacionesMoneda = T00216_A571OperacionesMoneda[0];
            n571OperacionesMoneda = T00216_n571OperacionesMoneda[0];
            AssignAttri("", false, "A571OperacionesMoneda", A571OperacionesMoneda);
            A572OperacionesFacturaCod = T00216_A572OperacionesFacturaCod[0];
            n572OperacionesFacturaCod = T00216_n572OperacionesFacturaCod[0];
            AssignAttri("", false, "A572OperacionesFacturaCod", A572OperacionesFacturaCod);
            A573OperacionesIva = T00216_A573OperacionesIva[0];
            n573OperacionesIva = T00216_n573OperacionesIva[0];
            AssignAttri("", false, "A573OperacionesIva", StringUtil.LTrimStr( A573OperacionesIva, 4, 2));
            A574OperacionesComision = T00216_A574OperacionesComision[0];
            n574OperacionesComision = T00216_n574OperacionesComision[0];
            AssignAttri("", false, "A574OperacionesComision", StringUtil.LTrimStr( A574OperacionesComision, 18, 2));
            A578OperacionesImporteGrabado = T00216_A578OperacionesImporteGrabado[0];
            n578OperacionesImporteGrabado = T00216_n578OperacionesImporteGrabado[0];
            AssignAttri("", false, "A578OperacionesImporteGrabado", StringUtil.LTrimStr( A578OperacionesImporteGrabado, 18, 2));
            A575OperacionesRequest = T00216_A575OperacionesRequest[0];
            n575OperacionesRequest = T00216_n575OperacionesRequest[0];
            AssignAttri("", false, "A575OperacionesRequest", A575OperacionesRequest);
            A576OperacionesResponse = T00216_A576OperacionesResponse[0];
            n576OperacionesResponse = T00216_n576OperacionesResponse[0];
            AssignAttri("", false, "A576OperacionesResponse", A576OperacionesResponse);
            A580OperacionesComprobantePago = T00216_A580OperacionesComprobantePago[0];
            n580OperacionesComprobantePago = T00216_n580OperacionesComprobantePago[0];
            AssignAttri("", false, "A580OperacionesComprobantePago", A580OperacionesComprobantePago);
            A581OperacionesFechaAlta = T00216_A581OperacionesFechaAlta[0];
            n581OperacionesFechaAlta = T00216_n581OperacionesFechaAlta[0];
            AssignAttri("", false, "A581OperacionesFechaAlta", context.localUtil.Format(A581OperacionesFechaAlta, "99/99/99"));
            A582OperacionesFechaPago = T00216_A582OperacionesFechaPago[0];
            n582OperacionesFechaPago = T00216_n582OperacionesFechaPago[0];
            AssignAttri("", false, "A582OperacionesFechaPago", context.localUtil.TToC( A582OperacionesFechaPago, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A583OperacionesAux1 = T00216_A583OperacionesAux1[0];
            n583OperacionesAux1 = T00216_n583OperacionesAux1[0];
            AssignAttri("", false, "A583OperacionesAux1", A583OperacionesAux1);
            A584OperacionesAux2 = T00216_A584OperacionesAux2[0];
            n584OperacionesAux2 = T00216_n584OperacionesAux2[0];
            AssignAttri("", false, "A584OperacionesAux2", A584OperacionesAux2);
            A585OperacionesAux3 = T00216_A585OperacionesAux3[0];
            n585OperacionesAux3 = T00216_n585OperacionesAux3[0];
            AssignAttri("", false, "A585OperacionesAux3", A585OperacionesAux3);
            A658OperacionesFechaDesde = T00216_A658OperacionesFechaDesde[0];
            n658OperacionesFechaDesde = T00216_n658OperacionesFechaDesde[0];
            AssignAttri("", false, "A658OperacionesFechaDesde", context.localUtil.Format(A658OperacionesFechaDesde, "99/99/99"));
            A659OperacionesFechaHasta = T00216_A659OperacionesFechaHasta[0];
            n659OperacionesFechaHasta = T00216_n659OperacionesFechaHasta[0];
            AssignAttri("", false, "A659OperacionesFechaHasta", context.localUtil.Format(A659OperacionesFechaHasta, "99/99/99"));
            A1028OperacionesPeriodoCod = T00216_A1028OperacionesPeriodoCod[0];
            n1028OperacionesPeriodoCod = T00216_n1028OperacionesPeriodoCod[0];
            A577OperacionesEstado = T00216_A577OperacionesEstado[0];
            n577OperacionesEstado = T00216_n577OperacionesEstado[0];
            AssignAttri("", false, "A577OperacionesEstado", A577OperacionesEstado);
            A666OperacionesUsrAlta = T00216_A666OperacionesUsrAlta[0];
            n666OperacionesUsrAlta = T00216_n666OperacionesUsrAlta[0];
            AssignAttri("", false, "A666OperacionesUsrAlta", StringUtil.LTrimStr( (decimal)(A666OperacionesUsrAlta), 10, 0));
            A667OperacionesUsrActualizacion = T00216_A667OperacionesUsrActualizacion[0];
            n667OperacionesUsrActualizacion = T00216_n667OperacionesUsrActualizacion[0];
            AssignAttri("", false, "A667OperacionesUsrActualizacion", StringUtil.LTrimStr( (decimal)(A667OperacionesUsrActualizacion), 10, 0));
            A663OperacionesBlob1 = T00216_A663OperacionesBlob1[0];
            n663OperacionesBlob1 = T00216_n663OperacionesBlob1[0];
            AssignAttri("", false, "A663OperacionesBlob1", A663OperacionesBlob1);
            AssignProp("", false, edtOperacionesBlob1_Internalname, "URL", context.PathToRelativeUrl( A663OperacionesBlob1), true);
            A664OperacionesBlob2 = T00216_A664OperacionesBlob2[0];
            n664OperacionesBlob2 = T00216_n664OperacionesBlob2[0];
            AssignAttri("", false, "A664OperacionesBlob2", A664OperacionesBlob2);
            AssignProp("", false, edtOperacionesBlob2_Internalname, "URL", context.PathToRelativeUrl( A664OperacionesBlob2), true);
            ZM2182( -23) ;
         }
         pr_default.close(4);
         OnLoadActions2182( ) ;
      }

      protected void OnLoadActions2182( )
      {
         AV17Pgmname = "Operaciones";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
      }

      protected void CheckExtendedTable2182( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV17Pgmname = "Operaciones";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         if ( ! ( ( StringUtil.StrCmp(A649OperacionesTipo, "LSF") == 0 ) || ( StringUtil.StrCmp(A649OperacionesTipo, "LSC") == 0 ) || ( StringUtil.StrCmp(A649OperacionesTipo, "COL") == 0 ) || ( StringUtil.StrCmp(A649OperacionesTipo, "POL") == 0 ) || ( StringUtil.StrCmp(A649OperacionesTipo, "CSO") == 0 ) || ( StringUtil.StrCmp(A649OperacionesTipo, "NCR") == 0 ) || ( StringUtil.StrCmp(A649OperacionesTipo, "NDE") == 0 ) || ( StringUtil.StrCmp(A649OperacionesTipo, "OTR") == 0 ) || ( StringUtil.StrCmp(A649OperacionesTipo, "FEN") == 0 ) || ( StringUtil.StrCmp(A649OperacionesTipo, "FGO") == 0 ) || ( StringUtil.StrCmp(A649OperacionesTipo, "CEX") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A649OperacionesTipo)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Operaciones Tipo", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "OPERACIONESTIPO");
            AnyError = 1;
            GX_FocusControl = cmbOperacionesTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A569OperacionesTipoES, "E") == 0 ) || ( StringUtil.StrCmp(A569OperacionesTipoES, "S") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A569OperacionesTipoES)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Tipo", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "OPERACIONESTIPOES");
            AnyError = 1;
            GX_FocusControl = cmbOperacionesTipoES_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A581OperacionesFechaAlta) || ( DateTimeUtil.ResetTime ( A581OperacionesFechaAlta ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha de Alta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "OPERACIONESFECHAALTA");
            AnyError = 1;
            GX_FocusControl = edtOperacionesFechaAlta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A582OperacionesFechaPago) || ( A582OperacionesFechaPago >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha de Pago", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "OPERACIONESFECHAPAGO");
            AnyError = 1;
            GX_FocusControl = edtOperacionesFechaPago_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A658OperacionesFechaDesde) || ( DateTimeUtil.ResetTime ( A658OperacionesFechaDesde ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Desde", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "OPERACIONESFECHADESDE");
            AnyError = 1;
            GX_FocusControl = edtOperacionesFechaDesde_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A659OperacionesFechaHasta) || ( DateTimeUtil.ResetTime ( A659OperacionesFechaHasta ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Hasta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "OPERACIONESFECHAHASTA");
            AnyError = 1;
            GX_FocusControl = edtOperacionesFechaHasta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A577OperacionesEstado, "PRO") == 0 ) || ( StringUtil.StrCmp(A577OperacionesEstado, "PND") == 0 ) || ( StringUtil.StrCmp(A577OperacionesEstado, "ANU") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A577OperacionesEstado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "OPERACIONESESTADO");
            AnyError = 1;
            GX_FocusControl = cmbOperacionesEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2182( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2182( )
      {
         /* Using cursor T00217 */
         pr_default.execute(5, new Object[] {A554OperacionesId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound82 = 1;
         }
         else
         {
            RcdFound82 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00215 */
         pr_default.execute(3, new Object[] {A554OperacionesId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM2182( 23) ;
            RcdFound82 = 1;
            A554OperacionesId = T00215_A554OperacionesId[0];
            AssignAttri("", false, "A554OperacionesId", StringUtil.LTrimStr( (decimal)(A554OperacionesId), 18, 0));
            A649OperacionesTipo = T00215_A649OperacionesTipo[0];
            n649OperacionesTipo = T00215_n649OperacionesTipo[0];
            AssignAttri("", false, "A649OperacionesTipo", A649OperacionesTipo);
            A962OperacionesComercioId1 = T00215_A962OperacionesComercioId1[0];
            n962OperacionesComercioId1 = T00215_n962OperacionesComercioId1[0];
            A963OperacionesComercioId2 = T00215_A963OperacionesComercioId2[0];
            n963OperacionesComercioId2 = T00215_n963OperacionesComercioId2[0];
            A555OperacionesRef = T00215_A555OperacionesRef[0];
            n555OperacionesRef = T00215_n555OperacionesRef[0];
            AssignAttri("", false, "A555OperacionesRef", A555OperacionesRef);
            A657OperacionesNombreRef = T00215_A657OperacionesNombreRef[0];
            n657OperacionesNombreRef = T00215_n657OperacionesNombreRef[0];
            AssignAttri("", false, "A657OperacionesNombreRef", A657OperacionesNombreRef);
            A579OperacionesOrdinal = T00215_A579OperacionesOrdinal[0];
            n579OperacionesOrdinal = T00215_n579OperacionesOrdinal[0];
            AssignAttri("", false, "A579OperacionesOrdinal", StringUtil.LTrimStr( (decimal)(A579OperacionesOrdinal), 12, 0));
            A586OperacionesIDORD = T00215_A586OperacionesIDORD[0];
            n586OperacionesIDORD = T00215_n586OperacionesIDORD[0];
            AssignAttri("", false, "A586OperacionesIDORD", A586OperacionesIDORD);
            A569OperacionesTipoES = T00215_A569OperacionesTipoES[0];
            n569OperacionesTipoES = T00215_n569OperacionesTipoES[0];
            AssignAttri("", false, "A569OperacionesTipoES", A569OperacionesTipoES);
            A570OperacionesImporte = T00215_A570OperacionesImporte[0];
            n570OperacionesImporte = T00215_n570OperacionesImporte[0];
            AssignAttri("", false, "A570OperacionesImporte", StringUtil.LTrimStr( A570OperacionesImporte, 18, 2));
            A662OperacionesMonId = T00215_A662OperacionesMonId[0];
            n662OperacionesMonId = T00215_n662OperacionesMonId[0];
            AssignAttri("", false, "A662OperacionesMonId", StringUtil.LTrimStr( (decimal)(A662OperacionesMonId), 18, 0));
            A571OperacionesMoneda = T00215_A571OperacionesMoneda[0];
            n571OperacionesMoneda = T00215_n571OperacionesMoneda[0];
            AssignAttri("", false, "A571OperacionesMoneda", A571OperacionesMoneda);
            A572OperacionesFacturaCod = T00215_A572OperacionesFacturaCod[0];
            n572OperacionesFacturaCod = T00215_n572OperacionesFacturaCod[0];
            AssignAttri("", false, "A572OperacionesFacturaCod", A572OperacionesFacturaCod);
            A573OperacionesIva = T00215_A573OperacionesIva[0];
            n573OperacionesIva = T00215_n573OperacionesIva[0];
            AssignAttri("", false, "A573OperacionesIva", StringUtil.LTrimStr( A573OperacionesIva, 4, 2));
            A574OperacionesComision = T00215_A574OperacionesComision[0];
            n574OperacionesComision = T00215_n574OperacionesComision[0];
            AssignAttri("", false, "A574OperacionesComision", StringUtil.LTrimStr( A574OperacionesComision, 18, 2));
            A578OperacionesImporteGrabado = T00215_A578OperacionesImporteGrabado[0];
            n578OperacionesImporteGrabado = T00215_n578OperacionesImporteGrabado[0];
            AssignAttri("", false, "A578OperacionesImporteGrabado", StringUtil.LTrimStr( A578OperacionesImporteGrabado, 18, 2));
            A575OperacionesRequest = T00215_A575OperacionesRequest[0];
            n575OperacionesRequest = T00215_n575OperacionesRequest[0];
            AssignAttri("", false, "A575OperacionesRequest", A575OperacionesRequest);
            A576OperacionesResponse = T00215_A576OperacionesResponse[0];
            n576OperacionesResponse = T00215_n576OperacionesResponse[0];
            AssignAttri("", false, "A576OperacionesResponse", A576OperacionesResponse);
            A580OperacionesComprobantePago = T00215_A580OperacionesComprobantePago[0];
            n580OperacionesComprobantePago = T00215_n580OperacionesComprobantePago[0];
            AssignAttri("", false, "A580OperacionesComprobantePago", A580OperacionesComprobantePago);
            A581OperacionesFechaAlta = T00215_A581OperacionesFechaAlta[0];
            n581OperacionesFechaAlta = T00215_n581OperacionesFechaAlta[0];
            AssignAttri("", false, "A581OperacionesFechaAlta", context.localUtil.Format(A581OperacionesFechaAlta, "99/99/99"));
            A582OperacionesFechaPago = T00215_A582OperacionesFechaPago[0];
            n582OperacionesFechaPago = T00215_n582OperacionesFechaPago[0];
            AssignAttri("", false, "A582OperacionesFechaPago", context.localUtil.TToC( A582OperacionesFechaPago, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A583OperacionesAux1 = T00215_A583OperacionesAux1[0];
            n583OperacionesAux1 = T00215_n583OperacionesAux1[0];
            AssignAttri("", false, "A583OperacionesAux1", A583OperacionesAux1);
            A584OperacionesAux2 = T00215_A584OperacionesAux2[0];
            n584OperacionesAux2 = T00215_n584OperacionesAux2[0];
            AssignAttri("", false, "A584OperacionesAux2", A584OperacionesAux2);
            A585OperacionesAux3 = T00215_A585OperacionesAux3[0];
            n585OperacionesAux3 = T00215_n585OperacionesAux3[0];
            AssignAttri("", false, "A585OperacionesAux3", A585OperacionesAux3);
            A658OperacionesFechaDesde = T00215_A658OperacionesFechaDesde[0];
            n658OperacionesFechaDesde = T00215_n658OperacionesFechaDesde[0];
            AssignAttri("", false, "A658OperacionesFechaDesde", context.localUtil.Format(A658OperacionesFechaDesde, "99/99/99"));
            A659OperacionesFechaHasta = T00215_A659OperacionesFechaHasta[0];
            n659OperacionesFechaHasta = T00215_n659OperacionesFechaHasta[0];
            AssignAttri("", false, "A659OperacionesFechaHasta", context.localUtil.Format(A659OperacionesFechaHasta, "99/99/99"));
            A1028OperacionesPeriodoCod = T00215_A1028OperacionesPeriodoCod[0];
            n1028OperacionesPeriodoCod = T00215_n1028OperacionesPeriodoCod[0];
            A577OperacionesEstado = T00215_A577OperacionesEstado[0];
            n577OperacionesEstado = T00215_n577OperacionesEstado[0];
            AssignAttri("", false, "A577OperacionesEstado", A577OperacionesEstado);
            A666OperacionesUsrAlta = T00215_A666OperacionesUsrAlta[0];
            n666OperacionesUsrAlta = T00215_n666OperacionesUsrAlta[0];
            AssignAttri("", false, "A666OperacionesUsrAlta", StringUtil.LTrimStr( (decimal)(A666OperacionesUsrAlta), 10, 0));
            A667OperacionesUsrActualizacion = T00215_A667OperacionesUsrActualizacion[0];
            n667OperacionesUsrActualizacion = T00215_n667OperacionesUsrActualizacion[0];
            AssignAttri("", false, "A667OperacionesUsrActualizacion", StringUtil.LTrimStr( (decimal)(A667OperacionesUsrActualizacion), 10, 0));
            A663OperacionesBlob1 = T00215_A663OperacionesBlob1[0];
            n663OperacionesBlob1 = T00215_n663OperacionesBlob1[0];
            AssignAttri("", false, "A663OperacionesBlob1", A663OperacionesBlob1);
            AssignProp("", false, edtOperacionesBlob1_Internalname, "URL", context.PathToRelativeUrl( A663OperacionesBlob1), true);
            A664OperacionesBlob2 = T00215_A664OperacionesBlob2[0];
            n664OperacionesBlob2 = T00215_n664OperacionesBlob2[0];
            AssignAttri("", false, "A664OperacionesBlob2", A664OperacionesBlob2);
            AssignProp("", false, edtOperacionesBlob2_Internalname, "URL", context.PathToRelativeUrl( A664OperacionesBlob2), true);
            Z554OperacionesId = A554OperacionesId;
            sMode82 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2182( ) ;
            if ( AnyError == 1 )
            {
               RcdFound82 = 0;
               InitializeNonKey2182( ) ;
            }
            Gx_mode = sMode82;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound82 = 0;
            InitializeNonKey2182( ) ;
            sMode82 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode82;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey2182( ) ;
         if ( RcdFound82 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound82 = 0;
         /* Using cursor T00218 */
         pr_default.execute(6, new Object[] {A554OperacionesId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00218_A554OperacionesId[0] < A554OperacionesId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00218_A554OperacionesId[0] > A554OperacionesId ) ) )
            {
               A554OperacionesId = T00218_A554OperacionesId[0];
               AssignAttri("", false, "A554OperacionesId", StringUtil.LTrimStr( (decimal)(A554OperacionesId), 18, 0));
               RcdFound82 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound82 = 0;
         /* Using cursor T00219 */
         pr_default.execute(7, new Object[] {A554OperacionesId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00219_A554OperacionesId[0] > A554OperacionesId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00219_A554OperacionesId[0] < A554OperacionesId ) ) )
            {
               A554OperacionesId = T00219_A554OperacionesId[0];
               AssignAttri("", false, "A554OperacionesId", StringUtil.LTrimStr( (decimal)(A554OperacionesId), 18, 0));
               RcdFound82 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2182( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtOperacionesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2182( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound82 == 1 )
            {
               if ( A554OperacionesId != Z554OperacionesId )
               {
                  A554OperacionesId = Z554OperacionesId;
                  AssignAttri("", false, "A554OperacionesId", StringUtil.LTrimStr( (decimal)(A554OperacionesId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "OPERACIONESID");
                  AnyError = 1;
                  GX_FocusControl = edtOperacionesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtOperacionesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2182( ) ;
                  GX_FocusControl = edtOperacionesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A554OperacionesId != Z554OperacionesId )
               {
                  /* Insert record */
                  GX_FocusControl = edtOperacionesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2182( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "OPERACIONESID");
                     AnyError = 1;
                     GX_FocusControl = edtOperacionesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtOperacionesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2182( ) ;
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
         if ( A554OperacionesId != Z554OperacionesId )
         {
            A554OperacionesId = Z554OperacionesId;
            AssignAttri("", false, "A554OperacionesId", StringUtil.LTrimStr( (decimal)(A554OperacionesId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "OPERACIONESID");
            AnyError = 1;
            GX_FocusControl = edtOperacionesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtOperacionesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2182( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00214 */
            pr_default.execute(2, new Object[] {A554OperacionesId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Operaciones"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z649OperacionesTipo, T00214_A649OperacionesTipo[0]) != 0 ) || ( Z962OperacionesComercioId1 != T00214_A962OperacionesComercioId1[0] ) || ( Z963OperacionesComercioId2 != T00214_A963OperacionesComercioId2[0] ) || ( StringUtil.StrCmp(Z555OperacionesRef, T00214_A555OperacionesRef[0]) != 0 ) || ( StringUtil.StrCmp(Z657OperacionesNombreRef, T00214_A657OperacionesNombreRef[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z579OperacionesOrdinal != T00214_A579OperacionesOrdinal[0] ) || ( StringUtil.StrCmp(Z586OperacionesIDORD, T00214_A586OperacionesIDORD[0]) != 0 ) || ( StringUtil.StrCmp(Z569OperacionesTipoES, T00214_A569OperacionesTipoES[0]) != 0 ) || ( Z570OperacionesImporte != T00214_A570OperacionesImporte[0] ) || ( Z662OperacionesMonId != T00214_A662OperacionesMonId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z571OperacionesMoneda, T00214_A571OperacionesMoneda[0]) != 0 ) || ( StringUtil.StrCmp(Z572OperacionesFacturaCod, T00214_A572OperacionesFacturaCod[0]) != 0 ) || ( Z573OperacionesIva != T00214_A573OperacionesIva[0] ) || ( Z574OperacionesComision != T00214_A574OperacionesComision[0] ) || ( Z578OperacionesImporteGrabado != T00214_A578OperacionesImporteGrabado[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z580OperacionesComprobantePago, T00214_A580OperacionesComprobantePago[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z581OperacionesFechaAlta ) != DateTimeUtil.ResetTime ( T00214_A581OperacionesFechaAlta[0] ) ) || ( Z582OperacionesFechaPago != T00214_A582OperacionesFechaPago[0] ) || ( StringUtil.StrCmp(Z583OperacionesAux1, T00214_A583OperacionesAux1[0]) != 0 ) || ( StringUtil.StrCmp(Z584OperacionesAux2, T00214_A584OperacionesAux2[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z658OperacionesFechaDesde ) != DateTimeUtil.ResetTime ( T00214_A658OperacionesFechaDesde[0] ) ) || ( DateTimeUtil.ResetTime ( Z659OperacionesFechaHasta ) != DateTimeUtil.ResetTime ( T00214_A659OperacionesFechaHasta[0] ) ) || ( StringUtil.StrCmp(Z1028OperacionesPeriodoCod, T00214_A1028OperacionesPeriodoCod[0]) != 0 ) || ( StringUtil.StrCmp(Z577OperacionesEstado, T00214_A577OperacionesEstado[0]) != 0 ) || ( Z666OperacionesUsrAlta != T00214_A666OperacionesUsrAlta[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z667OperacionesUsrActualizacion != T00214_A667OperacionesUsrActualizacion[0] ) )
            {
               if ( StringUtil.StrCmp(Z649OperacionesTipo, T00214_A649OperacionesTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesTipo");
                  GXUtil.WriteLogRaw("Old: ",Z649OperacionesTipo);
                  GXUtil.WriteLogRaw("Current: ",T00214_A649OperacionesTipo[0]);
               }
               if ( Z962OperacionesComercioId1 != T00214_A962OperacionesComercioId1[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesComercioId1");
                  GXUtil.WriteLogRaw("Old: ",Z962OperacionesComercioId1);
                  GXUtil.WriteLogRaw("Current: ",T00214_A962OperacionesComercioId1[0]);
               }
               if ( Z963OperacionesComercioId2 != T00214_A963OperacionesComercioId2[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesComercioId2");
                  GXUtil.WriteLogRaw("Old: ",Z963OperacionesComercioId2);
                  GXUtil.WriteLogRaw("Current: ",T00214_A963OperacionesComercioId2[0]);
               }
               if ( StringUtil.StrCmp(Z555OperacionesRef, T00214_A555OperacionesRef[0]) != 0 )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesRef");
                  GXUtil.WriteLogRaw("Old: ",Z555OperacionesRef);
                  GXUtil.WriteLogRaw("Current: ",T00214_A555OperacionesRef[0]);
               }
               if ( StringUtil.StrCmp(Z657OperacionesNombreRef, T00214_A657OperacionesNombreRef[0]) != 0 )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesNombreRef");
                  GXUtil.WriteLogRaw("Old: ",Z657OperacionesNombreRef);
                  GXUtil.WriteLogRaw("Current: ",T00214_A657OperacionesNombreRef[0]);
               }
               if ( Z579OperacionesOrdinal != T00214_A579OperacionesOrdinal[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesOrdinal");
                  GXUtil.WriteLogRaw("Old: ",Z579OperacionesOrdinal);
                  GXUtil.WriteLogRaw("Current: ",T00214_A579OperacionesOrdinal[0]);
               }
               if ( StringUtil.StrCmp(Z586OperacionesIDORD, T00214_A586OperacionesIDORD[0]) != 0 )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesIDORD");
                  GXUtil.WriteLogRaw("Old: ",Z586OperacionesIDORD);
                  GXUtil.WriteLogRaw("Current: ",T00214_A586OperacionesIDORD[0]);
               }
               if ( StringUtil.StrCmp(Z569OperacionesTipoES, T00214_A569OperacionesTipoES[0]) != 0 )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesTipoES");
                  GXUtil.WriteLogRaw("Old: ",Z569OperacionesTipoES);
                  GXUtil.WriteLogRaw("Current: ",T00214_A569OperacionesTipoES[0]);
               }
               if ( Z570OperacionesImporte != T00214_A570OperacionesImporte[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesImporte");
                  GXUtil.WriteLogRaw("Old: ",Z570OperacionesImporte);
                  GXUtil.WriteLogRaw("Current: ",T00214_A570OperacionesImporte[0]);
               }
               if ( Z662OperacionesMonId != T00214_A662OperacionesMonId[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesMonId");
                  GXUtil.WriteLogRaw("Old: ",Z662OperacionesMonId);
                  GXUtil.WriteLogRaw("Current: ",T00214_A662OperacionesMonId[0]);
               }
               if ( StringUtil.StrCmp(Z571OperacionesMoneda, T00214_A571OperacionesMoneda[0]) != 0 )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesMoneda");
                  GXUtil.WriteLogRaw("Old: ",Z571OperacionesMoneda);
                  GXUtil.WriteLogRaw("Current: ",T00214_A571OperacionesMoneda[0]);
               }
               if ( StringUtil.StrCmp(Z572OperacionesFacturaCod, T00214_A572OperacionesFacturaCod[0]) != 0 )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesFacturaCod");
                  GXUtil.WriteLogRaw("Old: ",Z572OperacionesFacturaCod);
                  GXUtil.WriteLogRaw("Current: ",T00214_A572OperacionesFacturaCod[0]);
               }
               if ( Z573OperacionesIva != T00214_A573OperacionesIva[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesIva");
                  GXUtil.WriteLogRaw("Old: ",Z573OperacionesIva);
                  GXUtil.WriteLogRaw("Current: ",T00214_A573OperacionesIva[0]);
               }
               if ( Z574OperacionesComision != T00214_A574OperacionesComision[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesComision");
                  GXUtil.WriteLogRaw("Old: ",Z574OperacionesComision);
                  GXUtil.WriteLogRaw("Current: ",T00214_A574OperacionesComision[0]);
               }
               if ( Z578OperacionesImporteGrabado != T00214_A578OperacionesImporteGrabado[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesImporteGrabado");
                  GXUtil.WriteLogRaw("Old: ",Z578OperacionesImporteGrabado);
                  GXUtil.WriteLogRaw("Current: ",T00214_A578OperacionesImporteGrabado[0]);
               }
               if ( StringUtil.StrCmp(Z580OperacionesComprobantePago, T00214_A580OperacionesComprobantePago[0]) != 0 )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesComprobantePago");
                  GXUtil.WriteLogRaw("Old: ",Z580OperacionesComprobantePago);
                  GXUtil.WriteLogRaw("Current: ",T00214_A580OperacionesComprobantePago[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z581OperacionesFechaAlta ) != DateTimeUtil.ResetTime ( T00214_A581OperacionesFechaAlta[0] ) )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesFechaAlta");
                  GXUtil.WriteLogRaw("Old: ",Z581OperacionesFechaAlta);
                  GXUtil.WriteLogRaw("Current: ",T00214_A581OperacionesFechaAlta[0]);
               }
               if ( Z582OperacionesFechaPago != T00214_A582OperacionesFechaPago[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesFechaPago");
                  GXUtil.WriteLogRaw("Old: ",Z582OperacionesFechaPago);
                  GXUtil.WriteLogRaw("Current: ",T00214_A582OperacionesFechaPago[0]);
               }
               if ( StringUtil.StrCmp(Z583OperacionesAux1, T00214_A583OperacionesAux1[0]) != 0 )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesAux1");
                  GXUtil.WriteLogRaw("Old: ",Z583OperacionesAux1);
                  GXUtil.WriteLogRaw("Current: ",T00214_A583OperacionesAux1[0]);
               }
               if ( StringUtil.StrCmp(Z584OperacionesAux2, T00214_A584OperacionesAux2[0]) != 0 )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesAux2");
                  GXUtil.WriteLogRaw("Old: ",Z584OperacionesAux2);
                  GXUtil.WriteLogRaw("Current: ",T00214_A584OperacionesAux2[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z658OperacionesFechaDesde ) != DateTimeUtil.ResetTime ( T00214_A658OperacionesFechaDesde[0] ) )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesFechaDesde");
                  GXUtil.WriteLogRaw("Old: ",Z658OperacionesFechaDesde);
                  GXUtil.WriteLogRaw("Current: ",T00214_A658OperacionesFechaDesde[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z659OperacionesFechaHasta ) != DateTimeUtil.ResetTime ( T00214_A659OperacionesFechaHasta[0] ) )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesFechaHasta");
                  GXUtil.WriteLogRaw("Old: ",Z659OperacionesFechaHasta);
                  GXUtil.WriteLogRaw("Current: ",T00214_A659OperacionesFechaHasta[0]);
               }
               if ( StringUtil.StrCmp(Z1028OperacionesPeriodoCod, T00214_A1028OperacionesPeriodoCod[0]) != 0 )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesPeriodoCod");
                  GXUtil.WriteLogRaw("Old: ",Z1028OperacionesPeriodoCod);
                  GXUtil.WriteLogRaw("Current: ",T00214_A1028OperacionesPeriodoCod[0]);
               }
               if ( StringUtil.StrCmp(Z577OperacionesEstado, T00214_A577OperacionesEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesEstado");
                  GXUtil.WriteLogRaw("Old: ",Z577OperacionesEstado);
                  GXUtil.WriteLogRaw("Current: ",T00214_A577OperacionesEstado[0]);
               }
               if ( Z666OperacionesUsrAlta != T00214_A666OperacionesUsrAlta[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesUsrAlta");
                  GXUtil.WriteLogRaw("Old: ",Z666OperacionesUsrAlta);
                  GXUtil.WriteLogRaw("Current: ",T00214_A666OperacionesUsrAlta[0]);
               }
               if ( Z667OperacionesUsrActualizacion != T00214_A667OperacionesUsrActualizacion[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesUsrActualizacion");
                  GXUtil.WriteLogRaw("Old: ",Z667OperacionesUsrActualizacion);
                  GXUtil.WriteLogRaw("Current: ",T00214_A667OperacionesUsrActualizacion[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Operaciones"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2182( )
      {
         BeforeValidate2182( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2182( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2182( 0) ;
            CheckOptimisticConcurrency2182( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2182( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2182( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002110 */
                     pr_default.execute(8, new Object[] {A554OperacionesId, n649OperacionesTipo, A649OperacionesTipo, n962OperacionesComercioId1, A962OperacionesComercioId1, n963OperacionesComercioId2, A963OperacionesComercioId2, n555OperacionesRef, A555OperacionesRef, n657OperacionesNombreRef, A657OperacionesNombreRef, n579OperacionesOrdinal, A579OperacionesOrdinal, n586OperacionesIDORD, A586OperacionesIDORD, n569OperacionesTipoES, A569OperacionesTipoES, n570OperacionesImporte, A570OperacionesImporte, n662OperacionesMonId, A662OperacionesMonId, n571OperacionesMoneda, A571OperacionesMoneda, n572OperacionesFacturaCod, A572OperacionesFacturaCod, n573OperacionesIva, A573OperacionesIva, n574OperacionesComision, A574OperacionesComision, n578OperacionesImporteGrabado, A578OperacionesImporteGrabado, n575OperacionesRequest, A575OperacionesRequest, n576OperacionesResponse, A576OperacionesResponse, n580OperacionesComprobantePago, A580OperacionesComprobantePago, n581OperacionesFechaAlta, A581OperacionesFechaAlta, n582OperacionesFechaPago, A582OperacionesFechaPago, n583OperacionesAux1, A583OperacionesAux1, n584OperacionesAux2, A584OperacionesAux2, n585OperacionesAux3, A585OperacionesAux3, n658OperacionesFechaDesde, A658OperacionesFechaDesde, n659OperacionesFechaHasta, A659OperacionesFechaHasta, n1028OperacionesPeriodoCod, A1028OperacionesPeriodoCod, n663OperacionesBlob1, A663OperacionesBlob1, n664OperacionesBlob2, A664OperacionesBlob2, n577OperacionesEstado, A577OperacionesEstado, n666OperacionesUsrAlta, A666OperacionesUsrAlta, n667OperacionesUsrActualizacion, A667OperacionesUsrActualizacion});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Operaciones");
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
                           ProcessLevel2182( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption210( ) ;
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
               Load2182( ) ;
            }
            EndLevel2182( ) ;
         }
         CloseExtendedTableCursors2182( ) ;
      }

      protected void Update2182( )
      {
         BeforeValidate2182( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2182( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2182( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2182( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2182( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002111 */
                     pr_default.execute(9, new Object[] {n649OperacionesTipo, A649OperacionesTipo, n962OperacionesComercioId1, A962OperacionesComercioId1, n963OperacionesComercioId2, A963OperacionesComercioId2, n555OperacionesRef, A555OperacionesRef, n657OperacionesNombreRef, A657OperacionesNombreRef, n579OperacionesOrdinal, A579OperacionesOrdinal, n586OperacionesIDORD, A586OperacionesIDORD, n569OperacionesTipoES, A569OperacionesTipoES, n570OperacionesImporte, A570OperacionesImporte, n662OperacionesMonId, A662OperacionesMonId, n571OperacionesMoneda, A571OperacionesMoneda, n572OperacionesFacturaCod, A572OperacionesFacturaCod, n573OperacionesIva, A573OperacionesIva, n574OperacionesComision, A574OperacionesComision, n578OperacionesImporteGrabado, A578OperacionesImporteGrabado, n575OperacionesRequest, A575OperacionesRequest, n576OperacionesResponse, A576OperacionesResponse, n580OperacionesComprobantePago, A580OperacionesComprobantePago, n581OperacionesFechaAlta, A581OperacionesFechaAlta, n582OperacionesFechaPago, A582OperacionesFechaPago, n583OperacionesAux1, A583OperacionesAux1, n584OperacionesAux2, A584OperacionesAux2, n585OperacionesAux3, A585OperacionesAux3, n658OperacionesFechaDesde, A658OperacionesFechaDesde, n659OperacionesFechaHasta, A659OperacionesFechaHasta, n1028OperacionesPeriodoCod, A1028OperacionesPeriodoCod, n577OperacionesEstado, A577OperacionesEstado, n666OperacionesUsrAlta, A666OperacionesUsrAlta, n667OperacionesUsrActualizacion, A667OperacionesUsrActualizacion, A554OperacionesId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Operaciones");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Operaciones"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2182( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2182( ) ;
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
            EndLevel2182( ) ;
         }
         CloseExtendedTableCursors2182( ) ;
      }

      protected void DeferredUpdate2182( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T002112 */
            pr_default.execute(10, new Object[] {n663OperacionesBlob1, A663OperacionesBlob1, A554OperacionesId});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Operaciones");
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002113 */
            pr_default.execute(11, new Object[] {n664OperacionesBlob2, A664OperacionesBlob2, A554OperacionesId});
            pr_default.close(11);
            pr_default.SmartCacheProvider.SetUpdated("Operaciones");
         }
      }

      protected void delete( )
      {
         BeforeValidate2182( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2182( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2182( ) ;
            AfterConfirm2182( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2182( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart2194( ) ;
                  while ( RcdFound94 != 0 )
                  {
                     getByPrimaryKey2194( ) ;
                     Delete2194( ) ;
                     ScanNext2194( ) ;
                  }
                  ScanEnd2194( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002114 */
                     pr_default.execute(12, new Object[] {A554OperacionesId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Operaciones");
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
         sMode82 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2182( ) ;
         Gx_mode = sMode82;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2182( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV17Pgmname = "Operaciones";
            AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         }
      }

      protected void ProcessNestedLevel2194( )
      {
         nGXsfl_128_idx = 0;
         while ( nGXsfl_128_idx < nRC_GXsfl_128 )
         {
            ReadRow2194( ) ;
            if ( ( nRcdExists_94 != 0 ) || ( nIsMod_94 != 0 ) )
            {
               standaloneNotModal2194( ) ;
               GetKey2194( ) ;
               if ( ( nRcdExists_94 == 0 ) && ( nRcdDeleted_94 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert2194( ) ;
               }
               else
               {
                  if ( RcdFound94 != 0 )
                  {
                     if ( ( nRcdDeleted_94 != 0 ) && ( nRcdExists_94 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete2194( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_94 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update2194( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_94 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "OPERACIONESID");
                        AnyError = 1;
                        GX_FocusControl = edtOperacionesId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtOperacionesSolicitudesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A650OperacionesSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtOperacionesSolicitudesNombre_Internalname, StringUtil.RTrim( A651OperacionesSolicitudesNombre)) ;
            ChangePostValue( edtOperacionesSolicitudesPFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A654OperacionesSolicitudesPFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtOperacionesSolicitudesComPro_Internalname, StringUtil.LTrim( StringUtil.NToC( A653OperacionesSolicitudesComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtOperacionesSolicitudesProvID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A660OperacionesSolicitudesProvID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtOperacionesSolicitudesProvNomb_Internalname, StringUtil.RTrim( A661OperacionesSolicitudesProvNomb)) ;
            ChangePostValue( edtOperacionesSolicitudesComProv_Internalname, StringUtil.LTrim( StringUtil.NToC( A655OperacionesSolicitudesComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtOperacionesSolicitudesComALM_Internalname, StringUtil.LTrim( StringUtil.NToC( A656OperacionesSolicitudesComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbOperacionesSolicitudesOrigenPa_Internalname, StringUtil.RTrim( A668OperacionesSolicitudesOrigenPa)) ;
            ChangePostValue( "ZT_"+"Z650OperacionesSolicitudesId_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z650OperacionesSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z651OperacionesSolicitudesNombre_"+sGXsfl_128_idx, StringUtil.RTrim( Z651OperacionesSolicitudesNombre)) ;
            ChangePostValue( "ZT_"+"Z654OperacionesSolicitudesPFinal_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( Z654OperacionesSolicitudesPFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z653OperacionesSolicitudesComPro_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( Z653OperacionesSolicitudesComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z660OperacionesSolicitudesProvID_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z660OperacionesSolicitudesProvID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z661OperacionesSolicitudesProvNomb_"+sGXsfl_128_idx, StringUtil.RTrim( Z661OperacionesSolicitudesProvNomb)) ;
            ChangePostValue( "ZT_"+"Z655OperacionesSolicitudesComProv_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( Z655OperacionesSolicitudesComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z656OperacionesSolicitudesComALM_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( Z656OperacionesSolicitudesComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z1029OperacionesSolicitudesXZComPro_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( Z1029OperacionesSolicitudesXZComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z1027OperacionesSolicitudesXZComAlm_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( Z1027OperacionesSolicitudesXZComAlm, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z668OperacionesSolicitudesOrigenPa_"+sGXsfl_128_idx, StringUtil.RTrim( Z668OperacionesSolicitudesOrigenPa)) ;
            ChangePostValue( "nRcdDeleted_94_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_94), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_94_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_94), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_94_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_94), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_94 != 0 )
            {
               ChangePostValue( "OPERACIONESSOLICITUDESID_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESNOMBRE_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESPFINAL_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesPFinal_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESCOMPRO_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesComPro_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESPROVID_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesProvID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESPROVNOMB_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesProvNomb_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESCOMPROV_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesComProv_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESCOMALM_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesComALM_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "OPERACIONESSOLICITUDESORIGENPA_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbOperacionesSolicitudesOrigenPa.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2194( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_94 = 0;
         nIsMod_94 = 0;
         nRcdDeleted_94 = 0;
      }

      protected void ProcessLevel2182( )
      {
         /* Save parent mode. */
         sMode82 = Gx_mode;
         ProcessNestedLevel2194( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode82;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel2182( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2182( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.CommitDataStores("operaciones",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues210( ) ;
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
            context.RollbackDataStores("operaciones",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2182( )
      {
         /* Scan By routine */
         /* Using cursor T002115 */
         pr_default.execute(13);
         RcdFound82 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound82 = 1;
            A554OperacionesId = T002115_A554OperacionesId[0];
            AssignAttri("", false, "A554OperacionesId", StringUtil.LTrimStr( (decimal)(A554OperacionesId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2182( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound82 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound82 = 1;
            A554OperacionesId = T002115_A554OperacionesId[0];
            AssignAttri("", false, "A554OperacionesId", StringUtil.LTrimStr( (decimal)(A554OperacionesId), 18, 0));
         }
      }

      protected void ScanEnd2182( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm2182( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2182( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2182( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2182( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2182( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2182( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2182( )
      {
         edtOperacionesId_Enabled = 0;
         AssignProp("", false, edtOperacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesId_Enabled), 5, 0), true);
         edtOperacionesRef_Enabled = 0;
         AssignProp("", false, edtOperacionesRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesRef_Enabled), 5, 0), true);
         edtOperacionesNombreRef_Enabled = 0;
         AssignProp("", false, edtOperacionesNombreRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesNombreRef_Enabled), 5, 0), true);
         edtOperacionesFacturaCod_Enabled = 0;
         AssignProp("", false, edtOperacionesFacturaCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesFacturaCod_Enabled), 5, 0), true);
         edtOperacionesIva_Enabled = 0;
         AssignProp("", false, edtOperacionesIva_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesIva_Enabled), 5, 0), true);
         edtOperacionesComision_Enabled = 0;
         AssignProp("", false, edtOperacionesComision_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesComision_Enabled), 5, 0), true);
         edtOperacionesImporteGrabado_Enabled = 0;
         AssignProp("", false, edtOperacionesImporteGrabado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesImporteGrabado_Enabled), 5, 0), true);
         edtOperacionesComprobantePago_Enabled = 0;
         AssignProp("", false, edtOperacionesComprobantePago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesComprobantePago_Enabled), 5, 0), true);
         cmbOperacionesEstado.Enabled = 0;
         AssignProp("", false, cmbOperacionesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbOperacionesEstado.Enabled), 5, 0), true);
         cmbOperacionesTipo.Enabled = 0;
         AssignProp("", false, cmbOperacionesTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbOperacionesTipo.Enabled), 5, 0), true);
         cmbOperacionesTipoES.Enabled = 0;
         AssignProp("", false, cmbOperacionesTipoES_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbOperacionesTipoES.Enabled), 5, 0), true);
         edtOperacionesMoneda_Enabled = 0;
         AssignProp("", false, edtOperacionesMoneda_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesMoneda_Enabled), 5, 0), true);
         edtOperacionesImporte_Enabled = 0;
         AssignProp("", false, edtOperacionesImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesImporte_Enabled), 5, 0), true);
         edtOperacionesUsrAlta_Enabled = 0;
         AssignProp("", false, edtOperacionesUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesUsrAlta_Enabled), 5, 0), true);
         edtOperacionesFechaAlta_Enabled = 0;
         AssignProp("", false, edtOperacionesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesFechaAlta_Enabled), 5, 0), true);
         edtOperacionesFechaPago_Enabled = 0;
         AssignProp("", false, edtOperacionesFechaPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesFechaPago_Enabled), 5, 0), true);
         edtOperacionesFechaDesde_Enabled = 0;
         AssignProp("", false, edtOperacionesFechaDesde_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesFechaDesde_Enabled), 5, 0), true);
         edtOperacionesFechaHasta_Enabled = 0;
         AssignProp("", false, edtOperacionesFechaHasta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesFechaHasta_Enabled), 5, 0), true);
         edtOperacionesUsrActualizacion_Enabled = 0;
         AssignProp("", false, edtOperacionesUsrActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesUsrActualizacion_Enabled), 5, 0), true);
         edtOperacionesRequest_Enabled = 0;
         AssignProp("", false, edtOperacionesRequest_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesRequest_Enabled), 5, 0), true);
         edtOperacionesResponse_Enabled = 0;
         AssignProp("", false, edtOperacionesResponse_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesResponse_Enabled), 5, 0), true);
         edtOperacionesAux1_Enabled = 0;
         AssignProp("", false, edtOperacionesAux1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesAux1_Enabled), 5, 0), true);
         edtOperacionesAux2_Enabled = 0;
         AssignProp("", false, edtOperacionesAux2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesAux2_Enabled), 5, 0), true);
         edtOperacionesAux3_Enabled = 0;
         AssignProp("", false, edtOperacionesAux3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesAux3_Enabled), 5, 0), true);
         edtOperacionesBlob1_Enabled = 0;
         AssignProp("", false, edtOperacionesBlob1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesBlob1_Enabled), 5, 0), true);
         edtOperacionesBlob2_Enabled = 0;
         AssignProp("", false, edtOperacionesBlob2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesBlob2_Enabled), 5, 0), true);
         edtOperacionesMonId_Enabled = 0;
         AssignProp("", false, edtOperacionesMonId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesMonId_Enabled), 5, 0), true);
         edtOperacionesOrdinal_Enabled = 0;
         AssignProp("", false, edtOperacionesOrdinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesOrdinal_Enabled), 5, 0), true);
         edtOperacionesIDORD_Enabled = 0;
         AssignProp("", false, edtOperacionesIDORD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesIDORD_Enabled), 5, 0), true);
      }

      protected void ZM2194( short GX_JID )
      {
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z651OperacionesSolicitudesNombre = T00213_A651OperacionesSolicitudesNombre[0];
               Z654OperacionesSolicitudesPFinal = T00213_A654OperacionesSolicitudesPFinal[0];
               Z653OperacionesSolicitudesComPro = T00213_A653OperacionesSolicitudesComPro[0];
               Z660OperacionesSolicitudesProvID = T00213_A660OperacionesSolicitudesProvID[0];
               Z661OperacionesSolicitudesProvNomb = T00213_A661OperacionesSolicitudesProvNomb[0];
               Z655OperacionesSolicitudesComProv = T00213_A655OperacionesSolicitudesComProv[0];
               Z656OperacionesSolicitudesComALM = T00213_A656OperacionesSolicitudesComALM[0];
               Z1029OperacionesSolicitudesXZComPro = T00213_A1029OperacionesSolicitudesXZComPro[0];
               Z1027OperacionesSolicitudesXZComAlm = T00213_A1027OperacionesSolicitudesXZComAlm[0];
               Z668OperacionesSolicitudesOrigenPa = T00213_A668OperacionesSolicitudesOrigenPa[0];
            }
            else
            {
               Z651OperacionesSolicitudesNombre = A651OperacionesSolicitudesNombre;
               Z654OperacionesSolicitudesPFinal = A654OperacionesSolicitudesPFinal;
               Z653OperacionesSolicitudesComPro = A653OperacionesSolicitudesComPro;
               Z660OperacionesSolicitudesProvID = A660OperacionesSolicitudesProvID;
               Z661OperacionesSolicitudesProvNomb = A661OperacionesSolicitudesProvNomb;
               Z655OperacionesSolicitudesComProv = A655OperacionesSolicitudesComProv;
               Z656OperacionesSolicitudesComALM = A656OperacionesSolicitudesComALM;
               Z1029OperacionesSolicitudesXZComPro = A1029OperacionesSolicitudesXZComPro;
               Z1027OperacionesSolicitudesXZComAlm = A1027OperacionesSolicitudesXZComAlm;
               Z668OperacionesSolicitudesOrigenPa = A668OperacionesSolicitudesOrigenPa;
            }
         }
         if ( GX_JID == -24 )
         {
            Z554OperacionesId = A554OperacionesId;
            Z650OperacionesSolicitudesId = A650OperacionesSolicitudesId;
            Z651OperacionesSolicitudesNombre = A651OperacionesSolicitudesNombre;
            Z654OperacionesSolicitudesPFinal = A654OperacionesSolicitudesPFinal;
            Z653OperacionesSolicitudesComPro = A653OperacionesSolicitudesComPro;
            Z660OperacionesSolicitudesProvID = A660OperacionesSolicitudesProvID;
            Z661OperacionesSolicitudesProvNomb = A661OperacionesSolicitudesProvNomb;
            Z655OperacionesSolicitudesComProv = A655OperacionesSolicitudesComProv;
            Z656OperacionesSolicitudesComALM = A656OperacionesSolicitudesComALM;
            Z1029OperacionesSolicitudesXZComPro = A1029OperacionesSolicitudesXZComPro;
            Z1027OperacionesSolicitudesXZComAlm = A1027OperacionesSolicitudesXZComAlm;
            Z668OperacionesSolicitudesOrigenPa = A668OperacionesSolicitudesOrigenPa;
         }
      }

      protected void standaloneNotModal2194( )
      {
         edtOperacionesSolicitudesId_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesId_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesNombre_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesNombre_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesPFinal_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesPFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesPFinal_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesComPro_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesComPro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesComPro_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesProvID_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesProvID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesProvID_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesProvNomb_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesProvNomb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesProvNomb_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesComProv_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesComProv_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesComProv_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesComALM_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesComALM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesComALM_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         cmbOperacionesSolicitudesOrigenPa.Enabled = 0;
         AssignProp("", false, cmbOperacionesSolicitudesOrigenPa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbOperacionesSolicitudesOrigenPa.Enabled), 5, 0), !bGXsfl_128_Refreshing);
      }

      protected void standaloneModal2194( )
      {
      }

      protected void Load2194( )
      {
         /* Using cursor T002116 */
         pr_default.execute(14, new Object[] {A554OperacionesId, A650OperacionesSolicitudesId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound94 = 1;
            A651OperacionesSolicitudesNombre = T002116_A651OperacionesSolicitudesNombre[0];
            n651OperacionesSolicitudesNombre = T002116_n651OperacionesSolicitudesNombre[0];
            A654OperacionesSolicitudesPFinal = T002116_A654OperacionesSolicitudesPFinal[0];
            n654OperacionesSolicitudesPFinal = T002116_n654OperacionesSolicitudesPFinal[0];
            A653OperacionesSolicitudesComPro = T002116_A653OperacionesSolicitudesComPro[0];
            n653OperacionesSolicitudesComPro = T002116_n653OperacionesSolicitudesComPro[0];
            A660OperacionesSolicitudesProvID = T002116_A660OperacionesSolicitudesProvID[0];
            n660OperacionesSolicitudesProvID = T002116_n660OperacionesSolicitudesProvID[0];
            A661OperacionesSolicitudesProvNomb = T002116_A661OperacionesSolicitudesProvNomb[0];
            n661OperacionesSolicitudesProvNomb = T002116_n661OperacionesSolicitudesProvNomb[0];
            A655OperacionesSolicitudesComProv = T002116_A655OperacionesSolicitudesComProv[0];
            n655OperacionesSolicitudesComProv = T002116_n655OperacionesSolicitudesComProv[0];
            A656OperacionesSolicitudesComALM = T002116_A656OperacionesSolicitudesComALM[0];
            n656OperacionesSolicitudesComALM = T002116_n656OperacionesSolicitudesComALM[0];
            A1029OperacionesSolicitudesXZComPro = T002116_A1029OperacionesSolicitudesXZComPro[0];
            n1029OperacionesSolicitudesXZComPro = T002116_n1029OperacionesSolicitudesXZComPro[0];
            A1027OperacionesSolicitudesXZComAlm = T002116_A1027OperacionesSolicitudesXZComAlm[0];
            n1027OperacionesSolicitudesXZComAlm = T002116_n1027OperacionesSolicitudesXZComAlm[0];
            A668OperacionesSolicitudesOrigenPa = T002116_A668OperacionesSolicitudesOrigenPa[0];
            n668OperacionesSolicitudesOrigenPa = T002116_n668OperacionesSolicitudesOrigenPa[0];
            ZM2194( -24) ;
         }
         pr_default.close(14);
         OnLoadActions2194( ) ;
      }

      protected void OnLoadActions2194( )
      {
      }

      protected void CheckExtendedTable2194( )
      {
         nIsDirty_94 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal2194( ) ;
      }

      protected void CloseExtendedTableCursors2194( )
      {
      }

      protected void enableDisable2194( )
      {
      }

      protected void GetKey2194( )
      {
         /* Using cursor T002117 */
         pr_default.execute(15, new Object[] {A554OperacionesId, A650OperacionesSolicitudesId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound94 = 1;
         }
         else
         {
            RcdFound94 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey2194( )
      {
         /* Using cursor T00213 */
         pr_default.execute(1, new Object[] {A554OperacionesId, A650OperacionesSolicitudesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2194( 24) ;
            RcdFound94 = 1;
            InitializeNonKey2194( ) ;
            A650OperacionesSolicitudesId = T00213_A650OperacionesSolicitudesId[0];
            A651OperacionesSolicitudesNombre = T00213_A651OperacionesSolicitudesNombre[0];
            n651OperacionesSolicitudesNombre = T00213_n651OperacionesSolicitudesNombre[0];
            A654OperacionesSolicitudesPFinal = T00213_A654OperacionesSolicitudesPFinal[0];
            n654OperacionesSolicitudesPFinal = T00213_n654OperacionesSolicitudesPFinal[0];
            A653OperacionesSolicitudesComPro = T00213_A653OperacionesSolicitudesComPro[0];
            n653OperacionesSolicitudesComPro = T00213_n653OperacionesSolicitudesComPro[0];
            A660OperacionesSolicitudesProvID = T00213_A660OperacionesSolicitudesProvID[0];
            n660OperacionesSolicitudesProvID = T00213_n660OperacionesSolicitudesProvID[0];
            A661OperacionesSolicitudesProvNomb = T00213_A661OperacionesSolicitudesProvNomb[0];
            n661OperacionesSolicitudesProvNomb = T00213_n661OperacionesSolicitudesProvNomb[0];
            A655OperacionesSolicitudesComProv = T00213_A655OperacionesSolicitudesComProv[0];
            n655OperacionesSolicitudesComProv = T00213_n655OperacionesSolicitudesComProv[0];
            A656OperacionesSolicitudesComALM = T00213_A656OperacionesSolicitudesComALM[0];
            n656OperacionesSolicitudesComALM = T00213_n656OperacionesSolicitudesComALM[0];
            A1029OperacionesSolicitudesXZComPro = T00213_A1029OperacionesSolicitudesXZComPro[0];
            n1029OperacionesSolicitudesXZComPro = T00213_n1029OperacionesSolicitudesXZComPro[0];
            A1027OperacionesSolicitudesXZComAlm = T00213_A1027OperacionesSolicitudesXZComAlm[0];
            n1027OperacionesSolicitudesXZComAlm = T00213_n1027OperacionesSolicitudesXZComAlm[0];
            A668OperacionesSolicitudesOrigenPa = T00213_A668OperacionesSolicitudesOrigenPa[0];
            n668OperacionesSolicitudesOrigenPa = T00213_n668OperacionesSolicitudesOrigenPa[0];
            Z554OperacionesId = A554OperacionesId;
            Z650OperacionesSolicitudesId = A650OperacionesSolicitudesId;
            sMode94 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2194( ) ;
            Gx_mode = sMode94;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound94 = 0;
            InitializeNonKey2194( ) ;
            sMode94 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal2194( ) ;
            Gx_mode = sMode94;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2194( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency2194( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00212 */
            pr_default.execute(0, new Object[] {A554OperacionesId, A650OperacionesSolicitudesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"OperacionesSolicitudes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z651OperacionesSolicitudesNombre, T00212_A651OperacionesSolicitudesNombre[0]) != 0 ) || ( Z654OperacionesSolicitudesPFinal != T00212_A654OperacionesSolicitudesPFinal[0] ) || ( Z653OperacionesSolicitudesComPro != T00212_A653OperacionesSolicitudesComPro[0] ) || ( Z660OperacionesSolicitudesProvID != T00212_A660OperacionesSolicitudesProvID[0] ) || ( StringUtil.StrCmp(Z661OperacionesSolicitudesProvNomb, T00212_A661OperacionesSolicitudesProvNomb[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z655OperacionesSolicitudesComProv != T00212_A655OperacionesSolicitudesComProv[0] ) || ( Z656OperacionesSolicitudesComALM != T00212_A656OperacionesSolicitudesComALM[0] ) || ( Z1029OperacionesSolicitudesXZComPro != T00212_A1029OperacionesSolicitudesXZComPro[0] ) || ( Z1027OperacionesSolicitudesXZComAlm != T00212_A1027OperacionesSolicitudesXZComAlm[0] ) || ( StringUtil.StrCmp(Z668OperacionesSolicitudesOrigenPa, T00212_A668OperacionesSolicitudesOrigenPa[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z651OperacionesSolicitudesNombre, T00212_A651OperacionesSolicitudesNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesSolicitudesNombre");
                  GXUtil.WriteLogRaw("Old: ",Z651OperacionesSolicitudesNombre);
                  GXUtil.WriteLogRaw("Current: ",T00212_A651OperacionesSolicitudesNombre[0]);
               }
               if ( Z654OperacionesSolicitudesPFinal != T00212_A654OperacionesSolicitudesPFinal[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesSolicitudesPFinal");
                  GXUtil.WriteLogRaw("Old: ",Z654OperacionesSolicitudesPFinal);
                  GXUtil.WriteLogRaw("Current: ",T00212_A654OperacionesSolicitudesPFinal[0]);
               }
               if ( Z653OperacionesSolicitudesComPro != T00212_A653OperacionesSolicitudesComPro[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesSolicitudesComPro");
                  GXUtil.WriteLogRaw("Old: ",Z653OperacionesSolicitudesComPro);
                  GXUtil.WriteLogRaw("Current: ",T00212_A653OperacionesSolicitudesComPro[0]);
               }
               if ( Z660OperacionesSolicitudesProvID != T00212_A660OperacionesSolicitudesProvID[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesSolicitudesProvID");
                  GXUtil.WriteLogRaw("Old: ",Z660OperacionesSolicitudesProvID);
                  GXUtil.WriteLogRaw("Current: ",T00212_A660OperacionesSolicitudesProvID[0]);
               }
               if ( StringUtil.StrCmp(Z661OperacionesSolicitudesProvNomb, T00212_A661OperacionesSolicitudesProvNomb[0]) != 0 )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesSolicitudesProvNomb");
                  GXUtil.WriteLogRaw("Old: ",Z661OperacionesSolicitudesProvNomb);
                  GXUtil.WriteLogRaw("Current: ",T00212_A661OperacionesSolicitudesProvNomb[0]);
               }
               if ( Z655OperacionesSolicitudesComProv != T00212_A655OperacionesSolicitudesComProv[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesSolicitudesComProv");
                  GXUtil.WriteLogRaw("Old: ",Z655OperacionesSolicitudesComProv);
                  GXUtil.WriteLogRaw("Current: ",T00212_A655OperacionesSolicitudesComProv[0]);
               }
               if ( Z656OperacionesSolicitudesComALM != T00212_A656OperacionesSolicitudesComALM[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesSolicitudesComALM");
                  GXUtil.WriteLogRaw("Old: ",Z656OperacionesSolicitudesComALM);
                  GXUtil.WriteLogRaw("Current: ",T00212_A656OperacionesSolicitudesComALM[0]);
               }
               if ( Z1029OperacionesSolicitudesXZComPro != T00212_A1029OperacionesSolicitudesXZComPro[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesSolicitudesXZComPro");
                  GXUtil.WriteLogRaw("Old: ",Z1029OperacionesSolicitudesXZComPro);
                  GXUtil.WriteLogRaw("Current: ",T00212_A1029OperacionesSolicitudesXZComPro[0]);
               }
               if ( Z1027OperacionesSolicitudesXZComAlm != T00212_A1027OperacionesSolicitudesXZComAlm[0] )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesSolicitudesXZComAlm");
                  GXUtil.WriteLogRaw("Old: ",Z1027OperacionesSolicitudesXZComAlm);
                  GXUtil.WriteLogRaw("Current: ",T00212_A1027OperacionesSolicitudesXZComAlm[0]);
               }
               if ( StringUtil.StrCmp(Z668OperacionesSolicitudesOrigenPa, T00212_A668OperacionesSolicitudesOrigenPa[0]) != 0 )
               {
                  GXUtil.WriteLog("operaciones:[seudo value changed for attri]"+"OperacionesSolicitudesOrigenPa");
                  GXUtil.WriteLogRaw("Old: ",Z668OperacionesSolicitudesOrigenPa);
                  GXUtil.WriteLogRaw("Current: ",T00212_A668OperacionesSolicitudesOrigenPa[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"OperacionesSolicitudes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2194( )
      {
         BeforeValidate2194( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2194( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2194( 0) ;
            CheckOptimisticConcurrency2194( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2194( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2194( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002118 */
                     pr_default.execute(16, new Object[] {A554OperacionesId, A650OperacionesSolicitudesId, n651OperacionesSolicitudesNombre, A651OperacionesSolicitudesNombre, n654OperacionesSolicitudesPFinal, A654OperacionesSolicitudesPFinal, n653OperacionesSolicitudesComPro, A653OperacionesSolicitudesComPro, n660OperacionesSolicitudesProvID, A660OperacionesSolicitudesProvID, n661OperacionesSolicitudesProvNomb, A661OperacionesSolicitudesProvNomb, n655OperacionesSolicitudesComProv, A655OperacionesSolicitudesComProv, n656OperacionesSolicitudesComALM, A656OperacionesSolicitudesComALM, n1029OperacionesSolicitudesXZComPro, A1029OperacionesSolicitudesXZComPro, n1027OperacionesSolicitudesXZComAlm, A1027OperacionesSolicitudesXZComAlm, n668OperacionesSolicitudesOrigenPa, A668OperacionesSolicitudesOrigenPa});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("OperacionesSolicitudes");
                     if ( (pr_default.getStatus(16) == 1) )
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
               Load2194( ) ;
            }
            EndLevel2194( ) ;
         }
         CloseExtendedTableCursors2194( ) ;
      }

      protected void Update2194( )
      {
         BeforeValidate2194( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2194( ) ;
         }
         if ( ( nIsMod_94 != 0 ) || ( nIsDirty_94 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency2194( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm2194( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate2194( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T002119 */
                        pr_default.execute(17, new Object[] {n651OperacionesSolicitudesNombre, A651OperacionesSolicitudesNombre, n654OperacionesSolicitudesPFinal, A654OperacionesSolicitudesPFinal, n653OperacionesSolicitudesComPro, A653OperacionesSolicitudesComPro, n660OperacionesSolicitudesProvID, A660OperacionesSolicitudesProvID, n661OperacionesSolicitudesProvNomb, A661OperacionesSolicitudesProvNomb, n655OperacionesSolicitudesComProv, A655OperacionesSolicitudesComProv, n656OperacionesSolicitudesComALM, A656OperacionesSolicitudesComALM, n1029OperacionesSolicitudesXZComPro, A1029OperacionesSolicitudesXZComPro, n1027OperacionesSolicitudesXZComAlm, A1027OperacionesSolicitudesXZComAlm, n668OperacionesSolicitudesOrigenPa, A668OperacionesSolicitudesOrigenPa, A554OperacionesId, A650OperacionesSolicitudesId});
                        pr_default.close(17);
                        pr_default.SmartCacheProvider.SetUpdated("OperacionesSolicitudes");
                        if ( (pr_default.getStatus(17) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"OperacionesSolicitudes"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate2194( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey2194( ) ;
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
               EndLevel2194( ) ;
            }
         }
         CloseExtendedTableCursors2194( ) ;
      }

      protected void DeferredUpdate2194( )
      {
      }

      protected void Delete2194( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2194( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2194( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2194( ) ;
            AfterConfirm2194( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2194( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002120 */
                  pr_default.execute(18, new Object[] {A554OperacionesId, A650OperacionesSolicitudesId});
                  pr_default.close(18);
                  pr_default.SmartCacheProvider.SetUpdated("OperacionesSolicitudes");
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
         sMode94 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2194( ) ;
         Gx_mode = sMode94;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2194( )
      {
         standaloneModal2194( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2194( )
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

      public void ScanStart2194( )
      {
         /* Scan By routine */
         /* Using cursor T002121 */
         pr_default.execute(19, new Object[] {A554OperacionesId});
         RcdFound94 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound94 = 1;
            A650OperacionesSolicitudesId = T002121_A650OperacionesSolicitudesId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2194( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound94 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound94 = 1;
            A650OperacionesSolicitudesId = T002121_A650OperacionesSolicitudesId[0];
         }
      }

      protected void ScanEnd2194( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm2194( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2194( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2194( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2194( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2194( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2194( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2194( )
      {
         edtOperacionesSolicitudesId_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesId_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesNombre_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesNombre_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesPFinal_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesPFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesPFinal_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesComPro_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesComPro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesComPro_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesProvID_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesProvID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesProvID_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesProvNomb_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesProvNomb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesProvNomb_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesComProv_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesComProv_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesComProv_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesComALM_Enabled = 0;
         AssignProp("", false, edtOperacionesSolicitudesComALM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesComALM_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         cmbOperacionesSolicitudesOrigenPa.Enabled = 0;
         AssignProp("", false, cmbOperacionesSolicitudesOrigenPa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbOperacionesSolicitudesOrigenPa.Enabled), 5, 0), !bGXsfl_128_Refreshing);
      }

      protected void send_integrity_lvl_hashes2194( )
      {
      }

      protected void send_integrity_lvl_hashes2182( )
      {
      }

      protected void SubsflControlProps_12894( )
      {
         edtOperacionesSolicitudesId_Internalname = "OPERACIONESSOLICITUDESID_"+sGXsfl_128_idx;
         edtOperacionesSolicitudesNombre_Internalname = "OPERACIONESSOLICITUDESNOMBRE_"+sGXsfl_128_idx;
         edtOperacionesSolicitudesPFinal_Internalname = "OPERACIONESSOLICITUDESPFINAL_"+sGXsfl_128_idx;
         edtOperacionesSolicitudesComPro_Internalname = "OPERACIONESSOLICITUDESCOMPRO_"+sGXsfl_128_idx;
         edtOperacionesSolicitudesProvID_Internalname = "OPERACIONESSOLICITUDESPROVID_"+sGXsfl_128_idx;
         edtOperacionesSolicitudesProvNomb_Internalname = "OPERACIONESSOLICITUDESPROVNOMB_"+sGXsfl_128_idx;
         edtOperacionesSolicitudesComProv_Internalname = "OPERACIONESSOLICITUDESCOMPROV_"+sGXsfl_128_idx;
         edtOperacionesSolicitudesComALM_Internalname = "OPERACIONESSOLICITUDESCOMALM_"+sGXsfl_128_idx;
         cmbOperacionesSolicitudesOrigenPa_Internalname = "OPERACIONESSOLICITUDESORIGENPA_"+sGXsfl_128_idx;
      }

      protected void SubsflControlProps_fel_12894( )
      {
         edtOperacionesSolicitudesId_Internalname = "OPERACIONESSOLICITUDESID_"+sGXsfl_128_fel_idx;
         edtOperacionesSolicitudesNombre_Internalname = "OPERACIONESSOLICITUDESNOMBRE_"+sGXsfl_128_fel_idx;
         edtOperacionesSolicitudesPFinal_Internalname = "OPERACIONESSOLICITUDESPFINAL_"+sGXsfl_128_fel_idx;
         edtOperacionesSolicitudesComPro_Internalname = "OPERACIONESSOLICITUDESCOMPRO_"+sGXsfl_128_fel_idx;
         edtOperacionesSolicitudesProvID_Internalname = "OPERACIONESSOLICITUDESPROVID_"+sGXsfl_128_fel_idx;
         edtOperacionesSolicitudesProvNomb_Internalname = "OPERACIONESSOLICITUDESPROVNOMB_"+sGXsfl_128_fel_idx;
         edtOperacionesSolicitudesComProv_Internalname = "OPERACIONESSOLICITUDESCOMPROV_"+sGXsfl_128_fel_idx;
         edtOperacionesSolicitudesComALM_Internalname = "OPERACIONESSOLICITUDESCOMALM_"+sGXsfl_128_fel_idx;
         cmbOperacionesSolicitudesOrigenPa_Internalname = "OPERACIONESSOLICITUDESORIGENPA_"+sGXsfl_128_fel_idx;
      }

      protected void AddRow2194( )
      {
         nGXsfl_128_idx = (int)(nGXsfl_128_idx+1);
         sGXsfl_128_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_128_idx), 4, 0), 4, "0");
         SubsflControlProps_12894( ) ;
         SendRow2194( ) ;
      }

      protected void SendRow2194( )
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
            if ( ((int)((nGXsfl_128_idx) % (2))) == 0 )
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
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_94_" + sGXsfl_128_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 129,'',false,'" + sGXsfl_128_idx + "',128)\"";
         ROClassString = "Attribute";
         Gridlevel_solicitudesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesSolicitudesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A650OperacionesSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtOperacionesSolicitudesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A650OperacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A650OperacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,129);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesSolicitudesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtOperacionesSolicitudesId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)128,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_94_" + sGXsfl_128_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 130,'',false,'" + sGXsfl_128_idx + "',128)\"";
         ROClassString = "Attribute";
         Gridlevel_solicitudesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesSolicitudesNombre_Internalname,StringUtil.RTrim( A651OperacionesSolicitudesNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,130);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesSolicitudesNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtOperacionesSolicitudesNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)128,(short)0,(short)-1,(short)-1,(bool)true,(string)"NombreLargo",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_94_" + sGXsfl_128_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 131,'',false,'" + sGXsfl_128_idx + "',128)\"";
         ROClassString = "Attribute";
         Gridlevel_solicitudesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesSolicitudesPFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A654OperacionesSolicitudesPFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtOperacionesSolicitudesPFinal_Enabled!=0) ? context.localUtil.Format( A654OperacionesSolicitudesPFinal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A654OperacionesSolicitudesPFinal, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,131);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesSolicitudesPFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtOperacionesSolicitudesPFinal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)128,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_94_" + sGXsfl_128_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 132,'',false,'" + sGXsfl_128_idx + "',128)\"";
         ROClassString = "Attribute";
         Gridlevel_solicitudesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesSolicitudesComPro_Internalname,StringUtil.LTrim( StringUtil.NToC( A653OperacionesSolicitudesComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtOperacionesSolicitudesComPro_Enabled!=0) ? context.localUtil.Format( A653OperacionesSolicitudesComPro, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A653OperacionesSolicitudesComPro, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,132);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesSolicitudesComPro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtOperacionesSolicitudesComPro_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)128,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_94_" + sGXsfl_128_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 133,'',false,'" + sGXsfl_128_idx + "',128)\"";
         ROClassString = "Attribute";
         Gridlevel_solicitudesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesSolicitudesProvID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A660OperacionesSolicitudesProvID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtOperacionesSolicitudesProvID_Enabled!=0) ? context.localUtil.Format( (decimal)(A660OperacionesSolicitudesProvID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A660OperacionesSolicitudesProvID), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,133);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesSolicitudesProvID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtOperacionesSolicitudesProvID_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)128,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_94_" + sGXsfl_128_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 134,'',false,'" + sGXsfl_128_idx + "',128)\"";
         ROClassString = "Attribute";
         Gridlevel_solicitudesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesSolicitudesProvNomb_Internalname,StringUtil.RTrim( A661OperacionesSolicitudesProvNomb),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesSolicitudesProvNomb_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtOperacionesSolicitudesProvNomb_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)128,(short)0,(short)-1,(short)-1,(bool)true,(string)"NombreLargo",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_94_" + sGXsfl_128_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 135,'',false,'" + sGXsfl_128_idx + "',128)\"";
         ROClassString = "Attribute";
         Gridlevel_solicitudesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesSolicitudesComProv_Internalname,StringUtil.LTrim( StringUtil.NToC( A655OperacionesSolicitudesComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtOperacionesSolicitudesComProv_Enabled!=0) ? context.localUtil.Format( A655OperacionesSolicitudesComProv, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A655OperacionesSolicitudesComProv, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,135);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesSolicitudesComProv_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtOperacionesSolicitudesComProv_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)128,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_94_" + sGXsfl_128_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 136,'',false,'" + sGXsfl_128_idx + "',128)\"";
         ROClassString = "Attribute";
         Gridlevel_solicitudesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesSolicitudesComALM_Internalname,StringUtil.LTrim( StringUtil.NToC( A656OperacionesSolicitudesComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtOperacionesSolicitudesComALM_Enabled!=0) ? context.localUtil.Format( A656OperacionesSolicitudesComALM, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A656OperacionesSolicitudesComALM, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,136);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesSolicitudesComALM_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtOperacionesSolicitudesComALM_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)128,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_94_" + sGXsfl_128_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 137,'',false,'" + sGXsfl_128_idx + "',128)\"";
         if ( ( cmbOperacionesSolicitudesOrigenPa.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "OPERACIONESSOLICITUDESORIGENPA_" + sGXsfl_128_idx;
            cmbOperacionesSolicitudesOrigenPa.Name = GXCCtl;
            cmbOperacionesSolicitudesOrigenPa.WebTags = "";
            cmbOperacionesSolicitudesOrigenPa.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
            cmbOperacionesSolicitudesOrigenPa.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
            cmbOperacionesSolicitudesOrigenPa.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
            if ( cmbOperacionesSolicitudesOrigenPa.ItemCount > 0 )
            {
               A668OperacionesSolicitudesOrigenPa = cmbOperacionesSolicitudesOrigenPa.getValidValue(A668OperacionesSolicitudesOrigenPa);
               n668OperacionesSolicitudesOrigenPa = false;
            }
         }
         /* ComboBox */
         Gridlevel_solicitudesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbOperacionesSolicitudesOrigenPa,(string)cmbOperacionesSolicitudesOrigenPa_Internalname,StringUtil.RTrim( A668OperacionesSolicitudesOrigenPa),(short)1,(string)cmbOperacionesSolicitudesOrigenPa_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbOperacionesSolicitudesOrigenPa.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,137);\"",(string)"",(bool)true,(short)0});
         cmbOperacionesSolicitudesOrigenPa.CurrentValue = StringUtil.RTrim( A668OperacionesSolicitudesOrigenPa);
         AssignProp("", false, cmbOperacionesSolicitudesOrigenPa_Internalname, "Values", (string)(cmbOperacionesSolicitudesOrigenPa.ToJavascriptSource()), !bGXsfl_128_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_solicitudesRow);
         send_integrity_lvl_hashes2194( ) ;
         GXCCtl = "Z650OperacionesSolicitudesId_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z650OperacionesSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z651OperacionesSolicitudesNombre_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z651OperacionesSolicitudesNombre));
         GXCCtl = "Z654OperacionesSolicitudesPFinal_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z654OperacionesSolicitudesPFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z653OperacionesSolicitudesComPro_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z653OperacionesSolicitudesComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z660OperacionesSolicitudesProvID_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z660OperacionesSolicitudesProvID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z661OperacionesSolicitudesProvNomb_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z661OperacionesSolicitudesProvNomb));
         GXCCtl = "Z655OperacionesSolicitudesComProv_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z655OperacionesSolicitudesComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z656OperacionesSolicitudesComALM_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z656OperacionesSolicitudesComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z1029OperacionesSolicitudesXZComPro_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z1029OperacionesSolicitudesXZComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z1027OperacionesSolicitudesXZComAlm_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z1027OperacionesSolicitudesXZComAlm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z668OperacionesSolicitudesOrigenPa_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z668OperacionesSolicitudesOrigenPa));
         GXCCtl = "nRcdDeleted_94_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_94), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_94_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_94), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_94_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_94), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_128_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vOPERACIONESID_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7OperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESID_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESNOMBRE_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESPFINAL_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesPFinal_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESCOMPRO_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesComPro_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESPROVID_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesProvID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESPROVNOMB_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesProvNomb_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESCOMPROV_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesComProv_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESCOMALM_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesComALM_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESORIGENPA_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbOperacionesSolicitudesOrigenPa.Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_solicitudesContainer.AddRow(Gridlevel_solicitudesRow);
      }

      protected void ReadRow2194( )
      {
         nGXsfl_128_idx = (int)(nGXsfl_128_idx+1);
         sGXsfl_128_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_128_idx), 4, 0), 4, "0");
         SubsflControlProps_12894( ) ;
         edtOperacionesSolicitudesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESID_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtOperacionesSolicitudesNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESNOMBRE_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtOperacionesSolicitudesPFinal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESPFINAL_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtOperacionesSolicitudesComPro_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESCOMPRO_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtOperacionesSolicitudesProvID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESPROVID_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtOperacionesSolicitudesProvNomb_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESPROVNOMB_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtOperacionesSolicitudesComProv_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESCOMPROV_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtOperacionesSolicitudesComALM_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESCOMALM_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbOperacionesSolicitudesOrigenPa.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "OPERACIONESSOLICITUDESORIGENPA_"+sGXsfl_128_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A650OperacionesSolicitudesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesSolicitudesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A651OperacionesSolicitudesNombre = cgiGet( edtOperacionesSolicitudesNombre_Internalname);
         n651OperacionesSolicitudesNombre = false;
         A654OperacionesSolicitudesPFinal = context.localUtil.CToN( cgiGet( edtOperacionesSolicitudesPFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         n654OperacionesSolicitudesPFinal = false;
         A653OperacionesSolicitudesComPro = context.localUtil.CToN( cgiGet( edtOperacionesSolicitudesComPro_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         n653OperacionesSolicitudesComPro = false;
         A660OperacionesSolicitudesProvID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesSolicitudesProvID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n660OperacionesSolicitudesProvID = false;
         A661OperacionesSolicitudesProvNomb = cgiGet( edtOperacionesSolicitudesProvNomb_Internalname);
         n661OperacionesSolicitudesProvNomb = false;
         A655OperacionesSolicitudesComProv = context.localUtil.CToN( cgiGet( edtOperacionesSolicitudesComProv_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         n655OperacionesSolicitudesComProv = false;
         A656OperacionesSolicitudesComALM = context.localUtil.CToN( cgiGet( edtOperacionesSolicitudesComALM_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         n656OperacionesSolicitudesComALM = false;
         cmbOperacionesSolicitudesOrigenPa.Name = cmbOperacionesSolicitudesOrigenPa_Internalname;
         cmbOperacionesSolicitudesOrigenPa.CurrentValue = cgiGet( cmbOperacionesSolicitudesOrigenPa_Internalname);
         A668OperacionesSolicitudesOrigenPa = cgiGet( cmbOperacionesSolicitudesOrigenPa_Internalname);
         n668OperacionesSolicitudesOrigenPa = false;
         GXCCtl = "Z650OperacionesSolicitudesId_" + sGXsfl_128_idx;
         Z650OperacionesSolicitudesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z651OperacionesSolicitudesNombre_" + sGXsfl_128_idx;
         Z651OperacionesSolicitudesNombre = cgiGet( GXCCtl);
         n651OperacionesSolicitudesNombre = (String.IsNullOrEmpty(StringUtil.RTrim( A651OperacionesSolicitudesNombre)) ? true : false);
         GXCCtl = "Z654OperacionesSolicitudesPFinal_" + sGXsfl_128_idx;
         Z654OperacionesSolicitudesPFinal = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         n654OperacionesSolicitudesPFinal = ((Convert.ToDecimal(0)==A654OperacionesSolicitudesPFinal) ? true : false);
         GXCCtl = "Z653OperacionesSolicitudesComPro_" + sGXsfl_128_idx;
         Z653OperacionesSolicitudesComPro = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         n653OperacionesSolicitudesComPro = ((Convert.ToDecimal(0)==A653OperacionesSolicitudesComPro) ? true : false);
         GXCCtl = "Z660OperacionesSolicitudesProvID_" + sGXsfl_128_idx;
         Z660OperacionesSolicitudesProvID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n660OperacionesSolicitudesProvID = ((0==A660OperacionesSolicitudesProvID) ? true : false);
         GXCCtl = "Z661OperacionesSolicitudesProvNomb_" + sGXsfl_128_idx;
         Z661OperacionesSolicitudesProvNomb = cgiGet( GXCCtl);
         n661OperacionesSolicitudesProvNomb = (String.IsNullOrEmpty(StringUtil.RTrim( A661OperacionesSolicitudesProvNomb)) ? true : false);
         GXCCtl = "Z655OperacionesSolicitudesComProv_" + sGXsfl_128_idx;
         Z655OperacionesSolicitudesComProv = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         n655OperacionesSolicitudesComProv = ((Convert.ToDecimal(0)==A655OperacionesSolicitudesComProv) ? true : false);
         GXCCtl = "Z656OperacionesSolicitudesComALM_" + sGXsfl_128_idx;
         Z656OperacionesSolicitudesComALM = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         n656OperacionesSolicitudesComALM = ((Convert.ToDecimal(0)==A656OperacionesSolicitudesComALM) ? true : false);
         GXCCtl = "Z1029OperacionesSolicitudesXZComPro_" + sGXsfl_128_idx;
         Z1029OperacionesSolicitudesXZComPro = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         n1029OperacionesSolicitudesXZComPro = ((Convert.ToDecimal(0)==A1029OperacionesSolicitudesXZComPro) ? true : false);
         GXCCtl = "Z1027OperacionesSolicitudesXZComAlm_" + sGXsfl_128_idx;
         Z1027OperacionesSolicitudesXZComAlm = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         n1027OperacionesSolicitudesXZComAlm = ((Convert.ToDecimal(0)==A1027OperacionesSolicitudesXZComAlm) ? true : false);
         GXCCtl = "Z668OperacionesSolicitudesOrigenPa_" + sGXsfl_128_idx;
         Z668OperacionesSolicitudesOrigenPa = cgiGet( GXCCtl);
         n668OperacionesSolicitudesOrigenPa = (String.IsNullOrEmpty(StringUtil.RTrim( A668OperacionesSolicitudesOrigenPa)) ? true : false);
         GXCCtl = "Z1029OperacionesSolicitudesXZComPro_" + sGXsfl_128_idx;
         A1029OperacionesSolicitudesXZComPro = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         n1029OperacionesSolicitudesXZComPro = false;
         n1029OperacionesSolicitudesXZComPro = ((Convert.ToDecimal(0)==A1029OperacionesSolicitudesXZComPro) ? true : false);
         GXCCtl = "Z1027OperacionesSolicitudesXZComAlm_" + sGXsfl_128_idx;
         A1027OperacionesSolicitudesXZComAlm = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         n1027OperacionesSolicitudesXZComAlm = false;
         n1027OperacionesSolicitudesXZComAlm = ((Convert.ToDecimal(0)==A1027OperacionesSolicitudesXZComAlm) ? true : false);
         GXCCtl = "nRcdDeleted_94_" + sGXsfl_128_idx;
         nRcdDeleted_94 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_94_" + sGXsfl_128_idx;
         nRcdExists_94 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_94_" + sGXsfl_128_idx;
         nIsMod_94 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defcmbOperacionesSolicitudesOrigenPa_Enabled = cmbOperacionesSolicitudesOrigenPa.Enabled;
         defedtOperacionesSolicitudesComALM_Enabled = edtOperacionesSolicitudesComALM_Enabled;
         defedtOperacionesSolicitudesComProv_Enabled = edtOperacionesSolicitudesComProv_Enabled;
         defedtOperacionesSolicitudesProvNomb_Enabled = edtOperacionesSolicitudesProvNomb_Enabled;
         defedtOperacionesSolicitudesProvID_Enabled = edtOperacionesSolicitudesProvID_Enabled;
         defedtOperacionesSolicitudesComPro_Enabled = edtOperacionesSolicitudesComPro_Enabled;
         defedtOperacionesSolicitudesPFinal_Enabled = edtOperacionesSolicitudesPFinal_Enabled;
         defedtOperacionesSolicitudesNombre_Enabled = edtOperacionesSolicitudesNombre_Enabled;
         defedtOperacionesSolicitudesId_Enabled = edtOperacionesSolicitudesId_Enabled;
      }

      protected void ConfirmValues210( )
      {
         nGXsfl_128_idx = 0;
         sGXsfl_128_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_128_idx), 4, 0), 4, "0");
         SubsflControlProps_12894( ) ;
         while ( nGXsfl_128_idx < nRC_GXsfl_128 )
         {
            nGXsfl_128_idx = (int)(nGXsfl_128_idx+1);
            sGXsfl_128_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_128_idx), 4, 0), 4, "0");
            SubsflControlProps_12894( ) ;
            ChangePostValue( "Z650OperacionesSolicitudesId_"+sGXsfl_128_idx, cgiGet( "ZT_"+"Z650OperacionesSolicitudesId_"+sGXsfl_128_idx)) ;
            DeletePostValue( "ZT_"+"Z650OperacionesSolicitudesId_"+sGXsfl_128_idx) ;
            ChangePostValue( "Z651OperacionesSolicitudesNombre_"+sGXsfl_128_idx, cgiGet( "ZT_"+"Z651OperacionesSolicitudesNombre_"+sGXsfl_128_idx)) ;
            DeletePostValue( "ZT_"+"Z651OperacionesSolicitudesNombre_"+sGXsfl_128_idx) ;
            ChangePostValue( "Z654OperacionesSolicitudesPFinal_"+sGXsfl_128_idx, cgiGet( "ZT_"+"Z654OperacionesSolicitudesPFinal_"+sGXsfl_128_idx)) ;
            DeletePostValue( "ZT_"+"Z654OperacionesSolicitudesPFinal_"+sGXsfl_128_idx) ;
            ChangePostValue( "Z653OperacionesSolicitudesComPro_"+sGXsfl_128_idx, cgiGet( "ZT_"+"Z653OperacionesSolicitudesComPro_"+sGXsfl_128_idx)) ;
            DeletePostValue( "ZT_"+"Z653OperacionesSolicitudesComPro_"+sGXsfl_128_idx) ;
            ChangePostValue( "Z660OperacionesSolicitudesProvID_"+sGXsfl_128_idx, cgiGet( "ZT_"+"Z660OperacionesSolicitudesProvID_"+sGXsfl_128_idx)) ;
            DeletePostValue( "ZT_"+"Z660OperacionesSolicitudesProvID_"+sGXsfl_128_idx) ;
            ChangePostValue( "Z661OperacionesSolicitudesProvNomb_"+sGXsfl_128_idx, cgiGet( "ZT_"+"Z661OperacionesSolicitudesProvNomb_"+sGXsfl_128_idx)) ;
            DeletePostValue( "ZT_"+"Z661OperacionesSolicitudesProvNomb_"+sGXsfl_128_idx) ;
            ChangePostValue( "Z655OperacionesSolicitudesComProv_"+sGXsfl_128_idx, cgiGet( "ZT_"+"Z655OperacionesSolicitudesComProv_"+sGXsfl_128_idx)) ;
            DeletePostValue( "ZT_"+"Z655OperacionesSolicitudesComProv_"+sGXsfl_128_idx) ;
            ChangePostValue( "Z656OperacionesSolicitudesComALM_"+sGXsfl_128_idx, cgiGet( "ZT_"+"Z656OperacionesSolicitudesComALM_"+sGXsfl_128_idx)) ;
            DeletePostValue( "ZT_"+"Z656OperacionesSolicitudesComALM_"+sGXsfl_128_idx) ;
            ChangePostValue( "Z1029OperacionesSolicitudesXZComPro_"+sGXsfl_128_idx, cgiGet( "ZT_"+"Z1029OperacionesSolicitudesXZComPro_"+sGXsfl_128_idx)) ;
            DeletePostValue( "ZT_"+"Z1029OperacionesSolicitudesXZComPro_"+sGXsfl_128_idx) ;
            ChangePostValue( "Z1027OperacionesSolicitudesXZComAlm_"+sGXsfl_128_idx, cgiGet( "ZT_"+"Z1027OperacionesSolicitudesXZComAlm_"+sGXsfl_128_idx)) ;
            DeletePostValue( "ZT_"+"Z1027OperacionesSolicitudesXZComAlm_"+sGXsfl_128_idx) ;
            ChangePostValue( "Z668OperacionesSolicitudesOrigenPa_"+sGXsfl_128_idx, cgiGet( "ZT_"+"Z668OperacionesSolicitudesOrigenPa_"+sGXsfl_128_idx)) ;
            DeletePostValue( "ZT_"+"Z668OperacionesSolicitudesOrigenPa_"+sGXsfl_128_idx) ;
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
         GXEncryptionTmp = "operaciones.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7OperacionesId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("operaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Operaciones");
         forbiddenHiddens.Add("OperacionesUsrAlta", context.localUtil.Format( (decimal)(A666OperacionesUsrAlta), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("OperacionesUsrActualizacion", context.localUtil.Format( (decimal)(A667OperacionesUsrActualizacion), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("OperacionesComercioId1", context.localUtil.Format( (decimal)(A962OperacionesComercioId1), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("OperacionesComercioId2", context.localUtil.Format( (decimal)(A963OperacionesComercioId2), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("OperacionesPeriodoCod", StringUtil.RTrim( context.localUtil.Format( A1028OperacionesPeriodoCod, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("operaciones:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z554OperacionesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z554OperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z649OperacionesTipo", StringUtil.RTrim( Z649OperacionesTipo));
         GxWebStd.gx_hidden_field( context, "Z962OperacionesComercioId1", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z962OperacionesComercioId1), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z963OperacionesComercioId2", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z963OperacionesComercioId2), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z555OperacionesRef", StringUtil.RTrim( Z555OperacionesRef));
         GxWebStd.gx_hidden_field( context, "Z657OperacionesNombreRef", StringUtil.RTrim( Z657OperacionesNombreRef));
         GxWebStd.gx_hidden_field( context, "Z579OperacionesOrdinal", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z579OperacionesOrdinal), 12, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z586OperacionesIDORD", StringUtil.RTrim( Z586OperacionesIDORD));
         GxWebStd.gx_hidden_field( context, "Z569OperacionesTipoES", StringUtil.RTrim( Z569OperacionesTipoES));
         GxWebStd.gx_hidden_field( context, "Z570OperacionesImporte", StringUtil.LTrim( StringUtil.NToC( Z570OperacionesImporte, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z662OperacionesMonId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z662OperacionesMonId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z571OperacionesMoneda", StringUtil.RTrim( Z571OperacionesMoneda));
         GxWebStd.gx_hidden_field( context, "Z572OperacionesFacturaCod", StringUtil.RTrim( Z572OperacionesFacturaCod));
         GxWebStd.gx_hidden_field( context, "Z573OperacionesIva", StringUtil.LTrim( StringUtil.NToC( Z573OperacionesIva, 4, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z574OperacionesComision", StringUtil.LTrim( StringUtil.NToC( Z574OperacionesComision, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z578OperacionesImporteGrabado", StringUtil.LTrim( StringUtil.NToC( Z578OperacionesImporteGrabado, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z580OperacionesComprobantePago", StringUtil.RTrim( Z580OperacionesComprobantePago));
         GxWebStd.gx_hidden_field( context, "Z581OperacionesFechaAlta", context.localUtil.DToC( Z581OperacionesFechaAlta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z582OperacionesFechaPago", context.localUtil.TToC( Z582OperacionesFechaPago, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z583OperacionesAux1", Z583OperacionesAux1);
         GxWebStd.gx_hidden_field( context, "Z584OperacionesAux2", Z584OperacionesAux2);
         GxWebStd.gx_hidden_field( context, "Z658OperacionesFechaDesde", context.localUtil.DToC( Z658OperacionesFechaDesde, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z659OperacionesFechaHasta", context.localUtil.DToC( Z659OperacionesFechaHasta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1028OperacionesPeriodoCod", Z1028OperacionesPeriodoCod);
         GxWebStd.gx_hidden_field( context, "Z577OperacionesEstado", StringUtil.RTrim( Z577OperacionesEstado));
         GxWebStd.gx_hidden_field( context, "Z666OperacionesUsrAlta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z666OperacionesUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z667OperacionesUsrActualizacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z667OperacionesUsrActualizacion), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_128", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_128_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vOPERACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7OperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vOPERACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7OperacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "OPERACIONESCOMERCIOID1", StringUtil.LTrim( StringUtil.NToC( (decimal)(A962OperacionesComercioId1), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "OPERACIONESCOMERCIOID2", StringUtil.LTrim( StringUtil.NToC( (decimal)(A963OperacionesComercioId2), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "OPERACIONESPERIODOCOD", A1028OperacionesPeriodoCod);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV17Pgmname));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESXZCOMPRO", StringUtil.LTrim( StringUtil.NToC( A1029OperacionesSolicitudesXZComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESXZCOMALM", StringUtil.LTrim( StringUtil.NToC( A1027OperacionesSolicitudesXZComAlm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtlgxBlob = "OPERACIONESBLOB1" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A663OperacionesBlob1);
         GXCCtlgxBlob = "OPERACIONESBLOB2" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A664OperacionesBlob2);
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Objectcall", StringUtil.RTrim( Gxuitabspanel_tabs_Objectcall));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Enabled", StringUtil.BoolToStr( Gxuitabspanel_tabs_Enabled));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Class", StringUtil.RTrim( Gxuitabspanel_tabs_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs_Historymanagement));
         GxWebStd.gx_hidden_field( context, "OPERACIONESBLOB1_Filename", StringUtil.RTrim( edtOperacionesBlob1_Filename));
         GxWebStd.gx_hidden_field( context, "OPERACIONESBLOB2_Filename", StringUtil.RTrim( edtOperacionesBlob2_Filename));
         GxWebStd.gx_hidden_field( context, "OPERACIONESBLOB1_Filetype", StringUtil.RTrim( edtOperacionesBlob1_Filetype));
         GxWebStd.gx_hidden_field( context, "OPERACIONESBLOB2_Filetype", StringUtil.RTrim( edtOperacionesBlob2_Filetype));
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
         GXEncryptionTmp = "operaciones.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7OperacionesId,18,0));
         return formatLink("operaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Operaciones" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Operaciones", "") ;
      }

      protected void InitializeNonKey2182( )
      {
         A962OperacionesComercioId1 = 0;
         n962OperacionesComercioId1 = false;
         AssignAttri("", false, "A962OperacionesComercioId1", StringUtil.LTrimStr( (decimal)(A962OperacionesComercioId1), 18, 0));
         A963OperacionesComercioId2 = 0;
         n963OperacionesComercioId2 = false;
         AssignAttri("", false, "A963OperacionesComercioId2", StringUtil.LTrimStr( (decimal)(A963OperacionesComercioId2), 18, 0));
         A555OperacionesRef = "";
         n555OperacionesRef = false;
         AssignAttri("", false, "A555OperacionesRef", A555OperacionesRef);
         n555OperacionesRef = (String.IsNullOrEmpty(StringUtil.RTrim( A555OperacionesRef)) ? true : false);
         A657OperacionesNombreRef = "";
         n657OperacionesNombreRef = false;
         AssignAttri("", false, "A657OperacionesNombreRef", A657OperacionesNombreRef);
         n657OperacionesNombreRef = (String.IsNullOrEmpty(StringUtil.RTrim( A657OperacionesNombreRef)) ? true : false);
         A579OperacionesOrdinal = 0;
         n579OperacionesOrdinal = false;
         AssignAttri("", false, "A579OperacionesOrdinal", StringUtil.LTrimStr( (decimal)(A579OperacionesOrdinal), 12, 0));
         n579OperacionesOrdinal = ((0==A579OperacionesOrdinal) ? true : false);
         A586OperacionesIDORD = "";
         n586OperacionesIDORD = false;
         AssignAttri("", false, "A586OperacionesIDORD", A586OperacionesIDORD);
         n586OperacionesIDORD = (String.IsNullOrEmpty(StringUtil.RTrim( A586OperacionesIDORD)) ? true : false);
         A569OperacionesTipoES = "";
         n569OperacionesTipoES = false;
         AssignAttri("", false, "A569OperacionesTipoES", A569OperacionesTipoES);
         n569OperacionesTipoES = (String.IsNullOrEmpty(StringUtil.RTrim( A569OperacionesTipoES)) ? true : false);
         A570OperacionesImporte = 0;
         n570OperacionesImporte = false;
         AssignAttri("", false, "A570OperacionesImporte", StringUtil.LTrimStr( A570OperacionesImporte, 18, 2));
         n570OperacionesImporte = ((Convert.ToDecimal(0)==A570OperacionesImporte) ? true : false);
         A662OperacionesMonId = 0;
         n662OperacionesMonId = false;
         AssignAttri("", false, "A662OperacionesMonId", StringUtil.LTrimStr( (decimal)(A662OperacionesMonId), 18, 0));
         n662OperacionesMonId = ((0==A662OperacionesMonId) ? true : false);
         A571OperacionesMoneda = "";
         n571OperacionesMoneda = false;
         AssignAttri("", false, "A571OperacionesMoneda", A571OperacionesMoneda);
         n571OperacionesMoneda = (String.IsNullOrEmpty(StringUtil.RTrim( A571OperacionesMoneda)) ? true : false);
         A572OperacionesFacturaCod = "";
         n572OperacionesFacturaCod = false;
         AssignAttri("", false, "A572OperacionesFacturaCod", A572OperacionesFacturaCod);
         n572OperacionesFacturaCod = (String.IsNullOrEmpty(StringUtil.RTrim( A572OperacionesFacturaCod)) ? true : false);
         A573OperacionesIva = 0;
         n573OperacionesIva = false;
         AssignAttri("", false, "A573OperacionesIva", StringUtil.LTrimStr( A573OperacionesIva, 4, 2));
         n573OperacionesIva = ((Convert.ToDecimal(0)==A573OperacionesIva) ? true : false);
         A574OperacionesComision = 0;
         n574OperacionesComision = false;
         AssignAttri("", false, "A574OperacionesComision", StringUtil.LTrimStr( A574OperacionesComision, 18, 2));
         n574OperacionesComision = ((Convert.ToDecimal(0)==A574OperacionesComision) ? true : false);
         A578OperacionesImporteGrabado = 0;
         n578OperacionesImporteGrabado = false;
         AssignAttri("", false, "A578OperacionesImporteGrabado", StringUtil.LTrimStr( A578OperacionesImporteGrabado, 18, 2));
         n578OperacionesImporteGrabado = ((Convert.ToDecimal(0)==A578OperacionesImporteGrabado) ? true : false);
         A575OperacionesRequest = "";
         n575OperacionesRequest = false;
         AssignAttri("", false, "A575OperacionesRequest", A575OperacionesRequest);
         n575OperacionesRequest = (String.IsNullOrEmpty(StringUtil.RTrim( A575OperacionesRequest)) ? true : false);
         A576OperacionesResponse = "";
         n576OperacionesResponse = false;
         AssignAttri("", false, "A576OperacionesResponse", A576OperacionesResponse);
         n576OperacionesResponse = (String.IsNullOrEmpty(StringUtil.RTrim( A576OperacionesResponse)) ? true : false);
         A580OperacionesComprobantePago = "";
         n580OperacionesComprobantePago = false;
         AssignAttri("", false, "A580OperacionesComprobantePago", A580OperacionesComprobantePago);
         n580OperacionesComprobantePago = (String.IsNullOrEmpty(StringUtil.RTrim( A580OperacionesComprobantePago)) ? true : false);
         A581OperacionesFechaAlta = DateTime.MinValue;
         n581OperacionesFechaAlta = false;
         AssignAttri("", false, "A581OperacionesFechaAlta", context.localUtil.Format(A581OperacionesFechaAlta, "99/99/99"));
         n581OperacionesFechaAlta = ((DateTime.MinValue==A581OperacionesFechaAlta) ? true : false);
         A582OperacionesFechaPago = (DateTime)(DateTime.MinValue);
         n582OperacionesFechaPago = false;
         AssignAttri("", false, "A582OperacionesFechaPago", context.localUtil.TToC( A582OperacionesFechaPago, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n582OperacionesFechaPago = ((DateTime.MinValue==A582OperacionesFechaPago) ? true : false);
         A583OperacionesAux1 = "";
         n583OperacionesAux1 = false;
         AssignAttri("", false, "A583OperacionesAux1", A583OperacionesAux1);
         n583OperacionesAux1 = (String.IsNullOrEmpty(StringUtil.RTrim( A583OperacionesAux1)) ? true : false);
         A584OperacionesAux2 = "";
         n584OperacionesAux2 = false;
         AssignAttri("", false, "A584OperacionesAux2", A584OperacionesAux2);
         n584OperacionesAux2 = (String.IsNullOrEmpty(StringUtil.RTrim( A584OperacionesAux2)) ? true : false);
         A585OperacionesAux3 = "";
         n585OperacionesAux3 = false;
         AssignAttri("", false, "A585OperacionesAux3", A585OperacionesAux3);
         n585OperacionesAux3 = (String.IsNullOrEmpty(StringUtil.RTrim( A585OperacionesAux3)) ? true : false);
         A658OperacionesFechaDesde = DateTime.MinValue;
         n658OperacionesFechaDesde = false;
         AssignAttri("", false, "A658OperacionesFechaDesde", context.localUtil.Format(A658OperacionesFechaDesde, "99/99/99"));
         n658OperacionesFechaDesde = ((DateTime.MinValue==A658OperacionesFechaDesde) ? true : false);
         A659OperacionesFechaHasta = DateTime.MinValue;
         n659OperacionesFechaHasta = false;
         AssignAttri("", false, "A659OperacionesFechaHasta", context.localUtil.Format(A659OperacionesFechaHasta, "99/99/99"));
         n659OperacionesFechaHasta = ((DateTime.MinValue==A659OperacionesFechaHasta) ? true : false);
         A1028OperacionesPeriodoCod = "";
         n1028OperacionesPeriodoCod = false;
         AssignAttri("", false, "A1028OperacionesPeriodoCod", A1028OperacionesPeriodoCod);
         A663OperacionesBlob1 = "";
         n663OperacionesBlob1 = false;
         AssignAttri("", false, "A663OperacionesBlob1", A663OperacionesBlob1);
         AssignProp("", false, edtOperacionesBlob1_Internalname, "URL", context.PathToRelativeUrl( A663OperacionesBlob1), true);
         n663OperacionesBlob1 = (String.IsNullOrEmpty(StringUtil.RTrim( A663OperacionesBlob1)) ? true : false);
         A664OperacionesBlob2 = "";
         n664OperacionesBlob2 = false;
         AssignAttri("", false, "A664OperacionesBlob2", A664OperacionesBlob2);
         AssignProp("", false, edtOperacionesBlob2_Internalname, "URL", context.PathToRelativeUrl( A664OperacionesBlob2), true);
         n664OperacionesBlob2 = (String.IsNullOrEmpty(StringUtil.RTrim( A664OperacionesBlob2)) ? true : false);
         A577OperacionesEstado = "";
         n577OperacionesEstado = false;
         AssignAttri("", false, "A577OperacionesEstado", A577OperacionesEstado);
         n577OperacionesEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A577OperacionesEstado)) ? true : false);
         A666OperacionesUsrAlta = 0;
         n666OperacionesUsrAlta = false;
         AssignAttri("", false, "A666OperacionesUsrAlta", StringUtil.LTrimStr( (decimal)(A666OperacionesUsrAlta), 10, 0));
         n666OperacionesUsrAlta = ((0==A666OperacionesUsrAlta) ? true : false);
         A667OperacionesUsrActualizacion = 0;
         n667OperacionesUsrActualizacion = false;
         AssignAttri("", false, "A667OperacionesUsrActualizacion", StringUtil.LTrimStr( (decimal)(A667OperacionesUsrActualizacion), 10, 0));
         n667OperacionesUsrActualizacion = ((0==A667OperacionesUsrActualizacion) ? true : false);
         A649OperacionesTipo = "CSO";
         n649OperacionesTipo = false;
         AssignAttri("", false, "A649OperacionesTipo", A649OperacionesTipo);
         Z649OperacionesTipo = "";
         Z962OperacionesComercioId1 = 0;
         Z963OperacionesComercioId2 = 0;
         Z555OperacionesRef = "";
         Z657OperacionesNombreRef = "";
         Z579OperacionesOrdinal = 0;
         Z586OperacionesIDORD = "";
         Z569OperacionesTipoES = "";
         Z570OperacionesImporte = 0;
         Z662OperacionesMonId = 0;
         Z571OperacionesMoneda = "";
         Z572OperacionesFacturaCod = "";
         Z573OperacionesIva = 0;
         Z574OperacionesComision = 0;
         Z578OperacionesImporteGrabado = 0;
         Z580OperacionesComprobantePago = "";
         Z581OperacionesFechaAlta = DateTime.MinValue;
         Z582OperacionesFechaPago = (DateTime)(DateTime.MinValue);
         Z583OperacionesAux1 = "";
         Z584OperacionesAux2 = "";
         Z658OperacionesFechaDesde = DateTime.MinValue;
         Z659OperacionesFechaHasta = DateTime.MinValue;
         Z1028OperacionesPeriodoCod = "";
         Z577OperacionesEstado = "";
         Z666OperacionesUsrAlta = 0;
         Z667OperacionesUsrActualizacion = 0;
      }

      protected void InitAll2182( )
      {
         A554OperacionesId = 0;
         AssignAttri("", false, "A554OperacionesId", StringUtil.LTrimStr( (decimal)(A554OperacionesId), 18, 0));
         InitializeNonKey2182( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A649OperacionesTipo = i649OperacionesTipo;
         n649OperacionesTipo = false;
         AssignAttri("", false, "A649OperacionesTipo", A649OperacionesTipo);
      }

      protected void InitializeNonKey2194( )
      {
         A651OperacionesSolicitudesNombre = "";
         n651OperacionesSolicitudesNombre = false;
         A654OperacionesSolicitudesPFinal = 0;
         n654OperacionesSolicitudesPFinal = false;
         A653OperacionesSolicitudesComPro = 0;
         n653OperacionesSolicitudesComPro = false;
         A660OperacionesSolicitudesProvID = 0;
         n660OperacionesSolicitudesProvID = false;
         A661OperacionesSolicitudesProvNomb = "";
         n661OperacionesSolicitudesProvNomb = false;
         A655OperacionesSolicitudesComProv = 0;
         n655OperacionesSolicitudesComProv = false;
         A656OperacionesSolicitudesComALM = 0;
         n656OperacionesSolicitudesComALM = false;
         A1029OperacionesSolicitudesXZComPro = 0;
         n1029OperacionesSolicitudesXZComPro = false;
         AssignAttri("", false, "A1029OperacionesSolicitudesXZComPro", StringUtil.LTrimStr( A1029OperacionesSolicitudesXZComPro, 18, 2));
         A1027OperacionesSolicitudesXZComAlm = 0;
         n1027OperacionesSolicitudesXZComAlm = false;
         AssignAttri("", false, "A1027OperacionesSolicitudesXZComAlm", StringUtil.LTrimStr( A1027OperacionesSolicitudesXZComAlm, 18, 2));
         A668OperacionesSolicitudesOrigenPa = "";
         n668OperacionesSolicitudesOrigenPa = false;
         Z651OperacionesSolicitudesNombre = "";
         Z654OperacionesSolicitudesPFinal = 0;
         Z653OperacionesSolicitudesComPro = 0;
         Z660OperacionesSolicitudesProvID = 0;
         Z661OperacionesSolicitudesProvNomb = "";
         Z655OperacionesSolicitudesComProv = 0;
         Z656OperacionesSolicitudesComALM = 0;
         Z1029OperacionesSolicitudesXZComPro = 0;
         Z1027OperacionesSolicitudesXZComAlm = 0;
         Z668OperacionesSolicitudesOrigenPa = "";
      }

      protected void InitAll2194( )
      {
         A650OperacionesSolicitudesId = 0;
         InitializeNonKey2194( ) ;
      }

      protected void StandaloneModalInsert2194( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202692821395815", true, true, false);
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
         context.AddJavascriptSource("operaciones.js", "?202692821395816", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties94( )
      {
         cmbOperacionesSolicitudesOrigenPa.Enabled = defcmbOperacionesSolicitudesOrigenPa_Enabled;
         AssignProp("", false, cmbOperacionesSolicitudesOrigenPa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbOperacionesSolicitudesOrigenPa.Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesComALM_Enabled = defedtOperacionesSolicitudesComALM_Enabled;
         AssignProp("", false, edtOperacionesSolicitudesComALM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesComALM_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesComProv_Enabled = defedtOperacionesSolicitudesComProv_Enabled;
         AssignProp("", false, edtOperacionesSolicitudesComProv_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesComProv_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesProvNomb_Enabled = defedtOperacionesSolicitudesProvNomb_Enabled;
         AssignProp("", false, edtOperacionesSolicitudesProvNomb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesProvNomb_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesProvID_Enabled = defedtOperacionesSolicitudesProvID_Enabled;
         AssignProp("", false, edtOperacionesSolicitudesProvID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesProvID_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesComPro_Enabled = defedtOperacionesSolicitudesComPro_Enabled;
         AssignProp("", false, edtOperacionesSolicitudesComPro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesComPro_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesPFinal_Enabled = defedtOperacionesSolicitudesPFinal_Enabled;
         AssignProp("", false, edtOperacionesSolicitudesPFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesPFinal_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesNombre_Enabled = defedtOperacionesSolicitudesNombre_Enabled;
         AssignProp("", false, edtOperacionesSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesNombre_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtOperacionesSolicitudesId_Enabled = defedtOperacionesSolicitudesId_Enabled;
         AssignProp("", false, edtOperacionesSolicitudesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacionesSolicitudesId_Enabled), 5, 0), !bGXsfl_128_Refreshing);
      }

      protected void StartGridControl128( )
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
         Gridlevel_solicitudesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A650OperacionesSolicitudesId), 18, 0, ".", ""))));
         Gridlevel_solicitudesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesId_Enabled), 5, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddColumnProperties(Gridlevel_solicitudesColumn);
         Gridlevel_solicitudesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_solicitudesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A651OperacionesSolicitudesNombre)));
         Gridlevel_solicitudesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddColumnProperties(Gridlevel_solicitudesColumn);
         Gridlevel_solicitudesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_solicitudesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A654OperacionesSolicitudesPFinal, 18, 2, ".", ""))));
         Gridlevel_solicitudesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesPFinal_Enabled), 5, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddColumnProperties(Gridlevel_solicitudesColumn);
         Gridlevel_solicitudesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_solicitudesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A653OperacionesSolicitudesComPro, 18, 2, ".", ""))));
         Gridlevel_solicitudesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesComPro_Enabled), 5, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddColumnProperties(Gridlevel_solicitudesColumn);
         Gridlevel_solicitudesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_solicitudesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A660OperacionesSolicitudesProvID), 18, 0, ".", ""))));
         Gridlevel_solicitudesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesProvID_Enabled), 5, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddColumnProperties(Gridlevel_solicitudesColumn);
         Gridlevel_solicitudesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_solicitudesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A661OperacionesSolicitudesProvNomb)));
         Gridlevel_solicitudesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesProvNomb_Enabled), 5, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddColumnProperties(Gridlevel_solicitudesColumn);
         Gridlevel_solicitudesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_solicitudesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A655OperacionesSolicitudesComProv, 18, 2, ".", ""))));
         Gridlevel_solicitudesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesComProv_Enabled), 5, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddColumnProperties(Gridlevel_solicitudesColumn);
         Gridlevel_solicitudesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_solicitudesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A656OperacionesSolicitudesComALM, 18, 2, ".", ""))));
         Gridlevel_solicitudesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesSolicitudesComALM_Enabled), 5, 0, ".", "")));
         Gridlevel_solicitudesContainer.AddColumnProperties(Gridlevel_solicitudesColumn);
         Gridlevel_solicitudesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_solicitudesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A668OperacionesSolicitudesOrigenPa)));
         Gridlevel_solicitudesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbOperacionesSolicitudesOrigenPa.Enabled), 5, 0, ".", "")));
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
         edtOperacionesId_Internalname = "OPERACIONESID";
         edtOperacionesRef_Internalname = "OPERACIONESREF";
         edtOperacionesNombreRef_Internalname = "OPERACIONESNOMBREREF";
         edtOperacionesFacturaCod_Internalname = "OPERACIONESFACTURACOD";
         edtOperacionesIva_Internalname = "OPERACIONESIVA";
         edtOperacionesComision_Internalname = "OPERACIONESCOMISION";
         edtOperacionesImporteGrabado_Internalname = "OPERACIONESIMPORTEGRABADO";
         edtOperacionesComprobantePago_Internalname = "OPERACIONESCOMPROBANTEPAGO";
         divTb1_Internalname = "TB1";
         cmbOperacionesEstado_Internalname = "OPERACIONESESTADO";
         cmbOperacionesTipo_Internalname = "OPERACIONESTIPO";
         cmbOperacionesTipoES_Internalname = "OPERACIONESTIPOES";
         edtOperacionesMoneda_Internalname = "OPERACIONESMONEDA";
         edtOperacionesImporte_Internalname = "OPERACIONESIMPORTE";
         divTb2_Internalname = "TB2";
         edtOperacionesUsrAlta_Internalname = "OPERACIONESUSRALTA";
         edtOperacionesFechaAlta_Internalname = "OPERACIONESFECHAALTA";
         edtOperacionesFechaPago_Internalname = "OPERACIONESFECHAPAGO";
         edtOperacionesFechaDesde_Internalname = "OPERACIONESFECHADESDE";
         edtOperacionesFechaHasta_Internalname = "OPERACIONESFECHAHASTA";
         edtOperacionesUsrActualizacion_Internalname = "OPERACIONESUSRACTUALIZACION";
         tblOtros_Internalname = "OTROS";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         lblTablevel_solicitudes_title_Internalname = "TABLEVEL_SOLICITUDES_TITLE";
         edtOperacionesSolicitudesId_Internalname = "OPERACIONESSOLICITUDESID";
         edtOperacionesSolicitudesNombre_Internalname = "OPERACIONESSOLICITUDESNOMBRE";
         edtOperacionesSolicitudesPFinal_Internalname = "OPERACIONESSOLICITUDESPFINAL";
         edtOperacionesSolicitudesComPro_Internalname = "OPERACIONESSOLICITUDESCOMPRO";
         edtOperacionesSolicitudesProvID_Internalname = "OPERACIONESSOLICITUDESPROVID";
         edtOperacionesSolicitudesProvNomb_Internalname = "OPERACIONESSOLICITUDESPROVNOMB";
         edtOperacionesSolicitudesComProv_Internalname = "OPERACIONESSOLICITUDESCOMPROV";
         edtOperacionesSolicitudesComALM_Internalname = "OPERACIONESSOLICITUDESCOMALM";
         cmbOperacionesSolicitudesOrigenPa_Internalname = "OPERACIONESSOLICITUDESORIGENPA";
         divTableleaflevel_solicitudes_Internalname = "TABLELEAFLEVEL_SOLICITUDES";
         divTabtablelevel_solicitudes_Internalname = "TABTABLELEVEL_SOLICITUDES";
         lblTab1_title_Internalname = "TAB1_TITLE";
         edtOperacionesRequest_Internalname = "OPERACIONESREQUEST";
         edtOperacionesResponse_Internalname = "OPERACIONESRESPONSE";
         edtOperacionesAux1_Internalname = "OPERACIONESAUX1";
         edtOperacionesAux2_Internalname = "OPERACIONESAUX2";
         edtOperacionesAux3_Internalname = "OPERACIONESAUX3";
         edtOperacionesBlob1_Internalname = "OPERACIONESBLOB1";
         edtOperacionesBlob2_Internalname = "OPERACIONESBLOB2";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs_Internalname = "GXUITABSPANEL_TABS";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtOperacionesMonId_Internalname = "OPERACIONESMONID";
         edtOperacionesOrdinal_Internalname = "OPERACIONESORDINAL";
         edtOperacionesIDORD_Internalname = "OPERACIONESIDORD";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
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
         edtOperacionesBlob2_Filename = "";
         edtOperacionesBlob1_Filename = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Operaciones", "");
         cmbOperacionesSolicitudesOrigenPa_Jsonclick = "";
         edtOperacionesSolicitudesComALM_Jsonclick = "";
         edtOperacionesSolicitudesComProv_Jsonclick = "";
         edtOperacionesSolicitudesProvNomb_Jsonclick = "";
         edtOperacionesSolicitudesProvID_Jsonclick = "";
         edtOperacionesSolicitudesComPro_Jsonclick = "";
         edtOperacionesSolicitudesPFinal_Jsonclick = "";
         edtOperacionesSolicitudesNombre_Jsonclick = "";
         edtOperacionesSolicitudesId_Jsonclick = "";
         subGridlevel_solicitudes_Class = "WorkWith";
         subGridlevel_solicitudes_Backcolorstyle = 0;
         cmbOperacionesSolicitudesOrigenPa.Enabled = 0;
         edtOperacionesSolicitudesComALM_Enabled = 0;
         edtOperacionesSolicitudesComProv_Enabled = 0;
         edtOperacionesSolicitudesProvNomb_Enabled = 0;
         edtOperacionesSolicitudesProvID_Enabled = 0;
         edtOperacionesSolicitudesComPro_Enabled = 0;
         edtOperacionesSolicitudesPFinal_Enabled = 0;
         edtOperacionesSolicitudesNombre_Enabled = 0;
         edtOperacionesSolicitudesId_Enabled = 0;
         edtOperacionesIDORD_Jsonclick = "";
         edtOperacionesIDORD_Enabled = 1;
         edtOperacionesIDORD_Visible = 1;
         edtOperacionesOrdinal_Jsonclick = "";
         edtOperacionesOrdinal_Enabled = 1;
         edtOperacionesOrdinal_Visible = 1;
         edtOperacionesMonId_Jsonclick = "";
         edtOperacionesMonId_Enabled = 1;
         edtOperacionesMonId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtOperacionesBlob2_Jsonclick = "";
         edtOperacionesBlob2_Parameters = "";
         edtOperacionesBlob2_Contenttype = "";
         edtOperacionesBlob2_Filetype = "";
         edtOperacionesBlob2_Enabled = 1;
         edtOperacionesBlob1_Jsonclick = "";
         edtOperacionesBlob1_Parameters = "";
         edtOperacionesBlob1_Contenttype = "";
         edtOperacionesBlob1_Filetype = "";
         edtOperacionesBlob1_Enabled = 1;
         edtOperacionesAux3_Enabled = 1;
         edtOperacionesAux2_Jsonclick = "";
         edtOperacionesAux2_Enabled = 1;
         edtOperacionesAux1_Jsonclick = "";
         edtOperacionesAux1_Enabled = 1;
         edtOperacionesResponse_Enabled = 1;
         edtOperacionesRequest_Enabled = 1;
         edtOperacionesUsrActualizacion_Jsonclick = "";
         edtOperacionesUsrActualizacion_Enabled = 0;
         edtOperacionesFechaHasta_Jsonclick = "";
         edtOperacionesFechaHasta_Enabled = 1;
         edtOperacionesFechaDesde_Jsonclick = "";
         edtOperacionesFechaDesde_Enabled = 1;
         edtOperacionesFechaPago_Jsonclick = "";
         edtOperacionesFechaPago_Enabled = 1;
         edtOperacionesFechaAlta_Jsonclick = "";
         edtOperacionesFechaAlta_Enabled = 1;
         edtOperacionesUsrAlta_Jsonclick = "";
         edtOperacionesUsrAlta_Enabled = 0;
         edtOperacionesImporte_Jsonclick = "";
         edtOperacionesImporte_Enabled = 1;
         edtOperacionesMoneda_Jsonclick = "";
         edtOperacionesMoneda_Enabled = 1;
         cmbOperacionesTipoES_Jsonclick = "";
         cmbOperacionesTipoES.Enabled = 1;
         cmbOperacionesTipo_Jsonclick = "";
         cmbOperacionesTipo.Enabled = 1;
         cmbOperacionesEstado_Jsonclick = "";
         cmbOperacionesEstado.Enabled = 1;
         edtOperacionesComprobantePago_Enabled = 1;
         edtOperacionesImporteGrabado_Jsonclick = "";
         edtOperacionesImporteGrabado_Enabled = 1;
         edtOperacionesComision_Jsonclick = "";
         edtOperacionesComision_Enabled = 1;
         edtOperacionesIva_Jsonclick = "";
         edtOperacionesIva_Enabled = 1;
         edtOperacionesFacturaCod_Jsonclick = "";
         edtOperacionesFacturaCod_Enabled = 1;
         edtOperacionesNombreRef_Jsonclick = "";
         edtOperacionesNombreRef_Enabled = 1;
         edtOperacionesRef_Jsonclick = "";
         edtOperacionesRef_Enabled = 1;
         edtOperacionesId_Jsonclick = "";
         edtOperacionesId_Enabled = 1;
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

      protected void gxnrGridlevel_solicitudes_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_12894( ) ;
         while ( nGXsfl_128_idx <= nRC_GXsfl_128 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal2194( ) ;
            standaloneModal2194( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow2194( ) ;
            nGXsfl_128_idx = (int)(nGXsfl_128_idx+1);
            sGXsfl_128_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_128_idx), 4, 0), 4, "0");
            SubsflControlProps_12894( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_solicitudesContainer)) ;
         /* End function gxnrGridlevel_solicitudes_newrow */
      }

      protected void init_web_controls( )
      {
         cmbOperacionesEstado.Name = "OPERACIONESESTADO";
         cmbOperacionesEstado.WebTags = "";
         cmbOperacionesEstado.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
         cmbOperacionesEstado.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
         cmbOperacionesEstado.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
         if ( cmbOperacionesEstado.ItemCount > 0 )
         {
            A577OperacionesEstado = cmbOperacionesEstado.getValidValue(A577OperacionesEstado);
            n577OperacionesEstado = false;
            AssignAttri("", false, "A577OperacionesEstado", A577OperacionesEstado);
         }
         cmbOperacionesTipo.Name = "OPERACIONESTIPO";
         cmbOperacionesTipo.WebTags = "";
         cmbOperacionesTipo.addItem("LSF", context.GetMessage( "Liquidación de Solicitudes del Profesional", ""), 0);
         cmbOperacionesTipo.addItem("LSC", context.GetMessage( "Liquidación de  Solicitudes Comercio", ""), 0);
         cmbOperacionesTipo.addItem("COL", context.GetMessage( "Cobro de Saldo Pendiente", ""), 0);
         cmbOperacionesTipo.addItem("POL", context.GetMessage( "Pago de Saldo", ""), 0);
         cmbOperacionesTipo.addItem("CSO", context.GetMessage( "Cobro de Solicitud", ""), 0);
         cmbOperacionesTipo.addItem("NCR", context.GetMessage( "Nota de Credito", ""), 0);
         cmbOperacionesTipo.addItem("NDE", context.GetMessage( "Nota de Debito", ""), 0);
         cmbOperacionesTipo.addItem("OTR", context.GetMessage( "Otros", ""), 0);
         cmbOperacionesTipo.addItem("FEN", context.GetMessage( "Solicitudes ingresadas desde Fenicio", ""), 0);
         cmbOperacionesTipo.addItem("FGO", context.GetMessage( "Respuesta de api fenicio", ""), 0);
         cmbOperacionesTipo.addItem("CEX", context.GetMessage( "COMERCIO_EXTERNO", ""), 0);
         if ( cmbOperacionesTipo.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A649OperacionesTipo)) )
            {
               A649OperacionesTipo = "CSO";
               n649OperacionesTipo = false;
               AssignAttri("", false, "A649OperacionesTipo", A649OperacionesTipo);
            }
         }
         cmbOperacionesTipoES.Name = "OPERACIONESTIPOES";
         cmbOperacionesTipoES.WebTags = "";
         cmbOperacionesTipoES.addItem("E", context.GetMessage( "Entrada", ""), 0);
         cmbOperacionesTipoES.addItem("S", context.GetMessage( "Salida", ""), 0);
         if ( cmbOperacionesTipoES.ItemCount > 0 )
         {
            A569OperacionesTipoES = cmbOperacionesTipoES.getValidValue(A569OperacionesTipoES);
            n569OperacionesTipoES = false;
            AssignAttri("", false, "A569OperacionesTipoES", A569OperacionesTipoES);
         }
         GXCCtl = "OPERACIONESSOLICITUDESORIGENPA_" + sGXsfl_128_idx;
         cmbOperacionesSolicitudesOrigenPa.Name = GXCCtl;
         cmbOperacionesSolicitudesOrigenPa.WebTags = "";
         cmbOperacionesSolicitudesOrigenPa.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
         cmbOperacionesSolicitudesOrigenPa.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
         cmbOperacionesSolicitudesOrigenPa.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
         if ( cmbOperacionesSolicitudesOrigenPa.ItemCount > 0 )
         {
            A668OperacionesSolicitudesOrigenPa = cmbOperacionesSolicitudesOrigenPa.getValidValue(A668OperacionesSolicitudesOrigenPa);
            n668OperacionesSolicitudesOrigenPa = false;
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A666OperacionesUsrAlta',fld:'OPERACIONESUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'A667OperacionesUsrActualizacion',fld:'OPERACIONESUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'A962OperacionesComercioId1',fld:'OPERACIONESCOMERCIOID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A963OperacionesComercioId2',fld:'OPERACIONESCOMERCIOID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A1028OperacionesPeriodoCod',fld:'OPERACIONESPERIODOCOD',pic:'',type:'svchar'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12212',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESID","{handler:'Valid_Operacionesid',iparms:[]");
         setEventMetadata("VALID_OPERACIONESID",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESESTADO","{handler:'Valid_Operacionesestado',iparms:[]");
         setEventMetadata("VALID_OPERACIONESESTADO",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESTIPO","{handler:'Valid_Operacionestipo',iparms:[]");
         setEventMetadata("VALID_OPERACIONESTIPO",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESTIPOES","{handler:'Valid_Operacionestipoes',iparms:[]");
         setEventMetadata("VALID_OPERACIONESTIPOES",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESFECHAALTA","{handler:'Valid_Operacionesfechaalta',iparms:[]");
         setEventMetadata("VALID_OPERACIONESFECHAALTA",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESFECHAPAGO","{handler:'Valid_Operacionesfechapago',iparms:[]");
         setEventMetadata("VALID_OPERACIONESFECHAPAGO",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESFECHADESDE","{handler:'Valid_Operacionesfechadesde',iparms:[]");
         setEventMetadata("VALID_OPERACIONESFECHADESDE",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESFECHAHASTA","{handler:'Valid_Operacionesfechahasta',iparms:[]");
         setEventMetadata("VALID_OPERACIONESFECHAHASTA",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESSOLICITUDESID","{handler:'Valid_Operacionessolicitudesid',iparms:[]");
         setEventMetadata("VALID_OPERACIONESSOLICITUDESID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Operacionessolicitudesorigenpa',iparms:[]");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z649OperacionesTipo = "";
         Z555OperacionesRef = "";
         Z657OperacionesNombreRef = "";
         Z586OperacionesIDORD = "";
         Z569OperacionesTipoES = "";
         Z571OperacionesMoneda = "";
         Z572OperacionesFacturaCod = "";
         Z580OperacionesComprobantePago = "";
         Z581OperacionesFechaAlta = DateTime.MinValue;
         Z582OperacionesFechaPago = (DateTime)(DateTime.MinValue);
         Z583OperacionesAux1 = "";
         Z584OperacionesAux2 = "";
         Z658OperacionesFechaDesde = DateTime.MinValue;
         Z659OperacionesFechaHasta = DateTime.MinValue;
         Z1028OperacionesPeriodoCod = "";
         Z577OperacionesEstado = "";
         Z651OperacionesSolicitudesNombre = "";
         Z661OperacionesSolicitudesProvNomb = "";
         Z668OperacionesSolicitudesOrigenPa = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A577OperacionesEstado = "";
         A649OperacionesTipo = "";
         A569OperacionesTipoES = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblTabgeneral_title_Jsonclick = "";
         TempTags = "";
         A555OperacionesRef = "";
         A657OperacionesNombreRef = "";
         A572OperacionesFacturaCod = "";
         A580OperacionesComprobantePago = "";
         A571OperacionesMoneda = "";
         sStyleString = "";
         A581OperacionesFechaAlta = DateTime.MinValue;
         A582OperacionesFechaPago = (DateTime)(DateTime.MinValue);
         A658OperacionesFechaDesde = DateTime.MinValue;
         A659OperacionesFechaHasta = DateTime.MinValue;
         lblTablevel_solicitudes_title_Jsonclick = "";
         lblTab1_title_Jsonclick = "";
         A575OperacionesRequest = "";
         A576OperacionesResponse = "";
         A583OperacionesAux1 = "";
         A584OperacionesAux2 = "";
         A585OperacionesAux3 = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         A663OperacionesBlob1 = "";
         A664OperacionesBlob2 = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A586OperacionesIDORD = "";
         Gridlevel_solicitudesContainer = new GXWebGrid( context);
         sMode94 = "";
         A1028OperacionesPeriodoCod = "";
         AV17Pgmname = "";
         Gxuitabspanel_tabs_Objectcall = "";
         Gxuitabspanel_tabs_Activepagecontrolname = "";
         GXCCtlgxBlob = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode82 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A651OperacionesSolicitudesNombre = "";
         A661OperacionesSolicitudesProvNomb = "";
         A668OperacionesSolicitudesOrigenPa = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z575OperacionesRequest = "";
         Z576OperacionesResponse = "";
         Z585OperacionesAux3 = "";
         Z663OperacionesBlob1 = "";
         Z664OperacionesBlob2 = "";
         T00216_A554OperacionesId = new long[1] ;
         T00216_A649OperacionesTipo = new string[] {""} ;
         T00216_n649OperacionesTipo = new bool[] {false} ;
         T00216_A962OperacionesComercioId1 = new long[1] ;
         T00216_n962OperacionesComercioId1 = new bool[] {false} ;
         T00216_A963OperacionesComercioId2 = new long[1] ;
         T00216_n963OperacionesComercioId2 = new bool[] {false} ;
         T00216_A555OperacionesRef = new string[] {""} ;
         T00216_n555OperacionesRef = new bool[] {false} ;
         T00216_A657OperacionesNombreRef = new string[] {""} ;
         T00216_n657OperacionesNombreRef = new bool[] {false} ;
         T00216_A579OperacionesOrdinal = new long[1] ;
         T00216_n579OperacionesOrdinal = new bool[] {false} ;
         T00216_A586OperacionesIDORD = new string[] {""} ;
         T00216_n586OperacionesIDORD = new bool[] {false} ;
         T00216_A569OperacionesTipoES = new string[] {""} ;
         T00216_n569OperacionesTipoES = new bool[] {false} ;
         T00216_A570OperacionesImporte = new decimal[1] ;
         T00216_n570OperacionesImporte = new bool[] {false} ;
         T00216_A662OperacionesMonId = new long[1] ;
         T00216_n662OperacionesMonId = new bool[] {false} ;
         T00216_A571OperacionesMoneda = new string[] {""} ;
         T00216_n571OperacionesMoneda = new bool[] {false} ;
         T00216_A572OperacionesFacturaCod = new string[] {""} ;
         T00216_n572OperacionesFacturaCod = new bool[] {false} ;
         T00216_A573OperacionesIva = new decimal[1] ;
         T00216_n573OperacionesIva = new bool[] {false} ;
         T00216_A574OperacionesComision = new decimal[1] ;
         T00216_n574OperacionesComision = new bool[] {false} ;
         T00216_A578OperacionesImporteGrabado = new decimal[1] ;
         T00216_n578OperacionesImporteGrabado = new bool[] {false} ;
         T00216_A575OperacionesRequest = new string[] {""} ;
         T00216_n575OperacionesRequest = new bool[] {false} ;
         T00216_A576OperacionesResponse = new string[] {""} ;
         T00216_n576OperacionesResponse = new bool[] {false} ;
         T00216_A580OperacionesComprobantePago = new string[] {""} ;
         T00216_n580OperacionesComprobantePago = new bool[] {false} ;
         T00216_A581OperacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00216_n581OperacionesFechaAlta = new bool[] {false} ;
         T00216_A582OperacionesFechaPago = new DateTime[] {DateTime.MinValue} ;
         T00216_n582OperacionesFechaPago = new bool[] {false} ;
         T00216_A583OperacionesAux1 = new string[] {""} ;
         T00216_n583OperacionesAux1 = new bool[] {false} ;
         T00216_A584OperacionesAux2 = new string[] {""} ;
         T00216_n584OperacionesAux2 = new bool[] {false} ;
         T00216_A585OperacionesAux3 = new string[] {""} ;
         T00216_n585OperacionesAux3 = new bool[] {false} ;
         T00216_A658OperacionesFechaDesde = new DateTime[] {DateTime.MinValue} ;
         T00216_n658OperacionesFechaDesde = new bool[] {false} ;
         T00216_A659OperacionesFechaHasta = new DateTime[] {DateTime.MinValue} ;
         T00216_n659OperacionesFechaHasta = new bool[] {false} ;
         T00216_A1028OperacionesPeriodoCod = new string[] {""} ;
         T00216_n1028OperacionesPeriodoCod = new bool[] {false} ;
         T00216_A577OperacionesEstado = new string[] {""} ;
         T00216_n577OperacionesEstado = new bool[] {false} ;
         T00216_A666OperacionesUsrAlta = new long[1] ;
         T00216_n666OperacionesUsrAlta = new bool[] {false} ;
         T00216_A667OperacionesUsrActualizacion = new long[1] ;
         T00216_n667OperacionesUsrActualizacion = new bool[] {false} ;
         T00216_A663OperacionesBlob1 = new string[] {""} ;
         T00216_n663OperacionesBlob1 = new bool[] {false} ;
         T00216_A664OperacionesBlob2 = new string[] {""} ;
         T00216_n664OperacionesBlob2 = new bool[] {false} ;
         T00217_A554OperacionesId = new long[1] ;
         T00215_A554OperacionesId = new long[1] ;
         T00215_A649OperacionesTipo = new string[] {""} ;
         T00215_n649OperacionesTipo = new bool[] {false} ;
         T00215_A962OperacionesComercioId1 = new long[1] ;
         T00215_n962OperacionesComercioId1 = new bool[] {false} ;
         T00215_A963OperacionesComercioId2 = new long[1] ;
         T00215_n963OperacionesComercioId2 = new bool[] {false} ;
         T00215_A555OperacionesRef = new string[] {""} ;
         T00215_n555OperacionesRef = new bool[] {false} ;
         T00215_A657OperacionesNombreRef = new string[] {""} ;
         T00215_n657OperacionesNombreRef = new bool[] {false} ;
         T00215_A579OperacionesOrdinal = new long[1] ;
         T00215_n579OperacionesOrdinal = new bool[] {false} ;
         T00215_A586OperacionesIDORD = new string[] {""} ;
         T00215_n586OperacionesIDORD = new bool[] {false} ;
         T00215_A569OperacionesTipoES = new string[] {""} ;
         T00215_n569OperacionesTipoES = new bool[] {false} ;
         T00215_A570OperacionesImporte = new decimal[1] ;
         T00215_n570OperacionesImporte = new bool[] {false} ;
         T00215_A662OperacionesMonId = new long[1] ;
         T00215_n662OperacionesMonId = new bool[] {false} ;
         T00215_A571OperacionesMoneda = new string[] {""} ;
         T00215_n571OperacionesMoneda = new bool[] {false} ;
         T00215_A572OperacionesFacturaCod = new string[] {""} ;
         T00215_n572OperacionesFacturaCod = new bool[] {false} ;
         T00215_A573OperacionesIva = new decimal[1] ;
         T00215_n573OperacionesIva = new bool[] {false} ;
         T00215_A574OperacionesComision = new decimal[1] ;
         T00215_n574OperacionesComision = new bool[] {false} ;
         T00215_A578OperacionesImporteGrabado = new decimal[1] ;
         T00215_n578OperacionesImporteGrabado = new bool[] {false} ;
         T00215_A575OperacionesRequest = new string[] {""} ;
         T00215_n575OperacionesRequest = new bool[] {false} ;
         T00215_A576OperacionesResponse = new string[] {""} ;
         T00215_n576OperacionesResponse = new bool[] {false} ;
         T00215_A580OperacionesComprobantePago = new string[] {""} ;
         T00215_n580OperacionesComprobantePago = new bool[] {false} ;
         T00215_A581OperacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00215_n581OperacionesFechaAlta = new bool[] {false} ;
         T00215_A582OperacionesFechaPago = new DateTime[] {DateTime.MinValue} ;
         T00215_n582OperacionesFechaPago = new bool[] {false} ;
         T00215_A583OperacionesAux1 = new string[] {""} ;
         T00215_n583OperacionesAux1 = new bool[] {false} ;
         T00215_A584OperacionesAux2 = new string[] {""} ;
         T00215_n584OperacionesAux2 = new bool[] {false} ;
         T00215_A585OperacionesAux3 = new string[] {""} ;
         T00215_n585OperacionesAux3 = new bool[] {false} ;
         T00215_A658OperacionesFechaDesde = new DateTime[] {DateTime.MinValue} ;
         T00215_n658OperacionesFechaDesde = new bool[] {false} ;
         T00215_A659OperacionesFechaHasta = new DateTime[] {DateTime.MinValue} ;
         T00215_n659OperacionesFechaHasta = new bool[] {false} ;
         T00215_A1028OperacionesPeriodoCod = new string[] {""} ;
         T00215_n1028OperacionesPeriodoCod = new bool[] {false} ;
         T00215_A577OperacionesEstado = new string[] {""} ;
         T00215_n577OperacionesEstado = new bool[] {false} ;
         T00215_A666OperacionesUsrAlta = new long[1] ;
         T00215_n666OperacionesUsrAlta = new bool[] {false} ;
         T00215_A667OperacionesUsrActualizacion = new long[1] ;
         T00215_n667OperacionesUsrActualizacion = new bool[] {false} ;
         T00215_A663OperacionesBlob1 = new string[] {""} ;
         T00215_n663OperacionesBlob1 = new bool[] {false} ;
         T00215_A664OperacionesBlob2 = new string[] {""} ;
         T00215_n664OperacionesBlob2 = new bool[] {false} ;
         T00218_A554OperacionesId = new long[1] ;
         T00219_A554OperacionesId = new long[1] ;
         T00214_A554OperacionesId = new long[1] ;
         T00214_A649OperacionesTipo = new string[] {""} ;
         T00214_n649OperacionesTipo = new bool[] {false} ;
         T00214_A962OperacionesComercioId1 = new long[1] ;
         T00214_n962OperacionesComercioId1 = new bool[] {false} ;
         T00214_A963OperacionesComercioId2 = new long[1] ;
         T00214_n963OperacionesComercioId2 = new bool[] {false} ;
         T00214_A555OperacionesRef = new string[] {""} ;
         T00214_n555OperacionesRef = new bool[] {false} ;
         T00214_A657OperacionesNombreRef = new string[] {""} ;
         T00214_n657OperacionesNombreRef = new bool[] {false} ;
         T00214_A579OperacionesOrdinal = new long[1] ;
         T00214_n579OperacionesOrdinal = new bool[] {false} ;
         T00214_A586OperacionesIDORD = new string[] {""} ;
         T00214_n586OperacionesIDORD = new bool[] {false} ;
         T00214_A569OperacionesTipoES = new string[] {""} ;
         T00214_n569OperacionesTipoES = new bool[] {false} ;
         T00214_A570OperacionesImporte = new decimal[1] ;
         T00214_n570OperacionesImporte = new bool[] {false} ;
         T00214_A662OperacionesMonId = new long[1] ;
         T00214_n662OperacionesMonId = new bool[] {false} ;
         T00214_A571OperacionesMoneda = new string[] {""} ;
         T00214_n571OperacionesMoneda = new bool[] {false} ;
         T00214_A572OperacionesFacturaCod = new string[] {""} ;
         T00214_n572OperacionesFacturaCod = new bool[] {false} ;
         T00214_A573OperacionesIva = new decimal[1] ;
         T00214_n573OperacionesIva = new bool[] {false} ;
         T00214_A574OperacionesComision = new decimal[1] ;
         T00214_n574OperacionesComision = new bool[] {false} ;
         T00214_A578OperacionesImporteGrabado = new decimal[1] ;
         T00214_n578OperacionesImporteGrabado = new bool[] {false} ;
         T00214_A575OperacionesRequest = new string[] {""} ;
         T00214_n575OperacionesRequest = new bool[] {false} ;
         T00214_A576OperacionesResponse = new string[] {""} ;
         T00214_n576OperacionesResponse = new bool[] {false} ;
         T00214_A580OperacionesComprobantePago = new string[] {""} ;
         T00214_n580OperacionesComprobantePago = new bool[] {false} ;
         T00214_A581OperacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00214_n581OperacionesFechaAlta = new bool[] {false} ;
         T00214_A582OperacionesFechaPago = new DateTime[] {DateTime.MinValue} ;
         T00214_n582OperacionesFechaPago = new bool[] {false} ;
         T00214_A583OperacionesAux1 = new string[] {""} ;
         T00214_n583OperacionesAux1 = new bool[] {false} ;
         T00214_A584OperacionesAux2 = new string[] {""} ;
         T00214_n584OperacionesAux2 = new bool[] {false} ;
         T00214_A585OperacionesAux3 = new string[] {""} ;
         T00214_n585OperacionesAux3 = new bool[] {false} ;
         T00214_A658OperacionesFechaDesde = new DateTime[] {DateTime.MinValue} ;
         T00214_n658OperacionesFechaDesde = new bool[] {false} ;
         T00214_A659OperacionesFechaHasta = new DateTime[] {DateTime.MinValue} ;
         T00214_n659OperacionesFechaHasta = new bool[] {false} ;
         T00214_A1028OperacionesPeriodoCod = new string[] {""} ;
         T00214_n1028OperacionesPeriodoCod = new bool[] {false} ;
         T00214_A577OperacionesEstado = new string[] {""} ;
         T00214_n577OperacionesEstado = new bool[] {false} ;
         T00214_A666OperacionesUsrAlta = new long[1] ;
         T00214_n666OperacionesUsrAlta = new bool[] {false} ;
         T00214_A667OperacionesUsrActualizacion = new long[1] ;
         T00214_n667OperacionesUsrActualizacion = new bool[] {false} ;
         T00214_A663OperacionesBlob1 = new string[] {""} ;
         T00214_n663OperacionesBlob1 = new bool[] {false} ;
         T00214_A664OperacionesBlob2 = new string[] {""} ;
         T00214_n664OperacionesBlob2 = new bool[] {false} ;
         T002115_A554OperacionesId = new long[1] ;
         T002116_A554OperacionesId = new long[1] ;
         T002116_A650OperacionesSolicitudesId = new long[1] ;
         T002116_A651OperacionesSolicitudesNombre = new string[] {""} ;
         T002116_n651OperacionesSolicitudesNombre = new bool[] {false} ;
         T002116_A654OperacionesSolicitudesPFinal = new decimal[1] ;
         T002116_n654OperacionesSolicitudesPFinal = new bool[] {false} ;
         T002116_A653OperacionesSolicitudesComPro = new decimal[1] ;
         T002116_n653OperacionesSolicitudesComPro = new bool[] {false} ;
         T002116_A660OperacionesSolicitudesProvID = new long[1] ;
         T002116_n660OperacionesSolicitudesProvID = new bool[] {false} ;
         T002116_A661OperacionesSolicitudesProvNomb = new string[] {""} ;
         T002116_n661OperacionesSolicitudesProvNomb = new bool[] {false} ;
         T002116_A655OperacionesSolicitudesComProv = new decimal[1] ;
         T002116_n655OperacionesSolicitudesComProv = new bool[] {false} ;
         T002116_A656OperacionesSolicitudesComALM = new decimal[1] ;
         T002116_n656OperacionesSolicitudesComALM = new bool[] {false} ;
         T002116_A1029OperacionesSolicitudesXZComPro = new decimal[1] ;
         T002116_n1029OperacionesSolicitudesXZComPro = new bool[] {false} ;
         T002116_A1027OperacionesSolicitudesXZComAlm = new decimal[1] ;
         T002116_n1027OperacionesSolicitudesXZComAlm = new bool[] {false} ;
         T002116_A668OperacionesSolicitudesOrigenPa = new string[] {""} ;
         T002116_n668OperacionesSolicitudesOrigenPa = new bool[] {false} ;
         T002117_A554OperacionesId = new long[1] ;
         T002117_A650OperacionesSolicitudesId = new long[1] ;
         T00213_A554OperacionesId = new long[1] ;
         T00213_A650OperacionesSolicitudesId = new long[1] ;
         T00213_A651OperacionesSolicitudesNombre = new string[] {""} ;
         T00213_n651OperacionesSolicitudesNombre = new bool[] {false} ;
         T00213_A654OperacionesSolicitudesPFinal = new decimal[1] ;
         T00213_n654OperacionesSolicitudesPFinal = new bool[] {false} ;
         T00213_A653OperacionesSolicitudesComPro = new decimal[1] ;
         T00213_n653OperacionesSolicitudesComPro = new bool[] {false} ;
         T00213_A660OperacionesSolicitudesProvID = new long[1] ;
         T00213_n660OperacionesSolicitudesProvID = new bool[] {false} ;
         T00213_A661OperacionesSolicitudesProvNomb = new string[] {""} ;
         T00213_n661OperacionesSolicitudesProvNomb = new bool[] {false} ;
         T00213_A655OperacionesSolicitudesComProv = new decimal[1] ;
         T00213_n655OperacionesSolicitudesComProv = new bool[] {false} ;
         T00213_A656OperacionesSolicitudesComALM = new decimal[1] ;
         T00213_n656OperacionesSolicitudesComALM = new bool[] {false} ;
         T00213_A1029OperacionesSolicitudesXZComPro = new decimal[1] ;
         T00213_n1029OperacionesSolicitudesXZComPro = new bool[] {false} ;
         T00213_A1027OperacionesSolicitudesXZComAlm = new decimal[1] ;
         T00213_n1027OperacionesSolicitudesXZComAlm = new bool[] {false} ;
         T00213_A668OperacionesSolicitudesOrigenPa = new string[] {""} ;
         T00213_n668OperacionesSolicitudesOrigenPa = new bool[] {false} ;
         T00212_A554OperacionesId = new long[1] ;
         T00212_A650OperacionesSolicitudesId = new long[1] ;
         T00212_A651OperacionesSolicitudesNombre = new string[] {""} ;
         T00212_n651OperacionesSolicitudesNombre = new bool[] {false} ;
         T00212_A654OperacionesSolicitudesPFinal = new decimal[1] ;
         T00212_n654OperacionesSolicitudesPFinal = new bool[] {false} ;
         T00212_A653OperacionesSolicitudesComPro = new decimal[1] ;
         T00212_n653OperacionesSolicitudesComPro = new bool[] {false} ;
         T00212_A660OperacionesSolicitudesProvID = new long[1] ;
         T00212_n660OperacionesSolicitudesProvID = new bool[] {false} ;
         T00212_A661OperacionesSolicitudesProvNomb = new string[] {""} ;
         T00212_n661OperacionesSolicitudesProvNomb = new bool[] {false} ;
         T00212_A655OperacionesSolicitudesComProv = new decimal[1] ;
         T00212_n655OperacionesSolicitudesComProv = new bool[] {false} ;
         T00212_A656OperacionesSolicitudesComALM = new decimal[1] ;
         T00212_n656OperacionesSolicitudesComALM = new bool[] {false} ;
         T00212_A1029OperacionesSolicitudesXZComPro = new decimal[1] ;
         T00212_n1029OperacionesSolicitudesXZComPro = new bool[] {false} ;
         T00212_A1027OperacionesSolicitudesXZComAlm = new decimal[1] ;
         T00212_n1027OperacionesSolicitudesXZComAlm = new bool[] {false} ;
         T00212_A668OperacionesSolicitudesOrigenPa = new string[] {""} ;
         T00212_n668OperacionesSolicitudesOrigenPa = new bool[] {false} ;
         T002121_A554OperacionesId = new long[1] ;
         T002121_A650OperacionesSolicitudesId = new long[1] ;
         Gridlevel_solicitudesRow = new GXWebRow();
         subGridlevel_solicitudes_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i649OperacionesTipo = "";
         Gridlevel_solicitudesColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.operaciones__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operaciones__default(),
            new Object[][] {
                new Object[] {
               T00212_A554OperacionesId, T00212_A650OperacionesSolicitudesId, T00212_A651OperacionesSolicitudesNombre, T00212_n651OperacionesSolicitudesNombre, T00212_A654OperacionesSolicitudesPFinal, T00212_n654OperacionesSolicitudesPFinal, T00212_A653OperacionesSolicitudesComPro, T00212_n653OperacionesSolicitudesComPro, T00212_A660OperacionesSolicitudesProvID, T00212_n660OperacionesSolicitudesProvID,
               T00212_A661OperacionesSolicitudesProvNomb, T00212_n661OperacionesSolicitudesProvNomb, T00212_A655OperacionesSolicitudesComProv, T00212_n655OperacionesSolicitudesComProv, T00212_A656OperacionesSolicitudesComALM, T00212_n656OperacionesSolicitudesComALM, T00212_A1029OperacionesSolicitudesXZComPro, T00212_n1029OperacionesSolicitudesXZComPro, T00212_A1027OperacionesSolicitudesXZComAlm, T00212_n1027OperacionesSolicitudesXZComAlm,
               T00212_A668OperacionesSolicitudesOrigenPa, T00212_n668OperacionesSolicitudesOrigenPa
               }
               , new Object[] {
               T00213_A554OperacionesId, T00213_A650OperacionesSolicitudesId, T00213_A651OperacionesSolicitudesNombre, T00213_n651OperacionesSolicitudesNombre, T00213_A654OperacionesSolicitudesPFinal, T00213_n654OperacionesSolicitudesPFinal, T00213_A653OperacionesSolicitudesComPro, T00213_n653OperacionesSolicitudesComPro, T00213_A660OperacionesSolicitudesProvID, T00213_n660OperacionesSolicitudesProvID,
               T00213_A661OperacionesSolicitudesProvNomb, T00213_n661OperacionesSolicitudesProvNomb, T00213_A655OperacionesSolicitudesComProv, T00213_n655OperacionesSolicitudesComProv, T00213_A656OperacionesSolicitudesComALM, T00213_n656OperacionesSolicitudesComALM, T00213_A1029OperacionesSolicitudesXZComPro, T00213_n1029OperacionesSolicitudesXZComPro, T00213_A1027OperacionesSolicitudesXZComAlm, T00213_n1027OperacionesSolicitudesXZComAlm,
               T00213_A668OperacionesSolicitudesOrigenPa, T00213_n668OperacionesSolicitudesOrigenPa
               }
               , new Object[] {
               T00214_A554OperacionesId, T00214_A649OperacionesTipo, T00214_n649OperacionesTipo, T00214_A962OperacionesComercioId1, T00214_n962OperacionesComercioId1, T00214_A963OperacionesComercioId2, T00214_n963OperacionesComercioId2, T00214_A555OperacionesRef, T00214_n555OperacionesRef, T00214_A657OperacionesNombreRef,
               T00214_n657OperacionesNombreRef, T00214_A579OperacionesOrdinal, T00214_n579OperacionesOrdinal, T00214_A586OperacionesIDORD, T00214_n586OperacionesIDORD, T00214_A569OperacionesTipoES, T00214_n569OperacionesTipoES, T00214_A570OperacionesImporte, T00214_n570OperacionesImporte, T00214_A662OperacionesMonId,
               T00214_n662OperacionesMonId, T00214_A571OperacionesMoneda, T00214_n571OperacionesMoneda, T00214_A572OperacionesFacturaCod, T00214_n572OperacionesFacturaCod, T00214_A573OperacionesIva, T00214_n573OperacionesIva, T00214_A574OperacionesComision, T00214_n574OperacionesComision, T00214_A578OperacionesImporteGrabado,
               T00214_n578OperacionesImporteGrabado, T00214_A575OperacionesRequest, T00214_n575OperacionesRequest, T00214_A576OperacionesResponse, T00214_n576OperacionesResponse, T00214_A580OperacionesComprobantePago, T00214_n580OperacionesComprobantePago, T00214_A581OperacionesFechaAlta, T00214_n581OperacionesFechaAlta, T00214_A582OperacionesFechaPago,
               T00214_n582OperacionesFechaPago, T00214_A583OperacionesAux1, T00214_n583OperacionesAux1, T00214_A584OperacionesAux2, T00214_n584OperacionesAux2, T00214_A585OperacionesAux3, T00214_n585OperacionesAux3, T00214_A658OperacionesFechaDesde, T00214_n658OperacionesFechaDesde, T00214_A659OperacionesFechaHasta,
               T00214_n659OperacionesFechaHasta, T00214_A1028OperacionesPeriodoCod, T00214_n1028OperacionesPeriodoCod, T00214_A577OperacionesEstado, T00214_n577OperacionesEstado, T00214_A666OperacionesUsrAlta, T00214_n666OperacionesUsrAlta, T00214_A667OperacionesUsrActualizacion, T00214_n667OperacionesUsrActualizacion, T00214_A663OperacionesBlob1,
               T00214_n663OperacionesBlob1, T00214_A664OperacionesBlob2, T00214_n664OperacionesBlob2
               }
               , new Object[] {
               T00215_A554OperacionesId, T00215_A649OperacionesTipo, T00215_n649OperacionesTipo, T00215_A962OperacionesComercioId1, T00215_n962OperacionesComercioId1, T00215_A963OperacionesComercioId2, T00215_n963OperacionesComercioId2, T00215_A555OperacionesRef, T00215_n555OperacionesRef, T00215_A657OperacionesNombreRef,
               T00215_n657OperacionesNombreRef, T00215_A579OperacionesOrdinal, T00215_n579OperacionesOrdinal, T00215_A586OperacionesIDORD, T00215_n586OperacionesIDORD, T00215_A569OperacionesTipoES, T00215_n569OperacionesTipoES, T00215_A570OperacionesImporte, T00215_n570OperacionesImporte, T00215_A662OperacionesMonId,
               T00215_n662OperacionesMonId, T00215_A571OperacionesMoneda, T00215_n571OperacionesMoneda, T00215_A572OperacionesFacturaCod, T00215_n572OperacionesFacturaCod, T00215_A573OperacionesIva, T00215_n573OperacionesIva, T00215_A574OperacionesComision, T00215_n574OperacionesComision, T00215_A578OperacionesImporteGrabado,
               T00215_n578OperacionesImporteGrabado, T00215_A575OperacionesRequest, T00215_n575OperacionesRequest, T00215_A576OperacionesResponse, T00215_n576OperacionesResponse, T00215_A580OperacionesComprobantePago, T00215_n580OperacionesComprobantePago, T00215_A581OperacionesFechaAlta, T00215_n581OperacionesFechaAlta, T00215_A582OperacionesFechaPago,
               T00215_n582OperacionesFechaPago, T00215_A583OperacionesAux1, T00215_n583OperacionesAux1, T00215_A584OperacionesAux2, T00215_n584OperacionesAux2, T00215_A585OperacionesAux3, T00215_n585OperacionesAux3, T00215_A658OperacionesFechaDesde, T00215_n658OperacionesFechaDesde, T00215_A659OperacionesFechaHasta,
               T00215_n659OperacionesFechaHasta, T00215_A1028OperacionesPeriodoCod, T00215_n1028OperacionesPeriodoCod, T00215_A577OperacionesEstado, T00215_n577OperacionesEstado, T00215_A666OperacionesUsrAlta, T00215_n666OperacionesUsrAlta, T00215_A667OperacionesUsrActualizacion, T00215_n667OperacionesUsrActualizacion, T00215_A663OperacionesBlob1,
               T00215_n663OperacionesBlob1, T00215_A664OperacionesBlob2, T00215_n664OperacionesBlob2
               }
               , new Object[] {
               T00216_A554OperacionesId, T00216_A649OperacionesTipo, T00216_n649OperacionesTipo, T00216_A962OperacionesComercioId1, T00216_n962OperacionesComercioId1, T00216_A963OperacionesComercioId2, T00216_n963OperacionesComercioId2, T00216_A555OperacionesRef, T00216_n555OperacionesRef, T00216_A657OperacionesNombreRef,
               T00216_n657OperacionesNombreRef, T00216_A579OperacionesOrdinal, T00216_n579OperacionesOrdinal, T00216_A586OperacionesIDORD, T00216_n586OperacionesIDORD, T00216_A569OperacionesTipoES, T00216_n569OperacionesTipoES, T00216_A570OperacionesImporte, T00216_n570OperacionesImporte, T00216_A662OperacionesMonId,
               T00216_n662OperacionesMonId, T00216_A571OperacionesMoneda, T00216_n571OperacionesMoneda, T00216_A572OperacionesFacturaCod, T00216_n572OperacionesFacturaCod, T00216_A573OperacionesIva, T00216_n573OperacionesIva, T00216_A574OperacionesComision, T00216_n574OperacionesComision, T00216_A578OperacionesImporteGrabado,
               T00216_n578OperacionesImporteGrabado, T00216_A575OperacionesRequest, T00216_n575OperacionesRequest, T00216_A576OperacionesResponse, T00216_n576OperacionesResponse, T00216_A580OperacionesComprobantePago, T00216_n580OperacionesComprobantePago, T00216_A581OperacionesFechaAlta, T00216_n581OperacionesFechaAlta, T00216_A582OperacionesFechaPago,
               T00216_n582OperacionesFechaPago, T00216_A583OperacionesAux1, T00216_n583OperacionesAux1, T00216_A584OperacionesAux2, T00216_n584OperacionesAux2, T00216_A585OperacionesAux3, T00216_n585OperacionesAux3, T00216_A658OperacionesFechaDesde, T00216_n658OperacionesFechaDesde, T00216_A659OperacionesFechaHasta,
               T00216_n659OperacionesFechaHasta, T00216_A1028OperacionesPeriodoCod, T00216_n1028OperacionesPeriodoCod, T00216_A577OperacionesEstado, T00216_n577OperacionesEstado, T00216_A666OperacionesUsrAlta, T00216_n666OperacionesUsrAlta, T00216_A667OperacionesUsrActualizacion, T00216_n667OperacionesUsrActualizacion, T00216_A663OperacionesBlob1,
               T00216_n663OperacionesBlob1, T00216_A664OperacionesBlob2, T00216_n664OperacionesBlob2
               }
               , new Object[] {
               T00217_A554OperacionesId
               }
               , new Object[] {
               T00218_A554OperacionesId
               }
               , new Object[] {
               T00219_A554OperacionesId
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
               }
               , new Object[] {
               T002115_A554OperacionesId
               }
               , new Object[] {
               T002116_A554OperacionesId, T002116_A650OperacionesSolicitudesId, T002116_A651OperacionesSolicitudesNombre, T002116_n651OperacionesSolicitudesNombre, T002116_A654OperacionesSolicitudesPFinal, T002116_n654OperacionesSolicitudesPFinal, T002116_A653OperacionesSolicitudesComPro, T002116_n653OperacionesSolicitudesComPro, T002116_A660OperacionesSolicitudesProvID, T002116_n660OperacionesSolicitudesProvID,
               T002116_A661OperacionesSolicitudesProvNomb, T002116_n661OperacionesSolicitudesProvNomb, T002116_A655OperacionesSolicitudesComProv, T002116_n655OperacionesSolicitudesComProv, T002116_A656OperacionesSolicitudesComALM, T002116_n656OperacionesSolicitudesComALM, T002116_A1029OperacionesSolicitudesXZComPro, T002116_n1029OperacionesSolicitudesXZComPro, T002116_A1027OperacionesSolicitudesXZComAlm, T002116_n1027OperacionesSolicitudesXZComAlm,
               T002116_A668OperacionesSolicitudesOrigenPa, T002116_n668OperacionesSolicitudesOrigenPa
               }
               , new Object[] {
               T002117_A554OperacionesId, T002117_A650OperacionesSolicitudesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002121_A554OperacionesId, T002121_A650OperacionesSolicitudesId
               }
            }
         );
         AV17Pgmname = "Operaciones";
         Z649OperacionesTipo = "CSO";
         n649OperacionesTipo = false;
         A649OperacionesTipo = "CSO";
         n649OperacionesTipo = false;
         i649OperacionesTipo = "CSO";
         n649OperacionesTipo = false;
      }

      private short nRcdDeleted_94 ;
      private short nRcdExists_94 ;
      private short nIsMod_94 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount94 ;
      private short RcdFound94 ;
      private short nBlankRcdUsr94 ;
      private short Gx_BScreen ;
      private short RcdFound82 ;
      private short nIsDirty_94 ;
      private short subGridlevel_solicitudes_Backcolorstyle ;
      private short subGridlevel_solicitudes_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_solicitudes_Allowselection ;
      private short subGridlevel_solicitudes_Allowhovering ;
      private short subGridlevel_solicitudes_Allowcollapsing ;
      private short subGridlevel_solicitudes_Collapsed ;
      private int nRC_GXsfl_128 ;
      private int nGXsfl_128_idx=1 ;
      private int trnEnded ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int edtOperacionesId_Enabled ;
      private int edtOperacionesRef_Enabled ;
      private int edtOperacionesNombreRef_Enabled ;
      private int edtOperacionesFacturaCod_Enabled ;
      private int edtOperacionesIva_Enabled ;
      private int edtOperacionesComision_Enabled ;
      private int edtOperacionesImporteGrabado_Enabled ;
      private int edtOperacionesComprobantePago_Enabled ;
      private int edtOperacionesMoneda_Enabled ;
      private int edtOperacionesImporte_Enabled ;
      private int edtOperacionesUsrAlta_Enabled ;
      private int edtOperacionesFechaAlta_Enabled ;
      private int edtOperacionesFechaPago_Enabled ;
      private int edtOperacionesFechaDesde_Enabled ;
      private int edtOperacionesFechaHasta_Enabled ;
      private int edtOperacionesUsrActualizacion_Enabled ;
      private int edtOperacionesRequest_Enabled ;
      private int edtOperacionesResponse_Enabled ;
      private int edtOperacionesAux1_Enabled ;
      private int edtOperacionesAux2_Enabled ;
      private int edtOperacionesAux3_Enabled ;
      private int edtOperacionesBlob1_Enabled ;
      private int edtOperacionesBlob2_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtOperacionesMonId_Enabled ;
      private int edtOperacionesMonId_Visible ;
      private int edtOperacionesOrdinal_Enabled ;
      private int edtOperacionesOrdinal_Visible ;
      private int edtOperacionesIDORD_Visible ;
      private int edtOperacionesIDORD_Enabled ;
      private int edtOperacionesSolicitudesId_Enabled ;
      private int edtOperacionesSolicitudesNombre_Enabled ;
      private int edtOperacionesSolicitudesPFinal_Enabled ;
      private int edtOperacionesSolicitudesComPro_Enabled ;
      private int edtOperacionesSolicitudesProvID_Enabled ;
      private int edtOperacionesSolicitudesProvNomb_Enabled ;
      private int edtOperacionesSolicitudesComProv_Enabled ;
      private int edtOperacionesSolicitudesComALM_Enabled ;
      private int fRowAdded ;
      private int Gxuitabspanel_tabs_Activepage ;
      private int subGridlevel_solicitudes_Backcolor ;
      private int subGridlevel_solicitudes_Allbackcolor ;
      private int defcmbOperacionesSolicitudesOrigenPa_Enabled ;
      private int defedtOperacionesSolicitudesComALM_Enabled ;
      private int defedtOperacionesSolicitudesComProv_Enabled ;
      private int defedtOperacionesSolicitudesProvNomb_Enabled ;
      private int defedtOperacionesSolicitudesProvID_Enabled ;
      private int defedtOperacionesSolicitudesComPro_Enabled ;
      private int defedtOperacionesSolicitudesPFinal_Enabled ;
      private int defedtOperacionesSolicitudesNombre_Enabled ;
      private int defedtOperacionesSolicitudesId_Enabled ;
      private int idxLst ;
      private int subGridlevel_solicitudes_Selectedindex ;
      private int subGridlevel_solicitudes_Selectioncolor ;
      private int subGridlevel_solicitudes_Hoveringcolor ;
      private long wcpOAV7OperacionesId ;
      private long Z554OperacionesId ;
      private long Z962OperacionesComercioId1 ;
      private long Z963OperacionesComercioId2 ;
      private long Z579OperacionesOrdinal ;
      private long Z662OperacionesMonId ;
      private long Z666OperacionesUsrAlta ;
      private long Z667OperacionesUsrActualizacion ;
      private long Z650OperacionesSolicitudesId ;
      private long Z660OperacionesSolicitudesProvID ;
      private long AV7OperacionesId ;
      private long A554OperacionesId ;
      private long A666OperacionesUsrAlta ;
      private long A667OperacionesUsrActualizacion ;
      private long A662OperacionesMonId ;
      private long A579OperacionesOrdinal ;
      private long A962OperacionesComercioId1 ;
      private long A963OperacionesComercioId2 ;
      private long GRIDLEVEL_SOLICITUDES_nFirstRecordOnPage ;
      private long A650OperacionesSolicitudesId ;
      private long A660OperacionesSolicitudesProvID ;
      private decimal Z570OperacionesImporte ;
      private decimal Z573OperacionesIva ;
      private decimal Z574OperacionesComision ;
      private decimal Z578OperacionesImporteGrabado ;
      private decimal Z654OperacionesSolicitudesPFinal ;
      private decimal Z653OperacionesSolicitudesComPro ;
      private decimal Z655OperacionesSolicitudesComProv ;
      private decimal Z656OperacionesSolicitudesComALM ;
      private decimal Z1029OperacionesSolicitudesXZComPro ;
      private decimal Z1027OperacionesSolicitudesXZComAlm ;
      private decimal A573OperacionesIva ;
      private decimal A574OperacionesComision ;
      private decimal A578OperacionesImporteGrabado ;
      private decimal A570OperacionesImporte ;
      private decimal A1029OperacionesSolicitudesXZComPro ;
      private decimal A1027OperacionesSolicitudesXZComAlm ;
      private decimal A654OperacionesSolicitudesPFinal ;
      private decimal A653OperacionesSolicitudesComPro ;
      private decimal A655OperacionesSolicitudesComProv ;
      private decimal A656OperacionesSolicitudesComALM ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z649OperacionesTipo ;
      private string Z555OperacionesRef ;
      private string Z657OperacionesNombreRef ;
      private string Z586OperacionesIDORD ;
      private string Z569OperacionesTipoES ;
      private string Z571OperacionesMoneda ;
      private string Z572OperacionesFacturaCod ;
      private string Z580OperacionesComprobantePago ;
      private string Z577OperacionesEstado ;
      private string Z651OperacionesSolicitudesNombre ;
      private string Z661OperacionesSolicitudesProvNomb ;
      private string Z668OperacionesSolicitudesOrigenPa ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtOperacionesId_Internalname ;
      private string sGXsfl_128_idx="0001" ;
      private string A577OperacionesEstado ;
      private string cmbOperacionesEstado_Internalname ;
      private string A649OperacionesTipo ;
      private string cmbOperacionesTipo_Internalname ;
      private string A569OperacionesTipoES ;
      private string cmbOperacionesTipoES_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Gxuitabspanel_tabs_Class ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblTabgeneral_title_Internalname ;
      private string lblTabgeneral_title_Jsonclick ;
      private string divTableattributes_Internalname ;
      private string divTb1_Internalname ;
      private string TempTags ;
      private string edtOperacionesId_Jsonclick ;
      private string edtOperacionesRef_Internalname ;
      private string A555OperacionesRef ;
      private string edtOperacionesRef_Jsonclick ;
      private string edtOperacionesNombreRef_Internalname ;
      private string A657OperacionesNombreRef ;
      private string edtOperacionesNombreRef_Jsonclick ;
      private string edtOperacionesFacturaCod_Internalname ;
      private string A572OperacionesFacturaCod ;
      private string edtOperacionesFacturaCod_Jsonclick ;
      private string edtOperacionesIva_Internalname ;
      private string edtOperacionesIva_Jsonclick ;
      private string edtOperacionesComision_Internalname ;
      private string edtOperacionesComision_Jsonclick ;
      private string edtOperacionesImporteGrabado_Internalname ;
      private string edtOperacionesImporteGrabado_Jsonclick ;
      private string edtOperacionesComprobantePago_Internalname ;
      private string A580OperacionesComprobantePago ;
      private string divTb2_Internalname ;
      private string cmbOperacionesEstado_Jsonclick ;
      private string cmbOperacionesTipo_Jsonclick ;
      private string cmbOperacionesTipoES_Jsonclick ;
      private string edtOperacionesMoneda_Internalname ;
      private string A571OperacionesMoneda ;
      private string edtOperacionesMoneda_Jsonclick ;
      private string edtOperacionesImporte_Internalname ;
      private string edtOperacionesImporte_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string sStyleString ;
      private string tblOtros_Internalname ;
      private string edtOperacionesUsrAlta_Internalname ;
      private string edtOperacionesUsrAlta_Jsonclick ;
      private string edtOperacionesFechaAlta_Internalname ;
      private string edtOperacionesFechaAlta_Jsonclick ;
      private string edtOperacionesFechaPago_Internalname ;
      private string edtOperacionesFechaPago_Jsonclick ;
      private string edtOperacionesFechaDesde_Internalname ;
      private string edtOperacionesFechaDesde_Jsonclick ;
      private string edtOperacionesFechaHasta_Internalname ;
      private string edtOperacionesFechaHasta_Jsonclick ;
      private string edtOperacionesUsrActualizacion_Internalname ;
      private string edtOperacionesUsrActualizacion_Jsonclick ;
      private string lblTablevel_solicitudes_title_Internalname ;
      private string lblTablevel_solicitudes_title_Jsonclick ;
      private string divTabtablelevel_solicitudes_Internalname ;
      private string divTableleaflevel_solicitudes_Internalname ;
      private string lblTab1_title_Internalname ;
      private string lblTab1_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string edtOperacionesRequest_Internalname ;
      private string edtOperacionesResponse_Internalname ;
      private string edtOperacionesAux1_Internalname ;
      private string edtOperacionesAux1_Jsonclick ;
      private string edtOperacionesAux2_Internalname ;
      private string edtOperacionesAux2_Jsonclick ;
      private string edtOperacionesAux3_Internalname ;
      private string edtOperacionesBlob1_Internalname ;
      private string edtOperacionesBlob1_Filetype ;
      private string edtOperacionesBlob1_Contenttype ;
      private string edtOperacionesBlob1_Parameters ;
      private string edtOperacionesBlob1_Jsonclick ;
      private string edtOperacionesBlob2_Internalname ;
      private string edtOperacionesBlob2_Filetype ;
      private string edtOperacionesBlob2_Contenttype ;
      private string edtOperacionesBlob2_Parameters ;
      private string edtOperacionesBlob2_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtOperacionesMonId_Internalname ;
      private string edtOperacionesMonId_Jsonclick ;
      private string edtOperacionesOrdinal_Internalname ;
      private string edtOperacionesOrdinal_Jsonclick ;
      private string edtOperacionesIDORD_Internalname ;
      private string A586OperacionesIDORD ;
      private string edtOperacionesIDORD_Jsonclick ;
      private string sMode94 ;
      private string edtOperacionesSolicitudesId_Internalname ;
      private string edtOperacionesSolicitudesNombre_Internalname ;
      private string edtOperacionesSolicitudesPFinal_Internalname ;
      private string edtOperacionesSolicitudesComPro_Internalname ;
      private string edtOperacionesSolicitudesProvID_Internalname ;
      private string edtOperacionesSolicitudesProvNomb_Internalname ;
      private string edtOperacionesSolicitudesComProv_Internalname ;
      private string edtOperacionesSolicitudesComALM_Internalname ;
      private string cmbOperacionesSolicitudesOrigenPa_Internalname ;
      private string subGridlevel_solicitudes_Internalname ;
      private string AV17Pgmname ;
      private string Gxuitabspanel_tabs_Objectcall ;
      private string Gxuitabspanel_tabs_Activepagecontrolname ;
      private string edtOperacionesBlob1_Filename ;
      private string edtOperacionesBlob2_Filename ;
      private string GXCCtlgxBlob ;
      private string hsh ;
      private string sMode82 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A651OperacionesSolicitudesNombre ;
      private string A661OperacionesSolicitudesProvNomb ;
      private string A668OperacionesSolicitudesOrigenPa ;
      private string GXEncryptionTmp ;
      private string sGXsfl_128_fel_idx="0001" ;
      private string subGridlevel_solicitudes_Class ;
      private string subGridlevel_solicitudes_Linesclass ;
      private string ROClassString ;
      private string edtOperacionesSolicitudesId_Jsonclick ;
      private string edtOperacionesSolicitudesNombre_Jsonclick ;
      private string edtOperacionesSolicitudesPFinal_Jsonclick ;
      private string edtOperacionesSolicitudesComPro_Jsonclick ;
      private string edtOperacionesSolicitudesProvID_Jsonclick ;
      private string edtOperacionesSolicitudesProvNomb_Jsonclick ;
      private string edtOperacionesSolicitudesComProv_Jsonclick ;
      private string edtOperacionesSolicitudesComALM_Jsonclick ;
      private string GXCCtl ;
      private string cmbOperacionesSolicitudesOrigenPa_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i649OperacionesTipo ;
      private string subGridlevel_solicitudes_Header ;
      private DateTime Z582OperacionesFechaPago ;
      private DateTime A582OperacionesFechaPago ;
      private DateTime Z581OperacionesFechaAlta ;
      private DateTime Z658OperacionesFechaDesde ;
      private DateTime Z659OperacionesFechaHasta ;
      private DateTime A581OperacionesFechaAlta ;
      private DateTime A658OperacionesFechaDesde ;
      private DateTime A659OperacionesFechaHasta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n577OperacionesEstado ;
      private bool n649OperacionesTipo ;
      private bool n569OperacionesTipoES ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool n663OperacionesBlob1 ;
      private bool n664OperacionesBlob2 ;
      private bool bGXsfl_128_Refreshing=false ;
      private bool n962OperacionesComercioId1 ;
      private bool n963OperacionesComercioId2 ;
      private bool n555OperacionesRef ;
      private bool n657OperacionesNombreRef ;
      private bool n579OperacionesOrdinal ;
      private bool n586OperacionesIDORD ;
      private bool n570OperacionesImporte ;
      private bool n662OperacionesMonId ;
      private bool n571OperacionesMoneda ;
      private bool n572OperacionesFacturaCod ;
      private bool n573OperacionesIva ;
      private bool n574OperacionesComision ;
      private bool n578OperacionesImporteGrabado ;
      private bool n580OperacionesComprobantePago ;
      private bool n581OperacionesFechaAlta ;
      private bool n582OperacionesFechaPago ;
      private bool n583OperacionesAux1 ;
      private bool n584OperacionesAux2 ;
      private bool n658OperacionesFechaDesde ;
      private bool n659OperacionesFechaHasta ;
      private bool n1028OperacionesPeriodoCod ;
      private bool n666OperacionesUsrAlta ;
      private bool n667OperacionesUsrActualizacion ;
      private bool n1029OperacionesSolicitudesXZComPro ;
      private bool n1027OperacionesSolicitudesXZComAlm ;
      private bool Gxuitabspanel_tabs_Enabled ;
      private bool Gxuitabspanel_tabs_Visible ;
      private bool n575OperacionesRequest ;
      private bool n576OperacionesResponse ;
      private bool n585OperacionesAux3 ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private bool n651OperacionesSolicitudesNombre ;
      private bool n654OperacionesSolicitudesPFinal ;
      private bool n653OperacionesSolicitudesComPro ;
      private bool n660OperacionesSolicitudesProvID ;
      private bool n661OperacionesSolicitudesProvNomb ;
      private bool n655OperacionesSolicitudesComProv ;
      private bool n656OperacionesSolicitudesComALM ;
      private bool n668OperacionesSolicitudesOrigenPa ;
      private string A575OperacionesRequest ;
      private string A576OperacionesResponse ;
      private string A585OperacionesAux3 ;
      private string Z575OperacionesRequest ;
      private string Z576OperacionesResponse ;
      private string Z585OperacionesAux3 ;
      private string Z583OperacionesAux1 ;
      private string Z584OperacionesAux2 ;
      private string Z1028OperacionesPeriodoCod ;
      private string A583OperacionesAux1 ;
      private string A584OperacionesAux2 ;
      private string A1028OperacionesPeriodoCod ;
      private string A663OperacionesBlob1 ;
      private string A664OperacionesBlob2 ;
      private string Z663OperacionesBlob1 ;
      private string Z664OperacionesBlob2 ;
      private IGxSession AV12WebSession ;
      private GxFile gxblobfileaux ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_solicitudesContainer ;
      private GXWebRow Gridlevel_solicitudesRow ;
      private GXWebColumn Gridlevel_solicitudesColumn ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbOperacionesEstado ;
      private GXCombobox cmbOperacionesTipo ;
      private GXCombobox cmbOperacionesTipoES ;
      private GXCombobox cmbOperacionesSolicitudesOrigenPa ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] T00216_A554OperacionesId ;
      private string[] T00216_A649OperacionesTipo ;
      private bool[] T00216_n649OperacionesTipo ;
      private long[] T00216_A962OperacionesComercioId1 ;
      private bool[] T00216_n962OperacionesComercioId1 ;
      private long[] T00216_A963OperacionesComercioId2 ;
      private bool[] T00216_n963OperacionesComercioId2 ;
      private string[] T00216_A555OperacionesRef ;
      private bool[] T00216_n555OperacionesRef ;
      private string[] T00216_A657OperacionesNombreRef ;
      private bool[] T00216_n657OperacionesNombreRef ;
      private long[] T00216_A579OperacionesOrdinal ;
      private bool[] T00216_n579OperacionesOrdinal ;
      private string[] T00216_A586OperacionesIDORD ;
      private bool[] T00216_n586OperacionesIDORD ;
      private string[] T00216_A569OperacionesTipoES ;
      private bool[] T00216_n569OperacionesTipoES ;
      private decimal[] T00216_A570OperacionesImporte ;
      private bool[] T00216_n570OperacionesImporte ;
      private long[] T00216_A662OperacionesMonId ;
      private bool[] T00216_n662OperacionesMonId ;
      private string[] T00216_A571OperacionesMoneda ;
      private bool[] T00216_n571OperacionesMoneda ;
      private string[] T00216_A572OperacionesFacturaCod ;
      private bool[] T00216_n572OperacionesFacturaCod ;
      private decimal[] T00216_A573OperacionesIva ;
      private bool[] T00216_n573OperacionesIva ;
      private decimal[] T00216_A574OperacionesComision ;
      private bool[] T00216_n574OperacionesComision ;
      private decimal[] T00216_A578OperacionesImporteGrabado ;
      private bool[] T00216_n578OperacionesImporteGrabado ;
      private string[] T00216_A575OperacionesRequest ;
      private bool[] T00216_n575OperacionesRequest ;
      private string[] T00216_A576OperacionesResponse ;
      private bool[] T00216_n576OperacionesResponse ;
      private string[] T00216_A580OperacionesComprobantePago ;
      private bool[] T00216_n580OperacionesComprobantePago ;
      private DateTime[] T00216_A581OperacionesFechaAlta ;
      private bool[] T00216_n581OperacionesFechaAlta ;
      private DateTime[] T00216_A582OperacionesFechaPago ;
      private bool[] T00216_n582OperacionesFechaPago ;
      private string[] T00216_A583OperacionesAux1 ;
      private bool[] T00216_n583OperacionesAux1 ;
      private string[] T00216_A584OperacionesAux2 ;
      private bool[] T00216_n584OperacionesAux2 ;
      private string[] T00216_A585OperacionesAux3 ;
      private bool[] T00216_n585OperacionesAux3 ;
      private DateTime[] T00216_A658OperacionesFechaDesde ;
      private bool[] T00216_n658OperacionesFechaDesde ;
      private DateTime[] T00216_A659OperacionesFechaHasta ;
      private bool[] T00216_n659OperacionesFechaHasta ;
      private string[] T00216_A1028OperacionesPeriodoCod ;
      private bool[] T00216_n1028OperacionesPeriodoCod ;
      private string[] T00216_A577OperacionesEstado ;
      private bool[] T00216_n577OperacionesEstado ;
      private long[] T00216_A666OperacionesUsrAlta ;
      private bool[] T00216_n666OperacionesUsrAlta ;
      private long[] T00216_A667OperacionesUsrActualizacion ;
      private bool[] T00216_n667OperacionesUsrActualizacion ;
      private string[] T00216_A663OperacionesBlob1 ;
      private bool[] T00216_n663OperacionesBlob1 ;
      private string[] T00216_A664OperacionesBlob2 ;
      private bool[] T00216_n664OperacionesBlob2 ;
      private long[] T00217_A554OperacionesId ;
      private long[] T00215_A554OperacionesId ;
      private string[] T00215_A649OperacionesTipo ;
      private bool[] T00215_n649OperacionesTipo ;
      private long[] T00215_A962OperacionesComercioId1 ;
      private bool[] T00215_n962OperacionesComercioId1 ;
      private long[] T00215_A963OperacionesComercioId2 ;
      private bool[] T00215_n963OperacionesComercioId2 ;
      private string[] T00215_A555OperacionesRef ;
      private bool[] T00215_n555OperacionesRef ;
      private string[] T00215_A657OperacionesNombreRef ;
      private bool[] T00215_n657OperacionesNombreRef ;
      private long[] T00215_A579OperacionesOrdinal ;
      private bool[] T00215_n579OperacionesOrdinal ;
      private string[] T00215_A586OperacionesIDORD ;
      private bool[] T00215_n586OperacionesIDORD ;
      private string[] T00215_A569OperacionesTipoES ;
      private bool[] T00215_n569OperacionesTipoES ;
      private decimal[] T00215_A570OperacionesImporte ;
      private bool[] T00215_n570OperacionesImporte ;
      private long[] T00215_A662OperacionesMonId ;
      private bool[] T00215_n662OperacionesMonId ;
      private string[] T00215_A571OperacionesMoneda ;
      private bool[] T00215_n571OperacionesMoneda ;
      private string[] T00215_A572OperacionesFacturaCod ;
      private bool[] T00215_n572OperacionesFacturaCod ;
      private decimal[] T00215_A573OperacionesIva ;
      private bool[] T00215_n573OperacionesIva ;
      private decimal[] T00215_A574OperacionesComision ;
      private bool[] T00215_n574OperacionesComision ;
      private decimal[] T00215_A578OperacionesImporteGrabado ;
      private bool[] T00215_n578OperacionesImporteGrabado ;
      private string[] T00215_A575OperacionesRequest ;
      private bool[] T00215_n575OperacionesRequest ;
      private string[] T00215_A576OperacionesResponse ;
      private bool[] T00215_n576OperacionesResponse ;
      private string[] T00215_A580OperacionesComprobantePago ;
      private bool[] T00215_n580OperacionesComprobantePago ;
      private DateTime[] T00215_A581OperacionesFechaAlta ;
      private bool[] T00215_n581OperacionesFechaAlta ;
      private DateTime[] T00215_A582OperacionesFechaPago ;
      private bool[] T00215_n582OperacionesFechaPago ;
      private string[] T00215_A583OperacionesAux1 ;
      private bool[] T00215_n583OperacionesAux1 ;
      private string[] T00215_A584OperacionesAux2 ;
      private bool[] T00215_n584OperacionesAux2 ;
      private string[] T00215_A585OperacionesAux3 ;
      private bool[] T00215_n585OperacionesAux3 ;
      private DateTime[] T00215_A658OperacionesFechaDesde ;
      private bool[] T00215_n658OperacionesFechaDesde ;
      private DateTime[] T00215_A659OperacionesFechaHasta ;
      private bool[] T00215_n659OperacionesFechaHasta ;
      private string[] T00215_A1028OperacionesPeriodoCod ;
      private bool[] T00215_n1028OperacionesPeriodoCod ;
      private string[] T00215_A577OperacionesEstado ;
      private bool[] T00215_n577OperacionesEstado ;
      private long[] T00215_A666OperacionesUsrAlta ;
      private bool[] T00215_n666OperacionesUsrAlta ;
      private long[] T00215_A667OperacionesUsrActualizacion ;
      private bool[] T00215_n667OperacionesUsrActualizacion ;
      private string[] T00215_A663OperacionesBlob1 ;
      private bool[] T00215_n663OperacionesBlob1 ;
      private string[] T00215_A664OperacionesBlob2 ;
      private bool[] T00215_n664OperacionesBlob2 ;
      private long[] T00218_A554OperacionesId ;
      private long[] T00219_A554OperacionesId ;
      private long[] T00214_A554OperacionesId ;
      private string[] T00214_A649OperacionesTipo ;
      private bool[] T00214_n649OperacionesTipo ;
      private long[] T00214_A962OperacionesComercioId1 ;
      private bool[] T00214_n962OperacionesComercioId1 ;
      private long[] T00214_A963OperacionesComercioId2 ;
      private bool[] T00214_n963OperacionesComercioId2 ;
      private string[] T00214_A555OperacionesRef ;
      private bool[] T00214_n555OperacionesRef ;
      private string[] T00214_A657OperacionesNombreRef ;
      private bool[] T00214_n657OperacionesNombreRef ;
      private long[] T00214_A579OperacionesOrdinal ;
      private bool[] T00214_n579OperacionesOrdinal ;
      private string[] T00214_A586OperacionesIDORD ;
      private bool[] T00214_n586OperacionesIDORD ;
      private string[] T00214_A569OperacionesTipoES ;
      private bool[] T00214_n569OperacionesTipoES ;
      private decimal[] T00214_A570OperacionesImporte ;
      private bool[] T00214_n570OperacionesImporte ;
      private long[] T00214_A662OperacionesMonId ;
      private bool[] T00214_n662OperacionesMonId ;
      private string[] T00214_A571OperacionesMoneda ;
      private bool[] T00214_n571OperacionesMoneda ;
      private string[] T00214_A572OperacionesFacturaCod ;
      private bool[] T00214_n572OperacionesFacturaCod ;
      private decimal[] T00214_A573OperacionesIva ;
      private bool[] T00214_n573OperacionesIva ;
      private decimal[] T00214_A574OperacionesComision ;
      private bool[] T00214_n574OperacionesComision ;
      private decimal[] T00214_A578OperacionesImporteGrabado ;
      private bool[] T00214_n578OperacionesImporteGrabado ;
      private string[] T00214_A575OperacionesRequest ;
      private bool[] T00214_n575OperacionesRequest ;
      private string[] T00214_A576OperacionesResponse ;
      private bool[] T00214_n576OperacionesResponse ;
      private string[] T00214_A580OperacionesComprobantePago ;
      private bool[] T00214_n580OperacionesComprobantePago ;
      private DateTime[] T00214_A581OperacionesFechaAlta ;
      private bool[] T00214_n581OperacionesFechaAlta ;
      private DateTime[] T00214_A582OperacionesFechaPago ;
      private bool[] T00214_n582OperacionesFechaPago ;
      private string[] T00214_A583OperacionesAux1 ;
      private bool[] T00214_n583OperacionesAux1 ;
      private string[] T00214_A584OperacionesAux2 ;
      private bool[] T00214_n584OperacionesAux2 ;
      private string[] T00214_A585OperacionesAux3 ;
      private bool[] T00214_n585OperacionesAux3 ;
      private DateTime[] T00214_A658OperacionesFechaDesde ;
      private bool[] T00214_n658OperacionesFechaDesde ;
      private DateTime[] T00214_A659OperacionesFechaHasta ;
      private bool[] T00214_n659OperacionesFechaHasta ;
      private string[] T00214_A1028OperacionesPeriodoCod ;
      private bool[] T00214_n1028OperacionesPeriodoCod ;
      private string[] T00214_A577OperacionesEstado ;
      private bool[] T00214_n577OperacionesEstado ;
      private long[] T00214_A666OperacionesUsrAlta ;
      private bool[] T00214_n666OperacionesUsrAlta ;
      private long[] T00214_A667OperacionesUsrActualizacion ;
      private bool[] T00214_n667OperacionesUsrActualizacion ;
      private string[] T00214_A663OperacionesBlob1 ;
      private bool[] T00214_n663OperacionesBlob1 ;
      private string[] T00214_A664OperacionesBlob2 ;
      private bool[] T00214_n664OperacionesBlob2 ;
      private long[] T002115_A554OperacionesId ;
      private long[] T002116_A554OperacionesId ;
      private long[] T002116_A650OperacionesSolicitudesId ;
      private string[] T002116_A651OperacionesSolicitudesNombre ;
      private bool[] T002116_n651OperacionesSolicitudesNombre ;
      private decimal[] T002116_A654OperacionesSolicitudesPFinal ;
      private bool[] T002116_n654OperacionesSolicitudesPFinal ;
      private decimal[] T002116_A653OperacionesSolicitudesComPro ;
      private bool[] T002116_n653OperacionesSolicitudesComPro ;
      private long[] T002116_A660OperacionesSolicitudesProvID ;
      private bool[] T002116_n660OperacionesSolicitudesProvID ;
      private string[] T002116_A661OperacionesSolicitudesProvNomb ;
      private bool[] T002116_n661OperacionesSolicitudesProvNomb ;
      private decimal[] T002116_A655OperacionesSolicitudesComProv ;
      private bool[] T002116_n655OperacionesSolicitudesComProv ;
      private decimal[] T002116_A656OperacionesSolicitudesComALM ;
      private bool[] T002116_n656OperacionesSolicitudesComALM ;
      private decimal[] T002116_A1029OperacionesSolicitudesXZComPro ;
      private bool[] T002116_n1029OperacionesSolicitudesXZComPro ;
      private decimal[] T002116_A1027OperacionesSolicitudesXZComAlm ;
      private bool[] T002116_n1027OperacionesSolicitudesXZComAlm ;
      private string[] T002116_A668OperacionesSolicitudesOrigenPa ;
      private bool[] T002116_n668OperacionesSolicitudesOrigenPa ;
      private long[] T002117_A554OperacionesId ;
      private long[] T002117_A650OperacionesSolicitudesId ;
      private long[] T00213_A554OperacionesId ;
      private long[] T00213_A650OperacionesSolicitudesId ;
      private string[] T00213_A651OperacionesSolicitudesNombre ;
      private bool[] T00213_n651OperacionesSolicitudesNombre ;
      private decimal[] T00213_A654OperacionesSolicitudesPFinal ;
      private bool[] T00213_n654OperacionesSolicitudesPFinal ;
      private decimal[] T00213_A653OperacionesSolicitudesComPro ;
      private bool[] T00213_n653OperacionesSolicitudesComPro ;
      private long[] T00213_A660OperacionesSolicitudesProvID ;
      private bool[] T00213_n660OperacionesSolicitudesProvID ;
      private string[] T00213_A661OperacionesSolicitudesProvNomb ;
      private bool[] T00213_n661OperacionesSolicitudesProvNomb ;
      private decimal[] T00213_A655OperacionesSolicitudesComProv ;
      private bool[] T00213_n655OperacionesSolicitudesComProv ;
      private decimal[] T00213_A656OperacionesSolicitudesComALM ;
      private bool[] T00213_n656OperacionesSolicitudesComALM ;
      private decimal[] T00213_A1029OperacionesSolicitudesXZComPro ;
      private bool[] T00213_n1029OperacionesSolicitudesXZComPro ;
      private decimal[] T00213_A1027OperacionesSolicitudesXZComAlm ;
      private bool[] T00213_n1027OperacionesSolicitudesXZComAlm ;
      private string[] T00213_A668OperacionesSolicitudesOrigenPa ;
      private bool[] T00213_n668OperacionesSolicitudesOrigenPa ;
      private long[] T00212_A554OperacionesId ;
      private long[] T00212_A650OperacionesSolicitudesId ;
      private string[] T00212_A651OperacionesSolicitudesNombre ;
      private bool[] T00212_n651OperacionesSolicitudesNombre ;
      private decimal[] T00212_A654OperacionesSolicitudesPFinal ;
      private bool[] T00212_n654OperacionesSolicitudesPFinal ;
      private decimal[] T00212_A653OperacionesSolicitudesComPro ;
      private bool[] T00212_n653OperacionesSolicitudesComPro ;
      private long[] T00212_A660OperacionesSolicitudesProvID ;
      private bool[] T00212_n660OperacionesSolicitudesProvID ;
      private string[] T00212_A661OperacionesSolicitudesProvNomb ;
      private bool[] T00212_n661OperacionesSolicitudesProvNomb ;
      private decimal[] T00212_A655OperacionesSolicitudesComProv ;
      private bool[] T00212_n655OperacionesSolicitudesComProv ;
      private decimal[] T00212_A656OperacionesSolicitudesComALM ;
      private bool[] T00212_n656OperacionesSolicitudesComALM ;
      private decimal[] T00212_A1029OperacionesSolicitudesXZComPro ;
      private bool[] T00212_n1029OperacionesSolicitudesXZComPro ;
      private decimal[] T00212_A1027OperacionesSolicitudesXZComAlm ;
      private bool[] T00212_n1027OperacionesSolicitudesXZComAlm ;
      private string[] T00212_A668OperacionesSolicitudesOrigenPa ;
      private bool[] T00212_n668OperacionesSolicitudesOrigenPa ;
      private long[] T002121_A554OperacionesId ;
      private long[] T002121_A650OperacionesSolicitudesId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class operaciones__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class operaciones__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
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
        Object[] prmT00212;
        prmT00212 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0) ,
        new ParDef("@OperacionesSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT00213;
        prmT00213 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0) ,
        new ParDef("@OperacionesSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT00214;
        prmT00214 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT00215;
        prmT00215 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT00216;
        prmT00216 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT00217;
        prmT00217 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT00218;
        prmT00218 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT00219;
        prmT00219 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT002110;
        prmT002110 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0) ,
        new ParDef("@OperacionesTipo",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesComercioId1",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@OperacionesComercioId2",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@OperacionesRef",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@OperacionesNombreRef",GXType.NChar,120,0){Nullable=true} ,
        new ParDef("@OperacionesOrdinal",GXType.Decimal,12,0){Nullable=true} ,
        new ParDef("@OperacionesIDORD",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@OperacionesTipoES",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@OperacionesImporte",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesMonId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@OperacionesMoneda",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesFacturaCod",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@OperacionesIva",GXType.Decimal,4,2){Nullable=true} ,
        new ParDef("@OperacionesComision",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesImporteGrabado",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesRequest",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@OperacionesResponse",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@OperacionesComprobantePago",GXType.NChar,256,0){Nullable=true} ,
        new ParDef("@OperacionesFechaAlta",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@OperacionesFechaPago",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@OperacionesAux1",GXType.NVarChar,120,0){Nullable=true} ,
        new ParDef("@OperacionesAux2",GXType.NVarChar,120,0){Nullable=true} ,
        new ParDef("@OperacionesAux3",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@OperacionesFechaDesde",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@OperacionesFechaHasta",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@OperacionesPeriodoCod",GXType.NVarChar,10,0){Nullable=true} ,
        new ParDef("@OperacionesBlob1",GXType.Blob,1024,0){Nullable=true,InDB=true} ,
        new ParDef("@OperacionesBlob2",GXType.Blob,1024,0){Nullable=true,InDB=true} ,
        new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesUsrAlta",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@OperacionesUsrActualizacion",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT002111;
        prmT002111 = new Object[] {
        new ParDef("@OperacionesTipo",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesComercioId1",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@OperacionesComercioId2",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@OperacionesRef",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@OperacionesNombreRef",GXType.NChar,120,0){Nullable=true} ,
        new ParDef("@OperacionesOrdinal",GXType.Decimal,12,0){Nullable=true} ,
        new ParDef("@OperacionesIDORD",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@OperacionesTipoES",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@OperacionesImporte",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesMonId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@OperacionesMoneda",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesFacturaCod",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@OperacionesIva",GXType.Decimal,4,2){Nullable=true} ,
        new ParDef("@OperacionesComision",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesImporteGrabado",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesRequest",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@OperacionesResponse",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@OperacionesComprobantePago",GXType.NChar,256,0){Nullable=true} ,
        new ParDef("@OperacionesFechaAlta",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@OperacionesFechaPago",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@OperacionesAux1",GXType.NVarChar,120,0){Nullable=true} ,
        new ParDef("@OperacionesAux2",GXType.NVarChar,120,0){Nullable=true} ,
        new ParDef("@OperacionesAux3",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@OperacionesFechaDesde",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@OperacionesFechaHasta",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@OperacionesPeriodoCod",GXType.NVarChar,10,0){Nullable=true} ,
        new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesUsrAlta",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@OperacionesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT002112;
        prmT002112 = new Object[] {
        new ParDef("@OperacionesBlob1",GXType.Blob,1024,0){Nullable=true,InDB=true} ,
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT002113;
        prmT002113 = new Object[] {
        new ParDef("@OperacionesBlob2",GXType.Blob,1024,0){Nullable=true,InDB=true} ,
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT002114;
        prmT002114 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT002115;
        prmT002115 = new Object[] {
        };
        Object[] prmT002116;
        prmT002116 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0) ,
        new ParDef("@OperacionesSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT002117;
        prmT002117 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0) ,
        new ParDef("@OperacionesSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT002118;
        prmT002118 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0) ,
        new ParDef("@OperacionesSolicitudesId",GXType.Decimal,18,0) ,
        new ParDef("@OperacionesSolicitudesNombre",GXType.NChar,120,0){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesPFinal",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesComPro",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesProvID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesProvNomb",GXType.NChar,120,0){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesComProv",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesComALM",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesXZComPro",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesXZComAlm",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesOrigenPa",GXType.NChar,1,0){Nullable=true}
        };
        Object[] prmT002119;
        prmT002119 = new Object[] {
        new ParDef("@OperacionesSolicitudesNombre",GXType.NChar,120,0){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesPFinal",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesComPro",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesProvID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesProvNomb",GXType.NChar,120,0){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesComProv",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesComALM",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesXZComPro",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesXZComAlm",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesOrigenPa",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@OperacionesId",GXType.Decimal,18,0) ,
        new ParDef("@OperacionesSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT002120;
        prmT002120 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0) ,
        new ParDef("@OperacionesSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmT002121;
        prmT002121 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00212", "SELECT [OperacionesId], [OperacionesSolicitudesId], [OperacionesSolicitudesNombre], [OperacionesSolicitudesPFinal], [OperacionesSolicitudesComPro], [OperacionesSolicitudesProvID], [OperacionesSolicitudesProvNomb], [OperacionesSolicitudesComProv], [OperacionesSolicitudesComALM], [OperacionesSolicitudesXZComPro], [OperacionesSolicitudesXZComAlm], [OperacionesSolicitudesOrigenPa] FROM [OperacionesSolicitudes] WITH (UPDLOCK) WHERE [OperacionesId] = @OperacionesId AND [OperacionesSolicitudesId] = @OperacionesSolicitudesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00212,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00213", "SELECT [OperacionesId], [OperacionesSolicitudesId], [OperacionesSolicitudesNombre], [OperacionesSolicitudesPFinal], [OperacionesSolicitudesComPro], [OperacionesSolicitudesProvID], [OperacionesSolicitudesProvNomb], [OperacionesSolicitudesComProv], [OperacionesSolicitudesComALM], [OperacionesSolicitudesXZComPro], [OperacionesSolicitudesXZComAlm], [OperacionesSolicitudesOrigenPa] FROM [OperacionesSolicitudes] WHERE [OperacionesId] = @OperacionesId AND [OperacionesSolicitudesId] = @OperacionesSolicitudesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00213,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00214", "SELECT [OperacionesId], [OperacionesTipo], [OperacionesComercioId1], [OperacionesComercioId2], [OperacionesRef], [OperacionesNombreRef], [OperacionesOrdinal], [OperacionesIDORD], [OperacionesTipoES], [OperacionesImporte], [OperacionesMonId], [OperacionesMoneda], [OperacionesFacturaCod], [OperacionesIva], [OperacionesComision], [OperacionesImporteGrabado], [OperacionesRequest], [OperacionesResponse], [OperacionesComprobantePago], [OperacionesFechaAlta], [OperacionesFechaPago], [OperacionesAux1], [OperacionesAux2], [OperacionesAux3], [OperacionesFechaDesde], [OperacionesFechaHasta], [OperacionesPeriodoCod], [OperacionesEstado], [OperacionesUsrAlta], [OperacionesUsrActualizacion], [OperacionesBlob1], [OperacionesBlob2] FROM [Operaciones] WITH (UPDLOCK) WHERE [OperacionesId] = @OperacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00214,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00215", "SELECT [OperacionesId], [OperacionesTipo], [OperacionesComercioId1], [OperacionesComercioId2], [OperacionesRef], [OperacionesNombreRef], [OperacionesOrdinal], [OperacionesIDORD], [OperacionesTipoES], [OperacionesImporte], [OperacionesMonId], [OperacionesMoneda], [OperacionesFacturaCod], [OperacionesIva], [OperacionesComision], [OperacionesImporteGrabado], [OperacionesRequest], [OperacionesResponse], [OperacionesComprobantePago], [OperacionesFechaAlta], [OperacionesFechaPago], [OperacionesAux1], [OperacionesAux2], [OperacionesAux3], [OperacionesFechaDesde], [OperacionesFechaHasta], [OperacionesPeriodoCod], [OperacionesEstado], [OperacionesUsrAlta], [OperacionesUsrActualizacion], [OperacionesBlob1], [OperacionesBlob2] FROM [Operaciones] WHERE [OperacionesId] = @OperacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00215,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00216", "SELECT TM1.[OperacionesId], TM1.[OperacionesTipo], TM1.[OperacionesComercioId1], TM1.[OperacionesComercioId2], TM1.[OperacionesRef], TM1.[OperacionesNombreRef], TM1.[OperacionesOrdinal], TM1.[OperacionesIDORD], TM1.[OperacionesTipoES], TM1.[OperacionesImporte], TM1.[OperacionesMonId], TM1.[OperacionesMoneda], TM1.[OperacionesFacturaCod], TM1.[OperacionesIva], TM1.[OperacionesComision], TM1.[OperacionesImporteGrabado], TM1.[OperacionesRequest], TM1.[OperacionesResponse], TM1.[OperacionesComprobantePago], TM1.[OperacionesFechaAlta], TM1.[OperacionesFechaPago], TM1.[OperacionesAux1], TM1.[OperacionesAux2], TM1.[OperacionesAux3], TM1.[OperacionesFechaDesde], TM1.[OperacionesFechaHasta], TM1.[OperacionesPeriodoCod], TM1.[OperacionesEstado], TM1.[OperacionesUsrAlta], TM1.[OperacionesUsrActualizacion], TM1.[OperacionesBlob1], TM1.[OperacionesBlob2] FROM [Operaciones] TM1 WHERE TM1.[OperacionesId] = @OperacionesId ORDER BY TM1.[OperacionesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00216,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00217", "SELECT [OperacionesId] FROM [Operaciones] WHERE [OperacionesId] = @OperacionesId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00217,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00218", "SELECT TOP 1 [OperacionesId] FROM [Operaciones] WHERE ( [OperacionesId] > @OperacionesId) ORDER BY [OperacionesId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00218,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00219", "SELECT TOP 1 [OperacionesId] FROM [Operaciones] WHERE ( [OperacionesId] < @OperacionesId) ORDER BY [OperacionesId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00219,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002110", "INSERT INTO [Operaciones]([OperacionesId], [OperacionesTipo], [OperacionesComercioId1], [OperacionesComercioId2], [OperacionesRef], [OperacionesNombreRef], [OperacionesOrdinal], [OperacionesIDORD], [OperacionesTipoES], [OperacionesImporte], [OperacionesMonId], [OperacionesMoneda], [OperacionesFacturaCod], [OperacionesIva], [OperacionesComision], [OperacionesImporteGrabado], [OperacionesRequest], [OperacionesResponse], [OperacionesComprobantePago], [OperacionesFechaAlta], [OperacionesFechaPago], [OperacionesAux1], [OperacionesAux2], [OperacionesAux3], [OperacionesFechaDesde], [OperacionesFechaHasta], [OperacionesPeriodoCod], [OperacionesBlob1], [OperacionesBlob2], [OperacionesEstado], [OperacionesUsrAlta], [OperacionesUsrActualizacion]) VALUES(@OperacionesId, @OperacionesTipo, @OperacionesComercioId1, @OperacionesComercioId2, @OperacionesRef, @OperacionesNombreRef, @OperacionesOrdinal, @OperacionesIDORD, @OperacionesTipoES, @OperacionesImporte, @OperacionesMonId, @OperacionesMoneda, @OperacionesFacturaCod, @OperacionesIva, @OperacionesComision, @OperacionesImporteGrabado, @OperacionesRequest, @OperacionesResponse, @OperacionesComprobantePago, @OperacionesFechaAlta, @OperacionesFechaPago, @OperacionesAux1, @OperacionesAux2, @OperacionesAux3, @OperacionesFechaDesde, @OperacionesFechaHasta, @OperacionesPeriodoCod, @OperacionesBlob1, @OperacionesBlob2, @OperacionesEstado, @OperacionesUsrAlta, @OperacionesUsrActualizacion)", GxErrorMask.GX_NOMASK,prmT002110)
           ,new CursorDef("T002111", "UPDATE [Operaciones] SET [OperacionesTipo]=@OperacionesTipo, [OperacionesComercioId1]=@OperacionesComercioId1, [OperacionesComercioId2]=@OperacionesComercioId2, [OperacionesRef]=@OperacionesRef, [OperacionesNombreRef]=@OperacionesNombreRef, [OperacionesOrdinal]=@OperacionesOrdinal, [OperacionesIDORD]=@OperacionesIDORD, [OperacionesTipoES]=@OperacionesTipoES, [OperacionesImporte]=@OperacionesImporte, [OperacionesMonId]=@OperacionesMonId, [OperacionesMoneda]=@OperacionesMoneda, [OperacionesFacturaCod]=@OperacionesFacturaCod, [OperacionesIva]=@OperacionesIva, [OperacionesComision]=@OperacionesComision, [OperacionesImporteGrabado]=@OperacionesImporteGrabado, [OperacionesRequest]=@OperacionesRequest, [OperacionesResponse]=@OperacionesResponse, [OperacionesComprobantePago]=@OperacionesComprobantePago, [OperacionesFechaAlta]=@OperacionesFechaAlta, [OperacionesFechaPago]=@OperacionesFechaPago, [OperacionesAux1]=@OperacionesAux1, [OperacionesAux2]=@OperacionesAux2, [OperacionesAux3]=@OperacionesAux3, [OperacionesFechaDesde]=@OperacionesFechaDesde, [OperacionesFechaHasta]=@OperacionesFechaHasta, [OperacionesPeriodoCod]=@OperacionesPeriodoCod, [OperacionesEstado]=@OperacionesEstado, [OperacionesUsrAlta]=@OperacionesUsrAlta, [OperacionesUsrActualizacion]=@OperacionesUsrActualizacion  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK,prmT002111)
           ,new CursorDef("T002112", "UPDATE [Operaciones] SET [OperacionesBlob1]=@OperacionesBlob1  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK,prmT002112)
           ,new CursorDef("T002113", "UPDATE [Operaciones] SET [OperacionesBlob2]=@OperacionesBlob2  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK,prmT002113)
           ,new CursorDef("T002114", "DELETE FROM [Operaciones]  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK,prmT002114)
           ,new CursorDef("T002115", "SELECT [OperacionesId] FROM [Operaciones] ORDER BY [OperacionesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002115,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002116", "SELECT [OperacionesId], [OperacionesSolicitudesId], [OperacionesSolicitudesNombre], [OperacionesSolicitudesPFinal], [OperacionesSolicitudesComPro], [OperacionesSolicitudesProvID], [OperacionesSolicitudesProvNomb], [OperacionesSolicitudesComProv], [OperacionesSolicitudesComALM], [OperacionesSolicitudesXZComPro], [OperacionesSolicitudesXZComAlm], [OperacionesSolicitudesOrigenPa] FROM [OperacionesSolicitudes] WHERE [OperacionesId] = @OperacionesId and [OperacionesSolicitudesId] = @OperacionesSolicitudesId ORDER BY [OperacionesId], [OperacionesSolicitudesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002116,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002117", "SELECT [OperacionesId], [OperacionesSolicitudesId] FROM [OperacionesSolicitudes] WHERE [OperacionesId] = @OperacionesId AND [OperacionesSolicitudesId] = @OperacionesSolicitudesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002117,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002118", "INSERT INTO [OperacionesSolicitudes]([OperacionesId], [OperacionesSolicitudesId], [OperacionesSolicitudesNombre], [OperacionesSolicitudesPFinal], [OperacionesSolicitudesComPro], [OperacionesSolicitudesProvID], [OperacionesSolicitudesProvNomb], [OperacionesSolicitudesComProv], [OperacionesSolicitudesComALM], [OperacionesSolicitudesXZComPro], [OperacionesSolicitudesXZComAlm], [OperacionesSolicitudesOrigenPa]) VALUES(@OperacionesId, @OperacionesSolicitudesId, @OperacionesSolicitudesNombre, @OperacionesSolicitudesPFinal, @OperacionesSolicitudesComPro, @OperacionesSolicitudesProvID, @OperacionesSolicitudesProvNomb, @OperacionesSolicitudesComProv, @OperacionesSolicitudesComALM, @OperacionesSolicitudesXZComPro, @OperacionesSolicitudesXZComAlm, @OperacionesSolicitudesOrigenPa)", GxErrorMask.GX_NOMASK,prmT002118)
           ,new CursorDef("T002119", "UPDATE [OperacionesSolicitudes] SET [OperacionesSolicitudesNombre]=@OperacionesSolicitudesNombre, [OperacionesSolicitudesPFinal]=@OperacionesSolicitudesPFinal, [OperacionesSolicitudesComPro]=@OperacionesSolicitudesComPro, [OperacionesSolicitudesProvID]=@OperacionesSolicitudesProvID, [OperacionesSolicitudesProvNomb]=@OperacionesSolicitudesProvNomb, [OperacionesSolicitudesComProv]=@OperacionesSolicitudesComProv, [OperacionesSolicitudesComALM]=@OperacionesSolicitudesComALM, [OperacionesSolicitudesXZComPro]=@OperacionesSolicitudesXZComPro, [OperacionesSolicitudesXZComAlm]=@OperacionesSolicitudesXZComAlm, [OperacionesSolicitudesOrigenPa]=@OperacionesSolicitudesOrigenPa  WHERE [OperacionesId] = @OperacionesId AND [OperacionesSolicitudesId] = @OperacionesSolicitudesId", GxErrorMask.GX_NOMASK,prmT002119)
           ,new CursorDef("T002120", "DELETE FROM [OperacionesSolicitudes]  WHERE [OperacionesId] = @OperacionesId AND [OperacionesSolicitudesId] = @OperacionesSolicitudesId", GxErrorMask.GX_NOMASK,prmT002120)
           ,new CursorDef("T002121", "SELECT [OperacionesId], [OperacionesSolicitudesId] FROM [OperacionesSolicitudes] WHERE [OperacionesId] = @OperacionesId ORDER BY [OperacionesId], [OperacionesSolicitudesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002121,11, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((long[]) buf[8])[0] = rslt.getLong(6);
              ((bool[]) buf[9])[0] = rslt.wasNull(6);
              ((string[]) buf[10])[0] = rslt.getString(7, 120);
              ((bool[]) buf[11])[0] = rslt.wasNull(7);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(8);
              ((bool[]) buf[13])[0] = rslt.wasNull(8);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(9);
              ((bool[]) buf[15])[0] = rslt.wasNull(9);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(10);
              ((bool[]) buf[17])[0] = rslt.wasNull(10);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(11);
              ((bool[]) buf[19])[0] = rslt.wasNull(11);
              ((string[]) buf[20])[0] = rslt.getString(12, 1);
              ((bool[]) buf[21])[0] = rslt.wasNull(12);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((long[]) buf[8])[0] = rslt.getLong(6);
              ((bool[]) buf[9])[0] = rslt.wasNull(6);
              ((string[]) buf[10])[0] = rslt.getString(7, 120);
              ((bool[]) buf[11])[0] = rslt.wasNull(7);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(8);
              ((bool[]) buf[13])[0] = rslt.wasNull(8);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(9);
              ((bool[]) buf[15])[0] = rslt.wasNull(9);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(10);
              ((bool[]) buf[17])[0] = rslt.wasNull(10);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(11);
              ((bool[]) buf[19])[0] = rslt.wasNull(11);
              ((string[]) buf[20])[0] = rslt.getString(12, 1);
              ((bool[]) buf[21])[0] = rslt.wasNull(12);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((long[]) buf[5])[0] = rslt.getLong(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 25);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 120);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((long[]) buf[11])[0] = rslt.getLong(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getString(8, 20);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getString(9, 1);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((long[]) buf[19])[0] = rslt.getLong(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getString(12, 3);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((string[]) buf[23])[0] = rslt.getString(13, 25);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
              ((bool[]) buf[30])[0] = rslt.wasNull(16);
              ((string[]) buf[31])[0] = rslt.getLongVarchar(17);
              ((bool[]) buf[32])[0] = rslt.wasNull(17);
              ((string[]) buf[33])[0] = rslt.getLongVarchar(18);
              ((bool[]) buf[34])[0] = rslt.wasNull(18);
              ((string[]) buf[35])[0] = rslt.getString(19, 256);
              ((bool[]) buf[36])[0] = rslt.wasNull(19);
              ((DateTime[]) buf[37])[0] = rslt.getGXDate(20);
              ((bool[]) buf[38])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[39])[0] = rslt.getGXDateTime(21);
              ((bool[]) buf[40])[0] = rslt.wasNull(21);
              ((string[]) buf[41])[0] = rslt.getVarchar(22);
              ((bool[]) buf[42])[0] = rslt.wasNull(22);
              ((string[]) buf[43])[0] = rslt.getVarchar(23);
              ((bool[]) buf[44])[0] = rslt.wasNull(23);
              ((string[]) buf[45])[0] = rslt.getLongVarchar(24);
              ((bool[]) buf[46])[0] = rslt.wasNull(24);
              ((DateTime[]) buf[47])[0] = rslt.getGXDate(25);
              ((bool[]) buf[48])[0] = rslt.wasNull(25);
              ((DateTime[]) buf[49])[0] = rslt.getGXDate(26);
              ((bool[]) buf[50])[0] = rslt.wasNull(26);
              ((string[]) buf[51])[0] = rslt.getVarchar(27);
              ((bool[]) buf[52])[0] = rslt.wasNull(27);
              ((string[]) buf[53])[0] = rslt.getString(28, 3);
              ((bool[]) buf[54])[0] = rslt.wasNull(28);
              ((long[]) buf[55])[0] = rslt.getLong(29);
              ((bool[]) buf[56])[0] = rslt.wasNull(29);
              ((long[]) buf[57])[0] = rslt.getLong(30);
              ((bool[]) buf[58])[0] = rslt.wasNull(30);
              ((string[]) buf[59])[0] = rslt.getBLOBFile(31, "tmp", "");
              ((bool[]) buf[60])[0] = rslt.wasNull(31);
              ((string[]) buf[61])[0] = rslt.getBLOBFile(32, "tmp", "");
              ((bool[]) buf[62])[0] = rslt.wasNull(32);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((long[]) buf[5])[0] = rslt.getLong(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 25);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 120);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((long[]) buf[11])[0] = rslt.getLong(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getString(8, 20);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getString(9, 1);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((long[]) buf[19])[0] = rslt.getLong(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getString(12, 3);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((string[]) buf[23])[0] = rslt.getString(13, 25);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
              ((bool[]) buf[30])[0] = rslt.wasNull(16);
              ((string[]) buf[31])[0] = rslt.getLongVarchar(17);
              ((bool[]) buf[32])[0] = rslt.wasNull(17);
              ((string[]) buf[33])[0] = rslt.getLongVarchar(18);
              ((bool[]) buf[34])[0] = rslt.wasNull(18);
              ((string[]) buf[35])[0] = rslt.getString(19, 256);
              ((bool[]) buf[36])[0] = rslt.wasNull(19);
              ((DateTime[]) buf[37])[0] = rslt.getGXDate(20);
              ((bool[]) buf[38])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[39])[0] = rslt.getGXDateTime(21);
              ((bool[]) buf[40])[0] = rslt.wasNull(21);
              ((string[]) buf[41])[0] = rslt.getVarchar(22);
              ((bool[]) buf[42])[0] = rslt.wasNull(22);
              ((string[]) buf[43])[0] = rslt.getVarchar(23);
              ((bool[]) buf[44])[0] = rslt.wasNull(23);
              ((string[]) buf[45])[0] = rslt.getLongVarchar(24);
              ((bool[]) buf[46])[0] = rslt.wasNull(24);
              ((DateTime[]) buf[47])[0] = rslt.getGXDate(25);
              ((bool[]) buf[48])[0] = rslt.wasNull(25);
              ((DateTime[]) buf[49])[0] = rslt.getGXDate(26);
              ((bool[]) buf[50])[0] = rslt.wasNull(26);
              ((string[]) buf[51])[0] = rslt.getVarchar(27);
              ((bool[]) buf[52])[0] = rslt.wasNull(27);
              ((string[]) buf[53])[0] = rslt.getString(28, 3);
              ((bool[]) buf[54])[0] = rslt.wasNull(28);
              ((long[]) buf[55])[0] = rslt.getLong(29);
              ((bool[]) buf[56])[0] = rslt.wasNull(29);
              ((long[]) buf[57])[0] = rslt.getLong(30);
              ((bool[]) buf[58])[0] = rslt.wasNull(30);
              ((string[]) buf[59])[0] = rslt.getBLOBFile(31, "tmp", "");
              ((bool[]) buf[60])[0] = rslt.wasNull(31);
              ((string[]) buf[61])[0] = rslt.getBLOBFile(32, "tmp", "");
              ((bool[]) buf[62])[0] = rslt.wasNull(32);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((long[]) buf[5])[0] = rslt.getLong(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 25);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 120);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((long[]) buf[11])[0] = rslt.getLong(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getString(8, 20);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getString(9, 1);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((long[]) buf[19])[0] = rslt.getLong(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getString(12, 3);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((string[]) buf[23])[0] = rslt.getString(13, 25);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
              ((bool[]) buf[30])[0] = rslt.wasNull(16);
              ((string[]) buf[31])[0] = rslt.getLongVarchar(17);
              ((bool[]) buf[32])[0] = rslt.wasNull(17);
              ((string[]) buf[33])[0] = rslt.getLongVarchar(18);
              ((bool[]) buf[34])[0] = rslt.wasNull(18);
              ((string[]) buf[35])[0] = rslt.getString(19, 256);
              ((bool[]) buf[36])[0] = rslt.wasNull(19);
              ((DateTime[]) buf[37])[0] = rslt.getGXDate(20);
              ((bool[]) buf[38])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[39])[0] = rslt.getGXDateTime(21);
              ((bool[]) buf[40])[0] = rslt.wasNull(21);
              ((string[]) buf[41])[0] = rslt.getVarchar(22);
              ((bool[]) buf[42])[0] = rslt.wasNull(22);
              ((string[]) buf[43])[0] = rslt.getVarchar(23);
              ((bool[]) buf[44])[0] = rslt.wasNull(23);
              ((string[]) buf[45])[0] = rslt.getLongVarchar(24);
              ((bool[]) buf[46])[0] = rslt.wasNull(24);
              ((DateTime[]) buf[47])[0] = rslt.getGXDate(25);
              ((bool[]) buf[48])[0] = rslt.wasNull(25);
              ((DateTime[]) buf[49])[0] = rslt.getGXDate(26);
              ((bool[]) buf[50])[0] = rslt.wasNull(26);
              ((string[]) buf[51])[0] = rslt.getVarchar(27);
              ((bool[]) buf[52])[0] = rslt.wasNull(27);
              ((string[]) buf[53])[0] = rslt.getString(28, 3);
              ((bool[]) buf[54])[0] = rslt.wasNull(28);
              ((long[]) buf[55])[0] = rslt.getLong(29);
              ((bool[]) buf[56])[0] = rslt.wasNull(29);
              ((long[]) buf[57])[0] = rslt.getLong(30);
              ((bool[]) buf[58])[0] = rslt.wasNull(30);
              ((string[]) buf[59])[0] = rslt.getBLOBFile(31, "tmp", "");
              ((bool[]) buf[60])[0] = rslt.wasNull(31);
              ((string[]) buf[61])[0] = rslt.getBLOBFile(32, "tmp", "");
              ((bool[]) buf[62])[0] = rslt.wasNull(32);
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
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((long[]) buf[8])[0] = rslt.getLong(6);
              ((bool[]) buf[9])[0] = rslt.wasNull(6);
              ((string[]) buf[10])[0] = rslt.getString(7, 120);
              ((bool[]) buf[11])[0] = rslt.wasNull(7);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(8);
              ((bool[]) buf[13])[0] = rslt.wasNull(8);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(9);
              ((bool[]) buf[15])[0] = rslt.wasNull(9);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(10);
              ((bool[]) buf[17])[0] = rslt.wasNull(10);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(11);
              ((bool[]) buf[19])[0] = rslt.wasNull(11);
              ((string[]) buf[20])[0] = rslt.getString(12, 1);
              ((bool[]) buf[21])[0] = rslt.wasNull(12);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
  }

}

}
