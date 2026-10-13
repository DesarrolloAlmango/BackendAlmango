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
   public class pais : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A118MonedaId = (short)(Math.Round(NumberUtil.Val( GetPar( "MonedaId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A118MonedaId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_moneda") == 0 )
         {
            gxnrGridlevel_moneda_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "pais.aspx")), "pais.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "pais.aspx")))) ;
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
                  AV7PaisID = GetPar( "PaisID");
                  AssignAttri("", false, "AV7PaisID", AV7PaisID);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPAISID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7PaisID, "")), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Pais", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_moneda_newrow_invoke( )
      {
         nRC_GXsfl_38 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_38"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_38_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_38_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_38_idx = GetPar( "sGXsfl_38_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_moneda_newrow( ) ;
         /* End function gxnrGridlevel_moneda_newrow_invoke */
      }

      public pais( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pais( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_PaisID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PaisID = aP1_PaisID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynMonedaId = new GXCombobox();
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisID_Internalname, context.GetMessage( "Pais", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.RTrim( A116PaisID), StringUtil.RTrim( context.localUtil.Format( A116PaisID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPaisID_Enabled, 1, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Pais.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisNombre_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisNombre_Internalname, StringUtil.RTrim( A165PaisNombre), StringUtil.RTrim( context.localUtil.Format( A165PaisNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPaisNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Pais.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgPaisBandera_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A207PaisBandera_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000PaisBandera_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.PathToRelativeUrl( A207PaisBandera));
         GxWebStd.gx_bitmap( context, imgPaisBandera_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgPaisBandera_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", "", "", 0, A207PaisBandera_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_Pais.htm");
         AssignProp("", false, imgPaisBandera_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.PathToRelativeUrl( A207PaisBandera)), true);
         AssignProp("", false, imgPaisBandera_Internalname, "IsBlob", StringUtil.BoolToStr( A207PaisBandera_IsBlob), true);
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
         GxWebStd.gx_div_start( context, divTableleaflevel_moneda_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_moneda( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pais.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pais.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pais.htm");
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

      protected void gxdraw_Gridlevel_moneda( )
      {
         /*  Grid Control  */
         StartGridControl38( ) ;
         nGXsfl_38_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount125 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_125 = 1;
               ScanStart0Y125( ) ;
               while ( RcdFound125 != 0 )
               {
                  init_level_properties125( ) ;
                  getByPrimaryKey0Y125( ) ;
                  AddRow0Y125( ) ;
                  ScanNext0Y125( ) ;
               }
               ScanEnd0Y125( ) ;
               nBlankRcdCount125 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0Y125( ) ;
            standaloneModal0Y125( ) ;
            sMode125 = Gx_mode;
            while ( nGXsfl_38_idx < nRC_GXsfl_38 )
            {
               bGXsfl_38_Refreshing = true;
               ReadRow0Y125( ) ;
               dynMonedaId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MONEDAID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtMonedaNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MONEDANOMBRE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtMonedaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonedaNombre_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtMonedaISOSimbolo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MONEDAISOSIMBOLO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtMonedaISOSimbolo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonedaISOSimbolo_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               if ( ( nRcdExists_125 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0Y125( ) ;
               }
               SendRow0Y125( ) ;
               bGXsfl_38_Refreshing = false;
            }
            Gx_mode = sMode125;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount125 = 5;
            nRcdExists_125 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0Y125( ) ;
               while ( RcdFound125 != 0 )
               {
                  sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_38125( ) ;
                  init_level_properties125( ) ;
                  standaloneNotModal0Y125( ) ;
                  getByPrimaryKey0Y125( ) ;
                  standaloneModal0Y125( ) ;
                  AddRow0Y125( ) ;
                  ScanNext0Y125( ) ;
               }
               ScanEnd0Y125( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode125 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx+1), 4, 0), 4, "0");
            SubsflControlProps_38125( ) ;
            InitAll0Y125( ) ;
            init_level_properties125( ) ;
            nRcdExists_125 = 0;
            nIsMod_125 = 0;
            nRcdDeleted_125 = 0;
            nBlankRcdCount125 = (short)(nBlankRcdUsr125+nBlankRcdCount125);
            fRowAdded = 0;
            while ( nBlankRcdCount125 > 0 )
            {
               standaloneNotModal0Y125( ) ;
               standaloneModal0Y125( ) ;
               AddRow0Y125( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = dynMonedaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount125 = (short)(nBlankRcdCount125-1);
            }
            Gx_mode = sMode125;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_monedaContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_moneda", Gridlevel_monedaContainer, subGridlevel_moneda_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_monedaContainerData", Gridlevel_monedaContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_monedaContainerData"+"V", Gridlevel_monedaContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_monedaContainerData"+"V"+"\" value='"+Gridlevel_monedaContainer.GridValuesHidden()+"'/>") ;
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
         E110Y2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z116PaisID = cgiGet( "Z116PaisID");
               Z165PaisNombre = cgiGet( "Z165PaisNombre");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_38 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_38"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7PaisID = cgiGet( "vPAISID");
               A40000PaisBandera_GXI = cgiGet( "PAISBANDERA_GXI");
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
               A116PaisID = cgiGet( edtPaisID_Internalname);
               AssignAttri("", false, "A116PaisID", A116PaisID);
               A165PaisNombre = cgiGet( edtPaisNombre_Internalname);
               AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
               A207PaisBandera = cgiGet( imgPaisBandera_Internalname);
               AssignAttri("", false, "A207PaisBandera", A207PaisBandera);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgPaisBandera_Internalname, ref  A207PaisBandera, ref  A40000PaisBandera_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Pais");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A116PaisID, Z116PaisID) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("pais:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A116PaisID = GetPar( "PaisID");
                  AssignAttri("", false, "A116PaisID", A116PaisID);
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
                     sMode39 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode39;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound39 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0Y0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PAISID");
                        AnyError = 1;
                        GX_FocusControl = edtPaisID_Internalname;
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
                           E110Y2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120Y2 ();
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
            E120Y2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0Y39( ) ;
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
            DisableAttributes0Y39( ) ;
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

      protected void CONFIRM_0Y0( )
      {
         BeforeValidate0Y39( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Y39( ) ;
            }
            else
            {
               CheckExtendedTable0Y39( ) ;
               CloseExtendedTableCursors0Y39( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode39 = Gx_mode;
            CONFIRM_0Y125( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode39;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode39;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0Y125( )
      {
         nGXsfl_38_idx = 0;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            ReadRow0Y125( ) ;
            if ( ( nRcdExists_125 != 0 ) || ( nIsMod_125 != 0 ) )
            {
               GetKey0Y125( ) ;
               if ( ( nRcdExists_125 == 0 ) && ( nRcdDeleted_125 == 0 ) )
               {
                  if ( RcdFound125 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0Y125( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Y125( ) ;
                        CloseExtendedTableCursors0Y125( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "MONEDAID_" + sGXsfl_38_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = dynMonedaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound125 != 0 )
                  {
                     if ( nRcdDeleted_125 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0Y125( ) ;
                        Load0Y125( ) ;
                        BeforeValidate0Y125( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Y125( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_125 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0Y125( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Y125( ) ;
                              CloseExtendedTableCursors0Y125( ) ;
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
                     if ( nRcdDeleted_125 == 0 )
                     {
                        GXCCtl = "MONEDAID_" + sGXsfl_38_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = dynMonedaId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( dynMonedaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", ""))) ;
            ChangePostValue( edtMonedaNombre_Internalname, StringUtil.RTrim( A187MonedaNombre)) ;
            ChangePostValue( edtMonedaISOSimbolo_Internalname, StringUtil.RTrim( A119MonedaISOSimbolo)) ;
            ChangePostValue( "ZT_"+"Z118MonedaId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_125_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_125), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_125_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_125), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_125_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_125), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_125 != 0 )
            {
               ChangePostValue( "MONEDAID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMonedaId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MONEDANOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMonedaNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MONEDAISOSIMBOLO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMonedaISOSimbolo_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0Y0( )
      {
      }

      protected void E110Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV12WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPais_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPais_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPais_Delete", out  GXt_boolean1) ;
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
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E120Y2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("paisww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0Y39( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z165PaisNombre = T000Y6_A165PaisNombre[0];
            }
            else
            {
               Z165PaisNombre = A165PaisNombre;
            }
         }
         if ( GX_JID == -4 )
         {
            Z116PaisID = A116PaisID;
            Z165PaisNombre = A165PaisNombre;
            Z207PaisBandera = A207PaisBandera;
            Z40000PaisBandera_GXI = A40000PaisBandera_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7PaisID)) )
         {
            A116PaisID = AV7PaisID;
            AssignAttri("", false, "A116PaisID", A116PaisID);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7PaisID)) )
         {
            edtPaisID_Enabled = 0;
            AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         }
         else
         {
            edtPaisID_Enabled = 1;
            AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7PaisID)) )
         {
            edtPaisID_Enabled = 0;
            AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
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
            AV14Pgmname = "Pais";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         }
      }

      protected void Load0Y39( )
      {
         /* Using cursor T000Y7 */
         pr_default.execute(5, new Object[] {A116PaisID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound39 = 1;
            A165PaisNombre = T000Y7_A165PaisNombre[0];
            AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
            A40000PaisBandera_GXI = T000Y7_A40000PaisBandera_GXI[0];
            AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
            AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
            A207PaisBandera = T000Y7_A207PaisBandera[0];
            AssignAttri("", false, "A207PaisBandera", A207PaisBandera);
            AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
            AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
            ZM0Y39( -4) ;
         }
         pr_default.close(5);
         OnLoadActions0Y39( ) ;
      }

      protected void OnLoadActions0Y39( )
      {
         AV14Pgmname = "Pais";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable0Y39( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV14Pgmname = "Pais";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CloseExtendedTableCursors0Y39( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Y39( )
      {
         /* Using cursor T000Y8 */
         pr_default.execute(6, new Object[] {A116PaisID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound39 = 1;
         }
         else
         {
            RcdFound39 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Y6 */
         pr_default.execute(4, new Object[] {A116PaisID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0Y39( 4) ;
            RcdFound39 = 1;
            A116PaisID = T000Y6_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
            A165PaisNombre = T000Y6_A165PaisNombre[0];
            AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
            A40000PaisBandera_GXI = T000Y6_A40000PaisBandera_GXI[0];
            AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
            AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
            A207PaisBandera = T000Y6_A207PaisBandera[0];
            AssignAttri("", false, "A207PaisBandera", A207PaisBandera);
            AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
            AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
            Z116PaisID = A116PaisID;
            sMode39 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Y39( ) ;
            if ( AnyError == 1 )
            {
               RcdFound39 = 0;
               InitializeNonKey0Y39( ) ;
            }
            Gx_mode = sMode39;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound39 = 0;
            InitializeNonKey0Y39( ) ;
            sMode39 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode39;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Y39( ) ;
         if ( RcdFound39 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound39 = 0;
         /* Using cursor T000Y9 */
         pr_default.execute(7, new Object[] {A116PaisID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T000Y9_A116PaisID[0], A116PaisID) < 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T000Y9_A116PaisID[0], A116PaisID) > 0 ) ) )
            {
               A116PaisID = T000Y9_A116PaisID[0];
               AssignAttri("", false, "A116PaisID", A116PaisID);
               RcdFound39 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound39 = 0;
         /* Using cursor T000Y10 */
         pr_default.execute(8, new Object[] {A116PaisID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000Y10_A116PaisID[0], A116PaisID) > 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000Y10_A116PaisID[0], A116PaisID) < 0 ) ) )
            {
               A116PaisID = T000Y10_A116PaisID[0];
               AssignAttri("", false, "A116PaisID", A116PaisID);
               RcdFound39 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Y39( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Y39( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound39 == 1 )
            {
               if ( StringUtil.StrCmp(A116PaisID, Z116PaisID) != 0 )
               {
                  A116PaisID = Z116PaisID;
                  AssignAttri("", false, "A116PaisID", A116PaisID);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PAISID");
                  AnyError = 1;
                  GX_FocusControl = edtPaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0Y39( ) ;
                  GX_FocusControl = edtPaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A116PaisID, Z116PaisID) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtPaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Y39( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAISID");
                     AnyError = 1;
                     GX_FocusControl = edtPaisID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPaisID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0Y39( ) ;
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
         if ( StringUtil.StrCmp(A116PaisID, Z116PaisID) != 0 )
         {
            A116PaisID = Z116PaisID;
            AssignAttri("", false, "A116PaisID", A116PaisID);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0Y39( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Y5 */
            pr_default.execute(3, new Object[] {A116PaisID});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Pais"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z165PaisNombre, T000Y5_A165PaisNombre[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z165PaisNombre, T000Y5_A165PaisNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("pais:[seudo value changed for attri]"+"PaisNombre");
                  GXUtil.WriteLogRaw("Old: ",Z165PaisNombre);
                  GXUtil.WriteLogRaw("Current: ",T000Y5_A165PaisNombre[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Pais"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Y39( )
      {
         BeforeValidate0Y39( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y39( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Y39( 0) ;
            CheckOptimisticConcurrency0Y39( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y39( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Y39( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y11 */
                     pr_default.execute(9, new Object[] {A116PaisID, A165PaisNombre, A207PaisBandera, A40000PaisBandera_GXI});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Pais");
                     if ( (pr_default.getStatus(9) == 1) )
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
                           ProcessLevel0Y39( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0Y0( ) ;
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
               Load0Y39( ) ;
            }
            EndLevel0Y39( ) ;
         }
         CloseExtendedTableCursors0Y39( ) ;
      }

      protected void Update0Y39( )
      {
         BeforeValidate0Y39( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y39( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y39( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y39( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Y39( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y12 */
                     pr_default.execute(10, new Object[] {A165PaisNombre, A116PaisID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Pais");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Pais"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Y39( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0Y39( ) ;
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
            EndLevel0Y39( ) ;
         }
         CloseExtendedTableCursors0Y39( ) ;
      }

      protected void DeferredUpdate0Y39( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000Y13 */
            pr_default.execute(11, new Object[] {A207PaisBandera, A40000PaisBandera_GXI, A116PaisID});
            pr_default.close(11);
            pr_default.SmartCacheProvider.SetUpdated("Pais");
         }
      }

      protected void delete( )
      {
         BeforeValidate0Y39( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y39( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Y39( ) ;
            AfterConfirm0Y39( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Y39( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0Y125( ) ;
                  while ( RcdFound125 != 0 )
                  {
                     getByPrimaryKey0Y125( ) ;
                     Delete0Y125( ) ;
                     ScanNext0Y125( ) ;
                  }
                  ScanEnd0Y125( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y14 */
                     pr_default.execute(12, new Object[] {A116PaisID});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Pais");
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
         sMode39 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Y39( ) ;
         Gx_mode = sMode39;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Y39( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "Pais";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000Y15 */
            pr_default.execute(13, new Object[] {A116PaisID});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "usuarios", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000Y16 */
            pr_default.execute(14, new Object[] {A116PaisID});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Departamento", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000Y17 */
            pr_default.execute(15, new Object[] {A116PaisID});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Ciudad", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void ProcessNestedLevel0Y125( )
      {
         nGXsfl_38_idx = 0;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            ReadRow0Y125( ) ;
            if ( ( nRcdExists_125 != 0 ) || ( nIsMod_125 != 0 ) )
            {
               standaloneNotModal0Y125( ) ;
               GetKey0Y125( ) ;
               if ( ( nRcdExists_125 == 0 ) && ( nRcdDeleted_125 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0Y125( ) ;
               }
               else
               {
                  if ( RcdFound125 != 0 )
                  {
                     if ( ( nRcdDeleted_125 != 0 ) && ( nRcdExists_125 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0Y125( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_125 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0Y125( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_125 == 0 )
                     {
                        GXCCtl = "MONEDAID_" + sGXsfl_38_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = dynMonedaId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( dynMonedaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", ""))) ;
            ChangePostValue( edtMonedaNombre_Internalname, StringUtil.RTrim( A187MonedaNombre)) ;
            ChangePostValue( edtMonedaISOSimbolo_Internalname, StringUtil.RTrim( A119MonedaISOSimbolo)) ;
            ChangePostValue( "ZT_"+"Z118MonedaId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_125_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_125), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_125_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_125), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_125_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_125), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_125 != 0 )
            {
               ChangePostValue( "MONEDAID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMonedaId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MONEDANOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMonedaNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MONEDAISOSIMBOLO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMonedaISOSimbolo_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Y125( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_125 = 0;
         nIsMod_125 = 0;
         nRcdDeleted_125 = 0;
      }

      protected void ProcessLevel0Y39( )
      {
         /* Save parent mode. */
         sMode39 = Gx_mode;
         ProcessNestedLevel0Y125( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode39;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0Y39( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Y39( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("pais",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0Y0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("pais",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Y39( )
      {
         /* Scan By routine */
         /* Using cursor T000Y18 */
         pr_default.execute(16);
         RcdFound39 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound39 = 1;
            A116PaisID = T000Y18_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Y39( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound39 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound39 = 1;
            A116PaisID = T000Y18_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
         }
      }

      protected void ScanEnd0Y39( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm0Y39( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Y39( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Y39( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Y39( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Y39( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Y39( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Y39( )
      {
         edtPaisID_Enabled = 0;
         AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         edtPaisNombre_Enabled = 0;
         AssignProp("", false, edtPaisNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisNombre_Enabled), 5, 0), true);
         imgPaisBandera_Enabled = 0;
         AssignProp("", false, imgPaisBandera_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgPaisBandera_Enabled), 5, 0), true);
      }

      protected void ZM0Y125( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -5 )
         {
            Z116PaisID = A116PaisID;
            Z118MonedaId = A118MonedaId;
            Z187MonedaNombre = A187MonedaNombre;
            Z119MonedaISOSimbolo = A119MonedaISOSimbolo;
         }
      }

      protected void standaloneNotModal0Y125( )
      {
      }

      protected void standaloneModal0Y125( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            dynMonedaId.Enabled = 0;
            AssignProp("", false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
         else
         {
            dynMonedaId.Enabled = 1;
            AssignProp("", false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
      }

      protected void Load0Y125( )
      {
         /* Using cursor T000Y19 */
         pr_default.execute(17, new Object[] {A116PaisID, A118MonedaId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound125 = 1;
            A187MonedaNombre = T000Y19_A187MonedaNombre[0];
            A119MonedaISOSimbolo = T000Y19_A119MonedaISOSimbolo[0];
            ZM0Y125( -5) ;
         }
         pr_default.close(17);
         OnLoadActions0Y125( ) ;
      }

      protected void OnLoadActions0Y125( )
      {
      }

      protected void CheckExtendedTable0Y125( )
      {
         nIsDirty_125 = 0;
         Gx_BScreen = 1;
         standaloneModal0Y125( ) ;
         /* Using cursor T000Y4 */
         pr_default.execute(2, new Object[] {A118MonedaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "MONEDAID_" + sGXsfl_38_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( " T12", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynMonedaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A187MonedaNombre = T000Y4_A187MonedaNombre[0];
         A119MonedaISOSimbolo = T000Y4_A119MonedaISOSimbolo[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0Y125( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0Y125( )
      {
      }

      protected void gxLoad_6( short A118MonedaId )
      {
         /* Using cursor T000Y20 */
         pr_default.execute(18, new Object[] {A118MonedaId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GXCCtl = "MONEDAID_" + sGXsfl_38_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( " T12", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynMonedaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A187MonedaNombre = T000Y20_A187MonedaNombre[0];
         A119MonedaISOSimbolo = T000Y20_A119MonedaISOSimbolo[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A187MonedaNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A119MonedaISOSimbolo))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void GetKey0Y125( )
      {
         /* Using cursor T000Y21 */
         pr_default.execute(19, new Object[] {A116PaisID, A118MonedaId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound125 = 1;
         }
         else
         {
            RcdFound125 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey0Y125( )
      {
         /* Using cursor T000Y3 */
         pr_default.execute(1, new Object[] {A116PaisID, A118MonedaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Y125( 5) ;
            RcdFound125 = 1;
            InitializeNonKey0Y125( ) ;
            A118MonedaId = T000Y3_A118MonedaId[0];
            Z116PaisID = A116PaisID;
            Z118MonedaId = A118MonedaId;
            sMode125 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Y125( ) ;
            Gx_mode = sMode125;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound125 = 0;
            InitializeNonKey0Y125( ) ;
            sMode125 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0Y125( ) ;
            Gx_mode = sMode125;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Y125( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0Y125( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Y2 */
            pr_default.execute(0, new Object[] {A116PaisID, A118MonedaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PaisMoneda"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PaisMoneda"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Y125( )
      {
         BeforeValidate0Y125( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y125( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Y125( 0) ;
            CheckOptimisticConcurrency0Y125( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y125( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Y125( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y22 */
                     pr_default.execute(20, new Object[] {A116PaisID, A118MonedaId});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("PaisMoneda");
                     if ( (pr_default.getStatus(20) == 1) )
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
               Load0Y125( ) ;
            }
            EndLevel0Y125( ) ;
         }
         CloseExtendedTableCursors0Y125( ) ;
      }

      protected void Update0Y125( )
      {
         BeforeValidate0Y125( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y125( ) ;
         }
         if ( ( nIsMod_125 != 0 ) || ( nIsDirty_125 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0Y125( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0Y125( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0Y125( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [PaisMoneda] */
                        DeferredUpdate0Y125( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0Y125( ) ;
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
               EndLevel0Y125( ) ;
            }
         }
         CloseExtendedTableCursors0Y125( ) ;
      }

      protected void DeferredUpdate0Y125( )
      {
      }

      protected void Delete0Y125( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Y125( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y125( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Y125( ) ;
            AfterConfirm0Y125( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Y125( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Y23 */
                  pr_default.execute(21, new Object[] {A116PaisID, A118MonedaId});
                  pr_default.close(21);
                  pr_default.SmartCacheProvider.SetUpdated("PaisMoneda");
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
         sMode125 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Y125( ) ;
         Gx_mode = sMode125;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Y125( )
      {
         standaloneModal0Y125( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000Y24 */
            pr_default.execute(22, new Object[] {A118MonedaId});
            A187MonedaNombre = T000Y24_A187MonedaNombre[0];
            A119MonedaISOSimbolo = T000Y24_A119MonedaISOSimbolo[0];
            pr_default.close(22);
         }
      }

      protected void EndLevel0Y125( )
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

      public void ScanStart0Y125( )
      {
         /* Scan By routine */
         /* Using cursor T000Y25 */
         pr_default.execute(23, new Object[] {A116PaisID});
         RcdFound125 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound125 = 1;
            A118MonedaId = T000Y25_A118MonedaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Y125( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound125 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound125 = 1;
            A118MonedaId = T000Y25_A118MonedaId[0];
         }
      }

      protected void ScanEnd0Y125( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm0Y125( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Y125( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Y125( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Y125( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Y125( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Y125( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Y125( )
      {
         dynMonedaId.Enabled = 0;
         AssignProp("", false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtMonedaNombre_Enabled = 0;
         AssignProp("", false, edtMonedaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonedaNombre_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtMonedaISOSimbolo_Enabled = 0;
         AssignProp("", false, edtMonedaISOSimbolo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonedaISOSimbolo_Enabled), 5, 0), !bGXsfl_38_Refreshing);
      }

      protected void send_integrity_lvl_hashes0Y125( )
      {
      }

      protected void send_integrity_lvl_hashes0Y39( )
      {
      }

      protected void SubsflControlProps_38125( )
      {
         dynMonedaId_Internalname = "MONEDAID_"+sGXsfl_38_idx;
         edtMonedaNombre_Internalname = "MONEDANOMBRE_"+sGXsfl_38_idx;
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO_"+sGXsfl_38_idx;
      }

      protected void SubsflControlProps_fel_38125( )
      {
         dynMonedaId_Internalname = "MONEDAID_"+sGXsfl_38_fel_idx;
         edtMonedaNombre_Internalname = "MONEDANOMBRE_"+sGXsfl_38_fel_idx;
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO_"+sGXsfl_38_fel_idx;
      }

      protected void AddRow0Y125( )
      {
         nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_38125( ) ;
         SendRow0Y125( ) ;
      }

      protected void SendRow0Y125( )
      {
         Gridlevel_monedaRow = GXWebRow.GetNew(context);
         if ( subGridlevel_moneda_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_moneda_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_moneda_Class, "") != 0 )
            {
               subGridlevel_moneda_Linesclass = subGridlevel_moneda_Class+"Odd";
            }
         }
         else if ( subGridlevel_moneda_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_moneda_Backstyle = 0;
            subGridlevel_moneda_Backcolor = subGridlevel_moneda_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_moneda_Class, "") != 0 )
            {
               subGridlevel_moneda_Linesclass = subGridlevel_moneda_Class+"Uniform";
            }
         }
         else if ( subGridlevel_moneda_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_moneda_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_moneda_Class, "") != 0 )
            {
               subGridlevel_moneda_Linesclass = subGridlevel_moneda_Class+"Odd";
            }
            subGridlevel_moneda_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_moneda_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_moneda_Backstyle = 1;
            if ( ((int)((nGXsfl_38_idx) % (2))) == 0 )
            {
               subGridlevel_moneda_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_moneda_Class, "") != 0 )
               {
                  subGridlevel_moneda_Linesclass = subGridlevel_moneda_Class+"Even";
               }
            }
            else
            {
               subGridlevel_moneda_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_moneda_Class, "") != 0 )
               {
                  subGridlevel_moneda_Linesclass = subGridlevel_moneda_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_125_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_38_idx + "',38)\"";
         GXCCtl = "MONEDAID_" + sGXsfl_38_idx;
         dynMonedaId.Name = GXCCtl;
         dynMonedaId.WebTags = "";
         dynMonedaId.removeAllItems();
         /* Using cursor T000Y26 */
         pr_default.execute(24);
         while ( (pr_default.getStatus(24) != 101) )
         {
            dynMonedaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000Y26_A118MonedaId[0]), 4, 0)), T000Y26_A119MonedaISOSimbolo[0], 0);
            pr_default.readNext(24);
         }
         pr_default.close(24);
         if ( dynMonedaId.ItemCount > 0 )
         {
            A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         /* ComboBox */
         Gridlevel_monedaRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynMonedaId,(string)dynMonedaId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0)),(short)1,(string)dynMonedaId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynMonedaId.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"",(string)"",(bool)true,(short)0});
         dynMonedaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0));
         AssignProp("", false, dynMonedaId_Internalname, "Values", (string)(dynMonedaId.ToJavascriptSource()), !bGXsfl_38_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_125_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_monedaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMonedaNombre_Internalname,StringUtil.RTrim( A187MonedaNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMonedaNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtMonedaNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_125_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_monedaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMonedaISOSimbolo_Internalname,StringUtil.RTrim( A119MonedaISOSimbolo),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMonedaISOSimbolo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtMonedaISOSimbolo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"MonISO",(string)"start",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_monedaRow);
         send_integrity_lvl_hashes0Y125( ) ;
         GXCCtl = "Z118MonedaId_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_125_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_125), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_125_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_125), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_125_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_125), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_38_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV10TrnContext);
         }
         GXCCtl = "vPAISID_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( AV7PaisID));
         GxWebStd.gx_hidden_field( context, "MONEDAID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMonedaId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MONEDANOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMonedaNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MONEDAISOSIMBOLO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMonedaISOSimbolo_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_monedaContainer.AddRow(Gridlevel_monedaRow);
      }

      protected void ReadRow0Y125( )
      {
         nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_38125( ) ;
         dynMonedaId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MONEDAID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtMonedaNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MONEDANOMBRE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtMonedaISOSimbolo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MONEDAISOSIMBOLO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynMonedaId.Name = dynMonedaId_Internalname;
         dynMonedaId.CurrentValue = cgiGet( dynMonedaId_Internalname);
         A118MonedaId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynMonedaId_Internalname), "."), 18, MidpointRounding.ToEven));
         A187MonedaNombre = cgiGet( edtMonedaNombre_Internalname);
         A119MonedaISOSimbolo = cgiGet( edtMonedaISOSimbolo_Internalname);
         GXCCtl = "Z118MonedaId_" + sGXsfl_38_idx;
         Z118MonedaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_125_" + sGXsfl_38_idx;
         nRcdDeleted_125 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_125_" + sGXsfl_38_idx;
         nRcdExists_125 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_125_" + sGXsfl_38_idx;
         nIsMod_125 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defdynMonedaId_Enabled = dynMonedaId.Enabled;
      }

      protected void ConfirmValues0Y0( )
      {
         nGXsfl_38_idx = 0;
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_38125( ) ;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_38125( ) ;
            ChangePostValue( "Z118MonedaId_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z118MonedaId_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z118MonedaId_"+sGXsfl_38_idx) ;
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
         GXEncryptionTmp = "pais.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7PaisID));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("pais.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Pais");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("pais:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z116PaisID", StringUtil.RTrim( Z116PaisID));
         GxWebStd.gx_hidden_field( context, "Z165PaisNombre", StringUtil.RTrim( Z165PaisNombre));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_38", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_38_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPAISID", StringUtil.RTrim( AV7PaisID));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAISID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7PaisID, "")), context));
         GxWebStd.gx_hidden_field( context, "PAISBANDERA_GXI", A40000PaisBandera_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
         GXCCtlgxBlob = "PAISBANDERA" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A207PaisBandera);
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
         GXEncryptionTmp = "pais.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7PaisID));
         return formatLink("pais.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Pais" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Pais", "") ;
      }

      protected void InitializeNonKey0Y39( )
      {
         A165PaisNombre = "";
         AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
         A207PaisBandera = "";
         AssignAttri("", false, "A207PaisBandera", A207PaisBandera);
         AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
         AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
         A40000PaisBandera_GXI = "";
         AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
         AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
         Z165PaisNombre = "";
      }

      protected void InitAll0Y39( )
      {
         A116PaisID = "";
         AssignAttri("", false, "A116PaisID", A116PaisID);
         InitializeNonKey0Y39( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0Y125( )
      {
         A187MonedaNombre = "";
         A119MonedaISOSimbolo = "";
      }

      protected void InitAll0Y125( )
      {
         A118MonedaId = 0;
         InitializeNonKey0Y125( ) ;
      }

      protected void StandaloneModalInsert0Y125( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202693202165", true, true, false);
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
         context.AddJavascriptSource("pais.js", "?202693202167", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties125( )
      {
         dynMonedaId.Enabled = defdynMonedaId_Enabled;
         AssignProp("", false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), !bGXsfl_38_Refreshing);
      }

      protected void StartGridControl38( )
      {
         Gridlevel_monedaContainer.AddObjectProperty("GridName", "Gridlevel_moneda");
         Gridlevel_monedaContainer.AddObjectProperty("Header", subGridlevel_moneda_Header);
         Gridlevel_monedaContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_monedaContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_monedaContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_monedaContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_moneda_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_monedaContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_monedaContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_monedaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_monedaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", ""))));
         Gridlevel_monedaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMonedaId.Enabled), 5, 0, ".", "")));
         Gridlevel_monedaContainer.AddColumnProperties(Gridlevel_monedaColumn);
         Gridlevel_monedaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_monedaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A187MonedaNombre)));
         Gridlevel_monedaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMonedaNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_monedaContainer.AddColumnProperties(Gridlevel_monedaColumn);
         Gridlevel_monedaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_monedaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A119MonedaISOSimbolo)));
         Gridlevel_monedaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMonedaISOSimbolo_Enabled), 5, 0, ".", "")));
         Gridlevel_monedaContainer.AddColumnProperties(Gridlevel_monedaColumn);
         Gridlevel_monedaContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_moneda_Selectedindex), 4, 0, ".", "")));
         Gridlevel_monedaContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_moneda_Allowselection), 1, 0, ".", "")));
         Gridlevel_monedaContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_moneda_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_monedaContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_moneda_Allowhovering), 1, 0, ".", "")));
         Gridlevel_monedaContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_moneda_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_monedaContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_moneda_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_monedaContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_moneda_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtPaisID_Internalname = "PAISID";
         edtPaisNombre_Internalname = "PAISNOMBRE";
         imgPaisBandera_Internalname = "PAISBANDERA";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         dynMonedaId_Internalname = "MONEDAID";
         edtMonedaNombre_Internalname = "MONEDANOMBRE";
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO";
         divTableleaflevel_moneda_Internalname = "TABLELEAFLEVEL_MONEDA";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_moneda_Internalname = "GRIDLEVEL_MONEDA";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_moneda_Allowcollapsing = 0;
         subGridlevel_moneda_Allowselection = 0;
         subGridlevel_moneda_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Pais", "");
         edtMonedaISOSimbolo_Jsonclick = "";
         edtMonedaNombre_Jsonclick = "";
         dynMonedaId_Jsonclick = "";
         subGridlevel_moneda_Class = "WorkWith";
         subGridlevel_moneda_Backcolorstyle = 0;
         edtMonedaISOSimbolo_Enabled = 0;
         edtMonedaNombre_Enabled = 0;
         dynMonedaId.Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         imgPaisBandera_Enabled = 1;
         edtPaisNombre_Jsonclick = "";
         edtPaisNombre_Enabled = 1;
         edtPaisID_Jsonclick = "";
         edtPaisID_Enabled = 1;
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

      protected void gxnrGridlevel_moneda_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_38125( ) ;
         while ( nGXsfl_38_idx <= nRC_GXsfl_38 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0Y125( ) ;
            standaloneModal0Y125( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0Y125( ) ;
            nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_38125( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_monedaContainer)) ;
         /* End function gxnrGridlevel_moneda_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "MONEDAID_" + sGXsfl_38_idx;
         dynMonedaId.Name = GXCCtl;
         dynMonedaId.WebTags = "";
         dynMonedaId.removeAllItems();
         /* Using cursor T000Y27 */
         pr_default.execute(25);
         while ( (pr_default.getStatus(25) != 101) )
         {
            dynMonedaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000Y27_A118MonedaId[0]), 4, 0)), T000Y27_A119MonedaISOSimbolo[0], 0);
            pr_default.readNext(25);
         }
         pr_default.close(25);
         if ( dynMonedaId.ItemCount > 0 )
         {
            A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0))), "."), 18, MidpointRounding.ToEven));
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

      public void Valid_Monedaid( )
      {
         A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000Y24 */
         pr_default.execute(22, new Object[] {A118MonedaId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( " T12", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MONEDAID");
            AnyError = 1;
            GX_FocusControl = dynMonedaId_Internalname;
         }
         A187MonedaNombre = T000Y24_A187MonedaNombre[0];
         A119MonedaISOSimbolo = T000Y24_A119MonedaISOSimbolo[0];
         pr_default.close(22);
         dynload_actions( ) ;
         if ( dynMonedaId.ItemCount > 0 )
         {
            A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMonedaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A187MonedaNombre", StringUtil.RTrim( A187MonedaNombre));
         AssignAttri("", false, "A119MonedaISOSimbolo", StringUtil.RTrim( A119MonedaISOSimbolo));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7PaisID',fld:'vPAISID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7PaisID',fld:'vPAISID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120Y2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[]");
         setEventMetadata("VALID_PAISID",",oparms:[]}");
         setEventMetadata("VALID_MONEDAID","{handler:'Valid_Monedaid',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'},{av:'A187MonedaNombre',fld:'MONEDANOMBRE',pic:'',type:'char'},{av:'A119MonedaISOSimbolo',fld:'MONEDAISOSIMBOLO',pic:'',type:'char'}]");
         setEventMetadata("VALID_MONEDAID",",oparms:[{av:'A187MonedaNombre',fld:'MONEDANOMBRE',pic:'',type:'char'},{av:'A119MonedaISOSimbolo',fld:'MONEDAISOSIMBOLO',pic:'',type:'char'}]}");
         setEventMetadata("NULL","{handler:'Valid_Monedaisosimbolo',iparms:[]");
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
         pr_default.close(22);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7PaisID = "";
         Z116PaisID = "";
         Z165PaisNombre = "";
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
         A116PaisID = "";
         A165PaisNombre = "";
         A207PaisBandera = "";
         A40000PaisBandera_GXI = "";
         sImgUrl = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_monedaContainer = new GXWebGrid( context);
         sMode125 = "";
         sStyleString = "";
         AV14Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode39 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A187MonedaNombre = "";
         A119MonedaISOSimbolo = "";
         AV12WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         Z207PaisBandera = "";
         Z40000PaisBandera_GXI = "";
         T000Y7_A116PaisID = new string[] {""} ;
         T000Y7_A165PaisNombre = new string[] {""} ;
         T000Y7_A40000PaisBandera_GXI = new string[] {""} ;
         T000Y7_A207PaisBandera = new string[] {""} ;
         T000Y8_A116PaisID = new string[] {""} ;
         T000Y6_A116PaisID = new string[] {""} ;
         T000Y6_A165PaisNombre = new string[] {""} ;
         T000Y6_A40000PaisBandera_GXI = new string[] {""} ;
         T000Y6_A207PaisBandera = new string[] {""} ;
         T000Y9_A116PaisID = new string[] {""} ;
         T000Y10_A116PaisID = new string[] {""} ;
         T000Y5_A116PaisID = new string[] {""} ;
         T000Y5_A165PaisNombre = new string[] {""} ;
         T000Y5_A40000PaisBandera_GXI = new string[] {""} ;
         T000Y5_A207PaisBandera = new string[] {""} ;
         T000Y15_A145usuariosId = new string[] {""} ;
         T000Y16_A112DepartamentoId = new long[1] ;
         T000Y17_A144CiudadId = new long[1] ;
         T000Y17_A116PaisID = new string[] {""} ;
         T000Y18_A116PaisID = new string[] {""} ;
         Z187MonedaNombre = "";
         Z119MonedaISOSimbolo = "";
         T000Y19_A116PaisID = new string[] {""} ;
         T000Y19_A187MonedaNombre = new string[] {""} ;
         T000Y19_A119MonedaISOSimbolo = new string[] {""} ;
         T000Y19_A118MonedaId = new short[1] ;
         T000Y4_A187MonedaNombre = new string[] {""} ;
         T000Y4_A119MonedaISOSimbolo = new string[] {""} ;
         T000Y20_A187MonedaNombre = new string[] {""} ;
         T000Y20_A119MonedaISOSimbolo = new string[] {""} ;
         T000Y21_A116PaisID = new string[] {""} ;
         T000Y21_A118MonedaId = new short[1] ;
         T000Y3_A116PaisID = new string[] {""} ;
         T000Y3_A118MonedaId = new short[1] ;
         T000Y2_A116PaisID = new string[] {""} ;
         T000Y2_A118MonedaId = new short[1] ;
         T000Y24_A187MonedaNombre = new string[] {""} ;
         T000Y24_A119MonedaISOSimbolo = new string[] {""} ;
         T000Y25_A116PaisID = new string[] {""} ;
         T000Y25_A118MonedaId = new short[1] ;
         Gridlevel_monedaRow = new GXWebRow();
         subGridlevel_moneda_Linesclass = "";
         T000Y26_A118MonedaId = new short[1] ;
         T000Y26_A119MonedaISOSimbolo = new string[] {""} ;
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         Gridlevel_monedaColumn = new GXWebColumn();
         T000Y27_A118MonedaId = new short[1] ;
         T000Y27_A119MonedaISOSimbolo = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.pais__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pais__default(),
            new Object[][] {
                new Object[] {
               T000Y2_A116PaisID, T000Y2_A118MonedaId
               }
               , new Object[] {
               T000Y3_A116PaisID, T000Y3_A118MonedaId
               }
               , new Object[] {
               T000Y4_A187MonedaNombre, T000Y4_A119MonedaISOSimbolo
               }
               , new Object[] {
               T000Y5_A116PaisID, T000Y5_A165PaisNombre, T000Y5_A40000PaisBandera_GXI, T000Y5_A207PaisBandera
               }
               , new Object[] {
               T000Y6_A116PaisID, T000Y6_A165PaisNombre, T000Y6_A40000PaisBandera_GXI, T000Y6_A207PaisBandera
               }
               , new Object[] {
               T000Y7_A116PaisID, T000Y7_A165PaisNombre, T000Y7_A40000PaisBandera_GXI, T000Y7_A207PaisBandera
               }
               , new Object[] {
               T000Y8_A116PaisID
               }
               , new Object[] {
               T000Y9_A116PaisID
               }
               , new Object[] {
               T000Y10_A116PaisID
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
               T000Y15_A145usuariosId
               }
               , new Object[] {
               T000Y16_A112DepartamentoId
               }
               , new Object[] {
               T000Y17_A144CiudadId, T000Y17_A116PaisID
               }
               , new Object[] {
               T000Y18_A116PaisID
               }
               , new Object[] {
               T000Y19_A116PaisID, T000Y19_A187MonedaNombre, T000Y19_A119MonedaISOSimbolo, T000Y19_A118MonedaId
               }
               , new Object[] {
               T000Y20_A187MonedaNombre, T000Y20_A119MonedaISOSimbolo
               }
               , new Object[] {
               T000Y21_A116PaisID, T000Y21_A118MonedaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Y24_A187MonedaNombre, T000Y24_A119MonedaISOSimbolo
               }
               , new Object[] {
               T000Y25_A116PaisID, T000Y25_A118MonedaId
               }
               , new Object[] {
               T000Y26_A118MonedaId, T000Y26_A119MonedaISOSimbolo
               }
               , new Object[] {
               T000Y27_A118MonedaId, T000Y27_A119MonedaISOSimbolo
               }
            }
         );
         AV14Pgmname = "Pais";
      }

      private short Z118MonedaId ;
      private short nRcdDeleted_125 ;
      private short nRcdExists_125 ;
      private short nIsMod_125 ;
      private short GxWebError ;
      private short A118MonedaId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount125 ;
      private short RcdFound125 ;
      private short nBlankRcdUsr125 ;
      private short RcdFound39 ;
      private short Gx_BScreen ;
      private short nIsDirty_125 ;
      private short subGridlevel_moneda_Backcolorstyle ;
      private short subGridlevel_moneda_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_moneda_Allowselection ;
      private short subGridlevel_moneda_Allowhovering ;
      private short subGridlevel_moneda_Allowcollapsing ;
      private short subGridlevel_moneda_Collapsed ;
      private int nRC_GXsfl_38 ;
      private int nGXsfl_38_idx=1 ;
      private int trnEnded ;
      private int edtPaisID_Enabled ;
      private int edtPaisNombre_Enabled ;
      private int imgPaisBandera_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtMonedaNombre_Enabled ;
      private int edtMonedaISOSimbolo_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int subGridlevel_moneda_Backcolor ;
      private int subGridlevel_moneda_Allbackcolor ;
      private int defdynMonedaId_Enabled ;
      private int idxLst ;
      private int subGridlevel_moneda_Selectedindex ;
      private int subGridlevel_moneda_Selectioncolor ;
      private int subGridlevel_moneda_Hoveringcolor ;
      private long GRIDLEVEL_MONEDA_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV7PaisID ;
      private string Z116PaisID ;
      private string Z165PaisNombre ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV7PaisID ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPaisID_Internalname ;
      private string sGXsfl_38_idx="0001" ;
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
      private string A116PaisID ;
      private string edtPaisID_Jsonclick ;
      private string edtPaisNombre_Internalname ;
      private string A165PaisNombre ;
      private string edtPaisNombre_Jsonclick ;
      private string imgPaisBandera_Internalname ;
      private string sImgUrl ;
      private string divTableleaflevel_moneda_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode125 ;
      private string dynMonedaId_Internalname ;
      private string edtMonedaNombre_Internalname ;
      private string edtMonedaISOSimbolo_Internalname ;
      private string sStyleString ;
      private string subGridlevel_moneda_Internalname ;
      private string AV14Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode39 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A187MonedaNombre ;
      private string A119MonedaISOSimbolo ;
      private string GXEncryptionTmp ;
      private string Z187MonedaNombre ;
      private string Z119MonedaISOSimbolo ;
      private string sGXsfl_38_fel_idx="0001" ;
      private string subGridlevel_moneda_Class ;
      private string subGridlevel_moneda_Linesclass ;
      private string dynMonedaId_Jsonclick ;
      private string ROClassString ;
      private string edtMonedaNombre_Jsonclick ;
      private string edtMonedaISOSimbolo_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string subGridlevel_moneda_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A207PaisBandera_IsBlob ;
      private bool bGXsfl_38_Refreshing=false ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private string A40000PaisBandera_GXI ;
      private string Z40000PaisBandera_GXI ;
      private string A207PaisBandera ;
      private string Z207PaisBandera ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_monedaContainer ;
      private GXWebRow Gridlevel_monedaRow ;
      private GXWebColumn Gridlevel_monedaColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynMonedaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV12WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_default ;
      private string[] T000Y7_A116PaisID ;
      private string[] T000Y7_A165PaisNombre ;
      private string[] T000Y7_A40000PaisBandera_GXI ;
      private string[] T000Y7_A207PaisBandera ;
      private string[] T000Y8_A116PaisID ;
      private string[] T000Y6_A116PaisID ;
      private string[] T000Y6_A165PaisNombre ;
      private string[] T000Y6_A40000PaisBandera_GXI ;
      private string[] T000Y6_A207PaisBandera ;
      private string[] T000Y9_A116PaisID ;
      private string[] T000Y10_A116PaisID ;
      private string[] T000Y5_A116PaisID ;
      private string[] T000Y5_A165PaisNombre ;
      private string[] T000Y5_A40000PaisBandera_GXI ;
      private string[] T000Y5_A207PaisBandera ;
      private string[] T000Y15_A145usuariosId ;
      private long[] T000Y16_A112DepartamentoId ;
      private long[] T000Y17_A144CiudadId ;
      private string[] T000Y17_A116PaisID ;
      private string[] T000Y18_A116PaisID ;
      private string[] T000Y19_A116PaisID ;
      private string[] T000Y19_A187MonedaNombre ;
      private string[] T000Y19_A119MonedaISOSimbolo ;
      private short[] T000Y19_A118MonedaId ;
      private string[] T000Y4_A187MonedaNombre ;
      private string[] T000Y4_A119MonedaISOSimbolo ;
      private string[] T000Y20_A187MonedaNombre ;
      private string[] T000Y20_A119MonedaISOSimbolo ;
      private string[] T000Y21_A116PaisID ;
      private short[] T000Y21_A118MonedaId ;
      private string[] T000Y3_A116PaisID ;
      private short[] T000Y3_A118MonedaId ;
      private string[] T000Y2_A116PaisID ;
      private short[] T000Y2_A118MonedaId ;
      private string[] T000Y24_A187MonedaNombre ;
      private string[] T000Y24_A119MonedaISOSimbolo ;
      private string[] T000Y25_A116PaisID ;
      private short[] T000Y25_A118MonedaId ;
      private short[] T000Y26_A118MonedaId ;
      private string[] T000Y26_A119MonedaISOSimbolo ;
      private short[] T000Y27_A118MonedaId ;
      private string[] T000Y27_A119MonedaISOSimbolo ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class pais__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class pais__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000Y2;
        prmT000Y2 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmT000Y3;
        prmT000Y3 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmT000Y4;
        prmT000Y4 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmT000Y5;
        prmT000Y5 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Y6;
        prmT000Y6 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Y7;
        prmT000Y7 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Y8;
        prmT000Y8 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Y9;
        prmT000Y9 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Y10;
        prmT000Y10 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Y11;
        prmT000Y11 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0) ,
        new ParDef("@PaisNombre",GXType.NChar,80,0) ,
        new ParDef("@PaisBandera",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@PaisBandera_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="Pais", Fld="PaisBandera"}
        };
        Object[] prmT000Y12;
        prmT000Y12 = new Object[] {
        new ParDef("@PaisNombre",GXType.NChar,80,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Y13;
        prmT000Y13 = new Object[] {
        new ParDef("@PaisBandera",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@PaisBandera_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Pais", Fld="PaisBandera"} ,
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Y14;
        prmT000Y14 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Y15;
        prmT000Y15 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Y16;
        prmT000Y16 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Y17;
        prmT000Y17 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Y18;
        prmT000Y18 = new Object[] {
        };
        Object[] prmT000Y19;
        prmT000Y19 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmT000Y20;
        prmT000Y20 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmT000Y21;
        prmT000Y21 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmT000Y22;
        prmT000Y22 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmT000Y23;
        prmT000Y23 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmT000Y24;
        prmT000Y24 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmT000Y25;
        prmT000Y25 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Y26;
        prmT000Y26 = new Object[] {
        };
        Object[] prmT000Y27;
        prmT000Y27 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000Y2", "SELECT [PaisID], [MonedaId] FROM [PaisMoneda] WITH (UPDLOCK) WHERE [PaisID] = @PaisID AND [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y3", "SELECT [PaisID], [MonedaId] FROM [PaisMoneda] WHERE [PaisID] = @PaisID AND [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y4", "SELECT [MonedaNombre], [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y5", "SELECT [PaisID], [PaisNombre], [PaisBandera_GXI], [PaisBandera] FROM [Pais] WITH (UPDLOCK) WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y6", "SELECT [PaisID], [PaisNombre], [PaisBandera_GXI], [PaisBandera] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y7", "SELECT TM1.[PaisID], TM1.[PaisNombre], TM1.[PaisBandera_GXI], TM1.[PaisBandera] FROM [Pais] TM1 WHERE TM1.[PaisID] = @PaisID ORDER BY TM1.[PaisID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y8", "SELECT [PaisID] FROM [Pais] WHERE [PaisID] = @PaisID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y9", "SELECT TOP 1 [PaisID] FROM [Pais] WHERE ( [PaisID] > @PaisID) ORDER BY [PaisID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y10", "SELECT TOP 1 [PaisID] FROM [Pais] WHERE ( [PaisID] < @PaisID) ORDER BY [PaisID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y11", "INSERT INTO [Pais]([PaisID], [PaisNombre], [PaisBandera], [PaisBandera_GXI]) VALUES(@PaisID, @PaisNombre, @PaisBandera, @PaisBandera_GXI)", GxErrorMask.GX_NOMASK,prmT000Y11)
           ,new CursorDef("T000Y12", "UPDATE [Pais] SET [PaisNombre]=@PaisNombre  WHERE [PaisID] = @PaisID", GxErrorMask.GX_NOMASK,prmT000Y12)
           ,new CursorDef("T000Y13", "UPDATE [Pais] SET [PaisBandera]=@PaisBandera, [PaisBandera_GXI]=@PaisBandera_GXI  WHERE [PaisID] = @PaisID", GxErrorMask.GX_NOMASK,prmT000Y13)
           ,new CursorDef("T000Y14", "DELETE FROM [Pais]  WHERE [PaisID] = @PaisID", GxErrorMask.GX_NOMASK,prmT000Y14)
           ,new CursorDef("T000Y15", "SELECT TOP 1 [usuariosId] FROM [usuarios] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y16", "SELECT TOP 1 [DepartamentoId] FROM [Departamento] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y17", "SELECT TOP 1 [CiudadId], [PaisID] FROM [Ciudad] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y18", "SELECT [PaisID] FROM [Pais] ORDER BY [PaisID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y18,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y19", "SELECT T1.[PaisID], T2.[MonedaNombre], T2.[MonedaISOSimbolo], T1.[MonedaId] FROM ([PaisMoneda] T1 INNER JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId]) WHERE T1.[PaisID] = @PaisID and T1.[MonedaId] = @MonedaId ORDER BY T1.[PaisID], T1.[MonedaId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y19,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y20", "SELECT [MonedaNombre], [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y21", "SELECT [PaisID], [MonedaId] FROM [PaisMoneda] WHERE [PaisID] = @PaisID AND [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y22", "INSERT INTO [PaisMoneda]([PaisID], [MonedaId]) VALUES(@PaisID, @MonedaId)", GxErrorMask.GX_NOMASK,prmT000Y22)
           ,new CursorDef("T000Y23", "DELETE FROM [PaisMoneda]  WHERE [PaisID] = @PaisID AND [MonedaId] = @MonedaId", GxErrorMask.GX_NOMASK,prmT000Y23)
           ,new CursorDef("T000Y24", "SELECT [MonedaNombre], [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y25", "SELECT [PaisID], [MonedaId] FROM [PaisMoneda] WHERE [PaisID] = @PaisID ORDER BY [PaisID], [MonedaId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y25,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y26", "SELECT [MonedaId], [MonedaISOSimbolo] FROM [Moneda] ORDER BY [MonedaISOSimbolo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y26,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y27", "SELECT [MonedaId], [MonedaISOSimbolo] FROM [Moneda] ORDER BY [MonedaISOSimbolo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y27,0, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 24 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 25 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
     }
  }

}

}
