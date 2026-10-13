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
   public class rubros : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rubros.aspx")), "rubros.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rubros.aspx")))) ;
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
                  AV7RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7RubrosId", StringUtil.LTrimStr( (decimal)(AV7RubrosId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vRUBROSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RubrosId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Rubros", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtRubrosNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public rubros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public rubros( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_RubrosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7RubrosId = aP1_RubrosId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkRubrosDefault = new GXCheckbox();
         cmbRubrosEstado = new GXCombobox();
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
         A501RubrosDefault = StringUtil.StrToBool( StringUtil.BoolToStr( A501RubrosDefault));
         n501RubrosDefault = false;
         AssignAttri("", false, "A501RubrosDefault", A501RubrosDefault);
         if ( cmbRubrosEstado.ItemCount > 0 )
         {
            A123RubrosEstado = cmbRubrosEstado.getValidValue(A123RubrosEstado);
            n123RubrosEstado = false;
            AssignAttri("", false, "A123RubrosEstado", A123RubrosEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbRubrosEstado.CurrentValue = StringUtil.RTrim( A123RubrosEstado);
            AssignProp("", false, cmbRubrosEstado_Internalname, "Values", cmbRubrosEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRubrosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubrosId_Internalname, context.GetMessage( "Código del Rubro", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtRubrosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9") : context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubrosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRubrosId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Rubros.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRubrosNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubrosNombre_Internalname, context.GetMessage( "Nombre del Rubro", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubrosNombre_Internalname, StringUtil.RTrim( A122RubrosNombre), StringUtil.RTrim( context.localUtil.Format( A122RubrosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubrosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRubrosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Rubros.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgRubrosImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A168RubrosImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000RubrosImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.PathToRelativeUrl( A168RubrosImagen));
         GxWebStd.gx_bitmap( context, imgRubrosImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgRubrosImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", "", "", 0, A168RubrosImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_Rubros.htm");
         AssignProp("", false, imgRubrosImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.PathToRelativeUrl( A168RubrosImagen)), true);
         AssignProp("", false, imgRubrosImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A168RubrosImagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkRubrosDefault_Internalname, context.GetMessage( "Default", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkRubrosDefault_Internalname, StringUtil.BoolToStr( A501RubrosDefault), "", context.GetMessage( "Default", ""), 1, chkRubrosDefault.Enabled, "true", context.GetMessage( "Rubro por defecto", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(36, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,36);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbRubrosEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbRubrosEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbRubrosEstado, cmbRubrosEstado_Internalname, StringUtil.RTrim( A123RubrosEstado), 1, cmbRubrosEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbRubrosEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_Rubros.htm");
         cmbRubrosEstado.CurrentValue = StringUtil.RTrim( A123RubrosEstado);
         AssignProp("", false, cmbRubrosEstado_Internalname, "Values", (string)(cmbRubrosEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRubrosImagenURL_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubrosImagenURL_Internalname, context.GetMessage( "Imagen URL", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubrosImagenURL_Internalname, A896RubrosImagenURL, StringUtil.RTrim( context.localUtil.Format( A896RubrosImagenURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", A896RubrosImagenURL, "_blank", "", "", edtRubrosImagenURL_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRubrosImagenURL_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_Rubros.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Rubros.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Rubros.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Rubros.htm");
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
         E110T2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z121RubrosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z122RubrosNombre = cgiGet( "Z122RubrosNombre");
               Z501RubrosDefault = StringUtil.StrToBool( cgiGet( "Z501RubrosDefault"));
               n501RubrosDefault = ((false==A501RubrosDefault) ? true : false);
               Z123RubrosEstado = cgiGet( "Z123RubrosEstado");
               n123RubrosEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A123RubrosEstado)) ? true : false);
               Z896RubrosImagenURL = cgiGet( "Z896RubrosImagenURL");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A40000RubrosImagen_GXI = cgiGet( "RUBROSIMAGEN_GXI");
               AV15Pgmname = cgiGet( "vPGMNAME");
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
               A121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
               A122RubrosNombre = cgiGet( edtRubrosNombre_Internalname);
               AssignAttri("", false, "A122RubrosNombre", A122RubrosNombre);
               A168RubrosImagen = cgiGet( imgRubrosImagen_Internalname);
               AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
               A501RubrosDefault = StringUtil.StrToBool( cgiGet( chkRubrosDefault_Internalname));
               n501RubrosDefault = false;
               AssignAttri("", false, "A501RubrosDefault", A501RubrosDefault);
               n501RubrosDefault = ((false==A501RubrosDefault) ? true : false);
               cmbRubrosEstado.CurrentValue = cgiGet( cmbRubrosEstado_Internalname);
               A123RubrosEstado = cgiGet( cmbRubrosEstado_Internalname);
               n123RubrosEstado = false;
               AssignAttri("", false, "A123RubrosEstado", A123RubrosEstado);
               n123RubrosEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A123RubrosEstado)) ? true : false);
               A896RubrosImagenURL = cgiGet( edtRubrosImagenURL_Internalname);
               AssignAttri("", false, "A896RubrosImagenURL", A896RubrosImagenURL);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgRubrosImagen_Internalname, ref  A168RubrosImagen, ref  A40000RubrosImagen_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Rubros");
               A121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
               forbiddenHiddens.Add("RubrosId", context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A121RubrosId != Z121RubrosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("rubros:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
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
                     sMode37 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode37;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound37 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0T0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "RUBROSID");
                        AnyError = 1;
                        GX_FocusControl = edtRubrosId_Internalname;
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
                           E110T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120T2 ();
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
            E120T2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0T37( ) ;
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
            DisableAttributes0T37( ) ;
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

      protected void CONFIRM_0T0( )
      {
         BeforeValidate0T37( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0T37( ) ;
            }
            else
            {
               CheckExtendedTable0T37( ) ;
               CloseExtendedTableCursors0T37( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0T0( )
      {
      }

      protected void E110T2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV12WWPContext) ;
         AV8IsAuthorized = true;
         AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWRubros_Insert", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWRubros_Update", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWRubros_Delete", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV15Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E120T2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("rubrosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0T37( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z122RubrosNombre = T000T3_A122RubrosNombre[0];
               Z501RubrosDefault = T000T3_A501RubrosDefault[0];
               Z123RubrosEstado = T000T3_A123RubrosEstado[0];
               Z896RubrosImagenURL = T000T3_A896RubrosImagenURL[0];
            }
            else
            {
               Z122RubrosNombre = A122RubrosNombre;
               Z501RubrosDefault = A501RubrosDefault;
               Z123RubrosEstado = A123RubrosEstado;
               Z896RubrosImagenURL = A896RubrosImagenURL;
            }
         }
         if ( GX_JID == -6 )
         {
            Z121RubrosId = A121RubrosId;
            Z122RubrosNombre = A122RubrosNombre;
            Z168RubrosImagen = A168RubrosImagen;
            Z40000RubrosImagen_GXI = A40000RubrosImagen_GXI;
            Z501RubrosDefault = A501RubrosDefault;
            Z123RubrosEstado = A123RubrosEstado;
            Z896RubrosImagenURL = A896RubrosImagenURL;
         }
      }

      protected void standaloneNotModal( )
      {
         edtRubrosId_Enabled = 0;
         AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtRubrosId_Enabled = 0;
         AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7RubrosId) )
         {
            A121RubrosId = AV7RubrosId;
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A123RubrosEstado)) && ( Gx_BScreen == 0 ) )
         {
            A123RubrosEstado = "HAB";
            n123RubrosEstado = false;
            AssignAttri("", false, "A123RubrosEstado", A123RubrosEstado);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0T37( )
      {
         /* Using cursor T000T4 */
         pr_default.execute(2, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound37 = 1;
            A122RubrosNombre = T000T4_A122RubrosNombre[0];
            AssignAttri("", false, "A122RubrosNombre", A122RubrosNombre);
            A40000RubrosImagen_GXI = T000T4_A40000RubrosImagen_GXI[0];
            AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
            AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A501RubrosDefault = T000T4_A501RubrosDefault[0];
            n501RubrosDefault = T000T4_n501RubrosDefault[0];
            AssignAttri("", false, "A501RubrosDefault", A501RubrosDefault);
            A123RubrosEstado = T000T4_A123RubrosEstado[0];
            n123RubrosEstado = T000T4_n123RubrosEstado[0];
            AssignAttri("", false, "A123RubrosEstado", A123RubrosEstado);
            A896RubrosImagenURL = T000T4_A896RubrosImagenURL[0];
            AssignAttri("", false, "A896RubrosImagenURL", A896RubrosImagenURL);
            A168RubrosImagen = T000T4_A168RubrosImagen[0];
            AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
            AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
            AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            ZM0T37( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0T37( ) ;
      }

      protected void OnLoadActions0T37( )
      {
         AV15Pgmname = "Rubros";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
      }

      protected void CheckExtendedTable0T37( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV15Pgmname = "Rubros";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         if ( ! ( ( StringUtil.StrCmp(A123RubrosEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A123RubrosEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A123RubrosEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A123RubrosEstado, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A123RubrosEstado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "RUBROSESTADO");
            AnyError = 1;
            GX_FocusControl = cmbRubrosEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A896RubrosImagenURL,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Rubros Imagen URL", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "RUBROSIMAGENURL");
            AnyError = 1;
            GX_FocusControl = edtRubrosImagenURL_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0T37( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0T37( )
      {
         /* Using cursor T000T5 */
         pr_default.execute(3, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound37 = 1;
         }
         else
         {
            RcdFound37 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000T3 */
         pr_default.execute(1, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0T37( 6) ;
            RcdFound37 = 1;
            A121RubrosId = T000T3_A121RubrosId[0];
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            A122RubrosNombre = T000T3_A122RubrosNombre[0];
            AssignAttri("", false, "A122RubrosNombre", A122RubrosNombre);
            A40000RubrosImagen_GXI = T000T3_A40000RubrosImagen_GXI[0];
            AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
            AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A501RubrosDefault = T000T3_A501RubrosDefault[0];
            n501RubrosDefault = T000T3_n501RubrosDefault[0];
            AssignAttri("", false, "A501RubrosDefault", A501RubrosDefault);
            A123RubrosEstado = T000T3_A123RubrosEstado[0];
            n123RubrosEstado = T000T3_n123RubrosEstado[0];
            AssignAttri("", false, "A123RubrosEstado", A123RubrosEstado);
            A896RubrosImagenURL = T000T3_A896RubrosImagenURL[0];
            AssignAttri("", false, "A896RubrosImagenURL", A896RubrosImagenURL);
            A168RubrosImagen = T000T3_A168RubrosImagen[0];
            AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
            AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
            AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            Z121RubrosId = A121RubrosId;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0T37( ) ;
            if ( AnyError == 1 )
            {
               RcdFound37 = 0;
               InitializeNonKey0T37( ) ;
            }
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound37 = 0;
            InitializeNonKey0T37( ) ;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0T37( ) ;
         if ( RcdFound37 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound37 = 0;
         /* Using cursor T000T6 */
         pr_default.execute(4, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000T6_A121RubrosId[0] < A121RubrosId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000T6_A121RubrosId[0] > A121RubrosId ) ) )
            {
               A121RubrosId = T000T6_A121RubrosId[0];
               AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
               RcdFound37 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound37 = 0;
         /* Using cursor T000T7 */
         pr_default.execute(5, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000T7_A121RubrosId[0] > A121RubrosId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000T7_A121RubrosId[0] < A121RubrosId ) ) )
            {
               A121RubrosId = T000T7_A121RubrosId[0];
               AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
               RcdFound37 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0T37( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtRubrosNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0T37( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound37 == 1 )
            {
               if ( A121RubrosId != Z121RubrosId )
               {
                  A121RubrosId = Z121RubrosId;
                  AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RUBROSID");
                  AnyError = 1;
                  GX_FocusControl = edtRubrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtRubrosNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0T37( ) ;
                  GX_FocusControl = edtRubrosNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A121RubrosId != Z121RubrosId )
               {
                  /* Insert record */
                  GX_FocusControl = edtRubrosNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0T37( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RUBROSID");
                     AnyError = 1;
                     GX_FocusControl = edtRubrosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtRubrosNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0T37( ) ;
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
         if ( A121RubrosId != Z121RubrosId )
         {
            A121RubrosId = Z121RubrosId;
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RUBROSID");
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtRubrosNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0T37( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000T2 */
            pr_default.execute(0, new Object[] {A121RubrosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Rubros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z122RubrosNombre, T000T2_A122RubrosNombre[0]) != 0 ) || ( Z501RubrosDefault != T000T2_A501RubrosDefault[0] ) || ( StringUtil.StrCmp(Z123RubrosEstado, T000T2_A123RubrosEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z896RubrosImagenURL, T000T2_A896RubrosImagenURL[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z122RubrosNombre, T000T2_A122RubrosNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("rubros:[seudo value changed for attri]"+"RubrosNombre");
                  GXUtil.WriteLogRaw("Old: ",Z122RubrosNombre);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A122RubrosNombre[0]);
               }
               if ( Z501RubrosDefault != T000T2_A501RubrosDefault[0] )
               {
                  GXUtil.WriteLog("rubros:[seudo value changed for attri]"+"RubrosDefault");
                  GXUtil.WriteLogRaw("Old: ",Z501RubrosDefault);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A501RubrosDefault[0]);
               }
               if ( StringUtil.StrCmp(Z123RubrosEstado, T000T2_A123RubrosEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("rubros:[seudo value changed for attri]"+"RubrosEstado");
                  GXUtil.WriteLogRaw("Old: ",Z123RubrosEstado);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A123RubrosEstado[0]);
               }
               if ( StringUtil.StrCmp(Z896RubrosImagenURL, T000T2_A896RubrosImagenURL[0]) != 0 )
               {
                  GXUtil.WriteLog("rubros:[seudo value changed for attri]"+"RubrosImagenURL");
                  GXUtil.WriteLogRaw("Old: ",Z896RubrosImagenURL);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A896RubrosImagenURL[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Rubros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0T37( )
      {
         BeforeValidate0T37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T37( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0T37( 0) ;
            CheckOptimisticConcurrency0T37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0T37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T8 */
                     pr_default.execute(6, new Object[] {A122RubrosNombre, A168RubrosImagen, A40000RubrosImagen_GXI, n501RubrosDefault, A501RubrosDefault, n123RubrosEstado, A123RubrosEstado, A896RubrosImagenURL});
                     A121RubrosId = T000T8_A121RubrosId[0];
                     AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Rubros");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0T0( ) ;
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
               Load0T37( ) ;
            }
            EndLevel0T37( ) ;
         }
         CloseExtendedTableCursors0T37( ) ;
      }

      protected void Update0T37( )
      {
         BeforeValidate0T37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T37( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0T37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T9 */
                     pr_default.execute(7, new Object[] {A122RubrosNombre, n501RubrosDefault, A501RubrosDefault, n123RubrosEstado, A123RubrosEstado, A896RubrosImagenURL, A121RubrosId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Rubros");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Rubros"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0T37( ) ;
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
            EndLevel0T37( ) ;
         }
         CloseExtendedTableCursors0T37( ) ;
      }

      protected void DeferredUpdate0T37( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000T10 */
            pr_default.execute(8, new Object[] {A168RubrosImagen, A40000RubrosImagen_GXI, A121RubrosId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("Rubros");
         }
      }

      protected void delete( )
      {
         BeforeValidate0T37( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T37( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0T37( ) ;
            AfterConfirm0T37( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0T37( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000T11 */
                  pr_default.execute(9, new Object[] {A121RubrosId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Rubros");
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
         sMode37 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0T37( ) ;
         Gx_mode = sMode37;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0T37( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "Rubros";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000T12 */
            pr_default.execute(10, new Object[] {A121RubrosId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Capacidad Productiva", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000T13 */
            pr_default.execute(11, new Object[] {A121RubrosId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000T14 */
            pr_default.execute(12, new Object[] {A121RubrosId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros Medidas y Precios", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel0T37( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0T37( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("rubros",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0T0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("rubros",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0T37( )
      {
         /* Scan By routine */
         /* Using cursor T000T15 */
         pr_default.execute(13);
         RcdFound37 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound37 = 1;
            A121RubrosId = T000T15_A121RubrosId[0];
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0T37( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound37 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound37 = 1;
            A121RubrosId = T000T15_A121RubrosId[0];
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
         }
      }

      protected void ScanEnd0T37( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0T37( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0T37( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0T37( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0T37( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0T37( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0T37( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0T37( )
      {
         edtRubrosId_Enabled = 0;
         AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), true);
         edtRubrosNombre_Enabled = 0;
         AssignProp("", false, edtRubrosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosNombre_Enabled), 5, 0), true);
         imgRubrosImagen_Enabled = 0;
         AssignProp("", false, imgRubrosImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgRubrosImagen_Enabled), 5, 0), true);
         chkRubrosDefault.Enabled = 0;
         AssignProp("", false, chkRubrosDefault_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkRubrosDefault.Enabled), 5, 0), true);
         cmbRubrosEstado.Enabled = 0;
         AssignProp("", false, cmbRubrosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbRubrosEstado.Enabled), 5, 0), true);
         edtRubrosImagenURL_Enabled = 0;
         AssignProp("", false, edtRubrosImagenURL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosImagenURL_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0T37( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0T0( )
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
         GXEncryptionTmp = "rubros.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7RubrosId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("rubros.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Rubros");
         forbiddenHiddens.Add("RubrosId", context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("rubros:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z121RubrosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z122RubrosNombre", StringUtil.RTrim( Z122RubrosNombre));
         GxWebStd.gx_boolean_hidden_field( context, "Z501RubrosDefault", Z501RubrosDefault);
         GxWebStd.gx_hidden_field( context, "Z123RubrosEstado", StringUtil.RTrim( Z123RubrosEstado));
         GxWebStd.gx_hidden_field( context, "Z896RubrosImagenURL", Z896RubrosImagenURL);
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
         GxWebStd.gx_hidden_field( context, "vRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vRUBROSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RubrosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "RUBROSIMAGEN_GXI", A40000RubrosImagen_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
         GXCCtlgxBlob = "RUBROSIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A168RubrosImagen);
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
         GXEncryptionTmp = "rubros.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7RubrosId,4,0));
         return formatLink("rubros.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Rubros" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Rubros", "") ;
      }

      protected void InitializeNonKey0T37( )
      {
         A122RubrosNombre = "";
         AssignAttri("", false, "A122RubrosNombre", A122RubrosNombre);
         A168RubrosImagen = "";
         AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
         AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
         AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A40000RubrosImagen_GXI = "";
         AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
         AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A501RubrosDefault = false;
         n501RubrosDefault = false;
         AssignAttri("", false, "A501RubrosDefault", A501RubrosDefault);
         n501RubrosDefault = ((false==A501RubrosDefault) ? true : false);
         A896RubrosImagenURL = "";
         AssignAttri("", false, "A896RubrosImagenURL", A896RubrosImagenURL);
         A123RubrosEstado = "HAB";
         n123RubrosEstado = false;
         AssignAttri("", false, "A123RubrosEstado", A123RubrosEstado);
         Z122RubrosNombre = "";
         Z501RubrosDefault = false;
         Z123RubrosEstado = "";
         Z896RubrosImagenURL = "";
      }

      protected void InitAll0T37( )
      {
         A121RubrosId = 0;
         AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
         InitializeNonKey0T37( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A123RubrosEstado = i123RubrosEstado;
         n123RubrosEstado = false;
         AssignAttri("", false, "A123RubrosEstado", A123RubrosEstado);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932015766", true, true, false);
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
         context.AddJavascriptSource("rubros.js", "?2026932015767", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtRubrosId_Internalname = "RUBROSID";
         edtRubrosNombre_Internalname = "RUBROSNOMBRE";
         imgRubrosImagen_Internalname = "RUBROSIMAGEN";
         chkRubrosDefault_Internalname = "RUBROSDEFAULT";
         cmbRubrosEstado_Internalname = "RUBROSESTADO";
         edtRubrosImagenURL_Internalname = "RUBROSIMAGENURL";
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
         Form.Caption = context.GetMessage( "Rubros", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtRubrosImagenURL_Jsonclick = "";
         edtRubrosImagenURL_Enabled = 1;
         cmbRubrosEstado_Jsonclick = "";
         cmbRubrosEstado.Enabled = 1;
         chkRubrosDefault.Enabled = 1;
         imgRubrosImagen_Enabled = 1;
         edtRubrosNombre_Jsonclick = "";
         edtRubrosNombre_Enabled = 1;
         edtRubrosId_Jsonclick = "";
         edtRubrosId_Enabled = 0;
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
         chkRubrosDefault.Name = "RUBROSDEFAULT";
         chkRubrosDefault.WebTags = "";
         chkRubrosDefault.Caption = context.GetMessage( "Default", "");
         AssignProp("", false, chkRubrosDefault_Internalname, "TitleCaption", chkRubrosDefault.Caption, true);
         chkRubrosDefault.CheckedValue = "false";
         A501RubrosDefault = StringUtil.StrToBool( StringUtil.BoolToStr( A501RubrosDefault));
         n501RubrosDefault = false;
         AssignAttri("", false, "A501RubrosDefault", A501RubrosDefault);
         cmbRubrosEstado.Name = "RUBROSESTADO";
         cmbRubrosEstado.WebTags = "";
         cmbRubrosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbRubrosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbRubrosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbRubrosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbRubrosEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A123RubrosEstado)) )
            {
               A123RubrosEstado = "HAB";
               n123RubrosEstado = false;
               AssignAttri("", false, "A123RubrosEstado", A123RubrosEstado);
            }
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7RubrosId',fld:'vRUBROSID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A501RubrosDefault',fld:'RUBROSDEFAULT',pic:'',type:'boolean'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A501RubrosDefault',fld:'RUBROSDEFAULT',pic:'',type:'boolean'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7RubrosId',fld:'vRUBROSID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'A501RubrosDefault',fld:'RUBROSDEFAULT',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A501RubrosDefault',fld:'RUBROSDEFAULT',pic:'',type:'boolean'}]}");
         setEventMetadata("AFTER TRN","{handler:'E120T2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A501RubrosDefault',fld:'RUBROSDEFAULT',pic:'',type:'boolean'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A501RubrosDefault',fld:'RUBROSDEFAULT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[{av:'A501RubrosDefault',fld:'RUBROSDEFAULT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_RUBROSID",",oparms:[{av:'A501RubrosDefault',fld:'RUBROSDEFAULT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_RUBROSESTADO","{handler:'Valid_Rubrosestado',iparms:[{av:'A501RubrosDefault',fld:'RUBROSDEFAULT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_RUBROSESTADO",",oparms:[{av:'A501RubrosDefault',fld:'RUBROSDEFAULT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_RUBROSIMAGENURL","{handler:'Valid_Rubrosimagenurl',iparms:[{av:'A501RubrosDefault',fld:'RUBROSDEFAULT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_RUBROSIMAGENURL",",oparms:[{av:'A501RubrosDefault',fld:'RUBROSDEFAULT',pic:'',type:'boolean'}]}");
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
         Z122RubrosNombre = "";
         Z123RubrosEstado = "";
         Z896RubrosImagenURL = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A123RubrosEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A122RubrosNombre = "";
         A168RubrosImagen = "";
         A40000RubrosImagen_GXI = "";
         sImgUrl = "";
         A896RubrosImagenURL = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV15Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode37 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV12WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z168RubrosImagen = "";
         Z40000RubrosImagen_GXI = "";
         T000T4_A121RubrosId = new short[1] ;
         T000T4_A122RubrosNombre = new string[] {""} ;
         T000T4_A40000RubrosImagen_GXI = new string[] {""} ;
         T000T4_A501RubrosDefault = new bool[] {false} ;
         T000T4_n501RubrosDefault = new bool[] {false} ;
         T000T4_A123RubrosEstado = new string[] {""} ;
         T000T4_n123RubrosEstado = new bool[] {false} ;
         T000T4_A896RubrosImagenURL = new string[] {""} ;
         T000T4_A168RubrosImagen = new string[] {""} ;
         T000T5_A121RubrosId = new short[1] ;
         T000T3_A121RubrosId = new short[1] ;
         T000T3_A122RubrosNombre = new string[] {""} ;
         T000T3_A40000RubrosImagen_GXI = new string[] {""} ;
         T000T3_A501RubrosDefault = new bool[] {false} ;
         T000T3_n501RubrosDefault = new bool[] {false} ;
         T000T3_A123RubrosEstado = new string[] {""} ;
         T000T3_n123RubrosEstado = new bool[] {false} ;
         T000T3_A896RubrosImagenURL = new string[] {""} ;
         T000T3_A168RubrosImagen = new string[] {""} ;
         T000T6_A121RubrosId = new short[1] ;
         T000T7_A121RubrosId = new short[1] ;
         T000T2_A121RubrosId = new short[1] ;
         T000T2_A122RubrosNombre = new string[] {""} ;
         T000T2_A40000RubrosImagen_GXI = new string[] {""} ;
         T000T2_A501RubrosDefault = new bool[] {false} ;
         T000T2_n501RubrosDefault = new bool[] {false} ;
         T000T2_A123RubrosEstado = new string[] {""} ;
         T000T2_n123RubrosEstado = new bool[] {false} ;
         T000T2_A896RubrosImagenURL = new string[] {""} ;
         T000T2_A168RubrosImagen = new string[] {""} ;
         T000T8_A121RubrosId = new short[1] ;
         T000T12_A804CapacidadProdId = new long[1] ;
         T000T13_A120ProfesionalesId = new string[] {""} ;
         T000T13_A121RubrosId = new short[1] ;
         T000T14_A121RubrosId = new short[1] ;
         T000T14_A137MedidasID = new long[1] ;
         T000T15_A121RubrosId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         i123RubrosEstado = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.rubros__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rubros__default(),
            new Object[][] {
                new Object[] {
               T000T2_A121RubrosId, T000T2_A122RubrosNombre, T000T2_A40000RubrosImagen_GXI, T000T2_A501RubrosDefault, T000T2_n501RubrosDefault, T000T2_A123RubrosEstado, T000T2_n123RubrosEstado, T000T2_A896RubrosImagenURL, T000T2_A168RubrosImagen
               }
               , new Object[] {
               T000T3_A121RubrosId, T000T3_A122RubrosNombre, T000T3_A40000RubrosImagen_GXI, T000T3_A501RubrosDefault, T000T3_n501RubrosDefault, T000T3_A123RubrosEstado, T000T3_n123RubrosEstado, T000T3_A896RubrosImagenURL, T000T3_A168RubrosImagen
               }
               , new Object[] {
               T000T4_A121RubrosId, T000T4_A122RubrosNombre, T000T4_A40000RubrosImagen_GXI, T000T4_A501RubrosDefault, T000T4_n501RubrosDefault, T000T4_A123RubrosEstado, T000T4_n123RubrosEstado, T000T4_A896RubrosImagenURL, T000T4_A168RubrosImagen
               }
               , new Object[] {
               T000T5_A121RubrosId
               }
               , new Object[] {
               T000T6_A121RubrosId
               }
               , new Object[] {
               T000T7_A121RubrosId
               }
               , new Object[] {
               T000T8_A121RubrosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000T12_A804CapacidadProdId
               }
               , new Object[] {
               T000T13_A120ProfesionalesId, T000T13_A121RubrosId
               }
               , new Object[] {
               T000T14_A121RubrosId, T000T14_A137MedidasID
               }
               , new Object[] {
               T000T15_A121RubrosId
               }
            }
         );
         AV15Pgmname = "Rubros";
         Z123RubrosEstado = "HAB";
         n123RubrosEstado = false;
         A123RubrosEstado = "HAB";
         n123RubrosEstado = false;
         i123RubrosEstado = "HAB";
         n123RubrosEstado = false;
      }

      private short wcpOAV7RubrosId ;
      private short Z121RubrosId ;
      private short GxWebError ;
      private short AV7RubrosId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A121RubrosId ;
      private short Gx_BScreen ;
      private short RcdFound37 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtRubrosId_Enabled ;
      private int edtRubrosNombre_Enabled ;
      private int imgRubrosImagen_Enabled ;
      private int edtRubrosImagenURL_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z122RubrosNombre ;
      private string Z123RubrosEstado ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtRubrosNombre_Internalname ;
      private string A123RubrosEstado ;
      private string cmbRubrosEstado_Internalname ;
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
      private string edtRubrosId_Internalname ;
      private string TempTags ;
      private string edtRubrosId_Jsonclick ;
      private string A122RubrosNombre ;
      private string edtRubrosNombre_Jsonclick ;
      private string imgRubrosImagen_Internalname ;
      private string sImgUrl ;
      private string chkRubrosDefault_Internalname ;
      private string cmbRubrosEstado_Jsonclick ;
      private string edtRubrosImagenURL_Internalname ;
      private string edtRubrosImagenURL_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV15Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode37 ;
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
      private string i123RubrosEstado ;
      private bool Z501RubrosDefault ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A501RubrosDefault ;
      private bool n501RubrosDefault ;
      private bool n123RubrosEstado ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A168RubrosImagen_IsBlob ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private string Z896RubrosImagenURL ;
      private string A40000RubrosImagen_GXI ;
      private string A896RubrosImagenURL ;
      private string Z40000RubrosImagen_GXI ;
      private string A168RubrosImagen ;
      private string Z168RubrosImagen ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkRubrosDefault ;
      private GXCombobox cmbRubrosEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV12WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T000T4_A121RubrosId ;
      private string[] T000T4_A122RubrosNombre ;
      private string[] T000T4_A40000RubrosImagen_GXI ;
      private bool[] T000T4_A501RubrosDefault ;
      private bool[] T000T4_n501RubrosDefault ;
      private string[] T000T4_A123RubrosEstado ;
      private bool[] T000T4_n123RubrosEstado ;
      private string[] T000T4_A896RubrosImagenURL ;
      private string[] T000T4_A168RubrosImagen ;
      private short[] T000T5_A121RubrosId ;
      private short[] T000T3_A121RubrosId ;
      private string[] T000T3_A122RubrosNombre ;
      private string[] T000T3_A40000RubrosImagen_GXI ;
      private bool[] T000T3_A501RubrosDefault ;
      private bool[] T000T3_n501RubrosDefault ;
      private string[] T000T3_A123RubrosEstado ;
      private bool[] T000T3_n123RubrosEstado ;
      private string[] T000T3_A896RubrosImagenURL ;
      private string[] T000T3_A168RubrosImagen ;
      private short[] T000T6_A121RubrosId ;
      private short[] T000T7_A121RubrosId ;
      private short[] T000T2_A121RubrosId ;
      private string[] T000T2_A122RubrosNombre ;
      private string[] T000T2_A40000RubrosImagen_GXI ;
      private bool[] T000T2_A501RubrosDefault ;
      private bool[] T000T2_n501RubrosDefault ;
      private string[] T000T2_A123RubrosEstado ;
      private bool[] T000T2_n123RubrosEstado ;
      private string[] T000T2_A896RubrosImagenURL ;
      private string[] T000T2_A168RubrosImagen ;
      private short[] T000T8_A121RubrosId ;
      private long[] T000T12_A804CapacidadProdId ;
      private string[] T000T13_A120ProfesionalesId ;
      private short[] T000T13_A121RubrosId ;
      private short[] T000T14_A121RubrosId ;
      private long[] T000T14_A137MedidasID ;
      private short[] T000T15_A121RubrosId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class rubros__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class rubros__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000T2;
        prmT000T2 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000T3;
        prmT000T3 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000T4;
        prmT000T4 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000T5;
        prmT000T5 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000T6;
        prmT000T6 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000T7;
        prmT000T7 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000T8;
        prmT000T8 = new Object[] {
        new ParDef("@RubrosNombre",GXType.NChar,100,0) ,
        new ParDef("@RubrosImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@RubrosImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Rubros", Fld="RubrosImagen"} ,
        new ParDef("@RubrosDefault",GXType.Boolean,1,0){Nullable=true} ,
        new ParDef("@RubrosEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@RubrosImagenURL",GXType.NVarChar,1000,0)
        };
        Object[] prmT000T9;
        prmT000T9 = new Object[] {
        new ParDef("@RubrosNombre",GXType.NChar,100,0) ,
        new ParDef("@RubrosDefault",GXType.Boolean,1,0){Nullable=true} ,
        new ParDef("@RubrosEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@RubrosImagenURL",GXType.NVarChar,1000,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000T10;
        prmT000T10 = new Object[] {
        new ParDef("@RubrosImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@RubrosImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Rubros", Fld="RubrosImagen"} ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000T11;
        prmT000T11 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000T12;
        prmT000T12 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000T13;
        prmT000T13 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000T14;
        prmT000T14 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000T15;
        prmT000T15 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000T2", "SELECT [RubrosId], [RubrosNombre], [RubrosImagen_GXI], [RubrosDefault], [RubrosEstado], [RubrosImagenURL], [RubrosImagen] FROM [Rubros] WITH (UPDLOCK) WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T3", "SELECT [RubrosId], [RubrosNombre], [RubrosImagen_GXI], [RubrosDefault], [RubrosEstado], [RubrosImagenURL], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T4", "SELECT TM1.[RubrosId], TM1.[RubrosNombre], TM1.[RubrosImagen_GXI], TM1.[RubrosDefault], TM1.[RubrosEstado], TM1.[RubrosImagenURL], TM1.[RubrosImagen] FROM [Rubros] TM1 WHERE TM1.[RubrosId] = @RubrosId ORDER BY TM1.[RubrosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000T4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T5", "SELECT [RubrosId] FROM [Rubros] WHERE [RubrosId] = @RubrosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000T5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T6", "SELECT TOP 1 [RubrosId] FROM [Rubros] WHERE ( [RubrosId] > @RubrosId) ORDER BY [RubrosId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000T6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T7", "SELECT TOP 1 [RubrosId] FROM [Rubros] WHERE ( [RubrosId] < @RubrosId) ORDER BY [RubrosId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000T7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T8", "INSERT INTO [Rubros]([RubrosNombre], [RubrosImagen], [RubrosImagen_GXI], [RubrosDefault], [RubrosEstado], [RubrosImagenURL], [RubrosMedidasSerial]) VALUES(@RubrosNombre, @RubrosImagen, @RubrosImagen_GXI, @RubrosDefault, @RubrosEstado, @RubrosImagenURL, convert(int, 0)); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000T8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T9", "UPDATE [Rubros] SET [RubrosNombre]=@RubrosNombre, [RubrosDefault]=@RubrosDefault, [RubrosEstado]=@RubrosEstado, [RubrosImagenURL]=@RubrosImagenURL  WHERE [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmT000T9)
           ,new CursorDef("T000T10", "UPDATE [Rubros] SET [RubrosImagen]=@RubrosImagen, [RubrosImagen_GXI]=@RubrosImagen_GXI  WHERE [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmT000T10)
           ,new CursorDef("T000T11", "DELETE FROM [Rubros]  WHERE [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmT000T11)
           ,new CursorDef("T000T12", "SELECT TOP 1 [CapacidadProdId] FROM [CapacidadProductiva] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T13", "SELECT TOP 1 [ProfesionalesId], [RubrosId] FROM [ProfesionalesRubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T14", "SELECT TOP 1 [RubrosId], [MedidasID] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T15", "SELECT [RubrosId] FROM [Rubros] ORDER BY [RubrosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000T15,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 3);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 3);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 3);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 12 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 13 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}
