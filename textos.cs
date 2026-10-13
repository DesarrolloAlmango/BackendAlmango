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
   public class textos : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "textos.aspx")), "textos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "textos.aspx")))) ;
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
                  AV7TextosId = (long)(Math.Round(NumberUtil.Val( GetPar( "TextosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7TextosId", StringUtil.LTrimStr( (decimal)(AV7TextosId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTEXTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TextosId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Textos", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTextosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public textos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public textos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_TextosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TextosId = aP1_TextosId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTextosEstado = new GXCombobox();
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
         if ( cmbTextosEstado.ItemCount > 0 )
         {
            A534TextosEstado = cmbTextosEstado.getValidValue(A534TextosEstado);
            n534TextosEstado = false;
            AssignAttri("", false, "A534TextosEstado", A534TextosEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTextosEstado.CurrentValue = StringUtil.RTrim( A534TextosEstado);
            AssignProp("", false, cmbTextosEstado_Internalname, "Values", cmbTextosEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTextosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTextosId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTextosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A150TextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtTextosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A150TextosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A150TextosId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTextosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTextosId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Textos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTextosTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTextosTipo_Internalname, context.GetMessage( "Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTextosTipo_Internalname, StringUtil.RTrim( A258TextosTipo), StringUtil.RTrim( context.localUtil.Format( A258TextosTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTextosTipo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTextosTipo_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Textos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTextosEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTextosEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTextosEstado, cmbTextosEstado_Internalname, StringUtil.RTrim( A534TextosEstado), 1, cmbTextosEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbTextosEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", true, 0, "HLP_Textos.htm");
         cmbTextosEstado.CurrentValue = StringUtil.RTrim( A534TextosEstado);
         AssignProp("", false, cmbTextosEstado_Internalname, "Values", (string)(cmbTextosEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTextosRutaPDF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTextosRutaPDF_Internalname, context.GetMessage( "Ruta PDF", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTextosRutaPDF_Internalname, A977TextosRutaPDF, StringUtil.RTrim( context.localUtil.Format( A977TextosRutaPDF, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTextosRutaPDF_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTextosRutaPDF_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Textos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTextosTitulo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTextosTitulo_Internalname, context.GetMessage( "Titulo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTextosTitulo_Internalname, StringUtil.RTrim( A259TextosTitulo), StringUtil.RTrim( context.localUtil.Format( A259TextosTitulo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTextosTitulo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTextosTitulo_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Textos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* User Defined Control */
         ucTextosdescripcion.SetProperty("Attribute", TextosDescripcion);
         ucTextosdescripcion.SetProperty("Skin", Textosdescripcion_Skin);
         ucTextosdescripcion.SetProperty("Toolbar", Textosdescripcion_Toolbar);
         ucTextosdescripcion.SetProperty("CaptionClass", Textosdescripcion_Captionclass);
         ucTextosdescripcion.SetProperty("CaptionStyle", Textosdescripcion_Captionstyle);
         ucTextosdescripcion.SetProperty("CaptionPosition", Textosdescripcion_Captionposition);
         ucTextosdescripcion.Render(context, "fckeditor", Textosdescripcion_Internalname, "TEXTOSDESCRIPCIONContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Textos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Textos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Textos.htm");
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
         E11172 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z150TextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z150TextosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z258TextosTipo = cgiGet( "Z258TextosTipo");
               Z259TextosTitulo = cgiGet( "Z259TextosTitulo");
               Z534TextosEstado = cgiGet( "Z534TextosEstado");
               n534TextosEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A534TextosEstado)) ? true : false);
               Z977TextosRutaPDF = cgiGet( "Z977TextosRutaPDF");
               n977TextosRutaPDF = (String.IsNullOrEmpty(StringUtil.RTrim( A977TextosRutaPDF)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7TextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vTEXTOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A257TextosDescripcion = cgiGet( "TEXTOSDESCRIPCION");
               AV14Pgmname = cgiGet( "vPGMNAME");
               Textosdescripcion_Objectcall = cgiGet( "TEXTOSDESCRIPCION_Objectcall");
               Textosdescripcion_Class = cgiGet( "TEXTOSDESCRIPCION_Class");
               Textosdescripcion_Enabled = StringUtil.StrToBool( cgiGet( "TEXTOSDESCRIPCION_Enabled"));
               Textosdescripcion_Width = cgiGet( "TEXTOSDESCRIPCION_Width");
               Textosdescripcion_Height = cgiGet( "TEXTOSDESCRIPCION_Height");
               Textosdescripcion_Skin = cgiGet( "TEXTOSDESCRIPCION_Skin");
               Textosdescripcion_Toolbar = cgiGet( "TEXTOSDESCRIPCION_Toolbar");
               Textosdescripcion_Customtoolbar = cgiGet( "TEXTOSDESCRIPCION_Customtoolbar");
               Textosdescripcion_Customconfiguration = cgiGet( "TEXTOSDESCRIPCION_Customconfiguration");
               Textosdescripcion_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( "TEXTOSDESCRIPCION_Toolbarcancollapse"));
               Textosdescripcion_Toolbarexpanded = StringUtil.StrToBool( cgiGet( "TEXTOSDESCRIPCION_Toolbarexpanded"));
               Textosdescripcion_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TEXTOSDESCRIPCION_Color"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Textosdescripcion_Buttonpressedid = cgiGet( "TEXTOSDESCRIPCION_Buttonpressedid");
               Textosdescripcion_Captionvalue = cgiGet( "TEXTOSDESCRIPCION_Captionvalue");
               Textosdescripcion_Captionclass = cgiGet( "TEXTOSDESCRIPCION_Captionclass");
               Textosdescripcion_Captionstyle = cgiGet( "TEXTOSDESCRIPCION_Captionstyle");
               Textosdescripcion_Captionposition = cgiGet( "TEXTOSDESCRIPCION_Captionposition");
               Textosdescripcion_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "TEXTOSDESCRIPCION_Isabstractlayoutcontrol"));
               Textosdescripcion_Coltitle = cgiGet( "TEXTOSDESCRIPCION_Coltitle");
               Textosdescripcion_Coltitlefont = cgiGet( "TEXTOSDESCRIPCION_Coltitlefont");
               Textosdescripcion_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TEXTOSDESCRIPCION_Coltitlecolor"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Textosdescripcion_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "TEXTOSDESCRIPCION_Usercontroliscolumn"));
               Textosdescripcion_Visible = StringUtil.StrToBool( cgiGet( "TEXTOSDESCRIPCION_Visible"));
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
               A150TextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTextosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n150TextosId = false;
               AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
               A258TextosTipo = cgiGet( edtTextosTipo_Internalname);
               AssignAttri("", false, "A258TextosTipo", A258TextosTipo);
               cmbTextosEstado.CurrentValue = cgiGet( cmbTextosEstado_Internalname);
               A534TextosEstado = cgiGet( cmbTextosEstado_Internalname);
               n534TextosEstado = false;
               AssignAttri("", false, "A534TextosEstado", A534TextosEstado);
               n534TextosEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A534TextosEstado)) ? true : false);
               A977TextosRutaPDF = cgiGet( edtTextosRutaPDF_Internalname);
               n977TextosRutaPDF = false;
               AssignAttri("", false, "A977TextosRutaPDF", A977TextosRutaPDF);
               n977TextosRutaPDF = (String.IsNullOrEmpty(StringUtil.RTrim( A977TextosRutaPDF)) ? true : false);
               A259TextosTitulo = cgiGet( edtTextosTitulo_Internalname);
               AssignAttri("", false, "A259TextosTitulo", A259TextosTitulo);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Textos");
               A150TextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTextosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n150TextosId = false;
               AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
               forbiddenHiddens.Add("TextosId", context.localUtil.Format( (decimal)(A150TextosId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A150TextosId != Z150TextosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("textos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A150TextosId = (long)(Math.Round(NumberUtil.Val( GetPar( "TextosId"), "."), 18, MidpointRounding.ToEven));
                  n150TextosId = false;
                  AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
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
                     sMode49 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode49;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound49 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_170( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TEXTOSID");
                        AnyError = 1;
                        GX_FocusControl = edtTextosId_Internalname;
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
                           E11172 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12172 ();
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
            E12172 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1749( ) ;
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
            DisableAttributes1749( ) ;
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

      protected void CONFIRM_170( )
      {
         BeforeValidate1749( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1749( ) ;
            }
            else
            {
               CheckExtendedTable1749( ) ;
               CloseExtendedTableCursors1749( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption170( )
      {
      }

      protected void E11172( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV11WWPContext) ;
         AV8IsAuthorized = true;
         AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWTextos_Insert", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWTextos_Update", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWTextos_Delete", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV14Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12172( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("textosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1749( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z258TextosTipo = T00173_A258TextosTipo[0];
               Z259TextosTitulo = T00173_A259TextosTitulo[0];
               Z534TextosEstado = T00173_A534TextosEstado[0];
               Z977TextosRutaPDF = T00173_A977TextosRutaPDF[0];
            }
            else
            {
               Z258TextosTipo = A258TextosTipo;
               Z259TextosTitulo = A259TextosTitulo;
               Z534TextosEstado = A534TextosEstado;
               Z977TextosRutaPDF = A977TextosRutaPDF;
            }
         }
         if ( GX_JID == -5 )
         {
            Z150TextosId = A150TextosId;
            Z258TextosTipo = A258TextosTipo;
            Z259TextosTitulo = A259TextosTitulo;
            Z257TextosDescripcion = A257TextosDescripcion;
            Z534TextosEstado = A534TextosEstado;
            Z977TextosRutaPDF = A977TextosRutaPDF;
         }
      }

      protected void standaloneNotModal( )
      {
         edtTextosId_Enabled = 0;
         AssignProp("", false, edtTextosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTextosId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtTextosId_Enabled = 0;
         AssignProp("", false, edtTextosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTextosId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TextosId) )
         {
            A150TextosId = AV7TextosId;
            n150TextosId = false;
            AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A534TextosEstado)) && ( Gx_BScreen == 0 ) )
         {
            A534TextosEstado = "HAB";
            n534TextosEstado = false;
            AssignAttri("", false, "A534TextosEstado", A534TextosEstado);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1749( )
      {
         /* Using cursor T00174 */
         pr_default.execute(2, new Object[] {n150TextosId, A150TextosId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound49 = 1;
            A258TextosTipo = T00174_A258TextosTipo[0];
            AssignAttri("", false, "A258TextosTipo", A258TextosTipo);
            A259TextosTitulo = T00174_A259TextosTitulo[0];
            AssignAttri("", false, "A259TextosTitulo", A259TextosTitulo);
            A257TextosDescripcion = T00174_A257TextosDescripcion[0];
            A534TextosEstado = T00174_A534TextosEstado[0];
            n534TextosEstado = T00174_n534TextosEstado[0];
            AssignAttri("", false, "A534TextosEstado", A534TextosEstado);
            A977TextosRutaPDF = T00174_A977TextosRutaPDF[0];
            n977TextosRutaPDF = T00174_n977TextosRutaPDF[0];
            AssignAttri("", false, "A977TextosRutaPDF", A977TextosRutaPDF);
            ZM1749( -5) ;
         }
         pr_default.close(2);
         OnLoadActions1749( ) ;
      }

      protected void OnLoadActions1749( )
      {
         AV14Pgmname = "Textos";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable1749( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV14Pgmname = "Textos";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         if ( ! ( ( StringUtil.StrCmp(A534TextosEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A534TextosEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A534TextosEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A534TextosEstado, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A534TextosEstado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Textos Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "TEXTOSESTADO");
            AnyError = 1;
            GX_FocusControl = cmbTextosEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1749( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1749( )
      {
         /* Using cursor T00175 */
         pr_default.execute(3, new Object[] {n150TextosId, A150TextosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound49 = 1;
         }
         else
         {
            RcdFound49 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00173 */
         pr_default.execute(1, new Object[] {n150TextosId, A150TextosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1749( 5) ;
            RcdFound49 = 1;
            A150TextosId = T00173_A150TextosId[0];
            n150TextosId = T00173_n150TextosId[0];
            AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
            A258TextosTipo = T00173_A258TextosTipo[0];
            AssignAttri("", false, "A258TextosTipo", A258TextosTipo);
            A259TextosTitulo = T00173_A259TextosTitulo[0];
            AssignAttri("", false, "A259TextosTitulo", A259TextosTitulo);
            A257TextosDescripcion = T00173_A257TextosDescripcion[0];
            A534TextosEstado = T00173_A534TextosEstado[0];
            n534TextosEstado = T00173_n534TextosEstado[0];
            AssignAttri("", false, "A534TextosEstado", A534TextosEstado);
            A977TextosRutaPDF = T00173_A977TextosRutaPDF[0];
            n977TextosRutaPDF = T00173_n977TextosRutaPDF[0];
            AssignAttri("", false, "A977TextosRutaPDF", A977TextosRutaPDF);
            Z150TextosId = A150TextosId;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1749( ) ;
            if ( AnyError == 1 )
            {
               RcdFound49 = 0;
               InitializeNonKey1749( ) ;
            }
            Gx_mode = sMode49;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound49 = 0;
            InitializeNonKey1749( ) ;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode49;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1749( ) ;
         if ( RcdFound49 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound49 = 0;
         /* Using cursor T00176 */
         pr_default.execute(4, new Object[] {n150TextosId, A150TextosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00176_A150TextosId[0] < A150TextosId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00176_A150TextosId[0] > A150TextosId ) ) )
            {
               A150TextosId = T00176_A150TextosId[0];
               n150TextosId = T00176_n150TextosId[0];
               AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
               RcdFound49 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound49 = 0;
         /* Using cursor T00177 */
         pr_default.execute(5, new Object[] {n150TextosId, A150TextosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00177_A150TextosId[0] > A150TextosId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00177_A150TextosId[0] < A150TextosId ) ) )
            {
               A150TextosId = T00177_A150TextosId[0];
               n150TextosId = T00177_n150TextosId[0];
               AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
               RcdFound49 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1749( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTextosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1749( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound49 == 1 )
            {
               if ( A150TextosId != Z150TextosId )
               {
                  A150TextosId = Z150TextosId;
                  n150TextosId = false;
                  AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TEXTOSID");
                  AnyError = 1;
                  GX_FocusControl = edtTextosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTextosTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1749( ) ;
                  GX_FocusControl = edtTextosTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A150TextosId != Z150TextosId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTextosTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1749( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TEXTOSID");
                     AnyError = 1;
                     GX_FocusControl = edtTextosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTextosTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1749( ) ;
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
         if ( A150TextosId != Z150TextosId )
         {
            A150TextosId = Z150TextosId;
            n150TextosId = false;
            AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TEXTOSID");
            AnyError = 1;
            GX_FocusControl = edtTextosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTextosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1749( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00172 */
            pr_default.execute(0, new Object[] {n150TextosId, A150TextosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Textos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z258TextosTipo, T00172_A258TextosTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z259TextosTitulo, T00172_A259TextosTitulo[0]) != 0 ) || ( StringUtil.StrCmp(Z534TextosEstado, T00172_A534TextosEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z977TextosRutaPDF, T00172_A977TextosRutaPDF[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z258TextosTipo, T00172_A258TextosTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("textos:[seudo value changed for attri]"+"TextosTipo");
                  GXUtil.WriteLogRaw("Old: ",Z258TextosTipo);
                  GXUtil.WriteLogRaw("Current: ",T00172_A258TextosTipo[0]);
               }
               if ( StringUtil.StrCmp(Z259TextosTitulo, T00172_A259TextosTitulo[0]) != 0 )
               {
                  GXUtil.WriteLog("textos:[seudo value changed for attri]"+"TextosTitulo");
                  GXUtil.WriteLogRaw("Old: ",Z259TextosTitulo);
                  GXUtil.WriteLogRaw("Current: ",T00172_A259TextosTitulo[0]);
               }
               if ( StringUtil.StrCmp(Z534TextosEstado, T00172_A534TextosEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("textos:[seudo value changed for attri]"+"TextosEstado");
                  GXUtil.WriteLogRaw("Old: ",Z534TextosEstado);
                  GXUtil.WriteLogRaw("Current: ",T00172_A534TextosEstado[0]);
               }
               if ( StringUtil.StrCmp(Z977TextosRutaPDF, T00172_A977TextosRutaPDF[0]) != 0 )
               {
                  GXUtil.WriteLog("textos:[seudo value changed for attri]"+"TextosRutaPDF");
                  GXUtil.WriteLogRaw("Old: ",Z977TextosRutaPDF);
                  GXUtil.WriteLogRaw("Current: ",T00172_A977TextosRutaPDF[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Textos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1749( )
      {
         BeforeValidate1749( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1749( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1749( 0) ;
            CheckOptimisticConcurrency1749( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1749( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1749( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00178 */
                     pr_default.execute(6, new Object[] {A258TextosTipo, A259TextosTitulo, A257TextosDescripcion, n534TextosEstado, A534TextosEstado, n977TextosRutaPDF, A977TextosRutaPDF});
                     A150TextosId = T00178_A150TextosId[0];
                     n150TextosId = T00178_n150TextosId[0];
                     AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Textos");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption170( ) ;
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
               Load1749( ) ;
            }
            EndLevel1749( ) ;
         }
         CloseExtendedTableCursors1749( ) ;
      }

      protected void Update1749( )
      {
         BeforeValidate1749( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1749( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1749( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1749( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1749( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00179 */
                     pr_default.execute(7, new Object[] {A258TextosTipo, A259TextosTitulo, A257TextosDescripcion, n534TextosEstado, A534TextosEstado, n977TextosRutaPDF, A977TextosRutaPDF, n150TextosId, A150TextosId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Textos");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Textos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1749( ) ;
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
            EndLevel1749( ) ;
         }
         CloseExtendedTableCursors1749( ) ;
      }

      protected void DeferredUpdate1749( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1749( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1749( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1749( ) ;
            AfterConfirm1749( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1749( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001710 */
                  pr_default.execute(8, new Object[] {n150TextosId, A150TextosId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Textos");
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
         sMode49 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1749( ) ;
         Gx_mode = sMode49;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1749( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "Textos";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001711 */
            pr_default.execute(9, new Object[] {n150TextosId, A150TextosId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Inventario", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T001712 */
            pr_default.execute(10, new Object[] {n150TextosId, A150TextosId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros Medidas y Precios", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel1749( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1749( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("textos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues170( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("textos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1749( )
      {
         /* Scan By routine */
         /* Using cursor T001713 */
         pr_default.execute(11);
         RcdFound49 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound49 = 1;
            A150TextosId = T001713_A150TextosId[0];
            n150TextosId = T001713_n150TextosId[0];
            AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1749( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound49 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound49 = 1;
            A150TextosId = T001713_A150TextosId[0];
            n150TextosId = T001713_n150TextosId[0];
            AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
         }
      }

      protected void ScanEnd1749( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1749( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1749( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1749( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1749( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1749( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1749( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1749( )
      {
         edtTextosId_Enabled = 0;
         AssignProp("", false, edtTextosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTextosId_Enabled), 5, 0), true);
         edtTextosTipo_Enabled = 0;
         AssignProp("", false, edtTextosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTextosTipo_Enabled), 5, 0), true);
         cmbTextosEstado.Enabled = 0;
         AssignProp("", false, cmbTextosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTextosEstado.Enabled), 5, 0), true);
         edtTextosRutaPDF_Enabled = 0;
         AssignProp("", false, edtTextosRutaPDF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTextosRutaPDF_Enabled), 5, 0), true);
         edtTextosTitulo_Enabled = 0;
         AssignProp("", false, edtTextosTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTextosTitulo_Enabled), 5, 0), true);
         Textosdescripcion_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Textosdescripcion_Internalname, "Enabled", StringUtil.BoolToStr( Textosdescripcion_Enabled), true);
      }

      protected void send_integrity_lvl_hashes1749( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues170( )
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
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true, false);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true, false);
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
         GXEncryptionTmp = "textos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TextosId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("textos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Textos");
         forbiddenHiddens.Add("TextosId", context.localUtil.Format( (decimal)(A150TextosId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("textos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z150TextosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z150TextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z258TextosTipo", StringUtil.RTrim( Z258TextosTipo));
         GxWebStd.gx_hidden_field( context, "Z259TextosTitulo", StringUtil.RTrim( Z259TextosTitulo));
         GxWebStd.gx_hidden_field( context, "Z534TextosEstado", StringUtil.RTrim( Z534TextosEstado));
         GxWebStd.gx_hidden_field( context, "Z977TextosRutaPDF", Z977TextosRutaPDF);
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
         GxWebStd.gx_hidden_field( context, "vTEXTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTEXTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TextosId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "TEXTOSDESCRIPCION", A257TextosDescripcion);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
         GxWebStd.gx_hidden_field( context, "TEXTOSDESCRIPCION_Objectcall", StringUtil.RTrim( Textosdescripcion_Objectcall));
         GxWebStd.gx_hidden_field( context, "TEXTOSDESCRIPCION_Enabled", StringUtil.BoolToStr( Textosdescripcion_Enabled));
         GxWebStd.gx_hidden_field( context, "TEXTOSDESCRIPCION_Skin", StringUtil.RTrim( Textosdescripcion_Skin));
         GxWebStd.gx_hidden_field( context, "TEXTOSDESCRIPCION_Toolbar", StringUtil.RTrim( Textosdescripcion_Toolbar));
         GxWebStd.gx_hidden_field( context, "TEXTOSDESCRIPCION_Captionclass", StringUtil.RTrim( Textosdescripcion_Captionclass));
         GxWebStd.gx_hidden_field( context, "TEXTOSDESCRIPCION_Captionstyle", StringUtil.RTrim( Textosdescripcion_Captionstyle));
         GxWebStd.gx_hidden_field( context, "TEXTOSDESCRIPCION_Captionposition", StringUtil.RTrim( Textosdescripcion_Captionposition));
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
         GXEncryptionTmp = "textos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TextosId,18,0));
         return formatLink("textos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Textos" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Textos", "") ;
      }

      protected void InitializeNonKey1749( )
      {
         A258TextosTipo = "";
         AssignAttri("", false, "A258TextosTipo", A258TextosTipo);
         A259TextosTitulo = "";
         AssignAttri("", false, "A259TextosTitulo", A259TextosTitulo);
         A257TextosDescripcion = "";
         AssignAttri("", false, "A257TextosDescripcion", A257TextosDescripcion);
         A977TextosRutaPDF = "";
         n977TextosRutaPDF = false;
         AssignAttri("", false, "A977TextosRutaPDF", A977TextosRutaPDF);
         n977TextosRutaPDF = (String.IsNullOrEmpty(StringUtil.RTrim( A977TextosRutaPDF)) ? true : false);
         A534TextosEstado = "HAB";
         n534TextosEstado = false;
         AssignAttri("", false, "A534TextosEstado", A534TextosEstado);
         Z258TextosTipo = "";
         Z259TextosTitulo = "";
         Z534TextosEstado = "";
         Z977TextosRutaPDF = "";
      }

      protected void InitAll1749( )
      {
         A150TextosId = 0;
         n150TextosId = false;
         AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
         InitializeNonKey1749( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A534TextosEstado = i534TextosEstado;
         n534TextosEstado = false;
         AssignAttri("", false, "A534TextosEstado", A534TextosEstado);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932031291", true, true, false);
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
         context.AddJavascriptSource("textos.js", "?2026932031291", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true, false);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtTextosId_Internalname = "TEXTOSID";
         edtTextosTipo_Internalname = "TEXTOSTIPO";
         cmbTextosEstado_Internalname = "TEXTOSESTADO";
         edtTextosRutaPDF_Internalname = "TEXTOSRUTAPDF";
         edtTextosTitulo_Internalname = "TEXTOSTITULO";
         Textosdescripcion_Internalname = "TEXTOSDESCRIPCION";
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
         Form.Caption = context.GetMessage( "Textos", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         Textosdescripcion_Captionposition = "None";
         Textosdescripcion_Captionstyle = "";
         Textosdescripcion_Captionclass = "col-sm-3 AttributeLabel";
         Textosdescripcion_Toolbar = "Custom";
         Textosdescripcion_Skin = "default";
         Textosdescripcion_Enabled = Convert.ToBoolean( 1);
         edtTextosTitulo_Jsonclick = "";
         edtTextosTitulo_Enabled = 1;
         edtTextosRutaPDF_Jsonclick = "";
         edtTextosRutaPDF_Enabled = 1;
         cmbTextosEstado_Jsonclick = "";
         cmbTextosEstado.Enabled = 1;
         edtTextosTipo_Jsonclick = "";
         edtTextosTipo_Enabled = 1;
         edtTextosId_Jsonclick = "";
         edtTextosId_Enabled = 0;
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
         cmbTextosEstado.Name = "TEXTOSESTADO";
         cmbTextosEstado.WebTags = "";
         cmbTextosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbTextosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbTextosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbTextosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbTextosEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A534TextosEstado)) )
            {
               A534TextosEstado = "HAB";
               n534TextosEstado = false;
               AssignAttri("", false, "A534TextosEstado", A534TextosEstado);
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7TextosId',fld:'vTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7TextosId',fld:'vTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A150TextosId',fld:'TEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12172',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_TEXTOSID","{handler:'Valid_Textosid',iparms:[]");
         setEventMetadata("VALID_TEXTOSID",",oparms:[]}");
         setEventMetadata("VALID_TEXTOSESTADO","{handler:'Valid_Textosestado',iparms:[]");
         setEventMetadata("VALID_TEXTOSESTADO",",oparms:[]}");
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
         Z258TextosTipo = "";
         Z259TextosTitulo = "";
         Z534TextosEstado = "";
         Z977TextosRutaPDF = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A534TextosEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A258TextosTipo = "";
         A977TextosRutaPDF = "";
         A259TextosTitulo = "";
         ucTextosdescripcion = new GXUserControl();
         TextosDescripcion = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A257TextosDescripcion = "";
         AV14Pgmname = "";
         Textosdescripcion_Objectcall = "";
         Textosdescripcion_Class = "";
         Textosdescripcion_Width = "";
         Textosdescripcion_Height = "";
         Textosdescripcion_Customtoolbar = "";
         Textosdescripcion_Customconfiguration = "";
         Textosdescripcion_Buttonpressedid = "";
         Textosdescripcion_Captionvalue = "";
         Textosdescripcion_Coltitle = "";
         Textosdescripcion_Coltitlefont = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode49 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV11WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z257TextosDescripcion = "";
         T00174_A150TextosId = new long[1] ;
         T00174_n150TextosId = new bool[] {false} ;
         T00174_A258TextosTipo = new string[] {""} ;
         T00174_A259TextosTitulo = new string[] {""} ;
         T00174_A257TextosDescripcion = new string[] {""} ;
         T00174_A534TextosEstado = new string[] {""} ;
         T00174_n534TextosEstado = new bool[] {false} ;
         T00174_A977TextosRutaPDF = new string[] {""} ;
         T00174_n977TextosRutaPDF = new bool[] {false} ;
         T00175_A150TextosId = new long[1] ;
         T00175_n150TextosId = new bool[] {false} ;
         T00173_A150TextosId = new long[1] ;
         T00173_n150TextosId = new bool[] {false} ;
         T00173_A258TextosTipo = new string[] {""} ;
         T00173_A259TextosTitulo = new string[] {""} ;
         T00173_A257TextosDescripcion = new string[] {""} ;
         T00173_A534TextosEstado = new string[] {""} ;
         T00173_n534TextosEstado = new bool[] {false} ;
         T00173_A977TextosRutaPDF = new string[] {""} ;
         T00173_n977TextosRutaPDF = new bool[] {false} ;
         T00176_A150TextosId = new long[1] ;
         T00176_n150TextosId = new bool[] {false} ;
         T00177_A150TextosId = new long[1] ;
         T00177_n150TextosId = new bool[] {false} ;
         T00172_A150TextosId = new long[1] ;
         T00172_n150TextosId = new bool[] {false} ;
         T00172_A258TextosTipo = new string[] {""} ;
         T00172_A259TextosTitulo = new string[] {""} ;
         T00172_A257TextosDescripcion = new string[] {""} ;
         T00172_A534TextosEstado = new string[] {""} ;
         T00172_n534TextosEstado = new bool[] {false} ;
         T00172_A977TextosRutaPDF = new string[] {""} ;
         T00172_n977TextosRutaPDF = new bool[] {false} ;
         T00178_A150TextosId = new long[1] ;
         T00178_n150TextosId = new bool[] {false} ;
         T001711_A121RubrosId = new short[1] ;
         T001711_A137MedidasID = new long[1] ;
         T001711_A135InventarioId = new long[1] ;
         T001712_A121RubrosId = new short[1] ;
         T001712_A137MedidasID = new long[1] ;
         T001713_A150TextosId = new long[1] ;
         T001713_n150TextosId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i534TextosEstado = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.textos__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.textos__default(),
            new Object[][] {
                new Object[] {
               T00172_A150TextosId, T00172_A258TextosTipo, T00172_A259TextosTitulo, T00172_A257TextosDescripcion, T00172_A534TextosEstado, T00172_n534TextosEstado, T00172_A977TextosRutaPDF, T00172_n977TextosRutaPDF
               }
               , new Object[] {
               T00173_A150TextosId, T00173_A258TextosTipo, T00173_A259TextosTitulo, T00173_A257TextosDescripcion, T00173_A534TextosEstado, T00173_n534TextosEstado, T00173_A977TextosRutaPDF, T00173_n977TextosRutaPDF
               }
               , new Object[] {
               T00174_A150TextosId, T00174_A258TextosTipo, T00174_A259TextosTitulo, T00174_A257TextosDescripcion, T00174_A534TextosEstado, T00174_n534TextosEstado, T00174_A977TextosRutaPDF, T00174_n977TextosRutaPDF
               }
               , new Object[] {
               T00175_A150TextosId
               }
               , new Object[] {
               T00176_A150TextosId
               }
               , new Object[] {
               T00177_A150TextosId
               }
               , new Object[] {
               T00178_A150TextosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001711_A121RubrosId, T001711_A137MedidasID, T001711_A135InventarioId
               }
               , new Object[] {
               T001712_A121RubrosId, T001712_A137MedidasID
               }
               , new Object[] {
               T001713_A150TextosId
               }
            }
         );
         AV14Pgmname = "Textos";
         Z534TextosEstado = "HAB";
         n534TextosEstado = false;
         A534TextosEstado = "HAB";
         n534TextosEstado = false;
         i534TextosEstado = "HAB";
         n534TextosEstado = false;
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound49 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtTextosId_Enabled ;
      private int edtTextosTipo_Enabled ;
      private int edtTextosRutaPDF_Enabled ;
      private int edtTextosTitulo_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Textosdescripcion_Color ;
      private int Textosdescripcion_Coltitlecolor ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long wcpOAV7TextosId ;
      private long Z150TextosId ;
      private long AV7TextosId ;
      private long A150TextosId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z258TextosTipo ;
      private string Z259TextosTitulo ;
      private string Z534TextosEstado ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTextosTipo_Internalname ;
      private string A534TextosEstado ;
      private string cmbTextosEstado_Internalname ;
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
      private string edtTextosId_Internalname ;
      private string TempTags ;
      private string edtTextosId_Jsonclick ;
      private string A258TextosTipo ;
      private string edtTextosTipo_Jsonclick ;
      private string cmbTextosEstado_Jsonclick ;
      private string edtTextosRutaPDF_Internalname ;
      private string edtTextosRutaPDF_Jsonclick ;
      private string edtTextosTitulo_Internalname ;
      private string A259TextosTitulo ;
      private string edtTextosTitulo_Jsonclick ;
      private string Textosdescripcion_Skin ;
      private string Textosdescripcion_Toolbar ;
      private string Textosdescripcion_Captionclass ;
      private string Textosdescripcion_Captionstyle ;
      private string Textosdescripcion_Captionposition ;
      private string Textosdescripcion_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV14Pgmname ;
      private string Textosdescripcion_Objectcall ;
      private string Textosdescripcion_Class ;
      private string Textosdescripcion_Width ;
      private string Textosdescripcion_Height ;
      private string Textosdescripcion_Customtoolbar ;
      private string Textosdescripcion_Customconfiguration ;
      private string Textosdescripcion_Buttonpressedid ;
      private string Textosdescripcion_Captionvalue ;
      private string Textosdescripcion_Coltitle ;
      private string Textosdescripcion_Coltitlefont ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode49 ;
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
      private string i534TextosEstado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n534TextosEstado ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n977TextosRutaPDF ;
      private bool Textosdescripcion_Enabled ;
      private bool Textosdescripcion_Toolbarcancollapse ;
      private bool Textosdescripcion_Toolbarexpanded ;
      private bool Textosdescripcion_Isabstractlayoutcontrol ;
      private bool Textosdescripcion_Usercontroliscolumn ;
      private bool Textosdescripcion_Visible ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n150TextosId ;
      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private string TextosDescripcion ;
      private string A257TextosDescripcion ;
      private string Z257TextosDescripcion ;
      private string Z977TextosRutaPDF ;
      private string A977TextosRutaPDF ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucTextosdescripcion ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTextosEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV11WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] T00174_A150TextosId ;
      private bool[] T00174_n150TextosId ;
      private string[] T00174_A258TextosTipo ;
      private string[] T00174_A259TextosTitulo ;
      private string[] T00174_A257TextosDescripcion ;
      private string[] T00174_A534TextosEstado ;
      private bool[] T00174_n534TextosEstado ;
      private string[] T00174_A977TextosRutaPDF ;
      private bool[] T00174_n977TextosRutaPDF ;
      private long[] T00175_A150TextosId ;
      private bool[] T00175_n150TextosId ;
      private long[] T00173_A150TextosId ;
      private bool[] T00173_n150TextosId ;
      private string[] T00173_A258TextosTipo ;
      private string[] T00173_A259TextosTitulo ;
      private string[] T00173_A257TextosDescripcion ;
      private string[] T00173_A534TextosEstado ;
      private bool[] T00173_n534TextosEstado ;
      private string[] T00173_A977TextosRutaPDF ;
      private bool[] T00173_n977TextosRutaPDF ;
      private long[] T00176_A150TextosId ;
      private bool[] T00176_n150TextosId ;
      private long[] T00177_A150TextosId ;
      private bool[] T00177_n150TextosId ;
      private long[] T00172_A150TextosId ;
      private bool[] T00172_n150TextosId ;
      private string[] T00172_A258TextosTipo ;
      private string[] T00172_A259TextosTitulo ;
      private string[] T00172_A257TextosDescripcion ;
      private string[] T00172_A534TextosEstado ;
      private bool[] T00172_n534TextosEstado ;
      private string[] T00172_A977TextosRutaPDF ;
      private bool[] T00172_n977TextosRutaPDF ;
      private long[] T00178_A150TextosId ;
      private bool[] T00178_n150TextosId ;
      private short[] T001711_A121RubrosId ;
      private long[] T001711_A137MedidasID ;
      private long[] T001711_A135InventarioId ;
      private short[] T001712_A121RubrosId ;
      private long[] T001712_A137MedidasID ;
      private long[] T001713_A150TextosId ;
      private bool[] T001713_n150TextosId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class textos__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class textos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00172;
        prmT00172 = new Object[] {
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00173;
        prmT00173 = new Object[] {
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00174;
        prmT00174 = new Object[] {
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00175;
        prmT00175 = new Object[] {
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00176;
        prmT00176 = new Object[] {
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00177;
        prmT00177 = new Object[] {
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT00178;
        prmT00178 = new Object[] {
        new ParDef("@TextosTipo",GXType.NChar,20,0) ,
        new ParDef("@TextosTitulo",GXType.NChar,80,0) ,
        new ParDef("@TextosDescripcion",GXType.NVarChar,2097152,0) ,
        new ParDef("@TextosEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@TextosRutaPDF",GXType.NVarChar,100,0){Nullable=true}
        };
        Object[] prmT00179;
        prmT00179 = new Object[] {
        new ParDef("@TextosTipo",GXType.NChar,20,0) ,
        new ParDef("@TextosTitulo",GXType.NChar,80,0) ,
        new ParDef("@TextosDescripcion",GXType.NVarChar,2097152,0) ,
        new ParDef("@TextosEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@TextosRutaPDF",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001710;
        prmT001710 = new Object[] {
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001711;
        prmT001711 = new Object[] {
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001712;
        prmT001712 = new Object[] {
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001713;
        prmT001713 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00172", "SELECT [TextosId], [TextosTipo], [TextosTitulo], [TextosDescripcion], [TextosEstado], [TextosRutaPDF] FROM [Textos] WITH (UPDLOCK) WHERE [TextosId] = @TextosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00172,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00173", "SELECT [TextosId], [TextosTipo], [TextosTitulo], [TextosDescripcion], [TextosEstado], [TextosRutaPDF] FROM [Textos] WHERE [TextosId] = @TextosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00173,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00174", "SELECT TM1.[TextosId], TM1.[TextosTipo], TM1.[TextosTitulo], TM1.[TextosDescripcion], TM1.[TextosEstado], TM1.[TextosRutaPDF] FROM [Textos] TM1 WHERE TM1.[TextosId] = @TextosId ORDER BY TM1.[TextosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00174,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00175", "SELECT [TextosId] FROM [Textos] WHERE [TextosId] = @TextosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00175,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00176", "SELECT TOP 1 [TextosId] FROM [Textos] WHERE ( [TextosId] > @TextosId) ORDER BY [TextosId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00176,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00177", "SELECT TOP 1 [TextosId] FROM [Textos] WHERE ( [TextosId] < @TextosId) ORDER BY [TextosId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00177,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00178", "INSERT INTO [Textos]([TextosTipo], [TextosTitulo], [TextosDescripcion], [TextosEstado], [TextosRutaPDF]) VALUES(@TextosTipo, @TextosTitulo, @TextosDescripcion, @TextosEstado, @TextosRutaPDF); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT00178,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00179", "UPDATE [Textos] SET [TextosTipo]=@TextosTipo, [TextosTitulo]=@TextosTitulo, [TextosDescripcion]=@TextosDescripcion, [TextosEstado]=@TextosEstado, [TextosRutaPDF]=@TextosRutaPDF  WHERE [TextosId] = @TextosId", GxErrorMask.GX_NOMASK,prmT00179)
           ,new CursorDef("T001710", "DELETE FROM [Textos]  WHERE [TextosId] = @TextosId", GxErrorMask.GX_NOMASK,prmT001710)
           ,new CursorDef("T001711", "SELECT TOP 1 [RubrosId], [MedidasID], [InventarioId] FROM [Inventario] WHERE [InventarioTextosId] = @TextosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001711,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001712", "SELECT TOP 1 [RubrosId], [MedidasID] FROM [RubrosMedidas] WHERE [TextosId] = @TextosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001712,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001713", "SELECT [TextosId] FROM [Textos] ORDER BY [TextosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001713,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 10 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
