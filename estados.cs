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
   public class estados : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_genericos") == 0 )
         {
            gxnrGridlevel_genericos_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "estados.aspx")), "estados.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "estados.aspx")))) ;
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
                  AV7EstadosTipo = GetPar( "EstadosTipo");
                  AssignAttri("", false, "AV7EstadosTipo", AV7EstadosTipo);
                  GxWebStd.gx_hidden_field( context, "gxhash_vESTADOSTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7EstadosTipo, "")), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Estados", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEstadosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_genericos_newrow_invoke( )
      {
         nRC_GXsfl_33 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_33"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_33_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_33_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_33_idx = GetPar( "sGXsfl_33_idx");
         A159EstadosAutoEnumerar = (short)(Math.Round(NumberUtil.Val( GetPar( "EstadosAutoEnumerar"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_genericos_newrow( ) ;
         /* End function gxnrGridlevel_genericos_newrow_invoke */
      }

      public estados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public estados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_EstadosTipo )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EstadosTipo = aP1_EstadosTipo;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadosTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadosTipo_Internalname, context.GetMessage( "Tipo de Estados", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadosTipo_Internalname, StringUtil.RTrim( A107EstadosTipo), StringUtil.RTrim( context.localUtil.Format( A107EstadosTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosTipo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadosTipo_Enabled, 1, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadosDescrip_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadosDescrip_Internalname, context.GetMessage( "Descripción", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadosDescrip_Internalname, StringUtil.RTrim( A158EstadosDescrip), StringUtil.RTrim( context.localUtil.Format( A158EstadosDescrip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosDescrip_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadosDescrip_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Estados.htm");
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
         GxWebStd.gx_div_start( context, divTableleaflevel_genericos_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_genericos( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Estados.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadosAutoEnumerar_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A159EstadosAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtEstadosAutoEnumerar_Enabled!=0) ? context.localUtil.Format( (decimal)(A159EstadosAutoEnumerar), "ZZZ9") : context.localUtil.Format( (decimal)(A159EstadosAutoEnumerar), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosAutoEnumerar_Jsonclick, 0, "Attribute", "", "", "", "", edtEstadosAutoEnumerar_Visible, edtEstadosAutoEnumerar_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_genericos( )
      {
         /*  Grid Control  */
         StartGridControl33( ) ;
         nGXsfl_33_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount24 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_24 = 1;
               ScanStart0K24( ) ;
               while ( RcdFound24 != 0 )
               {
                  init_level_properties24( ) ;
                  getByPrimaryKey0K24( ) ;
                  AddRow0K24( ) ;
                  ScanNext0K24( ) ;
               }
               ScanEnd0K24( ) ;
               nBlankRcdCount24 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B159EstadosAutoEnumerar = A159EstadosAutoEnumerar;
            AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
            standaloneNotModal0K24( ) ;
            standaloneModal0K24( ) ;
            sMode24 = Gx_mode;
            while ( nGXsfl_33_idx < nRC_GXsfl_33 )
            {
               bGXsfl_33_Refreshing = true;
               ReadRow0K24( ) ;
               edtEstadosGenericosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGENERICOSID_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), !bGXsfl_33_Refreshing);
               edtEstadosGenericosNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGENERICOSNOMBRE_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtEstadosGenericosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0), !bGXsfl_33_Refreshing);
               if ( ( nRcdExists_24 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0K24( ) ;
               }
               SendRow0K24( ) ;
               bGXsfl_33_Refreshing = false;
            }
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A159EstadosAutoEnumerar = B159EstadosAutoEnumerar;
            AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount24 = 5;
            nRcdExists_24 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0K24( ) ;
               while ( RcdFound24 != 0 )
               {
                  sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_3324( ) ;
                  init_level_properties24( ) ;
                  standaloneNotModal0K24( ) ;
                  getByPrimaryKey0K24( ) ;
                  standaloneModal0K24( ) ;
                  AddRow0K24( ) ;
                  ScanNext0K24( ) ;
               }
               ScanEnd0K24( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode24 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx+1), 4, 0), 4, "0");
            SubsflControlProps_3324( ) ;
            InitAll0K24( ) ;
            init_level_properties24( ) ;
            B159EstadosAutoEnumerar = A159EstadosAutoEnumerar;
            AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
            nRcdExists_24 = 0;
            nIsMod_24 = 0;
            nRcdDeleted_24 = 0;
            nBlankRcdCount24 = (short)(nBlankRcdUsr24+nBlankRcdCount24);
            fRowAdded = 0;
            while ( nBlankRcdCount24 > 0 )
            {
               standaloneNotModal0K24( ) ;
               standaloneModal0K24( ) ;
               AddRow0K24( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtEstadosGenericosNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount24 = (short)(nBlankRcdCount24-1);
            }
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A159EstadosAutoEnumerar = B159EstadosAutoEnumerar;
            AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_genericosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_genericos", Gridlevel_genericosContainer, subGridlevel_genericos_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_genericosContainerData", Gridlevel_genericosContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_genericosContainerData"+"V", Gridlevel_genericosContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_genericosContainerData"+"V"+"\" value='"+Gridlevel_genericosContainer.GridValuesHidden()+"'/>") ;
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
         E110K2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z107EstadosTipo = cgiGet( "Z107EstadosTipo");
               Z158EstadosDescrip = cgiGet( "Z158EstadosDescrip");
               Z159EstadosAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z159EstadosAutoEnumerar"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O159EstadosAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O159EstadosAutoEnumerar"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_33 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_33"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7EstadosTipo = cgiGet( "vESTADOSTIPO");
               AV14Pgmname = cgiGet( "vPGMNAME");
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
               A107EstadosTipo = cgiGet( edtEstadosTipo_Internalname);
               AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
               A158EstadosDescrip = cgiGet( edtEstadosDescrip_Internalname);
               AssignAttri("", false, "A158EstadosDescrip", A158EstadosDescrip);
               A159EstadosAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosAutoEnumerar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Estados");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A107EstadosTipo, Z107EstadosTipo) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("estados:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A107EstadosTipo = GetPar( "EstadosTipo");
                  AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
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
                     sMode23 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode23;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound23 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0K0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ESTADOSTIPO");
                        AnyError = 1;
                        GX_FocusControl = edtEstadosTipo_Internalname;
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
                           E110K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120K2 ();
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
            E120K2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0K23( ) ;
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
            DisableAttributes0K23( ) ;
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

      protected void CONFIRM_0K0( )
      {
         BeforeValidate0K23( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0K23( ) ;
            }
            else
            {
               CheckExtendedTable0K23( ) ;
               CloseExtendedTableCursors0K23( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode23 = Gx_mode;
            CONFIRM_0K24( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode23;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0K24( )
      {
         s159EstadosAutoEnumerar = O159EstadosAutoEnumerar;
         AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
         nGXsfl_33_idx = 0;
         while ( nGXsfl_33_idx < nRC_GXsfl_33 )
         {
            ReadRow0K24( ) ;
            if ( ( nRcdExists_24 != 0 ) || ( nIsMod_24 != 0 ) )
            {
               GetKey0K24( ) ;
               if ( ( nRcdExists_24 == 0 ) && ( nRcdDeleted_24 == 0 ) )
               {
                  if ( RcdFound24 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0K24( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0K24( ) ;
                        CloseExtendedTableCursors0K24( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O159EstadosAutoEnumerar = A159EstadosAutoEnumerar;
                        AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "ESTADOSTIPO");
                     AnyError = 1;
                     GX_FocusControl = edtEstadosTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound24 != 0 )
                  {
                     if ( nRcdDeleted_24 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0K24( ) ;
                        Load0K24( ) ;
                        BeforeValidate0K24( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0K24( ) ;
                           O159EstadosAutoEnumerar = A159EstadosAutoEnumerar;
                           AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_24 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0K24( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0K24( ) ;
                              CloseExtendedTableCursors0K24( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O159EstadosAutoEnumerar = A159EstadosAutoEnumerar;
                              AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_24 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ESTADOSTIPO");
                        AnyError = 1;
                        GX_FocusControl = edtEstadosTipo_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtEstadosGenericosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtEstadosGenericosNombre_Internalname, StringUtil.RTrim( A109EstadosGenericosNombre)) ;
            ChangePostValue( "ZT_"+"Z108EstadosGenericosId_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z109EstadosGenericosNombre_"+sGXsfl_33_idx, StringUtil.RTrim( Z109EstadosGenericosNombre)) ;
            ChangePostValue( "nRcdDeleted_24_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_24), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_24_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_24), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_24_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_24), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_24 != 0 )
            {
               ChangePostValue( "ESTADOSGENERICOSID_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGENERICOSNOMBRE_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O159EstadosAutoEnumerar = s159EstadosAutoEnumerar;
         AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0K0( )
      {
      }

      protected void E110K2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstados_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstados_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstados_Delete", out  GXt_boolean1) ;
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
         edtEstadosAutoEnumerar_Visible = 0;
         AssignProp("", false, edtEstadosAutoEnumerar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadosAutoEnumerar_Visible), 5, 0), true);
      }

      protected void E120K2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("estadosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0K23( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z158EstadosDescrip = T000K5_A158EstadosDescrip[0];
               Z159EstadosAutoEnumerar = T000K5_A159EstadosAutoEnumerar[0];
            }
            else
            {
               Z158EstadosDescrip = A158EstadosDescrip;
               Z159EstadosAutoEnumerar = A159EstadosAutoEnumerar;
            }
         }
         if ( GX_JID == -9 )
         {
            Z107EstadosTipo = A107EstadosTipo;
            Z158EstadosDescrip = A158EstadosDescrip;
            Z159EstadosAutoEnumerar = A159EstadosAutoEnumerar;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEstadosAutoEnumerar_Enabled = 0;
         AssignProp("", false, edtEstadosAutoEnumerar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosAutoEnumerar_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtEstadosAutoEnumerar_Enabled = 0;
         AssignProp("", false, edtEstadosAutoEnumerar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosAutoEnumerar_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7EstadosTipo)) )
         {
            A107EstadosTipo = AV7EstadosTipo;
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7EstadosTipo)) )
         {
            edtEstadosTipo_Enabled = 0;
            AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
         }
         else
         {
            edtEstadosTipo_Enabled = 1;
            AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7EstadosTipo)) )
         {
            edtEstadosTipo_Enabled = 0;
            AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
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
            AV14Pgmname = "Estados";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         }
      }

      protected void Load0K23( )
      {
         /* Using cursor T000K6 */
         pr_default.execute(4, new Object[] {A107EstadosTipo});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound23 = 1;
            A158EstadosDescrip = T000K6_A158EstadosDescrip[0];
            AssignAttri("", false, "A158EstadosDescrip", A158EstadosDescrip);
            A159EstadosAutoEnumerar = T000K6_A159EstadosAutoEnumerar[0];
            AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
            ZM0K23( -9) ;
         }
         pr_default.close(4);
         OnLoadActions0K23( ) ;
      }

      protected void OnLoadActions0K23( )
      {
         AV14Pgmname = "Estados";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable0K23( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV14Pgmname = "Estados";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CloseExtendedTableCursors0K23( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0K23( )
      {
         /* Using cursor T000K7 */
         pr_default.execute(5, new Object[] {A107EstadosTipo});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound23 = 1;
         }
         else
         {
            RcdFound23 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000K5 */
         pr_default.execute(3, new Object[] {A107EstadosTipo});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0K23( 9) ;
            RcdFound23 = 1;
            A107EstadosTipo = T000K5_A107EstadosTipo[0];
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
            A158EstadosDescrip = T000K5_A158EstadosDescrip[0];
            AssignAttri("", false, "A158EstadosDescrip", A158EstadosDescrip);
            A159EstadosAutoEnumerar = T000K5_A159EstadosAutoEnumerar[0];
            AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
            O159EstadosAutoEnumerar = A159EstadosAutoEnumerar;
            AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
            Z107EstadosTipo = A107EstadosTipo;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0K23( ) ;
            if ( AnyError == 1 )
            {
               RcdFound23 = 0;
               InitializeNonKey0K23( ) ;
            }
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound23 = 0;
            InitializeNonKey0K23( ) ;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0K23( ) ;
         if ( RcdFound23 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound23 = 0;
         /* Using cursor T000K8 */
         pr_default.execute(6, new Object[] {A107EstadosTipo});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T000K8_A107EstadosTipo[0], A107EstadosTipo) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T000K8_A107EstadosTipo[0], A107EstadosTipo) > 0 ) ) )
            {
               A107EstadosTipo = T000K8_A107EstadosTipo[0];
               AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
               RcdFound23 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound23 = 0;
         /* Using cursor T000K9 */
         pr_default.execute(7, new Object[] {A107EstadosTipo});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T000K9_A107EstadosTipo[0], A107EstadosTipo) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T000K9_A107EstadosTipo[0], A107EstadosTipo) < 0 ) ) )
            {
               A107EstadosTipo = T000K9_A107EstadosTipo[0];
               AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
               RcdFound23 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0K23( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A159EstadosAutoEnumerar = O159EstadosAutoEnumerar;
            AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
            GX_FocusControl = edtEstadosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0K23( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound23 == 1 )
            {
               if ( StringUtil.StrCmp(A107EstadosTipo, Z107EstadosTipo) != 0 )
               {
                  A107EstadosTipo = Z107EstadosTipo;
                  AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ESTADOSTIPO");
                  AnyError = 1;
                  GX_FocusControl = edtEstadosTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A159EstadosAutoEnumerar = O159EstadosAutoEnumerar;
                  AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEstadosTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A159EstadosAutoEnumerar = O159EstadosAutoEnumerar;
                  AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
                  Update0K23( ) ;
                  GX_FocusControl = edtEstadosTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A107EstadosTipo, Z107EstadosTipo) != 0 )
               {
                  /* Insert record */
                  A159EstadosAutoEnumerar = O159EstadosAutoEnumerar;
                  AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
                  GX_FocusControl = edtEstadosTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0K23( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ESTADOSTIPO");
                     AnyError = 1;
                     GX_FocusControl = edtEstadosTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A159EstadosAutoEnumerar = O159EstadosAutoEnumerar;
                     AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
                     GX_FocusControl = edtEstadosTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0K23( ) ;
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
         if ( StringUtil.StrCmp(A107EstadosTipo, Z107EstadosTipo) != 0 )
         {
            A107EstadosTipo = Z107EstadosTipo;
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ESTADOSTIPO");
            AnyError = 1;
            GX_FocusControl = edtEstadosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A159EstadosAutoEnumerar = O159EstadosAutoEnumerar;
            AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEstadosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0K23( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000K4 */
            pr_default.execute(2, new Object[] {A107EstadosTipo});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Estados"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z158EstadosDescrip, T000K4_A158EstadosDescrip[0]) != 0 ) || ( Z159EstadosAutoEnumerar != T000K4_A159EstadosAutoEnumerar[0] ) )
            {
               if ( StringUtil.StrCmp(Z158EstadosDescrip, T000K4_A158EstadosDescrip[0]) != 0 )
               {
                  GXUtil.WriteLog("estados:[seudo value changed for attri]"+"EstadosDescrip");
                  GXUtil.WriteLogRaw("Old: ",Z158EstadosDescrip);
                  GXUtil.WriteLogRaw("Current: ",T000K4_A158EstadosDescrip[0]);
               }
               if ( Z159EstadosAutoEnumerar != T000K4_A159EstadosAutoEnumerar[0] )
               {
                  GXUtil.WriteLog("estados:[seudo value changed for attri]"+"EstadosAutoEnumerar");
                  GXUtil.WriteLogRaw("Old: ",Z159EstadosAutoEnumerar);
                  GXUtil.WriteLogRaw("Current: ",T000K4_A159EstadosAutoEnumerar[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Estados"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0K23( )
      {
         BeforeValidate0K23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K23( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0K23( 0) ;
            CheckOptimisticConcurrency0K23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0K23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000K10 */
                     pr_default.execute(8, new Object[] {A107EstadosTipo, A158EstadosDescrip, A159EstadosAutoEnumerar});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Estados");
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
                           ProcessLevel0K23( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0K0( ) ;
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
               Load0K23( ) ;
            }
            EndLevel0K23( ) ;
         }
         CloseExtendedTableCursors0K23( ) ;
      }

      protected void Update0K23( )
      {
         BeforeValidate0K23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K23( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0K23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000K11 */
                     pr_default.execute(9, new Object[] {A158EstadosDescrip, A159EstadosAutoEnumerar, A107EstadosTipo});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Estados");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Estados"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0K23( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0K23( ) ;
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
            EndLevel0K23( ) ;
         }
         CloseExtendedTableCursors0K23( ) ;
      }

      protected void DeferredUpdate0K23( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0K23( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K23( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0K23( ) ;
            AfterConfirm0K23( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0K23( ) ;
               if ( AnyError == 0 )
               {
                  A159EstadosAutoEnumerar = O159EstadosAutoEnumerar;
                  AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
                  ScanStart0K24( ) ;
                  while ( RcdFound24 != 0 )
                  {
                     getByPrimaryKey0K24( ) ;
                     Delete0K24( ) ;
                     ScanNext0K24( ) ;
                     O159EstadosAutoEnumerar = A159EstadosAutoEnumerar;
                     AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
                  }
                  ScanEnd0K24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000K12 */
                     pr_default.execute(10, new Object[] {A107EstadosTipo});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Estados");
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
         sMode23 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0K23( ) ;
         Gx_mode = sMode23;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0K23( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "Estados";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000K13 */
            pr_default.execute(11, new Object[] {A107EstadosTipo});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Relaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000K14 */
            pr_default.execute(12, new Object[] {A107EstadosTipo});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Relaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000K15 */
            pr_default.execute(13, new Object[] {A107EstadosTipo});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Historico Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000K16 */
            pr_default.execute(14, new Object[] {A107EstadosTipo});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000K17 */
            pr_default.execute(15, new Object[] {A107EstadosTipo});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000K18 */
            pr_default.execute(16, new Object[] {A107EstadosTipo});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Inventario", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void ProcessNestedLevel0K24( )
      {
         s159EstadosAutoEnumerar = O159EstadosAutoEnumerar;
         AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
         nGXsfl_33_idx = 0;
         while ( nGXsfl_33_idx < nRC_GXsfl_33 )
         {
            ReadRow0K24( ) ;
            if ( ( nRcdExists_24 != 0 ) || ( nIsMod_24 != 0 ) )
            {
               standaloneNotModal0K24( ) ;
               GetKey0K24( ) ;
               if ( ( nRcdExists_24 == 0 ) && ( nRcdDeleted_24 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0K24( ) ;
               }
               else
               {
                  if ( RcdFound24 != 0 )
                  {
                     if ( ( nRcdDeleted_24 != 0 ) && ( nRcdExists_24 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0K24( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_24 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0K24( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_24 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ESTADOSTIPO");
                        AnyError = 1;
                        GX_FocusControl = edtEstadosTipo_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O159EstadosAutoEnumerar = A159EstadosAutoEnumerar;
               AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
            }
            ChangePostValue( edtEstadosGenericosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtEstadosGenericosNombre_Internalname, StringUtil.RTrim( A109EstadosGenericosNombre)) ;
            ChangePostValue( "ZT_"+"Z108EstadosGenericosId_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z109EstadosGenericosNombre_"+sGXsfl_33_idx, StringUtil.RTrim( Z109EstadosGenericosNombre)) ;
            ChangePostValue( "nRcdDeleted_24_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_24), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_24_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_24), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_24_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_24), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_24 != 0 )
            {
               ChangePostValue( "ESTADOSGENERICOSID_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGENERICOSNOMBRE_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0K24( ) ;
         if ( AnyError != 0 )
         {
            O159EstadosAutoEnumerar = s159EstadosAutoEnumerar;
            AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
         }
         nRcdExists_24 = 0;
         nIsMod_24 = 0;
         nRcdDeleted_24 = 0;
      }

      protected void ProcessLevel0K23( )
      {
         /* Save parent mode. */
         sMode23 = Gx_mode;
         ProcessNestedLevel0K24( ) ;
         if ( AnyError != 0 )
         {
            O159EstadosAutoEnumerar = s159EstadosAutoEnumerar;
            AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode23;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000K19 */
         pr_default.execute(17, new Object[] {A159EstadosAutoEnumerar, A107EstadosTipo});
         pr_default.close(17);
         pr_default.SmartCacheProvider.SetUpdated("Estados");
      }

      protected void EndLevel0K23( )
      {
         pr_default.close(2);
         if ( AnyError == 0 )
         {
            BeforeComplete0K23( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.CommitDataStores("estados",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0K0( ) ;
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
            context.RollbackDataStores("estados",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0K23( )
      {
         /* Scan By routine */
         /* Using cursor T000K20 */
         pr_default.execute(18);
         RcdFound23 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound23 = 1;
            A107EstadosTipo = T000K20_A107EstadosTipo[0];
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0K23( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound23 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound23 = 1;
            A107EstadosTipo = T000K20_A107EstadosTipo[0];
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
         }
      }

      protected void ScanEnd0K23( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0K23( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0K23( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0K23( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0K23( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0K23( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0K23( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0K23( )
      {
         edtEstadosTipo_Enabled = 0;
         AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
         edtEstadosDescrip_Enabled = 0;
         AssignProp("", false, edtEstadosDescrip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosDescrip_Enabled), 5, 0), true);
         edtEstadosAutoEnumerar_Enabled = 0;
         AssignProp("", false, edtEstadosAutoEnumerar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosAutoEnumerar_Enabled), 5, 0), true);
      }

      protected void ZM0K24( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z109EstadosGenericosNombre = T000K3_A109EstadosGenericosNombre[0];
            }
            else
            {
               Z109EstadosGenericosNombre = A109EstadosGenericosNombre;
            }
         }
         if ( GX_JID == -10 )
         {
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
            Z109EstadosGenericosNombre = A109EstadosGenericosNombre;
         }
      }

      protected void standaloneNotModal0K24( )
      {
         edtEstadosGenericosId_Enabled = 0;
         AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtEstadosAutoEnumerar_Enabled = 0;
         AssignProp("", false, edtEstadosAutoEnumerar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosAutoEnumerar_Enabled), 5, 0), true);
         edtEstadosAutoEnumerar_Enabled = 0;
         AssignProp("", false, edtEstadosAutoEnumerar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosAutoEnumerar_Enabled), 5, 0), true);
      }

      protected void standaloneModal0K24( )
      {
         if ( IsIns( )  )
         {
            A159EstadosAutoEnumerar = (short)(O159EstadosAutoEnumerar+1);
            AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A108EstadosGenericosId = A159EstadosAutoEnumerar;
         }
      }

      protected void Load0K24( )
      {
         /* Using cursor T000K21 */
         pr_default.execute(19, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound24 = 1;
            A109EstadosGenericosNombre = T000K21_A109EstadosGenericosNombre[0];
            ZM0K24( -10) ;
         }
         pr_default.close(19);
         OnLoadActions0K24( ) ;
      }

      protected void OnLoadActions0K24( )
      {
      }

      protected void CheckExtendedTable0K24( )
      {
         nIsDirty_24 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0K24( ) ;
      }

      protected void CloseExtendedTableCursors0K24( )
      {
      }

      protected void enableDisable0K24( )
      {
      }

      protected void GetKey0K24( )
      {
         /* Using cursor T000K22 */
         pr_default.execute(20, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound24 = 1;
         }
         else
         {
            RcdFound24 = 0;
         }
         pr_default.close(20);
      }

      protected void getByPrimaryKey0K24( )
      {
         /* Using cursor T000K3 */
         pr_default.execute(1, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0K24( 10) ;
            RcdFound24 = 1;
            InitializeNonKey0K24( ) ;
            A108EstadosGenericosId = T000K3_A108EstadosGenericosId[0];
            A109EstadosGenericosNombre = T000K3_A109EstadosGenericosNombre[0];
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0K24( ) ;
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound24 = 0;
            InitializeNonKey0K24( ) ;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0K24( ) ;
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0K24( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0K24( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000K2 */
            pr_default.execute(0, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EstadosGenericos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z109EstadosGenericosNombre, T000K2_A109EstadosGenericosNombre[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z109EstadosGenericosNombre, T000K2_A109EstadosGenericosNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("estados:[seudo value changed for attri]"+"EstadosGenericosNombre");
                  GXUtil.WriteLogRaw("Old: ",Z109EstadosGenericosNombre);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A109EstadosGenericosNombre[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EstadosGenericos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0K24( )
      {
         BeforeValidate0K24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K24( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0K24( 0) ;
            CheckOptimisticConcurrency0K24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0K24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000K23 */
                     pr_default.execute(21, new Object[] {A107EstadosTipo, A108EstadosGenericosId, A109EstadosGenericosNombre});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("EstadosGenericos");
                     if ( (pr_default.getStatus(21) == 1) )
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
               Load0K24( ) ;
            }
            EndLevel0K24( ) ;
         }
         CloseExtendedTableCursors0K24( ) ;
      }

      protected void Update0K24( )
      {
         BeforeValidate0K24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K24( ) ;
         }
         if ( ( nIsMod_24 != 0 ) || ( nIsDirty_24 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0K24( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0K24( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0K24( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000K24 */
                        pr_default.execute(22, new Object[] {A109EstadosGenericosNombre, A107EstadosTipo, A108EstadosGenericosId});
                        pr_default.close(22);
                        pr_default.SmartCacheProvider.SetUpdated("EstadosGenericos");
                        if ( (pr_default.getStatus(22) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EstadosGenericos"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0K24( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0K24( ) ;
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
               EndLevel0K24( ) ;
            }
         }
         CloseExtendedTableCursors0K24( ) ;
      }

      protected void DeferredUpdate0K24( )
      {
      }

      protected void Delete0K24( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0K24( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K24( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0K24( ) ;
            AfterConfirm0K24( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0K24( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000K25 */
                  pr_default.execute(23, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
                  pr_default.close(23);
                  pr_default.SmartCacheProvider.SetUpdated("EstadosGenericos");
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
         sMode24 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0K24( ) ;
         Gx_mode = sMode24;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0K24( )
      {
         standaloneModal0K24( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000K26 */
            pr_default.execute(24, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Relaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T000K27 */
            pr_default.execute(25, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Relaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T000K28 */
            pr_default.execute(26, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Historico Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T000K29 */
            pr_default.execute(27, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T000K30 */
            pr_default.execute(28, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T000K31 */
            pr_default.execute(29, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Metodo Pagos", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T000K32 */
            pr_default.execute(30, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Profesionales", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T000K33 */
            pr_default.execute(31, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Inventario", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
         }
      }

      protected void EndLevel0K24( )
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

      public void ScanStart0K24( )
      {
         /* Scan By routine */
         /* Using cursor T000K34 */
         pr_default.execute(32, new Object[] {A107EstadosTipo});
         RcdFound24 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound24 = 1;
            A108EstadosGenericosId = T000K34_A108EstadosGenericosId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0K24( )
      {
         /* Scan next routine */
         pr_default.readNext(32);
         RcdFound24 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound24 = 1;
            A108EstadosGenericosId = T000K34_A108EstadosGenericosId[0];
         }
      }

      protected void ScanEnd0K24( )
      {
         pr_default.close(32);
      }

      protected void AfterConfirm0K24( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0K24( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0K24( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0K24( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0K24( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0K24( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0K24( )
      {
         edtEstadosGenericosId_Enabled = 0;
         AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtEstadosGenericosNombre_Enabled = 0;
         AssignProp("", false, edtEstadosGenericosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0), !bGXsfl_33_Refreshing);
      }

      protected void send_integrity_lvl_hashes0K24( )
      {
      }

      protected void send_integrity_lvl_hashes0K23( )
      {
      }

      protected void SubsflControlProps_3324( )
      {
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_33_idx;
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE_"+sGXsfl_33_idx;
      }

      protected void SubsflControlProps_fel_3324( )
      {
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_33_fel_idx;
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE_"+sGXsfl_33_fel_idx;
      }

      protected void AddRow0K24( )
      {
         nGXsfl_33_idx = (int)(nGXsfl_33_idx+1);
         sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
         SubsflControlProps_3324( ) ;
         SendRow0K24( ) ;
      }

      protected void SendRow0K24( )
      {
         Gridlevel_genericosRow = GXWebRow.GetNew(context);
         if ( subGridlevel_genericos_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_genericos_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_genericos_Class, "") != 0 )
            {
               subGridlevel_genericos_Linesclass = subGridlevel_genericos_Class+"Odd";
            }
         }
         else if ( subGridlevel_genericos_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_genericos_Backstyle = 0;
            subGridlevel_genericos_Backcolor = subGridlevel_genericos_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_genericos_Class, "") != 0 )
            {
               subGridlevel_genericos_Linesclass = subGridlevel_genericos_Class+"Uniform";
            }
         }
         else if ( subGridlevel_genericos_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_genericos_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_genericos_Class, "") != 0 )
            {
               subGridlevel_genericos_Linesclass = subGridlevel_genericos_Class+"Odd";
            }
            subGridlevel_genericos_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_genericos_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_genericos_Backstyle = 1;
            if ( ((int)((nGXsfl_33_idx) % (2))) == 0 )
            {
               subGridlevel_genericos_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_genericos_Class, "") != 0 )
               {
                  subGridlevel_genericos_Linesclass = subGridlevel_genericos_Class+"Even";
               }
            }
            else
            {
               subGridlevel_genericos_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_genericos_Class, "") != 0 )
               {
                  subGridlevel_genericos_Linesclass = subGridlevel_genericos_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_24_" + sGXsfl_33_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_33_idx + "',33)\"";
         ROClassString = "Attribute";
         Gridlevel_genericosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtEstadosGenericosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9") : context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosGenericosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtEstadosGenericosId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_24_" + sGXsfl_33_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_33_idx + "',33)\"";
         ROClassString = "Attribute";
         Gridlevel_genericosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosNombre_Internalname,StringUtil.RTrim( A109EstadosGenericosNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosGenericosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtEstadosGenericosNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_genericosRow);
         send_integrity_lvl_hashes0K24( ) ;
         GXCCtl = "Z108EstadosGenericosId_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z109EstadosGenericosNombre_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z109EstadosGenericosNombre));
         GXCCtl = "nRcdDeleted_24_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_24), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_24_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_24), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_24_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_24), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_33_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vESTADOSTIPO_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( AV7EstadosTipo));
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSID_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSNOMBRE_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_genericosContainer.AddRow(Gridlevel_genericosRow);
      }

      protected void ReadRow0K24( )
      {
         nGXsfl_33_idx = (int)(nGXsfl_33_idx+1);
         sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
         SubsflControlProps_3324( ) ;
         edtEstadosGenericosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGENERICOSID_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtEstadosGenericosNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGENERICOSNOMBRE_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosGenericosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A109EstadosGenericosNombre = cgiGet( edtEstadosGenericosNombre_Internalname);
         GXCCtl = "Z108EstadosGenericosId_" + sGXsfl_33_idx;
         Z108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z109EstadosGenericosNombre_" + sGXsfl_33_idx;
         Z109EstadosGenericosNombre = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_24_" + sGXsfl_33_idx;
         nRcdDeleted_24 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_24_" + sGXsfl_33_idx;
         nRcdExists_24 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_24_" + sGXsfl_33_idx;
         nIsMod_24 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtEstadosGenericosId_Enabled = edtEstadosGenericosId_Enabled;
      }

      protected void ConfirmValues0K0( )
      {
         nGXsfl_33_idx = 0;
         sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
         SubsflControlProps_3324( ) ;
         while ( nGXsfl_33_idx < nRC_GXsfl_33 )
         {
            nGXsfl_33_idx = (int)(nGXsfl_33_idx+1);
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
            SubsflControlProps_3324( ) ;
            ChangePostValue( "Z108EstadosGenericosId_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z108EstadosGenericosId_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z108EstadosGenericosId_"+sGXsfl_33_idx) ;
            ChangePostValue( "Z109EstadosGenericosNombre_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z109EstadosGenericosNombre_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z109EstadosGenericosNombre_"+sGXsfl_33_idx) ;
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
         GXEncryptionTmp = "estados.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7EstadosTipo));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("estados.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Estados");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("estados:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z107EstadosTipo", StringUtil.RTrim( Z107EstadosTipo));
         GxWebStd.gx_hidden_field( context, "Z158EstadosDescrip", StringUtil.RTrim( Z158EstadosDescrip));
         GxWebStd.gx_hidden_field( context, "Z159EstadosAutoEnumerar", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z159EstadosAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O159EstadosAutoEnumerar", StringUtil.LTrim( StringUtil.NToC( (decimal)(O159EstadosAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_33", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_33_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vESTADOSTIPO", StringUtil.RTrim( AV7EstadosTipo));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOSTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7EstadosTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GXEncryptionTmp = "estados.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7EstadosTipo));
         return formatLink("estados.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Estados" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Estados", "") ;
      }

      protected void InitializeNonKey0K23( )
      {
         A158EstadosDescrip = "";
         AssignAttri("", false, "A158EstadosDescrip", A158EstadosDescrip);
         A159EstadosAutoEnumerar = 0;
         AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
         O159EstadosAutoEnumerar = A159EstadosAutoEnumerar;
         AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
         Z158EstadosDescrip = "";
         Z159EstadosAutoEnumerar = 0;
      }

      protected void InitAll0K23( )
      {
         A107EstadosTipo = "";
         AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
         InitializeNonKey0K23( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0K24( )
      {
         A109EstadosGenericosNombre = "";
         Z109EstadosGenericosNombre = "";
      }

      protected void InitAll0K24( )
      {
         A108EstadosGenericosId = 0;
         InitializeNonKey0K24( ) ;
      }

      protected void StandaloneModalInsert0K24( )
      {
         A159EstadosAutoEnumerar = i159EstadosAutoEnumerar;
         AssignAttri("", false, "A159EstadosAutoEnumerar", StringUtil.LTrimStr( (decimal)(A159EstadosAutoEnumerar), 4, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026730219761", true, true, false);
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
         context.AddJavascriptSource("estados.js", "?2026730219761", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties24( )
      {
         edtEstadosGenericosId_Enabled = defedtEstadosGenericosId_Enabled;
         AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), !bGXsfl_33_Refreshing);
      }

      protected void StartGridControl33( )
      {
         Gridlevel_genericosContainer.AddObjectProperty("GridName", "Gridlevel_genericos");
         Gridlevel_genericosContainer.AddObjectProperty("Header", subGridlevel_genericos_Header);
         Gridlevel_genericosContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_genericosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_genericosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_genericosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_genericos_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_genericosContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_genericosContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_genericosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_genericosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", ""))));
         Gridlevel_genericosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosId_Enabled), 5, 0, ".", "")));
         Gridlevel_genericosContainer.AddColumnProperties(Gridlevel_genericosColumn);
         Gridlevel_genericosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_genericosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A109EstadosGenericosNombre)));
         Gridlevel_genericosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_genericosContainer.AddColumnProperties(Gridlevel_genericosColumn);
         Gridlevel_genericosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_genericos_Selectedindex), 4, 0, ".", "")));
         Gridlevel_genericosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_genericos_Allowselection), 1, 0, ".", "")));
         Gridlevel_genericosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_genericos_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_genericosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_genericos_Allowhovering), 1, 0, ".", "")));
         Gridlevel_genericosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_genericos_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_genericosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_genericos_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_genericosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_genericos_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtEstadosTipo_Internalname = "ESTADOSTIPO";
         edtEstadosDescrip_Internalname = "ESTADOSDESCRIP";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID";
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE";
         divTableleaflevel_genericos_Internalname = "TABLELEAFLEVEL_GENERICOS";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtEstadosAutoEnumerar_Internalname = "ESTADOSAUTOENUMERAR";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_genericos_Internalname = "GRIDLEVEL_GENERICOS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_genericos_Allowcollapsing = 0;
         subGridlevel_genericos_Allowselection = 0;
         subGridlevel_genericos_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Estados", "");
         edtEstadosGenericosNombre_Jsonclick = "";
         edtEstadosGenericosId_Jsonclick = "";
         subGridlevel_genericos_Class = "WorkWith";
         subGridlevel_genericos_Backcolorstyle = 0;
         edtEstadosGenericosNombre_Enabled = 1;
         edtEstadosGenericosId_Enabled = 0;
         edtEstadosAutoEnumerar_Jsonclick = "";
         edtEstadosAutoEnumerar_Enabled = 0;
         edtEstadosAutoEnumerar_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtEstadosDescrip_Jsonclick = "";
         edtEstadosDescrip_Enabled = 1;
         edtEstadosTipo_Jsonclick = "";
         edtEstadosTipo_Enabled = 1;
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

      protected void gxnrGridlevel_genericos_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_3324( ) ;
         while ( nGXsfl_33_idx <= nRC_GXsfl_33 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0K24( ) ;
            standaloneModal0K24( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0K24( ) ;
            nGXsfl_33_idx = (int)(nGXsfl_33_idx+1);
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
            SubsflControlProps_3324( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_genericosContainer)) ;
         /* End function gxnrGridlevel_genericos_newrow */
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7EstadosTipo',fld:'vESTADOSTIPO',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7EstadosTipo',fld:'vESTADOSTIPO',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120K2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSTIPO","{handler:'Valid_Estadostipo',iparms:[]");
         setEventMetadata("VALID_ESTADOSTIPO",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSAUTOENUMERAR","{handler:'Valid_Estadosautoenumerar',iparms:[]");
         setEventMetadata("VALID_ESTADOSAUTOENUMERAR",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSGENERICOSID","{handler:'Valid_Estadosgenericosid',iparms:[]");
         setEventMetadata("VALID_ESTADOSGENERICOSID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Estadosgenericosnombre',iparms:[]");
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
         wcpOAV7EstadosTipo = "";
         Z107EstadosTipo = "";
         Z158EstadosDescrip = "";
         Z109EstadosGenericosNombre = "";
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
         A107EstadosTipo = "";
         A158EstadosDescrip = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_genericosContainer = new GXWebGrid( context);
         sMode24 = "";
         sStyleString = "";
         AV14Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode23 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A109EstadosGenericosNombre = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000K6_A107EstadosTipo = new string[] {""} ;
         T000K6_A158EstadosDescrip = new string[] {""} ;
         T000K6_A159EstadosAutoEnumerar = new short[1] ;
         T000K7_A107EstadosTipo = new string[] {""} ;
         T000K5_A107EstadosTipo = new string[] {""} ;
         T000K5_A158EstadosDescrip = new string[] {""} ;
         T000K5_A159EstadosAutoEnumerar = new short[1] ;
         T000K8_A107EstadosTipo = new string[] {""} ;
         T000K9_A107EstadosTipo = new string[] {""} ;
         T000K4_A107EstadosTipo = new string[] {""} ;
         T000K4_A158EstadosDescrip = new string[] {""} ;
         T000K4_A159EstadosAutoEnumerar = new short[1] ;
         T000K13_A153HistoricoSolicitudesID = new long[1] ;
         T000K13_A156HistoricoRelacionesId = new long[1] ;
         T000K14_A127SolicitudesID = new long[1] ;
         T000K14_A140RelacionesId = new long[1] ;
         T000K15_A153HistoricoSolicitudesID = new long[1] ;
         T000K16_A127SolicitudesID = new long[1] ;
         T000K17_A120ProfesionalesId = new string[] {""} ;
         T000K17_A121RubrosId = new short[1] ;
         T000K18_A121RubrosId = new short[1] ;
         T000K18_A137MedidasID = new long[1] ;
         T000K18_A135InventarioId = new long[1] ;
         T000K20_A107EstadosTipo = new string[] {""} ;
         T000K21_A107EstadosTipo = new string[] {""} ;
         T000K21_A108EstadosGenericosId = new int[1] ;
         T000K21_A109EstadosGenericosNombre = new string[] {""} ;
         T000K22_A107EstadosTipo = new string[] {""} ;
         T000K22_A108EstadosGenericosId = new int[1] ;
         T000K3_A107EstadosTipo = new string[] {""} ;
         T000K3_A108EstadosGenericosId = new int[1] ;
         T000K3_A109EstadosGenericosNombre = new string[] {""} ;
         T000K2_A107EstadosTipo = new string[] {""} ;
         T000K2_A108EstadosGenericosId = new int[1] ;
         T000K2_A109EstadosGenericosNombre = new string[] {""} ;
         T000K26_A153HistoricoSolicitudesID = new long[1] ;
         T000K26_A156HistoricoRelacionesId = new long[1] ;
         T000K27_A127SolicitudesID = new long[1] ;
         T000K27_A140RelacionesId = new long[1] ;
         T000K28_A153HistoricoSolicitudesID = new long[1] ;
         T000K29_A127SolicitudesID = new long[1] ;
         T000K30_A120ProfesionalesId = new string[] {""} ;
         T000K30_A121RubrosId = new short[1] ;
         T000K31_A128MetodoPagosID = new long[1] ;
         T000K32_A120ProfesionalesId = new string[] {""} ;
         T000K33_A121RubrosId = new short[1] ;
         T000K33_A137MedidasID = new long[1] ;
         T000K33_A135InventarioId = new long[1] ;
         T000K34_A107EstadosTipo = new string[] {""} ;
         T000K34_A108EstadosGenericosId = new int[1] ;
         Gridlevel_genericosRow = new GXWebRow();
         subGridlevel_genericos_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_genericosColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.estados__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estados__default(),
            new Object[][] {
                new Object[] {
               T000K2_A107EstadosTipo, T000K2_A108EstadosGenericosId, T000K2_A109EstadosGenericosNombre
               }
               , new Object[] {
               T000K3_A107EstadosTipo, T000K3_A108EstadosGenericosId, T000K3_A109EstadosGenericosNombre
               }
               , new Object[] {
               T000K4_A107EstadosTipo, T000K4_A158EstadosDescrip, T000K4_A159EstadosAutoEnumerar
               }
               , new Object[] {
               T000K5_A107EstadosTipo, T000K5_A158EstadosDescrip, T000K5_A159EstadosAutoEnumerar
               }
               , new Object[] {
               T000K6_A107EstadosTipo, T000K6_A158EstadosDescrip, T000K6_A159EstadosAutoEnumerar
               }
               , new Object[] {
               T000K7_A107EstadosTipo
               }
               , new Object[] {
               T000K8_A107EstadosTipo
               }
               , new Object[] {
               T000K9_A107EstadosTipo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000K13_A153HistoricoSolicitudesID, T000K13_A156HistoricoRelacionesId
               }
               , new Object[] {
               T000K14_A127SolicitudesID, T000K14_A140RelacionesId
               }
               , new Object[] {
               T000K15_A153HistoricoSolicitudesID
               }
               , new Object[] {
               T000K16_A127SolicitudesID
               }
               , new Object[] {
               T000K17_A120ProfesionalesId, T000K17_A121RubrosId
               }
               , new Object[] {
               T000K18_A121RubrosId, T000K18_A137MedidasID, T000K18_A135InventarioId
               }
               , new Object[] {
               }
               , new Object[] {
               T000K20_A107EstadosTipo
               }
               , new Object[] {
               T000K21_A107EstadosTipo, T000K21_A108EstadosGenericosId, T000K21_A109EstadosGenericosNombre
               }
               , new Object[] {
               T000K22_A107EstadosTipo, T000K22_A108EstadosGenericosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000K26_A153HistoricoSolicitudesID, T000K26_A156HistoricoRelacionesId
               }
               , new Object[] {
               T000K27_A127SolicitudesID, T000K27_A140RelacionesId
               }
               , new Object[] {
               T000K28_A153HistoricoSolicitudesID
               }
               , new Object[] {
               T000K29_A127SolicitudesID
               }
               , new Object[] {
               T000K30_A120ProfesionalesId, T000K30_A121RubrosId
               }
               , new Object[] {
               T000K31_A128MetodoPagosID
               }
               , new Object[] {
               T000K32_A120ProfesionalesId
               }
               , new Object[] {
               T000K33_A121RubrosId, T000K33_A137MedidasID, T000K33_A135InventarioId
               }
               , new Object[] {
               T000K34_A107EstadosTipo, T000K34_A108EstadosGenericosId
               }
            }
         );
         AV14Pgmname = "Estados";
      }

      private short Z159EstadosAutoEnumerar ;
      private short O159EstadosAutoEnumerar ;
      private short nRcdDeleted_24 ;
      private short nRcdExists_24 ;
      private short nIsMod_24 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A159EstadosAutoEnumerar ;
      private short Gx_BScreen ;
      private short nBlankRcdCount24 ;
      private short RcdFound24 ;
      private short B159EstadosAutoEnumerar ;
      private short nBlankRcdUsr24 ;
      private short RcdFound23 ;
      private short s159EstadosAutoEnumerar ;
      private short nIsDirty_24 ;
      private short subGridlevel_genericos_Backcolorstyle ;
      private short subGridlevel_genericos_Backstyle ;
      private short gxajaxcallmode ;
      private short i159EstadosAutoEnumerar ;
      private short subGridlevel_genericos_Allowselection ;
      private short subGridlevel_genericos_Allowhovering ;
      private short subGridlevel_genericos_Allowcollapsing ;
      private short subGridlevel_genericos_Collapsed ;
      private int nRC_GXsfl_33 ;
      private int nGXsfl_33_idx=1 ;
      private int Z108EstadosGenericosId ;
      private int trnEnded ;
      private int edtEstadosTipo_Enabled ;
      private int edtEstadosDescrip_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtEstadosAutoEnumerar_Enabled ;
      private int edtEstadosAutoEnumerar_Visible ;
      private int edtEstadosGenericosId_Enabled ;
      private int edtEstadosGenericosNombre_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int A108EstadosGenericosId ;
      private int subGridlevel_genericos_Backcolor ;
      private int subGridlevel_genericos_Allbackcolor ;
      private int defedtEstadosGenericosId_Enabled ;
      private int idxLst ;
      private int subGridlevel_genericos_Selectedindex ;
      private int subGridlevel_genericos_Selectioncolor ;
      private int subGridlevel_genericos_Hoveringcolor ;
      private long GRIDLEVEL_GENERICOS_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV7EstadosTipo ;
      private string Z107EstadosTipo ;
      private string Z158EstadosDescrip ;
      private string Z109EstadosGenericosNombre ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV7EstadosTipo ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEstadosTipo_Internalname ;
      private string sGXsfl_33_idx="0001" ;
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
      private string A107EstadosTipo ;
      private string edtEstadosTipo_Jsonclick ;
      private string edtEstadosDescrip_Internalname ;
      private string A158EstadosDescrip ;
      private string edtEstadosDescrip_Jsonclick ;
      private string divTableleaflevel_genericos_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtEstadosAutoEnumerar_Internalname ;
      private string edtEstadosAutoEnumerar_Jsonclick ;
      private string sMode24 ;
      private string edtEstadosGenericosId_Internalname ;
      private string edtEstadosGenericosNombre_Internalname ;
      private string sStyleString ;
      private string subGridlevel_genericos_Internalname ;
      private string AV14Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode23 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A109EstadosGenericosNombre ;
      private string GXEncryptionTmp ;
      private string sGXsfl_33_fel_idx="0001" ;
      private string subGridlevel_genericos_Class ;
      private string subGridlevel_genericos_Linesclass ;
      private string ROClassString ;
      private string edtEstadosGenericosId_Jsonclick ;
      private string edtEstadosGenericosNombre_Jsonclick ;
      private string GXCCtl ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_genericos_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool bGXsfl_33_Refreshing=false ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_genericosContainer ;
      private GXWebRow Gridlevel_genericosRow ;
      private GXWebColumn Gridlevel_genericosColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private string[] T000K6_A107EstadosTipo ;
      private string[] T000K6_A158EstadosDescrip ;
      private short[] T000K6_A159EstadosAutoEnumerar ;
      private string[] T000K7_A107EstadosTipo ;
      private string[] T000K5_A107EstadosTipo ;
      private string[] T000K5_A158EstadosDescrip ;
      private short[] T000K5_A159EstadosAutoEnumerar ;
      private string[] T000K8_A107EstadosTipo ;
      private string[] T000K9_A107EstadosTipo ;
      private string[] T000K4_A107EstadosTipo ;
      private string[] T000K4_A158EstadosDescrip ;
      private short[] T000K4_A159EstadosAutoEnumerar ;
      private long[] T000K13_A153HistoricoSolicitudesID ;
      private long[] T000K13_A156HistoricoRelacionesId ;
      private long[] T000K14_A127SolicitudesID ;
      private long[] T000K14_A140RelacionesId ;
      private long[] T000K15_A153HistoricoSolicitudesID ;
      private long[] T000K16_A127SolicitudesID ;
      private string[] T000K17_A120ProfesionalesId ;
      private short[] T000K17_A121RubrosId ;
      private short[] T000K18_A121RubrosId ;
      private long[] T000K18_A137MedidasID ;
      private long[] T000K18_A135InventarioId ;
      private string[] T000K20_A107EstadosTipo ;
      private string[] T000K21_A107EstadosTipo ;
      private int[] T000K21_A108EstadosGenericosId ;
      private string[] T000K21_A109EstadosGenericosNombre ;
      private string[] T000K22_A107EstadosTipo ;
      private int[] T000K22_A108EstadosGenericosId ;
      private string[] T000K3_A107EstadosTipo ;
      private int[] T000K3_A108EstadosGenericosId ;
      private string[] T000K3_A109EstadosGenericosNombre ;
      private string[] T000K2_A107EstadosTipo ;
      private int[] T000K2_A108EstadosGenericosId ;
      private string[] T000K2_A109EstadosGenericosNombre ;
      private long[] T000K26_A153HistoricoSolicitudesID ;
      private long[] T000K26_A156HistoricoRelacionesId ;
      private long[] T000K27_A127SolicitudesID ;
      private long[] T000K27_A140RelacionesId ;
      private long[] T000K28_A153HistoricoSolicitudesID ;
      private long[] T000K29_A127SolicitudesID ;
      private string[] T000K30_A120ProfesionalesId ;
      private short[] T000K30_A121RubrosId ;
      private long[] T000K31_A128MetodoPagosID ;
      private string[] T000K32_A120ProfesionalesId ;
      private short[] T000K33_A121RubrosId ;
      private long[] T000K33_A137MedidasID ;
      private long[] T000K33_A135InventarioId ;
      private string[] T000K34_A107EstadosTipo ;
      private int[] T000K34_A108EstadosGenericosId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class estados__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class estados__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000K2;
        prmT000K2 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000K3;
        prmT000K3 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000K4;
        prmT000K4 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000K5;
        prmT000K5 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000K6;
        prmT000K6 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000K7;
        prmT000K7 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000K8;
        prmT000K8 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000K9;
        prmT000K9 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000K10;
        prmT000K10 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosDescrip",GXType.NChar,80,0) ,
        new ParDef("@EstadosAutoEnumerar",GXType.Int16,4,0)
        };
        Object[] prmT000K11;
        prmT000K11 = new Object[] {
        new ParDef("@EstadosDescrip",GXType.NChar,80,0) ,
        new ParDef("@EstadosAutoEnumerar",GXType.Int16,4,0) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000K12;
        prmT000K12 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000K13;
        prmT000K13 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000K14;
        prmT000K14 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000K15;
        prmT000K15 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000K16;
        prmT000K16 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000K17;
        prmT000K17 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000K18;
        prmT000K18 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000K19;
        prmT000K19 = new Object[] {
        new ParDef("@EstadosAutoEnumerar",GXType.Int16,4,0) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000K20;
        prmT000K20 = new Object[] {
        };
        Object[] prmT000K21;
        prmT000K21 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000K22;
        prmT000K22 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000K23;
        prmT000K23 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0) ,
        new ParDef("@EstadosGenericosNombre",GXType.NChar,80,0)
        };
        Object[] prmT000K24;
        prmT000K24 = new Object[] {
        new ParDef("@EstadosGenericosNombre",GXType.NChar,80,0) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000K25;
        prmT000K25 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000K26;
        prmT000K26 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000K27;
        prmT000K27 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000K28;
        prmT000K28 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000K29;
        prmT000K29 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000K30;
        prmT000K30 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000K31;
        prmT000K31 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000K32;
        prmT000K32 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000K33;
        prmT000K33 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000K34;
        prmT000K34 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000K2", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] WITH (UPDLOCK) WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K3", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K4", "SELECT [EstadosTipo], [EstadosDescrip], [EstadosAutoEnumerar] FROM [Estados] WITH (UPDLOCK) WHERE [EstadosTipo] = @EstadosTipo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K5", "SELECT [EstadosTipo], [EstadosDescrip], [EstadosAutoEnumerar] FROM [Estados] WHERE [EstadosTipo] = @EstadosTipo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K6", "SELECT TM1.[EstadosTipo], TM1.[EstadosDescrip], TM1.[EstadosAutoEnumerar] FROM [Estados] TM1 WHERE TM1.[EstadosTipo] = @EstadosTipo ORDER BY TM1.[EstadosTipo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000K6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K7", "SELECT [EstadosTipo] FROM [Estados] WHERE [EstadosTipo] = @EstadosTipo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000K7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K8", "SELECT TOP 1 [EstadosTipo] FROM [Estados] WHERE ( [EstadosTipo] > @EstadosTipo) ORDER BY [EstadosTipo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000K8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K9", "SELECT TOP 1 [EstadosTipo] FROM [Estados] WHERE ( [EstadosTipo] < @EstadosTipo) ORDER BY [EstadosTipo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000K9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K10", "INSERT INTO [Estados]([EstadosTipo], [EstadosDescrip], [EstadosAutoEnumerar]) VALUES(@EstadosTipo, @EstadosDescrip, @EstadosAutoEnumerar)", GxErrorMask.GX_NOMASK,prmT000K10)
           ,new CursorDef("T000K11", "UPDATE [Estados] SET [EstadosDescrip]=@EstadosDescrip, [EstadosAutoEnumerar]=@EstadosAutoEnumerar  WHERE [EstadosTipo] = @EstadosTipo", GxErrorMask.GX_NOMASK,prmT000K11)
           ,new CursorDef("T000K12", "DELETE FROM [Estados]  WHERE [EstadosTipo] = @EstadosTipo", GxErrorMask.GX_NOMASK,prmT000K12)
           ,new CursorDef("T000K13", "SELECT TOP 1 [HistoricoSolicitudesID], [HistoricoRelacionesId] FROM [HistoricoRelacionesRelaciones] WHERE [EstadoSGTipo] = @EstadosTipo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K14", "SELECT TOP 1 [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE [EstadoSGTipo] = @EstadosTipo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K15", "SELECT TOP 1 [HistoricoSolicitudesID] FROM [HistoricoSolicitudes] WHERE [EstadosSolTipo] = @EstadosTipo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K16", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [EstadosSolTipo] = @EstadosTipo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K17", "SELECT TOP 1 [ProfesionalesId], [RubrosId] FROM [ProfesionalesRubros] WHERE [EstadosProfRubTipo] = @EstadosTipo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K18", "SELECT TOP 1 [RubrosId], [MedidasID], [InventarioId] FROM [Inventario] WHERE [EstadosTipo] = @EstadosTipo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K19", "UPDATE [Estados] SET [EstadosAutoEnumerar]=@EstadosAutoEnumerar  WHERE [EstadosTipo] = @EstadosTipo", GxErrorMask.GX_NOMASK,prmT000K19)
           ,new CursorDef("T000K20", "SELECT [EstadosTipo] FROM [Estados] ORDER BY [EstadosTipo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000K20,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K21", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo and [EstadosGenericosId] = @EstadosGenericosId ORDER BY [EstadosTipo], [EstadosGenericosId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K21,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K22", "SELECT [EstadosTipo], [EstadosGenericosId] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K23", "INSERT INTO [EstadosGenericos]([EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre], [EstadosNotificacionCliente], [EstadosNotificacionProfesional], [EstadosNotificacionOperador]) VALUES(@EstadosTipo, @EstadosGenericosId, @EstadosGenericosNombre, '', '', '')", GxErrorMask.GX_NOMASK,prmT000K23)
           ,new CursorDef("T000K24", "UPDATE [EstadosGenericos] SET [EstadosGenericosNombre]=@EstadosGenericosNombre  WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId", GxErrorMask.GX_NOMASK,prmT000K24)
           ,new CursorDef("T000K25", "DELETE FROM [EstadosGenericos]  WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId", GxErrorMask.GX_NOMASK,prmT000K25)
           ,new CursorDef("T000K26", "SELECT TOP 1 [HistoricoSolicitudesID], [HistoricoRelacionesId] FROM [HistoricoRelacionesRelaciones] WHERE [EstadoSGTipo] = @EstadosTipo AND [EstadoSGId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K27", "SELECT TOP 1 [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE [EstadoSGTipo] = @EstadosTipo AND [EstadoSGId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K28", "SELECT TOP 1 [HistoricoSolicitudesID] FROM [HistoricoSolicitudes] WHERE [EstadosSolTipo] = @EstadosTipo AND [EstadosSolId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K29", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [EstadosSolTipo] = @EstadosTipo AND [EstadosSolId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K30", "SELECT TOP 1 [ProfesionalesId], [RubrosId] FROM [ProfesionalesRubros] WHERE [EstadosProfRubTipo] = @EstadosTipo AND [EstadosProfRubId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K31", "SELECT TOP 1 [MetodoPagosID] FROM [MetodoPagos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K31,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K32", "SELECT TOP 1 [ProfesionalesId] FROM [Profesionales] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K32,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K33", "SELECT TOP 1 [RubrosId], [MedidasID], [InventarioId] FROM [Inventario] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K33,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K34", "SELECT [EstadosTipo], [EstadosGenericosId] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo ORDER BY [EstadosTipo], [EstadosGenericosId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K34,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 16 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 28 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 31 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
     }
  }

}

}
