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
   public class configgen : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel8"+"_"+"vOK") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX8ASAOK1C53( ) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_publicidad") == 0 )
         {
            gxnrGridlevel_publicidad_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configgen.aspx")), "configgen.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configgen.aspx")))) ;
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
                  AV7ConfigGenID = (short)(Math.Round(NumberUtil.Val( GetPar( "ConfigGenID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ConfigGenID", StringUtil.LTrimStr( (decimal)(AV7ConfigGenID), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCONFIGGENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ConfigGenID), "ZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Configuración General", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtConfigGenEmpNom_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_publicidad_newrow_invoke( )
      {
         nRC_GXsfl_78 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_78"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_78_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_78_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_78_idx = GetPar( "sGXsfl_78_idx");
         A365ConfigGenSerial = (long)(Math.Round(NumberUtil.Val( GetPar( "ConfigGenSerial"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_publicidad_newrow( ) ;
         /* End function gxnrGridlevel_publicidad_newrow_invoke */
      }

      public configgen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public configgen( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_ConfigGenID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ConfigGenID = aP1_ConfigGenID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbConfigGenEstado = new GXCombobox();
         cmbConfigGenPublicidadEsta = new GXCombobox();
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
         if ( cmbConfigGenEstado.ItemCount > 0 )
         {
            A358ConfigGenEstado = cmbConfigGenEstado.getValidValue(A358ConfigGenEstado);
            AssignAttri("", false, "A358ConfigGenEstado", A358ConfigGenEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConfigGenEstado.CurrentValue = StringUtil.RTrim( A358ConfigGenEstado);
            AssignProp("", false, cmbConfigGenEstado_Internalname, "Values", cmbConfigGenEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfigGenID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfigGenID_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfigGenID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A349ConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtConfigGenID_Enabled!=0) ? context.localUtil.Format( (decimal)(A349ConfigGenID), "ZZZ9") : context.localUtil.Format( (decimal)(A349ConfigGenID), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfigGenID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConfigGenID_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ConfigGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfigGenEmpNom_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfigGenEmpNom_Internalname, context.GetMessage( "Nombre de la Empresa", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfigGenEmpNom_Internalname, StringUtil.RTrim( A351ConfigGenEmpNom), StringUtil.RTrim( context.localUtil.Format( A351ConfigGenEmpNom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfigGenEmpNom_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConfigGenEmpNom_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ConfigGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfigGenSiglas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfigGenSiglas_Internalname, context.GetMessage( "Siglas", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfigGenSiglas_Internalname, StringUtil.RTrim( A352ConfigGenSiglas), StringUtil.RTrim( context.localUtil.Format( A352ConfigGenSiglas, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfigGenSiglas_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConfigGenSiglas_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ConfigGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgConfigGenLogo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Logo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A353ConfigGenLogo_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ConfigGenLogo_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo)) ? A40000ConfigGenLogo_GXI : context.PathToRelativeUrl( A353ConfigGenLogo));
         GxWebStd.gx_bitmap( context, imgConfigGenLogo_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgConfigGenLogo_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", "", "", 0, A353ConfigGenLogo_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_ConfigGen.htm");
         AssignProp("", false, imgConfigGenLogo_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo)) ? A40000ConfigGenLogo_GXI : context.PathToRelativeUrl( A353ConfigGenLogo)), true);
         AssignProp("", false, imgConfigGenLogo_Internalname, "IsBlob", StringUtil.BoolToStr( A353ConfigGenLogo_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfigGenSiteWeb_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfigGenSiteWeb_Internalname, context.GetMessage( "Sitio Web", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfigGenSiteWeb_Internalname, StringUtil.RTrim( A354ConfigGenSiteWeb), StringUtil.RTrim( context.localUtil.Format( A354ConfigGenSiteWeb, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfigGenSiteWeb_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConfigGenSiteWeb_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ConfigGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfigGenCorreo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfigGenCorreo_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfigGenCorreo_Internalname, A355ConfigGenCorreo, StringUtil.RTrim( context.localUtil.Format( A355ConfigGenCorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A355ConfigGenCorreo, "", "", "", edtConfigGenCorreo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConfigGenCorreo_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_ConfigGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfigGenTelefono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfigGenTelefono_Internalname, context.GetMessage( "Teléfono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A356ConfigGenTelefono);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfigGenTelefono_Internalname, StringUtil.RTrim( A356ConfigGenTelefono), StringUtil.RTrim( context.localUtil.Format( A356ConfigGenTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtConfigGenTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConfigGenTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_ConfigGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfigGenDireccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfigGenDireccion_Internalname, context.GetMessage( "Dirección", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtConfigGenDireccion_Internalname, A357ConfigGenDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A357ConfigGenDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", 0, 1, edtConfigGenDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ConfigGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbConfigGenEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbConfigGenEstado_Internalname, context.GetMessage( "Gen Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConfigGenEstado, cmbConfigGenEstado_Internalname, StringUtil.RTrim( A358ConfigGenEstado), 1, cmbConfigGenEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbConfigGenEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "", true, 0, "HLP_ConfigGen.htm");
         cmbConfigGenEstado.CurrentValue = StringUtil.RTrim( A358ConfigGenEstado);
         AssignProp("", false, cmbConfigGenEstado_Internalname, "Values", (string)(cmbConfigGenEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfigGenFecMod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfigGenFecMod_Internalname, context.GetMessage( "Modificación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtConfigGenFecMod_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtConfigGenFecMod_Internalname, context.localUtil.TToC( A368ConfigGenFecMod, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A368ConfigGenFecMod, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfigGenFecMod_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConfigGenFecMod_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ConfigGen.htm");
         GxWebStd.gx_bitmap( context, edtConfigGenFecMod_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtConfigGenFecMod_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ConfigGen.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfigGenUsuarioMod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfigGenUsuarioMod_Internalname, context.GetMessage( "Usuario de Modificación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfigGenUsuarioMod_Internalname, StringUtil.RTrim( A370ConfigGenUsuarioMod), StringUtil.RTrim( context.localUtil.Format( A370ConfigGenUsuarioMod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfigGenUsuarioMod_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConfigGenUsuarioMod_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "Usuario", "start", true, "", "HLP_ConfigGen.htm");
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
         GxWebStd.gx_div_start( context, divTableleaflevel_publicidad_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_publicidad( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ConfigGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ConfigGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ConfigGen.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfigGenSerial_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A365ConfigGenSerial), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtConfigGenSerial_Enabled!=0) ? context.localUtil.Format( (decimal)(A365ConfigGenSerial), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A365ConfigGenSerial), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfigGenSerial_Jsonclick, 0, "Attribute", "", "", "", "", edtConfigGenSerial_Visible, edtConfigGenSerial_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ConfigGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_publicidad( )
      {
         /*  Grid Control  */
         StartGridControl78( ) ;
         nGXsfl_78_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount54 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_54 = 1;
               ScanStart1C54( ) ;
               while ( RcdFound54 != 0 )
               {
                  init_level_properties54( ) ;
                  getByPrimaryKey1C54( ) ;
                  AddRow1C54( ) ;
                  ScanNext1C54( ) ;
               }
               ScanEnd1C54( ) ;
               nBlankRcdCount54 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B365ConfigGenSerial = A365ConfigGenSerial;
            AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
            standaloneNotModal1C54( ) ;
            standaloneModal1C54( ) ;
            sMode54 = Gx_mode;
            while ( nGXsfl_78_idx < nRC_GXsfl_78 )
            {
               bGXsfl_78_Refreshing = true;
               ReadRow1C54( ) ;
               edtConfigGenPublicidadId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGGENPUBLICIDADID_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtConfigGenPublicidadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenPublicidadId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtConfigGenPublicidadTit_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGGENPUBLICIDADTIT_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtConfigGenPublicidadTit_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenPublicidadTit_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtConfigGenPublicidadDes_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGGENPUBLICIDADDES_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtConfigGenPublicidadDes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenPublicidadDes_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtConfigGenPublicidadIma_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGGENPUBLICIDADIMA_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenPublicidadIma_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtConfigGenPublicidadFecIni_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGGENPUBLICIDADFECINI_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtConfigGenPublicidadFecIni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenPublicidadFecIni_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtConfigGenPublicidadFecFin_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGGENPUBLICIDADFECFIN_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtConfigGenPublicidadFecFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenPublicidadFecFin_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               cmbConfigGenPublicidadEsta.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGGENPUBLICIDADESTA_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbConfigGenPublicidadEsta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConfigGenPublicidadEsta.Enabled), 5, 0), !bGXsfl_78_Refreshing);
               if ( ( nRcdExists_54 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1C54( ) ;
               }
               SendRow1C54( ) ;
               bGXsfl_78_Refreshing = false;
            }
            Gx_mode = sMode54;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A365ConfigGenSerial = B365ConfigGenSerial;
            AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount54 = 5;
            nRcdExists_54 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1C54( ) ;
               while ( RcdFound54 != 0 )
               {
                  sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_7854( ) ;
                  init_level_properties54( ) ;
                  standaloneNotModal1C54( ) ;
                  getByPrimaryKey1C54( ) ;
                  standaloneModal1C54( ) ;
                  AddRow1C54( ) ;
                  ScanNext1C54( ) ;
               }
               ScanEnd1C54( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode54 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx+1), 4, 0), 4, "0");
            SubsflControlProps_7854( ) ;
            InitAll1C54( ) ;
            init_level_properties54( ) ;
            B365ConfigGenSerial = A365ConfigGenSerial;
            AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
            nRcdExists_54 = 0;
            nIsMod_54 = 0;
            nRcdDeleted_54 = 0;
            nBlankRcdCount54 = (short)(nBlankRcdUsr54+nBlankRcdCount54);
            fRowAdded = 0;
            while ( nBlankRcdCount54 > 0 )
            {
               standaloneNotModal1C54( ) ;
               standaloneModal1C54( ) ;
               AddRow1C54( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtConfigGenPublicidadTit_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount54 = (short)(nBlankRcdCount54-1);
            }
            Gx_mode = sMode54;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A365ConfigGenSerial = B365ConfigGenSerial;
            AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_publicidadContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_publicidad", Gridlevel_publicidadContainer, subGridlevel_publicidad_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_publicidadContainerData", Gridlevel_publicidadContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_publicidadContainerData"+"V", Gridlevel_publicidadContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_publicidadContainerData"+"V"+"\" value='"+Gridlevel_publicidadContainer.GridValuesHidden()+"'/>") ;
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
         E111C2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z349ConfigGenID = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z349ConfigGenID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z368ConfigGenFecMod = context.localUtil.CToT( cgiGet( "Z368ConfigGenFecMod"), 0);
               Z351ConfigGenEmpNom = cgiGet( "Z351ConfigGenEmpNom");
               Z352ConfigGenSiglas = cgiGet( "Z352ConfigGenSiglas");
               Z354ConfigGenSiteWeb = cgiGet( "Z354ConfigGenSiteWeb");
               Z355ConfigGenCorreo = cgiGet( "Z355ConfigGenCorreo");
               Z356ConfigGenTelefono = cgiGet( "Z356ConfigGenTelefono");
               Z357ConfigGenDireccion = cgiGet( "Z357ConfigGenDireccion");
               Z358ConfigGenEstado = cgiGet( "Z358ConfigGenEstado");
               Z370ConfigGenUsuarioMod = cgiGet( "Z370ConfigGenUsuarioMod");
               Z365ConfigGenSerial = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z365ConfigGenSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O365ConfigGenSerial = (long)(Math.Round(context.localUtil.CToN( cgiGet( "O365ConfigGenSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_78 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_78"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7ConfigGenID = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vCONFIGGENID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV11Ok = cgiGet( "vOK");
               A40000ConfigGenLogo_GXI = cgiGet( "CONFIGGENLOGO_GXI");
               AV15Pgmname = cgiGet( "vPGMNAME");
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A40001ConfigGenPublicidadIma_GXI = cgiGet( "CONFIGGENPUBLICIDADIMA_GXI");
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
               A349ConfigGenID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtConfigGenID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
               A351ConfigGenEmpNom = cgiGet( edtConfigGenEmpNom_Internalname);
               AssignAttri("", false, "A351ConfigGenEmpNom", A351ConfigGenEmpNom);
               A352ConfigGenSiglas = cgiGet( edtConfigGenSiglas_Internalname);
               AssignAttri("", false, "A352ConfigGenSiglas", A352ConfigGenSiglas);
               A353ConfigGenLogo = cgiGet( imgConfigGenLogo_Internalname);
               AssignAttri("", false, "A353ConfigGenLogo", A353ConfigGenLogo);
               A354ConfigGenSiteWeb = cgiGet( edtConfigGenSiteWeb_Internalname);
               AssignAttri("", false, "A354ConfigGenSiteWeb", A354ConfigGenSiteWeb);
               A355ConfigGenCorreo = cgiGet( edtConfigGenCorreo_Internalname);
               AssignAttri("", false, "A355ConfigGenCorreo", A355ConfigGenCorreo);
               A356ConfigGenTelefono = cgiGet( edtConfigGenTelefono_Internalname);
               AssignAttri("", false, "A356ConfigGenTelefono", A356ConfigGenTelefono);
               A357ConfigGenDireccion = cgiGet( edtConfigGenDireccion_Internalname);
               AssignAttri("", false, "A357ConfigGenDireccion", A357ConfigGenDireccion);
               cmbConfigGenEstado.Name = cmbConfigGenEstado_Internalname;
               cmbConfigGenEstado.CurrentValue = cgiGet( cmbConfigGenEstado_Internalname);
               A358ConfigGenEstado = cgiGet( cmbConfigGenEstado_Internalname);
               AssignAttri("", false, "A358ConfigGenEstado", A358ConfigGenEstado);
               A368ConfigGenFecMod = context.localUtil.CToT( cgiGet( edtConfigGenFecMod_Internalname));
               AssignAttri("", false, "A368ConfigGenFecMod", context.localUtil.TToC( A368ConfigGenFecMod, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A370ConfigGenUsuarioMod = cgiGet( edtConfigGenUsuarioMod_Internalname);
               AssignAttri("", false, "A370ConfigGenUsuarioMod", A370ConfigGenUsuarioMod);
               A365ConfigGenSerial = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtConfigGenSerial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgConfigGenLogo_Internalname, ref  A353ConfigGenLogo, ref  A40000ConfigGenLogo_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ConfigGen");
               A349ConfigGenID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtConfigGenID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
               forbiddenHiddens.Add("ConfigGenID", context.localUtil.Format( (decimal)(A349ConfigGenID), "ZZZ9"));
               A368ConfigGenFecMod = context.localUtil.CToT( cgiGet( edtConfigGenFecMod_Internalname));
               AssignAttri("", false, "A368ConfigGenFecMod", context.localUtil.TToC( A368ConfigGenFecMod, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               forbiddenHiddens.Add("ConfigGenFecMod", context.localUtil.Format( A368ConfigGenFecMod, "99/99/99 99:99"));
               A370ConfigGenUsuarioMod = cgiGet( edtConfigGenUsuarioMod_Internalname);
               AssignAttri("", false, "A370ConfigGenUsuarioMod", A370ConfigGenUsuarioMod);
               forbiddenHiddens.Add("ConfigGenUsuarioMod", StringUtil.RTrim( context.localUtil.Format( A370ConfigGenUsuarioMod, "")));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A349ConfigGenID != Z349ConfigGenID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configgen:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A349ConfigGenID = (short)(Math.Round(NumberUtil.Val( GetPar( "ConfigGenID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
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
                     sMode53 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode53;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound53 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1C0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CONFIGGENID");
                        AnyError = 1;
                        GX_FocusControl = edtConfigGenID_Internalname;
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
                           E111C2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121C2 ();
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
            E121C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1C53( ) ;
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
            DisableAttributes1C53( ) ;
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

      protected void CONFIRM_1C0( )
      {
         BeforeValidate1C53( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1C53( ) ;
            }
            else
            {
               CheckExtendedTable1C53( ) ;
               CloseExtendedTableCursors1C53( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode53 = Gx_mode;
            CONFIRM_1C54( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode53;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode53;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_1C54( )
      {
         s365ConfigGenSerial = O365ConfigGenSerial;
         AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
         nGXsfl_78_idx = 0;
         while ( nGXsfl_78_idx < nRC_GXsfl_78 )
         {
            ReadRow1C54( ) ;
            if ( ( nRcdExists_54 != 0 ) || ( nIsMod_54 != 0 ) )
            {
               GetKey1C54( ) ;
               if ( ( nRcdExists_54 == 0 ) && ( nRcdDeleted_54 == 0 ) )
               {
                  if ( RcdFound54 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1C54( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1C54( ) ;
                        CloseExtendedTableCursors1C54( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O365ConfigGenSerial = A365ConfigGenSerial;
                        AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound54 != 0 )
                  {
                     if ( nRcdDeleted_54 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1C54( ) ;
                        Load1C54( ) ;
                        BeforeValidate1C54( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1C54( ) ;
                           O365ConfigGenSerial = A365ConfigGenSerial;
                           AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_54 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1C54( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1C54( ) ;
                              CloseExtendedTableCursors1C54( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O365ConfigGenSerial = A365ConfigGenSerial;
                              AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_54 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtConfigGenPublicidadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A350ConfigGenPublicidadId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtConfigGenPublicidadTit_Internalname, StringUtil.RTrim( A359ConfigGenPublicidadTit)) ;
            ChangePostValue( edtConfigGenPublicidadDes_Internalname, A360ConfigGenPublicidadDes) ;
            ChangePostValue( edtConfigGenPublicidadIma_Internalname, A361ConfigGenPublicidadIma) ;
            ChangePostValue( edtConfigGenPublicidadFecIni_Internalname, context.localUtil.TToC( A362ConfigGenPublicidadFecIni, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( edtConfigGenPublicidadFecFin_Internalname, context.localUtil.TToC( A363ConfigGenPublicidadFecFin, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( cmbConfigGenPublicidadEsta_Internalname, StringUtil.RTrim( A364ConfigGenPublicidadEsta)) ;
            ChangePostValue( "ZT_"+"Z350ConfigGenPublicidadId_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z350ConfigGenPublicidadId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z359ConfigGenPublicidadTit_"+sGXsfl_78_idx, StringUtil.RTrim( Z359ConfigGenPublicidadTit)) ;
            ChangePostValue( "ZT_"+"Z362ConfigGenPublicidadFecIni_"+sGXsfl_78_idx, context.localUtil.TToC( Z362ConfigGenPublicidadFecIni, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z363ConfigGenPublicidadFecFin_"+sGXsfl_78_idx, context.localUtil.TToC( Z363ConfigGenPublicidadFecFin, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z364ConfigGenPublicidadEsta_"+sGXsfl_78_idx, StringUtil.RTrim( Z364ConfigGenPublicidadEsta)) ;
            ChangePostValue( "nRcdDeleted_54_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_54), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_54_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_54), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_54_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_54), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_54 != 0 )
            {
               ChangePostValue( "CONFIGGENPUBLICIDADID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONFIGGENPUBLICIDADTIT_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadTit_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONFIGGENPUBLICIDADDES_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadDes_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONFIGGENPUBLICIDADIMA_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadIma_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONFIGGENPUBLICIDADFECINI_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadFecIni_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONFIGGENPUBLICIDADFECFIN_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadFecFin_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONFIGGENPUBLICIDADESTA_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbConfigGenPublicidadEsta.Enabled), 5, 0, ".", ""))) ;
            }
         }
         O365ConfigGenSerial = s365ConfigGenSerial;
         AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1C0( )
      {
      }

      protected void E111C2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV12WWPContext) ;
         AV8IsAuthorized = true;
         AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWConfigGen_Insert", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWConfigGen_Update", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWConfigGen_Delete", out  GXt_boolean1) ;
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
         edtConfigGenSerial_Visible = 0;
         AssignProp("", false, edtConfigGenSerial_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtConfigGenSerial_Visible), 5, 0), true);
      }

      protected void E121C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configgenww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1C53( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z368ConfigGenFecMod = T001C5_A368ConfigGenFecMod[0];
               Z351ConfigGenEmpNom = T001C5_A351ConfigGenEmpNom[0];
               Z352ConfigGenSiglas = T001C5_A352ConfigGenSiglas[0];
               Z354ConfigGenSiteWeb = T001C5_A354ConfigGenSiteWeb[0];
               Z355ConfigGenCorreo = T001C5_A355ConfigGenCorreo[0];
               Z356ConfigGenTelefono = T001C5_A356ConfigGenTelefono[0];
               Z357ConfigGenDireccion = T001C5_A357ConfigGenDireccion[0];
               Z358ConfigGenEstado = T001C5_A358ConfigGenEstado[0];
               Z370ConfigGenUsuarioMod = T001C5_A370ConfigGenUsuarioMod[0];
               Z365ConfigGenSerial = T001C5_A365ConfigGenSerial[0];
            }
            else
            {
               Z368ConfigGenFecMod = A368ConfigGenFecMod;
               Z351ConfigGenEmpNom = A351ConfigGenEmpNom;
               Z352ConfigGenSiglas = A352ConfigGenSiglas;
               Z354ConfigGenSiteWeb = A354ConfigGenSiteWeb;
               Z355ConfigGenCorreo = A355ConfigGenCorreo;
               Z356ConfigGenTelefono = A356ConfigGenTelefono;
               Z357ConfigGenDireccion = A357ConfigGenDireccion;
               Z358ConfigGenEstado = A358ConfigGenEstado;
               Z370ConfigGenUsuarioMod = A370ConfigGenUsuarioMod;
               Z365ConfigGenSerial = A365ConfigGenSerial;
            }
         }
         if ( GX_JID == -15 )
         {
            Z349ConfigGenID = A349ConfigGenID;
            Z368ConfigGenFecMod = A368ConfigGenFecMod;
            Z351ConfigGenEmpNom = A351ConfigGenEmpNom;
            Z352ConfigGenSiglas = A352ConfigGenSiglas;
            Z353ConfigGenLogo = A353ConfigGenLogo;
            Z40000ConfigGenLogo_GXI = A40000ConfigGenLogo_GXI;
            Z354ConfigGenSiteWeb = A354ConfigGenSiteWeb;
            Z355ConfigGenCorreo = A355ConfigGenCorreo;
            Z356ConfigGenTelefono = A356ConfigGenTelefono;
            Z357ConfigGenDireccion = A357ConfigGenDireccion;
            Z358ConfigGenEstado = A358ConfigGenEstado;
            Z370ConfigGenUsuarioMod = A370ConfigGenUsuarioMod;
            Z365ConfigGenSerial = A365ConfigGenSerial;
         }
      }

      protected void standaloneNotModal( )
      {
         edtConfigGenID_Enabled = 0;
         AssignProp("", false, edtConfigGenID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenID_Enabled), 5, 0), true);
         edtConfigGenSerial_Enabled = 0;
         AssignProp("", false, edtConfigGenSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenSerial_Enabled), 5, 0), true);
         edtConfigGenFecMod_Enabled = 0;
         AssignProp("", false, edtConfigGenFecMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenFecMod_Enabled), 5, 0), true);
         edtConfigGenUsuarioMod_Enabled = 0;
         AssignProp("", false, edtConfigGenUsuarioMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenUsuarioMod_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtConfigGenID_Enabled = 0;
         AssignProp("", false, edtConfigGenID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenID_Enabled), 5, 0), true);
         edtConfigGenSerial_Enabled = 0;
         AssignProp("", false, edtConfigGenSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenSerial_Enabled), 5, 0), true);
         edtConfigGenFecMod_Enabled = 0;
         AssignProp("", false, edtConfigGenFecMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenFecMod_Enabled), 5, 0), true);
         edtConfigGenUsuarioMod_Enabled = 0;
         AssignProp("", false, edtConfigGenUsuarioMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenUsuarioMod_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ConfigGenID) )
         {
            A349ConfigGenID = AV7ConfigGenID;
            AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  || IsUpd( )  )
         {
            A368ConfigGenFecMod = DateTimeUtil.ServerNow( context, pr_default);
            AssignAttri("", false, "A368ConfigGenFecMod", context.localUtil.TToC( A368ConfigGenFecMod, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
      }

      protected void Load1C53( )
      {
         /* Using cursor T001C6 */
         pr_default.execute(4, new Object[] {A349ConfigGenID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound53 = 1;
            A368ConfigGenFecMod = T001C6_A368ConfigGenFecMod[0];
            AssignAttri("", false, "A368ConfigGenFecMod", context.localUtil.TToC( A368ConfigGenFecMod, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A351ConfigGenEmpNom = T001C6_A351ConfigGenEmpNom[0];
            AssignAttri("", false, "A351ConfigGenEmpNom", A351ConfigGenEmpNom);
            A352ConfigGenSiglas = T001C6_A352ConfigGenSiglas[0];
            AssignAttri("", false, "A352ConfigGenSiglas", A352ConfigGenSiglas);
            A40000ConfigGenLogo_GXI = T001C6_A40000ConfigGenLogo_GXI[0];
            AssignProp("", false, imgConfigGenLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo)) ? A40000ConfigGenLogo_GXI : context.convertURL( context.PathToRelativeUrl( A353ConfigGenLogo))), true);
            AssignProp("", false, imgConfigGenLogo_Internalname, "SrcSet", context.GetImageSrcSet( A353ConfigGenLogo), true);
            A354ConfigGenSiteWeb = T001C6_A354ConfigGenSiteWeb[0];
            AssignAttri("", false, "A354ConfigGenSiteWeb", A354ConfigGenSiteWeb);
            A355ConfigGenCorreo = T001C6_A355ConfigGenCorreo[0];
            AssignAttri("", false, "A355ConfigGenCorreo", A355ConfigGenCorreo);
            A356ConfigGenTelefono = T001C6_A356ConfigGenTelefono[0];
            AssignAttri("", false, "A356ConfigGenTelefono", A356ConfigGenTelefono);
            A357ConfigGenDireccion = T001C6_A357ConfigGenDireccion[0];
            AssignAttri("", false, "A357ConfigGenDireccion", A357ConfigGenDireccion);
            A358ConfigGenEstado = T001C6_A358ConfigGenEstado[0];
            AssignAttri("", false, "A358ConfigGenEstado", A358ConfigGenEstado);
            A370ConfigGenUsuarioMod = T001C6_A370ConfigGenUsuarioMod[0];
            AssignAttri("", false, "A370ConfigGenUsuarioMod", A370ConfigGenUsuarioMod);
            A365ConfigGenSerial = T001C6_A365ConfigGenSerial[0];
            AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
            A353ConfigGenLogo = T001C6_A353ConfigGenLogo[0];
            AssignAttri("", false, "A353ConfigGenLogo", A353ConfigGenLogo);
            AssignProp("", false, imgConfigGenLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo)) ? A40000ConfigGenLogo_GXI : context.convertURL( context.PathToRelativeUrl( A353ConfigGenLogo))), true);
            AssignProp("", false, imgConfigGenLogo_Internalname, "SrcSet", context.GetImageSrcSet( A353ConfigGenLogo), true);
            ZM1C53( -15) ;
         }
         pr_default.close(4);
         OnLoadActions1C53( ) ;
      }

      protected void OnLoadActions1C53( )
      {
         AV15Pgmname = "ConfigGen";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
      }

      protected void CheckExtendedTable1C53( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV15Pgmname = "ConfigGen";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         if ( ! ( GxRegex.IsMatch(A355ConfigGenCorreo,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "CONFIGGENCORREO");
            AnyError = 1;
            GX_FocusControl = edtConfigGenCorreo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1C53( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1C53( )
      {
         /* Using cursor T001C7 */
         pr_default.execute(5, new Object[] {A349ConfigGenID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound53 = 1;
         }
         else
         {
            RcdFound53 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001C5 */
         pr_default.execute(3, new Object[] {A349ConfigGenID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1C53( 15) ;
            RcdFound53 = 1;
            A349ConfigGenID = T001C5_A349ConfigGenID[0];
            AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
            A368ConfigGenFecMod = T001C5_A368ConfigGenFecMod[0];
            AssignAttri("", false, "A368ConfigGenFecMod", context.localUtil.TToC( A368ConfigGenFecMod, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A351ConfigGenEmpNom = T001C5_A351ConfigGenEmpNom[0];
            AssignAttri("", false, "A351ConfigGenEmpNom", A351ConfigGenEmpNom);
            A352ConfigGenSiglas = T001C5_A352ConfigGenSiglas[0];
            AssignAttri("", false, "A352ConfigGenSiglas", A352ConfigGenSiglas);
            A40000ConfigGenLogo_GXI = T001C5_A40000ConfigGenLogo_GXI[0];
            AssignProp("", false, imgConfigGenLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo)) ? A40000ConfigGenLogo_GXI : context.convertURL( context.PathToRelativeUrl( A353ConfigGenLogo))), true);
            AssignProp("", false, imgConfigGenLogo_Internalname, "SrcSet", context.GetImageSrcSet( A353ConfigGenLogo), true);
            A354ConfigGenSiteWeb = T001C5_A354ConfigGenSiteWeb[0];
            AssignAttri("", false, "A354ConfigGenSiteWeb", A354ConfigGenSiteWeb);
            A355ConfigGenCorreo = T001C5_A355ConfigGenCorreo[0];
            AssignAttri("", false, "A355ConfigGenCorreo", A355ConfigGenCorreo);
            A356ConfigGenTelefono = T001C5_A356ConfigGenTelefono[0];
            AssignAttri("", false, "A356ConfigGenTelefono", A356ConfigGenTelefono);
            A357ConfigGenDireccion = T001C5_A357ConfigGenDireccion[0];
            AssignAttri("", false, "A357ConfigGenDireccion", A357ConfigGenDireccion);
            A358ConfigGenEstado = T001C5_A358ConfigGenEstado[0];
            AssignAttri("", false, "A358ConfigGenEstado", A358ConfigGenEstado);
            A370ConfigGenUsuarioMod = T001C5_A370ConfigGenUsuarioMod[0];
            AssignAttri("", false, "A370ConfigGenUsuarioMod", A370ConfigGenUsuarioMod);
            A365ConfigGenSerial = T001C5_A365ConfigGenSerial[0];
            AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
            A353ConfigGenLogo = T001C5_A353ConfigGenLogo[0];
            AssignAttri("", false, "A353ConfigGenLogo", A353ConfigGenLogo);
            AssignProp("", false, imgConfigGenLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo)) ? A40000ConfigGenLogo_GXI : context.convertURL( context.PathToRelativeUrl( A353ConfigGenLogo))), true);
            AssignProp("", false, imgConfigGenLogo_Internalname, "SrcSet", context.GetImageSrcSet( A353ConfigGenLogo), true);
            O365ConfigGenSerial = A365ConfigGenSerial;
            AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
            Z349ConfigGenID = A349ConfigGenID;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1C53( ) ;
            if ( AnyError == 1 )
            {
               RcdFound53 = 0;
               InitializeNonKey1C53( ) ;
            }
            Gx_mode = sMode53;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound53 = 0;
            InitializeNonKey1C53( ) ;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode53;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey1C53( ) ;
         if ( RcdFound53 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound53 = 0;
         /* Using cursor T001C8 */
         pr_default.execute(6, new Object[] {A349ConfigGenID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T001C8_A349ConfigGenID[0] < A349ConfigGenID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T001C8_A349ConfigGenID[0] > A349ConfigGenID ) ) )
            {
               A349ConfigGenID = T001C8_A349ConfigGenID[0];
               AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
               RcdFound53 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound53 = 0;
         /* Using cursor T001C9 */
         pr_default.execute(7, new Object[] {A349ConfigGenID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001C9_A349ConfigGenID[0] > A349ConfigGenID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001C9_A349ConfigGenID[0] < A349ConfigGenID ) ) )
            {
               A349ConfigGenID = T001C9_A349ConfigGenID[0];
               AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
               RcdFound53 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1C53( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A365ConfigGenSerial = O365ConfigGenSerial;
            AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
            GX_FocusControl = edtConfigGenEmpNom_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1C53( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound53 == 1 )
            {
               if ( A349ConfigGenID != Z349ConfigGenID )
               {
                  A349ConfigGenID = Z349ConfigGenID;
                  AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CONFIGGENID");
                  AnyError = 1;
                  GX_FocusControl = edtConfigGenID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A365ConfigGenSerial = O365ConfigGenSerial;
                  AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtConfigGenEmpNom_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A365ConfigGenSerial = O365ConfigGenSerial;
                  AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
                  Update1C53( ) ;
                  GX_FocusControl = edtConfigGenEmpNom_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A349ConfigGenID != Z349ConfigGenID )
               {
                  /* Insert record */
                  A365ConfigGenSerial = O365ConfigGenSerial;
                  AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
                  GX_FocusControl = edtConfigGenEmpNom_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1C53( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONFIGGENID");
                     AnyError = 1;
                     GX_FocusControl = edtConfigGenID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A365ConfigGenSerial = O365ConfigGenSerial;
                     AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
                     GX_FocusControl = edtConfigGenEmpNom_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1C53( ) ;
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
         if ( A349ConfigGenID != Z349ConfigGenID )
         {
            A349ConfigGenID = Z349ConfigGenID;
            AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CONFIGGENID");
            AnyError = 1;
            GX_FocusControl = edtConfigGenID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A365ConfigGenSerial = O365ConfigGenSerial;
            AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtConfigGenEmpNom_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1C53( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001C4 */
            pr_default.execute(2, new Object[] {A349ConfigGenID});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConfigGen"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( Z368ConfigGenFecMod != T001C4_A368ConfigGenFecMod[0] ) || ( StringUtil.StrCmp(Z351ConfigGenEmpNom, T001C4_A351ConfigGenEmpNom[0]) != 0 ) || ( StringUtil.StrCmp(Z352ConfigGenSiglas, T001C4_A352ConfigGenSiglas[0]) != 0 ) || ( StringUtil.StrCmp(Z354ConfigGenSiteWeb, T001C4_A354ConfigGenSiteWeb[0]) != 0 ) || ( StringUtil.StrCmp(Z355ConfigGenCorreo, T001C4_A355ConfigGenCorreo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z356ConfigGenTelefono, T001C4_A356ConfigGenTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z357ConfigGenDireccion, T001C4_A357ConfigGenDireccion[0]) != 0 ) || ( StringUtil.StrCmp(Z358ConfigGenEstado, T001C4_A358ConfigGenEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z370ConfigGenUsuarioMod, T001C4_A370ConfigGenUsuarioMod[0]) != 0 ) || ( Z365ConfigGenSerial != T001C4_A365ConfigGenSerial[0] ) )
            {
               if ( Z368ConfigGenFecMod != T001C4_A368ConfigGenFecMod[0] )
               {
                  GXUtil.WriteLog("configgen:[seudo value changed for attri]"+"ConfigGenFecMod");
                  GXUtil.WriteLogRaw("Old: ",Z368ConfigGenFecMod);
                  GXUtil.WriteLogRaw("Current: ",T001C4_A368ConfigGenFecMod[0]);
               }
               if ( StringUtil.StrCmp(Z351ConfigGenEmpNom, T001C4_A351ConfigGenEmpNom[0]) != 0 )
               {
                  GXUtil.WriteLog("configgen:[seudo value changed for attri]"+"ConfigGenEmpNom");
                  GXUtil.WriteLogRaw("Old: ",Z351ConfigGenEmpNom);
                  GXUtil.WriteLogRaw("Current: ",T001C4_A351ConfigGenEmpNom[0]);
               }
               if ( StringUtil.StrCmp(Z352ConfigGenSiglas, T001C4_A352ConfigGenSiglas[0]) != 0 )
               {
                  GXUtil.WriteLog("configgen:[seudo value changed for attri]"+"ConfigGenSiglas");
                  GXUtil.WriteLogRaw("Old: ",Z352ConfigGenSiglas);
                  GXUtil.WriteLogRaw("Current: ",T001C4_A352ConfigGenSiglas[0]);
               }
               if ( StringUtil.StrCmp(Z354ConfigGenSiteWeb, T001C4_A354ConfigGenSiteWeb[0]) != 0 )
               {
                  GXUtil.WriteLog("configgen:[seudo value changed for attri]"+"ConfigGenSiteWeb");
                  GXUtil.WriteLogRaw("Old: ",Z354ConfigGenSiteWeb);
                  GXUtil.WriteLogRaw("Current: ",T001C4_A354ConfigGenSiteWeb[0]);
               }
               if ( StringUtil.StrCmp(Z355ConfigGenCorreo, T001C4_A355ConfigGenCorreo[0]) != 0 )
               {
                  GXUtil.WriteLog("configgen:[seudo value changed for attri]"+"ConfigGenCorreo");
                  GXUtil.WriteLogRaw("Old: ",Z355ConfigGenCorreo);
                  GXUtil.WriteLogRaw("Current: ",T001C4_A355ConfigGenCorreo[0]);
               }
               if ( StringUtil.StrCmp(Z356ConfigGenTelefono, T001C4_A356ConfigGenTelefono[0]) != 0 )
               {
                  GXUtil.WriteLog("configgen:[seudo value changed for attri]"+"ConfigGenTelefono");
                  GXUtil.WriteLogRaw("Old: ",Z356ConfigGenTelefono);
                  GXUtil.WriteLogRaw("Current: ",T001C4_A356ConfigGenTelefono[0]);
               }
               if ( StringUtil.StrCmp(Z357ConfigGenDireccion, T001C4_A357ConfigGenDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("configgen:[seudo value changed for attri]"+"ConfigGenDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z357ConfigGenDireccion);
                  GXUtil.WriteLogRaw("Current: ",T001C4_A357ConfigGenDireccion[0]);
               }
               if ( StringUtil.StrCmp(Z358ConfigGenEstado, T001C4_A358ConfigGenEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("configgen:[seudo value changed for attri]"+"ConfigGenEstado");
                  GXUtil.WriteLogRaw("Old: ",Z358ConfigGenEstado);
                  GXUtil.WriteLogRaw("Current: ",T001C4_A358ConfigGenEstado[0]);
               }
               if ( StringUtil.StrCmp(Z370ConfigGenUsuarioMod, T001C4_A370ConfigGenUsuarioMod[0]) != 0 )
               {
                  GXUtil.WriteLog("configgen:[seudo value changed for attri]"+"ConfigGenUsuarioMod");
                  GXUtil.WriteLogRaw("Old: ",Z370ConfigGenUsuarioMod);
                  GXUtil.WriteLogRaw("Current: ",T001C4_A370ConfigGenUsuarioMod[0]);
               }
               if ( Z365ConfigGenSerial != T001C4_A365ConfigGenSerial[0] )
               {
                  GXUtil.WriteLog("configgen:[seudo value changed for attri]"+"ConfigGenSerial");
                  GXUtil.WriteLogRaw("Old: ",Z365ConfigGenSerial);
                  GXUtil.WriteLogRaw("Current: ",T001C4_A365ConfigGenSerial[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ConfigGen"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1C53( )
      {
         BeforeValidate1C53( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C53( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1C53( 0) ;
            CheckOptimisticConcurrency1C53( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C53( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1C53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001C10 */
                     pr_default.execute(8, new Object[] {A368ConfigGenFecMod, A351ConfigGenEmpNom, A352ConfigGenSiglas, A353ConfigGenLogo, A40000ConfigGenLogo_GXI, A354ConfigGenSiteWeb, A355ConfigGenCorreo, A356ConfigGenTelefono, A357ConfigGenDireccion, A358ConfigGenEstado, A370ConfigGenUsuarioMod, A365ConfigGenSerial});
                     A349ConfigGenID = T001C10_A349ConfigGenID[0];
                     AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("ConfigGen");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1C53( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1C0( ) ;
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
               Load1C53( ) ;
            }
            EndLevel1C53( ) ;
         }
         CloseExtendedTableCursors1C53( ) ;
      }

      protected void Update1C53( )
      {
         BeforeValidate1C53( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C53( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C53( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C53( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1C53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001C11 */
                     pr_default.execute(9, new Object[] {A368ConfigGenFecMod, A351ConfigGenEmpNom, A352ConfigGenSiglas, A354ConfigGenSiteWeb, A355ConfigGenCorreo, A356ConfigGenTelefono, A357ConfigGenDireccion, A358ConfigGenEstado, A370ConfigGenUsuarioMod, A365ConfigGenSerial, A349ConfigGenID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("ConfigGen");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConfigGen"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1C53( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1C53( ) ;
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
            EndLevel1C53( ) ;
         }
         CloseExtendedTableCursors1C53( ) ;
      }

      protected void DeferredUpdate1C53( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001C12 */
            pr_default.execute(10, new Object[] {A353ConfigGenLogo, A40000ConfigGenLogo_GXI, A349ConfigGenID});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("ConfigGen");
         }
      }

      protected void delete( )
      {
         BeforeValidate1C53( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C53( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1C53( ) ;
            AfterConfirm1C53( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1C53( ) ;
               if ( AnyError == 0 )
               {
                  A365ConfigGenSerial = O365ConfigGenSerial;
                  AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
                  ScanStart1C54( ) ;
                  while ( RcdFound54 != 0 )
                  {
                     getByPrimaryKey1C54( ) ;
                     Delete1C54( ) ;
                     ScanNext1C54( ) ;
                     O365ConfigGenSerial = A365ConfigGenSerial;
                     AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
                  }
                  ScanEnd1C54( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001C13 */
                     pr_default.execute(11, new Object[] {A349ConfigGenID});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("ConfigGen");
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
         sMode53 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1C53( ) ;
         Gx_mode = sMode53;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1C53( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "ConfigGen";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001C14 */
            pr_default.execute(12, new Object[] {A349ConfigGenID});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Resumen", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void ProcessNestedLevel1C54( )
      {
         s365ConfigGenSerial = O365ConfigGenSerial;
         AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
         nGXsfl_78_idx = 0;
         while ( nGXsfl_78_idx < nRC_GXsfl_78 )
         {
            ReadRow1C54( ) ;
            if ( ( nRcdExists_54 != 0 ) || ( nIsMod_54 != 0 ) )
            {
               standaloneNotModal1C54( ) ;
               GetKey1C54( ) ;
               if ( ( nRcdExists_54 == 0 ) && ( nRcdDeleted_54 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1C54( ) ;
               }
               else
               {
                  if ( RcdFound54 != 0 )
                  {
                     if ( ( nRcdDeleted_54 != 0 ) && ( nRcdExists_54 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1C54( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_54 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1C54( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_54 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               O365ConfigGenSerial = A365ConfigGenSerial;
               AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
            }
            ChangePostValue( edtConfigGenPublicidadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A350ConfigGenPublicidadId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtConfigGenPublicidadTit_Internalname, StringUtil.RTrim( A359ConfigGenPublicidadTit)) ;
            ChangePostValue( edtConfigGenPublicidadDes_Internalname, A360ConfigGenPublicidadDes) ;
            ChangePostValue( edtConfigGenPublicidadIma_Internalname, A361ConfigGenPublicidadIma) ;
            ChangePostValue( edtConfigGenPublicidadFecIni_Internalname, context.localUtil.TToC( A362ConfigGenPublicidadFecIni, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( edtConfigGenPublicidadFecFin_Internalname, context.localUtil.TToC( A363ConfigGenPublicidadFecFin, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( cmbConfigGenPublicidadEsta_Internalname, StringUtil.RTrim( A364ConfigGenPublicidadEsta)) ;
            ChangePostValue( "ZT_"+"Z350ConfigGenPublicidadId_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z350ConfigGenPublicidadId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z359ConfigGenPublicidadTit_"+sGXsfl_78_idx, StringUtil.RTrim( Z359ConfigGenPublicidadTit)) ;
            ChangePostValue( "ZT_"+"Z362ConfigGenPublicidadFecIni_"+sGXsfl_78_idx, context.localUtil.TToC( Z362ConfigGenPublicidadFecIni, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z363ConfigGenPublicidadFecFin_"+sGXsfl_78_idx, context.localUtil.TToC( Z363ConfigGenPublicidadFecFin, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z364ConfigGenPublicidadEsta_"+sGXsfl_78_idx, StringUtil.RTrim( Z364ConfigGenPublicidadEsta)) ;
            ChangePostValue( "nRcdDeleted_54_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_54), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_54_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_54), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_54_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_54), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_54 != 0 )
            {
               ChangePostValue( "CONFIGGENPUBLICIDADID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONFIGGENPUBLICIDADTIT_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadTit_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONFIGGENPUBLICIDADDES_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadDes_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONFIGGENPUBLICIDADIMA_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadIma_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONFIGGENPUBLICIDADFECINI_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadFecIni_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONFIGGENPUBLICIDADFECFIN_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadFecFin_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CONFIGGENPUBLICIDADESTA_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbConfigGenPublicidadEsta.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1C54( ) ;
         if ( AnyError != 0 )
         {
            O365ConfigGenSerial = s365ConfigGenSerial;
            AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
         }
         nRcdExists_54 = 0;
         nIsMod_54 = 0;
         nRcdDeleted_54 = 0;
      }

      protected void ProcessLevel1C53( )
      {
         /* Save parent mode. */
         sMode53 = Gx_mode;
         ProcessNestedLevel1C54( ) ;
         if ( AnyError != 0 )
         {
            O365ConfigGenSerial = s365ConfigGenSerial;
            AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode53;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T001C15 */
         pr_default.execute(13, new Object[] {A365ConfigGenSerial, A349ConfigGenID});
         pr_default.close(13);
         pr_default.SmartCacheProvider.SetUpdated("ConfigGen");
      }

      protected void EndLevel1C53( )
      {
         pr_default.close(2);
         if ( AnyError == 0 )
         {
            BeforeComplete1C53( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.CommitDataStores("configgen",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1C0( ) ;
            }
            /* After transaction rules */
            GXt_char2 = AV11Ok;
            new aactualizaciones(context ).execute(  context.GetMessage( context.GetMessage( "ConfigGen", ""), ""), out  GXt_char2) ;
            AV11Ok = GXt_char2;
            AssignAttri("", false, "AV11Ok", AV11Ok);
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.RollbackDataStores("configgen",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1C53( )
      {
         /* Scan By routine */
         /* Using cursor T001C16 */
         pr_default.execute(14);
         RcdFound53 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound53 = 1;
            A349ConfigGenID = T001C16_A349ConfigGenID[0];
            AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1C53( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound53 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound53 = 1;
            A349ConfigGenID = T001C16_A349ConfigGenID[0];
            AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
         }
      }

      protected void ScanEnd1C53( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm1C53( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1C53( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1C53( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1C53( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1C53( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1C53( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1C53( )
      {
         edtConfigGenID_Enabled = 0;
         AssignProp("", false, edtConfigGenID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenID_Enabled), 5, 0), true);
         edtConfigGenEmpNom_Enabled = 0;
         AssignProp("", false, edtConfigGenEmpNom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenEmpNom_Enabled), 5, 0), true);
         edtConfigGenSiglas_Enabled = 0;
         AssignProp("", false, edtConfigGenSiglas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenSiglas_Enabled), 5, 0), true);
         imgConfigGenLogo_Enabled = 0;
         AssignProp("", false, imgConfigGenLogo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgConfigGenLogo_Enabled), 5, 0), true);
         edtConfigGenSiteWeb_Enabled = 0;
         AssignProp("", false, edtConfigGenSiteWeb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenSiteWeb_Enabled), 5, 0), true);
         edtConfigGenCorreo_Enabled = 0;
         AssignProp("", false, edtConfigGenCorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenCorreo_Enabled), 5, 0), true);
         edtConfigGenTelefono_Enabled = 0;
         AssignProp("", false, edtConfigGenTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenTelefono_Enabled), 5, 0), true);
         edtConfigGenDireccion_Enabled = 0;
         AssignProp("", false, edtConfigGenDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenDireccion_Enabled), 5, 0), true);
         cmbConfigGenEstado.Enabled = 0;
         AssignProp("", false, cmbConfigGenEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConfigGenEstado.Enabled), 5, 0), true);
         edtConfigGenFecMod_Enabled = 0;
         AssignProp("", false, edtConfigGenFecMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenFecMod_Enabled), 5, 0), true);
         edtConfigGenUsuarioMod_Enabled = 0;
         AssignProp("", false, edtConfigGenUsuarioMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenUsuarioMod_Enabled), 5, 0), true);
         edtConfigGenSerial_Enabled = 0;
         AssignProp("", false, edtConfigGenSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenSerial_Enabled), 5, 0), true);
      }

      protected void ZM1C54( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z359ConfigGenPublicidadTit = T001C3_A359ConfigGenPublicidadTit[0];
               Z362ConfigGenPublicidadFecIni = T001C3_A362ConfigGenPublicidadFecIni[0];
               Z363ConfigGenPublicidadFecFin = T001C3_A363ConfigGenPublicidadFecFin[0];
               Z364ConfigGenPublicidadEsta = T001C3_A364ConfigGenPublicidadEsta[0];
            }
            else
            {
               Z359ConfigGenPublicidadTit = A359ConfigGenPublicidadTit;
               Z362ConfigGenPublicidadFecIni = A362ConfigGenPublicidadFecIni;
               Z363ConfigGenPublicidadFecFin = A363ConfigGenPublicidadFecFin;
               Z364ConfigGenPublicidadEsta = A364ConfigGenPublicidadEsta;
            }
         }
         if ( GX_JID == -16 )
         {
            Z349ConfigGenID = A349ConfigGenID;
            Z350ConfigGenPublicidadId = A350ConfigGenPublicidadId;
            Z359ConfigGenPublicidadTit = A359ConfigGenPublicidadTit;
            Z360ConfigGenPublicidadDes = A360ConfigGenPublicidadDes;
            Z361ConfigGenPublicidadIma = A361ConfigGenPublicidadIma;
            Z40001ConfigGenPublicidadIma_GXI = A40001ConfigGenPublicidadIma_GXI;
            Z362ConfigGenPublicidadFecIni = A362ConfigGenPublicidadFecIni;
            Z363ConfigGenPublicidadFecFin = A363ConfigGenPublicidadFecFin;
            Z364ConfigGenPublicidadEsta = A364ConfigGenPublicidadEsta;
         }
      }

      protected void standaloneNotModal1C54( )
      {
         edtConfigGenPublicidadId_Enabled = 0;
         AssignProp("", false, edtConfigGenPublicidadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenPublicidadId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtConfigGenSerial_Enabled = 0;
         AssignProp("", false, edtConfigGenSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenSerial_Enabled), 5, 0), true);
         edtConfigGenSerial_Enabled = 0;
         AssignProp("", false, edtConfigGenSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenSerial_Enabled), 5, 0), true);
      }

      protected void standaloneModal1C54( )
      {
         if ( IsIns( )  )
         {
            A365ConfigGenSerial = (long)(O365ConfigGenSerial+1);
            AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A350ConfigGenPublicidadId = A365ConfigGenSerial;
         }
      }

      protected void Load1C54( )
      {
         /* Using cursor T001C17 */
         pr_default.execute(15, new Object[] {A349ConfigGenID, A350ConfigGenPublicidadId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound54 = 1;
            A359ConfigGenPublicidadTit = T001C17_A359ConfigGenPublicidadTit[0];
            A360ConfigGenPublicidadDes = T001C17_A360ConfigGenPublicidadDes[0];
            A40001ConfigGenPublicidadIma_GXI = T001C17_A40001ConfigGenPublicidadIma_GXI[0];
            AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma)) ? A40001ConfigGenPublicidadIma_GXI : context.convertURL( context.PathToRelativeUrl( A361ConfigGenPublicidadIma))), !bGXsfl_78_Refreshing);
            AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "SrcSet", context.GetImageSrcSet( A361ConfigGenPublicidadIma), true);
            A362ConfigGenPublicidadFecIni = T001C17_A362ConfigGenPublicidadFecIni[0];
            A363ConfigGenPublicidadFecFin = T001C17_A363ConfigGenPublicidadFecFin[0];
            A364ConfigGenPublicidadEsta = T001C17_A364ConfigGenPublicidadEsta[0];
            A361ConfigGenPublicidadIma = T001C17_A361ConfigGenPublicidadIma[0];
            AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma)) ? A40001ConfigGenPublicidadIma_GXI : context.convertURL( context.PathToRelativeUrl( A361ConfigGenPublicidadIma))), !bGXsfl_78_Refreshing);
            AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "SrcSet", context.GetImageSrcSet( A361ConfigGenPublicidadIma), true);
            ZM1C54( -16) ;
         }
         pr_default.close(15);
         OnLoadActions1C54( ) ;
      }

      protected void OnLoadActions1C54( )
      {
      }

      protected void CheckExtendedTable1C54( )
      {
         nIsDirty_54 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1C54( ) ;
         if ( ! ( (DateTime.MinValue==A362ConfigGenPublicidadFecIni) || ( A362ConfigGenPublicidadFecIni >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GXCCtl = "CONFIGGENPUBLICIDADFECINI_" + sGXsfl_78_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha de Inicio", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtConfigGenPublicidadFecIni_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A363ConfigGenPublicidadFecFin) || ( A363ConfigGenPublicidadFecFin >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GXCCtl = "CONFIGGENPUBLICIDADFECFIN_" + sGXsfl_78_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha Fin", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtConfigGenPublicidadFecFin_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1C54( )
      {
      }

      protected void enableDisable1C54( )
      {
      }

      protected void GetKey1C54( )
      {
         /* Using cursor T001C18 */
         pr_default.execute(16, new Object[] {A349ConfigGenID, A350ConfigGenPublicidadId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound54 = 1;
         }
         else
         {
            RcdFound54 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey1C54( )
      {
         /* Using cursor T001C3 */
         pr_default.execute(1, new Object[] {A349ConfigGenID, A350ConfigGenPublicidadId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1C54( 16) ;
            RcdFound54 = 1;
            InitializeNonKey1C54( ) ;
            A350ConfigGenPublicidadId = T001C3_A350ConfigGenPublicidadId[0];
            A359ConfigGenPublicidadTit = T001C3_A359ConfigGenPublicidadTit[0];
            A360ConfigGenPublicidadDes = T001C3_A360ConfigGenPublicidadDes[0];
            A40001ConfigGenPublicidadIma_GXI = T001C3_A40001ConfigGenPublicidadIma_GXI[0];
            AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma)) ? A40001ConfigGenPublicidadIma_GXI : context.convertURL( context.PathToRelativeUrl( A361ConfigGenPublicidadIma))), !bGXsfl_78_Refreshing);
            AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "SrcSet", context.GetImageSrcSet( A361ConfigGenPublicidadIma), true);
            A362ConfigGenPublicidadFecIni = T001C3_A362ConfigGenPublicidadFecIni[0];
            A363ConfigGenPublicidadFecFin = T001C3_A363ConfigGenPublicidadFecFin[0];
            A364ConfigGenPublicidadEsta = T001C3_A364ConfigGenPublicidadEsta[0];
            A361ConfigGenPublicidadIma = T001C3_A361ConfigGenPublicidadIma[0];
            AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma)) ? A40001ConfigGenPublicidadIma_GXI : context.convertURL( context.PathToRelativeUrl( A361ConfigGenPublicidadIma))), !bGXsfl_78_Refreshing);
            AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "SrcSet", context.GetImageSrcSet( A361ConfigGenPublicidadIma), true);
            Z349ConfigGenID = A349ConfigGenID;
            Z350ConfigGenPublicidadId = A350ConfigGenPublicidadId;
            sMode54 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1C54( ) ;
            Gx_mode = sMode54;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound54 = 0;
            InitializeNonKey1C54( ) ;
            sMode54 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1C54( ) ;
            Gx_mode = sMode54;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1C54( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1C54( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001C2 */
            pr_default.execute(0, new Object[] {A349ConfigGenID, A350ConfigGenPublicidadId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConfigGenPublicidad"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z359ConfigGenPublicidadTit, T001C2_A359ConfigGenPublicidadTit[0]) != 0 ) || ( Z362ConfigGenPublicidadFecIni != T001C2_A362ConfigGenPublicidadFecIni[0] ) || ( Z363ConfigGenPublicidadFecFin != T001C2_A363ConfigGenPublicidadFecFin[0] ) || ( StringUtil.StrCmp(Z364ConfigGenPublicidadEsta, T001C2_A364ConfigGenPublicidadEsta[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z359ConfigGenPublicidadTit, T001C2_A359ConfigGenPublicidadTit[0]) != 0 )
               {
                  GXUtil.WriteLog("configgen:[seudo value changed for attri]"+"ConfigGenPublicidadTit");
                  GXUtil.WriteLogRaw("Old: ",Z359ConfigGenPublicidadTit);
                  GXUtil.WriteLogRaw("Current: ",T001C2_A359ConfigGenPublicidadTit[0]);
               }
               if ( Z362ConfigGenPublicidadFecIni != T001C2_A362ConfigGenPublicidadFecIni[0] )
               {
                  GXUtil.WriteLog("configgen:[seudo value changed for attri]"+"ConfigGenPublicidadFecIni");
                  GXUtil.WriteLogRaw("Old: ",Z362ConfigGenPublicidadFecIni);
                  GXUtil.WriteLogRaw("Current: ",T001C2_A362ConfigGenPublicidadFecIni[0]);
               }
               if ( Z363ConfigGenPublicidadFecFin != T001C2_A363ConfigGenPublicidadFecFin[0] )
               {
                  GXUtil.WriteLog("configgen:[seudo value changed for attri]"+"ConfigGenPublicidadFecFin");
                  GXUtil.WriteLogRaw("Old: ",Z363ConfigGenPublicidadFecFin);
                  GXUtil.WriteLogRaw("Current: ",T001C2_A363ConfigGenPublicidadFecFin[0]);
               }
               if ( StringUtil.StrCmp(Z364ConfigGenPublicidadEsta, T001C2_A364ConfigGenPublicidadEsta[0]) != 0 )
               {
                  GXUtil.WriteLog("configgen:[seudo value changed for attri]"+"ConfigGenPublicidadEsta");
                  GXUtil.WriteLogRaw("Old: ",Z364ConfigGenPublicidadEsta);
                  GXUtil.WriteLogRaw("Current: ",T001C2_A364ConfigGenPublicidadEsta[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ConfigGenPublicidad"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1C54( )
      {
         BeforeValidate1C54( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C54( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1C54( 0) ;
            CheckOptimisticConcurrency1C54( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C54( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1C54( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001C19 */
                     pr_default.execute(17, new Object[] {A349ConfigGenID, A350ConfigGenPublicidadId, A359ConfigGenPublicidadTit, A360ConfigGenPublicidadDes, A361ConfigGenPublicidadIma, A40001ConfigGenPublicidadIma_GXI, A362ConfigGenPublicidadFecIni, A363ConfigGenPublicidadFecFin, A364ConfigGenPublicidadEsta});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("ConfigGenPublicidad");
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
               Load1C54( ) ;
            }
            EndLevel1C54( ) ;
         }
         CloseExtendedTableCursors1C54( ) ;
      }

      protected void Update1C54( )
      {
         BeforeValidate1C54( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C54( ) ;
         }
         if ( ( nIsMod_54 != 0 ) || ( nIsDirty_54 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1C54( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1C54( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1C54( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001C20 */
                        pr_default.execute(18, new Object[] {A359ConfigGenPublicidadTit, A360ConfigGenPublicidadDes, A362ConfigGenPublicidadFecIni, A363ConfigGenPublicidadFecFin, A364ConfigGenPublicidadEsta, A349ConfigGenID, A350ConfigGenPublicidadId});
                        pr_default.close(18);
                        pr_default.SmartCacheProvider.SetUpdated("ConfigGenPublicidad");
                        if ( (pr_default.getStatus(18) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConfigGenPublicidad"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1C54( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1C54( ) ;
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
               EndLevel1C54( ) ;
            }
         }
         CloseExtendedTableCursors1C54( ) ;
      }

      protected void DeferredUpdate1C54( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001C21 */
            pr_default.execute(19, new Object[] {A361ConfigGenPublicidadIma, A40001ConfigGenPublicidadIma_GXI, A349ConfigGenID, A350ConfigGenPublicidadId});
            pr_default.close(19);
            pr_default.SmartCacheProvider.SetUpdated("ConfigGenPublicidad");
         }
      }

      protected void Delete1C54( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1C54( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C54( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1C54( ) ;
            AfterConfirm1C54( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1C54( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001C22 */
                  pr_default.execute(20, new Object[] {A349ConfigGenID, A350ConfigGenPublicidadId});
                  pr_default.close(20);
                  pr_default.SmartCacheProvider.SetUpdated("ConfigGenPublicidad");
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
         sMode54 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1C54( ) ;
         Gx_mode = sMode54;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1C54( )
      {
         standaloneModal1C54( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1C54( )
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

      public void ScanStart1C54( )
      {
         /* Scan By routine */
         /* Using cursor T001C23 */
         pr_default.execute(21, new Object[] {A349ConfigGenID});
         RcdFound54 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound54 = 1;
            A350ConfigGenPublicidadId = T001C23_A350ConfigGenPublicidadId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1C54( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound54 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound54 = 1;
            A350ConfigGenPublicidadId = T001C23_A350ConfigGenPublicidadId[0];
         }
      }

      protected void ScanEnd1C54( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm1C54( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1C54( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1C54( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1C54( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1C54( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1C54( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1C54( )
      {
         edtConfigGenPublicidadId_Enabled = 0;
         AssignProp("", false, edtConfigGenPublicidadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenPublicidadId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtConfigGenPublicidadTit_Enabled = 0;
         AssignProp("", false, edtConfigGenPublicidadTit_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenPublicidadTit_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtConfigGenPublicidadDes_Enabled = 0;
         AssignProp("", false, edtConfigGenPublicidadDes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenPublicidadDes_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtConfigGenPublicidadIma_Enabled = 0;
         AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenPublicidadIma_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtConfigGenPublicidadFecIni_Enabled = 0;
         AssignProp("", false, edtConfigGenPublicidadFecIni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenPublicidadFecIni_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtConfigGenPublicidadFecFin_Enabled = 0;
         AssignProp("", false, edtConfigGenPublicidadFecFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenPublicidadFecFin_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         cmbConfigGenPublicidadEsta.Enabled = 0;
         AssignProp("", false, cmbConfigGenPublicidadEsta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConfigGenPublicidadEsta.Enabled), 5, 0), !bGXsfl_78_Refreshing);
      }

      protected void send_integrity_lvl_hashes1C54( )
      {
      }

      protected void send_integrity_lvl_hashes1C53( )
      {
      }

      protected void SubsflControlProps_7854( )
      {
         edtConfigGenPublicidadId_Internalname = "CONFIGGENPUBLICIDADID_"+sGXsfl_78_idx;
         edtConfigGenPublicidadTit_Internalname = "CONFIGGENPUBLICIDADTIT_"+sGXsfl_78_idx;
         edtConfigGenPublicidadDes_Internalname = "CONFIGGENPUBLICIDADDES_"+sGXsfl_78_idx;
         edtConfigGenPublicidadIma_Internalname = "CONFIGGENPUBLICIDADIMA_"+sGXsfl_78_idx;
         edtConfigGenPublicidadFecIni_Internalname = "CONFIGGENPUBLICIDADFECINI_"+sGXsfl_78_idx;
         edtConfigGenPublicidadFecFin_Internalname = "CONFIGGENPUBLICIDADFECFIN_"+sGXsfl_78_idx;
         cmbConfigGenPublicidadEsta_Internalname = "CONFIGGENPUBLICIDADESTA_"+sGXsfl_78_idx;
      }

      protected void SubsflControlProps_fel_7854( )
      {
         edtConfigGenPublicidadId_Internalname = "CONFIGGENPUBLICIDADID_"+sGXsfl_78_fel_idx;
         edtConfigGenPublicidadTit_Internalname = "CONFIGGENPUBLICIDADTIT_"+sGXsfl_78_fel_idx;
         edtConfigGenPublicidadDes_Internalname = "CONFIGGENPUBLICIDADDES_"+sGXsfl_78_fel_idx;
         edtConfigGenPublicidadIma_Internalname = "CONFIGGENPUBLICIDADIMA_"+sGXsfl_78_fel_idx;
         edtConfigGenPublicidadFecIni_Internalname = "CONFIGGENPUBLICIDADFECINI_"+sGXsfl_78_fel_idx;
         edtConfigGenPublicidadFecFin_Internalname = "CONFIGGENPUBLICIDADFECFIN_"+sGXsfl_78_fel_idx;
         cmbConfigGenPublicidadEsta_Internalname = "CONFIGGENPUBLICIDADESTA_"+sGXsfl_78_fel_idx;
      }

      protected void AddRow1C54( )
      {
         nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
         SubsflControlProps_7854( ) ;
         SendRow1C54( ) ;
      }

      protected void SendRow1C54( )
      {
         Gridlevel_publicidadRow = GXWebRow.GetNew(context);
         if ( subGridlevel_publicidad_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_publicidad_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_publicidad_Class, "") != 0 )
            {
               subGridlevel_publicidad_Linesclass = subGridlevel_publicidad_Class+"Odd";
            }
         }
         else if ( subGridlevel_publicidad_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_publicidad_Backstyle = 0;
            subGridlevel_publicidad_Backcolor = subGridlevel_publicidad_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_publicidad_Class, "") != 0 )
            {
               subGridlevel_publicidad_Linesclass = subGridlevel_publicidad_Class+"Uniform";
            }
         }
         else if ( subGridlevel_publicidad_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_publicidad_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_publicidad_Class, "") != 0 )
            {
               subGridlevel_publicidad_Linesclass = subGridlevel_publicidad_Class+"Odd";
            }
            subGridlevel_publicidad_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_publicidad_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_publicidad_Backstyle = 1;
            if ( ((int)((nGXsfl_78_idx) % (2))) == 0 )
            {
               subGridlevel_publicidad_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_publicidad_Class, "") != 0 )
               {
                  subGridlevel_publicidad_Linesclass = subGridlevel_publicidad_Class+"Even";
               }
            }
            else
            {
               subGridlevel_publicidad_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_publicidad_Class, "") != 0 )
               {
                  subGridlevel_publicidad_Linesclass = subGridlevel_publicidad_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_54_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridlevel_publicidadRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConfigGenPublicidadId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A350ConfigGenPublicidadId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtConfigGenPublicidadId_Enabled!=0) ? context.localUtil.Format( (decimal)(A350ConfigGenPublicidadId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A350ConfigGenPublicidadId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,79);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConfigGenPublicidadId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtConfigGenPublicidadId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_54_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridlevel_publicidadRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConfigGenPublicidadTit_Internalname,StringUtil.RTrim( A359ConfigGenPublicidadTit),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConfigGenPublicidadTit_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtConfigGenPublicidadTit_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_54_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridlevel_publicidadRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConfigGenPublicidadDes_Internalname,(string)A360ConfigGenPublicidadDes,(string)A360ConfigGenPublicidadDes,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConfigGenPublicidadDes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtConfigGenPublicidadDes_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)78,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         /* Static Bitmap Variable */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_54_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ClassString = "Attribute";
         StyleString = "";
         A361ConfigGenPublicidadIma_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001ConfigGenPublicidadIma_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma)) ? A40001ConfigGenPublicidadIma_GXI : context.PathToRelativeUrl( A361ConfigGenPublicidadIma));
         Gridlevel_publicidadRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtConfigGenPublicidadIma_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtConfigGenPublicidadIma_Enabled,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"",(string)"",(string)"",(string)"",(short)0,(bool)A361ConfigGenPublicidadIma_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
         AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma)) ? A40001ConfigGenPublicidadIma_GXI : context.PathToRelativeUrl( A361ConfigGenPublicidadIma)), !bGXsfl_78_Refreshing);
         AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "IsBlob", StringUtil.BoolToStr( A361ConfigGenPublicidadIma_IsBlob), !bGXsfl_78_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_54_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridlevel_publicidadRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConfigGenPublicidadFecIni_Internalname,context.localUtil.TToC( A362ConfigGenPublicidadFecIni, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A362ConfigGenPublicidadFecIni, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,83);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConfigGenPublicidadFecIni_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtConfigGenPublicidadFecIni_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_54_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridlevel_publicidadRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConfigGenPublicidadFecFin_Internalname,context.localUtil.TToC( A363ConfigGenPublicidadFecFin, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A363ConfigGenPublicidadFecFin, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,84);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConfigGenPublicidadFecFin_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtConfigGenPublicidadFecFin_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_54_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_78_idx + "',78)\"";
         if ( ( cmbConfigGenPublicidadEsta.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "CONFIGGENPUBLICIDADESTA_" + sGXsfl_78_idx;
            cmbConfigGenPublicidadEsta.Name = GXCCtl;
            cmbConfigGenPublicidadEsta.WebTags = "";
            cmbConfigGenPublicidadEsta.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
            cmbConfigGenPublicidadEsta.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
            if ( cmbConfigGenPublicidadEsta.ItemCount > 0 )
            {
               A364ConfigGenPublicidadEsta = cmbConfigGenPublicidadEsta.getValidValue(A364ConfigGenPublicidadEsta);
            }
         }
         /* ComboBox */
         Gridlevel_publicidadRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbConfigGenPublicidadEsta,(string)cmbConfigGenPublicidadEsta_Internalname,StringUtil.RTrim( A364ConfigGenPublicidadEsta),(short)1,(string)cmbConfigGenPublicidadEsta_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbConfigGenPublicidadEsta.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"",(string)"",(bool)true,(short)0});
         cmbConfigGenPublicidadEsta.CurrentValue = StringUtil.RTrim( A364ConfigGenPublicidadEsta);
         AssignProp("", false, cmbConfigGenPublicidadEsta_Internalname, "Values", (string)(cmbConfigGenPublicidadEsta.ToJavascriptSource()), !bGXsfl_78_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_publicidadRow);
         send_integrity_lvl_hashes1C54( ) ;
         GXCCtl = "Z350ConfigGenPublicidadId_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z350ConfigGenPublicidadId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z359ConfigGenPublicidadTit_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z359ConfigGenPublicidadTit));
         GXCCtl = "Z362ConfigGenPublicidadFecIni_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z362ConfigGenPublicidadFecIni, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z363ConfigGenPublicidadFecFin_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z363ConfigGenPublicidadFecFin, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z364ConfigGenPublicidadEsta_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z364ConfigGenPublicidadEsta));
         GXCCtl = "nRcdDeleted_54_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_54), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_54_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_54), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_54_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_54), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_78_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vCONFIGGENID_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "CONFIGGENPUBLICIDADIMA_" + sGXsfl_78_idx;
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A361ConfigGenPublicidadIma);
         GxWebStd.gx_hidden_field( context, "CONFIGGENPUBLICIDADID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CONFIGGENPUBLICIDADTIT_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadTit_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CONFIGGENPUBLICIDADDES_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadDes_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CONFIGGENPUBLICIDADIMA_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadIma_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CONFIGGENPUBLICIDADFECINI_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadFecIni_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CONFIGGENPUBLICIDADFECFIN_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadFecFin_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CONFIGGENPUBLICIDADESTA_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbConfigGenPublicidadEsta.Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_publicidadContainer.AddRow(Gridlevel_publicidadRow);
      }

      protected void ReadRow1C54( )
      {
         nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
         SubsflControlProps_7854( ) ;
         edtConfigGenPublicidadId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGGENPUBLICIDADID_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtConfigGenPublicidadTit_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGGENPUBLICIDADTIT_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtConfigGenPublicidadDes_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGGENPUBLICIDADDES_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtConfigGenPublicidadIma_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGGENPUBLICIDADIMA_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtConfigGenPublicidadFecIni_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGGENPUBLICIDADFECINI_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtConfigGenPublicidadFecFin_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGGENPUBLICIDADFECFIN_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbConfigGenPublicidadEsta.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGGENPUBLICIDADESTA_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A350ConfigGenPublicidadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtConfigGenPublicidadId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A359ConfigGenPublicidadTit = cgiGet( edtConfigGenPublicidadTit_Internalname);
         A360ConfigGenPublicidadDes = cgiGet( edtConfigGenPublicidadDes_Internalname);
         A361ConfigGenPublicidadIma = cgiGet( edtConfigGenPublicidadIma_Internalname);
         if ( context.localUtil.VCDateTime( cgiGet( edtConfigGenPublicidadFecIni_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
         {
            GXCCtl = "CONFIGGENPUBLICIDADFECINI_" + sGXsfl_78_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha de Inicio", "")}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtConfigGenPublicidadFecIni_Internalname;
            wbErr = true;
            A362ConfigGenPublicidadFecIni = (DateTime)(DateTime.MinValue);
         }
         else
         {
            A362ConfigGenPublicidadFecIni = context.localUtil.CToT( cgiGet( edtConfigGenPublicidadFecIni_Internalname));
         }
         if ( context.localUtil.VCDateTime( cgiGet( edtConfigGenPublicidadFecFin_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
         {
            GXCCtl = "CONFIGGENPUBLICIDADFECFIN_" + sGXsfl_78_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha Fin", "")}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtConfigGenPublicidadFecFin_Internalname;
            wbErr = true;
            A363ConfigGenPublicidadFecFin = (DateTime)(DateTime.MinValue);
         }
         else
         {
            A363ConfigGenPublicidadFecFin = context.localUtil.CToT( cgiGet( edtConfigGenPublicidadFecFin_Internalname));
         }
         cmbConfigGenPublicidadEsta.Name = cmbConfigGenPublicidadEsta_Internalname;
         cmbConfigGenPublicidadEsta.CurrentValue = cgiGet( cmbConfigGenPublicidadEsta_Internalname);
         A364ConfigGenPublicidadEsta = cgiGet( cmbConfigGenPublicidadEsta_Internalname);
         GXCCtl = "Z350ConfigGenPublicidadId_" + sGXsfl_78_idx;
         Z350ConfigGenPublicidadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z359ConfigGenPublicidadTit_" + sGXsfl_78_idx;
         Z359ConfigGenPublicidadTit = cgiGet( GXCCtl);
         GXCCtl = "Z362ConfigGenPublicidadFecIni_" + sGXsfl_78_idx;
         Z362ConfigGenPublicidadFecIni = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         GXCCtl = "Z363ConfigGenPublicidadFecFin_" + sGXsfl_78_idx;
         Z363ConfigGenPublicidadFecFin = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         GXCCtl = "Z364ConfigGenPublicidadEsta_" + sGXsfl_78_idx;
         Z364ConfigGenPublicidadEsta = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_54_" + sGXsfl_78_idx;
         nRcdDeleted_54 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_54_" + sGXsfl_78_idx;
         nRcdExists_54 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_54_" + sGXsfl_78_idx;
         nIsMod_54 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         getMultimediaValue(edtConfigGenPublicidadIma_Internalname, ref  A361ConfigGenPublicidadIma, ref  A40001ConfigGenPublicidadIma_GXI);
      }

      protected void assign_properties_default( )
      {
         defedtConfigGenPublicidadId_Enabled = edtConfigGenPublicidadId_Enabled;
      }

      protected void ConfirmValues1C0( )
      {
         nGXsfl_78_idx = 0;
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
         SubsflControlProps_7854( ) ;
         while ( nGXsfl_78_idx < nRC_GXsfl_78 )
         {
            nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
            sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
            SubsflControlProps_7854( ) ;
            ChangePostValue( "Z350ConfigGenPublicidadId_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z350ConfigGenPublicidadId_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z350ConfigGenPublicidadId_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z359ConfigGenPublicidadTit_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z359ConfigGenPublicidadTit_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z359ConfigGenPublicidadTit_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z362ConfigGenPublicidadFecIni_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z362ConfigGenPublicidadFecIni_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z362ConfigGenPublicidadFecIni_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z363ConfigGenPublicidadFecFin_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z363ConfigGenPublicidadFecFin_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z363ConfigGenPublicidadFecFin_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z364ConfigGenPublicidadEsta_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z364ConfigGenPublicidadEsta_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z364ConfigGenPublicidadEsta_"+sGXsfl_78_idx) ;
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
         GXEncryptionTmp = "configgen.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ConfigGenID,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configgen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ConfigGen");
         forbiddenHiddens.Add("ConfigGenID", context.localUtil.Format( (decimal)(A349ConfigGenID), "ZZZ9"));
         forbiddenHiddens.Add("ConfigGenFecMod", context.localUtil.Format( A368ConfigGenFecMod, "99/99/99 99:99"));
         forbiddenHiddens.Add("ConfigGenUsuarioMod", StringUtil.RTrim( context.localUtil.Format( A370ConfigGenUsuarioMod, "")));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configgen:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z349ConfigGenID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z349ConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z368ConfigGenFecMod", context.localUtil.TToC( Z368ConfigGenFecMod, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z351ConfigGenEmpNom", StringUtil.RTrim( Z351ConfigGenEmpNom));
         GxWebStd.gx_hidden_field( context, "Z352ConfigGenSiglas", StringUtil.RTrim( Z352ConfigGenSiglas));
         GxWebStd.gx_hidden_field( context, "Z354ConfigGenSiteWeb", StringUtil.RTrim( Z354ConfigGenSiteWeb));
         GxWebStd.gx_hidden_field( context, "Z355ConfigGenCorreo", Z355ConfigGenCorreo);
         GxWebStd.gx_hidden_field( context, "Z356ConfigGenTelefono", StringUtil.RTrim( Z356ConfigGenTelefono));
         GxWebStd.gx_hidden_field( context, "Z357ConfigGenDireccion", Z357ConfigGenDireccion);
         GxWebStd.gx_hidden_field( context, "Z358ConfigGenEstado", StringUtil.RTrim( Z358ConfigGenEstado));
         GxWebStd.gx_hidden_field( context, "Z370ConfigGenUsuarioMod", StringUtil.RTrim( Z370ConfigGenUsuarioMod));
         GxWebStd.gx_hidden_field( context, "Z365ConfigGenSerial", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z365ConfigGenSerial), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O365ConfigGenSerial", StringUtil.LTrim( StringUtil.NToC( (decimal)(O365ConfigGenSerial), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_78", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_78_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vCONFIGGENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONFIGGENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ConfigGenID), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vOK", StringUtil.RTrim( AV11Ok));
         GxWebStd.gx_hidden_field( context, "CONFIGGENLOGO_GXI", A40000ConfigGenLogo_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CONFIGGENPUBLICIDADIMA_GXI", A40001ConfigGenPublicidadIma_GXI);
         GXCCtlgxBlob = "CONFIGGENLOGO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A353ConfigGenLogo);
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
         GXEncryptionTmp = "configgen.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ConfigGenID,4,0));
         return formatLink("configgen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ConfigGen" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Configuración General", "") ;
      }

      protected void InitializeNonKey1C53( )
      {
         A368ConfigGenFecMod = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A368ConfigGenFecMod", context.localUtil.TToC( A368ConfigGenFecMod, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV11Ok = "";
         AssignAttri("", false, "AV11Ok", AV11Ok);
         A351ConfigGenEmpNom = "";
         AssignAttri("", false, "A351ConfigGenEmpNom", A351ConfigGenEmpNom);
         A352ConfigGenSiglas = "";
         AssignAttri("", false, "A352ConfigGenSiglas", A352ConfigGenSiglas);
         A353ConfigGenLogo = "";
         AssignAttri("", false, "A353ConfigGenLogo", A353ConfigGenLogo);
         AssignProp("", false, imgConfigGenLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo)) ? A40000ConfigGenLogo_GXI : context.convertURL( context.PathToRelativeUrl( A353ConfigGenLogo))), true);
         AssignProp("", false, imgConfigGenLogo_Internalname, "SrcSet", context.GetImageSrcSet( A353ConfigGenLogo), true);
         A40000ConfigGenLogo_GXI = "";
         AssignProp("", false, imgConfigGenLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo)) ? A40000ConfigGenLogo_GXI : context.convertURL( context.PathToRelativeUrl( A353ConfigGenLogo))), true);
         AssignProp("", false, imgConfigGenLogo_Internalname, "SrcSet", context.GetImageSrcSet( A353ConfigGenLogo), true);
         A354ConfigGenSiteWeb = "";
         AssignAttri("", false, "A354ConfigGenSiteWeb", A354ConfigGenSiteWeb);
         A355ConfigGenCorreo = "";
         AssignAttri("", false, "A355ConfigGenCorreo", A355ConfigGenCorreo);
         A356ConfigGenTelefono = "";
         AssignAttri("", false, "A356ConfigGenTelefono", A356ConfigGenTelefono);
         A357ConfigGenDireccion = "";
         AssignAttri("", false, "A357ConfigGenDireccion", A357ConfigGenDireccion);
         A358ConfigGenEstado = "";
         AssignAttri("", false, "A358ConfigGenEstado", A358ConfigGenEstado);
         A370ConfigGenUsuarioMod = "";
         AssignAttri("", false, "A370ConfigGenUsuarioMod", A370ConfigGenUsuarioMod);
         A365ConfigGenSerial = 0;
         AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
         O365ConfigGenSerial = A365ConfigGenSerial;
         AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
         Z368ConfigGenFecMod = (DateTime)(DateTime.MinValue);
         Z351ConfigGenEmpNom = "";
         Z352ConfigGenSiglas = "";
         Z354ConfigGenSiteWeb = "";
         Z355ConfigGenCorreo = "";
         Z356ConfigGenTelefono = "";
         Z357ConfigGenDireccion = "";
         Z358ConfigGenEstado = "";
         Z370ConfigGenUsuarioMod = "";
         Z365ConfigGenSerial = 0;
      }

      protected void InitAll1C53( )
      {
         A349ConfigGenID = 0;
         AssignAttri("", false, "A349ConfigGenID", StringUtil.LTrimStr( (decimal)(A349ConfigGenID), 4, 0));
         InitializeNonKey1C53( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A368ConfigGenFecMod = i368ConfigGenFecMod;
         AssignAttri("", false, "A368ConfigGenFecMod", context.localUtil.TToC( A368ConfigGenFecMod, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
      }

      protected void InitializeNonKey1C54( )
      {
         A359ConfigGenPublicidadTit = "";
         A360ConfigGenPublicidadDes = "";
         A361ConfigGenPublicidadIma = "";
         AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma)) ? A40001ConfigGenPublicidadIma_GXI : context.convertURL( context.PathToRelativeUrl( A361ConfigGenPublicidadIma))), !bGXsfl_78_Refreshing);
         AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "SrcSet", context.GetImageSrcSet( A361ConfigGenPublicidadIma), true);
         A40001ConfigGenPublicidadIma_GXI = "";
         AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma)) ? A40001ConfigGenPublicidadIma_GXI : context.convertURL( context.PathToRelativeUrl( A361ConfigGenPublicidadIma))), !bGXsfl_78_Refreshing);
         AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "SrcSet", context.GetImageSrcSet( A361ConfigGenPublicidadIma), true);
         A362ConfigGenPublicidadFecIni = (DateTime)(DateTime.MinValue);
         A363ConfigGenPublicidadFecFin = (DateTime)(DateTime.MinValue);
         A364ConfigGenPublicidadEsta = "";
         Z359ConfigGenPublicidadTit = "";
         Z362ConfigGenPublicidadFecIni = (DateTime)(DateTime.MinValue);
         Z363ConfigGenPublicidadFecFin = (DateTime)(DateTime.MinValue);
         Z364ConfigGenPublicidadEsta = "";
      }

      protected void InitAll1C54( )
      {
         A350ConfigGenPublicidadId = 0;
         InitializeNonKey1C54( ) ;
      }

      protected void StandaloneModalInsert1C54( )
      {
         A365ConfigGenSerial = i365ConfigGenSerial;
         AssignAttri("", false, "A365ConfigGenSerial", StringUtil.LTrimStr( (decimal)(A365ConfigGenSerial), 18, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302111514", true, true, false);
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
         context.AddJavascriptSource("configgen.js", "?20267302111514", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties54( )
      {
         edtConfigGenPublicidadId_Enabled = defedtConfigGenPublicidadId_Enabled;
         AssignProp("", false, edtConfigGenPublicidadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigGenPublicidadId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
      }

      protected void StartGridControl78( )
      {
         Gridlevel_publicidadContainer.AddObjectProperty("GridName", "Gridlevel_publicidad");
         Gridlevel_publicidadContainer.AddObjectProperty("Header", subGridlevel_publicidad_Header);
         Gridlevel_publicidadContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_publicidadContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_publicidadContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_publicidadContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_publicidad_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_publicidadContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_publicidadContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_publicidadColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_publicidadColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A350ConfigGenPublicidadId), 18, 0, ".", ""))));
         Gridlevel_publicidadColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadId_Enabled), 5, 0, ".", "")));
         Gridlevel_publicidadContainer.AddColumnProperties(Gridlevel_publicidadColumn);
         Gridlevel_publicidadColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_publicidadColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A359ConfigGenPublicidadTit)));
         Gridlevel_publicidadColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadTit_Enabled), 5, 0, ".", "")));
         Gridlevel_publicidadContainer.AddColumnProperties(Gridlevel_publicidadColumn);
         Gridlevel_publicidadColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_publicidadColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A360ConfigGenPublicidadDes));
         Gridlevel_publicidadColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadDes_Enabled), 5, 0, ".", "")));
         Gridlevel_publicidadContainer.AddColumnProperties(Gridlevel_publicidadColumn);
         Gridlevel_publicidadColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_publicidadColumn.AddObjectProperty("Value", context.convertURL( A361ConfigGenPublicidadIma));
         Gridlevel_publicidadColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadIma_Enabled), 5, 0, ".", "")));
         Gridlevel_publicidadContainer.AddColumnProperties(Gridlevel_publicidadColumn);
         Gridlevel_publicidadColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_publicidadColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A362ConfigGenPublicidadFecIni, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
         Gridlevel_publicidadColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadFecIni_Enabled), 5, 0, ".", "")));
         Gridlevel_publicidadContainer.AddColumnProperties(Gridlevel_publicidadColumn);
         Gridlevel_publicidadColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_publicidadColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A363ConfigGenPublicidadFecFin, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
         Gridlevel_publicidadColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConfigGenPublicidadFecFin_Enabled), 5, 0, ".", "")));
         Gridlevel_publicidadContainer.AddColumnProperties(Gridlevel_publicidadColumn);
         Gridlevel_publicidadColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_publicidadColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A364ConfigGenPublicidadEsta)));
         Gridlevel_publicidadColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbConfigGenPublicidadEsta.Enabled), 5, 0, ".", "")));
         Gridlevel_publicidadContainer.AddColumnProperties(Gridlevel_publicidadColumn);
         Gridlevel_publicidadContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_publicidad_Selectedindex), 4, 0, ".", "")));
         Gridlevel_publicidadContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_publicidad_Allowselection), 1, 0, ".", "")));
         Gridlevel_publicidadContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_publicidad_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_publicidadContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_publicidad_Allowhovering), 1, 0, ".", "")));
         Gridlevel_publicidadContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_publicidad_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_publicidadContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_publicidad_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_publicidadContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_publicidad_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtConfigGenID_Internalname = "CONFIGGENID";
         edtConfigGenEmpNom_Internalname = "CONFIGGENEMPNOM";
         edtConfigGenSiglas_Internalname = "CONFIGGENSIGLAS";
         imgConfigGenLogo_Internalname = "CONFIGGENLOGO";
         edtConfigGenSiteWeb_Internalname = "CONFIGGENSITEWEB";
         edtConfigGenCorreo_Internalname = "CONFIGGENCORREO";
         edtConfigGenTelefono_Internalname = "CONFIGGENTELEFONO";
         edtConfigGenDireccion_Internalname = "CONFIGGENDIRECCION";
         cmbConfigGenEstado_Internalname = "CONFIGGENESTADO";
         edtConfigGenFecMod_Internalname = "CONFIGGENFECMOD";
         edtConfigGenUsuarioMod_Internalname = "CONFIGGENUSUARIOMOD";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtConfigGenPublicidadId_Internalname = "CONFIGGENPUBLICIDADID";
         edtConfigGenPublicidadTit_Internalname = "CONFIGGENPUBLICIDADTIT";
         edtConfigGenPublicidadDes_Internalname = "CONFIGGENPUBLICIDADDES";
         edtConfigGenPublicidadIma_Internalname = "CONFIGGENPUBLICIDADIMA";
         edtConfigGenPublicidadFecIni_Internalname = "CONFIGGENPUBLICIDADFECINI";
         edtConfigGenPublicidadFecFin_Internalname = "CONFIGGENPUBLICIDADFECFIN";
         cmbConfigGenPublicidadEsta_Internalname = "CONFIGGENPUBLICIDADESTA";
         divTableleaflevel_publicidad_Internalname = "TABLELEAFLEVEL_PUBLICIDAD";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtConfigGenSerial_Internalname = "CONFIGGENSERIAL";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_publicidad_Internalname = "GRIDLEVEL_PUBLICIDAD";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_publicidad_Allowcollapsing = 0;
         subGridlevel_publicidad_Allowselection = 0;
         subGridlevel_publicidad_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Configuración General", "");
         cmbConfigGenPublicidadEsta_Jsonclick = "";
         edtConfigGenPublicidadFecFin_Jsonclick = "";
         edtConfigGenPublicidadFecIni_Jsonclick = "";
         edtConfigGenPublicidadDes_Jsonclick = "";
         edtConfigGenPublicidadTit_Jsonclick = "";
         edtConfigGenPublicidadId_Jsonclick = "";
         subGridlevel_publicidad_Class = "WorkWith";
         subGridlevel_publicidad_Backcolorstyle = 0;
         cmbConfigGenPublicidadEsta.Enabled = 1;
         edtConfigGenPublicidadFecFin_Enabled = 1;
         edtConfigGenPublicidadFecIni_Enabled = 1;
         edtConfigGenPublicidadIma_Enabled = 1;
         edtConfigGenPublicidadDes_Enabled = 1;
         edtConfigGenPublicidadTit_Enabled = 1;
         edtConfigGenPublicidadId_Enabled = 0;
         edtConfigGenSerial_Jsonclick = "";
         edtConfigGenSerial_Enabled = 0;
         edtConfigGenSerial_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtConfigGenUsuarioMod_Jsonclick = "";
         edtConfigGenUsuarioMod_Enabled = 0;
         edtConfigGenFecMod_Jsonclick = "";
         edtConfigGenFecMod_Enabled = 0;
         cmbConfigGenEstado_Jsonclick = "";
         cmbConfigGenEstado.Enabled = 1;
         edtConfigGenDireccion_Enabled = 1;
         edtConfigGenTelefono_Jsonclick = "";
         edtConfigGenTelefono_Enabled = 1;
         edtConfigGenCorreo_Jsonclick = "";
         edtConfigGenCorreo_Enabled = 1;
         edtConfigGenSiteWeb_Jsonclick = "";
         edtConfigGenSiteWeb_Enabled = 1;
         imgConfigGenLogo_Enabled = 1;
         edtConfigGenSiglas_Jsonclick = "";
         edtConfigGenSiglas_Enabled = 1;
         edtConfigGenEmpNom_Jsonclick = "";
         edtConfigGenEmpNom_Enabled = 1;
         edtConfigGenID_Jsonclick = "";
         edtConfigGenID_Enabled = 0;
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

      protected void GX8ASAOK1C53( )
      {
         GXt_char2 = AV11Ok;
         new aactualizaciones(context ).execute(  context.GetMessage( context.GetMessage( "ConfigGen", ""), ""), out  GXt_char2) ;
         AV11Ok = GXt_char2;
         AssignAttri("", false, "AV11Ok", AV11Ok);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( AV11Ok))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_publicidad_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_7854( ) ;
         while ( nGXsfl_78_idx <= nRC_GXsfl_78 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1C54( ) ;
            standaloneModal1C54( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1C54( ) ;
            nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
            sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
            SubsflControlProps_7854( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_publicidadContainer)) ;
         /* End function gxnrGridlevel_publicidad_newrow */
      }

      protected void init_web_controls( )
      {
         cmbConfigGenEstado.Name = "CONFIGGENESTADO";
         cmbConfigGenEstado.WebTags = "";
         cmbConfigGenEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbConfigGenEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbConfigGenEstado.ItemCount > 0 )
         {
            A358ConfigGenEstado = cmbConfigGenEstado.getValidValue(A358ConfigGenEstado);
            AssignAttri("", false, "A358ConfigGenEstado", A358ConfigGenEstado);
         }
         GXCCtl = "CONFIGGENPUBLICIDADESTA_" + sGXsfl_78_idx;
         cmbConfigGenPublicidadEsta.Name = GXCCtl;
         cmbConfigGenPublicidadEsta.WebTags = "";
         cmbConfigGenPublicidadEsta.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbConfigGenPublicidadEsta.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbConfigGenPublicidadEsta.ItemCount > 0 )
         {
            A364ConfigGenPublicidadEsta = cmbConfigGenPublicidadEsta.getValidValue(A364ConfigGenPublicidadEsta);
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7ConfigGenID',fld:'vCONFIGGENID',pic:'ZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ConfigGenID',fld:'vCONFIGGENID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A349ConfigGenID',fld:'CONFIGGENID',pic:'ZZZ9',type:'int'},{av:'A368ConfigGenFecMod',fld:'CONFIGGENFECMOD',pic:'99/99/99 99:99',type:'dtime'},{av:'A370ConfigGenUsuarioMod',fld:'CONFIGGENUSUARIOMOD',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E121C2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CONFIGGENID","{handler:'Valid_Configgenid',iparms:[]");
         setEventMetadata("VALID_CONFIGGENID",",oparms:[]}");
         setEventMetadata("VALID_CONFIGGENCORREO","{handler:'Valid_Configgencorreo',iparms:[]");
         setEventMetadata("VALID_CONFIGGENCORREO",",oparms:[]}");
         setEventMetadata("VALID_CONFIGGENSERIAL","{handler:'Valid_Configgenserial',iparms:[]");
         setEventMetadata("VALID_CONFIGGENSERIAL",",oparms:[]}");
         setEventMetadata("VALID_CONFIGGENPUBLICIDADID","{handler:'Valid_Configgenpublicidadid',iparms:[]");
         setEventMetadata("VALID_CONFIGGENPUBLICIDADID",",oparms:[]}");
         setEventMetadata("VALID_CONFIGGENPUBLICIDADFECINI","{handler:'Valid_Configgenpublicidadfecini',iparms:[]");
         setEventMetadata("VALID_CONFIGGENPUBLICIDADFECINI",",oparms:[]}");
         setEventMetadata("VALID_CONFIGGENPUBLICIDADFECFIN","{handler:'Valid_Configgenpublicidadfecfin',iparms:[]");
         setEventMetadata("VALID_CONFIGGENPUBLICIDADFECFIN",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Configgenpublicidadesta',iparms:[]");
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
         Z368ConfigGenFecMod = (DateTime)(DateTime.MinValue);
         Z351ConfigGenEmpNom = "";
         Z352ConfigGenSiglas = "";
         Z354ConfigGenSiteWeb = "";
         Z355ConfigGenCorreo = "";
         Z356ConfigGenTelefono = "";
         Z357ConfigGenDireccion = "";
         Z358ConfigGenEstado = "";
         Z370ConfigGenUsuarioMod = "";
         Z359ConfigGenPublicidadTit = "";
         Z362ConfigGenPublicidadFecIni = (DateTime)(DateTime.MinValue);
         Z363ConfigGenPublicidadFecFin = (DateTime)(DateTime.MinValue);
         Z364ConfigGenPublicidadEsta = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A358ConfigGenEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A351ConfigGenEmpNom = "";
         A352ConfigGenSiglas = "";
         A353ConfigGenLogo = "";
         A40000ConfigGenLogo_GXI = "";
         sImgUrl = "";
         A354ConfigGenSiteWeb = "";
         A355ConfigGenCorreo = "";
         gxphoneLink = "";
         A356ConfigGenTelefono = "";
         A357ConfigGenDireccion = "";
         A368ConfigGenFecMod = (DateTime)(DateTime.MinValue);
         A370ConfigGenUsuarioMod = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_publicidadContainer = new GXWebGrid( context);
         sMode54 = "";
         sStyleString = "";
         AV11Ok = "";
         AV15Pgmname = "";
         A40001ConfigGenPublicidadIma_GXI = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode53 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A359ConfigGenPublicidadTit = "";
         A360ConfigGenPublicidadDes = "";
         A361ConfigGenPublicidadIma = "";
         A362ConfigGenPublicidadFecIni = (DateTime)(DateTime.MinValue);
         A363ConfigGenPublicidadFecFin = (DateTime)(DateTime.MinValue);
         A364ConfigGenPublicidadEsta = "";
         AV12WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z353ConfigGenLogo = "";
         Z40000ConfigGenLogo_GXI = "";
         T001C6_A349ConfigGenID = new short[1] ;
         T001C6_A368ConfigGenFecMod = new DateTime[] {DateTime.MinValue} ;
         T001C6_A351ConfigGenEmpNom = new string[] {""} ;
         T001C6_A352ConfigGenSiglas = new string[] {""} ;
         T001C6_A40000ConfigGenLogo_GXI = new string[] {""} ;
         T001C6_A354ConfigGenSiteWeb = new string[] {""} ;
         T001C6_A355ConfigGenCorreo = new string[] {""} ;
         T001C6_A356ConfigGenTelefono = new string[] {""} ;
         T001C6_A357ConfigGenDireccion = new string[] {""} ;
         T001C6_A358ConfigGenEstado = new string[] {""} ;
         T001C6_A370ConfigGenUsuarioMod = new string[] {""} ;
         T001C6_A365ConfigGenSerial = new long[1] ;
         T001C6_A353ConfigGenLogo = new string[] {""} ;
         T001C7_A349ConfigGenID = new short[1] ;
         T001C5_A349ConfigGenID = new short[1] ;
         T001C5_A368ConfigGenFecMod = new DateTime[] {DateTime.MinValue} ;
         T001C5_A351ConfigGenEmpNom = new string[] {""} ;
         T001C5_A352ConfigGenSiglas = new string[] {""} ;
         T001C5_A40000ConfigGenLogo_GXI = new string[] {""} ;
         T001C5_A354ConfigGenSiteWeb = new string[] {""} ;
         T001C5_A355ConfigGenCorreo = new string[] {""} ;
         T001C5_A356ConfigGenTelefono = new string[] {""} ;
         T001C5_A357ConfigGenDireccion = new string[] {""} ;
         T001C5_A358ConfigGenEstado = new string[] {""} ;
         T001C5_A370ConfigGenUsuarioMod = new string[] {""} ;
         T001C5_A365ConfigGenSerial = new long[1] ;
         T001C5_A353ConfigGenLogo = new string[] {""} ;
         T001C8_A349ConfigGenID = new short[1] ;
         T001C9_A349ConfigGenID = new short[1] ;
         T001C4_A349ConfigGenID = new short[1] ;
         T001C4_A368ConfigGenFecMod = new DateTime[] {DateTime.MinValue} ;
         T001C4_A351ConfigGenEmpNom = new string[] {""} ;
         T001C4_A352ConfigGenSiglas = new string[] {""} ;
         T001C4_A40000ConfigGenLogo_GXI = new string[] {""} ;
         T001C4_A354ConfigGenSiteWeb = new string[] {""} ;
         T001C4_A355ConfigGenCorreo = new string[] {""} ;
         T001C4_A356ConfigGenTelefono = new string[] {""} ;
         T001C4_A357ConfigGenDireccion = new string[] {""} ;
         T001C4_A358ConfigGenEstado = new string[] {""} ;
         T001C4_A370ConfigGenUsuarioMod = new string[] {""} ;
         T001C4_A365ConfigGenSerial = new long[1] ;
         T001C4_A353ConfigGenLogo = new string[] {""} ;
         T001C10_A349ConfigGenID = new short[1] ;
         T001C14_A371ResumenID = new long[1] ;
         T001C16_A349ConfigGenID = new short[1] ;
         Z360ConfigGenPublicidadDes = "";
         Z361ConfigGenPublicidadIma = "";
         Z40001ConfigGenPublicidadIma_GXI = "";
         T001C17_A349ConfigGenID = new short[1] ;
         T001C17_A350ConfigGenPublicidadId = new long[1] ;
         T001C17_A359ConfigGenPublicidadTit = new string[] {""} ;
         T001C17_A360ConfigGenPublicidadDes = new string[] {""} ;
         T001C17_A40001ConfigGenPublicidadIma_GXI = new string[] {""} ;
         T001C17_A362ConfigGenPublicidadFecIni = new DateTime[] {DateTime.MinValue} ;
         T001C17_A363ConfigGenPublicidadFecFin = new DateTime[] {DateTime.MinValue} ;
         T001C17_A364ConfigGenPublicidadEsta = new string[] {""} ;
         T001C17_A361ConfigGenPublicidadIma = new string[] {""} ;
         GXCCtl = "";
         T001C18_A349ConfigGenID = new short[1] ;
         T001C18_A350ConfigGenPublicidadId = new long[1] ;
         T001C3_A349ConfigGenID = new short[1] ;
         T001C3_A350ConfigGenPublicidadId = new long[1] ;
         T001C3_A359ConfigGenPublicidadTit = new string[] {""} ;
         T001C3_A360ConfigGenPublicidadDes = new string[] {""} ;
         T001C3_A40001ConfigGenPublicidadIma_GXI = new string[] {""} ;
         T001C3_A362ConfigGenPublicidadFecIni = new DateTime[] {DateTime.MinValue} ;
         T001C3_A363ConfigGenPublicidadFecFin = new DateTime[] {DateTime.MinValue} ;
         T001C3_A364ConfigGenPublicidadEsta = new string[] {""} ;
         T001C3_A361ConfigGenPublicidadIma = new string[] {""} ;
         T001C2_A349ConfigGenID = new short[1] ;
         T001C2_A350ConfigGenPublicidadId = new long[1] ;
         T001C2_A359ConfigGenPublicidadTit = new string[] {""} ;
         T001C2_A360ConfigGenPublicidadDes = new string[] {""} ;
         T001C2_A40001ConfigGenPublicidadIma_GXI = new string[] {""} ;
         T001C2_A362ConfigGenPublicidadFecIni = new DateTime[] {DateTime.MinValue} ;
         T001C2_A363ConfigGenPublicidadFecFin = new DateTime[] {DateTime.MinValue} ;
         T001C2_A364ConfigGenPublicidadEsta = new string[] {""} ;
         T001C2_A361ConfigGenPublicidadIma = new string[] {""} ;
         T001C23_A349ConfigGenID = new short[1] ;
         T001C23_A350ConfigGenPublicidadId = new long[1] ;
         Gridlevel_publicidadRow = new GXWebRow();
         subGridlevel_publicidad_Linesclass = "";
         ROClassString = "";
         GXCCtlgxBlob = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i368ConfigGenFecMod = (DateTime)(DateTime.MinValue);
         Gridlevel_publicidadColumn = new GXWebColumn();
         GXt_char2 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.configgen__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configgen__default(),
            new Object[][] {
                new Object[] {
               T001C2_A349ConfigGenID, T001C2_A350ConfigGenPublicidadId, T001C2_A359ConfigGenPublicidadTit, T001C2_A360ConfigGenPublicidadDes, T001C2_A40001ConfigGenPublicidadIma_GXI, T001C2_A362ConfigGenPublicidadFecIni, T001C2_A363ConfigGenPublicidadFecFin, T001C2_A364ConfigGenPublicidadEsta, T001C2_A361ConfigGenPublicidadIma
               }
               , new Object[] {
               T001C3_A349ConfigGenID, T001C3_A350ConfigGenPublicidadId, T001C3_A359ConfigGenPublicidadTit, T001C3_A360ConfigGenPublicidadDes, T001C3_A40001ConfigGenPublicidadIma_GXI, T001C3_A362ConfigGenPublicidadFecIni, T001C3_A363ConfigGenPublicidadFecFin, T001C3_A364ConfigGenPublicidadEsta, T001C3_A361ConfigGenPublicidadIma
               }
               , new Object[] {
               T001C4_A349ConfigGenID, T001C4_A368ConfigGenFecMod, T001C4_A351ConfigGenEmpNom, T001C4_A352ConfigGenSiglas, T001C4_A40000ConfigGenLogo_GXI, T001C4_A354ConfigGenSiteWeb, T001C4_A355ConfigGenCorreo, T001C4_A356ConfigGenTelefono, T001C4_A357ConfigGenDireccion, T001C4_A358ConfigGenEstado,
               T001C4_A370ConfigGenUsuarioMod, T001C4_A365ConfigGenSerial, T001C4_A353ConfigGenLogo
               }
               , new Object[] {
               T001C5_A349ConfigGenID, T001C5_A368ConfigGenFecMod, T001C5_A351ConfigGenEmpNom, T001C5_A352ConfigGenSiglas, T001C5_A40000ConfigGenLogo_GXI, T001C5_A354ConfigGenSiteWeb, T001C5_A355ConfigGenCorreo, T001C5_A356ConfigGenTelefono, T001C5_A357ConfigGenDireccion, T001C5_A358ConfigGenEstado,
               T001C5_A370ConfigGenUsuarioMod, T001C5_A365ConfigGenSerial, T001C5_A353ConfigGenLogo
               }
               , new Object[] {
               T001C6_A349ConfigGenID, T001C6_A368ConfigGenFecMod, T001C6_A351ConfigGenEmpNom, T001C6_A352ConfigGenSiglas, T001C6_A40000ConfigGenLogo_GXI, T001C6_A354ConfigGenSiteWeb, T001C6_A355ConfigGenCorreo, T001C6_A356ConfigGenTelefono, T001C6_A357ConfigGenDireccion, T001C6_A358ConfigGenEstado,
               T001C6_A370ConfigGenUsuarioMod, T001C6_A365ConfigGenSerial, T001C6_A353ConfigGenLogo
               }
               , new Object[] {
               T001C7_A349ConfigGenID
               }
               , new Object[] {
               T001C8_A349ConfigGenID
               }
               , new Object[] {
               T001C9_A349ConfigGenID
               }
               , new Object[] {
               T001C10_A349ConfigGenID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001C14_A371ResumenID
               }
               , new Object[] {
               }
               , new Object[] {
               T001C16_A349ConfigGenID
               }
               , new Object[] {
               T001C17_A349ConfigGenID, T001C17_A350ConfigGenPublicidadId, T001C17_A359ConfigGenPublicidadTit, T001C17_A360ConfigGenPublicidadDes, T001C17_A40001ConfigGenPublicidadIma_GXI, T001C17_A362ConfigGenPublicidadFecIni, T001C17_A363ConfigGenPublicidadFecFin, T001C17_A364ConfigGenPublicidadEsta, T001C17_A361ConfigGenPublicidadIma
               }
               , new Object[] {
               T001C18_A349ConfigGenID, T001C18_A350ConfigGenPublicidadId
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
               T001C23_A349ConfigGenID, T001C23_A350ConfigGenPublicidadId
               }
            }
         );
         AV15Pgmname = "ConfigGen";
      }

      private short wcpOAV7ConfigGenID ;
      private short Z349ConfigGenID ;
      private short nRcdDeleted_54 ;
      private short nRcdExists_54 ;
      private short nIsMod_54 ;
      private short GxWebError ;
      private short AV7ConfigGenID ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short A349ConfigGenID ;
      private short nBlankRcdCount54 ;
      private short RcdFound54 ;
      private short nBlankRcdUsr54 ;
      private short RcdFound53 ;
      private short nIsDirty_54 ;
      private short subGridlevel_publicidad_Backcolorstyle ;
      private short subGridlevel_publicidad_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_publicidad_Allowselection ;
      private short subGridlevel_publicidad_Allowhovering ;
      private short subGridlevel_publicidad_Allowcollapsing ;
      private short subGridlevel_publicidad_Collapsed ;
      private int nRC_GXsfl_78 ;
      private int nGXsfl_78_idx=1 ;
      private int trnEnded ;
      private int edtConfigGenID_Enabled ;
      private int edtConfigGenEmpNom_Enabled ;
      private int edtConfigGenSiglas_Enabled ;
      private int imgConfigGenLogo_Enabled ;
      private int edtConfigGenSiteWeb_Enabled ;
      private int edtConfigGenCorreo_Enabled ;
      private int edtConfigGenTelefono_Enabled ;
      private int edtConfigGenDireccion_Enabled ;
      private int edtConfigGenFecMod_Enabled ;
      private int edtConfigGenUsuarioMod_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtConfigGenSerial_Enabled ;
      private int edtConfigGenSerial_Visible ;
      private int edtConfigGenPublicidadId_Enabled ;
      private int edtConfigGenPublicidadTit_Enabled ;
      private int edtConfigGenPublicidadDes_Enabled ;
      private int edtConfigGenPublicidadIma_Enabled ;
      private int edtConfigGenPublicidadFecIni_Enabled ;
      private int edtConfigGenPublicidadFecFin_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int subGridlevel_publicidad_Backcolor ;
      private int subGridlevel_publicidad_Allbackcolor ;
      private int defedtConfigGenPublicidadId_Enabled ;
      private int idxLst ;
      private int subGridlevel_publicidad_Selectedindex ;
      private int subGridlevel_publicidad_Selectioncolor ;
      private int subGridlevel_publicidad_Hoveringcolor ;
      private long Z365ConfigGenSerial ;
      private long O365ConfigGenSerial ;
      private long Z350ConfigGenPublicidadId ;
      private long A365ConfigGenSerial ;
      private long B365ConfigGenSerial ;
      private long GRIDLEVEL_PUBLICIDAD_nFirstRecordOnPage ;
      private long s365ConfigGenSerial ;
      private long A350ConfigGenPublicidadId ;
      private long i365ConfigGenSerial ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z351ConfigGenEmpNom ;
      private string Z352ConfigGenSiglas ;
      private string Z354ConfigGenSiteWeb ;
      private string Z356ConfigGenTelefono ;
      private string Z358ConfigGenEstado ;
      private string Z370ConfigGenUsuarioMod ;
      private string Z359ConfigGenPublicidadTit ;
      private string Z364ConfigGenPublicidadEsta ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtConfigGenEmpNom_Internalname ;
      private string sGXsfl_78_idx="0001" ;
      private string A358ConfigGenEstado ;
      private string cmbConfigGenEstado_Internalname ;
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
      private string edtConfigGenID_Internalname ;
      private string TempTags ;
      private string edtConfigGenID_Jsonclick ;
      private string A351ConfigGenEmpNom ;
      private string edtConfigGenEmpNom_Jsonclick ;
      private string edtConfigGenSiglas_Internalname ;
      private string A352ConfigGenSiglas ;
      private string edtConfigGenSiglas_Jsonclick ;
      private string imgConfigGenLogo_Internalname ;
      private string sImgUrl ;
      private string edtConfigGenSiteWeb_Internalname ;
      private string A354ConfigGenSiteWeb ;
      private string edtConfigGenSiteWeb_Jsonclick ;
      private string edtConfigGenCorreo_Internalname ;
      private string edtConfigGenCorreo_Jsonclick ;
      private string edtConfigGenTelefono_Internalname ;
      private string gxphoneLink ;
      private string A356ConfigGenTelefono ;
      private string edtConfigGenTelefono_Jsonclick ;
      private string edtConfigGenDireccion_Internalname ;
      private string cmbConfigGenEstado_Jsonclick ;
      private string edtConfigGenFecMod_Internalname ;
      private string edtConfigGenFecMod_Jsonclick ;
      private string edtConfigGenUsuarioMod_Internalname ;
      private string A370ConfigGenUsuarioMod ;
      private string edtConfigGenUsuarioMod_Jsonclick ;
      private string divTableleaflevel_publicidad_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtConfigGenSerial_Internalname ;
      private string edtConfigGenSerial_Jsonclick ;
      private string sMode54 ;
      private string edtConfigGenPublicidadId_Internalname ;
      private string edtConfigGenPublicidadTit_Internalname ;
      private string edtConfigGenPublicidadDes_Internalname ;
      private string edtConfigGenPublicidadIma_Internalname ;
      private string edtConfigGenPublicidadFecIni_Internalname ;
      private string edtConfigGenPublicidadFecFin_Internalname ;
      private string cmbConfigGenPublicidadEsta_Internalname ;
      private string sStyleString ;
      private string subGridlevel_publicidad_Internalname ;
      private string AV11Ok ;
      private string AV15Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode53 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A359ConfigGenPublicidadTit ;
      private string A364ConfigGenPublicidadEsta ;
      private string GXEncryptionTmp ;
      private string GXCCtl ;
      private string sGXsfl_78_fel_idx="0001" ;
      private string subGridlevel_publicidad_Class ;
      private string subGridlevel_publicidad_Linesclass ;
      private string ROClassString ;
      private string edtConfigGenPublicidadId_Jsonclick ;
      private string edtConfigGenPublicidadTit_Jsonclick ;
      private string edtConfigGenPublicidadDes_Jsonclick ;
      private string edtConfigGenPublicidadFecIni_Jsonclick ;
      private string edtConfigGenPublicidadFecFin_Jsonclick ;
      private string cmbConfigGenPublicidadEsta_Jsonclick ;
      private string GXCCtlgxBlob ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_publicidad_Header ;
      private string GXt_char2 ;
      private DateTime Z368ConfigGenFecMod ;
      private DateTime Z362ConfigGenPublicidadFecIni ;
      private DateTime Z363ConfigGenPublicidadFecFin ;
      private DateTime A368ConfigGenFecMod ;
      private DateTime A362ConfigGenPublicidadFecIni ;
      private DateTime A363ConfigGenPublicidadFecFin ;
      private DateTime i368ConfigGenFecMod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A353ConfigGenLogo_IsBlob ;
      private bool bGXsfl_78_Refreshing=false ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private bool A361ConfigGenPublicidadIma_IsBlob ;
      private string A360ConfigGenPublicidadDes ;
      private string Z360ConfigGenPublicidadDes ;
      private string Z355ConfigGenCorreo ;
      private string Z357ConfigGenDireccion ;
      private string A40000ConfigGenLogo_GXI ;
      private string A355ConfigGenCorreo ;
      private string A357ConfigGenDireccion ;
      private string A40001ConfigGenPublicidadIma_GXI ;
      private string Z40000ConfigGenLogo_GXI ;
      private string Z40001ConfigGenPublicidadIma_GXI ;
      private string A353ConfigGenLogo ;
      private string A361ConfigGenPublicidadIma ;
      private string Z353ConfigGenLogo ;
      private string Z361ConfigGenPublicidadIma ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_publicidadContainer ;
      private GXWebRow Gridlevel_publicidadRow ;
      private GXWebColumn Gridlevel_publicidadColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbConfigGenEstado ;
      private GXCombobox cmbConfigGenPublicidadEsta ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV12WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T001C6_A349ConfigGenID ;
      private DateTime[] T001C6_A368ConfigGenFecMod ;
      private string[] T001C6_A351ConfigGenEmpNom ;
      private string[] T001C6_A352ConfigGenSiglas ;
      private string[] T001C6_A40000ConfigGenLogo_GXI ;
      private string[] T001C6_A354ConfigGenSiteWeb ;
      private string[] T001C6_A355ConfigGenCorreo ;
      private string[] T001C6_A356ConfigGenTelefono ;
      private string[] T001C6_A357ConfigGenDireccion ;
      private string[] T001C6_A358ConfigGenEstado ;
      private string[] T001C6_A370ConfigGenUsuarioMod ;
      private long[] T001C6_A365ConfigGenSerial ;
      private string[] T001C6_A353ConfigGenLogo ;
      private short[] T001C7_A349ConfigGenID ;
      private short[] T001C5_A349ConfigGenID ;
      private DateTime[] T001C5_A368ConfigGenFecMod ;
      private string[] T001C5_A351ConfigGenEmpNom ;
      private string[] T001C5_A352ConfigGenSiglas ;
      private string[] T001C5_A40000ConfigGenLogo_GXI ;
      private string[] T001C5_A354ConfigGenSiteWeb ;
      private string[] T001C5_A355ConfigGenCorreo ;
      private string[] T001C5_A356ConfigGenTelefono ;
      private string[] T001C5_A357ConfigGenDireccion ;
      private string[] T001C5_A358ConfigGenEstado ;
      private string[] T001C5_A370ConfigGenUsuarioMod ;
      private long[] T001C5_A365ConfigGenSerial ;
      private string[] T001C5_A353ConfigGenLogo ;
      private short[] T001C8_A349ConfigGenID ;
      private short[] T001C9_A349ConfigGenID ;
      private short[] T001C4_A349ConfigGenID ;
      private DateTime[] T001C4_A368ConfigGenFecMod ;
      private string[] T001C4_A351ConfigGenEmpNom ;
      private string[] T001C4_A352ConfigGenSiglas ;
      private string[] T001C4_A40000ConfigGenLogo_GXI ;
      private string[] T001C4_A354ConfigGenSiteWeb ;
      private string[] T001C4_A355ConfigGenCorreo ;
      private string[] T001C4_A356ConfigGenTelefono ;
      private string[] T001C4_A357ConfigGenDireccion ;
      private string[] T001C4_A358ConfigGenEstado ;
      private string[] T001C4_A370ConfigGenUsuarioMod ;
      private long[] T001C4_A365ConfigGenSerial ;
      private string[] T001C4_A353ConfigGenLogo ;
      private short[] T001C10_A349ConfigGenID ;
      private long[] T001C14_A371ResumenID ;
      private short[] T001C16_A349ConfigGenID ;
      private short[] T001C17_A349ConfigGenID ;
      private long[] T001C17_A350ConfigGenPublicidadId ;
      private string[] T001C17_A359ConfigGenPublicidadTit ;
      private string[] T001C17_A360ConfigGenPublicidadDes ;
      private string[] T001C17_A40001ConfigGenPublicidadIma_GXI ;
      private DateTime[] T001C17_A362ConfigGenPublicidadFecIni ;
      private DateTime[] T001C17_A363ConfigGenPublicidadFecFin ;
      private string[] T001C17_A364ConfigGenPublicidadEsta ;
      private string[] T001C17_A361ConfigGenPublicidadIma ;
      private short[] T001C18_A349ConfigGenID ;
      private long[] T001C18_A350ConfigGenPublicidadId ;
      private short[] T001C3_A349ConfigGenID ;
      private long[] T001C3_A350ConfigGenPublicidadId ;
      private string[] T001C3_A359ConfigGenPublicidadTit ;
      private string[] T001C3_A360ConfigGenPublicidadDes ;
      private string[] T001C3_A40001ConfigGenPublicidadIma_GXI ;
      private DateTime[] T001C3_A362ConfigGenPublicidadFecIni ;
      private DateTime[] T001C3_A363ConfigGenPublicidadFecFin ;
      private string[] T001C3_A364ConfigGenPublicidadEsta ;
      private string[] T001C3_A361ConfigGenPublicidadIma ;
      private short[] T001C2_A349ConfigGenID ;
      private long[] T001C2_A350ConfigGenPublicidadId ;
      private string[] T001C2_A359ConfigGenPublicidadTit ;
      private string[] T001C2_A360ConfigGenPublicidadDes ;
      private string[] T001C2_A40001ConfigGenPublicidadIma_GXI ;
      private DateTime[] T001C2_A362ConfigGenPublicidadFecIni ;
      private DateTime[] T001C2_A363ConfigGenPublicidadFecFin ;
      private string[] T001C2_A364ConfigGenPublicidadEsta ;
      private string[] T001C2_A361ConfigGenPublicidadIma ;
      private short[] T001C23_A349ConfigGenID ;
      private long[] T001C23_A350ConfigGenPublicidadId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class configgen__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class configgen__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001C2;
        prmT001C2 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0) ,
        new ParDef("@ConfigGenPublicidadId",GXType.Decimal,18,0)
        };
        Object[] prmT001C3;
        prmT001C3 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0) ,
        new ParDef("@ConfigGenPublicidadId",GXType.Decimal,18,0)
        };
        Object[] prmT001C4;
        prmT001C4 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        Object[] prmT001C5;
        prmT001C5 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        Object[] prmT001C6;
        prmT001C6 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        Object[] prmT001C7;
        prmT001C7 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        Object[] prmT001C8;
        prmT001C8 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        Object[] prmT001C9;
        prmT001C9 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        Object[] prmT001C10;
        prmT001C10 = new Object[] {
        new ParDef("@ConfigGenFecMod",GXType.DateTime,8,5) ,
        new ParDef("@ConfigGenEmpNom",GXType.NChar,100,0) ,
        new ParDef("@ConfigGenSiglas",GXType.NChar,20,0) ,
        new ParDef("@ConfigGenLogo",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ConfigGenLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="ConfigGen", Fld="ConfigGenLogo"} ,
        new ParDef("@ConfigGenSiteWeb",GXType.NChar,80,0) ,
        new ParDef("@ConfigGenCorreo",GXType.NVarChar,100,0) ,
        new ParDef("@ConfigGenTelefono",GXType.NChar,20,0) ,
        new ParDef("@ConfigGenDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@ConfigGenEstado",GXType.NChar,3,0) ,
        new ParDef("@ConfigGenUsuarioMod",GXType.NChar,30,0) ,
        new ParDef("@ConfigGenSerial",GXType.Decimal,18,0)
        };
        Object[] prmT001C11;
        prmT001C11 = new Object[] {
        new ParDef("@ConfigGenFecMod",GXType.DateTime,8,5) ,
        new ParDef("@ConfigGenEmpNom",GXType.NChar,100,0) ,
        new ParDef("@ConfigGenSiglas",GXType.NChar,20,0) ,
        new ParDef("@ConfigGenSiteWeb",GXType.NChar,80,0) ,
        new ParDef("@ConfigGenCorreo",GXType.NVarChar,100,0) ,
        new ParDef("@ConfigGenTelefono",GXType.NChar,20,0) ,
        new ParDef("@ConfigGenDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@ConfigGenEstado",GXType.NChar,3,0) ,
        new ParDef("@ConfigGenUsuarioMod",GXType.NChar,30,0) ,
        new ParDef("@ConfigGenSerial",GXType.Decimal,18,0) ,
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        Object[] prmT001C12;
        prmT001C12 = new Object[] {
        new ParDef("@ConfigGenLogo",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ConfigGenLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="ConfigGen", Fld="ConfigGenLogo"} ,
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        Object[] prmT001C13;
        prmT001C13 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        Object[] prmT001C14;
        prmT001C14 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        Object[] prmT001C15;
        prmT001C15 = new Object[] {
        new ParDef("@ConfigGenSerial",GXType.Decimal,18,0) ,
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        Object[] prmT001C16;
        prmT001C16 = new Object[] {
        };
        Object[] prmT001C17;
        prmT001C17 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0) ,
        new ParDef("@ConfigGenPublicidadId",GXType.Decimal,18,0)
        };
        Object[] prmT001C18;
        prmT001C18 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0) ,
        new ParDef("@ConfigGenPublicidadId",GXType.Decimal,18,0)
        };
        Object[] prmT001C19;
        prmT001C19 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0) ,
        new ParDef("@ConfigGenPublicidadId",GXType.Decimal,18,0) ,
        new ParDef("@ConfigGenPublicidadTit",GXType.NChar,80,0) ,
        new ParDef("@ConfigGenPublicidadDes",GXType.NVarChar,2097152,0) ,
        new ParDef("@ConfigGenPublicidadIma",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ConfigGenPublicidadIma_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="ConfigGenPublicidad", Fld="ConfigGenPublicidadIma"} ,
        new ParDef("@ConfigGenPublicidadFecIni",GXType.DateTime,8,5) ,
        new ParDef("@ConfigGenPublicidadFecFin",GXType.DateTime,8,5) ,
        new ParDef("@ConfigGenPublicidadEsta",GXType.NChar,3,0)
        };
        Object[] prmT001C20;
        prmT001C20 = new Object[] {
        new ParDef("@ConfigGenPublicidadTit",GXType.NChar,80,0) ,
        new ParDef("@ConfigGenPublicidadDes",GXType.NVarChar,2097152,0) ,
        new ParDef("@ConfigGenPublicidadFecIni",GXType.DateTime,8,5) ,
        new ParDef("@ConfigGenPublicidadFecFin",GXType.DateTime,8,5) ,
        new ParDef("@ConfigGenPublicidadEsta",GXType.NChar,3,0) ,
        new ParDef("@ConfigGenID",GXType.Int16,4,0) ,
        new ParDef("@ConfigGenPublicidadId",GXType.Decimal,18,0)
        };
        Object[] prmT001C21;
        prmT001C21 = new Object[] {
        new ParDef("@ConfigGenPublicidadIma",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ConfigGenPublicidadIma_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="ConfigGenPublicidad", Fld="ConfigGenPublicidadIma"} ,
        new ParDef("@ConfigGenID",GXType.Int16,4,0) ,
        new ParDef("@ConfigGenPublicidadId",GXType.Decimal,18,0)
        };
        Object[] prmT001C22;
        prmT001C22 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0) ,
        new ParDef("@ConfigGenPublicidadId",GXType.Decimal,18,0)
        };
        Object[] prmT001C23;
        prmT001C23 = new Object[] {
        new ParDef("@ConfigGenID",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001C2", "SELECT [ConfigGenID], [ConfigGenPublicidadId], [ConfigGenPublicidadTit], [ConfigGenPublicidadDes], [ConfigGenPublicidadIma_GXI], [ConfigGenPublicidadFecIni], [ConfigGenPublicidadFecFin], [ConfigGenPublicidadEsta], [ConfigGenPublicidadIma] FROM [ConfigGenPublicidad] WITH (UPDLOCK) WHERE [ConfigGenID] = @ConfigGenID AND [ConfigGenPublicidadId] = @ConfigGenPublicidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C3", "SELECT [ConfigGenID], [ConfigGenPublicidadId], [ConfigGenPublicidadTit], [ConfigGenPublicidadDes], [ConfigGenPublicidadIma_GXI], [ConfigGenPublicidadFecIni], [ConfigGenPublicidadFecFin], [ConfigGenPublicidadEsta], [ConfigGenPublicidadIma] FROM [ConfigGenPublicidad] WHERE [ConfigGenID] = @ConfigGenID AND [ConfigGenPublicidadId] = @ConfigGenPublicidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C4", "SELECT [ConfigGenID], [ConfigGenFecMod], [ConfigGenEmpNom], [ConfigGenSiglas], [ConfigGenLogo_GXI], [ConfigGenSiteWeb], [ConfigGenCorreo], [ConfigGenTelefono], [ConfigGenDireccion], [ConfigGenEstado], [ConfigGenUsuarioMod], [ConfigGenSerial], [ConfigGenLogo] FROM [ConfigGen] WITH (UPDLOCK) WHERE [ConfigGenID] = @ConfigGenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C5", "SELECT [ConfigGenID], [ConfigGenFecMod], [ConfigGenEmpNom], [ConfigGenSiglas], [ConfigGenLogo_GXI], [ConfigGenSiteWeb], [ConfigGenCorreo], [ConfigGenTelefono], [ConfigGenDireccion], [ConfigGenEstado], [ConfigGenUsuarioMod], [ConfigGenSerial], [ConfigGenLogo] FROM [ConfigGen] WHERE [ConfigGenID] = @ConfigGenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C6", "SELECT TM1.[ConfigGenID], TM1.[ConfigGenFecMod], TM1.[ConfigGenEmpNom], TM1.[ConfigGenSiglas], TM1.[ConfigGenLogo_GXI], TM1.[ConfigGenSiteWeb], TM1.[ConfigGenCorreo], TM1.[ConfigGenTelefono], TM1.[ConfigGenDireccion], TM1.[ConfigGenEstado], TM1.[ConfigGenUsuarioMod], TM1.[ConfigGenSerial], TM1.[ConfigGenLogo] FROM [ConfigGen] TM1 WHERE TM1.[ConfigGenID] = @ConfigGenID ORDER BY TM1.[ConfigGenID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001C6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C7", "SELECT [ConfigGenID] FROM [ConfigGen] WHERE [ConfigGenID] = @ConfigGenID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001C7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C8", "SELECT TOP 1 [ConfigGenID] FROM [ConfigGen] WHERE ( [ConfigGenID] > @ConfigGenID) ORDER BY [ConfigGenID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001C8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C9", "SELECT TOP 1 [ConfigGenID] FROM [ConfigGen] WHERE ( [ConfigGenID] < @ConfigGenID) ORDER BY [ConfigGenID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001C9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C10", "INSERT INTO [ConfigGen]([ConfigGenFecMod], [ConfigGenEmpNom], [ConfigGenSiglas], [ConfigGenLogo], [ConfigGenLogo_GXI], [ConfigGenSiteWeb], [ConfigGenCorreo], [ConfigGenTelefono], [ConfigGenDireccion], [ConfigGenEstado], [ConfigGenUsuarioMod], [ConfigGenSerial]) VALUES(@ConfigGenFecMod, @ConfigGenEmpNom, @ConfigGenSiglas, @ConfigGenLogo, @ConfigGenLogo_GXI, @ConfigGenSiteWeb, @ConfigGenCorreo, @ConfigGenTelefono, @ConfigGenDireccion, @ConfigGenEstado, @ConfigGenUsuarioMod, @ConfigGenSerial); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001C10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C11", "UPDATE [ConfigGen] SET [ConfigGenFecMod]=@ConfigGenFecMod, [ConfigGenEmpNom]=@ConfigGenEmpNom, [ConfigGenSiglas]=@ConfigGenSiglas, [ConfigGenSiteWeb]=@ConfigGenSiteWeb, [ConfigGenCorreo]=@ConfigGenCorreo, [ConfigGenTelefono]=@ConfigGenTelefono, [ConfigGenDireccion]=@ConfigGenDireccion, [ConfigGenEstado]=@ConfigGenEstado, [ConfigGenUsuarioMod]=@ConfigGenUsuarioMod, [ConfigGenSerial]=@ConfigGenSerial  WHERE [ConfigGenID] = @ConfigGenID", GxErrorMask.GX_NOMASK,prmT001C11)
           ,new CursorDef("T001C12", "UPDATE [ConfigGen] SET [ConfigGenLogo]=@ConfigGenLogo, [ConfigGenLogo_GXI]=@ConfigGenLogo_GXI  WHERE [ConfigGenID] = @ConfigGenID", GxErrorMask.GX_NOMASK,prmT001C12)
           ,new CursorDef("T001C13", "DELETE FROM [ConfigGen]  WHERE [ConfigGenID] = @ConfigGenID", GxErrorMask.GX_NOMASK,prmT001C13)
           ,new CursorDef("T001C14", "SELECT TOP 1 [ResumenID] FROM [Resumen] WHERE [ConfigGenID] = @ConfigGenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C15", "UPDATE [ConfigGen] SET [ConfigGenSerial]=@ConfigGenSerial  WHERE [ConfigGenID] = @ConfigGenID", GxErrorMask.GX_NOMASK,prmT001C15)
           ,new CursorDef("T001C16", "SELECT [ConfigGenID] FROM [ConfigGen] ORDER BY [ConfigGenID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001C16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C17", "SELECT [ConfigGenID], [ConfigGenPublicidadId], [ConfigGenPublicidadTit], [ConfigGenPublicidadDes], [ConfigGenPublicidadIma_GXI], [ConfigGenPublicidadFecIni], [ConfigGenPublicidadFecFin], [ConfigGenPublicidadEsta], [ConfigGenPublicidadIma] FROM [ConfigGenPublicidad] WHERE [ConfigGenID] = @ConfigGenID and [ConfigGenPublicidadId] = @ConfigGenPublicidadId ORDER BY [ConfigGenID], [ConfigGenPublicidadId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C17,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C18", "SELECT [ConfigGenID], [ConfigGenPublicidadId] FROM [ConfigGenPublicidad] WHERE [ConfigGenID] = @ConfigGenID AND [ConfigGenPublicidadId] = @ConfigGenPublicidadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C19", "INSERT INTO [ConfigGenPublicidad]([ConfigGenID], [ConfigGenPublicidadId], [ConfigGenPublicidadTit], [ConfigGenPublicidadDes], [ConfigGenPublicidadIma], [ConfigGenPublicidadIma_GXI], [ConfigGenPublicidadFecIni], [ConfigGenPublicidadFecFin], [ConfigGenPublicidadEsta]) VALUES(@ConfigGenID, @ConfigGenPublicidadId, @ConfigGenPublicidadTit, @ConfigGenPublicidadDes, @ConfigGenPublicidadIma, @ConfigGenPublicidadIma_GXI, @ConfigGenPublicidadFecIni, @ConfigGenPublicidadFecFin, @ConfigGenPublicidadEsta)", GxErrorMask.GX_NOMASK,prmT001C19)
           ,new CursorDef("T001C20", "UPDATE [ConfigGenPublicidad] SET [ConfigGenPublicidadTit]=@ConfigGenPublicidadTit, [ConfigGenPublicidadDes]=@ConfigGenPublicidadDes, [ConfigGenPublicidadFecIni]=@ConfigGenPublicidadFecIni, [ConfigGenPublicidadFecFin]=@ConfigGenPublicidadFecFin, [ConfigGenPublicidadEsta]=@ConfigGenPublicidadEsta  WHERE [ConfigGenID] = @ConfigGenID AND [ConfigGenPublicidadId] = @ConfigGenPublicidadId", GxErrorMask.GX_NOMASK,prmT001C20)
           ,new CursorDef("T001C21", "UPDATE [ConfigGenPublicidad] SET [ConfigGenPublicidadIma]=@ConfigGenPublicidadIma, [ConfigGenPublicidadIma_GXI]=@ConfigGenPublicidadIma_GXI  WHERE [ConfigGenID] = @ConfigGenID AND [ConfigGenPublicidadId] = @ConfigGenPublicidadId", GxErrorMask.GX_NOMASK,prmT001C21)
           ,new CursorDef("T001C22", "DELETE FROM [ConfigGenPublicidad]  WHERE [ConfigGenID] = @ConfigGenID AND [ConfigGenPublicidadId] = @ConfigGenPublicidadId", GxErrorMask.GX_NOMASK,prmT001C22)
           ,new CursorDef("T001C23", "SELECT [ConfigGenID], [ConfigGenPublicidadId] FROM [ConfigGenPublicidad] WHERE [ConfigGenID] = @ConfigGenID ORDER BY [ConfigGenID], [ConfigGenPublicidadId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C23,11, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 80);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((string[]) buf[10])[0] = rslt.getString(11, 30);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              ((string[]) buf[12])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(5));
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 80);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((string[]) buf[10])[0] = rslt.getString(11, 30);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              ((string[]) buf[12])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(5));
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 80);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((string[]) buf[10])[0] = rslt.getString(11, 30);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              ((string[]) buf[12])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(5));
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 15 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
              return;
           case 16 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 21 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
  }

}

}
