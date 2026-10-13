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
   public class departamento : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A116PaisID = GetPar( "PaisID");
            AssignAttri("", false, "A116PaisID", A116PaisID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A116PaisID) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_municipio") == 0 )
         {
            gxnrGridlevel_municipio_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "departamento.aspx")), "departamento.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "departamento.aspx")))) ;
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
                  AV7DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7DepartamentoId", StringUtil.LTrimStr( (decimal)(AV7DepartamentoId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vDEPARTAMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Departamento", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_municipio_newrow_invoke( )
      {
         nRC_GXsfl_48 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_48"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_48_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_48_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_48_idx = GetPar( "sGXsfl_48_idx");
         A185DepartamentoAutEnuMuni = (short)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoAutEnuMuni"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_municipio_newrow( ) ;
         /* End function gxnrGridlevel_municipio_newrow_invoke */
      }

      public departamento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public departamento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_DepartamentoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7DepartamentoId = aP1_DepartamentoId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbDepartamentoEstado = new GXCombobox();
         cmbDepartamentoMunicipioEstado = new GXCombobox();
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
         if ( cmbDepartamentoEstado.ItemCount > 0 )
         {
            A907DepartamentoEstado = cmbDepartamentoEstado.getValidValue(A907DepartamentoEstado);
            n907DepartamentoEstado = false;
            AssignAttri("", false, "A907DepartamentoEstado", A907DepartamentoEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDepartamentoEstado.CurrentValue = StringUtil.RTrim( A907DepartamentoEstado);
            AssignProp("", false, cmbDepartamentoEstado_Internalname, "Values", cmbDepartamentoEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDepartamentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDepartamentoId_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDepartamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtDepartamentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDepartamentoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDepartamentoId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Departamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisID_Internalname, context.GetMessage( "Pais", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.RTrim( A116PaisID), StringUtil.RTrim( context.localUtil.Format( A116PaisID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPaisID_Enabled, 1, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Departamento.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_116_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_116_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_116_Internalname, sImgUrl, imgprompt_116_Link, "", "", context.GetTheme( ), imgprompt_116_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Departamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDepartamentoDepartamento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDepartamentoDepartamento_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDepartamentoDepartamento_Internalname, StringUtil.RTrim( A113DepartamentoDepartamento), StringUtil.RTrim( context.localUtil.Format( A113DepartamentoDepartamento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDepartamentoDepartamento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDepartamentoDepartamento_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Departamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDepartamentoAutEnuMuni_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDepartamentoAutEnuMuni_Internalname, context.GetMessage( "Enu Muni", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDepartamentoAutEnuMuni_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A185DepartamentoAutEnuMuni), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtDepartamentoAutEnuMuni_Enabled!=0) ? context.localUtil.Format( (decimal)(A185DepartamentoAutEnuMuni), "ZZZ9") : context.localUtil.Format( (decimal)(A185DepartamentoAutEnuMuni), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDepartamentoAutEnuMuni_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDepartamentoAutEnuMuni_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Departamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbDepartamentoEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbDepartamentoEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbDepartamentoEstado, cmbDepartamentoEstado_Internalname, StringUtil.RTrim( A907DepartamentoEstado), 1, cmbDepartamentoEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbDepartamentoEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", true, 0, "HLP_Departamento.htm");
         cmbDepartamentoEstado.CurrentValue = StringUtil.RTrim( A907DepartamentoEstado);
         AssignProp("", false, cmbDepartamentoEstado_Internalname, "Values", (string)(cmbDepartamentoEstado.ToJavascriptSource()), true);
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
         GxWebStd.gx_div_start( context, divTableleaflevel_municipio_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_municipio( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Departamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Departamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Departamento.htm");
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

      protected void gxdraw_Gridlevel_municipio( )
      {
         /*  Grid Control  */
         StartGridControl48( ) ;
         nGXsfl_48_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount22 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_22 = 1;
               ScanStart0J22( ) ;
               while ( RcdFound22 != 0 )
               {
                  init_level_properties22( ) ;
                  getByPrimaryKey0J22( ) ;
                  AddRow0J22( ) ;
                  ScanNext0J22( ) ;
               }
               ScanEnd0J22( ) ;
               nBlankRcdCount22 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B185DepartamentoAutEnuMuni = A185DepartamentoAutEnuMuni;
            AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
            standaloneNotModal0J22( ) ;
            standaloneModal0J22( ) ;
            sMode22 = Gx_mode;
            while ( nGXsfl_48_idx < nRC_GXsfl_48 )
            {
               bGXsfl_48_Refreshing = true;
               ReadRow0J22( ) ;
               edtDepartamentoMunicipioId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_48_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtDepartamentoMunicipioNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOMUNICIPIONOMBRE_"+sGXsfl_48_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtDepartamentoMunicipioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioNombre_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtDepartamentoMunicipioCosto_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOMUNICIPIOCOSTO_"+sGXsfl_48_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtDepartamentoMunicipioCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioCosto_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               cmbDepartamentoMunicipioEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOMUNICIPIOESTADO_"+sGXsfl_48_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbDepartamentoMunicipioEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbDepartamentoMunicipioEstado.Enabled), 5, 0), !bGXsfl_48_Refreshing);
               if ( ( nRcdExists_22 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0J22( ) ;
               }
               SendRow0J22( ) ;
               bGXsfl_48_Refreshing = false;
            }
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A185DepartamentoAutEnuMuni = B185DepartamentoAutEnuMuni;
            AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount22 = 5;
            nRcdExists_22 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0J22( ) ;
               while ( RcdFound22 != 0 )
               {
                  sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_4822( ) ;
                  init_level_properties22( ) ;
                  standaloneNotModal0J22( ) ;
                  getByPrimaryKey0J22( ) ;
                  standaloneModal0J22( ) ;
                  AddRow0J22( ) ;
                  ScanNext0J22( ) ;
               }
               ScanEnd0J22( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode22 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx+1), 4, 0), 4, "0");
            SubsflControlProps_4822( ) ;
            InitAll0J22( ) ;
            init_level_properties22( ) ;
            B185DepartamentoAutEnuMuni = A185DepartamentoAutEnuMuni;
            AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
            nRcdExists_22 = 0;
            nIsMod_22 = 0;
            nRcdDeleted_22 = 0;
            nBlankRcdCount22 = (short)(nBlankRcdUsr22+nBlankRcdCount22);
            fRowAdded = 0;
            while ( nBlankRcdCount22 > 0 )
            {
               standaloneNotModal0J22( ) ;
               standaloneModal0J22( ) ;
               AddRow0J22( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtDepartamentoMunicipioNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount22 = (short)(nBlankRcdCount22-1);
            }
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A185DepartamentoAutEnuMuni = B185DepartamentoAutEnuMuni;
            AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_municipioContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_municipio", Gridlevel_municipioContainer, subGridlevel_municipio_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_municipioContainerData", Gridlevel_municipioContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_municipioContainerData"+"V", Gridlevel_municipioContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_municipioContainerData"+"V"+"\" value='"+Gridlevel_municipioContainer.GridValuesHidden()+"'/>") ;
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
         E110J2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z112DepartamentoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z113DepartamentoDepartamento = cgiGet( "Z113DepartamentoDepartamento");
               Z907DepartamentoEstado = cgiGet( "Z907DepartamentoEstado");
               n907DepartamentoEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A907DepartamentoEstado)) ? true : false);
               Z185DepartamentoAutEnuMuni = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z185DepartamentoAutEnuMuni"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z966DepartamentoIntegracionEcommer = cgiGet( "Z966DepartamentoIntegracionEcommer");
               n966DepartamentoIntegracionEcommer = (String.IsNullOrEmpty(StringUtil.RTrim( A966DepartamentoIntegracionEcommer)) ? true : false);
               Z116PaisID = cgiGet( "Z116PaisID");
               A966DepartamentoIntegracionEcommer = cgiGet( "Z966DepartamentoIntegracionEcommer");
               n966DepartamentoIntegracionEcommer = false;
               n966DepartamentoIntegracionEcommer = (String.IsNullOrEmpty(StringUtil.RTrim( A966DepartamentoIntegracionEcommer)) ? true : false);
               O185DepartamentoAutEnuMuni = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O185DepartamentoAutEnuMuni"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_48 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_48"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N116PaisID = cgiGet( "N116PaisID");
               AV7DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vDEPARTAMENTOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV11Insert_PaisID = cgiGet( "vINSERT_PAISID");
               AssignAttri("", false, "AV11Insert_PaisID", AV11Insert_PaisID);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A966DepartamentoIntegracionEcommer = cgiGet( "DEPARTAMENTOINTEGRACIONECOMMER");
               n966DepartamentoIntegracionEcommer = (String.IsNullOrEmpty(StringUtil.RTrim( A966DepartamentoIntegracionEcommer)) ? true : false);
               AV22Pgmname = cgiGet( "vPGMNAME");
               A967DepartamentoMunicipioIntegraci = cgiGet( "DEPARTAMENTOMUNICIPIOINTEGRACI");
               n967DepartamentoMunicipioIntegraci = false;
               n967DepartamentoMunicipioIntegraci = (String.IsNullOrEmpty(StringUtil.RTrim( A967DepartamentoMunicipioIntegraci)) ? true : false);
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
               A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
               A116PaisID = cgiGet( edtPaisID_Internalname);
               AssignAttri("", false, "A116PaisID", A116PaisID);
               A113DepartamentoDepartamento = cgiGet( edtDepartamentoDepartamento_Internalname);
               AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
               A185DepartamentoAutEnuMuni = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoAutEnuMuni_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
               cmbDepartamentoEstado.Name = cmbDepartamentoEstado_Internalname;
               cmbDepartamentoEstado.CurrentValue = cgiGet( cmbDepartamentoEstado_Internalname);
               A907DepartamentoEstado = cgiGet( cmbDepartamentoEstado_Internalname);
               n907DepartamentoEstado = false;
               AssignAttri("", false, "A907DepartamentoEstado", A907DepartamentoEstado);
               n907DepartamentoEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A907DepartamentoEstado)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Departamento");
               A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
               forbiddenHiddens.Add("DepartamentoId", context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_PaisID", StringUtil.RTrim( context.localUtil.Format( AV11Insert_PaisID, "")));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("DepartamentoIntegracionEcommer", StringUtil.RTrim( context.localUtil.Format( A966DepartamentoIntegracionEcommer, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A112DepartamentoId != Z112DepartamentoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("departamento:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
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
                     sMode21 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode21;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound21 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0J0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "DEPARTAMENTOID");
                        AnyError = 1;
                        GX_FocusControl = edtDepartamentoId_Internalname;
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
                           E110J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120J2 ();
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
            E120J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0J21( ) ;
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
            DisableAttributes0J21( ) ;
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

      protected void CONFIRM_0J0( )
      {
         BeforeValidate0J21( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0J21( ) ;
            }
            else
            {
               CheckExtendedTable0J21( ) ;
               CloseExtendedTableCursors0J21( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode21 = Gx_mode;
            CONFIRM_0J22( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode21;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0J22( )
      {
         s185DepartamentoAutEnuMuni = O185DepartamentoAutEnuMuni;
         AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
         nGXsfl_48_idx = 0;
         while ( nGXsfl_48_idx < nRC_GXsfl_48 )
         {
            ReadRow0J22( ) ;
            if ( ( nRcdExists_22 != 0 ) || ( nIsMod_22 != 0 ) )
            {
               GetKey0J22( ) ;
               if ( ( nRcdExists_22 == 0 ) && ( nRcdDeleted_22 == 0 ) )
               {
                  if ( RcdFound22 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0J22( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0J22( ) ;
                        CloseExtendedTableCursors0J22( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O185DepartamentoAutEnuMuni = A185DepartamentoAutEnuMuni;
                        AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
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
                  if ( RcdFound22 != 0 )
                  {
                     if ( nRcdDeleted_22 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0J22( ) ;
                        Load0J22( ) ;
                        BeforeValidate0J22( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0J22( ) ;
                           O185DepartamentoAutEnuMuni = A185DepartamentoAutEnuMuni;
                           AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_22 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0J22( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0J22( ) ;
                              CloseExtendedTableCursors0J22( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O185DepartamentoAutEnuMuni = A185DepartamentoAutEnuMuni;
                              AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_22 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtDepartamentoMunicipioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtDepartamentoMunicipioNombre_Internalname, StringUtil.RTrim( A115DepartamentoMunicipioNombre)) ;
            ChangePostValue( edtDepartamentoMunicipioCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A863DepartamentoMunicipioCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbDepartamentoMunicipioEstado_Internalname, StringUtil.RTrim( A908DepartamentoMunicipioEstado)) ;
            ChangePostValue( "ZT_"+"Z114DepartamentoMunicipioId_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z908DepartamentoMunicipioEstado_"+sGXsfl_48_idx, StringUtil.RTrim( Z908DepartamentoMunicipioEstado)) ;
            ChangePostValue( "ZT_"+"Z115DepartamentoMunicipioNombre_"+sGXsfl_48_idx, StringUtil.RTrim( Z115DepartamentoMunicipioNombre)) ;
            ChangePostValue( "ZT_"+"Z863DepartamentoMunicipioCosto_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( Z863DepartamentoMunicipioCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z967DepartamentoMunicipioIntegraci_"+sGXsfl_48_idx, StringUtil.RTrim( Z967DepartamentoMunicipioIntegraci)) ;
            ChangePostValue( "nRcdDeleted_22_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_22), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_22_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_22), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_22_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_22), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_22 != 0 )
            {
               ChangePostValue( "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DEPARTAMENTOMUNICIPIONOMBRE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DEPARTAMENTOMUNICIPIOCOSTO_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioCosto_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DEPARTAMENTOMUNICIPIOESTADO_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbDepartamentoMunicipioEstado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         O185DepartamentoAutEnuMuni = s185DepartamentoAutEnuMuni;
         AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0J0( )
      {
      }

      protected void E110J2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV13WWPContext) ;
         AV8IsAuthorized = true;
         AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWDepartamento_Insert", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWDepartamento_Update", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWDepartamento_Delete", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV22Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV22Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV23GXV1 = 1;
            AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            while ( AV23GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "PaisID") == 0 )
               {
                  AV11Insert_PaisID = AV12TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV11Insert_PaisID", AV11Insert_PaisID);
               }
               AV23GXV1 = (int)(AV23GXV1+1);
               AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            }
         }
      }

      protected void E120J2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("departamentoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0J21( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z113DepartamentoDepartamento = T000J5_A113DepartamentoDepartamento[0];
               Z907DepartamentoEstado = T000J5_A907DepartamentoEstado[0];
               Z185DepartamentoAutEnuMuni = T000J5_A185DepartamentoAutEnuMuni[0];
               Z966DepartamentoIntegracionEcommer = T000J5_A966DepartamentoIntegracionEcommer[0];
               Z116PaisID = T000J5_A116PaisID[0];
            }
            else
            {
               Z113DepartamentoDepartamento = A113DepartamentoDepartamento;
               Z907DepartamentoEstado = A907DepartamentoEstado;
               Z185DepartamentoAutEnuMuni = A185DepartamentoAutEnuMuni;
               Z966DepartamentoIntegracionEcommer = A966DepartamentoIntegracionEcommer;
               Z116PaisID = A116PaisID;
            }
         }
         if ( GX_JID == -15 )
         {
            Z112DepartamentoId = A112DepartamentoId;
            Z113DepartamentoDepartamento = A113DepartamentoDepartamento;
            Z907DepartamentoEstado = A907DepartamentoEstado;
            Z185DepartamentoAutEnuMuni = A185DepartamentoAutEnuMuni;
            Z966DepartamentoIntegracionEcommer = A966DepartamentoIntegracionEcommer;
            Z116PaisID = A116PaisID;
         }
      }

      protected void standaloneNotModal( )
      {
         edtDepartamentoId_Enabled = 0;
         AssignProp("", false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
         edtDepartamentoAutEnuMuni_Enabled = 0;
         AssignProp("", false, edtDepartamentoAutEnuMuni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoAutEnuMuni_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_116_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0130.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISID"+"'), id:'"+"PAISID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtDepartamentoId_Enabled = 0;
         AssignProp("", false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
         edtDepartamentoAutEnuMuni_Enabled = 0;
         AssignProp("", false, edtDepartamentoAutEnuMuni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoAutEnuMuni_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7DepartamentoId) )
         {
            A112DepartamentoId = AV7DepartamentoId;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_PaisID)) )
         {
            edtPaisID_Enabled = 0;
            AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         }
         else
         {
            edtPaisID_Enabled = 1;
            AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_PaisID)) )
         {
            A116PaisID = AV11Insert_PaisID;
            AssignAttri("", false, "A116PaisID", A116PaisID);
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A907DepartamentoEstado)) && ( Gx_BScreen == 0 ) )
         {
            A907DepartamentoEstado = context.GetMessage( context.GetMessage( "HAB", ""), "");
            n907DepartamentoEstado = false;
            AssignAttri("", false, "A907DepartamentoEstado", A907DepartamentoEstado);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV22Pgmname = "Departamento";
            AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         }
      }

      protected void Load0J21( )
      {
         /* Using cursor T000J7 */
         pr_default.execute(5, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound21 = 1;
            A113DepartamentoDepartamento = T000J7_A113DepartamentoDepartamento[0];
            AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
            A907DepartamentoEstado = T000J7_A907DepartamentoEstado[0];
            n907DepartamentoEstado = T000J7_n907DepartamentoEstado[0];
            AssignAttri("", false, "A907DepartamentoEstado", A907DepartamentoEstado);
            A185DepartamentoAutEnuMuni = T000J7_A185DepartamentoAutEnuMuni[0];
            AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
            A966DepartamentoIntegracionEcommer = T000J7_A966DepartamentoIntegracionEcommer[0];
            n966DepartamentoIntegracionEcommer = T000J7_n966DepartamentoIntegracionEcommer[0];
            A116PaisID = T000J7_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
            ZM0J21( -15) ;
         }
         pr_default.close(5);
         OnLoadActions0J21( ) ;
      }

      protected void OnLoadActions0J21( )
      {
         AV22Pgmname = "Departamento";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
      }

      protected void CheckExtendedTable0J21( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV22Pgmname = "Departamento";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         /* Using cursor T000J6 */
         pr_default.execute(4, new Object[] {A116PaisID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0J21( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_16( string A116PaisID )
      {
         /* Using cursor T000J8 */
         pr_default.execute(6, new Object[] {A116PaisID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0J21( )
      {
         /* Using cursor T000J9 */
         pr_default.execute(7, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000J5 */
         pr_default.execute(3, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0J21( 15) ;
            RcdFound21 = 1;
            A112DepartamentoId = T000J5_A112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A113DepartamentoDepartamento = T000J5_A113DepartamentoDepartamento[0];
            AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
            A907DepartamentoEstado = T000J5_A907DepartamentoEstado[0];
            n907DepartamentoEstado = T000J5_n907DepartamentoEstado[0];
            AssignAttri("", false, "A907DepartamentoEstado", A907DepartamentoEstado);
            A185DepartamentoAutEnuMuni = T000J5_A185DepartamentoAutEnuMuni[0];
            AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
            A966DepartamentoIntegracionEcommer = T000J5_A966DepartamentoIntegracionEcommer[0];
            n966DepartamentoIntegracionEcommer = T000J5_n966DepartamentoIntegracionEcommer[0];
            A116PaisID = T000J5_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
            O185DepartamentoAutEnuMuni = A185DepartamentoAutEnuMuni;
            AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
            Z112DepartamentoId = A112DepartamentoId;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0J21( ) ;
            if ( AnyError == 1 )
            {
               RcdFound21 = 0;
               InitializeNonKey0J21( ) ;
            }
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0J21( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J21( ) ;
         if ( RcdFound21 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound21 = 0;
         /* Using cursor T000J10 */
         pr_default.execute(8, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000J10_A112DepartamentoId[0] < A112DepartamentoId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000J10_A112DepartamentoId[0] > A112DepartamentoId ) ) )
            {
               A112DepartamentoId = T000J10_A112DepartamentoId[0];
               AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
               RcdFound21 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound21 = 0;
         /* Using cursor T000J11 */
         pr_default.execute(9, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000J11_A112DepartamentoId[0] > A112DepartamentoId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000J11_A112DepartamentoId[0] < A112DepartamentoId ) ) )
            {
               A112DepartamentoId = T000J11_A112DepartamentoId[0];
               AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
               RcdFound21 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0J21( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A185DepartamentoAutEnuMuni = O185DepartamentoAutEnuMuni;
            AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0J21( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound21 == 1 )
            {
               if ( A112DepartamentoId != Z112DepartamentoId )
               {
                  A112DepartamentoId = Z112DepartamentoId;
                  AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DEPARTAMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtDepartamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A185DepartamentoAutEnuMuni = O185DepartamentoAutEnuMuni;
                  AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A185DepartamentoAutEnuMuni = O185DepartamentoAutEnuMuni;
                  AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
                  Update0J21( ) ;
                  GX_FocusControl = edtPaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A112DepartamentoId != Z112DepartamentoId )
               {
                  /* Insert record */
                  A185DepartamentoAutEnuMuni = O185DepartamentoAutEnuMuni;
                  AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
                  GX_FocusControl = edtPaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0J21( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DEPARTAMENTOID");
                     AnyError = 1;
                     GX_FocusControl = edtDepartamentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A185DepartamentoAutEnuMuni = O185DepartamentoAutEnuMuni;
                     AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
                     GX_FocusControl = edtPaisID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0J21( ) ;
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
         if ( A112DepartamentoId != Z112DepartamentoId )
         {
            A112DepartamentoId = Z112DepartamentoId;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DEPARTAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A185DepartamentoAutEnuMuni = O185DepartamentoAutEnuMuni;
            AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0J21( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000J4 */
            pr_default.execute(2, new Object[] {A112DepartamentoId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Departamento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z113DepartamentoDepartamento, T000J4_A113DepartamentoDepartamento[0]) != 0 ) || ( StringUtil.StrCmp(Z907DepartamentoEstado, T000J4_A907DepartamentoEstado[0]) != 0 ) || ( Z185DepartamentoAutEnuMuni != T000J4_A185DepartamentoAutEnuMuni[0] ) || ( StringUtil.StrCmp(Z966DepartamentoIntegracionEcommer, T000J4_A966DepartamentoIntegracionEcommer[0]) != 0 ) || ( StringUtil.StrCmp(Z116PaisID, T000J4_A116PaisID[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z113DepartamentoDepartamento, T000J4_A113DepartamentoDepartamento[0]) != 0 )
               {
                  GXUtil.WriteLog("departamento:[seudo value changed for attri]"+"DepartamentoDepartamento");
                  GXUtil.WriteLogRaw("Old: ",Z113DepartamentoDepartamento);
                  GXUtil.WriteLogRaw("Current: ",T000J4_A113DepartamentoDepartamento[0]);
               }
               if ( StringUtil.StrCmp(Z907DepartamentoEstado, T000J4_A907DepartamentoEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("departamento:[seudo value changed for attri]"+"DepartamentoEstado");
                  GXUtil.WriteLogRaw("Old: ",Z907DepartamentoEstado);
                  GXUtil.WriteLogRaw("Current: ",T000J4_A907DepartamentoEstado[0]);
               }
               if ( Z185DepartamentoAutEnuMuni != T000J4_A185DepartamentoAutEnuMuni[0] )
               {
                  GXUtil.WriteLog("departamento:[seudo value changed for attri]"+"DepartamentoAutEnuMuni");
                  GXUtil.WriteLogRaw("Old: ",Z185DepartamentoAutEnuMuni);
                  GXUtil.WriteLogRaw("Current: ",T000J4_A185DepartamentoAutEnuMuni[0]);
               }
               if ( StringUtil.StrCmp(Z966DepartamentoIntegracionEcommer, T000J4_A966DepartamentoIntegracionEcommer[0]) != 0 )
               {
                  GXUtil.WriteLog("departamento:[seudo value changed for attri]"+"DepartamentoIntegracionEcommer");
                  GXUtil.WriteLogRaw("Old: ",Z966DepartamentoIntegracionEcommer);
                  GXUtil.WriteLogRaw("Current: ",T000J4_A966DepartamentoIntegracionEcommer[0]);
               }
               if ( StringUtil.StrCmp(Z116PaisID, T000J4_A116PaisID[0]) != 0 )
               {
                  GXUtil.WriteLog("departamento:[seudo value changed for attri]"+"PaisID");
                  GXUtil.WriteLogRaw("Old: ",Z116PaisID);
                  GXUtil.WriteLogRaw("Current: ",T000J4_A116PaisID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Departamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J21( )
      {
         BeforeValidate0J21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J21( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J21( 0) ;
            CheckOptimisticConcurrency0J21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J12 */
                     pr_default.execute(10, new Object[] {A113DepartamentoDepartamento, n907DepartamentoEstado, A907DepartamentoEstado, A185DepartamentoAutEnuMuni, n966DepartamentoIntegracionEcommer, A966DepartamentoIntegracionEcommer, A116PaisID});
                     A112DepartamentoId = T000J12_A112DepartamentoId[0];
                     AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Departamento");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0J21( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0J0( ) ;
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
               Load0J21( ) ;
            }
            EndLevel0J21( ) ;
         }
         CloseExtendedTableCursors0J21( ) ;
      }

      protected void Update0J21( )
      {
         BeforeValidate0J21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J21( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J13 */
                     pr_default.execute(11, new Object[] {A113DepartamentoDepartamento, n907DepartamentoEstado, A907DepartamentoEstado, A185DepartamentoAutEnuMuni, n966DepartamentoIntegracionEcommer, A966DepartamentoIntegracionEcommer, A116PaisID, A112DepartamentoId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Departamento");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Departamento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J21( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0J21( ) ;
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
            EndLevel0J21( ) ;
         }
         CloseExtendedTableCursors0J21( ) ;
      }

      protected void DeferredUpdate0J21( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0J21( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J21( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J21( ) ;
            AfterConfirm0J21( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J21( ) ;
               if ( AnyError == 0 )
               {
                  A185DepartamentoAutEnuMuni = O185DepartamentoAutEnuMuni;
                  AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
                  ScanStart0J22( ) ;
                  while ( RcdFound22 != 0 )
                  {
                     getByPrimaryKey0J22( ) ;
                     Delete0J22( ) ;
                     ScanNext0J22( ) ;
                     O185DepartamentoAutEnuMuni = A185DepartamentoAutEnuMuni;
                     AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
                  }
                  ScanEnd0J22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J14 */
                     pr_default.execute(12, new Object[] {A112DepartamentoId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Departamento");
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0J21( ) ;
         Gx_mode = sMode21;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0J21( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV22Pgmname = "Departamento";
            AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000J15 */
            pr_default.execute(13, new Object[] {A112DepartamentoId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Capacidad Productiva", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000J16 */
            pr_default.execute(14, new Object[] {A112DepartamentoId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Zonas", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void ProcessNestedLevel0J22( )
      {
         s185DepartamentoAutEnuMuni = O185DepartamentoAutEnuMuni;
         AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
         nGXsfl_48_idx = 0;
         while ( nGXsfl_48_idx < nRC_GXsfl_48 )
         {
            ReadRow0J22( ) ;
            if ( ( nRcdExists_22 != 0 ) || ( nIsMod_22 != 0 ) )
            {
               standaloneNotModal0J22( ) ;
               GetKey0J22( ) ;
               if ( ( nRcdExists_22 == 0 ) && ( nRcdDeleted_22 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0J22( ) ;
               }
               else
               {
                  if ( RcdFound22 != 0 )
                  {
                     if ( ( nRcdDeleted_22 != 0 ) && ( nRcdExists_22 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0J22( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_22 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0J22( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_22 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               O185DepartamentoAutEnuMuni = A185DepartamentoAutEnuMuni;
               AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
            }
            ChangePostValue( edtDepartamentoMunicipioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtDepartamentoMunicipioNombre_Internalname, StringUtil.RTrim( A115DepartamentoMunicipioNombre)) ;
            ChangePostValue( edtDepartamentoMunicipioCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A863DepartamentoMunicipioCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbDepartamentoMunicipioEstado_Internalname, StringUtil.RTrim( A908DepartamentoMunicipioEstado)) ;
            ChangePostValue( "ZT_"+"Z114DepartamentoMunicipioId_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z908DepartamentoMunicipioEstado_"+sGXsfl_48_idx, StringUtil.RTrim( Z908DepartamentoMunicipioEstado)) ;
            ChangePostValue( "ZT_"+"Z115DepartamentoMunicipioNombre_"+sGXsfl_48_idx, StringUtil.RTrim( Z115DepartamentoMunicipioNombre)) ;
            ChangePostValue( "ZT_"+"Z863DepartamentoMunicipioCosto_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( Z863DepartamentoMunicipioCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z967DepartamentoMunicipioIntegraci_"+sGXsfl_48_idx, StringUtil.RTrim( Z967DepartamentoMunicipioIntegraci)) ;
            ChangePostValue( "nRcdDeleted_22_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_22), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_22_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_22), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_22_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_22), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_22 != 0 )
            {
               ChangePostValue( "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DEPARTAMENTOMUNICIPIONOMBRE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DEPARTAMENTOMUNICIPIOCOSTO_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioCosto_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DEPARTAMENTOMUNICIPIOESTADO_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbDepartamentoMunicipioEstado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0J22( ) ;
         if ( AnyError != 0 )
         {
            O185DepartamentoAutEnuMuni = s185DepartamentoAutEnuMuni;
            AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
         }
         nRcdExists_22 = 0;
         nIsMod_22 = 0;
         nRcdDeleted_22 = 0;
      }

      protected void ProcessLevel0J21( )
      {
         /* Save parent mode. */
         sMode21 = Gx_mode;
         ProcessNestedLevel0J22( ) ;
         if ( AnyError != 0 )
         {
            O185DepartamentoAutEnuMuni = s185DepartamentoAutEnuMuni;
            AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode21;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000J17 */
         pr_default.execute(15, new Object[] {A185DepartamentoAutEnuMuni, A112DepartamentoId});
         pr_default.close(15);
         pr_default.SmartCacheProvider.SetUpdated("Departamento");
      }

      protected void EndLevel0J21( )
      {
         pr_default.close(2);
         if ( AnyError == 0 )
         {
            BeforeComplete0J21( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.CommitDataStores("departamento",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0J0( ) ;
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
            context.RollbackDataStores("departamento",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0J21( )
      {
         /* Scan By routine */
         /* Using cursor T000J18 */
         pr_default.execute(16);
         RcdFound21 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound21 = 1;
            A112DepartamentoId = T000J18_A112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0J21( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound21 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound21 = 1;
            A112DepartamentoId = T000J18_A112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
      }

      protected void ScanEnd0J21( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm0J21( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J21( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J21( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J21( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J21( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J21( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J21( )
      {
         edtDepartamentoId_Enabled = 0;
         AssignProp("", false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
         edtPaisID_Enabled = 0;
         AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         edtDepartamentoDepartamento_Enabled = 0;
         AssignProp("", false, edtDepartamentoDepartamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoDepartamento_Enabled), 5, 0), true);
         edtDepartamentoAutEnuMuni_Enabled = 0;
         AssignProp("", false, edtDepartamentoAutEnuMuni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoAutEnuMuni_Enabled), 5, 0), true);
         cmbDepartamentoEstado.Enabled = 0;
         AssignProp("", false, cmbDepartamentoEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbDepartamentoEstado.Enabled), 5, 0), true);
      }

      protected void ZM0J22( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z908DepartamentoMunicipioEstado = T000J3_A908DepartamentoMunicipioEstado[0];
               Z115DepartamentoMunicipioNombre = T000J3_A115DepartamentoMunicipioNombre[0];
               Z863DepartamentoMunicipioCosto = T000J3_A863DepartamentoMunicipioCosto[0];
               Z967DepartamentoMunicipioIntegraci = T000J3_A967DepartamentoMunicipioIntegraci[0];
            }
            else
            {
               Z908DepartamentoMunicipioEstado = A908DepartamentoMunicipioEstado;
               Z115DepartamentoMunicipioNombre = A115DepartamentoMunicipioNombre;
               Z863DepartamentoMunicipioCosto = A863DepartamentoMunicipioCosto;
               Z967DepartamentoMunicipioIntegraci = A967DepartamentoMunicipioIntegraci;
            }
         }
         if ( GX_JID == -17 )
         {
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            Z908DepartamentoMunicipioEstado = A908DepartamentoMunicipioEstado;
            Z115DepartamentoMunicipioNombre = A115DepartamentoMunicipioNombre;
            Z863DepartamentoMunicipioCosto = A863DepartamentoMunicipioCosto;
            Z967DepartamentoMunicipioIntegraci = A967DepartamentoMunicipioIntegraci;
         }
      }

      protected void standaloneNotModal0J22( )
      {
         edtDepartamentoMunicipioId_Enabled = 0;
         AssignProp("", false, edtDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtDepartamentoAutEnuMuni_Enabled = 0;
         AssignProp("", false, edtDepartamentoAutEnuMuni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoAutEnuMuni_Enabled), 5, 0), true);
         edtDepartamentoAutEnuMuni_Enabled = 0;
         AssignProp("", false, edtDepartamentoAutEnuMuni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoAutEnuMuni_Enabled), 5, 0), true);
      }

      protected void standaloneModal0J22( )
      {
         if ( IsIns( )  )
         {
            A185DepartamentoAutEnuMuni = (short)(O185DepartamentoAutEnuMuni+1);
            AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A114DepartamentoMunicipioId = A185DepartamentoAutEnuMuni;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A908DepartamentoMunicipioEstado)) && ( Gx_BScreen == 0 ) )
         {
            A908DepartamentoMunicipioEstado = context.GetMessage( context.GetMessage( "HAB", ""), "");
            n908DepartamentoMunicipioEstado = false;
         }
      }

      protected void Load0J22( )
      {
         /* Using cursor T000J19 */
         pr_default.execute(17, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound22 = 1;
            A908DepartamentoMunicipioEstado = T000J19_A908DepartamentoMunicipioEstado[0];
            n908DepartamentoMunicipioEstado = T000J19_n908DepartamentoMunicipioEstado[0];
            A115DepartamentoMunicipioNombre = T000J19_A115DepartamentoMunicipioNombre[0];
            A863DepartamentoMunicipioCosto = T000J19_A863DepartamentoMunicipioCosto[0];
            A967DepartamentoMunicipioIntegraci = T000J19_A967DepartamentoMunicipioIntegraci[0];
            n967DepartamentoMunicipioIntegraci = T000J19_n967DepartamentoMunicipioIntegraci[0];
            ZM0J22( -17) ;
         }
         pr_default.close(17);
         OnLoadActions0J22( ) ;
      }

      protected void OnLoadActions0J22( )
      {
      }

      protected void CheckExtendedTable0J22( )
      {
         nIsDirty_22 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0J22( ) ;
      }

      protected void CloseExtendedTableCursors0J22( )
      {
      }

      protected void enableDisable0J22( )
      {
      }

      protected void GetKey0J22( )
      {
         /* Using cursor T000J20 */
         pr_default.execute(18, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(18);
      }

      protected void getByPrimaryKey0J22( )
      {
         /* Using cursor T000J3 */
         pr_default.execute(1, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J22( 17) ;
            RcdFound22 = 1;
            InitializeNonKey0J22( ) ;
            A114DepartamentoMunicipioId = T000J3_A114DepartamentoMunicipioId[0];
            A908DepartamentoMunicipioEstado = T000J3_A908DepartamentoMunicipioEstado[0];
            n908DepartamentoMunicipioEstado = T000J3_n908DepartamentoMunicipioEstado[0];
            A115DepartamentoMunicipioNombre = T000J3_A115DepartamentoMunicipioNombre[0];
            A863DepartamentoMunicipioCosto = T000J3_A863DepartamentoMunicipioCosto[0];
            A967DepartamentoMunicipioIntegraci = T000J3_A967DepartamentoMunicipioIntegraci[0];
            n967DepartamentoMunicipioIntegraci = T000J3_n967DepartamentoMunicipioIntegraci[0];
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0J22( ) ;
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0J22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0J22( ) ;
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0J22( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0J22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000J2 */
            pr_default.execute(0, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DepartamentoMunicipio"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z908DepartamentoMunicipioEstado, T000J2_A908DepartamentoMunicipioEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z115DepartamentoMunicipioNombre, T000J2_A115DepartamentoMunicipioNombre[0]) != 0 ) || ( Z863DepartamentoMunicipioCosto != T000J2_A863DepartamentoMunicipioCosto[0] ) || ( StringUtil.StrCmp(Z967DepartamentoMunicipioIntegraci, T000J2_A967DepartamentoMunicipioIntegraci[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z908DepartamentoMunicipioEstado, T000J2_A908DepartamentoMunicipioEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("departamento:[seudo value changed for attri]"+"DepartamentoMunicipioEstado");
                  GXUtil.WriteLogRaw("Old: ",Z908DepartamentoMunicipioEstado);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A908DepartamentoMunicipioEstado[0]);
               }
               if ( StringUtil.StrCmp(Z115DepartamentoMunicipioNombre, T000J2_A115DepartamentoMunicipioNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("departamento:[seudo value changed for attri]"+"DepartamentoMunicipioNombre");
                  GXUtil.WriteLogRaw("Old: ",Z115DepartamentoMunicipioNombre);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A115DepartamentoMunicipioNombre[0]);
               }
               if ( Z863DepartamentoMunicipioCosto != T000J2_A863DepartamentoMunicipioCosto[0] )
               {
                  GXUtil.WriteLog("departamento:[seudo value changed for attri]"+"DepartamentoMunicipioCosto");
                  GXUtil.WriteLogRaw("Old: ",Z863DepartamentoMunicipioCosto);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A863DepartamentoMunicipioCosto[0]);
               }
               if ( StringUtil.StrCmp(Z967DepartamentoMunicipioIntegraci, T000J2_A967DepartamentoMunicipioIntegraci[0]) != 0 )
               {
                  GXUtil.WriteLog("departamento:[seudo value changed for attri]"+"DepartamentoMunicipioIntegraci");
                  GXUtil.WriteLogRaw("Old: ",Z967DepartamentoMunicipioIntegraci);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A967DepartamentoMunicipioIntegraci[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DepartamentoMunicipio"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J22( )
      {
         BeforeValidate0J22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J22( 0) ;
            CheckOptimisticConcurrency0J22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J21 */
                     pr_default.execute(19, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId, n908DepartamentoMunicipioEstado, A908DepartamentoMunicipioEstado, A115DepartamentoMunicipioNombre, A863DepartamentoMunicipioCosto, n967DepartamentoMunicipioIntegraci, A967DepartamentoMunicipioIntegraci});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("DepartamentoMunicipio");
                     if ( (pr_default.getStatus(19) == 1) )
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
               Load0J22( ) ;
            }
            EndLevel0J22( ) ;
         }
         CloseExtendedTableCursors0J22( ) ;
      }

      protected void Update0J22( )
      {
         BeforeValidate0J22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J22( ) ;
         }
         if ( ( nIsMod_22 != 0 ) || ( nIsDirty_22 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0J22( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0J22( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0J22( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000J22 */
                        pr_default.execute(20, new Object[] {n908DepartamentoMunicipioEstado, A908DepartamentoMunicipioEstado, A115DepartamentoMunicipioNombre, A863DepartamentoMunicipioCosto, n967DepartamentoMunicipioIntegraci, A967DepartamentoMunicipioIntegraci, A112DepartamentoId, A114DepartamentoMunicipioId});
                        pr_default.close(20);
                        pr_default.SmartCacheProvider.SetUpdated("DepartamentoMunicipio");
                        if ( (pr_default.getStatus(20) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DepartamentoMunicipio"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0J22( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0J22( ) ;
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
               EndLevel0J22( ) ;
            }
         }
         CloseExtendedTableCursors0J22( ) ;
      }

      protected void DeferredUpdate0J22( )
      {
      }

      protected void Delete0J22( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0J22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J22( ) ;
            AfterConfirm0J22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000J23 */
                  pr_default.execute(21, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
                  pr_default.close(21);
                  pr_default.SmartCacheProvider.SetUpdated("DepartamentoMunicipio");
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
         sMode22 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0J22( ) ;
         Gx_mode = sMode22;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0J22( )
      {
         standaloneModal0J22( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000J24 */
            pr_default.execute(22, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Publicaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T000J25 */
            pr_default.execute(23, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Clientes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T000J26 */
            pr_default.execute(24, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Zonas", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
         }
      }

      protected void EndLevel0J22( )
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

      public void ScanStart0J22( )
      {
         /* Scan By routine */
         /* Using cursor T000J27 */
         pr_default.execute(25, new Object[] {A112DepartamentoId});
         RcdFound22 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound22 = 1;
            A114DepartamentoMunicipioId = T000J27_A114DepartamentoMunicipioId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0J22( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound22 = 1;
            A114DepartamentoMunicipioId = T000J27_A114DepartamentoMunicipioId[0];
         }
      }

      protected void ScanEnd0J22( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm0J22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J22( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J22( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J22( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J22( )
      {
         edtDepartamentoMunicipioId_Enabled = 0;
         AssignProp("", false, edtDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtDepartamentoMunicipioNombre_Enabled = 0;
         AssignProp("", false, edtDepartamentoMunicipioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioNombre_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtDepartamentoMunicipioCosto_Enabled = 0;
         AssignProp("", false, edtDepartamentoMunicipioCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioCosto_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         cmbDepartamentoMunicipioEstado.Enabled = 0;
         AssignProp("", false, cmbDepartamentoMunicipioEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbDepartamentoMunicipioEstado.Enabled), 5, 0), !bGXsfl_48_Refreshing);
      }

      protected void send_integrity_lvl_hashes0J22( )
      {
      }

      protected void send_integrity_lvl_hashes0J21( )
      {
      }

      protected void SubsflControlProps_4822( )
      {
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_48_idx;
         edtDepartamentoMunicipioNombre_Internalname = "DEPARTAMENTOMUNICIPIONOMBRE_"+sGXsfl_48_idx;
         edtDepartamentoMunicipioCosto_Internalname = "DEPARTAMENTOMUNICIPIOCOSTO_"+sGXsfl_48_idx;
         cmbDepartamentoMunicipioEstado_Internalname = "DEPARTAMENTOMUNICIPIOESTADO_"+sGXsfl_48_idx;
      }

      protected void SubsflControlProps_fel_4822( )
      {
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_48_fel_idx;
         edtDepartamentoMunicipioNombre_Internalname = "DEPARTAMENTOMUNICIPIONOMBRE_"+sGXsfl_48_fel_idx;
         edtDepartamentoMunicipioCosto_Internalname = "DEPARTAMENTOMUNICIPIOCOSTO_"+sGXsfl_48_fel_idx;
         cmbDepartamentoMunicipioEstado_Internalname = "DEPARTAMENTOMUNICIPIOESTADO_"+sGXsfl_48_fel_idx;
      }

      protected void AddRow0J22( )
      {
         nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_4822( ) ;
         SendRow0J22( ) ;
      }

      protected void SendRow0J22( )
      {
         Gridlevel_municipioRow = GXWebRow.GetNew(context);
         if ( subGridlevel_municipio_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_municipio_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_municipio_Class, "") != 0 )
            {
               subGridlevel_municipio_Linesclass = subGridlevel_municipio_Class+"Odd";
            }
         }
         else if ( subGridlevel_municipio_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_municipio_Backstyle = 0;
            subGridlevel_municipio_Backcolor = subGridlevel_municipio_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_municipio_Class, "") != 0 )
            {
               subGridlevel_municipio_Linesclass = subGridlevel_municipio_Class+"Uniform";
            }
         }
         else if ( subGridlevel_municipio_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_municipio_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_municipio_Class, "") != 0 )
            {
               subGridlevel_municipio_Linesclass = subGridlevel_municipio_Class+"Odd";
            }
            subGridlevel_municipio_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_municipio_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_municipio_Backstyle = 1;
            if ( ((int)((nGXsfl_48_idx) % (2))) == 0 )
            {
               subGridlevel_municipio_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_municipio_Class, "") != 0 )
               {
                  subGridlevel_municipio_Linesclass = subGridlevel_municipio_Class+"Even";
               }
            }
            else
            {
               subGridlevel_municipio_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_municipio_Class, "") != 0 )
               {
                  subGridlevel_municipio_Linesclass = subGridlevel_municipio_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_22_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridlevel_municipioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoMunicipioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtDepartamentoMunicipioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A114DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A114DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoMunicipioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtDepartamentoMunicipioId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_22_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridlevel_municipioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoMunicipioNombre_Internalname,StringUtil.RTrim( A115DepartamentoMunicipioNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoMunicipioNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtDepartamentoMunicipioNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)-1,(bool)true,(string)"NombreLargo",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_22_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridlevel_municipioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoMunicipioCosto_Internalname,StringUtil.LTrim( StringUtil.NToC( A863DepartamentoMunicipioCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtDepartamentoMunicipioCosto_Enabled!=0) ? context.localUtil.Format( A863DepartamentoMunicipioCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A863DepartamentoMunicipioCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,51);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoMunicipioCosto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn ColumnAlignTitleLeft ColumnAlignLeft ColumnAlignTitleLeft ColumnAlignLeft",(string)"",(short)-1,(int)edtDepartamentoMunicipioCosto_Enabled,(short)0,(string)"text",(string)"",(short)100,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_22_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_48_idx + "',48)\"";
         GXCCtl = "DEPARTAMENTOMUNICIPIOESTADO_" + sGXsfl_48_idx;
         cmbDepartamentoMunicipioEstado.Name = GXCCtl;
         cmbDepartamentoMunicipioEstado.WebTags = "";
         cmbDepartamentoMunicipioEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbDepartamentoMunicipioEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbDepartamentoMunicipioEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A908DepartamentoMunicipioEstado)) )
            {
               A908DepartamentoMunicipioEstado = context.GetMessage( "HAB", "");
               n908DepartamentoMunicipioEstado = false;
            }
         }
         /* ComboBox */
         Gridlevel_municipioRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbDepartamentoMunicipioEstado,(string)cmbDepartamentoMunicipioEstado_Internalname,StringUtil.RTrim( A908DepartamentoMunicipioEstado),(short)1,(string)cmbDepartamentoMunicipioEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbDepartamentoMunicipioEstado.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"",(bool)true,(short)0});
         cmbDepartamentoMunicipioEstado.CurrentValue = StringUtil.RTrim( A908DepartamentoMunicipioEstado);
         AssignProp("", false, cmbDepartamentoMunicipioEstado_Internalname, "Values", (string)(cmbDepartamentoMunicipioEstado.ToJavascriptSource()), !bGXsfl_48_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_municipioRow);
         send_integrity_lvl_hashes0J22( ) ;
         GXCCtl = "Z114DepartamentoMunicipioId_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z908DepartamentoMunicipioEstado_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z908DepartamentoMunicipioEstado));
         GXCCtl = "Z115DepartamentoMunicipioNombre_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z115DepartamentoMunicipioNombre));
         GXCCtl = "Z863DepartamentoMunicipioCosto_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z863DepartamentoMunicipioCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z967DepartamentoMunicipioIntegraci_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z967DepartamentoMunicipioIntegraci));
         GXCCtl = "nRcdDeleted_22_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_22), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_22_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_22), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_22_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_22), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_48_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vDEPARTAMENTOID_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOMUNICIPIONOMBRE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOMUNICIPIOCOSTO_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioCosto_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOMUNICIPIOESTADO_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbDepartamentoMunicipioEstado.Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_municipioContainer.AddRow(Gridlevel_municipioRow);
      }

      protected void ReadRow0J22( )
      {
         nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_4822( ) ;
         edtDepartamentoMunicipioId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_48_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtDepartamentoMunicipioNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOMUNICIPIONOMBRE_"+sGXsfl_48_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtDepartamentoMunicipioCosto_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOMUNICIPIOCOSTO_"+sGXsfl_48_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbDepartamentoMunicipioEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOMUNICIPIOESTADO_"+sGXsfl_48_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A115DepartamentoMunicipioNombre = cgiGet( edtDepartamentoMunicipioNombre_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
         {
            GXCCtl = "DEPARTAMENTOMUNICIPIOCOSTO_" + sGXsfl_48_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtDepartamentoMunicipioCosto_Internalname;
            wbErr = true;
            A863DepartamentoMunicipioCosto = 0;
         }
         else
         {
            A863DepartamentoMunicipioCosto = context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         }
         cmbDepartamentoMunicipioEstado.Name = cmbDepartamentoMunicipioEstado_Internalname;
         cmbDepartamentoMunicipioEstado.CurrentValue = cgiGet( cmbDepartamentoMunicipioEstado_Internalname);
         A908DepartamentoMunicipioEstado = cgiGet( cmbDepartamentoMunicipioEstado_Internalname);
         n908DepartamentoMunicipioEstado = false;
         n908DepartamentoMunicipioEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A908DepartamentoMunicipioEstado)) ? true : false);
         GXCCtl = "Z114DepartamentoMunicipioId_" + sGXsfl_48_idx;
         Z114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z908DepartamentoMunicipioEstado_" + sGXsfl_48_idx;
         Z908DepartamentoMunicipioEstado = cgiGet( GXCCtl);
         n908DepartamentoMunicipioEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A908DepartamentoMunicipioEstado)) ? true : false);
         GXCCtl = "Z115DepartamentoMunicipioNombre_" + sGXsfl_48_idx;
         Z115DepartamentoMunicipioNombre = cgiGet( GXCCtl);
         GXCCtl = "Z863DepartamentoMunicipioCosto_" + sGXsfl_48_idx;
         Z863DepartamentoMunicipioCosto = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "Z967DepartamentoMunicipioIntegraci_" + sGXsfl_48_idx;
         Z967DepartamentoMunicipioIntegraci = cgiGet( GXCCtl);
         n967DepartamentoMunicipioIntegraci = (String.IsNullOrEmpty(StringUtil.RTrim( A967DepartamentoMunicipioIntegraci)) ? true : false);
         GXCCtl = "Z967DepartamentoMunicipioIntegraci_" + sGXsfl_48_idx;
         A967DepartamentoMunicipioIntegraci = cgiGet( GXCCtl);
         n967DepartamentoMunicipioIntegraci = false;
         n967DepartamentoMunicipioIntegraci = (String.IsNullOrEmpty(StringUtil.RTrim( A967DepartamentoMunicipioIntegraci)) ? true : false);
         GXCCtl = "nRcdDeleted_22_" + sGXsfl_48_idx;
         nRcdDeleted_22 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_22_" + sGXsfl_48_idx;
         nRcdExists_22 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_22_" + sGXsfl_48_idx;
         nIsMod_22 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtDepartamentoMunicipioId_Enabled = edtDepartamentoMunicipioId_Enabled;
      }

      protected void ConfirmValues0J0( )
      {
         nGXsfl_48_idx = 0;
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_4822( ) ;
         while ( nGXsfl_48_idx < nRC_GXsfl_48 )
         {
            nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_4822( ) ;
            ChangePostValue( "Z114DepartamentoMunicipioId_"+sGXsfl_48_idx, cgiGet( "ZT_"+"Z114DepartamentoMunicipioId_"+sGXsfl_48_idx)) ;
            DeletePostValue( "ZT_"+"Z114DepartamentoMunicipioId_"+sGXsfl_48_idx) ;
            ChangePostValue( "Z908DepartamentoMunicipioEstado_"+sGXsfl_48_idx, cgiGet( "ZT_"+"Z908DepartamentoMunicipioEstado_"+sGXsfl_48_idx)) ;
            DeletePostValue( "ZT_"+"Z908DepartamentoMunicipioEstado_"+sGXsfl_48_idx) ;
            ChangePostValue( "Z115DepartamentoMunicipioNombre_"+sGXsfl_48_idx, cgiGet( "ZT_"+"Z115DepartamentoMunicipioNombre_"+sGXsfl_48_idx)) ;
            DeletePostValue( "ZT_"+"Z115DepartamentoMunicipioNombre_"+sGXsfl_48_idx) ;
            ChangePostValue( "Z863DepartamentoMunicipioCosto_"+sGXsfl_48_idx, cgiGet( "ZT_"+"Z863DepartamentoMunicipioCosto_"+sGXsfl_48_idx)) ;
            DeletePostValue( "ZT_"+"Z863DepartamentoMunicipioCosto_"+sGXsfl_48_idx) ;
            ChangePostValue( "Z967DepartamentoMunicipioIntegraci_"+sGXsfl_48_idx, cgiGet( "ZT_"+"Z967DepartamentoMunicipioIntegraci_"+sGXsfl_48_idx)) ;
            DeletePostValue( "ZT_"+"Z967DepartamentoMunicipioIntegraci_"+sGXsfl_48_idx) ;
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
         GXEncryptionTmp = "departamento.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7DepartamentoId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("departamento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Departamento");
         forbiddenHiddens.Add("DepartamentoId", context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_PaisID", StringUtil.RTrim( context.localUtil.Format( AV11Insert_PaisID, "")));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("DepartamentoIntegracionEcommer", StringUtil.RTrim( context.localUtil.Format( A966DepartamentoIntegracionEcommer, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("departamento:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z113DepartamentoDepartamento", StringUtil.RTrim( Z113DepartamentoDepartamento));
         GxWebStd.gx_hidden_field( context, "Z907DepartamentoEstado", StringUtil.RTrim( Z907DepartamentoEstado));
         GxWebStd.gx_hidden_field( context, "Z185DepartamentoAutEnuMuni", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z185DepartamentoAutEnuMuni), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z966DepartamentoIntegracionEcommer", StringUtil.RTrim( Z966DepartamentoIntegracionEcommer));
         GxWebStd.gx_hidden_field( context, "Z116PaisID", StringUtil.RTrim( Z116PaisID));
         GxWebStd.gx_hidden_field( context, "O185DepartamentoAutEnuMuni", StringUtil.LTrim( StringUtil.NToC( (decimal)(O185DepartamentoAutEnuMuni), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_48", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_48_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N116PaisID", StringUtil.RTrim( A116PaisID));
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
         GxWebStd.gx_hidden_field( context, "vDEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDEPARTAMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISID", StringUtil.RTrim( AV11Insert_PaisID));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOINTEGRACIONECOMMER", StringUtil.RTrim( A966DepartamentoIntegracionEcommer));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOMUNICIPIOINTEGRACI", StringUtil.RTrim( A967DepartamentoMunicipioIntegraci));
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
         GXEncryptionTmp = "departamento.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7DepartamentoId,18,0));
         return formatLink("departamento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Departamento" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Departamento", "") ;
      }

      protected void InitializeNonKey0J21( )
      {
         A116PaisID = "";
         AssignAttri("", false, "A116PaisID", A116PaisID);
         A113DepartamentoDepartamento = "";
         AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
         A185DepartamentoAutEnuMuni = 0;
         AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
         A966DepartamentoIntegracionEcommer = "";
         n966DepartamentoIntegracionEcommer = false;
         AssignAttri("", false, "A966DepartamentoIntegracionEcommer", A966DepartamentoIntegracionEcommer);
         A907DepartamentoEstado = context.GetMessage( "HAB", "");
         n907DepartamentoEstado = false;
         AssignAttri("", false, "A907DepartamentoEstado", A907DepartamentoEstado);
         O185DepartamentoAutEnuMuni = A185DepartamentoAutEnuMuni;
         AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
         Z113DepartamentoDepartamento = "";
         Z907DepartamentoEstado = "";
         Z185DepartamentoAutEnuMuni = 0;
         Z966DepartamentoIntegracionEcommer = "";
         Z116PaisID = "";
      }

      protected void InitAll0J21( )
      {
         A112DepartamentoId = 0;
         AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         InitializeNonKey0J21( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A907DepartamentoEstado = i907DepartamentoEstado;
         n907DepartamentoEstado = false;
         AssignAttri("", false, "A907DepartamentoEstado", A907DepartamentoEstado);
      }

      protected void InitializeNonKey0J22( )
      {
         A115DepartamentoMunicipioNombre = "";
         A863DepartamentoMunicipioCosto = 0;
         A967DepartamentoMunicipioIntegraci = "";
         n967DepartamentoMunicipioIntegraci = false;
         AssignAttri("", false, "A967DepartamentoMunicipioIntegraci", A967DepartamentoMunicipioIntegraci);
         A908DepartamentoMunicipioEstado = context.GetMessage( "HAB", "");
         n908DepartamentoMunicipioEstado = false;
         Z908DepartamentoMunicipioEstado = "";
         Z115DepartamentoMunicipioNombre = "";
         Z863DepartamentoMunicipioCosto = 0;
         Z967DepartamentoMunicipioIntegraci = "";
      }

      protected void InitAll0J22( )
      {
         A114DepartamentoMunicipioId = 0;
         InitializeNonKey0J22( ) ;
      }

      protected void StandaloneModalInsert0J22( )
      {
         A185DepartamentoAutEnuMuni = i185DepartamentoAutEnuMuni;
         AssignAttri("", false, "A185DepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(A185DepartamentoAutEnuMuni), 4, 0));
         A908DepartamentoMunicipioEstado = i908DepartamentoMunicipioEstado;
         n908DepartamentoMunicipioEstado = false;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269319584780", true, true, false);
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
         context.AddJavascriptSource("departamento.js", "?20269319584781", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties22( )
      {
         edtDepartamentoMunicipioId_Enabled = defedtDepartamentoMunicipioId_Enabled;
         AssignProp("", false, edtDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
      }

      protected void StartGridControl48( )
      {
         Gridlevel_municipioContainer.AddObjectProperty("GridName", "Gridlevel_municipio");
         Gridlevel_municipioContainer.AddObjectProperty("Header", subGridlevel_municipio_Header);
         Gridlevel_municipioContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_municipioContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_municipioContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_municipioContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_municipio_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_municipioContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_municipioContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_municipioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_municipioColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", ""))));
         Gridlevel_municipioColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0, ".", "")));
         Gridlevel_municipioContainer.AddColumnProperties(Gridlevel_municipioColumn);
         Gridlevel_municipioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_municipioColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A115DepartamentoMunicipioNombre)));
         Gridlevel_municipioColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_municipioContainer.AddColumnProperties(Gridlevel_municipioColumn);
         Gridlevel_municipioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_municipioColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A863DepartamentoMunicipioCosto, 21, 2, ".", ""))));
         Gridlevel_municipioColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioCosto_Enabled), 5, 0, ".", "")));
         Gridlevel_municipioContainer.AddColumnProperties(Gridlevel_municipioColumn);
         Gridlevel_municipioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_municipioColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A908DepartamentoMunicipioEstado)));
         Gridlevel_municipioColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbDepartamentoMunicipioEstado.Enabled), 5, 0, ".", "")));
         Gridlevel_municipioContainer.AddColumnProperties(Gridlevel_municipioColumn);
         Gridlevel_municipioContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_municipio_Selectedindex), 4, 0, ".", "")));
         Gridlevel_municipioContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_municipio_Allowselection), 1, 0, ".", "")));
         Gridlevel_municipioContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_municipio_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_municipioContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_municipio_Allowhovering), 1, 0, ".", "")));
         Gridlevel_municipioContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_municipio_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_municipioContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_municipio_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_municipioContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_municipio_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtDepartamentoId_Internalname = "DEPARTAMENTOID";
         edtPaisID_Internalname = "PAISID";
         edtDepartamentoDepartamento_Internalname = "DEPARTAMENTODEPARTAMENTO";
         edtDepartamentoAutEnuMuni_Internalname = "DEPARTAMENTOAUTENUMUNI";
         cmbDepartamentoEstado_Internalname = "DEPARTAMENTOESTADO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID";
         edtDepartamentoMunicipioNombre_Internalname = "DEPARTAMENTOMUNICIPIONOMBRE";
         edtDepartamentoMunicipioCosto_Internalname = "DEPARTAMENTOMUNICIPIOCOSTO";
         cmbDepartamentoMunicipioEstado_Internalname = "DEPARTAMENTOMUNICIPIOESTADO";
         divTableleaflevel_municipio_Internalname = "TABLELEAFLEVEL_MUNICIPIO";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_116_Internalname = "PROMPT_116";
         subGridlevel_municipio_Internalname = "GRIDLEVEL_MUNICIPIO";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_municipio_Allowcollapsing = 0;
         subGridlevel_municipio_Allowselection = 0;
         subGridlevel_municipio_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Departamento", "");
         cmbDepartamentoMunicipioEstado_Jsonclick = "";
         edtDepartamentoMunicipioCosto_Jsonclick = "";
         edtDepartamentoMunicipioNombre_Jsonclick = "";
         edtDepartamentoMunicipioId_Jsonclick = "";
         subGridlevel_municipio_Class = "WorkWith";
         subGridlevel_municipio_Backcolorstyle = 0;
         cmbDepartamentoMunicipioEstado.Enabled = 1;
         edtDepartamentoMunicipioCosto_Enabled = 1;
         edtDepartamentoMunicipioNombre_Enabled = 1;
         edtDepartamentoMunicipioId_Enabled = 0;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbDepartamentoEstado_Jsonclick = "";
         cmbDepartamentoEstado.Enabled = 1;
         edtDepartamentoAutEnuMuni_Jsonclick = "";
         edtDepartamentoAutEnuMuni_Enabled = 0;
         edtDepartamentoDepartamento_Jsonclick = "";
         edtDepartamentoDepartamento_Enabled = 1;
         imgprompt_116_Visible = 1;
         imgprompt_116_Link = "";
         edtPaisID_Jsonclick = "";
         edtPaisID_Enabled = 1;
         edtDepartamentoId_Jsonclick = "";
         edtDepartamentoId_Enabled = 0;
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

      protected void gxnrGridlevel_municipio_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_4822( ) ;
         while ( nGXsfl_48_idx <= nRC_GXsfl_48 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0J22( ) ;
            standaloneModal0J22( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0J22( ) ;
            nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_4822( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_municipioContainer)) ;
         /* End function gxnrGridlevel_municipio_newrow */
      }

      protected void init_web_controls( )
      {
         cmbDepartamentoEstado.Name = "DEPARTAMENTOESTADO";
         cmbDepartamentoEstado.WebTags = "";
         cmbDepartamentoEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbDepartamentoEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbDepartamentoEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A907DepartamentoEstado)) )
            {
               A907DepartamentoEstado = context.GetMessage( "HAB", "");
               n907DepartamentoEstado = false;
               AssignAttri("", false, "A907DepartamentoEstado", A907DepartamentoEstado);
            }
         }
         GXCCtl = "DEPARTAMENTOMUNICIPIOESTADO_" + sGXsfl_48_idx;
         cmbDepartamentoMunicipioEstado.Name = GXCCtl;
         cmbDepartamentoMunicipioEstado.WebTags = "";
         cmbDepartamentoMunicipioEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbDepartamentoMunicipioEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbDepartamentoMunicipioEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A908DepartamentoMunicipioEstado)) )
            {
               A908DepartamentoMunicipioEstado = context.GetMessage( "HAB", "");
               n908DepartamentoMunicipioEstado = false;
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

      public void Valid_Paisid( )
      {
         /* Using cursor T000J28 */
         pr_default.execute(26, new Object[] {A116PaisID});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
         }
         pr_default.close(26);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11Insert_PaisID',fld:'vINSERT_PAISID',pic:'',type:'char'},{av:'A966DepartamentoIntegracionEcommer',fld:'DEPARTAMENTOINTEGRACIONECOMMER',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120J2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'}]");
         setEventMetadata("VALID_PAISID",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTOAUTENUMUNI","{handler:'Valid_Departamentoautenumuni',iparms:[]");
         setEventMetadata("VALID_DEPARTAMENTOAUTENUMUNI",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID","{handler:'Valid_Departamentomunicipioid',iparms:[]");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Departamentomunicipioestado',iparms:[]");
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
         pr_default.close(26);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z113DepartamentoDepartamento = "";
         Z907DepartamentoEstado = "";
         Z966DepartamentoIntegracionEcommer = "";
         Z116PaisID = "";
         N116PaisID = "";
         Z908DepartamentoMunicipioEstado = "";
         Z115DepartamentoMunicipioNombre = "";
         Z967DepartamentoMunicipioIntegraci = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A116PaisID = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A907DepartamentoEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         imgprompt_116_gximage = "";
         sImgUrl = "";
         A113DepartamentoDepartamento = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_municipioContainer = new GXWebGrid( context);
         sMode22 = "";
         sStyleString = "";
         A966DepartamentoIntegracionEcommer = "";
         AV11Insert_PaisID = "";
         AV22Pgmname = "";
         A967DepartamentoMunicipioIntegraci = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode21 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A115DepartamentoMunicipioNombre = "";
         A908DepartamentoMunicipioEstado = "";
         AV13WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         T000J7_A112DepartamentoId = new long[1] ;
         T000J7_A113DepartamentoDepartamento = new string[] {""} ;
         T000J7_A907DepartamentoEstado = new string[] {""} ;
         T000J7_n907DepartamentoEstado = new bool[] {false} ;
         T000J7_A185DepartamentoAutEnuMuni = new short[1] ;
         T000J7_A966DepartamentoIntegracionEcommer = new string[] {""} ;
         T000J7_n966DepartamentoIntegracionEcommer = new bool[] {false} ;
         T000J7_A116PaisID = new string[] {""} ;
         T000J6_A116PaisID = new string[] {""} ;
         T000J8_A116PaisID = new string[] {""} ;
         T000J9_A112DepartamentoId = new long[1] ;
         T000J5_A112DepartamentoId = new long[1] ;
         T000J5_A113DepartamentoDepartamento = new string[] {""} ;
         T000J5_A907DepartamentoEstado = new string[] {""} ;
         T000J5_n907DepartamentoEstado = new bool[] {false} ;
         T000J5_A185DepartamentoAutEnuMuni = new short[1] ;
         T000J5_A966DepartamentoIntegracionEcommer = new string[] {""} ;
         T000J5_n966DepartamentoIntegracionEcommer = new bool[] {false} ;
         T000J5_A116PaisID = new string[] {""} ;
         T000J10_A112DepartamentoId = new long[1] ;
         T000J11_A112DepartamentoId = new long[1] ;
         T000J4_A112DepartamentoId = new long[1] ;
         T000J4_A113DepartamentoDepartamento = new string[] {""} ;
         T000J4_A907DepartamentoEstado = new string[] {""} ;
         T000J4_n907DepartamentoEstado = new bool[] {false} ;
         T000J4_A185DepartamentoAutEnuMuni = new short[1] ;
         T000J4_A966DepartamentoIntegracionEcommer = new string[] {""} ;
         T000J4_n966DepartamentoIntegracionEcommer = new bool[] {false} ;
         T000J4_A116PaisID = new string[] {""} ;
         T000J12_A112DepartamentoId = new long[1] ;
         T000J15_A804CapacidadProdId = new long[1] ;
         T000J16_A110ZonasID = new long[1] ;
         T000J16_A112DepartamentoId = new long[1] ;
         T000J16_A114DepartamentoMunicipioId = new long[1] ;
         T000J18_A112DepartamentoId = new long[1] ;
         T000J19_A112DepartamentoId = new long[1] ;
         T000J19_A114DepartamentoMunicipioId = new long[1] ;
         T000J19_A908DepartamentoMunicipioEstado = new string[] {""} ;
         T000J19_n908DepartamentoMunicipioEstado = new bool[] {false} ;
         T000J19_A115DepartamentoMunicipioNombre = new string[] {""} ;
         T000J19_A863DepartamentoMunicipioCosto = new decimal[1] ;
         T000J19_A967DepartamentoMunicipioIntegraci = new string[] {""} ;
         T000J19_n967DepartamentoMunicipioIntegraci = new bool[] {false} ;
         T000J20_A112DepartamentoId = new long[1] ;
         T000J20_A114DepartamentoMunicipioId = new long[1] ;
         T000J3_A112DepartamentoId = new long[1] ;
         T000J3_A114DepartamentoMunicipioId = new long[1] ;
         T000J3_A908DepartamentoMunicipioEstado = new string[] {""} ;
         T000J3_n908DepartamentoMunicipioEstado = new bool[] {false} ;
         T000J3_A115DepartamentoMunicipioNombre = new string[] {""} ;
         T000J3_A863DepartamentoMunicipioCosto = new decimal[1] ;
         T000J3_A967DepartamentoMunicipioIntegraci = new string[] {""} ;
         T000J3_n967DepartamentoMunicipioIntegraci = new bool[] {false} ;
         T000J2_A112DepartamentoId = new long[1] ;
         T000J2_A114DepartamentoMunicipioId = new long[1] ;
         T000J2_A908DepartamentoMunicipioEstado = new string[] {""} ;
         T000J2_n908DepartamentoMunicipioEstado = new bool[] {false} ;
         T000J2_A115DepartamentoMunicipioNombre = new string[] {""} ;
         T000J2_A863DepartamentoMunicipioCosto = new decimal[1] ;
         T000J2_A967DepartamentoMunicipioIntegraci = new string[] {""} ;
         T000J2_n967DepartamentoMunicipioIntegraci = new bool[] {false} ;
         T000J24_A381PublicacionesId = new long[1] ;
         T000J25_A106ClientesId = new long[1] ;
         T000J26_A110ZonasID = new long[1] ;
         T000J26_A112DepartamentoId = new long[1] ;
         T000J26_A114DepartamentoMunicipioId = new long[1] ;
         T000J27_A112DepartamentoId = new long[1] ;
         T000J27_A114DepartamentoMunicipioId = new long[1] ;
         Gridlevel_municipioRow = new GXWebRow();
         subGridlevel_municipio_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i907DepartamentoEstado = "";
         i908DepartamentoMunicipioEstado = "";
         Gridlevel_municipioColumn = new GXWebColumn();
         T000J28_A116PaisID = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.departamento__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.departamento__default(),
            new Object[][] {
                new Object[] {
               T000J2_A112DepartamentoId, T000J2_A114DepartamentoMunicipioId, T000J2_A908DepartamentoMunicipioEstado, T000J2_n908DepartamentoMunicipioEstado, T000J2_A115DepartamentoMunicipioNombre, T000J2_A863DepartamentoMunicipioCosto, T000J2_A967DepartamentoMunicipioIntegraci, T000J2_n967DepartamentoMunicipioIntegraci
               }
               , new Object[] {
               T000J3_A112DepartamentoId, T000J3_A114DepartamentoMunicipioId, T000J3_A908DepartamentoMunicipioEstado, T000J3_n908DepartamentoMunicipioEstado, T000J3_A115DepartamentoMunicipioNombre, T000J3_A863DepartamentoMunicipioCosto, T000J3_A967DepartamentoMunicipioIntegraci, T000J3_n967DepartamentoMunicipioIntegraci
               }
               , new Object[] {
               T000J4_A112DepartamentoId, T000J4_A113DepartamentoDepartamento, T000J4_A907DepartamentoEstado, T000J4_n907DepartamentoEstado, T000J4_A185DepartamentoAutEnuMuni, T000J4_A966DepartamentoIntegracionEcommer, T000J4_n966DepartamentoIntegracionEcommer, T000J4_A116PaisID
               }
               , new Object[] {
               T000J5_A112DepartamentoId, T000J5_A113DepartamentoDepartamento, T000J5_A907DepartamentoEstado, T000J5_n907DepartamentoEstado, T000J5_A185DepartamentoAutEnuMuni, T000J5_A966DepartamentoIntegracionEcommer, T000J5_n966DepartamentoIntegracionEcommer, T000J5_A116PaisID
               }
               , new Object[] {
               T000J6_A116PaisID
               }
               , new Object[] {
               T000J7_A112DepartamentoId, T000J7_A113DepartamentoDepartamento, T000J7_A907DepartamentoEstado, T000J7_n907DepartamentoEstado, T000J7_A185DepartamentoAutEnuMuni, T000J7_A966DepartamentoIntegracionEcommer, T000J7_n966DepartamentoIntegracionEcommer, T000J7_A116PaisID
               }
               , new Object[] {
               T000J8_A116PaisID
               }
               , new Object[] {
               T000J9_A112DepartamentoId
               }
               , new Object[] {
               T000J10_A112DepartamentoId
               }
               , new Object[] {
               T000J11_A112DepartamentoId
               }
               , new Object[] {
               T000J12_A112DepartamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000J15_A804CapacidadProdId
               }
               , new Object[] {
               T000J16_A110ZonasID, T000J16_A112DepartamentoId, T000J16_A114DepartamentoMunicipioId
               }
               , new Object[] {
               }
               , new Object[] {
               T000J18_A112DepartamentoId
               }
               , new Object[] {
               T000J19_A112DepartamentoId, T000J19_A114DepartamentoMunicipioId, T000J19_A908DepartamentoMunicipioEstado, T000J19_n908DepartamentoMunicipioEstado, T000J19_A115DepartamentoMunicipioNombre, T000J19_A863DepartamentoMunicipioCosto, T000J19_A967DepartamentoMunicipioIntegraci, T000J19_n967DepartamentoMunicipioIntegraci
               }
               , new Object[] {
               T000J20_A112DepartamentoId, T000J20_A114DepartamentoMunicipioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000J24_A381PublicacionesId
               }
               , new Object[] {
               T000J25_A106ClientesId
               }
               , new Object[] {
               T000J26_A110ZonasID, T000J26_A112DepartamentoId, T000J26_A114DepartamentoMunicipioId
               }
               , new Object[] {
               T000J27_A112DepartamentoId, T000J27_A114DepartamentoMunicipioId
               }
               , new Object[] {
               T000J28_A116PaisID
               }
            }
         );
         AV22Pgmname = "Departamento";
         Z908DepartamentoMunicipioEstado = context.GetMessage( "HAB", "");
         n908DepartamentoMunicipioEstado = false;
         A908DepartamentoMunicipioEstado = context.GetMessage( "HAB", "");
         n908DepartamentoMunicipioEstado = false;
         i908DepartamentoMunicipioEstado = context.GetMessage( "HAB", "");
         n908DepartamentoMunicipioEstado = false;
         Z907DepartamentoEstado = context.GetMessage( "HAB", "");
         n907DepartamentoEstado = false;
         A907DepartamentoEstado = context.GetMessage( "HAB", "");
         n907DepartamentoEstado = false;
         i907DepartamentoEstado = context.GetMessage( "HAB", "");
         n907DepartamentoEstado = false;
      }

      private short Z185DepartamentoAutEnuMuni ;
      private short O185DepartamentoAutEnuMuni ;
      private short nRcdDeleted_22 ;
      private short nRcdExists_22 ;
      private short nIsMod_22 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A185DepartamentoAutEnuMuni ;
      private short Gx_BScreen ;
      private short nBlankRcdCount22 ;
      private short RcdFound22 ;
      private short B185DepartamentoAutEnuMuni ;
      private short nBlankRcdUsr22 ;
      private short RcdFound21 ;
      private short s185DepartamentoAutEnuMuni ;
      private short nIsDirty_22 ;
      private short subGridlevel_municipio_Backcolorstyle ;
      private short subGridlevel_municipio_Backstyle ;
      private short gxajaxcallmode ;
      private short i185DepartamentoAutEnuMuni ;
      private short subGridlevel_municipio_Allowselection ;
      private short subGridlevel_municipio_Allowhovering ;
      private short subGridlevel_municipio_Allowcollapsing ;
      private short subGridlevel_municipio_Collapsed ;
      private int nRC_GXsfl_48 ;
      private int nGXsfl_48_idx=1 ;
      private int trnEnded ;
      private int edtDepartamentoId_Enabled ;
      private int edtPaisID_Enabled ;
      private int imgprompt_116_Visible ;
      private int edtDepartamentoDepartamento_Enabled ;
      private int edtDepartamentoAutEnuMuni_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtDepartamentoMunicipioId_Enabled ;
      private int edtDepartamentoMunicipioNombre_Enabled ;
      private int edtDepartamentoMunicipioCosto_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV23GXV1 ;
      private int subGridlevel_municipio_Backcolor ;
      private int subGridlevel_municipio_Allbackcolor ;
      private int defedtDepartamentoMunicipioId_Enabled ;
      private int idxLst ;
      private int subGridlevel_municipio_Selectedindex ;
      private int subGridlevel_municipio_Selectioncolor ;
      private int subGridlevel_municipio_Hoveringcolor ;
      private long wcpOAV7DepartamentoId ;
      private long Z112DepartamentoId ;
      private long Z114DepartamentoMunicipioId ;
      private long AV7DepartamentoId ;
      private long A112DepartamentoId ;
      private long GRIDLEVEL_MUNICIPIO_nFirstRecordOnPage ;
      private long A114DepartamentoMunicipioId ;
      private decimal Z863DepartamentoMunicipioCosto ;
      private decimal A863DepartamentoMunicipioCosto ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z113DepartamentoDepartamento ;
      private string Z907DepartamentoEstado ;
      private string Z966DepartamentoIntegracionEcommer ;
      private string Z116PaisID ;
      private string N116PaisID ;
      private string Z908DepartamentoMunicipioEstado ;
      private string Z115DepartamentoMunicipioNombre ;
      private string Z967DepartamentoMunicipioIntegraci ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A116PaisID ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPaisID_Internalname ;
      private string sGXsfl_48_idx="0001" ;
      private string A907DepartamentoEstado ;
      private string cmbDepartamentoEstado_Internalname ;
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
      private string edtDepartamentoId_Internalname ;
      private string TempTags ;
      private string edtDepartamentoId_Jsonclick ;
      private string edtPaisID_Jsonclick ;
      private string imgprompt_116_gximage ;
      private string sImgUrl ;
      private string imgprompt_116_Internalname ;
      private string imgprompt_116_Link ;
      private string edtDepartamentoDepartamento_Internalname ;
      private string A113DepartamentoDepartamento ;
      private string edtDepartamentoDepartamento_Jsonclick ;
      private string edtDepartamentoAutEnuMuni_Internalname ;
      private string edtDepartamentoAutEnuMuni_Jsonclick ;
      private string cmbDepartamentoEstado_Jsonclick ;
      private string divTableleaflevel_municipio_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode22 ;
      private string edtDepartamentoMunicipioId_Internalname ;
      private string edtDepartamentoMunicipioNombre_Internalname ;
      private string edtDepartamentoMunicipioCosto_Internalname ;
      private string cmbDepartamentoMunicipioEstado_Internalname ;
      private string sStyleString ;
      private string subGridlevel_municipio_Internalname ;
      private string A966DepartamentoIntegracionEcommer ;
      private string AV11Insert_PaisID ;
      private string AV22Pgmname ;
      private string A967DepartamentoMunicipioIntegraci ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode21 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A115DepartamentoMunicipioNombre ;
      private string A908DepartamentoMunicipioEstado ;
      private string GXEncryptionTmp ;
      private string sGXsfl_48_fel_idx="0001" ;
      private string subGridlevel_municipio_Class ;
      private string subGridlevel_municipio_Linesclass ;
      private string ROClassString ;
      private string edtDepartamentoMunicipioId_Jsonclick ;
      private string edtDepartamentoMunicipioNombre_Jsonclick ;
      private string edtDepartamentoMunicipioCosto_Jsonclick ;
      private string GXCCtl ;
      private string cmbDepartamentoMunicipioEstado_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i907DepartamentoEstado ;
      private string i908DepartamentoMunicipioEstado ;
      private string subGridlevel_municipio_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n907DepartamentoEstado ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool bGXsfl_48_Refreshing=false ;
      private bool n966DepartamentoIntegracionEcommer ;
      private bool n967DepartamentoMunicipioIntegraci ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool n908DepartamentoMunicipioEstado ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_municipioContainer ;
      private GXWebRow Gridlevel_municipioRow ;
      private GXWebColumn Gridlevel_municipioColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbDepartamentoEstado ;
      private GXCombobox cmbDepartamentoMunicipioEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV13WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] T000J7_A112DepartamentoId ;
      private string[] T000J7_A113DepartamentoDepartamento ;
      private string[] T000J7_A907DepartamentoEstado ;
      private bool[] T000J7_n907DepartamentoEstado ;
      private short[] T000J7_A185DepartamentoAutEnuMuni ;
      private string[] T000J7_A966DepartamentoIntegracionEcommer ;
      private bool[] T000J7_n966DepartamentoIntegracionEcommer ;
      private string[] T000J7_A116PaisID ;
      private string[] T000J6_A116PaisID ;
      private string[] T000J8_A116PaisID ;
      private long[] T000J9_A112DepartamentoId ;
      private long[] T000J5_A112DepartamentoId ;
      private string[] T000J5_A113DepartamentoDepartamento ;
      private string[] T000J5_A907DepartamentoEstado ;
      private bool[] T000J5_n907DepartamentoEstado ;
      private short[] T000J5_A185DepartamentoAutEnuMuni ;
      private string[] T000J5_A966DepartamentoIntegracionEcommer ;
      private bool[] T000J5_n966DepartamentoIntegracionEcommer ;
      private string[] T000J5_A116PaisID ;
      private long[] T000J10_A112DepartamentoId ;
      private long[] T000J11_A112DepartamentoId ;
      private long[] T000J4_A112DepartamentoId ;
      private string[] T000J4_A113DepartamentoDepartamento ;
      private string[] T000J4_A907DepartamentoEstado ;
      private bool[] T000J4_n907DepartamentoEstado ;
      private short[] T000J4_A185DepartamentoAutEnuMuni ;
      private string[] T000J4_A966DepartamentoIntegracionEcommer ;
      private bool[] T000J4_n966DepartamentoIntegracionEcommer ;
      private string[] T000J4_A116PaisID ;
      private long[] T000J12_A112DepartamentoId ;
      private long[] T000J15_A804CapacidadProdId ;
      private long[] T000J16_A110ZonasID ;
      private long[] T000J16_A112DepartamentoId ;
      private long[] T000J16_A114DepartamentoMunicipioId ;
      private long[] T000J18_A112DepartamentoId ;
      private long[] T000J19_A112DepartamentoId ;
      private long[] T000J19_A114DepartamentoMunicipioId ;
      private string[] T000J19_A908DepartamentoMunicipioEstado ;
      private bool[] T000J19_n908DepartamentoMunicipioEstado ;
      private string[] T000J19_A115DepartamentoMunicipioNombre ;
      private decimal[] T000J19_A863DepartamentoMunicipioCosto ;
      private string[] T000J19_A967DepartamentoMunicipioIntegraci ;
      private bool[] T000J19_n967DepartamentoMunicipioIntegraci ;
      private long[] T000J20_A112DepartamentoId ;
      private long[] T000J20_A114DepartamentoMunicipioId ;
      private long[] T000J3_A112DepartamentoId ;
      private long[] T000J3_A114DepartamentoMunicipioId ;
      private string[] T000J3_A908DepartamentoMunicipioEstado ;
      private bool[] T000J3_n908DepartamentoMunicipioEstado ;
      private string[] T000J3_A115DepartamentoMunicipioNombre ;
      private decimal[] T000J3_A863DepartamentoMunicipioCosto ;
      private string[] T000J3_A967DepartamentoMunicipioIntegraci ;
      private bool[] T000J3_n967DepartamentoMunicipioIntegraci ;
      private long[] T000J2_A112DepartamentoId ;
      private long[] T000J2_A114DepartamentoMunicipioId ;
      private string[] T000J2_A908DepartamentoMunicipioEstado ;
      private bool[] T000J2_n908DepartamentoMunicipioEstado ;
      private string[] T000J2_A115DepartamentoMunicipioNombre ;
      private decimal[] T000J2_A863DepartamentoMunicipioCosto ;
      private string[] T000J2_A967DepartamentoMunicipioIntegraci ;
      private bool[] T000J2_n967DepartamentoMunicipioIntegraci ;
      private long[] T000J24_A381PublicacionesId ;
      private long[] T000J25_A106ClientesId ;
      private long[] T000J26_A110ZonasID ;
      private long[] T000J26_A112DepartamentoId ;
      private long[] T000J26_A114DepartamentoMunicipioId ;
      private long[] T000J27_A112DepartamentoId ;
      private long[] T000J27_A114DepartamentoMunicipioId ;
      private string[] T000J28_A116PaisID ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class departamento__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class departamento__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000J2;
        prmT000J2 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000J3;
        prmT000J3 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000J4;
        prmT000J4 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000J5;
        prmT000J5 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000J6;
        prmT000J6 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000J7;
        prmT000J7 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000J8;
        prmT000J8 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000J9;
        prmT000J9 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000J10;
        prmT000J10 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000J11;
        prmT000J11 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000J12;
        prmT000J12 = new Object[] {
        new ParDef("@DepartamentoDepartamento",GXType.NChar,80,0) ,
        new ParDef("@DepartamentoEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@DepartamentoAutEnuMuni",GXType.Int16,4,0) ,
        new ParDef("@DepartamentoIntegracionEcommer",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT000J13;
        prmT000J13 = new Object[] {
        new ParDef("@DepartamentoDepartamento",GXType.NChar,80,0) ,
        new ParDef("@DepartamentoEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@DepartamentoAutEnuMuni",GXType.Int16,4,0) ,
        new ParDef("@DepartamentoIntegracionEcommer",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@PaisID",GXType.NChar,2,0) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000J14;
        prmT000J14 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000J15;
        prmT000J15 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000J16;
        prmT000J16 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000J17;
        prmT000J17 = new Object[] {
        new ParDef("@DepartamentoAutEnuMuni",GXType.Int16,4,0) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000J18;
        prmT000J18 = new Object[] {
        };
        Object[] prmT000J19;
        prmT000J19 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000J20;
        prmT000J20 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000J21;
        prmT000J21 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioNombre",GXType.NChar,120,0) ,
        new ParDef("@DepartamentoMunicipioCosto",GXType.Decimal,18,2) ,
        new ParDef("@DepartamentoMunicipioIntegraci",GXType.NChar,1,0){Nullable=true}
        };
        Object[] prmT000J22;
        prmT000J22 = new Object[] {
        new ParDef("@DepartamentoMunicipioEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioNombre",GXType.NChar,120,0) ,
        new ParDef("@DepartamentoMunicipioCosto",GXType.Decimal,18,2) ,
        new ParDef("@DepartamentoMunicipioIntegraci",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000J23;
        prmT000J23 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000J24;
        prmT000J24 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000J25;
        prmT000J25 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000J26;
        prmT000J26 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000J27;
        prmT000J27 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000J28;
        prmT000J28 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000J2", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [DepartamentoMunicipioEstado], [DepartamentoMunicipioNombre], [DepartamentoMunicipioCosto], [DepartamentoMunicipioIntegraci] FROM [DepartamentoMunicipio] WITH (UPDLOCK) WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J3", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [DepartamentoMunicipioEstado], [DepartamentoMunicipioNombre], [DepartamentoMunicipioCosto], [DepartamentoMunicipioIntegraci] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J4", "SELECT [DepartamentoId], [DepartamentoDepartamento], [DepartamentoEstado], [DepartamentoAutEnuMuni], [DepartamentoIntegracionEcommer], [PaisID] FROM [Departamento] WITH (UPDLOCK) WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J5", "SELECT [DepartamentoId], [DepartamentoDepartamento], [DepartamentoEstado], [DepartamentoAutEnuMuni], [DepartamentoIntegracionEcommer], [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J6", "SELECT [PaisID] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J7", "SELECT TM1.[DepartamentoId], TM1.[DepartamentoDepartamento], TM1.[DepartamentoEstado], TM1.[DepartamentoAutEnuMuni], TM1.[DepartamentoIntegracionEcommer], TM1.[PaisID] FROM [Departamento] TM1 WHERE TM1.[DepartamentoId] = @DepartamentoId ORDER BY TM1.[DepartamentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J8", "SELECT [PaisID] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J9", "SELECT [DepartamentoId] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J10", "SELECT TOP 1 [DepartamentoId] FROM [Departamento] WHERE ( [DepartamentoId] > @DepartamentoId) ORDER BY [DepartamentoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J11", "SELECT TOP 1 [DepartamentoId] FROM [Departamento] WHERE ( [DepartamentoId] < @DepartamentoId) ORDER BY [DepartamentoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J12", "INSERT INTO [Departamento]([DepartamentoDepartamento], [DepartamentoEstado], [DepartamentoAutEnuMuni], [DepartamentoIntegracionEcommer], [PaisID]) VALUES(@DepartamentoDepartamento, @DepartamentoEstado, @DepartamentoAutEnuMuni, @DepartamentoIntegracionEcommer, @PaisID); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000J12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J13", "UPDATE [Departamento] SET [DepartamentoDepartamento]=@DepartamentoDepartamento, [DepartamentoEstado]=@DepartamentoEstado, [DepartamentoAutEnuMuni]=@DepartamentoAutEnuMuni, [DepartamentoIntegracionEcommer]=@DepartamentoIntegracionEcommer, [PaisID]=@PaisID  WHERE [DepartamentoId] = @DepartamentoId", GxErrorMask.GX_NOMASK,prmT000J13)
           ,new CursorDef("T000J14", "DELETE FROM [Departamento]  WHERE [DepartamentoId] = @DepartamentoId", GxErrorMask.GX_NOMASK,prmT000J14)
           ,new CursorDef("T000J15", "SELECT TOP 1 [CapacidadProdId] FROM [CapacidadProductiva] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J16", "SELECT TOP 1 [ZonasID], [DepartamentoId], [DepartamentoMunicipioId] FROM [Zonas] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J17", "UPDATE [Departamento] SET [DepartamentoAutEnuMuni]=@DepartamentoAutEnuMuni  WHERE [DepartamentoId] = @DepartamentoId", GxErrorMask.GX_NOMASK,prmT000J17)
           ,new CursorDef("T000J18", "SELECT [DepartamentoId] FROM [Departamento] ORDER BY [DepartamentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J18,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J19", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [DepartamentoMunicipioEstado], [DepartamentoMunicipioNombre], [DepartamentoMunicipioCosto], [DepartamentoMunicipioIntegraci] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId and [DepartamentoMunicipioId] = @DepartamentoMunicipioId ORDER BY [DepartamentoId], [DepartamentoMunicipioId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J19,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J20", "SELECT [DepartamentoId], [DepartamentoMunicipioId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J21", "INSERT INTO [DepartamentoMunicipio]([DepartamentoId], [DepartamentoMunicipioId], [DepartamentoMunicipioEstado], [DepartamentoMunicipioNombre], [DepartamentoMunicipioCosto], [DepartamentoMunicipioIntegraci]) VALUES(@DepartamentoId, @DepartamentoMunicipioId, @DepartamentoMunicipioEstado, @DepartamentoMunicipioNombre, @DepartamentoMunicipioCosto, @DepartamentoMunicipioIntegraci)", GxErrorMask.GX_NOMASK,prmT000J21)
           ,new CursorDef("T000J22", "UPDATE [DepartamentoMunicipio] SET [DepartamentoMunicipioEstado]=@DepartamentoMunicipioEstado, [DepartamentoMunicipioNombre]=@DepartamentoMunicipioNombre, [DepartamentoMunicipioCosto]=@DepartamentoMunicipioCosto, [DepartamentoMunicipioIntegraci]=@DepartamentoMunicipioIntegraci  WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId", GxErrorMask.GX_NOMASK,prmT000J22)
           ,new CursorDef("T000J23", "DELETE FROM [DepartamentoMunicipio]  WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId", GxErrorMask.GX_NOMASK,prmT000J23)
           ,new CursorDef("T000J24", "SELECT TOP 1 [PublicacionesId] FROM [Publicaciones] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J25", "SELECT TOP 1 [ClientesId] FROM [Clientes] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J26", "SELECT TOP 1 [ZonasID], [DepartamentoId], [DepartamentoMunicipioId] FROM [Zonas] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J27", "SELECT [DepartamentoId], [DepartamentoMunicipioId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId ORDER BY [DepartamentoId], [DepartamentoMunicipioId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J27,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J28", "SELECT [PaisID] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J28,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 120);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 1);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 120);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 1);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((short[]) buf[4])[0] = rslt.getShort(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 1);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getString(6, 2);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((short[]) buf[4])[0] = rslt.getShort(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 1);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getString(6, 2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((short[]) buf[4])[0] = rslt.getShort(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 1);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getString(6, 2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
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
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 120);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 1);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 23 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              return;
     }
  }

}

}
