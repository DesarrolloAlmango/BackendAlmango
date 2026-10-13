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
   public class profesionalesrestriccion : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A120ProfesionalesId = GetPar( "ProfesionalesId");
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A120ProfesionalesId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A590Listaid = (long)(Math.Round(NumberUtil.Val( GetPar( "Listaid"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A590Listaid) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "profesionalesrestriccion.aspx")), "profesionalesrestriccion.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "profesionalesrestriccion.aspx")))) ;
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
                  AV7ProfesionalesRestriccionId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProfesionalesRestriccionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(AV7ProfesionalesRestriccionId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESRESTRICCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProfesionalesRestriccionId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Lista Profesionales Restriccion", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public profesionalesrestriccion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionalesrestriccion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_ProfesionalesRestriccionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ProfesionalesRestriccionId = aP1_ProfesionalesRestriccionId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbListaEstado = new GXCombobox();
         cmbListaTipo = new GXCombobox();
         cmbRestriccionesEstado = new GXCombobox();
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
         if ( cmbListaEstado.ItemCount > 0 )
         {
            A593ListaEstado = cmbListaEstado.getValidValue(A593ListaEstado);
            n593ListaEstado = false;
            AssignAttri("", false, "A593ListaEstado", A593ListaEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbListaEstado.CurrentValue = StringUtil.RTrim( A593ListaEstado);
            AssignProp("", false, cmbListaEstado_Internalname, "Values", cmbListaEstado.ToJavascriptSource(), true);
         }
         if ( cmbListaTipo.ItemCount > 0 )
         {
            A591ListaTipo = cmbListaTipo.getValidValue(A591ListaTipo);
            AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbListaTipo.CurrentValue = StringUtil.RTrim( A591ListaTipo);
            AssignProp("", false, cmbListaTipo_Internalname, "Values", cmbListaTipo.ToJavascriptSource(), true);
         }
         if ( cmbRestriccionesEstado.ItemCount > 0 )
         {
            A974RestriccionesEstado = cmbRestriccionesEstado.getValidValue(A974RestriccionesEstado);
            n974RestriccionesEstado = false;
            AssignAttri("", false, "A974RestriccionesEstado", A974RestriccionesEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbRestriccionesEstado.CurrentValue = StringUtil.RTrim( A974RestriccionesEstado);
            AssignProp("", false, cmbRestriccionesEstado_Internalname, "Values", cmbRestriccionesEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesRestriccionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesRestriccionId_Internalname, context.GetMessage( "Restriccion Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesRestriccionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A976ProfesionalesRestriccionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProfesionalesRestriccionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A976ProfesionalesRestriccionId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A976ProfesionalesRestriccionId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesRestriccionId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesRestriccionId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ProfesionalesRestriccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesId_Internalname, context.GetMessage( "Identidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesId_Internalname, StringUtil.RTrim( A120ProfesionalesId), StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "123456789", edtProfesionalesId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesId_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "NoIdentidad", "start", true, "", "HLP_ProfesionalesRestriccion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_120_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_120_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_120_Internalname, sImgUrl, imgprompt_120_Link, "", "", context.GetTheme( ), imgprompt_120_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_ProfesionalesRestriccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesPrimerNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesPrimerNombre_Internalname, context.GetMessage( "Primer Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesPrimerNombre_Internalname, StringUtil.RTrim( A166ProfesionalesPrimerNombre), StringUtil.RTrim( context.localUtil.Format( A166ProfesionalesPrimerNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesPrimerNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesPrimerNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesRestriccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesApellidoPrimero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesApellidoPrimero_Internalname, context.GetMessage( "Primero Apellido ", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesApellidoPrimero_Internalname, StringUtil.RTrim( A167ProfesionalesApellidoPrimero), StringUtil.RTrim( context.localUtil.Format( A167ProfesionalesApellidoPrimero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesApellidoPrimero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesApellidoPrimero_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesRestriccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtListaid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtListaid_Internalname, context.GetMessage( "Listaid", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A590Listaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A590Listaid), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtListaid_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesRestriccion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_590_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_590_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_590_Internalname, sImgUrl, imgprompt_590_Link, "", "", context.GetTheme( ), imgprompt_590_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_ProfesionalesRestriccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtListaNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtListaNombre_Internalname, context.GetMessage( "Lista Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListaNombre_Internalname, StringUtil.RTrim( A592ListaNombre), StringUtil.RTrim( context.localUtil.Format( A592ListaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtListaNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_ProfesionalesRestriccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbListaEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbListaEstado_Internalname, context.GetMessage( "Lista Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbListaEstado, cmbListaEstado_Internalname, StringUtil.RTrim( A593ListaEstado), 1, cmbListaEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbListaEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_ProfesionalesRestriccion.htm");
         cmbListaEstado.CurrentValue = StringUtil.RTrim( A593ListaEstado);
         AssignProp("", false, cmbListaEstado_Internalname, "Values", (string)(cmbListaEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbListaTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbListaTipo_Internalname, context.GetMessage( "Lista Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbListaTipo, cmbListaTipo_Internalname, StringUtil.RTrim( A591ListaTipo), 1, cmbListaTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbListaTipo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 0, "HLP_ProfesionalesRestriccion.htm");
         cmbListaTipo.CurrentValue = StringUtil.RTrim( A591ListaTipo);
         AssignProp("", false, cmbListaTipo_Internalname, "Values", (string)(cmbListaTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRestriccionesFechaAlta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRestriccionesFechaAlta_Internalname, context.GetMessage( "Fecha Alta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtRestriccionesFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtRestriccionesFechaAlta_Internalname, context.localUtil.TToC( A973RestriccionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A973RestriccionesFechaAlta, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRestriccionesFechaAlta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRestriccionesFechaAlta_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesRestriccion.htm");
         GxWebStd.gx_bitmap( context, edtRestriccionesFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtRestriccionesFechaAlta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ProfesionalesRestriccion.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbRestriccionesEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbRestriccionesEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbRestriccionesEstado, cmbRestriccionesEstado_Internalname, StringUtil.RTrim( A974RestriccionesEstado), 1, cmbRestriccionesEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbRestriccionesEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "", true, 0, "HLP_ProfesionalesRestriccion.htm");
         cmbRestriccionesEstado.CurrentValue = StringUtil.RTrim( A974RestriccionesEstado);
         AssignProp("", false, cmbRestriccionesEstado_Internalname, "Values", (string)(cmbRestriccionesEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRestriccionesObservacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRestriccionesObservacion_Internalname, context.GetMessage( "Observacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRestriccionesObservacion_Internalname, A975RestriccionesObservacion, StringUtil.RTrim( context.localUtil.Format( A975RestriccionesObservacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRestriccionesObservacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRestriccionesObservacion_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesRestriccion.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesRestriccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesRestriccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesRestriccion.htm");
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
         E112Y2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z976ProfesionalesRestriccionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z976ProfesionalesRestriccionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z973RestriccionesFechaAlta = context.localUtil.CToT( cgiGet( "Z973RestriccionesFechaAlta"), 0);
               n973RestriccionesFechaAlta = ((DateTime.MinValue==A973RestriccionesFechaAlta) ? true : false);
               Z974RestriccionesEstado = cgiGet( "Z974RestriccionesEstado");
               n974RestriccionesEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A974RestriccionesEstado)) ? true : false);
               Z975RestriccionesObservacion = cgiGet( "Z975RestriccionesObservacion");
               n975RestriccionesObservacion = (String.IsNullOrEmpty(StringUtil.RTrim( A975RestriccionesObservacion)) ? true : false);
               Z120ProfesionalesId = cgiGet( "Z120ProfesionalesId");
               Z590Listaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z590Listaid"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N120ProfesionalesId = cgiGet( "N120ProfesionalesId");
               N590Listaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N590Listaid"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7ProfesionalesRestriccionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vPROFESIONALESRESTRICCIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_ProfesionalesId = cgiGet( "vINSERT_PROFESIONALESID");
               AssignAttri("", false, "AV13Insert_ProfesionalesId", AV13Insert_ProfesionalesId);
               AV14Insert_Listaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_LISTAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV14Insert_Listaid", StringUtil.LTrimStr( (decimal)(AV14Insert_Listaid), 18, 0));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV18Pgmname = cgiGet( "vPGMNAME");
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
               A976ProfesionalesRestriccionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesRestriccionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
               A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
               AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
               A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
               AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
               A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
               AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
               if ( ( ( context.localUtil.CToN( cgiGet( edtListaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtListaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LISTAID");
                  AnyError = 1;
                  GX_FocusControl = edtListaid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A590Listaid = 0;
                  AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
               }
               else
               {
                  A590Listaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
               }
               A592ListaNombre = cgiGet( edtListaNombre_Internalname);
               AssignAttri("", false, "A592ListaNombre", A592ListaNombre);
               cmbListaEstado.CurrentValue = cgiGet( cmbListaEstado_Internalname);
               A593ListaEstado = cgiGet( cmbListaEstado_Internalname);
               n593ListaEstado = false;
               AssignAttri("", false, "A593ListaEstado", A593ListaEstado);
               cmbListaTipo.CurrentValue = cgiGet( cmbListaTipo_Internalname);
               A591ListaTipo = cgiGet( cmbListaTipo_Internalname);
               AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
               if ( context.localUtil.VCDateTime( cgiGet( edtRestriccionesFechaAlta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Restricciones Fecha Alta", "")}), 1, "RESTRICCIONESFECHAALTA");
                  AnyError = 1;
                  GX_FocusControl = edtRestriccionesFechaAlta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A973RestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
                  n973RestriccionesFechaAlta = false;
                  AssignAttri("", false, "A973RestriccionesFechaAlta", context.localUtil.TToC( A973RestriccionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A973RestriccionesFechaAlta = context.localUtil.CToT( cgiGet( edtRestriccionesFechaAlta_Internalname));
                  n973RestriccionesFechaAlta = false;
                  AssignAttri("", false, "A973RestriccionesFechaAlta", context.localUtil.TToC( A973RestriccionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               n973RestriccionesFechaAlta = ((DateTime.MinValue==A973RestriccionesFechaAlta) ? true : false);
               cmbRestriccionesEstado.CurrentValue = cgiGet( cmbRestriccionesEstado_Internalname);
               A974RestriccionesEstado = cgiGet( cmbRestriccionesEstado_Internalname);
               n974RestriccionesEstado = false;
               AssignAttri("", false, "A974RestriccionesEstado", A974RestriccionesEstado);
               n974RestriccionesEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A974RestriccionesEstado)) ? true : false);
               A975RestriccionesObservacion = cgiGet( edtRestriccionesObservacion_Internalname);
               n975RestriccionesObservacion = false;
               AssignAttri("", false, "A975RestriccionesObservacion", A975RestriccionesObservacion);
               n975RestriccionesObservacion = (String.IsNullOrEmpty(StringUtil.RTrim( A975RestriccionesObservacion)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ProfesionalesRestriccion");
               A976ProfesionalesRestriccionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesRestriccionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
               forbiddenHiddens.Add("ProfesionalesRestriccionId", context.localUtil.Format( (decimal)(A976ProfesionalesRestriccionId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ProfesionalesId", StringUtil.RTrim( context.localUtil.Format( AV13Insert_ProfesionalesId, "")));
               forbiddenHiddens.Add("Insert_Listaid", context.localUtil.Format( (decimal)(AV14Insert_Listaid), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A976ProfesionalesRestriccionId != Z976ProfesionalesRestriccionId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("profesionalesrestriccion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A976ProfesionalesRestriccionId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProfesionalesRestriccionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
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
                     sMode143 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode143;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound143 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2Y0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PROFESIONALESRESTRICCIONID");
                        AnyError = 1;
                        GX_FocusControl = edtProfesionalesRestriccionId_Internalname;
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
                           E112Y2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122Y2 ();
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
            E122Y2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2Y143( ) ;
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
            DisableAttributes2Y143( ) ;
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

      protected void CONFIRM_2Y0( )
      {
         BeforeValidate2Y143( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2Y143( ) ;
            }
            else
            {
               CheckExtendedTable2Y143( ) ;
               CloseExtendedTableCursors2Y143( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2Y0( )
      {
      }

      protected void E112Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionalesRestriccion_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionalesRestriccion_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionalesRestriccion_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV18Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV18Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV19GXV1 = 1;
            AssignAttri("", false, "AV19GXV1", StringUtil.LTrimStr( (decimal)(AV19GXV1), 8, 0));
            while ( AV19GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV19GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "ProfesionalesId") == 0 )
               {
                  AV13Insert_ProfesionalesId = AV15TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV13Insert_ProfesionalesId", AV13Insert_ProfesionalesId);
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "Listaid") == 0 )
               {
                  AV14Insert_Listaid = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Insert_Listaid", StringUtil.LTrimStr( (decimal)(AV14Insert_Listaid), 18, 0));
               }
               AV19GXV1 = (int)(AV19GXV1+1);
               AssignAttri("", false, "AV19GXV1", StringUtil.LTrimStr( (decimal)(AV19GXV1), 8, 0));
            }
         }
      }

      protected void E122Y2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("profesionalesrestriccionww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM2Y143( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z973RestriccionesFechaAlta = T002Y3_A973RestriccionesFechaAlta[0];
               Z974RestriccionesEstado = T002Y3_A974RestriccionesEstado[0];
               Z975RestriccionesObservacion = T002Y3_A975RestriccionesObservacion[0];
               Z120ProfesionalesId = T002Y3_A120ProfesionalesId[0];
               Z590Listaid = T002Y3_A590Listaid[0];
            }
            else
            {
               Z973RestriccionesFechaAlta = A973RestriccionesFechaAlta;
               Z974RestriccionesEstado = A974RestriccionesEstado;
               Z975RestriccionesObservacion = A975RestriccionesObservacion;
               Z120ProfesionalesId = A120ProfesionalesId;
               Z590Listaid = A590Listaid;
            }
         }
         if ( GX_JID == -14 )
         {
            Z976ProfesionalesRestriccionId = A976ProfesionalesRestriccionId;
            Z973RestriccionesFechaAlta = A973RestriccionesFechaAlta;
            Z974RestriccionesEstado = A974RestriccionesEstado;
            Z975RestriccionesObservacion = A975RestriccionesObservacion;
            Z120ProfesionalesId = A120ProfesionalesId;
            Z590Listaid = A590Listaid;
            Z166ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
            Z167ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
            Z592ListaNombre = A592ListaNombre;
            Z593ListaEstado = A593ListaEstado;
            Z591ListaTipo = A591ListaTipo;
         }
      }

      protected void standaloneNotModal( )
      {
         edtProfesionalesRestriccionId_Enabled = 0;
         AssignProp("", false, edtProfesionalesRestriccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesRestriccionId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_120_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"profesionalesprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROFESIONALESID"+"'), id:'"+"PROFESIONALESID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"PROFESIONALESPRIMERNOMBRE"+"'), id:'"+"PROFESIONALESPRIMERNOMBRE"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_590_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"listaprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"LISTAID"+"'), id:'"+"LISTAID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"LISTANOMBRE"+"'), id:'"+"LISTANOMBRE"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtProfesionalesRestriccionId_Enabled = 0;
         AssignProp("", false, edtProfesionalesRestriccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesRestriccionId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ProfesionalesRestriccionId) )
         {
            A976ProfesionalesRestriccionId = AV7ProfesionalesRestriccionId;
            AssignAttri("", false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_ProfesionalesId)) )
         {
            edtProfesionalesId_Enabled = 0;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         }
         else
         {
            edtProfesionalesId_Enabled = 1;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_Listaid) )
         {
            edtListaid_Enabled = 0;
            AssignProp("", false, edtListaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaid_Enabled), 5, 0), true);
         }
         else
         {
            edtListaid_Enabled = 1;
            AssignProp("", false, edtListaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaid_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_Listaid) )
         {
            A590Listaid = AV14Insert_Listaid;
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_ProfesionalesId)) )
         {
            A120ProfesionalesId = AV13Insert_ProfesionalesId;
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
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
         if ( IsIns( )  && (DateTime.MinValue==A973RestriccionesFechaAlta) && ( Gx_BScreen == 0 ) )
         {
            A973RestriccionesFechaAlta = DateTimeUtil.ResetTime( Gx_date ) ;
            n973RestriccionesFechaAlta = false;
            AssignAttri("", false, "A973RestriccionesFechaAlta", context.localUtil.TToC( A973RestriccionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV18Pgmname = "ProfesionalesRestriccion";
            AssignAttri("", false, "AV18Pgmname", AV18Pgmname);
            /* Using cursor T002Y5 */
            pr_default.execute(3, new Object[] {A590Listaid});
            A592ListaNombre = T002Y5_A592ListaNombre[0];
            AssignAttri("", false, "A592ListaNombre", A592ListaNombre);
            A593ListaEstado = T002Y5_A593ListaEstado[0];
            n593ListaEstado = T002Y5_n593ListaEstado[0];
            AssignAttri("", false, "A593ListaEstado", A593ListaEstado);
            A591ListaTipo = T002Y5_A591ListaTipo[0];
            AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
            pr_default.close(3);
            /* Using cursor T002Y4 */
            pr_default.execute(2, new Object[] {A120ProfesionalesId});
            A166ProfesionalesPrimerNombre = T002Y4_A166ProfesionalesPrimerNombre[0];
            AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
            A167ProfesionalesApellidoPrimero = T002Y4_A167ProfesionalesApellidoPrimero[0];
            AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
            pr_default.close(2);
         }
      }

      protected void Load2Y143( )
      {
         /* Using cursor T002Y6 */
         pr_default.execute(4, new Object[] {A976ProfesionalesRestriccionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound143 = 1;
            A166ProfesionalesPrimerNombre = T002Y6_A166ProfesionalesPrimerNombre[0];
            AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
            A167ProfesionalesApellidoPrimero = T002Y6_A167ProfesionalesApellidoPrimero[0];
            AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
            A592ListaNombre = T002Y6_A592ListaNombre[0];
            AssignAttri("", false, "A592ListaNombre", A592ListaNombre);
            A593ListaEstado = T002Y6_A593ListaEstado[0];
            n593ListaEstado = T002Y6_n593ListaEstado[0];
            AssignAttri("", false, "A593ListaEstado", A593ListaEstado);
            A591ListaTipo = T002Y6_A591ListaTipo[0];
            AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
            A973RestriccionesFechaAlta = T002Y6_A973RestriccionesFechaAlta[0];
            n973RestriccionesFechaAlta = T002Y6_n973RestriccionesFechaAlta[0];
            AssignAttri("", false, "A973RestriccionesFechaAlta", context.localUtil.TToC( A973RestriccionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A974RestriccionesEstado = T002Y6_A974RestriccionesEstado[0];
            n974RestriccionesEstado = T002Y6_n974RestriccionesEstado[0];
            AssignAttri("", false, "A974RestriccionesEstado", A974RestriccionesEstado);
            A975RestriccionesObservacion = T002Y6_A975RestriccionesObservacion[0];
            n975RestriccionesObservacion = T002Y6_n975RestriccionesObservacion[0];
            AssignAttri("", false, "A975RestriccionesObservacion", A975RestriccionesObservacion);
            A120ProfesionalesId = T002Y6_A120ProfesionalesId[0];
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
            A590Listaid = T002Y6_A590Listaid[0];
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
            ZM2Y143( -14) ;
         }
         pr_default.close(4);
         OnLoadActions2Y143( ) ;
      }

      protected void OnLoadActions2Y143( )
      {
         AV18Pgmname = "ProfesionalesRestriccion";
         AssignAttri("", false, "AV18Pgmname", AV18Pgmname);
      }

      protected void CheckExtendedTable2Y143( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV18Pgmname = "ProfesionalesRestriccion";
         AssignAttri("", false, "AV18Pgmname", AV18Pgmname);
         /* Using cursor T002Y4 */
         pr_default.execute(2, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROFESIONALESID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A166ProfesionalesPrimerNombre = T002Y4_A166ProfesionalesPrimerNombre[0];
         AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
         A167ProfesionalesApellidoPrimero = T002Y4_A167ProfesionalesApellidoPrimero[0];
         AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
         pr_default.close(2);
         /* Using cursor T002Y5 */
         pr_default.execute(3, new Object[] {A590Listaid});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Lista", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LISTAID");
            AnyError = 1;
            GX_FocusControl = edtListaid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A592ListaNombre = T002Y5_A592ListaNombre[0];
         AssignAttri("", false, "A592ListaNombre", A592ListaNombre);
         A593ListaEstado = T002Y5_A593ListaEstado[0];
         n593ListaEstado = T002Y5_n593ListaEstado[0];
         AssignAttri("", false, "A593ListaEstado", A593ListaEstado);
         A591ListaTipo = T002Y5_A591ListaTipo[0];
         AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A973RestriccionesFechaAlta) || ( A973RestriccionesFechaAlta >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Restricciones Fecha Alta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "RESTRICCIONESFECHAALTA");
            AnyError = 1;
            GX_FocusControl = edtRestriccionesFechaAlta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A974RestriccionesEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A974RestriccionesEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A974RestriccionesEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A974RestriccionesEstado, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A974RestriccionesEstado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Restricciones Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "RESTRICCIONESESTADO");
            AnyError = 1;
            GX_FocusControl = cmbRestriccionesEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2Y143( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( string A120ProfesionalesId )
      {
         /* Using cursor T002Y7 */
         pr_default.execute(5, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROFESIONALESID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A166ProfesionalesPrimerNombre = T002Y7_A166ProfesionalesPrimerNombre[0];
         AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
         A167ProfesionalesApellidoPrimero = T002Y7_A167ProfesionalesApellidoPrimero[0];
         AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A166ProfesionalesPrimerNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A167ProfesionalesApellidoPrimero))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_16( long A590Listaid )
      {
         /* Using cursor T002Y8 */
         pr_default.execute(6, new Object[] {A590Listaid});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Lista", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LISTAID");
            AnyError = 1;
            GX_FocusControl = edtListaid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A592ListaNombre = T002Y8_A592ListaNombre[0];
         AssignAttri("", false, "A592ListaNombre", A592ListaNombre);
         A593ListaEstado = T002Y8_A593ListaEstado[0];
         n593ListaEstado = T002Y8_n593ListaEstado[0];
         AssignAttri("", false, "A593ListaEstado", A593ListaEstado);
         A591ListaTipo = T002Y8_A591ListaTipo[0];
         AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A592ListaNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A593ListaEstado))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A591ListaTipo))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey2Y143( )
      {
         /* Using cursor T002Y9 */
         pr_default.execute(7, new Object[] {A976ProfesionalesRestriccionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound143 = 1;
         }
         else
         {
            RcdFound143 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002Y3 */
         pr_default.execute(1, new Object[] {A976ProfesionalesRestriccionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2Y143( 14) ;
            RcdFound143 = 1;
            A976ProfesionalesRestriccionId = T002Y3_A976ProfesionalesRestriccionId[0];
            AssignAttri("", false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
            A973RestriccionesFechaAlta = T002Y3_A973RestriccionesFechaAlta[0];
            n973RestriccionesFechaAlta = T002Y3_n973RestriccionesFechaAlta[0];
            AssignAttri("", false, "A973RestriccionesFechaAlta", context.localUtil.TToC( A973RestriccionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A974RestriccionesEstado = T002Y3_A974RestriccionesEstado[0];
            n974RestriccionesEstado = T002Y3_n974RestriccionesEstado[0];
            AssignAttri("", false, "A974RestriccionesEstado", A974RestriccionesEstado);
            A975RestriccionesObservacion = T002Y3_A975RestriccionesObservacion[0];
            n975RestriccionesObservacion = T002Y3_n975RestriccionesObservacion[0];
            AssignAttri("", false, "A975RestriccionesObservacion", A975RestriccionesObservacion);
            A120ProfesionalesId = T002Y3_A120ProfesionalesId[0];
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
            A590Listaid = T002Y3_A590Listaid[0];
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
            Z976ProfesionalesRestriccionId = A976ProfesionalesRestriccionId;
            sMode143 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2Y143( ) ;
            if ( AnyError == 1 )
            {
               RcdFound143 = 0;
               InitializeNonKey2Y143( ) ;
            }
            Gx_mode = sMode143;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound143 = 0;
            InitializeNonKey2Y143( ) ;
            sMode143 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode143;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2Y143( ) ;
         if ( RcdFound143 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound143 = 0;
         /* Using cursor T002Y10 */
         pr_default.execute(8, new Object[] {A976ProfesionalesRestriccionId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T002Y10_A976ProfesionalesRestriccionId[0] < A976ProfesionalesRestriccionId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T002Y10_A976ProfesionalesRestriccionId[0] > A976ProfesionalesRestriccionId ) ) )
            {
               A976ProfesionalesRestriccionId = T002Y10_A976ProfesionalesRestriccionId[0];
               AssignAttri("", false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
               RcdFound143 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound143 = 0;
         /* Using cursor T002Y11 */
         pr_default.execute(9, new Object[] {A976ProfesionalesRestriccionId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T002Y11_A976ProfesionalesRestriccionId[0] > A976ProfesionalesRestriccionId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T002Y11_A976ProfesionalesRestriccionId[0] < A976ProfesionalesRestriccionId ) ) )
            {
               A976ProfesionalesRestriccionId = T002Y11_A976ProfesionalesRestriccionId[0];
               AssignAttri("", false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
               RcdFound143 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2Y143( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2Y143( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound143 == 1 )
            {
               if ( A976ProfesionalesRestriccionId != Z976ProfesionalesRestriccionId )
               {
                  A976ProfesionalesRestriccionId = Z976ProfesionalesRestriccionId;
                  AssignAttri("", false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROFESIONALESRESTRICCIONID");
                  AnyError = 1;
                  GX_FocusControl = edtProfesionalesRestriccionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProfesionalesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2Y143( ) ;
                  GX_FocusControl = edtProfesionalesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A976ProfesionalesRestriccionId != Z976ProfesionalesRestriccionId )
               {
                  /* Insert record */
                  GX_FocusControl = edtProfesionalesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2Y143( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROFESIONALESRESTRICCIONID");
                     AnyError = 1;
                     GX_FocusControl = edtProfesionalesRestriccionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtProfesionalesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2Y143( ) ;
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
         if ( A976ProfesionalesRestriccionId != Z976ProfesionalesRestriccionId )
         {
            A976ProfesionalesRestriccionId = Z976ProfesionalesRestriccionId;
            AssignAttri("", false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROFESIONALESRESTRICCIONID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesRestriccionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2Y143( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002Y2 */
            pr_default.execute(0, new Object[] {A976ProfesionalesRestriccionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesRestriccion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z973RestriccionesFechaAlta != T002Y2_A973RestriccionesFechaAlta[0] ) || ( StringUtil.StrCmp(Z974RestriccionesEstado, T002Y2_A974RestriccionesEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z975RestriccionesObservacion, T002Y2_A975RestriccionesObservacion[0]) != 0 ) || ( StringUtil.StrCmp(Z120ProfesionalesId, T002Y2_A120ProfesionalesId[0]) != 0 ) || ( Z590Listaid != T002Y2_A590Listaid[0] ) )
            {
               if ( Z973RestriccionesFechaAlta != T002Y2_A973RestriccionesFechaAlta[0] )
               {
                  GXUtil.WriteLog("profesionalesrestriccion:[seudo value changed for attri]"+"RestriccionesFechaAlta");
                  GXUtil.WriteLogRaw("Old: ",Z973RestriccionesFechaAlta);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A973RestriccionesFechaAlta[0]);
               }
               if ( StringUtil.StrCmp(Z974RestriccionesEstado, T002Y2_A974RestriccionesEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionalesrestriccion:[seudo value changed for attri]"+"RestriccionesEstado");
                  GXUtil.WriteLogRaw("Old: ",Z974RestriccionesEstado);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A974RestriccionesEstado[0]);
               }
               if ( StringUtil.StrCmp(Z975RestriccionesObservacion, T002Y2_A975RestriccionesObservacion[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionalesrestriccion:[seudo value changed for attri]"+"RestriccionesObservacion");
                  GXUtil.WriteLogRaw("Old: ",Z975RestriccionesObservacion);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A975RestriccionesObservacion[0]);
               }
               if ( StringUtil.StrCmp(Z120ProfesionalesId, T002Y2_A120ProfesionalesId[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionalesrestriccion:[seudo value changed for attri]"+"ProfesionalesId");
                  GXUtil.WriteLogRaw("Old: ",Z120ProfesionalesId);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A120ProfesionalesId[0]);
               }
               if ( Z590Listaid != T002Y2_A590Listaid[0] )
               {
                  GXUtil.WriteLog("profesionalesrestriccion:[seudo value changed for attri]"+"Listaid");
                  GXUtil.WriteLogRaw("Old: ",Z590Listaid);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A590Listaid[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProfesionalesRestriccion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2Y143( )
      {
         BeforeValidate2Y143( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Y143( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2Y143( 0) ;
            CheckOptimisticConcurrency2Y143( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Y143( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2Y143( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Y12 */
                     pr_default.execute(10, new Object[] {n973RestriccionesFechaAlta, A973RestriccionesFechaAlta, n974RestriccionesEstado, A974RestriccionesEstado, n975RestriccionesObservacion, A975RestriccionesObservacion, A120ProfesionalesId, A590Listaid});
                     A976ProfesionalesRestriccionId = T002Y12_A976ProfesionalesRestriccionId[0];
                     AssignAttri("", false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("ProfesionalesRestriccion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2Y0( ) ;
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
               Load2Y143( ) ;
            }
            EndLevel2Y143( ) ;
         }
         CloseExtendedTableCursors2Y143( ) ;
      }

      protected void Update2Y143( )
      {
         BeforeValidate2Y143( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Y143( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Y143( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Y143( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2Y143( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Y13 */
                     pr_default.execute(11, new Object[] {n973RestriccionesFechaAlta, A973RestriccionesFechaAlta, n974RestriccionesEstado, A974RestriccionesEstado, n975RestriccionesObservacion, A975RestriccionesObservacion, A120ProfesionalesId, A590Listaid, A976ProfesionalesRestriccionId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("ProfesionalesRestriccion");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesRestriccion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2Y143( ) ;
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
            EndLevel2Y143( ) ;
         }
         CloseExtendedTableCursors2Y143( ) ;
      }

      protected void DeferredUpdate2Y143( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2Y143( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Y143( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2Y143( ) ;
            AfterConfirm2Y143( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2Y143( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002Y14 */
                  pr_default.execute(12, new Object[] {A976ProfesionalesRestriccionId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("ProfesionalesRestriccion");
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
         sMode143 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2Y143( ) ;
         Gx_mode = sMode143;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2Y143( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV18Pgmname = "ProfesionalesRestriccion";
            AssignAttri("", false, "AV18Pgmname", AV18Pgmname);
            /* Using cursor T002Y15 */
            pr_default.execute(13, new Object[] {A120ProfesionalesId});
            A166ProfesionalesPrimerNombre = T002Y15_A166ProfesionalesPrimerNombre[0];
            AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
            A167ProfesionalesApellidoPrimero = T002Y15_A167ProfesionalesApellidoPrimero[0];
            AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
            pr_default.close(13);
            /* Using cursor T002Y16 */
            pr_default.execute(14, new Object[] {A590Listaid});
            A592ListaNombre = T002Y16_A592ListaNombre[0];
            AssignAttri("", false, "A592ListaNombre", A592ListaNombre);
            A593ListaEstado = T002Y16_A593ListaEstado[0];
            n593ListaEstado = T002Y16_n593ListaEstado[0];
            AssignAttri("", false, "A593ListaEstado", A593ListaEstado);
            A591ListaTipo = T002Y16_A591ListaTipo[0];
            AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
            pr_default.close(14);
         }
      }

      protected void EndLevel2Y143( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2Y143( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("profesionalesrestriccion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2Y0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.RollbackDataStores("profesionalesrestriccion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2Y143( )
      {
         /* Scan By routine */
         /* Using cursor T002Y17 */
         pr_default.execute(15);
         RcdFound143 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound143 = 1;
            A976ProfesionalesRestriccionId = T002Y17_A976ProfesionalesRestriccionId[0];
            AssignAttri("", false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2Y143( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound143 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound143 = 1;
            A976ProfesionalesRestriccionId = T002Y17_A976ProfesionalesRestriccionId[0];
            AssignAttri("", false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
         }
      }

      protected void ScanEnd2Y143( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm2Y143( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2Y143( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2Y143( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2Y143( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2Y143( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2Y143( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2Y143( )
      {
         edtProfesionalesRestriccionId_Enabled = 0;
         AssignProp("", false, edtProfesionalesRestriccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesRestriccionId_Enabled), 5, 0), true);
         edtProfesionalesId_Enabled = 0;
         AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         edtProfesionalesPrimerNombre_Enabled = 0;
         AssignProp("", false, edtProfesionalesPrimerNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0), true);
         edtProfesionalesApellidoPrimero_Enabled = 0;
         AssignProp("", false, edtProfesionalesApellidoPrimero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0), true);
         edtListaid_Enabled = 0;
         AssignProp("", false, edtListaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaid_Enabled), 5, 0), true);
         edtListaNombre_Enabled = 0;
         AssignProp("", false, edtListaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaNombre_Enabled), 5, 0), true);
         cmbListaEstado.Enabled = 0;
         AssignProp("", false, cmbListaEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbListaEstado.Enabled), 5, 0), true);
         cmbListaTipo.Enabled = 0;
         AssignProp("", false, cmbListaTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbListaTipo.Enabled), 5, 0), true);
         edtRestriccionesFechaAlta_Enabled = 0;
         AssignProp("", false, edtRestriccionesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRestriccionesFechaAlta_Enabled), 5, 0), true);
         cmbRestriccionesEstado.Enabled = 0;
         AssignProp("", false, cmbRestriccionesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbRestriccionesEstado.Enabled), 5, 0), true);
         edtRestriccionesObservacion_Enabled = 0;
         AssignProp("", false, edtRestriccionesObservacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRestriccionesObservacion_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2Y143( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2Y0( )
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
         GXEncryptionTmp = "profesionalesrestriccion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ProfesionalesRestriccionId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("profesionalesrestriccion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ProfesionalesRestriccion");
         forbiddenHiddens.Add("ProfesionalesRestriccionId", context.localUtil.Format( (decimal)(A976ProfesionalesRestriccionId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ProfesionalesId", StringUtil.RTrim( context.localUtil.Format( AV13Insert_ProfesionalesId, "")));
         forbiddenHiddens.Add("Insert_Listaid", context.localUtil.Format( (decimal)(AV14Insert_Listaid), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("profesionalesrestriccion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z976ProfesionalesRestriccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z976ProfesionalesRestriccionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z973RestriccionesFechaAlta", context.localUtil.TToC( Z973RestriccionesFechaAlta, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z974RestriccionesEstado", StringUtil.RTrim( Z974RestriccionesEstado));
         GxWebStd.gx_hidden_field( context, "Z975RestriccionesObservacion", Z975RestriccionesObservacion);
         GxWebStd.gx_hidden_field( context, "Z120ProfesionalesId", StringUtil.RTrim( Z120ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "Z590Listaid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z590Listaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N120ProfesionalesId", StringUtil.RTrim( A120ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "N590Listaid", StringUtil.LTrim( StringUtil.NToC( (decimal)(A590Listaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESRESTRICCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ProfesionalesRestriccionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESRESTRICCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProfesionalesRestriccionId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROFESIONALESID", StringUtil.RTrim( AV13Insert_ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "vINSERT_LISTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_Listaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV18Pgmname));
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
         GXEncryptionTmp = "profesionalesrestriccion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ProfesionalesRestriccionId,18,0));
         return formatLink("profesionalesrestriccion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ProfesionalesRestriccion" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Lista Profesionales Restriccion", "") ;
      }

      protected void InitializeNonKey2Y143( )
      {
         A120ProfesionalesId = "";
         AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
         A590Listaid = 0;
         AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
         A166ProfesionalesPrimerNombre = "";
         AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
         A167ProfesionalesApellidoPrimero = "";
         AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
         A592ListaNombre = "";
         AssignAttri("", false, "A592ListaNombre", A592ListaNombre);
         A593ListaEstado = "";
         n593ListaEstado = false;
         AssignAttri("", false, "A593ListaEstado", A593ListaEstado);
         A591ListaTipo = "";
         AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
         A974RestriccionesEstado = "";
         n974RestriccionesEstado = false;
         AssignAttri("", false, "A974RestriccionesEstado", A974RestriccionesEstado);
         n974RestriccionesEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A974RestriccionesEstado)) ? true : false);
         A975RestriccionesObservacion = "";
         n975RestriccionesObservacion = false;
         AssignAttri("", false, "A975RestriccionesObservacion", A975RestriccionesObservacion);
         n975RestriccionesObservacion = (String.IsNullOrEmpty(StringUtil.RTrim( A975RestriccionesObservacion)) ? true : false);
         A973RestriccionesFechaAlta = DateTimeUtil.ResetTime( Gx_date ) ;
         n973RestriccionesFechaAlta = false;
         AssignAttri("", false, "A973RestriccionesFechaAlta", context.localUtil.TToC( A973RestriccionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         Z973RestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         Z974RestriccionesEstado = "";
         Z975RestriccionesObservacion = "";
         Z120ProfesionalesId = "";
         Z590Listaid = 0;
      }

      protected void InitAll2Y143( )
      {
         A976ProfesionalesRestriccionId = 0;
         AssignAttri("", false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
         InitializeNonKey2Y143( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A973RestriccionesFechaAlta = i973RestriccionesFechaAlta;
         n973RestriccionesFechaAlta = false;
         AssignAttri("", false, "A973RestriccionesFechaAlta", context.localUtil.TToC( A973RestriccionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320113061", true, true, false);
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
         context.AddJavascriptSource("profesionalesrestriccion.js", "?20269320113061", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtProfesionalesRestriccionId_Internalname = "PROFESIONALESRESTRICCIONID";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO";
         edtListaid_Internalname = "LISTAID";
         edtListaNombre_Internalname = "LISTANOMBRE";
         cmbListaEstado_Internalname = "LISTAESTADO";
         cmbListaTipo_Internalname = "LISTATIPO";
         edtRestriccionesFechaAlta_Internalname = "RESTRICCIONESFECHAALTA";
         cmbRestriccionesEstado_Internalname = "RESTRICCIONESESTADO";
         edtRestriccionesObservacion_Internalname = "RESTRICCIONESOBSERVACION";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_120_Internalname = "PROMPT_120";
         imgprompt_590_Internalname = "PROMPT_590";
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
         Form.Caption = context.GetMessage( "Lista Profesionales Restriccion", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtRestriccionesObservacion_Jsonclick = "";
         edtRestriccionesObservacion_Enabled = 1;
         cmbRestriccionesEstado_Jsonclick = "";
         cmbRestriccionesEstado.Enabled = 1;
         edtRestriccionesFechaAlta_Jsonclick = "";
         edtRestriccionesFechaAlta_Enabled = 1;
         cmbListaTipo_Jsonclick = "";
         cmbListaTipo.Enabled = 0;
         cmbListaEstado_Jsonclick = "";
         cmbListaEstado.Enabled = 0;
         edtListaNombre_Jsonclick = "";
         edtListaNombre_Enabled = 0;
         imgprompt_590_Visible = 1;
         imgprompt_590_Link = "";
         edtListaid_Jsonclick = "";
         edtListaid_Enabled = 1;
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Enabled = 0;
         imgprompt_120_Visible = 1;
         imgprompt_120_Link = "";
         edtProfesionalesId_Jsonclick = "";
         edtProfesionalesId_Enabled = 1;
         edtProfesionalesRestriccionId_Jsonclick = "";
         edtProfesionalesRestriccionId_Enabled = 0;
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
         cmbListaEstado.Name = "LISTAESTADO";
         cmbListaEstado.WebTags = "";
         cmbListaEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbListaEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbListaEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbListaEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbListaEstado.ItemCount > 0 )
         {
            A593ListaEstado = cmbListaEstado.getValidValue(A593ListaEstado);
            n593ListaEstado = false;
            AssignAttri("", false, "A593ListaEstado", A593ListaEstado);
         }
         cmbListaTipo.Name = "LISTATIPO";
         cmbListaTipo.WebTags = "";
         cmbListaTipo.addItem("PROV", context.GetMessage( "Proveedor", ""), 0);
         cmbListaTipo.addItem("PROF", context.GetMessage( "Profesional", ""), 0);
         cmbListaTipo.addItem("ADM", context.GetMessage( "Administrativa", ""), 0);
         cmbListaTipo.addItem("RST", context.GetMessage( "Restriccion", ""), 0);
         if ( cmbListaTipo.ItemCount > 0 )
         {
            A591ListaTipo = cmbListaTipo.getValidValue(A591ListaTipo);
            AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
         }
         cmbRestriccionesEstado.Name = "RESTRICCIONESESTADO";
         cmbRestriccionesEstado.WebTags = "";
         cmbRestriccionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbRestriccionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbRestriccionesEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbRestriccionesEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbRestriccionesEstado.ItemCount > 0 )
         {
            A974RestriccionesEstado = cmbRestriccionesEstado.getValidValue(A974RestriccionesEstado);
            n974RestriccionesEstado = false;
            AssignAttri("", false, "A974RestriccionesEstado", A974RestriccionesEstado);
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

      public void Valid_Profesionalesid( )
      {
         /* Using cursor T002Y15 */
         pr_default.execute(13, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROFESIONALESID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
         }
         A166ProfesionalesPrimerNombre = T002Y15_A166ProfesionalesPrimerNombre[0];
         A167ProfesionalesApellidoPrimero = T002Y15_A167ProfesionalesApellidoPrimero[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A166ProfesionalesPrimerNombre", StringUtil.RTrim( A166ProfesionalesPrimerNombre));
         AssignAttri("", false, "A167ProfesionalesApellidoPrimero", StringUtil.RTrim( A167ProfesionalesApellidoPrimero));
      }

      public void Valid_Listaid( )
      {
         n593ListaEstado = false;
         A593ListaEstado = cmbListaEstado.CurrentValue;
         n593ListaEstado = false;
         cmbListaEstado.CurrentValue = A593ListaEstado;
         A591ListaTipo = cmbListaTipo.CurrentValue;
         cmbListaTipo.CurrentValue = A591ListaTipo;
         /* Using cursor T002Y16 */
         pr_default.execute(14, new Object[] {A590Listaid});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Lista", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LISTAID");
            AnyError = 1;
            GX_FocusControl = edtListaid_Internalname;
         }
         A592ListaNombre = T002Y16_A592ListaNombre[0];
         A593ListaEstado = T002Y16_A593ListaEstado[0];
         n593ListaEstado = T002Y16_n593ListaEstado[0];
         cmbListaEstado.CurrentValue = A593ListaEstado;
         A591ListaTipo = T002Y16_A591ListaTipo[0];
         cmbListaTipo.CurrentValue = A591ListaTipo;
         pr_default.close(14);
         dynload_actions( ) ;
         if ( cmbListaEstado.ItemCount > 0 )
         {
            A593ListaEstado = cmbListaEstado.getValidValue(A593ListaEstado);
            n593ListaEstado = false;
            cmbListaEstado.CurrentValue = A593ListaEstado;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbListaEstado.CurrentValue = StringUtil.RTrim( A593ListaEstado);
         }
         if ( cmbListaTipo.ItemCount > 0 )
         {
            A591ListaTipo = cmbListaTipo.getValidValue(A591ListaTipo);
            cmbListaTipo.CurrentValue = A591ListaTipo;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbListaTipo.CurrentValue = StringUtil.RTrim( A591ListaTipo);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A592ListaNombre", StringUtil.RTrim( A592ListaNombre));
         AssignAttri("", false, "A593ListaEstado", StringUtil.RTrim( A593ListaEstado));
         cmbListaEstado.CurrentValue = StringUtil.RTrim( A593ListaEstado);
         AssignProp("", false, cmbListaEstado_Internalname, "Values", cmbListaEstado.ToJavascriptSource(), true);
         AssignAttri("", false, "A591ListaTipo", StringUtil.RTrim( A591ListaTipo));
         cmbListaTipo.CurrentValue = StringUtil.RTrim( A591ListaTipo);
         AssignProp("", false, cmbListaTipo_Internalname, "Values", cmbListaTipo.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7ProfesionalesRestriccionId',fld:'vPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ProfesionalesRestriccionId',fld:'vPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A976ProfesionalesRestriccionId',fld:'PROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13Insert_ProfesionalesId',fld:'vINSERT_PROFESIONALESID',pic:'',type:'char'},{av:'AV14Insert_Listaid',fld:'vINSERT_LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E122Y2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESRESTRICCIONID","{handler:'Valid_Profesionalesrestriccionid',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESRESTRICCIONID",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'},{av:'A166ProfesionalesPrimerNombre',fld:'PROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'A167ProfesionalesApellidoPrimero',fld:'PROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'}]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[{av:'A166ProfesionalesPrimerNombre',fld:'PROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'A167ProfesionalesApellidoPrimero',fld:'PROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'}]}");
         setEventMetadata("VALID_LISTAID","{handler:'Valid_Listaid',iparms:[{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A592ListaNombre',fld:'LISTANOMBRE',pic:'',type:'char'},{av:'cmbListaEstado'},{av:'A593ListaEstado',fld:'LISTAESTADO',pic:'',type:'char'},{av:'cmbListaTipo'},{av:'A591ListaTipo',fld:'LISTATIPO',pic:'',type:'char'}]");
         setEventMetadata("VALID_LISTAID",",oparms:[{av:'A592ListaNombre',fld:'LISTANOMBRE',pic:'',type:'char'},{av:'cmbListaEstado'},{av:'A593ListaEstado',fld:'LISTAESTADO',pic:'',type:'char'},{av:'cmbListaTipo'},{av:'A591ListaTipo',fld:'LISTATIPO',pic:'',type:'char'}]}");
         setEventMetadata("VALID_RESTRICCIONESFECHAALTA","{handler:'Valid_Restriccionesfechaalta',iparms:[]");
         setEventMetadata("VALID_RESTRICCIONESFECHAALTA",",oparms:[]}");
         setEventMetadata("VALID_RESTRICCIONESESTADO","{handler:'Valid_Restriccionesestado',iparms:[]");
         setEventMetadata("VALID_RESTRICCIONESESTADO",",oparms:[]}");
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
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z973RestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         Z974RestriccionesEstado = "";
         Z975RestriccionesObservacion = "";
         Z120ProfesionalesId = "";
         N120ProfesionalesId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A120ProfesionalesId = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A593ListaEstado = "";
         A591ListaTipo = "";
         A974RestriccionesEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         imgprompt_120_gximage = "";
         sImgUrl = "";
         A166ProfesionalesPrimerNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         imgprompt_590_gximage = "";
         A592ListaNombre = "";
         A973RestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         A975RestriccionesObservacion = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV13Insert_ProfesionalesId = "";
         Gx_date = DateTime.MinValue;
         AV18Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode143 = "";
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
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z166ProfesionalesPrimerNombre = "";
         Z167ProfesionalesApellidoPrimero = "";
         Z592ListaNombre = "";
         Z593ListaEstado = "";
         Z591ListaTipo = "";
         T002Y5_A592ListaNombre = new string[] {""} ;
         T002Y5_A593ListaEstado = new string[] {""} ;
         T002Y5_n593ListaEstado = new bool[] {false} ;
         T002Y5_A591ListaTipo = new string[] {""} ;
         T002Y4_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T002Y4_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T002Y6_A976ProfesionalesRestriccionId = new long[1] ;
         T002Y6_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T002Y6_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T002Y6_A592ListaNombre = new string[] {""} ;
         T002Y6_A593ListaEstado = new string[] {""} ;
         T002Y6_n593ListaEstado = new bool[] {false} ;
         T002Y6_A591ListaTipo = new string[] {""} ;
         T002Y6_A973RestriccionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T002Y6_n973RestriccionesFechaAlta = new bool[] {false} ;
         T002Y6_A974RestriccionesEstado = new string[] {""} ;
         T002Y6_n974RestriccionesEstado = new bool[] {false} ;
         T002Y6_A975RestriccionesObservacion = new string[] {""} ;
         T002Y6_n975RestriccionesObservacion = new bool[] {false} ;
         T002Y6_A120ProfesionalesId = new string[] {""} ;
         T002Y6_A590Listaid = new long[1] ;
         T002Y7_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T002Y7_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T002Y8_A592ListaNombre = new string[] {""} ;
         T002Y8_A593ListaEstado = new string[] {""} ;
         T002Y8_n593ListaEstado = new bool[] {false} ;
         T002Y8_A591ListaTipo = new string[] {""} ;
         T002Y9_A976ProfesionalesRestriccionId = new long[1] ;
         T002Y3_A976ProfesionalesRestriccionId = new long[1] ;
         T002Y3_A973RestriccionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T002Y3_n973RestriccionesFechaAlta = new bool[] {false} ;
         T002Y3_A974RestriccionesEstado = new string[] {""} ;
         T002Y3_n974RestriccionesEstado = new bool[] {false} ;
         T002Y3_A975RestriccionesObservacion = new string[] {""} ;
         T002Y3_n975RestriccionesObservacion = new bool[] {false} ;
         T002Y3_A120ProfesionalesId = new string[] {""} ;
         T002Y3_A590Listaid = new long[1] ;
         T002Y10_A976ProfesionalesRestriccionId = new long[1] ;
         T002Y11_A976ProfesionalesRestriccionId = new long[1] ;
         T002Y2_A976ProfesionalesRestriccionId = new long[1] ;
         T002Y2_A973RestriccionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T002Y2_n973RestriccionesFechaAlta = new bool[] {false} ;
         T002Y2_A974RestriccionesEstado = new string[] {""} ;
         T002Y2_n974RestriccionesEstado = new bool[] {false} ;
         T002Y2_A975RestriccionesObservacion = new string[] {""} ;
         T002Y2_n975RestriccionesObservacion = new bool[] {false} ;
         T002Y2_A120ProfesionalesId = new string[] {""} ;
         T002Y2_A590Listaid = new long[1] ;
         T002Y12_A976ProfesionalesRestriccionId = new long[1] ;
         T002Y15_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T002Y15_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T002Y16_A592ListaNombre = new string[] {""} ;
         T002Y16_A593ListaEstado = new string[] {""} ;
         T002Y16_n593ListaEstado = new bool[] {false} ;
         T002Y16_A591ListaTipo = new string[] {""} ;
         T002Y17_A976ProfesionalesRestriccionId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i973RestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.profesionalesrestriccion__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionalesrestriccion__default(),
            new Object[][] {
                new Object[] {
               T002Y2_A976ProfesionalesRestriccionId, T002Y2_A973RestriccionesFechaAlta, T002Y2_n973RestriccionesFechaAlta, T002Y2_A974RestriccionesEstado, T002Y2_n974RestriccionesEstado, T002Y2_A975RestriccionesObservacion, T002Y2_n975RestriccionesObservacion, T002Y2_A120ProfesionalesId, T002Y2_A590Listaid
               }
               , new Object[] {
               T002Y3_A976ProfesionalesRestriccionId, T002Y3_A973RestriccionesFechaAlta, T002Y3_n973RestriccionesFechaAlta, T002Y3_A974RestriccionesEstado, T002Y3_n974RestriccionesEstado, T002Y3_A975RestriccionesObservacion, T002Y3_n975RestriccionesObservacion, T002Y3_A120ProfesionalesId, T002Y3_A590Listaid
               }
               , new Object[] {
               T002Y4_A166ProfesionalesPrimerNombre, T002Y4_A167ProfesionalesApellidoPrimero
               }
               , new Object[] {
               T002Y5_A592ListaNombre, T002Y5_A593ListaEstado, T002Y5_n593ListaEstado, T002Y5_A591ListaTipo
               }
               , new Object[] {
               T002Y6_A976ProfesionalesRestriccionId, T002Y6_A166ProfesionalesPrimerNombre, T002Y6_A167ProfesionalesApellidoPrimero, T002Y6_A592ListaNombre, T002Y6_A593ListaEstado, T002Y6_n593ListaEstado, T002Y6_A591ListaTipo, T002Y6_A973RestriccionesFechaAlta, T002Y6_n973RestriccionesFechaAlta, T002Y6_A974RestriccionesEstado,
               T002Y6_n974RestriccionesEstado, T002Y6_A975RestriccionesObservacion, T002Y6_n975RestriccionesObservacion, T002Y6_A120ProfesionalesId, T002Y6_A590Listaid
               }
               , new Object[] {
               T002Y7_A166ProfesionalesPrimerNombre, T002Y7_A167ProfesionalesApellidoPrimero
               }
               , new Object[] {
               T002Y8_A592ListaNombre, T002Y8_A593ListaEstado, T002Y8_n593ListaEstado, T002Y8_A591ListaTipo
               }
               , new Object[] {
               T002Y9_A976ProfesionalesRestriccionId
               }
               , new Object[] {
               T002Y10_A976ProfesionalesRestriccionId
               }
               , new Object[] {
               T002Y11_A976ProfesionalesRestriccionId
               }
               , new Object[] {
               T002Y12_A976ProfesionalesRestriccionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002Y15_A166ProfesionalesPrimerNombre, T002Y15_A167ProfesionalesApellidoPrimero
               }
               , new Object[] {
               T002Y16_A592ListaNombre, T002Y16_A593ListaEstado, T002Y16_n593ListaEstado, T002Y16_A591ListaTipo
               }
               , new Object[] {
               T002Y17_A976ProfesionalesRestriccionId
               }
            }
         );
         AV18Pgmname = "ProfesionalesRestriccion";
         Z973RestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         n973RestriccionesFechaAlta = false;
         A973RestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         n973RestriccionesFechaAlta = false;
         i973RestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         n973RestriccionesFechaAlta = false;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound143 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtProfesionalesRestriccionId_Enabled ;
      private int edtProfesionalesId_Enabled ;
      private int imgprompt_120_Visible ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtListaid_Enabled ;
      private int imgprompt_590_Visible ;
      private int edtListaNombre_Enabled ;
      private int edtRestriccionesFechaAlta_Enabled ;
      private int edtRestriccionesObservacion_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV19GXV1 ;
      private int idxLst ;
      private long wcpOAV7ProfesionalesRestriccionId ;
      private long Z976ProfesionalesRestriccionId ;
      private long Z590Listaid ;
      private long N590Listaid ;
      private long A590Listaid ;
      private long AV7ProfesionalesRestriccionId ;
      private long A976ProfesionalesRestriccionId ;
      private long AV14Insert_Listaid ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z974RestriccionesEstado ;
      private string Z120ProfesionalesId ;
      private string N120ProfesionalesId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A120ProfesionalesId ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProfesionalesId_Internalname ;
      private string A593ListaEstado ;
      private string cmbListaEstado_Internalname ;
      private string A591ListaTipo ;
      private string cmbListaTipo_Internalname ;
      private string A974RestriccionesEstado ;
      private string cmbRestriccionesEstado_Internalname ;
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
      private string edtProfesionalesRestriccionId_Internalname ;
      private string TempTags ;
      private string edtProfesionalesRestriccionId_Jsonclick ;
      private string edtProfesionalesId_Jsonclick ;
      private string imgprompt_120_gximage ;
      private string sImgUrl ;
      private string imgprompt_120_Internalname ;
      private string imgprompt_120_Link ;
      private string edtProfesionalesPrimerNombre_Internalname ;
      private string A166ProfesionalesPrimerNombre ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Internalname ;
      private string A167ProfesionalesApellidoPrimero ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtListaid_Internalname ;
      private string edtListaid_Jsonclick ;
      private string imgprompt_590_gximage ;
      private string imgprompt_590_Internalname ;
      private string imgprompt_590_Link ;
      private string edtListaNombre_Internalname ;
      private string A592ListaNombre ;
      private string edtListaNombre_Jsonclick ;
      private string cmbListaEstado_Jsonclick ;
      private string cmbListaTipo_Jsonclick ;
      private string edtRestriccionesFechaAlta_Internalname ;
      private string edtRestriccionesFechaAlta_Jsonclick ;
      private string cmbRestriccionesEstado_Jsonclick ;
      private string edtRestriccionesObservacion_Internalname ;
      private string edtRestriccionesObservacion_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV13Insert_ProfesionalesId ;
      private string AV18Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode143 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string Z166ProfesionalesPrimerNombre ;
      private string Z167ProfesionalesApellidoPrimero ;
      private string Z592ListaNombre ;
      private string Z593ListaEstado ;
      private string Z591ListaTipo ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z973RestriccionesFechaAlta ;
      private DateTime A973RestriccionesFechaAlta ;
      private DateTime i973RestriccionesFechaAlta ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n593ListaEstado ;
      private bool n974RestriccionesEstado ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n973RestriccionesFechaAlta ;
      private bool n975RestriccionesObservacion ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private string Z975RestriccionesObservacion ;
      private string A975RestriccionesObservacion ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbListaEstado ;
      private GXCombobox cmbListaTipo ;
      private GXCombobox cmbRestriccionesEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T002Y5_A592ListaNombre ;
      private string[] T002Y5_A593ListaEstado ;
      private bool[] T002Y5_n593ListaEstado ;
      private string[] T002Y5_A591ListaTipo ;
      private string[] T002Y4_A166ProfesionalesPrimerNombre ;
      private string[] T002Y4_A167ProfesionalesApellidoPrimero ;
      private long[] T002Y6_A976ProfesionalesRestriccionId ;
      private string[] T002Y6_A166ProfesionalesPrimerNombre ;
      private string[] T002Y6_A167ProfesionalesApellidoPrimero ;
      private string[] T002Y6_A592ListaNombre ;
      private string[] T002Y6_A593ListaEstado ;
      private bool[] T002Y6_n593ListaEstado ;
      private string[] T002Y6_A591ListaTipo ;
      private DateTime[] T002Y6_A973RestriccionesFechaAlta ;
      private bool[] T002Y6_n973RestriccionesFechaAlta ;
      private string[] T002Y6_A974RestriccionesEstado ;
      private bool[] T002Y6_n974RestriccionesEstado ;
      private string[] T002Y6_A975RestriccionesObservacion ;
      private bool[] T002Y6_n975RestriccionesObservacion ;
      private string[] T002Y6_A120ProfesionalesId ;
      private long[] T002Y6_A590Listaid ;
      private string[] T002Y7_A166ProfesionalesPrimerNombre ;
      private string[] T002Y7_A167ProfesionalesApellidoPrimero ;
      private string[] T002Y8_A592ListaNombre ;
      private string[] T002Y8_A593ListaEstado ;
      private bool[] T002Y8_n593ListaEstado ;
      private string[] T002Y8_A591ListaTipo ;
      private long[] T002Y9_A976ProfesionalesRestriccionId ;
      private long[] T002Y3_A976ProfesionalesRestriccionId ;
      private DateTime[] T002Y3_A973RestriccionesFechaAlta ;
      private bool[] T002Y3_n973RestriccionesFechaAlta ;
      private string[] T002Y3_A974RestriccionesEstado ;
      private bool[] T002Y3_n974RestriccionesEstado ;
      private string[] T002Y3_A975RestriccionesObservacion ;
      private bool[] T002Y3_n975RestriccionesObservacion ;
      private string[] T002Y3_A120ProfesionalesId ;
      private long[] T002Y3_A590Listaid ;
      private long[] T002Y10_A976ProfesionalesRestriccionId ;
      private long[] T002Y11_A976ProfesionalesRestriccionId ;
      private long[] T002Y2_A976ProfesionalesRestriccionId ;
      private DateTime[] T002Y2_A973RestriccionesFechaAlta ;
      private bool[] T002Y2_n973RestriccionesFechaAlta ;
      private string[] T002Y2_A974RestriccionesEstado ;
      private bool[] T002Y2_n974RestriccionesEstado ;
      private string[] T002Y2_A975RestriccionesObservacion ;
      private bool[] T002Y2_n975RestriccionesObservacion ;
      private string[] T002Y2_A120ProfesionalesId ;
      private long[] T002Y2_A590Listaid ;
      private long[] T002Y12_A976ProfesionalesRestriccionId ;
      private string[] T002Y15_A166ProfesionalesPrimerNombre ;
      private string[] T002Y15_A167ProfesionalesApellidoPrimero ;
      private string[] T002Y16_A592ListaNombre ;
      private string[] T002Y16_A593ListaEstado ;
      private bool[] T002Y16_n593ListaEstado ;
      private string[] T002Y16_A591ListaTipo ;
      private long[] T002Y17_A976ProfesionalesRestriccionId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class profesionalesrestriccion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class profesionalesrestriccion__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002Y2;
        prmT002Y2 = new Object[] {
        new ParDef("@ProfesionalesRestriccionId",GXType.Decimal,18,0)
        };
        Object[] prmT002Y3;
        prmT002Y3 = new Object[] {
        new ParDef("@ProfesionalesRestriccionId",GXType.Decimal,18,0)
        };
        Object[] prmT002Y4;
        prmT002Y4 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT002Y5;
        prmT002Y5 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT002Y6;
        prmT002Y6 = new Object[] {
        new ParDef("@ProfesionalesRestriccionId",GXType.Decimal,18,0)
        };
        Object[] prmT002Y7;
        prmT002Y7 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT002Y8;
        prmT002Y8 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT002Y9;
        prmT002Y9 = new Object[] {
        new ParDef("@ProfesionalesRestriccionId",GXType.Decimal,18,0)
        };
        Object[] prmT002Y10;
        prmT002Y10 = new Object[] {
        new ParDef("@ProfesionalesRestriccionId",GXType.Decimal,18,0)
        };
        Object[] prmT002Y11;
        prmT002Y11 = new Object[] {
        new ParDef("@ProfesionalesRestriccionId",GXType.Decimal,18,0)
        };
        Object[] prmT002Y12;
        prmT002Y12 = new Object[] {
        new ParDef("@RestriccionesFechaAlta",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@RestriccionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@RestriccionesObservacion",GXType.NVarChar,120,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT002Y13;
        prmT002Y13 = new Object[] {
        new ParDef("@RestriccionesFechaAlta",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@RestriccionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@RestriccionesObservacion",GXType.NVarChar,120,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesRestriccionId",GXType.Decimal,18,0)
        };
        Object[] prmT002Y14;
        prmT002Y14 = new Object[] {
        new ParDef("@ProfesionalesRestriccionId",GXType.Decimal,18,0)
        };
        Object[] prmT002Y15;
        prmT002Y15 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT002Y16;
        prmT002Y16 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT002Y17;
        prmT002Y17 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T002Y2", "SELECT [ProfesionalesRestriccionId], [RestriccionesFechaAlta], [RestriccionesEstado], [RestriccionesObservacion], [ProfesionalesId], [Listaid] FROM [ProfesionalesRestriccion] WITH (UPDLOCK) WHERE [ProfesionalesRestriccionId] = @ProfesionalesRestriccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y3", "SELECT [ProfesionalesRestriccionId], [RestriccionesFechaAlta], [RestriccionesEstado], [RestriccionesObservacion], [ProfesionalesId], [Listaid] FROM [ProfesionalesRestriccion] WHERE [ProfesionalesRestriccionId] = @ProfesionalesRestriccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y4", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesApellidoPrimero] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y5", "SELECT [ListaNombre], [ListaEstado], [ListaTipo] FROM [Lista] WHERE [Listaid] = @Listaid ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y6", "SELECT TM1.[ProfesionalesRestriccionId], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesApellidoPrimero], T3.[ListaNombre], T3.[ListaEstado], T3.[ListaTipo], TM1.[RestriccionesFechaAlta], TM1.[RestriccionesEstado], TM1.[RestriccionesObservacion], TM1.[ProfesionalesId], TM1.[Listaid] FROM (([ProfesionalesRestriccion] TM1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = TM1.[ProfesionalesId]) INNER JOIN [Lista] T3 ON T3.[Listaid] = TM1.[Listaid]) WHERE TM1.[ProfesionalesRestriccionId] = @ProfesionalesRestriccionId ORDER BY TM1.[ProfesionalesRestriccionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y7", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesApellidoPrimero] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y8", "SELECT [ListaNombre], [ListaEstado], [ListaTipo] FROM [Lista] WHERE [Listaid] = @Listaid ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y9", "SELECT [ProfesionalesRestriccionId] FROM [ProfesionalesRestriccion] WHERE [ProfesionalesRestriccionId] = @ProfesionalesRestriccionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y10", "SELECT TOP 1 [ProfesionalesRestriccionId] FROM [ProfesionalesRestriccion] WHERE ( [ProfesionalesRestriccionId] > @ProfesionalesRestriccionId) ORDER BY [ProfesionalesRestriccionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Y11", "SELECT TOP 1 [ProfesionalesRestriccionId] FROM [ProfesionalesRestriccion] WHERE ( [ProfesionalesRestriccionId] < @ProfesionalesRestriccionId) ORDER BY [ProfesionalesRestriccionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Y12", "INSERT INTO [ProfesionalesRestriccion]([RestriccionesFechaAlta], [RestriccionesEstado], [RestriccionesObservacion], [ProfesionalesId], [Listaid]) VALUES(@RestriccionesFechaAlta, @RestriccionesEstado, @RestriccionesObservacion, @ProfesionalesId, @Listaid); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Y13", "UPDATE [ProfesionalesRestriccion] SET [RestriccionesFechaAlta]=@RestriccionesFechaAlta, [RestriccionesEstado]=@RestriccionesEstado, [RestriccionesObservacion]=@RestriccionesObservacion, [ProfesionalesId]=@ProfesionalesId, [Listaid]=@Listaid  WHERE [ProfesionalesRestriccionId] = @ProfesionalesRestriccionId", GxErrorMask.GX_NOMASK,prmT002Y13)
           ,new CursorDef("T002Y14", "DELETE FROM [ProfesionalesRestriccion]  WHERE [ProfesionalesRestriccionId] = @ProfesionalesRestriccionId", GxErrorMask.GX_NOMASK,prmT002Y14)
           ,new CursorDef("T002Y15", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesApellidoPrimero] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y16", "SELECT [ListaNombre], [ListaEstado], [ListaTipo] FROM [Lista] WHERE [Listaid] = @Listaid ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y17", "SELECT [ProfesionalesRestriccionId] FROM [ProfesionalesRestriccion] ORDER BY [ProfesionalesRestriccionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y17,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 20);
              ((long[]) buf[8])[0] = rslt.getLong(6);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 20);
              ((long[]) buf[8])[0] = rslt.getLong(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 4);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 3);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getVarchar(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getString(10, 20);
              ((long[]) buf[14])[0] = rslt.getLong(11);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 4);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 4);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
