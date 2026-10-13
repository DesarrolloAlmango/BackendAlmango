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
   public class vinculartrn : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A133ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A133ProveedorID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A488DocumentacionId = (long)(Math.Round(NumberUtil.Val( GetPar( "DocumentacionId"), "."), 18, MidpointRounding.ToEven));
            n488DocumentacionId = false;
            AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A488DocumentacionId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "vinculartrn.aspx")), "vinculartrn.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "vinculartrn.aspx")))) ;
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
                  AV11VincularTrnId = (long)(Math.Round(NumberUtil.Val( GetPar( "VincularTrnId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11VincularTrnId", StringUtil.LTrimStr( (decimal)(AV11VincularTrnId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vVINCULARTRNID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11VincularTrnId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Vincular Trn", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = imgVincularTrnImagen_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public vinculartrn( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public vinculartrn( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_VincularTrnId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV11VincularTrnId = aP1_VincularTrnId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVincularTrnId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVincularTrnId_Internalname, context.GetMessage( "Nro", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVincularTrnId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A491VincularTrnId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtVincularTrnId_Enabled!=0) ? context.localUtil.Format( (decimal)(A491VincularTrnId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A491VincularTrnId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVincularTrnId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVincularTrnId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_VincularTrn.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorID_Internalname, context.GetMessage( "Código del Proveedor", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorID_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_VincularTrn.htm");
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
         GxWebStd.gx_label_element( context, edtProveedorNombre_Internalname, context.GetMessage( "Proveedor Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre), StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_VincularTrn.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVincularTrnSolidicutd_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVincularTrnSolidicutd_Internalname, context.GetMessage( "Solicitud", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVincularTrnSolidicutd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A492VincularTrnSolidicutd), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtVincularTrnSolidicutd_Enabled!=0) ? context.localUtil.Format( (decimal)(A492VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A492VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVincularTrnSolidicutd_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVincularTrnSolidicutd_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_VincularTrn.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVincularTrnNombreSol_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVincularTrnNombreSol_Internalname, context.GetMessage( "Nombre del Cliente", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVincularTrnNombreSol_Internalname, StringUtil.RTrim( A493VincularTrnNombreSol), StringUtil.RTrim( context.localUtil.Format( A493VincularTrnNombreSol, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVincularTrnNombreSol_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVincularTrnNombreSol_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_VincularTrn.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVincularTrnTelefonoSol_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVincularTrnTelefonoSol_Internalname, context.GetMessage( "Teléfono del Cliente", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A494VincularTrnTelefonoSol);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVincularTrnTelefonoSol_Internalname, StringUtil.RTrim( A494VincularTrnTelefonoSol), StringUtil.RTrim( context.localUtil.Format( A494VincularTrnTelefonoSol, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtVincularTrnTelefonoSol_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVincularTrnTelefonoSol_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_VincularTrn.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDocumentacionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocumentacionId_Internalname, context.GetMessage( "Nombre del Documento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentacionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A488DocumentacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtDocumentacionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A488DocumentacionId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A488DocumentacionId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentacionId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentacionId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_VincularTrn.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgDocumentacionIcono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Icono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A498DocumentacionIcono_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000DocumentacionIcono_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.PathToRelativeUrl( A498DocumentacionIcono));
         GxWebStd.gx_bitmap( context, imgDocumentacionIcono_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgDocumentacionIcono_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", "", "", 0, A498DocumentacionIcono_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_VincularTrn.htm");
         AssignProp("", false, imgDocumentacionIcono_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.PathToRelativeUrl( A498DocumentacionIcono)), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "IsBlob", StringUtil.BoolToStr( A498DocumentacionIcono_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgVincularTrnImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Fotografia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A495VincularTrnImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001VincularTrnImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40001VincularTrnImagen_GXI : context.PathToRelativeUrl( A495VincularTrnImagen));
         GxWebStd.gx_bitmap( context, imgVincularTrnImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgVincularTrnImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "", "", "", 0, A495VincularTrnImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_VincularTrn.htm");
         AssignProp("", false, imgVincularTrnImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40001VincularTrnImagen_GXI : context.PathToRelativeUrl( A495VincularTrnImagen)), true);
         AssignProp("", false, imgVincularTrnImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A495VincularTrnImagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVincularTrnComentario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVincularTrnComentario_Internalname, context.GetMessage( "Comentario", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtVincularTrnComentario_Internalname, A497VincularTrnComentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", 0, 1, edtVincularTrnComentario_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_VincularTrn.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVincularTrnFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVincularTrnFecha_Internalname, context.GetMessage( "Fecha", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVincularTrnFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVincularTrnFecha_Internalname, context.localUtil.Format(A496VincularTrnFecha, "99/99/99"), context.localUtil.Format( A496VincularTrnFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVincularTrnFecha_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVincularTrnFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_VincularTrn.htm");
         GxWebStd.gx_bitmap( context, edtVincularTrnFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVincularTrnFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_VincularTrn.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_VincularTrn.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_VincularTrn.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_VincularTrn.htm");
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
         E111T2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z491VincularTrnId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z491VincularTrnId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z492VincularTrnSolidicutd = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z492VincularTrnSolidicutd"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z493VincularTrnNombreSol = cgiGet( "Z493VincularTrnNombreSol");
               Z494VincularTrnTelefonoSol = cgiGet( "Z494VincularTrnTelefonoSol");
               Z496VincularTrnFecha = context.localUtil.CToD( cgiGet( "Z496VincularTrnFecha"), 0);
               Z133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV11VincularTrnId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vVINCULARTRNID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV15Insert_ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15Insert_ProveedorID", StringUtil.LTrimStr( (decimal)(AV15Insert_ProveedorID), 18, 0));
               A40001VincularTrnImagen_GXI = cgiGet( "VINCULARTRNIMAGEN_GXI");
               A40000DocumentacionIcono_GXI = cgiGet( "DOCUMENTACIONICONO_GXI");
               AV25Pgmname = cgiGet( "vPGMNAME");
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
               A491VincularTrnId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVincularTrnId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
               A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
               AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
               A492VincularTrnSolidicutd = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVincularTrnSolidicutd_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A492VincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(A492VincularTrnSolidicutd), 18, 0));
               A493VincularTrnNombreSol = cgiGet( edtVincularTrnNombreSol_Internalname);
               AssignAttri("", false, "A493VincularTrnNombreSol", A493VincularTrnNombreSol);
               A494VincularTrnTelefonoSol = cgiGet( edtVincularTrnTelefonoSol_Internalname);
               AssignAttri("", false, "A494VincularTrnTelefonoSol", A494VincularTrnTelefonoSol);
               A488DocumentacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDocumentacionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n488DocumentacionId = false;
               AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
               A498DocumentacionIcono = cgiGet( imgDocumentacionIcono_Internalname);
               AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
               A495VincularTrnImagen = cgiGet( imgVincularTrnImagen_Internalname);
               AssignAttri("", false, "A495VincularTrnImagen", A495VincularTrnImagen);
               A497VincularTrnComentario = cgiGet( edtVincularTrnComentario_Internalname);
               AssignAttri("", false, "A497VincularTrnComentario", A497VincularTrnComentario);
               A496VincularTrnFecha = context.localUtil.CToD( cgiGet( edtVincularTrnFecha_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "A496VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgDocumentacionIcono_Internalname, ref  A498DocumentacionIcono, ref  A40000DocumentacionIcono_GXI);
               getMultimediaValue(imgVincularTrnImagen_Internalname, ref  A495VincularTrnImagen, ref  A40001VincularTrnImagen_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"VincularTrn");
               A491VincularTrnId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVincularTrnId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
               forbiddenHiddens.Add("VincularTrnId", context.localUtil.Format( (decimal)(A491VincularTrnId), "ZZZZZZZZZZZZZZZZZ9"));
               A492VincularTrnSolidicutd = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVincularTrnSolidicutd_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A492VincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(A492VincularTrnSolidicutd), 18, 0));
               forbiddenHiddens.Add("VincularTrnSolidicutd", context.localUtil.Format( (decimal)(A492VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9"));
               A493VincularTrnNombreSol = cgiGet( edtVincularTrnNombreSol_Internalname);
               AssignAttri("", false, "A493VincularTrnNombreSol", A493VincularTrnNombreSol);
               forbiddenHiddens.Add("VincularTrnNombreSol", StringUtil.RTrim( context.localUtil.Format( A493VincularTrnNombreSol, "")));
               A494VincularTrnTelefonoSol = cgiGet( edtVincularTrnTelefonoSol_Internalname);
               AssignAttri("", false, "A494VincularTrnTelefonoSol", A494VincularTrnTelefonoSol);
               forbiddenHiddens.Add("VincularTrnTelefonoSol", StringUtil.RTrim( context.localUtil.Format( A494VincularTrnTelefonoSol, "")));
               A496VincularTrnFecha = context.localUtil.CToD( cgiGet( edtVincularTrnFecha_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "A496VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
               forbiddenHiddens.Add("VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
               forbiddenHiddens.Add("Insert_ProveedorID", context.localUtil.Format( (decimal)(AV15Insert_ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A491VincularTrnId != Z491VincularTrnId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("vinculartrn:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A491VincularTrnId = (long)(Math.Round(NumberUtil.Val( GetPar( "VincularTrnId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
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
                     sMode73 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode73;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound73 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1T0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "VINCULARTRNID");
                        AnyError = 1;
                        GX_FocusControl = edtVincularTrnId_Internalname;
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
                           E111T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121T2 ();
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
            E121T2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1T73( ) ;
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
            DisableAttributes1T73( ) ;
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

      protected void CONFIRM_1T0( )
      {
         BeforeValidate1T73( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1T73( ) ;
            }
            else
            {
               CheckExtendedTable1T73( ) ;
               CloseExtendedTableCursors1T73( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1T0( )
      {
      }

      protected void E111T2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV17WWPContext) ;
         AV12IsAuthorized = true;
         AssignAttri("", false, "AV12IsAuthorized", AV12IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV12IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWVincularTrn_Insert", out  GXt_boolean1) ;
            AV12IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV12IsAuthorized", AV12IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV12IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWVincularTrn_Update", out  GXt_boolean1) ;
            AV12IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV12IsAuthorized", AV12IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV12IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWVincularTrn_Delete", out  GXt_boolean1) ;
            AV12IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV12IsAuthorized", AV12IsAuthorized);
         }
         if ( ! AV12IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV25Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV13TrnContext.FromXml(AV14WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV13TrnContext.gxTpr_Transactionname, AV25Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV26GXV1 = 1;
            AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            while ( AV26GXV1 <= AV13TrnContext.gxTpr_Attributes.Count )
            {
               AV16TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV13TrnContext.gxTpr_Attributes.Item(AV26GXV1));
               if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "ProveedorID") == 0 )
               {
                  AV15Insert_ProveedorID = (long)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15Insert_ProveedorID", StringUtil.LTrimStr( (decimal)(AV15Insert_ProveedorID), 18, 0));
               }
               AV26GXV1 = (int)(AV26GXV1+1);
               AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            }
         }
      }

      protected void E121T2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV13TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("vinculartrnww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1T73( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z492VincularTrnSolidicutd = T001T3_A492VincularTrnSolidicutd[0];
               Z493VincularTrnNombreSol = T001T3_A493VincularTrnNombreSol[0];
               Z494VincularTrnTelefonoSol = T001T3_A494VincularTrnTelefonoSol[0];
               Z496VincularTrnFecha = T001T3_A496VincularTrnFecha[0];
               Z133ProveedorID = T001T3_A133ProveedorID[0];
            }
            else
            {
               Z492VincularTrnSolidicutd = A492VincularTrnSolidicutd;
               Z493VincularTrnNombreSol = A493VincularTrnNombreSol;
               Z494VincularTrnTelefonoSol = A494VincularTrnTelefonoSol;
               Z496VincularTrnFecha = A496VincularTrnFecha;
               Z133ProveedorID = A133ProveedorID;
            }
         }
         if ( GX_JID == -12 )
         {
            Z491VincularTrnId = A491VincularTrnId;
            Z492VincularTrnSolidicutd = A492VincularTrnSolidicutd;
            Z493VincularTrnNombreSol = A493VincularTrnNombreSol;
            Z494VincularTrnTelefonoSol = A494VincularTrnTelefonoSol;
            Z495VincularTrnImagen = A495VincularTrnImagen;
            Z40001VincularTrnImagen_GXI = A40001VincularTrnImagen_GXI;
            Z497VincularTrnComentario = A497VincularTrnComentario;
            Z496VincularTrnFecha = A496VincularTrnFecha;
            Z133ProveedorID = A133ProveedorID;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z488DocumentacionId = A488DocumentacionId;
            Z498DocumentacionIcono = A498DocumentacionIcono;
            Z40000DocumentacionIcono_GXI = A40000DocumentacionIcono_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         edtVincularTrnId_Enabled = 0;
         AssignProp("", false, edtVincularTrnId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnId_Enabled), 5, 0), true);
         edtVincularTrnSolidicutd_Enabled = 0;
         AssignProp("", false, edtVincularTrnSolidicutd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnSolidicutd_Enabled), 5, 0), true);
         edtVincularTrnNombreSol_Enabled = 0;
         AssignProp("", false, edtVincularTrnNombreSol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnNombreSol_Enabled), 5, 0), true);
         edtVincularTrnTelefonoSol_Enabled = 0;
         AssignProp("", false, edtVincularTrnTelefonoSol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnTelefonoSol_Enabled), 5, 0), true);
         edtVincularTrnFecha_Enabled = 0;
         AssignProp("", false, edtVincularTrnFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnFecha_Enabled), 5, 0), true);
         edtVincularTrnId_Enabled = 0;
         AssignProp("", false, edtVincularTrnId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnId_Enabled), 5, 0), true);
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         edtVincularTrnSolidicutd_Enabled = 0;
         AssignProp("", false, edtVincularTrnSolidicutd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnSolidicutd_Enabled), 5, 0), true);
         edtVincularTrnNombreSol_Enabled = 0;
         AssignProp("", false, edtVincularTrnNombreSol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnNombreSol_Enabled), 5, 0), true);
         edtVincularTrnTelefonoSol_Enabled = 0;
         AssignProp("", false, edtVincularTrnTelefonoSol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnTelefonoSol_Enabled), 5, 0), true);
         edtVincularTrnFecha_Enabled = 0;
         AssignProp("", false, edtVincularTrnFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnFecha_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV11VincularTrnId) )
         {
            A491VincularTrnId = AV11VincularTrnId;
            AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_ProveedorID) )
         {
            edtProveedorID_Enabled = 0;
            AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         }
         else
         {
            if ( true )
            {
               edtProveedorID_Enabled = 1;
               AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
            }
            else
            {
               edtProveedorID_Enabled = 0;
               AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
            }
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_ProveedorID) )
         {
            A133ProveedorID = AV15Insert_ProveedorID;
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV25Pgmname = "VincularTrn";
            AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
            /* Using cursor T001T4 */
            pr_default.execute(2, new Object[] {A133ProveedorID});
            A282ProveedorNombre = T001T4_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A488DocumentacionId = T001T4_A488DocumentacionId[0];
            n488DocumentacionId = T001T4_n488DocumentacionId[0];
            AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
            pr_default.close(2);
            /* Using cursor T001T5 */
            pr_default.execute(3, new Object[] {n488DocumentacionId, A488DocumentacionId});
            A40000DocumentacionIcono_GXI = T001T5_A40000DocumentacionIcono_GXI[0];
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            A498DocumentacionIcono = T001T5_A498DocumentacionIcono[0];
            AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            pr_default.close(3);
         }
      }

      protected void Load1T73( )
      {
         /* Using cursor T001T6 */
         pr_default.execute(4, new Object[] {A491VincularTrnId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound73 = 1;
            A282ProveedorNombre = T001T6_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A492VincularTrnSolidicutd = T001T6_A492VincularTrnSolidicutd[0];
            AssignAttri("", false, "A492VincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(A492VincularTrnSolidicutd), 18, 0));
            A493VincularTrnNombreSol = T001T6_A493VincularTrnNombreSol[0];
            AssignAttri("", false, "A493VincularTrnNombreSol", A493VincularTrnNombreSol);
            A494VincularTrnTelefonoSol = T001T6_A494VincularTrnTelefonoSol[0];
            AssignAttri("", false, "A494VincularTrnTelefonoSol", A494VincularTrnTelefonoSol);
            A40000DocumentacionIcono_GXI = T001T6_A40000DocumentacionIcono_GXI[0];
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            A40001VincularTrnImagen_GXI = T001T6_A40001VincularTrnImagen_GXI[0];
            AssignProp("", false, imgVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40001VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), true);
            AssignProp("", false, imgVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
            A497VincularTrnComentario = T001T6_A497VincularTrnComentario[0];
            AssignAttri("", false, "A497VincularTrnComentario", A497VincularTrnComentario);
            A496VincularTrnFecha = T001T6_A496VincularTrnFecha[0];
            AssignAttri("", false, "A496VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
            A133ProveedorID = T001T6_A133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            A488DocumentacionId = T001T6_A488DocumentacionId[0];
            n488DocumentacionId = T001T6_n488DocumentacionId[0];
            AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
            A498DocumentacionIcono = T001T6_A498DocumentacionIcono[0];
            AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            A495VincularTrnImagen = T001T6_A495VincularTrnImagen[0];
            AssignAttri("", false, "A495VincularTrnImagen", A495VincularTrnImagen);
            AssignProp("", false, imgVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40001VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), true);
            AssignProp("", false, imgVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
            ZM1T73( -12) ;
         }
         pr_default.close(4);
         OnLoadActions1T73( ) ;
      }

      protected void OnLoadActions1T73( )
      {
         AV25Pgmname = "VincularTrn";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
      }

      protected void CheckExtendedTable1T73( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV25Pgmname = "VincularTrn";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
         /* Using cursor T001T4 */
         pr_default.execute(2, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
         }
         A282ProveedorNombre = T001T4_A282ProveedorNombre[0];
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A488DocumentacionId = T001T4_A488DocumentacionId[0];
         n488DocumentacionId = T001T4_n488DocumentacionId[0];
         AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
         pr_default.close(2);
         /* Using cursor T001T5 */
         pr_default.execute(3, new Object[] {n488DocumentacionId, A488DocumentacionId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A488DocumentacionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Documentacion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DOCUMENTACIONID");
               AnyError = 1;
            }
         }
         A40000DocumentacionIcono_GXI = T001T5_A40000DocumentacionIcono_GXI[0];
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         A498DocumentacionIcono = T001T5_A498DocumentacionIcono[0];
         AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1T73( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( long A133ProveedorID )
      {
         /* Using cursor T001T7 */
         pr_default.execute(5, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
         }
         A282ProveedorNombre = T001T7_A282ProveedorNombre[0];
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A488DocumentacionId = T001T7_A488DocumentacionId[0];
         n488DocumentacionId = T001T7_n488DocumentacionId[0];
         AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A282ProveedorNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A488DocumentacionId), 18, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_14( long A488DocumentacionId )
      {
         /* Using cursor T001T8 */
         pr_default.execute(6, new Object[] {n488DocumentacionId, A488DocumentacionId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A488DocumentacionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Documentacion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DOCUMENTACIONID");
               AnyError = 1;
            }
         }
         A40000DocumentacionIcono_GXI = T001T8_A40000DocumentacionIcono_GXI[0];
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         A498DocumentacionIcono = T001T8_A498DocumentacionIcono[0];
         AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A498DocumentacionIcono)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000DocumentacionIcono_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1T73( )
      {
         /* Using cursor T001T9 */
         pr_default.execute(7, new Object[] {A491VincularTrnId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound73 = 1;
         }
         else
         {
            RcdFound73 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001T3 */
         pr_default.execute(1, new Object[] {A491VincularTrnId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1T73( 12) ;
            RcdFound73 = 1;
            A491VincularTrnId = T001T3_A491VincularTrnId[0];
            AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
            A492VincularTrnSolidicutd = T001T3_A492VincularTrnSolidicutd[0];
            AssignAttri("", false, "A492VincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(A492VincularTrnSolidicutd), 18, 0));
            A493VincularTrnNombreSol = T001T3_A493VincularTrnNombreSol[0];
            AssignAttri("", false, "A493VincularTrnNombreSol", A493VincularTrnNombreSol);
            A494VincularTrnTelefonoSol = T001T3_A494VincularTrnTelefonoSol[0];
            AssignAttri("", false, "A494VincularTrnTelefonoSol", A494VincularTrnTelefonoSol);
            A40001VincularTrnImagen_GXI = T001T3_A40001VincularTrnImagen_GXI[0];
            AssignProp("", false, imgVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40001VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), true);
            AssignProp("", false, imgVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
            A497VincularTrnComentario = T001T3_A497VincularTrnComentario[0];
            AssignAttri("", false, "A497VincularTrnComentario", A497VincularTrnComentario);
            A496VincularTrnFecha = T001T3_A496VincularTrnFecha[0];
            AssignAttri("", false, "A496VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
            A133ProveedorID = T001T3_A133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            A495VincularTrnImagen = T001T3_A495VincularTrnImagen[0];
            AssignAttri("", false, "A495VincularTrnImagen", A495VincularTrnImagen);
            AssignProp("", false, imgVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40001VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), true);
            AssignProp("", false, imgVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
            Z491VincularTrnId = A491VincularTrnId;
            sMode73 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1T73( ) ;
            if ( AnyError == 1 )
            {
               RcdFound73 = 0;
               InitializeNonKey1T73( ) ;
            }
            Gx_mode = sMode73;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound73 = 0;
            InitializeNonKey1T73( ) ;
            sMode73 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode73;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1T73( ) ;
         if ( RcdFound73 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound73 = 0;
         /* Using cursor T001T10 */
         pr_default.execute(8, new Object[] {A491VincularTrnId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001T10_A491VincularTrnId[0] < A491VincularTrnId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001T10_A491VincularTrnId[0] > A491VincularTrnId ) ) )
            {
               A491VincularTrnId = T001T10_A491VincularTrnId[0];
               AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
               RcdFound73 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound73 = 0;
         /* Using cursor T001T11 */
         pr_default.execute(9, new Object[] {A491VincularTrnId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001T11_A491VincularTrnId[0] > A491VincularTrnId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001T11_A491VincularTrnId[0] < A491VincularTrnId ) ) )
            {
               A491VincularTrnId = T001T11_A491VincularTrnId[0];
               AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
               RcdFound73 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1T73( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = imgVincularTrnImagen_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1T73( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound73 == 1 )
            {
               if ( A491VincularTrnId != Z491VincularTrnId )
               {
                  A491VincularTrnId = Z491VincularTrnId;
                  AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "VINCULARTRNID");
                  AnyError = 1;
                  GX_FocusControl = edtVincularTrnId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = imgVincularTrnImagen_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1T73( ) ;
                  GX_FocusControl = imgVincularTrnImagen_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A491VincularTrnId != Z491VincularTrnId )
               {
                  /* Insert record */
                  GX_FocusControl = imgVincularTrnImagen_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1T73( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VINCULARTRNID");
                     AnyError = 1;
                     GX_FocusControl = edtVincularTrnId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = imgVincularTrnImagen_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1T73( ) ;
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
         if ( A491VincularTrnId != Z491VincularTrnId )
         {
            A491VincularTrnId = Z491VincularTrnId;
            AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "VINCULARTRNID");
            AnyError = 1;
            GX_FocusControl = edtVincularTrnId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = imgVincularTrnImagen_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1T73( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001T2 */
            pr_default.execute(0, new Object[] {A491VincularTrnId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"VincularTrn"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z492VincularTrnSolidicutd != T001T2_A492VincularTrnSolidicutd[0] ) || ( StringUtil.StrCmp(Z493VincularTrnNombreSol, T001T2_A493VincularTrnNombreSol[0]) != 0 ) || ( StringUtil.StrCmp(Z494VincularTrnTelefonoSol, T001T2_A494VincularTrnTelefonoSol[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z496VincularTrnFecha ) != DateTimeUtil.ResetTime ( T001T2_A496VincularTrnFecha[0] ) ) || ( Z133ProveedorID != T001T2_A133ProveedorID[0] ) )
            {
               if ( Z492VincularTrnSolidicutd != T001T2_A492VincularTrnSolidicutd[0] )
               {
                  GXUtil.WriteLog("vinculartrn:[seudo value changed for attri]"+"VincularTrnSolidicutd");
                  GXUtil.WriteLogRaw("Old: ",Z492VincularTrnSolidicutd);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A492VincularTrnSolidicutd[0]);
               }
               if ( StringUtil.StrCmp(Z493VincularTrnNombreSol, T001T2_A493VincularTrnNombreSol[0]) != 0 )
               {
                  GXUtil.WriteLog("vinculartrn:[seudo value changed for attri]"+"VincularTrnNombreSol");
                  GXUtil.WriteLogRaw("Old: ",Z493VincularTrnNombreSol);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A493VincularTrnNombreSol[0]);
               }
               if ( StringUtil.StrCmp(Z494VincularTrnTelefonoSol, T001T2_A494VincularTrnTelefonoSol[0]) != 0 )
               {
                  GXUtil.WriteLog("vinculartrn:[seudo value changed for attri]"+"VincularTrnTelefonoSol");
                  GXUtil.WriteLogRaw("Old: ",Z494VincularTrnTelefonoSol);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A494VincularTrnTelefonoSol[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z496VincularTrnFecha ) != DateTimeUtil.ResetTime ( T001T2_A496VincularTrnFecha[0] ) )
               {
                  GXUtil.WriteLog("vinculartrn:[seudo value changed for attri]"+"VincularTrnFecha");
                  GXUtil.WriteLogRaw("Old: ",Z496VincularTrnFecha);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A496VincularTrnFecha[0]);
               }
               if ( Z133ProveedorID != T001T2_A133ProveedorID[0] )
               {
                  GXUtil.WriteLog("vinculartrn:[seudo value changed for attri]"+"ProveedorID");
                  GXUtil.WriteLogRaw("Old: ",Z133ProveedorID);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A133ProveedorID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"VincularTrn"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1T73( )
      {
         BeforeValidate1T73( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1T73( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1T73( 0) ;
            CheckOptimisticConcurrency1T73( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1T73( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1T73( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001T12 */
                     pr_default.execute(10, new Object[] {A492VincularTrnSolidicutd, A493VincularTrnNombreSol, A494VincularTrnTelefonoSol, A495VincularTrnImagen, A40001VincularTrnImagen_GXI, A497VincularTrnComentario, A496VincularTrnFecha, A133ProveedorID});
                     A491VincularTrnId = T001T12_A491VincularTrnId[0];
                     AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("VincularTrn");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1T0( ) ;
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
               Load1T73( ) ;
            }
            EndLevel1T73( ) ;
         }
         CloseExtendedTableCursors1T73( ) ;
      }

      protected void Update1T73( )
      {
         BeforeValidate1T73( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1T73( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1T73( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1T73( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1T73( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001T13 */
                     pr_default.execute(11, new Object[] {A492VincularTrnSolidicutd, A493VincularTrnNombreSol, A494VincularTrnTelefonoSol, A497VincularTrnComentario, A496VincularTrnFecha, A133ProveedorID, A491VincularTrnId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("VincularTrn");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"VincularTrn"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1T73( ) ;
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
            EndLevel1T73( ) ;
         }
         CloseExtendedTableCursors1T73( ) ;
      }

      protected void DeferredUpdate1T73( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001T14 */
            pr_default.execute(12, new Object[] {A495VincularTrnImagen, A40001VincularTrnImagen_GXI, A491VincularTrnId});
            pr_default.close(12);
            pr_default.SmartCacheProvider.SetUpdated("VincularTrn");
         }
      }

      protected void delete( )
      {
         BeforeValidate1T73( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1T73( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1T73( ) ;
            AfterConfirm1T73( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1T73( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001T15 */
                  pr_default.execute(13, new Object[] {A491VincularTrnId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("VincularTrn");
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
         sMode73 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1T73( ) ;
         Gx_mode = sMode73;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1T73( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV25Pgmname = "VincularTrn";
            AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
            /* Using cursor T001T16 */
            pr_default.execute(14, new Object[] {A133ProveedorID});
            A282ProveedorNombre = T001T16_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A488DocumentacionId = T001T16_A488DocumentacionId[0];
            n488DocumentacionId = T001T16_n488DocumentacionId[0];
            AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
            pr_default.close(14);
            /* Using cursor T001T17 */
            pr_default.execute(15, new Object[] {n488DocumentacionId, A488DocumentacionId});
            A40000DocumentacionIcono_GXI = T001T17_A40000DocumentacionIcono_GXI[0];
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            A498DocumentacionIcono = T001T17_A498DocumentacionIcono[0];
            AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            pr_default.close(15);
         }
      }

      protected void EndLevel1T73( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1T73( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(14);
            pr_default.close(15);
            context.CommitDataStores("vinculartrn",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1T0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(14);
            pr_default.close(15);
            context.RollbackDataStores("vinculartrn",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1T73( )
      {
         /* Scan By routine */
         /* Using cursor T001T18 */
         pr_default.execute(16);
         RcdFound73 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound73 = 1;
            A491VincularTrnId = T001T18_A491VincularTrnId[0];
            AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1T73( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound73 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound73 = 1;
            A491VincularTrnId = T001T18_A491VincularTrnId[0];
            AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
         }
      }

      protected void ScanEnd1T73( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm1T73( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1T73( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1T73( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1T73( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1T73( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1T73( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1T73( )
      {
         edtVincularTrnId_Enabled = 0;
         AssignProp("", false, edtVincularTrnId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnId_Enabled), 5, 0), true);
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         edtVincularTrnSolidicutd_Enabled = 0;
         AssignProp("", false, edtVincularTrnSolidicutd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnSolidicutd_Enabled), 5, 0), true);
         edtVincularTrnNombreSol_Enabled = 0;
         AssignProp("", false, edtVincularTrnNombreSol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnNombreSol_Enabled), 5, 0), true);
         edtVincularTrnTelefonoSol_Enabled = 0;
         AssignProp("", false, edtVincularTrnTelefonoSol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnTelefonoSol_Enabled), 5, 0), true);
         edtDocumentacionId_Enabled = 0;
         AssignProp("", false, edtDocumentacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentacionId_Enabled), 5, 0), true);
         imgDocumentacionIcono_Enabled = 0;
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgDocumentacionIcono_Enabled), 5, 0), true);
         imgVincularTrnImagen_Enabled = 0;
         AssignProp("", false, imgVincularTrnImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgVincularTrnImagen_Enabled), 5, 0), true);
         edtVincularTrnComentario_Enabled = 0;
         AssignProp("", false, edtVincularTrnComentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnComentario_Enabled), 5, 0), true);
         edtVincularTrnFecha_Enabled = 0;
         AssignProp("", false, edtVincularTrnFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnFecha_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1T73( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1T0( )
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
         GXEncryptionTmp = "vinculartrn.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV11VincularTrnId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("vinculartrn.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"VincularTrn");
         forbiddenHiddens.Add("VincularTrnId", context.localUtil.Format( (decimal)(A491VincularTrnId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("VincularTrnSolidicutd", context.localUtil.Format( (decimal)(A492VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("VincularTrnNombreSol", StringUtil.RTrim( context.localUtil.Format( A493VincularTrnNombreSol, "")));
         forbiddenHiddens.Add("VincularTrnTelefonoSol", StringUtil.RTrim( context.localUtil.Format( A494VincularTrnTelefonoSol, "")));
         forbiddenHiddens.Add("VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
         forbiddenHiddens.Add("Insert_ProveedorID", context.localUtil.Format( (decimal)(AV15Insert_ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("vinculartrn:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z491VincularTrnId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z491VincularTrnId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z492VincularTrnSolidicutd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z492VincularTrnSolidicutd), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z493VincularTrnNombreSol", StringUtil.RTrim( Z493VincularTrnNombreSol));
         GxWebStd.gx_hidden_field( context, "Z494VincularTrnTelefonoSol", StringUtil.RTrim( Z494VincularTrnTelefonoSol));
         GxWebStd.gx_hidden_field( context, "Z496VincularTrnFecha", context.localUtil.DToC( Z496VincularTrnFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV13TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV13TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV13TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vVINCULARTRNID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11VincularTrnId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vVINCULARTRNID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11VincularTrnId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Insert_ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "VINCULARTRNIMAGEN_GXI", A40001VincularTrnImagen_GXI);
         GxWebStd.gx_hidden_field( context, "DOCUMENTACIONICONO_GXI", A40000DocumentacionIcono_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GXCCtlgxBlob = "DOCUMENTACIONICONO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A498DocumentacionIcono);
         GXCCtlgxBlob = "VINCULARTRNIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A495VincularTrnImagen);
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
         GXEncryptionTmp = "vinculartrn.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV11VincularTrnId,18,0));
         return formatLink("vinculartrn.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "VincularTrn" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Vincular Trn", "") ;
      }

      protected void InitializeNonKey1T73( )
      {
         A133ProveedorID = 0;
         AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         A282ProveedorNombre = "";
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A492VincularTrnSolidicutd = 0;
         AssignAttri("", false, "A492VincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(A492VincularTrnSolidicutd), 18, 0));
         A493VincularTrnNombreSol = "";
         AssignAttri("", false, "A493VincularTrnNombreSol", A493VincularTrnNombreSol);
         A494VincularTrnTelefonoSol = "";
         AssignAttri("", false, "A494VincularTrnTelefonoSol", A494VincularTrnTelefonoSol);
         A488DocumentacionId = 0;
         n488DocumentacionId = false;
         AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
         A498DocumentacionIcono = "";
         AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         A40000DocumentacionIcono_GXI = "";
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         A495VincularTrnImagen = "";
         AssignAttri("", false, "A495VincularTrnImagen", A495VincularTrnImagen);
         AssignProp("", false, imgVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40001VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), true);
         AssignProp("", false, imgVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
         A40001VincularTrnImagen_GXI = "";
         AssignProp("", false, imgVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40001VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), true);
         AssignProp("", false, imgVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
         A497VincularTrnComentario = "";
         AssignAttri("", false, "A497VincularTrnComentario", A497VincularTrnComentario);
         A496VincularTrnFecha = DateTime.MinValue;
         AssignAttri("", false, "A496VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
         Z492VincularTrnSolidicutd = 0;
         Z493VincularTrnNombreSol = "";
         Z494VincularTrnTelefonoSol = "";
         Z496VincularTrnFecha = DateTime.MinValue;
         Z133ProveedorID = 0;
      }

      protected void InitAll1T73( )
      {
         A491VincularTrnId = 0;
         AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
         InitializeNonKey1T73( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932072914", true, true, false);
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
         context.AddJavascriptSource("vinculartrn.js", "?2026932072915", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtVincularTrnId_Internalname = "VINCULARTRNID";
         edtProveedorID_Internalname = "PROVEEDORID";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         edtVincularTrnSolidicutd_Internalname = "VINCULARTRNSOLIDICUTD";
         edtVincularTrnNombreSol_Internalname = "VINCULARTRNNOMBRESOL";
         edtVincularTrnTelefonoSol_Internalname = "VINCULARTRNTELEFONOSOL";
         edtDocumentacionId_Internalname = "DOCUMENTACIONID";
         imgDocumentacionIcono_Internalname = "DOCUMENTACIONICONO";
         imgVincularTrnImagen_Internalname = "VINCULARTRNIMAGEN";
         edtVincularTrnComentario_Internalname = "VINCULARTRNCOMENTARIO";
         edtVincularTrnFecha_Internalname = "VINCULARTRNFECHA";
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
         Form.Caption = context.GetMessage( "Vincular Trn", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtVincularTrnFecha_Jsonclick = "";
         edtVincularTrnFecha_Enabled = 0;
         edtVincularTrnComentario_Enabled = 1;
         imgVincularTrnImagen_Enabled = 1;
         imgDocumentacionIcono_Enabled = 0;
         edtDocumentacionId_Jsonclick = "";
         edtDocumentacionId_Enabled = 0;
         edtVincularTrnTelefonoSol_Jsonclick = "";
         edtVincularTrnTelefonoSol_Enabled = 0;
         edtVincularTrnNombreSol_Jsonclick = "";
         edtVincularTrnNombreSol_Enabled = 0;
         edtVincularTrnSolidicutd_Jsonclick = "";
         edtVincularTrnSolidicutd_Enabled = 0;
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Enabled = 0;
         edtProveedorID_Jsonclick = "";
         edtProveedorID_Enabled = 0;
         edtVincularTrnId_Jsonclick = "";
         edtVincularTrnId_Enabled = 0;
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

      public void Valid_Proveedorid( )
      {
         n488DocumentacionId = false;
         /* Using cursor T001T16 */
         pr_default.execute(14, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
         }
         A282ProveedorNombre = T001T16_A282ProveedorNombre[0];
         A488DocumentacionId = T001T16_A488DocumentacionId[0];
         n488DocumentacionId = T001T16_n488DocumentacionId[0];
         pr_default.close(14);
         /* Using cursor T001T17 */
         pr_default.execute(15, new Object[] {n488DocumentacionId, A488DocumentacionId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A488DocumentacionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Documentacion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DOCUMENTACIONID");
               AnyError = 1;
            }
         }
         A40000DocumentacionIcono_GXI = T001T17_A40000DocumentacionIcono_GXI[0];
         A498DocumentacionIcono = T001T17_A498DocumentacionIcono[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A282ProveedorNombre", StringUtil.RTrim( A282ProveedorNombre));
         AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A488DocumentacionId), 18, 0, ".", "")));
         AssignAttri("", false, "A498DocumentacionIcono", context.PathToRelativeUrl( A498DocumentacionIcono));
         GXCCtlgxBlob = "DOCUMENTACIONICONO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A498DocumentacionIcono));
         AssignAttri("", false, "A40000DocumentacionIcono_GXI", A40000DocumentacionIcono_GXI);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11VincularTrnId',fld:'vVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV13TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV11VincularTrnId',fld:'vVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A491VincularTrnId',fld:'VINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A492VincularTrnSolidicutd',fld:'VINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A493VincularTrnNombreSol',fld:'VINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'A494VincularTrnTelefonoSol',fld:'VINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'A496VincularTrnFecha',fld:'VINCULARTRNFECHA',pic:'',type:'date'},{av:'AV15Insert_ProveedorID',fld:'vINSERT_PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E121T2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV13TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_VINCULARTRNID","{handler:'Valid_Vinculartrnid',iparms:[]");
         setEventMetadata("VALID_VINCULARTRNID",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A488DocumentacionId',fld:'DOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'A498DocumentacionIcono',fld:'DOCUMENTACIONICONO',pic:'',type:'bits'},{av:'A40000DocumentacionIcono_GXI',fld:'DOCUMENTACIONICONO_GXI',pic:'',type:'svchar'}]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'A488DocumentacionId',fld:'DOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A498DocumentacionIcono',fld:'DOCUMENTACIONICONO',pic:'',type:'bits'},{av:'A40000DocumentacionIcono_GXI',fld:'DOCUMENTACIONICONO_GXI',pic:'',type:'svchar'}]}");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z493VincularTrnNombreSol = "";
         Z494VincularTrnTelefonoSol = "";
         Z496VincularTrnFecha = DateTime.MinValue;
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
         A282ProveedorNombre = "";
         A493VincularTrnNombreSol = "";
         gxphoneLink = "";
         A494VincularTrnTelefonoSol = "";
         A498DocumentacionIcono = "";
         A40000DocumentacionIcono_GXI = "";
         sImgUrl = "";
         A495VincularTrnImagen = "";
         A40001VincularTrnImagen_GXI = "";
         A497VincularTrnComentario = "";
         A496VincularTrnFecha = DateTime.MinValue;
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV25Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode73 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV17WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV13TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV14WebSession = context.GetSession();
         AV16TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z495VincularTrnImagen = "";
         Z40001VincularTrnImagen_GXI = "";
         Z497VincularTrnComentario = "";
         Z282ProveedorNombre = "";
         Z498DocumentacionIcono = "";
         Z40000DocumentacionIcono_GXI = "";
         T001T4_A282ProveedorNombre = new string[] {""} ;
         T001T4_A488DocumentacionId = new long[1] ;
         T001T4_n488DocumentacionId = new bool[] {false} ;
         T001T5_A40000DocumentacionIcono_GXI = new string[] {""} ;
         T001T5_A498DocumentacionIcono = new string[] {""} ;
         T001T6_A491VincularTrnId = new long[1] ;
         T001T6_A282ProveedorNombre = new string[] {""} ;
         T001T6_A492VincularTrnSolidicutd = new long[1] ;
         T001T6_A493VincularTrnNombreSol = new string[] {""} ;
         T001T6_A494VincularTrnTelefonoSol = new string[] {""} ;
         T001T6_A40000DocumentacionIcono_GXI = new string[] {""} ;
         T001T6_A40001VincularTrnImagen_GXI = new string[] {""} ;
         T001T6_A497VincularTrnComentario = new string[] {""} ;
         T001T6_A496VincularTrnFecha = new DateTime[] {DateTime.MinValue} ;
         T001T6_A133ProveedorID = new long[1] ;
         T001T6_A488DocumentacionId = new long[1] ;
         T001T6_n488DocumentacionId = new bool[] {false} ;
         T001T6_A498DocumentacionIcono = new string[] {""} ;
         T001T6_A495VincularTrnImagen = new string[] {""} ;
         T001T7_A282ProveedorNombre = new string[] {""} ;
         T001T7_A488DocumentacionId = new long[1] ;
         T001T7_n488DocumentacionId = new bool[] {false} ;
         T001T8_A40000DocumentacionIcono_GXI = new string[] {""} ;
         T001T8_A498DocumentacionIcono = new string[] {""} ;
         T001T9_A491VincularTrnId = new long[1] ;
         T001T3_A491VincularTrnId = new long[1] ;
         T001T3_A492VincularTrnSolidicutd = new long[1] ;
         T001T3_A493VincularTrnNombreSol = new string[] {""} ;
         T001T3_A494VincularTrnTelefonoSol = new string[] {""} ;
         T001T3_A40001VincularTrnImagen_GXI = new string[] {""} ;
         T001T3_A497VincularTrnComentario = new string[] {""} ;
         T001T3_A496VincularTrnFecha = new DateTime[] {DateTime.MinValue} ;
         T001T3_A133ProveedorID = new long[1] ;
         T001T3_A495VincularTrnImagen = new string[] {""} ;
         T001T10_A491VincularTrnId = new long[1] ;
         T001T11_A491VincularTrnId = new long[1] ;
         T001T2_A491VincularTrnId = new long[1] ;
         T001T2_A492VincularTrnSolidicutd = new long[1] ;
         T001T2_A493VincularTrnNombreSol = new string[] {""} ;
         T001T2_A494VincularTrnTelefonoSol = new string[] {""} ;
         T001T2_A40001VincularTrnImagen_GXI = new string[] {""} ;
         T001T2_A497VincularTrnComentario = new string[] {""} ;
         T001T2_A496VincularTrnFecha = new DateTime[] {DateTime.MinValue} ;
         T001T2_A133ProveedorID = new long[1] ;
         T001T2_A495VincularTrnImagen = new string[] {""} ;
         T001T12_A491VincularTrnId = new long[1] ;
         T001T16_A282ProveedorNombre = new string[] {""} ;
         T001T16_A488DocumentacionId = new long[1] ;
         T001T16_n488DocumentacionId = new bool[] {false} ;
         T001T17_A40000DocumentacionIcono_GXI = new string[] {""} ;
         T001T17_A498DocumentacionIcono = new string[] {""} ;
         T001T18_A491VincularTrnId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.vinculartrn__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.vinculartrn__default(),
            new Object[][] {
                new Object[] {
               T001T2_A491VincularTrnId, T001T2_A492VincularTrnSolidicutd, T001T2_A493VincularTrnNombreSol, T001T2_A494VincularTrnTelefonoSol, T001T2_A40001VincularTrnImagen_GXI, T001T2_A497VincularTrnComentario, T001T2_A496VincularTrnFecha, T001T2_A133ProveedorID, T001T2_A495VincularTrnImagen
               }
               , new Object[] {
               T001T3_A491VincularTrnId, T001T3_A492VincularTrnSolidicutd, T001T3_A493VincularTrnNombreSol, T001T3_A494VincularTrnTelefonoSol, T001T3_A40001VincularTrnImagen_GXI, T001T3_A497VincularTrnComentario, T001T3_A496VincularTrnFecha, T001T3_A133ProveedorID, T001T3_A495VincularTrnImagen
               }
               , new Object[] {
               T001T4_A282ProveedorNombre, T001T4_A488DocumentacionId, T001T4_n488DocumentacionId
               }
               , new Object[] {
               T001T5_A40000DocumentacionIcono_GXI, T001T5_A498DocumentacionIcono
               }
               , new Object[] {
               T001T6_A491VincularTrnId, T001T6_A282ProveedorNombre, T001T6_A492VincularTrnSolidicutd, T001T6_A493VincularTrnNombreSol, T001T6_A494VincularTrnTelefonoSol, T001T6_A40000DocumentacionIcono_GXI, T001T6_A40001VincularTrnImagen_GXI, T001T6_A497VincularTrnComentario, T001T6_A496VincularTrnFecha, T001T6_A133ProveedorID,
               T001T6_A488DocumentacionId, T001T6_n488DocumentacionId, T001T6_A498DocumentacionIcono, T001T6_A495VincularTrnImagen
               }
               , new Object[] {
               T001T7_A282ProveedorNombre, T001T7_A488DocumentacionId, T001T7_n488DocumentacionId
               }
               , new Object[] {
               T001T8_A40000DocumentacionIcono_GXI, T001T8_A498DocumentacionIcono
               }
               , new Object[] {
               T001T9_A491VincularTrnId
               }
               , new Object[] {
               T001T10_A491VincularTrnId
               }
               , new Object[] {
               T001T11_A491VincularTrnId
               }
               , new Object[] {
               T001T12_A491VincularTrnId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001T16_A282ProveedorNombre, T001T16_A488DocumentacionId, T001T16_n488DocumentacionId
               }
               , new Object[] {
               T001T17_A40000DocumentacionIcono_GXI, T001T17_A498DocumentacionIcono
               }
               , new Object[] {
               T001T18_A491VincularTrnId
               }
            }
         );
         AV25Pgmname = "VincularTrn";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound73 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtVincularTrnId_Enabled ;
      private int edtProveedorID_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtVincularTrnSolidicutd_Enabled ;
      private int edtVincularTrnNombreSol_Enabled ;
      private int edtVincularTrnTelefonoSol_Enabled ;
      private int edtDocumentacionId_Enabled ;
      private int imgDocumentacionIcono_Enabled ;
      private int imgVincularTrnImagen_Enabled ;
      private int edtVincularTrnComentario_Enabled ;
      private int edtVincularTrnFecha_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV26GXV1 ;
      private int idxLst ;
      private long wcpOAV11VincularTrnId ;
      private long Z491VincularTrnId ;
      private long Z492VincularTrnSolidicutd ;
      private long Z133ProveedorID ;
      private long N133ProveedorID ;
      private long A133ProveedorID ;
      private long A488DocumentacionId ;
      private long AV11VincularTrnId ;
      private long A491VincularTrnId ;
      private long A492VincularTrnSolidicutd ;
      private long AV15Insert_ProveedorID ;
      private long Z488DocumentacionId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z493VincularTrnNombreSol ;
      private string Z494VincularTrnTelefonoSol ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string imgVincularTrnImagen_Internalname ;
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
      private string edtVincularTrnId_Internalname ;
      private string TempTags ;
      private string edtVincularTrnId_Jsonclick ;
      private string edtProveedorID_Internalname ;
      private string edtProveedorID_Jsonclick ;
      private string edtProveedorNombre_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Jsonclick ;
      private string edtVincularTrnSolidicutd_Internalname ;
      private string edtVincularTrnSolidicutd_Jsonclick ;
      private string edtVincularTrnNombreSol_Internalname ;
      private string A493VincularTrnNombreSol ;
      private string edtVincularTrnNombreSol_Jsonclick ;
      private string edtVincularTrnTelefonoSol_Internalname ;
      private string gxphoneLink ;
      private string A494VincularTrnTelefonoSol ;
      private string edtVincularTrnTelefonoSol_Jsonclick ;
      private string edtDocumentacionId_Internalname ;
      private string edtDocumentacionId_Jsonclick ;
      private string imgDocumentacionIcono_Internalname ;
      private string sImgUrl ;
      private string edtVincularTrnComentario_Internalname ;
      private string edtVincularTrnFecha_Internalname ;
      private string edtVincularTrnFecha_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV25Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode73 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string Z282ProveedorNombre ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private DateTime Z496VincularTrnFecha ;
      private DateTime A496VincularTrnFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n488DocumentacionId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A498DocumentacionIcono_IsBlob ;
      private bool A495VincularTrnImagen_IsBlob ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV12IsAuthorized ;
      private bool GXt_boolean1 ;
      private string A497VincularTrnComentario ;
      private string Z497VincularTrnComentario ;
      private string A40000DocumentacionIcono_GXI ;
      private string A40001VincularTrnImagen_GXI ;
      private string Z40001VincularTrnImagen_GXI ;
      private string Z40000DocumentacionIcono_GXI ;
      private string A498DocumentacionIcono ;
      private string A495VincularTrnImagen ;
      private string Z495VincularTrnImagen ;
      private string Z498DocumentacionIcono ;
      private IGxSession AV14WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV17WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV13TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV16TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T001T4_A282ProveedorNombre ;
      private long[] T001T4_A488DocumentacionId ;
      private bool[] T001T4_n488DocumentacionId ;
      private string[] T001T5_A40000DocumentacionIcono_GXI ;
      private string[] T001T5_A498DocumentacionIcono ;
      private long[] T001T6_A491VincularTrnId ;
      private string[] T001T6_A282ProveedorNombre ;
      private long[] T001T6_A492VincularTrnSolidicutd ;
      private string[] T001T6_A493VincularTrnNombreSol ;
      private string[] T001T6_A494VincularTrnTelefonoSol ;
      private string[] T001T6_A40000DocumentacionIcono_GXI ;
      private string[] T001T6_A40001VincularTrnImagen_GXI ;
      private string[] T001T6_A497VincularTrnComentario ;
      private DateTime[] T001T6_A496VincularTrnFecha ;
      private long[] T001T6_A133ProveedorID ;
      private long[] T001T6_A488DocumentacionId ;
      private bool[] T001T6_n488DocumentacionId ;
      private string[] T001T6_A498DocumentacionIcono ;
      private string[] T001T6_A495VincularTrnImagen ;
      private string[] T001T7_A282ProveedorNombre ;
      private long[] T001T7_A488DocumentacionId ;
      private bool[] T001T7_n488DocumentacionId ;
      private string[] T001T8_A40000DocumentacionIcono_GXI ;
      private string[] T001T8_A498DocumentacionIcono ;
      private long[] T001T9_A491VincularTrnId ;
      private long[] T001T3_A491VincularTrnId ;
      private long[] T001T3_A492VincularTrnSolidicutd ;
      private string[] T001T3_A493VincularTrnNombreSol ;
      private string[] T001T3_A494VincularTrnTelefonoSol ;
      private string[] T001T3_A40001VincularTrnImagen_GXI ;
      private string[] T001T3_A497VincularTrnComentario ;
      private DateTime[] T001T3_A496VincularTrnFecha ;
      private long[] T001T3_A133ProveedorID ;
      private string[] T001T3_A495VincularTrnImagen ;
      private long[] T001T10_A491VincularTrnId ;
      private long[] T001T11_A491VincularTrnId ;
      private long[] T001T2_A491VincularTrnId ;
      private long[] T001T2_A492VincularTrnSolidicutd ;
      private string[] T001T2_A493VincularTrnNombreSol ;
      private string[] T001T2_A494VincularTrnTelefonoSol ;
      private string[] T001T2_A40001VincularTrnImagen_GXI ;
      private string[] T001T2_A497VincularTrnComentario ;
      private DateTime[] T001T2_A496VincularTrnFecha ;
      private long[] T001T2_A133ProveedorID ;
      private string[] T001T2_A495VincularTrnImagen ;
      private long[] T001T12_A491VincularTrnId ;
      private string[] T001T16_A282ProveedorNombre ;
      private long[] T001T16_A488DocumentacionId ;
      private bool[] T001T16_n488DocumentacionId ;
      private string[] T001T17_A40000DocumentacionIcono_GXI ;
      private string[] T001T17_A498DocumentacionIcono ;
      private long[] T001T18_A491VincularTrnId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class vinculartrn__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class vinculartrn__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001T2;
        prmT001T2 = new Object[] {
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001T3;
        prmT001T3 = new Object[] {
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001T4;
        prmT001T4 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT001T5;
        prmT001T5 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001T6;
        prmT001T6 = new Object[] {
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001T7;
        prmT001T7 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT001T8;
        prmT001T8 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001T9;
        prmT001T9 = new Object[] {
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001T10;
        prmT001T10 = new Object[] {
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001T11;
        prmT001T11 = new Object[] {
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001T12;
        prmT001T12 = new Object[] {
        new ParDef("@VincularTrnSolidicutd",GXType.Decimal,18,0) ,
        new ParDef("@VincularTrnNombreSol",GXType.NChar,80,0) ,
        new ParDef("@VincularTrnTelefonoSol",GXType.NChar,20,0) ,
        new ParDef("@VincularTrnImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@VincularTrnImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="VincularTrn", Fld="VincularTrnImagen"} ,
        new ParDef("@VincularTrnComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@VincularTrnFecha",GXType.Date,8,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT001T13;
        prmT001T13 = new Object[] {
        new ParDef("@VincularTrnSolidicutd",GXType.Decimal,18,0) ,
        new ParDef("@VincularTrnNombreSol",GXType.NChar,80,0) ,
        new ParDef("@VincularTrnTelefonoSol",GXType.NChar,20,0) ,
        new ParDef("@VincularTrnComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@VincularTrnFecha",GXType.Date,8,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001T14;
        prmT001T14 = new Object[] {
        new ParDef("@VincularTrnImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@VincularTrnImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="VincularTrn", Fld="VincularTrnImagen"} ,
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001T15;
        prmT001T15 = new Object[] {
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001T16;
        prmT001T16 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT001T17;
        prmT001T17 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001T18;
        prmT001T18 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001T2", "SELECT [VincularTrnId], [VincularTrnSolidicutd], [VincularTrnNombreSol], [VincularTrnTelefonoSol], [VincularTrnImagen_GXI], [VincularTrnComentario], [VincularTrnFecha], [ProveedorID], [VincularTrnImagen] FROM [VincularTrn] WITH (UPDLOCK) WHERE [VincularTrnId] = @VincularTrnId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T3", "SELECT [VincularTrnId], [VincularTrnSolidicutd], [VincularTrnNombreSol], [VincularTrnTelefonoSol], [VincularTrnImagen_GXI], [VincularTrnComentario], [VincularTrnFecha], [ProveedorID], [VincularTrnImagen] FROM [VincularTrn] WHERE [VincularTrnId] = @VincularTrnId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T4", "SELECT [ProveedorNombre], [DocumentacionId] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T5", "SELECT [DocumentacionIcono_GXI], [DocumentacionIcono] FROM [Documentacion] WHERE [DocumentacionId] = @DocumentacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T6", "SELECT TM1.[VincularTrnId], T2.[ProveedorNombre], TM1.[VincularTrnSolidicutd], TM1.[VincularTrnNombreSol], TM1.[VincularTrnTelefonoSol], T3.[DocumentacionIcono_GXI], TM1.[VincularTrnImagen_GXI], TM1.[VincularTrnComentario], TM1.[VincularTrnFecha], TM1.[ProveedorID], T2.[DocumentacionId], T3.[DocumentacionIcono], TM1.[VincularTrnImagen] FROM (([VincularTrn] TM1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = TM1.[ProveedorID]) LEFT JOIN [Documentacion] T3 ON T3.[DocumentacionId] = T2.[DocumentacionId]) WHERE TM1.[VincularTrnId] = @VincularTrnId ORDER BY TM1.[VincularTrnId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001T6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T7", "SELECT [ProveedorNombre], [DocumentacionId] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T8", "SELECT [DocumentacionIcono_GXI], [DocumentacionIcono] FROM [Documentacion] WHERE [DocumentacionId] = @DocumentacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T9", "SELECT [VincularTrnId] FROM [VincularTrn] WHERE [VincularTrnId] = @VincularTrnId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001T9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T10", "SELECT TOP 1 [VincularTrnId] FROM [VincularTrn] WHERE ( [VincularTrnId] > @VincularTrnId) ORDER BY [VincularTrnId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001T10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001T11", "SELECT TOP 1 [VincularTrnId] FROM [VincularTrn] WHERE ( [VincularTrnId] < @VincularTrnId) ORDER BY [VincularTrnId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001T11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001T12", "INSERT INTO [VincularTrn]([VincularTrnSolidicutd], [VincularTrnNombreSol], [VincularTrnTelefonoSol], [VincularTrnImagen], [VincularTrnImagen_GXI], [VincularTrnComentario], [VincularTrnFecha], [ProveedorID]) VALUES(@VincularTrnSolidicutd, @VincularTrnNombreSol, @VincularTrnTelefonoSol, @VincularTrnImagen, @VincularTrnImagen_GXI, @VincularTrnComentario, @VincularTrnFecha, @ProveedorID); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001T12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001T13", "UPDATE [VincularTrn] SET [VincularTrnSolidicutd]=@VincularTrnSolidicutd, [VincularTrnNombreSol]=@VincularTrnNombreSol, [VincularTrnTelefonoSol]=@VincularTrnTelefonoSol, [VincularTrnComentario]=@VincularTrnComentario, [VincularTrnFecha]=@VincularTrnFecha, [ProveedorID]=@ProveedorID  WHERE [VincularTrnId] = @VincularTrnId", GxErrorMask.GX_NOMASK,prmT001T13)
           ,new CursorDef("T001T14", "UPDATE [VincularTrn] SET [VincularTrnImagen]=@VincularTrnImagen, [VincularTrnImagen_GXI]=@VincularTrnImagen_GXI  WHERE [VincularTrnId] = @VincularTrnId", GxErrorMask.GX_NOMASK,prmT001T14)
           ,new CursorDef("T001T15", "DELETE FROM [VincularTrn]  WHERE [VincularTrnId] = @VincularTrnId", GxErrorMask.GX_NOMASK,prmT001T15)
           ,new CursorDef("T001T16", "SELECT [ProveedorNombre], [DocumentacionId] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T17", "SELECT [DocumentacionIcono_GXI], [DocumentacionIcono] FROM [Documentacion] WHERE [DocumentacionId] = @DocumentacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T18", "SELECT [VincularTrnId] FROM [VincularTrn] ORDER BY [VincularTrnId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001T18,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((long[]) buf[10])[0] = rslt.getLong(11);
              ((bool[]) buf[11])[0] = rslt.wasNull(11);
              ((string[]) buf[12])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(6));
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(7));
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
