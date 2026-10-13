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
   public class documentacion : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "documentacion.aspx")), "documentacion.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "documentacion.aspx")))) ;
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
                  AV7DocumentacionId = (long)(Math.Round(NumberUtil.Val( GetPar( "DocumentacionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7DocumentacionId", StringUtil.LTrimStr( (decimal)(AV7DocumentacionId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTACIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7DocumentacionId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Documentacion", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDocumentacionNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public documentacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_DocumentacionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7DocumentacionId = aP1_DocumentacionId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDocumentacionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocumentacionId_Internalname, context.GetMessage( "Documentación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentacionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A488DocumentacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtDocumentacionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A488DocumentacionId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A488DocumentacionId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentacionId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentacionId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Documentacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDocumentacionNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocumentacionNombre_Internalname, context.GetMessage( "Nombre del Documento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentacionNombre_Internalname, StringUtil.RTrim( A489DocumentacionNombre), StringUtil.RTrim( context.localUtil.Format( A489DocumentacionNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentacionNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentacionNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Documentacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgDocumentacionIcono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Icono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A498DocumentacionIcono_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000DocumentacionIcono_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.PathToRelativeUrl( A498DocumentacionIcono));
         GxWebStd.gx_bitmap( context, imgDocumentacionIcono_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgDocumentacionIcono_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", "", "", 0, A498DocumentacionIcono_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_Documentacion.htm");
         AssignProp("", false, imgDocumentacionIcono_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.PathToRelativeUrl( A498DocumentacionIcono)), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "IsBlob", StringUtil.BoolToStr( A498DocumentacionIcono_IsBlob), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Documentacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Documentacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Documentacion.htm");
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
         E111S2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z488DocumentacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z488DocumentacionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z489DocumentacionNombre = cgiGet( "Z489DocumentacionNombre");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7DocumentacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vDOCUMENTACIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A40000DocumentacionIcono_GXI = cgiGet( "DOCUMENTACIONICONO_GXI");
               AV13Pgmname = cgiGet( "vPGMNAME");
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
               A488DocumentacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDocumentacionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n488DocumentacionId = false;
               AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
               A489DocumentacionNombre = cgiGet( edtDocumentacionNombre_Internalname);
               AssignAttri("", false, "A489DocumentacionNombre", A489DocumentacionNombre);
               A498DocumentacionIcono = cgiGet( imgDocumentacionIcono_Internalname);
               AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgDocumentacionIcono_Internalname, ref  A498DocumentacionIcono, ref  A40000DocumentacionIcono_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Documentacion");
               A488DocumentacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDocumentacionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n488DocumentacionId = false;
               AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
               forbiddenHiddens.Add("DocumentacionId", context.localUtil.Format( (decimal)(A488DocumentacionId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A488DocumentacionId != Z488DocumentacionId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("documentacion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A488DocumentacionId = (long)(Math.Round(NumberUtil.Val( GetPar( "DocumentacionId"), "."), 18, MidpointRounding.ToEven));
                  n488DocumentacionId = false;
                  AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
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
                     sMode72 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode72;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound72 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1S0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "DOCUMENTACIONID");
                        AnyError = 1;
                        GX_FocusControl = edtDocumentacionId_Internalname;
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
                           E111S2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121S2 ();
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
            E121S2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1S72( ) ;
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
            DisableAttributes1S72( ) ;
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

      protected void CONFIRM_1S0( )
      {
         BeforeValidate1S72( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1S72( ) ;
            }
            else
            {
               CheckExtendedTable1S72( ) ;
               CloseExtendedTableCursors1S72( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1S0( )
      {
      }

      protected void E111S2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV11WWPContext) ;
         AV8IsAuthorized = true;
         AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWDocumentacion_Insert", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWDocumentacion_Update", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWDocumentacion_Delete", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV13Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E121S2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("documentacionww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1S72( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z489DocumentacionNombre = T001S3_A489DocumentacionNombre[0];
            }
            else
            {
               Z489DocumentacionNombre = A489DocumentacionNombre;
            }
         }
         if ( GX_JID == -3 )
         {
            Z488DocumentacionId = A488DocumentacionId;
            Z489DocumentacionNombre = A489DocumentacionNombre;
            Z498DocumentacionIcono = A498DocumentacionIcono;
            Z40000DocumentacionIcono_GXI = A40000DocumentacionIcono_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         edtDocumentacionId_Enabled = 0;
         AssignProp("", false, edtDocumentacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentacionId_Enabled), 5, 0), true);
         edtDocumentacionId_Enabled = 0;
         AssignProp("", false, edtDocumentacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentacionId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7DocumentacionId) )
         {
            A488DocumentacionId = AV7DocumentacionId;
            n488DocumentacionId = false;
            AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
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
      }

      protected void Load1S72( )
      {
         /* Using cursor T001S4 */
         pr_default.execute(2, new Object[] {n488DocumentacionId, A488DocumentacionId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound72 = 1;
            A489DocumentacionNombre = T001S4_A489DocumentacionNombre[0];
            AssignAttri("", false, "A489DocumentacionNombre", A489DocumentacionNombre);
            A40000DocumentacionIcono_GXI = T001S4_A40000DocumentacionIcono_GXI[0];
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            A498DocumentacionIcono = T001S4_A498DocumentacionIcono[0];
            AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            ZM1S72( -3) ;
         }
         pr_default.close(2);
         OnLoadActions1S72( ) ;
      }

      protected void OnLoadActions1S72( )
      {
         AV13Pgmname = "Documentacion";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable1S72( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV13Pgmname = "Documentacion";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CloseExtendedTableCursors1S72( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1S72( )
      {
         /* Using cursor T001S5 */
         pr_default.execute(3, new Object[] {n488DocumentacionId, A488DocumentacionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound72 = 1;
         }
         else
         {
            RcdFound72 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001S3 */
         pr_default.execute(1, new Object[] {n488DocumentacionId, A488DocumentacionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1S72( 3) ;
            RcdFound72 = 1;
            A488DocumentacionId = T001S3_A488DocumentacionId[0];
            n488DocumentacionId = T001S3_n488DocumentacionId[0];
            AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
            A489DocumentacionNombre = T001S3_A489DocumentacionNombre[0];
            AssignAttri("", false, "A489DocumentacionNombre", A489DocumentacionNombre);
            A40000DocumentacionIcono_GXI = T001S3_A40000DocumentacionIcono_GXI[0];
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            A498DocumentacionIcono = T001S3_A498DocumentacionIcono[0];
            AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            Z488DocumentacionId = A488DocumentacionId;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1S72( ) ;
            if ( AnyError == 1 )
            {
               RcdFound72 = 0;
               InitializeNonKey1S72( ) ;
            }
            Gx_mode = sMode72;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound72 = 0;
            InitializeNonKey1S72( ) ;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode72;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1S72( ) ;
         if ( RcdFound72 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound72 = 0;
         /* Using cursor T001S6 */
         pr_default.execute(4, new Object[] {n488DocumentacionId, A488DocumentacionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T001S6_A488DocumentacionId[0] < A488DocumentacionId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T001S6_A488DocumentacionId[0] > A488DocumentacionId ) ) )
            {
               A488DocumentacionId = T001S6_A488DocumentacionId[0];
               n488DocumentacionId = T001S6_n488DocumentacionId[0];
               AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
               RcdFound72 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound72 = 0;
         /* Using cursor T001S7 */
         pr_default.execute(5, new Object[] {n488DocumentacionId, A488DocumentacionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T001S7_A488DocumentacionId[0] > A488DocumentacionId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T001S7_A488DocumentacionId[0] < A488DocumentacionId ) ) )
            {
               A488DocumentacionId = T001S7_A488DocumentacionId[0];
               n488DocumentacionId = T001S7_n488DocumentacionId[0];
               AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
               RcdFound72 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1S72( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDocumentacionNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1S72( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound72 == 1 )
            {
               if ( A488DocumentacionId != Z488DocumentacionId )
               {
                  A488DocumentacionId = Z488DocumentacionId;
                  n488DocumentacionId = false;
                  AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DOCUMENTACIONID");
                  AnyError = 1;
                  GX_FocusControl = edtDocumentacionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDocumentacionNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1S72( ) ;
                  GX_FocusControl = edtDocumentacionNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A488DocumentacionId != Z488DocumentacionId )
               {
                  /* Insert record */
                  GX_FocusControl = edtDocumentacionNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1S72( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DOCUMENTACIONID");
                     AnyError = 1;
                     GX_FocusControl = edtDocumentacionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtDocumentacionNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1S72( ) ;
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
         if ( A488DocumentacionId != Z488DocumentacionId )
         {
            A488DocumentacionId = Z488DocumentacionId;
            n488DocumentacionId = false;
            AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DOCUMENTACIONID");
            AnyError = 1;
            GX_FocusControl = edtDocumentacionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDocumentacionNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1S72( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001S2 */
            pr_default.execute(0, new Object[] {n488DocumentacionId, A488DocumentacionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Documentacion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z489DocumentacionNombre, T001S2_A489DocumentacionNombre[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z489DocumentacionNombre, T001S2_A489DocumentacionNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("documentacion:[seudo value changed for attri]"+"DocumentacionNombre");
                  GXUtil.WriteLogRaw("Old: ",Z489DocumentacionNombre);
                  GXUtil.WriteLogRaw("Current: ",T001S2_A489DocumentacionNombre[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Documentacion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1S72( )
      {
         BeforeValidate1S72( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1S72( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1S72( 0) ;
            CheckOptimisticConcurrency1S72( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1S72( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1S72( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001S8 */
                     pr_default.execute(6, new Object[] {A489DocumentacionNombre, A498DocumentacionIcono, A40000DocumentacionIcono_GXI});
                     A488DocumentacionId = T001S8_A488DocumentacionId[0];
                     n488DocumentacionId = T001S8_n488DocumentacionId[0];
                     AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Documentacion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1S0( ) ;
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
               Load1S72( ) ;
            }
            EndLevel1S72( ) ;
         }
         CloseExtendedTableCursors1S72( ) ;
      }

      protected void Update1S72( )
      {
         BeforeValidate1S72( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1S72( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1S72( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1S72( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1S72( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001S9 */
                     pr_default.execute(7, new Object[] {A489DocumentacionNombre, n488DocumentacionId, A488DocumentacionId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Documentacion");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Documentacion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1S72( ) ;
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
            EndLevel1S72( ) ;
         }
         CloseExtendedTableCursors1S72( ) ;
      }

      protected void DeferredUpdate1S72( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001S10 */
            pr_default.execute(8, new Object[] {A498DocumentacionIcono, A40000DocumentacionIcono_GXI, n488DocumentacionId, A488DocumentacionId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("Documentacion");
         }
      }

      protected void delete( )
      {
         BeforeValidate1S72( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1S72( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1S72( ) ;
            AfterConfirm1S72( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1S72( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001S11 */
                  pr_default.execute(9, new Object[] {n488DocumentacionId, A488DocumentacionId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Documentacion");
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
         sMode72 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1S72( ) ;
         Gx_mode = sMode72;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1S72( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Documentacion";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001S12 */
            pr_default.execute(10, new Object[] {n488DocumentacionId, A488DocumentacionId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Proveedor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel1S72( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1S72( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("documentacion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1S0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("documentacion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1S72( )
      {
         /* Scan By routine */
         /* Using cursor T001S13 */
         pr_default.execute(11);
         RcdFound72 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound72 = 1;
            A488DocumentacionId = T001S13_A488DocumentacionId[0];
            n488DocumentacionId = T001S13_n488DocumentacionId[0];
            AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1S72( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound72 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound72 = 1;
            A488DocumentacionId = T001S13_A488DocumentacionId[0];
            n488DocumentacionId = T001S13_n488DocumentacionId[0];
            AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
         }
      }

      protected void ScanEnd1S72( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1S72( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1S72( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1S72( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1S72( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1S72( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1S72( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1S72( )
      {
         edtDocumentacionId_Enabled = 0;
         AssignProp("", false, edtDocumentacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentacionId_Enabled), 5, 0), true);
         edtDocumentacionNombre_Enabled = 0;
         AssignProp("", false, edtDocumentacionNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentacionNombre_Enabled), 5, 0), true);
         imgDocumentacionIcono_Enabled = 0;
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgDocumentacionIcono_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1S72( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1S0( )
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
         GXEncryptionTmp = "documentacion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7DocumentacionId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("documentacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Documentacion");
         forbiddenHiddens.Add("DocumentacionId", context.localUtil.Format( (decimal)(A488DocumentacionId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("documentacion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z488DocumentacionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z488DocumentacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z489DocumentacionNombre", StringUtil.RTrim( Z489DocumentacionNombre));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vDOCUMENTACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DocumentacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTACIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7DocumentacionId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DOCUMENTACIONICONO_GXI", A40000DocumentacionIcono_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV13Pgmname));
         GXCCtlgxBlob = "DOCUMENTACIONICONO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A498DocumentacionIcono);
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
         GXEncryptionTmp = "documentacion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7DocumentacionId,18,0));
         return formatLink("documentacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Documentacion" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Documentacion", "") ;
      }

      protected void InitializeNonKey1S72( )
      {
         A489DocumentacionNombre = "";
         AssignAttri("", false, "A489DocumentacionNombre", A489DocumentacionNombre);
         A498DocumentacionIcono = "";
         AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         A40000DocumentacionIcono_GXI = "";
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         Z489DocumentacionNombre = "";
      }

      protected void InitAll1S72( )
      {
         A488DocumentacionId = 0;
         n488DocumentacionId = false;
         AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
         InitializeNonKey1S72( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932072287", true, true, false);
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
         context.AddJavascriptSource("documentacion.js", "?2026932072287", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtDocumentacionId_Internalname = "DOCUMENTACIONID";
         edtDocumentacionNombre_Internalname = "DOCUMENTACIONNOMBRE";
         imgDocumentacionIcono_Internalname = "DOCUMENTACIONICONO";
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
         Form.Caption = context.GetMessage( "Documentacion", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         imgDocumentacionIcono_Enabled = 1;
         edtDocumentacionNombre_Jsonclick = "";
         edtDocumentacionNombre_Enabled = 1;
         edtDocumentacionId_Jsonclick = "";
         edtDocumentacionId_Enabled = 0;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7DocumentacionId',fld:'vDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7DocumentacionId',fld:'vDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A488DocumentacionId',fld:'DOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E121S2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_DOCUMENTACIONID","{handler:'Valid_Documentacionid',iparms:[]");
         setEventMetadata("VALID_DOCUMENTACIONID",",oparms:[]}");
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
         Z489DocumentacionNombre = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A489DocumentacionNombre = "";
         A498DocumentacionIcono = "";
         A40000DocumentacionIcono_GXI = "";
         sImgUrl = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV13Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode72 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV11WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z498DocumentacionIcono = "";
         Z40000DocumentacionIcono_GXI = "";
         T001S4_A488DocumentacionId = new long[1] ;
         T001S4_n488DocumentacionId = new bool[] {false} ;
         T001S4_A489DocumentacionNombre = new string[] {""} ;
         T001S4_A40000DocumentacionIcono_GXI = new string[] {""} ;
         T001S4_A498DocumentacionIcono = new string[] {""} ;
         T001S5_A488DocumentacionId = new long[1] ;
         T001S5_n488DocumentacionId = new bool[] {false} ;
         T001S3_A488DocumentacionId = new long[1] ;
         T001S3_n488DocumentacionId = new bool[] {false} ;
         T001S3_A489DocumentacionNombre = new string[] {""} ;
         T001S3_A40000DocumentacionIcono_GXI = new string[] {""} ;
         T001S3_A498DocumentacionIcono = new string[] {""} ;
         T001S6_A488DocumentacionId = new long[1] ;
         T001S6_n488DocumentacionId = new bool[] {false} ;
         T001S7_A488DocumentacionId = new long[1] ;
         T001S7_n488DocumentacionId = new bool[] {false} ;
         T001S2_A488DocumentacionId = new long[1] ;
         T001S2_n488DocumentacionId = new bool[] {false} ;
         T001S2_A489DocumentacionNombre = new string[] {""} ;
         T001S2_A40000DocumentacionIcono_GXI = new string[] {""} ;
         T001S2_A498DocumentacionIcono = new string[] {""} ;
         T001S8_A488DocumentacionId = new long[1] ;
         T001S8_n488DocumentacionId = new bool[] {false} ;
         T001S12_A133ProveedorID = new long[1] ;
         T001S13_A488DocumentacionId = new long[1] ;
         T001S13_n488DocumentacionId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.documentacion__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentacion__default(),
            new Object[][] {
                new Object[] {
               T001S2_A488DocumentacionId, T001S2_A489DocumentacionNombre, T001S2_A40000DocumentacionIcono_GXI, T001S2_A498DocumentacionIcono
               }
               , new Object[] {
               T001S3_A488DocumentacionId, T001S3_A489DocumentacionNombre, T001S3_A40000DocumentacionIcono_GXI, T001S3_A498DocumentacionIcono
               }
               , new Object[] {
               T001S4_A488DocumentacionId, T001S4_A489DocumentacionNombre, T001S4_A40000DocumentacionIcono_GXI, T001S4_A498DocumentacionIcono
               }
               , new Object[] {
               T001S5_A488DocumentacionId
               }
               , new Object[] {
               T001S6_A488DocumentacionId
               }
               , new Object[] {
               T001S7_A488DocumentacionId
               }
               , new Object[] {
               T001S8_A488DocumentacionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001S12_A133ProveedorID
               }
               , new Object[] {
               T001S13_A488DocumentacionId
               }
            }
         );
         AV13Pgmname = "Documentacion";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound72 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtDocumentacionId_Enabled ;
      private int edtDocumentacionNombre_Enabled ;
      private int imgDocumentacionIcono_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long wcpOAV7DocumentacionId ;
      private long Z488DocumentacionId ;
      private long AV7DocumentacionId ;
      private long A488DocumentacionId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z489DocumentacionNombre ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtDocumentacionNombre_Internalname ;
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
      private string edtDocumentacionId_Internalname ;
      private string TempTags ;
      private string edtDocumentacionId_Jsonclick ;
      private string A489DocumentacionNombre ;
      private string edtDocumentacionNombre_Jsonclick ;
      private string imgDocumentacionIcono_Internalname ;
      private string sImgUrl ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV13Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode72 ;
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
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A498DocumentacionIcono_IsBlob ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n488DocumentacionId ;
      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private string A40000DocumentacionIcono_GXI ;
      private string Z40000DocumentacionIcono_GXI ;
      private string A498DocumentacionIcono ;
      private string Z498DocumentacionIcono ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV11WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] T001S4_A488DocumentacionId ;
      private bool[] T001S4_n488DocumentacionId ;
      private string[] T001S4_A489DocumentacionNombre ;
      private string[] T001S4_A40000DocumentacionIcono_GXI ;
      private string[] T001S4_A498DocumentacionIcono ;
      private long[] T001S5_A488DocumentacionId ;
      private bool[] T001S5_n488DocumentacionId ;
      private long[] T001S3_A488DocumentacionId ;
      private bool[] T001S3_n488DocumentacionId ;
      private string[] T001S3_A489DocumentacionNombre ;
      private string[] T001S3_A40000DocumentacionIcono_GXI ;
      private string[] T001S3_A498DocumentacionIcono ;
      private long[] T001S6_A488DocumentacionId ;
      private bool[] T001S6_n488DocumentacionId ;
      private long[] T001S7_A488DocumentacionId ;
      private bool[] T001S7_n488DocumentacionId ;
      private long[] T001S2_A488DocumentacionId ;
      private bool[] T001S2_n488DocumentacionId ;
      private string[] T001S2_A489DocumentacionNombre ;
      private string[] T001S2_A40000DocumentacionIcono_GXI ;
      private string[] T001S2_A498DocumentacionIcono ;
      private long[] T001S8_A488DocumentacionId ;
      private bool[] T001S8_n488DocumentacionId ;
      private long[] T001S12_A133ProveedorID ;
      private long[] T001S13_A488DocumentacionId ;
      private bool[] T001S13_n488DocumentacionId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class documentacion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class documentacion__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT001S2;
        prmT001S2 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001S3;
        prmT001S3 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001S4;
        prmT001S4 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001S5;
        prmT001S5 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001S6;
        prmT001S6 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001S7;
        prmT001S7 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001S8;
        prmT001S8 = new Object[] {
        new ParDef("@DocumentacionNombre",GXType.NChar,80,0) ,
        new ParDef("@DocumentacionIcono",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@DocumentacionIcono_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Documentacion", Fld="DocumentacionIcono"}
        };
        Object[] prmT001S9;
        prmT001S9 = new Object[] {
        new ParDef("@DocumentacionNombre",GXType.NChar,80,0) ,
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001S10;
        prmT001S10 = new Object[] {
        new ParDef("@DocumentacionIcono",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@DocumentacionIcono_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Documentacion", Fld="DocumentacionIcono"} ,
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001S11;
        prmT001S11 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001S12;
        prmT001S12 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001S13;
        prmT001S13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001S2", "SELECT [DocumentacionId], [DocumentacionNombre], [DocumentacionIcono_GXI], [DocumentacionIcono] FROM [Documentacion] WITH (UPDLOCK) WHERE [DocumentacionId] = @DocumentacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001S3", "SELECT [DocumentacionId], [DocumentacionNombre], [DocumentacionIcono_GXI], [DocumentacionIcono] FROM [Documentacion] WHERE [DocumentacionId] = @DocumentacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001S4", "SELECT TM1.[DocumentacionId], TM1.[DocumentacionNombre], TM1.[DocumentacionIcono_GXI], TM1.[DocumentacionIcono] FROM [Documentacion] TM1 WHERE TM1.[DocumentacionId] = @DocumentacionId ORDER BY TM1.[DocumentacionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001S4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001S5", "SELECT [DocumentacionId] FROM [Documentacion] WHERE [DocumentacionId] = @DocumentacionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001S5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001S6", "SELECT TOP 1 [DocumentacionId] FROM [Documentacion] WHERE ( [DocumentacionId] > @DocumentacionId) ORDER BY [DocumentacionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001S6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001S7", "SELECT TOP 1 [DocumentacionId] FROM [Documentacion] WHERE ( [DocumentacionId] < @DocumentacionId) ORDER BY [DocumentacionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001S7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001S8", "INSERT INTO [Documentacion]([DocumentacionNombre], [DocumentacionIcono], [DocumentacionIcono_GXI]) VALUES(@DocumentacionNombre, @DocumentacionIcono, @DocumentacionIcono_GXI); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001S8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001S9", "UPDATE [Documentacion] SET [DocumentacionNombre]=@DocumentacionNombre  WHERE [DocumentacionId] = @DocumentacionId", GxErrorMask.GX_NOMASK,prmT001S9)
           ,new CursorDef("T001S10", "UPDATE [Documentacion] SET [DocumentacionIcono]=@DocumentacionIcono, [DocumentacionIcono_GXI]=@DocumentacionIcono_GXI  WHERE [DocumentacionId] = @DocumentacionId", GxErrorMask.GX_NOMASK,prmT001S10)
           ,new CursorDef("T001S11", "DELETE FROM [Documentacion]  WHERE [DocumentacionId] = @DocumentacionId", GxErrorMask.GX_NOMASK,prmT001S11)
           ,new CursorDef("T001S12", "SELECT TOP 1 [ProveedorID] FROM [Proveedor] WHERE [DocumentacionId] = @DocumentacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001S13", "SELECT [DocumentacionId] FROM [Documentacion] ORDER BY [DocumentacionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001S13,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
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
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
