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
   public class servicios : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_categorias") == 0 )
         {
            gxnrGridlevel_categorias_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "servicios.aspx")), "servicios.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "servicios.aspx")))) ;
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
                  AV7ServiciosId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServiciosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ServiciosId", StringUtil.LTrimStr( (decimal)(AV7ServiciosId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSERVICIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ServiciosId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Servicios", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtServiciosNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_categorias_newrow_invoke( )
      {
         nRC_GXsfl_38 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_38"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_38_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_38_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_38_idx = GetPar( "sGXsfl_38_idx");
         A953ServiciosCategoriasSerial = (short)(Math.Round(NumberUtil.Val( GetPar( "ServiciosCategoriasSerial"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_categorias_newrow( ) ;
         /* End function gxnrGridlevel_categorias_newrow_invoke */
      }

      public servicios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public servicios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_ServiciosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ServiciosId = aP1_ServiciosId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbServiciosActivo = new GXCombobox();
         chkCategoriasActivo = new GXCheckbox();
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
         if ( cmbServiciosActivo.ItemCount > 0 )
         {
            A954ServiciosActivo = StringUtil.StrToBool( cmbServiciosActivo.getValidValue(StringUtil.BoolToStr( A954ServiciosActivo)));
            AssignAttri("", false, "A954ServiciosActivo", A954ServiciosActivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbServiciosActivo.CurrentValue = StringUtil.BoolToStr( A954ServiciosActivo);
            AssignProp("", false, cmbServiciosActivo_Internalname, "Values", cmbServiciosActivo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtServiciosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtServiciosId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtServiciosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A942ServiciosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtServiciosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A942ServiciosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A942ServiciosId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtServiciosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtServiciosId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Servicios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtServiciosNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtServiciosNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtServiciosNombre_Internalname, StringUtil.RTrim( A943ServiciosNombre), StringUtil.RTrim( context.localUtil.Format( A943ServiciosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtServiciosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtServiciosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Servicios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbServiciosActivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbServiciosActivo_Internalname, context.GetMessage( "Activo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbServiciosActivo, cmbServiciosActivo_Internalname, StringUtil.BoolToStr( A954ServiciosActivo), 1, cmbServiciosActivo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbServiciosActivo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 0, "HLP_Servicios.htm");
         cmbServiciosActivo.CurrentValue = StringUtil.BoolToStr( A954ServiciosActivo);
         AssignProp("", false, cmbServiciosActivo_Internalname, "Values", (string)(cmbServiciosActivo.ToJavascriptSource()), true);
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
         GxWebStd.gx_div_start( context, divTableleaflevel_categorias_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_categorias( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Servicios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Servicios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Servicios.htm");
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

      protected void gxdraw_Gridlevel_categorias( )
      {
         /*  Grid Control  */
         StartGridControl38( ) ;
         nGXsfl_38_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount141 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_141 = 1;
               ScanStart2X141( ) ;
               while ( RcdFound141 != 0 )
               {
                  init_level_properties141( ) ;
                  getByPrimaryKey2X141( ) ;
                  AddRow2X141( ) ;
                  ScanNext2X141( ) ;
               }
               ScanEnd2X141( ) ;
               nBlankRcdCount141 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B953ServiciosCategoriasSerial = A953ServiciosCategoriasSerial;
            AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
            standaloneNotModal2X141( ) ;
            standaloneModal2X141( ) ;
            sMode141 = Gx_mode;
            while ( nGXsfl_38_idx < nRC_GXsfl_38 )
            {
               bGXsfl_38_Refreshing = true;
               ReadRow2X141( ) ;
               edtCategoriasId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORIASID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCategoriasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriasId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtCategoriasNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORIASNOMBRE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCategoriasNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriasNombre_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               chkCategoriasActivo.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORIASACTIVO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, chkCategoriasActivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkCategoriasActivo.Enabled), 5, 0), !bGXsfl_38_Refreshing);
               if ( ( nRcdExists_141 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal2X141( ) ;
               }
               SendRow2X141( ) ;
               bGXsfl_38_Refreshing = false;
            }
            Gx_mode = sMode141;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A953ServiciosCategoriasSerial = B953ServiciosCategoriasSerial;
            AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount141 = 5;
            nRcdExists_141 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart2X141( ) ;
               while ( RcdFound141 != 0 )
               {
                  sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_38141( ) ;
                  init_level_properties141( ) ;
                  standaloneNotModal2X141( ) ;
                  getByPrimaryKey2X141( ) ;
                  standaloneModal2X141( ) ;
                  AddRow2X141( ) ;
                  ScanNext2X141( ) ;
               }
               ScanEnd2X141( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode141 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx+1), 4, 0), 4, "0");
            SubsflControlProps_38141( ) ;
            InitAll2X141( ) ;
            init_level_properties141( ) ;
            B953ServiciosCategoriasSerial = A953ServiciosCategoriasSerial;
            AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
            nRcdExists_141 = 0;
            nIsMod_141 = 0;
            nRcdDeleted_141 = 0;
            nBlankRcdCount141 = (short)(nBlankRcdUsr141+nBlankRcdCount141);
            fRowAdded = 0;
            while ( nBlankRcdCount141 > 0 )
            {
               standaloneNotModal2X141( ) ;
               standaloneModal2X141( ) ;
               AddRow2X141( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtCategoriasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount141 = (short)(nBlankRcdCount141-1);
            }
            Gx_mode = sMode141;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A953ServiciosCategoriasSerial = B953ServiciosCategoriasSerial;
            AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_categoriasContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_categorias", Gridlevel_categoriasContainer, subGridlevel_categorias_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_categoriasContainerData", Gridlevel_categoriasContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_categoriasContainerData"+"V", Gridlevel_categoriasContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_categoriasContainerData"+"V"+"\" value='"+Gridlevel_categoriasContainer.GridValuesHidden()+"'/>") ;
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
         E112X2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z942ServiciosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z942ServiciosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z943ServiciosNombre = cgiGet( "Z943ServiciosNombre");
               Z953ServiciosCategoriasSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z953ServiciosCategoriasSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z954ServiciosActivo = StringUtil.StrToBool( cgiGet( "Z954ServiciosActivo"));
               A953ServiciosCategoriasSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z953ServiciosCategoriasSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O953ServiciosCategoriasSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O953ServiciosCategoriasSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_38 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_38"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7ServiciosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vSERVICIOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A953ServiciosCategoriasSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( "SERVICIOSCATEGORIASSERIAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
               A942ServiciosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtServiciosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n942ServiciosId = false;
               AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
               A943ServiciosNombre = cgiGet( edtServiciosNombre_Internalname);
               AssignAttri("", false, "A943ServiciosNombre", A943ServiciosNombre);
               cmbServiciosActivo.Name = cmbServiciosActivo_Internalname;
               cmbServiciosActivo.CurrentValue = cgiGet( cmbServiciosActivo_Internalname);
               A954ServiciosActivo = StringUtil.StrToBool( cgiGet( cmbServiciosActivo_Internalname));
               AssignAttri("", false, "A954ServiciosActivo", A954ServiciosActivo);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Servicios");
               A942ServiciosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtServiciosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n942ServiciosId = false;
               AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
               forbiddenHiddens.Add("ServiciosId", context.localUtil.Format( (decimal)(A942ServiciosId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A942ServiciosId != Z942ServiciosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("servicios:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A942ServiciosId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServiciosId"), "."), 18, MidpointRounding.ToEven));
                  n942ServiciosId = false;
                  AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
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
                     sMode140 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode140;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound140 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2X0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SERVICIOSID");
                        AnyError = 1;
                        GX_FocusControl = edtServiciosId_Internalname;
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
                           E112X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122X2 ();
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
            E122X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2X140( ) ;
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
            DisableAttributes2X140( ) ;
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

      protected void CONFIRM_2X0( )
      {
         BeforeValidate2X140( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2X140( ) ;
            }
            else
            {
               CheckExtendedTable2X140( ) ;
               CloseExtendedTableCursors2X140( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode140 = Gx_mode;
            CONFIRM_2X141( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode140;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode140;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_2X141( )
      {
         s953ServiciosCategoriasSerial = O953ServiciosCategoriasSerial;
         AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
         nGXsfl_38_idx = 0;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            ReadRow2X141( ) ;
            if ( ( nRcdExists_141 != 0 ) || ( nIsMod_141 != 0 ) )
            {
               GetKey2X141( ) ;
               if ( ( nRcdExists_141 == 0 ) && ( nRcdDeleted_141 == 0 ) )
               {
                  if ( RcdFound141 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate2X141( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2X141( ) ;
                        CloseExtendedTableCursors2X141( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O953ServiciosCategoriasSerial = A953ServiciosCategoriasSerial;
                        AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "CATEGORIASID_" + sGXsfl_38_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCategoriasId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound141 != 0 )
                  {
                     if ( nRcdDeleted_141 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey2X141( ) ;
                        Load2X141( ) ;
                        BeforeValidate2X141( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2X141( ) ;
                           O953ServiciosCategoriasSerial = A953ServiciosCategoriasSerial;
                           AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_141 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate2X141( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2X141( ) ;
                              CloseExtendedTableCursors2X141( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O953ServiciosCategoriasSerial = A953ServiciosCategoriasSerial;
                              AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_141 == 0 )
                     {
                        GXCCtl = "CATEGORIASID_" + sGXsfl_38_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCategoriasId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCategoriasId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A931CategoriasId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCategoriasNombre_Internalname, StringUtil.RTrim( A944CategoriasNombre)) ;
            ChangePostValue( chkCategoriasActivo_Internalname, StringUtil.BoolToStr( A955CategoriasActivo)) ;
            ChangePostValue( "ZT_"+"Z931CategoriasId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z931CategoriasId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z944CategoriasNombre_"+sGXsfl_38_idx, StringUtil.RTrim( Z944CategoriasNombre)) ;
            ChangePostValue( "ZT_"+"Z955CategoriasActivo_"+sGXsfl_38_idx, StringUtil.BoolToStr( Z955CategoriasActivo)) ;
            ChangePostValue( "nRcdDeleted_141_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_141), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_141_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_141), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_141_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_141), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_141 != 0 )
            {
               ChangePostValue( "CATEGORIASID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriasId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORIASNOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriasNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORIASACTIVO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkCategoriasActivo.Enabled), 5, 0, ".", ""))) ;
            }
         }
         O953ServiciosCategoriasSerial = s953ServiciosCategoriasSerial;
         AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption2X0( )
      {
      }

      protected void E112X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWServicios_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWServicios_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWServicios_Delete", out  GXt_boolean1) ;
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

      protected void E122X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("serviciosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM2X140( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z943ServiciosNombre = T002X5_A943ServiciosNombre[0];
               Z953ServiciosCategoriasSerial = T002X5_A953ServiciosCategoriasSerial[0];
               Z954ServiciosActivo = T002X5_A954ServiciosActivo[0];
            }
            else
            {
               Z943ServiciosNombre = A943ServiciosNombre;
               Z953ServiciosCategoriasSerial = A953ServiciosCategoriasSerial;
               Z954ServiciosActivo = A954ServiciosActivo;
            }
         }
         if ( GX_JID == -6 )
         {
            Z942ServiciosId = A942ServiciosId;
            Z943ServiciosNombre = A943ServiciosNombre;
            Z953ServiciosCategoriasSerial = A953ServiciosCategoriasSerial;
            Z954ServiciosActivo = A954ServiciosActivo;
         }
      }

      protected void standaloneNotModal( )
      {
         edtServiciosId_Enabled = 0;
         AssignProp("", false, edtServiciosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServiciosId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtServiciosId_Enabled = 0;
         AssignProp("", false, edtServiciosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServiciosId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ServiciosId) )
         {
            A942ServiciosId = AV7ServiciosId;
            n942ServiciosId = false;
            AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
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
         if ( IsIns( )  && (false==A954ServiciosActivo) && ( Gx_BScreen == 0 ) )
         {
            A954ServiciosActivo = true;
            AssignAttri("", false, "A954ServiciosActivo", A954ServiciosActivo);
         }
      }

      protected void Load2X140( )
      {
         /* Using cursor T002X6 */
         pr_default.execute(4, new Object[] {n942ServiciosId, A942ServiciosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound140 = 1;
            A943ServiciosNombre = T002X6_A943ServiciosNombre[0];
            AssignAttri("", false, "A943ServiciosNombre", A943ServiciosNombre);
            A953ServiciosCategoriasSerial = T002X6_A953ServiciosCategoriasSerial[0];
            A954ServiciosActivo = T002X6_A954ServiciosActivo[0];
            AssignAttri("", false, "A954ServiciosActivo", A954ServiciosActivo);
            ZM2X140( -6) ;
         }
         pr_default.close(4);
         OnLoadActions2X140( ) ;
      }

      protected void OnLoadActions2X140( )
      {
         AV14Pgmname = "Servicios";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable2X140( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV14Pgmname = "Servicios";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CloseExtendedTableCursors2X140( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2X140( )
      {
         /* Using cursor T002X7 */
         pr_default.execute(5, new Object[] {n942ServiciosId, A942ServiciosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound140 = 1;
         }
         else
         {
            RcdFound140 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002X5 */
         pr_default.execute(3, new Object[] {n942ServiciosId, A942ServiciosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM2X140( 6) ;
            RcdFound140 = 1;
            A942ServiciosId = T002X5_A942ServiciosId[0];
            n942ServiciosId = T002X5_n942ServiciosId[0];
            AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
            A943ServiciosNombre = T002X5_A943ServiciosNombre[0];
            AssignAttri("", false, "A943ServiciosNombre", A943ServiciosNombre);
            A953ServiciosCategoriasSerial = T002X5_A953ServiciosCategoriasSerial[0];
            A954ServiciosActivo = T002X5_A954ServiciosActivo[0];
            AssignAttri("", false, "A954ServiciosActivo", A954ServiciosActivo);
            O953ServiciosCategoriasSerial = A953ServiciosCategoriasSerial;
            AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
            Z942ServiciosId = A942ServiciosId;
            sMode140 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2X140( ) ;
            if ( AnyError == 1 )
            {
               RcdFound140 = 0;
               InitializeNonKey2X140( ) ;
            }
            Gx_mode = sMode140;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound140 = 0;
            InitializeNonKey2X140( ) ;
            sMode140 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode140;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey2X140( ) ;
         if ( RcdFound140 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound140 = 0;
         /* Using cursor T002X8 */
         pr_default.execute(6, new Object[] {n942ServiciosId, A942ServiciosId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T002X8_A942ServiciosId[0] < A942ServiciosId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T002X8_A942ServiciosId[0] > A942ServiciosId ) ) )
            {
               A942ServiciosId = T002X8_A942ServiciosId[0];
               n942ServiciosId = T002X8_n942ServiciosId[0];
               AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
               RcdFound140 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound140 = 0;
         /* Using cursor T002X9 */
         pr_default.execute(7, new Object[] {n942ServiciosId, A942ServiciosId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T002X9_A942ServiciosId[0] > A942ServiciosId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T002X9_A942ServiciosId[0] < A942ServiciosId ) ) )
            {
               A942ServiciosId = T002X9_A942ServiciosId[0];
               n942ServiciosId = T002X9_n942ServiciosId[0];
               AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
               RcdFound140 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2X140( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A953ServiciosCategoriasSerial = O953ServiciosCategoriasSerial;
            AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
            GX_FocusControl = edtServiciosNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2X140( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound140 == 1 )
            {
               if ( A942ServiciosId != Z942ServiciosId )
               {
                  A942ServiciosId = Z942ServiciosId;
                  n942ServiciosId = false;
                  AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SERVICIOSID");
                  AnyError = 1;
                  GX_FocusControl = edtServiciosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A953ServiciosCategoriasSerial = O953ServiciosCategoriasSerial;
                  AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtServiciosNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A953ServiciosCategoriasSerial = O953ServiciosCategoriasSerial;
                  AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
                  Update2X140( ) ;
                  GX_FocusControl = edtServiciosNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A942ServiciosId != Z942ServiciosId )
               {
                  /* Insert record */
                  A953ServiciosCategoriasSerial = O953ServiciosCategoriasSerial;
                  AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
                  GX_FocusControl = edtServiciosNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2X140( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SERVICIOSID");
                     AnyError = 1;
                     GX_FocusControl = edtServiciosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A953ServiciosCategoriasSerial = O953ServiciosCategoriasSerial;
                     AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
                     GX_FocusControl = edtServiciosNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2X140( ) ;
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
         if ( A942ServiciosId != Z942ServiciosId )
         {
            A942ServiciosId = Z942ServiciosId;
            n942ServiciosId = false;
            AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SERVICIOSID");
            AnyError = 1;
            GX_FocusControl = edtServiciosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A953ServiciosCategoriasSerial = O953ServiciosCategoriasSerial;
            AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtServiciosNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2X140( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002X4 */
            pr_default.execute(2, new Object[] {n942ServiciosId, A942ServiciosId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Servicios"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z943ServiciosNombre, T002X4_A943ServiciosNombre[0]) != 0 ) || ( Z953ServiciosCategoriasSerial != T002X4_A953ServiciosCategoriasSerial[0] ) || ( Z954ServiciosActivo != T002X4_A954ServiciosActivo[0] ) )
            {
               if ( StringUtil.StrCmp(Z943ServiciosNombre, T002X4_A943ServiciosNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("servicios:[seudo value changed for attri]"+"ServiciosNombre");
                  GXUtil.WriteLogRaw("Old: ",Z943ServiciosNombre);
                  GXUtil.WriteLogRaw("Current: ",T002X4_A943ServiciosNombre[0]);
               }
               if ( Z953ServiciosCategoriasSerial != T002X4_A953ServiciosCategoriasSerial[0] )
               {
                  GXUtil.WriteLog("servicios:[seudo value changed for attri]"+"ServiciosCategoriasSerial");
                  GXUtil.WriteLogRaw("Old: ",Z953ServiciosCategoriasSerial);
                  GXUtil.WriteLogRaw("Current: ",T002X4_A953ServiciosCategoriasSerial[0]);
               }
               if ( Z954ServiciosActivo != T002X4_A954ServiciosActivo[0] )
               {
                  GXUtil.WriteLog("servicios:[seudo value changed for attri]"+"ServiciosActivo");
                  GXUtil.WriteLogRaw("Old: ",Z954ServiciosActivo);
                  GXUtil.WriteLogRaw("Current: ",T002X4_A954ServiciosActivo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Servicios"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2X140( )
      {
         BeforeValidate2X140( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2X140( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2X140( 0) ;
            CheckOptimisticConcurrency2X140( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2X140( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2X140( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002X10 */
                     pr_default.execute(8, new Object[] {A943ServiciosNombre, A953ServiciosCategoriasSerial, A954ServiciosActivo});
                     A942ServiciosId = T002X10_A942ServiciosId[0];
                     n942ServiciosId = T002X10_n942ServiciosId[0];
                     AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Servicios");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2X140( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption2X0( ) ;
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
               Load2X140( ) ;
            }
            EndLevel2X140( ) ;
         }
         CloseExtendedTableCursors2X140( ) ;
      }

      protected void Update2X140( )
      {
         BeforeValidate2X140( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2X140( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2X140( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2X140( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2X140( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002X11 */
                     pr_default.execute(9, new Object[] {A943ServiciosNombre, A953ServiciosCategoriasSerial, A954ServiciosActivo, n942ServiciosId, A942ServiciosId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Servicios");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Servicios"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2X140( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2X140( ) ;
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
            EndLevel2X140( ) ;
         }
         CloseExtendedTableCursors2X140( ) ;
      }

      protected void DeferredUpdate2X140( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2X140( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2X140( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2X140( ) ;
            AfterConfirm2X140( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2X140( ) ;
               if ( AnyError == 0 )
               {
                  A953ServiciosCategoriasSerial = O953ServiciosCategoriasSerial;
                  AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
                  ScanStart2X141( ) ;
                  while ( RcdFound141 != 0 )
                  {
                     getByPrimaryKey2X141( ) ;
                     Delete2X141( ) ;
                     ScanNext2X141( ) ;
                     O953ServiciosCategoriasSerial = A953ServiciosCategoriasSerial;
                     AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
                  }
                  ScanEnd2X141( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002X12 */
                     pr_default.execute(10, new Object[] {n942ServiciosId, A942ServiciosId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Servicios");
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
         sMode140 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2X140( ) ;
         Gx_mode = sMode140;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2X140( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "Servicios";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002X13 */
            pr_default.execute(11, new Object[] {n942ServiciosId, A942ServiciosId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "ProfesionalesServicios", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T002X14 */
            pr_default.execute(12, new Object[] {n942ServiciosId, A942ServiciosId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Postulaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void ProcessNestedLevel2X141( )
      {
         s953ServiciosCategoriasSerial = O953ServiciosCategoriasSerial;
         AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
         nGXsfl_38_idx = 0;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            ReadRow2X141( ) ;
            if ( ( nRcdExists_141 != 0 ) || ( nIsMod_141 != 0 ) )
            {
               standaloneNotModal2X141( ) ;
               GetKey2X141( ) ;
               if ( ( nRcdExists_141 == 0 ) && ( nRcdDeleted_141 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert2X141( ) ;
               }
               else
               {
                  if ( RcdFound141 != 0 )
                  {
                     if ( ( nRcdDeleted_141 != 0 ) && ( nRcdExists_141 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete2X141( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_141 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update2X141( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_141 == 0 )
                     {
                        GXCCtl = "CATEGORIASID_" + sGXsfl_38_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCategoriasId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O953ServiciosCategoriasSerial = A953ServiciosCategoriasSerial;
               AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
            }
            ChangePostValue( edtCategoriasId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A931CategoriasId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCategoriasNombre_Internalname, StringUtil.RTrim( A944CategoriasNombre)) ;
            ChangePostValue( chkCategoriasActivo_Internalname, StringUtil.BoolToStr( A955CategoriasActivo)) ;
            ChangePostValue( "ZT_"+"Z931CategoriasId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z931CategoriasId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z944CategoriasNombre_"+sGXsfl_38_idx, StringUtil.RTrim( Z944CategoriasNombre)) ;
            ChangePostValue( "ZT_"+"Z955CategoriasActivo_"+sGXsfl_38_idx, StringUtil.BoolToStr( Z955CategoriasActivo)) ;
            ChangePostValue( "nRcdDeleted_141_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_141), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_141_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_141), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_141_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_141), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_141 != 0 )
            {
               ChangePostValue( "CATEGORIASID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriasId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORIASNOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriasNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORIASACTIVO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkCategoriasActivo.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2X141( ) ;
         if ( AnyError != 0 )
         {
            O953ServiciosCategoriasSerial = s953ServiciosCategoriasSerial;
            AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
         }
         nRcdExists_141 = 0;
         nIsMod_141 = 0;
         nRcdDeleted_141 = 0;
      }

      protected void ProcessLevel2X140( )
      {
         /* Save parent mode. */
         sMode140 = Gx_mode;
         ProcessNestedLevel2X141( ) ;
         if ( AnyError != 0 )
         {
            O953ServiciosCategoriasSerial = s953ServiciosCategoriasSerial;
            AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode140;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T002X15 */
         pr_default.execute(13, new Object[] {A953ServiciosCategoriasSerial, n942ServiciosId, A942ServiciosId});
         pr_default.close(13);
         pr_default.SmartCacheProvider.SetUpdated("Servicios");
      }

      protected void EndLevel2X140( )
      {
         pr_default.close(2);
         if ( AnyError == 0 )
         {
            BeforeComplete2X140( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.CommitDataStores("servicios",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2X0( ) ;
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
            context.RollbackDataStores("servicios",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2X140( )
      {
         /* Scan By routine */
         /* Using cursor T002X16 */
         pr_default.execute(14);
         RcdFound140 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound140 = 1;
            A942ServiciosId = T002X16_A942ServiciosId[0];
            n942ServiciosId = T002X16_n942ServiciosId[0];
            AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2X140( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound140 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound140 = 1;
            A942ServiciosId = T002X16_A942ServiciosId[0];
            n942ServiciosId = T002X16_n942ServiciosId[0];
            AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
         }
      }

      protected void ScanEnd2X140( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm2X140( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2X140( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2X140( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2X140( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2X140( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2X140( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2X140( )
      {
         edtServiciosId_Enabled = 0;
         AssignProp("", false, edtServiciosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServiciosId_Enabled), 5, 0), true);
         edtServiciosNombre_Enabled = 0;
         AssignProp("", false, edtServiciosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServiciosNombre_Enabled), 5, 0), true);
         cmbServiciosActivo.Enabled = 0;
         AssignProp("", false, cmbServiciosActivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbServiciosActivo.Enabled), 5, 0), true);
      }

      protected void ZM2X141( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z944CategoriasNombre = T002X3_A944CategoriasNombre[0];
               Z955CategoriasActivo = T002X3_A955CategoriasActivo[0];
            }
            else
            {
               Z944CategoriasNombre = A944CategoriasNombre;
               Z955CategoriasActivo = A955CategoriasActivo;
            }
         }
         if ( GX_JID == -7 )
         {
            Z942ServiciosId = A942ServiciosId;
            Z931CategoriasId = A931CategoriasId;
            Z944CategoriasNombre = A944CategoriasNombre;
            Z955CategoriasActivo = A955CategoriasActivo;
         }
      }

      protected void standaloneNotModal2X141( )
      {
      }

      protected void standaloneModal2X141( )
      {
         if ( IsIns( )  )
         {
            A953ServiciosCategoriasSerial = (short)(O953ServiciosCategoriasSerial+1);
            AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A931CategoriasId = A953ServiciosCategoriasSerial;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCategoriasId_Enabled = 0;
            AssignProp("", false, edtCategoriasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriasId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
         else
         {
            edtCategoriasId_Enabled = 1;
            AssignProp("", false, edtCategoriasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriasId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
      }

      protected void Load2X141( )
      {
         /* Using cursor T002X17 */
         pr_default.execute(15, new Object[] {n942ServiciosId, A942ServiciosId, A931CategoriasId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound141 = 1;
            A944CategoriasNombre = T002X17_A944CategoriasNombre[0];
            A955CategoriasActivo = T002X17_A955CategoriasActivo[0];
            ZM2X141( -7) ;
         }
         pr_default.close(15);
         OnLoadActions2X141( ) ;
      }

      protected void OnLoadActions2X141( )
      {
      }

      protected void CheckExtendedTable2X141( )
      {
         nIsDirty_141 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal2X141( ) ;
      }

      protected void CloseExtendedTableCursors2X141( )
      {
      }

      protected void enableDisable2X141( )
      {
      }

      protected void GetKey2X141( )
      {
         /* Using cursor T002X18 */
         pr_default.execute(16, new Object[] {n942ServiciosId, A942ServiciosId, A931CategoriasId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound141 = 1;
         }
         else
         {
            RcdFound141 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey2X141( )
      {
         /* Using cursor T002X3 */
         pr_default.execute(1, new Object[] {n942ServiciosId, A942ServiciosId, A931CategoriasId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2X141( 7) ;
            RcdFound141 = 1;
            InitializeNonKey2X141( ) ;
            A931CategoriasId = T002X3_A931CategoriasId[0];
            A944CategoriasNombre = T002X3_A944CategoriasNombre[0];
            A955CategoriasActivo = T002X3_A955CategoriasActivo[0];
            Z942ServiciosId = A942ServiciosId;
            Z931CategoriasId = A931CategoriasId;
            sMode141 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2X141( ) ;
            Gx_mode = sMode141;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound141 = 0;
            InitializeNonKey2X141( ) ;
            sMode141 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal2X141( ) ;
            Gx_mode = sMode141;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2X141( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency2X141( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002X2 */
            pr_default.execute(0, new Object[] {n942ServiciosId, A942ServiciosId, A931CategoriasId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ServiciosCategorias"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z944CategoriasNombre, T002X2_A944CategoriasNombre[0]) != 0 ) || ( Z955CategoriasActivo != T002X2_A955CategoriasActivo[0] ) )
            {
               if ( StringUtil.StrCmp(Z944CategoriasNombre, T002X2_A944CategoriasNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("servicios:[seudo value changed for attri]"+"CategoriasNombre");
                  GXUtil.WriteLogRaw("Old: ",Z944CategoriasNombre);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A944CategoriasNombre[0]);
               }
               if ( Z955CategoriasActivo != T002X2_A955CategoriasActivo[0] )
               {
                  GXUtil.WriteLog("servicios:[seudo value changed for attri]"+"CategoriasActivo");
                  GXUtil.WriteLogRaw("Old: ",Z955CategoriasActivo);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A955CategoriasActivo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ServiciosCategorias"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2X141( )
      {
         BeforeValidate2X141( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2X141( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2X141( 0) ;
            CheckOptimisticConcurrency2X141( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2X141( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2X141( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002X19 */
                     pr_default.execute(17, new Object[] {n942ServiciosId, A942ServiciosId, A931CategoriasId, A944CategoriasNombre, A955CategoriasActivo});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("ServiciosCategorias");
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
               Load2X141( ) ;
            }
            EndLevel2X141( ) ;
         }
         CloseExtendedTableCursors2X141( ) ;
      }

      protected void Update2X141( )
      {
         BeforeValidate2X141( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2X141( ) ;
         }
         if ( ( nIsMod_141 != 0 ) || ( nIsDirty_141 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency2X141( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm2X141( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate2X141( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T002X20 */
                        pr_default.execute(18, new Object[] {A944CategoriasNombre, A955CategoriasActivo, n942ServiciosId, A942ServiciosId, A931CategoriasId});
                        pr_default.close(18);
                        pr_default.SmartCacheProvider.SetUpdated("ServiciosCategorias");
                        if ( (pr_default.getStatus(18) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ServiciosCategorias"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate2X141( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey2X141( ) ;
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
               EndLevel2X141( ) ;
            }
         }
         CloseExtendedTableCursors2X141( ) ;
      }

      protected void DeferredUpdate2X141( )
      {
      }

      protected void Delete2X141( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2X141( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2X141( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2X141( ) ;
            AfterConfirm2X141( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2X141( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002X21 */
                  pr_default.execute(19, new Object[] {n942ServiciosId, A942ServiciosId, A931CategoriasId});
                  pr_default.close(19);
                  pr_default.SmartCacheProvider.SetUpdated("ServiciosCategorias");
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
         sMode141 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2X141( ) ;
         Gx_mode = sMode141;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2X141( )
      {
         standaloneModal2X141( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2X141( )
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

      public void ScanStart2X141( )
      {
         /* Scan By routine */
         /* Using cursor T002X22 */
         pr_default.execute(20, new Object[] {n942ServiciosId, A942ServiciosId});
         RcdFound141 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound141 = 1;
            A931CategoriasId = T002X22_A931CategoriasId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2X141( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound141 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound141 = 1;
            A931CategoriasId = T002X22_A931CategoriasId[0];
         }
      }

      protected void ScanEnd2X141( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm2X141( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2X141( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2X141( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2X141( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2X141( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2X141( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2X141( )
      {
         edtCategoriasId_Enabled = 0;
         AssignProp("", false, edtCategoriasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriasId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtCategoriasNombre_Enabled = 0;
         AssignProp("", false, edtCategoriasNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriasNombre_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         chkCategoriasActivo.Enabled = 0;
         AssignProp("", false, chkCategoriasActivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkCategoriasActivo.Enabled), 5, 0), !bGXsfl_38_Refreshing);
      }

      protected void send_integrity_lvl_hashes2X141( )
      {
      }

      protected void send_integrity_lvl_hashes2X140( )
      {
      }

      protected void SubsflControlProps_38141( )
      {
         edtCategoriasId_Internalname = "CATEGORIASID_"+sGXsfl_38_idx;
         edtCategoriasNombre_Internalname = "CATEGORIASNOMBRE_"+sGXsfl_38_idx;
         chkCategoriasActivo_Internalname = "CATEGORIASACTIVO_"+sGXsfl_38_idx;
      }

      protected void SubsflControlProps_fel_38141( )
      {
         edtCategoriasId_Internalname = "CATEGORIASID_"+sGXsfl_38_fel_idx;
         edtCategoriasNombre_Internalname = "CATEGORIASNOMBRE_"+sGXsfl_38_fel_idx;
         chkCategoriasActivo_Internalname = "CATEGORIASACTIVO_"+sGXsfl_38_fel_idx;
      }

      protected void AddRow2X141( )
      {
         nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_38141( ) ;
         SendRow2X141( ) ;
      }

      protected void SendRow2X141( )
      {
         Gridlevel_categoriasRow = GXWebRow.GetNew(context);
         if ( subGridlevel_categorias_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_categorias_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_categorias_Class, "") != 0 )
            {
               subGridlevel_categorias_Linesclass = subGridlevel_categorias_Class+"Odd";
            }
         }
         else if ( subGridlevel_categorias_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_categorias_Backstyle = 0;
            subGridlevel_categorias_Backcolor = subGridlevel_categorias_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_categorias_Class, "") != 0 )
            {
               subGridlevel_categorias_Linesclass = subGridlevel_categorias_Class+"Uniform";
            }
         }
         else if ( subGridlevel_categorias_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_categorias_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_categorias_Class, "") != 0 )
            {
               subGridlevel_categorias_Linesclass = subGridlevel_categorias_Class+"Odd";
            }
            subGridlevel_categorias_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_categorias_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_categorias_Backstyle = 1;
            if ( ((int)((nGXsfl_38_idx) % (2))) == 0 )
            {
               subGridlevel_categorias_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_categorias_Class, "") != 0 )
               {
                  subGridlevel_categorias_Linesclass = subGridlevel_categorias_Class+"Even";
               }
            }
            else
            {
               subGridlevel_categorias_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_categorias_Class, "") != 0 )
               {
                  subGridlevel_categorias_Linesclass = subGridlevel_categorias_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_141_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_categoriasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoriasId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A931CategoriasId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A931CategoriasId), "ZZZZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoriasId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCategoriasId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_141_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_categoriasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoriasNombre_Internalname,StringUtil.RTrim( A944CategoriasNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoriasNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCategoriasNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Check box */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_141_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "CATEGORIASACTIVO_" + sGXsfl_38_idx;
         chkCategoriasActivo.Name = GXCCtl;
         chkCategoriasActivo.WebTags = "";
         chkCategoriasActivo.Caption = "";
         AssignProp("", false, chkCategoriasActivo_Internalname, "TitleCaption", chkCategoriasActivo.Caption, !bGXsfl_38_Refreshing);
         chkCategoriasActivo.CheckedValue = "false";
         A955CategoriasActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A955CategoriasActivo));
         Gridlevel_categoriasRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkCategoriasActivo_Internalname,StringUtil.BoolToStr( A955CategoriasActivo),(string)"",(string)"",(short)-1,chkCategoriasActivo.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(41, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,41);\""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_categoriasRow);
         send_integrity_lvl_hashes2X141( ) ;
         GXCCtl = "Z931CategoriasId_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z931CategoriasId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z944CategoriasNombre_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z944CategoriasNombre));
         GXCCtl = "Z955CategoriasActivo_" + sGXsfl_38_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z955CategoriasActivo);
         GXCCtl = "nRcdDeleted_141_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_141), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_141_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_141), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_141_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_141), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_38_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vSERVICIOSID_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ServiciosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CATEGORIASID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriasId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CATEGORIASNOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriasNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CATEGORIASACTIVO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkCategoriasActivo.Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_categoriasContainer.AddRow(Gridlevel_categoriasRow);
      }

      protected void ReadRow2X141( )
      {
         nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_38141( ) ;
         edtCategoriasId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORIASID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCategoriasNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORIASNOMBRE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         chkCategoriasActivo.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORIASACTIVO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtCategoriasId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCategoriasId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "CATEGORIASID_" + sGXsfl_38_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCategoriasId_Internalname;
            wbErr = true;
            A931CategoriasId = 0;
         }
         else
         {
            A931CategoriasId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCategoriasId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A944CategoriasNombre = cgiGet( edtCategoriasNombre_Internalname);
         A955CategoriasActivo = StringUtil.StrToBool( cgiGet( chkCategoriasActivo_Internalname));
         GXCCtl = "Z931CategoriasId_" + sGXsfl_38_idx;
         Z931CategoriasId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z944CategoriasNombre_" + sGXsfl_38_idx;
         Z944CategoriasNombre = cgiGet( GXCCtl);
         GXCCtl = "Z955CategoriasActivo_" + sGXsfl_38_idx;
         Z955CategoriasActivo = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "nRcdDeleted_141_" + sGXsfl_38_idx;
         nRcdDeleted_141 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_141_" + sGXsfl_38_idx;
         nRcdExists_141 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_141_" + sGXsfl_38_idx;
         nIsMod_141 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtCategoriasId_Enabled = edtCategoriasId_Enabled;
      }

      protected void ConfirmValues2X0( )
      {
         nGXsfl_38_idx = 0;
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_38141( ) ;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_38141( ) ;
            ChangePostValue( "Z931CategoriasId_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z931CategoriasId_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z931CategoriasId_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z944CategoriasNombre_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z944CategoriasNombre_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z944CategoriasNombre_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z955CategoriasActivo_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z955CategoriasActivo_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z955CategoriasActivo_"+sGXsfl_38_idx) ;
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
         GXEncryptionTmp = "servicios.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ServiciosId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("servicios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Servicios");
         forbiddenHiddens.Add("ServiciosId", context.localUtil.Format( (decimal)(A942ServiciosId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("servicios:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z942ServiciosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z942ServiciosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z943ServiciosNombre", StringUtil.RTrim( Z943ServiciosNombre));
         GxWebStd.gx_hidden_field( context, "Z953ServiciosCategoriasSerial", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z953ServiciosCategoriasSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z954ServiciosActivo", Z954ServiciosActivo);
         GxWebStd.gx_hidden_field( context, "O953ServiciosCategoriasSerial", StringUtil.LTrim( StringUtil.NToC( (decimal)(O953ServiciosCategoriasSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_38", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_38_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vSERVICIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ServiciosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSERVICIOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ServiciosId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SERVICIOSCATEGORIASSERIAL", StringUtil.LTrim( StringUtil.NToC( (decimal)(A953ServiciosCategoriasSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GXEncryptionTmp = "servicios.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ServiciosId,18,0));
         return formatLink("servicios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Servicios" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Servicios", "") ;
      }

      protected void InitializeNonKey2X140( )
      {
         A943ServiciosNombre = "";
         AssignAttri("", false, "A943ServiciosNombre", A943ServiciosNombre);
         A953ServiciosCategoriasSerial = 0;
         AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
         A954ServiciosActivo = true;
         AssignAttri("", false, "A954ServiciosActivo", A954ServiciosActivo);
         O953ServiciosCategoriasSerial = A953ServiciosCategoriasSerial;
         AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
         Z943ServiciosNombre = "";
         Z953ServiciosCategoriasSerial = 0;
         Z954ServiciosActivo = false;
      }

      protected void InitAll2X140( )
      {
         A942ServiciosId = 0;
         n942ServiciosId = false;
         AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
         InitializeNonKey2X140( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A954ServiciosActivo = i954ServiciosActivo;
         AssignAttri("", false, "A954ServiciosActivo", A954ServiciosActivo);
      }

      protected void InitializeNonKey2X141( )
      {
         A944CategoriasNombre = "";
         A955CategoriasActivo = false;
         Z944CategoriasNombre = "";
         Z955CategoriasActivo = false;
      }

      protected void InitAll2X141( )
      {
         A931CategoriasId = 0;
         InitializeNonKey2X141( ) ;
      }

      protected void StandaloneModalInsert2X141( )
      {
         A953ServiciosCategoriasSerial = i953ServiciosCategoriasSerial;
         AssignAttri("", false, "A953ServiciosCategoriasSerial", StringUtil.LTrimStr( (decimal)(A953ServiciosCategoriasSerial), 4, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320111021", true, true, false);
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
         context.AddJavascriptSource("servicios.js", "?20269320111022", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties141( )
      {
         edtCategoriasId_Enabled = defedtCategoriasId_Enabled;
         AssignProp("", false, edtCategoriasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriasId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
      }

      protected void StartGridControl38( )
      {
         Gridlevel_categoriasContainer.AddObjectProperty("GridName", "Gridlevel_categorias");
         Gridlevel_categoriasContainer.AddObjectProperty("Header", subGridlevel_categorias_Header);
         Gridlevel_categoriasContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_categoriasContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_categoriasContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_categoriasContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_categorias_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_categoriasContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_categoriasContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_categoriasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_categoriasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A931CategoriasId), 18, 0, ".", ""))));
         Gridlevel_categoriasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriasId_Enabled), 5, 0, ".", "")));
         Gridlevel_categoriasContainer.AddColumnProperties(Gridlevel_categoriasColumn);
         Gridlevel_categoriasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_categoriasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A944CategoriasNombre)));
         Gridlevel_categoriasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriasNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_categoriasContainer.AddColumnProperties(Gridlevel_categoriasColumn);
         Gridlevel_categoriasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_categoriasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A955CategoriasActivo)));
         Gridlevel_categoriasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkCategoriasActivo.Enabled), 5, 0, ".", "")));
         Gridlevel_categoriasContainer.AddColumnProperties(Gridlevel_categoriasColumn);
         Gridlevel_categoriasContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_categorias_Selectedindex), 4, 0, ".", "")));
         Gridlevel_categoriasContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_categorias_Allowselection), 1, 0, ".", "")));
         Gridlevel_categoriasContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_categorias_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_categoriasContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_categorias_Allowhovering), 1, 0, ".", "")));
         Gridlevel_categoriasContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_categorias_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_categoriasContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_categorias_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_categoriasContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_categorias_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtServiciosId_Internalname = "SERVICIOSID";
         edtServiciosNombre_Internalname = "SERVICIOSNOMBRE";
         cmbServiciosActivo_Internalname = "SERVICIOSACTIVO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtCategoriasId_Internalname = "CATEGORIASID";
         edtCategoriasNombre_Internalname = "CATEGORIASNOMBRE";
         chkCategoriasActivo_Internalname = "CATEGORIASACTIVO";
         divTableleaflevel_categorias_Internalname = "TABLELEAFLEVEL_CATEGORIAS";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_categorias_Internalname = "GRIDLEVEL_CATEGORIAS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_categorias_Allowcollapsing = 0;
         subGridlevel_categorias_Allowselection = 0;
         subGridlevel_categorias_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Servicios", "");
         chkCategoriasActivo.Caption = "";
         edtCategoriasNombre_Jsonclick = "";
         edtCategoriasId_Jsonclick = "";
         subGridlevel_categorias_Class = "WorkWith";
         subGridlevel_categorias_Backcolorstyle = 0;
         chkCategoriasActivo.Enabled = 1;
         edtCategoriasNombre_Enabled = 1;
         edtCategoriasId_Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbServiciosActivo_Jsonclick = "";
         cmbServiciosActivo.Enabled = 1;
         edtServiciosNombre_Jsonclick = "";
         edtServiciosNombre_Enabled = 1;
         edtServiciosId_Jsonclick = "";
         edtServiciosId_Enabled = 0;
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

      protected void gxnrGridlevel_categorias_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_38141( ) ;
         while ( nGXsfl_38_idx <= nRC_GXsfl_38 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal2X141( ) ;
            standaloneModal2X141( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow2X141( ) ;
            nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_38141( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_categoriasContainer)) ;
         /* End function gxnrGridlevel_categorias_newrow */
      }

      protected void init_web_controls( )
      {
         cmbServiciosActivo.Name = "SERVICIOSACTIVO";
         cmbServiciosActivo.WebTags = "";
         cmbServiciosActivo.addItem(StringUtil.BoolToStr( true), context.GetMessage( "true", ""), 0);
         cmbServiciosActivo.addItem(StringUtil.BoolToStr( false), context.GetMessage( "false", ""), 0);
         if ( cmbServiciosActivo.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A954ServiciosActivo) )
            {
               A954ServiciosActivo = true;
               AssignAttri("", false, "A954ServiciosActivo", A954ServiciosActivo);
            }
         }
         GXCCtl = "CATEGORIASACTIVO_" + sGXsfl_38_idx;
         chkCategoriasActivo.Name = GXCCtl;
         chkCategoriasActivo.WebTags = "";
         chkCategoriasActivo.Caption = "";
         AssignProp("", false, chkCategoriasActivo_Internalname, "TitleCaption", chkCategoriasActivo.Caption, !bGXsfl_38_Refreshing);
         chkCategoriasActivo.CheckedValue = "false";
         A955CategoriasActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A955CategoriasActivo));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7ServiciosId',fld:'vSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ServiciosId',fld:'vSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A942ServiciosId',fld:'SERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E122X2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_SERVICIOSID","{handler:'Valid_Serviciosid',iparms:[]");
         setEventMetadata("VALID_SERVICIOSID",",oparms:[]}");
         setEventMetadata("VALID_CATEGORIASID","{handler:'Valid_Categoriasid',iparms:[]");
         setEventMetadata("VALID_CATEGORIASID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Categoriasactivo',iparms:[]");
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
         Z943ServiciosNombre = "";
         Z944CategoriasNombre = "";
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
         A943ServiciosNombre = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_categoriasContainer = new GXWebGrid( context);
         sMode141 = "";
         sStyleString = "";
         AV14Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode140 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A944CategoriasNombre = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T002X6_A942ServiciosId = new long[1] ;
         T002X6_n942ServiciosId = new bool[] {false} ;
         T002X6_A943ServiciosNombre = new string[] {""} ;
         T002X6_A953ServiciosCategoriasSerial = new short[1] ;
         T002X6_A954ServiciosActivo = new bool[] {false} ;
         T002X7_A942ServiciosId = new long[1] ;
         T002X7_n942ServiciosId = new bool[] {false} ;
         T002X5_A942ServiciosId = new long[1] ;
         T002X5_n942ServiciosId = new bool[] {false} ;
         T002X5_A943ServiciosNombre = new string[] {""} ;
         T002X5_A953ServiciosCategoriasSerial = new short[1] ;
         T002X5_A954ServiciosActivo = new bool[] {false} ;
         T002X8_A942ServiciosId = new long[1] ;
         T002X8_n942ServiciosId = new bool[] {false} ;
         T002X9_A942ServiciosId = new long[1] ;
         T002X9_n942ServiciosId = new bool[] {false} ;
         T002X4_A942ServiciosId = new long[1] ;
         T002X4_n942ServiciosId = new bool[] {false} ;
         T002X4_A943ServiciosNombre = new string[] {""} ;
         T002X4_A953ServiciosCategoriasSerial = new short[1] ;
         T002X4_A954ServiciosActivo = new bool[] {false} ;
         T002X10_A942ServiciosId = new long[1] ;
         T002X10_n942ServiciosId = new bool[] {false} ;
         T002X13_A120ProfesionalesId = new string[] {""} ;
         T002X13_A993ProfesionalServicioId = new long[1] ;
         T002X14_A422PostulacionesId = new long[1] ;
         T002X16_A942ServiciosId = new long[1] ;
         T002X16_n942ServiciosId = new bool[] {false} ;
         T002X17_A942ServiciosId = new long[1] ;
         T002X17_n942ServiciosId = new bool[] {false} ;
         T002X17_A931CategoriasId = new long[1] ;
         T002X17_A944CategoriasNombre = new string[] {""} ;
         T002X17_A955CategoriasActivo = new bool[] {false} ;
         T002X18_A942ServiciosId = new long[1] ;
         T002X18_n942ServiciosId = new bool[] {false} ;
         T002X18_A931CategoriasId = new long[1] ;
         T002X3_A942ServiciosId = new long[1] ;
         T002X3_n942ServiciosId = new bool[] {false} ;
         T002X3_A931CategoriasId = new long[1] ;
         T002X3_A944CategoriasNombre = new string[] {""} ;
         T002X3_A955CategoriasActivo = new bool[] {false} ;
         T002X2_A942ServiciosId = new long[1] ;
         T002X2_n942ServiciosId = new bool[] {false} ;
         T002X2_A931CategoriasId = new long[1] ;
         T002X2_A944CategoriasNombre = new string[] {""} ;
         T002X2_A955CategoriasActivo = new bool[] {false} ;
         T002X22_A942ServiciosId = new long[1] ;
         T002X22_n942ServiciosId = new bool[] {false} ;
         T002X22_A931CategoriasId = new long[1] ;
         Gridlevel_categoriasRow = new GXWebRow();
         subGridlevel_categorias_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_categoriasColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.servicios__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.servicios__default(),
            new Object[][] {
                new Object[] {
               T002X2_A942ServiciosId, T002X2_A931CategoriasId, T002X2_A944CategoriasNombre, T002X2_A955CategoriasActivo
               }
               , new Object[] {
               T002X3_A942ServiciosId, T002X3_A931CategoriasId, T002X3_A944CategoriasNombre, T002X3_A955CategoriasActivo
               }
               , new Object[] {
               T002X4_A942ServiciosId, T002X4_A943ServiciosNombre, T002X4_A953ServiciosCategoriasSerial, T002X4_A954ServiciosActivo
               }
               , new Object[] {
               T002X5_A942ServiciosId, T002X5_A943ServiciosNombre, T002X5_A953ServiciosCategoriasSerial, T002X5_A954ServiciosActivo
               }
               , new Object[] {
               T002X6_A942ServiciosId, T002X6_A943ServiciosNombre, T002X6_A953ServiciosCategoriasSerial, T002X6_A954ServiciosActivo
               }
               , new Object[] {
               T002X7_A942ServiciosId
               }
               , new Object[] {
               T002X8_A942ServiciosId
               }
               , new Object[] {
               T002X9_A942ServiciosId
               }
               , new Object[] {
               T002X10_A942ServiciosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002X13_A120ProfesionalesId, T002X13_A993ProfesionalServicioId
               }
               , new Object[] {
               T002X14_A422PostulacionesId
               }
               , new Object[] {
               }
               , new Object[] {
               T002X16_A942ServiciosId
               }
               , new Object[] {
               T002X17_A942ServiciosId, T002X17_A931CategoriasId, T002X17_A944CategoriasNombre, T002X17_A955CategoriasActivo
               }
               , new Object[] {
               T002X18_A942ServiciosId, T002X18_A931CategoriasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002X22_A942ServiciosId, T002X22_A931CategoriasId
               }
            }
         );
         Z954ServiciosActivo = true;
         A954ServiciosActivo = true;
         i954ServiciosActivo = true;
         AV14Pgmname = "Servicios";
      }

      private short Z953ServiciosCategoriasSerial ;
      private short O953ServiciosCategoriasSerial ;
      private short nRcdDeleted_141 ;
      private short nRcdExists_141 ;
      private short nIsMod_141 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A953ServiciosCategoriasSerial ;
      private short Gx_BScreen ;
      private short nBlankRcdCount141 ;
      private short RcdFound141 ;
      private short B953ServiciosCategoriasSerial ;
      private short nBlankRcdUsr141 ;
      private short RcdFound140 ;
      private short s953ServiciosCategoriasSerial ;
      private short nIsDirty_141 ;
      private short subGridlevel_categorias_Backcolorstyle ;
      private short subGridlevel_categorias_Backstyle ;
      private short gxajaxcallmode ;
      private short i953ServiciosCategoriasSerial ;
      private short subGridlevel_categorias_Allowselection ;
      private short subGridlevel_categorias_Allowhovering ;
      private short subGridlevel_categorias_Allowcollapsing ;
      private short subGridlevel_categorias_Collapsed ;
      private int nRC_GXsfl_38 ;
      private int nGXsfl_38_idx=1 ;
      private int trnEnded ;
      private int edtServiciosId_Enabled ;
      private int edtServiciosNombre_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtCategoriasId_Enabled ;
      private int edtCategoriasNombre_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int subGridlevel_categorias_Backcolor ;
      private int subGridlevel_categorias_Allbackcolor ;
      private int defedtCategoriasId_Enabled ;
      private int idxLst ;
      private int subGridlevel_categorias_Selectedindex ;
      private int subGridlevel_categorias_Selectioncolor ;
      private int subGridlevel_categorias_Hoveringcolor ;
      private long wcpOAV7ServiciosId ;
      private long Z942ServiciosId ;
      private long Z931CategoriasId ;
      private long AV7ServiciosId ;
      private long A942ServiciosId ;
      private long GRIDLEVEL_CATEGORIAS_nFirstRecordOnPage ;
      private long A931CategoriasId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z943ServiciosNombre ;
      private string Z944CategoriasNombre ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtServiciosNombre_Internalname ;
      private string sGXsfl_38_idx="0001" ;
      private string cmbServiciosActivo_Internalname ;
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
      private string edtServiciosId_Internalname ;
      private string TempTags ;
      private string edtServiciosId_Jsonclick ;
      private string A943ServiciosNombre ;
      private string edtServiciosNombre_Jsonclick ;
      private string cmbServiciosActivo_Jsonclick ;
      private string divTableleaflevel_categorias_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode141 ;
      private string edtCategoriasId_Internalname ;
      private string edtCategoriasNombre_Internalname ;
      private string chkCategoriasActivo_Internalname ;
      private string sStyleString ;
      private string subGridlevel_categorias_Internalname ;
      private string AV14Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode140 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A944CategoriasNombre ;
      private string GXEncryptionTmp ;
      private string sGXsfl_38_fel_idx="0001" ;
      private string subGridlevel_categorias_Class ;
      private string subGridlevel_categorias_Linesclass ;
      private string ROClassString ;
      private string edtCategoriasId_Jsonclick ;
      private string edtCategoriasNombre_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_categorias_Header ;
      private bool Z954ServiciosActivo ;
      private bool Z955CategoriasActivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A954ServiciosActivo ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool bGXsfl_38_Refreshing=false ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n942ServiciosId ;
      private bool A955CategoriasActivo ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool i954ServiciosActivo ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_categoriasContainer ;
      private GXWebRow Gridlevel_categoriasRow ;
      private GXWebColumn Gridlevel_categoriasColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbServiciosActivo ;
      private GXCheckbox chkCategoriasActivo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] T002X6_A942ServiciosId ;
      private bool[] T002X6_n942ServiciosId ;
      private string[] T002X6_A943ServiciosNombre ;
      private short[] T002X6_A953ServiciosCategoriasSerial ;
      private bool[] T002X6_A954ServiciosActivo ;
      private long[] T002X7_A942ServiciosId ;
      private bool[] T002X7_n942ServiciosId ;
      private long[] T002X5_A942ServiciosId ;
      private bool[] T002X5_n942ServiciosId ;
      private string[] T002X5_A943ServiciosNombre ;
      private short[] T002X5_A953ServiciosCategoriasSerial ;
      private bool[] T002X5_A954ServiciosActivo ;
      private long[] T002X8_A942ServiciosId ;
      private bool[] T002X8_n942ServiciosId ;
      private long[] T002X9_A942ServiciosId ;
      private bool[] T002X9_n942ServiciosId ;
      private long[] T002X4_A942ServiciosId ;
      private bool[] T002X4_n942ServiciosId ;
      private string[] T002X4_A943ServiciosNombre ;
      private short[] T002X4_A953ServiciosCategoriasSerial ;
      private bool[] T002X4_A954ServiciosActivo ;
      private long[] T002X10_A942ServiciosId ;
      private bool[] T002X10_n942ServiciosId ;
      private string[] T002X13_A120ProfesionalesId ;
      private long[] T002X13_A993ProfesionalServicioId ;
      private long[] T002X14_A422PostulacionesId ;
      private long[] T002X16_A942ServiciosId ;
      private bool[] T002X16_n942ServiciosId ;
      private long[] T002X17_A942ServiciosId ;
      private bool[] T002X17_n942ServiciosId ;
      private long[] T002X17_A931CategoriasId ;
      private string[] T002X17_A944CategoriasNombre ;
      private bool[] T002X17_A955CategoriasActivo ;
      private long[] T002X18_A942ServiciosId ;
      private bool[] T002X18_n942ServiciosId ;
      private long[] T002X18_A931CategoriasId ;
      private long[] T002X3_A942ServiciosId ;
      private bool[] T002X3_n942ServiciosId ;
      private long[] T002X3_A931CategoriasId ;
      private string[] T002X3_A944CategoriasNombre ;
      private bool[] T002X3_A955CategoriasActivo ;
      private long[] T002X2_A942ServiciosId ;
      private bool[] T002X2_n942ServiciosId ;
      private long[] T002X2_A931CategoriasId ;
      private string[] T002X2_A944CategoriasNombre ;
      private bool[] T002X2_A955CategoriasActivo ;
      private long[] T002X22_A942ServiciosId ;
      private bool[] T002X22_n942ServiciosId ;
      private long[] T002X22_A931CategoriasId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class servicios__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class servicios__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new ForEachCursor(def[20])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002X2;
        prmT002X2 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmT002X3;
        prmT002X3 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmT002X4;
        prmT002X4 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002X5;
        prmT002X5 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002X6;
        prmT002X6 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002X7;
        prmT002X7 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002X8;
        prmT002X8 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002X9;
        prmT002X9 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002X10;
        prmT002X10 = new Object[] {
        new ParDef("@ServiciosNombre",GXType.NChar,80,0) ,
        new ParDef("@ServiciosCategoriasSerial",GXType.Int16,4,0) ,
        new ParDef("@ServiciosActivo",GXType.Boolean,3,0)
        };
        Object[] prmT002X11;
        prmT002X11 = new Object[] {
        new ParDef("@ServiciosNombre",GXType.NChar,80,0) ,
        new ParDef("@ServiciosCategoriasSerial",GXType.Int16,4,0) ,
        new ParDef("@ServiciosActivo",GXType.Boolean,3,0) ,
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002X12;
        prmT002X12 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002X13;
        prmT002X13 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002X14;
        prmT002X14 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002X15;
        prmT002X15 = new Object[] {
        new ParDef("@ServiciosCategoriasSerial",GXType.Int16,4,0) ,
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002X16;
        prmT002X16 = new Object[] {
        };
        Object[] prmT002X17;
        prmT002X17 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmT002X18;
        prmT002X18 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmT002X19;
        prmT002X19 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0) ,
        new ParDef("@CategoriasNombre",GXType.NChar,80,0) ,
        new ParDef("@CategoriasActivo",GXType.Boolean,4,0)
        };
        Object[] prmT002X20;
        prmT002X20 = new Object[] {
        new ParDef("@CategoriasNombre",GXType.NChar,80,0) ,
        new ParDef("@CategoriasActivo",GXType.Boolean,4,0) ,
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmT002X21;
        prmT002X21 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmT002X22;
        prmT002X22 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T002X2", "SELECT [ServiciosId], [CategoriasId], [CategoriasNombre], [CategoriasActivo] FROM [ServiciosCategorias] WITH (UPDLOCK) WHERE [ServiciosId] = @ServiciosId AND [CategoriasId] = @CategoriasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X3", "SELECT [ServiciosId], [CategoriasId], [CategoriasNombre], [CategoriasActivo] FROM [ServiciosCategorias] WHERE [ServiciosId] = @ServiciosId AND [CategoriasId] = @CategoriasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X4", "SELECT [ServiciosId], [ServiciosNombre], [ServiciosCategoriasSerial], [ServiciosActivo] FROM [Servicios] WITH (UPDLOCK) WHERE [ServiciosId] = @ServiciosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X5", "SELECT [ServiciosId], [ServiciosNombre], [ServiciosCategoriasSerial], [ServiciosActivo] FROM [Servicios] WHERE [ServiciosId] = @ServiciosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X6", "SELECT TM1.[ServiciosId], TM1.[ServiciosNombre], TM1.[ServiciosCategoriasSerial], TM1.[ServiciosActivo] FROM [Servicios] TM1 WHERE TM1.[ServiciosId] = @ServiciosId ORDER BY TM1.[ServiciosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002X6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X7", "SELECT [ServiciosId] FROM [Servicios] WHERE [ServiciosId] = @ServiciosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002X7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X8", "SELECT TOP 1 [ServiciosId] FROM [Servicios] WHERE ( [ServiciosId] > @ServiciosId) ORDER BY [ServiciosId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002X8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002X9", "SELECT TOP 1 [ServiciosId] FROM [Servicios] WHERE ( [ServiciosId] < @ServiciosId) ORDER BY [ServiciosId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002X9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002X10", "INSERT INTO [Servicios]([ServiciosNombre], [ServiciosCategoriasSerial], [ServiciosActivo]) VALUES(@ServiciosNombre, @ServiciosCategoriasSerial, @ServiciosActivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT002X10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002X11", "UPDATE [Servicios] SET [ServiciosNombre]=@ServiciosNombre, [ServiciosCategoriasSerial]=@ServiciosCategoriasSerial, [ServiciosActivo]=@ServiciosActivo  WHERE [ServiciosId] = @ServiciosId", GxErrorMask.GX_NOMASK,prmT002X11)
           ,new CursorDef("T002X12", "DELETE FROM [Servicios]  WHERE [ServiciosId] = @ServiciosId", GxErrorMask.GX_NOMASK,prmT002X12)
           ,new CursorDef("T002X13", "SELECT TOP 1 [ProfesionalesId], [ProfesionalServicioId] FROM [ProfesionalesServicios] WHERE [ProfesionalServicioId] = @ServiciosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002X14", "SELECT TOP 1 [PostulacionesId] FROM [Postulaciones] WHERE [ServiciosId] = @ServiciosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002X15", "UPDATE [Servicios] SET [ServiciosCategoriasSerial]=@ServiciosCategoriasSerial  WHERE [ServiciosId] = @ServiciosId", GxErrorMask.GX_NOMASK,prmT002X15)
           ,new CursorDef("T002X16", "SELECT [ServiciosId] FROM [Servicios] ORDER BY [ServiciosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002X16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X17", "SELECT [ServiciosId], [CategoriasId], [CategoriasNombre], [CategoriasActivo] FROM [ServiciosCategorias] WHERE [ServiciosId] = @ServiciosId and [CategoriasId] = @CategoriasId ORDER BY [ServiciosId], [CategoriasId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X17,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X18", "SELECT [ServiciosId], [CategoriasId] FROM [ServiciosCategorias] WHERE [ServiciosId] = @ServiciosId AND [CategoriasId] = @CategoriasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X19", "INSERT INTO [ServiciosCategorias]([ServiciosId], [CategoriasId], [CategoriasNombre], [CategoriasActivo]) VALUES(@ServiciosId, @CategoriasId, @CategoriasNombre, @CategoriasActivo)", GxErrorMask.GX_NOMASK,prmT002X19)
           ,new CursorDef("T002X20", "UPDATE [ServiciosCategorias] SET [CategoriasNombre]=@CategoriasNombre, [CategoriasActivo]=@CategoriasActivo  WHERE [ServiciosId] = @ServiciosId AND [CategoriasId] = @CategoriasId", GxErrorMask.GX_NOMASK,prmT002X20)
           ,new CursorDef("T002X21", "DELETE FROM [ServiciosCategorias]  WHERE [ServiciosId] = @ServiciosId AND [CategoriasId] = @CategoriasId", GxErrorMask.GX_NOMASK,prmT002X21)
           ,new CursorDef("T002X22", "SELECT [ServiciosId], [CategoriasId] FROM [ServiciosCategorias] WHERE [ServiciosId] = @ServiciosId ORDER BY [ServiciosId], [CategoriasId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X22,11, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
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
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
  }

}

}
