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
   public class feedback : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "feedback.aspx")), "feedback.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "feedback.aspx")))) ;
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
                  AV7FeedBackId = (long)(Math.Round(NumberUtil.Val( GetPar( "FeedBackId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7FeedBackId", StringUtil.LTrimStr( (decimal)(AV7FeedBackId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vFEEDBACKID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FeedBackId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Feed Back", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFeedBackSolicitudId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public feedback( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public feedback( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_FeedBackId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7FeedBackId = aP1_FeedBackId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFeedBackId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFeedBackId_Internalname, context.GetMessage( "Back Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFeedBackId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A117FeedBackId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtFeedBackId_Enabled!=0) ? context.localUtil.Format( (decimal)(A117FeedBackId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A117FeedBackId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFeedBackId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtFeedBackId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FeedBack.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFeedBackSolicitudId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFeedBackSolicitudId_Internalname, context.GetMessage( "Solicitud Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFeedBackSolicitudId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A272FeedBackSolicitudId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtFeedBackSolicitudId_Enabled!=0) ? context.localUtil.Format( (decimal)(A272FeedBackSolicitudId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A272FeedBackSolicitudId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFeedBackSolicitudId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtFeedBackSolicitudId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_FeedBack.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFeedBackProfesionalId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFeedBackProfesionalId_Internalname, context.GetMessage( "Profesional Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFeedBackProfesionalId_Internalname, StringUtil.RTrim( A273FeedBackProfesionalId), StringUtil.RTrim( context.localUtil.Format( A273FeedBackProfesionalId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFeedBackProfesionalId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtFeedBackProfesionalId_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "NoIdentidad", "start", true, "", "HLP_FeedBack.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFeedBackClienteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFeedBackClienteId_Internalname, context.GetMessage( "Cliente Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFeedBackClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A274FeedBackClienteId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtFeedBackClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A274FeedBackClienteId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A274FeedBackClienteId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFeedBackClienteId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtFeedBackClienteId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_FeedBack.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFeedBackNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFeedBackNum_Internalname, context.GetMessage( "Back Num", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFeedBackNum_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A275FeedBackNum), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtFeedBackNum_Enabled!=0) ? context.localUtil.Format( (decimal)(A275FeedBackNum), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A275FeedBackNum), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFeedBackNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtFeedBackNum_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FeedBack.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFeedBackComentario_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtFeedBackComentario_Internalname, A271FeedBackComentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", 0, 1, edtFeedBackComentario_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_FeedBack.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_FeedBack.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_FeedBack.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_FeedBack.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFeedBackFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFeedBackFechaAlta_Internalname, context.localUtil.Format(A276FeedBackFechaAlta, "99/99/99"), context.localUtil.Format( A276FeedBackFechaAlta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFeedBackFechaAlta_Jsonclick, 0, "Attribute", "", "", "", "", edtFeedBackFechaAlta_Visible, edtFeedBackFechaAlta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FeedBack.htm");
         GxWebStd.gx_bitmap( context, edtFeedBackFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtFeedBackFechaAlta_Visible==0)||(edtFeedBackFechaAlta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_FeedBack.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFeedBackFechaModif_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFeedBackFechaModif_Internalname, context.localUtil.Format(A277FeedBackFechaModif, "99/99/99"), context.localUtil.Format( A277FeedBackFechaModif, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFeedBackFechaModif_Jsonclick, 0, "Attribute", "", "", "", "", edtFeedBackFechaModif_Visible, edtFeedBackFechaModif_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FeedBack.htm");
         GxWebStd.gx_bitmap( context, edtFeedBackFechaModif_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtFeedBackFechaModif_Visible==0)||(edtFeedBackFechaModif_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_FeedBack.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         E110L2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z117FeedBackId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z117FeedBackId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z272FeedBackSolicitudId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z272FeedBackSolicitudId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z273FeedBackProfesionalId = cgiGet( "Z273FeedBackProfesionalId");
               Z274FeedBackClienteId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z274FeedBackClienteId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z275FeedBackNum = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z275FeedBackNum"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z276FeedBackFechaAlta = context.localUtil.CToD( cgiGet( "Z276FeedBackFechaAlta"), 0);
               Z277FeedBackFechaModif = context.localUtil.CToD( cgiGet( "Z277FeedBackFechaModif"), 0);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7FeedBackId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vFEEDBACKID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
               A117FeedBackId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtFeedBackId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A117FeedBackId", StringUtil.LTrimStr( (decimal)(A117FeedBackId), 18, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtFeedBackSolicitudId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFeedBackSolicitudId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FEEDBACKSOLICITUDID");
                  AnyError = 1;
                  GX_FocusControl = edtFeedBackSolicitudId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A272FeedBackSolicitudId = 0;
                  AssignAttri("", false, "A272FeedBackSolicitudId", StringUtil.LTrimStr( (decimal)(A272FeedBackSolicitudId), 18, 0));
               }
               else
               {
                  A272FeedBackSolicitudId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtFeedBackSolicitudId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A272FeedBackSolicitudId", StringUtil.LTrimStr( (decimal)(A272FeedBackSolicitudId), 18, 0));
               }
               A273FeedBackProfesionalId = cgiGet( edtFeedBackProfesionalId_Internalname);
               AssignAttri("", false, "A273FeedBackProfesionalId", A273FeedBackProfesionalId);
               if ( ( ( context.localUtil.CToN( cgiGet( edtFeedBackClienteId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFeedBackClienteId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FEEDBACKCLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtFeedBackClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A274FeedBackClienteId = 0;
                  AssignAttri("", false, "A274FeedBackClienteId", StringUtil.LTrimStr( (decimal)(A274FeedBackClienteId), 18, 0));
               }
               else
               {
                  A274FeedBackClienteId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtFeedBackClienteId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A274FeedBackClienteId", StringUtil.LTrimStr( (decimal)(A274FeedBackClienteId), 18, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtFeedBackNum_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFeedBackNum_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FEEDBACKNUM");
                  AnyError = 1;
                  GX_FocusControl = edtFeedBackNum_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A275FeedBackNum = 0;
                  AssignAttri("", false, "A275FeedBackNum", StringUtil.LTrimStr( (decimal)(A275FeedBackNum), 10, 0));
               }
               else
               {
                  A275FeedBackNum = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtFeedBackNum_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A275FeedBackNum", StringUtil.LTrimStr( (decimal)(A275FeedBackNum), 10, 0));
               }
               A271FeedBackComentario = cgiGet( edtFeedBackComentario_Internalname);
               AssignAttri("", false, "A271FeedBackComentario", A271FeedBackComentario);
               if ( context.localUtil.VCDate( cgiGet( edtFeedBackFechaAlta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Feed Back Fecha Alta", "")}), 1, "FEEDBACKFECHAALTA");
                  AnyError = 1;
                  GX_FocusControl = edtFeedBackFechaAlta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A276FeedBackFechaAlta = DateTime.MinValue;
                  AssignAttri("", false, "A276FeedBackFechaAlta", context.localUtil.Format(A276FeedBackFechaAlta, "99/99/99"));
               }
               else
               {
                  A276FeedBackFechaAlta = context.localUtil.CToD( cgiGet( edtFeedBackFechaAlta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A276FeedBackFechaAlta", context.localUtil.Format(A276FeedBackFechaAlta, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtFeedBackFechaModif_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Feed Back Fecha Modif", "")}), 1, "FEEDBACKFECHAMODIF");
                  AnyError = 1;
                  GX_FocusControl = edtFeedBackFechaModif_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A277FeedBackFechaModif = DateTime.MinValue;
                  AssignAttri("", false, "A277FeedBackFechaModif", context.localUtil.Format(A277FeedBackFechaModif, "99/99/99"));
               }
               else
               {
                  A277FeedBackFechaModif = context.localUtil.CToD( cgiGet( edtFeedBackFechaModif_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A277FeedBackFechaModif", context.localUtil.Format(A277FeedBackFechaModif, "99/99/99"));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"FeedBack");
               A117FeedBackId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtFeedBackId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A117FeedBackId", StringUtil.LTrimStr( (decimal)(A117FeedBackId), 18, 0));
               forbiddenHiddens.Add("FeedBackId", context.localUtil.Format( (decimal)(A117FeedBackId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A117FeedBackId != Z117FeedBackId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("feedback:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A117FeedBackId = (long)(Math.Round(NumberUtil.Val( GetPar( "FeedBackId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A117FeedBackId", StringUtil.LTrimStr( (decimal)(A117FeedBackId), 18, 0));
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
                     sMode25 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode25;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound25 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0L0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "FEEDBACKID");
                        AnyError = 1;
                        GX_FocusControl = edtFeedBackId_Internalname;
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
                           E110L2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120L2 ();
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
            E120L2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0L25( ) ;
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
            DisableAttributes0L25( ) ;
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

      protected void CONFIRM_0L0( )
      {
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0L25( ) ;
            }
            else
            {
               CheckExtendedTable0L25( ) ;
               CloseExtendedTableCursors0L25( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0L0( )
      {
      }

      protected void E110L2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWFeedBack_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWFeedBack_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWFeedBack_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV13Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtFeedBackFechaAlta_Visible = 0;
         AssignProp("", false, edtFeedBackFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFeedBackFechaAlta_Visible), 5, 0), true);
         edtFeedBackFechaModif_Visible = 0;
         AssignProp("", false, edtFeedBackFechaModif_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFeedBackFechaModif_Visible), 5, 0), true);
      }

      protected void E120L2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("feedbackww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0L25( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z272FeedBackSolicitudId = T000L3_A272FeedBackSolicitudId[0];
               Z273FeedBackProfesionalId = T000L3_A273FeedBackProfesionalId[0];
               Z274FeedBackClienteId = T000L3_A274FeedBackClienteId[0];
               Z275FeedBackNum = T000L3_A275FeedBackNum[0];
               Z276FeedBackFechaAlta = T000L3_A276FeedBackFechaAlta[0];
               Z277FeedBackFechaModif = T000L3_A277FeedBackFechaModif[0];
            }
            else
            {
               Z272FeedBackSolicitudId = A272FeedBackSolicitudId;
               Z273FeedBackProfesionalId = A273FeedBackProfesionalId;
               Z274FeedBackClienteId = A274FeedBackClienteId;
               Z275FeedBackNum = A275FeedBackNum;
               Z276FeedBackFechaAlta = A276FeedBackFechaAlta;
               Z277FeedBackFechaModif = A277FeedBackFechaModif;
            }
         }
         if ( GX_JID == -5 )
         {
            Z117FeedBackId = A117FeedBackId;
            Z272FeedBackSolicitudId = A272FeedBackSolicitudId;
            Z273FeedBackProfesionalId = A273FeedBackProfesionalId;
            Z274FeedBackClienteId = A274FeedBackClienteId;
            Z275FeedBackNum = A275FeedBackNum;
            Z271FeedBackComentario = A271FeedBackComentario;
            Z276FeedBackFechaAlta = A276FeedBackFechaAlta;
            Z277FeedBackFechaModif = A277FeedBackFechaModif;
         }
      }

      protected void standaloneNotModal( )
      {
         edtFeedBackId_Enabled = 0;
         AssignProp("", false, edtFeedBackId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFeedBackId_Enabled), 5, 0), true);
         edtFeedBackId_Enabled = 0;
         AssignProp("", false, edtFeedBackId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFeedBackId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7FeedBackId) )
         {
            A117FeedBackId = AV7FeedBackId;
            AssignAttri("", false, "A117FeedBackId", StringUtil.LTrimStr( (decimal)(A117FeedBackId), 18, 0));
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

      protected void Load0L25( )
      {
         /* Using cursor T000L4 */
         pr_default.execute(2, new Object[] {A117FeedBackId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound25 = 1;
            A272FeedBackSolicitudId = T000L4_A272FeedBackSolicitudId[0];
            AssignAttri("", false, "A272FeedBackSolicitudId", StringUtil.LTrimStr( (decimal)(A272FeedBackSolicitudId), 18, 0));
            A273FeedBackProfesionalId = T000L4_A273FeedBackProfesionalId[0];
            AssignAttri("", false, "A273FeedBackProfesionalId", A273FeedBackProfesionalId);
            A274FeedBackClienteId = T000L4_A274FeedBackClienteId[0];
            AssignAttri("", false, "A274FeedBackClienteId", StringUtil.LTrimStr( (decimal)(A274FeedBackClienteId), 18, 0));
            A275FeedBackNum = T000L4_A275FeedBackNum[0];
            AssignAttri("", false, "A275FeedBackNum", StringUtil.LTrimStr( (decimal)(A275FeedBackNum), 10, 0));
            A271FeedBackComentario = T000L4_A271FeedBackComentario[0];
            AssignAttri("", false, "A271FeedBackComentario", A271FeedBackComentario);
            A276FeedBackFechaAlta = T000L4_A276FeedBackFechaAlta[0];
            AssignAttri("", false, "A276FeedBackFechaAlta", context.localUtil.Format(A276FeedBackFechaAlta, "99/99/99"));
            A277FeedBackFechaModif = T000L4_A277FeedBackFechaModif[0];
            AssignAttri("", false, "A277FeedBackFechaModif", context.localUtil.Format(A277FeedBackFechaModif, "99/99/99"));
            ZM0L25( -5) ;
         }
         pr_default.close(2);
         OnLoadActions0L25( ) ;
      }

      protected void OnLoadActions0L25( )
      {
         AV13Pgmname = "FeedBack";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable0L25( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV13Pgmname = "FeedBack";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         if ( ! ( (DateTime.MinValue==A276FeedBackFechaAlta) || ( DateTimeUtil.ResetTime ( A276FeedBackFechaAlta ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Feed Back Fecha Alta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "FEEDBACKFECHAALTA");
            AnyError = 1;
            GX_FocusControl = edtFeedBackFechaAlta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A277FeedBackFechaModif) || ( DateTimeUtil.ResetTime ( A277FeedBackFechaModif ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Feed Back Fecha Modif", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "FEEDBACKFECHAMODIF");
            AnyError = 1;
            GX_FocusControl = edtFeedBackFechaModif_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0L25( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0L25( )
      {
         /* Using cursor T000L5 */
         pr_default.execute(3, new Object[] {A117FeedBackId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound25 = 1;
         }
         else
         {
            RcdFound25 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000L3 */
         pr_default.execute(1, new Object[] {A117FeedBackId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0L25( 5) ;
            RcdFound25 = 1;
            A117FeedBackId = T000L3_A117FeedBackId[0];
            AssignAttri("", false, "A117FeedBackId", StringUtil.LTrimStr( (decimal)(A117FeedBackId), 18, 0));
            A272FeedBackSolicitudId = T000L3_A272FeedBackSolicitudId[0];
            AssignAttri("", false, "A272FeedBackSolicitudId", StringUtil.LTrimStr( (decimal)(A272FeedBackSolicitudId), 18, 0));
            A273FeedBackProfesionalId = T000L3_A273FeedBackProfesionalId[0];
            AssignAttri("", false, "A273FeedBackProfesionalId", A273FeedBackProfesionalId);
            A274FeedBackClienteId = T000L3_A274FeedBackClienteId[0];
            AssignAttri("", false, "A274FeedBackClienteId", StringUtil.LTrimStr( (decimal)(A274FeedBackClienteId), 18, 0));
            A275FeedBackNum = T000L3_A275FeedBackNum[0];
            AssignAttri("", false, "A275FeedBackNum", StringUtil.LTrimStr( (decimal)(A275FeedBackNum), 10, 0));
            A271FeedBackComentario = T000L3_A271FeedBackComentario[0];
            AssignAttri("", false, "A271FeedBackComentario", A271FeedBackComentario);
            A276FeedBackFechaAlta = T000L3_A276FeedBackFechaAlta[0];
            AssignAttri("", false, "A276FeedBackFechaAlta", context.localUtil.Format(A276FeedBackFechaAlta, "99/99/99"));
            A277FeedBackFechaModif = T000L3_A277FeedBackFechaModif[0];
            AssignAttri("", false, "A277FeedBackFechaModif", context.localUtil.Format(A277FeedBackFechaModif, "99/99/99"));
            Z117FeedBackId = A117FeedBackId;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0L25( ) ;
            if ( AnyError == 1 )
            {
               RcdFound25 = 0;
               InitializeNonKey0L25( ) ;
            }
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound25 = 0;
            InitializeNonKey0L25( ) ;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0L25( ) ;
         if ( RcdFound25 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound25 = 0;
         /* Using cursor T000L6 */
         pr_default.execute(4, new Object[] {A117FeedBackId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000L6_A117FeedBackId[0] < A117FeedBackId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000L6_A117FeedBackId[0] > A117FeedBackId ) ) )
            {
               A117FeedBackId = T000L6_A117FeedBackId[0];
               AssignAttri("", false, "A117FeedBackId", StringUtil.LTrimStr( (decimal)(A117FeedBackId), 18, 0));
               RcdFound25 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound25 = 0;
         /* Using cursor T000L7 */
         pr_default.execute(5, new Object[] {A117FeedBackId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000L7_A117FeedBackId[0] > A117FeedBackId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000L7_A117FeedBackId[0] < A117FeedBackId ) ) )
            {
               A117FeedBackId = T000L7_A117FeedBackId[0];
               AssignAttri("", false, "A117FeedBackId", StringUtil.LTrimStr( (decimal)(A117FeedBackId), 18, 0));
               RcdFound25 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0L25( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFeedBackSolicitudId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0L25( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound25 == 1 )
            {
               if ( A117FeedBackId != Z117FeedBackId )
               {
                  A117FeedBackId = Z117FeedBackId;
                  AssignAttri("", false, "A117FeedBackId", StringUtil.LTrimStr( (decimal)(A117FeedBackId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FEEDBACKID");
                  AnyError = 1;
                  GX_FocusControl = edtFeedBackId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFeedBackSolicitudId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0L25( ) ;
                  GX_FocusControl = edtFeedBackSolicitudId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A117FeedBackId != Z117FeedBackId )
               {
                  /* Insert record */
                  GX_FocusControl = edtFeedBackSolicitudId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0L25( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FEEDBACKID");
                     AnyError = 1;
                     GX_FocusControl = edtFeedBackId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtFeedBackSolicitudId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0L25( ) ;
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
         if ( A117FeedBackId != Z117FeedBackId )
         {
            A117FeedBackId = Z117FeedBackId;
            AssignAttri("", false, "A117FeedBackId", StringUtil.LTrimStr( (decimal)(A117FeedBackId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FEEDBACKID");
            AnyError = 1;
            GX_FocusControl = edtFeedBackId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFeedBackSolicitudId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0L25( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000L2 */
            pr_default.execute(0, new Object[] {A117FeedBackId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FeedBack"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z272FeedBackSolicitudId != T000L2_A272FeedBackSolicitudId[0] ) || ( StringUtil.StrCmp(Z273FeedBackProfesionalId, T000L2_A273FeedBackProfesionalId[0]) != 0 ) || ( Z274FeedBackClienteId != T000L2_A274FeedBackClienteId[0] ) || ( Z275FeedBackNum != T000L2_A275FeedBackNum[0] ) || ( DateTimeUtil.ResetTime ( Z276FeedBackFechaAlta ) != DateTimeUtil.ResetTime ( T000L2_A276FeedBackFechaAlta[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z277FeedBackFechaModif ) != DateTimeUtil.ResetTime ( T000L2_A277FeedBackFechaModif[0] ) ) )
            {
               if ( Z272FeedBackSolicitudId != T000L2_A272FeedBackSolicitudId[0] )
               {
                  GXUtil.WriteLog("feedback:[seudo value changed for attri]"+"FeedBackSolicitudId");
                  GXUtil.WriteLogRaw("Old: ",Z272FeedBackSolicitudId);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A272FeedBackSolicitudId[0]);
               }
               if ( StringUtil.StrCmp(Z273FeedBackProfesionalId, T000L2_A273FeedBackProfesionalId[0]) != 0 )
               {
                  GXUtil.WriteLog("feedback:[seudo value changed for attri]"+"FeedBackProfesionalId");
                  GXUtil.WriteLogRaw("Old: ",Z273FeedBackProfesionalId);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A273FeedBackProfesionalId[0]);
               }
               if ( Z274FeedBackClienteId != T000L2_A274FeedBackClienteId[0] )
               {
                  GXUtil.WriteLog("feedback:[seudo value changed for attri]"+"FeedBackClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z274FeedBackClienteId);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A274FeedBackClienteId[0]);
               }
               if ( Z275FeedBackNum != T000L2_A275FeedBackNum[0] )
               {
                  GXUtil.WriteLog("feedback:[seudo value changed for attri]"+"FeedBackNum");
                  GXUtil.WriteLogRaw("Old: ",Z275FeedBackNum);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A275FeedBackNum[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z276FeedBackFechaAlta ) != DateTimeUtil.ResetTime ( T000L2_A276FeedBackFechaAlta[0] ) )
               {
                  GXUtil.WriteLog("feedback:[seudo value changed for attri]"+"FeedBackFechaAlta");
                  GXUtil.WriteLogRaw("Old: ",Z276FeedBackFechaAlta);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A276FeedBackFechaAlta[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z277FeedBackFechaModif ) != DateTimeUtil.ResetTime ( T000L2_A277FeedBackFechaModif[0] ) )
               {
                  GXUtil.WriteLog("feedback:[seudo value changed for attri]"+"FeedBackFechaModif");
                  GXUtil.WriteLogRaw("Old: ",Z277FeedBackFechaModif);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A277FeedBackFechaModif[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FeedBack"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0L25( )
      {
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L25( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0L25( 0) ;
            CheckOptimisticConcurrency0L25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0L25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L8 */
                     pr_default.execute(6, new Object[] {A272FeedBackSolicitudId, A273FeedBackProfesionalId, A274FeedBackClienteId, A275FeedBackNum, A271FeedBackComentario, A276FeedBackFechaAlta, A277FeedBackFechaModif});
                     A117FeedBackId = T000L8_A117FeedBackId[0];
                     AssignAttri("", false, "A117FeedBackId", StringUtil.LTrimStr( (decimal)(A117FeedBackId), 18, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("FeedBack");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0L0( ) ;
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
               Load0L25( ) ;
            }
            EndLevel0L25( ) ;
         }
         CloseExtendedTableCursors0L25( ) ;
      }

      protected void Update0L25( )
      {
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L25( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0L25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L9 */
                     pr_default.execute(7, new Object[] {A272FeedBackSolicitudId, A273FeedBackProfesionalId, A274FeedBackClienteId, A275FeedBackNum, A271FeedBackComentario, A276FeedBackFechaAlta, A277FeedBackFechaModif, A117FeedBackId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("FeedBack");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FeedBack"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0L25( ) ;
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
            EndLevel0L25( ) ;
         }
         CloseExtendedTableCursors0L25( ) ;
      }

      protected void DeferredUpdate0L25( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L25( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0L25( ) ;
            AfterConfirm0L25( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0L25( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000L10 */
                  pr_default.execute(8, new Object[] {A117FeedBackId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("FeedBack");
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
         sMode25 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0L25( ) ;
         Gx_mode = sMode25;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0L25( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "FeedBack";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         }
      }

      protected void EndLevel0L25( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0L25( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("feedback",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("feedback",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0L25( )
      {
         /* Scan By routine */
         /* Using cursor T000L11 */
         pr_default.execute(9);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound25 = 1;
            A117FeedBackId = T000L11_A117FeedBackId[0];
            AssignAttri("", false, "A117FeedBackId", StringUtil.LTrimStr( (decimal)(A117FeedBackId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0L25( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound25 = 1;
            A117FeedBackId = T000L11_A117FeedBackId[0];
            AssignAttri("", false, "A117FeedBackId", StringUtil.LTrimStr( (decimal)(A117FeedBackId), 18, 0));
         }
      }

      protected void ScanEnd0L25( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0L25( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0L25( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0L25( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0L25( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0L25( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0L25( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0L25( )
      {
         edtFeedBackId_Enabled = 0;
         AssignProp("", false, edtFeedBackId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFeedBackId_Enabled), 5, 0), true);
         edtFeedBackSolicitudId_Enabled = 0;
         AssignProp("", false, edtFeedBackSolicitudId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFeedBackSolicitudId_Enabled), 5, 0), true);
         edtFeedBackProfesionalId_Enabled = 0;
         AssignProp("", false, edtFeedBackProfesionalId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFeedBackProfesionalId_Enabled), 5, 0), true);
         edtFeedBackClienteId_Enabled = 0;
         AssignProp("", false, edtFeedBackClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFeedBackClienteId_Enabled), 5, 0), true);
         edtFeedBackNum_Enabled = 0;
         AssignProp("", false, edtFeedBackNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFeedBackNum_Enabled), 5, 0), true);
         edtFeedBackComentario_Enabled = 0;
         AssignProp("", false, edtFeedBackComentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFeedBackComentario_Enabled), 5, 0), true);
         edtFeedBackFechaAlta_Enabled = 0;
         AssignProp("", false, edtFeedBackFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFeedBackFechaAlta_Enabled), 5, 0), true);
         edtFeedBackFechaModif_Enabled = 0;
         AssignProp("", false, edtFeedBackFechaModif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFeedBackFechaModif_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0L25( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0L0( )
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
         GXEncryptionTmp = "feedback.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7FeedBackId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("feedback.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"FeedBack");
         forbiddenHiddens.Add("FeedBackId", context.localUtil.Format( (decimal)(A117FeedBackId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("feedback:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z117FeedBackId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z117FeedBackId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z272FeedBackSolicitudId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z272FeedBackSolicitudId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z273FeedBackProfesionalId", StringUtil.RTrim( Z273FeedBackProfesionalId));
         GxWebStd.gx_hidden_field( context, "Z274FeedBackClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z274FeedBackClienteId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z275FeedBackNum", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z275FeedBackNum), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z276FeedBackFechaAlta", context.localUtil.DToC( Z276FeedBackFechaAlta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z277FeedBackFechaModif", context.localUtil.DToC( Z277FeedBackFechaModif, 0, "/"));
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
         GxWebStd.gx_hidden_field( context, "vFEEDBACKID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7FeedBackId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFEEDBACKID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FeedBackId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV13Pgmname));
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
         GXEncryptionTmp = "feedback.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7FeedBackId,18,0));
         return formatLink("feedback.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "FeedBack" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Feed Back", "") ;
      }

      protected void InitializeNonKey0L25( )
      {
         A272FeedBackSolicitudId = 0;
         AssignAttri("", false, "A272FeedBackSolicitudId", StringUtil.LTrimStr( (decimal)(A272FeedBackSolicitudId), 18, 0));
         A273FeedBackProfesionalId = "";
         AssignAttri("", false, "A273FeedBackProfesionalId", A273FeedBackProfesionalId);
         A274FeedBackClienteId = 0;
         AssignAttri("", false, "A274FeedBackClienteId", StringUtil.LTrimStr( (decimal)(A274FeedBackClienteId), 18, 0));
         A275FeedBackNum = 0;
         AssignAttri("", false, "A275FeedBackNum", StringUtil.LTrimStr( (decimal)(A275FeedBackNum), 10, 0));
         A271FeedBackComentario = "";
         AssignAttri("", false, "A271FeedBackComentario", A271FeedBackComentario);
         A276FeedBackFechaAlta = DateTime.MinValue;
         AssignAttri("", false, "A276FeedBackFechaAlta", context.localUtil.Format(A276FeedBackFechaAlta, "99/99/99"));
         A277FeedBackFechaModif = DateTime.MinValue;
         AssignAttri("", false, "A277FeedBackFechaModif", context.localUtil.Format(A277FeedBackFechaModif, "99/99/99"));
         Z272FeedBackSolicitudId = 0;
         Z273FeedBackProfesionalId = "";
         Z274FeedBackClienteId = 0;
         Z275FeedBackNum = 0;
         Z276FeedBackFechaAlta = DateTime.MinValue;
         Z277FeedBackFechaModif = DateTime.MinValue;
      }

      protected void InitAll0L25( )
      {
         A117FeedBackId = 0;
         AssignAttri("", false, "A117FeedBackId", StringUtil.LTrimStr( (decimal)(A117FeedBackId), 18, 0));
         InitializeNonKey0L25( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026730219686", true, true, false);
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
         context.AddJavascriptSource("feedback.js", "?2026730219686", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtFeedBackId_Internalname = "FEEDBACKID";
         edtFeedBackSolicitudId_Internalname = "FEEDBACKSOLICITUDID";
         edtFeedBackProfesionalId_Internalname = "FEEDBACKPROFESIONALID";
         edtFeedBackClienteId_Internalname = "FEEDBACKCLIENTEID";
         edtFeedBackNum_Internalname = "FEEDBACKNUM";
         edtFeedBackComentario_Internalname = "FEEDBACKCOMENTARIO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtFeedBackFechaAlta_Internalname = "FEEDBACKFECHAALTA";
         edtFeedBackFechaModif_Internalname = "FEEDBACKFECHAMODIF";
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
         Form.Caption = context.GetMessage( "Feed Back", "");
         edtFeedBackFechaModif_Jsonclick = "";
         edtFeedBackFechaModif_Enabled = 1;
         edtFeedBackFechaModif_Visible = 1;
         edtFeedBackFechaAlta_Jsonclick = "";
         edtFeedBackFechaAlta_Enabled = 1;
         edtFeedBackFechaAlta_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtFeedBackComentario_Enabled = 1;
         edtFeedBackNum_Jsonclick = "";
         edtFeedBackNum_Enabled = 1;
         edtFeedBackClienteId_Jsonclick = "";
         edtFeedBackClienteId_Enabled = 1;
         edtFeedBackProfesionalId_Jsonclick = "";
         edtFeedBackProfesionalId_Enabled = 1;
         edtFeedBackSolicitudId_Jsonclick = "";
         edtFeedBackSolicitudId_Enabled = 1;
         edtFeedBackId_Jsonclick = "";
         edtFeedBackId_Enabled = 0;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7FeedBackId',fld:'vFEEDBACKID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7FeedBackId',fld:'vFEEDBACKID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A117FeedBackId',fld:'FEEDBACKID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120L2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_FEEDBACKID","{handler:'Valid_Feedbackid',iparms:[]");
         setEventMetadata("VALID_FEEDBACKID",",oparms:[]}");
         setEventMetadata("VALID_FEEDBACKFECHAALTA","{handler:'Valid_Feedbackfechaalta',iparms:[]");
         setEventMetadata("VALID_FEEDBACKFECHAALTA",",oparms:[]}");
         setEventMetadata("VALID_FEEDBACKFECHAMODIF","{handler:'Valid_Feedbackfechamodif',iparms:[]");
         setEventMetadata("VALID_FEEDBACKFECHAMODIF",",oparms:[]}");
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
         Z273FeedBackProfesionalId = "";
         Z276FeedBackFechaAlta = DateTime.MinValue;
         Z277FeedBackFechaModif = DateTime.MinValue;
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
         A273FeedBackProfesionalId = "";
         A271FeedBackComentario = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A276FeedBackFechaAlta = DateTime.MinValue;
         A277FeedBackFechaModif = DateTime.MinValue;
         AV13Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode25 = "";
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
         Z271FeedBackComentario = "";
         T000L4_A117FeedBackId = new long[1] ;
         T000L4_A272FeedBackSolicitudId = new long[1] ;
         T000L4_A273FeedBackProfesionalId = new string[] {""} ;
         T000L4_A274FeedBackClienteId = new long[1] ;
         T000L4_A275FeedBackNum = new long[1] ;
         T000L4_A271FeedBackComentario = new string[] {""} ;
         T000L4_A276FeedBackFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T000L4_A277FeedBackFechaModif = new DateTime[] {DateTime.MinValue} ;
         T000L5_A117FeedBackId = new long[1] ;
         T000L3_A117FeedBackId = new long[1] ;
         T000L3_A272FeedBackSolicitudId = new long[1] ;
         T000L3_A273FeedBackProfesionalId = new string[] {""} ;
         T000L3_A274FeedBackClienteId = new long[1] ;
         T000L3_A275FeedBackNum = new long[1] ;
         T000L3_A271FeedBackComentario = new string[] {""} ;
         T000L3_A276FeedBackFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T000L3_A277FeedBackFechaModif = new DateTime[] {DateTime.MinValue} ;
         T000L6_A117FeedBackId = new long[1] ;
         T000L7_A117FeedBackId = new long[1] ;
         T000L2_A117FeedBackId = new long[1] ;
         T000L2_A272FeedBackSolicitudId = new long[1] ;
         T000L2_A273FeedBackProfesionalId = new string[] {""} ;
         T000L2_A274FeedBackClienteId = new long[1] ;
         T000L2_A275FeedBackNum = new long[1] ;
         T000L2_A271FeedBackComentario = new string[] {""} ;
         T000L2_A276FeedBackFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T000L2_A277FeedBackFechaModif = new DateTime[] {DateTime.MinValue} ;
         T000L8_A117FeedBackId = new long[1] ;
         T000L11_A117FeedBackId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.feedback__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.feedback__default(),
            new Object[][] {
                new Object[] {
               T000L2_A117FeedBackId, T000L2_A272FeedBackSolicitudId, T000L2_A273FeedBackProfesionalId, T000L2_A274FeedBackClienteId, T000L2_A275FeedBackNum, T000L2_A271FeedBackComentario, T000L2_A276FeedBackFechaAlta, T000L2_A277FeedBackFechaModif
               }
               , new Object[] {
               T000L3_A117FeedBackId, T000L3_A272FeedBackSolicitudId, T000L3_A273FeedBackProfesionalId, T000L3_A274FeedBackClienteId, T000L3_A275FeedBackNum, T000L3_A271FeedBackComentario, T000L3_A276FeedBackFechaAlta, T000L3_A277FeedBackFechaModif
               }
               , new Object[] {
               T000L4_A117FeedBackId, T000L4_A272FeedBackSolicitudId, T000L4_A273FeedBackProfesionalId, T000L4_A274FeedBackClienteId, T000L4_A275FeedBackNum, T000L4_A271FeedBackComentario, T000L4_A276FeedBackFechaAlta, T000L4_A277FeedBackFechaModif
               }
               , new Object[] {
               T000L5_A117FeedBackId
               }
               , new Object[] {
               T000L6_A117FeedBackId
               }
               , new Object[] {
               T000L7_A117FeedBackId
               }
               , new Object[] {
               T000L8_A117FeedBackId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000L11_A117FeedBackId
               }
            }
         );
         AV13Pgmname = "FeedBack";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound25 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtFeedBackId_Enabled ;
      private int edtFeedBackSolicitudId_Enabled ;
      private int edtFeedBackProfesionalId_Enabled ;
      private int edtFeedBackClienteId_Enabled ;
      private int edtFeedBackNum_Enabled ;
      private int edtFeedBackComentario_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtFeedBackFechaAlta_Visible ;
      private int edtFeedBackFechaAlta_Enabled ;
      private int edtFeedBackFechaModif_Visible ;
      private int edtFeedBackFechaModif_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long wcpOAV7FeedBackId ;
      private long Z117FeedBackId ;
      private long Z272FeedBackSolicitudId ;
      private long Z274FeedBackClienteId ;
      private long Z275FeedBackNum ;
      private long AV7FeedBackId ;
      private long A117FeedBackId ;
      private long A272FeedBackSolicitudId ;
      private long A274FeedBackClienteId ;
      private long A275FeedBackNum ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z273FeedBackProfesionalId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtFeedBackSolicitudId_Internalname ;
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
      private string edtFeedBackId_Internalname ;
      private string TempTags ;
      private string edtFeedBackId_Jsonclick ;
      private string edtFeedBackSolicitudId_Jsonclick ;
      private string edtFeedBackProfesionalId_Internalname ;
      private string A273FeedBackProfesionalId ;
      private string edtFeedBackProfesionalId_Jsonclick ;
      private string edtFeedBackClienteId_Internalname ;
      private string edtFeedBackClienteId_Jsonclick ;
      private string edtFeedBackNum_Internalname ;
      private string edtFeedBackNum_Jsonclick ;
      private string edtFeedBackComentario_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtFeedBackFechaAlta_Internalname ;
      private string edtFeedBackFechaAlta_Jsonclick ;
      private string edtFeedBackFechaModif_Internalname ;
      private string edtFeedBackFechaModif_Jsonclick ;
      private string AV13Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode25 ;
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
      private DateTime Z276FeedBackFechaAlta ;
      private DateTime Z277FeedBackFechaModif ;
      private DateTime A276FeedBackFechaAlta ;
      private DateTime A277FeedBackFechaModif ;
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
      private bool Gx_longc ;
      private string A271FeedBackComentario ;
      private string Z271FeedBackComentario ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] T000L4_A117FeedBackId ;
      private long[] T000L4_A272FeedBackSolicitudId ;
      private string[] T000L4_A273FeedBackProfesionalId ;
      private long[] T000L4_A274FeedBackClienteId ;
      private long[] T000L4_A275FeedBackNum ;
      private string[] T000L4_A271FeedBackComentario ;
      private DateTime[] T000L4_A276FeedBackFechaAlta ;
      private DateTime[] T000L4_A277FeedBackFechaModif ;
      private long[] T000L5_A117FeedBackId ;
      private long[] T000L3_A117FeedBackId ;
      private long[] T000L3_A272FeedBackSolicitudId ;
      private string[] T000L3_A273FeedBackProfesionalId ;
      private long[] T000L3_A274FeedBackClienteId ;
      private long[] T000L3_A275FeedBackNum ;
      private string[] T000L3_A271FeedBackComentario ;
      private DateTime[] T000L3_A276FeedBackFechaAlta ;
      private DateTime[] T000L3_A277FeedBackFechaModif ;
      private long[] T000L6_A117FeedBackId ;
      private long[] T000L7_A117FeedBackId ;
      private long[] T000L2_A117FeedBackId ;
      private long[] T000L2_A272FeedBackSolicitudId ;
      private string[] T000L2_A273FeedBackProfesionalId ;
      private long[] T000L2_A274FeedBackClienteId ;
      private long[] T000L2_A275FeedBackNum ;
      private string[] T000L2_A271FeedBackComentario ;
      private DateTime[] T000L2_A276FeedBackFechaAlta ;
      private DateTime[] T000L2_A277FeedBackFechaModif ;
      private long[] T000L8_A117FeedBackId ;
      private long[] T000L11_A117FeedBackId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class feedback__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class feedback__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000L2;
        prmT000L2 = new Object[] {
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmT000L3;
        prmT000L3 = new Object[] {
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmT000L4;
        prmT000L4 = new Object[] {
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmT000L5;
        prmT000L5 = new Object[] {
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmT000L6;
        prmT000L6 = new Object[] {
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmT000L7;
        prmT000L7 = new Object[] {
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmT000L8;
        prmT000L8 = new Object[] {
        new ParDef("@FeedBackSolicitudId",GXType.Decimal,18,0) ,
        new ParDef("@FeedBackProfesionalId",GXType.NChar,20,0) ,
        new ParDef("@FeedBackClienteId",GXType.Decimal,18,0) ,
        new ParDef("@FeedBackNum",GXType.Decimal,10,0) ,
        new ParDef("@FeedBackComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@FeedBackFechaAlta",GXType.Date,8,0) ,
        new ParDef("@FeedBackFechaModif",GXType.Date,8,0)
        };
        Object[] prmT000L9;
        prmT000L9 = new Object[] {
        new ParDef("@FeedBackSolicitudId",GXType.Decimal,18,0) ,
        new ParDef("@FeedBackProfesionalId",GXType.NChar,20,0) ,
        new ParDef("@FeedBackClienteId",GXType.Decimal,18,0) ,
        new ParDef("@FeedBackNum",GXType.Decimal,10,0) ,
        new ParDef("@FeedBackComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@FeedBackFechaAlta",GXType.Date,8,0) ,
        new ParDef("@FeedBackFechaModif",GXType.Date,8,0) ,
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmT000L10;
        prmT000L10 = new Object[] {
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmT000L11;
        prmT000L11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000L2", "SELECT [FeedBackId], [FeedBackSolicitudId], [FeedBackProfesionalId], [FeedBackClienteId], [FeedBackNum], [FeedBackComentario], [FeedBackFechaAlta], [FeedBackFechaModif] FROM [FeedBack] WITH (UPDLOCK) WHERE [FeedBackId] = @FeedBackId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L3", "SELECT [FeedBackId], [FeedBackSolicitudId], [FeedBackProfesionalId], [FeedBackClienteId], [FeedBackNum], [FeedBackComentario], [FeedBackFechaAlta], [FeedBackFechaModif] FROM [FeedBack] WHERE [FeedBackId] = @FeedBackId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L4", "SELECT TM1.[FeedBackId], TM1.[FeedBackSolicitudId], TM1.[FeedBackProfesionalId], TM1.[FeedBackClienteId], TM1.[FeedBackNum], TM1.[FeedBackComentario], TM1.[FeedBackFechaAlta], TM1.[FeedBackFechaModif] FROM [FeedBack] TM1 WHERE TM1.[FeedBackId] = @FeedBackId ORDER BY TM1.[FeedBackId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L5", "SELECT [FeedBackId] FROM [FeedBack] WHERE [FeedBackId] = @FeedBackId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L6", "SELECT TOP 1 [FeedBackId] FROM [FeedBack] WHERE ( [FeedBackId] > @FeedBackId) ORDER BY [FeedBackId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000L7", "SELECT TOP 1 [FeedBackId] FROM [FeedBack] WHERE ( [FeedBackId] < @FeedBackId) ORDER BY [FeedBackId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000L8", "INSERT INTO [FeedBack]([FeedBackSolicitudId], [FeedBackProfesionalId], [FeedBackClienteId], [FeedBackNum], [FeedBackComentario], [FeedBackFechaAlta], [FeedBackFechaModif]) VALUES(@FeedBackSolicitudId, @FeedBackProfesionalId, @FeedBackClienteId, @FeedBackNum, @FeedBackComentario, @FeedBackFechaAlta, @FeedBackFechaModif); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000L8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000L9", "UPDATE [FeedBack] SET [FeedBackSolicitudId]=@FeedBackSolicitudId, [FeedBackProfesionalId]=@FeedBackProfesionalId, [FeedBackClienteId]=@FeedBackClienteId, [FeedBackNum]=@FeedBackNum, [FeedBackComentario]=@FeedBackComentario, [FeedBackFechaAlta]=@FeedBackFechaAlta, [FeedBackFechaModif]=@FeedBackFechaModif  WHERE [FeedBackId] = @FeedBackId", GxErrorMask.GX_NOMASK,prmT000L9)
           ,new CursorDef("T000L10", "DELETE FROM [FeedBack]  WHERE [FeedBackId] = @FeedBackId", GxErrorMask.GX_NOMASK,prmT000L10)
           ,new CursorDef("T000L11", "SELECT [FeedBackId] FROM [FeedBack] ORDER BY [FeedBackId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L11,100, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
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
     }
  }

}

}
