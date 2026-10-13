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
   public class parametros : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "parametros.aspx")), "parametros.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "parametros.aspx")))) ;
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
                  AV7ParametrosId = (long)(Math.Round(NumberUtil.Val( GetPar( "ParametrosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ParametrosId", StringUtil.LTrimStr( (decimal)(AV7ParametrosId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ParametrosId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Parametros", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbParametrosEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public parametros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public parametros( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_ParametrosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ParametrosId = aP1_ParametrosId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbParametrosEstado = new GXCombobox();
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
         if ( cmbParametrosEstado.ItemCount > 0 )
         {
            A238ParametrosEstado = cmbParametrosEstado.getValidValue(A238ParametrosEstado);
            AssignAttri("", false, "A238ParametrosEstado", A238ParametrosEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbParametrosEstado.CurrentValue = StringUtil.RTrim( A238ParametrosEstado);
            AssignProp("", false, cmbParametrosEstado_Internalname, "Values", cmbParametrosEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametrosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosId_Internalname, context.GetMessage( "Parametro", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A283ParametrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtParametrosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A283ParametrosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A283ParametrosId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametrosId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbParametrosEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbParametrosEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbParametrosEstado, cmbParametrosEstado_Internalname, StringUtil.RTrim( A238ParametrosEstado), 1, cmbParametrosEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbParametrosEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Parametros.htm");
         cmbParametrosEstado.CurrentValue = StringUtil.RTrim( A238ParametrosEstado);
         AssignProp("", false, cmbParametrosEstado_Internalname, "Values", (string)(cmbParametrosEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametrosNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrosNombre_Internalname, StringUtil.RTrim( A284ParametrosNombre), StringUtil.RTrim( context.localUtil.Format( A284ParametrosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametrosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametrosCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosCodigo_Internalname, context.GetMessage( "Codigo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrosCodigo_Internalname, StringUtil.RTrim( A237ParametrosCodigo), StringUtil.RTrim( context.localUtil.Format( A237ParametrosCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosCodigo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametrosCodigo_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametrosNumerico_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosNumerico_Internalname, context.GetMessage( "Número", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrosNumerico_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A635ParametrosNumerico), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtParametrosNumerico_Enabled!=0) ? context.localUtil.Format( (decimal)(A635ParametrosNumerico), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A635ParametrosNumerico), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosNumerico_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametrosNumerico_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametrosValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosValor_Internalname, context.GetMessage( "Valor", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtParametrosValor_Internalname, A602ParametrosValor, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", 0, 1, edtParametrosValor_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "ParametroValorSis", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Parametros.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
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
         E11252 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z283ParametrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z283ParametrosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z237ParametrosCodigo = cgiGet( "Z237ParametrosCodigo");
               Z284ParametrosNombre = cgiGet( "Z284ParametrosNombre");
               Z602ParametrosValor = cgiGet( "Z602ParametrosValor");
               Z635ParametrosNumerico = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z635ParametrosNumerico"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z238ParametrosEstado = cgiGet( "Z238ParametrosEstado");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7ParametrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vPARAMETROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV14Pgmname = cgiGet( "vPGMNAME");
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
               A283ParametrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtParametrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A283ParametrosId", StringUtil.LTrimStr( (decimal)(A283ParametrosId), 18, 0));
               cmbParametrosEstado.CurrentValue = cgiGet( cmbParametrosEstado_Internalname);
               A238ParametrosEstado = cgiGet( cmbParametrosEstado_Internalname);
               AssignAttri("", false, "A238ParametrosEstado", A238ParametrosEstado);
               A284ParametrosNombre = cgiGet( edtParametrosNombre_Internalname);
               AssignAttri("", false, "A284ParametrosNombre", A284ParametrosNombre);
               A237ParametrosCodigo = cgiGet( edtParametrosCodigo_Internalname);
               AssignAttri("", false, "A237ParametrosCodigo", A237ParametrosCodigo);
               if ( ( ( context.localUtil.CToN( cgiGet( edtParametrosNumerico_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParametrosNumerico_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARAMETROSNUMERICO");
                  AnyError = 1;
                  GX_FocusControl = edtParametrosNumerico_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A635ParametrosNumerico = 0;
                  AssignAttri("", false, "A635ParametrosNumerico", StringUtil.LTrimStr( (decimal)(A635ParametrosNumerico), 9, 0));
               }
               else
               {
                  A635ParametrosNumerico = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtParametrosNumerico_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A635ParametrosNumerico", StringUtil.LTrimStr( (decimal)(A635ParametrosNumerico), 9, 0));
               }
               A602ParametrosValor = cgiGet( edtParametrosValor_Internalname);
               AssignAttri("", false, "A602ParametrosValor", A602ParametrosValor);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Parametros");
               A283ParametrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtParametrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A283ParametrosId", StringUtil.LTrimStr( (decimal)(A283ParametrosId), 18, 0));
               forbiddenHiddens.Add("ParametrosId", context.localUtil.Format( (decimal)(A283ParametrosId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A283ParametrosId != Z283ParametrosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("parametros:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A283ParametrosId = (long)(Math.Round(NumberUtil.Val( GetPar( "ParametrosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A283ParametrosId", StringUtil.LTrimStr( (decimal)(A283ParametrosId), 18, 0));
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
                     sMode88 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode88;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound88 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_250( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PARAMETROSID");
                        AnyError = 1;
                        GX_FocusControl = edtParametrosId_Internalname;
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
                           E11252 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12252 ();
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
            E12252 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2588( ) ;
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
            DisableAttributes2588( ) ;
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

      protected void CONFIRM_250( )
      {
         BeforeValidate2588( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2588( ) ;
            }
            else
            {
               CheckExtendedTable2588( ) ;
               CloseExtendedTableCursors2588( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption250( )
      {
      }

      protected void E11252( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametros_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametros_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametros_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV14Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12252( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("parametrosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM2588( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z237ParametrosCodigo = T00253_A237ParametrosCodigo[0];
               Z284ParametrosNombre = T00253_A284ParametrosNombre[0];
               Z602ParametrosValor = T00253_A602ParametrosValor[0];
               Z635ParametrosNumerico = T00253_A635ParametrosNumerico[0];
               Z238ParametrosEstado = T00253_A238ParametrosEstado[0];
            }
            else
            {
               Z237ParametrosCodigo = A237ParametrosCodigo;
               Z284ParametrosNombre = A284ParametrosNombre;
               Z602ParametrosValor = A602ParametrosValor;
               Z635ParametrosNumerico = A635ParametrosNumerico;
               Z238ParametrosEstado = A238ParametrosEstado;
            }
         }
         if ( GX_JID == -5 )
         {
            Z283ParametrosId = A283ParametrosId;
            Z237ParametrosCodigo = A237ParametrosCodigo;
            Z284ParametrosNombre = A284ParametrosNombre;
            Z602ParametrosValor = A602ParametrosValor;
            Z635ParametrosNumerico = A635ParametrosNumerico;
            Z238ParametrosEstado = A238ParametrosEstado;
         }
      }

      protected void standaloneNotModal( )
      {
         edtParametrosId_Enabled = 0;
         AssignProp("", false, edtParametrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtParametrosId_Enabled = 0;
         AssignProp("", false, edtParametrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ParametrosId) )
         {
            A283ParametrosId = AV7ParametrosId;
            AssignAttri("", false, "A283ParametrosId", StringUtil.LTrimStr( (decimal)(A283ParametrosId), 18, 0));
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A238ParametrosEstado)) && ( Gx_BScreen == 0 ) )
         {
            A238ParametrosEstado = "HAB";
            AssignAttri("", false, "A238ParametrosEstado", A238ParametrosEstado);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load2588( )
      {
         /* Using cursor T00254 */
         pr_default.execute(2, new Object[] {A283ParametrosId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound88 = 1;
            A237ParametrosCodigo = T00254_A237ParametrosCodigo[0];
            AssignAttri("", false, "A237ParametrosCodigo", A237ParametrosCodigo);
            A284ParametrosNombre = T00254_A284ParametrosNombre[0];
            AssignAttri("", false, "A284ParametrosNombre", A284ParametrosNombre);
            A602ParametrosValor = T00254_A602ParametrosValor[0];
            AssignAttri("", false, "A602ParametrosValor", A602ParametrosValor);
            A635ParametrosNumerico = T00254_A635ParametrosNumerico[0];
            AssignAttri("", false, "A635ParametrosNumerico", StringUtil.LTrimStr( (decimal)(A635ParametrosNumerico), 9, 0));
            A238ParametrosEstado = T00254_A238ParametrosEstado[0];
            AssignAttri("", false, "A238ParametrosEstado", A238ParametrosEstado);
            ZM2588( -5) ;
         }
         pr_default.close(2);
         OnLoadActions2588( ) ;
      }

      protected void OnLoadActions2588( )
      {
         AV14Pgmname = "Parametros";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable2588( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV14Pgmname = "Parametros";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         /* Using cursor T00255 */
         pr_default.execute(3, new Object[] {A237ParametrosCodigo, A283ParametrosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Codigo", "")}), "DuplicateCandidateKey", 1, "PARAMETROSCODIGO");
            AnyError = 1;
            GX_FocusControl = edtParametrosCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A238ParametrosEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A238ParametrosEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A238ParametrosEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A238ParametrosEstado, "BLO") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PARAMETROSESTADO");
            AnyError = 1;
            GX_FocusControl = cmbParametrosEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2588( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2588( )
      {
         /* Using cursor T00256 */
         pr_default.execute(4, new Object[] {A283ParametrosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound88 = 1;
         }
         else
         {
            RcdFound88 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00253 */
         pr_default.execute(1, new Object[] {A283ParametrosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2588( 5) ;
            RcdFound88 = 1;
            A283ParametrosId = T00253_A283ParametrosId[0];
            AssignAttri("", false, "A283ParametrosId", StringUtil.LTrimStr( (decimal)(A283ParametrosId), 18, 0));
            A237ParametrosCodigo = T00253_A237ParametrosCodigo[0];
            AssignAttri("", false, "A237ParametrosCodigo", A237ParametrosCodigo);
            A284ParametrosNombre = T00253_A284ParametrosNombre[0];
            AssignAttri("", false, "A284ParametrosNombre", A284ParametrosNombre);
            A602ParametrosValor = T00253_A602ParametrosValor[0];
            AssignAttri("", false, "A602ParametrosValor", A602ParametrosValor);
            A635ParametrosNumerico = T00253_A635ParametrosNumerico[0];
            AssignAttri("", false, "A635ParametrosNumerico", StringUtil.LTrimStr( (decimal)(A635ParametrosNumerico), 9, 0));
            A238ParametrosEstado = T00253_A238ParametrosEstado[0];
            AssignAttri("", false, "A238ParametrosEstado", A238ParametrosEstado);
            Z283ParametrosId = A283ParametrosId;
            sMode88 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2588( ) ;
            if ( AnyError == 1 )
            {
               RcdFound88 = 0;
               InitializeNonKey2588( ) ;
            }
            Gx_mode = sMode88;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound88 = 0;
            InitializeNonKey2588( ) ;
            sMode88 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode88;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2588( ) ;
         if ( RcdFound88 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound88 = 0;
         /* Using cursor T00257 */
         pr_default.execute(5, new Object[] {A283ParametrosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00257_A283ParametrosId[0] < A283ParametrosId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00257_A283ParametrosId[0] > A283ParametrosId ) ) )
            {
               A283ParametrosId = T00257_A283ParametrosId[0];
               AssignAttri("", false, "A283ParametrosId", StringUtil.LTrimStr( (decimal)(A283ParametrosId), 18, 0));
               RcdFound88 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound88 = 0;
         /* Using cursor T00258 */
         pr_default.execute(6, new Object[] {A283ParametrosId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00258_A283ParametrosId[0] > A283ParametrosId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00258_A283ParametrosId[0] < A283ParametrosId ) ) )
            {
               A283ParametrosId = T00258_A283ParametrosId[0];
               AssignAttri("", false, "A283ParametrosId", StringUtil.LTrimStr( (decimal)(A283ParametrosId), 18, 0));
               RcdFound88 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2588( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbParametrosEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2588( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound88 == 1 )
            {
               if ( A283ParametrosId != Z283ParametrosId )
               {
                  A283ParametrosId = Z283ParametrosId;
                  AssignAttri("", false, "A283ParametrosId", StringUtil.LTrimStr( (decimal)(A283ParametrosId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PARAMETROSID");
                  AnyError = 1;
                  GX_FocusControl = edtParametrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbParametrosEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2588( ) ;
                  GX_FocusControl = cmbParametrosEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A283ParametrosId != Z283ParametrosId )
               {
                  /* Insert record */
                  GX_FocusControl = cmbParametrosEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2588( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PARAMETROSID");
                     AnyError = 1;
                     GX_FocusControl = edtParametrosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbParametrosEstado_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2588( ) ;
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
         if ( A283ParametrosId != Z283ParametrosId )
         {
            A283ParametrosId = Z283ParametrosId;
            AssignAttri("", false, "A283ParametrosId", StringUtil.LTrimStr( (decimal)(A283ParametrosId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PARAMETROSID");
            AnyError = 1;
            GX_FocusControl = edtParametrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbParametrosEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2588( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00252 */
            pr_default.execute(0, new Object[] {A283ParametrosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Parametros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z237ParametrosCodigo, T00252_A237ParametrosCodigo[0]) != 0 ) || ( StringUtil.StrCmp(Z284ParametrosNombre, T00252_A284ParametrosNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z602ParametrosValor, T00252_A602ParametrosValor[0]) != 0 ) || ( Z635ParametrosNumerico != T00252_A635ParametrosNumerico[0] ) || ( StringUtil.StrCmp(Z238ParametrosEstado, T00252_A238ParametrosEstado[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z237ParametrosCodigo, T00252_A237ParametrosCodigo[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z237ParametrosCodigo);
                  GXUtil.WriteLogRaw("Current: ",T00252_A237ParametrosCodigo[0]);
               }
               if ( StringUtil.StrCmp(Z284ParametrosNombre, T00252_A284ParametrosNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosNombre");
                  GXUtil.WriteLogRaw("Old: ",Z284ParametrosNombre);
                  GXUtil.WriteLogRaw("Current: ",T00252_A284ParametrosNombre[0]);
               }
               if ( StringUtil.StrCmp(Z602ParametrosValor, T00252_A602ParametrosValor[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosValor");
                  GXUtil.WriteLogRaw("Old: ",Z602ParametrosValor);
                  GXUtil.WriteLogRaw("Current: ",T00252_A602ParametrosValor[0]);
               }
               if ( Z635ParametrosNumerico != T00252_A635ParametrosNumerico[0] )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosNumerico");
                  GXUtil.WriteLogRaw("Old: ",Z635ParametrosNumerico);
                  GXUtil.WriteLogRaw("Current: ",T00252_A635ParametrosNumerico[0]);
               }
               if ( StringUtil.StrCmp(Z238ParametrosEstado, T00252_A238ParametrosEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosEstado");
                  GXUtil.WriteLogRaw("Old: ",Z238ParametrosEstado);
                  GXUtil.WriteLogRaw("Current: ",T00252_A238ParametrosEstado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Parametros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2588( )
      {
         BeforeValidate2588( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2588( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2588( 0) ;
            CheckOptimisticConcurrency2588( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2588( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2588( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00259 */
                     pr_default.execute(7, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A635ParametrosNumerico, A238ParametrosEstado});
                     A283ParametrosId = T00259_A283ParametrosId[0];
                     AssignAttri("", false, "A283ParametrosId", StringUtil.LTrimStr( (decimal)(A283ParametrosId), 18, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Parametros");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption250( ) ;
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
               Load2588( ) ;
            }
            EndLevel2588( ) ;
         }
         CloseExtendedTableCursors2588( ) ;
      }

      protected void Update2588( )
      {
         BeforeValidate2588( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2588( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2588( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2588( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2588( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002510 */
                     pr_default.execute(8, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A635ParametrosNumerico, A238ParametrosEstado, A283ParametrosId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Parametros");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Parametros"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2588( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
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
            EndLevel2588( ) ;
         }
         CloseExtendedTableCursors2588( ) ;
      }

      protected void DeferredUpdate2588( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2588( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2588( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2588( ) ;
            AfterConfirm2588( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2588( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002511 */
                  pr_default.execute(9, new Object[] {A283ParametrosId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Parametros");
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
         sMode88 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2588( ) ;
         Gx_mode = sMode88;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2588( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "Parametros";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         }
      }

      protected void EndLevel2588( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2588( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("parametros",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues250( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("parametros",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2588( )
      {
         /* Scan By routine */
         /* Using cursor T002512 */
         pr_default.execute(10);
         RcdFound88 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound88 = 1;
            A283ParametrosId = T002512_A283ParametrosId[0];
            AssignAttri("", false, "A283ParametrosId", StringUtil.LTrimStr( (decimal)(A283ParametrosId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2588( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound88 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound88 = 1;
            A283ParametrosId = T002512_A283ParametrosId[0];
            AssignAttri("", false, "A283ParametrosId", StringUtil.LTrimStr( (decimal)(A283ParametrosId), 18, 0));
         }
      }

      protected void ScanEnd2588( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm2588( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2588( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2588( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2588( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2588( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2588( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2588( )
      {
         edtParametrosId_Enabled = 0;
         AssignProp("", false, edtParametrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosId_Enabled), 5, 0), true);
         cmbParametrosEstado.Enabled = 0;
         AssignProp("", false, cmbParametrosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbParametrosEstado.Enabled), 5, 0), true);
         edtParametrosNombre_Enabled = 0;
         AssignProp("", false, edtParametrosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosNombre_Enabled), 5, 0), true);
         edtParametrosCodigo_Enabled = 0;
         AssignProp("", false, edtParametrosCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosCodigo_Enabled), 5, 0), true);
         edtParametrosNumerico_Enabled = 0;
         AssignProp("", false, edtParametrosNumerico_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosNumerico_Enabled), 5, 0), true);
         edtParametrosValor_Enabled = 0;
         AssignProp("", false, edtParametrosValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosValor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2588( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues250( )
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
         GXEncryptionTmp = "parametros.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ParametrosId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("parametros.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Parametros");
         forbiddenHiddens.Add("ParametrosId", context.localUtil.Format( (decimal)(A283ParametrosId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("parametros:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z283ParametrosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z283ParametrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z237ParametrosCodigo", StringUtil.RTrim( Z237ParametrosCodigo));
         GxWebStd.gx_hidden_field( context, "Z284ParametrosNombre", StringUtil.RTrim( Z284ParametrosNombre));
         GxWebStd.gx_hidden_field( context, "Z602ParametrosValor", Z602ParametrosValor);
         GxWebStd.gx_hidden_field( context, "Z635ParametrosNumerico", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z635ParametrosNumerico), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z238ParametrosEstado", StringUtil.RTrim( Z238ParametrosEstado));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vPARAMETROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ParametrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ParametrosId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
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
         GXEncryptionTmp = "parametros.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ParametrosId,18,0));
         return formatLink("parametros.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Parametros" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Parametros", "") ;
      }

      protected void InitializeNonKey2588( )
      {
         A237ParametrosCodigo = "";
         AssignAttri("", false, "A237ParametrosCodigo", A237ParametrosCodigo);
         A284ParametrosNombre = "";
         AssignAttri("", false, "A284ParametrosNombre", A284ParametrosNombre);
         A602ParametrosValor = "";
         AssignAttri("", false, "A602ParametrosValor", A602ParametrosValor);
         A635ParametrosNumerico = 0;
         AssignAttri("", false, "A635ParametrosNumerico", StringUtil.LTrimStr( (decimal)(A635ParametrosNumerico), 9, 0));
         A238ParametrosEstado = "HAB";
         AssignAttri("", false, "A238ParametrosEstado", A238ParametrosEstado);
         Z237ParametrosCodigo = "";
         Z284ParametrosNombre = "";
         Z602ParametrosValor = "";
         Z635ParametrosNumerico = 0;
         Z238ParametrosEstado = "";
      }

      protected void InitAll2588( )
      {
         A283ParametrosId = 0;
         AssignAttri("", false, "A283ParametrosId", StringUtil.LTrimStr( (decimal)(A283ParametrosId), 18, 0));
         InitializeNonKey2588( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A238ParametrosEstado = i238ParametrosEstado;
         AssignAttri("", false, "A238ParametrosEstado", A238ParametrosEstado);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932083699", true, true, false);
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
         context.AddJavascriptSource("parametros.js", "?202693208370", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtParametrosId_Internalname = "PARAMETROSID";
         cmbParametrosEstado_Internalname = "PARAMETROSESTADO";
         edtParametrosNombre_Internalname = "PARAMETROSNOMBRE";
         edtParametrosCodigo_Internalname = "PARAMETROSCODIGO";
         edtParametrosNumerico_Internalname = "PARAMETROSNUMERICO";
         edtParametrosValor_Internalname = "PARAMETROSVALOR";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
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
         Form.Caption = context.GetMessage( "Parametros", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtParametrosValor_Enabled = 1;
         edtParametrosNumerico_Jsonclick = "";
         edtParametrosNumerico_Enabled = 1;
         edtParametrosCodigo_Jsonclick = "";
         edtParametrosCodigo_Enabled = 1;
         edtParametrosNombre_Jsonclick = "";
         edtParametrosNombre_Enabled = 1;
         cmbParametrosEstado_Jsonclick = "";
         cmbParametrosEstado.Enabled = 1;
         edtParametrosId_Jsonclick = "";
         edtParametrosId_Enabled = 0;
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

      protected void init_web_controls( )
      {
         cmbParametrosEstado.Name = "PARAMETROSESTADO";
         cmbParametrosEstado.WebTags = "";
         cmbParametrosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbParametrosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbParametrosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbParametrosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbParametrosEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A238ParametrosEstado)) )
            {
               A238ParametrosEstado = "HAB";
               AssignAttri("", false, "A238ParametrosEstado", A238ParametrosEstado);
            }
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

      public void Valid_Parametroscodigo( )
      {
         /* Using cursor T002513 */
         pr_default.execute(11, new Object[] {A237ParametrosCodigo, A283ParametrosId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Codigo", "")}), "DuplicateCandidateKey", 1, "PARAMETROSCODIGO");
            AnyError = 1;
            GX_FocusControl = edtParametrosCodigo_Internalname;
         }
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7ParametrosId',fld:'vPARAMETROSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ParametrosId',fld:'vPARAMETROSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A283ParametrosId',fld:'PARAMETROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12252',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PARAMETROSID","{handler:'Valid_Parametrosid',iparms:[]");
         setEventMetadata("VALID_PARAMETROSID",",oparms:[]}");
         setEventMetadata("VALID_PARAMETROSESTADO","{handler:'Valid_Parametrosestado',iparms:[]");
         setEventMetadata("VALID_PARAMETROSESTADO",",oparms:[]}");
         setEventMetadata("VALID_PARAMETROSCODIGO","{handler:'Valid_Parametroscodigo',iparms:[{av:'A237ParametrosCodigo',fld:'PARAMETROSCODIGO',pic:'',type:'char'},{av:'A283ParametrosId',fld:'PARAMETROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_PARAMETROSCODIGO",",oparms:[]}");
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
         wcpOGx_mode = "";
         Z237ParametrosCodigo = "";
         Z284ParametrosNombre = "";
         Z602ParametrosValor = "";
         Z238ParametrosEstado = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A238ParametrosEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A284ParametrosNombre = "";
         A237ParametrosCodigo = "";
         A602ParametrosValor = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV14Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode88 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T00254_A283ParametrosId = new long[1] ;
         T00254_A237ParametrosCodigo = new string[] {""} ;
         T00254_A284ParametrosNombre = new string[] {""} ;
         T00254_A602ParametrosValor = new string[] {""} ;
         T00254_A635ParametrosNumerico = new int[1] ;
         T00254_A238ParametrosEstado = new string[] {""} ;
         T00255_A237ParametrosCodigo = new string[] {""} ;
         T00256_A283ParametrosId = new long[1] ;
         T00253_A283ParametrosId = new long[1] ;
         T00253_A237ParametrosCodigo = new string[] {""} ;
         T00253_A284ParametrosNombre = new string[] {""} ;
         T00253_A602ParametrosValor = new string[] {""} ;
         T00253_A635ParametrosNumerico = new int[1] ;
         T00253_A238ParametrosEstado = new string[] {""} ;
         T00257_A283ParametrosId = new long[1] ;
         T00258_A283ParametrosId = new long[1] ;
         T00252_A283ParametrosId = new long[1] ;
         T00252_A237ParametrosCodigo = new string[] {""} ;
         T00252_A284ParametrosNombre = new string[] {""} ;
         T00252_A602ParametrosValor = new string[] {""} ;
         T00252_A635ParametrosNumerico = new int[1] ;
         T00252_A238ParametrosEstado = new string[] {""} ;
         T00259_A283ParametrosId = new long[1] ;
         T002512_A283ParametrosId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i238ParametrosEstado = "";
         T002513_A237ParametrosCodigo = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.parametros__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametros__default(),
            new Object[][] {
                new Object[] {
               T00252_A283ParametrosId, T00252_A237ParametrosCodigo, T00252_A284ParametrosNombre, T00252_A602ParametrosValor, T00252_A635ParametrosNumerico, T00252_A238ParametrosEstado
               }
               , new Object[] {
               T00253_A283ParametrosId, T00253_A237ParametrosCodigo, T00253_A284ParametrosNombre, T00253_A602ParametrosValor, T00253_A635ParametrosNumerico, T00253_A238ParametrosEstado
               }
               , new Object[] {
               T00254_A283ParametrosId, T00254_A237ParametrosCodigo, T00254_A284ParametrosNombre, T00254_A602ParametrosValor, T00254_A635ParametrosNumerico, T00254_A238ParametrosEstado
               }
               , new Object[] {
               T00255_A237ParametrosCodigo
               }
               , new Object[] {
               T00256_A283ParametrosId
               }
               , new Object[] {
               T00257_A283ParametrosId
               }
               , new Object[] {
               T00258_A283ParametrosId
               }
               , new Object[] {
               T00259_A283ParametrosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002512_A283ParametrosId
               }
               , new Object[] {
               T002513_A237ParametrosCodigo
               }
            }
         );
         AV14Pgmname = "Parametros";
         Z238ParametrosEstado = "HAB";
         A238ParametrosEstado = "HAB";
         i238ParametrosEstado = "HAB";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound88 ;
      private short gxajaxcallmode ;
      private int Z635ParametrosNumerico ;
      private int trnEnded ;
      private int edtParametrosId_Enabled ;
      private int edtParametrosNombre_Enabled ;
      private int edtParametrosCodigo_Enabled ;
      private int A635ParametrosNumerico ;
      private int edtParametrosNumerico_Enabled ;
      private int edtParametrosValor_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long wcpOAV7ParametrosId ;
      private long Z283ParametrosId ;
      private long AV7ParametrosId ;
      private long A283ParametrosId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z237ParametrosCodigo ;
      private string Z284ParametrosNombre ;
      private string Z238ParametrosEstado ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbParametrosEstado_Internalname ;
      private string A238ParametrosEstado ;
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
      private string edtParametrosId_Internalname ;
      private string TempTags ;
      private string edtParametrosId_Jsonclick ;
      private string cmbParametrosEstado_Jsonclick ;
      private string edtParametrosNombre_Internalname ;
      private string A284ParametrosNombre ;
      private string edtParametrosNombre_Jsonclick ;
      private string edtParametrosCodigo_Internalname ;
      private string A237ParametrosCodigo ;
      private string edtParametrosCodigo_Jsonclick ;
      private string edtParametrosNumerico_Internalname ;
      private string edtParametrosNumerico_Jsonclick ;
      private string edtParametrosValor_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV14Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode88 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i238ParametrosEstado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private string Z602ParametrosValor ;
      private string A602ParametrosValor ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbParametrosEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] T00254_A283ParametrosId ;
      private string[] T00254_A237ParametrosCodigo ;
      private string[] T00254_A284ParametrosNombre ;
      private string[] T00254_A602ParametrosValor ;
      private int[] T00254_A635ParametrosNumerico ;
      private string[] T00254_A238ParametrosEstado ;
      private string[] T00255_A237ParametrosCodigo ;
      private long[] T00256_A283ParametrosId ;
      private long[] T00253_A283ParametrosId ;
      private string[] T00253_A237ParametrosCodigo ;
      private string[] T00253_A284ParametrosNombre ;
      private string[] T00253_A602ParametrosValor ;
      private int[] T00253_A635ParametrosNumerico ;
      private string[] T00253_A238ParametrosEstado ;
      private long[] T00257_A283ParametrosId ;
      private long[] T00258_A283ParametrosId ;
      private long[] T00252_A283ParametrosId ;
      private string[] T00252_A237ParametrosCodigo ;
      private string[] T00252_A284ParametrosNombre ;
      private string[] T00252_A602ParametrosValor ;
      private int[] T00252_A635ParametrosNumerico ;
      private string[] T00252_A238ParametrosEstado ;
      private long[] T00259_A283ParametrosId ;
      private long[] T002512_A283ParametrosId ;
      private string[] T002513_A237ParametrosCodigo ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class parametros__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class parametros__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00252;
        prmT00252 = new Object[] {
        new ParDef("@ParametrosId",GXType.Decimal,18,0)
        };
        Object[] prmT00253;
        prmT00253 = new Object[] {
        new ParDef("@ParametrosId",GXType.Decimal,18,0)
        };
        Object[] prmT00254;
        prmT00254 = new Object[] {
        new ParDef("@ParametrosId",GXType.Decimal,18,0)
        };
        Object[] prmT00255;
        prmT00255 = new Object[] {
        new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
        new ParDef("@ParametrosId",GXType.Decimal,18,0)
        };
        Object[] prmT00256;
        prmT00256 = new Object[] {
        new ParDef("@ParametrosId",GXType.Decimal,18,0)
        };
        Object[] prmT00257;
        prmT00257 = new Object[] {
        new ParDef("@ParametrosId",GXType.Decimal,18,0)
        };
        Object[] prmT00258;
        prmT00258 = new Object[] {
        new ParDef("@ParametrosId",GXType.Decimal,18,0)
        };
        Object[] prmT00259;
        prmT00259 = new Object[] {
        new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
        new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
        new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
        new ParDef("@ParametrosNumerico",GXType.Int32,9,0) ,
        new ParDef("@ParametrosEstado",GXType.NChar,3,0)
        };
        Object[] prmT002510;
        prmT002510 = new Object[] {
        new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
        new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
        new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
        new ParDef("@ParametrosNumerico",GXType.Int32,9,0) ,
        new ParDef("@ParametrosEstado",GXType.NChar,3,0) ,
        new ParDef("@ParametrosId",GXType.Decimal,18,0)
        };
        Object[] prmT002511;
        prmT002511 = new Object[] {
        new ParDef("@ParametrosId",GXType.Decimal,18,0)
        };
        Object[] prmT002512;
        prmT002512 = new Object[] {
        };
        Object[] prmT002513;
        prmT002513 = new Object[] {
        new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
        new ParDef("@ParametrosId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00252", "SELECT [ParametrosId], [ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosNumerico], [ParametrosEstado] FROM [Parametros] WITH (UPDLOCK) WHERE [ParametrosId] = @ParametrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00252,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00253", "SELECT [ParametrosId], [ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosNumerico], [ParametrosEstado] FROM [Parametros] WHERE [ParametrosId] = @ParametrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00253,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00254", "SELECT TM1.[ParametrosId], TM1.[ParametrosCodigo], TM1.[ParametrosNombre], TM1.[ParametrosValor], TM1.[ParametrosNumerico], TM1.[ParametrosEstado] FROM [Parametros] TM1 WHERE TM1.[ParametrosId] = @ParametrosId ORDER BY TM1.[ParametrosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00254,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00255", "SELECT [ParametrosCodigo] FROM [Parametros] WHERE ([ParametrosCodigo] = @ParametrosCodigo) AND (Not ( [ParametrosId] = @ParametrosId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00255,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00256", "SELECT [ParametrosId] FROM [Parametros] WHERE [ParametrosId] = @ParametrosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00256,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00257", "SELECT TOP 1 [ParametrosId] FROM [Parametros] WHERE ( [ParametrosId] > @ParametrosId) ORDER BY [ParametrosId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00257,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00258", "SELECT TOP 1 [ParametrosId] FROM [Parametros] WHERE ( [ParametrosId] < @ParametrosId) ORDER BY [ParametrosId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00258,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00259", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosNumerico], [ParametrosEstado]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosNumerico, @ParametrosEstado); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT00259,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002510", "UPDATE [Parametros] SET [ParametrosCodigo]=@ParametrosCodigo, [ParametrosNombre]=@ParametrosNombre, [ParametrosValor]=@ParametrosValor, [ParametrosNumerico]=@ParametrosNumerico, [ParametrosEstado]=@ParametrosEstado  WHERE [ParametrosId] = @ParametrosId", GxErrorMask.GX_NOMASK,prmT002510)
           ,new CursorDef("T002511", "DELETE FROM [Parametros]  WHERE [ParametrosId] = @ParametrosId", GxErrorMask.GX_NOMASK,prmT002511)
           ,new CursorDef("T002512", "SELECT [ParametrosId] FROM [Parametros] ORDER BY [ParametrosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002512,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002513", "SELECT [ParametrosCodigo] FROM [Parametros] WHERE ([ParametrosCodigo] = @ParametrosCodigo) AND (Not ( [ParametrosId] = @ParametrosId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT002513,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
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
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
     }
  }

}

}
