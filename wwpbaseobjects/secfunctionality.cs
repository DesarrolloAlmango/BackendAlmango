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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secfunctionality : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A14SecParentFunctionalityId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecParentFunctionalityId"), "."), 18, MidpointRounding.ToEven));
            n14SecParentFunctionalityId = false;
            AssignAttri("", false, "A14SecParentFunctionalityId", StringUtil.LTrimStr( (decimal)(A14SecParentFunctionalityId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A14SecParentFunctionalityId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.secfunctionality.aspx")), "wwpbaseobjects.secfunctionality.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.secfunctionality.aspx")))) ;
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
                  AV7SecFunctionalityId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecFunctionalityId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7SecFunctionalityId", StringUtil.LTrimStr( (decimal)(AV7SecFunctionalityId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSECFUNCTIONALITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SecFunctionalityId), "ZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Functionality", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSecFunctionalityKey_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public secfunctionality( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionality( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_SecFunctionalityId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SecFunctionalityId = aP1_SecFunctionalityId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbSecFunctionalityType = new GXCombobox();
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
         if ( cmbSecFunctionalityType.ItemCount > 0 )
         {
            A21SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cmbSecFunctionalityType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A21SecFunctionalityType), 2, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A21SecFunctionalityType", StringUtil.LTrimStr( (decimal)(A21SecFunctionalityType), 2, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSecFunctionalityType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A21SecFunctionalityType), 2, 0));
            AssignProp("", false, cmbSecFunctionalityType_Internalname, "Values", cmbSecFunctionalityType.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecFunctionalityId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecFunctionalityId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecFunctionalityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SecFunctionalityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSecFunctionalityId_Enabled!=0) ? context.localUtil.Format( (decimal)(A13SecFunctionalityId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A13SecFunctionalityId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecFunctionalityId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecFunctionalityId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SecFunctionality.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecFunctionalityKey_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecFunctionalityKey_Internalname, context.GetMessage( "Key", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecFunctionalityKey_Internalname, A15SecFunctionalityKey, StringUtil.RTrim( context.localUtil.Format( A15SecFunctionalityKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecFunctionalityKey_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecFunctionalityKey_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecFunctionality.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecFunctionalityDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecFunctionalityDescription_Internalname, context.GetMessage( "Description", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecFunctionalityDescription_Internalname, A20SecFunctionalityDescription, StringUtil.RTrim( context.localUtil.Format( A20SecFunctionalityDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecFunctionalityDescription_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecFunctionalityDescription_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecFunctionality.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSecFunctionalityType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSecFunctionalityType_Internalname, context.GetMessage( "Type", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSecFunctionalityType, cmbSecFunctionalityType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A21SecFunctionalityType), 2, 0)), 1, cmbSecFunctionalityType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbSecFunctionalityType.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 0, "HLP_WWPBaseObjects/SecFunctionality.htm");
         cmbSecFunctionalityType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A21SecFunctionalityType), 2, 0));
         AssignProp("", false, cmbSecFunctionalityType_Internalname, "Values", (string)(cmbSecFunctionalityType.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionality.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionality.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionality.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecParentFunctionalityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A14SecParentFunctionalityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A14SecParentFunctionalityId), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecParentFunctionalityId_Jsonclick, 0, "Attribute", "", "", "", "", edtSecParentFunctionalityId_Visible, edtSecParentFunctionalityId_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SecFunctionality.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_14_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_14_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_14_Internalname, sImgUrl, imgprompt_14_Link, "", "", context.GetTheme( ), imgprompt_14_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/SecFunctionality.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecFunctionalityActive_Internalname, StringUtil.BoolToStr( A19SecFunctionalityActive), StringUtil.BoolToStr( A19SecFunctionalityActive), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecFunctionalityActive_Jsonclick, 0, "Attribute", "", "", "", "", edtSecFunctionalityActive_Visible, edtSecFunctionalityActive_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SecFunctionality.htm");
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
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z13SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z13SecFunctionalityId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z15SecFunctionalityKey = cgiGet( "Z15SecFunctionalityKey");
               Z20SecFunctionalityDescription = cgiGet( "Z20SecFunctionalityDescription");
               Z21SecFunctionalityType = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z21SecFunctionalityType"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z19SecFunctionalityActive = StringUtil.StrToBool( cgiGet( "Z19SecFunctionalityActive"));
               Z14SecParentFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z14SecParentFunctionalityId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n14SecParentFunctionalityId = ((0==A14SecParentFunctionalityId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N14SecParentFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N14SecParentFunctionalityId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n14SecParentFunctionalityId = ((0==A14SecParentFunctionalityId) ? true : false);
               AV7SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vSECFUNCTIONALITYID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV12Insert_SecParentFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SECPARENTFUNCTIONALITYID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_SecParentFunctionalityId", StringUtil.LTrimStr( (decimal)(AV12Insert_SecParentFunctionalityId), 10, 0));
               A23SecParentFunctionalityDescript = cgiGet( "SECPARENTFUNCTIONALITYDESCRIPT");
               AV19Pgmname = cgiGet( "vPGMNAME");
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
               A13SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A13SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A13SecFunctionalityId), 10, 0));
               A15SecFunctionalityKey = cgiGet( edtSecFunctionalityKey_Internalname);
               AssignAttri("", false, "A15SecFunctionalityKey", A15SecFunctionalityKey);
               A20SecFunctionalityDescription = cgiGet( edtSecFunctionalityDescription_Internalname);
               AssignAttri("", false, "A20SecFunctionalityDescription", A20SecFunctionalityDescription);
               cmbSecFunctionalityType.CurrentValue = cgiGet( cmbSecFunctionalityType_Internalname);
               A21SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbSecFunctionalityType_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A21SecFunctionalityType", StringUtil.LTrimStr( (decimal)(A21SecFunctionalityType), 2, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtSecParentFunctionalityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecParentFunctionalityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECPARENTFUNCTIONALITYID");
                  AnyError = 1;
                  GX_FocusControl = edtSecParentFunctionalityId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A14SecParentFunctionalityId = 0;
                  n14SecParentFunctionalityId = false;
                  AssignAttri("", false, "A14SecParentFunctionalityId", StringUtil.LTrimStr( (decimal)(A14SecParentFunctionalityId), 10, 0));
               }
               else
               {
                  A14SecParentFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecParentFunctionalityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n14SecParentFunctionalityId = false;
                  AssignAttri("", false, "A14SecParentFunctionalityId", StringUtil.LTrimStr( (decimal)(A14SecParentFunctionalityId), 10, 0));
               }
               n14SecParentFunctionalityId = ((0==A14SecParentFunctionalityId) ? true : false);
               A19SecFunctionalityActive = StringUtil.StrToBool( cgiGet( edtSecFunctionalityActive_Internalname));
               AssignAttri("", false, "A19SecFunctionalityActive", A19SecFunctionalityActive);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"SecFunctionality");
               A13SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A13SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A13SecFunctionalityId), 10, 0));
               forbiddenHiddens.Add("SecFunctionalityId", context.localUtil.Format( (decimal)(A13SecFunctionalityId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_SecParentFunctionalityId", context.localUtil.Format( (decimal)(AV12Insert_SecParentFunctionalityId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A13SecFunctionalityId != Z13SecFunctionalityId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("wwpbaseobjects\\secfunctionality:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A13SecFunctionalityId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecFunctionalityId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A13SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A13SecFunctionalityId), 10, 0));
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
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode2;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SECFUNCTIONALITYID");
                        AnyError = 1;
                        GX_FocusControl = edtSecFunctionalityId_Internalname;
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
                           E11022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12022 ();
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
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
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
            DisableAttributes022( ) ;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV18WWPContext) ;
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Transactionname, AV19Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV20GXV1 = 1;
            AssignAttri("", false, "AV20GXV1", StringUtil.LTrimStr( (decimal)(AV20GXV1), 8, 0));
            while ( AV20GXV1 <= AV10TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV10TrnContext.gxTpr_Attributes.Item(AV20GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "SecParentFunctionalityId") == 0 )
               {
                  AV12Insert_SecParentFunctionalityId = (long)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_SecParentFunctionalityId", StringUtil.LTrimStr( (decimal)(AV12Insert_SecParentFunctionalityId), 10, 0));
               }
               AV20GXV1 = (int)(AV20GXV1+1);
               AssignAttri("", false, "AV20GXV1", StringUtil.LTrimStr( (decimal)(AV20GXV1), 8, 0));
            }
         }
         edtSecParentFunctionalityId_Visible = 0;
         AssignProp("", false, edtSecParentFunctionalityId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecParentFunctionalityId_Visible), 5, 0), true);
         edtSecFunctionalityActive_Visible = 0;
         AssignProp("", false, edtSecFunctionalityActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityActive_Visible), 5, 0), true);
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwpbaseobjects.secfunctionalityww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(1);
         pr_default.close(2);
         returnInSub = true;
         if (true) return;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z15SecFunctionalityKey = T00023_A15SecFunctionalityKey[0];
               Z20SecFunctionalityDescription = T00023_A20SecFunctionalityDescription[0];
               Z21SecFunctionalityType = T00023_A21SecFunctionalityType[0];
               Z19SecFunctionalityActive = T00023_A19SecFunctionalityActive[0];
               Z14SecParentFunctionalityId = T00023_A14SecParentFunctionalityId[0];
            }
            else
            {
               Z15SecFunctionalityKey = A15SecFunctionalityKey;
               Z20SecFunctionalityDescription = A20SecFunctionalityDescription;
               Z21SecFunctionalityType = A21SecFunctionalityType;
               Z19SecFunctionalityActive = A19SecFunctionalityActive;
               Z14SecParentFunctionalityId = A14SecParentFunctionalityId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z13SecFunctionalityId = A13SecFunctionalityId;
            Z15SecFunctionalityKey = A15SecFunctionalityKey;
            Z20SecFunctionalityDescription = A20SecFunctionalityDescription;
            Z21SecFunctionalityType = A21SecFunctionalityType;
            Z19SecFunctionalityActive = A19SecFunctionalityActive;
            Z14SecParentFunctionalityId = A14SecParentFunctionalityId;
            Z23SecParentFunctionalityDescript = A23SecParentFunctionalityDescript;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSecFunctionalityId_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), true);
         AV19Pgmname = "WWPBaseObjects.SecFunctionality";
         AssignAttri("", false, "AV19Pgmname", AV19Pgmname);
         imgprompt_14_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SECPARENTFUNCTIONALITYID"+"'), id:'"+"SECPARENTFUNCTIONALITYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtSecFunctionalityId_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SecFunctionalityId) )
         {
            A13SecFunctionalityId = AV7SecFunctionalityId;
            AssignAttri("", false, "A13SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A13SecFunctionalityId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SecParentFunctionalityId) )
         {
            edtSecParentFunctionalityId_Enabled = 0;
            AssignProp("", false, edtSecParentFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecParentFunctionalityId_Enabled), 5, 0), true);
         }
         else
         {
            edtSecParentFunctionalityId_Enabled = 1;
            AssignProp("", false, edtSecParentFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecParentFunctionalityId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SecParentFunctionalityId) )
         {
            A14SecParentFunctionalityId = AV12Insert_SecParentFunctionalityId;
            n14SecParentFunctionalityId = false;
            AssignAttri("", false, "A14SecParentFunctionalityId", StringUtil.LTrimStr( (decimal)(A14SecParentFunctionalityId), 10, 0));
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
            /* Using cursor T00024 */
            pr_default.execute(2, new Object[] {n14SecParentFunctionalityId, A14SecParentFunctionalityId});
            A23SecParentFunctionalityDescript = T00024_A23SecParentFunctionalityDescript[0];
            pr_default.close(2);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A13SecFunctionalityId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
            A15SecFunctionalityKey = T00025_A15SecFunctionalityKey[0];
            AssignAttri("", false, "A15SecFunctionalityKey", A15SecFunctionalityKey);
            A20SecFunctionalityDescription = T00025_A20SecFunctionalityDescription[0];
            AssignAttri("", false, "A20SecFunctionalityDescription", A20SecFunctionalityDescription);
            A21SecFunctionalityType = T00025_A21SecFunctionalityType[0];
            AssignAttri("", false, "A21SecFunctionalityType", StringUtil.LTrimStr( (decimal)(A21SecFunctionalityType), 2, 0));
            A23SecParentFunctionalityDescript = T00025_A23SecParentFunctionalityDescript[0];
            A19SecFunctionalityActive = T00025_A19SecFunctionalityActive[0];
            AssignAttri("", false, "A19SecFunctionalityActive", A19SecFunctionalityActive);
            A14SecParentFunctionalityId = T00025_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = T00025_n14SecParentFunctionalityId[0];
            AssignAttri("", false, "A14SecParentFunctionalityId", StringUtil.LTrimStr( (decimal)(A14SecParentFunctionalityId), 10, 0));
            ZM022( -9) ;
         }
         pr_default.close(3);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
      }

      protected void CheckExtendedTable022( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A15SecFunctionalityKey, A13SecFunctionalityId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Functionality Key", "")}), "DuplicateCandidateKey", 1, "SECFUNCTIONALITYKEY");
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityKey_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         if ( ! ( ( A21SecFunctionalityType == 1 ) || ( A21SecFunctionalityType == 2 ) || ( A21SecFunctionalityType == 3 ) || ( A21SecFunctionalityType == 4 ) || ( A21SecFunctionalityType == 5 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Functionality Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "SECFUNCTIONALITYTYPE");
            AnyError = 1;
            GX_FocusControl = cmbSecFunctionalityType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {n14SecParentFunctionalityId, A14SecParentFunctionalityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A14SecParentFunctionalityId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Sec Functionality Functionality", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECPARENTFUNCTIONALITYID");
               AnyError = 1;
               GX_FocusControl = edtSecParentFunctionalityId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A23SecParentFunctionalityDescript = T00024_A23SecParentFunctionalityDescript[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_11( long A14SecParentFunctionalityId )
      {
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {n14SecParentFunctionalityId, A14SecParentFunctionalityId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A14SecParentFunctionalityId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Sec Functionality Functionality", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECPARENTFUNCTIONALITYID");
               AnyError = 1;
               GX_FocusControl = edtSecParentFunctionalityId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A23SecParentFunctionalityDescript = T00027_A23SecParentFunctionalityDescript[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A23SecParentFunctionalityDescript)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void GetKey022( )
      {
         /* Using cursor T00028 */
         pr_default.execute(6, new Object[] {A13SecFunctionalityId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A13SecFunctionalityId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 9) ;
            RcdFound2 = 1;
            A13SecFunctionalityId = T00023_A13SecFunctionalityId[0];
            AssignAttri("", false, "A13SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A13SecFunctionalityId), 10, 0));
            A15SecFunctionalityKey = T00023_A15SecFunctionalityKey[0];
            AssignAttri("", false, "A15SecFunctionalityKey", A15SecFunctionalityKey);
            A20SecFunctionalityDescription = T00023_A20SecFunctionalityDescription[0];
            AssignAttri("", false, "A20SecFunctionalityDescription", A20SecFunctionalityDescription);
            A21SecFunctionalityType = T00023_A21SecFunctionalityType[0];
            AssignAttri("", false, "A21SecFunctionalityType", StringUtil.LTrimStr( (decimal)(A21SecFunctionalityType), 2, 0));
            A19SecFunctionalityActive = T00023_A19SecFunctionalityActive[0];
            AssignAttri("", false, "A19SecFunctionalityActive", A19SecFunctionalityActive);
            A14SecParentFunctionalityId = T00023_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = T00023_n14SecParentFunctionalityId[0];
            AssignAttri("", false, "A14SecParentFunctionalityId", StringUtil.LTrimStr( (decimal)(A14SecParentFunctionalityId), 10, 0));
            Z13SecFunctionalityId = A13SecFunctionalityId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T00029 */
         pr_default.execute(7, new Object[] {A13SecFunctionalityId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00029_A13SecFunctionalityId[0] < A13SecFunctionalityId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00029_A13SecFunctionalityId[0] > A13SecFunctionalityId ) ) )
            {
               A13SecFunctionalityId = T00029_A13SecFunctionalityId[0];
               AssignAttri("", false, "A13SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A13SecFunctionalityId), 10, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000210 */
         pr_default.execute(8, new Object[] {A13SecFunctionalityId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000210_A13SecFunctionalityId[0] > A13SecFunctionalityId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000210_A13SecFunctionalityId[0] < A13SecFunctionalityId ) ) )
            {
               A13SecFunctionalityId = T000210_A13SecFunctionalityId[0];
               AssignAttri("", false, "A13SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A13SecFunctionalityId), 10, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSecFunctionalityKey_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A13SecFunctionalityId != Z13SecFunctionalityId )
               {
                  A13SecFunctionalityId = Z13SecFunctionalityId;
                  AssignAttri("", false, "A13SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A13SecFunctionalityId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SECFUNCTIONALITYID");
                  AnyError = 1;
                  GX_FocusControl = edtSecFunctionalityId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSecFunctionalityKey_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtSecFunctionalityKey_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A13SecFunctionalityId != Z13SecFunctionalityId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSecFunctionalityKey_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SECFUNCTIONALITYID");
                     AnyError = 1;
                     GX_FocusControl = edtSecFunctionalityId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSecFunctionalityKey_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
         if ( A13SecFunctionalityId != Z13SecFunctionalityId )
         {
            A13SecFunctionalityId = Z13SecFunctionalityId;
            AssignAttri("", false, "A13SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A13SecFunctionalityId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SECFUNCTIONALITYID");
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSecFunctionalityKey_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A13SecFunctionalityId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecFunctionality"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z15SecFunctionalityKey, T00022_A15SecFunctionalityKey[0]) != 0 ) || ( StringUtil.StrCmp(Z20SecFunctionalityDescription, T00022_A20SecFunctionalityDescription[0]) != 0 ) || ( Z21SecFunctionalityType != T00022_A21SecFunctionalityType[0] ) || ( Z19SecFunctionalityActive != T00022_A19SecFunctionalityActive[0] ) || ( Z14SecParentFunctionalityId != T00022_A14SecParentFunctionalityId[0] ) )
            {
               if ( StringUtil.StrCmp(Z15SecFunctionalityKey, T00022_A15SecFunctionalityKey[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secfunctionality:[seudo value changed for attri]"+"SecFunctionalityKey");
                  GXUtil.WriteLogRaw("Old: ",Z15SecFunctionalityKey);
                  GXUtil.WriteLogRaw("Current: ",T00022_A15SecFunctionalityKey[0]);
               }
               if ( StringUtil.StrCmp(Z20SecFunctionalityDescription, T00022_A20SecFunctionalityDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secfunctionality:[seudo value changed for attri]"+"SecFunctionalityDescription");
                  GXUtil.WriteLogRaw("Old: ",Z20SecFunctionalityDescription);
                  GXUtil.WriteLogRaw("Current: ",T00022_A20SecFunctionalityDescription[0]);
               }
               if ( Z21SecFunctionalityType != T00022_A21SecFunctionalityType[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secfunctionality:[seudo value changed for attri]"+"SecFunctionalityType");
                  GXUtil.WriteLogRaw("Old: ",Z21SecFunctionalityType);
                  GXUtil.WriteLogRaw("Current: ",T00022_A21SecFunctionalityType[0]);
               }
               if ( Z19SecFunctionalityActive != T00022_A19SecFunctionalityActive[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secfunctionality:[seudo value changed for attri]"+"SecFunctionalityActive");
                  GXUtil.WriteLogRaw("Old: ",Z19SecFunctionalityActive);
                  GXUtil.WriteLogRaw("Current: ",T00022_A19SecFunctionalityActive[0]);
               }
               if ( Z14SecParentFunctionalityId != T00022_A14SecParentFunctionalityId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secfunctionality:[seudo value changed for attri]"+"SecParentFunctionalityId");
                  GXUtil.WriteLogRaw("Old: ",Z14SecParentFunctionalityId);
                  GXUtil.WriteLogRaw("Current: ",T00022_A14SecParentFunctionalityId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecFunctionality"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000211 */
                     pr_default.execute(9, new Object[] {A15SecFunctionalityKey, A20SecFunctionalityDescription, A21SecFunctionalityType, A19SecFunctionalityActive, n14SecParentFunctionalityId, A14SecParentFunctionalityId});
                     A13SecFunctionalityId = T000211_A13SecFunctionalityId[0];
                     AssignAttri("", false, "A13SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A13SecFunctionalityId), 10, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption020( ) ;
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000212 */
                     pr_default.execute(10, new Object[] {A15SecFunctionalityKey, A20SecFunctionalityDescription, A21SecFunctionalityType, A19SecFunctionalityActive, n14SecParentFunctionalityId, A14SecParentFunctionalityId, A13SecFunctionalityId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecFunctionality"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000213 */
                  pr_default.execute(11, new Object[] {A13SecFunctionalityId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000214 */
            pr_default.execute(12, new Object[] {n14SecParentFunctionalityId, A14SecParentFunctionalityId});
            A23SecParentFunctionalityDescript = T000214_A23SecParentFunctionalityDescript[0];
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000215 */
            pr_default.execute(13, new Object[] {A13SecFunctionalityId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Functionality", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000216 */
            pr_default.execute(14, new Object[] {A13SecFunctionalityId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Functionalities", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000217 */
            pr_default.execute(15, new Object[] {A13SecFunctionalityId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Functionality Role", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(12);
            context.CommitDataStores("wwpbaseobjects.secfunctionality",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(12);
            context.RollbackDataStores("wwpbaseobjects.secfunctionality",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000218 */
         pr_default.execute(16);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound2 = 1;
            A13SecFunctionalityId = T000218_A13SecFunctionalityId[0];
            AssignAttri("", false, "A13SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A13SecFunctionalityId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound2 = 1;
            A13SecFunctionalityId = T000218_A13SecFunctionalityId[0];
            AssignAttri("", false, "A13SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A13SecFunctionalityId), 10, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         edtSecFunctionalityId_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), true);
         edtSecFunctionalityKey_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityKey_Enabled), 5, 0), true);
         edtSecFunctionalityDescription_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityDescription_Enabled), 5, 0), true);
         cmbSecFunctionalityType.Enabled = 0;
         AssignProp("", false, cmbSecFunctionalityType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSecFunctionalityType.Enabled), 5, 0), true);
         edtSecParentFunctionalityId_Enabled = 0;
         AssignProp("", false, edtSecParentFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecParentFunctionalityId_Enabled), 5, 0), true);
         edtSecFunctionalityActive_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityActive_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
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
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SecFunctionalityId,10,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.secfunctionality.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"SecFunctionality");
         forbiddenHiddens.Add("SecFunctionalityId", context.localUtil.Format( (decimal)(A13SecFunctionalityId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_SecParentFunctionalityId", context.localUtil.Format( (decimal)(AV12Insert_SecParentFunctionalityId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wwpbaseobjects\\secfunctionality:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z13SecFunctionalityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13SecFunctionalityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z15SecFunctionalityKey", Z15SecFunctionalityKey);
         GxWebStd.gx_hidden_field( context, "Z20SecFunctionalityDescription", Z20SecFunctionalityDescription);
         GxWebStd.gx_hidden_field( context, "Z21SecFunctionalityType", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z21SecFunctionalityType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z19SecFunctionalityActive", Z19SecFunctionalityActive);
         GxWebStd.gx_hidden_field( context, "Z14SecParentFunctionalityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14SecParentFunctionalityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N14SecParentFunctionalityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14SecParentFunctionalityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vSECFUNCTIONALITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SecFunctionalityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECFUNCTIONALITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SecFunctionalityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SECPARENTFUNCTIONALITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_SecParentFunctionalityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SECPARENTFUNCTIONALITYDESCRIPT", A23SecParentFunctionalityDescript);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV19Pgmname));
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
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SecFunctionalityId,10,0));
         return formatLink("wwpbaseobjects.secfunctionality.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SecFunctionality" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Functionality", "") ;
      }

      protected void InitializeNonKey022( )
      {
         A14SecParentFunctionalityId = 0;
         n14SecParentFunctionalityId = false;
         AssignAttri("", false, "A14SecParentFunctionalityId", StringUtil.LTrimStr( (decimal)(A14SecParentFunctionalityId), 10, 0));
         n14SecParentFunctionalityId = ((0==A14SecParentFunctionalityId) ? true : false);
         A15SecFunctionalityKey = "";
         AssignAttri("", false, "A15SecFunctionalityKey", A15SecFunctionalityKey);
         A20SecFunctionalityDescription = "";
         AssignAttri("", false, "A20SecFunctionalityDescription", A20SecFunctionalityDescription);
         A21SecFunctionalityType = 0;
         AssignAttri("", false, "A21SecFunctionalityType", StringUtil.LTrimStr( (decimal)(A21SecFunctionalityType), 2, 0));
         A23SecParentFunctionalityDescript = "";
         AssignAttri("", false, "A23SecParentFunctionalityDescript", A23SecParentFunctionalityDescript);
         A19SecFunctionalityActive = false;
         AssignAttri("", false, "A19SecFunctionalityActive", A19SecFunctionalityActive);
         Z15SecFunctionalityKey = "";
         Z20SecFunctionalityDescription = "";
         Z21SecFunctionalityType = 0;
         Z19SecFunctionalityActive = false;
         Z14SecParentFunctionalityId = 0;
      }

      protected void InitAll022( )
      {
         A13SecFunctionalityId = 0;
         AssignAttri("", false, "A13SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A13SecFunctionalityId), 10, 0));
         InitializeNonKey022( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20268622275578", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/secfunctionality.js", "?20268622275578", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID";
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY";
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION";
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID";
         edtSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_14_Internalname = "PROMPT_14";
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
         Form.Caption = context.GetMessage( "Functionality", "");
         edtSecFunctionalityActive_Jsonclick = "";
         edtSecFunctionalityActive_Enabled = 1;
         edtSecFunctionalityActive_Visible = 1;
         imgprompt_14_Visible = 1;
         imgprompt_14_Link = "";
         edtSecParentFunctionalityId_Jsonclick = "";
         edtSecParentFunctionalityId_Enabled = 1;
         edtSecParentFunctionalityId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbSecFunctionalityType_Jsonclick = "";
         cmbSecFunctionalityType.Enabled = 1;
         edtSecFunctionalityDescription_Jsonclick = "";
         edtSecFunctionalityDescription_Enabled = 1;
         edtSecFunctionalityKey_Jsonclick = "";
         edtSecFunctionalityKey_Enabled = 1;
         edtSecFunctionalityId_Jsonclick = "";
         edtSecFunctionalityId_Enabled = 0;
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
         cmbSecFunctionalityType.Name = "SECFUNCTIONALITYTYPE";
         cmbSecFunctionalityType.WebTags = "";
         cmbSecFunctionalityType.addItem("1", context.GetMessage( "Mode", ""), 0);
         cmbSecFunctionalityType.addItem("2", context.GetMessage( "Action", ""), 0);
         cmbSecFunctionalityType.addItem("3", context.GetMessage( "Tab", ""), 0);
         cmbSecFunctionalityType.addItem("4", context.GetMessage( "Object", ""), 0);
         cmbSecFunctionalityType.addItem("5", context.GetMessage( "Attribute", ""), 0);
         if ( cmbSecFunctionalityType.ItemCount > 0 )
         {
            A21SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cmbSecFunctionalityType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A21SecFunctionalityType), 2, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A21SecFunctionalityType", StringUtil.LTrimStr( (decimal)(A21SecFunctionalityType), 2, 0));
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

      public void Valid_Secfunctionalitykey( )
      {
         /* Using cursor T000219 */
         pr_default.execute(17, new Object[] {A15SecFunctionalityKey, A13SecFunctionalityId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Functionality Key", "")}), "DuplicateCandidateKey", 1, "SECFUNCTIONALITYKEY");
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityKey_Internalname;
         }
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Secparentfunctionalityid( )
      {
         n14SecParentFunctionalityId = false;
         /* Using cursor T000214 */
         pr_default.execute(12, new Object[] {n14SecParentFunctionalityId, A14SecParentFunctionalityId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A14SecParentFunctionalityId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Sec Functionality Functionality", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECPARENTFUNCTIONALITYID");
               AnyError = 1;
               GX_FocusControl = edtSecParentFunctionalityId_Internalname;
            }
         }
         A23SecParentFunctionalityDescript = T000214_A23SecParentFunctionalityDescript[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A23SecParentFunctionalityDescript", A23SecParentFunctionalityDescript);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7SecFunctionalityId',fld:'vSECFUNCTIONALITYID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7SecFunctionalityId',fld:'vSECFUNCTIONALITYID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'A13SecFunctionalityId',fld:'SECFUNCTIONALITYID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV12Insert_SecParentFunctionalityId',fld:'vINSERT_SECPARENTFUNCTIONALITYID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12022',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_SECFUNCTIONALITYID","{handler:'Valid_Secfunctionalityid',iparms:[]");
         setEventMetadata("VALID_SECFUNCTIONALITYID",",oparms:[]}");
         setEventMetadata("VALID_SECFUNCTIONALITYKEY","{handler:'Valid_Secfunctionalitykey',iparms:[{av:'A15SecFunctionalityKey',fld:'SECFUNCTIONALITYKEY',pic:'',type:'svchar'},{av:'A13SecFunctionalityId',fld:'SECFUNCTIONALITYID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_SECFUNCTIONALITYKEY",",oparms:[]}");
         setEventMetadata("VALID_SECFUNCTIONALITYTYPE","{handler:'Valid_Secfunctionalitytype',iparms:[]");
         setEventMetadata("VALID_SECFUNCTIONALITYTYPE",",oparms:[]}");
         setEventMetadata("VALID_SECPARENTFUNCTIONALITYID","{handler:'Valid_Secparentfunctionalityid',iparms:[{av:'A14SecParentFunctionalityId',fld:'SECPARENTFUNCTIONALITYID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A23SecParentFunctionalityDescript',fld:'SECPARENTFUNCTIONALITYDESCRIPT',pic:'',type:'svchar'}]");
         setEventMetadata("VALID_SECPARENTFUNCTIONALITYID",",oparms:[{av:'A23SecParentFunctionalityDescript',fld:'SECPARENTFUNCTIONALITYDESCRIPT',pic:'',type:'svchar'}]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z15SecFunctionalityKey = "";
         Z20SecFunctionalityDescription = "";
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
         A15SecFunctionalityKey = "";
         A20SecFunctionalityDescription = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         imgprompt_14_gximage = "";
         sImgUrl = "";
         A23SecParentFunctionalityDescript = "";
         AV19Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV18WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         AV13TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z23SecParentFunctionalityDescript = "";
         T00024_A23SecParentFunctionalityDescript = new string[] {""} ;
         T00025_A13SecFunctionalityId = new long[1] ;
         T00025_A15SecFunctionalityKey = new string[] {""} ;
         T00025_A20SecFunctionalityDescription = new string[] {""} ;
         T00025_A21SecFunctionalityType = new short[1] ;
         T00025_A23SecParentFunctionalityDescript = new string[] {""} ;
         T00025_A19SecFunctionalityActive = new bool[] {false} ;
         T00025_A14SecParentFunctionalityId = new long[1] ;
         T00025_n14SecParentFunctionalityId = new bool[] {false} ;
         T00026_A15SecFunctionalityKey = new string[] {""} ;
         T00027_A23SecParentFunctionalityDescript = new string[] {""} ;
         T00028_A13SecFunctionalityId = new long[1] ;
         T00023_A13SecFunctionalityId = new long[1] ;
         T00023_A15SecFunctionalityKey = new string[] {""} ;
         T00023_A20SecFunctionalityDescription = new string[] {""} ;
         T00023_A21SecFunctionalityType = new short[1] ;
         T00023_A19SecFunctionalityActive = new bool[] {false} ;
         T00023_A14SecParentFunctionalityId = new long[1] ;
         T00023_n14SecParentFunctionalityId = new bool[] {false} ;
         T00029_A13SecFunctionalityId = new long[1] ;
         T000210_A13SecFunctionalityId = new long[1] ;
         T00022_A13SecFunctionalityId = new long[1] ;
         T00022_A15SecFunctionalityKey = new string[] {""} ;
         T00022_A20SecFunctionalityDescription = new string[] {""} ;
         T00022_A21SecFunctionalityType = new short[1] ;
         T00022_A19SecFunctionalityActive = new bool[] {false} ;
         T00022_A14SecParentFunctionalityId = new long[1] ;
         T00022_n14SecParentFunctionalityId = new bool[] {false} ;
         T000211_A13SecFunctionalityId = new long[1] ;
         T000214_A23SecParentFunctionalityDescript = new string[] {""} ;
         T000215_A14SecParentFunctionalityId = new long[1] ;
         T000215_n14SecParentFunctionalityId = new bool[] {false} ;
         T000216_A17SecObjectName = new string[] {""} ;
         T000216_A13SecFunctionalityId = new long[1] ;
         T000217_A13SecFunctionalityId = new long[1] ;
         T000217_A16SecRoleId = new short[1] ;
         T000218_A13SecFunctionalityId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T000219_A15SecFunctionalityKey = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionality__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionality__default(),
            new Object[][] {
                new Object[] {
               T00022_A13SecFunctionalityId, T00022_A15SecFunctionalityKey, T00022_A20SecFunctionalityDescription, T00022_A21SecFunctionalityType, T00022_A19SecFunctionalityActive, T00022_A14SecParentFunctionalityId, T00022_n14SecParentFunctionalityId
               }
               , new Object[] {
               T00023_A13SecFunctionalityId, T00023_A15SecFunctionalityKey, T00023_A20SecFunctionalityDescription, T00023_A21SecFunctionalityType, T00023_A19SecFunctionalityActive, T00023_A14SecParentFunctionalityId, T00023_n14SecParentFunctionalityId
               }
               , new Object[] {
               T00024_A23SecParentFunctionalityDescript
               }
               , new Object[] {
               T00025_A13SecFunctionalityId, T00025_A15SecFunctionalityKey, T00025_A20SecFunctionalityDescription, T00025_A21SecFunctionalityType, T00025_A23SecParentFunctionalityDescript, T00025_A19SecFunctionalityActive, T00025_A14SecParentFunctionalityId, T00025_n14SecParentFunctionalityId
               }
               , new Object[] {
               T00026_A15SecFunctionalityKey
               }
               , new Object[] {
               T00027_A23SecParentFunctionalityDescript
               }
               , new Object[] {
               T00028_A13SecFunctionalityId
               }
               , new Object[] {
               T00029_A13SecFunctionalityId
               }
               , new Object[] {
               T000210_A13SecFunctionalityId
               }
               , new Object[] {
               T000211_A13SecFunctionalityId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000214_A23SecParentFunctionalityDescript
               }
               , new Object[] {
               T000215_A14SecParentFunctionalityId
               }
               , new Object[] {
               T000216_A17SecObjectName, T000216_A13SecFunctionalityId
               }
               , new Object[] {
               T000217_A13SecFunctionalityId, T000217_A16SecRoleId
               }
               , new Object[] {
               T000218_A13SecFunctionalityId
               }
               , new Object[] {
               T000219_A15SecFunctionalityKey
               }
            }
         );
         AV19Pgmname = "WWPBaseObjects.SecFunctionality";
      }

      private short Z21SecFunctionalityType ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A21SecFunctionalityType ;
      private short RcdFound2 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtSecFunctionalityId_Enabled ;
      private int edtSecFunctionalityKey_Enabled ;
      private int edtSecFunctionalityDescription_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtSecParentFunctionalityId_Visible ;
      private int edtSecParentFunctionalityId_Enabled ;
      private int imgprompt_14_Visible ;
      private int edtSecFunctionalityActive_Visible ;
      private int edtSecFunctionalityActive_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV20GXV1 ;
      private int idxLst ;
      private long wcpOAV7SecFunctionalityId ;
      private long Z13SecFunctionalityId ;
      private long Z14SecParentFunctionalityId ;
      private long N14SecParentFunctionalityId ;
      private long A14SecParentFunctionalityId ;
      private long AV7SecFunctionalityId ;
      private long A13SecFunctionalityId ;
      private long AV12Insert_SecParentFunctionalityId ;
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
      private string edtSecFunctionalityKey_Internalname ;
      private string cmbSecFunctionalityType_Internalname ;
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
      private string edtSecFunctionalityId_Internalname ;
      private string TempTags ;
      private string edtSecFunctionalityId_Jsonclick ;
      private string edtSecFunctionalityKey_Jsonclick ;
      private string edtSecFunctionalityDescription_Internalname ;
      private string edtSecFunctionalityDescription_Jsonclick ;
      private string cmbSecFunctionalityType_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtSecParentFunctionalityId_Internalname ;
      private string edtSecParentFunctionalityId_Jsonclick ;
      private string imgprompt_14_gximage ;
      private string sImgUrl ;
      private string imgprompt_14_Internalname ;
      private string imgprompt_14_Link ;
      private string edtSecFunctionalityActive_Internalname ;
      private string edtSecFunctionalityActive_Jsonclick ;
      private string AV19Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode2 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool Z19SecFunctionalityActive ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n14SecParentFunctionalityId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A19SecFunctionalityActive ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string Z15SecFunctionalityKey ;
      private string Z20SecFunctionalityDescription ;
      private string A15SecFunctionalityKey ;
      private string A20SecFunctionalityDescription ;
      private string A23SecParentFunctionalityDescript ;
      private string Z23SecParentFunctionalityDescript ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbSecFunctionalityType ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV18WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00024_A23SecParentFunctionalityDescript ;
      private long[] T00025_A13SecFunctionalityId ;
      private string[] T00025_A15SecFunctionalityKey ;
      private string[] T00025_A20SecFunctionalityDescription ;
      private short[] T00025_A21SecFunctionalityType ;
      private string[] T00025_A23SecParentFunctionalityDescript ;
      private bool[] T00025_A19SecFunctionalityActive ;
      private long[] T00025_A14SecParentFunctionalityId ;
      private bool[] T00025_n14SecParentFunctionalityId ;
      private string[] T00026_A15SecFunctionalityKey ;
      private string[] T00027_A23SecParentFunctionalityDescript ;
      private long[] T00028_A13SecFunctionalityId ;
      private long[] T00023_A13SecFunctionalityId ;
      private string[] T00023_A15SecFunctionalityKey ;
      private string[] T00023_A20SecFunctionalityDescription ;
      private short[] T00023_A21SecFunctionalityType ;
      private bool[] T00023_A19SecFunctionalityActive ;
      private long[] T00023_A14SecParentFunctionalityId ;
      private bool[] T00023_n14SecParentFunctionalityId ;
      private long[] T00029_A13SecFunctionalityId ;
      private long[] T000210_A13SecFunctionalityId ;
      private long[] T00022_A13SecFunctionalityId ;
      private string[] T00022_A15SecFunctionalityKey ;
      private string[] T00022_A20SecFunctionalityDescription ;
      private short[] T00022_A21SecFunctionalityType ;
      private bool[] T00022_A19SecFunctionalityActive ;
      private long[] T00022_A14SecParentFunctionalityId ;
      private bool[] T00022_n14SecParentFunctionalityId ;
      private long[] T000211_A13SecFunctionalityId ;
      private string[] T000214_A23SecParentFunctionalityDescript ;
      private long[] T000215_A14SecParentFunctionalityId ;
      private bool[] T000215_n14SecParentFunctionalityId ;
      private string[] T000216_A17SecObjectName ;
      private long[] T000216_A13SecFunctionalityId ;
      private long[] T000217_A13SecFunctionalityId ;
      private short[] T000217_A16SecRoleId ;
      private long[] T000218_A13SecFunctionalityId ;
      private string[] T000219_A15SecFunctionalityKey ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class secfunctionality__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class secfunctionality__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00022;
        prmT00022 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT00023;
        prmT00023 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT00024;
        prmT00024 = new Object[] {
        new ParDef("@SecParentFunctionalityId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT00025;
        prmT00025 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT00026;
        prmT00026 = new Object[] {
        new ParDef("@SecFunctionalityKey",GXType.NVarChar,100,0) ,
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT00027;
        prmT00027 = new Object[] {
        new ParDef("@SecParentFunctionalityId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT00028;
        prmT00028 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT00029;
        prmT00029 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT000210;
        prmT000210 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT000211;
        prmT000211 = new Object[] {
        new ParDef("@SecFunctionalityKey",GXType.NVarChar,100,0) ,
        new ParDef("@SecFunctionalityDescription",GXType.NVarChar,100,0) ,
        new ParDef("@SecFunctionalityType",GXType.Int16,2,0) ,
        new ParDef("@SecFunctionalityActive",GXType.Boolean,4,0) ,
        new ParDef("@SecParentFunctionalityId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000212;
        prmT000212 = new Object[] {
        new ParDef("@SecFunctionalityKey",GXType.NVarChar,100,0) ,
        new ParDef("@SecFunctionalityDescription",GXType.NVarChar,100,0) ,
        new ParDef("@SecFunctionalityType",GXType.Int16,2,0) ,
        new ParDef("@SecFunctionalityActive",GXType.Boolean,4,0) ,
        new ParDef("@SecParentFunctionalityId",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT000213;
        prmT000213 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT000214;
        prmT000214 = new Object[] {
        new ParDef("@SecParentFunctionalityId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmT000215;
        prmT000215 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT000216;
        prmT000216 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT000217;
        prmT000217 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmT000218;
        prmT000218 = new Object[] {
        };
        Object[] prmT000219;
        prmT000219 = new Object[] {
        new ParDef("@SecFunctionalityKey",GXType.NVarChar,100,0) ,
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00022", "SELECT [SecFunctionalityId], [SecFunctionalityKey], [SecFunctionalityDescription], [SecFunctionalityType], [SecFunctionalityActive], [SecParentFunctionalityId] AS SecParentFunctionalityId FROM [SecFunctionality] WITH (UPDLOCK) WHERE [SecFunctionalityId] = @SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00023", "SELECT [SecFunctionalityId], [SecFunctionalityKey], [SecFunctionalityDescription], [SecFunctionalityType], [SecFunctionalityActive], [SecParentFunctionalityId] AS SecParentFunctionalityId FROM [SecFunctionality] WHERE [SecFunctionalityId] = @SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00024", "SELECT [SecFunctionalityDescription] AS SecParentFunctionalityDescript FROM [SecFunctionality] WHERE [SecFunctionalityId] = @SecParentFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00025", "SELECT TM1.[SecFunctionalityId], TM1.[SecFunctionalityKey], TM1.[SecFunctionalityDescription], TM1.[SecFunctionalityType], T2.[SecFunctionalityDescription] AS SecParentFunctionalityDescript, TM1.[SecFunctionalityActive], TM1.[SecParentFunctionalityId] AS SecParentFunctionalityId FROM ([SecFunctionality] TM1 LEFT JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = TM1.[SecParentFunctionalityId]) WHERE TM1.[SecFunctionalityId] = @SecFunctionalityId ORDER BY TM1.[SecFunctionalityId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00026", "SELECT [SecFunctionalityKey] FROM [SecFunctionality] WHERE ([SecFunctionalityKey] = @SecFunctionalityKey) AND (Not ( [SecFunctionalityId] = @SecFunctionalityId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00027", "SELECT [SecFunctionalityDescription] AS SecParentFunctionalityDescript FROM [SecFunctionality] WHERE [SecFunctionalityId] = @SecParentFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00028", "SELECT [SecFunctionalityId] FROM [SecFunctionality] WHERE [SecFunctionalityId] = @SecFunctionalityId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00029", "SELECT TOP 1 [SecFunctionalityId] FROM [SecFunctionality] WHERE ( [SecFunctionalityId] > @SecFunctionalityId) ORDER BY [SecFunctionalityId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000210", "SELECT TOP 1 [SecFunctionalityId] FROM [SecFunctionality] WHERE ( [SecFunctionalityId] < @SecFunctionalityId) ORDER BY [SecFunctionalityId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000211", "INSERT INTO [SecFunctionality]([SecFunctionalityKey], [SecFunctionalityDescription], [SecFunctionalityType], [SecFunctionalityActive], [SecParentFunctionalityId]) VALUES(@SecFunctionalityKey, @SecFunctionalityDescription, @SecFunctionalityType, @SecFunctionalityActive, @SecParentFunctionalityId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000212", "UPDATE [SecFunctionality] SET [SecFunctionalityKey]=@SecFunctionalityKey, [SecFunctionalityDescription]=@SecFunctionalityDescription, [SecFunctionalityType]=@SecFunctionalityType, [SecFunctionalityActive]=@SecFunctionalityActive, [SecParentFunctionalityId]=@SecParentFunctionalityId  WHERE [SecFunctionalityId] = @SecFunctionalityId", GxErrorMask.GX_NOMASK,prmT000212)
           ,new CursorDef("T000213", "DELETE FROM [SecFunctionality]  WHERE [SecFunctionalityId] = @SecFunctionalityId", GxErrorMask.GX_NOMASK,prmT000213)
           ,new CursorDef("T000214", "SELECT [SecFunctionalityDescription] AS SecParentFunctionalityDescript FROM [SecFunctionality] WHERE [SecFunctionalityId] = @SecParentFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000215", "SELECT TOP 1 [SecFunctionalityId] AS SecParentFunctionalityId FROM [SecFunctionality] WHERE [SecParentFunctionalityId] = @SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000215,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000216", "SELECT TOP 1 [SecObjectName], [SecFunctionalityId] FROM [SecObjectFunctionalities] WHERE [SecFunctionalityId] = @SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000216,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000217", "SELECT TOP 1 [SecFunctionalityId], [SecRoleId] FROM [SecFunctionalityRole] WHERE [SecFunctionalityId] = @SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000218", "SELECT [SecFunctionalityId] FROM [SecFunctionality] ORDER BY [SecFunctionalityId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000218,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000219", "SELECT [SecFunctionalityKey] FROM [SecFunctionality] WHERE ([SecFunctionalityKey] = @SecFunctionalityKey) AND (Not ( [SecFunctionalityId] = @SecFunctionalityId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000219,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
