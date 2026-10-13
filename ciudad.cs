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
   public class ciudad : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel1"+"_"+"CIUDADID") == 0 )
         {
            A116PaisID = GetPar( "PaisID");
            AssignAttri("", false, "A116PaisID", A116PaisID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX1ASACIUDADID0Z40( A116PaisID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A116PaisID = GetPar( "PaisID");
            AssignAttri("", false, "A116PaisID", A116PaisID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A116PaisID) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "ciudad.aspx")), "ciudad.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "ciudad.aspx")))) ;
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
                  AV7CiudadId = (long)(Math.Round(NumberUtil.Val( GetPar( "CiudadId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7CiudadId", StringUtil.LTrimStr( (decimal)(AV7CiudadId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCIUDADID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CiudadId), "ZZZZZZZZZZZZZZZZZ9"), context));
                  AV8PaisID = GetPar( "PaisID");
                  AssignAttri("", false, "AV8PaisID", AV8PaisID);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPAISID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8PaisID, "")), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Ciudad", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCiudadId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public ciudad( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ciudad( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_CiudadId ,
                           string aP2_PaisID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CiudadId = aP1_CiudadId;
         this.AV8PaisID = aP2_PaisID;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCiudadId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCiudadId_Internalname, context.GetMessage( "Ciudad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCiudadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A144CiudadId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A144CiudadId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCiudadId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCiudadId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Ciudad.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisID_Internalname, context.GetMessage( "PaisId", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.RTrim( A116PaisID), StringUtil.RTrim( context.localUtil.Format( A116PaisID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPaisID_Enabled, 1, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Ciudad.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_116_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_116_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_116_Internalname, sImgUrl, imgprompt_116_Link, "", "", context.GetTheme( ), imgprompt_116_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Ciudad.htm");
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
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisNombre_Internalname, context.GetMessage( "Pais", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisNombre_Internalname, StringUtil.RTrim( A165PaisNombre), StringUtil.RTrim( context.localUtil.Format( A165PaisNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPaisNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Ciudad.htm");
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
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Bandera", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A207PaisBandera_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000PaisBandera_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.PathToRelativeUrl( A207PaisBandera));
         GxWebStd.gx_bitmap( context, imgPaisBandera_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgPaisBandera_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", "", "", 0, A207PaisBandera_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_Ciudad.htm");
         AssignProp("", false, imgPaisBandera_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.PathToRelativeUrl( A207PaisBandera)), true);
         AssignProp("", false, imgPaisBandera_Internalname, "IsBlob", StringUtil.BoolToStr( A207PaisBandera_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCiudadNombre_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCiudadNombre_Internalname, StringUtil.RTrim( A208CiudadNombre), StringUtil.RTrim( context.localUtil.Format( A208CiudadNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCiudadNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCiudadNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Ciudad.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgCiudadImagen1_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A209CiudadImagen1_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A209CiudadImagen1))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001CiudadImagen1_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A209CiudadImagen1)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A209CiudadImagen1)) ? A40001CiudadImagen1_GXI : context.PathToRelativeUrl( A209CiudadImagen1));
         GxWebStd.gx_bitmap( context, imgCiudadImagen1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgCiudadImagen1_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", "", "", 0, A209CiudadImagen1_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_Ciudad.htm");
         AssignProp("", false, imgCiudadImagen1_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A209CiudadImagen1)) ? A40001CiudadImagen1_GXI : context.PathToRelativeUrl( A209CiudadImagen1)), true);
         AssignProp("", false, imgCiudadImagen1_Internalname, "IsBlob", StringUtil.BoolToStr( A209CiudadImagen1_IsBlob), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ciudad.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ciudad.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ciudad.htm");
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
         E110Z2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z144CiudadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z144CiudadId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z116PaisID = cgiGet( "Z116PaisID");
               Z208CiudadNombre = cgiGet( "Z208CiudadNombre");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7CiudadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCIUDADID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV8PaisID = cgiGet( "vPAISID");
               A40001CiudadImagen1_GXI = cgiGet( "CIUDADIMAGEN1_GXI");
               A40000PaisBandera_GXI = cgiGet( "PAISBANDERA_GXI");
               AV16Pgmname = cgiGet( "vPGMNAME");
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtCiudadId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCiudadId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CIUDADID");
                  AnyError = 1;
                  GX_FocusControl = edtCiudadId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A144CiudadId = 0;
                  AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
               }
               else
               {
                  A144CiudadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCiudadId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
               }
               A116PaisID = cgiGet( edtPaisID_Internalname);
               AssignAttri("", false, "A116PaisID", A116PaisID);
               A165PaisNombre = cgiGet( edtPaisNombre_Internalname);
               AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
               A207PaisBandera = cgiGet( imgPaisBandera_Internalname);
               AssignAttri("", false, "A207PaisBandera", A207PaisBandera);
               A208CiudadNombre = cgiGet( edtCiudadNombre_Internalname);
               AssignAttri("", false, "A208CiudadNombre", A208CiudadNombre);
               A209CiudadImagen1 = cgiGet( imgCiudadImagen1_Internalname);
               AssignAttri("", false, "A209CiudadImagen1", A209CiudadImagen1);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgPaisBandera_Internalname, ref  A207PaisBandera, ref  A40000PaisBandera_GXI);
               getMultimediaValue(imgCiudadImagen1_Internalname, ref  A209CiudadImagen1, ref  A40001CiudadImagen1_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Ciudad");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A144CiudadId != Z144CiudadId ) || ( StringUtil.StrCmp(A116PaisID, Z116PaisID) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("ciudad:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A144CiudadId = (long)(Math.Round(NumberUtil.Val( GetPar( "CiudadId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
                  A116PaisID = GetPar( "PaisID");
                  AssignAttri("", false, "A116PaisID", A116PaisID);
                  getEqualNoModal( ) ;
                  if ( ! (0==AV7CiudadId) )
                  {
                     A144CiudadId = AV7CiudadId;
                     AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
                  }
                  else
                  {
                     if ( IsIns( )  && true /* After */ && String.IsNullOrEmpty(StringUtil.RTrim( AV8PaisID)) )
                     {
                        GXt_int1 = A144CiudadId;
                        new oautonumrciudad(context ).execute(  A116PaisID, out  GXt_int1) ;
                        A144CiudadId = GXt_int1;
                        AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  standaloneModal( ) ;
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
                           E110Z2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120Z2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'ENUMERAR'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'Enumerar' */
                           E130Z2 ();
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
            E120Z2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0Z40( ) ;
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
            DisableAttributes0Z40( ) ;
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

      protected void CONFIRM_0Z0( )
      {
         BeforeValidate0Z40( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Z40( ) ;
            }
            else
            {
               CheckExtendedTable0Z40( ) ;
               CloseExtendedTableCursors0Z40( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0Z0( )
      {
      }

      protected void E110Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV14WWPContext) ;
         AV10IsAuthorized = true;
         AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean2 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCiudad_Insert", out  GXt_boolean2) ;
            AV10IsAuthorized = GXt_boolean2;
            AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean2 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCiudad_Update", out  GXt_boolean2) ;
            AV10IsAuthorized = GXt_boolean2;
            AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean2 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCiudad_Delete", out  GXt_boolean2) ;
            AV10IsAuthorized = GXt_boolean2;
            AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         }
         if ( ! AV10IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV16Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E120Z2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("ciudadww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E130Z2( )
      {
         /* 'Enumerar' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A116PaisID)) )
         {
            GX_msglist.addItem(context.GetMessage( "Seleccione un pais valido", ""));
         }
         else
         {
            new oautonumrciudad(context ).execute(  A116PaisID, out  A144CiudadId) ;
            AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
         }
         /*  Sending Event outputs  */
      }

      protected void ZM0Z40( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z208CiudadNombre = T000Z3_A208CiudadNombre[0];
            }
            else
            {
               Z208CiudadNombre = A208CiudadNombre;
            }
         }
         if ( GX_JID == -8 )
         {
            Z144CiudadId = A144CiudadId;
            Z208CiudadNombre = A208CiudadNombre;
            Z209CiudadImagen1 = A209CiudadImagen1;
            Z40001CiudadImagen1_GXI = A40001CiudadImagen1_GXI;
            Z116PaisID = A116PaisID;
            Z165PaisNombre = A165PaisNombre;
            Z207PaisBandera = A207PaisBandera;
            Z40000PaisBandera_GXI = A40000PaisBandera_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_116_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"paisprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISID"+"'), id:'"+"PAISID"+"'"+",IOType:'inout',isKey:true,isLastKey:true}"+","+"{Ctrl:gx.dom.el('"+"PAISNOMBRE"+"'), id:'"+"PAISNOMBRE"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CiudadId) )
         {
            edtCiudadId_Enabled = 0;
            AssignProp("", false, edtCiudadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadId_Enabled), 5, 0), true);
         }
         else
         {
            edtCiudadId_Enabled = 1;
            AssignProp("", false, edtCiudadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7CiudadId) )
         {
            edtCiudadId_Enabled = 0;
            AssignProp("", false, edtCiudadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadId_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8PaisID)) )
         {
            A116PaisID = AV8PaisID;
            AssignAttri("", false, "A116PaisID", A116PaisID);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8PaisID)) )
         {
            edtPaisID_Enabled = 0;
            AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         }
         else
         {
            edtPaisID_Enabled = 1;
            AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8PaisID)) )
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
            AV16Pgmname = "Ciudad";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T000Z4 */
            pr_default.execute(2, new Object[] {A116PaisID});
            A165PaisNombre = T000Z4_A165PaisNombre[0];
            AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
            A40000PaisBandera_GXI = T000Z4_A40000PaisBandera_GXI[0];
            AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
            AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
            A207PaisBandera = T000Z4_A207PaisBandera[0];
            AssignAttri("", false, "A207PaisBandera", A207PaisBandera);
            AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
            AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
            pr_default.close(2);
         }
      }

      protected void Load0Z40( )
      {
         /* Using cursor T000Z5 */
         pr_default.execute(3, new Object[] {A144CiudadId, A116PaisID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound40 = 1;
            A165PaisNombre = T000Z5_A165PaisNombre[0];
            AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
            A40000PaisBandera_GXI = T000Z5_A40000PaisBandera_GXI[0];
            AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
            AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
            A208CiudadNombre = T000Z5_A208CiudadNombre[0];
            AssignAttri("", false, "A208CiudadNombre", A208CiudadNombre);
            A40001CiudadImagen1_GXI = T000Z5_A40001CiudadImagen1_GXI[0];
            AssignProp("", false, imgCiudadImagen1_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A209CiudadImagen1)) ? A40001CiudadImagen1_GXI : context.convertURL( context.PathToRelativeUrl( A209CiudadImagen1))), true);
            AssignProp("", false, imgCiudadImagen1_Internalname, "SrcSet", context.GetImageSrcSet( A209CiudadImagen1), true);
            A207PaisBandera = T000Z5_A207PaisBandera[0];
            AssignAttri("", false, "A207PaisBandera", A207PaisBandera);
            AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
            AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
            A209CiudadImagen1 = T000Z5_A209CiudadImagen1[0];
            AssignAttri("", false, "A209CiudadImagen1", A209CiudadImagen1);
            AssignProp("", false, imgCiudadImagen1_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A209CiudadImagen1)) ? A40001CiudadImagen1_GXI : context.convertURL( context.PathToRelativeUrl( A209CiudadImagen1))), true);
            AssignProp("", false, imgCiudadImagen1_Internalname, "SrcSet", context.GetImageSrcSet( A209CiudadImagen1), true);
            ZM0Z40( -8) ;
         }
         pr_default.close(3);
         OnLoadActions0Z40( ) ;
      }

      protected void OnLoadActions0Z40( )
      {
         AV16Pgmname = "Ciudad";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         if ( ! (0==AV7CiudadId) )
         {
            A144CiudadId = AV7CiudadId;
            AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
         }
         else
         {
            if ( IsIns( )  && true /* After */ && String.IsNullOrEmpty(StringUtil.RTrim( AV8PaisID)) )
            {
               GXt_int1 = A144CiudadId;
               new oautonumrciudad(context ).execute(  A116PaisID, out  GXt_int1) ;
               A144CiudadId = GXt_int1;
               AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
            }
         }
      }

      protected void CheckExtendedTable0Z40( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV16Pgmname = "Ciudad";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         if ( (0==A144CiudadId) && IsIns( )  && true /* After */ )
         {
            GX_msglist.addItem(context.GetMessage( "Ingrese un ciudad", ""), 1, "CIUDADID");
            AnyError = 1;
            GX_FocusControl = edtCiudadId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000Z4 */
         pr_default.execute(2, new Object[] {A116PaisID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A165PaisNombre = T000Z4_A165PaisNombre[0];
         AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
         A40000PaisBandera_GXI = T000Z4_A40000PaisBandera_GXI[0];
         AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
         AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
         A207PaisBandera = T000Z4_A207PaisBandera[0];
         AssignAttri("", false, "A207PaisBandera", A207PaisBandera);
         AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
         AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
         pr_default.close(2);
         if ( ! (0==AV7CiudadId) )
         {
            A144CiudadId = AV7CiudadId;
            AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
         }
         else
         {
            if ( IsIns( )  && true /* After */ && String.IsNullOrEmpty(StringUtil.RTrim( AV8PaisID)) )
            {
               GXt_int1 = A144CiudadId;
               new oautonumrciudad(context ).execute(  A116PaisID, out  GXt_int1) ;
               A144CiudadId = GXt_int1;
               AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
            }
         }
      }

      protected void CloseExtendedTableCursors0Z40( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( string A116PaisID )
      {
         /* Using cursor T000Z6 */
         pr_default.execute(4, new Object[] {A116PaisID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A165PaisNombre = T000Z6_A165PaisNombre[0];
         AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
         A40000PaisBandera_GXI = T000Z6_A40000PaisBandera_GXI[0];
         AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
         AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
         A207PaisBandera = T000Z6_A207PaisBandera[0];
         AssignAttri("", false, "A207PaisBandera", A207PaisBandera);
         AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
         AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A165PaisNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( A207PaisBandera)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000PaisBandera_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0Z40( )
      {
         /* Using cursor T000Z7 */
         pr_default.execute(5, new Object[] {A144CiudadId, A116PaisID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound40 = 1;
         }
         else
         {
            RcdFound40 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Z3 */
         pr_default.execute(1, new Object[] {A144CiudadId, A116PaisID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Z40( 8) ;
            RcdFound40 = 1;
            A144CiudadId = T000Z3_A144CiudadId[0];
            AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
            A208CiudadNombre = T000Z3_A208CiudadNombre[0];
            AssignAttri("", false, "A208CiudadNombre", A208CiudadNombre);
            A40001CiudadImagen1_GXI = T000Z3_A40001CiudadImagen1_GXI[0];
            AssignProp("", false, imgCiudadImagen1_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A209CiudadImagen1)) ? A40001CiudadImagen1_GXI : context.convertURL( context.PathToRelativeUrl( A209CiudadImagen1))), true);
            AssignProp("", false, imgCiudadImagen1_Internalname, "SrcSet", context.GetImageSrcSet( A209CiudadImagen1), true);
            A116PaisID = T000Z3_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
            A209CiudadImagen1 = T000Z3_A209CiudadImagen1[0];
            AssignAttri("", false, "A209CiudadImagen1", A209CiudadImagen1);
            AssignProp("", false, imgCiudadImagen1_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A209CiudadImagen1)) ? A40001CiudadImagen1_GXI : context.convertURL( context.PathToRelativeUrl( A209CiudadImagen1))), true);
            AssignProp("", false, imgCiudadImagen1_Internalname, "SrcSet", context.GetImageSrcSet( A209CiudadImagen1), true);
            Z144CiudadId = A144CiudadId;
            Z116PaisID = A116PaisID;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Z40( ) ;
            if ( AnyError == 1 )
            {
               RcdFound40 = 0;
               InitializeNonKey0Z40( ) ;
            }
            Gx_mode = sMode40;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound40 = 0;
            InitializeNonKey0Z40( ) ;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode40;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Z40( ) ;
         if ( RcdFound40 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound40 = 0;
         /* Using cursor T000Z8 */
         pr_default.execute(6, new Object[] {A144CiudadId, A116PaisID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000Z8_A144CiudadId[0] < A144CiudadId ) || ( T000Z8_A144CiudadId[0] == A144CiudadId ) && ( StringUtil.StrCmp(T000Z8_A116PaisID[0], A116PaisID) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000Z8_A144CiudadId[0] > A144CiudadId ) || ( T000Z8_A144CiudadId[0] == A144CiudadId ) && ( StringUtil.StrCmp(T000Z8_A116PaisID[0], A116PaisID) > 0 ) ) )
            {
               A144CiudadId = T000Z8_A144CiudadId[0];
               AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
               A116PaisID = T000Z8_A116PaisID[0];
               AssignAttri("", false, "A116PaisID", A116PaisID);
               RcdFound40 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound40 = 0;
         /* Using cursor T000Z9 */
         pr_default.execute(7, new Object[] {A144CiudadId, A116PaisID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000Z9_A144CiudadId[0] > A144CiudadId ) || ( T000Z9_A144CiudadId[0] == A144CiudadId ) && ( StringUtil.StrCmp(T000Z9_A116PaisID[0], A116PaisID) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000Z9_A144CiudadId[0] < A144CiudadId ) || ( T000Z9_A144CiudadId[0] == A144CiudadId ) && ( StringUtil.StrCmp(T000Z9_A116PaisID[0], A116PaisID) < 0 ) ) )
            {
               A144CiudadId = T000Z9_A144CiudadId[0];
               AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
               A116PaisID = T000Z9_A116PaisID[0];
               AssignAttri("", false, "A116PaisID", A116PaisID);
               RcdFound40 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Z40( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCiudadId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Z40( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound40 == 1 )
            {
               if ( ( A144CiudadId != Z144CiudadId ) || ( StringUtil.StrCmp(A116PaisID, Z116PaisID) != 0 ) )
               {
                  A144CiudadId = Z144CiudadId;
                  AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
                  A116PaisID = Z116PaisID;
                  AssignAttri("", false, "A116PaisID", A116PaisID);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CIUDADID");
                  AnyError = 1;
                  GX_FocusControl = edtCiudadId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCiudadId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0Z40( ) ;
                  GX_FocusControl = edtCiudadId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A144CiudadId != Z144CiudadId ) || ( StringUtil.StrCmp(A116PaisID, Z116PaisID) != 0 ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtCiudadId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Z40( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CIUDADID");
                     AnyError = 1;
                     GX_FocusControl = edtCiudadId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCiudadId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0Z40( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( ( A144CiudadId != Z144CiudadId ) || ( StringUtil.StrCmp(A116PaisID, Z116PaisID) != 0 ) )
         {
            A144CiudadId = Z144CiudadId;
            AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
            A116PaisID = Z116PaisID;
            AssignAttri("", false, "A116PaisID", A116PaisID);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CIUDADID");
            AnyError = 1;
            GX_FocusControl = edtCiudadId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCiudadId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CIUDADID");
            AnyError = 1;
            GX_FocusControl = edtCiudadId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCiudadNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0Z40( ) ;
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
         }
         GX_FocusControl = edtCiudadNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Z40( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
         }
         GX_FocusControl = edtCiudadNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
         }
         GX_FocusControl = edtCiudadNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0Z40( ) ;
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound40 != 0 )
            {
               ScanNext0Z40( ) ;
            }
         }
         GX_FocusControl = edtCiudadNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Z40( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0Z40( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Z2 */
            pr_default.execute(0, new Object[] {A144CiudadId, A116PaisID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ciudad"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z208CiudadNombre, T000Z2_A208CiudadNombre[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z208CiudadNombre, T000Z2_A208CiudadNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("ciudad:[seudo value changed for attri]"+"CiudadNombre");
                  GXUtil.WriteLogRaw("Old: ",Z208CiudadNombre);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A208CiudadNombre[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Ciudad"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z40( )
      {
         BeforeValidate0Z40( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z40( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z40( 0) ;
            CheckOptimisticConcurrency0Z40( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z40( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z40( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z10 */
                     pr_default.execute(8, new Object[] {A144CiudadId, A208CiudadNombre, A209CiudadImagen1, A40001CiudadImagen1_GXI, A116PaisID});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Ciudad");
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
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0Z0( ) ;
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
               Load0Z40( ) ;
            }
            EndLevel0Z40( ) ;
         }
         CloseExtendedTableCursors0Z40( ) ;
      }

      protected void Update0Z40( )
      {
         BeforeValidate0Z40( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z40( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z40( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z40( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Z40( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z11 */
                     pr_default.execute(9, new Object[] {A208CiudadNombre, A144CiudadId, A116PaisID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Ciudad");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ciudad"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Z40( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0Z0( ) ;
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
            EndLevel0Z40( ) ;
         }
         CloseExtendedTableCursors0Z40( ) ;
      }

      protected void DeferredUpdate0Z40( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000Z12 */
            pr_default.execute(10, new Object[] {A209CiudadImagen1, A40001CiudadImagen1_GXI, A144CiudadId, A116PaisID});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Ciudad");
         }
      }

      protected void delete( )
      {
         BeforeValidate0Z40( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z40( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z40( ) ;
            AfterConfirm0Z40( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z40( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Z13 */
                  pr_default.execute(11, new Object[] {A144CiudadId, A116PaisID});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Ciudad");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound40 == 0 )
                        {
                           InitAll0Z40( ) ;
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption0Z0( ) ;
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
         sMode40 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Z40( ) ;
         Gx_mode = sMode40;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Z40( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( (0==A144CiudadId) && IsIns( )  && true /* After */ )
            {
               GX_msglist.addItem(context.GetMessage( "Ingrese un ciudad", ""), 1, "CIUDADID");
               AnyError = 1;
               GX_FocusControl = edtCiudadId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            AV16Pgmname = "Ciudad";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T000Z14 */
            pr_default.execute(12, new Object[] {A116PaisID});
            A165PaisNombre = T000Z14_A165PaisNombre[0];
            AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
            A40000PaisBandera_GXI = T000Z14_A40000PaisBandera_GXI[0];
            AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
            AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
            A207PaisBandera = T000Z14_A207PaisBandera[0];
            AssignAttri("", false, "A207PaisBandera", A207PaisBandera);
            AssignProp("", false, imgPaisBandera_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : context.convertURL( context.PathToRelativeUrl( A207PaisBandera))), true);
            AssignProp("", false, imgPaisBandera_Internalname, "SrcSet", context.GetImageSrcSet( A207PaisBandera), true);
            pr_default.close(12);
         }
      }

      protected void EndLevel0Z40( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Z40( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(12);
            context.CommitDataStores("ciudad",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0Z0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(12);
            context.RollbackDataStores("ciudad",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Z40( )
      {
         /* Scan By routine */
         /* Using cursor T000Z15 */
         pr_default.execute(13);
         RcdFound40 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound40 = 1;
            A144CiudadId = T000Z15_A144CiudadId[0];
            AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
            A116PaisID = T000Z15_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Z40( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound40 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound40 = 1;
            A144CiudadId = T000Z15_A144CiudadId[0];
            AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
            A116PaisID = T000Z15_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
         }
      }

      protected void ScanEnd0Z40( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0Z40( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z40( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z40( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z40( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z40( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z40( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z40( )
      {
         edtCiudadId_Enabled = 0;
         AssignProp("", false, edtCiudadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadId_Enabled), 5, 0), true);
         edtPaisID_Enabled = 0;
         AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         edtPaisNombre_Enabled = 0;
         AssignProp("", false, edtPaisNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisNombre_Enabled), 5, 0), true);
         imgPaisBandera_Enabled = 0;
         AssignProp("", false, imgPaisBandera_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgPaisBandera_Enabled), 5, 0), true);
         edtCiudadNombre_Enabled = 0;
         AssignProp("", false, edtCiudadNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadNombre_Enabled), 5, 0), true);
         imgCiudadImagen1_Enabled = 0;
         AssignProp("", false, imgCiudadImagen1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgCiudadImagen1_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0Z40( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0Z0( )
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
         GXEncryptionTmp = "ciudad.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CiudadId,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV8PaisID));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ciudad.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Ciudad");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("ciudad:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z144CiudadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z144CiudadId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z116PaisID", StringUtil.RTrim( Z116PaisID));
         GxWebStd.gx_hidden_field( context, "Z208CiudadNombre", StringUtil.RTrim( Z208CiudadNombre));
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
         GxWebStd.gx_hidden_field( context, "vCIUDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CiudadId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCIUDADID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CiudadId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPAISID", StringUtil.RTrim( AV8PaisID));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAISID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8PaisID, "")), context));
         GxWebStd.gx_hidden_field( context, "CIUDADIMAGEN1_GXI", A40001CiudadImagen1_GXI);
         GxWebStd.gx_hidden_field( context, "PAISBANDERA_GXI", A40000PaisBandera_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
         GXCCtlgxBlob = "PAISBANDERA" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A207PaisBandera);
         GXCCtlgxBlob = "CIUDADIMAGEN1" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A209CiudadImagen1);
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
         GXEncryptionTmp = "ciudad.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CiudadId,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV8PaisID));
         return formatLink("ciudad.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Ciudad" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Ciudad", "") ;
      }

      protected void InitializeNonKey0Z40( )
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
         A208CiudadNombre = "";
         AssignAttri("", false, "A208CiudadNombre", A208CiudadNombre);
         A209CiudadImagen1 = "";
         AssignAttri("", false, "A209CiudadImagen1", A209CiudadImagen1);
         AssignProp("", false, imgCiudadImagen1_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A209CiudadImagen1)) ? A40001CiudadImagen1_GXI : context.convertURL( context.PathToRelativeUrl( A209CiudadImagen1))), true);
         AssignProp("", false, imgCiudadImagen1_Internalname, "SrcSet", context.GetImageSrcSet( A209CiudadImagen1), true);
         A40001CiudadImagen1_GXI = "";
         AssignProp("", false, imgCiudadImagen1_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A209CiudadImagen1)) ? A40001CiudadImagen1_GXI : context.convertURL( context.PathToRelativeUrl( A209CiudadImagen1))), true);
         AssignProp("", false, imgCiudadImagen1_Internalname, "SrcSet", context.GetImageSrcSet( A209CiudadImagen1), true);
         Z208CiudadNombre = "";
      }

      protected void InitAll0Z40( )
      {
         A144CiudadId = 0;
         AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
         A116PaisID = "";
         AssignAttri("", false, "A116PaisID", A116PaisID);
         InitializeNonKey0Z40( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021105627", true, true, false);
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
         context.AddJavascriptSource("ciudad.js", "?202673021105627", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCiudadId_Internalname = "CIUDADID";
         edtPaisID_Internalname = "PAISID";
         edtPaisNombre_Internalname = "PAISNOMBRE";
         imgPaisBandera_Internalname = "PAISBANDERA";
         edtCiudadNombre_Internalname = "CIUDADNOMBRE";
         imgCiudadImagen1_Internalname = "CIUDADIMAGEN1";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_116_Internalname = "PROMPT_116";
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
         Form.Caption = context.GetMessage( "Ciudad", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         imgCiudadImagen1_Enabled = 1;
         edtCiudadNombre_Jsonclick = "";
         edtCiudadNombre_Enabled = 1;
         imgPaisBandera_Enabled = 0;
         edtPaisNombre_Jsonclick = "";
         edtPaisNombre_Enabled = 0;
         imgprompt_116_Visible = 1;
         imgprompt_116_Link = "";
         edtPaisID_Jsonclick = "";
         edtPaisID_Enabled = 1;
         edtCiudadId_Jsonclick = "";
         edtCiudadId_Enabled = 1;
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

      protected void GX1ASACIUDADID0Z40( string A116PaisID )
      {
         if ( ! (0==AV7CiudadId) )
         {
            A144CiudadId = AV7CiudadId;
            AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
         }
         else
         {
            if ( IsIns( )  && true /* After */ && String.IsNullOrEmpty(StringUtil.RTrim( AV8PaisID)) )
            {
               GXt_int1 = A144CiudadId;
               new oautonumrciudad(context ).execute(  A116PaisID, out  GXt_int1) ;
               A144CiudadId = GXt_int1;
               AssignAttri("", false, "A144CiudadId", StringUtil.LTrimStr( (decimal)(A144CiudadId), 18, 0));
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A144CiudadId), 18, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
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

      public void Valid_Paisid( )
      {
         /* Using cursor T000Z14 */
         pr_default.execute(12, new Object[] {A116PaisID});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
         }
         A165PaisNombre = T000Z14_A165PaisNombre[0];
         A40000PaisBandera_GXI = T000Z14_A40000PaisBandera_GXI[0];
         A207PaisBandera = T000Z14_A207PaisBandera[0];
         pr_default.close(12);
         if ( ! (0==AV7CiudadId) )
         {
            A144CiudadId = AV7CiudadId;
         }
         else
         {
            if ( IsIns( )  && true /* After */ && String.IsNullOrEmpty(StringUtil.RTrim( AV8PaisID)) )
            {
               GXt_int1 = A144CiudadId;
               new oautonumrciudad(context ).execute(  A116PaisID, out  GXt_int1) ;
               A144CiudadId = GXt_int1;
            }
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A165PaisNombre", StringUtil.RTrim( A165PaisNombre));
         AssignAttri("", false, "A207PaisBandera", context.PathToRelativeUrl( A207PaisBandera));
         GXCCtlgxBlob = "PAISBANDERA" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A207PaisBandera));
         AssignAttri("", false, "A40000PaisBandera_GXI", A40000PaisBandera_GXI);
         AssignAttri("", false, "A144CiudadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A144CiudadId), 18, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7CiudadId',fld:'vCIUDADID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV8PaisID',fld:'vPAISID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CiudadId',fld:'vCIUDADID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV8PaisID',fld:'vPAISID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120Z2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("'ENUMERAR'","{handler:'E130Z2',iparms:[{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'}]");
         setEventMetadata("'ENUMERAR'",",oparms:[{av:'A144CiudadId',fld:'CIUDADID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_CIUDADID","{handler:'Valid_Ciudadid',iparms:[]");
         setEventMetadata("VALID_CIUDADID",",oparms:[]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'},{av:'A165PaisNombre',fld:'PAISNOMBRE',pic:'',type:'char'},{av:'A207PaisBandera',fld:'PAISBANDERA',pic:'',type:'bits'},{av:'A40000PaisBandera_GXI',fld:'PAISBANDERA_GXI',pic:'',type:'svchar'},{av:'A144CiudadId',fld:'CIUDADID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_PAISID",",oparms:[{av:'A165PaisNombre',fld:'PAISNOMBRE',pic:'',type:'char'},{av:'A207PaisBandera',fld:'PAISBANDERA',pic:'',type:'bits'},{av:'A40000PaisBandera_GXI',fld:'PAISBANDERA_GXI',pic:'',type:'svchar'},{av:'A144CiudadId',fld:'CIUDADID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
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
         wcpOAV8PaisID = "";
         Z116PaisID = "";
         Z208CiudadNombre = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A116PaisID = "";
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
         imgprompt_116_gximage = "";
         sImgUrl = "";
         A165PaisNombre = "";
         A207PaisBandera = "";
         A40000PaisBandera_GXI = "";
         A208CiudadNombre = "";
         A209CiudadImagen1 = "";
         A40001CiudadImagen1_GXI = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV16Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV14WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z209CiudadImagen1 = "";
         Z40001CiudadImagen1_GXI = "";
         Z165PaisNombre = "";
         Z207PaisBandera = "";
         Z40000PaisBandera_GXI = "";
         T000Z4_A165PaisNombre = new string[] {""} ;
         T000Z4_A40000PaisBandera_GXI = new string[] {""} ;
         T000Z4_A207PaisBandera = new string[] {""} ;
         T000Z5_A144CiudadId = new long[1] ;
         T000Z5_A165PaisNombre = new string[] {""} ;
         T000Z5_A40000PaisBandera_GXI = new string[] {""} ;
         T000Z5_A208CiudadNombre = new string[] {""} ;
         T000Z5_A40001CiudadImagen1_GXI = new string[] {""} ;
         T000Z5_A116PaisID = new string[] {""} ;
         T000Z5_A207PaisBandera = new string[] {""} ;
         T000Z5_A209CiudadImagen1 = new string[] {""} ;
         T000Z6_A165PaisNombre = new string[] {""} ;
         T000Z6_A40000PaisBandera_GXI = new string[] {""} ;
         T000Z6_A207PaisBandera = new string[] {""} ;
         T000Z7_A144CiudadId = new long[1] ;
         T000Z7_A116PaisID = new string[] {""} ;
         T000Z3_A144CiudadId = new long[1] ;
         T000Z3_A208CiudadNombre = new string[] {""} ;
         T000Z3_A40001CiudadImagen1_GXI = new string[] {""} ;
         T000Z3_A116PaisID = new string[] {""} ;
         T000Z3_A209CiudadImagen1 = new string[] {""} ;
         sMode40 = "";
         T000Z8_A144CiudadId = new long[1] ;
         T000Z8_A116PaisID = new string[] {""} ;
         T000Z9_A144CiudadId = new long[1] ;
         T000Z9_A116PaisID = new string[] {""} ;
         T000Z2_A144CiudadId = new long[1] ;
         T000Z2_A208CiudadNombre = new string[] {""} ;
         T000Z2_A40001CiudadImagen1_GXI = new string[] {""} ;
         T000Z2_A116PaisID = new string[] {""} ;
         T000Z2_A209CiudadImagen1 = new string[] {""} ;
         T000Z14_A165PaisNombre = new string[] {""} ;
         T000Z14_A40000PaisBandera_GXI = new string[] {""} ;
         T000Z14_A207PaisBandera = new string[] {""} ;
         T000Z15_A144CiudadId = new long[1] ;
         T000Z15_A116PaisID = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.ciudad__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ciudad__default(),
            new Object[][] {
                new Object[] {
               T000Z2_A144CiudadId, T000Z2_A208CiudadNombre, T000Z2_A40001CiudadImagen1_GXI, T000Z2_A116PaisID, T000Z2_A209CiudadImagen1
               }
               , new Object[] {
               T000Z3_A144CiudadId, T000Z3_A208CiudadNombre, T000Z3_A40001CiudadImagen1_GXI, T000Z3_A116PaisID, T000Z3_A209CiudadImagen1
               }
               , new Object[] {
               T000Z4_A165PaisNombre, T000Z4_A40000PaisBandera_GXI, T000Z4_A207PaisBandera
               }
               , new Object[] {
               T000Z5_A144CiudadId, T000Z5_A165PaisNombre, T000Z5_A40000PaisBandera_GXI, T000Z5_A208CiudadNombre, T000Z5_A40001CiudadImagen1_GXI, T000Z5_A116PaisID, T000Z5_A207PaisBandera, T000Z5_A209CiudadImagen1
               }
               , new Object[] {
               T000Z6_A165PaisNombre, T000Z6_A40000PaisBandera_GXI, T000Z6_A207PaisBandera
               }
               , new Object[] {
               T000Z7_A144CiudadId, T000Z7_A116PaisID
               }
               , new Object[] {
               T000Z8_A144CiudadId, T000Z8_A116PaisID
               }
               , new Object[] {
               T000Z9_A144CiudadId, T000Z9_A116PaisID
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
               T000Z14_A165PaisNombre, T000Z14_A40000PaisBandera_GXI, T000Z14_A207PaisBandera
               }
               , new Object[] {
               T000Z15_A144CiudadId, T000Z15_A116PaisID
               }
            }
         );
         AV16Pgmname = "Ciudad";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound40 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtCiudadId_Enabled ;
      private int edtPaisID_Enabled ;
      private int imgprompt_116_Visible ;
      private int edtPaisNombre_Enabled ;
      private int imgPaisBandera_Enabled ;
      private int edtCiudadNombre_Enabled ;
      private int imgCiudadImagen1_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long wcpOAV7CiudadId ;
      private long Z144CiudadId ;
      private long AV7CiudadId ;
      private long A144CiudadId ;
      private long GXt_int1 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV8PaisID ;
      private string Z116PaisID ;
      private string Z208CiudadNombre ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A116PaisID ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV8PaisID ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCiudadId_Internalname ;
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
      private string edtCiudadId_Jsonclick ;
      private string edtPaisID_Internalname ;
      private string edtPaisID_Jsonclick ;
      private string imgprompt_116_gximage ;
      private string sImgUrl ;
      private string imgprompt_116_Internalname ;
      private string imgprompt_116_Link ;
      private string edtPaisNombre_Internalname ;
      private string A165PaisNombre ;
      private string edtPaisNombre_Jsonclick ;
      private string imgPaisBandera_Internalname ;
      private string edtCiudadNombre_Internalname ;
      private string A208CiudadNombre ;
      private string edtCiudadNombre_Jsonclick ;
      private string imgCiudadImagen1_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV16Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string Z165PaisNombre ;
      private string sMode40 ;
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
      private bool A207PaisBandera_IsBlob ;
      private bool A209CiudadImagen1_IsBlob ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV10IsAuthorized ;
      private bool GXt_boolean2 ;
      private string A40000PaisBandera_GXI ;
      private string A40001CiudadImagen1_GXI ;
      private string Z40001CiudadImagen1_GXI ;
      private string Z40000PaisBandera_GXI ;
      private string A207PaisBandera ;
      private string A209CiudadImagen1 ;
      private string Z209CiudadImagen1 ;
      private string Z207PaisBandera ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV14WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private string[] T000Z4_A165PaisNombre ;
      private string[] T000Z4_A40000PaisBandera_GXI ;
      private string[] T000Z4_A207PaisBandera ;
      private long[] T000Z5_A144CiudadId ;
      private string[] T000Z5_A165PaisNombre ;
      private string[] T000Z5_A40000PaisBandera_GXI ;
      private string[] T000Z5_A208CiudadNombre ;
      private string[] T000Z5_A40001CiudadImagen1_GXI ;
      private string[] T000Z5_A116PaisID ;
      private string[] T000Z5_A207PaisBandera ;
      private string[] T000Z5_A209CiudadImagen1 ;
      private string[] T000Z6_A165PaisNombre ;
      private string[] T000Z6_A40000PaisBandera_GXI ;
      private string[] T000Z6_A207PaisBandera ;
      private long[] T000Z7_A144CiudadId ;
      private string[] T000Z7_A116PaisID ;
      private long[] T000Z3_A144CiudadId ;
      private string[] T000Z3_A208CiudadNombre ;
      private string[] T000Z3_A40001CiudadImagen1_GXI ;
      private string[] T000Z3_A116PaisID ;
      private string[] T000Z3_A209CiudadImagen1 ;
      private long[] T000Z8_A144CiudadId ;
      private string[] T000Z8_A116PaisID ;
      private long[] T000Z9_A144CiudadId ;
      private string[] T000Z9_A116PaisID ;
      private long[] T000Z2_A144CiudadId ;
      private string[] T000Z2_A208CiudadNombre ;
      private string[] T000Z2_A40001CiudadImagen1_GXI ;
      private string[] T000Z2_A116PaisID ;
      private string[] T000Z2_A209CiudadImagen1 ;
      private string[] T000Z14_A165PaisNombre ;
      private string[] T000Z14_A40000PaisBandera_GXI ;
      private string[] T000Z14_A207PaisBandera ;
      private long[] T000Z15_A144CiudadId ;
      private string[] T000Z15_A116PaisID ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class ciudad__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class ciudad__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000Z2;
        prmT000Z2 = new Object[] {
        new ParDef("@CiudadId",GXType.Decimal,18,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Z3;
        prmT000Z3 = new Object[] {
        new ParDef("@CiudadId",GXType.Decimal,18,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Z4;
        prmT000Z4 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Z5;
        prmT000Z5 = new Object[] {
        new ParDef("@CiudadId",GXType.Decimal,18,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Z6;
        prmT000Z6 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Z7;
        prmT000Z7 = new Object[] {
        new ParDef("@CiudadId",GXType.Decimal,18,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Z8;
        prmT000Z8 = new Object[] {
        new ParDef("@CiudadId",GXType.Decimal,18,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Z9;
        prmT000Z9 = new Object[] {
        new ParDef("@CiudadId",GXType.Decimal,18,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Z10;
        prmT000Z10 = new Object[] {
        new ParDef("@CiudadId",GXType.Decimal,18,0) ,
        new ParDef("@CiudadNombre",GXType.NChar,80,0) ,
        new ParDef("@CiudadImagen1",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@CiudadImagen1_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="Ciudad", Fld="CiudadImagen1"} ,
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Z11;
        prmT000Z11 = new Object[] {
        new ParDef("@CiudadNombre",GXType.NChar,80,0) ,
        new ParDef("@CiudadId",GXType.Decimal,18,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Z12;
        prmT000Z12 = new Object[] {
        new ParDef("@CiudadImagen1",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@CiudadImagen1_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Ciudad", Fld="CiudadImagen1"} ,
        new ParDef("@CiudadId",GXType.Decimal,18,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Z13;
        prmT000Z13 = new Object[] {
        new ParDef("@CiudadId",GXType.Decimal,18,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Z14;
        prmT000Z14 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000Z15;
        prmT000Z15 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000Z2", "SELECT [CiudadId], [CiudadNombre], [CiudadImagen1_GXI], [PaisID], [CiudadImagen1] FROM [Ciudad] WITH (UPDLOCK) WHERE [CiudadId] = @CiudadId AND [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z3", "SELECT [CiudadId], [CiudadNombre], [CiudadImagen1_GXI], [PaisID], [CiudadImagen1] FROM [Ciudad] WHERE [CiudadId] = @CiudadId AND [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z4", "SELECT [PaisNombre], [PaisBandera_GXI], [PaisBandera] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z5", "SELECT TM1.[CiudadId], T2.[PaisNombre], T2.[PaisBandera_GXI], TM1.[CiudadNombre], TM1.[CiudadImagen1_GXI], TM1.[PaisID], T2.[PaisBandera], TM1.[CiudadImagen1] FROM ([Ciudad] TM1 INNER JOIN [Pais] T2 ON T2.[PaisID] = TM1.[PaisID]) WHERE TM1.[CiudadId] = @CiudadId and TM1.[PaisID] = @PaisID ORDER BY TM1.[CiudadId], TM1.[PaisID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z6", "SELECT [PaisNombre], [PaisBandera_GXI], [PaisBandera] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z7", "SELECT [CiudadId], [PaisID] FROM [Ciudad] WHERE [CiudadId] = @CiudadId AND [PaisID] = @PaisID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z8", "SELECT TOP 1 [CiudadId], [PaisID] FROM [Ciudad] WHERE ( [CiudadId] > @CiudadId or [CiudadId] = @CiudadId and [PaisID] > @PaisID) ORDER BY [CiudadId], [PaisID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z9", "SELECT TOP 1 [CiudadId], [PaisID] FROM [Ciudad] WHERE ( [CiudadId] < @CiudadId or [CiudadId] = @CiudadId and [PaisID] < @PaisID) ORDER BY [CiudadId] DESC, [PaisID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z10", "INSERT INTO [Ciudad]([CiudadId], [CiudadNombre], [CiudadImagen1], [CiudadImagen1_GXI], [PaisID]) VALUES(@CiudadId, @CiudadNombre, @CiudadImagen1, @CiudadImagen1_GXI, @PaisID)", GxErrorMask.GX_NOMASK,prmT000Z10)
           ,new CursorDef("T000Z11", "UPDATE [Ciudad] SET [CiudadNombre]=@CiudadNombre  WHERE [CiudadId] = @CiudadId AND [PaisID] = @PaisID", GxErrorMask.GX_NOMASK,prmT000Z11)
           ,new CursorDef("T000Z12", "UPDATE [Ciudad] SET [CiudadImagen1]=@CiudadImagen1, [CiudadImagen1_GXI]=@CiudadImagen1_GXI  WHERE [CiudadId] = @CiudadId AND [PaisID] = @PaisID", GxErrorMask.GX_NOMASK,prmT000Z12)
           ,new CursorDef("T000Z13", "DELETE FROM [Ciudad]  WHERE [CiudadId] = @CiudadId AND [PaisID] = @PaisID", GxErrorMask.GX_NOMASK,prmT000Z13)
           ,new CursorDef("T000Z14", "SELECT [PaisNombre], [PaisBandera_GXI], [PaisBandera] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z15", "SELECT [CiudadId], [PaisID] FROM [Ciudad] ORDER BY [CiudadId], [PaisID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z15,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getString(4, 2);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(3));
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 2);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(3));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 2);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(5));
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
     }
  }

}

}
