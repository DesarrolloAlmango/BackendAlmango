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
   public class conexiones : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_datos") == 0 )
         {
            gxnrGridlevel_datos_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "conexiones.aspx")), "conexiones.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "conexiones.aspx")))) ;
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
                  AV7ConexionesID = GetPar( "ConexionesID");
                  AssignAttri("", false, "AV7ConexionesID", AV7ConexionesID);
                  GxWebStd.gx_hidden_field( context, "gxhash_vCONEXIONESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ConexionesID, "")), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Conexiones", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtConexionesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_datos_newrow_invoke( )
      {
         nRC_GXsfl_83 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_83"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_83_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_83_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_83_idx = GetPar( "sGXsfl_83_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_datos_newrow( ) ;
         /* End function gxnrGridlevel_datos_newrow_invoke */
      }

      public conexiones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public conexiones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_ConexionesID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ConexionesID = aP1_ConexionesID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbConexionesTipoIntegracion = new GXCombobox();
         cmbConexionesEstado = new GXCombobox();
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
         if ( cmbConexionesTipoIntegracion.ItemCount > 0 )
         {
            A964ConexionesTipoIntegracion = (short)(Math.Round(NumberUtil.Val( cmbConexionesTipoIntegracion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A964ConexionesTipoIntegracion), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n964ConexionesTipoIntegracion = false;
            AssignAttri("", false, "A964ConexionesTipoIntegracion", StringUtil.LTrimStr( (decimal)(A964ConexionesTipoIntegracion), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConexionesTipoIntegracion.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A964ConexionesTipoIntegracion), 4, 0));
            AssignProp("", false, cmbConexionesTipoIntegracion_Internalname, "Values", cmbConexionesTipoIntegracion.ToJavascriptSource(), true);
         }
         if ( cmbConexionesEstado.ItemCount > 0 )
         {
            A562ConexionesEstado = cmbConexionesEstado.getValidValue(A562ConexionesEstado);
            n562ConexionesEstado = false;
            AssignAttri("", false, "A562ConexionesEstado", A562ConexionesEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConexionesEstado.CurrentValue = StringUtil.RTrim( A562ConexionesEstado);
            AssignProp("", false, cmbConexionesEstado_Internalname, "Values", cmbConexionesEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConexionesID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConexionesID_Internalname, context.GetMessage( "Código de Conexión", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConexionesID_Internalname, StringUtil.RTrim( A552ConexionesID), StringUtil.RTrim( context.localUtil.Format( A552ConexionesID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConexionesID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConexionesID_Enabled, 1, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Conexiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConexionesNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConexionesNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConexionesNombre_Internalname, StringUtil.RTrim( A556ConexionesNombre), StringUtil.RTrim( context.localUtil.Format( A556ConexionesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConexionesNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConexionesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Conexiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbConexionesTipoIntegracion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbConexionesTipoIntegracion_Internalname, context.GetMessage( "Tipo Integracion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConexionesTipoIntegracion, cmbConexionesTipoIntegracion_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A964ConexionesTipoIntegracion), 4, 0)), 1, cmbConexionesTipoIntegracion_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbConexionesTipoIntegracion.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 0, "HLP_Conexiones.htm");
         cmbConexionesTipoIntegracion.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A964ConexionesTipoIntegracion), 4, 0));
         AssignProp("", false, cmbConexionesTipoIntegracion_Internalname, "Values", (string)(cmbConexionesTipoIntegracion.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConexionesHost_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConexionesHost_Internalname, context.GetMessage( "Host", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConexionesHost_Internalname, StringUtil.RTrim( A557ConexionesHost), StringUtil.RTrim( context.localUtil.Format( A557ConexionesHost, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConexionesHost_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConexionesHost_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Conexiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConexionesBaseURL_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConexionesBaseURL_Internalname, context.GetMessage( "URL", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConexionesBaseURL_Internalname, StringUtil.RTrim( A558ConexionesBaseURL), StringUtil.RTrim( context.localUtil.Format( A558ConexionesBaseURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConexionesBaseURL_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConexionesBaseURL_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Conexiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConexionesPort_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConexionesPort_Internalname, context.GetMessage( "Puerto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConexionesPort_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A559ConexionesPort), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtConexionesPort_Enabled!=0) ? context.localUtil.Format( (decimal)(A559ConexionesPort), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A559ConexionesPort), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConexionesPort_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConexionesPort_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Conexiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConexionesApiKey_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConexionesApiKey_Internalname, context.GetMessage( "Key", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConexionesApiKey_Internalname, StringUtil.RTrim( A560ConexionesApiKey), StringUtil.RTrim( context.localUtil.Format( A560ConexionesApiKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConexionesApiKey_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConexionesApiKey_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Conexiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConexionesUsr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConexionesUsr_Internalname, context.GetMessage( "Usuario", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConexionesUsr_Internalname, StringUtil.RTrim( A561ConexionesUsr), StringUtil.RTrim( context.localUtil.Format( A561ConexionesUsr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConexionesUsr_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConexionesUsr_Enabled, 0, "text", "", 64, "chr", 1, "row", 64, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Conexiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConexionesAux1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConexionesAux1_Internalname, context.GetMessage( "Primer Auxiliar", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConexionesAux1_Internalname, StringUtil.RTrim( A563ConexionesAux1), StringUtil.RTrim( context.localUtil.Format( A563ConexionesAux1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConexionesAux1_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConexionesAux1_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Conexiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConexionesAux2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConexionesAux2_Internalname, context.GetMessage( "Segundo Auxiliar", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConexionesAux2_Internalname, StringUtil.RTrim( A564ConexionesAux2), StringUtil.RTrim( context.localUtil.Format( A564ConexionesAux2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConexionesAux2_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConexionesAux2_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Conexiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConexionesAux3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConexionesAux3_Internalname, context.GetMessage( "Tercer Auxiliar", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConexionesAux3_Internalname, StringUtil.RTrim( A565ConexionesAux3), StringUtil.RTrim( context.localUtil.Format( A565ConexionesAux3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConexionesAux3_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConexionesAux3_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Conexiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbConexionesEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbConexionesEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConexionesEstado, cmbConexionesEstado_Internalname, StringUtil.RTrim( A562ConexionesEstado), 1, cmbConexionesEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbConexionesEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "", true, 0, "HLP_Conexiones.htm");
         cmbConexionesEstado.CurrentValue = StringUtil.RTrim( A562ConexionesEstado);
         AssignProp("", false, cmbConexionesEstado_Internalname, "Values", (string)(cmbConexionesEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_datos_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_datos( ) ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Conexiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Conexiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Conexiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_datos( )
      {
         /*  Grid Control  */
         StartGridControl83( ) ;
         nGXsfl_83_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount81 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_81 = 1;
               ScanStart2081( ) ;
               while ( RcdFound81 != 0 )
               {
                  init_level_properties81( ) ;
                  getByPrimaryKey2081( ) ;
                  AddRow2081( ) ;
                  ScanNext2081( ) ;
               }
               ScanEnd2081( ) ;
               nBlankRcdCount81 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal2081( ) ;
            standaloneModal2081( ) ;
            sMode81 = Gx_mode;
            while ( nGXsfl_83_idx < nRC_GXsfl_83 )
            {
               bGXsfl_83_Refreshing = true;
               ReadRow2081( ) ;
               edtConexionesDatosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONEXIONESDATOSID_"+sGXsfl_83_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtConexionesDatosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesDatosId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtConexionesDatosInt_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONEXIONESDATOSINT_"+sGXsfl_83_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtConexionesDatosInt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesDatosInt_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtConexionesDatosExt_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONEXIONESDATOSEXT_"+sGXsfl_83_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtConexionesDatosExt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesDatosExt_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtConexionesDatosDetalle_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONEXIONESDATOSDETALLE_"+sGXsfl_83_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtConexionesDatosDetalle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesDatosDetalle_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               if ( ( nRcdExists_81 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal2081( ) ;
               }
               SendRow2081( ) ;
               bGXsfl_83_Refreshing = false;
            }
            Gx_mode = sMode81;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount81 = 5;
            nRcdExists_81 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart2081( ) ;
               while ( RcdFound81 != 0 )
               {
                  sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_8381( ) ;
                  init_level_properties81( ) ;
                  standaloneNotModal2081( ) ;
                  getByPrimaryKey2081( ) ;
                  standaloneModal2081( ) ;
                  AddRow2081( ) ;
                  ScanNext2081( ) ;
               }
               ScanEnd2081( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode81 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx+1), 4, 0), 4, "0");
            SubsflControlProps_8381( ) ;
            InitAll2081( ) ;
            init_level_properties81( ) ;
            nRcdExists_81 = 0;
            nIsMod_81 = 0;
            nRcdDeleted_81 = 0;
            nBlankRcdCount81 = (short)(nBlankRcdUsr81+nBlankRcdCount81);
            fRowAdded = 0;
            while ( nBlankRcdCount81 > 0 )
            {
               standaloneNotModal2081( ) ;
               standaloneModal2081( ) ;
               AddRow2081( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtConexionesDatosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount81 = (short)(nBlankRcdCount81-1);
            }
            Gx_mode = sMode81;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_datosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_datos", Gridlevel_datosContainer, subGridlevel_datos_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_datosContainerData", Gridlevel_datosContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_datosContainerData"+"V", Gridlevel_datosContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_datosContainerData"+"V"+"\" value='"+Gridlevel_datosContainer.GridValuesHidden()+"'/>") ;
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
         E11202 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z552ConexionesID = cgiGet( "Z552ConexionesID");
               Z556ConexionesNombre = cgiGet( "Z556ConexionesNombre");
               n556ConexionesNombre = (String.IsNullOrEmpty(StringUtil.RTrim( A556ConexionesNombre)) ? true : false);
               Z964ConexionesTipoIntegracion = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z964ConexionesTipoIntegracion"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n964ConexionesTipoIntegracion = ((0==A964ConexionesTipoIntegracion) ? true : false);
               Z557ConexionesHost = cgiGet( "Z557ConexionesHost");
               n557ConexionesHost = (String.IsNullOrEmpty(StringUtil.RTrim( A557ConexionesHost)) ? true : false);
               Z558ConexionesBaseURL = cgiGet( "Z558ConexionesBaseURL");
               n558ConexionesBaseURL = (String.IsNullOrEmpty(StringUtil.RTrim( A558ConexionesBaseURL)) ? true : false);
               Z559ConexionesPort = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z559ConexionesPort"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n559ConexionesPort = ((0==A559ConexionesPort) ? true : false);
               Z560ConexionesApiKey = cgiGet( "Z560ConexionesApiKey");
               n560ConexionesApiKey = (String.IsNullOrEmpty(StringUtil.RTrim( A560ConexionesApiKey)) ? true : false);
               Z561ConexionesUsr = cgiGet( "Z561ConexionesUsr");
               n561ConexionesUsr = (String.IsNullOrEmpty(StringUtil.RTrim( A561ConexionesUsr)) ? true : false);
               Z563ConexionesAux1 = cgiGet( "Z563ConexionesAux1");
               n563ConexionesAux1 = (String.IsNullOrEmpty(StringUtil.RTrim( A563ConexionesAux1)) ? true : false);
               Z564ConexionesAux2 = cgiGet( "Z564ConexionesAux2");
               n564ConexionesAux2 = (String.IsNullOrEmpty(StringUtil.RTrim( A564ConexionesAux2)) ? true : false);
               Z565ConexionesAux3 = cgiGet( "Z565ConexionesAux3");
               n565ConexionesAux3 = (String.IsNullOrEmpty(StringUtil.RTrim( A565ConexionesAux3)) ? true : false);
               Z562ConexionesEstado = cgiGet( "Z562ConexionesEstado");
               n562ConexionesEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A562ConexionesEstado)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_83 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_83"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7ConexionesID = cgiGet( "vCONEXIONESID");
               AV15Pgmname = cgiGet( "vPGMNAME");
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Titletype = cgiGet( "DVPANEL_TABLEATTRIBUTES_Titletype");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A552ConexionesID = cgiGet( edtConexionesID_Internalname);
               n552ConexionesID = false;
               AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
               A556ConexionesNombre = cgiGet( edtConexionesNombre_Internalname);
               n556ConexionesNombre = false;
               AssignAttri("", false, "A556ConexionesNombre", A556ConexionesNombre);
               n556ConexionesNombre = (String.IsNullOrEmpty(StringUtil.RTrim( A556ConexionesNombre)) ? true : false);
               cmbConexionesTipoIntegracion.Name = cmbConexionesTipoIntegracion_Internalname;
               cmbConexionesTipoIntegracion.CurrentValue = cgiGet( cmbConexionesTipoIntegracion_Internalname);
               A964ConexionesTipoIntegracion = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbConexionesTipoIntegracion_Internalname), "."), 18, MidpointRounding.ToEven));
               n964ConexionesTipoIntegracion = false;
               AssignAttri("", false, "A964ConexionesTipoIntegracion", StringUtil.LTrimStr( (decimal)(A964ConexionesTipoIntegracion), 4, 0));
               n964ConexionesTipoIntegracion = ((0==A964ConexionesTipoIntegracion) ? true : false);
               A557ConexionesHost = cgiGet( edtConexionesHost_Internalname);
               n557ConexionesHost = false;
               AssignAttri("", false, "A557ConexionesHost", A557ConexionesHost);
               n557ConexionesHost = (String.IsNullOrEmpty(StringUtil.RTrim( A557ConexionesHost)) ? true : false);
               A558ConexionesBaseURL = cgiGet( edtConexionesBaseURL_Internalname);
               n558ConexionesBaseURL = false;
               AssignAttri("", false, "A558ConexionesBaseURL", A558ConexionesBaseURL);
               n558ConexionesBaseURL = (String.IsNullOrEmpty(StringUtil.RTrim( A558ConexionesBaseURL)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtConexionesPort_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConexionesPort_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONEXIONESPORT");
                  AnyError = 1;
                  GX_FocusControl = edtConexionesPort_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A559ConexionesPort = 0;
                  n559ConexionesPort = false;
                  AssignAttri("", false, "A559ConexionesPort", StringUtil.LTrimStr( (decimal)(A559ConexionesPort), 9, 0));
               }
               else
               {
                  A559ConexionesPort = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtConexionesPort_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n559ConexionesPort = false;
                  AssignAttri("", false, "A559ConexionesPort", StringUtil.LTrimStr( (decimal)(A559ConexionesPort), 9, 0));
               }
               n559ConexionesPort = ((0==A559ConexionesPort) ? true : false);
               A560ConexionesApiKey = cgiGet( edtConexionesApiKey_Internalname);
               n560ConexionesApiKey = false;
               AssignAttri("", false, "A560ConexionesApiKey", A560ConexionesApiKey);
               n560ConexionesApiKey = (String.IsNullOrEmpty(StringUtil.RTrim( A560ConexionesApiKey)) ? true : false);
               A561ConexionesUsr = cgiGet( edtConexionesUsr_Internalname);
               n561ConexionesUsr = false;
               AssignAttri("", false, "A561ConexionesUsr", A561ConexionesUsr);
               n561ConexionesUsr = (String.IsNullOrEmpty(StringUtil.RTrim( A561ConexionesUsr)) ? true : false);
               A563ConexionesAux1 = cgiGet( edtConexionesAux1_Internalname);
               n563ConexionesAux1 = false;
               AssignAttri("", false, "A563ConexionesAux1", A563ConexionesAux1);
               n563ConexionesAux1 = (String.IsNullOrEmpty(StringUtil.RTrim( A563ConexionesAux1)) ? true : false);
               A564ConexionesAux2 = cgiGet( edtConexionesAux2_Internalname);
               n564ConexionesAux2 = false;
               AssignAttri("", false, "A564ConexionesAux2", A564ConexionesAux2);
               n564ConexionesAux2 = (String.IsNullOrEmpty(StringUtil.RTrim( A564ConexionesAux2)) ? true : false);
               A565ConexionesAux3 = cgiGet( edtConexionesAux3_Internalname);
               n565ConexionesAux3 = false;
               AssignAttri("", false, "A565ConexionesAux3", A565ConexionesAux3);
               n565ConexionesAux3 = (String.IsNullOrEmpty(StringUtil.RTrim( A565ConexionesAux3)) ? true : false);
               cmbConexionesEstado.Name = cmbConexionesEstado_Internalname;
               cmbConexionesEstado.CurrentValue = cgiGet( cmbConexionesEstado_Internalname);
               A562ConexionesEstado = cgiGet( cmbConexionesEstado_Internalname);
               n562ConexionesEstado = false;
               AssignAttri("", false, "A562ConexionesEstado", A562ConexionesEstado);
               n562ConexionesEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A562ConexionesEstado)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Conexiones");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A552ConexionesID, Z552ConexionesID) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("conexiones:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A552ConexionesID = GetPar( "ConexionesID");
                  n552ConexionesID = false;
                  AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
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
                     sMode80 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode80;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound80 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_200( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CONEXIONESID");
                        AnyError = 1;
                        GX_FocusControl = edtConexionesID_Internalname;
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
                           E11202 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12202 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'ALTA AUTOMATICA'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'Alta Automatica' */
                           E13202 ();
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
            E12202 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2080( ) ;
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
            DisableAttributes2080( ) ;
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

      protected void CONFIRM_200( )
      {
         BeforeValidate2080( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2080( ) ;
            }
            else
            {
               CheckExtendedTable2080( ) ;
               CloseExtendedTableCursors2080( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode80 = Gx_mode;
            CONFIRM_2081( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode80;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode80;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_2081( )
      {
         nGXsfl_83_idx = 0;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            ReadRow2081( ) ;
            if ( ( nRcdExists_81 != 0 ) || ( nIsMod_81 != 0 ) )
            {
               GetKey2081( ) ;
               if ( ( nRcdExists_81 == 0 ) && ( nRcdDeleted_81 == 0 ) )
               {
                  if ( RcdFound81 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate2081( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2081( ) ;
                        CloseExtendedTableCursors2081( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CONEXIONESDATOSID_" + sGXsfl_83_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtConexionesDatosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound81 != 0 )
                  {
                     if ( nRcdDeleted_81 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey2081( ) ;
                        Load2081( ) ;
                        BeforeValidate2081( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2081( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_81 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate2081( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2081( ) ;
                              CloseExtendedTableCursors2081( ) ;
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
                     if ( nRcdDeleted_81 == 0 )
                     {
                        GXCCtl = "CONEXIONESDATOSID_" + sGXsfl_83_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtConexionesDatosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtConexionesDatosId_Internalname, StringUtil.RTrim( A553ConexionesDatosId)) ;
            ChangePostValue( edtConexionesDatosInt_Internalname, StringUtil.RTrim( A566ConexionesDatosInt)) ;
            ChangePostValue( edtConexionesDatosExt_Internalname, StringUtil.RTrim( A567ConexionesDatosExt)) ;
            ChangePostValue( edtConexionesDatosDetalle_Internalname, StringUtil.RTrim( A568ConexionesDatosDetalle)) ;
            ChangePostValue( "ZT_"+"Z553ConexionesDatosId_"+sGXsfl_83_idx, StringUtil.RTrim( Z553ConexionesDatosId)) ;
            ChangePostValue( "ZT_"+"Z566ConexionesDatosInt_"+sGXsfl_83_idx, StringUtil.RTrim( Z566ConexionesDatosInt)) ;
            ChangePostValue( "ZT_"+"Z567ConexionesDatosExt_"+sGXsfl_83_idx, StringUtil.RTrim( Z567ConexionesDatosExt)) ;
            ChangePostValue( "ZT_"+"Z568ConexionesDatosDetalle_"+sGXsfl_83_idx, StringUtil.RTrim( Z568ConexionesDatosDetalle)) ;
            ChangePostValue( "nRcdDeleted_81_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_81), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_81_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_81), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_81_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_81), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_81 != 0 )
            {
               ChangePostValue( "CONEXIONESDATOSID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONEXIONESDATOSINT_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosInt_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONEXIONESDATOSEXT_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosExt_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONEXIONESDATOSDETALLE_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosDetalle_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption200( )
      {
      }

      protected void E11202( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWConexiones_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWConexiones_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWConexiones_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV15Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12202( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("conexionesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E13202( )
      {
         /* 'Alta Automatica' Routine */
         returnInSub = false;
         new aautconexiones(context ).execute( ) ;
      }

      protected void ZM2080( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z556ConexionesNombre = T00205_A556ConexionesNombre[0];
               Z964ConexionesTipoIntegracion = T00205_A964ConexionesTipoIntegracion[0];
               Z557ConexionesHost = T00205_A557ConexionesHost[0];
               Z558ConexionesBaseURL = T00205_A558ConexionesBaseURL[0];
               Z559ConexionesPort = T00205_A559ConexionesPort[0];
               Z560ConexionesApiKey = T00205_A560ConexionesApiKey[0];
               Z561ConexionesUsr = T00205_A561ConexionesUsr[0];
               Z563ConexionesAux1 = T00205_A563ConexionesAux1[0];
               Z564ConexionesAux2 = T00205_A564ConexionesAux2[0];
               Z565ConexionesAux3 = T00205_A565ConexionesAux3[0];
               Z562ConexionesEstado = T00205_A562ConexionesEstado[0];
            }
            else
            {
               Z556ConexionesNombre = A556ConexionesNombre;
               Z964ConexionesTipoIntegracion = A964ConexionesTipoIntegracion;
               Z557ConexionesHost = A557ConexionesHost;
               Z558ConexionesBaseURL = A558ConexionesBaseURL;
               Z559ConexionesPort = A559ConexionesPort;
               Z560ConexionesApiKey = A560ConexionesApiKey;
               Z561ConexionesUsr = A561ConexionesUsr;
               Z563ConexionesAux1 = A563ConexionesAux1;
               Z564ConexionesAux2 = A564ConexionesAux2;
               Z565ConexionesAux3 = A565ConexionesAux3;
               Z562ConexionesEstado = A562ConexionesEstado;
            }
         }
         if ( GX_JID == -6 )
         {
            Z552ConexionesID = A552ConexionesID;
            Z556ConexionesNombre = A556ConexionesNombre;
            Z964ConexionesTipoIntegracion = A964ConexionesTipoIntegracion;
            Z557ConexionesHost = A557ConexionesHost;
            Z558ConexionesBaseURL = A558ConexionesBaseURL;
            Z559ConexionesPort = A559ConexionesPort;
            Z560ConexionesApiKey = A560ConexionesApiKey;
            Z561ConexionesUsr = A561ConexionesUsr;
            Z563ConexionesAux1 = A563ConexionesAux1;
            Z564ConexionesAux2 = A564ConexionesAux2;
            Z565ConexionesAux3 = A565ConexionesAux3;
            Z562ConexionesEstado = A562ConexionesEstado;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ConexionesID)) )
         {
            A552ConexionesID = AV7ConexionesID;
            n552ConexionesID = false;
            AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ConexionesID)) )
         {
            edtConexionesID_Enabled = 0;
            AssignProp("", false, edtConexionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesID_Enabled), 5, 0), true);
         }
         else
         {
            edtConexionesID_Enabled = 1;
            AssignProp("", false, edtConexionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesID_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ConexionesID)) )
         {
            edtConexionesID_Enabled = 0;
            AssignProp("", false, edtConexionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesID_Enabled), 5, 0), true);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV15Pgmname = "Conexiones";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         }
      }

      protected void Load2080( )
      {
         /* Using cursor T00206 */
         pr_default.execute(4, new Object[] {n552ConexionesID, A552ConexionesID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound80 = 1;
            A556ConexionesNombre = T00206_A556ConexionesNombre[0];
            n556ConexionesNombre = T00206_n556ConexionesNombre[0];
            AssignAttri("", false, "A556ConexionesNombre", A556ConexionesNombre);
            A964ConexionesTipoIntegracion = T00206_A964ConexionesTipoIntegracion[0];
            n964ConexionesTipoIntegracion = T00206_n964ConexionesTipoIntegracion[0];
            AssignAttri("", false, "A964ConexionesTipoIntegracion", StringUtil.LTrimStr( (decimal)(A964ConexionesTipoIntegracion), 4, 0));
            A557ConexionesHost = T00206_A557ConexionesHost[0];
            n557ConexionesHost = T00206_n557ConexionesHost[0];
            AssignAttri("", false, "A557ConexionesHost", A557ConexionesHost);
            A558ConexionesBaseURL = T00206_A558ConexionesBaseURL[0];
            n558ConexionesBaseURL = T00206_n558ConexionesBaseURL[0];
            AssignAttri("", false, "A558ConexionesBaseURL", A558ConexionesBaseURL);
            A559ConexionesPort = T00206_A559ConexionesPort[0];
            n559ConexionesPort = T00206_n559ConexionesPort[0];
            AssignAttri("", false, "A559ConexionesPort", StringUtil.LTrimStr( (decimal)(A559ConexionesPort), 9, 0));
            A560ConexionesApiKey = T00206_A560ConexionesApiKey[0];
            n560ConexionesApiKey = T00206_n560ConexionesApiKey[0];
            AssignAttri("", false, "A560ConexionesApiKey", A560ConexionesApiKey);
            A561ConexionesUsr = T00206_A561ConexionesUsr[0];
            n561ConexionesUsr = T00206_n561ConexionesUsr[0];
            AssignAttri("", false, "A561ConexionesUsr", A561ConexionesUsr);
            A563ConexionesAux1 = T00206_A563ConexionesAux1[0];
            n563ConexionesAux1 = T00206_n563ConexionesAux1[0];
            AssignAttri("", false, "A563ConexionesAux1", A563ConexionesAux1);
            A564ConexionesAux2 = T00206_A564ConexionesAux2[0];
            n564ConexionesAux2 = T00206_n564ConexionesAux2[0];
            AssignAttri("", false, "A564ConexionesAux2", A564ConexionesAux2);
            A565ConexionesAux3 = T00206_A565ConexionesAux3[0];
            n565ConexionesAux3 = T00206_n565ConexionesAux3[0];
            AssignAttri("", false, "A565ConexionesAux3", A565ConexionesAux3);
            A562ConexionesEstado = T00206_A562ConexionesEstado[0];
            n562ConexionesEstado = T00206_n562ConexionesEstado[0];
            AssignAttri("", false, "A562ConexionesEstado", A562ConexionesEstado);
            ZM2080( -6) ;
         }
         pr_default.close(4);
         OnLoadActions2080( ) ;
      }

      protected void OnLoadActions2080( )
      {
         AV15Pgmname = "Conexiones";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
      }

      protected void CheckExtendedTable2080( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV15Pgmname = "Conexiones";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         if ( ! ( ( A964ConexionesTipoIntegracion == 1 ) || ( A964ConexionesTipoIntegracion == 2 ) || (0==A964ConexionesTipoIntegracion) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Conexiones Tipo Integracion", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "CONEXIONESTIPOINTEGRACION");
            AnyError = 1;
            GX_FocusControl = cmbConexionesTipoIntegracion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A562ConexionesEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A562ConexionesEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A562ConexionesEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A562ConexionesEstado, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A562ConexionesEstado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "CONEXIONESESTADO");
            AnyError = 1;
            GX_FocusControl = cmbConexionesEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2080( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2080( )
      {
         /* Using cursor T00207 */
         pr_default.execute(5, new Object[] {n552ConexionesID, A552ConexionesID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound80 = 1;
         }
         else
         {
            RcdFound80 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00205 */
         pr_default.execute(3, new Object[] {n552ConexionesID, A552ConexionesID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM2080( 6) ;
            RcdFound80 = 1;
            A552ConexionesID = T00205_A552ConexionesID[0];
            n552ConexionesID = T00205_n552ConexionesID[0];
            AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
            A556ConexionesNombre = T00205_A556ConexionesNombre[0];
            n556ConexionesNombre = T00205_n556ConexionesNombre[0];
            AssignAttri("", false, "A556ConexionesNombre", A556ConexionesNombre);
            A964ConexionesTipoIntegracion = T00205_A964ConexionesTipoIntegracion[0];
            n964ConexionesTipoIntegracion = T00205_n964ConexionesTipoIntegracion[0];
            AssignAttri("", false, "A964ConexionesTipoIntegracion", StringUtil.LTrimStr( (decimal)(A964ConexionesTipoIntegracion), 4, 0));
            A557ConexionesHost = T00205_A557ConexionesHost[0];
            n557ConexionesHost = T00205_n557ConexionesHost[0];
            AssignAttri("", false, "A557ConexionesHost", A557ConexionesHost);
            A558ConexionesBaseURL = T00205_A558ConexionesBaseURL[0];
            n558ConexionesBaseURL = T00205_n558ConexionesBaseURL[0];
            AssignAttri("", false, "A558ConexionesBaseURL", A558ConexionesBaseURL);
            A559ConexionesPort = T00205_A559ConexionesPort[0];
            n559ConexionesPort = T00205_n559ConexionesPort[0];
            AssignAttri("", false, "A559ConexionesPort", StringUtil.LTrimStr( (decimal)(A559ConexionesPort), 9, 0));
            A560ConexionesApiKey = T00205_A560ConexionesApiKey[0];
            n560ConexionesApiKey = T00205_n560ConexionesApiKey[0];
            AssignAttri("", false, "A560ConexionesApiKey", A560ConexionesApiKey);
            A561ConexionesUsr = T00205_A561ConexionesUsr[0];
            n561ConexionesUsr = T00205_n561ConexionesUsr[0];
            AssignAttri("", false, "A561ConexionesUsr", A561ConexionesUsr);
            A563ConexionesAux1 = T00205_A563ConexionesAux1[0];
            n563ConexionesAux1 = T00205_n563ConexionesAux1[0];
            AssignAttri("", false, "A563ConexionesAux1", A563ConexionesAux1);
            A564ConexionesAux2 = T00205_A564ConexionesAux2[0];
            n564ConexionesAux2 = T00205_n564ConexionesAux2[0];
            AssignAttri("", false, "A564ConexionesAux2", A564ConexionesAux2);
            A565ConexionesAux3 = T00205_A565ConexionesAux3[0];
            n565ConexionesAux3 = T00205_n565ConexionesAux3[0];
            AssignAttri("", false, "A565ConexionesAux3", A565ConexionesAux3);
            A562ConexionesEstado = T00205_A562ConexionesEstado[0];
            n562ConexionesEstado = T00205_n562ConexionesEstado[0];
            AssignAttri("", false, "A562ConexionesEstado", A562ConexionesEstado);
            Z552ConexionesID = A552ConexionesID;
            sMode80 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2080( ) ;
            if ( AnyError == 1 )
            {
               RcdFound80 = 0;
               InitializeNonKey2080( ) ;
            }
            Gx_mode = sMode80;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound80 = 0;
            InitializeNonKey2080( ) ;
            sMode80 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode80;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey2080( ) ;
         if ( RcdFound80 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound80 = 0;
         /* Using cursor T00208 */
         pr_default.execute(6, new Object[] {n552ConexionesID, A552ConexionesID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00208_A552ConexionesID[0], A552ConexionesID) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00208_A552ConexionesID[0], A552ConexionesID) > 0 ) ) )
            {
               A552ConexionesID = T00208_A552ConexionesID[0];
               n552ConexionesID = T00208_n552ConexionesID[0];
               AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
               RcdFound80 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound80 = 0;
         /* Using cursor T00209 */
         pr_default.execute(7, new Object[] {n552ConexionesID, A552ConexionesID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00209_A552ConexionesID[0], A552ConexionesID) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00209_A552ConexionesID[0], A552ConexionesID) < 0 ) ) )
            {
               A552ConexionesID = T00209_A552ConexionesID[0];
               n552ConexionesID = T00209_n552ConexionesID[0];
               AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
               RcdFound80 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2080( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtConexionesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2080( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound80 == 1 )
            {
               if ( StringUtil.StrCmp(A552ConexionesID, Z552ConexionesID) != 0 )
               {
                  A552ConexionesID = Z552ConexionesID;
                  n552ConexionesID = false;
                  AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CONEXIONESID");
                  AnyError = 1;
                  GX_FocusControl = edtConexionesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtConexionesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2080( ) ;
                  GX_FocusControl = edtConexionesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A552ConexionesID, Z552ConexionesID) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtConexionesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2080( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONEXIONESID");
                     AnyError = 1;
                     GX_FocusControl = edtConexionesID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtConexionesID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2080( ) ;
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
         if ( StringUtil.StrCmp(A552ConexionesID, Z552ConexionesID) != 0 )
         {
            A552ConexionesID = Z552ConexionesID;
            n552ConexionesID = false;
            AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CONEXIONESID");
            AnyError = 1;
            GX_FocusControl = edtConexionesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtConexionesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2080( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00204 */
            pr_default.execute(2, new Object[] {n552ConexionesID, A552ConexionesID});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Conexiones"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z556ConexionesNombre, T00204_A556ConexionesNombre[0]) != 0 ) || ( Z964ConexionesTipoIntegracion != T00204_A964ConexionesTipoIntegracion[0] ) || ( StringUtil.StrCmp(Z557ConexionesHost, T00204_A557ConexionesHost[0]) != 0 ) || ( StringUtil.StrCmp(Z558ConexionesBaseURL, T00204_A558ConexionesBaseURL[0]) != 0 ) || ( Z559ConexionesPort != T00204_A559ConexionesPort[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z560ConexionesApiKey, T00204_A560ConexionesApiKey[0]) != 0 ) || ( StringUtil.StrCmp(Z561ConexionesUsr, T00204_A561ConexionesUsr[0]) != 0 ) || ( StringUtil.StrCmp(Z563ConexionesAux1, T00204_A563ConexionesAux1[0]) != 0 ) || ( StringUtil.StrCmp(Z564ConexionesAux2, T00204_A564ConexionesAux2[0]) != 0 ) || ( StringUtil.StrCmp(Z565ConexionesAux3, T00204_A565ConexionesAux3[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z562ConexionesEstado, T00204_A562ConexionesEstado[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z556ConexionesNombre, T00204_A556ConexionesNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("conexiones:[seudo value changed for attri]"+"ConexionesNombre");
                  GXUtil.WriteLogRaw("Old: ",Z556ConexionesNombre);
                  GXUtil.WriteLogRaw("Current: ",T00204_A556ConexionesNombre[0]);
               }
               if ( Z964ConexionesTipoIntegracion != T00204_A964ConexionesTipoIntegracion[0] )
               {
                  GXUtil.WriteLog("conexiones:[seudo value changed for attri]"+"ConexionesTipoIntegracion");
                  GXUtil.WriteLogRaw("Old: ",Z964ConexionesTipoIntegracion);
                  GXUtil.WriteLogRaw("Current: ",T00204_A964ConexionesTipoIntegracion[0]);
               }
               if ( StringUtil.StrCmp(Z557ConexionesHost, T00204_A557ConexionesHost[0]) != 0 )
               {
                  GXUtil.WriteLog("conexiones:[seudo value changed for attri]"+"ConexionesHost");
                  GXUtil.WriteLogRaw("Old: ",Z557ConexionesHost);
                  GXUtil.WriteLogRaw("Current: ",T00204_A557ConexionesHost[0]);
               }
               if ( StringUtil.StrCmp(Z558ConexionesBaseURL, T00204_A558ConexionesBaseURL[0]) != 0 )
               {
                  GXUtil.WriteLog("conexiones:[seudo value changed for attri]"+"ConexionesBaseURL");
                  GXUtil.WriteLogRaw("Old: ",Z558ConexionesBaseURL);
                  GXUtil.WriteLogRaw("Current: ",T00204_A558ConexionesBaseURL[0]);
               }
               if ( Z559ConexionesPort != T00204_A559ConexionesPort[0] )
               {
                  GXUtil.WriteLog("conexiones:[seudo value changed for attri]"+"ConexionesPort");
                  GXUtil.WriteLogRaw("Old: ",Z559ConexionesPort);
                  GXUtil.WriteLogRaw("Current: ",T00204_A559ConexionesPort[0]);
               }
               if ( StringUtil.StrCmp(Z560ConexionesApiKey, T00204_A560ConexionesApiKey[0]) != 0 )
               {
                  GXUtil.WriteLog("conexiones:[seudo value changed for attri]"+"ConexionesApiKey");
                  GXUtil.WriteLogRaw("Old: ",Z560ConexionesApiKey);
                  GXUtil.WriteLogRaw("Current: ",T00204_A560ConexionesApiKey[0]);
               }
               if ( StringUtil.StrCmp(Z561ConexionesUsr, T00204_A561ConexionesUsr[0]) != 0 )
               {
                  GXUtil.WriteLog("conexiones:[seudo value changed for attri]"+"ConexionesUsr");
                  GXUtil.WriteLogRaw("Old: ",Z561ConexionesUsr);
                  GXUtil.WriteLogRaw("Current: ",T00204_A561ConexionesUsr[0]);
               }
               if ( StringUtil.StrCmp(Z563ConexionesAux1, T00204_A563ConexionesAux1[0]) != 0 )
               {
                  GXUtil.WriteLog("conexiones:[seudo value changed for attri]"+"ConexionesAux1");
                  GXUtil.WriteLogRaw("Old: ",Z563ConexionesAux1);
                  GXUtil.WriteLogRaw("Current: ",T00204_A563ConexionesAux1[0]);
               }
               if ( StringUtil.StrCmp(Z564ConexionesAux2, T00204_A564ConexionesAux2[0]) != 0 )
               {
                  GXUtil.WriteLog("conexiones:[seudo value changed for attri]"+"ConexionesAux2");
                  GXUtil.WriteLogRaw("Old: ",Z564ConexionesAux2);
                  GXUtil.WriteLogRaw("Current: ",T00204_A564ConexionesAux2[0]);
               }
               if ( StringUtil.StrCmp(Z565ConexionesAux3, T00204_A565ConexionesAux3[0]) != 0 )
               {
                  GXUtil.WriteLog("conexiones:[seudo value changed for attri]"+"ConexionesAux3");
                  GXUtil.WriteLogRaw("Old: ",Z565ConexionesAux3);
                  GXUtil.WriteLogRaw("Current: ",T00204_A565ConexionesAux3[0]);
               }
               if ( StringUtil.StrCmp(Z562ConexionesEstado, T00204_A562ConexionesEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("conexiones:[seudo value changed for attri]"+"ConexionesEstado");
                  GXUtil.WriteLogRaw("Old: ",Z562ConexionesEstado);
                  GXUtil.WriteLogRaw("Current: ",T00204_A562ConexionesEstado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Conexiones"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2080( )
      {
         BeforeValidate2080( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2080( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2080( 0) ;
            CheckOptimisticConcurrency2080( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2080( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2080( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002010 */
                     pr_default.execute(8, new Object[] {n552ConexionesID, A552ConexionesID, n556ConexionesNombre, A556ConexionesNombre, n964ConexionesTipoIntegracion, A964ConexionesTipoIntegracion, n557ConexionesHost, A557ConexionesHost, n558ConexionesBaseURL, A558ConexionesBaseURL, n559ConexionesPort, A559ConexionesPort, n560ConexionesApiKey, A560ConexionesApiKey, n561ConexionesUsr, A561ConexionesUsr, n563ConexionesAux1, A563ConexionesAux1, n564ConexionesAux2, A564ConexionesAux2, n565ConexionesAux3, A565ConexionesAux3, n562ConexionesEstado, A562ConexionesEstado});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Conexiones");
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
                           ProcessLevel2080( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption200( ) ;
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
               Load2080( ) ;
            }
            EndLevel2080( ) ;
         }
         CloseExtendedTableCursors2080( ) ;
      }

      protected void Update2080( )
      {
         BeforeValidate2080( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2080( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2080( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2080( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2080( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002011 */
                     pr_default.execute(9, new Object[] {n556ConexionesNombre, A556ConexionesNombre, n964ConexionesTipoIntegracion, A964ConexionesTipoIntegracion, n557ConexionesHost, A557ConexionesHost, n558ConexionesBaseURL, A558ConexionesBaseURL, n559ConexionesPort, A559ConexionesPort, n560ConexionesApiKey, A560ConexionesApiKey, n561ConexionesUsr, A561ConexionesUsr, n563ConexionesAux1, A563ConexionesAux1, n564ConexionesAux2, A564ConexionesAux2, n565ConexionesAux3, A565ConexionesAux3, n562ConexionesEstado, A562ConexionesEstado, n552ConexionesID, A552ConexionesID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Conexiones");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Conexiones"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2080( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2080( ) ;
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
            EndLevel2080( ) ;
         }
         CloseExtendedTableCursors2080( ) ;
      }

      protected void DeferredUpdate2080( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2080( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2080( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2080( ) ;
            AfterConfirm2080( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2080( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart2081( ) ;
                  while ( RcdFound81 != 0 )
                  {
                     getByPrimaryKey2081( ) ;
                     Delete2081( ) ;
                     ScanNext2081( ) ;
                  }
                  ScanEnd2081( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002012 */
                     pr_default.execute(10, new Object[] {n552ConexionesID, A552ConexionesID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Conexiones");
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
         sMode80 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2080( ) ;
         Gx_mode = sMode80;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2080( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "Conexiones";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002013 */
            pr_default.execute(11, new Object[] {n552ConexionesID, A552ConexionesID});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Lista Mapeo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void ProcessNestedLevel2081( )
      {
         nGXsfl_83_idx = 0;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            ReadRow2081( ) ;
            if ( ( nRcdExists_81 != 0 ) || ( nIsMod_81 != 0 ) )
            {
               standaloneNotModal2081( ) ;
               GetKey2081( ) ;
               if ( ( nRcdExists_81 == 0 ) && ( nRcdDeleted_81 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert2081( ) ;
               }
               else
               {
                  if ( RcdFound81 != 0 )
                  {
                     if ( ( nRcdDeleted_81 != 0 ) && ( nRcdExists_81 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete2081( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_81 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update2081( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_81 == 0 )
                     {
                        GXCCtl = "CONEXIONESDATOSID_" + sGXsfl_83_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtConexionesDatosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtConexionesDatosId_Internalname, StringUtil.RTrim( A553ConexionesDatosId)) ;
            ChangePostValue( edtConexionesDatosInt_Internalname, StringUtil.RTrim( A566ConexionesDatosInt)) ;
            ChangePostValue( edtConexionesDatosExt_Internalname, StringUtil.RTrim( A567ConexionesDatosExt)) ;
            ChangePostValue( edtConexionesDatosDetalle_Internalname, StringUtil.RTrim( A568ConexionesDatosDetalle)) ;
            ChangePostValue( "ZT_"+"Z553ConexionesDatosId_"+sGXsfl_83_idx, StringUtil.RTrim( Z553ConexionesDatosId)) ;
            ChangePostValue( "ZT_"+"Z566ConexionesDatosInt_"+sGXsfl_83_idx, StringUtil.RTrim( Z566ConexionesDatosInt)) ;
            ChangePostValue( "ZT_"+"Z567ConexionesDatosExt_"+sGXsfl_83_idx, StringUtil.RTrim( Z567ConexionesDatosExt)) ;
            ChangePostValue( "ZT_"+"Z568ConexionesDatosDetalle_"+sGXsfl_83_idx, StringUtil.RTrim( Z568ConexionesDatosDetalle)) ;
            ChangePostValue( "nRcdDeleted_81_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_81), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_81_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_81), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_81_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_81), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_81 != 0 )
            {
               ChangePostValue( "CONEXIONESDATOSID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONEXIONESDATOSINT_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosInt_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONEXIONESDATOSEXT_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosExt_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONEXIONESDATOSDETALLE_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosDetalle_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2081( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_81 = 0;
         nIsMod_81 = 0;
         nRcdDeleted_81 = 0;
      }

      protected void ProcessLevel2080( )
      {
         /* Save parent mode. */
         sMode80 = Gx_mode;
         ProcessNestedLevel2081( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode80;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel2080( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2080( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.CommitDataStores("conexiones",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues200( ) ;
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
            context.RollbackDataStores("conexiones",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2080( )
      {
         /* Scan By routine */
         /* Using cursor T002014 */
         pr_default.execute(12);
         RcdFound80 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound80 = 1;
            A552ConexionesID = T002014_A552ConexionesID[0];
            n552ConexionesID = T002014_n552ConexionesID[0];
            AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2080( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound80 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound80 = 1;
            A552ConexionesID = T002014_A552ConexionesID[0];
            n552ConexionesID = T002014_n552ConexionesID[0];
            AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
         }
      }

      protected void ScanEnd2080( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm2080( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2080( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2080( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2080( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2080( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2080( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2080( )
      {
         edtConexionesID_Enabled = 0;
         AssignProp("", false, edtConexionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesID_Enabled), 5, 0), true);
         edtConexionesNombre_Enabled = 0;
         AssignProp("", false, edtConexionesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesNombre_Enabled), 5, 0), true);
         cmbConexionesTipoIntegracion.Enabled = 0;
         AssignProp("", false, cmbConexionesTipoIntegracion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConexionesTipoIntegracion.Enabled), 5, 0), true);
         edtConexionesHost_Enabled = 0;
         AssignProp("", false, edtConexionesHost_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesHost_Enabled), 5, 0), true);
         edtConexionesBaseURL_Enabled = 0;
         AssignProp("", false, edtConexionesBaseURL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesBaseURL_Enabled), 5, 0), true);
         edtConexionesPort_Enabled = 0;
         AssignProp("", false, edtConexionesPort_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesPort_Enabled), 5, 0), true);
         edtConexionesApiKey_Enabled = 0;
         AssignProp("", false, edtConexionesApiKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesApiKey_Enabled), 5, 0), true);
         edtConexionesUsr_Enabled = 0;
         AssignProp("", false, edtConexionesUsr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesUsr_Enabled), 5, 0), true);
         edtConexionesAux1_Enabled = 0;
         AssignProp("", false, edtConexionesAux1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesAux1_Enabled), 5, 0), true);
         edtConexionesAux2_Enabled = 0;
         AssignProp("", false, edtConexionesAux2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesAux2_Enabled), 5, 0), true);
         edtConexionesAux3_Enabled = 0;
         AssignProp("", false, edtConexionesAux3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesAux3_Enabled), 5, 0), true);
         cmbConexionesEstado.Enabled = 0;
         AssignProp("", false, cmbConexionesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConexionesEstado.Enabled), 5, 0), true);
      }

      protected void ZM2081( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z566ConexionesDatosInt = T00203_A566ConexionesDatosInt[0];
               Z567ConexionesDatosExt = T00203_A567ConexionesDatosExt[0];
               Z568ConexionesDatosDetalle = T00203_A568ConexionesDatosDetalle[0];
            }
            else
            {
               Z566ConexionesDatosInt = A566ConexionesDatosInt;
               Z567ConexionesDatosExt = A567ConexionesDatosExt;
               Z568ConexionesDatosDetalle = A568ConexionesDatosDetalle;
            }
         }
         if ( GX_JID == -7 )
         {
            Z552ConexionesID = A552ConexionesID;
            Z553ConexionesDatosId = A553ConexionesDatosId;
            Z566ConexionesDatosInt = A566ConexionesDatosInt;
            Z567ConexionesDatosExt = A567ConexionesDatosExt;
            Z568ConexionesDatosDetalle = A568ConexionesDatosDetalle;
         }
      }

      protected void standaloneNotModal2081( )
      {
      }

      protected void standaloneModal2081( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtConexionesDatosId_Enabled = 0;
            AssignProp("", false, edtConexionesDatosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesDatosId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         }
         else
         {
            edtConexionesDatosId_Enabled = 1;
            AssignProp("", false, edtConexionesDatosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesDatosId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         }
      }

      protected void Load2081( )
      {
         /* Using cursor T002015 */
         pr_default.execute(13, new Object[] {n552ConexionesID, A552ConexionesID, A553ConexionesDatosId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound81 = 1;
            A566ConexionesDatosInt = T002015_A566ConexionesDatosInt[0];
            n566ConexionesDatosInt = T002015_n566ConexionesDatosInt[0];
            A567ConexionesDatosExt = T002015_A567ConexionesDatosExt[0];
            n567ConexionesDatosExt = T002015_n567ConexionesDatosExt[0];
            A568ConexionesDatosDetalle = T002015_A568ConexionesDatosDetalle[0];
            n568ConexionesDatosDetalle = T002015_n568ConexionesDatosDetalle[0];
            ZM2081( -7) ;
         }
         pr_default.close(13);
         OnLoadActions2081( ) ;
      }

      protected void OnLoadActions2081( )
      {
      }

      protected void CheckExtendedTable2081( )
      {
         nIsDirty_81 = 0;
         Gx_BScreen = 1;
         standaloneModal2081( ) ;
      }

      protected void CloseExtendedTableCursors2081( )
      {
      }

      protected void enableDisable2081( )
      {
      }

      protected void GetKey2081( )
      {
         /* Using cursor T002016 */
         pr_default.execute(14, new Object[] {n552ConexionesID, A552ConexionesID, A553ConexionesDatosId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound81 = 1;
         }
         else
         {
            RcdFound81 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey2081( )
      {
         /* Using cursor T00203 */
         pr_default.execute(1, new Object[] {n552ConexionesID, A552ConexionesID, A553ConexionesDatosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2081( 7) ;
            RcdFound81 = 1;
            InitializeNonKey2081( ) ;
            A553ConexionesDatosId = T00203_A553ConexionesDatosId[0];
            A566ConexionesDatosInt = T00203_A566ConexionesDatosInt[0];
            n566ConexionesDatosInt = T00203_n566ConexionesDatosInt[0];
            A567ConexionesDatosExt = T00203_A567ConexionesDatosExt[0];
            n567ConexionesDatosExt = T00203_n567ConexionesDatosExt[0];
            A568ConexionesDatosDetalle = T00203_A568ConexionesDatosDetalle[0];
            n568ConexionesDatosDetalle = T00203_n568ConexionesDatosDetalle[0];
            Z552ConexionesID = A552ConexionesID;
            Z553ConexionesDatosId = A553ConexionesDatosId;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2081( ) ;
            Gx_mode = sMode81;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound81 = 0;
            InitializeNonKey2081( ) ;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal2081( ) ;
            Gx_mode = sMode81;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2081( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency2081( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00202 */
            pr_default.execute(0, new Object[] {n552ConexionesID, A552ConexionesID, A553ConexionesDatosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConexionesDatos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z566ConexionesDatosInt, T00202_A566ConexionesDatosInt[0]) != 0 ) || ( StringUtil.StrCmp(Z567ConexionesDatosExt, T00202_A567ConexionesDatosExt[0]) != 0 ) || ( StringUtil.StrCmp(Z568ConexionesDatosDetalle, T00202_A568ConexionesDatosDetalle[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z566ConexionesDatosInt, T00202_A566ConexionesDatosInt[0]) != 0 )
               {
                  GXUtil.WriteLog("conexiones:[seudo value changed for attri]"+"ConexionesDatosInt");
                  GXUtil.WriteLogRaw("Old: ",Z566ConexionesDatosInt);
                  GXUtil.WriteLogRaw("Current: ",T00202_A566ConexionesDatosInt[0]);
               }
               if ( StringUtil.StrCmp(Z567ConexionesDatosExt, T00202_A567ConexionesDatosExt[0]) != 0 )
               {
                  GXUtil.WriteLog("conexiones:[seudo value changed for attri]"+"ConexionesDatosExt");
                  GXUtil.WriteLogRaw("Old: ",Z567ConexionesDatosExt);
                  GXUtil.WriteLogRaw("Current: ",T00202_A567ConexionesDatosExt[0]);
               }
               if ( StringUtil.StrCmp(Z568ConexionesDatosDetalle, T00202_A568ConexionesDatosDetalle[0]) != 0 )
               {
                  GXUtil.WriteLog("conexiones:[seudo value changed for attri]"+"ConexionesDatosDetalle");
                  GXUtil.WriteLogRaw("Old: ",Z568ConexionesDatosDetalle);
                  GXUtil.WriteLogRaw("Current: ",T00202_A568ConexionesDatosDetalle[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ConexionesDatos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2081( )
      {
         BeforeValidate2081( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2081( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2081( 0) ;
            CheckOptimisticConcurrency2081( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2081( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2081( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002017 */
                     pr_default.execute(15, new Object[] {n552ConexionesID, A552ConexionesID, A553ConexionesDatosId, n566ConexionesDatosInt, A566ConexionesDatosInt, n567ConexionesDatosExt, A567ConexionesDatosExt, n568ConexionesDatosDetalle, A568ConexionesDatosDetalle});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
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
               Load2081( ) ;
            }
            EndLevel2081( ) ;
         }
         CloseExtendedTableCursors2081( ) ;
      }

      protected void Update2081( )
      {
         BeforeValidate2081( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2081( ) ;
         }
         if ( ( nIsMod_81 != 0 ) || ( nIsDirty_81 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency2081( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm2081( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate2081( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T002018 */
                        pr_default.execute(16, new Object[] {n566ConexionesDatosInt, A566ConexionesDatosInt, n567ConexionesDatosExt, A567ConexionesDatosExt, n568ConexionesDatosDetalle, A568ConexionesDatosDetalle, n552ConexionesID, A552ConexionesID, A553ConexionesDatosId});
                        pr_default.close(16);
                        pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
                        if ( (pr_default.getStatus(16) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConexionesDatos"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate2081( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey2081( ) ;
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
               EndLevel2081( ) ;
            }
         }
         CloseExtendedTableCursors2081( ) ;
      }

      protected void DeferredUpdate2081( )
      {
      }

      protected void Delete2081( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2081( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2081( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2081( ) ;
            AfterConfirm2081( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2081( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002019 */
                  pr_default.execute(17, new Object[] {n552ConexionesID, A552ConexionesID, A553ConexionesDatosId});
                  pr_default.close(17);
                  pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
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
         sMode81 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2081( ) ;
         Gx_mode = sMode81;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2081( )
      {
         standaloneModal2081( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2081( )
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

      public void ScanStart2081( )
      {
         /* Scan By routine */
         /* Using cursor T002020 */
         pr_default.execute(18, new Object[] {n552ConexionesID, A552ConexionesID});
         RcdFound81 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound81 = 1;
            A553ConexionesDatosId = T002020_A553ConexionesDatosId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2081( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound81 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound81 = 1;
            A553ConexionesDatosId = T002020_A553ConexionesDatosId[0];
         }
      }

      protected void ScanEnd2081( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm2081( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2081( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2081( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2081( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2081( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2081( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2081( )
      {
         edtConexionesDatosId_Enabled = 0;
         AssignProp("", false, edtConexionesDatosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesDatosId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtConexionesDatosInt_Enabled = 0;
         AssignProp("", false, edtConexionesDatosInt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesDatosInt_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtConexionesDatosExt_Enabled = 0;
         AssignProp("", false, edtConexionesDatosExt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesDatosExt_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtConexionesDatosDetalle_Enabled = 0;
         AssignProp("", false, edtConexionesDatosDetalle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesDatosDetalle_Enabled), 5, 0), !bGXsfl_83_Refreshing);
      }

      protected void send_integrity_lvl_hashes2081( )
      {
      }

      protected void send_integrity_lvl_hashes2080( )
      {
      }

      protected void SubsflControlProps_8381( )
      {
         edtConexionesDatosId_Internalname = "CONEXIONESDATOSID_"+sGXsfl_83_idx;
         edtConexionesDatosInt_Internalname = "CONEXIONESDATOSINT_"+sGXsfl_83_idx;
         edtConexionesDatosExt_Internalname = "CONEXIONESDATOSEXT_"+sGXsfl_83_idx;
         edtConexionesDatosDetalle_Internalname = "CONEXIONESDATOSDETALLE_"+sGXsfl_83_idx;
      }

      protected void SubsflControlProps_fel_8381( )
      {
         edtConexionesDatosId_Internalname = "CONEXIONESDATOSID_"+sGXsfl_83_fel_idx;
         edtConexionesDatosInt_Internalname = "CONEXIONESDATOSINT_"+sGXsfl_83_fel_idx;
         edtConexionesDatosExt_Internalname = "CONEXIONESDATOSEXT_"+sGXsfl_83_fel_idx;
         edtConexionesDatosDetalle_Internalname = "CONEXIONESDATOSDETALLE_"+sGXsfl_83_fel_idx;
      }

      protected void AddRow2081( )
      {
         nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_8381( ) ;
         SendRow2081( ) ;
      }

      protected void SendRow2081( )
      {
         Gridlevel_datosRow = GXWebRow.GetNew(context);
         if ( subGridlevel_datos_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_datos_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_datos_Class, "") != 0 )
            {
               subGridlevel_datos_Linesclass = subGridlevel_datos_Class+"Odd";
            }
         }
         else if ( subGridlevel_datos_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_datos_Backstyle = 0;
            subGridlevel_datos_Backcolor = subGridlevel_datos_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_datos_Class, "") != 0 )
            {
               subGridlevel_datos_Linesclass = subGridlevel_datos_Class+"Uniform";
            }
         }
         else if ( subGridlevel_datos_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_datos_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_datos_Class, "") != 0 )
            {
               subGridlevel_datos_Linesclass = subGridlevel_datos_Class+"Odd";
            }
            subGridlevel_datos_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_datos_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_datos_Backstyle = 1;
            if ( ((int)((nGXsfl_83_idx) % (2))) == 0 )
            {
               subGridlevel_datos_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_datos_Class, "") != 0 )
               {
                  subGridlevel_datos_Linesclass = subGridlevel_datos_Class+"Even";
               }
            }
            else
            {
               subGridlevel_datos_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_datos_Class, "") != 0 )
               {
                  subGridlevel_datos_Linesclass = subGridlevel_datos_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_81_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridlevel_datosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConexionesDatosId_Internalname,StringUtil.RTrim( A553ConexionesDatosId),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConexionesDatosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtConexionesDatosId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)25,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_81_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridlevel_datosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConexionesDatosInt_Internalname,StringUtil.RTrim( A566ConexionesDatosInt),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConexionesDatosInt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtConexionesDatosInt_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)128,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_81_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridlevel_datosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConexionesDatosExt_Internalname,StringUtil.RTrim( A567ConexionesDatosExt),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConexionesDatosExt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtConexionesDatosExt_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)128,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_81_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridlevel_datosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConexionesDatosDetalle_Internalname,StringUtil.RTrim( A568ConexionesDatosDetalle),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConexionesDatosDetalle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtConexionesDatosDetalle_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)256,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_datosRow);
         send_integrity_lvl_hashes2081( ) ;
         GXCCtl = "Z553ConexionesDatosId_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z553ConexionesDatosId));
         GXCCtl = "Z566ConexionesDatosInt_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z566ConexionesDatosInt));
         GXCCtl = "Z567ConexionesDatosExt_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z567ConexionesDatosExt));
         GXCCtl = "Z568ConexionesDatosDetalle_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z568ConexionesDatosDetalle));
         GXCCtl = "nRcdDeleted_81_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_81), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_81_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_81), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_81_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_81), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_83_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vCONEXIONESID_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( AV7ConexionesID));
         GxWebStd.gx_hidden_field( context, "CONEXIONESDATOSID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CONEXIONESDATOSINT_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosInt_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CONEXIONESDATOSEXT_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosExt_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CONEXIONESDATOSDETALLE_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosDetalle_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_datosContainer.AddRow(Gridlevel_datosRow);
      }

      protected void ReadRow2081( )
      {
         nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_8381( ) ;
         edtConexionesDatosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONEXIONESDATOSID_"+sGXsfl_83_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtConexionesDatosInt_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONEXIONESDATOSINT_"+sGXsfl_83_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtConexionesDatosExt_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONEXIONESDATOSEXT_"+sGXsfl_83_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtConexionesDatosDetalle_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONEXIONESDATOSDETALLE_"+sGXsfl_83_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A553ConexionesDatosId = cgiGet( edtConexionesDatosId_Internalname);
         A566ConexionesDatosInt = cgiGet( edtConexionesDatosInt_Internalname);
         n566ConexionesDatosInt = false;
         n566ConexionesDatosInt = (String.IsNullOrEmpty(StringUtil.RTrim( A566ConexionesDatosInt)) ? true : false);
         A567ConexionesDatosExt = cgiGet( edtConexionesDatosExt_Internalname);
         n567ConexionesDatosExt = false;
         n567ConexionesDatosExt = (String.IsNullOrEmpty(StringUtil.RTrim( A567ConexionesDatosExt)) ? true : false);
         A568ConexionesDatosDetalle = cgiGet( edtConexionesDatosDetalle_Internalname);
         n568ConexionesDatosDetalle = false;
         n568ConexionesDatosDetalle = (String.IsNullOrEmpty(StringUtil.RTrim( A568ConexionesDatosDetalle)) ? true : false);
         GXCCtl = "Z553ConexionesDatosId_" + sGXsfl_83_idx;
         Z553ConexionesDatosId = cgiGet( GXCCtl);
         GXCCtl = "Z566ConexionesDatosInt_" + sGXsfl_83_idx;
         Z566ConexionesDatosInt = cgiGet( GXCCtl);
         n566ConexionesDatosInt = (String.IsNullOrEmpty(StringUtil.RTrim( A566ConexionesDatosInt)) ? true : false);
         GXCCtl = "Z567ConexionesDatosExt_" + sGXsfl_83_idx;
         Z567ConexionesDatosExt = cgiGet( GXCCtl);
         n567ConexionesDatosExt = (String.IsNullOrEmpty(StringUtil.RTrim( A567ConexionesDatosExt)) ? true : false);
         GXCCtl = "Z568ConexionesDatosDetalle_" + sGXsfl_83_idx;
         Z568ConexionesDatosDetalle = cgiGet( GXCCtl);
         n568ConexionesDatosDetalle = (String.IsNullOrEmpty(StringUtil.RTrim( A568ConexionesDatosDetalle)) ? true : false);
         GXCCtl = "nRcdDeleted_81_" + sGXsfl_83_idx;
         nRcdDeleted_81 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_81_" + sGXsfl_83_idx;
         nRcdExists_81 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_81_" + sGXsfl_83_idx;
         nIsMod_81 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtConexionesDatosId_Enabled = edtConexionesDatosId_Enabled;
      }

      protected void ConfirmValues200( )
      {
         nGXsfl_83_idx = 0;
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_8381( ) ;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
            SubsflControlProps_8381( ) ;
            ChangePostValue( "Z553ConexionesDatosId_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z553ConexionesDatosId_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z553ConexionesDatosId_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z566ConexionesDatosInt_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z566ConexionesDatosInt_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z566ConexionesDatosInt_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z567ConexionesDatosExt_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z567ConexionesDatosExt_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z567ConexionesDatosExt_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z568ConexionesDatosDetalle_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z568ConexionesDatosDetalle_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z568ConexionesDatosDetalle_"+sGXsfl_83_idx) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
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
         GXEncryptionTmp = "conexiones.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7ConexionesID));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("conexiones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Conexiones");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("conexiones:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z552ConexionesID", StringUtil.RTrim( Z552ConexionesID));
         GxWebStd.gx_hidden_field( context, "Z556ConexionesNombre", StringUtil.RTrim( Z556ConexionesNombre));
         GxWebStd.gx_hidden_field( context, "Z964ConexionesTipoIntegracion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z964ConexionesTipoIntegracion), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z557ConexionesHost", StringUtil.RTrim( Z557ConexionesHost));
         GxWebStd.gx_hidden_field( context, "Z558ConexionesBaseURL", StringUtil.RTrim( Z558ConexionesBaseURL));
         GxWebStd.gx_hidden_field( context, "Z559ConexionesPort", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z559ConexionesPort), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z560ConexionesApiKey", StringUtil.RTrim( Z560ConexionesApiKey));
         GxWebStd.gx_hidden_field( context, "Z561ConexionesUsr", StringUtil.RTrim( Z561ConexionesUsr));
         GxWebStd.gx_hidden_field( context, "Z563ConexionesAux1", StringUtil.RTrim( Z563ConexionesAux1));
         GxWebStd.gx_hidden_field( context, "Z564ConexionesAux2", StringUtil.RTrim( Z564ConexionesAux2));
         GxWebStd.gx_hidden_field( context, "Z565ConexionesAux3", StringUtil.RTrim( Z565ConexionesAux3));
         GxWebStd.gx_hidden_field( context, "Z562ConexionesEstado", StringUtil.RTrim( Z562ConexionesEstado));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_83", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_83_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vCONEXIONESID", StringUtil.RTrim( AV7ConexionesID));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONEXIONESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ConexionesID, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
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
         GXEncryptionTmp = "conexiones.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7ConexionesID));
         return formatLink("conexiones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Conexiones" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Conexiones", "") ;
      }

      protected void InitializeNonKey2080( )
      {
         A556ConexionesNombre = "";
         n556ConexionesNombre = false;
         AssignAttri("", false, "A556ConexionesNombre", A556ConexionesNombre);
         n556ConexionesNombre = (String.IsNullOrEmpty(StringUtil.RTrim( A556ConexionesNombre)) ? true : false);
         A964ConexionesTipoIntegracion = 0;
         n964ConexionesTipoIntegracion = false;
         AssignAttri("", false, "A964ConexionesTipoIntegracion", StringUtil.LTrimStr( (decimal)(A964ConexionesTipoIntegracion), 4, 0));
         n964ConexionesTipoIntegracion = ((0==A964ConexionesTipoIntegracion) ? true : false);
         A557ConexionesHost = "";
         n557ConexionesHost = false;
         AssignAttri("", false, "A557ConexionesHost", A557ConexionesHost);
         n557ConexionesHost = (String.IsNullOrEmpty(StringUtil.RTrim( A557ConexionesHost)) ? true : false);
         A558ConexionesBaseURL = "";
         n558ConexionesBaseURL = false;
         AssignAttri("", false, "A558ConexionesBaseURL", A558ConexionesBaseURL);
         n558ConexionesBaseURL = (String.IsNullOrEmpty(StringUtil.RTrim( A558ConexionesBaseURL)) ? true : false);
         A559ConexionesPort = 0;
         n559ConexionesPort = false;
         AssignAttri("", false, "A559ConexionesPort", StringUtil.LTrimStr( (decimal)(A559ConexionesPort), 9, 0));
         n559ConexionesPort = ((0==A559ConexionesPort) ? true : false);
         A560ConexionesApiKey = "";
         n560ConexionesApiKey = false;
         AssignAttri("", false, "A560ConexionesApiKey", A560ConexionesApiKey);
         n560ConexionesApiKey = (String.IsNullOrEmpty(StringUtil.RTrim( A560ConexionesApiKey)) ? true : false);
         A561ConexionesUsr = "";
         n561ConexionesUsr = false;
         AssignAttri("", false, "A561ConexionesUsr", A561ConexionesUsr);
         n561ConexionesUsr = (String.IsNullOrEmpty(StringUtil.RTrim( A561ConexionesUsr)) ? true : false);
         A563ConexionesAux1 = "";
         n563ConexionesAux1 = false;
         AssignAttri("", false, "A563ConexionesAux1", A563ConexionesAux1);
         n563ConexionesAux1 = (String.IsNullOrEmpty(StringUtil.RTrim( A563ConexionesAux1)) ? true : false);
         A564ConexionesAux2 = "";
         n564ConexionesAux2 = false;
         AssignAttri("", false, "A564ConexionesAux2", A564ConexionesAux2);
         n564ConexionesAux2 = (String.IsNullOrEmpty(StringUtil.RTrim( A564ConexionesAux2)) ? true : false);
         A565ConexionesAux3 = "";
         n565ConexionesAux3 = false;
         AssignAttri("", false, "A565ConexionesAux3", A565ConexionesAux3);
         n565ConexionesAux3 = (String.IsNullOrEmpty(StringUtil.RTrim( A565ConexionesAux3)) ? true : false);
         A562ConexionesEstado = "";
         n562ConexionesEstado = false;
         AssignAttri("", false, "A562ConexionesEstado", A562ConexionesEstado);
         n562ConexionesEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A562ConexionesEstado)) ? true : false);
         Z556ConexionesNombre = "";
         Z964ConexionesTipoIntegracion = 0;
         Z557ConexionesHost = "";
         Z558ConexionesBaseURL = "";
         Z559ConexionesPort = 0;
         Z560ConexionesApiKey = "";
         Z561ConexionesUsr = "";
         Z563ConexionesAux1 = "";
         Z564ConexionesAux2 = "";
         Z565ConexionesAux3 = "";
         Z562ConexionesEstado = "";
      }

      protected void InitAll2080( )
      {
         A552ConexionesID = "";
         n552ConexionesID = false;
         AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
         InitializeNonKey2080( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey2081( )
      {
         A566ConexionesDatosInt = "";
         n566ConexionesDatosInt = false;
         A567ConexionesDatosExt = "";
         n567ConexionesDatosExt = false;
         A568ConexionesDatosDetalle = "";
         n568ConexionesDatosDetalle = false;
         Z566ConexionesDatosInt = "";
         Z567ConexionesDatosExt = "";
         Z568ConexionesDatosDetalle = "";
      }

      protected void InitAll2081( )
      {
         A553ConexionesDatosId = "";
         InitializeNonKey2081( ) ;
      }

      protected void StandaloneModalInsert2081( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932075719", true, true, false);
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
         context.AddJavascriptSource("conexiones.js", "?2026932075719", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties81( )
      {
         edtConexionesDatosId_Enabled = defedtConexionesDatosId_Enabled;
         AssignProp("", false, edtConexionesDatosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesDatosId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
      }

      protected void StartGridControl83( )
      {
         Gridlevel_datosContainer.AddObjectProperty("GridName", "Gridlevel_datos");
         Gridlevel_datosContainer.AddObjectProperty("Header", subGridlevel_datos_Header);
         Gridlevel_datosContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_datosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_datosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_datosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_datos_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_datosContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_datosContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_datosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_datosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A553ConexionesDatosId)));
         Gridlevel_datosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosId_Enabled), 5, 0, ".", "")));
         Gridlevel_datosContainer.AddColumnProperties(Gridlevel_datosColumn);
         Gridlevel_datosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_datosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A566ConexionesDatosInt)));
         Gridlevel_datosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosInt_Enabled), 5, 0, ".", "")));
         Gridlevel_datosContainer.AddColumnProperties(Gridlevel_datosColumn);
         Gridlevel_datosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_datosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A567ConexionesDatosExt)));
         Gridlevel_datosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosExt_Enabled), 5, 0, ".", "")));
         Gridlevel_datosContainer.AddColumnProperties(Gridlevel_datosColumn);
         Gridlevel_datosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_datosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A568ConexionesDatosDetalle)));
         Gridlevel_datosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesDatosDetalle_Enabled), 5, 0, ".", "")));
         Gridlevel_datosContainer.AddColumnProperties(Gridlevel_datosColumn);
         Gridlevel_datosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_datos_Selectedindex), 4, 0, ".", "")));
         Gridlevel_datosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_datos_Allowselection), 1, 0, ".", "")));
         Gridlevel_datosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_datos_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_datosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_datos_Allowhovering), 1, 0, ".", "")));
         Gridlevel_datosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_datos_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_datosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_datos_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_datosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_datos_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtConexionesID_Internalname = "CONEXIONESID";
         edtConexionesNombre_Internalname = "CONEXIONESNOMBRE";
         cmbConexionesTipoIntegracion_Internalname = "CONEXIONESTIPOINTEGRACION";
         edtConexionesHost_Internalname = "CONEXIONESHOST";
         edtConexionesBaseURL_Internalname = "CONEXIONESBASEURL";
         edtConexionesPort_Internalname = "CONEXIONESPORT";
         edtConexionesApiKey_Internalname = "CONEXIONESAPIKEY";
         edtConexionesUsr_Internalname = "CONEXIONESUSR";
         edtConexionesAux1_Internalname = "CONEXIONESAUX1";
         edtConexionesAux2_Internalname = "CONEXIONESAUX2";
         edtConexionesAux3_Internalname = "CONEXIONESAUX3";
         cmbConexionesEstado_Internalname = "CONEXIONESESTADO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtConexionesDatosId_Internalname = "CONEXIONESDATOSID";
         edtConexionesDatosInt_Internalname = "CONEXIONESDATOSINT";
         edtConexionesDatosExt_Internalname = "CONEXIONESDATOSEXT";
         edtConexionesDatosDetalle_Internalname = "CONEXIONESDATOSDETALLE";
         divTableleaflevel_datos_Internalname = "TABLELEAFLEVEL_DATOS";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_datos_Internalname = "GRIDLEVEL_DATOS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_datos_Allowcollapsing = 0;
         subGridlevel_datos_Allowselection = 0;
         subGridlevel_datos_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Conexiones", "");
         edtConexionesDatosDetalle_Jsonclick = "";
         edtConexionesDatosExt_Jsonclick = "";
         edtConexionesDatosInt_Jsonclick = "";
         edtConexionesDatosId_Jsonclick = "";
         subGridlevel_datos_Class = "WorkWith";
         subGridlevel_datos_Backcolorstyle = 0;
         edtConexionesDatosDetalle_Enabled = 1;
         edtConexionesDatosExt_Enabled = 1;
         edtConexionesDatosInt_Enabled = 1;
         edtConexionesDatosId_Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbConexionesEstado_Jsonclick = "";
         cmbConexionesEstado.Enabled = 1;
         edtConexionesAux3_Jsonclick = "";
         edtConexionesAux3_Enabled = 1;
         edtConexionesAux2_Jsonclick = "";
         edtConexionesAux2_Enabled = 1;
         edtConexionesAux1_Jsonclick = "";
         edtConexionesAux1_Enabled = 1;
         edtConexionesUsr_Jsonclick = "";
         edtConexionesUsr_Enabled = 1;
         edtConexionesApiKey_Jsonclick = "";
         edtConexionesApiKey_Enabled = 1;
         edtConexionesPort_Jsonclick = "";
         edtConexionesPort_Enabled = 1;
         edtConexionesBaseURL_Jsonclick = "";
         edtConexionesBaseURL_Enabled = 1;
         edtConexionesHost_Jsonclick = "";
         edtConexionesHost_Enabled = 1;
         cmbConexionesTipoIntegracion_Jsonclick = "";
         cmbConexionesTipoIntegracion.Enabled = 1;
         edtConexionesNombre_Jsonclick = "";
         edtConexionesNombre_Enabled = 1;
         edtConexionesID_Jsonclick = "";
         edtConexionesID_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = context.GetMessage( "WWP_TemplateDataPanelTitle", "");
         Dvpanel_tableattributes_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
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

      protected void gxnrGridlevel_datos_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_8381( ) ;
         while ( nGXsfl_83_idx <= nRC_GXsfl_83 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal2081( ) ;
            standaloneModal2081( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow2081( ) ;
            nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
            SubsflControlProps_8381( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_datosContainer)) ;
         /* End function gxnrGridlevel_datos_newrow */
      }

      protected void init_web_controls( )
      {
         cmbConexionesTipoIntegracion.Name = "CONEXIONESTIPOINTEGRACION";
         cmbConexionesTipoIntegracion.WebTags = "";
         cmbConexionesTipoIntegracion.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 4, 0)), context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbConexionesTipoIntegracion.addItem("1", context.GetMessage( "FENICIO", ""), 0);
         cmbConexionesTipoIntegracion.addItem("2", context.GetMessage( "KREIVA", ""), 0);
         if ( cmbConexionesTipoIntegracion.ItemCount > 0 )
         {
            A964ConexionesTipoIntegracion = (short)(Math.Round(NumberUtil.Val( cmbConexionesTipoIntegracion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A964ConexionesTipoIntegracion), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n964ConexionesTipoIntegracion = false;
            AssignAttri("", false, "A964ConexionesTipoIntegracion", StringUtil.LTrimStr( (decimal)(A964ConexionesTipoIntegracion), 4, 0));
         }
         cmbConexionesEstado.Name = "CONEXIONESESTADO";
         cmbConexionesEstado.WebTags = "";
         cmbConexionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbConexionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbConexionesEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbConexionesEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbConexionesEstado.ItemCount > 0 )
         {
            A562ConexionesEstado = cmbConexionesEstado.getValidValue(A562ConexionesEstado);
            n562ConexionesEstado = false;
            AssignAttri("", false, "A562ConexionesEstado", A562ConexionesEstado);
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7ConexionesID',fld:'vCONEXIONESID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ConexionesID',fld:'vCONEXIONESID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12202',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("'ALTA AUTOMATICA'","{handler:'E13202',iparms:[]");
         setEventMetadata("'ALTA AUTOMATICA'",",oparms:[]}");
         setEventMetadata("VALID_CONEXIONESID","{handler:'Valid_Conexionesid',iparms:[]");
         setEventMetadata("VALID_CONEXIONESID",",oparms:[]}");
         setEventMetadata("VALID_CONEXIONESTIPOINTEGRACION","{handler:'Valid_Conexionestipointegracion',iparms:[]");
         setEventMetadata("VALID_CONEXIONESTIPOINTEGRACION",",oparms:[]}");
         setEventMetadata("VALID_CONEXIONESESTADO","{handler:'Valid_Conexionesestado',iparms:[]");
         setEventMetadata("VALID_CONEXIONESESTADO",",oparms:[]}");
         setEventMetadata("VALID_CONEXIONESDATOSID","{handler:'Valid_Conexionesdatosid',iparms:[]");
         setEventMetadata("VALID_CONEXIONESDATOSID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Conexionesdatosdetalle',iparms:[]");
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
         wcpOAV7ConexionesID = "";
         Z552ConexionesID = "";
         Z556ConexionesNombre = "";
         Z557ConexionesHost = "";
         Z558ConexionesBaseURL = "";
         Z560ConexionesApiKey = "";
         Z561ConexionesUsr = "";
         Z563ConexionesAux1 = "";
         Z564ConexionesAux2 = "";
         Z565ConexionesAux3 = "";
         Z562ConexionesEstado = "";
         Z553ConexionesDatosId = "";
         Z566ConexionesDatosInt = "";
         Z567ConexionesDatosExt = "";
         Z568ConexionesDatosDetalle = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A562ConexionesEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A552ConexionesID = "";
         A556ConexionesNombre = "";
         A557ConexionesHost = "";
         A558ConexionesBaseURL = "";
         A560ConexionesApiKey = "";
         A561ConexionesUsr = "";
         A563ConexionesAux1 = "";
         A564ConexionesAux2 = "";
         A565ConexionesAux3 = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_datosContainer = new GXWebGrid( context);
         sMode81 = "";
         sStyleString = "";
         AV15Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode80 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A553ConexionesDatosId = "";
         A566ConexionesDatosInt = "";
         A567ConexionesDatosExt = "";
         A568ConexionesDatosDetalle = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T00206_A552ConexionesID = new string[] {""} ;
         T00206_n552ConexionesID = new bool[] {false} ;
         T00206_A556ConexionesNombre = new string[] {""} ;
         T00206_n556ConexionesNombre = new bool[] {false} ;
         T00206_A964ConexionesTipoIntegracion = new short[1] ;
         T00206_n964ConexionesTipoIntegracion = new bool[] {false} ;
         T00206_A557ConexionesHost = new string[] {""} ;
         T00206_n557ConexionesHost = new bool[] {false} ;
         T00206_A558ConexionesBaseURL = new string[] {""} ;
         T00206_n558ConexionesBaseURL = new bool[] {false} ;
         T00206_A559ConexionesPort = new int[1] ;
         T00206_n559ConexionesPort = new bool[] {false} ;
         T00206_A560ConexionesApiKey = new string[] {""} ;
         T00206_n560ConexionesApiKey = new bool[] {false} ;
         T00206_A561ConexionesUsr = new string[] {""} ;
         T00206_n561ConexionesUsr = new bool[] {false} ;
         T00206_A563ConexionesAux1 = new string[] {""} ;
         T00206_n563ConexionesAux1 = new bool[] {false} ;
         T00206_A564ConexionesAux2 = new string[] {""} ;
         T00206_n564ConexionesAux2 = new bool[] {false} ;
         T00206_A565ConexionesAux3 = new string[] {""} ;
         T00206_n565ConexionesAux3 = new bool[] {false} ;
         T00206_A562ConexionesEstado = new string[] {""} ;
         T00206_n562ConexionesEstado = new bool[] {false} ;
         T00207_A552ConexionesID = new string[] {""} ;
         T00207_n552ConexionesID = new bool[] {false} ;
         T00205_A552ConexionesID = new string[] {""} ;
         T00205_n552ConexionesID = new bool[] {false} ;
         T00205_A556ConexionesNombre = new string[] {""} ;
         T00205_n556ConexionesNombre = new bool[] {false} ;
         T00205_A964ConexionesTipoIntegracion = new short[1] ;
         T00205_n964ConexionesTipoIntegracion = new bool[] {false} ;
         T00205_A557ConexionesHost = new string[] {""} ;
         T00205_n557ConexionesHost = new bool[] {false} ;
         T00205_A558ConexionesBaseURL = new string[] {""} ;
         T00205_n558ConexionesBaseURL = new bool[] {false} ;
         T00205_A559ConexionesPort = new int[1] ;
         T00205_n559ConexionesPort = new bool[] {false} ;
         T00205_A560ConexionesApiKey = new string[] {""} ;
         T00205_n560ConexionesApiKey = new bool[] {false} ;
         T00205_A561ConexionesUsr = new string[] {""} ;
         T00205_n561ConexionesUsr = new bool[] {false} ;
         T00205_A563ConexionesAux1 = new string[] {""} ;
         T00205_n563ConexionesAux1 = new bool[] {false} ;
         T00205_A564ConexionesAux2 = new string[] {""} ;
         T00205_n564ConexionesAux2 = new bool[] {false} ;
         T00205_A565ConexionesAux3 = new string[] {""} ;
         T00205_n565ConexionesAux3 = new bool[] {false} ;
         T00205_A562ConexionesEstado = new string[] {""} ;
         T00205_n562ConexionesEstado = new bool[] {false} ;
         T00208_A552ConexionesID = new string[] {""} ;
         T00208_n552ConexionesID = new bool[] {false} ;
         T00209_A552ConexionesID = new string[] {""} ;
         T00209_n552ConexionesID = new bool[] {false} ;
         T00204_A552ConexionesID = new string[] {""} ;
         T00204_n552ConexionesID = new bool[] {false} ;
         T00204_A556ConexionesNombre = new string[] {""} ;
         T00204_n556ConexionesNombre = new bool[] {false} ;
         T00204_A964ConexionesTipoIntegracion = new short[1] ;
         T00204_n964ConexionesTipoIntegracion = new bool[] {false} ;
         T00204_A557ConexionesHost = new string[] {""} ;
         T00204_n557ConexionesHost = new bool[] {false} ;
         T00204_A558ConexionesBaseURL = new string[] {""} ;
         T00204_n558ConexionesBaseURL = new bool[] {false} ;
         T00204_A559ConexionesPort = new int[1] ;
         T00204_n559ConexionesPort = new bool[] {false} ;
         T00204_A560ConexionesApiKey = new string[] {""} ;
         T00204_n560ConexionesApiKey = new bool[] {false} ;
         T00204_A561ConexionesUsr = new string[] {""} ;
         T00204_n561ConexionesUsr = new bool[] {false} ;
         T00204_A563ConexionesAux1 = new string[] {""} ;
         T00204_n563ConexionesAux1 = new bool[] {false} ;
         T00204_A564ConexionesAux2 = new string[] {""} ;
         T00204_n564ConexionesAux2 = new bool[] {false} ;
         T00204_A565ConexionesAux3 = new string[] {""} ;
         T00204_n565ConexionesAux3 = new bool[] {false} ;
         T00204_A562ConexionesEstado = new string[] {""} ;
         T00204_n562ConexionesEstado = new bool[] {false} ;
         T002013_A918MapeoID = new long[1] ;
         T002014_A552ConexionesID = new string[] {""} ;
         T002014_n552ConexionesID = new bool[] {false} ;
         T002015_A552ConexionesID = new string[] {""} ;
         T002015_n552ConexionesID = new bool[] {false} ;
         T002015_A553ConexionesDatosId = new string[] {""} ;
         T002015_A566ConexionesDatosInt = new string[] {""} ;
         T002015_n566ConexionesDatosInt = new bool[] {false} ;
         T002015_A567ConexionesDatosExt = new string[] {""} ;
         T002015_n567ConexionesDatosExt = new bool[] {false} ;
         T002015_A568ConexionesDatosDetalle = new string[] {""} ;
         T002015_n568ConexionesDatosDetalle = new bool[] {false} ;
         T002016_A552ConexionesID = new string[] {""} ;
         T002016_n552ConexionesID = new bool[] {false} ;
         T002016_A553ConexionesDatosId = new string[] {""} ;
         T00203_A552ConexionesID = new string[] {""} ;
         T00203_n552ConexionesID = new bool[] {false} ;
         T00203_A553ConexionesDatosId = new string[] {""} ;
         T00203_A566ConexionesDatosInt = new string[] {""} ;
         T00203_n566ConexionesDatosInt = new bool[] {false} ;
         T00203_A567ConexionesDatosExt = new string[] {""} ;
         T00203_n567ConexionesDatosExt = new bool[] {false} ;
         T00203_A568ConexionesDatosDetalle = new string[] {""} ;
         T00203_n568ConexionesDatosDetalle = new bool[] {false} ;
         T00202_A552ConexionesID = new string[] {""} ;
         T00202_n552ConexionesID = new bool[] {false} ;
         T00202_A553ConexionesDatosId = new string[] {""} ;
         T00202_A566ConexionesDatosInt = new string[] {""} ;
         T00202_n566ConexionesDatosInt = new bool[] {false} ;
         T00202_A567ConexionesDatosExt = new string[] {""} ;
         T00202_n567ConexionesDatosExt = new bool[] {false} ;
         T00202_A568ConexionesDatosDetalle = new string[] {""} ;
         T00202_n568ConexionesDatosDetalle = new bool[] {false} ;
         T002020_A552ConexionesID = new string[] {""} ;
         T002020_n552ConexionesID = new bool[] {false} ;
         T002020_A553ConexionesDatosId = new string[] {""} ;
         Gridlevel_datosRow = new GXWebRow();
         subGridlevel_datos_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_datosColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.conexiones__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.conexiones__default(),
            new Object[][] {
                new Object[] {
               T00202_A552ConexionesID, T00202_A553ConexionesDatosId, T00202_A566ConexionesDatosInt, T00202_n566ConexionesDatosInt, T00202_A567ConexionesDatosExt, T00202_n567ConexionesDatosExt, T00202_A568ConexionesDatosDetalle, T00202_n568ConexionesDatosDetalle
               }
               , new Object[] {
               T00203_A552ConexionesID, T00203_A553ConexionesDatosId, T00203_A566ConexionesDatosInt, T00203_n566ConexionesDatosInt, T00203_A567ConexionesDatosExt, T00203_n567ConexionesDatosExt, T00203_A568ConexionesDatosDetalle, T00203_n568ConexionesDatosDetalle
               }
               , new Object[] {
               T00204_A552ConexionesID, T00204_A556ConexionesNombre, T00204_n556ConexionesNombre, T00204_A964ConexionesTipoIntegracion, T00204_n964ConexionesTipoIntegracion, T00204_A557ConexionesHost, T00204_n557ConexionesHost, T00204_A558ConexionesBaseURL, T00204_n558ConexionesBaseURL, T00204_A559ConexionesPort,
               T00204_n559ConexionesPort, T00204_A560ConexionesApiKey, T00204_n560ConexionesApiKey, T00204_A561ConexionesUsr, T00204_n561ConexionesUsr, T00204_A563ConexionesAux1, T00204_n563ConexionesAux1, T00204_A564ConexionesAux2, T00204_n564ConexionesAux2, T00204_A565ConexionesAux3,
               T00204_n565ConexionesAux3, T00204_A562ConexionesEstado, T00204_n562ConexionesEstado
               }
               , new Object[] {
               T00205_A552ConexionesID, T00205_A556ConexionesNombre, T00205_n556ConexionesNombre, T00205_A964ConexionesTipoIntegracion, T00205_n964ConexionesTipoIntegracion, T00205_A557ConexionesHost, T00205_n557ConexionesHost, T00205_A558ConexionesBaseURL, T00205_n558ConexionesBaseURL, T00205_A559ConexionesPort,
               T00205_n559ConexionesPort, T00205_A560ConexionesApiKey, T00205_n560ConexionesApiKey, T00205_A561ConexionesUsr, T00205_n561ConexionesUsr, T00205_A563ConexionesAux1, T00205_n563ConexionesAux1, T00205_A564ConexionesAux2, T00205_n564ConexionesAux2, T00205_A565ConexionesAux3,
               T00205_n565ConexionesAux3, T00205_A562ConexionesEstado, T00205_n562ConexionesEstado
               }
               , new Object[] {
               T00206_A552ConexionesID, T00206_A556ConexionesNombre, T00206_n556ConexionesNombre, T00206_A964ConexionesTipoIntegracion, T00206_n964ConexionesTipoIntegracion, T00206_A557ConexionesHost, T00206_n557ConexionesHost, T00206_A558ConexionesBaseURL, T00206_n558ConexionesBaseURL, T00206_A559ConexionesPort,
               T00206_n559ConexionesPort, T00206_A560ConexionesApiKey, T00206_n560ConexionesApiKey, T00206_A561ConexionesUsr, T00206_n561ConexionesUsr, T00206_A563ConexionesAux1, T00206_n563ConexionesAux1, T00206_A564ConexionesAux2, T00206_n564ConexionesAux2, T00206_A565ConexionesAux3,
               T00206_n565ConexionesAux3, T00206_A562ConexionesEstado, T00206_n562ConexionesEstado
               }
               , new Object[] {
               T00207_A552ConexionesID
               }
               , new Object[] {
               T00208_A552ConexionesID
               }
               , new Object[] {
               T00209_A552ConexionesID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002013_A918MapeoID
               }
               , new Object[] {
               T002014_A552ConexionesID
               }
               , new Object[] {
               T002015_A552ConexionesID, T002015_A553ConexionesDatosId, T002015_A566ConexionesDatosInt, T002015_n566ConexionesDatosInt, T002015_A567ConexionesDatosExt, T002015_n567ConexionesDatosExt, T002015_A568ConexionesDatosDetalle, T002015_n568ConexionesDatosDetalle
               }
               , new Object[] {
               T002016_A552ConexionesID, T002016_A553ConexionesDatosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002020_A552ConexionesID, T002020_A553ConexionesDatosId
               }
            }
         );
         AV15Pgmname = "Conexiones";
      }

      private short Z964ConexionesTipoIntegracion ;
      private short nRcdDeleted_81 ;
      private short nRcdExists_81 ;
      private short nIsMod_81 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A964ConexionesTipoIntegracion ;
      private short nBlankRcdCount81 ;
      private short RcdFound81 ;
      private short nBlankRcdUsr81 ;
      private short RcdFound80 ;
      private short Gx_BScreen ;
      private short nIsDirty_81 ;
      private short subGridlevel_datos_Backcolorstyle ;
      private short subGridlevel_datos_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_datos_Allowselection ;
      private short subGridlevel_datos_Allowhovering ;
      private short subGridlevel_datos_Allowcollapsing ;
      private short subGridlevel_datos_Collapsed ;
      private int Z559ConexionesPort ;
      private int nRC_GXsfl_83 ;
      private int nGXsfl_83_idx=1 ;
      private int trnEnded ;
      private int edtConexionesID_Enabled ;
      private int edtConexionesNombre_Enabled ;
      private int edtConexionesHost_Enabled ;
      private int edtConexionesBaseURL_Enabled ;
      private int A559ConexionesPort ;
      private int edtConexionesPort_Enabled ;
      private int edtConexionesApiKey_Enabled ;
      private int edtConexionesUsr_Enabled ;
      private int edtConexionesAux1_Enabled ;
      private int edtConexionesAux2_Enabled ;
      private int edtConexionesAux3_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtConexionesDatosId_Enabled ;
      private int edtConexionesDatosInt_Enabled ;
      private int edtConexionesDatosExt_Enabled ;
      private int edtConexionesDatosDetalle_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int subGridlevel_datos_Backcolor ;
      private int subGridlevel_datos_Allbackcolor ;
      private int defedtConexionesDatosId_Enabled ;
      private int idxLst ;
      private int subGridlevel_datos_Selectedindex ;
      private int subGridlevel_datos_Selectioncolor ;
      private int subGridlevel_datos_Hoveringcolor ;
      private long GRIDLEVEL_DATOS_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV7ConexionesID ;
      private string Z552ConexionesID ;
      private string Z556ConexionesNombre ;
      private string Z557ConexionesHost ;
      private string Z558ConexionesBaseURL ;
      private string Z560ConexionesApiKey ;
      private string Z561ConexionesUsr ;
      private string Z563ConexionesAux1 ;
      private string Z564ConexionesAux2 ;
      private string Z565ConexionesAux3 ;
      private string Z562ConexionesEstado ;
      private string Z553ConexionesDatosId ;
      private string Z566ConexionesDatosInt ;
      private string Z567ConexionesDatosExt ;
      private string Z568ConexionesDatosDetalle ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV7ConexionesID ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtConexionesID_Internalname ;
      private string sGXsfl_83_idx="0001" ;
      private string cmbConexionesTipoIntegracion_Internalname ;
      private string A562ConexionesEstado ;
      private string cmbConexionesEstado_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string A552ConexionesID ;
      private string edtConexionesID_Jsonclick ;
      private string edtConexionesNombre_Internalname ;
      private string A556ConexionesNombre ;
      private string edtConexionesNombre_Jsonclick ;
      private string cmbConexionesTipoIntegracion_Jsonclick ;
      private string edtConexionesHost_Internalname ;
      private string A557ConexionesHost ;
      private string edtConexionesHost_Jsonclick ;
      private string edtConexionesBaseURL_Internalname ;
      private string A558ConexionesBaseURL ;
      private string edtConexionesBaseURL_Jsonclick ;
      private string edtConexionesPort_Internalname ;
      private string edtConexionesPort_Jsonclick ;
      private string edtConexionesApiKey_Internalname ;
      private string A560ConexionesApiKey ;
      private string edtConexionesApiKey_Jsonclick ;
      private string edtConexionesUsr_Internalname ;
      private string A561ConexionesUsr ;
      private string edtConexionesUsr_Jsonclick ;
      private string edtConexionesAux1_Internalname ;
      private string A563ConexionesAux1 ;
      private string edtConexionesAux1_Jsonclick ;
      private string edtConexionesAux2_Internalname ;
      private string A564ConexionesAux2 ;
      private string edtConexionesAux2_Jsonclick ;
      private string edtConexionesAux3_Internalname ;
      private string A565ConexionesAux3 ;
      private string edtConexionesAux3_Jsonclick ;
      private string cmbConexionesEstado_Jsonclick ;
      private string divTableleaflevel_datos_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode81 ;
      private string edtConexionesDatosId_Internalname ;
      private string edtConexionesDatosInt_Internalname ;
      private string edtConexionesDatosExt_Internalname ;
      private string edtConexionesDatosDetalle_Internalname ;
      private string sStyleString ;
      private string subGridlevel_datos_Internalname ;
      private string AV15Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode80 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A553ConexionesDatosId ;
      private string A566ConexionesDatosInt ;
      private string A567ConexionesDatosExt ;
      private string A568ConexionesDatosDetalle ;
      private string GXEncryptionTmp ;
      private string sGXsfl_83_fel_idx="0001" ;
      private string subGridlevel_datos_Class ;
      private string subGridlevel_datos_Linesclass ;
      private string ROClassString ;
      private string edtConexionesDatosId_Jsonclick ;
      private string edtConexionesDatosInt_Jsonclick ;
      private string edtConexionesDatosExt_Jsonclick ;
      private string edtConexionesDatosDetalle_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_datos_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n964ConexionesTipoIntegracion ;
      private bool n562ConexionesEstado ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool bGXsfl_83_Refreshing=false ;
      private bool n556ConexionesNombre ;
      private bool n557ConexionesHost ;
      private bool n558ConexionesBaseURL ;
      private bool n559ConexionesPort ;
      private bool n560ConexionesApiKey ;
      private bool n561ConexionesUsr ;
      private bool n563ConexionesAux1 ;
      private bool n564ConexionesAux2 ;
      private bool n565ConexionesAux3 ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n552ConexionesID ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private bool n566ConexionesDatosInt ;
      private bool n567ConexionesDatosExt ;
      private bool n568ConexionesDatosDetalle ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_datosContainer ;
      private GXWebRow Gridlevel_datosRow ;
      private GXWebColumn Gridlevel_datosColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbConexionesTipoIntegracion ;
      private GXCombobox cmbConexionesEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private string[] T00206_A552ConexionesID ;
      private bool[] T00206_n552ConexionesID ;
      private string[] T00206_A556ConexionesNombre ;
      private bool[] T00206_n556ConexionesNombre ;
      private short[] T00206_A964ConexionesTipoIntegracion ;
      private bool[] T00206_n964ConexionesTipoIntegracion ;
      private string[] T00206_A557ConexionesHost ;
      private bool[] T00206_n557ConexionesHost ;
      private string[] T00206_A558ConexionesBaseURL ;
      private bool[] T00206_n558ConexionesBaseURL ;
      private int[] T00206_A559ConexionesPort ;
      private bool[] T00206_n559ConexionesPort ;
      private string[] T00206_A560ConexionesApiKey ;
      private bool[] T00206_n560ConexionesApiKey ;
      private string[] T00206_A561ConexionesUsr ;
      private bool[] T00206_n561ConexionesUsr ;
      private string[] T00206_A563ConexionesAux1 ;
      private bool[] T00206_n563ConexionesAux1 ;
      private string[] T00206_A564ConexionesAux2 ;
      private bool[] T00206_n564ConexionesAux2 ;
      private string[] T00206_A565ConexionesAux3 ;
      private bool[] T00206_n565ConexionesAux3 ;
      private string[] T00206_A562ConexionesEstado ;
      private bool[] T00206_n562ConexionesEstado ;
      private string[] T00207_A552ConexionesID ;
      private bool[] T00207_n552ConexionesID ;
      private string[] T00205_A552ConexionesID ;
      private bool[] T00205_n552ConexionesID ;
      private string[] T00205_A556ConexionesNombre ;
      private bool[] T00205_n556ConexionesNombre ;
      private short[] T00205_A964ConexionesTipoIntegracion ;
      private bool[] T00205_n964ConexionesTipoIntegracion ;
      private string[] T00205_A557ConexionesHost ;
      private bool[] T00205_n557ConexionesHost ;
      private string[] T00205_A558ConexionesBaseURL ;
      private bool[] T00205_n558ConexionesBaseURL ;
      private int[] T00205_A559ConexionesPort ;
      private bool[] T00205_n559ConexionesPort ;
      private string[] T00205_A560ConexionesApiKey ;
      private bool[] T00205_n560ConexionesApiKey ;
      private string[] T00205_A561ConexionesUsr ;
      private bool[] T00205_n561ConexionesUsr ;
      private string[] T00205_A563ConexionesAux1 ;
      private bool[] T00205_n563ConexionesAux1 ;
      private string[] T00205_A564ConexionesAux2 ;
      private bool[] T00205_n564ConexionesAux2 ;
      private string[] T00205_A565ConexionesAux3 ;
      private bool[] T00205_n565ConexionesAux3 ;
      private string[] T00205_A562ConexionesEstado ;
      private bool[] T00205_n562ConexionesEstado ;
      private string[] T00208_A552ConexionesID ;
      private bool[] T00208_n552ConexionesID ;
      private string[] T00209_A552ConexionesID ;
      private bool[] T00209_n552ConexionesID ;
      private string[] T00204_A552ConexionesID ;
      private bool[] T00204_n552ConexionesID ;
      private string[] T00204_A556ConexionesNombre ;
      private bool[] T00204_n556ConexionesNombre ;
      private short[] T00204_A964ConexionesTipoIntegracion ;
      private bool[] T00204_n964ConexionesTipoIntegracion ;
      private string[] T00204_A557ConexionesHost ;
      private bool[] T00204_n557ConexionesHost ;
      private string[] T00204_A558ConexionesBaseURL ;
      private bool[] T00204_n558ConexionesBaseURL ;
      private int[] T00204_A559ConexionesPort ;
      private bool[] T00204_n559ConexionesPort ;
      private string[] T00204_A560ConexionesApiKey ;
      private bool[] T00204_n560ConexionesApiKey ;
      private string[] T00204_A561ConexionesUsr ;
      private bool[] T00204_n561ConexionesUsr ;
      private string[] T00204_A563ConexionesAux1 ;
      private bool[] T00204_n563ConexionesAux1 ;
      private string[] T00204_A564ConexionesAux2 ;
      private bool[] T00204_n564ConexionesAux2 ;
      private string[] T00204_A565ConexionesAux3 ;
      private bool[] T00204_n565ConexionesAux3 ;
      private string[] T00204_A562ConexionesEstado ;
      private bool[] T00204_n562ConexionesEstado ;
      private long[] T002013_A918MapeoID ;
      private string[] T002014_A552ConexionesID ;
      private bool[] T002014_n552ConexionesID ;
      private string[] T002015_A552ConexionesID ;
      private bool[] T002015_n552ConexionesID ;
      private string[] T002015_A553ConexionesDatosId ;
      private string[] T002015_A566ConexionesDatosInt ;
      private bool[] T002015_n566ConexionesDatosInt ;
      private string[] T002015_A567ConexionesDatosExt ;
      private bool[] T002015_n567ConexionesDatosExt ;
      private string[] T002015_A568ConexionesDatosDetalle ;
      private bool[] T002015_n568ConexionesDatosDetalle ;
      private string[] T002016_A552ConexionesID ;
      private bool[] T002016_n552ConexionesID ;
      private string[] T002016_A553ConexionesDatosId ;
      private string[] T00203_A552ConexionesID ;
      private bool[] T00203_n552ConexionesID ;
      private string[] T00203_A553ConexionesDatosId ;
      private string[] T00203_A566ConexionesDatosInt ;
      private bool[] T00203_n566ConexionesDatosInt ;
      private string[] T00203_A567ConexionesDatosExt ;
      private bool[] T00203_n567ConexionesDatosExt ;
      private string[] T00203_A568ConexionesDatosDetalle ;
      private bool[] T00203_n568ConexionesDatosDetalle ;
      private string[] T00202_A552ConexionesID ;
      private bool[] T00202_n552ConexionesID ;
      private string[] T00202_A553ConexionesDatosId ;
      private string[] T00202_A566ConexionesDatosInt ;
      private bool[] T00202_n566ConexionesDatosInt ;
      private string[] T00202_A567ConexionesDatosExt ;
      private bool[] T00202_n567ConexionesDatosExt ;
      private string[] T00202_A568ConexionesDatosDetalle ;
      private bool[] T00202_n568ConexionesDatosDetalle ;
      private string[] T002020_A552ConexionesID ;
      private bool[] T002020_n552ConexionesID ;
      private string[] T002020_A553ConexionesDatosId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class conexiones__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class conexiones__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new ForEachCursor(def[18])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00202;
        prmT00202 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesDatosId",GXType.NChar,25,0)
        };
        Object[] prmT00203;
        prmT00203 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesDatosId",GXType.NChar,25,0)
        };
        Object[] prmT00204;
        prmT00204 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmT00205;
        prmT00205 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmT00206;
        prmT00206 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmT00207;
        prmT00207 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmT00208;
        prmT00208 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmT00209;
        prmT00209 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmT002010;
        prmT002010 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesNombre",GXType.NChar,80,0){Nullable=true} ,
        new ParDef("@ConexionesTipoIntegracion",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ConexionesHost",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesBaseURL",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesPort",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@ConexionesApiKey",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesUsr",GXType.NChar,64,0){Nullable=true} ,
        new ParDef("@ConexionesAux1",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesAux2",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesAux3",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesEstado",GXType.NChar,3,0){Nullable=true}
        };
        Object[] prmT002011;
        prmT002011 = new Object[] {
        new ParDef("@ConexionesNombre",GXType.NChar,80,0){Nullable=true} ,
        new ParDef("@ConexionesTipoIntegracion",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ConexionesHost",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesBaseURL",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesPort",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@ConexionesApiKey",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesUsr",GXType.NChar,64,0){Nullable=true} ,
        new ParDef("@ConexionesAux1",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesAux2",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesAux3",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmT002012;
        prmT002012 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmT002013;
        prmT002013 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmT002014;
        prmT002014 = new Object[] {
        };
        Object[] prmT002015;
        prmT002015 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesDatosId",GXType.NChar,25,0)
        };
        Object[] prmT002016;
        prmT002016 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesDatosId",GXType.NChar,25,0)
        };
        Object[] prmT002017;
        prmT002017 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesDatosId",GXType.NChar,25,0) ,
        new ParDef("@ConexionesDatosInt",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesDatosExt",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesDatosDetalle",GXType.NChar,256,0){Nullable=true}
        };
        Object[] prmT002018;
        prmT002018 = new Object[] {
        new ParDef("@ConexionesDatosInt",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesDatosExt",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesDatosDetalle",GXType.NChar,256,0){Nullable=true} ,
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesDatosId",GXType.NChar,25,0)
        };
        Object[] prmT002019;
        prmT002019 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesDatosId",GXType.NChar,25,0)
        };
        Object[] prmT002020;
        prmT002020 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00202", "SELECT [ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle] FROM [ConexionesDatos] WITH (UPDLOCK) WHERE [ConexionesID] = @ConexionesID AND [ConexionesDatosId] = @ConexionesDatosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00202,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00203", "SELECT [ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle] FROM [ConexionesDatos] WHERE [ConexionesID] = @ConexionesID AND [ConexionesDatosId] = @ConexionesDatosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00203,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00204", "SELECT [ConexionesID], [ConexionesNombre], [ConexionesTipoIntegracion], [ConexionesHost], [ConexionesBaseURL], [ConexionesPort], [ConexionesApiKey], [ConexionesUsr], [ConexionesAux1], [ConexionesAux2], [ConexionesAux3], [ConexionesEstado] FROM [Conexiones] WITH (UPDLOCK) WHERE [ConexionesID] = @ConexionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00204,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00205", "SELECT [ConexionesID], [ConexionesNombre], [ConexionesTipoIntegracion], [ConexionesHost], [ConexionesBaseURL], [ConexionesPort], [ConexionesApiKey], [ConexionesUsr], [ConexionesAux1], [ConexionesAux2], [ConexionesAux3], [ConexionesEstado] FROM [Conexiones] WHERE [ConexionesID] = @ConexionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00205,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00206", "SELECT TM1.[ConexionesID], TM1.[ConexionesNombre], TM1.[ConexionesTipoIntegracion], TM1.[ConexionesHost], TM1.[ConexionesBaseURL], TM1.[ConexionesPort], TM1.[ConexionesApiKey], TM1.[ConexionesUsr], TM1.[ConexionesAux1], TM1.[ConexionesAux2], TM1.[ConexionesAux3], TM1.[ConexionesEstado] FROM [Conexiones] TM1 WHERE TM1.[ConexionesID] = @ConexionesID ORDER BY TM1.[ConexionesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00206,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00207", "SELECT [ConexionesID] FROM [Conexiones] WHERE [ConexionesID] = @ConexionesID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00207,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00208", "SELECT TOP 1 [ConexionesID] FROM [Conexiones] WHERE ( [ConexionesID] > @ConexionesID) ORDER BY [ConexionesID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00208,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00209", "SELECT TOP 1 [ConexionesID] FROM [Conexiones] WHERE ( [ConexionesID] < @ConexionesID) ORDER BY [ConexionesID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00209,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002010", "INSERT INTO [Conexiones]([ConexionesID], [ConexionesNombre], [ConexionesTipoIntegracion], [ConexionesHost], [ConexionesBaseURL], [ConexionesPort], [ConexionesApiKey], [ConexionesUsr], [ConexionesAux1], [ConexionesAux2], [ConexionesAux3], [ConexionesEstado]) VALUES(@ConexionesID, @ConexionesNombre, @ConexionesTipoIntegracion, @ConexionesHost, @ConexionesBaseURL, @ConexionesPort, @ConexionesApiKey, @ConexionesUsr, @ConexionesAux1, @ConexionesAux2, @ConexionesAux3, @ConexionesEstado)", GxErrorMask.GX_NOMASK,prmT002010)
           ,new CursorDef("T002011", "UPDATE [Conexiones] SET [ConexionesNombre]=@ConexionesNombre, [ConexionesTipoIntegracion]=@ConexionesTipoIntegracion, [ConexionesHost]=@ConexionesHost, [ConexionesBaseURL]=@ConexionesBaseURL, [ConexionesPort]=@ConexionesPort, [ConexionesApiKey]=@ConexionesApiKey, [ConexionesUsr]=@ConexionesUsr, [ConexionesAux1]=@ConexionesAux1, [ConexionesAux2]=@ConexionesAux2, [ConexionesAux3]=@ConexionesAux3, [ConexionesEstado]=@ConexionesEstado  WHERE [ConexionesID] = @ConexionesID", GxErrorMask.GX_NOMASK,prmT002011)
           ,new CursorDef("T002012", "DELETE FROM [Conexiones]  WHERE [ConexionesID] = @ConexionesID", GxErrorMask.GX_NOMASK,prmT002012)
           ,new CursorDef("T002013", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE [ConexionesID] = @ConexionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002013,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002014", "SELECT [ConexionesID] FROM [Conexiones] ORDER BY [ConexionesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002014,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002015", "SELECT [ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle] FROM [ConexionesDatos] WHERE [ConexionesID] = @ConexionesID and [ConexionesDatosId] = @ConexionesDatosId ORDER BY [ConexionesID], [ConexionesDatosId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002015,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002016", "SELECT [ConexionesID], [ConexionesDatosId] FROM [ConexionesDatos] WHERE [ConexionesID] = @ConexionesID AND [ConexionesDatosId] = @ConexionesDatosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002016,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002017", "INSERT INTO [ConexionesDatos]([ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle]) VALUES(@ConexionesID, @ConexionesDatosId, @ConexionesDatosInt, @ConexionesDatosExt, @ConexionesDatosDetalle)", GxErrorMask.GX_NOMASK,prmT002017)
           ,new CursorDef("T002018", "UPDATE [ConexionesDatos] SET [ConexionesDatosInt]=@ConexionesDatosInt, [ConexionesDatosExt]=@ConexionesDatosExt, [ConexionesDatosDetalle]=@ConexionesDatosDetalle  WHERE [ConexionesID] = @ConexionesID AND [ConexionesDatosId] = @ConexionesDatosId", GxErrorMask.GX_NOMASK,prmT002018)
           ,new CursorDef("T002019", "DELETE FROM [ConexionesDatos]  WHERE [ConexionesID] = @ConexionesID AND [ConexionesDatosId] = @ConexionesDatosId", GxErrorMask.GX_NOMASK,prmT002019)
           ,new CursorDef("T002020", "SELECT [ConexionesID], [ConexionesDatosId] FROM [ConexionesDatos] WHERE [ConexionesID] = @ConexionesID ORDER BY [ConexionesID], [ConexionesDatosId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002020,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 25);
              ((string[]) buf[2])[0] = rslt.getString(3, 128);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 128);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 256);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 25);
              ((string[]) buf[2])[0] = rslt.getString(3, 128);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 128);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 256);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((short[]) buf[3])[0] = rslt.getShort(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getString(4, 128);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 128);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((int[]) buf[9])[0] = rslt.getInt(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getString(7, 128);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getString(8, 64);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getString(9, 128);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((string[]) buf[17])[0] = rslt.getString(10, 128);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((string[]) buf[19])[0] = rslt.getString(11, 128);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getString(12, 3);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((short[]) buf[3])[0] = rslt.getShort(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getString(4, 128);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 128);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((int[]) buf[9])[0] = rslt.getInt(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getString(7, 128);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getString(8, 64);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getString(9, 128);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((string[]) buf[17])[0] = rslt.getString(10, 128);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((string[]) buf[19])[0] = rslt.getString(11, 128);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getString(12, 3);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((short[]) buf[3])[0] = rslt.getShort(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getString(4, 128);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 128);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((int[]) buf[9])[0] = rslt.getInt(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getString(7, 128);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getString(8, 64);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getString(9, 128);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((string[]) buf[17])[0] = rslt.getString(10, 128);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((string[]) buf[19])[0] = rslt.getString(11, 128);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getString(12, 3);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 25);
              ((string[]) buf[2])[0] = rslt.getString(3, 128);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 128);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 256);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 25);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 25);
              return;
     }
  }

}

}
