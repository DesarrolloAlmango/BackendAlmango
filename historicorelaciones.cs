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
   public class historicorelaciones : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"ESTADOSGID") == 0 )
         {
            A141EstadoSGTipo = GetPar( "EstadoSGTipo");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAESTADOSGID1244( A141EstadoSGTipo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A141EstadoSGTipo = GetPar( "EstadoSGTipo");
            A142EstadoSGId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadoSGId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A141EstadoSGTipo, A142EstadoSGId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_relaciones") == 0 )
         {
            gxnrGridlevel_relaciones_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "historicorelaciones.aspx")), "historicorelaciones.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "historicorelaciones.aspx")))) ;
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
                  AV10HistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "HistoricoSolicitudesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV10HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(AV10HistoricoSolicitudesID), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vHISTORICOSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Historico Relaciones", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_relaciones_newrow_invoke( )
      {
         nRC_GXsfl_33 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_33"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_33_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_33_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_33_idx = GetPar( "sGXsfl_33_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_relaciones_newrow( ) ;
         /* End function gxnrGridlevel_relaciones_newrow_invoke */
      }

      public historicorelaciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public historicorelaciones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_HistoricoSolicitudesID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV10HistoricoSolicitudesID = aP1_HistoricoSolicitudesID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynEstadoSGId = new GXCombobox();
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesID_Internalname, context.GetMessage( "Solicitudes ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A153HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A153HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesID_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_HistoricoRelaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesNombre_Internalname, context.GetMessage( "Solicitudes Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesNombre_Internalname, StringUtil.RTrim( A288HistoricoSolicitudesNombre), StringUtil.RTrim( context.localUtil.Format( A288HistoricoSolicitudesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoRelaciones.htm");
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
         GxWebStd.gx_div_start( context, divTableleaflevel_relaciones_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_relaciones( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoricoRelaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoricoRelaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoricoRelaciones.htm");
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

      protected void gxdraw_Gridlevel_relaciones( )
      {
         /*  Grid Control  */
         StartGridControl33( ) ;
         nGXsfl_33_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount44 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_44 = 1;
               ScanStart1244( ) ;
               while ( RcdFound44 != 0 )
               {
                  init_level_properties44( ) ;
                  getByPrimaryKey1244( ) ;
                  AddRow1244( ) ;
                  ScanNext1244( ) ;
               }
               ScanEnd1244( ) ;
               nBlankRcdCount44 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1244( ) ;
            standaloneModal1244( ) ;
            sMode44 = Gx_mode;
            while ( nGXsfl_33_idx < nRC_GXsfl_33 )
            {
               bGXsfl_33_Refreshing = true;
               ReadRow1244( ) ;
               edtHistoricoRelacionesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICORELACIONESID_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHistoricoRelacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoRelacionesId_Enabled), 5, 0), !bGXsfl_33_Refreshing);
               edtHistoricoRelacionesProfesional_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICORELACIONESPROFESIONAL_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHistoricoRelacionesProfesional_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoRelacionesProfesional_Enabled), 5, 0), !bGXsfl_33_Refreshing);
               edtHistoricoRelacionesNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICORELACIONESNOMBRE_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHistoricoRelacionesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoRelacionesNombre_Enabled), 5, 0), !bGXsfl_33_Refreshing);
               edtHistoricoRelacionesApellido_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICORELACIONESAPELLIDO_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHistoricoRelacionesApellido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoRelacionesApellido_Enabled), 5, 0), !bGXsfl_33_Refreshing);
               edtEstadoSGTipo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGTIPO_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtEstadoSGTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoSGTipo_Enabled), 5, 0), !bGXsfl_33_Refreshing);
               dynEstadoSGId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGID_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynEstadoSGId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadoSGId.Enabled), 5, 0), !bGXsfl_33_Refreshing);
               edtHistoricoRelacionesFechaAlta_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICORELACIONESFECHAALTA_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHistoricoRelacionesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoRelacionesFechaAlta_Enabled), 5, 0), !bGXsfl_33_Refreshing);
               edtHistoricoRelacionesFechaModif_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICORELACIONESFECHAMODIF_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHistoricoRelacionesFechaModif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoRelacionesFechaModif_Enabled), 5, 0), !bGXsfl_33_Refreshing);
               imgprompt_141_142_Link = cgiGet( "PROMPT_141_142_"+sGXsfl_33_idx+"Link");
               if ( ( nRcdExists_44 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1244( ) ;
               }
               SendRow1244( ) ;
               bGXsfl_33_Refreshing = false;
            }
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount44 = 5;
            nRcdExists_44 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1244( ) ;
               while ( RcdFound44 != 0 )
               {
                  sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_3344( ) ;
                  init_level_properties44( ) ;
                  standaloneNotModal1244( ) ;
                  getByPrimaryKey1244( ) ;
                  standaloneModal1244( ) ;
                  AddRow1244( ) ;
                  ScanNext1244( ) ;
               }
               ScanEnd1244( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode44 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx+1), 4, 0), 4, "0");
            SubsflControlProps_3344( ) ;
            InitAll1244( ) ;
            init_level_properties44( ) ;
            nRcdExists_44 = 0;
            nIsMod_44 = 0;
            nRcdDeleted_44 = 0;
            nBlankRcdCount44 = (short)(nBlankRcdUsr44+nBlankRcdCount44);
            fRowAdded = 0;
            while ( nBlankRcdCount44 > 0 )
            {
               standaloneNotModal1244( ) ;
               standaloneModal1244( ) ;
               AddRow1244( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtHistoricoRelacionesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount44 = (short)(nBlankRcdCount44-1);
            }
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_relacionesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_relaciones", Gridlevel_relacionesContainer, subGridlevel_relaciones_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_relacionesContainerData", Gridlevel_relacionesContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_relacionesContainerData"+"V", Gridlevel_relacionesContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_relacionesContainerData"+"V"+"\" value='"+Gridlevel_relacionesContainer.GridValuesHidden()+"'/>") ;
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
         E11122 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z153HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z153HistoricoSolicitudesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z288HistoricoSolicitudesNombre = cgiGet( "Z288HistoricoSolicitudesNombre");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_33 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_33"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV10HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vHISTORICOSOLICITUDESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV20Pgmname = cgiGet( "vPGMNAME");
               A143EstadoSGNombre = cgiGet( "ESTADOSGNOMBRE");
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HISTORICOSOLICITUDESID");
                  AnyError = 1;
                  GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A153HistoricoSolicitudesID = 0;
                  AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
               }
               else
               {
                  A153HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
               }
               A288HistoricoSolicitudesNombre = cgiGet( edtHistoricoSolicitudesNombre_Internalname);
               AssignAttri("", false, "A288HistoricoSolicitudesNombre", A288HistoricoSolicitudesNombre);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"HistoricoRelaciones");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A153HistoricoSolicitudesID != Z153HistoricoSolicitudesID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("historicorelaciones:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A153HistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "HistoricoSolicitudesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
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
                     sMode42 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode42;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound42 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_120( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "HISTORICOSOLICITUDESID");
                        AnyError = 1;
                        GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
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
                           E11122 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12122 ();
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
            E12122 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1242( ) ;
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
            DisableAttributes1242( ) ;
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

      protected void CONFIRM_120( )
      {
         BeforeValidate1242( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1242( ) ;
            }
            else
            {
               CheckExtendedTable1242( ) ;
               CloseExtendedTableCursors1242( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode42 = Gx_mode;
            CONFIRM_1244( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode42;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_1244( )
      {
         nGXsfl_33_idx = 0;
         while ( nGXsfl_33_idx < nRC_GXsfl_33 )
         {
            ReadRow1244( ) ;
            if ( ( nRcdExists_44 != 0 ) || ( nIsMod_44 != 0 ) )
            {
               GetKey1244( ) ;
               if ( ( nRcdExists_44 == 0 ) && ( nRcdDeleted_44 == 0 ) )
               {
                  if ( RcdFound44 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1244( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1244( ) ;
                        CloseExtendedTableCursors1244( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "HISTORICORELACIONESID_" + sGXsfl_33_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtHistoricoRelacionesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound44 != 0 )
                  {
                     if ( nRcdDeleted_44 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1244( ) ;
                        Load1244( ) ;
                        BeforeValidate1244( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1244( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_44 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1244( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1244( ) ;
                              CloseExtendedTableCursors1244( ) ;
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
                     if ( nRcdDeleted_44 == 0 )
                     {
                        GXCCtl = "HISTORICORELACIONESID_" + sGXsfl_33_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtHistoricoRelacionesId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtHistoricoRelacionesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A156HistoricoRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHistoricoRelacionesProfesional_Internalname, StringUtil.RTrim( A320HistoricoRelacionesProfesional)) ;
            ChangePostValue( edtHistoricoRelacionesNombre_Internalname, StringUtil.RTrim( A323HistoricoRelacionesNombre)) ;
            ChangePostValue( edtHistoricoRelacionesApellido_Internalname, StringUtil.RTrim( A324HistoricoRelacionesApellido)) ;
            ChangePostValue( edtEstadoSGTipo_Internalname, StringUtil.RTrim( A141EstadoSGTipo)) ;
            ChangePostValue( dynEstadoSGId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A142EstadoSGId), 5, 0, ".", ""))) ;
            ChangePostValue( edtHistoricoRelacionesFechaAlta_Internalname, context.localUtil.TToC( A321HistoricoRelacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( edtHistoricoRelacionesFechaModif_Internalname, context.localUtil.TToC( A322HistoricoRelacionesFechaModif, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z156HistoricoRelacionesId_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z156HistoricoRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z320HistoricoRelacionesProfesional_"+sGXsfl_33_idx, StringUtil.RTrim( Z320HistoricoRelacionesProfesional)) ;
            ChangePostValue( "ZT_"+"Z323HistoricoRelacionesNombre_"+sGXsfl_33_idx, StringUtil.RTrim( Z323HistoricoRelacionesNombre)) ;
            ChangePostValue( "ZT_"+"Z324HistoricoRelacionesApellido_"+sGXsfl_33_idx, StringUtil.RTrim( Z324HistoricoRelacionesApellido)) ;
            ChangePostValue( "ZT_"+"Z321HistoricoRelacionesFechaAlta_"+sGXsfl_33_idx, context.localUtil.TToC( Z321HistoricoRelacionesFechaAlta, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z322HistoricoRelacionesFechaModif_"+sGXsfl_33_idx, context.localUtil.TToC( Z322HistoricoRelacionesFechaModif, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z141EstadoSGTipo_"+sGXsfl_33_idx, StringUtil.RTrim( Z141EstadoSGTipo)) ;
            ChangePostValue( "ZT_"+"Z142EstadoSGId_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z142EstadoSGId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_44_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_44), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_44_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_44), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_44_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_44), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_44 != 0 )
            {
               ChangePostValue( "HISTORICORELACIONESID_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICORELACIONESPROFESIONAL_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesProfesional_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICORELACIONESNOMBRE_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICORELACIONESAPELLIDO_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesApellido_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGTIPO_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoSGTipo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGID_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadoSGId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICORELACIONESFECHAALTA_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesFechaAlta_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICORELACIONESFECHAMODIF_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesFechaModif_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption120( )
      {
      }

      protected void E11122( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV11WWPContext) ;
         AV7IsAuthorized = true;
         AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoRelaciones_Insert", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoRelaciones_Update", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoRelaciones_Delete", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         }
         if ( ! AV7IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV20Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV8TrnContext.FromXml(AV9WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12122( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1242( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z288HistoricoSolicitudesNombre = T00126_A288HistoricoSolicitudesNombre[0];
            }
            else
            {
               Z288HistoricoSolicitudesNombre = A288HistoricoSolicitudesNombre;
            }
         }
         if ( GX_JID == -7 )
         {
            Z153HistoricoSolicitudesID = A153HistoricoSolicitudesID;
            Z288HistoricoSolicitudesNombre = A288HistoricoSolicitudesNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV10HistoricoSolicitudesID) )
         {
            A153HistoricoSolicitudesID = AV10HistoricoSolicitudesID;
            AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
         }
         if ( ! (0==AV10HistoricoSolicitudesID) )
         {
            edtHistoricoSolicitudesID_Enabled = 0;
            AssignProp("", false, edtHistoricoSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesID_Enabled), 5, 0), true);
         }
         else
         {
            edtHistoricoSolicitudesID_Enabled = 1;
            AssignProp("", false, edtHistoricoSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesID_Enabled), 5, 0), true);
         }
         if ( ! (0==AV10HistoricoSolicitudesID) )
         {
            edtHistoricoSolicitudesID_Enabled = 0;
            AssignProp("", false, edtHistoricoSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesID_Enabled), 5, 0), true);
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
            AV20Pgmname = "HistoricoRelaciones";
            AssignAttri("", false, "AV20Pgmname", AV20Pgmname);
         }
      }

      protected void Load1242( )
      {
         /* Using cursor T00127 */
         pr_default.execute(5, new Object[] {A153HistoricoSolicitudesID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound42 = 1;
            A288HistoricoSolicitudesNombre = T00127_A288HistoricoSolicitudesNombre[0];
            AssignAttri("", false, "A288HistoricoSolicitudesNombre", A288HistoricoSolicitudesNombre);
            ZM1242( -7) ;
         }
         pr_default.close(5);
         OnLoadActions1242( ) ;
      }

      protected void OnLoadActions1242( )
      {
         AV20Pgmname = "HistoricoRelaciones";
         AssignAttri("", false, "AV20Pgmname", AV20Pgmname);
      }

      protected void CheckExtendedTable1242( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV20Pgmname = "HistoricoRelaciones";
         AssignAttri("", false, "AV20Pgmname", AV20Pgmname);
      }

      protected void CloseExtendedTableCursors1242( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1242( )
      {
         /* Using cursor T00128 */
         pr_default.execute(6, new Object[] {A153HistoricoSolicitudesID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound42 = 1;
         }
         else
         {
            RcdFound42 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00126 */
         pr_default.execute(4, new Object[] {A153HistoricoSolicitudesID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM1242( 7) ;
            RcdFound42 = 1;
            A153HistoricoSolicitudesID = T00126_A153HistoricoSolicitudesID[0];
            AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
            A288HistoricoSolicitudesNombre = T00126_A288HistoricoSolicitudesNombre[0];
            AssignAttri("", false, "A288HistoricoSolicitudesNombre", A288HistoricoSolicitudesNombre);
            Z153HistoricoSolicitudesID = A153HistoricoSolicitudesID;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1242( ) ;
            if ( AnyError == 1 )
            {
               RcdFound42 = 0;
               InitializeNonKey1242( ) ;
            }
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound42 = 0;
            InitializeNonKey1242( ) ;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey1242( ) ;
         if ( RcdFound42 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound42 = 0;
         /* Using cursor T00129 */
         pr_default.execute(7, new Object[] {A153HistoricoSolicitudesID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00129_A153HistoricoSolicitudesID[0] < A153HistoricoSolicitudesID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00129_A153HistoricoSolicitudesID[0] > A153HistoricoSolicitudesID ) ) )
            {
               A153HistoricoSolicitudesID = T00129_A153HistoricoSolicitudesID[0];
               AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
               RcdFound42 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound42 = 0;
         /* Using cursor T001210 */
         pr_default.execute(8, new Object[] {A153HistoricoSolicitudesID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001210_A153HistoricoSolicitudesID[0] > A153HistoricoSolicitudesID ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001210_A153HistoricoSolicitudesID[0] < A153HistoricoSolicitudesID ) ) )
            {
               A153HistoricoSolicitudesID = T001210_A153HistoricoSolicitudesID[0];
               AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
               RcdFound42 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1242( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1242( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound42 == 1 )
            {
               if ( A153HistoricoSolicitudesID != Z153HistoricoSolicitudesID )
               {
                  A153HistoricoSolicitudesID = Z153HistoricoSolicitudesID;
                  AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "HISTORICOSOLICITUDESID");
                  AnyError = 1;
                  GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1242( ) ;
                  GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A153HistoricoSolicitudesID != Z153HistoricoSolicitudesID )
               {
                  /* Insert record */
                  GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1242( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "HISTORICOSOLICITUDESID");
                     AnyError = 1;
                     GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1242( ) ;
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
         if ( A153HistoricoSolicitudesID != Z153HistoricoSolicitudesID )
         {
            A153HistoricoSolicitudesID = Z153HistoricoSolicitudesID;
            AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "HISTORICOSOLICITUDESID");
            AnyError = 1;
            GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1242( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00125 */
            pr_default.execute(3, new Object[] {A153HistoricoSolicitudesID});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HistoricoSolicitudes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z288HistoricoSolicitudesNombre, T00125_A288HistoricoSolicitudesNombre[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z288HistoricoSolicitudesNombre, T00125_A288HistoricoSolicitudesNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("historicorelaciones:[seudo value changed for attri]"+"HistoricoSolicitudesNombre");
                  GXUtil.WriteLogRaw("Old: ",Z288HistoricoSolicitudesNombre);
                  GXUtil.WriteLogRaw("Current: ",T00125_A288HistoricoSolicitudesNombre[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"HistoricoSolicitudes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1242( )
      {
         BeforeValidate1242( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1242( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1242( 0) ;
            CheckOptimisticConcurrency1242( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1242( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1242( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001211 */
                     pr_default.execute(9, new Object[] {A153HistoricoSolicitudesID, A288HistoricoSolicitudesNombre});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("HistoricoSolicitudes");
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
                           ProcessLevel1242( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption120( ) ;
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
               Load1242( ) ;
            }
            EndLevel1242( ) ;
         }
         CloseExtendedTableCursors1242( ) ;
      }

      protected void Update1242( )
      {
         BeforeValidate1242( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1242( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1242( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1242( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1242( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001212 */
                     pr_default.execute(10, new Object[] {A288HistoricoSolicitudesNombre, A153HistoricoSolicitudesID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("HistoricoSolicitudes");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HistoricoSolicitudes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1242( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1242( ) ;
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
            EndLevel1242( ) ;
         }
         CloseExtendedTableCursors1242( ) ;
      }

      protected void DeferredUpdate1242( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1242( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1242( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1242( ) ;
            AfterConfirm1242( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1242( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1244( ) ;
                  while ( RcdFound44 != 0 )
                  {
                     getByPrimaryKey1244( ) ;
                     Delete1244( ) ;
                     ScanNext1244( ) ;
                  }
                  ScanEnd1244( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001213 */
                     pr_default.execute(11, new Object[] {A153HistoricoSolicitudesID});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("HistoricoSolicitudes");
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
         sMode42 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1242( ) ;
         Gx_mode = sMode42;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1242( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV20Pgmname = "HistoricoRelaciones";
            AssignAttri("", false, "AV20Pgmname", AV20Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001214 */
            pr_default.execute(12, new Object[] {A153HistoricoSolicitudesID});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Items", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void ProcessNestedLevel1244( )
      {
         nGXsfl_33_idx = 0;
         while ( nGXsfl_33_idx < nRC_GXsfl_33 )
         {
            ReadRow1244( ) ;
            if ( ( nRcdExists_44 != 0 ) || ( nIsMod_44 != 0 ) )
            {
               standaloneNotModal1244( ) ;
               GetKey1244( ) ;
               if ( ( nRcdExists_44 == 0 ) && ( nRcdDeleted_44 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1244( ) ;
               }
               else
               {
                  if ( RcdFound44 != 0 )
                  {
                     if ( ( nRcdDeleted_44 != 0 ) && ( nRcdExists_44 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1244( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_44 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1244( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_44 == 0 )
                     {
                        GXCCtl = "HISTORICORELACIONESID_" + sGXsfl_33_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtHistoricoRelacionesId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtHistoricoRelacionesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A156HistoricoRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHistoricoRelacionesProfesional_Internalname, StringUtil.RTrim( A320HistoricoRelacionesProfesional)) ;
            ChangePostValue( edtHistoricoRelacionesNombre_Internalname, StringUtil.RTrim( A323HistoricoRelacionesNombre)) ;
            ChangePostValue( edtHistoricoRelacionesApellido_Internalname, StringUtil.RTrim( A324HistoricoRelacionesApellido)) ;
            ChangePostValue( edtEstadoSGTipo_Internalname, StringUtil.RTrim( A141EstadoSGTipo)) ;
            ChangePostValue( dynEstadoSGId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A142EstadoSGId), 5, 0, ".", ""))) ;
            ChangePostValue( edtHistoricoRelacionesFechaAlta_Internalname, context.localUtil.TToC( A321HistoricoRelacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( edtHistoricoRelacionesFechaModif_Internalname, context.localUtil.TToC( A322HistoricoRelacionesFechaModif, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z156HistoricoRelacionesId_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z156HistoricoRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z320HistoricoRelacionesProfesional_"+sGXsfl_33_idx, StringUtil.RTrim( Z320HistoricoRelacionesProfesional)) ;
            ChangePostValue( "ZT_"+"Z323HistoricoRelacionesNombre_"+sGXsfl_33_idx, StringUtil.RTrim( Z323HistoricoRelacionesNombre)) ;
            ChangePostValue( "ZT_"+"Z324HistoricoRelacionesApellido_"+sGXsfl_33_idx, StringUtil.RTrim( Z324HistoricoRelacionesApellido)) ;
            ChangePostValue( "ZT_"+"Z321HistoricoRelacionesFechaAlta_"+sGXsfl_33_idx, context.localUtil.TToC( Z321HistoricoRelacionesFechaAlta, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z322HistoricoRelacionesFechaModif_"+sGXsfl_33_idx, context.localUtil.TToC( Z322HistoricoRelacionesFechaModif, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z141EstadoSGTipo_"+sGXsfl_33_idx, StringUtil.RTrim( Z141EstadoSGTipo)) ;
            ChangePostValue( "ZT_"+"Z142EstadoSGId_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z142EstadoSGId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_44_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_44), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_44_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_44), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_44_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_44), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_44 != 0 )
            {
               ChangePostValue( "HISTORICORELACIONESID_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICORELACIONESPROFESIONAL_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesProfesional_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICORELACIONESNOMBRE_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICORELACIONESAPELLIDO_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesApellido_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGTIPO_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoSGTipo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGID_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadoSGId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICORELACIONESFECHAALTA_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesFechaAlta_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICORELACIONESFECHAMODIF_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesFechaModif_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1244( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_44 = 0;
         nIsMod_44 = 0;
         nRcdDeleted_44 = 0;
      }

      protected void ProcessLevel1242( )
      {
         /* Save parent mode. */
         sMode42 = Gx_mode;
         ProcessNestedLevel1244( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode42;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1242( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1242( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("historicorelaciones",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues120( ) ;
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
            context.RollbackDataStores("historicorelaciones",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1242( )
      {
         /* Scan By routine */
         /* Using cursor T001215 */
         pr_default.execute(13);
         RcdFound42 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound42 = 1;
            A153HistoricoSolicitudesID = T001215_A153HistoricoSolicitudesID[0];
            AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1242( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound42 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound42 = 1;
            A153HistoricoSolicitudesID = T001215_A153HistoricoSolicitudesID[0];
            AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
         }
      }

      protected void ScanEnd1242( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm1242( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1242( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1242( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1242( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1242( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1242( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1242( )
      {
         edtHistoricoSolicitudesID_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesID_Enabled), 5, 0), true);
         edtHistoricoSolicitudesNombre_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesNombre_Enabled), 5, 0), true);
      }

      protected void ZM1244( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z320HistoricoRelacionesProfesional = T00123_A320HistoricoRelacionesProfesional[0];
               Z323HistoricoRelacionesNombre = T00123_A323HistoricoRelacionesNombre[0];
               Z324HistoricoRelacionesApellido = T00123_A324HistoricoRelacionesApellido[0];
               Z321HistoricoRelacionesFechaAlta = T00123_A321HistoricoRelacionesFechaAlta[0];
               Z322HistoricoRelacionesFechaModif = T00123_A322HistoricoRelacionesFechaModif[0];
               Z141EstadoSGTipo = T00123_A141EstadoSGTipo[0];
               Z142EstadoSGId = T00123_A142EstadoSGId[0];
            }
            else
            {
               Z320HistoricoRelacionesProfesional = A320HistoricoRelacionesProfesional;
               Z323HistoricoRelacionesNombre = A323HistoricoRelacionesNombre;
               Z324HistoricoRelacionesApellido = A324HistoricoRelacionesApellido;
               Z321HistoricoRelacionesFechaAlta = A321HistoricoRelacionesFechaAlta;
               Z322HistoricoRelacionesFechaModif = A322HistoricoRelacionesFechaModif;
               Z141EstadoSGTipo = A141EstadoSGTipo;
               Z142EstadoSGId = A142EstadoSGId;
            }
         }
         if ( GX_JID == -8 )
         {
            Z153HistoricoSolicitudesID = A153HistoricoSolicitudesID;
            Z156HistoricoRelacionesId = A156HistoricoRelacionesId;
            Z320HistoricoRelacionesProfesional = A320HistoricoRelacionesProfesional;
            Z323HistoricoRelacionesNombre = A323HistoricoRelacionesNombre;
            Z324HistoricoRelacionesApellido = A324HistoricoRelacionesApellido;
            Z321HistoricoRelacionesFechaAlta = A321HistoricoRelacionesFechaAlta;
            Z322HistoricoRelacionesFechaModif = A322HistoricoRelacionesFechaModif;
            Z141EstadoSGTipo = A141EstadoSGTipo;
            Z142EstadoSGId = A142EstadoSGId;
            Z143EstadoSGNombre = A143EstadoSGNombre;
         }
      }

      protected void standaloneNotModal1244( )
      {
      }

      protected void standaloneModal1244( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtHistoricoRelacionesId_Enabled = 0;
            AssignProp("", false, edtHistoricoRelacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoRelacionesId_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         }
         else
         {
            edtHistoricoRelacionesId_Enabled = 1;
            AssignProp("", false, edtHistoricoRelacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoRelacionesId_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         }
      }

      protected void Load1244( )
      {
         /* Using cursor T001216 */
         pr_default.execute(14, new Object[] {A153HistoricoSolicitudesID, A156HistoricoRelacionesId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound44 = 1;
            A320HistoricoRelacionesProfesional = T001216_A320HistoricoRelacionesProfesional[0];
            A323HistoricoRelacionesNombre = T001216_A323HistoricoRelacionesNombre[0];
            A324HistoricoRelacionesApellido = T001216_A324HistoricoRelacionesApellido[0];
            A143EstadoSGNombre = T001216_A143EstadoSGNombre[0];
            A321HistoricoRelacionesFechaAlta = T001216_A321HistoricoRelacionesFechaAlta[0];
            A322HistoricoRelacionesFechaModif = T001216_A322HistoricoRelacionesFechaModif[0];
            A141EstadoSGTipo = T001216_A141EstadoSGTipo[0];
            A142EstadoSGId = T001216_A142EstadoSGId[0];
            ZM1244( -8) ;
         }
         pr_default.close(14);
         OnLoadActions1244( ) ;
      }

      protected void OnLoadActions1244( )
      {
         GXAESTADOSGID_html1244( A141EstadoSGTipo) ;
      }

      protected void CheckExtendedTable1244( )
      {
         nIsDirty_44 = 0;
         Gx_BScreen = 1;
         standaloneModal1244( ) ;
         /* Using cursor T00124 */
         pr_default.execute(2, new Object[] {A141EstadoSGTipo, A142EstadoSGId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "ESTADOSGID_" + sGXsfl_33_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado SG", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtEstadoSGTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A143EstadoSGNombre = T00124_A143EstadoSGNombre[0];
         pr_default.close(2);
         GXAESTADOSGID_html1244( A141EstadoSGTipo) ;
         if ( ! ( (DateTime.MinValue==A321HistoricoRelacionesFechaAlta) || ( A321HistoricoRelacionesFechaAlta >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GXCCtl = "HISTORICORELACIONESFECHAALTA_" + sGXsfl_33_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha Alta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtHistoricoRelacionesFechaAlta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A322HistoricoRelacionesFechaModif) || ( A322HistoricoRelacionesFechaModif >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GXCCtl = "HISTORICORELACIONESFECHAMODIF_" + sGXsfl_33_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha Modifado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtHistoricoRelacionesFechaModif_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1244( )
      {
         pr_default.close(2);
      }

      protected void enableDisable1244( )
      {
      }

      protected void gxLoad_9( string A141EstadoSGTipo ,
                               int A142EstadoSGId )
      {
         /* Using cursor T001217 */
         pr_default.execute(15, new Object[] {A141EstadoSGTipo, A142EstadoSGId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GXCCtl = "ESTADOSGID_" + sGXsfl_33_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado SG", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtEstadoSGTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A143EstadoSGNombre = T001217_A143EstadoSGNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A143EstadoSGNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void GetKey1244( )
      {
         /* Using cursor T001218 */
         pr_default.execute(16, new Object[] {A153HistoricoSolicitudesID, A156HistoricoRelacionesId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound44 = 1;
         }
         else
         {
            RcdFound44 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey1244( )
      {
         /* Using cursor T00123 */
         pr_default.execute(1, new Object[] {A153HistoricoSolicitudesID, A156HistoricoRelacionesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1244( 8) ;
            RcdFound44 = 1;
            InitializeNonKey1244( ) ;
            A156HistoricoRelacionesId = T00123_A156HistoricoRelacionesId[0];
            A320HistoricoRelacionesProfesional = T00123_A320HistoricoRelacionesProfesional[0];
            A323HistoricoRelacionesNombre = T00123_A323HistoricoRelacionesNombre[0];
            A324HistoricoRelacionesApellido = T00123_A324HistoricoRelacionesApellido[0];
            A321HistoricoRelacionesFechaAlta = T00123_A321HistoricoRelacionesFechaAlta[0];
            A322HistoricoRelacionesFechaModif = T00123_A322HistoricoRelacionesFechaModif[0];
            A141EstadoSGTipo = T00123_A141EstadoSGTipo[0];
            A142EstadoSGId = T00123_A142EstadoSGId[0];
            Z153HistoricoSolicitudesID = A153HistoricoSolicitudesID;
            Z156HistoricoRelacionesId = A156HistoricoRelacionesId;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1244( ) ;
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound44 = 0;
            InitializeNonKey1244( ) ;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1244( ) ;
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1244( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1244( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00122 */
            pr_default.execute(0, new Object[] {A153HistoricoSolicitudesID, A156HistoricoRelacionesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HistoricoRelacionesRelaciones"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z320HistoricoRelacionesProfesional, T00122_A320HistoricoRelacionesProfesional[0]) != 0 ) || ( StringUtil.StrCmp(Z323HistoricoRelacionesNombre, T00122_A323HistoricoRelacionesNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z324HistoricoRelacionesApellido, T00122_A324HistoricoRelacionesApellido[0]) != 0 ) || ( Z321HistoricoRelacionesFechaAlta != T00122_A321HistoricoRelacionesFechaAlta[0] ) || ( Z322HistoricoRelacionesFechaModif != T00122_A322HistoricoRelacionesFechaModif[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z141EstadoSGTipo, T00122_A141EstadoSGTipo[0]) != 0 ) || ( Z142EstadoSGId != T00122_A142EstadoSGId[0] ) )
            {
               if ( StringUtil.StrCmp(Z320HistoricoRelacionesProfesional, T00122_A320HistoricoRelacionesProfesional[0]) != 0 )
               {
                  GXUtil.WriteLog("historicorelaciones:[seudo value changed for attri]"+"HistoricoRelacionesProfesional");
                  GXUtil.WriteLogRaw("Old: ",Z320HistoricoRelacionesProfesional);
                  GXUtil.WriteLogRaw("Current: ",T00122_A320HistoricoRelacionesProfesional[0]);
               }
               if ( StringUtil.StrCmp(Z323HistoricoRelacionesNombre, T00122_A323HistoricoRelacionesNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("historicorelaciones:[seudo value changed for attri]"+"HistoricoRelacionesNombre");
                  GXUtil.WriteLogRaw("Old: ",Z323HistoricoRelacionesNombre);
                  GXUtil.WriteLogRaw("Current: ",T00122_A323HistoricoRelacionesNombre[0]);
               }
               if ( StringUtil.StrCmp(Z324HistoricoRelacionesApellido, T00122_A324HistoricoRelacionesApellido[0]) != 0 )
               {
                  GXUtil.WriteLog("historicorelaciones:[seudo value changed for attri]"+"HistoricoRelacionesApellido");
                  GXUtil.WriteLogRaw("Old: ",Z324HistoricoRelacionesApellido);
                  GXUtil.WriteLogRaw("Current: ",T00122_A324HistoricoRelacionesApellido[0]);
               }
               if ( Z321HistoricoRelacionesFechaAlta != T00122_A321HistoricoRelacionesFechaAlta[0] )
               {
                  GXUtil.WriteLog("historicorelaciones:[seudo value changed for attri]"+"HistoricoRelacionesFechaAlta");
                  GXUtil.WriteLogRaw("Old: ",Z321HistoricoRelacionesFechaAlta);
                  GXUtil.WriteLogRaw("Current: ",T00122_A321HistoricoRelacionesFechaAlta[0]);
               }
               if ( Z322HistoricoRelacionesFechaModif != T00122_A322HistoricoRelacionesFechaModif[0] )
               {
                  GXUtil.WriteLog("historicorelaciones:[seudo value changed for attri]"+"HistoricoRelacionesFechaModif");
                  GXUtil.WriteLogRaw("Old: ",Z322HistoricoRelacionesFechaModif);
                  GXUtil.WriteLogRaw("Current: ",T00122_A322HistoricoRelacionesFechaModif[0]);
               }
               if ( StringUtil.StrCmp(Z141EstadoSGTipo, T00122_A141EstadoSGTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("historicorelaciones:[seudo value changed for attri]"+"EstadoSGTipo");
                  GXUtil.WriteLogRaw("Old: ",Z141EstadoSGTipo);
                  GXUtil.WriteLogRaw("Current: ",T00122_A141EstadoSGTipo[0]);
               }
               if ( Z142EstadoSGId != T00122_A142EstadoSGId[0] )
               {
                  GXUtil.WriteLog("historicorelaciones:[seudo value changed for attri]"+"EstadoSGId");
                  GXUtil.WriteLogRaw("Old: ",Z142EstadoSGId);
                  GXUtil.WriteLogRaw("Current: ",T00122_A142EstadoSGId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"HistoricoRelacionesRelaciones"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1244( )
      {
         BeforeValidate1244( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1244( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1244( 0) ;
            CheckOptimisticConcurrency1244( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1244( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1244( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001219 */
                     pr_default.execute(17, new Object[] {A153HistoricoSolicitudesID, A156HistoricoRelacionesId, A320HistoricoRelacionesProfesional, A323HistoricoRelacionesNombre, A324HistoricoRelacionesApellido, A321HistoricoRelacionesFechaAlta, A322HistoricoRelacionesFechaModif, A141EstadoSGTipo, A142EstadoSGId});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("HistoricoRelacionesRelaciones");
                     if ( (pr_default.getStatus(17) == 1) )
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
               Load1244( ) ;
            }
            EndLevel1244( ) ;
         }
         CloseExtendedTableCursors1244( ) ;
      }

      protected void Update1244( )
      {
         BeforeValidate1244( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1244( ) ;
         }
         if ( ( nIsMod_44 != 0 ) || ( nIsDirty_44 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1244( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1244( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1244( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001220 */
                        pr_default.execute(18, new Object[] {A320HistoricoRelacionesProfesional, A323HistoricoRelacionesNombre, A324HistoricoRelacionesApellido, A321HistoricoRelacionesFechaAlta, A322HistoricoRelacionesFechaModif, A141EstadoSGTipo, A142EstadoSGId, A153HistoricoSolicitudesID, A156HistoricoRelacionesId});
                        pr_default.close(18);
                        pr_default.SmartCacheProvider.SetUpdated("HistoricoRelacionesRelaciones");
                        if ( (pr_default.getStatus(18) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HistoricoRelacionesRelaciones"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1244( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1244( ) ;
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
               EndLevel1244( ) ;
            }
         }
         CloseExtendedTableCursors1244( ) ;
      }

      protected void DeferredUpdate1244( )
      {
      }

      protected void Delete1244( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1244( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1244( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1244( ) ;
            AfterConfirm1244( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1244( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001221 */
                  pr_default.execute(19, new Object[] {A153HistoricoSolicitudesID, A156HistoricoRelacionesId});
                  pr_default.close(19);
                  pr_default.SmartCacheProvider.SetUpdated("HistoricoRelacionesRelaciones");
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
         sMode44 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1244( ) ;
         Gx_mode = sMode44;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1244( )
      {
         standaloneModal1244( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXAESTADOSGID_html1244( A141EstadoSGTipo) ;
            /* Using cursor T001222 */
            pr_default.execute(20, new Object[] {A141EstadoSGTipo, A142EstadoSGId});
            A143EstadoSGNombre = T001222_A143EstadoSGNombre[0];
            pr_default.close(20);
         }
      }

      protected void EndLevel1244( )
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

      public void ScanStart1244( )
      {
         /* Scan By routine */
         /* Using cursor T001223 */
         pr_default.execute(21, new Object[] {A153HistoricoSolicitudesID});
         RcdFound44 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound44 = 1;
            A156HistoricoRelacionesId = T001223_A156HistoricoRelacionesId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1244( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound44 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound44 = 1;
            A156HistoricoRelacionesId = T001223_A156HistoricoRelacionesId[0];
         }
      }

      protected void ScanEnd1244( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm1244( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1244( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1244( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1244( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1244( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1244( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1244( )
      {
         edtHistoricoRelacionesId_Enabled = 0;
         AssignProp("", false, edtHistoricoRelacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoRelacionesId_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtHistoricoRelacionesProfesional_Enabled = 0;
         AssignProp("", false, edtHistoricoRelacionesProfesional_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoRelacionesProfesional_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtHistoricoRelacionesNombre_Enabled = 0;
         AssignProp("", false, edtHistoricoRelacionesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoRelacionesNombre_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtHistoricoRelacionesApellido_Enabled = 0;
         AssignProp("", false, edtHistoricoRelacionesApellido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoRelacionesApellido_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtEstadoSGTipo_Enabled = 0;
         AssignProp("", false, edtEstadoSGTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoSGTipo_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         dynEstadoSGId.Enabled = 0;
         AssignProp("", false, dynEstadoSGId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadoSGId.Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtHistoricoRelacionesFechaAlta_Enabled = 0;
         AssignProp("", false, edtHistoricoRelacionesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoRelacionesFechaAlta_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtHistoricoRelacionesFechaModif_Enabled = 0;
         AssignProp("", false, edtHistoricoRelacionesFechaModif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoRelacionesFechaModif_Enabled), 5, 0), !bGXsfl_33_Refreshing);
      }

      protected void send_integrity_lvl_hashes1244( )
      {
      }

      protected void send_integrity_lvl_hashes1242( )
      {
      }

      protected void SubsflControlProps_3344( )
      {
         edtHistoricoRelacionesId_Internalname = "HISTORICORELACIONESID_"+sGXsfl_33_idx;
         edtHistoricoRelacionesProfesional_Internalname = "HISTORICORELACIONESPROFESIONAL_"+sGXsfl_33_idx;
         edtHistoricoRelacionesNombre_Internalname = "HISTORICORELACIONESNOMBRE_"+sGXsfl_33_idx;
         edtHistoricoRelacionesApellido_Internalname = "HISTORICORELACIONESAPELLIDO_"+sGXsfl_33_idx;
         edtEstadoSGTipo_Internalname = "ESTADOSGTIPO_"+sGXsfl_33_idx;
         dynEstadoSGId_Internalname = "ESTADOSGID_"+sGXsfl_33_idx;
         imgprompt_141_142_Internalname = "PROMPT_141_142_"+sGXsfl_33_idx;
         edtHistoricoRelacionesFechaAlta_Internalname = "HISTORICORELACIONESFECHAALTA_"+sGXsfl_33_idx;
         edtHistoricoRelacionesFechaModif_Internalname = "HISTORICORELACIONESFECHAMODIF_"+sGXsfl_33_idx;
      }

      protected void SubsflControlProps_fel_3344( )
      {
         edtHistoricoRelacionesId_Internalname = "HISTORICORELACIONESID_"+sGXsfl_33_fel_idx;
         edtHistoricoRelacionesProfesional_Internalname = "HISTORICORELACIONESPROFESIONAL_"+sGXsfl_33_fel_idx;
         edtHistoricoRelacionesNombre_Internalname = "HISTORICORELACIONESNOMBRE_"+sGXsfl_33_fel_idx;
         edtHistoricoRelacionesApellido_Internalname = "HISTORICORELACIONESAPELLIDO_"+sGXsfl_33_fel_idx;
         edtEstadoSGTipo_Internalname = "ESTADOSGTIPO_"+sGXsfl_33_fel_idx;
         dynEstadoSGId_Internalname = "ESTADOSGID_"+sGXsfl_33_fel_idx;
         imgprompt_141_142_Internalname = "PROMPT_141_142_"+sGXsfl_33_fel_idx;
         edtHistoricoRelacionesFechaAlta_Internalname = "HISTORICORELACIONESFECHAALTA_"+sGXsfl_33_fel_idx;
         edtHistoricoRelacionesFechaModif_Internalname = "HISTORICORELACIONESFECHAMODIF_"+sGXsfl_33_fel_idx;
      }

      protected void AddRow1244( )
      {
         nGXsfl_33_idx = (int)(nGXsfl_33_idx+1);
         sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
         SubsflControlProps_3344( ) ;
         SendRow1244( ) ;
      }

      protected void SendRow1244( )
      {
         Gridlevel_relacionesRow = GXWebRow.GetNew(context);
         if ( subGridlevel_relaciones_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_relaciones_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_relaciones_Class, "") != 0 )
            {
               subGridlevel_relaciones_Linesclass = subGridlevel_relaciones_Class+"Odd";
            }
         }
         else if ( subGridlevel_relaciones_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_relaciones_Backstyle = 0;
            subGridlevel_relaciones_Backcolor = subGridlevel_relaciones_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_relaciones_Class, "") != 0 )
            {
               subGridlevel_relaciones_Linesclass = subGridlevel_relaciones_Class+"Uniform";
            }
         }
         else if ( subGridlevel_relaciones_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_relaciones_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_relaciones_Class, "") != 0 )
            {
               subGridlevel_relaciones_Linesclass = subGridlevel_relaciones_Class+"Odd";
            }
            subGridlevel_relaciones_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_relaciones_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_relaciones_Backstyle = 1;
            if ( ((int)((nGXsfl_33_idx) % (2))) == 0 )
            {
               subGridlevel_relaciones_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_relaciones_Class, "") != 0 )
               {
                  subGridlevel_relaciones_Linesclass = subGridlevel_relaciones_Class+"Even";
               }
            }
            else
            {
               subGridlevel_relaciones_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_relaciones_Class, "") != 0 )
               {
                  subGridlevel_relaciones_Linesclass = subGridlevel_relaciones_Class+"Odd";
               }
            }
         }
         imgprompt_141_142_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00o0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ESTADOSGTIPO_"+sGXsfl_33_idx+"'), id:'"+"ESTADOSGTIPO_"+sGXsfl_33_idx+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"ESTADOSGID_"+sGXsfl_33_idx+"'), id:'"+"ESTADOSGID_"+sGXsfl_33_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_44_"+sGXsfl_33_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_44_" + sGXsfl_33_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_33_idx + "',33)\"";
         ROClassString = "Attribute";
         Gridlevel_relacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoRelacionesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A156HistoricoRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A156HistoricoRelacionesId), "ZZZZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoRelacionesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHistoricoRelacionesId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_44_" + sGXsfl_33_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_33_idx + "',33)\"";
         ROClassString = "Attribute";
         Gridlevel_relacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoRelacionesProfesional_Internalname,StringUtil.RTrim( A320HistoricoRelacionesProfesional),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoRelacionesProfesional_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHistoricoRelacionesProfesional_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_44_" + sGXsfl_33_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_33_idx + "',33)\"";
         ROClassString = "Attribute";
         Gridlevel_relacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoRelacionesNombre_Internalname,StringUtil.RTrim( A323HistoricoRelacionesNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoRelacionesNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHistoricoRelacionesNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_44_" + sGXsfl_33_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 37,'',false,'" + sGXsfl_33_idx + "',33)\"";
         ROClassString = "Attribute";
         Gridlevel_relacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoRelacionesApellido_Internalname,StringUtil.RTrim( A324HistoricoRelacionesApellido),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoRelacionesApellido_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHistoricoRelacionesApellido_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_44_" + sGXsfl_33_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_33_idx + "',33)\"";
         ROClassString = "Attribute";
         Gridlevel_relacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoSGTipo_Internalname,StringUtil.RTrim( A141EstadoSGTipo),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoSGTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtEstadoSGTipo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         GXAESTADOSGID_html1244( A141EstadoSGTipo) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_44_" + sGXsfl_33_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_33_idx + "',33)\"";
         if ( ( dynEstadoSGId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "ESTADOSGID_" + sGXsfl_33_idx;
            dynEstadoSGId.Name = GXCCtl;
            dynEstadoSGId.WebTags = "";
         }
         /* ComboBox */
         Gridlevel_relacionesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynEstadoSGId,(string)dynEstadoSGId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A142EstadoSGId), 5, 0)),(short)1,(string)dynEstadoSGId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynEstadoSGId.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"",(string)"",(bool)true,(short)0});
         dynEstadoSGId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A142EstadoSGId), 5, 0));
         AssignProp("", false, dynEstadoSGId_Internalname, "Values", (string)(dynEstadoSGId.ToJavascriptSource()), !bGXsfl_33_Refreshing);
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_141_142_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_141_142_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_relacionesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_141_142_Internalname,(string)sImgUrl,(string)imgprompt_141_142_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_141_142_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_44_" + sGXsfl_33_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_33_idx + "',33)\"";
         ROClassString = "Attribute";
         Gridlevel_relacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoRelacionesFechaAlta_Internalname,context.localUtil.TToC( A321HistoricoRelacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A321HistoricoRelacionesFechaAlta, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoRelacionesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHistoricoRelacionesFechaAlta_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_44_" + sGXsfl_33_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_33_idx + "',33)\"";
         ROClassString = "Attribute";
         Gridlevel_relacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoRelacionesFechaModif_Internalname,context.localUtil.TToC( A322HistoricoRelacionesFechaModif, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A322HistoricoRelacionesFechaModif, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoRelacionesFechaModif_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHistoricoRelacionesFechaModif_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_relacionesRow);
         send_integrity_lvl_hashes1244( ) ;
         GXCCtl = "Z156HistoricoRelacionesId_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z156HistoricoRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z320HistoricoRelacionesProfesional_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z320HistoricoRelacionesProfesional));
         GXCCtl = "Z323HistoricoRelacionesNombre_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z323HistoricoRelacionesNombre));
         GXCCtl = "Z324HistoricoRelacionesApellido_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z324HistoricoRelacionesApellido));
         GXCCtl = "Z321HistoricoRelacionesFechaAlta_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z321HistoricoRelacionesFechaAlta, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z322HistoricoRelacionesFechaModif_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z322HistoricoRelacionesFechaModif, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z141EstadoSGTipo_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z141EstadoSGTipo));
         GXCCtl = "Z142EstadoSGId_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z142EstadoSGId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_44_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_44), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_44_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_44), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_44_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_44), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vHISTORICOSOLICITUDESID_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "HISTORICORELACIONESID_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HISTORICORELACIONESPROFESIONAL_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesProfesional_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HISTORICORELACIONESNOMBRE_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HISTORICORELACIONESAPELLIDO_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesApellido_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSGTIPO_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoSGTipo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSGID_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadoSGId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HISTORICORELACIONESFECHAALTA_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesFechaAlta_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HISTORICORELACIONESFECHAMODIF_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesFechaModif_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_141_142_"+sGXsfl_33_idx+"Link", StringUtil.RTrim( imgprompt_141_142_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_relacionesContainer.AddRow(Gridlevel_relacionesRow);
      }

      protected void ReadRow1244( )
      {
         nGXsfl_33_idx = (int)(nGXsfl_33_idx+1);
         sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
         SubsflControlProps_3344( ) ;
         edtHistoricoRelacionesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICORELACIONESID_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHistoricoRelacionesProfesional_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICORELACIONESPROFESIONAL_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHistoricoRelacionesNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICORELACIONESNOMBRE_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHistoricoRelacionesApellido_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICORELACIONESAPELLIDO_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtEstadoSGTipo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGTIPO_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynEstadoSGId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGID_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHistoricoRelacionesFechaAlta_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICORELACIONESFECHAALTA_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHistoricoRelacionesFechaModif_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICORELACIONESFECHAMODIF_"+sGXsfl_33_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_141_142_Link = cgiGet( "PROMPT_141_142_"+sGXsfl_33_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtHistoricoRelacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHistoricoRelacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "HISTORICORELACIONESID_" + sGXsfl_33_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtHistoricoRelacionesId_Internalname;
            wbErr = true;
            A156HistoricoRelacionesId = 0;
         }
         else
         {
            A156HistoricoRelacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoRelacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A320HistoricoRelacionesProfesional = cgiGet( edtHistoricoRelacionesProfesional_Internalname);
         A323HistoricoRelacionesNombre = cgiGet( edtHistoricoRelacionesNombre_Internalname);
         A324HistoricoRelacionesApellido = cgiGet( edtHistoricoRelacionesApellido_Internalname);
         A141EstadoSGTipo = cgiGet( edtEstadoSGTipo_Internalname);
         dynEstadoSGId.Name = dynEstadoSGId_Internalname;
         dynEstadoSGId.CurrentValue = cgiGet( dynEstadoSGId_Internalname);
         A142EstadoSGId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynEstadoSGId_Internalname), "."), 18, MidpointRounding.ToEven));
         if ( context.localUtil.VCDateTime( cgiGet( edtHistoricoRelacionesFechaAlta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
         {
            GXCCtl = "HISTORICORELACIONESFECHAALTA_" + sGXsfl_33_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha Alta", "")}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtHistoricoRelacionesFechaAlta_Internalname;
            wbErr = true;
            A321HistoricoRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         }
         else
         {
            A321HistoricoRelacionesFechaAlta = context.localUtil.CToT( cgiGet( edtHistoricoRelacionesFechaAlta_Internalname));
         }
         if ( context.localUtil.VCDateTime( cgiGet( edtHistoricoRelacionesFechaModif_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
         {
            GXCCtl = "HISTORICORELACIONESFECHAMODIF_" + sGXsfl_33_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha Modifado", "")}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtHistoricoRelacionesFechaModif_Internalname;
            wbErr = true;
            A322HistoricoRelacionesFechaModif = (DateTime)(DateTime.MinValue);
         }
         else
         {
            A322HistoricoRelacionesFechaModif = context.localUtil.CToT( cgiGet( edtHistoricoRelacionesFechaModif_Internalname));
         }
         GXCCtl = "Z156HistoricoRelacionesId_" + sGXsfl_33_idx;
         Z156HistoricoRelacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z320HistoricoRelacionesProfesional_" + sGXsfl_33_idx;
         Z320HistoricoRelacionesProfesional = cgiGet( GXCCtl);
         GXCCtl = "Z323HistoricoRelacionesNombre_" + sGXsfl_33_idx;
         Z323HistoricoRelacionesNombre = cgiGet( GXCCtl);
         GXCCtl = "Z324HistoricoRelacionesApellido_" + sGXsfl_33_idx;
         Z324HistoricoRelacionesApellido = cgiGet( GXCCtl);
         GXCCtl = "Z321HistoricoRelacionesFechaAlta_" + sGXsfl_33_idx;
         Z321HistoricoRelacionesFechaAlta = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         GXCCtl = "Z322HistoricoRelacionesFechaModif_" + sGXsfl_33_idx;
         Z322HistoricoRelacionesFechaModif = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         GXCCtl = "Z141EstadoSGTipo_" + sGXsfl_33_idx;
         Z141EstadoSGTipo = cgiGet( GXCCtl);
         GXCCtl = "Z142EstadoSGId_" + sGXsfl_33_idx;
         Z142EstadoSGId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_44_" + sGXsfl_33_idx;
         nRcdDeleted_44 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_44_" + sGXsfl_33_idx;
         nRcdExists_44 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_44_" + sGXsfl_33_idx;
         nIsMod_44 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtHistoricoRelacionesId_Enabled = edtHistoricoRelacionesId_Enabled;
      }

      protected void ConfirmValues120( )
      {
         nGXsfl_33_idx = 0;
         sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
         SubsflControlProps_3344( ) ;
         while ( nGXsfl_33_idx < nRC_GXsfl_33 )
         {
            nGXsfl_33_idx = (int)(nGXsfl_33_idx+1);
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
            SubsflControlProps_3344( ) ;
            ChangePostValue( "Z156HistoricoRelacionesId_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z156HistoricoRelacionesId_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z156HistoricoRelacionesId_"+sGXsfl_33_idx) ;
            ChangePostValue( "Z320HistoricoRelacionesProfesional_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z320HistoricoRelacionesProfesional_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z320HistoricoRelacionesProfesional_"+sGXsfl_33_idx) ;
            ChangePostValue( "Z323HistoricoRelacionesNombre_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z323HistoricoRelacionesNombre_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z323HistoricoRelacionesNombre_"+sGXsfl_33_idx) ;
            ChangePostValue( "Z324HistoricoRelacionesApellido_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z324HistoricoRelacionesApellido_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z324HistoricoRelacionesApellido_"+sGXsfl_33_idx) ;
            ChangePostValue( "Z321HistoricoRelacionesFechaAlta_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z321HistoricoRelacionesFechaAlta_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z321HistoricoRelacionesFechaAlta_"+sGXsfl_33_idx) ;
            ChangePostValue( "Z322HistoricoRelacionesFechaModif_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z322HistoricoRelacionesFechaModif_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z322HistoricoRelacionesFechaModif_"+sGXsfl_33_idx) ;
            ChangePostValue( "Z141EstadoSGTipo_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z141EstadoSGTipo_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z141EstadoSGTipo_"+sGXsfl_33_idx) ;
            ChangePostValue( "Z142EstadoSGId_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z142EstadoSGId_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z142EstadoSGId_"+sGXsfl_33_idx) ;
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
         GXEncryptionTmp = "historicorelaciones.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV10HistoricoSolicitudesID,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("historicorelaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"HistoricoRelaciones");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("historicorelaciones:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z153HistoricoSolicitudesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z153HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z288HistoricoSolicitudesNombre", StringUtil.RTrim( Z288HistoricoSolicitudesNombre));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_33", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_33_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vHISTORICOSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vHISTORICOSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV20Pgmname));
         GxWebStd.gx_hidden_field( context, "ESTADOSGNOMBRE", StringUtil.RTrim( A143EstadoSGNombre));
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
         GXEncryptionTmp = "historicorelaciones.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV10HistoricoSolicitudesID,18,0));
         return formatLink("historicorelaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "HistoricoRelaciones" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Historico Relaciones", "") ;
      }

      protected void InitializeNonKey1242( )
      {
         A288HistoricoSolicitudesNombre = "";
         AssignAttri("", false, "A288HistoricoSolicitudesNombre", A288HistoricoSolicitudesNombre);
         Z288HistoricoSolicitudesNombre = "";
      }

      protected void InitAll1242( )
      {
         A153HistoricoSolicitudesID = 0;
         AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
         InitializeNonKey1242( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1244( )
      {
         A320HistoricoRelacionesProfesional = "";
         A323HistoricoRelacionesNombre = "";
         A324HistoricoRelacionesApellido = "";
         A141EstadoSGTipo = "";
         A142EstadoSGId = 0;
         A143EstadoSGNombre = "";
         AssignAttri("", false, "A143EstadoSGNombre", A143EstadoSGNombre);
         A321HistoricoRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         A322HistoricoRelacionesFechaModif = (DateTime)(DateTime.MinValue);
         Z320HistoricoRelacionesProfesional = "";
         Z323HistoricoRelacionesNombre = "";
         Z324HistoricoRelacionesApellido = "";
         Z321HistoricoRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         Z322HistoricoRelacionesFechaModif = (DateTime)(DateTime.MinValue);
         Z141EstadoSGTipo = "";
         Z142EstadoSGId = 0;
      }

      protected void InitAll1244( )
      {
         A156HistoricoRelacionesId = 0;
         InitializeNonKey1244( ) ;
      }

      protected void StandaloneModalInsert1244( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026862239348", true, true, false);
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
         context.AddJavascriptSource("historicorelaciones.js", "?2026862239348", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties44( )
      {
         edtHistoricoRelacionesId_Enabled = defedtHistoricoRelacionesId_Enabled;
         AssignProp("", false, edtHistoricoRelacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoRelacionesId_Enabled), 5, 0), !bGXsfl_33_Refreshing);
      }

      protected void StartGridControl33( )
      {
         Gridlevel_relacionesContainer.AddObjectProperty("GridName", "Gridlevel_relaciones");
         Gridlevel_relacionesContainer.AddObjectProperty("Header", subGridlevel_relaciones_Header);
         Gridlevel_relacionesContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_relacionesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_relacionesContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A156HistoricoRelacionesId), 18, 0, ".", ""))));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesId_Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A320HistoricoRelacionesProfesional)));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesProfesional_Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A323HistoricoRelacionesNombre)));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A324HistoricoRelacionesApellido)));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesApellido_Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A141EstadoSGTipo)));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoSGTipo_Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A142EstadoSGId), 5, 0, ".", ""))));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadoSGId.Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A321HistoricoRelacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesFechaAlta_Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A322HistoricoRelacionesFechaModif, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoRelacionesFechaModif_Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Selectedindex), 4, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Allowselection), 1, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Allowhovering), 1, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtHistoricoSolicitudesID_Internalname = "HISTORICOSOLICITUDESID";
         edtHistoricoSolicitudesNombre_Internalname = "HISTORICOSOLICITUDESNOMBRE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtHistoricoRelacionesId_Internalname = "HISTORICORELACIONESID";
         edtHistoricoRelacionesProfesional_Internalname = "HISTORICORELACIONESPROFESIONAL";
         edtHistoricoRelacionesNombre_Internalname = "HISTORICORELACIONESNOMBRE";
         edtHistoricoRelacionesApellido_Internalname = "HISTORICORELACIONESAPELLIDO";
         edtEstadoSGTipo_Internalname = "ESTADOSGTIPO";
         dynEstadoSGId_Internalname = "ESTADOSGID";
         edtHistoricoRelacionesFechaAlta_Internalname = "HISTORICORELACIONESFECHAALTA";
         edtHistoricoRelacionesFechaModif_Internalname = "HISTORICORELACIONESFECHAMODIF";
         divTableleaflevel_relaciones_Internalname = "TABLELEAFLEVEL_RELACIONES";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_141_142_Internalname = "PROMPT_141_142";
         subGridlevel_relaciones_Internalname = "GRIDLEVEL_RELACIONES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_relaciones_Allowcollapsing = 0;
         subGridlevel_relaciones_Allowselection = 0;
         subGridlevel_relaciones_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Historico Relaciones", "");
         edtHistoricoRelacionesFechaModif_Jsonclick = "";
         edtHistoricoRelacionesFechaAlta_Jsonclick = "";
         imgprompt_141_142_Visible = 1;
         imgprompt_141_142_Link = "";
         imgprompt_141_142_Visible = 1;
         dynEstadoSGId_Jsonclick = "";
         edtEstadoSGTipo_Jsonclick = "";
         edtHistoricoRelacionesApellido_Jsonclick = "";
         edtHistoricoRelacionesNombre_Jsonclick = "";
         edtHistoricoRelacionesProfesional_Jsonclick = "";
         edtHistoricoRelacionesId_Jsonclick = "";
         subGridlevel_relaciones_Class = "WorkWith";
         subGridlevel_relaciones_Backcolorstyle = 0;
         edtHistoricoRelacionesFechaModif_Enabled = 1;
         edtHistoricoRelacionesFechaAlta_Enabled = 1;
         dynEstadoSGId.Enabled = 1;
         edtEstadoSGTipo_Enabled = 1;
         edtHistoricoRelacionesApellido_Enabled = 1;
         edtHistoricoRelacionesNombre_Enabled = 1;
         edtHistoricoRelacionesProfesional_Enabled = 1;
         edtHistoricoRelacionesId_Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtHistoricoSolicitudesNombre_Jsonclick = "";
         edtHistoricoSolicitudesNombre_Enabled = 1;
         edtHistoricoSolicitudesID_Jsonclick = "";
         edtHistoricoSolicitudesID_Enabled = 1;
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
         GXAESTADOSGID_html1244( A141EstadoSGTipo) ;
         /* End function dynload_actions */
      }

      protected void GXDLAESTADOSGID1244( string A141EstadoSGTipo )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAESTADOSGID_data1244( A141EstadoSGTipo) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXAESTADOSGID_html1244( string A141EstadoSGTipo )
      {
         int gxdynajaxvalue;
         GXDLAESTADOSGID_data1244( A141EstadoSGTipo) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynEstadoSGId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynEstadoSGId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 5, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAESTADOSGID_data1244( string A141EstadoSGTipo )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T001224 */
         pr_default.execute(22, new Object[] {A141EstadoSGTipo});
         while ( (pr_default.getStatus(22) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001224_A142EstadoSGId[0]), 5, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T001224_A143EstadoSGNombre[0]));
            pr_default.readNext(22);
         }
         pr_default.close(22);
      }

      protected void gxnrGridlevel_relaciones_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_3344( ) ;
         while ( nGXsfl_33_idx <= nRC_GXsfl_33 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1244( ) ;
            standaloneModal1244( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1244( ) ;
            nGXsfl_33_idx = (int)(nGXsfl_33_idx+1);
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
            SubsflControlProps_3344( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_relacionesContainer)) ;
         /* End function gxnrGridlevel_relaciones_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "ESTADOSGID_" + sGXsfl_33_idx;
         dynEstadoSGId.Name = GXCCtl;
         dynEstadoSGId.WebTags = "";
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

      public void Valid_Estadosgtipo( )
      {
         A142EstadoSGId = (int)(Math.Round(NumberUtil.Val( dynEstadoSGId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         dynload_actions( ) ;
         if ( dynEstadoSGId.ItemCount > 0 )
         {
            A142EstadoSGId = (int)(Math.Round(NumberUtil.Val( dynEstadoSGId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A142EstadoSGId), 5, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynEstadoSGId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A142EstadoSGId), 5, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A142EstadoSGId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A142EstadoSGId), 5, 0, ".", "")));
         dynEstadoSGId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A142EstadoSGId), 5, 0));
         AssignProp("", false, dynEstadoSGId_Internalname, "Values", dynEstadoSGId.ToJavascriptSource(), true);
      }

      public void Valid_Estadosgid( )
      {
         A142EstadoSGId = (int)(Math.Round(NumberUtil.Val( dynEstadoSGId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T001225 */
         pr_default.execute(23, new Object[] {A141EstadoSGTipo, A142EstadoSGId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado SG", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSGID");
            AnyError = 1;
            GX_FocusControl = edtEstadoSGTipo_Internalname;
         }
         A143EstadoSGNombre = T001225_A143EstadoSGNombre[0];
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A143EstadoSGNombre", StringUtil.RTrim( A143EstadoSGNombre));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV10HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV10HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12122',iparms:[]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESID","{handler:'Valid_Historicosolicitudesid',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESID",",oparms:[]}");
         setEventMetadata("VALID_HISTORICORELACIONESID","{handler:'Valid_Historicorelacionesid',iparms:[]");
         setEventMetadata("VALID_HISTORICORELACIONESID",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSGTIPO","{handler:'Valid_Estadosgtipo',iparms:[{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'dynEstadoSGId'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("VALID_ESTADOSGTIPO",",oparms:[{av:'dynEstadoSGId'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_ESTADOSGID","{handler:'Valid_Estadosgid',iparms:[{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'dynEstadoSGId'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A143EstadoSGNombre',fld:'ESTADOSGNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("VALID_ESTADOSGID",",oparms:[{av:'A143EstadoSGNombre',fld:'ESTADOSGNOMBRE',pic:'',type:'char'}]}");
         setEventMetadata("VALID_HISTORICORELACIONESFECHAALTA","{handler:'Valid_Historicorelacionesfechaalta',iparms:[]");
         setEventMetadata("VALID_HISTORICORELACIONESFECHAALTA",",oparms:[]}");
         setEventMetadata("VALID_HISTORICORELACIONESFECHAMODIF","{handler:'Valid_Historicorelacionesfechamodif',iparms:[]");
         setEventMetadata("VALID_HISTORICORELACIONESFECHAMODIF",",oparms:[]}");
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
         pr_default.close(23);
         pr_default.close(20);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z288HistoricoSolicitudesNombre = "";
         Z320HistoricoRelacionesProfesional = "";
         Z323HistoricoRelacionesNombre = "";
         Z324HistoricoRelacionesApellido = "";
         Z321HistoricoRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         Z322HistoricoRelacionesFechaModif = (DateTime)(DateTime.MinValue);
         Z141EstadoSGTipo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A141EstadoSGTipo = "";
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
         A288HistoricoSolicitudesNombre = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_relacionesContainer = new GXWebGrid( context);
         sMode44 = "";
         sStyleString = "";
         AV20Pgmname = "";
         A143EstadoSGNombre = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode42 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A320HistoricoRelacionesProfesional = "";
         A323HistoricoRelacionesNombre = "";
         A324HistoricoRelacionesApellido = "";
         A321HistoricoRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         A322HistoricoRelacionesFechaModif = (DateTime)(DateTime.MinValue);
         AV11WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9WebSession = context.GetSession();
         T00127_A153HistoricoSolicitudesID = new long[1] ;
         T00127_A288HistoricoSolicitudesNombre = new string[] {""} ;
         T00128_A153HistoricoSolicitudesID = new long[1] ;
         T00126_A153HistoricoSolicitudesID = new long[1] ;
         T00126_A288HistoricoSolicitudesNombre = new string[] {""} ;
         T00129_A153HistoricoSolicitudesID = new long[1] ;
         T001210_A153HistoricoSolicitudesID = new long[1] ;
         T00125_A153HistoricoSolicitudesID = new long[1] ;
         T00125_A288HistoricoSolicitudesNombre = new string[] {""} ;
         T001214_A153HistoricoSolicitudesID = new long[1] ;
         T001214_A154HistoricoSolicitudesItemsID = new short[1] ;
         T001215_A153HistoricoSolicitudesID = new long[1] ;
         Z143EstadoSGNombre = "";
         T001216_A153HistoricoSolicitudesID = new long[1] ;
         T001216_A156HistoricoRelacionesId = new long[1] ;
         T001216_A320HistoricoRelacionesProfesional = new string[] {""} ;
         T001216_A323HistoricoRelacionesNombre = new string[] {""} ;
         T001216_A324HistoricoRelacionesApellido = new string[] {""} ;
         T001216_A143EstadoSGNombre = new string[] {""} ;
         T001216_A321HistoricoRelacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T001216_A322HistoricoRelacionesFechaModif = new DateTime[] {DateTime.MinValue} ;
         T001216_A141EstadoSGTipo = new string[] {""} ;
         T001216_A142EstadoSGId = new int[1] ;
         T00124_A143EstadoSGNombre = new string[] {""} ;
         T001217_A143EstadoSGNombre = new string[] {""} ;
         T001218_A153HistoricoSolicitudesID = new long[1] ;
         T001218_A156HistoricoRelacionesId = new long[1] ;
         T00123_A153HistoricoSolicitudesID = new long[1] ;
         T00123_A156HistoricoRelacionesId = new long[1] ;
         T00123_A320HistoricoRelacionesProfesional = new string[] {""} ;
         T00123_A323HistoricoRelacionesNombre = new string[] {""} ;
         T00123_A324HistoricoRelacionesApellido = new string[] {""} ;
         T00123_A321HistoricoRelacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00123_A322HistoricoRelacionesFechaModif = new DateTime[] {DateTime.MinValue} ;
         T00123_A141EstadoSGTipo = new string[] {""} ;
         T00123_A142EstadoSGId = new int[1] ;
         T00122_A153HistoricoSolicitudesID = new long[1] ;
         T00122_A156HistoricoRelacionesId = new long[1] ;
         T00122_A320HistoricoRelacionesProfesional = new string[] {""} ;
         T00122_A323HistoricoRelacionesNombre = new string[] {""} ;
         T00122_A324HistoricoRelacionesApellido = new string[] {""} ;
         T00122_A321HistoricoRelacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00122_A322HistoricoRelacionesFechaModif = new DateTime[] {DateTime.MinValue} ;
         T00122_A141EstadoSGTipo = new string[] {""} ;
         T00122_A142EstadoSGId = new int[1] ;
         T001222_A143EstadoSGNombre = new string[] {""} ;
         T001223_A153HistoricoSolicitudesID = new long[1] ;
         T001223_A156HistoricoRelacionesId = new long[1] ;
         Gridlevel_relacionesRow = new GXWebRow();
         subGridlevel_relaciones_Linesclass = "";
         ROClassString = "";
         imgprompt_141_142_gximage = "";
         sImgUrl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_relacionesColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T001224_A141EstadoSGTipo = new string[] {""} ;
         T001224_A127SolicitudesID = new long[1] ;
         T001224_A140RelacionesId = new long[1] ;
         T001224_A142EstadoSGId = new int[1] ;
         T001224_A143EstadoSGNombre = new string[] {""} ;
         T001225_A143EstadoSGNombre = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.historicorelaciones__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historicorelaciones__default(),
            new Object[][] {
                new Object[] {
               T00122_A153HistoricoSolicitudesID, T00122_A156HistoricoRelacionesId, T00122_A320HistoricoRelacionesProfesional, T00122_A323HistoricoRelacionesNombre, T00122_A324HistoricoRelacionesApellido, T00122_A321HistoricoRelacionesFechaAlta, T00122_A322HistoricoRelacionesFechaModif, T00122_A141EstadoSGTipo, T00122_A142EstadoSGId
               }
               , new Object[] {
               T00123_A153HistoricoSolicitudesID, T00123_A156HistoricoRelacionesId, T00123_A320HistoricoRelacionesProfesional, T00123_A323HistoricoRelacionesNombre, T00123_A324HistoricoRelacionesApellido, T00123_A321HistoricoRelacionesFechaAlta, T00123_A322HistoricoRelacionesFechaModif, T00123_A141EstadoSGTipo, T00123_A142EstadoSGId
               }
               , new Object[] {
               T00124_A143EstadoSGNombre
               }
               , new Object[] {
               T00125_A153HistoricoSolicitudesID, T00125_A288HistoricoSolicitudesNombre
               }
               , new Object[] {
               T00126_A153HistoricoSolicitudesID, T00126_A288HistoricoSolicitudesNombre
               }
               , new Object[] {
               T00127_A153HistoricoSolicitudesID, T00127_A288HistoricoSolicitudesNombre
               }
               , new Object[] {
               T00128_A153HistoricoSolicitudesID
               }
               , new Object[] {
               T00129_A153HistoricoSolicitudesID
               }
               , new Object[] {
               T001210_A153HistoricoSolicitudesID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001214_A153HistoricoSolicitudesID, T001214_A154HistoricoSolicitudesItemsID
               }
               , new Object[] {
               T001215_A153HistoricoSolicitudesID
               }
               , new Object[] {
               T001216_A153HistoricoSolicitudesID, T001216_A156HistoricoRelacionesId, T001216_A320HistoricoRelacionesProfesional, T001216_A323HistoricoRelacionesNombre, T001216_A324HistoricoRelacionesApellido, T001216_A143EstadoSGNombre, T001216_A321HistoricoRelacionesFechaAlta, T001216_A322HistoricoRelacionesFechaModif, T001216_A141EstadoSGTipo, T001216_A142EstadoSGId
               }
               , new Object[] {
               T001217_A143EstadoSGNombre
               }
               , new Object[] {
               T001218_A153HistoricoSolicitudesID, T001218_A156HistoricoRelacionesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001222_A143EstadoSGNombre
               }
               , new Object[] {
               T001223_A153HistoricoSolicitudesID, T001223_A156HistoricoRelacionesId
               }
               , new Object[] {
               T001224_A141EstadoSGTipo, T001224_A127SolicitudesID, T001224_A140RelacionesId, T001224_A142EstadoSGId, T001224_A143EstadoSGNombre
               }
               , new Object[] {
               T001225_A143EstadoSGNombre
               }
            }
         );
         AV20Pgmname = "HistoricoRelaciones";
      }

      private short nIsMod_44 ;
      private short nRcdDeleted_44 ;
      private short nRcdExists_44 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount44 ;
      private short RcdFound44 ;
      private short nBlankRcdUsr44 ;
      private short RcdFound42 ;
      private short Gx_BScreen ;
      private short nIsDirty_44 ;
      private short subGridlevel_relaciones_Backcolorstyle ;
      private short subGridlevel_relaciones_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_relaciones_Allowselection ;
      private short subGridlevel_relaciones_Allowhovering ;
      private short subGridlevel_relaciones_Allowcollapsing ;
      private short subGridlevel_relaciones_Collapsed ;
      private int nRC_GXsfl_33 ;
      private int nGXsfl_33_idx=1 ;
      private int Z142EstadoSGId ;
      private int A142EstadoSGId ;
      private int trnEnded ;
      private int edtHistoricoSolicitudesID_Enabled ;
      private int edtHistoricoSolicitudesNombre_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtHistoricoRelacionesId_Enabled ;
      private int edtHistoricoRelacionesProfesional_Enabled ;
      private int edtHistoricoRelacionesNombre_Enabled ;
      private int edtHistoricoRelacionesApellido_Enabled ;
      private int edtEstadoSGTipo_Enabled ;
      private int edtHistoricoRelacionesFechaAlta_Enabled ;
      private int edtHistoricoRelacionesFechaModif_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int subGridlevel_relaciones_Backcolor ;
      private int subGridlevel_relaciones_Allbackcolor ;
      private int imgprompt_141_142_Visible ;
      private int defedtHistoricoRelacionesId_Enabled ;
      private int idxLst ;
      private int subGridlevel_relaciones_Selectedindex ;
      private int subGridlevel_relaciones_Selectioncolor ;
      private int subGridlevel_relaciones_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long wcpOAV10HistoricoSolicitudesID ;
      private long Z153HistoricoSolicitudesID ;
      private long Z156HistoricoRelacionesId ;
      private long AV10HistoricoSolicitudesID ;
      private long A153HistoricoSolicitudesID ;
      private long GRIDLEVEL_RELACIONES_nFirstRecordOnPage ;
      private long A156HistoricoRelacionesId ;
      private string sPrefix ;
      private string sGXsfl_33_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z288HistoricoSolicitudesNombre ;
      private string Z320HistoricoRelacionesProfesional ;
      private string Z323HistoricoRelacionesNombre ;
      private string Z324HistoricoRelacionesApellido ;
      private string Z141EstadoSGTipo ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A141EstadoSGTipo ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtHistoricoSolicitudesID_Internalname ;
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
      private string edtHistoricoSolicitudesID_Jsonclick ;
      private string edtHistoricoSolicitudesNombre_Internalname ;
      private string A288HistoricoSolicitudesNombre ;
      private string edtHistoricoSolicitudesNombre_Jsonclick ;
      private string divTableleaflevel_relaciones_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode44 ;
      private string edtHistoricoRelacionesId_Internalname ;
      private string edtHistoricoRelacionesProfesional_Internalname ;
      private string edtHistoricoRelacionesNombre_Internalname ;
      private string edtHistoricoRelacionesApellido_Internalname ;
      private string edtEstadoSGTipo_Internalname ;
      private string dynEstadoSGId_Internalname ;
      private string edtHistoricoRelacionesFechaAlta_Internalname ;
      private string edtHistoricoRelacionesFechaModif_Internalname ;
      private string imgprompt_141_142_Link ;
      private string sStyleString ;
      private string subGridlevel_relaciones_Internalname ;
      private string AV20Pgmname ;
      private string A143EstadoSGNombre ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode42 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A320HistoricoRelacionesProfesional ;
      private string A323HistoricoRelacionesNombre ;
      private string A324HistoricoRelacionesApellido ;
      private string GXEncryptionTmp ;
      private string Z143EstadoSGNombre ;
      private string imgprompt_141_142_Internalname ;
      private string sGXsfl_33_fel_idx="0001" ;
      private string subGridlevel_relaciones_Class ;
      private string subGridlevel_relaciones_Linesclass ;
      private string ROClassString ;
      private string edtHistoricoRelacionesId_Jsonclick ;
      private string edtHistoricoRelacionesProfesional_Jsonclick ;
      private string edtHistoricoRelacionesNombre_Jsonclick ;
      private string edtHistoricoRelacionesApellido_Jsonclick ;
      private string edtEstadoSGTipo_Jsonclick ;
      private string dynEstadoSGId_Jsonclick ;
      private string imgprompt_141_142_gximage ;
      private string sImgUrl ;
      private string edtHistoricoRelacionesFechaAlta_Jsonclick ;
      private string edtHistoricoRelacionesFechaModif_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_relaciones_Header ;
      private string gxwrpcisep ;
      private DateTime Z321HistoricoRelacionesFechaAlta ;
      private DateTime Z322HistoricoRelacionesFechaModif ;
      private DateTime A321HistoricoRelacionesFechaAlta ;
      private DateTime A322HistoricoRelacionesFechaModif ;
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
      private bool AV7IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private bool gxdyncontrolsrefreshing ;
      private IGxSession AV9WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_relacionesContainer ;
      private GXWebRow Gridlevel_relacionesRow ;
      private GXWebColumn Gridlevel_relacionesColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynEstadoSGId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV11WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] T00127_A153HistoricoSolicitudesID ;
      private string[] T00127_A288HistoricoSolicitudesNombre ;
      private long[] T00128_A153HistoricoSolicitudesID ;
      private long[] T00126_A153HistoricoSolicitudesID ;
      private string[] T00126_A288HistoricoSolicitudesNombre ;
      private long[] T00129_A153HistoricoSolicitudesID ;
      private long[] T001210_A153HistoricoSolicitudesID ;
      private long[] T00125_A153HistoricoSolicitudesID ;
      private string[] T00125_A288HistoricoSolicitudesNombre ;
      private long[] T001214_A153HistoricoSolicitudesID ;
      private short[] T001214_A154HistoricoSolicitudesItemsID ;
      private long[] T001215_A153HistoricoSolicitudesID ;
      private long[] T001216_A153HistoricoSolicitudesID ;
      private long[] T001216_A156HistoricoRelacionesId ;
      private string[] T001216_A320HistoricoRelacionesProfesional ;
      private string[] T001216_A323HistoricoRelacionesNombre ;
      private string[] T001216_A324HistoricoRelacionesApellido ;
      private string[] T001216_A143EstadoSGNombre ;
      private DateTime[] T001216_A321HistoricoRelacionesFechaAlta ;
      private DateTime[] T001216_A322HistoricoRelacionesFechaModif ;
      private string[] T001216_A141EstadoSGTipo ;
      private int[] T001216_A142EstadoSGId ;
      private string[] T00124_A143EstadoSGNombre ;
      private string[] T001217_A143EstadoSGNombre ;
      private long[] T001218_A153HistoricoSolicitudesID ;
      private long[] T001218_A156HistoricoRelacionesId ;
      private long[] T00123_A153HistoricoSolicitudesID ;
      private long[] T00123_A156HistoricoRelacionesId ;
      private string[] T00123_A320HistoricoRelacionesProfesional ;
      private string[] T00123_A323HistoricoRelacionesNombre ;
      private string[] T00123_A324HistoricoRelacionesApellido ;
      private DateTime[] T00123_A321HistoricoRelacionesFechaAlta ;
      private DateTime[] T00123_A322HistoricoRelacionesFechaModif ;
      private string[] T00123_A141EstadoSGTipo ;
      private int[] T00123_A142EstadoSGId ;
      private long[] T00122_A153HistoricoSolicitudesID ;
      private long[] T00122_A156HistoricoRelacionesId ;
      private string[] T00122_A320HistoricoRelacionesProfesional ;
      private string[] T00122_A323HistoricoRelacionesNombre ;
      private string[] T00122_A324HistoricoRelacionesApellido ;
      private DateTime[] T00122_A321HistoricoRelacionesFechaAlta ;
      private DateTime[] T00122_A322HistoricoRelacionesFechaModif ;
      private string[] T00122_A141EstadoSGTipo ;
      private int[] T00122_A142EstadoSGId ;
      private string[] T001222_A143EstadoSGNombre ;
      private long[] T001223_A153HistoricoSolicitudesID ;
      private long[] T001223_A156HistoricoRelacionesId ;
      private string[] T001224_A141EstadoSGTipo ;
      private long[] T001224_A127SolicitudesID ;
      private long[] T001224_A140RelacionesId ;
      private int[] T001224_A142EstadoSGId ;
      private string[] T001224_A143EstadoSGNombre ;
      private string[] T001225_A143EstadoSGNombre ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class historicorelaciones__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class historicorelaciones__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00122;
        prmT00122 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoRelacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT00123;
        prmT00123 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoRelacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT00124;
        prmT00124 = new Object[] {
        new ParDef("@EstadoSGTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadoSGId",GXType.Int32,5,0)
        };
        Object[] prmT00125;
        prmT00125 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT00126;
        prmT00126 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT00127;
        prmT00127 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT00128;
        prmT00128 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT00129;
        prmT00129 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT001210;
        prmT001210 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT001211;
        prmT001211 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoSolicitudesNombre",GXType.NChar,100,0)
        };
        Object[] prmT001212;
        prmT001212 = new Object[] {
        new ParDef("@HistoricoSolicitudesNombre",GXType.NChar,100,0) ,
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT001213;
        prmT001213 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT001214;
        prmT001214 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT001215;
        prmT001215 = new Object[] {
        };
        Object[] prmT001216;
        prmT001216 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoRelacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT001217;
        prmT001217 = new Object[] {
        new ParDef("@EstadoSGTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadoSGId",GXType.Int32,5,0)
        };
        Object[] prmT001218;
        prmT001218 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoRelacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT001219;
        prmT001219 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoRelacionesId",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoRelacionesProfesional",GXType.NChar,20,0) ,
        new ParDef("@HistoricoRelacionesNombre",GXType.NChar,80,0) ,
        new ParDef("@HistoricoRelacionesApellido",GXType.NChar,80,0) ,
        new ParDef("@HistoricoRelacionesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@HistoricoRelacionesFechaModif",GXType.DateTime,8,5) ,
        new ParDef("@EstadoSGTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadoSGId",GXType.Int32,5,0)
        };
        Object[] prmT001220;
        prmT001220 = new Object[] {
        new ParDef("@HistoricoRelacionesProfesional",GXType.NChar,20,0) ,
        new ParDef("@HistoricoRelacionesNombre",GXType.NChar,80,0) ,
        new ParDef("@HistoricoRelacionesApellido",GXType.NChar,80,0) ,
        new ParDef("@HistoricoRelacionesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@HistoricoRelacionesFechaModif",GXType.DateTime,8,5) ,
        new ParDef("@EstadoSGTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadoSGId",GXType.Int32,5,0) ,
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoRelacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT001221;
        prmT001221 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoRelacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT001222;
        prmT001222 = new Object[] {
        new ParDef("@EstadoSGTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadoSGId",GXType.Int32,5,0)
        };
        Object[] prmT001223;
        prmT001223 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT001224;
        prmT001224 = new Object[] {
        new ParDef("@EstadoSGTipo",GXType.NChar,3,0)
        };
        Object[] prmT001225;
        prmT001225 = new Object[] {
        new ParDef("@EstadoSGTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadoSGId",GXType.Int32,5,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00122", "SELECT [HistoricoSolicitudesID], [HistoricoRelacionesId], [HistoricoRelacionesProfesional], [HistoricoRelacionesNombre], [HistoricoRelacionesApellido], [HistoricoRelacionesFechaAlta], [HistoricoRelacionesFechaModif], [EstadoSGTipo] AS EstadoSGTipo, [EstadoSGId] AS EstadoSGId FROM [HistoricoRelacionesRelaciones] WITH (UPDLOCK) WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID AND [HistoricoRelacionesId] = @HistoricoRelacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00122,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00123", "SELECT [HistoricoSolicitudesID], [HistoricoRelacionesId], [HistoricoRelacionesProfesional], [HistoricoRelacionesNombre], [HistoricoRelacionesApellido], [HistoricoRelacionesFechaAlta], [HistoricoRelacionesFechaModif], [EstadoSGTipo] AS EstadoSGTipo, [EstadoSGId] AS EstadoSGId FROM [HistoricoRelacionesRelaciones] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID AND [HistoricoRelacionesId] = @HistoricoRelacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00123,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00124", "SELECT [EstadosGenericosNombre] AS EstadoSGNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadoSGTipo AND [EstadosGenericosId] = @EstadoSGId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00124,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00125", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesNombre] FROM [HistoricoSolicitudes] WITH (UPDLOCK) WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00125,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00126", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesNombre] FROM [HistoricoSolicitudes] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00126,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00127", "SELECT TM1.[HistoricoSolicitudesID], TM1.[HistoricoSolicitudesNombre] FROM [HistoricoSolicitudes] TM1 WHERE TM1.[HistoricoSolicitudesID] = @HistoricoSolicitudesID ORDER BY TM1.[HistoricoSolicitudesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00127,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00128", "SELECT [HistoricoSolicitudesID] FROM [HistoricoSolicitudes] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00128,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00129", "SELECT TOP 1 [HistoricoSolicitudesID] FROM [HistoricoSolicitudes] WHERE ( [HistoricoSolicitudesID] > @HistoricoSolicitudesID) ORDER BY [HistoricoSolicitudesID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00129,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001210", "SELECT TOP 1 [HistoricoSolicitudesID] FROM [HistoricoSolicitudes] WHERE ( [HistoricoSolicitudesID] < @HistoricoSolicitudesID) ORDER BY [HistoricoSolicitudesID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001210,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001211", "INSERT INTO [HistoricoSolicitudes]([HistoricoSolicitudesID], [HistoricoSolicitudesNombre], [HistoricoSolicitudesTelefono], [HistoricoSolicitudesMail], [HistoricoPaisID], [HistoricoDepartamentoId], [HistoricoDepartamentoMunicipio], [HistoricoZonasID], [HistoricoSolicitudesDireccion], [HistoricoSolicitudesAutoEnumer], [HistoricoSolicitudesCotizacion], [HistoricoSolicitudServicioSolC], [EstadosSolTipo], [EstadosSolId], [HistoricoSolicitudesOtros1], [HistoricoSolicitudesOtros2], [HistoricoSolicitudesOtros3], [HistoricoSolicitudesFechaAlta], [HistoricoSolicitudesFechaActua], [HistoricoSolicitudesFechaInsta], [HistoricoSolicitudesHoraInstal], [HistoricoSolicitudesComentario], [MetodoPagosID], [HistoricoSolicitudesNota], [HistoricoSolicitudesNotificaci], [HistoricoSolicitudesOrigenPago], [HistoricoSolicitudesPagado], [HistoricoSolicitudesNombreAux], [HistoricoSolicitudesSubTipo], [HistoricoSolicitudesComProv], [HistoricoSolicitudesComProvP], [HistoricoSolicitudesComALM], [HistoricoSolicitudesComALMP], [HistoricoSolicitudesProvID], [HistoricoSolicitudesProvNombre]) VALUES(@HistoricoSolicitudesID, @HistoricoSolicitudesNombre, '', '', '', convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0), convert(int, 0), '', '', convert(int, 0), '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', convert(int, 0), '', '', '', '', '', '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '')", GxErrorMask.GX_NOMASK,prmT001211)
           ,new CursorDef("T001212", "UPDATE [HistoricoSolicitudes] SET [HistoricoSolicitudesNombre]=@HistoricoSolicitudesNombre  WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID", GxErrorMask.GX_NOMASK,prmT001212)
           ,new CursorDef("T001213", "DELETE FROM [HistoricoSolicitudes]  WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID", GxErrorMask.GX_NOMASK,prmT001213)
           ,new CursorDef("T001214", "SELECT TOP 1 [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID] FROM [HistoricoSolicitudesItems] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001214,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001215", "SELECT [HistoricoSolicitudesID] FROM [HistoricoSolicitudes] ORDER BY [HistoricoSolicitudesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001215,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001216", "SELECT T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesId], T1.[HistoricoRelacionesProfesional], T1.[HistoricoRelacionesNombre], T1.[HistoricoRelacionesApellido], T2.[EstadosGenericosNombre] AS EstadoSGNombre, T1.[HistoricoRelacionesFechaAlta], T1.[HistoricoRelacionesFechaModif], T1.[EstadoSGTipo] AS EstadoSGTipo, T1.[EstadoSGId] AS EstadoSGId FROM ([HistoricoRelacionesRelaciones] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadoSGTipo] AND T2.[EstadosGenericosId] = T1.[EstadoSGId]) WHERE T1.[HistoricoSolicitudesID] = @HistoricoSolicitudesID and T1.[HistoricoRelacionesId] = @HistoricoRelacionesId ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001216,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001217", "SELECT [EstadosGenericosNombre] AS EstadoSGNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadoSGTipo AND [EstadosGenericosId] = @EstadoSGId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001217,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001218", "SELECT [HistoricoSolicitudesID], [HistoricoRelacionesId] FROM [HistoricoRelacionesRelaciones] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID AND [HistoricoRelacionesId] = @HistoricoRelacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001218,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001219", "INSERT INTO [HistoricoRelacionesRelaciones]([HistoricoSolicitudesID], [HistoricoRelacionesId], [HistoricoRelacionesProfesional], [HistoricoRelacionesNombre], [HistoricoRelacionesApellido], [HistoricoRelacionesFechaAlta], [HistoricoRelacionesFechaModif], [EstadoSGTipo], [EstadoSGId]) VALUES(@HistoricoSolicitudesID, @HistoricoRelacionesId, @HistoricoRelacionesProfesional, @HistoricoRelacionesNombre, @HistoricoRelacionesApellido, @HistoricoRelacionesFechaAlta, @HistoricoRelacionesFechaModif, @EstadoSGTipo, @EstadoSGId)", GxErrorMask.GX_NOMASK,prmT001219)
           ,new CursorDef("T001220", "UPDATE [HistoricoRelacionesRelaciones] SET [HistoricoRelacionesProfesional]=@HistoricoRelacionesProfesional, [HistoricoRelacionesNombre]=@HistoricoRelacionesNombre, [HistoricoRelacionesApellido]=@HistoricoRelacionesApellido, [HistoricoRelacionesFechaAlta]=@HistoricoRelacionesFechaAlta, [HistoricoRelacionesFechaModif]=@HistoricoRelacionesFechaModif, [EstadoSGTipo]=@EstadoSGTipo, [EstadoSGId]=@EstadoSGId  WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID AND [HistoricoRelacionesId] = @HistoricoRelacionesId", GxErrorMask.GX_NOMASK,prmT001220)
           ,new CursorDef("T001221", "DELETE FROM [HistoricoRelacionesRelaciones]  WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID AND [HistoricoRelacionesId] = @HistoricoRelacionesId", GxErrorMask.GX_NOMASK,prmT001221)
           ,new CursorDef("T001222", "SELECT [EstadosGenericosNombre] AS EstadoSGNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadoSGTipo AND [EstadosGenericosId] = @EstadoSGId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001222,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001223", "SELECT [HistoricoSolicitudesID], [HistoricoRelacionesId] FROM [HistoricoRelacionesRelaciones] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ORDER BY [HistoricoSolicitudesID], [HistoricoRelacionesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001223,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001224", "SELECT T2.[EstadosTipo] AS EstadoSGTipo, T1.[SolicitudesID], T1.[RelacionesId], T1.[EstadoSGId] AS EstadoSGId, T2.[EstadosGenericosNombre] AS EstadoSGNombre FROM ([Relaciones] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadoSGTipo] AND T2.[EstadosGenericosId] = T1.[EstadoSGId]) WHERE T2.[EstadosTipo] = @EstadoSGTipo ORDER BY T2.[EstadosGenericosNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001224,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001225", "SELECT [EstadosGenericosNombre] AS EstadoSGNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadoSGTipo AND [EstadosGenericosId] = @EstadoSGId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001225,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
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
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((string[]) buf[5])[0] = rslt.getString(6, 80);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 3);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
     }
  }

}

}
