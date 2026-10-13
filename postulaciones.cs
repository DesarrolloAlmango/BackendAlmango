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
   public class postulaciones : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action16") == 0 )
         {
            A970PostulacionesSolicitudesId = (long)(Math.Round(NumberUtil.Val( GetPar( "PostulacionesSolicitudesId"), "."), 18, MidpointRounding.ToEven));
            n970PostulacionesSolicitudesId = false;
            AssignAttri("", false, "A970PostulacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(A970PostulacionesSolicitudesId), 18, 0));
            A422PostulacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "PostulacionesId"), "."), 18, MidpointRounding.ToEven));
            n422PostulacionesId = false;
            AssignAttri("", false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_16_1K126( A970PostulacionesSolicitudesId, A422PostulacionesId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_28") == 0 )
         {
            A942ServiciosId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServiciosId"), "."), 18, MidpointRounding.ToEven));
            n942ServiciosId = false;
            AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_28( A942ServiciosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_29") == 0 )
         {
            A945PostulacionesProveedorId = (long)(Math.Round(NumberUtil.Val( GetPar( "PostulacionesProveedorId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A945PostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(A945PostulacionesProveedorId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_29( A945PostulacionesProveedorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_31") == 0 )
         {
            A942ServiciosId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServiciosId"), "."), 18, MidpointRounding.ToEven));
            n942ServiciosId = false;
            AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
            A931CategoriasId = (long)(Math.Round(NumberUtil.Val( GetPar( "CategoriasId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_31( A942ServiciosId, A931CategoriasId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_34") == 0 )
         {
            A120ProfesionalesId = GetPar( "ProfesionalesId");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_34( A120ProfesionalesId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_multimedia") == 0 )
         {
            gxnrGridlevel_multimedia_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_profesionales") == 0 )
         {
            gxnrGridlevel_profesionales_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "postulaciones.aspx")), "postulaciones.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "postulaciones.aspx")))) ;
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
                  AV7PostulacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "PostulacionesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7PostulacionesId", StringUtil.LTrimStr( (decimal)(AV7PostulacionesId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPOSTULACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PostulacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Postulaciones", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPostulacionesApellidoNombre_Internalname;
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
         nRC_GXsfl_93 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_93"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_93_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_93_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_93_idx = GetPar( "sGXsfl_93_idx");
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

      protected void gxnrGridlevel_multimedia_newrow_invoke( )
      {
         nRC_GXsfl_103 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_103"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_103_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_103_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_103_idx = GetPar( "sGXsfl_103_idx");
         A961PostulacionesMultimediaSerial = (short)(Math.Round(NumberUtil.Val( GetPar( "PostulacionesMultimediaSerial"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_multimedia_newrow( ) ;
         /* End function gxnrGridlevel_multimedia_newrow_invoke */
      }

      protected void gxnrGridlevel_profesionales_newrow_invoke( )
      {
         nRC_GXsfl_115 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_115"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_115_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_115_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_115_idx = GetPar( "sGXsfl_115_idx");
         AV24VerMas = GetPar( "VerMas");
         edtavVermas_Tooltiptext = GetNextPar( );
         AssignProp("", false, edtavVermas_Internalname, "Tooltiptext", edtavVermas_Tooltiptext, !bGXsfl_115_Refreshing);
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_profesionales_newrow( ) ;
         /* End function gxnrGridlevel_profesionales_newrow_invoke */
      }

      public postulaciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public postulaciones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_PostulacionesId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PostulacionesId = aP1_PostulacionesId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkPostulacionesReqSuministros = new GXCheckbox();
         cmbPostulacionesRgoHoraservicio = new GXCombobox();
         cmbPostulacionProfesionalEstado = new GXCombobox();
         cmbPostulacionProfesionalUniE = new GXCombobox();
         cmbPostulacionProfesionalUniG = new GXCombobox();
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
         A937PostulacionesReqSuministros = StringUtil.StrToBool( StringUtil.BoolToStr( A937PostulacionesReqSuministros));
         AssignAttri("", false, "A937PostulacionesReqSuministros", A937PostulacionesReqSuministros);
         if ( cmbPostulacionesRgoHoraservicio.ItemCount > 0 )
         {
            A949PostulacionesRgoHoraservicio = cmbPostulacionesRgoHoraservicio.getValidValue(A949PostulacionesRgoHoraservicio);
            AssignAttri("", false, "A949PostulacionesRgoHoraservicio", A949PostulacionesRgoHoraservicio);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPostulacionesRgoHoraservicio.CurrentValue = StringUtil.RTrim( A949PostulacionesRgoHoraservicio);
            AssignProp("", false, cmbPostulacionesRgoHoraservicio_Internalname, "Values", cmbPostulacionesRgoHoraservicio.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesApellidoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostulacionesApellidoNombre_Internalname, context.GetMessage( "Apellido Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostulacionesApellidoNombre_Internalname, StringUtil.RTrim( A950PostulacionesApellidoNombre), StringUtil.RTrim( context.localUtil.Format( A950PostulacionesApellidoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesApellidoNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesApellidoNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Postulaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesMail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostulacionesMail_Internalname, context.GetMessage( "Mail", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostulacionesMail_Internalname, A951PostulacionesMail, StringUtil.RTrim( context.localUtil.Format( A951PostulacionesMail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A951PostulacionesMail, "", "", "", edtPostulacionesMail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesMail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Postulaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesTelefono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostulacionesTelefono_Internalname, context.GetMessage( "Telefono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A952PostulacionesTelefono);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostulacionesTelefono_Internalname, StringUtil.RTrim( A952PostulacionesTelefono), StringUtil.RTrim( context.localUtil.Format( A952PostulacionesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtPostulacionesTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Postulaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesProveedorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostulacionesProveedorId_Internalname, context.GetMessage( "Proveedor Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostulacionesProveedorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A945PostulacionesProveedorId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A945PostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesProveedorId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesProveedorId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Postulaciones.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_945_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_945_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_945_Internalname, sImgUrl, imgprompt_945_Link, "", "", context.GetTheme( ), imgprompt_945_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Postulaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesProveedorNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostulacionesProveedorNombre_Internalname, context.GetMessage( "Proveedor Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostulacionesProveedorNombre_Internalname, StringUtil.RTrim( A969PostulacionesProveedorNombre), StringUtil.RTrim( context.localUtil.Format( A969PostulacionesProveedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesProveedorNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesProveedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Postulaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesPrecio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostulacionesPrecio_Internalname, context.GetMessage( "Cotización", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostulacionesPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( A946PostulacionesPrecio, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPostulacionesPrecio_Enabled!=0) ? context.localUtil.Format( A946PostulacionesPrecio, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A946PostulacionesPrecio, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesPrecio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesPrecio_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_Postulaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostulacionesDescripcion_Internalname, context.GetMessage( "Descripción General", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPostulacionesDescripcion_Internalname, StringUtil.RTrim( A936PostulacionesDescripcion), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtPostulacionesDescripcion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Postulaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkPostulacionesReqSuministros_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkPostulacionesReqSuministros_Internalname, context.GetMessage( "¿Req. Suministros?", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkPostulacionesReqSuministros_Internalname, StringUtil.BoolToStr( A937PostulacionesReqSuministros), "", context.GetMessage( "¿Req. Suministros?", ""), 1, chkPostulacionesReqSuministros.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(54, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,54);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesSuministrosDescri_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostulacionesSuministrosDescri_Internalname, context.GetMessage( "Descripción de Suministros", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPostulacionesSuministrosDescri_Internalname, StringUtil.RTrim( A938PostulacionesSuministrosDescri), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", 0, 1, edtPostulacionesSuministrosDescri_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "Descripcion", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Postulaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesFechaCierre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostulacionesFechaCierre_Internalname, context.GetMessage( "Fecha Cierre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPostulacionesFechaCierre_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPostulacionesFechaCierre_Internalname, context.localUtil.Format(A939PostulacionesFechaCierre, "99/99/99"), context.localUtil.Format( A939PostulacionesFechaCierre, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesFechaCierre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesFechaCierre_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Postulaciones.htm");
         GxWebStd.gx_bitmap( context, edtPostulacionesFechaCierre_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPostulacionesFechaCierre_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Postulaciones.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesHoraCierre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostulacionesHoraCierre_Internalname, context.GetMessage( "Hora Cierre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostulacionesHoraCierre_Internalname, A940PostulacionesHoraCierre, StringUtil.RTrim( context.localUtil.Format( A940PostulacionesHoraCierre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesHoraCierre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesHoraCierre_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Postulaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesFechaTrabajo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostulacionesFechaTrabajo_Internalname, context.GetMessage( "Fecha Instalacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPostulacionesFechaTrabajo_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPostulacionesFechaTrabajo_Internalname, context.localUtil.Format(A947PostulacionesFechaTrabajo, "99/99/99"), context.localUtil.Format( A947PostulacionesFechaTrabajo, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesFechaTrabajo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesFechaTrabajo_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Postulaciones.htm");
         GxWebStd.gx_bitmap( context, edtPostulacionesFechaTrabajo_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPostulacionesFechaTrabajo_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Postulaciones.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbPostulacionesRgoHoraservicio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPostulacionesRgoHoraservicio_Internalname, context.GetMessage( "Hora Instalación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPostulacionesRgoHoraservicio, cmbPostulacionesRgoHoraservicio_Internalname, StringUtil.RTrim( A949PostulacionesRgoHoraservicio), 1, cmbPostulacionesRgoHoraservicio_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbPostulacionesRgoHoraservicio.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "", true, 0, "HLP_Postulaciones.htm");
         cmbPostulacionesRgoHoraservicio.CurrentValue = StringUtil.RTrim( A949PostulacionesRgoHoraservicio);
         AssignProp("", false, cmbPostulacionesRgoHoraservicio_Internalname, "Values", (string)(cmbPostulacionesRgoHoraservicio.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtServiciosNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtServiciosNombre_Internalname, context.GetMessage( "Servicio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtServiciosNombre_Internalname, StringUtil.RTrim( A943ServiciosNombre), StringUtil.RTrim( context.localUtil.Format( A943ServiciosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtServiciosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtServiciosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Postulaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesSolicitudesId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPostulacionesSolicitudesId_Internalname, context.GetMessage( "Solicitudes Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostulacionesSolicitudesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A970PostulacionesSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPostulacionesSolicitudesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A970PostulacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A970PostulacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,85);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesSolicitudesId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesSolicitudesId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Postulaciones.htm");
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
         /* User Defined Control */
         ucDvpanel_tableleaflevel_categorias.SetProperty("Width", Dvpanel_tableleaflevel_categorias_Width);
         ucDvpanel_tableleaflevel_categorias.SetProperty("AutoWidth", Dvpanel_tableleaflevel_categorias_Autowidth);
         ucDvpanel_tableleaflevel_categorias.SetProperty("AutoHeight", Dvpanel_tableleaflevel_categorias_Autoheight);
         ucDvpanel_tableleaflevel_categorias.SetProperty("Cls", Dvpanel_tableleaflevel_categorias_Cls);
         ucDvpanel_tableleaflevel_categorias.SetProperty("Title", Dvpanel_tableleaflevel_categorias_Title);
         ucDvpanel_tableleaflevel_categorias.SetProperty("Collapsible", Dvpanel_tableleaflevel_categorias_Collapsible);
         ucDvpanel_tableleaflevel_categorias.SetProperty("Collapsed", Dvpanel_tableleaflevel_categorias_Collapsed);
         ucDvpanel_tableleaflevel_categorias.SetProperty("ShowCollapseIcon", Dvpanel_tableleaflevel_categorias_Showcollapseicon);
         ucDvpanel_tableleaflevel_categorias.SetProperty("IconPosition", Dvpanel_tableleaflevel_categorias_Iconposition);
         ucDvpanel_tableleaflevel_categorias.SetProperty("AutoScroll", Dvpanel_tableleaflevel_categorias_Autoscroll);
         ucDvpanel_tableleaflevel_categorias.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableleaflevel_categorias_Internalname, "DVPANEL_TABLELEAFLEVEL_CATEGORIASContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLELEAFLEVEL_CATEGORIASContainer"+"TableLeafLevel_Categorias"+"\" style=\"display:none;\">") ;
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
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 CellMarginTop", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableleaflevel_multimedia.SetProperty("Width", Dvpanel_tableleaflevel_multimedia_Width);
         ucDvpanel_tableleaflevel_multimedia.SetProperty("AutoWidth", Dvpanel_tableleaflevel_multimedia_Autowidth);
         ucDvpanel_tableleaflevel_multimedia.SetProperty("AutoHeight", Dvpanel_tableleaflevel_multimedia_Autoheight);
         ucDvpanel_tableleaflevel_multimedia.SetProperty("Cls", Dvpanel_tableleaflevel_multimedia_Cls);
         ucDvpanel_tableleaflevel_multimedia.SetProperty("Title", Dvpanel_tableleaflevel_multimedia_Title);
         ucDvpanel_tableleaflevel_multimedia.SetProperty("Collapsible", Dvpanel_tableleaflevel_multimedia_Collapsible);
         ucDvpanel_tableleaflevel_multimedia.SetProperty("Collapsed", Dvpanel_tableleaflevel_multimedia_Collapsed);
         ucDvpanel_tableleaflevel_multimedia.SetProperty("ShowCollapseIcon", Dvpanel_tableleaflevel_multimedia_Showcollapseicon);
         ucDvpanel_tableleaflevel_multimedia.SetProperty("IconPosition", Dvpanel_tableleaflevel_multimedia_Iconposition);
         ucDvpanel_tableleaflevel_multimedia.SetProperty("AutoScroll", Dvpanel_tableleaflevel_multimedia_Autoscroll);
         ucDvpanel_tableleaflevel_multimedia.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableleaflevel_multimedia_Internalname, "DVPANEL_TABLELEAFLEVEL_MULTIMEDIAContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLELEAFLEVEL_MULTIMEDIAContainer"+"TableLeafLevel_Multimedia"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_multimedia_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_multimedia( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableleaflevel_profesionales.SetProperty("Width", Dvpanel_tableleaflevel_profesionales_Width);
         ucDvpanel_tableleaflevel_profesionales.SetProperty("AutoWidth", Dvpanel_tableleaflevel_profesionales_Autowidth);
         ucDvpanel_tableleaflevel_profesionales.SetProperty("AutoHeight", Dvpanel_tableleaflevel_profesionales_Autoheight);
         ucDvpanel_tableleaflevel_profesionales.SetProperty("Cls", Dvpanel_tableleaflevel_profesionales_Cls);
         ucDvpanel_tableleaflevel_profesionales.SetProperty("Title", Dvpanel_tableleaflevel_profesionales_Title);
         ucDvpanel_tableleaflevel_profesionales.SetProperty("Collapsible", Dvpanel_tableleaflevel_profesionales_Collapsible);
         ucDvpanel_tableleaflevel_profesionales.SetProperty("Collapsed", Dvpanel_tableleaflevel_profesionales_Collapsed);
         ucDvpanel_tableleaflevel_profesionales.SetProperty("ShowCollapseIcon", Dvpanel_tableleaflevel_profesionales_Showcollapseicon);
         ucDvpanel_tableleaflevel_profesionales.SetProperty("IconPosition", Dvpanel_tableleaflevel_profesionales_Iconposition);
         ucDvpanel_tableleaflevel_profesionales.SetProperty("AutoScroll", Dvpanel_tableleaflevel_profesionales_Autoscroll);
         ucDvpanel_tableleaflevel_profesionales.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableleaflevel_profesionales_Internalname, "DVPANEL_TABLELEAFLEVEL_PROFESIONALESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLELEAFLEVEL_PROFESIONALESContainer"+"TableLeafLevel_Profesionales"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_profesionales_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_profesionales( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Postulaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Postulaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Postulaciones.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostulacionesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPostulacionesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesId_Jsonclick, 0, "Attribute", "", "", "", "", edtPostulacionesId_Visible, edtPostulacionesId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Postulaciones.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtServiciosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A942ServiciosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A942ServiciosId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,142);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtServiciosId_Jsonclick, 0, "Attribute", "", "", "", "", edtServiciosId_Visible, edtServiciosId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Postulaciones.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_942_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_942_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_942_Internalname, sImgUrl, imgprompt_942_Link, "", "", context.GetTheme( ), imgprompt_942_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Postulaciones.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostulacionesTipoFecha_Internalname, A941PostulacionesTipoFecha, StringUtil.RTrim( context.localUtil.Format( A941PostulacionesTipoFecha, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,143);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesTipoFecha_Jsonclick, 0, "Attribute", "", "", "", "", edtPostulacionesTipoFecha_Visible, edtPostulacionesTipoFecha_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Postulaciones.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostulacionesEstado_Internalname, StringUtil.RTrim( A424PostulacionesEstado), StringUtil.RTrim( context.localUtil.Format( A424PostulacionesEstado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesEstado_Jsonclick, 0, "Attribute", "", "", "", "", edtPostulacionesEstado_Visible, edtPostulacionesEstado_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "Estado", "start", true, "", "HLP_Postulaciones.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPostulacionesFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPostulacionesFechaAlta_Internalname, context.localUtil.TToC( A425PostulacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A425PostulacionesFechaAlta, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,145);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesFechaAlta_Jsonclick, 0, "Attribute", "", "", "", "", edtPostulacionesFechaAlta_Visible, edtPostulacionesFechaAlta_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Postulaciones.htm");
         GxWebStd.gx_bitmap( context, edtPostulacionesFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtPostulacionesFechaAlta_Visible==0)||(edtPostulacionesFechaAlta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Postulaciones.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostulacionesSecUserId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A948PostulacionesSecUserId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPostulacionesSecUserId_Enabled!=0) ? context.localUtil.Format( (decimal)(A948PostulacionesSecUserId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A948PostulacionesSecUserId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesSecUserId_Jsonclick, 0, "Attribute", "", "", "", "", edtPostulacionesSecUserId_Visible, edtPostulacionesSecUserId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Postulaciones.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPostulacionesMultimediaSerial_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A961PostulacionesMultimediaSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPostulacionesMultimediaSerial_Enabled!=0) ? context.localUtil.Format( (decimal)(A961PostulacionesMultimediaSerial), "ZZZ9") : context.localUtil.Format( (decimal)(A961PostulacionesMultimediaSerial), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,147);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesMultimediaSerial_Jsonclick, 0, "Attribute", "", "", "", "", edtPostulacionesMultimediaSerial_Visible, edtPostulacionesMultimediaSerial_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Postulaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_categorias( )
      {
         /*  Grid Control  */
         StartGridControl93( ) ;
         nGXsfl_93_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount142 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_142 = 1;
               ScanStart1K142( ) ;
               while ( RcdFound142 != 0 )
               {
                  init_level_properties142( ) ;
                  getByPrimaryKey1K142( ) ;
                  AddRow1K142( ) ;
                  ScanNext1K142( ) ;
               }
               ScanEnd1K142( ) ;
               nBlankRcdCount142 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
            standaloneNotModal1K142( ) ;
            standaloneModal1K142( ) ;
            sMode142 = Gx_mode;
            while ( nGXsfl_93_idx < nRC_GXsfl_93 )
            {
               bGXsfl_93_Refreshing = true;
               ReadRow1K142( ) ;
               edtCategoriasId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORIASID_"+sGXsfl_93_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCategoriasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriasId_Enabled), 5, 0), !bGXsfl_93_Refreshing);
               edtCategoriasNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORIASNOMBRE_"+sGXsfl_93_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCategoriasNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriasNombre_Enabled), 5, 0), !bGXsfl_93_Refreshing);
               imgprompt_945_Link = cgiGet( "PROMPT_931_"+sGXsfl_93_idx+"Link");
               if ( ( nRcdExists_142 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1K142( ) ;
               }
               SendRow1K142( ) ;
               bGXsfl_93_Refreshing = false;
            }
            Gx_mode = sMode142;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A961PostulacionesMultimediaSerial = B961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount142 = 5;
            nRcdExists_142 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1K142( ) ;
               while ( RcdFound142 != 0 )
               {
                  sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_93142( ) ;
                  init_level_properties142( ) ;
                  standaloneNotModal1K142( ) ;
                  getByPrimaryKey1K142( ) ;
                  standaloneModal1K142( ) ;
                  AddRow1K142( ) ;
                  ScanNext1K142( ) ;
               }
               ScanEnd1K142( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode142 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx+1), 4, 0), 4, "0");
            SubsflControlProps_93142( ) ;
            InitAll1K142( ) ;
            init_level_properties142( ) ;
            B961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
            nRcdExists_142 = 0;
            nIsMod_142 = 0;
            nRcdDeleted_142 = 0;
            nBlankRcdCount142 = (short)(nBlankRcdUsr142+nBlankRcdCount142);
            fRowAdded = 0;
            while ( nBlankRcdCount142 > 0 )
            {
               standaloneNotModal1K142( ) ;
               standaloneModal1K142( ) ;
               AddRow1K142( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtCategoriasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount142 = (short)(nBlankRcdCount142-1);
            }
            Gx_mode = sMode142;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A961PostulacionesMultimediaSerial = B961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
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

      protected void gxdraw_Gridlevel_multimedia( )
      {
         /*  Grid Control  */
         StartGridControl103( ) ;
         nGXsfl_103_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount139 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_139 = 1;
               ScanStart1K139( ) ;
               while ( RcdFound139 != 0 )
               {
                  init_level_properties139( ) ;
                  getByPrimaryKey1K139( ) ;
                  AddRow1K139( ) ;
                  ScanNext1K139( ) ;
               }
               ScanEnd1K139( ) ;
               nBlankRcdCount139 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
            standaloneNotModal1K139( ) ;
            standaloneModal1K139( ) ;
            sMode139 = Gx_mode;
            while ( nGXsfl_103_idx < nRC_GXsfl_103 )
            {
               bGXsfl_103_Refreshing = true;
               ReadRow1K139( ) ;
               edtMultimediaId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MULTIMEDIAID_"+sGXsfl_103_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtMultimediaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMultimediaId_Enabled), 5, 0), !bGXsfl_103_Refreshing);
               edtMultimediaDireccion_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MULTIMEDIADIRECCION_"+sGXsfl_103_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtMultimediaDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMultimediaDireccion_Enabled), 5, 0), !bGXsfl_103_Refreshing);
               edtMultimediaDescripcion_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MULTIMEDIADESCRIPCION_"+sGXsfl_103_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtMultimediaDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMultimediaDescripcion_Enabled), 5, 0), !bGXsfl_103_Refreshing);
               edtMultimediaTipo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MULTIMEDIATIPO_"+sGXsfl_103_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtMultimediaTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMultimediaTipo_Enabled), 5, 0), !bGXsfl_103_Refreshing);
               if ( ( nRcdExists_139 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1K139( ) ;
               }
               SendRow1K139( ) ;
               bGXsfl_103_Refreshing = false;
            }
            Gx_mode = sMode139;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A961PostulacionesMultimediaSerial = B961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount139 = 5;
            nRcdExists_139 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1K139( ) ;
               while ( RcdFound139 != 0 )
               {
                  sGXsfl_103_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_103_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_103139( ) ;
                  init_level_properties139( ) ;
                  standaloneNotModal1K139( ) ;
                  getByPrimaryKey1K139( ) ;
                  standaloneModal1K139( ) ;
                  AddRow1K139( ) ;
                  ScanNext1K139( ) ;
               }
               ScanEnd1K139( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode139 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_103_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_103_idx+1), 4, 0), 4, "0");
            SubsflControlProps_103139( ) ;
            InitAll1K139( ) ;
            init_level_properties139( ) ;
            B961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
            nRcdExists_139 = 0;
            nIsMod_139 = 0;
            nRcdDeleted_139 = 0;
            nBlankRcdCount139 = (short)(nBlankRcdUsr139+nBlankRcdCount139);
            fRowAdded = 0;
            while ( nBlankRcdCount139 > 0 )
            {
               standaloneNotModal1K139( ) ;
               standaloneModal1K139( ) ;
               AddRow1K139( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtMultimediaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount139 = (short)(nBlankRcdCount139-1);
            }
            Gx_mode = sMode139;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A961PostulacionesMultimediaSerial = B961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_multimediaContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_multimedia", Gridlevel_multimediaContainer, subGridlevel_multimedia_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_multimediaContainerData", Gridlevel_multimediaContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_multimediaContainerData"+"V", Gridlevel_multimediaContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_multimediaContainerData"+"V"+"\" value='"+Gridlevel_multimediaContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridlevel_profesionales( )
      {
         /*  Grid Control  */
         StartGridControl115( ) ;
         nGXsfl_115_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount137 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_137 = 1;
               ScanStart1K137( ) ;
               while ( RcdFound137 != 0 )
               {
                  init_level_properties137( ) ;
                  getByPrimaryKey1K137( ) ;
                  AddRow1K137( ) ;
                  ScanNext1K137( ) ;
               }
               ScanEnd1K137( ) ;
               nBlankRcdCount137 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
            standaloneNotModal1K137( ) ;
            standaloneModal1K137( ) ;
            sMode137 = Gx_mode;
            while ( nGXsfl_115_idx < nRC_GXsfl_115 )
            {
               bGXsfl_115_Refreshing = true;
               ReadRow1K137( ) ;
               edtProfesionalesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESID_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_115_Refreshing);
               edtProfesionalesNombreCompleto_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESNOMBRECOMPLETO_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesNombreCompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesNombreCompleto_Enabled), 5, 0), !bGXsfl_115_Refreshing);
               cmbPostulacionProfesionalEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALESTADO_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbPostulacionProfesionalEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPostulacionProfesionalEstado.Enabled), 5, 0), !bGXsfl_115_Refreshing);
               edtPostulacionProfesionalFechaA_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALFECHAA_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPostulacionProfesionalFechaA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalFechaA_Enabled), 5, 0), !bGXsfl_115_Refreshing);
               edtPostulacionProfesionalPrecio_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALPRECIO_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPostulacionProfesionalPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalPrecio_Enabled), 5, 0), !bGXsfl_115_Refreshing);
               edtPostulacionProfesionalFechaT_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALFECHAT_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPostulacionProfesionalFechaT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalFechaT_Enabled), 5, 0), !bGXsfl_115_Refreshing);
               edtPostulacionProfesionalTurnoT_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALTURNOT_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPostulacionProfesionalTurnoT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalTurnoT_Enabled), 5, 0), !bGXsfl_115_Refreshing);
               edtPostulacionProfesionalPlazoE_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALPLAZOE_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPostulacionProfesionalPlazoE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalPlazoE_Enabled), 5, 0), !bGXsfl_115_Refreshing);
               cmbPostulacionProfesionalUniE.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALUNIE_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbPostulacionProfesionalUniE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPostulacionProfesionalUniE.Enabled), 5, 0), !bGXsfl_115_Refreshing);
               edtPostulacionProfesionalGar_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALGAR_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPostulacionProfesionalGar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalGar_Enabled), 5, 0), !bGXsfl_115_Refreshing);
               cmbPostulacionProfesionalUniG.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALUNIG_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbPostulacionProfesionalUniG_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPostulacionProfesionalUniG.Enabled), 5, 0), !bGXsfl_115_Refreshing);
               edtPostulacionProfesionalA_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALA_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPostulacionProfesionalA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalA_Enabled), 5, 0), !bGXsfl_115_Refreshing);
               edtavVermas_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vVERMAS_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtavVermas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVermas_Enabled), 5, 0), !bGXsfl_115_Refreshing);
               edtavVermas_Tooltiptext = cgiGet( "vVERMAS_"+sGXsfl_115_idx+"Tooltiptext");
               AssignProp("", false, edtavVermas_Internalname, "Tooltiptext", edtavVermas_Tooltiptext, !bGXsfl_115_Refreshing);
               edtavVermas_Visible = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vVERMAS_"+sGXsfl_115_idx+"Visible"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtavVermas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVermas_Visible), 5, 0), !bGXsfl_115_Refreshing);
               imgprompt_945_Link = cgiGet( "PROMPT_120_"+sGXsfl_115_idx+"Link");
               if ( ( nRcdExists_137 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1K137( ) ;
               }
               SendRow1K137( ) ;
               bGXsfl_115_Refreshing = false;
            }
            Gx_mode = sMode137;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A961PostulacionesMultimediaSerial = B961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount137 = 5;
            nRcdExists_137 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1K137( ) ;
               while ( RcdFound137 != 0 )
               {
                  sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_115137( ) ;
                  init_level_properties137( ) ;
                  standaloneNotModal1K137( ) ;
                  getByPrimaryKey1K137( ) ;
                  standaloneModal1K137( ) ;
                  AddRow1K137( ) ;
                  ScanNext1K137( ) ;
               }
               ScanEnd1K137( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode137 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx+1), 4, 0), 4, "0");
            SubsflControlProps_115137( ) ;
            InitAll1K137( ) ;
            init_level_properties137( ) ;
            B961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
            nRcdExists_137 = 0;
            nIsMod_137 = 0;
            nRcdDeleted_137 = 0;
            nBlankRcdCount137 = (short)(nBlankRcdUsr137+nBlankRcdCount137);
            fRowAdded = 0;
            while ( nBlankRcdCount137 > 0 )
            {
               standaloneNotModal1K137( ) ;
               standaloneModal1K137( ) ;
               AddRow1K137( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProfesionalesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount137 = (short)(nBlankRcdCount137-1);
            }
            Gx_mode = sMode137;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A961PostulacionesMultimediaSerial = B961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_profesionalesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_profesionales", Gridlevel_profesionalesContainer, subGridlevel_profesionales_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_profesionalesContainerData", Gridlevel_profesionalesContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_profesionalesContainerData"+"V", Gridlevel_profesionalesContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_profesionalesContainerData"+"V"+"\" value='"+Gridlevel_profesionalesContainer.GridValuesHidden()+"'/>") ;
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
         E111K2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z422PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z422PostulacionesId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z971PostulacionesProvNombreAux = cgiGet( "Z971PostulacionesProvNombreAux");
               Z946PostulacionesPrecio = context.localUtil.CToN( cgiGet( "Z946PostulacionesPrecio"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z961PostulacionesMultimediaSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z961PostulacionesMultimediaSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z936PostulacionesDescripcion = cgiGet( "Z936PostulacionesDescripcion");
               Z937PostulacionesReqSuministros = StringUtil.StrToBool( cgiGet( "Z937PostulacionesReqSuministros"));
               Z938PostulacionesSuministrosDescri = cgiGet( "Z938PostulacionesSuministrosDescri");
               Z947PostulacionesFechaTrabajo = context.localUtil.CToD( cgiGet( "Z947PostulacionesFechaTrabajo"), 0);
               Z939PostulacionesFechaCierre = context.localUtil.CToD( cgiGet( "Z939PostulacionesFechaCierre"), 0);
               Z940PostulacionesHoraCierre = cgiGet( "Z940PostulacionesHoraCierre");
               Z941PostulacionesTipoFecha = cgiGet( "Z941PostulacionesTipoFecha");
               Z949PostulacionesRgoHoraservicio = cgiGet( "Z949PostulacionesRgoHoraservicio");
               Z950PostulacionesApellidoNombre = cgiGet( "Z950PostulacionesApellidoNombre");
               Z951PostulacionesMail = cgiGet( "Z951PostulacionesMail");
               Z952PostulacionesTelefono = cgiGet( "Z952PostulacionesTelefono");
               Z979PostulacionesDepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z979PostulacionesDepartamentoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z980PostulacionesDepartamentoMunic = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z980PostulacionesDepartamentoMunic"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z981PostulacionesZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z981PostulacionesZonasID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z998PostulacionesDireccion = cgiGet( "Z998PostulacionesDireccion");
               Z425PostulacionesFechaAlta = context.localUtil.CToT( cgiGet( "Z425PostulacionesFechaAlta"), 0);
               Z424PostulacionesEstado = cgiGet( "Z424PostulacionesEstado");
               Z948PostulacionesSecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z948PostulacionesSecUserId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z942ServiciosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z942ServiciosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n942ServiciosId = ((0==A942ServiciosId) ? true : false);
               Z945PostulacionesProveedorId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z945PostulacionesProveedorId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A971PostulacionesProvNombreAux = cgiGet( "Z971PostulacionesProvNombreAux");
               A979PostulacionesDepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z979PostulacionesDepartamentoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A980PostulacionesDepartamentoMunic = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z980PostulacionesDepartamentoMunic"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A981PostulacionesZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z981PostulacionesZonasID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A998PostulacionesDireccion = cgiGet( "Z998PostulacionesDireccion");
               O961PostulacionesMultimediaSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O961PostulacionesMultimediaSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_93 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_93"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               nRC_GXsfl_103 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_103"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               nRC_GXsfl_115 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_115"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N942ServiciosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N942ServiciosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n942ServiciosId = ((0==A942ServiciosId) ? true : false);
               N945PostulacionesProveedorId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N945PostulacionesProveedorId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vPOSTULACIONESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV14Insert_ServiciosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SERVICIOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV14Insert_ServiciosId", StringUtil.LTrimStr( (decimal)(AV14Insert_ServiciosId), 18, 0));
               AV17Insert_PostulacionesProveedorId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_POSTULACIONESPROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV17Insert_PostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(AV17Insert_PostulacionesProveedorId), 18, 0));
               A971PostulacionesProvNombreAux = cgiGet( "POSTULACIONESPROVNOMBREAUX");
               A979PostulacionesDepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONESDEPARTAMENTOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A980PostulacionesDepartamentoMunic = (long)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONESDEPARTAMENTOMUNIC"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A981PostulacionesZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONESZONASID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A998PostulacionesDireccion = cgiGet( "POSTULACIONESDIRECCION");
               AV26Pgmname = cgiGet( "vPGMNAME");
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A167ProfesionalesApellidoPrimero = cgiGet( "PROFESIONALESAPELLIDOPRIMERO");
               A166ProfesionalesPrimerNombre = cgiGet( "PROFESIONALESPRIMERNOMBRE");
               A191ProfesionalesSegundoNombre = cgiGet( "PROFESIONALESSEGUNDONOMBRE");
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
               Dvpanel_tableleaflevel_categorias_Objectcall = cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Objectcall");
               Dvpanel_tableleaflevel_categorias_Class = cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Class");
               Dvpanel_tableleaflevel_categorias_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Enabled"));
               Dvpanel_tableleaflevel_categorias_Width = cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Width");
               Dvpanel_tableleaflevel_categorias_Height = cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Height");
               Dvpanel_tableleaflevel_categorias_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Autowidth"));
               Dvpanel_tableleaflevel_categorias_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Autoheight"));
               Dvpanel_tableleaflevel_categorias_Cls = cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Cls");
               Dvpanel_tableleaflevel_categorias_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Showheader"));
               Dvpanel_tableleaflevel_categorias_Title = cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Title");
               Dvpanel_tableleaflevel_categorias_Titletype = cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Titletype");
               Dvpanel_tableleaflevel_categorias_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Collapsible"));
               Dvpanel_tableleaflevel_categorias_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Collapsed"));
               Dvpanel_tableleaflevel_categorias_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Showcollapseicon"));
               Dvpanel_tableleaflevel_categorias_Iconposition = cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Iconposition");
               Dvpanel_tableleaflevel_categorias_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Autoscroll"));
               Dvpanel_tableleaflevel_categorias_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Visible"));
               Dvpanel_tableleaflevel_categorias_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Dvpanel_tableleaflevel_multimedia_Objectcall = cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Objectcall");
               Dvpanel_tableleaflevel_multimedia_Class = cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Class");
               Dvpanel_tableleaflevel_multimedia_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Enabled"));
               Dvpanel_tableleaflevel_multimedia_Width = cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Width");
               Dvpanel_tableleaflevel_multimedia_Height = cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Height");
               Dvpanel_tableleaflevel_multimedia_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Autowidth"));
               Dvpanel_tableleaflevel_multimedia_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Autoheight"));
               Dvpanel_tableleaflevel_multimedia_Cls = cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Cls");
               Dvpanel_tableleaflevel_multimedia_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Showheader"));
               Dvpanel_tableleaflevel_multimedia_Title = cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Title");
               Dvpanel_tableleaflevel_multimedia_Titletype = cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Titletype");
               Dvpanel_tableleaflevel_multimedia_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Collapsible"));
               Dvpanel_tableleaflevel_multimedia_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Collapsed"));
               Dvpanel_tableleaflevel_multimedia_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Showcollapseicon"));
               Dvpanel_tableleaflevel_multimedia_Iconposition = cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Iconposition");
               Dvpanel_tableleaflevel_multimedia_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Autoscroll"));
               Dvpanel_tableleaflevel_multimedia_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Visible"));
               Dvpanel_tableleaflevel_multimedia_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Dvpanel_tableleaflevel_profesionales_Objectcall = cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Objectcall");
               Dvpanel_tableleaflevel_profesionales_Class = cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Class");
               Dvpanel_tableleaflevel_profesionales_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Enabled"));
               Dvpanel_tableleaflevel_profesionales_Width = cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Width");
               Dvpanel_tableleaflevel_profesionales_Height = cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Height");
               Dvpanel_tableleaflevel_profesionales_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Autowidth"));
               Dvpanel_tableleaflevel_profesionales_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Autoheight"));
               Dvpanel_tableleaflevel_profesionales_Cls = cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Cls");
               Dvpanel_tableleaflevel_profesionales_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Showheader"));
               Dvpanel_tableleaflevel_profesionales_Title = cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Title");
               Dvpanel_tableleaflevel_profesionales_Titletype = cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Titletype");
               Dvpanel_tableleaflevel_profesionales_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Collapsible"));
               Dvpanel_tableleaflevel_profesionales_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Collapsed"));
               Dvpanel_tableleaflevel_profesionales_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Showcollapseicon"));
               Dvpanel_tableleaflevel_profesionales_Iconposition = cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Iconposition");
               Dvpanel_tableleaflevel_profesionales_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Autoscroll"));
               Dvpanel_tableleaflevel_profesionales_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Visible"));
               Dvpanel_tableleaflevel_profesionales_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A950PostulacionesApellidoNombre = cgiGet( edtPostulacionesApellidoNombre_Internalname);
               AssignAttri("", false, "A950PostulacionesApellidoNombre", A950PostulacionesApellidoNombre);
               A951PostulacionesMail = cgiGet( edtPostulacionesMail_Internalname);
               AssignAttri("", false, "A951PostulacionesMail", A951PostulacionesMail);
               A952PostulacionesTelefono = cgiGet( edtPostulacionesTelefono_Internalname);
               AssignAttri("", false, "A952PostulacionesTelefono", A952PostulacionesTelefono);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPostulacionesProveedorId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPostulacionesProveedorId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "POSTULACIONESPROVEEDORID");
                  AnyError = 1;
                  GX_FocusControl = edtPostulacionesProveedorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A945PostulacionesProveedorId = 0;
                  AssignAttri("", false, "A945PostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(A945PostulacionesProveedorId), 18, 0));
               }
               else
               {
                  A945PostulacionesProveedorId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesProveedorId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A945PostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(A945PostulacionesProveedorId), 18, 0));
               }
               A969PostulacionesProveedorNombre = cgiGet( edtPostulacionesProveedorNombre_Internalname);
               AssignAttri("", false, "A969PostulacionesProveedorNombre", A969PostulacionesProveedorNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPostulacionesPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPostulacionesPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "POSTULACIONESPRECIO");
                  AnyError = 1;
                  GX_FocusControl = edtPostulacionesPrecio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A946PostulacionesPrecio = 0;
                  AssignAttri("", false, "A946PostulacionesPrecio", StringUtil.LTrimStr( A946PostulacionesPrecio, 18, 2));
               }
               else
               {
                  A946PostulacionesPrecio = context.localUtil.CToN( cgiGet( edtPostulacionesPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  AssignAttri("", false, "A946PostulacionesPrecio", StringUtil.LTrimStr( A946PostulacionesPrecio, 18, 2));
               }
               A936PostulacionesDescripcion = cgiGet( edtPostulacionesDescripcion_Internalname);
               AssignAttri("", false, "A936PostulacionesDescripcion", A936PostulacionesDescripcion);
               A937PostulacionesReqSuministros = StringUtil.StrToBool( cgiGet( chkPostulacionesReqSuministros_Internalname));
               AssignAttri("", false, "A937PostulacionesReqSuministros", A937PostulacionesReqSuministros);
               A938PostulacionesSuministrosDescri = cgiGet( edtPostulacionesSuministrosDescri_Internalname);
               AssignAttri("", false, "A938PostulacionesSuministrosDescri", A938PostulacionesSuministrosDescri);
               if ( context.localUtil.VCDate( cgiGet( edtPostulacionesFechaCierre_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Postulaciones Fecha Cierre", "")}), 1, "POSTULACIONESFECHACIERRE");
                  AnyError = 1;
                  GX_FocusControl = edtPostulacionesFechaCierre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A939PostulacionesFechaCierre = DateTime.MinValue;
                  AssignAttri("", false, "A939PostulacionesFechaCierre", context.localUtil.Format(A939PostulacionesFechaCierre, "99/99/99"));
               }
               else
               {
                  A939PostulacionesFechaCierre = context.localUtil.CToD( cgiGet( edtPostulacionesFechaCierre_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A939PostulacionesFechaCierre", context.localUtil.Format(A939PostulacionesFechaCierre, "99/99/99"));
               }
               A940PostulacionesHoraCierre = cgiGet( edtPostulacionesHoraCierre_Internalname);
               AssignAttri("", false, "A940PostulacionesHoraCierre", A940PostulacionesHoraCierre);
               if ( context.localUtil.VCDate( cgiGet( edtPostulacionesFechaTrabajo_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Postulaciones Fecha Trabajo", "")}), 1, "POSTULACIONESFECHATRABAJO");
                  AnyError = 1;
                  GX_FocusControl = edtPostulacionesFechaTrabajo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A947PostulacionesFechaTrabajo = DateTime.MinValue;
                  AssignAttri("", false, "A947PostulacionesFechaTrabajo", context.localUtil.Format(A947PostulacionesFechaTrabajo, "99/99/99"));
               }
               else
               {
                  A947PostulacionesFechaTrabajo = context.localUtil.CToD( cgiGet( edtPostulacionesFechaTrabajo_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A947PostulacionesFechaTrabajo", context.localUtil.Format(A947PostulacionesFechaTrabajo, "99/99/99"));
               }
               cmbPostulacionesRgoHoraservicio.Name = cmbPostulacionesRgoHoraservicio_Internalname;
               cmbPostulacionesRgoHoraservicio.CurrentValue = cgiGet( cmbPostulacionesRgoHoraservicio_Internalname);
               A949PostulacionesRgoHoraservicio = cgiGet( cmbPostulacionesRgoHoraservicio_Internalname);
               AssignAttri("", false, "A949PostulacionesRgoHoraservicio", A949PostulacionesRgoHoraservicio);
               A943ServiciosNombre = cgiGet( edtServiciosNombre_Internalname);
               AssignAttri("", false, "A943ServiciosNombre", A943ServiciosNombre);
               A970PostulacionesSolicitudesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesSolicitudesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n970PostulacionesSolicitudesId = false;
               AssignAttri("", false, "A970PostulacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(A970PostulacionesSolicitudesId), 18, 0));
               A422PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n422PostulacionesId = false;
               AssignAttri("", false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtServiciosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtServiciosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERVICIOSID");
                  AnyError = 1;
                  GX_FocusControl = edtServiciosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A942ServiciosId = 0;
                  n942ServiciosId = false;
                  AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
               }
               else
               {
                  A942ServiciosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtServiciosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n942ServiciosId = false;
                  AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
               }
               n942ServiciosId = ((0==A942ServiciosId) ? true : false);
               A941PostulacionesTipoFecha = cgiGet( edtPostulacionesTipoFecha_Internalname);
               AssignAttri("", false, "A941PostulacionesTipoFecha", A941PostulacionesTipoFecha);
               A424PostulacionesEstado = cgiGet( edtPostulacionesEstado_Internalname);
               AssignAttri("", false, "A424PostulacionesEstado", A424PostulacionesEstado);
               if ( context.localUtil.VCDateTime( cgiGet( edtPostulacionesFechaAlta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha", "")}), 1, "POSTULACIONESFECHAALTA");
                  AnyError = 1;
                  GX_FocusControl = edtPostulacionesFechaAlta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A425PostulacionesFechaAlta", context.localUtil.TToC( A425PostulacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A425PostulacionesFechaAlta = context.localUtil.CToT( cgiGet( edtPostulacionesFechaAlta_Internalname));
                  AssignAttri("", false, "A425PostulacionesFechaAlta", context.localUtil.TToC( A425PostulacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtPostulacionesSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPostulacionesSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "POSTULACIONESSECUSERID");
                  AnyError = 1;
                  GX_FocusControl = edtPostulacionesSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A948PostulacionesSecUserId = 0;
                  AssignAttri("", false, "A948PostulacionesSecUserId", StringUtil.LTrimStr( (decimal)(A948PostulacionesSecUserId), 18, 0));
               }
               else
               {
                  A948PostulacionesSecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A948PostulacionesSecUserId", StringUtil.LTrimStr( (decimal)(A948PostulacionesSecUserId), 18, 0));
               }
               A961PostulacionesMultimediaSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesMultimediaSerial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Postulaciones");
               A422PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n422PostulacionesId = false;
               AssignAttri("", false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
               forbiddenHiddens.Add("PostulacionesId", context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ServiciosId", context.localUtil.Format( (decimal)(AV14Insert_ServiciosId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_PostulacionesProveedorId", context.localUtil.Format( (decimal)(AV17Insert_PostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("PostulacionesProvNombreAux", StringUtil.RTrim( context.localUtil.Format( A971PostulacionesProvNombreAux, "")));
               forbiddenHiddens.Add("PostulacionesDepartamentoId", context.localUtil.Format( (decimal)(A979PostulacionesDepartamentoId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("PostulacionesDepartamentoMunic", context.localUtil.Format( (decimal)(A980PostulacionesDepartamentoMunic), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("PostulacionesZonasID", context.localUtil.Format( (decimal)(A981PostulacionesZonasID), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("PostulacionesDireccion", StringUtil.RTrim( context.localUtil.Format( A998PostulacionesDireccion, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A422PostulacionesId != Z422PostulacionesId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("postulaciones:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               /* Check if conditions changed and reset current page numbers */
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
                  A422PostulacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "PostulacionesId"), "."), 18, MidpointRounding.ToEven));
                  n422PostulacionesId = false;
                  AssignAttri("", false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
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
                     sMode126 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode126;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound126 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1K0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "POSTULACIONESID");
                        AnyError = 1;
                        GX_FocusControl = edtPostulacionesId_Internalname;
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
                           E111K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121K2 ();
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
                        if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VVERMAS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VVERMAS.CLICK") == 0 ) )
                        {
                           nGXsfl_115_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
                           SubsflControlProps_115137( ) ;
                           A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                           A886ProfesionalesNombreCompleto = cgiGet( edtProfesionalesNombreCompleto_Internalname);
                           cmbPostulacionProfesionalEstado.Name = cmbPostulacionProfesionalEstado_Internalname;
                           cmbPostulacionProfesionalEstado.CurrentValue = cgiGet( cmbPostulacionProfesionalEstado_Internalname);
                           A956PostulacionProfesionalEstado = cgiGet( cmbPostulacionProfesionalEstado_Internalname);
                           A957PostulacionProfesionalFechaA = context.localUtil.CToT( cgiGet( edtPostulacionProfesionalFechaA_Internalname));
                           if ( ( ( context.localUtil.CToN( cgiGet( edtPostulacionProfesionalPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPostulacionProfesionalPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
                           {
                              GXCCtl = "POSTULACIONPROFESIONALPRECIO_" + sGXsfl_115_idx;
                              GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
                              AnyError = 1;
                              GX_FocusControl = edtPostulacionProfesionalPrecio_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                              wbErr = true;
                              A982PostulacionProfesionalPrecio = 0;
                              n982PostulacionProfesionalPrecio = false;
                           }
                           else
                           {
                              A982PostulacionProfesionalPrecio = context.localUtil.CToN( cgiGet( edtPostulacionProfesionalPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n982PostulacionProfesionalPrecio = false;
                           }
                           n982PostulacionProfesionalPrecio = ((Convert.ToDecimal(0)==A982PostulacionProfesionalPrecio) ? true : false);
                           if ( context.localUtil.VCDate( cgiGet( edtPostulacionProfesionalFechaT_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
                           {
                              GXCCtl = "POSTULACIONPROFESIONALFECHAT_" + sGXsfl_115_idx;
                              GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Postulacion Profesional Fecha T", "")}), 1, GXCCtl);
                              AnyError = 1;
                              GX_FocusControl = edtPostulacionProfesionalFechaT_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                              wbErr = true;
                              A958PostulacionProfesionalFechaT = DateTime.MinValue;
                           }
                           else
                           {
                              A958PostulacionProfesionalFechaT = context.localUtil.CToD( cgiGet( edtPostulacionProfesionalFechaT_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                           }
                           A959PostulacionProfesionalTurnoT = cgiGet( edtPostulacionProfesionalTurnoT_Internalname);
                           if ( ( ( context.localUtil.CToN( cgiGet( edtPostulacionProfesionalPlazoE_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPostulacionProfesionalPlazoE_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
                           {
                              GXCCtl = "POSTULACIONPROFESIONALPLAZOE_" + sGXsfl_115_idx;
                              GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
                              AnyError = 1;
                              GX_FocusControl = edtPostulacionProfesionalPlazoE_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                              wbErr = true;
                              A983PostulacionProfesionalPlazoE = 0;
                              n983PostulacionProfesionalPlazoE = false;
                           }
                           else
                           {
                              A983PostulacionProfesionalPlazoE = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionProfesionalPlazoE_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n983PostulacionProfesionalPlazoE = false;
                           }
                           n983PostulacionProfesionalPlazoE = ((0==A983PostulacionProfesionalPlazoE) ? true : false);
                           cmbPostulacionProfesionalUniE.Name = cmbPostulacionProfesionalUniE_Internalname;
                           cmbPostulacionProfesionalUniE.CurrentValue = cgiGet( cmbPostulacionProfesionalUniE_Internalname);
                           A986PostulacionProfesionalUniE = cgiGet( cmbPostulacionProfesionalUniE_Internalname);
                           n986PostulacionProfesionalUniE = false;
                           n986PostulacionProfesionalUniE = (String.IsNullOrEmpty(StringUtil.RTrim( A986PostulacionProfesionalUniE)) ? true : false);
                           if ( ( ( context.localUtil.CToN( cgiGet( edtPostulacionProfesionalGar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPostulacionProfesionalGar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
                           {
                              GXCCtl = "POSTULACIONPROFESIONALGAR_" + sGXsfl_115_idx;
                              GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
                              AnyError = 1;
                              GX_FocusControl = edtPostulacionProfesionalGar_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                              wbErr = true;
                              A985PostulacionProfesionalGar = 0;
                              n985PostulacionProfesionalGar = false;
                           }
                           else
                           {
                              A985PostulacionProfesionalGar = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionProfesionalGar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n985PostulacionProfesionalGar = false;
                           }
                           n985PostulacionProfesionalGar = ((0==A985PostulacionProfesionalGar) ? true : false);
                           cmbPostulacionProfesionalUniG.Name = cmbPostulacionProfesionalUniG_Internalname;
                           cmbPostulacionProfesionalUniG.CurrentValue = cgiGet( cmbPostulacionProfesionalUniG_Internalname);
                           A987PostulacionProfesionalUniG = cgiGet( cmbPostulacionProfesionalUniG_Internalname);
                           n987PostulacionProfesionalUniG = false;
                           n987PostulacionProfesionalUniG = (String.IsNullOrEmpty(StringUtil.RTrim( A987PostulacionProfesionalUniG)) ? true : false);
                           A984PostulacionProfesionalA = cgiGet( edtPostulacionProfesionalA_Internalname);
                           n984PostulacionProfesionalA = false;
                           n984PostulacionProfesionalA = (String.IsNullOrEmpty(StringUtil.RTrim( A984PostulacionProfesionalA)) ? true : false);
                           AV24VerMas = cgiGet( edtavVermas_Internalname);
                           AssignProp("", false, edtavVermas_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV24VerMas)) ? AV28Vermas_GXI : context.convertURL( context.PathToRelativeUrl( AV24VerMas))), !bGXsfl_115_Refreshing);
                           AssignProp("", false, edtavVermas_Internalname, "SrcSet", context.GetImageSrcSet( AV24VerMas), true);
                           GXCCtl = "Z120ProfesionalesId_" + sGXsfl_115_idx;
                           Z120ProfesionalesId = cgiGet( GXCCtl);
                           GXCCtl = "Z956PostulacionProfesionalEstado_" + sGXsfl_115_idx;
                           Z956PostulacionProfesionalEstado = cgiGet( GXCCtl);
                           GXCCtl = "Z957PostulacionProfesionalFechaA_" + sGXsfl_115_idx;
                           Z957PostulacionProfesionalFechaA = context.localUtil.CToT( cgiGet( GXCCtl), 0);
                           GXCCtl = "Z958PostulacionProfesionalFechaT_" + sGXsfl_115_idx;
                           Z958PostulacionProfesionalFechaT = context.localUtil.CToD( cgiGet( GXCCtl), 0);
                           GXCCtl = "Z959PostulacionProfesionalTurnoT_" + sGXsfl_115_idx;
                           Z959PostulacionProfesionalTurnoT = cgiGet( GXCCtl);
                           GXCCtl = "Z982PostulacionProfesionalPrecio_" + sGXsfl_115_idx;
                           Z982PostulacionProfesionalPrecio = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                           n982PostulacionProfesionalPrecio = ((Convert.ToDecimal(0)==A982PostulacionProfesionalPrecio) ? true : false);
                           GXCCtl = "Z983PostulacionProfesionalPlazoE_" + sGXsfl_115_idx;
                           Z983PostulacionProfesionalPlazoE = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           n983PostulacionProfesionalPlazoE = ((0==A983PostulacionProfesionalPlazoE) ? true : false);
                           GXCCtl = "Z986PostulacionProfesionalUniE_" + sGXsfl_115_idx;
                           Z986PostulacionProfesionalUniE = cgiGet( GXCCtl);
                           n986PostulacionProfesionalUniE = (String.IsNullOrEmpty(StringUtil.RTrim( A986PostulacionProfesionalUniE)) ? true : false);
                           GXCCtl = "Z985PostulacionProfesionalGar_" + sGXsfl_115_idx;
                           Z985PostulacionProfesionalGar = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           n985PostulacionProfesionalGar = ((0==A985PostulacionProfesionalGar) ? true : false);
                           GXCCtl = "Z987PostulacionProfesionalUniG_" + sGXsfl_115_idx;
                           Z987PostulacionProfesionalUniG = cgiGet( GXCCtl);
                           n987PostulacionProfesionalUniG = (String.IsNullOrEmpty(StringUtil.RTrim( A987PostulacionProfesionalUniG)) ? true : false);
                           GXCCtl = "Z984PostulacionProfesionalA_" + sGXsfl_115_idx;
                           Z984PostulacionProfesionalA = cgiGet( GXCCtl);
                           n984PostulacionProfesionalA = (String.IsNullOrEmpty(StringUtil.RTrim( A984PostulacionProfesionalA)) ? true : false);
                           GXCCtl = "nRcdDeleted_137_" + sGXsfl_115_idx;
                           nRcdDeleted_137 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           GXCCtl = "nRcdExists_137_" + sGXsfl_115_idx;
                           nRcdExists_137 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           GXCCtl = "nIsMod_137_" + sGXsfl_115_idx;
                           nIsMod_137 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           sEvtType = StringUtil.Right( sEvt, 1);
                           if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                           {
                              sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                              if ( StringUtil.StrCmp(sEvt, "VVERMAS.CLICK") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 E131K2 ();
                              }
                           }
                           else
                           {
                           }
                        }
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
            E121K2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1K126( ) ;
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
            DisableAttributes1K126( ) ;
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

      protected void CONFIRM_1K0( )
      {
         BeforeValidate1K126( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1K126( ) ;
            }
            else
            {
               CheckExtendedTable1K126( ) ;
               CloseExtendedTableCursors1K126( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode126 = Gx_mode;
            CONFIRM_1K142( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_1K139( ) ;
               if ( AnyError == 0 )
               {
                  CONFIRM_1K137( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Restore parent mode. */
                     Gx_mode = sMode126;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     IsConfirmed = 1;
                     AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                  }
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode126;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_1K137( )
      {
         nGXsfl_115_idx = 0;
         while ( nGXsfl_115_idx < nRC_GXsfl_115 )
         {
            ReadRow1K137( ) ;
            if ( ( nRcdExists_137 != 0 ) || ( nIsMod_137 != 0 ) )
            {
               GetKey1K137( ) ;
               if ( ( nRcdExists_137 == 0 ) && ( nRcdDeleted_137 == 0 ) )
               {
                  if ( RcdFound137 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1K137( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1K137( ) ;
                        CloseExtendedTableCursors1K137( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PROFESIONALESID_" + sGXsfl_115_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProfesionalesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound137 != 0 )
                  {
                     if ( nRcdDeleted_137 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1K137( ) ;
                        Load1K137( ) ;
                        BeforeValidate1K137( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1K137( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_137 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1K137( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1K137( ) ;
                              CloseExtendedTableCursors1K137( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_137 == 0 )
                     {
                        GXCCtl = "PROFESIONALESID_" + sGXsfl_115_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProfesionalesId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProfesionalesId_Internalname, StringUtil.RTrim( A120ProfesionalesId)) ;
            ChangePostValue( edtProfesionalesNombreCompleto_Internalname, A886ProfesionalesNombreCompleto) ;
            ChangePostValue( cmbPostulacionProfesionalEstado_Internalname, StringUtil.RTrim( A956PostulacionProfesionalEstado)) ;
            ChangePostValue( edtPostulacionProfesionalFechaA_Internalname, context.localUtil.TToC( A957PostulacionProfesionalFechaA, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( edtPostulacionProfesionalPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( A982PostulacionProfesionalPrecio, 21, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtPostulacionProfesionalFechaT_Internalname, context.localUtil.Format(A958PostulacionProfesionalFechaT, "99/99/99")) ;
            ChangePostValue( edtPostulacionProfesionalTurnoT_Internalname, StringUtil.RTrim( A959PostulacionProfesionalTurnoT)) ;
            ChangePostValue( edtPostulacionProfesionalPlazoE_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A983PostulacionProfesionalPlazoE), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbPostulacionProfesionalUniE_Internalname, StringUtil.RTrim( A986PostulacionProfesionalUniE)) ;
            ChangePostValue( edtPostulacionProfesionalGar_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A985PostulacionProfesionalGar), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbPostulacionProfesionalUniG_Internalname, StringUtil.RTrim( A987PostulacionProfesionalUniG)) ;
            ChangePostValue( edtPostulacionProfesionalA_Internalname, A984PostulacionProfesionalA) ;
            ChangePostValue( edtavVermas_Internalname, AV24VerMas) ;
            ChangePostValue( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_115_idx, StringUtil.RTrim( Z120ProfesionalesId)) ;
            ChangePostValue( "ZT_"+"Z956PostulacionProfesionalEstado_"+sGXsfl_115_idx, StringUtil.RTrim( Z956PostulacionProfesionalEstado)) ;
            ChangePostValue( "ZT_"+"Z957PostulacionProfesionalFechaA_"+sGXsfl_115_idx, context.localUtil.TToC( Z957PostulacionProfesionalFechaA, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z958PostulacionProfesionalFechaT_"+sGXsfl_115_idx, context.localUtil.DToC( Z958PostulacionProfesionalFechaT, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z959PostulacionProfesionalTurnoT_"+sGXsfl_115_idx, StringUtil.RTrim( Z959PostulacionProfesionalTurnoT)) ;
            ChangePostValue( "ZT_"+"Z982PostulacionProfesionalPrecio_"+sGXsfl_115_idx, StringUtil.LTrim( StringUtil.NToC( Z982PostulacionProfesionalPrecio, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z983PostulacionProfesionalPlazoE_"+sGXsfl_115_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z983PostulacionProfesionalPlazoE), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z986PostulacionProfesionalUniE_"+sGXsfl_115_idx, StringUtil.RTrim( Z986PostulacionProfesionalUniE)) ;
            ChangePostValue( "ZT_"+"Z985PostulacionProfesionalGar_"+sGXsfl_115_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z985PostulacionProfesionalGar), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z987PostulacionProfesionalUniG_"+sGXsfl_115_idx, StringUtil.RTrim( Z987PostulacionProfesionalUniG)) ;
            ChangePostValue( "ZT_"+"Z984PostulacionProfesionalA_"+sGXsfl_115_idx, Z984PostulacionProfesionalA) ;
            ChangePostValue( "nRcdDeleted_137_"+sGXsfl_115_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_137), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_137_"+sGXsfl_115_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_137), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_137_"+sGXsfl_115_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_137), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_137 != 0 )
            {
               ChangePostValue( "PROFESIONALESID_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESNOMBRECOMPLETO_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesNombreCompleto_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALESTADO_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPostulacionProfesionalEstado.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALFECHAA_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalFechaA_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALPRECIO_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalPrecio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALFECHAT_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalFechaT_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALTURNOT_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalTurnoT_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALPLAZOE_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalPlazoE_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALUNIE_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPostulacionProfesionalUniE.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALGAR_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalGar_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALUNIG_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPostulacionProfesionalUniG.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALA_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalA_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "vVERMAS_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVermas_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "vVERMAS_"+sGXsfl_115_idx+"Tooltiptext", StringUtil.RTrim( edtavVermas_Tooltiptext)) ;
               ChangePostValue( "vVERMAS_"+sGXsfl_115_idx+"Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVermas_Visible), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_1K139( )
      {
         s961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
         AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
         nGXsfl_103_idx = 0;
         while ( nGXsfl_103_idx < nRC_GXsfl_103 )
         {
            ReadRow1K139( ) ;
            if ( ( nRcdExists_139 != 0 ) || ( nIsMod_139 != 0 ) )
            {
               GetKey1K139( ) ;
               if ( ( nRcdExists_139 == 0 ) && ( nRcdDeleted_139 == 0 ) )
               {
                  if ( RcdFound139 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1K139( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1K139( ) ;
                        CloseExtendedTableCursors1K139( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
                        AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "MULTIMEDIAID_" + sGXsfl_103_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtMultimediaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound139 != 0 )
                  {
                     if ( nRcdDeleted_139 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1K139( ) ;
                        Load1K139( ) ;
                        BeforeValidate1K139( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1K139( ) ;
                           O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
                           AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_139 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1K139( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1K139( ) ;
                              CloseExtendedTableCursors1K139( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
                              AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_139 == 0 )
                     {
                        GXCCtl = "MULTIMEDIAID_" + sGXsfl_103_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtMultimediaId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtMultimediaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A932MultimediaId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtMultimediaDireccion_Internalname, StringUtil.RTrim( A933MultimediaDireccion)) ;
            ChangePostValue( edtMultimediaDescripcion_Internalname, StringUtil.RTrim( A960MultimediaDescripcion)) ;
            ChangePostValue( edtMultimediaTipo_Internalname, A934MultimediaTipo) ;
            ChangePostValue( "ZT_"+"Z932MultimediaId_"+sGXsfl_103_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z932MultimediaId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z933MultimediaDireccion_"+sGXsfl_103_idx, StringUtil.RTrim( Z933MultimediaDireccion)) ;
            ChangePostValue( "ZT_"+"Z960MultimediaDescripcion_"+sGXsfl_103_idx, StringUtil.RTrim( Z960MultimediaDescripcion)) ;
            ChangePostValue( "ZT_"+"Z934MultimediaTipo_"+sGXsfl_103_idx, Z934MultimediaTipo) ;
            ChangePostValue( "nRcdDeleted_139_"+sGXsfl_103_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_139), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_139_"+sGXsfl_103_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_139), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_139_"+sGXsfl_103_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_139), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_139 != 0 )
            {
               ChangePostValue( "MULTIMEDIAID_"+sGXsfl_103_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MULTIMEDIADIRECCION_"+sGXsfl_103_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaDireccion_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MULTIMEDIADESCRIPCION_"+sGXsfl_103_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaDescripcion_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MULTIMEDIATIPO_"+sGXsfl_103_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaTipo_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O961PostulacionesMultimediaSerial = s961PostulacionesMultimediaSerial;
         AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_1K142( )
      {
         nGXsfl_93_idx = 0;
         while ( nGXsfl_93_idx < nRC_GXsfl_93 )
         {
            ReadRow1K142( ) ;
            if ( ( nRcdExists_142 != 0 ) || ( nIsMod_142 != 0 ) )
            {
               GetKey1K142( ) ;
               if ( ( nRcdExists_142 == 0 ) && ( nRcdDeleted_142 == 0 ) )
               {
                  if ( RcdFound142 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1K142( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1K142( ) ;
                        CloseExtendedTableCursors1K142( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CATEGORIASID_" + sGXsfl_93_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCategoriasId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound142 != 0 )
                  {
                     if ( nRcdDeleted_142 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1K142( ) ;
                        Load1K142( ) ;
                        BeforeValidate1K142( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1K142( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_142 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1K142( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1K142( ) ;
                              CloseExtendedTableCursors1K142( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_142 == 0 )
                     {
                        GXCCtl = "CATEGORIASID_" + sGXsfl_93_idx;
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
            ChangePostValue( "ZT_"+"Z931CategoriasId_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z931CategoriasId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_142_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_142), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_142_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_142), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_142_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_142), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_142 != 0 )
            {
               ChangePostValue( "CATEGORIASID_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriasId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORIASNOMBRE_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriasNombre_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1K0( )
      {
      }

      protected void E111K2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10IsAuthorized = true;
         AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPostulaciones_Insert", out  GXt_boolean1) ;
            AV10IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPostulaciones_Update", out  GXt_boolean1) ;
            AV10IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPostulaciones_Delete", out  GXt_boolean1) ;
            AV10IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         }
         if ( ! AV10IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV26Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV26Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV27GXV1 = 1;
            AssignAttri("", false, "AV27GXV1", StringUtil.LTrimStr( (decimal)(AV27GXV1), 8, 0));
            while ( AV27GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV27GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "ServiciosId") == 0 )
               {
                  AV14Insert_ServiciosId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Insert_ServiciosId", StringUtil.LTrimStr( (decimal)(AV14Insert_ServiciosId), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "PostulacionesProveedorId") == 0 )
               {
                  AV17Insert_PostulacionesProveedorId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV17Insert_PostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(AV17Insert_PostulacionesProveedorId), 18, 0));
               }
               AV27GXV1 = (int)(AV27GXV1+1);
               AssignAttri("", false, "AV27GXV1", StringUtil.LTrimStr( (decimal)(AV27GXV1), 8, 0));
            }
         }
         edtPostulacionesId_Visible = 0;
         AssignProp("", false, edtPostulacionesId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesId_Visible), 5, 0), true);
         edtServiciosId_Visible = 0;
         AssignProp("", false, edtServiciosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtServiciosId_Visible), 5, 0), true);
         edtPostulacionesTipoFecha_Visible = 0;
         AssignProp("", false, edtPostulacionesTipoFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesTipoFecha_Visible), 5, 0), true);
         edtPostulacionesEstado_Visible = 0;
         AssignProp("", false, edtPostulacionesEstado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesEstado_Visible), 5, 0), true);
         edtPostulacionesFechaAlta_Visible = 0;
         AssignProp("", false, edtPostulacionesFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesFechaAlta_Visible), 5, 0), true);
         edtPostulacionesSecUserId_Visible = 0;
         AssignProp("", false, edtPostulacionesSecUserId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesSecUserId_Visible), 5, 0), true);
         edtPostulacionesMultimediaSerial_Visible = 0;
         AssignProp("", false, edtPostulacionesMultimediaSerial_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesMultimediaSerial_Visible), 5, 0), true);
         edtavVermas_gximage = "prompt";
         AssignProp("", false, edtavVermas_Internalname, "gximage", edtavVermas_gximage, !bGXsfl_115_Refreshing);
         AV24VerMas = context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( ));
         AssignProp("", false, edtavVermas_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV24VerMas)) ? AV28Vermas_GXI : context.convertURL( context.PathToRelativeUrl( AV24VerMas))), !bGXsfl_115_Refreshing);
         AssignProp("", false, edtavVermas_Internalname, "SrcSet", context.GetImageSrcSet( AV24VerMas), true);
         AV28Vermas_GXI = GXDbFile.PathToUrl( context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )), context);
         AssignProp("", false, edtavVermas_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV24VerMas)) ? AV28Vermas_GXI : context.convertURL( context.PathToRelativeUrl( AV24VerMas))), !bGXsfl_115_Refreshing);
         AssignProp("", false, edtavVermas_Internalname, "SrcSet", context.GetImageSrcSet( AV24VerMas), true);
         edtavVermas_Tooltiptext = context.GetMessage( "Ver aclaración", "");
         AssignProp("", false, edtavVermas_Internalname, "Tooltiptext", edtavVermas_Tooltiptext, !bGXsfl_115_Refreshing);
      }

      protected void E121K2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("postulacionesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E131K2( )
      {
         /* Vermas_Click Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wcpopovertexto.aspx"+UrlEncode(StringUtil.RTrim(context.GetMessage( "Detalle del Profesional", ""))) + "," + UrlEncode(StringUtil.RTrim(A984PostulacionProfesionalA));
         context.PopUp(formatLink("wcpopovertexto.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
      }

      protected void ZM1K126( short GX_JID )
      {
         if ( ( GX_JID == 26 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z971PostulacionesProvNombreAux = T001K11_A971PostulacionesProvNombreAux[0];
               Z946PostulacionesPrecio = T001K11_A946PostulacionesPrecio[0];
               Z961PostulacionesMultimediaSerial = T001K11_A961PostulacionesMultimediaSerial[0];
               Z936PostulacionesDescripcion = T001K11_A936PostulacionesDescripcion[0];
               Z937PostulacionesReqSuministros = T001K11_A937PostulacionesReqSuministros[0];
               Z938PostulacionesSuministrosDescri = T001K11_A938PostulacionesSuministrosDescri[0];
               Z947PostulacionesFechaTrabajo = T001K11_A947PostulacionesFechaTrabajo[0];
               Z939PostulacionesFechaCierre = T001K11_A939PostulacionesFechaCierre[0];
               Z940PostulacionesHoraCierre = T001K11_A940PostulacionesHoraCierre[0];
               Z941PostulacionesTipoFecha = T001K11_A941PostulacionesTipoFecha[0];
               Z949PostulacionesRgoHoraservicio = T001K11_A949PostulacionesRgoHoraservicio[0];
               Z950PostulacionesApellidoNombre = T001K11_A950PostulacionesApellidoNombre[0];
               Z951PostulacionesMail = T001K11_A951PostulacionesMail[0];
               Z952PostulacionesTelefono = T001K11_A952PostulacionesTelefono[0];
               Z979PostulacionesDepartamentoId = T001K11_A979PostulacionesDepartamentoId[0];
               Z980PostulacionesDepartamentoMunic = T001K11_A980PostulacionesDepartamentoMunic[0];
               Z981PostulacionesZonasID = T001K11_A981PostulacionesZonasID[0];
               Z998PostulacionesDireccion = T001K11_A998PostulacionesDireccion[0];
               Z425PostulacionesFechaAlta = T001K11_A425PostulacionesFechaAlta[0];
               Z424PostulacionesEstado = T001K11_A424PostulacionesEstado[0];
               Z948PostulacionesSecUserId = T001K11_A948PostulacionesSecUserId[0];
               Z942ServiciosId = T001K11_A942ServiciosId[0];
               Z945PostulacionesProveedorId = T001K11_A945PostulacionesProveedorId[0];
            }
            else
            {
               Z971PostulacionesProvNombreAux = A971PostulacionesProvNombreAux;
               Z946PostulacionesPrecio = A946PostulacionesPrecio;
               Z961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
               Z936PostulacionesDescripcion = A936PostulacionesDescripcion;
               Z937PostulacionesReqSuministros = A937PostulacionesReqSuministros;
               Z938PostulacionesSuministrosDescri = A938PostulacionesSuministrosDescri;
               Z947PostulacionesFechaTrabajo = A947PostulacionesFechaTrabajo;
               Z939PostulacionesFechaCierre = A939PostulacionesFechaCierre;
               Z940PostulacionesHoraCierre = A940PostulacionesHoraCierre;
               Z941PostulacionesTipoFecha = A941PostulacionesTipoFecha;
               Z949PostulacionesRgoHoraservicio = A949PostulacionesRgoHoraservicio;
               Z950PostulacionesApellidoNombre = A950PostulacionesApellidoNombre;
               Z951PostulacionesMail = A951PostulacionesMail;
               Z952PostulacionesTelefono = A952PostulacionesTelefono;
               Z979PostulacionesDepartamentoId = A979PostulacionesDepartamentoId;
               Z980PostulacionesDepartamentoMunic = A980PostulacionesDepartamentoMunic;
               Z981PostulacionesZonasID = A981PostulacionesZonasID;
               Z998PostulacionesDireccion = A998PostulacionesDireccion;
               Z425PostulacionesFechaAlta = A425PostulacionesFechaAlta;
               Z424PostulacionesEstado = A424PostulacionesEstado;
               Z948PostulacionesSecUserId = A948PostulacionesSecUserId;
               Z942ServiciosId = A942ServiciosId;
               Z945PostulacionesProveedorId = A945PostulacionesProveedorId;
            }
         }
         if ( GX_JID == -26 )
         {
            Z422PostulacionesId = A422PostulacionesId;
            Z971PostulacionesProvNombreAux = A971PostulacionesProvNombreAux;
            Z946PostulacionesPrecio = A946PostulacionesPrecio;
            Z961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
            Z936PostulacionesDescripcion = A936PostulacionesDescripcion;
            Z937PostulacionesReqSuministros = A937PostulacionesReqSuministros;
            Z938PostulacionesSuministrosDescri = A938PostulacionesSuministrosDescri;
            Z947PostulacionesFechaTrabajo = A947PostulacionesFechaTrabajo;
            Z939PostulacionesFechaCierre = A939PostulacionesFechaCierre;
            Z940PostulacionesHoraCierre = A940PostulacionesHoraCierre;
            Z941PostulacionesTipoFecha = A941PostulacionesTipoFecha;
            Z949PostulacionesRgoHoraservicio = A949PostulacionesRgoHoraservicio;
            Z950PostulacionesApellidoNombre = A950PostulacionesApellidoNombre;
            Z951PostulacionesMail = A951PostulacionesMail;
            Z952PostulacionesTelefono = A952PostulacionesTelefono;
            Z979PostulacionesDepartamentoId = A979PostulacionesDepartamentoId;
            Z980PostulacionesDepartamentoMunic = A980PostulacionesDepartamentoMunic;
            Z981PostulacionesZonasID = A981PostulacionesZonasID;
            Z998PostulacionesDireccion = A998PostulacionesDireccion;
            Z425PostulacionesFechaAlta = A425PostulacionesFechaAlta;
            Z424PostulacionesEstado = A424PostulacionesEstado;
            Z948PostulacionesSecUserId = A948PostulacionesSecUserId;
            Z942ServiciosId = A942ServiciosId;
            Z945PostulacionesProveedorId = A945PostulacionesProveedorId;
            Z970PostulacionesSolicitudesId = A970PostulacionesSolicitudesId;
            Z943ServiciosNombre = A943ServiciosNombre;
            Z969PostulacionesProveedorNombre = A969PostulacionesProveedorNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         /* Using cursor T001K13 */
         pr_default.execute(10, new Object[] {n422PostulacionesId, A422PostulacionesId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A970PostulacionesSolicitudesId = T001K13_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = T001K13_n970PostulacionesSolicitudesId[0];
            AssignAttri("", false, "A970PostulacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(A970PostulacionesSolicitudesId), 18, 0));
         }
         else
         {
            A970PostulacionesSolicitudesId = 0;
            n970PostulacionesSolicitudesId = false;
            AssignAttri("", false, "A970PostulacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(A970PostulacionesSolicitudesId), 18, 0));
         }
         pr_default.close(10);
         edtPostulacionesId_Enabled = 0;
         AssignProp("", false, edtPostulacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesId_Enabled), 5, 0), true);
         edtPostulacionesMultimediaSerial_Enabled = 0;
         AssignProp("", false, edtPostulacionesMultimediaSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesMultimediaSerial_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_945_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"proveedorprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"POSTULACIONESPROVEEDORID"+"'), id:'"+"POSTULACIONESPROVEEDORID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"POSTULACIONESPROVEEDORNOMBRE"+"'), id:'"+"POSTULACIONESPROVEEDORNOMBRE"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_942_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx03w0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SERVICIOSID"+"'), id:'"+"SERVICIOSID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtPostulacionesId_Enabled = 0;
         AssignProp("", false, edtPostulacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesId_Enabled), 5, 0), true);
         edtPostulacionesMultimediaSerial_Enabled = 0;
         AssignProp("", false, edtPostulacionesMultimediaSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesMultimediaSerial_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7PostulacionesId) )
         {
            A422PostulacionesId = AV7PostulacionesId;
            n422PostulacionesId = false;
            AssignAttri("", false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_ServiciosId) )
         {
            edtServiciosId_Enabled = 0;
            AssignProp("", false, edtServiciosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServiciosId_Enabled), 5, 0), true);
         }
         else
         {
            edtServiciosId_Enabled = 1;
            AssignProp("", false, edtServiciosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServiciosId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV17Insert_PostulacionesProveedorId) )
         {
            edtPostulacionesProveedorId_Enabled = 0;
            AssignProp("", false, edtPostulacionesProveedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesProveedorId_Enabled), 5, 0), true);
         }
         else
         {
            edtPostulacionesProveedorId_Enabled = 1;
            AssignProp("", false, edtPostulacionesProveedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesProveedorId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV17Insert_PostulacionesProveedorId) )
         {
            A945PostulacionesProveedorId = AV17Insert_PostulacionesProveedorId;
            AssignAttri("", false, "A945PostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(A945PostulacionesProveedorId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_ServiciosId) )
         {
            A942ServiciosId = AV14Insert_ServiciosId;
            n942ServiciosId = false;
            AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
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
            AV26Pgmname = "Postulaciones";
            AssignAttri("", false, "AV26Pgmname", AV26Pgmname);
            /* Using cursor T001K15 */
            pr_default.execute(12, new Object[] {A945PostulacionesProveedorId});
            A969PostulacionesProveedorNombre = T001K15_A969PostulacionesProveedorNombre[0];
            AssignAttri("", false, "A969PostulacionesProveedorNombre", A969PostulacionesProveedorNombre);
            pr_default.close(12);
            /* Using cursor T001K14 */
            pr_default.execute(11, new Object[] {n942ServiciosId, A942ServiciosId});
            A943ServiciosNombre = T001K14_A943ServiciosNombre[0];
            AssignAttri("", false, "A943ServiciosNombre", A943ServiciosNombre);
            pr_default.close(11);
         }
      }

      protected void Load1K126( )
      {
         /* Using cursor T001K17 */
         pr_default.execute(13, new Object[] {n422PostulacionesId, A422PostulacionesId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound126 = 1;
            A943ServiciosNombre = T001K17_A943ServiciosNombre[0];
            AssignAttri("", false, "A943ServiciosNombre", A943ServiciosNombre);
            A971PostulacionesProvNombreAux = T001K17_A971PostulacionesProvNombreAux[0];
            A969PostulacionesProveedorNombre = T001K17_A969PostulacionesProveedorNombre[0];
            AssignAttri("", false, "A969PostulacionesProveedorNombre", A969PostulacionesProveedorNombre);
            A946PostulacionesPrecio = T001K17_A946PostulacionesPrecio[0];
            AssignAttri("", false, "A946PostulacionesPrecio", StringUtil.LTrimStr( A946PostulacionesPrecio, 18, 2));
            A961PostulacionesMultimediaSerial = T001K17_A961PostulacionesMultimediaSerial[0];
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
            A936PostulacionesDescripcion = T001K17_A936PostulacionesDescripcion[0];
            AssignAttri("", false, "A936PostulacionesDescripcion", A936PostulacionesDescripcion);
            A937PostulacionesReqSuministros = T001K17_A937PostulacionesReqSuministros[0];
            AssignAttri("", false, "A937PostulacionesReqSuministros", A937PostulacionesReqSuministros);
            A938PostulacionesSuministrosDescri = T001K17_A938PostulacionesSuministrosDescri[0];
            AssignAttri("", false, "A938PostulacionesSuministrosDescri", A938PostulacionesSuministrosDescri);
            A947PostulacionesFechaTrabajo = T001K17_A947PostulacionesFechaTrabajo[0];
            AssignAttri("", false, "A947PostulacionesFechaTrabajo", context.localUtil.Format(A947PostulacionesFechaTrabajo, "99/99/99"));
            A939PostulacionesFechaCierre = T001K17_A939PostulacionesFechaCierre[0];
            AssignAttri("", false, "A939PostulacionesFechaCierre", context.localUtil.Format(A939PostulacionesFechaCierre, "99/99/99"));
            A940PostulacionesHoraCierre = T001K17_A940PostulacionesHoraCierre[0];
            AssignAttri("", false, "A940PostulacionesHoraCierre", A940PostulacionesHoraCierre);
            A941PostulacionesTipoFecha = T001K17_A941PostulacionesTipoFecha[0];
            AssignAttri("", false, "A941PostulacionesTipoFecha", A941PostulacionesTipoFecha);
            A949PostulacionesRgoHoraservicio = T001K17_A949PostulacionesRgoHoraservicio[0];
            AssignAttri("", false, "A949PostulacionesRgoHoraservicio", A949PostulacionesRgoHoraservicio);
            A950PostulacionesApellidoNombre = T001K17_A950PostulacionesApellidoNombre[0];
            AssignAttri("", false, "A950PostulacionesApellidoNombre", A950PostulacionesApellidoNombre);
            A951PostulacionesMail = T001K17_A951PostulacionesMail[0];
            AssignAttri("", false, "A951PostulacionesMail", A951PostulacionesMail);
            A952PostulacionesTelefono = T001K17_A952PostulacionesTelefono[0];
            AssignAttri("", false, "A952PostulacionesTelefono", A952PostulacionesTelefono);
            A979PostulacionesDepartamentoId = T001K17_A979PostulacionesDepartamentoId[0];
            A980PostulacionesDepartamentoMunic = T001K17_A980PostulacionesDepartamentoMunic[0];
            A981PostulacionesZonasID = T001K17_A981PostulacionesZonasID[0];
            A998PostulacionesDireccion = T001K17_A998PostulacionesDireccion[0];
            A425PostulacionesFechaAlta = T001K17_A425PostulacionesFechaAlta[0];
            AssignAttri("", false, "A425PostulacionesFechaAlta", context.localUtil.TToC( A425PostulacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A424PostulacionesEstado = T001K17_A424PostulacionesEstado[0];
            AssignAttri("", false, "A424PostulacionesEstado", A424PostulacionesEstado);
            A948PostulacionesSecUserId = T001K17_A948PostulacionesSecUserId[0];
            AssignAttri("", false, "A948PostulacionesSecUserId", StringUtil.LTrimStr( (decimal)(A948PostulacionesSecUserId), 18, 0));
            A942ServiciosId = T001K17_A942ServiciosId[0];
            n942ServiciosId = T001K17_n942ServiciosId[0];
            AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
            A945PostulacionesProveedorId = T001K17_A945PostulacionesProveedorId[0];
            AssignAttri("", false, "A945PostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(A945PostulacionesProveedorId), 18, 0));
            A970PostulacionesSolicitudesId = T001K17_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = T001K17_n970PostulacionesSolicitudesId[0];
            AssignAttri("", false, "A970PostulacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(A970PostulacionesSolicitudesId), 18, 0));
            ZM1K126( -26) ;
         }
         pr_default.close(13);
         OnLoadActions1K126( ) ;
      }

      protected void OnLoadActions1K126( )
      {
         AV26Pgmname = "Postulaciones";
         AssignAttri("", false, "AV26Pgmname", AV26Pgmname);
      }

      protected void CheckExtendedTable1K126( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV26Pgmname = "Postulaciones";
         AssignAttri("", false, "AV26Pgmname", AV26Pgmname);
         /* Using cursor T001K14 */
         pr_default.execute(11, new Object[] {n942ServiciosId, A942ServiciosId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A942ServiciosId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Servicios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SERVICIOSID");
               AnyError = 1;
               GX_FocusControl = edtServiciosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A943ServiciosNombre = T001K14_A943ServiciosNombre[0];
         AssignAttri("", false, "A943ServiciosNombre", A943ServiciosNombre);
         pr_default.close(11);
         /* Using cursor T001K15 */
         pr_default.execute(12, new Object[] {A945PostulacionesProveedorId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Postulaciones Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "POSTULACIONESPROVEEDORID");
            AnyError = 1;
            GX_FocusControl = edtPostulacionesProveedorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A969PostulacionesProveedorNombre = T001K15_A969PostulacionesProveedorNombre[0];
         AssignAttri("", false, "A969PostulacionesProveedorNombre", A969PostulacionesProveedorNombre);
         pr_default.close(12);
         if ( ! ( (DateTime.MinValue==A947PostulacionesFechaTrabajo) || ( DateTimeUtil.ResetTime ( A947PostulacionesFechaTrabajo ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Postulaciones Fecha Trabajo", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "POSTULACIONESFECHATRABAJO");
            AnyError = 1;
            GX_FocusControl = edtPostulacionesFechaTrabajo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A939PostulacionesFechaCierre) || ( DateTimeUtil.ResetTime ( A939PostulacionesFechaCierre ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Postulaciones Fecha Cierre", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "POSTULACIONESFECHACIERRE");
            AnyError = 1;
            GX_FocusControl = edtPostulacionesFechaCierre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A951PostulacionesMail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Postulaciones Mail", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "POSTULACIONESMAIL");
            AnyError = 1;
            GX_FocusControl = edtPostulacionesMail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A425PostulacionesFechaAlta) || ( A425PostulacionesFechaAlta >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "POSTULACIONESFECHAALTA");
            AnyError = 1;
            GX_FocusControl = edtPostulacionesFechaAlta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1K126( )
      {
         pr_default.close(11);
         pr_default.close(12);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_28( long A942ServiciosId )
      {
         /* Using cursor T001K18 */
         pr_default.execute(14, new Object[] {n942ServiciosId, A942ServiciosId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A942ServiciosId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Servicios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SERVICIOSID");
               AnyError = 1;
               GX_FocusControl = edtServiciosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A943ServiciosNombre = T001K18_A943ServiciosNombre[0];
         AssignAttri("", false, "A943ServiciosNombre", A943ServiciosNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A943ServiciosNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_29( long A945PostulacionesProveedorId )
      {
         /* Using cursor T001K19 */
         pr_default.execute(15, new Object[] {A945PostulacionesProveedorId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Postulaciones Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "POSTULACIONESPROVEEDORID");
            AnyError = 1;
            GX_FocusControl = edtPostulacionesProveedorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A969PostulacionesProveedorNombre = T001K19_A969PostulacionesProveedorNombre[0];
         AssignAttri("", false, "A969PostulacionesProveedorNombre", A969PostulacionesProveedorNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A969PostulacionesProveedorNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void GetKey1K126( )
      {
         /* Using cursor T001K20 */
         pr_default.execute(16, new Object[] {n422PostulacionesId, A422PostulacionesId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound126 = 1;
         }
         else
         {
            RcdFound126 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001K11 */
         pr_default.execute(9, new Object[] {n422PostulacionesId, A422PostulacionesId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            ZM1K126( 26) ;
            RcdFound126 = 1;
            A422PostulacionesId = T001K11_A422PostulacionesId[0];
            n422PostulacionesId = T001K11_n422PostulacionesId[0];
            AssignAttri("", false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
            A971PostulacionesProvNombreAux = T001K11_A971PostulacionesProvNombreAux[0];
            A946PostulacionesPrecio = T001K11_A946PostulacionesPrecio[0];
            AssignAttri("", false, "A946PostulacionesPrecio", StringUtil.LTrimStr( A946PostulacionesPrecio, 18, 2));
            A961PostulacionesMultimediaSerial = T001K11_A961PostulacionesMultimediaSerial[0];
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
            A936PostulacionesDescripcion = T001K11_A936PostulacionesDescripcion[0];
            AssignAttri("", false, "A936PostulacionesDescripcion", A936PostulacionesDescripcion);
            A937PostulacionesReqSuministros = T001K11_A937PostulacionesReqSuministros[0];
            AssignAttri("", false, "A937PostulacionesReqSuministros", A937PostulacionesReqSuministros);
            A938PostulacionesSuministrosDescri = T001K11_A938PostulacionesSuministrosDescri[0];
            AssignAttri("", false, "A938PostulacionesSuministrosDescri", A938PostulacionesSuministrosDescri);
            A947PostulacionesFechaTrabajo = T001K11_A947PostulacionesFechaTrabajo[0];
            AssignAttri("", false, "A947PostulacionesFechaTrabajo", context.localUtil.Format(A947PostulacionesFechaTrabajo, "99/99/99"));
            A939PostulacionesFechaCierre = T001K11_A939PostulacionesFechaCierre[0];
            AssignAttri("", false, "A939PostulacionesFechaCierre", context.localUtil.Format(A939PostulacionesFechaCierre, "99/99/99"));
            A940PostulacionesHoraCierre = T001K11_A940PostulacionesHoraCierre[0];
            AssignAttri("", false, "A940PostulacionesHoraCierre", A940PostulacionesHoraCierre);
            A941PostulacionesTipoFecha = T001K11_A941PostulacionesTipoFecha[0];
            AssignAttri("", false, "A941PostulacionesTipoFecha", A941PostulacionesTipoFecha);
            A949PostulacionesRgoHoraservicio = T001K11_A949PostulacionesRgoHoraservicio[0];
            AssignAttri("", false, "A949PostulacionesRgoHoraservicio", A949PostulacionesRgoHoraservicio);
            A950PostulacionesApellidoNombre = T001K11_A950PostulacionesApellidoNombre[0];
            AssignAttri("", false, "A950PostulacionesApellidoNombre", A950PostulacionesApellidoNombre);
            A951PostulacionesMail = T001K11_A951PostulacionesMail[0];
            AssignAttri("", false, "A951PostulacionesMail", A951PostulacionesMail);
            A952PostulacionesTelefono = T001K11_A952PostulacionesTelefono[0];
            AssignAttri("", false, "A952PostulacionesTelefono", A952PostulacionesTelefono);
            A979PostulacionesDepartamentoId = T001K11_A979PostulacionesDepartamentoId[0];
            A980PostulacionesDepartamentoMunic = T001K11_A980PostulacionesDepartamentoMunic[0];
            A981PostulacionesZonasID = T001K11_A981PostulacionesZonasID[0];
            A998PostulacionesDireccion = T001K11_A998PostulacionesDireccion[0];
            A425PostulacionesFechaAlta = T001K11_A425PostulacionesFechaAlta[0];
            AssignAttri("", false, "A425PostulacionesFechaAlta", context.localUtil.TToC( A425PostulacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A424PostulacionesEstado = T001K11_A424PostulacionesEstado[0];
            AssignAttri("", false, "A424PostulacionesEstado", A424PostulacionesEstado);
            A948PostulacionesSecUserId = T001K11_A948PostulacionesSecUserId[0];
            AssignAttri("", false, "A948PostulacionesSecUserId", StringUtil.LTrimStr( (decimal)(A948PostulacionesSecUserId), 18, 0));
            A942ServiciosId = T001K11_A942ServiciosId[0];
            n942ServiciosId = T001K11_n942ServiciosId[0];
            AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
            A945PostulacionesProveedorId = T001K11_A945PostulacionesProveedorId[0];
            AssignAttri("", false, "A945PostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(A945PostulacionesProveedorId), 18, 0));
            O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
            Z422PostulacionesId = A422PostulacionesId;
            sMode126 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1K126( ) ;
            if ( AnyError == 1 )
            {
               RcdFound126 = 0;
               InitializeNonKey1K126( ) ;
            }
            Gx_mode = sMode126;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound126 = 0;
            InitializeNonKey1K126( ) ;
            sMode126 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode126;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(9);
      }

      protected void getEqualNoModal( )
      {
         GetKey1K126( ) ;
         if ( RcdFound126 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound126 = 0;
         /* Using cursor T001K21 */
         pr_default.execute(17, new Object[] {n422PostulacionesId, A422PostulacionesId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( T001K21_A422PostulacionesId[0] < A422PostulacionesId ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( T001K21_A422PostulacionesId[0] > A422PostulacionesId ) ) )
            {
               A422PostulacionesId = T001K21_A422PostulacionesId[0];
               n422PostulacionesId = T001K21_n422PostulacionesId[0];
               AssignAttri("", false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
               RcdFound126 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void move_previous( )
      {
         RcdFound126 = 0;
         /* Using cursor T001K22 */
         pr_default.execute(18, new Object[] {n422PostulacionesId, A422PostulacionesId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            while ( (pr_default.getStatus(18) != 101) && ( ( T001K22_A422PostulacionesId[0] > A422PostulacionesId ) ) )
            {
               pr_default.readNext(18);
            }
            if ( (pr_default.getStatus(18) != 101) && ( ( T001K22_A422PostulacionesId[0] < A422PostulacionesId ) ) )
            {
               A422PostulacionesId = T001K22_A422PostulacionesId[0];
               n422PostulacionesId = T001K22_n422PostulacionesId[0];
               AssignAttri("", false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
               RcdFound126 = 1;
            }
         }
         pr_default.close(18);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1K126( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
            GX_FocusControl = edtPostulacionesApellidoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1K126( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound126 == 1 )
            {
               if ( A422PostulacionesId != Z422PostulacionesId )
               {
                  A422PostulacionesId = Z422PostulacionesId;
                  n422PostulacionesId = false;
                  AssignAttri("", false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "POSTULACIONESID");
                  AnyError = 1;
                  GX_FocusControl = edtPostulacionesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
                  AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPostulacionesApellidoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
                  AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
                  Update1K126( ) ;
                  GX_FocusControl = edtPostulacionesApellidoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A422PostulacionesId != Z422PostulacionesId )
               {
                  /* Insert record */
                  A961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
                  AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
                  GX_FocusControl = edtPostulacionesApellidoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1K126( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "POSTULACIONESID");
                     AnyError = 1;
                     GX_FocusControl = edtPostulacionesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
                     AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
                     GX_FocusControl = edtPostulacionesApellidoNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1K126( ) ;
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
         if ( A422PostulacionesId != Z422PostulacionesId )
         {
            A422PostulacionesId = Z422PostulacionesId;
            n422PostulacionesId = false;
            AssignAttri("", false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "POSTULACIONESID");
            AnyError = 1;
            GX_FocusControl = edtPostulacionesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPostulacionesApellidoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1K126( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001K10 */
            pr_default.execute(8, new Object[] {n422PostulacionesId, A422PostulacionesId});
            if ( (pr_default.getStatus(8) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Postulaciones"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(8) == 101) || ( StringUtil.StrCmp(Z971PostulacionesProvNombreAux, T001K10_A971PostulacionesProvNombreAux[0]) != 0 ) || ( Z946PostulacionesPrecio != T001K10_A946PostulacionesPrecio[0] ) || ( Z961PostulacionesMultimediaSerial != T001K10_A961PostulacionesMultimediaSerial[0] ) || ( StringUtil.StrCmp(Z936PostulacionesDescripcion, T001K10_A936PostulacionesDescripcion[0]) != 0 ) || ( Z937PostulacionesReqSuministros != T001K10_A937PostulacionesReqSuministros[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z938PostulacionesSuministrosDescri, T001K10_A938PostulacionesSuministrosDescri[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z947PostulacionesFechaTrabajo ) != DateTimeUtil.ResetTime ( T001K10_A947PostulacionesFechaTrabajo[0] ) ) || ( DateTimeUtil.ResetTime ( Z939PostulacionesFechaCierre ) != DateTimeUtil.ResetTime ( T001K10_A939PostulacionesFechaCierre[0] ) ) || ( StringUtil.StrCmp(Z940PostulacionesHoraCierre, T001K10_A940PostulacionesHoraCierre[0]) != 0 ) || ( StringUtil.StrCmp(Z941PostulacionesTipoFecha, T001K10_A941PostulacionesTipoFecha[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z949PostulacionesRgoHoraservicio, T001K10_A949PostulacionesRgoHoraservicio[0]) != 0 ) || ( StringUtil.StrCmp(Z950PostulacionesApellidoNombre, T001K10_A950PostulacionesApellidoNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z951PostulacionesMail, T001K10_A951PostulacionesMail[0]) != 0 ) || ( StringUtil.StrCmp(Z952PostulacionesTelefono, T001K10_A952PostulacionesTelefono[0]) != 0 ) || ( Z979PostulacionesDepartamentoId != T001K10_A979PostulacionesDepartamentoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z980PostulacionesDepartamentoMunic != T001K10_A980PostulacionesDepartamentoMunic[0] ) || ( Z981PostulacionesZonasID != T001K10_A981PostulacionesZonasID[0] ) || ( StringUtil.StrCmp(Z998PostulacionesDireccion, T001K10_A998PostulacionesDireccion[0]) != 0 ) || ( Z425PostulacionesFechaAlta != T001K10_A425PostulacionesFechaAlta[0] ) || ( StringUtil.StrCmp(Z424PostulacionesEstado, T001K10_A424PostulacionesEstado[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z948PostulacionesSecUserId != T001K10_A948PostulacionesSecUserId[0] ) || ( Z942ServiciosId != T001K10_A942ServiciosId[0] ) || ( Z945PostulacionesProveedorId != T001K10_A945PostulacionesProveedorId[0] ) )
            {
               if ( StringUtil.StrCmp(Z971PostulacionesProvNombreAux, T001K10_A971PostulacionesProvNombreAux[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesProvNombreAux");
                  GXUtil.WriteLogRaw("Old: ",Z971PostulacionesProvNombreAux);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A971PostulacionesProvNombreAux[0]);
               }
               if ( Z946PostulacionesPrecio != T001K10_A946PostulacionesPrecio[0] )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesPrecio");
                  GXUtil.WriteLogRaw("Old: ",Z946PostulacionesPrecio);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A946PostulacionesPrecio[0]);
               }
               if ( Z961PostulacionesMultimediaSerial != T001K10_A961PostulacionesMultimediaSerial[0] )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesMultimediaSerial");
                  GXUtil.WriteLogRaw("Old: ",Z961PostulacionesMultimediaSerial);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A961PostulacionesMultimediaSerial[0]);
               }
               if ( StringUtil.StrCmp(Z936PostulacionesDescripcion, T001K10_A936PostulacionesDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z936PostulacionesDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A936PostulacionesDescripcion[0]);
               }
               if ( Z937PostulacionesReqSuministros != T001K10_A937PostulacionesReqSuministros[0] )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesReqSuministros");
                  GXUtil.WriteLogRaw("Old: ",Z937PostulacionesReqSuministros);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A937PostulacionesReqSuministros[0]);
               }
               if ( StringUtil.StrCmp(Z938PostulacionesSuministrosDescri, T001K10_A938PostulacionesSuministrosDescri[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesSuministrosDescri");
                  GXUtil.WriteLogRaw("Old: ",Z938PostulacionesSuministrosDescri);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A938PostulacionesSuministrosDescri[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z947PostulacionesFechaTrabajo ) != DateTimeUtil.ResetTime ( T001K10_A947PostulacionesFechaTrabajo[0] ) )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesFechaTrabajo");
                  GXUtil.WriteLogRaw("Old: ",Z947PostulacionesFechaTrabajo);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A947PostulacionesFechaTrabajo[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z939PostulacionesFechaCierre ) != DateTimeUtil.ResetTime ( T001K10_A939PostulacionesFechaCierre[0] ) )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesFechaCierre");
                  GXUtil.WriteLogRaw("Old: ",Z939PostulacionesFechaCierre);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A939PostulacionesFechaCierre[0]);
               }
               if ( StringUtil.StrCmp(Z940PostulacionesHoraCierre, T001K10_A940PostulacionesHoraCierre[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesHoraCierre");
                  GXUtil.WriteLogRaw("Old: ",Z940PostulacionesHoraCierre);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A940PostulacionesHoraCierre[0]);
               }
               if ( StringUtil.StrCmp(Z941PostulacionesTipoFecha, T001K10_A941PostulacionesTipoFecha[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesTipoFecha");
                  GXUtil.WriteLogRaw("Old: ",Z941PostulacionesTipoFecha);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A941PostulacionesTipoFecha[0]);
               }
               if ( StringUtil.StrCmp(Z949PostulacionesRgoHoraservicio, T001K10_A949PostulacionesRgoHoraservicio[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesRgoHoraservicio");
                  GXUtil.WriteLogRaw("Old: ",Z949PostulacionesRgoHoraservicio);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A949PostulacionesRgoHoraservicio[0]);
               }
               if ( StringUtil.StrCmp(Z950PostulacionesApellidoNombre, T001K10_A950PostulacionesApellidoNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesApellidoNombre");
                  GXUtil.WriteLogRaw("Old: ",Z950PostulacionesApellidoNombre);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A950PostulacionesApellidoNombre[0]);
               }
               if ( StringUtil.StrCmp(Z951PostulacionesMail, T001K10_A951PostulacionesMail[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesMail");
                  GXUtil.WriteLogRaw("Old: ",Z951PostulacionesMail);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A951PostulacionesMail[0]);
               }
               if ( StringUtil.StrCmp(Z952PostulacionesTelefono, T001K10_A952PostulacionesTelefono[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesTelefono");
                  GXUtil.WriteLogRaw("Old: ",Z952PostulacionesTelefono);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A952PostulacionesTelefono[0]);
               }
               if ( Z979PostulacionesDepartamentoId != T001K10_A979PostulacionesDepartamentoId[0] )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesDepartamentoId");
                  GXUtil.WriteLogRaw("Old: ",Z979PostulacionesDepartamentoId);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A979PostulacionesDepartamentoId[0]);
               }
               if ( Z980PostulacionesDepartamentoMunic != T001K10_A980PostulacionesDepartamentoMunic[0] )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesDepartamentoMunic");
                  GXUtil.WriteLogRaw("Old: ",Z980PostulacionesDepartamentoMunic);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A980PostulacionesDepartamentoMunic[0]);
               }
               if ( Z981PostulacionesZonasID != T001K10_A981PostulacionesZonasID[0] )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesZonasID");
                  GXUtil.WriteLogRaw("Old: ",Z981PostulacionesZonasID);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A981PostulacionesZonasID[0]);
               }
               if ( StringUtil.StrCmp(Z998PostulacionesDireccion, T001K10_A998PostulacionesDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z998PostulacionesDireccion);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A998PostulacionesDireccion[0]);
               }
               if ( Z425PostulacionesFechaAlta != T001K10_A425PostulacionesFechaAlta[0] )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesFechaAlta");
                  GXUtil.WriteLogRaw("Old: ",Z425PostulacionesFechaAlta);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A425PostulacionesFechaAlta[0]);
               }
               if ( StringUtil.StrCmp(Z424PostulacionesEstado, T001K10_A424PostulacionesEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesEstado");
                  GXUtil.WriteLogRaw("Old: ",Z424PostulacionesEstado);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A424PostulacionesEstado[0]);
               }
               if ( Z948PostulacionesSecUserId != T001K10_A948PostulacionesSecUserId[0] )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesSecUserId");
                  GXUtil.WriteLogRaw("Old: ",Z948PostulacionesSecUserId);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A948PostulacionesSecUserId[0]);
               }
               if ( Z942ServiciosId != T001K10_A942ServiciosId[0] )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"ServiciosId");
                  GXUtil.WriteLogRaw("Old: ",Z942ServiciosId);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A942ServiciosId[0]);
               }
               if ( Z945PostulacionesProveedorId != T001K10_A945PostulacionesProveedorId[0] )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionesProveedorId");
                  GXUtil.WriteLogRaw("Old: ",Z945PostulacionesProveedorId);
                  GXUtil.WriteLogRaw("Current: ",T001K10_A945PostulacionesProveedorId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Postulaciones"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1K126( )
      {
         BeforeValidate1K126( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K126( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1K126( 0) ;
            CheckOptimisticConcurrency1K126( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K126( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1K126( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001K23 */
                     pr_default.execute(19, new Object[] {A971PostulacionesProvNombreAux, A946PostulacionesPrecio, A961PostulacionesMultimediaSerial, A936PostulacionesDescripcion, A937PostulacionesReqSuministros, A938PostulacionesSuministrosDescri, A947PostulacionesFechaTrabajo, A939PostulacionesFechaCierre, A940PostulacionesHoraCierre, A941PostulacionesTipoFecha, A949PostulacionesRgoHoraservicio, A950PostulacionesApellidoNombre, A951PostulacionesMail, A952PostulacionesTelefono, A979PostulacionesDepartamentoId, A980PostulacionesDepartamentoMunic, A981PostulacionesZonasID, A998PostulacionesDireccion, A425PostulacionesFechaAlta, A424PostulacionesEstado, A948PostulacionesSecUserId, n942ServiciosId, A942ServiciosId, A945PostulacionesProveedorId});
                     A422PostulacionesId = T001K23_A422PostulacionesId[0];
                     n422PostulacionesId = T001K23_n422PostulacionesId[0];
                     AssignAttri("", false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("Postulaciones");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1K126( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1K0( ) ;
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
               Load1K126( ) ;
            }
            EndLevel1K126( ) ;
         }
         CloseExtendedTableCursors1K126( ) ;
      }

      protected void Update1K126( )
      {
         BeforeValidate1K126( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K126( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K126( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K126( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1K126( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001K24 */
                     pr_default.execute(20, new Object[] {A971PostulacionesProvNombreAux, A946PostulacionesPrecio, A961PostulacionesMultimediaSerial, A936PostulacionesDescripcion, A937PostulacionesReqSuministros, A938PostulacionesSuministrosDescri, A947PostulacionesFechaTrabajo, A939PostulacionesFechaCierre, A940PostulacionesHoraCierre, A941PostulacionesTipoFecha, A949PostulacionesRgoHoraservicio, A950PostulacionesApellidoNombre, A951PostulacionesMail, A952PostulacionesTelefono, A979PostulacionesDepartamentoId, A980PostulacionesDepartamentoMunic, A981PostulacionesZonasID, A998PostulacionesDireccion, A425PostulacionesFechaAlta, A424PostulacionesEstado, A948PostulacionesSecUserId, n942ServiciosId, A942ServiciosId, A945PostulacionesProveedorId, n422PostulacionesId, A422PostulacionesId});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("Postulaciones");
                     if ( (pr_default.getStatus(20) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Postulaciones"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1K126( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        new sincronizarpostulacionessolicitudes(context ).execute(  A970PostulacionesSolicitudesId,  A422PostulacionesId) ;
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1K126( ) ;
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
            EndLevel1K126( ) ;
         }
         CloseExtendedTableCursors1K126( ) ;
      }

      protected void DeferredUpdate1K126( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1K126( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K126( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1K126( ) ;
            AfterConfirm1K126( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1K126( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1K142( ) ;
                  while ( RcdFound142 != 0 )
                  {
                     getByPrimaryKey1K142( ) ;
                     Delete1K142( ) ;
                     ScanNext1K142( ) ;
                  }
                  ScanEnd1K142( ) ;
                  A961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
                  AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
                  ScanStart1K139( ) ;
                  while ( RcdFound139 != 0 )
                  {
                     getByPrimaryKey1K139( ) ;
                     Delete1K139( ) ;
                     ScanNext1K139( ) ;
                     O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
                     AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
                  }
                  ScanEnd1K139( ) ;
                  ScanStart1K137( ) ;
                  while ( RcdFound137 != 0 )
                  {
                     getByPrimaryKey1K137( ) ;
                     Delete1K137( ) ;
                     ScanNext1K137( ) ;
                  }
                  ScanEnd1K137( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001K25 */
                     pr_default.execute(21, new Object[] {n422PostulacionesId, A422PostulacionesId});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("Postulaciones");
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
         sMode126 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1K126( ) ;
         Gx_mode = sMode126;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1K126( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV26Pgmname = "Postulaciones";
            AssignAttri("", false, "AV26Pgmname", AV26Pgmname);
            /* Using cursor T001K26 */
            pr_default.execute(22, new Object[] {n942ServiciosId, A942ServiciosId});
            A943ServiciosNombre = T001K26_A943ServiciosNombre[0];
            AssignAttri("", false, "A943ServiciosNombre", A943ServiciosNombre);
            pr_default.close(22);
            /* Using cursor T001K27 */
            pr_default.execute(23, new Object[] {A945PostulacionesProveedorId});
            A969PostulacionesProveedorNombre = T001K27_A969PostulacionesProveedorNombre[0];
            AssignAttri("", false, "A969PostulacionesProveedorNombre", A969PostulacionesProveedorNombre);
            pr_default.close(23);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001K28 */
            pr_default.execute(24, new Object[] {n422PostulacionesId, A422PostulacionesId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
         }
      }

      protected void ProcessNestedLevel1K142( )
      {
         nGXsfl_93_idx = 0;
         while ( nGXsfl_93_idx < nRC_GXsfl_93 )
         {
            ReadRow1K142( ) ;
            if ( ( nRcdExists_142 != 0 ) || ( nIsMod_142 != 0 ) )
            {
               standaloneNotModal1K142( ) ;
               GetKey1K142( ) ;
               if ( ( nRcdExists_142 == 0 ) && ( nRcdDeleted_142 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1K142( ) ;
               }
               else
               {
                  if ( RcdFound142 != 0 )
                  {
                     if ( ( nRcdDeleted_142 != 0 ) && ( nRcdExists_142 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1K142( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_142 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1K142( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_142 == 0 )
                     {
                        GXCCtl = "CATEGORIASID_" + sGXsfl_93_idx;
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
            ChangePostValue( "ZT_"+"Z931CategoriasId_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z931CategoriasId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_142_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_142), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_142_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_142), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_142_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_142), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_142 != 0 )
            {
               ChangePostValue( "CATEGORIASID_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriasId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORIASNOMBRE_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriasNombre_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1K142( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_142 = 0;
         nIsMod_142 = 0;
         nRcdDeleted_142 = 0;
      }

      protected void ProcessNestedLevel1K139( )
      {
         s961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
         AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
         nGXsfl_103_idx = 0;
         while ( nGXsfl_103_idx < nRC_GXsfl_103 )
         {
            ReadRow1K139( ) ;
            if ( ( nRcdExists_139 != 0 ) || ( nIsMod_139 != 0 ) )
            {
               standaloneNotModal1K139( ) ;
               GetKey1K139( ) ;
               if ( ( nRcdExists_139 == 0 ) && ( nRcdDeleted_139 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1K139( ) ;
               }
               else
               {
                  if ( RcdFound139 != 0 )
                  {
                     if ( ( nRcdDeleted_139 != 0 ) && ( nRcdExists_139 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1K139( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_139 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1K139( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_139 == 0 )
                     {
                        GXCCtl = "MULTIMEDIAID_" + sGXsfl_103_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtMultimediaId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
               AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
            }
            ChangePostValue( edtMultimediaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A932MultimediaId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtMultimediaDireccion_Internalname, StringUtil.RTrim( A933MultimediaDireccion)) ;
            ChangePostValue( edtMultimediaDescripcion_Internalname, StringUtil.RTrim( A960MultimediaDescripcion)) ;
            ChangePostValue( edtMultimediaTipo_Internalname, A934MultimediaTipo) ;
            ChangePostValue( "ZT_"+"Z932MultimediaId_"+sGXsfl_103_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z932MultimediaId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z933MultimediaDireccion_"+sGXsfl_103_idx, StringUtil.RTrim( Z933MultimediaDireccion)) ;
            ChangePostValue( "ZT_"+"Z960MultimediaDescripcion_"+sGXsfl_103_idx, StringUtil.RTrim( Z960MultimediaDescripcion)) ;
            ChangePostValue( "ZT_"+"Z934MultimediaTipo_"+sGXsfl_103_idx, Z934MultimediaTipo) ;
            ChangePostValue( "nRcdDeleted_139_"+sGXsfl_103_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_139), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_139_"+sGXsfl_103_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_139), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_139_"+sGXsfl_103_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_139), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_139 != 0 )
            {
               ChangePostValue( "MULTIMEDIAID_"+sGXsfl_103_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MULTIMEDIADIRECCION_"+sGXsfl_103_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaDireccion_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MULTIMEDIADESCRIPCION_"+sGXsfl_103_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaDescripcion_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MULTIMEDIATIPO_"+sGXsfl_103_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaTipo_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1K139( ) ;
         if ( AnyError != 0 )
         {
            O961PostulacionesMultimediaSerial = s961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
         }
         nRcdExists_139 = 0;
         nIsMod_139 = 0;
         nRcdDeleted_139 = 0;
      }

      protected void ProcessNestedLevel1K137( )
      {
         nGXsfl_115_idx = 0;
         while ( nGXsfl_115_idx < nRC_GXsfl_115 )
         {
            ReadRow1K137( ) ;
            if ( ( nRcdExists_137 != 0 ) || ( nIsMod_137 != 0 ) )
            {
               standaloneNotModal1K137( ) ;
               GetKey1K137( ) ;
               if ( ( nRcdExists_137 == 0 ) && ( nRcdDeleted_137 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1K137( ) ;
               }
               else
               {
                  if ( RcdFound137 != 0 )
                  {
                     if ( ( nRcdDeleted_137 != 0 ) && ( nRcdExists_137 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1K137( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_137 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1K137( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_137 == 0 )
                     {
                        GXCCtl = "PROFESIONALESID_" + sGXsfl_115_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProfesionalesId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProfesionalesId_Internalname, StringUtil.RTrim( A120ProfesionalesId)) ;
            ChangePostValue( edtProfesionalesNombreCompleto_Internalname, A886ProfesionalesNombreCompleto) ;
            ChangePostValue( cmbPostulacionProfesionalEstado_Internalname, StringUtil.RTrim( A956PostulacionProfesionalEstado)) ;
            ChangePostValue( edtPostulacionProfesionalFechaA_Internalname, context.localUtil.TToC( A957PostulacionProfesionalFechaA, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( edtPostulacionProfesionalPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( A982PostulacionProfesionalPrecio, 21, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtPostulacionProfesionalFechaT_Internalname, context.localUtil.Format(A958PostulacionProfesionalFechaT, "99/99/99")) ;
            ChangePostValue( edtPostulacionProfesionalTurnoT_Internalname, StringUtil.RTrim( A959PostulacionProfesionalTurnoT)) ;
            ChangePostValue( edtPostulacionProfesionalPlazoE_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A983PostulacionProfesionalPlazoE), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbPostulacionProfesionalUniE_Internalname, StringUtil.RTrim( A986PostulacionProfesionalUniE)) ;
            ChangePostValue( edtPostulacionProfesionalGar_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A985PostulacionProfesionalGar), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbPostulacionProfesionalUniG_Internalname, StringUtil.RTrim( A987PostulacionProfesionalUniG)) ;
            ChangePostValue( edtPostulacionProfesionalA_Internalname, A984PostulacionProfesionalA) ;
            ChangePostValue( edtavVermas_Internalname, AV24VerMas) ;
            ChangePostValue( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_115_idx, StringUtil.RTrim( Z120ProfesionalesId)) ;
            ChangePostValue( "ZT_"+"Z956PostulacionProfesionalEstado_"+sGXsfl_115_idx, StringUtil.RTrim( Z956PostulacionProfesionalEstado)) ;
            ChangePostValue( "ZT_"+"Z957PostulacionProfesionalFechaA_"+sGXsfl_115_idx, context.localUtil.TToC( Z957PostulacionProfesionalFechaA, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z958PostulacionProfesionalFechaT_"+sGXsfl_115_idx, context.localUtil.DToC( Z958PostulacionProfesionalFechaT, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z959PostulacionProfesionalTurnoT_"+sGXsfl_115_idx, StringUtil.RTrim( Z959PostulacionProfesionalTurnoT)) ;
            ChangePostValue( "ZT_"+"Z982PostulacionProfesionalPrecio_"+sGXsfl_115_idx, StringUtil.LTrim( StringUtil.NToC( Z982PostulacionProfesionalPrecio, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z983PostulacionProfesionalPlazoE_"+sGXsfl_115_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z983PostulacionProfesionalPlazoE), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z986PostulacionProfesionalUniE_"+sGXsfl_115_idx, StringUtil.RTrim( Z986PostulacionProfesionalUniE)) ;
            ChangePostValue( "ZT_"+"Z985PostulacionProfesionalGar_"+sGXsfl_115_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z985PostulacionProfesionalGar), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z987PostulacionProfesionalUniG_"+sGXsfl_115_idx, StringUtil.RTrim( Z987PostulacionProfesionalUniG)) ;
            ChangePostValue( "ZT_"+"Z984PostulacionProfesionalA_"+sGXsfl_115_idx, Z984PostulacionProfesionalA) ;
            ChangePostValue( "nRcdDeleted_137_"+sGXsfl_115_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_137), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_137_"+sGXsfl_115_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_137), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_137_"+sGXsfl_115_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_137), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_137 != 0 )
            {
               ChangePostValue( "PROFESIONALESID_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESNOMBRECOMPLETO_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesNombreCompleto_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALESTADO_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPostulacionProfesionalEstado.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALFECHAA_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalFechaA_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALPRECIO_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalPrecio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALFECHAT_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalFechaT_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALTURNOT_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalTurnoT_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALPLAZOE_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalPlazoE_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALUNIE_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPostulacionProfesionalUniE.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALGAR_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalGar_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALUNIG_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPostulacionProfesionalUniG.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POSTULACIONPROFESIONALA_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalA_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "vVERMAS_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVermas_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "vVERMAS_"+sGXsfl_115_idx+"Tooltiptext", StringUtil.RTrim( edtavVermas_Tooltiptext)) ;
               ChangePostValue( "vVERMAS_"+sGXsfl_115_idx+"Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVermas_Visible), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1K137( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_137 = 0;
         nIsMod_137 = 0;
         nRcdDeleted_137 = 0;
      }

      protected void ProcessLevel1K126( )
      {
         /* Save parent mode. */
         sMode126 = Gx_mode;
         ProcessNestedLevel1K142( ) ;
         ProcessNestedLevel1K139( ) ;
         ProcessNestedLevel1K137( ) ;
         if ( AnyError != 0 )
         {
            O961PostulacionesMultimediaSerial = s961PostulacionesMultimediaSerial;
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode126;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T001K29 */
         pr_default.execute(25, new Object[] {A961PostulacionesMultimediaSerial, n422PostulacionesId, A422PostulacionesId});
         pr_default.close(25);
         pr_default.SmartCacheProvider.SetUpdated("Postulaciones");
      }

      protected void EndLevel1K126( )
      {
         pr_default.close(8);
         if ( AnyError == 0 )
         {
            BeforeComplete1K126( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(9);
            pr_default.close(6);
            pr_default.close(5);
            pr_default.close(4);
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(22);
            pr_default.close(23);
            pr_default.close(7);
            pr_default.close(2);
            context.CommitDataStores("postulaciones",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1K0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(9);
            pr_default.close(6);
            pr_default.close(5);
            pr_default.close(4);
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(22);
            pr_default.close(23);
            pr_default.close(7);
            pr_default.close(2);
            context.RollbackDataStores("postulaciones",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1K126( )
      {
         /* Scan By routine */
         /* Using cursor T001K30 */
         pr_default.execute(26);
         RcdFound126 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound126 = 1;
            A422PostulacionesId = T001K30_A422PostulacionesId[0];
            n422PostulacionesId = T001K30_n422PostulacionesId[0];
            AssignAttri("", false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1K126( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound126 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound126 = 1;
            A422PostulacionesId = T001K30_A422PostulacionesId[0];
            n422PostulacionesId = T001K30_n422PostulacionesId[0];
            AssignAttri("", false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
         }
      }

      protected void ScanEnd1K126( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm1K126( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1K126( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1K126( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1K126( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1K126( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1K126( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1K126( )
      {
         edtPostulacionesApellidoNombre_Enabled = 0;
         AssignProp("", false, edtPostulacionesApellidoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesApellidoNombre_Enabled), 5, 0), true);
         edtPostulacionesMail_Enabled = 0;
         AssignProp("", false, edtPostulacionesMail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesMail_Enabled), 5, 0), true);
         edtPostulacionesTelefono_Enabled = 0;
         AssignProp("", false, edtPostulacionesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesTelefono_Enabled), 5, 0), true);
         edtPostulacionesProveedorId_Enabled = 0;
         AssignProp("", false, edtPostulacionesProveedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesProveedorId_Enabled), 5, 0), true);
         edtPostulacionesProveedorNombre_Enabled = 0;
         AssignProp("", false, edtPostulacionesProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesProveedorNombre_Enabled), 5, 0), true);
         edtPostulacionesPrecio_Enabled = 0;
         AssignProp("", false, edtPostulacionesPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesPrecio_Enabled), 5, 0), true);
         edtPostulacionesDescripcion_Enabled = 0;
         AssignProp("", false, edtPostulacionesDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesDescripcion_Enabled), 5, 0), true);
         chkPostulacionesReqSuministros.Enabled = 0;
         AssignProp("", false, chkPostulacionesReqSuministros_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkPostulacionesReqSuministros.Enabled), 5, 0), true);
         edtPostulacionesSuministrosDescri_Enabled = 0;
         AssignProp("", false, edtPostulacionesSuministrosDescri_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesSuministrosDescri_Enabled), 5, 0), true);
         edtPostulacionesFechaCierre_Enabled = 0;
         AssignProp("", false, edtPostulacionesFechaCierre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesFechaCierre_Enabled), 5, 0), true);
         edtPostulacionesHoraCierre_Enabled = 0;
         AssignProp("", false, edtPostulacionesHoraCierre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesHoraCierre_Enabled), 5, 0), true);
         edtPostulacionesFechaTrabajo_Enabled = 0;
         AssignProp("", false, edtPostulacionesFechaTrabajo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesFechaTrabajo_Enabled), 5, 0), true);
         cmbPostulacionesRgoHoraservicio.Enabled = 0;
         AssignProp("", false, cmbPostulacionesRgoHoraservicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPostulacionesRgoHoraservicio.Enabled), 5, 0), true);
         edtServiciosNombre_Enabled = 0;
         AssignProp("", false, edtServiciosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServiciosNombre_Enabled), 5, 0), true);
         edtPostulacionesSolicitudesId_Enabled = 0;
         AssignProp("", false, edtPostulacionesSolicitudesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesSolicitudesId_Enabled), 5, 0), true);
         edtPostulacionesId_Enabled = 0;
         AssignProp("", false, edtPostulacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesId_Enabled), 5, 0), true);
         edtServiciosId_Enabled = 0;
         AssignProp("", false, edtServiciosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServiciosId_Enabled), 5, 0), true);
         edtPostulacionesTipoFecha_Enabled = 0;
         AssignProp("", false, edtPostulacionesTipoFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesTipoFecha_Enabled), 5, 0), true);
         edtPostulacionesEstado_Enabled = 0;
         AssignProp("", false, edtPostulacionesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesEstado_Enabled), 5, 0), true);
         edtPostulacionesFechaAlta_Enabled = 0;
         AssignProp("", false, edtPostulacionesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesFechaAlta_Enabled), 5, 0), true);
         edtPostulacionesSecUserId_Enabled = 0;
         AssignProp("", false, edtPostulacionesSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesSecUserId_Enabled), 5, 0), true);
         edtPostulacionesMultimediaSerial_Enabled = 0;
         AssignProp("", false, edtPostulacionesMultimediaSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesMultimediaSerial_Enabled), 5, 0), true);
      }

      protected void ZM1K142( short GX_JID )
      {
         if ( ( GX_JID == 30 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -30 )
         {
            Z422PostulacionesId = A422PostulacionesId;
            Z931CategoriasId = A931CategoriasId;
            Z944CategoriasNombre = A944CategoriasNombre;
         }
      }

      protected void standaloneNotModal1K142( )
      {
      }

      protected void standaloneModal1K142( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCategoriasId_Enabled = 0;
            AssignProp("", false, edtCategoriasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriasId_Enabled), 5, 0), !bGXsfl_93_Refreshing);
         }
         else
         {
            edtCategoriasId_Enabled = 1;
            AssignProp("", false, edtCategoriasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriasId_Enabled), 5, 0), !bGXsfl_93_Refreshing);
         }
      }

      protected void Load1K142( )
      {
         /* Using cursor T001K31 */
         pr_default.execute(27, new Object[] {n942ServiciosId, A942ServiciosId, n422PostulacionesId, A422PostulacionesId, A931CategoriasId});
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound142 = 1;
            A944CategoriasNombre = T001K31_A944CategoriasNombre[0];
            ZM1K142( -30) ;
         }
         pr_default.close(27);
         OnLoadActions1K142( ) ;
      }

      protected void OnLoadActions1K142( )
      {
      }

      protected void CheckExtendedTable1K142( )
      {
         nIsDirty_142 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1K142( ) ;
         /* Using cursor T001K9 */
         pr_default.execute(7, new Object[] {n942ServiciosId, A942ServiciosId, A931CategoriasId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A942ServiciosId) || (0==A931CategoriasId) ) )
            {
               GXCCtl = "CATEGORIASID_" + sGXsfl_93_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Categorias", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtCategoriasId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A944CategoriasNombre = T001K9_A944CategoriasNombre[0];
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors1K142( )
      {
         pr_default.close(7);
      }

      protected void enableDisable1K142( )
      {
      }

      protected void gxLoad_31( long A942ServiciosId ,
                                long A931CategoriasId )
      {
         /* Using cursor T001K32 */
         pr_default.execute(28, new Object[] {n942ServiciosId, A942ServiciosId, A931CategoriasId});
         if ( (pr_default.getStatus(28) == 101) )
         {
            if ( ! ( (0==A942ServiciosId) || (0==A931CategoriasId) ) )
            {
               GXCCtl = "CATEGORIASID_" + sGXsfl_93_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Categorias", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtCategoriasId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A944CategoriasNombre = T001K32_A944CategoriasNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A944CategoriasNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(28) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(28);
      }

      protected void GetKey1K142( )
      {
         /* Using cursor T001K33 */
         pr_default.execute(29, new Object[] {n422PostulacionesId, A422PostulacionesId, A931CategoriasId});
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound142 = 1;
         }
         else
         {
            RcdFound142 = 0;
         }
         pr_default.close(29);
      }

      protected void getByPrimaryKey1K142( )
      {
         /* Using cursor T001K8 */
         pr_default.execute(6, new Object[] {n422PostulacionesId, A422PostulacionesId, A931CategoriasId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM1K142( 30) ;
            RcdFound142 = 1;
            InitializeNonKey1K142( ) ;
            A931CategoriasId = T001K8_A931CategoriasId[0];
            Z422PostulacionesId = A422PostulacionesId;
            Z931CategoriasId = A931CategoriasId;
            sMode142 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1K142( ) ;
            Gx_mode = sMode142;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound142 = 0;
            InitializeNonKey1K142( ) ;
            sMode142 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1K142( ) ;
            Gx_mode = sMode142;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1K142( ) ;
         }
         pr_default.close(6);
      }

      protected void CheckOptimisticConcurrency1K142( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001K7 */
            pr_default.execute(5, new Object[] {n422PostulacionesId, A422PostulacionesId, A931CategoriasId});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PostulacionesCategorias"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(5) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PostulacionesCategorias"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1K142( )
      {
         BeforeValidate1K142( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K142( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1K142( 0) ;
            CheckOptimisticConcurrency1K142( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K142( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1K142( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001K34 */
                     pr_default.execute(30, new Object[] {n422PostulacionesId, A422PostulacionesId, A931CategoriasId});
                     pr_default.close(30);
                     pr_default.SmartCacheProvider.SetUpdated("PostulacionesCategorias");
                     if ( (pr_default.getStatus(30) == 1) )
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
               Load1K142( ) ;
            }
            EndLevel1K142( ) ;
         }
         CloseExtendedTableCursors1K142( ) ;
      }

      protected void Update1K142( )
      {
         BeforeValidate1K142( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K142( ) ;
         }
         if ( ( nIsMod_142 != 0 ) || ( nIsDirty_142 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1K142( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1K142( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1K142( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [PostulacionesCategorias] */
                        DeferredUpdate1K142( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1K142( ) ;
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
               EndLevel1K142( ) ;
            }
         }
         CloseExtendedTableCursors1K142( ) ;
      }

      protected void DeferredUpdate1K142( )
      {
      }

      protected void Delete1K142( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1K142( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K142( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1K142( ) ;
            AfterConfirm1K142( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1K142( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001K35 */
                  pr_default.execute(31, new Object[] {n422PostulacionesId, A422PostulacionesId, A931CategoriasId});
                  pr_default.close(31);
                  pr_default.SmartCacheProvider.SetUpdated("PostulacionesCategorias");
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
         sMode142 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1K142( ) ;
         Gx_mode = sMode142;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1K142( )
      {
         standaloneModal1K142( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001K36 */
            pr_default.execute(32, new Object[] {n942ServiciosId, A942ServiciosId, A931CategoriasId});
            A944CategoriasNombre = T001K36_A944CategoriasNombre[0];
            pr_default.close(32);
         }
      }

      protected void EndLevel1K142( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(5);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1K142( )
      {
         /* Scan By routine */
         /* Using cursor T001K37 */
         pr_default.execute(33, new Object[] {n422PostulacionesId, A422PostulacionesId});
         RcdFound142 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound142 = 1;
            A931CategoriasId = T001K37_A931CategoriasId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1K142( )
      {
         /* Scan next routine */
         pr_default.readNext(33);
         RcdFound142 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound142 = 1;
            A931CategoriasId = T001K37_A931CategoriasId[0];
         }
      }

      protected void ScanEnd1K142( )
      {
         pr_default.close(33);
      }

      protected void AfterConfirm1K142( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1K142( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1K142( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1K142( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1K142( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1K142( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1K142( )
      {
         edtCategoriasId_Enabled = 0;
         AssignProp("", false, edtCategoriasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriasId_Enabled), 5, 0), !bGXsfl_93_Refreshing);
         edtCategoriasNombre_Enabled = 0;
         AssignProp("", false, edtCategoriasNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriasNombre_Enabled), 5, 0), !bGXsfl_93_Refreshing);
      }

      protected void send_integrity_lvl_hashes1K142( )
      {
      }

      protected void ZM1K139( short GX_JID )
      {
         if ( ( GX_JID == 32 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z933MultimediaDireccion = T001K6_A933MultimediaDireccion[0];
               Z960MultimediaDescripcion = T001K6_A960MultimediaDescripcion[0];
               Z934MultimediaTipo = T001K6_A934MultimediaTipo[0];
            }
            else
            {
               Z933MultimediaDireccion = A933MultimediaDireccion;
               Z960MultimediaDescripcion = A960MultimediaDescripcion;
               Z934MultimediaTipo = A934MultimediaTipo;
            }
         }
         if ( GX_JID == -32 )
         {
            Z422PostulacionesId = A422PostulacionesId;
            Z932MultimediaId = A932MultimediaId;
            Z933MultimediaDireccion = A933MultimediaDireccion;
            Z960MultimediaDescripcion = A960MultimediaDescripcion;
            Z934MultimediaTipo = A934MultimediaTipo;
         }
      }

      protected void standaloneNotModal1K139( )
      {
         edtPostulacionesMultimediaSerial_Enabled = 0;
         AssignProp("", false, edtPostulacionesMultimediaSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesMultimediaSerial_Enabled), 5, 0), true);
         edtPostulacionesMultimediaSerial_Enabled = 0;
         AssignProp("", false, edtPostulacionesMultimediaSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesMultimediaSerial_Enabled), 5, 0), true);
      }

      protected void standaloneModal1K139( )
      {
         if ( IsIns( )  )
         {
            A961PostulacionesMultimediaSerial = (short)(O961PostulacionesMultimediaSerial+1);
            AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A932MultimediaId = A961PostulacionesMultimediaSerial;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtMultimediaId_Enabled = 0;
            AssignProp("", false, edtMultimediaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMultimediaId_Enabled), 5, 0), !bGXsfl_103_Refreshing);
         }
         else
         {
            edtMultimediaId_Enabled = 1;
            AssignProp("", false, edtMultimediaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMultimediaId_Enabled), 5, 0), !bGXsfl_103_Refreshing);
         }
      }

      protected void Load1K139( )
      {
         /* Using cursor T001K38 */
         pr_default.execute(34, new Object[] {n422PostulacionesId, A422PostulacionesId, A932MultimediaId});
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound139 = 1;
            A933MultimediaDireccion = T001K38_A933MultimediaDireccion[0];
            A960MultimediaDescripcion = T001K38_A960MultimediaDescripcion[0];
            A934MultimediaTipo = T001K38_A934MultimediaTipo[0];
            ZM1K139( -32) ;
         }
         pr_default.close(34);
         OnLoadActions1K139( ) ;
      }

      protected void OnLoadActions1K139( )
      {
      }

      protected void CheckExtendedTable1K139( )
      {
         nIsDirty_139 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1K139( ) ;
      }

      protected void CloseExtendedTableCursors1K139( )
      {
      }

      protected void enableDisable1K139( )
      {
      }

      protected void GetKey1K139( )
      {
         /* Using cursor T001K39 */
         pr_default.execute(35, new Object[] {n422PostulacionesId, A422PostulacionesId, A932MultimediaId});
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound139 = 1;
         }
         else
         {
            RcdFound139 = 0;
         }
         pr_default.close(35);
      }

      protected void getByPrimaryKey1K139( )
      {
         /* Using cursor T001K6 */
         pr_default.execute(4, new Object[] {n422PostulacionesId, A422PostulacionesId, A932MultimediaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM1K139( 32) ;
            RcdFound139 = 1;
            InitializeNonKey1K139( ) ;
            A932MultimediaId = T001K6_A932MultimediaId[0];
            A933MultimediaDireccion = T001K6_A933MultimediaDireccion[0];
            A960MultimediaDescripcion = T001K6_A960MultimediaDescripcion[0];
            A934MultimediaTipo = T001K6_A934MultimediaTipo[0];
            Z422PostulacionesId = A422PostulacionesId;
            Z932MultimediaId = A932MultimediaId;
            sMode139 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1K139( ) ;
            Gx_mode = sMode139;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound139 = 0;
            InitializeNonKey1K139( ) ;
            sMode139 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1K139( ) ;
            Gx_mode = sMode139;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1K139( ) ;
         }
         pr_default.close(4);
      }

      protected void CheckOptimisticConcurrency1K139( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001K5 */
            pr_default.execute(3, new Object[] {n422PostulacionesId, A422PostulacionesId, A932MultimediaId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PostulacionesMultimedia"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z933MultimediaDireccion, T001K5_A933MultimediaDireccion[0]) != 0 ) || ( StringUtil.StrCmp(Z960MultimediaDescripcion, T001K5_A960MultimediaDescripcion[0]) != 0 ) || ( StringUtil.StrCmp(Z934MultimediaTipo, T001K5_A934MultimediaTipo[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z933MultimediaDireccion, T001K5_A933MultimediaDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"MultimediaDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z933MultimediaDireccion);
                  GXUtil.WriteLogRaw("Current: ",T001K5_A933MultimediaDireccion[0]);
               }
               if ( StringUtil.StrCmp(Z960MultimediaDescripcion, T001K5_A960MultimediaDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"MultimediaDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z960MultimediaDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T001K5_A960MultimediaDescripcion[0]);
               }
               if ( StringUtil.StrCmp(Z934MultimediaTipo, T001K5_A934MultimediaTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"MultimediaTipo");
                  GXUtil.WriteLogRaw("Old: ",Z934MultimediaTipo);
                  GXUtil.WriteLogRaw("Current: ",T001K5_A934MultimediaTipo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PostulacionesMultimedia"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1K139( )
      {
         BeforeValidate1K139( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K139( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1K139( 0) ;
            CheckOptimisticConcurrency1K139( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K139( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1K139( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001K40 */
                     pr_default.execute(36, new Object[] {n422PostulacionesId, A422PostulacionesId, A932MultimediaId, A933MultimediaDireccion, A960MultimediaDescripcion, A934MultimediaTipo});
                     pr_default.close(36);
                     pr_default.SmartCacheProvider.SetUpdated("PostulacionesMultimedia");
                     if ( (pr_default.getStatus(36) == 1) )
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
               Load1K139( ) ;
            }
            EndLevel1K139( ) ;
         }
         CloseExtendedTableCursors1K139( ) ;
      }

      protected void Update1K139( )
      {
         BeforeValidate1K139( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K139( ) ;
         }
         if ( ( nIsMod_139 != 0 ) || ( nIsDirty_139 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1K139( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1K139( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1K139( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001K41 */
                        pr_default.execute(37, new Object[] {A933MultimediaDireccion, A960MultimediaDescripcion, A934MultimediaTipo, n422PostulacionesId, A422PostulacionesId, A932MultimediaId});
                        pr_default.close(37);
                        pr_default.SmartCacheProvider.SetUpdated("PostulacionesMultimedia");
                        if ( (pr_default.getStatus(37) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PostulacionesMultimedia"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1K139( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1K139( ) ;
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
               EndLevel1K139( ) ;
            }
         }
         CloseExtendedTableCursors1K139( ) ;
      }

      protected void DeferredUpdate1K139( )
      {
      }

      protected void Delete1K139( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1K139( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K139( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1K139( ) ;
            AfterConfirm1K139( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1K139( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001K42 */
                  pr_default.execute(38, new Object[] {n422PostulacionesId, A422PostulacionesId, A932MultimediaId});
                  pr_default.close(38);
                  pr_default.SmartCacheProvider.SetUpdated("PostulacionesMultimedia");
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
         sMode139 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1K139( ) ;
         Gx_mode = sMode139;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1K139( )
      {
         standaloneModal1K139( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1K139( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1K139( )
      {
         /* Scan By routine */
         /* Using cursor T001K43 */
         pr_default.execute(39, new Object[] {n422PostulacionesId, A422PostulacionesId});
         RcdFound139 = 0;
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound139 = 1;
            A932MultimediaId = T001K43_A932MultimediaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1K139( )
      {
         /* Scan next routine */
         pr_default.readNext(39);
         RcdFound139 = 0;
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound139 = 1;
            A932MultimediaId = T001K43_A932MultimediaId[0];
         }
      }

      protected void ScanEnd1K139( )
      {
         pr_default.close(39);
      }

      protected void AfterConfirm1K139( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1K139( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1K139( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1K139( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1K139( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1K139( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1K139( )
      {
         edtMultimediaId_Enabled = 0;
         AssignProp("", false, edtMultimediaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMultimediaId_Enabled), 5, 0), !bGXsfl_103_Refreshing);
         edtMultimediaDireccion_Enabled = 0;
         AssignProp("", false, edtMultimediaDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMultimediaDireccion_Enabled), 5, 0), !bGXsfl_103_Refreshing);
         edtMultimediaDescripcion_Enabled = 0;
         AssignProp("", false, edtMultimediaDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMultimediaDescripcion_Enabled), 5, 0), !bGXsfl_103_Refreshing);
         edtMultimediaTipo_Enabled = 0;
         AssignProp("", false, edtMultimediaTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMultimediaTipo_Enabled), 5, 0), !bGXsfl_103_Refreshing);
      }

      protected void send_integrity_lvl_hashes1K139( )
      {
      }

      protected void ZM1K137( short GX_JID )
      {
         if ( ( GX_JID == 33 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z956PostulacionProfesionalEstado = T001K3_A956PostulacionProfesionalEstado[0];
               Z957PostulacionProfesionalFechaA = T001K3_A957PostulacionProfesionalFechaA[0];
               Z958PostulacionProfesionalFechaT = T001K3_A958PostulacionProfesionalFechaT[0];
               Z959PostulacionProfesionalTurnoT = T001K3_A959PostulacionProfesionalTurnoT[0];
               Z982PostulacionProfesionalPrecio = T001K3_A982PostulacionProfesionalPrecio[0];
               Z983PostulacionProfesionalPlazoE = T001K3_A983PostulacionProfesionalPlazoE[0];
               Z986PostulacionProfesionalUniE = T001K3_A986PostulacionProfesionalUniE[0];
               Z985PostulacionProfesionalGar = T001K3_A985PostulacionProfesionalGar[0];
               Z987PostulacionProfesionalUniG = T001K3_A987PostulacionProfesionalUniG[0];
               Z984PostulacionProfesionalA = T001K3_A984PostulacionProfesionalA[0];
            }
            else
            {
               Z956PostulacionProfesionalEstado = A956PostulacionProfesionalEstado;
               Z957PostulacionProfesionalFechaA = A957PostulacionProfesionalFechaA;
               Z958PostulacionProfesionalFechaT = A958PostulacionProfesionalFechaT;
               Z959PostulacionProfesionalTurnoT = A959PostulacionProfesionalTurnoT;
               Z982PostulacionProfesionalPrecio = A982PostulacionProfesionalPrecio;
               Z983PostulacionProfesionalPlazoE = A983PostulacionProfesionalPlazoE;
               Z986PostulacionProfesionalUniE = A986PostulacionProfesionalUniE;
               Z985PostulacionProfesionalGar = A985PostulacionProfesionalGar;
               Z987PostulacionProfesionalUniG = A987PostulacionProfesionalUniG;
               Z984PostulacionProfesionalA = A984PostulacionProfesionalA;
            }
         }
         if ( GX_JID == -33 )
         {
            Z422PostulacionesId = A422PostulacionesId;
            Z956PostulacionProfesionalEstado = A956PostulacionProfesionalEstado;
            Z957PostulacionProfesionalFechaA = A957PostulacionProfesionalFechaA;
            Z958PostulacionProfesionalFechaT = A958PostulacionProfesionalFechaT;
            Z959PostulacionProfesionalTurnoT = A959PostulacionProfesionalTurnoT;
            Z982PostulacionProfesionalPrecio = A982PostulacionProfesionalPrecio;
            Z983PostulacionProfesionalPlazoE = A983PostulacionProfesionalPlazoE;
            Z986PostulacionProfesionalUniE = A986PostulacionProfesionalUniE;
            Z985PostulacionProfesionalGar = A985PostulacionProfesionalGar;
            Z987PostulacionProfesionalUniG = A987PostulacionProfesionalUniG;
            Z984PostulacionProfesionalA = A984PostulacionProfesionalA;
            Z120ProfesionalesId = A120ProfesionalesId;
            Z167ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
            Z166ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
            Z191ProfesionalesSegundoNombre = A191ProfesionalesSegundoNombre;
         }
      }

      protected void standaloneNotModal1K137( )
      {
         edtPostulacionProfesionalFechaA_Enabled = 0;
         AssignProp("", false, edtPostulacionProfesionalFechaA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalFechaA_Enabled), 5, 0), !bGXsfl_115_Refreshing);
      }

      protected void standaloneModal1K137( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProfesionalesId_Enabled = 0;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_115_Refreshing);
         }
         else
         {
            edtProfesionalesId_Enabled = 1;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_115_Refreshing);
         }
      }

      protected void Load1K137( )
      {
         /* Using cursor T001K44 */
         pr_default.execute(40, new Object[] {n422PostulacionesId, A422PostulacionesId, A120ProfesionalesId});
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound137 = 1;
            A956PostulacionProfesionalEstado = T001K44_A956PostulacionProfesionalEstado[0];
            A957PostulacionProfesionalFechaA = T001K44_A957PostulacionProfesionalFechaA[0];
            A958PostulacionProfesionalFechaT = T001K44_A958PostulacionProfesionalFechaT[0];
            A959PostulacionProfesionalTurnoT = T001K44_A959PostulacionProfesionalTurnoT[0];
            A982PostulacionProfesionalPrecio = T001K44_A982PostulacionProfesionalPrecio[0];
            n982PostulacionProfesionalPrecio = T001K44_n982PostulacionProfesionalPrecio[0];
            A983PostulacionProfesionalPlazoE = T001K44_A983PostulacionProfesionalPlazoE[0];
            n983PostulacionProfesionalPlazoE = T001K44_n983PostulacionProfesionalPlazoE[0];
            A986PostulacionProfesionalUniE = T001K44_A986PostulacionProfesionalUniE[0];
            n986PostulacionProfesionalUniE = T001K44_n986PostulacionProfesionalUniE[0];
            A985PostulacionProfesionalGar = T001K44_A985PostulacionProfesionalGar[0];
            n985PostulacionProfesionalGar = T001K44_n985PostulacionProfesionalGar[0];
            A987PostulacionProfesionalUniG = T001K44_A987PostulacionProfesionalUniG[0];
            n987PostulacionProfesionalUniG = T001K44_n987PostulacionProfesionalUniG[0];
            A984PostulacionProfesionalA = T001K44_A984PostulacionProfesionalA[0];
            n984PostulacionProfesionalA = T001K44_n984PostulacionProfesionalA[0];
            A167ProfesionalesApellidoPrimero = T001K44_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = T001K44_A166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = T001K44_A191ProfesionalesSegundoNombre[0];
            ZM1K137( -33) ;
         }
         pr_default.close(40);
         OnLoadActions1K137( ) ;
      }

      protected void OnLoadActions1K137( )
      {
         A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
      }

      protected void CheckExtendedTable1K137( )
      {
         nIsDirty_137 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1K137( ) ;
         /* Using cursor T001K4 */
         pr_default.execute(2, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PROFESIONALESID_" + sGXsfl_115_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A167ProfesionalesApellidoPrimero = T001K4_A167ProfesionalesApellidoPrimero[0];
         A166ProfesionalesPrimerNombre = T001K4_A166ProfesionalesPrimerNombre[0];
         A191ProfesionalesSegundoNombre = T001K4_A191ProfesionalesSegundoNombre[0];
         pr_default.close(2);
         nIsDirty_137 = 1;
         A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
         if ( ! ( ( StringUtil.StrCmp(A956PostulacionProfesionalEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A956PostulacionProfesionalEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A956PostulacionProfesionalEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A956PostulacionProfesionalEstado, "BLO") == 0 ) ) )
         {
            GXCCtl = "POSTULACIONPROFESIONALESTADO_" + sGXsfl_115_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Postulacion Profesional Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbPostulacionProfesionalEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A958PostulacionProfesionalFechaT) || ( DateTimeUtil.ResetTime ( A958PostulacionProfesionalFechaT ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GXCCtl = "POSTULACIONPROFESIONALFECHAT_" + sGXsfl_115_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Postulacion Profesional Fecha T", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPostulacionProfesionalFechaT_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A986PostulacionProfesionalUniE, "D") == 0 ) || ( StringUtil.StrCmp(A986PostulacionProfesionalUniE, "M") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A986PostulacionProfesionalUniE)) ) )
         {
            GXCCtl = "POSTULACIONPROFESIONALUNIE_" + sGXsfl_115_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Unidad tiempo de ejecucion", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbPostulacionProfesionalUniE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A987PostulacionProfesionalUniG, "D") == 0 ) || ( StringUtil.StrCmp(A987PostulacionProfesionalUniG, "M") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A987PostulacionProfesionalUniG)) ) )
         {
            GXCCtl = "POSTULACIONPROFESIONALUNIG_" + sGXsfl_115_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Unidad tiempo Garantia", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbPostulacionProfesionalUniG_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1K137( )
      {
         pr_default.close(2);
      }

      protected void enableDisable1K137( )
      {
      }

      protected void gxLoad_34( string A120ProfesionalesId )
      {
         /* Using cursor T001K45 */
         pr_default.execute(41, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(41) == 101) )
         {
            GXCCtl = "PROFESIONALESID_" + sGXsfl_115_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A167ProfesionalesApellidoPrimero = T001K45_A167ProfesionalesApellidoPrimero[0];
         A166ProfesionalesPrimerNombre = T001K45_A166ProfesionalesPrimerNombre[0];
         A191ProfesionalesSegundoNombre = T001K45_A191ProfesionalesSegundoNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A167ProfesionalesApellidoPrimero))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A166ProfesionalesPrimerNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A191ProfesionalesSegundoNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(41) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(41);
      }

      protected void GetKey1K137( )
      {
         /* Using cursor T001K46 */
         pr_default.execute(42, new Object[] {n422PostulacionesId, A422PostulacionesId, A120ProfesionalesId});
         if ( (pr_default.getStatus(42) != 101) )
         {
            RcdFound137 = 1;
         }
         else
         {
            RcdFound137 = 0;
         }
         pr_default.close(42);
      }

      protected void getByPrimaryKey1K137( )
      {
         /* Using cursor T001K3 */
         pr_default.execute(1, new Object[] {n422PostulacionesId, A422PostulacionesId, A120ProfesionalesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1K137( 33) ;
            RcdFound137 = 1;
            InitializeNonKey1K137( ) ;
            A956PostulacionProfesionalEstado = T001K3_A956PostulacionProfesionalEstado[0];
            A957PostulacionProfesionalFechaA = T001K3_A957PostulacionProfesionalFechaA[0];
            A958PostulacionProfesionalFechaT = T001K3_A958PostulacionProfesionalFechaT[0];
            A959PostulacionProfesionalTurnoT = T001K3_A959PostulacionProfesionalTurnoT[0];
            A982PostulacionProfesionalPrecio = T001K3_A982PostulacionProfesionalPrecio[0];
            n982PostulacionProfesionalPrecio = T001K3_n982PostulacionProfesionalPrecio[0];
            A983PostulacionProfesionalPlazoE = T001K3_A983PostulacionProfesionalPlazoE[0];
            n983PostulacionProfesionalPlazoE = T001K3_n983PostulacionProfesionalPlazoE[0];
            A986PostulacionProfesionalUniE = T001K3_A986PostulacionProfesionalUniE[0];
            n986PostulacionProfesionalUniE = T001K3_n986PostulacionProfesionalUniE[0];
            A985PostulacionProfesionalGar = T001K3_A985PostulacionProfesionalGar[0];
            n985PostulacionProfesionalGar = T001K3_n985PostulacionProfesionalGar[0];
            A987PostulacionProfesionalUniG = T001K3_A987PostulacionProfesionalUniG[0];
            n987PostulacionProfesionalUniG = T001K3_n987PostulacionProfesionalUniG[0];
            A984PostulacionProfesionalA = T001K3_A984PostulacionProfesionalA[0];
            n984PostulacionProfesionalA = T001K3_n984PostulacionProfesionalA[0];
            A120ProfesionalesId = T001K3_A120ProfesionalesId[0];
            Z422PostulacionesId = A422PostulacionesId;
            Z120ProfesionalesId = A120ProfesionalesId;
            sMode137 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1K137( ) ;
            Gx_mode = sMode137;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound137 = 0;
            InitializeNonKey1K137( ) ;
            sMode137 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1K137( ) ;
            Gx_mode = sMode137;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1K137( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1K137( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001K2 */
            pr_default.execute(0, new Object[] {n422PostulacionesId, A422PostulacionesId, A120ProfesionalesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PostulacionesProfesionales"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z956PostulacionProfesionalEstado, T001K2_A956PostulacionProfesionalEstado[0]) != 0 ) || ( Z957PostulacionProfesionalFechaA != T001K2_A957PostulacionProfesionalFechaA[0] ) || ( DateTimeUtil.ResetTime ( Z958PostulacionProfesionalFechaT ) != DateTimeUtil.ResetTime ( T001K2_A958PostulacionProfesionalFechaT[0] ) ) || ( StringUtil.StrCmp(Z959PostulacionProfesionalTurnoT, T001K2_A959PostulacionProfesionalTurnoT[0]) != 0 ) || ( Z982PostulacionProfesionalPrecio != T001K2_A982PostulacionProfesionalPrecio[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z983PostulacionProfesionalPlazoE != T001K2_A983PostulacionProfesionalPlazoE[0] ) || ( StringUtil.StrCmp(Z986PostulacionProfesionalUniE, T001K2_A986PostulacionProfesionalUniE[0]) != 0 ) || ( Z985PostulacionProfesionalGar != T001K2_A985PostulacionProfesionalGar[0] ) || ( StringUtil.StrCmp(Z987PostulacionProfesionalUniG, T001K2_A987PostulacionProfesionalUniG[0]) != 0 ) || ( StringUtil.StrCmp(Z984PostulacionProfesionalA, T001K2_A984PostulacionProfesionalA[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z956PostulacionProfesionalEstado, T001K2_A956PostulacionProfesionalEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionProfesionalEstado");
                  GXUtil.WriteLogRaw("Old: ",Z956PostulacionProfesionalEstado);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A956PostulacionProfesionalEstado[0]);
               }
               if ( Z957PostulacionProfesionalFechaA != T001K2_A957PostulacionProfesionalFechaA[0] )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionProfesionalFechaA");
                  GXUtil.WriteLogRaw("Old: ",Z957PostulacionProfesionalFechaA);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A957PostulacionProfesionalFechaA[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z958PostulacionProfesionalFechaT ) != DateTimeUtil.ResetTime ( T001K2_A958PostulacionProfesionalFechaT[0] ) )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionProfesionalFechaT");
                  GXUtil.WriteLogRaw("Old: ",Z958PostulacionProfesionalFechaT);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A958PostulacionProfesionalFechaT[0]);
               }
               if ( StringUtil.StrCmp(Z959PostulacionProfesionalTurnoT, T001K2_A959PostulacionProfesionalTurnoT[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionProfesionalTurnoT");
                  GXUtil.WriteLogRaw("Old: ",Z959PostulacionProfesionalTurnoT);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A959PostulacionProfesionalTurnoT[0]);
               }
               if ( Z982PostulacionProfesionalPrecio != T001K2_A982PostulacionProfesionalPrecio[0] )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionProfesionalPrecio");
                  GXUtil.WriteLogRaw("Old: ",Z982PostulacionProfesionalPrecio);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A982PostulacionProfesionalPrecio[0]);
               }
               if ( Z983PostulacionProfesionalPlazoE != T001K2_A983PostulacionProfesionalPlazoE[0] )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionProfesionalPlazoE");
                  GXUtil.WriteLogRaw("Old: ",Z983PostulacionProfesionalPlazoE);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A983PostulacionProfesionalPlazoE[0]);
               }
               if ( StringUtil.StrCmp(Z986PostulacionProfesionalUniE, T001K2_A986PostulacionProfesionalUniE[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionProfesionalUniE");
                  GXUtil.WriteLogRaw("Old: ",Z986PostulacionProfesionalUniE);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A986PostulacionProfesionalUniE[0]);
               }
               if ( Z985PostulacionProfesionalGar != T001K2_A985PostulacionProfesionalGar[0] )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionProfesionalGar");
                  GXUtil.WriteLogRaw("Old: ",Z985PostulacionProfesionalGar);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A985PostulacionProfesionalGar[0]);
               }
               if ( StringUtil.StrCmp(Z987PostulacionProfesionalUniG, T001K2_A987PostulacionProfesionalUniG[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionProfesionalUniG");
                  GXUtil.WriteLogRaw("Old: ",Z987PostulacionProfesionalUniG);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A987PostulacionProfesionalUniG[0]);
               }
               if ( StringUtil.StrCmp(Z984PostulacionProfesionalA, T001K2_A984PostulacionProfesionalA[0]) != 0 )
               {
                  GXUtil.WriteLog("postulaciones:[seudo value changed for attri]"+"PostulacionProfesionalA");
                  GXUtil.WriteLogRaw("Old: ",Z984PostulacionProfesionalA);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A984PostulacionProfesionalA[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PostulacionesProfesionales"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1K137( )
      {
         BeforeValidate1K137( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K137( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1K137( 0) ;
            CheckOptimisticConcurrency1K137( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K137( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1K137( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001K47 */
                     pr_default.execute(43, new Object[] {n422PostulacionesId, A422PostulacionesId, A956PostulacionProfesionalEstado, A957PostulacionProfesionalFechaA, A958PostulacionProfesionalFechaT, A959PostulacionProfesionalTurnoT, n982PostulacionProfesionalPrecio, A982PostulacionProfesionalPrecio, n983PostulacionProfesionalPlazoE, A983PostulacionProfesionalPlazoE, n986PostulacionProfesionalUniE, A986PostulacionProfesionalUniE, n985PostulacionProfesionalGar, A985PostulacionProfesionalGar, n987PostulacionProfesionalUniG, A987PostulacionProfesionalUniG, n984PostulacionProfesionalA, A984PostulacionProfesionalA, A120ProfesionalesId});
                     pr_default.close(43);
                     pr_default.SmartCacheProvider.SetUpdated("PostulacionesProfesionales");
                     if ( (pr_default.getStatus(43) == 1) )
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
               Load1K137( ) ;
            }
            EndLevel1K137( ) ;
         }
         CloseExtendedTableCursors1K137( ) ;
      }

      protected void Update1K137( )
      {
         BeforeValidate1K137( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K137( ) ;
         }
         if ( ( nIsMod_137 != 0 ) || ( nIsDirty_137 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1K137( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1K137( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1K137( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001K48 */
                        pr_default.execute(44, new Object[] {A956PostulacionProfesionalEstado, A957PostulacionProfesionalFechaA, A958PostulacionProfesionalFechaT, A959PostulacionProfesionalTurnoT, n982PostulacionProfesionalPrecio, A982PostulacionProfesionalPrecio, n983PostulacionProfesionalPlazoE, A983PostulacionProfesionalPlazoE, n986PostulacionProfesionalUniE, A986PostulacionProfesionalUniE, n985PostulacionProfesionalGar, A985PostulacionProfesionalGar, n987PostulacionProfesionalUniG, A987PostulacionProfesionalUniG, n984PostulacionProfesionalA, A984PostulacionProfesionalA, n422PostulacionesId, A422PostulacionesId, A120ProfesionalesId});
                        pr_default.close(44);
                        pr_default.SmartCacheProvider.SetUpdated("PostulacionesProfesionales");
                        if ( (pr_default.getStatus(44) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PostulacionesProfesionales"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1K137( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1K137( ) ;
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
               EndLevel1K137( ) ;
            }
         }
         CloseExtendedTableCursors1K137( ) ;
      }

      protected void DeferredUpdate1K137( )
      {
      }

      protected void Delete1K137( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1K137( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K137( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1K137( ) ;
            AfterConfirm1K137( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1K137( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001K49 */
                  pr_default.execute(45, new Object[] {n422PostulacionesId, A422PostulacionesId, A120ProfesionalesId});
                  pr_default.close(45);
                  pr_default.SmartCacheProvider.SetUpdated("PostulacionesProfesionales");
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
         sMode137 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1K137( ) ;
         Gx_mode = sMode137;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1K137( )
      {
         standaloneModal1K137( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001K50 */
            pr_default.execute(46, new Object[] {A120ProfesionalesId});
            A167ProfesionalesApellidoPrimero = T001K50_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = T001K50_A166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = T001K50_A191ProfesionalesSegundoNombre[0];
            pr_default.close(46);
            A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
         }
      }

      protected void EndLevel1K137( )
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

      public void ScanStart1K137( )
      {
         /* Scan By routine */
         /* Using cursor T001K51 */
         pr_default.execute(47, new Object[] {n422PostulacionesId, A422PostulacionesId});
         RcdFound137 = 0;
         if ( (pr_default.getStatus(47) != 101) )
         {
            RcdFound137 = 1;
            A120ProfesionalesId = T001K51_A120ProfesionalesId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1K137( )
      {
         /* Scan next routine */
         pr_default.readNext(47);
         RcdFound137 = 0;
         if ( (pr_default.getStatus(47) != 101) )
         {
            RcdFound137 = 1;
            A120ProfesionalesId = T001K51_A120ProfesionalesId[0];
         }
      }

      protected void ScanEnd1K137( )
      {
         pr_default.close(47);
      }

      protected void AfterConfirm1K137( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1K137( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1K137( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1K137( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1K137( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1K137( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1K137( )
      {
         edtProfesionalesId_Enabled = 0;
         AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_115_Refreshing);
         edtProfesionalesNombreCompleto_Enabled = 0;
         AssignProp("", false, edtProfesionalesNombreCompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesNombreCompleto_Enabled), 5, 0), !bGXsfl_115_Refreshing);
         cmbPostulacionProfesionalEstado.Enabled = 0;
         AssignProp("", false, cmbPostulacionProfesionalEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPostulacionProfesionalEstado.Enabled), 5, 0), !bGXsfl_115_Refreshing);
         edtPostulacionProfesionalFechaA_Enabled = 0;
         AssignProp("", false, edtPostulacionProfesionalFechaA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalFechaA_Enabled), 5, 0), !bGXsfl_115_Refreshing);
         edtPostulacionProfesionalPrecio_Enabled = 0;
         AssignProp("", false, edtPostulacionProfesionalPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalPrecio_Enabled), 5, 0), !bGXsfl_115_Refreshing);
         edtPostulacionProfesionalFechaT_Enabled = 0;
         AssignProp("", false, edtPostulacionProfesionalFechaT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalFechaT_Enabled), 5, 0), !bGXsfl_115_Refreshing);
         edtPostulacionProfesionalTurnoT_Enabled = 0;
         AssignProp("", false, edtPostulacionProfesionalTurnoT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalTurnoT_Enabled), 5, 0), !bGXsfl_115_Refreshing);
         edtPostulacionProfesionalPlazoE_Enabled = 0;
         AssignProp("", false, edtPostulacionProfesionalPlazoE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalPlazoE_Enabled), 5, 0), !bGXsfl_115_Refreshing);
         cmbPostulacionProfesionalUniE.Enabled = 0;
         AssignProp("", false, cmbPostulacionProfesionalUniE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPostulacionProfesionalUniE.Enabled), 5, 0), !bGXsfl_115_Refreshing);
         edtPostulacionProfesionalGar_Enabled = 0;
         AssignProp("", false, edtPostulacionProfesionalGar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalGar_Enabled), 5, 0), !bGXsfl_115_Refreshing);
         cmbPostulacionProfesionalUniG.Enabled = 0;
         AssignProp("", false, cmbPostulacionProfesionalUniG_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPostulacionProfesionalUniG.Enabled), 5, 0), !bGXsfl_115_Refreshing);
         edtPostulacionProfesionalA_Enabled = 0;
         AssignProp("", false, edtPostulacionProfesionalA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalA_Enabled), 5, 0), !bGXsfl_115_Refreshing);
      }

      protected void send_integrity_lvl_hashes1K137( )
      {
      }

      protected void send_integrity_lvl_hashes1K126( )
      {
      }

      protected void SubsflControlProps_93142( )
      {
         edtCategoriasId_Internalname = "CATEGORIASID_"+sGXsfl_93_idx;
         imgprompt_931_Internalname = "PROMPT_931_"+sGXsfl_93_idx;
         edtCategoriasNombre_Internalname = "CATEGORIASNOMBRE_"+sGXsfl_93_idx;
      }

      protected void SubsflControlProps_fel_93142( )
      {
         edtCategoriasId_Internalname = "CATEGORIASID_"+sGXsfl_93_fel_idx;
         imgprompt_931_Internalname = "PROMPT_931_"+sGXsfl_93_fel_idx;
         edtCategoriasNombre_Internalname = "CATEGORIASNOMBRE_"+sGXsfl_93_fel_idx;
      }

      protected void AddRow1K142( )
      {
         nGXsfl_93_idx = (int)(nGXsfl_93_idx+1);
         sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx), 4, 0), 4, "0");
         SubsflControlProps_93142( ) ;
         SendRow1K142( ) ;
      }

      protected void SendRow1K142( )
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
            if ( ((int)((nGXsfl_93_idx) % (2))) == 0 )
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
         imgprompt_931_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx03x1.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SERVICIOSID"+"'), id:'"+"SERVICIOSID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"CATEGORIASID_"+sGXsfl_93_idx+"'), id:'"+"CATEGORIASID_"+sGXsfl_93_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_142_"+sGXsfl_93_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_142_" + sGXsfl_93_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_93_idx + "',93)\"";
         ROClassString = "Attribute";
         Gridlevel_categoriasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoriasId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A931CategoriasId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A931CategoriasId), "ZZZZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,94);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoriasId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCategoriasId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)93,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_931_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_931_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_categoriasRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_931_Internalname,(string)sImgUrl,(string)imgprompt_931_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_931_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_142_" + sGXsfl_93_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_93_idx + "',93)\"";
         ROClassString = "Attribute";
         Gridlevel_categoriasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoriasNombre_Internalname,StringUtil.RTrim( A944CategoriasNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoriasNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCategoriasNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)93,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_categoriasRow);
         send_integrity_lvl_hashes1K142( ) ;
         GXCCtl = "Z931CategoriasId_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z931CategoriasId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_142_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_142), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_142_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_142), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_142_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_142), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_93_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV12TrnContext);
         }
         GXCCtl = "vPOSTULACIONESID_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CATEGORIASID_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriasId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CATEGORIASNOMBRE_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriasNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_931_"+sGXsfl_93_idx+"Link", StringUtil.RTrim( imgprompt_931_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_categoriasContainer.AddRow(Gridlevel_categoriasRow);
      }

      protected void ReadRow1K142( )
      {
         nGXsfl_93_idx = (int)(nGXsfl_93_idx+1);
         sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx), 4, 0), 4, "0");
         SubsflControlProps_93142( ) ;
         edtCategoriasId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORIASID_"+sGXsfl_93_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCategoriasNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORIASNOMBRE_"+sGXsfl_93_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_945_Link = cgiGet( "PROMPT_931_"+sGXsfl_93_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtCategoriasId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCategoriasId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "CATEGORIASID_" + sGXsfl_93_idx;
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
         GXCCtl = "Z931CategoriasId_" + sGXsfl_93_idx;
         Z931CategoriasId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_142_" + sGXsfl_93_idx;
         nRcdDeleted_142 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_142_" + sGXsfl_93_idx;
         nRcdExists_142 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_142_" + sGXsfl_93_idx;
         nIsMod_142 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_103139( )
      {
         edtMultimediaId_Internalname = "MULTIMEDIAID_"+sGXsfl_103_idx;
         edtMultimediaDireccion_Internalname = "MULTIMEDIADIRECCION_"+sGXsfl_103_idx;
         edtMultimediaDescripcion_Internalname = "MULTIMEDIADESCRIPCION_"+sGXsfl_103_idx;
         edtMultimediaTipo_Internalname = "MULTIMEDIATIPO_"+sGXsfl_103_idx;
      }

      protected void SubsflControlProps_fel_103139( )
      {
         edtMultimediaId_Internalname = "MULTIMEDIAID_"+sGXsfl_103_fel_idx;
         edtMultimediaDireccion_Internalname = "MULTIMEDIADIRECCION_"+sGXsfl_103_fel_idx;
         edtMultimediaDescripcion_Internalname = "MULTIMEDIADESCRIPCION_"+sGXsfl_103_fel_idx;
         edtMultimediaTipo_Internalname = "MULTIMEDIATIPO_"+sGXsfl_103_fel_idx;
      }

      protected void AddRow1K139( )
      {
         nGXsfl_103_idx = (int)(nGXsfl_103_idx+1);
         sGXsfl_103_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_103_idx), 4, 0), 4, "0");
         SubsflControlProps_103139( ) ;
         SendRow1K139( ) ;
      }

      protected void SendRow1K139( )
      {
         Gridlevel_multimediaRow = GXWebRow.GetNew(context);
         if ( subGridlevel_multimedia_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_multimedia_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_multimedia_Class, "") != 0 )
            {
               subGridlevel_multimedia_Linesclass = subGridlevel_multimedia_Class+"Odd";
            }
         }
         else if ( subGridlevel_multimedia_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_multimedia_Backstyle = 0;
            subGridlevel_multimedia_Backcolor = subGridlevel_multimedia_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_multimedia_Class, "") != 0 )
            {
               subGridlevel_multimedia_Linesclass = subGridlevel_multimedia_Class+"Uniform";
            }
         }
         else if ( subGridlevel_multimedia_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_multimedia_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_multimedia_Class, "") != 0 )
            {
               subGridlevel_multimedia_Linesclass = subGridlevel_multimedia_Class+"Odd";
            }
            subGridlevel_multimedia_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_multimedia_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_multimedia_Backstyle = 1;
            if ( ((int)((nGXsfl_103_idx) % (2))) == 0 )
            {
               subGridlevel_multimedia_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_multimedia_Class, "") != 0 )
               {
                  subGridlevel_multimedia_Linesclass = subGridlevel_multimedia_Class+"Even";
               }
            }
            else
            {
               subGridlevel_multimedia_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_multimedia_Class, "") != 0 )
               {
                  subGridlevel_multimedia_Linesclass = subGridlevel_multimedia_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_139_" + sGXsfl_103_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 104,'',false,'" + sGXsfl_103_idx + "',103)\"";
         ROClassString = "Attribute";
         Gridlevel_multimediaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMultimediaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A932MultimediaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A932MultimediaId), "ZZZZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,104);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMultimediaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtMultimediaId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)103,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_139_" + sGXsfl_103_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_103_idx + "',103)\"";
         ROClassString = "Attribute";
         Gridlevel_multimediaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMultimediaDireccion_Internalname,StringUtil.RTrim( A933MultimediaDireccion),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMultimediaDireccion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtMultimediaDireccion_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)103,(short)0,(short)-1,(short)-1,(bool)true,(string)"Direccion",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_139_" + sGXsfl_103_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_103_idx + "',103)\"";
         ROClassString = "Attribute";
         Gridlevel_multimediaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMultimediaDescripcion_Internalname,StringUtil.RTrim( A960MultimediaDescripcion),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMultimediaDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtMultimediaDescripcion_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)250,(short)0,(short)0,(short)103,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_139_" + sGXsfl_103_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 107,'',false,'" + sGXsfl_103_idx + "',103)\"";
         ROClassString = "Attribute";
         Gridlevel_multimediaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMultimediaTipo_Internalname,(string)A934MultimediaTipo,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMultimediaTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtMultimediaTipo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)103,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_multimediaRow);
         send_integrity_lvl_hashes1K139( ) ;
         GXCCtl = "Z932MultimediaId_" + sGXsfl_103_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z932MultimediaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z933MultimediaDireccion_" + sGXsfl_103_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z933MultimediaDireccion));
         GXCCtl = "Z960MultimediaDescripcion_" + sGXsfl_103_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z960MultimediaDescripcion));
         GXCCtl = "Z934MultimediaTipo_" + sGXsfl_103_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z934MultimediaTipo);
         GXCCtl = "nRcdDeleted_139_" + sGXsfl_103_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_139), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_139_" + sGXsfl_103_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_139), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_139_" + sGXsfl_103_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_139), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_103_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_103_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV12TrnContext);
         }
         GXCCtl = "vPOSTULACIONESID_" + sGXsfl_103_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "MULTIMEDIAID_"+sGXsfl_103_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MULTIMEDIADIRECCION_"+sGXsfl_103_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaDireccion_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MULTIMEDIADESCRIPCION_"+sGXsfl_103_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaDescripcion_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MULTIMEDIATIPO_"+sGXsfl_103_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaTipo_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_multimediaContainer.AddRow(Gridlevel_multimediaRow);
      }

      protected void ReadRow1K139( )
      {
         nGXsfl_103_idx = (int)(nGXsfl_103_idx+1);
         sGXsfl_103_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_103_idx), 4, 0), 4, "0");
         SubsflControlProps_103139( ) ;
         edtMultimediaId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MULTIMEDIAID_"+sGXsfl_103_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtMultimediaDireccion_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MULTIMEDIADIRECCION_"+sGXsfl_103_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtMultimediaDescripcion_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MULTIMEDIADESCRIPCION_"+sGXsfl_103_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtMultimediaTipo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MULTIMEDIATIPO_"+sGXsfl_103_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtMultimediaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMultimediaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "MULTIMEDIAID_" + sGXsfl_103_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtMultimediaId_Internalname;
            wbErr = true;
            A932MultimediaId = 0;
         }
         else
         {
            A932MultimediaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMultimediaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A933MultimediaDireccion = cgiGet( edtMultimediaDireccion_Internalname);
         A960MultimediaDescripcion = cgiGet( edtMultimediaDescripcion_Internalname);
         A934MultimediaTipo = cgiGet( edtMultimediaTipo_Internalname);
         GXCCtl = "Z932MultimediaId_" + sGXsfl_103_idx;
         Z932MultimediaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z933MultimediaDireccion_" + sGXsfl_103_idx;
         Z933MultimediaDireccion = cgiGet( GXCCtl);
         GXCCtl = "Z960MultimediaDescripcion_" + sGXsfl_103_idx;
         Z960MultimediaDescripcion = cgiGet( GXCCtl);
         GXCCtl = "Z934MultimediaTipo_" + sGXsfl_103_idx;
         Z934MultimediaTipo = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_139_" + sGXsfl_103_idx;
         nRcdDeleted_139 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_139_" + sGXsfl_103_idx;
         nRcdExists_139 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_139_" + sGXsfl_103_idx;
         nIsMod_139 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_115137( )
      {
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_115_idx;
         imgprompt_120_Internalname = "PROMPT_120_"+sGXsfl_115_idx;
         edtProfesionalesNombreCompleto_Internalname = "PROFESIONALESNOMBRECOMPLETO_"+sGXsfl_115_idx;
         cmbPostulacionProfesionalEstado_Internalname = "POSTULACIONPROFESIONALESTADO_"+sGXsfl_115_idx;
         edtPostulacionProfesionalFechaA_Internalname = "POSTULACIONPROFESIONALFECHAA_"+sGXsfl_115_idx;
         edtPostulacionProfesionalPrecio_Internalname = "POSTULACIONPROFESIONALPRECIO_"+sGXsfl_115_idx;
         edtPostulacionProfesionalFechaT_Internalname = "POSTULACIONPROFESIONALFECHAT_"+sGXsfl_115_idx;
         edtPostulacionProfesionalTurnoT_Internalname = "POSTULACIONPROFESIONALTURNOT_"+sGXsfl_115_idx;
         edtPostulacionProfesionalPlazoE_Internalname = "POSTULACIONPROFESIONALPLAZOE_"+sGXsfl_115_idx;
         cmbPostulacionProfesionalUniE_Internalname = "POSTULACIONPROFESIONALUNIE_"+sGXsfl_115_idx;
         edtPostulacionProfesionalGar_Internalname = "POSTULACIONPROFESIONALGAR_"+sGXsfl_115_idx;
         cmbPostulacionProfesionalUniG_Internalname = "POSTULACIONPROFESIONALUNIG_"+sGXsfl_115_idx;
         edtPostulacionProfesionalA_Internalname = "POSTULACIONPROFESIONALA_"+sGXsfl_115_idx;
         edtavVermas_Internalname = "vVERMAS_"+sGXsfl_115_idx;
      }

      protected void SubsflControlProps_fel_115137( )
      {
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_115_fel_idx;
         imgprompt_120_Internalname = "PROMPT_120_"+sGXsfl_115_fel_idx;
         edtProfesionalesNombreCompleto_Internalname = "PROFESIONALESNOMBRECOMPLETO_"+sGXsfl_115_fel_idx;
         cmbPostulacionProfesionalEstado_Internalname = "POSTULACIONPROFESIONALESTADO_"+sGXsfl_115_fel_idx;
         edtPostulacionProfesionalFechaA_Internalname = "POSTULACIONPROFESIONALFECHAA_"+sGXsfl_115_fel_idx;
         edtPostulacionProfesionalPrecio_Internalname = "POSTULACIONPROFESIONALPRECIO_"+sGXsfl_115_fel_idx;
         edtPostulacionProfesionalFechaT_Internalname = "POSTULACIONPROFESIONALFECHAT_"+sGXsfl_115_fel_idx;
         edtPostulacionProfesionalTurnoT_Internalname = "POSTULACIONPROFESIONALTURNOT_"+sGXsfl_115_fel_idx;
         edtPostulacionProfesionalPlazoE_Internalname = "POSTULACIONPROFESIONALPLAZOE_"+sGXsfl_115_fel_idx;
         cmbPostulacionProfesionalUniE_Internalname = "POSTULACIONPROFESIONALUNIE_"+sGXsfl_115_fel_idx;
         edtPostulacionProfesionalGar_Internalname = "POSTULACIONPROFESIONALGAR_"+sGXsfl_115_fel_idx;
         cmbPostulacionProfesionalUniG_Internalname = "POSTULACIONPROFESIONALUNIG_"+sGXsfl_115_fel_idx;
         edtPostulacionProfesionalA_Internalname = "POSTULACIONPROFESIONALA_"+sGXsfl_115_fel_idx;
         edtavVermas_Internalname = "vVERMAS_"+sGXsfl_115_fel_idx;
      }

      protected void AddRow1K137( )
      {
         nGXsfl_115_idx = (int)(nGXsfl_115_idx+1);
         sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
         SubsflControlProps_115137( ) ;
         SendRow1K137( ) ;
      }

      protected void SendRow1K137( )
      {
         Gridlevel_profesionalesRow = GXWebRow.GetNew(context);
         if ( subGridlevel_profesionales_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_profesionales_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_profesionales_Class, "") != 0 )
            {
               subGridlevel_profesionales_Linesclass = subGridlevel_profesionales_Class+"Odd";
            }
         }
         else if ( subGridlevel_profesionales_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_profesionales_Backstyle = 0;
            subGridlevel_profesionales_Backcolor = subGridlevel_profesionales_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_profesionales_Class, "") != 0 )
            {
               subGridlevel_profesionales_Linesclass = subGridlevel_profesionales_Class+"Uniform";
            }
         }
         else if ( subGridlevel_profesionales_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_profesionales_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_profesionales_Class, "") != 0 )
            {
               subGridlevel_profesionales_Linesclass = subGridlevel_profesionales_Class+"Odd";
            }
            subGridlevel_profesionales_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_profesionales_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_profesionales_Backstyle = 1;
            if ( ((int)((nGXsfl_115_idx) % (2))) == 0 )
            {
               subGridlevel_profesionales_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_profesionales_Class, "") != 0 )
               {
                  subGridlevel_profesionales_Linesclass = subGridlevel_profesionales_Class+"Even";
               }
            }
            else
            {
               subGridlevel_profesionales_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_profesionales_Class, "") != 0 )
               {
                  subGridlevel_profesionales_Linesclass = subGridlevel_profesionales_Class+"Odd";
               }
            }
         }
         imgprompt_120_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"profesionalesfullnameprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROFESIONALESID_"+sGXsfl_115_idx+"'), id:'"+"PROFESIONALESID_"+sGXsfl_115_idx+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vFULLNAME"+"'), id:'"+"vFULLNAME"+"'"+",IOType:'inout'}"+"],"+"gx.dom.form()."+"nIsMod_137_"+sGXsfl_115_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_137_" + sGXsfl_115_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 116,'',false,'" + sGXsfl_115_idx + "',115)\"";
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_120_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_120_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_profesionalesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_120_Internalname,(string)sImgUrl,(string)imgprompt_120_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_120_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_137_" + sGXsfl_115_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 117,'',false,'" + sGXsfl_115_idx + "',115)\"";
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesNombreCompleto_Internalname,(string)A886ProfesionalesNombreCompleto,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesNombreCompleto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesNombreCompleto_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_137_" + sGXsfl_115_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 118,'',false,'" + sGXsfl_115_idx + "',115)\"";
         if ( ( cmbPostulacionProfesionalEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "POSTULACIONPROFESIONALESTADO_" + sGXsfl_115_idx;
            cmbPostulacionProfesionalEstado.Name = GXCCtl;
            cmbPostulacionProfesionalEstado.WebTags = "";
            cmbPostulacionProfesionalEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
            cmbPostulacionProfesionalEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
            cmbPostulacionProfesionalEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
            cmbPostulacionProfesionalEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
            if ( cmbPostulacionProfesionalEstado.ItemCount > 0 )
            {
               A956PostulacionProfesionalEstado = cmbPostulacionProfesionalEstado.getValidValue(A956PostulacionProfesionalEstado);
            }
         }
         /* ComboBox */
         Gridlevel_profesionalesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPostulacionProfesionalEstado,(string)cmbPostulacionProfesionalEstado_Internalname,StringUtil.RTrim( A956PostulacionProfesionalEstado),(short)1,(string)cmbPostulacionProfesionalEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbPostulacionProfesionalEstado.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"",(string)"",(bool)true,(short)0});
         cmbPostulacionProfesionalEstado.CurrentValue = StringUtil.RTrim( A956PostulacionProfesionalEstado);
         AssignProp("", false, cmbPostulacionProfesionalEstado_Internalname, "Values", (string)(cmbPostulacionProfesionalEstado.ToJavascriptSource()), !bGXsfl_115_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalFechaA_Internalname,context.localUtil.TToC( A957PostulacionProfesionalFechaA, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A957PostulacionProfesionalFechaA, "99/99/99 99:99"),""+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalFechaA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtPostulacionProfesionalFechaA_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_137_" + sGXsfl_115_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 120,'',false,'" + sGXsfl_115_idx + "',115)\"";
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( A982PostulacionProfesionalPrecio, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtPostulacionProfesionalPrecio_Enabled!=0) ? context.localUtil.Format( A982PostulacionProfesionalPrecio, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A982PostulacionProfesionalPrecio, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,120);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPostulacionProfesionalPrecio_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_137_" + sGXsfl_115_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 121,'',false,'" + sGXsfl_115_idx + "',115)\"";
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalFechaT_Internalname,context.localUtil.Format(A958PostulacionProfesionalFechaT, "99/99/99"),context.localUtil.Format( A958PostulacionProfesionalFechaT, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,121);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalFechaT_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPostulacionProfesionalFechaT_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_137_" + sGXsfl_115_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 122,'',false,'" + sGXsfl_115_idx + "',115)\"";
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalTurnoT_Internalname,StringUtil.RTrim( A959PostulacionProfesionalTurnoT),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalTurnoT_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPostulacionProfesionalTurnoT_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_137_" + sGXsfl_115_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_115_idx + "',115)\"";
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalPlazoE_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A983PostulacionProfesionalPlazoE), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtPostulacionProfesionalPlazoE_Enabled!=0) ? context.localUtil.Format( (decimal)(A983PostulacionProfesionalPlazoE), "ZZZ9") : context.localUtil.Format( (decimal)(A983PostulacionProfesionalPlazoE), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,123);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalPlazoE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPostulacionProfesionalPlazoE_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_137_" + sGXsfl_115_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 124,'',false,'" + sGXsfl_115_idx + "',115)\"";
         if ( ( cmbPostulacionProfesionalUniE.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "POSTULACIONPROFESIONALUNIE_" + sGXsfl_115_idx;
            cmbPostulacionProfesionalUniE.Name = GXCCtl;
            cmbPostulacionProfesionalUniE.WebTags = "";
            cmbPostulacionProfesionalUniE.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
            cmbPostulacionProfesionalUniE.addItem("D", context.GetMessage( "Días", ""), 0);
            cmbPostulacionProfesionalUniE.addItem("M", context.GetMessage( "Meses", ""), 0);
            if ( cmbPostulacionProfesionalUniE.ItemCount > 0 )
            {
               A986PostulacionProfesionalUniE = cmbPostulacionProfesionalUniE.getValidValue(A986PostulacionProfesionalUniE);
               n986PostulacionProfesionalUniE = false;
            }
         }
         /* ComboBox */
         Gridlevel_profesionalesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPostulacionProfesionalUniE,(string)cmbPostulacionProfesionalUniE_Internalname,StringUtil.RTrim( A986PostulacionProfesionalUniE),(short)1,(string)cmbPostulacionProfesionalUniE_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbPostulacionProfesionalUniE.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"",(string)"",(bool)true,(short)0});
         cmbPostulacionProfesionalUniE.CurrentValue = StringUtil.RTrim( A986PostulacionProfesionalUniE);
         AssignProp("", false, cmbPostulacionProfesionalUniE_Internalname, "Values", (string)(cmbPostulacionProfesionalUniE.ToJavascriptSource()), !bGXsfl_115_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_137_" + sGXsfl_115_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 125,'',false,'" + sGXsfl_115_idx + "',115)\"";
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalGar_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A985PostulacionProfesionalGar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtPostulacionProfesionalGar_Enabled!=0) ? context.localUtil.Format( (decimal)(A985PostulacionProfesionalGar), "ZZZ9") : context.localUtil.Format( (decimal)(A985PostulacionProfesionalGar), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,125);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalGar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPostulacionProfesionalGar_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_137_" + sGXsfl_115_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 126,'',false,'" + sGXsfl_115_idx + "',115)\"";
         if ( ( cmbPostulacionProfesionalUniG.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "POSTULACIONPROFESIONALUNIG_" + sGXsfl_115_idx;
            cmbPostulacionProfesionalUniG.Name = GXCCtl;
            cmbPostulacionProfesionalUniG.WebTags = "";
            cmbPostulacionProfesionalUniG.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
            cmbPostulacionProfesionalUniG.addItem("D", context.GetMessage( "Días", ""), 0);
            cmbPostulacionProfesionalUniG.addItem("M", context.GetMessage( "Meses", ""), 0);
            if ( cmbPostulacionProfesionalUniG.ItemCount > 0 )
            {
               A987PostulacionProfesionalUniG = cmbPostulacionProfesionalUniG.getValidValue(A987PostulacionProfesionalUniG);
               n987PostulacionProfesionalUniG = false;
            }
         }
         /* ComboBox */
         Gridlevel_profesionalesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPostulacionProfesionalUniG,(string)cmbPostulacionProfesionalUniG_Internalname,StringUtil.RTrim( A987PostulacionProfesionalUniG),(short)1,(string)cmbPostulacionProfesionalUniG_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbPostulacionProfesionalUniG.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"",(string)"",(bool)true,(short)0});
         cmbPostulacionProfesionalUniG.CurrentValue = StringUtil.RTrim( A987PostulacionProfesionalUniG);
         AssignProp("", false, cmbPostulacionProfesionalUniG_Internalname, "Values", (string)(cmbPostulacionProfesionalUniG.ToJavascriptSource()), !bGXsfl_115_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_137_" + sGXsfl_115_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 127,'',false,'" + sGXsfl_115_idx + "',115)\"";
         ROClassString = "Attribute";
         Gridlevel_profesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalA_Internalname,(string)A984PostulacionProfesionalA,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPostulacionProfesionalA_Enabled,(short)0,(string)"text",(string)"",(short)90,(string)"px",(short)17,(string)"px",(short)500,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Active Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',115)\"";
         ClassString = "Attribute" + " " + ((StringUtil.StrCmp(edtavVermas_gximage, "")==0) ? "" : "GX_Image_"+edtavVermas_gximage+"_Class");
         StyleString = "";
         AV24VerMas_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV24VerMas))&&String.IsNullOrEmpty(StringUtil.RTrim( AV28Vermas_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV24VerMas)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV24VerMas)) ? AV28Vermas_GXI : context.PathToRelativeUrl( AV24VerMas));
         Gridlevel_profesionalesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavVermas_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavVermas_Visible,(int)edtavVermas_Enabled,(string)"",(string)edtavVermas_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavVermas_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVVERMAS.CLICK."+sGXsfl_115_idx+"'",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV24VerMas_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_profesionalesRow);
         send_integrity_lvl_hashes1K137( ) ;
         GXCCtl = "Z120ProfesionalesId_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z120ProfesionalesId));
         GXCCtl = "Z956PostulacionProfesionalEstado_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z956PostulacionProfesionalEstado));
         GXCCtl = "Z957PostulacionProfesionalFechaA_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z957PostulacionProfesionalFechaA, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z958PostulacionProfesionalFechaT_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.DToC( Z958PostulacionProfesionalFechaT, 0, "/"));
         GXCCtl = "Z959PostulacionProfesionalTurnoT_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z959PostulacionProfesionalTurnoT));
         GXCCtl = "Z982PostulacionProfesionalPrecio_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z982PostulacionProfesionalPrecio, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z983PostulacionProfesionalPlazoE_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z983PostulacionProfesionalPlazoE), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z986PostulacionProfesionalUniE_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z986PostulacionProfesionalUniE));
         GXCCtl = "Z985PostulacionProfesionalGar_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z985PostulacionProfesionalGar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z987PostulacionProfesionalUniG_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z987PostulacionProfesionalUniG));
         GXCCtl = "Z984PostulacionProfesionalA_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z984PostulacionProfesionalA);
         GXCCtl = "nRcdDeleted_137_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_137), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_137_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_137), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_137_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_137), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_115_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV12TrnContext);
         }
         GXCCtl = "vPOSTULACIONESID_" + sGXsfl_115_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESID_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESNOMBRECOMPLETO_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesNombreCompleto_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POSTULACIONPROFESIONALESTADO_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPostulacionProfesionalEstado.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POSTULACIONPROFESIONALFECHAA_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalFechaA_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POSTULACIONPROFESIONALPRECIO_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalPrecio_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POSTULACIONPROFESIONALFECHAT_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalFechaT_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POSTULACIONPROFESIONALTURNOT_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalTurnoT_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POSTULACIONPROFESIONALPLAZOE_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalPlazoE_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POSTULACIONPROFESIONALUNIE_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPostulacionProfesionalUniE.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POSTULACIONPROFESIONALGAR_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalGar_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POSTULACIONPROFESIONALUNIG_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPostulacionProfesionalUniG.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POSTULACIONPROFESIONALA_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalA_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vVERMAS_"+sGXsfl_115_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVermas_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vVERMAS_"+sGXsfl_115_idx+"Tooltiptext", StringUtil.RTrim( edtavVermas_Tooltiptext));
         GxWebStd.gx_hidden_field( context, "vVERMAS_"+sGXsfl_115_idx+"Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVermas_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_120_"+sGXsfl_115_idx+"Link", StringUtil.RTrim( imgprompt_120_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_profesionalesContainer.AddRow(Gridlevel_profesionalesRow);
      }

      protected void ReadRow1K137( )
      {
         nGXsfl_115_idx = (int)(nGXsfl_115_idx+1);
         sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
         SubsflControlProps_115137( ) ;
         edtProfesionalesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESID_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfesionalesNombreCompleto_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESNOMBRECOMPLETO_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbPostulacionProfesionalEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALESTADO_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPostulacionProfesionalFechaA_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALFECHAA_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPostulacionProfesionalPrecio_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALPRECIO_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPostulacionProfesionalFechaT_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALFECHAT_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPostulacionProfesionalTurnoT_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALTURNOT_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPostulacionProfesionalPlazoE_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALPLAZOE_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbPostulacionProfesionalUniE.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALUNIE_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPostulacionProfesionalGar_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALGAR_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbPostulacionProfesionalUniG.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALUNIG_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPostulacionProfesionalA_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POSTULACIONPROFESIONALA_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtavVermas_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vVERMAS_"+sGXsfl_115_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtavVermas_Tooltiptext = cgiGet( "vVERMAS_"+sGXsfl_115_idx+"Tooltiptext");
         edtavVermas_Visible = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vVERMAS_"+sGXsfl_115_idx+"Visible"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_945_Link = cgiGet( "PROMPT_120_"+sGXsfl_115_idx+"Link");
         A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
         A886ProfesionalesNombreCompleto = cgiGet( edtProfesionalesNombreCompleto_Internalname);
         cmbPostulacionProfesionalEstado.Name = cmbPostulacionProfesionalEstado_Internalname;
         cmbPostulacionProfesionalEstado.CurrentValue = cgiGet( cmbPostulacionProfesionalEstado_Internalname);
         A956PostulacionProfesionalEstado = cgiGet( cmbPostulacionProfesionalEstado_Internalname);
         A957PostulacionProfesionalFechaA = context.localUtil.CToT( cgiGet( edtPostulacionProfesionalFechaA_Internalname));
         if ( ( ( context.localUtil.CToN( cgiGet( edtPostulacionProfesionalPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPostulacionProfesionalPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
         {
            GXCCtl = "POSTULACIONPROFESIONALPRECIO_" + sGXsfl_115_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPostulacionProfesionalPrecio_Internalname;
            wbErr = true;
            A982PostulacionProfesionalPrecio = 0;
            n982PostulacionProfesionalPrecio = false;
         }
         else
         {
            A982PostulacionProfesionalPrecio = context.localUtil.CToN( cgiGet( edtPostulacionProfesionalPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n982PostulacionProfesionalPrecio = false;
         }
         n982PostulacionProfesionalPrecio = ((Convert.ToDecimal(0)==A982PostulacionProfesionalPrecio) ? true : false);
         if ( context.localUtil.VCDate( cgiGet( edtPostulacionProfesionalFechaT_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
         {
            GXCCtl = "POSTULACIONPROFESIONALFECHAT_" + sGXsfl_115_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Postulacion Profesional Fecha T", "")}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPostulacionProfesionalFechaT_Internalname;
            wbErr = true;
            A958PostulacionProfesionalFechaT = DateTime.MinValue;
         }
         else
         {
            A958PostulacionProfesionalFechaT = context.localUtil.CToD( cgiGet( edtPostulacionProfesionalFechaT_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
         }
         A959PostulacionProfesionalTurnoT = cgiGet( edtPostulacionProfesionalTurnoT_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtPostulacionProfesionalPlazoE_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPostulacionProfesionalPlazoE_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "POSTULACIONPROFESIONALPLAZOE_" + sGXsfl_115_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPostulacionProfesionalPlazoE_Internalname;
            wbErr = true;
            A983PostulacionProfesionalPlazoE = 0;
            n983PostulacionProfesionalPlazoE = false;
         }
         else
         {
            A983PostulacionProfesionalPlazoE = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionProfesionalPlazoE_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n983PostulacionProfesionalPlazoE = false;
         }
         n983PostulacionProfesionalPlazoE = ((0==A983PostulacionProfesionalPlazoE) ? true : false);
         cmbPostulacionProfesionalUniE.Name = cmbPostulacionProfesionalUniE_Internalname;
         cmbPostulacionProfesionalUniE.CurrentValue = cgiGet( cmbPostulacionProfesionalUniE_Internalname);
         A986PostulacionProfesionalUniE = cgiGet( cmbPostulacionProfesionalUniE_Internalname);
         n986PostulacionProfesionalUniE = false;
         n986PostulacionProfesionalUniE = (String.IsNullOrEmpty(StringUtil.RTrim( A986PostulacionProfesionalUniE)) ? true : false);
         if ( ( ( context.localUtil.CToN( cgiGet( edtPostulacionProfesionalGar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPostulacionProfesionalGar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "POSTULACIONPROFESIONALGAR_" + sGXsfl_115_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPostulacionProfesionalGar_Internalname;
            wbErr = true;
            A985PostulacionProfesionalGar = 0;
            n985PostulacionProfesionalGar = false;
         }
         else
         {
            A985PostulacionProfesionalGar = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionProfesionalGar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n985PostulacionProfesionalGar = false;
         }
         n985PostulacionProfesionalGar = ((0==A985PostulacionProfesionalGar) ? true : false);
         cmbPostulacionProfesionalUniG.Name = cmbPostulacionProfesionalUniG_Internalname;
         cmbPostulacionProfesionalUniG.CurrentValue = cgiGet( cmbPostulacionProfesionalUniG_Internalname);
         A987PostulacionProfesionalUniG = cgiGet( cmbPostulacionProfesionalUniG_Internalname);
         n987PostulacionProfesionalUniG = false;
         n987PostulacionProfesionalUniG = (String.IsNullOrEmpty(StringUtil.RTrim( A987PostulacionProfesionalUniG)) ? true : false);
         A984PostulacionProfesionalA = cgiGet( edtPostulacionProfesionalA_Internalname);
         n984PostulacionProfesionalA = false;
         n984PostulacionProfesionalA = (String.IsNullOrEmpty(StringUtil.RTrim( A984PostulacionProfesionalA)) ? true : false);
         AV24VerMas = cgiGet( edtavVermas_Internalname);
         GXCCtl = "Z120ProfesionalesId_" + sGXsfl_115_idx;
         Z120ProfesionalesId = cgiGet( GXCCtl);
         GXCCtl = "Z956PostulacionProfesionalEstado_" + sGXsfl_115_idx;
         Z956PostulacionProfesionalEstado = cgiGet( GXCCtl);
         GXCCtl = "Z957PostulacionProfesionalFechaA_" + sGXsfl_115_idx;
         Z957PostulacionProfesionalFechaA = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         GXCCtl = "Z958PostulacionProfesionalFechaT_" + sGXsfl_115_idx;
         Z958PostulacionProfesionalFechaT = context.localUtil.CToD( cgiGet( GXCCtl), 0);
         GXCCtl = "Z959PostulacionProfesionalTurnoT_" + sGXsfl_115_idx;
         Z959PostulacionProfesionalTurnoT = cgiGet( GXCCtl);
         GXCCtl = "Z982PostulacionProfesionalPrecio_" + sGXsfl_115_idx;
         Z982PostulacionProfesionalPrecio = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         n982PostulacionProfesionalPrecio = ((Convert.ToDecimal(0)==A982PostulacionProfesionalPrecio) ? true : false);
         GXCCtl = "Z983PostulacionProfesionalPlazoE_" + sGXsfl_115_idx;
         Z983PostulacionProfesionalPlazoE = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n983PostulacionProfesionalPlazoE = ((0==A983PostulacionProfesionalPlazoE) ? true : false);
         GXCCtl = "Z986PostulacionProfesionalUniE_" + sGXsfl_115_idx;
         Z986PostulacionProfesionalUniE = cgiGet( GXCCtl);
         n986PostulacionProfesionalUniE = (String.IsNullOrEmpty(StringUtil.RTrim( A986PostulacionProfesionalUniE)) ? true : false);
         GXCCtl = "Z985PostulacionProfesionalGar_" + sGXsfl_115_idx;
         Z985PostulacionProfesionalGar = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n985PostulacionProfesionalGar = ((0==A985PostulacionProfesionalGar) ? true : false);
         GXCCtl = "Z987PostulacionProfesionalUniG_" + sGXsfl_115_idx;
         Z987PostulacionProfesionalUniG = cgiGet( GXCCtl);
         n987PostulacionProfesionalUniG = (String.IsNullOrEmpty(StringUtil.RTrim( A987PostulacionProfesionalUniG)) ? true : false);
         GXCCtl = "Z984PostulacionProfesionalA_" + sGXsfl_115_idx;
         Z984PostulacionProfesionalA = cgiGet( GXCCtl);
         n984PostulacionProfesionalA = (String.IsNullOrEmpty(StringUtil.RTrim( A984PostulacionProfesionalA)) ? true : false);
         GXCCtl = "nRcdDeleted_137_" + sGXsfl_115_idx;
         nRcdDeleted_137 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_137_" + sGXsfl_115_idx;
         nRcdExists_137 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_137_" + sGXsfl_115_idx;
         nIsMod_137 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtPostulacionProfesionalFechaA_Enabled = edtPostulacionProfesionalFechaA_Enabled;
         defedtProfesionalesId_Enabled = edtProfesionalesId_Enabled;
         defedtMultimediaId_Enabled = edtMultimediaId_Enabled;
         defedtCategoriasId_Enabled = edtCategoriasId_Enabled;
      }

      protected void ConfirmValues1K0( )
      {
         nGXsfl_93_idx = 0;
         sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx), 4, 0), 4, "0");
         SubsflControlProps_93142( ) ;
         while ( nGXsfl_93_idx < nRC_GXsfl_93 )
         {
            nGXsfl_93_idx = (int)(nGXsfl_93_idx+1);
            sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx), 4, 0), 4, "0");
            SubsflControlProps_93142( ) ;
            ChangePostValue( "Z931CategoriasId_"+sGXsfl_93_idx, cgiGet( "ZT_"+"Z931CategoriasId_"+sGXsfl_93_idx)) ;
            DeletePostValue( "ZT_"+"Z931CategoriasId_"+sGXsfl_93_idx) ;
         }
         nGXsfl_103_idx = 0;
         sGXsfl_103_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_103_idx), 4, 0), 4, "0");
         SubsflControlProps_103139( ) ;
         while ( nGXsfl_103_idx < nRC_GXsfl_103 )
         {
            nGXsfl_103_idx = (int)(nGXsfl_103_idx+1);
            sGXsfl_103_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_103_idx), 4, 0), 4, "0");
            SubsflControlProps_103139( ) ;
            ChangePostValue( "Z932MultimediaId_"+sGXsfl_103_idx, cgiGet( "ZT_"+"Z932MultimediaId_"+sGXsfl_103_idx)) ;
            DeletePostValue( "ZT_"+"Z932MultimediaId_"+sGXsfl_103_idx) ;
            ChangePostValue( "Z933MultimediaDireccion_"+sGXsfl_103_idx, cgiGet( "ZT_"+"Z933MultimediaDireccion_"+sGXsfl_103_idx)) ;
            DeletePostValue( "ZT_"+"Z933MultimediaDireccion_"+sGXsfl_103_idx) ;
            ChangePostValue( "Z960MultimediaDescripcion_"+sGXsfl_103_idx, cgiGet( "ZT_"+"Z960MultimediaDescripcion_"+sGXsfl_103_idx)) ;
            DeletePostValue( "ZT_"+"Z960MultimediaDescripcion_"+sGXsfl_103_idx) ;
            ChangePostValue( "Z934MultimediaTipo_"+sGXsfl_103_idx, cgiGet( "ZT_"+"Z934MultimediaTipo_"+sGXsfl_103_idx)) ;
            DeletePostValue( "ZT_"+"Z934MultimediaTipo_"+sGXsfl_103_idx) ;
         }
         nGXsfl_115_idx = 0;
         sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
         SubsflControlProps_115137( ) ;
         while ( nGXsfl_115_idx < nRC_GXsfl_115 )
         {
            nGXsfl_115_idx = (int)(nGXsfl_115_idx+1);
            sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
            SubsflControlProps_115137( ) ;
            ChangePostValue( "Z120ProfesionalesId_"+sGXsfl_115_idx, cgiGet( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_115_idx)) ;
            DeletePostValue( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_115_idx) ;
            ChangePostValue( "Z956PostulacionProfesionalEstado_"+sGXsfl_115_idx, cgiGet( "ZT_"+"Z956PostulacionProfesionalEstado_"+sGXsfl_115_idx)) ;
            DeletePostValue( "ZT_"+"Z956PostulacionProfesionalEstado_"+sGXsfl_115_idx) ;
            ChangePostValue( "Z957PostulacionProfesionalFechaA_"+sGXsfl_115_idx, cgiGet( "ZT_"+"Z957PostulacionProfesionalFechaA_"+sGXsfl_115_idx)) ;
            DeletePostValue( "ZT_"+"Z957PostulacionProfesionalFechaA_"+sGXsfl_115_idx) ;
            ChangePostValue( "Z958PostulacionProfesionalFechaT_"+sGXsfl_115_idx, cgiGet( "ZT_"+"Z958PostulacionProfesionalFechaT_"+sGXsfl_115_idx)) ;
            DeletePostValue( "ZT_"+"Z958PostulacionProfesionalFechaT_"+sGXsfl_115_idx) ;
            ChangePostValue( "Z959PostulacionProfesionalTurnoT_"+sGXsfl_115_idx, cgiGet( "ZT_"+"Z959PostulacionProfesionalTurnoT_"+sGXsfl_115_idx)) ;
            DeletePostValue( "ZT_"+"Z959PostulacionProfesionalTurnoT_"+sGXsfl_115_idx) ;
            ChangePostValue( "Z982PostulacionProfesionalPrecio_"+sGXsfl_115_idx, cgiGet( "ZT_"+"Z982PostulacionProfesionalPrecio_"+sGXsfl_115_idx)) ;
            DeletePostValue( "ZT_"+"Z982PostulacionProfesionalPrecio_"+sGXsfl_115_idx) ;
            ChangePostValue( "Z983PostulacionProfesionalPlazoE_"+sGXsfl_115_idx, cgiGet( "ZT_"+"Z983PostulacionProfesionalPlazoE_"+sGXsfl_115_idx)) ;
            DeletePostValue( "ZT_"+"Z983PostulacionProfesionalPlazoE_"+sGXsfl_115_idx) ;
            ChangePostValue( "Z986PostulacionProfesionalUniE_"+sGXsfl_115_idx, cgiGet( "ZT_"+"Z986PostulacionProfesionalUniE_"+sGXsfl_115_idx)) ;
            DeletePostValue( "ZT_"+"Z986PostulacionProfesionalUniE_"+sGXsfl_115_idx) ;
            ChangePostValue( "Z985PostulacionProfesionalGar_"+sGXsfl_115_idx, cgiGet( "ZT_"+"Z985PostulacionProfesionalGar_"+sGXsfl_115_idx)) ;
            DeletePostValue( "ZT_"+"Z985PostulacionProfesionalGar_"+sGXsfl_115_idx) ;
            ChangePostValue( "Z987PostulacionProfesionalUniG_"+sGXsfl_115_idx, cgiGet( "ZT_"+"Z987PostulacionProfesionalUniG_"+sGXsfl_115_idx)) ;
            DeletePostValue( "ZT_"+"Z987PostulacionProfesionalUniG_"+sGXsfl_115_idx) ;
            ChangePostValue( "Z984PostulacionProfesionalA_"+sGXsfl_115_idx, cgiGet( "ZT_"+"Z984PostulacionProfesionalA_"+sGXsfl_115_idx)) ;
            DeletePostValue( "ZT_"+"Z984PostulacionProfesionalA_"+sGXsfl_115_idx) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
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
         GXEncryptionTmp = "postulaciones.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PostulacionesId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("postulaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Postulaciones");
         forbiddenHiddens.Add("PostulacionesId", context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ServiciosId", context.localUtil.Format( (decimal)(AV14Insert_ServiciosId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_PostulacionesProveedorId", context.localUtil.Format( (decimal)(AV17Insert_PostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("PostulacionesProvNombreAux", StringUtil.RTrim( context.localUtil.Format( A971PostulacionesProvNombreAux, "")));
         forbiddenHiddens.Add("PostulacionesDepartamentoId", context.localUtil.Format( (decimal)(A979PostulacionesDepartamentoId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("PostulacionesDepartamentoMunic", context.localUtil.Format( (decimal)(A980PostulacionesDepartamentoMunic), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("PostulacionesZonasID", context.localUtil.Format( (decimal)(A981PostulacionesZonasID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("PostulacionesDireccion", StringUtil.RTrim( context.localUtil.Format( A998PostulacionesDireccion, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("postulaciones:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z422PostulacionesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z422PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z971PostulacionesProvNombreAux", StringUtil.RTrim( Z971PostulacionesProvNombreAux));
         GxWebStd.gx_hidden_field( context, "Z946PostulacionesPrecio", StringUtil.LTrim( StringUtil.NToC( Z946PostulacionesPrecio, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z961PostulacionesMultimediaSerial", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z961PostulacionesMultimediaSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z936PostulacionesDescripcion", StringUtil.RTrim( Z936PostulacionesDescripcion));
         GxWebStd.gx_boolean_hidden_field( context, "Z937PostulacionesReqSuministros", Z937PostulacionesReqSuministros);
         GxWebStd.gx_hidden_field( context, "Z938PostulacionesSuministrosDescri", StringUtil.RTrim( Z938PostulacionesSuministrosDescri));
         GxWebStd.gx_hidden_field( context, "Z947PostulacionesFechaTrabajo", context.localUtil.DToC( Z947PostulacionesFechaTrabajo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z939PostulacionesFechaCierre", context.localUtil.DToC( Z939PostulacionesFechaCierre, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z940PostulacionesHoraCierre", Z940PostulacionesHoraCierre);
         GxWebStd.gx_hidden_field( context, "Z941PostulacionesTipoFecha", Z941PostulacionesTipoFecha);
         GxWebStd.gx_hidden_field( context, "Z949PostulacionesRgoHoraservicio", StringUtil.RTrim( Z949PostulacionesRgoHoraservicio));
         GxWebStd.gx_hidden_field( context, "Z950PostulacionesApellidoNombre", StringUtil.RTrim( Z950PostulacionesApellidoNombre));
         GxWebStd.gx_hidden_field( context, "Z951PostulacionesMail", Z951PostulacionesMail);
         GxWebStd.gx_hidden_field( context, "Z952PostulacionesTelefono", StringUtil.RTrim( Z952PostulacionesTelefono));
         GxWebStd.gx_hidden_field( context, "Z979PostulacionesDepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z979PostulacionesDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z980PostulacionesDepartamentoMunic", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z980PostulacionesDepartamentoMunic), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z981PostulacionesZonasID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z981PostulacionesZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z998PostulacionesDireccion", StringUtil.RTrim( Z998PostulacionesDireccion));
         GxWebStd.gx_hidden_field( context, "Z425PostulacionesFechaAlta", context.localUtil.TToC( Z425PostulacionesFechaAlta, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z424PostulacionesEstado", StringUtil.RTrim( Z424PostulacionesEstado));
         GxWebStd.gx_hidden_field( context, "Z948PostulacionesSecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z948PostulacionesSecUserId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z942ServiciosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z942ServiciosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z945PostulacionesProveedorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z945PostulacionesProveedorId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O961PostulacionesMultimediaSerial", StringUtil.LTrim( StringUtil.NToC( (decimal)(O961PostulacionesMultimediaSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_93", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_93_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_103", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_103_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_115", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_115_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N942ServiciosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A942ServiciosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N945PostulacionesProveedorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A945PostulacionesProveedorId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV12TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV12TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPOSTULACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPOSTULACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PostulacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SERVICIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_ServiciosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_POSTULACIONESPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17Insert_PostulacionesProveedorId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "POSTULACIONESPROVNOMBREAUX", StringUtil.RTrim( A971PostulacionesProvNombreAux));
         GxWebStd.gx_hidden_field( context, "POSTULACIONESDEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A979PostulacionesDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "POSTULACIONESDEPARTAMENTOMUNIC", StringUtil.LTrim( StringUtil.NToC( (decimal)(A980PostulacionesDepartamentoMunic), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "POSTULACIONESZONASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A981PostulacionesZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "POSTULACIONESDIRECCION", StringUtil.RTrim( A998PostulacionesDireccion));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV26Pgmname));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAPELLIDOPRIMERO", StringUtil.RTrim( A167ProfesionalesApellidoPrimero));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESPRIMERNOMBRE", StringUtil.RTrim( A166ProfesionalesPrimerNombre));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESSEGUNDONOMBRE", StringUtil.RTrim( A191ProfesionalesSegundoNombre));
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
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Objectcall", StringUtil.RTrim( Dvpanel_tableleaflevel_categorias_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Enabled", StringUtil.BoolToStr( Dvpanel_tableleaflevel_categorias_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Width", StringUtil.RTrim( Dvpanel_tableleaflevel_categorias_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Autowidth", StringUtil.BoolToStr( Dvpanel_tableleaflevel_categorias_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Autoheight", StringUtil.BoolToStr( Dvpanel_tableleaflevel_categorias_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Cls", StringUtil.RTrim( Dvpanel_tableleaflevel_categorias_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Title", StringUtil.RTrim( Dvpanel_tableleaflevel_categorias_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Collapsible", StringUtil.BoolToStr( Dvpanel_tableleaflevel_categorias_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Collapsed", StringUtil.BoolToStr( Dvpanel_tableleaflevel_categorias_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableleaflevel_categorias_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Iconposition", StringUtil.RTrim( Dvpanel_tableleaflevel_categorias_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_CATEGORIAS_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableleaflevel_categorias_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Objectcall", StringUtil.RTrim( Dvpanel_tableleaflevel_multimedia_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Enabled", StringUtil.BoolToStr( Dvpanel_tableleaflevel_multimedia_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Width", StringUtil.RTrim( Dvpanel_tableleaflevel_multimedia_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Autowidth", StringUtil.BoolToStr( Dvpanel_tableleaflevel_multimedia_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Autoheight", StringUtil.BoolToStr( Dvpanel_tableleaflevel_multimedia_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Cls", StringUtil.RTrim( Dvpanel_tableleaflevel_multimedia_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Title", StringUtil.RTrim( Dvpanel_tableleaflevel_multimedia_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Collapsible", StringUtil.BoolToStr( Dvpanel_tableleaflevel_multimedia_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Collapsed", StringUtil.BoolToStr( Dvpanel_tableleaflevel_multimedia_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableleaflevel_multimedia_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Iconposition", StringUtil.RTrim( Dvpanel_tableleaflevel_multimedia_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableleaflevel_multimedia_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Objectcall", StringUtil.RTrim( Dvpanel_tableleaflevel_profesionales_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Enabled", StringUtil.BoolToStr( Dvpanel_tableleaflevel_profesionales_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Width", StringUtil.RTrim( Dvpanel_tableleaflevel_profesionales_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableleaflevel_profesionales_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableleaflevel_profesionales_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Cls", StringUtil.RTrim( Dvpanel_tableleaflevel_profesionales_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Title", StringUtil.RTrim( Dvpanel_tableleaflevel_profesionales_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableleaflevel_profesionales_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableleaflevel_profesionales_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableleaflevel_profesionales_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Iconposition", StringUtil.RTrim( Dvpanel_tableleaflevel_profesionales_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELEAFLEVEL_PROFESIONALES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableleaflevel_profesionales_Autoscroll));
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
         GXEncryptionTmp = "postulaciones.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PostulacionesId,18,0));
         return formatLink("postulaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Postulaciones" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Postulaciones", "") ;
      }

      protected void InitializeNonKey1K126( )
      {
         A942ServiciosId = 0;
         n942ServiciosId = false;
         AssignAttri("", false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
         n942ServiciosId = ((0==A942ServiciosId) ? true : false);
         A945PostulacionesProveedorId = 0;
         AssignAttri("", false, "A945PostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(A945PostulacionesProveedorId), 18, 0));
         A943ServiciosNombre = "";
         AssignAttri("", false, "A943ServiciosNombre", A943ServiciosNombre);
         A971PostulacionesProvNombreAux = "";
         AssignAttri("", false, "A971PostulacionesProvNombreAux", A971PostulacionesProvNombreAux);
         A969PostulacionesProveedorNombre = "";
         AssignAttri("", false, "A969PostulacionesProveedorNombre", A969PostulacionesProveedorNombre);
         A946PostulacionesPrecio = 0;
         AssignAttri("", false, "A946PostulacionesPrecio", StringUtil.LTrimStr( A946PostulacionesPrecio, 18, 2));
         A961PostulacionesMultimediaSerial = 0;
         AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
         A936PostulacionesDescripcion = "";
         AssignAttri("", false, "A936PostulacionesDescripcion", A936PostulacionesDescripcion);
         A937PostulacionesReqSuministros = false;
         AssignAttri("", false, "A937PostulacionesReqSuministros", A937PostulacionesReqSuministros);
         A938PostulacionesSuministrosDescri = "";
         AssignAttri("", false, "A938PostulacionesSuministrosDescri", A938PostulacionesSuministrosDescri);
         A947PostulacionesFechaTrabajo = DateTime.MinValue;
         AssignAttri("", false, "A947PostulacionesFechaTrabajo", context.localUtil.Format(A947PostulacionesFechaTrabajo, "99/99/99"));
         A939PostulacionesFechaCierre = DateTime.MinValue;
         AssignAttri("", false, "A939PostulacionesFechaCierre", context.localUtil.Format(A939PostulacionesFechaCierre, "99/99/99"));
         A940PostulacionesHoraCierre = "";
         AssignAttri("", false, "A940PostulacionesHoraCierre", A940PostulacionesHoraCierre);
         A941PostulacionesTipoFecha = "";
         AssignAttri("", false, "A941PostulacionesTipoFecha", A941PostulacionesTipoFecha);
         A949PostulacionesRgoHoraservicio = "";
         AssignAttri("", false, "A949PostulacionesRgoHoraservicio", A949PostulacionesRgoHoraservicio);
         A950PostulacionesApellidoNombre = "";
         AssignAttri("", false, "A950PostulacionesApellidoNombre", A950PostulacionesApellidoNombre);
         A951PostulacionesMail = "";
         AssignAttri("", false, "A951PostulacionesMail", A951PostulacionesMail);
         A952PostulacionesTelefono = "";
         AssignAttri("", false, "A952PostulacionesTelefono", A952PostulacionesTelefono);
         A979PostulacionesDepartamentoId = 0;
         AssignAttri("", false, "A979PostulacionesDepartamentoId", StringUtil.LTrimStr( (decimal)(A979PostulacionesDepartamentoId), 18, 0));
         A980PostulacionesDepartamentoMunic = 0;
         AssignAttri("", false, "A980PostulacionesDepartamentoMunic", StringUtil.LTrimStr( (decimal)(A980PostulacionesDepartamentoMunic), 18, 0));
         A981PostulacionesZonasID = 0;
         AssignAttri("", false, "A981PostulacionesZonasID", StringUtil.LTrimStr( (decimal)(A981PostulacionesZonasID), 18, 0));
         A998PostulacionesDireccion = "";
         AssignAttri("", false, "A998PostulacionesDireccion", A998PostulacionesDireccion);
         A425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A425PostulacionesFechaAlta", context.localUtil.TToC( A425PostulacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A424PostulacionesEstado = "";
         AssignAttri("", false, "A424PostulacionesEstado", A424PostulacionesEstado);
         A948PostulacionesSecUserId = 0;
         AssignAttri("", false, "A948PostulacionesSecUserId", StringUtil.LTrimStr( (decimal)(A948PostulacionesSecUserId), 18, 0));
         O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
         AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
         Z971PostulacionesProvNombreAux = "";
         Z946PostulacionesPrecio = 0;
         Z961PostulacionesMultimediaSerial = 0;
         Z936PostulacionesDescripcion = "";
         Z937PostulacionesReqSuministros = false;
         Z938PostulacionesSuministrosDescri = "";
         Z947PostulacionesFechaTrabajo = DateTime.MinValue;
         Z939PostulacionesFechaCierre = DateTime.MinValue;
         Z940PostulacionesHoraCierre = "";
         Z941PostulacionesTipoFecha = "";
         Z949PostulacionesRgoHoraservicio = "";
         Z950PostulacionesApellidoNombre = "";
         Z951PostulacionesMail = "";
         Z952PostulacionesTelefono = "";
         Z979PostulacionesDepartamentoId = 0;
         Z980PostulacionesDepartamentoMunic = 0;
         Z981PostulacionesZonasID = 0;
         Z998PostulacionesDireccion = "";
         Z425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         Z424PostulacionesEstado = "";
         Z948PostulacionesSecUserId = 0;
         Z942ServiciosId = 0;
         Z945PostulacionesProveedorId = 0;
      }

      protected void InitAll1K126( )
      {
         A422PostulacionesId = 0;
         n422PostulacionesId = false;
         AssignAttri("", false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
         InitializeNonKey1K126( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1K142( )
      {
         A944CategoriasNombre = "";
      }

      protected void InitAll1K142( )
      {
         A931CategoriasId = 0;
         InitializeNonKey1K142( ) ;
      }

      protected void StandaloneModalInsert1K142( )
      {
      }

      protected void InitializeNonKey1K139( )
      {
         A933MultimediaDireccion = "";
         A960MultimediaDescripcion = "";
         A934MultimediaTipo = "";
         Z933MultimediaDireccion = "";
         Z960MultimediaDescripcion = "";
         Z934MultimediaTipo = "";
      }

      protected void InitAll1K139( )
      {
         A932MultimediaId = 0;
         InitializeNonKey1K139( ) ;
      }

      protected void StandaloneModalInsert1K139( )
      {
         A961PostulacionesMultimediaSerial = i961PostulacionesMultimediaSerial;
         AssignAttri("", false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
      }

      protected void InitializeNonKey1K137( )
      {
         A886ProfesionalesNombreCompleto = "";
         A956PostulacionProfesionalEstado = "";
         A957PostulacionProfesionalFechaA = (DateTime)(DateTime.MinValue);
         A958PostulacionProfesionalFechaT = DateTime.MinValue;
         A959PostulacionProfesionalTurnoT = "";
         A982PostulacionProfesionalPrecio = 0;
         n982PostulacionProfesionalPrecio = false;
         A983PostulacionProfesionalPlazoE = 0;
         n983PostulacionProfesionalPlazoE = false;
         A986PostulacionProfesionalUniE = "";
         n986PostulacionProfesionalUniE = false;
         A985PostulacionProfesionalGar = 0;
         n985PostulacionProfesionalGar = false;
         A987PostulacionProfesionalUniG = "";
         n987PostulacionProfesionalUniG = false;
         A984PostulacionProfesionalA = "";
         n984PostulacionProfesionalA = false;
         A167ProfesionalesApellidoPrimero = "";
         AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
         A166ProfesionalesPrimerNombre = "";
         AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
         A191ProfesionalesSegundoNombre = "";
         AssignAttri("", false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
         Z956PostulacionProfesionalEstado = "";
         Z957PostulacionProfesionalFechaA = (DateTime)(DateTime.MinValue);
         Z958PostulacionProfesionalFechaT = DateTime.MinValue;
         Z959PostulacionProfesionalTurnoT = "";
         Z982PostulacionProfesionalPrecio = 0;
         Z983PostulacionProfesionalPlazoE = 0;
         Z986PostulacionProfesionalUniE = "";
         Z985PostulacionProfesionalGar = 0;
         Z987PostulacionProfesionalUniG = "";
         Z984PostulacionProfesionalA = "";
      }

      protected void InitAll1K137( )
      {
         A120ProfesionalesId = "";
         InitializeNonKey1K137( ) ;
      }

      protected void StandaloneModalInsert1K137( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932045857", true, true, false);
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
         context.AddJavascriptSource("postulaciones.js", "?2026932045857", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties142( )
      {
         edtCategoriasId_Enabled = defedtCategoriasId_Enabled;
         AssignProp("", false, edtCategoriasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriasId_Enabled), 5, 0), !bGXsfl_93_Refreshing);
      }

      protected void init_level_properties139( )
      {
         edtMultimediaId_Enabled = defedtMultimediaId_Enabled;
         AssignProp("", false, edtMultimediaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMultimediaId_Enabled), 5, 0), !bGXsfl_103_Refreshing);
      }

      protected void init_level_properties137( )
      {
         edtPostulacionProfesionalFechaA_Enabled = defedtPostulacionProfesionalFechaA_Enabled;
         AssignProp("", false, edtPostulacionProfesionalFechaA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionProfesionalFechaA_Enabled), 5, 0), !bGXsfl_115_Refreshing);
         edtProfesionalesId_Enabled = defedtProfesionalesId_Enabled;
         AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_115_Refreshing);
      }

      protected void StartGridControl93( )
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
         Gridlevel_categoriasContainer.AddColumnProperties(Gridlevel_categoriasColumn);
         Gridlevel_categoriasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_categoriasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A944CategoriasNombre)));
         Gridlevel_categoriasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriasNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_categoriasContainer.AddColumnProperties(Gridlevel_categoriasColumn);
         Gridlevel_categoriasContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_categorias_Selectedindex), 4, 0, ".", "")));
         Gridlevel_categoriasContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_categorias_Allowselection), 1, 0, ".", "")));
         Gridlevel_categoriasContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_categorias_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_categoriasContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_categorias_Allowhovering), 1, 0, ".", "")));
         Gridlevel_categoriasContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_categorias_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_categoriasContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_categorias_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_categoriasContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_categorias_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl103( )
      {
         Gridlevel_multimediaContainer.AddObjectProperty("GridName", "Gridlevel_multimedia");
         Gridlevel_multimediaContainer.AddObjectProperty("Header", subGridlevel_multimedia_Header);
         Gridlevel_multimediaContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_multimediaContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_multimediaContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_multimediaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_multimediaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A932MultimediaId), 18, 0, ".", ""))));
         Gridlevel_multimediaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaId_Enabled), 5, 0, ".", "")));
         Gridlevel_multimediaContainer.AddColumnProperties(Gridlevel_multimediaColumn);
         Gridlevel_multimediaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_multimediaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A933MultimediaDireccion)));
         Gridlevel_multimediaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaDireccion_Enabled), 5, 0, ".", "")));
         Gridlevel_multimediaContainer.AddColumnProperties(Gridlevel_multimediaColumn);
         Gridlevel_multimediaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_multimediaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A960MultimediaDescripcion)));
         Gridlevel_multimediaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaDescripcion_Enabled), 5, 0, ".", "")));
         Gridlevel_multimediaContainer.AddColumnProperties(Gridlevel_multimediaColumn);
         Gridlevel_multimediaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_multimediaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A934MultimediaTipo));
         Gridlevel_multimediaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMultimediaTipo_Enabled), 5, 0, ".", "")));
         Gridlevel_multimediaContainer.AddColumnProperties(Gridlevel_multimediaColumn);
         Gridlevel_multimediaContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Selectedindex), 4, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Allowselection), 1, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Allowhovering), 1, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl115( )
      {
         Gridlevel_profesionalesContainer.AddObjectProperty("GridName", "Gridlevel_profesionales");
         Gridlevel_profesionalesContainer.AddObjectProperty("Header", subGridlevel_profesionales_Header);
         Gridlevel_profesionalesContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_profesionalesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_profesionalesContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A886ProfesionalesNombreCompleto));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesNombreCompleto_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A956PostulacionProfesionalEstado)));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPostulacionProfesionalEstado.Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A957PostulacionProfesionalFechaA, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalFechaA_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A982PostulacionProfesionalPrecio, 21, 2, ".", ""))));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalPrecio_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A958PostulacionProfesionalFechaT, "99/99/99")));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalFechaT_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A959PostulacionProfesionalTurnoT)));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalTurnoT_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A983PostulacionProfesionalPlazoE), 4, 0, ".", ""))));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalPlazoE_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A986PostulacionProfesionalUniE)));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPostulacionProfesionalUniE.Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A985PostulacionProfesionalGar), 4, 0, ".", ""))));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalGar_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A987PostulacionProfesionalUniG)));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPostulacionProfesionalUniG.Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A984PostulacionProfesionalA));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionProfesionalA_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_profesionalesColumn.AddObjectProperty("Value", context.convertURL( AV24VerMas));
         Gridlevel_profesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVermas_Enabled), 5, 0, ".", "")));
         Gridlevel_profesionalesColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavVermas_Tooltiptext));
         Gridlevel_profesionalesColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVermas_Visible), 5, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddColumnProperties(Gridlevel_profesionalesColumn);
         Gridlevel_profesionalesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Selectedindex), 4, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Allowselection), 1, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Allowhovering), 1, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_profesionalesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_profesionales_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtPostulacionesApellidoNombre_Internalname = "POSTULACIONESAPELLIDONOMBRE";
         edtPostulacionesMail_Internalname = "POSTULACIONESMAIL";
         edtPostulacionesTelefono_Internalname = "POSTULACIONESTELEFONO";
         edtPostulacionesProveedorId_Internalname = "POSTULACIONESPROVEEDORID";
         edtPostulacionesProveedorNombre_Internalname = "POSTULACIONESPROVEEDORNOMBRE";
         edtPostulacionesPrecio_Internalname = "POSTULACIONESPRECIO";
         edtPostulacionesDescripcion_Internalname = "POSTULACIONESDESCRIPCION";
         chkPostulacionesReqSuministros_Internalname = "POSTULACIONESREQSUMINISTROS";
         edtPostulacionesSuministrosDescri_Internalname = "POSTULACIONESSUMINISTROSDESCRI";
         edtPostulacionesFechaCierre_Internalname = "POSTULACIONESFECHACIERRE";
         edtPostulacionesHoraCierre_Internalname = "POSTULACIONESHORACIERRE";
         edtPostulacionesFechaTrabajo_Internalname = "POSTULACIONESFECHATRABAJO";
         cmbPostulacionesRgoHoraservicio_Internalname = "POSTULACIONESRGOHORASERVICIO";
         edtServiciosNombre_Internalname = "SERVICIOSNOMBRE";
         edtPostulacionesSolicitudesId_Internalname = "POSTULACIONESSOLICITUDESID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtCategoriasId_Internalname = "CATEGORIASID";
         edtCategoriasNombre_Internalname = "CATEGORIASNOMBRE";
         divTableleaflevel_categorias_Internalname = "TABLELEAFLEVEL_CATEGORIAS";
         Dvpanel_tableleaflevel_categorias_Internalname = "DVPANEL_TABLELEAFLEVEL_CATEGORIAS";
         edtMultimediaId_Internalname = "MULTIMEDIAID";
         edtMultimediaDireccion_Internalname = "MULTIMEDIADIRECCION";
         edtMultimediaDescripcion_Internalname = "MULTIMEDIADESCRIPCION";
         edtMultimediaTipo_Internalname = "MULTIMEDIATIPO";
         divTableleaflevel_multimedia_Internalname = "TABLELEAFLEVEL_MULTIMEDIA";
         Dvpanel_tableleaflevel_multimedia_Internalname = "DVPANEL_TABLELEAFLEVEL_MULTIMEDIA";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         edtProfesionalesNombreCompleto_Internalname = "PROFESIONALESNOMBRECOMPLETO";
         cmbPostulacionProfesionalEstado_Internalname = "POSTULACIONPROFESIONALESTADO";
         edtPostulacionProfesionalFechaA_Internalname = "POSTULACIONPROFESIONALFECHAA";
         edtPostulacionProfesionalPrecio_Internalname = "POSTULACIONPROFESIONALPRECIO";
         edtPostulacionProfesionalFechaT_Internalname = "POSTULACIONPROFESIONALFECHAT";
         edtPostulacionProfesionalTurnoT_Internalname = "POSTULACIONPROFESIONALTURNOT";
         edtPostulacionProfesionalPlazoE_Internalname = "POSTULACIONPROFESIONALPLAZOE";
         cmbPostulacionProfesionalUniE_Internalname = "POSTULACIONPROFESIONALUNIE";
         edtPostulacionProfesionalGar_Internalname = "POSTULACIONPROFESIONALGAR";
         cmbPostulacionProfesionalUniG_Internalname = "POSTULACIONPROFESIONALUNIG";
         edtPostulacionProfesionalA_Internalname = "POSTULACIONPROFESIONALA";
         edtavVermas_Internalname = "vVERMAS";
         divTableleaflevel_profesionales_Internalname = "TABLELEAFLEVEL_PROFESIONALES";
         Dvpanel_tableleaflevel_profesionales_Internalname = "DVPANEL_TABLELEAFLEVEL_PROFESIONALES";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtPostulacionesId_Internalname = "POSTULACIONESID";
         edtServiciosId_Internalname = "SERVICIOSID";
         edtPostulacionesTipoFecha_Internalname = "POSTULACIONESTIPOFECHA";
         edtPostulacionesEstado_Internalname = "POSTULACIONESESTADO";
         edtPostulacionesFechaAlta_Internalname = "POSTULACIONESFECHAALTA";
         edtPostulacionesSecUserId_Internalname = "POSTULACIONESSECUSERID";
         edtPostulacionesMultimediaSerial_Internalname = "POSTULACIONESMULTIMEDIASERIAL";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_945_Internalname = "PROMPT_945";
         imgprompt_931_Internalname = "PROMPT_931";
         imgprompt_120_Internalname = "PROMPT_120";
         imgprompt_942_Internalname = "PROMPT_942";
         subGridlevel_categorias_Internalname = "GRIDLEVEL_CATEGORIAS";
         subGridlevel_multimedia_Internalname = "GRIDLEVEL_MULTIMEDIA";
         subGridlevel_profesionales_Internalname = "GRIDLEVEL_PROFESIONALES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_profesionales_Allowcollapsing = 0;
         subGridlevel_profesionales_Allowselection = 0;
         subGridlevel_profesionales_Header = "";
         subGridlevel_multimedia_Allowcollapsing = 0;
         subGridlevel_multimedia_Allowselection = 0;
         subGridlevel_multimedia_Header = "";
         subGridlevel_categorias_Allowcollapsing = 0;
         subGridlevel_categorias_Allowselection = 0;
         subGridlevel_categorias_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Postulaciones", "");
         edtavVermas_Jsonclick = "";
         edtPostulacionProfesionalA_Jsonclick = "";
         cmbPostulacionProfesionalUniG_Jsonclick = "";
         edtPostulacionProfesionalGar_Jsonclick = "";
         cmbPostulacionProfesionalUniE_Jsonclick = "";
         edtPostulacionProfesionalPlazoE_Jsonclick = "";
         edtPostulacionProfesionalTurnoT_Jsonclick = "";
         edtPostulacionProfesionalFechaT_Jsonclick = "";
         edtPostulacionProfesionalPrecio_Jsonclick = "";
         edtPostulacionProfesionalFechaA_Jsonclick = "";
         cmbPostulacionProfesionalEstado_Jsonclick = "";
         edtProfesionalesNombreCompleto_Jsonclick = "";
         imgprompt_120_Visible = 1;
         imgprompt_120_Link = "";
         edtProfesionalesId_Jsonclick = "";
         subGridlevel_profesionales_Class = "WorkWith";
         subGridlevel_profesionales_Backcolorstyle = 0;
         edtMultimediaTipo_Jsonclick = "";
         edtMultimediaDescripcion_Jsonclick = "";
         edtMultimediaDireccion_Jsonclick = "";
         edtMultimediaId_Jsonclick = "";
         subGridlevel_multimedia_Class = "WorkWith";
         subGridlevel_multimedia_Backcolorstyle = 0;
         edtCategoriasNombre_Jsonclick = "";
         imgprompt_931_Visible = 1;
         imgprompt_931_Link = "";
         imgprompt_945_Visible = 1;
         edtCategoriasId_Jsonclick = "";
         subGridlevel_categorias_Class = "WorkWith";
         subGridlevel_categorias_Backcolorstyle = 0;
         edtavVermas_gximage = "";
         edtavVermas_Visible = -1;
         edtavVermas_Enabled = 1;
         edtPostulacionProfesionalA_Enabled = 1;
         cmbPostulacionProfesionalUniG.Enabled = 1;
         edtPostulacionProfesionalGar_Enabled = 1;
         cmbPostulacionProfesionalUniE.Enabled = 1;
         edtPostulacionProfesionalPlazoE_Enabled = 1;
         edtPostulacionProfesionalTurnoT_Enabled = 1;
         edtPostulacionProfesionalFechaT_Enabled = 1;
         edtPostulacionProfesionalPrecio_Enabled = 1;
         edtPostulacionProfesionalFechaA_Enabled = 0;
         cmbPostulacionProfesionalEstado.Enabled = 1;
         edtProfesionalesNombreCompleto_Enabled = 0;
         edtProfesionalesId_Enabled = 1;
         edtMultimediaTipo_Enabled = 1;
         edtMultimediaDescripcion_Enabled = 1;
         edtMultimediaDireccion_Enabled = 1;
         edtMultimediaId_Enabled = 1;
         edtCategoriasNombre_Enabled = 0;
         edtCategoriasId_Enabled = 1;
         edtPostulacionesMultimediaSerial_Jsonclick = "";
         edtPostulacionesMultimediaSerial_Enabled = 0;
         edtPostulacionesMultimediaSerial_Visible = 1;
         edtPostulacionesSecUserId_Jsonclick = "";
         edtPostulacionesSecUserId_Enabled = 1;
         edtPostulacionesSecUserId_Visible = 1;
         edtPostulacionesFechaAlta_Jsonclick = "";
         edtPostulacionesFechaAlta_Enabled = 1;
         edtPostulacionesFechaAlta_Visible = 1;
         edtPostulacionesEstado_Jsonclick = "";
         edtPostulacionesEstado_Enabled = 1;
         edtPostulacionesEstado_Visible = 1;
         edtPostulacionesTipoFecha_Jsonclick = "";
         edtPostulacionesTipoFecha_Enabled = 1;
         edtPostulacionesTipoFecha_Visible = 1;
         imgprompt_942_Visible = 1;
         imgprompt_942_Link = "";
         edtServiciosId_Jsonclick = "";
         edtServiciosId_Enabled = 1;
         edtServiciosId_Visible = 1;
         edtPostulacionesId_Jsonclick = "";
         edtPostulacionesId_Enabled = 0;
         edtPostulacionesId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         Dvpanel_tableleaflevel_profesionales_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableleaflevel_profesionales_Iconposition = "Right";
         Dvpanel_tableleaflevel_profesionales_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableleaflevel_profesionales_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableleaflevel_profesionales_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableleaflevel_profesionales_Title = context.GetMessage( "Postulados", "");
         Dvpanel_tableleaflevel_profesionales_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_tableleaflevel_profesionales_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableleaflevel_profesionales_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableleaflevel_profesionales_Width = "100%";
         Dvpanel_tableleaflevel_multimedia_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableleaflevel_multimedia_Iconposition = "Right";
         Dvpanel_tableleaflevel_multimedia_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableleaflevel_multimedia_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableleaflevel_multimedia_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableleaflevel_multimedia_Title = context.GetMessage( "Multimedia", "");
         Dvpanel_tableleaflevel_multimedia_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_tableleaflevel_multimedia_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableleaflevel_multimedia_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableleaflevel_multimedia_Width = "100%";
         Dvpanel_tableleaflevel_categorias_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableleaflevel_categorias_Iconposition = "Right";
         Dvpanel_tableleaflevel_categorias_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableleaflevel_categorias_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableleaflevel_categorias_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableleaflevel_categorias_Title = context.GetMessage( "Categoría", "");
         Dvpanel_tableleaflevel_categorias_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_tableleaflevel_categorias_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableleaflevel_categorias_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableleaflevel_categorias_Width = "100%";
         edtPostulacionesSolicitudesId_Jsonclick = "";
         edtPostulacionesSolicitudesId_Enabled = 0;
         edtServiciosNombre_Jsonclick = "";
         edtServiciosNombre_Enabled = 0;
         cmbPostulacionesRgoHoraservicio_Jsonclick = "";
         cmbPostulacionesRgoHoraservicio.Enabled = 1;
         edtPostulacionesFechaTrabajo_Jsonclick = "";
         edtPostulacionesFechaTrabajo_Enabled = 1;
         edtPostulacionesHoraCierre_Jsonclick = "";
         edtPostulacionesHoraCierre_Enabled = 1;
         edtPostulacionesFechaCierre_Jsonclick = "";
         edtPostulacionesFechaCierre_Enabled = 1;
         edtPostulacionesSuministrosDescri_Enabled = 1;
         chkPostulacionesReqSuministros.Enabled = 1;
         edtPostulacionesDescripcion_Enabled = 1;
         edtPostulacionesPrecio_Jsonclick = "";
         edtPostulacionesPrecio_Enabled = 1;
         edtPostulacionesProveedorNombre_Jsonclick = "";
         edtPostulacionesProveedorNombre_Enabled = 0;
         imgprompt_945_Visible = 1;
         imgprompt_945_Link = "";
         edtPostulacionesProveedorId_Jsonclick = "";
         edtPostulacionesProveedorId_Enabled = 1;
         edtPostulacionesTelefono_Jsonclick = "";
         edtPostulacionesTelefono_Enabled = 1;
         edtPostulacionesMail_Jsonclick = "";
         edtPostulacionesMail_Enabled = 1;
         edtPostulacionesApellidoNombre_Jsonclick = "";
         edtPostulacionesApellidoNombre_Enabled = 1;
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
         edtavVermas_Tooltiptext = "";
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

      protected void XC_16_1K126( long A970PostulacionesSolicitudesId ,
                                  long A422PostulacionesId )
      {
         new sincronizarpostulacionessolicitudes(context ).execute(  A970PostulacionesSolicitudesId,  A422PostulacionesId) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_categorias_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_93142( ) ;
         while ( nGXsfl_93_idx <= nRC_GXsfl_93 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1K142( ) ;
            standaloneModal1K142( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1K142( ) ;
            nGXsfl_93_idx = (int)(nGXsfl_93_idx+1);
            sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx), 4, 0), 4, "0");
            SubsflControlProps_93142( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_categoriasContainer)) ;
         /* End function gxnrGridlevel_categorias_newrow */
      }

      protected void gxnrGridlevel_multimedia_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_103139( ) ;
         while ( nGXsfl_103_idx <= nRC_GXsfl_103 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1K139( ) ;
            standaloneModal1K139( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1K139( ) ;
            nGXsfl_103_idx = (int)(nGXsfl_103_idx+1);
            sGXsfl_103_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_103_idx), 4, 0), 4, "0");
            SubsflControlProps_103139( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_multimediaContainer)) ;
         /* End function gxnrGridlevel_multimedia_newrow */
      }

      protected void gxnrGridlevel_profesionales_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_115137( ) ;
         while ( nGXsfl_115_idx <= nRC_GXsfl_115 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1K137( ) ;
            standaloneModal1K137( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1K137( ) ;
            nGXsfl_115_idx = (int)(nGXsfl_115_idx+1);
            sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
            SubsflControlProps_115137( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_profesionalesContainer)) ;
         /* End function gxnrGridlevel_profesionales_newrow */
      }

      protected void init_web_controls( )
      {
         chkPostulacionesReqSuministros.Name = "POSTULACIONESREQSUMINISTROS";
         chkPostulacionesReqSuministros.WebTags = "";
         chkPostulacionesReqSuministros.Caption = context.GetMessage( "¿Req. Suministros?", "");
         AssignProp("", false, chkPostulacionesReqSuministros_Internalname, "TitleCaption", chkPostulacionesReqSuministros.Caption, true);
         chkPostulacionesReqSuministros.CheckedValue = "false";
         A937PostulacionesReqSuministros = StringUtil.StrToBool( StringUtil.BoolToStr( A937PostulacionesReqSuministros));
         AssignAttri("", false, "A937PostulacionesReqSuministros", A937PostulacionesReqSuministros);
         cmbPostulacionesRgoHoraservicio.Name = "POSTULACIONESRGOHORASERVICIO";
         cmbPostulacionesRgoHoraservicio.WebTags = "";
         cmbPostulacionesRgoHoraservicio.addItem("1", context.GetMessage( "Turno 1, 8:00-12:00", ""), 0);
         cmbPostulacionesRgoHoraservicio.addItem("2", context.GetMessage( "Turno 2, 12:00-16:00", ""), 0);
         cmbPostulacionesRgoHoraservicio.addItem("3", context.GetMessage( "Turno 3, 16:00-20:00", ""), 0);
         if ( cmbPostulacionesRgoHoraservicio.ItemCount > 0 )
         {
            A949PostulacionesRgoHoraservicio = cmbPostulacionesRgoHoraservicio.getValidValue(A949PostulacionesRgoHoraservicio);
            AssignAttri("", false, "A949PostulacionesRgoHoraservicio", A949PostulacionesRgoHoraservicio);
         }
         GXCCtl = "POSTULACIONPROFESIONALESTADO_" + sGXsfl_115_idx;
         cmbPostulacionProfesionalEstado.Name = GXCCtl;
         cmbPostulacionProfesionalEstado.WebTags = "";
         cmbPostulacionProfesionalEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbPostulacionProfesionalEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbPostulacionProfesionalEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbPostulacionProfesionalEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbPostulacionProfesionalEstado.ItemCount > 0 )
         {
            A956PostulacionProfesionalEstado = cmbPostulacionProfesionalEstado.getValidValue(A956PostulacionProfesionalEstado);
         }
         GXCCtl = "POSTULACIONPROFESIONALUNIE_" + sGXsfl_115_idx;
         cmbPostulacionProfesionalUniE.Name = GXCCtl;
         cmbPostulacionProfesionalUniE.WebTags = "";
         cmbPostulacionProfesionalUniE.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbPostulacionProfesionalUniE.addItem("D", context.GetMessage( "Días", ""), 0);
         cmbPostulacionProfesionalUniE.addItem("M", context.GetMessage( "Meses", ""), 0);
         if ( cmbPostulacionProfesionalUniE.ItemCount > 0 )
         {
            A986PostulacionProfesionalUniE = cmbPostulacionProfesionalUniE.getValidValue(A986PostulacionProfesionalUniE);
            n986PostulacionProfesionalUniE = false;
         }
         GXCCtl = "POSTULACIONPROFESIONALUNIG_" + sGXsfl_115_idx;
         cmbPostulacionProfesionalUniG.Name = GXCCtl;
         cmbPostulacionProfesionalUniG.WebTags = "";
         cmbPostulacionProfesionalUniG.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbPostulacionProfesionalUniG.addItem("D", context.GetMessage( "Días", ""), 0);
         cmbPostulacionProfesionalUniG.addItem("M", context.GetMessage( "Meses", ""), 0);
         if ( cmbPostulacionProfesionalUniG.ItemCount > 0 )
         {
            A987PostulacionProfesionalUniG = cmbPostulacionProfesionalUniG.getValidValue(A987PostulacionProfesionalUniG);
            n987PostulacionProfesionalUniG = false;
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

      public void Valid_Postulacionesproveedorid( )
      {
         /* Using cursor T001K27 */
         pr_default.execute(23, new Object[] {A945PostulacionesProveedorId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Postulaciones Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "POSTULACIONESPROVEEDORID");
            AnyError = 1;
            GX_FocusControl = edtPostulacionesProveedorId_Internalname;
         }
         A969PostulacionesProveedorNombre = T001K27_A969PostulacionesProveedorNombre[0];
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A969PostulacionesProveedorNombre", StringUtil.RTrim( A969PostulacionesProveedorNombre));
      }

      public void Valid_Serviciosid( )
      {
         n942ServiciosId = false;
         /* Using cursor T001K26 */
         pr_default.execute(22, new Object[] {n942ServiciosId, A942ServiciosId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            if ( ! ( (0==A942ServiciosId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Servicios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SERVICIOSID");
               AnyError = 1;
               GX_FocusControl = edtServiciosId_Internalname;
            }
         }
         A943ServiciosNombre = T001K26_A943ServiciosNombre[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A943ServiciosNombre", StringUtil.RTrim( A943ServiciosNombre));
      }

      public void Valid_Categoriasid( )
      {
         n942ServiciosId = false;
         /* Using cursor T001K36 */
         pr_default.execute(32, new Object[] {n942ServiciosId, A942ServiciosId, A931CategoriasId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            if ( ! ( (0==A942ServiciosId) || (0==A931CategoriasId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Categorias", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CATEGORIASID");
               AnyError = 1;
               GX_FocusControl = edtCategoriasId_Internalname;
            }
         }
         A944CategoriasNombre = T001K36_A944CategoriasNombre[0];
         pr_default.close(32);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A944CategoriasNombre", StringUtil.RTrim( A944CategoriasNombre));
      }

      public void Valid_Profesionalesid( )
      {
         /* Using cursor T001K50 */
         pr_default.execute(46, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(46) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROFESIONALESID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
         }
         A167ProfesionalesApellidoPrimero = T001K50_A167ProfesionalesApellidoPrimero[0];
         A166ProfesionalesPrimerNombre = T001K50_A166ProfesionalesPrimerNombre[0];
         A191ProfesionalesSegundoNombre = T001K50_A191ProfesionalesSegundoNombre[0];
         pr_default.close(46);
         A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A167ProfesionalesApellidoPrimero", StringUtil.RTrim( A167ProfesionalesApellidoPrimero));
         AssignAttri("", false, "A166ProfesionalesPrimerNombre", StringUtil.RTrim( A166ProfesionalesPrimerNombre));
         AssignAttri("", false, "A191ProfesionalesSegundoNombre", StringUtil.RTrim( A191ProfesionalesSegundoNombre));
         AssignAttri("", false, "A886ProfesionalesNombreCompleto", A886ProfesionalesNombreCompleto);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7PostulacionesId',fld:'vPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7PostulacionesId',fld:'vPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A422PostulacionesId',fld:'POSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV14Insert_ServiciosId',fld:'vINSERT_SERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV17Insert_PostulacionesProveedorId',fld:'vINSERT_POSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A971PostulacionesProvNombreAux',fld:'POSTULACIONESPROVNOMBREAUX',pic:'',type:'char'},{av:'A979PostulacionesDepartamentoId',fld:'POSTULACIONESDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A980PostulacionesDepartamentoMunic',fld:'POSTULACIONESDEPARTAMENTOMUNIC',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A981PostulacionesZonasID',fld:'POSTULACIONESZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A998PostulacionesDireccion',fld:'POSTULACIONESDIRECCION',pic:'',type:'char'},{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("AFTER TRN","{handler:'E121K2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VVERMAS.CLICK","{handler:'E131K2',iparms:[{av:'A984PostulacionProfesionalA',fld:'POSTULACIONPROFESIONALA',pic:'',type:'svchar'},{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VVERMAS.CLICK",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_POSTULACIONESMAIL","{handler:'Valid_Postulacionesmail',iparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_POSTULACIONESMAIL",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_POSTULACIONESPROVEEDORID","{handler:'Valid_Postulacionesproveedorid',iparms:[{av:'A945PostulacionesProveedorId',fld:'POSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A969PostulacionesProveedorNombre',fld:'POSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_POSTULACIONESPROVEEDORID",",oparms:[{av:'A969PostulacionesProveedorNombre',fld:'POSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_POSTULACIONESFECHACIERRE","{handler:'Valid_Postulacionesfechacierre',iparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_POSTULACIONESFECHACIERRE",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_POSTULACIONESFECHATRABAJO","{handler:'Valid_Postulacionesfechatrabajo',iparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_POSTULACIONESFECHATRABAJO",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_POSTULACIONESSOLICITUDESID","{handler:'Valid_Postulacionessolicitudesid',iparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_POSTULACIONESSOLICITUDESID",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_POSTULACIONESID","{handler:'Valid_Postulacionesid',iparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_POSTULACIONESID",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SERVICIOSID","{handler:'Valid_Serviciosid',iparms:[{av:'A942ServiciosId',fld:'SERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A943ServiciosNombre',fld:'SERVICIOSNOMBRE',pic:'',type:'char'},{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SERVICIOSID",",oparms:[{av:'A943ServiciosNombre',fld:'SERVICIOSNOMBRE',pic:'',type:'char'},{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_POSTULACIONESFECHAALTA","{handler:'Valid_Postulacionesfechaalta',iparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_POSTULACIONESFECHAALTA",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_POSTULACIONESMULTIMEDIASERIAL","{handler:'Valid_Postulacionesmultimediaserial',iparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_POSTULACIONESMULTIMEDIASERIAL",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_CATEGORIASID","{handler:'Valid_Categoriasid',iparms:[{av:'A942ServiciosId',fld:'SERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A931CategoriasId',fld:'CATEGORIASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A944CategoriasNombre',fld:'CATEGORIASNOMBRE',pic:'',type:'char'},{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_CATEGORIASID",",oparms:[{av:'A944CategoriasNombre',fld:'CATEGORIASNOMBRE',pic:'',type:'char'},{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("NULL","{handler:'Valid_Categoriasnombre',iparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("NULL",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_MULTIMEDIAID","{handler:'Valid_Multimediaid',iparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_MULTIMEDIAID",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("NULL","{handler:'Valid_Multimediatipo',iparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("NULL",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'},{av:'A167ProfesionalesApellidoPrimero',fld:'PROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'A166ProfesionalesPrimerNombre',fld:'PROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'A191ProfesionalesSegundoNombre',fld:'PROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'A886ProfesionalesNombreCompleto',fld:'PROFESIONALESNOMBRECOMPLETO',pic:'',type:'svchar'},{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[{av:'A167ProfesionalesApellidoPrimero',fld:'PROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'A166ProfesionalesPrimerNombre',fld:'PROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'A191ProfesionalesSegundoNombre',fld:'PROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'A886ProfesionalesNombreCompleto',fld:'PROFESIONALESNOMBRECOMPLETO',pic:'',type:'svchar'},{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_POSTULACIONPROFESIONALESTADO","{handler:'Valid_Postulacionprofesionalestado',iparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_POSTULACIONPROFESIONALESTADO",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_POSTULACIONPROFESIONALFECHAT","{handler:'Valid_Postulacionprofesionalfechat',iparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_POSTULACIONPROFESIONALFECHAT",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_POSTULACIONPROFESIONALUNIE","{handler:'Valid_Postulacionprofesionalunie',iparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_POSTULACIONPROFESIONALUNIE",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_POSTULACIONPROFESIONALUNIG","{handler:'Valid_Postulacionprofesionalunig',iparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_POSTULACIONPROFESIONALUNIG",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
         setEventMetadata("NULL","{handler:'Validv_Vermas',iparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("NULL",",oparms:[{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]}");
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
         pr_default.close(46);
         pr_default.close(4);
         pr_default.close(6);
         pr_default.close(32);
         pr_default.close(9);
         pr_default.close(22);
         pr_default.close(23);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z971PostulacionesProvNombreAux = "";
         Z936PostulacionesDescripcion = "";
         Z938PostulacionesSuministrosDescri = "";
         Z947PostulacionesFechaTrabajo = DateTime.MinValue;
         Z939PostulacionesFechaCierre = DateTime.MinValue;
         Z940PostulacionesHoraCierre = "";
         Z941PostulacionesTipoFecha = "";
         Z949PostulacionesRgoHoraservicio = "";
         Z950PostulacionesApellidoNombre = "";
         Z951PostulacionesMail = "";
         Z952PostulacionesTelefono = "";
         Z998PostulacionesDireccion = "";
         Z425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         Z424PostulacionesEstado = "";
         Z933MultimediaDireccion = "";
         Z960MultimediaDescripcion = "";
         Z934MultimediaTipo = "";
         Z120ProfesionalesId = "";
         Z956PostulacionProfesionalEstado = "";
         Z957PostulacionProfesionalFechaA = (DateTime)(DateTime.MinValue);
         Z958PostulacionProfesionalFechaT = DateTime.MinValue;
         Z959PostulacionProfesionalTurnoT = "";
         Z986PostulacionProfesionalUniE = "";
         Z987PostulacionProfesionalUniG = "";
         Z984PostulacionProfesionalA = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A120ProfesionalesId = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         AV24VerMas = "";
         A949PostulacionesRgoHoraservicio = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A950PostulacionesApellidoNombre = "";
         A951PostulacionesMail = "";
         gxphoneLink = "";
         A952PostulacionesTelefono = "";
         imgprompt_945_gximage = "";
         sImgUrl = "";
         A969PostulacionesProveedorNombre = "";
         A936PostulacionesDescripcion = "";
         A938PostulacionesSuministrosDescri = "";
         A939PostulacionesFechaCierre = DateTime.MinValue;
         A940PostulacionesHoraCierre = "";
         A947PostulacionesFechaTrabajo = DateTime.MinValue;
         A943ServiciosNombre = "";
         ucDvpanel_tableleaflevel_categorias = new GXUserControl();
         ucDvpanel_tableleaflevel_multimedia = new GXUserControl();
         ucDvpanel_tableleaflevel_profesionales = new GXUserControl();
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         imgprompt_942_gximage = "";
         A941PostulacionesTipoFecha = "";
         A424PostulacionesEstado = "";
         A425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         Gridlevel_categoriasContainer = new GXWebGrid( context);
         sMode142 = "";
         sStyleString = "";
         Gridlevel_multimediaContainer = new GXWebGrid( context);
         sMode139 = "";
         Gridlevel_profesionalesContainer = new GXWebGrid( context);
         sMode137 = "";
         A971PostulacionesProvNombreAux = "";
         A998PostulacionesDireccion = "";
         AV26Pgmname = "";
         A167ProfesionalesApellidoPrimero = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         Dvpanel_tableleaflevel_categorias_Objectcall = "";
         Dvpanel_tableleaflevel_categorias_Class = "";
         Dvpanel_tableleaflevel_categorias_Height = "";
         Dvpanel_tableleaflevel_categorias_Titletype = "";
         Dvpanel_tableleaflevel_multimedia_Objectcall = "";
         Dvpanel_tableleaflevel_multimedia_Class = "";
         Dvpanel_tableleaflevel_multimedia_Height = "";
         Dvpanel_tableleaflevel_multimedia_Titletype = "";
         Dvpanel_tableleaflevel_profesionales_Objectcall = "";
         Dvpanel_tableleaflevel_profesionales_Class = "";
         Dvpanel_tableleaflevel_profesionales_Height = "";
         Dvpanel_tableleaflevel_profesionales_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode126 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A886ProfesionalesNombreCompleto = "";
         A956PostulacionProfesionalEstado = "";
         A957PostulacionProfesionalFechaA = (DateTime)(DateTime.MinValue);
         GXCCtl = "";
         A958PostulacionProfesionalFechaT = DateTime.MinValue;
         A959PostulacionProfesionalTurnoT = "";
         A986PostulacionProfesionalUniE = "";
         A987PostulacionProfesionalUniG = "";
         A984PostulacionProfesionalA = "";
         AV28Vermas_GXI = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A933MultimediaDireccion = "";
         A960MultimediaDescripcion = "";
         A934MultimediaTipo = "";
         A944CategoriasNombre = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z943ServiciosNombre = "";
         Z969PostulacionesProveedorNombre = "";
         T001K13_A970PostulacionesSolicitudesId = new long[1] ;
         T001K13_n970PostulacionesSolicitudesId = new bool[] {false} ;
         T001K15_A969PostulacionesProveedorNombre = new string[] {""} ;
         T001K14_A943ServiciosNombre = new string[] {""} ;
         T001K17_A422PostulacionesId = new long[1] ;
         T001K17_n422PostulacionesId = new bool[] {false} ;
         T001K17_A943ServiciosNombre = new string[] {""} ;
         T001K17_A971PostulacionesProvNombreAux = new string[] {""} ;
         T001K17_A969PostulacionesProveedorNombre = new string[] {""} ;
         T001K17_A946PostulacionesPrecio = new decimal[1] ;
         T001K17_A961PostulacionesMultimediaSerial = new short[1] ;
         T001K17_A936PostulacionesDescripcion = new string[] {""} ;
         T001K17_A937PostulacionesReqSuministros = new bool[] {false} ;
         T001K17_A938PostulacionesSuministrosDescri = new string[] {""} ;
         T001K17_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         T001K17_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         T001K17_A940PostulacionesHoraCierre = new string[] {""} ;
         T001K17_A941PostulacionesTipoFecha = new string[] {""} ;
         T001K17_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         T001K17_A950PostulacionesApellidoNombre = new string[] {""} ;
         T001K17_A951PostulacionesMail = new string[] {""} ;
         T001K17_A952PostulacionesTelefono = new string[] {""} ;
         T001K17_A979PostulacionesDepartamentoId = new long[1] ;
         T001K17_A980PostulacionesDepartamentoMunic = new long[1] ;
         T001K17_A981PostulacionesZonasID = new long[1] ;
         T001K17_A998PostulacionesDireccion = new string[] {""} ;
         T001K17_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T001K17_A424PostulacionesEstado = new string[] {""} ;
         T001K17_A948PostulacionesSecUserId = new long[1] ;
         T001K17_A942ServiciosId = new long[1] ;
         T001K17_n942ServiciosId = new bool[] {false} ;
         T001K17_A945PostulacionesProveedorId = new long[1] ;
         T001K17_A970PostulacionesSolicitudesId = new long[1] ;
         T001K17_n970PostulacionesSolicitudesId = new bool[] {false} ;
         T001K18_A943ServiciosNombre = new string[] {""} ;
         T001K19_A969PostulacionesProveedorNombre = new string[] {""} ;
         T001K20_A422PostulacionesId = new long[1] ;
         T001K20_n422PostulacionesId = new bool[] {false} ;
         T001K11_A422PostulacionesId = new long[1] ;
         T001K11_n422PostulacionesId = new bool[] {false} ;
         T001K11_A971PostulacionesProvNombreAux = new string[] {""} ;
         T001K11_A946PostulacionesPrecio = new decimal[1] ;
         T001K11_A961PostulacionesMultimediaSerial = new short[1] ;
         T001K11_A936PostulacionesDescripcion = new string[] {""} ;
         T001K11_A937PostulacionesReqSuministros = new bool[] {false} ;
         T001K11_A938PostulacionesSuministrosDescri = new string[] {""} ;
         T001K11_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         T001K11_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         T001K11_A940PostulacionesHoraCierre = new string[] {""} ;
         T001K11_A941PostulacionesTipoFecha = new string[] {""} ;
         T001K11_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         T001K11_A950PostulacionesApellidoNombre = new string[] {""} ;
         T001K11_A951PostulacionesMail = new string[] {""} ;
         T001K11_A952PostulacionesTelefono = new string[] {""} ;
         T001K11_A979PostulacionesDepartamentoId = new long[1] ;
         T001K11_A980PostulacionesDepartamentoMunic = new long[1] ;
         T001K11_A981PostulacionesZonasID = new long[1] ;
         T001K11_A998PostulacionesDireccion = new string[] {""} ;
         T001K11_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T001K11_A424PostulacionesEstado = new string[] {""} ;
         T001K11_A948PostulacionesSecUserId = new long[1] ;
         T001K11_A942ServiciosId = new long[1] ;
         T001K11_n942ServiciosId = new bool[] {false} ;
         T001K11_A945PostulacionesProveedorId = new long[1] ;
         T001K21_A422PostulacionesId = new long[1] ;
         T001K21_n422PostulacionesId = new bool[] {false} ;
         T001K22_A422PostulacionesId = new long[1] ;
         T001K22_n422PostulacionesId = new bool[] {false} ;
         T001K10_A422PostulacionesId = new long[1] ;
         T001K10_n422PostulacionesId = new bool[] {false} ;
         T001K10_A971PostulacionesProvNombreAux = new string[] {""} ;
         T001K10_A946PostulacionesPrecio = new decimal[1] ;
         T001K10_A961PostulacionesMultimediaSerial = new short[1] ;
         T001K10_A936PostulacionesDescripcion = new string[] {""} ;
         T001K10_A937PostulacionesReqSuministros = new bool[] {false} ;
         T001K10_A938PostulacionesSuministrosDescri = new string[] {""} ;
         T001K10_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         T001K10_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         T001K10_A940PostulacionesHoraCierre = new string[] {""} ;
         T001K10_A941PostulacionesTipoFecha = new string[] {""} ;
         T001K10_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         T001K10_A950PostulacionesApellidoNombre = new string[] {""} ;
         T001K10_A951PostulacionesMail = new string[] {""} ;
         T001K10_A952PostulacionesTelefono = new string[] {""} ;
         T001K10_A979PostulacionesDepartamentoId = new long[1] ;
         T001K10_A980PostulacionesDepartamentoMunic = new long[1] ;
         T001K10_A981PostulacionesZonasID = new long[1] ;
         T001K10_A998PostulacionesDireccion = new string[] {""} ;
         T001K10_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T001K10_A424PostulacionesEstado = new string[] {""} ;
         T001K10_A948PostulacionesSecUserId = new long[1] ;
         T001K10_A942ServiciosId = new long[1] ;
         T001K10_n942ServiciosId = new bool[] {false} ;
         T001K10_A945PostulacionesProveedorId = new long[1] ;
         T001K23_A422PostulacionesId = new long[1] ;
         T001K23_n422PostulacionesId = new bool[] {false} ;
         T001K26_A943ServiciosNombre = new string[] {""} ;
         T001K27_A969PostulacionesProveedorNombre = new string[] {""} ;
         T001K28_A127SolicitudesID = new long[1] ;
         T001K30_A422PostulacionesId = new long[1] ;
         T001K30_n422PostulacionesId = new bool[] {false} ;
         Z944CategoriasNombre = "";
         T001K31_A942ServiciosId = new long[1] ;
         T001K31_n942ServiciosId = new bool[] {false} ;
         T001K31_A422PostulacionesId = new long[1] ;
         T001K31_n422PostulacionesId = new bool[] {false} ;
         T001K31_A944CategoriasNombre = new string[] {""} ;
         T001K31_A931CategoriasId = new long[1] ;
         T001K9_A944CategoriasNombre = new string[] {""} ;
         T001K32_A944CategoriasNombre = new string[] {""} ;
         T001K33_A422PostulacionesId = new long[1] ;
         T001K33_n422PostulacionesId = new bool[] {false} ;
         T001K33_A931CategoriasId = new long[1] ;
         T001K8_A422PostulacionesId = new long[1] ;
         T001K8_n422PostulacionesId = new bool[] {false} ;
         T001K8_A931CategoriasId = new long[1] ;
         T001K7_A422PostulacionesId = new long[1] ;
         T001K7_n422PostulacionesId = new bool[] {false} ;
         T001K7_A931CategoriasId = new long[1] ;
         T001K36_A944CategoriasNombre = new string[] {""} ;
         T001K37_A422PostulacionesId = new long[1] ;
         T001K37_n422PostulacionesId = new bool[] {false} ;
         T001K37_A931CategoriasId = new long[1] ;
         T001K38_A422PostulacionesId = new long[1] ;
         T001K38_n422PostulacionesId = new bool[] {false} ;
         T001K38_A932MultimediaId = new long[1] ;
         T001K38_A933MultimediaDireccion = new string[] {""} ;
         T001K38_A960MultimediaDescripcion = new string[] {""} ;
         T001K38_A934MultimediaTipo = new string[] {""} ;
         T001K39_A422PostulacionesId = new long[1] ;
         T001K39_n422PostulacionesId = new bool[] {false} ;
         T001K39_A932MultimediaId = new long[1] ;
         T001K6_A422PostulacionesId = new long[1] ;
         T001K6_n422PostulacionesId = new bool[] {false} ;
         T001K6_A932MultimediaId = new long[1] ;
         T001K6_A933MultimediaDireccion = new string[] {""} ;
         T001K6_A960MultimediaDescripcion = new string[] {""} ;
         T001K6_A934MultimediaTipo = new string[] {""} ;
         T001K5_A422PostulacionesId = new long[1] ;
         T001K5_n422PostulacionesId = new bool[] {false} ;
         T001K5_A932MultimediaId = new long[1] ;
         T001K5_A933MultimediaDireccion = new string[] {""} ;
         T001K5_A960MultimediaDescripcion = new string[] {""} ;
         T001K5_A934MultimediaTipo = new string[] {""} ;
         T001K43_A422PostulacionesId = new long[1] ;
         T001K43_n422PostulacionesId = new bool[] {false} ;
         T001K43_A932MultimediaId = new long[1] ;
         Z167ProfesionalesApellidoPrimero = "";
         Z166ProfesionalesPrimerNombre = "";
         Z191ProfesionalesSegundoNombre = "";
         T001K44_A422PostulacionesId = new long[1] ;
         T001K44_n422PostulacionesId = new bool[] {false} ;
         T001K44_A956PostulacionProfesionalEstado = new string[] {""} ;
         T001K44_A957PostulacionProfesionalFechaA = new DateTime[] {DateTime.MinValue} ;
         T001K44_A958PostulacionProfesionalFechaT = new DateTime[] {DateTime.MinValue} ;
         T001K44_A959PostulacionProfesionalTurnoT = new string[] {""} ;
         T001K44_A982PostulacionProfesionalPrecio = new decimal[1] ;
         T001K44_n982PostulacionProfesionalPrecio = new bool[] {false} ;
         T001K44_A983PostulacionProfesionalPlazoE = new short[1] ;
         T001K44_n983PostulacionProfesionalPlazoE = new bool[] {false} ;
         T001K44_A986PostulacionProfesionalUniE = new string[] {""} ;
         T001K44_n986PostulacionProfesionalUniE = new bool[] {false} ;
         T001K44_A985PostulacionProfesionalGar = new short[1] ;
         T001K44_n985PostulacionProfesionalGar = new bool[] {false} ;
         T001K44_A987PostulacionProfesionalUniG = new string[] {""} ;
         T001K44_n987PostulacionProfesionalUniG = new bool[] {false} ;
         T001K44_A984PostulacionProfesionalA = new string[] {""} ;
         T001K44_n984PostulacionProfesionalA = new bool[] {false} ;
         T001K44_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T001K44_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T001K44_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T001K44_A120ProfesionalesId = new string[] {""} ;
         T001K4_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T001K4_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T001K4_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T001K45_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T001K45_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T001K45_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T001K46_A422PostulacionesId = new long[1] ;
         T001K46_n422PostulacionesId = new bool[] {false} ;
         T001K46_A120ProfesionalesId = new string[] {""} ;
         T001K3_A422PostulacionesId = new long[1] ;
         T001K3_n422PostulacionesId = new bool[] {false} ;
         T001K3_A956PostulacionProfesionalEstado = new string[] {""} ;
         T001K3_A957PostulacionProfesionalFechaA = new DateTime[] {DateTime.MinValue} ;
         T001K3_A958PostulacionProfesionalFechaT = new DateTime[] {DateTime.MinValue} ;
         T001K3_A959PostulacionProfesionalTurnoT = new string[] {""} ;
         T001K3_A982PostulacionProfesionalPrecio = new decimal[1] ;
         T001K3_n982PostulacionProfesionalPrecio = new bool[] {false} ;
         T001K3_A983PostulacionProfesionalPlazoE = new short[1] ;
         T001K3_n983PostulacionProfesionalPlazoE = new bool[] {false} ;
         T001K3_A986PostulacionProfesionalUniE = new string[] {""} ;
         T001K3_n986PostulacionProfesionalUniE = new bool[] {false} ;
         T001K3_A985PostulacionProfesionalGar = new short[1] ;
         T001K3_n985PostulacionProfesionalGar = new bool[] {false} ;
         T001K3_A987PostulacionProfesionalUniG = new string[] {""} ;
         T001K3_n987PostulacionProfesionalUniG = new bool[] {false} ;
         T001K3_A984PostulacionProfesionalA = new string[] {""} ;
         T001K3_n984PostulacionProfesionalA = new bool[] {false} ;
         T001K3_A120ProfesionalesId = new string[] {""} ;
         T001K2_A422PostulacionesId = new long[1] ;
         T001K2_n422PostulacionesId = new bool[] {false} ;
         T001K2_A956PostulacionProfesionalEstado = new string[] {""} ;
         T001K2_A957PostulacionProfesionalFechaA = new DateTime[] {DateTime.MinValue} ;
         T001K2_A958PostulacionProfesionalFechaT = new DateTime[] {DateTime.MinValue} ;
         T001K2_A959PostulacionProfesionalTurnoT = new string[] {""} ;
         T001K2_A982PostulacionProfesionalPrecio = new decimal[1] ;
         T001K2_n982PostulacionProfesionalPrecio = new bool[] {false} ;
         T001K2_A983PostulacionProfesionalPlazoE = new short[1] ;
         T001K2_n983PostulacionProfesionalPlazoE = new bool[] {false} ;
         T001K2_A986PostulacionProfesionalUniE = new string[] {""} ;
         T001K2_n986PostulacionProfesionalUniE = new bool[] {false} ;
         T001K2_A985PostulacionProfesionalGar = new short[1] ;
         T001K2_n985PostulacionProfesionalGar = new bool[] {false} ;
         T001K2_A987PostulacionProfesionalUniG = new string[] {""} ;
         T001K2_n987PostulacionProfesionalUniG = new bool[] {false} ;
         T001K2_A984PostulacionProfesionalA = new string[] {""} ;
         T001K2_n984PostulacionProfesionalA = new bool[] {false} ;
         T001K2_A120ProfesionalesId = new string[] {""} ;
         T001K50_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T001K50_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T001K50_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T001K51_A422PostulacionesId = new long[1] ;
         T001K51_n422PostulacionesId = new bool[] {false} ;
         T001K51_A120ProfesionalesId = new string[] {""} ;
         Gridlevel_categoriasRow = new GXWebRow();
         subGridlevel_categorias_Linesclass = "";
         ROClassString = "";
         imgprompt_931_gximage = "";
         Gridlevel_multimediaRow = new GXWebRow();
         subGridlevel_multimedia_Linesclass = "";
         Gridlevel_profesionalesRow = new GXWebRow();
         subGridlevel_profesionales_Linesclass = "";
         imgprompt_120_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_categoriasColumn = new GXWebColumn();
         Gridlevel_multimediaColumn = new GXWebColumn();
         Gridlevel_profesionalesColumn = new GXWebColumn();
         Z886ProfesionalesNombreCompleto = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.postulaciones__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.postulaciones__default(),
            new Object[][] {
                new Object[] {
               T001K2_A422PostulacionesId, T001K2_A956PostulacionProfesionalEstado, T001K2_A957PostulacionProfesionalFechaA, T001K2_A958PostulacionProfesionalFechaT, T001K2_A959PostulacionProfesionalTurnoT, T001K2_A982PostulacionProfesionalPrecio, T001K2_n982PostulacionProfesionalPrecio, T001K2_A983PostulacionProfesionalPlazoE, T001K2_n983PostulacionProfesionalPlazoE, T001K2_A986PostulacionProfesionalUniE,
               T001K2_n986PostulacionProfesionalUniE, T001K2_A985PostulacionProfesionalGar, T001K2_n985PostulacionProfesionalGar, T001K2_A987PostulacionProfesionalUniG, T001K2_n987PostulacionProfesionalUniG, T001K2_A984PostulacionProfesionalA, T001K2_n984PostulacionProfesionalA, T001K2_A120ProfesionalesId
               }
               , new Object[] {
               T001K3_A422PostulacionesId, T001K3_A956PostulacionProfesionalEstado, T001K3_A957PostulacionProfesionalFechaA, T001K3_A958PostulacionProfesionalFechaT, T001K3_A959PostulacionProfesionalTurnoT, T001K3_A982PostulacionProfesionalPrecio, T001K3_n982PostulacionProfesionalPrecio, T001K3_A983PostulacionProfesionalPlazoE, T001K3_n983PostulacionProfesionalPlazoE, T001K3_A986PostulacionProfesionalUniE,
               T001K3_n986PostulacionProfesionalUniE, T001K3_A985PostulacionProfesionalGar, T001K3_n985PostulacionProfesionalGar, T001K3_A987PostulacionProfesionalUniG, T001K3_n987PostulacionProfesionalUniG, T001K3_A984PostulacionProfesionalA, T001K3_n984PostulacionProfesionalA, T001K3_A120ProfesionalesId
               }
               , new Object[] {
               T001K4_A167ProfesionalesApellidoPrimero, T001K4_A166ProfesionalesPrimerNombre, T001K4_A191ProfesionalesSegundoNombre
               }
               , new Object[] {
               T001K5_A422PostulacionesId, T001K5_A932MultimediaId, T001K5_A933MultimediaDireccion, T001K5_A960MultimediaDescripcion, T001K5_A934MultimediaTipo
               }
               , new Object[] {
               T001K6_A422PostulacionesId, T001K6_A932MultimediaId, T001K6_A933MultimediaDireccion, T001K6_A960MultimediaDescripcion, T001K6_A934MultimediaTipo
               }
               , new Object[] {
               T001K7_A422PostulacionesId, T001K7_A931CategoriasId
               }
               , new Object[] {
               T001K8_A422PostulacionesId, T001K8_A931CategoriasId
               }
               , new Object[] {
               T001K9_A944CategoriasNombre
               }
               , new Object[] {
               T001K10_A422PostulacionesId, T001K10_A971PostulacionesProvNombreAux, T001K10_A946PostulacionesPrecio, T001K10_A961PostulacionesMultimediaSerial, T001K10_A936PostulacionesDescripcion, T001K10_A937PostulacionesReqSuministros, T001K10_A938PostulacionesSuministrosDescri, T001K10_A947PostulacionesFechaTrabajo, T001K10_A939PostulacionesFechaCierre, T001K10_A940PostulacionesHoraCierre,
               T001K10_A941PostulacionesTipoFecha, T001K10_A949PostulacionesRgoHoraservicio, T001K10_A950PostulacionesApellidoNombre, T001K10_A951PostulacionesMail, T001K10_A952PostulacionesTelefono, T001K10_A979PostulacionesDepartamentoId, T001K10_A980PostulacionesDepartamentoMunic, T001K10_A981PostulacionesZonasID, T001K10_A998PostulacionesDireccion, T001K10_A425PostulacionesFechaAlta,
               T001K10_A424PostulacionesEstado, T001K10_A948PostulacionesSecUserId, T001K10_A942ServiciosId, T001K10_n942ServiciosId, T001K10_A945PostulacionesProveedorId
               }
               , new Object[] {
               T001K11_A422PostulacionesId, T001K11_A971PostulacionesProvNombreAux, T001K11_A946PostulacionesPrecio, T001K11_A961PostulacionesMultimediaSerial, T001K11_A936PostulacionesDescripcion, T001K11_A937PostulacionesReqSuministros, T001K11_A938PostulacionesSuministrosDescri, T001K11_A947PostulacionesFechaTrabajo, T001K11_A939PostulacionesFechaCierre, T001K11_A940PostulacionesHoraCierre,
               T001K11_A941PostulacionesTipoFecha, T001K11_A949PostulacionesRgoHoraservicio, T001K11_A950PostulacionesApellidoNombre, T001K11_A951PostulacionesMail, T001K11_A952PostulacionesTelefono, T001K11_A979PostulacionesDepartamentoId, T001K11_A980PostulacionesDepartamentoMunic, T001K11_A981PostulacionesZonasID, T001K11_A998PostulacionesDireccion, T001K11_A425PostulacionesFechaAlta,
               T001K11_A424PostulacionesEstado, T001K11_A948PostulacionesSecUserId, T001K11_A942ServiciosId, T001K11_n942ServiciosId, T001K11_A945PostulacionesProveedorId
               }
               , new Object[] {
               T001K13_A970PostulacionesSolicitudesId, T001K13_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               T001K14_A943ServiciosNombre
               }
               , new Object[] {
               T001K15_A969PostulacionesProveedorNombre
               }
               , new Object[] {
               T001K17_A422PostulacionesId, T001K17_A943ServiciosNombre, T001K17_A971PostulacionesProvNombreAux, T001K17_A969PostulacionesProveedorNombre, T001K17_A946PostulacionesPrecio, T001K17_A961PostulacionesMultimediaSerial, T001K17_A936PostulacionesDescripcion, T001K17_A937PostulacionesReqSuministros, T001K17_A938PostulacionesSuministrosDescri, T001K17_A947PostulacionesFechaTrabajo,
               T001K17_A939PostulacionesFechaCierre, T001K17_A940PostulacionesHoraCierre, T001K17_A941PostulacionesTipoFecha, T001K17_A949PostulacionesRgoHoraservicio, T001K17_A950PostulacionesApellidoNombre, T001K17_A951PostulacionesMail, T001K17_A952PostulacionesTelefono, T001K17_A979PostulacionesDepartamentoId, T001K17_A980PostulacionesDepartamentoMunic, T001K17_A981PostulacionesZonasID,
               T001K17_A998PostulacionesDireccion, T001K17_A425PostulacionesFechaAlta, T001K17_A424PostulacionesEstado, T001K17_A948PostulacionesSecUserId, T001K17_A942ServiciosId, T001K17_n942ServiciosId, T001K17_A945PostulacionesProveedorId, T001K17_A970PostulacionesSolicitudesId, T001K17_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               T001K18_A943ServiciosNombre
               }
               , new Object[] {
               T001K19_A969PostulacionesProveedorNombre
               }
               , new Object[] {
               T001K20_A422PostulacionesId
               }
               , new Object[] {
               T001K21_A422PostulacionesId
               }
               , new Object[] {
               T001K22_A422PostulacionesId
               }
               , new Object[] {
               T001K23_A422PostulacionesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001K26_A943ServiciosNombre
               }
               , new Object[] {
               T001K27_A969PostulacionesProveedorNombre
               }
               , new Object[] {
               T001K28_A127SolicitudesID
               }
               , new Object[] {
               }
               , new Object[] {
               T001K30_A422PostulacionesId
               }
               , new Object[] {
               T001K31_A942ServiciosId, T001K31_A422PostulacionesId, T001K31_A944CategoriasNombre, T001K31_A931CategoriasId
               }
               , new Object[] {
               T001K32_A944CategoriasNombre
               }
               , new Object[] {
               T001K33_A422PostulacionesId, T001K33_A931CategoriasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001K36_A944CategoriasNombre
               }
               , new Object[] {
               T001K37_A422PostulacionesId, T001K37_A931CategoriasId
               }
               , new Object[] {
               T001K38_A422PostulacionesId, T001K38_A932MultimediaId, T001K38_A933MultimediaDireccion, T001K38_A960MultimediaDescripcion, T001K38_A934MultimediaTipo
               }
               , new Object[] {
               T001K39_A422PostulacionesId, T001K39_A932MultimediaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001K43_A422PostulacionesId, T001K43_A932MultimediaId
               }
               , new Object[] {
               T001K44_A422PostulacionesId, T001K44_A956PostulacionProfesionalEstado, T001K44_A957PostulacionProfesionalFechaA, T001K44_A958PostulacionProfesionalFechaT, T001K44_A959PostulacionProfesionalTurnoT, T001K44_A982PostulacionProfesionalPrecio, T001K44_n982PostulacionProfesionalPrecio, T001K44_A983PostulacionProfesionalPlazoE, T001K44_n983PostulacionProfesionalPlazoE, T001K44_A986PostulacionProfesionalUniE,
               T001K44_n986PostulacionProfesionalUniE, T001K44_A985PostulacionProfesionalGar, T001K44_n985PostulacionProfesionalGar, T001K44_A987PostulacionProfesionalUniG, T001K44_n987PostulacionProfesionalUniG, T001K44_A984PostulacionProfesionalA, T001K44_n984PostulacionProfesionalA, T001K44_A167ProfesionalesApellidoPrimero, T001K44_A166ProfesionalesPrimerNombre, T001K44_A191ProfesionalesSegundoNombre,
               T001K44_A120ProfesionalesId
               }
               , new Object[] {
               T001K45_A167ProfesionalesApellidoPrimero, T001K45_A166ProfesionalesPrimerNombre, T001K45_A191ProfesionalesSegundoNombre
               }
               , new Object[] {
               T001K46_A422PostulacionesId, T001K46_A120ProfesionalesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001K50_A167ProfesionalesApellidoPrimero, T001K50_A166ProfesionalesPrimerNombre, T001K50_A191ProfesionalesSegundoNombre
               }
               , new Object[] {
               T001K51_A422PostulacionesId, T001K51_A120ProfesionalesId
               }
            }
         );
         AV26Pgmname = "Postulaciones";
      }

      private short nIsMod_142 ;
      private short nIsMod_137 ;
      private short Z961PostulacionesMultimediaSerial ;
      private short O961PostulacionesMultimediaSerial ;
      private short nRcdDeleted_142 ;
      private short nRcdExists_142 ;
      private short nRcdDeleted_139 ;
      private short nRcdExists_139 ;
      private short nIsMod_139 ;
      private short Z983PostulacionProfesionalPlazoE ;
      private short Z985PostulacionProfesionalGar ;
      private short nRcdDeleted_137 ;
      private short nRcdExists_137 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A961PostulacionesMultimediaSerial ;
      private short Gx_BScreen ;
      private short nBlankRcdCount142 ;
      private short RcdFound142 ;
      private short B961PostulacionesMultimediaSerial ;
      private short nBlankRcdUsr142 ;
      private short nBlankRcdCount139 ;
      private short RcdFound139 ;
      private short nBlankRcdUsr139 ;
      private short nBlankRcdCount137 ;
      private short RcdFound137 ;
      private short nBlankRcdUsr137 ;
      private short RcdFound126 ;
      private short A983PostulacionProfesionalPlazoE ;
      private short A985PostulacionProfesionalGar ;
      private short s961PostulacionesMultimediaSerial ;
      private short nIsDirty_142 ;
      private short nIsDirty_139 ;
      private short nIsDirty_137 ;
      private short subGridlevel_categorias_Backcolorstyle ;
      private short subGridlevel_categorias_Backstyle ;
      private short subGridlevel_multimedia_Backcolorstyle ;
      private short subGridlevel_multimedia_Backstyle ;
      private short subGridlevel_profesionales_Backcolorstyle ;
      private short subGridlevel_profesionales_Backstyle ;
      private short gxajaxcallmode ;
      private short i961PostulacionesMultimediaSerial ;
      private short subGridlevel_categorias_Allowselection ;
      private short subGridlevel_categorias_Allowhovering ;
      private short subGridlevel_categorias_Allowcollapsing ;
      private short subGridlevel_categorias_Collapsed ;
      private short subGridlevel_multimedia_Allowselection ;
      private short subGridlevel_multimedia_Allowhovering ;
      private short subGridlevel_multimedia_Allowcollapsing ;
      private short subGridlevel_multimedia_Collapsed ;
      private short subGridlevel_profesionales_Allowselection ;
      private short subGridlevel_profesionales_Allowhovering ;
      private short subGridlevel_profesionales_Allowcollapsing ;
      private short subGridlevel_profesionales_Collapsed ;
      private int nRC_GXsfl_93 ;
      private int nGXsfl_93_idx=1 ;
      private int nRC_GXsfl_103 ;
      private int nGXsfl_103_idx=1 ;
      private int nRC_GXsfl_115 ;
      private int nGXsfl_115_idx=1 ;
      private int trnEnded ;
      private int edtPostulacionesApellidoNombre_Enabled ;
      private int edtPostulacionesMail_Enabled ;
      private int edtPostulacionesTelefono_Enabled ;
      private int edtPostulacionesProveedorId_Enabled ;
      private int imgprompt_945_Visible ;
      private int edtPostulacionesProveedorNombre_Enabled ;
      private int edtPostulacionesPrecio_Enabled ;
      private int edtPostulacionesDescripcion_Enabled ;
      private int edtPostulacionesSuministrosDescri_Enabled ;
      private int edtPostulacionesFechaCierre_Enabled ;
      private int edtPostulacionesHoraCierre_Enabled ;
      private int edtPostulacionesFechaTrabajo_Enabled ;
      private int edtServiciosNombre_Enabled ;
      private int edtPostulacionesSolicitudesId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtPostulacionesId_Enabled ;
      private int edtPostulacionesId_Visible ;
      private int edtServiciosId_Visible ;
      private int edtServiciosId_Enabled ;
      private int imgprompt_942_Visible ;
      private int edtPostulacionesTipoFecha_Visible ;
      private int edtPostulacionesTipoFecha_Enabled ;
      private int edtPostulacionesEstado_Visible ;
      private int edtPostulacionesEstado_Enabled ;
      private int edtPostulacionesFechaAlta_Visible ;
      private int edtPostulacionesFechaAlta_Enabled ;
      private int edtPostulacionesSecUserId_Enabled ;
      private int edtPostulacionesSecUserId_Visible ;
      private int edtPostulacionesMultimediaSerial_Enabled ;
      private int edtPostulacionesMultimediaSerial_Visible ;
      private int edtCategoriasId_Enabled ;
      private int edtCategoriasNombre_Enabled ;
      private int fRowAdded ;
      private int edtMultimediaId_Enabled ;
      private int edtMultimediaDireccion_Enabled ;
      private int edtMultimediaDescripcion_Enabled ;
      private int edtMultimediaTipo_Enabled ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesNombreCompleto_Enabled ;
      private int edtPostulacionProfesionalFechaA_Enabled ;
      private int edtPostulacionProfesionalPrecio_Enabled ;
      private int edtPostulacionProfesionalFechaT_Enabled ;
      private int edtPostulacionProfesionalTurnoT_Enabled ;
      private int edtPostulacionProfesionalPlazoE_Enabled ;
      private int edtPostulacionProfesionalGar_Enabled ;
      private int edtPostulacionProfesionalA_Enabled ;
      private int edtavVermas_Enabled ;
      private int edtavVermas_Visible ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int Dvpanel_tableleaflevel_categorias_Gxcontroltype ;
      private int Dvpanel_tableleaflevel_multimedia_Gxcontroltype ;
      private int Dvpanel_tableleaflevel_profesionales_Gxcontroltype ;
      private int AV27GXV1 ;
      private int subGridlevel_categorias_Backcolor ;
      private int subGridlevel_categorias_Allbackcolor ;
      private int imgprompt_931_Visible ;
      private int subGridlevel_multimedia_Backcolor ;
      private int subGridlevel_multimedia_Allbackcolor ;
      private int subGridlevel_profesionales_Backcolor ;
      private int subGridlevel_profesionales_Allbackcolor ;
      private int imgprompt_120_Visible ;
      private int defedtPostulacionProfesionalFechaA_Enabled ;
      private int defedtProfesionalesId_Enabled ;
      private int defedtMultimediaId_Enabled ;
      private int defedtCategoriasId_Enabled ;
      private int idxLst ;
      private int subGridlevel_categorias_Selectedindex ;
      private int subGridlevel_categorias_Selectioncolor ;
      private int subGridlevel_categorias_Hoveringcolor ;
      private int subGridlevel_multimedia_Selectedindex ;
      private int subGridlevel_multimedia_Selectioncolor ;
      private int subGridlevel_multimedia_Hoveringcolor ;
      private int subGridlevel_profesionales_Selectedindex ;
      private int subGridlevel_profesionales_Selectioncolor ;
      private int subGridlevel_profesionales_Hoveringcolor ;
      private long wcpOAV7PostulacionesId ;
      private long Z422PostulacionesId ;
      private long Z979PostulacionesDepartamentoId ;
      private long Z980PostulacionesDepartamentoMunic ;
      private long Z981PostulacionesZonasID ;
      private long Z948PostulacionesSecUserId ;
      private long Z942ServiciosId ;
      private long Z945PostulacionesProveedorId ;
      private long N942ServiciosId ;
      private long N945PostulacionesProveedorId ;
      private long Z931CategoriasId ;
      private long Z932MultimediaId ;
      private long A970PostulacionesSolicitudesId ;
      private long A422PostulacionesId ;
      private long A942ServiciosId ;
      private long A945PostulacionesProveedorId ;
      private long A931CategoriasId ;
      private long AV7PostulacionesId ;
      private long A948PostulacionesSecUserId ;
      private long A979PostulacionesDepartamentoId ;
      private long A980PostulacionesDepartamentoMunic ;
      private long A981PostulacionesZonasID ;
      private long AV14Insert_ServiciosId ;
      private long AV17Insert_PostulacionesProveedorId ;
      private long GRIDLEVEL_CATEGORIAS_nFirstRecordOnPage ;
      private long GRIDLEVEL_MULTIMEDIA_nFirstRecordOnPage ;
      private long GRIDLEVEL_PROFESIONALES_nFirstRecordOnPage ;
      private long A932MultimediaId ;
      private long Z970PostulacionesSolicitudesId ;
      private decimal Z946PostulacionesPrecio ;
      private decimal Z982PostulacionProfesionalPrecio ;
      private decimal A946PostulacionesPrecio ;
      private decimal A982PostulacionProfesionalPrecio ;
      private string sPrefix ;
      private string sGXsfl_93_idx="0001" ;
      private string sGXsfl_115_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z971PostulacionesProvNombreAux ;
      private string Z936PostulacionesDescripcion ;
      private string Z938PostulacionesSuministrosDescri ;
      private string Z949PostulacionesRgoHoraservicio ;
      private string Z950PostulacionesApellidoNombre ;
      private string Z952PostulacionesTelefono ;
      private string Z998PostulacionesDireccion ;
      private string Z424PostulacionesEstado ;
      private string Z933MultimediaDireccion ;
      private string Z960MultimediaDescripcion ;
      private string Z120ProfesionalesId ;
      private string Z956PostulacionProfesionalEstado ;
      private string Z959PostulacionProfesionalTurnoT ;
      private string Z986PostulacionProfesionalUniE ;
      private string Z987PostulacionProfesionalUniG ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A120ProfesionalesId ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPostulacionesApellidoNombre_Internalname ;
      private string sGXsfl_103_idx="0001" ;
      private string edtavVermas_Tooltiptext ;
      private string edtavVermas_Internalname ;
      private string A949PostulacionesRgoHoraservicio ;
      private string cmbPostulacionesRgoHoraservicio_Internalname ;
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
      private string A950PostulacionesApellidoNombre ;
      private string edtPostulacionesApellidoNombre_Jsonclick ;
      private string edtPostulacionesMail_Internalname ;
      private string edtPostulacionesMail_Jsonclick ;
      private string edtPostulacionesTelefono_Internalname ;
      private string gxphoneLink ;
      private string A952PostulacionesTelefono ;
      private string edtPostulacionesTelefono_Jsonclick ;
      private string edtPostulacionesProveedorId_Internalname ;
      private string edtPostulacionesProveedorId_Jsonclick ;
      private string imgprompt_945_gximage ;
      private string sImgUrl ;
      private string imgprompt_945_Internalname ;
      private string imgprompt_945_Link ;
      private string edtPostulacionesProveedorNombre_Internalname ;
      private string A969PostulacionesProveedorNombre ;
      private string edtPostulacionesProveedorNombre_Jsonclick ;
      private string edtPostulacionesPrecio_Internalname ;
      private string edtPostulacionesPrecio_Jsonclick ;
      private string edtPostulacionesDescripcion_Internalname ;
      private string A936PostulacionesDescripcion ;
      private string chkPostulacionesReqSuministros_Internalname ;
      private string edtPostulacionesSuministrosDescri_Internalname ;
      private string A938PostulacionesSuministrosDescri ;
      private string edtPostulacionesFechaCierre_Internalname ;
      private string edtPostulacionesFechaCierre_Jsonclick ;
      private string edtPostulacionesHoraCierre_Internalname ;
      private string edtPostulacionesHoraCierre_Jsonclick ;
      private string edtPostulacionesFechaTrabajo_Internalname ;
      private string edtPostulacionesFechaTrabajo_Jsonclick ;
      private string cmbPostulacionesRgoHoraservicio_Jsonclick ;
      private string edtServiciosNombre_Internalname ;
      private string A943ServiciosNombre ;
      private string edtServiciosNombre_Jsonclick ;
      private string edtPostulacionesSolicitudesId_Internalname ;
      private string edtPostulacionesSolicitudesId_Jsonclick ;
      private string Dvpanel_tableleaflevel_categorias_Width ;
      private string Dvpanel_tableleaflevel_categorias_Cls ;
      private string Dvpanel_tableleaflevel_categorias_Title ;
      private string Dvpanel_tableleaflevel_categorias_Iconposition ;
      private string Dvpanel_tableleaflevel_categorias_Internalname ;
      private string divTableleaflevel_categorias_Internalname ;
      private string Dvpanel_tableleaflevel_multimedia_Width ;
      private string Dvpanel_tableleaflevel_multimedia_Cls ;
      private string Dvpanel_tableleaflevel_multimedia_Title ;
      private string Dvpanel_tableleaflevel_multimedia_Iconposition ;
      private string Dvpanel_tableleaflevel_multimedia_Internalname ;
      private string divTableleaflevel_multimedia_Internalname ;
      private string Dvpanel_tableleaflevel_profesionales_Width ;
      private string Dvpanel_tableleaflevel_profesionales_Cls ;
      private string Dvpanel_tableleaflevel_profesionales_Title ;
      private string Dvpanel_tableleaflevel_profesionales_Iconposition ;
      private string Dvpanel_tableleaflevel_profesionales_Internalname ;
      private string divTableleaflevel_profesionales_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtPostulacionesId_Internalname ;
      private string edtPostulacionesId_Jsonclick ;
      private string edtServiciosId_Internalname ;
      private string edtServiciosId_Jsonclick ;
      private string imgprompt_942_gximage ;
      private string imgprompt_942_Internalname ;
      private string imgprompt_942_Link ;
      private string edtPostulacionesTipoFecha_Internalname ;
      private string edtPostulacionesTipoFecha_Jsonclick ;
      private string edtPostulacionesEstado_Internalname ;
      private string A424PostulacionesEstado ;
      private string edtPostulacionesEstado_Jsonclick ;
      private string edtPostulacionesFechaAlta_Internalname ;
      private string edtPostulacionesFechaAlta_Jsonclick ;
      private string edtPostulacionesSecUserId_Internalname ;
      private string edtPostulacionesSecUserId_Jsonclick ;
      private string edtPostulacionesMultimediaSerial_Internalname ;
      private string edtPostulacionesMultimediaSerial_Jsonclick ;
      private string sMode142 ;
      private string edtCategoriasId_Internalname ;
      private string edtCategoriasNombre_Internalname ;
      private string sStyleString ;
      private string subGridlevel_categorias_Internalname ;
      private string sMode139 ;
      private string edtMultimediaId_Internalname ;
      private string edtMultimediaDireccion_Internalname ;
      private string edtMultimediaDescripcion_Internalname ;
      private string edtMultimediaTipo_Internalname ;
      private string subGridlevel_multimedia_Internalname ;
      private string sMode137 ;
      private string edtProfesionalesId_Internalname ;
      private string edtProfesionalesNombreCompleto_Internalname ;
      private string cmbPostulacionProfesionalEstado_Internalname ;
      private string edtPostulacionProfesionalFechaA_Internalname ;
      private string edtPostulacionProfesionalPrecio_Internalname ;
      private string edtPostulacionProfesionalFechaT_Internalname ;
      private string edtPostulacionProfesionalTurnoT_Internalname ;
      private string edtPostulacionProfesionalPlazoE_Internalname ;
      private string cmbPostulacionProfesionalUniE_Internalname ;
      private string edtPostulacionProfesionalGar_Internalname ;
      private string cmbPostulacionProfesionalUniG_Internalname ;
      private string edtPostulacionProfesionalA_Internalname ;
      private string subGridlevel_profesionales_Internalname ;
      private string A971PostulacionesProvNombreAux ;
      private string A998PostulacionesDireccion ;
      private string AV26Pgmname ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string Dvpanel_tableleaflevel_categorias_Objectcall ;
      private string Dvpanel_tableleaflevel_categorias_Class ;
      private string Dvpanel_tableleaflevel_categorias_Height ;
      private string Dvpanel_tableleaflevel_categorias_Titletype ;
      private string Dvpanel_tableleaflevel_multimedia_Objectcall ;
      private string Dvpanel_tableleaflevel_multimedia_Class ;
      private string Dvpanel_tableleaflevel_multimedia_Height ;
      private string Dvpanel_tableleaflevel_multimedia_Titletype ;
      private string Dvpanel_tableleaflevel_profesionales_Objectcall ;
      private string Dvpanel_tableleaflevel_profesionales_Class ;
      private string Dvpanel_tableleaflevel_profesionales_Height ;
      private string Dvpanel_tableleaflevel_profesionales_Titletype ;
      private string hsh ;
      private string sMode126 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string A956PostulacionProfesionalEstado ;
      private string GXCCtl ;
      private string A959PostulacionProfesionalTurnoT ;
      private string A986PostulacionProfesionalUniE ;
      private string A987PostulacionProfesionalUniG ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A933MultimediaDireccion ;
      private string A960MultimediaDescripcion ;
      private string A944CategoriasNombre ;
      private string GXEncryptionTmp ;
      private string edtavVermas_gximage ;
      private string Z943ServiciosNombre ;
      private string Z969PostulacionesProveedorNombre ;
      private string Z944CategoriasNombre ;
      private string Z167ProfesionalesApellidoPrimero ;
      private string Z166ProfesionalesPrimerNombre ;
      private string Z191ProfesionalesSegundoNombre ;
      private string imgprompt_931_Internalname ;
      private string sGXsfl_93_fel_idx="0001" ;
      private string subGridlevel_categorias_Class ;
      private string subGridlevel_categorias_Linesclass ;
      private string imgprompt_931_Link ;
      private string ROClassString ;
      private string edtCategoriasId_Jsonclick ;
      private string imgprompt_931_gximage ;
      private string edtCategoriasNombre_Jsonclick ;
      private string sGXsfl_103_fel_idx="0001" ;
      private string subGridlevel_multimedia_Class ;
      private string subGridlevel_multimedia_Linesclass ;
      private string edtMultimediaId_Jsonclick ;
      private string edtMultimediaDireccion_Jsonclick ;
      private string edtMultimediaDescripcion_Jsonclick ;
      private string edtMultimediaTipo_Jsonclick ;
      private string imgprompt_120_Internalname ;
      private string sGXsfl_115_fel_idx="0001" ;
      private string subGridlevel_profesionales_Class ;
      private string subGridlevel_profesionales_Linesclass ;
      private string imgprompt_120_Link ;
      private string edtProfesionalesId_Jsonclick ;
      private string imgprompt_120_gximage ;
      private string edtProfesionalesNombreCompleto_Jsonclick ;
      private string cmbPostulacionProfesionalEstado_Jsonclick ;
      private string edtPostulacionProfesionalFechaA_Jsonclick ;
      private string edtPostulacionProfesionalPrecio_Jsonclick ;
      private string edtPostulacionProfesionalFechaT_Jsonclick ;
      private string edtPostulacionProfesionalTurnoT_Jsonclick ;
      private string edtPostulacionProfesionalPlazoE_Jsonclick ;
      private string cmbPostulacionProfesionalUniE_Jsonclick ;
      private string edtPostulacionProfesionalGar_Jsonclick ;
      private string cmbPostulacionProfesionalUniG_Jsonclick ;
      private string edtPostulacionProfesionalA_Jsonclick ;
      private string edtavVermas_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_categorias_Header ;
      private string subGridlevel_multimedia_Header ;
      private string subGridlevel_profesionales_Header ;
      private DateTime Z425PostulacionesFechaAlta ;
      private DateTime Z957PostulacionProfesionalFechaA ;
      private DateTime A425PostulacionesFechaAlta ;
      private DateTime A957PostulacionProfesionalFechaA ;
      private DateTime Z947PostulacionesFechaTrabajo ;
      private DateTime Z939PostulacionesFechaCierre ;
      private DateTime Z958PostulacionProfesionalFechaT ;
      private DateTime A939PostulacionesFechaCierre ;
      private DateTime A947PostulacionesFechaTrabajo ;
      private DateTime A958PostulacionProfesionalFechaT ;
      private bool Z937PostulacionesReqSuministros ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n970PostulacionesSolicitudesId ;
      private bool n422PostulacionesId ;
      private bool n942ServiciosId ;
      private bool wbErr ;
      private bool bGXsfl_115_Refreshing=false ;
      private bool A937PostulacionesReqSuministros ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_tableleaflevel_categorias_Autowidth ;
      private bool Dvpanel_tableleaflevel_categorias_Autoheight ;
      private bool Dvpanel_tableleaflevel_categorias_Collapsible ;
      private bool Dvpanel_tableleaflevel_categorias_Collapsed ;
      private bool Dvpanel_tableleaflevel_categorias_Showcollapseicon ;
      private bool Dvpanel_tableleaflevel_categorias_Autoscroll ;
      private bool Dvpanel_tableleaflevel_multimedia_Autowidth ;
      private bool Dvpanel_tableleaflevel_multimedia_Autoheight ;
      private bool Dvpanel_tableleaflevel_multimedia_Collapsible ;
      private bool Dvpanel_tableleaflevel_multimedia_Collapsed ;
      private bool Dvpanel_tableleaflevel_multimedia_Showcollapseicon ;
      private bool Dvpanel_tableleaflevel_multimedia_Autoscroll ;
      private bool Dvpanel_tableleaflevel_profesionales_Autowidth ;
      private bool Dvpanel_tableleaflevel_profesionales_Autoheight ;
      private bool Dvpanel_tableleaflevel_profesionales_Collapsible ;
      private bool Dvpanel_tableleaflevel_profesionales_Collapsed ;
      private bool Dvpanel_tableleaflevel_profesionales_Showcollapseicon ;
      private bool Dvpanel_tableleaflevel_profesionales_Autoscroll ;
      private bool bGXsfl_93_Refreshing=false ;
      private bool bGXsfl_103_Refreshing=false ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool Dvpanel_tableleaflevel_categorias_Enabled ;
      private bool Dvpanel_tableleaflevel_categorias_Showheader ;
      private bool Dvpanel_tableleaflevel_categorias_Visible ;
      private bool Dvpanel_tableleaflevel_multimedia_Enabled ;
      private bool Dvpanel_tableleaflevel_multimedia_Showheader ;
      private bool Dvpanel_tableleaflevel_multimedia_Visible ;
      private bool Dvpanel_tableleaflevel_profesionales_Enabled ;
      private bool Dvpanel_tableleaflevel_profesionales_Showheader ;
      private bool Dvpanel_tableleaflevel_profesionales_Visible ;
      private bool n982PostulacionProfesionalPrecio ;
      private bool n983PostulacionProfesionalPlazoE ;
      private bool n986PostulacionProfesionalUniE ;
      private bool n985PostulacionProfesionalGar ;
      private bool n987PostulacionProfesionalUniG ;
      private bool n984PostulacionProfesionalA ;
      private bool returnInSub ;
      private bool AV10IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private bool AV24VerMas_IsBlob ;
      private string Z940PostulacionesHoraCierre ;
      private string Z941PostulacionesTipoFecha ;
      private string Z951PostulacionesMail ;
      private string Z934MultimediaTipo ;
      private string Z984PostulacionProfesionalA ;
      private string A951PostulacionesMail ;
      private string A940PostulacionesHoraCierre ;
      private string A941PostulacionesTipoFecha ;
      private string A886ProfesionalesNombreCompleto ;
      private string A984PostulacionProfesionalA ;
      private string AV28Vermas_GXI ;
      private string A934MultimediaTipo ;
      private string Z886ProfesionalesNombreCompleto ;
      private string AV24VerMas ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_categoriasContainer ;
      private GXWebGrid Gridlevel_multimediaContainer ;
      private GXWebGrid Gridlevel_profesionalesContainer ;
      private GXWebRow Gridlevel_categoriasRow ;
      private GXWebRow Gridlevel_multimediaRow ;
      private GXWebRow Gridlevel_profesionalesRow ;
      private GXWebColumn Gridlevel_categoriasColumn ;
      private GXWebColumn Gridlevel_multimediaColumn ;
      private GXWebColumn Gridlevel_profesionalesColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucDvpanel_tableleaflevel_categorias ;
      private GXUserControl ucDvpanel_tableleaflevel_multimedia ;
      private GXUserControl ucDvpanel_tableleaflevel_profesionales ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkPostulacionesReqSuministros ;
      private GXCombobox cmbPostulacionesRgoHoraservicio ;
      private GXCombobox cmbPostulacionProfesionalEstado ;
      private GXCombobox cmbPostulacionProfesionalUniE ;
      private GXCombobox cmbPostulacionProfesionalUniG ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] T001K13_A970PostulacionesSolicitudesId ;
      private bool[] T001K13_n970PostulacionesSolicitudesId ;
      private string[] T001K15_A969PostulacionesProveedorNombre ;
      private string[] T001K14_A943ServiciosNombre ;
      private long[] T001K17_A422PostulacionesId ;
      private bool[] T001K17_n422PostulacionesId ;
      private string[] T001K17_A943ServiciosNombre ;
      private string[] T001K17_A971PostulacionesProvNombreAux ;
      private string[] T001K17_A969PostulacionesProveedorNombre ;
      private decimal[] T001K17_A946PostulacionesPrecio ;
      private short[] T001K17_A961PostulacionesMultimediaSerial ;
      private string[] T001K17_A936PostulacionesDescripcion ;
      private bool[] T001K17_A937PostulacionesReqSuministros ;
      private string[] T001K17_A938PostulacionesSuministrosDescri ;
      private DateTime[] T001K17_A947PostulacionesFechaTrabajo ;
      private DateTime[] T001K17_A939PostulacionesFechaCierre ;
      private string[] T001K17_A940PostulacionesHoraCierre ;
      private string[] T001K17_A941PostulacionesTipoFecha ;
      private string[] T001K17_A949PostulacionesRgoHoraservicio ;
      private string[] T001K17_A950PostulacionesApellidoNombre ;
      private string[] T001K17_A951PostulacionesMail ;
      private string[] T001K17_A952PostulacionesTelefono ;
      private long[] T001K17_A979PostulacionesDepartamentoId ;
      private long[] T001K17_A980PostulacionesDepartamentoMunic ;
      private long[] T001K17_A981PostulacionesZonasID ;
      private string[] T001K17_A998PostulacionesDireccion ;
      private DateTime[] T001K17_A425PostulacionesFechaAlta ;
      private string[] T001K17_A424PostulacionesEstado ;
      private long[] T001K17_A948PostulacionesSecUserId ;
      private long[] T001K17_A942ServiciosId ;
      private bool[] T001K17_n942ServiciosId ;
      private long[] T001K17_A945PostulacionesProveedorId ;
      private long[] T001K17_A970PostulacionesSolicitudesId ;
      private bool[] T001K17_n970PostulacionesSolicitudesId ;
      private string[] T001K18_A943ServiciosNombre ;
      private string[] T001K19_A969PostulacionesProveedorNombre ;
      private long[] T001K20_A422PostulacionesId ;
      private bool[] T001K20_n422PostulacionesId ;
      private long[] T001K11_A422PostulacionesId ;
      private bool[] T001K11_n422PostulacionesId ;
      private string[] T001K11_A971PostulacionesProvNombreAux ;
      private decimal[] T001K11_A946PostulacionesPrecio ;
      private short[] T001K11_A961PostulacionesMultimediaSerial ;
      private string[] T001K11_A936PostulacionesDescripcion ;
      private bool[] T001K11_A937PostulacionesReqSuministros ;
      private string[] T001K11_A938PostulacionesSuministrosDescri ;
      private DateTime[] T001K11_A947PostulacionesFechaTrabajo ;
      private DateTime[] T001K11_A939PostulacionesFechaCierre ;
      private string[] T001K11_A940PostulacionesHoraCierre ;
      private string[] T001K11_A941PostulacionesTipoFecha ;
      private string[] T001K11_A949PostulacionesRgoHoraservicio ;
      private string[] T001K11_A950PostulacionesApellidoNombre ;
      private string[] T001K11_A951PostulacionesMail ;
      private string[] T001K11_A952PostulacionesTelefono ;
      private long[] T001K11_A979PostulacionesDepartamentoId ;
      private long[] T001K11_A980PostulacionesDepartamentoMunic ;
      private long[] T001K11_A981PostulacionesZonasID ;
      private string[] T001K11_A998PostulacionesDireccion ;
      private DateTime[] T001K11_A425PostulacionesFechaAlta ;
      private string[] T001K11_A424PostulacionesEstado ;
      private long[] T001K11_A948PostulacionesSecUserId ;
      private long[] T001K11_A942ServiciosId ;
      private bool[] T001K11_n942ServiciosId ;
      private long[] T001K11_A945PostulacionesProveedorId ;
      private long[] T001K21_A422PostulacionesId ;
      private bool[] T001K21_n422PostulacionesId ;
      private long[] T001K22_A422PostulacionesId ;
      private bool[] T001K22_n422PostulacionesId ;
      private long[] T001K10_A422PostulacionesId ;
      private bool[] T001K10_n422PostulacionesId ;
      private string[] T001K10_A971PostulacionesProvNombreAux ;
      private decimal[] T001K10_A946PostulacionesPrecio ;
      private short[] T001K10_A961PostulacionesMultimediaSerial ;
      private string[] T001K10_A936PostulacionesDescripcion ;
      private bool[] T001K10_A937PostulacionesReqSuministros ;
      private string[] T001K10_A938PostulacionesSuministrosDescri ;
      private DateTime[] T001K10_A947PostulacionesFechaTrabajo ;
      private DateTime[] T001K10_A939PostulacionesFechaCierre ;
      private string[] T001K10_A940PostulacionesHoraCierre ;
      private string[] T001K10_A941PostulacionesTipoFecha ;
      private string[] T001K10_A949PostulacionesRgoHoraservicio ;
      private string[] T001K10_A950PostulacionesApellidoNombre ;
      private string[] T001K10_A951PostulacionesMail ;
      private string[] T001K10_A952PostulacionesTelefono ;
      private long[] T001K10_A979PostulacionesDepartamentoId ;
      private long[] T001K10_A980PostulacionesDepartamentoMunic ;
      private long[] T001K10_A981PostulacionesZonasID ;
      private string[] T001K10_A998PostulacionesDireccion ;
      private DateTime[] T001K10_A425PostulacionesFechaAlta ;
      private string[] T001K10_A424PostulacionesEstado ;
      private long[] T001K10_A948PostulacionesSecUserId ;
      private long[] T001K10_A942ServiciosId ;
      private bool[] T001K10_n942ServiciosId ;
      private long[] T001K10_A945PostulacionesProveedorId ;
      private long[] T001K23_A422PostulacionesId ;
      private bool[] T001K23_n422PostulacionesId ;
      private string[] T001K26_A943ServiciosNombre ;
      private string[] T001K27_A969PostulacionesProveedorNombre ;
      private long[] T001K28_A127SolicitudesID ;
      private long[] T001K30_A422PostulacionesId ;
      private bool[] T001K30_n422PostulacionesId ;
      private long[] T001K31_A942ServiciosId ;
      private bool[] T001K31_n942ServiciosId ;
      private long[] T001K31_A422PostulacionesId ;
      private bool[] T001K31_n422PostulacionesId ;
      private string[] T001K31_A944CategoriasNombre ;
      private long[] T001K31_A931CategoriasId ;
      private string[] T001K9_A944CategoriasNombre ;
      private string[] T001K32_A944CategoriasNombre ;
      private long[] T001K33_A422PostulacionesId ;
      private bool[] T001K33_n422PostulacionesId ;
      private long[] T001K33_A931CategoriasId ;
      private long[] T001K8_A422PostulacionesId ;
      private bool[] T001K8_n422PostulacionesId ;
      private long[] T001K8_A931CategoriasId ;
      private long[] T001K7_A422PostulacionesId ;
      private bool[] T001K7_n422PostulacionesId ;
      private long[] T001K7_A931CategoriasId ;
      private string[] T001K36_A944CategoriasNombre ;
      private long[] T001K37_A422PostulacionesId ;
      private bool[] T001K37_n422PostulacionesId ;
      private long[] T001K37_A931CategoriasId ;
      private long[] T001K38_A422PostulacionesId ;
      private bool[] T001K38_n422PostulacionesId ;
      private long[] T001K38_A932MultimediaId ;
      private string[] T001K38_A933MultimediaDireccion ;
      private string[] T001K38_A960MultimediaDescripcion ;
      private string[] T001K38_A934MultimediaTipo ;
      private long[] T001K39_A422PostulacionesId ;
      private bool[] T001K39_n422PostulacionesId ;
      private long[] T001K39_A932MultimediaId ;
      private long[] T001K6_A422PostulacionesId ;
      private bool[] T001K6_n422PostulacionesId ;
      private long[] T001K6_A932MultimediaId ;
      private string[] T001K6_A933MultimediaDireccion ;
      private string[] T001K6_A960MultimediaDescripcion ;
      private string[] T001K6_A934MultimediaTipo ;
      private long[] T001K5_A422PostulacionesId ;
      private bool[] T001K5_n422PostulacionesId ;
      private long[] T001K5_A932MultimediaId ;
      private string[] T001K5_A933MultimediaDireccion ;
      private string[] T001K5_A960MultimediaDescripcion ;
      private string[] T001K5_A934MultimediaTipo ;
      private long[] T001K43_A422PostulacionesId ;
      private bool[] T001K43_n422PostulacionesId ;
      private long[] T001K43_A932MultimediaId ;
      private long[] T001K44_A422PostulacionesId ;
      private bool[] T001K44_n422PostulacionesId ;
      private string[] T001K44_A956PostulacionProfesionalEstado ;
      private DateTime[] T001K44_A957PostulacionProfesionalFechaA ;
      private DateTime[] T001K44_A958PostulacionProfesionalFechaT ;
      private string[] T001K44_A959PostulacionProfesionalTurnoT ;
      private decimal[] T001K44_A982PostulacionProfesionalPrecio ;
      private bool[] T001K44_n982PostulacionProfesionalPrecio ;
      private short[] T001K44_A983PostulacionProfesionalPlazoE ;
      private bool[] T001K44_n983PostulacionProfesionalPlazoE ;
      private string[] T001K44_A986PostulacionProfesionalUniE ;
      private bool[] T001K44_n986PostulacionProfesionalUniE ;
      private short[] T001K44_A985PostulacionProfesionalGar ;
      private bool[] T001K44_n985PostulacionProfesionalGar ;
      private string[] T001K44_A987PostulacionProfesionalUniG ;
      private bool[] T001K44_n987PostulacionProfesionalUniG ;
      private string[] T001K44_A984PostulacionProfesionalA ;
      private bool[] T001K44_n984PostulacionProfesionalA ;
      private string[] T001K44_A167ProfesionalesApellidoPrimero ;
      private string[] T001K44_A166ProfesionalesPrimerNombre ;
      private string[] T001K44_A191ProfesionalesSegundoNombre ;
      private string[] T001K44_A120ProfesionalesId ;
      private string[] T001K4_A167ProfesionalesApellidoPrimero ;
      private string[] T001K4_A166ProfesionalesPrimerNombre ;
      private string[] T001K4_A191ProfesionalesSegundoNombre ;
      private string[] T001K45_A167ProfesionalesApellidoPrimero ;
      private string[] T001K45_A166ProfesionalesPrimerNombre ;
      private string[] T001K45_A191ProfesionalesSegundoNombre ;
      private long[] T001K46_A422PostulacionesId ;
      private bool[] T001K46_n422PostulacionesId ;
      private string[] T001K46_A120ProfesionalesId ;
      private long[] T001K3_A422PostulacionesId ;
      private bool[] T001K3_n422PostulacionesId ;
      private string[] T001K3_A956PostulacionProfesionalEstado ;
      private DateTime[] T001K3_A957PostulacionProfesionalFechaA ;
      private DateTime[] T001K3_A958PostulacionProfesionalFechaT ;
      private string[] T001K3_A959PostulacionProfesionalTurnoT ;
      private decimal[] T001K3_A982PostulacionProfesionalPrecio ;
      private bool[] T001K3_n982PostulacionProfesionalPrecio ;
      private short[] T001K3_A983PostulacionProfesionalPlazoE ;
      private bool[] T001K3_n983PostulacionProfesionalPlazoE ;
      private string[] T001K3_A986PostulacionProfesionalUniE ;
      private bool[] T001K3_n986PostulacionProfesionalUniE ;
      private short[] T001K3_A985PostulacionProfesionalGar ;
      private bool[] T001K3_n985PostulacionProfesionalGar ;
      private string[] T001K3_A987PostulacionProfesionalUniG ;
      private bool[] T001K3_n987PostulacionProfesionalUniG ;
      private string[] T001K3_A984PostulacionProfesionalA ;
      private bool[] T001K3_n984PostulacionProfesionalA ;
      private string[] T001K3_A120ProfesionalesId ;
      private long[] T001K2_A422PostulacionesId ;
      private bool[] T001K2_n422PostulacionesId ;
      private string[] T001K2_A956PostulacionProfesionalEstado ;
      private DateTime[] T001K2_A957PostulacionProfesionalFechaA ;
      private DateTime[] T001K2_A958PostulacionProfesionalFechaT ;
      private string[] T001K2_A959PostulacionProfesionalTurnoT ;
      private decimal[] T001K2_A982PostulacionProfesionalPrecio ;
      private bool[] T001K2_n982PostulacionProfesionalPrecio ;
      private short[] T001K2_A983PostulacionProfesionalPlazoE ;
      private bool[] T001K2_n983PostulacionProfesionalPlazoE ;
      private string[] T001K2_A986PostulacionProfesionalUniE ;
      private bool[] T001K2_n986PostulacionProfesionalUniE ;
      private short[] T001K2_A985PostulacionProfesionalGar ;
      private bool[] T001K2_n985PostulacionProfesionalGar ;
      private string[] T001K2_A987PostulacionProfesionalUniG ;
      private bool[] T001K2_n987PostulacionProfesionalUniG ;
      private string[] T001K2_A984PostulacionProfesionalA ;
      private bool[] T001K2_n984PostulacionProfesionalA ;
      private string[] T001K2_A120ProfesionalesId ;
      private string[] T001K50_A167ProfesionalesApellidoPrimero ;
      private string[] T001K50_A166ProfesionalesPrimerNombre ;
      private string[] T001K50_A191ProfesionalesSegundoNombre ;
      private long[] T001K51_A422PostulacionesId ;
      private bool[] T001K51_n422PostulacionesId ;
      private string[] T001K51_A120ProfesionalesId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class postulaciones__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class postulaciones__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new UpdateCursor(def[30])
       ,new UpdateCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new UpdateCursor(def[36])
       ,new UpdateCursor(def[37])
       ,new UpdateCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new ForEachCursor(def[42])
       ,new UpdateCursor(def[43])
       ,new UpdateCursor(def[44])
       ,new UpdateCursor(def[45])
       ,new ForEachCursor(def[46])
       ,new ForEachCursor(def[47])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001K2;
        prmT001K2 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001K3;
        prmT001K3 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001K4;
        prmT001K4 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001K5;
        prmT001K5 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MultimediaId",GXType.Decimal,18,0)
        };
        Object[] prmT001K6;
        prmT001K6 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MultimediaId",GXType.Decimal,18,0)
        };
        Object[] prmT001K7;
        prmT001K7 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmT001K8;
        prmT001K8 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmT001K9;
        prmT001K9 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmT001K10;
        prmT001K10 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K11;
        prmT001K11 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K14;
        prmT001K14 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K15;
        prmT001K15 = new Object[] {
        new ParDef("@PostulacionesProveedorId",GXType.Decimal,18,0)
        };
        Object[] prmT001K13;
        prmT001K13 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K17;
        prmT001K17 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K18;
        prmT001K18 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K19;
        prmT001K19 = new Object[] {
        new ParDef("@PostulacionesProveedorId",GXType.Decimal,18,0)
        };
        Object[] prmT001K20;
        prmT001K20 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K21;
        prmT001K21 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K22;
        prmT001K22 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K23;
        prmT001K23 = new Object[] {
        new ParDef("@PostulacionesProvNombreAux",GXType.NChar,80,0) ,
        new ParDef("@PostulacionesPrecio",GXType.Decimal,18,2) ,
        new ParDef("@PostulacionesMultimediaSerial",GXType.Int16,4,0) ,
        new ParDef("@PostulacionesDescripcion",GXType.NChar,2000,0) ,
        new ParDef("@PostulacionesReqSuministros",GXType.Boolean,4,0) ,
        new ParDef("@PostulacionesSuministrosDescri",GXType.NChar,250,0) ,
        new ParDef("@PostulacionesFechaTrabajo",GXType.Date,8,0) ,
        new ParDef("@PostulacionesFechaCierre",GXType.Date,8,0) ,
        new ParDef("@PostulacionesHoraCierre",GXType.NVarChar,8,5) ,
        new ParDef("@PostulacionesTipoFecha",GXType.NVarChar,10,0) ,
        new ParDef("@PostulacionesRgoHoraservicio",GXType.NChar,5,0) ,
        new ParDef("@PostulacionesApellidoNombre",GXType.NChar,80,0) ,
        new ParDef("@PostulacionesMail",GXType.NVarChar,100,0) ,
        new ParDef("@PostulacionesTelefono",GXType.NChar,20,0) ,
        new ParDef("@PostulacionesDepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@PostulacionesDepartamentoMunic",GXType.Decimal,18,0) ,
        new ParDef("@PostulacionesZonasID",GXType.Decimal,18,0) ,
        new ParDef("@PostulacionesDireccion",GXType.NChar,100,0) ,
        new ParDef("@PostulacionesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@PostulacionesEstado",GXType.NChar,3,0) ,
        new ParDef("@PostulacionesSecUserId",GXType.Decimal,18,0) ,
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@PostulacionesProveedorId",GXType.Decimal,18,0)
        };
        Object[] prmT001K24;
        prmT001K24 = new Object[] {
        new ParDef("@PostulacionesProvNombreAux",GXType.NChar,80,0) ,
        new ParDef("@PostulacionesPrecio",GXType.Decimal,18,2) ,
        new ParDef("@PostulacionesMultimediaSerial",GXType.Int16,4,0) ,
        new ParDef("@PostulacionesDescripcion",GXType.NChar,2000,0) ,
        new ParDef("@PostulacionesReqSuministros",GXType.Boolean,4,0) ,
        new ParDef("@PostulacionesSuministrosDescri",GXType.NChar,250,0) ,
        new ParDef("@PostulacionesFechaTrabajo",GXType.Date,8,0) ,
        new ParDef("@PostulacionesFechaCierre",GXType.Date,8,0) ,
        new ParDef("@PostulacionesHoraCierre",GXType.NVarChar,8,5) ,
        new ParDef("@PostulacionesTipoFecha",GXType.NVarChar,10,0) ,
        new ParDef("@PostulacionesRgoHoraservicio",GXType.NChar,5,0) ,
        new ParDef("@PostulacionesApellidoNombre",GXType.NChar,80,0) ,
        new ParDef("@PostulacionesMail",GXType.NVarChar,100,0) ,
        new ParDef("@PostulacionesTelefono",GXType.NChar,20,0) ,
        new ParDef("@PostulacionesDepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@PostulacionesDepartamentoMunic",GXType.Decimal,18,0) ,
        new ParDef("@PostulacionesZonasID",GXType.Decimal,18,0) ,
        new ParDef("@PostulacionesDireccion",GXType.NChar,100,0) ,
        new ParDef("@PostulacionesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@PostulacionesEstado",GXType.NChar,3,0) ,
        new ParDef("@PostulacionesSecUserId",GXType.Decimal,18,0) ,
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@PostulacionesProveedorId",GXType.Decimal,18,0) ,
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K25;
        prmT001K25 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K26;
        prmT001K26 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K27;
        prmT001K27 = new Object[] {
        new ParDef("@PostulacionesProveedorId",GXType.Decimal,18,0)
        };
        Object[] prmT001K28;
        prmT001K28 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K29;
        prmT001K29 = new Object[] {
        new ParDef("@PostulacionesMultimediaSerial",GXType.Int16,4,0) ,
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K30;
        prmT001K30 = new Object[] {
        };
        Object[] prmT001K31;
        prmT001K31 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmT001K32;
        prmT001K32 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmT001K33;
        prmT001K33 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmT001K34;
        prmT001K34 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmT001K35;
        prmT001K35 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmT001K36;
        prmT001K36 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmT001K37;
        prmT001K37 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K38;
        prmT001K38 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MultimediaId",GXType.Decimal,18,0)
        };
        Object[] prmT001K39;
        prmT001K39 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MultimediaId",GXType.Decimal,18,0)
        };
        Object[] prmT001K40;
        prmT001K40 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MultimediaId",GXType.Decimal,18,0) ,
        new ParDef("@MultimediaDireccion",GXType.NChar,100,0) ,
        new ParDef("@MultimediaDescripcion",GXType.NChar,250,0) ,
        new ParDef("@MultimediaTipo",GXType.NVarChar,40,0)
        };
        Object[] prmT001K41;
        prmT001K41 = new Object[] {
        new ParDef("@MultimediaDireccion",GXType.NChar,100,0) ,
        new ParDef("@MultimediaDescripcion",GXType.NChar,250,0) ,
        new ParDef("@MultimediaTipo",GXType.NVarChar,40,0) ,
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MultimediaId",GXType.Decimal,18,0)
        };
        Object[] prmT001K42;
        prmT001K42 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MultimediaId",GXType.Decimal,18,0)
        };
        Object[] prmT001K43;
        prmT001K43 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001K44;
        prmT001K44 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001K45;
        prmT001K45 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001K46;
        prmT001K46 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001K47;
        prmT001K47 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalEstado",GXType.NChar,3,0) ,
        new ParDef("@PostulacionProfesionalFechaA",GXType.DateTime,8,5) ,
        new ParDef("@PostulacionProfesionalFechaT",GXType.Date,8,0) ,
        new ParDef("@PostulacionProfesionalTurnoT",GXType.NChar,1,0) ,
        new ParDef("@PostulacionProfesionalPrecio",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@PostulacionProfesionalPlazoE",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalUniE",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalGar",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalUniG",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalA",GXType.NVarChar,500,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001K48;
        prmT001K48 = new Object[] {
        new ParDef("@PostulacionProfesionalEstado",GXType.NChar,3,0) ,
        new ParDef("@PostulacionProfesionalFechaA",GXType.DateTime,8,5) ,
        new ParDef("@PostulacionProfesionalFechaT",GXType.Date,8,0) ,
        new ParDef("@PostulacionProfesionalTurnoT",GXType.NChar,1,0) ,
        new ParDef("@PostulacionProfesionalPrecio",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@PostulacionProfesionalPlazoE",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalUniE",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalGar",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalUniG",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalA",GXType.NVarChar,500,0){Nullable=true} ,
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001K49;
        prmT001K49 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001K50;
        prmT001K50 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001K51;
        prmT001K51 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T001K2", "SELECT [PostulacionesId], [PostulacionProfesionalEstado], [PostulacionProfesionalFechaA], [PostulacionProfesionalFechaT], [PostulacionProfesionalTurnoT], [PostulacionProfesionalPrecio], [PostulacionProfesionalPlazoE], [PostulacionProfesionalUniE], [PostulacionProfesionalGar], [PostulacionProfesionalUniG], [PostulacionProfesionalA], [ProfesionalesId] FROM [PostulacionesProfesionales] WITH (UPDLOCK) WHERE [PostulacionesId] = @PostulacionesId AND [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K3", "SELECT [PostulacionesId], [PostulacionProfesionalEstado], [PostulacionProfesionalFechaA], [PostulacionProfesionalFechaT], [PostulacionProfesionalTurnoT], [PostulacionProfesionalPrecio], [PostulacionProfesionalPlazoE], [PostulacionProfesionalUniE], [PostulacionProfesionalGar], [PostulacionProfesionalUniG], [PostulacionProfesionalA], [ProfesionalesId] FROM [PostulacionesProfesionales] WHERE [PostulacionesId] = @PostulacionesId AND [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K4", "SELECT [ProfesionalesApellidoPrimero], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K5", "SELECT [PostulacionesId], [MultimediaId], [MultimediaDireccion], [MultimediaDescripcion], [MultimediaTipo] FROM [PostulacionesMultimedia] WITH (UPDLOCK) WHERE [PostulacionesId] = @PostulacionesId AND [MultimediaId] = @MultimediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K6", "SELECT [PostulacionesId], [MultimediaId], [MultimediaDireccion], [MultimediaDescripcion], [MultimediaTipo] FROM [PostulacionesMultimedia] WHERE [PostulacionesId] = @PostulacionesId AND [MultimediaId] = @MultimediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K7", "SELECT [PostulacionesId], [CategoriasId] FROM [PostulacionesCategorias] WITH (UPDLOCK) WHERE [PostulacionesId] = @PostulacionesId AND [CategoriasId] = @CategoriasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K8", "SELECT [PostulacionesId], [CategoriasId] FROM [PostulacionesCategorias] WHERE [PostulacionesId] = @PostulacionesId AND [CategoriasId] = @CategoriasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K9", "SELECT [CategoriasNombre] FROM [ServiciosCategorias] WHERE [ServiciosId] = @ServiciosId AND [CategoriasId] = @CategoriasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K10", "SELECT [PostulacionesId], [PostulacionesProvNombreAux], [PostulacionesPrecio], [PostulacionesMultimediaSerial], [PostulacionesDescripcion], [PostulacionesReqSuministros], [PostulacionesSuministrosDescri], [PostulacionesFechaTrabajo], [PostulacionesFechaCierre], [PostulacionesHoraCierre], [PostulacionesTipoFecha], [PostulacionesRgoHoraservicio], [PostulacionesApellidoNombre], [PostulacionesMail], [PostulacionesTelefono], [PostulacionesDepartamentoId], [PostulacionesDepartamentoMunic], [PostulacionesZonasID], [PostulacionesDireccion], [PostulacionesFechaAlta], [PostulacionesEstado], [PostulacionesSecUserId], [ServiciosId], [PostulacionesProveedorId] AS PostulacionesProveedorId FROM [Postulaciones] WITH (UPDLOCK) WHERE [PostulacionesId] = @PostulacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K11", "SELECT [PostulacionesId], [PostulacionesProvNombreAux], [PostulacionesPrecio], [PostulacionesMultimediaSerial], [PostulacionesDescripcion], [PostulacionesReqSuministros], [PostulacionesSuministrosDescri], [PostulacionesFechaTrabajo], [PostulacionesFechaCierre], [PostulacionesHoraCierre], [PostulacionesTipoFecha], [PostulacionesRgoHoraservicio], [PostulacionesApellidoNombre], [PostulacionesMail], [PostulacionesTelefono], [PostulacionesDepartamentoId], [PostulacionesDepartamentoMunic], [PostulacionesZonasID], [PostulacionesDireccion], [PostulacionesFechaAlta], [PostulacionesEstado], [PostulacionesSecUserId], [ServiciosId], [PostulacionesProveedorId] AS PostulacionesProveedorId FROM [Postulaciones] WHERE [PostulacionesId] = @PostulacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K13", "SELECT COALESCE( T1.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K14", "SELECT [ServiciosNombre] FROM [Servicios] WHERE [ServiciosId] = @ServiciosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K15", "SELECT [ProveedorNombre] AS PostulacionesProveedorNombre FROM [Proveedor] WHERE [ProveedorID] = @PostulacionesProveedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K17", "SELECT TM1.[PostulacionesId], T3.[ServiciosNombre], TM1.[PostulacionesProvNombreAux], T4.[ProveedorNombre] AS PostulacionesProveedorNombre, TM1.[PostulacionesPrecio], TM1.[PostulacionesMultimediaSerial], TM1.[PostulacionesDescripcion], TM1.[PostulacionesReqSuministros], TM1.[PostulacionesSuministrosDescri], TM1.[PostulacionesFechaTrabajo], TM1.[PostulacionesFechaCierre], TM1.[PostulacionesHoraCierre], TM1.[PostulacionesTipoFecha], TM1.[PostulacionesRgoHoraservicio], TM1.[PostulacionesApellidoNombre], TM1.[PostulacionesMail], TM1.[PostulacionesTelefono], TM1.[PostulacionesDepartamentoId], TM1.[PostulacionesDepartamentoMunic], TM1.[PostulacionesZonasID], TM1.[PostulacionesDireccion], TM1.[PostulacionesFechaAlta], TM1.[PostulacionesEstado], TM1.[PostulacionesSecUserId], TM1.[ServiciosId], TM1.[PostulacionesProveedorId] AS PostulacionesProveedorId, COALESCE( T2.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] TM1 LEFT JOIN [Servicios] T3 ON T3.[ServiciosId] = TM1.[ServiciosId]) INNER JOIN [Proveedor] T4 ON T4.[ProveedorID] = TM1.[PostulacionesProveedorId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T2 WHERE TM1.[PostulacionesId] = @PostulacionesId ORDER BY TM1.[PostulacionesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001K17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K18", "SELECT [ServiciosNombre] FROM [Servicios] WHERE [ServiciosId] = @ServiciosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K19", "SELECT [ProveedorNombre] AS PostulacionesProveedorNombre FROM [Proveedor] WHERE [ProveedorID] = @PostulacionesProveedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K20", "SELECT [PostulacionesId] FROM [Postulaciones] WHERE [PostulacionesId] = @PostulacionesId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001K20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K21", "SELECT TOP 1 [PostulacionesId] FROM [Postulaciones] WHERE ( [PostulacionesId] > @PostulacionesId) ORDER BY [PostulacionesId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001K21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001K22", "SELECT TOP 1 [PostulacionesId] FROM [Postulaciones] WHERE ( [PostulacionesId] < @PostulacionesId) ORDER BY [PostulacionesId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001K22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001K23", "INSERT INTO [Postulaciones]([PostulacionesProvNombreAux], [PostulacionesPrecio], [PostulacionesMultimediaSerial], [PostulacionesDescripcion], [PostulacionesReqSuministros], [PostulacionesSuministrosDescri], [PostulacionesFechaTrabajo], [PostulacionesFechaCierre], [PostulacionesHoraCierre], [PostulacionesTipoFecha], [PostulacionesRgoHoraservicio], [PostulacionesApellidoNombre], [PostulacionesMail], [PostulacionesTelefono], [PostulacionesDepartamentoId], [PostulacionesDepartamentoMunic], [PostulacionesZonasID], [PostulacionesDireccion], [PostulacionesFechaAlta], [PostulacionesEstado], [PostulacionesSecUserId], [ServiciosId], [PostulacionesProveedorId]) VALUES(@PostulacionesProvNombreAux, @PostulacionesPrecio, @PostulacionesMultimediaSerial, @PostulacionesDescripcion, @PostulacionesReqSuministros, @PostulacionesSuministrosDescri, @PostulacionesFechaTrabajo, @PostulacionesFechaCierre, @PostulacionesHoraCierre, @PostulacionesTipoFecha, @PostulacionesRgoHoraservicio, @PostulacionesApellidoNombre, @PostulacionesMail, @PostulacionesTelefono, @PostulacionesDepartamentoId, @PostulacionesDepartamentoMunic, @PostulacionesZonasID, @PostulacionesDireccion, @PostulacionesFechaAlta, @PostulacionesEstado, @PostulacionesSecUserId, @ServiciosId, @PostulacionesProveedorId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001K23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001K24", "UPDATE [Postulaciones] SET [PostulacionesProvNombreAux]=@PostulacionesProvNombreAux, [PostulacionesPrecio]=@PostulacionesPrecio, [PostulacionesMultimediaSerial]=@PostulacionesMultimediaSerial, [PostulacionesDescripcion]=@PostulacionesDescripcion, [PostulacionesReqSuministros]=@PostulacionesReqSuministros, [PostulacionesSuministrosDescri]=@PostulacionesSuministrosDescri, [PostulacionesFechaTrabajo]=@PostulacionesFechaTrabajo, [PostulacionesFechaCierre]=@PostulacionesFechaCierre, [PostulacionesHoraCierre]=@PostulacionesHoraCierre, [PostulacionesTipoFecha]=@PostulacionesTipoFecha, [PostulacionesRgoHoraservicio]=@PostulacionesRgoHoraservicio, [PostulacionesApellidoNombre]=@PostulacionesApellidoNombre, [PostulacionesMail]=@PostulacionesMail, [PostulacionesTelefono]=@PostulacionesTelefono, [PostulacionesDepartamentoId]=@PostulacionesDepartamentoId, [PostulacionesDepartamentoMunic]=@PostulacionesDepartamentoMunic, [PostulacionesZonasID]=@PostulacionesZonasID, [PostulacionesDireccion]=@PostulacionesDireccion, [PostulacionesFechaAlta]=@PostulacionesFechaAlta, [PostulacionesEstado]=@PostulacionesEstado, [PostulacionesSecUserId]=@PostulacionesSecUserId, [ServiciosId]=@ServiciosId, [PostulacionesProveedorId]=@PostulacionesProveedorId  WHERE [PostulacionesId] = @PostulacionesId", GxErrorMask.GX_NOMASK,prmT001K24)
           ,new CursorDef("T001K25", "DELETE FROM [Postulaciones]  WHERE [PostulacionesId] = @PostulacionesId", GxErrorMask.GX_NOMASK,prmT001K25)
           ,new CursorDef("T001K26", "SELECT [ServiciosNombre] FROM [Servicios] WHERE [ServiciosId] = @ServiciosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K27", "SELECT [ProveedorNombre] AS PostulacionesProveedorNombre FROM [Proveedor] WHERE [ProveedorID] = @PostulacionesProveedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K28", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001K29", "UPDATE [Postulaciones] SET [PostulacionesMultimediaSerial]=@PostulacionesMultimediaSerial  WHERE [PostulacionesId] = @PostulacionesId", GxErrorMask.GX_NOMASK,prmT001K29)
           ,new CursorDef("T001K30", "SELECT [PostulacionesId] FROM [Postulaciones] ORDER BY [PostulacionesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001K30,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K31", "SELECT T2.[ServiciosId], T1.[PostulacionesId], T2.[CategoriasNombre], T1.[CategoriasId] FROM ([PostulacionesCategorias] T1 LEFT JOIN [ServiciosCategorias] T2 ON T2.[ServiciosId] = @ServiciosId AND T2.[CategoriasId] = T1.[CategoriasId]) WHERE T1.[PostulacionesId] = @PostulacionesId and T1.[CategoriasId] = @CategoriasId ORDER BY T1.[PostulacionesId], T1.[CategoriasId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K31,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K32", "SELECT [CategoriasNombre] FROM [ServiciosCategorias] WHERE [ServiciosId] = @ServiciosId AND [CategoriasId] = @CategoriasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K32,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K33", "SELECT [PostulacionesId], [CategoriasId] FROM [PostulacionesCategorias] WHERE [PostulacionesId] = @PostulacionesId AND [CategoriasId] = @CategoriasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K33,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K34", "INSERT INTO [PostulacionesCategorias]([PostulacionesId], [CategoriasId]) VALUES(@PostulacionesId, @CategoriasId)", GxErrorMask.GX_NOMASK,prmT001K34)
           ,new CursorDef("T001K35", "DELETE FROM [PostulacionesCategorias]  WHERE [PostulacionesId] = @PostulacionesId AND [CategoriasId] = @CategoriasId", GxErrorMask.GX_NOMASK,prmT001K35)
           ,new CursorDef("T001K36", "SELECT [CategoriasNombre] FROM [ServiciosCategorias] WHERE [ServiciosId] = @ServiciosId AND [CategoriasId] = @CategoriasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K36,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K37", "SELECT [PostulacionesId], [CategoriasId] FROM [PostulacionesCategorias] WHERE [PostulacionesId] = @PostulacionesId ORDER BY [PostulacionesId], [CategoriasId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K37,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K38", "SELECT [PostulacionesId], [MultimediaId], [MultimediaDireccion], [MultimediaDescripcion], [MultimediaTipo] FROM [PostulacionesMultimedia] WHERE [PostulacionesId] = @PostulacionesId and [MultimediaId] = @MultimediaId ORDER BY [PostulacionesId], [MultimediaId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K38,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K39", "SELECT [PostulacionesId], [MultimediaId] FROM [PostulacionesMultimedia] WHERE [PostulacionesId] = @PostulacionesId AND [MultimediaId] = @MultimediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K39,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K40", "INSERT INTO [PostulacionesMultimedia]([PostulacionesId], [MultimediaId], [MultimediaDireccion], [MultimediaDescripcion], [MultimediaTipo]) VALUES(@PostulacionesId, @MultimediaId, @MultimediaDireccion, @MultimediaDescripcion, @MultimediaTipo)", GxErrorMask.GX_NOMASK,prmT001K40)
           ,new CursorDef("T001K41", "UPDATE [PostulacionesMultimedia] SET [MultimediaDireccion]=@MultimediaDireccion, [MultimediaDescripcion]=@MultimediaDescripcion, [MultimediaTipo]=@MultimediaTipo  WHERE [PostulacionesId] = @PostulacionesId AND [MultimediaId] = @MultimediaId", GxErrorMask.GX_NOMASK,prmT001K41)
           ,new CursorDef("T001K42", "DELETE FROM [PostulacionesMultimedia]  WHERE [PostulacionesId] = @PostulacionesId AND [MultimediaId] = @MultimediaId", GxErrorMask.GX_NOMASK,prmT001K42)
           ,new CursorDef("T001K43", "SELECT [PostulacionesId], [MultimediaId] FROM [PostulacionesMultimedia] WHERE [PostulacionesId] = @PostulacionesId ORDER BY [PostulacionesId], [MultimediaId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K43,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K44", "SELECT T1.[PostulacionesId], T1.[PostulacionProfesionalEstado], T1.[PostulacionProfesionalFechaA], T1.[PostulacionProfesionalFechaT], T1.[PostulacionProfesionalTurnoT], T1.[PostulacionProfesionalPrecio], T1.[PostulacionProfesionalPlazoE], T1.[PostulacionProfesionalUniE], T1.[PostulacionProfesionalGar], T1.[PostulacionProfesionalUniG], T1.[PostulacionProfesionalA], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesSegundoNombre], T1.[ProfesionalesId] FROM ([PostulacionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) WHERE T1.[PostulacionesId] = @PostulacionesId and T1.[ProfesionalesId] = @ProfesionalesId ORDER BY T1.[PostulacionesId], T1.[ProfesionalesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K44,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K45", "SELECT [ProfesionalesApellidoPrimero], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K45,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K46", "SELECT [PostulacionesId], [ProfesionalesId] FROM [PostulacionesProfesionales] WHERE [PostulacionesId] = @PostulacionesId AND [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K46,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K47", "INSERT INTO [PostulacionesProfesionales]([PostulacionesId], [PostulacionProfesionalEstado], [PostulacionProfesionalFechaA], [PostulacionProfesionalFechaT], [PostulacionProfesionalTurnoT], [PostulacionProfesionalPrecio], [PostulacionProfesionalPlazoE], [PostulacionProfesionalUniE], [PostulacionProfesionalGar], [PostulacionProfesionalUniG], [PostulacionProfesionalA], [ProfesionalesId]) VALUES(@PostulacionesId, @PostulacionProfesionalEstado, @PostulacionProfesionalFechaA, @PostulacionProfesionalFechaT, @PostulacionProfesionalTurnoT, @PostulacionProfesionalPrecio, @PostulacionProfesionalPlazoE, @PostulacionProfesionalUniE, @PostulacionProfesionalGar, @PostulacionProfesionalUniG, @PostulacionProfesionalA, @ProfesionalesId)", GxErrorMask.GX_NOMASK,prmT001K47)
           ,new CursorDef("T001K48", "UPDATE [PostulacionesProfesionales] SET [PostulacionProfesionalEstado]=@PostulacionProfesionalEstado, [PostulacionProfesionalFechaA]=@PostulacionProfesionalFechaA, [PostulacionProfesionalFechaT]=@PostulacionProfesionalFechaT, [PostulacionProfesionalTurnoT]=@PostulacionProfesionalTurnoT, [PostulacionProfesionalPrecio]=@PostulacionProfesionalPrecio, [PostulacionProfesionalPlazoE]=@PostulacionProfesionalPlazoE, [PostulacionProfesionalUniE]=@PostulacionProfesionalUniE, [PostulacionProfesionalGar]=@PostulacionProfesionalGar, [PostulacionProfesionalUniG]=@PostulacionProfesionalUniG, [PostulacionProfesionalA]=@PostulacionProfesionalA  WHERE [PostulacionesId] = @PostulacionesId AND [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT001K48)
           ,new CursorDef("T001K49", "DELETE FROM [PostulacionesProfesionales]  WHERE [PostulacionesId] = @PostulacionesId AND [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT001K49)
           ,new CursorDef("T001K50", "SELECT [ProfesionalesApellidoPrimero], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K50,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K51", "SELECT [PostulacionesId], [ProfesionalesId] FROM [PostulacionesProfesionales] WHERE [PostulacionesId] = @PostulacionesId ORDER BY [PostulacionesId], [ProfesionalesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K51,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 1);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getString(10, 1);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getString(12, 20);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 1);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getString(10, 1);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getString(12, 20);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 250);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 250);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 2000);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 250);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 5);
              ((string[]) buf[12])[0] = rslt.getString(13, 80);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((long[]) buf[15])[0] = rslt.getLong(16);
              ((long[]) buf[16])[0] = rslt.getLong(17);
              ((long[]) buf[17])[0] = rslt.getLong(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 100);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(20);
              ((string[]) buf[20])[0] = rslt.getString(21, 3);
              ((long[]) buf[21])[0] = rslt.getLong(22);
              ((long[]) buf[22])[0] = rslt.getLong(23);
              ((bool[]) buf[23])[0] = rslt.wasNull(23);
              ((long[]) buf[24])[0] = rslt.getLong(24);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 2000);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 250);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 5);
              ((string[]) buf[12])[0] = rslt.getString(13, 80);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((long[]) buf[15])[0] = rslt.getLong(16);
              ((long[]) buf[16])[0] = rslt.getLong(17);
              ((long[]) buf[17])[0] = rslt.getLong(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 100);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(20);
              ((string[]) buf[20])[0] = rslt.getString(21, 3);
              ((long[]) buf[21])[0] = rslt.getLong(22);
              ((long[]) buf[22])[0] = rslt.getLong(23);
              ((bool[]) buf[23])[0] = rslt.wasNull(23);
              ((long[]) buf[24])[0] = rslt.getLong(24);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 2000);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 250);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 5);
              ((string[]) buf[14])[0] = rslt.getString(15, 80);
              ((string[]) buf[15])[0] = rslt.getVarchar(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 20);
              ((long[]) buf[17])[0] = rslt.getLong(18);
              ((long[]) buf[18])[0] = rslt.getLong(19);
              ((long[]) buf[19])[0] = rslt.getLong(20);
              ((string[]) buf[20])[0] = rslt.getString(21, 100);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(22);
              ((string[]) buf[22])[0] = rslt.getString(23, 3);
              ((long[]) buf[23])[0] = rslt.getLong(24);
              ((long[]) buf[24])[0] = rslt.getLong(25);
              ((bool[]) buf[25])[0] = rslt.wasNull(25);
              ((long[]) buf[26])[0] = rslt.getLong(26);
              ((long[]) buf[27])[0] = rslt.getLong(27);
              ((bool[]) buf[28])[0] = rslt.wasNull(27);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
           case 28 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 33 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 34 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 250);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 35 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 39 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 40 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 1);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getString(10, 1);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getString(12, 30);
              ((string[]) buf[18])[0] = rslt.getString(13, 30);
              ((string[]) buf[19])[0] = rslt.getString(14, 30);
              ((string[]) buf[20])[0] = rslt.getString(15, 20);
              return;
           case 41 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              return;
           case 42 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 46 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              return;
           case 47 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
     }
  }

}

}
