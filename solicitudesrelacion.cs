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
   public class solicitudesrelacion : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action26") == 0 )
         {
            A120ProfesionalesId = GetPar( "ProfesionalesId");
            AV21SolicitudServicioOrigenPago = GetPar( "SolicitudServicioOrigenPago");
            AssignAttri("", false, "AV21SolicitudServicioOrigenPago", AV21SolicitudServicioOrigenPago);
            AV15RoleName = GetPar( "RoleName");
            AssignAttri("", false, "AV15RoleName", AV15RoleName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_26_0Q32( A120ProfesionalesId, AV21SolicitudServicioOrigenPago, AV15RoleName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action27") == 0 )
         {
            A120ProfesionalesId = GetPar( "ProfesionalesId");
            AV21SolicitudServicioOrigenPago = GetPar( "SolicitudServicioOrigenPago");
            AssignAttri("", false, "AV21SolicitudServicioOrigenPago", AV21SolicitudServicioOrigenPago);
            AV15RoleName = GetPar( "RoleName");
            AssignAttri("", false, "AV15RoleName", AV15RoleName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_27_0Q32( A120ProfesionalesId, AV21SolicitudServicioOrigenPago, AV15RoleName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"ESTADOSGID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAESTADOSGID0Q32( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_32") == 0 )
         {
            A133ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_32( A133ProveedorID) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_35") == 0 )
         {
            A141EstadoSGTipo = GetPar( "EstadoSGTipo");
            A142EstadoSGId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadoSGId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_35( A141EstadoSGTipo, A142EstadoSGId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_relaciones") == 0 )
         {
            gxnrGridlevel_relaciones_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "solicitudesrelacion.aspx")), "solicitudesrelacion.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "solicitudesrelacion.aspx")))) ;
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
                  AV7SolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "SolicitudesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7SolicitudesID", StringUtil.LTrimStr( (decimal)(AV7SolicitudesID), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Solicitudes Relacion", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_relaciones_newrow_invoke( )
      {
         nRC_GXsfl_38 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_38"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_38_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_38_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_38_idx = GetPar( "sGXsfl_38_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         AV25Admin = GetPar( "Admin");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_relaciones_newrow( ) ;
         /* End function gxnrGridlevel_relaciones_newrow_invoke */
      }

      public solicitudesrelacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public solicitudesrelacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_SolicitudesID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SolicitudesID = aP1_SolicitudesID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynEstadoSGId = new GXCombobox();
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesID_Internalname, context.GetMessage( "Solicitud No:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesID_Enabled!=0) ? context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesRelacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesNombre_Internalname, context.GetMessage( "Nombre de la Persona/Contacto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesNombre_Internalname, StringUtil.RTrim( A171SolicitudesNombre), StringUtil.RTrim( context.localUtil.Format( A171SolicitudesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesRelacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAdmin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtavAdmin_Internalname, context.GetMessage( "¿Admin?", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavAdmin_Internalname, AV25Admin, StringUtil.RTrim( context.localUtil.Format( AV25Admin, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAdmin_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAdmin_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesRelacion.htm");
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
         GxWebStd.gx_div_start( context, divTableleaflevel_relaciones_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_relaciones( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SolicitudesRelacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SolicitudesRelacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SolicitudesRelacion.htm");
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

      protected void gxdraw_Gridlevel_relaciones( )
      {
         /*  Grid Control  */
         StartGridControl38( ) ;
         nGXsfl_38_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount32 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_32 = 1;
               ScanStart0Q32( ) ;
               while ( RcdFound32 != 0 )
               {
                  init_level_properties32( ) ;
                  getByPrimaryKey0Q32( ) ;
                  AddRow0Q32( ) ;
                  ScanNext0Q32( ) ;
               }
               ScanEnd0Q32( ) ;
               nBlankRcdCount32 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0Q32( ) ;
            standaloneModal0Q32( ) ;
            sMode32 = Gx_mode;
            while ( nGXsfl_38_idx < nRC_GXsfl_38 )
            {
               bGXsfl_38_Refreshing = true;
               ReadRow0Q32( ) ;
               edtRelacionesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RELACIONESID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtRelacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelacionesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtProfesionalesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtProfesionalesPrimerNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesPrimerNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtProfesionalesApellidoPrimero_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesApellidoPrimero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtEstadoSGTipo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGTIPO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtEstadoSGTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoSGTipo_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               dynEstadoSGId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynEstadoSGId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadoSGId.Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtSolicitudesRelacionesFechaAlta_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SOLICITUDESRELACIONESFECHAALTA_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSolicitudesRelacionesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesRelacionesFechaAlta_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtSolicitudesRelacionesFechaModi_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SOLICITUDESRELACIONESFECHAMODI_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSolicitudesRelacionesFechaModi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesRelacionesFechaModi_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               imgprompt_120_Link = cgiGet( "PROMPT_120_"+sGXsfl_38_idx+"Link");
               imgprompt_120_Link = cgiGet( "PROMPT_142_"+sGXsfl_38_idx+"Link");
               if ( ( nRcdExists_32 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0Q32( ) ;
               }
               SendRow0Q32( ) ;
               bGXsfl_38_Refreshing = false;
            }
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount32 = 5;
            nRcdExists_32 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0Q32( ) ;
               while ( RcdFound32 != 0 )
               {
                  sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_3832( ) ;
                  init_level_properties32( ) ;
                  standaloneNotModal0Q32( ) ;
                  getByPrimaryKey0Q32( ) ;
                  standaloneModal0Q32( ) ;
                  AddRow0Q32( ) ;
                  ScanNext0Q32( ) ;
               }
               ScanEnd0Q32( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode32 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx+1), 4, 0), 4, "0");
            SubsflControlProps_3832( ) ;
            InitAll0Q32( ) ;
            init_level_properties32( ) ;
            nRcdExists_32 = 0;
            nIsMod_32 = 0;
            nRcdDeleted_32 = 0;
            nBlankRcdCount32 = (short)(nBlankRcdUsr32+nBlankRcdCount32);
            fRowAdded = 0;
            while ( nBlankRcdCount32 > 0 )
            {
               standaloneNotModal0Q32( ) ;
               standaloneModal0Q32( ) ;
               AddRow0Q32( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtRelacionesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount32 = (short)(nBlankRcdCount32-1);
            }
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_relacionesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_relaciones", Gridlevel_relacionesContainer, subGridlevel_relaciones_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_relacionesContainerData", Gridlevel_relacionesContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_relacionesContainerData"+"V", Gridlevel_relacionesContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_relacionesContainerData"+"V"+"\" value='"+Gridlevel_relacionesContainer.GridValuesHidden()+"'/>") ;
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
         E110Q2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z127SolicitudesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z171SolicitudesNombre = cgiGet( "Z171SolicitudesNombre");
               Z688SolicitudesLiqProf = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z688SolicitudesLiqProf"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n688SolicitudesLiqProf = ((0==A688SolicitudesLiqProf) ? true : false);
               Z133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z996CancelacionTipificacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z996CancelacionTipificacionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z1013CuponId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1013CuponId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n1013CuponId = ((0==A1013CuponId) ? true : false);
               A688SolicitudesLiqProf = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z688SolicitudesLiqProf"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n688SolicitudesLiqProf = false;
               n688SolicitudesLiqProf = ((0==A688SolicitudesLiqProf) ? true : false);
               A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A996CancelacionTipificacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z996CancelacionTipificacionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A1013CuponId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1013CuponId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n1013CuponId = false;
               n1013CuponId = ((0==A1013CuponId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_38 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_38"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vSOLICITUDESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13Insert_ProveedorID", StringUtil.LTrimStr( (decimal)(AV13Insert_ProveedorID), 18, 0));
               A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV15RoleName = cgiGet( "vROLENAME");
               AssignAttri("", false, "AV15RoleName", AV15RoleName);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A1013CuponId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CUPONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n1013CuponId = ((0==A1013CuponId) ? true : false);
               A996CancelacionTipificacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CANCELACIONTIPIFICACIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A688SolicitudesLiqProf = (long)(Math.Round(context.localUtil.CToN( cgiGet( "SOLICITUDESLIQPROF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n688SolicitudesLiqProf = ((0==A688SolicitudesLiqProf) ? true : false);
               AV27Pgmname = cgiGet( "vPGMNAME");
               AV21SolicitudServicioOrigenPago = cgiGet( "vSOLICITUDSERVICIOORIGENPAGO");
               AssignAttri("", false, "AV21SolicitudServicioOrigenPago", AV21SolicitudServicioOrigenPago);
               AV19ProfesionalesTieneDeuda = StringUtil.StrToBool( cgiGet( "vPROFESIONALESTIENEDEUDA"));
               AV20PuedeAceptar = StringUtil.StrToBool( cgiGet( "vPUEDEACEPTAR"));
               AV18ForzarPrepago = StringUtil.StrToBool( cgiGet( "vFORZARPREPAGO"));
               A143EstadoSGNombre = cgiGet( "ESTADOSGNOMBRE");
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
               A127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
               A171SolicitudesNombre = cgiGet( edtSolicitudesNombre_Internalname);
               AssignAttri("", false, "A171SolicitudesNombre", A171SolicitudesNombre);
               AV25Admin = cgiGet( edtavAdmin_Internalname);
               AssignAttri("", false, "AV25Admin", AV25Admin);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"SolicitudesRelacion");
               A127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
               forbiddenHiddens.Add("SolicitudesID", context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"));
               A171SolicitudesNombre = cgiGet( edtSolicitudesNombre_Internalname);
               AssignAttri("", false, "A171SolicitudesNombre", A171SolicitudesNombre);
               forbiddenHiddens.Add("SolicitudesNombre", StringUtil.RTrim( context.localUtil.Format( A171SolicitudesNombre, "")));
               forbiddenHiddens.Add("Insert_ProveedorID", context.localUtil.Format( (decimal)(AV13Insert_ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("SolicitudServicioOrigenPago", StringUtil.RTrim( context.localUtil.Format( AV21SolicitudServicioOrigenPago, "")));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("SolicitudesLiqProf", context.localUtil.Format( (decimal)(A688SolicitudesLiqProf), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("CuponId", context.localUtil.Format( (decimal)(A1013CuponId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("CancelacionTipificacionId", context.localUtil.Format( (decimal)(A996CancelacionTipificacionId), "ZZZZZZZZZZZZZZZZZ9"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A127SolicitudesID != Z127SolicitudesID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("solicitudesrelacion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A127SolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "SolicitudesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
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
                     sMode30 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode30;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound30 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0Q0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SOLICITUDESID");
                        AnyError = 1;
                        GX_FocusControl = edtSolicitudesID_Internalname;
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
                           E110Q2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120Q2 ();
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
            E120Q2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0Q30( ) ;
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
            DisableAttributes0Q30( ) ;
         }
         AssignProp("", false, edtavAdmin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAdmin_Enabled), 5, 0), true);
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

      protected void CONFIRM_0Q0( )
      {
         BeforeValidate0Q30( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Q30( ) ;
            }
            else
            {
               CheckExtendedTable0Q30( ) ;
               CloseExtendedTableCursors0Q30( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode30 = Gx_mode;
            CONFIRM_0Q32( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode30;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode30;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0Q32( )
      {
         nGXsfl_38_idx = 0;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            ReadRow0Q32( ) ;
            if ( ( nRcdExists_32 != 0 ) || ( nIsMod_32 != 0 ) )
            {
               GetKey0Q32( ) ;
               if ( ( nRcdExists_32 == 0 ) && ( nRcdDeleted_32 == 0 ) )
               {
                  if ( RcdFound32 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0Q32( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Q32( ) ;
                        CloseExtendedTableCursors0Q32( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "RELACIONESID_" + sGXsfl_38_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtRelacionesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound32 != 0 )
                  {
                     if ( nRcdDeleted_32 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0Q32( ) ;
                        Load0Q32( ) ;
                        BeforeValidate0Q32( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Q32( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_32 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0Q32( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Q32( ) ;
                              CloseExtendedTableCursors0Q32( ) ;
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
                     if ( nRcdDeleted_32 == 0 )
                     {
                        GXCCtl = "RELACIONESID_" + sGXsfl_38_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtRelacionesId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtRelacionesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A140RelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProfesionalesId_Internalname, StringUtil.RTrim( A120ProfesionalesId)) ;
            ChangePostValue( edtProfesionalesPrimerNombre_Internalname, StringUtil.RTrim( A166ProfesionalesPrimerNombre)) ;
            ChangePostValue( edtProfesionalesApellidoPrimero_Internalname, StringUtil.RTrim( A167ProfesionalesApellidoPrimero)) ;
            ChangePostValue( edtEstadoSGTipo_Internalname, StringUtil.RTrim( A141EstadoSGTipo)) ;
            ChangePostValue( dynEstadoSGId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A142EstadoSGId), 5, 0, ".", ""))) ;
            ChangePostValue( edtSolicitudesRelacionesFechaAlta_Internalname, context.localUtil.TToC( A219SolicitudesRelacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( edtSolicitudesRelacionesFechaModi_Internalname, context.localUtil.TToC( A220SolicitudesRelacionesFechaModi, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z140RelacionesId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z140RelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z219SolicitudesRelacionesFechaAlta_"+sGXsfl_38_idx, context.localUtil.TToC( Z219SolicitudesRelacionesFechaAlta, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z220SolicitudesRelacionesFechaModi_"+sGXsfl_38_idx, context.localUtil.TToC( Z220SolicitudesRelacionesFechaModi, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_38_idx, StringUtil.RTrim( Z120ProfesionalesId)) ;
            ChangePostValue( "ZT_"+"Z141EstadoSGTipo_"+sGXsfl_38_idx, StringUtil.RTrim( Z141EstadoSGTipo)) ;
            ChangePostValue( "ZT_"+"Z142EstadoSGId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z142EstadoSGId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "T120ProfesionalesId_"+sGXsfl_38_idx, StringUtil.RTrim( O120ProfesionalesId)) ;
            ChangePostValue( "nRcdDeleted_32_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_32), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_32_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_32), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_32_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_32), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "N140RelacionesId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(A140RelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "N120ProfesionalesId_"+sGXsfl_38_idx, StringUtil.RTrim( A120ProfesionalesId)) ;
            ChangePostValue( "N142EstadoSGId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(A142EstadoSGId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_32 != 0 )
            {
               ChangePostValue( "RELACIONESID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRelacionesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGTIPO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoSGTipo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadoSGId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SOLICITUDESRELACIONESFECHAALTA_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesRelacionesFechaAlta_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SOLICITUDESRELACIONESFECHAMODI_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesRelacionesFechaModi_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0Q0( )
      {
      }

      protected void E110Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV25Admin = AV12WebSession.Get(context.GetMessage( "ADMINISTRATOR", ""));
         AssignAttri("", false, "AV25Admin", AV25Admin);
         AV15RoleName = AV12WebSession.Get(context.GetMessage( "Rol", ""));
         AssignAttri("", false, "AV15RoleName", AV15RoleName);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudesRelacion_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudesRelacion_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudesRelacion_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV27Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV27Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV28GXV1 = 1;
            AssignAttri("", false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            while ( AV28GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV28GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ProveedorID") == 0 )
               {
                  AV13Insert_ProveedorID = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_ProveedorID", StringUtil.LTrimStr( (decimal)(AV13Insert_ProveedorID), 18, 0));
               }
               AV28GXV1 = (int)(AV28GXV1+1);
               AssignAttri("", false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            }
         }
         new osolorigenpago(context ).execute(  AV7SolicitudesID, out  AV21SolicitudServicioOrigenPago) ;
         AssignAttri("", false, "AV21SolicitudServicioOrigenPago", AV21SolicitudServicioOrigenPago);
      }

      protected void E120Q2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         this.executeExternalObjectMethod("", false, "GlobalEvents", "ActualizarSolicitudesProf", new Object[] {}, true);
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("solicitudesrelacionww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0Q30( short GX_JID )
      {
         if ( ( GX_JID == 31 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z171SolicitudesNombre = T000Q7_A171SolicitudesNombre[0];
               Z688SolicitudesLiqProf = T000Q7_A688SolicitudesLiqProf[0];
               Z133ProveedorID = T000Q7_A133ProveedorID[0];
               Z996CancelacionTipificacionId = T000Q7_A996CancelacionTipificacionId[0];
               Z1013CuponId = T000Q7_A1013CuponId[0];
            }
            else
            {
               Z171SolicitudesNombre = A171SolicitudesNombre;
               Z688SolicitudesLiqProf = A688SolicitudesLiqProf;
               Z133ProveedorID = A133ProveedorID;
               Z996CancelacionTipificacionId = A996CancelacionTipificacionId;
               Z1013CuponId = A1013CuponId;
            }
         }
         if ( GX_JID == -31 )
         {
            Z127SolicitudesID = A127SolicitudesID;
            Z171SolicitudesNombre = A171SolicitudesNombre;
            Z688SolicitudesLiqProf = A688SolicitudesLiqProf;
            Z133ProveedorID = A133ProveedorID;
            Z996CancelacionTipificacionId = A996CancelacionTipificacionId;
            Z1013CuponId = A1013CuponId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSolicitudesID_Enabled = 0;
         AssignProp("", false, edtSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesID_Enabled), 5, 0), true);
         edtSolicitudesNombre_Enabled = 0;
         AssignProp("", false, edtSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesNombre_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtSolicitudesID_Enabled = 0;
         AssignProp("", false, edtSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesID_Enabled), 5, 0), true);
         edtSolicitudesNombre_Enabled = 0;
         AssignProp("", false, edtSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesNombre_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SolicitudesID) )
         {
            A127SolicitudesID = AV7SolicitudesID;
            AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ProveedorID) )
         {
            A133ProveedorID = AV13Insert_ProveedorID;
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
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
         if ( IsIns( )  && (0==A1013CuponId) && ( Gx_BScreen == 0 ) )
         {
            A1013CuponId = 1234;
            n1013CuponId = false;
            AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
         }
         if ( IsIns( )  && (0==A996CancelacionTipificacionId) && ( Gx_BScreen == 0 ) )
         {
            A996CancelacionTipificacionId = 0;
            AssignAttri("", false, "A996CancelacionTipificacionId", StringUtil.LTrimStr( (decimal)(A996CancelacionTipificacionId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV27Pgmname = "SolicitudesRelacion";
            AssignAttri("", false, "AV27Pgmname", AV27Pgmname);
            AV25Admin = AV12WebSession.Get(context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), ""));
            AssignAttri("", false, "AV25Admin", AV25Admin);
            AV15RoleName = AV12WebSession.Get(context.GetMessage( context.GetMessage( "Rol", ""), ""));
            AssignAttri("", false, "AV15RoleName", AV15RoleName);
         }
      }

      protected void Load0Q30( )
      {
         /* Using cursor T000Q9 */
         pr_default.execute(7, new Object[] {A127SolicitudesID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound30 = 1;
            A171SolicitudesNombre = T000Q9_A171SolicitudesNombre[0];
            AssignAttri("", false, "A171SolicitudesNombre", A171SolicitudesNombre);
            A688SolicitudesLiqProf = T000Q9_A688SolicitudesLiqProf[0];
            n688SolicitudesLiqProf = T000Q9_n688SolicitudesLiqProf[0];
            A133ProveedorID = T000Q9_A133ProveedorID[0];
            A996CancelacionTipificacionId = T000Q9_A996CancelacionTipificacionId[0];
            A1013CuponId = T000Q9_A1013CuponId[0];
            n1013CuponId = T000Q9_n1013CuponId[0];
            ZM0Q30( -31) ;
         }
         pr_default.close(7);
         OnLoadActions0Q30( ) ;
      }

      protected void OnLoadActions0Q30( )
      {
         AV27Pgmname = "SolicitudesRelacion";
         AssignAttri("", false, "AV27Pgmname", AV27Pgmname);
         AV25Admin = AV12WebSession.Get(context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), ""));
         AssignAttri("", false, "AV25Admin", AV25Admin);
         AV15RoleName = AV12WebSession.Get(context.GetMessage( context.GetMessage( "Rol", ""), ""));
         AssignAttri("", false, "AV15RoleName", AV15RoleName);
      }

      protected void CheckExtendedTable0Q30( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV27Pgmname = "SolicitudesRelacion";
         AssignAttri("", false, "AV27Pgmname", AV27Pgmname);
         AV25Admin = AV12WebSession.Get(context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), ""));
         AssignAttri("", false, "AV25Admin", AV25Admin);
         AV15RoleName = AV12WebSession.Get(context.GetMessage( context.GetMessage( "Rol", ""), ""));
         AssignAttri("", false, "AV15RoleName", AV15RoleName);
         if ( ( IsDlt( )  || IsUpd( )  ) && ! (0==A688SolicitudesLiqProf) && ( A688SolicitudesLiqProf != 0 ) )
         {
            GX_msglist.addItem(context.GetMessage( "No se puede quitar ni modificar el profesional: la solicitud ya está liquidada en la Operación ", "")+StringUtil.Str( (decimal)(A688SolicitudesLiqProf), 18, 0), 1, "");
            AnyError = 1;
         }
         /* Using cursor T000Q8 */
         pr_default.execute(6, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
         }
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors0Q30( )
      {
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_32( long A133ProveedorID )
      {
         /* Using cursor T000Q10 */
         pr_default.execute(8, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0Q30( )
      {
         /* Using cursor T000Q11 */
         pr_default.execute(9, new Object[] {A127SolicitudesID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound30 = 1;
         }
         else
         {
            RcdFound30 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Q7 */
         pr_default.execute(5, new Object[] {A127SolicitudesID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0Q30( 31) ;
            RcdFound30 = 1;
            A127SolicitudesID = T000Q7_A127SolicitudesID[0];
            AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
            A171SolicitudesNombre = T000Q7_A171SolicitudesNombre[0];
            AssignAttri("", false, "A171SolicitudesNombre", A171SolicitudesNombre);
            A688SolicitudesLiqProf = T000Q7_A688SolicitudesLiqProf[0];
            n688SolicitudesLiqProf = T000Q7_n688SolicitudesLiqProf[0];
            A133ProveedorID = T000Q7_A133ProveedorID[0];
            A996CancelacionTipificacionId = T000Q7_A996CancelacionTipificacionId[0];
            A1013CuponId = T000Q7_A1013CuponId[0];
            n1013CuponId = T000Q7_n1013CuponId[0];
            Z127SolicitudesID = A127SolicitudesID;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Q30( ) ;
            if ( AnyError == 1 )
            {
               RcdFound30 = 0;
               InitializeNonKey0Q30( ) ;
            }
            Gx_mode = sMode30;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound30 = 0;
            InitializeNonKey0Q30( ) ;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode30;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Q30( ) ;
         if ( RcdFound30 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound30 = 0;
         /* Using cursor T000Q12 */
         pr_default.execute(10, new Object[] {A127SolicitudesID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000Q12_A127SolicitudesID[0] < A127SolicitudesID ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000Q12_A127SolicitudesID[0] > A127SolicitudesID ) ) )
            {
               A127SolicitudesID = T000Q12_A127SolicitudesID[0];
               AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
               RcdFound30 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound30 = 0;
         /* Using cursor T000Q13 */
         pr_default.execute(11, new Object[] {A127SolicitudesID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000Q13_A127SolicitudesID[0] > A127SolicitudesID ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000Q13_A127SolicitudesID[0] < A127SolicitudesID ) ) )
            {
               A127SolicitudesID = T000Q13_A127SolicitudesID[0];
               AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
               RcdFound30 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Q30( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0Q30( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound30 == 1 )
            {
               if ( A127SolicitudesID != Z127SolicitudesID )
               {
                  A127SolicitudesID = Z127SolicitudesID;
                  AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SOLICITUDESID");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  /* Update record */
                  Update0Q30( ) ;
               }
            }
            else
            {
               if ( A127SolicitudesID != Z127SolicitudesID )
               {
                  /* Insert record */
                  Insert0Q30( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SOLICITUDESID");
                     AnyError = 1;
                     GX_FocusControl = edtSolicitudesID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     Insert0Q30( ) ;
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
         if ( A127SolicitudesID != Z127SolicitudesID )
         {
            A127SolicitudesID = Z127SolicitudesID;
            AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SOLICITUDESID");
            AnyError = 1;
            GX_FocusControl = edtSolicitudesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0Q30( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Q6 */
            pr_default.execute(4, new Object[] {A127SolicitudesID});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Solicitudes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z171SolicitudesNombre, T000Q6_A171SolicitudesNombre[0]) != 0 ) || ( Z688SolicitudesLiqProf != T000Q6_A688SolicitudesLiqProf[0] ) || ( Z133ProveedorID != T000Q6_A133ProveedorID[0] ) || ( Z996CancelacionTipificacionId != T000Q6_A996CancelacionTipificacionId[0] ) || ( Z1013CuponId != T000Q6_A1013CuponId[0] ) )
            {
               if ( StringUtil.StrCmp(Z171SolicitudesNombre, T000Q6_A171SolicitudesNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesrelacion:[seudo value changed for attri]"+"SolicitudesNombre");
                  GXUtil.WriteLogRaw("Old: ",Z171SolicitudesNombre);
                  GXUtil.WriteLogRaw("Current: ",T000Q6_A171SolicitudesNombre[0]);
               }
               if ( Z688SolicitudesLiqProf != T000Q6_A688SolicitudesLiqProf[0] )
               {
                  GXUtil.WriteLog("solicitudesrelacion:[seudo value changed for attri]"+"SolicitudesLiqProf");
                  GXUtil.WriteLogRaw("Old: ",Z688SolicitudesLiqProf);
                  GXUtil.WriteLogRaw("Current: ",T000Q6_A688SolicitudesLiqProf[0]);
               }
               if ( Z133ProveedorID != T000Q6_A133ProveedorID[0] )
               {
                  GXUtil.WriteLog("solicitudesrelacion:[seudo value changed for attri]"+"ProveedorID");
                  GXUtil.WriteLogRaw("Old: ",Z133ProveedorID);
                  GXUtil.WriteLogRaw("Current: ",T000Q6_A133ProveedorID[0]);
               }
               if ( Z996CancelacionTipificacionId != T000Q6_A996CancelacionTipificacionId[0] )
               {
                  GXUtil.WriteLog("solicitudesrelacion:[seudo value changed for attri]"+"CancelacionTipificacionId");
                  GXUtil.WriteLogRaw("Old: ",Z996CancelacionTipificacionId);
                  GXUtil.WriteLogRaw("Current: ",T000Q6_A996CancelacionTipificacionId[0]);
               }
               if ( Z1013CuponId != T000Q6_A1013CuponId[0] )
               {
                  GXUtil.WriteLog("solicitudesrelacion:[seudo value changed for attri]"+"CuponId");
                  GXUtil.WriteLogRaw("Old: ",Z1013CuponId);
                  GXUtil.WriteLogRaw("Current: ",T000Q6_A1013CuponId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Solicitudes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Q30( )
      {
         BeforeValidate0Q30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q30( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Q30( 0) ;
            CheckOptimisticConcurrency0Q30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Q30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Q14 */
                     pr_default.execute(12, new Object[] {A171SolicitudesNombre, n688SolicitudesLiqProf, A688SolicitudesLiqProf, A133ProveedorID, A996CancelacionTipificacionId, n1013CuponId, A1013CuponId});
                     A127SolicitudesID = T000Q14_A127SolicitudesID[0];
                     AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0Q30( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0Q0( ) ;
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
               Load0Q30( ) ;
            }
            EndLevel0Q30( ) ;
         }
         CloseExtendedTableCursors0Q30( ) ;
      }

      protected void Update0Q30( )
      {
         BeforeValidate0Q30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q30( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Q30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Q15 */
                     pr_default.execute(13, new Object[] {A171SolicitudesNombre, n688SolicitudesLiqProf, A688SolicitudesLiqProf, A133ProveedorID, A996CancelacionTipificacionId, n1013CuponId, A1013CuponId, A127SolicitudesID});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Solicitudes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Q30( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0Q30( ) ;
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
            EndLevel0Q30( ) ;
         }
         CloseExtendedTableCursors0Q30( ) ;
      }

      protected void DeferredUpdate0Q30( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0Q30( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q30( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Q30( ) ;
            AfterConfirm0Q30( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Q30( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0Q32( ) ;
                  while ( RcdFound32 != 0 )
                  {
                     getByPrimaryKey0Q32( ) ;
                     Delete0Q32( ) ;
                     ScanNext0Q32( ) ;
                  }
                  ScanEnd0Q32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Q16 */
                     pr_default.execute(14, new Object[] {A127SolicitudesID});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
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
         sMode30 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Q30( ) ;
         Gx_mode = sMode30;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Q30( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( ( IsDlt( )  || IsUpd( )  ) && ! (0==A688SolicitudesLiqProf) && ( A688SolicitudesLiqProf != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "No se puede quitar ni modificar el profesional: la solicitud ya está liquidada en la Operación ", "")+StringUtil.Str( (decimal)(A688SolicitudesLiqProf), 18, 0), 1, "");
               AnyError = 1;
            }
            AV27Pgmname = "SolicitudesRelacion";
            AssignAttri("", false, "AV27Pgmname", AV27Pgmname);
            AV25Admin = AV12WebSession.Get(context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), ""));
            AssignAttri("", false, "AV25Admin", AV25Admin);
            AV15RoleName = AV12WebSession.Get(context.GetMessage( context.GetMessage( "Rol", ""), ""));
            AssignAttri("", false, "AV15RoleName", AV15RoleName);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000Q17 */
            pr_default.execute(15, new Object[] {A127SolicitudesID});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Archivo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000Q18 */
            pr_default.execute(16, new Object[] {A127SolicitudesID});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Items", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void ProcessNestedLevel0Q32( )
      {
         nGXsfl_38_idx = 0;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            ReadRow0Q32( ) ;
            if ( ( nRcdExists_32 != 0 ) || ( nIsMod_32 != 0 ) )
            {
               standaloneNotModal0Q32( ) ;
               GetKey0Q32( ) ;
               if ( ( nRcdExists_32 == 0 ) && ( nRcdDeleted_32 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0Q32( ) ;
               }
               else
               {
                  if ( RcdFound32 != 0 )
                  {
                     if ( ( nRcdDeleted_32 != 0 ) && ( nRcdExists_32 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0Q32( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_32 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0Q32( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_32 == 0 )
                     {
                        GXCCtl = "RELACIONESID_" + sGXsfl_38_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtRelacionesId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtRelacionesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A140RelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProfesionalesId_Internalname, StringUtil.RTrim( A120ProfesionalesId)) ;
            ChangePostValue( edtProfesionalesPrimerNombre_Internalname, StringUtil.RTrim( A166ProfesionalesPrimerNombre)) ;
            ChangePostValue( edtProfesionalesApellidoPrimero_Internalname, StringUtil.RTrim( A167ProfesionalesApellidoPrimero)) ;
            ChangePostValue( edtEstadoSGTipo_Internalname, StringUtil.RTrim( A141EstadoSGTipo)) ;
            ChangePostValue( dynEstadoSGId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A142EstadoSGId), 5, 0, ".", ""))) ;
            ChangePostValue( edtSolicitudesRelacionesFechaAlta_Internalname, context.localUtil.TToC( A219SolicitudesRelacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( edtSolicitudesRelacionesFechaModi_Internalname, context.localUtil.TToC( A220SolicitudesRelacionesFechaModi, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z140RelacionesId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z140RelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z219SolicitudesRelacionesFechaAlta_"+sGXsfl_38_idx, context.localUtil.TToC( Z219SolicitudesRelacionesFechaAlta, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z220SolicitudesRelacionesFechaModi_"+sGXsfl_38_idx, context.localUtil.TToC( Z220SolicitudesRelacionesFechaModi, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_38_idx, StringUtil.RTrim( Z120ProfesionalesId)) ;
            ChangePostValue( "ZT_"+"Z141EstadoSGTipo_"+sGXsfl_38_idx, StringUtil.RTrim( Z141EstadoSGTipo)) ;
            ChangePostValue( "ZT_"+"Z142EstadoSGId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z142EstadoSGId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "T120ProfesionalesId_"+sGXsfl_38_idx, StringUtil.RTrim( O120ProfesionalesId)) ;
            ChangePostValue( "nRcdDeleted_32_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_32), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_32_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_32), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_32_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_32), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "N140RelacionesId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(A140RelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "N120ProfesionalesId_"+sGXsfl_38_idx, StringUtil.RTrim( A120ProfesionalesId)) ;
            ChangePostValue( "N142EstadoSGId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(A142EstadoSGId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_32 != 0 )
            {
               ChangePostValue( "RELACIONESID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRelacionesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGTIPO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoSGTipo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadoSGId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SOLICITUDESRELACIONESFECHAALTA_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesRelacionesFechaAlta_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SOLICITUDESRELACIONESFECHAMODI_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesRelacionesFechaModi_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Q32( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_32 = 0;
         nIsMod_32 = 0;
         nRcdDeleted_32 = 0;
      }

      protected void ProcessLevel0Q30( )
      {
         /* Save parent mode. */
         sMode30 = Gx_mode;
         ProcessNestedLevel0Q32( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode30;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0Q30( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Q30( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("solicitudesrelacion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0Q0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("solicitudesrelacion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Q30( )
      {
         /* Scan By routine */
         /* Using cursor T000Q19 */
         pr_default.execute(17);
         RcdFound30 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound30 = 1;
            A127SolicitudesID = T000Q19_A127SolicitudesID[0];
            AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Q30( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound30 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound30 = 1;
            A127SolicitudesID = T000Q19_A127SolicitudesID[0];
            AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
         }
      }

      protected void ScanEnd0Q30( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0Q30( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Q30( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Q30( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Q30( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Q30( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Q30( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Q30( )
      {
         edtSolicitudesID_Enabled = 0;
         AssignProp("", false, edtSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesID_Enabled), 5, 0), true);
         edtSolicitudesNombre_Enabled = 0;
         AssignProp("", false, edtSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesNombre_Enabled), 5, 0), true);
         edtavAdmin_Enabled = 0;
         AssignProp("", false, edtavAdmin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAdmin_Enabled), 5, 0), true);
      }

      protected void ZM0Q32( short GX_JID )
      {
         if ( ( GX_JID == 33 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z219SolicitudesRelacionesFechaAlta = T000Q3_A219SolicitudesRelacionesFechaAlta[0];
               Z220SolicitudesRelacionesFechaModi = T000Q3_A220SolicitudesRelacionesFechaModi[0];
               Z120ProfesionalesId = T000Q3_A120ProfesionalesId[0];
               Z141EstadoSGTipo = T000Q3_A141EstadoSGTipo[0];
               Z142EstadoSGId = T000Q3_A142EstadoSGId[0];
            }
            else
            {
               Z219SolicitudesRelacionesFechaAlta = A219SolicitudesRelacionesFechaAlta;
               Z220SolicitudesRelacionesFechaModi = A220SolicitudesRelacionesFechaModi;
               Z120ProfesionalesId = A120ProfesionalesId;
               Z141EstadoSGTipo = A141EstadoSGTipo;
               Z142EstadoSGId = A142EstadoSGId;
            }
         }
         if ( GX_JID == -33 )
         {
            Z127SolicitudesID = A127SolicitudesID;
            Z140RelacionesId = A140RelacionesId;
            Z219SolicitudesRelacionesFechaAlta = A219SolicitudesRelacionesFechaAlta;
            Z220SolicitudesRelacionesFechaModi = A220SolicitudesRelacionesFechaModi;
            Z120ProfesionalesId = A120ProfesionalesId;
            Z141EstadoSGTipo = A141EstadoSGTipo;
            Z142EstadoSGId = A142EstadoSGId;
            Z166ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
            Z167ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
            Z143EstadoSGNombre = A143EstadoSGNombre;
         }
      }

      protected void standaloneNotModal0Q32( )
      {
         GXAESTADOSGID_html0Q32( ) ;
         edtSolicitudesRelacionesFechaAlta_Enabled = 0;
         AssignProp("", false, edtSolicitudesRelacionesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesRelacionesFechaAlta_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtSolicitudesRelacionesFechaModi_Enabled = 0;
         AssignProp("", false, edtSolicitudesRelacionesFechaModi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesRelacionesFechaModi_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtEstadoSGTipo_Enabled = 0;
         AssignProp("", false, edtEstadoSGTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoSGTipo_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         if ( ! ( StringUtil.StrCmp(AV25Admin, context.GetMessage( context.GetMessage( "Yes", ""), "")) == 0 ) )
         {
            edtRelacionesId_Enabled = 0;
            AssignProp("", false, edtRelacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelacionesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
         else
         {
            edtRelacionesId_Enabled = 1;
            AssignProp("", false, edtRelacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelacionesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
         if ( ! ( StringUtil.StrCmp(AV25Admin, context.GetMessage( context.GetMessage( "Yes", ""), "")) == 0 ) )
         {
            edtProfesionalesId_Enabled = 0;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
         else
         {
            edtProfesionalesId_Enabled = 1;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
         if ( ! ( StringUtil.StrCmp(AV25Admin, context.GetMessage( context.GetMessage( "Yes", ""), "")) == 0 ) )
         {
            dynEstadoSGId.Enabled = 0;
            AssignProp("", false, dynEstadoSGId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadoSGId.Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
         else
         {
            dynEstadoSGId.Enabled = 1;
            AssignProp("", false, dynEstadoSGId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadoSGId.Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
      }

      protected void standaloneModal0Q32( )
      {
         A141EstadoSGTipo = context.GetMessage( context.GetMessage( "STS", ""), "");
         if ( IsIns( )  && (0==A142EstadoSGId) && ( Gx_BScreen == 0 ) )
         {
            A142EstadoSGId = 1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtRelacionesId_Enabled = 0;
            AssignProp("", false, edtRelacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelacionesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000Q5 */
            pr_default.execute(3, new Object[] {A141EstadoSGTipo, A142EstadoSGId});
            A143EstadoSGNombre = T000Q5_A143EstadoSGNombre[0];
            pr_default.close(3);
         }
      }

      protected void Load0Q32( )
      {
         /* Using cursor T000Q20 */
         pr_default.execute(18, new Object[] {A127SolicitudesID, A140RelacionesId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound32 = 1;
            A166ProfesionalesPrimerNombre = T000Q20_A166ProfesionalesPrimerNombre[0];
            A167ProfesionalesApellidoPrimero = T000Q20_A167ProfesionalesApellidoPrimero[0];
            A143EstadoSGNombre = T000Q20_A143EstadoSGNombre[0];
            A219SolicitudesRelacionesFechaAlta = T000Q20_A219SolicitudesRelacionesFechaAlta[0];
            A220SolicitudesRelacionesFechaModi = T000Q20_A220SolicitudesRelacionesFechaModi[0];
            A120ProfesionalesId = T000Q20_A120ProfesionalesId[0];
            A141EstadoSGTipo = T000Q20_A141EstadoSGTipo[0];
            A142EstadoSGId = T000Q20_A142EstadoSGId[0];
            ZM0Q32( -33) ;
         }
         pr_default.close(18);
         OnLoadActions0Q32( ) ;
      }

      protected void OnLoadActions0Q32( )
      {
      }

      protected void CheckExtendedTable0Q32( )
      {
         nIsDirty_32 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0Q32( ) ;
         if ( ( StringUtil.StrCmp(AV21SolicitudServicioOrigenPago, "F") == 0 ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV15RoleName), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) )
         {
            new GeneXus.Programs.apis.verificartrabajosporestadodeuda(context ).execute(  A120ProfesionalesId,  3, out  AV19ProfesionalesTieneDeuda, out  AV20PuedeAceptar) ;
            AssignAttri("", false, "AV19ProfesionalesTieneDeuda", AV19ProfesionalesTieneDeuda);
            AssignAttri("", false, "AV20PuedeAceptar", AV20PuedeAceptar);
         }
         if ( ( StringUtil.StrCmp(AV21SolicitudServicioOrigenPago, "F") == 0 ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV15RoleName), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) )
         {
            new GeneXus.Programs.apis.validaforzarprepago(context ).execute(  A120ProfesionalesId, out  AV18ForzarPrepago) ;
            AssignAttri("", false, "AV18ForzarPrepago", AV18ForzarPrepago);
         }
         if ( ( StringUtil.StrCmp(AV21SolicitudServicioOrigenPago, "F") == 0 ) && ! AV20PuedeAceptar && ! ( StringUtil.StrCmp(StringUtil.Trim( AV15RoleName), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) && ( IsIns( )  || ( IsUpd( )  && ( StringUtil.StrCmp(A120ProfesionalesId, O120ProfesionalesId) != 0 ) ) ) )
         {
            GXCCtl = "PROFESIONALESID_" + sGXsfl_38_idx;
            GX_msglist.addItem(context.GetMessage( "El profesional no puede ser asignado: posee deuda.", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( StringUtil.StrCmp(AV21SolicitudServicioOrigenPago, "F") == 0 ) && ! AV20PuedeAceptar && ! ( StringUtil.StrCmp(StringUtil.Trim( AV15RoleName), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) && ( IsIns( )  || ( IsUpd( )  && ( StringUtil.StrCmp(A120ProfesionalesId, O120ProfesionalesId) != 0 ) ) ) )
         {
            GXCCtl = "PROFESIONALESID_" + sGXsfl_38_idx;
            GX_msglist.addItem(context.GetMessage( "El profesional debe ser asignado a cobro prepago.", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( StringUtil.StrCmp(A120ProfesionalesId, O120ProfesionalesId) != 0 ) && ! ( (0==A688SolicitudesLiqProf) || T000Q7_n688SolicitudesLiqProf[0] ) && ( A688SolicitudesLiqProf != 0 ) )
         {
            GXCCtl = "PROFESIONALESID_" + sGXsfl_38_idx;
            GX_msglist.addItem(context.GetMessage( "No se puede cambiar el profesional: la solicitud ya forma parte de la liquidación Nro ", "")+StringUtil.Str( (decimal)(A688SolicitudesLiqProf), 18, 0), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A140RelacionesId) )
         {
            GXCCtl = "RELACIONESID_" + sGXsfl_38_idx;
            GX_msglist.addItem(context.GetMessage( "Ingrese un número correlativo", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRelacionesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000Q4 */
         pr_default.execute(2, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PROFESIONALESID_" + sGXsfl_38_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A166ProfesionalesPrimerNombre = T000Q4_A166ProfesionalesPrimerNombre[0];
         A167ProfesionalesApellidoPrimero = T000Q4_A167ProfesionalesApellidoPrimero[0];
         pr_default.close(2);
         /* Using cursor T000Q5 */
         pr_default.execute(3, new Object[] {A141EstadoSGTipo, A142EstadoSGId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "ESTADOSGID_" + sGXsfl_38_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado SG", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynEstadoSGId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A143EstadoSGNombre = T000Q5_A143EstadoSGNombre[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0Q32( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0Q32( )
      {
      }

      protected void gxLoad_34( string A120ProfesionalesId )
      {
         /* Using cursor T000Q21 */
         pr_default.execute(19, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GXCCtl = "PROFESIONALESID_" + sGXsfl_38_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A166ProfesionalesPrimerNombre = T000Q21_A166ProfesionalesPrimerNombre[0];
         A167ProfesionalesApellidoPrimero = T000Q21_A167ProfesionalesApellidoPrimero[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A166ProfesionalesPrimerNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A167ProfesionalesApellidoPrimero))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_35( string A141EstadoSGTipo ,
                                int A142EstadoSGId )
      {
         /* Using cursor T000Q22 */
         pr_default.execute(20, new Object[] {A141EstadoSGTipo, A142EstadoSGId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GXCCtl = "ESTADOSGID_" + sGXsfl_38_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado SG", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynEstadoSGId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A143EstadoSGNombre = T000Q22_A143EstadoSGNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A143EstadoSGNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void GetKey0Q32( )
      {
         /* Using cursor T000Q23 */
         pr_default.execute(21, new Object[] {A127SolicitudesID, A140RelacionesId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound32 = 1;
         }
         else
         {
            RcdFound32 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey0Q32( )
      {
         /* Using cursor T000Q3 */
         pr_default.execute(1, new Object[] {A127SolicitudesID, A140RelacionesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Q32( 33) ;
            RcdFound32 = 1;
            InitializeNonKey0Q32( ) ;
            A140RelacionesId = T000Q3_A140RelacionesId[0];
            A219SolicitudesRelacionesFechaAlta = T000Q3_A219SolicitudesRelacionesFechaAlta[0];
            A220SolicitudesRelacionesFechaModi = T000Q3_A220SolicitudesRelacionesFechaModi[0];
            A120ProfesionalesId = T000Q3_A120ProfesionalesId[0];
            A141EstadoSGTipo = T000Q3_A141EstadoSGTipo[0];
            A142EstadoSGId = T000Q3_A142EstadoSGId[0];
            O120ProfesionalesId = A120ProfesionalesId;
            Z127SolicitudesID = A127SolicitudesID;
            Z140RelacionesId = A140RelacionesId;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Q32( ) ;
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound32 = 0;
            InitializeNonKey0Q32( ) ;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0Q32( ) ;
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Q32( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0Q32( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Q2 */
            pr_default.execute(0, new Object[] {A127SolicitudesID, A140RelacionesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Relaciones"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z219SolicitudesRelacionesFechaAlta != T000Q2_A219SolicitudesRelacionesFechaAlta[0] ) || ( Z220SolicitudesRelacionesFechaModi != T000Q2_A220SolicitudesRelacionesFechaModi[0] ) || ( StringUtil.StrCmp(Z120ProfesionalesId, T000Q2_A120ProfesionalesId[0]) != 0 ) || ( StringUtil.StrCmp(Z141EstadoSGTipo, T000Q2_A141EstadoSGTipo[0]) != 0 ) || ( Z142EstadoSGId != T000Q2_A142EstadoSGId[0] ) )
            {
               if ( Z219SolicitudesRelacionesFechaAlta != T000Q2_A219SolicitudesRelacionesFechaAlta[0] )
               {
                  GXUtil.WriteLog("solicitudesrelacion:[seudo value changed for attri]"+"SolicitudesRelacionesFechaAlta");
                  GXUtil.WriteLogRaw("Old: ",Z219SolicitudesRelacionesFechaAlta);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A219SolicitudesRelacionesFechaAlta[0]);
               }
               if ( Z220SolicitudesRelacionesFechaModi != T000Q2_A220SolicitudesRelacionesFechaModi[0] )
               {
                  GXUtil.WriteLog("solicitudesrelacion:[seudo value changed for attri]"+"SolicitudesRelacionesFechaModi");
                  GXUtil.WriteLogRaw("Old: ",Z220SolicitudesRelacionesFechaModi);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A220SolicitudesRelacionesFechaModi[0]);
               }
               if ( StringUtil.StrCmp(Z120ProfesionalesId, T000Q2_A120ProfesionalesId[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesrelacion:[seudo value changed for attri]"+"ProfesionalesId");
                  GXUtil.WriteLogRaw("Old: ",Z120ProfesionalesId);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A120ProfesionalesId[0]);
               }
               if ( StringUtil.StrCmp(Z141EstadoSGTipo, T000Q2_A141EstadoSGTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesrelacion:[seudo value changed for attri]"+"EstadoSGTipo");
                  GXUtil.WriteLogRaw("Old: ",Z141EstadoSGTipo);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A141EstadoSGTipo[0]);
               }
               if ( Z142EstadoSGId != T000Q2_A142EstadoSGId[0] )
               {
                  GXUtil.WriteLog("solicitudesrelacion:[seudo value changed for attri]"+"EstadoSGId");
                  GXUtil.WriteLogRaw("Old: ",Z142EstadoSGId);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A142EstadoSGId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Relaciones"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Q32( )
      {
         BeforeValidate0Q32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q32( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Q32( 0) ;
            CheckOptimisticConcurrency0Q32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Q32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Q24 */
                     pr_default.execute(22, new Object[] {A127SolicitudesID, A140RelacionesId, A219SolicitudesRelacionesFechaAlta, A220SolicitudesRelacionesFechaModi, A120ProfesionalesId, A141EstadoSGTipo, A142EstadoSGId});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("Relaciones");
                     if ( (pr_default.getStatus(22) == 1) )
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
               Load0Q32( ) ;
            }
            EndLevel0Q32( ) ;
         }
         CloseExtendedTableCursors0Q32( ) ;
      }

      protected void Update0Q32( )
      {
         BeforeValidate0Q32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q32( ) ;
         }
         if ( ( nIsMod_32 != 0 ) || ( nIsDirty_32 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0Q32( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0Q32( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0Q32( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000Q25 */
                        pr_default.execute(23, new Object[] {A219SolicitudesRelacionesFechaAlta, A220SolicitudesRelacionesFechaModi, A120ProfesionalesId, A141EstadoSGTipo, A142EstadoSGId, A127SolicitudesID, A140RelacionesId});
                        pr_default.close(23);
                        pr_default.SmartCacheProvider.SetUpdated("Relaciones");
                        if ( (pr_default.getStatus(23) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Relaciones"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0Q32( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0Q32( ) ;
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
               EndLevel0Q32( ) ;
            }
         }
         CloseExtendedTableCursors0Q32( ) ;
      }

      protected void DeferredUpdate0Q32( )
      {
      }

      protected void Delete0Q32( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Q32( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q32( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Q32( ) ;
            AfterConfirm0Q32( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Q32( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Q26 */
                  pr_default.execute(24, new Object[] {A127SolicitudesID, A140RelacionesId});
                  pr_default.close(24);
                  pr_default.SmartCacheProvider.SetUpdated("Relaciones");
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
         sMode32 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Q32( ) ;
         Gx_mode = sMode32;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Q32( )
      {
         standaloneModal0Q32( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000Q27 */
            pr_default.execute(25, new Object[] {A120ProfesionalesId});
            A166ProfesionalesPrimerNombre = T000Q27_A166ProfesionalesPrimerNombre[0];
            A167ProfesionalesApellidoPrimero = T000Q27_A167ProfesionalesApellidoPrimero[0];
            pr_default.close(25);
            /* Using cursor T000Q28 */
            pr_default.execute(26, new Object[] {A141EstadoSGTipo, A142EstadoSGId});
            A143EstadoSGNombre = T000Q28_A143EstadoSGNombre[0];
            pr_default.close(26);
         }
      }

      protected void EndLevel0Q32( )
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

      public void ScanStart0Q32( )
      {
         /* Scan By routine */
         /* Using cursor T000Q29 */
         pr_default.execute(27, new Object[] {A127SolicitudesID});
         RcdFound32 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound32 = 1;
            A140RelacionesId = T000Q29_A140RelacionesId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Q32( )
      {
         /* Scan next routine */
         pr_default.readNext(27);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound32 = 1;
            A140RelacionesId = T000Q29_A140RelacionesId[0];
         }
      }

      protected void ScanEnd0Q32( )
      {
         pr_default.close(27);
      }

      protected void AfterConfirm0Q32( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Q32( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Q32( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Q32( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Q32( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Q32( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Q32( )
      {
         edtRelacionesId_Enabled = 0;
         AssignProp("", false, edtRelacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelacionesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtProfesionalesId_Enabled = 0;
         AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtProfesionalesPrimerNombre_Enabled = 0;
         AssignProp("", false, edtProfesionalesPrimerNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtProfesionalesApellidoPrimero_Enabled = 0;
         AssignProp("", false, edtProfesionalesApellidoPrimero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtEstadoSGTipo_Enabled = 0;
         AssignProp("", false, edtEstadoSGTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoSGTipo_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         dynEstadoSGId.Enabled = 0;
         AssignProp("", false, dynEstadoSGId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadoSGId.Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtSolicitudesRelacionesFechaAlta_Enabled = 0;
         AssignProp("", false, edtSolicitudesRelacionesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesRelacionesFechaAlta_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtSolicitudesRelacionesFechaModi_Enabled = 0;
         AssignProp("", false, edtSolicitudesRelacionesFechaModi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesRelacionesFechaModi_Enabled), 5, 0), !bGXsfl_38_Refreshing);
      }

      protected void send_integrity_lvl_hashes0Q32( )
      {
      }

      protected void send_integrity_lvl_hashes0Q30( )
      {
      }

      protected void SubsflControlProps_3832( )
      {
         edtRelacionesId_Internalname = "RELACIONESID_"+sGXsfl_38_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_38_idx;
         imgprompt_120_Internalname = "PROMPT_120_"+sGXsfl_38_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_38_idx;
         edtEstadoSGTipo_Internalname = "ESTADOSGTIPO_"+sGXsfl_38_idx;
         dynEstadoSGId_Internalname = "ESTADOSGID_"+sGXsfl_38_idx;
         imgprompt_142_Internalname = "PROMPT_142_"+sGXsfl_38_idx;
         edtSolicitudesRelacionesFechaAlta_Internalname = "SOLICITUDESRELACIONESFECHAALTA_"+sGXsfl_38_idx;
         edtSolicitudesRelacionesFechaModi_Internalname = "SOLICITUDESRELACIONESFECHAMODI_"+sGXsfl_38_idx;
      }

      protected void SubsflControlProps_fel_3832( )
      {
         edtRelacionesId_Internalname = "RELACIONESID_"+sGXsfl_38_fel_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_38_fel_idx;
         imgprompt_120_Internalname = "PROMPT_120_"+sGXsfl_38_fel_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_fel_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_38_fel_idx;
         edtEstadoSGTipo_Internalname = "ESTADOSGTIPO_"+sGXsfl_38_fel_idx;
         dynEstadoSGId_Internalname = "ESTADOSGID_"+sGXsfl_38_fel_idx;
         imgprompt_142_Internalname = "PROMPT_142_"+sGXsfl_38_fel_idx;
         edtSolicitudesRelacionesFechaAlta_Internalname = "SOLICITUDESRELACIONESFECHAALTA_"+sGXsfl_38_fel_idx;
         edtSolicitudesRelacionesFechaModi_Internalname = "SOLICITUDESRELACIONESFECHAMODI_"+sGXsfl_38_fel_idx;
      }

      protected void AddRow0Q32( )
      {
         nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_3832( ) ;
         SendRow0Q32( ) ;
      }

      protected void SendRow0Q32( )
      {
         Gridlevel_relacionesRow = GXWebRow.GetNew(context);
         if ( subGridlevel_relaciones_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_relaciones_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_relaciones_Class, "") != 0 )
            {
               subGridlevel_relaciones_Linesclass = subGridlevel_relaciones_Class+"Odd";
            }
         }
         else if ( subGridlevel_relaciones_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_relaciones_Backstyle = 0;
            subGridlevel_relaciones_Backcolor = subGridlevel_relaciones_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_relaciones_Class, "") != 0 )
            {
               subGridlevel_relaciones_Linesclass = subGridlevel_relaciones_Class+"Uniform";
            }
         }
         else if ( subGridlevel_relaciones_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_relaciones_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_relaciones_Class, "") != 0 )
            {
               subGridlevel_relaciones_Linesclass = subGridlevel_relaciones_Class+"Odd";
            }
            subGridlevel_relaciones_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_relaciones_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_relaciones_Backstyle = 1;
            if ( ((int)((nGXsfl_38_idx) % (2))) == 0 )
            {
               subGridlevel_relaciones_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_relaciones_Class, "") != 0 )
               {
                  subGridlevel_relaciones_Linesclass = subGridlevel_relaciones_Class+"Even";
               }
            }
            else
            {
               subGridlevel_relaciones_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_relaciones_Class, "") != 0 )
               {
                  subGridlevel_relaciones_Linesclass = subGridlevel_relaciones_Class+"Odd";
               }
            }
         }
         imgprompt_142_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00o1.aspx"+"',["+"'"+GXUtil.ValueEncode( StringUtil.StringReplace( StringUtil.RTrim( A141EstadoSGTipo), "'", "\\'"))+"'"+","+"{Ctrl:gx.dom.el('"+"ESTADOSGID_"+sGXsfl_38_idx+"'), id:'"+"ESTADOSGID_"+sGXsfl_38_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_32_"+sGXsfl_38_idx+","+"'', false"+","+"false"+");");
         imgprompt_120_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"profesionalesprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROFESIONALESID_"+sGXsfl_38_idx+"'), id:'"+"PROFESIONALESID_"+sGXsfl_38_idx+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_idx+"'), id:'"+"PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_idx+"'"+",IOType:'inout'}"+"],"+"gx.dom.form()."+"nIsMod_32_"+sGXsfl_38_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_32_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_relacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRelacionesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A140RelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A140RelacionesId), "ZZZZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRelacionesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtRelacionesId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_32_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_relacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_120_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_120_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_relacionesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_120_Internalname,(string)sImgUrl,(string)imgprompt_120_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_120_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_32_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_relacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPrimerNombre_Internalname,StringUtil.RTrim( A166ProfesionalesPrimerNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesPrimerNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesPrimerNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_32_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_relacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoPrimero_Internalname,StringUtil.RTrim( A167ProfesionalesApellidoPrimero),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoPrimero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesApellidoPrimero_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_relacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoSGTipo_Internalname,StringUtil.RTrim( A141EstadoSGTipo),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoSGTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtEstadoSGTipo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         GXAESTADOSGID_html0Q32( ) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_32_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_38_idx + "',38)\"";
         GXCCtl = "ESTADOSGID_" + sGXsfl_38_idx;
         dynEstadoSGId.Name = GXCCtl;
         dynEstadoSGId.WebTags = "";
         /* ComboBox */
         Gridlevel_relacionesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynEstadoSGId,(string)dynEstadoSGId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A142EstadoSGId), 5, 0)),(short)1,(string)dynEstadoSGId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynEstadoSGId.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"",(bool)true,(short)0});
         dynEstadoSGId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A142EstadoSGId), 5, 0));
         AssignProp("", false, dynEstadoSGId_Internalname, "Values", (string)(dynEstadoSGId.ToJavascriptSource()), !bGXsfl_38_Refreshing);
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_142_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_142_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_relacionesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_142_Internalname,(string)sImgUrl,(string)imgprompt_142_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_142_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_32_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_relacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesRelacionesFechaAlta_Internalname,context.localUtil.TToC( A219SolicitudesRelacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A219SolicitudesRelacionesFechaAlta, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,45);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesRelacionesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSolicitudesRelacionesFechaAlta_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_32_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_relacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesRelacionesFechaModi_Internalname,context.localUtil.TToC( A220SolicitudesRelacionesFechaModi, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A220SolicitudesRelacionesFechaModi, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,46);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesRelacionesFechaModi_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSolicitudesRelacionesFechaModi_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_relacionesRow);
         send_integrity_lvl_hashes0Q32( ) ;
         GXCCtl = "Z140RelacionesId_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z140RelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z219SolicitudesRelacionesFechaAlta_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z219SolicitudesRelacionesFechaAlta, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z220SolicitudesRelacionesFechaModi_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z220SolicitudesRelacionesFechaModi, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z120ProfesionalesId_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z120ProfesionalesId));
         GXCCtl = "Z141EstadoSGTipo_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z141EstadoSGTipo));
         GXCCtl = "Z142EstadoSGId_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z142EstadoSGId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "O120ProfesionalesId_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( O120ProfesionalesId));
         GXCCtl = "nRcdDeleted_32_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_32), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_32_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_32), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_32_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_32), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "N140RelacionesId_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(A140RelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "N120ProfesionalesId_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( A120ProfesionalesId));
         GXCCtl = "N142EstadoSGId_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(A142EstadoSGId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GXCCtl = "vSOLICITUDESID_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "RELACIONESID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRelacionesId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSGTIPO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoSGTipo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSGID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadoSGId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESRELACIONESFECHAALTA_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesRelacionesFechaAlta_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESRELACIONESFECHAMODI_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesRelacionesFechaModi_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_120_"+sGXsfl_38_idx+"Link", StringUtil.RTrim( imgprompt_120_Link));
         GxWebStd.gx_hidden_field( context, "PROMPT_142_"+sGXsfl_38_idx+"Link", StringUtil.RTrim( imgprompt_142_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_relacionesContainer.AddRow(Gridlevel_relacionesRow);
      }

      protected void ReadRow0Q32( )
      {
         nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_3832( ) ;
         edtRelacionesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RELACIONESID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfesionalesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfesionalesPrimerNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfesionalesApellidoPrimero_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtEstadoSGTipo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGTIPO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynEstadoSGId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSolicitudesRelacionesFechaAlta_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SOLICITUDESRELACIONESFECHAALTA_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSolicitudesRelacionesFechaModi_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SOLICITUDESRELACIONESFECHAMODI_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_120_Link = cgiGet( "PROMPT_120_"+sGXsfl_38_idx+"Link");
         imgprompt_120_Link = cgiGet( "PROMPT_142_"+sGXsfl_38_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtRelacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRelacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "RELACIONESID_" + sGXsfl_38_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRelacionesId_Internalname;
            wbErr = true;
            A140RelacionesId = 0;
         }
         else
         {
            A140RelacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtRelacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
         A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
         A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
         A141EstadoSGTipo = cgiGet( edtEstadoSGTipo_Internalname);
         dynEstadoSGId.Name = dynEstadoSGId_Internalname;
         dynEstadoSGId.CurrentValue = cgiGet( dynEstadoSGId_Internalname);
         A142EstadoSGId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynEstadoSGId_Internalname), "."), 18, MidpointRounding.ToEven));
         A219SolicitudesRelacionesFechaAlta = context.localUtil.CToT( cgiGet( edtSolicitudesRelacionesFechaAlta_Internalname));
         A220SolicitudesRelacionesFechaModi = context.localUtil.CToT( cgiGet( edtSolicitudesRelacionesFechaModi_Internalname));
         GXCCtl = "Z140RelacionesId_" + sGXsfl_38_idx;
         Z140RelacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z219SolicitudesRelacionesFechaAlta_" + sGXsfl_38_idx;
         Z219SolicitudesRelacionesFechaAlta = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         GXCCtl = "Z220SolicitudesRelacionesFechaModi_" + sGXsfl_38_idx;
         Z220SolicitudesRelacionesFechaModi = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         GXCCtl = "Z120ProfesionalesId_" + sGXsfl_38_idx;
         Z120ProfesionalesId = cgiGet( GXCCtl);
         GXCCtl = "Z141EstadoSGTipo_" + sGXsfl_38_idx;
         Z141EstadoSGTipo = cgiGet( GXCCtl);
         GXCCtl = "Z142EstadoSGId_" + sGXsfl_38_idx;
         Z142EstadoSGId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "O120ProfesionalesId_" + sGXsfl_38_idx;
         O120ProfesionalesId = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_32_" + sGXsfl_38_idx;
         nRcdDeleted_32 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_32_" + sGXsfl_38_idx;
         nRcdExists_32 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_32_" + sGXsfl_38_idx;
         nIsMod_32 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "N140RelacionesId_" + sGXsfl_38_idx;
         N140RelacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "N120ProfesionalesId_" + sGXsfl_38_idx;
         N120ProfesionalesId = cgiGet( GXCCtl);
         GXCCtl = "N142EstadoSGId_" + sGXsfl_38_idx;
         N142EstadoSGId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtSolicitudesRelacionesFechaModi_Enabled = edtSolicitudesRelacionesFechaModi_Enabled;
         defedtSolicitudesRelacionesFechaAlta_Enabled = edtSolicitudesRelacionesFechaAlta_Enabled;
         defdynEstadoSGId_Enabled = dynEstadoSGId.Enabled;
         defedtEstadoSGTipo_Enabled = edtEstadoSGTipo_Enabled;
         defedtProfesionalesId_Enabled = edtProfesionalesId_Enabled;
         defedtRelacionesId_Enabled = edtRelacionesId_Enabled;
         defedtRelacionesId_Enabled = edtRelacionesId_Enabled;
      }

      protected void ConfirmValues0Q0( )
      {
         nGXsfl_38_idx = 0;
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_3832( ) ;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_3832( ) ;
            ChangePostValue( "Z140RelacionesId_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z140RelacionesId_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z140RelacionesId_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z219SolicitudesRelacionesFechaAlta_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z219SolicitudesRelacionesFechaAlta_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z219SolicitudesRelacionesFechaAlta_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z220SolicitudesRelacionesFechaModi_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z220SolicitudesRelacionesFechaModi_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z220SolicitudesRelacionesFechaModi_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z120ProfesionalesId_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z141EstadoSGTipo_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z141EstadoSGTipo_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z141EstadoSGTipo_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z142EstadoSGId_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z142EstadoSGId_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z142EstadoSGId_"+sGXsfl_38_idx) ;
         }
         ChangePostValue( "O120ProfesionalesId", cgiGet( "T120ProfesionalesId")) ;
         DeletePostValue( "T120ProfesionalesId") ;
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
         GXEncryptionTmp = "solicitudesrelacion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SolicitudesID,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("solicitudesrelacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"SolicitudesRelacion");
         forbiddenHiddens.Add("SolicitudesID", context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("SolicitudesNombre", StringUtil.RTrim( context.localUtil.Format( A171SolicitudesNombre, "")));
         forbiddenHiddens.Add("Insert_ProveedorID", context.localUtil.Format( (decimal)(AV13Insert_ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("SolicitudServicioOrigenPago", StringUtil.RTrim( context.localUtil.Format( AV21SolicitudServicioOrigenPago, "")));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("SolicitudesLiqProf", context.localUtil.Format( (decimal)(A688SolicitudesLiqProf), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("CuponId", context.localUtil.Format( (decimal)(A1013CuponId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("CancelacionTipificacionId", context.localUtil.Format( (decimal)(A996CancelacionTipificacionId), "ZZZZZZZZZZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("solicitudesrelacion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z127SolicitudesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z171SolicitudesNombre", StringUtil.RTrim( Z171SolicitudesNombre));
         GxWebStd.gx_hidden_field( context, "Z688SolicitudesLiqProf", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z688SolicitudesLiqProf), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z996CancelacionTipificacionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z996CancelacionTipificacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z1013CuponId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1013CuponId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_38", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_38_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vROLENAME", StringUtil.RTrim( AV15RoleName));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CUPONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1013CuponId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CANCELACIONTIPIFICACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A996CancelacionTipificacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESLIQPROF", StringUtil.LTrim( StringUtil.NToC( (decimal)(A688SolicitudesLiqProf), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, "vSOLICITUDSERVICIOORIGENPAGO", StringUtil.RTrim( AV21SolicitudServicioOrigenPago));
         GxWebStd.gx_boolean_hidden_field( context, "vPROFESIONALESTIENEDEUDA", AV19ProfesionalesTieneDeuda);
         GxWebStd.gx_boolean_hidden_field( context, "vPUEDEACEPTAR", AV20PuedeAceptar);
         GxWebStd.gx_boolean_hidden_field( context, "vFORZARPREPAGO", AV18ForzarPrepago);
         GxWebStd.gx_hidden_field( context, "ESTADOSGNOMBRE", StringUtil.RTrim( A143EstadoSGNombre));
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
         GXEncryptionTmp = "solicitudesrelacion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SolicitudesID,18,0));
         return formatLink("solicitudesrelacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "SolicitudesRelacion" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Solicitudes Relacion", "") ;
      }

      protected void InitializeNonKey0Q30( )
      {
         A133ProveedorID = 0;
         AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         A171SolicitudesNombre = "";
         AssignAttri("", false, "A171SolicitudesNombre", A171SolicitudesNombre);
         A688SolicitudesLiqProf = 0;
         n688SolicitudesLiqProf = false;
         AssignAttri("", false, "A688SolicitudesLiqProf", StringUtil.LTrimStr( (decimal)(A688SolicitudesLiqProf), 18, 0));
         A1013CuponId = 1234;
         n1013CuponId = false;
         AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
         A996CancelacionTipificacionId = 0;
         AssignAttri("", false, "A996CancelacionTipificacionId", StringUtil.LTrimStr( (decimal)(A996CancelacionTipificacionId), 18, 0));
         Z171SolicitudesNombre = "";
         Z688SolicitudesLiqProf = 0;
         Z133ProveedorID = 0;
         Z996CancelacionTipificacionId = 0;
         Z1013CuponId = 0;
      }

      protected void InitAll0Q30( )
      {
         A127SolicitudesID = 0;
         AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
         InitializeNonKey0Q30( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1013CuponId = i1013CuponId;
         n1013CuponId = false;
         AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
         A996CancelacionTipificacionId = i996CancelacionTipificacionId;
         AssignAttri("", false, "A996CancelacionTipificacionId", StringUtil.LTrimStr( (decimal)(A996CancelacionTipificacionId), 18, 0));
      }

      protected void InitializeNonKey0Q32( )
      {
         A141EstadoSGTipo = "";
         AV19ProfesionalesTieneDeuda = false;
         AssignAttri("", false, "AV19ProfesionalesTieneDeuda", AV19ProfesionalesTieneDeuda);
         AV20PuedeAceptar = false;
         AssignAttri("", false, "AV20PuedeAceptar", AV20PuedeAceptar);
         AV18ForzarPrepago = false;
         AssignAttri("", false, "AV18ForzarPrepago", AV18ForzarPrepago);
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A143EstadoSGNombre = "";
         AssignAttri("", false, "A143EstadoSGNombre", A143EstadoSGNombre);
         A219SolicitudesRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         A220SolicitudesRelacionesFechaModi = (DateTime)(DateTime.MinValue);
         A142EstadoSGId = 1;
         O120ProfesionalesId = A120ProfesionalesId;
         Z219SolicitudesRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         Z220SolicitudesRelacionesFechaModi = (DateTime)(DateTime.MinValue);
         Z120ProfesionalesId = "";
         Z141EstadoSGTipo = "";
         Z142EstadoSGId = 0;
      }

      protected void InitAll0Q32( )
      {
         A140RelacionesId = 0;
         InitializeNonKey0Q32( ) ;
      }

      protected void StandaloneModalInsert0Q32( )
      {
         A141EstadoSGTipo = i141EstadoSGTipo;
         A142EstadoSGId = i142EstadoSGId;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202692821324514", true, true, false);
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
         context.AddJavascriptSource("solicitudesrelacion.js", "?202692821324514", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties32( )
      {
         edtSolicitudesRelacionesFechaModi_Enabled = defedtSolicitudesRelacionesFechaModi_Enabled;
         AssignProp("", false, edtSolicitudesRelacionesFechaModi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesRelacionesFechaModi_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtSolicitudesRelacionesFechaAlta_Enabled = defedtSolicitudesRelacionesFechaAlta_Enabled;
         AssignProp("", false, edtSolicitudesRelacionesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesRelacionesFechaAlta_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         dynEstadoSGId.Enabled = defdynEstadoSGId_Enabled;
         AssignProp("", false, dynEstadoSGId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadoSGId.Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtEstadoSGTipo_Enabled = defedtEstadoSGTipo_Enabled;
         AssignProp("", false, edtEstadoSGTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoSGTipo_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtProfesionalesId_Enabled = defedtProfesionalesId_Enabled;
         AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtRelacionesId_Enabled = defedtRelacionesId_Enabled;
         AssignProp("", false, edtRelacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelacionesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtRelacionesId_Enabled = defedtRelacionesId_Enabled;
         AssignProp("", false, edtRelacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelacionesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
      }

      protected void StartGridControl38( )
      {
         Gridlevel_relacionesContainer.AddObjectProperty("GridName", "Gridlevel_relaciones");
         Gridlevel_relacionesContainer.AddObjectProperty("Header", subGridlevel_relaciones_Header);
         Gridlevel_relacionesContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_relacionesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_relacionesContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A140RelacionesId), 18, 0, ".", ""))));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRelacionesId_Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A166ProfesionalesPrimerNombre)));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A167ProfesionalesApellidoPrimero)));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A141EstadoSGTipo)));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoSGTipo_Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A142EstadoSGId), 5, 0, ".", ""))));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadoSGId.Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A219SolicitudesRelacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesRelacionesFechaAlta_Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_relacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A220SolicitudesRelacionesFechaModi, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
         Gridlevel_relacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesRelacionesFechaModi_Enabled), 5, 0, ".", "")));
         Gridlevel_relacionesContainer.AddColumnProperties(Gridlevel_relacionesColumn);
         Gridlevel_relacionesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Selectedindex), 4, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Allowselection), 1, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Allowhovering), 1, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_relacionesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_relaciones_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtSolicitudesID_Internalname = "SOLICITUDESID";
         edtSolicitudesNombre_Internalname = "SOLICITUDESNOMBRE";
         edtavAdmin_Internalname = "vADMIN";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtRelacionesId_Internalname = "RELACIONESID";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO";
         edtEstadoSGTipo_Internalname = "ESTADOSGTIPO";
         dynEstadoSGId_Internalname = "ESTADOSGID";
         edtSolicitudesRelacionesFechaAlta_Internalname = "SOLICITUDESRELACIONESFECHAALTA";
         edtSolicitudesRelacionesFechaModi_Internalname = "SOLICITUDESRELACIONESFECHAMODI";
         divTableleaflevel_relaciones_Internalname = "TABLELEAFLEVEL_RELACIONES";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_120_Internalname = "PROMPT_120";
         imgprompt_142_Internalname = "PROMPT_142";
         subGridlevel_relaciones_Internalname = "GRIDLEVEL_RELACIONES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_relaciones_Allowcollapsing = 0;
         subGridlevel_relaciones_Allowselection = 0;
         subGridlevel_relaciones_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Solicitudes Relacion", "");
         edtSolicitudesRelacionesFechaModi_Jsonclick = "";
         edtSolicitudesRelacionesFechaAlta_Jsonclick = "";
         imgprompt_142_Visible = 1;
         imgprompt_142_Link = "";
         dynEstadoSGId_Jsonclick = "";
         edtEstadoSGTipo_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesPrimerNombre_Jsonclick = "";
         imgprompt_120_Visible = 1;
         imgprompt_120_Link = "";
         imgprompt_120_Visible = 1;
         edtProfesionalesId_Jsonclick = "";
         edtRelacionesId_Jsonclick = "";
         subGridlevel_relaciones_Class = "WorkWith";
         subGridlevel_relaciones_Backcolorstyle = 0;
         edtSolicitudesRelacionesFechaModi_Enabled = 0;
         edtSolicitudesRelacionesFechaAlta_Enabled = 0;
         dynEstadoSGId.Enabled = 1;
         edtEstadoSGTipo_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesId_Enabled = 1;
         edtRelacionesId_Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtavAdmin_Jsonclick = "";
         edtavAdmin_Enabled = 0;
         edtSolicitudesNombre_Jsonclick = "";
         edtSolicitudesNombre_Enabled = 0;
         edtSolicitudesID_Jsonclick = "";
         edtSolicitudesID_Enabled = 0;
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

      protected void GXDLAESTADOSGID0Q32( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAESTADOSGID_data0Q32( ) ;
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

      protected void GXAESTADOSGID_html0Q32( )
      {
         int gxdynajaxvalue;
         GXDLAESTADOSGID_data0Q32( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynEstadoSGId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynEstadoSGId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 5, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAESTADOSGID_data0Q32( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000Q30 */
         pr_default.execute(28);
         while ( (pr_default.getStatus(28) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000Q30_A142EstadoSGId[0]), 5, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000Q30_A143EstadoSGNombre[0]));
            pr_default.readNext(28);
         }
         pr_default.close(28);
      }

      protected void XC_26_0Q32( string A120ProfesionalesId ,
                                 string AV21SolicitudServicioOrigenPago ,
                                 string AV15RoleName )
      {
         if ( ( StringUtil.StrCmp(AV21SolicitudServicioOrigenPago, "F") == 0 ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV15RoleName), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) )
         {
            new GeneXus.Programs.apis.verificartrabajosporestadodeuda(context ).execute(  A120ProfesionalesId,  3, out  AV19ProfesionalesTieneDeuda, out  AV20PuedeAceptar) ;
            AssignAttri("", false, "AV19ProfesionalesTieneDeuda", AV19ProfesionalesTieneDeuda);
            AssignAttri("", false, "AV20PuedeAceptar", AV20PuedeAceptar);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV19ProfesionalesTieneDeuda))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV20PuedeAceptar))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_27_0Q32( string A120ProfesionalesId ,
                                 string AV21SolicitudServicioOrigenPago ,
                                 string AV15RoleName )
      {
         if ( ( StringUtil.StrCmp(AV21SolicitudServicioOrigenPago, "F") == 0 ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV15RoleName), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) )
         {
            new GeneXus.Programs.apis.validaforzarprepago(context ).execute(  A120ProfesionalesId, out  AV18ForzarPrepago) ;
            AssignAttri("", false, "AV18ForzarPrepago", AV18ForzarPrepago);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV18ForzarPrepago))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_relaciones_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_3832( ) ;
         while ( nGXsfl_38_idx <= nRC_GXsfl_38 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0Q32( ) ;
            standaloneModal0Q32( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0Q32( ) ;
            nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_3832( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_relacionesContainer)) ;
         /* End function gxnrGridlevel_relaciones_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "ESTADOSGID_" + sGXsfl_38_idx;
         dynEstadoSGId.Name = GXCCtl;
         dynEstadoSGId.WebTags = "";
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
         n688SolicitudesLiqProf = false;
         A142EstadoSGId = (int)(Math.Round(NumberUtil.Val( dynEstadoSGId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000Q31 */
         pr_default.execute(29, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROFESIONALESID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
         }
         A166ProfesionalesPrimerNombre = T000Q31_A166ProfesionalesPrimerNombre[0];
         A167ProfesionalesApellidoPrimero = T000Q31_A167ProfesionalesApellidoPrimero[0];
         pr_default.close(29);
         if ( ( StringUtil.StrCmp(AV21SolicitudServicioOrigenPago, "F") == 0 ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV15RoleName), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) )
         {
            new GeneXus.Programs.apis.verificartrabajosporestadodeuda(context ).execute(  A120ProfesionalesId,  3, out  AV19ProfesionalesTieneDeuda, out  AV20PuedeAceptar) ;
         }
         if ( ( StringUtil.StrCmp(AV21SolicitudServicioOrigenPago, "F") == 0 ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV15RoleName), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) )
         {
            new GeneXus.Programs.apis.validaforzarprepago(context ).execute(  A120ProfesionalesId, out  AV18ForzarPrepago) ;
         }
         if ( ( StringUtil.StrCmp(AV21SolicitudServicioOrigenPago, "F") == 0 ) && ! AV20PuedeAceptar && ! ( StringUtil.StrCmp(StringUtil.Trim( AV15RoleName), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) && ( IsIns( )  || ( IsUpd( )  && ( StringUtil.StrCmp(A120ProfesionalesId, O120ProfesionalesId) != 0 ) ) ) )
         {
            GX_msglist.addItem(context.GetMessage( "El profesional no puede ser asignado: posee deuda.", ""), 1, "PROFESIONALESID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
         }
         if ( ( StringUtil.StrCmp(AV21SolicitudServicioOrigenPago, "F") == 0 ) && ! AV20PuedeAceptar && ! ( StringUtil.StrCmp(StringUtil.Trim( AV15RoleName), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) && ( IsIns( )  || ( IsUpd( )  && ( StringUtil.StrCmp(A120ProfesionalesId, O120ProfesionalesId) != 0 ) ) ) )
         {
            GX_msglist.addItem(context.GetMessage( "El profesional debe ser asignado a cobro prepago.", ""), 1, "PROFESIONALESID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
         }
         if ( ( StringUtil.StrCmp(A120ProfesionalesId, O120ProfesionalesId) != 0 ) && ! ( (0==A688SolicitudesLiqProf) || T000Q7_n688SolicitudesLiqProf[0] ) && ( A688SolicitudesLiqProf != 0 ) )
         {
            GX_msglist.addItem(context.GetMessage( "No se puede cambiar el profesional: la solicitud ya forma parte de la liquidación Nro ", "")+StringUtil.Str( (decimal)(A688SolicitudesLiqProf), 18, 0), 1, "PROFESIONALESID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A166ProfesionalesPrimerNombre", StringUtil.RTrim( A166ProfesionalesPrimerNombre));
         AssignAttri("", false, "A167ProfesionalesApellidoPrimero", StringUtil.RTrim( A167ProfesionalesApellidoPrimero));
         AssignAttri("", false, "AV19ProfesionalesTieneDeuda", AV19ProfesionalesTieneDeuda);
         AssignAttri("", false, "AV20PuedeAceptar", AV20PuedeAceptar);
         AssignAttri("", false, "AV18ForzarPrepago", AV18ForzarPrepago);
      }

      public void Valid_Estadosgid( )
      {
         A142EstadoSGId = (int)(Math.Round(NumberUtil.Val( dynEstadoSGId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000Q32 */
         pr_default.execute(30, new Object[] {A141EstadoSGTipo, A142EstadoSGId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado SG", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSGID");
            AnyError = 1;
            GX_FocusControl = dynEstadoSGId_Internalname;
         }
         A143EstadoSGNombre = T000Q32_A143EstadoSGNombre[0];
         pr_default.close(30);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A143EstadoSGNombre", StringUtil.RTrim( A143EstadoSGNombre));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A171SolicitudesNombre',fld:'SOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV13Insert_ProveedorID',fld:'vINSERT_PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21SolicitudServicioOrigenPago',fld:'vSOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A1013CuponId',fld:'CUPONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A996CancelacionTipificacionId',fld:'CANCELACIONTIPIFICACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120Q2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESID","{handler:'Valid_Solicitudesid',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESID",",oparms:[]}");
         setEventMetadata("VALIDV_ADMIN","{handler:'Validv_Admin',iparms:[]");
         setEventMetadata("VALIDV_ADMIN",",oparms:[]}");
         setEventMetadata("VALID_RELACIONESID","{handler:'Valid_Relacionesid',iparms:[]");
         setEventMetadata("VALID_RELACIONESID",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'O120ProfesionalesId',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'},{av:'AV21SolicitudServicioOrigenPago',fld:'vSOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'AV15RoleName',fld:'vROLENAME',pic:'',type:'char'},{av:'AV20PuedeAceptar',fld:'vPUEDEACEPTAR',pic:'',type:'boolean'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynEstadoSGId'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A166ProfesionalesPrimerNombre',fld:'PROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'A167ProfesionalesApellidoPrimero',fld:'PROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV19ProfesionalesTieneDeuda',fld:'vPROFESIONALESTIENEDEUDA',pic:'',type:'boolean'},{av:'AV18ForzarPrepago',fld:'vFORZARPREPAGO',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[{av:'A166ProfesionalesPrimerNombre',fld:'PROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'A167ProfesionalesApellidoPrimero',fld:'PROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV19ProfesionalesTieneDeuda',fld:'vPROFESIONALESTIENEDEUDA',pic:'',type:'boolean'},{av:'AV20PuedeAceptar',fld:'vPUEDEACEPTAR',pic:'',type:'boolean'},{av:'AV18ForzarPrepago',fld:'vFORZARPREPAGO',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_ESTADOSGTIPO","{handler:'Valid_Estadosgtipo',iparms:[]");
         setEventMetadata("VALID_ESTADOSGTIPO",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSGID","{handler:'Valid_Estadosgid',iparms:[{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'dynEstadoSGId'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A143EstadoSGNombre',fld:'ESTADOSGNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("VALID_ESTADOSGID",",oparms:[{av:'A143EstadoSGNombre',fld:'ESTADOSGNOMBRE',pic:'',type:'char'}]}");
         setEventMetadata("NULL","{handler:'Valid_Solicitudesrelacionesfechamodi',iparms:[]");
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
         pr_default.close(29);
         pr_default.close(25);
         pr_default.close(30);
         pr_default.close(26);
         pr_default.close(5);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z171SolicitudesNombre = "";
         Z219SolicitudesRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         Z220SolicitudesRelacionesFechaModi = (DateTime)(DateTime.MinValue);
         Z120ProfesionalesId = "";
         Z141EstadoSGTipo = "";
         O120ProfesionalesId = "";
         N120ProfesionalesId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A120ProfesionalesId = "";
         AV21SolicitudServicioOrigenPago = "";
         AV15RoleName = "";
         A141EstadoSGTipo = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         AV25Admin = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A171SolicitudesNombre = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_relacionesContainer = new GXWebGrid( context);
         sMode32 = "";
         GX_FocusControl = "";
         sStyleString = "";
         AV27Pgmname = "";
         A143EstadoSGNombre = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode30 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A166ProfesionalesPrimerNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A219SolicitudesRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         A220SolicitudesRelacionesFechaModi = (DateTime)(DateTime.MinValue);
         T120ProfesionalesId = "";
         AV12WebSession = context.GetSession();
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         T000Q9_A127SolicitudesID = new long[1] ;
         T000Q9_A171SolicitudesNombre = new string[] {""} ;
         T000Q9_A688SolicitudesLiqProf = new long[1] ;
         T000Q9_n688SolicitudesLiqProf = new bool[] {false} ;
         T000Q9_A133ProveedorID = new long[1] ;
         T000Q9_A996CancelacionTipificacionId = new long[1] ;
         T000Q9_A1013CuponId = new long[1] ;
         T000Q9_n1013CuponId = new bool[] {false} ;
         T000Q8_A133ProveedorID = new long[1] ;
         T000Q10_A133ProveedorID = new long[1] ;
         T000Q11_A127SolicitudesID = new long[1] ;
         T000Q7_A127SolicitudesID = new long[1] ;
         T000Q7_A171SolicitudesNombre = new string[] {""} ;
         T000Q7_A688SolicitudesLiqProf = new long[1] ;
         T000Q7_n688SolicitudesLiqProf = new bool[] {false} ;
         T000Q7_A133ProveedorID = new long[1] ;
         T000Q7_A996CancelacionTipificacionId = new long[1] ;
         T000Q7_A1013CuponId = new long[1] ;
         T000Q7_n1013CuponId = new bool[] {false} ;
         T000Q12_A127SolicitudesID = new long[1] ;
         T000Q13_A127SolicitudesID = new long[1] ;
         T000Q6_A127SolicitudesID = new long[1] ;
         T000Q6_A171SolicitudesNombre = new string[] {""} ;
         T000Q6_A688SolicitudesLiqProf = new long[1] ;
         T000Q6_n688SolicitudesLiqProf = new bool[] {false} ;
         T000Q6_A133ProveedorID = new long[1] ;
         T000Q6_A996CancelacionTipificacionId = new long[1] ;
         T000Q6_A1013CuponId = new long[1] ;
         T000Q6_n1013CuponId = new bool[] {false} ;
         T000Q14_A127SolicitudesID = new long[1] ;
         T000Q17_A127SolicitudesID = new long[1] ;
         T000Q17_A988ArchivoId = new long[1] ;
         T000Q18_A127SolicitudesID = new long[1] ;
         T000Q18_A134SolicitudesItemsID = new short[1] ;
         T000Q19_A127SolicitudesID = new long[1] ;
         Z166ProfesionalesPrimerNombre = "";
         Z167ProfesionalesApellidoPrimero = "";
         Z143EstadoSGNombre = "";
         T000Q5_A143EstadoSGNombre = new string[] {""} ;
         T000Q20_A127SolicitudesID = new long[1] ;
         T000Q20_A140RelacionesId = new long[1] ;
         T000Q20_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T000Q20_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T000Q20_A143EstadoSGNombre = new string[] {""} ;
         T000Q20_A219SolicitudesRelacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T000Q20_A220SolicitudesRelacionesFechaModi = new DateTime[] {DateTime.MinValue} ;
         T000Q20_A120ProfesionalesId = new string[] {""} ;
         T000Q20_A141EstadoSGTipo = new string[] {""} ;
         T000Q20_A142EstadoSGId = new int[1] ;
         T000Q4_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T000Q4_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T000Q21_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T000Q21_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T000Q22_A143EstadoSGNombre = new string[] {""} ;
         T000Q23_A127SolicitudesID = new long[1] ;
         T000Q23_A140RelacionesId = new long[1] ;
         T000Q3_A127SolicitudesID = new long[1] ;
         T000Q3_A140RelacionesId = new long[1] ;
         T000Q3_A219SolicitudesRelacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T000Q3_A220SolicitudesRelacionesFechaModi = new DateTime[] {DateTime.MinValue} ;
         T000Q3_A120ProfesionalesId = new string[] {""} ;
         T000Q3_A141EstadoSGTipo = new string[] {""} ;
         T000Q3_A142EstadoSGId = new int[1] ;
         T000Q2_A127SolicitudesID = new long[1] ;
         T000Q2_A140RelacionesId = new long[1] ;
         T000Q2_A219SolicitudesRelacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T000Q2_A220SolicitudesRelacionesFechaModi = new DateTime[] {DateTime.MinValue} ;
         T000Q2_A120ProfesionalesId = new string[] {""} ;
         T000Q2_A141EstadoSGTipo = new string[] {""} ;
         T000Q2_A142EstadoSGId = new int[1] ;
         T000Q27_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T000Q27_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T000Q28_A143EstadoSGNombre = new string[] {""} ;
         T000Q29_A127SolicitudesID = new long[1] ;
         T000Q29_A140RelacionesId = new long[1] ;
         Gridlevel_relacionesRow = new GXWebRow();
         subGridlevel_relaciones_Linesclass = "";
         ROClassString = "";
         imgprompt_120_gximage = "";
         sImgUrl = "";
         imgprompt_142_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i141EstadoSGTipo = "";
         Gridlevel_relacionesColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000Q30_A141EstadoSGTipo = new string[] {""} ;
         T000Q30_A127SolicitudesID = new long[1] ;
         T000Q30_A140RelacionesId = new long[1] ;
         T000Q30_A142EstadoSGId = new int[1] ;
         T000Q30_A143EstadoSGNombre = new string[] {""} ;
         T000Q31_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T000Q31_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T000Q32_A143EstadoSGNombre = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.solicitudesrelacion__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.solicitudesrelacion__default(),
            new Object[][] {
                new Object[] {
               T000Q2_A127SolicitudesID, T000Q2_A140RelacionesId, T000Q2_A219SolicitudesRelacionesFechaAlta, T000Q2_A220SolicitudesRelacionesFechaModi, T000Q2_A120ProfesionalesId, T000Q2_A141EstadoSGTipo, T000Q2_A142EstadoSGId
               }
               , new Object[] {
               T000Q3_A127SolicitudesID, T000Q3_A140RelacionesId, T000Q3_A219SolicitudesRelacionesFechaAlta, T000Q3_A220SolicitudesRelacionesFechaModi, T000Q3_A120ProfesionalesId, T000Q3_A141EstadoSGTipo, T000Q3_A142EstadoSGId
               }
               , new Object[] {
               T000Q4_A166ProfesionalesPrimerNombre, T000Q4_A167ProfesionalesApellidoPrimero
               }
               , new Object[] {
               T000Q5_A143EstadoSGNombre
               }
               , new Object[] {
               T000Q6_A127SolicitudesID, T000Q6_A171SolicitudesNombre, T000Q6_A688SolicitudesLiqProf, T000Q6_n688SolicitudesLiqProf, T000Q6_A133ProveedorID, T000Q6_A996CancelacionTipificacionId, T000Q6_A1013CuponId, T000Q6_n1013CuponId
               }
               , new Object[] {
               T000Q7_A127SolicitudesID, T000Q7_A171SolicitudesNombre, T000Q7_A688SolicitudesLiqProf, T000Q7_n688SolicitudesLiqProf, T000Q7_A133ProveedorID, T000Q7_A996CancelacionTipificacionId, T000Q7_A1013CuponId, T000Q7_n1013CuponId
               }
               , new Object[] {
               T000Q8_A133ProveedorID
               }
               , new Object[] {
               T000Q9_A127SolicitudesID, T000Q9_A171SolicitudesNombre, T000Q9_A688SolicitudesLiqProf, T000Q9_n688SolicitudesLiqProf, T000Q9_A133ProveedorID, T000Q9_A996CancelacionTipificacionId, T000Q9_A1013CuponId, T000Q9_n1013CuponId
               }
               , new Object[] {
               T000Q10_A133ProveedorID
               }
               , new Object[] {
               T000Q11_A127SolicitudesID
               }
               , new Object[] {
               T000Q12_A127SolicitudesID
               }
               , new Object[] {
               T000Q13_A127SolicitudesID
               }
               , new Object[] {
               T000Q14_A127SolicitudesID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Q17_A127SolicitudesID, T000Q17_A988ArchivoId
               }
               , new Object[] {
               T000Q18_A127SolicitudesID, T000Q18_A134SolicitudesItemsID
               }
               , new Object[] {
               T000Q19_A127SolicitudesID
               }
               , new Object[] {
               T000Q20_A127SolicitudesID, T000Q20_A140RelacionesId, T000Q20_A166ProfesionalesPrimerNombre, T000Q20_A167ProfesionalesApellidoPrimero, T000Q20_A143EstadoSGNombre, T000Q20_A219SolicitudesRelacionesFechaAlta, T000Q20_A220SolicitudesRelacionesFechaModi, T000Q20_A120ProfesionalesId, T000Q20_A141EstadoSGTipo, T000Q20_A142EstadoSGId
               }
               , new Object[] {
               T000Q21_A166ProfesionalesPrimerNombre, T000Q21_A167ProfesionalesApellidoPrimero
               }
               , new Object[] {
               T000Q22_A143EstadoSGNombre
               }
               , new Object[] {
               T000Q23_A127SolicitudesID, T000Q23_A140RelacionesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Q27_A166ProfesionalesPrimerNombre, T000Q27_A167ProfesionalesApellidoPrimero
               }
               , new Object[] {
               T000Q28_A143EstadoSGNombre
               }
               , new Object[] {
               T000Q29_A127SolicitudesID, T000Q29_A140RelacionesId
               }
               , new Object[] {
               T000Q30_A141EstadoSGTipo, T000Q30_A127SolicitudesID, T000Q30_A140RelacionesId, T000Q30_A142EstadoSGId, T000Q30_A143EstadoSGNombre
               }
               , new Object[] {
               T000Q31_A166ProfesionalesPrimerNombre, T000Q31_A167ProfesionalesApellidoPrimero
               }
               , new Object[] {
               T000Q32_A143EstadoSGNombre
               }
            }
         );
         Z1013CuponId = 1234;
         n1013CuponId = false;
         A1013CuponId = 1234;
         n1013CuponId = false;
         i1013CuponId = 1234;
         n1013CuponId = false;
         Z996CancelacionTipificacionId = 0;
         A996CancelacionTipificacionId = 0;
         i996CancelacionTipificacionId = 0;
         AV27Pgmname = "SolicitudesRelacion";
         Z142EstadoSGId = 1;
         N142EstadoSGId = 1;
         i142EstadoSGId = 1;
         A142EstadoSGId = 1;
      }

      private short nIsMod_32 ;
      private short nRcdDeleted_32 ;
      private short nRcdExists_32 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short nBlankRcdCount32 ;
      private short RcdFound32 ;
      private short nBlankRcdUsr32 ;
      private short RcdFound30 ;
      private short nIsDirty_32 ;
      private short subGridlevel_relaciones_Backcolorstyle ;
      private short subGridlevel_relaciones_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_relaciones_Allowselection ;
      private short subGridlevel_relaciones_Allowhovering ;
      private short subGridlevel_relaciones_Allowcollapsing ;
      private short subGridlevel_relaciones_Collapsed ;
      private int nRC_GXsfl_38 ;
      private int nGXsfl_38_idx=1 ;
      private int Z142EstadoSGId ;
      private int N142EstadoSGId ;
      private int A142EstadoSGId ;
      private int trnEnded ;
      private int edtSolicitudesID_Enabled ;
      private int edtSolicitudesNombre_Enabled ;
      private int edtavAdmin_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtRelacionesId_Enabled ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtEstadoSGTipo_Enabled ;
      private int edtSolicitudesRelacionesFechaAlta_Enabled ;
      private int edtSolicitudesRelacionesFechaModi_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV28GXV1 ;
      private int subGridlevel_relaciones_Backcolor ;
      private int subGridlevel_relaciones_Allbackcolor ;
      private int imgprompt_120_Visible ;
      private int imgprompt_142_Visible ;
      private int defedtSolicitudesRelacionesFechaModi_Enabled ;
      private int defedtSolicitudesRelacionesFechaAlta_Enabled ;
      private int defdynEstadoSGId_Enabled ;
      private int defedtEstadoSGTipo_Enabled ;
      private int defedtProfesionalesId_Enabled ;
      private int defedtRelacionesId_Enabled ;
      private int i142EstadoSGId ;
      private int idxLst ;
      private int subGridlevel_relaciones_Selectedindex ;
      private int subGridlevel_relaciones_Selectioncolor ;
      private int subGridlevel_relaciones_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long wcpOAV7SolicitudesID ;
      private long Z127SolicitudesID ;
      private long Z688SolicitudesLiqProf ;
      private long Z133ProveedorID ;
      private long Z996CancelacionTipificacionId ;
      private long Z1013CuponId ;
      private long N133ProveedorID ;
      private long Z140RelacionesId ;
      private long N140RelacionesId ;
      private long A133ProveedorID ;
      private long AV7SolicitudesID ;
      private long A127SolicitudesID ;
      private long A688SolicitudesLiqProf ;
      private long A1013CuponId ;
      private long A996CancelacionTipificacionId ;
      private long AV13Insert_ProveedorID ;
      private long GRIDLEVEL_RELACIONES_nFirstRecordOnPage ;
      private long A140RelacionesId ;
      private long i1013CuponId ;
      private long i996CancelacionTipificacionId ;
      private string sPrefix ;
      private string sGXsfl_38_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z171SolicitudesNombre ;
      private string Z120ProfesionalesId ;
      private string Z141EstadoSGTipo ;
      private string O120ProfesionalesId ;
      private string N120ProfesionalesId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A120ProfesionalesId ;
      private string AV21SolicitudServicioOrigenPago ;
      private string AV15RoleName ;
      private string A141EstadoSGTipo ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
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
      private string edtSolicitudesID_Internalname ;
      private string TempTags ;
      private string edtSolicitudesID_Jsonclick ;
      private string edtSolicitudesNombre_Internalname ;
      private string A171SolicitudesNombre ;
      private string edtSolicitudesNombre_Jsonclick ;
      private string edtavAdmin_Internalname ;
      private string edtavAdmin_Jsonclick ;
      private string divTableleaflevel_relaciones_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode32 ;
      private string edtRelacionesId_Internalname ;
      private string edtProfesionalesId_Internalname ;
      private string edtProfesionalesPrimerNombre_Internalname ;
      private string edtProfesionalesApellidoPrimero_Internalname ;
      private string edtEstadoSGTipo_Internalname ;
      private string dynEstadoSGId_Internalname ;
      private string edtSolicitudesRelacionesFechaAlta_Internalname ;
      private string edtSolicitudesRelacionesFechaModi_Internalname ;
      private string imgprompt_120_Link ;
      private string GX_FocusControl ;
      private string sStyleString ;
      private string subGridlevel_relaciones_Internalname ;
      private string AV27Pgmname ;
      private string A143EstadoSGNombre ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode30 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A166ProfesionalesPrimerNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string T120ProfesionalesId ;
      private string GXEncryptionTmp ;
      private string Z166ProfesionalesPrimerNombre ;
      private string Z167ProfesionalesApellidoPrimero ;
      private string Z143EstadoSGNombre ;
      private string imgprompt_120_Internalname ;
      private string imgprompt_142_Internalname ;
      private string sGXsfl_38_fel_idx="0001" ;
      private string subGridlevel_relaciones_Class ;
      private string subGridlevel_relaciones_Linesclass ;
      private string imgprompt_142_Link ;
      private string ROClassString ;
      private string edtRelacionesId_Jsonclick ;
      private string edtProfesionalesId_Jsonclick ;
      private string imgprompt_120_gximage ;
      private string sImgUrl ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtEstadoSGTipo_Jsonclick ;
      private string dynEstadoSGId_Jsonclick ;
      private string imgprompt_142_gximage ;
      private string edtSolicitudesRelacionesFechaAlta_Jsonclick ;
      private string edtSolicitudesRelacionesFechaModi_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i141EstadoSGTipo ;
      private string subGridlevel_relaciones_Header ;
      private string gxwrpcisep ;
      private DateTime Z219SolicitudesRelacionesFechaAlta ;
      private DateTime Z220SolicitudesRelacionesFechaModi ;
      private DateTime A219SolicitudesRelacionesFechaAlta ;
      private DateTime A220SolicitudesRelacionesFechaModi ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool bGXsfl_38_Refreshing=false ;
      private bool n688SolicitudesLiqProf ;
      private bool n1013CuponId ;
      private bool AV19ProfesionalesTieneDeuda ;
      private bool AV20PuedeAceptar ;
      private bool AV18ForzarPrepago ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool gxdyncontrolsrefreshing ;
      private bool ZV19ProfesionalesTieneDeuda ;
      private bool ZV20PuedeAceptar ;
      private bool ZV18ForzarPrepago ;
      private string AV25Admin ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_relacionesContainer ;
      private GXWebRow Gridlevel_relacionesRow ;
      private GXWebColumn Gridlevel_relacionesColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynEstadoSGId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] T000Q9_A127SolicitudesID ;
      private string[] T000Q9_A171SolicitudesNombre ;
      private long[] T000Q9_A688SolicitudesLiqProf ;
      private bool[] T000Q9_n688SolicitudesLiqProf ;
      private long[] T000Q9_A133ProveedorID ;
      private long[] T000Q9_A996CancelacionTipificacionId ;
      private long[] T000Q9_A1013CuponId ;
      private bool[] T000Q9_n1013CuponId ;
      private long[] T000Q8_A133ProveedorID ;
      private long[] T000Q10_A133ProveedorID ;
      private long[] T000Q11_A127SolicitudesID ;
      private long[] T000Q7_A127SolicitudesID ;
      private string[] T000Q7_A171SolicitudesNombre ;
      private long[] T000Q7_A688SolicitudesLiqProf ;
      private bool[] T000Q7_n688SolicitudesLiqProf ;
      private long[] T000Q7_A133ProveedorID ;
      private long[] T000Q7_A996CancelacionTipificacionId ;
      private long[] T000Q7_A1013CuponId ;
      private bool[] T000Q7_n1013CuponId ;
      private long[] T000Q12_A127SolicitudesID ;
      private long[] T000Q13_A127SolicitudesID ;
      private long[] T000Q6_A127SolicitudesID ;
      private string[] T000Q6_A171SolicitudesNombre ;
      private long[] T000Q6_A688SolicitudesLiqProf ;
      private bool[] T000Q6_n688SolicitudesLiqProf ;
      private long[] T000Q6_A133ProveedorID ;
      private long[] T000Q6_A996CancelacionTipificacionId ;
      private long[] T000Q6_A1013CuponId ;
      private bool[] T000Q6_n1013CuponId ;
      private long[] T000Q14_A127SolicitudesID ;
      private long[] T000Q17_A127SolicitudesID ;
      private long[] T000Q17_A988ArchivoId ;
      private long[] T000Q18_A127SolicitudesID ;
      private short[] T000Q18_A134SolicitudesItemsID ;
      private long[] T000Q19_A127SolicitudesID ;
      private string[] T000Q5_A143EstadoSGNombre ;
      private long[] T000Q20_A127SolicitudesID ;
      private long[] T000Q20_A140RelacionesId ;
      private string[] T000Q20_A166ProfesionalesPrimerNombre ;
      private string[] T000Q20_A167ProfesionalesApellidoPrimero ;
      private string[] T000Q20_A143EstadoSGNombre ;
      private DateTime[] T000Q20_A219SolicitudesRelacionesFechaAlta ;
      private DateTime[] T000Q20_A220SolicitudesRelacionesFechaModi ;
      private string[] T000Q20_A120ProfesionalesId ;
      private string[] T000Q20_A141EstadoSGTipo ;
      private int[] T000Q20_A142EstadoSGId ;
      private string[] T000Q4_A166ProfesionalesPrimerNombre ;
      private string[] T000Q4_A167ProfesionalesApellidoPrimero ;
      private string[] T000Q21_A166ProfesionalesPrimerNombre ;
      private string[] T000Q21_A167ProfesionalesApellidoPrimero ;
      private string[] T000Q22_A143EstadoSGNombre ;
      private long[] T000Q23_A127SolicitudesID ;
      private long[] T000Q23_A140RelacionesId ;
      private long[] T000Q3_A127SolicitudesID ;
      private long[] T000Q3_A140RelacionesId ;
      private DateTime[] T000Q3_A219SolicitudesRelacionesFechaAlta ;
      private DateTime[] T000Q3_A220SolicitudesRelacionesFechaModi ;
      private string[] T000Q3_A120ProfesionalesId ;
      private string[] T000Q3_A141EstadoSGTipo ;
      private int[] T000Q3_A142EstadoSGId ;
      private long[] T000Q2_A127SolicitudesID ;
      private long[] T000Q2_A140RelacionesId ;
      private DateTime[] T000Q2_A219SolicitudesRelacionesFechaAlta ;
      private DateTime[] T000Q2_A220SolicitudesRelacionesFechaModi ;
      private string[] T000Q2_A120ProfesionalesId ;
      private string[] T000Q2_A141EstadoSGTipo ;
      private int[] T000Q2_A142EstadoSGId ;
      private string[] T000Q27_A166ProfesionalesPrimerNombre ;
      private string[] T000Q27_A167ProfesionalesApellidoPrimero ;
      private string[] T000Q28_A143EstadoSGNombre ;
      private long[] T000Q29_A127SolicitudesID ;
      private long[] T000Q29_A140RelacionesId ;
      private string[] T000Q30_A141EstadoSGTipo ;
      private long[] T000Q30_A127SolicitudesID ;
      private long[] T000Q30_A140RelacionesId ;
      private int[] T000Q30_A142EstadoSGId ;
      private string[] T000Q30_A143EstadoSGNombre ;
      private string[] T000Q31_A166ProfesionalesPrimerNombre ;
      private string[] T000Q31_A167ProfesionalesApellidoPrimero ;
      private string[] T000Q32_A143EstadoSGNombre ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class solicitudesrelacion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class solicitudesrelacion__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000Q2;
        prmT000Q2 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@RelacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT000Q3;
        prmT000Q3 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@RelacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT000Q4;
        prmT000Q4 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000Q5;
        prmT000Q5 = new Object[] {
        new ParDef("@EstadoSGTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadoSGId",GXType.Int32,5,0)
        };
        Object[] prmT000Q6;
        prmT000Q6 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT000Q7;
        prmT000Q7 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT000Q8;
        prmT000Q8 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT000Q9;
        prmT000Q9 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT000Q10;
        prmT000Q10 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT000Q11;
        prmT000Q11 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT000Q12;
        prmT000Q12 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT000Q13;
        prmT000Q13 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT000Q14;
        prmT000Q14 = new Object[] {
        new ParDef("@SolicitudesNombre",GXType.NChar,100,0) ,
        new ParDef("@SolicitudesLiqProf",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@CancelacionTipificacionId",GXType.Decimal,18,0) ,
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true}
        };
        string cmdBufferT000Q14;
        cmdBufferT000Q14=" INSERT INTO [Solicitudes]([SolicitudesNombre], [SolicitudesLiqProf], [ProveedorID], [CancelacionTipificacionId], [CuponId], [SolicitudesTelefono], [SolicitudesMail], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID], [SolicitudesDireccion], [SolicitudesAutoEnumerar], [SolicitudesCotizacion], [SolicitudServicioSolCoti], [EstadosSolTipo], [EstadosSolId], [SolicitudesOtros1], [SolicitudesOtros2], [SolicitudesOtros3], [SolicitudesUsrAlta], [SolicitudesUsrActualizacion], [SolicitudesFechaAlta], [SolicitudesFechaActualizacion], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudesComentario], [MetodoPagosID], [SolicitudesNota], [SolicitudesNotificacion], [SolicitudServicioOrigenPago], [SolicitudesPagado], [SolicitudServicioComProv], [SolicitudServicioComProvP], [SolicitudServicioComALM], [SolicitudServicioComALMP], [ProveedorNombreAux], [SolicitudesSubTipo], [STMonedasId], [SolicitudesCalComi], [SolicitudesLiqProv], [MudanzaId], [SolicitudesComisionMetodoPago], [SolicitudesCostoXZona], [SolicitudesCostoXZComAlm], [SolicitudesCostoXZComAlmP], [SolicitudesDescuento], [STComerciosID], [PostulacionesId], [SolicitudesDuplicado], [SolicitudesSerialArchivo], [SolicitudesCostoPresupuesto], [SolicitudesURLOrigen], [SolicitudesDescuentoCupon], [TicketId]) VALUES(@SolicitudesNombre, @SolicitudesLiqProf, @ProveedorID, @CancelacionTipificacionId, @CuponId, '', '', convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0), convert(int, 0), '', '', convert(int, 0), '', '', '', convert(int, 0), convert(int, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', convert(int, 0), '', '', '', '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', '', convert(int, 0), "
        + " convert(bit, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0), convert(int, 0)); SELECT SCOPE_IDENTITY()" ;
        Object[] prmT000Q15;
        prmT000Q15 = new Object[] {
        new ParDef("@SolicitudesNombre",GXType.NChar,100,0) ,
        new ParDef("@SolicitudesLiqProf",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@CancelacionTipificacionId",GXType.Decimal,18,0) ,
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT000Q16;
        prmT000Q16 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT000Q17;
        prmT000Q17 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT000Q18;
        prmT000Q18 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT000Q19;
        prmT000Q19 = new Object[] {
        };
        Object[] prmT000Q20;
        prmT000Q20 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@RelacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT000Q21;
        prmT000Q21 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000Q22;
        prmT000Q22 = new Object[] {
        new ParDef("@EstadoSGTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadoSGId",GXType.Int32,5,0)
        };
        Object[] prmT000Q23;
        prmT000Q23 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@RelacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT000Q24;
        prmT000Q24 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@RelacionesId",GXType.Decimal,18,0) ,
        new ParDef("@SolicitudesRelacionesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@SolicitudesRelacionesFechaModi",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@EstadoSGTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadoSGId",GXType.Int32,5,0)
        };
        Object[] prmT000Q25;
        prmT000Q25 = new Object[] {
        new ParDef("@SolicitudesRelacionesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@SolicitudesRelacionesFechaModi",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@EstadoSGTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadoSGId",GXType.Int32,5,0) ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@RelacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT000Q26;
        prmT000Q26 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@RelacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT000Q27;
        prmT000Q27 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000Q28;
        prmT000Q28 = new Object[] {
        new ParDef("@EstadoSGTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadoSGId",GXType.Int32,5,0)
        };
        Object[] prmT000Q29;
        prmT000Q29 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT000Q30;
        prmT000Q30 = new Object[] {
        };
        Object[] prmT000Q31;
        prmT000Q31 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000Q32;
        prmT000Q32 = new Object[] {
        new ParDef("@EstadoSGTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadoSGId",GXType.Int32,5,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000Q2", "SELECT [SolicitudesID], [RelacionesId], [SolicitudesRelacionesFechaAlta], [SolicitudesRelacionesFechaModi], [ProfesionalesId], [EstadoSGTipo] AS EstadoSGTipo, [EstadoSGId] AS EstadoSGId FROM [Relaciones] WITH (UPDLOCK) WHERE [SolicitudesID] = @SolicitudesID AND [RelacionesId] = @RelacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q3", "SELECT [SolicitudesID], [RelacionesId], [SolicitudesRelacionesFechaAlta], [SolicitudesRelacionesFechaModi], [ProfesionalesId], [EstadoSGTipo] AS EstadoSGTipo, [EstadoSGId] AS EstadoSGId FROM [Relaciones] WHERE [SolicitudesID] = @SolicitudesID AND [RelacionesId] = @RelacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q4", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesApellidoPrimero] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q5", "SELECT [EstadosGenericosNombre] AS EstadoSGNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadoSGTipo AND [EstadosGenericosId] = @EstadoSGId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q6", "SELECT [SolicitudesID], [SolicitudesNombre], [SolicitudesLiqProf], [ProveedorID], [CancelacionTipificacionId], [CuponId] FROM [Solicitudes] WITH (UPDLOCK) WHERE [SolicitudesID] = @SolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q7", "SELECT [SolicitudesID], [SolicitudesNombre], [SolicitudesLiqProf], [ProveedorID], [CancelacionTipificacionId], [CuponId] FROM [Solicitudes] WHERE [SolicitudesID] = @SolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q8", "SELECT [ProveedorID] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q9", "SELECT TM1.[SolicitudesID], TM1.[SolicitudesNombre], TM1.[SolicitudesLiqProf], TM1.[ProveedorID], TM1.[CancelacionTipificacionId], TM1.[CuponId] FROM [Solicitudes] TM1 WHERE TM1.[SolicitudesID] = @SolicitudesID ORDER BY TM1.[SolicitudesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q9,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q10", "SELECT [ProveedorID] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q11", "SELECT [SolicitudesID] FROM [Solicitudes] WHERE [SolicitudesID] = @SolicitudesID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q12", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE ( [SolicitudesID] > @SolicitudesID) ORDER BY [SolicitudesID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Q13", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE ( [SolicitudesID] < @SolicitudesID) ORDER BY [SolicitudesID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Q14", cmdBufferT000Q14,true, GxErrorMask.GX_NOMASK, false, this,prmT000Q14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Q15", "UPDATE [Solicitudes] SET [SolicitudesNombre]=@SolicitudesNombre, [SolicitudesLiqProf]=@SolicitudesLiqProf, [ProveedorID]=@ProveedorID, [CancelacionTipificacionId]=@CancelacionTipificacionId, [CuponId]=@CuponId  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK,prmT000Q15)
           ,new CursorDef("T000Q16", "DELETE FROM [Solicitudes]  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK,prmT000Q16)
           ,new CursorDef("T000Q17", "SELECT TOP 1 [SolicitudesID], [ArchivoId] FROM [SolicitudesArchivo] WHERE [SolicitudesID] = @SolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Q18", "SELECT TOP 1 [SolicitudesID], [SolicitudesItemsID] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Q19", "SELECT [SolicitudesID] FROM [Solicitudes] ORDER BY [SolicitudesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q19,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q20", "SELECT T1.[SolicitudesID], T1.[RelacionesId], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesApellidoPrimero], T3.[EstadosGenericosNombre] AS EstadoSGNombre, T1.[SolicitudesRelacionesFechaAlta], T1.[SolicitudesRelacionesFechaModi], T1.[ProfesionalesId], T1.[EstadoSGTipo] AS EstadoSGTipo, T1.[EstadoSGId] AS EstadoSGId FROM (([Relaciones] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T1.[EstadoSGTipo] AND T3.[EstadosGenericosId] = T1.[EstadoSGId]) WHERE T1.[SolicitudesID] = @SolicitudesID and T1.[RelacionesId] = @RelacionesId ORDER BY T1.[SolicitudesID], T1.[RelacionesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q20,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q21", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesApellidoPrimero] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q22", "SELECT [EstadosGenericosNombre] AS EstadoSGNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadoSGTipo AND [EstadosGenericosId] = @EstadoSGId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q23", "SELECT [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE [SolicitudesID] = @SolicitudesID AND [RelacionesId] = @RelacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q24", "INSERT INTO [Relaciones]([SolicitudesID], [RelacionesId], [SolicitudesRelacionesFechaAlta], [SolicitudesRelacionesFechaModi], [ProfesionalesId], [EstadoSGTipo], [EstadoSGId]) VALUES(@SolicitudesID, @RelacionesId, @SolicitudesRelacionesFechaAlta, @SolicitudesRelacionesFechaModi, @ProfesionalesId, @EstadoSGTipo, @EstadoSGId)", GxErrorMask.GX_NOMASK,prmT000Q24)
           ,new CursorDef("T000Q25", "UPDATE [Relaciones] SET [SolicitudesRelacionesFechaAlta]=@SolicitudesRelacionesFechaAlta, [SolicitudesRelacionesFechaModi]=@SolicitudesRelacionesFechaModi, [ProfesionalesId]=@ProfesionalesId, [EstadoSGTipo]=@EstadoSGTipo, [EstadoSGId]=@EstadoSGId  WHERE [SolicitudesID] = @SolicitudesID AND [RelacionesId] = @RelacionesId", GxErrorMask.GX_NOMASK,prmT000Q25)
           ,new CursorDef("T000Q26", "DELETE FROM [Relaciones]  WHERE [SolicitudesID] = @SolicitudesID AND [RelacionesId] = @RelacionesId", GxErrorMask.GX_NOMASK,prmT000Q26)
           ,new CursorDef("T000Q27", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesApellidoPrimero] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q28", "SELECT [EstadosGenericosNombre] AS EstadoSGNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadoSGTipo AND [EstadosGenericosId] = @EstadoSGId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q29", "SELECT [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID], [RelacionesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q29,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q30", "SELECT T2.[EstadosTipo] AS EstadoSGTipo, T1.[SolicitudesID], T1.[RelacionesId], T1.[EstadoSGId] AS EstadoSGId, T2.[EstadosGenericosNombre] AS EstadoSGNombre FROM ([Relaciones] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadoSGTipo] AND T2.[EstadosGenericosId] = T1.[EstadoSGId]) ORDER BY T2.[EstadosGenericosNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q30,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q31", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesApellidoPrimero] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q31,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q32", "SELECT [EstadosGenericosNombre] AS EstadoSGNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadoSGTipo AND [EstadosGenericosId] = @EstadoSGId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q32,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
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
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getString(9, 3);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 28 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              return;
           case 29 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
     }
  }

}

}
