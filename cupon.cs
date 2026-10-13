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
   public class cupon : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "cupon.aspx")), "cupon.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "cupon.aspx")))) ;
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
                  AV7CuponId = (long)(Math.Round(NumberUtil.Val( GetPar( "CuponId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7CuponId", StringUtil.LTrimStr( (decimal)(AV7CuponId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCUPONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CuponId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Cupon", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCuponPercent_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cupon( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cupon( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_CuponId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CuponId = aP1_CuponId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCuponId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCuponId_Internalname, context.GetMessage( "Código", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCuponId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1013CuponId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCuponId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1013CuponId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1013CuponId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCuponId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCuponId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Cupon.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCuponPercent_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCuponPercent_Internalname, context.GetMessage( "Porcentaje", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCuponPercent_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1014CuponPercent), 2, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCuponPercent_Enabled!=0) ? context.localUtil.Format( (decimal)(A1014CuponPercent), "Z9") : context.localUtil.Format( (decimal)(A1014CuponPercent), "Z9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCuponPercent_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCuponPercent_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Cupon.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCuponFechaVence_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCuponFechaVence_Internalname, context.GetMessage( "Vencimiento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCuponFechaVence_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCuponFechaVence_Internalname, context.localUtil.Format(A1017CuponFechaVence, "99/99/99"), context.localUtil.Format( A1017CuponFechaVence, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCuponFechaVence_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCuponFechaVence_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Cupon.htm");
         GxWebStd.gx_bitmap( context, edtCuponFechaVence_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCuponFechaVence_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Cupon.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cupon.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cupon.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cupon.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCuponUser_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1015CuponUser), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCuponUser_Enabled!=0) ? context.localUtil.Format( (decimal)(A1015CuponUser), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1015CuponUser), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCuponUser_Jsonclick, 0, "Attribute", "", "", "", "", edtCuponUser_Visible, edtCuponUser_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "UserID", "end", false, "", "HLP_Cupon.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCuponUsado_Internalname, StringUtil.BoolToStr( A1018CuponUsado), StringUtil.BoolToStr( A1018CuponUsado), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCuponUsado_Jsonclick, 0, "Attribute", "", "", "", "", edtCuponUsado_Visible, edtCuponUsado_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "", "end", false, "", "HLP_Cupon.htm");
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
         E11302 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1013CuponId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1013CuponId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z1015CuponUser = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1015CuponUser"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z1019CuponUserUpdated = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1019CuponUserUpdated"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z1014CuponPercent = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z1014CuponPercent"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z1017CuponFechaVence = context.localUtil.CToD( cgiGet( "Z1017CuponFechaVence"), 0);
               Z1018CuponUsado = StringUtil.StrToBool( cgiGet( "Z1018CuponUsado"));
               A1019CuponUserUpdated = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1019CuponUserUpdated"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7CuponId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCUPONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A1019CuponUserUpdated = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CUPONUSERUPDATED"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV12Pgmname = cgiGet( "vPGMNAME");
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
               A1013CuponId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCuponId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n1013CuponId = false;
               AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtCuponPercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCuponPercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUPONPERCENT");
                  AnyError = 1;
                  GX_FocusControl = edtCuponPercent_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1014CuponPercent = 0;
                  AssignAttri("", false, "A1014CuponPercent", StringUtil.LTrimStr( (decimal)(A1014CuponPercent), 2, 0));
               }
               else
               {
                  A1014CuponPercent = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCuponPercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1014CuponPercent", StringUtil.LTrimStr( (decimal)(A1014CuponPercent), 2, 0));
               }
               if ( context.localUtil.VCDate( cgiGet( edtCuponFechaVence_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Cupon Fecha Vence", "")}), 1, "CUPONFECHAVENCE");
                  AnyError = 1;
                  GX_FocusControl = edtCuponFechaVence_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1017CuponFechaVence = DateTime.MinValue;
                  AssignAttri("", false, "A1017CuponFechaVence", context.localUtil.Format(A1017CuponFechaVence, "99/99/99"));
               }
               else
               {
                  A1017CuponFechaVence = context.localUtil.CToD( cgiGet( edtCuponFechaVence_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A1017CuponFechaVence", context.localUtil.Format(A1017CuponFechaVence, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCuponUser_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCuponUser_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUPONUSER");
                  AnyError = 1;
                  GX_FocusControl = edtCuponUser_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1015CuponUser = 0;
                  AssignAttri("", false, "A1015CuponUser", StringUtil.LTrimStr( (decimal)(A1015CuponUser), 10, 0));
               }
               else
               {
                  A1015CuponUser = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCuponUser_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1015CuponUser", StringUtil.LTrimStr( (decimal)(A1015CuponUser), 10, 0));
               }
               A1018CuponUsado = StringUtil.StrToBool( cgiGet( edtCuponUsado_Internalname));
               AssignAttri("", false, "A1018CuponUsado", A1018CuponUsado);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Cupon");
               A1013CuponId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCuponId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n1013CuponId = false;
               AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
               forbiddenHiddens.Add("CuponId", context.localUtil.Format( (decimal)(A1013CuponId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("CuponUserUpdated", context.localUtil.Format( (decimal)(A1019CuponUserUpdated), "ZZZZZZZZZ9"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1013CuponId != Z1013CuponId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("cupon:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A1013CuponId = (long)(Math.Round(NumberUtil.Val( GetPar( "CuponId"), "."), 18, MidpointRounding.ToEven));
                  n1013CuponId = false;
                  AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
                  getEqualNoModal( ) ;
                  if ( ! (0==AV7CuponId) )
                  {
                     A1013CuponId = AV7CuponId;
                     n1013CuponId = false;
                     AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
                  }
                  else
                  {
                     if ( IsIns( )  && (0==A1013CuponId) && ( Gx_BScreen == 0 ) )
                     {
                        A1013CuponId = 1234;
                        n1013CuponId = false;
                        AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode147 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (0==AV7CuponId) )
                     {
                        A1013CuponId = AV7CuponId;
                        n1013CuponId = false;
                        AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
                     }
                     else
                     {
                        if ( IsIns( )  && (0==A1013CuponId) && ( Gx_BScreen == 0 ) )
                        {
                           A1013CuponId = 1234;
                           n1013CuponId = false;
                           AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
                        }
                     }
                     Gx_mode = sMode147;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound147 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_300( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CUPONID");
                        AnyError = 1;
                        GX_FocusControl = edtCuponId_Internalname;
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
                           E11302 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12302 ();
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
            E12302 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll30147( ) ;
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
            DisableAttributes30147( ) ;
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

      protected void CONFIRM_300( )
      {
         BeforeValidate30147( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls30147( ) ;
            }
            else
            {
               CheckExtendedTable30147( ) ;
               CloseExtendedTableCursors30147( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption300( )
      {
      }

      protected void E11302( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCupon_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCupon_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCupon_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV12Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
         edtCuponUser_Visible = 0;
         AssignProp("", false, edtCuponUser_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCuponUser_Visible), 5, 0), true);
         edtCuponUsado_Visible = 0;
         AssignProp("", false, edtCuponUsado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCuponUsado_Visible), 5, 0), true);
      }

      protected void E12302( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("cuponww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM30147( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1015CuponUser = T00303_A1015CuponUser[0];
               Z1019CuponUserUpdated = T00303_A1019CuponUserUpdated[0];
               Z1014CuponPercent = T00303_A1014CuponPercent[0];
               Z1017CuponFechaVence = T00303_A1017CuponFechaVence[0];
               Z1018CuponUsado = T00303_A1018CuponUsado[0];
            }
            else
            {
               Z1015CuponUser = A1015CuponUser;
               Z1019CuponUserUpdated = A1019CuponUserUpdated;
               Z1014CuponPercent = A1014CuponPercent;
               Z1017CuponFechaVence = A1017CuponFechaVence;
               Z1018CuponUsado = A1018CuponUsado;
            }
         }
         if ( GX_JID == -6 )
         {
            Z1013CuponId = A1013CuponId;
            Z1015CuponUser = A1015CuponUser;
            Z1019CuponUserUpdated = A1019CuponUserUpdated;
            Z1014CuponPercent = A1014CuponPercent;
            Z1017CuponFechaVence = A1017CuponFechaVence;
            Z1018CuponUsado = A1018CuponUsado;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCuponId_Enabled = 0;
         AssignProp("", false, edtCuponId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCuponId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtCuponId_Enabled = 0;
         AssignProp("", false, edtCuponId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCuponId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A1015CuponUser = AV8WWPContext.gxTpr_Userid;
            AssignAttri("", false, "A1015CuponUser", StringUtil.LTrimStr( (decimal)(A1015CuponUser), 10, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            A1019CuponUserUpdated = AV8WWPContext.gxTpr_Userid;
            AssignAttri("", false, "A1019CuponUserUpdated", StringUtil.LTrimStr( (decimal)(A1019CuponUserUpdated), 10, 0));
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
         if ( ! (0==AV7CuponId) )
         {
            A1013CuponId = AV7CuponId;
            n1013CuponId = false;
            AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A1013CuponId) && ( Gx_BScreen == 0 ) )
            {
               A1013CuponId = 1234;
               n1013CuponId = false;
               AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
            }
         }
      }

      protected void Load30147( )
      {
         /* Using cursor T00304 */
         pr_default.execute(2, new Object[] {n1013CuponId, A1013CuponId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound147 = 1;
            A1015CuponUser = T00304_A1015CuponUser[0];
            AssignAttri("", false, "A1015CuponUser", StringUtil.LTrimStr( (decimal)(A1015CuponUser), 10, 0));
            A1019CuponUserUpdated = T00304_A1019CuponUserUpdated[0];
            A1014CuponPercent = T00304_A1014CuponPercent[0];
            AssignAttri("", false, "A1014CuponPercent", StringUtil.LTrimStr( (decimal)(A1014CuponPercent), 2, 0));
            A1017CuponFechaVence = T00304_A1017CuponFechaVence[0];
            AssignAttri("", false, "A1017CuponFechaVence", context.localUtil.Format(A1017CuponFechaVence, "99/99/99"));
            A1018CuponUsado = T00304_A1018CuponUsado[0];
            AssignAttri("", false, "A1018CuponUsado", A1018CuponUsado);
            ZM30147( -6) ;
         }
         pr_default.close(2);
         OnLoadActions30147( ) ;
      }

      protected void OnLoadActions30147( )
      {
         AV12Pgmname = "Cupon";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CheckExtendedTable30147( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV12Pgmname = "Cupon";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         if ( ! ( (DateTime.MinValue==A1017CuponFechaVence) || ( DateTimeUtil.ResetTime ( A1017CuponFechaVence ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Cupon Fecha Vence", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "CUPONFECHAVENCE");
            AnyError = 1;
            GX_FocusControl = edtCuponFechaVence_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors30147( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey30147( )
      {
         /* Using cursor T00305 */
         pr_default.execute(3, new Object[] {n1013CuponId, A1013CuponId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound147 = 1;
         }
         else
         {
            RcdFound147 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00303 */
         pr_default.execute(1, new Object[] {n1013CuponId, A1013CuponId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM30147( 6) ;
            RcdFound147 = 1;
            A1013CuponId = T00303_A1013CuponId[0];
            n1013CuponId = T00303_n1013CuponId[0];
            AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
            A1015CuponUser = T00303_A1015CuponUser[0];
            AssignAttri("", false, "A1015CuponUser", StringUtil.LTrimStr( (decimal)(A1015CuponUser), 10, 0));
            A1019CuponUserUpdated = T00303_A1019CuponUserUpdated[0];
            A1014CuponPercent = T00303_A1014CuponPercent[0];
            AssignAttri("", false, "A1014CuponPercent", StringUtil.LTrimStr( (decimal)(A1014CuponPercent), 2, 0));
            A1017CuponFechaVence = T00303_A1017CuponFechaVence[0];
            AssignAttri("", false, "A1017CuponFechaVence", context.localUtil.Format(A1017CuponFechaVence, "99/99/99"));
            A1018CuponUsado = T00303_A1018CuponUsado[0];
            AssignAttri("", false, "A1018CuponUsado", A1018CuponUsado);
            Z1013CuponId = A1013CuponId;
            sMode147 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load30147( ) ;
            if ( AnyError == 1 )
            {
               RcdFound147 = 0;
               InitializeNonKey30147( ) ;
            }
            Gx_mode = sMode147;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound147 = 0;
            InitializeNonKey30147( ) ;
            sMode147 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode147;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey30147( ) ;
         if ( RcdFound147 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound147 = 0;
         /* Using cursor T00306 */
         pr_default.execute(4, new Object[] {n1013CuponId, A1013CuponId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00306_A1013CuponId[0] < A1013CuponId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00306_A1013CuponId[0] > A1013CuponId ) ) )
            {
               A1013CuponId = T00306_A1013CuponId[0];
               n1013CuponId = T00306_n1013CuponId[0];
               AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
               RcdFound147 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound147 = 0;
         /* Using cursor T00307 */
         pr_default.execute(5, new Object[] {n1013CuponId, A1013CuponId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00307_A1013CuponId[0] > A1013CuponId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00307_A1013CuponId[0] < A1013CuponId ) ) )
            {
               A1013CuponId = T00307_A1013CuponId[0];
               n1013CuponId = T00307_n1013CuponId[0];
               AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
               RcdFound147 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey30147( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCuponPercent_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert30147( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound147 == 1 )
            {
               if ( A1013CuponId != Z1013CuponId )
               {
                  A1013CuponId = Z1013CuponId;
                  n1013CuponId = false;
                  AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CUPONID");
                  AnyError = 1;
                  GX_FocusControl = edtCuponId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCuponPercent_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update30147( ) ;
                  GX_FocusControl = edtCuponPercent_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1013CuponId != Z1013CuponId )
               {
                  /* Insert record */
                  GX_FocusControl = edtCuponPercent_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert30147( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CUPONID");
                     AnyError = 1;
                     GX_FocusControl = edtCuponId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCuponPercent_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert30147( ) ;
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
         if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A1013CuponId != Z1013CuponId )
         {
            A1013CuponId = Z1013CuponId;
            n1013CuponId = false;
            AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CUPONID");
            AnyError = 1;
            GX_FocusControl = edtCuponId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCuponPercent_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency30147( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00302 */
            pr_default.execute(0, new Object[] {n1013CuponId, A1013CuponId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cupon"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1015CuponUser != T00302_A1015CuponUser[0] ) || ( Z1019CuponUserUpdated != T00302_A1019CuponUserUpdated[0] ) || ( Z1014CuponPercent != T00302_A1014CuponPercent[0] ) || ( DateTimeUtil.ResetTime ( Z1017CuponFechaVence ) != DateTimeUtil.ResetTime ( T00302_A1017CuponFechaVence[0] ) ) || ( Z1018CuponUsado != T00302_A1018CuponUsado[0] ) )
            {
               if ( Z1015CuponUser != T00302_A1015CuponUser[0] )
               {
                  GXUtil.WriteLog("cupon:[seudo value changed for attri]"+"CuponUser");
                  GXUtil.WriteLogRaw("Old: ",Z1015CuponUser);
                  GXUtil.WriteLogRaw("Current: ",T00302_A1015CuponUser[0]);
               }
               if ( Z1019CuponUserUpdated != T00302_A1019CuponUserUpdated[0] )
               {
                  GXUtil.WriteLog("cupon:[seudo value changed for attri]"+"CuponUserUpdated");
                  GXUtil.WriteLogRaw("Old: ",Z1019CuponUserUpdated);
                  GXUtil.WriteLogRaw("Current: ",T00302_A1019CuponUserUpdated[0]);
               }
               if ( Z1014CuponPercent != T00302_A1014CuponPercent[0] )
               {
                  GXUtil.WriteLog("cupon:[seudo value changed for attri]"+"CuponPercent");
                  GXUtil.WriteLogRaw("Old: ",Z1014CuponPercent);
                  GXUtil.WriteLogRaw("Current: ",T00302_A1014CuponPercent[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1017CuponFechaVence ) != DateTimeUtil.ResetTime ( T00302_A1017CuponFechaVence[0] ) )
               {
                  GXUtil.WriteLog("cupon:[seudo value changed for attri]"+"CuponFechaVence");
                  GXUtil.WriteLogRaw("Old: ",Z1017CuponFechaVence);
                  GXUtil.WriteLogRaw("Current: ",T00302_A1017CuponFechaVence[0]);
               }
               if ( Z1018CuponUsado != T00302_A1018CuponUsado[0] )
               {
                  GXUtil.WriteLog("cupon:[seudo value changed for attri]"+"CuponUsado");
                  GXUtil.WriteLogRaw("Old: ",Z1018CuponUsado);
                  GXUtil.WriteLogRaw("Current: ",T00302_A1018CuponUsado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Cupon"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert30147( )
      {
         BeforeValidate30147( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable30147( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM30147( 0) ;
            CheckOptimisticConcurrency30147( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm30147( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert30147( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00308 */
                     pr_default.execute(6, new Object[] {A1015CuponUser, A1019CuponUserUpdated, A1014CuponPercent, A1017CuponFechaVence, A1018CuponUsado});
                     A1013CuponId = T00308_A1013CuponId[0];
                     n1013CuponId = T00308_n1013CuponId[0];
                     AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Cupon");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
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
            else
            {
               Load30147( ) ;
            }
            EndLevel30147( ) ;
         }
         CloseExtendedTableCursors30147( ) ;
      }

      protected void Update30147( )
      {
         BeforeValidate30147( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable30147( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency30147( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm30147( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate30147( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00309 */
                     pr_default.execute(7, new Object[] {A1015CuponUser, A1019CuponUserUpdated, A1014CuponPercent, A1017CuponFechaVence, A1018CuponUsado, n1013CuponId, A1013CuponId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Cupon");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cupon"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate30147( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
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
            EndLevel30147( ) ;
         }
         CloseExtendedTableCursors30147( ) ;
      }

      protected void DeferredUpdate30147( )
      {
      }

      protected void delete( )
      {
         BeforeValidate30147( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency30147( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls30147( ) ;
            AfterConfirm30147( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete30147( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003010 */
                  pr_default.execute(8, new Object[] {n1013CuponId, A1013CuponId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Cupon");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
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
         sMode147 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel30147( ) ;
         Gx_mode = sMode147;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls30147( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV12Pgmname = "Cupon";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T003011 */
            pr_default.execute(9, new Object[] {n1013CuponId, A1013CuponId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel30147( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete30147( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cupon",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues300( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cupon",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart30147( )
      {
         /* Scan By routine */
         /* Using cursor T003012 */
         pr_default.execute(10);
         RcdFound147 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound147 = 1;
            A1013CuponId = T003012_A1013CuponId[0];
            n1013CuponId = T003012_n1013CuponId[0];
            AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext30147( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound147 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound147 = 1;
            A1013CuponId = T003012_A1013CuponId[0];
            n1013CuponId = T003012_n1013CuponId[0];
            AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
         }
      }

      protected void ScanEnd30147( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm30147( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert30147( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate30147( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete30147( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete30147( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate30147( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes30147( )
      {
         edtCuponId_Enabled = 0;
         AssignProp("", false, edtCuponId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCuponId_Enabled), 5, 0), true);
         edtCuponPercent_Enabled = 0;
         AssignProp("", false, edtCuponPercent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCuponPercent_Enabled), 5, 0), true);
         edtCuponFechaVence_Enabled = 0;
         AssignProp("", false, edtCuponFechaVence_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCuponFechaVence_Enabled), 5, 0), true);
         edtCuponUser_Enabled = 0;
         AssignProp("", false, edtCuponUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCuponUser_Enabled), 5, 0), true);
         edtCuponUsado_Enabled = 0;
         AssignProp("", false, edtCuponUsado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCuponUsado_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes30147( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues300( )
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
         GXEncryptionTmp = "cupon.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CuponId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cupon.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Cupon");
         forbiddenHiddens.Add("CuponId", context.localUtil.Format( (decimal)(A1013CuponId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("CuponUserUpdated", context.localUtil.Format( (decimal)(A1019CuponUserUpdated), "ZZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cupon:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1013CuponId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1013CuponId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z1015CuponUser", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1015CuponUser), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z1019CuponUserUpdated", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1019CuponUserUpdated), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z1014CuponPercent", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1014CuponPercent), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z1017CuponFechaVence", context.localUtil.DToC( Z1017CuponFechaVence, 0, "/"));
         GxWebStd.gx_boolean_hidden_field( context, "Z1018CuponUsado", Z1018CuponUsado);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vCUPONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CuponId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCUPONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CuponId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CUPONUSERUPDATED", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1019CuponUserUpdated), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV12Pgmname));
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
         GXEncryptionTmp = "cupon.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CuponId,18,0));
         return formatLink("cupon.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Cupon" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Cupon", "") ;
      }

      protected void InitializeNonKey30147( )
      {
         A1015CuponUser = 0;
         AssignAttri("", false, "A1015CuponUser", StringUtil.LTrimStr( (decimal)(A1015CuponUser), 10, 0));
         A1019CuponUserUpdated = 0;
         AssignAttri("", false, "A1019CuponUserUpdated", StringUtil.LTrimStr( (decimal)(A1019CuponUserUpdated), 10, 0));
         A1014CuponPercent = 0;
         AssignAttri("", false, "A1014CuponPercent", StringUtil.LTrimStr( (decimal)(A1014CuponPercent), 2, 0));
         A1017CuponFechaVence = DateTime.MinValue;
         AssignAttri("", false, "A1017CuponFechaVence", context.localUtil.Format(A1017CuponFechaVence, "99/99/99"));
         A1018CuponUsado = false;
         AssignAttri("", false, "A1018CuponUsado", A1018CuponUsado);
         Z1015CuponUser = 0;
         Z1019CuponUserUpdated = 0;
         Z1014CuponPercent = 0;
         Z1017CuponFechaVence = DateTime.MinValue;
         Z1018CuponUsado = false;
      }

      protected void InitAll30147( )
      {
         A1013CuponId = 1234;
         n1013CuponId = false;
         AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
         InitializeNonKey30147( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026981495332", true, true, false);
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
         context.AddJavascriptSource("cupon.js", "?2026981495332", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCuponId_Internalname = "CUPONID";
         edtCuponPercent_Internalname = "CUPONPERCENT";
         edtCuponFechaVence_Internalname = "CUPONFECHAVENCE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtCuponUser_Internalname = "CUPONUSER";
         edtCuponUsado_Internalname = "CUPONUSADO";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
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
         Form.Caption = context.GetMessage( "Cupon", "");
         edtCuponUsado_Jsonclick = "";
         edtCuponUsado_Enabled = 1;
         edtCuponUsado_Visible = 1;
         edtCuponUser_Jsonclick = "";
         edtCuponUser_Enabled = 1;
         edtCuponUser_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCuponFechaVence_Jsonclick = "";
         edtCuponFechaVence_Enabled = 1;
         edtCuponPercent_Jsonclick = "";
         edtCuponPercent_Enabled = 1;
         edtCuponId_Jsonclick = "";
         edtCuponId_Enabled = 0;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7CuponId',fld:'vCUPONID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CuponId',fld:'vCUPONID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A1013CuponId',fld:'CUPONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A1019CuponUserUpdated',fld:'CUPONUSERUPDATED',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12302',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CUPONID","{handler:'Valid_Cuponid',iparms:[]");
         setEventMetadata("VALID_CUPONID",",oparms:[]}");
         setEventMetadata("VALID_CUPONFECHAVENCE","{handler:'Valid_Cuponfechavence',iparms:[]");
         setEventMetadata("VALID_CUPONFECHAVENCE",",oparms:[]}");
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
         Z1017CuponFechaVence = DateTime.MinValue;
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
         A1017CuponFechaVence = DateTime.MinValue;
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV12Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode147 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         T00304_A1013CuponId = new long[1] ;
         T00304_n1013CuponId = new bool[] {false} ;
         T00304_A1015CuponUser = new long[1] ;
         T00304_A1019CuponUserUpdated = new long[1] ;
         T00304_A1014CuponPercent = new short[1] ;
         T00304_A1017CuponFechaVence = new DateTime[] {DateTime.MinValue} ;
         T00304_A1018CuponUsado = new bool[] {false} ;
         T00305_A1013CuponId = new long[1] ;
         T00305_n1013CuponId = new bool[] {false} ;
         T00303_A1013CuponId = new long[1] ;
         T00303_n1013CuponId = new bool[] {false} ;
         T00303_A1015CuponUser = new long[1] ;
         T00303_A1019CuponUserUpdated = new long[1] ;
         T00303_A1014CuponPercent = new short[1] ;
         T00303_A1017CuponFechaVence = new DateTime[] {DateTime.MinValue} ;
         T00303_A1018CuponUsado = new bool[] {false} ;
         T00306_A1013CuponId = new long[1] ;
         T00306_n1013CuponId = new bool[] {false} ;
         T00307_A1013CuponId = new long[1] ;
         T00307_n1013CuponId = new bool[] {false} ;
         T00302_A1013CuponId = new long[1] ;
         T00302_n1013CuponId = new bool[] {false} ;
         T00302_A1015CuponUser = new long[1] ;
         T00302_A1019CuponUserUpdated = new long[1] ;
         T00302_A1014CuponPercent = new short[1] ;
         T00302_A1017CuponFechaVence = new DateTime[] {DateTime.MinValue} ;
         T00302_A1018CuponUsado = new bool[] {false} ;
         T00308_A1013CuponId = new long[1] ;
         T00308_n1013CuponId = new bool[] {false} ;
         T003011_A127SolicitudesID = new long[1] ;
         T003012_A1013CuponId = new long[1] ;
         T003012_n1013CuponId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.cupon__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cupon__default(),
            new Object[][] {
                new Object[] {
               T00302_A1013CuponId, T00302_A1015CuponUser, T00302_A1019CuponUserUpdated, T00302_A1014CuponPercent, T00302_A1017CuponFechaVence, T00302_A1018CuponUsado
               }
               , new Object[] {
               T00303_A1013CuponId, T00303_A1015CuponUser, T00303_A1019CuponUserUpdated, T00303_A1014CuponPercent, T00303_A1017CuponFechaVence, T00303_A1018CuponUsado
               }
               , new Object[] {
               T00304_A1013CuponId, T00304_A1015CuponUser, T00304_A1019CuponUserUpdated, T00304_A1014CuponPercent, T00304_A1017CuponFechaVence, T00304_A1018CuponUsado
               }
               , new Object[] {
               T00305_A1013CuponId
               }
               , new Object[] {
               T00306_A1013CuponId
               }
               , new Object[] {
               T00307_A1013CuponId
               }
               , new Object[] {
               T00308_A1013CuponId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003011_A127SolicitudesID
               }
               , new Object[] {
               T003012_A1013CuponId
               }
            }
         );
         Z1013CuponId = 1234;
         n1013CuponId = false;
         A1013CuponId = 1234;
         n1013CuponId = false;
         AV12Pgmname = "Cupon";
      }

      private short Z1014CuponPercent ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A1014CuponPercent ;
      private short Gx_BScreen ;
      private short RcdFound147 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtCuponId_Enabled ;
      private int edtCuponPercent_Enabled ;
      private int edtCuponFechaVence_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtCuponUser_Enabled ;
      private int edtCuponUser_Visible ;
      private int edtCuponUsado_Visible ;
      private int edtCuponUsado_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long wcpOAV7CuponId ;
      private long Z1013CuponId ;
      private long Z1015CuponUser ;
      private long Z1019CuponUserUpdated ;
      private long AV7CuponId ;
      private long A1013CuponId ;
      private long A1015CuponUser ;
      private long A1019CuponUserUpdated ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCuponPercent_Internalname ;
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
      private string edtCuponId_Internalname ;
      private string TempTags ;
      private string edtCuponId_Jsonclick ;
      private string edtCuponPercent_Jsonclick ;
      private string edtCuponFechaVence_Internalname ;
      private string edtCuponFechaVence_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtCuponUser_Internalname ;
      private string edtCuponUser_Jsonclick ;
      private string edtCuponUsado_Internalname ;
      private string edtCuponUsado_Jsonclick ;
      private string AV12Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode147 ;
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
      private DateTime Z1017CuponFechaVence ;
      private DateTime A1017CuponFechaVence ;
      private bool Z1018CuponUsado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A1018CuponUsado ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n1013CuponId ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] T00304_A1013CuponId ;
      private bool[] T00304_n1013CuponId ;
      private long[] T00304_A1015CuponUser ;
      private long[] T00304_A1019CuponUserUpdated ;
      private short[] T00304_A1014CuponPercent ;
      private DateTime[] T00304_A1017CuponFechaVence ;
      private bool[] T00304_A1018CuponUsado ;
      private long[] T00305_A1013CuponId ;
      private bool[] T00305_n1013CuponId ;
      private long[] T00303_A1013CuponId ;
      private bool[] T00303_n1013CuponId ;
      private long[] T00303_A1015CuponUser ;
      private long[] T00303_A1019CuponUserUpdated ;
      private short[] T00303_A1014CuponPercent ;
      private DateTime[] T00303_A1017CuponFechaVence ;
      private bool[] T00303_A1018CuponUsado ;
      private long[] T00306_A1013CuponId ;
      private bool[] T00306_n1013CuponId ;
      private long[] T00307_A1013CuponId ;
      private bool[] T00307_n1013CuponId ;
      private long[] T00302_A1013CuponId ;
      private bool[] T00302_n1013CuponId ;
      private long[] T00302_A1015CuponUser ;
      private long[] T00302_A1019CuponUserUpdated ;
      private short[] T00302_A1014CuponPercent ;
      private DateTime[] T00302_A1017CuponFechaVence ;
      private bool[] T00302_A1018CuponUsado ;
      private long[] T00308_A1013CuponId ;
      private bool[] T00308_n1013CuponId ;
      private long[] T003011_A127SolicitudesID ;
      private long[] T003012_A1013CuponId ;
      private bool[] T003012_n1013CuponId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class cupon__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class cupon__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00302;
        prmT00302 = new Object[] {
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00303;
        prmT00303 = new Object[] {
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00304;
        prmT00304 = new Object[] {
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00305;
        prmT00305 = new Object[] {
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00306;
        prmT00306 = new Object[] {
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00307;
        prmT00307 = new Object[] {
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00308;
        prmT00308 = new Object[] {
        new ParDef("@CuponUser",GXType.Decimal,10,0) ,
        new ParDef("@CuponUserUpdated",GXType.Decimal,10,0) ,
        new ParDef("@CuponPercent",GXType.Int16,2,0) ,
        new ParDef("@CuponFechaVence",GXType.Date,8,0) ,
        new ParDef("@CuponUsado",GXType.Boolean,4,0)
        };
        Object[] prmT00309;
        prmT00309 = new Object[] {
        new ParDef("@CuponUser",GXType.Decimal,10,0) ,
        new ParDef("@CuponUserUpdated",GXType.Decimal,10,0) ,
        new ParDef("@CuponPercent",GXType.Int16,2,0) ,
        new ParDef("@CuponFechaVence",GXType.Date,8,0) ,
        new ParDef("@CuponUsado",GXType.Boolean,4,0) ,
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT003010;
        prmT003010 = new Object[] {
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT003011;
        prmT003011 = new Object[] {
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT003012;
        prmT003012 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00302", "SELECT [CuponId], [CuponUser], [CuponUserUpdated], [CuponPercent], [CuponFechaVence], [CuponUsado] FROM [Cupon] WITH (UPDLOCK) WHERE [CuponId] = @CuponId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00302,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00303", "SELECT [CuponId], [CuponUser], [CuponUserUpdated], [CuponPercent], [CuponFechaVence], [CuponUsado] FROM [Cupon] WHERE [CuponId] = @CuponId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00303,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00304", "SELECT TM1.[CuponId], TM1.[CuponUser], TM1.[CuponUserUpdated], TM1.[CuponPercent], TM1.[CuponFechaVence], TM1.[CuponUsado] FROM [Cupon] TM1 WHERE TM1.[CuponId] = @CuponId ORDER BY TM1.[CuponId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00304,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00305", "SELECT [CuponId] FROM [Cupon] WHERE [CuponId] = @CuponId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00305,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00306", "SELECT TOP 1 [CuponId] FROM [Cupon] WHERE ( [CuponId] > @CuponId) ORDER BY [CuponId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00306,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00307", "SELECT TOP 1 [CuponId] FROM [Cupon] WHERE ( [CuponId] < @CuponId) ORDER BY [CuponId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00307,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00308", "INSERT INTO [Cupon]([CuponUser], [CuponUserUpdated], [CuponPercent], [CuponFechaVence], [CuponUsado]) VALUES(@CuponUser, @CuponUserUpdated, @CuponPercent, @CuponFechaVence, @CuponUsado); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT00308,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00309", "UPDATE [Cupon] SET [CuponUser]=@CuponUser, [CuponUserUpdated]=@CuponUserUpdated, [CuponPercent]=@CuponPercent, [CuponFechaVence]=@CuponFechaVence, [CuponUsado]=@CuponUsado  WHERE [CuponId] = @CuponId", GxErrorMask.GX_NOMASK,prmT00309)
           ,new CursorDef("T003010", "DELETE FROM [Cupon]  WHERE [CuponId] = @CuponId", GxErrorMask.GX_NOMASK,prmT003010)
           ,new CursorDef("T003011", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [CuponId] = @CuponId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003011,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003012", "SELECT [CuponId] FROM [Cupon] ORDER BY [CuponId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003012,100, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
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
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
