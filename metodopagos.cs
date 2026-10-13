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
   public class metodopagos : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"ESTADOSGENERICOSID") == 0 )
         {
            A107EstadosTipo = GetPar( "EstadosTipo");
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAESTADOSGENERICOSID1041( A107EstadosTipo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A107EstadosTipo = GetPar( "EstadosTipo");
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
            A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosGenericosId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A107EstadosTipo, A108EstadosGenericosId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "metodopagos.aspx")), "metodopagos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "metodopagos.aspx")))) ;
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
                  AV7MetodoPagosID = (long)(Math.Round(NumberUtil.Val( GetPar( "MetodoPagosID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7MetodoPagosID", StringUtil.LTrimStr( (decimal)(AV7MetodoPagosID), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMETODOPAGOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MetodoPagosID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Metodo Pagos", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMetodoPagosID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public metodopagos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public metodopagos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_MetodoPagosID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MetodoPagosID = aP1_MetodoPagosID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynEstadosGenericosId = new GXCombobox();
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
         if ( dynEstadosGenericosId.ItemCount > 0 )
         {
            A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynEstadosGenericosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0));
            AssignProp("", false, dynEstadosGenericosId_Internalname, "Values", dynEstadosGenericosId.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMetodoPagosID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMetodoPagosID_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMetodoPagosID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A128MetodoPagosID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMetodoPagosID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMetodoPagosID_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_MetodoPagos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMetodoPagosNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMetodoPagosNombre_Internalname, context.GetMessage( "Metodo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMetodoPagosNombre_Internalname, StringUtil.RTrim( A129MetodoPagosNombre), StringUtil.RTrim( context.localUtil.Format( A129MetodoPagosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMetodoPagosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMetodoPagosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MetodoPagos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgMetodoPagosLogo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Logo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A213MetodoPagosLogo_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A213MetodoPagosLogo))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000MetodoPagosLogo_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A213MetodoPagosLogo)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A213MetodoPagosLogo)) ? A40000MetodoPagosLogo_GXI : context.PathToRelativeUrl( A213MetodoPagosLogo));
         GxWebStd.gx_bitmap( context, imgMetodoPagosLogo_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgMetodoPagosLogo_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", "", "", 0, A213MetodoPagosLogo_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_MetodoPagos.htm");
         AssignProp("", false, imgMetodoPagosLogo_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A213MetodoPagosLogo)) ? A40000MetodoPagosLogo_GXI : context.PathToRelativeUrl( A213MetodoPagosLogo)), true);
         AssignProp("", false, imgMetodoPagosLogo_Internalname, "IsBlob", StringUtil.BoolToStr( A213MetodoPagosLogo_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMetodoPagosCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMetodoPagosCodigo_Internalname, context.GetMessage( "Codigo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtMetodoPagosCodigo_Internalname, A214MetodoPagosCodigo, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", 0, 1, edtMetodoPagosCodigo_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_MetodoPagos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynEstadosGenericosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynEstadosGenericosId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynEstadosGenericosId, dynEstadosGenericosId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0)), 1, dynEstadosGenericosId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynEstadosGenericosId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", true, 0, "HLP_MetodoPagos.htm");
         dynEstadosGenericosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0));
         AssignProp("", false, dynEstadosGenericosId_Internalname, "Values", (string)(dynEstadosGenericosId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_MetodoPagos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_MetodoPagos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_MetodoPagos.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadosTipo_Internalname, StringUtil.RTrim( A107EstadosTipo), StringUtil.RTrim( context.localUtil.Format( A107EstadosTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosTipo_Jsonclick, 0, "Attribute", "", "", "", "", edtEstadosTipo_Visible, edtEstadosTipo_Enabled, 1, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MetodoPagos.htm");
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
         E11102 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z128MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z128MetodoPagosID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z129MetodoPagosNombre = cgiGet( "Z129MetodoPagosNombre");
               Z107EstadosTipo = cgiGet( "Z107EstadosTipo");
               Z108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z108EstadosGenericosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N107EstadosTipo = cgiGet( "N107EstadosTipo");
               N108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N108EstadosGenericosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vMETODOPAGOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV11Insert_EstadosTipo = cgiGet( "vINSERT_ESTADOSTIPO");
               AssignAttri("", false, "AV11Insert_EstadosTipo", AV11Insert_EstadosTipo);
               AV12Insert_EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_ESTADOSGENERICOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_EstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV12Insert_EstadosGenericosId), 5, 0));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A40000MetodoPagosLogo_GXI = cgiGet( "METODOPAGOSLOGO_GXI");
               A109EstadosGenericosNombre = cgiGet( "ESTADOSGENERICOSNOMBRE");
               AV23Pgmname = cgiGet( "vPGMNAME");
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtMetodoPagosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMetodoPagosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "METODOPAGOSID");
                  AnyError = 1;
                  GX_FocusControl = edtMetodoPagosID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A128MetodoPagosID = 0;
                  AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
               }
               else
               {
                  A128MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMetodoPagosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
               }
               A129MetodoPagosNombre = cgiGet( edtMetodoPagosNombre_Internalname);
               AssignAttri("", false, "A129MetodoPagosNombre", A129MetodoPagosNombre);
               A213MetodoPagosLogo = cgiGet( imgMetodoPagosLogo_Internalname);
               AssignAttri("", false, "A213MetodoPagosLogo", A213MetodoPagosLogo);
               A214MetodoPagosCodigo = cgiGet( edtMetodoPagosCodigo_Internalname);
               AssignAttri("", false, "A214MetodoPagosCodigo", A214MetodoPagosCodigo);
               dynEstadosGenericosId.CurrentValue = cgiGet( dynEstadosGenericosId_Internalname);
               A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynEstadosGenericosId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
               A107EstadosTipo = cgiGet( edtEstadosTipo_Internalname);
               AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgMetodoPagosLogo_Internalname, ref  A213MetodoPagosLogo, ref  A40000MetodoPagosLogo_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"MetodoPagos");
               forbiddenHiddens.Add("Insert_EstadosTipo", StringUtil.RTrim( context.localUtil.Format( AV11Insert_EstadosTipo, "")));
               forbiddenHiddens.Add("Insert_EstadosGenericosId", context.localUtil.Format( (decimal)(AV12Insert_EstadosGenericosId), "ZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A128MetodoPagosID != Z128MetodoPagosID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("metodopagos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A128MetodoPagosID = (long)(Math.Round(NumberUtil.Val( GetPar( "MetodoPagosID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
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
                     sMode41 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode41;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound41 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_100( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "METODOPAGOSID");
                        AnyError = 1;
                        GX_FocusControl = edtMetodoPagosID_Internalname;
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
                           E11102 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12102 ();
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
            E12102 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1041( ) ;
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
            DisableAttributes1041( ) ;
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

      protected void CONFIRM_100( )
      {
         BeforeValidate1041( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1041( ) ;
            }
            else
            {
               CheckExtendedTable1041( ) ;
               CloseExtendedTableCursors1041( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption100( )
      {
      }

      protected void E11102( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV14WWPContext) ;
         AV8IsAuthorized = true;
         AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMetodoPagos_Insert", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMetodoPagos_Update", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMetodoPagos_Delete", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV23Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV23Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV24GXV1 = 1;
            AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            while ( AV24GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV24GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "EstadosTipo") == 0 )
               {
                  AV11Insert_EstadosTipo = AV13TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV11Insert_EstadosTipo", AV11Insert_EstadosTipo);
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "EstadosGenericosId") == 0 )
               {
                  AV12Insert_EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_EstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV12Insert_EstadosGenericosId), 5, 0));
               }
               AV24GXV1 = (int)(AV24GXV1+1);
               AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            }
         }
         edtEstadosTipo_Visible = 0;
         AssignProp("", false, edtEstadosTipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Visible), 5, 0), true);
      }

      protected void E12102( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("metodopagosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1041( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z129MetodoPagosNombre = T00103_A129MetodoPagosNombre[0];
               Z107EstadosTipo = T00103_A107EstadosTipo[0];
               Z108EstadosGenericosId = T00103_A108EstadosGenericosId[0];
            }
            else
            {
               Z129MetodoPagosNombre = A129MetodoPagosNombre;
               Z107EstadosTipo = A107EstadosTipo;
               Z108EstadosGenericosId = A108EstadosGenericosId;
            }
         }
         if ( GX_JID == -13 )
         {
            Z128MetodoPagosID = A128MetodoPagosID;
            Z129MetodoPagosNombre = A129MetodoPagosNombre;
            Z213MetodoPagosLogo = A213MetodoPagosLogo;
            Z40000MetodoPagosLogo_GXI = A40000MetodoPagosLogo_GXI;
            Z214MetodoPagosCodigo = A214MetodoPagosCodigo;
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
            Z109EstadosGenericosNombre = A109EstadosGenericosNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7MetodoPagosID) )
         {
            A128MetodoPagosID = AV7MetodoPagosID;
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
         }
         if ( ! (0==AV7MetodoPagosID) )
         {
            edtMetodoPagosID_Enabled = 0;
            AssignProp("", false, edtMetodoPagosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetodoPagosID_Enabled), 5, 0), true);
         }
         else
         {
            edtMetodoPagosID_Enabled = 1;
            AssignProp("", false, edtMetodoPagosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetodoPagosID_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7MetodoPagosID) )
         {
            edtMetodoPagosID_Enabled = 0;
            AssignProp("", false, edtMetodoPagosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetodoPagosID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_EstadosTipo)) )
         {
            edtEstadosTipo_Enabled = 0;
            AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
         }
         else
         {
            edtEstadosTipo_Enabled = 1;
            AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_EstadosGenericosId) )
         {
            dynEstadosGenericosId.Enabled = 0;
            AssignProp("", false, dynEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadosGenericosId.Enabled), 5, 0), true);
         }
         else
         {
            dynEstadosGenericosId.Enabled = 1;
            AssignProp("", false, dynEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadosGenericosId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_EstadosTipo)) )
         {
            A107EstadosTipo = AV11Insert_EstadosTipo;
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
         }
         else
         {
            A107EstadosTipo = context.GetMessage( context.GetMessage( "STS", ""), "");
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_EstadosGenericosId) )
         {
            A108EstadosGenericosId = AV12Insert_EstadosGenericosId;
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A108EstadosGenericosId) && ( Gx_BScreen == 0 ) )
            {
               A108EstadosGenericosId = 1;
               AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV23Pgmname = "MetodoPagos";
            AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
            GXAESTADOSGENERICOSID_html1041( A107EstadosTipo) ;
            /* Using cursor T00104 */
            pr_default.execute(2, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            A109EstadosGenericosNombre = T00104_A109EstadosGenericosNombre[0];
            pr_default.close(2);
         }
      }

      protected void Load1041( )
      {
         /* Using cursor T00105 */
         pr_default.execute(3, new Object[] {A128MetodoPagosID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound41 = 1;
            A129MetodoPagosNombre = T00105_A129MetodoPagosNombre[0];
            AssignAttri("", false, "A129MetodoPagosNombre", A129MetodoPagosNombre);
            A40000MetodoPagosLogo_GXI = T00105_A40000MetodoPagosLogo_GXI[0];
            AssignProp("", false, imgMetodoPagosLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A213MetodoPagosLogo)) ? A40000MetodoPagosLogo_GXI : context.convertURL( context.PathToRelativeUrl( A213MetodoPagosLogo))), true);
            AssignProp("", false, imgMetodoPagosLogo_Internalname, "SrcSet", context.GetImageSrcSet( A213MetodoPagosLogo), true);
            A214MetodoPagosCodigo = T00105_A214MetodoPagosCodigo[0];
            AssignAttri("", false, "A214MetodoPagosCodigo", A214MetodoPagosCodigo);
            A109EstadosGenericosNombre = T00105_A109EstadosGenericosNombre[0];
            A107EstadosTipo = T00105_A107EstadosTipo[0];
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
            A108EstadosGenericosId = T00105_A108EstadosGenericosId[0];
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            A213MetodoPagosLogo = T00105_A213MetodoPagosLogo[0];
            AssignAttri("", false, "A213MetodoPagosLogo", A213MetodoPagosLogo);
            AssignProp("", false, imgMetodoPagosLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A213MetodoPagosLogo)) ? A40000MetodoPagosLogo_GXI : context.convertURL( context.PathToRelativeUrl( A213MetodoPagosLogo))), true);
            AssignProp("", false, imgMetodoPagosLogo_Internalname, "SrcSet", context.GetImageSrcSet( A213MetodoPagosLogo), true);
            ZM1041( -13) ;
         }
         pr_default.close(3);
         OnLoadActions1041( ) ;
      }

      protected void OnLoadActions1041( )
      {
         AV23Pgmname = "MetodoPagos";
         AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
         GXAESTADOSGENERICOSID_html1041( A107EstadosTipo) ;
      }

      protected void CheckExtendedTable1041( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV23Pgmname = "MetodoPagos";
         AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
         /* Using cursor T00104 */
         pr_default.execute(2, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSGENERICOSID");
            AnyError = 1;
            GX_FocusControl = edtEstadosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A109EstadosGenericosNombre = T00104_A109EstadosGenericosNombre[0];
         pr_default.close(2);
         GXAESTADOSGENERICOSID_html1041( A107EstadosTipo) ;
      }

      protected void CloseExtendedTableCursors1041( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( string A107EstadosTipo ,
                                int A108EstadosGenericosId )
      {
         /* Using cursor T00106 */
         pr_default.execute(4, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSGENERICOSID");
            AnyError = 1;
            GX_FocusControl = edtEstadosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A109EstadosGenericosNombre = T00106_A109EstadosGenericosNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A109EstadosGenericosNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1041( )
      {
         /* Using cursor T00107 */
         pr_default.execute(5, new Object[] {A128MetodoPagosID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound41 = 1;
         }
         else
         {
            RcdFound41 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00103 */
         pr_default.execute(1, new Object[] {A128MetodoPagosID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1041( 13) ;
            RcdFound41 = 1;
            A128MetodoPagosID = T00103_A128MetodoPagosID[0];
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
            A129MetodoPagosNombre = T00103_A129MetodoPagosNombre[0];
            AssignAttri("", false, "A129MetodoPagosNombre", A129MetodoPagosNombre);
            A40000MetodoPagosLogo_GXI = T00103_A40000MetodoPagosLogo_GXI[0];
            AssignProp("", false, imgMetodoPagosLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A213MetodoPagosLogo)) ? A40000MetodoPagosLogo_GXI : context.convertURL( context.PathToRelativeUrl( A213MetodoPagosLogo))), true);
            AssignProp("", false, imgMetodoPagosLogo_Internalname, "SrcSet", context.GetImageSrcSet( A213MetodoPagosLogo), true);
            A214MetodoPagosCodigo = T00103_A214MetodoPagosCodigo[0];
            AssignAttri("", false, "A214MetodoPagosCodigo", A214MetodoPagosCodigo);
            A107EstadosTipo = T00103_A107EstadosTipo[0];
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
            A108EstadosGenericosId = T00103_A108EstadosGenericosId[0];
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            A213MetodoPagosLogo = T00103_A213MetodoPagosLogo[0];
            AssignAttri("", false, "A213MetodoPagosLogo", A213MetodoPagosLogo);
            AssignProp("", false, imgMetodoPagosLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A213MetodoPagosLogo)) ? A40000MetodoPagosLogo_GXI : context.convertURL( context.PathToRelativeUrl( A213MetodoPagosLogo))), true);
            AssignProp("", false, imgMetodoPagosLogo_Internalname, "SrcSet", context.GetImageSrcSet( A213MetodoPagosLogo), true);
            Z128MetodoPagosID = A128MetodoPagosID;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1041( ) ;
            if ( AnyError == 1 )
            {
               RcdFound41 = 0;
               InitializeNonKey1041( ) ;
            }
            Gx_mode = sMode41;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound41 = 0;
            InitializeNonKey1041( ) ;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode41;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1041( ) ;
         if ( RcdFound41 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound41 = 0;
         /* Using cursor T00108 */
         pr_default.execute(6, new Object[] {A128MetodoPagosID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00108_A128MetodoPagosID[0] < A128MetodoPagosID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00108_A128MetodoPagosID[0] > A128MetodoPagosID ) ) )
            {
               A128MetodoPagosID = T00108_A128MetodoPagosID[0];
               AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
               RcdFound41 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound41 = 0;
         /* Using cursor T00109 */
         pr_default.execute(7, new Object[] {A128MetodoPagosID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00109_A128MetodoPagosID[0] > A128MetodoPagosID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00109_A128MetodoPagosID[0] < A128MetodoPagosID ) ) )
            {
               A128MetodoPagosID = T00109_A128MetodoPagosID[0];
               AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
               RcdFound41 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1041( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMetodoPagosID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1041( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound41 == 1 )
            {
               if ( A128MetodoPagosID != Z128MetodoPagosID )
               {
                  A128MetodoPagosID = Z128MetodoPagosID;
                  AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "METODOPAGOSID");
                  AnyError = 1;
                  GX_FocusControl = edtMetodoPagosID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMetodoPagosID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1041( ) ;
                  GX_FocusControl = edtMetodoPagosID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A128MetodoPagosID != Z128MetodoPagosID )
               {
                  /* Insert record */
                  GX_FocusControl = edtMetodoPagosID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1041( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "METODOPAGOSID");
                     AnyError = 1;
                     GX_FocusControl = edtMetodoPagosID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMetodoPagosID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1041( ) ;
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
         if ( A128MetodoPagosID != Z128MetodoPagosID )
         {
            A128MetodoPagosID = Z128MetodoPagosID;
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "METODOPAGOSID");
            AnyError = 1;
            GX_FocusControl = edtMetodoPagosID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMetodoPagosID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1041( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00102 */
            pr_default.execute(0, new Object[] {A128MetodoPagosID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MetodoPagos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z129MetodoPagosNombre, T00102_A129MetodoPagosNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z107EstadosTipo, T00102_A107EstadosTipo[0]) != 0 ) || ( Z108EstadosGenericosId != T00102_A108EstadosGenericosId[0] ) )
            {
               if ( StringUtil.StrCmp(Z129MetodoPagosNombre, T00102_A129MetodoPagosNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("metodopagos:[seudo value changed for attri]"+"MetodoPagosNombre");
                  GXUtil.WriteLogRaw("Old: ",Z129MetodoPagosNombre);
                  GXUtil.WriteLogRaw("Current: ",T00102_A129MetodoPagosNombre[0]);
               }
               if ( StringUtil.StrCmp(Z107EstadosTipo, T00102_A107EstadosTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("metodopagos:[seudo value changed for attri]"+"EstadosTipo");
                  GXUtil.WriteLogRaw("Old: ",Z107EstadosTipo);
                  GXUtil.WriteLogRaw("Current: ",T00102_A107EstadosTipo[0]);
               }
               if ( Z108EstadosGenericosId != T00102_A108EstadosGenericosId[0] )
               {
                  GXUtil.WriteLog("metodopagos:[seudo value changed for attri]"+"EstadosGenericosId");
                  GXUtil.WriteLogRaw("Old: ",Z108EstadosGenericosId);
                  GXUtil.WriteLogRaw("Current: ",T00102_A108EstadosGenericosId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"MetodoPagos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1041( )
      {
         BeforeValidate1041( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1041( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1041( 0) ;
            CheckOptimisticConcurrency1041( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1041( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1041( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001010 */
                     pr_default.execute(8, new Object[] {A128MetodoPagosID, A129MetodoPagosNombre, A213MetodoPagosLogo, A40000MetodoPagosLogo_GXI, A214MetodoPagosCodigo, A107EstadosTipo, A108EstadosGenericosId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("MetodoPagos");
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
                           ResetCaption100( ) ;
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
               Load1041( ) ;
            }
            EndLevel1041( ) ;
         }
         CloseExtendedTableCursors1041( ) ;
      }

      protected void Update1041( )
      {
         BeforeValidate1041( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1041( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1041( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1041( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1041( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001011 */
                     pr_default.execute(9, new Object[] {A129MetodoPagosNombre, A214MetodoPagosCodigo, A107EstadosTipo, A108EstadosGenericosId, A128MetodoPagosID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("MetodoPagos");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MetodoPagos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1041( ) ;
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
            EndLevel1041( ) ;
         }
         CloseExtendedTableCursors1041( ) ;
      }

      protected void DeferredUpdate1041( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001012 */
            pr_default.execute(10, new Object[] {A213MetodoPagosLogo, A40000MetodoPagosLogo_GXI, A128MetodoPagosID});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("MetodoPagos");
         }
      }

      protected void delete( )
      {
         BeforeValidate1041( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1041( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1041( ) ;
            AfterConfirm1041( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1041( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001013 */
                  pr_default.execute(11, new Object[] {A128MetodoPagosID});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("MetodoPagos");
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
         sMode41 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1041( ) ;
         Gx_mode = sMode41;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1041( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV23Pgmname = "MetodoPagos";
            AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
            GXAESTADOSGENERICOSID_html1041( A107EstadosTipo) ;
            /* Using cursor T001014 */
            pr_default.execute(12, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            A109EstadosGenericosNombre = T001014_A109EstadosGenericosNombre[0];
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001015 */
            pr_default.execute(13, new Object[] {A128MetodoPagosID});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Historico Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T001016 */
            pr_default.execute(14, new Object[] {A128MetodoPagosID});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel1041( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1041( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(12);
            context.CommitDataStores("metodopagos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues100( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(12);
            context.RollbackDataStores("metodopagos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1041( )
      {
         /* Scan By routine */
         /* Using cursor T001017 */
         pr_default.execute(15);
         RcdFound41 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound41 = 1;
            A128MetodoPagosID = T001017_A128MetodoPagosID[0];
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1041( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound41 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound41 = 1;
            A128MetodoPagosID = T001017_A128MetodoPagosID[0];
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
         }
      }

      protected void ScanEnd1041( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1041( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1041( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1041( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1041( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1041( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1041( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1041( )
      {
         edtMetodoPagosID_Enabled = 0;
         AssignProp("", false, edtMetodoPagosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetodoPagosID_Enabled), 5, 0), true);
         edtMetodoPagosNombre_Enabled = 0;
         AssignProp("", false, edtMetodoPagosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetodoPagosNombre_Enabled), 5, 0), true);
         imgMetodoPagosLogo_Enabled = 0;
         AssignProp("", false, imgMetodoPagosLogo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgMetodoPagosLogo_Enabled), 5, 0), true);
         edtMetodoPagosCodigo_Enabled = 0;
         AssignProp("", false, edtMetodoPagosCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetodoPagosCodigo_Enabled), 5, 0), true);
         dynEstadosGenericosId.Enabled = 0;
         AssignProp("", false, dynEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadosGenericosId.Enabled), 5, 0), true);
         edtEstadosTipo_Enabled = 0;
         AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1041( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues100( )
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
         GXEncryptionTmp = "metodopagos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MetodoPagosID,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("metodopagos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"MetodoPagos");
         forbiddenHiddens.Add("Insert_EstadosTipo", StringUtil.RTrim( context.localUtil.Format( AV11Insert_EstadosTipo, "")));
         forbiddenHiddens.Add("Insert_EstadosGenericosId", context.localUtil.Format( (decimal)(AV12Insert_EstadosGenericosId), "ZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("metodopagos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z128MetodoPagosID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z129MetodoPagosNombre", StringUtil.RTrim( Z129MetodoPagosNombre));
         GxWebStd.gx_hidden_field( context, "Z107EstadosTipo", StringUtil.RTrim( Z107EstadosTipo));
         GxWebStd.gx_hidden_field( context, "Z108EstadosGenericosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N107EstadosTipo", StringUtil.RTrim( A107EstadosTipo));
         GxWebStd.gx_hidden_field( context, "N108EstadosGenericosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vMETODOPAGOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMETODOPAGOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MetodoPagosID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESTADOSTIPO", StringUtil.RTrim( AV11Insert_EstadosTipo));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "METODOPAGOSLOGO_GXI", A40000MetodoPagosLogo_GXI);
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSNOMBRE", StringUtil.RTrim( A109EstadosGenericosNombre));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV23Pgmname));
         GXCCtlgxBlob = "METODOPAGOSLOGO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A213MetodoPagosLogo);
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
         GXEncryptionTmp = "metodopagos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MetodoPagosID,18,0));
         return formatLink("metodopagos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "MetodoPagos" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Metodo Pagos", "") ;
      }

      protected void InitializeNonKey1041( )
      {
         A107EstadosTipo = "";
         AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
         A129MetodoPagosNombre = "";
         AssignAttri("", false, "A129MetodoPagosNombre", A129MetodoPagosNombre);
         A213MetodoPagosLogo = "";
         AssignAttri("", false, "A213MetodoPagosLogo", A213MetodoPagosLogo);
         AssignProp("", false, imgMetodoPagosLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A213MetodoPagosLogo)) ? A40000MetodoPagosLogo_GXI : context.convertURL( context.PathToRelativeUrl( A213MetodoPagosLogo))), true);
         AssignProp("", false, imgMetodoPagosLogo_Internalname, "SrcSet", context.GetImageSrcSet( A213MetodoPagosLogo), true);
         A40000MetodoPagosLogo_GXI = "";
         AssignProp("", false, imgMetodoPagosLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A213MetodoPagosLogo)) ? A40000MetodoPagosLogo_GXI : context.convertURL( context.PathToRelativeUrl( A213MetodoPagosLogo))), true);
         AssignProp("", false, imgMetodoPagosLogo_Internalname, "SrcSet", context.GetImageSrcSet( A213MetodoPagosLogo), true);
         A214MetodoPagosCodigo = "";
         AssignAttri("", false, "A214MetodoPagosCodigo", A214MetodoPagosCodigo);
         A109EstadosGenericosNombre = "";
         AssignAttri("", false, "A109EstadosGenericosNombre", A109EstadosGenericosNombre);
         A108EstadosGenericosId = 1;
         AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
         Z129MetodoPagosNombre = "";
         Z107EstadosTipo = "";
         Z108EstadosGenericosId = 0;
      }

      protected void InitAll1041( )
      {
         A128MetodoPagosID = 0;
         AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
         InitializeNonKey1041( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A108EstadosGenericosId = i108EstadosGenericosId;
         AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021105840", true, true, false);
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
         context.AddJavascriptSource("metodopagos.js", "?202673021105840", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtMetodoPagosID_Internalname = "METODOPAGOSID";
         edtMetodoPagosNombre_Internalname = "METODOPAGOSNOMBRE";
         imgMetodoPagosLogo_Internalname = "METODOPAGOSLOGO";
         edtMetodoPagosCodigo_Internalname = "METODOPAGOSCODIGO";
         dynEstadosGenericosId_Internalname = "ESTADOSGENERICOSID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtEstadosTipo_Internalname = "ESTADOSTIPO";
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
         Form.Caption = context.GetMessage( "Metodo Pagos", "");
         edtEstadosTipo_Jsonclick = "";
         edtEstadosTipo_Enabled = 1;
         edtEstadosTipo_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         dynEstadosGenericosId_Jsonclick = "";
         dynEstadosGenericosId.Enabled = 1;
         edtMetodoPagosCodigo_Enabled = 1;
         imgMetodoPagosLogo_Enabled = 1;
         edtMetodoPagosNombre_Jsonclick = "";
         edtMetodoPagosNombre_Enabled = 1;
         edtMetodoPagosID_Jsonclick = "";
         edtMetodoPagosID_Enabled = 1;
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
         GXAESTADOSGENERICOSID_html1041( A107EstadosTipo) ;
         /* End function dynload_actions */
      }

      protected void GXDLAESTADOSGENERICOSID1041( string A107EstadosTipo )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAESTADOSGENERICOSID_data1041( A107EstadosTipo) ;
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

      protected void GXAESTADOSGENERICOSID_html1041( string A107EstadosTipo )
      {
         int gxdynajaxvalue;
         GXDLAESTADOSGENERICOSID_data1041( A107EstadosTipo) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynEstadosGenericosId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynEstadosGenericosId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 5, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAESTADOSGENERICOSID_data1041( string A107EstadosTipo )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T001018 */
         pr_default.execute(16, new Object[] {A107EstadosTipo});
         while ( (pr_default.getStatus(16) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001018_A108EstadosGenericosId[0]), 5, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T001018_A109EstadosGenericosNombre[0]));
            pr_default.readNext(16);
         }
         pr_default.close(16);
      }

      protected void init_web_controls( )
      {
         dynEstadosGenericosId.Name = "ESTADOSGENERICOSID";
         dynEstadosGenericosId.WebTags = "";
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

      public void Valid_Estadostipo( )
      {
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T001019 */
         pr_default.execute(17, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSGENERICOSID");
            AnyError = 1;
            GX_FocusControl = edtEstadosTipo_Internalname;
         }
         A109EstadosGenericosNombre = T001019_A109EstadosGenericosNombre[0];
         pr_default.close(17);
         GXAESTADOSGENERICOSID_html1041( A107EstadosTipo) ;
         dynload_actions( ) ;
         if ( dynEstadosGenericosId.ItemCount > 0 )
         {
            A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynEstadosGenericosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A109EstadosGenericosNombre", StringUtil.RTrim( A109EstadosGenericosNombre));
         AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", "")));
         dynEstadosGenericosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0));
         AssignProp("", false, dynEstadosGenericosId_Internalname, "Values", dynEstadosGenericosId.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7MetodoPagosID',fld:'vMETODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MetodoPagosID',fld:'vMETODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV11Insert_EstadosTipo',fld:'vINSERT_ESTADOSTIPO',pic:'',type:'char'},{av:'AV12Insert_EstadosGenericosId',fld:'vINSERT_ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]}");
         setEventMetadata("AFTER TRN","{handler:'E12102',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_METODOPAGOSID","{handler:'Valid_Metodopagosid',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("VALID_METODOPAGOSID",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_ESTADOSGENERICOSID","{handler:'Valid_Estadosgenericosid',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("VALID_ESTADOSGENERICOSID",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_ESTADOSTIPO","{handler:'Valid_Estadostipo',iparms:[{av:'A109EstadosGenericosNombre',fld:'ESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("VALID_ESTADOSTIPO",",oparms:[{av:'A109EstadosGenericosNombre',fld:'ESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]}");
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
         pr_default.close(17);
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z129MetodoPagosNombre = "";
         Z107EstadosTipo = "";
         N107EstadosTipo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A107EstadosTipo = "";
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
         A129MetodoPagosNombre = "";
         A213MetodoPagosLogo = "";
         A40000MetodoPagosLogo_GXI = "";
         sImgUrl = "";
         A214MetodoPagosCodigo = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV11Insert_EstadosTipo = "";
         A109EstadosGenericosNombre = "";
         AV23Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode41 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV14WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z213MetodoPagosLogo = "";
         Z40000MetodoPagosLogo_GXI = "";
         Z214MetodoPagosCodigo = "";
         Z109EstadosGenericosNombre = "";
         T00104_A109EstadosGenericosNombre = new string[] {""} ;
         T00105_A128MetodoPagosID = new long[1] ;
         T00105_A129MetodoPagosNombre = new string[] {""} ;
         T00105_A40000MetodoPagosLogo_GXI = new string[] {""} ;
         T00105_A214MetodoPagosCodigo = new string[] {""} ;
         T00105_A109EstadosGenericosNombre = new string[] {""} ;
         T00105_A107EstadosTipo = new string[] {""} ;
         T00105_A108EstadosGenericosId = new int[1] ;
         T00105_A213MetodoPagosLogo = new string[] {""} ;
         T00106_A109EstadosGenericosNombre = new string[] {""} ;
         T00107_A128MetodoPagosID = new long[1] ;
         T00103_A128MetodoPagosID = new long[1] ;
         T00103_A129MetodoPagosNombre = new string[] {""} ;
         T00103_A40000MetodoPagosLogo_GXI = new string[] {""} ;
         T00103_A214MetodoPagosCodigo = new string[] {""} ;
         T00103_A107EstadosTipo = new string[] {""} ;
         T00103_A108EstadosGenericosId = new int[1] ;
         T00103_A213MetodoPagosLogo = new string[] {""} ;
         T00108_A128MetodoPagosID = new long[1] ;
         T00109_A128MetodoPagosID = new long[1] ;
         T00102_A128MetodoPagosID = new long[1] ;
         T00102_A129MetodoPagosNombre = new string[] {""} ;
         T00102_A40000MetodoPagosLogo_GXI = new string[] {""} ;
         T00102_A214MetodoPagosCodigo = new string[] {""} ;
         T00102_A107EstadosTipo = new string[] {""} ;
         T00102_A108EstadosGenericosId = new int[1] ;
         T00102_A213MetodoPagosLogo = new string[] {""} ;
         T001014_A109EstadosGenericosNombre = new string[] {""} ;
         T001015_A153HistoricoSolicitudesID = new long[1] ;
         T001016_A127SolicitudesID = new long[1] ;
         T001017_A128MetodoPagosID = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T001018_A107EstadosTipo = new string[] {""} ;
         T001018_A108EstadosGenericosId = new int[1] ;
         T001018_A109EstadosGenericosNombre = new string[] {""} ;
         T001019_A109EstadosGenericosNombre = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.metodopagos__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.metodopagos__default(),
            new Object[][] {
                new Object[] {
               T00102_A128MetodoPagosID, T00102_A129MetodoPagosNombre, T00102_A40000MetodoPagosLogo_GXI, T00102_A214MetodoPagosCodigo, T00102_A107EstadosTipo, T00102_A108EstadosGenericosId, T00102_A213MetodoPagosLogo
               }
               , new Object[] {
               T00103_A128MetodoPagosID, T00103_A129MetodoPagosNombre, T00103_A40000MetodoPagosLogo_GXI, T00103_A214MetodoPagosCodigo, T00103_A107EstadosTipo, T00103_A108EstadosGenericosId, T00103_A213MetodoPagosLogo
               }
               , new Object[] {
               T00104_A109EstadosGenericosNombre
               }
               , new Object[] {
               T00105_A128MetodoPagosID, T00105_A129MetodoPagosNombre, T00105_A40000MetodoPagosLogo_GXI, T00105_A214MetodoPagosCodigo, T00105_A109EstadosGenericosNombre, T00105_A107EstadosTipo, T00105_A108EstadosGenericosId, T00105_A213MetodoPagosLogo
               }
               , new Object[] {
               T00106_A109EstadosGenericosNombre
               }
               , new Object[] {
               T00107_A128MetodoPagosID
               }
               , new Object[] {
               T00108_A128MetodoPagosID
               }
               , new Object[] {
               T00109_A128MetodoPagosID
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
               T001014_A109EstadosGenericosNombre
               }
               , new Object[] {
               T001015_A153HistoricoSolicitudesID
               }
               , new Object[] {
               T001016_A127SolicitudesID
               }
               , new Object[] {
               T001017_A128MetodoPagosID
               }
               , new Object[] {
               T001018_A107EstadosTipo, T001018_A108EstadosGenericosId, T001018_A109EstadosGenericosNombre
               }
               , new Object[] {
               T001019_A109EstadosGenericosNombre
               }
            }
         );
         AV23Pgmname = "MetodoPagos";
         Z108EstadosGenericosId = 1;
         N108EstadosGenericosId = 1;
         i108EstadosGenericosId = 1;
         A108EstadosGenericosId = 1;
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound41 ;
      private short gxajaxcallmode ;
      private int Z108EstadosGenericosId ;
      private int N108EstadosGenericosId ;
      private int A108EstadosGenericosId ;
      private int trnEnded ;
      private int edtMetodoPagosID_Enabled ;
      private int edtMetodoPagosNombre_Enabled ;
      private int imgMetodoPagosLogo_Enabled ;
      private int edtMetodoPagosCodigo_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtEstadosTipo_Visible ;
      private int edtEstadosTipo_Enabled ;
      private int AV12Insert_EstadosGenericosId ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV24GXV1 ;
      private int i108EstadosGenericosId ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private long wcpOAV7MetodoPagosID ;
      private long Z128MetodoPagosID ;
      private long AV7MetodoPagosID ;
      private long A128MetodoPagosID ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z129MetodoPagosNombre ;
      private string Z107EstadosTipo ;
      private string N107EstadosTipo ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A107EstadosTipo ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMetodoPagosID_Internalname ;
      private string dynEstadosGenericosId_Internalname ;
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
      private string edtMetodoPagosID_Jsonclick ;
      private string edtMetodoPagosNombre_Internalname ;
      private string A129MetodoPagosNombre ;
      private string edtMetodoPagosNombre_Jsonclick ;
      private string imgMetodoPagosLogo_Internalname ;
      private string sImgUrl ;
      private string edtMetodoPagosCodigo_Internalname ;
      private string dynEstadosGenericosId_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtEstadosTipo_Internalname ;
      private string edtEstadosTipo_Jsonclick ;
      private string AV11Insert_EstadosTipo ;
      private string A109EstadosGenericosNombre ;
      private string AV23Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode41 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string Z109EstadosGenericosNombre ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A213MetodoPagosLogo_IsBlob ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool gxdyncontrolsrefreshing ;
      private string A214MetodoPagosCodigo ;
      private string Z214MetodoPagosCodigo ;
      private string A40000MetodoPagosLogo_GXI ;
      private string Z40000MetodoPagosLogo_GXI ;
      private string A213MetodoPagosLogo ;
      private string Z213MetodoPagosLogo ;
      private IGxSession AV10WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynEstadosGenericosId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV14WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00104_A109EstadosGenericosNombre ;
      private long[] T00105_A128MetodoPagosID ;
      private string[] T00105_A129MetodoPagosNombre ;
      private string[] T00105_A40000MetodoPagosLogo_GXI ;
      private string[] T00105_A214MetodoPagosCodigo ;
      private string[] T00105_A109EstadosGenericosNombre ;
      private string[] T00105_A107EstadosTipo ;
      private int[] T00105_A108EstadosGenericosId ;
      private string[] T00105_A213MetodoPagosLogo ;
      private string[] T00106_A109EstadosGenericosNombre ;
      private long[] T00107_A128MetodoPagosID ;
      private long[] T00103_A128MetodoPagosID ;
      private string[] T00103_A129MetodoPagosNombre ;
      private string[] T00103_A40000MetodoPagosLogo_GXI ;
      private string[] T00103_A214MetodoPagosCodigo ;
      private string[] T00103_A107EstadosTipo ;
      private int[] T00103_A108EstadosGenericosId ;
      private string[] T00103_A213MetodoPagosLogo ;
      private long[] T00108_A128MetodoPagosID ;
      private long[] T00109_A128MetodoPagosID ;
      private long[] T00102_A128MetodoPagosID ;
      private string[] T00102_A129MetodoPagosNombre ;
      private string[] T00102_A40000MetodoPagosLogo_GXI ;
      private string[] T00102_A214MetodoPagosCodigo ;
      private string[] T00102_A107EstadosTipo ;
      private int[] T00102_A108EstadosGenericosId ;
      private string[] T00102_A213MetodoPagosLogo ;
      private string[] T001014_A109EstadosGenericosNombre ;
      private long[] T001015_A153HistoricoSolicitudesID ;
      private long[] T001016_A127SolicitudesID ;
      private long[] T001017_A128MetodoPagosID ;
      private string[] T001018_A107EstadosTipo ;
      private int[] T001018_A108EstadosGenericosId ;
      private string[] T001018_A109EstadosGenericosNombre ;
      private string[] T001019_A109EstadosGenericosNombre ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class metodopagos__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class metodopagos__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00102;
        prmT00102 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT00103;
        prmT00103 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT00104;
        prmT00104 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT00105;
        prmT00105 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT00106;
        prmT00106 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT00107;
        prmT00107 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT00108;
        prmT00108 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT00109;
        prmT00109 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT001010;
        prmT001010 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0) ,
        new ParDef("@MetodoPagosNombre",GXType.NChar,80,0) ,
        new ParDef("@MetodoPagosLogo",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@MetodoPagosLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="MetodoPagos", Fld="MetodoPagosLogo"} ,
        new ParDef("@MetodoPagosCodigo",GXType.NVarChar,2097152,0) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001011;
        prmT001011 = new Object[] {
        new ParDef("@MetodoPagosNombre",GXType.NChar,80,0) ,
        new ParDef("@MetodoPagosCodigo",GXType.NVarChar,2097152,0) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0) ,
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT001012;
        prmT001012 = new Object[] {
        new ParDef("@MetodoPagosLogo",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@MetodoPagosLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="MetodoPagos", Fld="MetodoPagosLogo"} ,
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT001013;
        prmT001013 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT001014;
        prmT001014 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001015;
        prmT001015 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT001016;
        prmT001016 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT001017;
        prmT001017 = new Object[] {
        };
        Object[] prmT001018;
        prmT001018 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT001019;
        prmT001019 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00102", "SELECT [MetodoPagosID], [MetodoPagosNombre], [MetodoPagosLogo_GXI], [MetodoPagosCodigo], [EstadosTipo], [EstadosGenericosId], [MetodoPagosLogo] FROM [MetodoPagos] WITH (UPDLOCK) WHERE [MetodoPagosID] = @MetodoPagosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00102,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00103", "SELECT [MetodoPagosID], [MetodoPagosNombre], [MetodoPagosLogo_GXI], [MetodoPagosCodigo], [EstadosTipo], [EstadosGenericosId], [MetodoPagosLogo] FROM [MetodoPagos] WHERE [MetodoPagosID] = @MetodoPagosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00103,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00104", "SELECT [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00104,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00105", "SELECT TM1.[MetodoPagosID], TM1.[MetodoPagosNombre], TM1.[MetodoPagosLogo_GXI], TM1.[MetodoPagosCodigo], T2.[EstadosGenericosNombre], TM1.[EstadosTipo], TM1.[EstadosGenericosId], TM1.[MetodoPagosLogo] FROM ([MetodoPagos] TM1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = TM1.[EstadosTipo] AND T2.[EstadosGenericosId] = TM1.[EstadosGenericosId]) WHERE TM1.[MetodoPagosID] = @MetodoPagosID ORDER BY TM1.[MetodoPagosID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00105,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00106", "SELECT [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00106,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00107", "SELECT [MetodoPagosID] FROM [MetodoPagos] WHERE [MetodoPagosID] = @MetodoPagosID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00107,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00108", "SELECT TOP 1 [MetodoPagosID] FROM [MetodoPagos] WHERE ( [MetodoPagosID] > @MetodoPagosID) ORDER BY [MetodoPagosID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00108,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00109", "SELECT TOP 1 [MetodoPagosID] FROM [MetodoPagos] WHERE ( [MetodoPagosID] < @MetodoPagosID) ORDER BY [MetodoPagosID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00109,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001010", "INSERT INTO [MetodoPagos]([MetodoPagosID], [MetodoPagosNombre], [MetodoPagosLogo], [MetodoPagosLogo_GXI], [MetodoPagosCodigo], [EstadosTipo], [EstadosGenericosId]) VALUES(@MetodoPagosID, @MetodoPagosNombre, @MetodoPagosLogo, @MetodoPagosLogo_GXI, @MetodoPagosCodigo, @EstadosTipo, @EstadosGenericosId)", GxErrorMask.GX_NOMASK,prmT001010)
           ,new CursorDef("T001011", "UPDATE [MetodoPagos] SET [MetodoPagosNombre]=@MetodoPagosNombre, [MetodoPagosCodigo]=@MetodoPagosCodigo, [EstadosTipo]=@EstadosTipo, [EstadosGenericosId]=@EstadosGenericosId  WHERE [MetodoPagosID] = @MetodoPagosID", GxErrorMask.GX_NOMASK,prmT001011)
           ,new CursorDef("T001012", "UPDATE [MetodoPagos] SET [MetodoPagosLogo]=@MetodoPagosLogo, [MetodoPagosLogo_GXI]=@MetodoPagosLogo_GXI  WHERE [MetodoPagosID] = @MetodoPagosID", GxErrorMask.GX_NOMASK,prmT001012)
           ,new CursorDef("T001013", "DELETE FROM [MetodoPagos]  WHERE [MetodoPagosID] = @MetodoPagosID", GxErrorMask.GX_NOMASK,prmT001013)
           ,new CursorDef("T001014", "SELECT [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001014,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001015", "SELECT TOP 1 [HistoricoSolicitudesID] FROM [HistoricoSolicitudes] WHERE [MetodoPagosID] = @MetodoPagosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001015,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001016", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [MetodoPagosID] = @MetodoPagosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001016,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001017", "SELECT [MetodoPagosID] FROM [MetodoPagos] ORDER BY [MetodoPagosID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001017,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001018", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo ORDER BY [EstadosGenericosNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001018,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001019", "SELECT [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001019,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
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
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
     }
  }

}

}
